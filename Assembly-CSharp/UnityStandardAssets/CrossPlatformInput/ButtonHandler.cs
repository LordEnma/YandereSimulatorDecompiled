using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000532 RID: 1330
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x060021E0 RID: 8672 RVA: 0x001EA9D8 File Offset: 0x001E8BD8
		private void OnEnable()
		{
		}

		// Token: 0x060021E1 RID: 8673 RVA: 0x001EA9DA File Offset: 0x001E8BDA
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x001EA9E7 File Offset: 0x001E8BE7
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x001EA9F4 File Offset: 0x001E8BF4
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x060021E4 RID: 8676 RVA: 0x001EAA01 File Offset: 0x001E8C01
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x001EAA0E File Offset: 0x001E8C0E
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001EAA1B File Offset: 0x001E8C1B
		public void Update()
		{
		}

		// Token: 0x040049EC RID: 18924
		public string Name;
	}
}
