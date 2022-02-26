using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053A RID: 1338
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x0600222A RID: 8746 RVA: 0x001EE07A File Offset: 0x001EC27A
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600222B RID: 8747 RVA: 0x001EE082 File Offset: 0x001EC282
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x001EE098 File Offset: 0x001EC298
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

		// Token: 0x0600222D RID: 8749 RVA: 0x001EE104 File Offset: 0x001EC304
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

		// Token: 0x0600222E RID: 8750 RVA: 0x001EE190 File Offset: 0x001EC390
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

		// Token: 0x0600222F RID: 8751 RVA: 0x001EE276 File Offset: 0x001EC476
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002230 RID: 8752 RVA: 0x001EE295 File Offset: 0x001EC495
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x001EE297 File Offset: 0x001EC497
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

		// Token: 0x04004A39 RID: 19001
		public int MovementRange = 100;

		// Token: 0x04004A3A RID: 19002
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004A3B RID: 19003
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A3C RID: 19004
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A3D RID: 19005
		private Vector3 m_StartPos;

		// Token: 0x04004A3E RID: 19006
		private bool m_UseX;

		// Token: 0x04004A3F RID: 19007
		private bool m_UseY;

		// Token: 0x04004A40 RID: 19008
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A41 RID: 19009
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000689 RID: 1673
		public enum AxisOption
		{
			// Token: 0x04004FFB RID: 20475
			Both,
			// Token: 0x04004FFC RID: 20476
			OnlyHorizontal,
			// Token: 0x04004FFD RID: 20477
			OnlyVertical
		}
	}
}
