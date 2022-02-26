using System;
using UnityEngine;

// Token: 0x020002A4 RID: 676
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x06001420 RID: 5152 RVA: 0x000C03D4 File Offset: 0x000BE5D4
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

	// Token: 0x04001E43 RID: 7747
	public StudentScript TargetStudent;

	// Token: 0x04001E44 RID: 7748
	public Animation MyAnimation;

	// Token: 0x04001E45 RID: 7749
	public GameObject DarkAura;

	// Token: 0x04001E46 RID: 7750
	public Transform Mouth;

	// Token: 0x04001E47 RID: 7751
	public float[] BloodTimes;

	// Token: 0x04001E48 RID: 7752
	public int EatPhase;
}
