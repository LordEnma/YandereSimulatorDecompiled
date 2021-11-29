using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000530 RID: 1328
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x060021CC RID: 8652 RVA: 0x001E8CB4 File Offset: 0x001E6EB4
		private void OnEnable()
		{
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x001E8CB6 File Offset: 0x001E6EB6
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x060021CE RID: 8654 RVA: 0x001E8CC3 File Offset: 0x001E6EC3
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x060021CF RID: 8655 RVA: 0x001E8CD0 File Offset: 0x001E6ED0
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x060021D0 RID: 8656 RVA: 0x001E8CDD File Offset: 0x001E6EDD
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x001E8CEA File Offset: 0x001E6EEA
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x001E8CF7 File Offset: 0x001E6EF7
		public void Update()
		{
		}

		// Token: 0x040049A4 RID: 18852
		public string Name;
	}
}
