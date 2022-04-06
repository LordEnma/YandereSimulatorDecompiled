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
		// Token: 0x06002272 RID: 8818 RVA: 0x001F2BAF File Offset: 0x001F0DAF
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x001F2BB7 File Offset: 0x001F0DB7
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x001F2BDC File Offset: 0x001F0DDC
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

		// Token: 0x06002275 RID: 8821 RVA: 0x001F2C65 File Offset: 0x001F0E65
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

		// Token: 0x06002276 RID: 8822 RVA: 0x001F2CA2 File Offset: 0x001F0EA2
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x001F2CD0 File Offset: 0x001F0ED0
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

		// Token: 0x06002278 RID: 8824 RVA: 0x001F2DD1 File Offset: 0x001F0FD1
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002279 RID: 8825 RVA: 0x001F2DEC File Offset: 0x001F0FEC
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

		// Token: 0x04004AF9 RID: 19193
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004AFA RID: 19194
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004AFB RID: 19195
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004AFC RID: 19196
		public string verticalAxisName = "Vertical";

		// Token: 0x04004AFD RID: 19197
		public float Xsensitivity = 1f;

		// Token: 0x04004AFE RID: 19198
		public float Ysensitivity = 1f;

		// Token: 0x04004AFF RID: 19199
		private Vector3 m_StartPos;

		// Token: 0x04004B00 RID: 19200
		private Vector2 m_PreviousDelta;

		// Token: 0x04004B01 RID: 19201
		private Vector3 m_JoytickOutput;

		// Token: 0x04004B02 RID: 19202
		private bool m_UseX;

		// Token: 0x04004B03 RID: 19203
		private bool m_UseY;

		// Token: 0x04004B04 RID: 19204
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B05 RID: 19205
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004B06 RID: 19206
		private bool m_Dragging;

		// Token: 0x04004B07 RID: 19207
		private int m_Id = -1;

		// Token: 0x04004B08 RID: 19208
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004B09 RID: 19209
		private Vector3 m_Center;

		// Token: 0x04004B0A RID: 19210
		private Image m_Image;

		// Token: 0x02000697 RID: 1687
		public enum AxisOption
		{
			// Token: 0x040050B6 RID: 20662
			Both,
			// Token: 0x040050B7 RID: 20663
			OnlyHorizontal,
			// Token: 0x040050B8 RID: 20664
			OnlyVertical
		}

		// Token: 0x02000698 RID: 1688
		public enum ControlStyle
		{
			// Token: 0x040050BA RID: 20666
			Absolute,
			// Token: 0x040050BB RID: 20667
			Relative,
			// Token: 0x040050BC RID: 20668
			Swipe
		}
	}
}
