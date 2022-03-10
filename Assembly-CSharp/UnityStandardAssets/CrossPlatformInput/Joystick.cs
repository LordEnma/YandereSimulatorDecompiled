using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053B RID: 1339
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002230 RID: 8752 RVA: 0x001EEA52 File Offset: 0x001ECC52
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x001EEA5A File Offset: 0x001ECC5A
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002232 RID: 8754 RVA: 0x001EEA70 File Offset: 0x001ECC70
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

		// Token: 0x06002233 RID: 8755 RVA: 0x001EEADC File Offset: 0x001ECCDC
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

		// Token: 0x06002234 RID: 8756 RVA: 0x001EEB68 File Offset: 0x001ECD68
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

		// Token: 0x06002235 RID: 8757 RVA: 0x001EEC4E File Offset: 0x001ECE4E
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x001EEC6D File Offset: 0x001ECE6D
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x001EEC6F File Offset: 0x001ECE6F
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

		// Token: 0x04004A56 RID: 19030
		public int MovementRange = 100;

		// Token: 0x04004A57 RID: 19031
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004A58 RID: 19032
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A59 RID: 19033
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A5A RID: 19034
		private Vector3 m_StartPos;

		// Token: 0x04004A5B RID: 19035
		private bool m_UseX;

		// Token: 0x04004A5C RID: 19036
		private bool m_UseY;

		// Token: 0x04004A5D RID: 19037
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A5E RID: 19038
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x0200068A RID: 1674
		public enum AxisOption
		{
			// Token: 0x04005018 RID: 20504
			Both,
			// Token: 0x04005019 RID: 20505
			OnlyHorizontal,
			// Token: 0x0400501A RID: 20506
			OnlyVertical
		}
	}
}
