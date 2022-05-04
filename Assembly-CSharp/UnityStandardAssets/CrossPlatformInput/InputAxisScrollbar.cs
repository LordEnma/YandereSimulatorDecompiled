using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000545 RID: 1349
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x0600226E RID: 8814 RVA: 0x001F471A File Offset: 0x001F291A
		private void Update()
		{
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x001F471C File Offset: 0x001F291C
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004B12 RID: 19218
		public string axis;
	}
}
