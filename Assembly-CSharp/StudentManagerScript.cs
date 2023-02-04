using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StudentManagerScript : MonoBehaviour
{
	private PortraitChanScript NewPortraitChan;

	private GameObject NewStudent;

	public StudentScript[] Students;

	public OsanaThursdayAfterClassEventScript OsanaThursdayAfterClassEvent;

	public SpawnedObjectManagerScript SpawnedObjectManager;

	public SelectiveGrayscale SmartphoneSelectiveGreyscale;

	public PickpocketMinigameScript PickpocketMinigame;

	public FindStudentLockerScript FindStudentLocker;

	public PopulationManagerScript PopulationManager;

	public SelectiveGrayscale HandSelectiveGreyscale;

	public KokonaTutorialScript KokonaTutorialObject;

	public ReputationSetterScript ReputationSetter;

	public SkinnedMeshRenderer FemaleShowerCurtain;

	public CleaningManagerScript CleaningManager;

	public GenericRivalBagScript GenericRivalBag;

	public StolenPhoneSpotScript StolenPhoneSpot;

	public SelectiveGrayscale SelectiveGreyscale;

	public InterestManagerScript InterestManager;

	public OpinionsLearnedScript OpinionsLearned;

	public CombatMinigameScript CombatMinigame;

	public DatingMinigameScript DatingMinigame;

	public SnappedYandereScript SnappedYandere;

	public TextureManagerScript TextureManager;

	public TutorialWindowScript TutorialWindow;

	public QualityManagerScript QualityManager;

	public GenericRivalBagScript RivalBookBag;

	public ComputerGamesScript ComputerGames;

	public DialogueWheelScript DialogueWheel;

	public EmergencyExitScript EmergencyExit;

	public MemorialSceneScript MemorialScene;

	public TranqDetectorScript TranqDetector;

	public WitnessCameraScript WitnessCamera;

	public ConvoManagerScript ConvoManager;

	public TallLockerScript CommunalLocker;

	public PuddleParentScript PuddleParent;

	public BloodParentScript BloodParent;

	public CabinetDoorScript CabinetDoor;

	public ClubManagerScript ClubManager;

	public LightSwitchScript LightSwitch;

	public LoveManagerScript LoveManager;

	public MiyukiEnemyScript MiyukiEnemy;

	public TaskManagerScript TaskManager;

	public WaterCoolerScript WaterCooler;

	public StudentScript MindBrokenSlave;

	public Collider MaleLockerRoomArea;

	public StudentScript BloodReporter;

	public HeadmasterScript Headmaster;

	public NoteWindowScript NoteWindow;

	public ReputationScript Reputation;

	public WeaponScript FragileWeapon;

	public AudioSource PracticeVocals;

	public AudioSource PracticeMusic;

	public ContainerScript Container;

	public RedStringScript RedString;

	public RingEventScript RingEvent;

	public RivalPoseScript RivalPose;

	public GazerEyesScript Shinigami;

	public ParticleSystem PyroFlames;

	public HologramScript Holograms;

	public RobotArmScript RobotArms;

	public TrashCanScript WeaponBag;

	public AlphabetScript Alphabet;

	public FanCoverScript FanCover;

	public PickUpScript Flashlight;

	public FountainScript Fountain;

	public PoseModeScript PoseMode;

	public TutorialScript Tutorial;

	public Collider LockerRoomArea;

	public PickUpScript FoodPlate;

	public StudentScript Reporter;

	public BookbagScript BookBag;

	public DoorScript GamingDoor;

	public GhostScript GhostChan;

	public SchemesScript Schemes;

	public TributeScript Tribute;

	public YandereScript Yandere;

	public ListScript MeetSpots;

	public MirrorScript Mirror;

	public PoliceScript Police;

	public DoorScript ShedDoor;

	public UILabel ErrorLabel;

	public RestScript Rest;

	public TagScript Tag;

	public UISprite HUD;

	public Collider EastBathroomArea;

	public Collider WestBathroomArea;

	public Collider IncineratorArea;

	public Collider HeadmasterArea;

	public Collider GardenArea;

	public Collider PoolStairs;

	public Collider TreeArea;

	public Collider NEStairs;

	public Collider NWStairs;

	public Collider SEStairs;

	public Collider SWStairs;

	public DoorScript AltFemaleVomitDoor;

	public DoorScript FemaleVomitDoor;

	public CounselorDoorScript[] CounselorDoor;

	public ParticleSystem AltFemaleDrownSplashes;

	public ParticleSystem FemaleDrownSplashes;

	public OfferHelpScript EightiesOfferHelp;

	public OfferHelpScript FragileOfferHelp;

	public OfferHelpScript OsanaOfferHelp;

	public OfferHelpScript OfferHelp;

	public Transform MaleLockerRoomChangingSpot;

	public Transform SukebanHangoutParent;

	public Transform AltFemaleVomitSpot;

	public Transform RaibaruMentorSpot;

	public Transform SleepSpot;

	public Transform PyroSpot;

	public ListScript EightiesSpots;

	public ListScript SearchPatrols;

	public ListScript CleaningSpots;

	public ListScript Patrols;

	public ClockScript Clock;

	public JsonScript JSON;

	public GateScript Gate;

	public ListScript LunchWitnessPositions;

	public ListScript EntranceVectors;

	public ListScript ShowerLockers;

	public ListScript Week1Hangouts;

	public ListScript Week2Hangouts;

	public ListScript GoAwaySpots;

	public ListScript HidingSpots;

	public ListScript LunchSpots;

	public ListScript Stairways;

	public ListScript Hangouts;

	public ListScript Lockers;

	public ListScript Podiums;

	public ListScript Clubs;

	public ListScript EightiesLunchSpots;

	public ListScript EightiesHangouts;

	public ListScript EightiesPatrols;

	public ListScript EightiesClubs;

	public BodyHidingLockerScript[] BodyHidingLockers;

	public ChangingBoothScript[] ChangingBooths;

	public SelectiveGrayscale[] SpyGrayscales;

	public GradingPaperScript[] FacultyDesks;

	public DynamicBone[] AllDynamicBones;

	public AudioSource[] PyroFlameSounds;

	public ListScript[] InterestsLearned;

	public StudentScript[] WitnessList;

	public TrashCanScript[] TrashCans;

	public StudentScript[] Teachers;

	public GloveScript[] GloveList;

	public ListScript[] Seats;

	public BugScript[] Bugs;

	public Collider[] Blood;

	public Collider[] Limbs;

	public Transform[] TeacherGuardLocation;

	public Transform[] CorpseGuardLocation;

	public Transform[] PossibleRandomSpots;

	public Transform[] BloodGuardLocation;

	public Transform[] SleuthDestinations;

	public Transform[] StrippingPositions;

	public Transform[] FemaleCoupleSpots;

	public Transform[] GardeningPatrols;

	public Transform[] MartialArtsSpots;

	public Transform[] PopularGirlSpots;

	public Transform[] LockerPositions;

	public Transform[] MaleCoupleSpots;

	public Transform[] PhotoShootSpots;

	public Transform[] RivalGuardSpots;

	public Transform[] BackstageSpots;

	public Transform[] SpawnPositions;

	public Transform[] GraffitiSpots;

	public Transform[] PracticeSpots;

	public Transform[] SunbatheSpots;

	public Transform[] MeetingSpots;

	public Transform[] PerformSpots;

	public Transform[] PinDownSpots;

	public Transform[] ShockedSpots;

	public Transform[] SukebanSpots;

	public Transform[] FridaySpots;

	public Transform[] MiyukiSpots;

	public Transform[] RandomSpots;

	public Transform[] SocialSeats;

	public Transform[] SocialSpots;

	public Transform[] SupplySpots;

	public Transform[] BullySpots;

	public Transform[] DramaSpots;

	public Transform[] MournSpots;

	public Transform[] ClubZones;

	public Transform[] FleeSpots;

	public Transform[] FoodTrays;

	public Transform[] SulkSpots;

	public Transform[] WaitSpots;

	public Transform[] Uniforms;

	public Transform[] Plates;

	public Transform[] FemaleVomitSpots;

	public Transform[] MaleVomitSpots;

	public Transform[] FemaleWashSpots;

	public Transform[] MaleWashSpots;

	public GameObject[] ShrineCollectibles;

	public GameObject[] GarbageBagList;

	public GameObject[] Graffiti;

	public GameObject[] Canvas;

	public DoorScript[] FemaleToiletDoors;

	public DoorScript[] MaleToiletDoors;

	public DrinkingFountainScript[] DrinkingFountains;

	public Renderer[] FridayPaintings;

	public bool[] StudentPhotographed;

	public bool[] PantyShotTaken;

	public bool[] SeatsTaken11;

	public bool[] SeatsTaken12;

	public bool[] SeatsTaken21;

	public bool[] SeatsTaken22;

	public bool[] SeatsTaken31;

	public bool[] SeatsTaken32;

	public bool[] NoBully;

	public Quaternion[] OriginalClubRotations;

	public Vector3[] OriginalClubPositions;

	public Collider RivalDeskCollider;

	public Transform FollowerLookAtTarget;

	public Transform SuitorConfessionSpot;

	public Transform RivalConfessionSpot;

	public Transform OriginalLyricsSpot;

	public Transform EightiesLyricDesk;

	public Transform FragileSlaveSpot;

	public Transform FemaleCoupleSpot;

	public Transform LookTargetParent;

	public Transform YandereStripSpot;

	public Transform FemaleBatheSpot;

	public Transform FemaleStalkSpot;

	public Transform FemaleStripSpot;

	public Transform FemaleVomitSpot;

	public Transform MedicineCabinet;

	public Transform PyroWateringCan;

	public Transform ConfessionSpot;

	public Transform CorpseLocation;

	public Transform FemaleWashSpot;

	public Transform MaleCoupleSpot;

	public Transform LastKnownOsana;

	public Transform AirGuitarSpot;

	public Transform BloodLocation;

	public Transform FastBatheSpot;

	public Transform InfirmarySeat;

	public Transform MaleBatheSpot;

	public Transform MaleStalkSpot;

	public Transform MaleStripSpot;

	public Transform MaleVomitSpot;

	public Transform SacrificeSpot;

	public Transform WeaponBoxSpot;

	public Transform FountainSpot;

	public Transform MaleWashSpot;

	public Transform SenpaiLocker;

	public Transform SuitorLocker;

	public Transform RomanceSpot;

	public Transform BrokenSpot;

	public Transform BullyGroup;

	public Transform EdgeOfGrid;

	public Transform GoAwaySpot;

	public Transform LyricsSpot;

	public Transform MainCamera;

	public Transform SuitorSpot;

	public Transform ToolTarget;

	public Transform MiyukiCat;

	public Transform ShameSpot;

	public Transform SlaveSpot;

	public Transform Papers;

	public Transform Exit;

	public Transform[] FemaleRestSpots;

	public Transform[] MaleRestSpots;

	public GameObject ModernRivalBookBag;

	public GameObject DelinquentVoices;

	public GameObject LovestruckCamera;

	public GameObject WednesdayGiftBox;

	public GameObject DelinquentRadio;

	public GameObject FridayTestNotes;

	public GameObject EndingCutscene;

	public GameObject GardenBlockade;

	public GameObject FPSDisplayBG;

	public GameObject PortraitChan;

	public GameObject RandomPatrol;

	public GameObject ChaseCamera;

	public GameObject EmptyObject;

	public GameObject MondayBento;

	public GameObject PortraitKun;

	public GameObject StudentChan;

	public GameObject FPSDisplay;

	public GameObject StudentKun;

	public GameObject RivalChan;

	public GameObject BakeSale;

	public GameObject Canvases;

	public GameObject Medicine;

	public GameObject DrumSet;

	public GameObject Flowers;

	public GameObject Portal;

	public GameObject Gift;

	public GameObject Note;

	public float[] SpawnTimes;

	public int InitialSabotageProgress;

	public int LowDetailThreshold;

	public int FarAnimThreshold;

	public int MartialArtsPhase;

	public int OriginalUniforms = 2;

	public int SabotageProgress;

	public int StudentsSpawned;

	public int SedatedStudents;

	public int StudentsTotal = 13;

	public int TeachersTotal = 6;

	public int Photographers;

	public int GirlsSpawned;

	public int TagStudentID;

	public int GarbageBags;

	public int NewUniforms;

	public int NPCsSpawned;

	public int SleuthPhase = 1;

	public int DramaPhase = 1;

	public int NPCsTotal;

	public int WeekLimit = 2;

	public int Witnesses;

	public int PinPhase;

	public int Bullies;

	public int Speaker = 21;

	public int Frame;

	public int Bones;

	public int Week;

	public int GymTeacherID = 100;

	public int ObstacleID = 6;

	public int CurrentID;

	public int SuitorID = 13;

	public int BucketID;

	public int VictimID;

	public int NurseID = 93;

	public int RivalID = 7;

	public int SpawnID;

	public int GloveID;

	public int ID;

	public bool RaibaruKnowsAboutStalker;

	public bool DisableRivalDeathSloMo;

	public bool ReplaceSparringPartner;

	public bool ReactedToGameLeader;

	public bool UnequipImmediately;

	public bool EmbarassingSecret;

	public bool MurderTakingPlace;

	public bool ControllerShrink;

	public bool EightiesTutorial;

	public bool GasInWateringCan;

	public bool ReturnedFromSave;

	public bool DisableFarAnims;

	public bool GameOverIminent;

	public bool RivalEliminated;

	public bool TakingPortraits;

	public bool TeachersSpawned;

	public bool KokonaTutorial;

	public bool MetalDetectors;

	public bool RecordingVideo;

	public bool TutorialActive;

	public bool YandereVisible;

	public bool CanSelfReport;

	public bool NoClubMeeting;

	public bool CameFromLoad;

	public bool UpdatedBlood;

	public bool YandereDying;

	public bool FirstUpdate;

	public bool MissionMode;

	public bool OpenCurtain;

	public bool PinningDown;

	public bool RoofFenceUp;

	public bool SpawnNobody;

	public bool YandereLate;

	public bool EmptyDemon;

	public bool ForceSpawn;

	public bool LoadedSave;

	public bool PoolClosed;

	public bool NoGravity;

	public bool Randomize;

	public bool Eighties;

	public bool LoveSick;

	public bool NoSpeech;

	public bool Meeting;

	public bool Jammed;

	public bool Spooky;

	public bool Bully;

	public bool Ebola;

	public bool Gaze;

	public bool Pose;

	public bool Sans;

	public bool Stop;

	public bool Egg;

	public bool Six;

	public bool AoT;

	public bool DK;

	public float Atmosphere;

	public float OpenValue = 100f;

	public float YandereHeight = 999f;

	public float MeetingTimer;

	public float PinDownTimer;

	public float ChangeTimer;

	public float SleuthTimer;

	public float DramaTimer;

	public float GrowTimer;

	public float LowestRep;

	public float PinTimer;

	public float Timer;

	public float[] StudentReps;

	public string[] ColorNames;

	public string[] MaleNames;

	public string[] FirstNames;

	public string[] LastNames;

	public float[] TargetSize;

	public int[] SuitorIDs;

	public AudioSource[] FountainAudio;

	public AudioClip YanderePinDown;

	public AudioClip PinDownSFX;

	[SerializeField]
	private int ProblemID = -1;

	public GameObject Cardigan;

	public SkinnedMeshRenderer CardiganRenderer;

	public Mesh OpenChipBag;

	public Vignetting[] Vignettes;

	public Renderer[] Trees;

	public DoorScript[] AllDoors;

	public BucketScript[] AllBuckets;

	public OcclusionPortal BehindSchoolOccluder;

	public OcclusionPortal PlazaOccluder;

	public AudioClip SlidingDoorOpen;

	public AudioClip SlidingDoorShut;

	public AudioClip SwingingDoorOpen;

	public AudioClip SwingingDoorShut;

	public PickUpScript[] AllPickUps;

	public int PickUpID;

	public RadioScript Radio;

	public bool SeatOccupied;

	public int Class = 1;

	public int Thins;

	public int Seriouses;

	public int Rounds;

	public int Sads;

	public int Means;

	public int Smugs;

	public int Gentles;

	public int Rival1s;

	public DoorScript[] Doors;

	public int DoorID;

	private int OpenedDoors;

	private int SnappedStudents = 1;

	public Texture PureWhite;

	public Transform[] BullySnapPosition;

	public OcclusionPortal WindowOccluder;

	public bool TransparentWindows;

	public bool TransWindows;

	public Renderer Window;

	private ScheduleBlock scheduleBlock;

	public OsanaPoolEventScript OsanaPoolEvent;

	public bool[] HeadmasterTapesCollected;

	public bool[] PantiesCollected;

	public bool[] MangaCollected;

	public bool[] TapesCollected;

	public SkinnedMeshRenderer LandLinePhone;

	public PostProcessingBehaviour Profile;

	public Light HauntedBathroomLight;

	public GameObject OutOfOrderSign;

	public Transform LandLineSpot;

	public UILabel EventSubtitle;

	public string EightiesPrefix;

	public Texture EightiesBG;

	public UITexture PhotoBG;

	public Font Arial;

	public Font VCR;

	public RectTransform FPS;

	public RectTransform FPSValue;

	public GameObject ModernDayPropsLMC;

	public GameObject ModernDayRoomLMC;

	public GameObject EightiesPropsLMC;

	public GameObject EightiesRoomLMC;

	public GameObject NewspaperClubProps;

	public GameObject NewspaperClubRoom;

	public GameObject InfoClubProps;

	public GameObject InfoClubRoom;

	public GameObject ModernDayScienceClub;

	public GameObject ModernDayScienceProps;

	public GameObject EightiesScienceClub;

	public GameObject EightiesScienceProps;

	public GameObject[] ModernDayProps;

	public GameObject[] EightiesProps;

	public GameObject IdolStage;

	public GameObject PoolPhotoShootCameras;

	public GameObject Journalist;

	public UIPanel FreeFloatingPanel;

	public bool[] RivalKilledSelf;

	public PantyListScript PantyList;

	public bool AttackPromptActive;

	public int MeetStudentID;

	public float MeetTime;

	public int MeetID;

	public Collider EastFemaleBathroomCollider;

	public Collider WestFemaleBathroomCollider;

	public Collider EastMaleBathroomCollider;

	public Collider WestMaleBathroomCollider;

	public Transform DisabledObjectParent;

	public GameObject Whistle;

	public GameObject MiniMap;

	private void Awake()
	{
		if (!TakingPortraits && !GameGlobals.Eighties && DateGlobals.Week > WeekLimit)
		{
			Debug.Log("We're not in 1980s Mode and Week is " + DateGlobals.Week + " so we're resetting the week to ''0'' and booting the player out.");
			DateGlobals.Week = 0;
			SceneManager.LoadScene("VeryFunScene");
		}
	}

	private void Start()
	{
		DisableRivalDeathSloMo = OptionGlobals.RivalDeathSlowMo;
		EightiesTutorial = GameGlobals.EightiesTutorial;
		MissionMode = MissionModeGlobals.MissionMode;
		KokonaTutorial = GameGlobals.KokonaTutorial;
		EmptyDemon = GameGlobals.EmptyDemon;
		Week = DateGlobals.Week;
		if (GameGlobals.Eighties)
		{
			Become1989();
		}
		else
		{
			for (int i = 2; i < 11; i++)
			{
				SuitorIDs[i] = 0;
			}
			PortraitChan = StudentChan;
			PortraitKun = StudentKun;
			if (IdolStage != null)
			{
				IdolStage.SetActive(value: false);
			}
			GameObject[] modernDayProps = ModernDayProps;
			foreach (GameObject gameObject in modernDayProps)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(value: true);
				}
			}
			modernDayProps = EightiesProps;
			foreach (GameObject gameObject2 in modernDayProps)
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(value: false);
				}
			}
			if (!TakingPortraits)
			{
				InfoClubRoom.SetActive(value: true);
				InfoClubProps.SetActive(value: true);
				ModernDayScienceClub.SetActive(value: true);
				ModernDayScienceProps.SetActive(value: true);
				ModernDayPropsLMC.SetActive(value: true);
				ModernDayRoomLMC.SetActive(value: true);
				NewspaperClubProps.SetActive(value: false);
				NewspaperClubRoom.SetActive(value: false);
				EightiesPropsLMC.SetActive(value: false);
				EightiesRoomLMC.SetActive(value: false);
				EightiesScienceClub.SetActive(value: false);
				EightiesScienceProps.SetActive(value: false);
			}
			SuitorID = 6;
		}
		if (KokonaTutorial || EightiesTutorial || Week > 10)
		{
			Debug.Log("KokonaTutorial is: " + KokonaTutorial);
			SpawnNobody = true;
			if (Week > 10)
			{
				RivalBookBag.gameObject.SetActive(value: false);
				Tutorial.gameObject.SetActive(value: false);
				Yandere.enabled = false;
				EndingCutscene.SetActive(value: true);
				Yandere.MainCamera.gameObject.SetActive(value: false);
				Clock.transform.parent = FreeFloatingPanel.transform;
				Yandere.HUD.transform.parent.gameObject.SetActive(value: false);
			}
			if (EightiesTutorial && Tutorial != null)
			{
				Tutorial.gameObject.SetActive(value: false);
			}
			else if (KokonaTutorial && KokonaTutorialObject != null)
			{
				KokonaTutorialObject.gameObject.SetActive(value: true);
			}
		}
		InitialSabotageProgress = DatingGlobals.RivalSabotaged;
		SabotageProgress = InitialSabotageProgress;
		LoadCollectibles();
		LoadReps();
		EmbarassingSecret = SchemeGlobals.EmbarassingSecret;
		if (!ConversationGlobals.GetTopicDiscovered(1))
		{
			for (ID = 1; ID < 26; ID++)
			{
				ConversationGlobals.SetTopicDiscovered(ID, value: true);
			}
		}
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			ReturnedFromSave = true;
		}
		if (GameGlobals.RivalEliminationID > 0)
		{
			ModernRivalBookBag.SetActive(value: false);
			RivalEliminated = true;
		}
		RivalID = Week + 10;
		StudentGlobals.SetStudentPhotographed(RivalID, value: true);
		StudentPhotographed[RivalID] = true;
		if (Police != null)
		{
			Police.EndOfDay.LearnedOsanaInfo1 = EventGlobals.OsanaEvent1;
			Police.EndOfDay.LearnedOsanaInfo2 = EventGlobals.OsanaEvent2;
			Police.EndOfDay.LearnedAboutPhotographer = EventGlobals.LearnedAboutPhotographer;
		}
		LoveSick = GameGlobals.LoveSick;
		MetalDetectors = SchoolGlobals.HighSecurity;
		RoofFenceUp = SchoolGlobals.RoofFence;
		if (Schemes != null)
		{
			Schemes.HUDIcon.gameObject.SetActive(value: false);
			Schemes.HUDInstructions.text = string.Empty;
			Schemes.SchemeManager.CurrentScheme = 0;
			Schemes.NextStepInput.SetActive(value: false);
			SchemeGlobals.CurrentScheme = 0;
		}
		if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
		{
			SpawnPositions[51].position = new Vector3(3f, 0f, -95f);
		}
		if (Eighties && Week > 1)
		{
			SpawnPositions[94].position = FacultyDesks[1].Chair.position;
			SpawnPositions[94].rotation = FacultyDesks[1].Chair.rotation;
		}
		if (HomeGlobals.LateForSchool)
		{
			YandereLate = true;
			Debug.Log("Yandere-chan is late for school!");
		}
		if (GameGlobals.Profile == 0)
		{
			GameGlobals.Profile = 1;
			PlayerGlobals.Money = 10f;
		}
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			int profile = GameGlobals.Profile;
			int @int = PlayerPrefs.GetInt("SaveSlot");
			StudentGlobals.MemorialStudents = PlayerPrefs.GetInt("Profile_" + profile + "_Slot_" + @int + "_MemorialStudents");
		}
		if (!GameGlobals.ReputationsInitialized)
		{
			GameGlobals.ReputationsInitialized = true;
			InitializeReputations();
		}
		for (ID = 76; ID < 81; ID++)
		{
			if (StudentReps[ID] > -67f)
			{
				StudentReps[ID] = -67f;
			}
		}
		if (ClubGlobals.GetClubClosed(ClubType.Gardening))
		{
			GardenBlockade.SetActive(value: true);
			Flowers.SetActive(value: false);
		}
		ID = 0;
		for (ID = 1; ID < JSON.Students.Length; ID++)
		{
			if (!JSON.Students[ID].Success)
			{
				ProblemID = ID;
				break;
			}
		}
		if (!TakingPortraits)
		{
			if (FridayPaintings.Length != 0)
			{
				for (ID = 1; ID < FridayPaintings.Length; ID++)
				{
					FridayPaintings[ID].material.color = new Color(1f, 1f, 1f, 0f);
				}
			}
			DatingMinigame.Start();
		}
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			if (Canvases != null)
			{
				Canvases.SetActive(value: false);
			}
		}
		else if (Week == 1 && ClubGlobals.GetClubClosed(ClubType.Art))
		{
			Canvases.SetActive(value: false);
		}
		if (ProblemID != -1)
		{
			if (ErrorLabel != null)
			{
				ErrorLabel.text = string.Empty;
				ErrorLabel.enabled = false;
			}
			if (MissionMode)
			{
				StudentGlobals.FemaleUniform = 5;
				StudentGlobals.MaleUniform = 5;
				RedString.gameObject.SetActive(value: false);
			}
			SetAtmosphere();
			GameGlobals.Paranormal = false;
			if (StudentGlobals.StudentSlave > 0 && !StudentGlobals.GetStudentDead(StudentGlobals.StudentSlave))
			{
				int studentSlave = StudentGlobals.StudentSlave;
				ForceSpawn = true;
				SpawnPositions[studentSlave] = SlaveSpot;
				SpawnID = studentSlave;
				StudentGlobals.SetStudentDead(studentSlave, value: false);
				SpawnStudent(SpawnID);
				Students[studentSlave].Slave = true;
				SpawnID = 0;
			}
			if (StudentGlobals.FragileSlave > 0)
			{
				if (!StudentGlobals.GetStudentDead(StudentGlobals.FragileSlave))
				{
					int fragileSlave = StudentGlobals.FragileSlave;
					ForceSpawn = true;
					SpawnPositions[fragileSlave] = FragileSlaveSpot;
					SpawnID = fragileSlave;
					StudentGlobals.SetStudentDead(fragileSlave, value: false);
					SpawnStudent(SpawnID);
					Students[fragileSlave].FragileSlave = true;
					Students[fragileSlave].Slave = true;
					SpawnID = 0;
				}
			}
			else if (FragileWeapon != null)
			{
				FragileWeapon.gameObject.SetActive(value: false);
			}
			NPCsTotal = StudentsTotal + TeachersTotal;
			SpawnID = 1;
			if (StudentGlobals.MaleUniform == 0)
			{
				StudentGlobals.MaleUniform = 1;
			}
			for (ID = 1; ID < NPCsTotal + 1; ID++)
			{
				if (!StudentGlobals.GetStudentDead(ID))
				{
					StudentGlobals.SetStudentDying(ID, value: false);
				}
			}
			if (!TakingPortraits)
			{
				for (ID = 1; ID < 101; ID++)
				{
					TargetSize[ID] = 2f + (float)ID * 0.1f;
				}
				TargetSize[11] = 20f;
				for (ID = 1; ID < Lockers.List.Length; ID++)
				{
					LockerPositions[ID].transform.position = Lockers.List[ID].position + Lockers.List[ID].forward * 0.5f;
					LockerPositions[ID].LookAt(Lockers.List[ID].position);
				}
				for (ID = 1; ID < ShowerLockers.List.Length; ID++)
				{
					Transform transform = UnityEngine.Object.Instantiate(EmptyObject, ShowerLockers.List[ID].position + ShowerLockers.List[ID].forward * 0.5f, ShowerLockers.List[ID].rotation).transform;
					transform.parent = ShowerLockers.transform;
					transform.transform.eulerAngles = new Vector3(transform.transform.eulerAngles.x, transform.transform.eulerAngles.y + 180f, transform.transform.eulerAngles.z);
					StrippingPositions[ID] = transform;
				}
				for (ID = 1; ID < HidingSpots.List.Length; ID++)
				{
					if (HidingSpots.List[ID] == null)
					{
						GameObject gameObject3 = UnityEngine.Object.Instantiate(EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
						while (gameObject3.transform.position.x < 2.5f && gameObject3.transform.position.x > -2.5f && gameObject3.transform.position.z > -2.5f && gameObject3.transform.position.z < 2.5f)
						{
							gameObject3.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
						}
						gameObject3.transform.parent = HidingSpots.transform;
						HidingSpots.List[ID] = gameObject3.transform;
					}
				}
			}
			if (GameGlobals.AlphabetMode)
			{
				Debug.Log("Entering Alphabet Killer Mode. Repositioning Yandere-chan and others.");
				Yandere.transform.position = Portal.transform.position + new Vector3(1f, 0f, 0f);
				Clock.StopTime = true;
				SkipTo730();
			}
			if (!TakingPortraits && !RecordingVideo && !SpawnNobody)
			{
				while (SpawnID < NPCsTotal + 1)
				{
					SpawnStudent(SpawnID);
					SpawnID++;
				}
				Graffiti[1].SetActive(value: false);
				Graffiti[2].SetActive(value: false);
				Graffiti[3].SetActive(value: false);
				Graffiti[4].SetActive(value: false);
				Graffiti[5].SetActive(value: false);
				RivalChan.SetActive(value: false);
			}
		}
		else
		{
			string text = string.Empty;
			if (ProblemID > 1)
			{
				text = "The problem may be caused by Student " + ProblemID + ".";
			}
			if (ErrorLabel != null)
			{
				ErrorLabel.text = "The game cannot compile Students.JSON! There is a typo somewhere in the JSON file. The problem might be a missing quotation mark, a missing colon, a missing comma, or something else like that. Please find your typo and fix it, or revert to a backup of the JSON file. " + text;
				ErrorLabel.enabled = true;
			}
		}
		if (!TakingPortraits)
		{
			NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
			NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
			SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
			SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
			if (!ReturnedFromSave)
			{
				Yandere.Class.GetStats();
			}
			Yandere.CameraEffects.UpdateDOF(2f);
		}
		if (PlayerGlobals.PersonaID > 0)
		{
			Yandere.PersonaID = PlayerGlobals.PersonaID;
			Mirror.UpdatePersona();
		}
		LoadPantyshots();
		LoadPhotographs();
		if (RecordingVideo)
		{
			base.gameObject.SetActive(value: false);
			FPSDisplay.SetActive(value: false);
			FPSDisplayBG.SetActive(value: false);
			Clock.CameraEffects.UpdateBloom(1f);
			Clock.CameraEffects.UpdateBloomRadius(4f);
			Clock.CameraEffects.UpdateBloomKnee(0.75f);
			Yandere.enabled = false;
			Yandere.UICamera.gameObject.SetActive(value: false);
			Yandere.MainCamera.gameObject.SetActive(value: false);
		}
		if (StudentGlobals.UpdateRivalReputation)
		{
			Debug.Log("''StudentGlobals.UpdateRivalReputation'' was ''true'', so we're performing math on the rival's rep now.");
			Debug.Log("Rival's rep was: " + StudentReps[RivalID]);
			StudentReps[RivalID] -= 50f;
			Debug.Log("And now it is: " + StudentReps[RivalID]);
		}
		LoadTopicsLearned();
		if (Police != null)
		{
			Police.EndOfDay.VoidGoddess.Window.parent.gameObject.SetActive(value: false);
		}
		Yandere.PauseScreen.PhotoGallery.Start();
	}

	public void SetAtmosphere()
	{
		if (GameGlobals.LoveSick)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 0f;
		}
		if (!MissionMode && !KokonaTutorial)
		{
			if (!SchoolGlobals.SchoolAtmosphereSet)
			{
				SchoolGlobals.SchoolAtmosphereSet = true;
				SchoolGlobals.PreviousSchoolAtmosphere = 1f;
				SchoolGlobals.SchoolAtmosphere = 1f;
			}
			Atmosphere = SchoolGlobals.SchoolAtmosphere;
		}
		float num = 1f - Atmosphere;
		if (!TakingPortraits)
		{
			SelectiveGreyscale.desaturation = num;
			if (HandSelectiveGreyscale != null)
			{
				HandSelectiveGreyscale.desaturation = num;
				SmartphoneSelectiveGreyscale.desaturation = num;
			}
			SelectiveGrayscale[] spyGrayscales = SpyGrayscales;
			for (int i = 0; i < spyGrayscales.Length; i++)
			{
				spyGrayscales[i].desaturation = num;
			}
			float num2 = 1f - num;
			RenderSettings.fogColor = new Color(num2, num2, num2, 1f);
			Camera.main.backgroundColor = new Color(num2, num2, num2, 1f);
			if (!EightiesTutorial)
			{
				RenderSettings.fogDensity = num * 0.1f;
			}
		}
		if (Yandere != null)
		{
			Yandere.GreyTarget = num;
		}
	}

	private void Update()
	{
		if (!TakingPortraits)
		{
			if (!Yandere.ShoulderCamera.Counselor.Interrogating && !Yandere.PauseScreen.YouTubeChatMenu.isActiveAndEnabled)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
			if (Frame < 4)
			{
				Frame++;
				if (!FirstUpdate)
				{
					QualityManager.UpdateOutlines();
					FirstUpdate = true;
					AssignTeachers();
				}
				if (Frame == 3)
				{
					Police.EndOfDay.VoidGoddess.UpdatePortraits();
					LoveManager.CoupleCheck();
					if (Eighties || Bullies > 0)
					{
						DetermineVictim();
					}
					UpdateStudents();
					QualityManager.UpdateOutlinesAndRimlight();
					if (QualityManager.DisableOutlinesLater)
					{
						OptionGlobals.DisableOutlines = true;
					}
					if (QualityManager.DisableRimLightLater)
					{
						OptionGlobals.RimLight = false;
					}
					QualityManager.UpdateOutlinesAndRimlight();
					for (int i = 26; i < 31; i++)
					{
						if (Students[i] != null)
						{
							OriginalClubPositions[i - 25] = Clubs.List[i].position;
							OriginalClubRotations[i - 25] = Clubs.List[i].rotation;
						}
					}
					if (!TakingPortraits)
					{
						TaskManager.UpdateTaskStatus();
					}
					Yandere.GloveAttacher.newRenderer.enabled = false;
					UpdateAprons();
					if (PlayerPrefs.GetInt("LoadingSave") == 1)
					{
						PlayerPrefs.SetInt("LoadingSave", 0);
						Load();
					}
					ClubManager.gameObject.SetActive(value: true);
					if (!YandereLate)
					{
						if (!LoadedSave && StudentGlobals.MemorialStudents > 0 && !ReturnedFromSave && DateGlobals.Week < 11)
						{
							Yandere.HUD.alpha = 0f;
							Yandere.RPGCamera.transform.position = new Vector3(38f, 4.125f, 68.825f);
							Yandere.RPGCamera.transform.eulerAngles = new Vector3(22.5f, 67.5f, 0f);
							Yandere.RPGCamera.transform.Translate(Vector3.forward, Space.Self);
							Yandere.RPGCamera.enabled = false;
							Yandere.HeartCamera.enabled = false;
							Yandere.CanMove = false;
							Clock.StopTime = true;
							StopMoving();
							MemorialScene.gameObject.SetActive(value: true);
							MemorialScene.enabled = true;
						}
					}
					else
					{
						Debug.Log("Because Yandere-chan is late for school, we're teleporting students where they would be at 8 AM.");
						Clock.PresentTime = 480f;
						Clock.HourTime = 8f;
						Clock.Hour = Mathf.Floor(Clock.PresentTime / 60f);
						Clock.Minute = Mathf.Floor((Clock.PresentTime / 60f - Clock.Hour) * 60f);
						Clock.UpdateClock();
						Clock.Update();
						SkipTo8();
					}
					for (int i = 1; i < 101; i++)
					{
						if (Students[i] != null)
						{
							if (!Students[i].Teacher)
							{
								Students[i].ShoeRemoval.Start();
							}
							Students[i].AddOutlineToHair();
						}
					}
					ClubManager.ActivateClubBenefit();
					if (GameGlobals.CensorPanties)
					{
						CensorStudents();
						Yandere.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
					}
					if (!Eighties)
					{
						if (!MissionMode && !GameGlobals.AlphabetMode)
						{
							if (Week == 1 && Students[RivalID] != null)
							{
								Week1RoutineAdjustments();
							}
							if (Week == 2)
							{
								Week2RoutineAdjustments();
								BakeSale.SetActive(value: true);
							}
						}
					}
					else
					{
						IdolStage.SetActive(value: false);
						if (Students[RivalID] != null)
						{
							if (Week > 1)
							{
								RivalPostWeekRoutineAdjustments();
							}
							if (Week == 3)
							{
								EightiesWeek3RoutineAdjustments();
							}
							else if (Week == 4)
							{
								EightiesWeek4RoutineAdjustments();
							}
							else if (Week == 5)
							{
								EightiesWeek5RoutineAdjustments();
							}
							else if (Week == 6)
							{
								EightiesWeek6RoutineAdjustments();
								IdolStage.SetActive(value: true);
							}
							else if (Week == 7)
							{
								EightiesWeek3RoutineAdjustments();
							}
							else if (Week == 8)
							{
								EightiesWeek8RoutineAdjustments();
							}
							else if (Week == 9)
							{
								Debug.Log("Adjusting everyone's routine because of the gravure rival.");
								EightiesWeek9RoutineAdjustments();
								for (int j = 57; j < 61; j++)
								{
									if (Students[j] != null && !Students[j].Grudge)
									{
										Debug.Log("Student #" + j + " does NOT hold a grudge.");
										Photographers++;
									}
								}
								if (SchoolGlobals.SchoolAtmosphere > 0.8f && Photographers > 0)
								{
									PhotoshootRoutineAdjustments();
									PoolPhotoShootCameras.SetActive(value: true);
								}
								else if (Students[19] != null)
								{
									Debug.Log("Changing Gravure Idol's routine.");
									scheduleBlock = Students[19].ScheduleBlocks[7];
									scheduleBlock.destination = "Patrol";
									scheduleBlock.action = "Patrol";
									Students[19].GetDestinations();
								}
							}
							else if (Week == 10)
							{
								EightiesWeek10RoutineAdjustments();
							}
						}
						if (Students[RivalID] != null && Students[SuitorID] != null)
						{
							ChangeSuitorRoutine(SuitorID);
						}
						if (Week > 1)
						{
							CoupleCheck();
						}
					}
					if (SpawnNobody)
					{
						if (Week < 11 && Eighties)
						{
							TutorialActive = true;
							Tutorial.gameObject.SetActive(value: true);
							Tutorial.InstructionLabel.transform.parent.gameObject.SetActive(value: true);
						}
						if (SchoolGlobals.SchoolAtmosphere < 0.5f)
						{
							Clock.CameraEffects.UpdateBloom(1f);
							Clock.CameraEffects.UpdateBloomKnee(0.5f);
							Clock.CameraEffects.UpdateBloomRadius(4f);
						}
						else
						{
							Clock.CameraEffects.UpdateBloom(11f);
							Clock.CameraEffects.UpdateBloomKnee(1f);
							Clock.CameraEffects.UpdateBloomRadius(7f);
						}
						FPSDisplay.SetActive(value: false);
						FPSDisplayBG.SetActive(value: false);
					}
					if (!TutorialActive)
					{
						Tutorial.InstructionLabel.transform.parent.gameObject.SetActive(value: false);
					}
					UpdateAllBentos();
					if (!Eighties)
					{
						FanCover.enabled = true;
					}
					if (!MissionMode && !GameGlobals.AlphabetMode)
					{
						for (int k = 76; k < 90; k++)
						{
							if (Students[k] != null)
							{
								Students[k].transform.position = SpawnPositions[k].position;
							}
						}
					}
					Physics.SyncTransforms();
					if (MissionMode)
					{
						Yandere.ChangeSchoolwear();
					}
					UpdateAllSleuthClothing();
				}
				else if (Frame == 4)
				{
					StudentScript[] students;
					if (LoadedSave)
					{
						RagdollScript[] corpseList = Police.CorpseList;
						foreach (RagdollScript ragdollScript in corpseList)
						{
							if (ragdollScript != null && ragdollScript.gameObject != null)
							{
								GameObjectUtils.SetLayerRecursively(ragdollScript.gameObject, 11);
							}
						}
						LoadAllStudentPositions();
						Physics.SyncTransforms();
						if (BookBag.Worn)
						{
							BookBag.Wear();
						}
						LoadedSave = false;
						Reputation.UpdatePendingRepLabel();
						if (!Eighties)
						{
							if (Students[10] != null)
							{
								Students[10].Cosmetic.SetFemaleUniform();
							}
							if (Students[86] != null)
							{
								Students[86].Cosmetic.SetFemaleUniform();
							}
							if (Students[87] != null)
							{
								Students[87].Cosmetic.SetFemaleUniform();
							}
							if (Students[88] != null)
							{
								Students[88].Cosmetic.SetFemaleUniform();
							}
							if (Students[89] != null)
							{
								Students[89].Cosmetic.SetFemaleUniform();
							}
						}
						else
						{
							if (Students[86] != null)
							{
								Students[86].Cosmetic.SetMaleUniform();
							}
							if (Students[87] != null)
							{
								Students[87].Cosmetic.SetMaleUniform();
							}
							if (Students[88] != null)
							{
								Students[88].Cosmetic.SetMaleUniform();
							}
							if (Students[89] != null)
							{
								Students[89].Cosmetic.SetMaleUniform();
							}
						}
						students = Students;
						foreach (StudentScript studentScript in students)
						{
							if (studentScript != null)
							{
								if (studentScript.Meeting)
								{
									Debug.Log(studentScript.Name + " was in the middle of meeting someone when this save file was made. Attempting to update their schedule accordingly.");
									NoteWindow.NoteLocker.StudentID = MeetStudentID;
									NoteWindow.NoteLocker.MeetTime = MeetTime;
									NoteWindow.NoteLocker.MeetID = MeetID;
									NoteWindow.NoteLocker.DetermineSchedule();
									studentScript.MeetTimer = 0f;
								}
								if (studentScript.Schoolwear != 1)
								{
									studentScript.ChangeSchoolwear();
								}
								if (studentScript.Actions[studentScript.Phase] == StudentActionType.ClubAction && studentScript.Club == ClubType.Cooking && studentScript.ClubActivityPhase > 0)
								{
									studentScript.MyPlate.parent = studentScript.RightHand;
									studentScript.MyPlate.localPosition = new Vector3(0.02f, -0.02f, -0.15f);
									studentScript.MyPlate.localEulerAngles = new Vector3(-5f, -90f, 172.5f);
									studentScript.IdleAnim = studentScript.PlateIdleAnim;
									studentScript.WalkAnim = studentScript.PlateWalkAnim;
									studentScript.LeanAnim = studentScript.PlateIdleAnim;
									studentScript.Attempts = 0;
									studentScript.SleuthID--;
									Debug.Log("Loading save. Instructing " + studentScript.Name + " to GetFoodTarget().");
									studentScript.GetFoodTarget();
									studentScript.ClubTimer = 0f;
								}
							}
						}
						if (StudentGlobals.MemorialStudents > 0)
						{
							Debug.Log("We loaded a save, and had a memorial before the save was loaded. Restoring the memorial scene.");
							MemorialScene.gameObject.SetActive(value: true);
							MemorialScene.Start();
							MemorialScene.Headmaster.SetActive(value: false);
							MemorialScene.Counselor.SetActive(value: false);
						}
					}
					students = Students;
					foreach (StudentScript studentScript2 in students)
					{
						if (studentScript2 != null)
						{
							studentScript2.SetOriginalScheduleBlocks();
							studentScript2.SetOriginalActions();
						}
					}
					Eighties = GameGlobals.Eighties;
					if (!GameGlobals.AlphabetMode && !Eighties && Students[RivalID] != null && Students[RivalID].Indoors)
					{
						UpdateExteriorStudents();
					}
					if (Eighties && !RivalEliminated)
					{
						if (GameGlobals.AlphabetMode)
						{
							UpdateExteriorEightiesStudents();
						}
						for (int m = 81; m < 86; m++)
						{
							if (Students[m] != null)
							{
								Students[m].Indoors = true;
								Students[m].Spawned = true;
								Students[m].Paired = false;
								if (Students[m].ShoeRemoval.Locker == null)
								{
									Students[m].ShoeRemoval.Start();
								}
								Students[m].ShoeRemoval.PutOnShoes();
								Students[m].transform.position = SukebanHangoutParent.position;
							}
						}
					}
					Physics.SyncTransforms();
					if (Screen.width < 1280 || Screen.height < 720)
					{
						Screen.SetResolution(1280, 720, fullscreen: false);
					}
					LookAtTest();
					Yandere.EmptyHands();
					Yandere.FilterUpdated = false;
				}
			}
			if ((double)Clock.HourTime > 16.9)
			{
				CheckMusic();
			}
		}
		else if (NPCsSpawned < StudentsTotal + TeachersTotal)
		{
			Frame++;
			if (Frame == 1)
			{
				if (NewStudent != null)
				{
					UnityEngine.Object.Destroy(NewStudent);
				}
				if (Eighties || NPCsSpawned < 12 || NPCsSpawned > 19)
				{
					if (Randomize)
					{
						int num = UnityEngine.Random.Range(0, 2);
						NewStudent = UnityEngine.Object.Instantiate((num == 0) ? PortraitChan : PortraitKun, Vector3.zero, Quaternion.identity);
					}
					else
					{
						NewStudent = UnityEngine.Object.Instantiate((JSON.Students[NPCsSpawned + 1].Gender == 0) ? PortraitChan : PortraitKun, Vector3.zero, Quaternion.identity);
					}
					CosmeticScript component = NewStudent.GetComponent<CosmeticScript>();
					component.StudentID = NPCsSpawned + 1;
					component.StudentManager = this;
					component.TakingPortrait = true;
					component.Randomize = Randomize;
					component.JSON = JSON;
					component.Student.enabled = false;
					component.Student.Prompt.enabled = false;
					component.Student.MyCollider.enabled = false;
					component.Student.Pathfinding.enabled = false;
					component.Student.MyRigidbody.useGravity = false;
					component.Student.DisableProps();
					if (component.Student.Male)
					{
						component.Student.DisableMaleProps();
					}
					else
					{
						component.Student.DisableFemaleProps();
					}
					component.Start();
					StudentScript component2 = NewStudent.GetComponent<StudentScript>();
					component2.Yandere = Yandere;
					component2.SetSplashes(Bool: false);
					PromptScript[] componentsInChildren = component.gameObject.GetComponentsInChildren<PromptScript>();
					for (int l = 0; l < componentsInChildren.Length; l++)
					{
						componentsInChildren[l].enabled = false;
					}
					if (!Eighties && component.StudentID == 97)
					{
						Whistle.SetActive(value: true);
					}
				}
				if (!Randomize)
				{
					NPCsSpawned++;
				}
			}
			if (Frame == 2)
			{
				ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits" + EightiesPrefix + "/Student_" + NPCsSpawned + ".png");
				Frame = 0;
			}
		}
		else
		{
			ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits" + EightiesPrefix + "/Student_" + NPCsSpawned + ".png");
			base.gameObject.SetActive(value: false);
		}
		if (Witnesses > 0)
		{
			for (ID = 1; ID < WitnessList.Length; ID++)
			{
				StudentScript studentScript3 = WitnessList[ID];
				if (studentScript3 != null && (!studentScript3.Alive || studentScript3.Attacked || studentScript3.Dying || studentScript3.Routine || (studentScript3.Fleeing && !studentScript3.PinningDown) || studentScript3.Persona == PersonaType.Coward))
				{
					studentScript3.PinDownWitness = false;
					studentScript3 = null;
					if (ID != WitnessList.Length - 1)
					{
						Shuffle(ID);
					}
					Witnesses--;
				}
			}
			if (PinningDown && Witnesses < 4)
			{
				Debug.Log("Students were going to pin Yandere-chan down, but now there are less than 4 witnesses, so it's not going to happen.");
				if (!Yandere.Chased && Yandere.Chasers == 0)
				{
					Yandere.CanMove = true;
				}
				PinningDown = false;
				PinDownTimer = 0f;
				PinPhase = 0;
			}
		}
		if (PinningDown)
		{
			if (!Yandere.Attacking && Yandere.CanMove)
			{
				Yandere.CharacterAnimation.CrossFade("f02_pinDownPanic_00");
				Yandere.EmptyHands();
				Yandere.CanMove = false;
				if (Yandere.YandereVision)
				{
					Yandere.YandereVision = false;
					Yandere.ResetYandereEffects();
				}
			}
			if (PinPhase == 1)
			{
				if (!Yandere.Attacking && !Yandere.Struggling)
				{
					PinTimer += Time.deltaTime;
				}
				if (PinTimer > 1f)
				{
					for (ID = 1; ID < 5; ID++)
					{
						StudentScript studentScript4 = WitnessList[ID];
						if (studentScript4 != null)
						{
							studentScript4.transform.position = new Vector3(studentScript4.transform.position.x, studentScript4.transform.position.y + 0.1f, studentScript4.transform.position.z);
							studentScript4.CurrentDestination = PinDownSpots[ID];
							studentScript4.Pathfinding.target = PinDownSpots[ID];
							studentScript4.SprintAnim = studentScript4.OriginalSprintAnim;
							studentScript4.DistanceToDestination = 100f;
							studentScript4.Pathfinding.speed = 5f;
							studentScript4.MyController.radius = 0f;
							studentScript4.PinningDown = true;
							studentScript4.Alarmed = false;
							studentScript4.Routine = false;
							studentScript4.Fleeing = true;
							studentScript4.AlarmTimer = 0f;
							studentScript4.LowPoly.MyMesh.enabled = false;
							studentScript4.MyRenderer.enabled = true;
							studentScript4.LowPoly.enabled = false;
							studentScript4.SmartPhone.SetActive(value: false);
							studentScript4.Safe = true;
							studentScript4.Prompt.Hide();
							studentScript4.Prompt.enabled = false;
							Debug.Log(studentScript4?.ToString() + "'s current destination is " + studentScript4.CurrentDestination);
						}
					}
					PinPhase++;
				}
			}
			else if (WitnessList[1].PinPhase == 0)
			{
				if (!Yandere.ShoulderCamera.Noticed && !Yandere.ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
				{
					PinDownTimer += Time.deltaTime;
					if (PinDownTimer > 10f || (WitnessList[1].DistanceToDestination < 1f && WitnessList[2].DistanceToDestination < 1f && WitnessList[3].DistanceToDestination < 1f && WitnessList[4].DistanceToDestination < 1f))
					{
						Time.timeScale = 1f;
						CombatMinigame.DisablePrompts();
						Clock.StopTime = true;
						Yandere.HUD.enabled = false;
						if (Yandere.Aiming)
						{
							Yandere.StopAiming();
							Yandere.enabled = false;
						}
						Yandere.Mopping = false;
						Yandere.EmptyHands();
						AudioSource component3 = GetComponent<AudioSource>();
						component3.PlayOneShot(PinDownSFX);
						component3.PlayOneShot(YanderePinDown);
						Yandere.CharacterAnimation.CrossFade("f02_pinDown_00");
						Yandere.CanMove = false;
						Yandere.ShoulderCamera.LookDown = true;
						Yandere.RPGCamera.enabled = false;
						StopMoving();
						Yandere.ShoulderCamera.HeartbrokenCamera.GetComponent<Camera>().cullingMask |= 512;
						for (ID = 1; ID < 5; ID++)
						{
							StudentScript studentScript5 = WitnessList[ID];
							if (studentScript5.MyWeapon != null)
							{
								GameObjectUtils.SetLayerRecursively(studentScript5.MyWeapon.gameObject, 13);
							}
							studentScript5.CharacterAnimation.CrossFade(((studentScript5.Male ? "pinDown_0" : "f02_pinDown_0") + ID).ToString());
							studentScript5.PinPhase++;
						}
					}
				}
			}
			else
			{
				bool flag = false;
				if (!WitnessList[1].Male)
				{
					if (WitnessList[1].CharacterAnimation["f02_pinDown_01"].time >= WitnessList[1].CharacterAnimation["f02_pinDown_01"].length)
					{
						flag = true;
					}
				}
				else if (WitnessList[1].CharacterAnimation["pinDown_01"].time >= WitnessList[1].CharacterAnimation["pinDown_01"].length)
				{
					flag = true;
				}
				if (flag)
				{
					Yandere.CharacterAnimation.CrossFade("f02_pinDownLoop_00");
					for (ID = 1; ID < 5; ID++)
					{
						StudentScript studentScript6 = WitnessList[ID];
						studentScript6.CharacterAnimation.CrossFade(((studentScript6.Male ? "pinDownLoop_0" : "f02_pinDownLoop_0") + ID).ToString());
					}
					PinningDown = false;
				}
			}
		}
		if (Meeting)
		{
			UpdateMeeting();
		}
		if (Police != null && (Police.BloodParent.childCount > 0 || Police.LimbParent.childCount > 0 || Yandere.WeaponManager.MisplacedWeapons > 0))
		{
			CurrentID++;
			if (CurrentID > 97)
			{
				UpdateBlood();
				CurrentID = 1;
			}
			if (Students[CurrentID] == null)
			{
				CurrentID++;
			}
			else if (!Students[CurrentID].gameObject.activeInHierarchy)
			{
				CurrentID++;
			}
		}
		if (OpenCurtain)
		{
			OpenValue = Mathf.Lerp(OpenValue, 100f, Time.deltaTime * 10f);
			if (OpenValue > 99f)
			{
				OpenCurtain = false;
			}
			FemaleShowerCurtain.SetBlendShapeWeight(1, OpenValue);
		}
		if (AoT)
		{
			GrowTimer += Time.deltaTime;
			if (GrowTimer < 10f)
			{
				for (ID = 2; ID < Students.Length; ID++)
				{
					StudentScript studentScript7 = Students[ID];
					if (studentScript7 != null && studentScript7.transform.localScale.x < TargetSize[ID])
					{
						studentScript7.transform.localScale = Vector3.Lerp(studentScript7.transform.localScale, new Vector3(TargetSize[ID], TargetSize[ID], TargetSize[ID]), Time.deltaTime);
					}
				}
			}
		}
		if (Pose)
		{
			for (ID = 1; ID < Students.Length; ID++)
			{
				StudentScript studentScript8 = Students[ID];
				if (studentScript8 != null && studentScript8.Prompt.Label[0] != null)
				{
					studentScript8.Prompt.Label[0].text = "     Pose";
				}
			}
		}
		if (Yandere.Egg)
		{
			if (Sans)
			{
				for (ID = 1; ID < Students.Length; ID++)
				{
					StudentScript studentScript9 = Students[ID];
					if (studentScript9 != null && studentScript9.Prompt.Label[0] != null)
					{
						studentScript9.Prompt.Label[0].text = "     Psychokinesis";
					}
				}
			}
			if (Ebola)
			{
				for (ID = 2; ID < Students.Length; ID++)
				{
					StudentScript studentScript10 = Students[ID];
					if (studentScript10 != null && studentScript10.isActiveAndEnabled && studentScript10.DistanceToPlayer < 1f)
					{
						UnityEngine.Object.Instantiate(Yandere.EbolaEffect, studentScript10.transform.position + Vector3.up, Quaternion.identity);
						studentScript10.SpawnAlarmDisc();
						studentScript10.BecomeRagdoll();
						studentScript10.DeathType = DeathType.EasterEgg;
					}
				}
			}
			if (Yandere.Hunger >= 5)
			{
				for (ID = 2; ID < Students.Length; ID++)
				{
					StudentScript studentScript11 = Students[ID];
					if (studentScript11 != null && studentScript11.isActiveAndEnabled && studentScript11.DistanceToPlayer < 5f)
					{
						UnityEngine.Object.Instantiate(Yandere.DarkHelix, studentScript11.transform.position + Vector3.up, Quaternion.identity);
						studentScript11.SpawnAlarmDisc();
						studentScript11.BecomeRagdoll();
						studentScript11.DeathType = DeathType.EasterEgg;
					}
				}
			}
		}
		if (PlazaOccluder != null)
		{
			if (Yandere.transform.position.z < -50f)
			{
				PlazaOccluder.open = false;
			}
			else
			{
				PlazaOccluder.open = true;
			}
		}
		if (BehindSchoolOccluder != null)
		{
			if (Yandere.transform.position.z > 50f)
			{
				BehindSchoolOccluder.open = false;
			}
			else
			{
				BehindSchoolOccluder.open = true;
			}
		}
		YandereVisible = false;
	}

	public void SpawnStudent(int spawnID)
	{
		bool flag = false;
		if (Eighties)
		{
			if (spawnID > Week + WeekLimit && spawnID < 21)
			{
				flag = true;
			}
		}
		else
		{
			if (spawnID > 11 && spawnID < 21)
			{
				flag = true;
			}
			if (Week == 2 && spawnID == 12)
			{
				flag = false;
			}
		}
		if (JSON.Students[spawnID].Club != ClubType.Delinquent && StudentGlobals.GetStudentReputation(spawnID) < -100)
		{
			flag = true;
		}
		if (!flag && Students[spawnID] == null && !StudentGlobals.GetStudentDead(spawnID) && !StudentGlobals.GetStudentKidnapped(spawnID) && !StudentGlobals.GetStudentArrested(spawnID) && !StudentGlobals.GetStudentExpelled(spawnID))
		{
			int num = 0;
			if (JSON.Students[spawnID].Name == "Random")
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
				while (gameObject.transform.position.x < 2.5f && gameObject.transform.position.x > -2.5f && gameObject.transform.position.z > -2.5f && gameObject.transform.position.z < 2.5f)
				{
					gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0f, UnityEngine.Random.Range(-17f, 17f));
				}
				gameObject.transform.parent = HidingSpots.transform;
				HidingSpots.List[spawnID] = gameObject.transform;
				GameObject gameObject2 = UnityEngine.Object.Instantiate(RandomPatrol, Vector3.zero, Quaternion.identity);
				gameObject2.transform.parent = Patrols.transform;
				Patrols.List[spawnID] = gameObject2.transform;
				GameObject gameObject3 = UnityEngine.Object.Instantiate(RandomPatrol, Vector3.zero, Quaternion.identity);
				gameObject3.transform.parent = CleaningSpots.transform;
				CleaningSpots.List[spawnID] = gameObject3.transform;
				num = ((!MissionMode || MissionModeGlobals.MissionTarget != spawnID) ? UnityEngine.Random.Range(0, 2) : 0);
				FindUnoccupiedSeat();
			}
			else
			{
				num = JSON.Students[spawnID].Gender;
			}
			NewStudent = UnityEngine.Object.Instantiate((num == 0) ? StudentChan : StudentKun, SpawnPositions[spawnID].position, Quaternion.identity);
			CosmeticScript component = NewStudent.GetComponent<CosmeticScript>();
			component.LoveManager = LoveManager;
			component.StudentManager = this;
			component.Randomize = Randomize;
			component.StudentID = spawnID;
			component.JSON = JSON;
			if (spawnID == 4)
			{
				component.Randomize = false;
			}
			if (JSON.Students[spawnID].Name == "Random")
			{
				NewStudent.GetComponent<StudentScript>().CleaningSpot = CleaningSpots.List[spawnID];
				NewStudent.GetComponent<StudentScript>().CleaningRole = 3;
			}
			if (JSON.Students[spawnID].Club == ClubType.Bully)
			{
				Bullies++;
			}
			Students[spawnID] = NewStudent.GetComponent<StudentScript>();
			StudentScript studentScript = Students[spawnID];
			studentScript.ChaseSelectiveGrayscale.desaturation = 1f - SchoolGlobals.SchoolAtmosphere;
			studentScript.Cosmetic.TextureManager = TextureManager;
			studentScript.WitnessCamera = WitnessCamera;
			studentScript.StudentManager = this;
			studentScript.StudentID = spawnID;
			studentScript.JSON = JSON;
			studentScript.Ragdoll.StudentID = spawnID;
			studentScript.BloodSpawnerIdentifier.ObjectID = "Student_" + spawnID + "_BloodSpawner";
			studentScript.BentoIdentifier.ObjectID = "Student_" + spawnID + "_Bento";
			studentScript.HipsIdentifier.ObjectID = "Student_" + spawnID + "_Hips";
			studentScript.YanSave.ObjectID = "Student_" + spawnID;
			if (studentScript.Miyuki != null)
			{
				studentScript.Miyuki.Enemy = MiyukiCat;
			}
			if (AoT)
			{
				studentScript.AoT = true;
			}
			if (DK)
			{
				studentScript.DK = true;
			}
			if (Spooky)
			{
				studentScript.Spooky = true;
			}
			if (Sans)
			{
				studentScript.BadTime = true;
			}
			if (!MissionMode)
			{
				if (spawnID == RivalID && !RivalEliminated)
				{
					studentScript.Rival = true;
					RedString.transform.parent = studentScript.LeftPinky;
					RedString.transform.localPosition = new Vector3(0f, 0f, 0f);
				}
				if (spawnID == 1)
				{
					RedString.Target = studentScript.LeftPinky;
				}
			}
			else if (spawnID == MissionModeGlobals.MissionTarget)
			{
				studentScript.Rival = true;
			}
			if (num == 0)
			{
				GirlsSpawned++;
				studentScript.GirlID = GirlsSpawned;
			}
			if (spawnID == 1)
			{
				studentScript.MiniMapIcon.icon = studentScript.SenpaiSprite;
			}
			else if (spawnID == RivalID)
			{
				studentScript.MiniMapIcon.icon = studentScript.RivalSprite;
			}
			OccupySeat();
		}
		NPCsSpawned++;
		ForceSpawn = false;
	}

	public void UpdateStudents(int SpecificStudent = 0)
	{
		ID = 2;
		while (ID < Students.Length)
		{
			bool flag = false;
			if (SpecificStudent != 0)
			{
				ID = SpecificStudent;
				flag = true;
			}
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.CanTakeSnack = false;
				studentScript.CanGiveHelp = false;
				studentScript.CanBeFed = false;
				if (studentScript.gameObject.activeInHierarchy || studentScript.Hurry)
				{
					if (!studentScript.Safe)
					{
						if (!studentScript.Slave)
						{
							if (studentScript.Pushable)
							{
								studentScript.Prompt.Label[0].text = "     Push";
							}
							else if (Yandere.SpiderGrow)
							{
								if (!studentScript.Cosmetic.Empty)
								{
									studentScript.Prompt.Label[0].text = "     Send Husk";
								}
								else
								{
									studentScript.Prompt.Label[0].text = "     Talk";
								}
							}
							else if (!studentScript.Following)
							{
								studentScript.Prompt.Label[0].text = "     Talk";
							}
							else
							{
								studentScript.Prompt.Label[0].text = "     Stop";
							}
							studentScript.Prompt.HideButton[0] = false;
							studentScript.Prompt.HideButton[2] = false;
							studentScript.Prompt.Attack = false;
							if (Yandere.Mask != null || studentScript.Ragdoll.Zs.activeInHierarchy)
							{
								studentScript.Prompt.HideButton[0] = true;
							}
							if (Yandere.Dragging || Yandere.PickUp != null || Yandere.Chased)
							{
								studentScript.Prompt.HideButton[0] = true;
								studentScript.Prompt.HideButton[2] = true;
								if (Yandere.PickUp != null && !studentScript.Following)
								{
									if (Yandere.PickUp.Food > 0)
									{
										studentScript.Prompt.Label[0].text = "     Feed";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
										studentScript.CanBeFed = true;
									}
									else if (Yandere.PickUp.Salty)
									{
										studentScript.Prompt.Label[0].text = "     Give Snack";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
										studentScript.CanTakeSnack = true;
									}
									else if (Yandere.PickUp.StuckBoxCutter != null)
									{
										studentScript.Prompt.Label[0].text = "     Ask For Help";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
										studentScript.CanGiveHelp = true;
									}
									else if (Yandere.PickUp.PuzzleCube)
									{
										studentScript.Prompt.Label[0].text = "     Give Puzzle";
										studentScript.Prompt.HideButton[0] = false;
										studentScript.Prompt.HideButton[2] = true;
									}
								}
							}
							if (Yandere.Armed)
							{
								studentScript.Prompt.HideButton[0] = true;
								studentScript.Prompt.Attack = true;
								studentScript.Prompt.MinimumDistanceSqr = 1f;
								studentScript.Prompt.MinimumDistance = 1f;
							}
							else
							{
								studentScript.Prompt.HideButton[2] = true;
								studentScript.Prompt.MinimumDistanceSqr = 2f;
								studentScript.Prompt.MinimumDistance = 2f;
								if (studentScript.WitnessedMurder || studentScript.WitnessedCorpse || studentScript.Private)
								{
									studentScript.Prompt.HideButton[0] = true;
								}
							}
							if (Yandere.NearBodies > 0 || Yandere.Sanity < 33.33333f)
							{
								studentScript.Prompt.HideButton[0] = true;
							}
							if (studentScript.Teacher)
							{
								CheckSelfReportStatus(studentScript);
							}
						}
						else if (!studentScript.FragileSlave)
						{
							if (Yandere.Armed)
							{
								if (Yandere.EquippedWeapon.Concealable)
								{
									studentScript.Prompt.HideButton[0] = false;
									studentScript.Prompt.Label[0].text = "     Give Weapon";
								}
								else
								{
									studentScript.Prompt.HideButton[0] = true;
									studentScript.Prompt.Label[0].text = string.Empty;
								}
							}
							else
							{
								studentScript.Prompt.HideButton[0] = true;
								studentScript.Prompt.Label[0].text = string.Empty;
							}
						}
					}
					if (studentScript.FightingSlave && Yandere.Armed && Yandere.EquippedWeapon.Type == WeaponType.Knife)
					{
						Debug.Log("Fighting with a slave!");
						studentScript.Prompt.Label[0].text = "     Stab";
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.HideButton[2] = true;
						studentScript.Prompt.enabled = true;
					}
					if (NoSpeech && !studentScript.Armband.activeInHierarchy)
					{
						studentScript.Prompt.HideButton[0] = true;
					}
				}
				if (studentScript.Prompt.Label[0] != null)
				{
					if (Sans)
					{
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Psychokinesis";
					}
					if (Pose)
					{
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Pose";
						studentScript.Prompt.BloodMask = 1;
						studentScript.Prompt.BloodMask |= 2;
						studentScript.Prompt.BloodMask |= 512;
						studentScript.Prompt.BloodMask |= 8192;
						studentScript.Prompt.BloodMask |= 16384;
						studentScript.Prompt.BloodMask |= 65536;
						studentScript.Prompt.BloodMask |= 2097152;
						studentScript.Prompt.BloodMask = ~studentScript.Prompt.BloodMask;
					}
					if (!studentScript.Teacher && Six)
					{
						studentScript.Prompt.MinimumDistance = 0.75f;
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Eat";
					}
					if (Gaze)
					{
						studentScript.Prompt.MinimumDistance = 5f;
						studentScript.Prompt.HideButton[0] = false;
						studentScript.Prompt.Label[0].text = "     Gaze";
					}
				}
				if (EmptyDemon)
				{
					studentScript.Prompt.HideButton[0] = false;
				}
			}
			ID++;
			if (flag)
			{
				ID = Students.Length;
			}
		}
		Container.UpdatePrompts();
		for (int i = 1; i < TrashCans.Length; i++)
		{
			TrashCans[i].UpdatePrompt();
		}
	}

	public void UpdateMe(int ID)
	{
		if (ID <= 1)
		{
			return;
		}
		StudentScript studentScript = Students[ID];
		if (!(studentScript != null))
		{
			return;
		}
		if (!studentScript.Safe)
		{
			studentScript.Prompt.Label[0].text = "     Talk";
			studentScript.Prompt.HideButton[0] = false;
			studentScript.Prompt.HideButton[2] = false;
			studentScript.Prompt.Attack = false;
			if (studentScript.FightingSlave)
			{
				if (Yandere.Armed && Yandere.EquippedWeapon.Type == WeaponType.Knife)
				{
					Debug.Log("Fighting with a slave!");
					studentScript.Prompt.Label[0].text = "     Stab";
					studentScript.Prompt.HideButton[0] = false;
					studentScript.Prompt.HideButton[2] = true;
					studentScript.Prompt.enabled = true;
				}
			}
			else
			{
				if (Yandere.Armed && OriginalUniforms + NewUniforms > 0)
				{
					studentScript.Prompt.HideButton[0] = true;
					studentScript.Prompt.MinimumDistance = 1f;
					studentScript.Prompt.Attack = true;
				}
				else
				{
					studentScript.Prompt.HideButton[2] = true;
					studentScript.Prompt.MinimumDistance = 2f;
					if (studentScript.WitnessedMurder || studentScript.WitnessedCorpse || studentScript.Private)
					{
						studentScript.Prompt.HideButton[0] = true;
					}
				}
				studentScript.Prompt.Label[2].text = "     Attack";
				if (studentScript.Drownable && !Yandere.Armed && Yandere.PickUp == null)
				{
					studentScript.Prompt.Label[2].text = "     Drown";
					studentScript.Prompt.HideButton[0] = true;
					studentScript.Prompt.HideButton[2] = false;
					studentScript.Prompt.MinimumDistance = 1f;
					studentScript.Prompt.Attack = true;
				}
				if (studentScript.Pushable && !Yandere.Armed && Yandere.PickUp == null)
				{
					studentScript.Prompt.Label[2].text = "     Push";
					studentScript.Prompt.HideButton[0] = true;
					studentScript.Prompt.HideButton[2] = false;
					studentScript.Prompt.MinimumDistance = 1f;
					studentScript.Prompt.Attack = true;
				}
				if (Yandere.Dragging || Yandere.PickUp != null || Yandere.Chased || Yandere.Chasers > 0)
				{
					studentScript.Prompt.HideButton[0] = true;
					studentScript.Prompt.HideButton[2] = true;
				}
				if (Yandere.NearBodies > 0 || Yandere.Sanity < 33.33333f)
				{
					studentScript.Prompt.HideButton[0] = true;
				}
				if (studentScript.Teacher)
				{
					CheckSelfReportStatus(studentScript);
				}
			}
		}
		if (Sans)
		{
			studentScript.Prompt.HideButton[0] = false;
			studentScript.Prompt.Label[0].text = "     Psychokinesis";
		}
		if (Pose)
		{
			studentScript.Prompt.HideButton[0] = false;
			studentScript.Prompt.Label[0].text = "     Pose";
		}
		if (NoSpeech || studentScript.Ragdoll.Zs.activeInHierarchy)
		{
			studentScript.Prompt.HideButton[0] = true;
		}
	}

	public void AttendClass()
	{
		ConvoManager.BothCharactersInPosition = false;
		SleuthPhase = 3;
		if (RingEvent.EventActive)
		{
			RingEvent.ReturnRing();
		}
		while (NPCsSpawned < NPCsTotal)
		{
			SpawnStudent(SpawnID);
			SpawnID++;
		}
		if (Clock.LateStudent)
		{
			Clock.ActivateLateStudent();
		}
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.VisitSenpaiDesk = false;
				studentScript.AlreadyFed = false;
				studentScript.Attempts = 0;
				if (studentScript.Meeting)
				{
					studentScript.StopMeeting();
				}
				if (studentScript.WitnessedBloodPool && !studentScript.WitnessedMurder && !studentScript.WitnessedCorpse)
				{
					studentScript.Fleeing = false;
					studentScript.Alarmed = false;
					studentScript.AlarmTimer = 0f;
					studentScript.ReportPhase = 0;
					studentScript.WitnessedBloodPool = false;
				}
				if (studentScript.HoldingHands)
				{
					studentScript.HoldingHands = false;
					studentScript.Paired = false;
					studentScript.enabled = true;
				}
				if (studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil && !studentScript.Fleeing && studentScript.enabled && studentScript.gameObject.activeInHierarchy)
				{
					if (!studentScript.Started)
					{
						studentScript.Start();
					}
					if (!studentScript.Teacher)
					{
						if (!studentScript.Indoors)
						{
							if (studentScript.ShoeRemoval.Locker == null)
							{
								studentScript.ShoeRemoval.Start();
							}
							studentScript.ShoeRemoval.PutOnShoes();
						}
						studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
						studentScript.transform.rotation = studentScript.Seat.rotation;
						studentScript.CharacterAnimation.Play(studentScript.SitAnim);
						studentScript.Pathfinding.canSearch = false;
						studentScript.Pathfinding.canMove = false;
						studentScript.Pathfinding.speed = 0f;
						studentScript.ClubActivityPhase = 0;
						studentScript.ClubTimer = 0f;
						studentScript.Patience = 5;
						studentScript.Pestered = 0;
						if (studentScript.SentToLocker)
						{
							NoteWindow.NoteLocker.Finish();
						}
						studentScript.Distracting = false;
						studentScript.Distracted = false;
						studentScript.Tripping = false;
						studentScript.Ignoring = false;
						studentScript.Pushable = false;
						studentScript.Private = false;
						studentScript.Sedated = false;
						studentScript.Emetic = false;
						studentScript.Hurry = false;
						studentScript.Safe = false;
						studentScript.CanTalk = true;
						studentScript.Routine = true;
						if (studentScript.Wet)
						{
							studentScript.CharacterAnimation[studentScript.WetAnim].weight = 0f;
							CommunalLocker.Student = null;
							studentScript.Schoolwear = 3;
							studentScript.ChangeSchoolwear();
							studentScript.LiquidProjector.enabled = false;
							studentScript.Splashed = false;
							studentScript.Bloody = false;
							studentScript.BathePhase = 1;
							studentScript.Wet = false;
							studentScript.UnWet();
							if (studentScript.Rival && CommunalLocker.RivalPhone.Stolen)
							{
								studentScript.RealizePhoneIsMissing();
							}
						}
						if (studentScript.ClubAttire)
						{
							studentScript.ChangeSchoolwear();
							studentScript.ClubAttire = false;
						}
						if (!studentScript.Male && studentScript.BikiniAttacher.enabled)
						{
							studentScript.ChangeSchoolwear();
						}
						if (studentScript.Schoolwear != 1)
						{
							if (!studentScript.BeenSplashed)
							{
								studentScript.Schoolwear = 1;
								studentScript.ChangeSchoolwear();
								studentScript.MustChangeClothing = false;
							}
							studentScript.SunbathePhase = 0;
						}
						if (studentScript.Meeting && Clock.HourTime > studentScript.MeetTime)
						{
							studentScript.Meeting = false;
						}
						if (studentScript.Club == ClubType.Sports)
						{
							studentScript.SetSplashes(Bool: false);
							studentScript.WalkAnim = studentScript.OriginalWalkAnim;
							studentScript.Character.transform.localPosition = new Vector3(0f, 0f, 0f);
							if (studentScript.Cosmetic.Goggles.Length != 0 && studentScript.Cosmetic.Goggles[studentScript.StudentID].GetComponent<SkinnedMeshRenderer>() != null)
							{
								studentScript.Cosmetic.Goggles[studentScript.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
							}
							if (!studentScript.Cosmetic.Empty && studentScript.Male && studentScript.Cosmetic.MaleHair[studentScript.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>() != null)
							{
								studentScript.Cosmetic.MaleHair[studentScript.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
							}
						}
						if (studentScript.MyPlate != null && studentScript.MyPlate.transform.parent == studentScript.RightHand)
						{
							studentScript.MyPlate.transform.parent = null;
							studentScript.MyPlate.transform.position = studentScript.OriginalPlatePosition;
							studentScript.MyPlate.transform.rotation = studentScript.OriginalPlateRotation;
							studentScript.IdleAnim = studentScript.OriginalIdleAnim;
							studentScript.WalkAnim = studentScript.OriginalWalkAnim;
						}
						if (studentScript.ReturningMisplacedWeapon)
						{
							studentScript.ReturnMisplacedWeapon();
						}
						if (studentScript.UpdateAppearance)
						{
							studentScript.UpdateGemaAppearance();
						}
					}
					else
					{
						if (studentScript.ReportPhase == 9)
						{
							studentScript.DropWeaponInBox();
						}
						if (ID != GymTeacherID && ID != NurseID)
						{
							studentScript.transform.position = Podiums.List[studentScript.Class].position + Vector3.up * 0.01f;
							studentScript.transform.rotation = Podiums.List[studentScript.Class].rotation;
						}
						else
						{
							studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
							studentScript.transform.rotation = studentScript.Seat.rotation;
						}
					}
				}
			}
		}
		UpdateStudents();
		if (GameGlobals.SenpaiMourning)
		{
			Students[1].gameObject.SetActive(value: false);
			Students[1].transform.position = new Vector3(0f, 100f, 0f);
		}
		Physics.SyncTransforms();
		for (int i = 1; i < 10; i++)
		{
			if (ShrineCollectibles[i] != null)
			{
				ShrineCollectibles[i].SetActive(value: true);
			}
		}
		Gift.SetActive(value: false);
	}

	public void SkipTo8()
	{
		while (NPCsSpawned < NPCsTotal)
		{
			SpawnStudent(SpawnID);
			SpawnID++;
		}
		int num = 0;
		int num2 = 0;
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil)
			{
				if (!studentScript.Started)
				{
					studentScript.Start();
				}
				bool flag = false;
				if (MemorialScene.enabled && studentScript.Teacher)
				{
					flag = true;
					studentScript.Teacher = false;
				}
				if (!studentScript.Teacher)
				{
					if (!studentScript.Indoors)
					{
						if (studentScript.ShoeRemoval.Locker == null)
						{
							studentScript.ShoeRemoval.Start();
						}
						studentScript.ShoeRemoval.PutOnShoes();
					}
					studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
					studentScript.transform.rotation = studentScript.Seat.rotation;
					if (studentScript.StudentID == 10 && Students[11] != null)
					{
						studentScript.transform.position = Students[11].transform.position;
					}
					Physics.SyncTransforms();
					studentScript.Pathfinding.canSearch = true;
					studentScript.Pathfinding.canMove = true;
					studentScript.Pathfinding.speed = 1f;
					studentScript.ClubActivityPhase = 0;
					studentScript.Distracted = false;
					studentScript.Spawned = true;
					studentScript.Routine = true;
					studentScript.Safe = false;
					studentScript.SprintAnim = studentScript.OriginalSprintAnim;
					if (studentScript.ClubAttire)
					{
						studentScript.ChangeSchoolwear();
						studentScript.ClubAttire = true;
					}
					studentScript.TeleportToDestination();
					studentScript.TeleportToDestination();
				}
				else
				{
					studentScript.TeleportToDestination();
					studentScript.TeleportToDestination();
				}
				if (MemorialScene.enabled)
				{
					if (flag)
					{
						studentScript.Teacher = true;
					}
					if (studentScript.Persona == PersonaType.PhoneAddict)
					{
						studentScript.SmartPhone.SetActive(value: true);
					}
					if (studentScript.Actions[studentScript.Phase] == StudentActionType.Graffiti && !Bully)
					{
						studentScript.OriginalActions[2] = StudentActionType.Patrol;
						ScheduleBlock obj = studentScript.ScheduleBlocks[2];
						obj.destination = "Patrol";
						obj.action = "Patrol";
						studentScript.GetDestinations();
					}
					studentScript.SpeechLines.Stop();
					studentScript.transform.position = new Vector3(20f + (float)num * 1.1f, 0f, 82 - num2 * 5);
					num2++;
					if (num2 > 4)
					{
						num++;
						num2 = 0;
					}
				}
			}
		}
	}

	public void SkipTo730()
	{
		while (NPCsSpawned < NPCsTotal)
		{
			SpawnStudent(SpawnID);
			SpawnID++;
		}
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && studentScript.Alive && !studentScript.Slave && !studentScript.Tranquil)
			{
				if (!studentScript.Started)
				{
					studentScript.Start();
				}
				if (!studentScript.Teacher)
				{
					if (!studentScript.Indoors)
					{
						if (studentScript.ShoeRemoval.Locker == null)
						{
							studentScript.ShoeRemoval.Start();
						}
						studentScript.ShoeRemoval.PutOnShoes();
					}
					studentScript.transform.position = studentScript.Seat.position + Vector3.up * 0.01f;
					studentScript.transform.rotation = studentScript.Seat.rotation;
					studentScript.Pathfinding.canSearch = true;
					studentScript.Pathfinding.canMove = true;
					studentScript.Pathfinding.speed = 1f;
					studentScript.ClubActivityPhase = 0;
					studentScript.Distracted = false;
					studentScript.Spawned = true;
					studentScript.Routine = true;
					studentScript.Safe = false;
					studentScript.SprintAnim = studentScript.OriginalSprintAnim;
					if (studentScript.ClubAttire)
					{
						studentScript.ChangeSchoolwear();
						studentScript.ClubAttire = true;
					}
					studentScript.AltTeleportToDestination();
					studentScript.AltTeleportToDestination();
				}
				else
				{
					studentScript.AltTeleportToDestination();
					studentScript.AltTeleportToDestination();
				}
			}
		}
		Physics.SyncTransforms();
	}

	public void ResumeMovement()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && !studentScript.Fleeing)
			{
				studentScript.Pathfinding.canSearch = true;
				studentScript.Pathfinding.canMove = true;
				studentScript.Pathfinding.speed = 1f;
				if (!studentScript.TurnOffRadio)
				{
					studentScript.Routine = true;
				}
			}
		}
	}

	public void UpdateAllSleuthClothing()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && studentScript.Persona == PersonaType.Sleuth)
			{
				if (!studentScript.Male)
				{
					studentScript.Cosmetic.SetFemaleUniform();
				}
				else
				{
					studentScript.Cosmetic.SetMaleUniform();
				}
			}
		}
	}

	public void StopMoving()
	{
		Radio.TurnOff();
		CombatMinigame.enabled = false;
		Stop = true;
		if (GameOverIminent)
		{
			Portal.GetComponent<PortalScript>().EndEvents();
			Portal.GetComponent<PortalScript>().EndLaterEvents();
		}
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				if (!studentScript.Dying && !studentScript.PinningDown && !studentScript.Spraying && !studentScript.Struggling && !studentScript.Drowned)
				{
					if (YandereDying && studentScript.Club != ClubType.Council)
					{
						studentScript.IdleAnim = studentScript.ScaredAnim;
					}
					if (Yandere.Attacking)
					{
						if (studentScript.MurderReaction == 0 && !studentScript.Blind)
						{
							studentScript.Character.GetComponent<Animation>().CrossFade(studentScript.ScaredAnim);
						}
					}
					else if (ID > 1 && studentScript.CharacterAnimation != null)
					{
						studentScript.CharacterAnimation.CrossFade(studentScript.IdleAnim);
					}
					studentScript.Pathfinding.canSearch = false;
					studentScript.Pathfinding.canMove = false;
					studentScript.Pathfinding.speed = 0f;
					studentScript.Stop = true;
					if (studentScript.EventManager != null)
					{
						studentScript.EventManager.EndEvent();
					}
				}
				if (studentScript.Alive)
				{
					if (studentScript.SawMask)
					{
						Police.MaskReported = true;
					}
					if (studentScript.Slave && (Yandere.Noticed || Police.DayOver))
					{
						Debug.Log("A mind-broken slave committed suicide.");
						studentScript.Broken.Subtitle.text = string.Empty;
						studentScript.Broken.Done = true;
						UnityEngine.Object.Destroy(studentScript.Broken);
						studentScript.BecomeRagdoll();
						studentScript.Slave = false;
						studentScript.Suicide = true;
						studentScript.DeathType = DeathType.Mystery;
						StudentGlobals.StudentSlave = studentScript.StudentID;
						if (studentScript.MyWeapon != null)
						{
							studentScript.MyWeapon.Victims[studentScript.StudentID] = true;
							studentScript.MyWeapon.transform.parent = null;
							studentScript.MyWeapon.Blood.enabled = true;
							studentScript.MyWeapon.Evidence = true;
							studentScript.MyWeapon.Drop();
							studentScript.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
							studentScript.MyWeapon = null;
						}
					}
				}
			}
		}
	}

	public void TimeFreeze()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && studentScript.Alive)
			{
				studentScript.enabled = false;
				studentScript.CharacterAnimation.Stop();
				studentScript.Pathfinding.canSearch = false;
				studentScript.Pathfinding.canMove = false;
				studentScript.Prompt.Hide();
				studentScript.Prompt.enabled = false;
			}
		}
	}

	public void TimeUnfreeze()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && studentScript.Alive)
			{
				studentScript.enabled = true;
				studentScript.Prompt.enabled = true;
				studentScript.Pathfinding.canSearch = true;
				studentScript.Pathfinding.canMove = true;
			}
		}
	}

	public void ComeBack()
	{
		Stop = false;
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && (!Police.EndOfDay.Counselor.ExpelledDelinquents || ID <= 75 || ID >= 81))
			{
				if (!studentScript.Dying && !studentScript.Replaced && studentScript.Spawned && !StudentGlobals.GetStudentExpelled(ID) && !StudentGlobals.GetStudentArrested(ID) && !studentScript.Ragdoll.Disposed)
				{
					studentScript.gameObject.SetActive(value: true);
					studentScript.Pathfinding.canSearch = true;
					studentScript.Pathfinding.canMove = true;
					studentScript.Pathfinding.speed = 1f;
					studentScript.Stop = false;
				}
				if (studentScript.Teacher)
				{
					studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
					studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
					studentScript.Alarmed = false;
					studentScript.Reacted = false;
					studentScript.Witness = false;
					studentScript.Routine = true;
					studentScript.AlarmTimer = 0f;
					studentScript.Concern = 0;
				}
				if (studentScript.Club == ClubType.Council)
				{
					studentScript.Teacher = false;
				}
				if (studentScript.Slave)
				{
					studentScript.Stop = false;
				}
			}
		}
		UpdateAllAnimLayers();
		if (Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Expelled || Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Arrested)
		{
			Students[RivalID].gameObject.SetActive(value: false);
		}
		if (GameGlobals.SenpaiMourning)
		{
			Students[1].gameObject.SetActive(value: false);
		}
		Yandere.SetAnimationLayers();
	}

	public void StopFleeing()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && !studentScript.Teacher)
			{
				studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
				studentScript.Pathfinding.speed = 1f;
				studentScript.WitnessedCorpse = false;
				studentScript.WitnessedMurder = false;
				studentScript.Alarmed = false;
				studentScript.Fleeing = false;
				studentScript.Reacted = false;
				studentScript.Witness = false;
				studentScript.Routine = true;
			}
		}
	}

	public void EnablePrompts()
	{
		for (ID = 2; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.Prompt.enabled = true;
			}
		}
	}

	public void DisablePrompts()
	{
		for (ID = 2; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.Prompt.Hide();
				studentScript.Prompt.enabled = false;
			}
		}
	}

	public void WipePendingRep()
	{
		for (ID = 2; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.PendingRep = 0f;
			}
		}
	}

	public void AttackOnTitan()
	{
		RandomizeRoutines();
		Students[1].Blind = true;
		AoT = true;
		for (ID = 2; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.AttackOnTitan();
			}
		}
	}

	public void Kong()
	{
		DK = true;
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.DK = true;
			}
		}
	}

	public void Spook()
	{
		Spooky = true;
		for (ID = 2; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && !studentScript.Male)
			{
				studentScript.Spook();
			}
		}
	}

	public void BadTime()
	{
		Sans = true;
		for (ID = 2; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.Prompt.HideButton[0] = false;
				studentScript.BadTime = true;
			}
		}
	}

	public void UpdateBooths()
	{
		for (ID = 0; ID < ChangingBooths.Length; ID++)
		{
			ChangingBoothScript changingBoothScript = ChangingBooths[ID];
			if (changingBoothScript != null)
			{
				changingBoothScript.CheckYandereClub();
			}
		}
	}

	public void UpdatePerception()
	{
		for (ID = 0; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.UpdatePerception();
			}
		}
	}

	public void DespawnAllStudents()
	{
		for (ID = 0; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.Prompt.Hide();
				UnityEngine.Object.Destroy(studentScript.Prompt.gameObject);
				UnityEngine.Object.Destroy(studentScript.gameObject);
			}
			Students[ID] = null;
		}
	}

	public void StopHesitating()
	{
		for (ID = 0; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				if (studentScript.AlarmTimer > 0f)
				{
					studentScript.AlarmTimer = 1f;
				}
				studentScript.Hesitation = 0f;
			}
		}
	}

	public void Unstop()
	{
		for (ID = 0; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.Stop = false;
			}
		}
	}

	public void LowerCorpsePosition()
	{
		float num = 0f;
		Debug.Log("Corpse's Y position is: " + CorpseLocation.position.y);
		num = ((CorpseLocation.position.y > 1.4f && CorpseLocation.position.y < 1.6f) ? 1.4f : ((CorpseLocation.position.y < 2f) ? 0f : ((CorpseLocation.position.y < 4f) ? 2f : ((CorpseLocation.position.y < 6f) ? 4f : ((CorpseLocation.position.y < 8f) ? 6f : ((CorpseLocation.position.y < 10f) ? 8f : ((!(CorpseLocation.position.y < 12f)) ? 12f : 10f)))))));
		CorpseLocation.position = new Vector3(CorpseLocation.position.x, num, CorpseLocation.position.z);
		Debug.Log("CorpseLocation's Height has been set to: " + num);
	}

	public void LowerBloodPosition()
	{
		int num = 0;
		num = ((!(BloodLocation.position.y < 2f)) ? ((BloodLocation.position.y < 4f) ? 2 : ((BloodLocation.position.y < 6f) ? 4 : ((BloodLocation.position.y < 8f) ? 6 : ((BloodLocation.position.y < 10f) ? 8 : ((!(BloodLocation.position.y < 12f)) ? 12 : 10))))) : 0);
		BloodLocation.position = new Vector3(BloodLocation.position.x, num, BloodLocation.position.z);
	}

	public void CensorStudents()
	{
		for (ID = 0; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && !studentScript.Male && studentScript.Club != ClubType.Teacher && studentScript.Club != ClubType.GymTeacher && studentScript.Club != ClubType.Nurse)
			{
				if (GameGlobals.CensorPanties)
				{
					studentScript.Cosmetic.CensorPanties();
				}
				else
				{
					studentScript.Cosmetic.RemoveCensor();
				}
			}
		}
	}

	private void OccupySeat()
	{
		int @class = JSON.Students[SpawnID].Class;
		int seat = JSON.Students[SpawnID].Seat;
		switch (@class)
		{
		case 11:
			SeatsTaken11[seat] = true;
			break;
		case 12:
			SeatsTaken12[seat] = true;
			break;
		case 21:
			SeatsTaken21[seat] = true;
			break;
		case 22:
			SeatsTaken22[seat] = true;
			break;
		case 31:
			SeatsTaken31[seat] = true;
			break;
		case 32:
			SeatsTaken32[seat] = true;
			break;
		}
	}

	private void FindUnoccupiedSeat()
	{
		SeatOccupied = false;
		if (Class == 1)
		{
			JSON.Students[SpawnID].Class = 11;
			ID = 1;
			while (ID < SeatsTaken11.Length && !SeatOccupied)
			{
				if (!SeatsTaken11[ID])
				{
					JSON.Students[SpawnID].Seat = ID;
					SeatsTaken11[ID] = true;
					SeatOccupied = true;
				}
				ID++;
				if (ID > 15)
				{
					Class++;
				}
			}
		}
		else if (Class == 2)
		{
			JSON.Students[SpawnID].Class = 12;
			ID = 1;
			while (ID < SeatsTaken12.Length && !SeatOccupied)
			{
				if (!SeatsTaken12[ID])
				{
					JSON.Students[SpawnID].Seat = ID;
					SeatsTaken12[ID] = true;
					SeatOccupied = true;
				}
				ID++;
				if (ID > 15)
				{
					Class++;
				}
			}
		}
		else if (Class == 3)
		{
			JSON.Students[SpawnID].Class = 21;
			ID = 1;
			while (ID < SeatsTaken21.Length && !SeatOccupied)
			{
				if (!SeatsTaken21[ID])
				{
					JSON.Students[SpawnID].Seat = ID;
					SeatsTaken21[ID] = true;
					SeatOccupied = true;
				}
				ID++;
				if (ID > 15)
				{
					Class++;
				}
			}
		}
		else if (Class == 4)
		{
			JSON.Students[SpawnID].Class = 22;
			ID = 1;
			while (ID < SeatsTaken22.Length && !SeatOccupied)
			{
				if (!SeatsTaken22[ID])
				{
					JSON.Students[SpawnID].Seat = ID;
					SeatsTaken22[ID] = true;
					SeatOccupied = true;
				}
				ID++;
				if (ID > 15)
				{
					Class++;
				}
			}
		}
		else if (Class == 5)
		{
			JSON.Students[SpawnID].Class = 31;
			ID = 1;
			while (ID < SeatsTaken31.Length && !SeatOccupied)
			{
				if (!SeatsTaken31[ID])
				{
					JSON.Students[SpawnID].Seat = ID;
					SeatsTaken31[ID] = true;
					SeatOccupied = true;
				}
				ID++;
				if (ID > 15)
				{
					Class++;
				}
			}
		}
		else if (Class == 6)
		{
			JSON.Students[SpawnID].Class = 32;
			ID = 1;
			while (ID < SeatsTaken32.Length && !SeatOccupied)
			{
				if (!SeatsTaken32[ID])
				{
					JSON.Students[SpawnID].Seat = ID;
					SeatsTaken32[ID] = true;
					SeatOccupied = true;
				}
				ID++;
				if (ID > 15)
				{
					Class++;
				}
			}
		}
		if (!SeatOccupied)
		{
			FindUnoccupiedSeat();
		}
	}

	public void PinDownCheck()
	{
		if (PinningDown || Witnesses <= 3)
		{
			return;
		}
		for (ID = 1; ID < WitnessList.Length; ID++)
		{
			StudentScript studentScript = WitnessList[ID];
			if (studentScript != null && (!studentScript.Alive || studentScript.Attacked || studentScript.Fleeing || studentScript.Dying || studentScript.Routine || studentScript.Persona == PersonaType.Coward))
			{
				studentScript = null;
				if (ID != WitnessList.Length - 1)
				{
					Shuffle(ID);
				}
				Witnesses--;
			}
		}
		if (Witnesses > 3)
		{
			PinningDown = true;
			PinPhase = 1;
		}
	}

	private void Shuffle(int Start)
	{
		for (int i = Start; i < WitnessList.Length - 1; i++)
		{
			WitnessList[i] = WitnessList[i + 1];
		}
	}

	public void RemovePapersFromDesks()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && studentScript.MyPaper != null)
			{
				studentScript.MyPaper.SetActive(value: false);
			}
		}
	}

	public void SetStudentsActive(bool active)
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.gameObject.SetActive(active);
			}
		}
	}

	public void AssignTeachers()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.MyTeacher = Teachers[JSON.Students[studentScript.StudentID].Class];
			}
		}
	}

	public void ToggleBookBags()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.BookBag.SetActive(!studentScript.BookBag.activeInHierarchy);
			}
		}
	}

	public void DetermineVictim()
	{
		Bully = false;
		for (ID = 2; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && StudentReps[ID] < -33.33333f && (ID != 36 || TaskManager.TaskStatus[36] != 3) && !studentScript.Teacher && !studentScript.Slave && studentScript.Club != ClubType.Bully && studentScript.Club != ClubType.Council && studentScript.Club != ClubType.Photography && studentScript.Club != ClubType.Delinquent && StudentReps[ID] < LowestRep)
			{
				bool flag = false;
				if (!Eighties && ID == 11)
				{
					flag = true;
					if (Students[10] == null)
					{
						flag = false;
					}
					else if (Students[10].FollowTarget == null)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					LowestRep = StudentReps[ID];
					VictimID = ID;
					Bully = true;
				}
			}
		}
		if (Bully)
		{
			Debug.Log(Students[VictimID].Name + " has been selected for bullying. Changing routine.");
			if (Students[VictimID].Seat.position.x > 0f)
			{
				BullyGroup.position = Students[VictimID].Seat.position + new Vector3(0.33333f, 0f, 0f);
			}
			else
			{
				BullyGroup.position = Students[VictimID].Seat.position - new Vector3(0.33333f, 0f, 0f);
				BullyGroup.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			StudentScript studentScript2 = Students[VictimID];
			if (!Students[VictimID].Rival)
			{
				ScheduleBlock obj = studentScript2.ScheduleBlocks[2];
				obj.destination = "ShameSpot";
				obj.action = "Shamed";
				obj.time = 8f;
			}
			ScheduleBlock obj2 = studentScript2.ScheduleBlocks[4];
			obj2.destination = "Seat";
			obj2.action = "Sit";
			ScheduleBlock obj3 = studentScript2.ScheduleBlocks[7];
			obj3.destination = "Exit";
			obj3.action = "Exit";
			if (studentScript2.Male)
			{
				studentScript2.ChemistScanner.MyRenderer.materials[1].mainTexture = studentScript2.ChemistScanner.SadEyes;
				studentScript2.ChemistScanner.enabled = false;
			}
			studentScript2.IdleAnim = studentScript2.BulliedIdleAnim;
			studentScript2.WalkAnim = studentScript2.BulliedWalkAnim;
			studentScript2.Bullied = true;
			studentScript2.GetDestinations();
			studentScript2.CameraAnims = studentScript2.CowardAnims;
			studentScript2.BusyAtLunch = true;
			studentScript2.Shy = false;
		}
	}

	public void SecurityCameras()
	{
		Egg = true;
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && studentScript.SecurityCamera != null && studentScript.Alive)
			{
				Debug.Log("Enabling security camera on this character's head.");
				studentScript.SecurityCamera.SetActive(value: true);
			}
		}
	}

	public void DisableEveryone()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && !studentScript.Ragdoll.enabled)
			{
				studentScript.gameObject.SetActive(value: false);
			}
		}
	}

	public void DisableStudent(int DisableID)
	{
		StudentScript studentScript = Students[DisableID];
		if (studentScript != null)
		{
			if (studentScript.gameObject.activeInHierarchy)
			{
				studentScript.gameObject.SetActive(value: false);
			}
			else
			{
				studentScript.gameObject.SetActive(value: true);
				UpdateOneAnimLayer(DisableID);
				Students[DisableID].ReadPhase = 0;
			}
		}
		if (Eighties && DisableID == 100)
		{
			Journalist.SetActive(!Journalist.activeInHierarchy);
		}
	}

	public void UpdateOneAnimLayer(int DisableID)
	{
		Students[DisableID].UpdateAnimLayers();
		Students[DisableID].ReadPhase = 0;
	}

	public void UpdateAllAnimLayers()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.UpdateAnimLayers();
				studentScript.ReadPhase = 0;
			}
		}
	}

	public void UpdateGraffiti()
	{
		for (ID = 1; ID < 6; ID++)
		{
			if (!NoBully[ID])
			{
				Graffiti[ID].SetActive(value: true);
			}
		}
	}

	public void UpdateAllBentos()
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null && !studentScript.MyBento.Tampered)
			{
				studentScript.MyBento.Prompt.Yandere = Yandere;
				studentScript.MyBento.UpdatePrompts();
			}
		}
	}

	public void UpdateSleuths()
	{
		SleuthPhase++;
		for (ID = 56; ID < 61; ID++)
		{
			if (Students[ID] != null && Students[ID].Actions[Students[ID].Phase] == StudentActionType.Sleuth && Students[ID].Routine && !Students[ID].Slave && !Students[ID].Following && !Students[ID].Meeting && !Students[ID].SentToLocker)
			{
				if (SleuthPhase < 3)
				{
					Students[ID].SleuthTarget = SleuthDestinations[ID - 55];
					Students[ID].Pathfinding.target = Students[ID].SleuthTarget;
					Students[ID].CurrentDestination = Students[ID].SleuthTarget;
				}
				else if (SleuthPhase == 3)
				{
					Students[ID].GetSleuthTarget();
				}
				else if (SleuthPhase == 4)
				{
					Students[ID].SleuthTarget = Clubs.List[ID];
					Students[ID].Pathfinding.target = Students[ID].SleuthTarget;
					Students[ID].CurrentDestination = Students[ID].SleuthTarget;
				}
				if (!Students[ID].Phoneless)
				{
					Students[ID].SmartPhone.SetActive(value: true);
				}
				Students[ID].SpeechLines.Stop();
			}
		}
	}

	public void UpdateDrama()
	{
		if (MemorialScene.gameObject.activeInHierarchy)
		{
			return;
		}
		DramaPhase++;
		for (ID = 26; ID < 31; ID++)
		{
			if (Students[ID] != null)
			{
				if (DramaPhase == 1)
				{
					Clubs.List[ID].position = OriginalClubPositions[ID - 25];
					Clubs.List[ID].rotation = OriginalClubRotations[ID - 25];
					Students[ID].ClubAnim = Students[ID].OriginalClubAnim;
				}
				else if (DramaPhase == 2)
				{
					Clubs.List[ID].position = DramaSpots[ID - 25].position;
					Clubs.List[ID].rotation = DramaSpots[ID - 25].rotation;
					if (ID == 26)
					{
						Students[ID].ClubAnim = Students[ID].ActAnim;
					}
					else if (ID == 27)
					{
						Students[ID].ClubAnim = Students[ID].ThinkAnim;
					}
					else if (ID == 28)
					{
						Students[ID].ClubAnim = Students[ID].ThinkAnim;
					}
					else if (ID == 29)
					{
						Students[ID].ClubAnim = Students[ID].ActAnim;
					}
					else if (ID == 30)
					{
						Students[ID].ClubAnim = Students[ID].ThinkAnim;
					}
				}
				else if (DramaPhase == 3)
				{
					Clubs.List[ID].position = BackstageSpots[ID - 25].position;
					Clubs.List[ID].rotation = BackstageSpots[ID - 25].rotation;
				}
				else if (DramaPhase == 4)
				{
					DramaPhase = 1;
					UpdateDrama();
				}
				Students[ID].DistanceToDestination = 100f;
				Students[ID].SmartPhone.SetActive(value: false);
				Students[ID].SpeechLines.Stop();
			}
		}
	}

	public void UpdateMartialArts()
	{
		ConvoManager.BothCharactersInPosition = false;
		MartialArtsPhase++;
		for (ID = 46; ID < 51; ID++)
		{
			if (Students[ID] != null)
			{
				if (MartialArtsPhase == 1)
				{
					Clubs.List[ID].position = MartialArtsSpots[ID - 45].position;
					Clubs.List[ID].rotation = MartialArtsSpots[ID - 45].rotation;
				}
				else if (MartialArtsPhase == 2)
				{
					Clubs.List[ID].position = MartialArtsSpots[ID - 40].position;
					Clubs.List[ID].rotation = MartialArtsSpots[ID - 40].rotation;
				}
				else if (MartialArtsPhase == 3)
				{
					Clubs.List[ID].position = MartialArtsSpots[ID - 35].position;
					Clubs.List[ID].rotation = MartialArtsSpots[ID - 35].rotation;
				}
				else if (MartialArtsPhase == 4)
				{
					MartialArtsPhase = 0;
					UpdateMartialArts();
				}
				Students[ID].DistanceToDestination = 100f;
				Students[ID].SmartPhone.SetActive(value: false);
				Students[ID].SpeechLines.Stop();
			}
		}
		RaibaruMentorSpot.position = Clubs.List[46].position + Clubs.List[46].forward * 0.5f + Clubs.List[46].right * 0.5f;
		RaibaruMentorSpot.rotation = Clubs.List[46].rotation;
		if (Students[10] != null && Students[10].CurrentAction != StudentActionType.Follow && Students[10].DistanceToDestination < 1f)
		{
			Students[10].Pathfinding.speed = 1f;
			Students[10].SpeechLines.Stop();
			Students[10].Hurry = false;
		}
	}

	public void UpdateMeeting()
	{
		MeetingTimer += Time.deltaTime;
		if (MeetingTimer > 5f)
		{
			Speaker += 5;
			if (Speaker == 91)
			{
				Speaker = 21;
			}
			else if (Speaker == 76)
			{
				Speaker = 86;
			}
			else if (Speaker == 36)
			{
				Speaker = 41;
			}
			MeetingTimer = 0f;
		}
	}

	public void CheckMusic()
	{
		int num = 0;
		for (ID = 51; ID < 56; ID++)
		{
			if (Students[ID] != null && Students[ID].Routine && Students[ID].DistanceToDestination < 0.1f)
			{
				num++;
			}
		}
		if (num == 5)
		{
			if (!Police.FadeOut && !Police.FadeResults)
			{
				PracticeVocals.pitch = Time.timeScale;
				PracticeMusic.pitch = Time.timeScale;
			}
			else
			{
				PracticeVocals.pitch = 1f;
				PracticeMusic.pitch = 1f;
			}
			if (!PracticeMusic.isPlaying)
			{
				PracticeVocals.Play();
				PracticeMusic.Play();
			}
		}
		else
		{
			PracticeVocals.Stop();
			PracticeMusic.Stop();
		}
	}

	public void UpdateAprons()
	{
		for (ID = 21; ID < 26; ID++)
		{
			if (Students[ID] != null && Students[ID].ClubMemberID > 0 && Students[ID].ApronAttacher != null && Students[ID].ApronAttacher.newRenderer != null)
			{
				if (!Eighties)
				{
					Students[ID].ApronAttacher.newRenderer.material.mainTexture = Students[ID].Cosmetic.ApronTextures[Students[ID].ClubMemberID];
				}
				else
				{
					Students[ID].ApronAttacher.newRenderer.material.mainTexture = Students[ID].Cosmetic.EightiesApronTextures[Students[ID].ClubMemberID];
				}
			}
		}
		if (Students[12] != null && Students[12].ApronAttacher != null && Students[12].ApronAttacher.newRenderer != null)
		{
			Students[12].ApronAttacher.newRenderer.material.mainTexture = Students[12].Cosmetic.AmaiApron;
		}
	}

	public void PreventAlarm()
	{
		for (ID = 1; ID < 101; ID++)
		{
			if (Students[ID] != null)
			{
				Students[ID].Alarm = 0f;
			}
		}
	}

	public void VolumeDown()
	{
		for (ID = 51; ID < 56; ID++)
		{
			if (Students[ID] != null && Students[ID].Instruments[Students[ID].ClubMemberID] != null)
			{
				Students[ID].Instruments[Students[ID].ClubMemberID].GetComponent<AudioSource>().volume = 0.2f;
			}
		}
	}

	public void VolumeUp()
	{
		for (ID = 51; ID < 56; ID++)
		{
			if (Students[ID] != null && Students[ID].Instruments[Students[ID].ClubMemberID] != null)
			{
				Students[ID].Instruments[Students[ID].ClubMemberID].GetComponent<AudioSource>().volume = 1f;
			}
		}
	}

	public void GetMaleVomitSpot(StudentScript VomitStudent)
	{
		MaleVomitSpot = MaleVomitSpots[1];
		VomitStudent.VomitDoor = MaleToiletDoors[1];
		for (ID = 2; ID < 7; ID++)
		{
			if (Vector3.Distance(VomitStudent.transform.position, MaleVomitSpots[ID].position) < Vector3.Distance(VomitStudent.transform.position, MaleVomitSpot.position))
			{
				MaleVomitSpot = MaleVomitSpots[ID];
				VomitStudent.VomitDoor = MaleToiletDoors[ID];
			}
		}
	}

	public void GetFemaleVomitSpot(StudentScript VomitStudent)
	{
		FemaleVomitSpot = FemaleVomitSpots[1];
		VomitStudent.VomitDoor = FemaleToiletDoors[1];
		for (ID = 2; ID < 7; ID++)
		{
			if (Vector3.Distance(VomitStudent.transform.position, FemaleVomitSpots[ID].position) < Vector3.Distance(VomitStudent.transform.position, FemaleVomitSpot.position))
			{
				FemaleVomitSpot = FemaleVomitSpots[ID];
				VomitStudent.VomitDoor = FemaleToiletDoors[ID];
			}
		}
		if (KokonaTutorial)
		{
			FemaleVomitSpot = FemaleVomitSpots[0];
		}
	}

	public void GetMaleWashSpot(StudentScript VomitStudent)
	{
		Transform transform = MaleWashSpots[1];
		for (ID = 2; ID < 7; ID++)
		{
			if (Vector3.Distance(VomitStudent.transform.position, MaleWashSpots[ID].position) < Vector3.Distance(VomitStudent.transform.position, transform.position))
			{
				transform = MaleWashSpots[ID];
			}
		}
		MaleWashSpot = transform;
	}

	public void GetFemaleWashSpot(StudentScript VomitStudent)
	{
		Transform transform = FemaleWashSpots[1];
		for (ID = 2; ID < 7; ID++)
		{
			if (Vector3.Distance(VomitStudent.transform.position, FemaleWashSpots[ID].position) < Vector3.Distance(VomitStudent.transform.position, transform.position))
			{
				transform = FemaleWashSpots[ID];
			}
		}
		FemaleWashSpot = transform;
	}

	public void GetNearestFountain(StudentScript Student)
	{
		DrinkingFountainScript drinkingFountainScript = DrinkingFountains[1];
		bool flag = false;
		ID = 1;
		while (drinkingFountainScript.Occupied)
		{
			drinkingFountainScript = DrinkingFountains[1 + ID];
			ID++;
			if (1 + ID == DrinkingFountains.Length)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Student.EquipCleaningItems();
			Student.EatingSnack = false;
			Student.Private = false;
			Student.Routine = true;
			Student.StudentManager.UpdateMe(Student.StudentID);
			Student.CurrentDestination = Student.Destinations[Student.Phase];
			Student.Pathfinding.target = Student.Destinations[Student.Phase];
			return;
		}
		for (ID = 1; ID < DrinkingFountains.Length; ID++)
		{
			if (Vector3.Distance(Student.transform.position, DrinkingFountains[ID].transform.position) < Vector3.Distance(Student.transform.position, drinkingFountainScript.transform.position) && !DrinkingFountains[ID].Occupied)
			{
				drinkingFountainScript = DrinkingFountains[ID];
			}
		}
		Student.DrinkingFountain = drinkingFountainScript;
		Student.DrinkingFountain.Occupied = true;
	}

	public void Save()
	{
		SaveAllStudentPositions();
		int profile = GameGlobals.Profile;
		int @int = PlayerPrefs.GetInt("SaveSlot");
		BloodParent.RecordAllBlood();
		PuddleParent.RecordAllPuddles();
		GenericRivalBag.RememberBentoStatus();
		SpawnedObjectManager.RememberObjects();
		RivalMorningEventManagerScript[] morningEvents = Yandere.Class.Portal.MorningEvents;
		for (int i = 0; i < morningEvents.Length; i++)
		{
			morningEvents[i].SaveAnimationTime();
		}
		Debug.Log("At the moment of saving, PhotoGallery.PhotographTaken[1] was: " + Yandere.PauseScreen.PhotoGallery.PhotographTaken[1]);
		Yandere.PauseScreen.PhotoGallery.gameObject.SetActive(value: true);
		YanSave.SaveData("Profile_" + profile + "_Slot_" + @int);
		PlayerPrefs.SetInt("Profile_" + profile + "_Slot_" + @int + "_MemorialStudents", StudentGlobals.MemorialStudents);
		Yandere.PauseScreen.PhotoGallery.gameObject.SetActive(value: false);
		Debug.Log("At the time of saving, StudentManager's GloveID was: " + GloveID);
	}

	public void Load()
	{
		Eighties = GameGlobals.Eighties;
		DoorScript[] doors = Doors;
		foreach (DoorScript doorScript in doors)
		{
			if (doorScript != null)
			{
				doorScript.Start();
			}
		}
		Debug.Log("Now loading save data.");
		int profile = GameGlobals.Profile;
		int @int = PlayerPrefs.GetInt("SaveSlot");
		Yandere.Class.gameObject.SetActive(value: true);
		Yandere.PauseScreen.PhotoGallery.gameObject.SetActive(value: true);
		YanSave.LoadData("Profile_" + profile + "_Slot_" + @int);
		Yandere.PauseScreen.PhotoGallery.gameObject.SetActive(value: false);
		Yandere.Class.gameObject.SetActive(value: false);
		Physics.SyncTransforms();
		Yandere.Incinerator.ReturnFromSave();
		for (ID = 1; ID < 101; ID++)
		{
			if (Students[ID] != null)
			{
				if (Students[ID].Schoolwear != 1)
				{
					Debug.Log("At time of loading, " + Students[ID].Name + " needed to change clothing.");
					Students[ID].ChangeSchoolwear();
				}
				if (!Students[ID].Alive)
				{
					Debug.Log(Students[ID].Name + " is confirmed to be dead. Transforming them into a ragdoll now.");
					if (Students[ID].Rival)
					{
						Students[ID].MapMarker.gameObject.SetActive(value: false);
					}
					Vector3 localPosition = Students[ID].Hips.localPosition;
					Quaternion localRotation = Students[ID].Hips.localRotation;
					Students[ID].Ragdoll.Yandere = Yandere;
					Students[ID].BecomeRagdoll();
					GameObjectUtils.SetLayerRecursively(Students[ID].gameObject, 0);
					Students[ID].Ragdoll.UpdateNextFrame = true;
					Students[ID].Ragdoll.NextPosition = localPosition;
					Students[ID].Ragdoll.NextRotation = localRotation;
					Students[ID].Ragdoll.CharacterAnimation = Students[ID].CharacterAnimation;
					Students[ID].MyRenderer.updateWhenOffscreen = true;
					Students[ID].CharacterAnimation.enabled = false;
					Students[ID].MyController.enabled = false;
					Students[ID].Pathfinding.enabled = false;
					Students[ID].HipCollider.enabled = true;
					if (!StudentGlobals.GetStudentDying(ID))
					{
						Debug.Log("For some reason, " + Students[ID].Name + " may not have been added to the Police CorpseList, so we're doing it manually.");
						Police.CorpseList[Police.Corpses] = Students[ID].Ragdoll;
						Police.Corpses++;
						Police.Deaths++;
						if (Students[ID].Removed)
						{
							Debug.Log("Oh, wait! " + Students[ID].Name + " should be removed from the Police CorpseList. Removing her now.");
							Students[ID].Ragdoll.Remove();
							Police.Corpses--;
						}
					}
					else
					{
						Debug.Log("It looks like " + Students[ID].Name + " has already added themself to the Police CorpseList, so we won't be doing that manually.");
						if (Students[ID].Removed)
						{
							Debug.Log(Students[ID].Name + "'s ''Removed'' boolean was true, so we're removing them from the Police CorpseList.");
							Students[ID].Ragdoll.Remove();
							Police.Corpses--;
						}
					}
				}
				else
				{
					Students[ID].ReturningFromSave = true;
					Students[ID].PhaseFromSave = Students[ID].Phase;
					if (Students[ID].ChangingShoes)
					{
						Students[ID].ShoeRemoval.enabled = true;
					}
					if (!Students[ID].Teacher && Students[ID].Indoors)
					{
						if (Students[ID].ShoeRemoval.Locker == null)
						{
							Students[ID].ShoeRemoval.Start();
						}
						Students[ID].ShoeRemoval.PutOnShoes();
					}
					if (Students[ID].ClubAttire)
					{
						int clubActivityPhase = Students[ID].ClubActivityPhase;
						Students[ID].ClubAttire = false;
						if (Students[ID].ClubActivityPhase > 14)
						{
							if (Students[ID].ClubActivityPhase == 18 || Students[ID].ClubActivityPhase == 19)
							{
								Students[ID].Destinations[Students[ID].Phase] = Clubs.List[ID].GetChild(Students[ID].ClubActivityPhase - 2);
								Students[ID].Destinations[Students[ID].Phase + 1] = Clubs.List[ID].GetChild(Students[ID].ClubActivityPhase - 2);
								Students[ID].CurrentDestination = Clubs.List[ID].GetChild(Students[ID].ClubActivityPhase - 2);
								Students[ID].Pathfinding.target = Clubs.List[ID].GetChild(Students[ID].ClubActivityPhase - 2);
								Students[ID].Character.transform.localPosition = new Vector3(0f, -0.25f, 0f);
								Students[ID].CurrentAction = StudentActionType.ClubAction;
								Students[ID].WalkAnim = "poolSwim_00";
								Students[ID].ClubAnim = "poolSwim_00";
								Students[ID].SetSplashes(Bool: true);
								Students[ID].Phase++;
							}
							Clock.Period = 3;
						}
						Students[ID].ChangeClubwear();
						if (Students[ID].ClubActivityPhase > 14)
						{
							Students[ID].ClubActivityPhase = clubActivityPhase;
						}
					}
					if (Students[ID].Defeats > 0)
					{
						Students[ID].IdleAnim = "idleInjured_00";
						Students[ID].WalkAnim = "walkInjured_00";
						Students[ID].OriginalIdleAnim = Students[ID].IdleAnim;
						Students[ID].OriginalWalkAnim = Students[ID].WalkAnim;
						Students[ID].LeanAnim = Students[ID].IdleAnim;
						Students[ID].CharacterAnimation.CrossFade(Students[ID].IdleAnim);
						Students[ID].Injured = true;
						Students[ID].Strength = 0;
						ScheduleBlock obj = Students[ID].ScheduleBlocks[2];
						obj.destination = "Sulk";
						obj.action = "Sulk";
						ScheduleBlock obj2 = Students[ID].ScheduleBlocks[4];
						obj2.destination = "Sulk";
						obj2.action = "Sulk";
						ScheduleBlock obj3 = Students[ID].ScheduleBlocks[6];
						obj3.destination = "Sulk";
						obj3.action = "Sulk";
						ScheduleBlock obj4 = Students[ID].ScheduleBlocks[7];
						obj4.destination = "Sulk";
						obj4.action = "Sulk";
						Students[ID].GetDestinations();
					}
					if (Students[ID].Actions[Students[ID].Phase] == StudentActionType.ClubAction && Students[ID].Club == ClubType.Cooking && Students[ID].ClubActivityPhase > 0)
					{
						Debug.Log("Upon loading, " + Students[ID].Name + "'s FoodTarget was Student #" + Students[ID].SleuthID + " : " + Students[Students[ID].SleuthID].Name + ".");
						Students[Students[ID].SleuthID].TargetedForDistraction = false;
					}
					else if (Students[ID].Phase > 1)
					{
						Students[ID].Phase--;
					}
					if (OsanaPoolEvent.Phase > 2)
					{
						OsanaPoolEvent.ReturnFromSave();
					}
					if (Students[ID].MeetTime > 0f)
					{
						Debug.Log("A student was planning to meet someone when this save file was made. Attempting to update their schedule accordingly.");
						NoteWindow.NoteLocker.StudentID = MeetStudentID;
						NoteWindow.NoteLocker.MeetTime = MeetTime;
						NoteWindow.NoteLocker.MeetID = MeetID;
						NoteWindow.NoteLocker.DetermineSchedule();
					}
					if (Students[ID].Vomiting)
					{
						Students[ID].CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
						if (Students[ID].Male)
						{
							Students[ID].WalkAnim = "stomachPainWalk_00";
							Students[ID].Pathfinding.target = MaleVomitSpot;
							Students[ID].CurrentDestination = MaleVomitSpot;
						}
						else
						{
							Students[ID].WalkAnim = "f02_stomachPainWalk_00";
							Students[ID].Pathfinding.target = FemaleVomitSpot;
							Students[ID].CurrentDestination = FemaleVomitSpot;
						}
						if (Students[ID].StudentID == 10)
						{
							Students[ID].Pathfinding.target = AltFemaleVomitSpot;
							Students[ID].CurrentDestination = AltFemaleVomitSpot;
							Students[ID].VomitDoor = AltFemaleVomitDoor;
						}
						Students[ID].CharacterAnimation.CrossFade(Students[ID].WalkAnim);
						Students[ID].DistanceToDestination = 100f;
						Students[ID].Pathfinding.canSearch = true;
						Students[ID].Pathfinding.canMove = true;
						Students[ID].Pathfinding.speed = 2f;
						Students[ID].MyBento.Tampered = false;
						Students[ID].Routine = false;
						Students[ID].Chopsticks[0].SetActive(value: false);
						Students[ID].Chopsticks[1].SetActive(value: false);
						Students[ID].Bento.SetActive(value: false);
					}
					if (Students[ID].Routine && Students[ID].StudentID == 10)
					{
						Students[ID].GetDestinations();
						Students[ID].CurrentAction = Students[ID].Actions[Students[ID].Phase];
						Students[ID].CurrentDestination = Students[ID].Destinations[Students[ID].Phase];
						Students[ID].Pathfinding.target = Students[ID].Destinations[Students[ID].Phase];
					}
					Students[ID].CameraReacting = false;
				}
			}
		}
		Clock.UpdateClock();
		Clock.UpdateBloom = true;
		Alphabet.UpdateText();
		ClubManager.ActivateClubBenefit();
		UnequipImmediately = false;
		if (!Yandere.Armed)
		{
			UnequipImmediately = true;
		}
		Yandere.CanMove = true;
		Yandere.ClubAccessory();
		Yandere.Inventory.UpdateMoney();
		Yandere.WeaponManager.EquipWeaponsFromSave();
		Yandere.WeaponManager.RestoreWeaponToStudent();
		Yandere.WeaponManager.UpdateDelinquentWeapons();
		Yandere.WeaponManager.RestoreBlood();
		Yandere.ImmunityTimer = 1f;
		Yandere.ChangeSchoolwear();
		Mirror.UpdatePersona();
		if (Yandere.ClubAttire)
		{
			Yandere.ClubAttire = false;
			Yandere.ChangeClubwear();
		}
		doors = Doors;
		foreach (DoorScript doorScript2 in doors)
		{
			if (doorScript2 != null && doorScript2.enabled && doorScript2.Open)
			{
				doorScript2.OpenDoor();
			}
		}
		BugScript[] bugs = Bugs;
		foreach (BugScript bugScript in bugs)
		{
			if (bugScript != null)
			{
				bugScript.CheckStatus();
			}
		}
		BucketScript[] allBuckets = AllBuckets;
		foreach (BucketScript bucketScript in allBuckets)
		{
			if (bucketScript != null)
			{
				bucketScript.UpdateAppearance = true;
			}
		}
		BodyHidingLockerScript[] bodyHidingLockers = BodyHidingLockers;
		foreach (BodyHidingLockerScript bodyHidingLockerScript in bodyHidingLockers)
		{
			if (bodyHidingLockerScript != null && bodyHidingLockerScript.StudentID > 0)
			{
				bodyHidingLockerScript.UpdateCorpse();
			}
		}
		BloodParent.RestoreAllBlood();
		PuddleParent.RestoreAllPuddles();
		if (OsanaThursdayAfterClassEvent.Phase > 0)
		{
			OsanaThursdayAfterClassEvent.ReturningFromSave = true;
		}
		if (Students[10] != null && Students[10].Cheer != null)
		{
			Students[10].Cheer.enabled = false;
		}
		if (Yandere.Gloved)
		{
			Yandere.Gloves = GloveList[GloveID];
			Yandere.WearingRaincoat = Yandere.Gloves.Raincoat;
			int hairstyleBeforeRaincoat = Yandere.HairstyleBeforeRaincoat;
			Yandere.WearGloves();
			Yandere.HairstyleBeforeRaincoat = hairstyleBeforeRaincoat;
		}
		if (DramaPhase > 1)
		{
			Debug.Log("When loading, DramaPhase was " + DramaPhase + ". So, we are attempting to restore that DramaPhase now.");
			DramaPhase--;
			UpdateDrama();
		}
		if (Police.EndOfDay.TranqCase.VictimID > 0)
		{
			Students[Police.EndOfDay.TranqCase.VictimID].gameObject.SetActive(value: false);
		}
		if (WaterCooler.TrapSet)
		{
			WaterCooler.UpdateCylinderColor();
			WaterCooler.SetTrap();
			WaterCooler.Timer = 1f;
		}
		PickUpScript[] allPickUps = AllPickUps;
		foreach (PickUpScript pickUpScript in allPickUps)
		{
			if (pickUpScript != null && pickUpScript.InsideBookbag)
			{
				Debug.Log(pickUpScript.name + " is supposed to be inside of the bookbag.");
				BookBag.ConcealedPickup = pickUpScript;
				pickUpScript.gameObject.SetActive(value: false);
				if (pickUpScript.Prompt.Text[3] != "")
				{
					BookBag.Prompt.Label[0].text = "     Retrieve " + pickUpScript.Prompt.Text[3];
				}
				else
				{
					BookBag.Prompt.Label[0].text = "     Retrieve " + pickUpScript.name;
				}
			}
		}
		if (WeaponBag.Worn)
		{
			Debug.Log("The player was wearing the WeaponBag at the time the save file was made.");
			WeaponBag.AttachToBack();
		}
		if (BookBag.Worn)
		{
			Debug.Log("The player was wearing the BookBag at the time the save file was made.");
			BookBag.Wear();
		}
		Yandere.WeaponManager.PutWeaponInBag();
		if (Yandere.Bloodiness > 0f && Yandere.Schoolwear > 0 && !Yandere.WearingRaincoat)
		{
			Debug.Log("The player was bloody when returning from a save, so we're going to prevent her from incrementing Police.BloodyClothing unnecessarily.");
			Police.BloodyClothing--;
		}
		SpawnedObjectManager.RespawnObjects();
		LoadedSave = true;
		if (Students[RivalID] != null)
		{
			Debug.Log("Rival's Phase is: " + Students[RivalID].Phase);
			if (Students[RivalID].Phase == 1 && Students[RivalID].Indoors && Students[RivalID].BagPlaced)
			{
				Debug.Log("Placing bag due to reloading.");
				Students[RivalID].PlaceBag();
				GenericRivalBag.RestoreBentoStatus();
			}
		}
		FoodPlate.UpdateFood();
		Debug.Log("The entire loading process has been completed.");
		Week = DateGlobals.Week;
		CameFromLoad = true;
	}

	public void UpdateBlood()
	{
		if (Police.BloodParent.childCount > 0)
		{
			ID = 0;
			foreach (Transform item in Police.BloodParent)
			{
				if (ID < 100)
				{
					Blood[ID] = item.gameObject.GetComponent<Collider>();
					ID++;
				}
			}
		}
		if (Police.BloodParent.childCount <= 0 && Police.LimbParent.childCount <= 0)
		{
			return;
		}
		ID = 0;
		foreach (Transform item2 in Police.LimbParent)
		{
			if (ID < 100)
			{
				Limbs[ID] = item2.gameObject.GetComponent<Collider>();
				ID++;
			}
		}
	}

	public void CanAnyoneSeeYandere()
	{
		YandereVisible = false;
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null && studentScript.gameObject.activeInHierarchy && studentScript.Alive && studentScript.CanSeeObject(studentScript.Yandere.gameObject, studentScript.Yandere.HeadPosition))
			{
				Debug.Log("Student #" + studentScript.StudentID + ", " + studentScript.Name + ", can see Yandere-chan right now.");
				YandereVisible = true;
				break;
			}
		}
	}

	public void CheckBentos()
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null && studentScript.MyBento.Tranquil)
			{
				Debug.Log("Yandere-chan put sedative into " + studentScript.Name + "'s bento, so that student is being marked as ''Sleepy''.");
				studentScript.Sleepy = true;
				studentScript.Oversleep();
				studentScript.GetDestinations();
			}
		}
	}

	public void PutStudentsToSleep()
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null && studentScript.Sleepy)
			{
				studentScript.transform.position = studentScript.Pathfinding.target.position;
				Physics.SyncTransforms();
			}
		}
	}

	public void SetFaces(float alpha)
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (!(studentScript != null) || studentScript.StudentID <= 1)
			{
				continue;
			}
			if (studentScript.MyRenderer != null)
			{
				studentScript.MyRenderer.materials[0].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				studentScript.MyRenderer.materials[1].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
				if (studentScript.MyRenderer.materials.Length > 2)
				{
					studentScript.MyRenderer.materials[2].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
					if (studentScript.MyRenderer.materials.Length > 3)
					{
						studentScript.MyRenderer.materials[3].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
					}
				}
			}
			studentScript.Cosmetic.LeftEyeRenderer.material.color = new Color(studentScript.OriginalEyeR - alpha, studentScript.OriginalEyeG - alpha, studentScript.OriginalEyeB - alpha, 1f);
			studentScript.Cosmetic.RightEyeRenderer.material.color = new Color(studentScript.OriginalEyeR - alpha, studentScript.OriginalEyeG - alpha, studentScript.OriginalEyeB - alpha, 1f);
			if (studentScript.Cosmetic.HairRenderer != null)
			{
				studentScript.Cosmetic.HairRenderer.material.color = new Color(studentScript.OriginalHairR - alpha, studentScript.OriginalHairG - alpha, studentScript.OriginalHairB - alpha, 1f);
			}
		}
	}

	public void DisableChaseCameras()
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null)
			{
				studentScript.ChaseCamera.SetActive(value: false);
			}
		}
	}

	public void UpdateDynamicBones(bool Status)
	{
		DynamicBone[] allDynamicBones = AllDynamicBones;
		foreach (DynamicBone dynamicBone in allDynamicBones)
		{
			if (dynamicBone != null)
			{
				dynamicBone.enabled = Status;
			}
		}
	}

	public void UpdateFPSDisplay(bool Status)
	{
		if (RecordingVideo)
		{
			return;
		}
		DynamicBone[] allDynamicBones = AllDynamicBones;
		for (int i = 0; i < allDynamicBones.Length; i++)
		{
			_ = allDynamicBones[i];
			if (FPSDisplay != null)
			{
				FPSDisplayBG.SetActive(Status);
				FPSDisplay.SetActive(Status);
			}
		}
	}

	public void InitializeReputations()
	{
		ReputationSetter.InitializeReputations();
		for (ID = 0; ID < 101; ID++)
		{
			Vector3 reputationTriangle = StudentGlobals.GetReputationTriangle(ID);
			reputationTriangle.x *= 0.33333f;
			reputationTriangle.y *= 0.33333f;
			reputationTriangle.z *= 0.33333f;
			StudentGlobals.SetStudentReputation(ID, Mathf.RoundToInt(reputationTriangle.x + reputationTriangle.y + reputationTriangle.z));
			StudentReps[ID] = StudentGlobals.GetStudentReputation(ID);
		}
	}

	public void GracePeriod(float Length)
	{
		for (ID = 1; ID < Students.Length; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.FocusOnYandere = false;
				studentScript.IgnoreTimer = Length;
			}
		}
	}

	public void OpenSomeDoors()
	{
		int openedDoors = OpenedDoors;
		while (OpenedDoors < openedDoors + 11)
		{
			if (OpenedDoors < Doors.Length && Doors[OpenedDoors] != null && Doors[OpenedDoors].enabled)
			{
				Doors[OpenedDoors].Open = true;
				Doors[OpenedDoors].OpenDoor();
			}
			OpenedDoors++;
		}
	}

	public void SnapSomeStudents()
	{
		int snappedStudents = SnappedStudents;
		while (SnappedStudents < snappedStudents + 10)
		{
			if (SnappedStudents < Students.Length)
			{
				StudentScript studentScript = Students[SnappedStudents];
				if (studentScript != null && studentScript.gameObject.activeInHierarchy && studentScript.Alive)
				{
					studentScript.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					studentScript.CharacterAnimation[studentScript.SocialSitAnim].weight = 0f;
					studentScript.SnapStudent.Yandere = SnappedYandere;
					studentScript.SnapStudent.enabled = true;
					studentScript.SpeechLines.Stop();
					studentScript.enabled = false;
					studentScript.EmptyHands();
					if (studentScript.Shy)
					{
						studentScript.CharacterAnimation[studentScript.ShyAnim].weight = 0f;
					}
					if (studentScript.Club == ClubType.LightMusic)
					{
						studentScript.StopMusic();
					}
				}
			}
			SnappedStudents++;
		}
	}

	public void DarkenAllStudents()
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (!(studentScript != null) || studentScript.StudentID <= 1)
			{
				continue;
			}
			studentScript.MyRenderer.materials[0].mainTexture = PureWhite;
			studentScript.MyRenderer.materials[1].mainTexture = PureWhite;
			studentScript.MyRenderer.materials[0].color = new Color(1f, 1f, 1f, 1f);
			studentScript.MyRenderer.materials[1].color = new Color(1f, 1f, 1f, 1f);
			if (studentScript.MyRenderer.materials.Length > 2)
			{
				studentScript.MyRenderer.materials[2].mainTexture = PureWhite;
				studentScript.MyRenderer.materials[2].color = new Color(1f, 1f, 1f, 1f);
				if (studentScript.MyRenderer.materials.Length > 3)
				{
					studentScript.MyRenderer.materials[3].mainTexture = PureWhite;
					studentScript.MyRenderer.materials[3].color = new Color(1f, 1f, 1f, 1f);
				}
			}
			studentScript.Cosmetic.LeftEyeRenderer.material.mainTexture = PureWhite;
			studentScript.Cosmetic.RightEyeRenderer.material.mainTexture = PureWhite;
			studentScript.Cosmetic.HairRenderer.material.mainTexture = PureWhite;
			studentScript.Cosmetic.LeftEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
			studentScript.Cosmetic.RightEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
			studentScript.Cosmetic.HairRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	public void LockDownOccultClub()
	{
		for (int i = 31; i < 36; i++)
		{
			Patrols.List[i].GetChild(1).position = Patrols.List[i].GetChild(0).position;
			Patrols.List[i].GetChild(2).position = Patrols.List[i].GetChild(0).position;
			Patrols.List[i].GetChild(3).position = Patrols.List[i].GetChild(0).position;
			Patrols.List[i].GetChild(4).position = Patrols.List[i].GetChild(0).position;
			Patrols.List[i].GetChild(5).position = Patrols.List[i].GetChild(0).position;
		}
		for (int j = 81; j < 86; j++)
		{
			Patrols.List[j].GetChild(0).position = BullySnapPosition[j].position;
			Patrols.List[j].GetChild(1).position = BullySnapPosition[j].position;
			Patrols.List[j].GetChild(2).position = BullySnapPosition[j].position;
			Patrols.List[j].GetChild(3).position = BullySnapPosition[j].position;
		}
	}

	public void SetWindowsTransparent()
	{
		Window.sharedMaterial.color = new Color(0.85f, 0.85f, 0.85f, 0.5f);
		Window.sharedMaterial.shader = Shader.Find("Transparent/Diffuse");
		TransWindows = true;
	}

	public void SetWindowsOpaque()
	{
		Window.sharedMaterial.color = new Color(0.85f, 0.85f, 0.85f, 1f);
		Window.sharedMaterial.shader = Shader.Find("Diffuse");
		TransWindows = false;
	}

	public void LateUpdate()
	{
		if (WindowOccluder != null && !TransparentWindows)
		{
			if (Yandere.transform.position.y > 0.1f && Yandere.transform.position.y < 11f)
			{
				WindowOccluder.open = false;
			}
			else
			{
				WindowOccluder.open = true;
			}
		}
	}

	public void UpdateSkirts(bool Status)
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null)
			{
				if (!studentScript.Male && !studentScript.Teacher && studentScript.Schoolwear == 1)
				{
					studentScript.SkirtCollider.gameObject.SetActive(Status);
				}
				studentScript.RightHandCollider.enabled = Status;
				studentScript.LeftHandCollider.enabled = Status;
			}
		}
	}

	public void UpdatePanties(bool Status)
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null)
			{
				if (!studentScript.Male && !studentScript.Teacher && studentScript.Schoolwear == 1)
				{
					studentScript.SkirtCollider.gameObject.SetActive(Status);
					studentScript.PantyCollider.gameObject.SetActive(Status);
				}
				studentScript.NotFaceCollider.enabled = Status;
				studentScript.FaceCollider.enabled = Status;
			}
		}
	}

	public void LoadPantyshots()
	{
		ID = 1;
		bool[] pantyShotTaken = PantyShotTaken;
		for (int i = 0; i < pantyShotTaken.Length; i++)
		{
			_ = pantyShotTaken[i];
			if (ID < PantyShotTaken.Length)
			{
				PantyShotTaken[ID] = PlayerGlobals.GetStudentPantyShot(ID);
			}
			ID++;
		}
	}

	public void SavePantyshots()
	{
		ID = 0;
		bool[] pantyShotTaken = PantyShotTaken;
		foreach (bool value in pantyShotTaken)
		{
			PlayerGlobals.SetStudentPantyShot(ID, value);
			ID++;
		}
	}

	public void LoadPhotographs()
	{
		ID = 1;
		bool[] studentPhotographed = StudentPhotographed;
		for (int i = 0; i < studentPhotographed.Length; i++)
		{
			_ = studentPhotographed[i];
			if (ID < StudentPhotographed.Length)
			{
				StudentPhotographed[ID] = StudentGlobals.GetStudentPhotographed(ID);
			}
			ID++;
		}
	}

	public void SavePhotographs()
	{
		ID = 0;
		bool[] studentPhotographed = StudentPhotographed;
		foreach (bool value in studentPhotographed)
		{
			StudentGlobals.SetStudentPhotographed(ID, value);
			ID++;
		}
	}

	public void LoadReps()
	{
		ID = 1;
		float[] studentReps = StudentReps;
		for (int i = 0; i < studentReps.Length; i++)
		{
			_ = studentReps[i];
			if (ID < StudentReps.Length)
			{
				StudentReps[ID] = StudentGlobals.GetStudentReputation(ID);
			}
			ID++;
		}
	}

	public void SaveReps()
	{
		ID = 1;
		float[] studentReps = StudentReps;
		for (int i = 0; i < studentReps.Length; i++)
		{
			_ = studentReps[i];
			if (ID < StudentReps.Length)
			{
				StudentGlobals.SetStudentReputation(ID, (int)StudentReps[ID]);
			}
			ID++;
		}
	}

	public void Week1RoutineAdjustments()
	{
		Debug.Log("Making Week 1 routine adjustments.");
		UpdateWeek1Hangout(25);
		UpdateWeek1Hangout(30);
		UpdateWeek1Hangout(24);
		UpdateWeek1Hangout(27);
		UpdateWeek1Hangout(34);
		UpdateWeek1Hangout(35);
		UpdateWeek1Hangout(39);
		UpdateWeek1Hangout(40);
		UpdateWeek1Hangout(44);
		UpdateWeek1Hangout(45);
		UpdateWeek1Hangout(54);
		UpdateWeek1Hangout(55);
		UpdateWeek1Hangout(59);
		UpdateWeek1Hangout(60);
		UpdateWeek1Hangout(64);
		UpdateWeek1Hangout(65);
		UpdateWeek1Hangout(69);
		UpdateWeek1Hangout(70);
		UpdateWeek1Hangout(72);
		UpdateWeek1Hangout(73);
		UpdateWeek1Hangout(74);
		UpdateWeek1Hangout(75);
		if (!Bully)
		{
			UpdateWeek1Hangout(82);
			UpdateWeek1Hangout(83);
		}
	}

	public void UpdateWeek1Hangout(int StudentID)
	{
		if (Students[StudentID] != null && !Students[StudentID].Sleuthing)
		{
			scheduleBlock = Students[StudentID].ScheduleBlocks[2];
			scheduleBlock.destination = "Week1Hangout";
			scheduleBlock.action = "Socialize";
			if (StudentID == 25 || StudentID == 30 || StudentID == 24 || StudentID == 27)
			{
				Students[StudentID].Hurry = true;
				Students[StudentID].Pathfinding.speed = 4f;
			}
			if (Students[StudentID].Club != ClubType.Bully)
			{
				scheduleBlock = Students[StudentID].ScheduleBlocks[6];
				scheduleBlock.destination = "Week1Hangout";
				scheduleBlock.action = "Socialize";
			}
			scheduleBlock = Students[StudentID].ScheduleBlocks[7];
			scheduleBlock.destination = "Week1Hangout";
			scheduleBlock.action = "Socialize";
			Students[StudentID].GetDestinations();
			if (DateGlobals.Weekday == DayOfWeek.Friday && Students[StudentID].Club == ClubType.Art)
			{
				ScheduleBlock obj = Students[StudentID].ScheduleBlocks[7];
				obj.destination = "Paint";
				obj.action = "Paint";
				Students[StudentID].VisionDistance += 5f;
			}
			Students[StudentID].SetOriginalScheduleBlocks();
			Students[StudentID].SetOriginalActions();
		}
	}

	public void UpdateExteriorStudents()
	{
		Debug.Log("Osana finished changing her shoes, so exterior students are moving back inside.");
		UpdateExteriorHangout(25);
		UpdateExteriorHangout(30);
		UpdateExteriorHangout(24);
		UpdateExteriorHangout(27);
		UpdateExteriorHangout(34);
		UpdateExteriorHangout(35);
	}

	public void UpdateExteriorEightiesStudents()
	{
		if (Week == 0)
		{
			Week = DateGlobals.Week;
		}
		SukebanHangoutParent.position = SukebanSpots[Week].position;
		SukebanHangoutParent.eulerAngles = SukebanSpots[Week].eulerAngles;
		if (Week == 4)
		{
			EightiesLunchSpots.List[81].position = EightiesLunchSpots.List[101].position;
			EightiesLunchSpots.List[82].position = EightiesLunchSpots.List[102].position;
			EightiesLunchSpots.List[83].position = EightiesLunchSpots.List[103].position;
			EightiesLunchSpots.List[84].position = EightiesLunchSpots.List[104].position;
			EightiesLunchSpots.List[85].position = EightiesLunchSpots.List[105].position;
			EightiesLunchSpots.List[81].eulerAngles = EightiesLunchSpots.List[101].eulerAngles;
			EightiesLunchSpots.List[82].eulerAngles = EightiesLunchSpots.List[102].eulerAngles;
			EightiesLunchSpots.List[83].eulerAngles = EightiesLunchSpots.List[103].eulerAngles;
			EightiesLunchSpots.List[84].eulerAngles = EightiesLunchSpots.List[104].eulerAngles;
			EightiesLunchSpots.List[85].eulerAngles = EightiesLunchSpots.List[105].eulerAngles;
		}
	}

	public void UpdateLunchtimeStudents()
	{
		Debug.Log("It's lunchtime during Osana's week, so certain students are having their routines adjusted.");
		UpdateLunchtimeHangout(25);
		UpdateLunchtimeHangout(30);
		UpdateLunchtimeHangout(24);
		UpdateLunchtimeHangout(27);
		UpdateLunchtimeHangout(34);
		UpdateLunchtimeHangout(35);
		UpdateLunchtimeHangout(39);
		UpdateLunchtimeHangout(40);
		UpdateLunchtimeHangout(44);
		UpdateLunchtimeHangout(45);
		UpdateLunchtimeHangout(54);
		UpdateLunchtimeHangout(55);
		UpdateLunchtimeHangout(59);
		UpdateLunchtimeHangout(60);
		if (!Bully)
		{
			UpdateLunchtimeHangout(82);
			UpdateLunchtimeHangout(83);
		}
	}

	public void UpdateExteriorHangout(int StudentID)
	{
		if (Students[StudentID] != null)
		{
			scheduleBlock = Students[StudentID].ScheduleBlocks[2];
			scheduleBlock.destination = "Stairway";
			scheduleBlock.action = "Socialize";
			scheduleBlock = Students[StudentID].ScheduleBlocks[6];
			scheduleBlock.destination = "Stairway";
			scheduleBlock.action = "Socialize";
			scheduleBlock = Students[StudentID].ScheduleBlocks[7];
			scheduleBlock.destination = "Stairway";
			scheduleBlock.action = "Socialize";
			Students[StudentID].GetDestinations();
			Students[StudentID].CurrentDestination = Students[StudentID].Destinations[Students[StudentID].Phase];
			Students[StudentID].Pathfinding.target = Students[StudentID].Destinations[Students[StudentID].Phase];
			Students[StudentID].SpeechLines.Stop();
		}
	}

	public void UpdateLunchtimeHangout(int StudentID)
	{
		if (Students[StudentID] != null && !Students[StudentID].Sleuthing)
		{
			scheduleBlock = Students[StudentID].ScheduleBlocks[4];
			scheduleBlock.destination = "LunchWitnessPosition";
			scheduleBlock.action = "Socialize";
			Students[StudentID].GetDestinations();
			Students[StudentID].CurrentDestination = Students[StudentID].Destinations[Students[StudentID].Phase];
			Students[StudentID].Pathfinding.target = Students[StudentID].Destinations[Students[StudentID].Phase];
		}
	}

	public void Week2RoutineAdjustments()
	{
		if (Students[11] != null)
		{
			Hangouts.List[11] = Week2Hangouts.List[11];
			Students[11].GetDestinations();
			if (Students[10] != null)
			{
				Hangouts.List[10] = Week2Hangouts.List[10];
				Students[10].GetDestinations();
			}
		}
		MournSpots[10].position = Week2Hangouts.List[11].position;
		MournSpots[10].eulerAngles = Week2Hangouts.List[11].eulerAngles;
		if (Students[21] != null)
		{
			scheduleBlock = Students[21].ScheduleBlocks[2];
			scheduleBlock.destination = "Week2Hangout";
			scheduleBlock.action = "Stand";
			scheduleBlock = Students[21].ScheduleBlocks[4];
			scheduleBlock.destination = "Week2Hangout";
			scheduleBlock.action = "Stand";
			scheduleBlock = Students[21].ScheduleBlocks[7];
			scheduleBlock.destination = "Week2Hangout";
			scheduleBlock.action = "Stand";
			scheduleBlock = Students[21].ScheduleBlocks[8];
			scheduleBlock.destination = "Week2Hangout";
			scheduleBlock.action = "Stand";
			Students[21].GetDestinations();
		}
		UpdateWeek2Hangout(4);
		UpdateWeek2Hangout(5);
		UpdateWeek2Hangout(6);
		UpdateWeek2Hangout(7);
		UpdateWeek2Hangout(8);
		UpdateWeek2Hangout(9);
		UpdateWeek2Hangout(22);
		UpdateWeek2Hangout(23);
		UpdateWeek2Hangout(24);
		UpdateWeek2Hangout(25);
		UpdateWeek2Hangout(27);
		UpdateWeek2Hangout(28);
		UpdateWeek2Hangout(29);
		UpdateWeek2Hangout(30);
		UpdateWeek2Hangout(32);
		UpdateWeek2Hangout(33);
		UpdateWeek2Hangout(34);
		UpdateWeek2Hangout(35);
		UpdateWeek2Hangout(37);
		UpdateWeek2Hangout(38);
		UpdateWeek2Hangout(39);
		UpdateWeek2Hangout(40);
		UpdateWeek2Hangout(42);
		UpdateWeek2Hangout(43);
		UpdateWeek2Hangout(44);
		UpdateWeek2Hangout(45);
		UpdateWeek2Hangout(56);
		UpdateWeek2Hangout(57);
		UpdateWeek2Hangout(58);
		UpdateWeek2Hangout(59);
		UpdateWeek2Hangout(60);
		UpdateWeek2Hangout(81);
		UpdateWeek2Hangout(82);
		UpdateWeek2Hangout(83);
		UpdateWeek2Hangout(84);
		UpdateWeek2Hangout(85);
	}

	public void UpdateWeek2Hangout(int StudentID)
	{
		if (Students[StudentID] != null)
		{
			scheduleBlock = Students[StudentID].ScheduleBlocks[2];
			scheduleBlock.destination = "Week2Hangout";
			scheduleBlock.action = "Socialize";
			scheduleBlock = Students[StudentID].ScheduleBlocks[4];
			scheduleBlock.destination = "Week2Hangout";
			scheduleBlock.action = "Socialize";
			scheduleBlock = Students[StudentID].ScheduleBlocks[7];
			scheduleBlock.destination = "Week2Hangout";
			scheduleBlock.action = "Socialize";
			Students[StudentID].GetDestinations();
		}
	}

	public void RivalPostWeekRoutineAdjustments()
	{
		if (Week > 1 && Students[11] != null)
		{
			Debug.Log("Attempting to update Rival #1's routine.");
			EightiesHangouts.List[11].position = new Vector3(-31f, 0f, 0f);
			EightiesHangouts.List[11].eulerAngles = new Vector3(0f, 90f, 0f);
			scheduleBlock = Students[11].ScheduleBlocks[2];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Gaming";
			scheduleBlock = Students[11].ScheduleBlocks[7];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Gaming";
			Students[11].GameAnim = "f02_observeKitten_00";
			Students[11].GetDestinations();
		}
		if (Week > 2 && Students[12] != null)
		{
			Debug.Log("Attempting to update Rival #2's routine.");
			EightiesHangouts.List[12].position = new Vector3(-2f, 0f, 56f);
			EightiesHangouts.List[12].eulerAngles = new Vector3(0f, 90f, 0f);
			scheduleBlock = Students[12].ScheduleBlocks[2];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Gaming";
			scheduleBlock = Students[12].ScheduleBlocks[7];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Gaming";
			Students[12].GameAnim = "f02_lookLeftRight_00";
			Students[12].GetDestinations();
		}
		if (Week > 9 && Students[19] != null)
		{
			Debug.Log("Is Rival $9 in a couple?" + Students[19].InCouple);
			if (!Students[19].InCouple)
			{
				Debug.Log("Attempting to update Rival #9's routine.");
				scheduleBlock = Students[19].ScheduleBlocks[2];
				scheduleBlock.destination = "Patrol";
				scheduleBlock.action = "Patrol";
				scheduleBlock = Students[19].ScheduleBlocks[7];
				scheduleBlock.destination = "Patrol";
				scheduleBlock.action = "Patrol";
				Students[19].GetDestinations();
			}
		}
	}

	public void EightiesWeek3RoutineAdjustments()
	{
		for (int i = 2; i < 6; i++)
		{
			if (Students[i] != null)
			{
				scheduleBlock = Students[i].ScheduleBlocks[2];
				scheduleBlock.destination = "EightiesSpot";
				scheduleBlock.action = "Read";
				scheduleBlock = Students[i].ScheduleBlocks[7];
				scheduleBlock.destination = "EightiesSpot";
				scheduleBlock.action = "Read";
				Students[i].GetDestinations();
			}
		}
	}

	public void EightiesWeek4RoutineAdjustments()
	{
		for (int i = 6; i < 11; i++)
		{
			if (Students[i] != null)
			{
				scheduleBlock = Students[i].ScheduleBlocks[4];
				scheduleBlock.destination = "EightiesSpot";
				scheduleBlock.action = "PrepareFood";
				Students[i].GetDestinations();
			}
		}
	}

	public void EightiesWeek5RoutineAdjustments()
	{
		SunbatheAllDay(25);
		SunbatheAllDay(30);
		SunbatheAllDay(35);
		SunbatheAllDay(40);
		SunbatheAllDay(45);
		SunbatheAllDay(50);
		SunbatheAllDay(55);
	}

	public void EightiesWeek6RoutineAdjustments()
	{
		int num = 26;
		if (Students[num] != null)
		{
			scheduleBlock = Students[num].ScheduleBlocks[2];
			scheduleBlock.destination = "Patrol";
			scheduleBlock.action = "Patrol";
			scheduleBlock = Students[num].ScheduleBlocks[7];
			scheduleBlock.destination = "Patrol";
			scheduleBlock.action = "Patrol";
			Students[num].GetDestinations();
		}
		num = 29;
		if (Students[num] != null)
		{
			scheduleBlock = Students[num].ScheduleBlocks[2];
			scheduleBlock.destination = "Patrol";
			scheduleBlock.action = "Patrol";
			scheduleBlock = Students[num].ScheduleBlocks[7];
			scheduleBlock.destination = "Patrol";
			scheduleBlock.action = "Patrol";
			Students[num].GetDestinations();
		}
		for (num = 52; num < 56; num++)
		{
			if (Students[num] != null && Students[num].Club != 0)
			{
				scheduleBlock = Students[num].ScheduleBlocks[2];
				scheduleBlock.destination = "Perform";
				scheduleBlock.action = "Perform";
				scheduleBlock = Students[num].ScheduleBlocks[7];
				scheduleBlock.destination = "Perform";
				scheduleBlock.action = "Perform";
				Students[num].GetDestinations();
			}
		}
	}

	public void EightiesWeek8RoutineAdjustments()
	{
		if (Students[18] != null && StudentGlobals.StudentSlave != 18)
		{
			for (int i = 2; i < 11; i++)
			{
				FollowTraditionalGirl(i);
			}
		}
	}

	public void EightiesWeek9RoutineAdjustments()
	{
		if (Students[19] != null && StudentGlobals.StudentSlave != 19)
		{
			Students[1].Infatuated = true;
			if (DateGlobals.Weekday != DayOfWeek.Monday)
			{
				FollowGravureIdol(1);
			}
			FollowGravureIdol(6);
			FollowGravureIdol(7);
			FollowGravureIdol(8);
			FollowGravureIdol(9);
			FollowGravureIdol(10);
			FollowGravureIdol(23);
			FollowGravureIdol(28);
			FollowGravureIdol(33);
			FollowGravureIdol(38);
			FollowGravureIdol(43);
			FollowGravureIdol(48);
			FollowGravureIdol(63);
			FollowGravureIdol(68);
			FollowGravureIdol(73);
		}
	}

	public void PhotoshootRoutineAdjustments()
	{
		for (int i = 57; i < 61; i++)
		{
			scheduleBlock = Students[i].ScheduleBlocks[2];
			scheduleBlock.destination = "PhotoShoot";
			scheduleBlock.action = "PhotoShoot";
			scheduleBlock = Students[i].ScheduleBlocks[7];
			scheduleBlock.destination = "PhotoShoot";
			scheduleBlock.action = "PhotoShoot";
			Students[i].GetDestinations();
		}
	}

	public void RevertEightiesWeek9RoutineAdjustments()
	{
		Debug.Log("Freeing all simps from the ''Follow Chigusa'' routine.");
		StopFollowGravureIdol(1);
		StopFollowGravureIdol(6);
		StopFollowGravureIdol(7);
		StopFollowGravureIdol(8);
		StopFollowGravureIdol(9);
		StopFollowGravureIdol(10);
		StopFollowGravureIdol(23);
		StopFollowGravureIdol(28);
		StopFollowGravureIdol(33);
		StopFollowGravureIdol(38);
		StopFollowGravureIdol(43);
		StopFollowGravureIdol(48);
		StopFollowGravureIdol(63);
		StopFollowGravureIdol(68);
		StopFollowGravureIdol(73);
	}

	public void StopFollowGravureIdol(int ID)
	{
		if (Students[ID] != null)
		{
			Students[ID].SnackTimer = 6f;
			Students[ID].CannotFindInfatuationTarget();
		}
	}

	public void EightiesWeek10RoutineAdjustments()
	{
		Debug.Log("Changing student routines for Week 10.");
		for (int i = 2; i < 11; i++)
		{
			BecomeSleuth(i);
		}
		BecomeSleuth(20);
		RivalGuardSpots[0].parent = Students[20].transform;
		RivalGuardSpots[0].localPosition = new Vector3(0f, 0f, 0f);
		RivalGuardSpots[0].localEulerAngles = new Vector3(0f, 0f, 0f);
		for (int i = 37; i < 41; i++)
		{
			BecomeSleuth(i);
		}
		for (int i = 57; i < 61; i++)
		{
			BecomeGuard(i);
		}
	}

	public void BecomeSleuth(int ID)
	{
		if (Students[ID] != null && !Students[ID].Slave)
		{
			Students[ID].Persona = PersonaType.Sleuth;
			Students[ID].BecomeSleuth();
			Students[ID].GetDestinations();
		}
	}

	public void BecomeGuard(int ID)
	{
		if (Students[ID] != null && !Students[ID].Grudge)
		{
			Students[ID].Persona = PersonaType.Sleuth;
			Students[ID].BecomeSleuth();
			ScheduleBlock obj = Students[ID].ScheduleBlocks[2];
			obj.destination = "Guard";
			obj.action = "Guard";
			ScheduleBlock obj2 = Students[ID].ScheduleBlocks[4];
			obj2.destination = "Guard";
			obj2.action = "Guard";
			ScheduleBlock obj3 = Students[ID].ScheduleBlocks[7];
			obj3.destination = "Guard";
			obj3.action = "Guard";
			_ = Students[ID].ScheduleBlocks[8];
			obj3.destination = "Guard";
			obj3.action = "Guard";
			Students[ID].GetDestinations();
		}
	}

	public void FollowTraditionalGirl(int ID)
	{
		if (Students[ID] != null)
		{
			Hangouts.List[ID] = Students[18].transform;
			scheduleBlock = Students[ID].ScheduleBlocks[2];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Admire";
			if (!Students[ID].Male)
			{
				scheduleBlock = Students[ID].ScheduleBlocks[4];
				scheduleBlock.destination = "Hangout";
				scheduleBlock.action = "Admire";
			}
			scheduleBlock = Students[ID].ScheduleBlocks[6];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Admire";
			scheduleBlock = Students[ID].ScheduleBlocks[7];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Admire";
			Students[ID].GetDestinations();
			Students[ID].Infatuated = true;
			Students[ID].InfatuationID = 18;
			Students[ID].Obstacle.enabled = false;
			Students[ID].AdmireAnim = Students[ID].AdmireAnims[UnityEngine.Random.Range(0, 3)];
			Physics.IgnoreCollision(Students[ID].MyController, Students[18].MyController);
		}
	}

	public void FollowGravureIdol(int ID)
	{
		if (Students[ID] != null)
		{
			Hangouts.List[ID] = Students[19].transform;
			scheduleBlock = Students[ID].ScheduleBlocks[2];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Admire";
			if (ID > 1)
			{
				scheduleBlock = Students[ID].ScheduleBlocks[4];
				scheduleBlock.destination = "Hangout";
				scheduleBlock.action = "Admire";
			}
			scheduleBlock = Students[ID].ScheduleBlocks[6];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Admire";
			scheduleBlock = Students[ID].ScheduleBlocks[7];
			scheduleBlock.destination = "Hangout";
			scheduleBlock.action = "Admire";
			Students[ID].GetDestinations();
			Students[ID].Infatuated = true;
			Students[ID].InfatuationID = 19;
			Students[ID].Obstacle.enabled = false;
			Students[ID].AdmireAnim = Students[ID].AdmireAnims[UnityEngine.Random.Range(0, 3)];
			Physics.IgnoreCollision(Students[ID].MyController, Students[19].MyController);
		}
	}

	public void SunbatheAllDay(int ID)
	{
		if (Students[ID] != null)
		{
			Students[ID].DressCode = false;
			scheduleBlock = Students[ID].ScheduleBlocks[2];
			scheduleBlock.destination = "Sunbathe";
			scheduleBlock.action = "Sunbathe";
			scheduleBlock = Students[ID].ScheduleBlocks[6];
			scheduleBlock.destination = "Sunbathe";
			scheduleBlock.action = "Sunbathe";
			scheduleBlock = Students[ID].ScheduleBlocks[7];
			scheduleBlock.destination = "Sunbathe";
			scheduleBlock.action = "Sunbathe";
			Students[ID].GetDestinations();
		}
		ID++;
	}

	public void ForgetAboutSunbathing(int ID)
	{
		if (Students[ID] != null)
		{
			if (Students[ID].Actions[2] == StudentActionType.Sunbathe)
			{
				Students[ID].DressCode = false;
				scheduleBlock = Students[ID].ScheduleBlocks[2];
				scheduleBlock.destination = "Hangout";
				scheduleBlock.action = "Socialize";
				scheduleBlock = Students[ID].ScheduleBlocks[6];
				scheduleBlock.destination = "Hangout";
				scheduleBlock.action = "Socialize";
				scheduleBlock = Students[ID].ScheduleBlocks[7];
				scheduleBlock.destination = "Hangout";
				scheduleBlock.action = "Socialize";
				Students[ID].GetDestinations();
				Students[ID].CurrentDestination = Students[ID].Destinations[Students[ID].Phase];
				Students[ID].Pathfinding.target = Students[ID].Destinations[Students[ID].Phase];
			}
			if (Students[ID].Schoolwear == 2)
			{
				Debug.Log("Student #" + ID + " was wearing a swimsuit at the moment she learned the pool was off-limits.");
				Students[ID].Phase++;
			}
		}
	}

	public void TakeOutTheTrash()
	{
		int i = 2;
		for (int j = 0; j < GarbageBags; j++)
		{
			if (i >= 90)
			{
				break;
			}
			if (GarbageBagList[j] != null)
			{
				if (i > 9 && i < 21)
				{
					i++;
				}
				for (; Students[i] == null || !Students[i].gameObject.activeInHierarchy || Students[i].Slave || (!Students[i].Male && WestMaleBathroomCollider.bounds.Contains(GarbageBagList[j].transform.position)) || (!Students[i].Male && EastMaleBathroomCollider.bounds.Contains(GarbageBagList[j].transform.position)) || (Students[i].Male && WestFemaleBathroomCollider.bounds.Contains(GarbageBagList[j].transform.position)) || (Students[i].Male && EastFemaleBathroomCollider.bounds.Contains(GarbageBagList[j].transform.position)); i++)
				{
				}
				GarbageBagList[j].GetComponent<PickUpScript>().DisableGarbageBag();
				Students[i].TakingOutTrash = true;
				Students[i].TrashDestination = GarbageBagList[j].transform;
				Students[i].Routine = false;
				Debug.Log("Assigned " + Students[i].Name + " to clean up trash bag #" + j);
			}
			i++;
		}
	}

	public void Medibang()
	{
		Students[35].IdleAnim = "f02_idleElegant_00";
		Students[35].WalkAnim = "f02_jojoWalk_00";
		Students[35].OriginalIdleAnim = "f02_idleElegant_00";
		Students[35].OriginalWalkAnim = "f02_jojoWalk_00";
		Students[35].Cosmetic.MyRenderer.enabled = false;
		Students[35].EdgyAttacher.SetActive(value: true);
		Students[35].Cosmetic.Medibang = true;
		Students[35].Cosmetic.Start();
	}

	public void RemovePoolFromRoutines()
	{
		Debug.Log("Firing RemovePoolFromRoutines()");
		OsanaPoolEvent.enabled = false;
		PoolClosed = true;
		for (int i = 81; i < 86; i++)
		{
			ScheduleBlock obj = Students[i].ScheduleBlocks[4];
			obj.destination = "LunchSpot";
			obj.action = "Eat";
			Students[i].Actions[4] = StudentActionType.SitAndEatBento;
			Students[i].GetDestinations();
		}
		if (Eighties)
		{
			Debug.Log("A bunch of girls are now being instructed to forget about sunbathing.");
			ForgetAboutSunbathing(25);
			ForgetAboutSunbathing(30);
			ForgetAboutSunbathing(35);
			ForgetAboutSunbathing(40);
			ForgetAboutSunbathing(45);
			ForgetAboutSunbathing(50);
			ForgetAboutSunbathing(55);
		}
	}

	public void LoadCollectibles()
	{
		int i = 1;
		if (HeadmasterTapesCollected.Length != 0)
		{
			for (; i < 12; i++)
			{
				HeadmasterTapesCollected[i] = CollectibleGlobals.GetHeadmasterTapeCollected(i);
				PantiesCollected[i] = CollectibleGlobals.GetPantyPurchased(i);
				TapesCollected[i] = CollectibleGlobals.GetTapeCollected(i);
			}
		}
		if (MangaCollected.Length != 0)
		{
			for (i = 1; i < 16; i++)
			{
				MangaCollected[i] = CollectibleGlobals.GetMangaCollected(i);
			}
		}
	}

	public void SaveCollectibles()
	{
		for (int i = 1; i < 12; i++)
		{
			CollectibleGlobals.SetHeadmasterTapeCollected(i, HeadmasterTapesCollected[i]);
			CollectibleGlobals.SetPantyPurchased(i, PantiesCollected[i]);
			CollectibleGlobals.SetTapeCollected(i, TapesCollected[i]);
			if (i == 11 && PantiesCollected[i])
			{
				Debug.Log("Saving the fact that Ryoba picked up the fundoshi.");
			}
		}
		for (int i = 1; i < 16; i++)
		{
			CollectibleGlobals.SetMangaCollected(i, MangaCollected[i]);
		}
	}

	public void UpdateTeachers()
	{
		Debug.Log("All teachers were just commanded to fire the UpdateMe() function.");
		UpdateMe(90);
		UpdateMe(91);
		UpdateMe(92);
		UpdateMe(93);
		UpdateMe(94);
		UpdateMe(95);
		UpdateMe(96);
		UpdateMe(97);
	}

	public void UpdateAppearances()
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null)
			{
				studentScript.Cosmetic.Start();
			}
		}
	}

	public void RandomizeRoutines()
	{
		for (ID = 1; ID < 101; ID++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(EmptyObject, base.transform.position, Quaternion.identity);
			RandomSpots[ID] = gameObject.transform;
			gameObject.transform.position = PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
		}
		for (ID = 1; ID < 97; ID++)
		{
			StudentScript studentScript = Students[ID];
			if (studentScript != null)
			{
				studentScript.Indoors = true;
				studentScript.Spawned = true;
				studentScript.Calm = true;
				if (studentScript.ShoeRemoval.Locker == null && !studentScript.Teacher)
				{
					studentScript.ShoeRemoval.Start();
					studentScript.ShoeRemoval.PutOnShoes();
				}
				ScheduleBlock obj = studentScript.ScheduleBlocks[0];
				obj.destination = "Random";
				obj.action = "Random";
				ScheduleBlock obj2 = studentScript.ScheduleBlocks[1];
				obj2.destination = "Random";
				obj2.action = "Random";
				ScheduleBlock obj3 = studentScript.ScheduleBlocks[2];
				obj3.destination = "Random";
				obj3.action = "Random";
				ScheduleBlock obj4 = studentScript.ScheduleBlocks[3];
				obj4.destination = "Random";
				obj4.action = "Random";
				ScheduleBlock obj5 = studentScript.ScheduleBlocks[4];
				obj5.destination = "Random";
				obj5.action = "Random";
				ScheduleBlock obj6 = studentScript.ScheduleBlocks[5];
				obj6.destination = "Random";
				obj6.action = "Random";
				studentScript.GetDestinations();
				studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
				studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
				studentScript.CurrentAction = StudentActionType.Random;
				Students[ID].transform.position = PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
				Physics.SyncTransforms();
			}
		}
	}

	public void DepowerStudentCouncil()
	{
		for (int i = 86; i < 90; i++)
		{
			StudentScript studentScript = Students[i];
			if (studentScript != null)
			{
				studentScript.OriginalPersona = PersonaType.Heroic;
				studentScript.Persona = PersonaType.Heroic;
				studentScript.Club = ClubType.None;
				studentScript.CameraReacting = false;
				studentScript.SpeechLines.Stop();
				studentScript.EmptyHands();
				studentScript.IdleAnim = studentScript.BulliedIdleAnim;
				studentScript.WalkAnim = studentScript.BulliedWalkAnim;
				studentScript.Armband.SetActive(value: false);
				ScheduleBlock obj = studentScript.ScheduleBlocks[3];
				obj.destination = "LunchSpot";
				obj.action = "Eat";
				studentScript.GetDestinations();
				studentScript.CurrentDestination = studentScript.Destinations[studentScript.Phase];
				studentScript.Pathfinding.target = studentScript.Destinations[studentScript.Phase];
			}
		}
	}

	public void Become1989()
	{
		Eighties = true;
		WeekLimit = 10;
		if (TakingPortraits)
		{
			PhotoBG.mainTexture = EightiesBG;
			PortraitChan = StudentChan;
			PortraitKun = StudentKun;
			EightiesPrefix = "1989";
			Profile.enabled = true;
			return;
		}
		Yandere.HeartCamera.enabled = false;
		Tutorial.ReputationHUD.transform.localPosition = new Vector3(-15f, 25f, 0f);
		Tutorial.SanityHUD.transform.localPosition = new Vector3(50f, 30f, 0f);
		Tutorial.ClockHUD.transform.localPosition = new Vector3(-25f, -10f, 0f);
		FPSValue.GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
		FPSValue.localPosition = new Vector3(75f, -179f, 0f);
		FPS.GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
		FPS.localPosition = new Vector3(120f, -179f, 0f);
		LandLinePhone.gameObject.SetActive(value: true);
		OutOfOrderSign.SetActive(value: false);
		YellowifyLabel(Police.EndOfDay.Counselor.CounselorSubtitle);
		YellowifyLabel(Police.EndOfDay.Counselor.LectureSubtitle);
		YellowifyLabel(LoveManager.ConfessionManager.SubtitleLabel);
		YellowifyLabel(Headmaster.HeadmasterSubtitle);
		YellowifyLabel(Yandere.Subtitle.Label);
		YellowifyLabel(EventSubtitle);
		EightiesifyLabel(Yandere.SanityLabel);
		HauntedBathroomLight.enabled = true;
		SpawnPositions[7].localPosition = new Vector3(1f, 0f, -6f);
		PracticeSpots[1].localPosition = new Vector3(1.66666f, 4f, 26f);
		PracticeSpots[1].localEulerAngles = new Vector3(0f, -90f, 0f);
		for (int i = 1; i < ModernDayProps.Length; i++)
		{
			ModernDayProps[i].SetActive(value: false);
		}
		for (int i = 1; i < EightiesProps.Length; i++)
		{
			EightiesProps[i].SetActive(value: true);
		}
		LunchSpots = EightiesLunchSpots;
		Hangouts = EightiesHangouts;
		Patrols = EightiesPatrols;
		Clubs = EightiesClubs;
		InfoClubRoom.SetActive(value: false);
		InfoClubProps.SetActive(value: false);
		ModernDayScienceClub.SetActive(value: false);
		ModernDayScienceProps.SetActive(value: false);
		ModernDayPropsLMC.SetActive(value: false);
		ModernDayRoomLMC.SetActive(value: false);
		NewspaperClubProps.SetActive(value: true);
		NewspaperClubRoom.SetActive(value: true);
		EightiesPropsLMC.SetActive(value: true);
		EightiesRoomLMC.SetActive(value: true);
		EightiesScienceClub.SetActive(value: true);
		EightiesScienceProps.SetActive(value: true);
		if (Week < 11)
		{
			SuitorID = SuitorIDs[Week];
		}
		LyricsSpot.parent.position = EightiesLyricDesk.position;
		LyricsSpot.parent.eulerAngles = EightiesLyricDesk.eulerAngles;
	}

	public void YellowifyLabel(UILabel Label)
	{
		Label.trueTypeFont = Arial;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 0f, 1f);
		Label.fontStyle = FontStyle.Bold;
	}

	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	public void StayInOneSpot(int StudentID)
	{
		Hangouts.List[StudentID].transform.position = Students[StudentID].transform.position;
		Hangouts.List[StudentID].transform.eulerAngles = Students[StudentID].transform.eulerAngles;
		for (int i = 0; i < 8; i++)
		{
			ScheduleBlock obj = Students[StudentID].ScheduleBlocks[i];
			obj.destination = "Hangout";
			obj.action = "Wait";
		}
		Students[StudentID].GetDestinations();
		Students[StudentID].CurrentAction = StudentActionType.Wait;
		Students[StudentID].Pathfinding.target = Tutorial.Destination[Tutorial.Phase + 1];
		Students[StudentID].CurrentDestination = Tutorial.Destination[Tutorial.Phase + 1];
	}

	public void ChangeSuitorRoutine(int StudentID)
	{
		StudentScript obj = Students[StudentID];
		obj.RelaxAnim = obj.PatrolAnim;
		obj.Curious = true;
		obj.Crush = RivalID;
		Hangouts.List[StudentID].transform.position = new Vector3(6f, 0f, -5f);
		Hangouts.List[StudentID].transform.eulerAngles = new Vector3(0f, 90f, 0f);
		ScheduleBlock obj2 = obj.ScheduleBlocks[2];
		obj2.destination = "Hangout";
		obj2.action = "Relax";
		ScheduleBlock obj3 = obj.ScheduleBlocks[4];
		obj3.destination = "Hangout";
		obj3.action = "Relax";
		ScheduleBlock obj4 = obj.ScheduleBlocks[7];
		obj4.destination = "Hangout";
		obj4.action = "Relax";
		Students[StudentID].GetDestinations();
		Students[StudentID].Pathfinding.target = Students[StudentID].Destinations[Students[StudentID].Phase];
		Students[StudentID].CurrentDestination = Students[StudentID].Destinations[Students[StudentID].Phase];
		SuitorLocker = LockerPositions[StudentID];
	}

	public void UpdateRivalEliminationDetails(int StudentID)
	{
		RivalKilledSelf[StudentID - 10] = true;
	}

	public void SaveAllStudentPositions()
	{
		for (int i = 1; i < 101; i++)
		{
			if (Students[i] != null)
			{
				Students[i].SavePositionX = Students[i].transform.position.x;
				Students[i].SavePositionY = Students[i].transform.position.y;
				Students[i].SavePositionZ = Students[i].transform.position.z;
			}
		}
	}

	public void LoadAllStudentPositions()
	{
		for (int i = 1; i < 101; i++)
		{
			if (Students[i] != null)
			{
				Students[i].transform.position = new Vector3(Students[i].SavePositionX, Students[i].SavePositionY, Students[i].SavePositionZ);
			}
		}
	}

	public void CheckSelfReportStatus(StudentScript student)
	{
		if (Yandere.Bloodiness == 0f && (double)Yandere.Sanity > 66.66666 && !Yandere.StudentManager.WitnessCamera.Show && Yandere.StudentManager.ChaseCamera == null && !MurderTakingPlace)
		{
			if (Police.Corpses > 0 || Police.LimbParent.childCount > 0 || Police.BloodParent.childCount > 0 || Police.BloodyClothing > 0 || Police.BloodyWeapons > 0)
			{
				CanSelfReport = true;
			}
			else
			{
				CanSelfReport = false;
			}
		}
		else
		{
			CanSelfReport = false;
		}
		if (CanSelfReport)
		{
			student.Prompt.HideButton[0] = false;
			student.Prompt.Label[0].text = "     Report Blood/Corpse";
		}
		else
		{
			student.Prompt.HideButton[0] = true;
		}
	}

	public void UpdateInfatuatedTargetDistances()
	{
		Debug.Log("Rival's Meeting boolean is set to " + Students[RivalID].Meeting + ". Updating InfatuatedTargetDistances.");
		if (Eighties && Week == 9)
		{
			if (DateGlobals.Weekday != DayOfWeek.Monday)
			{
				DecideTargetDistance(1);
			}
			DecideTargetDistance(6);
			DecideTargetDistance(7);
			DecideTargetDistance(8);
			DecideTargetDistance(9);
			DecideTargetDistance(10);
			DecideTargetDistance(23);
			DecideTargetDistance(28);
			DecideTargetDistance(33);
			DecideTargetDistance(38);
			DecideTargetDistance(43);
			DecideTargetDistance(48);
			DecideTargetDistance(63);
			DecideTargetDistance(68);
			DecideTargetDistance(73);
		}
	}

	private void DecideTargetDistance(int ID)
	{
		Debug.Log("Updating the TargetDistance for Student#" + ID);
		if (Students[ID] != null)
		{
			if (Students[RivalID].Meeting)
			{
				Debug.Log("Rival is meeting someone, so TargetDistance is far away.");
				Students[ID].TargetDistance = 10f;
			}
			else
			{
				Debug.Log("Rival is NOT meeting someone, so TargetDistance is nearby.");
				Students[ID].TargetDistance = 5f;
			}
		}
	}

	private void CoupleCheck()
	{
		for (int i = 1; i < Week; i++)
		{
			if (GameGlobals.GetRivalEliminations(i) == 6)
			{
				Debug.Log("Rival #" + i + " was Matchmade! Adjusting her routine now.");
				StudentScript studentScript = Students[10 + i];
				StudentScript studentScript2 = Students[SuitorIDs[i]];
				if (studentScript != null && studentScript2 != null)
				{
					studentScript.PartnerID = SuitorIDs[i];
					studentScript.Partner = Students[studentScript.PartnerID];
					studentScript.CoupleID = i;
					AssignCoupleSchedule(studentScript);
					studentScript2.PartnerID = 10 + i;
					studentScript2.Partner = Students[10 + i];
					studentScript2.CoupleID = i;
					AssignCoupleSchedule(studentScript2);
				}
			}
		}
	}

	private void AssignCoupleSchedule(StudentScript Student)
	{
		ScheduleBlock obj = Student.ScheduleBlocks[2];
		obj.destination = "Cuddle";
		obj.action = "Cuddle";
		ScheduleBlock obj2 = Student.ScheduleBlocks[4];
		obj2.destination = "Cuddle";
		obj2.action = "Cuddle";
		ScheduleBlock obj3 = Student.ScheduleBlocks[6];
		obj3.destination = "Locker";
		obj3.action = "Shoes";
		ScheduleBlock obj4 = Student.ScheduleBlocks[7];
		obj4.destination = "Exit";
		obj4.action = "Exit";
		Student.GetDestinations();
		Student.Pathfinding.target = Student.Destinations[Student.Phase];
		Student.CurrentDestination = Student.Destinations[Student.Phase];
		Student.DressCode = false;
	}

	public void SetTopicLearnedByStudent(int Topic, int StudentID, bool boolean)
	{
		OpinionsLearned.StudentOpinions[StudentID].Opinions[Topic] = boolean;
	}

	public bool GetTopicLearnedByStudent(int Topic, int StudentID)
	{
		return OpinionsLearned.StudentOpinions[StudentID].Opinions[Topic];
	}

	public void LoadTopicsLearned()
	{
		for (int i = 1; i < 101; i++)
		{
			for (int j = 1; j < 26; j++)
			{
				SetTopicLearnedByStudent(j, i, ConversationGlobals.GetTopicLearnedByStudent(j, i));
			}
		}
	}

	public void CheckForAttackPrompt()
	{
		Debug.Log("Checking to see if any attack prompts are active.");
		AttackPromptActive = false;
		for (int i = 1; i < 101; i++)
		{
			if (Students[i] != null && Students[i].gameObject.activeInHierarchy && Yandere.NearestPrompt == Students[i].Prompt && !Students[i].Prompt.HideButton[2])
			{
				Debug.Log("Under the impression that Student #" + i + "'s Attack Prompt is visible.");
				AttackPromptActive = true;
			}
		}
	}

	public void LookAtTest()
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null)
			{
				studentScript.SimpleLook.enabled = true;
			}
		}
	}

	public void MiniMapTest()
	{
		MiniMap.SetActive(value: true);
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null)
			{
				studentScript.MiniMapIcon.enabled = true;
			}
		}
		Yandere.MiniMapIcon.enabled = true;
	}

	public void TeleportEveryoneToDestination()
	{
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null)
			{
				studentScript.transform.position = studentScript.CurrentDestination.position;
			}
		}
		Physics.SyncTransforms();
	}

	public void CheckStudentProximity()
	{
		Debug.Log("Checking to see if any students are currently less than 1 meter away from the player.");
		StudentScript[] students = Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null && studentScript.gameObject.activeInHierarchy && studentScript.DistanceToPlayer < 1f)
			{
				Debug.Log(studentScript.Name + " is less than 1 meter away from the player!");
				Yandere.MyController.Move((Yandere.transform.position - studentScript.transform.position) * 1f);
			}
		}
		Physics.SyncTransforms();
	}
}
