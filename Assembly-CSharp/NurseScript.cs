using System;
using UnityEngine;

// Token: 0x02000381 RID: 897
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A1F RID: 6687 RVA: 0x001133FA File Offset: 0x001115FA
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A20 RID: 6688 RVA: 0x00113422 File Offset: 0x00111622
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A89 RID: 10889
	public GameObject Character;

	// Token: 0x04002A8A RID: 10890
	public Transform SkirtCenter;
}
