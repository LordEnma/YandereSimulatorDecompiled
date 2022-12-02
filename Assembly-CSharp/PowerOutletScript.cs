using UnityEngine;

public class PowerOutletScript : MonoBehaviour
{
	public PromptScript Prompt;

	public PowerSwitchScript PowerSwitch;

	public GameObject PowerStrip;

	public GameObject PluggedOutlet;

	public GameObject SabotagedOutlet;

	public bool Sabotaged;

	private void Update()
	{
		if (PowerStrip == null)
		{
			if (Prompt.Yandere.PickUp != null)
			{
				if (Prompt.Yandere.PickUp.Electronic)
				{
					Prompt.HideButton[0] = false;
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					PowerStrip = Prompt.Yandere.PickUp.gameObject;
					Prompt.Yandere.EmptyHands();
					PowerStrip.transform.parent = base.transform;
					PowerStrip.transform.localPosition = new Vector3(0f, 0f, 0f);
					PowerStrip.SetActive(false);
					PluggedOutlet.SetActive(true);
					Prompt.Label[0].text = "     Unplug";
				}
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
			return;
		}
		if (Prompt.Yandere.EquippedWeapon != null)
		{
			if (Prompt.Yandere.EquippedWeapon.WeaponID == 6)
			{
				Prompt.HideButton[1] = false;
			}
			else
			{
				Prompt.HideButton[1] = true;
			}
		}
		else
		{
			Prompt.HideButton[1] = true;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			PluggedOutlet.SetActive(false);
			PowerStrip.transform.localPosition = new Vector3(0.074f, -0.01385f, 0.0295f);
			PowerStrip.transform.localEulerAngles = new Vector3(0f, -99f, 0f);
			PowerStrip.SetActive(true);
			PowerStrip = null;
			Prompt.HideButton[1] = true;
			Prompt.Label[0].text = "     Plug In";
		}
		if (Prompt.Circle[1].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[1].fillAmount = 1f;
		if (PowerSwitch.On)
		{
			Prompt.Yandere.NotificationManager.CustomText = "Turn Lightswitch Off First!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		if (!Sabotaged)
		{
			Prompt.Yandere.SuspiciousActionTimer = 1f;
			SabotagedOutlet.SetActive(true);
			PluggedOutlet.SetActive(false);
			Prompt.Label[1].text = "     Repair";
			Prompt.HideButton[0] = true;
		}
		else
		{
			SabotagedOutlet.SetActive(false);
			PluggedOutlet.SetActive(true);
			Prompt.Label[1].text = "     Sabotage";
			Prompt.HideButton[0] = false;
		}
		Sabotaged = !Sabotaged;
		Debug.Log("''Sabotaged'' is now: " + Sabotaged);
	}
}
