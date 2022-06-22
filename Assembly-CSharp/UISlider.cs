// Decompiled with JetBrains decompiler
// Type: UISlider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/NGUI Slider")]
public class UISlider : UIProgressBar
{
  [HideInInspector]
  [SerializeField]
  private Transform foreground;
  [HideInInspector]
  [SerializeField]
  private float rawValue = 1f;
  [HideInInspector]
  [SerializeField]
  private UISlider.Direction direction = UISlider.Direction.Upgraded;
  [HideInInspector]
  [SerializeField]
  protected bool mInverted;

  public bool isColliderEnabled
  {
    get
    {
      Collider component1 = this.GetComponent<Collider>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        return component1.enabled;
      Collider2D component2 = this.GetComponent<Collider2D>();
      return (UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.enabled;
    }
  }

  [Obsolete("Use 'value' instead")]
  public float sliderValue
  {
    get => this.value;
    set => this.value = value;
  }

  [Obsolete("Use 'fillDirection' instead")]
  public bool inverted
  {
    get => this.isInverted;
    set
    {
    }
  }

  protected override void Upgrade()
  {
    if (this.direction == UISlider.Direction.Upgraded)
      return;
    this.mValue = this.rawValue;
    if ((UnityEngine.Object) this.foreground != (UnityEngine.Object) null)
      this.mFG = this.foreground.GetComponent<UIWidget>();
    if (this.direction == UISlider.Direction.Horizontal)
      this.mFill = this.mInverted ? UIProgressBar.FillDirection.RightToLeft : UIProgressBar.FillDirection.LeftToRight;
    else
      this.mFill = this.mInverted ? UIProgressBar.FillDirection.TopToBottom : UIProgressBar.FillDirection.BottomToTop;
    this.direction = UISlider.Direction.Upgraded;
  }

  protected override void OnStart()
  {
    UIEventListener uiEventListener1 = UIEventListener.Get(!((UnityEngine.Object) this.mBG != (UnityEngine.Object) null) || !((UnityEngine.Object) this.mBG.GetComponent<Collider>() != (UnityEngine.Object) null) && !((UnityEngine.Object) this.mBG.GetComponent<Collider2D>() != (UnityEngine.Object) null) ? this.gameObject : this.mBG.gameObject);
    uiEventListener1.onPress += new UIEventListener.BoolDelegate(this.OnPressBackground);
    uiEventListener1.onDrag += new UIEventListener.VectorDelegate(this.OnDragBackground);
    if (!((UnityEngine.Object) this.thumb != (UnityEngine.Object) null) || !((UnityEngine.Object) this.thumb.GetComponent<Collider>() != (UnityEngine.Object) null) && !((UnityEngine.Object) this.thumb.GetComponent<Collider2D>() != (UnityEngine.Object) null) || !((UnityEngine.Object) this.mFG == (UnityEngine.Object) null) && !((UnityEngine.Object) this.thumb != (UnityEngine.Object) this.mFG.cachedTransform))
      return;
    UIEventListener uiEventListener2 = UIEventListener.Get(this.thumb.gameObject);
    uiEventListener2.onPress += new UIEventListener.BoolDelegate(this.OnPressForeground);
    uiEventListener2.onDrag += new UIEventListener.VectorDelegate(this.OnDragForeground);
  }

  protected void OnPressBackground(GameObject go, bool isPressed)
  {
    if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    this.mCam = UICamera.currentCamera;
    this.value = this.ScreenToValue(UICamera.lastEventPosition);
    if (isPressed || this.onDragFinished == null)
      return;
    this.onDragFinished();
  }

  protected void OnDragBackground(GameObject go, Vector2 delta)
  {
    if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    this.mCam = UICamera.currentCamera;
    this.value = this.ScreenToValue(UICamera.lastEventPosition);
  }

  protected void OnPressForeground(GameObject go, bool isPressed)
  {
    if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    this.mCam = UICamera.currentCamera;
    if (isPressed)
    {
      this.mOffset = (UnityEngine.Object) this.mFG == (UnityEngine.Object) null ? 0.0f : this.value - this.ScreenToValue(UICamera.lastEventPosition);
    }
    else
    {
      if (this.onDragFinished == null)
        return;
      this.onDragFinished();
    }
  }

  protected void OnDragForeground(GameObject go, Vector2 delta)
  {
    if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    this.mCam = UICamera.currentCamera;
    this.value = this.mOffset + this.ScreenToValue(UICamera.lastEventPosition);
  }

  public override void OnPan(Vector2 delta)
  {
    if (!this.enabled || !this.isColliderEnabled)
      return;
    base.OnPan(delta);
  }

  private enum Direction
  {
    Horizontal,
    Vertical,
    Upgraded,
  }
}
