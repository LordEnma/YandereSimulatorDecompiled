using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x0600220C RID: 8716 RVA: 0x001EE870 File Offset: 0x001ECA70
		private void OnEnable()
		{
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x001EE872 File Offset: 0x001ECA72
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x001EE87F File Offset: 0x001ECA7F
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001EE88C File Offset: 0x001ECA8C
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x001EE899 File Offset: 0x001ECA99
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x001EE8A6 File Offset: 0x001ECAA6
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x06002212 RID: 8722 RVA: 0x001EE8B3 File Offset: 0x001ECAB3
		public void Update()
		{
		}

		// Token: 0x04004A51 RID: 19025
		public string Name;
	}
}
