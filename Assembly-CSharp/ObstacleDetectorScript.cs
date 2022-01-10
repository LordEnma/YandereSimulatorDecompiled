using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class ObstacleDetectorScript : MonoBehaviour
{
	// Token: 0x06001A15 RID: 6677 RVA: 0x00112314 File Offset: 0x00110514
	private void Update()
	{
		this.Frame++;
		if (this.Frame == 3)
		{
			this.Frame = 0;
			this.Obstacles = 0;
			base.gameObject.SetActive(false);
			return;
		}
		if (this.Frame != 2)
		{
			int frame = this.Frame;
			return;
		}
		if (this.Obstacles > 0)
		{
			this.Yandere.NotificationManager.CustomText = "Something's in the way.";
			this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			this.Yandere.NotificationManager.CustomText = "You can't set the cello case down here.";
			this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		this.Frame = 0;
		this.Yandere.Container.Drop();
		this.Yandere.WeaponMenu.UpdateSprites();
		base.gameObject.SetActive(false);
	}

	// Token: 0x06001A16 RID: 6678 RVA: 0x001123F4 File Offset: 0x001105F4
	private void OnTriggerEnter(Collider other)
	{
		if (this.Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString());
			this.Obstacles++;
		}
	}

	// Token: 0x04002A73 RID: 10867
	public YandereScript Yandere;

	// Token: 0x04002A74 RID: 10868
	public int Obstacles;

	// Token: 0x04002A75 RID: 10869
	public int Frame;

	// Token: 0x04002A76 RID: 10870
	public int ID;
}
