// Decompiled with JetBrains decompiler
// Type: UIButtonRotation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Rotation")]
public class UIButtonRotation : MonoBehaviour
{
  public Transform tweenTarget;
  public Vector3 hover = Vector3.zero;
  public Vector3 pressed = Vector3.zero;
  public float duration = 0.2f;
  private Quaternion mRot;
  private bool mStarted;

  private void Start()
  {
    if (this.mStarted)
      return;
    this.mStarted = true;
    if ((Object) this.tweenTarget == (Object) null)
      this.tweenTarget = this.transform;
    this.mRot = this.tweenTarget.localRotation;
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
    TweenRotation component = this.tweenTarget.GetComponent<TweenRotation>();
    if (!((Object) component != (Object) null))
      return;
    component.value = this.mRot;
    component.enabled = false;
  }

  private void OnPress(bool isPressed)
  {
    if (!this.enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenRotation.Begin(this.tweenTarget.gameObject, this.duration, isPressed ? this.mRot * Quaternion.Euler(this.pressed) : (UICamera.IsHighlighted(this.gameObject) ? this.mRot * Quaternion.Euler(this.hover) : this.mRot)).method = UITweener.Method.EaseInOut;
  }

  private void OnHover(bool isOver)
  {
    if (!this.enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenRotation.Begin(this.tweenTarget.gameObject, this.duration, isOver ? this.mRot * Quaternion.Euler(this.hover) : this.mRot).method = UITweener.Method.EaseInOut;
  }

  private void OnSelect(bool isSelected)
  {
    if (!this.enabled || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller)
      return;
    this.OnHover(isSelected);
  }
}
