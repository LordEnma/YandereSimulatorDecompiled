using System;
using UnityEngine;

// Token: 0x02000063 RID: 99
public class UIShowControlScheme : MonoBehaviour
{
	// Token: 0x060002B0 RID: 688 RVA: 0x0001DBB3 File Offset: 0x0001BDB3
	private void OnEnable()
	{
		UICamera.onSchemeChange = (UICamera.OnSchemeChange)Delegate.Combine(UICamera.onSchemeChange, new UICamera.OnSchemeChange(this.OnScheme));
		this.OnScheme();
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x0001DBDB File Offset: 0x0001BDDB
	private void OnDisable()
	{
		UICamera.onSchemeChange = (UICamera.OnSchemeChange)Delegate.Remove(UICamera.onSchemeChange, new UICamera.OnSchemeChange(this.OnScheme));
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x0001DC00 File Offset: 0x0001BE00
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

	// Token: 0x04000437 RID: 1079
	public GameObject target;

	// Token: 0x04000438 RID: 1080
	public bool mouse;

	// Token: 0x04000439 RID: 1081
	public bool touch;

	// Token: 0x0400043A RID: 1082
	public bool controller = true;
}
