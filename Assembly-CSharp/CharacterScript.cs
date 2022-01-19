using System;
using UnityEngine;

// Token: 0x0200023E RID: 574
public class CharacterScript : MonoBehaviour
{
	// Token: 0x0600123C RID: 4668 RVA: 0x0008BF04 File Offset: 0x0008A104
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

	// Token: 0x040016F1 RID: 5873
	public Transform RightBreast;

	// Token: 0x040016F2 RID: 5874
	public Transform LeftBreast;

	// Token: 0x040016F3 RID: 5875
	public Transform ItemParent;

	// Token: 0x040016F4 RID: 5876
	public Transform PelvisRoot;

	// Token: 0x040016F5 RID: 5877
	public Transform RightEye;

	// Token: 0x040016F6 RID: 5878
	public Transform LeftEye;

	// Token: 0x040016F7 RID: 5879
	public Transform Head;

	// Token: 0x040016F8 RID: 5880
	public Transform[] Spine;

	// Token: 0x040016F9 RID: 5881
	public Transform[] Arm;

	// Token: 0x040016FA RID: 5882
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040016FB RID: 5883
	public Renderer RightYandereEye;

	// Token: 0x040016FC RID: 5884
	public Renderer LeftYandereEye;
}
