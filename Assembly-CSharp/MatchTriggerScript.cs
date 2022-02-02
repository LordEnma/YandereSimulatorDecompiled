using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x06001982 RID: 6530 RVA: 0x00103F54 File Offset: 0x00102154
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

	// Token: 0x040028C5 RID: 10437
	public StudentScript Student;

	// Token: 0x040028C6 RID: 10438
	public bool Fireball;

	// Token: 0x040028C7 RID: 10439
	public bool Candle;
}
