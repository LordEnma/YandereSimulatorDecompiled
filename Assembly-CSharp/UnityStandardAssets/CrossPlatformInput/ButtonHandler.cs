using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000542 RID: 1346
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x06002243 RID: 8771 RVA: 0x001F2FD4 File Offset: 0x001F11D4
		private void OnEnable()
		{
		}

		// Token: 0x06002244 RID: 8772 RVA: 0x001F2FD6 File Offset: 0x001F11D6
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x001F2FE3 File Offset: 0x001F11E3
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x06002246 RID: 8774 RVA: 0x001F2FF0 File Offset: 0x001F11F0
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x001F2FFD File Offset: 0x001F11FD
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x001F300A File Offset: 0x001F120A
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001F3017 File Offset: 0x001F1217
		public void Update()
		{
		}

		// Token: 0x04004AF8 RID: 19192
		public string Name;
	}
}
