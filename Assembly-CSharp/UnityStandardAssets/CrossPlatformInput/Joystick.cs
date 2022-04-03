using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000544 RID: 1348
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002258 RID: 8792 RVA: 0x001F222A File Offset: 0x001F042A
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001F2232 File Offset: 0x001F0432
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001F2248 File Offset: 0x001F0448
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

		// Token: 0x0600225B RID: 8795 RVA: 0x001F22B4 File Offset: 0x001F04B4
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

		// Token: 0x0600225C RID: 8796 RVA: 0x001F2340 File Offset: 0x001F0540
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

		// Token: 0x0600225D RID: 8797 RVA: 0x001F2426 File Offset: 0x001F0626
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001F2445 File Offset: 0x001F0645
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001F2447 File Offset: 0x001F0647
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

		// Token: 0x04004AE7 RID: 19175
		public int MovementRange = 100;

		// Token: 0x04004AE8 RID: 19176
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004AE9 RID: 19177
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004AEA RID: 19178
		public string verticalAxisName = "Vertical";

		// Token: 0x04004AEB RID: 19179
		private Vector3 m_StartPos;

		// Token: 0x04004AEC RID: 19180
		private bool m_UseX;

		// Token: 0x04004AED RID: 19181
		private bool m_UseY;

		// Token: 0x04004AEE RID: 19182
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004AEF RID: 19183
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000693 RID: 1683
		public enum AxisOption
		{
			// Token: 0x040050A9 RID: 20649
			Both,
			// Token: 0x040050AA RID: 20650
			OnlyHorizontal,
			// Token: 0x040050AB RID: 20651
			OnlyVertical
		}
	}
}
