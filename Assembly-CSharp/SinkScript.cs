using UnityEngine;

public class SinkScript : MonoBehaviour
{
	public ParticleSystem WaterStream;

	public Transform WashPosition;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public bool WashingDisabled;

	private void Start()
	{
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		if (GameGlobals.EightiesTutorial)
		{
			WashingDisabled = true;
		}
	}

	private void Update()
	{
		if (Yandere.PickUp != null)
		{
			Prompt.HideButton[0] = false;
			Prompt.HideButton[1] = true;
			if (Yandere.PickUp.Bucket != null)
			{
				if (Yandere.PickUp.Bucket.Dumbbells == 0)
				{
					Prompt.enabled = true;
					if (!Yandere.PickUp.Bucket.Full)
					{
						Prompt.Label[0].text = "     Fill Bucket";
					}
					else
					{
						Prompt.Label[0].text = "     Empty Bucket";
					}
				}
				else if (Prompt.enabled)
				{
					Prompt.Hide();
					Prompt.enabled = false;
				}
			}
			else if (Yandere.PickUp.BloodCleaner != null)
			{
				if (Yandere.PickUp.BloodCleaner.Blood > 0f)
				{
					Prompt.Label[0].text = "     Empty Robot";
					Prompt.enabled = true;
				}
				else
				{
					Prompt.Hide();
					Prompt.enabled = false;
				}
			}
			else if (Prompt.enabled)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		else if (!WashingDisabled && Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.Blood.enabled)
		{
			if (Prompt.HideButton[1])
			{
				Prompt.Label[1].text = "     Wash Weapon";
				Prompt.HideButton[0] = true;
				Prompt.HideButton[1] = false;
				Prompt.enabled = true;
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
			Prompt.HideButton[1] = true;
			if (Prompt.enabled)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (Yandere.PickUp.Bucket != null)
			{
				if (!Yandere.PickUp.Bucket.Full)
				{
					Yandere.PickUp.Bucket.Fill();
				}
				else
				{
					Yandere.PickUp.Bucket.Empty();
				}
				if (!Yandere.PickUp.Bucket.Full)
				{
					Prompt.Label[0].text = "     Fill Bucket";
				}
				else
				{
					Prompt.Label[0].text = "     Empty Bucket";
				}
			}
			else if (Yandere.PickUp.BloodCleaner != null)
			{
				Yandere.PickUp.BloodCleaner.Blood = 0f;
				Yandere.PickUp.BloodCleaner.Lens.SetActive(value: false);
			}
			Prompt.Circle[0].fillAmount = 1f;
		}
		if (Prompt.Circle[1].fillAmount == 0f)
		{
			Prompt.Circle[1].fillAmount = 1f;
			Prompt.Yandere.CharacterAnimation.CrossFade("f02_cleaningWeapon_00");
			Prompt.Yandere.Target = WashPosition;
			Prompt.Yandere.CleaningWeapon = true;
			Prompt.Yandere.CanMove = false;
			WaterStream.Play();
		}
	}
}
