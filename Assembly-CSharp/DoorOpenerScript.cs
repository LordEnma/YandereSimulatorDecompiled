using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013AE RID: 5038 RVA: 0x000B8D66 File Offset: 0x000B6F66
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013AF RID: 5039 RVA: 0x000B8D74 File Offset: 0x000B6F74
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

	// Token: 0x060013B0 RID: 5040 RVA: 0x000B8DF4 File Offset: 0x000B6FF4
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

	// Token: 0x04001D2B RID: 7467
	public StudentScript Student;

	// Token: 0x04001D2C RID: 7468
	public DoorScript Door;
}
