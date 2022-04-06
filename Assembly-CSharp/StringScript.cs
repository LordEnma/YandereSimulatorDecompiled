using System;
using UnityEngine;

// Token: 0x02000454 RID: 1108
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D5F RID: 7519 RVA: 0x00161307 File Offset: 0x0015F507
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D60 RID: 7520 RVA: 0x00161328 File Offset: 0x0015F528
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x040035FB RID: 13819
	public Transform Origin;

	// Token: 0x040035FC RID: 13820
	public Transform Target;

	// Token: 0x040035FD RID: 13821
	public Transform String;

	// Token: 0x040035FE RID: 13822
	public int ArrayID;
}
