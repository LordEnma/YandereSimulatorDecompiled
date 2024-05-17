using System;
using UnityEngine;

public class BountyPromptScript : MonoBehaviour
{
	public HologramScript Hologram;

	public PromptScript Prompt;

	private void Start()
	{
		if (DateGlobals.Week != 2 || DateGlobals.Weekday != DayOfWeek.Wednesday)
		{
			Hide();
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (Prompt.Yandere.StudentManager.YandereVisible)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone can see you!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				return;
			}
			Prompt.Yandere.NotificationManager.CustomText = "Holograms sabotaged!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Hologram.ReplaceHologram();
			Hide();
		}
	}

	private void Hide()
	{
		Prompt.Hide();
		Prompt.enabled = false;
		base.enabled = false;
	}
}
