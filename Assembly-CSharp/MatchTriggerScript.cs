using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x060019AC RID: 6572 RVA: 0x00106310 File Offset: 0x00104510
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

	// Token: 0x04002934 RID: 10548
	public StudentScript Student;

	// Token: 0x04002935 RID: 10549
	public bool Fireball;

	// Token: 0x04002936 RID: 10550
	public bool Candle;
}
