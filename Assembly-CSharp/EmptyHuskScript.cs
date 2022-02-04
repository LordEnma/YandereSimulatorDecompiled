using System;
using UnityEngine;

// Token: 0x020002A2 RID: 674
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x06001413 RID: 5139 RVA: 0x000BFA90 File Offset: 0x000BDC90
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

	// Token: 0x04001E2F RID: 7727
	public StudentScript TargetStudent;

	// Token: 0x04001E30 RID: 7728
	public Animation MyAnimation;

	// Token: 0x04001E31 RID: 7729
	public GameObject DarkAura;

	// Token: 0x04001E32 RID: 7730
	public Transform Mouth;

	// Token: 0x04001E33 RID: 7731
	public float[] BloodTimes;

	// Token: 0x04001E34 RID: 7732
	public int EatPhase;
}
