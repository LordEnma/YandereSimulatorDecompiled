using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000539 RID: 1337
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002221 RID: 8737 RVA: 0x001ED49A File Offset: 0x001EB69A
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x001ED4A2 File Offset: 0x001EB6A2
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002223 RID: 8739 RVA: 0x001ED4B8 File Offset: 0x001EB6B8
		private void UpdateVirtualAxes(Vector3 value)
		{
			Vector3 vector = this.m_StartPos - value;
			vector.y = -vector.y;
			vector /= (float)this.MovementRange;
			if (this.m_UseX)
			{
				this.m_HorizontalVirtualAxis.Update(-vector.x);
			}
			if (this.m_UseY)
			{
				this.m_VerticalVirtualAxis.Update(vector.y);
			}
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001ED524 File Offset: 0x001EB724
		private void CreateVirtualAxes()
		{
			this.m_UseX = (this.axesToUse == Joystick.AxisOption.Both || this.axesToUse == Joystick.AxisOption.OnlyHorizontal);
			this.m_UseY = (this.axesToUse == Joystick.AxisOption.Both || this.axesToUse == Joystick.AxisOption.OnlyVertical);
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

		// Token: 0x06002225 RID: 8741 RVA: 0x001ED5B0 File Offset: 0x001EB7B0
		public void OnDrag(PointerEventData data)
		{
			Vector3 zero = Vector3.zero;
			if (this.m_UseX)
			{
				int num = (int)(data.position.x - this.m_StartPos.x);
				num = Mathf.Clamp(num, -this.MovementRange, this.MovementRange);
				zero.x = (float)num;
			}
			if (this.m_UseY)
			{
				int num2 = (int)(data.position.y - this.m_StartPos.y);
				num2 = Mathf.Clamp(num2, -this.MovementRange, this.MovementRange);
				zero.y = (float)num2;
			}
			base.transform.position = new Vector3(this.m_StartPos.x + zero.x, this.m_StartPos.y + zero.y, this.m_StartPos.z + zero.z);
			this.UpdateVirtualAxes(base.transform.position);
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x001ED696 File Offset: 0x001EB896
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002227 RID: 8743 RVA: 0x001ED6B5 File Offset: 0x001EB8B5
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x001ED6B7 File Offset: 0x001EB8B7
		private void OnDisable()
		{
			if (this.m_UseX)
			{
				this.m_HorizontalVirtualAxis.Remove();
			}
			if (this.m_UseY)
			{
				this.m_VerticalVirtualAxis.Remove();
			}
		}

		// Token: 0x04004A29 RID: 18985
		public int MovementRange = 100;

		// Token: 0x04004A2A RID: 18986
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004A2B RID: 18987
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A2C RID: 18988
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A2D RID: 18989
		private Vector3 m_StartPos;

		// Token: 0x04004A2E RID: 18990
		private bool m_UseX;

		// Token: 0x04004A2F RID: 18991
		private bool m_UseY;

		// Token: 0x04004A30 RID: 18992
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A31 RID: 18993
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000686 RID: 1670
		public enum AxisOption
		{
			// Token: 0x04004FE6 RID: 20454
			Both,
			// Token: 0x04004FE7 RID: 20455
			OnlyHorizontal,
			// Token: 0x04004FE8 RID: 20456
			OnlyVertical
		}
	}
}
