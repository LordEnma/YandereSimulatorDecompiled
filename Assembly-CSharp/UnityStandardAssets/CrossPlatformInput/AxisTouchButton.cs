using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000534 RID: 1332
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x060021E7 RID: 8679 RVA: 0x001EBEDC File Offset: 0x001EA0DC
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

		// Token: 0x060021E8 RID: 8680 RVA: 0x001EBF2C File Offset: 0x001EA12C
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

		// Token: 0x060021E9 RID: 8681 RVA: 0x001EBF88 File Offset: 0x001EA188
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x001EBF98 File Offset: 0x001EA198
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001EBFE6 File Offset: 0x001EA1E6
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004A01 RID: 18945
		public string axisName = "Horizontal";

		// Token: 0x04004A02 RID: 18946
		public float axisValue = 1f;

		// Token: 0x04004A03 RID: 18947
		public float responseSpeed = 3f;

		// Token: 0x04004A04 RID: 18948
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004A05 RID: 18949
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004A06 RID: 18950
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
