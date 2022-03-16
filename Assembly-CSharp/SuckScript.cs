using System;
using UnityEngine;

// Token: 0x02000461 RID: 1121
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E82 RID: 7810 RVA: 0x001A5310 File Offset: 0x001A3510
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

	// Token: 0x04003EAF RID: 16047
	public StudentScript Student;

	// Token: 0x04003EB0 RID: 16048
	public float Strength;
}
