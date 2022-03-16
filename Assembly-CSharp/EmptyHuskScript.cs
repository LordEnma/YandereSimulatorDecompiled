using System;
using UnityEngine;

// Token: 0x020002A4 RID: 676
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x06001423 RID: 5155 RVA: 0x000C0948 File Offset: 0x000BEB48
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

	// Token: 0x04001E5B RID: 7771
	public StudentScript TargetStudent;

	// Token: 0x04001E5C RID: 7772
	public Animation MyAnimation;

	// Token: 0x04001E5D RID: 7773
	public GameObject DarkAura;

	// Token: 0x04001E5E RID: 7774
	public Transform Mouth;

	// Token: 0x04001E5F RID: 7775
	public float[] BloodTimes;

	// Token: 0x04001E60 RID: 7776
	public int EatPhase;
}
