using System;
using UnityEngine;

// Token: 0x0200045C RID: 1116
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E57 RID: 7767 RVA: 0x001A0F54 File Offset: 0x0019F154
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

	// Token: 0x04003E1E RID: 15902
	public StudentScript Student;

	// Token: 0x04003E1F RID: 15903
	public float Strength;
}
