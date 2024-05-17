using System;
using UnityEngine;

public class SundayRivalCutsceneScript : MonoBehaviour
{
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	public HomeDarknessScript HomeDarkness;

	public HomeYandereScript HomeYandere;

	public PhoneScript Phone;

	public GameObject NewSundayCutscene;

	public GameObject SmartphoneScreen;

	public GameObject InfoTextConvo;

	public GameObject InfoTextPanel;

	public GameObject SenpaiLight;

	public GameObject GrabbyHand;

	public GameObject HomeClock;

	public Transform YandereParent;

	public Transform Smartphone;

	public Transform RightHand;

	public AudioClip YoureSafeNow;

	public AudioSource Vibration;

	public UISprite SkipCircle;

	public UILabel ShrineLabel;

	public UIPanel SkipPanel;

	public float Alpha = 1f;

	public float Speed;

	public float Timer;

	public float RotX;

	public float RotY;

	public float RotZ;

	public float X;

	public float Y;

	public float Z;

	public int Phase;

	public bool RestoreDOF;

	private void Awake()
	{
		Time.timeScale = 1f;
	}

	private void Start()
	{
		Time.timeScale = 1f;
		if (!GameGlobals.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday && GameGlobals.CorkboardScene)
		{
			Debug.Log("The Sunday Rival Cutscene thinks that it's time to play.");
			NewSundayCutscene.SetActive(value: true);
			HomeSenpaiShrine.Start();
			ShrineLabel.gameObject.SetActive(value: false);
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
			HomeYandere.CharacterAnimation.Play("f02_endOfWeek_00");
			HomeYandere.HomeCamera.Profile.depthOfField.enabled = true;
			HomeYandere.HomeCamera.UpdateDOF(1f);
			SmartphoneScreen.SetActive(value: false);
			SenpaiLight.SetActive(value: true);
			EventGlobals.OsanaConversation = false;
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
			if (Timer > 3f)
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
			if (Timer > 7f)
			{
				if (!Vibration.isPlaying)
				{
					HomeYandere.CharacterAnimation["f02_postOsana_00"].speed = 1.5f;
					HomeYandere.Pajamas.newRenderer.enabled = false;
					SmartphoneScreen.SetActive(value: true);
					Vibration.Play();
				}
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			Timer += Time.deltaTime;
			if (Timer > 3.5f)
			{
				HomeYandere.Pajamas.newRenderer.enabled = true;
			}
			if (HomeYandere.CharacterAnimation["f02_endOfWeek_00"].time >= HomeYandere.CharacterAnimation["f02_endOfWeek_00"].length)
			{
				HomeYandere.CharacterAnimation.CrossFade("f02_endOfWeekIdle_00");
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
