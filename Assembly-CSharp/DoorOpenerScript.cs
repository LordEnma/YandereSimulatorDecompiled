using System;
using UnityEngine;

// Token: 0x0200028A RID: 650
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x0600139D RID: 5021 RVA: 0x000B81C2 File Offset: 0x000B63C2
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x0600139E RID: 5022 RVA: 0x000B81D0 File Offset: 0x000B63D0
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

	// Token: 0x0600139F RID: 5023 RVA: 0x000B8250 File Offset: 0x000B6450
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

	// Token: 0x04001D10 RID: 7440
	public StudentScript Student;

	// Token: 0x04001D11 RID: 7441
	public DoorScript Door;
}
