using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000543 RID: 1347
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002255 RID: 8789 RVA: 0x001F2206 File Offset: 0x001F0406
		private void Update()
		{
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x001F2208 File Offset: 0x001F0408
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004AE6 RID: 19174
		public string axis;
	}
}
