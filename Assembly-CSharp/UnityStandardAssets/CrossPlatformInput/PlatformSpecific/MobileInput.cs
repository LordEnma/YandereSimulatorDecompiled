using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054B RID: 1355
	public class MobileInput : VirtualInput
	{
		// Token: 0x060022A4 RID: 8868 RVA: 0x001F5027 File Offset: 0x001F3227
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x060022A5 RID: 8869 RVA: 0x001F5034 File Offset: 0x001F3234
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x060022A6 RID: 8870 RVA: 0x001F5041 File Offset: 0x001F3241
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x060022A7 RID: 8871 RVA: 0x001F5069 File Offset: 0x001F3269
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x060022A8 RID: 8872 RVA: 0x001F5091 File Offset: 0x001F3291
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x060022A9 RID: 8873 RVA: 0x001F50B9 File Offset: 0x001F32B9
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x001F50E6 File Offset: 0x001F32E6
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x001F5113 File Offset: 0x001F3313
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x001F5140 File Offset: 0x001F3340
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x001F5169 File Offset: 0x001F3369
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x001F51A3 File Offset: 0x001F33A3
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x060022AF RID: 8879 RVA: 0x001F51DD File Offset: 0x001F33DD
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x001F5217 File Offset: 0x001F3417
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
