using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200054A RID: 1354
	public abstract class VirtualInput
	{
		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x0600228B RID: 8843 RVA: 0x001F4D41 File Offset: 0x001F2F41
		// (set) Token: 0x0600228C RID: 8844 RVA: 0x001F4D49 File Offset: 0x001F2F49
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x0600228D RID: 8845 RVA: 0x001F4D52 File Offset: 0x001F2F52
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x001F4D60 File Offset: 0x001F2F60
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x0600228F RID: 8847 RVA: 0x001F4D70 File Offset: 0x001F2F70
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

		// Token: 0x06002290 RID: 8848 RVA: 0x001F4DD8 File Offset: 0x001F2FD8
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

		// Token: 0x06002291 RID: 8849 RVA: 0x001F4E3E File Offset: 0x001F303E
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x001F4E5B File Offset: 0x001F305B
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x06002293 RID: 8851 RVA: 0x001F4E78 File Offset: 0x001F3078
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x06002294 RID: 8852 RVA: 0x001F4E96 File Offset: 0x001F3096
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x06002295 RID: 8853 RVA: 0x001F4EBA File Offset: 0x001F30BA
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x06002296 RID: 8854 RVA: 0x001F4EDE File Offset: 0x001F30DE
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x06002297 RID: 8855
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002298 RID: 8856
		public abstract bool GetButton(string name);

		// Token: 0x06002299 RID: 8857
		public abstract bool GetButtonDown(string name);

		// Token: 0x0600229A RID: 8858
		public abstract bool GetButtonUp(string name);

		// Token: 0x0600229B RID: 8859
		public abstract void SetButtonDown(string name);

		// Token: 0x0600229C RID: 8860
		public abstract void SetButtonUp(string name);

		// Token: 0x0600229D RID: 8861
		public abstract void SetAxisPositive(string name);

		// Token: 0x0600229E RID: 8862
		public abstract void SetAxisNegative(string name);

		// Token: 0x0600229F RID: 8863
		public abstract void SetAxisZero(string name);

		// Token: 0x060022A0 RID: 8864
		public abstract void SetAxis(string name, float value);

		// Token: 0x060022A1 RID: 8865
		public abstract Vector3 MousePosition();

		// Token: 0x04004B34 RID: 19252
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004B35 RID: 19253
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004B36 RID: 19254
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
