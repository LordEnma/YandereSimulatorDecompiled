using UnityEngine;

public class StolenPhoneSpotScript : MonoBehaviour
{
	public RivalPhoneScript RivalPhone;

	public PromptScript Prompt;

	public Transform PhoneSpot;

	private void Update()
	{
		if (Prompt.Yandere.Inventory.RivalPhone)
		{
			Prompt.enabled = true;
			if (Prompt.Circle[0].fillAmount != 0f)
			{
				return;
			}
			Prompt.Circle[0].fillAmount = 1f;
			if (RivalPhone.StudentID == 0)
			{
				RivalPhone.StudentID = Prompt.Yandere.Inventory.RivalPhoneID;
			}
			Debug.Log("RivalPhone.StudentID is: " + RivalPhone.StudentID);
			Debug.Log("this.Prompt.Yandere.StudentManager.Students[RivalPhone.StudentID] is: " + Prompt.Yandere.StudentManager.Students[RivalPhone.StudentID]);
			Debug.Log("this.Prompt.Yandere.StudentManager.Students[RivalPhone.StudentID].Phoneless is: " + Prompt.Yandere.StudentManager.Students[RivalPhone.StudentID].Phoneless);
			if (Prompt.Yandere.StudentManager.Students[RivalPhone.StudentID] != null && Prompt.Yandere.StudentManager.Students[RivalPhone.StudentID].Phoneless)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					if (RivalPhone.StudentID == Prompt.Yandere.StudentManager.RivalID && SchemeGlobals.GetSchemeStage(1) == 6)
					{
						SchemeGlobals.SetSchemeStage(1, 7);
						Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
					}
					Prompt.Yandere.SmartphoneRenderer.material.mainTexture = Prompt.Yandere.YanderePhoneTexture;
					Prompt.Yandere.Inventory.RivalPhone = false;
					Prompt.Yandere.RivalPhone = false;
					RivalPhone.StolenPhoneDropoff.Prompt.enabled = false;
					RivalPhone.StolenPhoneDropoff.Prompt.Hide();
					RivalPhone.transform.parent = null;
					if (PhoneSpot == null)
					{
						RivalPhone.transform.position = base.transform.position;
					}
					else
					{
						RivalPhone.transform.position = PhoneSpot.position;
					}
					RivalPhone.transform.eulerAngles = base.transform.eulerAngles;
					RivalPhone.gameObject.SetActive(value: true);
					base.gameObject.SetActive(value: false);
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "Wait a few more moments first...";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.enabled = false;
			Prompt.Hide();
		}
	}
}
