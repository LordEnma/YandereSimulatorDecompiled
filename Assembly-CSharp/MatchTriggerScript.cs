using System;
using UnityEngine;

// Token: 0x0200035D RID: 861
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x0600197D RID: 6525 RVA: 0x00103614 File Offset: 0x00101814
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

	// Token: 0x040028B6 RID: 10422
	public StudentScript Student;

	// Token: 0x040028B7 RID: 10423
	public bool Fireball;

	// Token: 0x040028B8 RID: 10424
	public bool Candle;
}
