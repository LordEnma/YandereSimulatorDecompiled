using System;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A36 RID: 6710 RVA: 0x00114AA6 File Offset: 0x00112CA6
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A37 RID: 6711 RVA: 0x00114ACE File Offset: 0x00112CCE
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002ADE RID: 10974
	public GameObject Character;

	// Token: 0x04002ADF RID: 10975
	public Transform SkirtCenter;
}
