using System;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D1F RID: 7455 RVA: 0x0015B70F File Offset: 0x0015990F
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D20 RID: 7456 RVA: 0x0015B730 File Offset: 0x00159930
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x0400354F RID: 13647
	public Transform Origin;

	// Token: 0x04003550 RID: 13648
	public Transform Target;

	// Token: 0x04003551 RID: 13649
	public Transform String;

	// Token: 0x04003552 RID: 13650
	public int ArrayID;
}
