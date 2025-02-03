using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class KokonaTutorialIntroScript : MonoBehaviour
{
	public InputDeviceScript InputDevice;

	public AudioSource MyAudioSource;

	public AudioSource Jukebox;

	public AudioClip KokonaIntro;

	public AudioClip KokonaYes;

	public AudioClip KokonaNo;

	public AudioClip DoorOpen;

	public AudioClip AyanoYes;

	public AudioClip AyanoNo;

	public AudioClip DeclineClip;

	public AudioClip AcceptClip;

	public AudioClip WaitLoop;

	public Animation KokonaAnim;

	public Animation AyanoAnim;

	public UISprite SkipCircle;

	public Transform AyanoHead;

	public Transform Kokona;

	public Transform Senpai;

	public Transform Window;

	public Transform Door;

	public Camera MainCamera;

	public UISprite Darkness;

	public UIPanel SkipPanel;

	public float SkipTimer;

	public float Speed;

	public float Timer;

	public int Phase;

	public UILabel Subtitle;

	public string[] SpeechLines;

	public float[] SpeechTimes;

	public float SpeechTimer;

	public int SpeechID;

	public int DebugID;

	public bool Debug;

	public PostProcessingProfile Profile;

	public GameObject[] VtuberHairs;

	public GameObject[] VtuberAccs;

	public GameObject YandereHair;

	private void Start()
	{
		MainCamera.transform.position = new Vector3(0.1f, 1f, 18.1f);
		KokonaAnim["Tutorial_Kokona_Intro"].speed = 0f;
		AyanoAnim["Tutorial_Ayano_Intro"].speed = 0f;
		Window.localScale = new Vector3(0f, 0f, 0f);
		GameGlobals.Eighties = false;
		SkipPanel.alpha = 0f;
		Darkness.alpha = 1f;
		Subtitle.text = "";
		VtuberCheck();
	}

	private void Update()
	{
		Senpai.Translate(Senpai.right * Time.deltaTime);
		if ((Phase > 1 && Phase < 5) || Phase > 5)
		{
			SpeechTimer += Time.deltaTime;
		}
		if (SpeechTimer > SpeechTimes[SpeechID])
		{
			SpeechID++;
			Subtitle.text = SpeechLines[SpeechID];
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			DebugID++;
			if (DebugID > 9)
			{
				Debug = true;
			}
		}
		if (Phase == 0)
		{
			Timer = Mathf.MoveTowards(Timer, 1f, Time.deltaTime);
			SkipPanel.alpha = Timer;
			if (Timer == 1f || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				Jukebox.Play();
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.33333f);
			if (Darkness.alpha == 0f || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				Darkness.alpha = 0f;
				Timer += Time.deltaTime;
				if (Timer > 1f || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
				{
					KokonaAnim["Tutorial_Kokona_Intro"].speed = 1f;
					AyanoAnim["Tutorial_Ayano_Intro"].speed = 1f;
					AyanoAnim.CrossFade("Tutorial_Ayano_Intro_ALT");
					Timer = 0f;
					Phase++;
				}
			}
		}
		else if (Phase == 2)
		{
			if (Debug && Input.GetButtonDown(InputNames.Xbox_A))
			{
				MainCamera.transform.position = new Vector3(3.01f, 1.25f, 20.5f);
				MainCamera.transform.eulerAngles = new Vector3(0f, 22.5f, 0f);
				Door.localPosition = new Vector3(-0.5f, 0f, 0f);
				KokonaAnim["Tutorial_Kokona_Intro"].time = 8.75f;
				AyanoAnim["Tutorial_Ayano_Intro_ALT"].time = 8.75f;
				SpeechTimer = 8.75f;
				Phase++;
			}
			if (Speed > 2.5f)
			{
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			Door.localPosition = Vector3.Lerp(Door.localPosition, new Vector3(-0.5f, 0f, 0f), Time.deltaTime * 2f);
			Timer += Time.deltaTime;
			if (KokonaAnim["Tutorial_Kokona_Intro"].time > 8.75f)
			{
				MyAudioSource.clip = KokonaIntro;
				MyAudioSource.Play();
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			if (AyanoAnim["Tutorial_Ayano_Intro_ALT"].time > 13f)
			{
				if (AyanoAnim["Tutorial_Ayano_Intro_ALT"].time > 20f)
				{
					AyanoAnim["Tutorial_Ayano_Intro_ALT"].speed = Mathf.MoveTowards(AyanoAnim["Tutorial_Ayano_Intro_ALT"].speed, 1.5f, Time.deltaTime);
				}
				else if (AyanoAnim["Tutorial_Ayano_Intro_ALT"].time > 15.5f)
				{
					AyanoAnim["Tutorial_Ayano_Intro_ALT"].speed = Mathf.MoveTowards(AyanoAnim["Tutorial_Ayano_Intro_ALT"].speed, 0.5f, Time.deltaTime);
				}
				else
				{
					AyanoAnim["Tutorial_Ayano_Intro_ALT"].speed = Mathf.MoveTowards(AyanoAnim["Tutorial_Ayano_Intro_ALT"].speed, 2f, Time.deltaTime);
				}
			}
			if (KokonaAnim["Tutorial_Kokona_Intro"].time > KokonaAnim["Tutorial_Kokona_Intro"].length - 1f || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				Jukebox.clip = WaitLoop;
				Jukebox.loop = true;
				Jukebox.Play();
				KokonaAnim.CrossFade("Tutorial_Kokona_Wait_Idle");
				AyanoAnim.CrossFade("Tutorial_Ayano_Wait_Idle");
				MyAudioSource.Stop();
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			Window.localScale = Vector3.Lerp(Window.localScale, Vector3.one, Time.deltaTime * 10f);
			if (Window.localScale.x > 0.9f)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					Jukebox.clip = AcceptClip;
					Jukebox.loop = false;
					Jukebox.Play();
					AyanoAnim.CrossFade("Tutorial_Ayano_Accept");
					MyAudioSource.clip = AyanoYes;
					MyAudioSource.Play();
					Darkness.color = new Color(1f, 1f, 1f, 0f);
					SpeechTimer = 30f;
					Phase++;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					Jukebox.clip = DeclineClip;
					Jukebox.loop = false;
					Jukebox.Play();
					AyanoAnim.CrossFade("Tutorial_Ayano_Decline");
					KokonaAnim.CrossFade("Tutorial_Kokona_Decline_Idle");
					MyAudioSource.clip = AyanoNo;
					MyAudioSource.Play();
					SpeechTimer = 40f;
					Phase = 9;
				}
			}
		}
		else if (Phase == 6)
		{
			if (!MyAudioSource.isPlaying || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				KokonaAnim.CrossFade("Tutorial_Kokona_Accept");
				AyanoAnim.CrossFade("Tutorial_Ayano_Accept_Idle");
				MyAudioSource.clip = KokonaYes;
				MyAudioSource.Play();
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			if (!MyAudioSource.isPlaying || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				Phase++;
			}
		}
		else if (Phase == 8)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha == 1f || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				GameGlobals.KokonaTutorial = true;
				GameGlobals.LastInputType = (int)InputDevice.Type;
				SceneManager.LoadScene("LoadingScene");
			}
		}
		else if (Phase == 9)
		{
			if (!MyAudioSource.isPlaying || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				KokonaAnim.CrossFade("Tutorial_Kokona_Decline");
				MyAudioSource.clip = KokonaNo;
				MyAudioSource.Play();
				Phase++;
			}
		}
		else if (Phase == 10)
		{
			if (!MyAudioSource.isPlaying || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				Phase++;
			}
		}
		else if (Phase == 11)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha == 1f || (Debug && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				GameGlobals.KokonaTutorial = false;
				GameGlobals.LastInputType = (int)InputDevice.Type;
				SceneManager.LoadScene("PhoneScene");
			}
		}
		if (Phase > 0)
		{
			SkipTimer += Time.deltaTime;
			if (SkipTimer > 5f)
			{
				SkipPanel.alpha -= Time.deltaTime;
			}
			if (Input.GetButton(InputNames.Xbox_X))
			{
				SkipPanel.alpha = 1f;
				SkipTimer = 0f;
				SkipCircle.fillAmount -= Time.deltaTime;
				if (SkipCircle.fillAmount == 0f)
				{
					if (Phase > 5 && Phase < 9)
					{
						Phase = 8;
					}
					else
					{
						Phase = 11;
					}
				}
			}
			else
			{
				SkipCircle.fillAmount = 1f;
			}
		}
		if (Phase > 1)
		{
			Speed += Time.deltaTime * 0.5f;
			MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, new Vector3(3.01f, 1.25f, 20.5f), Time.deltaTime * Speed * 0.1f);
			MainCamera.transform.eulerAngles = Vector3.Lerp(MainCamera.transform.eulerAngles, new Vector3(0f, 22.5f, 0f), Time.deltaTime * Speed * 0.1f);
			if (Phase > 5)
			{
				Window.localScale = Vector3.Lerp(Window.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
		}
		UpdateDOF(Vector3.Distance(MainCamera.transform.position, AyanoHead.position));
	}

	private void SetToDefault()
	{
		ColorGradingModel.Settings settings = Profile.colorGrading.settings;
		settings.basic.saturation = 1f;
		settings.channelMixer.red = new Vector3(1f, 0f, 0f);
		settings.channelMixer.green = new Vector3(0f, 1f, 0f);
		settings.channelMixer.blue = new Vector3(0f, 0f, 1f);
		Profile.colorGrading.settings = settings;
		DepthOfFieldModel.Settings settings2 = Profile.depthOfField.settings;
		settings2.focusDistance = 10f;
		settings2.aperture = 5.6f;
		Profile.depthOfField.settings = settings2;
		BloomModel.Settings settings3 = Profile.bloom.settings;
		settings3.bloom.intensity = 1f;
		Profile.bloom.settings = settings3;
		VignetteModel.Settings settings4 = Profile.vignette.settings;
		settings4.color = Color.black;
		settings4.intensity = 0.45f;
		settings4.smoothness = 0.2f;
		settings4.roundness = 1f;
		Profile.vignette.settings = settings4;
	}

	private void UpdateDOF(float DOF)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = DOF;
		Profile.depthOfField.settings = settings;
	}

	private void VtuberCheck()
	{
		for (int i = 1; i < VtuberHairs.Length; i++)
		{
			VtuberHairs[i].SetActive(value: false);
			VtuberAccs[i].SetActive(value: false);
		}
		if (GameGlobals.VtuberID > 0)
		{
			VtuberHairs[GameGlobals.VtuberID].SetActive(value: true);
			VtuberAccs[GameGlobals.VtuberID].SetActive(value: true);
			YandereHair.SetActive(value: false);
		}
	}
}
