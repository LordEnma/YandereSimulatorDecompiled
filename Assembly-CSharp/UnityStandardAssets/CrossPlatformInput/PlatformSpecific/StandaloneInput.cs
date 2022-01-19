using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053E RID: 1342
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002252 RID: 8786 RVA: 0x001ECD13 File Offset: 0x001EAF13
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001ECD25 File Offset: 0x001EAF25
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001ECD2D File Offset: 0x001EAF2D
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x001ECD35 File Offset: 0x001EAF35
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x001ECD3D File Offset: 0x001EAF3D
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x001ECD49 File Offset: 0x001EAF49
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001ECD55 File Offset: 0x001EAF55
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001ECD61 File Offset: 0x001EAF61
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001ECD6D File Offset: 0x001EAF6D
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001ECD79 File Offset: 0x001EAF79
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001ECD85 File Offset: 0x001EAF85
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
