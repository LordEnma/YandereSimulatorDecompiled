using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x0600220E RID: 8718 RVA: 0x001EC206 File Offset: 0x001EA406
		private void Update()
		{
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001EC208 File Offset: 0x001EA408
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004A0B RID: 18955
		public string axis;
	}
}
