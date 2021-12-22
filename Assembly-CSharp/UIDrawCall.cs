using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

// Token: 0x0200007F RID: 127
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Draw Call")]
public class UIDrawCall : MonoBehaviour
{
	// Token: 0x1700007B RID: 123
	// (get) Token: 0x0600048E RID: 1166 RVA: 0x0002F28D File Offset: 0x0002D48D
	[Obsolete("Use UIDrawCall.activeList")]
	public static BetterList<UIDrawCall> list
	{
		get
		{
			return UIDrawCall.mActiveList;
		}
	}

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x0600048F RID: 1167 RVA: 0x0002F294 File Offset: 0x0002D494
	public static BetterList<UIDrawCall> activeList
	{
		get
		{
			return UIDrawCall.mActiveList;
		}
	}

	// Token: 0x1700007D RID: 125
	// (get) Token: 0x06000490 RID: 1168 RVA: 0x0002F29B File Offset: 0x0002D49B
	public static BetterList<UIDrawCall> inactiveList
	{
		get
		{
			return UIDrawCall.mInactiveList;
		}
	}

	// Token: 0x1700007E RID: 126
	// (get) Token: 0x06000491 RID: 1169 RVA: 0x0002F2A2 File Offset: 0x0002D4A2
	// (set) Token: 0x06000492 RID: 1170 RVA: 0x0002F2AA File Offset: 0x0002D4AA
	public int renderQueue
	{
		get
		{
			return this.mRenderQueue;
		}
		set
		{
			if (this.mRenderQueue != value)
			{
				this.mRenderQueue = value;
				if (this.mDynamicMat != null)
				{
					this.mDynamicMat.renderQueue = value;
				}
			}
		}
	}

	// Token: 0x1700007F RID: 127
	// (get) Token: 0x06000493 RID: 1171 RVA: 0x0002F2D6 File Offset: 0x0002D4D6
	// (set) Token: 0x06000494 RID: 1172 RVA: 0x0002F2DE File Offset: 0x0002D4DE
	public int sortingOrder
	{
		get
		{
			return this.mSortingOrder;
		}
		set
		{
			if (this.mSortingOrder != value)
			{
				this.mSortingOrder = value;
				if (this.mRenderer != null)
				{
					this.mRenderer.sortingOrder = value;
				}
			}
		}
	}

	// Token: 0x17000080 RID: 128
	// (get) Token: 0x06000495 RID: 1173 RVA: 0x0002F30A File Offset: 0x0002D50A
	// (set) Token: 0x06000496 RID: 1174 RVA: 0x0002F347 File Offset: 0x0002D547
	public string sortingLayerName
	{
		get
		{
			if (!string.IsNullOrEmpty(this.mSortingLayerName))
			{
				return this.mSortingLayerName;
			}
			if (this.mRenderer == null)
			{
				return null;
			}
			this.mSortingLayerName = this.mRenderer.sortingLayerName;
			return this.mSortingLayerName;
		}
		set
		{
			if (this.mRenderer != null && this.mSortingLayerName != value)
			{
				this.mSortingLayerName = value;
				this.mRenderer.sortingLayerName = value;
			}
		}
	}

	// Token: 0x17000081 RID: 129
	// (get) Token: 0x06000497 RID: 1175 RVA: 0x0002F378 File Offset: 0x0002D578
	public int finalRenderQueue
	{
		get
		{
			if (!(this.mDynamicMat != null))
			{
				return this.mRenderQueue;
			}
			return this.mDynamicMat.renderQueue;
		}
	}

	// Token: 0x17000082 RID: 130
	// (get) Token: 0x06000498 RID: 1176 RVA: 0x0002F39A File Offset: 0x0002D59A
	public Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x17000083 RID: 131
	// (get) Token: 0x06000499 RID: 1177 RVA: 0x0002F3BC File Offset: 0x0002D5BC
	// (set) Token: 0x0600049A RID: 1178 RVA: 0x0002F3C4 File Offset: 0x0002D5C4
	public Material baseMaterial
	{
		get
		{
			return this.mMaterial;
		}
		set
		{
			if (this.mMaterial != value)
			{
				this.mMaterial = value;
				this.mRebuildMat = true;
			}
		}
	}

	// Token: 0x17000084 RID: 132
	// (get) Token: 0x0600049B RID: 1179 RVA: 0x0002F3E2 File Offset: 0x0002D5E2
	public Material dynamicMaterial
	{
		get
		{
			return this.mDynamicMat;
		}
	}

	// Token: 0x17000085 RID: 133
	// (get) Token: 0x0600049C RID: 1180 RVA: 0x0002F3EA File Offset: 0x0002D5EA
	// (set) Token: 0x0600049D RID: 1181 RVA: 0x0002F3F2 File Offset: 0x0002D5F2
	public Texture mainTexture
	{
		get
		{
			return this.mTexture;
		}
		set
		{
			this.mTexture = value;
			if (this.mBlock == null)
			{
				this.mBlock = new MaterialPropertyBlock();
			}
			this.mBlock.SetTexture("_MainTex", (value != null) ? value : Texture2D.whiteTexture);
		}
	}

	// Token: 0x17000086 RID: 134
	// (get) Token: 0x0600049E RID: 1182 RVA: 0x0002F42F File Offset: 0x0002D62F
	// (set) Token: 0x0600049F RID: 1183 RVA: 0x0002F437 File Offset: 0x0002D637
	public Shader shader
	{
		get
		{
			return this.mShader;
		}
		set
		{
			if (this.mShader != value)
			{
				this.mShader = value;
				this.mRebuildMat = true;
			}
		}
	}

	// Token: 0x17000087 RID: 135
	// (get) Token: 0x060004A0 RID: 1184 RVA: 0x0002F455 File Offset: 0x0002D655
	// (set) Token: 0x060004A1 RID: 1185 RVA: 0x0002F460 File Offset: 0x0002D660
	public UIDrawCall.ShadowMode shadowMode
	{
		get
		{
			return this.mShadowMode;
		}
		set
		{
			if (this.mShadowMode != value)
			{
				this.mShadowMode = value;
				if (this.mRenderer != null)
				{
					if (this.mShadowMode == UIDrawCall.ShadowMode.None)
					{
						this.mRenderer.shadowCastingMode = ShadowCastingMode.Off;
						this.mRenderer.receiveShadows = false;
						return;
					}
					if (this.mShadowMode == UIDrawCall.ShadowMode.Receive)
					{
						this.mRenderer.shadowCastingMode = ShadowCastingMode.Off;
						this.mRenderer.receiveShadows = true;
						return;
					}
					this.mRenderer.shadowCastingMode = ShadowCastingMode.On;
					this.mRenderer.receiveShadows = true;
				}
			}
		}
	}

	// Token: 0x17000088 RID: 136
	// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0002F4E6 File Offset: 0x0002D6E6
	public int triangles
	{
		get
		{
			if (!(this.mMesh != null))
			{
				return 0;
			}
			return this.mTriangles;
		}
	}

	// Token: 0x17000089 RID: 137
	// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0002F4FE File Offset: 0x0002D6FE
	public bool isClipped
	{
		get
		{
			return this.mClipCount != 0;
		}
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x0002F50C File Offset: 0x0002D70C
	private void CreateMaterial()
	{
		this.mTextureClip = false;
		this.mLegacyShader = false;
		this.mClipCount = this.panel.clipCount;
		string text = (this.mShader != null) ? this.mShader.name : ((this.mMaterial != null) ? this.mMaterial.shader.name : "Unlit/Transparent Colored");
		text = text.Replace("GUI/Text Shader", "Unlit/Text");
		if (text.Length > 2 && text[text.Length - 2] == ' ')
		{
			int num = (int)text[text.Length - 1];
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
		if (this.panel != null && this.panel.clipping == UIDrawCall.Clipping.TextureMask)
		{
			this.mTextureClip = true;
			this.shader = Shader.Find("Hidden/" + text + " (TextureClip)");
		}
		else if (this.mClipCount != 0)
		{
			this.shader = Shader.Find("Hidden/" + text + " " + this.mClipCount.ToString());
			if (this.shader == null)
			{
				this.shader = Shader.Find(text + " " + this.mClipCount.ToString());
			}
			if (this.shader == null && this.mClipCount == 1)
			{
				this.mLegacyShader = true;
				this.shader = Shader.Find(text + " (SoftClip)");
			}
		}
		else
		{
			this.shader = Shader.Find(text);
		}
		if (this.shader == null)
		{
			this.shader = Shader.Find("Unlit/Transparent Colored");
		}
		if (this.mMaterial != null)
		{
			this.mDynamicMat = new Material(this.mMaterial);
			this.mDynamicMat.name = "[NGUI] " + this.mMaterial.name;
			this.mDynamicMat.hideFlags = (HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
			this.mDynamicMat.CopyPropertiesFromMaterial(this.mMaterial);
			string[] shaderKeywords = this.mMaterial.shaderKeywords;
			for (int i = 0; i < shaderKeywords.Length; i++)
			{
				this.mDynamicMat.EnableKeyword(shaderKeywords[i]);
			}
			if (this.shader != null)
			{
				this.mDynamicMat.shader = this.shader;
				return;
			}
			if (this.mClipCount != 0)
			{
				Debug.LogError(text + " shader doesn't have a clipped shader version for " + this.mClipCount.ToString() + " clip regions");
				return;
			}
		}
		else
		{
			this.mDynamicMat = new Material(this.shader);
			this.mDynamicMat.name = "[NGUI] " + this.shader.name;
			this.mDynamicMat.hideFlags = (HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
		}
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x0002F818 File Offset: 0x0002DA18
	private Material RebuildMaterial()
	{
		NGUITools.DestroyImmediate(this.mDynamicMat);
		this.CreateMaterial();
		this.mDynamicMat.renderQueue = this.mRenderQueue;
		if (this.mRenderer != null)
		{
			this.mRenderer.sharedMaterials = new Material[]
			{
				this.mDynamicMat
			};
			this.mRenderer.sortingLayerName = this.mSortingLayerName;
			this.mRenderer.sortingOrder = this.mSortingOrder;
		}
		return this.mDynamicMat;
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x0002F898 File Offset: 0x0002DA98
	private void UpdateMaterials()
	{
		if (this.panel == null)
		{
			return;
		}
		if (this.mRebuildMat || this.mDynamicMat == null || this.mClipCount != this.panel.clipCount || this.mTextureClip != (this.panel.clipping == UIDrawCall.Clipping.TextureMask))
		{
			this.RebuildMaterial();
			this.mRebuildMat = false;
		}
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x0002F904 File Offset: 0x0002DB04
	public void UpdateGeometry(int widgetCount, bool needsBounds)
	{
		this.widgetCount = widgetCount;
		int count = this.verts.Count;
		if (count > 0 && count == this.uvs.Count && count == this.cols.Count && count % 4 == 0)
		{
			if (UIDrawCall.mColorSpace == ColorSpace.Uninitialized)
			{
				UIDrawCall.mColorSpace = QualitySettings.activeColorSpace;
			}
			if (UIDrawCall.mColorSpace == ColorSpace.Linear)
			{
				for (int i = 0; i < count; i++)
				{
					Color color = this.cols[i];
					color.r = Mathf.GammaToLinearSpace(color.r);
					color.g = Mathf.GammaToLinearSpace(color.g);
					color.b = Mathf.GammaToLinearSpace(color.b);
					color.a = Mathf.GammaToLinearSpace(color.a);
					this.cols[i] = color;
				}
			}
			if (this.mFilter == null)
			{
				this.mFilter = base.gameObject.GetComponent<MeshFilter>();
			}
			if (this.mFilter == null)
			{
				this.mFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			if (count < 65000)
			{
				int num = (count >> 1) * 3;
				bool flag = this.mIndices == null || this.mIndices.Length != num;
				if (this.mMesh == null)
				{
					this.mMesh = new Mesh();
					this.mMesh.hideFlags = HideFlags.DontSave;
					this.mMesh.name = ((this.mMaterial != null) ? ("[NGUI] " + this.mMaterial.name) : "[NGUI] Mesh");
					if (UIDrawCall.dx9BugWorkaround == 0)
					{
						this.mMesh.MarkDynamic();
					}
					flag = true;
				}
				bool flag2 = this.uvs.Count != count || this.cols.Count != count || this.uv2.Count != count || this.norms.Count != count || this.tans.Count != count;
				if (!flag2 && this.panel != null && this.panel.renderQueue != UIPanel.RenderQueue.Automatic)
				{
					flag2 = (this.mMesh == null || this.mMesh.vertexCount != this.verts.Count);
				}
				if (!flag2 && count << 1 < this.verts.Count)
				{
					flag2 = true;
				}
				this.mTriangles = count >> 1;
				if (this.mMesh.vertexCount != count)
				{
					this.mMesh.Clear();
					flag = true;
				}
				this.mMesh.SetVertices(this.verts);
				this.mMesh.SetUVs(0, this.uvs);
				this.mMesh.SetColors(this.cols);
				this.mMesh.SetUVs(1, (this.uv2.Count == count) ? this.uv2 : null);
				this.mMesh.SetNormals((this.norms.Count == count) ? this.norms : null);
				this.mMesh.SetTangents((this.tans.Count == count) ? this.tans : null);
				if (flag)
				{
					this.mIndices = this.GenerateCachedIndexBuffer(count, num);
					this.mMesh.SetTriangles(this.mIndices, 0, needsBounds);
				}
				if (flag2 || !this.alwaysOnScreen)
				{
					this.mMesh.RecalculateBounds();
				}
				this.mFilter.mesh = this.mMesh;
			}
			else
			{
				this.mTriangles = 0;
				if (this.mMesh != null)
				{
					this.mMesh.Clear();
				}
				Debug.LogError("Too many vertices on one panel: " + count.ToString());
			}
			if (this.mRenderer == null)
			{
				this.mRenderer = base.gameObject.GetComponent<MeshRenderer>();
			}
			if (this.mRenderer == null)
			{
				this.mRenderer = base.gameObject.AddComponent<MeshRenderer>();
				if (this.mShadowMode == UIDrawCall.ShadowMode.None)
				{
					this.mRenderer.shadowCastingMode = ShadowCastingMode.Off;
					this.mRenderer.receiveShadows = false;
				}
				else if (this.mShadowMode == UIDrawCall.ShadowMode.Receive)
				{
					this.mRenderer.shadowCastingMode = ShadowCastingMode.Off;
					this.mRenderer.receiveShadows = true;
				}
				else
				{
					this.mRenderer.shadowCastingMode = ShadowCastingMode.On;
					this.mRenderer.receiveShadows = true;
				}
			}
			if (this.mIsNew)
			{
				this.mIsNew = false;
				if (this.onCreateDrawCall != null)
				{
					this.onCreateDrawCall(this, this.mFilter, this.mRenderer);
				}
			}
			this.UpdateMaterials();
		}
		else
		{
			if (this.mFilter.mesh != null)
			{
				this.mFilter.mesh.Clear();
			}
			Debug.LogError("UIWidgets must fill the buffer with 4 vertices per quad. Found " + count.ToString());
		}
		this.verts.Clear();
		this.uvs.Clear();
		this.uv2.Clear();
		this.cols.Clear();
		this.norms.Clear();
		this.tans.Clear();
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x0002FDFC File Offset: 0x0002DFFC
	private int[] GenerateCachedIndexBuffer(int vertexCount, int indexCount)
	{
		int i = 0;
		int count = UIDrawCall.mCache.Count;
		while (i < count)
		{
			int[] array = UIDrawCall.mCache[i];
			if (array != null && array.Length == indexCount)
			{
				return array;
			}
			i++;
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
		if (UIDrawCall.mCache.Count > 10)
		{
			UIDrawCall.mCache.RemoveAt(0);
		}
		UIDrawCall.mCache.Add(array2);
		return array2;
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0002FEB8 File Offset: 0x0002E0B8
	private void OnWillRenderObject()
	{
		this.UpdateMaterials();
		if (this.mBlock != null)
		{
			this.mRenderer.SetPropertyBlock(this.mBlock);
		}
		if (this.onRender != null)
		{
			this.onRender((this.mDynamicMat != null) ? this.mDynamicMat : this.mMaterial);
		}
		if (this.mDynamicMat == null || this.mClipCount == 0)
		{
			return;
		}
		if (this.mTextureClip)
		{
			Vector4 drawCallClipRange = this.panel.drawCallClipRange;
			Vector2 clipSoftness = this.panel.clipSoftness;
			Vector2 vector = new Vector2(1000f, 1000f);
			if (clipSoftness.x > 0f)
			{
				vector.x = drawCallClipRange.z / clipSoftness.x;
			}
			if (clipSoftness.y > 0f)
			{
				vector.y = drawCallClipRange.w / clipSoftness.y;
			}
			this.mDynamicMat.SetVector(UIDrawCall.ClipRange[0], new Vector4(-drawCallClipRange.x / drawCallClipRange.z, -drawCallClipRange.y / drawCallClipRange.w, 1f / drawCallClipRange.z, 1f / drawCallClipRange.w));
			this.mDynamicMat.SetTexture("_ClipTex", this.clipTexture);
			return;
		}
		if (!this.mLegacyShader)
		{
			UIPanel parentPanel = this.panel;
			int num = 0;
			while (parentPanel != null)
			{
				if (parentPanel.hasClipping)
				{
					float angle = 0f;
					Vector4 drawCallClipRange2 = parentPanel.drawCallClipRange;
					if (parentPanel != this.panel)
					{
						Vector3 vector2 = parentPanel.cachedTransform.InverseTransformPoint(this.panel.cachedTransform.position);
						drawCallClipRange2.x -= vector2.x;
						drawCallClipRange2.y -= vector2.y;
						Vector3 eulerAngles = this.panel.cachedTransform.rotation.eulerAngles;
						Vector3 vector3 = parentPanel.cachedTransform.rotation.eulerAngles - eulerAngles;
						vector3.x = NGUIMath.WrapAngle(vector3.x);
						vector3.y = NGUIMath.WrapAngle(vector3.y);
						vector3.z = NGUIMath.WrapAngle(vector3.z);
						if (Mathf.Abs(vector3.x) > 0.001f || Mathf.Abs(vector3.y) > 0.001f)
						{
							Debug.LogWarning("Panel can only be clipped properly if X and Y rotation is left at 0", this.panel);
						}
						angle = vector3.z;
					}
					this.SetClipping(num++, drawCallClipRange2, parentPanel.clipSoftness, angle);
				}
				parentPanel = parentPanel.parentPanel;
			}
			return;
		}
		Vector2 clipSoftness2 = this.panel.clipSoftness;
		Vector4 drawCallClipRange3 = this.panel.drawCallClipRange;
		Vector2 mainTextureOffset = new Vector2(-drawCallClipRange3.x / drawCallClipRange3.z, -drawCallClipRange3.y / drawCallClipRange3.w);
		Vector2 mainTextureScale = new Vector2(1f / drawCallClipRange3.z, 1f / drawCallClipRange3.w);
		Vector2 v = new Vector2(1000f, 1000f);
		if (clipSoftness2.x > 0f)
		{
			v.x = drawCallClipRange3.z / clipSoftness2.x;
		}
		if (clipSoftness2.y > 0f)
		{
			v.y = drawCallClipRange3.w / clipSoftness2.y;
		}
		this.mDynamicMat.mainTextureOffset = mainTextureOffset;
		this.mDynamicMat.mainTextureScale = mainTextureScale;
		this.mDynamicMat.SetVector("_ClipSharpness", v);
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x00030250 File Offset: 0x0002E450
	private void SetClipping(int index, Vector4 cr, Vector2 soft, float angle)
	{
		angle *= -0.017453292f;
		Vector2 vector = new Vector2(1000f, 1000f);
		if (soft.x > 0f)
		{
			vector.x = cr.z / soft.x;
		}
		if (soft.y > 0f)
		{
			vector.y = cr.w / soft.y;
		}
		if (index < UIDrawCall.ClipRange.Length)
		{
			this.mDynamicMat.SetVector(UIDrawCall.ClipRange[index], new Vector4(-cr.x / cr.z, -cr.y / cr.w, 1f / cr.z, 1f / cr.w));
			this.mDynamicMat.SetVector(UIDrawCall.ClipArgs[index], new Vector4(vector.x, vector.y, Mathf.Sin(angle), Mathf.Cos(angle)));
		}
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x00030340 File Offset: 0x0002E540
	private void Awake()
	{
		if (UIDrawCall.dx9BugWorkaround == -1)
		{
			UIDrawCall.dx9BugWorkaround = ((Application.platform == RuntimePlatform.WindowsPlayer && SystemInfo.graphicsShaderLevel < 40 && SystemInfo.graphicsDeviceVersion.Contains("Direct3D")) ? 1 : 0);
		}
		if (UIDrawCall.ClipRange == null)
		{
			UIDrawCall.ClipRange = new int[]
			{
				Shader.PropertyToID("_ClipRange0"),
				Shader.PropertyToID("_ClipRange1"),
				Shader.PropertyToID("_ClipRange2"),
				Shader.PropertyToID("_ClipRange4")
			};
		}
		if (UIDrawCall.ClipArgs == null)
		{
			UIDrawCall.ClipArgs = new int[]
			{
				Shader.PropertyToID("_ClipArgs0"),
				Shader.PropertyToID("_ClipArgs1"),
				Shader.PropertyToID("_ClipArgs2"),
				Shader.PropertyToID("_ClipArgs3")
			};
		}
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x0003040C File Offset: 0x0002E60C
	private void OnEnable()
	{
		this.mRebuildMat = true;
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x00030418 File Offset: 0x0002E618
	private void OnDisable()
	{
		this.depthStart = int.MaxValue;
		this.depthEnd = int.MinValue;
		this.panel = null;
		this.manager = null;
		this.mMaterial = null;
		this.mTexture = null;
		this.clipTexture = null;
		if (this.mRenderer != null)
		{
			this.mRenderer.sharedMaterials = new Material[0];
		}
		NGUITools.DestroyImmediate(this.mDynamicMat);
		this.mDynamicMat = null;
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x0003048F File Offset: 0x0002E68F
	private void OnDestroy()
	{
		NGUITools.DestroyImmediate(this.mMesh);
		this.mMesh = null;
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x000304A3 File Offset: 0x0002E6A3
	public static UIDrawCall Create(UIPanel panel, Material mat, Texture tex, Shader shader)
	{
		return UIDrawCall.Create(null, panel, mat, tex, shader);
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x000304B0 File Offset: 0x0002E6B0
	private static UIDrawCall Create(string name, UIPanel pan, Material mat, Texture tex, Shader shader)
	{
		UIDrawCall uidrawCall = UIDrawCall.Create(name);
		uidrawCall.gameObject.layer = pan.cachedGameObject.layer;
		uidrawCall.baseMaterial = mat;
		uidrawCall.mainTexture = tex;
		uidrawCall.shader = shader;
		uidrawCall.renderQueue = pan.startingRenderQueue;
		uidrawCall.sortingOrder = pan.sortingOrder;
		uidrawCall.manager = pan;
		return uidrawCall;
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x00030510 File Offset: 0x0002E710
	private static UIDrawCall Create(string name)
	{
		while (UIDrawCall.mInactiveList.size > 0)
		{
			UIDrawCall uidrawCall = UIDrawCall.mInactiveList.Pop();
			if (uidrawCall != null)
			{
				UIDrawCall.mActiveList.Add(uidrawCall);
				if (name != null)
				{
					uidrawCall.name = name;
				}
				NGUITools.SetActive(uidrawCall.gameObject, true);
				return uidrawCall;
			}
		}
		GameObject gameObject = new GameObject(name);
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		UIDrawCall uidrawCall2 = gameObject.AddComponent<UIDrawCall>();
		UIDrawCall.mActiveList.Add(uidrawCall2);
		return uidrawCall2;
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x00030584 File Offset: 0x0002E784
	public static void ClearAll()
	{
		bool isPlaying = Application.isPlaying;
		int i = UIDrawCall.mActiveList.size;
		while (i > 0)
		{
			UIDrawCall uidrawCall = UIDrawCall.mActiveList.buffer[--i];
			if (uidrawCall)
			{
				if (isPlaying)
				{
					NGUITools.SetActive(uidrawCall.gameObject, false);
				}
				else
				{
					NGUITools.DestroyImmediate(uidrawCall.gameObject);
				}
			}
		}
		UIDrawCall.mActiveList.Clear();
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x000305E7 File Offset: 0x0002E7E7
	public static void ReleaseAll()
	{
		UIDrawCall.ClearAll();
		UIDrawCall.ReleaseInactive();
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x000305F4 File Offset: 0x0002E7F4
	public static void ReleaseInactive()
	{
		int i = UIDrawCall.mInactiveList.size;
		while (i > 0)
		{
			UIDrawCall uidrawCall = UIDrawCall.mInactiveList.buffer[--i];
			if (uidrawCall)
			{
				NGUITools.DestroyImmediate(uidrawCall.gameObject);
			}
		}
		UIDrawCall.mInactiveList.Clear();
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x00030640 File Offset: 0x0002E840
	public static int Count(UIPanel panel)
	{
		int num = 0;
		for (int i = 0; i < UIDrawCall.mActiveList.size; i++)
		{
			if (UIDrawCall.mActiveList.buffer[i].manager == panel)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x00030684 File Offset: 0x0002E884
	public static void Destroy(UIDrawCall dc)
	{
		if (dc)
		{
			if (dc.onCreateDrawCall != null)
			{
				NGUITools.Destroy(dc.gameObject);
				return;
			}
			dc.onRender = null;
			if (Application.isPlaying)
			{
				if (UIDrawCall.mActiveList.Remove(dc))
				{
					NGUITools.SetActive(dc.gameObject, false);
					UIDrawCall.mInactiveList.Add(dc);
					dc.mIsNew = true;
					return;
				}
			}
			else
			{
				UIDrawCall.mActiveList.Remove(dc);
				NGUITools.DestroyImmediate(dc.gameObject);
			}
		}
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x00030700 File Offset: 0x0002E900
	public static void MoveToScene(Scene scene)
	{
		foreach (UIDrawCall uidrawCall in UIDrawCall.activeList)
		{
			SceneManager.MoveGameObjectToScene(uidrawCall.gameObject, scene);
		}
		foreach (UIDrawCall uidrawCall2 in UIDrawCall.inactiveList)
		{
			SceneManager.MoveGameObjectToScene(uidrawCall2.gameObject, scene);
		}
	}

	// Token: 0x0400050E RID: 1294
	private static BetterList<UIDrawCall> mActiveList = new BetterList<UIDrawCall>();

	// Token: 0x0400050F RID: 1295
	private static BetterList<UIDrawCall> mInactiveList = new BetterList<UIDrawCall>();

	// Token: 0x04000510 RID: 1296
	[HideInInspector]
	[NonSerialized]
	public int widgetCount;

	// Token: 0x04000511 RID: 1297
	[HideInInspector]
	[NonSerialized]
	public int depthStart = int.MaxValue;

	// Token: 0x04000512 RID: 1298
	[HideInInspector]
	[NonSerialized]
	public int depthEnd = int.MinValue;

	// Token: 0x04000513 RID: 1299
	[HideInInspector]
	[NonSerialized]
	public UIPanel manager;

	// Token: 0x04000514 RID: 1300
	[HideInInspector]
	[NonSerialized]
	public UIPanel panel;

	// Token: 0x04000515 RID: 1301
	[HideInInspector]
	[NonSerialized]
	public Texture2D clipTexture;

	// Token: 0x04000516 RID: 1302
	[HideInInspector]
	[NonSerialized]
	public bool alwaysOnScreen;

	// Token: 0x04000517 RID: 1303
	[HideInInspector]
	[NonSerialized]
	public List<Vector3> verts = new List<Vector3>();

	// Token: 0x04000518 RID: 1304
	[HideInInspector]
	[NonSerialized]
	public List<Vector3> norms = new List<Vector3>();

	// Token: 0x04000519 RID: 1305
	[HideInInspector]
	[NonSerialized]
	public List<Vector4> tans = new List<Vector4>();

	// Token: 0x0400051A RID: 1306
	[HideInInspector]
	[NonSerialized]
	public List<Vector2> uvs = new List<Vector2>();

	// Token: 0x0400051B RID: 1307
	[HideInInspector]
	[NonSerialized]
	public List<Vector4> uv2 = new List<Vector4>();

	// Token: 0x0400051C RID: 1308
	[HideInInspector]
	[NonSerialized]
	public List<Color> cols = new List<Color>();

	// Token: 0x0400051D RID: 1309
	[NonSerialized]
	private Material mMaterial;

	// Token: 0x0400051E RID: 1310
	[NonSerialized]
	private Texture mTexture;

	// Token: 0x0400051F RID: 1311
	[NonSerialized]
	private Shader mShader;

	// Token: 0x04000520 RID: 1312
	[NonSerialized]
	private int mClipCount;

	// Token: 0x04000521 RID: 1313
	[NonSerialized]
	private Transform mTrans;

	// Token: 0x04000522 RID: 1314
	[NonSerialized]
	private Mesh mMesh;

	// Token: 0x04000523 RID: 1315
	[NonSerialized]
	private MeshFilter mFilter;

	// Token: 0x04000524 RID: 1316
	[NonSerialized]
	private MeshRenderer mRenderer;

	// Token: 0x04000525 RID: 1317
	[NonSerialized]
	private Material mDynamicMat;

	// Token: 0x04000526 RID: 1318
	[NonSerialized]
	private int[] mIndices;

	// Token: 0x04000527 RID: 1319
	[NonSerialized]
	private UIDrawCall.ShadowMode mShadowMode;

	// Token: 0x04000528 RID: 1320
	[NonSerialized]
	private bool mRebuildMat = true;

	// Token: 0x04000529 RID: 1321
	[NonSerialized]
	private bool mLegacyShader;

	// Token: 0x0400052A RID: 1322
	[NonSerialized]
	private int mRenderQueue = 3000;

	// Token: 0x0400052B RID: 1323
	[NonSerialized]
	private int mTriangles;

	// Token: 0x0400052C RID: 1324
	[NonSerialized]
	public bool isDirty;

	// Token: 0x0400052D RID: 1325
	[NonSerialized]
	private bool mTextureClip;

	// Token: 0x0400052E RID: 1326
	[NonSerialized]
	private bool mIsNew = true;

	// Token: 0x0400052F RID: 1327
	public UIDrawCall.OnRenderCallback onRender;

	// Token: 0x04000530 RID: 1328
	public UIDrawCall.OnCreateDrawCall onCreateDrawCall;

	// Token: 0x04000531 RID: 1329
	[NonSerialized]
	private string mSortingLayerName;

	// Token: 0x04000532 RID: 1330
	[NonSerialized]
	private int mSortingOrder;

	// Token: 0x04000533 RID: 1331
	private static ColorSpace mColorSpace = ColorSpace.Uninitialized;

	// Token: 0x04000534 RID: 1332
	private const int maxIndexBufferCache = 10;

	// Token: 0x04000535 RID: 1333
	private static List<int[]> mCache = new List<int[]>(10);

	// Token: 0x04000536 RID: 1334
	protected MaterialPropertyBlock mBlock;

	// Token: 0x04000537 RID: 1335
	private static int[] ClipRange = null;

	// Token: 0x04000538 RID: 1336
	private static int[] ClipArgs = null;

	// Token: 0x04000539 RID: 1337
	private static int dx9BugWorkaround = -1;

	// Token: 0x020005F5 RID: 1525
	[DoNotObfuscateNGUI]
	public enum Clipping
	{
		// Token: 0x04004DA3 RID: 19875
		None,
		// Token: 0x04004DA4 RID: 19876
		TextureMask,
		// Token: 0x04004DA5 RID: 19877
		SoftClip = 3,
		// Token: 0x04004DA6 RID: 19878
		ConstrainButDontClip
	}

	// Token: 0x020005F6 RID: 1526
	// (Invoke) Token: 0x06002544 RID: 9540
	public delegate void OnRenderCallback(Material mat);

	// Token: 0x020005F7 RID: 1527
	// (Invoke) Token: 0x06002548 RID: 9544
	public delegate void OnCreateDrawCall(UIDrawCall dc, MeshFilter filter, MeshRenderer ren);

	// Token: 0x020005F8 RID: 1528
	[DoNotObfuscateNGUI]
	public enum ShadowMode
	{
		// Token: 0x04004DA8 RID: 19880
		None,
		// Token: 0x04004DA9 RID: 19881
		Receive,
		// Token: 0x04004DAA RID: 19882
		CastAndReceive
	}
}
