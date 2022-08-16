// Decompiled with JetBrains decompiler
// Type: InputDeviceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class InputDeviceScript : MonoBehaviour
{
  public InputDeviceType Type = InputDeviceType.Gamepad;
  public Vector3 MousePrevious;
  public Vector3 MouseDelta;
  public float Horizontal;
  public float Vertical;
  public string[] joystickNames;

  private void Start()
  {
    this.joystickNames = new string[20];
    for (int index = 0; index < 20; ++index)
      this.joystickNames[index] = "joystick 1 button " + index.ToString();
  }

  private void Update()
  {
    this.MouseDelta = Input.mousePosition - this.MousePrevious;
    this.MousePrevious = Input.mousePosition;
    InputDeviceType type = this.Type;
    if (Input.GetJoystickNames().Length == 0 && Input.anyKey || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || this.MouseDelta != Vector3.zero)
    {
      this.Type = InputDeviceType.MouseAndKeyboard;
    }
    else
    {
      bool flag1 = false;
      for (int index = 0; index < 20; ++index)
      {
        if (Input.GetKey(this.joystickNames[index]))
        {
          flag1 = true;
          break;
        }
      }
      bool flag2 = (double) Math.Abs(Input.GetAxis("DpadX")) > 0.5 || (double) Math.Abs(Input.GetAxis("DpadY")) > 0.5;
      bool flag3 = (double) Mathf.Abs(Input.GetAxis("Vertical")) == 1.0 || (double) Mathf.Abs(Input.GetAxis("Horizontal")) == 1.0;
      if (flag1 | flag2 | flag3)
        this.Type = InputDeviceType.Gamepad;
    }
    if (this.Type != type)
    {
      foreach (PromptSwapScript promptSwapScript in Resources.FindObjectsOfTypeAll<PromptSwapScript>())
        promptSwapScript.UpdateSpriteType(this.Type);
    }
    this.Horizontal = Input.GetAxis("Horizontal");
    this.Vertical = Input.GetAxis("Vertical");
  }
}
