using System;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001F04 RID: 7940 RVA: 0x001B4E0C File Offset: 0x001B300C
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

	// Token: 0x06001F05 RID: 7941 RVA: 0x001B4E88 File Offset: 0x001B3088
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

	// Token: 0x04004088 RID: 16520
	public GameObject YandereObject;

	// Token: 0x04004089 RID: 16521
	public YandereScript Yandere;

	// Token: 0x0400408A RID: 16522
	public PoliceScript Police;

	// Token: 0x0400408B RID: 16523
	public bool HideNotification;

	// Token: 0x0400408C RID: 16524
	public bool OffLimits;

	// Token: 0x0400408D RID: 16525
	public bool FacultyRoom;
}
