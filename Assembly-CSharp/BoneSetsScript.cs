using System;
using UnityEngine;

// Token: 0x020000F3 RID: 243
public class BoneSetsScript : MonoBehaviour
{
	// Token: 0x06000A58 RID: 2648 RVA: 0x0005C5FA File Offset: 0x0005A7FA
	private void Start()
	{
	}

	// Token: 0x06000A59 RID: 2649 RVA: 0x0005C5FC File Offset: 0x0005A7FC
	private void Update()
	{
		if (this.Head != null)
		{
			this.RightArm.localPosition = this.RightArmPosition;
			this.RightArm.localEulerAngles = this.RightArmRotation;
			this.LeftArm.localPosition = this.LeftArmPosition;
			this.LeftArm.localEulerAngles = this.LeftArmRotation;
			this.RightLeg.localPosition = this.RightLegPosition;
			this.RightLeg.localEulerAngles = this.RightLegRotation;
			this.LeftLeg.localPosition = this.LeftLegPosition;
			this.LeftLeg.localEulerAngles = this.LeftLegRotation;
			this.Head.localPosition = this.HeadPosition;
		}
		base.enabled = false;
	}

	// Token: 0x04000BEE RID: 3054
	public Transform[] BoneSet1;

	// Token: 0x04000BEF RID: 3055
	public Transform[] BoneSet2;

	// Token: 0x04000BF0 RID: 3056
	public Transform[] BoneSet3;

	// Token: 0x04000BF1 RID: 3057
	public Transform[] BoneSet4;

	// Token: 0x04000BF2 RID: 3058
	public Transform[] BoneSet5;

	// Token: 0x04000BF3 RID: 3059
	public Transform[] BoneSet6;

	// Token: 0x04000BF4 RID: 3060
	public Transform[] BoneSet7;

	// Token: 0x04000BF5 RID: 3061
	public Transform[] BoneSet8;

	// Token: 0x04000BF6 RID: 3062
	public Transform[] BoneSet9;

	// Token: 0x04000BF7 RID: 3063
	public Vector3[] BoneSet1Pos;

	// Token: 0x04000BF8 RID: 3064
	public Vector3[] BoneSet2Pos;

	// Token: 0x04000BF9 RID: 3065
	public Vector3[] BoneSet3Pos;

	// Token: 0x04000BFA RID: 3066
	public Vector3[] BoneSet4Pos;

	// Token: 0x04000BFB RID: 3067
	public Vector3[] BoneSet5Pos;

	// Token: 0x04000BFC RID: 3068
	public Vector3[] BoneSet6Pos;

	// Token: 0x04000BFD RID: 3069
	public Vector3[] BoneSet7Pos;

	// Token: 0x04000BFE RID: 3070
	public Vector3[] BoneSet8Pos;

	// Token: 0x04000BFF RID: 3071
	public Vector3[] BoneSet9Pos;

	// Token: 0x04000C00 RID: 3072
	public float Timer;

	// Token: 0x04000C01 RID: 3073
	public Transform RightArm;

	// Token: 0x04000C02 RID: 3074
	public Transform LeftArm;

	// Token: 0x04000C03 RID: 3075
	public Transform RightLeg;

	// Token: 0x04000C04 RID: 3076
	public Transform LeftLeg;

	// Token: 0x04000C05 RID: 3077
	public Transform Head;

	// Token: 0x04000C06 RID: 3078
	public Vector3 RightArmPosition;

	// Token: 0x04000C07 RID: 3079
	public Vector3 RightArmRotation;

	// Token: 0x04000C08 RID: 3080
	public Vector3 LeftArmPosition;

	// Token: 0x04000C09 RID: 3081
	public Vector3 LeftArmRotation;

	// Token: 0x04000C0A RID: 3082
	public Vector3 RightLegPosition;

	// Token: 0x04000C0B RID: 3083
	public Vector3 RightLegRotation;

	// Token: 0x04000C0C RID: 3084
	public Vector3 LeftLegPosition;

	// Token: 0x04000C0D RID: 3085
	public Vector3 LeftLegRotation;

	// Token: 0x04000C0E RID: 3086
	public Vector3 HeadPosition;
}
