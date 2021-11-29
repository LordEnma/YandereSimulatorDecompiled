using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x06001396 RID: 5014 RVA: 0x000B79F6 File Offset: 0x000B5BF6
	private void Start()
	{
		base.gameObject.layer = 1;
	}

	// Token: 0x06001397 RID: 5015 RVA: 0x000B7A04 File Offset: 0x000B5C04
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

	// Token: 0x06001398 RID: 5016 RVA: 0x000B7A84 File Offset: 0x000B5C84
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

	// Token: 0x04001CED RID: 7405
	public StudentScript Student;

	// Token: 0x04001CEE RID: 7406
	public DoorScript Door;
}
