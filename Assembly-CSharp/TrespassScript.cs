using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001EDA RID: 7898 RVA: 0x001B1198 File Offset: 0x001AF398
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

	// Token: 0x06001EDB RID: 7899 RVA: 0x001B1214 File Offset: 0x001AF414
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

	// Token: 0x04004025 RID: 16421
	public GameObject YandereObject;

	// Token: 0x04004026 RID: 16422
	public YandereScript Yandere;

	// Token: 0x04004027 RID: 16423
	public PoliceScript Police;

	// Token: 0x04004028 RID: 16424
	public bool HideNotification;

	// Token: 0x04004029 RID: 16425
	public bool OffLimits;

	// Token: 0x0400402A RID: 16426
	public bool FacultyRoom;
}
