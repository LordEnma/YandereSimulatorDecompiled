using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x060021FD RID: 8701 RVA: 0x001ED2B8 File Offset: 0x001EB4B8
		private void OnEnable()
		{
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x001ED2BA File Offset: 0x001EB4BA
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001ED2C7 File Offset: 0x001EB4C7
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001ED2D4 File Offset: 0x001EB4D4
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001ED2E1 File Offset: 0x001EB4E1
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001ED2EE File Offset: 0x001EB4EE
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001ED2FB File Offset: 0x001EB4FB
		public void Update()
		{
		}

		// Token: 0x04004A24 RID: 18980
		public string Name;
	}
}
