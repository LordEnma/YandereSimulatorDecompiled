using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000535 RID: 1333
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x060021F1 RID: 8689 RVA: 0x001EC8E8 File Offset: 0x001EAAE8
		private void OnEnable()
		{
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x001EC8EA File Offset: 0x001EAAEA
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x001EC8F7 File Offset: 0x001EAAF7
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x001EC904 File Offset: 0x001EAB04
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001EC911 File Offset: 0x001EAB11
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001EC91E File Offset: 0x001EAB1E
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x001EC92B File Offset: 0x001EAB2B
		public void Update()
		{
		}

		// Token: 0x04004A12 RID: 18962
		public string Name;
	}
}
