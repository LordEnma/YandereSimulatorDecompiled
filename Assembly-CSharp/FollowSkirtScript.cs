using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x060014B0 RID: 5296 RVA: 0x000CB938 File Offset: 0x000C9B38
	private void LateUpdate()
	{
		this.SkirtHips.position = this.TargetSkirtHips.position;
		for (int i = 0; i < 3; i++)
		{
			this.SkirtFront[i].position = this.TargetSkirtFront[i].position;
			this.SkirtFront[i].rotation = this.TargetSkirtFront[i].rotation;
			this.SkirtBack[i].position = this.TargetSkirtBack[i].position;
			this.SkirtBack[i].rotation = this.TargetSkirtBack[i].rotation;
			this.SkirtRight[i].position = this.TargetSkirtRight[i].position;
			this.SkirtRight[i].rotation = this.TargetSkirtRight[i].rotation;
			this.SkirtLeft[i].position = this.TargetSkirtLeft[i].position;
			this.SkirtLeft[i].rotation = this.TargetSkirtLeft[i].rotation;
		}
	}

	// Token: 0x04002059 RID: 8281
	public Transform[] TargetSkirtFront;

	// Token: 0x0400205A RID: 8282
	public Transform[] TargetSkirtBack;

	// Token: 0x0400205B RID: 8283
	public Transform[] TargetSkirtRight;

	// Token: 0x0400205C RID: 8284
	public Transform[] TargetSkirtLeft;

	// Token: 0x0400205D RID: 8285
	public Transform[] SkirtFront;

	// Token: 0x0400205E RID: 8286
	public Transform[] SkirtBack;

	// Token: 0x0400205F RID: 8287
	public Transform[] SkirtRight;

	// Token: 0x04002060 RID: 8288
	public Transform[] SkirtLeft;

	// Token: 0x04002061 RID: 8289
	public Transform TargetSkirtHips;

	// Token: 0x04002062 RID: 8290
	public Transform SkirtHips;
}
