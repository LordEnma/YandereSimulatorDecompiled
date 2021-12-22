using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053A RID: 1338
	public class MobileInput : VirtualInput
	{
		// Token: 0x06002234 RID: 8756 RVA: 0x001EAEB3 File Offset: 0x001E90B3
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x001EAEC0 File Offset: 0x001E90C0
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x001EAECD File Offset: 0x001E90CD
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x001EAEF5 File Offset: 0x001E90F5
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x001EAF1D File Offset: 0x001E911D
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x001EAF45 File Offset: 0x001E9145
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x001EAF72 File Offset: 0x001E9172
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x0600223B RID: 8763 RVA: 0x001EAF9F File Offset: 0x001E919F
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x0600223C RID: 8764 RVA: 0x001EAFCC File Offset: 0x001E91CC
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x001EAFF5 File Offset: 0x001E91F5
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x001EB02F File Offset: 0x001E922F
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x0600223F RID: 8767 RVA: 0x001EB069 File Offset: 0x001E9269
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x001EB0A3 File Offset: 0x001E92A3
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
