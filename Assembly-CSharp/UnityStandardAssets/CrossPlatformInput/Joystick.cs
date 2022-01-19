using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002211 RID: 8721 RVA: 0x001EC22A File Offset: 0x001EA42A
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002212 RID: 8722 RVA: 0x001EC232 File Offset: 0x001EA432
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x001EC248 File Offset: 0x001EA448
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

		// Token: 0x06002214 RID: 8724 RVA: 0x001EC2B4 File Offset: 0x001EA4B4
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

		// Token: 0x06002215 RID: 8725 RVA: 0x001EC340 File Offset: 0x001EA540
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

		// Token: 0x06002216 RID: 8726 RVA: 0x001EC426 File Offset: 0x001EA626
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x001EC445 File Offset: 0x001EA645
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001EC447 File Offset: 0x001EA647
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

		// Token: 0x04004A0C RID: 18956
		public int MovementRange = 100;

		// Token: 0x04004A0D RID: 18957
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004A0E RID: 18958
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A0F RID: 18959
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A10 RID: 18960
		private Vector3 m_StartPos;

		// Token: 0x04004A11 RID: 18961
		private bool m_UseX;

		// Token: 0x04004A12 RID: 18962
		private bool m_UseY;

		// Token: 0x04004A13 RID: 18963
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A14 RID: 18964
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x0200068B RID: 1675
		public enum AxisOption
		{
			// Token: 0x04004FF7 RID: 20471
			Both,
			// Token: 0x04004FF8 RID: 20472
			OnlyHorizontal,
			// Token: 0x04004FF9 RID: 20473
			OnlyVertical
		}
	}
}
