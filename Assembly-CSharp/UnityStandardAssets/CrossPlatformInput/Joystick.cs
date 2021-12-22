using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000535 RID: 1333
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002201 RID: 8705 RVA: 0x001EA5CA File Offset: 0x001E87CA
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001EA5D2 File Offset: 0x001E87D2
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001EA5E8 File Offset: 0x001E87E8
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

		// Token: 0x06002204 RID: 8708 RVA: 0x001EA654 File Offset: 0x001E8854
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

		// Token: 0x06002205 RID: 8709 RVA: 0x001EA6E0 File Offset: 0x001E88E0
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

		// Token: 0x06002206 RID: 8710 RVA: 0x001EA7C6 File Offset: 0x001E89C6
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x001EA7E5 File Offset: 0x001E89E5
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001EA7E7 File Offset: 0x001E89E7
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

		// Token: 0x040049E8 RID: 18920
		public int MovementRange = 100;

		// Token: 0x040049E9 RID: 18921
		public Joystick.AxisOption axesToUse;

		// Token: 0x040049EA RID: 18922
		public string horizontalAxisName = "Horizontal";

		// Token: 0x040049EB RID: 18923
		public string verticalAxisName = "Vertical";

		// Token: 0x040049EC RID: 18924
		private Vector3 m_StartPos;

		// Token: 0x040049ED RID: 18925
		private bool m_UseX;

		// Token: 0x040049EE RID: 18926
		private bool m_UseY;

		// Token: 0x040049EF RID: 18927
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x040049F0 RID: 18928
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000688 RID: 1672
		public enum AxisOption
		{
			// Token: 0x04004FD3 RID: 20435
			Both,
			// Token: 0x04004FD4 RID: 20436
			OnlyHorizontal,
			// Token: 0x04004FD5 RID: 20437
			OnlyVertical
		}
	}
}
