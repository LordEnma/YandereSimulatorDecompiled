using System;
using UnityEngine;

// Token: 0x0200048E RID: 1166
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001F38 RID: 7992 RVA: 0x001B9E64 File Offset: 0x001B8064
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

	// Token: 0x06001F39 RID: 7993 RVA: 0x001B9EE0 File Offset: 0x001B80E0
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

	// Token: 0x04004129 RID: 16681
	public GameObject YandereObject;

	// Token: 0x0400412A RID: 16682
	public YandereScript Yandere;

	// Token: 0x0400412B RID: 16683
	public PoliceScript Police;

	// Token: 0x0400412C RID: 16684
	public bool HideNotification;

	// Token: 0x0400412D RID: 16685
	public bool OffLimits;

	// Token: 0x0400412E RID: 16686
	public bool FacultyRoom;
}
