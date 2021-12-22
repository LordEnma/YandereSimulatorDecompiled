using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000534 RID: 1332
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x060021FE RID: 8702 RVA: 0x001EA5A6 File Offset: 0x001E87A6
		private void Update()
		{
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001EA5A8 File Offset: 0x001E87A8
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x040049E7 RID: 18919
		public string axis;
	}
}
