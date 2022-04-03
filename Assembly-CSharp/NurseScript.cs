using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A30 RID: 6704 RVA: 0x0011493A File Offset: 0x00112B3A
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A31 RID: 6705 RVA: 0x00114962 File Offset: 0x00112B62
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002ADB RID: 10971
	public GameObject Character;

	// Token: 0x04002ADC RID: 10972
	public Transform SkirtCenter;
}
