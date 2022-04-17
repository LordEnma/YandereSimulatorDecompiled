using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000541 RID: 1345
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x0600223D RID: 8765 RVA: 0x001F2E68 File Offset: 0x001F1068
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

		// Token: 0x0600223E RID: 8766 RVA: 0x001F2EB8 File Offset: 0x001F10B8
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

		// Token: 0x0600223F RID: 8767 RVA: 0x001F2F14 File Offset: 0x001F1114
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x001F2F24 File Offset: 0x001F1124
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x001F2F72 File Offset: 0x001F1172
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004AF2 RID: 19186
		public string axisName = "Horizontal";

		// Token: 0x04004AF3 RID: 19187
		public float axisValue = 1f;

		// Token: 0x04004AF4 RID: 19188
		public float responseSpeed = 3f;

		// Token: 0x04004AF5 RID: 19189
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004AF6 RID: 19190
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004AF7 RID: 19191
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
