using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x06001974 RID: 6516 RVA: 0x00102AF8 File Offset: 0x00100CF8
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

	// Token: 0x0400288D RID: 10381
	public StudentScript Student;

	// Token: 0x0400288E RID: 10382
	public bool Fireball;

	// Token: 0x0400288F RID: 10383
	public bool Candle;
}
