using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000543 RID: 1347
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x0600224D RID: 8781 RVA: 0x001F455C File Offset: 0x001F275C
		private void OnEnable()
		{
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001F455E File Offset: 0x001F275E
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001F456B File Offset: 0x001F276B
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001F4578 File Offset: 0x001F2778
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x001F4585 File Offset: 0x001F2785
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001F4592 File Offset: 0x001F2792
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001F459F File Offset: 0x001F279F
		public void Update()
		{
		}

		// Token: 0x04004B0E RID: 19214
		public string Name;
	}
}
