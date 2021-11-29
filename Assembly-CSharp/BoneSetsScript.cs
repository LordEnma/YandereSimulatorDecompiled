using System;
using UnityEngine;

// Token: 0x020000F1 RID: 241
public class BoneSetsScript : MonoBehaviour
{
	// Token: 0x06000A52 RID: 2642 RVA: 0x0005BC6E File Offset: 0x00059E6E
	private void Start()
	{
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x0005BC70 File Offset: 0x00059E70
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

	// Token: 0x04000BD3 RID: 3027
	public Transform[] BoneSet1;

	// Token: 0x04000BD4 RID: 3028
	public Transform[] BoneSet2;

	// Token: 0x04000BD5 RID: 3029
	public Transform[] BoneSet3;

	// Token: 0x04000BD6 RID: 3030
	public Transform[] BoneSet4;

	// Token: 0x04000BD7 RID: 3031
	public Transform[] BoneSet5;

	// Token: 0x04000BD8 RID: 3032
	public Transform[] BoneSet6;

	// Token: 0x04000BD9 RID: 3033
	public Transform[] BoneSet7;

	// Token: 0x04000BDA RID: 3034
	public Transform[] BoneSet8;

	// Token: 0x04000BDB RID: 3035
	public Transform[] BoneSet9;

	// Token: 0x04000BDC RID: 3036
	public Vector3[] BoneSet1Pos;

	// Token: 0x04000BDD RID: 3037
	public Vector3[] BoneSet2Pos;

	// Token: 0x04000BDE RID: 3038
	public Vector3[] BoneSet3Pos;

	// Token: 0x04000BDF RID: 3039
	public Vector3[] BoneSet4Pos;

	// Token: 0x04000BE0 RID: 3040
	public Vector3[] BoneSet5Pos;

	// Token: 0x04000BE1 RID: 3041
	public Vector3[] BoneSet6Pos;

	// Token: 0x04000BE2 RID: 3042
	public Vector3[] BoneSet7Pos;

	// Token: 0x04000BE3 RID: 3043
	public Vector3[] BoneSet8Pos;

	// Token: 0x04000BE4 RID: 3044
	public Vector3[] BoneSet9Pos;

	// Token: 0x04000BE5 RID: 3045
	public float Timer;

	// Token: 0x04000BE6 RID: 3046
	public Transform RightArm;

	// Token: 0x04000BE7 RID: 3047
	public Transform LeftArm;

	// Token: 0x04000BE8 RID: 3048
	public Transform RightLeg;

	// Token: 0x04000BE9 RID: 3049
	public Transform LeftLeg;

	// Token: 0x04000BEA RID: 3050
	public Transform Head;

	// Token: 0x04000BEB RID: 3051
	public Vector3 RightArmPosition;

	// Token: 0x04000BEC RID: 3052
	public Vector3 RightArmRotation;

	// Token: 0x04000BED RID: 3053
	public Vector3 LeftArmPosition;

	// Token: 0x04000BEE RID: 3054
	public Vector3 LeftArmRotation;

	// Token: 0x04000BEF RID: 3055
	public Vector3 RightLegPosition;

	// Token: 0x04000BF0 RID: 3056
	public Vector3 RightLegRotation;

	// Token: 0x04000BF1 RID: 3057
	public Vector3 LeftLegPosition;

	// Token: 0x04000BF2 RID: 3058
	public Vector3 LeftLegRotation;

	// Token: 0x04000BF3 RID: 3059
	public Vector3 HeadPosition;
}
