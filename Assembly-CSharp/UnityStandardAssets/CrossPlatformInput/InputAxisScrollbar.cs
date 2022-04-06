using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000544 RID: 1348
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x0600225D RID: 8797 RVA: 0x001F2736 File Offset: 0x001F0936
		private void Update()
		{
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001F2738 File Offset: 0x001F0938
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004AEA RID: 19178
		public string axis;
	}
}
