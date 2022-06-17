// Decompiled with JetBrains decompiler
// Type: UIPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Panel")]
public class UIPanel : UIRect
{
  public static List<UIPanel> list = new List<UIPanel>();
  public UIPanel.OnGeometryUpdated onGeometryUpdated;
  public bool showInPanelTool = true;
  public bool generateNormals;
  public bool generateUV2;
  public UIDrawCall.ShadowMode shadowMode;
  public bool widgetsAreStatic;
  public bool cullWhileDragging = true;
  public bool alwaysOnScreen;
  public bool anchorOffset;
  public bool softBorderPadding = true;
  public UIPanel.RenderQueue renderQueue;
  public int startingRenderQueue = 3000;
  [NonSerialized]
  public List<UIWidget> widgets = new List<UIWidget>();
  [NonSerialized]
  public List<UIDrawCall> drawCalls = new List<UIDrawCall>();
  [NonSerialized]
  public Matrix4x4 worldToLocal = Matrix4x4.identity;
  [NonSerialized]
  public Vector4 drawCallClipRange = new Vector4(0.0f, 0.0f, 1f, 1f);
  public UIPanel.OnClippingMoved onClipMove;
  public UIPanel.OnCreateMaterial onCreateMaterial;
  public UIDrawCall.OnCreateDrawCall onCreateDrawCall;
  [HideInInspector]
  [SerializeField]
  private Texture2D mClipTexture;
  [HideInInspector]
  [SerializeField]
  private float mAlpha = 1f;
  [HideInInspector]
  [SerializeField]
  private UIDrawCall.Clipping mClipping;
  [HideInInspector]
  [SerializeField]
  private Vector4 mClipRange = new Vector4(0.0f, 0.0f, 300f, 200f);
  [HideInInspector]
  [SerializeField]
  private Vector2 mClipSoftness = new Vector2(4f, 4f);
  [HideInInspector]
  [SerializeField]
  private int mDepth;
  [HideInInspector]
  [SerializeField]
  private int mSortingOrder;
  [HideInInspector]
  [SerializeField]
  private string mSortingLayerName;
  private bool mRebuild;
  private bool mResized;
  [SerializeField]
  private Vector2 mClipOffset = Vector2.zero;
  private int mMatrixFrame = -1;
  private int mAlphaFrameID;
  private int mLayer = -1;
  private static float[] mTemp = new float[4];
  private Vector2 mMin = Vector2.zero;
  private Vector2 mMax = Vector2.zero;
  private bool mSortWidgets;
  private bool mUpdateScroll;
  public bool useSortingOrder;
  private UIPanel mParentPanel;
  private static Vector3[] mCorners = new Vector3[4];
  private static int mUpdateFrame = -1;
  [NonSerialized]
  private bool mHasMoved;
  private UIDrawCall.OnRenderCallback mOnRender;
  private bool mForced;

  public string sortingLayerName
  {
    get => this.mSortingLayerName;
    set
    {
      if (!(this.mSortingLayerName != value))
        return;
      this.mSortingLayerName = value;
      this.UpdateDrawCalls(UIPanel.list.IndexOf(this));
    }
  }

  public static int nextUnusedDepth
  {
    get
    {
      int a = int.MinValue;
      int index = 0;
      for (int count = UIPanel.list.Count; index < count; ++index)
        a = Mathf.Max(a, UIPanel.list[index].depth);
      return a != int.MinValue ? a + 1 : 0;
    }
  }

  public override bool canBeAnchored => this.mClipping != 0;

  public override float alpha
  {
    get => this.mAlpha;
    set
    {
      float num = Mathf.Clamp01(value);
      if ((double) this.mAlpha == (double) num)
        return;
      bool flag = (double) this.mAlpha > 1.0 / 1000.0;
      this.mAlphaFrameID = -1;
      this.mResized = true;
      this.mAlpha = num;
      int index = 0;
      for (int count = this.drawCalls.Count; index < count; ++index)
        this.drawCalls[index].isDirty = true;
      this.Invalidate(!flag && (double) this.mAlpha > 1.0 / 1000.0);
    }
  }

  public int depth
  {
    get => this.mDepth;
    set
    {
      if (this.mDepth == value)
        return;
      this.mDepth = value;
      UIPanel.list.Sort(new Comparison<UIPanel>(UIPanel.CompareFunc));
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
      this.UpdateDrawCalls(UIPanel.list.IndexOf(this));
    }
  }

  public static int CompareFunc(UIPanel a, UIPanel b)
  {
    if (!((UnityEngine.Object) a != (UnityEngine.Object) b) || !((UnityEngine.Object) a != (UnityEngine.Object) null) || !((UnityEngine.Object) b != (UnityEngine.Object) null))
      return 0;
    return a.mDepth < b.mDepth || a.mDepth <= b.mDepth && a.GetInstanceID() < b.GetInstanceID() ? -1 : 1;
  }

  public float width => this.GetViewSize().x;

  public float height => this.GetViewSize().y;

  public bool halfPixelOffset => false;

  public bool usedForUI => (UnityEngine.Object) this.anchorCamera != (UnityEngine.Object) null && this.mCam.orthographic;

  public Vector3 drawCallOffset
  {
    get
    {
      if (!((UnityEngine.Object) this.anchorCamera != (UnityEngine.Object) null) || !this.mCam.orthographic)
        return Vector3.zero;
      Vector2 windowSize = this.GetWindowSize();
      float num = ((UnityEngine.Object) this.root != (UnityEngine.Object) null ? this.root.pixelSizeAdjustment : 1f) / windowSize.y / this.mCam.orthographicSize;
      bool flag1 = false;
      bool flag2 = false;
      if ((Mathf.RoundToInt(windowSize.x) & 1) == 1)
        flag1 = !flag1;
      if ((Mathf.RoundToInt(windowSize.y) & 1) == 1)
        flag2 = !flag2;
      return new Vector3(flag1 ? -num : 0.0f, flag2 ? num : 0.0f);
    }
  }

  public UIDrawCall.Clipping clipping
  {
    get => this.mClipping;
    set
    {
      if (this.mClipping == value)
        return;
      this.mResized = true;
      this.mClipping = value;
      this.mMatrixFrame = -1;
    }
  }

  public UIPanel parentPanel => this.mParentPanel;

  public int clipCount
  {
    get
    {
      int clipCount = 0;
      for (UIPanel uiPanel = this; (UnityEngine.Object) uiPanel != (UnityEngine.Object) null; uiPanel = uiPanel.mParentPanel)
      {
        if (uiPanel.mClipping == UIDrawCall.Clipping.SoftClip || uiPanel.mClipping == UIDrawCall.Clipping.TextureMask)
          ++clipCount;
      }
      return clipCount;
    }
  }

  public bool hasClipping => this.mClipping == UIDrawCall.Clipping.SoftClip || this.mClipping == UIDrawCall.Clipping.TextureMask;

  public bool hasCumulativeClipping => this.clipCount != 0;

  [Obsolete("Use 'hasClipping' or 'hasCumulativeClipping' instead")]
  public bool clipsChildren => this.hasCumulativeClipping;

  public Vector2 clipOffset
  {
    get => this.mClipOffset;
    set
    {
      if ((double) Mathf.Abs(this.mClipOffset.x - value.x) <= 1.0 / 1000.0 && (double) Mathf.Abs(this.mClipOffset.y - value.y) <= 1.0 / 1000.0)
        return;
      this.mClipOffset = value;
      this.InvalidateClipping();
      if (this.onClipMove == null)
        return;
      this.onClipMove(this);
    }
  }

  private void InvalidateClipping()
  {
    this.mResized = true;
    this.mMatrixFrame = -1;
    int index = 0;
    for (int count = UIPanel.list.Count; index < count; ++index)
    {
      UIPanel uiPanel = UIPanel.list[index];
      if ((UnityEngine.Object) uiPanel != (UnityEngine.Object) this && (UnityEngine.Object) uiPanel.parentPanel == (UnityEngine.Object) this)
        uiPanel.InvalidateClipping();
    }
  }

  public Texture2D clipTexture
  {
    get => this.mClipTexture;
    set
    {
      if (!((UnityEngine.Object) this.mClipTexture != (UnityEngine.Object) value))
        return;
      this.mClipTexture = value;
    }
  }

  [Obsolete("Use 'finalClipRegion' or 'baseClipRegion' instead")]
  public Vector4 clipRange
  {
    get => this.baseClipRegion;
    set => this.baseClipRegion = value;
  }

  public Vector4 baseClipRegion
  {
    get => this.mClipRange;
    set
    {
      if ((double) Mathf.Abs(this.mClipRange.x - value.x) <= 1.0 / 1000.0 && (double) Mathf.Abs(this.mClipRange.y - value.y) <= 1.0 / 1000.0 && (double) Mathf.Abs(this.mClipRange.z - value.z) <= 1.0 / 1000.0 && (double) Mathf.Abs(this.mClipRange.w - value.w) <= 1.0 / 1000.0)
        return;
      this.mResized = true;
      this.mClipRange = value;
      this.mMatrixFrame = -1;
      UIScrollView component = this.GetComponent<UIScrollView>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        component.UpdatePosition();
      if (this.onClipMove == null)
        return;
      this.onClipMove(this);
    }
  }

  public Vector4 finalClipRegion
  {
    get
    {
      Vector2 viewSize = this.GetViewSize();
      if (this.mClipping != UIDrawCall.Clipping.None)
        return new Vector4(this.mClipRange.x + this.mClipOffset.x, this.mClipRange.y + this.mClipOffset.y, viewSize.x, viewSize.y);
      Vector4 finalClipRegion = new Vector4(0.0f, 0.0f, viewSize.x, viewSize.y);
      Vector3 screenPoint = this.anchorCamera.WorldToScreenPoint(this.cachedTransform.position);
      screenPoint.x -= viewSize.x * 0.5f;
      screenPoint.y -= viewSize.y * 0.5f;
      finalClipRegion.x -= screenPoint.x;
      finalClipRegion.y -= screenPoint.y;
      return finalClipRegion;
    }
  }

  public Vector2 clipSoftness
  {
    get => this.mClipSoftness;
    set
    {
      if (!(this.mClipSoftness != value))
        return;
      this.mClipSoftness = value;
    }
  }

  public override Vector3[] localCorners
  {
    get
    {
      if (this.mClipping == UIDrawCall.Clipping.None)
      {
        Vector3[] worldCorners = this.worldCorners;
        Transform cachedTransform = this.cachedTransform;
        for (int index = 0; index < 4; ++index)
          worldCorners[index] = cachedTransform.InverseTransformPoint(worldCorners[index]);
        return worldCorners;
      }
      float x1 = (float) ((double) this.mClipOffset.x + (double) this.mClipRange.x - 0.5 * (double) this.mClipRange.z);
      float y1 = (float) ((double) this.mClipOffset.y + (double) this.mClipRange.y - 0.5 * (double) this.mClipRange.w);
      float x2 = x1 + this.mClipRange.z;
      float y2 = y1 + this.mClipRange.w;
      UIPanel.mCorners[0] = new Vector3(x1, y1);
      UIPanel.mCorners[1] = new Vector3(x1, y2);
      UIPanel.mCorners[2] = new Vector3(x2, y2);
      UIPanel.mCorners[3] = new Vector3(x2, y1);
      return UIPanel.mCorners;
    }
  }

  public override Vector3[] worldCorners
  {
    get
    {
      if (this.mClipping != UIDrawCall.Clipping.None)
      {
        float x1 = (float) ((double) this.mClipOffset.x + (double) this.mClipRange.x - 0.5 * (double) this.mClipRange.z);
        float y1 = (float) ((double) this.mClipOffset.y + (double) this.mClipRange.y - 0.5 * (double) this.mClipRange.w);
        float x2 = x1 + this.mClipRange.z;
        float y2 = y1 + this.mClipRange.w;
        Transform cachedTransform = this.cachedTransform;
        UIPanel.mCorners[0] = cachedTransform.TransformPoint(x1, y1, 0.0f);
        UIPanel.mCorners[1] = cachedTransform.TransformPoint(x1, y2, 0.0f);
        UIPanel.mCorners[2] = cachedTransform.TransformPoint(x2, y2, 0.0f);
        UIPanel.mCorners[3] = cachedTransform.TransformPoint(x2, y1, 0.0f);
      }
      else
      {
        if ((UnityEngine.Object) this.anchorCamera != (UnityEngine.Object) null)
          return this.mCam.GetWorldCorners(this.cameraRayDistance);
        Vector2 viewSize = this.GetViewSize();
        float x3 = -0.5f * viewSize.x;
        float y3 = -0.5f * viewSize.y;
        float x4 = x3 + viewSize.x;
        float y4 = y3 + viewSize.y;
        UIPanel.mCorners[0] = new Vector3(x3, y3);
        UIPanel.mCorners[1] = new Vector3(x3, y4);
        UIPanel.mCorners[2] = new Vector3(x4, y4);
        UIPanel.mCorners[3] = new Vector3(x4, y3);
        if (this.anchorOffset && ((UnityEngine.Object) this.mCam == (UnityEngine.Object) null || (UnityEngine.Object) this.mCam.transform.parent != (UnityEngine.Object) this.cachedTransform))
        {
          Vector3 position = this.cachedTransform.position;
          for (int index = 0; index < 4; ++index)
            UIPanel.mCorners[index] += position;
        }
      }
      return UIPanel.mCorners;
    }
  }

  public override Vector3[] GetSides(Transform relativeTo)
  {
    if (this.mClipping != UIDrawCall.Clipping.None)
    {
      float x1 = (float) ((double) this.mClipOffset.x + (double) this.mClipRange.x - 0.5 * (double) this.mClipRange.z);
      float y1 = (float) ((double) this.mClipOffset.y + (double) this.mClipRange.y - 0.5 * (double) this.mClipRange.w);
      float x2 = x1 + this.mClipRange.z;
      float y2 = y1 + this.mClipRange.w;
      float x3 = (float) (((double) x1 + (double) x2) * 0.5);
      float y3 = (float) (((double) y1 + (double) y2) * 0.5);
      Transform cachedTransform = this.cachedTransform;
      UIRect.mSides[0] = cachedTransform.TransformPoint(x1, y3, 0.0f);
      UIRect.mSides[1] = cachedTransform.TransformPoint(x3, y2, 0.0f);
      UIRect.mSides[2] = cachedTransform.TransformPoint(x2, y3, 0.0f);
      UIRect.mSides[3] = cachedTransform.TransformPoint(x3, y1, 0.0f);
      if ((UnityEngine.Object) relativeTo != (UnityEngine.Object) null)
      {
        for (int index = 0; index < 4; ++index)
          UIRect.mSides[index] = relativeTo.InverseTransformPoint(UIRect.mSides[index]);
      }
      return UIRect.mSides;
    }
    if (!((UnityEngine.Object) this.anchorCamera != (UnityEngine.Object) null) || !this.anchorOffset)
      return base.GetSides(relativeTo);
    Vector3[] sides = this.mCam.GetSides(this.cameraRayDistance);
    Vector3 position = this.cachedTransform.position;
    for (int index = 0; index < 4; ++index)
      sides[index] += position;
    if ((UnityEngine.Object) relativeTo != (UnityEngine.Object) null)
    {
      for (int index = 0; index < 4; ++index)
        sides[index] = relativeTo.InverseTransformPoint(sides[index]);
    }
    return sides;
  }

  public override void Invalidate(bool includeChildren)
  {
    this.mAlphaFrameID = -1;
    base.Invalidate(includeChildren);
  }

  public override float CalculateFinalAlpha(int frameID)
  {
    if (this.mAlphaFrameID != frameID)
    {
      this.mAlphaFrameID = frameID;
      UIRect parent = this.parent;
      this.finalAlpha = (UnityEngine.Object) this.parent != (UnityEngine.Object) null ? parent.CalculateFinalAlpha(frameID) * this.mAlpha : this.mAlpha;
    }
    return this.finalAlpha;
  }

  public override void SetRect(float x, float y, float width, float height)
  {
    int num1 = Mathf.FloorToInt(width + 0.5f);
    int num2 = Mathf.FloorToInt(height + 0.5f);
    int z = num1 >> 1 << 1;
    int w = num2 >> 1 << 1;
    Transform cachedTransform = this.cachedTransform;
    Vector3 localPosition = cachedTransform.localPosition with
    {
      x = Mathf.Floor(x + 0.5f),
      y = Mathf.Floor(y + 0.5f)
    };
    if (z < 2)
      z = 2;
    if (w < 2)
      w = 2;
    this.baseClipRegion = new Vector4(localPosition.x, localPosition.y, (float) z, (float) w);
    if (!this.isAnchored)
      return;
    Transform parent = cachedTransform.parent;
    if ((bool) (UnityEngine.Object) this.leftAnchor.target)
      this.leftAnchor.SetHorizontal(parent, x);
    if ((bool) (UnityEngine.Object) this.rightAnchor.target)
      this.rightAnchor.SetHorizontal(parent, x + width);
    if ((bool) (UnityEngine.Object) this.bottomAnchor.target)
      this.bottomAnchor.SetVertical(parent, y);
    if (!(bool) (UnityEngine.Object) this.topAnchor.target)
      return;
    this.topAnchor.SetVertical(parent, y + height);
  }

  public bool IsVisible(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
  {
    this.UpdateTransformMatrix();
    a = this.worldToLocal.MultiplyPoint3x4(a);
    b = this.worldToLocal.MultiplyPoint3x4(b);
    c = this.worldToLocal.MultiplyPoint3x4(c);
    d = this.worldToLocal.MultiplyPoint3x4(d);
    UIPanel.mTemp[0] = a.x;
    UIPanel.mTemp[1] = b.x;
    UIPanel.mTemp[2] = c.x;
    UIPanel.mTemp[3] = d.x;
    float num1 = Mathf.Min(UIPanel.mTemp);
    double num2 = (double) Mathf.Max(UIPanel.mTemp);
    UIPanel.mTemp[0] = a.y;
    UIPanel.mTemp[1] = b.y;
    UIPanel.mTemp[2] = c.y;
    UIPanel.mTemp[3] = d.y;
    float num3 = Mathf.Min(UIPanel.mTemp);
    float num4 = Mathf.Max(UIPanel.mTemp);
    double x = (double) this.mMin.x;
    return num2 >= x && (double) num4 >= (double) this.mMin.y && (double) num1 <= (double) this.mMax.x && (double) num3 <= (double) this.mMax.y;
  }

  public bool IsVisible(Vector3 worldPos)
  {
    if ((double) this.mAlpha < 1.0 / 1000.0)
      return false;
    if (this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip)
      return true;
    this.UpdateTransformMatrix();
    Vector3 vector3 = this.worldToLocal.MultiplyPoint3x4(worldPos);
    return (double) vector3.x >= (double) this.mMin.x && (double) vector3.y >= (double) this.mMin.y && (double) vector3.x <= (double) this.mMax.x && (double) vector3.y <= (double) this.mMax.y;
  }

  public bool IsVisible(UIWidget w)
  {
    UIPanel uiPanel = this;
    Vector3[] vector3Array = (Vector3[]) null;
    while ((UnityEngine.Object) uiPanel != (UnityEngine.Object) null)
    {
      if ((uiPanel.mClipping == UIDrawCall.Clipping.None || uiPanel.mClipping == UIDrawCall.Clipping.ConstrainButDontClip) && !w.hideIfOffScreen)
      {
        uiPanel = uiPanel.mParentPanel;
      }
      else
      {
        if (vector3Array == null)
          vector3Array = w.worldCorners;
        if (!uiPanel.IsVisible(vector3Array[0], vector3Array[1], vector3Array[2], vector3Array[3]))
          return false;
        uiPanel = uiPanel.mParentPanel;
      }
    }
    return true;
  }

  public bool Affects(UIWidget w)
  {
    if ((UnityEngine.Object) w == (UnityEngine.Object) null)
      return false;
    UIPanel panel = w.panel;
    if ((UnityEngine.Object) panel == (UnityEngine.Object) null)
      return false;
    for (UIPanel uiPanel = this; (UnityEngine.Object) uiPanel != (UnityEngine.Object) null; uiPanel = uiPanel.mParentPanel)
    {
      if ((UnityEngine.Object) uiPanel == (UnityEngine.Object) panel)
        return true;
      if (!uiPanel.hasCumulativeClipping)
        return false;
    }
    return false;
  }

  [ContextMenu("Force Refresh")]
  public void RebuildAllDrawCalls() => this.mRebuild = true;

  public void SetDirty()
  {
    int index = 0;
    for (int count = this.drawCalls.Count; index < count; ++index)
      this.drawCalls[index].isDirty = true;
    this.Invalidate(true);
  }

  protected override void Awake() => base.Awake();

  private void FindParent()
  {
    Transform parent = this.cachedTransform.parent;
    this.mParentPanel = (UnityEngine.Object) parent != (UnityEngine.Object) null ? NGUITools.FindInParents<UIPanel>(parent.gameObject) : (UIPanel) null;
  }

  public override void ParentHasChanged()
  {
    base.ParentHasChanged();
    this.FindParent();
  }

  protected override void OnStart() => this.mLayer = this.cachedGameObject.layer;

  protected override void OnEnable()
  {
    this.mRebuild = true;
    this.mAlphaFrameID = -1;
    this.mMatrixFrame = -1;
    this.OnStart();
    base.OnEnable();
    this.mMatrixFrame = -1;
  }

  protected override void OnInit()
  {
    if (UIPanel.list.Contains(this))
      return;
    base.OnInit();
    this.FindParent();
    if ((UnityEngine.Object) this.GetComponent<Rigidbody>() == (UnityEngine.Object) null && (UnityEngine.Object) this.mParentPanel == (UnityEngine.Object) null)
    {
      UICamera uiCamera = (UnityEngine.Object) this.anchorCamera != (UnityEngine.Object) null ? this.mCam.GetComponent<UICamera>() : (UICamera) null;
      if ((UnityEngine.Object) uiCamera != (UnityEngine.Object) null && (uiCamera.eventType == UICamera.EventType.UI_3D || uiCamera.eventType == UICamera.EventType.World_3D))
      {
        Rigidbody rigidbody = this.gameObject.AddComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
      }
    }
    this.mRebuild = true;
    this.mAlphaFrameID = -1;
    this.mMatrixFrame = -1;
    UIPanel.list.Add(this);
    UIPanel.list.Sort(new Comparison<UIPanel>(UIPanel.CompareFunc));
  }

  protected override void OnDisable()
  {
    int index = 0;
    for (int count = this.drawCalls.Count; index < count; ++index)
    {
      UIDrawCall drawCall = this.drawCalls[index];
      if ((UnityEngine.Object) drawCall != (UnityEngine.Object) null)
        UIDrawCall.Destroy(drawCall);
    }
    this.drawCalls.Clear();
    UIPanel.list.Remove(this);
    this.mAlphaFrameID = -1;
    this.mMatrixFrame = -1;
    if (UIPanel.list.Count == 0)
    {
      UIDrawCall.ReleaseAll();
      UIPanel.mUpdateFrame = -1;
    }
    base.OnDisable();
  }

  private void UpdateTransformMatrix()
  {
    int frameCount = Time.frameCount;
    if (!this.mHasMoved && this.mMatrixFrame == frameCount)
      return;
    this.mMatrixFrame = frameCount;
    this.worldToLocal = this.cachedTransform.worldToLocalMatrix;
    Vector2 vector2 = this.GetViewSize() * 0.5f;
    float num1 = this.mClipOffset.x + this.mClipRange.x;
    float num2 = this.mClipOffset.y + this.mClipRange.y;
    this.mMin.x = num1 - vector2.x;
    this.mMin.y = num2 - vector2.y;
    this.mMax.x = num1 + vector2.x;
    this.mMax.y = num2 + vector2.y;
  }

  protected override void OnAnchor()
  {
    if (this.mClipping == UIDrawCall.Clipping.None)
      return;
    Transform cachedTransform = this.cachedTransform;
    Transform parent = cachedTransform.parent;
    Vector2 viewSize = this.GetViewSize();
    Vector2 localPosition = (Vector2) cachedTransform.localPosition;
    float num1;
    float num2;
    float num3;
    float num4;
    if ((UnityEngine.Object) this.leftAnchor.target == (UnityEngine.Object) this.bottomAnchor.target && (UnityEngine.Object) this.leftAnchor.target == (UnityEngine.Object) this.rightAnchor.target && (UnityEngine.Object) this.leftAnchor.target == (UnityEngine.Object) this.topAnchor.target)
    {
      Vector3[] sides = this.leftAnchor.GetSides(parent);
      if (sides != null)
      {
        num1 = NGUIMath.Lerp(sides[0].x, sides[2].x, this.leftAnchor.relative) + (float) this.leftAnchor.absolute;
        num2 = NGUIMath.Lerp(sides[0].x, sides[2].x, this.rightAnchor.relative) + (float) this.rightAnchor.absolute;
        num3 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.bottomAnchor.relative) + (float) this.bottomAnchor.absolute;
        num4 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.topAnchor.relative) + (float) this.topAnchor.absolute;
      }
      else
      {
        Vector2 localPos = (Vector2) this.GetLocalPos(this.leftAnchor, parent);
        num1 = localPos.x + (float) this.leftAnchor.absolute;
        num3 = localPos.y + (float) this.bottomAnchor.absolute;
        num2 = localPos.x + (float) this.rightAnchor.absolute;
        num4 = localPos.y + (float) this.topAnchor.absolute;
      }
    }
    else
    {
      if ((bool) (UnityEngine.Object) this.leftAnchor.target)
      {
        Vector3[] sides = this.leftAnchor.GetSides(parent);
        num1 = sides == null ? this.GetLocalPos(this.leftAnchor, parent).x + (float) this.leftAnchor.absolute : NGUIMath.Lerp(sides[0].x, sides[2].x, this.leftAnchor.relative) + (float) this.leftAnchor.absolute;
      }
      else
        num1 = this.mClipRange.x - 0.5f * viewSize.x;
      if ((bool) (UnityEngine.Object) this.rightAnchor.target)
      {
        Vector3[] sides = this.rightAnchor.GetSides(parent);
        num2 = sides == null ? this.GetLocalPos(this.rightAnchor, parent).x + (float) this.rightAnchor.absolute : NGUIMath.Lerp(sides[0].x, sides[2].x, this.rightAnchor.relative) + (float) this.rightAnchor.absolute;
      }
      else
        num2 = this.mClipRange.x + 0.5f * viewSize.x;
      if ((bool) (UnityEngine.Object) this.bottomAnchor.target)
      {
        Vector3[] sides = this.bottomAnchor.GetSides(parent);
        num3 = sides == null ? this.GetLocalPos(this.bottomAnchor, parent).y + (float) this.bottomAnchor.absolute : NGUIMath.Lerp(sides[3].y, sides[1].y, this.bottomAnchor.relative) + (float) this.bottomAnchor.absolute;
      }
      else
        num3 = this.mClipRange.y - 0.5f * viewSize.y;
      if ((bool) (UnityEngine.Object) this.topAnchor.target)
      {
        Vector3[] sides = this.topAnchor.GetSides(parent);
        num4 = sides == null ? this.GetLocalPos(this.topAnchor, parent).y + (float) this.topAnchor.absolute : NGUIMath.Lerp(sides[3].y, sides[1].y, this.topAnchor.relative) + (float) this.topAnchor.absolute;
      }
      else
        num4 = this.mClipRange.y + 0.5f * viewSize.y;
    }
    float a1 = num1 - (localPosition.x + this.mClipOffset.x);
    float b1 = num2 - (localPosition.x + this.mClipOffset.x);
    float a2 = num3 - (localPosition.y + this.mClipOffset.y);
    float b2 = num4 - (localPosition.y + this.mClipOffset.y);
    float x = Mathf.Lerp(a1, b1, 0.5f);
    float y = Mathf.Lerp(a2, b2, 0.5f);
    float z = b1 - a1;
    float w = b2 - a2;
    float num5 = Mathf.Max(2f, this.mClipSoftness.x);
    float num6 = Mathf.Max(2f, this.mClipSoftness.y);
    if ((double) z < (double) num5)
      z = num5;
    if ((double) w < (double) num6)
      w = num6;
    this.baseClipRegion = new Vector4(x, y, z, w);
  }

  private void LateUpdate()
  {
    if (UIPanel.mUpdateFrame == Time.frameCount)
      return;
    UIPanel.mUpdateFrame = Time.frameCount;
    int index = 0;
    for (int count = UIPanel.list.Count; index < count; ++index)
      UIPanel.list[index].UpdateSelf();
    int a = 3000;
    int num = 0;
    for (int count = UIPanel.list.Count; num < count; ++num)
    {
      UIPanel uiPanel = UIPanel.list[num];
      if (uiPanel.renderQueue == UIPanel.RenderQueue.Automatic)
      {
        uiPanel.startingRenderQueue = a;
        uiPanel.UpdateDrawCalls(num);
        a += uiPanel.drawCalls.Count;
      }
      else if (uiPanel.renderQueue == UIPanel.RenderQueue.StartAt)
      {
        uiPanel.UpdateDrawCalls(num);
        if (uiPanel.drawCalls.Count != 0)
          a = Mathf.Max(a, uiPanel.startingRenderQueue + uiPanel.drawCalls.Count);
      }
      else
      {
        uiPanel.UpdateDrawCalls(num);
        if (uiPanel.drawCalls.Count != 0)
          a = Mathf.Max(a, uiPanel.startingRenderQueue + 1);
      }
    }
  }

  private void UpdateSelf()
  {
    this.mHasMoved = this.cachedTransform.hasChanged;
    this.UpdateTransformMatrix();
    this.UpdateLayers();
    this.UpdateWidgets();
    if (this.mRebuild)
    {
      this.mRebuild = false;
      this.FillAllDrawCalls();
    }
    else
    {
      bool needsCulling = (UnityEngine.Object) this.mCam == (UnityEngine.Object) null || this.mCam.useOcclusionCulling;
      int index = 0;
      while (index < this.drawCalls.Count)
      {
        UIDrawCall drawCall = this.drawCalls[index];
        if (drawCall.isDirty && !this.FillDrawCall(drawCall, needsCulling))
        {
          UIDrawCall.Destroy(drawCall);
          this.drawCalls.RemoveAt(index);
        }
        else
          ++index;
      }
    }
    if (this.mUpdateScroll)
    {
      this.mUpdateScroll = false;
      UIScrollView component = this.GetComponent<UIScrollView>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        component.UpdateScrollbars();
    }
    if (!this.mHasMoved)
      return;
    this.mHasMoved = false;
    this.mTrans.hasChanged = false;
  }

  public void SortWidgets()
  {
    this.mSortWidgets = false;
    this.widgets.Sort(new Comparison<UIWidget>(UIWidget.PanelCompareFunc));
  }

  private void FillAllDrawCalls()
  {
    for (int index = 0; index < this.drawCalls.Count; ++index)
      UIDrawCall.Destroy(this.drawCalls[index]);
    this.drawCalls.Clear();
    Material mat1 = (Material) null;
    Texture tex = (Texture) null;
    Shader shader1 = (Shader) null;
    UIDrawCall uiDrawCall = (UIDrawCall) null;
    int widgetCount = 0;
    bool needsBounds = (UnityEngine.Object) this.mCam == (UnityEngine.Object) null || this.mCam.useOcclusionCulling;
    if (this.mSortWidgets)
      this.SortWidgets();
    for (int index = 0; index < this.widgets.Count; ++index)
    {
      UIWidget widget = this.widgets[index];
      if (widget.isVisible && widget.hasVertices)
      {
        Material mat2 = widget.material;
        if (this.onCreateMaterial != null)
          mat2 = this.onCreateMaterial(widget, mat2);
        Texture mainTexture = widget.mainTexture;
        Shader shader2 = widget.shader;
        if ((UnityEngine.Object) mat1 != (UnityEngine.Object) mat2 || (UnityEngine.Object) tex != (UnityEngine.Object) mainTexture || (UnityEngine.Object) shader1 != (UnityEngine.Object) shader2)
        {
          if ((UnityEngine.Object) uiDrawCall != (UnityEngine.Object) null && uiDrawCall.verts.Count != 0)
          {
            this.drawCalls.Add(uiDrawCall);
            uiDrawCall.UpdateGeometry(widgetCount, needsBounds);
            uiDrawCall.onRender = this.mOnRender;
            this.mOnRender = (UIDrawCall.OnRenderCallback) null;
            widgetCount = 0;
            uiDrawCall = (UIDrawCall) null;
          }
          mat1 = mat2;
          tex = mainTexture;
          shader1 = shader2;
        }
        if ((UnityEngine.Object) mat1 != (UnityEngine.Object) null || (UnityEngine.Object) shader1 != (UnityEngine.Object) null || (UnityEngine.Object) tex != (UnityEngine.Object) null)
        {
          if ((UnityEngine.Object) uiDrawCall == (UnityEngine.Object) null)
          {
            if (true)
            {
              uiDrawCall = UIDrawCall.Create(this, mat1, tex, shader1);
              uiDrawCall.depthStart = widget.depth;
              uiDrawCall.depthEnd = uiDrawCall.depthStart;
              uiDrawCall.panel = this;
              uiDrawCall.onCreateDrawCall = this.onCreateDrawCall;
            }
          }
          else
          {
            int depth = widget.depth;
            if (depth < uiDrawCall.depthStart)
              uiDrawCall.depthStart = depth;
            if (depth > uiDrawCall.depthEnd)
              uiDrawCall.depthEnd = depth;
          }
          widget.drawCall = uiDrawCall;
          if ((UnityEngine.Object) uiDrawCall != (UnityEngine.Object) null)
          {
            ++widgetCount;
            if (this.generateNormals)
              widget.WriteToBuffers(uiDrawCall.verts, uiDrawCall.uvs, uiDrawCall.cols, uiDrawCall.norms, uiDrawCall.tans, this.generateUV2 ? uiDrawCall.uv2 : (List<Vector4>) null);
            else
              widget.WriteToBuffers(uiDrawCall.verts, uiDrawCall.uvs, uiDrawCall.cols, (List<Vector3>) null, (List<Vector4>) null, this.generateUV2 ? uiDrawCall.uv2 : (List<Vector4>) null);
            if (widget.mOnRender != null)
            {
              if (this.mOnRender == null)
                this.mOnRender = widget.mOnRender;
              else
                this.mOnRender += widget.mOnRender;
            }
          }
        }
      }
      else
        widget.drawCall = (UIDrawCall) null;
    }
    if (!((UnityEngine.Object) uiDrawCall != (UnityEngine.Object) null) || uiDrawCall.verts.Count == 0)
      return;
    this.drawCalls.Add(uiDrawCall);
    uiDrawCall.UpdateGeometry(widgetCount, needsBounds);
    uiDrawCall.onRender = this.mOnRender;
    this.mOnRender = (UIDrawCall.OnRenderCallback) null;
  }

  public bool FillDrawCall(UIDrawCall dc)
  {
    bool needsCulling = (UnityEngine.Object) this.mCam == (UnityEngine.Object) null || this.mCam.useOcclusionCulling;
    return this.FillDrawCall(dc, needsCulling);
  }

  public bool FillDrawCall(UIDrawCall dc, bool needsCulling)
  {
    if ((UnityEngine.Object) dc != (UnityEngine.Object) null)
    {
      dc.isDirty = false;
      int widgetCount = 0;
      int index = 0;
      while (index < this.widgets.Count)
      {
        UIWidget widget = this.widgets[index];
        if ((UnityEngine.Object) widget == (UnityEngine.Object) null)
        {
          this.widgets.RemoveAt(index);
        }
        else
        {
          if ((UnityEngine.Object) widget.drawCall == (UnityEngine.Object) dc)
          {
            if (widget.isVisible && widget.hasVertices)
            {
              ++widgetCount;
              if (this.generateNormals)
                widget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, dc.norms, dc.tans, this.generateUV2 ? dc.uv2 : (List<Vector4>) null);
              else
                widget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, (List<Vector3>) null, (List<Vector4>) null, this.generateUV2 ? dc.uv2 : (List<Vector4>) null);
              if (widget.mOnRender != null)
              {
                if (this.mOnRender == null)
                  this.mOnRender = widget.mOnRender;
                else
                  this.mOnRender += widget.mOnRender;
              }
            }
            else
              widget.drawCall = (UIDrawCall) null;
          }
          ++index;
        }
      }
      if (dc.verts.Count != 0)
      {
        dc.UpdateGeometry(widgetCount, needsCulling);
        dc.onRender = this.mOnRender;
        this.mOnRender = (UIDrawCall.OnRenderCallback) null;
        return true;
      }
    }
    return false;
  }

  private void UpdateDrawCalls(int sortOrder)
  {
    Transform cachedTransform1 = this.cachedTransform;
    int num = this.usedForUI ? 1 : 0;
    if (this.clipping != UIDrawCall.Clipping.None)
    {
      this.drawCallClipRange = this.finalClipRegion;
      this.drawCallClipRange.z *= 0.5f;
      this.drawCallClipRange.w *= 0.5f;
    }
    else
      this.drawCallClipRange = Vector4.zero;
    int width = Screen.width;
    int height = Screen.height;
    if ((double) this.drawCallClipRange.z == 0.0)
      this.drawCallClipRange.z = (float) width * 0.5f;
    if ((double) this.drawCallClipRange.w == 0.0)
      this.drawCallClipRange.w = (float) height * 0.5f;
    if (this.halfPixelOffset)
    {
      this.drawCallClipRange.x -= 0.5f;
      this.drawCallClipRange.y += 0.5f;
    }
    Vector3 vector3;
    if (num != 0)
    {
      Transform parent = this.cachedTransform.parent;
      Vector3 position = this.cachedTransform.localPosition;
      if (this.clipping != UIDrawCall.Clipping.None)
      {
        position.x = (float) Mathf.RoundToInt(position.x);
        position.y = (float) Mathf.RoundToInt(position.y);
      }
      if ((UnityEngine.Object) parent != (UnityEngine.Object) null)
        position = parent.TransformPoint(position);
      vector3 = position + this.drawCallOffset;
    }
    else
      vector3 = cachedTransform1.position;
    Quaternion rotation = cachedTransform1.rotation;
    Vector3 lossyScale = cachedTransform1.lossyScale;
    for (int index = 0; index < this.drawCalls.Count; ++index)
    {
      UIDrawCall drawCall = this.drawCalls[index];
      Transform cachedTransform2 = drawCall.cachedTransform;
      cachedTransform2.position = vector3;
      cachedTransform2.rotation = rotation;
      cachedTransform2.localScale = lossyScale;
      drawCall.renderQueue = this.renderQueue == UIPanel.RenderQueue.Explicit ? this.startingRenderQueue : this.startingRenderQueue + index;
      drawCall.alwaysOnScreen = this.alwaysOnScreen && (this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip);
      drawCall.sortingOrder = this.useSortingOrder ? (this.mSortingOrder != 0 || this.renderQueue != UIPanel.RenderQueue.Automatic ? this.mSortingOrder : sortOrder) : 0;
      drawCall.sortingLayerName = this.useSortingOrder ? this.mSortingLayerName : (string) null;
      drawCall.clipTexture = this.mClipTexture;
      drawCall.shadowMode = this.shadowMode;
    }
  }

  private void UpdateLayers()
  {
    if (this.mLayer == this.cachedGameObject.layer)
      return;
    this.mLayer = this.mGo.layer;
    int index1 = 0;
    for (int count = this.widgets.Count; index1 < count; ++index1)
    {
      UIWidget widget = this.widgets[index1];
      if ((bool) (UnityEngine.Object) widget && (UnityEngine.Object) widget.parent == (UnityEngine.Object) this)
        widget.gameObject.layer = this.mLayer;
    }
    this.ResetAnchors();
    for (int index2 = 0; index2 < this.drawCalls.Count; ++index2)
      this.drawCalls[index2].gameObject.layer = this.mLayer;
  }

  private void UpdateWidgets()
  {
    bool flag1 = false;
    bool flag2 = false;
    bool cumulativeClipping = this.hasCumulativeClipping;
    if (!this.cullWhileDragging)
    {
      for (int index = 0; index < UIScrollView.list.size; ++index)
      {
        UIScrollView uiScrollView = UIScrollView.list.buffer[index];
        if ((UnityEngine.Object) uiScrollView.panel == (UnityEngine.Object) this && uiScrollView.isDragging)
          flag2 = true;
      }
    }
    if (this.mForced != flag2)
    {
      this.mForced = flag2;
      this.mResized = true;
    }
    int frameCount = Time.frameCount;
    int index1 = 0;
    for (int count = this.widgets.Count; index1 < count; ++index1)
    {
      UIWidget widget = this.widgets[index1];
      if ((UnityEngine.Object) widget.panel == (UnityEngine.Object) this && widget.enabled)
      {
        if (widget.UpdateTransform(frameCount) || this.mResized || this.mHasMoved && !this.alwaysOnScreen)
        {
          bool visibleByAlpha = flag2 || (double) widget.CalculateCumulativeAlpha(frameCount) > 1.0 / 1000.0;
          widget.UpdateVisibility(visibleByAlpha, flag2 || this.alwaysOnScreen || !cumulativeClipping && !widget.hideIfOffScreen || this.IsVisible(widget));
        }
        if (widget.UpdateGeometry(frameCount))
        {
          flag1 = true;
          if (!this.mRebuild)
          {
            if ((UnityEngine.Object) widget.drawCall != (UnityEngine.Object) null)
              widget.drawCall.isDirty = true;
            else
              this.FindDrawCall(widget);
          }
        }
      }
    }
    if (flag1 && this.onGeometryUpdated != null)
      this.onGeometryUpdated();
    this.mResized = false;
  }

  public UIDrawCall FindDrawCall(UIWidget w)
  {
    Material material = w.material;
    Texture mainTexture = w.mainTexture;
    Shader shader = w.shader;
    int depth = w.depth;
    for (int index = 0; index < this.drawCalls.Count; ++index)
    {
      UIDrawCall drawCall = this.drawCalls[index];
      int num1 = index == 0 ? int.MinValue : this.drawCalls[index - 1].depthEnd + 1;
      int num2 = index + 1 == this.drawCalls.Count ? int.MaxValue : this.drawCalls[index + 1].depthStart - 1;
      int num3 = depth;
      if (num1 <= num3 && num2 >= depth)
      {
        if ((UnityEngine.Object) drawCall.baseMaterial == (UnityEngine.Object) material && (UnityEngine.Object) drawCall.shader == (UnityEngine.Object) shader && (UnityEngine.Object) drawCall.mainTexture == (UnityEngine.Object) mainTexture)
        {
          if (w.isVisible)
          {
            w.drawCall = drawCall;
            if (w.hasVertices)
              drawCall.isDirty = true;
            return drawCall;
          }
        }
        else
          this.mRebuild = true;
        return (UIDrawCall) null;
      }
    }
    this.mRebuild = true;
    return (UIDrawCall) null;
  }

  public void AddWidget(UIWidget w)
  {
    this.mUpdateScroll = true;
    if (this.widgets.Count == 0)
      this.widgets.Add(w);
    else if (this.mSortWidgets)
    {
      this.widgets.Add(w);
      this.SortWidgets();
    }
    else if (UIWidget.PanelCompareFunc(w, this.widgets[0]) == -1)
    {
      this.widgets.Insert(0, w);
    }
    else
    {
      int count = this.widgets.Count;
      while (count > 0)
      {
        if (UIWidget.PanelCompareFunc(w, this.widgets[--count]) != -1)
        {
          this.widgets.Insert(count + 1, w);
          break;
        }
      }
    }
    this.FindDrawCall(w);
  }

  public void RemoveWidget(UIWidget w)
  {
    if (!this.widgets.Remove(w) || !((UnityEngine.Object) w.drawCall != (UnityEngine.Object) null))
      return;
    int depth = w.depth;
    if (depth == w.drawCall.depthStart || depth == w.drawCall.depthEnd)
      this.mRebuild = true;
    w.drawCall.isDirty = true;
    w.drawCall = (UIDrawCall) null;
  }

  public void Refresh()
  {
    this.mRebuild = true;
    UIPanel.mUpdateFrame = -1;
    if (UIPanel.list.Count <= 0)
      return;
    UIPanel.list[0].LateUpdate();
  }

  public virtual Vector3 CalculateConstrainOffset(Vector2 min, Vector2 max)
  {
    Vector4 finalClipRegion = this.finalClipRegion;
    float num1 = finalClipRegion.z * 0.5f;
    float num2 = finalClipRegion.w * 0.5f;
    Vector2 minRect = new Vector2(min.x, min.y);
    Vector2 vector2_1 = new Vector2(max.x, max.y);
    Vector2 vector2_2 = new Vector2(finalClipRegion.x - num1, finalClipRegion.y - num2);
    Vector2 vector2_3 = new Vector2(finalClipRegion.x + num1, finalClipRegion.y + num2);
    if (this.softBorderPadding && this.clipping == UIDrawCall.Clipping.SoftClip)
    {
      vector2_2.x += this.mClipSoftness.x;
      vector2_2.y += this.mClipSoftness.y;
      vector2_3.x -= this.mClipSoftness.x;
      vector2_3.y -= this.mClipSoftness.y;
    }
    Vector2 maxRect = vector2_1;
    Vector2 minArea = vector2_2;
    Vector2 maxArea = vector2_3;
    return (Vector3) NGUIMath.ConstrainRect(minRect, maxRect, minArea, maxArea);
  }

  public bool ConstrainTargetToBounds(Transform target, ref Bounds targetBounds, bool immediate)
  {
    Vector3 min = targetBounds.min;
    Vector3 max = targetBounds.max;
    float num = 1f;
    if (this.mClipping == UIDrawCall.Clipping.None)
    {
      UIRoot root = this.root;
      if ((UnityEngine.Object) root != (UnityEngine.Object) null)
        num = root.pixelSizeAdjustment;
    }
    if ((double) num != 1.0)
    {
      min /= num;
      max /= num;
    }
    Vector3 vector3 = this.CalculateConstrainOffset((Vector2) min, (Vector2) max) * num;
    if ((double) vector3.sqrMagnitude <= 0.0)
      return false;
    if (immediate)
    {
      target.localPosition += vector3;
      targetBounds.center += vector3;
      SpringPosition component = target.GetComponent<SpringPosition>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        component.enabled = false;
    }
    else
    {
      SpringPosition springPosition = SpringPosition.Begin(target.gameObject, target.localPosition + vector3, 13f);
      springPosition.ignoreTimeScale = true;
      springPosition.worldSpace = false;
    }
    return true;
  }

  public bool ConstrainTargetToBounds(Transform target, bool immediate)
  {
    Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(this.cachedTransform, target);
    return this.ConstrainTargetToBounds(target, ref relativeWidgetBounds, immediate);
  }

  public static UIPanel Find(Transform trans) => UIPanel.Find(trans, false, -1);

  public static UIPanel Find(Transform trans, bool createIfMissing) => UIPanel.Find(trans, createIfMissing, -1);

  public static UIPanel Find(Transform trans, bool createIfMissing, int layer)
  {
    UIPanel inParents = NGUITools.FindInParents<UIPanel>(trans);
    if ((UnityEngine.Object) inParents != (UnityEngine.Object) null)
      return inParents;
    while ((UnityEngine.Object) trans.parent != (UnityEngine.Object) null)
      trans = trans.parent;
    return !createIfMissing ? (UIPanel) null : NGUITools.CreateUI(trans, false, layer);
  }

  public Vector2 GetWindowSize()
  {
    UIRoot root = this.root;
    Vector2 screenSize = NGUITools.screenSize;
    if ((UnityEngine.Object) root != (UnityEngine.Object) null)
      screenSize *= root.GetPixelSizeAdjustment(Mathf.RoundToInt(screenSize.y));
    return screenSize;
  }

  public Vector2 GetViewSize() => this.mClipping != UIDrawCall.Clipping.None ? new Vector2(this.mClipRange.z, this.mClipRange.w) : NGUITools.screenSize;

  [DoNotObfuscateNGUI]
  public enum RenderQueue
  {
    Automatic,
    StartAt,
    Explicit,
  }

  public delegate void OnGeometryUpdated();

  public delegate void OnClippingMoved(UIPanel panel);

  public delegate Material OnCreateMaterial(UIWidget widget, Material mat);
}
