using System;
using UnityEngine;

// Token: 0x020002A3 RID: 675
public class EmptyHuskScript : MonoBehaviour
{
	// Token: 0x06001417 RID: 5143 RVA: 0x000BFA78 File Offset: 0x000BDC78
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

	// Token: 0x04001E34 RID: 7732
	public StudentScript TargetStudent;

	// Token: 0x04001E35 RID: 7733
	public Animation MyAnimation;

	// Token: 0x04001E36 RID: 7734
	public GameObject DarkAura;

	// Token: 0x04001E37 RID: 7735
	public Transform Mouth;

	// Token: 0x04001E38 RID: 7736
	public float[] BloodTimes;

	// Token: 0x04001E39 RID: 7737
	public int EatPhase;
}
