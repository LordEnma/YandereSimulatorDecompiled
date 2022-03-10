using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x060014B0 RID: 5296 RVA: 0x000CBAB4 File Offset: 0x000C9CB4
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

	// Token: 0x04002063 RID: 8291
	public Transform[] TargetSkirtFront;

	// Token: 0x04002064 RID: 8292
	public Transform[] TargetSkirtBack;

	// Token: 0x04002065 RID: 8293
	public Transform[] TargetSkirtRight;

	// Token: 0x04002066 RID: 8294
	public Transform[] TargetSkirtLeft;

	// Token: 0x04002067 RID: 8295
	public Transform[] SkirtFront;

	// Token: 0x04002068 RID: 8296
	public Transform[] SkirtBack;

	// Token: 0x04002069 RID: 8297
	public Transform[] SkirtRight;

	// Token: 0x0400206A RID: 8298
	public Transform[] SkirtLeft;

	// Token: 0x0400206B RID: 8299
	public Transform TargetSkirtHips;

	// Token: 0x0400206C RID: 8300
	public Transform SkirtHips;
}
