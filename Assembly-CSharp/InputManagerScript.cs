// Decompiled with JetBrains decompiler
// Type: InputManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
  public bool TappedUp;
  public bool TappedDown;
  public bool TappedRight;
  public bool TappedLeft;
  public bool DPadUp;
  public bool DPadDown;
  public bool DPadRight;
  public bool DPadLeft;
  public bool StickUp;
  public bool StickDown;
  public bool StickRight;
  public bool StickLeft;

  private void Update()
  {
    this.TappedUp = false;
    this.TappedDown = false;
    this.TappedRight = false;
    this.TappedLeft = false;
    if ((double) Input.GetAxisRaw("DpadY") > 0.5)
    {
      this.TappedUp = !this.DPadUp;
      this.DPadUp = true;
    }
    else if ((double) Input.GetAxisRaw("DpadY") < -0.5)
    {
      this.TappedDown = !this.DPadDown;
      this.DPadDown = true;
    }
    else
    {
      this.DPadUp = false;
      this.DPadDown = false;
    }
    if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
    {
      if ((double) Input.GetAxisRaw("Vertical") > 0.5)
      {
        this.TappedUp = !this.StickUp;
        this.StickUp = !this.TappedDown;
      }
      else if ((double) Input.GetAxisRaw("Vertical") < -0.5)
      {
        this.TappedDown = !this.StickDown;
        this.StickDown = !this.TappedUp;
      }
      else
      {
        this.StickUp = false;
        this.StickDown = false;
      }
    }
    if ((double) Input.GetAxisRaw("DpadX") > 0.5)
    {
      this.TappedRight = !this.DPadRight;
      this.DPadRight = true;
    }
    else if ((double) Input.GetAxisRaw("DpadX") < -0.5)
    {
      this.TappedLeft = !this.DPadLeft;
      this.DPadLeft = true;
    }
    else
    {
      this.DPadRight = false;
      this.DPadLeft = false;
    }
    if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
    {
      if ((double) Input.GetAxisRaw("Horizontal") > 0.5)
      {
        this.TappedRight = !this.StickRight;
        this.StickRight = true;
      }
      else if ((double) Input.GetAxisRaw("Horizontal") < -0.5)
      {
        this.TappedLeft = !this.StickLeft;
        this.StickLeft = true;
      }
      else
      {
        this.StickRight = false;
        this.StickLeft = false;
      }
    }
    if ((double) Input.GetAxisRaw("Horizontal") < 0.5 && (double) Input.GetAxisRaw("Horizontal") > -0.5 && (double) Input.GetAxisRaw("DpadX") < 0.5 && (double) Input.GetAxisRaw("DpadX") > -0.5)
    {
      this.TappedRight = false;
      this.TappedLeft = false;
    }
    if ((double) Input.GetAxisRaw("Vertical") < 0.5 && (double) Input.GetAxisRaw("Vertical") > -0.5 && (double) Input.GetAxisRaw("DpadY") < 0.5 && (double) Input.GetAxisRaw("DpadY") > -0.5)
    {
      this.TappedUp = false;
      this.TappedDown = false;
    }
    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
    {
      this.TappedUp = true;
      this.NoStick();
    }
    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
    {
      this.TappedDown = true;
      this.NoStick();
    }
    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    {
      this.TappedLeft = true;
      this.NoStick();
    }
    if (!Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.RightArrow))
      return;
    this.TappedRight = true;
    this.NoStick();
  }

  private void NoStick()
  {
    this.StickUp = false;
    this.StickDown = false;
    this.StickLeft = false;
    this.StickRight = false;
  }
}
