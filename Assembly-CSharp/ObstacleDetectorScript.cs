using UnityEngine;

public class ObstacleDetectorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public int Obstacles;

	public int Frame;

	public int ID;

	private void Update()
	{
		Frame++;
		if (Frame == 3)
		{
			Frame = 0;
			Obstacles = 0;
			base.gameObject.SetActive(false);
		}
		else if (Frame == 2)
		{
			if (Obstacles > 0)
			{
				Yandere.NotificationManager.CustomText = "Something's in the way.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Yandere.NotificationManager.CustomText = "You can't set the cello case down here.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else
			{
				Frame = 0;
				Yandere.Container.Drop();
				Yandere.WeaponMenu.UpdateSprites();
				base.gameObject.SetActive(false);
			}
		}
		else
		{
			int frame = Frame;
			int num = 1;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer);
			Obstacles++;
		}
	}
}
