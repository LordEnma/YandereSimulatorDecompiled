using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x060013A0 RID: 5024 RVA: 0x000B825E File Offset: 0x000B645E
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x060013A1 RID: 5025 RVA: 0x000B826C File Offset: 0x000B646C
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

	// Token: 0x060013A2 RID: 5026 RVA: 0x000B82EC File Offset: 0x000B64EC
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

	// Token: 0x04001D11 RID: 7441
	public StudentScript Student;

	// Token: 0x04001D12 RID: 7442
	public DoorScript Door;
}
