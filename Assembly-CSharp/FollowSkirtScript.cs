using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x060014C4 RID: 5316 RVA: 0x000CCC58 File Offset: 0x000CAE58
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

	// Token: 0x0400208C RID: 8332
	public Transform[] TargetSkirtFront;

	// Token: 0x0400208D RID: 8333
	public Transform[] TargetSkirtBack;

	// Token: 0x0400208E RID: 8334
	public Transform[] TargetSkirtRight;

	// Token: 0x0400208F RID: 8335
	public Transform[] TargetSkirtLeft;

	// Token: 0x04002090 RID: 8336
	public Transform[] SkirtFront;

	// Token: 0x04002091 RID: 8337
	public Transform[] SkirtBack;

	// Token: 0x04002092 RID: 8338
	public Transform[] SkirtRight;

	// Token: 0x04002093 RID: 8339
	public Transform[] SkirtLeft;

	// Token: 0x04002094 RID: 8340
	public Transform TargetSkirtHips;

	// Token: 0x04002095 RID: 8341
	public Transform SkirtHips;
}
