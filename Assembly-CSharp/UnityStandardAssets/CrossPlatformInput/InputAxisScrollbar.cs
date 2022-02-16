using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x001ED476 File Offset: 0x001EB676
		private void Update()
		{
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001ED478 File Offset: 0x001EB678
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004A28 RID: 18984
		public string axis;
	}
}
