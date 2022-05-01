using System;
using UnityEngine;

// Token: 0x020002A5 RID: 677
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x0600142E RID: 5166 RVA: 0x000C1198 File Offset: 0x000BF398
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

	// Token: 0x04001E6A RID: 7786
	public StudentScript TargetStudent;

	// Token: 0x04001E6B RID: 7787
	public Animation MyAnimation;

	// Token: 0x04001E6C RID: 7788
	public GameObject DarkAura;

	// Token: 0x04001E6D RID: 7789
	public Transform Mouth;

	// Token: 0x04001E6E RID: 7790
	public float[] BloodTimes;

	// Token: 0x04001E6F RID: 7791
	public int EatPhase;
}
