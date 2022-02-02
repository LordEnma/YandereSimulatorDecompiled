using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053E RID: 1342
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002256 RID: 8790 RVA: 0x001ED5B3 File Offset: 0x001EB7B3
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x001ED5C5 File Offset: 0x001EB7C5
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001ED5CD File Offset: 0x001EB7CD
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001ED5D5 File Offset: 0x001EB7D5
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001ED5DD File Offset: 0x001EB7DD
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001ED5E9 File Offset: 0x001EB7E9
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001ED5F5 File Offset: 0x001EB7F5
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001ED601 File Offset: 0x001EB801
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001ED60D File Offset: 0x001EB80D
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001ED619 File Offset: 0x001EB819
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x001ED625 File Offset: 0x001EB825
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
