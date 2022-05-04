using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x060014C2 RID: 5314 RVA: 0x000CC8C4 File Offset: 0x000CAAC4
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

	// Token: 0x04002085 RID: 8325
	public Transform[] TargetSkirtFront;

	// Token: 0x04002086 RID: 8326
	public Transform[] TargetSkirtBack;

	// Token: 0x04002087 RID: 8327
	public Transform[] TargetSkirtRight;

	// Token: 0x04002088 RID: 8328
	public Transform[] TargetSkirtLeft;

	// Token: 0x04002089 RID: 8329
	public Transform[] SkirtFront;

	// Token: 0x0400208A RID: 8330
	public Transform[] SkirtBack;

	// Token: 0x0400208B RID: 8331
	public Transform[] SkirtRight;

	// Token: 0x0400208C RID: 8332
	public Transform[] SkirtLeft;

	// Token: 0x0400208D RID: 8333
	public Transform TargetSkirtHips;

	// Token: 0x0400208E RID: 8334
	public Transform SkirtHips;
}
