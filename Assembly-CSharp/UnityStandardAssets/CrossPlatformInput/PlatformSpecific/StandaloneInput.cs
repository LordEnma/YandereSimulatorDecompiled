using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x02000539 RID: 1337
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002231 RID: 8753 RVA: 0x001E997F File Offset: 0x001E7B7F
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x06002232 RID: 8754 RVA: 0x001E9991 File Offset: 0x001E7B91
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x001E9999 File Offset: 0x001E7B99
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x001E99A1 File Offset: 0x001E7BA1
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x001E99A9 File Offset: 0x001E7BA9
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x001E99B5 File Offset: 0x001E7BB5
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x001E99C1 File Offset: 0x001E7BC1
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x001E99CD File Offset: 0x001E7BCD
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x001E99D9 File Offset: 0x001E7BD9
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x001E99E5 File Offset: 0x001E7BE5
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600223B RID: 8763 RVA: 0x001E99F1 File Offset: 0x001E7BF1
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
