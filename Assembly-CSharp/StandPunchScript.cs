using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001CE5 RID: 7397 RVA: 0x00156BAC File Offset: 0x00154DAC
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x04003460 RID: 13408
	public Collider MyCollider;
}
