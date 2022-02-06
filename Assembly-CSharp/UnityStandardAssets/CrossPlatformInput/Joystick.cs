using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x0600221A RID: 8730 RVA: 0x001ECFE6 File Offset: 0x001EB1E6
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001ECFEE File Offset: 0x001EB1EE
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x001ED004 File Offset: 0x001EB204
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

		// Token: 0x0600221D RID: 8733 RVA: 0x001ED070 File Offset: 0x001EB270
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

		// Token: 0x0600221E RID: 8734 RVA: 0x001ED0FC File Offset: 0x001EB2FC
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

		// Token: 0x0600221F RID: 8735 RVA: 0x001ED1E2 File Offset: 0x001EB3E2
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001ED201 File Offset: 0x001EB401
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x001ED203 File Offset: 0x001EB403
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

		// Token: 0x04004A20 RID: 18976
		public int MovementRange = 100;

		// Token: 0x04004A21 RID: 18977
		public Joystick.AxisOption axesToUse;

		// Token: 0x04004A22 RID: 18978
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A23 RID: 18979
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A24 RID: 18980
		private Vector3 m_StartPos;

		// Token: 0x04004A25 RID: 18981
		private bool m_UseX;

		// Token: 0x04004A26 RID: 18982
		private bool m_UseY;

		// Token: 0x04004A27 RID: 18983
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A28 RID: 18984
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x02000685 RID: 1669
		public enum AxisOption
		{
			// Token: 0x04004FDD RID: 20445
			Both,
			// Token: 0x04004FDE RID: 20446
			OnlyHorizontal,
			// Token: 0x04004FDF RID: 20447
			OnlyVertical
		}
	}
}
