using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000543 RID: 1347
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x06002252 RID: 8786 RVA: 0x001F5FA8 File Offset: 0x001F41A8
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

		// Token: 0x06002253 RID: 8787 RVA: 0x001F5FF8 File Offset: 0x001F41F8
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

		// Token: 0x06002254 RID: 8788 RVA: 0x001F6054 File Offset: 0x001F4254
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x001F6064 File Offset: 0x001F4264
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x001F60B2 File Offset: 0x001F42B2
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04004B38 RID: 19256
		public string axisName = "Horizontal";

		// Token: 0x04004B39 RID: 19257
		public float axisValue = 1f;

		// Token: 0x04004B3A RID: 19258
		public float responseSpeed = 3f;

		// Token: 0x04004B3B RID: 19259
		public float returnToCentreSpeed = 3f;

		// Token: 0x04004B3C RID: 19260
		private AxisTouchButton m_PairedWith;

		// Token: 0x04004B3D RID: 19261
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
