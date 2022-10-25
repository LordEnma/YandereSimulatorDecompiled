// Decompiled with JetBrains decompiler
// Type: UIButtonColor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Button Color")]
public class UIButtonColor : UIWidgetContainer
{
  public GameObject tweenTarget;
  public Color hover = new Color(0.882352948f, 0.784313738f, 0.5882353f, 1f);
  public Color pressed = new Color(0.7176471f, 0.6392157f, 0.482352942f, 1f);
  public Color disabledColor = Color.grey;
  public float duration = 0.2f;
  [NonSerialized]
  protected Color mStartingColor;
  [NonSerialized]
  protected Color mDefaultColor;
  [NonSerialized]
  protected bool mInitDone;
  [NonSerialized]
  protected UIWidget mWidget;
  [NonSerialized]
  protected UIButtonColor.State mState;

  public UIButtonColor.State state
  {
    get => this.mState;
    set => this.SetState(value, false);
  }

  public Color defaultColor
  {
    get
    {
      if (!this.mInitDone)
        this.OnInit();
      return this.mDefaultColor;
    }
    set
    {
      if (!this.mInitDone)
        this.OnInit();
      this.mDefaultColor = value;
      UIButtonColor.State mState = this.mState;
      this.mState = UIButtonColor.State.Disabled;
      this.SetState(mState, false);
    }
  }

  public virtual bool isEnabled
  {
    get => this.enabled;
    set => this.enabled = value;
  }

  public void ResetDefaultColor() => this.defaultColor = this.mStartingColor;

  public void CacheDefaultColor()
  {
    if (this.mInitDone)
      return;
    this.OnInit();
  }

  private void Start()
  {
    if (!this.mInitDone)
      this.OnInit();
    if (this.isEnabled)
      return;
    this.SetState(UIButtonColor.State.Disabled, true);
  }

  protected virtual void OnInit()
  {
    this.mInitDone = true;
    if ((UnityEngine.Object) this.tweenTarget == (UnityEngine.Object) null && !Application.isPlaying)
      this.tweenTarget = this.gameObject;
    if ((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null)
      this.mWidget = this.tweenTarget.GetComponent<UIWidget>();
    if ((UnityEngine.Object) this.mWidget != (UnityEngine.Object) null)
    {
      this.mDefaultColor = this.mWidget.color;
      this.mStartingColor = this.mDefaultColor;
    }
    else
    {
      if (!((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null))
        return;
      Renderer component1 = this.tweenTarget.GetComponent<Renderer>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      {
        this.mDefaultColor = Application.isPlaying ? component1.material.color : component1.sharedMaterial.color;
        this.mStartingColor = this.mDefaultColor;
      }
      else
      {
        Light component2 = this.tweenTarget.GetComponent<Light>();
        if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
        {
          this.mDefaultColor = component2.color;
          this.mStartingColor = this.mDefaultColor;
        }
        else
        {
          this.tweenTarget = (GameObject) null;
          this.mInitDone = false;
        }
      }
    }
  }

  protected virtual void OnEnable()
  {
    if (this.mInitDone)
      this.OnHover(UICamera.IsHighlighted(this.gameObject));
    if (UICamera.currentTouch == null)
      return;
    if ((UnityEngine.Object) UICamera.currentTouch.pressed == (UnityEngine.Object) this.gameObject)
    {
      this.OnPress(true);
    }
    else
    {
      if (!((UnityEngine.Object) UICamera.currentTouch.current == (UnityEngine.Object) this.gameObject))
        return;
      this.OnHover(true);
    }
  }

  protected virtual void OnDisable()
  {
    if (!this.mInitDone || this.mState == UIButtonColor.State.Normal)
      return;
    this.SetState(UIButtonColor.State.Normal, true);
    if (!((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null))
      return;
    TweenColor component = this.tweenTarget.GetComponent<TweenColor>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    component.value = this.mDefaultColor;
    component.enabled = false;
  }

  protected virtual void OnHover(bool isOver)
  {
    if (!this.isEnabled)
      return;
    if (!this.mInitDone)
      this.OnInit();
    if (!((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null))
      return;
    this.SetState(isOver ? UIButtonColor.State.Hover : UIButtonColor.State.Normal, false);
  }

  protected virtual void OnPress(bool isPressed)
  {
    if (!this.isEnabled)
      return;
    if (!this.mInitDone)
      this.OnInit();
    if (!((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null))
      return;
    if (isPressed)
      this.SetState(UIButtonColor.State.Pressed, false);
    else if (UICamera.currentTouch != null && (UnityEngine.Object) UICamera.currentTouch.current == (UnityEngine.Object) this.gameObject)
    {
      switch (UICamera.currentScheme)
      {
        case UICamera.ControlScheme.Mouse:
          if ((UnityEngine.Object) UICamera.hoveredObject == (UnityEngine.Object) this.gameObject)
          {
            this.SetState(UIButtonColor.State.Hover, false);
            return;
          }
          break;
        case UICamera.ControlScheme.Controller:
          this.SetState(UIButtonColor.State.Hover, false);
          return;
      }
      this.SetState(UIButtonColor.State.Normal, false);
    }
    else
      this.SetState(UIButtonColor.State.Normal, false);
  }

  protected virtual void OnDragOver()
  {
    if (!this.isEnabled)
      return;
    if (!this.mInitDone)
      this.OnInit();
    if (!((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null))
      return;
    this.SetState(UIButtonColor.State.Pressed, false);
  }

  protected virtual void OnDragOut()
  {
    if (!this.isEnabled)
      return;
    if (!this.mInitDone)
      this.OnInit();
    if (!((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null))
      return;
    this.SetState(UIButtonColor.State.Normal, false);
  }

  public virtual void SetState(UIButtonColor.State state, bool instant)
  {
    if (!this.mInitDone)
    {
      this.mInitDone = true;
      this.OnInit();
    }
    if (this.mState == state)
      return;
    this.mState = state;
    this.UpdateColor(instant);
  }

  public void UpdateColor(bool instant)
  {
    if (!this.mInitDone || !((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null))
      return;
    TweenColor tweenColor;
    switch (this.mState)
    {
      case UIButtonColor.State.Hover:
        tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.hover);
        break;
      case UIButtonColor.State.Pressed:
        tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.pressed);
        break;
      case UIButtonColor.State.Disabled:
        tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.disabledColor);
        break;
      default:
        tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.mDefaultColor);
        break;
    }
    if (!instant || !((UnityEngine.Object) tweenColor != (UnityEngine.Object) null))
      return;
    tweenColor.value = tweenColor.to;
    tweenColor.enabled = false;
  }

  [DoNotObfuscateNGUI]
  public enum State
  {
    Normal,
    Hover,
    Pressed,
    Disabled,
  }
}
