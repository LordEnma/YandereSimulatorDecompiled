using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000539 RID: 1337
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06002227 RID: 8743 RVA: 0x001EE056 File Offset: 0x001EC256
		private void Update()
		{
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x001EE058 File Offset: 0x001EC258
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004A38 RID: 19000
		public string axis;
	}
}
