using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053F RID: 1343
	public abstract class VirtualInput
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600224B RID: 8779 RVA: 0x001EF151 File Offset: 0x001ED351
		// (set) Token: 0x0600224C RID: 8780 RVA: 0x001EF159 File Offset: 0x001ED359
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x0600224D RID: 8781 RVA: 0x001EF162 File Offset: 0x001ED362
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001EF170 File Offset: 0x001ED370
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001EF180 File Offset: 0x001ED380
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

		// Token: 0x06002250 RID: 8784 RVA: 0x001EF1E8 File Offset: 0x001ED3E8
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

		// Token: 0x06002251 RID: 8785 RVA: 0x001EF24E File Offset: 0x001ED44E
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001EF26B File Offset: 0x001ED46B
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001EF288 File Offset: 0x001ED488
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001EF2A6 File Offset: 0x001ED4A6
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x001EF2CA File Offset: 0x001ED4CA
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x001EF2EE File Offset: 0x001ED4EE
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x06002257 RID: 8791
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002258 RID: 8792
		public abstract bool GetButton(string name);

		// Token: 0x06002259 RID: 8793
		public abstract bool GetButtonDown(string name);

		// Token: 0x0600225A RID: 8794
		public abstract bool GetButtonUp(string name);

		// Token: 0x0600225B RID: 8795
		public abstract void SetButtonDown(string name);

		// Token: 0x0600225C RID: 8796
		public abstract void SetButtonUp(string name);

		// Token: 0x0600225D RID: 8797
		public abstract void SetAxisPositive(string name);

		// Token: 0x0600225E RID: 8798
		public abstract void SetAxisNegative(string name);

		// Token: 0x0600225F RID: 8799
		public abstract void SetAxisZero(string name);

		// Token: 0x06002260 RID: 8800
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002261 RID: 8801
		public abstract Vector3 MousePosition();

		// Token: 0x04004A77 RID: 19063
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004A78 RID: 19064
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004A79 RID: 19065
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
