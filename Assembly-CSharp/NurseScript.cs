using System;
using UnityEngine;

// Token: 0x02000381 RID: 897
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A2A RID: 6698 RVA: 0x001142E2 File Offset: 0x001124E2
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A2B RID: 6699 RVA: 0x0011430A File Offset: 0x0011250A
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002AC8 RID: 10952
	public GameObject Character;

	// Token: 0x04002AC9 RID: 10953
	public Transform SkirtCenter;
}
