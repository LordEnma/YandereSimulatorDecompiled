using UnityEngine;

public class MatchboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PickUp;

	public GameObject Match;

	public AudioSource MyAudio;

	public bool LabelUpdated;

	public bool Throwing;

	public string ProjectileNames;

	public string ProjectileName;

	public int Ammo;

	private void Start()
	{
		Prompt.Button[0].gameObject.GetComponent<PromptSwapScript>().DisableButton = true;
		Prompt.Button[0].gameObject.GetComponent<PromptSwapScript>().UpdateSpriteType(InputDeviceType.Gamepad);
		UpdateLabel();
	}

	private void Update()
	{
		if (Prompt.PauseScreen.Show)
		{
			return;
		}
		if (Prompt.Yandere.PickUp == PickUp)
		{
			if (Prompt.HideButton[0])
			{
				Prompt.HideButton[0] = false;
				Prompt.HideButton[3] = true;
			}
			if (Prompt.Yandere.PreparingThrow && !LabelUpdated)
			{
				if (Prompt.Yandere.InputDevice.Type == InputDeviceType.MouseAndKeyboard)
				{
					Prompt.Text[0] = "Click LMB to Throw";
					Prompt.Label[0].text = "     " + Prompt.Text[0];
				}
				else
				{
					Prompt.Text[0] = "Pull RT to Throw";
					Prompt.Label[0].text = "     " + Prompt.Text[0];
				}
				LabelUpdated = true;
			}
			if (Input.GetAxis("RT") > 0.5f || Input.GetMouseButtonDown(0))
			{
				Debug.Log("User clicked.");
				if ((Prompt.Yandere.PreparingThrow && !Throwing) || (Prompt.Yandere.Throwing && !Throwing))
				{
					Throwing = true;
					MyAudio.Play();
					GameObject obj = Object.Instantiate(Match, Prompt.Yandere.ItemParent.position, Prompt.Yandere.transform.rotation);
					obj.GetComponent<MatchScript>().GravityFactor = Prompt.Yandere.NewArc.GravityFactor;
					Rigidbody component = obj.GetComponent<Rigidbody>();
					component.isKinematic = false;
					component.AddRelativeForce(Vector3.forward * Prompt.Yandere.NewArc.ForwardMomentum, ForceMode.VelocityChange);
					Prompt.Yandere.SuspiciousActionTimer = 1f;
					Ammo--;
					if (Ammo < 1)
					{
						Prompt.Yandere.OutOfAmmo = true;
						Prompt.Yandere.Arc.SetActive(value: false);
						Prompt.Yandere.PickUp.Drop();
						Prompt.Yandere.NotificationManager.CustomText = "Out of " + ProjectileNames + "!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						Object.Destroy(base.gameObject);
					}
					else
					{
						if (Ammo == 1)
						{
							Prompt.Yandere.NotificationManager.CustomText = Ammo + " " + ProjectileName + " left!";
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = Ammo + " " + ProjectileNames + " left!";
						}
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
			}
		}
		else if (Prompt.Yandere.Arc.activeInHierarchy && !Prompt.HideButton[0])
		{
			Prompt.Yandere.Arc.SetActive(value: false);
			Prompt.HideButton[0] = true;
			Prompt.HideButton[3] = false;
		}
		if (Throwing && !Prompt.Yandere.Throwing)
		{
			Throwing = false;
		}
		if (!Prompt.Yandere.PreparingThrow && LabelUpdated)
		{
			Debug.Log("Ran this code.");
			UpdateLabel();
			LabelUpdated = false;
		}
	}

	public void UpdateLabel()
	{
		if (Prompt.Yandere.InputDevice.Type == InputDeviceType.MouseAndKeyboard)
		{
			Prompt.Text[0] = "Hold RMB to Aim";
			Prompt.Label[0].text = "     " + Prompt.Text[0];
		}
		else
		{
			Prompt.Text[0] = "Hold LT to Aim";
			Prompt.Label[0].text = "     " + Prompt.Text[0];
		}
	}
}
