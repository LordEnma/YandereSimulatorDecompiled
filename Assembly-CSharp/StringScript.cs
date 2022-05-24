using System;
using UnityEngine;

// Token: 0x02000456 RID: 1110
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D71 RID: 7537 RVA: 0x00162F5F File Offset: 0x0016115F
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D72 RID: 7538 RVA: 0x00162F80 File Offset: 0x00161180
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003633 RID: 13875
	public Transform Origin;

	// Token: 0x04003634 RID: 13876
	public Transform Target;

	// Token: 0x04003635 RID: 13877
	public Transform String;

	// Token: 0x04003636 RID: 13878
	public int ArrayID;
}
