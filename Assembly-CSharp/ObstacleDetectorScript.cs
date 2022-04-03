using System;
using UnityEngine;

// Token: 0x02000385 RID: 901
public class ObstacleDetectorScript : MonoBehaviour
{
	// Token: 0x06001A39 RID: 6713 RVA: 0x00114D0C File Offset: 0x00112F0C
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

	// Token: 0x06001A3A RID: 6714 RVA: 0x00114DEC File Offset: 0x00112FEC
	private void OnTriggerEnter(Collider other)
	{
		if (this.Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString());
			this.Obstacles++;
		}
	}

	// Token: 0x04002AE8 RID: 10984
	public YandereScript Yandere;

	// Token: 0x04002AE9 RID: 10985
	public int Obstacles;

	// Token: 0x04002AEA RID: 10986
	public int Frame;

	// Token: 0x04002AEB RID: 10987
	public int ID;
}
