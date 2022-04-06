using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054B RID: 1355
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x060022A1 RID: 8865 RVA: 0x001F3243 File Offset: 0x001F1443
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x060022A2 RID: 8866 RVA: 0x001F3255 File Offset: 0x001F1455
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x060022A3 RID: 8867 RVA: 0x001F325D File Offset: 0x001F145D
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x060022A4 RID: 8868 RVA: 0x001F3265 File Offset: 0x001F1465
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x060022A5 RID: 8869 RVA: 0x001F326D File Offset: 0x001F146D
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022A6 RID: 8870 RVA: 0x001F3279 File Offset: 0x001F1479
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022A7 RID: 8871 RVA: 0x001F3285 File Offset: 0x001F1485
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022A8 RID: 8872 RVA: 0x001F3291 File Offset: 0x001F1491
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022A9 RID: 8873 RVA: 0x001F329D File Offset: 0x001F149D
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x001F32A9 File Offset: 0x001F14A9
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x001F32B5 File Offset: 0x001F14B5
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
