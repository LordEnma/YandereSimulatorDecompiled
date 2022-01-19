using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053B RID: 1339
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002223 RID: 8739 RVA: 0x001EC67F File Offset: 0x001EA87F
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001EC687 File Offset: 0x001EA887
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x001EC6AC File Offset: 0x001EA8AC
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

		// Token: 0x06002226 RID: 8742 RVA: 0x001EC735 File Offset: 0x001EA935
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

		// Token: 0x06002227 RID: 8743 RVA: 0x001EC772 File Offset: 0x001EA972
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x001EC7A0 File Offset: 0x001EA9A0
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

		// Token: 0x06002229 RID: 8745 RVA: 0x001EC8A1 File Offset: 0x001EAAA1
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x0600222A RID: 8746 RVA: 0x001EC8BC File Offset: 0x001EAABC
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

		// Token: 0x04004A1A RID: 18970
		public TouchPad.AxisOption axesToUse;

		// Token: 0x04004A1B RID: 18971
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x04004A1C RID: 18972
		public string horizontalAxisName = "Horizontal";

		// Token: 0x04004A1D RID: 18973
		public string verticalAxisName = "Vertical";

		// Token: 0x04004A1E RID: 18974
		public float Xsensitivity = 1f;

		// Token: 0x04004A1F RID: 18975
		public float Ysensitivity = 1f;

		// Token: 0x04004A20 RID: 18976
		private Vector3 m_StartPos;

		// Token: 0x04004A21 RID: 18977
		private Vector2 m_PreviousDelta;

		// Token: 0x04004A22 RID: 18978
		private Vector3 m_JoytickOutput;

		// Token: 0x04004A23 RID: 18979
		private bool m_UseX;

		// Token: 0x04004A24 RID: 18980
		private bool m_UseY;

		// Token: 0x04004A25 RID: 18981
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x04004A26 RID: 18982
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x04004A27 RID: 18983
		private bool m_Dragging;

		// Token: 0x04004A28 RID: 18984
		private int m_Id = -1;

		// Token: 0x04004A29 RID: 18985
		private Vector2 m_PreviousTouchPos;

		// Token: 0x04004A2A RID: 18986
		private Vector3 m_Center;

		// Token: 0x04004A2B RID: 18987
		private Image m_Image;

		// Token: 0x0200068E RID: 1678
		public enum AxisOption
		{
			// Token: 0x04005000 RID: 20480
			Both,
			// Token: 0x04005001 RID: 20481
			OnlyHorizontal,
			// Token: 0x04005002 RID: 20482
			OnlyVertical
		}

		// Token: 0x0200068F RID: 1679
		public enum ControlStyle
		{
			// Token: 0x04005004 RID: 20484
			Absolute,
			// Token: 0x04005005 RID: 20485
			Relative,
			// Token: 0x04005006 RID: 20486
			Swipe
		}
	}
}
