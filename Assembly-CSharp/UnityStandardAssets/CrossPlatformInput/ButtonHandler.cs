using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053C RID: 1340
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x06002224 RID: 8740 RVA: 0x001F07D8 File Offset: 0x001EE9D8
		private void OnEnable()
		{
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x001F07DA File Offset: 0x001EE9DA
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x001F07E7 File Offset: 0x001EE9E7
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x06002227 RID: 8743 RVA: 0x001F07F4 File Offset: 0x001EE9F4
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x001F0801 File Offset: 0x001EEA01
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x001F080E File Offset: 0x001EEA0E
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x0600222A RID: 8746 RVA: 0x001F081B File Offset: 0x001EEA1B
		public void Update()
		{
		}

		// Token: 0x04004AB0 RID: 19120
		public string Name;
	}
}
