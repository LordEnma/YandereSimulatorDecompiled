using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000546 RID: 1350
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002279 RID: 8825 RVA: 0x001F62D2 File Offset: 0x001F44D2
		private void Update()
		{
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x001F62D4 File Offset: 0x001F44D4
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004B42 RID: 19266
		public string axis;
	}
}
