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
		// Token: 0x0600228E RID: 8846 RVA: 0x001F674B File Offset: 0x001F494B
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600228F RID: 8847 RVA: 0x001F6753 File Offset: 0x001F4953
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06002290 RID: 8848 RVA: 0x001F6778 File Offset: 0x001F4978
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

		// Token: 0x06002291 RID: 8849 RVA: 0x001F6801 File Offset: 0x001F4A01
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

		// Token: 0x06002292 RID: 8850 RVA: 0x001F683E File Offset: 0x001F4A3E
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002293 RID: 8851 RVA: 0x001F686C File Offset: 0x001F4A6C
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

		// Token: 0x06002294 RID: 8852 RVA: 0x001F696D File Offset: 0x001F4B6D
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002295 RID: 8853 RVA: 0x001F6988 File Offset: 0x001F4B88
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

		// Token: 0x04004B51 RID: 19281
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004B52 RID: 19282
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004B53 RID: 19283
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004B54 RID: 19284
		public string verticalAxisName = "Vertical";

		// Token: 0x04004B55 RID: 19285
		public float Xsensitivity = 1f;

		// Token: 0x04004B56 RID: 19286
		public float Ysensitivity = 1f;

		// Token: 0x04004B57 RID: 19287
		private Vector3 m_StartPos;

		// Token: 0x04004B58 RID: 19288
		private Vector2 m_PreviousDelta;

		// Token: 0x04004B59 RID: 19289
		private Vector3 m_JoytickOutput;

		// Token: 0x04004B5A RID: 19290
		private bool m_UseX;

		// Token: 0x04004B5B RID: 19291
		private bool m_UseY;

		// Token: 0x04004B5C RID: 19292
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B5D RID: 19293
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004B5E RID: 19294
		private bool m_Dragging;

		// Token: 0x04004B5F RID: 19295
		private int m_Id = -1;

		// Token: 0x04004B60 RID: 19296
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004B61 RID: 19297
		private Vector3 m_Center;

		// Token: 0x04004B62 RID: 19298
		private Image m_Image;

		// Token: 0x02000699 RID: 1689
		public enum AxisOption
		{
			// Token: 0x04005116 RID: 20758
			Both,
			// Token: 0x04005117 RID: 20759
			OnlyHorizontal,
			// Token: 0x04005118 RID: 20760
			OnlyVertical
		}

		// Token: 0x0200069A RID: 1690
		public enum ControlStyle
		{
			// Token: 0x0400511A RID: 20762
			Absolute,
			// Token: 0x0400511B RID: 20763
			Relative,
			// Token: 0x0400511C RID: 20764
			Swipe
		}
	}
}
