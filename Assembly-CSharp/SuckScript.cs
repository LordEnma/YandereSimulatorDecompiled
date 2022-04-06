using System;
using UnityEngine;

// Token: 0x02000465 RID: 1125
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E94 RID: 7828 RVA: 0x001A6B20 File Offset: 0x001A4D20
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

	// Token: 0x04003EDD RID: 16093
	public StudentScript Student;

	// Token: 0x04003EDE RID: 16094
	public float Strength;
}
