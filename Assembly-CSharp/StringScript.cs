using System;
using UnityEngine;

// Token: 0x0200044E RID: 1102
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D35 RID: 7477 RVA: 0x0015E117 File Offset: 0x0015C317
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D36 RID: 7478 RVA: 0x0015E138 File Offset: 0x0015C338
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003579 RID: 13689
	public Transform Origin;

	// Token: 0x0400357A RID: 13690
	public Transform Target;

	// Token: 0x0400357B RID: 13691
	public Transform String;

	// Token: 0x0400357C RID: 13692
	public int ArrayID;
}
