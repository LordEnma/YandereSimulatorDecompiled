using System;
using UnityEngine;

// Token: 0x02000063 RID: 99
public class UIShowControlScheme : MonoBehaviour
{
	// Token: 0x060002B0 RID: 688 RVA: 0x0001DEA3 File Offset: 0x0001C0A3
	private void OnEnable()
	{
		UICamera.onSchemeChange = (UICamera.OnSchemeChange)Delegate.Combine(UICamera.onSchemeChange, new UICamera.OnSchemeChange(this.OnScheme));
		this.OnScheme();
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x0001DECB File Offset: 0x0001C0CB
	private void OnDisable()
	{
		UICamera.onSchemeChange = (UICamera.OnSchemeChange)Delegate.Remove(UICamera.onSchemeChange, new UICamera.OnSchemeChange(this.OnScheme));
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x0001DEF0 File Offset: 0x0001C0F0
	private void OnScheme()
	{
		if (this.target != null)
		{
			UICamera.ControlScheme currentScheme = UICamera.currentScheme;
			if (currentScheme == UICamera.ControlScheme.Mouse)
			{
				this.target.SetActive(this.mouse);
				return;
			}
			if (currentScheme == UICamera.ControlScheme.Touch)
			{
				this.target.SetActive(this.touch);
				return;
			}
			if (currentScheme == UICamera.ControlScheme.Controller)
			{
				this.target.SetActive(this.controller);
			}
		}
	}

	// Token: 0x04000443 RID: 1091
	public GameObject target;

	// Token: 0x04000444 RID: 1092
	public bool mouse;

	// Token: 0x04000445 RID: 1093
	public bool touch;

	// Token: 0x04000446 RID: 1094
	public bool controller = true;
}
