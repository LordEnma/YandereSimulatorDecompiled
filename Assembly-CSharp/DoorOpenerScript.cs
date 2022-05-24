using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013BE RID: 5054 RVA: 0x000B9DBE File Offset: 0x000B7FBE
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013BF RID: 5055 RVA: 0x000B9DCC File Offset: 0x000B7FCC
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

	// Token: 0x060013C0 RID: 5056 RVA: 0x000B9E4C File Offset: 0x000B804C
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

	// Token: 0x04001D58 RID: 7512
	public StudentScript Student;

	// Token: 0x04001D59 RID: 7513
	public DoorScript Door;
}
