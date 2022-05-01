using System;
using UnityEngine;

// Token: 0x0200023E RID: 574
public class CharacterScript : MonoBehaviour
{
	// Token: 0x0600123F RID: 4671 RVA: 0x0008C9CC File Offset: 0x0008ABCC
	private void SetAnimations()
	{
		Animation component = base.GetComponent<Animation>();
		component["f02_yanderePose_00"].layer = 1;
		component["f02_yanderePose_00"].weight = 0f;
		component.Play("f02_yanderePose_00");
		component["f02_shy_00"].layer = 2;
		component["f02_shy_00"].weight = 0f;
		component.Play("f02_shy_00");
		component["f02_fist_00"].layer = 3;
		component["f02_fist_00"].weight = 0f;
		component.Play("f02_fist_00");
		component["f02_mopping_00"].layer = 4;
		component["f02_mopping_00"].weight = 0f;
		component["f02_mopping_00"].speed = 2f;
		component.Play("f02_mopping_00");
		component["f02_carry_00"].layer = 5;
		component["f02_carry_00"].weight = 0f;
		component.Play("f02_carry_00");
		component["f02_mopCarry_00"].layer = 6;
		component["f02_mopCarry_00"].weight = 0f;
		component.Play("f02_mopCarry_00");
		component["f02_bucketCarry_00"].layer = 7;
		component["f02_bucketCarry_00"].weight = 0f;
		component.Play("f02_bucketCarry_00");
		component["f02_cameraPose_00"].layer = 8;
		component["f02_cameraPose_00"].weight = 0f;
		component.Play("f02_cameraPose_00");
		component["f02_dipping_00"].speed = 2f;
		component["f02_cameraPose_00"].weight = 0f;
		component["f02_shy_00"].weight = 0f;
	}

	// Token: 0x04001709 RID: 5897
	public Transform RightBreast;

	// Token: 0x0400170A RID: 5898
	public Transform LeftBreast;

	// Token: 0x0400170B RID: 5899
	public Transform ItemParent;

	// Token: 0x0400170C RID: 5900
	public Transform PelvisRoot;

	// Token: 0x0400170D RID: 5901
	public Transform RightEye;

	// Token: 0x0400170E RID: 5902
	public Transform LeftEye;

	// Token: 0x0400170F RID: 5903
	public Transform Head;

	// Token: 0x04001710 RID: 5904
	public Transform[] Spine;

	// Token: 0x04001711 RID: 5905
	public Transform[] Arm;

	// Token: 0x04001712 RID: 5906
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001713 RID: 5907
	public Renderer RightYandereEye;

	// Token: 0x04001714 RID: 5908
	public Renderer LeftYandereEye;
}
