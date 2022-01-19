using System;
using UnityEngine;

// Token: 0x020002A2 RID: 674
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x06001412 RID: 5138 RVA: 0x000BF86C File Offset: 0x000BDA6C
	private void Update()
	{
		if (this.EatPhase < this.BloodTimes.Length && this.MyAnimation["f02_sixEat_00"].time > this.BloodTimes[this.EatPhase])
		{
			UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.Mouth.position, Quaternion.identity).GetComponent<RandomStabScript>().Biting = true;
			this.EatPhase++;
		}
		if (this.MyAnimation["f02_sixEat_00"].time >= this.MyAnimation["f02_sixEat_00"].length)
		{
			if (this.DarkAura != null)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.DarkAura, base.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001E2A RID: 7722
	public StudentScript TargetStudent;

	// Token: 0x04001E2B RID: 7723
	public Animation MyAnimation;

	// Token: 0x04001E2C RID: 7724
	public GameObject DarkAura;

	// Token: 0x04001E2D RID: 7725
	public Transform Mouth;

	// Token: 0x04001E2E RID: 7726
	public float[] BloodTimes;

	// Token: 0x04001E2F RID: 7727
	public int EatPhase;
}
