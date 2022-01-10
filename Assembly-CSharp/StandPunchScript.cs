using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001CF9 RID: 7417 RVA: 0x001581A0 File Offset: 0x001563A0
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x040034A6 RID: 13478
	public Collider MyCollider;
}
