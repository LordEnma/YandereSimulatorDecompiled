using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000548 RID: 1352
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002279 RID: 8825 RVA: 0x001F360B File Offset: 0x001F180B
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x001F3613 File Offset: 0x001F1813
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x001F3638 File Offset: 0x001F1838
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

		// Token: 0x0600227C RID: 8828 RVA: 0x001F36C1 File Offset: 0x001F18C1
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

		// Token: 0x0600227D RID: 8829 RVA: 0x001F36FE File Offset: 0x001F18FE
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x001F372C File Offset: 0x001F192C
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

		// Token: 0x0600227F RID: 8831 RVA: 0x001F382D File Offset: 0x001F1A2D
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002280 RID: 8832 RVA: 0x001F3848 File Offset: 0x001F1A48
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

		// Token: 0x04004B0B RID: 19211
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004B0C RID: 19212
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004B0D RID: 19213
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004B0E RID: 19214
		public string verticalAxisName = "Vertical";

		// Token: 0x04004B0F RID: 19215
		public float Xsensitivity = 1f;

		// Token: 0x04004B10 RID: 19216
		public float Ysensitivity = 1f;

		// Token: 0x04004B11 RID: 19217
		private Vector3 m_StartPos;

		// Token: 0x04004B12 RID: 19218
		private Vector2 m_PreviousDelta;

		// Token: 0x04004B13 RID: 19219
		private Vector3 m_JoytickOutput;

		// Token: 0x04004B14 RID: 19220
		private bool m_UseX;

		// Token: 0x04004B15 RID: 19221
		private bool m_UseY;

		// Token: 0x04004B16 RID: 19222
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B17 RID: 19223
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004B18 RID: 19224
		private bool m_Dragging;

		// Token: 0x04004B19 RID: 19225
		private int m_Id = -1;

		// Token: 0x04004B1A RID: 19226
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004B1B RID: 19227
		private Vector3 m_Center;

		// Token: 0x04004B1C RID: 19228
		private Image m_Image;

		// Token: 0x02000697 RID: 1687
		public enum AxisOption
		{
			// Token: 0x040050C8 RID: 20680
			Both,
			// Token: 0x040050C9 RID: 20681
			OnlyHorizontal,
			// Token: 0x040050CA RID: 20682
			OnlyVertical
		}

		// Token: 0x02000698 RID: 1688
		public enum ControlStyle
		{
			// Token: 0x040050CC RID: 20684
			Absolute,
			// Token: 0x040050CD RID: 20685
			Relative,
			// Token: 0x040050CE RID: 20686
			Swipe
		}
	}
}
