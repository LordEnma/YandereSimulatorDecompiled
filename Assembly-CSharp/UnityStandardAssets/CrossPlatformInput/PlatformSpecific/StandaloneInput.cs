using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053E RID: 1342
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x0600225B RID: 8795 RVA: 0x001EDACF File Offset: 0x001EBCCF
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001EDAE1 File Offset: 0x001EBCE1
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001EDAE9 File Offset: 0x001EBCE9
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001EDAF1 File Offset: 0x001EBCF1
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001EDAF9 File Offset: 0x001EBCF9
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x001EDB05 File Offset: 0x001EBD05
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001EDB11 File Offset: 0x001EBD11
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x001EDB1D File Offset: 0x001EBD1D
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x001EDB29 File Offset: 0x001EBD29
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x001EDB35 File Offset: 0x001EBD35
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x001EDB41 File Offset: 0x001EBD41
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
