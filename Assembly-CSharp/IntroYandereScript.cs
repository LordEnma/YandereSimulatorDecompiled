using System;
using UnityEngine;

// Token: 0x0200033B RID: 827
public class IntroYandereScript : MonoBehaviour
{
	// Token: 0x060018EB RID: 6379 RVA: 0x000F90DC File Offset: 0x000F72DC
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

	// Token: 0x040026A2 RID: 9890
	public Transform Hips;

	// Token: 0x040026A3 RID: 9891
	public Transform Spine;

	// Token: 0x040026A4 RID: 9892
	public Transform Spine1;

	// Token: 0x040026A5 RID: 9893
	public Transform Spine2;

	// Token: 0x040026A6 RID: 9894
	public Transform Spine3;

	// Token: 0x040026A7 RID: 9895
	public Transform Neck;

	// Token: 0x040026A8 RID: 9896
	public Transform Head;

	// Token: 0x040026A9 RID: 9897
	public Transform RightUpLeg;

	// Token: 0x040026AA RID: 9898
	public Transform RightLeg;

	// Token: 0x040026AB RID: 9899
	public Transform RightFoot;

	// Token: 0x040026AC RID: 9900
	public Transform LeftUpLeg;

	// Token: 0x040026AD RID: 9901
	public Transform LeftLeg;

	// Token: 0x040026AE RID: 9902
	public Transform LeftFoot;

	// Token: 0x040026AF RID: 9903
	public float X;
}
