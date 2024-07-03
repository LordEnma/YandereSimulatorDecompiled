using UnityEngine;

public class FrameScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject ObjectToActivate;

	public bool Framed;

	public int ID;

	private void Start()
	{
		Prompt.enabled = false;
		Prompt.Hide();
		base.enabled = false;
		if ((ID == 1 && DateGlobals.Week == 2) || (ID == 2 && DateGlobals.Week == 2))
		{
			Prompt.enabled = true;
			base.enabled = true;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (ID == 1)
		{
			if (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.Garbage)
			{
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					Prompt.Yandere.NotificationManager.CustomText = "You spread garbage around the room";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					ObjectToActivate.SetActive(value: true);
					Framed = true;
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
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "Bring a bag of garbage here!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		else
		{
			if (ID != 2)
			{
				return;
			}
			if (Prompt.Yandere.Inventory.IDCard)
			{
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					Prompt.Yandere.NotificationManager.CustomText = "You put money on the Cooking Club's debit card";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					Framed = true;
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
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "You need a faculty keycard!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
	}
}
