using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013B2 RID: 5042 RVA: 0x000B93B6 File Offset: 0x000B75B6
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013B3 RID: 5043 RVA: 0x000B93C4 File Offset: 0x000B75C4
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

	// Token: 0x060013B4 RID: 5044 RVA: 0x000B9444 File Offset: 0x000B7644
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

	// Token: 0x04001D45 RID: 7493
	public StudentScript Student;

	// Token: 0x04001D46 RID: 7494
	public DoorScript Door;
}
