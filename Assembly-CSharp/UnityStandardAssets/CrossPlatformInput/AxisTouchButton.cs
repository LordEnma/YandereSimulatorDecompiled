using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000531 RID: 1329
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x060021D7 RID: 8663 RVA: 0x001EA27C File Offset: 0x001E847C
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

		// Token: 0x060021D8 RID: 8664 RVA: 0x001EA2CC File Offset: 0x001E84CC
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

		// Token: 0x060021D9 RID: 8665 RVA: 0x001EA328 File Offset: 0x001E8528
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x060021DA RID: 8666 RVA: 0x001EA338 File Offset: 0x001E8538
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x001EA386 File Offset: 0x001E8586
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x040049DD RID: 18909
		public string axisName = "Horizontal";

		// Token: 0x040049DE RID: 18910
		public float axisValue = 1f;

		// Token: 0x040049DF RID: 18911
		public float responseSpeed = 3f;

		// Token: 0x040049E0 RID: 18912
		public float returnToCentreSpeed = 3f;

		// Token: 0x040049E1 RID: 18913
		private AxisTouchButton m_PairedWith;

		// Token: 0x040049E2 RID: 18914
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
