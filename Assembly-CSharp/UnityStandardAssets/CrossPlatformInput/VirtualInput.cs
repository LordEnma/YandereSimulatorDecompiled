using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000549 RID: 1353
	public abstract class VirtualInput
	{
		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06002282 RID: 8834 RVA: 0x001F38B5 File Offset: 0x001F1AB5
		// (set) Token: 0x06002283 RID: 8835 RVA: 0x001F38BD File Offset: 0x001F1ABD
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x06002284 RID: 8836 RVA: 0x001F38C6 File Offset: 0x001F1AC6
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x001F38D4 File Offset: 0x001F1AD4
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x001F38E4 File Offset: 0x001F1AE4
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

		// Token: 0x06002287 RID: 8839 RVA: 0x001F394C File Offset: 0x001F1B4C
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

		// Token: 0x06002288 RID: 8840 RVA: 0x001F39B2 File Offset: 0x001F1BB2
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06002289 RID: 8841 RVA: 0x001F39CF File Offset: 0x001F1BCF
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x001F39EC File Offset: 0x001F1BEC
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x001F3A0A File Offset: 0x001F1C0A
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x001F3A2E File Offset: 0x001F1C2E
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x001F3A52 File Offset: 0x001F1C52
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x0600228E RID: 8846
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x0600228F RID: 8847
		public abstract bool GetButton(string name);

		// Token: 0x06002290 RID: 8848
		public abstract bool GetButtonDown(string name);

		// Token: 0x06002291 RID: 8849
		public abstract bool GetButtonUp(string name);

		// Token: 0x06002292 RID: 8850
		public abstract void SetButtonDown(string name);

		// Token: 0x06002293 RID: 8851
		public abstract void SetButtonUp(string name);

		// Token: 0x06002294 RID: 8852
		public abstract void SetAxisPositive(string name);

		// Token: 0x06002295 RID: 8853
		public abstract void SetAxisNegative(string name);

		// Token: 0x06002296 RID: 8854
		public abstract void SetAxisZero(string name);

		// Token: 0x06002297 RID: 8855
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002298 RID: 8856
		public abstract Vector3 MousePosition();

		// Token: 0x04004B1E RID: 19230
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004B1F RID: 19231
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004B20 RID: 19232
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
