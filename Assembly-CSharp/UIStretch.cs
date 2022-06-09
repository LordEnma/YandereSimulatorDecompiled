// Decompiled with JetBrains decompiler
// Type: UIStretch
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Stretch")]
public class UIStretch : MonoBehaviour
{
  public Camera uiCamera;
  public GameObject container;
  public UIStretch.Style style;
  public bool runOnlyOnce = true;
  public Vector2 relativeSize = Vector2.one;
  public Vector2 initialSize = Vector2.one;
  public Vector2 borderPadding = Vector2.zero;
  [HideInInspector]
  [SerializeField]
  private UIWidget widgetContainer;
  private Transform mTrans;
  private UIWidget mWidget;
  private UISprite mSprite;
  private UIPanel mPanel;
  private UIRoot mRoot;
  private Animation mAnim;
  private Rect mRect;
  private bool mStarted;

  private void Awake()
  {
    this.mAnim = this.GetComponent<Animation>();
    this.mRect = new Rect();
    this.mTrans = this.transform;
    this.mWidget = this.GetComponent<UIWidget>();
    this.mSprite = this.GetComponent<UISprite>();
    this.mPanel = this.GetComponent<UIPanel>();
    UICamera.onScreenResize += new UICamera.OnScreenResize(this.ScreenSizeChanged);
  }

  private void OnDestroy() => UICamera.onScreenResize -= new UICamera.OnScreenResize(this.ScreenSizeChanged);

  private void ScreenSizeChanged()
  {
    if (!this.mStarted || !this.runOnlyOnce)
      return;
    this.Update();
  }

  private void Start()
  {
    if ((Object) this.container == (Object) null && (Object) this.widgetContainer != (Object) null)
    {
      this.container = this.widgetContainer.gameObject;
      this.widgetContainer = (UIWidget) null;
    }
    if ((Object) this.uiCamera == (Object) null)
      this.uiCamera = NGUITools.FindCameraForLayer(this.gameObject.layer);
    this.mRoot = NGUITools.FindInParents<UIRoot>(this.gameObject);
    this.Update();
    this.mStarted = true;
  }

  private void Update()
  {
    if ((Object) this.mAnim != (Object) null && this.mAnim.isPlaying || this.style == UIStretch.Style.None)
      return;
    UIWidget uiWidget = (Object) this.container == (Object) null ? (UIWidget) null : this.container.GetComponent<UIWidget>();
    UIPanel uiPanel = !((Object) this.container == (Object) null) || !((Object) uiWidget == (Object) null) ? this.container.GetComponent<UIPanel>() : (UIPanel) null;
    float num1 = 1f;
    if ((Object) uiWidget != (Object) null)
    {
      Bounds bounds = uiWidget.CalculateBounds(this.transform.parent);
      this.mRect.x = bounds.min.x;
      this.mRect.y = bounds.min.y;
      this.mRect.width = bounds.size.x;
      this.mRect.height = bounds.size.y;
    }
    else if ((Object) uiPanel != (Object) null)
    {
      if (uiPanel.clipping == UIDrawCall.Clipping.None)
      {
        float num2 = (Object) this.mRoot != (Object) null ? (float) ((double) this.mRoot.activeHeight / (double) Screen.height * 0.5) : 0.5f;
        this.mRect.xMin = (float) -Screen.width * num2;
        this.mRect.yMin = (float) -Screen.height * num2;
        this.mRect.xMax = -this.mRect.xMin;
        this.mRect.yMax = -this.mRect.yMin;
      }
      else
      {
        Vector4 finalClipRegion = uiPanel.finalClipRegion;
        this.mRect.x = finalClipRegion.x - finalClipRegion.z * 0.5f;
        this.mRect.y = finalClipRegion.y - finalClipRegion.w * 0.5f;
        this.mRect.width = finalClipRegion.z;
        this.mRect.height = finalClipRegion.w;
      }
    }
    else if ((Object) this.container != (Object) null)
    {
      Transform parent = this.transform.parent;
      Bounds bounds = (Object) parent != (Object) null ? NGUIMath.CalculateRelativeWidgetBounds(parent, this.container.transform) : NGUIMath.CalculateRelativeWidgetBounds(this.container.transform);
      this.mRect.x = bounds.min.x;
      this.mRect.y = bounds.min.y;
      this.mRect.width = bounds.size.x;
      this.mRect.height = bounds.size.y;
    }
    else
    {
      if (!((Object) this.uiCamera != (Object) null))
        return;
      this.mRect = this.uiCamera.pixelRect;
      if ((Object) this.mRoot != (Object) null)
        num1 = this.mRoot.pixelSizeAdjustment;
    }
    float width = this.mRect.width;
    float height = this.mRect.height;
    if ((double) num1 != 1.0 && (double) height > 1.0)
    {
      float num3 = (float) this.mRoot.activeHeight / height;
      width *= num3;
      height *= num3;
    }
    Vector3 vector3 = (Object) this.mWidget != (Object) null ? new Vector3((float) this.mWidget.width, (float) this.mWidget.height) : this.mTrans.localScale;
    if (this.style == UIStretch.Style.BasedOnHeight)
    {
      vector3.x = this.relativeSize.x * height;
      vector3.y = this.relativeSize.y * height;
    }
    else if (this.style == UIStretch.Style.FillKeepingRatio)
    {
      if ((double) this.initialSize.x / (double) this.initialSize.y < (double) (width / height))
      {
        float num4 = width / this.initialSize.x;
        vector3.x = width;
        vector3.y = this.initialSize.y * num4;
      }
      else
      {
        float num5 = height / this.initialSize.y;
        vector3.x = this.initialSize.x * num5;
        vector3.y = height;
      }
    }
    else if (this.style == UIStretch.Style.FitInternalKeepingRatio)
    {
      if ((double) this.initialSize.x / (double) this.initialSize.y > (double) (width / height))
      {
        float num6 = width / this.initialSize.x;
        vector3.x = width;
        vector3.y = this.initialSize.y * num6;
      }
      else
      {
        float num7 = height / this.initialSize.y;
        vector3.x = this.initialSize.x * num7;
        vector3.y = height;
      }
    }
    else
    {
      if (this.style != UIStretch.Style.Vertical)
        vector3.x = this.relativeSize.x * width;
      if (this.style != UIStretch.Style.Horizontal)
        vector3.y = this.relativeSize.y * height;
    }
    if ((Object) this.mSprite != (Object) null)
    {
      float num8 = this.mSprite.atlas != null ? this.mSprite.pixelSize : 1f;
      vector3.x -= this.borderPadding.x * num8;
      vector3.y -= this.borderPadding.y * num8;
      if (this.style != UIStretch.Style.Vertical)
        this.mSprite.width = Mathf.RoundToInt(vector3.x);
      if (this.style != UIStretch.Style.Horizontal)
        this.mSprite.height = Mathf.RoundToInt(vector3.y);
      vector3 = Vector3.one;
    }
    else if ((Object) this.mWidget != (Object) null)
    {
      if (this.style != UIStretch.Style.Vertical)
        this.mWidget.width = Mathf.RoundToInt(vector3.x - this.borderPadding.x);
      if (this.style != UIStretch.Style.Horizontal)
        this.mWidget.height = Mathf.RoundToInt(vector3.y - this.borderPadding.y);
      vector3 = Vector3.one;
    }
    else if ((Object) this.mPanel != (Object) null)
    {
      Vector4 baseClipRegion = this.mPanel.baseClipRegion;
      if (this.style != UIStretch.Style.Vertical)
        baseClipRegion.z = vector3.x - this.borderPadding.x;
      if (this.style != UIStretch.Style.Horizontal)
        baseClipRegion.w = vector3.y - this.borderPadding.y;
      this.mPanel.baseClipRegion = baseClipRegion;
      vector3 = Vector3.one;
    }
    else
    {
      if (this.style != UIStretch.Style.Vertical)
        vector3.x -= this.borderPadding.x;
      if (this.style != UIStretch.Style.Horizontal)
        vector3.y -= this.borderPadding.y;
    }
    if (this.mTrans.localScale != vector3)
      this.mTrans.localScale = vector3;
    if (!this.runOnlyOnce || !Application.isPlaying)
      return;
    this.enabled = false;
  }

  [DoNotObfuscateNGUI]
  public enum Style
  {
    None,
    Horizontal,
    Vertical,
    Both,
    BasedOnHeight,
    FillKeepingRatio,
    FitInternalKeepingRatio,
  }
}
