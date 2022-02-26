using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x06002206 RID: 8710 RVA: 0x001EDE98 File Offset: 0x001EC098
		private void OnEnable()
		{
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x001EDE9A File Offset: 0x001EC09A
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001EDEA7 File Offset: 0x001EC0A7
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001EDEB4 File Offset: 0x001EC0B4
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001EDEC1 File Offset: 0x001EC0C1
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001EDECE File Offset: 0x001EC0CE
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x001EDEDB File Offset: 0x001EC0DB
		public void Update()
		{
		}

		// Token: 0x04004A34 RID: 18996
		public string Name;
	}
}
