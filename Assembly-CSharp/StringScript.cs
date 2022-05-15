using System;
using UnityEngine;

// Token: 0x02000456 RID: 1110
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D70 RID: 7536 RVA: 0x00162CA3 File Offset: 0x00160EA3
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D71 RID: 7537 RVA: 0x00162CC4 File Offset: 0x00160EC4
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x0400362B RID: 13867
	public Transform Origin;

	// Token: 0x0400362C RID: 13868
	public Transform Target;

	// Token: 0x0400362D RID: 13869
	public Transform String;

	// Token: 0x0400362E RID: 13870
	public int ArrayID;
}
