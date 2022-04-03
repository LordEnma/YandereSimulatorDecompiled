using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000548 RID: 1352
	public abstract class VirtualInput
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002273 RID: 8819 RVA: 0x001F2929 File Offset: 0x001F0B29
		// (set) Token: 0x06002274 RID: 8820 RVA: 0x001F2931 File Offset: 0x001F0B31
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x06002275 RID: 8821 RVA: 0x001F293A File Offset: 0x001F0B3A
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x001F2948 File Offset: 0x001F0B48
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x001F2958 File Offset: 0x001F0B58
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

		// Token: 0x06002278 RID: 8824 RVA: 0x001F29C0 File Offset: 0x001F0BC0
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

		// Token: 0x06002279 RID: 8825 RVA: 0x001F2A26 File Offset: 0x001F0C26
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x001F2A43 File Offset: 0x001F0C43
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x001F2A60 File Offset: 0x001F0C60
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x001F2A7E File Offset: 0x001F0C7E
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x001F2AA2 File Offset: 0x001F0CA2
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x001F2AC6 File Offset: 0x001F0CC6
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x0600227F RID: 8831
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002280 RID: 8832
		public abstract bool GetButton(string name);

		// Token: 0x06002281 RID: 8833
		public abstract bool GetButtonDown(string name);

		// Token: 0x06002282 RID: 8834
		public abstract bool GetButtonUp(string name);

		// Token: 0x06002283 RID: 8835
		public abstract void SetButtonDown(string name);

		// Token: 0x06002284 RID: 8836
		public abstract void SetButtonUp(string name);

		// Token: 0x06002285 RID: 8837
		public abstract void SetAxisPositive(string name);

		// Token: 0x06002286 RID: 8838
		public abstract void SetAxisNegative(string name);

		// Token: 0x06002287 RID: 8839
		public abstract void SetAxisZero(string name);

		// Token: 0x06002288 RID: 8840
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002289 RID: 8841
		public abstract Vector3 MousePosition();

		// Token: 0x04004B08 RID: 19208
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004B09 RID: 19209
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004B0A RID: 19210
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
