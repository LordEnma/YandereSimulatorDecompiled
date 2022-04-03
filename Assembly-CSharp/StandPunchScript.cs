using System;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D28 RID: 7464 RVA: 0x0015D090 File Offset: 0x0015B290
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x0400353A RID: 13626
	public Collider MyCollider;
}
