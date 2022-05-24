using System;
using UnityEngine;

// Token: 0x02000467 RID: 1127
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001EAD RID: 7853 RVA: 0x001A9E3C File Offset: 0x001A803C
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

	// Token: 0x04003F29 RID: 16169
	public StudentScript Student;

	// Token: 0x04003F2A RID: 16170
	public float Strength;
}
