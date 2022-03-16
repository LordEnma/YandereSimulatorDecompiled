using System;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D1E RID: 7454 RVA: 0x0015C4FC File Offset: 0x0015A6FC
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x0400351D RID: 13597
	public Collider MyCollider;
}
