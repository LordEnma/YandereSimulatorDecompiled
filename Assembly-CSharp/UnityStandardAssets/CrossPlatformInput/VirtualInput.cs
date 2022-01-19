using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053C RID: 1340
	public abstract class VirtualInput
	{
		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x0600222C RID: 8748 RVA: 0x001EC929 File Offset: 0x001EAB29
		// (set) Token: 0x0600222D RID: 8749 RVA: 0x001EC931 File Offset: 0x001EAB31
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x0600222E RID: 8750 RVA: 0x001EC93A File Offset: 0x001EAB3A
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x0600222F RID: 8751 RVA: 0x001EC948 File Offset: 0x001EAB48
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x06002230 RID: 8752 RVA: 0x001EC958 File Offset: 0x001EAB58
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

		// Token: 0x06002231 RID: 8753 RVA: 0x001EC9C0 File Offset: 0x001EABC0
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

		// Token: 0x06002232 RID: 8754 RVA: 0x001ECA26 File Offset: 0x001EAC26
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x001ECA43 File Offset: 0x001EAC43
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x001ECA60 File Offset: 0x001EAC60
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x001ECA7E File Offset: 0x001EAC7E
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x001ECAA2 File Offset: 0x001EACA2
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x001ECAC6 File Offset: 0x001EACC6
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x06002238 RID: 8760
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002239 RID: 8761
		public abstract bool GetButton(string name);

		// Token: 0x0600223A RID: 8762
		public abstract bool GetButtonDown(string name);

		// Token: 0x0600223B RID: 8763
		public abstract bool GetButtonUp(string name);

		// Token: 0x0600223C RID: 8764
		public abstract void SetButtonDown(string name);

		// Token: 0x0600223D RID: 8765
		public abstract void SetButtonUp(string name);

		// Token: 0x0600223E RID: 8766
		public abstract void SetAxisPositive(string name);

		// Token: 0x0600223F RID: 8767
		public abstract void SetAxisNegative(string name);

		// Token: 0x06002240 RID: 8768
		public abstract void SetAxisZero(string name);

		// Token: 0x06002241 RID: 8769
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002242 RID: 8770
		public abstract Vector3 MousePosition();

		// Token: 0x04004A2D RID: 18989
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004A2E RID: 18990
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004A2F RID: 18991
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
