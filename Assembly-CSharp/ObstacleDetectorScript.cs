using System;
using UnityEngine;

// Token: 0x02000380 RID: 896
public class ObstacleDetectorScript : MonoBehaviour
{
	// Token: 0x06001A07 RID: 6663 RVA: 0x001114DC File Offset: 0x0010F6DC
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

	// Token: 0x06001A08 RID: 6664 RVA: 0x001115BC File Offset: 0x0010F7BC
	private void OnTriggerEnter(Collider other)
	{
		if (this.Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString());
			this.Obstacles++;
		}
	}

	// Token: 0x04002A42 RID: 10818
	public YandereScript Yandere;

	// Token: 0x04002A43 RID: 10819
	public int Obstacles;

	// Token: 0x04002A44 RID: 10820
	public int Frame;

	// Token: 0x04002A45 RID: 10821
	public int ID;
}
