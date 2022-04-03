using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000547 RID: 1351
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x0600226A RID: 8810 RVA: 0x001F267F File Offset: 0x001F087F
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001F2687 File Offset: 0x001F0887
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001F26AC File Offset: 0x001F08AC
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

		// Token: 0x0600226D RID: 8813 RVA: 0x001F2735 File Offset: 0x001F0935
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

		// Token: 0x0600226E RID: 8814 RVA: 0x001F2772 File Offset: 0x001F0972
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x001F27A0 File Offset: 0x001F09A0
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

		// Token: 0x06002270 RID: 8816 RVA: 0x001F28A1 File Offset: 0x001F0AA1
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x001F28BC File Offset: 0x001F0ABC
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

		// Token: 0x04004AF5 RID: 19189
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004AF6 RID: 19190
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004AF7 RID: 19191
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004AF8 RID: 19192
		public string verticalAxisName = "Vertical";

		// Token: 0x04004AF9 RID: 19193
		public float Xsensitivity = 1f;

		// Token: 0x04004AFA RID: 19194
		public float Ysensitivity = 1f;

		// Token: 0x04004AFB RID: 19195
		private Vector3 m_StartPos;

		// Token: 0x04004AFC RID: 19196
		private Vector2 m_PreviousDelta;

		// Token: 0x04004AFD RID: 19197
		private Vector3 m_JoytickOutput;

		// Token: 0x04004AFE RID: 19198
		private bool m_UseX;

		// Token: 0x04004AFF RID: 19199
		private bool m_UseY;

		// Token: 0x04004B00 RID: 19200
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004B01 RID: 19201
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004B02 RID: 19202
		private bool m_Dragging;

		// Token: 0x04004B03 RID: 19203
		private int m_Id = -1;

		// Token: 0x04004B04 RID: 19204
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004B05 RID: 19205
		private Vector3 m_Center;

		// Token: 0x04004B06 RID: 19206
		private Image m_Image;

		// Token: 0x02000696 RID: 1686
		public enum AxisOption
		{
			// Token: 0x040050B2 RID: 20658
			Both,
			// Token: 0x040050B3 RID: 20659
			OnlyHorizontal,
			// Token: 0x040050B4 RID: 20660
			OnlyVertical
		}

		// Token: 0x02000697 RID: 1687
		public enum ControlStyle
		{
			// Token: 0x040050B6 RID: 20662
			Absolute,
			// Token: 0x040050B7 RID: 20663
			Relative,
			// Token: 0x040050B8 RID: 20664
			Swipe
		}
	}
}
