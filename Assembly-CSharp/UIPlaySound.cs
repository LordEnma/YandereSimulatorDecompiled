// Decompiled with JetBrains decompiler
// Type: UIPlaySound
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Play Sound")]
public class UIPlaySound : MonoBehaviour
{
  public AudioClip audioClip;
  public UIPlaySound.Trigger trigger;
  [Range(0.0f, 1f)]
  public float volume = 1f;
  [Range(0.0f, 2f)]
  public float pitch = 1f;
  private bool mIsOver;

  private bool canPlay
  {
    get
    {
      if (!this.enabled)
        return false;
      UIButton component = this.GetComponent<UIButton>();
      return (Object) component == (Object) null || component.isEnabled;
    }
  }

  private void OnEnable()
  {
    if (this.trigger != UIPlaySound.Trigger.OnEnable)
      return;
    NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
  }

  private void OnDisable()
  {
    if (this.trigger != UIPlaySound.Trigger.OnDisable)
      return;
    NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
  }

  private void OnHover(bool isOver)
  {
    if (this.trigger == UIPlaySound.Trigger.OnMouseOver)
    {
      if (this.mIsOver == isOver)
        return;
      this.mIsOver = isOver;
    }
    if (!this.canPlay || (!isOver || this.trigger != UIPlaySound.Trigger.OnMouseOver) && (isOver || this.trigger != UIPlaySound.Trigger.OnMouseOut))
      return;
    NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
  }

  private void OnPress(bool isPressed)
  {
    if (this.trigger == UIPlaySound.Trigger.OnPress)
    {
      if (this.mIsOver == isPressed)
        return;
      this.mIsOver = isPressed;
    }
    if (!this.canPlay || (!isPressed || this.trigger != UIPlaySound.Trigger.OnPress) && (isPressed || this.trigger != UIPlaySound.Trigger.OnRelease))
      return;
    NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
  }

  private void OnClick()
  {
    if (!this.canPlay || this.trigger != UIPlaySound.Trigger.OnClick)
      return;
    NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
  }

  private void OnSelect(bool isSelected)
  {
    if (!this.canPlay || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller)
      return;
    this.OnHover(isSelected);
  }

  public void Play() => NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);

  [DoNotObfuscateNGUI]
  public enum Trigger
  {
    OnClick,
    OnMouseOver,
    OnMouseOut,
    OnPress,
    OnRelease,
    Custom,
    OnEnable,
    OnDisable,
  }
}
