using System;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001CFE RID: 7422 RVA: 0x0015A014 File Offset: 0x00158214
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x040034B6 RID: 13494
	public Collider MyCollider;
}
