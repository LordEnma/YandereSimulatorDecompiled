using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000535 RID: 1333
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002204 RID: 8708 RVA: 0x001EABBA File Offset: 0x001E8DBA
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x001EABC2 File Offset: 0x001E8DC2
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x001EABD8 File Offset: 0x001E8DD8
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

		// Token: 0x06002207 RID: 8711 RVA: 0x001EAC44 File Offset: 0x001E8E44
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

		// Token: 0x06002208 RID: 8712 RVA: 0x001EACD0 File Offset: 0x001E8ED0
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

		// Token: 0x06002209 RID: 8713 RVA: 0x001EADB6 File Offset: 0x001E8FB6
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001EADD5 File Offset: 0x001E8FD5
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001EADD7 File Offset: 0x001E8FD7
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

		// Token: 0x040049F1 RID: 18929
		public int MovementRange = 100;

		// Token: 0x040049F2 RID: 18930
		public Joystick.AxisOption axesToUse;

		// Token: 0x040049F3 RID: 18931
		public string horizontalAxisName = "Horizontal";

		// Token: 0x040049F4 RID: 18932
		public string verticalAxisName = "Vertical";

		// Token: 0x040049F5 RID: 18933
		private Vector3 m_StartPos;

		// Token: 0x040049F6 RID: 18934
		private bool m_UseX;

		// Token: 0x040049F7 RID: 18935
		private bool m_UseY;

		// Token: 0x040049F8 RID: 18936
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x040049F9 RID: 18937
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000688 RID: 1672
		public enum AxisOption
		{
			// Token: 0x04004FDC RID: 20444
			Both,
			// Token: 0x04004FDD RID: 20445
			OnlyHorizontal,
			// Token: 0x04004FDE RID: 20446
			OnlyVertical
		}
	}
}
