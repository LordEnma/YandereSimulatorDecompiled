using System;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D41 RID: 7489 RVA: 0x0015F008 File Offset: 0x0015D208
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x04003575 RID: 13685
	public Collider MyCollider;
}
