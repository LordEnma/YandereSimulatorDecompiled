using System;
using UnityEngine;

// Token: 0x0200037E RID: 894
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A06 RID: 6662 RVA: 0x00111906 File Offset: 0x0010FB06
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A07 RID: 6663 RVA: 0x0011192E File Offset: 0x0010FB2E
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A5C RID: 10844
	public GameObject Character;

	// Token: 0x04002A5D RID: 10845
	public Transform SkirtCenter;
}
