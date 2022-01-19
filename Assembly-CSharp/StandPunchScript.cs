using System;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001CFB RID: 7419 RVA: 0x00159938 File Offset: 0x00157B38
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x040034AC RID: 13484
	public Collider MyCollider;
}
