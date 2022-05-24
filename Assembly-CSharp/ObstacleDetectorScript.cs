using System;
using UnityEngine;

// Token: 0x02000387 RID: 903
public class ObstacleDetectorScript : MonoBehaviour
{
	// Token: 0x06001A4E RID: 6734 RVA: 0x00116150 File Offset: 0x00114350
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

	// Token: 0x06001A4F RID: 6735 RVA: 0x00116230 File Offset: 0x00114430
	private void OnTriggerEnter(Collider other)
	{
		if (this.Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString());
			this.Obstacles++;
		}
	}

	// Token: 0x04002B15 RID: 11029
	public YandereScript Yandere;

	// Token: 0x04002B16 RID: 11030
	public int Obstacles;

	// Token: 0x04002B17 RID: 11031
	public int Frame;

	// Token: 0x04002B18 RID: 11032
	public int ID;
}
