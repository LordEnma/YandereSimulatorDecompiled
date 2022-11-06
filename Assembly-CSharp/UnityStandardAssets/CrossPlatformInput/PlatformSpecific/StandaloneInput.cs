// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.PlatformSpecific.StandaloneInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
  public class StandaloneInput : VirtualInput
  {
    public override float GetAxis(string name, bool raw) => !raw ? Input.GetAxis(name) : Input.GetAxisRaw(name);

    public override bool GetButton(string name) => Input.GetButton(name);

    public override bool GetButtonDown(string name) => Input.GetButtonDown(name);

    public override bool GetButtonUp(string name) => Input.GetButtonUp(name);

    public override void SetButtonDown(string name) => throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");

    public override void SetButtonUp(string name) => throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");

    public override void SetAxisPositive(string name) => throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");

    public override void SetAxisNegative(string name) => throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");

    public override void SetAxisZero(string name) => throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");

    public override void SetAxis(string name, float value) => throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");

    public override Vector3 MousePosition() => Input.mousePosition;
  }
}
