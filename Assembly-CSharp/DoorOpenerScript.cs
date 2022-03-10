using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013AE RID: 5038 RVA: 0x000B8ECE File Offset: 0x000B70CE
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013AF RID: 5039 RVA: 0x000B8EDC File Offset: 0x000B70DC
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = other.gameObject.GetComponent<StudentScript>();
			if (this.Student != null && !this.Student.Dying && !this.Door.Open && !this.Door.Locked)
			{
				this.Door.Student = this.Student;
				this.Door.OpenDoor();
			}
		}
	}

	// Token: 0x060013B0 RID: 5040 RVA: 0x000B8F5C File Offset: 0x000B715C
	private void OnTriggerStay(Collider other)
	{
		if (!this.Door.Open && other.gameObject.layer == 9)
		{
			this.Student = other.gameObject.GetComponent<StudentScript>();
			if (this.Student != null && !this.Student.Dying && !this.Door.Open && !this.Door.Locked)
			{
				this.Door.Student = this.Student;
				this.Door.OpenDoor();
			}
		}
	}

	// Token: 0x04001D34 RID: 7476
	public StudentScript Student;

	// Token: 0x04001D35 RID: 7477
	public DoorScript Door;
}
