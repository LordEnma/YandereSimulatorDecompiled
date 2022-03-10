using System;
using UnityEngine;

// Token: 0x0200023E RID: 574
public class CharacterScript : MonoBehaviour
{
	// Token: 0x0600123D RID: 4669 RVA: 0x0008C2F8 File Offset: 0x0008A4F8
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

	// Token: 0x040016FF RID: 5887
	public Transform RightBreast;

	// Token: 0x04001700 RID: 5888
	public Transform LeftBreast;

	// Token: 0x04001701 RID: 5889
	public Transform ItemParent;

	// Token: 0x04001702 RID: 5890
	public Transform PelvisRoot;

	// Token: 0x04001703 RID: 5891
	public Transform RightEye;

	// Token: 0x04001704 RID: 5892
	public Transform LeftEye;

	// Token: 0x04001705 RID: 5893
	public Transform Head;

	// Token: 0x04001706 RID: 5894
	public Transform[] Spine;

	// Token: 0x04001707 RID: 5895
	public Transform[] Arm;

	// Token: 0x04001708 RID: 5896
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001709 RID: 5897
	public Renderer RightYandereEye;

	// Token: 0x0400170A RID: 5898
	public Renderer LeftYandereEye;
}
