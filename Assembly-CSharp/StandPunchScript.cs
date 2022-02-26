using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class StandPunchScript : MonoBehaviour
{
	// Token: 0x06001D0E RID: 7438 RVA: 0x0015ADC8 File Offset: 0x00158FC8
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			component.JojoReact();
		}
	}

	// Token: 0x040034CC RID: 13516
	public Collider MyCollider;
}
