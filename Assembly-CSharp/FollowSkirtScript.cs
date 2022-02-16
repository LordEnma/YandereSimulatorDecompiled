using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x060014A7 RID: 5287 RVA: 0x000CB054 File Offset: 0x000C9254
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

	// Token: 0x0400204A RID: 8266
	public Transform[] TargetSkirtFront;

	// Token: 0x0400204B RID: 8267
	public Transform[] TargetSkirtBack;

	// Token: 0x0400204C RID: 8268
	public Transform[] TargetSkirtRight;

	// Token: 0x0400204D RID: 8269
	public Transform[] TargetSkirtLeft;

	// Token: 0x0400204E RID: 8270
	public Transform[] SkirtFront;

	// Token: 0x0400204F RID: 8271
	public Transform[] SkirtBack;

	// Token: 0x04002050 RID: 8272
	public Transform[] SkirtRight;

	// Token: 0x04002051 RID: 8273
	public Transform[] SkirtLeft;

	// Token: 0x04002052 RID: 8274
	public Transform TargetSkirtHips;

	// Token: 0x04002053 RID: 8275
	public Transform SkirtHips;
}
