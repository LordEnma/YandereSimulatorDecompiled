using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;

public class MissionModeScript : MonoBehaviour
{
	public SecurityCameraManagerScript SecurityCameraManager;

	public NotificationManagerScript NotificationManager;

	public CameraFilterPack_Gradients_FireGradient Fire;

	public NewMissionWindowScript NewMissionWindow;

	public MissionModeMenuScript MissionModeMenu;

	public StudentManagerScript StudentManager;

	public WeaponManagerScript WeaponManager;

	public PromptScript ExitPortalPrompt;

	public IncineratorScript Incinerator;

	public AlphabetScript AlphabetArrow;

	public ReputationScript Reputation;

	public GrayscaleEffect Grayscale;

	public PromptBarScript PromptBar;

	public WeaponScript MurderWeapon;

	public BoundaryScript Boundary;

	public JukeboxScript Jukebox;

	public ManholeScript Manhole;

	public YandereScript Yandere;

	public PoliceScript Police;

	public ClockScript Clock;

	public PlantScript Plant;

	public WoodChipperScript WoodChipper;

	public WoodChipperScript AcidVat;

	public WoodChipperScript Kiln;

	public UILabel EventSubtitleLabel;

	public UILabel ReputationLabel;

	public UILabel GameOverHeader;

	public UILabel GameOverReason;

	public UILabel SubtitleLabel;

	public UILabel LoadingLabel;

	public UILabel SpottedLabel;

	public UILabel SanityLabel;

	public UILabel MoneyLabel;

	public UILabel TimeLabel;

	public Graphic NewFPSLabel;

	public Graphic NewFPSValueLabel;

	public UISprite ReputationFace1;

	public UISprite ReputationFace2;

	public UISprite ReputationBG;

	public UISprite CautionSign;

	public UISprite MusicIcon;

	public UISprite Darkness;

	public UISprite PhoneBar;

	public UISprite PhoneBG;

	public UILabel FPS;

	public GardenHoleScript[] GardenHoles;

	public GameObject[] ReputationIcons;

	public GameObject[] CardboardBoxes;

	public string[] GameOverReasons;

	public AudioClip[] StealthMusic;

	public Transform[] SpawnPoints;

	public UISprite[] PoliceIcon;

	public UILabel[] PoliceLabel;

	public int[] Conditions;

	public GameObject SecurityCameraGroup;

	public GameObject MetalDetectorGroup;

	public GameObject HeartbrokenCamera;

	public GameObject DetectionCamera;

	public GameObject HeartbeatCamera;

	public GameObject MissionModeHUD;

	public GameObject SpottedWindow;

	public GameObject TranqDetector;

	public GameObject WitnessCamera;

	public GameObject GameOverText;

	public GameObject VoidGoddess;

	public GameObject Headmaster;

	public GameObject ExitPortal;

	public GameObject MurderKit;

	public GameObject Subtitle;

	public GameObject Nemesis;

	public GameObject Safe;

	public Transform LastKnownPosition;

	public int RequiredClothingID;

	public int RequiredDisposalID;

	public int RequiredWeaponID;

	public int NemesisDifficulty;

	public int DisposalMethod;

	public int MurderWeaponID;

	public int GameOverPhase;

	public int Destination;

	public int Difficulty;

	public int GameOverID;

	public int EndFrame;

	public int TargetID;

	public int MusicID = 1;

	public int Phase = 1;

	public int ID;

	public int[] Target;

	public int[] Method;

	public bool BroughtHardware;

	public bool SecurityCameras;

	public bool MetalDetectors;

	public bool StealDocuments;

	public bool NoCollateral;

	public bool NoSuspicion;

	public bool NoWitnesses;

	public bool NoCorpses;

	public bool NoSpeech;

	public bool NoWeapon;

	public bool NoBlood;

	public bool TimeLimit;

	public bool CorrectClothingConfirmed;

	public bool DocumentsStolen;

	public bool CorpseDisposed;

	public bool WeaponDisposed;

	public bool CheckForBlood;

	public bool BloodCleaned;

	public bool MultiMission;

	public bool InfoRemark;

	public bool TargetDead;

	public bool YakuzaMode;

	public bool Chastise;

	public bool Eighties;

	public bool FadeOut;

	public bool Run;

	public bool Enabled;

	public bool[] Checking;

	public string CauseOfFailure = string.Empty;

	public float TimeRemaining = 300f;

	public float TargetHeight;

	public float BloodTimer;

	public float Speed;

	public float Timer;

	public AudioClip InfoAccomplished;

	public AudioClip InfoExfiltrate;

	public AudioClip InfoObjective;

	public AudioClip InfoFailure;

	public AudioClip GameOverSound;

	public AudioClip YakuzaSuccess;

	public AudioClip Silence;

	public AudioSource MyAudio;

	public Camera MainCamera;

	public UILabel Watermark;

	public Font Arial;

	public AudioClip Failure;

	public int Frame;

	public UILabel DiscordCodeLabel;

	public float RandomNumber;

	public bool Valid;

	public string Title;

	public UILabel EightiesLoadingLabel;

	public UILabel ModernLoadingLabel;

	public Font EightiesFont;

	public Font ModernFont;

	private void Start()
	{
		if (!SchoolGlobals.HighSecurity)
		{
			MetalDetectorGroup.SetActive(value: false);
		}
		NewMissionWindow.gameObject.SetActive(value: false);
		MissionModeHUD.SetActive(value: false);
		SpottedWindow.SetActive(value: false);
		ExitPortal.SetActive(value: false);
		if (GameGlobals.Eighties)
		{
			StudentManager.EightiesifyLabel(Watermark);
			Watermark.transform.localPosition = new Vector3(0f, -546f, 0f);
			if (GameGlobals.EightiesTutorial)
			{
				Watermark.gameObject.SetActive(value: false);
			}
			Eighties = true;
			InfoAccomplished = YakuzaSuccess;
			InfoExfiltrate = Silence;
			InfoObjective = Silence;
			InfoFailure = Silence;
			Yandere.CharacterAnimation.Play("f02_ryobaIdle_00");
		}
		if (GameGlobals.LoveSick)
		{
			MurderKit.SetActive(value: false);
			Yandere.HeartRate.MediumColour = new Color(1f, 1f, 1f, 1f);
			Yandere.HeartRate.NormalColour = new Color(1f, 1f, 1f, 1f);
			Clock.PeriodLabel.color = new Color(1f, 0f, 0f, 1f);
			Clock.TimeLabel.color = new Color(1f, 0f, 0f, 1f);
			Clock.DayLabel.enabled = false;
			MoneyLabel.color = new Color(1f, 0f, 0f, 1f);
			MoneyLabel.applyGradient = false;
			Reputation.PendingRepMarker.GetComponent<UISprite>().color = new Color(1f, 0f, 0f, 1f);
			Reputation.CurrentRepMarker.gameObject.SetActive(value: false);
			Reputation.PendingRepLabel.color = new Color(1f, 0f, 0f, 1f);
			Reputation.PendingRepLabel.applyGradient = false;
			ReputationFace1.color = new Color(1f, 0f, 0f, 1f);
			ReputationFace2.color = new Color(1f, 0f, 0f, 1f);
			ReputationBG.color = new Color(1f, 0f, 0f, 1f);
			ReputationLabel.color = new Color(1f, 0f, 0f, 1f);
			ReputationLabel.applyGradient = false;
			Watermark.color = new Color(1f, 0f, 0f, 1f);
			Watermark.applyGradient = false;
			EventSubtitleLabel.color = new Color(1f, 0f, 0f, 1f);
			EventSubtitleLabel.applyGradient = false;
			SubtitleLabel.color = new Color(1f, 0f, 0f, 1f);
			SubtitleLabel.applyGradient = false;
			CautionSign.color = new Color(1f, 0f, 0f, 1f);
			CautionSign.applyGradient = false;
			FPS.color = new Color(1f, 0f, 0f, 1f);
			FPS.applyGradient = false;
			SanityLabel.color = new Color(1f, 0f, 0f, 1f);
			SanityLabel.applyGradient = false;
			for (ID = 1; ID < PoliceLabel.Length; ID++)
			{
				PoliceLabel[ID].color = new Color(1f, 0f, 0f, 1f);
				PoliceLabel[ID].applyGradient = false;
			}
			for (ID = 1; ID < PoliceIcon.Length; ID++)
			{
				PoliceIcon[ID].color = new Color(1f, 0f, 0f, 1f);
				PoliceIcon[ID].applyGradient = false;
			}
			PhoneBar.color = new Color(0f, 0f, 0f, 1f);
			PhoneBG.color = new Color(0.5f, 0.5f, 0.5f, 1f);
			PhoneBG.gradientTop = new Color(1f, 1f, 1f, 1f);
			PhoneBG.gradientBottom = new Color(0.5f, 0.5f, 0.5f, 1f);
		}
		NewFPSLabel.transform.parent.parent.gameObject.SetActive(value: true);
		if (MissionModeGlobals.MissionMode)
		{
			NewFPSLabel.color = new Color(1f, 1f, 1f, 1f);
			NewFPSValueLabel.color = new Color(1f, 1f, 1f, 1f);
			AlphabetArrow.gameObject.SetActive(value: true);
			AlphabetArrow.gameObject.GetComponent<Renderer>().material.shader = StudentManager.QualityManager.ToonOutline;
			AlphabetArrow.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0f);
			Headmaster.SetActive(value: false);
			Yandere.HeartRate.MediumColour = new Color(1f, 0.5f, 0.5f, 1f);
			Yandere.HeartRate.NormalColour = new Color(1f, 1f, 1f, 1f);
			Clock.PeriodLabel.color = new Color(1f, 1f, 1f, 1f);
			Clock.TimeLabel.color = new Color(1f, 1f, 1f, 1f);
			Clock.DayLabel.enabled = false;
			MoneyLabel.color = new Color(1f, 1f, 1f, 1f);
			MoneyLabel.fontStyle = FontStyle.Bold;
			MoneyLabel.trueTypeFont = Arial;
			MoneyLabel.applyGradient = false;
			Reputation.PendingRepMarker.GetComponent<UISprite>().color = new Color(1f, 1f, 1f, 1f);
			Reputation.CurrentRepMarker.gameObject.SetActive(value: false);
			Reputation.PendingRepLabel.color = new Color(1f, 1f, 1f, 1f);
			Reputation.PendingRepLabel.applyGradient = false;
			ReputationLabel.fontStyle = FontStyle.Bold;
			ReputationLabel.trueTypeFont = Arial;
			ReputationLabel.color = new Color(1f, 1f, 1f, 1f);
			ReputationLabel.applyGradient = false;
			ReputationLabel.text = "AWARENESS";
			ReputationIcons[0].SetActive(value: true);
			ReputationIcons[1].SetActive(value: false);
			ReputationIcons[2].SetActive(value: false);
			ReputationIcons[3].SetActive(value: false);
			ReputationIcons[4].SetActive(value: false);
			ReputationIcons[5].SetActive(value: false);
			Clock.TimeLabel.fontStyle = FontStyle.Bold;
			Clock.TimeLabel.trueTypeFont = Arial;
			Clock.TimeLabel.applyGradient = false;
			Clock.PeriodLabel.fontStyle = FontStyle.Bold;
			Clock.PeriodLabel.trueTypeFont = Arial;
			Clock.PeriodLabel.applyGradient = false;
			Watermark.fontStyle = FontStyle.Bold;
			Watermark.color = new Color(1f, 1f, 1f, 1f);
			Watermark.trueTypeFont = Arial;
			Watermark.applyGradient = false;
			SubtitleLabel.color = new Color(1f, 1f, 1f, 1f);
			SubtitleLabel.applyGradient = false;
			CautionSign.color = new Color(1f, 1f, 1f, 1f);
			CautionSign.applyGradient = false;
			FPS.color = new Color(1f, 1f, 1f, 1f);
			FPS.applyGradient = false;
			SanityLabel.color = new Color(1f, 1f, 1f, 1f);
			SanityLabel.applyGradient = false;
			StudentManager.MissionMode = true;
			NemesisDifficulty = MissionModeGlobals.NemesisDifficulty;
			Difficulty = MissionModeGlobals.MissionDifficulty;
			TargetID = MissionModeGlobals.MissionTarget;
			if (Eighties && NemesisDifficulty > 0)
			{
				YakuzaMode = true;
			}
			else
			{
				YakuzaMode = false;
			}
			ClassGlobals.BiologyGrade = 1;
			ClassGlobals.ChemistryGrade = 4;
			ClassGlobals.LanguageGrade = 1;
			ClassGlobals.PhysicalGrade = 1;
			ClassGlobals.PsychologyGrade = 1;
			OptionGlobals.TutorialsOff = true;
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 1f - (float)Difficulty * 0.1f;
			PlayerGlobals.Money = 20f;
			StudentManager.Atmosphere = 1f - (float)Difficulty * 0.1f;
			StudentManager.StudentPhotographed[TargetID] = true;
			StudentManager.SetAtmosphere();
			if (ID == 12)
			{
				Debug.Log("Establishing Mission Mode variables!");
				Debug.Log("StudentManager.StudentPhotographed[12] is: " + StudentManager.StudentPhotographed[12]);
			}
			for (ID = 1; ID < PoliceLabel.Length; ID++)
			{
				PoliceLabel[ID].fontStyle = FontStyle.Bold;
				PoliceLabel[ID].color = new Color(1f, 1f, 1f, 1f);
				PoliceLabel[ID].trueTypeFont = Arial;
				PoliceLabel[ID].applyGradient = false;
			}
			for (ID = 1; ID < PoliceIcon.Length; ID++)
			{
				PoliceIcon[ID].color = new Color(1f, 1f, 1f, 1f);
				PoliceIcon[ID].applyGradient = false;
			}
			if (Difficulty > 1)
			{
				for (ID = 2; ID < Difficulty + 1; ID++)
				{
					int missionCondition = MissionModeGlobals.GetMissionCondition(ID);
					switch (missionCondition)
					{
					case 1:
						RequiredWeaponID = MissionModeGlobals.MissionRequiredWeapon;
						break;
					case 2:
						RequiredClothingID = MissionModeGlobals.MissionRequiredClothing;
						break;
					case 3:
						RequiredDisposalID = MissionModeGlobals.MissionRequiredDisposal;
						break;
					case 4:
						NoCollateral = true;
						break;
					case 5:
						NoWitnesses = true;
						break;
					case 6:
						NoCorpses = true;
						break;
					case 7:
						NoWeapon = true;
						break;
					case 8:
						NoBlood = true;
						break;
					case 9:
						TimeLimit = true;
						break;
					case 10:
						NoSuspicion = true;
						break;
					case 11:
						SecurityCameras = true;
						break;
					case 12:
						MetalDetectors = true;
						break;
					case 13:
						NoSpeech = true;
						break;
					case 14:
						StealDocuments = true;
						break;
					}
					Conditions[ID] = missionCondition;
				}
			}
			if (!StealDocuments)
			{
				DocumentsStolen = true;
			}
			else
			{
				Safe.SetActive(value: true);
			}
			if (SecurityCameras)
			{
				SecurityCameraManager.ActivateAllCameras();
			}
			if (MetalDetectors)
			{
				MetalDetectorGroup.SetActive(value: true);
			}
			if (TimeLimit)
			{
				TimeLabel.gameObject.SetActive(value: true);
			}
			if (NoSpeech)
			{
				StudentManager.NoSpeech = true;
			}
			if (RequiredDisposalID == 0)
			{
				CorpseDisposed = true;
			}
			if (NemesisDifficulty > 0 && !YakuzaMode)
			{
				Nemesis.SetActive(value: true);
			}
			if (!NoWeapon)
			{
				WeaponDisposed = true;
			}
			if (!NoBlood)
			{
				BloodCleaned = true;
			}
			Jukebox.Egg = true;
			Jukebox.KillVolume();
			if (Eighties)
			{
				Jukebox.MissionMode.clip = StealthMusic[0];
			}
			Yandere.FixCamera();
			if (!YakuzaMode)
			{
				MusicID = Random.Range(1, 10);
				ChangeMusic();
				Jukebox.MissionMode.enabled = true;
				Jukebox.MissionMode.volume = 0f;
				Jukebox.MissionMode.Play();
			}
			else
			{
				Jukebox.YakuzaMusic.SetActive(value: true);
			}
			BroughtHardware = PlayerGlobals.BringingHardware > 0;
			MainCamera.transform.position = new Vector3(0f, 6.51505f, -76.9222f);
			MainCamera.transform.eulerAngles = new Vector3(15f, MainCamera.transform.eulerAngles.y, MainCamera.transform.eulerAngles.z);
			Yandere.RPGCamera.enabled = false;
			Yandere.SanityBased = true;
			Yandere.CanMove = false;
			VoidGoddess.GetComponent<VoidGoddessScript>().Window.gameObject.SetActive(value: false);
			TranqDetector.GetComponent<TranqDetectorScript>().Checklist.alpha = 0f;
			HeartbeatCamera.SetActive(value: false);
			TranqDetector.SetActive(value: false);
			VoidGoddess.SetActive(value: false);
			MurderKit.SetActive(value: false);
			TargetHeight = 1.51505f;
			Yandere.HUD.alpha = 0f;
			MusicIcon.color = new Color(MusicIcon.color.r, MusicIcon.color.g, MusicIcon.color.b, 1f);
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
			MissionModeMenu.UpdateGraphics();
			MissionModeMenu.gameObject.SetActive(value: true);
			if (MissionModeGlobals.MultiMission)
			{
				NewMissionWindow.gameObject.SetActive(value: true);
				MissionModeMenu.gameObject.SetActive(value: false);
				NewMissionWindow.FillOutInfo();
				NewMissionWindow.HideButtons();
				MultiMission = true;
			}
			PhoneBar.color = new Color(0f, 0f, 0f, 1f);
			PhoneBG.color = new Color(0.5f, 0.5f, 0.5f, 1f);
			PhoneBG.gradientTop = new Color(1f, 1f, 1f, 1f);
			PhoneBG.gradientBottom = new Color(0.5f, 0.5f, 0.5f, 1f);
			Enabled = true;
		}
		else
		{
			MissionModeMenu.gameObject.SetActive(value: false);
			TimeLabel.gameObject.SetActive(value: false);
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (YakuzaMode)
		{
			Frame++;
			if (Frame == 5)
			{
				StudentManager.SkipTo730();
				StudentManager.Students[97].AltTeleportToDestination();
				StudentManager.ChangeIntoTeachersPet();
				StudentManager.TeleportEveryoneToDestination();
				Yandere.IdleAnim = "f02_heroicIdle_00";
				Yandere.WalkAnim = "f02_walkConfident_00";
				Yandere.RunAnim = "f02_stealthRun_00";
				Yandere.OriginalIdleAnim = "f02_heroicIdle_00";
				Yandere.OriginalWalkAnim = "f02_walkConfident_00";
				Yandere.OriginalRunAnim = "f02_stealthRun_00";
				Yandere.CharacterAnimation.Play(Yandere.IdleAnim);
				Yandere.CharacterAnimation[Yandere.RunAnim].speed = 2f;
				Yandere.Yakuza = true;
				if (WeaponManager.Weapons[1].AnimID != 0)
				{
					WeaponManager.Weapons[1].StartingPosition = Vector3.zero;
					WeaponManager.Weapons[1].StartingRotation = Vector3.zero;
					WeaponManager.Weapons[1].AnimID = 0;
					WeaponManager.Weapons[1].Equip();
				}
				if (StudentManager.Students[1] != null)
				{
					StudentManager.Students[1].transform.position = Vector3.zero;
				}
				RequiredWeaponID = 2;
				Physics.SyncTransforms();
				Yandere.Subtitle.MurderReactions[0] = "Who are you?! You shouldn't be here!";
				Yandere.Subtitle.PetMurderReports[2] = "A dangerous-looking person is in the school!";
				Yandere.Subtitle.PetMurderReports[3] = "What?! But she was right here! Where did she go...?";
				Yandere.Subtitle.TeacherReportReactions[0] = "Lead me there!";
				Yandere.Subtitle.TeacherReportClips[0] = Yandere.Subtitle.LongestSilence;
				Yandere.Subtitle.TeacherMurderReactions[1] = "An intruder at school?!";
				Yandere.Subtitle.TeacherMurderReactions[2] = "An intruder at school?!";
				Yandere.Subtitle.TeacherMurderReactions[3] = "An intruder at school?!";
				Yandere.Subtitle.TeacherMurderReactions[4] = "An intruder at school?!";
				Yandere.Subtitle.TeacherMurderClips[1] = Yandere.Subtitle.LongestSilence;
				Yandere.Subtitle.TeacherMurderClips[2] = Yandere.Subtitle.LongestSilence;
				Yandere.Subtitle.TeacherMurderClips[3] = Yandere.Subtitle.LongestSilence;
				Yandere.Subtitle.TeacherMurderClips[4] = Yandere.Subtitle.LongestSilence;
				StudentManager.GloveList[2].gameObject.SetActive(value: false);
				StudentManager.YandereLocker.Prompt.Hide();
				StudentManager.YandereLocker.Prompt.enabled = false;
				StudentManager.YandereLocker.enabled = false;
			}
			if (WeaponManager.Weapons[1] != null)
			{
				WeaponManager.Weapons[1].Prompt.WaitTimer = 0f;
			}
		}
		if (Phase == 1)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime / 1f));
			if (Darkness.color.a != 0f)
			{
				return;
			}
			if (!Jukebox.MissionMode.isPlaying)
			{
				Jukebox.MissionMode.Play();
			}
			Speed += Time.deltaTime / 3f;
			if (!BroughtHardware)
			{
				MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, Mathf.Lerp(MainCamera.transform.position.y, TargetHeight, Time.deltaTime * Speed), MainCamera.transform.position.z);
			}
			else
			{
				MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, new Vector3(9f, 1.491756f, -96.83526f), Time.deltaTime * Speed);
			}
			if (MainCamera.transform.position.y < TargetHeight + 0.1f)
			{
				Yandere.HUD.alpha = Mathf.MoveTowards(Yandere.HUD.alpha, 1f, Time.deltaTime / 3f);
				if (Yandere.HUD.alpha == 1f)
				{
					Yandere.RPGCamera.enabled = true;
					HeartbeatCamera.SetActive(value: true);
					Yandere.CanMove = true;
					Phase++;
				}
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, TargetHeight, MainCamera.transform.position.z);
				Yandere.RPGCamera.enabled = true;
				HeartbeatCamera.SetActive(value: true);
				Yandere.CanMove = true;
				Yandere.HUD.alpha = 1f;
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 0f);
			}
		}
		else if (Phase == 2)
		{
			if (MultiMission)
			{
				for (int i = 1; i < Target.Length; i++)
				{
					if (Target[i] == 0)
					{
						Checking[i] = false;
					}
					else
					{
						if (!Checking[i])
						{
							continue;
						}
						if (StudentManager.Students[Target[i]].transform.position.y < -11f)
						{
							GameOverID = 1;
							GameOver();
							Phase = 4;
						}
						else
						{
							if (StudentManager.Students[Target[i]].Alive)
							{
								continue;
							}
							if (Method[i] == 0)
							{
								if (StudentManager.Students[Target[i]].DeathType == DeathType.Weapon)
								{
									NewMissionWindow.DeathSkulls[i].SetActive(value: true);
									Checking[i] = false;
									CheckForCompletion();
								}
								else
								{
									GameOverID = 18;
									GameOver();
									Phase = 4;
								}
							}
							else if (Method[i] == 1)
							{
								if (StudentManager.Students[Target[i]].DeathType == DeathType.Drowning)
								{
									NewMissionWindow.DeathSkulls[i].SetActive(value: true);
									Checking[i] = false;
									CheckForCompletion();
								}
								else
								{
									GameOverID = 18;
									GameOver();
									Phase = 4;
								}
							}
							else if (Method[i] == 2)
							{
								if (StudentManager.Students[Target[i]].DeathType == DeathType.Poison)
								{
									NewMissionWindow.DeathSkulls[i].SetActive(value: true);
									Checking[i] = false;
									CheckForCompletion();
								}
								else
								{
									GameOverID = 18;
									GameOver();
									Phase = 4;
								}
							}
							else if (Method[i] == 3)
							{
								if (StudentManager.Students[Target[i]].DeathType == DeathType.Electrocution)
								{
									NewMissionWindow.DeathSkulls[i].SetActive(value: true);
									Checking[i] = false;
									CheckForCompletion();
								}
								else
								{
									GameOverID = 18;
									GameOver();
									Phase = 4;
								}
							}
							else if (Method[i] == 4)
							{
								if (StudentManager.Students[Target[i]].DeathType == DeathType.Burning)
								{
									NewMissionWindow.DeathSkulls[i].SetActive(value: true);
									Checking[i] = false;
									CheckForCompletion();
								}
								else
								{
									GameOverID = 18;
									GameOver();
									Phase = 4;
								}
							}
							else if (Method[i] == 5)
							{
								if (StudentManager.Students[Target[i]].DeathType == DeathType.Falling)
								{
									NewMissionWindow.DeathSkulls[i].SetActive(value: true);
									Checking[i] = false;
									CheckForCompletion();
								}
								else
								{
									GameOverID = 18;
									GameOver();
									Phase = 4;
								}
							}
							else if (Method[i] == 6)
							{
								if (StudentManager.Students[Target[i]].DeathType == DeathType.Weight)
								{
									NewMissionWindow.DeathSkulls[i].SetActive(value: true);
									Checking[i] = false;
									CheckForCompletion();
								}
								else
								{
									GameOverID = 18;
									GameOver();
									Phase = 4;
								}
							}
						}
					}
				}
			}
			if (!TargetDead && StudentManager.Students[TargetID] != null)
			{
				AlphabetArrow.LocalArrow.LookAt(StudentManager.Students[TargetID].transform.position);
				AlphabetArrow.transform.eulerAngles = AlphabetArrow.LocalArrow.eulerAngles - new Vector3(0f, StudentManager.MainCamera.transform.eulerAngles.y, 0f);
				AlphabetArrow.gameObject.SetActive(value: true);
				if (!StudentManager.Students[TargetID].Alive)
				{
					if (Yandere.Equipped > 0)
					{
						if (StudentManager.Students[TargetID].DeathType == DeathType.Weapon)
						{
							MurderWeapon = Yandere.EquippedWeapon;
							MurderWeaponID = Yandere.EquippedWeapon.WeaponID;
						}
						else
						{
							WeaponDisposed = true;
						}
					}
					else
					{
						WeaponDisposed = true;
					}
					AlphabetArrow.gameObject.SetActive(value: false);
					TargetDead = true;
				}
				if (StudentManager.Students[TargetID].transform.position.y < -11f)
				{
					GameOverID = 1;
					GameOver();
					Phase = 4;
				}
			}
			if (RequiredWeaponID > 0 && StudentManager.Students[TargetID] != null && !StudentManager.Students[TargetID].Alive && StudentManager.Students[TargetID].DeathCause != RequiredWeaponID)
			{
				Debug.Log("Required Weapon was " + RequiredWeaponID + " and player used something else...supposedly.");
				Chastise = true;
				GameOverID = 2;
				GameOver();
				Phase = 4;
			}
			if (!CorrectClothingConfirmed && RequiredClothingID > 0 && StudentManager.Students[TargetID] != null && !StudentManager.Students[TargetID].Alive)
			{
				if (Yandere.Schoolwear != RequiredClothingID)
				{
					Debug.Log("RequiredClothingID was: " + RequiredClothingID + " and player's Schoolwear was: " + Yandere.Schoolwear);
					Chastise = true;
					GameOverID = 3;
					GameOver();
					Phase = 4;
				}
				else
				{
					CorrectClothingConfirmed = true;
				}
			}
			if (RequiredDisposalID > 0 && DisposalMethod == 0 && TargetDead)
			{
				for (ID = 1; ID < Incinerator.Victims + 1; ID++)
				{
					if (Incinerator.VictimList[ID] == TargetID && Incinerator.Smoke.isPlaying)
					{
						DisposalMethod = 1;
					}
				}
				int num = 0;
				for (ID = 1; ID < Incinerator.Limbs + 1; ID++)
				{
					if (Incinerator.LimbList[ID] == TargetID)
					{
						num++;
					}
					if (num == 6 && Incinerator.Smoke.isPlaying)
					{
						DisposalMethod = 1;
					}
				}
				for (ID = 1; ID < WoodChipper.Victims + 1; ID++)
				{
					if (WoodChipper.VictimList[ID] == TargetID && WoodChipper.Shredding)
					{
						DisposalMethod = 2;
					}
				}
				for (ID = 1; ID < GardenHoles.Length; ID++)
				{
					if (GardenHoles[ID].VictimID == TargetID && !GardenHoles[ID].enabled)
					{
						DisposalMethod = 3;
					}
				}
				for (ID = 1; ID < AcidVat.Victims + 1; ID++)
				{
					if (AcidVat.VictimList[ID] == TargetID)
					{
						DisposalMethod = 4;
					}
				}
				int num2 = 0;
				for (ID = 1; ID < AcidVat.Limbs + 1; ID++)
				{
					if (AcidVat.LimbList[ID] == TargetID)
					{
						num2++;
					}
					if (num2 == 6)
					{
						DisposalMethod = 4;
					}
				}
				for (ID = 1; ID < Manhole.Victims + 1; ID++)
				{
					if (Manhole.VictimList[ID] == TargetID)
					{
						DisposalMethod = 5;
					}
				}
				for (ID = 1; ID < Kiln.Victims + 1; ID++)
				{
					if (Kiln.VictimList[ID] == TargetID)
					{
						DisposalMethod = 6;
					}
				}
				int num3 = 0;
				for (ID = 1; ID < Kiln.Limbs + 1; ID++)
				{
					if (Kiln.LimbList[ID] == TargetID)
					{
						num3++;
					}
					if (num3 == 6)
					{
						DisposalMethod = 6;
					}
				}
				Debug.Log("Checking plant.");
				if (Plant.VictimID == TargetID)
				{
					DisposalMethod = 7;
				}
				int num4 = 0;
				for (ID = 0; ID < Plant.Limbs + 1; ID++)
				{
					if (Plant.LimbList[ID] == TargetID)
					{
						num4++;
					}
					Debug.Log(num4 + " PlantTargetLimbs counted.");
					if (num4 == 6)
					{
						DisposalMethod = 7;
					}
				}
				if (DisposalMethod > 0)
				{
					if (DisposalMethod != RequiredDisposalID)
					{
						Chastise = true;
						GameOverID = 4;
						GameOver();
						Phase = 4;
					}
					else
					{
						CorpseDisposed = true;
					}
				}
			}
			if (NoCollateral)
			{
				if (Police.Corpses == 1)
				{
					if (Police.CorpseList[0].StudentID != TargetID)
					{
						Chastise = true;
						GameOverID = 5;
						GameOver();
						Phase = 4;
					}
				}
				else if (Police.Corpses > 1)
				{
					GameOverID = 5;
					GameOver();
					Phase = 4;
				}
			}
			if (NoWitnesses)
			{
				for (ID = 1; ID < StudentManager.Students.Length; ID++)
				{
					if (StudentManager.Students[ID] != null && StudentManager.Students[ID].WitnessedMurder && !Yandere.DelinquentFighting)
					{
						GetTitle();
						SpottedLabel.text = Title + " " + StudentManager.Students[ID].Name;
						SpottedWindow.SetActive(value: true);
						Chastise = true;
						GameOverID = 6;
						if (Yandere.Mopping)
						{
							GameOverID = 20;
						}
						if (Yandere.Yakuza)
						{
							GameOverID = 22;
						}
						GameOver();
						Phase = 4;
					}
				}
			}
			if (NoCorpses)
			{
				for (ID = 1; ID < StudentManager.Students.Length; ID++)
				{
					if (StudentManager.Students[ID] != null && (StudentManager.Students[ID].WitnessedCorpse || (StudentManager.Students[ID].WitnessedMurder && !StudentManager.Students[ID].SpottedYakuza)))
					{
						GetTitle();
						SpottedLabel.text = Title + " " + StudentManager.Students[ID].Name;
						SpottedWindow.SetActive(value: true);
						Chastise = true;
						if (Yandere.DelinquentFighting)
						{
							GameOverID = 19;
						}
						else
						{
							GameOverID = 7;
						}
						GameOver();
						Phase = 4;
					}
				}
			}
			if (NoBlood)
			{
				if (Police.Deaths > 0)
				{
					CheckForBlood = true;
				}
				if (CheckForBlood)
				{
					if (Police.BloodParent.childCount == 0)
					{
						BloodTimer += Time.deltaTime;
						if (BloodTimer > 2f)
						{
							BloodCleaned = true;
						}
					}
					else
					{
						BloodTimer = 0f;
					}
				}
			}
			if (NoWeapon && !WeaponDisposed && ((MurderWeaponID > 0 && MurderWeapon == null) || (MurderWeaponID > 0 && MurderWeapon.Disposed)))
			{
				WeaponDisposed = true;
			}
			if (TimeLimit)
			{
				if (!Yandere.PauseScreen.Show)
				{
					TimeRemaining = Mathf.MoveTowards(TimeRemaining, 0f, Time.unscaledDeltaTime);
				}
				int num5 = Mathf.CeilToInt(TimeRemaining);
				int num6 = num5 / 60;
				int num7 = num5 % 60;
				TimeLabel.text = $"{num6:00}:{num7:00}";
				if (TimeRemaining == 0f)
				{
					Chastise = true;
					GameOverID = 10;
					GameOver();
					Phase = 4;
				}
			}
			if (Reputation.Reputation + Reputation.PendingRep <= -100f)
			{
				GameOverID = 14;
				GameOver();
				Phase = 4;
			}
			if (NoSuspicion && Reputation.Reputation + Reputation.PendingRep < 0f)
			{
				GameOverID = 14;
				GameOver();
				Phase = 4;
			}
			if (HeartbrokenCamera.activeInHierarchy)
			{
				HeartbrokenCamera.SetActive(value: false);
				GameOverID = 0;
				GameOver();
				Phase = 4;
			}
			if (Clock.PresentTime > 1080f)
			{
				GameOverID = 11;
				GameOver();
				Phase = 4;
			}
			else if (Police.FadeOut)
			{
				GameOverID = 12;
				GameOver();
				Phase = 4;
			}
			if (Yandere.ShoulderCamera.Noticed)
			{
				if (Yandere.Senpai.GetComponent<StudentScript>().Club == ClubType.Council)
				{
					GameOverID = 21;
				}
				else
				{
					GameOverID = 17;
				}
				GameOver();
				Phase = 4;
			}
			if (ExitPortal.activeInHierarchy)
			{
				if ((!YakuzaMode && Yandere.Chased) || (!YakuzaMode && Yandere.Chasers > 0))
				{
					ExitPortalPrompt.Label[0].text = "     Cannot Exfiltrate!";
					ExitPortalPrompt.Circle[0].fillAmount = 1f;
				}
				else
				{
					ExitPortalPrompt.Label[0].text = "     Exfiltrate";
					if (ExitPortalPrompt.Circle[0].fillAmount == 0f)
					{
						ExitPortalPrompt.Circle[0].fillAmount = 1f;
						bool flag = false;
						if (Yandere.Container != null && Yandere.Container.TrashCan.Item != null && Yandere.Container.TrashCan.Item == WeaponManager.Weapons[1].gameObject)
						{
							flag = true;
							Debug.Log("Katana is in possession!");
						}
						if ((!flag && YakuzaMode && Yandere.EquippedWeapon == null) || (!flag && YakuzaMode && Yandere.EquippedWeapon != WeaponManager.Weapons[1]))
						{
							NotificationManager.CustomText = "Can't leave without katana!";
							NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						else
						{
							if (!YakuzaMode)
							{
								Yandere.EmptyHands();
							}
							StudentManager.DisableChaseCameras();
							MainCamera.transform.position = new Vector3(0.5f, 2.25f, -100.5f);
							MainCamera.transform.eulerAngles = Vector3.zero;
							Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
							Yandere.transform.position = new Vector3(0f, 0f, -94.5f);
							if (Yandere.Chased || Yandere.Chasers > 0)
							{
								Yandere.CharacterAnimation.Play(Yandere.RunAnim);
								Run = true;
							}
							else
							{
								Yandere.CharacterAnimation.Play(Yandere.WalkAnim);
							}
							Yandere.RPGCamera.enabled = false;
							Yandere.HUD.gameObject.SetActive(value: false);
							Yandere.ResetYandereEffects();
							Yandere.YandereVision = false;
							Yandere.CanMove = false;
							Yandere.Chased = false;
							Yandere.Chasers = 0;
							if (YakuzaMode)
							{
								Jukebox.YakuzaMusic.SetActive(value: false);
								Jukebox.MissionMode.enabled = true;
								Jukebox.MissionMode.volume = 1f;
							}
							Jukebox.MissionMode.clip = StealthMusic[11];
							Jukebox.MissionMode.loop = false;
							Jukebox.MissionMode.Play();
							MyAudio.PlayOneShot(InfoAccomplished);
							Yandere.MyLocker.gameObject.SetActive(value: false);
							HeartbeatCamera.SetActive(value: false);
							Boundary.enabled = false;
							Phase++;
							if (Run)
							{
								Yandere.enabled = false;
							}
						}
					}
				}
			}
			if (TargetDead && CorpseDisposed && BloodCleaned && WeaponDisposed && DocumentsStolen && GameOverID == 0 && !ExitPortal.activeInHierarchy)
			{
				NotificationManager.DisplayNotification(NotificationType.Complete);
				NotificationManager.DisplayNotification(NotificationType.Exfiltrate);
				MyAudio.PlayOneShot(InfoExfiltrate);
				AlphabetArrow.gameObject.SetActive(value: true);
				ExitPortal.SetActive(value: true);
			}
			if (NoBlood && BloodCleaned && Police.BloodParent.childCount > 0)
			{
				ExitPortal.SetActive(value: false);
				BloodCleaned = false;
				BloodTimer = 0f;
			}
			if (!InfoRemark && GameOverID == 0 && TargetDead && (!CorpseDisposed || !BloodCleaned || !WeaponDisposed))
			{
				MyAudio.PlayOneShot(InfoObjective);
				InfoRemark = true;
			}
			if (ExitPortal.activeInHierarchy)
			{
				AlphabetArrow.LocalArrow.LookAt(new Vector3(0f, 0f, ExitPortal.transform.position.z));
				AlphabetArrow.transform.eulerAngles = AlphabetArrow.LocalArrow.transform.eulerAngles - new Vector3(0f, StudentManager.MainCamera.transform.eulerAngles.y, 0f);
			}
		}
		else if (Phase == 3)
		{
			Timer += Time.deltaTime;
			MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y - Time.deltaTime * 0.2f, MainCamera.transform.position.z);
			if (Run)
			{
				Yandere.transform.position = new Vector3(Yandere.transform.position.x, Yandere.transform.position.y, Yandere.transform.position.z - Time.deltaTime * 5f);
			}
			else
			{
				Yandere.transform.position = new Vector3(Yandere.transform.position.x, Yandere.transform.position.y, Yandere.transform.position.z - Time.deltaTime);
			}
			if (Timer > 5f)
			{
				Success();
				Timer = 0f;
				Phase++;
			}
		}
		else
		{
			if (Phase != 4)
			{
				return;
			}
			Time.timeScale = 0.0001f;
			Timer += 1f / 60f;
			if (Timer > 1f)
			{
				if (!FadeOut)
				{
					if (!PromptBar.Show)
					{
						PromptBar.Show = true;
					}
					else
					{
						GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							PromptBar.Show = false;
							Destination = 1;
							FadeOut = true;
						}
						else if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							PromptBar.Show = false;
							Destination = 2;
							FadeOut = true;
						}
						else if (Input.GetButtonDown(InputNames.Xbox_X))
						{
							PromptBar.Show = false;
							Destination = 3;
							FadeOut = true;
						}
					}
				}
				else
				{
					Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, 1f / 60f));
					Jukebox.Dip = Mathf.MoveTowards(Jukebox.Dip, 0f, 1f / 60f);
					if (Darkness.color.a > 127f / 128f)
					{
						if (Destination == 1)
						{
							if (Eighties)
							{
								EightiesLoadingLabel.enabled = true;
							}
							else
							{
								ModernLoadingLabel.enabled = true;
							}
							if (EndFrame > 0)
							{
								ResetGlobals();
								if (Eighties)
								{
									DateGlobals.Week = 10;
									for (int j = 1; j < 101; j++)
									{
										StudentGlobals.SetStudentPhotographed(j, value: true);
										StudentManager.StudentPhotographed[j] = true;
									}
								}
								SceneManager.LoadScene(SceneManager.GetActiveScene().name);
							}
							else
							{
								Debug.Log("Counting frames. Now on Frame #" + EndFrame);
							}
							EndFrame++;
						}
						else if (Destination == 2)
						{
							Globals.DeleteAll();
							SceneManager.LoadScene("MissionModeScene");
						}
						else if (Destination == 3)
						{
							Globals.DeleteAll();
							SceneManager.LoadScene("NewTitleScene");
						}
						else if (Destination == 4)
						{
							Globals.DeleteAll();
							SceneManager.LoadScene("DiscordScene");
						}
					}
				}
			}
			if (GameOverPhase == 1)
			{
				if (Timer > 2.5f)
				{
					if (Chastise)
					{
						MyAudio.PlayOneShot(InfoFailure);
						GameOverPhase++;
					}
					else
					{
						GameOverPhase++;
						Timer += 5f;
					}
				}
			}
			else if (GameOverPhase == 2 && Timer > 7.5f)
			{
				Jukebox.MissionMode.clip = Failure;
				Jukebox.MissionMode.Play();
				Jukebox.Volume = 0.5f;
				GameOverPhase++;
			}
		}
	}

	public void GameOver()
	{
		if (Yandere.Aiming)
		{
			Yandere.StopAiming();
		}
		if (Yandere.YandereVision)
		{
			Yandere.YandereVision = false;
			Yandere.ResetYandereEffects();
		}
		Yandere.AttackManager.enabled = false;
		Yandere.enabled = false;
		GameOverReason.text = GameOverReasons[GameOverID];
		Fire.enabled = true;
		MyAudio.PlayOneShot(GameOverSound);
		DetectionCamera.SetActive(value: false);
		HeartbeatCamera.SetActive(value: false);
		WitnessCamera.SetActive(value: false);
		GameOverText.SetActive(value: true);
		Yandere.HUD.gameObject.SetActive(value: false);
		Subtitle.SetActive(value: false);
		Time.timeScale = 0.0001f;
		GameOverPhase = 1;
		Jukebox.MissionMode.Stop();
		Jukebox.YakuzaMusic.SetActive(value: false);
	}

	private void Success()
	{
		while (!Valid)
		{
			RandomNumber = Random.Range(1000000, 10000000);
			if (RandomNumber / 9f % 5f == 0f)
			{
				Valid = true;
			}
		}
		DiscordCodeLabel.text = RandomNumber.ToString() ?? "";
		DiscordCodeLabel.transform.parent.gameObject.SetActive(value: true);
		GameOverHeader.transform.localPosition = new Vector3(GameOverHeader.transform.localPosition.x, 0f, GameOverHeader.transform.localPosition.z);
		GameOverHeader.text = "MISSION ACCOMPLISHED";
		GameOverReason.gameObject.SetActive(value: false);
		DetectionCamera.SetActive(value: false);
		WitnessCamera.SetActive(value: false);
		GameOverText.SetActive(value: true);
		GameOverReason.text = string.Empty;
		Subtitle.SetActive(value: false);
		Jukebox.Volume = 1f;
		Time.timeScale = 0.0001f;
		Fire.enabled = true;
		if (Difficulty == 10 && !GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Mission", 1);
			PlayerPrefs.SetInt("a", 1);
		}
	}

	public void ChangeMusic()
	{
		MusicID++;
		if (MusicID > 10)
		{
			if (Eighties)
			{
				MusicID = 0;
			}
			else
			{
				MusicID = 1;
			}
		}
		Jukebox.MissionMode.clip = StealthMusic[MusicID];
		Jukebox.MissionMode.Play();
	}

	private void ResetGlobals()
	{
		Debug.Log("Mission Difficulty was: " + MissionModeGlobals.MissionDifficulty);
		int disableFarAnimations = OptionGlobals.DisableFarAnimations;
		bool disablePostAliasing = OptionGlobals.DisablePostAliasing;
		bool disableOutlines = OptionGlobals.DisableOutlines;
		int lowDetailStudents = OptionGlobals.LowDetailStudents;
		int particleCount = OptionGlobals.ParticleCount;
		bool enableShadows = OptionGlobals.EnableShadows;
		int drawDistance = OptionGlobals.DrawDistance;
		int drawDistanceLimit = OptionGlobals.DrawDistanceLimit;
		bool disableBloom = OptionGlobals.DisableBloom;
		bool fog = OptionGlobals.Fog;
		bool nemesisAggression = MissionModeGlobals.NemesisAggression;
		string missionTargetName = MissionModeGlobals.MissionTargetName;
		bool highPopulation = OptionGlobals.HighPopulation;
		Globals.DeleteAll();
		OptionGlobals.TutorialsOff = true;
		for (int i = 1; i < 11; i++)
		{
			PlayerPrefs.SetInt("MissionModeTarget" + i, Target[i]);
			PlayerPrefs.SetInt("MissionModeMethod" + i, Method[i]);
		}
		SchoolGlobals.SchoolAtmosphere = 1f - (float)Difficulty * 0.1f;
		MissionModeGlobals.MissionTargetName = missionTargetName;
		MissionModeGlobals.MissionDifficulty = Difficulty;
		OptionGlobals.HighPopulation = highPopulation;
		MissionModeGlobals.MissionTarget = TargetID;
		SchoolGlobals.SchoolAtmosphereSet = true;
		MissionModeGlobals.MissionMode = true;
		MissionModeGlobals.MultiMission = MultiMission;
		MissionModeGlobals.MissionRequiredWeapon = RequiredWeaponID;
		MissionModeGlobals.MissionRequiredClothing = RequiredClothingID;
		MissionModeGlobals.MissionRequiredDisposal = RequiredDisposalID;
		ClassGlobals.BiologyGrade = 1;
		ClassGlobals.ChemistryGrade = 1;
		ClassGlobals.LanguageGrade = 1;
		ClassGlobals.PhysicalGrade = 1;
		ClassGlobals.PsychologyGrade = 1;
		for (ID = 2; ID < 11; ID++)
		{
			MissionModeGlobals.SetMissionCondition(ID, Conditions[ID]);
		}
		MissionModeGlobals.NemesisDifficulty = NemesisDifficulty;
		MissionModeGlobals.NemesisAggression = nemesisAggression;
		OptionGlobals.DisableFarAnimations = disableFarAnimations;
		OptionGlobals.DisablePostAliasing = disablePostAliasing;
		OptionGlobals.DisableOutlines = disableOutlines;
		OptionGlobals.LowDetailStudents = lowDetailStudents;
		OptionGlobals.ParticleCount = particleCount;
		OptionGlobals.EnableShadows = enableShadows;
		OptionGlobals.DrawDistance = drawDistance;
		OptionGlobals.DrawDistanceLimit = drawDistanceLimit;
		OptionGlobals.DisableBloom = disableBloom;
		OptionGlobals.Fog = fog;
		if (RequiredWeaponID == 31)
		{
			PlayerGlobals.BringingHardware = 9;
		}
		else if (RequiredWeaponID == 44)
		{
			PlayerGlobals.BringingHardware = 2;
		}
		else if (RequiredWeaponID == 45)
		{
			PlayerGlobals.BringingHardware = 6;
		}
		else if (RequiredWeaponID == 46)
		{
			PlayerGlobals.BringingHardware = 8;
		}
		Debug.Log("Mission Difficulty is now: " + MissionModeGlobals.MissionDifficulty);
	}

	private void ChangeAllText()
	{
		UILabel[] array = Object.FindObjectsOfType<UILabel>();
		foreach (UILabel obj in array)
		{
			float a = obj.color.a;
			obj.color = new Color(1f, 1f, 1f, a);
			obj.trueTypeFont = Arial;
		}
		UISprite[] array2 = Object.FindObjectsOfType<UISprite>();
		foreach (UISprite uISprite in array2)
		{
			float a2 = uISprite.color.a;
			if (uISprite.color != new Color(0f, 0f, 0f, a2))
			{
				uISprite.color = new Color(1f, 1f, 1f, a2);
			}
		}
	}

	private void CheckForCompletion()
	{
		if (!Checking[1] && !Checking[2] && !Checking[3] && !Checking[4] && !Checking[5] && !Checking[6] && !Checking[7] && !Checking[8] && !Checking[9] && !Checking[10])
		{
			TargetDead = true;
		}
	}

	public void RemoveBoxes()
	{
		for (int i = 1; i < CardboardBoxes.Length; i++)
		{
			CardboardBoxes[i].SetActive(value: false);
		}
	}

	public void GetTitle()
	{
		if (ID == 90)
		{
			Title = "Nurse";
		}
		else if (ID == 97)
		{
			Title = "Coach";
		}
		else if (StudentManager.Students[ID].Teacher)
		{
			Title = "Teacher";
		}
		else
		{
			Title = "Student";
		}
	}

	public void UpdateStudentsPhotographed()
	{
		for (int i = 1; i < 11; i++)
		{
			Target[i] = PlayerPrefs.GetInt("MissionModeTarget" + i);
			Method[i] = PlayerPrefs.GetInt("MissionModeMethod" + i);
			StudentManager.StudentPhotographed[Target[i]] = true;
			if (Target[i] > 0)
			{
				Debug.Log("One of the targets is Student #" + Target[i] + ", so we are setting StudentManager.StudentPhotographed[" + Target[i] + "] to " + StudentManager.StudentPhotographed[Target[i]]);
				StudentManager.Students[Target[i]].MissionModeTarget = true;
			}
		}
	}
}
