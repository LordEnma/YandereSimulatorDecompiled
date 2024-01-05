using UnityEngine;

public class CutRopeScript : MonoBehaviour
{
	public FallingObjectScript FallingObject;

	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.Type == WeaponType.Knife)
			{
				FallingObject.enabled = true;
				Prompt.Hide();
				base.enabled = false;
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "Grab a knife first!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
	}
}
