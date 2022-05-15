using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054D RID: 1357
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x060022BC RID: 8892 RVA: 0x001F6877 File Offset: 0x001F4A77
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x060022BD RID: 8893 RVA: 0x001F6889 File Offset: 0x001F4A89
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x060022BE RID: 8894 RVA: 0x001F6891 File Offset: 0x001F4A91
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x060022BF RID: 8895 RVA: 0x001F6899 File Offset: 0x001F4A99
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x060022C0 RID: 8896 RVA: 0x001F68A1 File Offset: 0x001F4AA1
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C1 RID: 8897 RVA: 0x001F68AD File Offset: 0x001F4AAD
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C2 RID: 8898 RVA: 0x001F68B9 File Offset: 0x001F4AB9
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C3 RID: 8899 RVA: 0x001F68C5 File Offset: 0x001F4AC5
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C4 RID: 8900 RVA: 0x001F68D1 File Offset: 0x001F4AD1
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C5 RID: 8901 RVA: 0x001F68DD File Offset: 0x001F4ADD
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C6 RID: 8902 RVA: 0x001F68E9 File Offset: 0x001F4AE9
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
