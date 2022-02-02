using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000534 RID: 1332
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x060021EB RID: 8683 RVA: 0x001EC77C File Offset: 0x001EA97C
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

		// Token: 0x060021EC RID: 8684 RVA: 0x001EC7CC File Offset: 0x001EA9CC
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

		// Token: 0x060021ED RID: 8685 RVA: 0x001EC828 File Offset: 0x001EAA28
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001EC838 File Offset: 0x001EAA38
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x001EC886 File Offset: 0x001EAA86
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004A0C RID: 18956
		public string axisName = "Horizontal";

		// Token: 0x04004A0D RID: 18957
		public float axisValue = 1f;

		// Token: 0x04004A0E RID: 18958
		public float responseSpeed = 3f;

		// Token: 0x04004A0F RID: 18959
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004A10 RID: 18960
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004A11 RID: 18961
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
