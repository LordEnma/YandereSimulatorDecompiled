using System;
using UnityEngine;

// Token: 0x020002A4 RID: 676
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x06001424 RID: 5156 RVA: 0x000C0A54 File Offset: 0x000BEC54
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

	// Token: 0x04001E5E RID: 7774
	public StudentScript TargetStudent;

	// Token: 0x04001E5F RID: 7775
	public Animation MyAnimation;

	// Token: 0x04001E60 RID: 7776
	public GameObject DarkAura;

	// Token: 0x04001E61 RID: 7777
	public Transform Mouth;

	// Token: 0x04001E62 RID: 7778
	public float[] BloodTimes;

	// Token: 0x04001E63 RID: 7779
	public int EatPhase;
}
