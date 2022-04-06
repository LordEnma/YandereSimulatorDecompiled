using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000549 RID: 1353
	public abstract class VirtualInput
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600227B RID: 8827 RVA: 0x001F2E59 File Offset: 0x001F1059
		// (set) Token: 0x0600227C RID: 8828 RVA: 0x001F2E61 File Offset: 0x001F1061
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x0600227D RID: 8829 RVA: 0x001F2E6A File Offset: 0x001F106A
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x001F2E78 File Offset: 0x001F1078
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x001F2E88 File Offset: 0x001F1088
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

		// Token: 0x06002280 RID: 8832 RVA: 0x001F2EF0 File Offset: 0x001F10F0
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

		// Token: 0x06002281 RID: 8833 RVA: 0x001F2F56 File Offset: 0x001F1156
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x001F2F73 File Offset: 0x001F1173
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x001F2F90 File Offset: 0x001F1190
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x001F2FAE File Offset: 0x001F11AE
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x001F2FD2 File Offset: 0x001F11D2
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x001F2FF6 File Offset: 0x001F11F6
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x06002287 RID: 8839
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002288 RID: 8840
		public abstract bool GetButton(string name);

		// Token: 0x06002289 RID: 8841
		public abstract bool GetButtonDown(string name);

		// Token: 0x0600228A RID: 8842
		public abstract bool GetButtonUp(string name);

		// Token: 0x0600228B RID: 8843
		public abstract void SetButtonDown(string name);

		// Token: 0x0600228C RID: 8844
		public abstract void SetButtonUp(string name);

		// Token: 0x0600228D RID: 8845
		public abstract void SetAxisPositive(string name);

		// Token: 0x0600228E RID: 8846
		public abstract void SetAxisNegative(string name);

		// Token: 0x0600228F RID: 8847
		public abstract void SetAxisZero(string name);

		// Token: 0x06002290 RID: 8848
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002291 RID: 8849
		public abstract Vector3 MousePosition();

		// Token: 0x04004B0C RID: 19212
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004B0D RID: 19213
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004B0E RID: 19214
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
