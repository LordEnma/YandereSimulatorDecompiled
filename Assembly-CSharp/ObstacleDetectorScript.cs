using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class ObstacleDetectorScript : MonoBehaviour
{
	// Token: 0x06001A18 RID: 6680 RVA: 0x00112A94 File Offset: 0x00110C94
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

	// Token: 0x06001A19 RID: 6681 RVA: 0x00112B74 File Offset: 0x00110D74
	private void OnTriggerEnter(Collider other)
	{
		if (this.Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString());
			this.Obstacles++;
		}
	}

	// Token: 0x04002A80 RID: 10880
	public YandereScript Yandere;

	// Token: 0x04002A81 RID: 10881
	public int Obstacles;

	// Token: 0x04002A82 RID: 10882
	public int Frame;

	// Token: 0x04002A83 RID: 10883
	public int ID;
}
