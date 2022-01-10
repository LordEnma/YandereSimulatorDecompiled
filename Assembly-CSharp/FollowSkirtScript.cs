using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x060014A1 RID: 5281 RVA: 0x000CA914 File Offset: 0x000C8B14
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

	// Token: 0x0400203A RID: 8250
	public Transform[] TargetSkirtFront;

	// Token: 0x0400203B RID: 8251
	public Transform[] TargetSkirtBack;

	// Token: 0x0400203C RID: 8252
	public Transform[] TargetSkirtRight;

	// Token: 0x0400203D RID: 8253
	public Transform[] TargetSkirtLeft;

	// Token: 0x0400203E RID: 8254
	public Transform[] SkirtFront;

	// Token: 0x0400203F RID: 8255
	public Transform[] SkirtBack;

	// Token: 0x04002040 RID: 8256
	public Transform[] SkirtRight;

	// Token: 0x04002041 RID: 8257
	public Transform[] SkirtLeft;

	// Token: 0x04002042 RID: 8258
	public Transform TargetSkirtHips;

	// Token: 0x04002043 RID: 8259
	public Transform SkirtHips;
}
