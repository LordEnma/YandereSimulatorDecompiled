using UnityEngine;

public class DrinkingFountainScript : MonoBehaviour
{
	public PowerSwitchScript PowerSwitch;

	public ParticleSystem WaterStream;

	public ParticleSystem WaterBlast;

	public Transform DrinkPosition;

	public GameObject WaterCollider;

	public GameObject Puddle;

	public GameObject Leak;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public bool Sabotagable;

	public bool Sabotaged;

	public bool Occupied;

	public string CleanAnim = "f02_cleaningWeapon_00";

	private void Start()
	{
		if (GameGlobals.EightiesTutorial)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Yandere.EquippedWeapon != null)
		{
			if (Prompt.Yandere.EquippedWeapon.Blood.enabled)
			{
				Prompt.HideButton[0] = false;
				Prompt.enabled = true;
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
			if (!Leak.activeInHierarchy)
			{
				if (Prompt.Yandere.EquippedWeapon.WeaponID == 24)
				{
					Prompt.HideButton[1] = false;
					if (Sabotagable && !Sabotaged)
					{
						Prompt.HideButton[2] = false;
					}
					else
					{
						Prompt.HideButton[2] = true;
					}
					Prompt.enabled = true;
				}
				else
				{
					Prompt.HideButton[1] = true;
					Prompt.HideButton[2] = true;
				}
			}
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Prompt.Yandere.YandereVision)
				{
					Prompt.Yandere.YandereVision = false;
					Prompt.Yandere.ResetYandereEffects();
				}
				Prompt.Yandere.CleanAnim = CleanAnim;
				Prompt.Yandere.CharacterAnimation.CrossFade(Prompt.Yandere.CleanAnim);
				Prompt.Yandere.Target = DrinkPosition;
				Prompt.Yandere.CleaningWeapon = true;
				Prompt.Yandere.CanMove = false;
				WaterStream.Play();
			}
			if (Prompt.Circle[1].fillAmount == 0f)
			{
				Prompt.HideButton[1] = true;
				Puddle.SetActive(value: true);
				Leak.SetActive(value: true);
				MyAudio.Play();
				PowerSwitch.CheckPuddle();
			}
			if (Prompt.Circle[2].fillAmount == 0f)
			{
				Prompt.HideButton[2] = true;
				Sabotaged = true;
				MyAudio.Play();
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}
}
