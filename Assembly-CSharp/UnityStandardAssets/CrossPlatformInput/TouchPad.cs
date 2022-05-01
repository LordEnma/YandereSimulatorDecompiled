using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000549 RID: 1353
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002282 RID: 8834 RVA: 0x001F4A97 File Offset: 0x001F2C97
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x001F4A9F File Offset: 0x001F2C9F
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x001F4AC4 File Offset: 0x001F2CC4
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

		// Token: 0x06002285 RID: 8837 RVA: 0x001F4B4D File Offset: 0x001F2D4D
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

		// Token: 0x06002286 RID: 8838 RVA: 0x001F4B8A File Offset: 0x001F2D8A
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002287 RID: 8839 RVA: 0x001F4BB8 File Offset: 0x001F2DB8
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

		// Token: 0x06002288 RID: 8840 RVA: 0x001F4CB9 File Offset: 0x001F2EB9
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002289 RID: 8841 RVA: 0x001F4CD4 File Offset: 0x001F2ED4
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

		// Token: 0x04004B21 RID: 19233
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004B22 RID: 19234
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004B23 RID: 19235
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004B24 RID: 19236
		public string verticalAxisName = "Vertical";

		// Token: 0x04004B25 RID: 19237
		public float Xsensitivity = 1f;

		// Token: 0x04004B26 RID: 19238
		public float Ysensitivity = 1f;

		// Token: 0x04004B27 RID: 19239
		private Vector3 m_StartPos;

		// Token: 0x04004B28 RID: 19240
		private Vector2 m_PreviousDelta;

		// Token: 0x04004B29 RID: 19241
		private Vector3 m_JoytickOutput;

		// Token: 0x04004B2A RID: 19242
		private bool m_UseX;

		// Token: 0x04004B2B RID: 19243
		private bool m_UseY;

		// Token: 0x04004B2C RID: 19244
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B2D RID: 19245
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004B2E RID: 19246
		private bool m_Dragging;

		// Token: 0x04004B2F RID: 19247
		private int m_Id = -1;

		// Token: 0x04004B30 RID: 19248
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004B31 RID: 19249
		private Vector3 m_Center;

		// Token: 0x04004B32 RID: 19250
		private Image m_Image;

		// Token: 0x02000698 RID: 1688
		public enum AxisOption
		{
			// Token: 0x040050E6 RID: 20710
			Both,
			// Token: 0x040050E7 RID: 20711
			OnlyHorizontal,
			// Token: 0x040050E8 RID: 20712
			OnlyVertical
		}

		// Token: 0x02000699 RID: 1689
		public enum ControlStyle
		{
			// Token: 0x040050EA RID: 20714
			Absolute,
			// Token: 0x040050EB RID: 20715
			Relative,
			// Token: 0x040050EC RID: 20716
			Swipe
		}
	}
}
