using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x02000541 RID: 1345
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002271 RID: 8817 RVA: 0x001EF53B File Offset: 0x001ED73B
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x001EF54D File Offset: 0x001ED74D
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x001EF555 File Offset: 0x001ED755
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x001EF55D File Offset: 0x001ED75D
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x06002275 RID: 8821 RVA: 0x001EF565 File Offset: 0x001ED765
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x001EF571 File Offset: 0x001ED771
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x001EF57D File Offset: 0x001ED77D
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002278 RID: 8824 RVA: 0x001EF589 File Offset: 0x001ED789
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002279 RID: 8825 RVA: 0x001EF595 File Offset: 0x001ED795
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x001EF5A1 File Offset: 0x001ED7A1
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x001EF5AD File Offset: 0x001ED7AD
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
