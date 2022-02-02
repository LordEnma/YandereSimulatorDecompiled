using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002212 RID: 8722 RVA: 0x001ECAA6 File Offset: 0x001EACA6
		private void Update()
		{
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x001ECAA8 File Offset: 0x001EACA8
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004A16 RID: 18966
		public string axis;
	}
}
