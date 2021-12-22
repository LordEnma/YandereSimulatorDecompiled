using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002213 RID: 8723 RVA: 0x001EAA1F File Offset: 0x001E8C1F
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002214 RID: 8724 RVA: 0x001EAA27 File Offset: 0x001E8C27
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x001EAA4C File Offset: 0x001E8C4C
		private void CreateVirtualAxes()
		{
			this.m_UseX = (this.axesToUse == TouchPad.AxisOption.Both || this.axesToUse == TouchPad.AxisOption.OnlyHorizontal);
			this.m_UseY = (this.axesToUse == TouchPad.AxisOption.Both || this.axesToUse == TouchPad.AxisOption.OnlyVertical);
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

		// Token: 0x06002216 RID: 8726 RVA: 0x001EAAD5 File Offset: 0x001E8CD5
		private void UpdateVirtualAxes(Vector3 value)
		{
			value = value.normalized;
			if (this.m_UseX)
			{
				this.m_HorizontalVirtualAxis.Update(value.x);
			}
			if (this.m_UseY)
			{
				this.m_VerticalVirtualAxis.Update(value.y);
			}
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x001EAB12 File Offset: 0x001E8D12
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001EAB40 File Offset: 0x001E8D40
		private void Update()
		{
			if (!this.m_Dragging)
			{
				return;
			}
			if (Input.touchCount >= this.m_Id + 1 && this.m_Id != -1)
			{
				if (this.controlStyle == TouchPad.ControlStyle.Swipe)
				{
					this.m_Center = this.m_PreviousTouchPos;
					this.m_PreviousTouchPos = Input.touches[this.m_Id].position;
				}
				Vector2 normalized = new Vector2(Input.touches[this.m_Id].position.x - this.m_Center.x, Input.touches[this.m_Id].position.y - this.m_Center.y).normalized;
				normalized.x *= this.Xsensitivity;
				normalized.y *= this.Ysensitivity;
				this.UpdateVirtualAxes(new Vector3(normalized.x, normalized.y, 0f));
			}
		}

		// Token: 0x06002219 RID: 8729 RVA: 0x001EAC41 File Offset: 0x001E8E41
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x0600221A RID: 8730 RVA: 0x001EAC5C File Offset: 0x001E8E5C
		private void OnDisable()
		{
			if (CrossPlatformInputManager.AxisExists(this.horizontalAxisName))
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.horizontalAxisName);
			}
			if (CrossPlatformInputManager.AxisExists(this.verticalAxisName))
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.verticalAxisName);
			}
		}

		// Token: 0x040049F6 RID: 18934
		public TouchPad.AxisOption axesToUse;

		// Token: 0x040049F7 RID: 18935
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x040049F8 RID: 18936
		public string horizontalAxisName = "Horizontal";

		// Token: 0x040049F9 RID: 18937
		public string verticalAxisName = "Vertical";

		// Token: 0x040049FA RID: 18938
		public float Xsensitivity = 1f;

		// Token: 0x040049FB RID: 18939
		public float Ysensitivity = 1f;

		// Token: 0x040049FC RID: 18940
		private Vector3 m_StartPos;

		// Token: 0x040049FD RID: 18941
		private Vector2 m_PreviousDelta;

		// Token: 0x040049FE RID: 18942
		private Vector3 m_JoytickOutput;

		// Token: 0x040049FF RID: 18943
		private bool m_UseX;

		// Token: 0x04004A00 RID: 18944
		private bool m_UseY;

		// Token: 0x04004A01 RID: 18945
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A02 RID: 18946
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004A03 RID: 18947
		private bool m_Dragging;

		// Token: 0x04004A04 RID: 18948
		private int m_Id = -1;

		// Token: 0x04004A05 RID: 18949
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004A06 RID: 18950
		private Vector3 m_Center;

		// Token: 0x04004A07 RID: 18951
		private Image m_Image;

		// Token: 0x0200068B RID: 1675
		public enum AxisOption
		{
			// Token: 0x04004FDC RID: 20444
			Both,
			// Token: 0x04004FDD RID: 20445
			OnlyHorizontal,
			// Token: 0x04004FDE RID: 20446
			OnlyVertical
		}

		// Token: 0x0200068C RID: 1676
		public enum ControlStyle
		{
			// Token: 0x04004FE0 RID: 20448
			Absolute,
			// Token: 0x04004FE1 RID: 20449
			Relative,
			// Token: 0x04004FE2 RID: 20450
			Swipe
		}
	}
}
