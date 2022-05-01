using System;
using UnityEngine;

// Token: 0x0200028E RID: 654
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013BC RID: 5052 RVA: 0x000B9AE6 File Offset: 0x000B7CE6
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013BD RID: 5053 RVA: 0x000B9AF4 File Offset: 0x000B7CF4
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

	// Token: 0x060013BE RID: 5054 RVA: 0x000B9B74 File Offset: 0x000B7D74
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

	// Token: 0x04001D51 RID: 7505
	public StudentScript Student;

	// Token: 0x04001D52 RID: 7506
	public DoorScript Door;
}
