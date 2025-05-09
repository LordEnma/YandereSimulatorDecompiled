using UnityEngine;

public class ConfessionSceneScript : MonoBehaviour
{
	public Transform[] CameraDestinations;

	public StudentManagerScript StudentManager;

	public LoveManagerScript LoveManager;

	public PromptBarScript PromptBar;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public ClockScript Clock;

	public Bloom BloomEffect;

	public StudentScript Suitor;

	public StudentScript Rival;

	public ParticleSystem MythBlossoms;

	public GameObject HeartBeatCamera;

	public GameObject ConfessionBG;

	public Transform MainCamera;

	public Transform RivalSpot;

	public Transform KissSpot;

	public Transform NewTree;

	public string[] Text;

	public GameObject[] Letters;

	public UISprite Darkness;

	public UILabel Label;

	public UIPanel Panel;

	public AudioSource MyAudio;

	public AudioSource Jingle;

	public AudioClip EightiesConfessionMusic;

	public bool MoveSuitor;

	public bool ShowLabel;

	public bool Kissing;

	public int TextPhase = 1;

	public int LetterID = 1;

	public int Phase = 1;

	public float LetterTimer = 0.1f;

	public float Speed;

	public float Timer;

	public Texture BlushTexture;

	private void Start()
	{
		if (Clock.TimeSkip)
		{
			Clock.EndTimeSkip();
		}
		Time.timeScale = 1f;
		if (StudentManager.Eighties)
		{
			MyAudio.clip = EightiesConfessionMusic;
		}
	}

	private void Update()
	{
		if (Phase == 1)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 0f, Time.deltaTime);
			Jukebox.Volume = Mathf.MoveTowards(Jukebox.Volume, 0f, Time.deltaTime);
			if (Darkness.color.a > 0.999f)
			{
				Darkness.alpha = 1f;
				Timer += Time.deltaTime;
				if (Timer > 1f)
				{
					Yandere.CameraEffects.UpdateBloom(1f);
					Yandere.CameraEffects.UpdateThreshold(1f);
					Yandere.CameraEffects.UpdateBloomKnee(1f);
					Yandere.CameraEffects.UpdateBloomRadius(7f);
					Suitor = StudentManager.Students[LoveManager.SuitorID];
					Rival = StudentManager.Students[LoveManager.RivalID];
					Rival.transform.position = RivalSpot.position;
					Rival.transform.eulerAngles = RivalSpot.eulerAngles;
					Debug.Log("Now activating blush on Suitor.");
					Suitor.Cosmetic.MyRenderer.materials[Suitor.Cosmetic.FaceID].SetTexture("_OverlayTex", BlushTexture);
					Suitor.Cosmetic.MyRenderer.materials[Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
					Suitor.transform.eulerAngles = StudentManager.SuitorConfessionSpot.eulerAngles;
					Suitor.transform.position = StudentManager.SuitorConfessionSpot.position;
					Suitor.CharacterAnimation.Play(Suitor.IdleAnim);
					Suitor.EmptyHands();
					ParticleSystem.EmissionModule emission = MythBlossoms.emission;
					emission.rateOverTime = 100f;
					HeartBeatCamera.SetActive(value: false);
					GetComponent<AudioSource>().Play();
					MainCamera.position = CameraDestinations[1].position;
					MainCamera.eulerAngles = CameraDestinations[1].eulerAngles;
					Timer = 0f;
					Phase++;
					Rival.transform.position = new Vector3(0f, 6.54f, 120f);
					Suitor.transform.position = new Vector3(0f, 6.533333f, 119f);
					NewTree.localPosition = new Vector3(0f, -0.1082915f, 0f);
					NewTree.localScale = new Vector3(50f, 50f, 100f);
				}
			}
		}
		else if (Phase == 2)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
			if (Darkness.color.a < 0.001f)
			{
				Darkness.alpha = 0f;
				if (!ShowLabel)
				{
					Label.color = new Color(Label.color.r, Label.color.g, Label.color.b, Mathf.MoveTowards(Label.color.a, 0f, Time.deltaTime));
					if (Label.color.a < 0.001f)
					{
						Label.alpha = 0f;
						if (TextPhase < 5)
						{
							MainCamera.position = CameraDestinations[TextPhase].position;
							MainCamera.eulerAngles = CameraDestinations[TextPhase].eulerAngles;
							if (TextPhase == 4 && !Kissing)
							{
								ParticleSystem.EmissionModule emission2 = Suitor.Hearts.emission;
								emission2.enabled = true;
								emission2.rateOverTime = 10f;
								Suitor.Hearts.Play();
								ParticleSystem.EmissionModule emission3 = Rival.Hearts.emission;
								emission3.enabled = true;
								emission3.rateOverTime = 10f;
								Rival.Hearts.Play();
								Suitor.Character.transform.localScale = new Vector3(1f, 1f, 1f);
								Suitor.transform.position = KissSpot.position;
								if (Suitor.Male)
								{
									Suitor.CharacterAnimation.Play("kiss_00");
								}
								else
								{
									Suitor.CharacterAnimation.Play("f02_suitorKiss_00");
								}
								if (!Rival.Male)
								{
									if (!Suitor.Male)
									{
										Rival.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
									}
									Rival.CharacterAnimation[Rival.ShyAnim].weight = 0f;
									Rival.CharacterAnimation.Play("f02_kiss_00");
								}
								else
								{
									if (!Suitor.Male)
									{
										Rival.Character.transform.localScale = new Vector3(0.86f, 0.86f, 0.86f);
									}
									Rival.CharacterAnimation.Play("suitorKiss_00");
								}
								Kissing = true;
							}
							Label.text = Text[TextPhase];
							ShowLabel = true;
						}
						else
						{
							Jingle.Play();
							Phase++;
						}
					}
				}
				else
				{
					Label.color = new Color(Label.color.r, Label.color.g, Label.color.b, Mathf.MoveTowards(Label.color.a, 1f, Time.deltaTime));
					if (Label.color.a > 0.999f)
					{
						Label.alpha = 1f;
						if (!PromptBar.Show)
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Continue";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							TextPhase++;
							ShowLabel = false;
						}
					}
				}
			}
		}
		else if (Phase == 3)
		{
			LetterTimer += Time.deltaTime;
			if (LetterTimer > 0.1f && LetterID < Letters.Length)
			{
				Letters[LetterID].SetActive(value: true);
				LetterTimer = 0f;
				LetterID++;
			}
			if (LetterTimer > 5f)
			{
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (Darkness.color.a > 0.999f)
			{
				Darkness.alpha = 1f;
				Timer += Time.deltaTime;
				if (Timer > 1f)
				{
					Debug.Log("As of right now, the StudentManager should be aware that the rival was eliminated through matchmaking.");
					DatingGlobals.SuitorProgress = 2;
					StudentManager.RivalEliminated = true;
					Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Matchmade;
					Suitor.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
					PromptBar.ClearButtons();
					PromptBar.UpdateButtons();
					PromptBar.Show = false;
					ConfessionBG.SetActive(value: false);
					Yandere.FixCamera();
					Phase++;
				}
			}
		}
		else
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 1f, Time.deltaTime);
			if (Darkness.color.a < 0.0001f)
			{
				Darkness.alpha = 0f;
				StudentManager.ComeBack();
				Suitor.enabled = false;
				Suitor.Prompt.enabled = false;
				Suitor.Pathfinding.canMove = false;
				Suitor.Pathfinding.canSearch = false;
				Rival.enabled = false;
				Rival.Prompt.enabled = false;
				Rival.Pathfinding.canMove = false;
				Rival.Pathfinding.canSearch = false;
				Yandere.ShoulderCamera.enabled = true;
				Yandere.RPGCamera.enabled = true;
				Yandere.CanMove = true;
				HeartBeatCamera.SetActive(value: true);
				ParticleSystem.EmissionModule emission4 = MythBlossoms.emission;
				emission4.rateOverTime = 20f;
				Clock.Police.gameObject.SetActive(value: true);
				Clock.StopTime = false;
				base.enabled = false;
				Suitor.PartnerID = LoveManager.RivalID;
				Rival.PartnerID = LoveManager.SuitorID;
				if (Suitor.Male)
				{
					Suitor.CharacterAnimation.CrossFade("holdHandsLoop_00");
				}
				else
				{
					Suitor.CharacterAnimation.CrossFade("f02_suitorHoldHandsLoop_00");
				}
				if (!Rival.Male)
				{
					Rival.CharacterAnimation.CrossFade("f02_holdHandsLoop_00");
				}
				else
				{
					Rival.CharacterAnimation.CrossFade("suitorHoldHandsLoop_00");
				}
			}
		}
		if (Kissing)
		{
			if (!Suitor.Male && !Rival.Male)
			{
				Suitor.transform.position = new Vector3(0f, 6.566667f, 119.59f);
			}
			if ((Suitor.Male && Suitor.CharacterAnimation["kiss_00"].time >= Suitor.CharacterAnimation["kiss_00"].length * 0.66666f) || (!Suitor.Male && Suitor.CharacterAnimation["f02_suitorKiss_00"].time >= Suitor.CharacterAnimation["f02_suitorKiss_00"].length * 0.66666f))
			{
				Suitor.Character.transform.localScale = Vector3.Lerp(Suitor.Character.transform.localScale, new Vector3(0.94f, 0.94f, 0.94f), Time.deltaTime);
			}
			if ((Suitor.Male && Suitor.CharacterAnimation["kiss_00"].time >= Suitor.CharacterAnimation["kiss_00"].length) || (!Suitor.Male && Suitor.CharacterAnimation["f02_suitorKiss_00"].time >= Suitor.CharacterAnimation["f02_suitorKiss_00"].length))
			{
				if (!Rival.Male)
				{
					Rival.CharacterAnimation.CrossFade("f02_introHoldHands_00");
				}
				else
				{
					Rival.CharacterAnimation.CrossFade("suitorHoldHands_00");
				}
				if (Suitor.Male)
				{
					Suitor.CharacterAnimation.CrossFade("introHoldHands_00");
				}
				else
				{
					Suitor.CharacterAnimation.CrossFade("f02_suitorIntroHoldHands_00");
				}
				Kissing = false;
				MoveSuitor = true;
			}
		}
		else if (Suitor != null)
		{
			Suitor.gameObject.SetActive(value: true);
			Suitor.Character.transform.localScale = Vector3.Lerp(Suitor.Character.transform.localScale, new Vector3(0.94f, 0.94f, 0.94f), Time.deltaTime);
			if (MoveSuitor)
			{
				Speed += Time.deltaTime;
				Suitor.Character.transform.position = Vector3.Lerp(Suitor.Character.transform.position, new Vector3(0f, 6.54f, 119.2f), Time.deltaTime * Speed);
			}
		}
	}
}
