using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054B RID: 1355
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x060022A8 RID: 8872 RVA: 0x001F3C9F File Offset: 0x001F1E9F
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x060022A9 RID: 8873 RVA: 0x001F3CB1 File Offset: 0x001F1EB1
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x001F3CB9 File Offset: 0x001F1EB9
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x001F3CC1 File Offset: 0x001F1EC1
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x001F3CC9 File Offset: 0x001F1EC9
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x001F3CD5 File Offset: 0x001F1ED5
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x001F3CE1 File Offset: 0x001F1EE1
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022AF RID: 8879 RVA: 0x001F3CED File Offset: 0x001F1EED
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x001F3CF9 File Offset: 0x001F1EF9
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x001F3D05 File Offset: 0x001F1F05
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x001F3D11 File Offset: 0x001F1F11
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
