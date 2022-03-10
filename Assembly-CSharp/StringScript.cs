using System;
using UnityEngine;

// Token: 0x0200044F RID: 1103
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D40 RID: 7488 RVA: 0x0015F203 File Offset: 0x0015D403
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D41 RID: 7489 RVA: 0x0015F224 File Offset: 0x0015D424
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x040035A0 RID: 13728
	public Transform Origin;

	// Token: 0x040035A1 RID: 13729
	public Transform Target;

	// Token: 0x040035A2 RID: 13730
	public Transform String;

	// Token: 0x040035A3 RID: 13731
	public int ArrayID;
}
