using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000531 RID: 1329
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x060021DA RID: 8666 RVA: 0x001EA86C File Offset: 0x001E8A6C
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

		// Token: 0x060021DB RID: 8667 RVA: 0x001EA8BC File Offset: 0x001E8ABC
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

		// Token: 0x060021DC RID: 8668 RVA: 0x001EA918 File Offset: 0x001E8B18
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x001EA928 File Offset: 0x001E8B28
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x001EA976 File Offset: 0x001E8B76
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x040049E6 RID: 18918
		public string axisName = "Horizontal";

		// Token: 0x040049E7 RID: 18919
		public float axisValue = 1f;

		// Token: 0x040049E8 RID: 18920
		public float responseSpeed = 3f;

		// Token: 0x040049E9 RID: 18921
		public float returnToCentreSpeed = 3f;

		// Token: 0x040049EA RID: 18922
		private AxisTouchButton m_PairedWith;

		// Token: 0x040049EB RID: 18923
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
