using System;
using UnityEngine;

public class BountyPromptScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public HologramScript Hologram;

	public PromptScript Prompt;

	public StudentScript Horo;

	public Renderer MyRenderer;

	private void Start()
	{
		if (DateGlobals.Week != 2 || DateGlobals.Weekday != DayOfWeek.Wednesday || GameGlobals.Eighties)
		{
			Hide();
		}
	}

	private void Update()
	{
		if (StudentManager.Students[62] != null)
		{
			Horo = StudentManager.Students[62];
			if (Horo.ScienceProps[0].activeInHierarchy)
			{
				MyRenderer.enabled = false;
				Prompt.Hide();
				Prompt.enabled = false;
			}
			else if (!MyRenderer.enabled)
			{
				MyRenderer.enabled = true;
				Prompt.enabled = true;
			}
		}
		else
		{
			Debug.Log("Horo's BountyPrompt thinks that Horo does not exist.");
			Hide();
		}
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
