using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000546 RID: 1350
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002271 RID: 8817 RVA: 0x001F473E File Offset: 0x001F293E
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x001F4746 File Offset: 0x001F2946
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x001F475C File Offset: 0x001F295C
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

		// Token: 0x06002274 RID: 8820 RVA: 0x001F47C8 File Offset: 0x001F29C8
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

		// Token: 0x06002275 RID: 8821 RVA: 0x001F4854 File Offset: 0x001F2A54
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

		// Token: 0x06002276 RID: 8822 RVA: 0x001F493A File Offset: 0x001F2B3A
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x001F4959 File Offset: 0x001F2B59
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002278 RID: 8824 RVA: 0x001F495B File Offset: 0x001F2B5B
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

		// Token: 0x04004B13 RID: 19219
		public int MovementRange = 100;

		// Token: 0x04004B14 RID: 19220
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004B15 RID: 19221
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004B16 RID: 19222
		public string verticalAxisName = "Vertical";

		// Token: 0x04004B17 RID: 19223
		private Vector3 m_StartPos;

		// Token: 0x04004B18 RID: 19224
		private bool m_UseX;

		// Token: 0x04004B19 RID: 19225
		private bool m_UseY;

		// Token: 0x04004B1A RID: 19226
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B1B RID: 19227
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000695 RID: 1685
		public enum AxisOption
		{
			// Token: 0x040050DD RID: 20701
			Both,
			// Token: 0x040050DE RID: 20702
			OnlyHorizontal,
			// Token: 0x040050DF RID: 20703
			OnlyVertical
		}
	}
}
