using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002200 RID: 8704 RVA: 0x001EDD2C File Offset: 0x001EBF2C
		private void OnEnable()
		{
			if (!CrossPlatformInputManager.AxisExists(this.axisName))
			{
				this.m_Axis = new CrossPlatformInputManager.VirtualAxis(this.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_Axis);
			}
			else
			{
				this.m_Axis = CrossPlatformInputManager.VirtualAxisReference(this.axisName);
			}
			this.FindPairedButton();
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001EDD7C File Offset: 0x001EBF7C
		private void FindPairedButton()
		{
			AxisTouchButton[] array = UnityEngine.Object.FindObjectsOfType(typeof(AxisTouchButton)) as AxisTouchButton[];
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].axisName == this.axisName && array[i] != this)
					{
						this.m_PairedWith = array[i];
					}
				}
			}
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001EDDD8 File Offset: 0x001EBFD8
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001EDDE8 File Offset: 0x001EBFE8
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001EDE36 File Offset: 0x001EC036
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004A2E RID: 18990
		public string axisName = "Horizontal";

		// Token: 0x04004A2F RID: 18991
		public float axisValue = 1f;

		// Token: 0x04004A30 RID: 18992
		public float responseSpeed = 3f;

		// Token: 0x04004A31 RID: 18993
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004A32 RID: 18994
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004A33 RID: 18995
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
