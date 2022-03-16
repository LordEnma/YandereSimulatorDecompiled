using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053F RID: 1343
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002248 RID: 8776 RVA: 0x001F09BA File Offset: 0x001EEBBA
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001F09C2 File Offset: 0x001EEBC2
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x001F09D8 File Offset: 0x001EEBD8
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

		// Token: 0x0600224B RID: 8779 RVA: 0x001F0A44 File Offset: 0x001EEC44
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

		// Token: 0x0600224C RID: 8780 RVA: 0x001F0AD0 File Offset: 0x001EECD0
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

		// Token: 0x0600224D RID: 8781 RVA: 0x001F0BB6 File Offset: 0x001EEDB6
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001F0BD5 File Offset: 0x001EEDD5
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001F0BD7 File Offset: 0x001EEDD7
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

		// Token: 0x04004AB5 RID: 19125
		public int MovementRange = 100;

		// Token: 0x04004AB6 RID: 19126
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004AB7 RID: 19127
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004AB8 RID: 19128
		public string verticalAxisName = "Vertical";

		// Token: 0x04004AB9 RID: 19129
		private Vector3 m_StartPos;

		// Token: 0x04004ABA RID: 19130
		private bool m_UseX;

		// Token: 0x04004ABB RID: 19131
		private bool m_UseY;

		// Token: 0x04004ABC RID: 19132
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004ABD RID: 19133
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x0200068E RID: 1678
		public enum AxisOption
		{
			// Token: 0x04005077 RID: 20599
			Both,
			// Token: 0x04005078 RID: 20600
			OnlyHorizontal,
			// Token: 0x04005079 RID: 20601
			OnlyVertical
		}
	}
}
