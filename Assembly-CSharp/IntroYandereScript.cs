using System;
using UnityEngine;

// Token: 0x0200033E RID: 830
public class IntroYandereScript : MonoBehaviour
{
	// Token: 0x06001907 RID: 6407 RVA: 0x000FAC68 File Offset: 0x000F8E68
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

	// Token: 0x040026F9 RID: 9977
	public Transform Hips;

	// Token: 0x040026FA RID: 9978
	public Transform Spine;

	// Token: 0x040026FB RID: 9979
	public Transform Spine1;

	// Token: 0x040026FC RID: 9980
	public Transform Spine2;

	// Token: 0x040026FD RID: 9981
	public Transform Spine3;

	// Token: 0x040026FE RID: 9982
	public Transform Neck;

	// Token: 0x040026FF RID: 9983
	public Transform Head;

	// Token: 0x04002700 RID: 9984
	public Transform RightUpLeg;

	// Token: 0x04002701 RID: 9985
	public Transform RightLeg;

	// Token: 0x04002702 RID: 9986
	public Transform RightFoot;

	// Token: 0x04002703 RID: 9987
	public Transform LeftUpLeg;

	// Token: 0x04002704 RID: 9988
	public Transform LeftLeg;

	// Token: 0x04002705 RID: 9989
	public Transform LeftFoot;

	// Token: 0x04002706 RID: 9990
	public float X;
}
