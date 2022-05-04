using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x060019B0 RID: 6576 RVA: 0x001067DC File Offset: 0x001049DC
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

	// Token: 0x0400293D RID: 10557
	public StudentScript Student;

	// Token: 0x0400293E RID: 10558
	public bool Fireball;

	// Token: 0x0400293F RID: 10559
	public bool Candle;
}
