using System;
using UnityEngine;

// Token: 0x0200037E RID: 894
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A08 RID: 6664 RVA: 0x00111BE2 File Offset: 0x0010FDE2
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A09 RID: 6665 RVA: 0x00111C0A File Offset: 0x0010FE0A
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A60 RID: 10848
	public GameObject Character;

	// Token: 0x04002A61 RID: 10849
	public Transform SkirtCenter;
}
