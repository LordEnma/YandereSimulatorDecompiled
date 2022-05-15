using System;
using UnityEngine;

// Token: 0x02000363 RID: 867
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x060019B6 RID: 6582 RVA: 0x00107018 File Offset: 0x00105218
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = other.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
			if (this.Student != null && this.Student.StudentID > 1 && (this.Student.Gas || this.Fireball))
			{
				this.Student.Combust();
				if (!this.Candle)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x0400294E RID: 10574
	public StudentScript Student;

	// Token: 0x0400294F RID: 10575
	public bool Fireball;

	// Token: 0x04002950 RID: 10576
	public bool Candle;
}
