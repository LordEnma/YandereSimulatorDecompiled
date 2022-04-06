using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000545 RID: 1349
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x06002260 RID: 8800 RVA: 0x001F275A File Offset: 0x001F095A
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001F2762 File Offset: 0x001F0962
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x001F2778 File Offset: 0x001F0978
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

		// Token: 0x06002263 RID: 8803 RVA: 0x001F27E4 File Offset: 0x001F09E4
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

		// Token: 0x06002264 RID: 8804 RVA: 0x001F2870 File Offset: 0x001F0A70
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

		// Token: 0x06002265 RID: 8805 RVA: 0x001F2956 File Offset: 0x001F0B56
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x001F2975 File Offset: 0x001F0B75
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x001F2977 File Offset: 0x001F0B77
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

		// Token: 0x04004AEB RID: 19179
		public int MovementRange = 100;

		// Token: 0x04004AEC RID: 19180
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004AED RID: 19181
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004AEE RID: 19182
		public string verticalAxisName = "Vertical";

		// Token: 0x04004AEF RID: 19183
		private Vector3 m_StartPos;

		// Token: 0x04004AF0 RID: 19184
		private bool m_UseX;

		// Token: 0x04004AF1 RID: 19185
		private bool m_UseY;

		// Token: 0x04004AF2 RID: 19186
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004AF3 RID: 19187
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000694 RID: 1684
		public enum AxisOption
		{
			// Token: 0x040050AD RID: 20653
			Both,
			// Token: 0x040050AE RID: 20654
			OnlyHorizontal,
			// Token: 0x040050AF RID: 20655
			OnlyVertical
		}
	}
}
