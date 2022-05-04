using System;
using UnityEngine;

// Token: 0x02000449 RID: 1097
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D3A RID: 7482 RVA: 0x0015E098 File Offset: 0x0015C298
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x04003558 RID: 13656
	public Collider MyCollider;
}
