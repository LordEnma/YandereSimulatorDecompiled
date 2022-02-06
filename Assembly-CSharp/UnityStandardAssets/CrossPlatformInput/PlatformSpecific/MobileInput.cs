using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053D RID: 1341
	public class MobileInput : VirtualInput
	{
		// Token: 0x0600224D RID: 8781 RVA: 0x001ED8CF File Offset: 0x001EBACF
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001ED8DC File Offset: 0x001EBADC
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001ED8E9 File Offset: 0x001EBAE9
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001ED911 File Offset: 0x001EBB11
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x001ED939 File Offset: 0x001EBB39
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001ED961 File Offset: 0x001EBB61
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001ED98E File Offset: 0x001EBB8E
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001ED9BB File Offset: 0x001EBBBB
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x001ED9E8 File Offset: 0x001EBBE8
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x001EDA11 File Offset: 0x001EBC11
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x001EDA4B File Offset: 0x001EBC4B
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001EDA85 File Offset: 0x001EBC85
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x001EDABF File Offset: 0x001EBCBF
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
