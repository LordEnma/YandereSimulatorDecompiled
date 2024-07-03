using UnityEngine;

public class InventoryItemScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject ObjectToDectivate;

	public int ID;

	public void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
		if (!Prompt.Yandere.StudentManager.YandereVisible)
		{
			if (ID == 1)
			{
				Prompt.Yandere.NotificationManager.CustomText = "You stole the cooking utensils";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.Utensils = true;
			}
			ObjectToDectivate.SetActive(value: false);
			Prompt.enabled = false;
			Prompt.Hide();
			base.enabled = false;
		}
		else
		{
			Prompt.Yandere.NotificationManager.CustomText = "Not now! Someone can see you!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}
}
