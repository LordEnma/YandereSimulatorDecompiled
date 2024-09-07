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
			}
		}
		if (!Yandere.Cooking)
		{
			return;
		}
		Quaternion b = Quaternion.LookRotation(new Vector3(Octodogs[1].transform.position.x, Yandere.transform.position.y, Octodogs[1].transform.position.z) - Yandere.transform.position);
		Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, b, Time.deltaTime * 10f);
		Yandere.MoveTowardsTarget(CookingSpot.position);
		if (EventPhase == 0)
		{
			Yandere.CharacterAnimation.Play("f02_prepareFood_00");
			Octodog.transform.parent = Yandere.RightHand;
			Octodog.transform.localPosition = new Vector3(0.0129f, -0.02475f, 0.0316f);
			Octodog.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			Sausage.transform.parent = Yandere.RightHand;
			Sausage.transform.localPosition = new Vector3(0.013f, -0.038f, 0.015f);
			Sausage.transform.localEulerAngles = Vector3.zero;
			Octodog.SetActive(value: false);
			Sausage.SetActive(value: false);
			EventPhase++;
		}
		else if (EventPhase == 1)
		{
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time > 1f)
			{
				EventPhase++;
			}
		}
		else if (EventPhase == 2)
		{
			Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time > 3f)
			{
				Jar.parent = Yandere.RightHand;
				Jar.localPosition = new Vector3(0f, -1f / 30f, -0.14f);
				Jar.localEulerAngles = new Vector3(90f, 0f, 0f);
				EventPhase++;
			}
		}
		else if (EventPhase == 3)
		{
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time > 5f)
			{
				JarLid.transform.parent = Yandere.LeftHand;
				JarLid.localPosition = new Vector3(1f / 30f, 0f, 0f);
				JarLid.localEulerAngles = Vector3.zero;
				EventPhase++;
			}
		}
		else if (EventPhase == 4)
		{
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time > 6f)
			{
				JarLid.parent = CookingClub;
				JarLid.localPosition = new Vector3(0.334585f, 1f, -0.2528915f);
				JarLid.localEulerAngles = new Vector3(0f, 30f, 0f);
				Jar.parent = CookingClub;
				Jar.localPosition = new Vector3(0.29559f, 1f, 0.2029152f);
				Jar.localEulerAngles = new Vector3(0f, -150f, 0f);
				EventPhase++;
			}
		}
		else if (EventPhase == 5)
		{
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time > 7f)
			{
				Knife.GetComponent<WeaponScript>().FingerprintID = 100;
				Knife.parent = Yandere.LeftHand;
				Knife.localPosition = new Vector3(0f, -0.01f, 0f);
				Knife.localEulerAngles = new Vector3(0f, 0f, -90f);
				EventPhase++;
			}
		}
		else if (EventPhase == 6)
		{
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time >= Yandere.CharacterAnimation["f02_prepareFood_00"].length)
			{
				Yandere.CharacterAnimation.CrossFade("f02_cutFood_00");
				Sausage.SetActive(value: true);
				EventPhase++;
			}
		}
		else if (EventPhase == 7)
		{
			if (Yandere.CharacterAnimation["f02_cutFood_00"].time > 2.66666f)
			{
				Octodog.SetActive(value: true);
				Sausage.SetActive(value: false);
				EventPhase++;
			}
		}
		else if (EventPhase == 8)
		{
			if (Yandere.CharacterAnimation["f02_cutFood_00"].time > 3f)
			{
				Rotation = Mathf.MoveTowards(Rotation, 90f, Time.deltaTime * 360f);
				Octodog.transform.localEulerAngles = new Vector3(Rotation, Octodog.transform.localEulerAngles.y, Octodog.transform.localEulerAngles.z);
				Octodog.transform.localPosition = new Vector3(Octodog.transform.localPosition.x, Octodog.transform.localPosition.y, Mathf.MoveTowards(Octodog.transform.localPosition.z, 0.012f, Time.deltaTime));
			}
			if (Yandere.CharacterAnimation["f02_cutFood_00"].time > 6f)
			{
				Octodog.SetActive(value: false);
				for (int i = 1; i < Octodogs.Length; i++)
				{
					Octodogs[i].SetActive(value: true);
				}
				EventPhase++;
			}
		}
		else if (EventPhase == 9)
		{
			if (Yandere.CharacterAnimation["f02_cutFood_00"].time >= Yandere.CharacterAnimation["f02_cutFood_00"].length)
			{
				Yandere.CharacterAnimation.Play("f02_prepareFood_00");
				Yandere.CharacterAnimation["f02_prepareFood_00"].time = Yandere.CharacterAnimation["f02_prepareFood_00"].length;
				Yandere.CharacterAnimation["f02_prepareFood_00"].speed = -1f;
				EventPhase++;
			}
		}
		else if (EventPhase == 10)
		{
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time < Yandere.CharacterAnimation["f02_prepareFood_00"].length - 1f)
			{
				Knife.parent = CookingClub;
				Knife.localPosition = new Vector3(0.197f, 1.1903f, -1f / 3f);
				Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
				EventPhase++;
			}
		}
		else if (EventPhase == 11)
		{
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time < Yandere.CharacterAnimation["f02_prepareFood_00"].length - 2f)
			{
				JarLid.parent = Yandere.LeftHand;
				JarLid.localPosition = new Vector3(1f / 30f, 0f, 0f);
				JarLid.localEulerAngles = Vector3.zero;
				Jar.parent = Yandere.RightHand;
				Jar.localPosition = new Vector3(0f, -1f / 30f, -0.14f);
				Jar.localEulerAngles = new Vector3(90f, 0f, 0f);
				EventPhase++;
			}
		}
		else if (EventPhase == 12)
		{
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time < Yandere.CharacterAnimation["f02_prepareFood_00"].length - 3f)
			{
				JarLid.parent = Jar;
				JarLid.localPosition = new Vector3(0f, 0.175f, 0f);
				JarLid.localEulerAngles = Vector3.zero;
				Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
				Refrigerator.GetComponent<Animation>()["FridgeOpen"].time = Refrigerator.GetComponent<Animation>()["FridgeOpen"].length;
				Refrigerator.GetComponent<Animation>()["FridgeOpen"].speed = -1f;
				EventPhase++;
			}
		}
		else if (EventPhase == 13)
		{
			if (Yandere.CharacterAnimation["f02_prepareFood_00"].time < Yandere.CharacterAnimation["f02_prepareFood_00"].length - 5f)
			{
				Jar.parent = CookingClub;
				Jar.localPosition = new Vector3(0.1f, 0.941f, 0.75f);
				Jar.localEulerAngles = new Vector3(0f, 90f, 0f);
				EventPhase++;
			}
		}
		else if (EventPhase == 14 && Yandere.CharacterAnimation["f02_prepareFood_00"].time <= 0f)
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
}
