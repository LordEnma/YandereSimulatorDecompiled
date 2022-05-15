using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000544 RID: 1348
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x06002257 RID: 8791 RVA: 0x001F5BAC File Offset: 0x001F3DAC
		private void OnEnable()
		{
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001F5BAE File Offset: 0x001F3DAE
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001F5BBB File Offset: 0x001F3DBB
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001F5BC8 File Offset: 0x001F3DC8
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001F5BD5 File Offset: 0x001F3DD5
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001F5BE2 File Offset: 0x001F3DE2
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001F5BEF File Offset: 0x001F3DEF
		public void Update()
		{
		}

		// Token: 0x04004B35 RID: 19253
		public string Name;
	}
}
