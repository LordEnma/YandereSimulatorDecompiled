using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002216 RID: 8726 RVA: 0x001EB00F File Offset: 0x001E920F
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x001EB017 File Offset: 0x001E9217
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001EB03C File Offset: 0x001E923C
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

		// Token: 0x06002219 RID: 8729 RVA: 0x001EB0C5 File Offset: 0x001E92C5
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

		// Token: 0x0600221A RID: 8730 RVA: 0x001EB102 File Offset: 0x001E9302
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001EB130 File Offset: 0x001E9330
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

		// Token: 0x0600221C RID: 8732 RVA: 0x001EB231 File Offset: 0x001E9431
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x001EB24C File Offset: 0x001E944C
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

		// Token: 0x040049FF RID: 18943
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004A00 RID: 18944
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004A01 RID: 18945
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A02 RID: 18946
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A03 RID: 18947
		public float Xsensitivity = 1f;

		// Token: 0x04004A04 RID: 18948
		public float Ysensitivity = 1f;

		// Token: 0x04004A05 RID: 18949
		private Vector3 m_StartPos;

		// Token: 0x04004A06 RID: 18950
		private Vector2 m_PreviousDelta;

		// Token: 0x04004A07 RID: 18951
		private Vector3 m_JoytickOutput;

		// Token: 0x04004A08 RID: 18952
		private bool m_UseX;

		// Token: 0x04004A09 RID: 18953
		private bool m_UseY;

		// Token: 0x04004A0A RID: 18954
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A0B RID: 18955
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004A0C RID: 18956
		private bool m_Dragging;

		// Token: 0x04004A0D RID: 18957
		private int m_Id = -1;

		// Token: 0x04004A0E RID: 18958
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004A0F RID: 18959
		private Vector3 m_Center;

		// Token: 0x04004A10 RID: 18960
		private Image m_Image;

		// Token: 0x0200068B RID: 1675
		public enum AxisOption
		{
			// Token: 0x04004FE5 RID: 20453
			Both,
			// Token: 0x04004FE6 RID: 20454
			OnlyHorizontal,
			// Token: 0x04004FE7 RID: 20455
			OnlyVertical
		}

		// Token: 0x0200068C RID: 1676
		public enum ControlStyle
		{
			// Token: 0x04004FE9 RID: 20457
			Absolute,
			// Token: 0x04004FEA RID: 20458
			Relative,
			// Token: 0x04004FEB RID: 20459
			Swipe
		}
	}
}
