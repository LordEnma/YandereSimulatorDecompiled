using System;
using UnityEngine;

// Token: 0x02000384 RID: 900
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A45 RID: 6725 RVA: 0x00115D7E File Offset: 0x00113F7E
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A46 RID: 6726 RVA: 0x00115DA6 File Offset: 0x00113FA6
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002B08 RID: 11016
	public GameObject Character;

	// Token: 0x04002B09 RID: 11017
	public Transform SkirtCenter;
}
