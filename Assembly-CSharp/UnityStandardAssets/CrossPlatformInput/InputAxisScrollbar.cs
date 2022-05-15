using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000546 RID: 1350
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002278 RID: 8824 RVA: 0x001F5D6A File Offset: 0x001F3F6A
		private void Update()
		{
		}

		// Token: 0x06002279 RID: 8825 RVA: 0x001F5D6C File Offset: 0x001F3F6C
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004B39 RID: 19257
		public string axis;
	}
}
