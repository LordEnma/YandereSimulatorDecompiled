using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053C RID: 1340
	public abstract class VirtualInput
	{
		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06002230 RID: 8752 RVA: 0x001ED1C9 File Offset: 0x001EB3C9
		// (set) Token: 0x06002231 RID: 8753 RVA: 0x001ED1D1 File Offset: 0x001EB3D1
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x06002232 RID: 8754 RVA: 0x001ED1DA File Offset: 0x001EB3DA
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x001ED1E8 File Offset: 0x001EB3E8
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x001ED1F8 File Offset: 0x001EB3F8
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

		// Token: 0x06002235 RID: 8757 RVA: 0x001ED260 File Offset: 0x001EB460
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

		// Token: 0x06002236 RID: 8758 RVA: 0x001ED2C6 File Offset: 0x001EB4C6
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x001ED2E3 File Offset: 0x001EB4E3
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x001ED300 File Offset: 0x001EB500
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				return null;
			}
			return this.m_VirtualAxes[name];
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x001ED31E File Offset: 0x001EB51E
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x001ED342 File Offset: 0x001EB542
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x0600223B RID: 8763 RVA: 0x001ED366 File Offset: 0x001EB566
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x0600223C RID: 8764
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x0600223D RID: 8765
		public abstract bool GetButton(string name);

		// Token: 0x0600223E RID: 8766
		public abstract bool GetButtonDown(string name);

		// Token: 0x0600223F RID: 8767
		public abstract bool GetButtonUp(string name);

		// Token: 0x06002240 RID: 8768
		public abstract void SetButtonDown(string name);

		// Token: 0x06002241 RID: 8769
		public abstract void SetButtonUp(string name);

		// Token: 0x06002242 RID: 8770
		public abstract void SetAxisPositive(string name);

		// Token: 0x06002243 RID: 8771
		public abstract void SetAxisNegative(string name);

		// Token: 0x06002244 RID: 8772
		public abstract void SetAxisZero(string name);

		// Token: 0x06002245 RID: 8773
		public abstract void SetAxis(string name, float value);

		// Token: 0x06002246 RID: 8774
		public abstract Vector3 MousePosition();

		// Token: 0x04004A38 RID: 19000
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x04004A39 RID: 19001
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x04004A3A RID: 19002
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
