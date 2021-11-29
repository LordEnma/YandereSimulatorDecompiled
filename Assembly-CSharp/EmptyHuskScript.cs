using System;
using UnityEngine;

// Token: 0x020002A0 RID: 672
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x06001408 RID: 5128 RVA: 0x000BEEF8 File Offset: 0x000BD0F8
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

	// Token: 0x04001E04 RID: 7684
	public StudentScript TargetStudent;

	// Token: 0x04001E05 RID: 7685
	public Animation MyAnimation;

	// Token: 0x04001E06 RID: 7686
	public GameObject DarkAura;

	// Token: 0x04001E07 RID: 7687
	public Transform Mouth;

	// Token: 0x04001E08 RID: 7688
	public float[] BloodTimes;

	// Token: 0x04001E09 RID: 7689
	public int EatPhase;
}
