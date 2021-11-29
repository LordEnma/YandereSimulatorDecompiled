using System;
using UnityEngine;

// Token: 0x0200037D RID: 893
public class NurseScript : MonoBehaviour
{
	// Token: 0x060019FE RID: 6654 RVA: 0x0011110A File Offset: 0x0010F30A
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x060019FF RID: 6655 RVA: 0x00111132 File Offset: 0x0010F332
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A35 RID: 10805
	public GameObject Character;

	// Token: 0x04002A36 RID: 10806
	public Transform SkirtCenter;
}
