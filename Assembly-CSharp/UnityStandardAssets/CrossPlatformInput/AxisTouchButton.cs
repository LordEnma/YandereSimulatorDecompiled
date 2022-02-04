using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000534 RID: 1332
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x060021ED RID: 8685 RVA: 0x001ECA94 File Offset: 0x001EAC94
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

		// Token: 0x060021EE RID: 8686 RVA: 0x001ECAE4 File Offset: 0x001EACE4
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

		// Token: 0x060021EF RID: 8687 RVA: 0x001ECB40 File Offset: 0x001EAD40
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001ECB50 File Offset: 0x001EAD50
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001ECB9E File Offset: 0x001EAD9E
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004A12 RID: 18962
		public string axisName = "Horizontal";

		// Token: 0x04004A13 RID: 18963
		public float axisValue = 1f;

		// Token: 0x04004A14 RID: 18964
		public float responseSpeed = 3f;

		// Token: 0x04004A15 RID: 18965
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004A16 RID: 18966
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004A17 RID: 18967
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
