using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x02000549 RID: 1353
	public class MobileInput : VirtualInput
	{
		// Token: 0x0600228B RID: 8843 RVA: 0x001F2B13 File Offset: 0x001F0D13
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x001F2B20 File Offset: 0x001F0D20
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x001F2B2D File Offset: 0x001F0D2D
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x001F2B55 File Offset: 0x001F0D55
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x0600228F RID: 8847 RVA: 0x001F2B7D File Offset: 0x001F0D7D
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x06002290 RID: 8848 RVA: 0x001F2BA5 File Offset: 0x001F0DA5
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x06002291 RID: 8849 RVA: 0x001F2BD2 File Offset: 0x001F0DD2
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x001F2BFF File Offset: 0x001F0DFF
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x06002293 RID: 8851 RVA: 0x001F2C2C File Offset: 0x001F0E2C
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x06002294 RID: 8852 RVA: 0x001F2C55 File Offset: 0x001F0E55
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x06002295 RID: 8853 RVA: 0x001F2C8F File Offset: 0x001F0E8F
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x06002296 RID: 8854 RVA: 0x001F2CC9 File Offset: 0x001F0EC9
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x06002297 RID: 8855 RVA: 0x001F2D03 File Offset: 0x001F0F03
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
