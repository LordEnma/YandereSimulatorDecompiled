// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
  public static class CrossPlatformInputManager
  {
    private static VirtualInput activeInput;
    private static VirtualInput s_TouchInput = (VirtualInput) new MobileInput();
    private static VirtualInput s_HardwareInput = (VirtualInput) new StandaloneInput();

    static CrossPlatformInputManager() => CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;

    public static void SwitchActiveInputMethod(
      CrossPlatformInputManager.ActiveInputMethod activeInputMethod)
    {
      if (activeInputMethod != CrossPlatformInputManager.ActiveInputMethod.Hardware)
      {
        if (activeInputMethod != CrossPlatformInputManager.ActiveInputMethod.Touch)
          return;
        CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_TouchInput;
      }
      else
        CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
    }

    public static bool AxisExists(string name) => CrossPlatformInputManager.activeInput.AxisExists(name);

    public static bool ButtonExists(string name) => CrossPlatformInputManager.activeInput.ButtonExists(name);

    public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis) => CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);

    public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button) => CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);

    public static void UnRegisterVirtualAxis(string name)
    {
      if (name == null)
        throw new ArgumentNullException(nameof (name));
      CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
    }

    public static void UnRegisterVirtualButton(string name) => CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);

    public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(
      string name)
    {
      return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
    }

    public static float GetAxis(string name) => CrossPlatformInputManager.GetAxis(name, false);

    public static float GetAxisRaw(string name) => CrossPlatformInputManager.GetAxis(name, true);

    private static float GetAxis(string name, bool raw) => CrossPlatformInputManager.activeInput.GetAxis(name, raw);

    public static bool GetButton(string name) => CrossPlatformInputManager.activeInput.GetButton(name);

    public static bool GetButtonDown(string name) => CrossPlatformInputManager.activeInput.GetButtonDown(name);

    public static bool GetButtonUp(string name) => CrossPlatformInputManager.activeInput.GetButtonUp(name);

    public static void SetButtonDown(string name) => CrossPlatformInputManager.activeInput.SetButtonDown(name);

    public static void SetButtonUp(string name) => CrossPlatformInputManager.activeInput.SetButtonUp(name);

    public static void SetAxisPositive(string name) => CrossPlatformInputManager.activeInput.SetAxisPositive(name);

    public static void SetAxisNegative(string name) => CrossPlatformInputManager.activeInput.SetAxisNegative(name);

    public static void SetAxisZero(string name) => CrossPlatformInputManager.activeInput.SetAxisZero(name);

    public static void SetAxis(string name, float value) => CrossPlatformInputManager.activeInput.SetAxis(name, value);

    public static Vector3 mousePosition => CrossPlatformInputManager.activeInput.MousePosition();

    public static void SetVirtualMousePositionX(float f) => CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);

    public static void SetVirtualMousePositionY(float f) => CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);

    public static void SetVirtualMousePositionZ(float f) => CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);

    public enum ActiveInputMethod
    {
      Hardware,
      Touch,
    }

    public class VirtualAxis
    {
      private float m_Value;

      public string name { get; private set; }

      public bool matchWithInputManager { get; private set; }

      public VirtualAxis(string name)
        : this(name, true)
      {
      }

      public VirtualAxis(string name, bool matchToInputSettings)
      {
        this.name = name;
        this.matchWithInputManager = matchToInputSettings;
      }

      public void Remove() => CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);

      public void Update(float value) => this.m_Value = value;

      public float GetValue => this.m_Value;

      public float GetValueRaw => this.m_Value;
    }

    public class VirtualButton
    {
      private int m_LastPressedFrame = -5;
      private int m_ReleasedFrame = -5;
      private bool m_Pressed;

      public string name { get; private set; }

      public bool matchWithInputManager { get; private set; }

      public VirtualButton(string name)
        : this(name, true)
      {
      }

      public VirtualButton(string name, bool matchToInputSettings)
      {
        this.name = name;
        this.matchWithInputManager = matchToInputSettings;
      }

      public void Pressed()
      {
        if (this.m_Pressed)
          return;
        this.m_Pressed = true;
        this.m_LastPressedFrame = Time.frameCount;
      }

      public void Released()
      {
        this.m_Pressed = false;
        this.m_ReleasedFrame = Time.frameCount;
      }

      public void Remove() => CrossPlatformInputManager.UnRegisterVirtualButton(this.name);

      public bool GetButton => this.m_Pressed;

      public bool GetButtonDown => this.m_LastPressedFrame - Time.frameCount == -1;

      public bool GetButtonUp => this.m_ReleasedFrame == Time.frameCount - 1;
    }
  }
}
