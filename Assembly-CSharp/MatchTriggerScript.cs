using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x0600199C RID: 6556 RVA: 0x001058D0 File Offset: 0x00103AD0
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

	// Token: 0x04002916 RID: 10518
	public StudentScript Student;

	// Token: 0x04002917 RID: 10519
	public bool Fireball;

	// Token: 0x04002918 RID: 10520
	public bool Candle;
}
