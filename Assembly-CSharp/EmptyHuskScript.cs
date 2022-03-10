using System;
using UnityEngine;

// Token: 0x020002A4 RID: 676
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x06001420 RID: 5152 RVA: 0x000C0520 File Offset: 0x000BE720
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

	// Token: 0x04001E4C RID: 7756
	public StudentScript TargetStudent;

	// Token: 0x04001E4D RID: 7757
	public Animation MyAnimation;

	// Token: 0x04001E4E RID: 7758
	public GameObject DarkAura;

	// Token: 0x04001E4F RID: 7759
	public Transform Mouth;

	// Token: 0x04001E50 RID: 7760
	public float[] BloodTimes;

	// Token: 0x04001E51 RID: 7761
	public int EatPhase;
}
