using UnityEngine;

public class FlyerScript : MonoBehaviour
{
	public GameObject Flyer;

	public PromptScript Prompt;

	public int TaskID = 13;

	private void Start()
	{
		Flyer.SetActive(value: false);
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		if (TaskID == 13)
		{
			Prompt.Yandere.Inventory.Flyers--;
			if (Prompt.Yandere.Inventory.Flyers == 1)
			{
				Prompt.Yandere.NotificationManager.CustomText = Prompt.Yandere.Inventory.Flyers + " flyer remaining!";
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = Prompt.Yandere.Inventory.Flyers + " flyers remaining!";
			}
		}
		else if (TaskID == 17)
		{
			Prompt.Yandere.Inventory.Books--;
			if (Prompt.Yandere.Inventory.Books == 1)
			{
				Prompt.Yandere.NotificationManager.CustomText = Prompt.Yandere.Inventory.Books + " book remaining!";
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = Prompt.Yandere.Inventory.Books + " books remaining!";
			}
		}
		Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		Prompt.Hide();
		Prompt.enabled = false;
		Flyer.SetActive(value: true);
		base.enabled = false;
	}
}
