using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000D3 RID: 211
public class AreaScript : MonoBehaviour
{
	// Token: 0x060009DB RID: 2523 RVA: 0x0005208C File Offset: 0x0005028C
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Student"))
		{
			StudentScript component = other.GetComponent<StudentScript>();
			if (!component.Teacher)
			{
				this.Students.Add(component);
				this.Population++;
			}
		}
	}

	// Token: 0x060009DC RID: 2524 RVA: 0x000520D0 File Offset: 0x000502D0
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Student"))
		{
			StudentScript component = other.GetComponent<StudentScript>();
			if (!component.Teacher)
			{
				this.Students.Remove(component);
				this.Population--;
			}
		}
	}

	// Token: 0x04000A5D RID: 2653
	[Header("Do not touch any of these values. They get updated at runtime.")]
	[Tooltip("The amount of students in this area.")]
	public int Population;

	// Token: 0x04000A5E RID: 2654
	[Tooltip("A list of students in this area.")]
	public List<StudentScript> Students;

	// Token: 0x04000A5F RID: 2655
	[Tooltip("This area's crowd. Students will go here.")]
	public List<StudentScript> Crowd;

	// Token: 0x04000A60 RID: 2656
	public int ID;
}
