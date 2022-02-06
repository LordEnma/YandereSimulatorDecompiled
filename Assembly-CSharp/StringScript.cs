using System;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D2E RID: 7470 RVA: 0x0015DE0F File Offset: 0x0015C00F
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D2F RID: 7471 RVA: 0x0015DE30 File Offset: 0x0015C030
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003573 RID: 13683
	public Transform Origin;

	// Token: 0x04003574 RID: 13684
	public Transform Target;

	// Token: 0x04003575 RID: 13685
	public Transform String;

	// Token: 0x04003576 RID: 13686
	public int ArrayID;
}
