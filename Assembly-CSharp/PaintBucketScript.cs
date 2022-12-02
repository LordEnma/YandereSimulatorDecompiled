using UnityEngine;

public class PaintBucketScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (Prompt.Yandere.StudentManager.OriginalUniforms + Prompt.Yandere.StudentManager.NewUniforms > 1)
		{
			if (Prompt.Yandere.Bloodiness == 0f)
			{
				Prompt.Yandere.Police.RedPaintClothing++;
				Prompt.Yandere.Bloodiness += 100f;
				Prompt.Yandere.RedPaint = true;
				if (Prompt.Yandere.Gloves != null)
				{
					Prompt.Yandere.Gloves.PickUp.RedPaint = true;
					Prompt.Yandere.Gloves.Blood.enabled = true;
				}
			}
		}
		else if (!Prompt.Yandere.ClothingWarning)
		{
			Prompt.Yandere.NotificationManager.CustomText = "Can't do that; no spare clothing";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Prompt.Yandere.StudentManager.TutorialWindow.ShowClothingMessage = true;
			Prompt.Yandere.ClothingWarning = true;
		}
	}
}
