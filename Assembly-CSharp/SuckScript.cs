using System;
using UnityEngine;

// Token: 0x02000465 RID: 1125
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E9A RID: 7834 RVA: 0x001A74F8 File Offset: 0x001A56F8
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

	// Token: 0x04003EED RID: 16109
	public StudentScript Student;

	// Token: 0x04003EEE RID: 16110
	public float Strength;
}
