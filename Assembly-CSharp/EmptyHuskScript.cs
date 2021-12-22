using System;
using UnityEngine;

// Token: 0x020002A1 RID: 673
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x0600140F RID: 5135 RVA: 0x000BF51C File Offset: 0x000BD71C
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

	// Token: 0x04001E24 RID: 7716
	public StudentScript TargetStudent;

	// Token: 0x04001E25 RID: 7717
	public Animation MyAnimation;

	// Token: 0x04001E26 RID: 7718
	public GameObject DarkAura;

	// Token: 0x04001E27 RID: 7719
	public Transform Mouth;

	// Token: 0x04001E28 RID: 7720
	public float[] BloodTimes;

	// Token: 0x04001E29 RID: 7721
	public int EatPhase;
}
