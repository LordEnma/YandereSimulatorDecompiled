using System;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001F28 RID: 7976 RVA: 0x001B8020 File Offset: 0x001B6220
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

	// Token: 0x06001F29 RID: 7977 RVA: 0x001B809C File Offset: 0x001B629C
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

	// Token: 0x04004103 RID: 16643
	public GameObject YandereObject;

	// Token: 0x04004104 RID: 16644
	public YandereScript Yandere;

	// Token: 0x04004105 RID: 16645
	public PoliceScript Police;

	// Token: 0x04004106 RID: 16646
	public bool HideNotification;

	// Token: 0x04004107 RID: 16647
	public bool OffLimits;

	// Token: 0x04004108 RID: 16648
	public bool FacultyRoom;
}
