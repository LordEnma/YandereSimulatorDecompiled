using System;
using UnityEngine;

// Token: 0x0200033A RID: 826
public class IntroYandereScript : MonoBehaviour
{
	// Token: 0x060018E4 RID: 6372 RVA: 0x000F8F38 File Offset: 0x000F7138
	private void LateUpdate()
	{
		this.Hips.localEulerAngles = new Vector3(this.Hips.localEulerAngles.x + this.X, this.Hips.localEulerAngles.y, this.Hips.localEulerAngles.z);
		this.Spine.localEulerAngles = new Vector3(this.Spine.localEulerAngles.x + this.X, this.Spine.localEulerAngles.y, this.Spine.localEulerAngles.z);
		this.Spine1.localEulerAngles = new Vector3(this.Spine1.localEulerAngles.x + this.X, this.Spine1.localEulerAngles.y, this.Spine1.localEulerAngles.z);
		this.Spine2.localEulerAngles = new Vector3(this.Spine2.localEulerAngles.x + this.X, this.Spine2.localEulerAngles.y, this.Spine2.localEulerAngles.z);
		this.Spine3.localEulerAngles = new Vector3(this.Spine3.localEulerAngles.x + this.X, this.Spine3.localEulerAngles.y, this.Spine3.localEulerAngles.z);
		this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x + this.X, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
		this.Head.localEulerAngles = new Vector3(this.Head.localEulerAngles.x + this.X, this.Head.localEulerAngles.y, this.Head.localEulerAngles.z);
		this.RightUpLeg.localEulerAngles = new Vector3(this.RightUpLeg.localEulerAngles.x - this.X, this.RightUpLeg.localEulerAngles.y, this.RightUpLeg.localEulerAngles.z);
		this.RightLeg.localEulerAngles = new Vector3(this.RightLeg.localEulerAngles.x - this.X, this.RightLeg.localEulerAngles.y, this.RightLeg.localEulerAngles.z);
		this.RightFoot.localEulerAngles = new Vector3(this.RightFoot.localEulerAngles.x - this.X, this.RightFoot.localEulerAngles.y, this.RightFoot.localEulerAngles.z);
		this.LeftUpLeg.localEulerAngles = new Vector3(this.LeftUpLeg.localEulerAngles.x - this.X, this.LeftUpLeg.localEulerAngles.y, this.LeftUpLeg.localEulerAngles.z);
		this.LeftLeg.localEulerAngles = new Vector3(this.LeftLeg.localEulerAngles.x - this.X, this.LeftLeg.localEulerAngles.y, this.LeftLeg.localEulerAngles.z);
		this.LeftFoot.localEulerAngles = new Vector3(this.LeftFoot.localEulerAngles.x - this.X, this.LeftFoot.localEulerAngles.y, this.LeftFoot.localEulerAngles.z);
	}

	// Token: 0x0400269C RID: 9884
	public Transform Hips;

	// Token: 0x0400269D RID: 9885
	public Transform Spine;

	// Token: 0x0400269E RID: 9886
	public Transform Spine1;

	// Token: 0x0400269F RID: 9887
	public Transform Spine2;

	// Token: 0x040026A0 RID: 9888
	public Transform Spine3;

	// Token: 0x040026A1 RID: 9889
	public Transform Neck;

	// Token: 0x040026A2 RID: 9890
	public Transform Head;

	// Token: 0x040026A3 RID: 9891
	public Transform RightUpLeg;

	// Token: 0x040026A4 RID: 9892
	public Transform RightLeg;

	// Token: 0x040026A5 RID: 9893
	public Transform RightFoot;

	// Token: 0x040026A6 RID: 9894
	public Transform LeftUpLeg;

	// Token: 0x040026A7 RID: 9895
	public Transform LeftLeg;

	// Token: 0x040026A8 RID: 9896
	public Transform LeftFoot;

	// Token: 0x040026A9 RID: 9897
	public float X;
}
