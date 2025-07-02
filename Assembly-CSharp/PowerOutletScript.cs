using UnityEngine;

public class PowerOutletScript : MonoBehaviour
{
	public PromptScript Prompt;

	public PowerSwitchScript PowerSwitch;

	public GameObject PowerStripGameObject;

	public GameObject PowerStrip;

	public GameObject PluggedOutlet;

	public GameObject SabotagedOutlet;

	public bool PluggedIn;

	public bool Sabotaged;

	private void Update()
	{
		if (!Prompt.InView)
		{
			return;
		}
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
					PlugIn();
				}
			}
			else if (!Prompt.HideButton[0])
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
			Unplug();
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
			Sabotage();
		}
		else
		{
			SabotagedOutlet.SetActive(value: false);
			PluggedOutlet.SetActive(value: true);
			Prompt.Label[1].text = "     Sabotage";
			Prompt.HideButton[0] = false;
		}
		Sabotaged = !Sabotaged;
		Debug.Log("''Sabotaged'' is now: " + Sabotaged);
	}

	public void PlugIn()
	{
		Prompt.Circle[0].fillAmount = 1f;
		PowerStrip = PowerStripGameObject;
		Prompt.Yandere.EmptyHands();
		PowerStrip.transform.parent = base.transform;
		PowerStrip.transform.localPosition = new Vector3(0f, 0f, 0f);
		PowerStrip.SetActive(value: false);
		PluggedOutlet.SetActive(value: true);
		Prompt.Label[0].text = "     Unplug";
		PluggedIn = true;
	}

	public void Unplug()
	{
		Prompt.Circle[0].fillAmount = 1f;
		PluggedOutlet.SetActive(value: false);
		PowerStrip.transform.localPosition = new Vector3(0.074f, -0.01385f, 0.0295f);
		PowerStrip.transform.localEulerAngles = new Vector3(0f, -99f, 0f);
		PowerStrip.SetActive(value: true);
		PowerStrip = null;
		Prompt.HideButton[1] = true;
		Prompt.Label[0].text = "     Plug In";
		PluggedIn = false;
	}

	public void Sabotage()
	{
		Prompt.Yandere.SuspiciousActionTimer = 1f;
		SabotagedOutlet.SetActive(value: true);
		PluggedOutlet.SetActive(value: false);
		Prompt.Label[1].text = "     Repair";
		Prompt.HideButton[0] = true;
	}

	public void RestoreState()
	{
		if (PluggedIn)
		{
			PlugIn();
			if (Sabotaged)
			{
				Sabotage();
			}
		}
	}
}
