using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053B RID: 1339
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002245 RID: 8773 RVA: 0x001EB6A3 File Offset: 0x001E98A3
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x06002246 RID: 8774 RVA: 0x001EB6B5 File Offset: 0x001E98B5
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x001EB6BD File Offset: 0x001E98BD
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x001EB6C5 File Offset: 0x001E98C5
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001EB6CD File Offset: 0x001E98CD
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x001EB6D9 File Offset: 0x001E98D9
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x001EB6E5 File Offset: 0x001E98E5
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001EB6F1 File Offset: 0x001E98F1
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x001EB6FD File Offset: 0x001E98FD
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001EB709 File Offset: 0x001E9909
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001EB715 File Offset: 0x001E9915
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
