// Decompiled with JetBrains decompiler
// Type: StudentManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
  public ReputationSetterScript ReputationSetter;
  public SkinnedMeshRenderer FemaleShowerCurtain;
  public CleaningManagerScript CleaningManager;
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
  public bool DisableRivalDeathSloMo;
  public bool ReactedToGameLeader;
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
  public bool MetalDetectors;
  public bool RecordingVideo;
  public bool TutorialActive;
  public bool YandereVisible;
  public bool CanSelfReport;
  public bool NoClubMeeting;
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

  private void Awake()
  {
    if (this.TakingPortraits || GameGlobals.Eighties || DateGlobals.Week <= this.WeekLimit)
      return;
    Debug.Log((object) ("We're not in 1980s Mode and Week is " + DateGlobals.Week.ToString() + " so we're resetting the week to ''0'' and booting the player out."));
    DateGlobals.Week = 0;
    SceneManager.LoadScene("VeryFunScene");
  }

  private void Start()
  {
    this.EightiesTutorial = GameGlobals.EightiesTutorial;
    this.DisableRivalDeathSloMo = OptionGlobals.RivalDeathSlowMo;
    this.MissionMode = MissionModeGlobals.MissionMode;
    this.EmptyDemon = GameGlobals.EmptyDemon;
    this.Week = DateGlobals.Week;
    if (GameGlobals.Eighties)
    {
      this.Become1989();
    }
    else
    {
      for (int index = 2; index < 11; ++index)
        this.SuitorIDs[index] = 0;
      this.PortraitChan = this.StudentChan;
      this.PortraitKun = this.StudentKun;
      if ((UnityEngine.Object) this.IdolStage != (UnityEngine.Object) null)
        this.IdolStage.SetActive(false);
      foreach (GameObject modernDayProp in this.ModernDayProps)
      {
        if ((UnityEngine.Object) modernDayProp != (UnityEngine.Object) null)
          modernDayProp.SetActive(true);
      }
      foreach (GameObject eightiesProp in this.EightiesProps)
      {
        if ((UnityEngine.Object) eightiesProp != (UnityEngine.Object) null)
          eightiesProp.SetActive(false);
      }
      if (!this.TakingPortraits)
      {
        this.InfoClubRoom.SetActive(true);
        this.InfoClubProps.SetActive(true);
        this.ModernDayScienceClub.SetActive(true);
        this.ModernDayScienceProps.SetActive(true);
        this.ModernDayPropsLMC.SetActive(true);
        this.ModernDayRoomLMC.SetActive(true);
        this.NewspaperClubProps.SetActive(false);
        this.NewspaperClubRoom.SetActive(false);
        this.EightiesPropsLMC.SetActive(false);
        this.EightiesRoomLMC.SetActive(false);
        this.EightiesScienceClub.SetActive(false);
        this.EightiesScienceProps.SetActive(false);
      }
      this.SuitorID = 6;
    }
    if (this.EightiesTutorial || this.Week > 10)
    {
      this.SpawnNobody = true;
      if (this.Week > 10)
      {
        this.RivalBookBag.gameObject.SetActive(false);
        this.Tutorial.gameObject.SetActive(false);
        this.Yandere.enabled = false;
        this.EndingCutscene.SetActive(true);
        this.Yandere.MainCamera.gameObject.SetActive(false);
        this.Clock.transform.parent = this.FreeFloatingPanel.transform;
        this.Yandere.HUD.transform.parent.gameObject.SetActive(false);
      }
    }
    else if ((UnityEngine.Object) this.Tutorial != (UnityEngine.Object) null)
      this.Tutorial.gameObject.SetActive(false);
    this.InitialSabotageProgress = DatingGlobals.RivalSabotaged;
    this.SabotageProgress = this.InitialSabotageProgress;
    this.LoadCollectibles();
    this.LoadReps();
    this.EmbarassingSecret = SchemeGlobals.EmbarassingSecret;
    if (!ConversationGlobals.GetTopicDiscovered(1))
    {
      for (this.ID = 1; this.ID < 26; ++this.ID)
        ConversationGlobals.SetTopicDiscovered(this.ID, true);
    }
    if (PlayerPrefs.GetInt("LoadingSave") == 1)
      this.ReturnedFromSave = true;
    if (GameGlobals.RivalEliminationID > 0)
    {
      this.ModernRivalBookBag.SetActive(false);
      this.RivalEliminated = true;
    }
    this.RivalID = this.Week + 10;
    StudentGlobals.SetStudentPhotographed(this.RivalID, true);
    this.StudentPhotographed[this.RivalID] = true;
    if ((UnityEngine.Object) this.Police != (UnityEngine.Object) null)
    {
      this.Police.EndOfDay.LearnedOsanaInfo1 = EventGlobals.OsanaEvent1;
      this.Police.EndOfDay.LearnedOsanaInfo2 = EventGlobals.OsanaEvent2;
      this.Police.EndOfDay.LearnedAboutPhotographer = EventGlobals.LearnedAboutPhotographer;
    }
    this.LoveSick = GameGlobals.LoveSick;
    this.MetalDetectors = SchoolGlobals.HighSecurity;
    this.RoofFenceUp = SchoolGlobals.RoofFence;
    if ((UnityEngine.Object) this.Schemes != (UnityEngine.Object) null)
    {
      this.Schemes.HUDIcon.gameObject.SetActive(false);
      this.Schemes.HUDInstructions.text = string.Empty;
      this.Schemes.SchemeManager.CurrentScheme = 0;
      this.Schemes.NextStepInput.SetActive(false);
      SchemeGlobals.CurrentScheme = 0;
    }
    if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
      this.SpawnPositions[51].position = new Vector3(3f, 0.0f, -95f);
    if (this.Eighties && this.Week > 1)
    {
      this.SpawnPositions[94].position = this.FacultyDesks[1].Chair.position;
      this.SpawnPositions[94].rotation = this.FacultyDesks[1].Chair.rotation;
    }
    if (HomeGlobals.LateForSchool)
    {
      this.YandereLate = true;
      Debug.Log((object) "Yandere-chan is late for school!");
    }
    if (GameGlobals.Profile == 0)
    {
      GameGlobals.Profile = 1;
      PlayerGlobals.Money = 10f;
    }
    if (PlayerPrefs.GetInt("LoadingSave") == 1)
    {
      int profile = GameGlobals.Profile;
      int num = PlayerPrefs.GetInt("SaveSlot");
      StudentGlobals.MemorialStudents = PlayerPrefs.GetInt("Profile_" + profile.ToString() + "_Slot_" + num.ToString() + "_MemorialStudents");
    }
    if (!GameGlobals.ReputationsInitialized)
    {
      GameGlobals.ReputationsInitialized = true;
      this.InitializeReputations();
    }
    for (this.ID = 76; this.ID < 81; ++this.ID)
    {
      if ((double) this.StudentReps[this.ID] > -67.0)
        this.StudentReps[this.ID] = -67f;
    }
    if (ClubGlobals.GetClubClosed(ClubType.Gardening))
    {
      this.GardenBlockade.SetActive(true);
      this.Flowers.SetActive(false);
    }
    this.ID = 0;
    for (this.ID = 1; this.ID < this.JSON.Students.Length; ++this.ID)
    {
      if (!this.JSON.Students[this.ID].Success)
      {
        this.ProblemID = this.ID;
        break;
      }
    }
    if (!this.TakingPortraits)
    {
      if (this.FridayPaintings.Length != 0)
      {
        for (this.ID = 1; this.ID < this.FridayPaintings.Length; ++this.ID)
          this.FridayPaintings[this.ID].material.color = new Color(1f, 1f, 1f, 0.0f);
      }
      this.DatingMinigame.Start();
    }
    if (DateGlobals.Weekday != DayOfWeek.Friday)
    {
      if ((UnityEngine.Object) this.Canvases != (UnityEngine.Object) null)
        this.Canvases.SetActive(false);
    }
    else if (this.Week == 1 && ClubGlobals.GetClubClosed(ClubType.Art))
      this.Canvases.SetActive(false);
    if (this.ProblemID != -1)
    {
      if ((UnityEngine.Object) this.ErrorLabel != (UnityEngine.Object) null)
      {
        this.ErrorLabel.text = string.Empty;
        this.ErrorLabel.enabled = false;
      }
      if (this.MissionMode)
      {
        StudentGlobals.FemaleUniform = 5;
        StudentGlobals.MaleUniform = 5;
        this.RedString.gameObject.SetActive(false);
      }
      this.SetAtmosphere();
      GameGlobals.Paranormal = false;
      if (StudentGlobals.StudentSlave > 0 && !StudentGlobals.GetStudentDead(StudentGlobals.StudentSlave))
      {
        int studentSlave = StudentGlobals.StudentSlave;
        this.ForceSpawn = true;
        this.SpawnPositions[studentSlave] = this.SlaveSpot;
        this.SpawnID = studentSlave;
        StudentGlobals.SetStudentDead(studentSlave, false);
        this.SpawnStudent(this.SpawnID);
        this.Students[studentSlave].Slave = true;
        this.SpawnID = 0;
      }
      if (StudentGlobals.FragileSlave > 0)
      {
        if (!StudentGlobals.GetStudentDead(StudentGlobals.FragileSlave))
        {
          int fragileSlave = StudentGlobals.FragileSlave;
          this.ForceSpawn = true;
          this.SpawnPositions[fragileSlave] = this.FragileSlaveSpot;
          this.SpawnID = fragileSlave;
          StudentGlobals.SetStudentDead(fragileSlave, false);
          this.SpawnStudent(this.SpawnID);
          this.Students[fragileSlave].FragileSlave = true;
          this.Students[fragileSlave].Slave = true;
          this.SpawnID = 0;
        }
      }
      else if ((UnityEngine.Object) this.FragileWeapon != (UnityEngine.Object) null)
        this.FragileWeapon.gameObject.SetActive(false);
      this.NPCsTotal = this.StudentsTotal + this.TeachersTotal;
      this.SpawnID = 1;
      if (StudentGlobals.MaleUniform == 0)
        StudentGlobals.MaleUniform = 1;
      for (this.ID = 1; this.ID < this.NPCsTotal + 1; ++this.ID)
      {
        if (!StudentGlobals.GetStudentDead(this.ID))
          StudentGlobals.SetStudentDying(this.ID, false);
      }
      if (!this.TakingPortraits)
      {
        for (this.ID = 1; this.ID < 101; ++this.ID)
          this.TargetSize[this.ID] = (float) (2.0 + (double) this.ID * 0.10000000149011612);
        this.TargetSize[11] = 20f;
        for (this.ID = 1; this.ID < this.Lockers.List.Length; ++this.ID)
        {
          this.LockerPositions[this.ID].transform.position = this.Lockers.List[this.ID].position + this.Lockers.List[this.ID].forward * 0.5f;
          this.LockerPositions[this.ID].LookAt(this.Lockers.List[this.ID].position);
        }
        for (this.ID = 1; this.ID < this.ShowerLockers.List.Length; ++this.ID)
        {
          Transform transform = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, this.ShowerLockers.List[this.ID].position + this.ShowerLockers.List[this.ID].forward * 0.5f, this.ShowerLockers.List[this.ID].rotation).transform;
          transform.parent = this.ShowerLockers.transform;
          transform.transform.eulerAngles = new Vector3(transform.transform.eulerAngles.x, transform.transform.eulerAngles.y + 180f, transform.transform.eulerAngles.z);
          this.StrippingPositions[this.ID] = transform;
        }
        for (this.ID = 1; this.ID < this.HidingSpots.List.Length; ++this.ID)
        {
          if ((UnityEngine.Object) this.HidingSpots.List[this.ID] == (UnityEngine.Object) null)
          {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0.0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
            while ((double) gameObject.transform.position.x < 2.5 && (double) gameObject.transform.position.x > -2.5 && (double) gameObject.transform.position.z > -2.5 && (double) gameObject.transform.position.z < 2.5)
              gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0.0f, UnityEngine.Random.Range(-17f, 17f));
            gameObject.transform.parent = this.HidingSpots.transform;
            this.HidingSpots.List[this.ID] = gameObject.transform;
          }
        }
      }
      if (GameGlobals.AlphabetMode)
      {
        Debug.Log((object) "Entering Alphabet Killer Mode. Repositioning Yandere-chan and others.");
        this.Yandere.transform.position = this.Portal.transform.position + new Vector3(1f, 0.0f, 0.0f);
        this.Clock.StopTime = true;
        this.SkipTo730();
      }
      if (!this.TakingPortraits && !this.RecordingVideo && !this.SpawnNobody)
      {
        for (; this.SpawnID < this.NPCsTotal + 1; ++this.SpawnID)
          this.SpawnStudent(this.SpawnID);
        this.Graffiti[1].SetActive(false);
        this.Graffiti[2].SetActive(false);
        this.Graffiti[3].SetActive(false);
        this.Graffiti[4].SetActive(false);
        this.Graffiti[5].SetActive(false);
        this.RivalChan.SetActive(false);
      }
    }
    else
    {
      string str = string.Empty;
      if (this.ProblemID > 1)
        str = "The problem may be caused by Student " + this.ProblemID.ToString() + ".";
      if ((UnityEngine.Object) this.ErrorLabel != (UnityEngine.Object) null)
      {
        this.ErrorLabel.text = "The game cannot compile Students.JSON! There is a typo somewhere in the JSON file. The problem might be a missing quotation mark, a missing colon, a missing comma, or something else like that. Please find your typo and fix it, or revert to a backup of the JSON file. " + str;
        this.ErrorLabel.enabled = true;
      }
    }
    if (!this.TakingPortraits)
    {
      this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
      this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
      this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
      this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
      if (!this.ReturnedFromSave)
        this.Yandere.Class.GetStats();
      this.Yandere.CameraEffects.UpdateDOF(2f);
    }
    if (PlayerGlobals.PersonaID > 0)
    {
      this.Yandere.PersonaID = PlayerGlobals.PersonaID;
      this.Mirror.UpdatePersona();
    }
    this.LoadPantyshots();
    this.LoadPhotographs();
    if (this.RecordingVideo)
    {
      this.gameObject.SetActive(false);
      this.FPSDisplay.SetActive(false);
      this.FPSDisplayBG.SetActive(false);
      this.Clock.CameraEffects.UpdateBloom(1f);
      this.Clock.CameraEffects.UpdateBloomRadius(4f);
      this.Clock.CameraEffects.UpdateBloomKnee(0.75f);
      this.Yandere.enabled = false;
      this.Yandere.UICamera.gameObject.SetActive(false);
      this.Yandere.MainCamera.gameObject.SetActive(false);
    }
    if (StudentGlobals.UpdateRivalReputation)
      this.StudentReps[this.RivalID] = this.StudentReps[this.RivalID] - 50f;
    this.LoadTopicsLearned();
    if (!((UnityEngine.Object) this.Police != (UnityEngine.Object) null))
      return;
    this.Police.EndOfDay.VoidGoddess.Window.parent.gameObject.SetActive(false);
  }

  public void SetAtmosphere()
  {
    if (GameGlobals.LoveSick)
    {
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.SchoolAtmosphere = 0.0f;
    }
    if (!this.MissionMode)
    {
      if (!SchoolGlobals.SchoolAtmosphereSet)
      {
        SchoolGlobals.SchoolAtmosphereSet = true;
        SchoolGlobals.PreviousSchoolAtmosphere = 1f;
        SchoolGlobals.SchoolAtmosphere = 1f;
      }
      this.Atmosphere = SchoolGlobals.SchoolAtmosphere;
    }
    float num1 = 1f - this.Atmosphere;
    if (!this.TakingPortraits)
    {
      this.SelectiveGreyscale.desaturation = num1;
      if ((UnityEngine.Object) this.HandSelectiveGreyscale != (UnityEngine.Object) null)
      {
        this.HandSelectiveGreyscale.desaturation = num1;
        this.SmartphoneSelectiveGreyscale.desaturation = num1;
      }
      foreach (SelectiveGrayscale spyGrayscale in this.SpyGrayscales)
        spyGrayscale.desaturation = num1;
      float num2 = 1f - num1;
      RenderSettings.fogColor = new Color(num2, num2, num2, 1f);
      Camera.main.backgroundColor = new Color(num2, num2, num2, 1f);
      if (!this.EightiesTutorial)
        RenderSettings.fogDensity = num1 * 0.1f;
    }
    if (!((UnityEngine.Object) this.Yandere != (UnityEngine.Object) null))
      return;
    this.Yandere.GreyTarget = num1;
  }

  private void Update()
  {
    if (!this.TakingPortraits)
    {
      if (!this.Yandere.ShoulderCamera.Counselor.Interrogating && !this.Yandere.PauseScreen.YouTubeChatMenu.isActiveAndEnabled)
      {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      }
      if (this.Frame < 4)
      {
        ++this.Frame;
        if (!this.FirstUpdate)
        {
          this.QualityManager.UpdateOutlines();
          this.FirstUpdate = true;
          this.AssignTeachers();
        }
        if (this.Frame == 3)
        {
          this.Police.EndOfDay.VoidGoddess.UpdatePortraits();
          this.LoveManager.CoupleCheck();
          if (this.Eighties || this.Bullies > 0)
            this.DetermineVictim();
          this.UpdateStudents();
          this.QualityManager.UpdateOutlinesAndRimlight();
          if (this.QualityManager.DisableOutlinesLater)
            OptionGlobals.DisableOutlines = true;
          if (this.QualityManager.DisableRimLightLater)
            OptionGlobals.RimLight = false;
          this.QualityManager.UpdateOutlinesAndRimlight();
          for (int index = 26; index < 31; ++index)
          {
            if ((UnityEngine.Object) this.Students[index] != (UnityEngine.Object) null)
            {
              this.OriginalClubPositions[index - 25] = this.Clubs.List[index].position;
              this.OriginalClubRotations[index - 25] = this.Clubs.List[index].rotation;
            }
          }
          if (!this.TakingPortraits)
            this.TaskManager.UpdateTaskStatus();
          this.Yandere.GloveAttacher.newRenderer.enabled = false;
          this.UpdateAprons();
          if (PlayerPrefs.GetInt("LoadingSave") == 1)
          {
            PlayerPrefs.SetInt("LoadingSave", 0);
            this.Load();
          }
          this.ClubManager.gameObject.SetActive(true);
          if (!this.YandereLate)
          {
            if (StudentGlobals.MemorialStudents > 0 && !this.ReturnedFromSave && DateGlobals.Week < 11)
            {
              this.Yandere.HUD.alpha = 0.0f;
              this.Yandere.RPGCamera.transform.position = new Vector3(38f, 4.125f, 68.825f);
              this.Yandere.RPGCamera.transform.eulerAngles = new Vector3(22.5f, 67.5f, 0.0f);
              this.Yandere.RPGCamera.transform.Translate(Vector3.forward, Space.Self);
              this.Yandere.RPGCamera.enabled = false;
              this.Yandere.HeartCamera.enabled = false;
              this.Yandere.CanMove = false;
              this.Clock.StopTime = true;
              this.StopMoving();
              this.MemorialScene.gameObject.SetActive(true);
              this.MemorialScene.enabled = true;
            }
          }
          else
          {
            Debug.Log((object) "Because Yandere-chan is late for school, we're teleporting students where they would be at 8 AM.");
            this.Clock.PresentTime = 480f;
            this.Clock.HourTime = 8f;
            this.Clock.Hour = Mathf.Floor(this.Clock.PresentTime / 60f);
            this.Clock.Minute = Mathf.Floor((float) (((double) this.Clock.PresentTime / 60.0 - (double) this.Clock.Hour) * 60.0));
            this.Clock.UpdateClock();
            this.Clock.Update();
            this.SkipTo8();
          }
          for (int index = 1; index < 101; ++index)
          {
            if ((UnityEngine.Object) this.Students[index] != (UnityEngine.Object) null)
            {
              if (!this.Students[index].Teacher)
                this.Students[index].ShoeRemoval.Start();
              this.Students[index].AddOutlineToHair();
            }
          }
          this.ClubManager.ActivateClubBenefit();
          if (GameGlobals.CensorPanties)
          {
            this.CensorStudents();
            this.Yandere.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
          }
          if (!this.Eighties)
          {
            if (!this.MissionMode && !GameGlobals.AlphabetMode)
            {
              if (this.Week == 1)
                this.Week1RoutineAdjustments();
              if (this.Week == 2)
              {
                this.Week2RoutineAdjustments();
                this.BakeSale.SetActive(true);
              }
            }
          }
          else
          {
            this.IdolStage.SetActive(false);
            if ((UnityEngine.Object) this.Students[this.RivalID] != (UnityEngine.Object) null)
            {
              if (this.Week == 3)
                this.EightiesWeek3RoutineAdjustments();
              else if (this.Week == 4)
                this.EightiesWeek4RoutineAdjustments();
              else if (this.Week == 5)
                this.EightiesWeek5RoutineAdjustments();
              else if (this.Week == 6)
              {
                this.EightiesWeek6RoutineAdjustments();
                this.IdolStage.SetActive(true);
              }
              else if (this.Week == 7)
                this.EightiesWeek3RoutineAdjustments();
              else if (this.Week == 8)
                this.EightiesWeek8RoutineAdjustments();
              else if (this.Week == 9)
              {
                Debug.Log((object) "Adjusting everyone's routine because of the gravure rival.");
                this.EightiesWeek9RoutineAdjustments();
                int num = 0;
                for (int index = 57; index < 61; ++index)
                {
                  if ((UnityEngine.Object) this.Students[index] != (UnityEngine.Object) null)
                    ++num;
                }
                if ((double) SchoolGlobals.SchoolAtmosphere > 0.800000011920929 && num > 0)
                  this.PoolPhotoShootCameras.SetActive(true);
                else if ((UnityEngine.Object) this.Students[19] != (UnityEngine.Object) null)
                {
                  Debug.Log((object) "Changing Gravure Idol's routine.");
                  this.scheduleBlock = this.Students[19].ScheduleBlocks[2];
                  this.scheduleBlock.destination = "Patrol";
                  this.scheduleBlock.action = "Patrol";
                  this.scheduleBlock = this.Students[19].ScheduleBlocks[7];
                  this.scheduleBlock.destination = "Patrol";
                  this.scheduleBlock.action = "Patrol";
                  this.Students[19].GetDestinations();
                }
              }
              else if (this.Week == 10)
                this.EightiesWeek10RoutineAdjustments();
            }
            if ((UnityEngine.Object) this.Students[this.RivalID] != (UnityEngine.Object) null && (UnityEngine.Object) this.Students[this.SuitorID] != (UnityEngine.Object) null)
              this.ChangeSuitorRoutine(this.SuitorID);
            if (this.Week > 1)
              this.CoupleCheck();
          }
          if (this.SpawnNobody)
          {
            if (this.Week < 11)
            {
              this.TutorialActive = true;
              this.Tutorial.gameObject.SetActive(true);
              this.Tutorial.InstructionLabel.transform.parent.gameObject.SetActive(true);
            }
            if ((double) SchoolGlobals.SchoolAtmosphere < 0.5)
            {
              this.Clock.CameraEffects.UpdateBloom(1f);
              this.Clock.CameraEffects.UpdateBloomKnee(0.5f);
              this.Clock.CameraEffects.UpdateBloomRadius(4f);
            }
            else
            {
              this.Clock.CameraEffects.UpdateBloom(11f);
              this.Clock.CameraEffects.UpdateBloomKnee(1f);
              this.Clock.CameraEffects.UpdateBloomRadius(7f);
            }
            this.FPSDisplay.SetActive(false);
            this.FPSDisplayBG.SetActive(false);
          }
          if (!this.TutorialActive)
            this.Tutorial.InstructionLabel.transform.parent.gameObject.SetActive(false);
          this.UpdateAllBentos();
          if (!this.Eighties)
            this.FanCover.enabled = true;
          if (!this.MissionMode && !GameGlobals.AlphabetMode)
          {
            for (int index = 76; index < 90; ++index)
            {
              if ((UnityEngine.Object) this.Students[index] != (UnityEngine.Object) null)
                this.Students[index].transform.position = this.SpawnPositions[index].position;
            }
          }
          Physics.SyncTransforms();
          if (this.MissionMode)
            this.Yandere.ChangeSchoolwear();
          this.UpdateAllSleuthClothing();
        }
        else if (this.Frame == 4)
        {
          if (this.LoadedSave)
          {
            foreach (RagdollScript corpse in this.Police.CorpseList)
            {
              if ((UnityEngine.Object) corpse != (UnityEngine.Object) null && (UnityEngine.Object) corpse.gameObject != (UnityEngine.Object) null)
                GameObjectUtils.SetLayerRecursively(corpse.gameObject, 11);
            }
            this.LoadAllStudentPositions();
            Physics.SyncTransforms();
            this.Eighties = GameGlobals.Eighties;
            if (!this.Eighties && (UnityEngine.Object) this.Students[this.RivalID] != (UnityEngine.Object) null && this.Students[this.RivalID].Indoors)
              this.UpdateExteriorStudents();
            if (this.BookBag.Worn)
              this.BookBag.Wear();
            this.LoadedSave = false;
            this.Reputation.UpdatePendingRepLabel();
            if (!this.Eighties)
            {
              if ((UnityEngine.Object) this.Students[10] != (UnityEngine.Object) null)
                this.Students[10].Cosmetic.SetFemaleUniform();
              if ((UnityEngine.Object) this.Students[86] != (UnityEngine.Object) null)
                this.Students[86].Cosmetic.SetFemaleUniform();
              if ((UnityEngine.Object) this.Students[87] != (UnityEngine.Object) null)
                this.Students[87].Cosmetic.SetFemaleUniform();
              if ((UnityEngine.Object) this.Students[88] != (UnityEngine.Object) null)
                this.Students[88].Cosmetic.SetFemaleUniform();
              if ((UnityEngine.Object) this.Students[89] != (UnityEngine.Object) null)
                this.Students[89].Cosmetic.SetFemaleUniform();
            }
            else
            {
              if ((UnityEngine.Object) this.Students[86] != (UnityEngine.Object) null)
                this.Students[86].Cosmetic.SetMaleUniform();
              if ((UnityEngine.Object) this.Students[87] != (UnityEngine.Object) null)
                this.Students[87].Cosmetic.SetMaleUniform();
              if ((UnityEngine.Object) this.Students[88] != (UnityEngine.Object) null)
                this.Students[88].Cosmetic.SetMaleUniform();
              if ((UnityEngine.Object) this.Students[89] != (UnityEngine.Object) null)
                this.Students[89].Cosmetic.SetMaleUniform();
            }
            foreach (StudentScript student in this.Students)
            {
              if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.Meeting)
              {
                Debug.Log((object) "A student was in the middle of meeting someone when this save file was made. Attempting to update their schedule accordingly.");
                this.NoteWindow.NoteLocker.StudentID = this.MeetStudentID;
                this.NoteWindow.NoteLocker.MeetTime = this.MeetTime;
                this.NoteWindow.NoteLocker.MeetID = this.MeetID;
                this.NoteWindow.NoteLocker.DetermineSchedule();
                student.MeetTimer = 0.0f;
              }
            }
          }
          if (Screen.width < 1280 || Screen.height < 720)
            Screen.SetResolution(1280, 720, false);
        }
      }
      if ((double) this.Clock.HourTime > 16.9)
        this.CheckMusic();
    }
    else if (this.NPCsSpawned < this.StudentsTotal + this.TeachersTotal)
    {
      ++this.Frame;
      if (this.Frame == 1)
      {
        if ((UnityEngine.Object) this.NewStudent != (UnityEngine.Object) null)
          UnityEngine.Object.Destroy((UnityEngine.Object) this.NewStudent);
        if (this.Eighties || this.NPCsSpawned < 12 || this.NPCsSpawned > 19)
        {
          this.NewStudent = !this.Randomize ? UnityEngine.Object.Instantiate<GameObject>(this.JSON.Students[this.NPCsSpawned + 1].Gender == 0 ? this.PortraitChan : this.PortraitKun, Vector3.zero, Quaternion.identity) : UnityEngine.Object.Instantiate<GameObject>(UnityEngine.Random.Range(0, 2) == 0 ? this.PortraitChan : this.PortraitKun, Vector3.zero, Quaternion.identity);
          CosmeticScript component1 = this.NewStudent.GetComponent<CosmeticScript>();
          component1.StudentID = this.NPCsSpawned + 1;
          component1.StudentManager = this;
          component1.TakingPortrait = true;
          component1.Randomize = this.Randomize;
          component1.JSON = this.JSON;
          component1.Student.enabled = false;
          component1.Student.Prompt.enabled = false;
          component1.Student.MyCollider.enabled = false;
          component1.Student.Pathfinding.enabled = false;
          component1.Student.MyRigidbody.useGravity = false;
          component1.Student.DisableProps();
          if (component1.Student.Male)
            component1.Student.DisableMaleProps();
          else
            component1.Student.DisableFemaleProps();
          component1.Start();
          StudentScript component2 = this.NewStudent.GetComponent<StudentScript>();
          component2.Yandere = this.Yandere;
          component2.SetSplashes(false);
          foreach (Behaviour componentsInChild in component1.gameObject.GetComponentsInChildren<PromptScript>())
            componentsInChild.enabled = false;
          if (!this.Eighties && component1.StudentID == 97)
            this.Whistle.SetActive(true);
        }
        if (!this.Randomize)
          ++this.NPCsSpawned;
      }
      if (this.Frame == 2)
      {
        ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits" + this.EightiesPrefix + "/Student_" + this.NPCsSpawned.ToString() + ".png");
        this.Frame = 0;
      }
    }
    else
    {
      ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Portraits" + this.EightiesPrefix + "/Student_" + this.NPCsSpawned.ToString() + ".png");
      this.gameObject.SetActive(false);
    }
    if (this.Witnesses > 0)
    {
      for (this.ID = 1; this.ID < this.WitnessList.Length; ++this.ID)
      {
        StudentScript witness = this.WitnessList[this.ID];
        if ((UnityEngine.Object) witness != (UnityEngine.Object) null && (!witness.Alive || witness.Attacked || witness.Dying || witness.Routine || witness.Fleeing && !witness.PinningDown))
        {
          witness.PinDownWitness = false;
          if (this.ID != this.WitnessList.Length - 1)
            this.Shuffle(this.ID);
          --this.Witnesses;
        }
      }
      if (this.PinningDown && this.Witnesses < 4)
      {
        Debug.Log((object) "Students were going to pin Yandere-chan down, but now there are less than 4 witnesses, so it's not going to happen.");
        if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
          this.Yandere.CanMove = true;
        this.PinningDown = false;
        this.PinDownTimer = 0.0f;
        this.PinPhase = 0;
      }
    }
    if (this.PinningDown)
    {
      if (!this.Yandere.Attacking && this.Yandere.CanMove)
      {
        this.Yandere.CharacterAnimation.CrossFade("f02_pinDownPanic_00");
        this.Yandere.EmptyHands();
        this.Yandere.CanMove = false;
        if (this.Yandere.YandereVision)
        {
          this.Yandere.YandereVision = false;
          this.Yandere.ResetYandereEffects();
        }
      }
      if (this.PinPhase == 1)
      {
        if (!this.Yandere.Attacking && !this.Yandere.Struggling)
          this.PinTimer += Time.deltaTime;
        if ((double) this.PinTimer > 1.0)
        {
          for (this.ID = 1; this.ID < 5; ++this.ID)
          {
            StudentScript witness = this.WitnessList[this.ID];
            if ((UnityEngine.Object) witness != (UnityEngine.Object) null)
            {
              witness.transform.position = new Vector3(witness.transform.position.x, witness.transform.position.y + 0.1f, witness.transform.position.z);
              witness.CurrentDestination = this.PinDownSpots[this.ID];
              witness.Pathfinding.target = this.PinDownSpots[this.ID];
              witness.SprintAnim = witness.OriginalSprintAnim;
              witness.DistanceToDestination = 100f;
              witness.Pathfinding.speed = 5f;
              witness.MyController.radius = 0.0f;
              witness.PinningDown = true;
              witness.Alarmed = false;
              witness.Routine = false;
              witness.Fleeing = true;
              witness.AlarmTimer = 0.0f;
              witness.SmartPhone.SetActive(false);
              witness.Safe = true;
              witness.Prompt.Hide();
              witness.Prompt.enabled = false;
              Debug.Log((object) (((object) witness)?.ToString() + "'s current destination is " + ((object) witness.CurrentDestination)?.ToString()));
            }
          }
          ++this.PinPhase;
        }
      }
      else if (this.WitnessList[1].PinPhase == 0)
      {
        if (!this.Yandere.ShoulderCamera.Noticed && !this.Yandere.ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
        {
          this.PinDownTimer += Time.deltaTime;
          if ((double) this.PinDownTimer > 10.0 || (double) this.WitnessList[1].DistanceToDestination < 1.0 && (double) this.WitnessList[2].DistanceToDestination < 1.0 && (double) this.WitnessList[3].DistanceToDestination < 1.0 && (double) this.WitnessList[4].DistanceToDestination < 1.0)
          {
            this.Clock.StopTime = true;
            this.Yandere.HUD.enabled = false;
            if (this.Yandere.Aiming)
            {
              this.Yandere.StopAiming();
              this.Yandere.enabled = false;
            }
            this.Yandere.Mopping = false;
            this.Yandere.EmptyHands();
            AudioSource component = this.GetComponent<AudioSource>();
            component.PlayOneShot(this.PinDownSFX);
            component.PlayOneShot(this.YanderePinDown);
            this.Yandere.CharacterAnimation.CrossFade("f02_pinDown_00");
            this.Yandere.CanMove = false;
            this.Yandere.ShoulderCamera.LookDown = true;
            this.Yandere.RPGCamera.enabled = false;
            this.StopMoving();
            this.Yandere.ShoulderCamera.HeartbrokenCamera.GetComponent<Camera>().cullingMask |= 512;
            for (this.ID = 1; this.ID < 5; ++this.ID)
            {
              StudentScript witness = this.WitnessList[this.ID];
              if ((UnityEngine.Object) witness.MyWeapon != (UnityEngine.Object) null)
                GameObjectUtils.SetLayerRecursively(witness.MyWeapon.gameObject, 13);
              witness.CharacterAnimation.CrossFade(((witness.Male ? "pinDown_0" : "f02_pinDown_0") + this.ID.ToString()).ToString());
              ++witness.PinPhase;
            }
          }
        }
      }
      else
      {
        bool flag = false;
        if (!this.WitnessList[1].Male)
        {
          if ((double) this.WitnessList[1].CharacterAnimation["f02_pinDown_01"].time >= (double) this.WitnessList[1].CharacterAnimation["f02_pinDown_01"].length)
            flag = true;
        }
        else if ((double) this.WitnessList[1].CharacterAnimation["pinDown_01"].time >= (double) this.WitnessList[1].CharacterAnimation["pinDown_01"].length)
          flag = true;
        if (flag)
        {
          this.Yandere.CharacterAnimation.CrossFade("f02_pinDownLoop_00");
          for (this.ID = 1; this.ID < 5; ++this.ID)
          {
            StudentScript witness = this.WitnessList[this.ID];
            witness.CharacterAnimation.CrossFade(((witness.Male ? "pinDownLoop_0" : "f02_pinDownLoop_0") + this.ID.ToString()).ToString());
          }
          this.PinningDown = false;
        }
      }
    }
    if (this.Meeting)
      this.UpdateMeeting();
    if ((UnityEngine.Object) this.Police != (UnityEngine.Object) null && (this.Police.BloodParent.childCount > 0 || this.Police.LimbParent.childCount > 0 || this.Yandere.WeaponManager.MisplacedWeapons > 0))
    {
      ++this.CurrentID;
      if (this.CurrentID > 97)
      {
        this.UpdateBlood();
        this.CurrentID = 1;
      }
      if ((UnityEngine.Object) this.Students[this.CurrentID] == (UnityEngine.Object) null)
        ++this.CurrentID;
      else if (!this.Students[this.CurrentID].gameObject.activeInHierarchy)
        ++this.CurrentID;
    }
    if (this.OpenCurtain)
    {
      this.OpenValue = Mathf.Lerp(this.OpenValue, 100f, Time.deltaTime * 10f);
      if ((double) this.OpenValue > 99.0)
        this.OpenCurtain = false;
      this.FemaleShowerCurtain.SetBlendShapeWeight(1, this.OpenValue);
    }
    if (this.AoT)
    {
      this.GrowTimer += Time.deltaTime;
      if ((double) this.GrowTimer < 10.0)
      {
        for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
        {
          StudentScript student = this.Students[this.ID];
          if ((UnityEngine.Object) student != (UnityEngine.Object) null && (double) student.transform.localScale.x < (double) this.TargetSize[this.ID])
            student.transform.localScale = Vector3.Lerp(student.transform.localScale, new Vector3(this.TargetSize[this.ID], this.TargetSize[this.ID], this.TargetSize[this.ID]), Time.deltaTime);
        }
      }
    }
    if (this.Pose)
    {
      for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
      {
        StudentScript student = this.Students[this.ID];
        if ((UnityEngine.Object) student != (UnityEngine.Object) null && (UnityEngine.Object) student.Prompt.Label[0] != (UnityEngine.Object) null)
          student.Prompt.Label[0].text = "     Pose";
      }
    }
    if (this.Yandere.Egg)
    {
      if (this.Sans)
      {
        for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
        {
          StudentScript student = this.Students[this.ID];
          if ((UnityEngine.Object) student != (UnityEngine.Object) null && (UnityEngine.Object) student.Prompt.Label[0] != (UnityEngine.Object) null)
            student.Prompt.Label[0].text = "     Psychokinesis";
        }
      }
      if (this.Ebola)
      {
        for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
        {
          StudentScript student = this.Students[this.ID];
          if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.isActiveAndEnabled && (double) student.DistanceToPlayer < 1.0)
          {
            UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EbolaEffect, student.transform.position + Vector3.up, Quaternion.identity);
            student.SpawnAlarmDisc();
            student.BecomeRagdoll();
            student.DeathType = DeathType.EasterEgg;
          }
        }
      }
      if (this.Yandere.Hunger >= 5)
      {
        for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
        {
          StudentScript student = this.Students[this.ID];
          if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.isActiveAndEnabled && (double) student.DistanceToPlayer < 5.0)
          {
            UnityEngine.Object.Instantiate<GameObject>(this.Yandere.DarkHelix, student.transform.position + Vector3.up, Quaternion.identity);
            student.SpawnAlarmDisc();
            student.BecomeRagdoll();
            student.DeathType = DeathType.EasterEgg;
          }
        }
      }
    }
    if ((UnityEngine.Object) this.PlazaOccluder != (UnityEngine.Object) null)
      this.PlazaOccluder.open = (double) this.Yandere.transform.position.z >= -50.0;
    if ((UnityEngine.Object) this.BehindSchoolOccluder != (UnityEngine.Object) null)
      this.BehindSchoolOccluder.open = (double) this.Yandere.transform.position.z <= 50.0;
    this.YandereVisible = false;
  }

  public void SpawnStudent(int spawnID)
  {
    bool flag = false;
    if (this.Eighties)
    {
      if (spawnID > this.Week + this.WeekLimit && spawnID < 21)
        flag = true;
    }
    else
    {
      if (spawnID > 11 && spawnID < 21)
        flag = true;
      if (this.Week == 2 && spawnID == 12)
        flag = false;
    }
    if (this.JSON.Students[spawnID].Club != ClubType.Delinquent && StudentGlobals.GetStudentReputation(spawnID) < -100)
      flag = true;
    if (!flag && (UnityEngine.Object) this.Students[spawnID] == (UnityEngine.Object) null && !StudentGlobals.GetStudentDead(spawnID) && !StudentGlobals.GetStudentKidnapped(spawnID) && !StudentGlobals.GetStudentArrested(spawnID) && !StudentGlobals.GetStudentExpelled(spawnID))
    {
      int num;
      if (this.JSON.Students[spawnID].Name == "Random")
      {
        GameObject gameObject1 = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, new Vector3(UnityEngine.Random.Range(-17f, 17f), 0.0f, UnityEngine.Random.Range(-17f, 17f)), Quaternion.identity);
        while ((double) gameObject1.transform.position.x < 2.5 && (double) gameObject1.transform.position.x > -2.5 && (double) gameObject1.transform.position.z > -2.5 && (double) gameObject1.transform.position.z < 2.5)
          gameObject1.transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 0.0f, UnityEngine.Random.Range(-17f, 17f));
        gameObject1.transform.parent = this.HidingSpots.transform;
        this.HidingSpots.List[spawnID] = gameObject1.transform;
        GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
        gameObject2.transform.parent = this.Patrols.transform;
        this.Patrols.List[spawnID] = gameObject2.transform;
        GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.RandomPatrol, Vector3.zero, Quaternion.identity);
        gameObject3.transform.parent = this.CleaningSpots.transform;
        this.CleaningSpots.List[spawnID] = gameObject3.transform;
        num = !this.MissionMode || MissionModeGlobals.MissionTarget != spawnID ? UnityEngine.Random.Range(0, 2) : 0;
        this.FindUnoccupiedSeat();
      }
      else
        num = this.JSON.Students[spawnID].Gender;
      this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(num == 0 ? this.StudentChan : this.StudentKun, this.SpawnPositions[spawnID].position, Quaternion.identity);
      CosmeticScript component = this.NewStudent.GetComponent<CosmeticScript>();
      component.LoveManager = this.LoveManager;
      component.StudentManager = this;
      component.Randomize = this.Randomize;
      component.StudentID = spawnID;
      component.JSON = this.JSON;
      if (this.JSON.Students[spawnID].Name == "Random")
      {
        this.NewStudent.GetComponent<StudentScript>().CleaningSpot = this.CleaningSpots.List[spawnID];
        this.NewStudent.GetComponent<StudentScript>().CleaningRole = 3;
      }
      if (this.JSON.Students[spawnID].Club == ClubType.Bully)
        ++this.Bullies;
      this.Students[spawnID] = this.NewStudent.GetComponent<StudentScript>();
      StudentScript student = this.Students[spawnID];
      student.ChaseSelectiveGrayscale.desaturation = 1f - SchoolGlobals.SchoolAtmosphere;
      student.Cosmetic.TextureManager = this.TextureManager;
      student.WitnessCamera = this.WitnessCamera;
      student.StudentManager = this;
      student.StudentID = spawnID;
      student.JSON = this.JSON;
      student.Ragdoll.StudentID = spawnID;
      student.BloodSpawnerIdentifier.ObjectID = "Student_" + spawnID.ToString() + "_BloodSpawner";
      student.HipsIdentifier.ObjectID = "Student_" + spawnID.ToString() + "_Hips";
      student.YanSave.ObjectID = "Student_" + spawnID.ToString();
      if ((UnityEngine.Object) student.Miyuki != (UnityEngine.Object) null)
        student.Miyuki.Enemy = this.MiyukiCat;
      if (this.AoT)
        student.AoT = true;
      if (this.DK)
        student.DK = true;
      if (this.Spooky)
        student.Spooky = true;
      if (this.Sans)
        student.BadTime = true;
      if (!this.MissionMode)
      {
        if (spawnID == this.RivalID && !this.RivalEliminated)
        {
          student.Rival = true;
          this.RedString.transform.parent = student.LeftPinky;
          this.RedString.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
        if (spawnID == 1)
          this.RedString.Target = student.LeftPinky;
      }
      else if (spawnID == MissionModeGlobals.MissionTarget)
        student.Rival = true;
      if (num == 0)
      {
        ++this.GirlsSpawned;
        student.GirlID = this.GirlsSpawned;
      }
      this.OccupySeat();
    }
    ++this.NPCsSpawned;
    this.ForceSpawn = false;
  }

  public void UpdateStudents(int SpecificStudent = 0)
  {
    this.ID = 2;
    while (this.ID < this.Students.Length)
    {
      bool flag = false;
      if (SpecificStudent != 0)
      {
        this.ID = SpecificStudent;
        flag = true;
      }
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        student.CanTakeSnack = false;
        student.CanGiveHelp = false;
        student.CanBeFed = false;
        if (student.gameObject.activeInHierarchy || student.Hurry)
        {
          if (!student.Safe)
          {
            if (!student.Slave)
            {
              student.Prompt.Label[0].text = !student.Pushable ? (!this.Yandere.SpiderGrow ? (student.Following ? "     Stop" : "     Talk") : (student.Cosmetic.Empty ? "     Talk" : "     Send Husk")) : "     Push";
              student.Prompt.HideButton[0] = false;
              student.Prompt.HideButton[2] = false;
              student.Prompt.Attack = false;
              if ((UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null || student.Ragdoll.Zs.activeInHierarchy)
                student.Prompt.HideButton[0] = true;
              if (this.Yandere.Dragging || (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null || this.Yandere.Chased)
              {
                student.Prompt.HideButton[0] = true;
                student.Prompt.HideButton[2] = true;
                if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && !student.Following)
                {
                  if (this.Yandere.PickUp.Food > 0)
                  {
                    student.Prompt.Label[0].text = "     Feed";
                    student.Prompt.HideButton[0] = false;
                    student.Prompt.HideButton[2] = true;
                    student.CanBeFed = true;
                  }
                  else if (this.Yandere.PickUp.Salty)
                  {
                    student.Prompt.Label[0].text = "     Give Snack";
                    student.Prompt.HideButton[0] = false;
                    student.Prompt.HideButton[2] = true;
                    student.CanTakeSnack = true;
                  }
                  else if ((UnityEngine.Object) this.Yandere.PickUp.StuckBoxCutter != (UnityEngine.Object) null)
                  {
                    student.Prompt.Label[0].text = "     Ask For Help";
                    student.Prompt.HideButton[0] = false;
                    student.Prompt.HideButton[2] = true;
                    student.CanGiveHelp = true;
                  }
                  else if (this.Yandere.PickUp.PuzzleCube)
                  {
                    student.Prompt.Label[0].text = "     Give Puzzle";
                    student.Prompt.HideButton[0] = false;
                    student.Prompt.HideButton[2] = true;
                  }
                }
              }
              if (this.Yandere.Armed)
              {
                student.Prompt.HideButton[0] = true;
                student.Prompt.Attack = true;
                student.Prompt.MinimumDistanceSqr = 1f;
                student.Prompt.MinimumDistance = 1f;
              }
              else
              {
                student.Prompt.HideButton[2] = true;
                student.Prompt.MinimumDistanceSqr = 2f;
                student.Prompt.MinimumDistance = 2f;
                if (student.WitnessedMurder || student.WitnessedCorpse || student.Private)
                  student.Prompt.HideButton[0] = true;
              }
              if (this.Yandere.NearBodies > 0 || (double) this.Yandere.Sanity < 33.333328247070313)
                student.Prompt.HideButton[0] = true;
              if (student.Teacher)
                this.CheckSelfReportStatus(student);
            }
            else if (!student.FragileSlave)
            {
              if (this.Yandere.Armed)
              {
                if (this.Yandere.EquippedWeapon.Concealable)
                {
                  student.Prompt.HideButton[0] = false;
                  student.Prompt.Label[0].text = "     Give Weapon";
                }
                else
                {
                  student.Prompt.HideButton[0] = true;
                  student.Prompt.Label[0].text = string.Empty;
                }
              }
              else
              {
                student.Prompt.HideButton[0] = true;
                student.Prompt.Label[0].text = string.Empty;
              }
            }
          }
          if (student.FightingSlave && this.Yandere.Armed && this.Yandere.EquippedWeapon.Type == WeaponType.Knife)
          {
            Debug.Log((object) "Fighting with a slave!");
            student.Prompt.Label[0].text = "     Stab";
            student.Prompt.HideButton[0] = false;
            student.Prompt.HideButton[2] = true;
            student.Prompt.enabled = true;
          }
          if (this.NoSpeech && !student.Armband.activeInHierarchy)
            student.Prompt.HideButton[0] = true;
        }
        if ((UnityEngine.Object) student.Prompt.Label[0] != (UnityEngine.Object) null)
        {
          if (this.Sans)
          {
            student.Prompt.HideButton[0] = false;
            student.Prompt.Label[0].text = "     Psychokinesis";
          }
          if (this.Pose)
          {
            student.Prompt.HideButton[0] = false;
            student.Prompt.Label[0].text = "     Pose";
            student.Prompt.BloodMask = 1;
            student.Prompt.BloodMask |= 2;
            student.Prompt.BloodMask |= 512;
            student.Prompt.BloodMask |= 8192;
            student.Prompt.BloodMask |= 16384;
            student.Prompt.BloodMask |= 65536;
            student.Prompt.BloodMask |= 2097152;
            student.Prompt.BloodMask = ~student.Prompt.BloodMask;
          }
          if (!student.Teacher && this.Six)
          {
            student.Prompt.MinimumDistance = 0.75f;
            student.Prompt.HideButton[0] = false;
            student.Prompt.Label[0].text = "     Eat";
          }
          if (this.Gaze)
          {
            student.Prompt.MinimumDistance = 5f;
            student.Prompt.HideButton[0] = false;
            student.Prompt.Label[0].text = "     Gaze";
          }
        }
        if (this.EmptyDemon)
          student.Prompt.HideButton[0] = false;
      }
      ++this.ID;
      if (flag)
        this.ID = this.Students.Length;
    }
    this.Container.UpdatePrompts();
    for (int index = 1; index < this.TrashCans.Length; ++index)
      this.TrashCans[index].UpdatePrompt();
  }

  public void UpdateMe(int ID)
  {
    if (ID <= 1)
      return;
    StudentScript student = this.Students[ID];
    if (!((UnityEngine.Object) student != (UnityEngine.Object) null))
      return;
    if (!student.Safe)
    {
      student.Prompt.Label[0].text = "     Talk";
      student.Prompt.HideButton[0] = false;
      student.Prompt.HideButton[2] = false;
      student.Prompt.Attack = false;
      if (student.FightingSlave)
      {
        if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Type == WeaponType.Knife)
        {
          Debug.Log((object) "Fighting with a slave!");
          student.Prompt.Label[0].text = "     Stab";
          student.Prompt.HideButton[0] = false;
          student.Prompt.HideButton[2] = true;
          student.Prompt.enabled = true;
        }
      }
      else
      {
        if (this.Yandere.Armed && this.OriginalUniforms + this.NewUniforms > 0)
        {
          student.Prompt.HideButton[0] = true;
          student.Prompt.MinimumDistance = 1f;
          student.Prompt.Attack = true;
        }
        else
        {
          student.Prompt.HideButton[2] = true;
          student.Prompt.MinimumDistance = 2f;
          if (student.WitnessedMurder || student.WitnessedCorpse || student.Private)
            student.Prompt.HideButton[0] = true;
        }
        student.Prompt.Label[2].text = "     Attack";
        if (student.Drownable && !this.Yandere.Armed && (UnityEngine.Object) this.Yandere.PickUp == (UnityEngine.Object) null)
        {
          student.Prompt.Label[2].text = "     Drown";
          student.Prompt.HideButton[0] = true;
          student.Prompt.HideButton[2] = false;
          student.Prompt.MinimumDistance = 1f;
          student.Prompt.Attack = true;
        }
        if (student.Pushable && !this.Yandere.Armed && (UnityEngine.Object) this.Yandere.PickUp == (UnityEngine.Object) null)
        {
          student.Prompt.Label[2].text = "     Push";
          student.Prompt.HideButton[0] = true;
          student.Prompt.HideButton[2] = false;
          student.Prompt.MinimumDistance = 1f;
          student.Prompt.Attack = true;
        }
        if (this.Yandere.Dragging || (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null || this.Yandere.Chased || this.Yandere.Chasers > 0)
        {
          student.Prompt.HideButton[0] = true;
          student.Prompt.HideButton[2] = true;
        }
        if (this.Yandere.NearBodies > 0 || (double) this.Yandere.Sanity < 33.333328247070313)
          student.Prompt.HideButton[0] = true;
        if (student.Teacher)
          this.CheckSelfReportStatus(student);
      }
    }
    if (this.Sans)
    {
      student.Prompt.HideButton[0] = false;
      student.Prompt.Label[0].text = "     Psychokinesis";
    }
    if (this.Pose)
    {
      student.Prompt.HideButton[0] = false;
      student.Prompt.Label[0].text = "     Pose";
    }
    if (!this.NoSpeech && !student.Ragdoll.Zs.activeInHierarchy)
      return;
    student.Prompt.HideButton[0] = true;
  }

  public void AttendClass()
  {
    this.ConvoManager.Confirmed = false;
    this.SleuthPhase = 3;
    if (this.RingEvent.EventActive)
      this.RingEvent.ReturnRing();
    while (this.NPCsSpawned < this.NPCsTotal)
    {
      this.SpawnStudent(this.SpawnID);
      ++this.SpawnID;
    }
    if (this.Clock.LateStudent)
      this.Clock.ActivateLateStudent();
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        if (student.Meeting)
          student.StopMeeting();
        if (student.WitnessedBloodPool && !student.WitnessedMurder && !student.WitnessedCorpse)
        {
          student.Fleeing = false;
          student.Alarmed = false;
          student.AlarmTimer = 0.0f;
          student.ReportPhase = 0;
          student.WitnessedBloodPool = false;
        }
        if (student.HoldingHands)
        {
          student.HoldingHands = false;
          student.Paired = false;
          student.enabled = true;
        }
        if (student.Alive && !student.Slave && !student.Tranquil && !student.Fleeing && student.enabled && student.gameObject.activeInHierarchy)
        {
          if (!student.Started)
            student.Start();
          if (!student.Teacher)
          {
            if (!student.Indoors)
            {
              if ((UnityEngine.Object) student.ShoeRemoval.Locker == (UnityEngine.Object) null)
                student.ShoeRemoval.Start();
              student.ShoeRemoval.PutOnShoes();
            }
            student.transform.position = student.Seat.position + Vector3.up * 0.01f;
            student.transform.rotation = student.Seat.rotation;
            student.CharacterAnimation.Play(student.SitAnim);
            student.Pathfinding.canSearch = false;
            student.Pathfinding.canMove = false;
            student.Pathfinding.speed = 0.0f;
            student.ClubActivityPhase = 0;
            student.ClubTimer = 0.0f;
            student.Patience = 5;
            student.Pestered = 0;
            if (student.SentToLocker)
              this.NoteWindow.NoteLocker.Finish();
            student.Distracting = false;
            student.Distracted = false;
            student.Tripping = false;
            student.Ignoring = false;
            student.Pushable = false;
            student.Private = false;
            student.Sedated = false;
            student.Emetic = false;
            student.Hurry = false;
            student.Safe = false;
            student.CanTalk = true;
            student.Routine = true;
            if (student.Wet)
            {
              student.CharacterAnimation[student.WetAnim].weight = 0.0f;
              this.CommunalLocker.Student = (StudentScript) null;
              student.Schoolwear = 3;
              student.ChangeSchoolwear();
              student.LiquidProjector.enabled = false;
              student.Splashed = false;
              student.Bloody = false;
              student.BathePhase = 1;
              student.Wet = false;
              student.UnWet();
              if (student.Rival && this.CommunalLocker.RivalPhone.Stolen)
                student.RealizePhoneIsMissing();
            }
            if (student.ClubAttire)
            {
              student.ChangeSchoolwear();
              student.ClubAttire = false;
            }
            if (!student.Male && student.BikiniAttacher.enabled)
              student.ChangeSchoolwear();
            if (student.Schoolwear != 1)
            {
              if (!student.BeenSplashed)
              {
                student.Schoolwear = 1;
                student.ChangeSchoolwear();
                student.MustChangeClothing = false;
              }
              student.SunbathePhase = 0;
            }
            if (student.Meeting && (double) this.Clock.HourTime > (double) student.MeetTime)
              student.Meeting = false;
            if (student.Club == ClubType.Sports)
            {
              student.SetSplashes(false);
              student.WalkAnim = student.OriginalWalkAnim;
              student.Character.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
              if (student.Cosmetic.Goggles.Length != 0 && (UnityEngine.Object) student.Cosmetic.Goggles[student.StudentID].GetComponent<SkinnedMeshRenderer>() != (UnityEngine.Object) null)
                student.Cosmetic.Goggles[student.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0.0f);
              if (!student.Cosmetic.Empty && student.Male && (UnityEngine.Object) student.Cosmetic.MaleHair[student.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>() != (UnityEngine.Object) null)
                student.Cosmetic.MaleHair[student.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0.0f);
            }
            if ((UnityEngine.Object) student.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) student.MyPlate.transform.parent == (UnityEngine.Object) student.RightHand)
            {
              student.MyPlate.transform.parent = (Transform) null;
              student.MyPlate.transform.position = student.OriginalPlatePosition;
              student.MyPlate.transform.rotation = student.OriginalPlateRotation;
              student.IdleAnim = student.OriginalIdleAnim;
              student.WalkAnim = student.OriginalWalkAnim;
            }
            if (student.ReturningMisplacedWeapon)
              student.ReturnMisplacedWeapon();
            if (student.UpdateAppearance)
              student.UpdateGemaAppearance();
          }
          else if (this.ID != this.GymTeacherID && this.ID != this.NurseID)
          {
            student.transform.position = this.Podiums.List[student.Class].position + Vector3.up * 0.01f;
            student.transform.rotation = this.Podiums.List[student.Class].rotation;
          }
          else
          {
            student.transform.position = student.Seat.position + Vector3.up * 0.01f;
            student.transform.rotation = student.Seat.rotation;
          }
        }
      }
    }
    this.UpdateStudents();
    if (GameGlobals.SenpaiMourning)
    {
      this.Students[1].gameObject.SetActive(false);
      this.Students[1].transform.position = new Vector3(0.0f, 100f, 0.0f);
    }
    Physics.SyncTransforms();
    for (int index = 1; index < 10; ++index)
    {
      if ((UnityEngine.Object) this.ShrineCollectibles[index] != (UnityEngine.Object) null)
        this.ShrineCollectibles[index].SetActive(true);
    }
    this.Gift.SetActive(false);
  }

  public void SkipTo8()
  {
    while (this.NPCsSpawned < this.NPCsTotal)
    {
      this.SpawnStudent(this.SpawnID);
      ++this.SpawnID;
    }
    int num1 = 0;
    int num2 = 0;
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.Alive && !student.Slave && !student.Tranquil)
      {
        if (!student.Started)
          student.Start();
        bool flag = false;
        if (this.MemorialScene.enabled && student.Teacher)
        {
          flag = true;
          student.Teacher = false;
        }
        if (!student.Teacher)
        {
          if (!student.Indoors)
          {
            if ((UnityEngine.Object) student.ShoeRemoval.Locker == (UnityEngine.Object) null)
              student.ShoeRemoval.Start();
            student.ShoeRemoval.PutOnShoes();
          }
          student.transform.position = student.Seat.position + Vector3.up * 0.01f;
          student.transform.rotation = student.Seat.rotation;
          if (student.StudentID == 10 && (UnityEngine.Object) this.Students[11] != (UnityEngine.Object) null)
            student.transform.position = this.Students[11].transform.position;
          Physics.SyncTransforms();
          student.Pathfinding.canSearch = true;
          student.Pathfinding.canMove = true;
          student.Pathfinding.speed = 1f;
          student.ClubActivityPhase = 0;
          student.Distracted = false;
          student.Spawned = true;
          student.Routine = true;
          student.Safe = false;
          student.SprintAnim = student.OriginalSprintAnim;
          if (student.ClubAttire)
          {
            student.ChangeSchoolwear();
            student.ClubAttire = true;
          }
          student.TeleportToDestination();
          student.TeleportToDestination();
        }
        else
        {
          student.TeleportToDestination();
          student.TeleportToDestination();
        }
        if (this.MemorialScene.enabled)
        {
          if (flag)
            student.Teacher = true;
          if (student.Persona == PersonaType.PhoneAddict)
            student.SmartPhone.SetActive(true);
          if (student.Actions[student.Phase] == StudentActionType.Graffiti && !this.Bully)
          {
            student.OriginalActions[2] = StudentActionType.Patrol;
            ScheduleBlock scheduleBlock = student.ScheduleBlocks[2];
            scheduleBlock.destination = "Patrol";
            scheduleBlock.action = "Patrol";
            student.GetDestinations();
          }
          student.SpeechLines.Stop();
          student.transform.position = new Vector3((float) (20.0 + (double) num1 * 1.1000000238418579), 0.0f, (float) (82 - num2 * 5));
          ++num2;
          if (num2 > 4)
          {
            ++num1;
            num2 = 0;
          }
        }
      }
    }
  }

  public void SkipTo730()
  {
    while (this.NPCsSpawned < this.NPCsTotal)
    {
      this.SpawnStudent(this.SpawnID);
      ++this.SpawnID;
    }
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.Alive && !student.Slave && !student.Tranquil)
      {
        if (!student.Started)
          student.Start();
        if (!student.Teacher)
        {
          if (!student.Indoors)
          {
            if ((UnityEngine.Object) student.ShoeRemoval.Locker == (UnityEngine.Object) null)
              student.ShoeRemoval.Start();
            student.ShoeRemoval.PutOnShoes();
          }
          student.transform.position = student.Seat.position + Vector3.up * 0.01f;
          student.transform.rotation = student.Seat.rotation;
          student.Pathfinding.canSearch = true;
          student.Pathfinding.canMove = true;
          student.Pathfinding.speed = 1f;
          student.ClubActivityPhase = 0;
          student.Distracted = false;
          student.Spawned = true;
          student.Routine = true;
          student.Safe = false;
          student.SprintAnim = student.OriginalSprintAnim;
          if (student.ClubAttire)
          {
            student.ChangeSchoolwear();
            student.ClubAttire = true;
          }
          student.AltTeleportToDestination();
          student.AltTeleportToDestination();
        }
        else
        {
          student.AltTeleportToDestination();
          student.AltTeleportToDestination();
        }
      }
    }
    Physics.SyncTransforms();
  }

  public void ResumeMovement()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && !student.Fleeing)
      {
        student.Pathfinding.canSearch = true;
        student.Pathfinding.canMove = true;
        student.Pathfinding.speed = 1f;
        if (!student.TurnOffRadio)
          student.Routine = true;
      }
    }
  }

  public void UpdateAllSleuthClothing()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.Persona == PersonaType.Sleuth)
      {
        if (!student.Male)
          student.Cosmetic.SetFemaleUniform();
        else
          student.Cosmetic.SetMaleUniform();
      }
    }
  }

  public void StopMoving()
  {
    this.CombatMinigame.enabled = false;
    this.Stop = true;
    if (this.GameOverIminent)
    {
      this.Portal.GetComponent<PortalScript>().EndEvents();
      this.Portal.GetComponent<PortalScript>().EndLaterEvents();
    }
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        if (!student.Dying && !student.PinningDown && !student.Spraying && !student.Struggling && !student.Drowned)
        {
          if (this.YandereDying && student.Club != ClubType.Council)
            student.IdleAnim = student.ScaredAnim;
          if (this.Yandere.Attacking)
          {
            if (student.MurderReaction == 0 && !student.Blind)
              student.Character.GetComponent<Animation>().CrossFade(student.ScaredAnim);
          }
          else if (this.ID > 1 && (UnityEngine.Object) student.CharacterAnimation != (UnityEngine.Object) null)
            student.CharacterAnimation.CrossFade(student.IdleAnim);
          student.Pathfinding.canSearch = false;
          student.Pathfinding.canMove = false;
          student.Pathfinding.speed = 0.0f;
          student.Stop = true;
          if ((UnityEngine.Object) student.EventManager != (UnityEngine.Object) null)
            student.EventManager.EndEvent();
        }
        if (student.Alive)
        {
          if (student.SawMask)
            this.Police.MaskReported = true;
          if (student.Slave && (this.Yandere.Noticed || this.Police.DayOver))
          {
            Debug.Log((object) "A mind-broken slave committed suicide.");
            student.Broken.Subtitle.text = string.Empty;
            student.Broken.Done = true;
            UnityEngine.Object.Destroy((UnityEngine.Object) student.Broken);
            student.BecomeRagdoll();
            student.Slave = false;
            student.Suicide = true;
            student.DeathType = DeathType.Mystery;
            StudentGlobals.StudentSlave = student.StudentID;
            if ((UnityEngine.Object) student.MyWeapon != (UnityEngine.Object) null)
            {
              student.MyWeapon.Victims[student.StudentID] = true;
              student.MyWeapon.transform.parent = (Transform) null;
              student.MyWeapon.Blood.enabled = true;
              student.MyWeapon.Evidence = true;
              student.MyWeapon.Drop();
              student.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
              student.MyWeapon = (WeaponScript) null;
            }
          }
        }
      }
    }
  }

  public void TimeFreeze()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.Alive)
      {
        student.enabled = false;
        student.CharacterAnimation.Stop();
        student.Pathfinding.canSearch = false;
        student.Pathfinding.canMove = false;
        student.Prompt.Hide();
        student.Prompt.enabled = false;
      }
    }
  }

  public void TimeUnfreeze()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.Alive)
      {
        student.enabled = true;
        student.Prompt.enabled = true;
        student.Pathfinding.canSearch = true;
        student.Pathfinding.canMove = true;
      }
    }
  }

  public void ComeBack()
  {
    this.Stop = false;
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && (!this.Police.EndOfDay.Counselor.ExpelledDelinquents || this.ID <= 75 || this.ID >= 81))
      {
        if (!student.Dying && !student.Replaced && student.Spawned && !StudentGlobals.GetStudentExpelled(this.ID) && !StudentGlobals.GetStudentArrested(this.ID) && !student.Ragdoll.Disposed)
        {
          student.gameObject.SetActive(true);
          student.Pathfinding.canSearch = true;
          student.Pathfinding.canMove = true;
          student.Pathfinding.speed = 1f;
          student.Stop = false;
        }
        if (student.Teacher)
        {
          student.CurrentDestination = student.Destinations[student.Phase];
          student.Pathfinding.target = student.Destinations[student.Phase];
          student.Alarmed = false;
          student.Reacted = false;
          student.Witness = false;
          student.Routine = true;
          student.AlarmTimer = 0.0f;
          student.Concern = 0;
        }
        if (student.Club == ClubType.Council)
          student.Teacher = false;
        if (student.Slave)
          student.Stop = false;
      }
    }
    this.UpdateAllAnimLayers();
    if (this.Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Expelled || this.Police.EndOfDay.RivalEliminationMethod == RivalEliminationType.Arrested)
      this.Students[this.RivalID].gameObject.SetActive(false);
    if (GameGlobals.SenpaiMourning)
      this.Students[1].gameObject.SetActive(false);
    this.Yandere.SetAnimationLayers();
  }

  public void StopFleeing()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && !student.Teacher)
      {
        student.Pathfinding.target = student.Destinations[student.Phase];
        student.Pathfinding.speed = 1f;
        student.WitnessedCorpse = false;
        student.WitnessedMurder = false;
        student.Alarmed = false;
        student.Fleeing = false;
        student.Reacted = false;
        student.Witness = false;
        student.Routine = true;
      }
    }
  }

  public void EnablePrompts()
  {
    for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.Prompt.enabled = true;
    }
  }

  public void DisablePrompts()
  {
    for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        student.Prompt.Hide();
        student.Prompt.enabled = false;
      }
    }
  }

  public void WipePendingRep()
  {
    for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.PendingRep = 0.0f;
    }
  }

  public void AttackOnTitan()
  {
    this.RandomizeRoutines();
    this.Students[1].Blind = true;
    this.AoT = true;
    for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.AttackOnTitan();
    }
  }

  public void Kong()
  {
    this.DK = true;
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.DK = true;
    }
  }

  public void Spook()
  {
    this.Spooky = true;
    for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && !student.Male)
        student.Spook();
    }
  }

  public void BadTime()
  {
    this.Sans = true;
    for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        student.Prompt.HideButton[0] = false;
        student.BadTime = true;
      }
    }
  }

  public void UpdateBooths()
  {
    for (this.ID = 0; this.ID < this.ChangingBooths.Length; ++this.ID)
    {
      ChangingBoothScript changingBooth = this.ChangingBooths[this.ID];
      if ((UnityEngine.Object) changingBooth != (UnityEngine.Object) null)
        changingBooth.CheckYandereClub();
    }
  }

  public void UpdatePerception()
  {
    for (this.ID = 0; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.UpdatePerception();
    }
  }

  public void StopHesitating()
  {
    for (this.ID = 0; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        if ((double) student.AlarmTimer > 0.0)
          student.AlarmTimer = 1f;
        student.Hesitation = 0.0f;
      }
    }
  }

  public void Unstop()
  {
    for (this.ID = 0; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.Stop = false;
    }
  }

  public void LowerCorpsePosition()
  {
    Debug.Log((object) ("Corpse's Y position is: " + this.CorpseLocation.position.y.ToString()));
    this.CorpseLocation.position = new Vector3(this.CorpseLocation.position.x, (double) this.CorpseLocation.position.y <= 1.3999999761581421 || (double) this.CorpseLocation.position.y >= 1.6000000238418579 ? ((double) this.CorpseLocation.position.y >= 2.0 ? ((double) this.CorpseLocation.position.y >= 4.0 ? ((double) this.CorpseLocation.position.y >= 6.0 ? ((double) this.CorpseLocation.position.y >= 8.0 ? ((double) this.CorpseLocation.position.y >= 10.0 ? ((double) this.CorpseLocation.position.y >= 12.0 ? 12f : 10f) : 8f) : 6f) : 4f) : 2f) : 0.0f) : 1.4f, this.CorpseLocation.position.z);
  }

  public void LowerBloodPosition() => this.BloodLocation.position = new Vector3(this.BloodLocation.position.x, (double) this.BloodLocation.position.y >= 2.0 ? ((double) this.BloodLocation.position.y >= 4.0 ? ((double) this.BloodLocation.position.y >= 6.0 ? ((double) this.BloodLocation.position.y >= 8.0 ? ((double) this.BloodLocation.position.y >= 10.0 ? ((double) this.BloodLocation.position.y >= 12.0 ? 12f : 10f) : 8f) : 6f) : 4f) : 2f) : 0.0f, this.BloodLocation.position.z);

  public void CensorStudents()
  {
    for (this.ID = 0; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && !student.Male && student.Club != ClubType.Teacher && student.Club != ClubType.GymTeacher && student.Club != ClubType.Nurse)
      {
        if (GameGlobals.CensorPanties)
          student.Cosmetic.CensorPanties();
        else
          student.Cosmetic.RemoveCensor();
      }
    }
  }

  private void OccupySeat()
  {
    int num = this.JSON.Students[this.SpawnID].Class;
    int seat = this.JSON.Students[this.SpawnID].Seat;
    switch (num)
    {
      case 11:
        this.SeatsTaken11[seat] = true;
        break;
      case 12:
        this.SeatsTaken12[seat] = true;
        break;
      case 21:
        this.SeatsTaken21[seat] = true;
        break;
      case 22:
        this.SeatsTaken22[seat] = true;
        break;
      case 31:
        this.SeatsTaken31[seat] = true;
        break;
      case 32:
        this.SeatsTaken32[seat] = true;
        break;
    }
  }

  private void FindUnoccupiedSeat()
  {
    this.SeatOccupied = false;
    if (this.Class == 1)
    {
      this.JSON.Students[this.SpawnID].Class = 11;
      this.ID = 1;
      while (this.ID < this.SeatsTaken11.Length && !this.SeatOccupied)
      {
        if (!this.SeatsTaken11[this.ID])
        {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken11[this.ID] = true;
          this.SeatOccupied = true;
        }
        ++this.ID;
        if (this.ID > 15)
          ++this.Class;
      }
    }
    else if (this.Class == 2)
    {
      this.JSON.Students[this.SpawnID].Class = 12;
      this.ID = 1;
      while (this.ID < this.SeatsTaken12.Length && !this.SeatOccupied)
      {
        if (!this.SeatsTaken12[this.ID])
        {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken12[this.ID] = true;
          this.SeatOccupied = true;
        }
        ++this.ID;
        if (this.ID > 15)
          ++this.Class;
      }
    }
    else if (this.Class == 3)
    {
      this.JSON.Students[this.SpawnID].Class = 21;
      this.ID = 1;
      while (this.ID < this.SeatsTaken21.Length && !this.SeatOccupied)
      {
        if (!this.SeatsTaken21[this.ID])
        {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken21[this.ID] = true;
          this.SeatOccupied = true;
        }
        ++this.ID;
        if (this.ID > 15)
          ++this.Class;
      }
    }
    else if (this.Class == 4)
    {
      this.JSON.Students[this.SpawnID].Class = 22;
      this.ID = 1;
      while (this.ID < this.SeatsTaken22.Length && !this.SeatOccupied)
      {
        if (!this.SeatsTaken22[this.ID])
        {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken22[this.ID] = true;
          this.SeatOccupied = true;
        }
        ++this.ID;
        if (this.ID > 15)
          ++this.Class;
      }
    }
    else if (this.Class == 5)
    {
      this.JSON.Students[this.SpawnID].Class = 31;
      this.ID = 1;
      while (this.ID < this.SeatsTaken31.Length && !this.SeatOccupied)
      {
        if (!this.SeatsTaken31[this.ID])
        {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken31[this.ID] = true;
          this.SeatOccupied = true;
        }
        ++this.ID;
        if (this.ID > 15)
          ++this.Class;
      }
    }
    else if (this.Class == 6)
    {
      this.JSON.Students[this.SpawnID].Class = 32;
      this.ID = 1;
      while (this.ID < this.SeatsTaken32.Length && !this.SeatOccupied)
      {
        if (!this.SeatsTaken32[this.ID])
        {
          this.JSON.Students[this.SpawnID].Seat = this.ID;
          this.SeatsTaken32[this.ID] = true;
          this.SeatOccupied = true;
        }
        ++this.ID;
        if (this.ID > 15)
          ++this.Class;
      }
    }
    if (this.SeatOccupied)
      return;
    this.FindUnoccupiedSeat();
  }

  public void PinDownCheck()
  {
    if (this.PinningDown || this.Witnesses <= 3)
      return;
    for (this.ID = 1; this.ID < this.WitnessList.Length; ++this.ID)
    {
      StudentScript witness = this.WitnessList[this.ID];
      if ((UnityEngine.Object) witness != (UnityEngine.Object) null && (!witness.Alive || witness.Attacked || witness.Fleeing || witness.Dying || witness.Routine))
      {
        if (this.ID != this.WitnessList.Length - 1)
          this.Shuffle(this.ID);
        --this.Witnesses;
      }
    }
    if (this.Witnesses <= 3)
      return;
    this.PinningDown = true;
    this.PinPhase = 1;
  }

  private void Shuffle(int Start)
  {
    for (int index = Start; index < this.WitnessList.Length - 1; ++index)
      this.WitnessList[index] = this.WitnessList[index + 1];
  }

  public void RemovePapersFromDesks()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && (UnityEngine.Object) student.MyPaper != (UnityEngine.Object) null)
        student.MyPaper.SetActive(false);
    }
  }

  public void SetStudentsActive(bool active)
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.gameObject.SetActive(active);
    }
  }

  public void AssignTeachers()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.MyTeacher = this.Teachers[this.JSON.Students[student.StudentID].Class];
    }
  }

  public void ToggleBookBags()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.BookBag.SetActive(!student.BookBag.activeInHierarchy);
    }
  }

  public void DetermineVictim()
  {
    this.Bully = false;
    for (this.ID = 2; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && (double) this.StudentReps[this.ID] < -33.333328247070313 && (this.ID != 36 || this.TaskManager.TaskStatus[36] != 3) && !student.Teacher && !student.Slave && student.Club != ClubType.Bully && student.Club != ClubType.Council && student.Club != ClubType.Photography && student.Club != ClubType.Delinquent && (double) this.StudentReps[this.ID] < (double) this.LowestRep)
      {
        bool flag = false;
        if (!this.Eighties && this.ID == 11)
        {
          flag = true;
          if ((UnityEngine.Object) this.Students[10] == (UnityEngine.Object) null)
            flag = false;
          else if ((UnityEngine.Object) this.Students[10].FollowTarget == (UnityEngine.Object) null)
            flag = false;
        }
        if (!flag)
        {
          this.LowestRep = this.StudentReps[this.ID];
          this.VictimID = this.ID;
          this.Bully = true;
        }
      }
    }
    if (!this.Bully)
      return;
    if ((double) this.Students[this.VictimID].Seat.position.x > 0.0)
    {
      this.BullyGroup.position = this.Students[this.VictimID].Seat.position + new Vector3(0.33333f, 0.0f, 0.0f);
    }
    else
    {
      this.BullyGroup.position = this.Students[this.VictimID].Seat.position - new Vector3(0.33333f, 0.0f, 0.0f);
      this.BullyGroup.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
    }
    StudentScript student1 = this.Students[this.VictimID];
    if (!this.Students[this.VictimID].Rival)
    {
      ScheduleBlock scheduleBlock = student1.ScheduleBlocks[2];
      scheduleBlock.destination = "ShameSpot";
      scheduleBlock.action = "Shamed";
      scheduleBlock.time = 8f;
    }
    ScheduleBlock scheduleBlock1 = student1.ScheduleBlocks[4];
    scheduleBlock1.destination = "Seat";
    scheduleBlock1.action = "Sit";
    ScheduleBlock scheduleBlock2 = student1.ScheduleBlocks[7];
    scheduleBlock2.destination = "ShameSpot";
    scheduleBlock2.action = "Shamed";
    if (student1.Male)
    {
      student1.ChemistScanner.MyRenderer.materials[1].mainTexture = student1.ChemistScanner.SadEyes;
      student1.ChemistScanner.enabled = false;
    }
    student1.IdleAnim = student1.BulliedIdleAnim;
    student1.WalkAnim = student1.BulliedWalkAnim;
    student1.Bullied = true;
    student1.GetDestinations();
    student1.CameraAnims = student1.CowardAnims;
    student1.BusyAtLunch = true;
    student1.Shy = false;
  }

  public void SecurityCameras()
  {
    this.Egg = true;
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && (UnityEngine.Object) student.SecurityCamera != (UnityEngine.Object) null && student.Alive)
      {
        Debug.Log((object) "Enabling security camera on this character's head.");
        student.SecurityCamera.SetActive(true);
      }
    }
  }

  public void DisableEveryone()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && !student.Ragdoll.enabled)
        student.gameObject.SetActive(false);
    }
  }

  public void DisableStudent(int DisableID)
  {
    StudentScript student = this.Students[DisableID];
    if ((UnityEngine.Object) student != (UnityEngine.Object) null)
    {
      if (student.gameObject.activeInHierarchy)
      {
        student.gameObject.SetActive(false);
      }
      else
      {
        student.gameObject.SetActive(true);
        this.UpdateOneAnimLayer(DisableID);
        this.Students[DisableID].ReadPhase = 0;
      }
    }
    if (!this.Eighties || DisableID != 100)
      return;
    this.Journalist.SetActive(!this.Journalist.activeInHierarchy);
  }

  public void UpdateOneAnimLayer(int DisableID)
  {
    this.Students[DisableID].UpdateAnimLayers();
    this.Students[DisableID].ReadPhase = 0;
  }

  public void UpdateAllAnimLayers()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        student.UpdateAnimLayers();
        student.ReadPhase = 0;
      }
    }
  }

  public void UpdateGraffiti()
  {
    for (this.ID = 1; this.ID < 6; ++this.ID)
    {
      if (!this.NoBully[this.ID])
        this.Graffiti[this.ID].SetActive(true);
    }
  }

  public void UpdateAllBentos()
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && !student.MyBento.Tampered)
      {
        student.MyBento.Prompt.Yandere = this.Yandere;
        student.MyBento.UpdatePrompts();
      }
    }
  }

  public void UpdateSleuths()
  {
    ++this.SleuthPhase;
    for (this.ID = 56; this.ID < 61; ++this.ID)
    {
      if ((UnityEngine.Object) this.Students[this.ID] != (UnityEngine.Object) null && !this.Students[this.ID].Slave && !this.Students[this.ID].Following && !this.Students[this.ID].Meeting && !this.Students[this.ID].SentToLocker)
      {
        if (this.SleuthPhase < 3)
        {
          this.Students[this.ID].SleuthTarget = this.SleuthDestinations[this.ID - 55];
          this.Students[this.ID].Pathfinding.target = this.Students[this.ID].SleuthTarget;
          this.Students[this.ID].CurrentDestination = this.Students[this.ID].SleuthTarget;
        }
        else if (this.SleuthPhase == 3)
          this.Students[this.ID].GetSleuthTarget();
        else if (this.SleuthPhase == 4)
        {
          this.Students[this.ID].SleuthTarget = this.Clubs.List[this.ID];
          this.Students[this.ID].Pathfinding.target = this.Students[this.ID].SleuthTarget;
          this.Students[this.ID].CurrentDestination = this.Students[this.ID].SleuthTarget;
        }
        this.Students[this.ID].SmartPhone.SetActive(true);
        this.Students[this.ID].SpeechLines.Stop();
      }
    }
  }

  public void UpdateDrama()
  {
    if (this.MemorialScene.gameObject.activeInHierarchy)
      return;
    ++this.DramaPhase;
    for (this.ID = 26; this.ID < 31; ++this.ID)
    {
      if ((UnityEngine.Object) this.Students[this.ID] != (UnityEngine.Object) null)
      {
        if (this.DramaPhase == 1)
        {
          this.Clubs.List[this.ID].position = this.OriginalClubPositions[this.ID - 25];
          this.Clubs.List[this.ID].rotation = this.OriginalClubRotations[this.ID - 25];
          this.Students[this.ID].ClubAnim = this.Students[this.ID].OriginalClubAnim;
        }
        else if (this.DramaPhase == 2)
        {
          this.Clubs.List[this.ID].position = this.DramaSpots[this.ID - 25].position;
          this.Clubs.List[this.ID].rotation = this.DramaSpots[this.ID - 25].rotation;
          if (this.ID == 26)
            this.Students[this.ID].ClubAnim = this.Students[this.ID].ActAnim;
          else if (this.ID == 27)
            this.Students[this.ID].ClubAnim = this.Students[this.ID].ThinkAnim;
          else if (this.ID == 28)
            this.Students[this.ID].ClubAnim = this.Students[this.ID].ThinkAnim;
          else if (this.ID == 29)
            this.Students[this.ID].ClubAnim = this.Students[this.ID].ActAnim;
          else if (this.ID == 30)
            this.Students[this.ID].ClubAnim = this.Students[this.ID].ThinkAnim;
        }
        else if (this.DramaPhase == 3)
        {
          this.Clubs.List[this.ID].position = this.BackstageSpots[this.ID - 25].position;
          this.Clubs.List[this.ID].rotation = this.BackstageSpots[this.ID - 25].rotation;
        }
        else if (this.DramaPhase == 4)
        {
          this.DramaPhase = 1;
          this.UpdateDrama();
        }
        this.Students[this.ID].DistanceToDestination = 100f;
        this.Students[this.ID].SmartPhone.SetActive(false);
        this.Students[this.ID].SpeechLines.Stop();
      }
    }
  }

  public void UpdateMartialArts()
  {
    this.ConvoManager.Confirmed = false;
    ++this.MartialArtsPhase;
    for (this.ID = 46; this.ID < 51; ++this.ID)
    {
      if ((UnityEngine.Object) this.Students[this.ID] != (UnityEngine.Object) null)
      {
        if (this.MartialArtsPhase == 1)
        {
          this.Clubs.List[this.ID].position = this.MartialArtsSpots[this.ID - 45].position;
          this.Clubs.List[this.ID].rotation = this.MartialArtsSpots[this.ID - 45].rotation;
        }
        else if (this.MartialArtsPhase == 2)
        {
          this.Clubs.List[this.ID].position = this.MartialArtsSpots[this.ID - 40].position;
          this.Clubs.List[this.ID].rotation = this.MartialArtsSpots[this.ID - 40].rotation;
        }
        else if (this.MartialArtsPhase == 3)
        {
          this.Clubs.List[this.ID].position = this.MartialArtsSpots[this.ID - 35].position;
          this.Clubs.List[this.ID].rotation = this.MartialArtsSpots[this.ID - 35].rotation;
        }
        else if (this.MartialArtsPhase == 4)
        {
          this.MartialArtsPhase = 0;
          this.UpdateMartialArts();
        }
        this.Students[this.ID].DistanceToDestination = 100f;
        this.Students[this.ID].SmartPhone.SetActive(false);
        this.Students[this.ID].SpeechLines.Stop();
      }
    }
    this.RaibaruMentorSpot.position = this.Clubs.List[46].position + this.Clubs.List[46].forward * 0.5f + this.Clubs.List[46].right * 0.5f;
    this.RaibaruMentorSpot.rotation = this.Clubs.List[46].rotation;
    if (!((UnityEngine.Object) this.Students[10] != (UnityEngine.Object) null) || this.Students[10].CurrentAction == StudentActionType.Follow || (double) this.Students[10].DistanceToDestination >= 1.0)
      return;
    this.Students[10].Pathfinding.speed = 1f;
    this.Students[10].SpeechLines.Stop();
    this.Students[10].Hurry = false;
  }

  public void UpdateMeeting()
  {
    this.MeetingTimer += Time.deltaTime;
    if ((double) this.MeetingTimer <= 5.0)
      return;
    this.Speaker += 5;
    if (this.Speaker == 91)
      this.Speaker = 21;
    else if (this.Speaker == 76)
      this.Speaker = 86;
    else if (this.Speaker == 36)
      this.Speaker = 41;
    this.MeetingTimer = 0.0f;
  }

  public void CheckMusic()
  {
    int num = 0;
    for (this.ID = 51; this.ID < 56; ++this.ID)
    {
      if ((UnityEngine.Object) this.Students[this.ID] != (UnityEngine.Object) null && this.Students[this.ID].Routine && (double) this.Students[this.ID].DistanceToDestination < 0.10000000149011612)
        ++num;
    }
    if (num == 5)
    {
      this.PracticeVocals.pitch = Time.timeScale;
      this.PracticeMusic.pitch = Time.timeScale;
      if (this.PracticeMusic.isPlaying)
        return;
      this.PracticeVocals.Play();
      this.PracticeMusic.Play();
    }
    else
    {
      this.PracticeVocals.Stop();
      this.PracticeMusic.Stop();
    }
  }

  public void UpdateAprons()
  {
    for (this.ID = 21; this.ID < 26; ++this.ID)
    {
      if ((UnityEngine.Object) this.Students[this.ID] != (UnityEngine.Object) null && this.Students[this.ID].ClubMemberID > 0 && (UnityEngine.Object) this.Students[this.ID].ApronAttacher != (UnityEngine.Object) null && (UnityEngine.Object) this.Students[this.ID].ApronAttacher.newRenderer != (UnityEngine.Object) null)
      {
        if (!this.Eighties)
          this.Students[this.ID].ApronAttacher.newRenderer.material.mainTexture = this.Students[this.ID].Cosmetic.ApronTextures[this.Students[this.ID].ClubMemberID];
        else
          this.Students[this.ID].ApronAttacher.newRenderer.material.mainTexture = this.Students[this.ID].Cosmetic.EightiesApronTextures[this.Students[this.ID].ClubMemberID];
      }
    }
    if (!((UnityEngine.Object) this.Students[12] != (UnityEngine.Object) null) || !((UnityEngine.Object) this.Students[12].ApronAttacher != (UnityEngine.Object) null) || !((UnityEngine.Object) this.Students[12].ApronAttacher.newRenderer != (UnityEngine.Object) null))
      return;
    this.Students[12].ApronAttacher.newRenderer.material.mainTexture = this.Students[12].Cosmetic.AmaiApron;
  }

  public void PreventAlarm()
  {
    for (this.ID = 1; this.ID < 101; ++this.ID)
    {
      if ((UnityEngine.Object) this.Students[this.ID] != (UnityEngine.Object) null)
        this.Students[this.ID].Alarm = 0.0f;
    }
  }

  public void VolumeDown()
  {
    for (this.ID = 51; this.ID < 56; ++this.ID)
    {
      if ((UnityEngine.Object) this.Students[this.ID] != (UnityEngine.Object) null && (UnityEngine.Object) this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID] != (UnityEngine.Object) null)
        this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID].GetComponent<AudioSource>().volume = 0.2f;
    }
  }

  public void VolumeUp()
  {
    for (this.ID = 51; this.ID < 56; ++this.ID)
    {
      if ((UnityEngine.Object) this.Students[this.ID] != (UnityEngine.Object) null && (UnityEngine.Object) this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID] != (UnityEngine.Object) null)
        this.Students[this.ID].Instruments[this.Students[this.ID].ClubMemberID].GetComponent<AudioSource>().volume = 1f;
    }
  }

  public void GetMaleVomitSpot(StudentScript VomitStudent)
  {
    this.MaleVomitSpot = this.MaleVomitSpots[1];
    VomitStudent.VomitDoor = this.MaleToiletDoors[1];
    for (this.ID = 2; this.ID < 7; ++this.ID)
    {
      if ((double) Vector3.Distance(VomitStudent.transform.position, this.MaleVomitSpots[this.ID].position) < (double) Vector3.Distance(VomitStudent.transform.position, this.MaleVomitSpot.position))
      {
        this.MaleVomitSpot = this.MaleVomitSpots[this.ID];
        VomitStudent.VomitDoor = this.MaleToiletDoors[this.ID];
      }
    }
  }

  public void GetFemaleVomitSpot(StudentScript VomitStudent)
  {
    this.FemaleVomitSpot = this.FemaleVomitSpots[1];
    VomitStudent.VomitDoor = this.FemaleToiletDoors[1];
    for (this.ID = 2; this.ID < 7; ++this.ID)
    {
      if ((double) Vector3.Distance(VomitStudent.transform.position, this.FemaleVomitSpots[this.ID].position) < (double) Vector3.Distance(VomitStudent.transform.position, this.FemaleVomitSpot.position))
      {
        this.FemaleVomitSpot = this.FemaleVomitSpots[this.ID];
        VomitStudent.VomitDoor = this.FemaleToiletDoors[this.ID];
      }
    }
  }

  public void GetMaleWashSpot(StudentScript VomitStudent)
  {
    Transform maleWashSpot = this.MaleWashSpots[1];
    for (this.ID = 2; this.ID < 7; ++this.ID)
    {
      if ((double) Vector3.Distance(VomitStudent.transform.position, this.MaleWashSpots[this.ID].position) < (double) Vector3.Distance(VomitStudent.transform.position, maleWashSpot.position))
        maleWashSpot = this.MaleWashSpots[this.ID];
    }
    this.MaleWashSpot = maleWashSpot;
  }

  public void GetFemaleWashSpot(StudentScript VomitStudent)
  {
    Transform femaleWashSpot = this.FemaleWashSpots[1];
    for (this.ID = 2; this.ID < 7; ++this.ID)
    {
      if ((double) Vector3.Distance(VomitStudent.transform.position, this.FemaleWashSpots[this.ID].position) < (double) Vector3.Distance(VomitStudent.transform.position, femaleWashSpot.position))
        femaleWashSpot = this.FemaleWashSpots[this.ID];
    }
    this.FemaleWashSpot = femaleWashSpot;
  }

  public void GetNearestFountain(StudentScript Student)
  {
    DrinkingFountainScript drinkingFountain = this.DrinkingFountains[1];
    bool flag = false;
    this.ID = 1;
    while (drinkingFountain.Occupied)
    {
      drinkingFountain = this.DrinkingFountains[1 + this.ID];
      ++this.ID;
      if (1 + this.ID == this.DrinkingFountains.Length)
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
    }
    else
    {
      for (this.ID = 1; this.ID < this.DrinkingFountains.Length; ++this.ID)
      {
        if ((double) Vector3.Distance(Student.transform.position, this.DrinkingFountains[this.ID].transform.position) < (double) Vector3.Distance(Student.transform.position, drinkingFountain.transform.position) && !this.DrinkingFountains[this.ID].Occupied)
          drinkingFountain = this.DrinkingFountains[this.ID];
      }
      Student.DrinkingFountain = drinkingFountain;
      Student.DrinkingFountain.Occupied = true;
    }
  }

  public void Save()
  {
    this.SaveAllStudentPositions();
    int profile = GameGlobals.Profile;
    int num = PlayerPrefs.GetInt("SaveSlot");
    this.BloodParent.RecordAllBlood();
    this.PuddleParent.RecordAllPuddles();
    this.SpawnedObjectManager.RememberObjects();
    YanSave.SaveData("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
    PlayerPrefs.SetInt("Profile_" + profile.ToString() + "_Slot_" + num.ToString() + "_MemorialStudents", StudentGlobals.MemorialStudents);
    Debug.Log((object) ("At the time of saving, StudentManager's GloveID was: " + this.GloveID.ToString()));
  }

  public void Load()
  {
    this.Eighties = GameGlobals.Eighties;
    foreach (DoorScript door in this.Doors)
    {
      if ((UnityEngine.Object) door != (UnityEngine.Object) null)
        door.Start();
    }
    Debug.Log((object) "Now loading save data.");
    int profile = GameGlobals.Profile;
    int num = PlayerPrefs.GetInt("SaveSlot");
    this.Yandere.Class.gameObject.SetActive(true);
    YanSave.LoadData("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
    this.Yandere.Class.gameObject.SetActive(false);
    Physics.SyncTransforms();
    for (this.ID = 1; this.ID < 101; ++this.ID)
    {
      if ((UnityEngine.Object) this.Students[this.ID] != (UnityEngine.Object) null)
      {
        if (this.Students[this.ID].Schoolwear != 1)
          this.Students[this.ID].ChangeSchoolwear();
        if (!this.Students[this.ID].Alive)
        {
          Debug.Log((object) (this.Students[this.ID].Name + " is confirmed to be dead. Transforming them into a ragdoll now."));
          if (this.Students[this.ID].Rival)
            this.Students[this.ID].MapMarker.gameObject.SetActive(false);
          Vector3 localPosition = this.Students[this.ID].Hips.localPosition;
          Quaternion localRotation = this.Students[this.ID].Hips.localRotation;
          this.Students[this.ID].Ragdoll.Yandere = this.Yandere;
          this.Students[this.ID].BecomeRagdoll();
          GameObjectUtils.SetLayerRecursively(this.Students[this.ID].gameObject, 0);
          this.Students[this.ID].Ragdoll.UpdateNextFrame = true;
          this.Students[this.ID].Ragdoll.NextPosition = localPosition;
          this.Students[this.ID].Ragdoll.NextRotation = localRotation;
          this.Students[this.ID].Ragdoll.CharacterAnimation = this.Students[this.ID].CharacterAnimation;
          this.Students[this.ID].MyRenderer.updateWhenOffscreen = true;
          this.Students[this.ID].CharacterAnimation.enabled = false;
          this.Students[this.ID].MyController.enabled = false;
          this.Students[this.ID].Pathfinding.enabled = false;
          this.Students[this.ID].HipCollider.enabled = true;
          if (!StudentGlobals.GetStudentDying(this.ID))
          {
            Debug.Log((object) ("For some reason, " + this.Students[this.ID].Name + " may not have been added to the Police CorpseList, so we're doing it manually."));
            this.Police.CorpseList[this.Police.Corpses] = this.Students[this.ID].Ragdoll;
            ++this.Police.Corpses;
            ++this.Police.Deaths;
            if (this.Students[this.ID].Removed)
            {
              this.Students[this.ID].Ragdoll.Remove();
              --this.Police.Corpses;
            }
          }
          else
          {
            Debug.Log((object) ("It looks like " + this.Students[this.ID].Name + " has already added themself to the Police CorpseList, so we won't be doing that manually."));
            if (this.Students[this.ID].Removed)
            {
              Debug.Log((object) (this.Students[this.ID].Name + "'s ''Removed'' boolean was true, so we're removing them from the Police CorpseList."));
              this.Students[this.ID].Ragdoll.Remove();
              --this.Police.Corpses;
            }
          }
        }
        else
        {
          this.Students[this.ID].ReturningFromSave = true;
          this.Students[this.ID].PhaseFromSave = this.Students[this.ID].Phase;
          if (this.Students[this.ID].ChangingShoes)
            this.Students[this.ID].ShoeRemoval.enabled = true;
          if (this.Students[this.ID].ClubAttire)
          {
            int clubActivityPhase = this.Students[this.ID].ClubActivityPhase;
            this.Students[this.ID].ClubAttire = false;
            if (this.Students[this.ID].ClubActivityPhase > 14)
            {
              if (this.Students[this.ID].ClubActivityPhase == 18 || this.Students[this.ID].ClubActivityPhase == 19)
              {
                this.Students[this.ID].Destinations[this.Students[this.ID].Phase] = this.Clubs.List[this.ID].GetChild(this.Students[this.ID].ClubActivityPhase - 2);
                this.Students[this.ID].Destinations[this.Students[this.ID].Phase + 1] = this.Clubs.List[this.ID].GetChild(this.Students[this.ID].ClubActivityPhase - 2);
                this.Students[this.ID].CurrentDestination = this.Clubs.List[this.ID].GetChild(this.Students[this.ID].ClubActivityPhase - 2);
                this.Students[this.ID].Pathfinding.target = this.Clubs.List[this.ID].GetChild(this.Students[this.ID].ClubActivityPhase - 2);
                this.Students[this.ID].Character.transform.localPosition = new Vector3(0.0f, -0.25f, 0.0f);
                this.Students[this.ID].CurrentAction = StudentActionType.ClubAction;
                this.Students[this.ID].WalkAnim = "poolSwim_00";
                this.Students[this.ID].ClubAnim = "poolSwim_00";
                this.Students[this.ID].SetSplashes(true);
                ++this.Students[this.ID].Phase;
              }
              this.Clock.Period = 3;
            }
            this.Students[this.ID].ChangeClubwear();
            if (this.Students[this.ID].ClubActivityPhase > 14)
              this.Students[this.ID].ClubActivityPhase = clubActivityPhase;
          }
          if (this.Students[this.ID].Defeats > 0)
          {
            this.Students[this.ID].IdleAnim = "idleInjured_00";
            this.Students[this.ID].WalkAnim = "walkInjured_00";
            this.Students[this.ID].OriginalIdleAnim = this.Students[this.ID].IdleAnim;
            this.Students[this.ID].OriginalWalkAnim = this.Students[this.ID].WalkAnim;
            this.Students[this.ID].LeanAnim = this.Students[this.ID].IdleAnim;
            this.Students[this.ID].CharacterAnimation.CrossFade(this.Students[this.ID].IdleAnim);
            this.Students[this.ID].Injured = true;
            this.Students[this.ID].Strength = 0;
            ScheduleBlock scheduleBlock1 = this.Students[this.ID].ScheduleBlocks[2];
            scheduleBlock1.destination = "Sulk";
            scheduleBlock1.action = "Sulk";
            ScheduleBlock scheduleBlock2 = this.Students[this.ID].ScheduleBlocks[4];
            scheduleBlock2.destination = "Sulk";
            scheduleBlock2.action = "Sulk";
            ScheduleBlock scheduleBlock3 = this.Students[this.ID].ScheduleBlocks[6];
            scheduleBlock3.destination = "Sulk";
            scheduleBlock3.action = "Sulk";
            ScheduleBlock scheduleBlock4 = this.Students[this.ID].ScheduleBlocks[7];
            scheduleBlock4.destination = "Sulk";
            scheduleBlock4.action = "Sulk";
            this.Students[this.ID].GetDestinations();
          }
          if (this.Students[this.ID].Actions[this.Students[this.ID].Phase] == StudentActionType.ClubAction && this.Students[this.ID].Club == ClubType.Cooking && this.Students[this.ID].ClubActivityPhase > 0)
          {
            this.Students[this.ID].MyPlate.parent = this.Students[this.ID].RightHand;
            this.Students[this.ID].MyPlate.localPosition = new Vector3(0.02f, -0.02f, -0.15f);
            this.Students[this.ID].MyPlate.localEulerAngles = new Vector3(-5f, -90f, 172.5f);
            this.Students[this.ID].IdleAnim = this.Students[this.ID].PlateIdleAnim;
            this.Students[this.ID].WalkAnim = this.Students[this.ID].PlateWalkAnim;
            this.Students[this.ID].LeanAnim = this.Students[this.ID].PlateIdleAnim;
            this.Students[this.ID].GetFoodTarget();
            this.Students[this.ID].ClubTimer = 0.0f;
          }
          else if (this.Students[this.ID].Phase > 1)
            --this.Students[this.ID].Phase;
          if (this.OsanaPoolEvent.Phase > 2)
            this.OsanaPoolEvent.ReturnFromSave();
          if (!this.Students[this.ID].Teacher && this.Students[this.ID].Indoors)
          {
            if ((UnityEngine.Object) this.Students[this.ID].ShoeRemoval.Locker == (UnityEngine.Object) null)
              this.Students[this.ID].ShoeRemoval.Start();
            this.Students[this.ID].ShoeRemoval.PutOnShoes();
          }
          if ((double) this.Students[this.ID].MeetTime > 0.0)
          {
            Debug.Log((object) "A student was planning to meet someone when this save file was made. Attempting to update their schedule accordingly.");
            this.NoteWindow.NoteLocker.StudentID = this.MeetStudentID;
            this.NoteWindow.NoteLocker.MeetTime = this.MeetTime;
            this.NoteWindow.NoteLocker.MeetID = this.MeetID;
            this.NoteWindow.NoteLocker.DetermineSchedule();
          }
        }
      }
    }
    this.Clock.UpdateClock();
    this.Clock.UpdateBloom = true;
    this.Alphabet.UpdateText();
    this.ClubManager.ActivateClubBenefit();
    this.Yandere.CanMove = true;
    this.Yandere.ClubAccessory();
    this.Yandere.Inventory.UpdateMoney();
    this.Yandere.WeaponManager.EquipWeaponsFromSave();
    this.Yandere.WeaponManager.RestoreWeaponToStudent();
    this.Yandere.WeaponManager.UpdateDelinquentWeapons();
    this.Yandere.WeaponManager.RestoreBlood();
    this.Yandere.ChangeSchoolwear();
    this.Mirror.UpdatePersona();
    if (this.Yandere.ClubAttire)
    {
      this.Yandere.ClubAttire = false;
      this.Yandere.ChangeClubwear();
    }
    foreach (DoorScript door in this.Doors)
    {
      if ((UnityEngine.Object) door != (UnityEngine.Object) null && door.enabled && door.Open)
        door.OpenDoor();
    }
    foreach (BugScript bug in this.Bugs)
    {
      if ((UnityEngine.Object) bug != (UnityEngine.Object) null)
        bug.CheckStatus();
    }
    foreach (BodyHidingLockerScript bodyHidingLocker in this.BodyHidingLockers)
    {
      if ((UnityEngine.Object) bodyHidingLocker != (UnityEngine.Object) null && bodyHidingLocker.StudentID > 0)
        bodyHidingLocker.UpdateCorpse();
    }
    this.BloodParent.RestoreAllBlood();
    this.PuddleParent.RestoreAllPuddles();
    if (this.OsanaThursdayAfterClassEvent.Phase > 0)
      this.OsanaThursdayAfterClassEvent.ReturningFromSave = true;
    if ((UnityEngine.Object) this.Students[10] != (UnityEngine.Object) null && (UnityEngine.Object) this.Students[10].Cheer != (UnityEngine.Object) null)
      this.Students[10].Cheer.enabled = false;
    if (this.Yandere.Gloved)
    {
      this.Yandere.Gloves = this.GloveList[this.GloveID];
      this.Yandere.WearingRaincoat = this.Yandere.Gloves.Raincoat;
      int hairstyleBeforeRaincoat = this.Yandere.HairstyleBeforeRaincoat;
      this.Yandere.WearGloves();
      this.Yandere.HairstyleBeforeRaincoat = hairstyleBeforeRaincoat;
    }
    if (this.DramaPhase > 1)
    {
      Debug.Log((object) ("When loading, DramaPhase was " + this.DramaPhase.ToString() + ". So, we are attempting to restore that DramaPhase now."));
      --this.DramaPhase;
      this.UpdateDrama();
    }
    if (this.Police.EndOfDay.TranqCase.VictimID > 0)
      this.Students[this.Police.EndOfDay.TranqCase.VictimID].gameObject.SetActive(false);
    if (this.WaterCooler.TrapSet)
    {
      this.WaterCooler.UpdateCylinderColor();
      this.WaterCooler.SetTrap();
      this.WaterCooler.Timer = 1f;
    }
    foreach (PickUpScript allPickUp in this.AllPickUps)
    {
      if ((UnityEngine.Object) allPickUp != (UnityEngine.Object) null && allPickUp.InsideBookbag)
      {
        this.BookBag.ConcealedPickup = allPickUp;
        allPickUp.gameObject.SetActive(false);
        this.BookBag.Prompt.Label[0].text = !(allPickUp.Prompt.Text[3] != "") ? "     Retrieve " + allPickUp.name : "     Retrieve " + allPickUp.Prompt.Text[3];
      }
    }
    if (this.WeaponBag.Worn)
    {
      Debug.Log((object) "The player was wearing the WeaponBag at the time the save file was made.");
      this.WeaponBag.AttachToBack();
    }
    this.Yandere.WeaponManager.PutWeaponInBag();
    if ((double) this.Yandere.Bloodiness > 0.0 && this.Yandere.Schoolwear > 0 && !this.Yandere.WearingRaincoat)
    {
      Debug.Log((object) "The player was bloody when returning from a save, so we're going to prevent her from incrementing Police.BloodyClothing unnecessarily.");
      --this.Police.BloodyClothing;
    }
    this.SpawnedObjectManager.RespawnObjects();
    this.LoadedSave = true;
    if (this.RivalBookBag.gameObject.activeInHierarchy)
      this.RivalBookBag.UpdatePosition();
    Debug.Log((object) "The entire loading process has been completed.");
  }

  public void UpdateBlood()
  {
    if (this.Police.BloodParent.childCount > 0)
    {
      this.ID = 0;
      foreach (Transform transform in this.Police.BloodParent)
      {
        if (this.ID < 100)
        {
          this.Blood[this.ID] = transform.gameObject.GetComponent<Collider>();
          ++this.ID;
        }
      }
    }
    if (this.Police.BloodParent.childCount <= 0 && this.Police.LimbParent.childCount <= 0)
      return;
    this.ID = 0;
    foreach (Transform transform in this.Police.LimbParent)
    {
      if (this.ID < 100)
      {
        this.Limbs[this.ID] = transform.gameObject.GetComponent<Collider>();
        ++this.ID;
      }
    }
  }

  public void CanAnyoneSeeYandere()
  {
    this.YandereVisible = false;
    foreach (StudentScript student in this.Students)
    {
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.gameObject.activeInHierarchy && student.Alive && student.CanSeeObject(student.Yandere.gameObject, student.Yandere.HeadPosition))
      {
        Debug.Log((object) ("Student #" + student.StudentID.ToString() + ", " + student.Name + ", can see Yandere-chan right now."));
        this.YandereVisible = true;
        break;
      }
    }
  }

  public void CheckBentos()
  {
    foreach (StudentScript student in this.Students)
    {
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.MyBento.Tranquil)
      {
        Debug.Log((object) ("Yandere-chan put sedative into " + student.Name + "'s bento, so that student is being marked as ''Sleepy''."));
        student.Sleepy = true;
        student.Oversleep();
      }
    }
  }

  public void PutStudentsToSleep()
  {
    foreach (StudentScript student in this.Students)
    {
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.Sleepy)
      {
        student.transform.position = student.Pathfinding.target.position;
        Physics.SyncTransforms();
      }
    }
  }

  public void SetFaces(float alpha)
  {
    foreach (StudentScript student in this.Students)
    {
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.StudentID > 1)
      {
        if ((UnityEngine.Object) student.MyRenderer != (UnityEngine.Object) null)
        {
          student.MyRenderer.materials[0].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
          student.MyRenderer.materials[1].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
          if (student.MyRenderer.materials.Length > 2)
            student.MyRenderer.materials[2].color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
        }
        student.Cosmetic.LeftEyeRenderer.material.color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
        student.Cosmetic.RightEyeRenderer.material.color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
        if ((UnityEngine.Object) student.Cosmetic.HairRenderer != (UnityEngine.Object) null)
          student.Cosmetic.HairRenderer.material.color = new Color(1f - alpha, 1f - alpha, 1f - alpha, 1f);
      }
    }
  }

  public void DisableChaseCameras()
  {
    foreach (StudentScript student in this.Students)
    {
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.ChaseCamera.SetActive(false);
    }
  }

  public void UpdateDynamicBones(bool Status)
  {
    foreach (DynamicBone allDynamicBone in this.AllDynamicBones)
    {
      if ((UnityEngine.Object) allDynamicBone != (UnityEngine.Object) null)
        allDynamicBone.enabled = Status;
    }
  }

  public void UpdateFPSDisplay(bool Status)
  {
    if (this.RecordingVideo)
      return;
    foreach (DynamicBone allDynamicBone in this.AllDynamicBones)
    {
      if ((UnityEngine.Object) this.FPSDisplay != (UnityEngine.Object) null)
      {
        this.FPSDisplayBG.SetActive(Status);
        this.FPSDisplay.SetActive(Status);
      }
    }
  }

  public void InitializeReputations()
  {
    this.ReputationSetter.InitializeReputations();
    for (this.ID = 0; this.ID < 101; ++this.ID)
    {
      Vector3 reputationTriangle = StudentGlobals.GetReputationTriangle(this.ID);
      reputationTriangle.x *= 0.33333f;
      reputationTriangle.y *= 0.33333f;
      reputationTriangle.z *= 0.33333f;
      StudentGlobals.SetStudentReputation(this.ID, Mathf.RoundToInt(reputationTriangle.x + reputationTriangle.y + reputationTriangle.z));
      this.StudentReps[this.ID] = (float) StudentGlobals.GetStudentReputation(this.ID);
    }
  }

  public void GracePeriod(float Length)
  {
    for (this.ID = 1; this.ID < this.Students.Length; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        student.FocusOnYandere = false;
        student.IgnoreTimer = Length;
      }
    }
  }

  public void OpenSomeDoors()
  {
    for (int openedDoors = this.OpenedDoors; this.OpenedDoors < openedDoors + 11; ++this.OpenedDoors)
    {
      if (this.OpenedDoors < this.Doors.Length && (UnityEngine.Object) this.Doors[this.OpenedDoors] != (UnityEngine.Object) null && this.Doors[this.OpenedDoors].enabled)
      {
        this.Doors[this.OpenedDoors].Open = true;
        this.Doors[this.OpenedDoors].OpenDoor();
      }
    }
  }

  public void SnapSomeStudents()
  {
    for (int snappedStudents = this.SnappedStudents; this.SnappedStudents < snappedStudents + 10; ++this.SnappedStudents)
    {
      if (this.SnappedStudents < this.Students.Length)
      {
        StudentScript student = this.Students[this.SnappedStudents];
        if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.gameObject.activeInHierarchy && student.Alive)
        {
          student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          student.CharacterAnimation[student.SocialSitAnim].weight = 0.0f;
          student.SnapStudent.Yandere = this.SnappedYandere;
          student.SnapStudent.enabled = true;
          student.SpeechLines.Stop();
          student.enabled = false;
          student.EmptyHands();
          if (student.Shy)
            student.CharacterAnimation[student.ShyAnim].weight = 0.0f;
          if (student.Club == ClubType.LightMusic)
            student.StopMusic();
        }
      }
    }
  }

  public void DarkenAllStudents()
  {
    foreach (StudentScript student in this.Students)
    {
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.StudentID > 1)
      {
        student.MyRenderer.materials[0].mainTexture = this.PureWhite;
        student.MyRenderer.materials[1].mainTexture = this.PureWhite;
        student.MyRenderer.materials[0].color = new Color(1f, 1f, 1f, 1f);
        student.MyRenderer.materials[1].color = new Color(1f, 1f, 1f, 1f);
        if (student.MyRenderer.materials.Length > 2)
        {
          student.MyRenderer.materials[2].mainTexture = this.PureWhite;
          student.MyRenderer.materials[2].color = new Color(1f, 1f, 1f, 1f);
        }
        student.Cosmetic.LeftEyeRenderer.material.mainTexture = this.PureWhite;
        student.Cosmetic.RightEyeRenderer.material.mainTexture = this.PureWhite;
        student.Cosmetic.HairRenderer.material.mainTexture = this.PureWhite;
        student.Cosmetic.LeftEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
        student.Cosmetic.RightEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
        student.Cosmetic.HairRenderer.material.color = new Color(1f, 1f, 1f, 1f);
      }
    }
  }

  public void LockDownOccultClub()
  {
    for (int index = 31; index < 36; ++index)
    {
      this.Patrols.List[index].GetChild(1).position = this.Patrols.List[index].GetChild(0).position;
      this.Patrols.List[index].GetChild(2).position = this.Patrols.List[index].GetChild(0).position;
      this.Patrols.List[index].GetChild(3).position = this.Patrols.List[index].GetChild(0).position;
      this.Patrols.List[index].GetChild(4).position = this.Patrols.List[index].GetChild(0).position;
      this.Patrols.List[index].GetChild(5).position = this.Patrols.List[index].GetChild(0).position;
    }
    for (int index = 81; index < 86; ++index)
    {
      this.Patrols.List[index].GetChild(0).position = this.BullySnapPosition[index].position;
      this.Patrols.List[index].GetChild(1).position = this.BullySnapPosition[index].position;
      this.Patrols.List[index].GetChild(2).position = this.BullySnapPosition[index].position;
      this.Patrols.List[index].GetChild(3).position = this.BullySnapPosition[index].position;
    }
  }

  public void SetWindowsTransparent()
  {
    this.Window.sharedMaterial.color = new Color(0.85f, 0.85f, 0.85f, 0.5f);
    this.Window.sharedMaterial.shader = Shader.Find("Transparent/Diffuse");
    this.TransWindows = true;
  }

  public void SetWindowsOpaque()
  {
    this.Window.sharedMaterial.color = new Color(0.85f, 0.85f, 0.85f, 1f);
    this.Window.sharedMaterial.shader = Shader.Find("Diffuse");
    this.TransWindows = false;
  }

  public void LateUpdate()
  {
    if (!((UnityEngine.Object) this.WindowOccluder != (UnityEngine.Object) null) || this.TransparentWindows)
      return;
    if ((double) this.Yandere.transform.position.y > 0.10000000149011612 && (double) this.Yandere.transform.position.y < 11.0)
      this.WindowOccluder.open = false;
    else
      this.WindowOccluder.open = true;
  }

  public void UpdateSkirts(bool Status)
  {
    foreach (StudentScript student in this.Students)
    {
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        if (!student.Male && !student.Teacher && student.Schoolwear == 1)
          student.SkirtCollider.gameObject.SetActive(Status);
        student.RightHandCollider.enabled = Status;
        student.LeftHandCollider.enabled = Status;
      }
    }
  }

  public void UpdatePanties(bool Status)
  {
    foreach (StudentScript student in this.Students)
    {
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        if (!student.Male && !student.Teacher && student.Schoolwear == 1)
        {
          student.SkirtCollider.gameObject.SetActive(Status);
          student.PantyCollider.gameObject.SetActive(Status);
        }
        student.NotFaceCollider.enabled = Status;
        student.FaceCollider.enabled = Status;
      }
    }
  }

  public void LoadPantyshots()
  {
    this.ID = 1;
    foreach (bool flag in this.PantyShotTaken)
    {
      int num = flag ? 1 : 0;
      if (this.ID < this.PantyShotTaken.Length)
        this.PantyShotTaken[this.ID] = PlayerGlobals.GetStudentPantyShot(this.ID);
      ++this.ID;
    }
  }

  public void SavePantyshots()
  {
    this.ID = 0;
    foreach (bool flag in this.PantyShotTaken)
    {
      PlayerGlobals.SetStudentPantyShot(this.ID, flag);
      ++this.ID;
    }
  }

  public void LoadPhotographs()
  {
    this.ID = 1;
    foreach (bool flag in this.StudentPhotographed)
    {
      int num = flag ? 1 : 0;
      if (this.ID < this.StudentPhotographed.Length)
        this.StudentPhotographed[this.ID] = StudentGlobals.GetStudentPhotographed(this.ID);
      ++this.ID;
    }
  }

  public void SavePhotographs()
  {
    this.ID = 0;
    foreach (bool flag in this.StudentPhotographed)
    {
      StudentGlobals.SetStudentPhotographed(this.ID, flag);
      ++this.ID;
    }
  }

  public void LoadReps()
  {
    this.ID = 1;
    foreach (double studentRep in this.StudentReps)
    {
      if (this.ID < this.StudentReps.Length)
        this.StudentReps[this.ID] = (float) StudentGlobals.GetStudentReputation(this.ID);
      ++this.ID;
    }
  }

  public void SaveReps()
  {
    this.ID = 1;
    foreach (double studentRep in this.StudentReps)
    {
      if (this.ID < this.StudentReps.Length)
        StudentGlobals.SetStudentReputation(this.ID, (int) this.StudentReps[this.ID]);
      ++this.ID;
    }
  }

  public void Week1RoutineAdjustments()
  {
    this.UpdateWeek1Hangout(25);
    this.UpdateWeek1Hangout(30);
    this.UpdateWeek1Hangout(24);
    this.UpdateWeek1Hangout(27);
    this.UpdateWeek1Hangout(34);
    this.UpdateWeek1Hangout(35);
    this.UpdateWeek1Hangout(39);
    this.UpdateWeek1Hangout(40);
    this.UpdateWeek1Hangout(44);
    this.UpdateWeek1Hangout(45);
    this.UpdateWeek1Hangout(54);
    this.UpdateWeek1Hangout(55);
    this.UpdateWeek1Hangout(59);
    this.UpdateWeek1Hangout(60);
    this.UpdateWeek1Hangout(64);
    this.UpdateWeek1Hangout(65);
    this.UpdateWeek1Hangout(69);
    this.UpdateWeek1Hangout(70);
    this.UpdateWeek1Hangout(72);
    this.UpdateWeek1Hangout(73);
    this.UpdateWeek1Hangout(74);
    this.UpdateWeek1Hangout(75);
    if (this.Bully)
      return;
    this.UpdateWeek1Hangout(82);
    this.UpdateWeek1Hangout(83);
  }

  public void UpdateWeek1Hangout(int StudentID)
  {
    if (!((UnityEngine.Object) this.Students[StudentID] != (UnityEngine.Object) null) || this.Students[StudentID].Sleuthing)
      return;
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[2];
    this.scheduleBlock.destination = "Week1Hangout";
    this.scheduleBlock.action = "Socialize";
    if (StudentID == 25 || StudentID == 30 || StudentID == 24 || StudentID == 27)
    {
      this.Students[StudentID].Hurry = true;
      this.Students[StudentID].Pathfinding.speed = 4f;
    }
    if (this.Students[StudentID].Club != ClubType.Bully)
    {
      this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[6];
      this.scheduleBlock.destination = "Week1Hangout";
      this.scheduleBlock.action = "Socialize";
    }
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[7];
    this.scheduleBlock.destination = "Week1Hangout";
    this.scheduleBlock.action = "Socialize";
    this.Students[StudentID].GetDestinations();
    if (DateGlobals.Weekday != DayOfWeek.Friday || this.Students[StudentID].Club != ClubType.Art)
      return;
    ScheduleBlock scheduleBlock = this.Students[StudentID].ScheduleBlocks[7];
    scheduleBlock.destination = "Paint";
    scheduleBlock.action = "Paint";
    this.Students[StudentID].VisionDistance += 5f;
  }

  public void UpdateExteriorStudents()
  {
    Debug.Log((object) "Osana finished changing her shoes, so exterior students are moving back inside.");
    this.UpdateExteriorHangout(25);
    this.UpdateExteriorHangout(30);
    this.UpdateExteriorHangout(24);
    this.UpdateExteriorHangout(27);
    this.UpdateExteriorHangout(34);
    this.UpdateExteriorHangout(35);
  }

  public void UpdateLunchtimeStudents()
  {
    Debug.Log((object) "It's lunchtime during Osana's week, so certain students are having their routines adjusted.");
    this.UpdateLunchtimeHangout(25);
    this.UpdateLunchtimeHangout(30);
    this.UpdateLunchtimeHangout(24);
    this.UpdateLunchtimeHangout(27);
    this.UpdateLunchtimeHangout(34);
    this.UpdateLunchtimeHangout(35);
    this.UpdateLunchtimeHangout(39);
    this.UpdateLunchtimeHangout(40);
    this.UpdateLunchtimeHangout(44);
    this.UpdateLunchtimeHangout(45);
    this.UpdateLunchtimeHangout(54);
    this.UpdateLunchtimeHangout(55);
    this.UpdateLunchtimeHangout(59);
    this.UpdateLunchtimeHangout(60);
    if (this.Bully)
      return;
    this.UpdateLunchtimeHangout(82);
    this.UpdateLunchtimeHangout(83);
  }

  public void UpdateExteriorHangout(int StudentID)
  {
    if (!((UnityEngine.Object) this.Students[StudentID] != (UnityEngine.Object) null))
      return;
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[2];
    this.scheduleBlock.destination = "Stairway";
    this.scheduleBlock.action = "Socialize";
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[6];
    this.scheduleBlock.destination = "Stairway";
    this.scheduleBlock.action = "Socialize";
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[7];
    this.scheduleBlock.destination = "Stairway";
    this.scheduleBlock.action = "Socialize";
    this.Students[StudentID].GetDestinations();
    this.Students[StudentID].CurrentDestination = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
    this.Students[StudentID].Pathfinding.target = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
    this.Students[StudentID].SpeechLines.Stop();
  }

  public void UpdateLunchtimeHangout(int StudentID)
  {
    if (!((UnityEngine.Object) this.Students[StudentID] != (UnityEngine.Object) null))
      return;
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[4];
    this.scheduleBlock.destination = "LunchWitnessPosition";
    this.scheduleBlock.action = "Socialize";
    this.Students[StudentID].GetDestinations();
    this.Students[StudentID].CurrentDestination = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
    this.Students[StudentID].Pathfinding.target = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
  }

  public void Week2RoutineAdjustments()
  {
    if ((UnityEngine.Object) this.Students[11] != (UnityEngine.Object) null)
    {
      this.Hangouts.List[11] = this.Week2Hangouts.List[11];
      this.Students[11].GetDestinations();
      if ((UnityEngine.Object) this.Students[10] != (UnityEngine.Object) null)
      {
        this.Hangouts.List[10] = this.Week2Hangouts.List[10];
        this.Students[10].GetDestinations();
      }
    }
    this.MournSpots[10].position = this.Week2Hangouts.List[11].position;
    this.MournSpots[10].eulerAngles = this.Week2Hangouts.List[11].eulerAngles;
    if ((UnityEngine.Object) this.Students[21] != (UnityEngine.Object) null)
    {
      this.scheduleBlock = this.Students[21].ScheduleBlocks[2];
      this.scheduleBlock.destination = "Week2Hangout";
      this.scheduleBlock.action = "Stand";
      this.scheduleBlock = this.Students[21].ScheduleBlocks[4];
      this.scheduleBlock.destination = "Week2Hangout";
      this.scheduleBlock.action = "Stand";
      this.scheduleBlock = this.Students[21].ScheduleBlocks[6];
      this.scheduleBlock.destination = "Week2Hangout";
      this.scheduleBlock.action = "Stand";
      this.scheduleBlock = this.Students[21].ScheduleBlocks[7];
      this.scheduleBlock.destination = "Week2Hangout";
      this.scheduleBlock.action = "Stand";
      this.scheduleBlock = this.Students[21].ScheduleBlocks[8];
      this.scheduleBlock.destination = "Week2Hangout";
      this.scheduleBlock.action = "Stand";
      this.Students[21].GetDestinations();
    }
    this.UpdateWeek2Hangout(4);
    this.UpdateWeek2Hangout(5);
    this.UpdateWeek2Hangout(6);
    this.UpdateWeek2Hangout(7);
    this.UpdateWeek2Hangout(8);
    this.UpdateWeek2Hangout(9);
    this.UpdateWeek2Hangout(22);
    this.UpdateWeek2Hangout(23);
    this.UpdateWeek2Hangout(24);
    this.UpdateWeek2Hangout(25);
    this.UpdateWeek2Hangout(27);
    this.UpdateWeek2Hangout(28);
    this.UpdateWeek2Hangout(29);
    this.UpdateWeek2Hangout(30);
    this.UpdateWeek2Hangout(32);
    this.UpdateWeek2Hangout(33);
    this.UpdateWeek2Hangout(34);
    this.UpdateWeek2Hangout(35);
    this.UpdateWeek2Hangout(37);
    this.UpdateWeek2Hangout(38);
    this.UpdateWeek2Hangout(39);
    this.UpdateWeek2Hangout(40);
    this.UpdateWeek2Hangout(42);
    this.UpdateWeek2Hangout(43);
    this.UpdateWeek2Hangout(44);
    this.UpdateWeek2Hangout(45);
    this.UpdateWeek2Hangout(56);
    this.UpdateWeek2Hangout(57);
    this.UpdateWeek2Hangout(58);
    this.UpdateWeek2Hangout(59);
    this.UpdateWeek2Hangout(60);
    this.UpdateWeek2Hangout(81);
    this.UpdateWeek2Hangout(82);
    this.UpdateWeek2Hangout(83);
    this.UpdateWeek2Hangout(84);
    this.UpdateWeek2Hangout(85);
  }

  public void UpdateWeek2Hangout(int StudentID)
  {
    if (!((UnityEngine.Object) this.Students[StudentID] != (UnityEngine.Object) null))
      return;
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[2];
    this.scheduleBlock.destination = "Week2Hangout";
    this.scheduleBlock.action = "Socialize";
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[4];
    this.scheduleBlock.destination = "Week2Hangout";
    this.scheduleBlock.action = "Socialize";
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[6];
    this.scheduleBlock.destination = "Week2Hangout";
    this.scheduleBlock.action = "Socialize";
    this.scheduleBlock = this.Students[StudentID].ScheduleBlocks[7];
    this.scheduleBlock.destination = "Week2Hangout";
    this.scheduleBlock.action = "Socialize";
    this.Students[StudentID].GetDestinations();
  }

  public void EightiesWeek3RoutineAdjustments()
  {
    for (int index = 2; index < 6; ++index)
    {
      if ((UnityEngine.Object) this.Students[index] != (UnityEngine.Object) null)
      {
        this.scheduleBlock = this.Students[index].ScheduleBlocks[2];
        this.scheduleBlock.destination = "EightiesSpot";
        this.scheduleBlock.action = "Read";
        this.scheduleBlock = this.Students[index].ScheduleBlocks[7];
        this.scheduleBlock.destination = "EightiesSpot";
        this.scheduleBlock.action = "Read";
        this.Students[index].GetDestinations();
      }
    }
  }

  public void EightiesWeek4RoutineAdjustments()
  {
    for (int index = 6; index < 11; ++index)
    {
      if ((UnityEngine.Object) this.Students[index] != (UnityEngine.Object) null)
      {
        this.scheduleBlock = this.Students[index].ScheduleBlocks[4];
        this.scheduleBlock.destination = "EightiesSpot";
        this.scheduleBlock.action = "PrepareFood";
        this.Students[index].GetDestinations();
      }
    }
  }

  public void EightiesWeek5RoutineAdjustments()
  {
    this.SunbatheAllDay(25);
    this.SunbatheAllDay(30);
    this.SunbatheAllDay(35);
    this.SunbatheAllDay(40);
    this.SunbatheAllDay(45);
    this.SunbatheAllDay(50);
    this.SunbatheAllDay(55);
  }

  public void EightiesWeek6RoutineAdjustments()
  {
    int index1 = 26;
    if ((UnityEngine.Object) this.Students[index1] != (UnityEngine.Object) null)
    {
      this.scheduleBlock = this.Students[index1].ScheduleBlocks[2];
      this.scheduleBlock.destination = "Patrol";
      this.scheduleBlock.action = "Patrol";
      this.scheduleBlock = this.Students[index1].ScheduleBlocks[7];
      this.scheduleBlock.destination = "Patrol";
      this.scheduleBlock.action = "Patrol";
      this.Students[index1].GetDestinations();
    }
    int index2 = 29;
    if ((UnityEngine.Object) this.Students[index2] != (UnityEngine.Object) null)
    {
      this.scheduleBlock = this.Students[index2].ScheduleBlocks[2];
      this.scheduleBlock.destination = "Patrol";
      this.scheduleBlock.action = "Patrol";
      this.scheduleBlock = this.Students[index2].ScheduleBlocks[7];
      this.scheduleBlock.destination = "Patrol";
      this.scheduleBlock.action = "Patrol";
      this.Students[index2].GetDestinations();
    }
    for (int index3 = 52; index3 < 56; ++index3)
    {
      if ((UnityEngine.Object) this.Students[index3] != (UnityEngine.Object) null && this.Students[index3].Club != ClubType.None)
      {
        this.scheduleBlock = this.Students[index3].ScheduleBlocks[2];
        this.scheduleBlock.destination = "Perform";
        this.scheduleBlock.action = "Perform";
        this.scheduleBlock = this.Students[index3].ScheduleBlocks[7];
        this.scheduleBlock.destination = "Perform";
        this.scheduleBlock.action = "Perform";
        this.Students[index3].GetDestinations();
      }
    }
  }

  public void EightiesWeek8RoutineAdjustments()
  {
    for (int index = 2; index < 11; ++index)
    {
      this.Hangouts.List[index].position = this.PopularGirlSpots[index].position;
      this.Hangouts.List[index].LookAt(this.EightiesHangouts.List[18]);
    }
  }

  public void EightiesWeek9RoutineAdjustments()
  {
    if (!((UnityEngine.Object) this.Students[19] != (UnityEngine.Object) null) || StudentGlobals.StudentSlave == 19)
      return;
    for (int index = 57; index < 61; ++index)
    {
      this.scheduleBlock = this.Students[index].ScheduleBlocks[2];
      this.scheduleBlock.destination = "PhotoShoot";
      this.scheduleBlock.action = "PhotoShoot";
      this.scheduleBlock = this.Students[index].ScheduleBlocks[7];
      this.scheduleBlock.destination = "PhotoShoot";
      this.scheduleBlock.action = "PhotoShoot";
      this.Students[index].GetDestinations();
    }
    this.Students[1].Infatuated = true;
    if (DateGlobals.Weekday != DayOfWeek.Monday)
      this.FollowGravureIdol(1);
    this.FollowGravureIdol(6);
    this.FollowGravureIdol(7);
    this.FollowGravureIdol(8);
    this.FollowGravureIdol(9);
    this.FollowGravureIdol(10);
    this.FollowGravureIdol(23);
    this.FollowGravureIdol(28);
    this.FollowGravureIdol(33);
    this.FollowGravureIdol(38);
    this.FollowGravureIdol(43);
    this.FollowGravureIdol(48);
    this.FollowGravureIdol(63);
    this.FollowGravureIdol(68);
    this.FollowGravureIdol(73);
  }

  public void EightiesWeek10RoutineAdjustments()
  {
    Debug.Log((object) "Changing student routines for Week 10.");
    if ((UnityEngine.Object) this.Students[19] != (UnityEngine.Object) null)
    {
      Debug.Log((object) "Changing Gravure Idol's routine.");
      this.scheduleBlock = this.Students[19].ScheduleBlocks[2];
      this.scheduleBlock.destination = "Patrol";
      this.scheduleBlock.action = "Patrol";
      this.scheduleBlock = this.Students[19].ScheduleBlocks[7];
      this.scheduleBlock.destination = "Patrol";
      this.scheduleBlock.action = "Patrol";
      this.Students[19].GetDestinations();
    }
    for (int ID = 2; ID < 11; ++ID)
      this.BecomeSleuth(ID);
    this.BecomeSleuth(20);
    this.RivalGuardSpots[0].parent = this.Students[20].transform;
    this.RivalGuardSpots[0].localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    this.RivalGuardSpots[0].localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    for (int ID = 37; ID < 41; ++ID)
      this.BecomeSleuth(ID);
    for (int ID = 57; ID < 61; ++ID)
      this.BecomeGuard(ID);
  }

  public void BecomeSleuth(int ID)
  {
    if (!((UnityEngine.Object) this.Students[ID] != (UnityEngine.Object) null))
      return;
    this.Students[ID].Persona = PersonaType.Sleuth;
    this.Students[ID].BecomeSleuth();
    this.Students[ID].GetDestinations();
  }

  public void BecomeGuard(int ID)
  {
    if (!((UnityEngine.Object) this.Students[ID] != (UnityEngine.Object) null))
      return;
    this.Students[ID].Persona = PersonaType.Sleuth;
    this.Students[ID].BecomeSleuth();
    ScheduleBlock scheduleBlock1 = this.Students[ID].ScheduleBlocks[2];
    scheduleBlock1.destination = "Guard";
    scheduleBlock1.action = "Guard";
    ScheduleBlock scheduleBlock2 = this.Students[ID].ScheduleBlocks[4];
    scheduleBlock2.destination = "Guard";
    scheduleBlock2.action = "Guard";
    ScheduleBlock scheduleBlock3 = this.Students[ID].ScheduleBlocks[7];
    scheduleBlock3.destination = "Guard";
    scheduleBlock3.action = "Guard";
    ScheduleBlock scheduleBlock4 = this.Students[ID].ScheduleBlocks[8];
    scheduleBlock3.destination = "Guard";
    scheduleBlock3.action = "Guard";
    this.Students[ID].GetDestinations();
  }

  public void FollowGravureIdol(int ID)
  {
    if (!((UnityEngine.Object) this.Students[ID] != (UnityEngine.Object) null))
      return;
    this.Hangouts.List[ID] = this.Students[19].transform;
    this.scheduleBlock = this.Students[ID].ScheduleBlocks[2];
    this.scheduleBlock.destination = "Hangout";
    this.scheduleBlock.action = "Socialize";
    if (ID > 1)
    {
      this.scheduleBlock = this.Students[ID].ScheduleBlocks[4];
      this.scheduleBlock.destination = "Hangout";
      this.scheduleBlock.action = "Socialize";
    }
    this.scheduleBlock = this.Students[ID].ScheduleBlocks[6];
    this.scheduleBlock.destination = "Hangout";
    this.scheduleBlock.action = "Socialize";
    this.scheduleBlock = this.Students[ID].ScheduleBlocks[7];
    this.scheduleBlock.destination = "Hangout";
    this.scheduleBlock.action = "Socialize";
    this.Students[ID].GetDestinations();
    this.Students[ID].Infatuated = true;
  }

  public void SunbatheAllDay(int ID)
  {
    if ((UnityEngine.Object) this.Students[ID] != (UnityEngine.Object) null)
    {
      this.Students[ID].DressCode = false;
      this.scheduleBlock = this.Students[ID].ScheduleBlocks[2];
      this.scheduleBlock.destination = "Sunbathe";
      this.scheduleBlock.action = "Sunbathe";
      this.scheduleBlock = this.Students[ID].ScheduleBlocks[6];
      this.scheduleBlock.destination = "Sunbathe";
      this.scheduleBlock.action = "Sunbathe";
      this.scheduleBlock = this.Students[ID].ScheduleBlocks[7];
      this.scheduleBlock.destination = "Sunbathe";
      this.scheduleBlock.action = "Sunbathe";
      this.Students[ID].GetDestinations();
    }
    ++ID;
  }

  public void ForgetAboutSunbathing(int ID)
  {
    if (!((UnityEngine.Object) this.Students[ID] != (UnityEngine.Object) null))
      return;
    if (this.Students[ID].Actions[2] == StudentActionType.Sunbathe)
    {
      this.Students[ID].DressCode = false;
      this.scheduleBlock = this.Students[ID].ScheduleBlocks[2];
      this.scheduleBlock.destination = "Hangout";
      this.scheduleBlock.action = "Socialize";
      this.scheduleBlock = this.Students[ID].ScheduleBlocks[6];
      this.scheduleBlock.destination = "Hangout";
      this.scheduleBlock.action = "Socialize";
      this.scheduleBlock = this.Students[ID].ScheduleBlocks[7];
      this.scheduleBlock.destination = "Hangout";
      this.scheduleBlock.action = "Socialize";
      this.Students[ID].GetDestinations();
      this.Students[ID].CurrentDestination = this.Students[ID].Destinations[this.Students[ID].Phase];
      this.Students[ID].Pathfinding.target = this.Students[ID].Destinations[this.Students[ID].Phase];
    }
    if (this.Students[ID].Schoolwear != 2)
      return;
    Debug.Log((object) ("Student #" + ID.ToString() + " was wearing a swimsuit at the moment she learned the pool was off-limits."));
    ++this.Students[ID].Phase;
  }

  public void TakeOutTheTrash()
  {
    int index1 = 2;
    for (int index2 = 0; index2 < this.GarbageBags && index1 < 90; ++index2)
    {
      if ((UnityEngine.Object) this.GarbageBagList[index2] != (UnityEngine.Object) null)
      {
        if (index1 > 9 && index1 < 21)
          ++index1;
        while (true)
        {
          if (!((UnityEngine.Object) this.Students[index1] == (UnityEngine.Object) null) && this.Students[index1].gameObject.activeInHierarchy && !this.Students[index1].Slave)
            goto label_6;
label_4:
          ++index1;
          continue;
label_6:
          Bounds bounds;
          if (!this.Students[index1].Male)
          {
            bounds = this.WestMaleBathroomCollider.bounds;
            if (bounds.Contains(this.GarbageBagList[index2].transform.position))
              goto label_4;
          }
          if (!this.Students[index1].Male)
          {
            bounds = this.EastMaleBathroomCollider.bounds;
            if (bounds.Contains(this.GarbageBagList[index2].transform.position))
              goto label_4;
          }
          if (this.Students[index1].Male)
          {
            bounds = this.WestFemaleBathroomCollider.bounds;
            if (bounds.Contains(this.GarbageBagList[index2].transform.position))
              goto label_4;
          }
          if (this.Students[index1].Male)
          {
            bounds = this.EastFemaleBathroomCollider.bounds;
            if (bounds.Contains(this.GarbageBagList[index2].transform.position))
              goto label_4;
            else
              break;
          }
          else
            break;
        }
        this.GarbageBagList[index2].GetComponent<PickUpScript>().DisableGarbageBag();
        this.Students[index1].TakingOutTrash = true;
        this.Students[index1].TrashDestination = this.GarbageBagList[index2].transform;
        this.Students[index1].Routine = false;
        Debug.Log((object) ("Assigned " + this.Students[index1].Name + " to clean up trash bag #" + index2.ToString()));
      }
      ++index1;
    }
  }

  public void Medibang()
  {
    this.Students[35].IdleAnim = "f02_idleElegant_00";
    this.Students[35].WalkAnim = "f02_jojoWalk_00";
    this.Students[35].OriginalIdleAnim = "f02_idleElegant_00";
    this.Students[35].OriginalWalkAnim = "f02_jojoWalk_00";
    this.Students[35].Cosmetic.MyRenderer.enabled = false;
    this.Students[35].EdgyAttacher.SetActive(true);
    this.Students[35].Cosmetic.Medibang = true;
    this.Students[35].Cosmetic.Start();
  }

  public void RemovePoolFromRoutines()
  {
    Debug.Log((object) "Firing RemovePoolFromRoutines()");
    this.OsanaPoolEvent.enabled = false;
    this.PoolClosed = true;
    for (int index = 81; index < 86; ++index)
    {
      ScheduleBlock scheduleBlock = this.Students[index].ScheduleBlocks[4];
      scheduleBlock.destination = "LunchSpot";
      scheduleBlock.action = "Eat";
      this.Students[index].Actions[4] = StudentActionType.SitAndEatBento;
      this.Students[index].GetDestinations();
    }
    if (!this.Eighties)
      return;
    Debug.Log((object) "A bunch of girls are now being instructed to forget about sunbathing.");
    this.ForgetAboutSunbathing(25);
    this.ForgetAboutSunbathing(30);
    this.ForgetAboutSunbathing(35);
    this.ForgetAboutSunbathing(40);
    this.ForgetAboutSunbathing(45);
    this.ForgetAboutSunbathing(50);
    this.ForgetAboutSunbathing(55);
  }

  public void LoadCollectibles()
  {
    int index = 1;
    if (this.HeadmasterTapesCollected.Length != 0)
    {
      for (; index < 12; ++index)
      {
        this.HeadmasterTapesCollected[index] = CollectibleGlobals.GetHeadmasterTapeCollected(index);
        this.PantiesCollected[index] = CollectibleGlobals.GetPantyPurchased(index);
        this.TapesCollected[index] = CollectibleGlobals.GetTapeCollected(index);
      }
    }
    if (this.MangaCollected.Length == 0)
      return;
    for (int mangaID = 1; mangaID < 16; ++mangaID)
      this.MangaCollected[mangaID] = CollectibleGlobals.GetMangaCollected(mangaID);
  }

  public void SaveCollectibles()
  {
    for (int index = 1; index < 12; ++index)
    {
      CollectibleGlobals.SetHeadmasterTapeCollected(index, this.HeadmasterTapesCollected[index]);
      CollectibleGlobals.SetPantyPurchased(index, this.PantiesCollected[index]);
      CollectibleGlobals.SetTapeCollected(index, this.TapesCollected[index]);
      if (index == 11 && this.PantiesCollected[index])
        Debug.Log((object) "Saving the fact that Ryoba picked up the fundoshi.");
    }
    for (int mangaID = 1; mangaID < 16; ++mangaID)
      CollectibleGlobals.SetMangaCollected(mangaID, this.MangaCollected[mangaID]);
  }

  public void UpdateTeachers()
  {
    Debug.Log((object) "All teachers were just commanded to fire the UpdateMe() function.");
    this.UpdateMe(90);
    this.UpdateMe(91);
    this.UpdateMe(92);
    this.UpdateMe(93);
    this.UpdateMe(94);
    this.UpdateMe(95);
    this.UpdateMe(96);
    this.UpdateMe(97);
  }

  public void UpdateAppearances()
  {
    foreach (StudentScript student in this.Students)
    {
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
        student.Cosmetic.Start();
    }
  }

  public void RandomizeRoutines()
  {
    for (this.ID = 1; this.ID < 101; ++this.ID)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyObject, this.transform.position, Quaternion.identity);
      this.RandomSpots[this.ID] = gameObject.transform;
      gameObject.transform.position = this.PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
    }
    for (this.ID = 1; this.ID < 97; ++this.ID)
    {
      StudentScript student = this.Students[this.ID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        student.Indoors = true;
        student.Spawned = true;
        student.Calm = true;
        if ((UnityEngine.Object) student.ShoeRemoval.Locker == (UnityEngine.Object) null && !student.Teacher)
        {
          student.ShoeRemoval.Start();
          student.ShoeRemoval.PutOnShoes();
        }
        ScheduleBlock scheduleBlock1 = student.ScheduleBlocks[0];
        scheduleBlock1.destination = "Random";
        scheduleBlock1.action = "Random";
        ScheduleBlock scheduleBlock2 = student.ScheduleBlocks[1];
        scheduleBlock2.destination = "Random";
        scheduleBlock2.action = "Random";
        ScheduleBlock scheduleBlock3 = student.ScheduleBlocks[2];
        scheduleBlock3.destination = "Random";
        scheduleBlock3.action = "Random";
        ScheduleBlock scheduleBlock4 = student.ScheduleBlocks[3];
        scheduleBlock4.destination = "Random";
        scheduleBlock4.action = "Random";
        ScheduleBlock scheduleBlock5 = student.ScheduleBlocks[4];
        scheduleBlock5.destination = "Random";
        scheduleBlock5.action = "Random";
        ScheduleBlock scheduleBlock6 = student.ScheduleBlocks[5];
        scheduleBlock6.destination = "Random";
        scheduleBlock6.action = "Random";
        student.GetDestinations();
        student.CurrentDestination = student.Destinations[student.Phase];
        student.Pathfinding.target = student.Destinations[student.Phase];
        student.CurrentAction = StudentActionType.Random;
        this.Students[this.ID].transform.position = this.PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
        Physics.SyncTransforms();
      }
    }
  }

  public void DepowerStudentCouncil()
  {
    for (int index = 86; index < 90; ++index)
    {
      StudentScript student = this.Students[index];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null)
      {
        student.OriginalPersona = PersonaType.Heroic;
        student.Persona = PersonaType.Heroic;
        student.Club = ClubType.None;
        student.CameraReacting = false;
        student.SpeechLines.Stop();
        student.EmptyHands();
        student.IdleAnim = student.BulliedIdleAnim;
        student.WalkAnim = student.BulliedWalkAnim;
        student.Armband.SetActive(false);
        ScheduleBlock scheduleBlock = student.ScheduleBlocks[3];
        scheduleBlock.destination = "LunchSpot";
        scheduleBlock.action = "Eat";
        student.GetDestinations();
        student.CurrentDestination = student.Destinations[student.Phase];
        student.Pathfinding.target = student.Destinations[student.Phase];
      }
    }
  }

  public void Become1989()
  {
    this.Eighties = true;
    this.WeekLimit = 10;
    if (this.TakingPortraits)
    {
      this.PhotoBG.mainTexture = this.EightiesBG;
      this.PortraitChan = this.StudentChan;
      this.PortraitKun = this.StudentKun;
      this.EightiesPrefix = "1989";
      this.Profile.enabled = true;
    }
    else
    {
      this.Yandere.HeartCamera.enabled = false;
      this.Tutorial.ReputationHUD.transform.localPosition = new Vector3(-15f, 25f, 0.0f);
      this.Tutorial.SanityHUD.transform.localPosition = new Vector3(50f, 30f, 0.0f);
      this.Tutorial.ClockHUD.transform.localPosition = new Vector3(-25f, -10f, 0.0f);
      this.FPSValue.GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
      this.FPSValue.localPosition = new Vector3(75f, -179f, 0.0f);
      this.FPS.GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
      this.FPS.localPosition = new Vector3(120f, -179f, 0.0f);
      this.LandLinePhone.gameObject.SetActive(true);
      this.OutOfOrderSign.SetActive(false);
      this.YellowifyLabel(this.Police.EndOfDay.Counselor.CounselorSubtitle);
      this.YellowifyLabel(this.Police.EndOfDay.Counselor.LectureSubtitle);
      this.YellowifyLabel(this.LoveManager.ConfessionManager.SubtitleLabel);
      this.YellowifyLabel(this.Headmaster.HeadmasterSubtitle);
      this.YellowifyLabel(this.Yandere.Subtitle.Label);
      this.YellowifyLabel(this.EventSubtitle);
      this.EightiesifyLabel(this.Yandere.SanityLabel);
      this.HauntedBathroomLight.enabled = true;
      this.SpawnPositions[7].localPosition = new Vector3(1f, 0.0f, -6f);
      this.PracticeSpots[1].localPosition = new Vector3(1.66666f, 4f, 26f);
      this.PracticeSpots[1].localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
      for (int index = 1; index < this.ModernDayProps.Length; ++index)
        this.ModernDayProps[index].SetActive(false);
      for (int index = 1; index < this.EightiesProps.Length; ++index)
        this.EightiesProps[index].SetActive(true);
      this.LunchSpots = this.EightiesLunchSpots;
      this.Hangouts = this.EightiesHangouts;
      this.Patrols = this.EightiesPatrols;
      this.Clubs = this.EightiesClubs;
      this.InfoClubRoom.SetActive(false);
      this.InfoClubProps.SetActive(false);
      this.ModernDayScienceClub.SetActive(false);
      this.ModernDayScienceProps.SetActive(false);
      this.ModernDayPropsLMC.SetActive(false);
      this.ModernDayRoomLMC.SetActive(false);
      this.NewspaperClubProps.SetActive(true);
      this.NewspaperClubRoom.SetActive(true);
      this.EightiesPropsLMC.SetActive(true);
      this.EightiesRoomLMC.SetActive(true);
      this.EightiesScienceClub.SetActive(true);
      this.EightiesScienceProps.SetActive(true);
      if (this.Week < 11)
        this.SuitorID = this.SuitorIDs[this.Week];
      this.LyricsSpot.parent.position = this.EightiesLyricDesk.position;
      this.LyricsSpot.parent.eulerAngles = this.EightiesLyricDesk.eulerAngles;
    }
  }

  public void YellowifyLabel(UILabel Label)
  {
    Label.trueTypeFont = this.Arial;
    Label.applyGradient = false;
    Label.color = new Color(1f, 1f, 0.0f, 1f);
    Label.fontStyle = FontStyle.Bold;
  }

  public void EightiesifyLabel(UILabel Label)
  {
    Label.trueTypeFont = this.VCR;
    Label.applyGradient = false;
    Label.color = new Color(1f, 1f, 1f, 1f);
    Label.effectStyle = UILabel.Effect.Outline8;
    Label.effectColor = new Color(0.0f, 0.0f, 0.0f, 1f);
  }

  public void StayInOneSpot(int StudentID)
  {
    this.Hangouts.List[StudentID].transform.position = this.Students[StudentID].transform.position;
    this.Hangouts.List[StudentID].transform.eulerAngles = this.Students[StudentID].transform.eulerAngles;
    for (int index = 0; index < 8; ++index)
    {
      ScheduleBlock scheduleBlock = this.Students[StudentID].ScheduleBlocks[index];
      scheduleBlock.destination = "Hangout";
      scheduleBlock.action = "Wait";
    }
    this.Students[StudentID].GetDestinations();
    this.Students[StudentID].CurrentAction = StudentActionType.Wait;
    this.Students[StudentID].Pathfinding.target = this.Tutorial.Destination[this.Tutorial.Phase + 1];
    this.Students[StudentID].CurrentDestination = this.Tutorial.Destination[this.Tutorial.Phase + 1];
  }

  public void ChangeSuitorRoutine(int StudentID)
  {
    StudentScript student = this.Students[StudentID];
    student.RelaxAnim = student.PatrolAnim;
    student.Curious = true;
    student.Crush = this.RivalID;
    this.Hangouts.List[StudentID].transform.position = new Vector3(6f, 0.0f, -5f);
    this.Hangouts.List[StudentID].transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
    ScheduleBlock scheduleBlock1 = student.ScheduleBlocks[2];
    scheduleBlock1.destination = "Hangout";
    scheduleBlock1.action = "Relax";
    ScheduleBlock scheduleBlock2 = student.ScheduleBlocks[4];
    scheduleBlock2.destination = "Hangout";
    scheduleBlock2.action = "Relax";
    ScheduleBlock scheduleBlock3 = student.ScheduleBlocks[7];
    scheduleBlock3.destination = "Hangout";
    scheduleBlock3.action = "Relax";
    this.Students[StudentID].GetDestinations();
    this.Students[StudentID].Pathfinding.target = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
    this.Students[StudentID].CurrentDestination = this.Students[StudentID].Destinations[this.Students[StudentID].Phase];
    this.SuitorLocker = this.LockerPositions[StudentID];
  }

  public void UpdateRivalEliminationDetails(int StudentID) => this.RivalKilledSelf[StudentID - 10] = true;

  public void SaveAllStudentPositions()
  {
    for (int index = 1; index < 101; ++index)
    {
      if ((UnityEngine.Object) this.Students[index] != (UnityEngine.Object) null)
      {
        this.Students[index].SavePositionX = this.Students[index].transform.position.x;
        this.Students[index].SavePositionY = this.Students[index].transform.position.y;
        this.Students[index].SavePositionZ = this.Students[index].transform.position.z;
      }
    }
  }

  public void LoadAllStudentPositions()
  {
    for (int index = 1; index < 101; ++index)
    {
      if ((UnityEngine.Object) this.Students[index] != (UnityEngine.Object) null)
        this.Students[index].transform.position = new Vector3(this.Students[index].SavePositionX, this.Students[index].SavePositionY, this.Students[index].SavePositionZ);
    }
  }

  private void CheckSelfReportStatus(StudentScript student)
  {
    this.CanSelfReport = (double) this.Yandere.Bloodiness == 0.0 && (double) this.Yandere.Sanity > 66.66666 && !this.Yandere.StudentManager.WitnessCamera.Show && (UnityEngine.Object) this.Yandere.StudentManager.ChaseCamera == (UnityEngine.Object) null && !this.MurderTakingPlace && (this.Police.Corpses > 0 || this.Police.LimbParent.childCount > 0 || this.Police.BloodParent.childCount > 0 || this.Police.BloodyClothing > 0 || this.Police.BloodyWeapons > 0);
    if (this.CanSelfReport)
    {
      student.Prompt.HideButton[0] = false;
      student.Prompt.Label[0].text = "     Report Blood/Corpse";
    }
    else
      student.Prompt.HideButton[0] = true;
  }

  public void UpdateInfatuatedTargetDistances()
  {
    Debug.Log((object) ("Rival's Meeting boolean is set to " + this.Students[this.RivalID].Meeting.ToString() + ". Updating InfatuatedTargetDistances."));
    if (!this.Eighties || this.Week != 9)
      return;
    if (DateGlobals.Weekday != DayOfWeek.Monday)
      this.DecideTargetDistance(1);
    this.DecideTargetDistance(6);
    this.DecideTargetDistance(7);
    this.DecideTargetDistance(8);
    this.DecideTargetDistance(9);
    this.DecideTargetDistance(10);
    this.DecideTargetDistance(23);
    this.DecideTargetDistance(28);
    this.DecideTargetDistance(33);
    this.DecideTargetDistance(38);
    this.DecideTargetDistance(43);
    this.DecideTargetDistance(48);
    this.DecideTargetDistance(63);
    this.DecideTargetDistance(68);
    this.DecideTargetDistance(73);
  }

  private void DecideTargetDistance(int ID)
  {
    Debug.Log((object) ("Updating the TargetDistance for Student#" + ID.ToString()));
    if (!((UnityEngine.Object) this.Students[ID] != (UnityEngine.Object) null))
      return;
    if (this.Students[this.RivalID].Meeting)
    {
      Debug.Log((object) "Rival is meeting someone, so TargetDistance is far away.");
      this.Students[ID].TargetDistance = 10f;
    }
    else
    {
      Debug.Log((object) "Rival is NOT meeting someone, so TargetDistance is nearby.");
      this.Students[ID].TargetDistance = 5f;
    }
  }

  private void CoupleCheck()
  {
    for (int elimID = 1; elimID < this.Week; ++elimID)
    {
      if (GameGlobals.GetRivalEliminations(elimID) == 6)
      {
        Debug.Log((object) ("Rival #" + elimID.ToString() + " was Matchmade! Adjusting her routine now."));
        StudentScript student1 = this.Students[10 + elimID];
        StudentScript student2 = this.Students[this.SuitorIDs[elimID]];
        if ((UnityEngine.Object) student1 != (UnityEngine.Object) null && (UnityEngine.Object) student2 != (UnityEngine.Object) null)
        {
          student1.PartnerID = this.SuitorIDs[elimID];
          student1.Partner = this.Students[student1.PartnerID];
          student1.CoupleID = elimID;
          this.AssignCoupleSchedule(student1);
          student2.PartnerID = 10 + elimID;
          student2.Partner = this.Students[10 + elimID];
          student2.CoupleID = elimID;
          this.AssignCoupleSchedule(student2);
        }
      }
    }
  }

  private void AssignCoupleSchedule(StudentScript Student)
  {
    ScheduleBlock scheduleBlock1 = Student.ScheduleBlocks[2];
    scheduleBlock1.destination = "Cuddle";
    scheduleBlock1.action = "Cuddle";
    ScheduleBlock scheduleBlock2 = Student.ScheduleBlocks[4];
    scheduleBlock2.destination = "Cuddle";
    scheduleBlock2.action = "Cuddle";
    ScheduleBlock scheduleBlock3 = Student.ScheduleBlocks[6];
    scheduleBlock3.destination = "Locker";
    scheduleBlock3.action = "Shoes";
    ScheduleBlock scheduleBlock4 = Student.ScheduleBlocks[7];
    scheduleBlock4.destination = "Exit";
    scheduleBlock4.action = "Exit";
    Student.GetDestinations();
    Student.Pathfinding.target = Student.Destinations[Student.Phase];
    Student.CurrentDestination = Student.Destinations[Student.Phase];
  }

  public void SetTopicLearnedByStudent(int Topic, int StudentID, bool boolean) => this.OpinionsLearned.StudentOpinions[StudentID].Opinions[Topic] = boolean;

  public bool GetTopicLearnedByStudent(int Topic, int StudentID) => this.OpinionsLearned.StudentOpinions[StudentID].Opinions[Topic];

  public void LoadTopicsLearned()
  {
    for (int index1 = 1; index1 < 101; ++index1)
    {
      for (int index2 = 1; index2 < 26; ++index2)
        this.SetTopicLearnedByStudent(index2, index1, ConversationGlobals.GetTopicLearnedByStudent(index2, index1));
    }
  }

  public void CheckForAttackPrompt()
  {
    Debug.Log((object) "Checking to see if any attack prompts are active.");
    this.AttackPromptActive = false;
    for (int index = 1; index < 101; ++index)
    {
      if ((UnityEngine.Object) this.Students[index] != (UnityEngine.Object) null && this.Students[index].gameObject.activeInHierarchy && (UnityEngine.Object) this.Yandere.NearestPrompt == (UnityEngine.Object) this.Students[index].Prompt && !this.Students[index].Prompt.HideButton[2])
      {
        Debug.Log((object) ("Under the impression that Student #" + index.ToString() + "'s Attack Prompt is visible."));
        this.AttackPromptActive = true;
      }
    }
  }
}
