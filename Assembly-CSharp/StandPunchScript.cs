using System;
using UnityEngine;

// Token: 0x02000448 RID: 1096
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D33 RID: 7475 RVA: 0x0015D83C File Offset: 0x0015BA3C
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x04003549 RID: 13641
	public Collider MyCollider;
}
