using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053E RID: 1342
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002258 RID: 8792 RVA: 0x001ED8CB File Offset: 0x001EBACB
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001ED8DD File Offset: 0x001EBADD
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001ED8E5 File Offset: 0x001EBAE5
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001ED8ED File Offset: 0x001EBAED
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001ED8F5 File Offset: 0x001EBAF5
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001ED901 File Offset: 0x001EBB01
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001ED90D File Offset: 0x001EBB0D
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001ED919 File Offset: 0x001EBB19
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x001ED925 File Offset: 0x001EBB25
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001ED931 File Offset: 0x001EBB31
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x001ED93D File Offset: 0x001EBB3D
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
