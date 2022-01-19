using System;
using UnityEngine;

// Token: 0x0200037F RID: 895
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A0C RID: 6668 RVA: 0x001120AA File Offset: 0x001102AA
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A0D RID: 6669 RVA: 0x001120D2 File Offset: 0x001102D2
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A69 RID: 10857
	public GameObject Character;

	// Token: 0x04002A6A RID: 10858
	public Transform SkirtCenter;
}
