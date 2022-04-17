using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x060014BE RID: 5310 RVA: 0x000CC430 File Offset: 0x000CA630
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

	// Token: 0x0400207C RID: 8316
	public Transform[] TargetSkirtFront;

	// Token: 0x0400207D RID: 8317
	public Transform[] TargetSkirtBack;

	// Token: 0x0400207E RID: 8318
	public Transform[] TargetSkirtRight;

	// Token: 0x0400207F RID: 8319
	public Transform[] TargetSkirtLeft;

	// Token: 0x04002080 RID: 8320
	public Transform[] SkirtFront;

	// Token: 0x04002081 RID: 8321
	public Transform[] SkirtBack;

	// Token: 0x04002082 RID: 8322
	public Transform[] SkirtRight;

	// Token: 0x04002083 RID: 8323
	public Transform[] SkirtLeft;

	// Token: 0x04002084 RID: 8324
	public Transform TargetSkirtHips;

	// Token: 0x04002085 RID: 8325
	public Transform SkirtHips;
}
