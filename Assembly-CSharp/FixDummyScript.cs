using UnityEngine;

public class FixDummyScript : MonoBehaviour
{
	public GameObject FixedDummy;

	public PromptScript Prompt;

	private void Start()
	{
		FixedDummy.SetActive(false);
		if (GameGlobals.Eighties)
		{
			Fix();
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.WeaponID == 24)
			{
				Fix();
				return;
			}
			Prompt.Yandere.NotificationManager.CustomText = "Wrench required!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	private void Fix()
	{
		base.gameObject.SetActive(false);
		FixedDummy.SetActive(true);
		Prompt.enabled = false;
		Prompt.Hide();
	}
}
