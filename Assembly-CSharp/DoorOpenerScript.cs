using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013B1 RID: 5041 RVA: 0x000B92AA File Offset: 0x000B74AA
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013B2 RID: 5042 RVA: 0x000B92B8 File Offset: 0x000B74B8
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

	// Token: 0x060013B3 RID: 5043 RVA: 0x000B9338 File Offset: 0x000B7538
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

	// Token: 0x04001D42 RID: 7490
	public StudentScript Student;

	// Token: 0x04001D43 RID: 7491
	public DoorScript Door;
}
