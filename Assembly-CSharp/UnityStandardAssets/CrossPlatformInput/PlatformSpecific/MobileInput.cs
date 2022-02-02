using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053D RID: 1341
	public class MobileInput : VirtualInput
	{
		// Token: 0x06002248 RID: 8776 RVA: 0x001ED3B3 File Offset: 0x001EB5B3
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001ED3C0 File Offset: 0x001EB5C0
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x001ED3CD File Offset: 0x001EB5CD
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x001ED3F5 File Offset: 0x001EB5F5
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001ED41D File Offset: 0x001EB61D
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x001ED445 File Offset: 0x001EB645
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001ED472 File Offset: 0x001EB672
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001ED49F File Offset: 0x001EB69F
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001ED4CC File Offset: 0x001EB6CC
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x001ED4F5 File Offset: 0x001EB6F5
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001ED52F File Offset: 0x001EB72F
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001ED569 File Offset: 0x001EB769
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001ED5A3 File Offset: 0x001EB7A3
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
