using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000533 RID: 1331
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x060021E5 RID: 8677 RVA: 0x001EB20C File Offset: 0x001E940C
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

		// Token: 0x060021E6 RID: 8678 RVA: 0x001EB25C File Offset: 0x001E945C
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

		// Token: 0x060021E7 RID: 8679 RVA: 0x001EB2B8 File Offset: 0x001E94B8
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x001EB2C8 File Offset: 0x001E94C8
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x001EB316 File Offset: 0x001E9516
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x040049FA RID: 18938
		public string axisName = "Horizontal";

		// Token: 0x040049FB RID: 18939
		public float axisValue = 1f;

		// Token: 0x040049FC RID: 18940
		public float responseSpeed = 3f;

		// Token: 0x040049FD RID: 18941
		public float returnToCentreSpeed = 3f;

		// Token: 0x040049FE RID: 18942
		private AxisTouchButton m_PairedWith;

		// Token: 0x040049FF RID: 18943
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
