using UnityEngine;

public class InventoryItemScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject ObjectToDectivate;

	public AudioSource MyAudio;

	public bool Suspicious = true;

	public int ID;

	public void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (Suspicious)
		{
			Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
		}
		if (!Suspicious || (Suspicious && !Prompt.Yandere.StudentManager.YandereVisible))
		{
			if (ID == 1)
			{
				Prompt.Yandere.NotificationManager.CustomText = "You stole the cooking utensils!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.Utensils = true;
			}
			else if (ID == 2)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Acquired rotten meat!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.RottenMeat = true;
			}
			else if (ID == 3)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Acquired arts & crafts materials!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.FakeRatMaterials = true;
			}
			ObjectToDectivate.SetActive(value: false);
			Prompt.enabled = false;
			Prompt.Hide();
			if (MyAudio != null)
			{
				MyAudio.Play();
			}
			base.enabled = false;
		}
		else
		{
			Prompt.Yandere.NotificationManager.CustomText = "Not now! Someone can see you!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}
}
