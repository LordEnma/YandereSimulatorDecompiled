using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x02000540 RID: 1344
	public class MobileInput : VirtualInput
	{
		// Token: 0x06002263 RID: 8803 RVA: 0x001EF33B File Offset: 0x001ED53B
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x001EF348 File Offset: 0x001ED548
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x001EF355 File Offset: 0x001ED555
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x001EF37D File Offset: 0x001ED57D
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x001EF3A5 File Offset: 0x001ED5A5
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x001EF3CD File Offset: 0x001ED5CD
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x001EF3FA File Offset: 0x001ED5FA
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001EF427 File Offset: 0x001ED627
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001EF454 File Offset: 0x001ED654
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001EF47D File Offset: 0x001ED67D
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001EF4B7 File Offset: 0x001ED6B7
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x001EF4F1 File Offset: 0x001ED6F1
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x001EF52B File Offset: 0x001ED72B
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
