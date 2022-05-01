using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054B RID: 1355
	public class MobileInput : VirtualInput
	{
		// Token: 0x060022A3 RID: 8867 RVA: 0x001F4F2B File Offset: 0x001F312B
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x060022A4 RID: 8868 RVA: 0x001F4F38 File Offset: 0x001F3138
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x060022A5 RID: 8869 RVA: 0x001F4F45 File Offset: 0x001F3145
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x060022A6 RID: 8870 RVA: 0x001F4F6D File Offset: 0x001F316D
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x060022A7 RID: 8871 RVA: 0x001F4F95 File Offset: 0x001F3195
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x060022A8 RID: 8872 RVA: 0x001F4FBD File Offset: 0x001F31BD
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x060022A9 RID: 8873 RVA: 0x001F4FEA File Offset: 0x001F31EA
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x001F5017 File Offset: 0x001F3217
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x001F5044 File Offset: 0x001F3244
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x001F506D File Offset: 0x001F326D
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x001F50A7 File Offset: 0x001F32A7
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x001F50E1 File Offset: 0x001F32E1
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x060022AF RID: 8879 RVA: 0x001F511B File Offset: 0x001F331B
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
