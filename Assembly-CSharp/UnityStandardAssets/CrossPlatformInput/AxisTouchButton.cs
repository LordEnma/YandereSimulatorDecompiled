using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000543 RID: 1347
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002251 RID: 8785 RVA: 0x001F5A40 File Offset: 0x001F3C40
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

		// Token: 0x06002252 RID: 8786 RVA: 0x001F5A90 File Offset: 0x001F3C90
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

		// Token: 0x06002253 RID: 8787 RVA: 0x001F5AEC File Offset: 0x001F3CEC
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001F5AFC File Offset: 0x001F3CFC
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x001F5B4A File Offset: 0x001F3D4A
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004B2F RID: 19247
		public string axisName = "Horizontal";

		// Token: 0x04004B30 RID: 19248
		public float axisValue = 1f;

		// Token: 0x04004B31 RID: 19249
		public float responseSpeed = 3f;

		// Token: 0x04004B32 RID: 19250
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004B33 RID: 19251
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004B34 RID: 19252
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
