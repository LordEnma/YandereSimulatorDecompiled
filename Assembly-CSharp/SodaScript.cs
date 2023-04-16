using UnityEngine;

public class SodaScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (!Prompt.Yandere.StudentManager.Eighties)
			{
				Prompt.Yandere.Inventory.Soda = true;
			}
			else
			{
				Prompt.Yandere.Inventory.ItemsCollected[5]++;
				Prompt.Yandere.NotificationManager.CustomText = "Got a soda!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			Object.Destroy(base.gameObject);
		}
	}
}
