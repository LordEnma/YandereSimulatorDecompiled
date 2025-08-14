using UnityEngine;

public class RefrigeratorScript : MonoBehaviour
{
	public CookingEventScript CookingEvent;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PlatePickUp;

	public PromptScript PlatePrompt;

	public Collider PlateCollider;

	public GameObject[] Octodogs;

	public GameObject Refrigerator;

	public GameObject Octodog;

	public GameObject Sausage;

	public Transform CookingSpot;

	public Transform CookingClub;

	public Transform JarLid;

	public Transform Knife;

	public Transform Jar;

	public UISprite Darkness;

	public bool Cooking;

	public bool Empty;

	public int EventPhase;

	public float Rotation;

	private void Start()
	{
		if (Empty)
		{
			base.enabled = false;
			Prompt.enabled = false;
			Prompt.Hide();
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Yandere.Chased && Yandere.Chasers == 0)
			{
				Knife.GetComponent<WeaponScript>().enabled = false;
				CookingEvent.EventCheck = false;
				Yandere.EmptyHands();
				if (Yandere.YandereVision)
				{
					Yandere.YandereVision = false;
					Yandere.ResetYandereEffects();
				}
				Yandere.CanMove = false;
				Yandere.Cooking = true;
				Cooking = true;
			}
		}
		if (!Cooking)
		{
			return;
		}
		if (EventPhase == 0)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha == 1f)
			{
				for (int i = 1; i < Octodogs.Length; i++)
				{
					Octodogs[i].SetActive(value: true);
				}
				EventPhase++;
			}
		}
		else
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha == 0f)
			{
				Exit();
			}
		}
	}

	private void Exit()
	{
		Knife.GetComponent<WeaponScript>().enabled = true;
		PlateCollider.enabled = true;
		PlatePickUp.enabled = true;
		PlatePrompt.enabled = true;
		Yandere.Cooking = false;
		Yandere.CanMove = true;
		Empty = true;
		Prompt.Hide();
		Prompt.enabled = false;
		base.enabled = false;
	}
}
