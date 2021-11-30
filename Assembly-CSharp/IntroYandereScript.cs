using System;
using UnityEngine;

// Token: 0x02000338 RID: 824
public class IntroYandereScript : MonoBehaviour
{
	// Token: 0x060018D4 RID: 6356 RVA: 0x000F7A20 File Offset: 0x000F5C20
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

	// Token: 0x04002667 RID: 9831
	public Transform Hips;

	// Token: 0x04002668 RID: 9832
	public Transform Spine;

	// Token: 0x04002669 RID: 9833
	public Transform Spine1;

	// Token: 0x0400266A RID: 9834
	public Transform Spine2;

	// Token: 0x0400266B RID: 9835
	public Transform Spine3;

	// Token: 0x0400266C RID: 9836
	public Transform Neck;

	// Token: 0x0400266D RID: 9837
	public Transform Head;

	// Token: 0x0400266E RID: 9838
	public Transform RightUpLeg;

	// Token: 0x0400266F RID: 9839
	public Transform RightLeg;

	// Token: 0x04002670 RID: 9840
	public Transform RightFoot;

	// Token: 0x04002671 RID: 9841
	public Transform LeftUpLeg;

	// Token: 0x04002672 RID: 9842
	public Transform LeftLeg;

	// Token: 0x04002673 RID: 9843
	public Transform LeftFoot;

	// Token: 0x04002674 RID: 9844
	public float X;
}
