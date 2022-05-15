using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200054B RID: 1355
	public abstract class VirtualInput
	{
		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06002296 RID: 8854 RVA: 0x001F648D File Offset: 0x001F468D
		// (set) Token: 0x06002297 RID: 8855 RVA: 0x001F6495 File Offset: 0x001F4695
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x06002298 RID: 8856 RVA: 0x001F649E File Offset: 0x001F469E
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x06002299 RID: 8857 RVA: 0x001F64AC File Offset: 0x001F46AC
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x0600229A RID: 8858 RVA: 0x001F64BC File Offset: 0x001F46BC
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

		// Token: 0x0600229B RID: 8859 RVA: 0x001F6524 File Offset: 0x001F4724
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

		// Token: 0x0600229C RID: 8860 RVA: 0x001F658A File Offset: 0x001F478A
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x0600229D RID: 8861 RVA: 0x001F65A7 File Offset: 0x001F47A7
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x0600229E RID: 8862 RVA: 0x001F65C4 File Offset: 0x001F47C4
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x0600229F RID: 8863 RVA: 0x001F65E2 File Offset: 0x001F47E2
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x060022A0 RID: 8864 RVA: 0x001F6606 File Offset: 0x001F4806
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x060022A1 RID: 8865 RVA: 0x001F662A File Offset: 0x001F482A
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x060022A2 RID: 8866
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x060022A3 RID: 8867
		public abstract bool GetButton(string name);

		// Token: 0x060022A4 RID: 8868
		public abstract bool GetButtonDown(string name);

		// Token: 0x060022A5 RID: 8869
		public abstract bool GetButtonUp(string name);

		// Token: 0x060022A6 RID: 8870
		public abstract void SetButtonDown(string name);

		// Token: 0x060022A7 RID: 8871
		public abstract void SetButtonUp(string name);

		// Token: 0x060022A8 RID: 8872
		public abstract void SetAxisPositive(string name);

		// Token: 0x060022A9 RID: 8873
		public abstract void SetAxisNegative(string name);

		// Token: 0x060022AA RID: 8874
		public abstract void SetAxisZero(string name);

		// Token: 0x060022AB RID: 8875
		public abstract void SetAxis(string name, float value);

		// Token: 0x060022AC RID: 8876
		public abstract Vector3 MousePosition();

		// Token: 0x04004B5B RID: 19291
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004B5C RID: 19292
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004B5D RID: 19293
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
