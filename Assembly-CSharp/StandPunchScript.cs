using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001CED RID: 7405 RVA: 0x001574D0 File Offset: 0x001556D0
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x0400348B RID: 13451
	public Collider MyCollider;
}
