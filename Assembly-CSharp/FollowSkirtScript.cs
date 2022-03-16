using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x060014B3 RID: 5299 RVA: 0x000CBF24 File Offset: 0x000CA124
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

	// Token: 0x04002073 RID: 8307
	public Transform[] TargetSkirtFront;

	// Token: 0x04002074 RID: 8308
	public Transform[] TargetSkirtBack;

	// Token: 0x04002075 RID: 8309
	public Transform[] TargetSkirtRight;

	// Token: 0x04002076 RID: 8310
	public Transform[] TargetSkirtLeft;

	// Token: 0x04002077 RID: 8311
	public Transform[] SkirtFront;

	// Token: 0x04002078 RID: 8312
	public Transform[] SkirtBack;

	// Token: 0x04002079 RID: 8313
	public Transform[] SkirtRight;

	// Token: 0x0400207A RID: 8314
	public Transform[] SkirtLeft;

	// Token: 0x0400207B RID: 8315
	public Transform TargetSkirtHips;

	// Token: 0x0400207C RID: 8316
	public Transform SkirtHips;
}
