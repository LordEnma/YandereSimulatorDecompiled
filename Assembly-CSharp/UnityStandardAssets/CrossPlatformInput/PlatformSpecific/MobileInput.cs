using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x02000538 RID: 1336
	public class MobileInput : VirtualInput
	{
		// Token: 0x06002223 RID: 8739 RVA: 0x001E977F File Offset: 0x001E797F
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001E978C File Offset: 0x001E798C
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x001E9799 File Offset: 0x001E7999
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x001E97C1 File Offset: 0x001E79C1
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x06002227 RID: 8743 RVA: 0x001E97E9 File Offset: 0x001E79E9
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x001E9811 File Offset: 0x001E7A11
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x001E983E File Offset: 0x001E7A3E
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x0600222A RID: 8746 RVA: 0x001E986B File Offset: 0x001E7A6B
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x0600222B RID: 8747 RVA: 0x001E9898 File Offset: 0x001E7A98
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x001E98C1 File Offset: 0x001E7AC1
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x001E98FB File Offset: 0x001E7AFB
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x0600222E RID: 8750 RVA: 0x001E9935 File Offset: 0x001E7B35
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x0600222F RID: 8751 RVA: 0x001E996F File Offset: 0x001E7B6F
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
