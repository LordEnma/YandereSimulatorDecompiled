using System;
using UnityEngine;

// Token: 0x02000448 RID: 1096
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D2F RID: 7471 RVA: 0x0015D3B0 File Offset: 0x0015B5B0
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x0400353D RID: 13629
	public Collider MyCollider;
}
