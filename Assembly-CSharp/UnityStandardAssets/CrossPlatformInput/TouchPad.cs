using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000542 RID: 1346
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x0600225A RID: 8794 RVA: 0x001F0E0F File Offset: 0x001EF00F
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001F0E17 File Offset: 0x001EF017
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001F0E3C File Offset: 0x001EF03C
		private void CreateVirtualAxes()
		{
			this.m_UseX = (this.axesToUse == TouchPad.AxisOption.Both || this.axesToUse == TouchPad.AxisOption.OnlyHorizontal);
			this.m_UseY = (this.axesToUse == TouchPad.AxisOption.Both || this.axesToUse == TouchPad.AxisOption.OnlyVertical);
			if (this.m_UseX)
			{
				this.m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(this.horizontalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_HorizontalVirtualAxis);
			}
			if (this.m_UseY)
			{
				this.m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(this.verticalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_VerticalVirtualAxis);
			}
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001F0EC5 File Offset: 0x001EF0C5
		private void UpdateVirtualAxes(Vector3 value)
		{
			value = value.normalized;
			if (this.m_UseX)
			{
				this.m_HorizontalVirtualAxis.Update(value.x);
			}
			if (this.m_UseY)
			{
				this.m_VerticalVirtualAxis.Update(value.y);
			}
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001F0F02 File Offset: 0x001EF102
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001F0F30 File Offset: 0x001EF130
		private void Update()
		{
			if (!this.m_Dragging)
			{
				return;
			}
			if (Input.touchCount >= this.m_Id + 1 && this.m_Id != -1)
			{
				if (this.controlStyle == TouchPad.ControlStyle.Swipe)
				{
					this.m_Center = this.m_PreviousTouchPos;
					this.m_PreviousTouchPos = Input.touches[this.m_Id].position;
				}
				Vector2 normalized = new Vector2(Input.touches[this.m_Id].position.x - this.m_Center.x, Input.touches[this.m_Id].position.y - this.m_Center.y).normalized;
				normalized.x *= this.Xsensitivity;
				normalized.y *= this.Ysensitivity;
				this.UpdateVirtualAxes(new Vector3(normalized.x, normalized.y, 0f));
			}
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x001F1031 File Offset: 0x001EF231
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001F104C File Offset: 0x001EF24C
		private void OnDisable()
		{
			if (CrossPlatformInputManager.AxisExists(this.horizontalAxisName))
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.horizontalAxisName);
			}
			if (CrossPlatformInputManager.AxisExists(this.verticalAxisName))
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.verticalAxisName);
			}
		}

		// Token: 0x04004AC3 RID: 19139
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004AC4 RID: 19140
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004AC5 RID: 19141
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004AC6 RID: 19142
		public string verticalAxisName = "Vertical";

		// Token: 0x04004AC7 RID: 19143
		public float Xsensitivity = 1f;

		// Token: 0x04004AC8 RID: 19144
		public float Ysensitivity = 1f;

		// Token: 0x04004AC9 RID: 19145
		private Vector3 m_StartPos;

		// Token: 0x04004ACA RID: 19146
		private Vector2 m_PreviousDelta;

		// Token: 0x04004ACB RID: 19147
		private Vector3 m_JoytickOutput;

		// Token: 0x04004ACC RID: 19148
		private bool m_UseX;

		// Token: 0x04004ACD RID: 19149
		private bool m_UseY;

		// Token: 0x04004ACE RID: 19150
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004ACF RID: 19151
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004AD0 RID: 19152
		private bool m_Dragging;

		// Token: 0x04004AD1 RID: 19153
		private int m_Id = -1;

		// Token: 0x04004AD2 RID: 19154
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004AD3 RID: 19155
		private Vector3 m_Center;

		// Token: 0x04004AD4 RID: 19156
		private Image m_Image;

		// Token: 0x02000691 RID: 1681
		public enum AxisOption
		{
			// Token: 0x04005080 RID: 20608
			Both,
			// Token: 0x04005081 RID: 20609
			OnlyHorizontal,
			// Token: 0x04005082 RID: 20610
			OnlyVertical
		}

		// Token: 0x02000692 RID: 1682
		public enum ControlStyle
		{
			// Token: 0x04005084 RID: 20612
			Absolute,
			// Token: 0x04005085 RID: 20613
			Relative,
			// Token: 0x04005086 RID: 20614
			Swipe
		}
	}
}
