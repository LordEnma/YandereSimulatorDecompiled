using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000535 RID: 1333
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x060021F6 RID: 8694 RVA: 0x001ECE04 File Offset: 0x001EB004
		private void OnEnable()
		{
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x001ECE06 File Offset: 0x001EB006
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x060021F8 RID: 8696 RVA: 0x001ECE13 File Offset: 0x001EB013
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x060021F9 RID: 8697 RVA: 0x001ECE20 File Offset: 0x001EB020
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x001ECE2D File Offset: 0x001EB02D
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001ECE3A File Offset: 0x001EB03A
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001ECE47 File Offset: 0x001EB047
		public void Update()
		{
		}

		// Token: 0x04004A1B RID: 18971
		public string Name;
	}
}
