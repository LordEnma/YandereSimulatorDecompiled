using System;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D2C RID: 7468 RVA: 0x0015DC77 File Offset: 0x0015BE77
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D2D RID: 7469 RVA: 0x0015DC98 File Offset: 0x0015BE98
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003570 RID: 13680
	public Transform Origin;

	// Token: 0x04003571 RID: 13681
	public Transform Target;

	// Token: 0x04003572 RID: 13682
	public Transform String;

	// Token: 0x04003573 RID: 13683
	public int ArrayID;
}
