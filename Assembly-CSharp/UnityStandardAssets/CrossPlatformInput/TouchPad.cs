using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200054A RID: 1354
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x0600228D RID: 8845 RVA: 0x001F61E3 File Offset: 0x001F43E3
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x001F61EB File Offset: 0x001F43EB
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x0600228F RID: 8847 RVA: 0x001F6210 File Offset: 0x001F4410
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

		// Token: 0x06002290 RID: 8848 RVA: 0x001F6299 File Offset: 0x001F4499
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

		// Token: 0x06002291 RID: 8849 RVA: 0x001F62D6 File Offset: 0x001F44D6
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x001F6304 File Offset: 0x001F4504
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

		// Token: 0x06002293 RID: 8851 RVA: 0x001F6405 File Offset: 0x001F4605
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002294 RID: 8852 RVA: 0x001F6420 File Offset: 0x001F4620
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

		// Token: 0x04004B48 RID: 19272
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004B49 RID: 19273
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004B4A RID: 19274
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004B4B RID: 19275
		public string verticalAxisName = "Vertical";

		// Token: 0x04004B4C RID: 19276
		public float Xsensitivity = 1f;

		// Token: 0x04004B4D RID: 19277
		public float Ysensitivity = 1f;

		// Token: 0x04004B4E RID: 19278
		private Vector3 m_StartPos;

		// Token: 0x04004B4F RID: 19279
		private Vector2 m_PreviousDelta;

		// Token: 0x04004B50 RID: 19280
		private Vector3 m_JoytickOutput;

		// Token: 0x04004B51 RID: 19281
		private bool m_UseX;

		// Token: 0x04004B52 RID: 19282
		private bool m_UseY;

		// Token: 0x04004B53 RID: 19283
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B54 RID: 19284
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004B55 RID: 19285
		private bool m_Dragging;

		// Token: 0x04004B56 RID: 19286
		private int m_Id = -1;

		// Token: 0x04004B57 RID: 19287
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004B58 RID: 19288
		private Vector3 m_Center;

		// Token: 0x04004B59 RID: 19289
		private Image m_Image;

		// Token: 0x02000699 RID: 1689
		public enum AxisOption
		{
			// Token: 0x0400510D RID: 20749
			Both,
			// Token: 0x0400510E RID: 20750
			OnlyHorizontal,
			// Token: 0x0400510F RID: 20751
			OnlyVertical
		}

		// Token: 0x0200069A RID: 1690
		public enum ControlStyle
		{
			// Token: 0x04005111 RID: 20753
			Absolute,
			// Token: 0x04005112 RID: 20754
			Relative,
			// Token: 0x04005113 RID: 20755
			Swipe
		}
	}
}
