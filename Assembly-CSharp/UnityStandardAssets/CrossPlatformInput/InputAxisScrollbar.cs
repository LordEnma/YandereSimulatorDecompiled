using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053A RID: 1338
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x0600222D RID: 8749 RVA: 0x001EEA2E File Offset: 0x001ECC2E
		private void Update()
		{
		}

		// Token: 0x0600222E RID: 8750 RVA: 0x001EEA30 File Offset: 0x001ECC30
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004A55 RID: 19029
		public string axis;
	}
}
