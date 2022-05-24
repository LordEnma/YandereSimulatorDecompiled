using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000547 RID: 1351
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x0600227C RID: 8828 RVA: 0x001F62F6 File Offset: 0x001F44F6
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x001F62FE File Offset: 0x001F44FE
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x001F6314 File Offset: 0x001F4514
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

		// Token: 0x0600227F RID: 8831 RVA: 0x001F6380 File Offset: 0x001F4580
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

		// Token: 0x06002280 RID: 8832 RVA: 0x001F640C File Offset: 0x001F460C
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

		// Token: 0x06002281 RID: 8833 RVA: 0x001F64F2 File Offset: 0x001F46F2
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x001F6511 File Offset: 0x001F4711
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x001F6513 File Offset: 0x001F4713
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

		// Token: 0x04004B43 RID: 19267
		public int MovementRange = 100;

		// Token: 0x04004B44 RID: 19268
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004B45 RID: 19269
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004B46 RID: 19270
		public string verticalAxisName = "Vertical";

		// Token: 0x04004B47 RID: 19271
		private Vector3 m_StartPos;

		// Token: 0x04004B48 RID: 19272
		private bool m_UseX;

		// Token: 0x04004B49 RID: 19273
		private bool m_UseY;

		// Token: 0x04004B4A RID: 19274
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B4B RID: 19275
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000696 RID: 1686
		public enum AxisOption
		{
			// Token: 0x0400510D RID: 20749
			Both,
			// Token: 0x0400510E RID: 20750
			OnlyHorizontal,
			// Token: 0x0400510F RID: 20751
			OnlyVertical
		}
	}
}
