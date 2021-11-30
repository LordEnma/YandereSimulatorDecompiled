using System;
using UnityEngine;

// Token: 0x020002CB RID: 715
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x06001496 RID: 5270 RVA: 0x000C9C48 File Offset: 0x000C7E48
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

	// Token: 0x04002013 RID: 8211
	public Transform[] TargetSkirtFront;

	// Token: 0x04002014 RID: 8212
	public Transform[] TargetSkirtBack;

	// Token: 0x04002015 RID: 8213
	public Transform[] TargetSkirtRight;

	// Token: 0x04002016 RID: 8214
	public Transform[] TargetSkirtLeft;

	// Token: 0x04002017 RID: 8215
	public Transform[] SkirtFront;

	// Token: 0x04002018 RID: 8216
	public Transform[] SkirtBack;

	// Token: 0x04002019 RID: 8217
	public Transform[] SkirtRight;

	// Token: 0x0400201A RID: 8218
	public Transform[] SkirtLeft;

	// Token: 0x0400201B RID: 8219
	public Transform TargetSkirtHips;

	// Token: 0x0400201C RID: 8220
	public Transform SkirtHips;
}
