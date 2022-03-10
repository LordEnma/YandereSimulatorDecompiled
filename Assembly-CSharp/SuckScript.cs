using System;
using UnityEngine;

// Token: 0x0200045F RID: 1119
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E72 RID: 7794 RVA: 0x001A3C04 File Offset: 0x001A1E04
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

	// Token: 0x04003E65 RID: 15973
	public StudentScript Student;

	// Token: 0x04003E66 RID: 15974
	public float Strength;
}
