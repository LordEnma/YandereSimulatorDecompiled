using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002217 RID: 8727 RVA: 0x001ECDE2 File Offset: 0x001EAFE2
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001ECDEA File Offset: 0x001EAFEA
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002219 RID: 8729 RVA: 0x001ECE00 File Offset: 0x001EB000
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

		// Token: 0x0600221A RID: 8730 RVA: 0x001ECE6C File Offset: 0x001EB06C
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

		// Token: 0x0600221B RID: 8731 RVA: 0x001ECEF8 File Offset: 0x001EB0F8
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

		// Token: 0x0600221C RID: 8732 RVA: 0x001ECFDE File Offset: 0x001EB1DE
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x001ECFFD File Offset: 0x001EB1FD
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x0600221E RID: 8734 RVA: 0x001ECFFF File Offset: 0x001EB1FF
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

		// Token: 0x04004A1D RID: 18973
		public int MovementRange = 100;

		// Token: 0x04004A1E RID: 18974
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004A1F RID: 18975
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A20 RID: 18976
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A21 RID: 18977
		private Vector3 m_StartPos;

		// Token: 0x04004A22 RID: 18978
		private bool m_UseX;

		// Token: 0x04004A23 RID: 18979
		private bool m_UseY;

		// Token: 0x04004A24 RID: 18980
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A25 RID: 18981
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000685 RID: 1669
		public enum AxisOption
		{
			// Token: 0x04004FDA RID: 20442
			Both,
			// Token: 0x04004FDB RID: 20443
			OnlyHorizontal,
			// Token: 0x04004FDC RID: 20444
			OnlyVertical
		}
	}
}
