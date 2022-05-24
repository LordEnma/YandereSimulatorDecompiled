using System;
using UnityEngine;

// Token: 0x0200048F RID: 1167
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001F41 RID: 8001 RVA: 0x001BB458 File Offset: 0x001B9658
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

	// Token: 0x06001F42 RID: 8002 RVA: 0x001BB4D4 File Offset: 0x001B96D4
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

	// Token: 0x04004150 RID: 16720
	public GameObject YandereObject;

	// Token: 0x04004151 RID: 16721
	public YandereScript Yandere;

	// Token: 0x04004152 RID: 16722
	public PoliceScript Police;

	// Token: 0x04004153 RID: 16723
	public bool HideNotification;

	// Token: 0x04004154 RID: 16724
	public bool OffLimits;

	// Token: 0x04004155 RID: 16725
	public bool FacultyRoom;
}
