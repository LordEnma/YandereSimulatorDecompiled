using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public abstract class VirtualInput
	{
		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x0600220B RID: 8715 RVA: 0x001E9595 File Offset: 0x001E7795
		// (set) Token: 0x0600220C RID: 8716 RVA: 0x001E959D File Offset: 0x001E779D
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x0600220D RID: 8717 RVA: 0x001E95A6 File Offset: 0x001E77A6
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x001E95B4 File Offset: 0x001E77B4
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001E95C4 File Offset: 0x001E77C4
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

		// Token: 0x06002210 RID: 8720 RVA: 0x001E962C File Offset: 0x001E782C
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

		// Token: 0x06002211 RID: 8721 RVA: 0x001E9692 File Offset: 0x001E7892
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06002212 RID: 8722 RVA: 0x001E96AF File Offset: 0x001E78AF
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x001E96CC File Offset: 0x001E78CC
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x06002214 RID: 8724 RVA: 0x001E96EA File Offset: 0x001E78EA
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x001E970E File Offset: 0x001E790E
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x001E9732 File Offset: 0x001E7932
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x06002217 RID: 8727
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06002218 RID: 8728
		public abstract bool GetButton(string name);

		// Token: 0x06002219 RID: 8729
		public abstract bool GetButtonDown(string name);

		// Token: 0x0600221A RID: 8730
		public abstract bool GetButtonUp(string name);

		// Token: 0x0600221B RID: 8731
		public abstract void SetButtonDown(string name);

		// Token: 0x0600221C RID: 8732
		public abstract void SetButtonUp(string name);

		// Token: 0x0600221D RID: 8733
		public abstract void SetAxisPositive(string name);

		// Token: 0x0600221E RID: 8734
		public abstract void SetAxisNegative(string name);

		// Token: 0x0600221F RID: 8735
		public abstract void SetAxisZero(string name);

		// Token: 0x06002220 RID: 8736
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002221 RID: 8737
		public abstract Vector3 MousePosition();

		// Token: 0x040049CA RID: 18890
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x040049CB RID: 18891
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x040049CC RID: 18892
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
