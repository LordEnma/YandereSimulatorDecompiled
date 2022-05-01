using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054C RID: 1356
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x060022B1 RID: 8881 RVA: 0x001F512B File Offset: 0x001F332B
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x001F513D File Offset: 0x001F333D
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x001F5145 File Offset: 0x001F3345
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x001F514D File Offset: 0x001F334D
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x001F5155 File Offset: 0x001F3355
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B6 RID: 8886 RVA: 0x001F5161 File Offset: 0x001F3361
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B7 RID: 8887 RVA: 0x001F516D File Offset: 0x001F336D
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B8 RID: 8888 RVA: 0x001F5179 File Offset: 0x001F3379
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x001F5185 File Offset: 0x001F3385
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x001F5191 File Offset: 0x001F3391
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022BB RID: 8891 RVA: 0x001F519D File Offset: 0x001F339D
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
