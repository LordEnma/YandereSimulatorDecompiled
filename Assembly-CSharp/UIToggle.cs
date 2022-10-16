// Decompiled with JetBrains decompiler
// Type: UIToggle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using AnimationOrTween;
using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Toggle")]
public class UIToggle : UIWidgetContainer
{
  public static BetterList<UIToggle> list = new BetterList<UIToggle>();
  public static UIToggle current;
  public int group;
  public UIWidget activeSprite;
  public bool invertSpriteState;
  public Animation activeAnimation;
  public Animator animator;
  public UITweener tween;
  public bool startsActive;
  public bool instantTween;
  public bool optionCanBeNone;
  public List<EventDelegate> onChange = new List<EventDelegate>();
  public UIToggle.Validate validator;
  [HideInInspector]
  [SerializeField]
  private UISprite checkSprite;
  [HideInInspector]
  [SerializeField]
  private Animation checkAnimation;
  [HideInInspector]
  [SerializeField]
  private GameObject eventReceiver;
  [HideInInspector]
  [SerializeField]
  private string functionName = "OnActivate";
  [HideInInspector]
  [SerializeField]
  private bool startsChecked;
  private bool mIsActive = true;
  private bool mStarted;

  public bool value
  {
    get => !this.mStarted ? this.startsActive : this.mIsActive;
    set
    {
      if (!this.mStarted)
      {
        this.startsActive = value;
      }
      else
      {
        if (!(this.group == 0 | value) && !this.optionCanBeNone && this.mStarted)
          return;
        this.Set(value);
      }
    }
  }

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
  public bool isChecked
  {
    get => this.value;
    set => this.value = value;
  }

  public static UIToggle GetActiveToggle(int group)
  {
    for (int index = 0; index < UIToggle.list.size; ++index)
    {
      UIToggle activeToggle = UIToggle.list.buffer[index];
      if ((UnityEngine.Object) activeToggle != (UnityEngine.Object) null && activeToggle.group == group && activeToggle.mIsActive)
        return activeToggle;
    }
    return (UIToggle) null;
  }

  private void OnEnable() => UIToggle.list.Add(this);

  private void OnDisable() => UIToggle.list.Remove(this);

  public void Start()
  {
    if (this.mStarted)
      return;
    if (this.startsChecked)
    {
      this.startsChecked = false;
      this.startsActive = true;
    }
    if (!Application.isPlaying)
    {
      if ((UnityEngine.Object) this.checkSprite != (UnityEngine.Object) null && (UnityEngine.Object) this.activeSprite == (UnityEngine.Object) null)
      {
        this.activeSprite = (UIWidget) this.checkSprite;
        this.checkSprite = (UISprite) null;
      }
      if ((UnityEngine.Object) this.checkAnimation != (UnityEngine.Object) null && (UnityEngine.Object) this.activeAnimation == (UnityEngine.Object) null)
      {
        this.activeAnimation = this.checkAnimation;
        this.checkAnimation = (Animation) null;
      }
      if (Application.isPlaying && (UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null)
        this.activeSprite.alpha = this.invertSpriteState ? (this.startsActive ? 0.0f : 1f) : (this.startsActive ? 1f : 0.0f);
      if (!EventDelegate.IsValid(this.onChange))
        return;
      this.eventReceiver = (GameObject) null;
      this.functionName = (string) null;
    }
    else
    {
      this.mIsActive = !this.startsActive;
      this.mStarted = true;
      bool instantTween = this.instantTween;
      this.instantTween = true;
      this.Set(this.startsActive);
      this.instantTween = instantTween;
    }
  }

  private void OnClick()
  {
    if (!this.enabled || !this.isColliderEnabled || UICamera.currentTouchID == -2)
      return;
    this.value = !this.value;
  }

  public void Set(bool state, bool notify = true)
  {
    if (this.validator != null && !this.validator(state))
      return;
    if (!this.mStarted)
    {
      this.mIsActive = state;
      this.startsActive = state;
      if (!((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null))
        return;
      this.activeSprite.alpha = this.invertSpriteState ? (state ? 0.0f : 1f) : (state ? 1f : 0.0f);
    }
    else
    {
      if (this.mIsActive == state)
        return;
      if (this.group != 0 & state)
      {
        int index = 0;
        int size = UIToggle.list.size;
        while (index < size)
        {
          UIToggle uiToggle = UIToggle.list.buffer[index];
          if ((UnityEngine.Object) uiToggle != (UnityEngine.Object) this && uiToggle.group == this.group)
            uiToggle.Set(false);
          if (UIToggle.list.size != size)
          {
            size = UIToggle.list.size;
            index = 0;
          }
          else
            ++index;
        }
      }
      this.mIsActive = state;
      if ((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null)
      {
        if (this.instantTween || !NGUITools.GetActive((Behaviour) this))
          this.activeSprite.alpha = this.invertSpriteState ? (this.mIsActive ? 0.0f : 1f) : (this.mIsActive ? 1f : 0.0f);
        else
          TweenAlpha.Begin(this.activeSprite.gameObject, 0.15f, this.invertSpriteState ? (this.mIsActive ? 0.0f : 1f) : (this.mIsActive ? 1f : 0.0f));
      }
      if (notify && (UnityEngine.Object) UIToggle.current == (UnityEngine.Object) null)
      {
        UIToggle current = UIToggle.current;
        UIToggle.current = this;
        if (EventDelegate.IsValid(this.onChange))
          EventDelegate.Execute(this.onChange);
        else if ((UnityEngine.Object) this.eventReceiver != (UnityEngine.Object) null && !string.IsNullOrEmpty(this.functionName))
          this.eventReceiver.SendMessage(this.functionName, (object) this.mIsActive, SendMessageOptions.DontRequireReceiver);
        UIToggle.current = current;
      }
      if ((UnityEngine.Object) this.animator != (UnityEngine.Object) null)
      {
        ActiveAnimation activeAnimation = ActiveAnimation.Play(this.animator, (string) null, state ? AnimationOrTween.Direction.Forward : AnimationOrTween.Direction.Reverse, EnableCondition.IgnoreDisabledState, DisableCondition.DoNotDisable);
        if (!((UnityEngine.Object) activeAnimation != (UnityEngine.Object) null) || !this.instantTween && NGUITools.GetActive((Behaviour) this))
          return;
        activeAnimation.Finish();
      }
      else if ((UnityEngine.Object) this.activeAnimation != (UnityEngine.Object) null)
      {
        ActiveAnimation activeAnimation = ActiveAnimation.Play(this.activeAnimation, (string) null, state ? AnimationOrTween.Direction.Forward : AnimationOrTween.Direction.Reverse, EnableCondition.IgnoreDisabledState, DisableCondition.DoNotDisable);
        if (!((UnityEngine.Object) activeAnimation != (UnityEngine.Object) null) || !this.instantTween && NGUITools.GetActive((Behaviour) this))
          return;
        activeAnimation.Finish();
      }
      else
      {
        if (!((UnityEngine.Object) this.tween != (UnityEngine.Object) null))
          return;
        bool active = NGUITools.GetActive((Behaviour) this);
        if (this.tween.tweenGroup != 0)
        {
          UITweener[] componentsInChildren = this.tween.GetComponentsInChildren<UITweener>(true);
          int index = 0;
          for (int length = componentsInChildren.Length; index < length; ++index)
          {
            UITweener uiTweener = componentsInChildren[index];
            if (uiTweener.tweenGroup == this.tween.tweenGroup)
            {
              uiTweener.Play(state);
              if (this.instantTween || !active)
                uiTweener.tweenFactor = state ? 1f : 0.0f;
            }
          }
        }
        else
        {
          this.tween.Play(state);
          if (!this.instantTween && active)
            return;
          this.tween.tweenFactor = state ? 1f : 0.0f;
        }
      }
    }
  }

  public delegate bool Validate(bool choice);
}
