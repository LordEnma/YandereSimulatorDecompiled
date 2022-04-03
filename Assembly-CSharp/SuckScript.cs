using System;
using UnityEngine;

// Token: 0x02000464 RID: 1124
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E8C RID: 7820 RVA: 0x001A662C File Offset: 0x001A482C
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

	// Token: 0x04003EDA RID: 16090
	public StudentScript Student;

	// Token: 0x04003EDB RID: 16091
	public float Strength;
}
