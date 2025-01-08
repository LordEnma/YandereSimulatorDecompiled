using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class GenocideEndingScript : MonoBehaviour
{
	public UISprite SecondDarkness;

	public UISprite Darkness;

	public AudioSource MyAudio;

	public UISprite SkipCircle;

	public UIPanel SkipPanel;

	public UILabel Subtitle;

	public Animation Senpai;

	public Transform Neck;

	public AudioClip[] EightiesSpeechClip;

	public AudioClip[] SpeechClip;

	public AudioClip OsanaClip;

	public AudioClip Slam;

	public string[] EightiesText;

	public string[] SpeechText;

	public float[] SpeechDelay;

	public float[] SpeechTime;

	public GameObject RIVAL;

	public GameObject ELIMINATED;

	public GameObject SenpaiRopes;

	public GameObject OsanaRopes;

	public GameObject Osana;

	public int SpeechPhase;

	public float SecondAlpha;

	public float FadeSpeed = 0.2f;

	public float TimeLimit;

	public float Alpha;

	public float Delay;

	public float Timer;

	public bool EightiesEnding;

	public bool FadeOut;

	public bool LockJaw;

	public GameObject[] EightiesRivalHair;

	public GameObject[] RivalHair;

	public GameObject Blindfold;

	public GameObject Hood;

	public GameObject Jaw;

	public Font Arial;

	public PostProcessingProfile Profile;

	private void Start()
	{
		UpdateDOF(1f);
		Time.timeScale = 1f;
		SkipPanel.gameObject.SetActive(value: false);
		Hood.SetActive(value: false);
		if (GameGlobals.EightiesCutsceneID == 12)
		{
			SecondDarkness.color = new Color(0.1f, 0.1f, 0.1f, 0f);
			Darkness.color = new Color(0.1f, 0.1f, 0.1f, 1f);
			SkipPanel.gameObject.SetActive(value: true);
			SkipPanel.alpha = 0f;
			Debug.Log("We're here for the end of 1980s Mode.");
			SpeechText = EightiesText;
			Subtitle.text = SpeechText[1];
			SpeechClip = EightiesSpeechClip;
			MyAudio.clip = SpeechClip[1];
			MyAudio.Play();
			SpeechPhase = 1;
			YellowifyLabel(Subtitle);
			Senpai["kidnapTorture_01"].speed = 0.1f;
			Senpai.Play();
			SenpaiRopes.SetActive(value: true);
			OsanaRopes.SetActive(value: false);
			Senpai.transform.parent.gameObject.SetActive(value: true);
			Osana.SetActive(value: false);
			EightiesEnding = true;
			FadeSpeed = 0.1f;
			return;
		}
		if (EventGlobals.OsanaConversation)
		{
			Debug.Log("We're here for a Betray cutscene.");
			Osana.GetComponent<StudentScript>().CharacterAnimation["f02_kidnapTorture_01"].speed = 0.8f;
			Osana.GetComponent<CosmeticScript>().SetFemaleUniform();
			SenpaiRopes.SetActive(value: false);
			OsanaRopes.SetActive(value: true);
			Senpai.transform.parent.gameObject.SetActive(value: false);
			Osana.SetActive(value: true);
			SpeechText[10] = "...huh? ...what is this? ...why am I tied to a...chair?! Why are you doing this?! This isn't funny! Lemme go! Lemme go right now!";
			MyAudio.clip = OsanaClip;
			MyAudio.Play();
			SpeechPhase = 10;
			TimeLimit = 9f;
			Delay = 10f;
			if (GameGlobals.Eighties)
			{
				RivalHair[0].SetActive(value: false);
				if (GameGlobals.CustomMode)
				{
					Blindfold.SetActive(value: false);
					Hood.SetActive(value: true);
					LockJaw = true;
				}
				else
				{
					EightiesRivalHair[DateGlobals.Week].SetActive(value: true);
				}
				YellowifyLabel(Subtitle);
			}
			else if (DateGlobals.Week == 2)
			{
				SpeechText[10] = "...huh...?!...am...am I...tied to a chair...?!...no...no, this can't be happening...Yan-chan?! Yan-chan, did you do this?! Why?! Please, let me go...let me go!";
				RivalHair[DateGlobals.Week].SetActive(value: true);
				RivalHair[0].SetActive(value: false);
				MyAudio.volume = 0f;
			}
			Subtitle.text = SpeechText[10];
			return;
		}
		Debug.Log("We're here for the Genocide Ending.");
		Senpai["kidnapTorture_01"].speed = 0.9f;
		SenpaiRopes.SetActive(value: true);
		OsanaRopes.SetActive(value: false);
		Senpai.transform.parent.gameObject.SetActive(value: true);
		Osana.SetActive(value: false);
		GameGlobals.DarkEnding = true;
		if (GameGlobals.Eighties)
		{
			if (GameGlobals.CustomMode && GameGlobals.FemaleSenpai)
			{
				Osana.GetComponent<StudentScript>().CharacterAnimation["f02_kidnapTorture_01"].speed = 0.7f;
				Osana.GetComponent<CosmeticScript>().SetFemaleUniform();
				SenpaiRopes.SetActive(value: false);
				OsanaRopes.SetActive(value: true);
				Senpai.transform.parent.gameObject.SetActive(value: false);
				Osana.SetActive(value: true);
				RivalHair[0].SetActive(value: false);
				Blindfold.SetActive(value: false);
				Hood.SetActive(value: true);
				LockJaw = true;
			}
			YellowifyLabel(Subtitle);
		}
	}

	private void Update()
	{
		if (!EightiesEnding)
		{
			if (SpeechPhase > 9)
			{
				base.transform.Translate(Vector3.forward * -0.1f * Time.deltaTime);
				if (MyAudio.isPlaying)
				{
					Senpai.Play();
					if (MyAudio.time < TimeLimit)
					{
						Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.25f);
					}
					else
					{
						Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.25f);
					}
				}
				Darkness.color = new Color(0f, 0f, 0f, Alpha);
				if (Darkness.color.a == 1f)
				{
					Subtitle.text = "";
				}
			}
			if (MyAudio.isPlaying)
			{
				return;
			}
			Timer += Time.deltaTime;
			if (Delay == 10f && Timer > 1f)
			{
				if (Timer < 3f)
				{
					RIVAL.SetActive(value: true);
					ELIMINATED.SetActive(value: true);
				}
				else if (Timer < 5f)
				{
					if (ELIMINATED.activeInHierarchy)
					{
						ELIMINATED.SetActive(value: false);
						AudioSource.PlayClipAtPoint(Slam, base.transform.position);
					}
				}
				else
				{
					SecondAlpha = Mathf.MoveTowards(SecondAlpha, 1f, Time.deltaTime * 0.25f);
					SecondDarkness.color = new Color(0f, 0f, 0f, SecondAlpha);
				}
			}
			if (Timer > Delay)
			{
				SpeechPhase++;
				Timer = 0f;
				if (SpeechPhase < SpeechClip.Length)
				{
					Subtitle.text = SpeechText[SpeechPhase];
					MyAudio.clip = SpeechClip[SpeechPhase];
					Delay = SpeechDelay[SpeechPhase];
					MyAudio.Play();
				}
				else if (!EventGlobals.OsanaConversation)
				{
					SceneManager.LoadScene("CreditsScene");
				}
				else
				{
					DateGlobals.PassDays = 1;
					SceneManager.LoadScene("CalendarScene");
					EventGlobals.OsanaConversation = false;
				}
			}
			return;
		}
		base.transform.Translate(Vector3.forward * -0.01f * Time.deltaTime);
		if (!FadeOut)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * FadeSpeed);
			if (SkipPanel.alpha < 1f)
			{
				SkipPanel.alpha = Mathf.MoveTowards(SkipPanel.alpha, 1f, Time.deltaTime);
			}
			else if (Input.GetButton(InputNames.Xbox_X))
			{
				SkipCircle.fillAmount += Time.deltaTime;
				if (SkipCircle.fillAmount >= 1f)
				{
					FadeOut = true;
					FadeSpeed = 1f;
				}
			}
			else
			{
				SkipCircle.fillAmount = 0f;
			}
		}
		else
		{
			SecondDarkness.alpha = Mathf.MoveTowards(SecondDarkness.alpha, 1f, Time.deltaTime * FadeSpeed);
			if (SecondDarkness.alpha == 1f)
			{
				GameGlobals.DarkEnding = false;
				SceneManager.LoadScene("CreditsScene");
			}
			SkipPanel.alpha = Mathf.MoveTowards(SkipPanel.alpha, 0f, Time.deltaTime);
			if (SkipCircle.fillAmount >= 1f)
			{
				MyAudio.volume -= Time.deltaTime;
			}
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			MyAudio.Stop();
		}
		if (!MyAudio.isPlaying && SpeechPhase < SpeechClip.Length - 1)
		{
			SpeechPhase++;
			Subtitle.text = SpeechText[SpeechPhase];
			MyAudio.clip = SpeechClip[SpeechPhase];
			MyAudio.Play();
			if (SpeechPhase == SpeechClip.Length - 1)
			{
				FadeOut = true;
			}
		}
	}

	private void LateUpdate()
	{
		Neck.transform.localEulerAngles = new Vector3(0f, Neck.transform.localEulerAngles.y, Neck.transform.localEulerAngles.z);
		if (LockJaw)
		{
			Jaw.transform.eulerAngles = new Vector3(0f, 0f, 40f);
		}
	}

	public void YellowifyLabel(UILabel Label)
	{
		Label.trueTypeFont = Arial;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 0f, 1f);
		Label.fontStyle = FontStyle.Bold;
		Label.effectDistance = new Vector2(4f, 4f);
	}

	private void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
	}
}
