using UnityEngine;

public class RingScript : MonoBehaviour
{
	public RingEventScript RingEvent;

	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (!Prompt.Yandere.StudentManager.YandereVisible)
			{
				SchemeGlobals.SetSchemeStage(2, 5);
				Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
				Prompt.Yandere.Inventory.Ring = true;
				Prompt.Yandere.TheftTimer = 0.1f;
				RingEvent.RingStolen = true;
				base.gameObject.SetActive(false);
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone is watching!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
	}
}
