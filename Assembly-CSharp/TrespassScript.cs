using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001EEC RID: 7916 RVA: 0x001B31A0 File Offset: 0x001B13A0
	private void OnTriggerEnter(Collider other)
	{
		if (base.enabled && other.gameObject.layer == 13)
		{
			this.YandereObject = other.gameObject;
			this.Yandere = other.gameObject.GetComponent<YandereScript>();
			if (this.Yandere != null)
			{
				if (!this.Yandere.Trespassing)
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Intrude);
				}
				this.Yandere.Trespassing = true;
			}
		}
	}

	// Token: 0x06001EED RID: 7917 RVA: 0x001B321C File Offset: 0x001B141C
	private void OnTriggerExit(Collider other)
	{
		if (this.Yandere != null && other.gameObject == this.YandereObject)
		{
			this.Yandere.Trespassing = false;
			if (this.FacultyRoom)
			{
				this.Yandere.StudentManager.CanSelfReport = false;
				this.Yandere.StudentManager.UpdateTeachers();
			}
		}
	}

	// Token: 0x0400404F RID: 16463
	public GameObject YandereObject;

	// Token: 0x04004050 RID: 16464
	public YandereScript Yandere;

	// Token: 0x04004051 RID: 16465
	public PoliceScript Police;

	// Token: 0x04004052 RID: 16466
	public bool HideNotification;

	// Token: 0x04004053 RID: 16467
	public bool OffLimits;

	// Token: 0x04004054 RID: 16468
	public bool FacultyRoom;
}
