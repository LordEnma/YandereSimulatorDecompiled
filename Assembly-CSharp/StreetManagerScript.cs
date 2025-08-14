using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class StreetManagerScript : MonoBehaviour
{
	public StreetShopInterfaceScript StreetShopInterface;

	public SelectiveGrayscale LoveSickEffect1;

	public CameraFilterPack_Film_Grain LoveSickEffect2;

	public CameraFilterPack_TV_Vignetting LoveSickEffect3;

	public PostProcessingProfile Profile;

	public AudioSource CurrentlyActiveJukebox;

	public AudioSource JukeboxNight;

	public AudioSource JukeboxDay;

	public AudioSource Yakuza;

	public Transform BinocularCamera;

	public Transform Yandere;

	public Transform Hips;

	public Transform Sun;

	public Animation EightiesMaidAnimation;

	public Animation MaidAnimation;

	public Animation Gossip1;

	public Animation Gossip2;

	public GameObject[] EightiesObjects;

	public GameObject[] ModernObjects;

	public GameObject InvertedSphere;

	public GameObject MaidPrompt;

	public GameObject MaidLabel;

	public HomeClockScript Clock;

	public Animation[] Civilian;

	public GameObject Couple;

	public UISprite Darkness;

	public Renderer Stars;

	public Light Sunlight;

	public bool Threatened;

	public bool GoToCafe;

	public bool FadeOut;

	public bool Mute;

	public bool Day;

	public float Rotation;

	public float Timer;

	public float DesiredValue;

	public float StarAlpha;

	public float Alpha;

	public GameObject[] RamenShop;

	public AudioClip LoveSickBGM;

	public UILabel[] HUDLabels;

	public AudioClip DayStreet80s;

	public AudioClip NightStreet80s;

	public GameObject EightiesCivilians;

	public GameObject ModernCivilians;

	public GameObject KenchoShip;

	public Renderer Konbini;

	public Texture EightiesKonbini;

	public Font VCR;

	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			LoveSickEffect1.enabled = true;
			LoveSickEffect2.enabled = true;
			LoveSickEffect3.enabled = true;
			JukeboxNight.clip = LoveSickBGM;
			JukeboxNight.Play();
			JukeboxDay.clip = LoveSickBGM;
			JukeboxDay.Play();
		}
		MaidAnimation["f02_faceCouncilGrace_00"].layer = 1;
		MaidAnimation.Play("f02_faceCouncilGrace_00");
		MaidAnimation["f02_faceCouncilGrace_00"].weight = 1f;
		EightiesMaidAnimation["f02_faceCouncilGrace_00"].layer = 1;
		EightiesMaidAnimation.Play("f02_faceCouncilGrace_00");
		EightiesMaidAnimation["f02_faceCouncilGrace_00"].weight = 1f;
		Gossip1["f02_socialSit_00"].layer = 1;
		Gossip1.Play("f02_socialSit_00");
		Gossip1["f02_socialSit_00"].weight = 1f;
		Gossip2["f02_socialSit_00"].layer = 1;
		Gossip2.Play("f02_socialSit_00");
		Gossip2["f02_socialSit_00"].weight = 1f;
		for (int i = 1; i < 6; i++)
		{
			Civilian[i]["f02_smile_00"].layer = 1;
			Civilian[i].Play("f02_smile_00");
			Civilian[i]["f02_smile_00"].weight = 1f;
		}
		Darkness.color = new Color(1f, 1f, 1f, 1f);
		CurrentlyActiveJukebox = JukeboxNight;
		Alpha = 1f;
		Sunlight.shadows = LightShadows.None;
		if (!HomeGlobals.Night)
		{
			Day = true;
			MaidLabel.SetActive(value: false);
			MaidPrompt.SetActive(value: false);
			InvertedSphere.SetActive(value: false);
			Yakuza.transform.parent.gameObject.SetActive(value: false);
			Clock.HourLabel.text = "6:00 AM";
			Sunlight.shadows = LightShadows.Soft;
			if (DateGlobals.Weekday == DayOfWeek.Sunday)
			{
				MaidLabel.SetActive(value: true);
				MaidPrompt.SetActive(value: true);
			}
		}
		if (GameGlobals.Eighties)
		{
			BecomeEighties();
			if (GameGlobals.CustomMode)
			{
				RamenShop[0].SetActive(value: false);
				RamenShop[1].SetActive(value: false);
			}
			GameObject[] modernObjects = ModernObjects;
			foreach (GameObject gameObject in modernObjects)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(value: false);
				}
			}
			modernObjects = EightiesObjects;
			foreach (GameObject gameObject2 in modernObjects)
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(value: true);
				}
			}
		}
		else
		{
			Yakuza.transform.parent.gameObject.SetActive(value: false);
			EightiesCivilians.SetActive(value: false);
			ModernCivilians.SetActive(value: true);
			GameObject[] modernObjects = ModernObjects;
			foreach (GameObject gameObject3 in modernObjects)
			{
				if (gameObject3 != null)
				{
					gameObject3.SetActive(value: true);
				}
			}
			modernObjects = EightiesObjects;
			foreach (GameObject gameObject4 in modernObjects)
			{
				if (gameObject4 != null)
				{
					gameObject4.SetActive(value: false);
				}
			}
		}
		if (GameGlobals.YakuzaPhase > 0)
		{
			Threatened = true;
		}
		Profile.bloom.enabled = !OptionGlobals.DisableBloom;
		Profile.depthOfField.enabled = OptionGlobals.DepthOfField;
		Profile.ambientOcclusion.enabled = !OptionGlobals.DisableObscurance;
		UpdateDOF(2f);
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 0.5f)
		{
			if (Alpha == 1f)
			{
				JukeboxNight.volume = 0.5f;
				JukeboxNight.Play();
				JukeboxDay.volume = 0f;
				JukeboxDay.Play();
			}
			if (!FadeOut)
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
				Darkness.color = new Color(1f, 1f, 1f, Alpha);
			}
			else
			{
				Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime);
				if (!StreetShopInterface.Show && !Mute)
				{
					CurrentlyActiveJukebox.volume = (1f - Alpha) * 0.5f;
				}
				if (GoToCafe)
				{
					Darkness.color = new Color(1f, 1f, 1f, Alpha);
					if (Alpha == 1f)
					{
						SceneManager.LoadScene("MaidMenuScene");
					}
				}
				else
				{
					Darkness.color = new Color(0f, 0f, 0f, Alpha);
					if (Alpha == 1f)
					{
						SceneManager.LoadScene("HomeScene");
					}
				}
			}
		}
		if (!FadeOut && !BinocularCamera.gameObject.activeInHierarchy)
		{
			if (Yandere.position.z > Yakuza.transform.position.z)
			{
				if (Vector3.Distance(Yandere.position, Yakuza.transform.position) > 5f)
				{
					DesiredValue = 0.5f;
				}
				else
				{
					DesiredValue = Vector3.Distance(Yandere.position, Yakuza.transform.position) * 0.1f;
				}
			}
			else
			{
				DesiredValue = 0f;
			}
			if (!StreetShopInterface.Show && !Mute)
			{
				if (Day)
				{
					JukeboxDay.volume = Mathf.Lerp(JukeboxDay.volume, DesiredValue, Time.deltaTime * 10f);
					JukeboxNight.volume = Mathf.Lerp(JukeboxNight.volume, 0f, Time.deltaTime * 10f);
				}
				else
				{
					JukeboxDay.volume = Mathf.Lerp(JukeboxDay.volume, 0f, Time.deltaTime * 10f);
					JukeboxNight.volume = Mathf.Lerp(JukeboxNight.volume, DesiredValue, Time.deltaTime * 10f);
				}
			}
			if (Vector3.Distance(Yandere.position, Yakuza.transform.position) < 0.1f && !Threatened)
			{
				Threatened = true;
				Yakuza.Play();
			}
		}
		if (Input.GetKeyDown("m"))
		{
			Mute = !Mute;
			Debug.Log("Mute is: " + Mute);
			if (Mute)
			{
				JukeboxNight.volume = 0f;
				JukeboxDay.volume = 0f;
				if (StreetShopInterface != null)
				{
					StreetShopInterface.Jukebox.volume = 0f;
				}
			}
			else
			{
				CurrentlyActiveJukebox.Play();
			}
		}
		if (!Mute)
		{
			if (StreetShopInterface.Show)
			{
				JukeboxNight.volume = Mathf.Lerp(JukeboxNight.volume, 0f, Time.deltaTime * 10f);
				JukeboxDay.volume = Mathf.Lerp(JukeboxDay.volume, 0f, Time.deltaTime * 10f);
			}
			else if (Day)
			{
				CurrentlyActiveJukebox = JukeboxDay;
				Rotation = Mathf.Lerp(Rotation, 45f, Time.deltaTime * 10f);
				StarAlpha = Mathf.Lerp(StarAlpha, 0f, Time.deltaTime * 10f);
			}
			else
			{
				CurrentlyActiveJukebox = JukeboxNight;
				Rotation = Mathf.Lerp(Rotation, -45f, Time.deltaTime * 10f);
				StarAlpha = Mathf.Lerp(StarAlpha, 1f, Time.deltaTime * 10f);
			}
		}
		Sun.transform.eulerAngles = new Vector3(Rotation, Rotation, 0f);
		Stars.material.SetColor("_TintColor", new Color(1f, 1f, 1f, StarAlpha));
	}

	private void LateUpdate()
	{
		Hips.LookAt(BinocularCamera.position + new Vector3(0f, -10f, 0f));
	}

	private void BecomeEighties()
	{
		for (int i = 1; i < HUDLabels.Length; i++)
		{
			EightiesifyLabel(HUDLabels[i]);
		}
		HUDLabels[1].transform.parent.localPosition -= new Vector3(25f, 25f, 0f);
		JukeboxDay.clip = DayStreet80s;
		JukeboxNight.clip = NightStreet80s;
		KenchoShip.SetActive(value: false);
		EightiesCivilians.SetActive(value: true);
		ModernCivilians.SetActive(value: false);
		Konbini.material.mainTexture = EightiesKonbini;
	}

	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	public void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
		UpdateAperture(5.6f);
	}

	public void UpdateAperture(float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		float num = (float)Screen.width / 1280f;
		settings.aperture = Aperture * num;
		settings.focalLength = 50f;
		Profile.depthOfField.settings = settings;
	}
}
