using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D10 RID: 7440 RVA: 0x0015B34C File Offset: 0x0015954C
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x040034E2 RID: 13538
	public Collider MyCollider;
}
