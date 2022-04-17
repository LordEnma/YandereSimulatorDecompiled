using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200054A RID: 1354
	public class MobileInput : VirtualInput
	{
		// Token: 0x0600229A RID: 8858 RVA: 0x001F3A9F File Offset: 0x001F1C9F
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x0600229B RID: 8859 RVA: 0x001F3AAC File Offset: 0x001F1CAC
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x0600229C RID: 8860 RVA: 0x001F3AB9 File Offset: 0x001F1CB9
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x0600229D RID: 8861 RVA: 0x001F3AE1 File Offset: 0x001F1CE1
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x0600229E RID: 8862 RVA: 0x001F3B09 File Offset: 0x001F1D09
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x0600229F RID: 8863 RVA: 0x001F3B31 File Offset: 0x001F1D31
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x060022A0 RID: 8864 RVA: 0x001F3B5E File Offset: 0x001F1D5E
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x060022A1 RID: 8865 RVA: 0x001F3B8B File Offset: 0x001F1D8B
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x060022A2 RID: 8866 RVA: 0x001F3BB8 File Offset: 0x001F1DB8
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x060022A3 RID: 8867 RVA: 0x001F3BE1 File Offset: 0x001F1DE1
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x060022A4 RID: 8868 RVA: 0x001F3C1B File Offset: 0x001F1E1B
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x060022A5 RID: 8869 RVA: 0x001F3C55 File Offset: 0x001F1E55
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x060022A6 RID: 8870 RVA: 0x001F3C8F File Offset: 0x001F1E8F
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
