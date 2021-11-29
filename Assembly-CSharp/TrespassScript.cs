using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001ED0 RID: 7888 RVA: 0x001B03C8 File Offset: 0x001AE5C8
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

	// Token: 0x06001ED1 RID: 7889 RVA: 0x001B0444 File Offset: 0x001AE644
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

	// Token: 0x04003FF5 RID: 16373
	public GameObject YandereObject;

	// Token: 0x04003FF6 RID: 16374
	public YandereScript Yandere;

	// Token: 0x04003FF7 RID: 16375
	public PoliceScript Police;

	// Token: 0x04003FF8 RID: 16376
	public bool HideNotification;

	// Token: 0x04003FF9 RID: 16377
	public bool OffLimits;

	// Token: 0x04003FFA RID: 16378
	public bool FacultyRoom;
}
