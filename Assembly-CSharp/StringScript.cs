using System;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D2C RID: 7468 RVA: 0x0015DB73 File Offset: 0x0015BD73
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D2D RID: 7469 RVA: 0x0015DB94 File Offset: 0x0015BD94
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x0400356F RID: 13679
	public Transform Origin;

	// Token: 0x04003570 RID: 13680
	public Transform Target;

	// Token: 0x04003571 RID: 13681
	public Transform String;

	// Token: 0x04003572 RID: 13682
	public int ArrayID;
}
