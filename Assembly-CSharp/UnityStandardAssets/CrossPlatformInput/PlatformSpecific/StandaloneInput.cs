using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054C RID: 1356
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x060022B2 RID: 8882 RVA: 0x001F5227 File Offset: 0x001F3427
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x001F5239 File Offset: 0x001F3439
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x001F5241 File Offset: 0x001F3441
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x001F5249 File Offset: 0x001F3449
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x060022B6 RID: 8886 RVA: 0x001F5251 File Offset: 0x001F3451
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B7 RID: 8887 RVA: 0x001F525D File Offset: 0x001F345D
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B8 RID: 8888 RVA: 0x001F5269 File Offset: 0x001F3469
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x001F5275 File Offset: 0x001F3475
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x001F5281 File Offset: 0x001F3481
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022BB RID: 8891 RVA: 0x001F528D File Offset: 0x001F348D
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022BC RID: 8892 RVA: 0x001F5299 File Offset: 0x001F3499
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
