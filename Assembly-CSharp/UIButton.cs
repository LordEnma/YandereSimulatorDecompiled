// Decompiled with JetBrains decompiler
// Type: UIButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button")]
public class UIButton : UIButtonColor
{
  public static UIButton current;
  public bool dragHighlight;
  public string hoverSprite;
  public string pressedSprite;
  public string disabledSprite;
  public UnityEngine.Sprite hoverSprite2D;
  public UnityEngine.Sprite pressedSprite2D;
  public UnityEngine.Sprite disabledSprite2D;
  public bool pixelSnap;
  public List<EventDelegate> onClick = new List<EventDelegate>();
  [NonSerialized]
  private UISprite mSprite;
  [NonSerialized]
  private UI2DSprite mSprite2D;
  [NonSerialized]
  private string mNormalSprite;
  [NonSerialized]
  private UnityEngine.Sprite mNormalSprite2D;

  public override bool isEnabled
  {
    get
    {
      if (!this.enabled)
        return false;
      Collider component1 = this.gameObject.GetComponent<Collider>();
      if ((bool) (UnityEngine.Object) component1 && component1.enabled)
        return true;
      Collider2D component2 = this.GetComponent<Collider2D>();
      return (bool) (UnityEngine.Object) component2 && component2.enabled;
    }
    set
    {
      if (this.isEnabled == value)
        return;
      Collider component1 = this.gameObject.GetComponent<Collider>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      {
        component1.enabled = value;
        foreach (UIButtonColor component2 in this.GetComponents<UIButton>())
          component2.SetState(value ? UIButtonColor.State.Normal : UIButtonColor.State.Disabled, false);
      }
      else
      {
        Collider2D component3 = this.GetComponent<Collider2D>();
        if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
        {
          component3.enabled = value;
          foreach (UIButtonColor component4 in this.GetComponents<UIButton>())
            component4.SetState(value ? UIButtonColor.State.Normal : UIButtonColor.State.Disabled, false);
        }
        else
          this.enabled = value;
      }
    }
  }

  public string normalSprite
  {
    get
    {
      if (!this.mInitDone)
        this.OnInit();
      return this.mNormalSprite;
    }
    set
    {
      if (!this.mInitDone)
        this.OnInit();
      if ((UnityEngine.Object) this.mSprite != (UnityEngine.Object) null && !string.IsNullOrEmpty(this.mNormalSprite) && this.mNormalSprite == this.mSprite.spriteName)
      {
        this.mNormalSprite = value;
        this.SetSprite(value);
        NGUITools.SetDirty((UnityEngine.Object) this.mSprite);
      }
      else
      {
        this.mNormalSprite = value;
        if (this.mState != UIButtonColor.State.Normal)
          return;
        this.SetSprite(value);
      }
    }
  }

  public UnityEngine.Sprite normalSprite2D
  {
    get
    {
      if (!this.mInitDone)
        this.OnInit();
      return this.mNormalSprite2D;
    }
    set
    {
      if (!this.mInitDone)
        this.OnInit();
      if ((UnityEngine.Object) this.mSprite2D != (UnityEngine.Object) null && (UnityEngine.Object) this.mNormalSprite2D == (UnityEngine.Object) this.mSprite2D.sprite2D)
      {
        this.mNormalSprite2D = value;
        this.SetSprite(value);
        NGUITools.SetDirty((UnityEngine.Object) this.mSprite);
      }
      else
      {
        this.mNormalSprite2D = value;
        if (this.mState != UIButtonColor.State.Normal)
          return;
        this.SetSprite(value);
      }
    }
  }

  protected override void OnInit()
  {
    base.OnInit();
    this.mSprite = this.mWidget as UISprite;
    this.mSprite2D = this.mWidget as UI2DSprite;
    if ((UnityEngine.Object) this.mSprite != (UnityEngine.Object) null)
      this.mNormalSprite = this.mSprite.spriteName;
    if (!((UnityEngine.Object) this.mSprite2D != (UnityEngine.Object) null))
      return;
    this.mNormalSprite2D = this.mSprite2D.sprite2D;
  }

  protected override void OnEnable()
  {
    if (this.isEnabled)
    {
      if (!this.mInitDone)
        return;
      this.OnHover((UnityEngine.Object) UICamera.hoveredObject == (UnityEngine.Object) this.gameObject);
    }
    else
      this.SetState(UIButtonColor.State.Disabled, true);
  }

  protected override void OnDragOver()
  {
    if (!this.isEnabled || !this.dragHighlight && !((UnityEngine.Object) UICamera.currentTouch.pressed == (UnityEngine.Object) this.gameObject))
      return;
    base.OnDragOver();
  }

  protected override void OnDragOut()
  {
    if (!this.isEnabled || !this.dragHighlight && !((UnityEngine.Object) UICamera.currentTouch.pressed == (UnityEngine.Object) this.gameObject))
      return;
    base.OnDragOut();
  }

  protected virtual void OnClick()
  {
    if (!((UnityEngine.Object) UIButton.current == (UnityEngine.Object) null) || !this.isEnabled || UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
      return;
    UIButton.current = this;
    EventDelegate.Execute(this.onClick);
    UIButton.current = (UIButton) null;
  }

  public override void SetState(UIButtonColor.State state, bool immediate)
  {
    base.SetState(state, immediate);
    if ((UnityEngine.Object) this.mSprite != (UnityEngine.Object) null)
    {
      switch (state)
      {
        case UIButtonColor.State.Normal:
          this.SetSprite(this.mNormalSprite);
          break;
        case UIButtonColor.State.Hover:
          this.SetSprite(string.IsNullOrEmpty(this.hoverSprite) ? this.mNormalSprite : this.hoverSprite);
          break;
        case UIButtonColor.State.Pressed:
          this.SetSprite(this.pressedSprite);
          break;
        case UIButtonColor.State.Disabled:
          this.SetSprite(this.disabledSprite);
          break;
      }
    }
    else
    {
      if (!((UnityEngine.Object) this.mSprite2D != (UnityEngine.Object) null))
        return;
      switch (state)
      {
        case UIButtonColor.State.Normal:
          this.SetSprite(this.mNormalSprite2D);
          break;
        case UIButtonColor.State.Hover:
          this.SetSprite((UnityEngine.Object) this.hoverSprite2D == (UnityEngine.Object) null ? this.mNormalSprite2D : this.hoverSprite2D);
          break;
        case UIButtonColor.State.Pressed:
          this.SetSprite(this.pressedSprite2D);
          break;
        case UIButtonColor.State.Disabled:
          this.SetSprite(this.disabledSprite2D);
          break;
      }
    }
  }

  protected void SetSprite(string sp)
  {
    if (!((UnityEngine.Object) this.mSprite != (UnityEngine.Object) null) || string.IsNullOrEmpty(sp) || !(this.mSprite.spriteName != sp))
      return;
    this.mSprite.spriteName = sp;
    if (!this.pixelSnap)
      return;
    this.mSprite.MakePixelPerfect();
  }

  protected void SetSprite(UnityEngine.Sprite sp)
  {
    if (!((UnityEngine.Object) sp != (UnityEngine.Object) null) || !((UnityEngine.Object) this.mSprite2D != (UnityEngine.Object) null) || !((UnityEngine.Object) this.mSprite2D.sprite2D != (UnityEngine.Object) sp))
      return;
    this.mSprite2D.sprite2D = sp;
    if (!this.pixelSnap)
      return;
    this.mSprite2D.MakePixelPerfect();
  }
}
