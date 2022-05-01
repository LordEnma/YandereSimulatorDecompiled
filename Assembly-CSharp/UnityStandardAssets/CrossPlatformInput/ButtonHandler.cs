using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000543 RID: 1347
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x0600224C RID: 8780 RVA: 0x001F4460 File Offset: 0x001F2660
		private void OnEnable()
		{
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x001F4462 File Offset: 0x001F2662
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001F446F File Offset: 0x001F266F
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001F447C File Offset: 0x001F267C
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001F4489 File Offset: 0x001F2689
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x001F4496 File Offset: 0x001F2696
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001F44A3 File Offset: 0x001F26A3
		public void Update()
		{
		}

		// Token: 0x04004B0E RID: 19214
		public string Name;
	}
}
