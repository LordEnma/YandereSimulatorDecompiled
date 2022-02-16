using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x0600198B RID: 6539 RVA: 0x001042C0 File Offset: 0x001024C0
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

	// Token: 0x040028CF RID: 10447
	public StudentScript Student;

	// Token: 0x040028D0 RID: 10448
	public bool Fireball;

	// Token: 0x040028D1 RID: 10449
	public bool Candle;
}
