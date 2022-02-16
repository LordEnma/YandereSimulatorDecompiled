using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053D RID: 1341
	public abstract class VirtualInput
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600223C RID: 8764 RVA: 0x001EDB99 File Offset: 0x001EBD99
		// (set) Token: 0x0600223D RID: 8765 RVA: 0x001EDBA1 File Offset: 0x001EBDA1
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x0600223E RID: 8766 RVA: 0x001EDBAA File Offset: 0x001EBDAA
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x0600223F RID: 8767 RVA: 0x001EDBB8 File Offset: 0x001EBDB8
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x001EDBC8 File Offset: 0x001EBDC8
		public void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			if (this.m_VirtualAxes.ContainsKey(axis.name))
			{
				Debug.LogError("There is already a virtual axis named " + axis.name + " registered.");
				return;
			}
			this.m_VirtualAxes.Add(axis.name, axis);
			if (!axis.matchWithInputManager)
			{
				this.m_AlwaysUseVirtual.Add(axis.name);
			}
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x001EDC30 File Offset: 0x001EBE30
		public void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			if (this.m_VirtualButtons.ContainsKey(button.name))
			{
				Debug.LogError("There is already a virtual button named " + button.name + " registered.");
				return;
			}
			this.m_VirtualButtons.Add(button.name, button);
			if (!button.matchWithInputManager)
			{
				this.m_AlwaysUseVirtual.Add(button.name);
			}
		}

		// Token: 0x06002242 RID: 8770 RVA: 0x001EDC96 File Offset: 0x001EBE96
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x001EDCB3 File Offset: 0x001EBEB3
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x06002244 RID: 8772 RVA: 0x001EDCD0 File Offset: 0x001EBED0
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x001EDCEE File Offset: 0x001EBEEE
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x06002246 RID: 8774 RVA: 0x001EDD12 File Offset: 0x001EBF12
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x001EDD36 File Offset: 0x001EBF36
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x06002248 RID: 8776
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002249 RID: 8777
		public abstract bool GetButton(string name);

		// Token: 0x0600224A RID: 8778
		public abstract bool GetButtonDown(string name);

		// Token: 0x0600224B RID: 8779
		public abstract bool GetButtonUp(string name);

		// Token: 0x0600224C RID: 8780
		public abstract void SetButtonDown(string name);

		// Token: 0x0600224D RID: 8781
		public abstract void SetButtonUp(string name);

		// Token: 0x0600224E RID: 8782
		public abstract void SetAxisPositive(string name);

		// Token: 0x0600224F RID: 8783
		public abstract void SetAxisNegative(string name);

		// Token: 0x06002250 RID: 8784
		public abstract void SetAxisZero(string name);

		// Token: 0x06002251 RID: 8785
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002252 RID: 8786
		public abstract Vector3 MousePosition();

		// Token: 0x04004A4A RID: 19018
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004A4B RID: 19019
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004A4C RID: 19020
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
