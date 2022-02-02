using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002215 RID: 8725 RVA: 0x001ECACA File Offset: 0x001EACCA
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x001ECAD2 File Offset: 0x001EACD2
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x001ECAE8 File Offset: 0x001EACE8
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

		// Token: 0x06002218 RID: 8728 RVA: 0x001ECB54 File Offset: 0x001EAD54
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

		// Token: 0x06002219 RID: 8729 RVA: 0x001ECBE0 File Offset: 0x001EADE0
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

		// Token: 0x0600221A RID: 8730 RVA: 0x001ECCC6 File Offset: 0x001EAEC6
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001ECCE5 File Offset: 0x001EAEE5
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x001ECCE7 File Offset: 0x001EAEE7
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

		// Token: 0x04004A17 RID: 18967
		public int MovementRange = 100;

		// Token: 0x04004A18 RID: 18968
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004A19 RID: 18969
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A1A RID: 18970
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A1B RID: 18971
		private Vector3 m_StartPos;

		// Token: 0x04004A1C RID: 18972
		private bool m_UseX;

		// Token: 0x04004A1D RID: 18973
		private bool m_UseY;

		// Token: 0x04004A1E RID: 18974
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A1F RID: 18975
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000685 RID: 1669
		public enum AxisOption
		{
			// Token: 0x04004FD4 RID: 20436
			Both,
			// Token: 0x04004FD5 RID: 20437
			OnlyHorizontal,
			// Token: 0x04004FD6 RID: 20438
			OnlyVertical
		}
	}
}
