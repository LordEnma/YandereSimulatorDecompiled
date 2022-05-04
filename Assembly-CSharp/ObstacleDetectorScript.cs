using System;
using UnityEngine;

// Token: 0x02000386 RID: 902
public class ObstacleDetectorScript : MonoBehaviour
{
	// Token: 0x06001A47 RID: 6727 RVA: 0x00115648 File Offset: 0x00113848
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

	// Token: 0x06001A48 RID: 6728 RVA: 0x00115728 File Offset: 0x00113928
	private void OnTriggerEnter(Collider other)
	{
		if (this.Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString());
			this.Obstacles++;
		}
	}

	// Token: 0x04002AFC RID: 11004
	public YandereScript Yandere;

	// Token: 0x04002AFD RID: 11005
	public int Obstacles;

	// Token: 0x04002AFE RID: 11006
	public int Frame;

	// Token: 0x04002AFF RID: 11007
	public int ID;
}
