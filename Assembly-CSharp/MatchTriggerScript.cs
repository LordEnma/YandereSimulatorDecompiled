using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x060019A8 RID: 6568 RVA: 0x0010607C File Offset: 0x0010427C
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

	// Token: 0x0400292C RID: 10540
	public StudentScript Student;

	// Token: 0x0400292D RID: 10541
	public bool Fireball;

	// Token: 0x0400292E RID: 10542
	public bool Candle;
}
