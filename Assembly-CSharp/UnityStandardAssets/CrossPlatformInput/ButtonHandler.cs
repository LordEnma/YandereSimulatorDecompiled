using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000532 RID: 1330
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x060021DD RID: 8669 RVA: 0x001EA3E8 File Offset: 0x001E85E8
		private void OnEnable()
		{
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x001EA3EA File Offset: 0x001E85EA
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x060021DF RID: 8671 RVA: 0x001EA3F7 File Offset: 0x001E85F7
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x060021E0 RID: 8672 RVA: 0x001EA404 File Offset: 0x001E8604
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x060021E1 RID: 8673 RVA: 0x001EA411 File Offset: 0x001E8611
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x001EA41E File Offset: 0x001E861E
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x001EA42B File Offset: 0x001E862B
		public void Update()
		{
		}

		// Token: 0x040049E3 RID: 18915
		public string Name;
	}
}
