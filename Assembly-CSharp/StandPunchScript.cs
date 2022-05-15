using System;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D40 RID: 7488 RVA: 0x0015ED4C File Offset: 0x0015CF4C
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x0400356D RID: 13677
	public Collider MyCollider;
}
