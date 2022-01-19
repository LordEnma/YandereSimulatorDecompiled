using System;
using UnityEngine;

// Token: 0x0200045D RID: 1117
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E59 RID: 7769 RVA: 0x001A1C24 File Offset: 0x0019FE24
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

	// Token: 0x04003E25 RID: 15909
	public StudentScript Student;

	// Token: 0x04003E26 RID: 15910
	public float Strength;
}
