using UnityEngine;

public class TutorialObjectScript : MonoBehaviour
{
	public GameObject Self;

	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (!Prompt.Yandere.StudentManager.YandereVisible)
			{
				Self.SetActive(false);
				Prompt.enabled = false;
				Prompt.Hide();
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
	}
}
