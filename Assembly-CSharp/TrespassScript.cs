using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001EDD RID: 7901 RVA: 0x001B1670 File Offset: 0x001AF870
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

	// Token: 0x06001EDE RID: 7902 RVA: 0x001B16EC File Offset: 0x001AF8EC
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

	// Token: 0x0400402C RID: 16428
	public GameObject YandereObject;

	// Token: 0x0400402D RID: 16429
	public YandereScript Yandere;

	// Token: 0x0400402E RID: 16430
	public PoliceScript Police;

	// Token: 0x0400402F RID: 16431
	public bool HideNotification;

	// Token: 0x04004030 RID: 16432
	public bool OffLimits;

	// Token: 0x04004031 RID: 16433
	public bool FacultyRoom;
}
