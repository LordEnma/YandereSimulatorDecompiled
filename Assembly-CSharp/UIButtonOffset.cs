// Decompiled with JetBrains decompiler
// Type: UIButtonOffset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Offset")]
public class UIButtonOffset : MonoBehaviour
{
  public Transform tweenTarget;
  public Vector3 hover = Vector3.zero;
  public Vector3 pressed = new Vector3(2f, -2f);
  public float duration = 0.2f;
  [NonSerialized]
  private Vector3 mPos;
  [NonSerialized]
  private bool mStarted;
  [NonSerialized]
  private bool mPressed;

  private void Start()
  {
    if (this.mStarted)
      return;
    this.mStarted = true;
    if ((UnityEngine.Object) this.tweenTarget == (UnityEngine.Object) null)
      this.tweenTarget = this.transform;
    this.mPos = this.tweenTarget.localPosition;
  }

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.OnHover(UICamera.IsHighlighted(this.gameObject));
  }

  private void OnDisable()
  {
    if (!this.mStarted || !((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null))
      return;
    TweenPosition component = this.tweenTarget.GetComponent<TweenPosition>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    component.value = this.mPos;
    component.enabled = false;
  }

  private void OnPress(bool isPressed)
  {
    this.mPressed = isPressed;
    if (!this.enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, isPressed ? this.mPos + this.pressed : (UICamera.IsHighlighted(this.gameObject) ? this.mPos + this.hover : this.mPos)).method = UITweener.Method.EaseInOut;
  }

  private void OnHover(bool isOver)
  {
    if (!this.enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, isOver ? this.mPos + this.hover : this.mPos).method = UITweener.Method.EaseInOut;
  }

  private void OnDragOver()
  {
    if (!this.mPressed)
      return;
    TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, this.mPos + this.hover).method = UITweener.Method.EaseInOut;
  }

  private void OnDragOut()
  {
    if (!this.mPressed)
      return;
    TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, this.mPos).method = UITweener.Method.EaseInOut;
  }

  private void OnSelect(bool isSelected)
  {
    if (!this.enabled || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller)
      return;
    this.OnHover(isSelected);
  }
}
