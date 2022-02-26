using System;
using UnityEngine;

// Token: 0x0200023E RID: 574
public class CharacterScript : MonoBehaviour
{
	// Token: 0x0600123D RID: 4669 RVA: 0x0008C1B0 File Offset: 0x0008A3B0
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

	// Token: 0x040016F6 RID: 5878
	public Transform RightBreast;

	// Token: 0x040016F7 RID: 5879
	public Transform LeftBreast;

	// Token: 0x040016F8 RID: 5880
	public Transform ItemParent;

	// Token: 0x040016F9 RID: 5881
	public Transform PelvisRoot;

	// Token: 0x040016FA RID: 5882
	public Transform RightEye;

	// Token: 0x040016FB RID: 5883
	public Transform LeftEye;

	// Token: 0x040016FC RID: 5884
	public Transform Head;

	// Token: 0x040016FD RID: 5885
	public Transform[] Spine;

	// Token: 0x040016FE RID: 5886
	public Transform[] Arm;

	// Token: 0x040016FF RID: 5887
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001700 RID: 5888
	public Renderer RightYandereEye;

	// Token: 0x04001701 RID: 5889
	public Renderer LeftYandereEye;
}
