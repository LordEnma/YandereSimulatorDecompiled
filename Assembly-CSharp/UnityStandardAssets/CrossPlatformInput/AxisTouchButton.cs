using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002206 RID: 8710 RVA: 0x001EE704 File Offset: 0x001EC904
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

		// Token: 0x06002207 RID: 8711 RVA: 0x001EE754 File Offset: 0x001EC954
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

		// Token: 0x06002208 RID: 8712 RVA: 0x001EE7B0 File Offset: 0x001EC9B0
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001EE7C0 File Offset: 0x001EC9C0
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001EE80E File Offset: 0x001ECA0E
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004A4B RID: 19019
		public string axisName = "Horizontal";

		// Token: 0x04004A4C RID: 19020
		public float axisValue = 1f;

		// Token: 0x04004A4D RID: 19021
		public float responseSpeed = 3f;

		// Token: 0x04004A4E RID: 19022
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004A4F RID: 19023
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004A50 RID: 19024
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
