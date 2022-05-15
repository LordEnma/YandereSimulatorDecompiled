using System;
using UnityEngine;

// Token: 0x020002A6 RID: 678
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x06001430 RID: 5168 RVA: 0x000C13D8 File Offset: 0x000BF5D8
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

	// Token: 0x04001E71 RID: 7793
	public StudentScript TargetStudent;

	// Token: 0x04001E72 RID: 7794
	public Animation MyAnimation;

	// Token: 0x04001E73 RID: 7795
	public GameObject DarkAura;

	// Token: 0x04001E74 RID: 7796
	public Transform Mouth;

	// Token: 0x04001E75 RID: 7797
	public float[] BloodTimes;

	// Token: 0x04001E76 RID: 7798
	public int EatPhase;
}
