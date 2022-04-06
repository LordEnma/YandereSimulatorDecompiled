using System;
using UnityEngine;

// Token: 0x02000386 RID: 902
public class ObstacleDetectorScript : MonoBehaviour
{
	// Token: 0x06001A3F RID: 6719 RVA: 0x00114E78 File Offset: 0x00113078
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

	// Token: 0x06001A40 RID: 6720 RVA: 0x00114F58 File Offset: 0x00113158
	private void OnTriggerEnter(Collider other)
	{
		if (this.Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString());
			this.Obstacles++;
		}
	}

	// Token: 0x04002AEB RID: 10987
	public YandereScript Yandere;

	// Token: 0x04002AEC RID: 10988
	public int Obstacles;

	// Token: 0x04002AED RID: 10989
	public int Frame;

	// Token: 0x04002AEE RID: 10990
	public int ID;
}
