using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Draw Call")]
public class UIDrawCall : MonoBehaviour
{
	[DoNotObfuscateNGUI]
	public enum Clipping
	{
		None = 0,
		TextureMask = 1,
		SoftClip = 3,
		ConstrainButDontClip = 4
	}

	public delegate void OnRenderCallback(Material mat);

	public delegate void OnCreateDrawCall(UIDrawCall dc, MeshFilter filter, MeshRenderer ren);

	[DoNotObfuscateNGUI]
	public enum ShadowMode
	{
		None = 0,
		Receive = 1,
		CastAndReceive = 2
	}

	private static BetterList<UIDrawCall> mActiveList = new BetterList<UIDrawCall>();

	private static BetterList<UIDrawCall> mInactiveList = new BetterList<UIDrawCall>();

	[NonSerialized]
	[HideInInspector]
	public int widgetCount;

	[NonSerialized]
	[HideInInspector]
	public int depthStart = int.MaxValue;

	[NonSerialized]
	[HideInInspector]
	public int depthEnd = int.MinValue;

	[NonSerialized]
	[HideInInspector]
	public UIPanel manager;

	[NonSerialized]
	[HideInInspector]
	public UIPanel panel;

	[NonSerialized]
	[HideInInspector]
	public Texture2D clipTexture;

	[NonSerialized]
	[HideInInspector]
	public bool alwaysOnScreen;

	[NonSerialized]
	[HideInInspector]
	public List<Vector3> verts = new List<Vector3>();

	[NonSerialized]
	[HideInInspector]
	public List<Vector3> norms = new List<Vector3>();

	[NonSerialized]
	[HideInInspector]
	public List<Vector4> tans = new List<Vector4>();

	[NonSerialized]
	[HideInInspector]
	public List<Vector2> uvs = new List<Vector2>();

	[NonSerialized]
	[HideInInspector]
	public List<Vector4> uv2 = new List<Vector4>();

	[NonSerialized]
	[HideInInspector]
	public List<Color> cols = new List<Color>();

	[NonSerialized]
	private Material mMaterial;

	[NonSerialized]
	private Texture mTexture;

	[NonSerialized]
	private Shader mShader;

	[NonSerialized]
	private int mClipCount;

	[NonSerialized]
	private Transform mTrans;

	[NonSerialized]
	private Mesh mMesh;

	[NonSerialized]
	private MeshFilter mFilter;

	[NonSerialized]
	private MeshRenderer mRenderer;

	[NonSerialized]
	private Material mDynamicMat;

	[NonSerialized]
	private int[] mIndices;

	[NonSerialized]
	private ShadowMode mShadowMode;

	[NonSerialized]
	private bool mRebuildMat = true;

	[NonSerialized]
	private bool mLegacyShader;

	[NonSerialized]
	private int mRenderQueue = 3000;

	[NonSerialized]
	private int mTriangles;

	[NonSerialized]
	public bool isDirty;

	[NonSerialized]
	private bool mTextureClip;

	[NonSerialized]
	private bool mIsNew = true;

	public OnRenderCallback onRender;

	public OnCreateDrawCall onCreateDrawCall;

	[NonSerialized]
	private string mSortingLayerName;

	[NonSerialized]
	private int mSortingOrder;

	private static ColorSpace mColorSpace = ColorSpace.Uninitialized;

	private const int maxIndexBufferCache = 10;

	private static List<int[]> mCache = new List<int[]>(10);

	protected MaterialPropertyBlock mBlock;

	private static int[] ClipRange = null;

	private static int[] ClipArgs = null;

	private static int dx9BugWorkaround = -1;

	[Obsolete("Use UIDrawCall.activeList")]
	public static BetterList<UIDrawCall> list => mActiveList;

	public static BetterList<UIDrawCall> activeList => mActiveList;

	public static BetterList<UIDrawCall> inactiveList => mInactiveList;

	public int renderQueue
	{
		get
		{
			return mRenderQueue;
		}
		set
		{
			if (mRenderQueue != value)
			{
				mRenderQueue = value;
				if (mDynamicMat != null)
				{
					mDynamicMat.renderQueue = value;
				}
			}
		}
	}

	public int sortingOrder
	{
		get
		{
			return mSortingOrder;
		}
		set
		{
			if (mSortingOrder != value)
			{
				mSortingOrder = value;
				if (mRenderer != null)
				{
					mRenderer.sortingOrder = value;
				}
			}
		}
	}

	public string sortingLayerName
	{
		get
		{
			if (!string.IsNullOrEmpty(mSortingLayerName))
			{
				return mSortingLayerName;
			}
			if (mRenderer == null)
			{
				return null;
			}
			mSortingLayerName = mRenderer.sortingLayerName;
			return mSortingLayerName;
		}
		set
		{
			if (mRenderer != null && mSortingLayerName != value)
			{
				mSortingLayerName = value;
				mRenderer.sortingLayerName = value;
			}
		}
	}

	public int finalRenderQueue
	{
		get
		{
			if (!(mDynamicMat != null))
			{
				return mRenderQueue;
			}
			return mDynamicMat.renderQueue;
		}
	}

	public Transform cachedTransform
	{
		get
		{
			if (mTrans == null)
			{
				mTrans = base.transform;
			}
			return mTrans;
		}
	}

	public Material baseMaterial
	{
		get
		{
			return mMaterial;
		}
		set
		{
			if (mMaterial != value)
			{
				mMaterial = value;
				mRebuildMat = true;
			}
		}
	}

	public Material dynamicMaterial => mDynamicMat;

	public Texture mainTexture
	{
		get
		{
			return mTexture;
		}
		set
		{
			mTexture = value;
			if (mBlock == null)
			{
				mBlock = new MaterialPropertyBlock();
			}
			mBlock.SetTexture("_MainTex", (value != null) ? value : Texture2D.whiteTexture);
		}
	}

	public Shader shader
	{
		get
		{
			return mShader;
		}
		set
		{
			if (mShader != value)
			{
				mShader = value;
				mRebuildMat = true;
			}
		}
	}

	public ShadowMode shadowMode
	{
		get
		{
			return mShadowMode;
		}
		set
		{
			if (mShadowMode == value)
			{
				return;
			}
			mShadowMode = value;
			if (mRenderer != null)
			{
				if (mShadowMode == ShadowMode.None)
				{
					mRenderer.shadowCastingMode = ShadowCastingMode.Off;
					mRenderer.receiveShadows = false;
				}
				else if (mShadowMode == ShadowMode.Receive)
				{
					mRenderer.shadowCastingMode = ShadowCastingMode.Off;
					mRenderer.receiveShadows = true;
				}
				else
				{
					mRenderer.shadowCastingMode = ShadowCastingMode.On;
					mRenderer.receiveShadows = true;
				}
			}
		}
	}

	public int triangles
	{
		get
		{
			if (!(mMesh != null))
			{
				return 0;
			}
			return mTriangles;
		}
	}

	public bool isClipped => mClipCount != 0;

	private void CreateMaterial()
	{
		mTextureClip = false;
		mLegacyShader = false;
		mClipCount = panel.clipCount;
		string text = ((mShader != null) ? mShader.name : ((mMaterial != null) ? mMaterial.shader.name : "Unlit/Transparent Colored"));
		text = text.Replace("GUI/Text Shader", "Unlit/Text");
		if (text.Length > 2 && text[text.Length - 2] == ' ')
		{
			int num = text[text.Length - 1];
			if (num > 48 && num <= 57)
			{
				text = text.Substring(0, text.Length - 2);
			}
		}
		if (text.StartsWith("Hidden/"))
		{
			text = text.Substring(7);
		}
		text = text.Replace(" (SoftClip)", "");
		text = text.Replace(" (TextureClip)", "");
		if (panel != null && panel.clipping == Clipping.TextureMask)
		{
			mTextureClip = true;
			shader = Shader.Find("Hidden/" + text + " (TextureClip)");
		}
		else if (mClipCount != 0)
		{
			shader = Shader.Find("Hidden/" + text + " " + mClipCount);
			if (shader == null)
			{
				shader = Shader.Find(text + " " + mClipCount);
			}
			if (shader == null && mClipCount == 1)
			{
				mLegacyShader = true;
				shader = Shader.Find(text + " (SoftClip)");
			}
		}
		else
		{
			shader = Shader.Find(text);
		}
		if (shader == null)
		{
			shader = Shader.Find("Unlit/Transparent Colored");
		}
		if (mMaterial != null)
		{
			mDynamicMat = new Material(mMaterial);
			mDynamicMat.name = "[NGUI] " + mMaterial.name;
			mDynamicMat.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
			mDynamicMat.CopyPropertiesFromMaterial(mMaterial);
			string[] shaderKeywords = mMaterial.shaderKeywords;
			for (int i = 0; i < shaderKeywords.Length; i++)
			{
				mDynamicMat.EnableKeyword(shaderKeywords[i]);
			}
			if (shader != null)
			{
				mDynamicMat.shader = shader;
			}
			else if (mClipCount != 0)
			{
				Debug.LogError(text + " shader doesn't have a clipped shader version for " + mClipCount + " clip regions");
			}
		}
		else
		{
			mDynamicMat = new Material(shader);
			mDynamicMat.name = "[NGUI] " + shader.name;
			mDynamicMat.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
		}
	}

	private Material RebuildMaterial()
	{
		NGUITools.DestroyImmediate(mDynamicMat);
		CreateMaterial();
		mDynamicMat.renderQueue = mRenderQueue;
		if (mRenderer != null)
		{
			mRenderer.sharedMaterials = new Material[1] { mDynamicMat };
			mRenderer.sortingLayerName = mSortingLayerName;
			mRenderer.sortingOrder = mSortingOrder;
		}
		return mDynamicMat;
	}

	private void UpdateMaterials()
	{
		if (!(panel == null) && (mRebuildMat || mDynamicMat == null || mClipCount != panel.clipCount || mTextureClip != (panel.clipping == Clipping.TextureMask)))
		{
			RebuildMaterial();
			mRebuildMat = false;
		}
	}

	public void UpdateGeometry(int widgetCount, bool needsBounds)
	{
		this.widgetCount = widgetCount;
		int count = verts.Count;
		if (count > 0 && count == uvs.Count && count == cols.Count && count % 4 == 0)
		{
			if (mColorSpace == ColorSpace.Uninitialized)
			{
				mColorSpace = QualitySettings.activeColorSpace;
			}
			if (mColorSpace == ColorSpace.Linear)
			{
				for (int i = 0; i < count; i++)
				{
					Color value = cols[i];
					value.r = Mathf.GammaToLinearSpace(value.r);
					value.g = Mathf.GammaToLinearSpace(value.g);
					value.b = Mathf.GammaToLinearSpace(value.b);
					value.a = Mathf.GammaToLinearSpace(value.a);
					cols[i] = value;
				}
			}
			if (mFilter == null)
			{
				mFilter = base.gameObject.GetComponent<MeshFilter>();
			}
			if (mFilter == null)
			{
				mFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			if (count < 65000)
			{
				int num = (count >> 1) * 3;
				bool flag = mIndices == null || mIndices.Length != num;
				if (mMesh == null)
				{
					mMesh = new Mesh();
					mMesh.hideFlags = HideFlags.DontSave;
					mMesh.name = ((mMaterial != null) ? ("[NGUI] " + mMaterial.name) : "[NGUI] Mesh");
					if (dx9BugWorkaround == 0)
					{
						mMesh.MarkDynamic();
					}
					flag = true;
				}
				bool flag2 = uvs.Count != count || cols.Count != count || uv2.Count != count || norms.Count != count || tans.Count != count;
				if (!flag2 && panel != null && panel.renderQueue != 0)
				{
					flag2 = mMesh == null || mMesh.vertexCount != verts.Count;
				}
				if (!flag2 && count << 1 < verts.Count)
				{
					flag2 = true;
				}
				mTriangles = count >> 1;
				if (mMesh.vertexCount != count)
				{
					mMesh.Clear();
					flag = true;
				}
				mMesh.SetVertices(verts);
				mMesh.SetUVs(0, uvs);
				mMesh.SetColors(cols);
				mMesh.SetUVs(1, (uv2.Count == count) ? uv2 : null);
				mMesh.SetNormals((norms.Count == count) ? norms : null);
				mMesh.SetTangents((tans.Count == count) ? tans : null);
				if (flag)
				{
					mIndices = GenerateCachedIndexBuffer(count, num);
					mMesh.SetTriangles(mIndices, 0, needsBounds);
				}
				if (flag2 || !alwaysOnScreen)
				{
					mMesh.RecalculateBounds();
				}
				mFilter.mesh = mMesh;
			}
			else
			{
				mTriangles = 0;
				if (mMesh != null)
				{
					mMesh.Clear();
				}
				Debug.LogError("Too many vertices on one panel: " + count);
			}
			if (mRenderer == null)
			{
				mRenderer = base.gameObject.GetComponent<MeshRenderer>();
			}
			if (mRenderer == null)
			{
				mRenderer = base.gameObject.AddComponent<MeshRenderer>();
				if (mShadowMode == ShadowMode.None)
				{
					mRenderer.shadowCastingMode = ShadowCastingMode.Off;
					mRenderer.receiveShadows = false;
				}
				else if (mShadowMode == ShadowMode.Receive)
				{
					mRenderer.shadowCastingMode = ShadowCastingMode.Off;
					mRenderer.receiveShadows = true;
				}
				else
				{
					mRenderer.shadowCastingMode = ShadowCastingMode.On;
					mRenderer.receiveShadows = true;
				}
			}
			if (mIsNew)
			{
				mIsNew = false;
				if (onCreateDrawCall != null)
				{
					onCreateDrawCall(this, mFilter, mRenderer);
				}
			}
			UpdateMaterials();
		}
		else
		{
			if (mFilter.mesh != null)
			{
				mFilter.mesh.Clear();
			}
			Debug.LogError("UIWidgets must fill the buffer with 4 vertices per quad. Found " + count);
		}
		verts.Clear();
		uvs.Clear();
		uv2.Clear();
		cols.Clear();
		norms.Clear();
		tans.Clear();
	}

	private int[] GenerateCachedIndexBuffer(int vertexCount, int indexCount)
	{
		int i = 0;
		for (int count = mCache.Count; i < count; i++)
		{
			int[] array = mCache[i];
			if (array != null && array.Length == indexCount)
			{
				return array;
			}
		}
		int[] array2 = new int[indexCount];
		int num = 0;
		for (int j = 0; j < vertexCount; j += 4)
		{
			array2[num++] = j;
			array2[num++] = j + 1;
			array2[num++] = j + 2;
			array2[num++] = j + 2;
			array2[num++] = j + 3;
			array2[num++] = j;
		}
		if (mCache.Count > 10)
		{
			mCache.RemoveAt(0);
		}
		mCache.Add(array2);
		return array2;
	}

	private void OnWillRenderObject()
	{
		UpdateMaterials();
		if (mBlock != null)
		{
			mRenderer.SetPropertyBlock(mBlock);
		}
		if (onRender != null)
		{
			onRender((mDynamicMat != null) ? mDynamicMat : mMaterial);
		}
		if (mDynamicMat == null || mClipCount == 0)
		{
			return;
		}
		if (mTextureClip)
		{
			Vector4 drawCallClipRange = panel.drawCallClipRange;
			Vector2 clipSoftness = panel.clipSoftness;
			Vector2 vector = new Vector2(1000f, 1000f);
			if (clipSoftness.x > 0f)
			{
				vector.x = drawCallClipRange.z / clipSoftness.x;
			}
			if (clipSoftness.y > 0f)
			{
				vector.y = drawCallClipRange.w / clipSoftness.y;
			}
			mDynamicMat.SetVector(ClipRange[0], new Vector4((0f - drawCallClipRange.x) / drawCallClipRange.z, (0f - drawCallClipRange.y) / drawCallClipRange.w, 1f / drawCallClipRange.z, 1f / drawCallClipRange.w));
			mDynamicMat.SetTexture("_ClipTex", clipTexture);
		}
		else if (!mLegacyShader)
		{
			UIPanel parentPanel = panel;
			int num = 0;
			while (parentPanel != null)
			{
				if (parentPanel.hasClipping)
				{
					float angle = 0f;
					Vector4 drawCallClipRange2 = parentPanel.drawCallClipRange;
					if (parentPanel != panel)
					{
						Vector3 vector2 = parentPanel.cachedTransform.InverseTransformPoint(panel.cachedTransform.position);
						drawCallClipRange2.x -= vector2.x;
						drawCallClipRange2.y -= vector2.y;
						Vector3 eulerAngles = panel.cachedTransform.rotation.eulerAngles;
						Vector3 vector3 = parentPanel.cachedTransform.rotation.eulerAngles - eulerAngles;
						vector3.x = NGUIMath.WrapAngle(vector3.x);
						vector3.y = NGUIMath.WrapAngle(vector3.y);
						vector3.z = NGUIMath.WrapAngle(vector3.z);
						if (Mathf.Abs(vector3.x) > 0.001f || Mathf.Abs(vector3.y) > 0.001f)
						{
							Debug.LogWarning("Panel can only be clipped properly if X and Y rotation is left at 0", panel);
						}
						angle = vector3.z;
					}
					SetClipping(num++, drawCallClipRange2, parentPanel.clipSoftness, angle);
				}
				parentPanel = parentPanel.parentPanel;
			}
		}
		else
		{
			Vector2 clipSoftness2 = panel.clipSoftness;
			Vector4 drawCallClipRange3 = panel.drawCallClipRange;
			Vector2 mainTextureOffset = new Vector2((0f - drawCallClipRange3.x) / drawCallClipRange3.z, (0f - drawCallClipRange3.y) / drawCallClipRange3.w);
			Vector2 mainTextureScale = new Vector2(1f / drawCallClipRange3.z, 1f / drawCallClipRange3.w);
			Vector2 vector4 = new Vector2(1000f, 1000f);
			if (clipSoftness2.x > 0f)
			{
				vector4.x = drawCallClipRange3.z / clipSoftness2.x;
			}
			if (clipSoftness2.y > 0f)
			{
				vector4.y = drawCallClipRange3.w / clipSoftness2.y;
			}
			mDynamicMat.mainTextureOffset = mainTextureOffset;
			mDynamicMat.mainTextureScale = mainTextureScale;
			mDynamicMat.SetVector("_ClipSharpness", vector4);
		}
	}

	private void SetClipping(int index, Vector4 cr, Vector2 soft, float angle)
	{
		angle *= -MathF.PI / 180f;
		Vector2 vector = new Vector2(1000f, 1000f);
		if (soft.x > 0f)
		{
			vector.x = cr.z / soft.x;
		}
		if (soft.y > 0f)
		{
			vector.y = cr.w / soft.y;
		}
		if (index < ClipRange.Length)
		{
			mDynamicMat.SetVector(ClipRange[index], new Vector4((0f - cr.x) / cr.z, (0f - cr.y) / cr.w, 1f / cr.z, 1f / cr.w));
			mDynamicMat.SetVector(ClipArgs[index], new Vector4(vector.x, vector.y, Mathf.Sin(angle), Mathf.Cos(angle)));
		}
	}

	private void Awake()
	{
		if (dx9BugWorkaround == -1)
		{
			dx9BugWorkaround = ((Application.platform == RuntimePlatform.WindowsPlayer && SystemInfo.graphicsShaderLevel < 40 && SystemInfo.graphicsDeviceVersion.Contains("Direct3D")) ? 1 : 0);
		}
		if (ClipRange == null)
		{
			ClipRange = new int[4]
			{
				Shader.PropertyToID("_ClipRange0"),
				Shader.PropertyToID("_ClipRange1"),
				Shader.PropertyToID("_ClipRange2"),
				Shader.PropertyToID("_ClipRange4")
			};
		}
		if (ClipArgs == null)
		{
			ClipArgs = new int[4]
			{
				Shader.PropertyToID("_ClipArgs0"),
				Shader.PropertyToID("_ClipArgs1"),
				Shader.PropertyToID("_ClipArgs2"),
				Shader.PropertyToID("_ClipArgs3")
			};
		}
	}

	private void OnEnable()
	{
		mRebuildMat = true;
	}

	private void OnDisable()
	{
		depthStart = int.MaxValue;
		depthEnd = int.MinValue;
		panel = null;
		manager = null;
		mMaterial = null;
		mTexture = null;
		clipTexture = null;
		if (mRenderer != null)
		{
			mRenderer.sharedMaterials = new Material[0];
		}
		NGUITools.DestroyImmediate(mDynamicMat);
		mDynamicMat = null;
	}

	private void OnDestroy()
	{
		NGUITools.DestroyImmediate(mMesh);
		mMesh = null;
	}

	public static UIDrawCall Create(UIPanel panel, Material mat, Texture tex, Shader shader)
	{
		return Create(null, panel, mat, tex, shader);
	}

	private static UIDrawCall Create(string name, UIPanel pan, Material mat, Texture tex, Shader shader)
	{
		UIDrawCall uIDrawCall = Create(name);
		uIDrawCall.gameObject.layer = pan.cachedGameObject.layer;
		uIDrawCall.baseMaterial = mat;
		uIDrawCall.mainTexture = tex;
		uIDrawCall.shader = shader;
		uIDrawCall.renderQueue = pan.startingRenderQueue;
		uIDrawCall.sortingOrder = pan.sortingOrder;
		uIDrawCall.manager = pan;
		return uIDrawCall;
	}

	private static UIDrawCall Create(string name)
	{
		while (mInactiveList.size > 0)
		{
			UIDrawCall uIDrawCall = mInactiveList.Pop();
			if (uIDrawCall != null)
			{
				mActiveList.Add(uIDrawCall);
				if (name != null)
				{
					uIDrawCall.name = name;
				}
				NGUITools.SetActive(uIDrawCall.gameObject, state: true);
				return uIDrawCall;
			}
		}
		GameObject obj = new GameObject(name);
		UnityEngine.Object.DontDestroyOnLoad(obj);
		UIDrawCall uIDrawCall2 = obj.AddComponent<UIDrawCall>();
		mActiveList.Add(uIDrawCall2);
		return uIDrawCall2;
	}

	public static void ClearAll()
	{
		bool isPlaying = Application.isPlaying;
		int num = mActiveList.size;
		while (num > 0)
		{
			UIDrawCall uIDrawCall = mActiveList.buffer[--num];
			if ((bool)uIDrawCall)
			{
				if (isPlaying)
				{
					NGUITools.SetActive(uIDrawCall.gameObject, state: false);
				}
				else
				{
					NGUITools.DestroyImmediate(uIDrawCall.gameObject);
				}
			}
		}
		mActiveList.Clear();
	}

	public static void ReleaseAll()
	{
		ClearAll();
		ReleaseInactive();
	}

	public static void ReleaseInactive()
	{
		int num = mInactiveList.size;
		while (num > 0)
		{
			UIDrawCall uIDrawCall = mInactiveList.buffer[--num];
			if ((bool)uIDrawCall)
			{
				NGUITools.DestroyImmediate(uIDrawCall.gameObject);
			}
		}
		mInactiveList.Clear();
	}

	public static int Count(UIPanel panel)
	{
		int num = 0;
		for (int i = 0; i < mActiveList.size; i++)
		{
			if (mActiveList.buffer[i].manager == panel)
			{
				num++;
			}
		}
		return num;
	}

	public static void Destroy(UIDrawCall dc)
	{
		if (!dc)
		{
			return;
		}
		if (dc.onCreateDrawCall != null)
		{
			NGUITools.Destroy(dc.gameObject);
			return;
		}
		dc.onRender = null;
		if (Application.isPlaying)
		{
			if (mActiveList.Remove(dc))
			{
				NGUITools.SetActive(dc.gameObject, state: false);
				mInactiveList.Add(dc);
				dc.mIsNew = true;
			}
		}
		else
		{
			mActiveList.Remove(dc);
			NGUITools.DestroyImmediate(dc.gameObject);
		}
	}

	public static void MoveToScene(Scene scene)
	{
		foreach (UIDrawCall active in activeList)
		{
			SceneManager.MoveGameObjectToScene(active.gameObject, scene);
		}
		foreach (UIDrawCall inactive in inactiveList)
		{
			SceneManager.MoveGameObjectToScene(inactive.gameObject, scene);
		}
	}
}
