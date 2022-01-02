using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000534 RID: 1332
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002201 RID: 8705 RVA: 0x001EAB96 File Offset: 0x001E8D96
		private void Update()
		{
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001EAB98 File Offset: 0x001E8D98
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x040049F0 RID: 18928
		public string axis;
	}
}
