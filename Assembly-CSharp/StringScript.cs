using System;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D2B RID: 7467 RVA: 0x0015D733 File Offset: 0x0015B933
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D2C RID: 7468 RVA: 0x0015D754 File Offset: 0x0015B954
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003569 RID: 13673
	public Transform Origin;

	// Token: 0x0400356A RID: 13674
	public Transform Target;

	// Token: 0x0400356B RID: 13675
	public Transform String;

	// Token: 0x0400356C RID: 13676
	public int ArrayID;
}
