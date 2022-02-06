using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002217 RID: 8727 RVA: 0x001ECFC2 File Offset: 0x001EB1C2
		private void Update()
		{
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001ECFC4 File Offset: 0x001EB1C4
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004A1F RID: 18975
		public string axis;
	}
}
