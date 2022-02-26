using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x02000540 RID: 1344
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x0600226B RID: 8811 RVA: 0x001EEB63 File Offset: 0x001ECD63
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001EEB75 File Offset: 0x001ECD75
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001EEB7D File Offset: 0x001ECD7D
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x001EEB85 File Offset: 0x001ECD85
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x001EEB8D File Offset: 0x001ECD8D
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x001EEB99 File Offset: 0x001ECD99
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x001EEBA5 File Offset: 0x001ECDA5
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x001EEBB1 File Offset: 0x001ECDB1
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x001EEBBD File Offset: 0x001ECDBD
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x001EEBC9 File Offset: 0x001ECDC9
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002275 RID: 8821 RVA: 0x001EEBD5 File Offset: 0x001ECDD5
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
