using System;
using UnityEngine;

// Token: 0x0200028A RID: 650
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x0600139D RID: 5021 RVA: 0x000B7F92 File Offset: 0x000B6192
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x0600139E RID: 5022 RVA: 0x000B7FA0 File Offset: 0x000B61A0
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

	// Token: 0x0600139F RID: 5023 RVA: 0x000B8020 File Offset: 0x000B6220
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

	// Token: 0x04001D0D RID: 7437
	public StudentScript Student;

	// Token: 0x04001D0E RID: 7438
	public DoorScript Door;
}
