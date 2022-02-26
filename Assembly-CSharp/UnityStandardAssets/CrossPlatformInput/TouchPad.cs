using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053D RID: 1341
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x0600223C RID: 8764 RVA: 0x001EE4CF File Offset: 0x001EC6CF
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x001EE4D7 File Offset: 0x001EC6D7
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x001EE4FC File Offset: 0x001EC6FC
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

		// Token: 0x0600223F RID: 8767 RVA: 0x001EE585 File Offset: 0x001EC785
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

		// Token: 0x06002240 RID: 8768 RVA: 0x001EE5C2 File Offset: 0x001EC7C2
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x001EE5F0 File Offset: 0x001EC7F0
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

		// Token: 0x06002242 RID: 8770 RVA: 0x001EE6F1 File Offset: 0x001EC8F1
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x001EE70C File Offset: 0x001EC90C
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

		// Token: 0x04004A47 RID: 19015
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004A48 RID: 19016
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004A49 RID: 19017
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A4A RID: 19018
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A4B RID: 19019
		public float Xsensitivity = 1f;

		// Token: 0x04004A4C RID: 19020
		public float Ysensitivity = 1f;

		// Token: 0x04004A4D RID: 19021
		private Vector3 m_StartPos;

		// Token: 0x04004A4E RID: 19022
		private Vector2 m_PreviousDelta;

		// Token: 0x04004A4F RID: 19023
		private Vector3 m_JoytickOutput;

		// Token: 0x04004A50 RID: 19024
		private bool m_UseX;

		// Token: 0x04004A51 RID: 19025
		private bool m_UseY;

		// Token: 0x04004A52 RID: 19026
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A53 RID: 19027
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004A54 RID: 19028
		private bool m_Dragging;

		// Token: 0x04004A55 RID: 19029
		private int m_Id = -1;

		// Token: 0x04004A56 RID: 19030
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004A57 RID: 19031
		private Vector3 m_Center;

		// Token: 0x04004A58 RID: 19032
		private Image m_Image;

		// Token: 0x0200068C RID: 1676
		public enum AxisOption
		{
			// Token: 0x04005004 RID: 20484
			Both,
			// Token: 0x04005005 RID: 20485
			OnlyHorizontal,
			// Token: 0x04005006 RID: 20486
			OnlyVertical
		}

		// Token: 0x0200068D RID: 1677
		public enum ControlStyle
		{
			// Token: 0x04005008 RID: 20488
			Absolute,
			// Token: 0x04005009 RID: 20489
			Relative,
			// Token: 0x0400500A RID: 20490
			Swipe
		}
	}
}
