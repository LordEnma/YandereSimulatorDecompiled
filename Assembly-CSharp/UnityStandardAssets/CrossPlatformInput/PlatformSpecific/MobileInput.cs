using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054C RID: 1356
	public class MobileInput : VirtualInput
	{
		// Token: 0x060022AF RID: 8879 RVA: 0x001F6BDF File Offset: 0x001F4DDF
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x001F6BEC File Offset: 0x001F4DEC
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x001F6BF9 File Offset: 0x001F4DF9
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x001F6C21 File Offset: 0x001F4E21
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x001F6C49 File Offset: 0x001F4E49
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x001F6C71 File Offset: 0x001F4E71
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x001F6C9E File Offset: 0x001F4E9E
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x060022B6 RID: 8886 RVA: 0x001F6CCB File Offset: 0x001F4ECB
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x060022B7 RID: 8887 RVA: 0x001F6CF8 File Offset: 0x001F4EF8
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x060022B8 RID: 8888 RVA: 0x001F6D21 File Offset: 0x001F4F21
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x001F6D5B File Offset: 0x001F4F5B
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x001F6D95 File Offset: 0x001F4F95
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x060022BB RID: 8891 RVA: 0x001F6DCF File Offset: 0x001F4FCF
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
