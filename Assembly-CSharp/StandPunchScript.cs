using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001CEF RID: 7407 RVA: 0x00157914 File Offset: 0x00155B14
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x04003492 RID: 13458
	public Collider MyCollider;
}
