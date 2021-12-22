using System;
using UnityEngine;

// Token: 0x020002CC RID: 716
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x0600149D RID: 5277 RVA: 0x000CA3EC File Offset: 0x000C85EC
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

	// Token: 0x04002033 RID: 8243
	public Transform[] TargetSkirtFront;

	// Token: 0x04002034 RID: 8244
	public Transform[] TargetSkirtBack;

	// Token: 0x04002035 RID: 8245
	public Transform[] TargetSkirtRight;

	// Token: 0x04002036 RID: 8246
	public Transform[] TargetSkirtLeft;

	// Token: 0x04002037 RID: 8247
	public Transform[] SkirtFront;

	// Token: 0x04002038 RID: 8248
	public Transform[] SkirtBack;

	// Token: 0x04002039 RID: 8249
	public Transform[] SkirtRight;

	// Token: 0x0400203A RID: 8250
	public Transform[] SkirtLeft;

	// Token: 0x0400203B RID: 8251
	public Transform TargetSkirtHips;

	// Token: 0x0400203C RID: 8252
	public Transform SkirtHips;
}
