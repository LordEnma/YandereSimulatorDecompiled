using System;
using UnityEngine;

// Token: 0x02000381 RID: 897
public class ObstacleDetectorScript : MonoBehaviour
{
	// Token: 0x06001A11 RID: 6673 RVA: 0x00111FB4 File Offset: 0x001101B4
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

	// Token: 0x06001A12 RID: 6674 RVA: 0x00112094 File Offset: 0x00110294
	private void OnTriggerEnter(Collider other)
	{
		if (this.Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString());
			this.Obstacles++;
		}
	}

	// Token: 0x04002A6D RID: 10861
	public YandereScript Yandere;

	// Token: 0x04002A6E RID: 10862
	public int Obstacles;

	// Token: 0x04002A6F RID: 10863
	public int Frame;

	// Token: 0x04002A70 RID: 10864
	public int ID;
}
