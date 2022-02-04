using System;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001CFC RID: 7420 RVA: 0x00159E7C File Offset: 0x0015807C
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x040034B3 RID: 13491
	public Collider MyCollider;
}
