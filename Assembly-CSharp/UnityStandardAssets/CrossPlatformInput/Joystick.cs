using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000533 RID: 1331
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x060021F0 RID: 8688 RVA: 0x001E8E96 File Offset: 0x001E7096
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001E8E9E File Offset: 0x001E709E
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x001E8EB4 File Offset: 0x001E70B4
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

		// Token: 0x060021F3 RID: 8691 RVA: 0x001E8F20 File Offset: 0x001E7120
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

		// Token: 0x060021F4 RID: 8692 RVA: 0x001E8FAC File Offset: 0x001E71AC
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

		// Token: 0x060021F5 RID: 8693 RVA: 0x001E9092 File Offset: 0x001E7292
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001E90B1 File Offset: 0x001E72B1
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x001E90B3 File Offset: 0x001E72B3
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

		// Token: 0x040049A9 RID: 18857
		public int MovementRange = 100;

		// Token: 0x040049AA RID: 18858
		public Joystick.AxisOption axesToUse;

		// Token: 0x040049AB RID: 18859
		public string horizontalAxisName = "Horizontal";

		// Token: 0x040049AC RID: 18860
		public string verticalAxisName = "Vertical";

		// Token: 0x040049AD RID: 18861
		private Vector3 m_StartPos;

		// Token: 0x040049AE RID: 18862
		private bool m_UseX;

		// Token: 0x040049AF RID: 18863
		private bool m_UseY;

		// Token: 0x040049B0 RID: 18864
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x040049B1 RID: 18865
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000685 RID: 1669
		public enum AxisOption
		{
			// Token: 0x04004F88 RID: 20360
			Both,
			// Token: 0x04004F89 RID: 20361
			OnlyHorizontal,
			// Token: 0x04004F8A RID: 20362
			OnlyVertical
		}
	}
}
