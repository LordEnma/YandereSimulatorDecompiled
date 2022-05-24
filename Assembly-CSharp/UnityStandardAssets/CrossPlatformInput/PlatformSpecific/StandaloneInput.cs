using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054D RID: 1357
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x060022BD RID: 8893 RVA: 0x001F6DDF File Offset: 0x001F4FDF
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x060022BE RID: 8894 RVA: 0x001F6DF1 File Offset: 0x001F4FF1
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x060022BF RID: 8895 RVA: 0x001F6DF9 File Offset: 0x001F4FF9
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x060022C0 RID: 8896 RVA: 0x001F6E01 File Offset: 0x001F5001
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x060022C1 RID: 8897 RVA: 0x001F6E09 File Offset: 0x001F5009
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C2 RID: 8898 RVA: 0x001F6E15 File Offset: 0x001F5015
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C3 RID: 8899 RVA: 0x001F6E21 File Offset: 0x001F5021
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C4 RID: 8900 RVA: 0x001F6E2D File Offset: 0x001F502D
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C5 RID: 8901 RVA: 0x001F6E39 File Offset: 0x001F5039
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C6 RID: 8902 RVA: 0x001F6E45 File Offset: 0x001F5045
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022C7 RID: 8903 RVA: 0x001F6E51 File Offset: 0x001F5051
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
