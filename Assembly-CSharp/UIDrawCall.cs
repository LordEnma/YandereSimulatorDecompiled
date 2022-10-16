// Decompiled with JetBrains decompiler
// Type: UIDrawCall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Draw Call")]
public class UIDrawCall : MonoBehaviour
{
  private static BetterList<UIDrawCall> mActiveList = new BetterList<UIDrawCall>();
  private static BetterList<UIDrawCall> mInactiveList = new BetterList<UIDrawCall>();
  [HideInInspector]
  [NonSerialized]
  public int widgetCount;
  [HideInInspector]
  [NonSerialized]
  public int depthStart = int.MaxValue;
  [HideInInspector]
  [NonSerialized]
  public int depthEnd = int.MinValue;
  [HideInInspector]
  [NonSerialized]
  public UIPanel manager;
  [HideInInspector]
  [NonSerialized]
  public UIPanel panel;
  [HideInInspector]
  [NonSerialized]
  public Texture2D clipTexture;
  [HideInInspector]
  [NonSerialized]
  public bool alwaysOnScreen;
  [HideInInspector]
  [NonSerialized]
  public List<Vector3> verts = new List<Vector3>();
  [HideInInspector]
  [NonSerialized]
  public List<Vector3> norms = new List<Vector3>();
  [HideInInspector]
  [NonSerialized]
  public List<Vector4> tans = new List<Vector4>();
  [HideInInspector]
  [NonSerialized]
  public List<Vector2> uvs = new List<Vector2>();
  [HideInInspector]
  [NonSerialized]
  public List<Vector4> uv2 = new List<Vector4>();
  [HideInInspector]
  [NonSerialized]
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
  private UIDrawCall.ShadowMode mShadowMode;
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
  public UIDrawCall.OnRenderCallback onRender;
  public UIDrawCall.OnCreateDrawCall onCreateDrawCall;
  [NonSerialized]
  private string mSortingLayerName;
  [NonSerialized]
  private int mSortingOrder;
  private static ColorSpace mColorSpace = ColorSpace.Uninitialized;
  private const int maxIndexBufferCache = 10;
  private static List<int[]> mCache = new List<int[]>(10);
  protected MaterialPropertyBlock mBlock;
  private static int[] ClipRange = (int[]) null;
  private static int[] ClipArgs = (int[]) null;
  private static int dx9BugWorkaround = -1;

  [Obsolete("Use UIDrawCall.activeList")]
  public static BetterList<UIDrawCall> list => UIDrawCall.mActiveList;

  public static BetterList<UIDrawCall> activeList => UIDrawCall.mActiveList;

  public static BetterList<UIDrawCall> inactiveList => UIDrawCall.mInactiveList;

  public int renderQueue
  {
    get => this.mRenderQueue;
    set
    {
      if (this.mRenderQueue == value)
        return;
      this.mRenderQueue = value;
      if (!((UnityEngine.Object) this.mDynamicMat != (UnityEngine.Object) null))
        return;
      this.mDynamicMat.renderQueue = value;
    }
  }

  public int sortingOrder
  {
    get => this.mSortingOrder;
    set
    {
      if (this.mSortingOrder == value)
        return;
      this.mSortingOrder = value;
      if (!((UnityEngine.Object) this.mRenderer != (UnityEngine.Object) null))
        return;
      this.mRenderer.sortingOrder = value;
    }
  }

  public string sortingLayerName
  {
    get
    {
      if (!string.IsNullOrEmpty(this.mSortingLayerName))
        return this.mSortingLayerName;
      if ((UnityEngine.Object) this.mRenderer == (UnityEngine.Object) null)
        return (string) null;
      this.mSortingLayerName = this.mRenderer.sortingLayerName;
      return this.mSortingLayerName;
    }
    set
    {
      if (!((UnityEngine.Object) this.mRenderer != (UnityEngine.Object) null) || !(this.mSortingLayerName != value))
        return;
      this.mSortingLayerName = value;
      this.mRenderer.sortingLayerName = value;
    }
  }

  public int finalRenderQueue => !((UnityEngine.Object) this.mDynamicMat != (UnityEngine.Object) null) ? this.mRenderQueue : this.mDynamicMat.renderQueue;

  public Transform cachedTransform
  {
    get
    {
      if ((UnityEngine.Object) this.mTrans == (UnityEngine.Object) null)
        this.mTrans = this.transform;
      return this.mTrans;
    }
  }

  public Material baseMaterial
  {
    get => this.mMaterial;
    set
    {
      if (!((UnityEngine.Object) this.mMaterial != (UnityEngine.Object) value))
        return;
      this.mMaterial = value;
      this.mRebuildMat = true;
    }
  }

  public Material dynamicMaterial => this.mDynamicMat;

  public Texture mainTexture
  {
    get => this.mTexture;
    set
    {
      this.mTexture = value;
      if (this.mBlock == null)
        this.mBlock = new MaterialPropertyBlock();
      this.mBlock.SetTexture("_MainTex", (UnityEngine.Object) value != (UnityEngine.Object) null ? value : (Texture) Texture2D.whiteTexture);
    }
  }

  public Shader shader
  {
    get => this.mShader;
    set
    {
      if (!((UnityEngine.Object) this.mShader != (UnityEngine.Object) value))
        return;
      this.mShader = value;
      this.mRebuildMat = true;
    }
  }

  public UIDrawCall.ShadowMode shadowMode
  {
    get => this.mShadowMode;
    set
    {
      if (this.mShadowMode == value)
        return;
      this.mShadowMode = value;
      if (!((UnityEngine.Object) this.mRenderer != (UnityEngine.Object) null))
        return;
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
  }

  public int triangles => !((UnityEngine.Object) this.mMesh != (UnityEngine.Object) null) ? 0 : this.mTriangles;

  public bool isClipped => this.mClipCount != 0;

  private void CreateMaterial()
  {
    this.mTextureClip = false;
    this.mLegacyShader = false;
    this.mClipCount = this.panel.clipCount;
    string str = ((UnityEngine.Object) this.mShader != (UnityEngine.Object) null ? this.mShader.name : ((UnityEngine.Object) this.mMaterial != (UnityEngine.Object) null ? this.mMaterial.shader.name : "Unlit/Transparent Colored")).Replace("GUI/Text Shader", "Unlit/Text");
    if (str.Length > 2 && str[str.Length - 2] == ' ')
    {
      int num = (int) str[str.Length - 1];
      if (num > 48 && num <= 57)
        str = str.Substring(0, str.Length - 2);
    }
    if (str.StartsWith("Hidden/"))
      str = str.Substring(7);
    string name = str.Replace(" (SoftClip)", "").Replace(" (TextureClip)", "");
    if ((UnityEngine.Object) this.panel != (UnityEngine.Object) null && this.panel.clipping == UIDrawCall.Clipping.TextureMask)
    {
      this.mTextureClip = true;
      this.shader = Shader.Find("Hidden/" + name + " (TextureClip)");
    }
    else if (this.mClipCount != 0)
    {
      this.shader = Shader.Find("Hidden/" + name + " " + this.mClipCount.ToString());
      if ((UnityEngine.Object) this.shader == (UnityEngine.Object) null)
        this.shader = Shader.Find(name + " " + this.mClipCount.ToString());
      if ((UnityEngine.Object) this.shader == (UnityEngine.Object) null && this.mClipCount == 1)
      {
        this.mLegacyShader = true;
        this.shader = Shader.Find(name + " (SoftClip)");
      }
    }
    else
      this.shader = Shader.Find(name);
    if ((UnityEngine.Object) this.shader == (UnityEngine.Object) null)
      this.shader = Shader.Find("Unlit/Transparent Colored");
    if ((UnityEngine.Object) this.mMaterial != (UnityEngine.Object) null)
    {
      this.mDynamicMat = new Material(this.mMaterial);
      this.mDynamicMat.name = "[NGUI] " + this.mMaterial.name;
      this.mDynamicMat.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
      this.mDynamicMat.CopyPropertiesFromMaterial(this.mMaterial);
      foreach (string shaderKeyword in this.mMaterial.shaderKeywords)
        this.mDynamicMat.EnableKeyword(shaderKeyword);
      if ((UnityEngine.Object) this.shader != (UnityEngine.Object) null)
      {
        this.mDynamicMat.shader = this.shader;
      }
      else
      {
        if (this.mClipCount == 0)
          return;
        Debug.LogError((object) (name + " shader doesn't have a clipped shader version for " + this.mClipCount.ToString() + " clip regions"));
      }
    }
    else
    {
      this.mDynamicMat = new Material(this.shader);
      this.mDynamicMat.name = "[NGUI] " + this.shader.name;
      this.mDynamicMat.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
    }
  }

  private Material RebuildMaterial()
  {
    NGUITools.DestroyImmediate((UnityEngine.Object) this.mDynamicMat);
    this.CreateMaterial();
    this.mDynamicMat.renderQueue = this.mRenderQueue;
    if ((UnityEngine.Object) this.mRenderer != (UnityEngine.Object) null)
    {
      this.mRenderer.sharedMaterials = new Material[1]
      {
        this.mDynamicMat
      };
      this.mRenderer.sortingLayerName = this.mSortingLayerName;
      this.mRenderer.sortingOrder = this.mSortingOrder;
    }
    return this.mDynamicMat;
  }

  private void UpdateMaterials()
  {
    if ((UnityEngine.Object) this.panel == (UnityEngine.Object) null || !this.mRebuildMat && !((UnityEngine.Object) this.mDynamicMat == (UnityEngine.Object) null) && this.mClipCount == this.panel.clipCount && this.mTextureClip == (this.panel.clipping == UIDrawCall.Clipping.TextureMask))
      return;
    this.RebuildMaterial();
    this.mRebuildMat = false;
  }

  public void UpdateGeometry(int widgetCount, bool needsBounds)
  {
    this.widgetCount = widgetCount;
    int count = this.verts.Count;
    if (count > 0 && count == this.uvs.Count && count == this.cols.Count && count % 4 == 0)
    {
      if (UIDrawCall.mColorSpace == ColorSpace.Uninitialized)
        UIDrawCall.mColorSpace = QualitySettings.activeColorSpace;
      if (UIDrawCall.mColorSpace == ColorSpace.Linear)
      {
        for (int index = 0; index < count; ++index)
        {
          Color col = this.cols[index];
          col.r = Mathf.GammaToLinearSpace(col.r);
          col.g = Mathf.GammaToLinearSpace(col.g);
          col.b = Mathf.GammaToLinearSpace(col.b);
          col.a = Mathf.GammaToLinearSpace(col.a);
          this.cols[index] = col;
        }
      }
      if ((UnityEngine.Object) this.mFilter == (UnityEngine.Object) null)
        this.mFilter = this.gameObject.GetComponent<MeshFilter>();
      if ((UnityEngine.Object) this.mFilter == (UnityEngine.Object) null)
        this.mFilter = this.gameObject.AddComponent<MeshFilter>();
      if (count < 65000)
      {
        int indexCount = (count >> 1) * 3;
        bool flag1 = this.mIndices == null || this.mIndices.Length != indexCount;
        if ((UnityEngine.Object) this.mMesh == (UnityEngine.Object) null)
        {
          this.mMesh = new Mesh();
          this.mMesh.hideFlags = HideFlags.DontSave;
          this.mMesh.name = (UnityEngine.Object) this.mMaterial != (UnityEngine.Object) null ? "[NGUI] " + this.mMaterial.name : "[NGUI] Mesh";
          if (UIDrawCall.dx9BugWorkaround == 0)
            this.mMesh.MarkDynamic();
          flag1 = true;
        }
        bool flag2 = this.uvs.Count != count || this.cols.Count != count || this.uv2.Count != count || this.norms.Count != count || this.tans.Count != count;
        if (!flag2 && (UnityEngine.Object) this.panel != (UnityEngine.Object) null && this.panel.renderQueue != UIPanel.RenderQueue.Automatic)
          flag2 = (UnityEngine.Object) this.mMesh == (UnityEngine.Object) null || this.mMesh.vertexCount != this.verts.Count;
        if (!flag2 && count << 1 < this.verts.Count)
          flag2 = true;
        this.mTriangles = count >> 1;
        if (this.mMesh.vertexCount != count)
        {
          this.mMesh.Clear();
          flag1 = true;
        }
        this.mMesh.SetVertices(this.verts);
        this.mMesh.SetUVs(0, this.uvs);
        this.mMesh.SetColors(this.cols);
        this.mMesh.SetUVs(1, this.uv2.Count == count ? this.uv2 : (List<Vector4>) null);
        this.mMesh.SetNormals(this.norms.Count == count ? this.norms : (List<Vector3>) null);
        this.mMesh.SetTangents(this.tans.Count == count ? this.tans : (List<Vector4>) null);
        if (flag1)
        {
          this.mIndices = this.GenerateCachedIndexBuffer(count, indexCount);
          this.mMesh.SetTriangles(this.mIndices, 0, needsBounds);
        }
        if (flag2 || !this.alwaysOnScreen)
          this.mMesh.RecalculateBounds();
        this.mFilter.mesh = this.mMesh;
      }
      else
      {
        this.mTriangles = 0;
        if ((UnityEngine.Object) this.mMesh != (UnityEngine.Object) null)
          this.mMesh.Clear();
        Debug.LogError((object) ("Too many vertices on one panel: " + count.ToString()));
      }
      if ((UnityEngine.Object) this.mRenderer == (UnityEngine.Object) null)
        this.mRenderer = this.gameObject.GetComponent<MeshRenderer>();
      if ((UnityEngine.Object) this.mRenderer == (UnityEngine.Object) null)
      {
        this.mRenderer = this.gameObject.AddComponent<MeshRenderer>();
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
          this.onCreateDrawCall(this, this.mFilter, this.mRenderer);
      }
      this.UpdateMaterials();
    }
    else
    {
      if ((UnityEngine.Object) this.mFilter.mesh != (UnityEngine.Object) null)
        this.mFilter.mesh.Clear();
      Debug.LogError((object) ("UIWidgets must fill the buffer with 4 vertices per quad. Found " + count.ToString()));
    }
    this.verts.Clear();
    this.uvs.Clear();
    this.uv2.Clear();
    this.cols.Clear();
    this.norms.Clear();
    this.tans.Clear();
  }

  private int[] GenerateCachedIndexBuffer(int vertexCount, int indexCount)
  {
    int index1 = 0;
    for (int count = UIDrawCall.mCache.Count; index1 < count; ++index1)
    {
      int[] cachedIndexBuffer = UIDrawCall.mCache[index1];
      if (cachedIndexBuffer != null && cachedIndexBuffer.Length == indexCount)
        return cachedIndexBuffer;
    }
    int[] cachedIndexBuffer1 = new int[indexCount];
    int num1 = 0;
    for (int index2 = 0; index2 < vertexCount; index2 += 4)
    {
      int[] numArray1 = cachedIndexBuffer1;
      int index3 = num1;
      int num2 = index3 + 1;
      int num3 = index2;
      numArray1[index3] = num3;
      int[] numArray2 = cachedIndexBuffer1;
      int index4 = num2;
      int num4 = index4 + 1;
      int num5 = index2 + 1;
      numArray2[index4] = num5;
      int[] numArray3 = cachedIndexBuffer1;
      int index5 = num4;
      int num6 = index5 + 1;
      int num7 = index2 + 2;
      numArray3[index5] = num7;
      int[] numArray4 = cachedIndexBuffer1;
      int index6 = num6;
      int num8 = index6 + 1;
      int num9 = index2 + 2;
      numArray4[index6] = num9;
      int[] numArray5 = cachedIndexBuffer1;
      int index7 = num8;
      int num10 = index7 + 1;
      int num11 = index2 + 3;
      numArray5[index7] = num11;
      int[] numArray6 = cachedIndexBuffer1;
      int index8 = num10;
      num1 = index8 + 1;
      int num12 = index2;
      numArray6[index8] = num12;
    }
    if (UIDrawCall.mCache.Count > 10)
      UIDrawCall.mCache.RemoveAt(0);
    UIDrawCall.mCache.Add(cachedIndexBuffer1);
    return cachedIndexBuffer1;
  }

  private void OnWillRenderObject()
  {
    this.UpdateMaterials();
    if (this.mBlock != null)
      this.mRenderer.SetPropertyBlock(this.mBlock);
    if (this.onRender != null)
      this.onRender((UnityEngine.Object) this.mDynamicMat != (UnityEngine.Object) null ? this.mDynamicMat : this.mMaterial);
    if ((UnityEngine.Object) this.mDynamicMat == (UnityEngine.Object) null || this.mClipCount == 0)
      return;
    if (this.mTextureClip)
    {
      Vector4 drawCallClipRange = this.panel.drawCallClipRange;
      Vector2 clipSoftness = this.panel.clipSoftness;
      Vector2 vector2 = new Vector2(1000f, 1000f);
      if ((double) clipSoftness.x > 0.0)
        vector2.x = drawCallClipRange.z / clipSoftness.x;
      if ((double) clipSoftness.y > 0.0)
        vector2.y = drawCallClipRange.w / clipSoftness.y;
      this.mDynamicMat.SetVector(UIDrawCall.ClipRange[0], new Vector4(-drawCallClipRange.x / drawCallClipRange.z, -drawCallClipRange.y / drawCallClipRange.w, 1f / drawCallClipRange.z, 1f / drawCallClipRange.w));
      this.mDynamicMat.SetTexture("_ClipTex", (Texture) this.clipTexture);
    }
    else if (!this.mLegacyShader)
    {
      UIPanel uiPanel = this.panel;
      int num = 0;
      for (; (UnityEngine.Object) uiPanel != (UnityEngine.Object) null; uiPanel = uiPanel.parentPanel)
      {
        if (uiPanel.hasClipping)
        {
          float angle = 0.0f;
          Vector4 drawCallClipRange = uiPanel.drawCallClipRange;
          if ((UnityEngine.Object) uiPanel != (UnityEngine.Object) this.panel)
          {
            Vector3 vector3_1 = uiPanel.cachedTransform.InverseTransformPoint(this.panel.cachedTransform.position);
            drawCallClipRange.x -= vector3_1.x;
            drawCallClipRange.y -= vector3_1.y;
            Vector3 eulerAngles = this.panel.cachedTransform.rotation.eulerAngles;
            Vector3 vector3_2 = uiPanel.cachedTransform.rotation.eulerAngles - eulerAngles;
            vector3_2.x = NGUIMath.WrapAngle(vector3_2.x);
            vector3_2.y = NGUIMath.WrapAngle(vector3_2.y);
            vector3_2.z = NGUIMath.WrapAngle(vector3_2.z);
            if ((double) Mathf.Abs(vector3_2.x) > 1.0 / 1000.0 || (double) Mathf.Abs(vector3_2.y) > 1.0 / 1000.0)
              Debug.LogWarning((object) "Panel can only be clipped properly if X and Y rotation is left at 0", (UnityEngine.Object) this.panel);
            angle = vector3_2.z;
          }
          this.SetClipping(num++, drawCallClipRange, uiPanel.clipSoftness, angle);
        }
      }
    }
    else
    {
      Vector2 clipSoftness = this.panel.clipSoftness;
      Vector4 drawCallClipRange = this.panel.drawCallClipRange;
      Vector2 vector2_1 = new Vector2(-drawCallClipRange.x / drawCallClipRange.z, -drawCallClipRange.y / drawCallClipRange.w);
      Vector2 vector2_2 = new Vector2(1f / drawCallClipRange.z, 1f / drawCallClipRange.w);
      Vector2 vector2_3 = new Vector2(1000f, 1000f);
      if ((double) clipSoftness.x > 0.0)
        vector2_3.x = drawCallClipRange.z / clipSoftness.x;
      if ((double) clipSoftness.y > 0.0)
        vector2_3.y = drawCallClipRange.w / clipSoftness.y;
      this.mDynamicMat.mainTextureOffset = vector2_1;
      this.mDynamicMat.mainTextureScale = vector2_2;
      this.mDynamicMat.SetVector("_ClipSharpness", (Vector4) vector2_3);
    }
  }

  private void SetClipping(int index, Vector4 cr, Vector2 soft, float angle)
  {
    angle *= -1f * (float) Math.PI / 180f;
    Vector2 vector2 = new Vector2(1000f, 1000f);
    if ((double) soft.x > 0.0)
      vector2.x = cr.z / soft.x;
    if ((double) soft.y > 0.0)
      vector2.y = cr.w / soft.y;
    if (index >= UIDrawCall.ClipRange.Length)
      return;
    this.mDynamicMat.SetVector(UIDrawCall.ClipRange[index], new Vector4(-cr.x / cr.z, -cr.y / cr.w, 1f / cr.z, 1f / cr.w));
    this.mDynamicMat.SetVector(UIDrawCall.ClipArgs[index], new Vector4(vector2.x, vector2.y, Mathf.Sin(angle), Mathf.Cos(angle)));
  }

  private void Awake()
  {
    if (UIDrawCall.dx9BugWorkaround == -1)
      UIDrawCall.dx9BugWorkaround = Application.platform != RuntimePlatform.WindowsPlayer || SystemInfo.graphicsShaderLevel >= 40 || !SystemInfo.graphicsDeviceVersion.Contains("Direct3D") ? 0 : 1;
    if (UIDrawCall.ClipRange == null)
      UIDrawCall.ClipRange = new int[4]
      {
        Shader.PropertyToID("_ClipRange0"),
        Shader.PropertyToID("_ClipRange1"),
        Shader.PropertyToID("_ClipRange2"),
        Shader.PropertyToID("_ClipRange4")
      };
    if (UIDrawCall.ClipArgs != null)
      return;
    UIDrawCall.ClipArgs = new int[4]
    {
      Shader.PropertyToID("_ClipArgs0"),
      Shader.PropertyToID("_ClipArgs1"),
      Shader.PropertyToID("_ClipArgs2"),
      Shader.PropertyToID("_ClipArgs3")
    };
  }

  private void OnEnable() => this.mRebuildMat = true;

  private void OnDisable()
  {
    this.depthStart = int.MaxValue;
    this.depthEnd = int.MinValue;
    this.panel = (UIPanel) null;
    this.manager = (UIPanel) null;
    this.mMaterial = (Material) null;
    this.mTexture = (Texture) null;
    this.clipTexture = (Texture2D) null;
    if ((UnityEngine.Object) this.mRenderer != (UnityEngine.Object) null)
      this.mRenderer.sharedMaterials = new Material[0];
    NGUITools.DestroyImmediate((UnityEngine.Object) this.mDynamicMat);
    this.mDynamicMat = (Material) null;
  }

  private void OnDestroy()
  {
    NGUITools.DestroyImmediate((UnityEngine.Object) this.mMesh);
    this.mMesh = (Mesh) null;
  }

  public static UIDrawCall Create(
    UIPanel panel,
    Material mat,
    Texture tex,
    Shader shader)
  {
    return UIDrawCall.Create((string) null, panel, mat, tex, shader);
  }

  private static UIDrawCall Create(
    string name,
    UIPanel pan,
    Material mat,
    Texture tex,
    Shader shader)
  {
    UIDrawCall uiDrawCall = UIDrawCall.Create(name);
    uiDrawCall.gameObject.layer = pan.cachedGameObject.layer;
    uiDrawCall.baseMaterial = mat;
    uiDrawCall.mainTexture = tex;
    uiDrawCall.shader = shader;
    uiDrawCall.renderQueue = pan.startingRenderQueue;
    uiDrawCall.sortingOrder = pan.sortingOrder;
    uiDrawCall.manager = pan;
    return uiDrawCall;
  }

  private static UIDrawCall Create(string name)
  {
    while (UIDrawCall.mInactiveList.size > 0)
    {
      UIDrawCall uiDrawCall = UIDrawCall.mInactiveList.Pop();
      if ((UnityEngine.Object) uiDrawCall != (UnityEngine.Object) null)
      {
        UIDrawCall.mActiveList.Add(uiDrawCall);
        if (name != null)
          uiDrawCall.name = name;
        NGUITools.SetActive(uiDrawCall.gameObject, true);
        return uiDrawCall;
      }
    }
    GameObject target = new GameObject(name);
    UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) target);
    UIDrawCall uiDrawCall1 = target.AddComponent<UIDrawCall>();
    UIDrawCall.mActiveList.Add(uiDrawCall1);
    return uiDrawCall1;
  }

  public static void ClearAll()
  {
    bool isPlaying = Application.isPlaying;
    int size = UIDrawCall.mActiveList.size;
    while (size > 0)
    {
      UIDrawCall uiDrawCall = UIDrawCall.mActiveList.buffer[--size];
      if ((bool) (UnityEngine.Object) uiDrawCall)
      {
        if (isPlaying)
          NGUITools.SetActive(uiDrawCall.gameObject, false);
        else
          NGUITools.DestroyImmediate((UnityEngine.Object) uiDrawCall.gameObject);
      }
    }
    UIDrawCall.mActiveList.Clear();
  }

  public static void ReleaseAll()
  {
    UIDrawCall.ClearAll();
    UIDrawCall.ReleaseInactive();
  }

  public static void ReleaseInactive()
  {
    int size = UIDrawCall.mInactiveList.size;
    while (size > 0)
    {
      UIDrawCall uiDrawCall = UIDrawCall.mInactiveList.buffer[--size];
      if ((bool) (UnityEngine.Object) uiDrawCall)
        NGUITools.DestroyImmediate((UnityEngine.Object) uiDrawCall.gameObject);
    }
    UIDrawCall.mInactiveList.Clear();
  }

  public static int Count(UIPanel panel)
  {
    int num = 0;
    for (int index = 0; index < UIDrawCall.mActiveList.size; ++index)
    {
      if ((UnityEngine.Object) UIDrawCall.mActiveList.buffer[index].manager == (UnityEngine.Object) panel)
        ++num;
    }
    return num;
  }

  public static void Destroy(UIDrawCall dc)
  {
    if (!(bool) (UnityEngine.Object) dc)
      return;
    if (dc.onCreateDrawCall != null)
    {
      NGUITools.Destroy((UnityEngine.Object) dc.gameObject);
    }
    else
    {
      dc.onRender = (UIDrawCall.OnRenderCallback) null;
      if (Application.isPlaying)
      {
        if (!UIDrawCall.mActiveList.Remove(dc))
          return;
        NGUITools.SetActive(dc.gameObject, false);
        UIDrawCall.mInactiveList.Add(dc);
        dc.mIsNew = true;
      }
      else
      {
        UIDrawCall.mActiveList.Remove(dc);
        NGUITools.DestroyImmediate((UnityEngine.Object) dc.gameObject);
      }
    }
  }

  public static void MoveToScene(Scene scene)
  {
    foreach (Component active in UIDrawCall.activeList)
      SceneManager.MoveGameObjectToScene(active.gameObject, scene);
    foreach (Component inactive in UIDrawCall.inactiveList)
      SceneManager.MoveGameObjectToScene(inactive.gameObject, scene);
  }

  [DoNotObfuscateNGUI]
  public enum Clipping
  {
    None = 0,
    TextureMask = 1,
    SoftClip = 3,
    ConstrainButDontClip = 4,
  }

  public delegate void OnRenderCallback(Material mat);

  public delegate void OnCreateDrawCall(UIDrawCall dc, MeshFilter filter, MeshRenderer ren);

  [DoNotObfuscateNGUI]
  public enum ShadowMode
  {
    None,
    Receive,
    CastAndReceive,
  }
}
