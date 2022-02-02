using System;
using UnityEngine;

// Token: 0x0200037F RID: 895
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A0D RID: 6669 RVA: 0x001124EE File Offset: 0x001106EE
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A0E RID: 6670 RVA: 0x00112516 File Offset: 0x00110716
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A6F RID: 10863
	public GameObject Character;

	// Token: 0x04002A70 RID: 10864
	public Transform SkirtCenter;
}
