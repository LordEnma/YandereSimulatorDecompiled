using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001EF1 RID: 7921 RVA: 0x001B36CC File Offset: 0x001B18CC
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

	// Token: 0x06001EF2 RID: 7922 RVA: 0x001B3748 File Offset: 0x001B1948
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

	// Token: 0x04004058 RID: 16472
	public GameObject YandereObject;

	// Token: 0x04004059 RID: 16473
	public YandereScript Yandere;

	// Token: 0x0400405A RID: 16474
	public PoliceScript Police;

	// Token: 0x0400405B RID: 16475
	public bool HideNotification;

	// Token: 0x0400405C RID: 16476
	public bool OffLimits;

	// Token: 0x0400405D RID: 16477
	public bool FacultyRoom;
}
