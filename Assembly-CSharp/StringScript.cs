using System;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D1D RID: 7453 RVA: 0x0015B2CB File Offset: 0x001594CB
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D1E RID: 7454 RVA: 0x0015B2EC File Offset: 0x001594EC
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003548 RID: 13640
	public Transform Origin;

	// Token: 0x04003549 RID: 13641
	public Transform Target;

	// Token: 0x0400354A RID: 13642
	public Transform String;

	// Token: 0x0400354B RID: 13643
	public int ArrayID;
}
