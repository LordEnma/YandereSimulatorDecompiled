// Decompiled with JetBrains decompiler
// Type: UIButtonScale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Scale")]
public class UIButtonScale : MonoBehaviour
{
  public Transform tweenTarget;
  public Vector3 hover = new Vector3(1.1f, 1.1f, 1.1f);
  public Vector3 pressed = new Vector3(1.05f, 1.05f, 1.05f);
  public float duration = 0.2f;
  private Vector3 mScale;
  private bool mStarted;

  private void Start()
  {
    if (this.mStarted)
      return;
    this.mStarted = true;
    if ((Object) this.tweenTarget == (Object) null)
      this.tweenTarget = this.transform;
    this.mScale = this.tweenTarget.localScale;
  }

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.OnHover(UICamera.IsHighlighted(this.gameObject));
  }

  private void OnDisable()
  {
    if (!this.mStarted || !((Object) this.tweenTarget != (Object) null))
      return;
    TweenScale component = this.tweenTarget.GetComponent<TweenScale>();
    if (!((Object) component != (Object) null))
      return;
    component.value = this.mScale;
    component.enabled = false;
  }

  private void OnPress(bool isPressed)
  {
    if (!this.enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenScale.Begin(this.tweenTarget.gameObject, this.duration, isPressed ? Vector3.Scale(this.mScale, this.pressed) : (UICamera.IsHighlighted(this.gameObject) ? Vector3.Scale(this.mScale, this.hover) : this.mScale)).method = UITweener.Method.EaseInOut;
  }

  private void OnHover(bool isOver)
  {
    if (!this.enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenScale.Begin(this.tweenTarget.gameObject, this.duration, isOver ? Vector3.Scale(this.mScale, this.hover) : this.mScale).method = UITweener.Method.EaseInOut;
  }

  private void OnSelect(bool isSelected)
  {
    if (!this.enabled || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller)
      return;
    this.OnHover(isSelected);
  }
}
