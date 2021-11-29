using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000532 RID: 1330
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x060021ED RID: 8685 RVA: 0x001E8E72 File Offset: 0x001E7072
		private void Update()
		{
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001E8E74 File Offset: 0x001E7074
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x040049A8 RID: 18856
		public string axis;
	}
}
