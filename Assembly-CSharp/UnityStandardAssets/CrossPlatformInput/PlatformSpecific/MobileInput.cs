using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x0200053D RID: 1341
	public class MobileInput : VirtualInput
	{
		// Token: 0x06002244 RID: 8772 RVA: 0x001ECB13 File Offset: 0x001EAD13
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x001ECB20 File Offset: 0x001EAD20
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x06002246 RID: 8774 RVA: 0x001ECB2D File Offset: 0x001EAD2D
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x001ECB55 File Offset: 0x001EAD55
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x001ECB7D File Offset: 0x001EAD7D
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001ECBA5 File Offset: 0x001EADA5
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x001ECBD2 File Offset: 0x001EADD2
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x001ECBFF File Offset: 0x001EADFF
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001ECC2C File Offset: 0x001EAE2C
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x001ECC55 File Offset: 0x001EAE55
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001ECC8F File Offset: 0x001EAE8F
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001ECCC9 File Offset: 0x001EAEC9
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001ECD03 File Offset: 0x001EAF03
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
