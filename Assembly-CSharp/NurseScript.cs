using System;
using UnityEngine;

// Token: 0x0200037F RID: 895
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A0F RID: 6671 RVA: 0x001126C2 File Offset: 0x001108C2
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A10 RID: 6672 RVA: 0x001126EA File Offset: 0x001108EA
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A73 RID: 10867
	public GameObject Character;

	// Token: 0x04002A74 RID: 10868
	public Transform SkirtCenter;
}
