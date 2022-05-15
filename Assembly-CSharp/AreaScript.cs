using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000D3 RID: 211
public class AreaScript : MonoBehaviour
{
	// Token: 0x060009DB RID: 2523 RVA: 0x0005244C File Offset: 0x0005064C
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

	// Token: 0x060009DC RID: 2524 RVA: 0x00052490 File Offset: 0x00050690
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

	// Token: 0x04000A69 RID: 2665
	[Header("Do not touch any of these values. They get updated at runtime.")]
	[Tooltip("The amount of students in this area.")]
	public int Population;

	// Token: 0x04000A6A RID: 2666
	[Tooltip("A list of students in this area.")]
	public List<StudentScript> Students;

	// Token: 0x04000A6B RID: 2667
	[Tooltip("This area's crowd. Students will go here.")]
	public List<StudentScript> Crowd;

	// Token: 0x04000A6C RID: 2668
	public int ID;
}
