using System;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001F01 RID: 7937 RVA: 0x001B466C File Offset: 0x001B286C
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

	// Token: 0x06001F02 RID: 7938 RVA: 0x001B46E8 File Offset: 0x001B28E8
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

	// Token: 0x04004071 RID: 16497
	public GameObject YandereObject;

	// Token: 0x04004072 RID: 16498
	public YandereScript Yandere;

	// Token: 0x04004073 RID: 16499
	public PoliceScript Police;

	// Token: 0x04004074 RID: 16500
	public bool HideNotification;

	// Token: 0x04004075 RID: 16501
	public bool OffLimits;

	// Token: 0x04004076 RID: 16502
	public bool FacultyRoom;
}
