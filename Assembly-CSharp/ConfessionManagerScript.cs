using UnityEngine;

public class ConfessionManagerScript : MonoBehaviour
{
	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public HeartbrokenScript Heartbroken;

	public JukeboxScript OriginalJukebox;

	public CosmeticScript OsanaCosmetic;

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

	private void Start()
	{
		StudentManager.Yandere.Class.Portal.EndEvents();
		StudentManager.Students[StudentManager.RivalID].BookBag.SetActive(false);
		Senpai["SenpaiConfession"].speed = 0.9f;
		TimelessDarkness.color = new Color(0f, 0f, 0f, 0f);
		Darkness.color = new Color(0f, 0f, 0f, 1f);
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
				ConfessionCamera.gameObject.SetActive(true);
				MainCamera.SetActive(false);
				OsanaCosmetic = StudentManager.Students[StudentManager.RivalID].Cosmetic;
				Osana = StudentManager.Students[StudentManager.RivalID].CharacterAnimation;
				Tears = StudentManager.Students[StudentManager.RivalID].Tears;
				Senpai = StudentManager.Students[1].CharacterAnimation;
				SenpaiNeck = StudentManager.Students[1].Neck;
				Osana[OsanaCosmetic.Student.ShyAnim].weight = 0f;
				Senpai["SenpaiConfession"].speed = 0.9f;
				OriginalBlossoms.SetActive(false);
				Tears.gameObject.SetActive(true);
				Osana.transform.position = new Vector3(0f, 6.6f, 119.5f);
				Senpai.transform.position = new Vector3(0f, 6.6f, 119.5f);
				Osana.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				Senpai.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				OsanaCosmetic.MyRenderer.materials[OsanaCosmetic.FaceID].SetFloat("_BlendAmount", 1f);
				OsanaCosmetic.MyRenderer.materials[OsanaCosmetic.SkinID].SetFloat("_BlendAmount", 0f);
				OsanaCosmetic.MyRenderer.materials[OsanaCosmetic.UniformID].SetFloat("_BlendAmount", 0f);
				Debug.Log("The characters were told to perform their confession animations.");
				Senpai.Play("SenpaiConfession");
				Osana.Play("OsanaConfession");
				OriginalBlossoms.SetActive(false);
				HeartBeatCamera.SetActive(false);
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
				if (ContinueButton.alpha == 1f && Input.GetButtonDown("A"))
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
				else if (Osana["OsanaConfessionRejected"].time < 45f)
				{
					Senpai.CrossFade("SenpaiConfessionRejected", 1f);
					Osana["OsanaConfessionRejected"].time = 45f;
					Osana.CrossFade("OsanaConfessionRejected", 1f);
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
				Senpai.gameObject.SetActive(false);
				Osana["OsanaConfession"].time = 11f;
				MyAudio.volume = 1f;
				MyAudio.time = 8f;
				FadeOut = false;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (SubID < ConfessTimes.Length && Osana["OsanaConfession"].time > ConfessTimes[SubID] + 3f)
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
				if (ContinueButton.alpha == 1f && Input.GetButtonDown("A"))
				{
					ConfessionCamera.eulerAngles = new Vector3(0f, 0f, 0f);
					ConfessionCamera.position = new Vector3(0f, 7.85f, 118f);
					Osana["OsanaConfession"].time = Osana["OsanaConfession"].length;
					ContinueButton.alpha = 0f;
				}
			}
			if (Osana["OsanaConfession"].time >= Osana["OsanaConfession"].length)
			{
				ContinueButton.alpha = 0f;
				if (StudentManager.SabotageProgress > 4)
				{
					Reject = true;
				}
				if (!Reject)
				{
					Osana.CrossFade("OsanaConfessionAccepted");
					MyAudio.clip = ConfessionAccepted;
				}
				else
				{
					Osana.CrossFade("OsanaConfessionRejected");
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
				if (SubID < AcceptTimes.Length && Osana["OsanaConfessionAccepted"].time > AcceptTimes[SubID])
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
					if (ContinueButton.alpha == 1f && Input.GetButtonDown("A"))
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
				if (SubID < RejectTimes.Length && Osana["OsanaConfessionRejected"].time > RejectTimes[SubID])
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
					Osana["OsanaConfessionRejected"].time = 41f;
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
					if (ContinueButton.alpha == 1f && Input.GetButtonDown("A"))
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
				Senpai.gameObject.SetActive(true);
				if (!Reject)
				{
					Senpai.Play("SenpaiConfessionAccepted");
					Senpai["SenpaiConfessionAccepted"].time = Osana["OsanaConfessionAccepted"].time;
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
						Osana.Play("OsanaConfessionRejected");
						Osana["OsanaConfessionRejected"].time = 47f;
						Senpai.Play("SenpaiConfessionRejected");
						Senpai["SenpaiConfessionRejected"].time = 47f;
					}
					else
					{
						Osana.Play("OsanaConfessionAccepted");
						Osana["OsanaConfessionAccepted"].time = 47f;
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
					MainCamera.SetActive(true);
					Camera.main.enabled = true;
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
				Debug.Log("Timer is: " + Timer);
				if (Timer > 5f)
				{
					FadeOut = true;
					if (Darkness.color.a == 1f)
					{
						Debug.Log("Confession cutscene ended. Deciding where to go next.");
						StudentManager.RivalEliminated = true;
						StudentManager.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Rejected;
						MainCamera.SetActive(true);
						base.gameObject.SetActive(false);
						StudentManager.Clock.PresentTime = 1080f;
						StudentManager.Clock.StopTime = false;
						StudentManager.Yandere.HUD.alpha = 1f;
						StudentManager.Police.Darkness.color = new Color(0f, 0f, 0f, 1f);
						StudentManager.Police.gameObject.SetActive(true);
						StudentManager.Police.BeginConfession = false;
						StudentManager.Police.enabled = true;
						if (StudentManager.Police.EndOfDay.Phase == 25)
						{
							StudentManager.Police.EndOfDay.Phase = 13;
							StudentManager.Police.EndOfDay.Darken = true;
							StudentManager.Police.EndOfDay.EndOfDayDarkness.alpha = 1f;
							StudentManager.Police.EndOfDay.gameObject.SetActive(true);
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
