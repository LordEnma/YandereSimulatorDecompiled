using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054C RID: 1356
	public class MobileInput : VirtualInput
	{
		// Token: 0x060022AE RID: 8878 RVA: 0x001F6677 File Offset: 0x001F4877
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x060022AF RID: 8879 RVA: 0x001F6684 File Offset: 0x001F4884
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x001F6691 File Offset: 0x001F4891
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x001F66B9 File Offset: 0x001F48B9
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x001F66E1 File Offset: 0x001F48E1
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x001F6709 File Offset: 0x001F4909
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x001F6736 File Offset: 0x001F4936
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x001F6763 File Offset: 0x001F4963
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x060022B6 RID: 8886 RVA: 0x001F6790 File Offset: 0x001F4990
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x060022B7 RID: 8887 RVA: 0x001F67B9 File Offset: 0x001F49B9
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x060022B8 RID: 8888 RVA: 0x001F67F3 File Offset: 0x001F49F3
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x001F682D File Offset: 0x001F4A2D
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x001F6867 File Offset: 0x001F4A67
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
