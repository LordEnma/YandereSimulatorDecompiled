using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000535 RID: 1333
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x060021F3 RID: 8691 RVA: 0x001ECC00 File Offset: 0x001EAE00
		private void OnEnable()
		{
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x001ECC02 File Offset: 0x001EAE02
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001ECC0F File Offset: 0x001EAE0F
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001ECC1C File Offset: 0x001EAE1C
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x001ECC29 File Offset: 0x001EAE29
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x060021F8 RID: 8696 RVA: 0x001ECC36 File Offset: 0x001EAE36
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x060021F9 RID: 8697 RVA: 0x001ECC43 File Offset: 0x001EAE43
		public void Update()
		{
		}

		// Token: 0x04004A18 RID: 18968
		public string Name;
	}
}
