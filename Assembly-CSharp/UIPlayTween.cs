// Decompiled with JetBrains decompiler
// Type: UIPlayTween
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using AnimationOrTween;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Play Tween")]
public class UIPlayTween : MonoBehaviour
{
  public static UIPlayTween current;
  public GameObject tweenTarget;
  public int tweenGroup;
  public AnimationOrTween.Trigger trigger;
  public AnimationOrTween.Direction playDirection = AnimationOrTween.Direction.Forward;
  public bool resetOnPlay;
  public bool resetIfDisabled;
  public EnableCondition ifDisabledOnPlay;
  public DisableCondition disableWhenFinished;
  public bool includeChildren;
  public List<EventDelegate> onFinished = new List<EventDelegate>();
  [HideInInspector]
  [SerializeField]
  private GameObject eventReceiver;
  [HideInInspector]
  [SerializeField]
  private string callWhenFinished;
  private UITweener[] mTweens;
  private bool mStarted;
  private int mActive;
  private bool mActivated;

  private void Awake()
  {
    if (!((Object) this.eventReceiver != (Object) null) || !EventDelegate.IsValid(this.onFinished))
      return;
    this.eventReceiver = (GameObject) null;
    this.callWhenFinished = (string) null;
  }

  private void Start()
  {
    this.mStarted = true;
    if (!((Object) this.tweenTarget == (Object) null))
      return;
    this.tweenTarget = this.gameObject;
  }

  private void OnEnable()
  {
    if (this.mStarted)
      this.OnHover(UICamera.IsHighlighted(this.gameObject));
    if (UICamera.currentTouch != null)
    {
      if (this.trigger == AnimationOrTween.Trigger.OnPress || this.trigger == AnimationOrTween.Trigger.OnPressTrue)
        this.mActivated = (Object) UICamera.currentTouch.pressed == (Object) this.gameObject;
      if (this.trigger == AnimationOrTween.Trigger.OnHover || this.trigger == AnimationOrTween.Trigger.OnHoverTrue)
        this.mActivated = (Object) UICamera.currentTouch.current == (Object) this.gameObject;
    }
    UIToggle component = this.GetComponent<UIToggle>();
    if (!((Object) component != (Object) null))
      return;
    EventDelegate.Add(component.onChange, new EventDelegate.Callback(this.OnToggle));
  }

  private void OnDisable()
  {
    UIToggle component = this.GetComponent<UIToggle>();
    if (!((Object) component != (Object) null))
      return;
    EventDelegate.Remove(component.onChange, new EventDelegate.Callback(this.OnToggle));
  }

  private void OnDragOver()
  {
    if (this.trigger != AnimationOrTween.Trigger.OnHover)
      return;
    this.OnHover(true);
  }

  private void OnHover(bool isOver)
  {
    if (!this.enabled || this.trigger != AnimationOrTween.Trigger.OnHover && !(this.trigger == AnimationOrTween.Trigger.OnHoverTrue & isOver) && (this.trigger != AnimationOrTween.Trigger.OnHoverFalse || isOver) || isOver == this.mActivated)
      return;
    if (!isOver && (Object) UICamera.hoveredObject != (Object) null && UICamera.hoveredObject.transform.IsChildOf(this.transform))
    {
      UICamera.onHover += new UICamera.BoolDelegate(this.CustomHoverListener);
      isOver = true;
      if (this.mActivated)
        return;
    }
    this.mActivated = isOver && this.trigger == AnimationOrTween.Trigger.OnHover;
    this.Play(isOver);
  }

  private void CustomHoverListener(GameObject go, bool isOver)
  {
    if (!(bool) (Object) this)
      return;
    GameObject gameObject = this.gameObject;
    if ((!(bool) (Object) gameObject || !(bool) (Object) go ? 0 : ((Object) go == (Object) gameObject ? 1 : (go.transform.IsChildOf(this.transform) ? 1 : 0))) != 0)
      return;
    this.OnHover(false);
    UICamera.onHover -= new UICamera.BoolDelegate(this.CustomHoverListener);
  }

  private void OnDragOut()
  {
    if (!this.enabled || !this.mActivated)
      return;
    this.mActivated = false;
    this.Play(false);
  }

  private void OnPress(bool isPressed)
  {
    if (!this.enabled || this.trigger != AnimationOrTween.Trigger.OnPress && !(this.trigger == AnimationOrTween.Trigger.OnPressTrue & isPressed) && (this.trigger != AnimationOrTween.Trigger.OnPressFalse || isPressed))
      return;
    this.mActivated = isPressed && this.trigger == AnimationOrTween.Trigger.OnPress;
    this.Play(isPressed);
  }

  private void OnClick()
  {
    if (!this.enabled || this.trigger != AnimationOrTween.Trigger.OnClick)
      return;
    this.Play(true);
  }

  private void OnDoubleClick()
  {
    if (!this.enabled || this.trigger != AnimationOrTween.Trigger.OnDoubleClick)
      return;
    this.Play(true);
  }

  private void OnSelect(bool isSelected)
  {
    if (!this.enabled || this.trigger != AnimationOrTween.Trigger.OnSelect && !(this.trigger == AnimationOrTween.Trigger.OnSelectTrue & isSelected) && (this.trigger != AnimationOrTween.Trigger.OnSelectFalse || isSelected))
      return;
    this.mActivated = isSelected && this.trigger == AnimationOrTween.Trigger.OnSelect;
    this.Play(isSelected);
  }

  private void OnToggle()
  {
    if (!this.enabled || (Object) UIToggle.current == (Object) null || this.trigger != AnimationOrTween.Trigger.OnActivate && (this.trigger != AnimationOrTween.Trigger.OnActivateTrue || !UIToggle.current.value) && (this.trigger != AnimationOrTween.Trigger.OnActivateFalse || UIToggle.current.value))
      return;
    this.Play(UIToggle.current.value);
  }

  private void Update()
  {
    if (this.disableWhenFinished == DisableCondition.DoNotDisable || this.mTweens == null)
      return;
    bool flag1 = true;
    bool flag2 = true;
    int index = 0;
    for (int length = this.mTweens.Length; index < length; ++index)
    {
      UITweener mTween = this.mTweens[index];
      if (mTween.tweenGroup == this.tweenGroup)
      {
        if (mTween.enabled)
        {
          flag1 = false;
          break;
        }
        if (mTween.direction != (AnimationOrTween.Direction) this.disableWhenFinished)
          flag2 = false;
      }
    }
    if (!flag1)
      return;
    if (flag2)
      NGUITools.SetActive(this.tweenTarget, false);
    this.mTweens = (UITweener[]) null;
  }

  public void Play() => this.Play(true);

  public void Play(bool forward)
  {
    this.mActive = 0;
    GameObject go = (Object) this.tweenTarget == (Object) null ? this.gameObject : this.tweenTarget;
    if (!NGUITools.GetActive(go))
    {
      if (this.ifDisabledOnPlay != EnableCondition.EnableThenPlay)
        return;
      NGUITools.SetActive(go, true);
    }
    this.mTweens = this.includeChildren ? go.GetComponentsInChildren<UITweener>() : go.GetComponents<UITweener>();
    if (this.mTweens.Length == 0)
    {
      if (this.disableWhenFinished == DisableCondition.DoNotDisable)
        return;
      NGUITools.SetActive(this.tweenTarget, false);
    }
    else
    {
      bool flag = false;
      if (this.playDirection == AnimationOrTween.Direction.Reverse)
        forward = !forward;
      int index = 0;
      for (int length = this.mTweens.Length; index < length; ++index)
      {
        UITweener mTween = this.mTweens[index];
        if (mTween.tweenGroup == this.tweenGroup)
        {
          if (!flag && !NGUITools.GetActive(go))
          {
            flag = true;
            NGUITools.SetActive(go, true);
          }
          ++this.mActive;
          if (this.playDirection == AnimationOrTween.Direction.Toggle)
          {
            EventDelegate.Add(mTween.onFinished, new EventDelegate.Callback(this.OnFinished), true);
            mTween.Toggle();
          }
          else
          {
            if (this.resetOnPlay || this.resetIfDisabled && !mTween.enabled)
            {
              mTween.Play(forward);
              mTween.ResetToBeginning();
            }
            EventDelegate.Add(mTween.onFinished, new EventDelegate.Callback(this.OnFinished), true);
            mTween.Play(forward);
          }
        }
      }
    }
  }

  private void OnFinished()
  {
    if (--this.mActive != 0 || !((Object) UIPlayTween.current == (Object) null))
      return;
    UIPlayTween.current = this;
    EventDelegate.Execute(this.onFinished);
    if ((Object) this.eventReceiver != (Object) null && !string.IsNullOrEmpty(this.callWhenFinished))
      this.eventReceiver.SendMessage(this.callWhenFinished, SendMessageOptions.DontRequireReceiver);
    this.eventReceiver = (GameObject) null;
    UIPlayTween.current = (UIPlayTween) null;
  }
}
