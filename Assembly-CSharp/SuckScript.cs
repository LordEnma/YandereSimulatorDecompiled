using System;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001EA4 RID: 7844 RVA: 0x001A88A4 File Offset: 0x001A6AA4
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

	// Token: 0x04003F02 RID: 16130
	public StudentScript Student;

	// Token: 0x04003F03 RID: 16131
	public float Strength;
}
