using System;
using UnityEngine;

// Token: 0x020000F2 RID: 242
public class BoneSetsScript : MonoBehaviour
{
	// Token: 0x06000A56 RID: 2646 RVA: 0x0005C186 File Offset: 0x0005A386
	private void Start()
	{
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x0005C188 File Offset: 0x0005A388
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

	// Token: 0x04000BE7 RID: 3047
	public Transform[] BoneSet1;

	// Token: 0x04000BE8 RID: 3048
	public Transform[] BoneSet2;

	// Token: 0x04000BE9 RID: 3049
	public Transform[] BoneSet3;

	// Token: 0x04000BEA RID: 3050
	public Transform[] BoneSet4;

	// Token: 0x04000BEB RID: 3051
	public Transform[] BoneSet5;

	// Token: 0x04000BEC RID: 3052
	public Transform[] BoneSet6;

	// Token: 0x04000BED RID: 3053
	public Transform[] BoneSet7;

	// Token: 0x04000BEE RID: 3054
	public Transform[] BoneSet8;

	// Token: 0x04000BEF RID: 3055
	public Transform[] BoneSet9;

	// Token: 0x04000BF0 RID: 3056
	public Vector3[] BoneSet1Pos;

	// Token: 0x04000BF1 RID: 3057
	public Vector3[] BoneSet2Pos;

	// Token: 0x04000BF2 RID: 3058
	public Vector3[] BoneSet3Pos;

	// Token: 0x04000BF3 RID: 3059
	public Vector3[] BoneSet4Pos;

	// Token: 0x04000BF4 RID: 3060
	public Vector3[] BoneSet5Pos;

	// Token: 0x04000BF5 RID: 3061
	public Vector3[] BoneSet6Pos;

	// Token: 0x04000BF6 RID: 3062
	public Vector3[] BoneSet7Pos;

	// Token: 0x04000BF7 RID: 3063
	public Vector3[] BoneSet8Pos;

	// Token: 0x04000BF8 RID: 3064
	public Vector3[] BoneSet9Pos;

	// Token: 0x04000BF9 RID: 3065
	public float Timer;

	// Token: 0x04000BFA RID: 3066
	public Transform RightArm;

	// Token: 0x04000BFB RID: 3067
	public Transform LeftArm;

	// Token: 0x04000BFC RID: 3068
	public Transform RightLeg;

	// Token: 0x04000BFD RID: 3069
	public Transform LeftLeg;

	// Token: 0x04000BFE RID: 3070
	public Transform Head;

	// Token: 0x04000BFF RID: 3071
	public Vector3 RightArmPosition;

	// Token: 0x04000C00 RID: 3072
	public Vector3 RightArmRotation;

	// Token: 0x04000C01 RID: 3073
	public Vector3 LeftArmPosition;

	// Token: 0x04000C02 RID: 3074
	public Vector3 LeftArmRotation;

	// Token: 0x04000C03 RID: 3075
	public Vector3 RightLegPosition;

	// Token: 0x04000C04 RID: 3076
	public Vector3 RightLegRotation;

	// Token: 0x04000C05 RID: 3077
	public Vector3 LeftLegPosition;

	// Token: 0x04000C06 RID: 3078
	public Vector3 LeftLegRotation;

	// Token: 0x04000C07 RID: 3079
	public Vector3 HeadPosition;
}
