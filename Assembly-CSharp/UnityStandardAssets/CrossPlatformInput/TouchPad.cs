// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.TouchPad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
  [RequireComponent(typeof (Image))]
  public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
  {
    public TouchPad.AxisOption axesToUse;
    public TouchPad.ControlStyle controlStyle;
    public string horizontalAxisName = "Horizontal";
    public string verticalAxisName = "Vertical";
    public float Xsensitivity = 1f;
    public float Ysensitivity = 1f;
    private Vector3 m_StartPos;
    private Vector2 m_PreviousDelta;
    private Vector3 m_JoytickOutput;
    private bool m_UseX;
    private bool m_UseY;
    private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;
    private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;
    private bool m_Dragging;
    private int m_Id = -1;
    private Vector2 m_PreviousTouchPos;
    private Vector3 m_Center;
    private Image m_Image;

    private void OnEnable() => this.CreateVirtualAxes();

    private void Start()
    {
      this.m_Image = this.GetComponent<Image>();
      this.m_Center = this.m_Image.transform.position;
    }

    private void CreateVirtualAxes()
    {
      this.m_UseX = this.axesToUse == TouchPad.AxisOption.Both || this.axesToUse == TouchPad.AxisOption.OnlyHorizontal;
      this.m_UseY = this.axesToUse == TouchPad.AxisOption.Both || this.axesToUse == TouchPad.AxisOption.OnlyVertical;
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

    private void UpdateVirtualAxes(Vector3 value)
    {
      value = value.normalized;
      if (this.m_UseX)
        this.m_HorizontalVirtualAxis.Update(value.x);
      if (!this.m_UseY)
        return;
      this.m_VerticalVirtualAxis.Update(value.y);
    }

    public void OnPointerDown(PointerEventData data)
    {
      this.m_Dragging = true;
      this.m_Id = data.pointerId;
      if (this.controlStyle == TouchPad.ControlStyle.Absolute)
        return;
      this.m_Center = (Vector3) data.position;
    }

    private void Update()
    {
      if (!this.m_Dragging || Input.touchCount < this.m_Id + 1 || this.m_Id == -1)
        return;
      if (this.controlStyle == TouchPad.ControlStyle.Swipe)
      {
        this.m_Center = (Vector3) this.m_PreviousTouchPos;
        this.m_PreviousTouchPos = Input.touches[this.m_Id].position;
      }
      Vector2 normalized = new Vector2(Input.touches[this.m_Id].position.x - this.m_Center.x, Input.touches[this.m_Id].position.y - this.m_Center.y).normalized;
      normalized.x *= this.Xsensitivity;
      normalized.y *= this.Ysensitivity;
      this.UpdateVirtualAxes(new Vector3(normalized.x, normalized.y, 0.0f));
    }

    public void OnPointerUp(PointerEventData data)
    {
      this.m_Dragging = false;
      this.m_Id = -1;
      this.UpdateVirtualAxes(Vector3.zero);
    }

    private void OnDisable()
    {
      if (CrossPlatformInputManager.AxisExists(this.horizontalAxisName))
        CrossPlatformInputManager.UnRegisterVirtualAxis(this.horizontalAxisName);
      if (!CrossPlatformInputManager.AxisExists(this.verticalAxisName))
        return;
      CrossPlatformInputManager.UnRegisterVirtualAxis(this.verticalAxisName);
    }

    public enum AxisOption
    {
      Both,
      OnlyHorizontal,
      OnlyVertical,
    }

    public enum ControlStyle
    {
      Absolute,
      Relative,
      Swipe,
    }
  }
}
