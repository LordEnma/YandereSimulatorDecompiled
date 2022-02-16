using System;
using UnityEngine;

// Token: 0x02000485 RID: 1157
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001EF8 RID: 7928 RVA: 0x001B3B20 File Offset: 0x001B1D20
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

	// Token: 0x06001EF9 RID: 7929 RVA: 0x001B3B9C File Offset: 0x001B1D9C
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

	// Token: 0x04004061 RID: 16481
	public GameObject YandereObject;

	// Token: 0x04004062 RID: 16482
	public YandereScript Yandere;

	// Token: 0x04004063 RID: 16483
	public PoliceScript Police;

	// Token: 0x04004064 RID: 16484
	public bool HideNotification;

	// Token: 0x04004065 RID: 16485
	public bool OffLimits;

	// Token: 0x04004066 RID: 16486
	public bool FacultyRoom;
}
