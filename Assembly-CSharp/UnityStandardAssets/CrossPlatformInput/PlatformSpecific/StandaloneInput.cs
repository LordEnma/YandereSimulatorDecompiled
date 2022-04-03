using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054A RID: 1354
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06002299 RID: 8857 RVA: 0x001F2D13 File Offset: 0x001F0F13
		public override float GetAxis(string name, bool raw)
		{
			if (!raw)
			{
				return Input.GetAxis(name);
			}
			return Input.GetAxisRaw(name);
		}

		// Token: 0x0600229A RID: 8858 RVA: 0x001F2D25 File Offset: 0x001F0F25
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x0600229B RID: 8859 RVA: 0x001F2D2D File Offset: 0x001F0F2D
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x0600229C RID: 8860 RVA: 0x001F2D35 File Offset: 0x001F0F35
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x0600229D RID: 8861 RVA: 0x001F2D3D File Offset: 0x001F0F3D
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600229E RID: 8862 RVA: 0x001F2D49 File Offset: 0x001F0F49
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x0600229F RID: 8863 RVA: 0x001F2D55 File Offset: 0x001F0F55
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022A0 RID: 8864 RVA: 0x001F2D61 File Offset: 0x001F0F61
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022A1 RID: 8865 RVA: 0x001F2D6D File Offset: 0x001F0F6D
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022A2 RID: 8866 RVA: 0x001F2D79 File Offset: 0x001F0F79
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x060022A3 RID: 8867 RVA: 0x001F2D85 File Offset: 0x001F0F85
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
