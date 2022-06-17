// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.Joystick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
  public class Joystick : 
    MonoBehaviour,
    IPointerDownHandler,
    IEventSystemHandler,
    IPointerUpHandler,
    IDragHandler
  {
    public int MovementRange = 100;
    public Joystick.AxisOption axesToUse;
    public string horizontalAxisName = "Horizontal";
    public string verticalAxisName = "Vertical";
    private Vector3 m_StartPos;
    private bool m_UseX;
    private bool m_UseY;
    private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;
    private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

    private void OnEnable() => this.CreateVirtualAxes();

    private void Start() => this.m_StartPos = this.transform.position;

    private void UpdateVirtualAxes(Vector3 value)
    {
      Vector3 vector3_1 = this.m_StartPos - value;
      vector3_1.y = -vector3_1.y;
      Vector3 vector3_2 = vector3_1 / (float) this.MovementRange;
      if (this.m_UseX)
        this.m_HorizontalVirtualAxis.Update(-vector3_2.x);
      if (!this.m_UseY)
        return;
      this.m_VerticalVirtualAxis.Update(vector3_2.y);
    }

    private void CreateVirtualAxes()
    {
      this.m_UseX = this.axesToUse == Joystick.AxisOption.Both || this.axesToUse == Joystick.AxisOption.OnlyHorizontal;
      this.m_UseY = this.axesToUse == Joystick.AxisOption.Both || this.axesToUse == Joystick.AxisOption.OnlyVertical;
      if (this.m_UseX)
      {
        this.m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(this.horizontalAxisName);
        CrossPlatformInputManager.RegisterVirtualAxis(this.m_HorizontalVirtualAxis);
      }
      if (!this.m_UseY)
        return;
      this.m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(this.verticalAxisName);
      CrossPlatformInputManager.RegisterVirtualAxis(this.m_VerticalVirtualAxis);
    }

    public void OnDrag(PointerEventData data)
    {
      Vector3 zero = Vector3.zero;
      if (this.m_UseX)
      {
        int num = Mathf.Clamp((int) ((double) data.position.x - (double) this.m_StartPos.x), -this.MovementRange, this.MovementRange);
        zero.x = (float) num;
      }
      if (this.m_UseY)
      {
        int num = Mathf.Clamp((int) ((double) data.position.y - (double) this.m_StartPos.y), -this.MovementRange, this.MovementRange);
        zero.y = (float) num;
      }
      this.transform.position = new Vector3(this.m_StartPos.x + zero.x, this.m_StartPos.y + zero.y, this.m_StartPos.z + zero.z);
      this.UpdateVirtualAxes(this.transform.position);
    }

    public void OnPointerUp(PointerEventData data)
    {
      this.transform.position = this.m_StartPos;
      this.UpdateVirtualAxes(this.m_StartPos);
    }

    public void OnPointerDown(PointerEventData data)
    {
    }

    private void OnDisable()
    {
      if (this.m_UseX)
        this.m_HorizontalVirtualAxis.Remove();
      if (!this.m_UseY)
        return;
      this.m_VerticalVirtualAxis.Remove();
    }

    public enum AxisOption
    {
      Both,
      OnlyHorizontal,
      OnlyVertical,
    }
  }
}
