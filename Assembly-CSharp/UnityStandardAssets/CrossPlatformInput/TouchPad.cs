using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053E RID: 1342
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002242 RID: 8770 RVA: 0x001EEEA7 File Offset: 0x001ED0A7
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x001EEEAF File Offset: 0x001ED0AF
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06002244 RID: 8772 RVA: 0x001EEED4 File Offset: 0x001ED0D4
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

		// Token: 0x06002245 RID: 8773 RVA: 0x001EEF5D File Offset: 0x001ED15D
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

		// Token: 0x06002246 RID: 8774 RVA: 0x001EEF9A File Offset: 0x001ED19A
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x001EEFC8 File Offset: 0x001ED1C8
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

		// Token: 0x06002248 RID: 8776 RVA: 0x001EF0C9 File Offset: 0x001ED2C9
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001EF0E4 File Offset: 0x001ED2E4
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

		// Token: 0x04004A64 RID: 19044
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004A65 RID: 19045
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004A66 RID: 19046
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A67 RID: 19047
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A68 RID: 19048
		public float Xsensitivity = 1f;

		// Token: 0x04004A69 RID: 19049
		public float Ysensitivity = 1f;

		// Token: 0x04004A6A RID: 19050
		private Vector3 m_StartPos;

		// Token: 0x04004A6B RID: 19051
		private Vector2 m_PreviousDelta;

		// Token: 0x04004A6C RID: 19052
		private Vector3 m_JoytickOutput;

		// Token: 0x04004A6D RID: 19053
		private bool m_UseX;

		// Token: 0x04004A6E RID: 19054
		private bool m_UseY;

		// Token: 0x04004A6F RID: 19055
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A70 RID: 19056
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004A71 RID: 19057
		private bool m_Dragging;

		// Token: 0x04004A72 RID: 19058
		private int m_Id = -1;

		// Token: 0x04004A73 RID: 19059
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004A74 RID: 19060
		private Vector3 m_Center;

		// Token: 0x04004A75 RID: 19061
		private Image m_Image;

		// Token: 0x0200068D RID: 1677
		public enum AxisOption
		{
			// Token: 0x04005021 RID: 20513
			Both,
			// Token: 0x04005022 RID: 20514
			OnlyHorizontal,
			// Token: 0x04005023 RID: 20515
			OnlyVertical
		}

		// Token: 0x0200068E RID: 1678
		public enum ControlStyle
		{
			// Token: 0x04005025 RID: 20517
			Absolute,
			// Token: 0x04005026 RID: 20518
			Relative,
			// Token: 0x04005027 RID: 20519
			Swipe
		}
	}
}
