using System;
using UnityEngine;

// Token: 0x0200033C RID: 828
public class IntroYandereScript : MonoBehaviour
{
	// Token: 0x060018F4 RID: 6388 RVA: 0x000F99E0 File Offset: 0x000F7BE0
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

	// Token: 0x040026B1 RID: 9905
	public Transform Hips;

	// Token: 0x040026B2 RID: 9906
	public Transform Spine;

	// Token: 0x040026B3 RID: 9907
	public Transform Spine1;

	// Token: 0x040026B4 RID: 9908
	public Transform Spine2;

	// Token: 0x040026B5 RID: 9909
	public Transform Spine3;

	// Token: 0x040026B6 RID: 9910
	public Transform Neck;

	// Token: 0x040026B7 RID: 9911
	public Transform Head;

	// Token: 0x040026B8 RID: 9912
	public Transform RightUpLeg;

	// Token: 0x040026B9 RID: 9913
	public Transform RightLeg;

	// Token: 0x040026BA RID: 9914
	public Transform RightFoot;

	// Token: 0x040026BB RID: 9915
	public Transform LeftUpLeg;

	// Token: 0x040026BC RID: 9916
	public Transform LeftLeg;

	// Token: 0x040026BD RID: 9917
	public Transform LeftFoot;

	// Token: 0x040026BE RID: 9918
	public float X;
}
