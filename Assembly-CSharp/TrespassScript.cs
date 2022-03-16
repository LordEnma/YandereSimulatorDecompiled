using System;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001F16 RID: 7958 RVA: 0x001B658C File Offset: 0x001B478C
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

	// Token: 0x06001F17 RID: 7959 RVA: 0x001B6608 File Offset: 0x001B4808
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

	// Token: 0x040040D3 RID: 16595
	public GameObject YandereObject;

	// Token: 0x040040D4 RID: 16596
	public YandereScript Yandere;

	// Token: 0x040040D5 RID: 16597
	public PoliceScript Police;

	// Token: 0x040040D6 RID: 16598
	public bool HideNotification;

	// Token: 0x040040D7 RID: 16599
	public bool OffLimits;

	// Token: 0x040040D8 RID: 16600
	public bool FacultyRoom;
}
