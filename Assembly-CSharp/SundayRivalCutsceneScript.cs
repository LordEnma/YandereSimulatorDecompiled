using System;
using UnityEngine;

public class SundayRivalCutsceneScript : MonoBehaviour
{
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	public HomeDarknessScript HomeDarkness;

	public HomeYandereScript HomeYandere;

	public PhoneScript Phone;

	public GameObject InfoTextConvo;

	public GameObject InfoTextPanel;

	public AudioClip YoureSafeNow;

	public AudioSource Vibration;

	public GameObject GrabbyHand;

	public GameObject HomeClock;

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
			HomeYandere.transform.position = new Vector3(-1.655f, 0f, 1.93f);
			HomeYandere.transform.eulerAngles = new Vector3(0f, -45f, 0f);
			HomeYandere.HomeCamera.transform.position = new Vector3(-1.905f, 1.48f, 2.15f);
			HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(0f, -22.5f, 0f);
			if (HomeYandere.HomeCamera.Profile.depthOfField.enabled)
			{
				RestoreDOF = true;
			}
			HomeYandere.HomeCamera.Profile.depthOfField.enabled = false;
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
			if (Input.GetButton("X"))
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
		if (Phase < 4)
		{
			HomeYandere.HomeCamera.transform.Translate(Vector3.forward * Time.deltaTime * -0.01f, Space.Self);
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
				HomeYandere.Character.GetComponent<Animation>().Play("f02_caressPhoto_00");
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			Timer += Time.deltaTime;
			if (Timer > 2.5f)
			{
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
				Vibration.Play();
			}
			if (Timer > 4f)
			{
				X = 0f;
				Y = -22.5f;
				Z = 0f;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			Timer += Time.deltaTime;
			Speed += Time.deltaTime;
			HomeYandere.HomeCamera.transform.position = Vector3.Lerp(HomeYandere.HomeCamera.transform.position, new Vector3(-2.055f, 1.075f, 1.99f), Time.deltaTime * Speed);
			X = Mathf.Lerp(X, 67.5f, Time.deltaTime * Speed);
			Y = Mathf.Lerp(Y, -22.5f, Time.deltaTime * Speed);
			Z = Mathf.Lerp(Z, 0f, Time.deltaTime * Speed);
			HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(X, Y, Z);
			if (Timer > 2f)
			{
				HomeYandere.gameObject.SetActive(value: false);
			}
			if (Timer > 2.5f)
			{
				GrabbyHand.SetActive(value: true);
			}
			if (Timer > 4.5f)
			{
				HomeYandere.HomeCamera.transform.position = new Vector3(-1.638197f, 1.4925f, 2f);
				HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(0f, -45f, 0f);
				HomeYandere.gameObject.SetActive(value: false);
				GrabbyHand.SetActive(value: false);
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
