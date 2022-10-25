// Decompiled with JetBrains decompiler
// Type: UIWidget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Invisible Widget")]
public class UIWidget : UIRect
{
  [HideInInspector]
  [SerializeField]
  protected Color mColor = Color.white;
  [HideInInspector]
  [SerializeField]
  protected UIWidget.Pivot mPivot = UIWidget.Pivot.Center;
  [HideInInspector]
  [SerializeField]
  protected int mWidth = 100;
  [HideInInspector]
  [SerializeField]
  protected int mHeight = 100;
  [HideInInspector]
  [SerializeField]
  protected int mDepth;
  [Tooltip("Custom material, if desired")]
  [HideInInspector]
  [SerializeField]
  protected Material mMat;
  public UIWidget.OnDimensionsChanged onChange;
  public UIWidget.OnPostFillCallback onPostFill;
  public UIDrawCall.OnRenderCallback mOnRender;
  public bool autoResizeBoxCollider;
  public bool hideIfOffScreen;
  public UIWidget.AspectRatioSource keepAspectRatio;
  public float aspectRatio = 1f;
  public UIWidget.HitCheck hitCheck;
  [NonSerialized]
  public UIPanel panel;
  [NonSerialized]
  public UIGeometry geometry = new UIGeometry();
  [NonSerialized]
  public bool fillGeometry = true;
  [NonSerialized]
  protected bool mPlayMode = true;
  [NonSerialized]
  protected Vector4 mDrawRegion = new Vector4(0.0f, 0.0f, 1f, 1f);
  [NonSerialized]
  private Matrix4x4 mLocalToPanel;
  [NonSerialized]
  private bool mIsVisibleByAlpha = true;
  [NonSerialized]
  private bool mIsVisibleByPanel = true;
  [NonSerialized]
  private bool mIsInFront = true;
  [NonSerialized]
  private float mLastAlpha;
  [NonSerialized]
  private bool mMoved;
  [NonSerialized]
  public UIDrawCall drawCall;
  [NonSerialized]
  protected Vector3[] mCorners = new Vector3[4];
  [NonSerialized]
  private int mAlphaFrameID = -1;
  private int mMatrixFrame = -1;
  private Vector3 mOldV0;
  private Vector3 mOldV1;

  public UIDrawCall.OnRenderCallback onRender
  {
    get => this.mOnRender;
    set
    {
      if (!(this.mOnRender != value))
        return;
      if ((UnityEngine.Object) this.drawCall != (UnityEngine.Object) null && this.drawCall.onRender != null && this.mOnRender != null)
        this.drawCall.onRender -= this.mOnRender;
      this.mOnRender = value;
      if (!((UnityEngine.Object) this.drawCall != (UnityEngine.Object) null))
        return;
      this.drawCall.onRender += value;
    }
  }

  public Vector4 drawRegion
  {
    get => this.mDrawRegion;
    set
    {
      if (!(this.mDrawRegion != value))
        return;
      this.mDrawRegion = value;
      if (this.autoResizeBoxCollider)
        this.ResizeCollider();
      this.MarkAsChanged();
    }
  }

  public Vector2 pivotOffset => NGUIMath.GetPivotOffset(this.pivot);

  public int width
  {
    get => this.mWidth;
    set
    {
      int minWidth = this.minWidth;
      if (value < minWidth)
        value = minWidth;
      if (this.mWidth == value || this.keepAspectRatio == UIWidget.AspectRatioSource.BasedOnHeight)
        return;
      if (this.isAnchoredHorizontally)
      {
        if ((UnityEngine.Object) this.leftAnchor.target != (UnityEngine.Object) null && (UnityEngine.Object) this.rightAnchor.target != (UnityEngine.Object) null)
        {
          if (this.mPivot == UIWidget.Pivot.BottomLeft || this.mPivot == UIWidget.Pivot.Left || this.mPivot == UIWidget.Pivot.TopLeft)
            NGUIMath.AdjustWidget(this, 0.0f, 0.0f, (float) (value - this.mWidth), 0.0f);
          else if (this.mPivot == UIWidget.Pivot.BottomRight || this.mPivot == UIWidget.Pivot.Right || this.mPivot == UIWidget.Pivot.TopRight)
          {
            NGUIMath.AdjustWidget(this, (float) (this.mWidth - value), 0.0f, 0.0f, 0.0f);
          }
          else
          {
            int num1 = value - this.mWidth;
            int num2 = num1 - (num1 & 1);
            if (num2 == 0)
              return;
            NGUIMath.AdjustWidget(this, (float) -num2 * 0.5f, 0.0f, (float) num2 * 0.5f, 0.0f);
          }
        }
        else if ((UnityEngine.Object) this.leftAnchor.target != (UnityEngine.Object) null)
          NGUIMath.AdjustWidget(this, 0.0f, 0.0f, (float) (value - this.mWidth), 0.0f);
        else
          NGUIMath.AdjustWidget(this, (float) (this.mWidth - value), 0.0f, 0.0f, 0.0f);
      }
      else
        this.SetDimensions(value, this.mHeight);
    }
  }

  public int height
  {
    get => this.mHeight;
    set
    {
      int minHeight = this.minHeight;
      if (value < minHeight)
        value = minHeight;
      if (this.mHeight == value || this.keepAspectRatio == UIWidget.AspectRatioSource.BasedOnWidth)
        return;
      if (this.isAnchoredVertically)
      {
        if ((UnityEngine.Object) this.bottomAnchor.target != (UnityEngine.Object) null && (UnityEngine.Object) this.topAnchor.target != (UnityEngine.Object) null)
        {
          if (this.mPivot == UIWidget.Pivot.BottomLeft || this.mPivot == UIWidget.Pivot.Bottom || this.mPivot == UIWidget.Pivot.BottomRight)
            NGUIMath.AdjustWidget(this, 0.0f, 0.0f, 0.0f, (float) (value - this.mHeight));
          else if (this.mPivot == UIWidget.Pivot.TopLeft || this.mPivot == UIWidget.Pivot.Top || this.mPivot == UIWidget.Pivot.TopRight)
          {
            NGUIMath.AdjustWidget(this, 0.0f, (float) (this.mHeight - value), 0.0f, 0.0f);
          }
          else
          {
            int num1 = value - this.mHeight;
            int num2 = num1 - (num1 & 1);
            if (num2 == 0)
              return;
            NGUIMath.AdjustWidget(this, 0.0f, (float) -num2 * 0.5f, 0.0f, (float) num2 * 0.5f);
          }
        }
        else if ((UnityEngine.Object) this.bottomAnchor.target != (UnityEngine.Object) null)
          NGUIMath.AdjustWidget(this, 0.0f, 0.0f, 0.0f, (float) (value - this.mHeight));
        else
          NGUIMath.AdjustWidget(this, 0.0f, (float) (this.mHeight - value), 0.0f, 0.0f);
      }
      else
        this.SetDimensions(this.mWidth, value);
    }
  }

  public Color color
  {
    get => this.mColor;
    set
    {
      if (!(this.mColor != value))
        return;
      bool includeChildren = (double) this.mColor.a != (double) value.a;
      this.mColor = value;
      this.Invalidate(includeChildren);
    }
  }

  public void SetColorNoAlpha(Color c)
  {
    if ((double) this.mColor.r == (double) c.r && (double) this.mColor.g == (double) c.g && (double) this.mColor.b == (double) c.b)
      return;
    this.mColor.r = c.r;
    this.mColor.g = c.g;
    this.mColor.b = c.b;
    this.Invalidate(false);
  }

  public override float alpha
  {
    get => this.mColor.a;
    set
    {
      if ((double) this.mColor.a == (double) value)
        return;
      this.mColor.a = value;
      this.Invalidate(true);
    }
  }

  public bool isVisible => this.mIsVisibleByPanel && this.mIsVisibleByAlpha && this.mIsInFront && (double) this.finalAlpha > 1.0 / 1000.0 && NGUITools.GetActive((Behaviour) this);

  public bool hasVertices => this.geometry != null && this.geometry.hasVertices;

  public UIWidget.Pivot rawPivot
  {
    get => this.mPivot;
    set
    {
      if (this.mPivot == value)
        return;
      this.mPivot = value;
      if (this.autoResizeBoxCollider)
        this.ResizeCollider();
      this.MarkAsChanged();
    }
  }

  public UIWidget.Pivot pivot
  {
    get => this.mPivot;
    set
    {
      if (this.mPivot == value)
        return;
      Vector3 worldCorner1 = this.worldCorners[0];
      this.mPivot = value;
      this.mChanged = true;
      Vector3 worldCorner2 = this.worldCorners[0];
      Transform cachedTransform = this.cachedTransform;
      Vector3 position = cachedTransform.position;
      float z = cachedTransform.localPosition.z;
      position.x += worldCorner1.x - worldCorner2.x;
      position.y += worldCorner1.y - worldCorner2.y;
      this.cachedTransform.position = position;
      Vector3 localPosition = this.cachedTransform.localPosition;
      localPosition.x = Mathf.Round(localPosition.x);
      localPosition.y = Mathf.Round(localPosition.y);
      localPosition.z = z;
      this.cachedTransform.localPosition = localPosition;
    }
  }

  public int depth
  {
    get => this.mDepth;
    set
    {
      if (this.mDepth == value)
        return;
      if ((UnityEngine.Object) this.panel != (UnityEngine.Object) null)
        this.panel.RemoveWidget(this);
      this.mDepth = value;
      if (!((UnityEngine.Object) this.panel != (UnityEngine.Object) null))
        return;
      this.panel.AddWidget(this);
      if (Application.isPlaying)
        return;
      this.panel.SortWidgets();
      this.panel.RebuildAllDrawCalls();
    }
  }

  public int raycastDepth
  {
    get
    {
      if ((UnityEngine.Object) this.panel == (UnityEngine.Object) null)
        this.CreatePanel();
      return !((UnityEngine.Object) this.panel != (UnityEngine.Object) null) ? this.mDepth : this.mDepth + this.panel.depth * 1000;
    }
  }

  public override Vector3[] localCorners
  {
    get
    {
      Vector2 pivotOffset = this.pivotOffset;
      float x1 = -pivotOffset.x * (float) this.mWidth;
      float y1 = -pivotOffset.y * (float) this.mHeight;
      float x2 = x1 + (float) this.mWidth;
      float y2 = y1 + (float) this.mHeight;
      this.mCorners[0] = new Vector3(x1, y1);
      this.mCorners[1] = new Vector3(x1, y2);
      this.mCorners[2] = new Vector3(x2, y2);
      this.mCorners[3] = new Vector3(x2, y1);
      return this.mCorners;
    }
  }

  public virtual Vector2 localSize
  {
    get
    {
      Vector3[] localCorners = this.localCorners;
      return (Vector2) (localCorners[2] - localCorners[0]);
    }
  }

  public Vector3 localCenter
  {
    get
    {
      Vector3[] localCorners = this.localCorners;
      return Vector3.Lerp(localCorners[0], localCorners[2], 0.5f);
    }
  }

  public override Vector3[] worldCorners
  {
    get
    {
      Vector2 pivotOffset = this.pivotOffset;
      float x1 = -pivotOffset.x * (float) this.mWidth;
      float y1 = -pivotOffset.y * (float) this.mHeight;
      float x2 = x1 + (float) this.mWidth;
      float y2 = y1 + (float) this.mHeight;
      Transform cachedTransform = this.cachedTransform;
      this.mCorners[0] = cachedTransform.TransformPoint(x1, y1, 0.0f);
      this.mCorners[1] = cachedTransform.TransformPoint(x1, y2, 0.0f);
      this.mCorners[2] = cachedTransform.TransformPoint(x2, y2, 0.0f);
      this.mCorners[3] = cachedTransform.TransformPoint(x2, y1, 0.0f);
      return this.mCorners;
    }
  }

  public Vector3 worldCenter => this.cachedTransform.TransformPoint(this.localCenter);

  public virtual Vector4 drawingDimensions
  {
    get
    {
      Vector2 pivotOffset = this.pivotOffset;
      float a1 = -pivotOffset.x * (float) this.mWidth;
      float a2 = -pivotOffset.y * (float) this.mHeight;
      float b1 = a1 + (float) this.mWidth;
      float b2 = a2 + (float) this.mHeight;
      return new Vector4((double) this.mDrawRegion.x == 0.0 ? a1 : Mathf.Lerp(a1, b1, this.mDrawRegion.x), (double) this.mDrawRegion.y == 0.0 ? a2 : Mathf.Lerp(a2, b2, this.mDrawRegion.y), (double) this.mDrawRegion.z == 1.0 ? b1 : Mathf.Lerp(a1, b1, this.mDrawRegion.z), (double) this.mDrawRegion.w == 1.0 ? b2 : Mathf.Lerp(a2, b2, this.mDrawRegion.w));
    }
  }

  public virtual Material material
  {
    get => this.mMat;
    set
    {
      if (!((UnityEngine.Object) this.mMat != (UnityEngine.Object) value))
        return;
      this.RemoveFromPanel();
      this.mMat = value;
      this.MarkAsChanged();
    }
  }

  public virtual Texture mainTexture
  {
    get
    {
      Material material = this.material;
      return !((UnityEngine.Object) material != (UnityEngine.Object) null) ? (Texture) null : material.mainTexture;
    }
    set => throw new NotImplementedException(((object) this).GetType()?.ToString() + " has no mainTexture setter");
  }

  public virtual Shader shader
  {
    get
    {
      Material material = this.material;
      return !((UnityEngine.Object) material != (UnityEngine.Object) null) ? (Shader) null : material.shader;
    }
    set => throw new NotImplementedException(((object) this).GetType()?.ToString() + " has no shader setter");
  }

  [Obsolete("There is no relative scale anymore. Widgets now have width and height instead")]
  public Vector2 relativeSize => Vector2.one;

  public bool hasBoxCollider => (UnityEngine.Object) (this.GetComponent<Collider>() as BoxCollider) != (UnityEngine.Object) null || (UnityEngine.Object) this.GetComponent<BoxCollider2D>() != (UnityEngine.Object) null;

  public void SetDimensions(int w, int h)
  {
    if (this.mWidth == w && this.mHeight == h)
      return;
    this.mWidth = w;
    this.mHeight = h;
    if (this.keepAspectRatio == UIWidget.AspectRatioSource.BasedOnWidth)
      this.mHeight = Mathf.RoundToInt((float) this.mWidth / this.aspectRatio);
    else if (this.keepAspectRatio == UIWidget.AspectRatioSource.BasedOnHeight)
      this.mWidth = Mathf.RoundToInt((float) this.mHeight * this.aspectRatio);
    else if (this.keepAspectRatio == UIWidget.AspectRatioSource.Free)
      this.aspectRatio = (float) this.mWidth / (float) this.mHeight;
    this.mMoved = true;
    if (this.autoResizeBoxCollider)
      this.ResizeCollider();
    this.MarkAsChanged();
  }

  public override Vector3[] GetSides(Transform relativeTo)
  {
    Vector2 pivotOffset = this.pivotOffset;
    float x1 = -pivotOffset.x * (float) this.mWidth;
    float y1 = -pivotOffset.y * (float) this.mHeight;
    float x2 = x1 + (float) this.mWidth;
    float y2 = y1 + (float) this.mHeight;
    float x3 = (float) (((double) x1 + (double) x2) * 0.5);
    float y3 = (float) (((double) y1 + (double) y2) * 0.5);
    Transform cachedTransform = this.cachedTransform;
    this.mCorners[0] = cachedTransform.TransformPoint(x1, y3, 0.0f);
    this.mCorners[1] = cachedTransform.TransformPoint(x3, y2, 0.0f);
    this.mCorners[2] = cachedTransform.TransformPoint(x2, y3, 0.0f);
    this.mCorners[3] = cachedTransform.TransformPoint(x3, y1, 0.0f);
    if ((UnityEngine.Object) relativeTo != (UnityEngine.Object) null)
    {
      for (int index = 0; index < 4; ++index)
        this.mCorners[index] = relativeTo.InverseTransformPoint(this.mCorners[index]);
    }
    return this.mCorners;
  }

  public override float CalculateFinalAlpha(int frameID)
  {
    if (this.mAlphaFrameID != frameID)
    {
      this.mAlphaFrameID = frameID;
      this.UpdateFinalAlpha(frameID);
    }
    return this.finalAlpha;
  }

  protected void UpdateFinalAlpha(int frameID)
  {
    if (!this.mIsVisibleByAlpha || !this.mIsInFront)
    {
      this.finalAlpha = 0.0f;
    }
    else
    {
      UIRect parent = this.parent;
      this.finalAlpha = (UnityEngine.Object) parent != (UnityEngine.Object) null ? parent.CalculateFinalAlpha(frameID) * this.mColor.a : this.mColor.a;
    }
  }

  public override void Invalidate(bool includeChildren)
  {
    this.mChanged = true;
    this.mAlphaFrameID = -1;
    if (!((UnityEngine.Object) this.panel != (UnityEngine.Object) null))
      return;
    bool visibleByPanel = !this.hideIfOffScreen && !this.panel.hasCumulativeClipping || this.panel.IsVisible(this);
    this.UpdateVisibility((double) this.CalculateCumulativeAlpha(Time.frameCount) > 1.0 / 1000.0, visibleByPanel);
    this.UpdateFinalAlpha(Time.frameCount);
    if (!includeChildren)
      return;
    base.Invalidate(true);
  }

  public float CalculateCumulativeAlpha(int frameID)
  {
    UIRect parent = this.parent;
    return !((UnityEngine.Object) parent != (UnityEngine.Object) null) ? this.mColor.a : parent.CalculateFinalAlpha(frameID) * this.mColor.a;
  }

  public override void SetRect(float x, float y, float width, float height)
  {
    Vector2 pivotOffset = this.pivotOffset;
    float num1 = Mathf.Lerp(x, x + width, pivotOffset.x);
    float num2 = Mathf.Lerp(y, y + height, pivotOffset.y);
    int num3 = Mathf.FloorToInt(width + 0.5f);
    int num4 = Mathf.FloorToInt(height + 0.5f);
    if ((double) pivotOffset.x == 0.5)
      num3 = num3 >> 1 << 1;
    if ((double) pivotOffset.y == 0.5)
      num4 = num4 >> 1 << 1;
    Transform cachedTransform = this.cachedTransform;
    Vector3 localPosition = cachedTransform.localPosition with
    {
      x = Mathf.Floor(num1 + 0.5f),
      y = Mathf.Floor(num2 + 0.5f)
    };
    if (num3 < this.minWidth)
      num3 = this.minWidth;
    if (num4 < this.minHeight)
      num4 = this.minHeight;
    cachedTransform.localPosition = localPosition;
    this.width = num3;
    this.height = num4;
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

  public void ResizeCollider()
  {
    BoxCollider component = this.GetComponent<BoxCollider>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      NGUITools.UpdateWidgetCollider(this, component);
    else
      NGUITools.UpdateWidgetCollider(this, this.GetComponent<BoxCollider2D>());
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static int FullCompareFunc(UIWidget left, UIWidget right)
  {
    int num = UIPanel.CompareFunc(left.panel, right.panel);
    return num != 0 ? num : UIWidget.PanelCompareFunc(left, right);
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static int PanelCompareFunc(UIWidget left, UIWidget right)
  {
    if (left.mDepth < right.mDepth)
      return -1;
    if (left.mDepth > right.mDepth)
      return 1;
    Material material1 = left.material;
    Material material2 = right.material;
    if ((UnityEngine.Object) material1 == (UnityEngine.Object) material2)
      return 0;
    return (UnityEngine.Object) material1 == (UnityEngine.Object) null || !((UnityEngine.Object) material2 == (UnityEngine.Object) null) && material1.GetInstanceID() >= material2.GetInstanceID() ? 1 : -1;
  }

  public Bounds CalculateBounds() => this.CalculateBounds((Transform) null);

  public Bounds CalculateBounds(Transform relativeParent)
  {
    if ((UnityEngine.Object) relativeParent == (UnityEngine.Object) null)
    {
      Vector3[] localCorners = this.localCorners;
      Bounds bounds = new Bounds(localCorners[0], Vector3.zero);
      for (int index = 1; index < 4; ++index)
        bounds.Encapsulate(localCorners[index]);
      return bounds;
    }
    Matrix4x4 worldToLocalMatrix = relativeParent.worldToLocalMatrix;
    Vector3[] worldCorners = this.worldCorners;
    Bounds bounds1 = new Bounds(worldToLocalMatrix.MultiplyPoint3x4(worldCorners[0]), Vector3.zero);
    for (int index = 1; index < 4; ++index)
      bounds1.Encapsulate(worldToLocalMatrix.MultiplyPoint3x4(worldCorners[index]));
    return bounds1;
  }

  public void SetDirty()
  {
    if ((UnityEngine.Object) this.drawCall != (UnityEngine.Object) null)
    {
      this.drawCall.isDirty = true;
    }
    else
    {
      if (!this.isVisible || !this.hasVertices)
        return;
      this.CreatePanel();
    }
  }

  public void RemoveFromPanel()
  {
    if ((UnityEngine.Object) this.panel != (UnityEngine.Object) null)
    {
      this.panel.RemoveWidget(this);
      this.panel = (UIPanel) null;
    }
    this.drawCall = (UIDrawCall) null;
  }

  public virtual void MarkAsChanged()
  {
    if (!NGUITools.GetActive((Behaviour) this))
      return;
    this.mChanged = true;
    if (!((UnityEngine.Object) this.panel != (UnityEngine.Object) null) || !this.enabled || !NGUITools.GetActive(this.gameObject) || this.mPlayMode)
      return;
    this.SetDirty();
    this.CheckLayer();
  }

  public UIPanel CreatePanel()
  {
    if (this.mStarted && (UnityEngine.Object) this.panel == (UnityEngine.Object) null && this.enabled && NGUITools.GetActive(this.gameObject))
    {
      this.panel = UIPanel.Find(this.cachedTransform, true, this.cachedGameObject.layer);
      if ((UnityEngine.Object) this.panel != (UnityEngine.Object) null)
      {
        this.mParentFound = false;
        this.panel.AddWidget(this);
        this.CheckLayer();
        this.Invalidate(true);
      }
    }
    return this.panel;
  }

  public void CheckLayer()
  {
    if (!((UnityEngine.Object) this.panel != (UnityEngine.Object) null) || this.panel.gameObject.layer == this.gameObject.layer)
      return;
    UnityEngine.Debug.LogWarning((object) "You can't place widgets on a layer different than the UIPanel that manages them.\nIf you want to move widgets to a different layer, parent them to a new panel instead.", (UnityEngine.Object) this);
    this.gameObject.layer = this.panel.gameObject.layer;
  }

  public override void ParentHasChanged()
  {
    base.ParentHasChanged();
    if (!((UnityEngine.Object) this.panel != (UnityEngine.Object) null) || !((UnityEngine.Object) this.panel != (UnityEngine.Object) UIPanel.Find(this.cachedTransform, true, this.cachedGameObject.layer)))
      return;
    this.RemoveFromPanel();
    this.CreatePanel();
  }

  protected override void Awake()
  {
    base.Awake();
    this.mPlayMode = Application.isPlaying;
  }

  protected override void OnInit()
  {
    base.OnInit();
    this.RemoveFromPanel();
    this.mMoved = true;
    this.Update();
  }

  protected virtual void UpgradeFrom265()
  {
    Vector3 localScale = this.cachedTransform.localScale;
    this.mWidth = Mathf.Abs(Mathf.RoundToInt(localScale.x));
    this.mHeight = Mathf.Abs(Mathf.RoundToInt(localScale.y));
    NGUITools.UpdateWidgetCollider(this.gameObject, true);
  }

  protected override void OnStart() => this.CreatePanel();

  protected override void OnAnchor()
  {
    Transform cachedTransform = this.cachedTransform;
    Transform parent = cachedTransform.parent;
    Vector3 localPosition = cachedTransform.localPosition;
    Vector2 pivotOffset = this.pivotOffset;
    float a1;
    float b1;
    float a2;
    float b2;
    if ((UnityEngine.Object) this.leftAnchor.target == (UnityEngine.Object) this.bottomAnchor.target && (UnityEngine.Object) this.leftAnchor.target == (UnityEngine.Object) this.rightAnchor.target && (UnityEngine.Object) this.leftAnchor.target == (UnityEngine.Object) this.topAnchor.target)
    {
      Vector3[] sides = this.leftAnchor.GetSides(parent);
      if (sides != null)
      {
        a1 = NGUIMath.Lerp(sides[0].x, sides[2].x, this.leftAnchor.relative) + (float) this.leftAnchor.absolute;
        b1 = NGUIMath.Lerp(sides[0].x, sides[2].x, this.rightAnchor.relative) + (float) this.rightAnchor.absolute;
        a2 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.bottomAnchor.relative) + (float) this.bottomAnchor.absolute;
        b2 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.topAnchor.relative) + (float) this.topAnchor.absolute;
        this.mIsInFront = true;
      }
      else
      {
        Vector3 localPos = this.GetLocalPos(this.leftAnchor, parent);
        a1 = localPos.x + (float) this.leftAnchor.absolute;
        a2 = localPos.y + (float) this.bottomAnchor.absolute;
        b1 = localPos.x + (float) this.rightAnchor.absolute;
        b2 = localPos.y + (float) this.topAnchor.absolute;
        this.mIsInFront = !this.hideIfOffScreen || (double) localPos.z >= 0.0;
      }
    }
    else
    {
      this.mIsInFront = true;
      if ((bool) (UnityEngine.Object) this.leftAnchor.target)
      {
        Vector3[] sides = this.leftAnchor.GetSides(parent);
        a1 = sides == null ? this.GetLocalPos(this.leftAnchor, parent).x + (float) this.leftAnchor.absolute : NGUIMath.Lerp(sides[0].x, sides[2].x, this.leftAnchor.relative) + (float) this.leftAnchor.absolute;
      }
      else
        a1 = localPosition.x - pivotOffset.x * (float) this.mWidth;
      if ((bool) (UnityEngine.Object) this.rightAnchor.target)
      {
        Vector3[] sides = this.rightAnchor.GetSides(parent);
        b1 = sides == null ? this.GetLocalPos(this.rightAnchor, parent).x + (float) this.rightAnchor.absolute : NGUIMath.Lerp(sides[0].x, sides[2].x, this.rightAnchor.relative) + (float) this.rightAnchor.absolute;
      }
      else
        b1 = localPosition.x - pivotOffset.x * (float) this.mWidth + (float) this.mWidth;
      if ((bool) (UnityEngine.Object) this.bottomAnchor.target)
      {
        Vector3[] sides = this.bottomAnchor.GetSides(parent);
        a2 = sides == null ? this.GetLocalPos(this.bottomAnchor, parent).y + (float) this.bottomAnchor.absolute : NGUIMath.Lerp(sides[3].y, sides[1].y, this.bottomAnchor.relative) + (float) this.bottomAnchor.absolute;
      }
      else
        a2 = localPosition.y - pivotOffset.y * (float) this.mHeight;
      if ((bool) (UnityEngine.Object) this.topAnchor.target)
      {
        Vector3[] sides = this.topAnchor.GetSides(parent);
        b2 = sides == null ? this.GetLocalPos(this.topAnchor, parent).y + (float) this.topAnchor.absolute : NGUIMath.Lerp(sides[3].y, sides[1].y, this.topAnchor.relative) + (float) this.topAnchor.absolute;
      }
      else
        b2 = localPosition.y - pivotOffset.y * (float) this.mHeight + (float) this.mHeight;
    }
    Vector3 vector3 = new Vector3(Mathf.Lerp(a1, b1, pivotOffset.x), Mathf.Lerp(a2, b2, pivotOffset.y), localPosition.z);
    vector3.x = Mathf.Round(vector3.x);
    vector3.y = Mathf.Round(vector3.y);
    int minWidth = Mathf.FloorToInt((float) ((double) b1 - (double) a1 + 0.5));
    int minHeight = Mathf.FloorToInt((float) ((double) b2 - (double) a2 + 0.5));
    if (this.keepAspectRatio != UIWidget.AspectRatioSource.Free && (double) this.aspectRatio != 0.0)
    {
      if (this.keepAspectRatio == UIWidget.AspectRatioSource.BasedOnHeight)
        minWidth = Mathf.RoundToInt((float) minHeight * this.aspectRatio);
      else
        minHeight = Mathf.RoundToInt((float) minWidth / this.aspectRatio);
    }
    if (minWidth < this.minWidth)
      minWidth = this.minWidth;
    if (minHeight < this.minHeight)
      minHeight = this.minHeight;
    if ((double) Vector3.SqrMagnitude(localPosition - vector3) > 1.0 / 1000.0)
    {
      this.cachedTransform.localPosition = vector3;
      if (this.mIsInFront)
        this.mChanged = true;
    }
    if (this.mWidth == minWidth && this.mHeight == minHeight)
      return;
    this.mWidth = minWidth;
    this.mHeight = minHeight;
    if (this.mIsInFront)
      this.mChanged = true;
    if (!this.autoResizeBoxCollider)
      return;
    this.ResizeCollider();
  }

  protected override void OnUpdate()
  {
    if (!((UnityEngine.Object) this.panel == (UnityEngine.Object) null))
      return;
    this.CreatePanel();
  }

  private void OnApplicationPause(bool paused)
  {
    if (paused)
      return;
    this.MarkAsChanged();
  }

  protected override void OnDisable()
  {
    this.RemoveFromPanel();
    base.OnDisable();
  }

  private void OnDestroy() => this.RemoveFromPanel();

  public bool UpdateVisibility(bool visibleByAlpha, bool visibleByPanel)
  {
    if (this.mIsVisibleByAlpha == visibleByAlpha && this.mIsVisibleByPanel == visibleByPanel)
      return false;
    this.mChanged = true;
    this.mIsVisibleByAlpha = visibleByAlpha;
    this.mIsVisibleByPanel = visibleByPanel;
    return true;
  }

  public bool UpdateTransform(int frame)
  {
    Transform cachedTransform = this.cachedTransform;
    this.mPlayMode = Application.isPlaying;
    if (this.mMoved)
    {
      this.mMoved = true;
      this.mMatrixFrame = -1;
      cachedTransform.hasChanged = false;
      Vector2 pivotOffset = this.pivotOffset;
      float x1 = -pivotOffset.x * (float) this.mWidth;
      float y1 = -pivotOffset.y * (float) this.mHeight;
      float x2 = x1 + (float) this.mWidth;
      float y2 = y1 + (float) this.mHeight;
      this.mOldV0 = this.panel.worldToLocal.MultiplyPoint3x4(cachedTransform.TransformPoint(x1, y1, 0.0f));
      this.mOldV1 = this.panel.worldToLocal.MultiplyPoint3x4(cachedTransform.TransformPoint(x2, y2, 0.0f));
    }
    else if (!this.panel.widgetsAreStatic && cachedTransform.hasChanged)
    {
      this.mMatrixFrame = -1;
      cachedTransform.hasChanged = false;
      Vector2 pivotOffset = this.pivotOffset;
      float x3 = -pivotOffset.x * (float) this.mWidth;
      float y3 = -pivotOffset.y * (float) this.mHeight;
      float x4 = x3 + (float) this.mWidth;
      float y4 = y3 + (float) this.mHeight;
      Vector3 vector3_1 = this.panel.worldToLocal.MultiplyPoint3x4(cachedTransform.TransformPoint(x3, y3, 0.0f));
      Vector3 vector3_2 = this.panel.worldToLocal.MultiplyPoint3x4(cachedTransform.TransformPoint(x4, y4, 0.0f));
      if ((double) Vector3.SqrMagnitude(this.mOldV0 - vector3_1) > 9.9999999747524271E-07 || (double) Vector3.SqrMagnitude(this.mOldV1 - vector3_2) > 9.9999999747524271E-07)
      {
        this.mMoved = true;
        this.mOldV0 = vector3_1;
        this.mOldV1 = vector3_2;
      }
    }
    if (this.mMoved && this.onChange != null)
      this.onChange();
    return this.mMoved || this.mChanged;
  }

  public bool UpdateGeometry(int frame)
  {
    float finalAlpha = this.CalculateFinalAlpha(frame);
    if (this.mIsVisibleByAlpha && (double) this.mLastAlpha != (double) finalAlpha)
      this.mChanged = true;
    this.mLastAlpha = finalAlpha;
    if (this.mChanged)
    {
      if (this.mIsVisibleByAlpha && (double) finalAlpha > 1.0 / 1000.0 && (UnityEngine.Object) this.shader != (UnityEngine.Object) null)
      {
        bool hasVertices = this.geometry.hasVertices;
        if (this.fillGeometry)
        {
          this.geometry.Clear();
          this.OnFill(this.geometry.verts, this.geometry.uvs, this.geometry.cols);
        }
        if (this.geometry.hasVertices)
        {
          if (this.mMatrixFrame != frame)
          {
            this.mLocalToPanel = this.panel.worldToLocal * this.cachedTransform.localToWorldMatrix;
            this.mMatrixFrame = frame;
          }
          this.geometry.ApplyTransform(this.mLocalToPanel, this.panel.generateNormals);
          this.mMoved = false;
          this.mChanged = false;
          return true;
        }
        this.mChanged = false;
        return hasVertices;
      }
      if (this.geometry.hasVertices)
      {
        if (this.fillGeometry)
          this.geometry.Clear();
        this.mMoved = false;
        this.mChanged = false;
        return true;
      }
    }
    else if (this.mMoved && this.geometry.hasVertices)
    {
      if (this.mMatrixFrame != frame)
      {
        this.mLocalToPanel = this.panel.worldToLocal * this.cachedTransform.localToWorldMatrix;
        this.mMatrixFrame = frame;
      }
      this.geometry.ApplyTransform(this.mLocalToPanel, this.panel.generateNormals);
      this.mMoved = false;
      this.mChanged = false;
      return true;
    }
    this.mMoved = false;
    this.mChanged = false;
    return false;
  }

  public void WriteToBuffers(
    List<Vector3> v,
    List<Vector2> u,
    List<Color> c,
    List<Vector3> n,
    List<Vector4> t,
    List<Vector4> u2)
  {
    this.geometry.WriteToBuffers(v, u, c, n, t, u2);
  }

  public virtual void MakePixelPerfect()
  {
    Vector3 localPosition = this.cachedTransform.localPosition;
    localPosition.z = Mathf.Round(localPosition.z);
    localPosition.x = Mathf.Round(localPosition.x);
    localPosition.y = Mathf.Round(localPosition.y);
    this.cachedTransform.localPosition = localPosition;
    Vector3 localScale = this.cachedTransform.localScale;
    this.cachedTransform.localScale = new Vector3(Mathf.Sign(localScale.x), Mathf.Sign(localScale.y), 1f);
  }

  public virtual int minWidth => 2;

  public virtual int minHeight => 2;

  public virtual Vector4 border
  {
    get => Vector4.zero;
    set
    {
    }
  }

  public virtual void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
  {
  }

  [DoNotObfuscateNGUI]
  public enum Pivot
  {
    TopLeft,
    Top,
    TopRight,
    Left,
    Center,
    Right,
    BottomLeft,
    Bottom,
    BottomRight,
  }

  public delegate void OnDimensionsChanged();

  public delegate void OnPostFillCallback(
    UIWidget widget,
    int bufferOffset,
    List<Vector3> verts,
    List<Vector2> uvs,
    List<Color> cols);

  [DoNotObfuscateNGUI]
  public enum AspectRatioSource
  {
    Free,
    BasedOnWidth,
    BasedOnHeight,
  }

  public delegate bool HitCheck(Vector3 worldPos);
}
