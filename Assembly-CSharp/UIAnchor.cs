// Decompiled with JetBrains decompiler
// Type: UIAnchor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Anchor")]
public class UIAnchor : MonoBehaviour
{
  public Camera uiCamera;
  public GameObject container;
  public UIAnchor.Side side = UIAnchor.Side.Center;
  public bool runOnlyOnce = true;
  public Vector2 relativeOffset = Vector2.zero;
  public Vector2 pixelOffset = Vector2.zero;
  [HideInInspector]
  [SerializeField]
  private UIWidget widgetContainer;
  private Transform mTrans;
  private Animation mAnim;
  private Rect mRect;
  private UIRoot mRoot;
  private bool mStarted;

  private void OnEnable()
  {
    this.mTrans = this.transform;
    this.mAnim = this.GetComponent<Animation>();
    UICamera.onScreenResize += new UICamera.OnScreenResize(this.ScreenSizeChanged);
  }

  private void OnDisable() => UICamera.onScreenResize -= new UICamera.OnScreenResize(this.ScreenSizeChanged);

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
    this.mRoot = NGUITools.FindInParents<UIRoot>(this.gameObject);
    if ((Object) this.uiCamera == (Object) null)
      this.uiCamera = NGUITools.FindCameraForLayer(this.gameObject.layer);
    this.Update();
    this.mStarted = true;
  }

  private void Update()
  {
    if ((Object) this.mAnim != (Object) null && this.mAnim.enabled && this.mAnim.isPlaying || (Object) this.mTrans == (Object) null)
      return;
    bool flag = false;
    UIWidget uiWidget = (Object) this.container == (Object) null ? (UIWidget) null : this.container.GetComponent<UIWidget>();
    UIPanel uiPanel = !((Object) this.container == (Object) null) || !((Object) uiWidget == (Object) null) ? this.container.GetComponent<UIPanel>() : (UIPanel) null;
    if ((Object) uiWidget != (Object) null)
    {
      Bounds bounds = uiWidget.CalculateBounds(this.container.transform.parent);
      this.mRect.x = bounds.min.x;
      this.mRect.y = bounds.min.y;
      this.mRect.width = bounds.size.x;
      this.mRect.height = bounds.size.y;
    }
    else if ((Object) uiPanel != (Object) null)
    {
      if (uiPanel.clipping == UIDrawCall.Clipping.None)
      {
        float num = (Object) this.mRoot != (Object) null ? (float) ((double) this.mRoot.activeHeight / (double) Screen.height * 0.5) : 0.5f;
        this.mRect.xMin = (float) -Screen.width * num;
        this.mRect.yMin = (float) -Screen.height * num;
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
      Transform parent = this.container.transform.parent;
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
      flag = true;
      this.mRect = this.uiCamera.pixelRect;
    }
    float x = (float) (((double) this.mRect.xMin + (double) this.mRect.xMax) * 0.5);
    float y = (float) (((double) this.mRect.yMin + (double) this.mRect.yMax) * 0.5);
    Vector3 position = new Vector3(x, y, 0.0f);
    if (this.side != UIAnchor.Side.Center)
    {
      position.x = this.side == UIAnchor.Side.Right || this.side == UIAnchor.Side.TopRight || this.side == UIAnchor.Side.BottomRight ? this.mRect.xMax : (this.side == UIAnchor.Side.Top || this.side == UIAnchor.Side.Center || this.side == UIAnchor.Side.Bottom ? x : this.mRect.xMin);
      position.y = this.side == UIAnchor.Side.Top || this.side == UIAnchor.Side.TopRight || this.side == UIAnchor.Side.TopLeft ? this.mRect.yMax : (this.side == UIAnchor.Side.Left || this.side == UIAnchor.Side.Center || this.side == UIAnchor.Side.Right ? y : this.mRect.yMin);
    }
    float width = this.mRect.width;
    float height = this.mRect.height;
    position.x += this.pixelOffset.x + this.relativeOffset.x * width;
    position.y += this.pixelOffset.y + this.relativeOffset.y * height;
    if (flag)
    {
      if (this.uiCamera.orthographic)
      {
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
      }
      position.z = this.uiCamera.WorldToScreenPoint(this.mTrans.position).z;
      position = this.uiCamera.ScreenToWorldPoint(position);
    }
    else
    {
      position.x = Mathf.Round(position.x);
      position.y = Mathf.Round(position.y);
      if ((Object) uiPanel != (Object) null)
        position = uiPanel.cachedTransform.TransformPoint(position);
      else if ((Object) this.container != (Object) null)
      {
        Transform parent = this.container.transform.parent;
        if ((Object) parent != (Object) null)
          position = parent.TransformPoint(position);
      }
      position.z = this.mTrans.position.z;
    }
    if (flag && this.uiCamera.orthographic && (Object) this.mTrans.parent != (Object) null)
    {
      position = this.mTrans.parent.InverseTransformPoint(position);
      position.x = (float) Mathf.RoundToInt(position.x);
      position.y = (float) Mathf.RoundToInt(position.y);
      if (this.mTrans.localPosition != position)
        this.mTrans.localPosition = position;
    }
    else if (this.mTrans.position != position)
      this.mTrans.position = position;
    if (!this.runOnlyOnce || !Application.isPlaying)
      return;
    this.enabled = false;
  }

  [DoNotObfuscateNGUI]
  public enum Side
  {
    BottomLeft,
    Left,
    TopLeft,
    Top,
    TopRight,
    Right,
    BottomRight,
    Bottom,
    Center,
  }
}
