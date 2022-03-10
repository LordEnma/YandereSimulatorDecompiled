using System;
using UnityEngine;

// Token: 0x02000063 RID: 99
public class UIShowControlScheme : MonoBehaviour
{
	// Token: 0x060002B0 RID: 688 RVA: 0x0001DCAB File Offset: 0x0001BEAB
	private void OnEnable()
	{
		UICamera.onSchemeChange = (UICamera.OnSchemeChange)Delegate.Combine(UICamera.onSchemeChange, new UICamera.OnSchemeChange(this.OnScheme));
		this.OnScheme();
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x0001DCD3 File Offset: 0x0001BED3
	private void OnDisable()
	{
		UICamera.onSchemeChange = (UICamera.OnSchemeChange)Delegate.Remove(UICamera.onSchemeChange, new UICamera.OnSchemeChange(this.OnScheme));
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x0001DCF8 File Offset: 0x0001BEF8
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

	// Token: 0x04000441 RID: 1089
	public GameObject target;

	// Token: 0x04000442 RID: 1090
	public bool mouse;

	// Token: 0x04000443 RID: 1091
	public bool touch;

	// Token: 0x04000444 RID: 1092
	public bool controller = true;
}
