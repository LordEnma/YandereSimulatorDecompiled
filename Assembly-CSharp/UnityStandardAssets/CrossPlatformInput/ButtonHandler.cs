using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000535 RID: 1333
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x060021ED RID: 8685 RVA: 0x001EC048 File Offset: 0x001EA248
		private void OnEnable()
		{
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001EC04A File Offset: 0x001EA24A
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x001EC057 File Offset: 0x001EA257
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001EC064 File Offset: 0x001EA264
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001EC071 File Offset: 0x001EA271
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x001EC07E File Offset: 0x001EA27E
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x001EC08B File Offset: 0x001EA28B
		public void Update()
		{
		}

		// Token: 0x04004A07 RID: 18951
		public string Name;
	}
}
