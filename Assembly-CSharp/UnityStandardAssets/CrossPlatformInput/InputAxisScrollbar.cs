using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002214 RID: 8724 RVA: 0x001ECDBE File Offset: 0x001EAFBE
		private void Update()
		{
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x001ECDC0 File Offset: 0x001EAFC0
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004A1C RID: 18972
		public string axis;
	}
}
