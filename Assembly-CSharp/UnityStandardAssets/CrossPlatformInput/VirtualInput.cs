using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000539 RID: 1337
	public abstract class VirtualInput
	{
		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x0600221C RID: 8732 RVA: 0x001EACC9 File Offset: 0x001E8EC9
		// (set) Token: 0x0600221D RID: 8733 RVA: 0x001EACD1 File Offset: 0x001E8ED1
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x0600221E RID: 8734 RVA: 0x001EACDA File Offset: 0x001E8EDA
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001EACE8 File Offset: 0x001E8EE8
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001EACF8 File Offset: 0x001E8EF8
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

		// Token: 0x06002221 RID: 8737 RVA: 0x001EAD60 File Offset: 0x001E8F60
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

		// Token: 0x06002222 RID: 8738 RVA: 0x001EADC6 File Offset: 0x001E8FC6
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06002223 RID: 8739 RVA: 0x001EADE3 File Offset: 0x001E8FE3
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001EAE00 File Offset: 0x001E9000
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x001EAE1E File Offset: 0x001E901E
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x001EAE42 File Offset: 0x001E9042
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x06002227 RID: 8743 RVA: 0x001EAE66 File Offset: 0x001E9066
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x06002228 RID: 8744
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002229 RID: 8745
		public abstract bool GetButton(string name);

		// Token: 0x0600222A RID: 8746
		public abstract bool GetButtonDown(string name);

		// Token: 0x0600222B RID: 8747
		public abstract bool GetButtonUp(string name);

		// Token: 0x0600222C RID: 8748
		public abstract void SetButtonDown(string name);

		// Token: 0x0600222D RID: 8749
		public abstract void SetButtonUp(string name);

		// Token: 0x0600222E RID: 8750
		public abstract void SetAxisPositive(string name);

		// Token: 0x0600222F RID: 8751
		public abstract void SetAxisNegative(string name);

		// Token: 0x06002230 RID: 8752
		public abstract void SetAxisZero(string name);

		// Token: 0x06002231 RID: 8753
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002232 RID: 8754
		public abstract Vector3 MousePosition();

		// Token: 0x04004A09 RID: 18953
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004A0A RID: 18954
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004A0B RID: 18955
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
