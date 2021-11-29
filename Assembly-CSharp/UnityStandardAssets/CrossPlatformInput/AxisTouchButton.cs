using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200052F RID: 1327
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x060021C6 RID: 8646 RVA: 0x001E8B48 File Offset: 0x001E6D48
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

		// Token: 0x060021C7 RID: 8647 RVA: 0x001E8B98 File Offset: 0x001E6D98
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

		// Token: 0x060021C8 RID: 8648 RVA: 0x001E8BF4 File Offset: 0x001E6DF4
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x060021C9 RID: 8649 RVA: 0x001E8C04 File Offset: 0x001E6E04
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x060021CA RID: 8650 RVA: 0x001E8C52 File Offset: 0x001E6E52
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x0400499E RID: 18846
		public string axisName = "Horizontal";

		// Token: 0x0400499F RID: 18847
		public float axisValue = 1f;

		// Token: 0x040049A0 RID: 18848
		public float responseSpeed = 3f;

		// Token: 0x040049A1 RID: 18849
		public float returnToCentreSpeed = 3f;

		// Token: 0x040049A2 RID: 18850
		private AxisTouchButton m_PairedWith;

		// Token: 0x040049A3 RID: 18851
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
