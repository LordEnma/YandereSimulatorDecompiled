using System;
using UnityEngine;

// Token: 0x02000380 RID: 896
public class NurseScript : MonoBehaviour
{
	// Token: 0x06001A16 RID: 6678 RVA: 0x001129E6 File Offset: 0x00110BE6
	private void Awake()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	// Token: 0x06001A17 RID: 6679 RVA: 0x00112A0E File Offset: 0x00110C0E
	private void LateUpdate()
	{
		this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
	}

	// Token: 0x04002A79 RID: 10873
	public GameObject Character;

	// Token: 0x04002A7A RID: 10874
	public Transform SkirtCenter;
}
