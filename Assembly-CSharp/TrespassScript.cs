using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001EEA RID: 7914 RVA: 0x001B2CC0 File Offset: 0x001B0EC0
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

	// Token: 0x06001EEB RID: 7915 RVA: 0x001B2D3C File Offset: 0x001B0F3C
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

	// Token: 0x04004047 RID: 16455
	public GameObject YandereObject;

	// Token: 0x04004048 RID: 16456
	public YandereScript Yandere;

	// Token: 0x04004049 RID: 16457
	public PoliceScript Police;

	// Token: 0x0400404A RID: 16458
	public bool HideNotification;

	// Token: 0x0400404B RID: 16459
	public bool OffLimits;

	// Token: 0x0400404C RID: 16460
	public bool FacultyRoom;
}
