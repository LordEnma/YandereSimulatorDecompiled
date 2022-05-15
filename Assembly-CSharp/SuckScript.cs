using System;
using UnityEngine;

// Token: 0x02000467 RID: 1127
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001EAC RID: 7852 RVA: 0x001A9A1C File Offset: 0x001A7C1C
	private void Update()
	{
		this.Strength += Time.deltaTime;
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Student.Yandere.Hips.position + base.transform.up * 0.25f, Time.deltaTime * this.Strength);
		if (Vector3.Distance(base.transform.position, this.Student.Yandere.Hips.position + base.transform.up * 0.25f) < 1f)
		{
			base.transform.localScale = Vector3.MoveTowards(base.transform.localScale, Vector3.zero, Time.deltaTime);
			if (base.transform.localScale == Vector3.zero)
			{
				base.transform.parent.parent.parent.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x04003F20 RID: 16160
	public StudentScript Student;

	// Token: 0x04003F21 RID: 16161
	public float Strength;
}
