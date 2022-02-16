using System;
using UnityEngine;

// Token: 0x0200028C RID: 652
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013A5 RID: 5029 RVA: 0x000B8426 File Offset: 0x000B6626
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013A6 RID: 5030 RVA: 0x000B8434 File Offset: 0x000B6634
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

	// Token: 0x060013A7 RID: 5031 RVA: 0x000B84B4 File Offset: 0x000B66B4
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

	// Token: 0x04001D1C RID: 7452
	public StudentScript Student;

	// Token: 0x04001D1D RID: 7453
	public DoorScript Door;
}
