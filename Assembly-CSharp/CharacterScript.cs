using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CharacterScript : MonoBehaviour
{
	// Token: 0x06001241 RID: 4673 RVA: 0x0008CCF8 File Offset: 0x0008AEF8
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

	// Token: 0x0400170F RID: 5903
	public Transform RightBreast;

	// Token: 0x04001710 RID: 5904
	public Transform LeftBreast;

	// Token: 0x04001711 RID: 5905
	public Transform ItemParent;

	// Token: 0x04001712 RID: 5906
	public Transform PelvisRoot;

	// Token: 0x04001713 RID: 5907
	public Transform RightEye;

	// Token: 0x04001714 RID: 5908
	public Transform LeftEye;

	// Token: 0x04001715 RID: 5909
	public Transform Head;

	// Token: 0x04001716 RID: 5910
	public Transform[] Spine;

	// Token: 0x04001717 RID: 5911
	public Transform[] Arm;

	// Token: 0x04001718 RID: 5912
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001719 RID: 5913
	public Renderer RightYandereEye;

	// Token: 0x0400171A RID: 5914
	public Renderer LeftYandereEye;
}
