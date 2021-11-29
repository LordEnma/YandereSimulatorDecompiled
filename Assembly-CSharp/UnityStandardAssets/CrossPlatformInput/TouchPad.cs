using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002202 RID: 8706 RVA: 0x001E92EB File Offset: 0x001E74EB
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001E92F3 File Offset: 0x001E74F3
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001E9318 File Offset: 0x001E7518
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

		// Token: 0x06002205 RID: 8709 RVA: 0x001E93A1 File Offset: 0x001E75A1
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

		// Token: 0x06002206 RID: 8710 RVA: 0x001E93DE File Offset: 0x001E75DE
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x001E940C File Offset: 0x001E760C
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

		// Token: 0x06002208 RID: 8712 RVA: 0x001E950D File Offset: 0x001E770D
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001E9528 File Offset: 0x001E7728
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

		// Token: 0x040049B7 RID: 18871
		public TouchPad.AxisOption axesToUse;

		// Token: 0x040049B8 RID: 18872
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x040049B9 RID: 18873
		public string horizontalAxisName = "Horizontal";

		// Token: 0x040049BA RID: 18874
		public string verticalAxisName = "Vertical";

		// Token: 0x040049BB RID: 18875
		public float Xsensitivity = 1f;

		// Token: 0x040049BC RID: 18876
		public float Ysensitivity = 1f;

		// Token: 0x040049BD RID: 18877
		private Vector3 m_StartPos;

		// Token: 0x040049BE RID: 18878
		private Vector2 m_PreviousDelta;

		// Token: 0x040049BF RID: 18879
		private Vector3 m_JoytickOutput;

		// Token: 0x040049C0 RID: 18880
		private bool m_UseX;

		// Token: 0x040049C1 RID: 18881
		private bool m_UseY;

		// Token: 0x040049C2 RID: 18882
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x040049C3 RID: 18883
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x040049C4 RID: 18884
		private bool m_Dragging;

		// Token: 0x040049C5 RID: 18885
		private int m_Id = -1;

		// Token: 0x040049C6 RID: 18886
		private Vector2 m_PreviousTouchPos;

		// Token: 0x040049C7 RID: 18887
		private Vector3 m_Center;

		// Token: 0x040049C8 RID: 18888
		private Image m_Image;

		// Token: 0x02000688 RID: 1672
		public enum AxisOption
		{
			// Token: 0x04004F91 RID: 20369
			Both,
			// Token: 0x04004F92 RID: 20370
			OnlyHorizontal,
			// Token: 0x04004F93 RID: 20371
			OnlyVertical
		}

		// Token: 0x02000689 RID: 1673
		public enum ControlStyle
		{
			// Token: 0x04004F95 RID: 20373
			Absolute,
			// Token: 0x04004F96 RID: 20374
			Relative,
			// Token: 0x04004F97 RID: 20375
			Swipe
		}
	}
}
