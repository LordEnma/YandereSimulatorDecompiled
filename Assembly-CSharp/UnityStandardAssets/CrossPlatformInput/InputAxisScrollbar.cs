using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053E RID: 1342
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002245 RID: 8773 RVA: 0x001F0996 File Offset: 0x001EEB96
		private void Update()
		{
		}

		// Token: 0x06002246 RID: 8774 RVA: 0x001F0998 File Offset: 0x001EEB98
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004AB4 RID: 19124
		public string axis;
	}
}
