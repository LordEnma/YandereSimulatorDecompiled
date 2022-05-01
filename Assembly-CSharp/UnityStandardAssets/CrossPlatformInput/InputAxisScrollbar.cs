using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000545 RID: 1349
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x0600226D RID: 8813 RVA: 0x001F461E File Offset: 0x001F281E
		private void Update()
		{
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x001F4620 File Offset: 0x001F2820
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004B12 RID: 19218
		public string axis;
	}
}
