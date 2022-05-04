using System;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A3E RID: 6718 RVA: 0x00115276 File Offset: 0x00113476
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A3F RID: 6719 RVA: 0x0011529E File Offset: 0x0011349E
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002AEF RID: 10991
	public GameObject Character;

	// Token: 0x04002AF0 RID: 10992
	public Transform SkirtCenter;
}
