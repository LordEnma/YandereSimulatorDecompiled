using System;
using UnityEngine;

// Token: 0x02000454 RID: 1108
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D63 RID: 7523 RVA: 0x00161793 File Offset: 0x0015F993
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D64 RID: 7524 RVA: 0x001617B4 File Offset: 0x0015F9B4
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003607 RID: 13831
	public Transform Origin;

	// Token: 0x04003608 RID: 13832
	public Transform Target;

	// Token: 0x04003609 RID: 13833
	public Transform String;

	// Token: 0x0400360A RID: 13834
	public int ArrayID;
}
