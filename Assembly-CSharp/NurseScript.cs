using System;
using UnityEngine;

// Token: 0x0200037F RID: 895
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A0C RID: 6668 RVA: 0x00111F42 File Offset: 0x00110142
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A0D RID: 6669 RVA: 0x00111F6A File Offset: 0x0011016A
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A66 RID: 10854
	public GameObject Character;

	// Token: 0x04002A67 RID: 10855
	public Transform SkirtCenter;
}
