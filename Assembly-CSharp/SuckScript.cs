using System;
using UnityEngine;

// Token: 0x0200045F RID: 1119
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E6F RID: 7791 RVA: 0x001A3540 File Offset: 0x001A1740
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

	// Token: 0x04003E4E RID: 15950
	public StudentScript Student;

	// Token: 0x04003E4F RID: 15951
	public float Strength;
}
