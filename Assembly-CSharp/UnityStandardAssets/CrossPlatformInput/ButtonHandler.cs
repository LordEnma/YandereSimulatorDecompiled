using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000544 RID: 1348
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x06002258 RID: 8792 RVA: 0x001F6114 File Offset: 0x001F4314
		private void OnEnable()
		{
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001F6116 File Offset: 0x001F4316
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001F6123 File Offset: 0x001F4323
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001F6130 File Offset: 0x001F4330
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001F613D File Offset: 0x001F433D
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001F614A File Offset: 0x001F434A
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001F6157 File Offset: 0x001F4357
		public void Update()
		{
		}

		// Token: 0x04004B3E RID: 19262
		public string Name;
	}
}
