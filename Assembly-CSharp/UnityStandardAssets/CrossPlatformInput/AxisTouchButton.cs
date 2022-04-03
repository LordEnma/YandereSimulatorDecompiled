using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000540 RID: 1344
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x0600222E RID: 8750 RVA: 0x001F1EDC File Offset: 0x001F00DC
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

		// Token: 0x0600222F RID: 8751 RVA: 0x001F1F2C File Offset: 0x001F012C
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

		// Token: 0x06002230 RID: 8752 RVA: 0x001F1F88 File Offset: 0x001F0188
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x001F1F98 File Offset: 0x001F0198
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x06002232 RID: 8754 RVA: 0x001F1FE6 File Offset: 0x001F01E6
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004ADC RID: 19164
		public string axisName = "Horizontal";

		// Token: 0x04004ADD RID: 19165
		public float axisValue = 1f;

		// Token: 0x04004ADE RID: 19166
		public float responseSpeed = 3f;

		// Token: 0x04004ADF RID: 19167
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004AE0 RID: 19168
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004AE1 RID: 19169
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
