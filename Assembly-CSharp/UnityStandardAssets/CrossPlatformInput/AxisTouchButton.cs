using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000542 RID: 1346
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002247 RID: 8775 RVA: 0x001F43F0 File Offset: 0x001F25F0
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

		// Token: 0x06002248 RID: 8776 RVA: 0x001F4440 File Offset: 0x001F2640
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

		// Token: 0x06002249 RID: 8777 RVA: 0x001F449C File Offset: 0x001F269C
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x001F44AC File Offset: 0x001F26AC
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x001F44FA File Offset: 0x001F26FA
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004B08 RID: 19208
		public string axisName = "Horizontal";

		// Token: 0x04004B09 RID: 19209
		public float axisValue = 1f;

		// Token: 0x04004B0A RID: 19210
		public float responseSpeed = 3f;

		// Token: 0x04004B0B RID: 19211
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004B0C RID: 19212
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004B0D RID: 19213
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
