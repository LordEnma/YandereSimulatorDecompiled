using System;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001CFC RID: 7420 RVA: 0x00159D78 File Offset: 0x00157F78
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x040034B2 RID: 13490
	public Collider MyCollider;
}
