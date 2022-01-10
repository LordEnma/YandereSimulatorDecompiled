using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053D RID: 1341
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002250 RID: 8784 RVA: 0x001EC043 File Offset: 0x001EA243
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x001EC055 File Offset: 0x001EA255
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001EC05D File Offset: 0x001EA25D
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001EC065 File Offset: 0x001EA265
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001EC06D File Offset: 0x001EA26D
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x001EC079 File Offset: 0x001EA279
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x001EC085 File Offset: 0x001EA285
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x001EC091 File Offset: 0x001EA291
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001EC09D File Offset: 0x001EA29D
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001EC0A9 File Offset: 0x001EA2A9
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001EC0B5 File Offset: 0x001EA2B5
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
