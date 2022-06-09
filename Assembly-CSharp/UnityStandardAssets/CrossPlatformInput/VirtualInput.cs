// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.VirtualInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
  public abstract class VirtualInput
  {
    protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();
    protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();
    protected List<string> m_AlwaysUseVirtual = new List<string>();

    public Vector3 virtualMousePosition { get; private set; }

    public bool AxisExists(string name) => this.m_VirtualAxes.ContainsKey(name);

    public bool ButtonExists(string name) => this.m_VirtualButtons.ContainsKey(name);

    public void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
    {
      if (this.m_VirtualAxes.ContainsKey(axis.name))
      {
        Debug.LogError((object) ("There is already a virtual axis named " + axis.name + " registered."));
      }
      else
      {
        this.m_VirtualAxes.Add(axis.name, axis);
        if (axis.matchWithInputManager)
          return;
        this.m_AlwaysUseVirtual.Add(axis.name);
      }
    }

    public void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
    {
      if (this.m_VirtualButtons.ContainsKey(button.name))
      {
        Debug.LogError((object) ("There is already a virtual button named " + button.name + " registered."));
      }
      else
      {
        this.m_VirtualButtons.Add(button.name, button);
        if (button.matchWithInputManager)
          return;
        this.m_AlwaysUseVirtual.Add(button.name);
      }
    }

    public void UnRegisterVirtualAxis(string name)
    {
      if (!this.m_VirtualAxes.ContainsKey(name))
        return;
      this.m_VirtualAxes.Remove(name);
    }

    public void UnRegisterVirtualButton(string name)
    {
      if (!this.m_VirtualButtons.ContainsKey(name))
        return;
      this.m_VirtualButtons.Remove(name);
    }

    public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(
      string name)
    {
      return !this.m_VirtualAxes.ContainsKey(name) ? (CrossPlatformInputManager.VirtualAxis) null : this.m_VirtualAxes[name];
    }

    public void SetVirtualMousePositionX(float f) => this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);

    public void SetVirtualMousePositionY(float f) => this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);

    public void SetVirtualMousePositionZ(float f) => this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);

    public abstract float GetAxis(string name, bool raw);

    public abstract bool GetButton(string name);

    public abstract bool GetButtonDown(string name);

    public abstract bool GetButtonUp(string name);

    public abstract void SetButtonDown(string name);

    public abstract void SetButtonUp(string name);

    public abstract void SetAxisPositive(string name);

    public abstract void SetAxisNegative(string name);

    public abstract void SetAxisZero(string name);

    public abstract void SetAxis(string name, float value);

    public abstract Vector3 MousePosition();
  }
}
