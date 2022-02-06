using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000534 RID: 1332
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x060021F0 RID: 8688 RVA: 0x001ECC98 File Offset: 0x001EAE98
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

		// Token: 0x060021F1 RID: 8689 RVA: 0x001ECCE8 File Offset: 0x001EAEE8
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

		// Token: 0x060021F2 RID: 8690 RVA: 0x001ECD44 File Offset: 0x001EAF44
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x001ECD54 File Offset: 0x001EAF54
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x001ECDA2 File Offset: 0x001EAFA2
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004A15 RID: 18965
		public string axisName = "Horizontal";

		// Token: 0x04004A16 RID: 18966
		public float axisValue = 1f;

		// Token: 0x04004A17 RID: 18967
		public float responseSpeed = 3f;

		// Token: 0x04004A18 RID: 18968
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004A19 RID: 18969
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004A1A RID: 18970
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
