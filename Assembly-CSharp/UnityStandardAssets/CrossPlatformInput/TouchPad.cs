using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053C RID: 1340
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002233 RID: 8755 RVA: 0x001ED8EF File Offset: 0x001EBAEF
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x001ED8F7 File Offset: 0x001EBAF7
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x001ED91C File Offset: 0x001EBB1C
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

		// Token: 0x06002236 RID: 8758 RVA: 0x001ED9A5 File Offset: 0x001EBBA5
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

		// Token: 0x06002237 RID: 8759 RVA: 0x001ED9E2 File Offset: 0x001EBBE2
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x001EDA10 File Offset: 0x001EBC10
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

		// Token: 0x06002239 RID: 8761 RVA: 0x001EDB11 File Offset: 0x001EBD11
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x001EDB2C File Offset: 0x001EBD2C
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

		// Token: 0x04004A37 RID: 18999
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004A38 RID: 19000
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004A39 RID: 19001
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A3A RID: 19002
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A3B RID: 19003
		public float Xsensitivity = 1f;

		// Token: 0x04004A3C RID: 19004
		public float Ysensitivity = 1f;

		// Token: 0x04004A3D RID: 19005
		private Vector3 m_StartPos;

		// Token: 0x04004A3E RID: 19006
		private Vector2 m_PreviousDelta;

		// Token: 0x04004A3F RID: 19007
		private Vector3 m_JoytickOutput;

		// Token: 0x04004A40 RID: 19008
		private bool m_UseX;

		// Token: 0x04004A41 RID: 19009
		private bool m_UseY;

		// Token: 0x04004A42 RID: 19010
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A43 RID: 19011
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004A44 RID: 19012
		private bool m_Dragging;

		// Token: 0x04004A45 RID: 19013
		private int m_Id = -1;

		// Token: 0x04004A46 RID: 19014
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004A47 RID: 19015
		private Vector3 m_Center;

		// Token: 0x04004A48 RID: 19016
		private Image m_Image;

		// Token: 0x02000689 RID: 1673
		public enum AxisOption
		{
			// Token: 0x04004FEF RID: 20463
			Both,
			// Token: 0x04004FF0 RID: 20464
			OnlyHorizontal,
			// Token: 0x04004FF1 RID: 20465
			OnlyVertical
		}

		// Token: 0x0200068A RID: 1674
		public enum ControlStyle
		{
			// Token: 0x04004FF3 RID: 20467
			Absolute,
			// Token: 0x04004FF4 RID: 20468
			Relative,
			// Token: 0x04004FF5 RID: 20469
			Swipe
		}
	}
}
