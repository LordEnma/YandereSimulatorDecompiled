using System;
using UnityEngine;

// Token: 0x0200035D RID: 861
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x0600197B RID: 6523 RVA: 0x00103354 File Offset: 0x00101554
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

	// Token: 0x040028B2 RID: 10418
	public StudentScript Student;

	// Token: 0x040028B3 RID: 10419
	public bool Fireball;

	// Token: 0x040028B4 RID: 10420
	public bool Candle;
}
