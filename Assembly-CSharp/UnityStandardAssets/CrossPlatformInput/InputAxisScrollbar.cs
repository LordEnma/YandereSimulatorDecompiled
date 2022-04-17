using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000544 RID: 1348
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002264 RID: 8804 RVA: 0x001F3192 File Offset: 0x001F1392
		private void Update()
		{
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x001F3194 File Offset: 0x001F1394
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004AFC RID: 19196
		public string axis;
	}
}
