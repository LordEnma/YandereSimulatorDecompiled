using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000542 RID: 1346
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x0600223C RID: 8764 RVA: 0x001F2578 File Offset: 0x001F0778
		private void OnEnable()
		{
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x001F257A File Offset: 0x001F077A
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x001F2587 File Offset: 0x001F0787
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x0600223F RID: 8767 RVA: 0x001F2594 File Offset: 0x001F0794
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x001F25A1 File Offset: 0x001F07A1
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x001F25AE File Offset: 0x001F07AE
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x06002242 RID: 8770 RVA: 0x001F25BB File Offset: 0x001F07BB
		public void Update()
		{
		}

		// Token: 0x04004AE6 RID: 19174
		public string Name;
	}
}
