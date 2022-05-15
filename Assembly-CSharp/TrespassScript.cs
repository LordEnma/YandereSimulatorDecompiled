using System;
using UnityEngine;

// Token: 0x0200048F RID: 1167
public class TrespassScript : MonoBehaviour
{
	// Token: 0x06001F40 RID: 8000 RVA: 0x001BAFDC File Offset: 0x001B91DC
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

	// Token: 0x06001F41 RID: 8001 RVA: 0x001BB058 File Offset: 0x001B9258
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

	// Token: 0x04004147 RID: 16711
	public GameObject YandereObject;

	// Token: 0x04004148 RID: 16712
	public YandereScript Yandere;

	// Token: 0x04004149 RID: 16713
	public PoliceScript Police;

	// Token: 0x0400414A RID: 16714
	public bool HideNotification;

	// Token: 0x0400414B RID: 16715
	public bool OffLimits;

	// Token: 0x0400414C RID: 16716
	public bool FacultyRoom;
}
