using System;
using UnityEngine;

// Token: 0x0200044C RID: 1100
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D29 RID: 7465 RVA: 0x0015BF9B File Offset: 0x0015A19B
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D2A RID: 7466 RVA: 0x0015BFBC File Offset: 0x0015A1BC
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003563 RID: 13667
	public Transform Origin;

	// Token: 0x04003564 RID: 13668
	public Transform Target;

	// Token: 0x04003565 RID: 13669
	public Transform String;

	// Token: 0x04003566 RID: 13670
	public int ArrayID;
}
