using UnityEngine;

public class ConfessionManagerScript : MonoBehaviour
{
	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public HeartbrokenScript Heartbroken;

	public JukeboxScript OriginalJukebox;

	public CosmeticScript OsanaCosmetic;

	public ConfessionDataScript[] ConfessionData;

	public AudioClip ConfessionAccepted;

	public AudioClip ConfessionRejected;

	public AudioClip ConfessionGiggle;

	public AudioClip[] ConfessionMusic;

	public GameObject OriginalBlossoms;

	public GameObject HeartBeatCamera;

	public GameObject MainCamera;

	public Transform ConfessionCamera;

	public Transform OriginalPOV;

	public Transform ReactionPOV;

	public Transform SenpaiNeck;

	public Transform SenpaiPOV;

	public string[] ConfessSubs;

	public string[] AcceptSubs;

	public string[] RejectSubs;

	public float[] ConfessTimes;

	public float[] AcceptTimes;

	public float[] RejectTimes;

	public UISprite TimelessDarkness;

	public UISprite ContinueButton;

	public UILabel ContinueLabel;

	public UILabel SubtitleLabel;

	public UISprite Darkness;

	public UIPanel Panel;

	public AudioSource MyAudio;

	public AudioSource Jukebox;

	public Animation Yandere;

	public Animation Senpai;

	public Animation Osana;

	public Renderer Tears;

	public float RotateSpeed;

	public float TearSpeed;

	public float TearTimer;

	public float Timer;

	public bool CheatRejection;

	public bool ReverseTears;

	public bool Eighties;

	public bool Skipping;

	public bool FadeOut;

	public bool Reject;

	public int TearPhase;

	public int Phase;

	public int MusicID;

	public int SubID;

	public string MalePrefix;

	private void Start()
	{
		ConfessionCamera.gameObject.SetActive(value: false);
		if (GameGlobals.FemaleSenpai)
		{
			Senpai.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
		}
		StudentManager.Yandere.Class.Portal.EndEvents();
		StudentManager.Students[StudentManager.RivalID].BookBag.SetActive(value: false);
		Senpai["SenpaiConfession"].speed = 0.9f;
		Debug.Log("At this moment, Darkness.color.alpha is being set to 0.");
		TimelessDarkness.color = new Color(0f, 0f, 0f, 0f);
		Darkness.color = new Color(0f, 0f, 0f, 0f);
		SubtitleLabel.text = "";
		Eighties = StudentManager.Eighties;
		ContinueButton.alpha = 0f;
		if (Eighties)
		{
			ConfessionMusic[1] = ConfessionMusic[5];
			ConfessionMusic[2] = ConfessionMusic[5];
			ConfessionMusic[3] = ConfessionMusic[5];
			ConfessionMusic[4] = ConfessionMusic[5];
			Jukebox.clip = ConfessionMusic[5];
			ContinueLabel.text = "CONTINUE";
			StudentManager.EightiesifyLabel(ContinueLabel);
			ContinueButton.transform.localPosition = new Vector3(680f, 370f, 0f);
			ContinueButton.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			ContinueLabel.transform.localPosition = new Vector3(-30f, 2.5f, 0f);
		}
		if (DateGlobals.Week > 1)
		{
			ConfessSubs = ConfessionData[DateGlobals.Week].ConfessSubs;
			AcceptSubs = ConfessionData[DateGlobals.Week].AcceptSubs;
			RejectSubs = ConfessionData[DateGlobals.Week].RejectSubs;
			MyAudio.clip = ConfessionData[DateGlobals.Week].ConfessionSpeech;
			ConfessionAccepted = ConfessionData[DateGlobals.Week].ConfessionAccepted;
			ConfessionRejected = ConfessionData[DateGlobals.Week].ConfessionRejected;
		}
		Time.timeScale = 1f;
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Phase == -1)
		{
			TimelessDarkness.color = new Color(TimelessDarkness.color.r, TimelessDarkness.color.g, TimelessDarkness.color.b, Mathf.MoveTowards(TimelessDarkness.color.a, 1f, Time.deltaTime));
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 0f, Time.deltaTime);
			OriginalJukebox.Volume = Mathf.MoveTowards(OriginalJukebox.Volume, 0f, Time.deltaTime);
			if (TimelessDarkness.color.a == 1f && Timer > 2f)
			{
				TimelessDarkness.color = new Color(0f, 0f, 0f, 0f);
				Darkness.color = new Color(0f, 0f, 0f, 1f);
				Debug.Log("This is the exact moment that the main camera should be disabled and the confession camera should be enabled.");
				ConfessionCamera.gameObject.SetActive(value: true);
				MainCamera.SetActive(value: false);
				OsanaCosmetic = StudentManager.Students[StudentManager.RivalID].Cosmetic;
				Osana = StudentManager.Students[StudentManager.RivalID].CharacterAnimation;
				Tears = StudentManager.Students[StudentManager.RivalID].Tears;
				Senpai = StudentManager.Students[1].CharacterAnimation;
				SenpaiNeck = StudentManager.Students[1].Neck;
				if (!StudentManager.Students[StudentManager.RivalID].Male)
				{
					Osana[OsanaCosmetic.Student.ShyAnim].weight = 0f;
				}
				else
				{
					Senpai.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
					MalePrefix = "Male";
				}
				Senpai["SenpaiConfession"].speed = 0.9f;
				OriginalBlossoms.SetActive(value: false);
				Tears.gameObject.SetActive(value: true);
				Osana.transform.position = new Vector3(0f, 6.6f, 119.5f);
				Senpai.transform.position = new Vector3(0f, 6.6f, 119.5f);
				Osana.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				Senpai.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				OsanaCosmetic.MyRenderer.materials[OsanaCosmetic.FaceID].SetFloat("_BlendAmount", 1f);
				OsanaCosmetic.MyRenderer.materials[OsanaCosmetic.SkinID].SetFloat("_BlendAmount", 0f);
				OsanaCosmetic.MyRenderer.materials[OsanaCosmetic.UniformID].SetFloat("_BlendAmount", 0f);
				Tears.materials[0].SetFloat("_TearReveal", 0f);
				Tears.materials[1].SetFloat("_TearReveal", 0f);
				Debug.Log("The characters were told to perform their confession animations.");
				Senpai.Play("SenpaiConfession");
				Osana.Play(MalePrefix + "OsanaConfession");
				OriginalBlossoms.SetActive(value: false);
				HeartBeatCamera.SetActive(value: false);
				if (!Eighties)
				{
					MyAudio.Play();
				}
				Jukebox.Play();
				Timer = 0f;
				Phase++;
				Yandere.transform.parent.position = new Vector3(5f, 5.73f, 119f);
				Yandere.transform.parent.eulerAngles = new Vector3(0f, -90f, 0f);
			}
		}
		else if (Phase == 0)
		{
			if (Darkness.color.a == 0f)
			{
				ContinueButton.alpha = Mathf.MoveTowards(ContinueButton.alpha, 1f, Time.deltaTime);
				if (ContinueButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					Timer = 11f;
				}
			}
			if (Timer > 11f)
			{
				if (!CheatRejection)
				{
					ContinueButton.alpha = 0f;
					FadeOut = true;
					Timer = 0f;
					Phase++;
				}
				else if (Osana[MalePrefix + "OsanaConfessionRejected"].time < 45f)
				{
					Senpai.CrossFade("SenpaiConfessionRejected", 1f);
					Osana[MalePrefix + "OsanaConfessionRejected"].time = 45f;
					Osana.CrossFade(MalePrefix + "OsanaConfessionRejected", 1f);
				}
			}
			else
			{
				StudentManager.Students[StudentManager.RivalID].MyRenderer.enabled = true;
				StudentManager.Students[1].MyRenderer.enabled = true;
			}
		}
		else if (Phase == 1)
		{
			if (Timer > 2f)
			{
				ConfessionCamera.eulerAngles = SenpaiPOV.eulerAngles;
				ConfessionCamera.position = SenpaiPOV.position;
				Senpai.gameObject.SetActive(value: false);
				Osana[MalePrefix + "OsanaConfession"].time = 11f;
				MyAudio.volume = 1f;
				MyAudio.time = 8f;
				FadeOut = false;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (SubID < ConfessTimes.Length && Osana[MalePrefix + "OsanaConfession"].time > ConfessTimes[SubID] + 3f)
			{
				if (!Eighties)
				{
					SubtitleLabel.text = ConfessSubs[SubID] ?? "";
				}
				else
				{
					SubtitleLabel.text = "(Your rival confesses her feelings to Senpai...)";
					if (SubID > 0)
					{
						ContinueButton.alpha = 1f;
					}
				}
				SubID++;
			}
			RotateSpeed += Time.deltaTime * 0.2f;
			ConfessionCamera.eulerAngles = Vector3.Lerp(ConfessionCamera.eulerAngles, new Vector3(0f, 0f, 0f), Time.deltaTime * RotateSpeed);
			ConfessionCamera.position = Vector3.Lerp(ConfessionCamera.position, new Vector3(0f, 7.85f, 118f), Time.deltaTime * RotateSpeed);
			if (Darkness.color.a == 0f)
			{
				ContinueButton.alpha = Mathf.MoveTowards(ContinueButton.alpha, 1f, Time.deltaTime);
				if (ContinueButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					ConfessionCamera.eulerAngles = new Vector3(0f, 0f, 0f);
					ConfessionCamera.position = new Vector3(0f, 7.85f, 118f);
					Osana[MalePrefix + "OsanaConfession"].time = Osana[MalePrefix + "OsanaConfession"].length;
					ContinueButton.alpha = 0f;
				}
			}
			if (Osana[MalePrefix + "OsanaConfession"].time >= Osana[MalePrefix + "OsanaConfession"].length)
			{
				ContinueButton.alpha = 0f;
				if (StudentManager.SabotageProgress > 4 || StudentManager.StudentReps[StudentManager.RivalID] < -100f)
				{
					Reject = true;
				}
				if (!Reject)
				{
					Osana.CrossFade(MalePrefix + "OsanaConfessionAccepted");
					MyAudio.clip = ConfessionAccepted;
				}
				else
				{
					Osana.CrossFade(MalePrefix + "OsanaConfessionRejected");
					MyAudio.clip = ConfessionRejected;
				}
				MyAudio.time = 0f;
				MyAudio.Play();
				Jukebox.Stop();
				if (Eighties)
				{
					MyAudio.volume = 0f;
				}
				SubtitleLabel.text = "";
				RotateSpeed = 0f;
				SubID = 0;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			if (!Reject)
			{
				if (SubID < AcceptTimes.Length && Osana[MalePrefix + "OsanaConfessionAccepted"].time > AcceptTimes[SubID])
				{
					if (!Eighties)
					{
						SubtitleLabel.text = AcceptSubs[SubID] ?? "";
					}
					else
					{
						SubtitleLabel.text = "Senpai accepts your rival's confession...";
					}
					SubID++;
				}
				if (TearPhase == 0)
				{
					if (Timer > 26f)
					{
						ReverseTears = true;
						TearSpeed = 5f;
						TearPhase++;
					}
				}
				else if (TearPhase == 1)
				{
					if ((double)Timer > 33.33333)
					{
						ReverseTears = true;
						TearSpeed = 5f;
						TearPhase++;
					}
				}
				else if (TearPhase == 2)
				{
					if (Timer > 39f)
					{
						ReverseTears = true;
						TearSpeed = 5f;
						TearPhase++;
					}
				}
				else if (TearPhase == 3 && Timer > 40f)
				{
					TearPhase++;
				}
				if (Timer > 10f)
				{
					if (!Jukebox.isPlaying)
					{
						Jukebox.clip = ConfessionMusic[4];
						Jukebox.loop = true;
						Jukebox.volume = 0f;
						Jukebox.Play();
					}
					Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0.05f, Time.deltaTime * 0.01f);
					if (!ReverseTears)
					{
						TearTimer = Mathf.MoveTowards(TearTimer, 1f, Time.deltaTime * TearSpeed);
					}
					else
					{
						TearTimer = Mathf.MoveTowards(TearTimer, 0f, Time.deltaTime * TearSpeed);
						if (TearTimer == 0f)
						{
							ReverseTears = false;
							TearSpeed = 0.2f;
						}
					}
					if (TearPhase < 4)
					{
						Tears.materials[0].SetFloat("_TearReveal", TearTimer);
					}
					Tears.materials[1].SetFloat("_TearReveal", TearTimer);
				}
				if (Darkness.color.a == 0f)
				{
					if (SubID > 0)
					{
						ContinueButton.alpha = Mathf.MoveTowards(ContinueButton.alpha, 1f, Time.deltaTime);
					}
					if (ContinueButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
					{
						Debug.Log("Skippin'.");
						MyAudio.enabled = false;
						MyAudio.volume = 0f;
						MyAudio.Stop();
						Skipping = true;
						Timer = 43f;
					}
				}
				if (Timer >= 43f)
				{
					ContinueButton.alpha = 0f;
					TearSpeed = 0.1f;
					FadeOut = true;
					Timer = 0f;
					Phase++;
				}
			}
			else
			{
				if (SubID < RejectTimes.Length && Osana[MalePrefix + "OsanaConfessionRejected"].time > RejectTimes[SubID])
				{
					if (!Eighties)
					{
						SubtitleLabel.text = RejectSubs[SubID] ?? "";
					}
					else
					{
						SubtitleLabel.text = "(Senpai rejects your rival's confession!)";
					}
					SubID++;
				}
				if (Eighties && Timer < 41f)
				{
					Osana[MalePrefix + "OsanaConfessionRejected"].time = 41f;
					Timer = 41f;
				}
				if (Timer > 41f)
				{
					TearTimer = Mathf.MoveTowards(TearTimer, 1f, Time.deltaTime * TearSpeed);
					Tears.materials[0].SetFloat("_TearReveal", TearTimer);
					Tears.materials[1].SetFloat("_TearReveal", TearTimer);
				}
				if (Timer > 47f)
				{
					RotateSpeed += Time.deltaTime * 0.01f;
					ConfessionCamera.eulerAngles = new Vector3(ConfessionCamera.eulerAngles.x, ConfessionCamera.eulerAngles.y - RotateSpeed * 2f, ConfessionCamera.eulerAngles.z);
					ConfessionCamera.position = new Vector3(ConfessionCamera.position.x, ConfessionCamera.position.y, ConfessionCamera.position.z - RotateSpeed * 0.05f);
				}
				if (Darkness.color.a == 0f)
				{
					if (SubID > 0)
					{
						ContinueButton.alpha = Mathf.MoveTowards(ContinueButton.alpha, 1f, Time.deltaTime);
					}
					if (ContinueButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
					{
						Debug.Log("Skippin'.");
						MyAudio.enabled = false;
						MyAudio.volume = 0f;
						MyAudio.Stop();
						Skipping = true;
						Timer = 51f;
					}
				}
				if (Timer > 51f)
				{
					ContinueButton.alpha = 0f;
					FadeOut = true;
					Timer = 0f;
					Phase++;
				}
			}
		}
		else if (Phase == 4)
		{
			if (Reject)
			{
				RotateSpeed += Time.deltaTime * 0.01f;
				ConfessionCamera.eulerAngles = new Vector3(ConfessionCamera.eulerAngles.x, ConfessionCamera.eulerAngles.y - RotateSpeed * 2f, ConfessionCamera.eulerAngles.z);
				ConfessionCamera.position = new Vector3(ConfessionCamera.position.x, ConfessionCamera.position.y, ConfessionCamera.position.z - RotateSpeed * 0.05f);
			}
			if (Timer > 2f)
			{
				ConfessionCamera.eulerAngles = OriginalPOV.eulerAngles;
				ConfessionCamera.position = OriginalPOV.position;
				Senpai.gameObject.SetActive(value: true);
				if (!GameGlobals.CustomMode)
				{
					Senpai.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
				}
				if (!Reject)
				{
					Senpai.Play("SenpaiConfessionAccepted");
					Senpai["SenpaiConfessionAccepted"].time = Osana[MalePrefix + "OsanaConfessionAccepted"].time;
					Senpai.Play("SenpaiConfessionAccepted");
					Yandere.Play("YandereConfessionAccepted");
					StudentManager.Yandere.LoseGentleEyes();
				}
				else
				{
					Senpai.Play("SenpaiConfessionRejected");
					Senpai["SenpaiConfessionRejected"].time += 2f;
				}
				if (Skipping)
				{
					if (Reject)
					{
						Osana.Play(MalePrefix + "OsanaConfessionRejected");
						Osana[MalePrefix + "OsanaConfessionRejected"].time = 47f;
						Senpai.Play("SenpaiConfessionRejected");
						Senpai["SenpaiConfessionRejected"].time = 47f;
					}
					else
					{
						Osana.Play(MalePrefix + "OsanaConfessionAccepted");
						Osana[MalePrefix + "OsanaConfessionAccepted"].time = 47f;
						Senpai.Play("SenpaiConfessionAccepted");
						Senpai["SenpaiConfessionAccepted"].time = 47f;
					}
				}
				SubtitleLabel.text = "";
				FadeOut = false;
				RotateSpeed = 0f;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			if (Timer > 5f)
			{
				if (Reject)
				{
					Yandere.Play("YandereConfessionRejected");
					StudentManager.Yandere.LoseGentleEyes();
				}
				Jukebox.pitch = Mathf.MoveTowards(Jukebox.pitch, 0f, Time.deltaTime * 0.1f);
				RotateSpeed += Time.deltaTime * 0.5f;
				ConfessionCamera.position = Vector3.Lerp(ConfessionCamera.position, new Vector3(7f, 7f, 118.5f), Time.deltaTime * RotateSpeed);
				if (Timer > 10f)
				{
					if (Reject)
					{
						AudioSource.PlayClipAtPoint(ConfessionGiggle, Yandere.transform.position);
					}
					ConfessionCamera.eulerAngles = ReactionPOV.eulerAngles;
					ConfessionCamera.position = ReactionPOV.position;
					RotateSpeed = 0f;
					Timer = 0f;
					Phase++;
				}
			}
		}
		else if (Phase == 6)
		{
			Jukebox.pitch = Mathf.MoveTowards(Jukebox.pitch, 0f, Time.deltaTime * 0.1f);
			if (!Reject)
			{
				if (!Heartbroken.Confessed)
				{
					MainCamera.transform.eulerAngles = ConfessionCamera.eulerAngles;
					MainCamera.transform.position = ConfessionCamera.position;
					Heartbroken.Confessed = true;
					MainCamera.SetActive(value: true);
					Camera.main.enabled = true;
					StudentManager.Yandere.RPGCamera.enabled = false;
					ShoulderCamera.enabled = true;
					ShoulderCamera.Noticed = true;
					ShoulderCamera.Skip = true;
				}
				ConfessionCamera.position = MainCamera.transform.position;
			}
			else
			{
				RotateSpeed += Time.deltaTime * 0.5f;
				ConfessionCamera.position = Vector3.Lerp(ConfessionCamera.position, new Vector3(4f, 7f, 119f), Time.deltaTime * RotateSpeed);
				if (Timer > 5f)
				{
					FadeOut = true;
					if (Darkness.color.a == 1f)
					{
						Debug.Log("Confession cutscene ended. Deciding where to go next.");
						StudentManager.RivalEliminated = true;
						StudentManager.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Rejected;
						MainCamera.SetActive(value: true);
						base.gameObject.SetActive(value: false);
						StudentManager.Clock.PresentTime = 1080f;
						StudentManager.Clock.StopTime = false;
						StudentManager.Yandere.HUD.alpha = 1f;
						StudentManager.Police.Darkness.color = new Color(0f, 0f, 0f, 1f);
						StudentManager.Police.gameObject.SetActive(value: true);
						StudentManager.Police.BeginConfession = false;
						StudentManager.Police.enabled = true;
						if (StudentManager.Police.EndOfDay.Phase == 25)
						{
							StudentManager.Police.EndOfDay.Phase = 13;
							StudentManager.Police.EndOfDay.Darken = true;
							StudentManager.Police.EndOfDay.EndOfDayDarkness.alpha = 1f;
							StudentManager.Police.EndOfDay.gameObject.SetActive(value: true);
						}
					}
				}
			}
		}
		if (FadeOut)
		{
			Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime * 0.5f));
		}
		else
		{
			Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime * 0.5f));
		}
	}

	private void LateUpdate()
	{
		if (Phase > 4 && Reject)
		{
			SenpaiNeck.eulerAngles = new Vector3(SenpaiNeck.eulerAngles.x + 15f, SenpaiNeck.eulerAngles.y, SenpaiNeck.eulerAngles.z);
		}
	}
}
