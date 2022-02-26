using System;
using UnityEngine;

// Token: 0x0200044F RID: 1103
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D3E RID: 7486 RVA: 0x0015EBC3 File Offset: 0x0015CDC3
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D3F RID: 7487 RVA: 0x0015EBE4 File Offset: 0x0015CDE4
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003589 RID: 13705
	public Transform Origin;

	// Token: 0x0400358A RID: 13706
	public Transform Target;

	// Token: 0x0400358B RID: 13707
	public Transform String;

	// Token: 0x0400358C RID: 13708
	public int ArrayID;
}
