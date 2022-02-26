using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x06001994 RID: 6548 RVA: 0x00104BF0 File Offset: 0x00102DF0
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

	// Token: 0x040028DE RID: 10462
	public StudentScript Student;

	// Token: 0x040028DF RID: 10463
	public bool Fireball;

	// Token: 0x040028E0 RID: 10464
	public bool Candle;
}
