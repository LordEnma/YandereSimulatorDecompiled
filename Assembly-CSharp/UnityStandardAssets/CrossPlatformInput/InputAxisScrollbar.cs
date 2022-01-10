using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x0600220C RID: 8716 RVA: 0x001EB536 File Offset: 0x001E9736
		private void Update()
		{
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x001EB538 File Offset: 0x001E9738
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04004A04 RID: 18948
		public string axis;
	}
}
