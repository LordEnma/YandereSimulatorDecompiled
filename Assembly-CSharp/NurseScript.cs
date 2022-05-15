using System;
using UnityEngine;

// Token: 0x02000384 RID: 900
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A44 RID: 6724 RVA: 0x00115B4E File Offset: 0x00113D4E
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A45 RID: 6725 RVA: 0x00115B76 File Offset: 0x00113D76
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002B01 RID: 11009
	public GameObject Character;

	// Token: 0x04002B02 RID: 11010
	public Transform SkirtCenter;
}
