using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053A RID: 1338
	public class MobileInput : VirtualInput
	{
		// Token: 0x06002237 RID: 8759 RVA: 0x001EB4A3 File Offset: 0x001E96A3
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x001EB4B0 File Offset: 0x001E96B0
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x001EB4BD File Offset: 0x001E96BD
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x001EB4E5 File Offset: 0x001E96E5
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x0600223B RID: 8763 RVA: 0x001EB50D File Offset: 0x001E970D
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x0600223C RID: 8764 RVA: 0x001EB535 File Offset: 0x001E9735
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x001EB562 File Offset: 0x001E9762
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x001EB58F File Offset: 0x001E978F
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x0600223F RID: 8767 RVA: 0x001EB5BC File Offset: 0x001E97BC
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x001EB5E5 File Offset: 0x001E97E5
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x001EB61F File Offset: 0x001E981F
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x06002242 RID: 8770 RVA: 0x001EB659 File Offset: 0x001E9859
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x001EB693 File Offset: 0x001E9893
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
