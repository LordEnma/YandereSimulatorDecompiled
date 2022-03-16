using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000543 RID: 1347
	public abstract class VirtualInput
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002263 RID: 8803 RVA: 0x001F10B9 File Offset: 0x001EF2B9
		// (set) Token: 0x06002264 RID: 8804 RVA: 0x001F10C1 File Offset: 0x001EF2C1
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x06002265 RID: 8805 RVA: 0x001F10CA File Offset: 0x001EF2CA
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x001F10D8 File Offset: 0x001EF2D8
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x001F10E8 File Offset: 0x001EF2E8
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

		// Token: 0x06002268 RID: 8808 RVA: 0x001F1150 File Offset: 0x001EF350
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

		// Token: 0x06002269 RID: 8809 RVA: 0x001F11B6 File Offset: 0x001EF3B6
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001F11D3 File Offset: 0x001EF3D3
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001F11F0 File Offset: 0x001EF3F0
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001F120E File Offset: 0x001EF40E
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001F1232 File Offset: 0x001EF432
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x001F1256 File Offset: 0x001EF456
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x0600226F RID: 8815
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002270 RID: 8816
		public abstract bool GetButton(string name);

		// Token: 0x06002271 RID: 8817
		public abstract bool GetButtonDown(string name);

		// Token: 0x06002272 RID: 8818
		public abstract bool GetButtonUp(string name);

		// Token: 0x06002273 RID: 8819
		public abstract void SetButtonDown(string name);

		// Token: 0x06002274 RID: 8820
		public abstract void SetButtonUp(string name);

		// Token: 0x06002275 RID: 8821
		public abstract void SetAxisPositive(string name);

		// Token: 0x06002276 RID: 8822
		public abstract void SetAxisNegative(string name);

		// Token: 0x06002277 RID: 8823
		public abstract void SetAxisZero(string name);

		// Token: 0x06002278 RID: 8824
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002279 RID: 8825
		public abstract Vector3 MousePosition();

		// Token: 0x04004AD6 RID: 19158
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004AD7 RID: 19159
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004AD8 RID: 19160
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
