// Decompiled with JetBrains decompiler
// Type: PromptSwapScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PromptSwapScript : MonoBehaviour
{
  public InputDeviceScript InputDevice;
  public UISprite MySprite;
  public UILabel MyLetter;
  public string KeyboardLetter = string.Empty;
  public string KeyboardName = string.Empty;
  public string GamepadName = string.Empty;

  private void Awake()
  {
    if (!((Object) this.InputDevice == (Object) null))
      return;
    this.InputDevice = Object.FindObjectOfType<InputDeviceScript>();
  }

  public void UpdateSpriteType(InputDeviceType deviceType)
  {
    if ((Object) this.InputDevice == (Object) null)
      this.InputDevice = Object.FindObjectOfType<InputDeviceScript>();
    if (deviceType == InputDeviceType.Gamepad)
    {
      this.MySprite.spriteName = this.GamepadName;
      if (!((Object) this.MyLetter != (Object) null))
        return;
      this.MyLetter.text = "";
    }
    else
    {
      this.MySprite.spriteName = this.KeyboardName;
      if (!((Object) this.MyLetter != (Object) null))
        return;
      this.MyLetter.text = this.KeyboardLetter;
    }
  }
}
