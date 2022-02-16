using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D05 RID: 7429 RVA: 0x0015A31C File Offset: 0x0015851C
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x040034BC RID: 13500
	public Collider MyCollider;
}
