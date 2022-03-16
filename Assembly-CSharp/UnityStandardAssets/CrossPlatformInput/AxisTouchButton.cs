using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053B RID: 1339
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x001F066C File Offset: 0x001EE86C
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

		// Token: 0x0600221F RID: 8735 RVA: 0x001F06BC File Offset: 0x001EE8BC
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

		// Token: 0x06002220 RID: 8736 RVA: 0x001F0718 File Offset: 0x001EE918
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x001F0728 File Offset: 0x001EE928
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x001F0776 File Offset: 0x001EE976
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004AAA RID: 19114
		public string axisName = "Horizontal";

		// Token: 0x04004AAB RID: 19115
		public float axisValue = 1f;

		// Token: 0x04004AAC RID: 19116
		public float responseSpeed = 3f;

		// Token: 0x04004AAD RID: 19117
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004AAE RID: 19118
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004AAF RID: 19119
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
