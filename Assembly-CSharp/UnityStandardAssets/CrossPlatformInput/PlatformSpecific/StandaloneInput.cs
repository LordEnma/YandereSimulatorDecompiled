using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053B RID: 1339
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002242 RID: 8770 RVA: 0x001EB0B3 File Offset: 0x001E92B3
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x001EB0C5 File Offset: 0x001E92C5
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x06002244 RID: 8772 RVA: 0x001EB0CD File Offset: 0x001E92CD
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x001EB0D5 File Offset: 0x001E92D5
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x06002246 RID: 8774 RVA: 0x001EB0DD File Offset: 0x001E92DD
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x001EB0E9 File Offset: 0x001E92E9
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x001EB0F5 File Offset: 0x001E92F5
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001EB101 File Offset: 0x001E9301
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x001EB10D File Offset: 0x001E930D
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x001EB119 File Offset: 0x001E9319
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001EB125 File Offset: 0x001E9325
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
