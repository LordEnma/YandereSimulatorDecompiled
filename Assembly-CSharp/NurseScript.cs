using System;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A3A RID: 6714 RVA: 0x00114D86 File Offset: 0x00112F86
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A3B RID: 6715 RVA: 0x00114DAE File Offset: 0x00112FAE
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002AE6 RID: 10982
	public GameObject Character;

	// Token: 0x04002AE7 RID: 10983
	public Transform SkirtCenter;
}
