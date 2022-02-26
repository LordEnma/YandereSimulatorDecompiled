using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053E RID: 1342
	public abstract class VirtualInput
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002245 RID: 8773 RVA: 0x001EE779 File Offset: 0x001EC979
		// (set) Token: 0x06002246 RID: 8774 RVA: 0x001EE781 File Offset: 0x001EC981
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x06002247 RID: 8775 RVA: 0x001EE78A File Offset: 0x001EC98A
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x001EE798 File Offset: 0x001EC998
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001EE7A8 File Offset: 0x001EC9A8
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

		// Token: 0x0600224A RID: 8778 RVA: 0x001EE810 File Offset: 0x001ECA10
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

		// Token: 0x0600224B RID: 8779 RVA: 0x001EE876 File Offset: 0x001ECA76
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001EE893 File Offset: 0x001ECA93
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x001EE8B0 File Offset: 0x001ECAB0
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001EE8CE File Offset: 0x001ECACE
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001EE8F2 File Offset: 0x001ECAF2
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001EE916 File Offset: 0x001ECB16
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x06002251 RID: 8785
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002252 RID: 8786
		public abstract bool GetButton(string name);

		// Token: 0x06002253 RID: 8787
		public abstract bool GetButtonDown(string name);

		// Token: 0x06002254 RID: 8788
		public abstract bool GetButtonUp(string name);

		// Token: 0x06002255 RID: 8789
		public abstract void SetButtonDown(string name);

		// Token: 0x06002256 RID: 8790
		public abstract void SetButtonUp(string name);

		// Token: 0x06002257 RID: 8791
		public abstract void SetAxisPositive(string name);

		// Token: 0x06002258 RID: 8792
		public abstract void SetAxisNegative(string name);

		// Token: 0x06002259 RID: 8793
		public abstract void SetAxisZero(string name);

		// Token: 0x0600225A RID: 8794
		public abstract void SetAxis(string name, float value);

		// Token: 0x0600225B RID: 8795
		public abstract Vector3 MousePosition();

		// Token: 0x04004A5A RID: 19034
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004A5B RID: 19035
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004A5C RID: 19036
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
