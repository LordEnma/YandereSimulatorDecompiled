using System;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001F2E RID: 7982 RVA: 0x001B89F8 File Offset: 0x001B6BF8
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

	// Token: 0x06001F2F RID: 7983 RVA: 0x001B8A74 File Offset: 0x001B6C74
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

	// Token: 0x04004113 RID: 16659
	public GameObject YandereObject;

	// Token: 0x04004114 RID: 16660
	public YandereScript Yandere;

	// Token: 0x04004115 RID: 16661
	public PoliceScript Police;

	// Token: 0x04004116 RID: 16662
	public bool HideNotification;

	// Token: 0x04004117 RID: 16663
	public bool OffLimits;

	// Token: 0x04004118 RID: 16664
	public bool FacultyRoom;
}
