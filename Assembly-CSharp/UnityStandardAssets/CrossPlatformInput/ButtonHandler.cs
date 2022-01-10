using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000534 RID: 1332
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x060021EB RID: 8683 RVA: 0x001EB378 File Offset: 0x001E9578
		private void OnEnable()
		{
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001EB37A File Offset: 0x001E957A
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001EB387 File Offset: 0x001E9587
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001EB394 File Offset: 0x001E9594
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x001EB3A1 File Offset: 0x001E95A1
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001EB3AE File Offset: 0x001E95AE
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001EB3BB File Offset: 0x001E95BB
		public void Update()
		{
		}

		// Token: 0x04004A00 RID: 18944
		public string Name;
	}
}
