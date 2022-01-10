using System;
using UnityEngine;

// Token: 0x02000483 RID: 1155
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001EE8 RID: 7912 RVA: 0x001B1FF0 File Offset: 0x001B01F0
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

	// Token: 0x06001EE9 RID: 7913 RVA: 0x001B206C File Offset: 0x001B026C
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

	// Token: 0x04004040 RID: 16448
	public GameObject YandereObject;

	// Token: 0x04004041 RID: 16449
	public YandereScript Yandere;

	// Token: 0x04004042 RID: 16450
	public PoliceScript Police;

	// Token: 0x04004043 RID: 16451
	public bool HideNotification;

	// Token: 0x04004044 RID: 16452
	public bool OffLimits;

	// Token: 0x04004045 RID: 16453
	public bool FacultyRoom;
}
