using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000535 RID: 1333
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x060021F7 RID: 8695 RVA: 0x001ED14C File Offset: 0x001EB34C
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

		// Token: 0x060021F8 RID: 8696 RVA: 0x001ED19C File Offset: 0x001EB39C
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

		// Token: 0x060021F9 RID: 8697 RVA: 0x001ED1F8 File Offset: 0x001EB3F8
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x001ED208 File Offset: 0x001EB408
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001ED256 File Offset: 0x001EB456
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004A1E RID: 18974
		public string axisName = "Horizontal";

		// Token: 0x04004A1F RID: 18975
		public float axisValue = 1f;

		// Token: 0x04004A20 RID: 18976
		public float responseSpeed = 3f;

		// Token: 0x04004A21 RID: 18977
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004A22 RID: 18978
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004A23 RID: 18979
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
