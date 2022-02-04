using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001EEE RID: 7918 RVA: 0x001B34AC File Offset: 0x001B16AC
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

	// Token: 0x06001EEF RID: 7919 RVA: 0x001B3528 File Offset: 0x001B1728
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

	// Token: 0x04004055 RID: 16469
	public GameObject YandereObject;

	// Token: 0x04004056 RID: 16470
	public YandereScript Yandere;

	// Token: 0x04004057 RID: 16471
	public PoliceScript Police;

	// Token: 0x04004058 RID: 16472
	public bool HideNotification;

	// Token: 0x04004059 RID: 16473
	public bool OffLimits;

	// Token: 0x0400405A RID: 16474
	public bool FacultyRoom;
}
