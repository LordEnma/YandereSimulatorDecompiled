using System;
using UnityEngine;

public class SundayRivalCutsceneScript : MonoBehaviour
{
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	public HomeDarknessScript HomeDarkness;

	public HomeYandereScript HomeYandere;

	public PhoneScript Phone;

	public GameObject SmartphoneScreen;

	public GameObject InfoTextConvo;

	public GameObject InfoTextPanel;

	public GameObject SenpaiLight;

	public GameObject GrabbyHand;

	public GameObject HomeClock;

	public AudioClip YoureSafeNow;

	public AudioSource Vibration;

	public Transform Smartphone;

	public Transform RightHand;

	public UISprite SkipCircle;

	public UIPanel SkipPanel;

	public float Alpha = 1f;

	public float Speed;

	public float Timer;

	public float X;

	public float Y;

	public float Z;

	public int Phase;

	public bool RestoreDOF;

	private void Start()
	{
		if (!GameGlobals.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday && GameGlobals.CorkboardScene)
		{
			Debug.Log("The Sunday Rival Cutscene thinks that it's time to play.");
			HomeSenpaiShrine.Start();
			HomeYandere.HomeDarkness.color = new Color(0f, 0f, 0f, 1f);
			HomeDarkness.enabled = false;
			Alpha = 1f;
			InfoTextConvo.gameObject.SetActive(value: true);
			Vibration.gameObject.SetActive(value: true);
			HomeYandere.Start();
			HomeYandere.HomeCamera.Start();
			HomeClock.SetActive(value: false);
			HomeYandere.enabled = false;
			HomeYandere.HomeCamera.enabled = false;
			HomeYandere.HomeCamera.RoomJukebox.enabled = false;
			HomeYandere.HomeCamera.HomeSenpaiShrine.enabled = false;
			UnityEngine.Object.Destroy(HomeYandere.HomeCamera.PauseScreen.gameObject);
			HomeYandere.HomeCamera.HomeSenpaiShrine.RightDoor.localEulerAngles = new Vector3(HomeYandere.HomeCamera.HomeSenpaiShrine.RightDoor.localEulerAngles.x, 135f, HomeYandere.HomeCamera.HomeSenpaiShrine.RightDoor.localEulerAngles.z);
			HomeYandere.HomeCamera.HomeSenpaiShrine.LeftDoor.localEulerAngles = new Vector3(HomeYandere.HomeCamera.HomeSenpaiShrine.LeftDoor.localEulerAngles.x, -135f, HomeYandere.HomeCamera.HomeSenpaiShrine.LeftDoor.localEulerAngles.z);
			HomeYandere.transform.position = new Vector3(-1.65636f, 0f, 2.01636f);
			HomeYandere.transform.eulerAngles = new Vector3(0f, -45f, 0f);
			HomeYandere.HomeCamera.transform.position = new Vector3(-1.82f, 1.25f, 1f);
			HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			if (HomeYandere.HomeCamera.Profile.depthOfField.enabled)
			{
				RestoreDOF = true;
			}
			HomeYandere.HomeCamera.Profile.depthOfField.enabled = false;
			HomeYandere.CharacterAnimation["f02_postOsana_00"].speed = 1.5f;
			HomeYandere.CharacterAnimation.Play("f02_postOsana_00");
			HomeYandere.HomeCamera.Profile.depthOfField.enabled = true;
			HomeYandere.HomeCamera.UpdateDOF(1f);
			SmartphoneScreen.SetActive(value: false);
			SenpaiLight.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (SkipCircle.transform.parent.gameObject.activeInHierarchy)
		{
			if (Input.GetButton(InputNames.Xbox_X))
			{
				SkipCircle.fillAmount -= Time.deltaTime;
				if (SkipCircle.fillAmount == 0f)
				{
					HomeYandere.HomeDarkness.color = new Color(0f, 0f, 0f, 0f);
					SkipCircle.transform.parent.gameObject.SetActive(value: false);
					Phase = 5;
					Timer = 0f;
				}
			}
			else
			{
				SkipCircle.fillAmount = 1f;
			}
		}
		if (Phase < 5)
		{
			HomeYandere.HomeCamera.transform.Translate(Vector3.forward * Time.deltaTime * 0.01f, Space.Self);
		}
		if (Phase == 0)
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.25f);
			HomeYandere.HomeDarkness.color = new Color(0f, 0f, 0f, Alpha);
			if (Alpha == 0f)
			{
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			Timer += Time.deltaTime;
			if (Timer > 2.5f)
			{
				HomeYandere.CharacterAnimation["f02_postOsana_00"].speed = 0.8f;
				Vibration.PlayOneShot(YoureSafeNow);
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			Timer += Time.deltaTime;
			if (Timer > 3f && !Vibration.isPlaying)
			{
				HomeYandere.CharacterAnimation["f02_postOsana_00"].speed = 1.5f;
				SmartphoneScreen.SetActive(value: true);
				Vibration.Play();
			}
			if (Timer > 4f)
			{
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			Timer += Time.deltaTime;
			Speed += Time.deltaTime;
			if (Timer > 3.66666f)
			{
				Smartphone.parent = RightHand;
				Smartphone.transform.localPosition = new Vector3(0.025f, 0.0075f, 0.05f);
				Smartphone.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
			}
			if (HomeYandere.CharacterAnimation["f02_postOsana_00"].time >= HomeYandere.CharacterAnimation["f02_postOsana_00"].length)
			{
				HomeYandere.CharacterAnimation.CrossFade("f02_postOsanaLoop_00", 1f);
				InfoTextConvo.SetActive(value: true);
				Timer = 0f;
				Phase++;
			}
		}
		else
		{
			if (Phase != 5)
			{
				return;
			}
			HomeYandere.HomeCamera.UpdateDOF(0f);
			Timer += Time.deltaTime;
			InfoTextPanel.transform.localPosition = Vector3.Lerp(InfoTextPanel.transform.localPosition, new Vector3(0f, 0f, 1f), Time.deltaTime * 10f);
			if (Timer > 1f)
			{
				SkipPanel.alpha = 0f;
				if (RestoreDOF)
				{
					HomeYandere.HomeCamera.Profile.depthOfField.enabled = true;
				}
				Phone.enabled = true;
				Time.timeScale = 1f;
				Phase++;
			}
		}
	}
}
