using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000547 RID: 1351
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x0600227B RID: 8827 RVA: 0x001F5D8E File Offset: 0x001F3F8E
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x001F5D96 File Offset: 0x001F3F96
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x001F5DAC File Offset: 0x001F3FAC
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

		// Token: 0x0600227E RID: 8830 RVA: 0x001F5E18 File Offset: 0x001F4018
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

		// Token: 0x0600227F RID: 8831 RVA: 0x001F5EA4 File Offset: 0x001F40A4
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

		// Token: 0x06002280 RID: 8832 RVA: 0x001F5F8A File Offset: 0x001F418A
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002281 RID: 8833 RVA: 0x001F5FA9 File Offset: 0x001F41A9
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x001F5FAB File Offset: 0x001F41AB
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

		// Token: 0x04004B3A RID: 19258
		public int MovementRange = 100;

		// Token: 0x04004B3B RID: 19259
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004B3C RID: 19260
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004B3D RID: 19261
		public string verticalAxisName = "Vertical";

		// Token: 0x04004B3E RID: 19262
		private Vector3 m_StartPos;

		// Token: 0x04004B3F RID: 19263
		private bool m_UseX;

		// Token: 0x04004B40 RID: 19264
		private bool m_UseY;

		// Token: 0x04004B41 RID: 19265
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B42 RID: 19266
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000696 RID: 1686
		public enum AxisOption
		{
			// Token: 0x04005104 RID: 20740
			Both,
			// Token: 0x04005105 RID: 20741
			OnlyHorizontal,
			// Token: 0x04005106 RID: 20742
			OnlyVertical
		}
	}
}
