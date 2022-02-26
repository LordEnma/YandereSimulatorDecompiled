using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053F RID: 1343
	public class MobileInput : VirtualInput
	{
		// Token: 0x0600225D RID: 8797 RVA: 0x001EE963 File Offset: 0x001ECB63
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001EE970 File Offset: 0x001ECB70
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001EE97D File Offset: 0x001ECB7D
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x001EE9A5 File Offset: 0x001ECBA5
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001EE9CD File Offset: 0x001ECBCD
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x001EE9F5 File Offset: 0x001ECBF5
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x001EEA22 File Offset: 0x001ECC22
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x001EEA4F File Offset: 0x001ECC4F
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x001EEA7C File Offset: 0x001ECC7C
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x001EEAA5 File Offset: 0x001ECCA5
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x001EEADF File Offset: 0x001ECCDF
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x001EEB19 File Offset: 0x001ECD19
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x001EEB53 File Offset: 0x001ECD53
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
