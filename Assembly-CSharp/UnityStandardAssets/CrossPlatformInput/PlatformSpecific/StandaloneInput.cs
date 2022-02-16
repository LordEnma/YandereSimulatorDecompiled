using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053F RID: 1343
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002262 RID: 8802 RVA: 0x001EDF83 File Offset: 0x001EC183
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x001EDF95 File Offset: 0x001EC195
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x001EDF9D File Offset: 0x001EC19D
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x001EDFA5 File Offset: 0x001EC1A5
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x001EDFAD File Offset: 0x001EC1AD
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x001EDFB9 File Offset: 0x001EC1B9
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x001EDFC5 File Offset: 0x001EC1C5
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x001EDFD1 File Offset: 0x001EC1D1
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001EDFDD File Offset: 0x001EC1DD
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001EDFE9 File Offset: 0x001EC1E9
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001EDFF5 File Offset: 0x001EC1F5
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
