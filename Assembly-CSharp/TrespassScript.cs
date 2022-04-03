using System;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001F20 RID: 7968 RVA: 0x001B7B18 File Offset: 0x001B5D18
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

	// Token: 0x06001F21 RID: 7969 RVA: 0x001B7B94 File Offset: 0x001B5D94
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

	// Token: 0x04004100 RID: 16640
	public GameObject YandereObject;

	// Token: 0x04004101 RID: 16641
	public YandereScript Yandere;

	// Token: 0x04004102 RID: 16642
	public PoliceScript Police;

	// Token: 0x04004103 RID: 16643
	public bool HideNotification;

	// Token: 0x04004104 RID: 16644
	public bool OffLimits;

	// Token: 0x04004105 RID: 16645
	public bool FacultyRoom;
}
