using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x06001981 RID: 6529 RVA: 0x00103B1C File Offset: 0x00101D1C
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

	// Token: 0x040028BF RID: 10431
	public StudentScript Student;

	// Token: 0x040028C0 RID: 10432
	public bool Fireball;

	// Token: 0x040028C1 RID: 10433
	public bool Candle;
}
