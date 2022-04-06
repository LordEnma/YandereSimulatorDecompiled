using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000541 RID: 1345
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002236 RID: 8758 RVA: 0x001F240C File Offset: 0x001F060C
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

		// Token: 0x06002237 RID: 8759 RVA: 0x001F245C File Offset: 0x001F065C
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

		// Token: 0x06002238 RID: 8760 RVA: 0x001F24B8 File Offset: 0x001F06B8
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x001F24C8 File Offset: 0x001F06C8
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x001F2516 File Offset: 0x001F0716
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004AE0 RID: 19168
		public string axisName = "Horizontal";

		// Token: 0x04004AE1 RID: 19169
		public float axisValue = 1f;

		// Token: 0x04004AE2 RID: 19170
		public float responseSpeed = 3f;

		// Token: 0x04004AE3 RID: 19171
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004AE4 RID: 19172
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004AE5 RID: 19173
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
