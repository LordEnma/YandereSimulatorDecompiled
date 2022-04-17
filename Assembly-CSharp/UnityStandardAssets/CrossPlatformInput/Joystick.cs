using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000545 RID: 1349
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002267 RID: 8807 RVA: 0x001F31B6 File Offset: 0x001F13B6
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x001F31BE File Offset: 0x001F13BE
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x001F31D4 File Offset: 0x001F13D4
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

		// Token: 0x0600226A RID: 8810 RVA: 0x001F3240 File Offset: 0x001F1440
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

		// Token: 0x0600226B RID: 8811 RVA: 0x001F32CC File Offset: 0x001F14CC
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

		// Token: 0x0600226C RID: 8812 RVA: 0x001F33B2 File Offset: 0x001F15B2
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001F33D1 File Offset: 0x001F15D1
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x001F33D3 File Offset: 0x001F15D3
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

		// Token: 0x04004AFD RID: 19197
		public int MovementRange = 100;

		// Token: 0x04004AFE RID: 19198
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004AFF RID: 19199
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004B00 RID: 19200
		public string verticalAxisName = "Vertical";

		// Token: 0x04004B01 RID: 19201
		private Vector3 m_StartPos;

		// Token: 0x04004B02 RID: 19202
		private bool m_UseX;

		// Token: 0x04004B03 RID: 19203
		private bool m_UseY;

		// Token: 0x04004B04 RID: 19204
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B05 RID: 19205
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000694 RID: 1684
		public enum AxisOption
		{
			// Token: 0x040050BF RID: 20671
			Both,
			// Token: 0x040050C0 RID: 20672
			OnlyHorizontal,
			// Token: 0x040050C1 RID: 20673
			OnlyVertical
		}
	}
}
