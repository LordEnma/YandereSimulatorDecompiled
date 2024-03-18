using UnityEngine;

public class ModernRivalSabotageScript : MonoBehaviour
{
	public BakeSaleScript BakeSale;

	public PromptScript Prompt;

	public int ID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (ID == 1)
		{
			if (Prompt.Yandere.Inventory.EmeticPoisons == 0)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Obtain emetic poison first.";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				return;
			}
			Prompt.Yandere.NotificationManager.CustomText = "Ingredients poisoned!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Prompt.Yandere.Inventory.EmeticPoisons--;
			BakeSale.Poisoned = true;
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}
}
