using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013A1 RID: 5025 RVA: 0x000B84E2 File Offset: 0x000B66E2
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013A2 RID: 5026 RVA: 0x000B84F0 File Offset: 0x000B66F0
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

	// Token: 0x060013A3 RID: 5027 RVA: 0x000B8570 File Offset: 0x000B6770
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

	// Token: 0x04001D19 RID: 7449
	public StudentScript Student;

	// Token: 0x04001D1A RID: 7450
	public DoorScript Door;
}
