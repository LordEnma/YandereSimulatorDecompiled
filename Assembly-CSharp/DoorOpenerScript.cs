using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013A1 RID: 5025 RVA: 0x000B841A File Offset: 0x000B661A
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013A2 RID: 5026 RVA: 0x000B8428 File Offset: 0x000B6628
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

	// Token: 0x060013A3 RID: 5027 RVA: 0x000B84A8 File Offset: 0x000B66A8
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

	// Token: 0x04001D16 RID: 7446
	public StudentScript Student;

	// Token: 0x04001D17 RID: 7447
	public DoorScript Door;
}
