using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x060019A2 RID: 6562 RVA: 0x00105F7C File Offset: 0x0010417C
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

	// Token: 0x04002929 RID: 10537
	public StudentScript Student;

	// Token: 0x0400292A RID: 10538
	public bool Fireball;

	// Token: 0x0400292B RID: 10539
	public bool Candle;
}
