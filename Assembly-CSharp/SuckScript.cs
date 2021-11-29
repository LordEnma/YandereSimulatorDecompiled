using System;
using UnityEngine;

// Token: 0x02000459 RID: 1113
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E40 RID: 7744 RVA: 0x0019F4BC File Offset: 0x0019D6BC
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

	// Token: 0x04003DD3 RID: 15827
	public StudentScript Student;

	// Token: 0x04003DD4 RID: 15828
	public float Strength;
}
