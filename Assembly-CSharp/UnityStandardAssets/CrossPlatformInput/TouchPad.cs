using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053B RID: 1339
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x0600222C RID: 8748 RVA: 0x001ED43B File Offset: 0x001EB63B
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x001ED443 File Offset: 0x001EB643
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x0600222E RID: 8750 RVA: 0x001ED468 File Offset: 0x001EB668
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

		// Token: 0x0600222F RID: 8751 RVA: 0x001ED4F1 File Offset: 0x001EB6F1
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

		// Token: 0x06002230 RID: 8752 RVA: 0x001ED52E File Offset: 0x001EB72E
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x001ED55C File Offset: 0x001EB75C
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

		// Token: 0x06002232 RID: 8754 RVA: 0x001ED65D File Offset: 0x001EB85D
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x001ED678 File Offset: 0x001EB878
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

		// Token: 0x04004A2E RID: 18990
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004A2F RID: 18991
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004A30 RID: 18992
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A31 RID: 18993
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A32 RID: 18994
		public float Xsensitivity = 1f;

		// Token: 0x04004A33 RID: 18995
		public float Ysensitivity = 1f;

		// Token: 0x04004A34 RID: 18996
		private Vector3 m_StartPos;

		// Token: 0x04004A35 RID: 18997
		private Vector2 m_PreviousDelta;

		// Token: 0x04004A36 RID: 18998
		private Vector3 m_JoytickOutput;

		// Token: 0x04004A37 RID: 18999
		private bool m_UseX;

		// Token: 0x04004A38 RID: 19000
		private bool m_UseY;

		// Token: 0x04004A39 RID: 19001
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A3A RID: 19002
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004A3B RID: 19003
		private bool m_Dragging;

		// Token: 0x04004A3C RID: 19004
		private int m_Id = -1;

		// Token: 0x04004A3D RID: 19005
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004A3E RID: 19006
		private Vector3 m_Center;

		// Token: 0x04004A3F RID: 19007
		private Image m_Image;

		// Token: 0x02000688 RID: 1672
		public enum AxisOption
		{
			// Token: 0x04004FE6 RID: 20454
			Both,
			// Token: 0x04004FE7 RID: 20455
			OnlyHorizontal,
			// Token: 0x04004FE8 RID: 20456
			OnlyVertical
		}

		// Token: 0x02000689 RID: 1673
		public enum ControlStyle
		{
			// Token: 0x04004FEA RID: 20458
			Absolute,
			// Token: 0x04004FEB RID: 20459
			Relative,
			// Token: 0x04004FEC RID: 20460
			Swipe
		}
	}
}
