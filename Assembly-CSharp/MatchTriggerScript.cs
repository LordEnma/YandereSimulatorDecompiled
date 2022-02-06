using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x06001984 RID: 6532 RVA: 0x0010411C File Offset: 0x0010231C
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

	// Token: 0x040028C9 RID: 10441
	public StudentScript Student;

	// Token: 0x040028CA RID: 10442
	public bool Fireball;

	// Token: 0x040028CB RID: 10443
	public bool Candle;
}
