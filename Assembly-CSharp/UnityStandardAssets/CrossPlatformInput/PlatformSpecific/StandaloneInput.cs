using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x02000545 RID: 1349
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002289 RID: 8841 RVA: 0x001F14A3 File Offset: 0x001EF6A3
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x001F14B5 File Offset: 0x001EF6B5
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x001F14BD File Offset: 0x001EF6BD
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x001F14C5 File Offset: 0x001EF6C5
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x001F14CD File Offset: 0x001EF6CD
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x001F14D9 File Offset: 0x001EF6D9
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600228F RID: 8847 RVA: 0x001F14E5 File Offset: 0x001EF6E5
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002290 RID: 8848 RVA: 0x001F14F1 File Offset: 0x001EF6F1
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002291 RID: 8849 RVA: 0x001F14FD File Offset: 0x001EF6FD
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x001F1509 File Offset: 0x001EF709
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002293 RID: 8851 RVA: 0x001F1515 File Offset: 0x001EF715
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
