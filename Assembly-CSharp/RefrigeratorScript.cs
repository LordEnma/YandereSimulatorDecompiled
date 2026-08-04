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

	public GameObject CookingMontageObjects;

	public GameObject ChoppingBlock;

	public GameObject Refrigerator;

	public GameObject Octodog;

	public GameObject Sausage;

	public Animation CookingCameraAnim;

	public Animation CookingPropsAnim;

	public Transform CameraParent;

	public Transform CookingSpot;

	public Transform CookingClub;

	public Transform JarLid;

	public Transform Knife;

	public Transform Jar;

	public AudioSource BGM;

	public AudioSource SFX;

	public UISprite Darkness;

	public UIPanel SkipPanel;

	public bool Cooking;

	public bool Empty;

	public int EventPhase;

	public float OriginalVolume;

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
				Yandere.CharacterAnimation.Play(Yandere.IdleAnim);
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
				OriginalVolume = Yandere.Jukebox.Volume;
				Yandere.Jukebox.Volume = 0f;
				Darkness.color = new Color(1f, 1f, 1f, 0f);
				BGM.Play();
				SFX.Play();
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
			Yandere.HUDSprite.alpha = 1f - Darkness.alpha;
			if (Darkness.alpha == 1f)
			{
				CookingMontageObjects.SetActive(value: true);
				Yandere.transform.position = new Vector3(0f, 100f, 0f);
				Yandere.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				Yandere.CharacterAnimation.Play("f02_cookingMontage_00");
				Yandere.MyController.enabled = false;
				Yandere.RPGCamera.enabled = false;
				Yandere.MainCamera.fieldOfView = 45f;
				Yandere.CameraEffects.UpdateDOF(1f);
				EventPhase++;
			}
		}
		else if (EventPhase == 1)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 2f);
			if (Yandere.CharacterAnimation["f02_cookingMontage_00"].time >= 4.5f)
			{
				ChoppingBlock.SetActive(value: false);
			}
			else if (Yandere.CharacterAnimation["f02_cookingMontage_00"].time >= Yandere.CharacterAnimation["f02_cookingMontage_00"].length * 0.212f)
			{
				ChoppingBlock.SetActive(value: true);
			}
			if (Yandere.CharacterAnimation["f02_cookingMontage_00"].time >= 8f)
			{
				Yandere.CameraEffects.UpdateDOF(0.5f);
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					EventPhase = 3;
				}
				SkipPanel.alpha = 0f;
			}
			else
			{
				SkipPanel.alpha = Mathf.MoveTowards(SkipPanel.alpha, 1f, Time.deltaTime * 2f);
			}
			if (Yandere.CharacterAnimation["f02_cookingMontage_00"].time >= Yandere.CharacterAnimation["f02_cookingMontage_00"].length)
			{
				Yandere.CharacterAnimation.Play("f02_cookingMontageLoop_00");
				SkipPanel.alpha = 0f;
				EventPhase++;
			}
			if (SkipPanel.alpha > 0.999f && Input.GetButtonDown(InputNames.Xbox_X))
			{
				Yandere.CharacterAnimation["f02_cookingMontage_00"].time = 8f;
				CookingCameraAnim["obj_CameraCookingMontage"].time = 8f;
				CookingPropsAnim["obj_PropsCookingMontage"].time = 8f;
				ChoppingBlock.SetActive(value: false);
				SkipPanel.alpha = 0f;
				EventPhase++;
			}
		}
		else if (EventPhase == 2)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				EventPhase++;
			}
		}
		else if (EventPhase == 3)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha == 1f)
			{
				CookingMontageObjects.SetActive(value: false);
				Yandere.transform.position = new Vector3(-10.66633f, 0f, 28.379f);
				Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				Yandere.CharacterAnimation.Play(Yandere.IdleAnim);
				Yandere.MyController.enabled = true;
				Yandere.RPGCamera.enabled = true;
				for (int i = 1; i < Octodogs.Length; i++)
				{
					Octodogs[i].SetActive(value: true);
				}
				Yandere.MainCamera.fieldOfView = 60f;
				Yandere.CameraEffects.UpdateDOF(2f);
				Yandere.Jukebox.Volume = OriginalVolume;
				EventPhase++;
			}
		}
		else
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			Yandere.HUDSprite.alpha = 1f - Darkness.alpha;
			if (Darkness.alpha == 0f)
			{
				Exit();
			}
		}
	}

	private void LateUpdate()
	{
		if (EventPhase > 0 && EventPhase < 4)
		{
			Yandere.MainCamera.transform.position = CameraParent.transform.position;
			Yandere.MainCamera.transform.eulerAngles = CameraParent.transform.eulerAngles;
			if (EventPhase == 3)
			{
				Yandere.CameraEffects.UpdateDOF(0.5f);
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
		Darkness.color = new Color(0f, 0f, 0f, 0f);
		base.enabled = false;
	}
}
