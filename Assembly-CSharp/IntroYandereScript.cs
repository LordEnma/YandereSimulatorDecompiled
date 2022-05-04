using System;
using UnityEngine;

// Token: 0x0200033E RID: 830
public class IntroYandereScript : MonoBehaviour
{
	// Token: 0x0600190F RID: 6415 RVA: 0x000FB3CC File Offset: 0x000F95CC
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

	// Token: 0x0400270A RID: 9994
	public Transform Hips;

	// Token: 0x0400270B RID: 9995
	public Transform Spine;

	// Token: 0x0400270C RID: 9996
	public Transform Spine1;

	// Token: 0x0400270D RID: 9997
	public Transform Spine2;

	// Token: 0x0400270E RID: 9998
	public Transform Spine3;

	// Token: 0x0400270F RID: 9999
	public Transform Neck;

	// Token: 0x04002710 RID: 10000
	public Transform Head;

	// Token: 0x04002711 RID: 10001
	public Transform RightUpLeg;

	// Token: 0x04002712 RID: 10002
	public Transform RightLeg;

	// Token: 0x04002713 RID: 10003
	public Transform RightFoot;

	// Token: 0x04002714 RID: 10004
	public Transform LeftUpLeg;

	// Token: 0x04002715 RID: 10005
	public Transform LeftLeg;

	// Token: 0x04002716 RID: 10006
	public Transform LeftFoot;

	// Token: 0x04002717 RID: 10007
	public float X;
}
