using System;
using UnityEngine;

// Token: 0x02000381 RID: 897
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A20 RID: 6688 RVA: 0x001137D2 File Offset: 0x001119D2
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A21 RID: 6689 RVA: 0x001137FA File Offset: 0x001119FA
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A9F RID: 10911
	public GameObject Character;

	// Token: 0x04002AA0 RID: 10912
	public Transform SkirtCenter;
}
