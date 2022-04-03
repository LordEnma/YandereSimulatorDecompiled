using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000541 RID: 1345
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x06002234 RID: 8756 RVA: 0x001F2048 File Offset: 0x001F0248
		private void OnEnable()
		{
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x001F204A File Offset: 0x001F024A
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x001F2057 File Offset: 0x001F0257
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x001F2064 File Offset: 0x001F0264
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x001F2071 File Offset: 0x001F0271
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x001F207E File Offset: 0x001F027E
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x001F208B File Offset: 0x001F028B
		public void Update()
		{
		}

		// Token: 0x04004AE2 RID: 19170
		public string Name;
	}
}
