using System;
using UnityEngine;

// Token: 0x0200045D RID: 1117
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E5F RID: 7775 RVA: 0x001A25C0 File Offset: 0x001A07C0
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

	// Token: 0x04003E35 RID: 15925
	public StudentScript Student;

	// Token: 0x04003E36 RID: 15926
	public float Strength;
}
