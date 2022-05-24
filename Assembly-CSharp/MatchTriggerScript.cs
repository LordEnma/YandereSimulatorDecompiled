using System;
using UnityEngine;

// Token: 0x02000363 RID: 867
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x060019B7 RID: 6583 RVA: 0x0010721C File Offset: 0x0010541C
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

	// Token: 0x04002955 RID: 10581
	public StudentScript Student;

	// Token: 0x04002956 RID: 10582
	public bool Fireball;

	// Token: 0x04002957 RID: 10583
	public bool Candle;
}
