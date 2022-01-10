using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x0600220F RID: 8719 RVA: 0x001EB55A File Offset: 0x001E975A
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x001EB562 File Offset: 0x001E9762
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x001EB578 File Offset: 0x001E9778
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

		// Token: 0x06002212 RID: 8722 RVA: 0x001EB5E4 File Offset: 0x001E97E4
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

		// Token: 0x06002213 RID: 8723 RVA: 0x001EB670 File Offset: 0x001E9870
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

		// Token: 0x06002214 RID: 8724 RVA: 0x001EB756 File Offset: 0x001E9956
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x001EB775 File Offset: 0x001E9975
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x001EB777 File Offset: 0x001E9977
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

		// Token: 0x04004A05 RID: 18949
		public int MovementRange = 100;

		// Token: 0x04004A06 RID: 18950
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004A07 RID: 18951
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A08 RID: 18952
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A09 RID: 18953
		private Vector3 m_StartPos;

		// Token: 0x04004A0A RID: 18954
		private bool m_UseX;

		// Token: 0x04004A0B RID: 18955
		private bool m_UseY;

		// Token: 0x04004A0C RID: 18956
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A0D RID: 18957
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x0200068A RID: 1674
		public enum AxisOption
		{
			// Token: 0x04004FF0 RID: 20464
			Both,
			// Token: 0x04004FF1 RID: 20465
			OnlyHorizontal,
			// Token: 0x04004FF2 RID: 20466
			OnlyVertical
		}
	}
}
