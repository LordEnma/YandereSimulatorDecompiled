using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudentScript : MonoBehaviour
{
	public Quaternion targetRotation;

	public Quaternion OriginalRotation;

	public Quaternion OriginalPlateRotation;

	public SelectiveGrayscale ChaseSelectiveGrayscale;

	public YanSaveIdentifier BloodSpawnerIdentifier;

	public DrinkingFountainScript DrinkingFountain;

	public ModernRivalEventScript EventToSabotage;

	public DetectionMarkerScript DetectionMarker;

	public ChemistScannerScript ChemistScanner;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public ChangingBoothScript ChangingBooth;

	public DialogueWheelScript DialogueWheel;

	public WitnessCameraScript WitnessCamera;

	public YanSaveIdentifier BentoIdentifier;

	public YanSaveIdentifier HipsIdentifier;

	public StudentScript DistractionTarget;

	public CookingEventScript CookingEvent;

	public EventManagerScript EventManager;

	public GradingPaperScript GradingPaper;

	public CountdownScript FollowCountdown;

	public ClubManagerScript ClubManager;

	public LightSwitchScript LightSwitch;

	public MovingEventScript MovingEvent;

	public ShoeRemovalScript ShoeRemoval;

	public SnapStudentScript SnapStudent;

	public StruggleBarScript StruggleBar;

	public ToiletEventScript ToiletEvent;

	public WeaponScript WeaponToTakeAway;

	public DynamicGridObstacle Obstacle;

	public StudentScript StudentToMourn;

	public PhoneEventScript PhoneEvent;

	public PickpocketScript PickPocket;

	public ReputationScript Reputation;

	public SimpleLookScript SimpleLook;

	public StudentScript TargetStudent;

	public GenericBentoScript MyBento;

	public StudentScript FollowTarget;

	public CountdownScript Countdown;

	public Renderer SmartPhoneScreen;

	public YanSaveIdentifier YanSave;

	public StudentScript Distractor;

	public StudentScript HuntTarget;

	public StudentScript MyReporter;

	public StudentScript MyTeacher;

	public BoneSetsScript BoneSets;

	public CosmeticScript Cosmetic;

	public PickUpScript PuzzleCube;

	public SaveLoadScript SaveLoad;

	public SubtitleScript Subtitle;

	public StudentScript Follower;

	public DynamicBone OsanaHairL;

	public DynamicBone OsanaHairR;

	public ARMiyukiScript Miyuki;

	public WeaponScript MyWeapon;

	public StudentScript Partner;

	public RagdollScript Ragdoll;

	public YandereScript Yandere;

	public Camera DramaticCamera;

	public RagdollScript Corpse;

	public StudentScript Hunter;

	public DoorScript VomitDoor;

	public BrokenScript Broken;

	public PoliceScript Police;

	public PromptScript Prompt;

	public AIPath Pathfinding;

	public TalkingScript Talk;

	public CheerScript Cheer;

	public ClockScript Clock;

	public RadioScript Radio;

	public Renderer Painting;

	public JsonScript JSON;

	public NapeScript Nape;

	public SuckScript Suck;

	public Renderer Tears;

	public Rigidbody MyRigidbody;

	public Collider HorudaCollider;

	public Collider NapeCollider;

	public Collider MyCollider;

	public CharacterController MyController;

	public Animation CharacterAnimation;

	public Projector LiquidProjector;

	public float VisionFOV;

	public float VisionBonus;

	public float VisionDistance;

	public ParticleSystem DelinquentSpeechLines;

	public ParticleSystem PepperSprayEffect;

	public ParticleSystem DrowningSplashes;

	public ParticleSystem BloodFountain;

	public ParticleSystem VomitEmitter;

	public ParticleSystem SpeechLines;

	public ParticleSystem BullyDust;

	public ParticleSystem ChalkDust;

	public ParticleSystem Hearts;

	public Texture[] PhoneTextures;

	public Texture KokonaPhoneTexture;

	public Texture MidoriPhoneTexture;

	public Texture SocialMediaTexture;

	public Texture OsanaPhoneTexture;

	public Texture RedBookTexture;

	public Texture BloodTexture;

	public Texture BrownTexture;

	public Texture WaterTexture;

	public Texture JokichiHead;

	public Texture GasTexture;

	public SkinnedMeshRenderer EightiesTeacherRenderer;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer BookRenderer;

	public Transform FollowTargetDestination;

	public Transform LastSuspiciousObject2;

	public Transform LastSuspiciousObject;

	public Transform ExamineCorpseTarget;

	public Transform CurrentDestination;

	public Transform LeftMiddleFinger;

	public Transform TrashDestination;

	public Transform WeaponBagParent;

	public Transform LeftItemParent;

	public Transform PetDestination;

	public Transform SketchPosition;

	public Transform CleaningSpot;

	public Transform SleuthTarget;

	public Transform WeirdStudent;

	public Transform Distraction;

	public Transform StalkTarget;

	public Transform CorpseHead;

	public Transform ItemParent;

	public Transform WitnessPOV;

	public Transform RightDrill;

	public Transform BloodPool;

	public Transform LeftDrill;

	public Transform LeftPinky;

	public Transform MapMarker;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform MeetSpot;

	public Transform MyLocker;

	public Transform MyPlate;

	public Transform Spine;

	public Transform Eyes;

	public Transform Head;

	public Transform Hips;

	public Transform Neck;

	public Transform Seat;

	public Transform LipL;

	public Transform LipR;

	public Transform Jaw;

	public ParticleSystem[] LiquidEmitters;

	public ParticleSystem[] SplashEmitters;

	public ParticleSystem[] FireEmitters;

	public ScheduleBlock[] ScheduleBlocks;

	public ScheduleBlock[] OriginalScheduleBlocks;

	public Transform[] Destinations;

	public Transform[] LongHair;

	public Transform[] Skirt;

	public Transform[] Arm;

	public DynamicBone[] BlackHoleEffect;

	public OutlineScript[] Outlines;

	public GameObject[] InstrumentBag;

	public GameObject[] ScienceProps;

	public GameObject[] Instruments;

	public GameObject[] Chopsticks;

	public GameObject[] Drumsticks;

	public GameObject[] Fingerfood;

	public GameObject[] Bones;

	public string[] DelinquentAnims;

	public string[] AnimationNames;

	public string[] GravureAnims;

	public string[] GossipAnims;

	public string[] SleuthAnims;

	public string[] CheerAnims;

	[SerializeField]
	private List<int> VisibleCorpses = new List<int>();

	[SerializeField]
	private int[] CorpseLayers = new int[2] { 11, 14 };

	[SerializeField]
	private LayerMask YandereCheckMask;

	[SerializeField]
	private LayerMask Mask;

	public StudentActionType CurrentAction;

	public StudentActionType[] Actions;

	public StudentActionType[] OriginalActions;

	public AudioClip MurderSuicideKiller;

	public AudioClip MurderSuicideVictim;

	public AudioClip MurderSuicideSounds;

	public AudioClip PoisonDeathClip;

	public AudioClip PepperSpraySFX;

	public AudioClip BurningClip;

	public AudioSource AirGuitar;

	public AudioClip[] FemaleAttacks;

	public AudioClip[] BullyGiggles;

	public AudioClip[] BullyLaughs;

	public AudioClip[] MaleAttacks;

	public SphereCollider HipCollider;

	public Collider RightHandCollider;

	public Collider LeftHandCollider;

	public Collider NotFaceCollider;

	public Collider PantyCollider;

	public Collider SkirtCollider;

	public Collider FaceCollider;

	public Collider PoolStairs;

	public Collider NEStairs;

	public Collider NWStairs;

	public Collider SEStairs;

	public Collider SWStairs;

	public GameObject EightiesTeacherAttacher;

	public GameObject EnterGuardStateCollider;

	public GameObject HeadacheMedicinePrompt;

	public GameObject BloodSprayCollider;

	public GameObject BullyPhotoCollider;

	public GameObject SquishyBloodEffect;

	public GameObject WhiteQuestionMark;

	public GameObject MiyukiGameScreen;

	public GameObject RetroCameraFlash;

	public GameObject EmptyGameObject;

	public GameObject StabBloodEffect;

	public GameObject BountyCollider;

	public GameObject BigWaterSplash;

	public GameObject SecurityCamera;

	public GameObject RightEmptyEye;

	public GameObject LeftEmptyEye;

	public GameObject AnimatedBook;

	public GameObject BloodyScream;

	public GameObject EdgyAttacher;

	public GameObject Handkerchief;

	public GameObject BloodEffect;

	public GameObject CameraFlash;

	public GameObject ChaseCamera;

	public GameObject DeathScream;

	public GameObject PepperSpray;

	public GameObject PinkSeifuku;

	public GameObject RetroCamera;

	public GameObject WateringCan;

	public GameObject BagOfChips;

	public GameObject BloodSpray;

	public GameObject CrushedCan;

	public GameObject GarbageBag;

	public GameObject Sketchbook;

	public GameObject SmartPhone;

	public GameObject OccultBook;

	public GameObject Paintbrush;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject Cigarette;

	public GameObject EventBook;

	public GameObject Handcuffs;

	public GameObject HealthBar;

	public GameObject OsanaHair;

	public GameObject PaperFire;

	public GameObject WeaponBag;

	public GameObject CandyBar;

	public GameObject Earpiece;

	public GameObject Scrubber;

	public GameObject Armband;

	public GameObject BookBag;

	public GameObject Lighter;

	public GameObject MyPaper;

	public GameObject Octodog;

	public GameObject Palette;

	public GameObject SodaCan;

	public GameObject Eraser;

	public GameObject Giggle;

	public GameObject Marker;

	public GameObject Pencil;

	public GameObject Weapon;

	public GameObject Bento;

	public GameObject Paper;

	public GameObject Note;

	public GameObject Pen;

	public GameObject Lid;

	public bool InvestigatingMysteriousDisappearance;

	public bool InvestigatingPossibleBlood;

	public bool InvestigatingPossibleDeath;

	public bool InvestigatingPossibleLimb;

	public bool SpecialRivalDeathReaction;

	public bool WitnessedMindBrokenMurder;

	public bool ReturningMisplacedWeapon;

	public bool SenpaiWitnessingRivalDie;

	public bool ReportingMurderToSenpai;

	public bool IgnoringThingsOnGround;

	public bool PlayerHeldBloodyWeapon;

	public bool TargetedForDistraction;

	public bool SchoolwearUnavailable;

	public bool TakingUpAHeadacheSpot;

	public bool WitnessedBloodyWeapon;

	public bool IgnoringPettyActions;

	public bool ManuallyAdvancePhase;

	public bool ReturnToRoutineAfter;

	public bool TakingUpASedatedSpot;

	public bool ActivateIncinerator;

	public bool MustChangeClothing;

	public bool SawCorpseThisFrame;

	public bool WillRemoveTripwire;

	public bool WitnessedBloodPool;

	public bool WitnessedSomething;

	public bool ConfessAfterwards;

	public bool FoundFriendCorpse;

	public bool LovestruckWaiting;

	public bool MurderedByFragile;

	public bool MurderedByStudent;

	public bool OriginallyTeacher;

	public bool ReturningFromSave;

	public bool GoingToLockerRoom;

	public bool WillRemoveBucket;

	public bool DramaticReaction;

	public bool EventInterrupted;

	public bool EventSpecialCase;

	public bool FoundEnemyCorpse;

	public bool ImmuneToLaughter;

	public bool LostTeacherTrust;

	public bool TemporarilyBlind;

	public bool WitnessedCoverUp;

	public bool WitnessedCorpse;

	public bool WitnessedMurder;

	public bool WitnessedWeapon;

	public bool CrushedByBucket;

	public bool VerballyReacted;

	public bool VisitSenpaiDesk;

	public bool YandereInnocent;

	public bool GetNewAnimation = true;

	public bool AttackWillFail;

	public bool CanStillNotice;

	public bool FocusOnStudent;

	public bool FocusOnYandere;

	public bool ManualRotation;

	public bool NotActuallyWet;

	public bool PinDownWitness;

	public bool RepeatReaction;

	public bool SitInInfirmary;

	public bool StalkerFleeing;

	public bool YandereVisible;

	public bool WitnessedSlave;

	public bool AwareOfCorpse;

	public bool AwareOfMurder;

	public bool CrimeReported;

	public bool ExplainedKick;

	public bool FleeWhenClean;

	public bool MurderSuicide;

	public bool PhotoEvidence;

	public bool RespectEarned;

	public bool SpottedYakuza;

	public bool WitnessedLimb;

	public bool BeenSplashed;

	public bool BoobsResized;

	public bool CanTakeSnack;

	public bool CheckingNote;

	public bool ClubActivity;

	public bool Complimented;

	public bool Electrocuted;

	public bool FragileSlave;

	public bool HoldingHands;

	public bool PlayingAudio;

	public bool StopRotating;

	public bool SawFriendDie;

	public bool SentToLocker;

	public bool TurnOffRadio;

	public bool BusyAtLunch;

	public bool CanGiveHelp;

	public bool Electrified;

	public bool HeardScream;

	public bool HelpOffered;

	public bool IgnoreBlood;

	public bool MusumeRight;

	public bool NeckSnapped;

	public bool StopSliding;

	public bool Traumatized;

	public bool UpdateSkirt;

	public bool WillCombust;

	public bool AlreadyFed;

	public bool ClubAttire;

	public bool ClubLeader;

	public bool Confessing;

	public bool Distracted;

	public bool DoNotShove;

	public bool ExtraBento;

	public bool KilledMood;

	public bool InDarkness;

	public bool Infatuated;

	public bool LewdPhotos;

	public bool SwitchBack;

	public bool Threatened;

	public bool BatheFast;

	public bool Counselor;

	public bool Depressed;

	public bool DoNotFeed;

	public bool DiscCheck;

	public bool DressCode;

	public bool Drownable;

	public bool DyedBrown;

	public bool EndSearch;

	public bool GasWarned;

	public bool KeyStolen;

	public bool KnifeDown;

	public bool LongSkirt;

	public bool Mentoring;

	public bool NoBreakUp;

	public bool NoRagdoll;

	public bool Phoneless;

	public bool RingReact;

	public bool TrueAlone;

	public bool WillChase;

	public bool Attacked;

	public bool BakeSale;

	public bool CanBeFed;

	public bool Headache;

	public bool Gossiped;

	public bool MustTrip;

	public bool Pushable;

	public bool PyroUrge;

	public bool Reflexes;

	public bool Replaced;

	public bool Restless;

	public bool SentHome;

	public bool Splashed;

	public bool Tranquil;

	public bool WalkBack;

	public bool WaterLow;

	public bool Alarmed;

	public bool BadTime;

	public bool Bullied;

	public bool Drowned;

	public bool Forgave;

	public bool GiftBox;

	public bool Indoors;

	public bool InEvent;

	public bool Injured;

	public bool Nemesis;

	public bool Private;

	public bool Reacted;

	public bool Removed;

	public bool SawMask;

	public bool Sedated;

	public bool SlideIn;

	public bool Spawned;

	public bool Stabbed;

	public bool Stalker;

	public bool Started;

	public bool Suicide;

	public bool Teacher;

	public bool Tripped;

	public bool Witness;

	public bool Bloody;

	public bool CanTalk = true;

	public bool Emetic;

	public bool Lethal;

	public bool Routine = true;

	public bool Friend;

	public bool GoAway;

	public bool Grudge;

	public bool Hungry;

	public bool Hunted;

	public bool NoTalk;

	public bool Paired;

	public bool Pushed;

	public bool Shovey;

	public bool Sleepy;

	public bool Urgent;

	public bool Warned;

	public bool Alone;

	public bool Blind;

	public bool Eaten;

	public bool Hurry;

	public bool Rival;

	public bool Slave;

	public bool Calm;

	public bool Halt;

	public bool Lost;

	public bool Male;

	public bool Rose;

	public bool Safe;

	public bool Stop;

	public bool AoT;

	public bool Fed;

	public bool Gas;

	public bool Shy;

	public bool Wet;

	public bool Won;

	public bool DK;

	public bool NotAlarmedByYandereChan;

	public bool InvestigatingBloodPool;

	public bool ResumeTakingOutTrash;

	public bool RetreivingMedicine;

	public bool ListeningToReport;

	public bool ResumeDistracting;

	public bool UpdateAppearance;

	public bool BreakingUpFight;

	public bool SeekingMedicine;

	public bool ReportingMurder;

	public bool CameraReacting;

	public bool UsingRigidbody;

	public bool ReportingBlood;

	public bool TakingOutTrash;

	public bool FightingSlave;

	public bool Investigating;

	public bool SolvingPuzzle;

	public bool ChangingShoes;

	public bool Distracting;

	public bool EatingSnack;

	public bool HitReacting;

	public bool PinningDown;

	public bool WasHurrying;

	public bool Struggling;

	public bool Following;

	public bool NotEating;

	public bool Sleuthing;

	public bool Stripping;

	public bool Fighting;

	public bool Guarding;

	public bool Ignoring;

	public bool Pursuing;

	public bool Spraying;

	public bool Tripping;

	public bool Vomiting;

	public bool Burning;

	public bool Chasing;

	public bool Curious;

	public bool Fleeing;

	public bool Hunting;

	public bool Leaving;

	public bool Meeting;

	public bool Shoving;

	public bool Talking;

	public bool Waiting;

	public bool Dodging;

	public bool Posing;

	public bool Dying;

	public float DistanceToDestination;

	public float InvestigationDistance;

	public float FollowTargetDistance;

	public float DistanceToPlayer;

	public float TargetDistance;

	public float ThreatDistance;

	public float LockerRoomCheckTimer;

	public float WitnessCooldownTimer;

	public float InstantNoticeTimer;

	public float InvestigationTimer;

	public float PersonalSpaceTimer;

	public float CameraPoseTimer;

	public float IgnoreFoodTimer;

	public float RivalDeathTimer;

	public float CuriosityTimer;

	public float DistractTimer;

	public float DramaticTimer;

	public float MedicineTimer;

	public float ReactionTimer;

	public float WalkBackTimer;

	public float AmnesiaTimer;

	public float ElectroTimer;

	public float StretchTimer;

	public float PuzzleTimer;

	public float GiggleTimer;

	public float GoAwayTimer;

	public float IgnoreTimer;

	public float LyricsTimer;

	public float MiyukiTimer;

	public float MusumeTimer;

	public float PatrolTimer;

	public float PursueTimer;

	public float ReportTimer;

	public float SplashTimer;

	public float ThreatTimer;

	public float UpdateTimer;

	public float AlarmTimer;

	public float BatheTimer;

	public float ChaseTimer;

	public float CheerTimer;

	public float CleanTimer;

	public float LaughTimer;

	public float RadioTimer;

	public float SnackTimer;

	public float SprayTimer;

	public float StuckTimer;

	public float ClubTimer;

	public float HuntTimer;

	public float MeetTimer;

	public float PyroTimer;

	public float ReadTimer;

	public float SulkTimer;

	public float TalkTimer;

	public float WaitTimer;

	public float SewTimer;

	public float TargetWeaponDistance;

	public float OriginalYPosition;

	public float PreviousEyeShrink;

	public float PhotoPatience;

	public float PreviousAlarm;

	public float ClubThreshold = 6f;

	public float RepDeduction;

	public float GoAwayLimit = 10f;

	public float RepRecovery;

	public float BreastSize;

	public float DodgeSpeed = 2f;

	public float Hesitation;

	public float PendingRep;

	public float Perception = 1f;

	public float EyeShrink;

	public float PyroLimit;

	public float WalkSpeed = 1f;

	public float MeetTime;

	public float Paranoia;

	public float RepLoss;

	public float Health = 100f;

	public float Alarm;

	public float OriginalHairR = 1f;

	public float OriginalHairG = 1f;

	public float OriginalHairB = 1f;

	public float OriginalEyeR = 1f;

	public float OriginalEyeG = 1f;

	public float OriginalEyeB = 1f;

	public int ReturningMisplacedWeaponPhase;

	public int RetrieveMedicinePhase;

	public int WitnessRivalDiePhase;

	public int ChangeClothingPhase;

	public int InvestigationPhase;

	public int MurderSuicidePhase;

	public int ClubActivityPhase;

	public int SeekMedicinePhase;

	public int CameraReactPhase;

	public int CuriosityPhase;

	public int BakeSalePhase;

	public int DramaticPhase;

	public int GraffitiPhase;

	public int SentHomePhase;

	public int SunbathePhase;

	public int ConfessPhase = 1;

	public int SciencePhase;

	public int StretchPhase;

	public int LyricsPhase;

	public int ReportPhase;

	public int SplashPhase;

	public int ThreatPhase = 1;

	public int BathePhase;

	public int BullyPhase;

	public int RadioPhase = 1;

	public int SnackPhase;

	public int TrashPhase;

	public int VomitPhase;

	public int ClubPhase;

	public int PyroPhase;

	public int SulkPhase;

	public int TaskPhase;

	public int ReadPhase;

	public int PinPhase;

	public int Phase;

	public PersonaType OriginalPersona;

	public StudentInteractionType Interaction;

	public int TimesWeaponWitnessed;

	public int TimesBloodWitnessed;

	public int TimesAlarmed;

	public int TimesAnnoyed;

	public int StinkBombSpecialCase;

	public int ElectrocutionVictim;

	public int AfterWitnessBonus;

	public int BloodPoolsSpawned;

	public int AnnoyedByGiggles;

	public int LovestruckTarget;

	public int MurdersWitnessed;

	public int WeaponWitnessed;

	public int AnnoyedByRadio;

	public int MurderReaction;

	public int PhaseFromSave;

	public int WarningsGiven;

	public int CleaningRole;

	public int StruggleWait;

	public int WitnessBonus;

	public int GossipBonus;

	public int DeathCause;

	public int Schoolwear;

	public int SkinColor = 3;

	public int Attempts;

	public int Patience = 5;

	public int Pestered;

	public int RepBonus;

	public int Strength;

	public int Concern;

	public int Defeats;

	public int Crush;

	public int CuddlePartnerID;

	public int GenericTaskID;

	public int InfatuationID;

	public int PinDownID;

	public StudentWitnessType PreviouslyWitnessed;

	public StudentWitnessType Witnessed;

	public GameOverType GameOverCause;

	public DeathType DeathType;

	public string OriginalDestination = string.Empty;

	public string OriginalAction = string.Empty;

	public string CurrentAnim = string.Empty;

	public string RivalPrefix = string.Empty;

	public string RandomAnim = string.Empty;

	public string Accessory = string.Empty;

	public string Hairstyle = string.Empty;

	public string Suffix = string.Empty;

	public string Name = string.Empty;

	public string OriginalOriginalWalkAnim = string.Empty;

	public string OriginalOriginalSprintAnim = string.Empty;

	public string OriginalIdleAnim = string.Empty;

	public string OriginalWalkAnim = string.Empty;

	public string OriginalSprintAnim = string.Empty;

	public string OriginalLeanAnim = string.Empty;

	public string WalkAnim = string.Empty;

	public string RunAnim = string.Empty;

	public string SprintAnim = string.Empty;

	public string IdleAnim = string.Empty;

	public string TalkAnim = string.Empty;

	public string Nod1Anim = string.Empty;

	public string Nod2Anim = string.Empty;

	public string DefendAnim = string.Empty;

	public string DeathAnim = string.Empty;

	public string ScaredAnim = string.Empty;

	public string EvilWitnessAnim = string.Empty;

	public string LookDownAnim = string.Empty;

	public string PhoneAnim = string.Empty;

	public string AngryFaceAnim = string.Empty;

	public string ToughFaceAnim = string.Empty;

	public string InspectAnim = string.Empty;

	public string GuardAnim = string.Empty;

	public string CallAnim = string.Empty;

	public string CounterAnim = string.Empty;

	public string PushedAnim = string.Empty;

	public string GameAnim = string.Empty;

	public string BentoAnim = string.Empty;

	public string EatAnim = string.Empty;

	public string DrownAnim = string.Empty;

	public string WetAnim = string.Empty;

	public string SplashedAnim = string.Empty;

	public string StripAnim = string.Empty;

	public string ParanoidAnim = string.Empty;

	public string GossipAnim = string.Empty;

	public string SadSitAnim = string.Empty;

	public string BrokenAnim = string.Empty;

	public string BrokenSitAnim = string.Empty;

	public string BrokenWalkAnim = string.Empty;

	public string FistAnim = string.Empty;

	public string AttackAnim = string.Empty;

	public string SuicideAnim = string.Empty;

	public string RelaxAnim = string.Empty;

	public string SitAnim = string.Empty;

	public string ShyAnim = string.Empty;

	public string PeekAnim = string.Empty;

	public string ClubAnim = string.Empty;

	public string StruggleAnim = string.Empty;

	public string StruggleWonAnim = string.Empty;

	public string StruggleLostAnim = string.Empty;

	public string SocialSitAnim = string.Empty;

	public string CarryAnim = string.Empty;

	public string ActivityAnim = string.Empty;

	public string GrudgeAnim = string.Empty;

	public string SadFaceAnim = string.Empty;

	public string CowardAnim = string.Empty;

	public string EvilAnim = string.Empty;

	public string SocialReportAnim = string.Empty;

	public string SocialFearAnim = string.Empty;

	public string SocialTerrorAnim = string.Empty;

	public string BuzzSawDeathAnim = string.Empty;

	public string SwingDeathAnim = string.Empty;

	public string CyborgDeathAnim = string.Empty;

	public string WalkBackAnim = string.Empty;

	public string PatrolAnim = string.Empty;

	public string RadioAnim = string.Empty;

	public string BookSitAnim = string.Empty;

	public string BookReadAnim = string.Empty;

	public string LovedOneAnim = string.Empty;

	public string CuddleAnim = string.Empty;

	public string VomitAnim = string.Empty;

	public string WashFaceAnim = string.Empty;

	public string EmeticAnim = string.Empty;

	public string BurningAnim = string.Empty;

	public string JojoReactAnim = string.Empty;

	public string TeachAnim = string.Empty;

	public string LeanAnim = string.Empty;

	public string DeskTextAnim = string.Empty;

	public string CarryShoulderAnim = string.Empty;

	public string ReadyToFightAnim = string.Empty;

	public string SearchPatrolAnim = string.Empty;

	public string DiscoverPhoneAnim = string.Empty;

	public string WaitAnim = string.Empty;

	public string ShoveAnim = string.Empty;

	public string SprayAnim = string.Empty;

	public string SithReactAnim = string.Empty;

	public string EatVictimAnim = string.Empty;

	public string RandomGossipAnim = string.Empty;

	public string CuteAnim = string.Empty;

	public string BulliedIdleAnim = string.Empty;

	public string BulliedWalkAnim = string.Empty;

	public string BullyVictimAnim = string.Empty;

	public string SadDeskSitAnim = string.Empty;

	public string ConfusedSitAnim = string.Empty;

	public string SentHomeAnim = string.Empty;

	public string RandomCheerAnim = string.Empty;

	public string ParanoidWalkAnim = string.Empty;

	public string SleuthIdleAnim = string.Empty;

	public string SleuthWalkAnim = string.Empty;

	public string SleuthCalmAnim = string.Empty;

	public string SleuthScanAnim = string.Empty;

	public string SleuthReactAnim = string.Empty;

	public string SleuthSprintAnim = string.Empty;

	public string SleuthReportAnim = string.Empty;

	public string RandomSleuthAnim = string.Empty;

	public string BreakUpAnim = string.Empty;

	public string PaintAnim = string.Empty;

	public string SketchAnim = string.Empty;

	public string RummageAnim = string.Empty;

	public string ThinkAnim = string.Empty;

	public string ActAnim = string.Empty;

	public string OriginalClubAnim = string.Empty;

	public string MiyukiAnim = string.Empty;

	public string VictoryAnim = string.Empty;

	public string PlateIdleAnim = string.Empty;

	public string PlateWalkAnim = string.Empty;

	public string PlateEatAnim = string.Empty;

	public string PrepareFoodAnim = string.Empty;

	public string PoisonDeathAnim = string.Empty;

	public string HeadacheAnim = string.Empty;

	public string HeadacheSitAnim = string.Empty;

	public string ElectroAnim = string.Empty;

	public string EatChipsAnim = string.Empty;

	public string DrinkFountainAnim = string.Empty;

	public string PullBoxCutterAnim = string.Empty;

	public string TossNoteAnim = string.Empty;

	public string KeepNoteAnim = string.Empty;

	public string BathingAnim = string.Empty;

	public string DodgeAnim = string.Empty;

	public string InspectBloodAnim = string.Empty;

	public string PickUpAnim = string.Empty;

	public string PuzzleAnim = string.Empty;

	public string LandLineAnim = string.Empty;

	public string SulkAnim = string.Empty;

	public string BeforeReturnAnim = string.Empty;

	public string AdmireAnim = string.Empty;

	public string StretchAnim = string.Empty;

	public string LookLeftRightAnim = string.Empty;

	public string PinDownAnim = string.Empty;

	public string WaveAnim = string.Empty;

	public string MurderSuicideAnim = string.Empty;

	public string CustomHangoutAnim = string.Empty;

	public string CustomPatrolAnim = string.Empty;

	public string[] AdmireAnims;

	public string[] CleanAnims;

	public string[] CameraAnims;

	public string[] SocialAnims;

	public string[] CowardAnims;

	public string[] EvilAnims;

	public string[] HeroAnims;

	public string[] TaskAnims;

	public string[] PhoneAnims;

	public string[] StretchAnims;

	public string[] IdleAnims;

	public string[] WalkAnims;

	public int ClubMemberID;

	public int StudentID;

	public int WitnessID;

	public int CorpseID;

	public int PatrolID;

	public int SleuthID;

	public int BullyID;

	public int CleanID;

	public int GuardID;

	public int GirlID;

	public int Class;

	public int ID;

	public PersonaType Persona;

	public ClubType OriginalClub;

	public ClubType Club;

	public Vector3 OriginalBloodPoolLocation;

	public Vector3 OriginalPlatePosition;

	public Vector3 OriginalPosition;

	public Vector3 LastKnownCorpse;

	public Vector3 DistractionSpot;

	public Vector3 LastKnownBlood;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3 PreviousSkirt;

	public Vector3 LastPosition;

	public Vector3 BurnTarget;

	public Vector3 OriginalEyePos;

	public Vector3 OriginalEyeRot;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform RightEye;

	public Transform LeftEye;

	public int Frame;

	private float MaxSpeed = 10f;

	private const string RIVAL_PREFIX = "Rival ";

	public Vector3[] SkirtPositions;

	public Vector3[] SkirtRotations;

	public Vector3[] SkirtOrigins;

	public Transform DefaultTarget;

	public Transform GushTarget;

	public bool Gush;

	public float LookSpeed = 2f;

	public float TimeOfDeath;

	public int Fate;

	public float TeacherTimer;

	public LowPolyStudentScript LowPoly;

	public GameObject EightiesPhone;

	public Material BloodMaterial;

	public Material BrownMaterial;

	public Material WaterMaterial;

	public Material GasMaterial;

	public bool NoScream;

	public GameObject JojoHitEffect;

	public GameObject[] ElectroSteam;

	public GameObject[] CensorSteam;

	public Texture NudeTexture;

	public Mesh BaldNudeMesh;

	public Mesh NudeMesh;

	public Texture TowelTexture;

	public Mesh TowelMesh;

	public Mesh SwimmingTrunks;

	public Mesh SchoolSwimsuit;

	public Mesh GymUniform;

	public Texture GyaruSwimsuitTexture;

	public Texture EightiesGymTexture;

	public Texture SwimsuitTexture;

	public Texture UniformTexture;

	public Texture GymTexture;

	public Texture TitanBodyTexture;

	public Texture TitanFaceTexture;

	public bool Spooky;

	public Mesh JudoGiMesh;

	public Texture JudoGiTexture;

	public RiggedAccessoryAttacher Attacher;

	public bool WearingBikini;

	public Mesh NoArmsNoTorso;

	public GameObject RiggedAccessory;

	public int CoupleID;

	public int PartnerID;

	public bool SearchingForPhone;

	public float ChameleonBonus;

	public bool Chameleon;

	public bool SleuthInitialized;

	public int TeacherID = 90;

	public RiggedAccessoryAttacher LabcoatAttacher;

	public RiggedAccessoryAttacher BikiniAttacher;

	public RiggedAccessoryAttacher ApronAttacher;

	public Mesh HeadAndHands;

	private bool NoMentor;

	public bool BagPlaced;

	public RaycastHit hit;

	public Transform RaycastOrigin;

	public bool TooCloseToWall;

	private Vector3 RaycastOriginVector;

	public bool ResumeFollowingAfter;

	public float[] OriginalTimes;

	public string[] OriginalDests;

	public string[] OriginalActs;

	public OutlineScript[] RiggedAccessoryOutlines;

	public int RiggedAccessoryOutlineID;

	public MiniMapComponent MiniMapIcon;

	public Sprite SenpaiSprite;

	public Sprite RivalSprite;

	public float SavePositionX;

	public float SavePositionY;

	public float SavePositionZ;

	public string ReturnDestination;

	public string ReturnAction;

	public bool Alive => DeathType == DeathType.None;

	private SubtitleType LostPhoneSubtitleType
	{
		get
		{
			if (RivalPrefix == string.Empty)
			{
				return SubtitleType.LostPhone;
			}
			if (RivalPrefix == "Rival ")
			{
				return SubtitleType.RivalLostPhone;
			}
			throw new NotImplementedException("\"" + RivalPrefix + "\" case not implemented.");
		}
	}

	private SubtitleType PickpocketSubtitleType
	{
		get
		{
			Debug.Log("This is where the game determines what pickpocket subtitle to use.");
			if (Male)
			{
				Subtitle.CustomText = "Hey! Are you trying to take my keys? Knock it off!";
				return SubtitleType.Custom;
			}
			if (RivalPrefix == string.Empty)
			{
				return SubtitleType.PickpocketReaction;
			}
			if (RivalPrefix == "Rival ")
			{
				return SubtitleType.RivalPickpocketReaction;
			}
			throw new NotImplementedException("\"" + RivalPrefix + "\" case not implemented.");
		}
	}

	private SubtitleType SplashSubtitleType
	{
		get
		{
			if (RivalPrefix == string.Empty)
			{
				if (!Male)
				{
					return SubtitleType.SplashReaction;
				}
				return SubtitleType.SplashReactionMale;
			}
			if (RivalPrefix == "Rival ")
			{
				return SubtitleType.RivalSplashReaction;
			}
			throw new NotImplementedException("\"" + RivalPrefix + "\" case not implemented.");
		}
	}

	public SubtitleType TaskLineResponseType
	{
		get
		{
			bool flag = false;
			if (StudentManager.Eighties)
			{
				flag = true;
				if ((StudentID > 10 && StudentID < 21) || StudentID == 79)
				{
					flag = false;
				}
				if (StudentManager.CustomMode && StudentID > 10 && StudentID < 21)
				{
					flag = true;
				}
			}
			if (StudentManager.Eighties && flag)
			{
				if (GenericTaskID == 1)
				{
					return SubtitleType.TaskGenericEightiesLine1;
				}
				if (GenericTaskID == 2)
				{
					return SubtitleType.TaskGenericEightiesLine2;
				}
				if (GenericTaskID == 3)
				{
					return SubtitleType.TaskGenericEightiesLine3;
				}
				if (GenericTaskID == 4)
				{
					return SubtitleType.TaskGenericEightiesLine4;
				}
				if (GenericTaskID == 5)
				{
					return SubtitleType.TaskGenericEightiesLine5;
				}
				if (GenericTaskID == 6)
				{
					return SubtitleType.TaskGenericEightiesLine6;
				}
				if (GenericTaskID == 7)
				{
					return SubtitleType.TaskGenericEightiesLine7;
				}
				if (GenericTaskID == 8)
				{
					return SubtitleType.TaskGenericEightiesLine8;
				}
				if (GenericTaskID == 9)
				{
					return SubtitleType.TaskGenericEightiesLine9;
				}
				if (GenericTaskID == 10)
				{
					return SubtitleType.TaskGenericEightiesLine10;
				}
				Debug.Log("This student doesn't have a Generic Task ID assigned.");
				return SubtitleType.TaskGenericEightiesLine1;
			}
			if (StudentID == 4)
			{
				return SubtitleType.Task4Line;
			}
			if (StudentID == 6)
			{
				return SubtitleType.Task6Line;
			}
			if (StudentID == 8)
			{
				return SubtitleType.Task8Line;
			}
			if (StudentID == 11)
			{
				return SubtitleType.Task11Line;
			}
			if (StudentID == 12)
			{
				return SubtitleType.Task12Line;
			}
			if (StudentID == 13)
			{
				return SubtitleType.Task13Line;
			}
			if (StudentID == 14)
			{
				return SubtitleType.Task14Line;
			}
			if (StudentID == 15)
			{
				return SubtitleType.Task15Line;
			}
			if (StudentID == 16)
			{
				return SubtitleType.Task16Line;
			}
			if (StudentID == 17)
			{
				return SubtitleType.Task17Line;
			}
			if (StudentID == 18)
			{
				return SubtitleType.Task18Line;
			}
			if (StudentID == 19)
			{
				return SubtitleType.Task19Line;
			}
			if (StudentID == 20)
			{
				return SubtitleType.Task20Line;
			}
			if (StudentID == 25)
			{
				return SubtitleType.Task25Line;
			}
			if (StudentID == 28)
			{
				return SubtitleType.Task28Line;
			}
			if (StudentID == 30)
			{
				return SubtitleType.Task30Line;
			}
			if (StudentID == 36)
			{
				return SubtitleType.Task36Line;
			}
			if (StudentID == 37)
			{
				return SubtitleType.Task37Line;
			}
			if (StudentID == 38)
			{
				return SubtitleType.Task38Line;
			}
			if (StudentID == 41)
			{
				return SubtitleType.Task41Line;
			}
			if (StudentID == 46)
			{
				return SubtitleType.Task46Line;
			}
			if (StudentID == 47)
			{
				return SubtitleType.Task47Line;
			}
			if (StudentID == 48)
			{
				return SubtitleType.Task48Line;
			}
			if (StudentID == 49)
			{
				return SubtitleType.Task49Line;
			}
			if (StudentID == 50)
			{
				return SubtitleType.Task50Line;
			}
			if (StudentID == 52)
			{
				return SubtitleType.Task52Line;
			}
			if (StudentID == 76)
			{
				return SubtitleType.Task76Line;
			}
			if (StudentID == 77)
			{
				return SubtitleType.Task77Line;
			}
			if (StudentID == 78)
			{
				return SubtitleType.Task78Line;
			}
			if (StudentID == 79)
			{
				return SubtitleType.Task79Line;
			}
			if (StudentID == 80)
			{
				return SubtitleType.Task80Line;
			}
			if (StudentID == 81)
			{
				return SubtitleType.Task81Line;
			}
			return SubtitleType.TaskGenericLine;
		}
	}

	public SubtitleType ClubInfoResponseType
	{
		get
		{
			if (StudentManager.EmptyDemon)
			{
				return SubtitleType.ClubPlaceholderInfo;
			}
			if (Club == ClubType.Cooking)
			{
				return SubtitleType.ClubCookingInfo;
			}
			if (Club == ClubType.Drama)
			{
				return SubtitleType.ClubDramaInfo;
			}
			if (Club == ClubType.Occult)
			{
				return SubtitleType.ClubOccultInfo;
			}
			if (Club == ClubType.Art)
			{
				return SubtitleType.ClubArtInfo;
			}
			if (Club == ClubType.LightMusic)
			{
				return SubtitleType.ClubLightMusicInfo;
			}
			if (Club == ClubType.MartialArts)
			{
				return SubtitleType.ClubMartialArtsInfo;
			}
			if (Club == ClubType.Photography)
			{
				if (Sleuthing)
				{
					return SubtitleType.ClubPhotoInfoDark;
				}
				return SubtitleType.ClubPhotoInfoLight;
			}
			if (Club == ClubType.Science)
			{
				return SubtitleType.ClubScienceInfo;
			}
			if (Club == ClubType.Sports)
			{
				return SubtitleType.ClubSportsInfo;
			}
			if (Club == ClubType.Gardening)
			{
				return SubtitleType.ClubGardenInfo;
			}
			if (Club == ClubType.Gaming)
			{
				return SubtitleType.ClubGamingInfo;
			}
			if (Club == ClubType.Delinquent)
			{
				return SubtitleType.ClubDelinquentInfo;
			}
			if (Club == ClubType.Newspaper)
			{
				return SubtitleType.ClubNewspaperInfo;
			}
			return SubtitleType.ClubPlaceholderInfo;
		}
	}

	public bool InCouple => CoupleID > 0;

	public int OnlyDefault => 1;

	public void Start()
	{
		string idleAnim = IdleAnim;
		CounterAnim = "f02_teacherCounterB_00";
		if (!Started)
		{
			CharacterAnimation = Character.GetComponent<Animation>();
			MyBento = Bento.GetComponent<GenericBentoScript>();
			Pathfinding.repathRate += (float)StudentID * 0.01f;
			OriginalIdleAnim = IdleAnim;
			OriginalLeanAnim = LeanAnim;
			Friend = PlayerGlobals.GetStudentFriend(StudentID);
			if (ClubGlobals.Club == ClubType.Occult)
			{
				Perception = 0.5f;
			}
			ParticleSystem.EmissionModule emission = Hearts.emission;
			emission.enabled = false;
			Prompt.OwnerType = PromptOwnerType.Person;
			Paranoia = 2f - SchoolGlobals.SchoolAtmosphere;
			VisionDistance = ((PlayerGlobals.PantiesEquipped == 4) ? 5f : 10f) * Paranoia;
			if (Yandere != null && Yandere.DetectionPanel != null)
			{
				SpawnDetectionMarker();
			}
			StudentJson studentJson = JSON.Students[StudentID];
			OriginalScheduleBlocks = studentJson.ScheduleBlocks;
			ScheduleBlocks = studentJson.ScheduleBlocks;
			Persona = studentJson.Persona;
			Class = studentJson.Class;
			Crush = studentJson.Crush;
			Club = studentJson.Club;
			BreastSize = studentJson.BreastSize;
			Strength = studentJson.Strength;
			Hairstyle = studentJson.Hairstyle;
			Accessory = studentJson.Accessory;
			Name = studentJson.Name;
			OriginalClub = Club;
			if (!StudentManager.LoveSick && SchoolAtmosphere.Type == SchoolAtmosphereType.Low && Club != ClubType.Council && Persona != PersonaType.Heroic && Persona != PersonaType.Violent && StudentID < 90 && (Club <= ClubType.Gaming || Club == ClubType.Newspaper))
			{
				IdleAnim = ParanoidAnim;
			}
			if (StudentGlobals.GetStudentBroken(StudentID))
			{
				Cosmetic.RightEyeRenderer.gameObject.SetActive(value: false);
				Cosmetic.LeftEyeRenderer.gameObject.SetActive(value: false);
				Cosmetic.RightIrisLight.SetActive(value: false);
				Cosmetic.LeftIrisLight.SetActive(value: false);
				RightEmptyEye.SetActive(value: true);
				LeftEmptyEye.SetActive(value: true);
				Traumatized = true;
				Shy = true;
				Persona = PersonaType.Coward;
			}
			if (Name == "Random")
			{
				Persona = (PersonaType)UnityEngine.Random.Range(1, 8);
				if (Persona == PersonaType.Lovestruck)
				{
					Persona = PersonaType.PhoneAddict;
				}
				studentJson.Persona = Persona;
				if (Persona == PersonaType.Heroic)
				{
					Strength = UnityEngine.Random.Range(1, 5);
					studentJson.Strength = Strength;
				}
			}
			Seat = StudentManager.Seats[Class].List[studentJson.Seat];
			base.gameObject.name = "Student_" + StudentID + " (" + Name + ")";
			OriginalPersona = Persona;
			if (StudentID == 81 && StudentGlobals.GetStudentBroken(81))
			{
				Persona = PersonaType.Coward;
			}
			if (Persona == PersonaType.Loner || Persona == PersonaType.Coward || Persona == PersonaType.Fragile)
			{
				CameraAnims = CowardAnims;
			}
			else if (Persona == PersonaType.TeachersPet || Persona == PersonaType.Heroic || Persona == PersonaType.Strict)
			{
				CameraAnims = HeroAnims;
			}
			else if (Persona == PersonaType.Evil || Persona == PersonaType.Spiteful || Persona == PersonaType.Violent)
			{
				CameraAnims = EvilAnims;
			}
			else if (Persona == PersonaType.SocialButterfly || Persona == PersonaType.Lovestruck || Persona == PersonaType.PhoneAddict || Persona == PersonaType.Sleuth)
			{
				CameraAnims = SocialAnims;
			}
			if (ClubGlobals.GetClubClosed(Club))
			{
				if ((Club == ClubType.Cooking || Club == ClubType.Drama || Club == ClubType.Occult || Club == ClubType.Gaming || Club == ClubType.Art || Club == ClubType.MartialArts || Club == ClubType.LightMusic || Club == ClubType.Photography || Club == ClubType.Science || Club == ClubType.Sports || Club == ClubType.Gardening || Club == ClubType.Newspaper) && StudentManager.SuitorID != StudentID)
				{
					ScheduleBlock obj = ScheduleBlocks[7];
					obj.destination = "Locker";
					obj.action = "Shoes";
					if (ScheduleBlocks.Length > 8)
					{
						ScheduleBlock obj2 = ScheduleBlocks[8];
						obj2.destination = "Exit";
						obj2.action = "Stand";
					}
				}
				Club = ClubType.None;
				GetDestinations();
			}
			Yandere = StudentManager.Yandere;
			StalkTarget = Yandere.transform;
			DialogueWheel = StudentManager.DialogueWheel;
			ClubManager = StudentManager.ClubManager;
			Reputation = StudentManager.Reputation;
			Subtitle = Yandere.Subtitle;
			Police = StudentManager.Police;
			Clock = StudentManager.Clock;
			CameraEffects = Yandere.MainCamera.GetComponent<CameraEffectsScript>();
			RightEyeOrigin = RightEye.localPosition;
			LeftEyeOrigin = LeftEye.localPosition;
			Bento.GetComponent<GenericBentoScript>().StudentID = StudentID;
			DisableProps();
			OriginalOriginalSprintAnim = SprintAnim;
			OriginalOriginalWalkAnim = WalkAnim;
			OriginalSprintAnim = SprintAnim;
			OriginalWalkAnim = WalkAnim;
			if (Persona == PersonaType.Evil)
			{
				ScaredAnim = EvilWitnessAnim;
			}
			if (Persona == PersonaType.PhoneAddict)
			{
				SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
				SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
				Countdown.Speed = 0.1f;
				if (!StudentManager.Eighties)
				{
					SprintAnim = PhoneAnims[2];
					PatrolAnim = PhoneAnims[3];
				}
			}
			if (Club == ClubType.Bully)
			{
				SkirtCollider.transform.localPosition = new Vector3(0f, 0.055f, 0f);
				if (!StudentGlobals.GetStudentBroken(StudentID))
				{
					if (!StudentManager.Eighties)
					{
						IdleAnim = PhoneAnims[0];
					}
					BullyID = StudentID - 80;
				}
			}
			DisableProps();
			if (Rival)
			{
				MapMarker.gameObject.SetActive(value: true);
				if (StudentManager.MissionMode)
				{
					MapMarker.gameObject.GetComponent<Renderer>().material.mainTexture = StudentManager.TargetMapMarker;
					MapMarker.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 1f);
				}
				else if (StudentManager.CustomMode)
				{
					MapMarker.gameObject.GetComponent<Renderer>().material.mainTexture = StudentManager.RivalMapMarker;
				}
				else if (StudentManager.Eighties)
				{
					MapMarker.gameObject.GetComponent<Renderer>().material.mainTexture = StudentManager.Police.EndOfDay.Counselor.EightiesRivalHeads[StudentManager.Week];
				}
				else
				{
					MapMarker.gameObject.GetComponent<Renderer>().material.mainTexture = StudentManager.Police.EndOfDay.Counselor.RivalHeads[StudentManager.Week];
				}
			}
			if (!StudentManager.Eighties)
			{
				int num = StudentID;
				if (num > 35)
				{
					while (num > 35)
					{
						num -= 35;
					}
				}
				SmartPhone.GetComponent<Renderer>().material.mainTexture = PhoneTextures[num];
				if (StudentID == 1)
				{
					MapMarker.gameObject.SetActive(value: true);
					if (DateGlobals.Week == 2)
					{
						ScheduleBlock obj3 = ScheduleBlocks[2];
						obj3.destination = "Patrol";
						obj3.action = "Patrol";
						ScheduleBlock obj4 = ScheduleBlocks[7];
						obj4.destination = "Patrol";
						obj4.action = "Patrol";
					}
				}
				else if (StudentID == 2)
				{
					if (StudentGlobals.GetStudentDead(3) || StudentGlobals.GetStudentKidnapped(3) || StudentManager.Students[3] == null || (StudentManager.Students[3] != null && StudentManager.Students[3].Slave))
					{
						ScheduleBlock obj5 = ScheduleBlocks[2];
						obj5.destination = "Mourn";
						obj5.action = "Mourn";
						ScheduleBlock obj6 = ScheduleBlocks[7];
						obj6.destination = "Mourn";
						obj6.action = "Mourn";
						IdleAnim = BulliedIdleAnim;
						WalkAnim = BulliedWalkAnim;
					}
					PatrolAnim = SearchPatrolAnim;
				}
				else if (StudentID == 3)
				{
					if (StudentGlobals.GetStudentDead(2) || StudentGlobals.GetStudentKidnapped(2) || StudentManager.Students[2] == null || (StudentManager.Students[2] != null && StudentManager.Students[2].Slave))
					{
						ScheduleBlock obj7 = ScheduleBlocks[2];
						obj7.destination = "Mourn";
						obj7.action = "Mourn";
						ScheduleBlock obj8 = ScheduleBlocks[7];
						obj8.destination = "Mourn";
						obj8.action = "Mourn";
						IdleAnim = BulliedIdleAnim;
						WalkAnim = BulliedWalkAnim;
					}
					PatrolAnim = SearchPatrolAnim;
				}
				else if (StudentID == 4)
				{
					IdleAnim = "f02_idleShort_00";
					WalkAnim = "f02_newWalk_00";
				}
				else if (StudentID == 5)
				{
					if (!StudentManager.TakingPortraits)
					{
						if (StudentManager.Students[81] == null && StudentManager.Students[82] == null && StudentManager.Students[83] == null && StudentManager.Students[84] == null && StudentManager.Students[85] == null)
						{
							CharacterAnimation["f02_smile_00"].layer = 1;
							CharacterAnimation.Play("f02_smile_00");
							CharacterAnimation["f02_smile_00"].weight = 1f;
						}
						else
						{
							Shy = true;
						}
					}
					WaveAnim = "f02_casualWave_04";
				}
				else if (StudentID == 6)
				{
					RelaxAnim = "crossarms_00";
					CameraAnims = HeroAnims;
					Curious = true;
					Crush = 11;
					if (StudentManager.Students[11] == null || StudentManager.Students[11].Slave)
					{
						Curious = false;
					}
				}
				else if (StudentID == 7)
				{
					MustTrip = true;
					RunAnim = "runFeminine_00";
					SprintAnim = "runFeminine_00";
					RelaxAnim = "infirmaryRest_00";
					OriginalSprintAnim = SprintAnim;
					Cosmetic.Start();
					if (!GameGlobals.AlphabetMode && !StudentManager.MissionMode)
					{
						base.gameObject.SetActive(value: false);
					}
					if (GameGlobals.AlphabetMode)
					{
						Head.gameObject.GetComponent<SphereCollider>().radius = 0.3f;
					}
					WaveAnim = "f02_casualWave_04";
				}
				else if (StudentID == 8)
				{
					IdleAnim = BulliedIdleAnim;
					WalkAnim = BulliedWalkAnim;
					WaveAnim = "f02_casualWave_04";
				}
				else if (StudentID == 9)
				{
					IdleAnim = "idleScholarly_00";
					WalkAnim = "walkScholarly_00";
					CameraAnims = HeroAnims;
				}
				else if (StudentID == 10)
				{
					Reflexes = true;
					if (GameGlobals.AlphabetMode || StudentManager.MissionMode)
					{
						OriginalPersona = PersonaType.Heroic;
						Persona = PersonaType.Heroic;
						Reflexes = false;
						Strength = 5;
					}
					else
					{
						LovestruckTarget = 11;
					}
					if (StudentManager.Students[11] != null && DatingGlobals.SuitorProgress < 2 && (float)StudentGlobals.GetStudentReputation(10) > -33.33333f && StudentGlobals.StudentSlave != 11 && !GameGlobals.AlphabetMode && !StudentManager.MissionMode)
					{
						StudentManager.Patrols.List[StudentID].parent = StudentManager.Students[11].transform;
						StudentManager.Patrols.List[StudentID].localEulerAngles = new Vector3(0f, 0f, 0f);
						StudentManager.Patrols.List[StudentID].localPosition = new Vector3(0f, 0f, 0f);
						VomitPhase = -1;
						Indoors = true;
						Spawned = true;
						Calm = true;
						if (ShoeRemoval.Locker == null)
						{
							ShoeRemoval.Start();
						}
						ShoeRemoval.PutOnShoes();
						FollowTarget = StudentManager.Students[11];
						FollowTarget.Follower = this;
						IdleAnim = "f02_idleGirly_00";
						WalkAnim = "f02_walkGirly_00";
						PatrolAnim = "f02_stretch_00";
						OriginalIdleAnim = IdleAnim;
						if (GameGlobals.RivalEliminationID == 4)
						{
							StudentManager.LunchSpots.List[StudentID].position = StudentManager.AltFriendLunchSpot.position;
							StudentManager.LunchSpots.List[StudentID].eulerAngles = StudentManager.AltFriendLunchSpot.eulerAngles;
						}
					}
					else
					{
						Debug.Log("Due to the circumstances, we're changing Raibaru's destinations.");
						if (StudentManager.Students[11] == null || StudentGlobals.StudentSlave == 11 || GameGlobals.AlphabetMode || StudentManager.MissionMode)
						{
							RaibaruOsanaDeathScheduleChanges();
						}
						else if ((float)StudentGlobals.GetStudentReputation(10) <= -33.33333f)
						{
							ShoeRemoval.PutOnShoes();
							ScheduleBlock obj9 = ScheduleBlocks[2];
							obj9.destination = "ShameSpot";
							obj9.action = "Shamed";
							obj9.time = 8f;
							ScheduleBlock obj10 = ScheduleBlocks[4];
							obj10.destination = "Seat";
							obj10.action = "Sit";
							IdleAnim = BulliedIdleAnim;
							WalkAnim = BulliedWalkAnim;
							OriginalIdleAnim = IdleAnim;
						}
						else if (DatingGlobals.SuitorProgress == 2)
						{
							ScheduleBlock obj11 = ScheduleBlocks[2];
							obj11.destination = "Peek";
							obj11.action = "Peek";
							obj11.time = 8f;
							ScheduleBlock obj12 = ScheduleBlocks[4];
							obj12.destination = "LunchSpot";
							obj12.action = "Eat";
						}
						RaibaruStopsFollowingOsana();
						TargetDistance = 0.5f;
					}
					PhotoPatience = 0f;
					OriginalWalkAnim = WalkAnim;
					CharacterAnimation["f02_nervousLeftRight_00"].speed = 0.5f;
				}
				else if (StudentID == 11)
				{
					SmartPhone.transform.localPosition = new Vector3(-0.0075f, -0.0025f, -0.0075f);
					SmartPhone.transform.localEulerAngles = new Vector3(5f, -150f, 170f);
					SmartPhone.GetComponent<Renderer>().material.mainTexture = OsanaPhoneTexture;
					IdleAnim = "f02_tsunIdle_00";
					WalkAnim = "f02_tsunWalk_00";
					TaskAnims[0] = "f02_Task33_Line0";
					TaskAnims[1] = "f02_Task33_Line1";
					TaskAnims[2] = "f02_Task33_Line2";
					TaskAnims[3] = "f02_Task33_Line3";
					TaskAnims[4] = "f02_Task33_Line4";
					TaskAnims[5] = "f02_Task33_Line5";
					LovestruckTarget = 1;
					if (GameGlobals.RivalEliminationID == 4)
					{
						StudentManager.LunchSpots.List[StudentID].position = StudentManager.AltRivalLunchSpot.position;
						StudentManager.LunchSpots.List[StudentID].eulerAngles = StudentManager.AltRivalLunchSpot.eulerAngles;
					}
					if (StudentManager.Students[10] == null)
					{
						Debug.Log("Raibaru has been killed/arrested/vanished, so Osana's schedule has changed.");
						ScheduleBlock obj13 = ScheduleBlocks[2];
						obj13.destination = "Mourn";
						obj13.action = "Mourn";
						ScheduleBlock obj14 = ScheduleBlocks[7];
						obj14.destination = "Mourn";
						obj14.action = "Mourn";
						IdleAnim = BulliedIdleAnim;
						WalkAnim = BulliedWalkAnim;
					}
					else if (PlayerGlobals.RaibaruLoner || GameGlobals.AlphabetMode || StudentManager.MissionMode)
					{
						ScheduleBlock obj15 = ScheduleBlocks[2];
						obj15.destination = "Patrol";
						obj15.action = "Patrol";
						ScheduleBlock obj16 = ScheduleBlocks[7];
						obj16.destination = "Patrol";
						obj16.action = "Patrol";
						PatrolAnim = "f02_pondering_00";
						if (StudentManager.MissionMode)
						{
							OriginalPersona = PersonaType.Loner;
							Persona = PersonaType.Loner;
						}
					}
					OriginalWalkAnim = WalkAnim;
				}
				else if (StudentID == 12)
				{
					SmartPhone.GetComponent<Renderer>().material.mainTexture = Cosmetic.SmartphoneTextures[StudentID];
					if (!ClubGlobals.GetClubClosed(ClubType.Cooking))
					{
						Armband.SetActive(value: true);
						ClubLeader = true;
					}
					OriginalIdleAnim = "f02_idleGirly_00";
					OriginalWalkAnim = "f02_walkGirly_00";
					IdleAnim = "f02_idleGirly_00";
					WalkAnim = "f02_walkGirly_00";
					CanTalk = false;
					Distracted = true;
				}
				else if (StudentID != 21)
				{
					if (StudentID == 24 && StudentID == 25)
					{
						IdleAnim = "f02_idleGirly_00";
						WalkAnim = "f02_walkGirly_00";
					}
					else if (StudentID == 26)
					{
						IdleAnim = "idleHaughty_00";
						WalkAnim = "walkHaughty_00";
					}
					else if (StudentID == 27)
					{
						IdleAnim = "idleConfident_00";
						WalkAnim = "walkConfident_00";
					}
					else if (StudentID == 29)
					{
						IdleAnim = "f02_idleElegant_00";
						WalkAnim = "f02_walkElegant_00";
					}
					else if (StudentID == 30)
					{
						SmartPhone.GetComponent<Renderer>().material.mainTexture = KokonaPhoneTexture;
					}
					else if (StudentID == 31)
					{
						IdleAnim = BulliedIdleAnim;
						WalkAnim = BulliedWalkAnim;
					}
					else if (StudentID == 34 || StudentID == 35)
					{
						IdleAnim = "f02_idleShort_00";
						WalkAnim = "f02_newWalk_00";
						if (Paranoia > 1.66666f)
						{
							IdleAnim = ParanoidAnim;
							WalkAnim = ParanoidWalkAnim;
						}
					}
					else if (StudentID == 36)
					{
						if (TaskGlobals.GetTaskStatus(36) < 3)
						{
							IdleAnim = "slouchIdle_00";
							WalkAnim = "slouchWalk_00";
							ClubAnim = "slouchGaming_00";
						}
						else
						{
							IdleAnim = "properIdle_00";
							WalkAnim = "properWalk_00";
							ClubAnim = "properGaming_00";
						}
						if (Paranoia > 1.66666f)
						{
							IdleAnim = ParanoidAnim;
							WalkAnim = ParanoidWalkAnim;
						}
						if (StudentManager.MissionMode)
						{
							ScheduleBlock obj17 = ScheduleBlocks[4];
							obj17.destination = "LunchSpot";
							obj17.action = "Eat";
						}
					}
					else if (StudentID == 39)
					{
						SmartPhone.GetComponent<Renderer>().material.mainTexture = MidoriPhoneTexture;
						PatrolAnim = "f02_midoriTexting_00";
					}
					else if (StudentID == 51)
					{
						IdleAnim = "f02_idleConfident_01";
						WalkAnim = "f02_walkConfident_01";
						if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
						{
							IdleAnim = BulliedIdleAnim;
							WalkAnim = BulliedWalkAnim;
							CameraAnims = CowardAnims;
							OriginalPersona = PersonaType.Loner;
							Persona = PersonaType.Loner;
							if (!SchoolGlobals.RoofFence)
							{
								ScheduleBlock obj18 = ScheduleBlocks[2];
								obj18.destination = "Sulk";
								obj18.action = "Sulk";
								ScheduleBlock obj19 = ScheduleBlocks[4];
								obj19.destination = "Sulk";
								obj19.action = "Sulk";
								ScheduleBlock obj20 = ScheduleBlocks[7];
								obj20.destination = "Sulk";
								obj20.action = "Sulk";
								ScheduleBlock obj21 = ScheduleBlocks[8];
								obj21.destination = "Sulk";
								obj21.action = "Sulk";
							}
							else
							{
								ScheduleBlock obj22 = ScheduleBlocks[2];
								obj22.destination = "Seat";
								obj22.action = "Sit";
								ScheduleBlock obj23 = ScheduleBlocks[4];
								obj23.destination = "Seat";
								obj23.action = "Sit";
								ScheduleBlock obj24 = ScheduleBlocks[7];
								obj24.destination = "Seat";
								obj24.action = "Sit";
								ScheduleBlock obj25 = ScheduleBlocks[8];
								obj25.destination = "Seat";
								obj25.action = "Sit";
							}
						}
						if (StudentManager.MissionMode)
						{
							ScheduleBlock obj26 = ScheduleBlocks[4];
							obj26.destination = "LunchSpot";
							obj26.action = "Eat";
						}
					}
					else if (StudentID == 56)
					{
						IdleAnim = "idleConfident_00";
						WalkAnim = "walkConfident_00";
						SleuthID = 1;
					}
					else if (StudentID == 57)
					{
						IdleAnim = "idleChill_01";
						WalkAnim = "walkChill_01";
						SleuthID = 20;
					}
					else if (StudentID == 58)
					{
						IdleAnim = "idleChill_00";
						WalkAnim = "walkChill_00";
						SleuthID = 40;
					}
					else if (StudentID == 59)
					{
						IdleAnim = "f02_idleGraceful_00";
						WalkAnim = "f02_walkGraceful_00";
						SleuthID = 60;
					}
					else if (StudentID == 60)
					{
						IdleAnim = "f02_idleScholarly_00";
						WalkAnim = "f02_walkScholarly_00";
						CameraAnims = HeroAnims;
						SleuthID = 80;
					}
					else if (StudentID == 61)
					{
						IdleAnim = "scienceIdle_00";
						WalkAnim = "scienceWalk_00";
						OriginalWalkAnim = "scienceWalk_00";
					}
					else if (StudentID == 62)
					{
						IdleAnim = "idleFrown_00";
						WalkAnim = "walkFrown_00";
						if (Paranoia > 1.66666f)
						{
							IdleAnim = ParanoidAnim;
							WalkAnim = ParanoidWalkAnim;
						}
					}
					else if (StudentID == 64 || StudentID == 65)
					{
						IdleAnim = "f02_idleShort_00";
						WalkAnim = "f02_newWalk_00";
						if (Paranoia > 1.66666f)
						{
							IdleAnim = ParanoidAnim;
							WalkAnim = ParanoidWalkAnim;
						}
					}
					else if (StudentID == 66)
					{
						IdleAnim = "pose_03";
						OriginalWalkAnim = "walkConfident_00";
						WalkAnim = "walkConfident_00";
						ClubThreshold = 100f;
					}
					else if (StudentID == 69)
					{
						IdleAnim = "idleFrown_00";
						WalkAnim = "walkFrown_00";
						if (Paranoia > 1.66666f)
						{
							IdleAnim = ParanoidAnim;
							WalkAnim = ParanoidWalkAnim;
						}
					}
					else if (StudentID == 71)
					{
						IdleAnim = "f02_idleGirly_00";
						WalkAnim = "f02_walkGirly_00";
						if (!PickPocket.gameObject.transform.parent.gameObject.activeInHierarchy)
						{
							PickPocket.gameObject.transform.parent.gameObject.SetActive(value: true);
						}
					}
				}
				if ((StudentID == 6 || StudentID == 11) && DatingGlobals.SuitorProgress == 2)
				{
					Partner = ((StudentID == 11) ? StudentManager.Students[6] : StudentManager.Students[11]);
					ScheduleBlock obj27 = ScheduleBlocks[2];
					obj27.destination = "Cuddle";
					obj27.action = "Cuddle";
					ScheduleBlock obj28 = ScheduleBlocks[4];
					obj28.destination = "Cuddle";
					obj28.action = "Cuddle";
					ScheduleBlock obj29 = ScheduleBlocks[6];
					obj29.destination = "Locker";
					obj29.action = "Shoes";
					ScheduleBlock obj30 = ScheduleBlocks[7];
					obj30.destination = "Exit";
					obj30.action = "Exit";
				}
				if (Rival)
				{
					if (StudentID > 11 && StudentID < 21)
					{
						ScheduleBlock scheduleBlock = ScheduleBlocks[2];
						OriginalDestination = scheduleBlock.destination;
						OriginalAction = scheduleBlock.action;
						scheduleBlock.destination = "Seat";
						scheduleBlock.action = "PlaceBag";
						BookBag.SetActive(value: true);
					}
					LovestruckTarget = 1;
				}
			}
			else
			{
				if (StudentID == 1)
				{
					MapMarker.gameObject.SetActive(value: true);
					MapMarker.gameObject.GetComponent<Renderer>().material.mainTexture = JokichiHead;
				}
				BookRenderer.material.mainTexture = RedBookTexture;
				Phoneless = true;
				if (!Male)
				{
					PatrolAnim = "f02_thinking_00";
				}
				if (Rival)
				{
					if (StudentID > 10 && StudentID < 21)
					{
						ScheduleBlock scheduleBlock2 = ScheduleBlocks[2];
						OriginalDestination = scheduleBlock2.destination;
						OriginalAction = scheduleBlock2.action;
						scheduleBlock2.destination = "Seat";
						scheduleBlock2.action = "PlaceBag";
						BookBag.SetActive(value: true);
					}
					LovestruckTarget = 1;
				}
				if (!StudentManager.CustomMode)
				{
					if (StudentID == 11)
					{
						IdleAnim = "f02_idleGirly_00";
						WalkAnim = "f02_walkGirly_00";
						if (!Rival)
						{
							Persona = PersonaType.LandlineUser;
						}
					}
					else if (StudentID == 12)
					{
						CharacterAnimation["f02_startFire_00"].speed = 2f;
						IdleAnim = "f02_idleChill_00";
						WalkAnim = "f02_walkChill_00";
						GameAnim = "f02_lookLeftRight_00";
						PyroUrge = true;
						PyroLimit = 60f;
						if (StudentManager.Week > 2)
						{
							PyroLimit = 5f;
						}
						if (!Rival)
						{
							Persona = PersonaType.LandlineUser;
						}
					}
					else if (StudentID == 13)
					{
						IdleAnim = "f02_idleShy_00";
						WalkAnim = "f02_walkShy_00";
						WaveAnim = "f02_casualWave_04";
						if (!Rival)
						{
							Persona = PersonaType.Coward;
						}
					}
					else if (StudentID == 14)
					{
						IdleAnim = "f02_idleLively_00";
						WalkAnim = "f02_walkLively_00";
						ClubAnim = "f02_stretch_00";
						if (!Rival)
						{
							Persona = PersonaType.Heroic;
						}
					}
					else if (StudentID == 15)
					{
						IdleAnim = "f02_idleHaughty_00";
						WalkAnim = "f02_walkHaughty_00";
						if (!Rival)
						{
							Persona = PersonaType.Loner;
						}
					}
					else if (StudentID == 16)
					{
						IdleAnim = "f02_idleConfident_01";
						WalkAnim = "f02_walkConfident_01";
						ClubAnim = "f02_vocalSingA_00";
						if (DateGlobals.Week != 6)
						{
							ScheduleBlock obj31 = ScheduleBlocks[2];
							obj31.destination = "Lyrics";
							obj31.action = "Lyrics";
							ScheduleBlock obj32 = ScheduleBlocks[7];
							obj32.destination = "Lyrics";
							obj32.action = "Lyrics";
						}
						if (!Rival)
						{
							Persona = PersonaType.LandlineUser;
						}
					}
					else if (StudentID == 17)
					{
						IdleAnim = "f02_idleCouncilGrace_00";
						WalkAnim = "f02_walkCouncilGrace_00";
						MyRenderer.SetBlendShapeWeight(0, 100f);
						if (!Rival)
						{
							Persona = PersonaType.TeachersPet;
						}
					}
					else if (StudentID == 18)
					{
						IdleAnim = "f02_idleGraceful_00";
						WalkAnim = "f02_walkGraceful_00";
						MyRenderer.SetBlendShapeWeight(0, 100f);
						if (!Rival)
						{
							Persona = PersonaType.TeachersPet;
						}
					}
					else if (StudentID == 19)
					{
						IdleAnim = "f02_idleElegant_00";
						WalkAnim = "f02_walkElegant_00";
						OriginalWalkAnim = "f02_walkElegant_00";
						OriginalOriginalWalkAnim = "f02_walkElegant_00";
						ClubAnim = GravureAnims[0];
						if (!Rival)
						{
							Persona = PersonaType.LandlineUser;
						}
					}
					else if (StudentID == 20)
					{
						IdleAnim = "f02_idleConfident_00";
						WalkAnim = "f02_walkConfident_00";
						Shovey = !StudentManager.RivalEliminated;
						if (!Rival)
						{
							Persona = PersonaType.Heroic;
						}
						Suffix = "Strict";
						IdleAnim = "f02_idleCouncil" + Suffix + "_00";
						WalkAnim = "f02_walkCouncil" + Suffix + "_00";
						ShoveAnim = "f02_pushCouncil" + Suffix + "_00";
						PatrolAnim = "f02_scanCouncil" + Suffix + "_00";
						RelaxAnim = "f02_relaxCouncil" + Suffix + "_00";
						SprayAnim = "f02_sprayCouncil" + Suffix + "_00";
						BreakUpAnim = "f02_stopCouncil" + Suffix + "_00";
						PickUpAnim = "f02_teacherPickUp_00";
					}
					else if (StudentID == 36)
					{
						BecomeSleuth();
						if (StudentManager.Atmosphere > 0.8f)
						{
							CharacterAnimation["f02_smile_00"].layer = 1;
							CharacterAnimation.Play("f02_smile_00");
							CharacterAnimation["f02_smile_00"].weight = 1f;
						}
					}
					if (StudentID > 35 && StudentID < 41 && StudentManager.MissionMode)
					{
						ScheduleBlock obj33 = ScheduleBlocks[4];
						obj33.destination = "LunchSpot";
						obj33.action = "Eat";
					}
				}
				if (StudentID == 71 && Club == ClubType.Gardening && !PickPocket.gameObject.transform.parent.gameObject.activeInHierarchy)
				{
					PickPocket.gameObject.transform.parent.gameObject.SetActive(value: true);
				}
				if (StudentID == 66)
				{
					ClubThreshold = 100f;
				}
				if (StudentID > 10 && StudentID < 21)
				{
					OriginalPersona = Persona;
				}
				if (Club == ClubType.Delinquent)
				{
					if (Male)
					{
						CharacterAnimation[WalkAnim].speed += 0.01f * (float)(StudentID - 76);
					}
					else
					{
						Jaw.gameObject.name = Jaw.gameObject.name + "_RENAMED";
					}
				}
				if (StudentID == 20)
				{
					GuardID = 1;
				}
				else
				{
					GuardID = 20;
				}
			}
			OriginalWalkAnim = WalkAnim;
			if (StudentGlobals.GetStudentGrudge(StudentID))
			{
				if (Persona != PersonaType.Coward && Persona != PersonaType.Fragile && Persona != PersonaType.Evil && Club != ClubType.Delinquent)
				{
					CameraAnims = EvilAnims;
					Reputation.PendingRep -= 10f;
					PendingRep -= 10f;
					for (ID = 0; ID < Outlines.Length; ID++)
					{
						if (Outlines[ID] != null)
						{
							Outlines[ID].color = new Color(1f, 1f, 0f, 1f);
						}
					}
				}
				Grudge = true;
				CameraAnims = EvilAnims;
			}
			if (!StudentManager.MissionMode && Rival)
			{
				for (ID = 0; ID < Outlines.Length; ID++)
				{
					if (Outlines[ID] != null)
					{
						Outlines[ID].color = new Color(10f, 0f, 0f, 1f);
					}
				}
			}
			if (Persona == PersonaType.Sleuth)
			{
				if (SchoolGlobals.SchoolAtmosphere <= 0.8f || Grudge)
				{
					bool flag = false;
					if (StudentManager.Eighties && ClubLeader)
					{
						Debug.Log("Student #" + StudentID + " is a club leader, so they shouldn't become a Sleuth...");
						flag = true;
					}
					if (!flag)
					{
						BecomeSleuth();
					}
				}
				else if (SchoolGlobals.SchoolAtmosphere <= 0.9f)
				{
					WalkAnim = ParanoidWalkAnim;
					CameraAnims = HeroAnims;
				}
			}
			if (!Slave)
			{
				if (StudentManager.Bullies > 1)
				{
					if (StudentID == 81 || StudentID == 83 || StudentID == 85)
					{
						if (Persona != PersonaType.Coward)
						{
							Pathfinding.canSearch = false;
							Pathfinding.canMove = false;
							Paired = true;
							CharacterAnimation["f02_walkTalk_00"].time += StudentID - 81;
							WalkAnim = "f02_walkTalk_00";
							SpeechLines.Play();
						}
					}
					else if (StudentID == 82 || StudentID == 84)
					{
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						Paired = true;
						CharacterAnimation["f02_walkTalk_01"].time += StudentID - 81;
						WalkAnim = "f02_walkTalk_01";
						SpeechLines.Play();
					}
				}
				if (Club == ClubType.Delinquent)
				{
					if (Friend)
					{
						RespectEarned = true;
					}
					if (CounselorGlobals.WeaponsBanned == 0)
					{
						MyWeapon = Yandere.WeaponManager.DelinquentWeapons[StudentID - 75];
						MyWeapon.transform.parent = WeaponBagParent;
						MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
						MyWeapon.FingerprintID = StudentID;
						MyWeapon.MyCollider.enabled = false;
						WeaponBag.SetActive(value: true);
					}
					else
					{
						OriginalPersona = PersonaType.Heroic;
						Persona = PersonaType.Heroic;
					}
					string text = "";
					if (!Male)
					{
						text = "f02_";
					}
					ScaredAnim = text + "delinquentCombatIdle_00";
					LeanAnim = "delinquentConcern_00";
					ShoveAnim = text + "pushTough_00";
					WalkAnim = text + "walkTough_00";
					IdleAnim = text + "idleTough_00";
					SpeechLines = DelinquentSpeechLines;
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					Paired = true;
					TaskAnims[0] = text + "delinquentTalk_04";
					TaskAnims[1] = text + "delinquentTalk_01";
					TaskAnims[2] = text + "delinquentTalk_02";
					TaskAnims[3] = text + "delinquentTalk_03";
					TaskAnims[4] = text + "delinquentTalk_00";
					TaskAnims[5] = text + "delinquentTalk_03";
					WaveAnim = "f02_casualWave_04";
				}
			}
			else
			{
				Club = ClubType.None;
			}
			if (Rival)
			{
				RivalPrefix = "Rival ";
				if (DateGlobals.Weekday == DayOfWeek.Friday)
				{
					ScheduleBlocks[7].time = 17f;
				}
			}
			if (!Teacher && Name != "Random")
			{
				StudentManager.CleaningManager.GetRole(StudentID);
				CleaningSpot = StudentManager.CleaningManager.Spot;
				CleaningRole = StudentManager.CleaningManager.Role;
			}
			if (Club == ClubType.Cooking)
			{
				SleuthID = (StudentID - 21) * 20;
				ClubAnim = PrepareFoodAnim;
				if (StudentID > 11)
				{
					if (StudentID == 12)
					{
						ClubMemberID = 0;
					}
					else
					{
						ClubMemberID = StudentID - 20;
					}
					MyPlate = StudentManager.Plates[ClubMemberID];
					OriginalPlatePosition = MyPlate.position;
					OriginalPlateRotation = MyPlate.rotation;
				}
				if (!StudentManager.EmptyDemon && !StudentManager.TutorialActive)
				{
					ApronAttacher.enabled = true;
				}
			}
			else if (Club == ClubType.Drama)
			{
				if (StudentID == 26)
				{
					if (Male)
					{
						ClubAnim = "teaching_00";
					}
					else
					{
						ClubAnim = "f02_teaching_00";
					}
				}
				else if (Male)
				{
					ClubAnim = "sit_00";
				}
				else
				{
					ClubAnim = "f02_sit_00";
				}
				OriginalClubAnim = ClubAnim;
			}
			else if (Club == ClubType.Occult)
			{
				WaveAnim = "f02_casualWave_04";
				CharacterAnimation[PatrolAnim].speed = 0.2f;
			}
			else if (Club == ClubType.Gaming)
			{
				MiyukiGameScreen.SetActive(value: true);
				ClubMemberID = StudentID - 35;
				if (StudentID > 36)
				{
					ClubAnim = GameAnim;
				}
				ActivityAnim = GameAnim;
			}
			else if (Club == ClubType.Art)
			{
				ChangingBooth = StudentManager.ChangingBooths[4];
				ActivityAnim = PaintAnim;
				Attacher.ArtClub = true;
				ClubAnim = PaintAnim;
				DressCode = true;
				if (StudentManager.Week == 1 && DateGlobals.Weekday == DayOfWeek.Friday)
				{
					ScheduleBlock obj34 = ScheduleBlocks[7];
					obj34.destination = "Paint";
					obj34.action = "Paint";
					VisionDistance += 5f;
				}
				ClubMemberID = StudentID - 40;
				Painting = StudentManager.FridayPaintings[ClubMemberID];
				GetDestinations();
			}
			else if (OriginalClub == ClubType.LightMusic)
			{
				ClubMemberID = StudentID - 50;
				InstrumentBag[ClubMemberID].SetActive(value: true);
				if (StudentID == 51)
				{
					if (!Male)
					{
						ClubAnim = "f02_practiceGuitar_01";
					}
					else
					{
						ClubAnim = "practiceGuitar_01";
					}
					if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
					{
						InstrumentBag[ClubMemberID].SetActive(value: false);
					}
				}
				else if (StudentID == 52 || StudentID == 53)
				{
					if (Male)
					{
						ClubAnim = "practiceGuitar_00";
					}
					else
					{
						ClubAnim = "f02_practiceGuitar_00";
					}
				}
				else if (StudentID == 54)
				{
					ClubAnim = "f02_practiceDrums_00";
					Instruments[4] = StudentManager.DrumSet;
					if (StudentManager.Eighties)
					{
						InstrumentBag[ClubMemberID].GetComponent<Renderer>().enabled = false;
						Instruments[ClubMemberID].GetComponent<Renderer>().enabled = false;
					}
				}
				else if (StudentID == 55)
				{
					ClubAnim = "f02_practiceKeytar_00";
				}
				if (StudentManager.Eighties && StudentManager.Students[16] != null && !GameGlobals.CustomMode && DateGlobals.Week == 6)
				{
					Instruments[ClubMemberID].GetComponent<AudioSource>().enabled = false;
					Instruments[ClubMemberID].GetComponent<AudioSource>().volume = 0f;
					if (StudentID == 52)
					{
						ClubAnim = "f02_guitarPlayA_00";
					}
					else if (StudentID == 53)
					{
						ClubAnim = "f02_guitarPlayB_00";
					}
					else if (StudentID == 54)
					{
						ClubAnim = "f02_drumsPlay_00";
					}
					else if (StudentID == 55)
					{
						ClubAnim = "f02_keysPlay_00";
					}
				}
			}
			else if (OriginalClub == ClubType.MartialArts)
			{
				ChangingBooth = StudentManager.ChangingBooths[6];
				DressCode = true;
				if (StudentID == 46)
				{
					if (Male)
					{
						IdleAnim = "pose_03";
						ClubAnim = "pose_03";
					}
					else
					{
						ClubAnim = IdleAnim;
					}
					ActivityAnim = IdleAnim;
				}
				else if (StudentID == 47)
				{
					GetNewAnimation = true;
					if (Male)
					{
						ClubAnim = "idle_20";
						ActivityAnim = "kick_24";
					}
					else
					{
						ClubAnim = "f02_idle_20";
						ActivityAnim = "f02_kick_23";
					}
				}
				else if (StudentID == 48)
				{
					if (Male)
					{
						ClubAnim = "sit_04";
						ActivityAnim = "kick_24";
					}
					else
					{
						ClubAnim = "f02_sit_05";
						ActivityAnim = "f02_kick_23";
					}
				}
				else if (StudentID == 49)
				{
					GetNewAnimation = true;
					if (Male)
					{
						ClubAnim = "idle_20";
						ActivityAnim = "kick_24";
					}
					else
					{
						ClubAnim = "f02_idle_20";
						ActivityAnim = "f02_kick_23";
					}
				}
				else if (StudentID == 50)
				{
					if (Male)
					{
						ClubAnim = "sit_04";
						ActivityAnim = "kick_24";
					}
					else
					{
						ClubAnim = "f02_sit_05";
						ActivityAnim = "f02_kick_23";
					}
				}
				ClubMemberID = StudentID - 45;
			}
			else if (Club == ClubType.Science)
			{
				if (!StudentManager.Eighties)
				{
					ChangingBooth = StudentManager.ChangingBooths[8];
					Attacher.ScienceClub = true;
					DressCode = true;
					if (StudentID == 61)
					{
						ClubAnim = "scienceMad_00";
					}
					else if (StudentID == 62)
					{
						ClubAnim = "scienceTablet_00";
					}
					else if (StudentID == 63)
					{
						ClubAnim = "scienceChemistry_00";
					}
					else if (StudentID == 64)
					{
						ClubAnim = "f02_scienceLeg_00";
					}
					else if (StudentID == 65)
					{
						ClubAnim = "f02_scienceConsole_00";
					}
				}
				else if (Male)
				{
					ClubAnim = "scienceChemistry_00";
				}
				else
				{
					ClubAnim = "f02_scienceChemistry_00";
				}
				ClubMemberID = StudentID - 60;
			}
			else if (OriginalClub == ClubType.Sports)
			{
				if (Male)
				{
					ChangingBooth = StudentManager.ChangingBooths[9];
					ClubAnim = "stretch_00";
				}
				else
				{
					ChangingBooth = StudentManager.ChangingBooths[10];
					ClubAnim = "f02_stretch_00";
				}
				DressCode = true;
				ClubMemberID = StudentID - 65;
			}
			else if (OriginalClub == ClubType.Gardening)
			{
				if (!StudentManager.Eighties)
				{
					if (StudentID == 71)
					{
						PatrolAnim = "f02_thinking_00";
						ClubAnim = "f02_thinking_00";
						CharacterAnimation[PatrolAnim].speed = 0.9f;
					}
					else if (ClubGlobals.GetClubClosed(ClubType.Gardening))
					{
						ClubAnim = "f02_arrangeFlowers_00";
						WateringCan.SetActive(value: false);
					}
					else
					{
						ClubAnim = "f02_waterPlant_00";
						WateringCan.SetActive(value: true);
					}
				}
				else
				{
					if (Male)
					{
						PatrolAnim = "thinking_00";
						ClubAnim = "thinking_00";
					}
					else
					{
						PatrolAnim = "f02_thinking_00";
						ClubAnim = "f02_thinking_00";
					}
					CharacterAnimation[PatrolAnim].speed = 0.9f;
				}
			}
			else if (Club == ClubType.Newspaper)
			{
				if (StudentID == 36)
				{
					if (Male)
					{
						ClubAnim = "thinking_00";
					}
					else
					{
						ClubAnim = "f02_pondering_00";
					}
				}
				else if (Male)
				{
					PatrolAnim = "thinking_00";
					ClubAnim = "onComputer_00";
				}
				else
				{
					PatrolAnim = "f02_thinking_00";
					ClubAnim = "f02_onComputer_00";
				}
				OriginalClubAnim = ClubAnim;
			}
			if (OriginalClub != ClubType.Gaming)
			{
				Miyuki.gameObject.SetActive(value: false);
			}
			if (Cosmetic.Hairstyle == 20)
			{
				IdleAnim = "f02_tsunIdle_00";
			}
			GetDestinations();
			OriginalActions = new StudentActionType[Actions.Length];
			Array.Copy(Actions, OriginalActions, Actions.Length);
			if (AoT)
			{
				AttackOnTitan();
			}
			if (Slave)
			{
				PoolStairs = GameObject.Find("PoolStairs").GetComponent<Collider>();
				NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
				NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
				SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
				SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
				IdleAnim = BrokenAnim;
				WalkAnim = BrokenWalkAnim;
				RightEmptyEye.SetActive(value: true);
				LeftEmptyEye.SetActive(value: true);
				SmartPhone.SetActive(value: false);
				Distracted = true;
				Indoors = true;
				Safe = false;
				Shy = false;
				for (ID = 0; ID < ScheduleBlocks.Length; ID++)
				{
					ScheduleBlocks[ID].time = 0f;
				}
				if (FragileSlave)
				{
					HuntTarget = StudentManager.Students[StudentGlobals.FragileTarget];
				}
			}
			if (Spooky)
			{
				Spook();
			}
			Prompt.HideButton[0] = true;
			Prompt.HideButton[2] = true;
			for (ID = 0; ID < Ragdoll.AllRigidbodies.Length; ID++)
			{
				Ragdoll.AllRigidbodies[ID].isKinematic = true;
				Ragdoll.AllColliders[ID].enabled = false;
			}
			Ragdoll.AllColliders[10].enabled = true;
			if (StudentID == 1)
			{
				Yandere.Senpai = base.transform;
				Yandere.LookAt.target = Head;
				for (ID = 0; ID < Outlines.Length; ID++)
				{
					if (Outlines[ID] != null)
					{
						Outlines[ID].enabled = true;
						Outlines[ID].color = new Color(1f, 0f, 1f);
					}
				}
				Prompt.ButtonActive[0] = false;
				Prompt.ButtonActive[1] = false;
				Prompt.ButtonActive[2] = false;
				Prompt.ButtonActive[3] = false;
				if (StudentManager.MissionMode || GameGlobals.SenpaiMourning)
				{
					base.transform.position = Vector3.zero;
					base.gameObject.SetActive(value: false);
				}
			}
			else if (StudentManager.StudentPhotographed[StudentID] && !Rival)
			{
				TurnOutlinesGreen();
			}
			else
			{
				for (ID = 0; ID < Outlines.Length; ID++)
				{
					if (Outlines[ID] != null)
					{
						Outlines[ID].enabled = false;
					}
				}
			}
			if (StudentManager.MissionMode)
			{
				if (StudentID == 11)
				{
					for (ID = 0; ID < Outlines.Length; ID++)
					{
						if (Outlines[ID] != null)
						{
							Outlines[ID].enabled = false;
						}
					}
				}
				for (int i = 1; i < 11; i++)
				{
					if (PlayerPrefs.GetInt("MissionModeTarget" + i) != StudentID)
					{
						continue;
					}
					for (ID = 0; ID < Outlines.Length; ID++)
					{
						if (Outlines[ID] != null)
						{
							Outlines[ID].color = new Color(10f, 0f, 0f, 1f);
							Outlines[ID].enabled = true;
						}
					}
				}
			}
			PickRandomAnim();
			PickRandomSleuthAnim();
			Renderer component = Armband.GetComponent<Renderer>();
			if (Club != 0 && (StudentID == 21 || StudentID == 26 || StudentID == 31 || StudentID == 36 || StudentID == 41 || StudentID == 46 || StudentID == 51 || StudentID == 56 || StudentID == 61 || StudentID == 66 || StudentID == 71))
			{
				Armband.SetActive(value: true);
				ClubLeader = true;
				if (StudentID == 21 && StudentManager.Students[12] != null)
				{
					Armband.SetActive(value: false);
					ClubLeader = false;
				}
				if (StudentManager.EmptyDemon)
				{
					IdleAnim = OriginalIdleAnim;
					WalkAnim = OriginalOriginalWalkAnim;
					OriginalPersona = PersonaType.Evil;
					Persona = PersonaType.Evil;
					ScaredAnim = EvilWitnessAnim;
				}
			}
			if (!Teacher)
			{
				CurrentDestination = Destinations[Phase];
				Pathfinding.target = Destinations[Phase];
			}
			else
			{
				Indoors = true;
			}
			if (StudentID == 1 || StudentID == 4 || StudentID == 5 || StudentID == 11)
			{
				BookRenderer.material.mainTexture = RedBookTexture;
			}
			CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			if ((StudentManager.MissionMode && StudentID == MissionModeGlobals.MissionTarget) || (!StudentManager.MissionMode && Rival))
			{
				for (ID = 0; ID < Outlines.Length; ID++)
				{
					if (Outlines[ID] != null)
					{
						Outlines[ID].enabled = true;
						Outlines[ID].color = new Color(1f, 0f, 0f);
					}
				}
			}
			UnityEngine.Object.Destroy(MyRigidbody);
			Started = true;
			if (Club == ClubType.Council && !Slave)
			{
				if (GameGlobals.AlternateTimeline || GameGlobals.NoCouncilShove)
				{
					DoNotShove = true;
				}
				component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, 0f));
				Armband.SetActive(value: true);
				Indoors = true;
				Spawned = true;
				if (ShoeRemoval.Locker == null)
				{
					ShoeRemoval.Start();
				}
				ShoeRemoval.PutOnShoes();
				if (StudentID == 86)
				{
					Suffix = "Strict";
				}
				else if (StudentID == 87)
				{
					Suffix = "Casual";
				}
				else if (StudentID == 88)
				{
					Suffix = "Grace";
				}
				else if (StudentID == 89)
				{
					Suffix = "Edgy";
				}
				if (!StudentManager.Eighties || !Male)
				{
					IdleAnim = "f02_idleCouncil" + Suffix + "_00";
					WalkAnim = "f02_walkCouncil" + Suffix + "_00";
					ShoveAnim = "f02_pushCouncil" + Suffix + "_00";
					PatrolAnim = "f02_scanCouncil" + Suffix + "_00";
					RelaxAnim = "f02_relaxCouncil" + Suffix + "_00";
					SprayAnim = "f02_sprayCouncil" + Suffix + "_00";
					BreakUpAnim = "f02_stopCouncil" + Suffix + "_00";
					PickUpAnim = "f02_teacherPickUp_00";
					if (StudentID == 89)
					{
						MyController.radius = 0.04f;
					}
				}
				else
				{
					IdleAnim = idleAnim;
					BreakUpAnim = "delinquentTalk_03";
					GuardAnim = ReadyToFightAnim;
					RelaxAnim = "sit_00";
					if (StudentID == 86)
					{
						ShoveAnim = "coldPush_00";
					}
					else if (StudentID == 87)
					{
						ShoveAnim = "foreignPush_00";
					}
					else if (StudentID == 88)
					{
						ShoveAnim = "humblePush_00";
						CharacterAnimation["humblePush_00"].speed = 1.33333f;
					}
					else if (StudentID == 89)
					{
						RelaxAnim = "crossarms_00";
						ShoveAnim = "toughPush_00";
					}
				}
				ScaredAnim = ReadyToFightAnim;
				ParanoidAnim = GuardAnim;
				CameraAnims[1] = IdleAnim;
				CameraAnims[2] = IdleAnim;
				CameraAnims[3] = IdleAnim;
				ClubMemberID = StudentID - 85;
				VisionDistance *= 2f;
			}
			if (StudentID == 81 && StudentGlobals.GetStudentBroken(81))
			{
				Destinations[2] = StudentManager.BrokenSpot;
				Destinations[4] = StudentManager.BrokenSpot;
				Actions[2] = StudentActionType.Shamed;
				Actions[4] = StudentActionType.Shamed;
			}
		}
		UpdateAnimLayers();
		if (!Male)
		{
			if (StudentID == 40)
			{
				LongHair[0] = LongHair[2];
			}
			if (StudentID != 55 && StudentID != 40)
			{
				LongHair[0] = null;
				LongHair[1] = null;
				LongHair[2] = null;
			}
		}
		if (StudentID == 90)
		{
			PatrolAnim = "f02_nurseThink_00";
		}
		SetOriginalScheduleBlocks();
		if (StudentManager.Randomize)
		{
			OriginalPersona = PersonaType.Coward;
			Persona = PersonaType.Coward;
		}
		if (StudentManager.Atmosphere < 0.33333f && Teacher)
		{
			OriginalIdleAnim = "f02_idleShort_00";
			IdleAnim = "f02_idleShort_00";
			if (StudentID == 97)
			{
				OriginalIdleAnim = "f02_tsunIdle_00";
				IdleAnim = "f02_tsunIdle_00";
			}
		}
		if (Club != ClubType.Bully)
		{
			MiyukiGameScreen.SetActive(value: true);
			if (StudentID <= 35 || StudentID >= 41)
			{
				MiyukiGameScreen.GetComponent<Renderer>().material.mainTexture = SocialMediaTexture;
			}
			SmartPhone.transform.localPosition = new Vector3(0.02f, 0.01f, 0.025f);
			SmartPhone.transform.localEulerAngles = new Vector3(15f, -145f, 180f);
		}
		if (StudentManager.YandereLate || StudentManager.MissionMode)
		{
			Paired = false;
		}
		if (OriginalClub == ClubType.Occult || OriginalClub == ClubType.Delinquent || (!StudentManager.Eighties && StudentID == 4) || (!StudentManager.Eighties && StudentID == 36) || (!StudentManager.Eighties && StudentID == 41) || (!StudentManager.Eighties && StudentID == 42) || (!StudentManager.Eighties && StudentID == 66))
		{
			WaveAnim = "f02_casualWave_04";
		}
		if (StudentManager.CustomMode)
		{
			if (StudentManager.JSON.Misc.AnimSet[StudentID] < IdleAnims.Length)
			{
				IdleAnim = IdleAnims[StudentManager.JSON.Misc.AnimSet[StudentID]];
				WalkAnim = WalkAnims[StudentManager.JSON.Misc.AnimSet[StudentID]];
			}
			if (Slave)
			{
				IdleAnim = BrokenAnim;
				WalkAnim = BrokenWalkAnim;
			}
			idleAnim = IdleAnim;
			OriginalWalkAnim = WalkAnim;
			if (ClubAnim == "")
			{
				ClubAnim = ThinkAnim;
			}
			if (GuardAnim == "")
			{
				if (Male)
				{
					GuardAnim = "guardCorpse_00";
				}
				else
				{
					GuardAnim = "f02_guardCorpse_00";
				}
			}
			if (CustomPatrolAnim == "")
			{
				CustomPatrolAnim = ThinkAnim;
			}
			if (CustomHangoutAnim == "")
			{
				CustomHangoutAnim = ThinkAnim;
			}
			if (RelaxAnim == "")
			{
				RelaxAnim = ThinkAnim;
			}
		}
		for (int j = 1; j < 11; j++)
		{
			if (StudentID == StudentManager.SuitorIDs[j])
			{
				CuddlePartnerID = 1;
			}
		}
		if (Yandere.PauseScreen.MissionMode.YakuzaMode && Strength == 7)
		{
			Strength = 5;
		}
		CharacterAnimation.Sample();
	}

	private float GetPerceptionPercent(float distance)
	{
		float num = Mathf.Clamp01(distance / VisionDistance);
		return 1f - num * num;
	}

	private bool PointIsInFOV(Vector3 point)
	{
		Vector3 vector = new Vector3(base.transform.position.x, Eyes.transform.position.y, base.transform.position.z);
		Vector3 to = point - vector;
		float num = 90f;
		return Vector3.Angle(Head.transform.forward, to) <= num;
	}

	public bool SeenByYandere()
	{
		Debug.Log("A ''SeenByYandere'' check is occuring.");
		Debug.DrawLine(Yandere.transform.position + new Vector3(0f, 1f, 0f), base.transform.position + new Vector3(0f, 1f, 0f), Color.red);
		if (Physics.Linecast(Yandere.transform.position + new Vector3(0f, 1f, 0f), base.transform.position + new Vector3(0f, 1f, 0f), out var hitInfo, YandereCheckMask))
		{
			Debug.Log("Yandere-chan's raycast hit: " + hitInfo.collider.gameObject.name);
			if (hitInfo.collider.gameObject == Head.gameObject || hitInfo.collider.gameObject == base.gameObject)
			{
				return true;
			}
		}
		return false;
	}

	public bool CanSeeObject(GameObject obj, Vector3 targetPoint, int[] layers, int mask)
	{
		Vector3 vector = new Vector3(base.transform.position.x, Eyes.transform.position.y, base.transform.position.z);
		Vector3 vector2 = targetPoint - vector;
		if (PointIsInFOV(targetPoint))
		{
			float num = VisionDistance;
			if (obj == Yandere.gameObject)
			{
				num += VisionBonus;
			}
			float num2 = num * num;
			if (vector2.sqrMagnitude <= num2)
			{
				Debug.DrawLine(vector, targetPoint, Color.green);
				if (Physics.Linecast(vector, targetPoint, out var hitInfo, mask) && (hitInfo.collider.gameObject == obj || hitInfo.collider.gameObject.transform.root.gameObject == obj || hitInfo.transform.root.gameObject == obj.transform.root.gameObject))
				{
					foreach (int num3 in layers)
					{
						if (hitInfo.collider.gameObject.layer == num3)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	public bool CanSeeObject(GameObject obj, Vector3 targetPoint)
	{
		if (!Blind)
		{
			Vector3 vector = new Vector3(base.transform.position.x, Eyes.transform.position.y, base.transform.position.z);
			Vector3 vector2 = targetPoint - vector;
			float num = VisionDistance;
			if (obj == Yandere.gameObject)
			{
				num += VisionBonus;
			}
			float num2 = num * num;
			bool num3 = PointIsInFOV(targetPoint);
			bool flag = vector2.sqrMagnitude <= num2;
			if (num3 && flag && Physics.Linecast(vector, targetPoint, out var hitInfo, Mask) && hitInfo.collider.gameObject == obj)
			{
				return true;
			}
		}
		return false;
	}

	public bool CanSeeObject(GameObject obj)
	{
		return CanSeeObject(obj, obj.transform.position);
	}

	private void Update()
	{
		if (!Stop)
		{
			DistanceToPlayer = Vector3.Distance(base.transform.position, Yandere.transform.position);
			UpdateRoutine();
			UpdateDetectionMarker();
			if (Dying)
			{
				UpdateDying();
				if (Burning)
				{
					UpdateBurning();
				}
			}
			else
			{
				if (DistanceToPlayer <= 2f)
				{
					UpdateTalkInput();
				}
				UpdateVision();
				if (Pushed)
				{
					UpdatePushed();
				}
				else if (Drowned)
				{
					UpdateDrowned();
				}
				else if (WitnessedMurder)
				{
					UpdateWitnessedMurder();
				}
				else if (Alarmed)
				{
					UpdateAlarmed();
				}
				else if (TurnOffRadio)
				{
					UpdateTurningOffRadio();
				}
				else if (Confessing)
				{
					UpdateConfessing();
				}
				else if (Vomiting)
				{
					UpdateVomiting();
				}
				else if (Splashed)
				{
					UpdateSplashed();
				}
			}
			UpdateMisc();
		}
		else
		{
			UpdateStop();
		}
	}

	private void UpdateStop()
	{
		if (StudentManager.Pose)
		{
			DistanceToPlayer = Vector3.Distance(base.transform.position, Yandere.transform.position);
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Pose();
			}
		}
		else if (!ClubActivity)
		{
			if (!Yandere.Talking)
			{
				if (Yandere.Sprayed)
				{
					CharacterAnimation.CrossFade(ScaredAnim);
				}
				if (Yandere.Noticed || StudentManager.YandereDying)
				{
					targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
					if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 1f)
					{
						MyController.Move(base.transform.forward * (Time.deltaTime * -1f));
					}
					if (Yandere.Attacking && Yandere.TargetStudent != null)
					{
						targetRotation = Quaternion.LookRotation(new Vector3(Yandere.TargetStudent.Hips.transform.position.x, base.transform.position.y, Yandere.TargetStudent.Hips.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
						if (Vector3.Distance(base.transform.position, Yandere.TargetStudent.transform.position) < 2f)
						{
							MyController.Move(base.transform.forward * (Time.deltaTime * -1f));
						}
					}
				}
			}
		}
		else if (Police.Darkness.color.a < 1f)
		{
			if (Club == ClubType.Cooking)
			{
				CharacterAnimation[SocialSitAnim].layer = 99;
				CharacterAnimation.Play(SocialSitAnim);
				CharacterAnimation[SocialSitAnim].weight = 1f;
				SmartPhone.SetActive(value: false);
				SpeechLines.Play();
				CharacterAnimation.CrossFade(RandomAnim);
				if (CharacterAnimation[RandomAnim].time >= CharacterAnimation[RandomAnim].length)
				{
					PickRandomAnim();
				}
			}
			else if (Club == ClubType.MartialArts)
			{
				CharacterAnimation.enabled = true;
				CharacterAnimation.Play(ActivityAnim);
				AudioSource component = GetComponent<AudioSource>();
				if (!Male)
				{
					if (CharacterAnimation["f02_kick_23"].time > 1f)
					{
						if (!PlayingAudio)
						{
							component.clip = FemaleAttacks[UnityEngine.Random.Range(0, FemaleAttacks.Length)];
							component.Play();
							PlayingAudio = true;
						}
						if (CharacterAnimation["f02_kick_23"].time >= CharacterAnimation["f02_kick_23"].length)
						{
							CharacterAnimation["f02_kick_23"].time = 0f;
							PlayingAudio = false;
						}
					}
				}
				else if (CharacterAnimation["kick_24"].time > 1f)
				{
					if (!PlayingAudio)
					{
						component.clip = MaleAttacks[UnityEngine.Random.Range(0, MaleAttacks.Length)];
						component.Play();
						PlayingAudio = true;
					}
					if (CharacterAnimation["kick_24"].time >= CharacterAnimation["kick_24"].length)
					{
						CharacterAnimation["kick_24"].time = 0f;
						PlayingAudio = false;
					}
				}
			}
			else if (Club == ClubType.Drama)
			{
				Stop = false;
			}
			else if (Club == ClubType.Photography)
			{
				CharacterAnimation.CrossFade(RandomSleuthAnim);
				if (CharacterAnimation[RandomSleuthAnim].time >= CharacterAnimation[RandomSleuthAnim].length)
				{
					PickRandomSleuthAnim();
				}
			}
			else if (Club == ClubType.Art)
			{
				CharacterAnimation.Play(ActivityAnim);
				Paintbrush.SetActive(value: true);
				Palette.SetActive(value: true);
			}
			else if (Club == ClubType.Science)
			{
				CharacterAnimation.Play(ClubAnim);
				if (!StudentManager.Eighties)
				{
					if (StudentID == 62)
					{
						ScienceProps[0].SetActive(value: true);
					}
					else if (StudentID == 63)
					{
						ScienceProps[1].SetActive(value: true);
						ScienceProps[2].SetActive(value: true);
					}
					else if (StudentID == 64)
					{
						ScienceProps[0].SetActive(value: true);
					}
				}
				else
				{
					if (!Male && !ScienceProps[1].activeInHierarchy)
					{
						Debug.Log("Supposedly straightening skirt.");
						CharacterAnimation.Play("f02_straightenSkirt_00");
					}
					ScienceProps[1].SetActive(value: true);
					ScienceProps[2].SetActive(value: true);
				}
			}
			else if (Club == ClubType.Sports)
			{
				Stop = false;
			}
			else if (Club == ClubType.Gardening)
			{
				CharacterAnimation.Play(ClubAnim);
				Stop = false;
			}
			else if (Club == ClubType.Gaming)
			{
				CharacterAnimation.CrossFade(ClubAnim);
			}
			else if (Club == ClubType.Newspaper)
			{
				CharacterAnimation.enabled = true;
				CharacterAnimation.CrossFade(ClubAnim);
			}
		}
		Alarm = Mathf.MoveTowards(Alarm, 0f, Time.deltaTime);
		UpdateDetectionMarker();
	}

	private void UpdateRoutine()
	{
		if (Routine)
		{
			IgnoreFoodTimer -= Time.deltaTime;
			if (CurrentDestination != null)
			{
				DistanceToDestination = Vector3.Distance(base.transform.position, CurrentDestination.position);
			}
			if (StalkerFleeing)
			{
				if (Actions[Phase] == StudentActionType.Stalk && DistanceToPlayer > 10f)
				{
					Pathfinding.target = Yandere.transform;
					CurrentDestination = Yandere.transform;
					StalkerFleeing = false;
					Pathfinding.speed = WalkSpeed;
				}
			}
			else if (Actions[Phase] == StudentActionType.Stalk)
			{
				TargetDistance = 10f;
				if (DistanceToPlayer > 20f)
				{
					Pathfinding.speed = 4f;
				}
				else if (DistanceToPlayer < 10f)
				{
					Pathfinding.speed = WalkSpeed;
				}
			}
			if (!Indoors)
			{
				if (Hurry && !Tripped && MustTrip && base.transform.position.z > -50.5f && base.transform.position.x < 6f)
				{
					CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					CharacterAnimation.CrossFade("trip_00");
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					Tripping = true;
					Routine = false;
					Blind = true;
					if (Clock.Day == 2 && !BountyCollider.activeInHierarchy)
					{
						BountyCollider.transform.localPosition = new Vector3(0f, 0f, 0.25f);
						BountyCollider.GetComponent<BoxCollider>().center = new Vector3(0f, 0.12f, 0f);
						BountyCollider.GetComponent<BoxCollider>().size = new Vector3(0.78f, 0.24f, 1.9f);
						BountyCollider.SetActive(value: true);
					}
				}
				if (Paired)
				{
					if (base.transform.position.z < -50f)
					{
						if (base.transform.localEulerAngles != Vector3.zero)
						{
							base.transform.localEulerAngles = Vector3.zero;
						}
						MyController.Move(base.transform.forward * Time.deltaTime);
						if (StudentID == 81 && !StudentManager.Eighties)
						{
							MusumeTimer += Time.deltaTime;
							if (MusumeTimer > 5f)
							{
								MusumeTimer = 0f;
								MusumeRight = !MusumeRight;
								WalkAnim = (MusumeRight ? "f02_walkTalk_00" : "f02_walkTalk_01");
							}
						}
					}
					else
					{
						if (Persona == PersonaType.PhoneAddict)
						{
							SpeechLines.Stop();
							SmartPhone.SetActive(value: true);
						}
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						StopPairing();
					}
				}
				if (!StudentManager.KokonaTutorial)
				{
					if (Phase == 0)
					{
						if (DistanceToDestination < 1f)
						{
							CurrentDestination = MyLocker;
							Pathfinding.target = MyLocker;
							Phase++;
						}
					}
					else if (DistanceToDestination < 0.5f && !ShoeRemoval.enabled && !InEvent)
					{
						if (Rival)
						{
							Debug.Log("A rival just decided to change her shoes from this part of the code, specifically.");
						}
						if (Shy)
						{
							CharacterAnimation[ShyAnim].weight = 0.5f;
						}
						SmartPhone.SetActive(value: false);
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						ShoeRemoval.StartChangingShoes();
						ShoeRemoval.enabled = true;
						ChangingShoes = true;
						CanTalk = false;
						Routine = false;
					}
				}
			}
			else if (Phase < ScheduleBlocks.Length - 1 && Clock.HourTime >= ScheduleBlocks[Phase].time && !InEvent && !Meeting && ClubActivityPhase < 16 && !Ragdoll.Zs.activeInHierarchy && !Dying)
			{
				if (Schoolwear == 2)
				{
					Debug.Log(Name + ", a student wearing a swimsuit, is now advancing their phase.");
				}
				if (Actions[Phase] == StudentActionType.Clean && Pushable && !Meeting)
				{
					Pushable = false;
					StudentManager.UpdateMe(StudentID);
					ChalkDust.Stop();
				}
				SimpleForgetAboutBloodPool();
				MyRenderer.updateWhenOffscreen = false;
				SprintAnim = OriginalSprintAnim;
				if (Headache)
				{
					SprintAnim = OriginalSprintAnim;
					WalkAnim = OriginalWalkAnim;
				}
				if (Vomiting)
				{
					StopVomitting();
				}
				SitInInfirmary = false;
				Pushable = false;
				Headache = false;
				Sedated = false;
				Hurry = false;
				if (Schoolwear == 1)
				{
					SunbathePhase = 0;
				}
				Phase++;
				WitnessBonus = 0;
				BountyCollider.SetActive(value: false);
				if (Drownable)
				{
					Drownable = false;
					StudentManager.UpdateMe(StudentID);
				}
				if (Schoolwear > 1 && Destinations[Phase] == MyLocker)
				{
					Phase++;
					if (Rival && DateGlobals.Weekday == DayOfWeek.Friday)
					{
						Phase--;
					}
				}
				if ((Actions[Phase] == StudentActionType.SitAndTakeNotes && Schoolwear == 2) || (Actions[Phase] == StudentActionType.ChangeShoes && Schoolwear == 2) || (Actions[Phase] == StudentActionType.AtLocker && Schoolwear == 2) || (Actions[Phase] == StudentActionType.AtLocker && BikiniAttacher != null && BikiniAttacher.newRenderer != null))
				{
					if (Schoolwear == 2 && BeenSplashed)
					{
						Debug.Log(Name + " doesn't have access to a clean uniform. They will simply have to continue wearing their gym clothing.");
					}
					else
					{
						Debug.Log(Name + " needs to change clothing before doing whatever they're supposed to do next.");
						MustChangeClothing = true;
						ChangeClothingPhase = 0;
					}
				}
				if (Actions[Phase] == StudentActionType.Graffiti && !StudentManager.Bully)
				{
					ScheduleBlock obj = ScheduleBlocks[2];
					obj.destination = "Patrol";
					obj.action = "Patrol";
					GetDestinations();
				}
				if (!StudentManager.Eighties && Actions[Phase] == StudentActionType.Bully && StudentManager.VictimID == 10)
				{
					ScheduleBlock obj2 = ScheduleBlocks[4];
					obj2.destination = "Patrol";
					obj2.action = "Patrol";
					GetDestinations();
				}
				if (!StudentManager.ReactedToGameLeader && Actions[Phase] == StudentActionType.Bully && !StudentManager.Bully)
				{
					ScheduleBlock obj3 = ScheduleBlocks[4];
					obj3.destination = "Sunbathe";
					obj3.action = "Sunbathe";
					GetDestinations();
				}
				if (Sedated)
				{
					SprintAnim = OriginalSprintAnim;
					Sedated = false;
				}
				CurrentAction = Actions[Phase];
				CurrentDestination = Destinations[Phase];
				Pathfinding.target = Destinations[Phase];
				if (Rival && DateGlobals.Weekday == DayOfWeek.Friday && !InCouple)
				{
					if (Rival && DateGlobals.Weekday == DayOfWeek.Friday)
					{
						Debug.Log("This is the part where the rival decides whether or not she should put a note in someone's locker.");
						CharacterAnimation.CrossFade(WalkAnim);
					}
					if ((StudentManager.LoveManager.ConfessToSuitor || GameGlobals.RivalEliminationID != 4) && Actions[Phase] == StudentActionType.ChangeShoes)
					{
						Debug.Log("The rival's current action is ''ChangingShoes''.");
						ChooseLocker();
						Yandere.PauseScreen.Hint.Show = true;
						Yandere.PauseScreen.Hint.QuickID = 10;
						IgnoringThingsOnGround = true;
						IgnoringPettyActions = true;
						Confessing = true;
						Routine = false;
						CanTalk = false;
					}
				}
				if (CurrentDestination != null)
				{
					DistanceToDestination = Vector3.Distance(base.transform.position, CurrentDestination.position);
				}
				if (Bento != null && Bento.activeInHierarchy)
				{
					Bento.SetActive(value: false);
					Chopsticks[0].SetActive(value: false);
					Chopsticks[1].SetActive(value: false);
				}
				if (Male)
				{
					Cosmetic.MyRenderer.materials[Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
					PinkSeifuku.SetActive(value: false);
				}
				else
				{
					HorudaCollider.gameObject.SetActive(value: false);
				}
				BountyCollider.SetActive(value: false);
				Cigarette.SetActive(value: false);
				Lighter.SetActive(value: false);
				if (!Paired)
				{
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
				}
				if (Persona != PersonaType.PhoneAddict && !Sleuthing)
				{
					SmartPhone.SetActive(value: false);
				}
				else if (!Slave && !Phoneless)
				{
					if (!StudentManager.Eighties)
					{
						if ((StudentID > 37 && StudentID < 41) || (StudentID == 84 && Club == ClubType.None))
						{
							IdleAnim = "f02_friendlyPhoneIdle_00";
						}
						else
						{
							IdleAnim = PhoneAnims[0];
						}
					}
					SmartPhone.SetActive(value: true);
				}
				Paintbrush.SetActive(value: false);
				Sketchbook.SetActive(value: false);
				Palette.SetActive(value: false);
				Pencil.SetActive(value: false);
				OccultBook.SetActive(value: false);
				Scrubber.SetActive(value: false);
				Eraser.SetActive(value: false);
				Pen.SetActive(value: false);
				GameObject[] scienceProps = ScienceProps;
				foreach (GameObject gameObject in scienceProps)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(value: false);
					}
				}
				scienceProps = Fingerfood;
				foreach (GameObject gameObject2 in scienceProps)
				{
					if (gameObject2 != null)
					{
						gameObject2.SetActive(value: false);
					}
				}
				SpeechLines.Stop();
				GoAway = false;
				ReadPhase = 0;
				if (!ReturningFromSave)
				{
					PatrolID = 0;
				}
				if (Phase == PhaseFromSave)
				{
					if (StudentManager.Patrols.List[StudentID] != null && Destinations[Phase] == StudentManager.Patrols.List[StudentID].GetChild(0))
					{
						Destinations[Phase] = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
						CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
						Pathfinding.target = CurrentDestination;
					}
					ReturningFromSave = false;
				}
				if (Actions[Phase] == StudentActionType.Clean)
				{
					if (!StudentManager.CustomMode && StudentID == 11)
					{
						FollowTargetDestination.localPosition = new Vector3(0f, 0f, -1f);
					}
					EquipCleaningItems();
				}
				else
				{
					if (!StudentManager.Eighties && StudentID == 11)
					{
						FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
					}
					if (!Slave && !Phoneless)
					{
						if (Persona == PersonaType.PhoneAddict)
						{
							SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
							SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
							if (!StudentManager.Eighties)
							{
								WalkAnim = PhoneAnims[1];
							}
						}
						else if (Sleuthing)
						{
							WalkAnim = SleuthWalkAnim;
						}
					}
				}
				if (Actions[Phase] == StudentActionType.Sleuth && StudentManager.SleuthPhase == 3)
				{
					GetSleuthTarget();
				}
				if (Actions[Phase] == StudentActionType.Stalk)
				{
					TargetDistance = 10f;
				}
				else if (Actions[Phase] == StudentActionType.Follow)
				{
					TargetDistance = 0.5f;
					if (FollowTarget != null && !FollowTarget.Alive && !WitnessedCorpse)
					{
						if (FollowTarget.CurrentAction == StudentActionType.Clean)
						{
							FollowTarget.FollowTargetDestination.localPosition = new Vector3(-1f, 0f, -1f);
						}
						else if (FollowTarget.CurrentAction == StudentActionType.SitAndEatBento)
						{
							FollowTarget.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 1f);
						}
						else if (FollowTarget.Meeting)
						{
							FollowTarget.FollowTargetDestination.localPosition = new Vector3(-1f, 0f, 0f);
						}
						else
						{
							FollowTarget.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
						}
						TargetDistance = 1f;
					}
				}
				else if (Actions[Phase] != StudentActionType.SitAndEatBento)
				{
					TargetDistance = 0.5f;
				}
				if (Club == ClubType.Gardening && StudentID != 71 && Actions[Phase] == StudentActionType.ClubAction)
				{
					if (!StudentManager.Eighties || WaterLow)
					{
						if (WateringCan != null && WateringCan.activeInHierarchy && WateringCan.transform.parent != Hips)
						{
							WateringCan.transform.parent = Hips;
							WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
							WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
						}
						if (Clock.Period == 6 && !WaterLow && StudentManager.Patrols.List[StudentID] != StudentManager.GardeningPatrols[StudentID - 71])
						{
							StudentManager.Patrols.List[StudentID] = StudentManager.GardeningPatrols[StudentID - 71];
							ClubAnim = "f02_waterPlantLow_00";
							CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
							Pathfinding.target = CurrentDestination;
						}
					}
					else if (Clock.Period == 6 && StudentManager.Patrols.List[StudentID] != StudentManager.GardeningPatrols[StudentID - 71])
					{
						StudentManager.Patrols.List[StudentID] = StudentManager.GardeningPatrols[StudentID - 71];
						CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
						Pathfinding.target = CurrentDestination;
					}
				}
				if (OriginalClub == ClubType.LightMusic)
				{
					if (StudentID == 51)
					{
						if (InstrumentBag[ClubMemberID].transform.parent == null)
						{
							Instruments[ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
							Instruments[ClubMemberID].GetComponent<AudioSource>().Stop();
							Instruments[ClubMemberID].transform.parent = null;
							if (!StudentManager.Eighties)
							{
								Instruments[ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
								Instruments[ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
							}
							else
							{
								Instruments[ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
								Instruments[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
							}
						}
						else
						{
							Instruments[ClubMemberID].SetActive(value: false);
						}
					}
					else
					{
						Instruments[ClubMemberID].SetActive(value: false);
					}
					Drumsticks[0].SetActive(value: false);
					Drumsticks[1].SetActive(value: false);
					AirGuitar.Stop();
				}
				if (!StudentManager.Eighties && Phase == 8 && StudentID == 36)
				{
					StudentManager.Clubs.List[StudentID].position = StudentManager.Clubs.List[71].position;
					StudentManager.Clubs.List[StudentID].rotation = StudentManager.Clubs.List[71].rotation;
					ClubAnim = GameAnim;
				}
				if (MyPlate != null && MyPlate.parent == RightHand)
				{
					CurrentDestination = StudentManager.Clubs.List[StudentID];
					Pathfinding.target = StudentManager.Clubs.List[StudentID];
				}
				if (Persona == PersonaType.Sleuth)
				{
					if (Male)
					{
						SmartPhone.transform.localPosition = new Vector3(0.06f, -0.02f, -0.02f);
						if (!StudentManager.Eighties)
						{
							SmartPhone.transform.localEulerAngles = new Vector3(12.5f, 120f, 180f);
						}
						else
						{
							SmartPhone.transform.localEulerAngles = new Vector3(22.5f, 22.5f, 150f);
						}
					}
					else if (StudentManager.Eighties)
					{
						SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.066666f, -0.01f);
						SmartPhone.transform.localEulerAngles = new Vector3(15f, 15f, 105f);
					}
					else if (Sleuthing)
					{
						SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.015f, -0.015f);
						SmartPhone.transform.localEulerAngles = new Vector3(12.5f, 120f, 180f);
					}
					else
					{
						SmartPhone.transform.localPosition = new Vector3(0.025f, 0.02f, 0.04f);
						SmartPhone.transform.localEulerAngles = new Vector3(22.5f, -157.5f, 180f);
					}
				}
				if (Character.transform.localPosition.y == -0.25f)
				{
					Debug.Log("Swimming club special case was reached.");
					Destinations[Phase] = StudentManager.Clubs.List[ID].GetChild(ClubActivityPhase - 2);
					CurrentDestination = StudentManager.Clubs.List[ID].GetChild(ClubActivityPhase - 2);
					Pathfinding.target = StudentManager.Clubs.List[ID].GetChild(ClubActivityPhase - 2);
				}
				if (Actions[Phase] == StudentActionType.Sunbathe && SunbathePhase > 1)
				{
					CurrentDestination = StudentManager.SunbatheSpots[StudentID];
					Pathfinding.target = StudentManager.SunbatheSpots[StudentID];
				}
				if (StudentID == 10 && FollowTarget != null && !FollowTarget.Alive && StudentManager.LastKnownOsana.position != Vector3.zero)
				{
					Pathfinding.target = StudentManager.LastKnownOsana;
					CurrentDestination = StudentManager.LastKnownOsana;
				}
				if (Phoneless)
				{
					SmartPhone.SetActive(value: false);
				}
				if (Rival)
				{
					if (CurrentAction == StudentActionType.Clean)
					{
						StudentManager.RivalBookBag.gameObject.SetActive(value: false);
						StudentManager.RivalBookBag.Prompt.Hide();
						StudentManager.RivalBookBag.Prompt.enabled = false;
						if (StudentManager.Eighties)
						{
							BookBag.SetActive(value: true);
						}
					}
					else if (Clock.Period == 4 && CurrentAction == StudentActionType.Read && !StudentManager.RivalBookBag.BorrowedBook)
					{
						ScheduleBlock obj4 = ScheduleBlocks[Phase];
						obj4.destination = "Search Patrol";
						obj4.action = "Search Patrol";
						GetDestinations();
						CurrentDestination = Destinations[Phase];
						Pathfinding.target = Destinations[Phase];
					}
				}
				if (!Teacher && Club != ClubType.Delinquent && Club != ClubType.Sports)
				{
					if (Clock.Period == 2 || Clock.Period == 4)
					{
						if (ClubActivityPhase < 16)
						{
							Pathfinding.speed = 4f;
						}
					}
					else
					{
						Pathfinding.speed = WalkSpeed;
					}
					if (!StudentManager.Eighties)
					{
						if (StudentManager.ConvoManager.Week != 0 && (StudentID == 25 || StudentID == 30 || StudentID == 24 || StudentID == 27))
						{
							Hurry = true;
							Pathfinding.speed = 4f;
						}
					}
					else if (StudentID > 10 && StudentID < 21 && (Schoolwear != 1 || (BikiniAttacher != null && BikiniAttacher.newRenderer != null)))
					{
						Debug.Log(Name + " wasn't dressed normally when she reached this part of the code.");
						if (Schoolwear == 3)
						{
							Debug.Log(Name + " was in gym clothing. Should be running.");
							Hurry = true;
							Pathfinding.speed = 4f;
						}
						if (CurrentAction == StudentActionType.AtLocker || CurrentAction == StudentActionType.ChangeShoes || CurrentAction == StudentActionType.SitAndTakeNotes)
						{
							Debug.Log(Name + " is firing the GoChange() function.");
							ConfessAfterwards = Confessing;
							if (ConfessAfterwards)
							{
								Routine = true;
							}
							Confessing = false;
							ChangeClothingPhase = 0;
							GoChange();
						}
					}
				}
				if (Infatuated && Actions[Phase] == StudentActionType.Admire)
				{
					if (DistanceToDestination > TargetDistance + 5f)
					{
						Pathfinding.speed = 5f;
					}
					else
					{
						Pathfinding.speed = WalkSpeed;
					}
					if (InvestigatingMysteriousDisappearance)
					{
						TargetDistance = 1f;
					}
					else if (base.transform.position.y > CurrentDestination.position.y + 1f || base.transform.position.y < CurrentDestination.position.y - 1f)
					{
						TargetDistance = 2f;
					}
					else if (StudentManager.Students[StudentManager.RivalID] != null && StudentManager.Students[StudentManager.RivalID].Meeting)
					{
						TargetDistance = 10f;
					}
					else if (StudentManager.Week > 8)
					{
						TargetDistance = 0.5f;
					}
					else
					{
						TargetDistance = 3.9f;
					}
				}
				if (Club == ClubType.Sports && Clock.Period == 6 && !StudentManager.PoolClosed && Schoolwear == 3)
				{
					ClubAnim = "poolDive_00";
					ClubActivityPhase = 15;
					Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase);
				}
				if (CurrentAction == StudentActionType.GravurePose && WearingBikini)
				{
					Debug.Log("She's already in her bikini. Telling her to go pose!");
					GoPose();
				}
				if (WitnessID > 0)
				{
					Hurry = true;
				}
				if (ClubLeader && Club == ClubType.Art && CurrentAction == StudentActionType.Paint && DateGlobals.Weekday == DayOfWeek.Friday)
				{
					StudentManager.Clubs.List[41].position = CurrentDestination.position;
				}
				CharacterAnimation[SitAnim].weight = 0f;
				CharacterAnimation[SocialSitAnim].weight = 0f;
				if (MustChangeClothing && Schoolwear == 2)
				{
					Debug.Log("This character really ought to change their clothing before they proceed with their routine.");
					CurrentDestination = StudentManager.StrippingPositions[GirlID];
					Pathfinding.target = StudentManager.StrippingPositions[GirlID];
				}
			}
			if (MeetTime > 0f)
			{
				bool flag = false;
				if (MyPlate != null && MyPlate.parent == RightHand)
				{
					flag = true;
				}
				if (!InEvent && Clock.HourTime > MeetTime && !flag && Schoolwear != 0 && Schoolwear != 2)
				{
					if (MyPlate != null && MyPlate.parent == RightHand && Follower != null)
					{
						ScheduleBlock obj5 = Follower.ScheduleBlocks[Follower.Phase];
						obj5.destination = "Follow";
						obj5.action = "Follow";
						Follower.Actions[Follower.Phase] = StudentActionType.Follow;
						CurrentAction = StudentActionType.Follow;
						Follower.GetDestinations();
						Follower.CurrentDestination = Follower.Destinations[Follower.Phase];
						Follower.Pathfinding.target = Follower.Destinations[Follower.Phase];
					}
					CurrentDestination = MeetSpot;
					Pathfinding.target = MeetSpot;
					DistanceToDestination = Vector3.Distance(base.transform.position, CurrentDestination.position);
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					Pathfinding.speed = 4f;
					TargetDistance = 1f;
					SpeechLines.Stop();
					EmptyHands();
					Meeting = true;
					MeetTime = 0f;
					if (Rival)
					{
						StudentManager.UpdateInfatuatedTargetDistances();
					}
				}
			}
			if (DistanceToDestination > TargetDistance)
			{
				ReadPhase = 0;
				if (Actions[Phase] == StudentActionType.Sleuth)
				{
					if (!SmartPhone.activeInHierarchy)
					{
						SmartPhone.SetActive(value: true);
						SpeechLines.Stop();
					}
					if (CurrentDestination == null)
					{
						GetSleuthTarget();
					}
					else
					{
						LockerRoomCheckTimer += Time.deltaTime;
						if (LockerRoomCheckTimer > 5f)
						{
							LockerRoomCheckTimer = 0f;
							if (StudentManager.LockerRoomArea.bounds.Contains(CurrentDestination.position) || StudentManager.MaleLockerRoomArea.bounds.Contains(CurrentDestination.position) || StudentManager.EastBathroomArea.bounds.Contains(CurrentDestination.position) || StudentManager.WestBathroomArea.bounds.Contains(CurrentDestination.position) || CurrentDestination.position.z < -100f)
							{
								GetSleuthTarget();
							}
						}
					}
				}
				else if (Actions[Phase] == StudentActionType.Relax && Curious)
				{
					if (CurrentDestination == StudentManager.Students[Crush].transform)
					{
						TargetDistance = 3.9f;
					}
				}
				else if (Actions[Phase] == StudentActionType.Stalk && StudentManager.LockerRoomArea.bounds.Contains(Yandere.transform.position))
				{
					if (Vector3.Distance(base.transform.position, StudentManager.FleeSpots[0].position) > 10f)
					{
						Pathfinding.target = StudentManager.FleeSpots[0];
						CurrentDestination = StudentManager.FleeSpots[0];
					}
					else
					{
						Pathfinding.target = StudentManager.FleeSpots[1];
						CurrentDestination = StudentManager.FleeSpots[1];
					}
					Pathfinding.speed = 4f;
					StalkerFleeing = true;
				}
				if (StudentID == 10)
				{
					if (Actions[Phase] == StudentActionType.Follow && !Alarmed)
					{
						Obstacle.enabled = false;
						if (FollowTarget != null)
						{
							if (FollowTarget.Wet && FollowTarget.DistanceToDestination < 5f)
							{
								TargetDistance = 4f;
							}
							else if (FollowTarget.CurrentAction == StudentActionType.SearchPatrol)
							{
								TargetDistance = 1f;
							}
							else
							{
								TargetDistance = 0.5f;
								if (FollowTarget != null && !FollowTarget.Alive && !WitnessedCorpse)
								{
									TargetDistance = 1f;
								}
							}
						}
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						if (DistanceToDestination > 2f)
						{
							Pathfinding.speed = 5f;
							SpeechLines.Stop();
						}
						else
						{
							Pathfinding.speed = WalkSpeed;
							SpeechLines.Stop();
						}
					}
					else if (base.transform.position.z > 121f && Actions[Phase] == StudentActionType.Sketch && Yandere.Attacking && Yandere.TargetStudent == FollowTarget)
					{
						AwareOfMurder = true;
						Alarm = 200f;
					}
				}
				if (StudentID == 12 && Actions[Phase] == StudentActionType.LightFire && Vector3.Distance(Yandere.transform.position, CurrentDestination.position) < 5f && CanSeeObject(Yandere.gameObject, Yandere.HeadPosition))
				{
					Subtitle.CustomText = "...oh...I didn't realize someone was here...I'll just...be going, now...";
					Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
					FinishPyro();
				}
				if (CuriosityPhase == 1 && Actions[Phase] == StudentActionType.Relax && StudentManager.Students[Crush].Private)
				{
					Pathfinding.target = Destinations[Phase];
					CurrentDestination = Destinations[Phase];
					TargetDistance = 0.5f;
					CuriosityTimer = 0f;
					CuriosityPhase--;
				}
				if (Actions[Phase] != StudentActionType.Follow || (Actions[Phase] == StudentActionType.Follow && DistanceToDestination > TargetDistance + 0.1f))
				{
					if (Actions[Phase] == StudentActionType.Follow && ((Clock.Period == 1 && Clock.HourTime > 8.483334f) || (Clock.Period == 3 && Clock.HourTime > 13.483334f)))
					{
						Pathfinding.speed = 4f;
					}
					if (!InEvent && !Meeting && !GoAway)
					{
						if (DressCode)
						{
							if (Actions[Phase] == StudentActionType.ClubAction)
							{
								if (!ClubAttire)
								{
									if (!ChangingBooth.Occupied)
									{
										CurrentDestination = ChangingBooth.transform;
										Pathfinding.target = ChangingBooth.transform;
									}
									else
									{
										CurrentDestination = ChangingBooth.WaitSpots[ClubMemberID];
										Pathfinding.target = ChangingBooth.WaitSpots[ClubMemberID];
									}
								}
								else if (Indoors && !GoAway)
								{
									CurrentDestination = Destinations[Phase];
									Pathfinding.target = Destinations[Phase];
									DistanceToDestination = 100f;
								}
							}
							else if (ClubAttire)
							{
								TargetDistance = 1f;
								if (!ChangingBooth.Occupied)
								{
									CurrentDestination = ChangingBooth.transform;
									Pathfinding.target = ChangingBooth.transform;
								}
								else
								{
									CurrentDestination = ChangingBooth.WaitSpots[ClubMemberID];
									Pathfinding.target = ChangingBooth.WaitSpots[ClubMemberID];
								}
							}
							else if (Indoors && Actions[Phase] != StudentActionType.Clean && Actions[Phase] != StudentActionType.Sketch && Actions[Phase] != StudentActionType.Relax)
							{
								CurrentDestination = Destinations[Phase];
								Pathfinding.target = Destinations[Phase];
							}
						}
						else if (Actions[Phase] == StudentActionType.SitAndTakeNotes && Schoolwear > 1 && !SchoolwearUnavailable)
						{
							CurrentDestination = StudentManager.StrippingPositions[GirlID];
							Pathfinding.target = StudentManager.StrippingPositions[GirlID];
						}
					}
					if (!Pathfinding.canMove)
					{
						if (!Spawned)
						{
							base.transform.position = StudentManager.SpawnPositions[StudentID].position;
							Spawned = true;
							if (!StudentManager.Eighties && StudentID == 10 && StudentManager.Students[11] == null)
							{
								base.transform.position = new Vector3(-4f, 0f, -96f);
								Physics.SyncTransforms();
							}
						}
						if (!Paired && !Alarmed)
						{
							Pathfinding.canSearch = true;
							Pathfinding.canMove = true;
							Obstacle.enabled = false;
						}
					}
					if (!InEvent)
					{
						if (Pathfinding.speed > 0f)
						{
							if (!Hurry && Pathfinding.speed == WalkSpeed)
							{
								if (!CharacterAnimation.IsPlaying(WalkAnim))
								{
									if (Persona == PersonaType.PhoneAddict && Actions[Phase] == StudentActionType.Clean)
									{
										CharacterAnimation.CrossFade(OriginalWalkAnim);
									}
									else
									{
										if (WalkAnim == "")
										{
											WalkAnim = OriginalWalkAnim;
										}
										CharacterAnimation.CrossFade(WalkAnim);
									}
								}
							}
							else if (!Dying)
							{
								if (Sleepy)
								{
									Pathfinding.speed = 2f;
								}
								else
								{
									Pathfinding.speed = 4f;
								}
								CharacterAnimation.CrossFade(SprintAnim);
							}
						}
					}
					else if (Mentoring && StudentID == 10 && InEvent && CurrentAction == StudentActionType.Socializing)
					{
						if (!Hurry)
						{
							Pathfinding.speed = WalkSpeed;
						}
						else
						{
							Pathfinding.speed = 4f;
						}
						if (Pathfinding.speed == WalkSpeed)
						{
							CharacterAnimation.CrossFade(WalkAnim);
						}
						else
						{
							CharacterAnimation.CrossFade(SprintAnim);
						}
						CheckForEndRaibaruEvent();
					}
					if (Club == ClubType.Occult && Actions[Phase] != StudentActionType.ClubAction)
					{
						OccultBook.SetActive(value: false);
					}
					if (!Meeting && !GoAway && !InEvent)
					{
						if (Actions[Phase] == StudentActionType.Clean)
						{
							if (SmartPhone.activeInHierarchy)
							{
								SmartPhone.SetActive(value: false);
							}
							if (CurrentDestination != CleaningSpot.GetChild(CleanID))
							{
								CurrentDestination = CleaningSpot.GetChild(CleanID);
								Pathfinding.target = CurrentDestination;
							}
						}
						if ((Actions[Phase] == StudentActionType.Patrol || (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Gardening)) && CurrentDestination != StudentManager.Patrols.List[StudentID].GetChild(PatrolID))
						{
							CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
							Pathfinding.target = CurrentDestination;
						}
					}
				}
				if (Meeting)
				{
					if (BakeSale)
					{
						CharacterAnimation.CrossFade(WalkAnim);
						Pathfinding.speed = WalkSpeed;
					}
					else
					{
						CharacterAnimation.CrossFade(SprintAnim);
						Pathfinding.speed = 4f;
					}
				}
				if (CuriosityPhase == 1 && CurrentAction == StudentActionType.Relax && (StudentManager.LockerRoomArea.bounds.Contains(StudentManager.Students[Crush].transform.position) || StudentManager.EastBathroomArea.bounds.Contains(StudentManager.Students[Crush].transform.position) || StudentManager.WestBathroomArea.bounds.Contains(StudentManager.Students[Crush].transform.position)))
				{
					Debug.Log("This code is called when a student is stalking their crush and their crush is in the locker room or shower room.");
					Pathfinding.target = Destinations[Phase];
					CurrentDestination = Destinations[Phase];
					TargetDistance = 0.5f;
					CuriosityTimer = 0f;
					CuriosityPhase--;
				}
				if (Infatuated && Actions[Phase] == StudentActionType.Admire)
				{
					if (DistanceToDestination > TargetDistance + 5f)
					{
						Pathfinding.speed = 5f;
					}
					else
					{
						Pathfinding.speed = WalkSpeed;
					}
					if (InvestigatingMysteriousDisappearance)
					{
						TargetDistance = 1f;
					}
					else if (base.transform.position.y > CurrentDestination.position.y + 0.1f || base.transform.position.y < CurrentDestination.position.y - 0.1f)
					{
						TargetDistance = 1f;
					}
					else if (StudentManager.Students[StudentManager.RivalID].Meeting || StudentManager.Students[StudentManager.RivalID].InEvent)
					{
						TargetDistance = 10f;
					}
					else if (StudentManager.Week > 8)
					{
						TargetDistance = 0.5f;
					}
					else
					{
						TargetDistance = 3.9f;
					}
					if (StudentManager.Students[StudentManager.RivalID].Talking || StudentManager.LockerRoomArea.bounds.Contains(CurrentDestination.position) || StudentManager.EastBathroomArea.bounds.Contains(CurrentDestination.position) || StudentManager.WestBathroomArea.bounds.Contains(CurrentDestination.position) || StudentManager.LockerRoomArea.bounds.Contains(StudentManager.Students[StudentManager.RivalID].transform.position) || StudentManager.EastBathroomArea.bounds.Contains(StudentManager.Students[StudentManager.RivalID].transform.position) || StudentManager.WestBathroomArea.bounds.Contains(StudentManager.Students[StudentManager.RivalID].transform.position))
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("impatientWait_00");
						}
						else
						{
							CharacterAnimation.CrossFade(WaitAnim);
						}
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
					}
					else
					{
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
					}
				}
			}
			else
			{
				if (StudentID == 10 && InEvent && CurrentAction != StudentActionType.Follow && Mentoring)
				{
					SpeechLines.Play();
					CharacterAnimation.CrossFade(RandomAnim);
					if (CharacterAnimation[RandomAnim].time >= CharacterAnimation[RandomAnim].length)
					{
						PickRandomAnim();
					}
					if (Mentoring)
					{
						CheckForEndRaibaruEvent();
					}
				}
				if (CurrentDestination != null)
				{
					bool flag2 = false;
					if ((Actions[Phase] == StudentActionType.Sleuth && StudentManager.SleuthPhase == 3 && !Meeting) || Actions[Phase] == StudentActionType.Stalk || (Actions[Phase] == StudentActionType.Relax && CuriosityPhase == 1) || (Actions[Phase] == StudentActionType.Guard && !Meeting) || (CurrentAction == StudentActionType.Follow && FollowTarget != null && FollowTarget.CurrentAction == StudentActionType.SearchPatrol))
					{
						if (StudentID == 11)
						{
							Debug.Log("Rival #1 believes that she should ''StopEarly''.");
						}
						TargetDistance = 2f;
						flag2 = true;
					}
					else if (Infatuated && Actions[Phase] == StudentActionType.Admire)
					{
						if (DistanceToDestination > TargetDistance + 5f)
						{
							Pathfinding.speed = 5f;
						}
						else
						{
							Pathfinding.speed = WalkSpeed;
						}
						if (InvestigatingMysteriousDisappearance)
						{
							TargetDistance = 1f;
						}
						else if (base.transform.position.y > CurrentDestination.position.y + 0.1f || base.transform.position.y < CurrentDestination.position.y - 0.1f)
						{
							TargetDistance = 1f;
						}
						else if (!StudentManager.Students[StudentManager.RivalID].Meeting && !StudentManager.Students[StudentManager.RivalID].InEvent)
						{
							if (StudentManager.Week > 8)
							{
								TargetDistance = 0.5f;
							}
							else
							{
								TargetDistance = 3.9f;
							}
						}
						flag2 = true;
					}
					if (Actions[Phase] == StudentActionType.Follow)
					{
						if (FollowTarget != null)
						{
							if (!ManualRotation)
							{
								targetRotation = Quaternion.LookRotation(FollowTarget.transform.position - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
							}
							if (FollowTarget.Attacked && FollowTarget.Alive && !FollowTarget.Tranquil && !Blind)
							{
								Debug.Log("Raibaru should be aware that Osana is being attacked.");
								AwareOfMurder = true;
								Alarm = 200f;
							}
						}
					}
					else if (!flag2)
					{
						MoveTowardsTarget(CurrentDestination.position);
						if (Quaternion.Angle(base.transform.rotation, CurrentDestination.rotation) > 1f && !StopRotating)
						{
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, 10f * Time.deltaTime);
						}
					}
					else
					{
						if (Infatuated)
						{
							StudentScript studentScript = null;
							if (Stalker)
							{
								targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
							}
							else
							{
								studentScript = StudentManager.Students[InfatuationID];
								targetRotation = Quaternion.LookRotation(new Vector3(StudentManager.Students[InfatuationID].transform.position.x, base.transform.position.y, StudentManager.Students[InfatuationID].transform.position.z) - base.transform.position);
							}
							if (studentScript != null && (!studentScript.gameObject.activeInHierarchy || !studentScript.enabled) && !StudentManager.TranqArea.bounds.Contains(studentScript.transform.position))
							{
								InvestigatingMysteriousDisappearance = true;
								TargetDistance = 1f;
								CannotFindInfatuationTarget();
							}
						}
						else if (Actions[Phase] == StudentActionType.Sleuth || Actions[Phase] == StudentActionType.Stalk)
						{
							if (Stalker)
							{
								targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
							}
							else
							{
								targetRotation = Quaternion.LookRotation(new Vector3(SleuthTarget.transform.position.x, base.transform.position.y, SleuthTarget.transform.position.z) - base.transform.position);
							}
						}
						else if (Actions[Phase] == StudentActionType.Guard)
						{
							targetRotation = Quaternion.LookRotation(base.transform.position - new Vector3(CurrentDestination.position.x, base.transform.position.y, CurrentDestination.position.z));
						}
						else if (Crush > 0)
						{
							targetRotation = Quaternion.LookRotation(new Vector3(StudentManager.Students[Crush].transform.position.x, base.transform.position.y, StudentManager.Students[Crush].transform.position.z) - base.transform.position);
						}
						float num = Quaternion.Angle(base.transform.rotation, targetRotation);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
						if (num > 1f)
						{
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
						}
					}
					if (!Hurry)
					{
						Pathfinding.speed = WalkSpeed;
					}
					else
					{
						Pathfinding.speed = 4f;
					}
				}
				if (Pathfinding.canMove)
				{
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					if (Actions[Phase] != StudentActionType.Clean && !Infatuated)
					{
						Obstacle.enabled = true;
					}
				}
				if (!InEvent && !Meeting && DressCode)
				{
					if (Actions[Phase] == StudentActionType.ClubAction)
					{
						if (!ClubAttire)
						{
							if (!ChangingBooth.Occupied)
							{
								if (CurrentDestination == ChangingBooth.transform)
								{
									ChangingBooth.Occupied = true;
									ChangingBooth.Student = this;
									ChangingBooth.CheckYandereClub();
									Obstacle.enabled = false;
								}
								CurrentDestination = ChangingBooth.transform;
								Pathfinding.target = ChangingBooth.transform;
							}
							else
							{
								CharacterAnimation.CrossFade(IdleAnim);
							}
						}
						else if (!GoAway)
						{
							CurrentDestination = Destinations[Phase];
							Pathfinding.target = Destinations[Phase];
						}
					}
					else if (ClubAttire)
					{
						if (!ChangingBooth.Occupied)
						{
							if (CurrentDestination == ChangingBooth.transform)
							{
								ChangingBooth.Occupied = true;
								ChangingBooth.Student = this;
								ChangingBooth.CheckYandereClub();
							}
							CurrentDestination = ChangingBooth.transform;
							Pathfinding.target = ChangingBooth.transform;
						}
						else
						{
							CharacterAnimation.CrossFade(IdleAnim);
						}
					}
					else if (Actions[Phase] != StudentActionType.Clean)
					{
						CurrentDestination = Destinations[Phase];
						Pathfinding.target = Destinations[Phase];
					}
				}
				if (!InEvent)
				{
					if (!Meeting)
					{
						if (!GoAway)
						{
							if (Actions[Phase] == StudentActionType.AtLocker)
							{
								if (MustChangeClothing)
								{
									Debug.Log(Name + " is calling ChangeClothing() from here, specifically.");
									ChangeClothing();
								}
								else
								{
									CharacterAnimation.CrossFade(IdleAnim);
									Pathfinding.canSearch = false;
									Pathfinding.canMove = false;
								}
							}
							else if (Actions[Phase] == StudentActionType.Socializing || (Actions[Phase] == StudentActionType.Follow && FollowTarget != null && FollowTarget.Actions[Phase] != StudentActionType.Clean && FollowTargetDistance < 1f && !FollowTarget.Alone && !FollowTarget.InEvent && !FollowTarget.Talking && !FollowTarget.Meeting && !FollowTarget.Confessing && FollowTarget.DistanceToDestination < 1f))
							{
								bool flag3 = false;
								if (FollowTarget != null)
								{
									if (!FollowTarget.Alive && FollowTarget.Ragdoll.Concealed)
									{
										if (base.transform.position.y > -1f)
										{
											RaibaruCannotFindOsana();
											flag3 = true;
										}
									}
									else if (FollowTarget.Indoors && FollowTarget.CurrentAction != StudentActionType.SearchPatrol)
									{
										CurrentDestination = FollowTarget.FollowTargetDestination;
										Pathfinding.target = FollowTarget.FollowTargetDestination;
										FollowTarget.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 1f);
										MoveTowardsTarget(CurrentDestination.position);
									}
									else if (FollowTarget.CurrentAction == StudentActionType.Clean)
									{
										FollowTarget.FollowTargetDestination.localPosition = new Vector3(-1f, 0f, -1f);
									}
									else
									{
										FollowTarget.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
									}
								}
								if (MyPlate != null && MyPlate.parent == RightHand)
								{
									ClubActivityPhase = 0;
									MyPlate.parent = null;
									MyPlate.position = OriginalPlatePosition;
									MyPlate.rotation = OriginalPlateRotation;
									IdleAnim = OriginalIdleAnim;
									WalkAnim = OriginalWalkAnim;
									LeanAnim = OriginalLeanAnim;
									ResumeDistracting = false;
									Distracting = false;
									Distracted = false;
									CanTalk = true;
								}
								if (Paranoia > 1.66666f && !StudentManager.LoveSick && Club != ClubType.Delinquent)
								{
									CharacterAnimation.CrossFade(IdleAnim);
								}
								else
								{
									StudentManager.ConvoManager.CheckMe(StudentID);
									if (Club == ClubType.Delinquent)
									{
										if (Alone)
										{
											if (!Phoneless && TrueAlone)
											{
												if (!SmartPhone.activeInHierarchy)
												{
													CharacterAnimation.CrossFade("delinquentTexting_00");
													SmartPhone.SetActive(value: true);
													SpeechLines.Stop();
												}
											}
											else
											{
												CharacterAnimation.CrossFade(IdleAnim);
												SpeechLines.Stop();
											}
										}
										else
										{
											if (!InEvent)
											{
												if (!Grudge)
												{
													if (!SpeechLines.isPlaying)
													{
														SmartPhone.SetActive(value: false);
														SpeechLines.Play();
													}
												}
												else
												{
													SmartPhone.SetActive(value: false);
												}
											}
											CharacterAnimation.CrossFade(RandomAnim);
											if (CharacterAnimation[RandomAnim].time >= CharacterAnimation[RandomAnim].length)
											{
												PickRandomAnim();
											}
										}
									}
									else if (Alone)
									{
										if (!Male)
										{
											if (!Phoneless)
											{
												if (!flag3)
												{
													CharacterAnimation.CrossFade("f02_standTexting_00");
													SmartPhone.SetActive(value: true);
													SpeechLines.Stop();
												}
											}
											else
											{
												CharacterAnimation.CrossFade(PatrolAnim);
												SpeechLines.Stop();
											}
										}
										else if (!Phoneless)
										{
											if (StudentID == 36)
											{
												CharacterAnimation.CrossFade(ClubAnim);
											}
											else if (StudentID == 66)
											{
												CharacterAnimation.CrossFade("delinquentTexting_00");
											}
											else
											{
												CharacterAnimation.CrossFade("standTexting_00");
											}
											if (!SmartPhone.activeInHierarchy && !Shy)
											{
												if (StudentID == 36)
												{
													SmartPhone.transform.localPosition = new Vector3(0.0566666f, -0.02f, 0f);
													SmartPhone.transform.localEulerAngles = new Vector3(10f, 115f, 180f);
												}
												else
												{
													SmartPhone.transform.localPosition = new Vector3(0.015f, 0.01f, 0.025f);
													SmartPhone.transform.localEulerAngles = new Vector3(10f, -160f, 165f);
												}
												SmartPhone.SetActive(value: true);
												SpeechLines.Stop();
											}
										}
										else
										{
											CharacterAnimation.CrossFade(PatrolAnim);
											SpeechLines.Stop();
										}
									}
									else if ((FollowTarget != null && !FollowTarget.gameObject.activeInHierarchy) || (FollowTarget != null && !FollowTarget.enabled))
									{
										Debug.Log("Raibaru can't find Osana.");
										RaibaruCannotFindOsana();
									}
									else
									{
										if (!InEvent)
										{
											if (!Grudge)
											{
												if (!SpeechLines.isPlaying)
												{
													SmartPhone.SetActive(value: false);
													SpeechLines.Play();
												}
											}
											else
											{
												SmartPhone.SetActive(value: false);
											}
										}
										if (Club != ClubType.Photography)
										{
											CharacterAnimation.CrossFade(RandomAnim);
											if (CharacterAnimation[RandomAnim].time >= CharacterAnimation[RandomAnim].length)
											{
												PickRandomAnim();
											}
										}
										else
										{
											CharacterAnimation.CrossFade(RandomSleuthAnim);
											if (CharacterAnimation[RandomSleuthAnim].time >= CharacterAnimation[RandomSleuthAnim].length)
											{
												PickRandomSleuthAnim();
											}
										}
									}
								}
								if (PyroUrge)
								{
									UpdatePyroUrge();
								}
							}
							else if (Actions[Phase] == StudentActionType.Gossip)
							{
								if (StudentID == 82 && Clock.Day == 5)
								{
									BountyCollider.SetActive(value: true);
								}
								if (Paranoia > 1.66666f && !StudentManager.LoveSick)
								{
									CharacterAnimation.CrossFade(IdleAnim);
								}
								else
								{
									StudentManager.ConvoManager.CheckMe(StudentID);
									if (Alone)
									{
										if (!Shy)
										{
											CharacterAnimation.CrossFade("f02_standTexting_00");
											if (!SmartPhone.activeInHierarchy)
											{
												SmartPhone.SetActive(value: true);
												SpeechLines.Stop();
											}
										}
									}
									else
									{
										if (!SpeechLines.isPlaying)
										{
											SmartPhone.SetActive(value: false);
											SpeechLines.Play();
										}
										CharacterAnimation.CrossFade(RandomGossipAnim);
										if (CharacterAnimation[RandomGossipAnim].time >= CharacterAnimation[RandomGossipAnim].length)
										{
											PickRandomGossipAnim();
										}
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Gaming)
							{
								CharacterAnimation.CrossFade(GameAnim);
								if (PyroUrge)
								{
									UpdatePyroUrge();
								}
							}
							else if (Actions[Phase] == StudentActionType.Shamed)
							{
								CharacterAnimation.CrossFade(SadSitAnim);
							}
							else if (Actions[Phase] == StudentActionType.Slave)
							{
								CharacterAnimation.CrossFade(BrokenSitAnim);
								if (FragileSlave)
								{
									if (HuntTarget == null)
									{
										HuntTarget = this;
										GoCommitMurder();
									}
									else if (HuntTarget.Indoors)
									{
										GoCommitMurder();
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Relax)
							{
								if (CuriosityPhase == 0)
								{
									CharacterAnimation.CrossFade(RelaxAnim);
									if (Curious)
									{
										CuriosityTimer += Time.deltaTime;
										if (CuriosityTimer > 30f)
										{
											if (!StudentManager.Students[Crush].Private && !StudentManager.Students[Crush].Wet && !StudentManager.LockerRoomArea.bounds.Contains(StudentManager.Students[Crush].transform.position) && !StudentManager.EastBathroomArea.bounds.Contains(StudentManager.Students[Crush].transform.position) && !StudentManager.WestBathroomArea.bounds.Contains(StudentManager.Students[Crush].transform.position))
											{
												Pathfinding.target = StudentManager.Students[Crush].transform;
												CurrentDestination = StudentManager.Students[Crush].transform;
												DistanceToDestination = 100f;
												TargetDistance = 3.9f;
												CuriosityTimer = 0f;
												CuriosityPhase++;
											}
											else
											{
												CuriosityTimer = 0f;
											}
										}
									}
								}
								else
								{
									if (Pathfinding.target != StudentManager.Students[Crush].transform)
									{
										Pathfinding.target = StudentManager.Students[Crush].transform;
										CurrentDestination = StudentManager.Students[Crush].transform;
									}
									TargetDistance = 6f;
									if ((!StudentManager.Students[Crush].Alive && StudentManager.Students[Crush].Ragdoll.Concealed) || (!StudentManager.Students[Crush].Alive && StudentManager.Students[Crush].Ragdoll.Disposed) || StudentManager.Students[Crush].Ragdoll.Zs.activeInHierarchy || !StudentManager.Students[Crush].gameObject.activeInHierarchy)
									{
										CharacterAnimation.CrossFade("lookLeftRightConfused_00");
									}
									else
									{
										CharacterAnimation.CrossFade(LeanAnim);
									}
									CuriosityTimer += Time.deltaTime;
									if (CuriosityTimer > 10f || StudentManager.Students[Crush].Private || StudentManager.Students[Crush].Wet)
									{
										Pathfinding.target = Destinations[Phase];
										CurrentDestination = Destinations[Phase];
										TargetDistance = 0.5f;
										CuriosityTimer = 0f;
										CuriosityPhase--;
										if ((!StudentManager.Students[Crush].Alive && StudentManager.Students[Crush].Ragdoll.Concealed) || (!StudentManager.Students[Crush].Alive && StudentManager.Students[Crush].Ragdoll.Disposed) || !StudentManager.Students[Crush].gameObject.activeInHierarchy)
										{
											Curious = false;
										}
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.SitAndTakeNotes)
							{
								if (Follower != null && Follower.Actions[Follower.Phase] != StudentActionType.SitAndTakeNotes && Clock.HourTime < 15.5f)
								{
									Follower.GoToClass();
								}
								if (MyPlate != null && MyPlate.parent == RightHand)
								{
									ClubActivityPhase = 0;
									MyPlate.parent = null;
									MyPlate.position = OriginalPlatePosition;
									MyPlate.rotation = OriginalPlateRotation;
									CurrentDestination = Destinations[Phase];
									Pathfinding.target = Destinations[Phase];
									IdleAnim = OriginalIdleAnim;
									WalkAnim = OriginalWalkAnim;
									LeanAnim = OriginalLeanAnim;
									ResumeDistracting = false;
									Distracting = false;
									Distracted = false;
									CanTalk = true;
								}
								if (MustChangeClothing)
								{
									Debug.Log("Calling ChangeClothing() from here, specifically.");
									ChangeClothing();
								}
								else if (Bullied)
								{
									if (SmartPhone.activeInHierarchy)
									{
										SmartPhone.SetActive(value: false);
									}
									CharacterAnimation.CrossFade(SadDeskSitAnim, 1f);
								}
								else
								{
									if (Phoneless && StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !EndSearch && Yandere.CanMove)
									{
										if (Rival)
										{
											LewdPhotos = StudentManager.CommunalLocker.RivalPhone.LewdPhotos;
											if (DateGlobals.Weekday == DayOfWeek.Monday)
											{
												SchemeGlobals.SetSchemeStage(1, 8);
												Yandere.PauseScreen.Schemes.UpdateInstructions();
											}
										}
										Debug.Log(Name + " found her lost phone from this spot in the code. 1");
										CharacterAnimation.CrossFade(DiscoverPhoneAnim);
										Subtitle.UpdateLabel(LostPhoneSubtitleType, 2, 5f);
										SearchingForPhone = false;
										Phoneless = false;
										EndSearch = true;
										Routine = false;
										if (EventToSabotage != null)
										{
											EventToSabotage.gameObject.SetActive(value: true);
										}
									}
									if (!EndSearch)
									{
										if (Clock.Period != 2 && Clock.Period != 4)
										{
											if (DressCode && ClubAttire)
											{
												CharacterAnimation.CrossFade(IdleAnim);
											}
											else if ((double)Vector3.Distance(base.transform.position, Seat.position) < 0.5)
											{
												if ((StudentID == 1 && StudentManager.Gift.activeInHierarchy) || (StudentID == 1 && StudentManager.Note.activeInHierarchy))
												{
													CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
													CharacterAnimation.CrossFade(InspectBloodAnim);
													if (CharacterAnimation[InspectBloodAnim].time >= CharacterAnimation[InspectBloodAnim].length)
													{
														StudentManager.SenpaiLoveWindow.UpdateSenpaiLove();
														StudentManager.Gift.SetActive(value: false);
														StudentManager.Note.SetActive(value: false);
													}
												}
												else if (!Phoneless)
												{
													if (Club != ClubType.Delinquent)
													{
														if (!StudentManager.Eighties)
														{
															if (!SmartPhone.activeInHierarchy)
															{
																if (Male)
																{
																	SmartPhone.transform.localPosition = new Vector3(0.025f, 0.0025f, 0.025f);
																	SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 180f);
																}
																else
																{
																	SmartPhone.transform.localPosition = new Vector3(0.01f, 0.01f, 0.01f);
																	SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
																}
																SmartPhone.SetActive(value: true);
															}
															CharacterAnimation.CrossFade(DeskTextAnim);
														}
														else
														{
															if (SmartPhone.activeInHierarchy)
															{
																SmartPhone.SetActive(value: false);
															}
															CharacterAnimation.CrossFade(ConfusedSitAnim);
														}
													}
													else
													{
														CharacterAnimation.CrossFade("delinquentSit_00");
													}
												}
												else
												{
													CharacterAnimation.CrossFade(ConfusedSitAnim);
												}
											}
										}
										else if (StudentManager.Teachers[Class].SpeechLines.isPlaying && !StudentManager.Teachers[Class].Alarmed)
										{
											if (DressCode && ClubAttire)
											{
												CharacterAnimation.CrossFade(IdleAnim);
											}
											else
											{
												if (!Depressed && !Pen.activeInHierarchy)
												{
													Pen.SetActive(value: true);
												}
												if (SmartPhone.activeInHierarchy)
												{
													SmartPhone.SetActive(value: false);
												}
												if (MyPaper == null)
												{
													if (base.transform.position.x < 0f)
													{
														MyPaper = UnityEngine.Object.Instantiate(Paper, Seat.position + new Vector3(-0.4f, 0.772f, 0f), Quaternion.identity);
													}
													else
													{
														MyPaper = UnityEngine.Object.Instantiate(Paper, Seat.position + new Vector3(0.4f, 0.772f, 0f), Quaternion.identity);
													}
													MyPaper.transform.eulerAngles = new Vector3(0f, 0f, -90f);
													MyPaper.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
													MyPaper.transform.parent = StudentManager.Papers;
												}
												CharacterAnimation.CrossFade(SitAnim);
											}
										}
										else if (Club != ClubType.Delinquent)
										{
											CharacterAnimation.CrossFade(ConfusedSitAnim);
										}
										else
										{
											CharacterAnimation.CrossFade("delinquentSit_00");
										}
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Peek)
							{
								CharacterAnimation.CrossFade(PeekAnim);
								if (Male)
								{
									Cosmetic.MyRenderer.materials[Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
								}
							}
							else if (Actions[Phase] == StudentActionType.ClubAction)
							{
								if (DressCode && !ClubAttire)
								{
									CharacterAnimation.CrossFade(IdleAnim);
								}
								else
								{
									if (StudentID == 47 || StudentID == 49)
									{
										if (GetNewAnimation)
										{
											StudentManager.ConvoManager.MartialArtsCheck();
										}
										CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											GetNewAnimation = true;
										}
									}
									if (Club != ClubType.Occult)
									{
										CharacterAnimation.CrossFade(ClubAnim);
									}
								}
								if (Club == ClubType.Cooking)
								{
									if (ClubActivityPhase == 0)
									{
										if (ClubTimer == 0f)
										{
											ClubActivityPhase = 0;
											MyPlate.parent = null;
											MyPlate.gameObject.SetActive(value: true);
											MyPlate.position = OriginalPlatePosition;
											MyPlate.rotation = OriginalPlateRotation;
										}
										ClubTimer += Time.deltaTime;
										if (ClubTimer > 60f)
										{
											MyPlate.parent = RightHand;
											MyPlate.localPosition = new Vector3(0.02f, -0.02f, -0.15f);
											MyPlate.localEulerAngles = new Vector3(-5f, -90f, 172.5f);
											IdleAnim = PlateIdleAnim;
											WalkAnim = PlateWalkAnim;
											LeanAnim = PlateIdleAnim;
											GetFoodTarget();
											ClubTimer = 0f;
											ClubActivityPhase++;
										}
									}
									else
									{
										GetFoodTarget();
									}
								}
								else if (OriginalClub == ClubType.Drama)
								{
									StudentManager.DramaTimer += Time.deltaTime;
									if (StudentManager.DramaPhase == 1)
									{
										StudentManager.ConvoManager.CheckMe(StudentID);
										if (Alone)
										{
											if (Phoneless)
											{
												if (ClubLeader)
												{
													CharacterAnimation.CrossFade(IdleAnim);
												}
												else if (!Male)
												{
													CharacterAnimation.CrossFade("f02_sit_01");
												}
												else
												{
													CharacterAnimation.CrossFade("sit_00");
												}
											}
											else
											{
												if (Male)
												{
													CharacterAnimation.CrossFade("standTexting_00");
												}
												else
												{
													CharacterAnimation.CrossFade("f02_standTexting_00");
												}
												if (!SmartPhone.activeInHierarchy)
												{
													SmartPhone.transform.localPosition = new Vector3(0.02f, 0.01f, 0.03f);
													SmartPhone.transform.localEulerAngles = new Vector3(5f, -160f, 180f);
													SmartPhone.SetActive(value: true);
													SpeechLines.Stop();
												}
											}
										}
										else if (StudentID == 26 && !SpeechLines.isPlaying)
										{
											SmartPhone.SetActive(value: false);
											SpeechLines.Play();
										}
										if (StudentManager.DramaTimer > 100f)
										{
											StudentManager.DramaTimer = 0f;
											StudentManager.UpdateDrama();
										}
									}
									else if (StudentManager.DramaPhase == 2)
									{
										if (StudentManager.DramaTimer > 300f)
										{
											StudentManager.DramaTimer = 0f;
											StudentManager.UpdateDrama();
										}
									}
									else if (StudentManager.DramaPhase == 3)
									{
										SpeechLines.Play();
										CharacterAnimation.CrossFade(RandomAnim);
										if (CharacterAnimation[RandomAnim].time >= CharacterAnimation[RandomAnim].length)
										{
											PickRandomAnim();
										}
										if (StudentManager.DramaTimer > 100f)
										{
											StudentManager.DramaTimer = 0f;
											StudentManager.UpdateDrama();
										}
									}
								}
								else if (Club == ClubType.Occult)
								{
									if (ReadPhase == 0)
									{
										CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										CharacterAnimation.CrossFade(BookSitAnim);
										if (CharacterAnimation[BookSitAnim].time > CharacterAnimation[BookSitAnim].length)
										{
											CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
											CharacterAnimation.CrossFade(BookReadAnim);
											ReadPhase++;
										}
										else if (CharacterAnimation[BookSitAnim].time > 1f)
										{
											OccultBook.SetActive(value: true);
										}
									}
								}
								else if (Club == ClubType.Art)
								{
									if (ClubAttire && !Paintbrush.activeInHierarchy && (double)Vector3.Distance(base.transform.position, CurrentDestination.position) < 0.5)
									{
										Paintbrush.SetActive(value: true);
										Palette.SetActive(value: true);
									}
								}
								else if (OriginalClub == ClubType.LightMusic)
								{
									if ((double)Clock.HourTime < 16.9)
									{
										Instruments[ClubMemberID].SetActive(value: true);
										CharacterAnimation.CrossFade(ClubAnim);
										if (StudentID == 51)
										{
											if (InstrumentBag[ClubMemberID].transform.parent != null)
											{
												InstrumentBag[ClubMemberID].transform.parent = null;
												if (!StudentManager.Eighties)
												{
													InstrumentBag[ClubMemberID].transform.position = new Vector3(0.5f, 4.5f, 22.45666f);
													InstrumentBag[ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
												}
												else
												{
													InstrumentBag[ClubMemberID].transform.position = new Vector3(2.06f, 4.5f, 26.5f);
													InstrumentBag[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
												}
											}
											if (Instruments[ClubMemberID].transform.parent == null)
											{
												Instruments[ClubMemberID].GetComponent<AudioSource>().Play();
												Instruments[ClubMemberID].transform.parent = base.transform;
												Instruments[ClubMemberID].transform.localPosition = new Vector3(0.340493f, 0.653502f, -0.286104f);
												Instruments[ClubMemberID].transform.localEulerAngles = new Vector3(-13.6139f, 16.16775f, 72.5293f);
											}
										}
										else if (StudentID == 54 && !Drumsticks[0].activeInHierarchy)
										{
											Instruments[ClubMemberID].GetComponent<AudioSource>().Play();
											Drumsticks[0].SetActive(value: true);
											Drumsticks[1].SetActive(value: true);
										}
									}
									else if (StudentID == 51)
									{
										_ = (bool)InstrumentBag[ClubMemberID].transform.parent;
										if (!StudentManager.Eighties)
										{
											InstrumentBag[ClubMemberID].transform.position = new Vector3(0.5f, 4.5f, 22.45666f);
											InstrumentBag[ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
										}
										else
										{
											InstrumentBag[ClubMemberID].transform.position = new Vector3(2.06f, 4.5f, 26.5f);
											InstrumentBag[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
										}
										InstrumentBag[ClubMemberID].transform.parent = null;
										if (!StudentManager.PracticeMusic.isPlaying)
										{
											CharacterAnimation.CrossFade("f02_vocalIdle_00");
										}
										else if (StudentManager.PracticeMusic.time > 114.5f)
										{
											CharacterAnimation.CrossFade("f02_vocalCelebrate_00");
										}
										else if (StudentManager.PracticeMusic.time > 104f)
										{
											CharacterAnimation.CrossFade("f02_vocalWait_00");
										}
										else if (StudentManager.PracticeMusic.time > 32f)
										{
											CharacterAnimation.CrossFade("f02_vocalSingB_00");
										}
										else if (StudentManager.PracticeMusic.time > 24f)
										{
											CharacterAnimation.CrossFade("f02_vocalSingB_00");
										}
										else if (StudentManager.PracticeMusic.time > 17f)
										{
											CharacterAnimation.CrossFade("f02_vocalSingB_00");
										}
										else if (StudentManager.PracticeMusic.time > 14f)
										{
											CharacterAnimation.CrossFade("f02_vocalWait_00");
										}
										else if (StudentManager.PracticeMusic.time > 8f)
										{
											CharacterAnimation.CrossFade("f02_vocalSingA_00");
										}
										else if (StudentManager.PracticeMusic.time > 0f)
										{
											CharacterAnimation.CrossFade("f02_vocalWait_00");
										}
									}
									else if (StudentID == 52)
									{
										if (!Instruments[ClubMemberID].activeInHierarchy)
										{
											Instruments[ClubMemberID].SetActive(value: true);
											Instruments[ClubMemberID].GetComponent<AudioSource>().Stop();
											Instruments[ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
											Instruments[ClubMemberID].transform.parent = Spine;
											Instruments[ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
											Instruments[ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
											InstrumentBag[ClubMemberID].transform.parent = null;
											InstrumentBag[ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 25f);
											InstrumentBag[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
										}
										if (!StudentManager.PracticeMusic.isPlaying)
										{
											CharacterAnimation.CrossFade("f02_guitarIdle_00");
										}
										else if (StudentManager.PracticeMusic.time > 114.5f)
										{
											CharacterAnimation.CrossFade("f02_guitarCelebrate_00");
										}
										else if (StudentManager.PracticeMusic.time > 112f)
										{
											CharacterAnimation.CrossFade("f02_guitarWait_00");
										}
										else if (StudentManager.PracticeMusic.time > 64f)
										{
											CharacterAnimation.CrossFade("f02_guitarPlayA_01");
										}
										else if (StudentManager.PracticeMusic.time > 8f)
										{
											CharacterAnimation.CrossFade("f02_guitarPlayA_00");
										}
										else if (StudentManager.PracticeMusic.time > 0f)
										{
											CharacterAnimation.CrossFade("f02_guitarWait_00");
										}
									}
									else if (StudentID == 53)
									{
										if (!Instruments[ClubMemberID].activeInHierarchy)
										{
											Instruments[ClubMemberID].SetActive(value: true);
											Instruments[ClubMemberID].GetComponent<AudioSource>().Stop();
											Instruments[ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
											Instruments[ClubMemberID].transform.parent = Spine;
											Instruments[ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
											Instruments[ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
											InstrumentBag[ClubMemberID].transform.parent = null;
											InstrumentBag[ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 26f);
											InstrumentBag[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
										}
										if (!StudentManager.PracticeMusic.isPlaying)
										{
											CharacterAnimation.CrossFade("f02_guitarIdle_00");
										}
										else if (StudentManager.PracticeMusic.time > 114.5f)
										{
											CharacterAnimation.CrossFade("f02_guitarCelebrate_00");
										}
										else if (StudentManager.PracticeMusic.time > 112f)
										{
											CharacterAnimation.CrossFade("f02_guitarWait_00");
										}
										else if (StudentManager.PracticeMusic.time > 88f)
										{
											CharacterAnimation.CrossFade("f02_guitarPlayA_00");
										}
										else if (StudentManager.PracticeMusic.time > 80f)
										{
											CharacterAnimation.CrossFade("f02_guitarWait_00");
										}
										else if (StudentManager.PracticeMusic.time > 64f)
										{
											CharacterAnimation.CrossFade("f02_guitarPlayB_00");
										}
										else if (StudentManager.PracticeMusic.time > 0f)
										{
											CharacterAnimation.CrossFade("f02_guitarPlaySlowA_01");
										}
									}
									else if (StudentID == 54)
									{
										if (InstrumentBag[ClubMemberID].transform.parent != null)
										{
											InstrumentBag[ClubMemberID].transform.parent = null;
											InstrumentBag[ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 23f);
											InstrumentBag[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
										}
										Drumsticks[0].SetActive(value: true);
										Drumsticks[1].SetActive(value: true);
										if (!StudentManager.PracticeMusic.isPlaying)
										{
											CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
										else if (StudentManager.PracticeMusic.time > 114.5f)
										{
											CharacterAnimation.CrossFade("f02_drumsCelebrate_00");
										}
										else if (StudentManager.PracticeMusic.time > 108f)
										{
											CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
										else if (StudentManager.PracticeMusic.time > 96f)
										{
											CharacterAnimation.CrossFade("f02_drumsPlaySlow_00");
										}
										else if (StudentManager.PracticeMusic.time > 80f)
										{
											CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
										else if (StudentManager.PracticeMusic.time > 38f)
										{
											CharacterAnimation.CrossFade("f02_drumsPlay_00");
										}
										else if (StudentManager.PracticeMusic.time > 46f)
										{
											CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
										else if (StudentManager.PracticeMusic.time > 16f)
										{
											CharacterAnimation.CrossFade("f02_drumsPlay_00");
										}
										else if (StudentManager.PracticeMusic.time > 0f)
										{
											CharacterAnimation.CrossFade("f02_drumsIdle_00");
										}
									}
									else if (StudentID == 55)
									{
										if (InstrumentBag[ClubMemberID].transform.parent != null)
										{
											InstrumentBag[ClubMemberID].transform.parent = null;
											InstrumentBag[ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 24f);
											InstrumentBag[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
										}
										if (!StudentManager.PracticeMusic.isPlaying)
										{
											CharacterAnimation.CrossFade("f02_keysIdle_00");
										}
										else if (StudentManager.PracticeMusic.time > 114.5f)
										{
											CharacterAnimation.CrossFade("f02_keysCelebrate_00");
										}
										else if (StudentManager.PracticeMusic.time > 80f)
										{
											CharacterAnimation.CrossFade("f02_keysWait_00");
										}
										else if (StudentManager.PracticeMusic.time > 24f)
										{
											CharacterAnimation.CrossFade("f02_keysPlay_00");
										}
										else if (StudentManager.PracticeMusic.time > 0f)
										{
											CharacterAnimation.CrossFade("f02_keysWait_00");
										}
									}
								}
								else if (Club == ClubType.Science)
								{
									if ((ClubAttire && !GoAway) || (StudentManager.Eighties && !GoAway))
									{
										if (SciencePhase == 0)
										{
											CharacterAnimation.CrossFade(ClubAnim);
										}
										else
										{
											CharacterAnimation.CrossFade(RummageAnim);
										}
										if ((double)Vector3.Distance(base.transform.position, CurrentDestination.position) < 0.5)
										{
											if (SciencePhase == 0)
											{
												if (!StudentManager.Eighties)
												{
													if (StudentID == 62)
													{
														ScienceProps[0].SetActive(value: true);
													}
													else if (StudentID == 63)
													{
														ScienceProps[1].SetActive(value: true);
														ScienceProps[2].SetActive(value: true);
													}
													else if (StudentID == 64)
													{
														ScienceProps[0].SetActive(value: true);
													}
												}
												else
												{
													if (!Male && !ScienceProps[1].activeInHierarchy)
													{
														CharacterAnimation.Play("f02_straightenSkirt_00");
													}
													ScienceProps[1].SetActive(value: true);
													ScienceProps[2].SetActive(value: true);
												}
											}
											if (StudentID > 61)
											{
												ClubTimer += Time.deltaTime;
												if (ClubTimer > 60f)
												{
													ClubTimer = 0f;
													SciencePhase++;
													if (SciencePhase == 1)
													{
														ClubTimer = 50f;
														Destinations[Phase] = StudentManager.SupplySpots[StudentID - 61];
														CurrentDestination = StudentManager.SupplySpots[StudentID - 61];
														Pathfinding.target = StudentManager.SupplySpots[StudentID - 61];
														GameObject[] scienceProps = ScienceProps;
														foreach (GameObject gameObject3 in scienceProps)
														{
															if (gameObject3 != null)
															{
																gameObject3.SetActive(value: false);
															}
														}
													}
													else
													{
														SciencePhase = 0;
														ClubTimer = 0f;
														Destinations[Phase] = StudentManager.Clubs.List[StudentID];
														CurrentDestination = StudentManager.Clubs.List[StudentID];
														Pathfinding.target = StudentManager.Clubs.List[StudentID];
													}
												}
											}
										}
									}
									else
									{
										CharacterAnimation.CrossFade(IdleAnim);
									}
								}
								else if (OriginalClub == ClubType.Sports)
								{
									CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
									if (ClubActivityPhase == 0)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											string text = "";
											if (!Male)
											{
												text = "f02_";
											}
											ClubActivityPhase++;
											ClubAnim = text + "stretch_01";
											Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase);
										}
									}
									else if (ClubActivityPhase == 1)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											string text2 = "";
											if (!Male)
											{
												text2 = "f02_";
											}
											ClubActivityPhase++;
											ClubAnim = text2 + "stretch_02";
											Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase);
										}
									}
									else if (ClubActivityPhase == 2)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											_ = Male;
											Hurry = true;
											ClubActivityPhase++;
											CharacterAnimation[ClubAnim].time = 0f;
											Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase);
										}
									}
									else if (ClubActivityPhase < 14)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											ClubActivityPhase++;
											CharacterAnimation[ClubAnim].time = 0f;
											Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase);
										}
									}
									else if (ClubActivityPhase == 14)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											WalkAnim = OriginalWalkAnim;
											string text3 = "";
											if (!Male)
											{
												text3 = "f02_";
											}
											Hurry = false;
											ClubActivityPhase = 0;
											ClubAnim = text3 + "stretch_00";
											Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase);
										}
									}
									else if (ClubActivityPhase == 15)
									{
										if (CharacterAnimation[ClubAnim].time >= 1f && MyController.radius > 0f)
										{
											MyRenderer.updateWhenOffscreen = true;
											Obstacle.enabled = false;
											MyController.radius = 0f;
											Distracted = true;
										}
										if (!StudentManager.Eighties && CharacterAnimation[ClubAnim].time >= 2f)
										{
											float value = Cosmetic.Goggles[StudentID].GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) + Time.deltaTime * 200f;
											Cosmetic.Goggles[StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, value);
										}
										if (CharacterAnimation[ClubAnim].time >= 5f)
										{
											ClubActivityPhase++;
										}
									}
									else if (ClubActivityPhase == 16)
									{
										if ((double)CharacterAnimation[ClubAnim].time >= 6.1)
										{
											if (!StudentManager.Eighties)
											{
												Cosmetic.Goggles[StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100f);
												Cosmetic.MaleHair[Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100f);
											}
											GameObject gameObject4 = UnityEngine.Object.Instantiate(BigWaterSplash, RightHand.transform.position, Quaternion.identity);
											gameObject4.transform.eulerAngles = new Vector3(-90f, gameObject4.transform.eulerAngles.y, gameObject4.transform.eulerAngles.z);
											SetSplashes(Bool: true);
											ClubActivityPhase++;
										}
									}
									else if (ClubActivityPhase == 17)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											WalkAnim = "poolSwim_00";
											ClubAnim = "poolSwim_00";
											ClubActivityPhase++;
											Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase - 2);
											base.transform.position = Hips.transform.position;
											Character.transform.localPosition = new Vector3(0f, -0.25f, 0f);
											Physics.SyncTransforms();
											CharacterAnimation.Play(WalkAnim);
										}
									}
									else if (ClubActivityPhase == 18)
									{
										ClubActivityPhase++;
										Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase - 2);
										DistanceToDestination = 100f;
									}
									else if (ClubActivityPhase == 19)
									{
										ClubAnim = "poolExit_00";
										if (CharacterAnimation[ClubAnim].time >= 0.1f)
										{
											SetSplashes(Bool: false);
										}
										if (!StudentManager.Eighties && CharacterAnimation[ClubAnim].time >= 4.66666f)
										{
											float value2 = Cosmetic.Goggles[StudentID].GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) - Time.deltaTime * 200f;
											Cosmetic.Goggles[StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, value2);
										}
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											ClubActivityPhase = 15;
											ClubAnim = "poolDive_00";
											MyController.radius = 0.1f;
											WalkAnim = OriginalWalkAnim;
											MyRenderer.updateWhenOffscreen = false;
											Character.transform.localPosition = new Vector3(0f, 0f, 0f);
											Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase);
											if (!StudentManager.Eighties)
											{
												Cosmetic.Goggles[StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
											}
											base.transform.position = new Vector3(Hips.position.x, 4f, Hips.position.z);
											Physics.SyncTransforms();
											CharacterAnimation.Play(IdleAnim);
											Distracted = false;
											if (Clock.Period == 2 || Clock.Period == 4)
											{
												Pathfinding.speed = 4f;
											}
										}
									}
								}
								else if (OriginalClub == ClubType.Gardening)
								{
									if ((!StudentManager.Eighties || WaterLow) && WateringCan.transform.parent != RightHand)
									{
										WateringCan.transform.parent = RightHand;
										WateringCan.transform.localPosition = new Vector3(0.14f, -0.15f, -0.05f);
										WateringCan.transform.localEulerAngles = new Vector3(10f, 15f, 45f);
									}
									PatrolTimer += Time.deltaTime * CharacterAnimation[PatrolAnim].speed;
									if (PatrolTimer >= CharacterAnimation[ClubAnim].length)
									{
										PatrolID++;
										if (PatrolID == StudentManager.Patrols.List[StudentID].childCount)
										{
											PatrolID = 0;
										}
										CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
										Pathfinding.target = CurrentDestination;
										PatrolTimer = 0f;
										if (!StudentManager.Eighties || WaterLow)
										{
											WateringCan.transform.parent = Hips;
											WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
											WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
										}
									}
								}
								else if (OriginalClub == ClubType.Gaming)
								{
									if (Phase < 8)
									{
										if (StudentID == 36 && !SmartPhone.activeInHierarchy)
										{
											SmartPhone.SetActive(value: true);
											SmartPhone.transform.localPosition = new Vector3(0.0566666f, -0.02f, 0f);
											SmartPhone.transform.localEulerAngles = new Vector3(10f, 115f, 180f);
										}
									}
									else
									{
										if (!ClubManager.GameScreens[ClubMemberID].activeInHierarchy)
										{
											ClubManager.GameScreens[ClubMemberID].SetActive(value: true);
											MyController.radius = 0.2f;
										}
										if (SmartPhone.activeInHierarchy)
										{
											SmartPhone.SetActive(value: false);
										}
									}
								}
								else if (Club == ClubType.Newspaper && StudentID > 36)
								{
									ClubTimer += Time.deltaTime;
									if (ClubTimer > 30f)
									{
										if (CurrentDestination.position.y > 0f)
										{
											CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(0);
											Pathfinding.target = CurrentDestination;
											ClubAnim = PatrolAnim;
										}
										else
										{
											CurrentDestination = StudentManager.Clubs.List[StudentID];
											Pathfinding.target = CurrentDestination;
											ClubAnim = OriginalClubAnim;
										}
										ClubTimer = 0f;
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.SitAndSocialize)
							{
								if (Paranoia > 1.66666f)
								{
									CharacterAnimation.CrossFade(IdleAnim);
								}
								else
								{
									StudentManager.ConvoManager.CheckMe(StudentID);
									if (Alone)
									{
										if (!Male)
										{
											CharacterAnimation.CrossFade("f02_standTexting_00");
										}
										else
										{
											CharacterAnimation.CrossFade("standTexting_00");
										}
										if (!SmartPhone.activeInHierarchy)
										{
											SmartPhone.SetActive(value: true);
											SpeechLines.Stop();
										}
									}
									else
									{
										if (!InEvent && !SpeechLines.isPlaying)
										{
											SmartPhone.SetActive(value: false);
											SpeechLines.Play();
										}
										if (Club != ClubType.Photography)
										{
											CharacterAnimation.CrossFade(RandomAnim);
											if (CharacterAnimation[RandomAnim].time >= CharacterAnimation[RandomAnim].length)
											{
												PickRandomAnim();
											}
										}
										else
										{
											CharacterAnimation.CrossFade(RandomSleuthAnim);
											if (CharacterAnimation[RandomSleuthAnim].time >= CharacterAnimation[RandomSleuthAnim].length)
											{
												PickRandomSleuthAnim();
											}
										}
									}
									if (StudentID == 56 && Clock.Day == 3)
									{
										BountyCollider.SetActive(value: true);
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.SitAndEatBento)
							{
								if (MustChangeClothing)
								{
									if (Schoolwear == 1 || Schoolwear == 3)
									{
										WalkAnim = OriginalWalkAnim;
										MustChangeClothing = false;
									}
									else
									{
										Debug.Log("Calling ChangeClothing() from here, specifically.");
										ChangeClothing();
									}
								}
								else if (!DiscCheck && Alarm < 100f)
								{
									if (!Ragdoll.Poisoned && (!Bento.activeInHierarchy || Bento.transform.parent == null))
									{
										SmartPhone.SetActive(value: false);
										if (!Male)
										{
											Bento.transform.parent = LeftItemParent;
											Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
											Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
										}
										else
										{
											Bento.transform.parent = LeftItemParent;
											Bento.transform.localPosition = new Vector3(-0.05f, -0.085f, 0f);
											Bento.transform.localEulerAngles = new Vector3(-3.2f, -24.4f, -94f);
										}
										Chopsticks[0].SetActive(value: true);
										Chopsticks[1].SetActive(value: true);
										Bento.SetActive(value: true);
										Lid.SetActive(value: false);
										MyBento.Prompt.Hide();
										MyBento.Prompt.enabled = false;
										if (MyBento.Tampered)
										{
											if (MyBento.Emetic)
											{
												Debug.Log(Name + "'s bento contains emetic medicine.");
												Emetic = true;
											}
											else if (MyBento.Lethal)
											{
												Lethal = true;
											}
											else if (MyBento.Tranquil)
											{
												Sedated = true;
											}
											else if (MyBento.Headache)
											{
												Debug.Log(Name + "'s bento contains headache medicine.");
												Headache = true;
											}
											Distracted = true;
											Alarm = 0f;
											UpdateDetectionMarker();
										}
									}
									if (!Emetic && !Lethal && !Sedated && !Headache)
									{
										CharacterAnimation.CrossFade(EatAnim);
										if (FollowTarget != null && ((FollowTarget.CurrentAction != StudentActionType.SitAndEatBento && !FollowTarget.Dying && !FollowTarget.Emetic) || Clock.HourTime > 13.375f))
										{
											if (FollowTarget.Alive)
											{
												Debug.Log("Osana is no longer eating, so Raibaru is now following Osana.");
												CharacterAnimation.CrossFade(WalkAnim);
												EmptyHands();
												Pathfinding.canSearch = true;
												Pathfinding.canMove = true;
												ScheduleBlock obj6 = ScheduleBlocks[4];
												obj6.destination = "Follow";
												obj6.action = "Follow";
												ScheduleBlock obj7 = ScheduleBlocks[5];
												obj7.destination = "Follow";
												obj7.action = "Follow";
												GetDestinations();
												Pathfinding.target = FollowTarget.transform;
												CurrentDestination = FollowTarget.transform;
											}
											else
											{
												Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 5, 10f);
												RaibaruOsanaDeathScheduleChanges();
												RaibaruStopsFollowingOsana();
												GetDestinations();
												CurrentDestination = Destinations[Phase];
												Pathfinding.target = Destinations[Phase];
											}
										}
									}
									else if (Emetic)
									{
										if (!Private)
										{
											CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											CharacterAnimation.CrossFade(EmeticAnim);
											Distracted = true;
											Private = true;
											CanTalk = false;
										}
										if (CharacterAnimation[EmeticAnim].time >= 16f)
										{
											if (StudentID == 10)
											{
												if (VomitPhase < 0)
												{
													Subtitle.UpdateLabel(SubtitleType.ObstaclePoisonReaction, 0, 9f);
													VomitPhase++;
												}
											}
											else if (StudentID == 11 && Follower != null)
											{
												StudentManager.LastKnownOsana.position = base.transform.position;
											}
										}
										if (CharacterAnimation[EmeticAnim].time >= CharacterAnimation[EmeticAnim].length)
										{
											GoPuke();
										}
									}
									else if (Lethal)
									{
										if (!Private)
										{
											AudioSource component = GetComponent<AudioSource>();
											component.clip = PoisonDeathClip;
											component.Play();
											if (Male)
											{
												CharacterAnimation.CrossFade("poisonDeath_00");
												PoisonDeathAnim = "poisonDeath_00";
											}
											else
											{
												CharacterAnimation.CrossFade("f02_poisonDeath_00");
												PoisonDeathAnim = "f02_poisonDeath_00";
												Distracted = true;
											}
											CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											MyRenderer.updateWhenOffscreen = true;
											Ragdoll.Poisoned = true;
											Private = true;
											Prompt.Hide();
											Prompt.enabled = false;
										}
										else if (StudentID == 11 && StudentManager.Students[1] != null && !StudentManager.Students[1].SenpaiWitnessingRivalDie && Vector3.Distance(base.transform.position, StudentManager.Students[1].transform.position) < 2f)
										{
											Debug.Log("Setting ''SenpaiWitnessingRivalDie'' to true.");
											StudentManager.Students[1].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											StudentManager.Students[1].CharacterAnimation.CrossFade("witnessPoisoning_00");
											StudentManager.Students[1].CurrentDestination = StudentManager.LunchSpots.List[1];
											StudentManager.Students[1].Pathfinding.target = StudentManager.LunchSpots.List[1];
											StudentManager.Students[1].MyRenderer.updateWhenOffscreen = true;
											StudentManager.Students[1].SenpaiWitnessingRivalDie = true;
											StudentManager.Students[1].Distracted = true;
											StudentManager.Students[1].Routine = false;
										}
										if (!Distracted && CharacterAnimation[PoisonDeathAnim].time >= 2.5f)
										{
											Distracted = true;
										}
										if (CharacterAnimation[PoisonDeathAnim].time >= 17.5f && Bento.activeInHierarchy)
										{
											Police.CorpseList[Police.Corpses] = Ragdoll;
											Police.Corpses++;
											GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
											MapMarker.gameObject.layer = 10;
											base.tag = "Blood";
											Ragdoll.ChokingAnimation = true;
											Ragdoll.Disturbing = true;
											Ragdoll.Choking = true;
											Dying = true;
											MurderSuicidePhase = 100;
											SpawnAlarmDisc();
											Debug.Log(Name + " just spawned an 'AlarmDisc'.");
											Chopsticks[0].SetActive(value: false);
											Chopsticks[1].SetActive(value: false);
											Bento.SetActive(value: false);
										}
										if (CharacterAnimation[PoisonDeathAnim].time >= CharacterAnimation[PoisonDeathAnim].length)
										{
											BecomeRagdoll();
											DeathType = DeathType.Poison;
											Ragdoll.Choking = false;
											if (StudentManager.Students[1].SenpaiWitnessingRivalDie)
											{
												Ragdoll.Prompt.Hide();
												Ragdoll.Prompt.enabled = false;
											}
										}
									}
									else if (Sedated)
									{
										if (!Private)
										{
											Debug.Log(Name + " is beginning to eat food that has been poisoned with a sedative.");
											CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											CharacterAnimation.CrossFade(HeadacheAnim);
											Distracted = true;
											CanTalk = false;
											Private = true;
										}
										if (CharacterAnimation[HeadacheAnim].time >= CharacterAnimation[HeadacheAnim].length)
										{
											CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
											if (Male)
											{
												SprintAnim = "headacheWalk_00";
												RelaxAnim = "infirmaryRest_00";
											}
											else
											{
												SprintAnim = "f02_headacheWalk_00";
												RelaxAnim = "f02_infirmaryRest_00";
											}
											CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
											CharacterAnimation.CrossFade(SprintAnim);
											DistanceToDestination = 100f;
											Pathfinding.canSearch = true;
											Pathfinding.canMove = true;
											Pathfinding.speed = 2f;
											MyBento.Tampered = false;
											Private = true;
											Sleepy = true;
											ScheduleBlock obj8 = ScheduleBlocks[4];
											obj8.destination = "InfirmaryBed";
											obj8.action = "Relax";
											Oversleep();
											GetDestinations();
											CurrentDestination = Destinations[Phase];
											Pathfinding.target = Destinations[Phase];
											Chopsticks[0].SetActive(value: false);
											Chopsticks[1].SetActive(value: false);
											Bento.SetActive(value: false);
										}
									}
									else if (Headache)
									{
										if (!Private)
										{
											CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											CharacterAnimation.CrossFade(HeadacheAnim);
											CanTalk = false;
											Private = true;
										}
										if (CharacterAnimation[HeadacheAnim].time >= CharacterAnimation[HeadacheAnim].length)
										{
											CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
											if (Male)
											{
												SprintAnim = "headacheWalk_00";
												IdleAnim = "headacheIdle_00";
											}
											else
											{
												SprintAnim = "f02_headacheWalk_00";
												IdleAnim = "f02_headacheIdle_00";
											}
											CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
											CharacterAnimation.CrossFade(SprintAnim);
											DistanceToDestination = 100f;
											Pathfinding.canSearch = true;
											Pathfinding.canMove = true;
											Pathfinding.speed = 2f;
											MyBento.Tampered = false;
											SeekingMedicine = true;
											Routine = false;
											Private = true;
											Chopsticks[0].SetActive(value: false);
											Chopsticks[1].SetActive(value: false);
											Bento.SetActive(value: false);
										}
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.ChangeShoes)
							{
								if (MustChangeClothing)
								{
									Debug.Log("Calling ChangeClothing() from here, specifically.");
									ChangeClothing();
								}
								else if (MeetTime == 0f)
								{
									if ((StudentID == 1 && !StudentManager.LoveManager.ConfessToSuitor && StudentManager.LoveManager.LeftNote) || (StudentID == StudentManager.LoveManager.SuitorID && StudentManager.LoveManager.ConfessToSuitor && StudentManager.LoveManager.LeftNote))
									{
										if (StudentID == 1)
										{
											Debug.Log("Senpai is now checking their locker...");
										}
										CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										if (Male)
										{
											CharacterAnimation.CrossFade("keepNote_00");
										}
										else
										{
											CharacterAnimation.CrossFade("f02_keepNote_00");
										}
										Pathfinding.canSearch = false;
										Pathfinding.canMove = false;
										Confessing = true;
										CanTalk = false;
										Routine = false;
									}
									else
									{
										SmartPhone.SetActive(value: false);
										Pathfinding.canSearch = false;
										Pathfinding.canMove = false;
										ShoeRemoval.enabled = true;
										CanTalk = false;
										Routine = false;
										ShoeRemoval.LeavingSchool();
									}
								}
								else
								{
									CharacterAnimation.CrossFade(IdleAnim);
								}
							}
							else if (Actions[Phase] == StudentActionType.GradePapers)
							{
								CharacterAnimation.CrossFade("f02_deskWrite");
								GradingPaper.Writing = true;
								Obstacle.enabled = true;
								Pen.SetActive(value: true);
							}
							else if (Actions[Phase] == StudentActionType.Patrol)
							{
								if (PatrolAnim == "")
								{
									PatrolAnim = IdleAnim;
								}
								if (StudentID == 1 && ExtraBento && CurrentDestination == StudentManager.Patrols.List[StudentID].GetChild(0))
								{
									StudentManager.MondayBento.SetActive(value: true);
									ExtraBento = false;
									if (Infatuated)
									{
										Debug.Log("Senpai is now changing his routine to go stalk the gravure idol.");
										StudentManager.StalkerID = 0;
										StudentManager.FollowGravureIdol(1);
										CurrentDestination = Destinations[Phase];
										Pathfinding.target = Destinations[Phase];
									}
									else if (StudentManager.CustomMode)
									{
										Debug.Log("Attempting to update Senpai's routine to whatever his Custom Mode routine is supposed to be.");
										ScheduleBlock obj9 = ScheduleBlocks[Phase];
										ScheduleBlock scheduleBlock = OriginalScheduleBlocks[Phase];
										obj9.destination = scheduleBlock.destination;
										obj9.action = scheduleBlock.action;
										obj9.destination = ReturnDestination;
										obj9.action = ReturnAction;
										GetDestinations();
										CurrentDestination = Destinations[Phase];
										Pathfinding.target = Destinations[Phase];
									}
								}
								PatrolTimer += Time.deltaTime * CharacterAnimation[PatrolAnim].speed;
								if (StudentManager.Eighties && StudentID == 13)
								{
									if (PatrolID == 0)
									{
										PatrolAnim = BookReadAnim;
										OccultBook.SetActive(value: true);
									}
									else
									{
										PatrolAnim = ThinkAnim;
									}
								}
								if (StudentID == 1)
								{
									if (PatrolID == 0)
									{
										if (StudentManager.Gift.activeInHierarchy || StudentManager.Note.activeInHierarchy)
										{
											CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											CharacterAnimation.CrossFade(InspectBloodAnim);
											if (CharacterAnimation[InspectBloodAnim].time >= CharacterAnimation[InspectBloodAnim].length)
											{
												StudentManager.SenpaiLoveWindow.UpdateSenpaiLove();
												StudentManager.Gift.SetActive(value: false);
												StudentManager.Note.SetActive(value: false);
											}
										}
										else
										{
											CharacterAnimation.CrossFade(PatrolAnim);
										}
									}
									else
									{
										CharacterAnimation.CrossFade(PatrolAnim);
									}
								}
								else
								{
									CharacterAnimation.CrossFade(PatrolAnim);
								}
								if (PatrolTimer >= CharacterAnimation[PatrolAnim].length || Pathfinding.target == null)
								{
									PatrolID++;
									if (PatrolID == StudentManager.Patrols.List[StudentID].childCount || Pathfinding.target == null)
									{
										PatrolID = 0;
									}
									CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
									Pathfinding.target = CurrentDestination;
									OccultBook.SetActive(value: false);
									PatrolTimer = 0f;
								}
								if (Restless)
								{
									SewTimer += Time.deltaTime;
									if (SewTimer > 20f)
									{
										CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										ScheduleBlock obj10 = ScheduleBlocks[Phase];
										obj10.destination = "Sketch";
										obj10.action = "Sketch";
										GetDestinations();
										CurrentDestination = SketchPosition;
										Pathfinding.target = SketchPosition;
										SewTimer = 0f;
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Read)
							{
								if (ReadPhase == 0)
								{
									if (StudentID == 5)
									{
										HorudaCollider.gameObject.SetActive(value: true);
									}
									CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
									CharacterAnimation.CrossFade(BookSitAnim);
									if (CharacterAnimation[BookSitAnim].time > CharacterAnimation[BookSitAnim].length)
									{
										CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
										CharacterAnimation.CrossFade(BookReadAnim);
										ReadPhase++;
									}
									else if (CharacterAnimation[BookSitAnim].time > 1f)
									{
										OccultBook.SetActive(value: true);
									}
								}
								if (Rival)
								{
									ReadTimer += Time.deltaTime;
									if (ReadTimer > 300f)
									{
										OccultBook.SetActive(value: false);
										ScheduleBlock obj11 = ScheduleBlocks[Phase];
										obj11.destination = "LunchSpot";
										obj11.action = "SitAndEatBento";
										Actions[Phase] = StudentActionType.SitAndEatBento;
										CurrentAction = StudentActionType.SitAndEatBento;
										GetDestinations();
										CurrentDestination = Destinations[Phase];
										Pathfinding.target = Destinations[Phase];
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Texting)
							{
								CharacterAnimation.CrossFade("f02_midoriTexting_00");
								if (SmartPhone.transform.localPosition.x != 0.02f)
								{
									SmartPhone.transform.localPosition = new Vector3(0.02f, -0.0075f, 0f);
									SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, -164f);
								}
								if (!SmartPhone.activeInHierarchy && base.transform.position.y > 11f)
								{
									SmartPhone.SetActive(value: true);
								}
							}
							else if (Actions[Phase] == StudentActionType.Mourn)
							{
								CharacterAnimation.CrossFade("f02_brokenSit_00");
							}
							else if (Actions[Phase] == StudentActionType.Cuddle)
							{
								if (Vector3.Distance(base.transform.position, Partner.transform.position) < 1f && Partner.Routine)
								{
									ParticleSystem.EmissionModule emission = Hearts.emission;
									if (!emission.enabled)
									{
										Hearts.Play();
										emission.enabled = true;
										if (!Male)
										{
											Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
										}
										else
										{
											Cosmetic.MyRenderer.materials[Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
										}
									}
									if (CuddlePartnerID == 1)
									{
										if (Male)
										{
											CharacterAnimation.CrossFade(CuddleAnim);
										}
										else
										{
											CharacterAnimation.CrossFade("f02_cuddle_00");
										}
									}
									else if (!Male)
									{
										CharacterAnimation.CrossFade(CuddleAnim);
									}
									else
									{
										CharacterAnimation.CrossFade("cuddle_00");
									}
								}
								else
								{
									CharacterAnimation.CrossFade(IdleAnim);
								}
							}
							else if (Actions[Phase] == StudentActionType.Teaching)
							{
								if (Clock.Period != 2 && Clock.Period != 4)
								{
									CharacterAnimation.CrossFade("f02_teacherPodium_00");
								}
								else
								{
									if (!SpeechLines.isPlaying)
									{
										SpeechLines.Play();
									}
									CharacterAnimation.CrossFade(TeachAnim);
								}
							}
							else if (Actions[Phase] == StudentActionType.SearchPatrol)
							{
								if (PatrolID == 0 && StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !EndSearch)
								{
									if (Rival)
									{
										LewdPhotos = StudentManager.CommunalLocker.RivalPhone.LewdPhotos;
										if (DateGlobals.Weekday == DayOfWeek.Monday)
										{
											SchemeGlobals.SetSchemeStage(1, 8);
											Yandere.PauseScreen.Schemes.UpdateInstructions();
										}
									}
									CharacterAnimation.CrossFade(DiscoverPhoneAnim);
									Subtitle.UpdateLabel(LostPhoneSubtitleType, 2, 5f);
									Debug.Log(Name + " found her lost phone from this spot in the code. 2");
									SearchingForPhone = false;
									Phoneless = false;
									EndSearch = true;
									Routine = false;
									PatrolTimer = 0f;
									if (EventToSabotage != null)
									{
										EventToSabotage.gameObject.SetActive(value: true);
									}
								}
								if (!EndSearch)
								{
									PatrolTimer += Time.deltaTime * CharacterAnimation[SearchPatrolAnim].speed;
									CharacterAnimation.CrossFade(SearchPatrolAnim);
									if (PatrolTimer >= CharacterAnimation[SearchPatrolAnim].length)
									{
										PatrolID++;
										if (PatrolID == StudentManager.SearchPatrols.List[Class].childCount)
										{
											PatrolID = 0;
										}
										CurrentDestination = StudentManager.SearchPatrols.List[Class].GetChild(PatrolID);
										Pathfinding.target = CurrentDestination;
										DistanceToDestination = 100f;
										PatrolTimer = 0f;
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Wait)
							{
								CharacterAnimation.CrossFade(IdleAnim);
							}
							else if (Actions[Phase] == StudentActionType.LightCig)
							{
								if (!Cigarette.active)
								{
									if (!Male)
									{
										WaitAnim = "f02_smokeAttempt_00";
									}
									else
									{
										WaitAnim = "smokeAttempt_00";
									}
									SmartPhone.SetActive(value: false);
									Cigarette.SetActive(value: true);
									Lighter.SetActive(value: true);
								}
								CharacterAnimation.CrossFade(WaitAnim);
							}
							else if (Actions[Phase] == StudentActionType.Random)
							{
								CurrentDestination.transform.position = StudentManager.PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
							}
							else if (Actions[Phase] == StudentActionType.Clean)
							{
								if (CleanTimer == 0f)
								{
									EquipCleaningItems();
								}
								CleanTimer += Time.deltaTime;
								if (CleaningRole == 5)
								{
									if (CleanID == 0)
									{
										CharacterAnimation.CrossFade(CleanAnims[1]);
									}
									else
									{
										if (!StudentManager.RoofFenceUp)
										{
											Pushable = true;
											StudentManager.UpdateMe(StudentID);
										}
										CharacterAnimation.CrossFade(CleanAnims[CleaningRole]);
										if ((double)CleanTimer >= 1.166666 && (double)CleanTimer <= 6.166666 && !ChalkDust.isPlaying)
										{
											ChalkDust.Play();
										}
									}
								}
								else if (CleaningRole == 4)
								{
									CharacterAnimation.CrossFade(CleanAnims[CleaningRole]);
									if (!Drownable)
									{
										Drownable = true;
										StudentManager.UpdateMe(StudentID);
									}
								}
								else
								{
									CharacterAnimation.CrossFade(CleanAnims[CleaningRole]);
								}
								if (CleanTimer >= CharacterAnimation[CleanAnims[CleaningRole]].length)
								{
									CleanID++;
									if (CleanID == CleaningSpot.childCount)
									{
										CleanID = 0;
									}
									CurrentDestination = CleaningSpot.GetChild(CleanID);
									Pathfinding.target = CurrentDestination;
									DistanceToDestination = 100f;
									CleanTimer = 0f;
									if (Pushable)
									{
										Prompt.Label[0].text = "     Talk";
										Pushable = false;
										StudentManager.UpdateMe(StudentID);
									}
									if (Drownable)
									{
										Drownable = false;
										StudentManager.UpdateMe(StudentID);
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Graffiti)
							{
								if (KilledMood)
								{
									Subtitle.UpdateLabel(SubtitleType.KilledMood, 0, 5f);
									GraffitiPhase = 4;
									KilledMood = false;
								}
								if (GraffitiPhase == 0)
								{
									AudioSource.PlayClipAtPoint(BullyGiggles[UnityEngine.Random.Range(0, BullyGiggles.Length)], Head.position);
									CharacterAnimation.CrossFade("f02_bullyDesk_00");
									SmartPhone.SetActive(value: false);
									GraffitiPhase++;
								}
								else if (GraffitiPhase == 1)
								{
									if (CharacterAnimation["f02_bullyDesk_00"].time >= 8f)
									{
										StudentManager.Graffiti[BullyID].SetActive(value: true);
										GraffitiPhase++;
									}
								}
								else if (GraffitiPhase == 2)
								{
									if (CharacterAnimation["f02_bullyDesk_00"].time >= 9.66666f)
									{
										AudioSource.PlayClipAtPoint(BullyGiggles[UnityEngine.Random.Range(0, BullyGiggles.Length)], Head.position);
										GraffitiPhase++;
									}
								}
								else if (GraffitiPhase == 3)
								{
									if (CharacterAnimation["f02_bullyDesk_00"].time >= CharacterAnimation["f02_bullyDesk_00"].length)
									{
										GraffitiPhase++;
									}
								}
								else if (GraffitiPhase == 4)
								{
									DistanceToDestination = 100f;
									ScheduleBlock obj12 = ScheduleBlocks[2];
									obj12.destination = "Patrol";
									obj12.action = "Patrol";
									GetDestinations();
									if (!StudentManager.Eighties)
									{
										if (StudentID == 82)
										{
											StudentManager.UpdateWeek1Hangout(82);
										}
										else if (StudentID == 83)
										{
											StudentManager.UpdateWeek1Hangout(83);
										}
									}
									CurrentDestination = Destinations[Phase];
									Pathfinding.target = Destinations[Phase];
									SmartPhone.SetActive(value: true);
								}
							}
							else if (Actions[Phase] == StudentActionType.Bully)
							{
								CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
								if (StudentManager.Students[StudentManager.VictimID] != null && StudentManager.Students[StudentManager.VictimID].Alive && !StudentManager.Students[StudentManager.VictimID].Tranquil)
								{
									if (StudentManager.Students[StudentManager.VictimID].Distracted)
									{
										StudentManager.NoBully[BullyID] = true;
										KilledMood = true;
									}
									if (KilledMood)
									{
										Subtitle.UpdateLabel(SubtitleType.KilledMood, 0, 5f);
										BullyPhase = 4;
										KilledMood = false;
										BullyDust.Stop();
									}
									if (StudentManager.Students[81] == null)
									{
										ScheduleBlock obj13 = ScheduleBlocks[4];
										obj13.destination = "Patrol";
										obj13.action = "Patrol";
										GetDestinations();
										CurrentDestination = Destinations[Phase];
										Pathfinding.target = Destinations[Phase];
									}
									else
									{
										SmartPhone.SetActive(value: false);
										if (BullyID == 1)
										{
											if (BullyPhase == 0)
											{
												Scrubber.GetComponent<Renderer>().material.mainTexture = Eraser.GetComponent<Renderer>().material.mainTexture;
												Scrubber.SetActive(value: true);
												Eraser.SetActive(value: true);
												StudentManager.Students[StudentManager.VictimID].CharacterAnimation.CrossFade(StudentManager.Students[StudentManager.VictimID].BullyVictimAnim);
												StudentManager.Students[StudentManager.VictimID].Routine = false;
												CharacterAnimation.CrossFade("f02_bullyEraser_00");
												BullyPhase++;
											}
											else if (BullyPhase == 1)
											{
												if (CharacterAnimation["f02_bullyEraser_00"].time >= 0.833333f)
												{
													BullyDust.Play();
													BullyPhase++;
												}
											}
											else if (BullyPhase == 2)
											{
												if (CharacterAnimation["f02_bullyEraser_00"].time >= CharacterAnimation["f02_bullyEraser_00"].length)
												{
													AudioSource.PlayClipAtPoint(BullyLaughs[BullyID], Head.position);
													CharacterAnimation.CrossFade("f02_bullyLaugh_00");
													Scrubber.SetActive(value: false);
													Eraser.SetActive(value: false);
													BullyPhase++;
												}
											}
											else if (BullyPhase == 3)
											{
												if (CharacterAnimation["f02_bullyLaugh_00"].time >= CharacterAnimation["f02_bullyLaugh_00"].length)
												{
													BullyPhase++;
												}
											}
											else if (BullyPhase == 4)
											{
												CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												StudentManager.Students[StudentManager.VictimID].Routine = true;
												ScheduleBlock obj14 = ScheduleBlocks[4];
												obj14.destination = "Patrol";
												obj14.action = "Patrol";
												GetDestinations();
												if (!StudentManager.Eighties)
												{
													if (StudentID == 82)
													{
														StudentManager.UpdateLunchtimeHangout(82);
													}
													else if (StudentID == 83)
													{
														StudentManager.UpdateLunchtimeHangout(83);
													}
												}
												CurrentDestination = Destinations[Phase];
												Pathfinding.target = Destinations[Phase];
												SmartPhone.SetActive(value: true);
												Scrubber.SetActive(value: false);
												Eraser.SetActive(value: false);
											}
										}
										else
										{
											if (StudentManager.Students[81].BullyPhase < 2)
											{
												if (GiggleTimer == 0f)
												{
													AudioSource.PlayClipAtPoint(BullyGiggles[UnityEngine.Random.Range(0, BullyGiggles.Length)], Head.position);
													GiggleTimer = 5f;
												}
												GiggleTimer = Mathf.MoveTowards(GiggleTimer, 0f, Time.deltaTime);
												CharacterAnimation.CrossFade("f02_bullyGiggle_00");
											}
											else if (StudentManager.Students[81].BullyPhase < 4)
											{
												if (LaughTimer == 0f)
												{
													AudioSource.PlayClipAtPoint(BullyLaughs[BullyID], Head.position);
													LaughTimer = 5f;
												}
												LaughTimer = Mathf.MoveTowards(LaughTimer, 0f, Time.deltaTime);
												CharacterAnimation.CrossFade("f02_bullyLaugh_00");
											}
											if (CharacterAnimation["f02_bullyLaugh_00"].time >= CharacterAnimation["f02_bullyLaugh_00"].length || StudentManager.Students[81].BullyPhase == 4 || BullyPhase == 4)
											{
												Debug.Log("The bullying event has ended.");
												CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												DistanceToDestination = 100f;
												ScheduleBlock obj15 = ScheduleBlocks[4];
												obj15.destination = "Patrol";
												obj15.action = "Patrol";
												GetDestinations();
												CurrentDestination = Destinations[Phase];
												Pathfinding.target = Destinations[Phase];
												SmartPhone.SetActive(value: true);
											}
										}
									}
								}
								else
								{
									Debug.Log("This code is called when the bullies' victim is missing or dead.");
									CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
									DistanceToDestination = 100f;
									ScheduleBlock obj16 = ScheduleBlocks[Phase];
									obj16.destination = "Patrol";
									obj16.action = "Patrol";
									GetDestinations();
									CurrentDestination = Destinations[Phase];
									Pathfinding.target = Destinations[Phase];
									SmartPhone.SetActive(value: true);
								}
							}
							else if (Actions[Phase] == StudentActionType.Follow)
							{
								if (FollowTarget != null)
								{
									if (StudentManager.LoveManager.RivalWaiting && FollowTarget.transform.position.x > 40f && FollowTarget.DistanceToDestination < 1f)
									{
										CurrentDestination = StudentManager.LoveManager.FriendWaitSpot;
										Pathfinding.target = StudentManager.LoveManager.FriendWaitSpot;
										CharacterAnimation.CrossFade(IdleAnim);
									}
									else if (FollowTarget.Routine && !FollowTarget.InEvent && FollowTarget.CurrentAction == StudentActionType.Clean && FollowTarget.DistanceToDestination < 1f)
									{
										FollowTarget.FollowTargetDestination.localPosition = new Vector3(-1f, 0f, -1f);
										CurrentDestination = FollowTarget.FollowTargetDestination;
										Pathfinding.target = FollowTarget.FollowTargetDestination;
										CharacterAnimation.CrossFade(CleanAnims[CleaningRole]);
										Scrubber.SetActive(value: true);
										if (CharacterAnimation[CleanAnims[CleaningRole]].time > CharacterAnimation[CleanAnims[CleaningRole]].length)
										{
											CharacterAnimation[CleanAnims[CleaningRole]].time = 1f;
										}
									}
									else if (FollowTarget.Routine && !FollowTarget.InEvent && !FollowTarget.Meeting && FollowTarget.gameObject.activeInHierarchy && FollowTarget.CurrentAction == StudentActionType.Socializing && FollowTarget.DistanceToDestination < 1f)
									{
										if (FollowTarget.Alone || FollowTarget.Meeting)
										{
											CharacterAnimation.CrossFade(IdleAnim);
											SpeechLines.Stop();
										}
										else
										{
											Scrubber.SetActive(value: false);
											SpeechLines.Play();
											CharacterAnimation.CrossFade(RandomAnim);
											if (CharacterAnimation[RandomAnim].time >= CharacterAnimation[RandomAnim].length)
											{
												PickRandomAnim();
											}
										}
									}
									else if (FollowTarget.CurrentAction == StudentActionType.SitAndTakeNotes && FollowTarget.Routine && !FollowTarget.InEvent && FollowTarget.DistanceToDestination < 1f && !FollowTarget.Meeting && Clock.HourTime < 15.5f)
									{
										Debug.Log("Raibaru just changed her destination to class.");
										GoToClass();
									}
									else if (FollowTarget.Routine && !FollowTarget.InEvent && FollowTarget.CurrentAction == StudentActionType.SitAndEatBento && FollowTarget.DistanceToDestination < 1f && !FollowTarget.Meeting)
									{
										Debug.Log("Raibaru just changed her destination to lunch.");
										ScheduleBlock obj17 = ScheduleBlocks[Phase];
										obj17.destination = "LunchSpot";
										obj17.action = "SitAndEatBento";
										Actions[Phase] = StudentActionType.SitAndEatBento;
										CurrentAction = StudentActionType.SitAndEatBento;
										GetDestinations();
										CurrentDestination = Destinations[Phase];
										Pathfinding.target = Destinations[Phase];
									}
									else if (FollowTarget.Routine && !FollowTarget.InEvent && FollowTarget.Phase == 8 && FollowTarget.DistanceToDestination < 1f)
									{
										Debug.Log("Raibaru just changed her destination to the lockers.");
										ScheduleBlock obj18 = ScheduleBlocks[Phase];
										obj18.destination = "Locker";
										obj18.action = "Shoes";
										Actions[Phase] = StudentActionType.ChangeShoes;
										CurrentAction = StudentActionType.ChangeShoes;
										GetDestinations();
										CurrentDestination = Destinations[Phase];
										Pathfinding.target = Destinations[Phase];
									}
									else if (FollowTarget.ConfessPhase == 5)
									{
										Debug.Log("Raibaru just changed her action to Sketch and her destination to Paint.");
										ScheduleBlock obj19 = ScheduleBlocks[Phase];
										obj19.destination = "Paint";
										obj19.action = "Sketch";
										obj19.time = 99f;
										GetDestinations();
										CurrentDestination = Destinations[Phase];
										Pathfinding.target = Destinations[Phase];
										TargetDistance = 1f;
										MyController.radius = 0.1f;
									}
									else
									{
										CharacterAnimation.CrossFade(IdleAnim);
										SpeechLines.Stop();
										if (SlideIn)
										{
											MoveTowardsTarget(CurrentDestination.position);
										}
										if (!FollowTarget.gameObject.activeInHierarchy || !FollowTarget.enabled)
										{
											if (base.transform.position.y > -1f)
											{
												Debug.Log("Raibaru cannot find Osana.");
												RaibaruCannotFindOsana();
											}
											else
											{
												Debug.Log("Osana left school, so Raibaru is disabling herself, too.");
												base.gameObject.SetActive(value: false);
											}
										}
										else
										{
											CharacterAnimation.CrossFade(IdleAnim);
										}
									}
								}
								else
								{
									CharacterAnimation.CrossFade(IdleAnim);
								}
							}
							else if (Actions[Phase] == StudentActionType.Sulk)
							{
								if (StudentID == 51)
								{
									CharacterAnimation.CrossFade("f02_railingSulk_0" + SulkPhase, 1f);
									SulkTimer += Time.deltaTime;
									if (SulkTimer > 7.66666f)
									{
										SulkTimer = 0f;
										SulkPhase++;
										if (SulkPhase == 3)
										{
											SulkPhase = 0;
										}
									}
								}
								else
								{
									CharacterAnimation.CrossFade(SulkAnim);
									if (StudentID == 76 && Clock.Day == 4)
									{
										BountyCollider.SetActive(value: true);
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Sleuth)
							{
								if (StudentManager.SleuthPhase != 3)
								{
									StudentManager.ConvoManager.CheckMe(StudentID);
									if (Alone)
									{
										if (Male)
										{
											CharacterAnimation.CrossFade("standTexting_00");
										}
										else
										{
											CharacterAnimation.CrossFade("f02_standTexting_00");
										}
										if (Male)
										{
											SmartPhone.transform.localPosition = new Vector3(0.025f, 0.0025f, 0.025f);
											SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 180f);
										}
										else
										{
											SmartPhone.transform.localPosition = new Vector3(0.01f, 0.01f, 0.01f);
											SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
										}
										SmartPhone.SetActive(value: true);
										SpeechLines.Stop();
									}
									else
									{
										if (!SpeechLines.isPlaying)
										{
											SmartPhone.SetActive(value: false);
											SpeechLines.Play();
										}
										CharacterAnimation.CrossFade(RandomSleuthAnim, 1f);
										if (CharacterAnimation[RandomSleuthAnim].time >= CharacterAnimation[RandomSleuthAnim].length)
										{
											PickRandomSleuthAnim();
										}
										StudentManager.SleuthTimer += Time.deltaTime;
										if (StudentManager.SleuthTimer > 100f)
										{
											StudentManager.SleuthTimer = 0f;
											StudentManager.UpdateSleuths();
										}
									}
								}
								else
								{
									CharacterAnimation.CrossFade(SleuthScanAnim);
									if (CharacterAnimation[SleuthScanAnim].time >= CharacterAnimation[SleuthScanAnim].length)
									{
										GetSleuthTarget();
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Stalk)
							{
								CharacterAnimation.CrossFade(SleuthIdleAnim);
								if (DistanceToPlayer < 5f || StudentManager.LockerRoomArea.bounds.Contains(Yandere.transform.position))
								{
									if (Vector3.Distance(base.transform.position, StudentManager.FleeSpots[0].position) > 10f)
									{
										Pathfinding.target = StudentManager.FleeSpots[0];
										CurrentDestination = StudentManager.FleeSpots[0];
									}
									else
									{
										Pathfinding.target = StudentManager.FleeSpots[1];
										CurrentDestination = StudentManager.FleeSpots[1];
									}
									Pathfinding.speed = 4f;
									StalkerFleeing = true;
								}
							}
							else if (Actions[Phase] == StudentActionType.Sketch)
							{
								CharacterAnimation.CrossFade(SketchAnim);
								Sketchbook.SetActive(value: true);
								Pencil.SetActive(value: true);
								if (Restless)
								{
									SewTimer += Time.deltaTime;
									if (SewTimer > 20f)
									{
										CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										ScheduleBlock obj20 = ScheduleBlocks[Phase];
										obj20.destination = "Patrol";
										obj20.action = "Patrol";
										GetDestinations();
										EmptyHands();
										PatrolID = 1;
										PatrolTimer = 0f;
										CharacterAnimation[PatrolAnim].time = 0f;
										CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
										Pathfinding.target = CurrentDestination;
										SewTimer = 0f;
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Sunbathe)
							{
								if (SunbathePhase == 0)
								{
									CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
									StudentManager.CommunalLocker.Open = true;
									StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this);
									MustChangeClothing = true;
									ChangeClothingPhase++;
									SunbathePhase++;
								}
								else if (SunbathePhase == 1)
								{
									CharacterAnimation.CrossFade(StripAnim);
									Pathfinding.canSearch = false;
									Pathfinding.canMove = false;
									if (CharacterAnimation[StripAnim].time >= 1.5f)
									{
										if (Schoolwear != 2)
										{
											Debug.Log(Name + " is calling ChangeSchoolwear() from here, specifically.");
											Schoolwear = 2;
											ChangeSchoolwear();
										}
										if (CharacterAnimation[StripAnim].time > CharacterAnimation[StripAnim].length)
										{
											Pathfinding.canSearch = true;
											Pathfinding.canMove = true;
											Stripping = false;
											if (!StudentManager.CommunalLocker.SteamCountdown)
											{
												CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												Destinations[Phase] = StudentManager.SunbatheSpots[StudentID];
												Pathfinding.target = StudentManager.SunbatheSpots[StudentID];
												CurrentDestination = StudentManager.SunbatheSpots[StudentID];
												StudentManager.CommunalLocker.Student = null;
												SunbathePhase++;
											}
										}
									}
								}
								else if (SunbathePhase == 2)
								{
									if (Rival && StudentManager.PoolClosed)
									{
										Subtitle.CustomText = "I can't believe anyone would let a stupid sign stop them from sunbathing...";
										Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
									}
									MyRenderer.updateWhenOffscreen = true;
									CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
									CharacterAnimation.CrossFade("f02_sunbatheStart_00");
									SmartPhone.SetActive(value: false);
									if (CharacterAnimation["f02_sunbatheStart_00"].time >= CharacterAnimation["f02_sunbatheStart_00"].length)
									{
										MyController.radius = 0f;
										SunbathePhase++;
									}
								}
								else if (SunbathePhase == 3)
								{
									if (Sleepy)
									{
										if (!Blind)
										{
											Debug.Log("Aaaaand...NOW! Rival is now asleep.");
											CharacterAnimation.CrossFade("f02_sunbatheSleep_00");
											Ragdoll.Zs.SetActive(value: true);
											Blind = true;
										}
									}
									else
									{
										CharacterAnimation.CrossFade("f02_sunbatheLoop_00");
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Shock)
							{
								if (StudentManager.Students[36] == null)
								{
									Phase++;
								}
								else if (StudentManager.Students[36].Routine && StudentManager.Students[36].DistanceToDestination < 1f)
								{
									if (!StudentManager.GamingDoor.Locked && !StudentManager.GamingDoor.Open)
									{
										StudentManager.GamingDoor.OpenDoor();
									}
									ParticleSystem.EmissionModule emission2 = Hearts.emission;
									if (SmartPhone.activeInHierarchy)
									{
										Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
										SmartPhone.SetActive(value: false);
										MyController.radius = 0f;
										emission2.rateOverTime = 5f;
										emission2.enabled = true;
										Hearts.Play();
									}
									if (!StudentManager.GamingDoor.Locked)
									{
										CharacterAnimation.CrossFade("f02_peeking_0" + (StudentID - 80));
									}
									else
									{
										CharacterAnimation.CrossFade(AdmireAnim);
									}
								}
								else
								{
									CharacterAnimation.CrossFade(PatrolAnim);
									if (!SmartPhone.activeInHierarchy)
									{
										SmartPhone.SetActive(value: true);
										MyController.radius = 0.1f;
										if (BullyID == 2)
										{
											MyController.Move(base.transform.right * 1f * Time.timeScale * 0.2f);
										}
										else if (BullyID == 3)
										{
											MyController.Move(base.transform.right * -1f * Time.timeScale * 0.2f);
										}
										else if (BullyID == 4)
										{
											MyController.Move(base.transform.right * 1f * Time.timeScale * 0.2f);
										}
										else if (BullyID == 5)
										{
											MyController.Move(base.transform.right * -1f * Time.timeScale * 0.2f);
										}
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Miyuki)
							{
								if (StudentManager.MiyukiEnemy.Enemy.activeInHierarchy)
								{
									if (StudentID == 37 && Clock.Day == 1)
									{
										BountyCollider.SetActive(value: true);
									}
									CharacterAnimation.CrossFade(MiyukiAnim);
									MiyukiTimer += Time.deltaTime;
									if (MiyukiTimer > 1f)
									{
										MiyukiTimer = 0f;
										Miyuki.Shoot();
									}
								}
								else
								{
									CharacterAnimation.CrossFade(VictoryAnim);
									BountyCollider.SetActive(value: false);
								}
							}
							else if (Actions[Phase] == StudentActionType.Meeting)
							{
								if (StudentID != 36)
								{
									StudentManager.Meeting = true;
									if (StudentManager.Speaker == StudentID)
									{
										if (!SpeechLines.isPlaying)
										{
											CharacterAnimation.CrossFade(RandomAnim);
											SpeechLines.Play();
										}
									}
									else
									{
										CharacterAnimation.CrossFade(IdleAnim);
										if (SpeechLines.isPlaying)
										{
											SpeechLines.Stop();
										}
									}
								}
								else
								{
									CharacterAnimation.CrossFade(PeekAnim);
								}
							}
							else if (Actions[Phase] == StudentActionType.Lyrics)
							{
								LyricsTimer += Time.deltaTime;
								if (LyricsPhase == 0)
								{
									CharacterAnimation.CrossFade("f02_writingLyrics_00");
									if (!Pencil.activeInHierarchy)
									{
										Pencil.SetActive(value: true);
									}
									if (LyricsTimer > 18f)
									{
										StudentManager.LyricsSpot.position = StudentManager.AirGuitarSpot.position;
										StudentManager.LyricsSpot.eulerAngles = StudentManager.AirGuitarSpot.eulerAngles;
										Pencil.SetActive(value: false);
										LyricsPhase = 1;
										LyricsTimer = 0f;
									}
								}
								else
								{
									CharacterAnimation.CrossFade("f02_airGuitar_00");
									if (!AirGuitar.isPlaying)
									{
										AirGuitar.Play();
									}
									if (LyricsTimer > 18f)
									{
										StudentManager.LyricsSpot.position = StudentManager.OriginalLyricsSpot.position;
										StudentManager.LyricsSpot.eulerAngles = StudentManager.OriginalLyricsSpot.eulerAngles;
										AirGuitar.Stop();
										LyricsPhase = 0;
										LyricsTimer = 0f;
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Sew)
							{
								CharacterAnimation.CrossFade("sewing_00");
								PinkSeifuku.SetActive(value: true);
								if (SewTimer < 10f && StudentManager.TaskManager.TaskStatus[8] == 3)
								{
									SewTimer += Time.deltaTime;
									if (SewTimer > 10f)
									{
										UnityEngine.Object.Instantiate(Yandere.PauseScreen.DropsMenu.GetComponent<DropsScript>().InfoChanWindow.Drops[1], new Vector3(28.289f, 0.7718928f, 5.196f), Quaternion.identity);
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Paint)
							{
								Painting.material.color += new Color(0f, 0f, 0f, Time.deltaTime * 0.00066666f);
								CharacterAnimation.CrossFade(PaintAnim);
								Paintbrush.SetActive(value: true);
								Palette.SetActive(value: true);
							}
							else if (Actions[Phase] == StudentActionType.UpdateAppearance)
							{
								Debug.Log("We have reached the ''UpdateAppearance'' code.");
								UpdateGemaAppearance();
							}
							else if (Actions[Phase] == StudentActionType.PlaceBag)
							{
								PlaceBag();
							}
							else if (Actions[Phase] == StudentActionType.Sleep)
							{
								if (Male)
								{
									CharacterAnimation.CrossFade("infirmaryRest_00");
								}
								else
								{
									CharacterAnimation.CrossFade("f02_infirmaryRest_00");
								}
							}
							else if (Actions[Phase] == StudentActionType.LightFire)
							{
								if (PyroPhase == 1)
								{
									CharacterAnimation.CrossFade("f02_startFire_00");
									if (DistanceToPlayer < 5f && Yandere.transform.position.z < base.transform.position.z)
									{
										Subtitle.CustomText = "...oh...I didn't realize someone was here...I'll just...be going, now...";
										Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
										PyroPhase = 4;
									}
									else if (CharacterAnimation["f02_startFire_00"].time > CharacterAnimation["f02_startFire_00"].length)
									{
										PyroPhase++;
									}
									else if (CharacterAnimation["f02_startFire_00"].time > 13f)
									{
										if (!StudentManager.PyroFlames.isPlaying)
										{
											StudentManager.PyroFlames.Play();
											StudentManager.PyroFlameSounds[1].Play();
											StudentManager.PyroFlameSounds[2].Play();
										}
									}
									else if (CharacterAnimation["f02_startFire_00"].time > 11.75f)
									{
										Note.transform.parent = null;
										Note.transform.position -= new Vector3(0f, Time.deltaTime, 0f);
									}
									else if (CharacterAnimation["f02_startFire_00"].time > 11.5f)
									{
										Lighter.SetActive(value: false);
									}
									else if (CharacterAnimation["f02_startFire_00"].time > 8f)
									{
										PaperFire.SetActive(value: true);
									}
									else if (CharacterAnimation["f02_startFire_00"].time > 4.5f)
									{
										Lighter.SetActive(value: true);
									}
									else if (CharacterAnimation["f02_startFire_00"].time > 1f && !Note.gameObject.activeInHierarchy)
									{
										Note.transform.parent = RightHand;
										Note.transform.localPosition = new Vector3(0f, -0.1f, -0.004f);
										Note.transform.localEulerAngles = new Vector3(0f, 135f, 45f);
										Note.transform.localScale = new Vector3(0.1f, 0.2f, 1f);
										Note.SetActive(value: true);
									}
								}
								else if (PyroPhase == 2)
								{
									if (PyroTimer == 0f && DistanceToPlayer < 5f)
									{
										Subtitle.CustomText = "...hehe...it's always just as spellbinding as the first time...";
										Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
									}
									CharacterAnimation.CrossFade("f02_inspectLoop_00");
									PyroTimer += Time.deltaTime;
									if (PyroTimer > 60f || Yandere.transform.position.z < base.transform.position.z)
									{
										if (DistanceToPlayer < 5f)
										{
											if (PyroTimer < 60f)
											{
												Subtitle.UpdateLabel(SubtitleType.AcceptFood, 0, 0f);
												Subtitle.CustomText = "...um...oh, my! Who started this fire? How dangerous! I'd better put it out...";
												Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
											}
											else
											{
												Subtitle.CustomText = "...well, that's enough for now...";
												Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
											}
										}
										StudentManager.PyroWateringCan.parent = RightHand;
										StudentManager.PyroWateringCan.localPosition = new Vector3(0.14f, -0.15f, -0.05f);
										StudentManager.PyroWateringCan.localEulerAngles = new Vector3(10f, 15f, 45f);
										Note.transform.parent = RightHand;
										Note.transform.localPosition = new Vector3(0f, -0.1f, -0.004f);
										Note.transform.localEulerAngles = new Vector3(0f, 135f, 45f);
										Note.transform.localScale = new Vector3(0.1f, 0.2f, 1f);
										PaperFire.SetActive(value: false);
										Lighter.SetActive(value: false);
										Note.SetActive(value: false);
										PyroPhase++;
									}
								}
								else if (PyroPhase == 3)
								{
									CharacterAnimation.CrossFade("f02_waterPlant_00");
									if (CharacterAnimation["f02_waterPlant_00"].time > CharacterAnimation["f02_waterPlant_00"].length)
									{
										WillCombust = true;
										PyroPhase++;
									}
								}
								else if (PyroPhase == 4)
								{
									StudentManager.PyroWateringCan.parent = null;
									StudentManager.PyroWateringCan.localPosition = new Vector3(-38.5f, 0f, 43f);
									StudentManager.PyroWateringCan.localEulerAngles = new Vector3(0f, 180f, 0f);
									if (StudentManager.GasInWateringCan && WillCombust)
									{
										Combust();
									}
									else
									{
										FinishPyro();
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Jog)
							{
								CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
								if (Schoolwear == 1)
								{
									if (SunbathePhase == 0)
									{
										CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										StudentManager.CommunalLocker.Open = true;
										StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this);
										MustChangeClothing = true;
										ChangeClothingPhase++;
										SunbathePhase++;
									}
									else if (SunbathePhase == 1)
									{
										CharacterAnimation.CrossFade(StripAnim);
										Pathfinding.canSearch = false;
										Pathfinding.canMove = false;
										if (CharacterAnimation[StripAnim].time >= 1.5f)
										{
											if (Schoolwear != 3)
											{
												Schoolwear = 3;
												ChangeSchoolwear();
											}
											if (CharacterAnimation[StripAnim].time > CharacterAnimation[StripAnim].length)
											{
												Pathfinding.canSearch = true;
												Pathfinding.canMove = true;
												Stripping = false;
												if (!StudentManager.CommunalLocker.SteamCountdown)
												{
													CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
													Destinations[Phase] = StudentManager.Clubs.List[66].GetChild(ClubActivityPhase);
													Pathfinding.target = StudentManager.Clubs.List[66].GetChild(ClubActivityPhase);
													CurrentDestination = StudentManager.Clubs.List[66].GetChild(ClubActivityPhase);
													StudentManager.CommunalLocker.Student = null;
													SunbathePhase++;
												}
											}
										}
									}
								}
								else
								{
									CharacterAnimation.CrossFade(ClubAnim);
									if (ClubActivityPhase == 0)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											string text4 = "";
											if (!Male)
											{
												text4 = "f02_";
											}
											ClubActivityPhase++;
											ClubAnim = text4 + "stretch_01";
											Destinations[Phase] = StudentManager.Clubs.List[66].GetChild(ClubActivityPhase);
										}
									}
									else if (ClubActivityPhase == 1)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											string text5 = "";
											if (!Male)
											{
												text5 = "f02_";
											}
											ClubActivityPhase++;
											ClubAnim = text5 + "stretch_02";
											Destinations[Phase] = StudentManager.Clubs.List[66].GetChild(ClubActivityPhase);
										}
									}
									else if (ClubActivityPhase == 2)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											string text6 = "";
											if (!Male)
											{
												text6 = "f02_";
											}
											WalkAnim = text6 + "trackJog_00";
											Hurry = true;
											ClubActivityPhase++;
											CharacterAnimation[ClubAnim].time = 0f;
											Destinations[Phase] = StudentManager.Clubs.List[66].GetChild(ClubActivityPhase);
											CurrentDestination = Destinations[Phase];
											Pathfinding.target = CurrentDestination;
											Pathfinding.speed = 4f;
										}
									}
									else if (ClubActivityPhase < 14)
									{
										if (CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
										{
											string text7 = "";
											if (!Male)
											{
												text7 = "f02_";
											}
											WalkAnim = text7 + "trackJog_00";
											Hurry = true;
											ClubActivityPhase++;
											CharacterAnimation[ClubAnim].time = 0f;
											Destinations[Phase] = StudentManager.Clubs.List[66].GetChild(ClubActivityPhase);
											CurrentDestination = Destinations[Phase];
											Pathfinding.target = CurrentDestination;
											Pathfinding.speed = 4f;
										}
									}
									else if (ClubActivityPhase == 14 && CharacterAnimation[ClubAnim].time >= CharacterAnimation[ClubAnim].length)
									{
										WalkAnim = OriginalWalkAnim;
										Hurry = false;
										ClubActivityPhase = 0;
										if (Male)
										{
											ClubAnim = "stretch_00";
										}
										else
										{
											ClubAnim = "f02_stretch_00";
										}
										Destinations[Phase] = StudentManager.Clubs.List[66].GetChild(ClubActivityPhase);
										CurrentDestination = Destinations[Phase];
										Pathfinding.target = CurrentDestination;
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.PrepareFood)
							{
								if (!MyBento.gameObject.activeInHierarchy)
								{
									MyBento.Lid.SetActive(value: false);
									MyBento.Prompt.enabled = true;
									MyBento.transform.parent = null;
									MyBento.gameObject.SetActive(value: true);
									MyBento.transform.position = StudentManager.FoodTrays[StudentID].position;
									MyBento.transform.eulerAngles = StudentManager.FoodTrays[StudentID].eulerAngles;
								}
								CharacterAnimation.CrossFade(PrepareFoodAnim);
								ClubTimer += Time.deltaTime;
								if (ClubTimer > 60f)
								{
									MyBento.transform.parent = LeftItemParent;
									MyBento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
									MyBento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
									MyBento.gameObject.SetActive(value: false);
									MyBento.Prompt.enabled = false;
									MyBento.Prompt.Hide();
									ScheduleBlock obj21 = ScheduleBlocks[Phase];
									obj21.destination = "LunchSpot";
									obj21.action = "Eat";
									GetDestinations();
									Pathfinding.target = Destinations[Phase];
									CurrentDestination = Destinations[Phase];
								}
							}
							else if (Actions[Phase] == StudentActionType.Perform)
							{
								CharacterAnimation.CrossFade(ClubAnim);
								if (StudentID == 52)
								{
									if (!Instruments[ClubMemberID].activeInHierarchy)
									{
										Instruments[ClubMemberID].SetActive(value: true);
										Instruments[ClubMemberID].transform.parent = Spine;
										Instruments[ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
										Instruments[ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
									}
								}
								else if (StudentID == 53)
								{
									if (!Instruments[ClubMemberID].activeInHierarchy)
									{
										Instruments[ClubMemberID].SetActive(value: true);
										Instruments[ClubMemberID].transform.parent = Spine;
										Instruments[ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
										Instruments[ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
									}
								}
								else if (StudentID == 54)
								{
									Drumsticks[0].SetActive(value: true);
									Drumsticks[1].SetActive(value: true);
								}
							}
							else if (Actions[Phase] == StudentActionType.PhotoShoot)
							{
								if (StudentManager.Students[19] != null)
								{
									if (StudentManager.Students[19].ClubTimer > 0f && StudentManager.Students[19].DistanceToDestination < 1f)
									{
										if (Male)
										{
											CharacterAnimation.CrossFade("tripodUse_00");
										}
										else
										{
											CharacterAnimation.CrossFade("f02_tripodUse_00");
										}
									}
									else if (Male)
									{
										CharacterAnimation.CrossFade("impatientWait_00");
									}
									else
									{
										CharacterAnimation.CrossFade("f02_impatientWait_00");
									}
								}
								else if (Male)
								{
									CharacterAnimation.CrossFade("impatientWait_00");
								}
								else
								{
									CharacterAnimation.CrossFade("f02_impatientWait_00");
								}
							}
							else if (Actions[Phase] == StudentActionType.GravurePose)
							{
								if (!Hurry)
								{
									if (SunbathePhase < 2)
									{
										if (SunbathePhase == 0)
										{
											CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											StudentManager.CommunalLocker.Open = true;
											StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this);
											MustChangeClothing = true;
											ChangeClothingPhase++;
											SunbathePhase++;
										}
										else if (SunbathePhase == 1)
										{
											CharacterAnimation.CrossFade(StripAnim);
											Pathfinding.canSearch = false;
											Pathfinding.canMove = false;
											if (CharacterAnimation[StripAnim].time >= 1.5f)
											{
												Debug.Log("Chigusa has reached her destination, so she is now being instructed to change into a bikini and update her destination.");
												if (!WearingBikini)
												{
													WearBikini();
												}
												if (CharacterAnimation[StripAnim].time > CharacterAnimation[StripAnim].length && !StudentManager.CommunalLocker.SteamCountdown)
												{
													GoPose();
													SunbathePhase++;
												}
											}
										}
									}
									else
									{
										CharacterAnimation.CrossFade(ClubAnim);
										ClubTimer += Time.deltaTime;
										if (ClubTimer > 5f)
										{
											ClubPhase++;
											if (ClubPhase == GravureAnims.Length - 1)
											{
												ClubPhase = 0;
											}
											ClubAnim = GravureAnims[ClubPhase];
											ClubTimer = 0f;
										}
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Guard)
							{
								CharacterAnimation.CrossFade(IdleAnim);
							}
							else if (Actions[Phase] == StudentActionType.HelpTeacher)
							{
								CharacterAnimation.CrossFade(ThinkAnim);
								if (CharacterAnimation[ThinkAnim].time > CharacterAnimation[ThinkAnim].length)
								{
									GetTeacherTarget();
								}
							}
							else if (Actions[Phase] == StudentActionType.Admire)
							{
								if (Stalker)
								{
									CharacterAnimation.CrossFade(AdmireAnim);
								}
								else
								{
									StudentScript studentScript2 = StudentManager.Students[InfatuationID];
									if (studentScript2 != null)
									{
										if (!studentScript2.gameObject.activeInHierarchy || !studentScript2.enabled)
										{
											Debug.Log("The target's disabled or dead.");
											CharacterAnimation.CrossFade(LookLeftRightAnim);
											SnackTimer += Time.deltaTime;
											if (SnackTimer >= 5f)
											{
												StopFollowingGravureModel();
											}
										}
										else
										{
											CharacterAnimation.CrossFade(AdmireAnim);
										}
									}
									if (StudentManager.Students[InfatuationID] != null && StudentManager.Students[InfatuationID].Sleepy && StudentManager.Students[InfatuationID].DistanceToDestination < 1f)
									{
										StopFollowingGravureModel();
									}
								}
							}
							else if (Actions[Phase] == StudentActionType.Rehearse)
							{
								if (StudentID < 28)
								{
									CharacterAnimation.CrossFade(ActAnim);
								}
								else
								{
									CharacterAnimation.CrossFade(ThinkAnim);
								}
							}
							else if (Actions[Phase] == StudentActionType.Stretch)
							{
								CharacterAnimation.CrossFade(StretchAnim);
								StretchTimer += Time.deltaTime;
								if (StretchTimer > 5f)
								{
									StretchPhase++;
									if (StretchPhase == StretchAnims.Length)
									{
										StretchPhase = 0;
									}
									StretchAnim = StretchAnims[StretchPhase];
									StretchTimer = 0f;
								}
							}
							else if (Actions[Phase] == StudentActionType.CustomHangout)
							{
								CharacterAnimation.CrossFade(CustomHangoutAnim);
							}
							else if (Actions[Phase] == StudentActionType.CustomPatrol)
							{
								DressCode = false;
								CharacterAnimation.CrossFade(CustomPatrolAnim);
								PatrolTimer += Time.deltaTime;
								if (PatrolTimer >= 10f || Pathfinding.target == null)
								{
									PatrolID++;
									if (PatrolID == StudentManager.CustomPatrols.List[StudentID].childCount || Pathfinding.target == null)
									{
										PatrolID = 0;
									}
									CurrentDestination = StudentManager.CustomPatrols.List[StudentID].GetChild(PatrolID);
									Pathfinding.target = CurrentDestination;
									PatrolTimer = 0f;
								}
							}
							else if (Actions[Phase] == StudentActionType.RandomPatrol)
							{
								DressCode = false;
								CharacterAnimation.CrossFade(CustomPatrolAnim);
								PatrolTimer += Time.deltaTime;
								if (PatrolTimer >= 10f || Pathfinding.target == null)
								{
									CurrentDestination = StudentManager.CustomPatrols.List[UnityEngine.Random.Range(1, 101)].GetChild(UnityEngine.Random.Range(0, 2));
									Pathfinding.target = CurrentDestination;
									PatrolTimer = 0f;
								}
							}
							else if (Actions[Phase] == StudentActionType.BakeSale)
							{
								if (BakeSalePhase == 0)
								{
									CharacterAnimation.CrossFade(PrepareFoodAnim);
									ClubTimer += Time.deltaTime;
									if (ClubTimer > 60f)
									{
										MyPlate.parent = RightHand;
										MyPlate.localPosition = new Vector3(0.02f, -0.02f, -0.15f);
										MyPlate.localEulerAngles = new Vector3(-5f, -90f, 172.5f);
										IdleAnim = PlateIdleAnim;
										WalkAnim = PlateWalkAnim;
										LeanAnim = PlateIdleAnim;
										StudentManager.BakeSalePrepSpots[StudentID].position = StudentManager.BakeSaleSpots[StudentID].position;
										StudentManager.BakeSalePrepSpots[StudentID].rotation = StudentManager.BakeSaleSpots[StudentID].rotation;
										StudentManager.BakeSaleSabotageScripts[StudentID].Disable();
										DistanceToDestination = 100f;
										BakeSalePhase++;
										CanTalk = false;
										ClubTimer = 0f;
									}
								}
								else if (BakeSalePhase == 1)
								{
									if (MyPlate != null && MyPlate.parent == RightHand)
									{
										MyPlate.parent = null;
										MyPlate.position = StudentManager.BakeSalePlateParents[StudentID].position;
										MyPlate.rotation = StudentManager.BakeSalePlateParents[StudentID].rotation;
										IdleAnim = OriginalIdleAnim;
										WalkAnim = OriginalWalkAnim;
										LeanAnim = OriginalLeanAnim;
										StudentManager.BakeSale.enabled = true;
										BakeSalePhase++;
										CanTalk = true;
									}
								}
								else if (BakeSalePhase == 2)
								{
									CharacterAnimation.CrossFade(IdleAnim);
								}
							}
							else if (Actions[Phase] == StudentActionType.Picnic)
							{
								if (Male)
								{
									CharacterAnimation.CrossFade("sit_02");
								}
								else
								{
									CharacterAnimation.CrossFade("f02_sit_02");
								}
							}
						}
						else
						{
							CurrentDestination = StudentManager.GoAwaySpots.List[StudentID];
							Pathfinding.target = StudentManager.GoAwaySpots.List[StudentID];
							CharacterAnimation.CrossFade(IdleAnim);
							GoAwayTimer += Time.deltaTime;
							if (GoAwayTimer > 10f)
							{
								Debug.Log("This code is only called after a character has spent 10 seconds standing in a 'Go Away'' spot.");
								CurrentDestination = Destinations[Phase];
								Pathfinding.target = Destinations[Phase];
								GoAwayTimer = 0f;
								GoAway = false;
							}
						}
					}
					else
					{
						if (MeetTimer == 0f)
						{
							if (Yandere.Bloodiness + (float)Yandere.GloveBlood == 0f && (double)Yandere.Sanity >= 66.66666 && (CurrentDestination == StudentManager.MeetSpots.List[8] || CurrentDestination == StudentManager.MeetSpots.List[9] || CurrentDestination == StudentManager.MeetSpots.List[10]))
							{
								if (StudentManager.Eighties && StudentID == StudentManager.RivalID)
								{
									if (StudentManager.EightiesOfferHelp != null)
									{
										StudentManager.EightiesOfferHelp.UpdateLocation();
										StudentManager.EightiesOfferHelp.enabled = true;
										StudentManager.EightiesOfferHelp.Prompt.enabled = true;
									}
								}
								else if (StudentID == StudentManager.RivalID)
								{
									StudentManager.OsanaOfferHelp.UpdateLocation();
									StudentManager.OsanaOfferHelp.enabled = true;
									StudentManager.OsanaOfferHelp.Prompt.enabled = true;
								}
								else if (StudentID == 5)
								{
									Yandere.BullyPhotoCheck();
									if (Yandere.BullyPhoto)
									{
										StudentManager.FragileOfferHelp.gameObject.SetActive(value: true);
										StudentManager.FragileOfferHelp.UpdateLocation();
										StudentManager.FragileOfferHelp.enabled = true;
										StudentManager.FragileOfferHelp.Prompt.enabled = true;
									}
								}
							}
							if (!SchoolGlobals.RoofFence && base.transform.position.y > 11f)
							{
								Pushable = true;
								StudentManager.UpdateMe(StudentID);
							}
							if (CurrentDestination == StudentManager.FountainSpot)
							{
								Debug.Log(Name + " is now drownable.");
								Drownable = true;
								StudentManager.UpdateMe(StudentID);
							}
						}
						MeetTimer += Time.deltaTime;
						if (Follower != null)
						{
							Debug.Log("Osana is now repositioning her own FollowTargetDestination.");
							if (Meeting)
							{
								FollowTargetDestination.localPosition = new Vector3(-1f, 0f, 0f);
							}
							else if (CurrentAction == StudentActionType.Clean)
							{
								FollowTargetDestination.localPosition = new Vector3(-1f, 0f, -1f);
							}
							else if (CurrentAction == StudentActionType.SitAndEatBento)
							{
								FollowTargetDestination.localPosition = new Vector3(0f, 0f, 1f);
							}
							else
							{
								FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
							}
						}
						if (BakeSale)
						{
							CharacterAnimation.CrossFade(PlateEatAnim);
							MeetTimer += Time.deltaTime * 6.5f;
						}
						else if (Male)
						{
							CharacterAnimation.CrossFade("impatientWait_00");
						}
						else
						{
							CharacterAnimation.CrossFade("f02_impatientWait_00");
						}
						if (MeetTimer > 60f)
						{
							if (!BakeSale)
							{
								if (!Male)
								{
									Subtitle.UpdateLabel(SubtitleType.NoteReaction, 4, 3f);
								}
								else if (StudentID == 28)
								{
									Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 6, 3f);
								}
								else
								{
									Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 4, 3f);
								}
							}
							while (Clock.HourTime >= ScheduleBlocks[Phase].time)
							{
								Phase++;
							}
							CurrentDestination = Destinations[Phase];
							Pathfinding.target = Destinations[Phase];
							if (Follower != null)
							{
								Follower.CurrentDestination = Follower.FollowTarget.transform;
								Follower.Pathfinding.target = Follower.FollowTarget.transform;
								FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
							}
							StopMeeting();
							if (BakeSale && StudentManager.BakeSale.Poisoned)
							{
								GoPuke();
							}
						}
					}
				}
			}
		}
		else
		{
			if (CurrentDestination != null)
			{
				DistanceToDestination = Vector3.Distance(base.transform.position, CurrentDestination.position);
			}
			if (Fleeing)
			{
				if (WitnessedMurder && Persona == PersonaType.Heroic)
				{
					Pathfinding.target = Yandere.transform;
					CurrentDestination = Yandere.transform;
				}
				if (FollowTarget != null && Vector3.Distance(base.transform.position, FollowTarget.transform.position) < 10f && FollowTarget.Attacked && FollowTarget.Alive && !FollowTarget.Tranquil && !Blind)
				{
					Debug.Log("Raibaru should be aware that Osana is being attacked.");
					AwareOfMurder = true;
					Alarm = 200f;
				}
				if (Struggling && Lost)
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Yandere.transform.rotation, 10f * Time.deltaTime);
					if (!StopSliding)
					{
						MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward * 0.425f);
					}
				}
				if (!Dying && !Spraying)
				{
					if (!PinningDown)
					{
						if (Persona == PersonaType.Dangerous)
						{
							Yandere.Pursuer = this;
							Debug.Log("This student council member is running to intercept Yandere-chan.");
							if (Yandere.Laughing)
							{
								Yandere.StopLaughing();
								Yandere.Chased = true;
								Yandere.CanMove = false;
							}
							if (Yandere.Cauterizing || Yandere.Dismembering || Yandere.WrappingCorpse)
							{
								if (Yandere.Dismembering)
								{
									Yandere.StopDismembering();
								}
								if (Yandere.WrappingCorpse)
								{
									Yandere.StopWrappingCorpse();
								}
								Yandere.Cauterizing = false;
								Yandere.Chased = true;
								Yandere.CanMove = false;
							}
							if (StudentManager.CombatMinigame.Path > 3 && StudentManager.CombatMinigame.Path < 7)
							{
								ReturnToRoutine();
							}
						}
						if (Pathfinding.target != null)
						{
							DistanceToDestination = Vector3.Distance(base.transform.position, Pathfinding.target.position);
						}
						if (AlarmTimer > 0f)
						{
							AlarmTimer = Mathf.MoveTowards(AlarmTimer, 0f, Time.deltaTime);
							if (StudentID == 1)
							{
								Debug.Log("Senpai entered his scared animation.");
							}
							CharacterAnimation.CrossFade(ScaredAnim);
							if (AlarmTimer == 0f)
							{
								Debug.Log("Alarmed is being set to false from here.");
								WalkBack = false;
								Alarmed = false;
							}
							Pathfinding.canSearch = false;
							Pathfinding.canMove = false;
							if (WitnessedMurder)
							{
								targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
							}
							else if (WitnessedCorpse)
							{
								targetRotation = Quaternion.LookRotation(new Vector3(Corpse.AllColliders[0].transform.position.x, base.transform.position.y, Corpse.AllColliders[0].transform.position.z) - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
							}
						}
						else
						{
							if (Persona == PersonaType.TeachersPet && WitnessedMurder && ReportPhase == 0 && StudentManager.Reporter == null && !Police.Called)
							{
								Debug.Log(Name + " is setting their teacher as their destination at the beginning of Flee protocol.");
								Pathfinding.target = StudentManager.Teachers[Class].transform;
								CurrentDestination = StudentManager.Teachers[Class].transform;
								StudentManager.Reporter = this;
								ReportingMurder = true;
								DetermineCorpseLocation();
							}
							if (base.transform.position.y < -10f)
							{
								Debug.Log("A student has just run out of Akademi.");
								if (!StudentManager.Jammed)
								{
									if (Persona == PersonaType.PhoneAddict && WitnessedMurder && !SawMask)
									{
										PhoneAddictGameOver();
									}
									else if (FoundEnemyCorpse)
									{
										Debug.Log("Not going to call the cops, since the corpse belonged to an enemy.");
									}
									else if (Persona != PersonaType.Evil && Persona != PersonaType.Coward && Persona != PersonaType.Fragile)
									{
										Debug.Log(Name + " just called the cops.");
										Police.Called = true;
										Police.Show = true;
									}
								}
								base.transform.position = new Vector3(base.transform.position.x, -100f, base.transform.position.z);
								base.gameObject.SetActive(value: false);
							}
							if (base.transform.position.y < -11f)
							{
								if (Persona != PersonaType.Coward && Persona != PersonaType.Evil && Persona != PersonaType.Fragile && OriginalPersona != PersonaType.Evil)
								{
									Police.Witnesses--;
									if (!StudentManager.Jammed)
									{
										Police.Show = true;
										if (Countdown.gameObject.activeInHierarchy)
										{
											PhoneAddictGameOver();
										}
									}
								}
								base.transform.position = new Vector3(base.transform.position.x, -100f, base.transform.position.z);
								base.gameObject.SetActive(value: false);
							}
							if (base.transform.position.z < -99f)
							{
								Prompt.Hide();
								Prompt.enabled = false;
								Safe = true;
							}
							if (DistanceToDestination > TargetDistance)
							{
								if (!Phoneless)
								{
									CharacterAnimation.CrossFade(SprintAnim);
								}
								else
								{
									CharacterAnimation.CrossFade(OriginalSprintAnim);
								}
								Pathfinding.canSearch = true;
								Pathfinding.canMove = true;
								if (Pursuing && Yandere.CanMove && !Yandere.Yakuza)
								{
									Debug.Log("A character is pursuing Yandere, yet Yandere can move?");
									PursueTimer += Time.deltaTime;
									if (PursueTimer > 1f)
									{
										Yandere.CanMove = false;
									}
								}
								if (Yandere.Chased && Yandere.Pursuer == this)
								{
									if (Persona == PersonaType.Protective && !StudentManager.ChallengeManager.InvincibleRaibaru && Yandere.PhysicalGrade + Yandere.Class.PhysicalBonus > 0)
									{
										Persona = PersonaType.Heroic;
									}
									Debug.Log(Name + " is now chasing Yandere-chan.");
									FocusOnYandere = false;
									CharacterAnimation.CrossFade(SprintAnim);
									Pathfinding.repathRate = 0f;
									Pathfinding.speed = 5f;
									ChaseTimer += Time.deltaTime;
									if (ChaseTimer > 10f && !Yandere.Yakuza)
									{
										base.transform.position = Yandere.transform.position + Yandere.transform.forward * 0.999f;
										base.transform.LookAt(Yandere.transform.position);
										Physics.SyncTransforms();
									}
									if (Yandere.Dismembering)
									{
										Yandere.StopDismembering();
									}
									if (Yandere.WrappingCorpse)
									{
										Yandere.StopWrappingCorpse();
									}
									if (Yandere.Hiding)
									{
										Yandere.PromptBar.ClearButtons();
										Yandere.PromptBar.Show = false;
										Yandere.Hiding = false;
									}
									if (Yandere.CanMove && !Yandere.Yakuza)
									{
										Yandere.PreparedForStruggle = false;
										Yandere.CanMove = false;
									}
								}
								else
								{
									Pathfinding.speed = 4f;
								}
								if (Persona == PersonaType.PhoneAddict && !Phoneless && !CrimeReported)
								{
									if (!StudentManager.Eighties)
									{
										Countdown.Sprite.fillAmount = Mathf.MoveTowards(Countdown.Sprite.fillAmount, 0f, Time.deltaTime * Countdown.Speed);
									}
									if (Countdown.Sprite.fillAmount == 0f)
									{
										Countdown.Sprite.fillAmount = 1f;
										CrimeReported = true;
										if (WitnessedMurder && !Countdown.MaskedPhoto)
										{
											PhoneAddictGameOver();
										}
										else
										{
											if (StudentManager.ChaseCamera == ChaseCamera)
											{
												StudentManager.ChaseCamera = null;
											}
											SprintAnim = OriginalSprintAnim;
											Countdown.gameObject.SetActive(value: false);
											ChaseCamera.SetActive(value: false);
											if (!StudentManager.Jammed)
											{
												Debug.Log(Name + " just called the cops.");
												Police.Called = true;
												Police.Show = true;
											}
										}
									}
									else if (!StudentManager.Eighties)
									{
										SprintAnim = PhoneAnims[2];
										if (StudentManager.ChaseCamera == null)
										{
											StudentManager.ChaseCamera = ChaseCamera;
											ChaseCamera.SetActive(value: true);
										}
									}
								}
							}
							else
							{
								Pathfinding.canSearch = false;
								Pathfinding.canMove = false;
								if (!Halt)
								{
									if (StudentID > 1)
									{
										MoveTowardsTarget(Pathfinding.target.position);
										if (!Teacher && !FocusOnYandere)
										{
											base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Pathfinding.target.rotation, 10f * Time.deltaTime);
										}
									}
								}
								else
								{
									if (Spraying)
									{
										CharacterAnimation.CrossFade(SprayAnim);
									}
									if (Persona == PersonaType.TeachersPet)
									{
										targetRotation = Quaternion.LookRotation(new Vector3(StudentManager.Teachers[Class].transform.position.x, base.transform.position.y, StudentManager.Teachers[Class].transform.position.z) - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
									}
									else if (Persona == PersonaType.Dangerous && !BreakingUpFight)
									{
										targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
									}
								}
								if (Persona == PersonaType.TeachersPet)
								{
									if (ReportingMurder || ReportingBlood)
									{
										if (StudentManager.Teachers[Class].Alarmed && ReportPhase < 100)
										{
											if (Club == ClubType.Council)
											{
												Pathfinding.target = StudentManager.CorpseLocation;
												CurrentDestination = StudentManager.CorpseLocation;
											}
											else
											{
												if (PetDestination == null)
												{
													PetDestination = UnityEngine.Object.Instantiate(EmptyGameObject, Seat.position + Seat.forward * -0.5f, Quaternion.identity).transform;
												}
												Pathfinding.target = PetDestination;
												CurrentDestination = PetDestination;
											}
											ReportPhase = 3;
										}
										if (ReportPhase == 0)
										{
											Debug.Log(Name + ", currently acting as a Teacher's Pet, is talking to a teacher.");
											if (MyTeacher == null)
											{
												MyTeacher = StudentManager.Teachers[Class];
											}
											if (!MyTeacher.Alive)
											{
												Persona = PersonaType.Loner;
												PersonaReaction();
											}
											else
											{
												Subtitle.Speaker = this;
												CharacterAnimation.CrossFade(ScaredAnim);
												if (WitnessedMurder)
												{
													Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 2, 3f);
												}
												else if (WitnessedCorpse)
												{
													if (Club == ClubType.Council)
													{
														Subtitle.CustomText = "";
														Subtitle.UpdateLabel(SubtitleType.Custom, 0, 0f);
														if (StudentID == 86)
														{
															Subtitle.UpdateLabel(SubtitleType.StrictReport, 2, 5f);
														}
														else if (StudentID == 87)
														{
															Subtitle.UpdateLabel(SubtitleType.CasualReport, 2, 5f);
														}
														else if (StudentID == 88)
														{
															Subtitle.UpdateLabel(SubtitleType.GraceReport, 2, 5f);
														}
														else if (StudentID == 89)
														{
															Subtitle.UpdateLabel(SubtitleType.EdgyReport, 2, 5f);
														}
													}
													else
													{
														Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 2, 3f);
													}
												}
												else if (WitnessedLimb)
												{
													Subtitle.UpdateLabel(SubtitleType.PetLimbReport, 2, 3f);
												}
												else if (WitnessedBloodyWeapon)
												{
													Subtitle.UpdateLabel(SubtitleType.PetBloodyWeaponReport, 2, 3f);
												}
												else if (WitnessedBloodPool)
												{
													Subtitle.UpdateLabel(SubtitleType.PetBloodReport, 2, 3f);
												}
												else if (WitnessedWeapon)
												{
													Subtitle.UpdateLabel(SubtitleType.PetWeaponReport, 2, 3f);
												}
												MyTeacher = StudentManager.Teachers[Class];
												MyTeacher.CurrentDestination = MyTeacher.transform;
												MyTeacher.Pathfinding.target = MyTeacher.transform;
												MyTeacher.Pathfinding.canSearch = false;
												MyTeacher.Pathfinding.canMove = false;
												MyTeacher.CharacterAnimation.CrossFade(MyTeacher.IdleAnim);
												MyTeacher.ListeningToReport = true;
												MyTeacher.Routine = false;
												if (MyTeacher.Persona != PersonaType.Strict)
												{
													Debug.Log("The teacher wasn't strict. Must be Custom Mode. Turning the teacher strict, then.");
													MyTeacher.Persona = PersonaType.Strict;
												}
												if (StudentManager.Teachers[Class].Investigating)
												{
													StudentManager.Teachers[Class].StopInvestigating();
												}
												Halt = true;
												ReportPhase++;
											}
										}
										else if (ReportPhase == 1)
										{
											Pathfinding.target = StudentManager.Teachers[Class].transform;
											CurrentDestination = StudentManager.Teachers[Class].transform;
											if (WitnessedBloodPool || (WitnessedWeapon && !WitnessedBloodyWeapon))
											{
												CharacterAnimation.CrossFade(IdleAnim);
											}
											else if (WitnessedMurder || WitnessedCorpse || WitnessedLimb || WitnessedBloodyWeapon)
											{
												CharacterAnimation.CrossFade(ScaredAnim);
											}
											StudentManager.Teachers[Class].targetRotation = Quaternion.LookRotation(base.transform.position - StudentManager.Teachers[Class].transform.position);
											StudentManager.Teachers[Class].transform.rotation = Quaternion.Slerp(StudentManager.Teachers[Class].transform.rotation, StudentManager.Teachers[Class].targetRotation, 10f * Time.deltaTime);
											ReportTimer += Time.deltaTime;
											if (ReportTimer >= 3f)
											{
												base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
												StudentManager.Teachers[Class].ListeningToReport = false;
												StudentManager.Teachers[Class].MyReporter = this;
												StudentManager.Teachers[Class].Routine = false;
												StudentManager.Teachers[Class].Fleeing = true;
												ReportTimer = 0f;
												ReportPhase++;
											}
										}
										else if (ReportPhase == 2)
										{
											Pathfinding.target = StudentManager.Teachers[Class].transform;
											CurrentDestination = StudentManager.Teachers[Class].transform;
											if (WitnessedBloodPool || (WitnessedWeapon && !WitnessedBloodyWeapon))
											{
												CharacterAnimation.CrossFade(IdleAnim);
											}
											else if (WitnessedMurder || WitnessedCorpse || WitnessedLimb || WitnessedBloodyWeapon)
											{
												CharacterAnimation.CrossFade(ScaredAnim);
											}
										}
										else if (ReportPhase == 3)
										{
											Pathfinding.target = base.transform;
											CurrentDestination = base.transform;
											if (WitnessedBloodPool || (WitnessedWeapon && !WitnessedBloodyWeapon))
											{
												CharacterAnimation.CrossFade(IdleAnim);
											}
											else if (WitnessedMurder || WitnessedCorpse || WitnessedLimb || WitnessedBloodyWeapon)
											{
												CharacterAnimation.CrossFade(ParanoidAnim);
											}
										}
										else if (ReportPhase < 100)
										{
											CharacterAnimation.CrossFade(ParanoidAnim);
										}
										else
										{
											if (Pathfinding.target != base.transform)
											{
												Debug.Log("This character just set their destination to themself.");
												if (Club == ClubType.Council)
												{
													Debug.Log("The reporter was a student council member.");
													if (StudentID == 86)
													{
														Subtitle.UpdateLabel(SubtitleType.StrictReport, 3, 5f);
													}
													else if (StudentID == 87)
													{
														Subtitle.UpdateLabel(SubtitleType.CasualReport, 3, 5f);
													}
													else if (StudentID == 88)
													{
														Subtitle.UpdateLabel(SubtitleType.GraceReport, 3, 5f);
													}
													else if (StudentID == 89)
													{
														Subtitle.UpdateLabel(SubtitleType.EdgyReport, 3, 5f);
													}
												}
												else
												{
													Subtitle.Speaker = this;
													Subtitle.UpdateLabel(SubtitleType.PrankReaction, 1, 5f);
												}
											}
											Pathfinding.target = base.transform;
											CurrentDestination = base.transform;
											CharacterAnimation.CrossFade(ScaredAnim);
											ReportTimer += Time.deltaTime;
											if (ReportTimer >= 5f)
											{
												ReturnToNormal();
											}
										}
										if (MyTeacher != null && MyTeacher.Guarding && Club == ClubType.Council)
										{
											CharacterAnimation.CrossFade(GuardAnim);
											Persona = PersonaType.Dangerous;
											Guarding = true;
											Fleeing = false;
										}
									}
									else if (Club == ClubType.Council)
									{
										CharacterAnimation.CrossFade(GuardAnim);
										Persona = PersonaType.Dangerous;
										Guarding = true;
										Fleeing = false;
									}
									else
									{
										CharacterAnimation.CrossFade(ParanoidAnim);
										ReportPhase = 100;
										Fleeing = false;
										Persona = OriginalPersona;
										IgnoringPettyActions = true;
										Guarding = true;
									}
								}
								else if (Persona == PersonaType.Heroic)
								{
									if (Yandere.Attacking || (Yandere.Struggling && Yandere.StruggleBar.Student != this))
									{
										CharacterAnimation.CrossFade(ReadyToFightAnim);
										targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
										Pathfinding.canSearch = false;
										Pathfinding.canMove = false;
									}
									else if (!Yandere.Attacking && !StudentManager.PinningDown && !Yandere.Shoved && !Yandere.Dumping && !Yandere.Dropping)
									{
										if (StudentID > 1)
										{
											if (!Yandere.Struggling && !Yandere.StruggleBar.gameObject.activeInHierarchy && Yandere.RPGCamera.enabled)
											{
												bool flag4 = false;
												if (!StudentManager.ChallengeManager.InvincibleRaibaru && Yandere.PhysicalGrade + Yandere.Class.PhysicalBonus > 0)
												{
													Debug.Log("Player meets the criteria to have a physical struggle with Raibaru.");
													flag4 = true;
												}
												if (Strength == 7)
												{
													Debug.Log(Name + " is calling Spray() from this place in the code.");
													Spray();
												}
												else if (Strength == 9 && !flag4)
												{
													Debug.Log(Name + " is calling InvincibleTakedown() from this place in the code.");
													InvincibleTakedown();
												}
												else if (Frame > 0)
												{
													Debug.Log(Name + " is calling BeginStruggle() from this place in the code.");
													BeginStruggle();
												}
												Frame++;
											}
											if (!Spraying)
											{
												Debug.Log(Name + " is currently engaged in a stuggle.");
												CharacterAnimation.CrossFade(StruggleAnim);
												if (!Teacher)
												{
													CharacterAnimation[StruggleAnim].time = Yandere.CharacterAnimation["f02_struggleA_00"].time;
												}
												else
												{
													CharacterAnimation[StruggleAnim].time = Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time;
												}
												base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Yandere.transform.rotation, 10f * Time.deltaTime);
												if (!StopSliding)
												{
													MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward * 0.425f);
												}
												if (!Yandere.Armed)
												{
													CheckForKnifeInInventory();
												}
												if ((!Yandere.Armed || !Yandere.EquippedWeapon.Concealable || Yandere.EquippedWeapon.Broken || Yandere.EquippedWeapon.Type == WeaponType.Garrote) && !Yandere.Lost)
												{
													BeginStruggle();
													Yandere.StruggleBar.HeroWins();
												}
												if (Lost)
												{
													CharacterAnimation.CrossFade(StruggleWonAnim);
													if (CharacterAnimation[StruggleWonAnim].time > 1f)
													{
														EyeShrink = 1f;
													}
												}
												else if (Won)
												{
													CharacterAnimation.CrossFade(StruggleLostAnim);
												}
											}
										}
										else if (Yandere.Mask != null)
										{
											Yandere.EmptyHands();
											Pathfinding.canSearch = false;
											Pathfinding.canMove = false;
											TargetDistance = 1f;
											Yandere.CharacterAnimation.CrossFade("f02_unmasking_00");
											string text8 = "";
											text8 = ((!Male) ? "f02_unmasking_01" : "unmasking_00");
											CharacterAnimation.CrossFade(text8);
											Yandere.CanMove = false;
											targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
											base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
											MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward * 1f);
											if (CharacterAnimation[text8].time == 0f)
											{
												Yandere.ShoulderCamera.YandereNo();
												Yandere.Jukebox.GameOver();
											}
											if (CharacterAnimation[text8].time >= 0.66666f && Yandere.Mask.transform.parent != LeftHand)
											{
												Yandere.CanMove = true;
												Yandere.EmptyHands();
												Yandere.CanMove = false;
												Yandere.Mask.transform.parent = LeftHand;
												Yandere.Mask.transform.localPosition = new Vector3(-0.1f, -0.05f, 0f);
												Yandere.Mask.transform.localEulerAngles = new Vector3(-90f, 90f, 0f);
												Yandere.Mask.transform.localScale = new Vector3(1f, 1f, 1f);
											}
											if (CharacterAnimation[text8].time >= CharacterAnimation[text8].length)
											{
												Yandere.Unmasked = true;
												Yandere.ShoulderCamera.GameOver();
												Yandere.Mask.Drop();
											}
										}
									}
									else
									{
										CharacterAnimation.CrossFade(ReadyToFightAnim);
									}
								}
								else if (Persona == PersonaType.Coward || Persona == PersonaType.Fragile)
								{
									targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
									CharacterAnimation.CrossFade(CowardAnim);
									if (!StudentManager.KokonaTutorial)
									{
										ReactionTimer += Time.deltaTime;
										if (ReactionTimer > 5f)
										{
											CurrentDestination = StudentManager.Exit;
											Pathfinding.target = StudentManager.Exit;
										}
									}
								}
								else if (Persona == PersonaType.Evil)
								{
									targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
									CharacterAnimation.CrossFade(EvilAnim);
									ReactionTimer += Time.deltaTime;
									if (ReactionTimer > 5f)
									{
										CurrentDestination = StudentManager.Exit;
										Pathfinding.target = StudentManager.Exit;
									}
								}
								else if (Persona == PersonaType.SocialButterfly)
								{
									if (ReportPhase < 4)
									{
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Pathfinding.target.rotation, 10f * Time.deltaTime);
									}
									if (ReportPhase == 1)
									{
										if (!SmartPhone.activeInHierarchy)
										{
											if (StudentManager.Reporter == null && !Police.Called)
											{
												CharacterAnimation.CrossFade(SocialReportAnim);
												Subtitle.UpdateLabel(SubtitleType.SocialReport, 1, 5f);
												StudentManager.Reporter = this;
												SmartPhone.SetActive(value: true);
												SmartPhone.transform.localPosition = new Vector3(-0.015f, -0.01f, 0f);
												SmartPhone.transform.localEulerAngles = new Vector3(0f, -170f, 165f);
											}
											else
											{
												ReportTimer = 5f;
											}
										}
										ReportTimer += Time.deltaTime;
										if (ReportTimer > 5f)
										{
											if (StudentManager.Reporter == this && !StudentManager.Jammed)
											{
												Debug.Log(Name + " just called the cops.");
												Police.Called = true;
												Police.Show = true;
											}
											CharacterAnimation.CrossFade(ParanoidAnim);
											SmartPhone.SetActive(value: false);
											ReportPhase++;
											Halt = false;
										}
									}
									else if (ReportPhase == 2)
									{
										if (WitnessedMurder && (!SawMask || (SawMask && Yandere.Mask != null)))
										{
											LookForYandere();
										}
									}
									else if (ReportPhase == 3)
									{
										CharacterAnimation.CrossFade(SocialFearAnim);
										Subtitle.UpdateLabel(SubtitleType.SocialFear, 1, 5f);
										SpawnAlarmDisc();
										ReportPhase++;
										Halt = true;
									}
									else if (ReportPhase == 4)
									{
										targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
										if (Yandere.Attacking)
										{
											LookForYandere();
										}
									}
									else if (ReportPhase == 5)
									{
										CharacterAnimation.CrossFade(SocialTerrorAnim);
										Subtitle.UpdateLabel(SubtitleType.SocialTerror, 1, 5f);
										VisionDistance = 0f;
										SpawnAlarmDisc();
										ReportPhase++;
									}
								}
								else if (Persona == PersonaType.Lovestruck)
								{
									if (ReportPhase < 3)
									{
										if (LovestruckTarget == 0 || StudentManager.Students[LovestruckTarget] == null || StudentManager.Students[LovestruckTarget].Fleeing)
										{
											Debug.Log("Lovestruck Target is null or fleeing, so destination is being set to Exit.");
											Pathfinding.target = StudentManager.Exit;
											CurrentDestination = StudentManager.Exit;
											ReportPhase = 3;
										}
										else if (StudentManager.Students[LovestruckTarget].InEvent && StudentManager.Students[LovestruckTarget].Ragdoll.Zs.activeInHierarchy)
										{
											Debug.Log("Lovestruck Target is asleep, so she needs to be woken up first.");
											StudentManager.Yandere.Class.Portal.OsanaThursdayEvent.EndEvent();
										}
									}
									if (ReportPhase == 1)
									{
										if (!StudentManager.Students[LovestruckTarget].gameObject.activeInHierarchy || StudentManager.Students[LovestruckTarget].Ragdoll.Concealed || StudentManager.Students[LovestruckTarget].Ragdoll.Zs.activeInHierarchy)
										{
											Debug.Log("A character wants to run to someone to tell them about murder, but that character is either gone or in a garbage bag.");
											Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 5, 10f);
											Pathfinding.target = StudentManager.Exit;
											CurrentDestination = StudentManager.Exit;
											Pathfinding.enabled = true;
											ReportPhase = 3;
										}
										else if (!StudentManager.Students[LovestruckTarget].Alive)
										{
											CurrentDestination = Corpse.Student.Hips;
											Pathfinding.target = Corpse.Student.Hips;
											SpecialRivalDeathReaction = true;
											WitnessRivalDiePhase = 1;
											Fleeing = false;
											Routine = false;
											TargetDistance = 0.5f;
										}
										else if (StudentManager.Students[LovestruckTarget].Routine && Yandere.CanMove)
										{
											if (StudentManager.Students[LovestruckTarget].Male)
											{
												StudentManager.Students[LovestruckTarget].CharacterAnimation.CrossFade("surprised_00");
											}
											else
											{
												StudentManager.Students[LovestruckTarget].CharacterAnimation.CrossFade("f02_surprised_00");
											}
											StudentManager.Students[LovestruckTarget].EmptyHands();
											CharacterAnimation.CrossFade(ScaredAnim);
											StudentManager.Students[LovestruckTarget].Pathfinding.canSearch = false;
											StudentManager.Students[LovestruckTarget].Pathfinding.canMove = false;
											StudentManager.Students[LovestruckTarget].Pathfinding.enabled = false;
											StudentManager.Students[LovestruckTarget].Investigating = false;
											StudentManager.Students[LovestruckTarget].CheckingNote = false;
											StudentManager.Students[LovestruckTarget].Meeting = false;
											StudentManager.Students[LovestruckTarget].AwareOfCorpse = true;
											StudentManager.Students[LovestruckTarget].Routine = false;
											StudentManager.Students[LovestruckTarget].Blind = true;
											ReportingMurderToSenpai = true;
											Pathfinding.enabled = false;
											if (WitnessedMurder && !SawMask)
											{
												Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
												Yandere.Jukebox.gameObject.active = false;
												Yandere.MainCamera.enabled = false;
												Yandere.RPGCamera.enabled = false;
												Yandere.Jukebox.Volume = 0f;
												Yandere.CanMove = false;
												StudentManager.LovestruckCamera.transform.parent = base.transform;
												StudentManager.LovestruckCamera.transform.localPosition = new Vector3(1f, 1f, -1f);
												StudentManager.LovestruckCamera.transform.localEulerAngles = new Vector3(0f, -30f, 0f);
												StudentManager.LovestruckCamera.active = true;
												Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(Hips.transform.position.x, Yandere.transform.position.y, Hips.transform.position.z) - Yandere.transform.position);
											}
											if (WitnessedMurder && !SawMask)
											{
												Subtitle.UpdateLabel(SubtitleType.LovestruckMurderReport, 0, 5f);
											}
											else if (LovestruckTarget == 1)
											{
												Subtitle.UpdateLabel(SubtitleType.LovestruckCorpseReport, 0, 5f);
											}
											else
											{
												Subtitle.UpdateLabel(SubtitleType.LovestruckCorpseReport, 1, 5f);
											}
											ReportPhase++;
										}
										else
										{
											Debug.Log("The character who needs to be warned is currently in an event, or Yandere-chan's CanMove is false...");
											CharacterAnimation.CrossFade(ScaredAnim);
											StudentManager.Students[LovestruckTarget].LovestruckWaiting = true;
											if (StudentManager.Students[LovestruckTarget].Confessing)
											{
												StudentManager.Students[LovestruckTarget].Confessing = false;
												StudentManager.Students[LovestruckTarget].Routine = true;
											}
										}
									}
									else if (ReportPhase == 2)
									{
										targetRotation = Quaternion.LookRotation(new Vector3(StudentManager.Students[LovestruckTarget].transform.position.x, base.transform.position.y, StudentManager.Students[LovestruckTarget].transform.position.z) - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
										targetRotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, StudentManager.Students[LovestruckTarget].transform.position.y, base.transform.position.z) - StudentManager.Students[LovestruckTarget].transform.position);
										StudentManager.Students[LovestruckTarget].transform.rotation = Quaternion.Slerp(StudentManager.Students[LovestruckTarget].transform.rotation, targetRotation, 10f * Time.deltaTime);
										ReportTimer += Time.deltaTime;
										if (ReportTimer > 5f)
										{
											if (WitnessedMurder && !SawMask)
											{
												Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(value: true);
												Yandere.Police.EndOfDay.Heartbroken.Exposed = true;
												Yandere.CharacterAnimation.CrossFade("f02_down_22");
												Yandere.Collapse = true;
												StudentManager.LovestruckCamera.SetActive(value: false);
												StudentManager.StopMoving();
												ReportPhase++;
											}
											else
											{
												Debug.Log("Both reporter and Lovestruck Target should be heading to the Exit.");
												StudentManager.Students[LovestruckTarget].Pathfinding.target = StudentManager.Exit;
												StudentManager.Students[LovestruckTarget].CurrentDestination = StudentManager.Exit;
												StudentManager.Students[LovestruckTarget].CharacterAnimation.CrossFade(StudentManager.Students[LovestruckTarget].SprintAnim);
												StudentManager.Students[LovestruckTarget].Pathfinding.canSearch = true;
												StudentManager.Students[LovestruckTarget].Pathfinding.canMove = true;
												StudentManager.Students[LovestruckTarget].Pathfinding.enabled = true;
												StudentManager.Students[LovestruckTarget].Pathfinding.speed = 4f;
												Pathfinding.target = StudentManager.Exit;
												CurrentDestination = StudentManager.Exit;
												Pathfinding.enabled = true;
												ReportPhase++;
											}
										}
									}
									else
									{
										Debug.Log("Lovestruck student is running for an exit.");
										if (StudentID == 10)
										{
											Debug.Log("The Lovestruck student is Raibaru.");
										}
										if (FollowTarget != null)
										{
											Debug.Log("Raibaru knows about Osana.");
										}
										if (FollowTarget != null && Vector3.Distance(base.transform.position, FollowTarget.transform.position) < 10f && FollowTarget.Attacked && FollowTarget.Alive && !FollowTarget.Tranquil && !Blind)
										{
											Debug.Log("Raibaru should be aware that Osana is being attacked.");
											AwareOfMurder = true;
											Alarm = 200f;
										}
									}
								}
								else if (Persona == PersonaType.Dangerous || Strength == 7)
								{
									if (Pathfinding.target == Yandere.transform && !Yandere.Attacking && !StudentManager.PinningDown && !Yandere.Struggling && !Yandere.Noticed && !Yandere.Invisible)
									{
										Debug.Log("Calling ''Spray()'' from this part of the code. 1");
										Spray();
									}
									else
									{
										CharacterAnimation.CrossFade(ReadyToFightAnim);
									}
								}
								else if (Persona == PersonaType.Protective || Strength == 9)
								{
									if (!Yandere.Dumping && !Yandere.Attacking && !Yandere.Struggling)
									{
										if (Strength >= 9)
										{
											Debug.Log("A protective student is calling InvincibleTakedown() now.");
											InvincibleTakedown();
										}
										else
										{
											Debug.Log("This student's Strength is less than 9, so they should enter a struggle when trying to apprehend the player.");
											CheckForKnifeInInventory();
											BeginStruggle();
										}
									}
									else if (!Struggling)
									{
										CharacterAnimation.CrossFade(ReadyToFightAnim);
									}
								}
								else if (Persona == PersonaType.Violent)
								{
									if (!Yandere.Attacking && !Yandere.Struggling && !Yandere.Dumping && !Yandere.SneakingShot && !StudentManager.PinningDown && !RespectEarned)
									{
										if (!Yandere.DelinquentFighting)
										{
											Debug.Log(Name + " is supposed to begin the combat minigame now.");
											SmartPhone.SetActive(value: false);
											Threatened = true;
											Fleeing = false;
											Alarmed = true;
											NoTalk = false;
											Patience = 0;
										}
									}
									else
									{
										CharacterAnimation.CrossFade(ReadyToFightAnim);
									}
								}
								else if (Persona == PersonaType.Strict)
								{
									if (!WitnessedMurder)
									{
										if (ReportPhase == 0)
										{
											if (MyReporter.WitnessedMurder || MyReporter.WitnessedCorpse)
											{
												Subtitle.Speaker = this;
												Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 0, 3f);
												InvestigatingPossibleDeath = true;
											}
											else if (MyReporter.WitnessedLimb)
											{
												Subtitle.Speaker = this;
												Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 2, 3f);
											}
											else if (MyReporter.WitnessedBloodyWeapon)
											{
												Subtitle.Speaker = this;
												Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 3, 3f);
											}
											else if (MyReporter.WitnessedBloodPool)
											{
												Subtitle.Speaker = this;
												Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 1, 3f);
											}
											else if (MyReporter.WitnessedWeapon)
											{
												Subtitle.Speaker = this;
												Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 4, 3f);
											}
											ReportPhase++;
										}
										else if (ReportPhase == 1)
										{
											CharacterAnimation.CrossFade(IdleAnim);
											ReportTimer += Time.deltaTime;
											if (ReportTimer >= 3f)
											{
												base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
												StudentScript studentScript3 = null;
												if (MyReporter != null)
												{
													Debug.Log("MyReporter.WitnessedMurder is: " + MyReporter.WitnessedMurder);
													Debug.Log("MyReporter.WitnessedCorpse is: " + MyReporter.WitnessedCorpse);
													Debug.Log("MyReporter.WitnessedBloodPool is: " + MyReporter.WitnessedBloodPool);
													Debug.Log("MyReporter.WitnessedLimb is: " + MyReporter.WitnessedLimb);
													Debug.Log("MyReporter.WitnessedWeapon is: " + MyReporter.WitnessedWeapon);
													if (MyReporter.WitnessedMurder || MyReporter.WitnessedCorpse)
													{
														studentScript3 = StudentManager.Reporter;
													}
													else if (MyReporter.WitnessedBloodPool || MyReporter.WitnessedLimb || MyReporter.WitnessedWeapon)
													{
														Debug.Log("Assigning RelevantReporter here.");
														studentScript3 = StudentManager.BloodReporter;
													}
													if (MyReporter.WitnessedLimb)
													{
														InvestigatingPossibleLimb = true;
													}
													if (MyReporter.WitnessedBloodPool)
													{
														InvestigatingPossibleBlood = true;
													}
													if (studentScript3 == null)
													{
														Debug.Log("For some reason, RelevantReporter was null...");
													}
													if (!studentScript3.Teacher)
													{
														if (MyReporter.WitnessedMurder || MyReporter.WitnessedCorpse)
														{
															if (ExamineCorpseTarget == null)
															{
																Debug.Log(Name + "'s CurrentDestination is manually being forced to CorpseLocation.");
																StudentManager.Reporter.CurrentDestination = StudentManager.CorpseLocation;
																StudentManager.Reporter.Pathfinding.target = StudentManager.CorpseLocation;
																CurrentDestination = StudentManager.CorpseLocation;
																Pathfinding.target = StudentManager.CorpseLocation;
															}
															StudentManager.Reporter.TargetDistance = 2f;
														}
														else if (MyReporter.WitnessedBloodPool || MyReporter.WitnessedLimb || MyReporter.WitnessedWeapon)
														{
															Debug.Log("Setting BloodReporter's destination to BloodLocation.");
															StudentManager.BloodReporter.CurrentDestination = StudentManager.BloodLocation;
															StudentManager.BloodReporter.Pathfinding.target = StudentManager.BloodLocation;
															CurrentDestination = StudentManager.BloodLocation;
															Pathfinding.target = StudentManager.BloodLocation;
															StudentManager.BloodReporter.TargetDistance = 2f;
														}
													}
												}
												TargetDistance = 1f;
												ReportTimer = 0f;
												ReportPhase++;
											}
										}
										else if (ReportPhase == 2)
										{
											if (WitnessedCorpse)
											{
												Debug.Log("A teacher has just witnessed a corpse while on their way to investigate a student's report of a corpse.");
												DetermineCorpseLocation();
												if (!Corpse.Poisoned)
												{
													Subtitle.Speaker = this;
													Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 1, 5f);
												}
												else
												{
													Subtitle.Speaker = this;
													Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 2, 2f);
												}
												ReportPhase++;
											}
											else if (WitnessedBloodPool || WitnessedLimb || WitnessedWeapon)
											{
												Debug.Log("A teacher has just witnessed an alarming object while on their way to investigate a student's report - a " + BloodPool.name);
												DetermineBloodLocation();
												if (!VerballyReacted)
												{
													if (WitnessedLimb)
													{
														Subtitle.Speaker = this;
														Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 4, 5f);
													}
													else if (WitnessedBloodPool || WitnessedBloodyWeapon)
													{
														Subtitle.Speaker = this;
														Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 3, 5f);
													}
													else if (WitnessedWeapon)
													{
														Subtitle.Speaker = this;
														Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 5, 5f);
													}
												}
												PromptScript component2 = BloodPool.GetComponent<PromptScript>();
												WeaponScript component3 = BloodPool.GetComponent<WeaponScript>();
												bool flag5 = false;
												if (component3 != null)
												{
													if (component3.BroughtFromHome)
													{
														Debug.Log("This weapon was brought from home!");
														flag5 = true;
													}
													else
													{
														Debug.Log("This weapon was not brought from home.");
													}
												}
												if (component2 != null && !flag5)
												{
													Debug.Log("Disabling an object's prompt.");
													component2.Hide();
													component2.enabled = false;
													TargetDistance = 1.5f;
												}
												ReportPhase++;
											}
											else
											{
												CharacterAnimation.CrossFade(GuardAnim);
												if (BloodPool == null && StudentManager.Police.BloodParent.childCount > 0 && !InvestigatingPossibleLimb)
												{
													UpdateVisibleBlood();
												}
												ReportTimer += Time.deltaTime;
												if (ReportTimer > 5f)
												{
													Subtitle.Speaker = this;
													Subtitle.UpdateLabel(SubtitleType.TeacherPrankReaction, 1, 7f);
													ReportPhase = 98;
													ReportTimer = 0f;
												}
											}
										}
										else if (ReportPhase == 3)
										{
											if (WitnessedCorpse)
											{
												targetRotation = Quaternion.LookRotation(new Vector3(Corpse.AllColliders[0].transform.position.x, base.transform.position.y, Corpse.AllColliders[0].transform.position.z) - base.transform.position);
												base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
												CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
												if (!Male)
												{
													CharacterAnimation.CrossFade(InspectAnim);
												}
												else
												{
													CharacterAnimation.CrossFade(GuardAnim);
												}
											}
											else if (WitnessedBloodPool || WitnessedLimb || WitnessedWeapon)
											{
												if (BloodPool != null)
												{
													targetRotation = Quaternion.LookRotation(new Vector3(BloodPool.transform.position.x, base.transform.position.y, BloodPool.transform.position.z) - base.transform.position);
												}
												base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
												CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
												CharacterAnimation[InspectBloodAnim].speed = 0.66666f;
												CharacterAnimation.CrossFade(InspectBloodAnim);
											}
											ReportTimer += Time.deltaTime;
											if (ReportTimer >= 6f)
											{
												ReportTimer = 0f;
												if (WitnessedWeapon && !WitnessedBloodyWeapon)
												{
													ReportPhase = 7;
												}
												else
												{
													Debug.Log("A character is now checking whether or not they have a phone.");
													if (Teacher)
													{
														Phoneless = false;
													}
													if (!Phoneless)
													{
														Debug.Log("This character has a phone.");
														ReportPhase++;
													}
													else
													{
														Debug.Log("This character has no phone.");
														ReportPhase += 2;
													}
												}
											}
										}
										else if (ReportPhase == 4)
										{
											Debug.Log("A teacher is now supposed to be saying a line of dialogue about a corpse or blood.");
											if (WitnessedCorpse)
											{
												Subtitle.Speaker = this;
												Subtitle.UpdateLabel(SubtitleType.TeacherPoliceReport, 0, 5f);
											}
											else if (WitnessedBloodPool || WitnessedLimb || WitnessedWeapon)
											{
												Subtitle.Speaker = this;
												Subtitle.UpdateLabel(SubtitleType.TeacherPoliceReport, 1, 5f);
											}
											if (!StudentManager.Eighties)
											{
												SmartPhone.transform.localPosition = new Vector3(-0.01f, -0.005f, -0.02f);
												SmartPhone.transform.localEulerAngles = new Vector3(-10f, -145f, 170f);
											}
											else
											{
												SmartPhone.transform.localPosition = new Vector3(0f, -0.022f, 0f);
												SmartPhone.transform.localEulerAngles = new Vector3(90f, 45f, 0f);
												SmartPhone.transform.localScale = new Vector3(66.66666f, 66.66666f, 66.66666f);
											}
											if (Teacher)
											{
												SmartPhone.SetActive(value: true);
											}
											else
											{
												SmartPhone.SetActive(value: false);
											}
											ReportPhase++;
										}
										else if (ReportPhase == 5)
										{
											Debug.Log("A teacher is now supposed to be performing a ''calling police'' animation.");
											if (Teacher)
											{
												CharacterAnimation.CrossFade(CallAnim);
											}
											else
											{
												Pathfinding.target = StudentManager.Exit;
												CurrentDestination = StudentManager.Exit;
											}
											ReportTimer += Time.deltaTime;
											if (ReportTimer >= 5f)
											{
												CharacterAnimation.CrossFade(GuardAnim);
												SmartPhone.SetActive(value: false);
												WitnessedBloodyWeapon = false;
												WitnessedBloodPool = false;
												WitnessedSomething = false;
												WitnessedWeapon = false;
												WitnessedLimb = false;
												IgnoringPettyActions = true;
												if (!StudentManager.Jammed)
												{
													Debug.Log(Name + " just called the cops.");
													Police.Called = true;
													Police.Show = true;
												}
												ReportTimer = 0f;
												Guarding = true;
												Alarmed = false;
												Fleeing = false;
												Reacted = false;
												ReportPhase++;
												if (MyReporter != null && MyReporter.ReportingBlood)
												{
													Debug.Log("The blood reporter has just been instructed to stop following the teacher.");
													MyReporter.ReportPhase++;
												}
											}
										}
										else if (ReportPhase == 6)
										{
											if (Corpse != null && Corpse.Concealed)
											{
												Alarm = 200f;
												Yandere.PotentiallyMurderousTimer = 1f;
												Witnessed = StudentWitnessType.Murder;
											}
										}
										else if (ReportPhase == 7)
										{
											if (StudentManager.BloodReporter != this)
											{
												StudentManager.BloodReporter = null;
											}
											StudentManager.UpdateStudents();
											BloodPool.GetComponent<WeaponScript>().Prompt.enabled = false;
											BloodPool.GetComponent<WeaponScript>().Prompt.Hide();
											BloodPool.GetComponent<WeaponScript>().enabled = false;
											Debug.Log("A WeaponScript has been disabled from this part of the code. 1");
											ReportPhase++;
										}
										else if (ReportPhase == 8)
										{
											CharacterAnimation.CrossFade("f02_teacherPickUp_00");
											if (CharacterAnimation["f02_teacherPickUp_00"].time >= 0.33333f)
											{
												Handkerchief.SetActive(value: true);
											}
											if (CharacterAnimation["f02_teacherPickUp_00"].time >= 2f)
											{
												BloodPool.parent = RightHand;
												BloodPool.localPosition = new Vector3(0f, 0f, 0f);
												BloodPool.localEulerAngles = new Vector3(0f, 0f, 0f);
												BloodPool.GetComponent<WeaponScript>().Returner = this;
											}
											if (CharacterAnimation["f02_teacherPickUp_00"].time >= CharacterAnimation["f02_teacherPickUp_00"].length)
											{
												CurrentDestination = StudentManager.WeaponBoxSpot;
												Pathfinding.target = StudentManager.WeaponBoxSpot;
												Pathfinding.speed = WalkSpeed;
												Hurry = false;
												ReportPhase++;
												if (MyReporter != null)
												{
													Debug.Log("Telling reporter to go back to their normal routine.");
													MyReporter.CurrentDestination = MyReporter.Destinations[MyReporter.Phase];
													MyReporter.Pathfinding.target = MyReporter.Destinations[MyReporter.Phase];
													MyReporter.Pathfinding.speed = 1f;
													MyReporter.ReportTimer = 0f;
													MyReporter.AlarmTimer = 0f;
													MyReporter.TargetDistance = 1f;
													MyReporter.ReportPhase = 0;
													MyReporter.WitnessedSomething = false;
													MyReporter.WitnessedWeapon = false;
													MyReporter.Distracted = false;
													MyReporter.Reacted = false;
													MyReporter.Alarmed = false;
													MyReporter.Fleeing = false;
													MyReporter.Routine = true;
													MyReporter.Halt = false;
													MyReporter.Persona = MyReporter.OriginalPersona;
													MyReporter.BloodPool = null;
													if (MyReporter.Club == ClubType.Council)
													{
														MyReporter.Persona = PersonaType.Dangerous;
													}
													for (ID = 0; ID < MyReporter.Outlines.Length; ID++)
													{
														if (MyReporter.Outlines[ID] != null)
														{
															MyReporter.Outlines[ID].color = new Color(1f, 1f, 0f, 1f);
														}
													}
													if (MyReporter.BeforeReturnAnim != "")
													{
														MyReporter.WalkAnim = MyReporter.BeforeReturnAnim;
													}
												}
											}
										}
										else if (ReportPhase == 9)
										{
											DropWeaponInBox();
											CharacterAnimation.CrossFade(RunAnim);
											CurrentDestination = Destinations[Phase];
											Pathfinding.target = Destinations[Phase];
											Pathfinding.canSearch = true;
											Pathfinding.canMove = true;
											Pathfinding.speed = WalkSpeed;
											WitnessedSomething = false;
											VerballyReacted = false;
											WitnessedWeapon = false;
											YandereInnocent = false;
											ReportingBlood = false;
											Distracted = false;
											Alarmed = false;
											Fleeing = false;
											Routine = true;
											Halt = false;
											ReportTimer = 0f;
											ReportPhase = 0;
										}
										else if (ReportPhase == 98)
										{
											CharacterAnimation.CrossFade(IdleAnim);
											targetRotation = Quaternion.LookRotation(MyReporter.transform.position - base.transform.position);
											base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
											ReportTimer += Time.deltaTime;
											if (ReportTimer > 7f)
											{
												ReportPhase++;
											}
										}
										else if (ReportPhase == 99)
										{
											CharacterAnimation.CrossFade(RunAnim);
											CurrentDestination = Destinations[Phase];
											Pathfinding.target = Destinations[Phase];
											Pathfinding.canSearch = true;
											Pathfinding.canMove = true;
											MyReporter.Persona = PersonaType.TeachersPet;
											MyReporter.ReportPhase = 100;
											MyReporter.Fleeing = true;
											ReportTimer = 0f;
											ReportPhase = 0;
											InvestigatingPossibleBlood = false;
											InvestigatingPossibleDeath = false;
											InvestigatingPossibleLimb = false;
											Alarmed = false;
											Fleeing = false;
											Routine = true;
										}
									}
									else if (!Yandere.Dumping && !Yandere.Attacking)
									{
										if ((Yandere.Armed && Yandere.Class.PhysicalGrade + Yandere.Class.PhysicalBonus > 0 && Yandere.EquippedWeapon.Type == WeaponType.Knife) || (Yandere.Club == ClubType.MartialArts && Yandere.Armed && Yandere.EquippedWeapon.Type == WeaponType.Knife))
										{
											Debug.Log("Yandere-chan is in a state that allows her to enter struggles with teachers, so this teacher is changing into the ''Heroic'' Persona to have a struggle.");
											Persona = PersonaType.Heroic;
										}
										else
										{
											Debug.Log("A teacher is taking down Yandere-chan.");
											if (Yandere.Aiming)
											{
												Yandere.StopAiming();
											}
											Yandere.Mopping = false;
											Yandere.EmptyHands();
											AttackReaction();
											CharacterAnimation[CounterAnim].time = 5f;
											Yandere.CharacterAnimation["f02_teacherCounterA_00"].time = 5f;
											Yandere.ShoulderCamera.Timer = 5f;
											Yandere.ShoulderCamera.Phase = 3;
											Police.Show = false;
											Yandere.CameraEffects.MurderWitnessed();
											Yandere.Jukebox.GameOver();
										}
									}
									else
									{
										CharacterAnimation.CrossFade(ReadyToFightAnim);
									}
								}
								else if (Persona == PersonaType.LandlineUser)
								{
									if (ReportPhase == 1)
									{
										if (StudentManager.Reporter == null && !Police.Called)
										{
											Subtitle.UpdateLabel(SubtitleType.SocialReport, 1, 5f);
											CharacterAnimation.CrossFade(LandLineAnim);
											StudentManager.Reporter = this;
											SpawnAlarmDisc();
											ReportPhase++;
										}
										else
										{
											CharacterAnimation.CrossFade(ParanoidAnim);
											ReportPhase += 2;
											Halt = true;
										}
									}
									else if (ReportPhase == 2)
									{
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Pathfinding.target.rotation, 10f * Time.deltaTime);
										StudentManager.LandLinePhone.SetBlendShapeWeight(1, ReportTimer * 200f);
										ReportTimer += Time.deltaTime;
										if (ReportTimer > 5f)
										{
											if (StudentManager.Reporter == this)
											{
												StudentManager.LandLinePhone.SetBlendShapeWeight(1, 0f);
												if (!StudentManager.Jammed)
												{
													Debug.Log(Name + " just called the cops.");
													Police.Called = true;
													Police.Show = true;
												}
											}
											UnityEngine.Object.Instantiate(EnterGuardStateCollider, base.transform.position, Quaternion.identity);
											CharacterAnimation.CrossFade(ParanoidAnim);
											ReportPhase++;
										}
									}
									else if (ReportPhase == 3)
									{
										if (WitnessedMurder && (!SawMask || (SawMask && Yandere.Mask != null)))
										{
											LookForYandere();
										}
									}
									else if (ReportPhase == 4)
									{
										CharacterAnimation.CrossFade(SocialFearAnim);
										Subtitle.UpdateLabel(SubtitleType.SocialFear, 1, 5f);
										SpawnAlarmDisc();
										ReportPhase++;
										Halt = true;
									}
									else if (ReportPhase == 5)
									{
										targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
										if (Yandere.Attacking)
										{
											LookForYandere();
										}
									}
									else if (ReportPhase == 6)
									{
										CharacterAnimation.CrossFade(SocialTerrorAnim);
										Subtitle.UpdateLabel(SubtitleType.SocialTerror, 1, 5f);
										VisionDistance = 0f;
										SpawnAlarmDisc();
										ReportPhase++;
									}
								}
							}
							if (Persona == PersonaType.Strict && BloodPool != null && BloodPool.parent == Yandere.RightHand)
							{
								Debug.Log("Yandere-chan picked up the weapon that the teacher was investigating!");
								WitnessedBloodyWeapon = false;
								WitnessedBloodPool = false;
								WitnessedSomething = false;
								WitnessedCorpse = false;
								WitnessedMurder = false;
								WitnessedWeapon = false;
								WitnessedLimb = false;
								YandereVisible = true;
								ReportTimer = 0f;
								BloodPool = null;
								ReportPhase = 0;
								Alarmed = false;
								Fleeing = false;
								Routine = true;
								Reacted = false;
								AlarmTimer = 0f;
								Alarm = 200f;
								BecomeAlarmed();
							}
						}
					}
					else if (PinPhase == 0)
					{
						if (DistanceToDestination < 1f)
						{
							if (Pathfinding.canSearch)
							{
								Pathfinding.canSearch = false;
								Pathfinding.canMove = false;
							}
							targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
							CharacterAnimation.CrossFade(ReadyToFightAnim);
							MoveTowardsTarget(CurrentDestination.position);
						}
						else
						{
							CharacterAnimation.CrossFade(SprintAnim);
							if (!Pathfinding.canSearch)
							{
								Pathfinding.canSearch = true;
								Pathfinding.canMove = true;
							}
						}
					}
					else if (PinDownID > 0)
					{
						CharacterAnimation.CrossFade(PinDownAnim);
						CurrentDestination = StudentManager.PinDownSpots[PinDownID];
						Pathfinding.target = StudentManager.PinDownSpots[PinDownID];
						MoveTowardsTarget(CurrentDestination.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
					}
				}
			}
			if (Following && !Waiting)
			{
				DistanceToDestination = Vector3.Distance(base.transform.position, Pathfinding.target.position);
				if (DistanceToDestination > 2f)
				{
					FollowCountdown.Sprite.fillAmount = Mathf.MoveTowards(FollowCountdown.Sprite.fillAmount, 0f, Time.deltaTime * 0.01f);
					CharacterAnimation.CrossFade(RunAnim);
					Pathfinding.speed = 4f;
					Obstacle.enabled = false;
				}
				else if (DistanceToDestination > 1f)
				{
					FollowCountdown.Sprite.fillAmount = Mathf.MoveTowards(FollowCountdown.Sprite.fillAmount, 0f, Time.deltaTime * 0.01f);
					CharacterAnimation.CrossFade(OriginalWalkAnim);
					Pathfinding.canMove = true;
					Obstacle.enabled = false;
					Pathfinding.speed = WalkSpeed;
				}
				else
				{
					if (!Yandere.Succubus)
					{
						if (StudentManager.TranqArea.bounds.Contains(Yandere.transform.position))
						{
							FollowCountdown.Sprite.fillAmount = Mathf.MoveTowards(FollowCountdown.Sprite.fillAmount, 0f, Time.deltaTime * 0.01f);
						}
						else
						{
							FollowCountdown.Sprite.fillAmount = Mathf.MoveTowards(FollowCountdown.Sprite.fillAmount, 0f, Time.deltaTime * 0.1f);
						}
					}
					CharacterAnimation.CrossFade(IdleAnim);
					Pathfinding.canMove = false;
					Obstacle.enabled = true;
				}
				if (Phase < ScheduleBlocks.Length && !Yandere.Succubus && (FollowCountdown.Sprite.fillAmount == 0f || Clock.HourTime >= ScheduleBlocks[Phase].time || StudentManager.LockerRoomArea.bounds.Contains(Yandere.transform.position) || StudentManager.WestBathroomArea.bounds.Contains(Yandere.transform.position) || StudentManager.EastBathroomArea.bounds.Contains(Yandere.transform.position) || StudentManager.IncineratorArea.bounds.Contains(Yandere.transform.position) || StudentManager.HeadmasterArea.bounds.Contains(Yandere.transform.position) || Yandere.Class.Portal.Transition || Yandere.TimeSkipping || Yandere.Trespassing))
				{
					Debug.Log("This student will now stop following Ayano.");
					if (Clock.HourTime >= ScheduleBlocks[Phase].time)
					{
						Phase++;
					}
					CurrentDestination = Destinations[Phase];
					Pathfinding.target = Destinations[Phase];
					ParticleSystem.EmissionModule emission3 = Hearts.emission;
					emission3.enabled = false;
					FollowCountdown.gameObject.SetActive(value: false);
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					Yandere.Follower = null;
					Yandere.Followers--;
					Following = false;
					Routine = true;
					Pathfinding.speed = WalkSpeed;
					if (StudentManager.LockerRoomArea.bounds.Contains(Yandere.transform.position) || StudentManager.WestBathroomArea.bounds.Contains(Yandere.transform.position) || StudentManager.EastBathroomArea.bounds.Contains(Yandere.transform.position) || StudentManager.IncineratorArea.bounds.Contains(Yandere.transform.position) || StudentManager.HeadmasterArea.bounds.Contains(Yandere.transform.position) || Yandere.Trespassing)
					{
						Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 1, 3f);
					}
					else if (Yandere.TimeSkipping)
					{
						Subtitle.CustomText = "If you're just going to stand there spacing out, I'm leaving...";
						Subtitle.UpdateLabel(SubtitleType.Custom, 0, 10f);
					}
					else
					{
						Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
					}
					if (!StudentManager.Eighties && StudentID == 41)
					{
						Subtitle.CustomText = "I'm leaving.";
						Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
					}
					Prompt.Label[0].text = "     Talk";
				}
			}
			if (Wet)
			{
				if (DistanceToDestination < TargetDistance)
				{
					if (!Splashed)
					{
						if (!InDarkness)
						{
							if (NotActuallyWet && BathePhase < 5)
							{
								BathePhase = 5;
							}
							if (BathePhase == 1)
							{
								if (StudentManager.CommunalLocker.Student == null)
								{
									CharacterAnimation[WetAnim].weight = 0f;
									StudentManager.CommunalLocker.Open = true;
									StudentManager.CommunalLocker.Student = this;
									StudentManager.CommunalLocker.SpawnSteam();
									Pathfinding.speed = WalkSpeed;
									Schoolwear = 0;
									BathePhase++;
									Distracted = true;
								}
								else
								{
									CharacterAnimation.CrossFade(IdleAnim);
									Pathfinding.canSearch = false;
									Pathfinding.canMove = false;
								}
							}
							else if (BathePhase == 2)
							{
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
								MoveTowardsTarget(CurrentDestination.position);
								if (Club == ClubType.Cooking && ApronAttacher.newRenderer.enabled)
								{
									ApronAttacher.newRenderer.enabled = false;
								}
							}
							else if (BathePhase == 3)
							{
								StudentManager.CommunalLocker.Open = false;
								CharacterAnimation.CrossFade(WalkAnim);
								if (!BatheFast)
								{
									if (!Male)
									{
										CurrentDestination = StudentManager.FemaleBatheSpot;
										Pathfinding.target = StudentManager.FemaleBatheSpot;
									}
									else
									{
										CurrentDestination = StudentManager.MaleBatheSpot;
										Pathfinding.target = StudentManager.MaleBatheSpot;
									}
								}
								else if (!Male)
								{
									CurrentDestination = StudentManager.FastBatheSpot;
									Pathfinding.target = StudentManager.FastBatheSpot;
								}
								else
								{
									CurrentDestination = StudentManager.MaleBatheSpot;
									Pathfinding.target = StudentManager.MaleBatheSpot;
								}
								Pathfinding.canSearch = true;
								Pathfinding.canMove = true;
								BathePhase++;
							}
							else if (BathePhase == 4)
							{
								if (!Male)
								{
									StudentManager.OpenValue = Mathf.Lerp(StudentManager.OpenValue, 0f, Time.deltaTime * 10f);
									StudentManager.FemaleShowerCurtain.SetBlendShapeWeight(1, StudentManager.OpenValue);
								}
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
								MoveTowardsTarget(CurrentDestination.position);
								CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
								CharacterAnimation.CrossFade(BathingAnim);
								if (CharacterAnimation[BathingAnim].time >= CharacterAnimation[BathingAnim].length)
								{
									CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
									if (!Male)
									{
										StudentManager.OpenCurtain = true;
									}
									LiquidProjector.enabled = false;
									Bloody = false;
									BathePhase++;
									Gas = false;
									GoChange();
									UnWet();
								}
							}
							else if (BathePhase == 5)
							{
								if (StudentManager.CommunalLocker.Student == null)
								{
									StudentManager.CommunalLocker.Open = true;
									StudentManager.CommunalLocker.Student = this;
									StudentManager.CommunalLocker.SpawnSteam();
									Schoolwear = (InEvent ? 1 : 3);
									if (NotActuallyWet)
									{
										Schoolwear = 1;
										if (Follower != null && Follower.FollowTarget != null && Follower.CurrentAction == StudentActionType.Sunbathe)
										{
											Follower.Schoolwear = 1;
											Follower.ChangeSchoolwear();
											Follower.CurrentAction = StudentActionType.Follow;
										}
									}
									Debug.Log("Time to decide if a special case applies to this character.");
									if (Club == ClubType.Sports && Clock.Period > 5 && !StudentManager.PoolClosed)
									{
										Debug.Log("Sports Club special case! Swimsuit!");
										Schoolwear = 2;
									}
									BathePhase++;
								}
								else
								{
									CharacterAnimation.CrossFade(IdleAnim);
									Pathfinding.canSearch = false;
									Pathfinding.canMove = false;
								}
							}
							else if (BathePhase == 6)
							{
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
								MoveTowardsTarget(CurrentDestination.position);
								if (Club == ClubType.Cooking && !ApronAttacher.newRenderer.enabled)
								{
									ApronAttacher.newRenderer.enabled = true;
									Debug.Log("We are being told to re-enable this apron attacher...");
								}
								BatheTimer += Time.deltaTime;
								if (BatheTimer > 5f)
								{
									Debug.Log("Something went wrong. This student didn't change clothing like they were supposed to.");
									BatheTimer = 0f;
									BathePhase--;
								}
							}
							else if (BathePhase == 7)
							{
								BatheTimer = 0f;
								if (!Yandere.Inventory.Ring)
								{
									StudentManager.CommunalLocker.Rings.gameObject.SetActive(value: false);
								}
								if (StudentManager.CommunalLocker.RivalPhone.Stolen && Yandere.Inventory.RivalPhoneID == StudentID)
								{
									CharacterAnimation.CrossFade("f02_losingPhone_00");
									Subtitle.UpdateLabel(LostPhoneSubtitleType, 1, 5f);
									RealizePhoneIsMissing();
									Phoneless = true;
									BatheTimer = CharacterAnimation["f02_losingPhone_00"].length;
									BathePhase++;
								}
								else
								{
									StudentManager.CommunalLocker.RivalPhone.gameObject.SetActive(value: false);
									BathePhase++;
								}
							}
							else if (BathePhase == 8)
							{
								if (BatheTimer == 0f)
								{
									BathePhase++;
								}
								else
								{
									BatheTimer = Mathf.MoveTowards(BatheTimer, 0f, Time.deltaTime);
								}
							}
							else if (BathePhase == 9)
							{
								if ((StudentManager.Eighties && StudentID == 30 && StudentManager.CommunalLocker.Rings.Stolen) || (!StudentManager.Eighties && StudentID == 2 && StudentManager.CommunalLocker.Rings.Stolen))
								{
									CharacterAnimation.CrossFade("f02_losingPhone_00");
									if (StudentManager.Eighties)
									{
										Subtitle.CustomText = "Huh? One of my rings is missing...did someone steal it?!";
									}
									else
									{
										Subtitle.CustomText = "Huh? My ring is missing...did someone take it?";
									}
									Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
									Depressed = true;
									BatheTimer = CharacterAnimation["f02_losingPhone_00"].length;
									BathePhase++;
								}
								else
								{
									if (!StudentManager.Eighties && StudentID == 2)
									{
										Cosmetic.FemaleAccessories[Cosmetic.Accessory].SetActive(value: true);
									}
									else if (StudentManager.Eighties && StudentID == 30)
									{
										Cosmetic.EnableRings();
									}
									BathePhase++;
								}
							}
							else if (BathePhase == 10)
							{
								if (BatheTimer == 0f)
								{
									BathePhase++;
								}
								else
								{
									BatheTimer = Mathf.MoveTowards(BatheTimer, 0f, Time.deltaTime);
								}
							}
							else if (BathePhase == 11)
							{
								CharacterAnimation[WetAnim].weight = 0f;
								if (Persona == PersonaType.PhoneAddict && !Phoneless)
								{
									SmartPhone.SetActive(value: true);
								}
								else
								{
									WalkAnim = OriginalOriginalWalkAnim;
									RunAnim = OriginalSprintAnim;
									IdleAnim = OriginalIdleAnim;
								}
								StudentManager.CommunalLocker.Student = null;
								StudentManager.CommunalLocker.Open = false;
								if (Phase == 1)
								{
									Phase++;
								}
								if (Club == ClubType.Sports && Clock.Period > 4 && !StudentManager.PoolClosed)
								{
									ChangeClubwear();
									DressCode = true;
								}
								CurrentDestination = Destinations[Phase];
								Pathfinding.target = Destinations[Phase];
								Pathfinding.canSearch = true;
								Pathfinding.canMove = true;
								DistanceToDestination = 100f;
								Routine = true;
								Wet = false;
								if (FleeWhenClean)
								{
									CurrentDestination = StudentManager.Exit;
									Pathfinding.target = StudentManager.Exit;
									TargetDistance = 0f;
									Routine = false;
									Fleeing = true;
								}
								else
								{
									Hurry = false;
								}
								if (!StudentManager.Eighties && Phoneless)
								{
									SprintAnim = OriginalOriginalSprintAnim;
									RunAnim = OriginalOriginalSprintAnim;
									Pathfinding.speed = 4f;
									Hurry = true;
								}
								if (CurrentAction == StudentActionType.PhotoShoot || CurrentAction == StudentActionType.GravurePose)
								{
									Hurry = false;
								}
							}
						}
						else if (BathePhase == -1)
						{
							CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
							Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 2, 5f);
							CharacterAnimation.CrossFade("f02_electrocution_00");
							Pathfinding.canSearch = false;
							Pathfinding.canMove = false;
							Distracted = true;
							BathePhase++;
						}
						else if (BathePhase == 0)
						{
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
							MoveTowardsTarget(CurrentDestination.position);
							if (CharacterAnimation["f02_electrocution_00"].time > 2f && CharacterAnimation["f02_electrocution_00"].time < 5.9500003f)
							{
								if (!LightSwitch.Panel.useGravity)
								{
									if (!Bloody)
									{
										Subtitle.Speaker = this;
										Subtitle.UpdateLabel(SplashSubtitleType, 2, 5f);
									}
									else
									{
										Subtitle.Speaker = this;
										Subtitle.UpdateLabel(SplashSubtitleType, 4, 5f);
									}
									CurrentDestination = StudentManager.StrippingPositions[GirlID];
									Pathfinding.target = StudentManager.StrippingPositions[GirlID];
									Debug.Log("Sprinting becasue bathing.");
									Pathfinding.canSearch = true;
									Pathfinding.canMove = true;
									Pathfinding.speed = 4f;
									CharacterAnimation.CrossFade(WalkAnim);
									BathePhase++;
									LightSwitch.Prompt.Label[0].text = "     Turn Off";
									LightSwitch.BathroomLight.SetActive(value: true);
									LightSwitch.GetComponent<AudioSource>().clip = LightSwitch.Flick[0];
									LightSwitch.GetComponent<AudioSource>().Play();
									InDarkness = false;
								}
								else
								{
									if (!LightSwitch.Flicker)
									{
										CharacterAnimation["f02_electrocution_00"].speed = 0.85f;
										GameObject obj22 = UnityEngine.Object.Instantiate(LightSwitch.Electricity, base.transform.position, Quaternion.identity);
										obj22.transform.parent = Bones[1].transform;
										obj22.transform.localPosition = Vector3.zero;
										Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 3, 0f);
										LightSwitch.GetComponent<AudioSource>().clip = LightSwitch.Flick[2];
										LightSwitch.Flicker = true;
										LightSwitch.GetComponent<AudioSource>().Play();
										EyeShrink = 1f;
										ElectroSteam[0].SetActive(value: true);
										ElectroSteam[1].SetActive(value: true);
										ElectroSteam[2].SetActive(value: true);
										ElectroSteam[3].SetActive(value: true);
									}
									RightDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
									LeftDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
									ElectroTimer += Time.deltaTime;
									if (ElectroTimer > 0.1f)
									{
										ElectroTimer = 0f;
										if (MyRenderer.enabled)
										{
											Spook();
										}
										else
										{
											Unspook();
										}
									}
								}
							}
							else if (CharacterAnimation["f02_electrocution_00"].time > 5.9500003f && CharacterAnimation["f02_electrocution_00"].time < CharacterAnimation["f02_electrocution_00"].length)
							{
								if (LightSwitch.Flicker)
								{
									CharacterAnimation["f02_electrocution_00"].speed = 1f;
									Prompt.Label[0].text = "     Turn Off";
									LightSwitch.BathroomLight.SetActive(value: true);
									RightDrill.localEulerAngles = new Vector3(0f, 0f, 68.30447f);
									LeftDrill.localEulerAngles = new Vector3(0f, -180f, -159.417f);
									LightSwitch.Flicker = false;
									Unspook();
									UnWet();
								}
							}
							else if (CharacterAnimation["f02_electrocution_00"].time >= CharacterAnimation["f02_electrocution_00"].length)
							{
								Police.ElectrocutedStudentName = Name;
								Police.ElectroScene = true;
								Electrocuted = true;
								BecomeRagdoll();
								DeathType = DeathType.Electrocution;
							}
						}
					}
				}
				else if (Pathfinding.canMove)
				{
					if (BathePhase == 1 || FleeWhenClean)
					{
						if (!NotActuallyWet)
						{
							if (!WitnessedCorpse)
							{
								CharacterAnimation[WetAnim].weight = 1f;
								CharacterAnimation.Play(WetAnim);
							}
							Pathfinding.speed = 4f;
							if (Persona == PersonaType.PhoneAddict && !Phoneless)
							{
								CharacterAnimation.CrossFade(OriginalSprintAnim);
							}
							else
							{
								CharacterAnimation.CrossFade(SprintAnim);
							}
						}
						else
						{
							CharacterAnimation.CrossFade(WalkAnim);
						}
					}
					else
					{
						if (Persona == PersonaType.PhoneAddict && !Phoneless)
						{
							CharacterAnimation.CrossFade(OriginalWalkAnim);
						}
						else
						{
							CharacterAnimation.CrossFade(WalkAnim);
						}
						Pathfinding.speed = WalkSpeed;
					}
				}
			}
			if (Distracting)
			{
				if (DistractionTarget == null)
				{
					Distracting = false;
				}
				else if (DistractionTarget.Dying)
				{
					CurrentDestination = Destinations[Phase];
					Pathfinding.target = Destinations[Phase];
					DistractionTarget.TargetedForDistraction = false;
					DistractionTarget.Distracted = false;
					DistractionTarget.EmptyHands();
					Pathfinding.speed = WalkSpeed;
					Distracting = false;
					Distracted = false;
					CanTalk = true;
					Routine = true;
				}
				else
				{
					if (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Cooking && ClubActivityPhase > 0 && DistractionTarget.InEvent)
					{
						GetFoodTarget();
					}
					if (DistanceToDestination < 5f || DistractionTarget.Leaving)
					{
						if (DistractionTarget.HelpOffered || DistractionTarget.InEvent || DistractionTarget.Talking || DistractionTarget.Following || DistractionTarget.TurnOffRadio || DistractionTarget.Splashed || DistractionTarget.Shoving || DistractionTarget.Spraying || DistractionTarget.FocusOnYandere || DistractionTarget.ShoeRemoval.enabled || DistractionTarget.Posing || DistractionTarget.ClubActivityPhase >= 16 || !DistractionTarget.enabled || DistractionTarget.Alarmed || DistractionTarget.Fleeing || DistractionTarget.Wet || DistractionTarget.EatingSnack || DistractionTarget.MyBento.Tampered || DistractionTarget.Meeting || DistractionTarget.Sedated || DistractionTarget.Sleepy || DistractionTarget.InvestigatingBloodPool || DistractionTarget.ReturningMisplacedWeapon || StudentManager.LockerRoomArea.bounds.Contains(DistractionTarget.transform.position) || StudentManager.MaleLockerRoomArea.bounds.Contains(DistractionTarget.transform.position) || StudentManager.WestBathroomArea.bounds.Contains(DistractionTarget.transform.position) || StudentManager.EastBathroomArea.bounds.Contains(DistractionTarget.transform.position) || StudentManager.HeadmasterArea.bounds.Contains(DistractionTarget.transform.position) || (DistractionTarget.Actions[DistractionTarget.Phase] == StudentActionType.Bully && DistractionTarget.DistanceToDestination < 1f) || DistractionTarget.Leaving || DistractionTarget.CameraReacting || DistractionTarget.SentToLocker || (MyPlate != null && MyPlate.parent == RightHand && DistractionTarget.AlreadyFed) || DistractionTarget.AwareOfCorpse)
						{
							CurrentDestination = Destinations[Phase];
							Pathfinding.target = Destinations[Phase];
							DistractionTarget.TargetedForDistraction = false;
							Distracting = false;
							Distracted = false;
							SpeechLines.Stop();
							CanTalk = true;
							Routine = true;
							Pathfinding.speed = WalkSpeed;
							if (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Cooking && ClubActivityPhase > 0)
							{
								GetFoodTarget();
							}
						}
						else if (DistanceToDestination < TargetDistance)
						{
							if (!DistractionTarget.Distracted)
							{
								if (StudentID > 1 && DistractionTarget.StudentID > 1 && Persona != PersonaType.Fragile && DistractionTarget.Persona != PersonaType.Fragile && ((Club != ClubType.Bully && DistractionTarget.Club == ClubType.Bully) || (Club == ClubType.Bully && DistractionTarget.Club != ClubType.Bully)))
								{
									BullyPhotoCollider.SetActive(value: true);
								}
								if (DistractionTarget.Investigating)
								{
									DistractionTarget.StopInvestigating();
								}
								StudentManager.UpdateStudents(DistractionTarget.StudentID);
								DistractionTarget.Pathfinding.canSearch = false;
								DistractionTarget.Pathfinding.canMove = false;
								DistractionTarget.OccultBook.SetActive(value: false);
								DistractionTarget.SmartPhone.SetActive(value: false);
								DistractionTarget.Distraction = base.transform;
								DistractionTarget.CameraReacting = false;
								DistractionTarget.Pathfinding.speed = 0f;
								DistractionTarget.Pen.SetActive(value: false);
								DistractionTarget.Drownable = false;
								DistractionTarget.Distracted = true;
								DistractionTarget.Pushable = false;
								DistractionTarget.Routine = false;
								DistractionTarget.CanTalk = false;
								DistractionTarget.ReadPhase = 0;
								DistractionTarget.SpeechLines.Stop();
								DistractionTarget.ChalkDust.Stop();
								DistractionTarget.CleanTimer = 0f;
								DistractionTarget.EmptyHands();
								DistractionTarget.Distractor = this;
								Pathfinding.speed = 0f;
								Distracted = true;
							}
							targetRotation = Quaternion.LookRotation(new Vector3(DistractionTarget.transform.position.x, base.transform.position.y, DistractionTarget.transform.position.z) - base.transform.position);
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
							if (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Cooking && ClubActivityPhase > 0)
							{
								CharacterAnimation.CrossFade(IdleAnim);
							}
							else
							{
								DistractionTarget.SpeechLines.Play();
								SpeechLines.Play();
								CharacterAnimation.CrossFade(RandomAnim);
								if (CharacterAnimation[RandomAnim].time >= CharacterAnimation[RandomAnim].length)
								{
									PickRandomAnim();
								}
							}
							DistractTimer -= Time.deltaTime;
							if (DistractTimer <= 0f)
							{
								if (DistractionTarget.SunbathePhase == 0)
								{
									DistractionTarget.CurrentDestination = DistractionTarget.Destinations[DistractionTarget.Phase];
									DistractionTarget.Pathfinding.target = DistractionTarget.Destinations[DistractionTarget.Phase];
								}
								else
								{
									DistractionTarget.CurrentDestination = StudentManager.SunbatheSpots[DistractionTarget.StudentID];
									DistractionTarget.Pathfinding.target = StudentManager.SunbatheSpots[DistractionTarget.StudentID];
									Debug.Log(DistractionTarget.Name + " was sunbathing at the time of being distracted, and should be returning to their sunbathing spot now.");
									DistractionTarget.SunbathePhase = 2;
								}
								DistractionTarget.TargetedForDistraction = false;
								DistractionTarget.Pathfinding.canSearch = true;
								DistractionTarget.Pathfinding.canMove = true;
								DistractionTarget.Pathfinding.speed = 1f;
								DistractionTarget.Octodog.SetActive(value: false);
								DistractionTarget.Distraction = null;
								DistractionTarget.Distracted = false;
								DistractionTarget.CanTalk = true;
								DistractionTarget.Routine = true;
								DistractionTarget.Hurry = false;
								DistractionTarget.EquipCleaningItems();
								DistractionTarget.EatingSnack = false;
								Private = false;
								if (DistractionTarget.Persona == PersonaType.PhoneAddict)
								{
									DistractionTarget.SmartPhone.SetActive(value: true);
								}
								DistractionTarget.Distractor = null;
								DistractionTarget.SpeechLines.Stop();
								SpeechLines.Stop();
								CurrentDestination = Destinations[Phase];
								Pathfinding.target = Destinations[Phase];
								BullyPhotoCollider.SetActive(value: false);
								Pathfinding.speed = WalkSpeed;
								Distracting = false;
								Distracted = false;
								CanTalk = true;
								Routine = true;
								Hurry = false;
								if (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Cooking && ClubActivityPhase > 0)
								{
									DistractionTarget.AlreadyFed = true;
									GetFoodTarget();
								}
								if (StudentID == StudentManager.SuitorID && StudentManager.DatingMinigame.SuitorAndRivalTalking)
								{
									Debug.Log("Fire ''CalculateLove()''");
									StudentManager.LoveManager.Courted = true;
									DialogueWheel.AdviceWindow.CalculateLove();
									StudentManager.DatingMinigame.SuitorAndRivalTalking = false;
									Yandere.PromptParent.gameObject.SetActive(value: false);
								}
							}
						}
						else if (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Cooking && ClubActivityPhase > 0)
						{
							CharacterAnimation.CrossFade(WalkAnim);
							Pathfinding.canSearch = true;
							Pathfinding.canMove = true;
						}
						else if (Pathfinding.speed == WalkSpeed)
						{
							CharacterAnimation.CrossFade(WalkAnim);
						}
						else
						{
							CharacterAnimation.CrossFade(SprintAnim);
						}
					}
					else if (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Cooking && ClubActivityPhase > 0)
					{
						CharacterAnimation.CrossFade(WalkAnim);
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						if (Phase < ScheduleBlocks.Length - 1 && Clock.HourTime >= ScheduleBlocks[Phase].time)
						{
							Routine = true;
						}
					}
					else if (Pathfinding.speed == WalkSpeed)
					{
						CharacterAnimation.CrossFade(WalkAnim);
					}
					else
					{
						CharacterAnimation.CrossFade(SprintAnim);
					}
				}
			}
			if (Hunting)
			{
				HuntTimer += Time.deltaTime;
				if (HuntTimer > 1f)
				{
					GameObject obj23 = UnityEngine.Object.Instantiate(AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
					obj23.GetComponent<AlarmDiscScript>().Originator = this;
					obj23.GetComponent<AlarmDiscScript>().Shocking = true;
					obj23.GetComponent<AlarmDiscScript>().NoScream = true;
					obj23.GetComponent<AlarmDiscScript>().Silent = true;
					obj23.GetComponent<AlarmDiscScript>().Slave = true;
					HuntTimer = 0f;
				}
				if (HuntTarget != null)
				{
					if (HuntTarget.Prompt.enabled && !HuntTarget.FightingSlave)
					{
						HuntTarget.Prompt.Hide();
						HuntTarget.Prompt.enabled = false;
					}
					Pathfinding.target = HuntTarget.transform;
					CurrentDestination = HuntTarget.transform;
					DistanceToDestination = Vector3.Distance(base.transform.position, HuntTarget.transform.position);
					if (HuntTarget.Alive && !HuntTarget.Tranquil && !HuntTarget.PinningDown)
					{
						if (DistanceToDestination > TargetDistance)
						{
							if (MurderSuicidePhase == 0)
							{
								if (CharacterAnimation["f02_brokenStandUp_00"].time >= CharacterAnimation["f02_brokenStandUp_00"].length)
								{
									MurderSuicidePhase++;
									Pathfinding.canSearch = true;
									Pathfinding.canMove = true;
									CharacterAnimation.CrossFade(WalkAnim);
									Pathfinding.speed = 1.15f;
								}
							}
							else if (MurderSuicidePhase == 1)
							{
								if (!Male)
								{
									CharacterAnimation.CrossFade(WalkAnim);
								}
								else
								{
									CharacterAnimation.CrossFade(RunAnim);
								}
								Pathfinding.canSearch = true;
								Pathfinding.canMove = true;
							}
							else if (MurderSuicidePhase > 1)
							{
								CharacterAnimation.CrossFade(WalkAnim);
								HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
							}
							if (HuntTarget.Dying || HuntTarget.Struggling || HuntTarget.Ragdoll.enabled || (HuntTarget.Hunter != null && HuntTarget.Hunter != this))
							{
								Hunting = false;
								Suicide = true;
							}
						}
						else if (HuntTarget.ClubActivityPhase >= 16 || HuntTarget.Shoving || HuntTarget.ChangingShoes || HuntTarget.Chasing || Yandere.Pursuer == HuntTarget || HuntTarget.SeekingMedicine || (StudentManager.CombatMinigame.Delinquent == HuntTarget && StudentManager.CombatMinigame.Path == 5) || !HuntTarget.enabled || HuntTarget.BreakingUpFight)
						{
							Debug.Log("The mind-broken slave has to wait for something...");
							CharacterAnimation.CrossFade(IdleAnim);
							Pathfinding.canSearch = false;
							Pathfinding.canMove = false;
						}
						else
						{
							if (!Male && !Broken.Done)
							{
								Pathfinding.canSearch = true;
								Pathfinding.canMove = true;
							}
							if (!NEStairs.bounds.Contains(base.transform.position) && !NWStairs.bounds.Contains(base.transform.position) && !SEStairs.bounds.Contains(base.transform.position) && !SWStairs.bounds.Contains(base.transform.position) && !PoolStairs.bounds.Contains(base.transform.position) && !NEStairs.bounds.Contains(HuntTarget.transform.position) && !NWStairs.bounds.Contains(HuntTarget.transform.position) && !SEStairs.bounds.Contains(HuntTarget.transform.position) && !SWStairs.bounds.Contains(HuntTarget.transform.position) && !PoolStairs.bounds.Contains(HuntTarget.transform.position))
							{
								if (Pathfinding.canMove)
								{
									Debug.Log("Slave is attacking target!");
									if (HuntTarget.InvestigatingBloodPool)
									{
										HuntTarget.ForgetAboutBloodPool();
									}
									if (HuntTarget.Strength == 9)
									{
										Debug.Log("Target is Invincible! Attack should fail!");
										AttackWillFail = true;
										if (!StudentManager.CustomMode && !StudentManager.Eighties && StudentID == 11)
										{
											Debug.Log("But, wait, it's Osana attacking Raibaru! Attack should succeed!");
											AttackWillFail = false;
										}
									}
									if (!AttackWillFail)
									{
										CharacterAnimation.CrossFade(MurderSuicideAnim);
									}
									else
									{
										if (!Male)
										{
											CharacterAnimation.CrossFade("f02_brokenAttackFailA_00");
										}
										else
										{
											CharacterAnimation.CrossFade("brokenAttackFailA_00");
										}
										CharacterAnimation[WetAnim].weight = 0f;
										Police.CorpseList[Police.Corpses] = Ragdoll;
										Police.Corpses++;
										GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
										MapMarker.gameObject.layer = 10;
										base.tag = "Blood";
										Ragdoll.MurderSuicideAnimation = true;
										Ragdoll.Disturbing = true;
										Dying = true;
										HipCollider.enabled = true;
										HipCollider.radius = 0.5f;
										MurderSuicidePhase = 9;
									}
									Pathfinding.canSearch = false;
									Pathfinding.canMove = false;
									if (!Male)
									{
										Broken.Subtitle.text = string.Empty;
										Broken.Done = true;
									}
									MyController.radius = 0f;
									if (!AttackWillFail)
									{
										AudioSource.PlayClipAtPoint(MurderSuicideSounds, base.transform.position + new Vector3(0f, 1f, 0f));
										AudioSource component4 = GetComponent<AudioSource>();
										component4.clip = MurderSuicideKiller;
										component4.Play();
									}
									if (HuntTarget.Shoving)
									{
										Yandere.CannotRecover = false;
									}
									if (StudentManager.CombatMinigame.Delinquent == HuntTarget)
									{
										StudentManager.CombatMinigame.Stop();
										StudentManager.CombatMinigame.ReleaseYandere();
									}
									if (!AttackWillFail)
									{
										HuntTarget.HipCollider.enabled = true;
										HuntTarget.HipCollider.radius = 1f;
										HuntTarget.DetectionMarker.Tex.enabled = false;
									}
									HuntTarget.CharacterAnimation[HuntTarget.WetAnim].weight = 0f;
									if (!HuntTarget.Male)
									{
										HuntTarget.CharacterAnimation[HuntTarget.ShyAnim].weight = 0f;
										if (HuntTarget.Club == ClubType.LightMusic)
										{
											HuntTarget.Instruments[HuntTarget.ClubMemberID].gameObject.SetActive(value: false);
										}
									}
									if (HuntTarget.Rival)
									{
										HuntTarget.MapMarker.gameObject.SetActive(value: false);
									}
									if (HuntTarget.ReturningMisplacedWeapon)
									{
										HuntTarget.DropMisplacedWeapon();
									}
									bool flag6 = false;
									foreach (Transform item in HuntTarget.ItemParent)
									{
										if (item.gameObject.activeSelf)
										{
											flag6 = true;
										}
									}
									if (flag6)
									{
										HuntTarget.EmptyHands();
									}
									HuntTarget.TargetedForDistraction = false;
									HuntTarget.Pathfinding.canSearch = false;
									HuntTarget.Pathfinding.canMove = false;
									HuntTarget.WitnessCamera.Show = false;
									HuntTarget.CameraReacting = false;
									HuntTarget.FocusOnStudent = false;
									HuntTarget.FocusOnYandere = false;
									HuntTarget.Investigating = false;
									HuntTarget.Distracting = false;
									HuntTarget.SentHome = false;
									HuntTarget.Splashed = false;
									HuntTarget.Alarmed = false;
									HuntTarget.Burning = false;
									HuntTarget.Fleeing = false;
									HuntTarget.Routine = false;
									HuntTarget.Shoving = false;
									HuntTarget.Tripped = false;
									HuntTarget.Wet = false;
									HuntTarget.Blind = true;
									HuntTarget.Hunter = this;
									Debug.Log(HuntTarget.Name + " should now recognize " + Name + " as their Hunter.");
									HuntTarget.Prompt.Hide();
									HuntTarget.Prompt.enabled = false;
									Distracted = true;
									Blind = true;
									if (Yandere.Pursuer == HuntTarget)
									{
										Yandere.Chased = false;
										Yandere.Pursuer = null;
									}
									if (!AttackWillFail)
									{
										if (!HuntTarget.Male)
										{
											HuntTarget.CharacterAnimation.CrossFade("f02_murderSuicide_01");
										}
										else
										{
											HuntTarget.CharacterAnimation.CrossFade("murderSuicide_01");
										}
										HuntTarget.CharacterAnimation[HuntTarget.WetAnim].weight = 0f;
										HuntTarget.Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
										HuntTarget.GetComponent<AudioSource>().clip = HuntTarget.MurderSuicideVictim;
										HuntTarget.GetComponent<AudioSource>().Play();
										Police.CorpseList[Police.Corpses] = HuntTarget.Ragdoll;
										Police.Corpses++;
										GameObjectUtils.SetLayerRecursively(HuntTarget.gameObject, 11);
										MapMarker.gameObject.layer = 10;
										HuntTarget.tag = "Blood";
										HuntTarget.Ragdoll.MurderSuicideAnimation = true;
										HuntTarget.Ragdoll.Disturbing = true;
										HuntTarget.Dying = true;
										HuntTarget.MurderSuicidePhase = 100;
									}
									else
									{
										if (!HuntTarget.Male)
										{
											HuntTarget.CharacterAnimation.CrossFade("f02_brokenAttackFailB_00");
										}
										else
										{
											HuntTarget.CharacterAnimation.CrossFade("brokenAttackFailB_00");
										}
										HuntTarget.FightingSlave = true;
										HuntTarget.Distracted = true;
										HuntTarget.Blind = false;
										MyWeapon.transform.parent = ItemParent;
										MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
										MyWeapon.transform.localPosition = Vector3.zero;
										MyWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
										StudentManager.UpdateMe(HuntTarget.StudentID);
									}
									HuntTarget.MyController.radius = 0f;
									HuntTarget.SpeechLines.Stop();
									HuntTarget.EyeShrink = 1f;
									HuntTarget.SpawnAlarmDisc();
									if (HuntTarget.Following)
									{
										Yandere.Follower = null;
										Yandere.Followers--;
										ParticleSystem.EmissionModule emission4 = Hearts.emission;
										emission4.enabled = false;
										HuntTarget.FollowCountdown.gameObject.SetActive(value: false);
										HuntTarget.Following = false;
									}
									OriginalYPosition = HuntTarget.transform.position.y;
									if (MurderSuicidePhase == 0)
									{
										MurderSuicidePhase++;
									}
								}
								else
								{
									TooCloseToWall = false;
									CheckForWallInFront(1f);
									if (TooCloseToWall)
									{
										MyController.Move(base.transform.forward * Time.deltaTime * -0.1f);
									}
									if (Dying)
									{
										Yandere.NearMindSlave = Vector3.Distance(base.transform.position, Yandere.transform.position) < 5f;
									}
									if (MurderSuicidePhase == 0 && CharacterAnimation["f02_brokenStandUp_00"].time >= CharacterAnimation["f02_brokenStandUp_00"].length)
									{
										Pathfinding.canSearch = true;
										Pathfinding.canMove = true;
									}
									if (MurderSuicidePhase > 0)
									{
										if (!AttackWillFail)
										{
											HuntTarget.targetRotation = Quaternion.LookRotation(HuntTarget.transform.position - base.transform.position);
											HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
										}
										else
										{
											HuntTarget.targetRotation = Quaternion.LookRotation(base.transform.position - HuntTarget.transform.position);
											HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 1f);
										}
										HuntTarget.transform.rotation = Quaternion.Slerp(HuntTarget.transform.rotation, HuntTarget.targetRotation, Time.deltaTime * 10f);
										base.transform.position = new Vector3(base.transform.position.x, OriginalYPosition, base.transform.position.z);
										HuntTarget.transform.position = new Vector3(HuntTarget.transform.position.x, OriginalYPosition, HuntTarget.transform.position.z);
										targetRotation = Quaternion.LookRotation(HuntTarget.transform.position - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
										Physics.SyncTransforms();
									}
									if (MurderSuicidePhase == 1)
									{
										if (CharacterAnimation[MurderSuicideAnim].time >= 2.4f)
										{
											MyWeapon.transform.parent = ItemParent;
											MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
											MyWeapon.transform.localPosition = Vector3.zero;
											MyWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
											MurderSuicidePhase++;
										}
									}
									else if (MurderSuicidePhase == 2)
									{
										if (CharacterAnimation[MurderSuicideAnim].time >= 3.3f)
										{
											GameObject obj24 = UnityEngine.Object.Instantiate(Ragdoll.BloodPoolSpawner.BloodPool, base.transform.position + base.transform.up * 0.021f + base.transform.forward, Quaternion.identity);
											obj24.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
											obj24.transform.parent = Police.BloodParent;
											MyWeapon.Victims[HuntTarget.StudentID] = true;
											MyWeapon.Blood.enabled = true;
											MyWeapon.StainWithBlood();
											if (!MyWeapon.Evidence)
											{
												Debug.Log("A mind-broken slave is running the code for staining her equipped weapon with blood and marking it as evidence.");
												MyWeapon.MurderWeapon = true;
												MyWeapon.Evidence = true;
												MyWeapon.Bloody = true;
												Police.MurderWeapons++;
											}
											UnityEngine.Object.Instantiate(BloodEffect, MyWeapon.transform.position, Quaternion.identity);
											KnifeDown = true;
											LiquidProjector.material = BloodMaterial;
											LiquidProjector.gameObject.SetActive(value: true);
											LiquidProjector.enabled = true;
											HuntTarget.LiquidProjector.material = HuntTarget.BloodMaterial;
											HuntTarget.LiquidProjector.gameObject.SetActive(value: true);
											HuntTarget.LiquidProjector.enabled = true;
											MurderSuicidePhase++;
										}
									}
									else if (MurderSuicidePhase == 3)
									{
										if (!KnifeDown)
										{
											if (MyWeapon.transform.position.y < base.transform.position.y + 1f / 3f)
											{
												UnityEngine.Object.Instantiate(BloodEffect, MyWeapon.transform.position, Quaternion.identity);
												KnifeDown = true;
												Debug.Log("Stab!");
											}
										}
										else if (MyWeapon.transform.position.y > base.transform.position.y + 1f / 3f)
										{
											KnifeDown = false;
										}
										if (CharacterAnimation[MurderSuicideAnim].time >= 16.666666f)
										{
											Debug.Log("Released knife!");
											MyWeapon.transform.parent = null;
											MurderSuicidePhase++;
										}
									}
									else if (MurderSuicidePhase == 4)
									{
										if (CharacterAnimation[MurderSuicideAnim].time >= 18.9f)
										{
											Debug.Log("Yanked out knife!");
											UnityEngine.Object.Instantiate(BloodEffect, MyWeapon.transform.position, Quaternion.identity);
											MyWeapon.transform.parent = ItemParent;
											MyWeapon.transform.localPosition = Vector3.zero;
											MyWeapon.transform.localEulerAngles = Vector3.zero;
											MurderSuicidePhase++;
										}
									}
									else if (MurderSuicidePhase == 5)
									{
										if (CharacterAnimation[MurderSuicideAnim].time >= 26.166666f)
										{
											Debug.Log("Stabbed neck!");
											UnityEngine.Object.Instantiate(BloodEffect, MyWeapon.transform.position, Quaternion.identity);
											MyWeapon.Victims[StudentID] = true;
											MurderSuicidePhase++;
										}
									}
									else if (MurderSuicidePhase == 6)
									{
										if (CharacterAnimation[MurderSuicideAnim].time >= 30.5f)
										{
											Debug.Log("BLOOD FOUNTAIN!");
											BloodFountain.Play();
											MurderSuicidePhase++;
										}
									}
									else if (MurderSuicidePhase == 7)
									{
										if (CharacterAnimation[MurderSuicideAnim].time >= 31.5f)
										{
											if (!Male)
											{
												BloodSprayCollider.SetActive(value: true);
												BloodSprayCollider.layer = 2;
											}
											MurderSuicidePhase++;
										}
									}
									else if (MurderSuicidePhase == 8)
									{
										if (CharacterAnimation[MurderSuicideAnim].time >= CharacterAnimation[MurderSuicideAnim].length)
										{
											Yandere.NearMindSlave = false;
											MyWeapon.transform.parent = null;
											MyWeapon.DoNotRelocate = true;
											MyWeapon.Drop();
											MyWeapon = null;
											StudentManager.StopHesitating();
											HuntTarget.HipCollider.radius = 0.5f;
											HuntTarget.BecomeRagdoll();
											HuntTarget.MurderedByStudent = true;
											HuntTarget.Ragdoll.Disturbing = false;
											HuntTarget.Ragdoll.MurderSuicide = true;
											HuntTarget.DeathType = DeathType.Weapon;
											if (FragileSlave)
											{
												HuntTarget.MurderedByFragile = true;
												HuntTarget.Hunted = true;
											}
											if (HuntTarget.Follower != null)
											{
												Debug.Log("This mind-broken slave just killed someone who had a follower.");
												if (HuntTarget.Follower.WitnessedMindBrokenMurder)
												{
													Debug.Log("The follower's ''Corpse'' variable is being set to: " + HuntTarget.Ragdoll.Student.Name);
													HuntTarget.Follower.Corpse = HuntTarget.Ragdoll;
												}
											}
											if (BloodSprayCollider != null)
											{
												BloodSprayCollider.SetActive(value: false);
											}
											BecomeRagdoll();
											DeathType = DeathType.Weapon;
											StudentManager.MurderTakingPlace = false;
											Ragdoll.MurderSuicide = true;
											MurderSuicide = true;
											if (!Male)
											{
												Broken.HairPhysics[0].enabled = true;
												Broken.HairPhysics[1].enabled = true;
												Broken.enabled = false;
											}
											Hunting = false;
											if (StudentID > 10 && StudentID < 21)
											{
												Debug.Log("A former rival killed herself as a mind-broken slave. StudentManager will be informed.");
												StudentManager.UpdateRivalEliminationDetails(StudentID);
											}
											Debug.Log("MurderTakingPlace *should* now be false...");
										}
									}
									else if (MurderSuicidePhase == 9)
									{
										if (!Male)
										{
											CharacterAnimation.CrossFade("f02_brokenAttackFailA_00");
										}
										else
										{
											CharacterAnimation.CrossFade("brokenAttackFailA_00");
										}
										if ((!Male && CharacterAnimation["f02_brokenAttackFailA_00"].time >= CharacterAnimation["f02_brokenAttackFailA_00"].length) || (Male && CharacterAnimation["brokenAttackFailA_00"].time >= CharacterAnimation["brokenAttackFailA_00"].length))
										{
											Debug.Log("A mind-broken slave just failed to kill her target.");
											Yandere.NearMindSlave = false;
											MurderSuicidePhase = 1;
											Hunting = false;
											Suicide = true;
											HuntTarget.MyController.radius = 0.1f;
											HuntTarget.Distracted = false;
											HuntTarget.Routine = true;
											HuntTarget.FightingSlave = false;
											StudentManager.UpdateMe(HuntTarget.StudentID);
											StudentManager.MurderTakingPlace = false;
											if (StudentID > 10 && StudentID < 21)
											{
												Debug.Log("A former rival killed herself as a mind-broken slave. StudentManager will be informed.");
												StudentManager.UpdateRivalEliminationDetails(StudentID);
											}
											Debug.Log("MurderTakingPlace *should* now be false...");
										}
										else if (((!Male && CharacterAnimation["f02_brokenAttackFailA_00"].time >= 6.5f) || (Male && CharacterAnimation["brokenAttackFailA_00"].time >= 6.5f)) && HuntTarget.FightingSlave)
										{
											HuntTarget.FightingSlave = false;
											StudentManager.UpdateMe(HuntTarget.StudentID);
										}
									}
								}
							}
						}
					}
					else
					{
						Hunting = false;
						Suicide = true;
					}
				}
				else
				{
					Hunting = false;
					Suicide = true;
				}
			}
			if (Suicide)
			{
				if (MurderSuicidePhase == 0)
				{
					if (CharacterAnimation["f02_brokenStandUp_00"].time >= CharacterAnimation["f02_brokenStandUp_00"].length)
					{
						MurderSuicidePhase++;
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						Pathfinding.speed = 0f;
						CharacterAnimation.CrossFade("f02_suicide_00");
					}
				}
				else if (MurderSuicidePhase == 1)
				{
					if (Pathfinding.speed > 0f)
					{
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						Pathfinding.speed = 0f;
						CharacterAnimation.CrossFade("f02_suicide_00");
					}
					if (CharacterAnimation["f02_suicide_00"].time >= 11f / 15f)
					{
						MyWeapon.transform.parent = ItemParent;
						MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
						MyWeapon.transform.localPosition = Vector3.zero;
						MyWeapon.transform.localEulerAngles = Vector3.zero;
						Broken.Subtitle.text = string.Empty;
						Broken.Done = true;
						MurderSuicidePhase++;
					}
				}
				else if (MurderSuicidePhase == 2)
				{
					if (CharacterAnimation["f02_suicide_00"].time >= 4.1666665f)
					{
						Debug.Log("Stabbed neck!");
						UnityEngine.Object.Instantiate(StabBloodEffect, MyWeapon.transform.position, Quaternion.identity);
						MyWeapon.Victims[StudentID] = true;
						MyWeapon.Blood.enabled = true;
						MyWeapon.StainWithBlood();
						if (!MyWeapon.Evidence)
						{
							MyWeapon.Evidence = true;
							Police.MurderWeapons++;
						}
						MurderSuicidePhase++;
					}
				}
				else if (MurderSuicidePhase == 3)
				{
					if (CharacterAnimation["f02_suicide_00"].time >= 6.1666665f)
					{
						Debug.Log("BLOOD FOUNTAIN!");
						BloodFountain.gameObject.GetComponent<AudioSource>().Play();
						BloodFountain.Play();
						MurderSuicidePhase++;
					}
				}
				else if (MurderSuicidePhase == 4)
				{
					if (CharacterAnimation["f02_suicide_00"].time >= 7f)
					{
						Ragdoll.BloodPoolSpawner.SpawnPool(base.transform);
						BloodSprayCollider.SetActive(value: true);
						MurderSuicidePhase++;
					}
				}
				else if (MurderSuicidePhase == 5 && CharacterAnimation["f02_suicide_00"].time >= CharacterAnimation["f02_suicide_00"].length)
				{
					MyWeapon.transform.parent = null;
					MyWeapon.DoNotRelocate = true;
					MyWeapon.Drop();
					MyWeapon = null;
					StudentManager.StopHesitating();
					if (BloodSprayCollider != null)
					{
						BloodSprayCollider.SetActive(value: false);
					}
					BecomeRagdoll();
					DeathType = DeathType.Weapon;
					Broken.HairPhysics[0].enabled = true;
					Broken.HairPhysics[1].enabled = true;
					Broken.enabled = false;
					StudentManager.MurderTakingPlace = false;
					if (StudentID > 10 && StudentID < 21)
					{
						Debug.Log("A former rival killed herself as a mind-broken slave. StudentManager will be informed.");
						StudentManager.UpdateRivalEliminationDetails(StudentID);
					}
					Debug.Log("MurderTakingPlace *should* now be false...");
				}
			}
			if (CameraReacting)
			{
				PhotoPatience = Mathf.MoveTowards(PhotoPatience, 0f, Time.deltaTime);
				Prompt.Circle[0].fillAmount = 1f;
				if (!Yandere.Selfie)
				{
					targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
				}
				else
				{
					targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Smartphone.transform.position.x, base.transform.position.y, Yandere.Smartphone.transform.position.z) - base.transform.position);
				}
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				if (!Yandere.ClubAccessories[7].activeInHierarchy || Club == ClubType.Delinquent)
				{
					if (CameraReactPhase == 1)
					{
						if (CharacterAnimation[CameraAnims[1]].time >= CharacterAnimation[CameraAnims[1]].length)
						{
							CharacterAnimation.CrossFade(CameraAnims[2]);
							CameraReactPhase = 2;
							CameraPoseTimer = 1f;
						}
					}
					else if (CameraReactPhase == 2)
					{
						CameraPoseTimer -= Time.deltaTime;
						if (CameraPoseTimer <= 0f)
						{
							CharacterAnimation.CrossFade(CameraAnims[3]);
							CameraReactPhase = 3;
						}
					}
					else if (CameraReactPhase == 3)
					{
						if (CameraPoseTimer == 1f)
						{
							CharacterAnimation.CrossFade(CameraAnims[2]);
							CameraReactPhase = 2;
						}
						if (CharacterAnimation[CameraAnims[3]].time >= CharacterAnimation[CameraAnims[3]].length)
						{
							if (!Phoneless && (Persona == PersonaType.PhoneAddict || Sleuthing))
							{
								SmartPhone.SetActive(value: true);
							}
							if (Cigarette.activeInHierarchy)
							{
								SmartPhone.SetActive(value: false);
							}
							CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
							Obstacle.enabled = false;
							CameraReacting = false;
							Routine = true;
							ReadPhase = 0;
							if (Actions[Phase] == StudentActionType.Clean)
							{
								Scrubber.SetActive(value: true);
								if (CleaningRole == 5)
								{
									Eraser.SetActive(value: true);
								}
							}
						}
					}
				}
				else if (Yandere.Shutter.TargetStudent != StudentID)
				{
					CameraPoseTimer = Mathf.MoveTowards(CameraPoseTimer, 0f, Time.deltaTime);
					if (CameraPoseTimer == 0f)
					{
						if (!Phoneless && (Persona == PersonaType.PhoneAddict || Sleuthing))
						{
							SmartPhone.SetActive(value: true);
						}
						CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
						Obstacle.enabled = false;
						CameraReacting = false;
						Routine = true;
						ReadPhase = 0;
						if (Actions[Phase] == StudentActionType.Clean)
						{
							Scrubber.SetActive(value: true);
							if (CleaningRole == 5)
							{
								Eraser.SetActive(value: true);
							}
						}
					}
				}
				else
				{
					CameraPoseTimer = 1f;
				}
				if (InEvent)
				{
					CameraReacting = false;
					ReadPhase = 0;
				}
			}
			if (Investigating)
			{
				if (!YandereInnocent && InvestigationPhase < 100 && CanSeeObject(Yandere.gameObject, new Vector3(Yandere.HeadPosition.x, Yandere.transform.position.y + Yandere.Zoom.Height, Yandere.HeadPosition.z)))
				{
					if (Vector3.Distance(Yandere.transform.position, Giggle.transform.position) > 2.5f)
					{
						YandereInnocent = true;
					}
					else
					{
						CharacterAnimation.CrossFade(IdleAnim);
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						InvestigationPhase = 100;
						InvestigationTimer = 0f;
					}
				}
				if (InvestigationPhase == 0)
				{
					if (InvestigationTimer < 5f)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("heardSuspiciousNoise_00");
						}
						else
						{
							CharacterAnimation.CrossFade("f02_heardSuspiciousNoise_02");
						}
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						if ((Persona == PersonaType.Heroic && HeardScream) || Persona == PersonaType.Protective)
						{
							InvestigationTimer += Time.deltaTime * 5f;
						}
						else
						{
							InvestigationTimer += Time.deltaTime;
						}
						targetRotation = Quaternion.LookRotation(new Vector3(Giggle.transform.position.x, base.transform.position.y, Giggle.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
					}
					else
					{
						if (Giggle != null)
						{
							Pathfinding.target = Giggle.transform;
							CurrentDestination = Giggle.transform;
						}
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						if ((Persona == PersonaType.Heroic && HeardScream) || Persona == PersonaType.Protective || Hurry || WalkSpeed == 4f || Pathfinding.speed == 4f)
						{
							CharacterAnimation.CrossFade(SprintAnim);
							Pathfinding.speed = 4f;
						}
						else
						{
							CharacterAnimation.CrossFade(WalkAnim);
							Pathfinding.speed = WalkSpeed;
						}
						InvestigationPhase++;
					}
				}
				else if (InvestigationPhase == 1)
				{
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					if (InvestigationDistance == 0f)
					{
						InvestigationDistance = 0.8f;
					}
					if (DistanceToDestination > InvestigationDistance)
					{
						if ((Persona == PersonaType.Heroic && HeardScream) || Persona == PersonaType.Protective || Hurry || WalkSpeed == 4f || Pathfinding.speed == 4f)
						{
							CharacterAnimation.CrossFade(SprintAnim);
						}
						else
						{
							CharacterAnimation.CrossFade(WalkAnim);
						}
					}
					else
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("lookLeftRight_00");
						}
						else
						{
							CharacterAnimation.CrossFade("f02_lookLeftRight_00");
						}
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						InvestigationPhase++;
					}
				}
				else if (InvestigationPhase == 2)
				{
					if (Persona == PersonaType.Protective)
					{
						InvestigationTimer += Time.deltaTime * 2.5f;
					}
					else
					{
						InvestigationTimer += Time.deltaTime;
					}
					if (InvestigationTimer > 10f)
					{
						StopInvestigating();
					}
				}
				else if (InvestigationPhase == 100)
				{
					targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
					InvestigationTimer += Time.deltaTime;
					if (InvestigationTimer > 2f)
					{
						StopInvestigating();
					}
				}
			}
			if (EndSearch)
			{
				if (PatrolTimer == 0f)
				{
					Debug.Log(Name + " just got her phone back.");
				}
				MoveTowardsTarget(Pathfinding.target.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Pathfinding.target.rotation, 10f * Time.deltaTime);
				PatrolTimer += Time.deltaTime * CharacterAnimation[DiscoverPhoneAnim].speed;
				if (PatrolTimer >= CharacterAnimation[DiscoverPhoneAnim].length)
				{
					Debug.Log(Name + " is now attempting to return to her previous routine.");
					ScheduleBlock scheduleBlock2 = ScheduleBlocks[2];
					scheduleBlock2.destination = "Hangout";
					scheduleBlock2.action = "Hangout";
					if (Club == ClubType.Cooking || Club == ClubType.MartialArts)
					{
						scheduleBlock2.destination = "Club";
						scheduleBlock2.action = "Club";
					}
					if (Club == ClubType.LightMusic)
					{
						scheduleBlock2.destination = "Practice";
						scheduleBlock2.action = "Practice";
					}
					ScheduleBlock obj25 = ScheduleBlocks[4];
					obj25.destination = "LunchSpot";
					obj25.action = "Eat";
					ScheduleBlock obj26 = ScheduleBlocks[7];
					obj26.destination = "Hangout";
					obj26.action = "Hangout";
					Debug.Log("ScheduleBlocks[2].destination is: " + ScheduleBlocks[2].destination);
					RestoreOriginalScheduleBlocks();
					RestoreOriginalActions();
					if (Actions[2] == StudentActionType.Graffiti && !StudentManager.Bully)
					{
						scheduleBlock2.destination = "Patrol";
						scheduleBlock2.action = "Patrol";
					}
					Debug.Log("And now, ScheduleBlocks[2].destination is: " + ScheduleBlocks[2].destination);
					GetDestinations();
					CurrentDestination = Destinations[Phase];
					Pathfinding.target = Destinations[Phase];
					CurrentAction = Actions[Phase];
					DistanceToDestination = 100f;
					SearchingForPhone = false;
					EndSearch = false;
					Phoneless = false;
					Routine = true;
					Hurry = false;
					SprintAnim = OriginalSprintAnim;
					RunAnim = OriginalSprintAnim;
					WalkAnim = OriginalWalkAnim;
					if (Persona == PersonaType.PhoneAddict && !StudentManager.Eighties)
					{
						WalkAnim = PhoneAnims[1];
					}
					WalkSpeed = 1f;
					Pathfinding.speed = WalkSpeed;
					Hurry = false;
					StudentManager.CommunalLocker.RivalPhone.ReturnToOrigin();
					if (Follower != null)
					{
						Follower.TargetDistance = 0.5f;
					}
					if (Persona == PersonaType.PhoneAddict)
					{
						SmartPhone.SetActive(value: true);
					}
				}
			}
			if (Shoving)
			{
				if (SprayTimer > 0f)
				{
					SprayTimer = Mathf.MoveTowards(SprayTimer, 0f, Time.deltaTime);
				}
				CharacterAnimation.CrossFade(ShoveAnim);
				if (CharacterAnimation[ShoveAnim].time > CharacterAnimation[ShoveAnim].length)
				{
					if ((Club != ClubType.Council && Persona != PersonaType.Violent && StudentID != 20) || RespectEarned)
					{
						Patience = 999;
					}
					if (Patience > 0)
					{
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						Distracted = false;
						Shoving = false;
						Routine = true;
						Paired = false;
						InstantNoticeTimer = 1f;
					}
					else if (Club == ClubType.Council || Shovey)
					{
						Debug.Log("Calling ''Spray()'' from this part of the code. 2");
						Shoving = false;
						Spray();
					}
					else
					{
						SpawnAlarmDisc();
						SmartPhone.SetActive(value: false);
						Distracted = true;
						Threatened = true;
						Shoving = false;
						Alarmed = true;
					}
				}
			}
			if (Spraying)
			{
				CharacterAnimation.CrossFade(SprayAnim);
				Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
				Yandere.Attacking = false;
				if ((double)CharacterAnimation[SprayAnim].time > 0.66666)
				{
					if (Yandere.Armed)
					{
						Yandere.EquippedWeapon.Drop();
					}
					Yandere.EmptyHands();
					PepperSprayEffect.Play();
					Spraying = false;
					base.enabled = false;
				}
			}
			if (SentHome)
			{
				if (SentHomePhase == 0)
				{
					if (Shy)
					{
						CharacterAnimation[ShyAnim].weight = 0f;
					}
					CharacterAnimation.CrossFade(SentHomeAnim);
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					SentHomePhase++;
					if (SmartPhone.activeInHierarchy)
					{
						CharacterAnimation[SentHomeAnim].time = 1.5f;
						SentHomePhase++;
					}
				}
				else if (SentHomePhase == 1)
				{
					CharacterAnimation.CrossFade(SentHomeAnim);
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					if (CharacterAnimation[SentHomeAnim].time > 0.66666f)
					{
						SmartPhone.SetActive(value: true);
						SentHomePhase++;
					}
				}
				else if (SentHomePhase == 2)
				{
					CharacterAnimation.CrossFade(SentHomeAnim);
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					if (CharacterAnimation[SentHomeAnim].time > CharacterAnimation[SentHomeAnim].length)
					{
						Debug.Log("Sprinting becasue sent home.");
						SprintAnim = OriginalSprintAnim;
						CharacterAnimation.CrossFade(SprintAnim);
						CurrentDestination = StudentManager.Exit;
						Pathfinding.target = StudentManager.Exit;
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						SmartPhone.SetActive(value: false);
						Pathfinding.speed = 4f;
						SentHomePhase++;
					}
				}
				else if (SentHomePhase == 3)
				{
					CharacterAnimation.CrossFade(SprintAnim);
					Pathfinding.speed = 4f;
				}
				if (base.transform.position.y < -11f)
				{
					base.transform.position = new Vector3(base.transform.position.x, -100f, base.transform.position.z);
					base.gameObject.SetActive(value: false);
				}
			}
			if (DramaticReaction)
			{
				DramaticCamera.transform.Translate(Vector3.forward * Time.deltaTime * 0.01f);
				if (DramaticPhase == 0)
				{
					DramaticCamera.rect = new Rect(0f, Mathf.Lerp(DramaticCamera.rect.y, 0.25f, Time.deltaTime * 10f), 1f, Mathf.Lerp(DramaticCamera.rect.height, 0.5f, Time.deltaTime * 10f));
					DramaticTimer += Time.deltaTime;
					if (DramaticTimer > 1f)
					{
						DramaticTimer = 0f;
						DramaticPhase++;
					}
				}
				else if (DramaticPhase == 1)
				{
					DramaticCamera.rect = new Rect(0f, Mathf.Lerp(DramaticCamera.rect.y, 0.5f, Time.deltaTime * 10f), 1f, Mathf.Lerp(DramaticCamera.rect.height, 0f, Time.deltaTime * 10f));
					DramaticTimer += Time.deltaTime;
					if (DramaticCamera.rect.height < 0.01f || DramaticTimer > 0.5f)
					{
						Debug.Log("Disabling Dramatic Camera.");
						DramaticCamera.gameObject.SetActive(value: false);
						AttackReaction();
						DramaticPhase++;
					}
				}
			}
			if (HitReacting && CharacterAnimation[SithReactAnim].time >= CharacterAnimation[SithReactAnim].length)
			{
				Persona = PersonaType.SocialButterfly;
				PersonaReaction();
				HitReacting = false;
			}
			if (Eaten)
			{
				if (Yandere.Eating)
				{
					targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				}
				if (CharacterAnimation[EatVictimAnim].time >= CharacterAnimation[EatVictimAnim].length)
				{
					BecomeRagdoll();
				}
			}
			if (Electrified)
			{
				Debug.Log(Name + " is now being electrocuted.");
				CharacterAnimation.CrossFade(ElectroAnim);
				if (CharacterAnimation[ElectroAnim].time >= CharacterAnimation[ElectroAnim].length || TooCloseToWall)
				{
					Debug.Log(Name + "'s TooCloseToWall is " + TooCloseToWall);
					Electrocuted = true;
					BecomeRagdoll();
					DeathType = DeathType.Electrocution;
					if (OsanaHairL != null)
					{
						OsanaHairL.GetComponent<DynamicBone>().enabled = true;
						OsanaHairR.GetComponent<DynamicBone>().enabled = true;
						OsanaHairL.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
						OsanaHairR.transform.localEulerAngles = new Vector3(0f, -90f, 180f);
					}
				}
				else if ((double)CharacterAnimation[ElectroAnim].time >= 9.5)
				{
					CheckForWallBehind();
				}
				else if (CharacterAnimation[ElectroAnim].time < 6f && OsanaHairL != null)
				{
					OsanaHairL.transform.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
					OsanaHairR.transform.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
				}
			}
			if (BreakingUpFight)
			{
				targetRotation = Yandere.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward * 0.5f);
				if (StudentID == 87 && CandyBar != null)
				{
					if (CharacterAnimation[BreakUpAnim].time >= 4f)
					{
						CandyBar.SetActive(value: false);
					}
					else if ((double)CharacterAnimation[BreakUpAnim].time >= 0.16666666666)
					{
						CandyBar.SetActive(value: true);
					}
				}
				if (CharacterAnimation[BreakUpAnim].time != 0f && CharacterAnimation[BreakUpAnim].time >= CharacterAnimation[BreakUpAnim].length)
				{
					ReturnToRoutine();
				}
			}
			if (Tripping)
			{
				MoveTowardsTarget(new Vector3(0f, 0f, base.transform.position.z));
				CharacterAnimation.CrossFade("trip_00");
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				if (CharacterAnimation["trip_00"].time >= 0.5f && CharacterAnimation["trip_00"].time <= 5.5f && StudentManager.Gate.Crushing)
				{
					BecomeRagdoll();
					DeathType = DeathType.Weight;
					Ragdoll.Decapitated = true;
					UnityEngine.Object.Instantiate(SquishyBloodEffect, Head.position, Quaternion.identity);
				}
				if (CharacterAnimation["trip_00"].time >= CharacterAnimation["trip_00"].length)
				{
					CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					Distracted = true;
					Tripping = false;
					Routine = true;
					Tripped = true;
					Blind = false;
					BountyCollider.SetActive(value: false);
				}
			}
			if (SeekingMedicine)
			{
				if (StudentManager.Students[90] == null)
				{
					if (SeekMedicinePhase < 5)
					{
						SeekMedicinePhase = 5;
					}
				}
				else if ((!StudentManager.Students[90].gameObject.activeInHierarchy || StudentManager.Students[90].Dying) && SeekMedicinePhase < 5)
				{
					SeekMedicinePhase = 5;
				}
				if (SeekMedicinePhase == 0)
				{
					CurrentDestination = StudentManager.Students[90].transform;
					Pathfinding.target = StudentManager.Students[90].transform;
					SeekMedicinePhase++;
				}
				else if (SeekMedicinePhase == 1)
				{
					CharacterAnimation.CrossFade(SprintAnim);
					if (DistanceToDestination < 1f)
					{
						StudentScript studentScript4 = StudentManager.Students[90];
						CharacterAnimation.CrossFade(IdleAnim);
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						Pathfinding.speed = 0f;
						if (!studentScript4.Fleeing && !studentScript4.Guarding)
						{
							if (studentScript4.Investigating)
							{
								studentScript4.StopInvestigating();
							}
							StudentManager.UpdateStudents(studentScript4.StudentID);
							studentScript4.Pathfinding.canSearch = false;
							studentScript4.Pathfinding.canMove = false;
							studentScript4.RetrieveMedicinePhase = 0;
							studentScript4.RetreivingMedicine = true;
							studentScript4.Pathfinding.speed = 0f;
							studentScript4.CameraReacting = false;
							studentScript4.TargetStudent = this;
							studentScript4.Routine = false;
							Subtitle.UpdateLabel(SubtitleType.RequestMedicine, 0, 5f);
							SeekMedicinePhase++;
						}
						else
						{
							SeekMedicinePhase = 5;
						}
					}
				}
				else if (SeekMedicinePhase == 2)
				{
					StudentScript studentScript5 = StudentManager.Students[90];
					targetRotation = Quaternion.LookRotation(new Vector3(studentScript5.transform.position.x, base.transform.position.y, studentScript5.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
					MedicineTimer += Time.deltaTime;
					if (MedicineTimer > 5f)
					{
						SeekMedicinePhase++;
						MedicineTimer = 0f;
						studentScript5.Pathfinding.canSearch = true;
						studentScript5.Pathfinding.canMove = true;
						studentScript5.RetrieveMedicinePhase++;
					}
				}
				else if (SeekMedicinePhase != 3)
				{
					if (SeekMedicinePhase == 4)
					{
						StudentScript studentScript6 = StudentManager.Students[90];
						targetRotation = Quaternion.LookRotation(new Vector3(studentScript6.transform.position.x, base.transform.position.y, studentScript6.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
					}
					else if (SeekMedicinePhase == 5)
					{
						GoSitInInfirmary();
					}
				}
			}
			if (RetreivingMedicine)
			{
				if (RetrieveMedicinePhase == 0)
				{
					CharacterAnimation.CrossFade(IdleAnim);
					targetRotation = Quaternion.LookRotation(new Vector3(TargetStudent.transform.position.x, base.transform.position.y, TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				}
				else if (RetrieveMedicinePhase == 1)
				{
					CharacterAnimation.CrossFade(WalkAnim);
					CurrentDestination = StudentManager.MedicineCabinet;
					Pathfinding.target = StudentManager.MedicineCabinet;
					Pathfinding.speed = WalkSpeed;
					RetrieveMedicinePhase++;
				}
				else if (RetrieveMedicinePhase == 2)
				{
					if (DistanceToDestination < 1f)
					{
						StudentManager.CabinetDoor.Locked = false;
						StudentManager.CabinetDoor.Open = true;
						StudentManager.CabinetDoor.Timer = 0f;
						CurrentDestination = TargetStudent.transform;
						Pathfinding.target = TargetStudent.transform;
						RetrieveMedicinePhase++;
					}
				}
				else if (RetrieveMedicinePhase == 3)
				{
					if (DistanceToDestination < 1f)
					{
						CurrentDestination = TargetStudent.transform;
						Pathfinding.target = TargetStudent.transform;
						RetrieveMedicinePhase++;
					}
				}
				else if (RetrieveMedicinePhase == 4)
				{
					if (DistanceToDestination < 1f)
					{
						CharacterAnimation.CrossFade("f02_giveItem_00");
						if (TargetStudent.Male)
						{
							TargetStudent.CharacterAnimation.CrossFade("eatItem_00");
						}
						else
						{
							TargetStudent.CharacterAnimation.CrossFade("f02_eatItem_00");
						}
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						TargetStudent.SeekMedicinePhase++;
						RetrieveMedicinePhase++;
					}
				}
				else if (RetrieveMedicinePhase == 5)
				{
					targetRotation = Quaternion.LookRotation(new Vector3(TargetStudent.transform.position.x, base.transform.position.y, TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
					MedicineTimer += Time.deltaTime;
					if (MedicineTimer > 3f)
					{
						CharacterAnimation.CrossFade(WalkAnim);
						CurrentDestination = StudentManager.MedicineCabinet;
						Pathfinding.target = StudentManager.MedicineCabinet;
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						TargetStudent.SeekMedicinePhase++;
						RetrieveMedicinePhase++;
					}
				}
				else if (RetrieveMedicinePhase == 6 && DistanceToDestination < 1f)
				{
					StudentManager.CabinetDoor.Locked = true;
					StudentManager.CabinetDoor.Open = false;
					StudentManager.CabinetDoor.Timer = 0f;
					RetreivingMedicine = false;
					RetrieveMedicinePhase = 0;
					Routine = true;
				}
			}
			if (EatingSnack)
			{
				if (SnackPhase == 0)
				{
					CharacterAnimation.CrossFade(EatChipsAnim);
					SmartPhone.SetActive(value: false);
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					SnackTimer += Time.deltaTime;
					if (SnackTimer > 10f)
					{
						UnityEngine.Object.Destroy(BagOfChips);
						bool flag7 = false;
						if (!StudentManager.Eighties && !StudentManager.MissionMode && StudentID == 11)
						{
							flag7 = true;
						}
						if (!flag7)
						{
							StudentManager.GetNearestFountain(this);
							if (Persona == PersonaType.Protective)
							{
								Pathfinding.speed = 4f;
							}
							Pathfinding.target = DrinkingFountain.DrinkPosition;
							CurrentDestination = DrinkingFountain.DrinkPosition;
							Pathfinding.canSearch = true;
							Pathfinding.canMove = true;
							SnackTimer = 0f;
						}
						SnackPhase++;
					}
				}
				else if (SnackPhase == 1)
				{
					if (Pathfinding.speed < 4f)
					{
						CharacterAnimation.CrossFade(WalkAnim);
					}
					else
					{
						CharacterAnimation.CrossFade(RunAnim);
					}
					if (Persona == PersonaType.PhoneAddict && !Phoneless)
					{
						SmartPhone.SetActive(value: true);
					}
					if (DistanceToDestination < 1f)
					{
						SmartPhone.SetActive(value: false);
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						SnackPhase++;
					}
				}
				else if (SnackPhase == 2)
				{
					CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					CharacterAnimation.CrossFade(DrinkFountainAnim);
					MoveTowardsTarget(DrinkingFountain.DrinkPosition.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, DrinkingFountain.DrinkPosition.rotation, 10f * Time.deltaTime);
					if (CharacterAnimation[DrinkFountainAnim].time >= CharacterAnimation[DrinkFountainAnim].length)
					{
						StopDrinking();
						CurrentDestination = Destinations[Phase];
						Pathfinding.target = Destinations[Phase];
					}
					else if (CharacterAnimation[DrinkFountainAnim].time > 0.5f && CharacterAnimation[DrinkFountainAnim].time < 1.5f)
					{
						if (!DrinkingFountain.Sabotaged)
						{
							DrinkingFountain.WaterStream.Play();
						}
						else
						{
							StopDrinking();
							UnityEngine.Object.Instantiate(DrinkingFountain.WaterCollider, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
							DrinkingFountain.WaterBlast.Play();
						}
					}
				}
			}
			if (Dodging)
			{
				if (CharacterAnimation[DodgeAnim].time >= CharacterAnimation[DodgeAnim].length)
				{
					Debug.Log(Name + " has finished her dodging animation.");
					Dodging = false;
					if (!TurnOffRadio)
					{
						Routine = true;
					}
					else
					{
						Debug.Log("Hey. You. Walk.");
						CharacterAnimation.CrossFade(WalkAnim);
					}
					CurrentDestination = Destinations[Phase];
					Pathfinding.target = Destinations[Phase];
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					if (GasWarned)
					{
						Yandere.Subtitle.UpdateLabel(SubtitleType.GasWarning, 2, 5f);
						GasWarned = false;
					}
				}
				else if (CharacterAnimation[DodgeAnim].time < 0.66666f)
				{
					MyController.Move(base.transform.forward * -1f * DodgeSpeed * Time.deltaTime);
					MyController.Move(Physics.gravity * 0.1f);
					if (DodgeSpeed > 0f)
					{
						DodgeSpeed = Mathf.MoveTowards(DodgeSpeed, 0f, Time.deltaTime * 3f);
					}
				}
			}
			if (Guarding && Corpse != null && Corpse.Concealed && !Alarmed)
			{
				Alarm = 200f;
				Yandere.PotentiallyMurderousTimer = 1f;
				Witnessed = StudentWitnessType.Murder;
			}
			if (!Guarding && InvestigatingBloodPool)
			{
				if (BloodPool != null)
				{
					if (Vector3.Distance(base.transform.position, new Vector3(BloodPool.position.x, base.transform.position.y, BloodPool.position.z)) < 1f)
					{
						bool flag8 = false;
						if (BloodPool == null || (WitnessedWeapon && BloodPool.parent != null) || (WitnessedBloodPool && BloodPool.parent == Yandere.RightHand) || BloodPool.transform.position != OriginalBloodPoolLocation || (WitnessedWeapon && (bool)BloodPool.GetComponent<WeaponScript>().Returner))
						{
							Debug.Log("ForgetAboutBloodPool() was called from this place in the code. 0");
							ForgetAboutBloodPool();
							flag8 = true;
						}
						if (!flag8)
						{
							CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
							CharacterAnimation[InspectBloodAnim].speed = 1f;
							CharacterAnimation.CrossFade(InspectBloodAnim);
							Pathfinding.canSearch = false;
							Pathfinding.canMove = false;
							Distracted = true;
							if (CharacterAnimation[InspectBloodAnim].time >= CharacterAnimation[InspectBloodAnim].length || Persona == PersonaType.Strict)
							{
								bool flag9 = false;
								bool flag10 = false;
								bool flag11 = false;
								if ((Club == ClubType.Cooking && CurrentAction == StudentActionType.ClubAction) || (StudentID == 15 && StudentManager.Eighties))
								{
									flag10 = true;
								}
								if (CurrentAction == StudentActionType.SitAndEatBento)
								{
									flag11 = true;
								}
								if (WitnessedWeapon)
								{
									bool flag12 = false;
									if (!Teacher && BloodPool.GetComponent<WeaponScript>().Metal && StudentManager.MetalDetectors)
									{
										flag12 = true;
									}
									if (Schoolwear == 2)
									{
										flag9 = true;
									}
									if (!WitnessedBloodyWeapon && StudentID > 1 && !flag12 && CurrentAction != StudentActionType.SitAndTakeNotes && Indoors && !flag10 && Club != ClubType.Delinquent && !flag9 && !flag11 && !BloodPool.GetComponent<WeaponScript>().Dangerous && BloodPool.GetComponent<WeaponScript>().Returner == null && BloodPool.GetComponent<WeaponScript>().Origin != null)
									{
										Debug.Log(Name + " is now picking up a weapon with intent to return it to its original location.");
										CharacterAnimation[PickUpAnim].time = 0f;
										BloodPool.GetComponent<WeaponScript>().Prompt.Hide();
										BloodPool.GetComponent<WeaponScript>().Prompt.enabled = false;
										BloodPool.GetComponent<WeaponScript>().enabled = false;
										BloodPool.GetComponent<WeaponScript>().Returner = this;
										Debug.Log("A WeaponScript has been disabled from this part of the code. 2");
										if (StudentID == 41 && !StudentManager.Eighties)
										{
											Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
										}
										else
										{
											Subtitle.UpdateLabel(SubtitleType.ReturningWeapon, 0, 5f);
										}
										ReturningMisplacedWeapon = true;
										ReportingBlood = false;
										Distracted = false;
										CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										Yandere.WeaponManager.ReturnWeaponID = BloodPool.GetComponent<WeaponScript>().GlobalID;
										Yandere.WeaponManager.ReturnStudentID = StudentID;
									}
								}
								InvestigatingBloodPool = false;
								WitnessCooldownTimer = 5f;
								if (WitnessedLimb)
								{
									SpawnAlarmDisc();
								}
								if (!ReturningMisplacedWeapon)
								{
									if (StudentManager.BloodReporter == this && WitnessedWeapon && !BloodPool.GetComponent<WeaponScript>().Dangerous)
									{
										StudentManager.BloodReporter = null;
									}
									if (StudentManager.BloodReporter == this && StudentID > 1)
									{
										if (Persona != PersonaType.Strict && Persona != PersonaType.Violent)
										{
											Debug.Log(Name + " has changed from their original Persona into a Teacher's Pet.");
											Persona = PersonaType.TeachersPet;
										}
										PersonaReaction();
									}
									else
									{
										Distracted = false;
										if (WitnessedWeapon && !WitnessedBloodyWeapon)
										{
											Debug.Log(Name + " is not going to bother reporting what they found.");
											StopInvestigating();
											CurrentDestination = Destinations[Phase];
											Pathfinding.target = Destinations[Phase];
											LastSuspiciousObject2 = LastSuspiciousObject;
											LastSuspiciousObject = BloodPool;
											Pathfinding.canSearch = true;
											Pathfinding.canMove = true;
											Pathfinding.speed = WalkSpeed;
											if (StudentID == 41 && !StudentManager.Eighties)
											{
												Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
											}
											else if (StudentID == 15 && StudentManager.Eighties)
											{
												Subtitle.CustomText = "How weird. But, frankly, I don't care.";
												Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
											}
											else if (Club == ClubType.Delinquent)
											{
												Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 2, 3f);
											}
											else if (BloodPool.GetComponent<WeaponScript>().Dangerous)
											{
												Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 0, 3f);
											}
											else if (flag9)
											{
												Subtitle.CustomText = "Weird, but I'm not doing anything about it now; I'm in a swimsuit...";
												Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
											}
											else if (flag11)
											{
												Subtitle.CustomText = "Normally I'd put it back where it belongs, but right now I'm busy eating...";
												Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
											}
											else
											{
												Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 1, 3f);
											}
											WitnessedSomething = false;
											WitnessedWeapon = false;
											Routine = true;
											BloodPool = null;
											if (StudentManager.BloodReporter == this)
											{
												StudentManager.BloodReporter = null;
											}
										}
										else
										{
											Debug.Log(Name + " just found something scary on the ground and is going to react to it now.");
											if (Persona != PersonaType.Strict && Persona != PersonaType.Violent)
											{
												Debug.Log(Name + " has changed from their original Persona into a Teacher's Pet.");
												Persona = PersonaType.TeachersPet;
											}
											PersonaReaction();
										}
									}
									CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
								}
							}
						}
					}
					else
					{
						if (Persona == PersonaType.Strict)
						{
							if (WitnessedWeapon && (bool)BloodPool.GetComponent<WeaponScript>().Returner)
							{
								Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
								CurrentDestination = Destinations[Phase];
								Pathfinding.target = Destinations[Phase];
								InvestigatingBloodPool = false;
								WitnessedBloodyWeapon = false;
								WitnessedBloodPool = false;
								WitnessedSomething = false;
								WitnessedWeapon = false;
								Distracted = false;
								Routine = true;
								BloodPool = null;
								WitnessCooldownTimer = 5f;
							}
							else if (BloodPool.parent == Yandere.RightHand || !BloodPool.gameObject.activeInHierarchy)
							{
								Debug.Log("Yandere-chan just picked up the weapon that was being investigated.");
								InvestigatingBloodPool = false;
								WitnessedBloodyWeapon = false;
								WitnessedBloodPool = false;
								WitnessedSomething = false;
								WitnessedWeapon = false;
								Distracted = false;
								Routine = true;
								if (BloodPool.GetComponent<WeaponScript>() != null && BloodPool.GetComponent<WeaponScript>().Suspicious)
								{
									WitnessCooldownTimer = 5f;
									AlarmTimer = 0f;
									Alarm = 200f;
								}
								BloodPool = null;
							}
						}
						if (BloodPool == null || (WitnessedWeapon && BloodPool.parent != null) || (WitnessedBloodPool && BloodPool.parent == Yandere.RightHand) || BloodPool.transform.position != OriginalBloodPoolLocation || (WitnessedWeapon && (bool)BloodPool.GetComponent<WeaponScript>().Returner))
						{
							Debug.Log("ForgetAboutBloodPool() was called from this place in the code. 1");
							ForgetAboutBloodPool();
						}
					}
				}
				else
				{
					Debug.Log("ForgetAboutBloodPool() was called from this place in the code. 2");
					ForgetAboutBloodPool();
				}
				if (FollowTarget != null && (Vector3.Distance(base.transform.position, FollowTarget.transform.position) < 5f || FollowTarget.transform.position.z < -50f) && FollowTarget.Attacked && FollowTarget.Alive && !FollowTarget.Tranquil && !Blind)
				{
					Debug.Log("Raibaru should be aware that Osana is being attacked.");
					ForgetAboutBloodPool();
					FocusOnYandere = true;
					AwareOfMurder = true;
					Alarm = 200f;
				}
			}
			if (ReturningMisplacedWeapon)
			{
				if (ReturningMisplacedWeaponPhase == 0)
				{
					CharacterAnimation.CrossFade(PickUpAnim);
					if ((Club == ClubType.Council || Teacher) && CharacterAnimation[PickUpAnim].time >= 0.33333f)
					{
						Handkerchief.SetActive(value: true);
					}
					if (CharacterAnimation[PickUpAnim].time >= 2f)
					{
						BloodPool.parent = RightHand;
						BloodPool.localPosition = new Vector3(0f, 0f, 0f);
						BloodPool.localEulerAngles = new Vector3(0f, 0f, 0f);
						if (Club != ClubType.Council && !Teacher)
						{
							BloodPool.GetComponent<WeaponScript>().FingerprintID = StudentID;
						}
					}
					if (CharacterAnimation[PickUpAnim].time >= CharacterAnimation[PickUpAnim].length)
					{
						CurrentDestination = BloodPool.GetComponent<WeaponScript>().Origin;
						Pathfinding.target = BloodPool.GetComponent<WeaponScript>().Origin;
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						Pathfinding.speed = WalkSpeed;
						Hurry = false;
						TargetWeaponDistance = BloodPool.GetComponent<WeaponScript>().TargetWeaponDistance;
						ReturningMisplacedWeaponPhase++;
					}
				}
				else
				{
					CharacterAnimation.CrossFade(WalkAnim);
					BloodPool.localPosition = new Vector3(0f, 0f, 0f);
					BloodPool.localEulerAngles = new Vector3(0f, 0f, 0f);
					if (DistanceToDestination < TargetWeaponDistance)
					{
						ReturnMisplacedWeapon();
					}
				}
			}
			if (SentToLocker && !CheckingNote)
			{
				CharacterAnimation.CrossFade(RunAnim);
			}
			if (Stripping)
			{
				CharacterAnimation.CrossFade(StripAnim);
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				if (CharacterAnimation[StripAnim].time >= 1.5f)
				{
					if (Schoolwear != 1)
					{
						Debug.Log(Name + "is calling ChangeSchoolwear() from here, specifically.");
						Schoolwear = 1;
						ChangeSchoolwear();
						WalkAnim = OriginalWalkAnim;
					}
					if (CharacterAnimation[StripAnim].time > CharacterAnimation[StripAnim].length)
					{
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						Stripping = false;
						Routine = true;
					}
				}
			}
			if (SenpaiWitnessingRivalDie)
			{
				Fleeing = false;
				if (DistanceToDestination < 1f)
				{
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
				}
				if (WitnessRivalDiePhase == 0)
				{
					CharacterAnimation.CrossFade("witnessPoisoning_00");
					MoveTowardsTarget(CurrentDestination.position);
					Chopsticks[0].SetActive(value: true);
					Chopsticks[1].SetActive(value: true);
					Bento.SetActive(value: true);
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, 10f * Time.deltaTime);
					if (CharacterAnimation["witnessPoisoning_00"].time >= 18.5f && Bento.activeInHierarchy)
					{
						Chopsticks[0].SetActive(value: false);
						Chopsticks[1].SetActive(value: false);
						Bento.SetActive(value: false);
						WitnessRivalDiePhase++;
					}
				}
				else if (WitnessRivalDiePhase == 1)
				{
					if (CharacterAnimation["witnessPoisoning_00"].time >= 22.5f)
					{
						Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 0, 8f);
						WitnessRivalDiePhase++;
					}
				}
				else if (WitnessRivalDiePhase == 2)
				{
					if (CharacterAnimation["witnessPoisoning_00"].time >= CharacterAnimation["witnessPoisoning_00"].length)
					{
						base.transform.position = new Vector3(Hips.position.x, base.transform.position.y, Hips.position.z);
						Physics.SyncTransforms();
						CharacterAnimation.Play("senpaiRivalCorpseReaction_00");
						TargetDistance = 1.5f;
						WitnessRivalDiePhase++;
						RivalDeathTimer = 0f;
					}
				}
				else if (WitnessRivalDiePhase == 3)
				{
					TargetDistance = 1.5f;
					if (DistanceToDestination <= TargetDistance)
					{
						CharacterAnimation.Play("senpaiRivalCorpseReaction_00");
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						if (WitnessedCorpse)
						{
							base.transform.LookAt(StudentManager.Students[StudentManager.RivalID].Head.position);
							base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y - 90f, 0f);
						}
					}
					if (RivalDeathTimer == 0f)
					{
						Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 2, 15f);
					}
					RivalDeathTimer += Time.deltaTime;
					if (CharacterAnimation["senpaiRivalCorpseReaction_00"].time >= CharacterAnimation["senpaiRivalCorpseReaction_00"].length)
					{
						if (!Phoneless)
						{
							Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 3, 15f);
							CharacterAnimation.CrossFade("kneelPhone_00");
							SmartPhone.SetActive(value: true);
						}
						WitnessRivalDiePhase++;
						RivalDeathTimer = 0f;
					}
				}
				else if (WitnessRivalDiePhase == 4)
				{
					CharacterAnimation.CrossFade("kneelPhone_00");
					RivalDeathTimer += Time.deltaTime;
					if (Phoneless)
					{
						RivalDeathTimer += 100f;
					}
					if (RivalDeathTimer > Subtitle.SenpaiRivalDeathReactionClips[3].length)
					{
						Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 4, 10f);
						CharacterAnimation.CrossFade("senpaiRivalCorpseCry_00");
						SmartPhone.SetActive(value: false);
						WitnessRivalDiePhase++;
						if (!StudentManager.Jammed && !Phoneless)
						{
							Debug.Log(Name + " just called the cops.");
							Police.Called = true;
							Police.Show = true;
						}
					}
				}
				if ((Yandere.Lifting || Yandere.Dragging) && Yandere.TargetStudent == StudentManager.Students[StudentManager.RivalID])
				{
					Alarm = 200f;
				}
				if (StudentManager.Students[StudentManager.RivalID].Ragdoll.Concealed)
				{
					Debug.Log("A corpse that was being mourned has been concealed in a trash bag. " + Name + " should now react as if they know the player is a murderer.");
					if (!Yandere.Noticed)
					{
						Alarm = 200f;
						Alarmed = false;
						MurdersWitnessed = 1;
						WitnessedMurder = true;
						Yandere.PotentiallyMurderousTimer = 1f;
						Witnessed = StudentWitnessType.Murder;
						BecomeAlarmed();
						SenpaiWitnessingRivalDie = false;
					}
				}
			}
			if (SpecialRivalDeathReaction)
			{
				if (Corpse == null)
				{
					Corpse = StudentManager.Students[CorpseID].Ragdoll;
				}
				CurrentDestination = Corpse.Student.Hips;
				Pathfinding.target = Corpse.Student.Hips;
				if (WitnessRivalDiePhase == 1)
				{
					if (DistanceToDestination <= 1f)
					{
						if (!Male)
						{
							CharacterAnimation.CrossFade("f02_friendCorpseReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade("senpaiRivalCorpseReaction_00");
						}
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						if (CorpseHead == null)
						{
							CorpseHead = Corpse.Student.Head;
						}
						base.transform.LookAt(CorpseHead.position);
						base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y - 90f, 0f);
					}
					else
					{
						CharacterAnimation.CrossFade(RunAnim);
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						Pathfinding.speed = 4f;
					}
					if (RivalDeathTimer == 0f)
					{
						Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
						if (StudentID == StudentManager.ObstacleID)
						{
							Debug.Log("Raibaru is reacting to Osana's corpse.");
							Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 2, 15f);
							StudentToMourn = StudentManager.Students[11];
						}
						else if (StudentID == StudentManager.RivalID)
						{
							Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 2, 15f);
						}
						else if (!StudentManager.Eighties && StudentID > 1 && StudentID < 4)
						{
							Subtitle.CustomText = "Sister!! Sister, answer me!! Wake up, please, wake up!! Don't do this!! Oh, no, this can't be happening!! NO!! ...no...";
							Subtitle.UpdateLabel(SubtitleType.Custom, 2, 15f);
						}
					}
					RivalDeathTimer += Time.deltaTime;
					if ((!Male && CharacterAnimation["f02_friendCorpseReaction_00"].time >= CharacterAnimation["f02_friendCorpseReaction_00"].length) || (Male && CharacterAnimation["senpaiRivalCorpseReaction_00"].time >= CharacterAnimation["senpaiRivalCorpseReaction_00"].length))
					{
						if (!Phoneless)
						{
							if (StudentID == StudentManager.ObstacleID)
							{
								Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 3, 10f);
							}
							else if (StudentID == StudentManager.RivalID)
							{
								Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 3, 10f);
							}
							else if (!StudentManager.Eighties && StudentID > 1 && StudentID < 4)
							{
								Subtitle.CustomText = "...hello...police ? ...I'm...a student at Akademi...my sister is...dead...I'm not sure what happened...please...send someone...anyone...";
								Subtitle.UpdateLabel(SubtitleType.Custom, 3, 10f);
							}
							CharacterAnimation.CrossFade("f02_kneelPhone_00");
							SmartPhone.SetActive(value: true);
						}
						else
						{
							if (StudentID == StudentManager.ObstacleID)
							{
								Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 4, 10f);
							}
							else if (StudentID == StudentManager.RivalID)
							{
								Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 4, 10f);
							}
							else if (!StudentManager.Eighties && StudentID > 1 && StudentID < 4)
							{
								Subtitle.CustomText = "(Sobbing)";
								Subtitle.UpdateLabel(SubtitleType.Custom, 4, 10f);
							}
							if (!Male)
							{
								CharacterAnimation.CrossFade("f02_friendCorpseCry_00");
							}
							else
							{
								CharacterAnimation.CrossFade("senpaiRivalCorpseCry_00");
							}
							WitnessRivalDiePhase++;
						}
						WitnessRivalDiePhase++;
						RivalDeathTimer = 0f;
					}
				}
				else if (WitnessRivalDiePhase == 2)
				{
					RivalDeathTimer += Time.deltaTime;
					if (RivalDeathTimer > Subtitle.OsanaObstacleDeathReactionClips[3].length)
					{
						if (StudentID == StudentManager.ObstacleID)
						{
							Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 4, 10f);
						}
						else if (StudentID == StudentManager.RivalID)
						{
							Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 4, 10f);
						}
						else
						{
							Subtitle.CustomText = "(Sobbing)";
							Subtitle.UpdateLabel(SubtitleType.Custom, 4, 10f);
						}
						CharacterAnimation.CrossFade("f02_friendCorpseCry_00");
						SmartPhone.SetActive(value: false);
						WitnessRivalDiePhase++;
						if (!StudentManager.Jammed)
						{
							Debug.Log(Name + " just called the cops.");
							Police.Called = true;
							Police.Show = true;
						}
					}
				}
				if ((Yandere.Lifting || Yandere.Dragging) && Yandere.TargetStudent == StudentToMourn)
				{
					Alarm = 200f;
				}
				if (StudentToMourn.Ragdoll.Concealed)
				{
					Debug.Log("A corpse that was being mourned has been concealed in a trash bag. " + Name + " should now react as if they know the player is a murderer.");
					if (!Yandere.Noticed)
					{
						Alarm = 200f;
						Alarmed = false;
						MurdersWitnessed = 1;
						WitnessedMurder = true;
						Yandere.PotentiallyMurderousTimer = 1f;
						Witnessed = StudentWitnessType.Murder;
						WitnessMurder();
						SpecialRivalDeathReaction = false;
					}
				}
			}
			if (SolvingPuzzle)
			{
				PuzzleTimer += Time.deltaTime;
				CharacterAnimation.CrossFade(PuzzleAnim);
				PuzzleCube.transform.Rotate(new Vector3(360f, 360f, 360f), Time.deltaTime * 100f);
				if (PuzzleTimer > 30f)
				{
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					PuzzleTimer = 0f;
					Routine = true;
					DropPuzzle();
				}
			}
			if (GoAway)
			{
				GoAwayTimer += Time.deltaTime;
				if (GoAwayTimer > GoAwayLimit)
				{
					Debug.Log("A student's GoAwayTimer has run out.");
					CurrentDestination = Destinations[Phase];
					Pathfinding.target = Destinations[Phase];
					GoAwayLimit = 10f;
					GoAwayTimer = 0f;
					Hurry = WasHurrying;
					Distracted = false;
					GoAway = false;
					Routine = true;
					if (!Hurry)
					{
						Pathfinding.speed = 1f;
					}
				}
			}
			if (TakingOutTrash)
			{
				if (TrashPhase == 0)
				{
					CurrentDestination = TrashDestination;
					Pathfinding.target = TrashDestination;
					EmptyHands();
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					CharacterAnimation.CrossFade(WalkAnim);
					TrashPhase++;
				}
				else if (TrashPhase == 1)
				{
					if (DistanceToDestination < 1f)
					{
						TrashDestination.parent = ItemParent;
						TrashDestination.localEulerAngles = new Vector3(90f, 0f, 0f);
						TrashDestination.localPosition = new Vector3(0f, 0.05f, -0.45f);
						CurrentDestination = Yandere.Incinerator.transform;
						Pathfinding.target = Yandere.Incinerator.transform;
						TrashPhase++;
					}
				}
				else if (TrashPhase == 2 && DistanceToDestination < 2.5f)
				{
					Yandere.Incinerator.DumpGarbageBag(TrashDestination.GetComponent<PickUpScript>());
					TakingOutTrash = false;
					Routine = true;
					GetDestinations();
					Pathfinding.target = Destinations[Phase];
					CurrentDestination = Destinations[Phase];
				}
			}
			if (FocusOnYandere)
			{
				LookAtYandere();
			}
			else if (FocusOnStudent)
			{
				if (!InEvent)
				{
					CharacterAnimation.CrossFade(LeanAnim);
				}
				targetRotation = Quaternion.LookRotation(new Vector3(WeirdStudent.position.x, base.transform.position.y, WeirdStudent.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			}
		}
		if (InstantNoticeTimer > 0f)
		{
			InstantNoticeTimer = Mathf.MoveTowards(InstantNoticeTimer, 0f, Time.deltaTime);
		}
	}

	private void LookAtYandere()
	{
		CharacterAnimation.CrossFade(LeanAnim);
		targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
	}

	private void UpdateVisibleCorpses()
	{
		VisibleCorpses.Clear();
		for (ID = 0; ID < Police.Corpses; ID++)
		{
			RagdollScript ragdollScript = Police.CorpseList[ID];
			if (ragdollScript != null && !ragdollScript.Hidden && !ragdollScript.Concealed)
			{
				Collider collider = ragdollScript.AllColliders[0];
				bool flag = false;
				if (collider.transform.position.y < base.transform.position.y + 4f)
				{
					flag = true;
				}
				if (flag && CanSeeObject(collider.gameObject, collider.transform.position, CorpseLayers, Mask))
				{
					RagdollScript component = collider.gameObject.transform.parent.parent.parent.GetComponent<RagdollScript>();
					flag = false;
					if (!component.Concealed)
					{
						flag = true;
					}
					if (component != null && !component.Concealed)
					{
						VisibleCorpses.Add(component.StudentID);
						Corpse = component;
						if (Club == ClubType.Delinquent && Corpse.Student.Club == ClubType.Bully)
						{
							Debug.Log("At this moment, a delinquent is reacting to the corpse of a bully. 1");
							ScaredAnim = EvilWitnessAnim;
							Persona = PersonaType.Evil;
						}
						if (Persona == PersonaType.TeachersPet && StudentManager.Reporter == null && !Police.Called)
						{
							StudentManager.CorpseLocation.position = Corpse.AllColliders[0].transform.position;
							StudentManager.CorpseLocation.LookAt(base.transform.position);
							StudentManager.CorpseLocation.Translate(StudentManager.CorpseLocation.forward * -1f);
							StudentManager.LowerCorpsePosition();
							StudentManager.Reporter = this;
							ReportingMurder = true;
							DetermineCorpseLocation();
							Pathfinding.canSearch = false;
							Pathfinding.canMove = false;
							Pathfinding.speed = 0f;
							Fleeing = false;
						}
					}
				}
			}
		}
	}

	private void UpdateVisibleBlood()
	{
		ID = 0;
		while (ID < StudentManager.Blood.Length && BloodPool == null)
		{
			Collider collider = StudentManager.Blood[ID];
			if (collider != null && Vector3.Distance(base.transform.position, collider.transform.position) < VisionDistance && CanSeeObject(collider.gameObject, collider.transform.position))
			{
				BloodPool = collider.transform;
				OriginalBloodPoolLocation = BloodPool.transform.position;
				WitnessedBloodPool = true;
				if (Club != ClubType.Delinquent && StudentManager.BloodReporter == null && !Police.Called && !LostTeacherTrust)
				{
					StudentManager.BloodLocation.position = BloodPool.position;
					StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, StudentManager.BloodLocation.position.y, base.transform.position.z));
					StudentManager.BloodLocation.Translate(StudentManager.BloodLocation.forward * -1f);
					StudentManager.LowerBloodPosition();
					StudentManager.BloodReporter = this;
					ReportingBlood = true;
					Debug.Log(Name + " has just appointed themself as a BloodReporter.");
					if (BloodPool.gameObject.GetComponent<BloodPoolScript>() != null)
					{
						Debug.Log("Attempting to mark the blood pool as ''under investigation''.");
						BloodPool.gameObject.GetComponent<BloodPoolScript>().UnderInvestigation = true;
					}
					DetermineBloodLocation();
				}
			}
			ID++;
		}
	}

	private void UpdateVisibleLimbs()
	{
		ID = 0;
		while (ID < StudentManager.Limbs.Length && BloodPool == null)
		{
			Collider collider = StudentManager.Limbs[ID];
			if (collider != null && CanSeeObject(collider.gameObject, collider.transform.position))
			{
				BloodPool = collider.transform;
				OriginalBloodPoolLocation = BloodPool.transform.position;
				WitnessedLimb = true;
				if (Club != ClubType.Delinquent && StudentManager.BloodReporter == null && !Police.Called && !LostTeacherTrust)
				{
					StudentManager.BloodLocation.position = BloodPool.position;
					StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, StudentManager.BloodLocation.position.y, base.transform.position.z));
					StudentManager.BloodLocation.Translate(StudentManager.BloodLocation.forward * -1f);
					StudentManager.LowerBloodPosition();
					StudentManager.BloodReporter = this;
					ReportingBlood = true;
					DetermineBloodLocation();
				}
			}
			ID++;
		}
	}

	private void UpdateVisibleWeapons()
	{
		for (ID = 0; ID < Yandere.WeaponManager.Weapons.Length; ID++)
		{
			if (Yandere.WeaponManager.Weapons[ID] != null && (Yandere.WeaponManager.Weapons[ID].Blood.enabled || (Yandere.WeaponManager.Weapons[ID].Misplaced && Yandere.WeaponManager.Weapons[ID].transform.parent == null)))
			{
				if (!(BloodPool == null))
				{
					break;
				}
				if (Yandere.WeaponManager.Weapons[ID].transform != LastSuspiciousObject && Yandere.WeaponManager.Weapons[ID].transform != LastSuspiciousObject2 && Yandere.WeaponManager.Weapons[ID].enabled)
				{
					Collider myCollider = Yandere.WeaponManager.Weapons[ID].MyCollider;
					if (myCollider != null && CanSeeObject(myCollider.gameObject, myCollider.transform.position))
					{
						if ((!StudentManager.Eighties && StudentID == 48 && Yandere.WeaponManager.Weapons[ID].WeaponID == 12) || (!StudentManager.Eighties && StudentID == 50 && Yandere.WeaponManager.Weapons[ID].WeaponID == 24))
						{
							break;
						}
						CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						Debug.Log(Name + " has seen a dropped weapon on the ground.");
						CheckForBento();
						BloodPool = myCollider.transform;
						OriginalBloodPoolLocation = BloodPool.transform.position;
						if (Yandere.WeaponManager.Weapons[ID].Blood.enabled)
						{
							WitnessedBloodyWeapon = true;
						}
						Debug.Log("WitnessedWeapon SHOULD be set to true here...");
						WitnessedWeapon = true;
						if (Club != ClubType.Delinquent && StudentManager.BloodReporter == null && !Police.Called && !LostTeacherTrust)
						{
							Debug.Log("Current WalkAnim is: " + WalkAnim + ". Saving BeforeReturnAnim.");
							StudentManager.BloodLocation.position = BloodPool.position;
							StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, StudentManager.BloodLocation.position.y, base.transform.position.z));
							StudentManager.BloodLocation.Translate(StudentManager.BloodLocation.forward * -1f);
							StudentManager.LowerBloodPosition();
							StudentManager.BloodReporter = this;
							ReportingBlood = true;
							BeforeReturnAnim = WalkAnim;
							WalkAnim = OriginalWalkAnim;
							WasHurrying = Hurry;
							DetermineBloodLocation();
						}
					}
				}
			}
		}
	}

	private void UpdateVision()
	{
		bool flag = false;
		if (Distracted)
		{
			flag = true;
			if (StudentManager.BloodReporter == this)
			{
				flag = false;
			}
		}
		if (AmnesiaTimer > 0f)
		{
			flag = true;
			AmnesiaTimer = Mathf.MoveTowards(AmnesiaTimer, 0f, Time.deltaTime);
			if (AmnesiaTimer == 0f)
			{
				Debug.Log("Student should now be returning to their previous routine.");
			}
		}
		if (!flag)
		{
			bool flag2 = true;
			if (Yandere.Pursuer == null && Yandere.Pursuer == this)
			{
				flag2 = false;
			}
			if (!WitnessedMurder && !CheckingNote && !Shoving && !Slave && !Struggling && flag2 && !Drownable && !Fighting)
			{
				if (Police.Corpses > 0)
				{
					if (!Blind && !AwareOfCorpse)
					{
						UpdateVisibleCorpses();
					}
					if (VisibleCorpses.Count > 0)
					{
						if (!WitnessedCorpse)
						{
							Debug.Log(Name + " discovered the corpse of " + Corpse.Student.Name);
							if (ReturningMisplacedWeapon)
							{
								DropMisplacedWeapon();
							}
							if (BloodPool != null)
							{
								Debug.Log("ForgetAboutBloodPool() was called from this place in the code.");
								ForgetAboutBloodPool();
							}
							Fleeing = false;
							Police.StudentFoundCorpse = true;
							SawCorpseThisFrame = true;
							if (Club == ClubType.Delinquent && Corpse.Student.Club == ClubType.Bully)
							{
								Debug.Log(Name + " witnessed the corpse of a bully, specifically.");
								FoundEnemyCorpse = true;
							}
							if (Persona == PersonaType.Sleuth)
							{
								if (Sleuthing)
								{
									Persona = PersonaType.PhoneAddict;
									SmartPhone.SetActive(value: true);
								}
								else if (StudentManager.Eighties)
								{
									Persona = PersonaType.LandlineUser;
								}
								else
								{
									Persona = PersonaType.SocialButterfly;
								}
							}
							Pathfinding.canSearch = false;
							Pathfinding.canMove = false;
							if (!Male)
							{
								CharacterAnimation["f02_smile_00"].weight = 0f;
							}
							Debug.Log("Manually setting Alarm to 200.");
							AlarmTimer = 0f;
							Alarm = 200f;
							LastKnownCorpse = Corpse.AllColliders[0].transform.position;
							WitnessedBloodyWeapon = false;
							WitnessedBloodPool = false;
							WitnessedSomething = false;
							WitnessedWeapon = false;
							WitnessedCorpse = true;
							WitnessedLimb = false;
							Yandere.NotificationManager.CustomText = Name + " found a corpse!";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							SetOutlinesYellow();
							SummonWitnessCamera();
							if (StudentManager.BloodReporter == this)
							{
								StudentManager.BloodReporter = null;
								ReportingBlood = false;
								Fleeing = false;
							}
							if (Distracting || ResumeDistracting)
							{
								Debug.Log(Name + " should be forgetting about ''Distracting'' right now.");
								if (DistractionTarget != null)
								{
									DistractionTarget.TargetedForDistraction = false;
								}
								ResumeDistracting = false;
								Distracting = false;
							}
							InvestigatingBloodPool = false;
							Investigating = false;
							EatingSnack = false;
							Threatened = false;
							SentHome = false;
							Routine = false;
							CheckingNote = false;
							SentToLocker = false;
							Meeting = false;
							MeetTimer = 0f;
							if (Persona == PersonaType.Spiteful && ((Bullied && Corpse.Student.Club == ClubType.Bully) || Corpse.Student.Bullied))
							{
								Debug.Log("At this moment, a delinquent is reacting to the corpse of a bully. 2");
								ScaredAnim = EvilWitnessAnim;
								Persona = PersonaType.Evil;
							}
							ForgetRadio();
							if (Wet)
							{
								Persona = PersonaType.Loner;
							}
							if (Corpse.Disturbing)
							{
								if (Vector3.Distance(base.transform.position, Corpse.transform.position) < 5f)
								{
									WalkBackTimer = 5f;
									WalkBack = true;
									Routine = false;
								}
								if (Corpse.BurningAnimation || Corpse.ElectrocutionAnimation)
								{
									Hesitation = 0.5f;
								}
								if (Corpse.MurderSuicideAnimation)
								{
									WitnessedMindBrokenMurder = true;
									Hesitation = 1f;
								}
								if (Corpse.ChokingAnimation)
								{
									Hesitation = 0.6f;
								}
							}
							if (Corpse.Student.Electrified)
							{
								Debug.Log(Name + " is witnessing a person being electrocuted.");
								ElectrocutionVictim = Corpse.Student.StudentID;
								Vector3 headPosition = Yandere.HeadPosition;
								if (CanSeeObject(Yandere.gameObject, headPosition))
								{
									Debug.Log("Yandere-chan is in the vicinity.");
									if (Yandere.PotentiallyMurderousTimer > 0f)
									{
										Debug.Log("Yandere-chan just threw a car battery, which means she just deliberately killed someone!");
										WitnessMurder();
									}
								}
							}
							if (Corpse.Student.Burning)
							{
								Debug.Log(Name + " is witnessing a person burn to death.");
								Vector3 headPosition2 = Yandere.HeadPosition;
								if (CanSeeObject(Yandere.gameObject, headPosition2))
								{
									Debug.Log("Yandere-chan is in the vicinity.");
									if (Yandere.PotentiallyMurderousTimer > 0f)
									{
										Debug.Log("Yandere-chan just ran into the victim while holding a flame, which means she just deliberately killed someone!");
										WitnessMurder();
									}
								}
							}
							StudentManager.UpdateMe(StudentID);
							if (!Teacher)
							{
								SpawnAlarmDisc();
							}
							else
							{
								AlarmTimer = 3f;
							}
							ParticleSystem.EmissionModule emission = Hearts.emission;
							if (Talking)
							{
								DialogueWheel.End();
								emission.enabled = false;
								Pathfinding.canSearch = true;
								Pathfinding.canMove = true;
								Obstacle.enabled = false;
								Talk.enabled = false;
								Talking = false;
								Waiting = false;
								StudentManager.EnablePrompts();
							}
							if (Following)
							{
								emission.enabled = false;
								FollowCountdown.gameObject.SetActive(value: false);
								Yandere.Follower = null;
								Yandere.Followers--;
								Following = false;
							}
						}
						if (Corpse.Dragged || Corpse.Dumped)
						{
							if (Teacher)
							{
								Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, UnityEngine.Random.Range(1, 3), 3f);
							}
							if (!Yandere.Egg && !Yandere.Invisible)
							{
								WitnessMurder();
							}
						}
					}
				}
				if (VisibleCorpses.Count == 0 && !WitnessedCorpse)
				{
					if (WitnessCooldownTimer > 0f)
					{
						WitnessCooldownTimer = Mathf.MoveTowards(WitnessCooldownTimer, 0f, Time.deltaTime);
					}
					else if ((StudentID == StudentManager.CurrentID || (Persona == PersonaType.Strict && Fleeing)) && !Wet && !Guarding && !IgnoreBlood && !InvestigatingPossibleDeath && !Spraying && !Emetic && !Threatened && !Sedated && !Headache && !SentHome && !Slave && !Talking && !Confessing && !SentToLocker && !Meeting && !IgnoringThingsOnGround && !RetreivingMedicine && !StudentManager.KokonaTutorial)
					{
						if (BloodPool == null && StudentManager.Police.LimbParent.childCount > 0)
						{
							UpdateVisibleLimbs();
						}
						if (BloodPool == null && (Police.BloodyWeapons > 0 || Yandere.WeaponManager.MisplacedWeapons > 0) && !InvestigatingPossibleLimb && !TakingOutTrash && !Alarmed && !InEvent && !Distracted && !InvestigatingPossibleBlood && !ChangingShoes && !EatingSnack && Persona != PersonaType.Violent && (MyPlate == null || (MyPlate != null && MyPlate.parent != RightHand)))
						{
							UpdateVisibleWeapons();
						}
						if (BloodPool == null)
						{
							if (StudentManager.Police.BloodParent.childCount > 0 && !InvestigatingPossibleLimb)
							{
								UpdateVisibleBlood();
							}
						}
						else if (!WitnessedSomething)
						{
							Debug.Log(Name + " saw something suspicious on the ground.");
							Pathfinding.canSearch = false;
							Pathfinding.canMove = false;
							if (!Male)
							{
								CharacterAnimation["f02_smile_00"].weight = 0f;
							}
							Debug.Log("Manually setting Alarm to 200.");
							AlarmTimer = 0f;
							Alarm = 200f;
							LastKnownBlood = BloodPool.transform.position;
							NotAlarmedByYandereChan = true;
							WitnessedSomething = true;
							Investigating = false;
							EatingSnack = false;
							Threatened = false;
							SentHome = false;
							Routine = false;
							ForgetRadio();
							StudentManager.UpdateMe(StudentID);
							if (Teacher)
							{
								AlarmTimer = 3f;
							}
							ParticleSystem.EmissionModule emission2 = Hearts.emission;
							if (Talking)
							{
								DialogueWheel.End();
								emission2.enabled = false;
								Pathfinding.canSearch = true;
								Pathfinding.canMove = true;
								Obstacle.enabled = false;
								Talk.enabled = false;
								Talking = false;
								Waiting = false;
								StudentManager.EnablePrompts();
							}
							if (Following)
							{
								emission2.enabled = false;
								FollowCountdown.gameObject.SetActive(value: false);
								Yandere.Follower = null;
								Yandere.Followers--;
								Following = false;
							}
						}
					}
				}
				PreviousAlarm = Alarm;
				if (DistanceToPlayer < VisionDistance + VisionBonus - ChameleonBonus)
				{
					if (!Talking && !Spraying && !SentHome && !Slave && !Attacked)
					{
						if (!Yandere.Noticed && !Yandere.Invisible)
						{
							bool flag3 = false;
							if (Guarding || Fleeing || (InvestigatingBloodPool && WitnessedBloodPool))
							{
								flag3 = true;
							}
							if ((Yandere.Armed && Yandere.EquippedWeapon.Suspicious) || (Yandere.Armed && Yandere.EquippedWeapon.Bloody) || (!IgnoringPettyActions && StudentID > 1 && Yandere.PickUp != null && Yandere.PickUp.Suspicious) || (!IgnoringPettyActions && StudentID > 1 && Yandere.PickUp != null && Yandere.PickUp.CleaningProduct && Clock.Period != 5) || (Guarding && Yandere.Mopping && Yandere.Mop.Bloodiness > 0f) || (Yandere.Bloodiness + (float)Yandere.GloveBlood > 0f && !Yandere.Paint) || Yandere.Sanity < 33.333f || Yandere.Pickpocketing || Yandere.Lockpicking || Yandere.Attacking || Yandere.Cauterizing || Yandere.Struggling || Yandere.WrappingCorpse || (Yandere.Dragging && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Dragging && Yandere.CurrentRagdoll.Concealed && Clock.Period != 5) || (!IgnoringPettyActions && Yandere.Lewd) || (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Carrying && Yandere.CurrentRagdoll.Concealed && Clock.Period != 5) || Yandere.Yakuza || Yandere.Medusa || Yandere.Poisoning || Yandere.WeaponTimer > 0f || Yandere.WearingRaincoat || Yandere.MurderousActionTimer > 0f || (!IgnoringPettyActions && Yandere.Schoolwear == 2 && Yandere.transform.position.z < 30f) || (!IgnoringPettyActions && Yandere.PickUp != null && Yandere.PickUp.BodyPart != null && !Yandere.PickUp.Garbage) || (!IgnoringPettyActions && Yandere.SuspiciousActionTimer > 0f) || (!IgnoringPettyActions && Yandere.Laughing && Yandere.LaughIntensity > 15f) || (!IgnoringPettyActions && Yandere.Stance.Current == StanceType.Crouching) || (!IgnoringPettyActions && Yandere.Stance.Current == StanceType.Crawling) || (!IgnoringPettyActions && Yandere.Trespassing) || (Private && Yandere.Eavesdropping && !Yandere.Talking) || (Teacher && !WitnessedCorpse && Yandere.Trespassing) || (Teacher && !IgnoringPettyActions && Yandere.Rummaging) || (!IgnoringPettyActions && Yandere.TheftTimer > 0f) || (StudentID == 1 && Yandere.NearSenpai && !Yandere.Talking) || (!IgnoringPettyActions && !StudentManager.CombatMinigame.Practice && Yandere.DelinquentFighting && StudentID != 10 && StudentManager.CombatMinigame.Path < 4 && !StudentManager.CombatMinigame.Practice && !Yandere.SeenByAuthority) || (flag3 && Yandere.PickUp != null && Yandere.PickUp.Mop != null && Yandere.PickUp.Mop.Bloodiness > 50f) || (!IgnoringPettyActions && flag3 && Yandere.PickUp != null && Yandere.PickUp.BodyPart != null && !Yandere.PickUp.Garbage) || (Yandere.PickUp != null && Yandere.PickUp.Clothing && Yandere.PickUp.Evidence && !Yandere.PickUp.BloodMistakenForPaint) || (!IgnoringPettyActions && AnnoyedByRadio > 1 && Yandere.PotentiallyAnnoyingTimer > 0f) || (!IgnoringPettyActions && AnnoyedByGiggles > 4 && Yandere.AnnoyingGiggleTimer > 0f) || (!IgnoringPettyActions && Yandere.PreparingThrow && Yandere.Obvious))
							{
								bool flag4 = false;
								if (Yandere.transform.position.y < base.transform.position.y + 4f)
								{
									flag4 = true;
								}
								Vector3 headPosition3 = Yandere.HeadPosition;
								if ((flag4 && CanSeeObject(Yandere.gameObject, headPosition3)) || AwareOfMurder)
								{
									YandereVisible = true;
									if (Yandere.Attacking || Yandere.Cauterizing || Yandere.Struggling || Yandere.WrappingCorpse || (WitnessedCorpse && Yandere.NearBodies > 0 && Yandere.Bloodiness + (float)Yandere.GloveBlood > 0f && !Yandere.Paint) || (WitnessedCorpse && Yandere.NearBodies > 0 && Yandere.Armed) || (WitnessedCorpse && Yandere.NearBodies > 0 && Yandere.Sanity < 66.66666f) || (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Dragging && !Yandere.CurrentRagdoll.Concealed) || Yandere.MurderousActionTimer > 0f || (Guarding && Yandere.Bloodiness + (float)Yandere.GloveBlood > 0f && !Yandere.Paint) || (Guarding && Yandere.Armed && Yandere.EquippedWeapon.Dangerous) || (Guarding && Yandere.Armed && Yandere.EquippedWeapon.Suspicious) || (Guarding && Yandere.Sanity < 66.66666f) || (Guarding && Yandere.WearingRaincoat) || (!IgnoringPettyActions && !StudentManager.CombatMinigame.Practice && Club == ClubType.Council && Yandere.DelinquentFighting && StudentManager.CombatMinigame.Path < 4 && !Yandere.SeenByAuthority) || (!StudentManager.CombatMinigame.Practice && Teacher && Yandere.DelinquentFighting && StudentManager.CombatMinigame.Path < 4 && !Yandere.SeenByAuthority) || (flag3 && Yandere.PickUp != null && Yandere.PickUp.Mop != null && Yandere.PickUp.Mop.Bloodiness > 0f) || (flag3 && Yandere.PickUp != null && Yandere.PickUp.BodyPart != null && !Yandere.PickUp.Garbage) || (Yandere.PickUp != null && Teacher && Yandere.PickUp.Clothing && Yandere.PickUp.Evidence) || (StudentManager.Atmosphere < 0.33333f && Yandere.Bloodiness + (float)Yandere.GloveBlood > 0f && Yandere.Armed) || (Fleeing && Yandere.Yakuza))
									{
										Debug.Log(Name + " is aware that Yandere-chan is doing something murderous.");
										if (Yandere.Hungry || !Yandere.Egg)
										{
											Debug.Log(Name + " has just witnessed a murder!");
											if (Yandere.PickUp != null)
											{
												if (flag3)
												{
													if (Yandere.PickUp.Mop != null)
													{
														if (Yandere.PickUp.Mop.Bloodiness > 0f)
														{
															Debug.Log("This character witnessed Yandere-chan trying to cover up a crime.");
															WitnessedCoverUp = true;
														}
													}
													else if (Yandere.PickUp.BodyPart != null && !Yandere.PickUp.Garbage)
													{
														Debug.Log("This character witnessed Yandere-chan trying to cover up a crime.");
														WitnessedCoverUp = true;
													}
												}
												if (Teacher && Yandere.PickUp.Clothing && Yandere.PickUp.Evidence)
												{
													Debug.Log("This character witnessed Yandere-chan trying to cover up a crime.");
													WitnessedCoverUp = true;
												}
											}
											if (Persona == PersonaType.PhoneAddict && !Phoneless)
											{
												Debug.Log(Name + ", a Phone Addict, is deciding what to do.");
												Countdown.gameObject.SetActive(value: false);
												Countdown.Sprite.fillAmount = 1f;
												WitnessedMurder = false;
												Fleeing = false;
												if (CrimeReported)
												{
													Debug.Log(Name + "'s ''CrimeReported'' was ''true'', but we're seeing it to ''false''.");
													CrimeReported = false;
												}
											}
											if (!Yandere.DelinquentFighting)
											{
												NoBreakUp = true;
											}
											else if (Teacher || Club == ClubType.Council)
											{
												Yandere.SeenByAuthority = true;
											}
											WitnessMurder();
										}
									}
									else if (!Fleeing && (!Alarmed || CanStillNotice))
									{
										if (Yandere.Rummaging || Yandere.TheftTimer > 0f)
										{
											Alarm = 200f;
										}
										if (Yandere.WeaponTimer > 0f)
										{
											Alarm = 200f;
										}
										if (IgnoreTimer == 0f || CanStillNotice)
										{
											if (Teacher)
											{
												StudentManager.TutorialWindow.ShowTeacherMessage = true;
											}
											int num = 1;
											if (Yandere.Armed && Yandere.EquippedWeapon.Suspicious && (Yandere.EquippedWeapon.Type == WeaponType.Bat || Yandere.EquippedWeapon.Type == WeaponType.Katana || Yandere.EquippedWeapon.Type == WeaponType.Saw || Yandere.EquippedWeapon.Type == WeaponType.Weight))
											{
												num = 5;
											}
											if (Yandere.Carrying)
											{
												num = 5;
											}
											if (!Yandere.Chased && Yandere.Chasers == 0 && !Yandere.StruggleIminent)
											{
												if (InstantNoticeTimer > 0f)
												{
													Alarm = 100f;
												}
												Alarm += Time.deltaTime * (100f / DistanceToPlayer) * Paranoia * Perception * (float)num;
												if (Yandere.SneakingShot)
												{
													Alarm += Time.deltaTime * (100f / DistanceToPlayer) * Paranoia * Perception * (float)num * 2f;
												}
												if (Yandere.SuspiciousActionTimer > 0f || Yandere.PotentiallyAnnoyingTimer > 0f || Yandere.AnnoyingGiggleTimer > 0f)
												{
													Debug.Log(Name + " witnessed something suspicious or annoying.");
													Alarm += Time.deltaTime * (100f / DistanceToPlayer) * Paranoia * Perception * (float)num * 9f;
													if (Yandere.CreatingBucketTrap)
													{
														Debug.Log(Name + " just witnessed the player creating a bucket trap.");
														WillRemoveBucket = true;
													}
													if (Yandere.CreatingTripwireTrap)
													{
														WillRemoveTripwire = true;
													}
												}
											}
											else
											{
												Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
											}
											if (StudentID == 1 && Yandere.TimeSkipping)
											{
												Clock.EndTimeSkip();
											}
										}
									}
								}
								else
								{
									Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
								}
							}
							else
							{
								Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
							}
						}
						else
						{
							Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
						}
					}
					else
					{
						Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
					}
				}
				else
				{
					Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
				}
				if (PreviousAlarm > Alarm && Alarm < 100f)
				{
					YandereVisible = false;
				}
				if (Teacher && !Yandere.Medusa && Yandere.Egg)
				{
					Alarm = 0f;
				}
				if (Alarm > 100f)
				{
					if (Yandere.Yakuza && YandereVisible)
					{
						SpottedYakuza = true;
						WitnessMurder();
					}
					else
					{
						BecomeAlarmed();
					}
				}
			}
			else
			{
				Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
			}
		}
		else
		{
			if (!(Distraction != null))
			{
				return;
			}
			targetRotation = Quaternion.LookRotation(new Vector3(Distraction.position.x, base.transform.position.y, Distraction.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			if (!(Distractor != null))
			{
				return;
			}
			if (Distractor.Club == ClubType.Cooking && Distractor.ClubActivityPhase > 0 && Distractor.Actions[Distractor.Phase] == StudentActionType.ClubAction)
			{
				CharacterAnimation.CrossFade(PlateEatAnim);
				if ((double)CharacterAnimation[PlateEatAnim].time > 6.83333)
				{
					Fingerfood[Distractor.StudentID - 20].SetActive(value: false);
				}
				else if ((double)CharacterAnimation[PlateEatAnim].time > 2.66666)
				{
					Fingerfood[Distractor.StudentID - 20].SetActive(value: true);
				}
			}
			else
			{
				CharacterAnimation.CrossFade(RandomAnim);
				if (CharacterAnimation[RandomAnim].time >= CharacterAnimation[RandomAnim].length)
				{
					PickRandomAnim();
				}
			}
		}
	}

	public void BecomeAlarmed()
	{
		Debug.Log(Name + " just fired the BecomeAlarmed() function.");
		if (Teacher && Persona == PersonaType.Violent)
		{
			Persona = PersonaType.Strict;
		}
		if (Yandere.Medusa && YandereVisible)
		{
			TurnToStone();
			return;
		}
		if (Investigating && !HeardScream)
		{
			Debug.Log(Name + " was investigating prior to being alarmed, so they are now ending their investigation.");
			StopInvestigating();
		}
		if (!Alarmed || DiscCheck)
		{
			bool flag = false;
			if (CurrentAction == StudentActionType.Sunbathe && SunbathePhase > 2)
			{
				SunbathePhase = 2;
				flag = true;
			}
			if (ReturningMisplacedWeapon)
			{
				DropMisplacedWeapon();
				ReturnToRoutineAfter = true;
			}
			if (DistractionTarget != null)
			{
				DistractionTarget.TargetedForDistraction = false;
			}
			if (SolvingPuzzle)
			{
				DropPuzzle();
			}
			Debug.Log(Name + " is now having their DiscCheck set to false...");
			CharacterAnimation.CrossFade(LeanAnim);
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
			CameraReacting = false;
			CanStillNotice = false;
			Distracting = false;
			Distracted = false;
			DiscCheck = false;
			Reacted = false;
			Routine = false;
			Alarmed = true;
			if (HeardScream)
			{
				Debug.Log("But HeardScream was true, so we're setting DiscCheck to true...");
				DiscCheck = true;
			}
			PuzzleTimer = 0f;
			ReadPhase = 0;
			if (!Male)
			{
				HorudaCollider.gameObject.SetActive(value: false);
			}
			BountyCollider.SetActive(value: false);
			if (YandereVisible && Yandere.Mask == null)
			{
				Witness = true;
			}
			EmptyHands();
			if ((Persona == PersonaType.PhoneAddict && !Phoneless && !flag) || Persona == PersonaType.Sleuth || StudentID == 20)
			{
				SmartPhone.SetActive(value: true);
				Scrubber.SetActive(value: false);
				Eraser.SetActive(value: false);
			}
			if (Club == ClubType.Cooking && Actions[Phase] == StudentActionType.ClubAction && ClubActivityPhase == 1 && !WitnessedCorpse)
			{
				Debug.Log("The game believes that " + Name + " did not witness a corpse; ''ResumeDistracting'' is being set to ''true''.");
				ResumeDistracting = true;
				MyPlate.gameObject.SetActive(value: true);
			}
			if (TakingOutTrash && !WitnessedCorpse)
			{
				ResumeTakingOutTrash = true;
			}
			SpeechLines.Stop();
			StopPairing();
			if (Witnessed != StudentWitnessType.Weapon && Witnessed != StudentWitnessType.Eavesdropping)
			{
				PreviouslyWitnessed = Witnessed;
			}
			if (DistanceToDestination < 5f && (Actions[Phase] == StudentActionType.Graffiti || Actions[Phase] == StudentActionType.Bully))
			{
				StudentManager.NoBully[BullyID] = true;
				KilledMood = true;
			}
			if (WitnessedCorpse && !WitnessedMurder)
			{
				Witnessed = StudentWitnessType.Corpse;
				EyeShrink = 0.9f;
			}
			else if (WitnessedLimb)
			{
				Witnessed = StudentWitnessType.SeveredLimb;
			}
			else if (WitnessedBloodyWeapon)
			{
				Witnessed = StudentWitnessType.BloodyWeapon;
			}
			else if (WitnessedBloodPool)
			{
				Witnessed = StudentWitnessType.BloodPool;
			}
			else if (WitnessedWeapon)
			{
				Witnessed = StudentWitnessType.DroppedWeapon;
			}
			else if (StudentManager.TutorialActive)
			{
				Witnessed = StudentWitnessType.Tutorial;
			}
			if (SawCorpseThisFrame)
			{
				YandereVisible = false;
			}
			if (TemporarilyBlind)
			{
				YandereVisible = false;
			}
			if ((SenpaiWitnessingRivalDie && StudentManager.Students[StudentManager.RivalID].Ragdoll.Concealed) || (SpecialRivalDeathReaction && StudentToMourn.Ragdoll.Concealed))
			{
				NotAlarmedByYandereChan = false;
				YandereVisible = true;
			}
			if (YandereVisible && !NotAlarmedByYandereChan)
			{
				if (Yandere.Mask == null)
				{
					TimesAlarmed++;
				}
				if ((!Injured && Persona == PersonaType.Violent && Yandere.Armed && !WitnessedCorpse && !RespectEarned) || (Persona == PersonaType.Violent && Yandere.DelinquentFighting))
				{
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentWeaponReaction, 0, 3f);
					ThreatDistance = DistanceToPlayer;
					CheerTimer = UnityEngine.Random.Range(1f, 2f);
					SmartPhone.SetActive(value: false);
					Threatened = true;
					ThreatPhase = 1;
					ForgetGiggle();
				}
				Debug.Log(Name + " saw Yandere-chan doing something bad.");
				if (Yandere.CreatingBucketTrap)
				{
					Debug.Log(Name + " just witnessed the player creating a bucket trap.");
					WillRemoveBucket = true;
				}
				if (Yandere.CreatingTripwireTrap)
				{
					Debug.Log(Name + " just witnessed the player creating a tripwire trap.");
					WillRemoveTripwire = true;
				}
				FocusOnYandere = true;
				if (StudentID > 1 && Yandere.Mask == null)
				{
					Debug.Log("Alerts was incremented.");
					Yandere.Alerts++;
				}
				else
				{
					Debug.Log("Alerts was not incremented.");
				}
				if (Yandere.Attacking || Yandere.Struggling || (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.PickUp != null && (bool)Yandere.PickUp.BodyPart && !Yandere.PickUp.Garbage))
				{
					if (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed)
					{
						Corpse = Yandere.CurrentRagdoll;
					}
					if (!Yandere.Egg)
					{
						WitnessMurder();
					}
				}
				else if (Witnessed != StudentWitnessType.Corpse)
				{
					DetermineWhatWasWitnessed();
				}
				if (Teacher && WitnessedCorpse)
				{
					Concern = 1;
				}
				if (StudentID == 1 && Yandere.Mask == null && !Yandere.Egg && Persona != PersonaType.Evil)
				{
					if (Concern == 5)
					{
						Debug.Log("Senpai noticed stalking or lewdness.");
						SenpaiNoticed();
						if (Witnessed == StudentWitnessType.Stalking || Witnessed == StudentWitnessType.Lewd)
						{
							CharacterAnimation.CrossFade(IdleAnim);
							CharacterAnimation[AngryFaceAnim].weight = 1f;
						}
						else
						{
							Debug.Log("Senpai entered his scared animation.");
							CharacterAnimation.CrossFade(ScaredAnim);
							if (Male)
							{
								CharacterAnimation["scaredFace_00"].weight = 1f;
							}
						}
						CameraEffects.MurderWitnessed();
					}
					else
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("suspicious_00");
						}
						else
						{
							CharacterAnimation.CrossFade(LeanAnim);
						}
						CameraEffects.Alarm();
					}
				}
				else if (!Teacher)
				{
					CameraEffects.Alarm();
				}
				else
				{
					Debug.Log(Name + ", using the Teacher Persona, has just witnessed Yandere-chan doing something bad.");
					if (!Fleeing)
					{
						if (AnnoyedByGiggles > 4 && Yandere.AnnoyingGiggleTimer > 0f)
						{
							Debug.Log("It seems to be a giggle, specifically, that annoyed the teacher.");
							Concern = 5;
						}
						if (Concern < 5)
						{
							CameraEffects.Alarm();
						}
						else if (!Yandere.Struggling && !Yandere.StruggleIminent && !StudentManager.PinningDown)
						{
							SenpaiNoticed();
							CameraEffects.MurderWitnessed();
						}
					}
					else
					{
						PersonaReaction();
						AlarmTimer = 0f;
						if (Concern < 5)
						{
							CameraEffects.Alarm();
						}
						else
						{
							CameraEffects.MurderWitnessed();
						}
					}
				}
				if (!Teacher)
				{
					if (Club != ClubType.Delinquent && Witnessed == PreviouslyWitnessed)
					{
						RepeatReaction = true;
					}
					if (Yandere.Mask == null)
					{
						RepDeduction = 0f;
						CalculateReputationPenalty();
						if (RepDeduction >= 0f)
						{
							RepLoss -= RepDeduction;
						}
						Reputation.PendingRep -= RepLoss * Paranoia;
						PendingRep -= RepLoss * Paranoia;
					}
				}
				if (ToiletEvent != null && ToiletEvent.EventDay == DayOfWeek.Monday)
				{
					ToiletEvent.EndEvent();
				}
			}
			else if (!WitnessedCorpse)
			{
				if (Yandere.Caught)
				{
					if (Yandere.Mask == null)
					{
						if (Yandere.Pickpocketing)
						{
							Witnessed = StudentWitnessType.Pickpocketing;
							RepLoss += 10f;
						}
						else
						{
							Witnessed = StudentWitnessType.Theft;
						}
						RepDeduction = 0f;
						Debug.Log("Calculating reputation penalty from here. 1");
						CalculateReputationPenalty();
						if (RepDeduction >= 0f)
						{
							RepLoss -= RepDeduction;
						}
						Reputation.PendingRep -= RepLoss * Paranoia;
						PendingRep -= RepLoss * Paranoia;
					}
				}
				else if (WitnessedLimb)
				{
					Witnessed = StudentWitnessType.SeveredLimb;
				}
				else if (WitnessedBloodyWeapon)
				{
					Witnessed = StudentWitnessType.BloodyWeapon;
				}
				else if (WitnessedBloodPool)
				{
					Witnessed = StudentWitnessType.BloodPool;
				}
				else if (WitnessedWeapon)
				{
					Witnessed = StudentWitnessType.DroppedWeapon;
				}
				else
				{
					Debug.Log(Name + " was alarmed by something, but didn't see what it was. DiscCheck is being set to true.");
					if (WitnessedSlave)
					{
						Debug.Log("Specifically, " + Name + " saw a mind-broken slave walking around...");
					}
					Witnessed = StudentWitnessType.None;
					DiscCheck = true;
					Witness = false;
					AlarmTimer = 0f;
				}
			}
			else
			{
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
			}
		}
		NotAlarmedByYandereChan = false;
		SawCorpseThisFrame = false;
	}

	private void UpdateDetectionMarker()
	{
		if (Alarm < 0f)
		{
			Alarm = 0f;
			if (Club == ClubType.Council && !Yandere.Noticed)
			{
				CanStillNotice = true;
			}
		}
		if (DetectionMarker != null)
		{
			if (Alarm > 0f)
			{
				if (!DetectionMarker.Tex.enabled)
				{
					DetectionMarker.Tex.enabled = true;
				}
				DetectionMarker.Tex.transform.localScale = new Vector3(DetectionMarker.Tex.transform.localScale.x, (Alarm <= 100f) ? (Alarm / 100f) : 1f, DetectionMarker.Tex.transform.localScale.z);
				DetectionMarker.Tex.color = new Color(DetectionMarker.Tex.color.r, DetectionMarker.Tex.color.g, DetectionMarker.Tex.color.b, Alarm / 100f);
			}
			else if (DetectionMarker.Tex.color.a != 0f)
			{
				DetectionMarker.Tex.enabled = false;
				DetectionMarker.Tex.color = new Color(DetectionMarker.Tex.color.r, DetectionMarker.Tex.color.g, DetectionMarker.Tex.color.b, 0f);
			}
		}
		else
		{
			SpawnDetectionMarker();
		}
	}

	private void UpdateTalkInput()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Debug.Log("The player is attempting to speak to a student.");
			if (!Alarmed)
			{
				AlarmTimer = 0f;
			}
			bool flag = false;
			if (!StudentManager.EmptyDemon)
			{
				if (!StudentManager.Eighties && StudentID == 10 && StudentManager.TaskManager.TaskStatus[46] == 1 && !NoMentor && !StudentManager.TaskManager.Mentored)
				{
					Debug.Log("Nothing should be stopping her, but what time is it?");
					if (Clock.Period == 3 || Clock.Period == 5)
					{
						Debug.Log("It's you-can't-mentor-the-martial-arts-club-o-clock.");
						Yandere.NotificationManager.CustomText = "Martial Arts Club is not training now";
						Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				bool flag2 = false;
				if (StudentManager.Pose)
				{
					flag2 = true;
				}
				if (FocusOnYandere)
				{
					Debug.Log("''FocusOnYandere'' was true at the time.");
					if (!StudentManager.KokonaTutorial)
					{
						EndAlarm();
					}
				}
				if (Alarm > 0f || AlarmTimer > 0f || Yandere.Armed || Yandere.Shoved || Stripping || Waiting || InEvent || SentHome || Threatened || Guarding || VisitSenpaiDesk || (Distracted && !Drownable) || (StudentID == 1 && !flag2) || Yandere.YandereVision || TakingOutTrash)
				{
					if (Alarm > 0f)
					{
						Debug.Log("Alarm was above zero.");
					}
					if (AlarmTimer > 0f)
					{
						Debug.Log("AlarmTimer was above zero.");
					}
					if (Stripping)
					{
						Debug.Log("Stripping was true.");
					}
					if ((!Slave && !BadTime && !Yandere.Gazing && !FightingSlave) || Yandere.YandereVision || Stripping)
					{
						Debug.Log("Met criteria for not being allowed to talk to a student.");
						if (InEvent || VisitSenpaiDesk)
						{
							string text = "She";
							if (Male)
							{
								text = "He";
							}
							Yandere.NotificationManager.CustomText = text + " is busy with an event right now!";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						else if (Guarding)
						{
							string text2 = "She";
							if (Male)
							{
								text2 = "He";
							}
							if (!Teacher)
							{
								Yandere.NotificationManager.CustomText = text2 + " is too scared to talk right now!";
								Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							}
							else
							{
								Yandere.NotificationManager.CustomText = text2 + " is already aware of a murder!";
								Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							}
						}
						Prompt.Circle[0].fillAmount = 1f;
					}
				}
			}
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Debug.Log("The player is allowed to speak to a student right now.");
				bool flag3 = false;
				if (StudentID < 86 && Armband.activeInHierarchy)
				{
					Debug.Log("The player is speaking to a Club Leader.");
					Debug.Log("The Club Leader's current action is: " + Actions[Phase]);
					if (StudentManager.CustomMode)
					{
						flag3 = true;
					}
					if (Actions[Phase] == StudentActionType.ClubAction || Actions[Phase] == StudentActionType.SitAndSocialize || Actions[Phase] == StudentActionType.Socializing || Actions[Phase] == StudentActionType.Sleuth || Actions[Phase] == StudentActionType.Lyrics || Actions[Phase] == StudentActionType.Patrol || Actions[Phase] == StudentActionType.Rehearse || Actions[Phase] == StudentActionType.SitAndEatBento || Actions[Phase] == StudentActionType.BakeSale || Actions[Phase] == StudentActionType.Clean || Actions[Phase] == StudentActionType.Paint)
					{
						Debug.Log("This Club Leader is " + Vector3.Distance(base.transform.position, StudentManager.ClubZones[(int)Club].position) + " meters from the center of his Club Zone.");
						Debug.Log("This Club Leader's DistanceToDestination is " + DistanceToDestination + " but he is actually " + Vector3.Distance(base.transform.position, CurrentDestination.position) + " meters from his destination.");
						if (DistanceToDestination < 10f || (base.transform.position.y > StudentManager.ClubZones[(int)Club].position.y - 2.5f && base.transform.position.y < StudentManager.ClubZones[(int)Club].position.y + 2.5f && Vector3.Distance(base.transform.position, StudentManager.ClubZones[(int)Club].position) < ClubThreshold) || (Club == ClubType.Drama && Vector3.Distance(base.transform.position, StudentManager.DramaSpots[1].position) < 12f) || (Club == ClubType.MartialArts && base.transform.position.y < 1f && Vector3.Distance(base.transform.position, StudentManager.Clubs.List[StudentID].position) < 12f))
						{
							Debug.Log("Criteria for talking to this Club Leader was met.");
							flag3 = true;
							Warned = false;
						}
					}
				}
				if (StudentID == 76)
				{
					Debug.Log("BlondeHair is: " + GameGlobals.BlondeHair + ". Yandere's Persona is: " + Yandere.Persona.ToString() + ". Friendships are: " + PlayerGlobals.GetStudentFriend(76) + ", " + PlayerGlobals.GetStudentFriend(77) + ", " + PlayerGlobals.GetStudentFriend(78) + ", " + PlayerGlobals.GetStudentFriend(79) + ", " + PlayerGlobals.GetStudentFriend(80));
					bool flag4 = false;
					if (Yandere.Persona == YanderePersonaType.Tough || Yandere.Persona == YanderePersonaType.Edgy)
					{
						flag4 = true;
					}
					bool flag5 = false;
					bool flag6 = false;
					bool flag7 = false;
					bool flag8 = false;
					bool flag9 = false;
					flag5 = StudentManager.Students[76] != null && StudentManager.Students[76].Friend;
					flag6 = StudentManager.Students[77] != null && StudentManager.Students[77].Friend;
					flag7 = StudentManager.Students[78] != null && StudentManager.Students[78].Friend;
					flag8 = StudentManager.Students[79] != null && StudentManager.Students[79].Friend;
					flag9 = StudentManager.Students[80] != null && StudentManager.Students[80].Friend;
					Debug.Log("Yandere.PersonaID is: " + Yandere.PersonaID);
					Debug.Log("Yandere.Persona is: " + Yandere.Persona);
					if ((GameGlobals.BlondeHair && Reputation.Reputation < -33.33333f && flag4 && flag5 && flag6 && flag7 && flag8 && flag9) || Yandere.Club == ClubType.Delinquent)
					{
						Debug.Log("Yandere-chan meets the criteria to talk to the delinquent leader about joining.");
						flag3 = true;
						Warned = false;
					}
					else
					{
						Debug.Log("Yandere-chan does not meet the criteria to talk to the delinquent leader about joining.");
					}
				}
				bool flag10 = false;
				if (Yandere.PickUp != null && Yandere.PickUp.Salty && !Indoors)
				{
					flag10 = true;
				}
				bool flag11 = false;
				if (Teacher && StudentManager.CanSelfReport)
				{
					flag11 = true;
				}
				if (ClubGlobals.GetClubKicked(Club) && ExplainedKick)
				{
					flag3 = false;
				}
				if (StudentManager.Pose)
				{
					MyController.enabled = false;
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					Stop = true;
					Pose();
				}
				else if (BadTime)
				{
					Yandere.EmptyHands();
					BecomeRagdoll();
					Yandere.RagdollPK.connectedBody = Ragdoll.AllRigidbodies[5];
					Yandere.RagdollPK.connectedAnchor = Ragdoll.LimbAnchor[4];
					DialogueWheel.PromptBar.ClearButtons();
					DialogueWheel.PromptBar.Label[1].text = "Back";
					DialogueWheel.PromptBar.UpdateButtons();
					DialogueWheel.PromptBar.Show = true;
					Yandere.Ragdoll = Ragdoll.gameObject;
					Yandere.SansEyes[0].SetActive(value: true);
					Yandere.SansEyes[1].SetActive(value: true);
					Yandere.GlowEffect.Play();
					Yandere.CanMove = false;
					Yandere.PK = true;
					DeathType = DeathType.EasterEgg;
				}
				else if (StudentManager.Six)
				{
					UnityEngine.Object.Instantiate(AlarmDisc, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity).GetComponent<AlarmDiscScript>().Originator = this;
					AudioSource.PlayClipAtPoint(Yandere.SixTakedown, base.transform.position);
					AudioSource.PlayClipAtPoint(Yandere.Snarls[UnityEngine.Random.Range(0, Yandere.Snarls.Length)], base.transform.position);
					Yandere.CharacterAnimation.CrossFade("f02_sixEat_00");
					Yandere.TargetStudent = this;
					Yandere.FollowHips = true;
					Yandere.Attacking = true;
					Yandere.CanMove = false;
					Yandere.Eating = true;
					CharacterAnimation.CrossFade(EatVictimAnim);
					CharacterAnimation[WetAnim].weight = 0f;
					Pathfinding.enabled = false;
					Routine = false;
					Dying = true;
					Eaten = true;
					GameObject gameObject = UnityEngine.Object.Instantiate(EmptyGameObject, base.transform.position, Quaternion.identity);
					Yandere.SixTarget = gameObject.transform;
					Yandere.SixTarget.LookAt(Yandere.transform.position);
					Yandere.SixTarget.Translate(Yandere.SixTarget.forward);
				}
				else if (Yandere.SpiderGrow)
				{
					if (!Eaten && !Cosmetic.Empty)
					{
						AudioSource.PlayClipAtPoint(Yandere.SixTakedown, base.transform.position);
						AudioSource.PlayClipAtPoint(Yandere.Snarls[UnityEngine.Random.Range(0, Yandere.Snarls.Length)], base.transform.position);
						GameObject obj = UnityEngine.Object.Instantiate(Yandere.EmptyHusk, base.transform.position + base.transform.forward * 0.5f, Quaternion.identity);
						obj.GetComponent<EmptyHuskScript>().TargetStudent = this;
						obj.transform.LookAt(base.transform.position);
						CharacterAnimation.CrossFade(EatVictimAnim);
						CharacterAnimation[WetAnim].weight = 0f;
						Pathfinding.enabled = false;
						Distracted = false;
						Routine = false;
						Dying = true;
						Eaten = true;
						if (Investigating)
						{
							StopInvestigating();
						}
						if (Following)
						{
							FollowCountdown.gameObject.SetActive(value: false);
							Yandere.Follower = null;
							Yandere.Followers--;
							Following = false;
						}
						UnityEngine.Object.Instantiate(EmptyGameObject, base.transform.position, Quaternion.identity);
					}
				}
				else if (StudentManager.Gaze)
				{
					Yandere.CharacterAnimation.CrossFade("f02_gazerPoint_00");
					Yandere.GazerEyes.Attacking = true;
					Yandere.TargetStudent = this;
					Yandere.GazeAttacking = true;
					Yandere.CanMove = false;
					Routine = false;
				}
				else if (Yandere.Succubus)
				{
					Prompt.Circle[0].fillAmount = 1f;
					if (Male)
					{
						if (Following)
						{
							StopFollowing();
						}
						else
						{
							ParticleSystem.EmissionModule emission = Hearts.emission;
							emission.enabled = true;
							OriginalIdleAnim = AdmireAnims[0];
							IdleAnim = AdmireAnims[0];
							CurrentDestination = Yandere.transform;
							Pathfinding.target = Yandere.transform;
							Prompt.Label[0].text = "     Stop";
							Yandere.FollowerList[Yandere.Followers] = this;
							Yandere.Followers++;
							Following = true;
							Routine = false;
							Hurry = false;
							Blind = true;
							StudentManager.UpdateStudents();
						}
					}
					else if (Yandere.Followers > 0)
					{
						StudentScript studentScript = null;
						for (int i = 0; i < 101; i++)
						{
							if (studentScript == null && Yandere.FollowerList[i] != null)
							{
								studentScript = Yandere.FollowerList[i];
								Yandere.FollowerList[i] = null;
							}
						}
						if (studentScript != null)
						{
							studentScript.MurderSuicidePhase = 1;
							studentScript.HuntTarget = this;
							studentScript.Following = false;
							studentScript.Blind = true;
							studentScript.GoCommitMurder();
						}
					}
				}
				else if (Slave)
				{
					Prompt.Circle[0].fillAmount = 1f;
					Yandere.TargetStudent = this;
					Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
					Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(value: true);
					Yandere.PauseScreen.StudentInfoMenu.Column = 0;
					Yandere.PauseScreen.StudentInfoMenu.Row = 0;
					Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
					StartCoroutine(Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
					Yandere.PauseScreen.MainMenu.SetActive(value: false);
					Yandere.PauseScreen.Panel.enabled = true;
					Yandere.PauseScreen.Sideways = true;
					Yandere.PauseScreen.Show = true;
					Time.timeScale = 0.0001f;
					Yandere.PromptBar.ClearButtons();
					Yandere.PromptBar.Label[1].text = "Cancel";
					Yandere.PromptBar.UpdateButtons();
					Yandere.PromptBar.Show = true;
				}
				else if (FightingSlave)
				{
					Yandere.CharacterAnimation.CrossFade("f02_subtleStab_00");
					Yandere.SubtleStabbing = true;
					Yandere.TargetStudent = this;
					Yandere.CanMove = false;
				}
				else if (Following)
				{
					StopFollowing();
				}
				else if ((Clock.Period == 2 && !flag11) || (Clock.Period == 4 && !flag11))
				{
					Debug.Log("This character won't talk because Class is in session, or because their destination is ''seat''.");
					if (Club != ClubType.Delinquent)
					{
						Subtitle.UpdateLabel(SubtitleType.ClassApology, 0, 3f);
					}
					else
					{
						Subtitle.UpdateLabel(SubtitleType.DelinquentAnnoy, UnityEngine.Random.Range(0, Subtitle.DelinquentAnnoyClips.Length), 3f);
					}
					Prompt.Circle[0].fillAmount = 1f;
				}
				else if (InEvent || !CanTalk || GoAway || Fleeing || (Meeting && !Drownable) || Wet || TurnOffRadio || InvestigatingBloodPool || (MyPlate != null && MyPlate.parent == RightHand) || flag10 || ReturningMisplacedWeapon || Actions[Phase] == StudentActionType.Bully || Actions[Phase] == StudentActionType.Graffiti || (CanTakeSnack && IgnoreFoodTimer > 0f) || (FollowTarget != null && FollowTarget.InEvent))
				{
					Subtitle.UpdateLabel(SubtitleType.EventApology, 1, 3f);
					Prompt.Circle[0].fillAmount = 1f;
					StudentManager.UpdateMe(StudentID);
				}
				else if (Clock.Period == 3 && BusyAtLunch)
				{
					Subtitle.UpdateLabel(SubtitleType.SadApology, 1, 3f);
					Prompt.Circle[0].fillAmount = 1f;
				}
				else if (Warned)
				{
					Debug.Log("This character refuses to speak to Yandere-chan because of a grudge.");
					Subtitle.UpdateLabel(SubtitleType.GrudgeRefusal, 0, 3f);
					Prompt.Circle[0].fillAmount = 1f;
					if (!Male)
					{
						CharacterAnimation["f02_smile_00"].weight = 0f;
					}
				}
				else if (Ignoring)
				{
					Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
					Prompt.Circle[0].fillAmount = 1f;
				}
				else if (Yandere.PickUp != null && Yandere.PickUp.PuzzleCube)
				{
					if (Investigating)
					{
						StopInvestigating();
					}
					EmptyHands();
					Prompt.Circle[0].fillAmount = 1f;
					PuzzleCube = Yandere.PickUp;
					Yandere.EmptyHands();
					PuzzleCube.enabled = false;
					PuzzleCube.Prompt.Hide();
					PuzzleCube.Prompt.enabled = false;
					PuzzleCube.MyRigidbody.useGravity = false;
					PuzzleCube.MyRigidbody.isKinematic = true;
					PuzzleCube.gameObject.transform.parent = RightHand;
					PuzzleCube.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					PuzzleCube.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					if (Male)
					{
						PuzzleCube.gameObject.transform.localPosition = new Vector3(0f, -0.0466666f, 0f);
						PuzzleCube.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					}
					else
					{
						PuzzleCube.gameObject.transform.localPosition = new Vector3(0f, -0.0266666f, 0f);
						PuzzleCube.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
					}
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					SolvingPuzzle = true;
					Distracted = true;
					Routine = false;
				}
				else if (Actions[Phase] == StudentActionType.LightFire && DistanceToDestination < 1f)
				{
					Yandere.NotificationManager.CustomText = "She doesn't seem to notice you...";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					Prompt.Circle[0].fillAmount = 1f;
				}
				else if (Teacher && !StudentManager.CanSelfReport)
				{
					StudentManager.CheckSelfReportStatus(this);
				}
				else
				{
					bool flag12 = false;
					if (Yandere.Bloodiness + (float)Yandere.GloveBlood > 0f && !Yandere.Paint)
					{
						flag12 = true;
					}
					if (Yandere.Club == ClubType.Art && Yandere.ClubAttire)
					{
						flag12 = false;
					}
					if (!Witness && flag12)
					{
						Prompt.Circle[0].fillAmount = 1f;
						YandereVisible = true;
						Alarm = 200f;
					}
					else
					{
						if (Subtitle.CurrentClip != null)
						{
							UnityEngine.Object.Destroy(Subtitle.CurrentClip);
						}
						Debug.Log("Setting Speaker to " + Name);
						Subtitle.Speaker = this;
						SpeechLines.Stop();
						Yandere.TargetStudent = this;
						if (!Grudge)
						{
							if (!Yandere.StudentManager.TutorialActive)
							{
								ClubManager.CheckGrudge(Club);
							}
							if (StudentID > 89 && StudentManager.CanSelfReport)
							{
								Debug.Log("The player has just reported blood/murder to the faculty.");
								StudentManager.Reputation.UpdateRep();
								Police.SelfReported = true;
								StudentManager.Reputation.Portal.EndDay();
							}
							else if (ClubGlobals.GetClubKicked(Club) && flag3 && !ExplainedKick)
							{
								Debug.Log("Player was kicked out of this club.");
								if (ClubManager.ClubGrudge)
								{
									Debug.Log("Someone in the club hates the player.");
								}
								else
								{
									Debug.Log("Player never showed up for club activities, got kicked.");
								}
								Interaction = StudentInteractionType.ClubGrudge;
								ExplainedKick = true;
								TalkTimer = 5f;
								Warned = true;
							}
							else if (Yandere.Club == Club && flag3 && ClubManager.ClubGrudge)
							{
								Interaction = StudentInteractionType.ClubKick;
								ClubManager.ClubsKickedFrom[(int)Club] = true;
								TalkTimer = 5f;
								Warned = true;
							}
							else if (CanBeFed)
							{
								Interaction = StudentInteractionType.Feeding;
								TalkTimer = 10f;
							}
							else if (CanTakeSnack)
							{
								Yandere.Interaction = YandereInteractionType.GivingSnack;
								Yandere.TalkTimer = 3f;
								Interaction = StudentInteractionType.Idle;
							}
							else if (CanGiveHelp)
							{
								Yandere.Interaction = YandereInteractionType.AskingForHelp;
								Yandere.TalkTimer = 5f;
								Interaction = StudentInteractionType.Idle;
							}
							else if (!StudentManager.Eighties && StudentID == 10 && StudentManager.TaskManager.TaskStatus[46] == 1 && Yandere.PickUp == null && !flag)
							{
								Debug.Log("The status of Budo's Task is: " + StudentManager.TaskManager.TaskStatus[46]);
								Debug.Log("The game thinks that the current period is: " + Clock.Period);
								if (Clock.Period == 3 || Clock.Period == 5)
								{
									Yandere.NotificationManager.CustomText = "Martial Arts Club is not training now!";
									Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
									Debug.Log("HOW THE FUCK DID THE CODE GET HERE?????");
								}
								else
								{
									if (FollowTarget != null)
									{
										StudentManager.LastKnownOsana.position = FollowTarget.transform.position;
									}
									Interaction = StudentInteractionType.Idle;
									Yandere.Interaction = YandereInteractionType.TaskInquiry;
									Yandere.TalkTimer = 5f;
								}
							}
							else if (StudentID == 79 && DistanceToDestination < 1f && Actions[Phase] == StudentActionType.Wait)
							{
								Interaction = StudentInteractionType.WaitingForBeatEmUpResult;
							}
							else
							{
								if (Destinations[Phase] == null)
								{
									DistanceToDestination = 100f;
								}
								else
								{
									DistanceToDestination = Vector3.Distance(base.transform.position, Destinations[Phase].position);
								}
								if (Sleuthing && SleuthTarget != null)
								{
									DistanceToDestination = Vector3.Distance(base.transform.position, SleuthTarget.position);
								}
								if (flag3)
								{
									int num = 0;
									num = ((Club == ClubType.Photography && Sleuthing) ? 5 : 0);
									if (StudentManager.EmptyDemon)
									{
										num = (int)Club * -1;
									}
									Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int)(Club + num), 4f);
									DialogueWheel.ClubLeader = true;
									Yandere.Jukebox.ClubTheme.clip = Yandere.Jukebox.ClubThemes[(int)Club];
									Yandere.Jukebox.ClubTheme.Play();
								}
								else
								{
									Subtitle.UpdateLabel(SubtitleType.Greeting, 0, 3f);
								}
								if (Club != ClubType.Council && Club != ClubType.Delinquent && ((Male && Yandere.Class.Seduction + Yandere.Class.SeductionBonus > 0) || Yandere.Class.Seduction + Yandere.Class.SeductionBonus > 4))
								{
									ParticleSystem.EmissionModule emission2 = Hearts.emission;
									emission2.rateOverTime = Yandere.Class.Seduction + Yandere.Class.SeductionBonus;
									emission2.enabled = true;
									Hearts.Play();
								}
								StudentManager.DisablePrompts();
								StudentManager.VolumeDown();
								DialogueWheel.HideShadows();
								DialogueWheel.Show = true;
								DialogueWheel.Panel.enabled = true;
								TalkTimer = 0f;
								if (Rival)
								{
									int num2 = DialogueWheel.Social.StudentFriendships[StudentID];
									float num3 = DialogueWheel.Social.StudentThresholds[StudentID] * 100f;
									Yandere.NotificationManager.CustomText = "Friendship: " + num2 + "/" + num3;
									Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
								}
							}
						}
						else if (flag3)
						{
							Interaction = StudentInteractionType.ClubUnwelcome;
							TalkTimer = 5f;
							Warned = true;
						}
						else
						{
							Interaction = StudentInteractionType.PersonalGrudge;
							TalkTimer = 5f;
							Warned = true;
						}
						Yandere.ShoulderCamera.OverShoulder = true;
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
						Obstacle.enabled = true;
						Giggle = null;
						Yandere.WeaponMenu.KeyboardShow = false;
						Yandere.WeaponMenu.Show = false;
						Yandere.YandereVision = false;
						Yandere.CanMove = false;
						Yandere.Talking = true;
						Investigating = false;
						Talk.enabled = true;
						Reacted = false;
						Routine = false;
						Talking = true;
						TargetDistance = 0.5f;
						CuriosityPhase = 0;
						ReadPhase = 0;
						EmptyHands();
						bool flag13 = false;
						if (CurrentAction == StudentActionType.Sunbathe && SunbathePhase > 2)
						{
							SunbathePhase = 2;
							flag13 = true;
						}
						if (Phoneless)
						{
							SmartPhone.SetActive(value: false);
						}
						else if (Sleuthing)
						{
							if (!Scrubber.activeInHierarchy)
							{
								SmartPhone.SetActive(value: true);
							}
							else
							{
								SmartPhone.SetActive(value: false);
							}
						}
						else if (Persona != PersonaType.PhoneAddict)
						{
							SmartPhone.SetActive(value: false);
						}
						else if (!Scrubber.activeInHierarchy && !flag13)
						{
							SmartPhone.SetActive(value: true);
						}
						ChalkDust.Stop();
						StopPairing();
					}
				}
			}
		}
		if (Prompt.Circle[2].fillAmount != 0f && (!(Yandere.Sanity < 33.33333f) || !Yandere.CanMove || Prompt.HideButton[2] || !Prompt.InSight || Club == ClubType.Council || Struggling || Chasing || !(DistanceToPlayer < 1.4f) || !SeenByYandere() || StudentID <= 1 || !(Yandere.EquippedWeapon != null) || Yandere.EquippedWeapon.Broken))
		{
			return;
		}
		if (!Yandere.Armed && Drownable)
		{
			GameObject obj2 = UnityEngine.Object.Instantiate(AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
			obj2.GetComponent<AlarmDiscScript>().Originator = this;
			obj2.GetComponent<AlarmDiscScript>().Silent = true;
			Debug.Log("Just began to drown someone.");
			if (VomitDoor != null)
			{
				VomitDoor.Prompt.enabled = true;
				VomitDoor.enabled = true;
			}
			Yandere.EmptyHands();
			Prompt.Hide();
			Prompt.enabled = false;
			Prompt.Circle[2].fillAmount = 1f;
			VomitEmitter.gameObject.SetActive(value: false);
			Police.DrownedStudentName = Name;
			MyController.enabled = false;
			SmartPhone.SetActive(value: false);
			Police.DrownVictims++;
			Distracted = true;
			Routine = false;
			Drowned = true;
			if (Male)
			{
				Subtitle.UpdateLabel(SubtitleType.DrownReaction, 1, 3f);
			}
			else
			{
				Subtitle.UpdateLabel(SubtitleType.DrownReaction, 0, 3f);
			}
			Yandere.TargetStudent = this;
			Yandere.Attacking = true;
			Yandere.CanMove = false;
			Yandere.Drown = true;
			Yandere.DrownAnim = "f02_fountainDrownA_00";
			if (Male)
			{
				if (Vector3.Distance(base.transform.position, StudentManager.transform.position) < 5f)
				{
					DrownAnim = "fountainDrown_00_B";
				}
				else
				{
					DrownAnim = "toiletDrown_00_B";
				}
			}
			else if (Vector3.Distance(base.transform.position, StudentManager.transform.position) < 5f)
			{
				DrownAnim = "f02_fountainDrownB_00";
			}
			else
			{
				DrownAnim = "f02_toiletDrownB_00";
			}
			CharacterAnimation.CrossFade(DrownAnim);
			return;
		}
		if (!Yandere.Armed && Pushable)
		{
			CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			if (!Male)
			{
				Subtitle.UpdateLabel(SubtitleType.NoteReaction, 5, 3f);
			}
			else
			{
				Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 5, 3f);
			}
			Prompt.Label[0].text = "     Talk";
			Prompt.Circle[0].fillAmount = 1f;
			Yandere.TargetStudent = this;
			Yandere.FollowHips = true;
			Yandere.Attacking = true;
			Yandere.RoofPush = true;
			Yandere.CanMove = false;
			Yandere.EmptyHands();
			EmptyHands();
			Distracted = true;
			Routine = false;
			Pushed = true;
			CharacterAnimation.CrossFade(PushedAnim);
			RemoveOfferHelpPrompt();
			Yandere.PromptBar.ClearButtons();
			Yandere.PromptBar.Show = true;
			Yandere.PromptBar.Label[1].text = "Death Cam";
			Yandere.PromptBar.UpdateButtons();
			return;
		}
		if (Yandere.EquippedWeapon != null && Yandere.EquippedWeapon.Broken)
		{
			if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				Yandere.NotificationManager.CustomText = "Can't attack! Weapon is broken!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			return;
		}
		Debug.Log(Name + " was just attacked, either because the player pressed the X button, or because Yandere-chan had low sanity.");
		if (Investigating)
		{
			StopInvestigating();
		}
		float f = Vector3.Angle(-base.transform.forward, Yandere.transform.position - base.transform.position);
		Yandere.AttackManager.Stealth = Mathf.Abs(f) <= 45f;
		if (Yandere.EquippedWeapon.Type == WeaponType.Garrote && !Yandere.AttackManager.Stealth)
		{
			if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				Yandere.NotificationManager.CustomText = "To strangle, approach from behind.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			return;
		}
		bool flag14 = false;
		if (Yandere.Armed && Yandere.AttackManager.Stealth && (Yandere.EquippedWeapon.Type == WeaponType.Bat || Yandere.EquippedWeapon.Type == WeaponType.Weight))
		{
			flag14 = true;
		}
		if (Yandere.Bloodiness > 0f)
		{
			flag14 = true;
		}
		if (flag14 || Yandere.Schoolwear == 2 || StudentManager.OriginalUniforms + StudentManager.NewUniforms > 1)
		{
			if (ClubActivityPhase >= 16)
			{
				return;
			}
			bool flag15 = false;
			if (Club == ClubType.Delinquent && !Injured && !Yandere.AttackManager.Stealth && !RespectEarned && !SolvingPuzzle && !Wet && MyWeapon != null && !Blind && !Yandere.Invisible && !EatingSnack)
			{
				Debug.Log(Name + " knows that Yandere-chan is trying to attack them, and will now shove (and spawn alarm disc).");
				Persona = PersonaType.Violent;
				flag15 = true;
				RespectEarned = false;
				Fleeing = false;
				Patience = 1;
				Shove();
				SpawnAlarmDisc();
			}
			if (Yandere.AttackManager.Stealth)
			{
				SpawnSmallAlarmDisc();
			}
			if (flag15 || Yandere.NearSenpai || Yandere.Attacking || Yandere.Stance.Current == StanceType.Crouching)
			{
				return;
			}
			if ((Yandere.Armed && Yandere.EquippedWeapon.Flaming) || Yandere.CyborgParts[1].activeInHierarchy)
			{
				Yandere.SanityBased = false;
			}
			if (Strength == 9 && !Emetic && !Lethal && !Sedated && !Headache)
			{
				if (Following)
				{
					StopFollowing();
				}
				if (!Male)
				{
					if (!Yandere.AttackManager.Stealth)
					{
						CharacterAnimation.CrossFade("f02_dramaticFrontal_00");
					}
					else
					{
						CharacterAnimation.CrossFade("f02_dramaticStealth_00");
					}
				}
				else if (!Yandere.AttackManager.Stealth)
				{
					CharacterAnimation.CrossFade("dramaticFrontal_00");
				}
				else
				{
					Debug.Log("This character should be playing the dramaticStealth_00 animation right now...");
					CharacterAnimation.CrossFade("dramaticStealth_00");
				}
				Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
				Yandere.StruggleIminent = true;
				Yandere.CanMove = false;
				if (StudentManager.ChallengeManager.InvincibleRaibaru || Yandere.PhysicalGrade + Yandere.Class.PhysicalBonus <= 0)
				{
					Yandere.Invisible = true;
				}
				DramaticCamera.enabled = true;
				DramaticCamera.rect = new Rect(0f, 0.5f, 1f, 0f);
				DramaticCamera.gameObject.SetActive(value: true);
				DramaticCamera.gameObject.GetComponent<AudioSource>().Play();
				DramaticReaction = true;
				GoAway = false;
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				Routine = false;
			}
			else if (Yandere.Armed)
			{
				if (Yandere.EquippedWeapon.WeaponID != 27 || (Yandere.EquippedWeapon.WeaponID == 27 && Yandere.AttackManager.Stealth))
				{
					AttackReaction();
				}
				else if (Yandere.NotificationManager.Timer == 0f)
				{
					Yandere.NotificationManager.CustomText = "Approach victim from behind to strangle";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					Yandere.NotificationManager.Timer = 5f;
				}
			}
		}
		else if (!Yandere.ClothingWarning)
		{
			Yandere.NotificationManager.DisplayNotification(NotificationType.Clothing);
			StudentManager.TutorialWindow.ShowClothingMessage = true;
			Yandere.ClothingWarning = true;
		}
	}

	private void UpdateDying()
	{
		CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
		if (!Attacked)
		{
			return;
		}
		if (!Teacher)
		{
			if (Strength == 9 && !Emetic && !Lethal && !Sedated && !Headache)
			{
				Debug.Log("Raibaru is counter-attacking!");
				if (!StudentManager.Stop)
				{
					StudentManager.StopMoving();
					Yandere.RPGCamera.enabled = false;
					SmartPhone.SetActive(value: false);
					Police.Show = false;
				}
				if (!Male)
				{
					CharacterAnimation.CrossFade("f02_moCounterB_00");
				}
				else
				{
					CharacterAnimation.CrossFade("moCounterB_00");
				}
				if (!WitnessedMurder && !Male && CharacterAnimation["f02_moLipSync_00"].weight == 0f)
				{
					CharacterAnimation["f02_moLipSync_00"].weight = 1f;
					CharacterAnimation["f02_moLipSync_00"].time = 0f;
					CharacterAnimation.Play("f02_moLipSync_00");
				}
				targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
				MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward);
				return;
			}
			EyeShrink = Mathf.Lerp(EyeShrink, 1f, Time.deltaTime * 10f);
			if (Alive && !Tranquil)
			{
				if (!Yandere.SanityBased)
				{
					targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
					if (Yandere.EquippedWeapon.WeaponID == 11)
					{
						CharacterAnimation.CrossFade(CyborgDeathAnim);
						MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward);
						if (CharacterAnimation[CyborgDeathAnim].time >= CharacterAnimation[CyborgDeathAnim].length - 0.25f && Yandere.EquippedWeapon.WeaponID == 11)
						{
							UnityEngine.Object.Instantiate(BloodyScream, base.transform.position + Vector3.up, Quaternion.identity);
							DeathType = DeathType.EasterEgg;
							BecomeRagdoll();
							Ragdoll.Dismember();
						}
					}
					else if (Yandere.EquippedWeapon.WeaponID == 7)
					{
						CharacterAnimation.CrossFade(BuzzSawDeathAnim);
						MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward);
					}
					else if (!Yandere.EquippedWeapon.Concealable)
					{
						CharacterAnimation.CrossFade(SwingDeathAnim);
						MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward);
					}
					else
					{
						CharacterAnimation.CrossFade(DefendAnim);
						MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward * 0.1f);
					}
				}
				else
				{
					Vector3 vector = Yandere.transform.position + Yandere.transform.forward * Yandere.AttackManager.Distance;
					if (Vector3.Distance(vector, base.transform.position) > 0.5f)
					{
						base.transform.position = vector;
					}
					MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward * Yandere.AttackManager.Distance);
					if (!Yandere.AttackManager.Stealth)
					{
						targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
					}
					else
					{
						targetRotation = Quaternion.LookRotation(base.transform.position - new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z));
					}
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
				}
			}
			else
			{
				CharacterAnimation.CrossFade(DeathAnim);
				if (CharacterAnimation[DeathAnim].time < 1f)
				{
					base.transform.Translate(Vector3.back * Time.deltaTime);
				}
				else
				{
					BecomeRagdoll();
				}
			}
		}
		else
		{
			if (!StudentManager.Stop)
			{
				StudentManager.StopMoving();
				Yandere.Laughing = false;
				Yandere.Dipping = false;
				Yandere.RPGCamera.enabled = false;
				SmartPhone.SetActive(value: false);
				Police.Show = false;
			}
			CharacterAnimation.CrossFade(CounterAnim);
			targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			MoveTowardsTarget(Yandere.transform.position + Yandere.transform.forward);
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
	}

	private void UpdatePushed()
	{
		Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
		EyeShrink = Mathf.Lerp(EyeShrink, 1f, Time.deltaTime * 10f);
		if (CharacterAnimation[PushedAnim].time >= CharacterAnimation[PushedAnim].length)
		{
			BecomeRagdoll();
		}
	}

	private void UpdateDrowned()
	{
		SplashTimer += Time.deltaTime;
		if (SplashTimer > 3f && SplashTimer < 100f)
		{
			DrowningSplashes.Play();
			SplashTimer += 100f;
		}
		Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
		EyeShrink = Mathf.Lerp(EyeShrink, 1f, Time.deltaTime * 10f);
		if (CharacterAnimation[DrownAnim].time >= CharacterAnimation[DrownAnim].length)
		{
			BecomeRagdoll();
		}
	}

	private void UpdateWitnessedMurder()
	{
		if (Threatened)
		{
			UpdateAlarmed();
		}
		else
		{
			if (Fleeing || Shoving)
			{
				return;
			}
			if (StudentID > 1 && Persona != PersonaType.Evil)
			{
				EyeShrink += Time.deltaTime * 0.2f;
			}
			if ((Yandere.Attacking && Yandere.TargetStudent != null && LovedOneIsTargeted(Yandere.TargetStudent.StudentID)) || (ElectrocutionVictim > 0 && LovedOneIsTargeted(ElectrocutionVictim)) || (Yandere.Carrying && LovedOneIsTargeted(Yandere.CurrentRagdoll.StudentID)) || (Yandere.Dragging && LovedOneIsTargeted(Yandere.CurrentRagdoll.StudentID)))
			{
				Debug.Log(Name + " realized that the protagonist killed their loved one!");
				Strength = 5;
				Persona = PersonaType.Heroic;
				SmartPhone.SetActive(value: false);
				SprintAnim = OriginalSprintAnim;
			}
			if ((Club != ClubType.Delinquent || (Club == ClubType.Delinquent && Injured)) && Yandere.TargetStudent == null && LovedOneIsTargeted(Yandere.NearestCorpseID))
			{
				Strength = 5;
				if (Injured)
				{
					Strength = 1;
				}
				Persona = PersonaType.Heroic;
			}
			if (Yandere.PickUp != null && Yandere.PickUp.BodyPart != null && Yandere.PickUp.BodyPart.Type == 1 && LovedOneIsTargeted(Yandere.PickUp.BodyPart.StudentID))
			{
				Strength = 5;
				Persona = PersonaType.Heroic;
				SmartPhone.SetActive(value: false);
				SprintAnim = OriginalSprintAnim;
			}
			if (Persona == PersonaType.PhoneAddict && !Phoneless)
			{
				if (!Attacked)
				{
					Debug.Log("Calling PhoneAddictCameraUpdate() from here, specifically.");
					PhoneAddictCameraUpdate();
				}
			}
			else
			{
				CharacterAnimation.CrossFade(ScaredAnim);
			}
			targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.position.x, base.transform.position.y, Yandere.Hips.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			if (!Yandere.Struggling)
			{
				if (Persona != PersonaType.Heroic && Persona != PersonaType.Dangerous && Persona != PersonaType.Violent)
				{
					AlarmTimer += Time.deltaTime * (float)MurdersWitnessed;
					if (Urgent && Yandere.CanMove)
					{
						if (StudentID == 1 && Persona != PersonaType.Evil)
						{
							SenpaiNoticed();
						}
						AlarmTimer += 5f;
					}
				}
				else
				{
					AlarmTimer += Time.deltaTime * ((float)MurdersWitnessed * 5f);
				}
			}
			else if (Yandere.Won)
			{
				Urgent = true;
			}
			if (AlarmTimer > 5f)
			{
				PersonaReaction();
				AlarmTimer = 0f;
			}
			else if (AlarmTimer > 1f && !Reacted)
			{
				if (StudentID == 1 && Persona != PersonaType.Evil && Yandere.Mask == null)
				{
					Debug.Log("Senpai witnessed murder, and entered a specific murder reaction animation.");
					MurderReaction = UnityEngine.Random.Range(1, 6);
					if (Male)
					{
						CharacterAnimation.CrossFade("senpaiMurderReaction_0" + MurderReaction);
						CharacterAnimation["scaredFace_00"].weight = 0f;
					}
					GameOverCause = GameOverType.Murder;
					if (!Yandere.Egg)
					{
						SenpaiNoticed();
					}
					CharacterAnimation[AngryFaceAnim].weight = 0f;
					Yandere.ShoulderCamera.enabled = true;
					Yandere.ShoulderCamera.Noticed = true;
					Yandere.RPGCamera.enabled = false;
					Stop = true;
				}
				else
				{
					if (StudentID == 1 && Persona != PersonaType.Evil)
					{
						Debug.Log("Senpai saw a mask.");
						Persona = PersonaType.Heroic;
						PersonaReaction();
					}
					if (!Teacher)
					{
						if (Persona != PersonaType.Evil)
						{
							if (Club == ClubType.Delinquent)
							{
								SmartPhone.SetActive(value: false);
							}
							else if (!StudentManager.Eighties && StudentID == 10)
							{
								Debug.Log("This is the exact moment that Raibaru witnesses Yandere-chan commit murder.");
								Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 1, 3f);
								Yandere.Chasers++;
								Urgent = true;
							}
							else
							{
								Subtitle.UpdateLabel(SubtitleType.MurderReaction, 1, 3f);
							}
						}
					}
					else if (WitnessedCoverUp)
					{
						Subtitle.UpdateLabel(SubtitleType.TeacherCoverUpHostile, 1, 5f);
					}
					else
					{
						DetermineWhatWasWitnessed();
						DetermineTeacherSubtitle();
					}
				}
				Reacted = true;
			}
			if (!Male)
			{
				CharacterAnimation[ShyAnim].weight = Mathf.Lerp(CharacterAnimation[ShyAnim].weight, 0f, Time.deltaTime);
			}
		}
	}

	private void UpdateAlarmed()
	{
		if (ID == 30)
		{
			Debug.Log(Name + " is calling UpdateAlarmed()");
		}
		if (!Threatened)
		{
			if (Yandere.Medusa && YandereVisible)
			{
				TurnToStone();
				return;
			}
			if (Persona != PersonaType.PhoneAddict && !Sleuthing)
			{
				SmartPhone.SetActive(value: false);
			}
			OccultBook.SetActive(value: false);
			Pen.SetActive(value: false);
			SpeechLines.Stop();
			ReadPhase = 0;
			if (WitnessedCorpse)
			{
				if (!WalkBack)
				{
					_ = StudentID;
					_ = 1;
					if (Persona != PersonaType.PhoneAddict)
					{
						CharacterAnimation.CrossFade(ScaredAnim);
					}
					else if (!Phoneless && !Attacked)
					{
						if (Corpse.MurderSuicideAnimation)
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						else
						{
							PhoneAddictCameraUpdate();
						}
					}
				}
				else
				{
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					MyController.Move(base.transform.forward * (-0.5f * Time.deltaTime));
					CharacterAnimation.CrossFade(WalkBackAnim);
					WalkBackTimer -= Time.deltaTime;
					if (WalkBackTimer <= 0f)
					{
						WalkBack = false;
					}
				}
			}
			else if (StudentID > 1)
			{
				if (Witness)
				{
					CharacterAnimation.CrossFade(LeanAnim);
				}
				else
				{
					if (!Investigating)
					{
						if (FocusOnStudent)
						{
							CharacterAnimation.CrossFade(LeanAnim);
						}
						else
						{
							CharacterAnimation.CrossFade(LeanAnim);
						}
					}
					if (FocusOnYandere)
					{
						if (DistanceToPlayer < 1f && !Injured && ((Club == ClubType.Council && !DoNotShove) || (Club == ClubType.Delinquent && !Injured) || Shovey))
						{
							AlarmTimer = 0f;
							if (Yandere.CanMove)
							{
								ThreatTimer += Time.deltaTime;
							}
							if (ThreatTimer > 5f && !Yandere.Struggling && !Yandere.DelinquentFighting && !Yandere.Chased && Yandere.Chasers == 0 && Prompt.InSight)
							{
								ThreatTimer = 0f;
								Shove();
							}
						}
						DistractionSpot = new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z);
					}
				}
			}
			else
			{
				CharacterAnimation.CrossFade(LeanAnim);
			}
			if (WitnessedMurder)
			{
				targetRotation = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			}
			else if (WitnessedCorpse)
			{
				if (Corpse != null && Corpse.AllColliders[0] != null)
				{
					targetRotation = Quaternion.LookRotation(new Vector3(Corpse.AllColliders[0].transform.position.x, base.transform.position.y, Corpse.AllColliders[0].transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				}
			}
			else if (WitnessedBloodPool || WitnessedLimb || WitnessedWeapon)
			{
				if (BloodPool != null)
				{
					targetRotation = Quaternion.LookRotation(new Vector3(BloodPool.transform.position.x, base.transform.position.y, BloodPool.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				}
			}
			else if (!Investigating)
			{
				if (!FocusOnYandere)
				{
					if (DiscCheck)
					{
						targetRotation = Quaternion.LookRotation(new Vector3(DistractionSpot.x, base.transform.position.y, DistractionSpot.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
					}
				}
				else
				{
					LookAtYandere();
				}
			}
			if (!Fleeing && !Yandere.DelinquentFighting)
			{
				AlarmTimer += Time.deltaTime * (1f - Hesitation);
			}
			if (!CanStillNotice)
			{
				Alarm -= Time.deltaTime * 100f * (1f / Paranoia) * 5f;
			}
			if (AlarmTimer < 5f && BloodPool != null && CanSeeObject(Yandere.gameObject, Yandere.HeadPosition) && BloodPool.parent == Yandere.RightHand)
			{
				Debug.Log("ForgetAboutBloodPool() was called from this place in the code. 3");
				ForgetAboutBloodPool();
			}
			if (AlarmTimer > 5f)
			{
				if (!DramaticReaction)
				{
					EndAlarm();
				}
			}
			else if (AlarmTimer > 1f && !Reacted)
			{
				if (Teacher)
				{
					if (!WitnessedCorpse)
					{
						Debug.Log(Name + " witnessed: " + Witnessed);
						if (Concern > 4 || Witnessed == StudentWitnessType.Trespassing)
						{
							Debug.Log("A teacher's subtitle is now being determined.");
							CharacterAnimation.CrossFade(IdleAnim);
							switch (Witnessed)
							{
							case StudentWitnessType.BloodAndInsanity:
							case StudentWitnessType.Insanity:
							case StudentWitnessType.CleaningItem:
							case StudentWitnessType.Poisoning:
							case StudentWitnessType.WeaponAndBloodAndInsanity:
							case StudentWitnessType.WeaponAndInsanity:
								Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
								GameOverCause = GameOverType.Insanity;
								break;
							case StudentWitnessType.Weapon:
							case StudentWitnessType.WeaponAndBlood:
								Subtitle.UpdateLabel(SubtitleType.TeacherWeaponReaction, 1, 6f);
								GameOverCause = GameOverType.Weapon;
								break;
							case StudentWitnessType.Blood:
								Subtitle.UpdateLabel(SubtitleType.TeacherBloodReaction, 1, 6f);
								GameOverCause = GameOverType.Blood;
								break;
							case StudentWitnessType.Lewd:
								Debug.Log(Name + ", using the Teacher Persona, witnessed lewd behavior.");
								Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
								GameOverCause = GameOverType.Lewd;
								break;
							case StudentWitnessType.Violence:
								Debug.Log(Name + ", using the Teacher Persona, witnessed violence.");
								Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, 1, 6f);
								GameOverCause = GameOverType.Violence;
								Concern = 5;
								break;
							case StudentWitnessType.Trespassing:
								Debug.Log("Witnessed was Trespassing, so we're using TeacherTrespassingReaction.");
								Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, Concern, 5f);
								break;
							case StudentWitnessType.Pickpocketing:
							case StudentWitnessType.Theft:
								Subtitle.UpdateLabel(SubtitleType.TeacherTheftReaction, 1, 6f);
								break;
							}
						}
						else
						{
							Debug.Log("Concerned was below 5 and player was not trespassing, so we're using HmmReaction.");
							if (WitnessedSlave)
							{
								Subtitle.UpdateLabel(SubtitleType.SlaveReaction, 1, 3f);
							}
							else
							{
								Subtitle.UpdateLabel(SubtitleType.HmmReaction, 1, 3f);
							}
						}
						if (Club == ClubType.Council)
						{
							UnityEngine.Object.Destroy(Subtitle.CurrentClip);
							Subtitle.UpdateLabel(SubtitleType.CouncilToCounselor, ClubMemberID, 6f);
						}
						if (!Yandere.Noticed && BloodPool != null)
						{
							Debug.Log(Name + ", using the Teacher Persona, was alarmed because she saw something weird on the ground - a " + BloodPool.name);
							UnityEngine.Object.Destroy(Subtitle.CurrentClip);
							Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 2, 5f);
							PromptScript component = BloodPool.GetComponent<PromptScript>();
							if (component != null)
							{
								WeaponScript component2 = BloodPool.GetComponent<WeaponScript>();
								bool flag = false;
								if (component2 != null)
								{
									if (component2.BroughtFromHome)
									{
										Debug.Log("This weapon was brought from home!");
										flag = true;
									}
									else
									{
										Debug.Log("This weapon was not brought from home.");
									}
								}
								if (!flag)
								{
									Debug.Log("Disabling a bloody object's prompt because " + Name + ", using the Teacher Persona, is heading for it.");
									component.Hide();
									component.enabled = false;
								}
							}
							if (ReportPhase == 2)
							{
								Debug.Log("This teacher noticed the suspicious object while on her way to investigate something, and is now updating her pathfinding target.");
								DetermineBloodLocation();
							}
						}
					}
					else
					{
						Debug.Log("A teacher found a corpse.");
						Concern = 1;
						DetermineWhatWasWitnessed();
						DetermineTeacherSubtitle();
						if (WitnessedMurder)
						{
							MurdersWitnessed++;
							if (!Yandere.Chased)
							{
								Debug.Log("A teacher has reached ChaseYandere() through UpdateAlarm().");
								ChaseYandere();
							}
						}
					}
					if (!Chasing && ((YandereVisible && Concern == 5) || Yandere.Noticed))
					{
						Debug.Log("Yandere-chan is getting sent to the guidance counselor.");
						if (Witnessed == StudentWitnessType.Theft && Yandere.StolenObject != null)
						{
							Yandere.StolenObject.SetActive(value: true);
							Yandere.StolenObject = null;
							Yandere.Inventory.IDCard = false;
						}
						StudentManager.CombatMinigame.Stop();
						CharacterAnimation[AngryFaceAnim].weight = 1f;
						Yandere.ShoulderCamera.enabled = true;
						Yandere.ShoulderCamera.Noticed = true;
						Yandere.RPGCamera.enabled = false;
						Stop = true;
					}
				}
				else if (StudentID == 1 && Persona != PersonaType.Evil && Yandere.Mask == null && !WitnessedWeapon)
				{
					Debug.Log("We are now determining what Senpai saw...");
					if (Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						GameOverCause = GameOverType.Insanity;
					}
					else if (Witnessed == StudentWitnessType.WeaponAndBlood)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						GameOverCause = GameOverType.Weapon;
					}
					else if (Witnessed == StudentWitnessType.WeaponAndInsanity)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						GameOverCause = GameOverType.Insanity;
					}
					else if (Witnessed == StudentWitnessType.BloodAndInsanity)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						GameOverCause = GameOverType.Insanity;
					}
					else if (Witnessed == StudentWitnessType.Weapon)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						GameOverCause = GameOverType.Weapon;
					}
					else if (Witnessed == StudentWitnessType.Blood)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("senpaiBloodReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						GameOverCause = GameOverType.Blood;
					}
					else if (Witnessed == StudentWitnessType.Insanity)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						GameOverCause = GameOverType.Insanity;
					}
					else if (Witnessed == StudentWitnessType.Lewd || Witnessed == StudentWitnessType.Poisoning)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("senpaiLewdReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						GameOverCause = GameOverType.Lewd;
					}
					else if (Witnessed == StudentWitnessType.Stalking)
					{
						if (Concern < 5)
						{
							Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, Concern, 4.5f);
						}
						else
						{
							if (Male)
							{
								CharacterAnimation.CrossFade("senpaiCreepyReaction_00");
							}
							else
							{
								CharacterAnimation.CrossFade(ScaredAnim);
							}
							GameOverCause = GameOverType.Stalking;
						}
						Witnessed = StudentWitnessType.None;
					}
					else if (Witnessed == StudentWitnessType.Corpse)
					{
						if (Corpse.Student.Rival)
						{
							Subtitle.Speaker = this;
							Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 1, 5f);
							Debug.Log("Senpai is reacting to Osana's corpse with a unique subtitle.");
						}
						else
						{
							Subtitle.UpdateLabel(SubtitleType.SenpaiCorpseReaction, 1, 5f);
						}
					}
					else if (Witnessed == StudentWitnessType.Violence)
					{
						if (Male)
						{
							CharacterAnimation.CrossFade("senpaiFightReaction_00");
						}
						else
						{
							CharacterAnimation.CrossFade(ScaredAnim);
						}
						GameOverCause = GameOverType.Violence;
						Concern = 5;
					}
					else
					{
						Debug.Log("Senpai witnessed...nothing?!");
					}
					if (Concern == 5)
					{
						if (Male)
						{
							CharacterAnimation["scaredFace_00"].weight = 0f;
						}
						CharacterAnimation[AngryFaceAnim].weight = 0f;
						Yandere.ShoulderCamera.enabled = true;
						Yandere.ShoulderCamera.Noticed = true;
						Yandere.RPGCamera.enabled = false;
						Stop = true;
					}
				}
				else if (StudentID == 41 && !StudentManager.Eighties)
				{
					Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
				}
				else if (RepeatReaction)
				{
					if (!StudentManager.Eighties && StudentID == 48 && TaskPhase == 4 && Yandere.Armed && Yandere.EquippedWeapon.WeaponID == 12)
					{
						Subtitle.CustomText = "Is that dumbbell for me? Drop it over here!";
						Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
					}
					else if (!StudentManager.Eighties && StudentID == 50 && TaskPhase == 4 && Yandere.Armed && Yandere.EquippedWeapon.WeaponID == 24)
					{
						Subtitle.CustomText = "Are you going to use that pipe wrench to fix the training dummy?";
						Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
					}
					else
					{
						Subtitle.UpdateLabel(SubtitleType.RepeatReaction, 1, 3f);
						RepeatReaction = false;
					}
				}
				else if (Club != ClubType.Delinquent)
				{
					if (Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
					{
						Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodAndInsanityReaction, 1, 3f);
					}
					else if (Witnessed == StudentWitnessType.WeaponAndBlood)
					{
						Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodReaction, 1, 3f);
					}
					else if (Witnessed == StudentWitnessType.WeaponAndInsanity)
					{
						Subtitle.UpdateLabel(SubtitleType.WeaponAndInsanityReaction, 1, 3f);
					}
					else if (Witnessed == StudentWitnessType.BloodAndInsanity)
					{
						Subtitle.UpdateLabel(SubtitleType.BloodAndInsanityReaction, 1, 3f);
					}
					else if (Witnessed == StudentWitnessType.Weapon)
					{
						Debug.Log("Witnessed a weapon. That weapon's ID is: " + WeaponWitnessed);
						Subtitle.StudentID = StudentID;
						if (PlayerHeldBloodyWeapon)
						{
							Subtitle.CustomText = "Why is that thing covered in blood?! Did you hurt someone?!";
							Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
							PlayerHeldBloodyWeapon = false;
						}
						else
						{
							Subtitle.UpdateLabel(SubtitleType.WeaponReaction, WeaponWitnessed, 3f);
						}
					}
					else if (Witnessed == StudentWitnessType.Blood)
					{
						if (!Bloody)
						{
							Subtitle.UpdateLabel(SubtitleType.BloodReaction, 1, 3f);
						}
						else
						{
							Subtitle.UpdateLabel(SubtitleType.WetBloodReaction, 1, 3f);
							Witnessed = StudentWitnessType.None;
							Witness = false;
						}
					}
					else if (Witnessed == StudentWitnessType.Insanity)
					{
						Subtitle.UpdateLabel(SubtitleType.InsanityReaction, 1, 3f);
					}
					else if (Witnessed == StudentWitnessType.Lewd)
					{
						Subtitle.UpdateLabel(SubtitleType.LewdReaction, 1, 3f);
					}
					else if (Witnessed == StudentWitnessType.CleaningItem)
					{
						Subtitle.UpdateLabel(SubtitleType.SuspiciousReaction, 0, 5f);
					}
					else if (Witnessed == StudentWitnessType.Suspicious)
					{
						Subtitle.UpdateLabel(SubtitleType.SuspiciousReaction, 1, 5f);
					}
					else if (Witnessed == StudentWitnessType.Corpse)
					{
						Debug.Log(Name + " is currently reacting to the corpse of " + Corpse.Student.Name + " and is deciding what subtitle to use.");
						if (!StudentManager.Eighties && StudentID == StudentManager.ObstacleID && Corpse.Student.Rival)
						{
							Subtitle.Speaker = this;
							Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 1, 5f);
							Debug.Log("Raibaru is reacting to Osana's corpse with a unique subtitle.");
						}
						else if (!StudentManager.Eighties && StudentID == 11 && Corpse.StudentID == StudentManager.ObstacleID)
						{
							Subtitle.Speaker = this;
							Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 1, 5f);
							Debug.Log("Osana is reacting to Raibaru's corpse with a unique subtitle.");
						}
						else if (!StudentManager.Eighties && StudentID > 1 && StudentID < 4 && Corpse.StudentID > 1 && Corpse.StudentID < 4)
						{
							Subtitle.Speaker = this;
							Subtitle.CustomText = "Sister?! What's wrong?! Are you hurt?!";
							Subtitle.UpdateLabel(SubtitleType.Custom, 1, 5f);
							Debug.Log("A Basu sister is reacting to her sister's death with a unique subtitle.");
						}
						else if (Club == ClubType.Council)
						{
							if (StudentID == 86)
							{
								Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 1, 5f);
							}
							else if (StudentID == 87)
							{
								Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 2, 5f);
							}
							else if (StudentID == 88)
							{
								Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 3, 5f);
							}
							else if (StudentID == 89)
							{
								Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 4, 5f);
							}
						}
						else if (Persona == PersonaType.Evil)
						{
							Subtitle.UpdateLabel(SubtitleType.EvilCorpseReaction, 1, 5f);
						}
						else if (WitnessedMindBrokenMurder)
						{
							Subtitle.CustomText = "This can't be happening...";
							Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
						}
						else if (!Corpse.Choking)
						{
							Subtitle.UpdateLabel(SubtitleType.CorpseReaction, 0, 5f);
						}
						else
						{
							Subtitle.UpdateLabel(SubtitleType.CorpseReaction, 1, 5f);
						}
					}
					else if (Witnessed == StudentWitnessType.Interruption)
					{
						if (StudentID == 11)
						{
							Subtitle.UpdateLabel(SubtitleType.InterruptionReaction, 1, 5f);
						}
						else
						{
							Subtitle.UpdateLabel(SubtitleType.InterruptionReaction, 2, 5f);
						}
					}
					else if (Witnessed == StudentWitnessType.Eavesdropping)
					{
						if (StudentID == 10 || (StudentManager.Eighties && Rival))
						{
							Subtitle.UpdateLabel(SubtitleType.RivalEavesdropReaction, 0, 9f);
							Hesitation = 0.6f;
						}
						else if (Rival)
						{
							Subtitle.UpdateLabel(SubtitleType.RivalEavesdropReaction, DateGlobals.Week, 9f);
							Hesitation = 0.6f;
						}
						else if (EventInterrupted)
						{
							Subtitle.UpdateLabel(SubtitleType.EventEavesdropReaction, 1, 5f);
							EventInterrupted = false;
						}
						else
						{
							Subtitle.UpdateLabel(SubtitleType.EavesdropReaction, 1, 5f);
						}
					}
					else if (Witnessed == StudentWitnessType.Pickpocketing)
					{
						Subtitle.UpdateLabel(PickpocketSubtitleType, 1, 5f);
					}
					else if (Witnessed == StudentWitnessType.Violence)
					{
						Subtitle.UpdateLabel(SubtitleType.ViolenceReaction, 5, 5f);
					}
					else if (Witnessed == StudentWitnessType.Poisoning)
					{
						if (Yandere.TargetBento != null)
						{
							if (Yandere.TargetBento.StudentID != StudentID)
							{
								Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 1, 5f);
							}
							else
							{
								Debug.Log(Name + " witnessed their own bento being poisoned.");
								Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 2, 5f);
								NotEating = true;
								if (Clock.Period == 3)
								{
									Phase++;
									Pathfinding.target = Destinations[Phase];
									CurrentDestination = Destinations[Phase];
								}
							}
						}
						else
						{
							Debug.Log("Player was caught poisoning a bento that is a part of an event.");
							if (StudentID == 11)
							{
								Debug.Log("Osana witnessed it.");
								if (StudentManager.Portal.GetComponent<PortalScript>().OsanaEvent.Bentos[1].GetComponent<BentoScript>().BeingPoisoned)
								{
									Debug.Log("Osana witnessed Senpai's bento being poisoned.");
									StudentManager.Portal.GetComponent<PortalScript>().OsanaMondayLunchEvent.enabled = false;
									Subtitle.CustomText = "What are you doing to Senpai's bento?! Ugh, now I can't give it to him...";
									Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
									StudentManager.Students[1].MyBento.Tampered = false;
									StudentManager.Students[1].MyBento.Emetic = false;
									StudentManager.Students[1].Emetic = false;
								}
								else if (StudentManager.Portal.GetComponent<PortalScript>().OsanaEvent.Bentos[2].GetComponent<BentoScript>().BeingPoisoned)
								{
									Debug.Log("Osana witnessed her own bento being poisoned.");
									StudentManager.Portal.GetComponent<PortalScript>().OsanaMondayLunchEvent.enabled = false;
									Subtitle.CustomText = "What are you doing to my bento?! Well, now I'm not going to eat it...";
									Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
									Debug.Log("Osana will spend her lunchtime looking sad.");
									ScheduleBlocks[4].action = "Shamed";
									GetDestinations();
								}
							}
							else
							{
								Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 1, 5f);
							}
						}
					}
					else if (Witnessed == StudentWitnessType.SeveredLimb)
					{
						Subtitle.UpdateLabel(SubtitleType.LimbReaction, 0, 5f);
					}
					else if (Witnessed == StudentWitnessType.BloodyWeapon)
					{
						Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 0, 5f);
					}
					else if (Witnessed == StudentWitnessType.DroppedWeapon)
					{
						Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 0, 5f);
					}
					else if (Witnessed == StudentWitnessType.BloodPool)
					{
						Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 0, 5f);
					}
					else if (Witnessed == StudentWitnessType.HoldingBloodyClothing)
					{
						Subtitle.UpdateLabel(SubtitleType.HoldingBloodyClothingReaction, 0, 5f);
					}
					else if (Witnessed == StudentWitnessType.Theft)
					{
						if (StudentID == 2 && RingReact)
						{
							Subtitle.UpdateLabel(SubtitleType.TheftReaction, 1, 5f);
						}
						else
						{
							Subtitle.UpdateLabel(SubtitleType.TheftReaction, 0, 5f);
						}
					}
					else if (Witnessed == StudentWitnessType.Tutorial)
					{
						Subtitle.UpdateLabel(SubtitleType.TutorialReaction, 0, 10f);
					}
					else if (Witnessed == StudentWitnessType.Trespassing)
					{
						Subtitle.UpdateLabel(SubtitleType.TrespassReaction, 0, 10f);
					}
					else if (WitnessedSlave)
					{
						Subtitle.UpdateLabel(SubtitleType.SlaveReaction, 1, 3f);
					}
					else if (Club == ClubType.Council)
					{
						Subtitle.UpdateLabel(SubtitleType.HmmReaction, ClubMemberID, 3f);
						TemporarilyBlind = false;
					}
					else
					{
						Subtitle.UpdateLabel(SubtitleType.HmmReaction, 0, 3f);
					}
				}
				else if (Witnessed == StudentWitnessType.None)
				{
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentHmm, 0, 5f);
				}
				else if (Witnessed == StudentWitnessType.Corpse)
				{
					if (FoundEnemyCorpse)
					{
						Subtitle.UpdateLabel(SubtitleType.EvilDelinquentCorpseReaction, 1, 5f);
					}
					else if (Corpse.Student.Club == ClubType.Delinquent)
					{
						Subtitle.Speaker = this;
						Subtitle.UpdateLabel(SubtitleType.DelinquentFriendCorpseReaction, 1, 5f);
						FoundFriendCorpse = true;
					}
					else
					{
						Subtitle.Speaker = this;
						Subtitle.UpdateLabel(SubtitleType.DelinquentCorpseReaction, 1, 5f);
					}
				}
				else if (Witnessed == StudentWitnessType.Weapon && !Injured)
				{
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentWeaponReaction, 0, 3f);
				}
				else
				{
					Subtitle.Speaker = this;
					if (WitnessedLimb || WitnessedWeapon || WitnessedBloodPool || WitnessedBloodyWeapon)
					{
						Subtitle.UpdateLabel(SubtitleType.LimbReaction, 0, 5f);
					}
					else
					{
						Subtitle.UpdateLabel(SubtitleType.DelinquentReaction, 0, 5f);
						Debug.Log("A delinquent is reacting to Yandere-chan's behavior.");
					}
				}
				Reacted = true;
			}
			if (((Club == ClubType.Council && !DoNotShove) || Shovey) && DistanceToPlayer < 1.1f && !Yandere.Invisible && !EatingSnack && (Yandere.Armed || (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Dragging && !Yandere.CurrentRagdoll.Concealed)) && Prompt.InSight)
			{
				if (Yandere.Armed && !Yandere.EquippedWeapon.Suspicious && !WitnessedMurder && !WitnessedCorpse && !Yandere.Chased && Yandere.Chasers == 0)
				{
					Debug.Log(Name + " is shoving the player from this place in the code. 1");
					Shove();
				}
				else
				{
					Debug.Log("Calling ''Spray()'' from this part of the code. 3");
					Spray();
				}
			}
			return;
		}
		Alarm -= Time.deltaTime * 100f * (1f / Paranoia);
		if (StudentManager.CombatMinigame.Delinquent == null || StudentManager.CombatMinigame.Delinquent == this)
		{
			targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
		}
		else
		{
			targetRotation = Quaternion.LookRotation(new Vector3(StudentManager.CombatMinigame.Midpoint.position.x, base.transform.position.y, StudentManager.CombatMinigame.Midpoint.position.z) - base.transform.position);
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
		if (Yandere.DelinquentFighting && StudentManager.CombatMinigame.Delinquent != this)
		{
			if (StudentManager.CombatMinigame.Path < 4)
			{
				if (DistanceToPlayer < 1f)
				{
					MyController.Move(base.transform.forward * Time.deltaTime * -1f);
				}
				if (Vector3.Distance(base.transform.position, StudentManager.CombatMinigame.Delinquent.transform.position) < 1f)
				{
					MyController.Move(base.transform.forward * Time.deltaTime * -1f);
				}
				if (Yandere.enabled)
				{
					CheerTimer = Mathf.MoveTowards(CheerTimer, 0f, Time.deltaTime);
					if (CheerTimer == 0f)
					{
						Subtitle.Speaker = this;
						Subtitle.UpdateLabel(SubtitleType.DelinquentCheer, 0, 5f);
						CheerTimer = UnityEngine.Random.Range(2f, 3f);
					}
				}
				CharacterAnimation.CrossFade(RandomCheerAnim);
				if (CharacterAnimation[RandomCheerAnim].time >= CharacterAnimation[RandomCheerAnim].length)
				{
					RandomCheerAnim = CheerAnims[UnityEngine.Random.Range(0, CheerAnims.Length)];
				}
				ThreatPhase = 3;
				ThreatTimer = 0f;
				if (WitnessedMurder)
				{
					Injured = true;
				}
			}
			else
			{
				CharacterAnimation.CrossFade(IdleAnim, 5f);
				NoTalk = true;
			}
			return;
		}
		if (!Injured)
		{
			if (DistanceToPlayer > 5f + ThreatDistance && ThreatPhase < 4)
			{
				ThreatPhase = 3;
				ThreatTimer = 0f;
			}
			if (Yandere.Dumping || Yandere.SneakingShot)
			{
				return;
			}
			if (DistanceToPlayer > 1f && Patience > 0)
			{
				if (ThreatPhase == 1)
				{
					CharacterAnimation.CrossFade("delinquentShock_00");
					if (CharacterAnimation["delinquentShock_00"].time >= CharacterAnimation["delinquentShock_00"].length)
					{
						Subtitle.Speaker = this;
						Subtitle.UpdateLabel(SubtitleType.DelinquentThreatened, 0, 3f);
						CharacterAnimation.CrossFade("delinquentCombatIdle_00");
						ThreatTimer = 5f;
						ThreatPhase++;
					}
				}
				else if (ThreatPhase == 2)
				{
					ThreatTimer -= Time.deltaTime;
					if (ThreatTimer < 0f)
					{
						Subtitle.Speaker = this;
						Subtitle.UpdateLabel(SubtitleType.DelinquentTaunt, 0, 5f);
						ThreatTimer = 5f;
						ThreatPhase++;
					}
				}
				else if (ThreatPhase == 3)
				{
					ThreatTimer -= Time.deltaTime;
					if (ThreatTimer < 0f)
					{
						if (!NoTalk)
						{
							Subtitle.Speaker = this;
							Subtitle.UpdateLabel(SubtitleType.DelinquentCalm, 0, 5f);
						}
						CharacterAnimation.CrossFade(IdleAnim, 5f);
						ThreatTimer = 5f;
						ThreatPhase++;
					}
				}
				else
				{
					if (ThreatPhase != 4)
					{
						return;
					}
					ThreatTimer -= Time.deltaTime;
					if (ThreatTimer < 0f)
					{
						if (CurrentDestination != Destinations[Phase])
						{
							StopInvestigating();
						}
						FocusOnStudent = false;
						FocusOnYandere = false;
						Distracted = false;
						Threatened = false;
						Alarmed = false;
						Routine = true;
						NoTalk = false;
						IgnoreTimer = 5f;
						AlarmTimer = 0f;
					}
				}
				return;
			}
			if (!NoTalk)
			{
				Yandere.Shoved = false;
				Debug.Log("The combat minigame is now beginning.");
				Yandere.CustomThreshold = 5f;
				Yandere.WallToRight = false;
				Yandere.Direction = 2;
				Yandere.CheckForWall();
				if (Yandere.WallToRight)
				{
					Debug.Log("Trying to move Yandere-chan to the left.");
					Yandere.MyController.Move(Yandere.transform.right * Time.deltaTime * -1f);
				}
				Yandere.CustomThreshold = 0f;
				string text = "";
				if (!Male)
				{
					text = "Female_";
				}
				if (StudentID == 46)
				{
					CharacterAnimation.CrossFade("delinquentDrawWeapon_00");
				}
				if (StudentManager.CombatMinigame.Delinquent == null)
				{
					Yandere.CharacterAnimation.CrossFade("Yandere_CombatIdle");
					if (MyWeapon.transform.parent != ItemParent)
					{
						Debug.Log("The game is trying to tell " + StudentManager.CombatMinigame.Delinquent?.ToString() + "to draw out a weapon.");
						CharacterAnimation.CrossFade(text + "delinquentDrawWeapon_00");
					}
					else
					{
						CharacterAnimation.CrossFade("delinquentCombatIdle_00");
					}
					if ((Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Dragging && !Yandere.CurrentRagdoll.Concealed))
					{
						Yandere.EmptyHands();
					}
					if (Yandere.Pickpocketing)
					{
						Yandere.Caught = true;
						PickPocket.PickpocketMinigame.End();
					}
					Yandere.StopLaughing();
					Yandere.StopAiming();
					Yandere.Unequip();
					if (Yandere.YandereVision)
					{
						Yandere.YandereVision = false;
						Yandere.ResetYandereEffects();
					}
					if (Yandere.PickUp != null)
					{
						Yandere.EmptyHands();
					}
					Yandere.DelinquentFighting = true;
					Yandere.NearSenpai = false;
					Yandere.Degloving = false;
					Yandere.CanMove = false;
					Yandere.GloveTimer = 0f;
					FocusOnStudent = false;
					FocusOnYandere = false;
					Distracted = true;
					Fighting = true;
					ThreatTimer = 0f;
					StudentManager.CombatMinigame.Delinquent = this;
					StudentManager.CombatMinigame.enabled = true;
					StudentManager.CombatMinigame.StartCombat();
					SpeechLines.Stop();
					SpawnAlarmDisc();
					if (WitnessedMurder || WitnessedCorpse)
					{
						Subtitle.Speaker = this;
						Subtitle.UpdateLabel(SubtitleType.DelinquentAvenge, 0, 5f);
					}
					else if (!StudentManager.CombatMinigame.Practice)
					{
						Subtitle.Speaker = this;
						Subtitle.UpdateLabel(SubtitleType.DelinquentFight, 0, 5f);
					}
				}
				Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(Hips.transform.position.x, Yandere.transform.position.y, Hips.transform.position.z) - Yandere.transform.position);
				if (CharacterAnimation[text + "delinquentDrawWeapon_00"].time >= 0.5f)
				{
					MyWeapon.transform.parent = ItemParent;
					MyWeapon.transform.localEulerAngles = new Vector3(0f, 15f, 0f);
					MyWeapon.transform.localPosition = new Vector3(0.01f, 0f, 0f);
				}
				if (CharacterAnimation[text + "delinquentDrawWeapon_00"].time >= CharacterAnimation[text + "delinquentDrawWeapon_00"].length)
				{
					Threatened = false;
					Alarmed = false;
					base.enabled = false;
				}
				return;
			}
			ThreatTimer -= Time.deltaTime;
			if (ThreatTimer < 0f)
			{
				if (CurrentDestination != Destinations[Phase])
				{
					StopInvestigating();
				}
				Distracted = false;
				Threatened = false;
				Alarmed = false;
				Routine = true;
				NoTalk = false;
				IgnoreTimer = 5f;
				AlarmTimer = 0f;
			}
			return;
		}
		ThreatTimer += Time.deltaTime;
		if (!(ThreatTimer > 5f))
		{
			return;
		}
		DistanceToDestination = 100f;
		if (Yandere.CanMove)
		{
			if (!WitnessedMurder && !WitnessedCorpse)
			{
				Distracted = false;
				Threatened = false;
				EndAlarm();
			}
			else
			{
				Threatened = false;
				Alarmed = false;
				Injured = false;
				PersonaReaction();
			}
		}
	}

	private void UpdateBurning()
	{
		if (DistanceToPlayer < 1f && !Yandere.Shoved && !Yandere.Egg)
		{
			if (Yandere.PickUp != null && Yandere.PickUp.OpenFlame && !Yandere.Invisible)
			{
				Yandere.PotentiallyMurderousTimer = 1f;
			}
			PushYandereAway();
		}
		if (BurnTarget != Vector3.zero)
		{
			MoveTowardsTarget(BurnTarget);
		}
		if (CharacterAnimation[BurningAnim].time > CharacterAnimation[BurningAnim].length)
		{
			DeathType = DeathType.Burning;
			BecomeRagdoll();
		}
		else if (CharacterAnimation[BurningAnim].time > 8f)
		{
			CheckForWallInFront(2f);
			if (TooCloseToWall)
			{
				MyController.Move(base.transform.forward * Time.deltaTime * -0.5f);
			}
		}
	}

	private void UpdateSplashed()
	{
		CharacterAnimation.CrossFade(SplashedAnim);
		if (Yandere.Tripping)
		{
			targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
		}
		SplashTimer += Time.deltaTime;
		if (SplashTimer > 2f && SplashPhase == 1)
		{
			if (Gas)
			{
				Subtitle.Speaker = this;
				Subtitle.UpdateLabel(SplashSubtitleType, 5, 5f);
			}
			else if (DyedBrown)
			{
				Subtitle.Speaker = this;
				Subtitle.UpdateLabel(SplashSubtitleType, 7, 5f);
			}
			else if (Bloody)
			{
				Subtitle.Speaker = this;
				Subtitle.UpdateLabel(SplashSubtitleType, 3, 5f);
			}
			else
			{
				Subtitle.Speaker = this;
				Subtitle.UpdateLabel(SplashSubtitleType, 1, 5f);
			}
			CharacterAnimation[SplashedAnim].speed = 0.5f;
			SplashPhase++;
		}
		if (!(SplashTimer > 12f) || SplashPhase != 2 || StudentManager.KokonaTutorial)
		{
			return;
		}
		if (LightSwitch == null)
		{
			if (Gas)
			{
				Subtitle.Speaker = this;
				Subtitle.UpdateLabel(SplashSubtitleType, 6, 5f);
			}
			else if (Bloody)
			{
				Subtitle.Speaker = this;
				Subtitle.UpdateLabel(SplashSubtitleType, 4, 5f);
			}
			else
			{
				Subtitle.Speaker = this;
				Subtitle.UpdateLabel(SplashSubtitleType, 2, 5f);
			}
			SplashPhase++;
			if (!Male)
			{
				CurrentDestination = StudentManager.StrippingPositions[GirlID];
				Pathfinding.target = StudentManager.StrippingPositions[GirlID];
			}
			else
			{
				CurrentDestination = StudentManager.MaleStripSpot;
				Pathfinding.target = StudentManager.MaleStripSpot;
			}
		}
		else if (!LightSwitch.BathroomLight.activeInHierarchy)
		{
			if (LightSwitch.Panel.useGravity)
			{
				LightSwitch.Prompt.Hide();
				LightSwitch.Prompt.enabled = false;
				Prompt.Hide();
				Prompt.enabled = false;
			}
			Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 1, 5f);
			CurrentDestination = LightSwitch.ElectrocutionSpot;
			Pathfinding.target = LightSwitch.ElectrocutionSpot;
			Pathfinding.speed = WalkSpeed;
			BathePhase = -1;
			InDarkness = true;
		}
		else
		{
			if (!Bloody)
			{
				Subtitle.Speaker = this;
				Subtitle.UpdateLabel(SplashSubtitleType, 2, 5f);
			}
			else
			{
				Subtitle.Speaker = this;
				Subtitle.UpdateLabel(SplashSubtitleType, 4, 5f);
			}
			SplashPhase++;
			CurrentDestination = StudentManager.StrippingPositions[GirlID];
			Pathfinding.target = StudentManager.StrippingPositions[GirlID];
		}
		Debug.Log(Name + " is now running towards the locker room to wash up.");
		CharacterAnimation[WetAnim].weight = 1f;
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		Splashed = false;
	}

	private void UpdateTurningOffRadio()
	{
		if (Radio.On || (RadioPhase == 3 && Radio.transform.parent == null))
		{
			if (RadioPhase == 1)
			{
				targetRotation = Quaternion.LookRotation(new Vector3(Radio.transform.position.x, base.transform.position.y, Radio.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				RadioTimer += Time.deltaTime;
				if (RadioTimer > 3f)
				{
					if (Persona == PersonaType.PhoneAddict && !Phoneless)
					{
						SmartPhone.SetActive(value: true);
					}
					if (Persona == PersonaType.Protective || Hurry)
					{
						CharacterAnimation.CrossFade(RunAnim);
						Pathfinding.speed = 4f;
					}
					else
					{
						CharacterAnimation.CrossFade(WalkAnim);
					}
					CurrentDestination = Radio.transform;
					Pathfinding.target = Radio.transform;
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					RadioTimer = 0f;
					RadioPhase++;
				}
			}
			else if (RadioPhase == 2)
			{
				if (Vector3.Distance(base.transform.position, new Vector3(Radio.transform.position.x, base.transform.position.y, Radio.transform.position.z)) < 0.5f)
				{
					CharacterAnimation.CrossFade(RadioAnim);
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					SmartPhone.SetActive(value: false);
					RadioPhase++;
				}
			}
			else
			{
				if (RadioPhase != 3)
				{
					return;
				}
				targetRotation = Quaternion.LookRotation(new Vector3(Radio.transform.position.x, base.transform.position.y, Radio.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				RadioTimer += Time.deltaTime;
				if (RadioTimer > 4f)
				{
					if (Persona == PersonaType.PhoneAddict && !Phoneless)
					{
						SmartPhone.SetActive(value: true);
					}
					CurrentDestination = Destinations[Phase];
					Pathfinding.target = Destinations[Phase];
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					ForgetRadio();
				}
				else if (RadioTimer > 2f)
				{
					Radio.Victim = null;
					Radio.TurnOff();
				}
			}
		}
		else
		{
			if (RadioPhase < 100)
			{
				CharacterAnimation.CrossFade(IdleAnim);
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				RadioPhase = 100;
				RadioTimer = 0f;
			}
			targetRotation = Quaternion.LookRotation(new Vector3(Radio.transform.position.x, base.transform.position.y, Radio.transform.position.z) - base.transform.position);
			RadioTimer += Time.deltaTime;
			if (RadioTimer > 1f || Radio.transform.parent != null)
			{
				CurrentDestination = Destinations[Phase];
				Pathfinding.target = Destinations[Phase];
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				ForgetRadio();
			}
		}
	}

	private void UpdateVomiting()
	{
		if (VomitPhase != 0 && VomitPhase != 4)
		{
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
			MoveTowardsTarget(CurrentDestination.position);
		}
		if (VomitPhase == 0)
		{
			if (DistanceToDestination < 0.5f)
			{
				if (!Yandere.Armed && Yandere.PickUp == null)
				{
					Drownable = true;
					StudentManager.UpdateMe(StudentID);
				}
				if (VomitDoor != null)
				{
					VomitDoor.Prompt.enabled = false;
					VomitDoor.Prompt.Hide();
					VomitDoor.enabled = false;
				}
				CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				CharacterAnimation.CrossFade(VomitAnim);
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				VomitPhase++;
			}
		}
		else if (VomitPhase == 1)
		{
			if (CharacterAnimation[VomitAnim].time > 1f)
			{
				VomitEmitter.gameObject.SetActive(value: true);
				VomitPhase++;
			}
		}
		else if (VomitPhase == 2)
		{
			if (StudentManager.KokonaTutorial)
			{
				if (CharacterAnimation[VomitAnim].time > 13f)
				{
					CharacterAnimation[VomitAnim].speed = -1f;
				}
				else if (CharacterAnimation[VomitAnim].time < 1f)
				{
					CharacterAnimation[VomitAnim].speed = 1f;
				}
			}
			else if (CharacterAnimation[VomitAnim].time > 13f)
			{
				VomitEmitter.gameObject.SetActive(value: false);
				VomitPhase++;
			}
		}
		else if (VomitPhase == 3)
		{
			if (CharacterAnimation[VomitAnim].time >= CharacterAnimation[VomitAnim].length)
			{
				Drownable = false;
				StudentManager.UpdateMe(StudentID);
				WalkAnim = OriginalWalkAnim;
				CharacterAnimation.CrossFade(WalkAnim);
				if (Male)
				{
					StudentManager.GetMaleWashSpot(this);
					Pathfinding.target = StudentManager.MaleWashSpot;
					CurrentDestination = StudentManager.MaleWashSpot;
				}
				else
				{
					StudentManager.GetFemaleWashSpot(this);
					Pathfinding.target = StudentManager.FemaleWashSpot;
					CurrentDestination = StudentManager.FemaleWashSpot;
				}
				if (VomitDoor != null)
				{
					VomitDoor.Prompt.enabled = true;
					VomitDoor.enabled = true;
				}
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				Pathfinding.speed = WalkSpeed;
				DistanceToDestination = 100f;
				VomitPhase++;
			}
		}
		else if (VomitPhase == 4)
		{
			if (DistanceToDestination < 0.5f)
			{
				CharacterAnimation.CrossFade(WashFaceAnim);
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				VomitPhase++;
			}
		}
		else if (VomitPhase == 5 && CharacterAnimation[WashFaceAnim].time > CharacterAnimation[WashFaceAnim].length)
		{
			StopVomitting();
			ScheduleBlock obj = ScheduleBlocks[Phase + 1];
			obj.destination = "Seat";
			obj.action = "Sit";
			GetDestinations();
			Phase++;
			Pathfinding.target = Destinations[Phase];
			CurrentDestination = Destinations[Phase];
			CurrentAction = StudentActionType.SitAndTakeNotes;
			DistanceToDestination = 100f;
		}
	}

	private void StopVomitting()
	{
		CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		VomitEmitter.gameObject.SetActive(value: false);
		Prompt.Label[0].text = "     Talk";
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		Distracted = false;
		Drownable = false;
		Vomiting = false;
		Private = false;
		CanTalk = true;
		Routine = true;
		Emetic = false;
		VomitPhase = 0;
		StudentManager.UpdateMe(StudentID);
		WalkAnim = OriginalWalkAnim;
	}

	private void UpdateConfessing()
	{
		if (StudentID > 1 && StudentID != StudentManager.SuitorID)
		{
			if (ConfessPhase == 1)
			{
				if (DistanceToDestination < 0.5f)
				{
					StudentManager.ChangeSuitorRoutineOnFriday();
					CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					if (Male)
					{
						CharacterAnimation.CrossFade("insertNote_01");
						Cosmetic.MyRenderer.materials[Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
					}
					else
					{
						CharacterAnimation.CrossFade("f02_insertNote_00");
						Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
					}
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					Note.SetActive(value: true);
					ConfessPhase++;
				}
				else
				{
					CharacterAnimation.CrossFade(WalkAnim);
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
				}
			}
			else if (ConfessPhase == 2)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
				MoveTowardsTarget(CurrentDestination.position);
				string text = "";
				text = ((!Male) ? "f02_insertNote_00" : "insertNote_01");
				if (CharacterAnimation[text].time >= 9f)
				{
					Note.SetActive(value: false);
					ConfessPhase++;
				}
			}
			else if (ConfessPhase == 3)
			{
				string text2 = "";
				text2 = ((!Male) ? "f02_insertNote_00" : "insertNote_01");
				if (CharacterAnimation[text2].time >= CharacterAnimation[text2].length)
				{
					CurrentDestination = StudentManager.RivalConfessionSpot;
					Pathfinding.target = StudentManager.RivalConfessionSpot;
					Pathfinding.canSearch = true;
					Pathfinding.canMove = true;
					Pathfinding.speed = 4f;
					StudentManager.LoveManager.LeftNote = true;
					CharacterAnimation.CrossFade(SprintAnim);
					ConfessPhase++;
				}
			}
			else if (ConfessPhase == 4)
			{
				if (DistanceToDestination < 0.5f)
				{
					CharacterAnimation.CrossFade(IdleAnim);
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					ConfessPhase++;
				}
			}
			else if (ConfessPhase == 5)
			{
				if (DistanceToPlayer < 5f && (Yandere.Attacking || Yandere.NearBodies > 0))
				{
					Distracted = false;
				}
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
				if (!Male && !Alarmed)
				{
					CharacterAnimation[ShyAnim].weight = Mathf.Lerp(CharacterAnimation[ShyAnim].weight, 1f, Time.deltaTime);
				}
				MoveTowardsTarget(CurrentDestination.position);
			}
		}
		else if (ConfessPhase == 1)
		{
			string text3 = "";
			text3 = ((!Male) ? "f02_keepNote_00" : "keepNote_00");
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
			MoveTowardsTarget(CurrentDestination.position);
			if (CharacterAnimation[text3].time > 14f)
			{
				Note.SetActive(value: false);
			}
			else if ((double)CharacterAnimation[text3].time > 4.5)
			{
				Note.SetActive(value: true);
			}
			if (CharacterAnimation[text3].time >= CharacterAnimation[text3].length)
			{
				Debug.Log("Sprinting to confession tree.");
				CurrentDestination = StudentManager.SuitorConfessionSpot;
				Pathfinding.target = StudentManager.SuitorConfessionSpot;
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				Pathfinding.speed = 4f;
				Note.SetActive(value: false);
				CharacterAnimation.CrossFade(SprintAnim);
				ConfessPhase++;
			}
		}
		else if (ConfessPhase == 2)
		{
			if (DistanceToDestination < 0.5f)
			{
				if (Male)
				{
					CharacterAnimation.CrossFade("exhausted_01");
				}
				else
				{
					CharacterAnimation.CrossFade("f02_nervousLeftRight_00");
				}
				Pathfinding.canSearch = false;
				Pathfinding.canMove = false;
				ConfessPhase++;
			}
		}
		else if (ConfessPhase == 3)
		{
			if (Male)
			{
				CharacterAnimation.CrossFade("exhausted_01");
			}
			else
			{
				CharacterAnimation.CrossFade("f02_nervousLeftRight_00");
			}
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
			MoveTowardsTarget(CurrentDestination.position);
		}
	}

	private void UpdateMisc()
	{
		if (IgnoreTimer > 0f)
		{
			IgnoreTimer = Mathf.MoveTowards(IgnoreTimer, 0f, Time.deltaTime);
		}
		if (!Fleeing)
		{
			if (base.transform.position.z < -100f)
			{
				if (base.transform.position.y < -10f && StudentID > 1 && Phase > 1)
				{
					base.gameObject.SetActive(value: false);
				}
				return;
			}
			if (base.transform.position.y < -0.1f)
			{
				base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			}
			if (Dying || Distracted || WalkBack || Waiting || Guarding || InEvent || WitnessedMurder || WitnessedCorpse || Blind || SentHome || SentToLocker || TurnOffRadio || Wet || InvestigatingBloodPool || ReturningMisplacedWeapon || Yandere.Egg || StudentManager.Pose || ShoeRemoval.enabled || Drownable || Meeting || EatingSnack)
			{
				return;
			}
			if (StudentManager.MissionMode && (double)DistanceToPlayer < 0.5)
			{
				Yandere.Shutter.FaceStudent = this;
				Yandere.Shutter.Penalize();
			}
			if (((Club == ClubType.Council && !DoNotShove) || (Shovey && !Following)) && !WitnessedSomething)
			{
				if (DistanceToPlayer < 5f)
				{
					if (DistanceToPlayer < 2f)
					{
						StudentManager.TutorialWindow.ShowCouncilMessage = true;
					}
					if (Mathf.Abs(Vector3.Angle(-base.transform.forward, Yandere.transform.position - base.transform.position)) <= 45f && Yandere.Stance.Current != StanceType.Crouching && Yandere.Stance.Current != StanceType.Crawling && Yandere.CanMove && !Yandere.Invisible && (Yandere.h != 0f || Yandere.v != 0f) && (Yandere.Running || DistanceToPlayer < 2f))
					{
						if (Investigating)
						{
							StopInvestigating();
						}
						Debug.Log(Name + " was alarmed because Yandere-chan was moving nearby.");
						DistractionSpot = Yandere.transform.position;
						Alarm = 200f;
						TemporarilyBlind = true;
						FocusOnYandere = true;
						Routine = false;
						Pathfinding.canSearch = false;
						Pathfinding.canMove = false;
					}
				}
				if (DistanceToPlayer < 1.1f && !Yandere.Invisible && !EatingSnack && Mathf.Abs(Vector3.Angle(-base.transform.forward, Yandere.transform.position - base.transform.position)) > 45f && (Yandere.Armed || (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Dragging && !Yandere.CurrentRagdoll.Concealed)) && Prompt.InSight)
				{
					if (Yandere.Armed && !Yandere.EquippedWeapon.Suspicious && !WitnessedMurder && !Yandere.Chased && Yandere.Chasers == 0)
					{
						Debug.Log(Name + " is shoving the player from this place in the code. 2");
						Shove();
					}
					else
					{
						Debug.Log("Calling ''Spray()'' from this part of the code. 4");
						Spray();
					}
				}
			}
			if (((Club == ClubType.Council && !Spraying && !DoNotShove) || (Club == ClubType.Delinquent && !Injured && !RespectEarned && !Vomiting && !Emetic && !Headache && !Sedated && !Lethal) || (Shovey && !Spraying && !Following && !Meeting && !EatingSnack)) && (double)DistanceToPlayer < 0.5 && Yandere.CanMove && !Yandere.Invisible && (Yandere.h != 0f || Yandere.v != 0f) && !Yandere.Chased && Yandere.Chasers == 0)
			{
				if (Club == ClubType.Delinquent)
				{
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentShove, 0, 3f);
				}
				Debug.Log(Name + " is shoving the player from this place in the code. 3");
				Shove();
			}
		}
		else if (((Club == ClubType.Council && !DoNotShove) || Shovey) && DistanceToPlayer < 1.1f && !Yandere.Invisible && !EatingSnack && Mathf.Abs(Vector3.Angle(-base.transform.forward, Yandere.transform.position - base.transform.position)) > 45f && ((!IgnoringPettyActions && Yandere.Armed && Yandere.EquippedWeapon.Suspicious) || (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Dragging && !Yandere.CurrentRagdoll.Concealed)) && Prompt.InSight)
		{
			Debug.Log(Name + " will now decide whether to spray or shove the protagonist.");
			if (Yandere.Armed && !Yandere.EquippedWeapon.Suspicious && !WitnessedMurder && !Yandere.Chased && Yandere.Chasers == 0)
			{
				Debug.Log(Name + " is shoving the player from this place in the code. 4");
				Shove();
			}
			else
			{
				Debug.Log("Calling ''Spray()'' from this part of the code. 5");
				Spray();
			}
		}
	}

	private void LateUpdate()
	{
		if (StudentManager.DisableFarAnims && DistanceToPlayer >= (float)StudentManager.FarAnimThreshold && CharacterAnimation.cullingType != 0 && !WitnessCamera.Show && !ClubActivity)
		{
			CharacterAnimation.enabled = false;
		}
		else
		{
			CharacterAnimation.enabled = true;
		}
		if (EyeShrink > 0f)
		{
			if (EyeShrink > 1f)
			{
				EyeShrink = 1f;
			}
			LeftEye.localPosition = new Vector3(LeftEye.localPosition.x, LeftEye.localPosition.y, LeftEyeOrigin.z - EyeShrink * 0.01f);
			RightEye.localPosition = new Vector3(RightEye.localPosition.x, RightEye.localPosition.y, RightEyeOrigin.z + EyeShrink * 0.01f);
			LeftEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, LeftEye.localScale.z);
			RightEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, RightEye.localScale.z);
			PreviousEyeShrink = EyeShrink;
		}
		if (!Male)
		{
			if (Shy)
			{
				if (Routine)
				{
					if ((Phase == 2 && DistanceToDestination < 1f) || (Phase == 4 && DistanceToDestination < 1f) || (Actions[Phase] == StudentActionType.SitAndTakeNotes && DistanceToDestination < 1f) || (Actions[Phase] == StudentActionType.Clean && DistanceToDestination < 1f) || (Actions[Phase] == StudentActionType.Read && DistanceToDestination < 1f))
					{
						CharacterAnimation[ShyAnim].weight = Mathf.Lerp(CharacterAnimation[ShyAnim].weight, 0f, Time.deltaTime);
					}
					else
					{
						CharacterAnimation[ShyAnim].weight = Mathf.Lerp(CharacterAnimation[ShyAnim].weight, 1f, Time.deltaTime);
					}
				}
				else if (!Headache)
				{
					CharacterAnimation[ShyAnim].weight = Mathf.Lerp(CharacterAnimation[ShyAnim].weight, 0f, Time.deltaTime);
				}
			}
			if (BreastSize != 1f && (!BoobsResized || RightBreast.localScale.x != BreastSize))
			{
				RightBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
				LeftBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
				if (!Cosmetic.CustomEyes)
				{
					RightBreast.gameObject.name = "RightBreastRENAMED";
					LeftBreast.gameObject.name = "LeftBreastRENAMED";
				}
				BoobsResized = true;
			}
			if (StudentManager.Egg && SecurityCamera.activeInHierarchy)
			{
				Head.localScale = new Vector3(0f, 0f, 0f);
			}
			if (!Slave && Club == ClubType.Bully)
			{
				for (int i = 0; i < 4; i++)
				{
					if (Skirt[i] != null)
					{
						Transform transform = Skirt[i].transform;
						transform.localScale = new Vector3(transform.localScale.x, 2f / 3f, transform.localScale.z);
					}
				}
			}
			if (LongHair[0] != null && MyBento.gameObject.activeInHierarchy && MyBento.transform.parent != null)
			{
				LongHair[0].eulerAngles = new Vector3(Spine.eulerAngles.x, Spine.eulerAngles.y, Spine.eulerAngles.z);
				LongHair[0].RotateAround(LongHair[0].position, base.transform.right, 180f);
				if (LongHair[1] != null)
				{
					LongHair[1].eulerAngles = new Vector3(Spine.eulerAngles.x, Spine.eulerAngles.y, Spine.eulerAngles.z);
					LongHair[1].RotateAround(LongHair[1].position, base.transform.right, 180f);
				}
			}
		}
		if (Club == ClubType.Photography || ClubActivity || Actions[Phase] == StudentActionType.Meeting)
		{
			if (Routine && !InEvent && !Meeting && !GoAway)
			{
				if (!StudentManager.Eighties)
				{
					if ((DistanceToDestination < TargetDistance && Actions[Phase] == StudentActionType.SitAndSocialize) || (DistanceToDestination < TargetDistance && StudentID != 36 && Actions[Phase] == StudentActionType.Meeting) || (DistanceToDestination < TargetDistance && Actions[Phase] == StudentActionType.Sleuth && StudentManager.SleuthPhase != 2 && StudentManager.SleuthPhase != 3) || (Club == ClubType.Photography && ClubActivity))
					{
						BlendIntoSittingAnim();
					}
					else
					{
						BlendOutOfSittingAnim();
					}
				}
				else if (DistanceToDestination < TargetDistance && StudentID != 36 && CurrentAction == StudentActionType.Meeting)
				{
					BlendIntoSittingAnim();
				}
				else
				{
					BlendOutOfSittingAnim();
				}
			}
			else
			{
				BlendOutOfSittingAnim();
			}
		}
		if (DK)
		{
			Arm[0].localScale = new Vector3(2f, 2f, 2f);
			Arm[1].localScale = new Vector3(2f, 2f, 2f);
			Head.localScale = new Vector3(2f, 2f, 2f);
		}
		if (Fate > 0 && Clock.HourTime > TimeOfDeath)
		{
			Yandere.TargetStudent = this;
			StudentManager.Shinigami.Effect = Fate - 1;
			StudentManager.Shinigami.Attack();
			Yandere.TargetStudent = null;
			Fate = 0;
		}
		if (Yandere.BlackHole && DistanceToPlayer < 2.5f)
		{
			if (DeathScream != null)
			{
				UnityEngine.Object.Instantiate(DeathScream, base.transform.position + Vector3.up, Quaternion.identity);
			}
			BlackHoleEffect[0].enabled = true;
			BlackHoleEffect[1].enabled = true;
			BlackHoleEffect[2].enabled = true;
			CharacterAnimation[WetAnim].weight = 0f;
			DeathType = DeathType.EasterEgg;
			CharacterAnimation.Stop();
			Suck.enabled = true;
			BecomeRagdoll();
			Dying = true;
		}
		if (CameraReacting && (StudentManager.NEStairs.bounds.Contains(base.transform.position) || StudentManager.NWStairs.bounds.Contains(base.transform.position) || StudentManager.SEStairs.bounds.Contains(base.transform.position) || StudentManager.SWStairs.bounds.Contains(base.transform.position) || StudentManager.PoolStairs.bounds.Contains(base.transform.position)) && Spine != null)
		{
			Spine.LookAt(Yandere.Spine[0]);
			Head.LookAt(Yandere.Head);
		}
		if (DistanceToPlayer < 0.5f && !CameraReacting && !Struggling && !Yandere.Attacking && !Distracted && !Posing && CanSeeObject(Yandere.gameObject, Yandere.HeadPosition) && Yandere.CanMove && CurrentDestination != Yandere.transform)
		{
			PersonalSpaceTimer += Time.deltaTime;
			if (PersonalSpaceTimer > 4f)
			{
				Debug.Log(Name + " feels that the protagonist is invading their personal space.");
				if (WarningsGiven > 4)
				{
					Yandere.Shutter.FaceStudent = this;
					Yandere.Shutter.Penalize();
				}
				else
				{
					Subtitle.UpdateLabel(SubtitleType.HmmReaction, 0, 0f);
					Subtitle.UpdateLabel(SubtitleType.ProximityWarning, WarningsGiven, 5f);
					PersonalSpaceTimer = 0f;
				}
				WarningsGiven++;
			}
		}
		if (CurrentDestination == null)
		{
			if (Phase > 0)
			{
				Debug.Log(Name + "'s CurrentDestination became ''null'' for some reason.");
			}
			if (Destinations[Phase] == null)
			{
				Phase++;
			}
			CurrentDestination = Destinations[Phase];
			Pathfinding.target = CurrentDestination;
			if (Leaving)
			{
				CurrentDestination = StudentManager.Exit;
				Pathfinding.target = StudentManager.Exit;
			}
			if (Phase > 0)
			{
				Debug.Log("Phase is " + Phase + ". Changing " + Name + "'s CurrentDestination to: " + Destinations[Phase]);
			}
		}
		if (Shoving && CharacterAnimation[ShoveAnim].time < CharacterAnimation[ShoveAnim].length * 0.5f)
		{
			float num = 1f - CharacterAnimation[ShoveAnim].time / (CharacterAnimation[ShoveAnim].length * 0.5f);
			MyController.Move(base.transform.forward * (Time.deltaTime * -1f * num));
		}
	}

	public void CalculateReputationPenalty()
	{
		Debug.Log("Calculating reputation penalty now.");
		if ((Male && Yandere.Class.Seduction + Yandere.Class.SeductionBonus > 2) || Yandere.Class.Seduction + Yandere.Class.SeductionBonus > 4)
		{
			RepDeduction += RepLoss * 0.2f;
		}
		if (PlayerGlobals.Reputation < -33.33333f)
		{
			Debug.Log("Rep is low. Rep loss should be harsher.");
			RepDeduction -= RepLoss * 0.2f;
		}
		if (PlayerGlobals.Reputation > 33.33333f)
		{
			Debug.Log("Rep is high. Rep loss should be lower.");
			RepDeduction += RepLoss * 0.2f;
		}
		if (Friend)
		{
			RepDeduction += RepLoss * 0.2f;
		}
		if (PlayerGlobals.PantiesEquipped == 1)
		{
			Debug.Log("Wearing the less-rep-loss panties.");
			RepDeduction += RepLoss * 0.2f;
		}
		if (Yandere.Class.SocialBonus > 0)
		{
			RepDeduction += RepLoss * 0.2f;
		}
		ChameleonCheck();
		if (Chameleon)
		{
			Debug.Log("Chopping reputation loss in half!");
			RepLoss *= 0.5f;
		}
		if (Yandere.Persona == YanderePersonaType.Aggressive)
		{
			RepLoss *= 2f;
		}
		if (Club == ClubType.Bully)
		{
			RepLoss *= 2f;
		}
		if (Witnessed == StudentWitnessType.CleaningItem)
		{
			RepLoss *= 0.5f;
		}
		if (Club == ClubType.Delinquent)
		{
			RepDeduction = 0f;
			RepLoss = 0f;
		}
	}

	public void MoveTowardsTarget(Vector3 target)
	{
		if (Time.timeScale > 0.0001f && MyController.enabled)
		{
			Vector3 vector = target - base.transform.position;
			if (vector.sqrMagnitude > 1E-06f)
			{
				MyController.Move(vector * (Time.deltaTime * 5f / Time.timeScale));
			}
		}
	}

	private void LookTowardsTarget(Vector3 target)
	{
		_ = Time.timeScale;
		_ = 0.0001f;
	}

	public void AttackReaction()
	{
		Debug.Log(Name + " is being attacked.");
		FocusOnStudent = false;
		FocusOnYandere = false;
		Blind = true;
		if (ReportingMurderToSenpai)
		{
			StudentManager.Students[LovestruckTarget].Blind = false;
		}
		if (SeekingMedicine)
		{
			Debug.Log("Student was seeking medicine at the time of death.");
			StudentScript studentScript = StudentManager.Students[90];
			if (studentScript != null && studentScript.RetreivingMedicine)
			{
				Debug.Log("Nurse was retrieving medicine at the time of death.");
				studentScript.RetrieveMedicinePhase = 5;
				studentScript.MedicineTimer = 4f;
				StudentManager.UpdateStudents(studentScript.StudentID);
			}
		}
		if (TurnOffRadio)
		{
			ForgetRadio();
		}
		if (SolvingPuzzle)
		{
			DropPuzzle();
		}
		if (HorudaCollider != null)
		{
			HorudaCollider.gameObject.SetActive(value: false);
		}
		BountyCollider.SetActive(value: false);
		if (PhotoEvidence)
		{
			SmartPhone.GetComponent<SmartphoneScript>().enabled = true;
			SmartPhone.GetComponent<PromptScript>().enabled = true;
			SmartPhone.GetComponent<Rigidbody>().useGravity = true;
			SmartPhone.GetComponent<Collider>().enabled = true;
			SmartPhone.transform.parent = null;
			SmartPhone.layer = 15;
		}
		else
		{
			SmartPhone.SetActive(value: false);
		}
		if (!WitnessedMurder)
		{
			float f = Vector3.Angle(-base.transform.forward, Yandere.transform.position - base.transform.position);
			Yandere.AttackManager.Stealth = Mathf.Abs(f) <= 45f;
		}
		if (ReturningMisplacedWeapon)
		{
			Debug.Log(Name + " was in the process of returning a weapon when they were attacked.");
			DropMisplacedWeapon();
		}
		if (BloodPool != null)
		{
			Debug.Log(Name + "'s BloodPool was not null.");
			if (BloodPool.GetComponent<WeaponScript>() != null && BloodPool.GetComponent<WeaponScript>().Returner == this)
			{
				BloodPool.GetComponent<WeaponScript>().DoNotRelocate = true;
				BloodPool.GetComponent<WeaponScript>().Returner = null;
				BloodPool.GetComponent<WeaponScript>().Drop();
				BloodPool.GetComponent<WeaponScript>().enabled = true;
				BloodPool = null;
			}
		}
		if (!Male && Following)
		{
			StudentManager.TranqDetector.TranqCheck();
			CharacterAnimation["f02_smile_00"].weight = 0f;
			SmartPhone.SetActive(value: false);
			if (CharacterAnimation[ShyAnim] != null)
			{
				CharacterAnimation[ShyAnim].weight = 0f;
			}
			Shy = false;
		}
		if (WitnessCamera != null)
		{
			WitnessCamera.Show = false;
		}
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		Yandere.CharacterAnimation["f02_idleShort_00"].time = 0f;
		Yandere.CharacterAnimation["f02_swingA_00"].time = 0f;
		CharacterAnimation[WetAnim].weight = 0f;
		Yandere.HipCollider.enabled = true;
		Yandere.YandereVision = false;
		Yandere.Attacking = true;
		Yandere.CanMove = false;
		if (Yandere.Equipped > 0 && Yandere.EquippedWeapon.AnimID == 2)
		{
			Yandere.CharacterAnimation[Yandere.ArmedAnims[2]].weight = 0f;
		}
		if (DetectionMarker != null)
		{
			DetectionMarker.Tex.enabled = false;
		}
		EmptyHands();
		DropPlate();
		MyController.radius = 0f;
		if (Persona == PersonaType.PhoneAddict && !Phoneless)
		{
			Countdown.gameObject.SetActive(value: false);
			ChaseCamera.SetActive(value: false);
			if (StudentManager.ChaseCamera == ChaseCamera)
			{
				StudentManager.ChaseCamera = null;
			}
		}
		VomitEmitter.gameObject.SetActive(value: false);
		SpecialRivalDeathReaction = false;
		InvestigatingBloodPool = false;
		SeekingMedicine = false;
		Investigating = false;
		Pen.SetActive(value: false);
		EatingSnack = false;
		SpeechLines.Stop();
		SentHome = false;
		Attacked = true;
		Alarmed = false;
		Fleeing = false;
		Routine = false;
		ReadPhase = 0;
		Dying = true;
		Wet = false;
		Prompt.Hide();
		Prompt.enabled = false;
		if (Following)
		{
			Debug.Log("Yandere-chan's follower is being set to ''null''.");
			ParticleSystem.EmissionModule emission = Hearts.emission;
			emission.enabled = false;
			FollowCountdown.gameObject.SetActive(value: false);
			Yandere.Follower = null;
			Yandere.Followers--;
			Following = false;
		}
		if (Distracting || (DistractionTarget != null && DistractionTarget.Distracted))
		{
			Debug.Log("At the time of being attacked, " + Name + " was distracting " + DistractionTarget.Name + ".");
			DistractionTarget.TargetedForDistraction = false;
			DistractionTarget.Octodog.SetActive(value: false);
			DistractionTarget.Distracted = false;
			Distracting = false;
		}
		if (Teacher)
		{
			CheckForKnifeInInventory();
			if ((Yandere.Armed && Yandere.Class.PhysicalGrade + Yandere.Class.PhysicalBonus > 0 && Yandere.EquippedWeapon.Type == WeaponType.Knife) || (Yandere.Club == ClubType.MartialArts && Yandere.Armed && Yandere.EquippedWeapon.Type == WeaponType.Knife))
			{
				Debug.Log(Name + " has called the ''BeginStruggle'' function.");
				Pathfinding.target = Yandere.transform;
				CurrentDestination = Yandere.transform;
				Yandere.Attacking = false;
				Attacked = false;
				Fleeing = true;
				Dying = false;
				Persona = PersonaType.Heroic;
				BeginStruggle();
			}
			else
			{
				Debug.Log(Name + " just countered Yandere-chan.");
				Yandere.HeartRate.gameObject.SetActive(value: false);
				Yandere.ShoulderCamera.Counter = true;
				Yandere.ShoulderCamera.OverShoulder = false;
				Yandere.RPGCamera.enabled = false;
				Yandere.Senpai = base.transform;
				Yandere.Attacking = true;
				Yandere.CanMove = false;
				Yandere.Talking = false;
				Yandere.Noticed = true;
				Yandere.HUD.alpha = 0f;
				Yandere.TargetStudent = this;
			}
		}
		else if (Strength == 9 && !Emetic && !Lethal && !Sedated && !Headache)
		{
			Debug.Log("Time to decide how Raibaru should react.");
			if (!StudentManager.ChallengeManager.InvincibleRaibaru && Yandere.PhysicalGrade + Yandere.Class.PhysicalBonus > 0)
			{
				Debug.Log("Player meets the criteria to have a physical struggle with Raibaru.");
				Pathfinding.target = Yandere.transform;
				CurrentDestination = Yandere.transform;
				Yandere.Attacking = false;
				FocusOnYandere = false;
				Attacked = false;
				Fleeing = true;
				Dying = false;
				Persona = PersonaType.Heroic;
				BeginStruggle();
			}
			else
			{
				Debug.Log("Player does not meet the criteria to have a physical struggle with Raibaru.");
				if (!WitnessedMurder)
				{
					Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 3, 11f);
				}
				Yandere.CharacterAnimation.CrossFade("f02_moCounterA_00");
				Yandere.HeartRate.gameObject.SetActive(value: false);
				Yandere.ShoulderCamera.ObstacleCounter = true;
				Yandere.ShoulderCamera.OverShoulder = false;
				Yandere.RPGCamera.enabled = false;
				Yandere.Senpai = base.transform;
				Yandere.Attacking = true;
				Yandere.CanMove = false;
				Yandere.Talking = false;
				Yandere.Noticed = true;
				Yandere.HUD.alpha = 0f;
			}
		}
		else
		{
			Yandere.TargetStudent = this;
			if (Yandere.Armed)
			{
				if (Yandere.EquippedWeapon.Type == WeaponType.Garrote)
				{
					StudentManager.TranqDetector.GarroteAttack();
				}
				if (Yandere.SanityBased)
				{
					Yandere.AttackManager.Attack(Character, Yandere.EquippedWeapon);
				}
				if (!Yandere.AttackManager.Stealth)
				{
					Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
					SpawnAlarmDisc();
				}
			}
		}
		if (StudentManager.Reporter == this)
		{
			StudentManager.Reporter = null;
			if (ReportPhase == 0)
			{
				Debug.Log("A reporter died before being able to report a corpse. Corpse position reset.");
				StudentManager.CorpseLocation.position = Vector3.zero;
			}
		}
		if (StudentManager.BloodReporter == this)
		{
			Debug.Log(Name + " just set StudentManager.BloodReporter to ''null''.");
			StudentManager.BloodReporter = null;
		}
		if (Club == ClubType.Delinquent && MyWeapon != null && MyWeapon.transform.parent == ItemParent)
		{
			MyWeapon.transform.parent = null;
			MyWeapon.MyCollider.enabled = true;
			MyWeapon.Prompt.enabled = true;
			Rigidbody component = MyWeapon.GetComponent<Rigidbody>();
			component.constraints = RigidbodyConstraints.None;
			component.isKinematic = false;
			component.useGravity = true;
		}
		if (PhotoEvidence)
		{
			CameraFlash.SetActive(value: false);
			SmartPhone.SetActive(value: true);
		}
		if (BloodPool != null)
		{
			WeaponScript component2 = BloodPool.GetComponent<WeaponScript>();
			if (component2 != null && component2.Returner == this)
			{
				component2.Returner = null;
			}
		}
	}

	public void DropPlate()
	{
		if (MyPlate != null)
		{
			if (MyPlate.parent == RightHand)
			{
				ClubActivityPhase = 0;
				MyPlate.GetComponent<Rigidbody>().isKinematic = false;
				MyPlate.GetComponent<Rigidbody>().useGravity = true;
				MyPlate.GetComponent<Collider>().enabled = true;
				MyPlate.parent = null;
				MyPlate.gameObject.SetActive(value: true);
			}
			if (Distracting)
			{
				DistractionTarget.TargetedForDistraction = false;
				Distracting = false;
				IdleAnim = OriginalIdleAnim;
				WalkAnim = OriginalWalkAnim;
			}
		}
	}

	public void SenpaiNoticed()
	{
		Debug.Log("The ''SenpaiNoticed'' function has been called.");
		if (InvestigatingBloodPool)
		{
			Debug.Log("Was investigating something suspicious on the ground at the time.");
			if (BloodPool.GetComponent<WeaponScript>() != null)
			{
				Police.EndOfDay.Counselor.WeaponToReturn = BloodPool.GetComponent<WeaponScript>();
			}
			ForgetAboutBloodPool();
		}
		if (Yandere.Digging)
		{
			Yandere.StopDigging();
		}
		if (Yandere.Burying)
		{
			Yandere.StopBurying();
		}
		if (Yandere.Talking)
		{
			Yandere.StudentManager.DialogueWheel.End();
		}
		if (Yandere.Shutter.Snapping)
		{
			Debug.Log("THE SHUTTER WAS SNAPPING AT THE MOMENT THAT AYANO WAS NOTICED!");
			Yandere.Shutter.ResumeGameplay();
			Yandere.StopAiming();
			Yandere.Shutter.Snapping = false;
			Yandere.Shutter.Close = false;
			Yandere.Shutter.Timer = 0f;
		}
		Yandere.Stance.Current = StanceType.Standing;
		Yandere.CrawlTimer = 0f;
		Yandere.Uncrouch();
		Yandere.Noticed = true;
		if (WeaponToTakeAway != null)
		{
			Debug.Log("Yandere-chan was holding a weapon at the time she was caught.");
			if (Teacher && !Yandere.Attacking)
			{
				if (Yandere.EquippedWeapon.WeaponID == 23)
				{
					WeaponToTakeAway.transform.parent = null;
					WeaponToTakeAway.transform.position = WeaponToTakeAway.GetComponent<WeaponScript>().StartingPosition;
					WeaponToTakeAway.transform.eulerAngles = WeaponToTakeAway.GetComponent<WeaponScript>().StartingRotation;
					WeaponToTakeAway.GetComponent<WeaponScript>().Prompt.enabled = true;
					WeaponToTakeAway.GetComponent<WeaponScript>().enabled = true;
					WeaponToTakeAway.GetComponent<WeaponScript>().DoNotRelocate = true;
					WeaponToTakeAway.GetComponent<WeaponScript>().Drop();
					WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.useGravity = false;
					WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.isKinematic = true;
				}
				else
				{
					Debug.Log("That weapon was splattered with blood!");
					if (Yandere.EquippedWeapon.Bloody)
					{
						Police.WasHoldingBloodyWeapon = true;
					}
					Yandere.EquippedWeapon.Drop();
					WeaponToTakeAway.transform.position = StudentManager.WeaponBoxSpot.parent.position + new Vector3(0f, 1f, 0f);
					WeaponToTakeAway.transform.eulerAngles = new Vector3(0f, 90f, 0f);
					WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.useGravity = true;
					WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.isKinematic = false;
					WeaponToTakeAway.GetComponent<BoxCollider>().isTrigger = false;
				}
				Debug.Log("The weapon has been taken away...");
			}
		}
		if (Yandere.StolenObjectID == 1)
		{
			Debug.Log("Yandere-chan was spotted stealing cigarettes.");
			Yandere.Inventory.Cigs = false;
		}
		WeaponToTakeAway = null;
		if (!Yandere.Attacking)
		{
			Yandere.EmptyHands();
		}
		Yandere.Senpai = base.transform;
		if (Yandere.Aiming || Yandere.Throwing || Yandere.PreparingThrow)
		{
			Yandere.StopAiming();
		}
		Yandere.PauseScreen.Hint.MyPanel.alpha = 0f;
		Yandere.DetectionPanel.alpha = 0f;
		Yandere.RPGCamera.mouseSpeed = 0f;
		Yandere.LaughIntensity = 0f;
		Yandere.HUD.alpha = 0f;
		Yandere.EyeShrink = 0f;
		Yandere.Sanity = 100f;
		Yandere.ProgressBar.transform.parent.gameObject.SetActive(value: false);
		Yandere.StudentManager.CombatMinigame.RedVignette.alpha = 0f;
		Yandere.HeartRate.gameObject.SetActive(value: false);
		Yandere.Stance.Current = StanceType.Standing;
		Yandere.MainCamera.transform.parent = null;
		Yandere.SneakShotPhone.SetActive(value: false);
		Yandere.ShoulderCamera.OverShoulder = false;
		Yandere.DelinquentFighting = false;
		Yandere.Shutter.Blocked = false;
		Yandere.CleaningWeapon = false;
		Yandere.FakingReaction = false;
		Yandere.BreakingGlass = false;
		Yandere.YandereVision = false;
		Yandere.CannotRecover = true;
		Yandere.SneakingShot = false;
		Yandere.Police.Show = false;
		Yandere.Cauterizing = false;
		Yandere.FollowHips = false;
		Yandere.Poisoning = false;
		Yandere.Rummaging = false;
		Yandere.Laughing = false;
		Yandere.CanMove = false;
		Yandere.Dipping = false;
		Yandere.Mopping = false;
		Yandere.Talking = false;
		Yandere.Hiding = false;
		Yandere.Lewd = false;
		Yandere.Jukebox.GameOver();
		StudentManager.GameOverIminent = true;
		StudentManager.StopMoving();
		if (Teacher || StudentID == 1)
		{
			if (Club != ClubType.Council)
			{
				IdleAnim = OriginalIdleAnim;
			}
			if (Giggle != null)
			{
				ForgetGiggle();
			}
			AlarmTimer = 0f;
			GoAway = false;
			base.enabled = true;
			Stop = false;
		}
		if (StudentID == 1)
		{
			StudentManager.FountainAudio[0].Stop();
			StudentManager.FountainAudio[1].Stop();
		}
		if (StudentManager.Eighties)
		{
			Yandere.LoseGentleEyes();
		}
	}

	private void WitnessMurder()
	{
		Debug.Log(Name + " just realized that Yandere-chan is responsible for a murder!");
		if (Yandere.Mask == null)
		{
			Debug.Log("Alerts was incremented.");
			Yandere.Alerts++;
		}
		else
		{
			Debug.Log("Alerts was not incremented.");
		}
		if (Corpse == null)
		{
			Corpse = Yandere.CurrentRagdoll;
		}
		RespectEarned = false;
		if ((Fleeing && WitnessedBloodPool) || ReportPhase == 2)
		{
			WitnessedBloodyWeapon = false;
			WitnessedBloodPool = false;
			WitnessedSomething = false;
			WitnessedWeapon = false;
			WitnessedLimb = false;
			Fleeing = false;
			ReportPhase = 0;
		}
		CharacterAnimation[ScaredAnim].time = 0f;
		CameraFlash.SetActive(value: false);
		if (!Male)
		{
			CharacterAnimation["f02_smile_00"].weight = 0f;
		}
		WateringCan.SetActive(value: false);
		if (MyPlate != null && MyPlate.parent == RightHand)
		{
			ClubActivityPhase = 0;
			MyPlate.GetComponent<Rigidbody>().isKinematic = false;
			MyPlate.GetComponent<Rigidbody>().useGravity = true;
			MyPlate.GetComponent<Collider>().enabled = true;
			MyPlate.parent = null;
		}
		EmptyHands();
		MurdersWitnessed++;
		SpeechLines.Stop();
		WitnessedBloodyWeapon = false;
		WitnessedBloodPool = false;
		WitnessedSomething = false;
		WitnessedWeapon = false;
		WitnessedLimb = false;
		if (ReturningMisplacedWeapon)
		{
			DropMisplacedWeapon();
		}
		SpecialRivalDeathReaction = false;
		SenpaiWitnessingRivalDie = false;
		ReturningMisplacedWeapon = false;
		InvestigatingBloodPool = false;
		CameraReacting = false;
		FocusOnStudent = false;
		FocusOnYandere = false;
		TakingOutTrash = false;
		WitnessedMurder = true;
		Investigating = false;
		Distracting = false;
		EatingSnack = false;
		Threatened = false;
		Distracted = false;
		Reacted = false;
		Routine = false;
		Alarmed = true;
		NoTalk = false;
		Shy = false;
		Wet = false;
		if (OriginalPersona != PersonaType.Violent && Persona != OriginalPersona)
		{
			Debug.Log(Name + " is reverting back into their original Persona: " + OriginalPersona);
			Persona = OriginalPersona;
			SwitchBack = false;
			if (Persona == PersonaType.Heroic || Persona == PersonaType.Dangerous || Persona == PersonaType.Protective)
			{
				PersonaReaction();
			}
		}
		if (Persona == PersonaType.Spiteful && Yandere.TargetStudent != null)
		{
			Debug.Log("A Spiteful student witnessed a murder.");
			if ((Bullied && Yandere.TargetStudent.Club == ClubType.Bully) || Yandere.TargetStudent.Bullied)
			{
				Debug.Log("At this moment, a delinquent is reacting to the murder of a bully. 1");
				ScaredAnim = EvilWitnessAnim;
				Persona = PersonaType.Evil;
			}
		}
		if (Club == ClubType.Delinquent)
		{
			Debug.Log("A Delinquent witnessed murderous behavior, and now has to determine if he saw a bully's murder.");
			if (Yandere.Attacking && Yandere.TargetStudent != null && Yandere.TargetStudent.Club == ClubType.Bully)
			{
				Debug.Log("At this moment, " + Name + " is reacting to the murder of a bully. 2");
				ScaredAnim = EvilWitnessAnim;
				Persona = PersonaType.Evil;
				FoundEnemyCorpse = true;
			}
			if ((Yandere.Lifting && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Dragging && !Yandere.CurrentRagdoll.Concealed))
			{
				if (Yandere.CurrentRagdoll.Student.Club == ClubType.Bully || Yandere.CurrentRagdoll.Student.OriginalClub == ClubType.Bully)
				{
					Debug.Log("At this moment, a delinquent is reacting to the murder of a bully. 3");
					ScaredAnim = EvilWitnessAnim;
					Persona = PersonaType.Evil;
				}
				else
				{
					Debug.Log("Ain't a bully.");
				}
			}
		}
		if (Persona == PersonaType.Sleuth)
		{
			Debug.Log("A Sleuth is witnessing a murder.");
			if (Yandere.Attacking || Yandere.Struggling || (Yandere.Carrying && !Yandere.CurrentRagdoll.Concealed) || (Yandere.Lifting && !Yandere.CurrentRagdoll.Concealed) || (Yandere.PickUp != null && (bool)Yandere.PickUp.BodyPart))
			{
				if (!Sleuthing)
				{
					Debug.Log("A Sleuth is changing their Persona.");
					if (StudentID == 56)
					{
						Persona = PersonaType.Heroic;
					}
					else if (StudentManager.Eighties)
					{
						Persona = PersonaType.LandlineUser;
					}
					else
					{
						Persona = PersonaType.SocialButterfly;
					}
				}
				else if (StudentManager.Eighties)
				{
					Persona = PersonaType.LandlineUser;
				}
				else
				{
					Persona = PersonaType.SocialButterfly;
				}
			}
		}
		if (Persona == PersonaType.Heroic)
		{
			Yandere.Pursuer = this;
		}
		if (StudentID == 1 && Persona != PersonaType.Evil && Yandere.Mask == null)
		{
			if (!Yandere.Attacking && !Yandere.Struggling && !Yandere.Egg)
			{
				SenpaiNoticed();
			}
			Fleeing = false;
			EyeShrink = 0f;
			Yandere.Noticed = true;
			Yandere.Talking = false;
			CameraEffects.MurderWitnessed();
			Yandere.ShoulderCamera.OverShoulder = false;
			CharacterAnimation.CrossFade(ScaredAnim);
			if (Male)
			{
				CharacterAnimation["scaredFace_00"].weight = 1f;
			}
			Debug.Log("Senpai should be entereing his scared animation right now.");
		}
		else
		{
			SetOutlinesRed();
			SummonWitnessCamera();
			CameraEffects.MurderWitnessed();
			Witnessed = StudentWitnessType.Murder;
			if (Persona != PersonaType.Evil)
			{
				Police.Witnesses++;
			}
			if (Teacher)
			{
				StudentManager.Reporter = this;
			}
			if (Talking)
			{
				DialogueWheel.End();
				ParticleSystem.EmissionModule emission = Hearts.emission;
				emission.enabled = false;
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				Obstacle.enabled = false;
				Talk.enabled = false;
				Talking = false;
				Waiting = false;
				StudentManager.EnablePrompts();
			}
			if (Prompt.Label[0] != null && !StudentManager.EmptyDemon)
			{
				Prompt.Label[0].text = "     Talk";
				Prompt.HideButton[0] = true;
			}
		}
		if (Persona == PersonaType.TeachersPet && StudentManager.Reporter == null && !Police.Called)
		{
			StudentManager.CorpseLocation.position = Yandere.transform.position;
			StudentManager.LowerCorpsePosition();
			StudentManager.Reporter = this;
			ReportingMurder = true;
		}
		if (Following)
		{
			ParticleSystem.EmissionModule emission2 = Hearts.emission;
			emission2.enabled = false;
			FollowCountdown.gameObject.SetActive(value: false);
			Yandere.Follower = null;
			Yandere.Followers--;
			Following = false;
		}
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		if (!Phoneless && (Persona == PersonaType.PhoneAddict || Sleuthing))
		{
			SmartPhone.SetActive(value: true);
		}
		if (SmartPhone.activeInHierarchy)
		{
			if (Persona != PersonaType.Heroic && Persona != PersonaType.Dangerous && Persona != PersonaType.Evil && Persona != PersonaType.Violent && Persona != PersonaType.Coward && !Teacher)
			{
				Persona = PersonaType.PhoneAddict;
				if (!Sleuthing)
				{
					if (!StudentManager.Eighties)
					{
						SprintAnim = PhoneAnims[2];
					}
				}
				else
				{
					SprintAnim = SleuthReportAnim;
				}
			}
			else
			{
				SmartPhone.SetActive(value: false);
			}
		}
		StopPairing();
		if (Persona != PersonaType.Heroic)
		{
			AlarmTimer = 0f;
			Alarm = 0f;
		}
		if ((Teacher && Persona == PersonaType.Strict) || Persona == PersonaType.Heroic)
		{
			if (!Yandere.Chased)
			{
				Debug.Log("A teacher has reached ChaseYandere through WitnessMurder.");
				RetreivingMedicine = false;
				ChaseYandere();
			}
		}
		else
		{
			SpawnAlarmDisc();
		}
		if (!PinDownWitness && Persona != PersonaType.Evil && Persona != PersonaType.Protective)
		{
			StudentManager.Witnesses++;
			StudentManager.WitnessList[StudentManager.Witnesses] = this;
			StudentManager.PinDownCheck();
			PinDownWitness = true;
		}
		if (Persona == PersonaType.Violent)
		{
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
		}
		if (Yandere.Mask == null)
		{
			SawMask = false;
			if (Persona != PersonaType.Evil)
			{
				Grudge = true;
			}
		}
		else
		{
			SawMask = true;
		}
		StudentManager.UpdateMe(StudentID);
	}

	public void DropMisplacedWeapon()
	{
		if (BloodPool == null)
		{
			Debug.Log(Name + " was told to DropMisplacedWeapon(), but BloodPool was null!!");
		}
		WitnessedWeapon = false;
		InvestigatingBloodPool = false;
		ReturningMisplacedWeaponPhase = 0;
		ReturningMisplacedWeapon = false;
		BloodPool.GetComponent<WeaponScript>().Returner = null;
		BloodPool.GetComponent<WeaponScript>().DoNotRelocate = true;
		BloodPool.GetComponent<WeaponScript>().Drop();
		BloodPool.GetComponent<WeaponScript>().enabled = true;
		BloodPool = null;
		WalkAnim = BeforeReturnAnim;
	}

	private void ChaseYandere()
	{
		if (Persona == PersonaType.Coward || Persona == PersonaType.Evil || Persona == PersonaType.Fragile || Persona == PersonaType.Loner || Persona == PersonaType.LandlineUser)
		{
			Debug.Log("On second thought, " + Name + " will not chase Yandere-chan. She's using one of the cowardly Personas.");
			return;
		}
		Debug.Log(Name + " has begun to chase Yandere-chan.");
		CurrentDestination = Yandere.transform;
		Pathfinding.target = Yandere.transform;
		Pathfinding.speed = 5f;
		if (Yandere.Pursuer == null)
		{
			Yandere.Pursuer = this;
		}
		TargetDistance = 1f;
		AlarmTimer = 0f;
		Pursuing = true;
		Chasing = false;
		Fleeing = false;
		StudentManager.UpdateStudents();
	}

	private void PersonaReaction()
	{
		Debug.Log(Name + " just called PersonaReaction(). As of now, they are a: " + Persona.ToString() + ".");
		if (Persona == PersonaType.Strict && !Teacher)
		{
			Persona = PersonaType.Heroic;
		}
		if (Persona == PersonaType.Sleuth)
		{
			if (Sleuthing)
			{
				if (!Phoneless)
				{
					Persona = PersonaType.PhoneAddict;
					SmartPhone.SetActive(value: true);
				}
				else
				{
					Persona = PersonaType.Loner;
				}
			}
			else if (StudentManager.Eighties)
			{
				Persona = PersonaType.LandlineUser;
			}
			else if (!Phoneless)
			{
				Persona = PersonaType.SocialButterfly;
			}
			else
			{
				Persona = PersonaType.Loner;
			}
		}
		if ((Persona == PersonaType.PhoneAddict && Phoneless) || (Persona == PersonaType.SocialButterfly && Phoneless))
		{
			Persona = PersonaType.Loner;
		}
		if (Persona == PersonaType.Vengeful)
		{
			Persona = PersonaType.Heroic;
		}
		if (Persona == PersonaType.Violent && MyWeapon == null)
		{
			Persona = PersonaType.Heroic;
		}
		if (!Indoors && WitnessedMurder && !Rival)
		{
			Debug.Log(Name + "'s current Persona is: " + Persona);
			if ((Persona != PersonaType.Evil && Persona != PersonaType.Heroic && Persona != PersonaType.Coward && Persona != PersonaType.PhoneAddict && Persona != PersonaType.Protective && Persona != PersonaType.Violent) || Injured)
			{
				Debug.Log(Name + " is switching to the Loner Persona.");
				Persona = PersonaType.Loner;
			}
		}
		if (!WitnessedMurder)
		{
			if (Persona == PersonaType.Heroic)
			{
				SwitchBack = true;
				Persona = ((!(Corpse != null)) ? PersonaType.Loner : PersonaType.TeachersPet);
			}
			else if (Persona == PersonaType.Coward || Persona == PersonaType.Evil || Persona == PersonaType.Fragile)
			{
				Persona = PersonaType.Loner;
			}
			else if (Persona == PersonaType.Protective)
			{
				Debug.Log("Raibaru witnessed the corpse of " + Corpse.Student.Name + ", and is now switching to the Lovestruck Persona.");
				Persona = PersonaType.Lovestruck;
			}
			if (!StudentManager.Eighties && (StudentID == 2 || StudentID == 3) && Corpse != null && (Corpse.StudentID == 2 || Corpse.StudentID == 3))
			{
				Persona = PersonaType.Lovestruck;
			}
		}
		if (Persona == PersonaType.Loner || Persona == PersonaType.Spiteful)
		{
			Debug.Log(Name + " is looking in the Loner/Spiteful section of PersonaReaction() to decide what to do next.");
			if (Club == ClubType.Delinquent)
			{
				Debug.Log("A delinquent turned into a loner, and now he is fleeing.");
				if (Injured && WitnessedMurder)
				{
					Debug.Log("You won't get away with what you've done!");
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentInjuredFlee, 1, 3f);
				}
				else if (FoundFriendCorpse)
				{
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentFriendFlee, 1, 3f);
				}
				else if (FoundEnemyCorpse)
				{
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentEnemyFlee, 1, 3f);
				}
				else
				{
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentFlee, 1, 3f);
				}
			}
			else if (WitnessedMurder)
			{
				Subtitle.UpdateLabel(SubtitleType.LonerMurderReaction, 1, 3f);
			}
			else
			{
				Subtitle.UpdateLabel(SubtitleType.LonerCorpseReaction, 1, 3f);
			}
			if (Schoolwear > 0)
			{
				if (!Bloody)
				{
					Pathfinding.target = StudentManager.Exit;
					TargetDistance = 0f;
					Routine = false;
					Fleeing = true;
				}
				else
				{
					FleeWhenClean = true;
					TargetDistance = 1f;
					BatheFast = true;
				}
			}
			else
			{
				FleeWhenClean = true;
				if (!Bloody)
				{
					BathePhase = 5;
					GoChange();
				}
				else
				{
					CurrentDestination = StudentManager.FastBatheSpot;
					Pathfinding.target = StudentManager.FastBatheSpot;
					TargetDistance = 1f;
					BatheFast = true;
				}
			}
			if (Corpse != null && StudentID == 1 && Corpse.Student.Rival)
			{
				CurrentDestination = Corpse.Student.Hips;
				Pathfinding.target = Corpse.Student.Hips;
				SenpaiWitnessingRivalDie = true;
				IgnoringPettyActions = true;
				DistanceToDestination = 1f;
				WitnessRivalDiePhase = 3;
				Routine = false;
				TargetDistance = 0.5f;
			}
		}
		else if (Persona == PersonaType.TeachersPet)
		{
			if (WitnessedBloodPool || WitnessedLimb || WitnessedWeapon)
			{
				if (StudentManager.BloodReporter == null)
				{
					if (Club != ClubType.Delinquent && !Police.Called && !LostTeacherTrust)
					{
						StudentManager.BloodLocation.position = BloodPool.transform.position;
						StudentManager.LowerBloodPosition();
						Debug.Log(Name + " has become a ''blood reporter''.");
						StudentManager.BloodReporter = this;
						ReportingBlood = true;
						DetermineBloodLocation();
					}
					else
					{
						ReportingBlood = false;
					}
				}
			}
			else if (StudentManager.Reporter == null && !Police.Called && StudentManager.CorpseLocation != null)
			{
				if (Corpse != null)
				{
					StudentManager.CorpseLocation.position = Corpse.AllColliders[0].transform.position;
					StudentManager.LowerCorpsePosition();
				}
				Debug.Log(Name + " has become a ''reporter''.");
				StudentManager.Reporter = this;
				ReportingMurder = true;
				IgnoringPettyActions = true;
				DetermineCorpseLocation();
			}
			if (StudentManager.Reporter == this)
			{
				Debug.Log(Name + " is running to a teacher to report murder.");
				Pathfinding.target = StudentManager.Teachers[Class].transform;
				CurrentDestination = StudentManager.Teachers[Class].transform;
				TargetDistance = 2f;
				if (Club == ClubType.Council)
				{
					if (StudentID == 86)
					{
						Subtitle.UpdateLabel(SubtitleType.StrictReport, 1, 5f);
					}
					else if (StudentID == 87)
					{
						Subtitle.UpdateLabel(SubtitleType.CasualReport, 1, 5f);
					}
					else if (StudentID == 88)
					{
						Subtitle.UpdateLabel(SubtitleType.GraceReport, 1, 5f);
					}
					else if (StudentID == 89)
					{
						Subtitle.UpdateLabel(SubtitleType.EdgyReport, 1, 5f);
					}
				}
				else if (WitnessedMurder)
				{
					Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 1, 3f);
				}
				else if (WitnessedCorpse)
				{
					Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 1, 3f);
				}
			}
			else if (StudentManager.BloodReporter == this)
			{
				Debug.Log(Name + " is running to a teacher to report something.");
				DropPlate();
				Pathfinding.target = StudentManager.Teachers[Class].transform;
				CurrentDestination = StudentManager.Teachers[Class].transform;
				TargetDistance = 2f;
				if (WitnessedLimb)
				{
					Subtitle.UpdateLabel(SubtitleType.LimbReaction, 1, 3f);
				}
				else if (WitnessedBloodyWeapon)
				{
					Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 1, 3f);
				}
				else if (WitnessedBloodPool)
				{
					Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 1, 3f);
				}
				else if (WitnessedWeapon)
				{
					Subtitle.UpdateLabel(SubtitleType.PetWeaponReport, 1, 3f);
				}
			}
			else
			{
				Debug.Log(Name + " found something scary, and is now deciding what to do next.");
				if (Club == ClubType.Council)
				{
					if (WitnessedCorpse)
					{
						if (StudentManager.CorpseLocation.position == Vector3.zero)
						{
							StudentManager.CorpseLocation.position = Corpse.AllColliders[0].transform.position;
							AssignCorpseGuardLocations();
						}
						if (StudentID == 86)
						{
							Pathfinding.target = StudentManager.CorpseGuardLocation[1];
						}
						else if (StudentID == 87)
						{
							Pathfinding.target = StudentManager.CorpseGuardLocation[2];
						}
						else if (StudentID == 88)
						{
							Pathfinding.target = StudentManager.CorpseGuardLocation[3];
						}
						else if (StudentID == 89)
						{
							Pathfinding.target = StudentManager.CorpseGuardLocation[4];
						}
						CurrentDestination = Pathfinding.target;
					}
					else
					{
						Debug.Log("A student council member is being told to travel to ''BloodGuardLocation''.");
						if (StudentManager.BloodLocation.position == Vector3.zero)
						{
							StudentManager.BloodLocation.position = BloodPool.transform.position;
							AssignBloodGuardLocations();
						}
						if (StudentManager.BloodGuardLocation[1].position == Vector3.zero)
						{
							AssignBloodGuardLocations();
						}
						if (StudentID == 86)
						{
							Pathfinding.target = StudentManager.BloodGuardLocation[1];
						}
						else if (StudentID == 87)
						{
							Pathfinding.target = StudentManager.BloodGuardLocation[2];
						}
						else if (StudentID == 88)
						{
							Pathfinding.target = StudentManager.BloodGuardLocation[3];
						}
						else if (StudentID == 89)
						{
							Pathfinding.target = StudentManager.BloodGuardLocation[4];
						}
						CurrentDestination = Pathfinding.target;
						Guarding = true;
					}
				}
				else
				{
					Debug.Log(Name + " is considering whether or not to hide in their classroom...");
					if (Vector3.Distance(base.transform.position, Seat.position) < 2f)
					{
						Debug.Log("...but there is danger in their classroom, so they will flee the school instead.");
						Pathfinding.target = StudentManager.Exit;
						CurrentDestination = StudentManager.Exit;
					}
					else
					{
						PetDestination = UnityEngine.Object.Instantiate(EmptyGameObject, Seat.position + Seat.forward * -0.5f, Quaternion.identity).transform;
						Pathfinding.target = PetDestination;
						CurrentDestination = PetDestination;
					}
					if (Distracting)
					{
						if (DistractionTarget != null)
						{
							DistractionTarget.TargetedForDistraction = false;
						}
						ResumeDistracting = false;
						Distracting = false;
					}
					DropPlate();
				}
				if (WitnessedMurder)
				{
					Subtitle.UpdateLabel(SubtitleType.PetMurderReaction, 1, 3f);
				}
				else if (WitnessedCorpse)
				{
					Subtitle.UpdateLabel(SubtitleType.PetCorpseReaction, 1, 3f);
				}
				else if (WitnessedLimb)
				{
					Subtitle.UpdateLabel(SubtitleType.PetLimbReaction, 1, 3f);
				}
				else if (WitnessedBloodyWeapon)
				{
					Subtitle.UpdateLabel(SubtitleType.PetBloodyWeaponReaction, 1, 3f);
				}
				else if (WitnessedBloodPool)
				{
					Subtitle.UpdateLabel(SubtitleType.PetBloodReaction, 1, 3f);
				}
				else if (WitnessedWeapon)
				{
					Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 1, 3f);
				}
				TargetDistance = 1f;
				ReportingMurder = false;
				ReportingBlood = false;
			}
			Routine = false;
			Fleeing = true;
		}
		else if (Persona == PersonaType.Heroic || Persona == PersonaType.Protective)
		{
			Debug.Log("A Heroic student is now running PersonaReaction()...");
			Headache = false;
			if (!Yandere.Chased)
			{
				StudentManager.PinDownCheck();
				if (!StudentManager.PinningDown)
				{
					Debug.Log(Name + "'s ''Flee'' was set to ''true'' because Hero persona reaction was called.");
					if (Persona == PersonaType.Protective)
					{
						Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
						Debug.Log("You won't get away with this!");
						Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 2, 3f);
					}
					else if (Persona != PersonaType.Violent)
					{
						Subtitle.UpdateLabel(SubtitleType.HeroMurderReaction, 3, 3f);
					}
					else if (Defeats > 0)
					{
						Subtitle.Speaker = this;
						Subtitle.UpdateLabel(SubtitleType.DelinquentResume, 3, 3f);
					}
					else
					{
						Subtitle.Speaker = this;
						Subtitle.UpdateLabel(SubtitleType.DelinquentMurderReaction, 3, 3f);
					}
					Pathfinding.target = Yandere.transform;
					Pathfinding.speed = 5f;
					Yandere.Pursuer = this;
					Yandere.Chased = true;
					TargetDistance = 1f;
					StudentManager.UpdateStudents();
					Routine = false;
					Fleeing = true;
				}
			}
		}
		else if (Persona == PersonaType.Coward || Persona == PersonaType.Fragile)
		{
			Debug.Log(Name + " just set their destination to themself.");
			CurrentDestination = base.transform;
			Pathfinding.target = base.transform;
			Subtitle.UpdateLabel(SubtitleType.CowardMurderReaction, 1, 5f);
			Routine = false;
			Fleeing = true;
		}
		else if (Persona == PersonaType.Evil)
		{
			Debug.Log("This character just set their destination to themself.");
			CurrentDestination = base.transform;
			Pathfinding.target = base.transform;
			Subtitle.UpdateLabel(SubtitleType.EvilMurderReaction, 1, 5f);
			Routine = false;
			Fleeing = true;
		}
		else if (Persona == PersonaType.SocialButterfly)
		{
			Debug.Log("A social butterfly is calling PersonaReaction().");
			StudentManager.HidingSpots.List[StudentID].position = StudentManager.PopulationManager.GetCrowdedLocation();
			CurrentDestination = StudentManager.HidingSpots.List[StudentID];
			Pathfinding.target = StudentManager.HidingSpots.List[StudentID];
			Subtitle.UpdateLabel(SubtitleType.SocialDeathReaction, 1, 5f);
			TargetDistance = 2f;
			ReportPhase = 1;
			Routine = false;
			Fleeing = true;
			Halt = true;
		}
		else if (Persona == PersonaType.Lovestruck)
		{
			Debug.Log(Name + " is now calling the the Lovestruck Persona code.");
			if (Corpse != null)
			{
				Debug.Log(Name + " witnessed the corpse of: " + Corpse.Student.Name);
			}
			bool flag = false;
			if (!WitnessedMurder && Corpse != null && (Corpse.Student.Rival || (!StudentManager.Eighties && StudentID == 11 && Corpse.StudentID == StudentManager.ObstacleID) || (!StudentManager.Eighties && StudentID > 1 && StudentID < 4 && Corpse.StudentID > 1 && Corpse.StudentID < 4)))
			{
				flag = true;
			}
			if (flag)
			{
				Debug.Log(Name + " is going to have a special reaction to the corpse of " + Corpse.Student.Name);
				CurrentDestination = Corpse.Student.Hips;
				Pathfinding.target = Corpse.Student.Hips;
				CorpseHead = Corpse.Student.Head;
				StudentToMourn = Corpse.Student;
				SpecialRivalDeathReaction = true;
				IgnoringPettyActions = true;
				WitnessRivalDiePhase = 1;
				Routine = false;
				TargetDistance = 0.5f;
				CorpseID = Corpse.StudentID;
			}
			else
			{
				if (LovestruckTarget == 0)
				{
					LovestruckTarget = 1;
				}
				if (!StudentManager.Students[LovestruckTarget].WitnessedMurder)
				{
					Debug.Log(Name + "'s new destination should be " + StudentManager.Students[LovestruckTarget].Name);
					CurrentDestination = StudentManager.Students[LovestruckTarget].transform;
					Pathfinding.target = StudentManager.Students[LovestruckTarget].transform;
					StudentManager.Students[LovestruckTarget].TargetedForDistraction = true;
					TargetDistance = 1f;
					ReportPhase = 1;
				}
				else
				{
					Debug.Log(Name + "'s new destination should be the exit of the school.");
					CurrentDestination = StudentManager.Exit;
					Pathfinding.target = StudentManager.Exit;
					TargetDistance = 0f;
					ReportPhase = 3;
				}
				if (LovestruckTarget == 1)
				{
					Subtitle.UpdateLabel(SubtitleType.LovestruckDeathReaction, 0, 5f);
				}
				else if (WitnessedMindBrokenMurder)
				{
					Subtitle.CustomText = "This can't be happening...";
					Subtitle.UpdateLabel(SubtitleType.Custom, 1, 5f);
				}
				else
				{
					Subtitle.UpdateLabel(SubtitleType.LovestruckDeathReaction, 1, 5f);
				}
				DistanceToDestination = 100f;
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				Routine = false;
				Fleeing = true;
				Halt = true;
			}
		}
		else if (Persona == PersonaType.Dangerous)
		{
			Debug.Log("A student council member's PersonaReaction has been triggered.");
			if (WitnessedMurder)
			{
				Debug.Log("A student council member's ''WitnessedMurder'' has been set to ''true''.");
				if (!Yandere.DelinquentFighting)
				{
					Subtitle.UpdateLabel(SubtitleType.Chasing, ClubMemberID, 5f);
				}
				Pathfinding.target = Yandere.transform;
				Pathfinding.speed = 5f;
				Yandere.Chased = true;
				TargetDistance = 1f;
				StudentManager.UpdateStudents();
				Routine = false;
				Fleeing = true;
				Halt = true;
			}
			else
			{
				Debug.Log("A student council member has transformed into a Teacher's Pet.");
				Persona = PersonaType.TeachersPet;
				PersonaReaction();
			}
		}
		else if (Persona == PersonaType.PhoneAddict)
		{
			Debug.Log(Name + " is executing the Phone Addict Persona code.");
			CurrentDestination = StudentManager.Exit;
			Pathfinding.target = StudentManager.Exit;
			if (!StudentManager.Eighties)
			{
				Countdown.gameObject.SetActive(value: true);
				if (StudentManager.ChaseCamera == null)
				{
					StudentManager.ChaseCamera = ChaseCamera;
					ChaseCamera.SetActive(value: true);
				}
			}
			Routine = false;
			Fleeing = true;
		}
		else if (Persona == PersonaType.Violent)
		{
			Debug.Log(Name + ", a delinquent, is currently in the ''Violent'' part of PersonaReaction()");
			if (WitnessedMurder)
			{
				if (!Yandere.Chased)
				{
					StudentManager.PinDownCheck();
					if (!StudentManager.PinningDown)
					{
						Debug.Log(Name + " began fleeing because Violent persona reaction was called.");
						if (Defeats > 0)
						{
							Subtitle.Speaker = this;
							Subtitle.UpdateLabel(SubtitleType.DelinquentResume, 3, 3f);
						}
						else
						{
							Subtitle.Speaker = this;
							Subtitle.UpdateLabel(SubtitleType.DelinquentMurderReaction, 3, 3f);
						}
						Pathfinding.target = Yandere.transform;
						Pathfinding.canSearch = true;
						Pathfinding.canMove = true;
						Pathfinding.speed = 5f;
						Yandere.Pursuer = this;
						Yandere.Chased = true;
						TargetDistance = 1f;
						StudentManager.UpdateStudents();
						Routine = false;
						Fleeing = true;
					}
				}
			}
			else
			{
				Debug.Log("A delinquent reached the ''Flee'' protocol through PersonaReaction().");
				if (FoundFriendCorpse)
				{
					Debug.Log("Found Friend Corpse.");
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentFriendFlee, 1, 3f);
				}
				else
				{
					Debug.Log("Didn't Find Friend Corpse.");
					Subtitle.Speaker = this;
					Subtitle.UpdateLabel(SubtitleType.DelinquentFlee, 1, 3f);
				}
				CurrentDestination = StudentManager.Exit;
				Pathfinding.target = StudentManager.Exit;
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
				TargetDistance = 0f;
				Routine = false;
				Fleeing = true;
			}
		}
		else if (Persona == PersonaType.Strict)
		{
			if (Yandere.Pursuer == this)
			{
				Debug.Log("This teacher is now pursuing Yandere-chan.");
			}
			if (WitnessedMurder)
			{
				if (Yandere.Pursuer == this)
				{
					Debug.Log("A teacher is now reacting to the sight of murder.");
					Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 3, 3f);
					Pathfinding.target = Yandere.transform;
					Pathfinding.speed = 5f;
					Yandere.Chased = true;
					TargetDistance = 1f;
					StudentManager.UpdateStudents();
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
					Routine = false;
					Fleeing = true;
				}
				else if (!Yandere.Chased)
				{
					if (Yandere.FightHasBrokenUp)
					{
						Debug.Log("This teacher is returning to normal after witnessing a SC member break up a fight.");
						WitnessedMurder = false;
						PinDownWitness = false;
						Alarmed = false;
						Reacted = false;
						Routine = true;
						Grudge = false;
						AlarmTimer = 0f;
						PreviousEyeShrink = 0f;
						EyeShrink = 0f;
						PreviousAlarm = 0f;
						MurdersWitnessed = 0;
						Concern = 0;
						Witnessed = StudentWitnessType.None;
						GameOverCause = GameOverType.None;
						CurrentDestination = Destinations[Phase];
						Pathfinding.target = Destinations[Phase];
					}
					else
					{
						Debug.Log("A teacher has reached ChaseYandere through PersonaReaction.");
						ChaseYandere();
					}
				}
			}
			else if (WitnessedCorpse)
			{
				Debug.Log("A teacher is now reacting to the sight of a corpse.");
				if (ReportPhase == 0)
				{
					Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
				}
				float y = Corpse.AllColliders[0].transform.position.y;
				float num = 0f;
				num = ((y > 1.4f && y < 1.6f) ? 1.4f : ((y < 2f) ? 0f : ((y < 4f) ? 2f : ((y < 6f) ? 4f : ((y < 8f) ? 6f : ((y < 10f) ? 8f : ((!(y < 12f)) ? 12f : 10f)))))));
				Debug.Log("PathfindingTarget's height has been set to: " + num);
				ExamineCorpseTarget = UnityEngine.Object.Instantiate(EmptyGameObject, new Vector3(Corpse.AllColliders[0].transform.position.x, num, Corpse.AllColliders[0].transform.position.z), Quaternion.identity).transform;
				Pathfinding.target = ExamineCorpseTarget;
				Pathfinding.target.position = Vector3.MoveTowards(Pathfinding.target.position, new Vector3(base.transform.position.x, num, base.transform.position.z), 1.5f);
				TargetDistance = 1f;
				ReportPhase = 2;
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
				IgnoringPettyActions = true;
				Routine = false;
				Fleeing = true;
			}
			else
			{
				Debug.Log("A teacher is now reacting to the sight of a severed limb, blood pool, or weapon.");
				if (ReportPhase == 0)
				{
					if (WitnessedBloodPool || WitnessedBloodyWeapon)
					{
						Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 3, 3f);
					}
					else if (WitnessedLimb)
					{
						Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 4, 3f);
					}
					else if (WitnessedWeapon)
					{
						Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 5, 3f);
					}
				}
				TargetDistance = 1f;
				ReportPhase = 2;
				VerballyReacted = true;
				Routine = false;
				Fleeing = true;
				Halt = true;
			}
		}
		else if (Persona == PersonaType.LandlineUser)
		{
			Debug.Log("A Snitch is calling PersonaReaction().");
			CurrentDestination = StudentManager.LandLineSpot;
			Pathfinding.target = StudentManager.LandLineSpot;
			Subtitle.UpdateLabel(SubtitleType.SocialDeathReaction, 1, 5f);
			TargetDistance = 1f;
			ReportPhase = 1;
			Routine = false;
			Fleeing = true;
		}
		if (StudentID == 41 && !StudentManager.Eighties)
		{
			Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
		}
		Debug.Log(Name + " has finished calling PersonaReaction(). As of now, they are a: " + Persona.ToString() + ".");
		if (WitnessedCorpse)
		{
			Debug.Log(Name + " witnessed a corpse...");
			if (Distracting)
			{
				Debug.Log("...so ''Distracting'' is being set to false.");
				if (DistractionTarget != null)
				{
					DistractionTarget.TargetedForDistraction = false;
				}
				ResumeDistracting = false;
				Distracting = false;
			}
		}
		Alarm = 0f;
		UpdateDetectionMarker();
	}

	private void BeginStruggle()
	{
		Debug.Log(Name + " has begun a struggle with Yandere-chan.");
		if (Yandere.Hiding)
		{
			Yandere.Hiding = false;
		}
		if (Yandere.Dragging)
		{
			Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		if (Yandere.Armed)
		{
			Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
		}
		Yandere.StruggleBar.OriginalDOF = CameraEffects.GetDOF();
		Yandere.StruggleBar.Strength = Strength;
		Yandere.StruggleBar.Struggling = true;
		Yandere.StruggleBar.Student = this;
		Yandere.StruggleBar.gameObject.SetActive(value: true);
		CharacterAnimation.CrossFade(StruggleAnim);
		Yandere.ShoulderCamera.LastPosition = Yandere.ShoulderCamera.transform.position;
		Yandere.ShoulderCamera.Struggle = true;
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		Obstacle.enabled = true;
		Struggling = true;
		DiscCheck = false;
		Alarmed = false;
		Halt = true;
		if (!Teacher)
		{
			Yandere.CharacterAnimation["f02_struggleA_00"].time = 0f;
		}
		else
		{
			Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time = 0f;
			base.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		if (Yandere.Aiming)
		{
			Yandere.StopAiming();
		}
		Yandere.StopLaughing();
		Yandere.TargetStudent = this;
		Yandere.YandereVision = false;
		Yandere.NearSenpai = false;
		Yandere.Struggling = true;
		Yandere.CanMove = false;
		if (Yandere.DelinquentFighting)
		{
			StudentManager.CombatMinigame.Stop();
		}
		Yandere.EmptyHands();
		Yandere.RPGCamera.enabled = false;
		MyController.radius = 0f;
		TargetDistance = 100f;
		AlarmTimer = 0f;
		SpawnAlarmDisc();
		Debug.Log("Manually setting DOF to 1 from here.");
		CameraEffects.UpdateDOF(1f);
	}

	public void GetDestinations()
	{
		if (!Teacher)
		{
			MyLocker = StudentManager.LockerPositions[StudentID];
		}
		if (Slave)
		{
			ScheduleBlock[] scheduleBlocks = ScheduleBlocks;
			foreach (ScheduleBlock obj in scheduleBlocks)
			{
				obj.destination = "Slave";
				obj.action = "Slave";
			}
		}
		if (ScheduleBlocks.Length == 0)
		{
			return;
		}
		for (ID = 1; ID < JSON.Students[StudentID].ScheduleBlocks.Length; ID++)
		{
			ScheduleBlock scheduleBlock = ScheduleBlocks[ID];
			if (scheduleBlock.destination == "Locker")
			{
				Destinations[ID] = MyLocker;
			}
			else if (scheduleBlock.destination == "Seat")
			{
				Destinations[ID] = Seat;
			}
			else if (scheduleBlock.destination == "SocialSeat")
			{
				Destinations[ID] = StudentManager.SocialSeats[StudentID];
				if (Destinations[ID] == null)
				{
					Destinations[ID] = Seat;
				}
			}
			else if (scheduleBlock.destination == "Podium")
			{
				Destinations[ID] = StudentManager.Podiums.List[Class];
			}
			else if (scheduleBlock.destination == "Exit")
			{
				Destinations[ID] = StudentManager.Hangouts.List[0];
			}
			else if (scheduleBlock.destination == "Hangout")
			{
				Destinations[ID] = StudentManager.Hangouts.List[StudentID];
			}
			else if (scheduleBlock.destination == "Week1Hangout")
			{
				Destinations[ID] = StudentManager.Week1Hangouts.List[StudentID];
			}
			else if (scheduleBlock.destination == "Week2Hangout")
			{
				Destinations[ID] = StudentManager.Week2Hangouts.List[StudentID];
			}
			else if (scheduleBlock.destination == "Stairway")
			{
				Destinations[ID] = StudentManager.Stairways.List[StudentID];
			}
			else if (scheduleBlock.destination == "LunchSpot")
			{
				Destinations[ID] = StudentManager.LunchSpots.List[StudentID];
			}
			else if (scheduleBlock.destination == "Slave")
			{
				if (!FragileSlave)
				{
					Destinations[ID] = StudentManager.SlaveSpot;
				}
				else
				{
					Destinations[ID] = StudentManager.FragileSlaveSpot;
				}
			}
			else if (scheduleBlock.destination == "Patrol")
			{
				Destinations[ID] = StudentManager.Patrols.List[StudentID].GetChild(0);
				if (OriginalClub != 0 && Club == ClubType.None && OriginalClub != ClubType.Occult && OriginalClub != ClubType.Gardening)
				{
					Debug.Log("Student #" + StudentID + "'s club disbanded, so their destination has been set to ''Hangout''.");
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
			}
			else if (scheduleBlock.destination == "Search Patrol")
			{
				StudentManager.SearchPatrols.List[Class].GetChild(0).position = Seat.position + Seat.forward;
				StudentManager.SearchPatrols.List[Class].GetChild(0).LookAt(Seat);
				StudentManager.StolenPhoneSpot.transform.position = Seat.position + Seat.forward * 0.4f;
				StudentManager.StolenPhoneSpot.transform.position += Vector3.up;
				StudentManager.StolenPhoneSpot.gameObject.SetActive(value: true);
				Destinations[ID] = StudentManager.SearchPatrols.List[Class].GetChild(0);
			}
			else if (scheduleBlock.destination == "Graffiti")
			{
				if (StudentManager.GraffitiSpots[BullyID] != null)
				{
					Destinations[ID] = StudentManager.GraffitiSpots[BullyID];
				}
				else if (StudentManager.Eighties)
				{
					Destinations[ID] = StudentManager.EightiesHangouts.List[StudentID];
				}
				else
				{
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
			}
			else if (scheduleBlock.destination == "Bully")
			{
				Destinations[ID] = StudentManager.BullySpots[BullyID];
			}
			else if (scheduleBlock.destination == "Mourn")
			{
				Destinations[ID] = StudentManager.MournSpots[StudentID];
			}
			else if (scheduleBlock.destination == "Clean")
			{
				if (CleaningSpot != null)
				{
					Destinations[ID] = CleaningSpot.GetChild(0);
				}
			}
			else if (scheduleBlock.destination == "ShameSpot")
			{
				Destinations[ID] = StudentManager.ShameSpot;
			}
			else if (scheduleBlock.destination == "Follow")
			{
				if (FollowTarget != null)
				{
					Destinations[ID] = FollowTarget.FollowTargetDestination;
				}
			}
			else if (scheduleBlock.destination == "Cuddle")
			{
				if (CuddlePartnerID == 0)
				{
					Destinations[ID] = StudentManager.FemaleCoupleSpots[CoupleID];
				}
				else
				{
					Destinations[ID] = StudentManager.MaleCoupleSpots[CoupleID];
				}
			}
			else if (scheduleBlock.destination == "Peek")
			{
				if (!Male)
				{
					Destinations[ID] = StudentManager.FemaleStalkSpot;
				}
				else
				{
					Destinations[ID] = StudentManager.MaleStalkSpot;
				}
			}
			else if (scheduleBlock.destination == "Club")
			{
				if (Club > ClubType.None)
				{
					Destinations[ID] = StudentManager.Clubs.List[StudentID];
					if (Club == ClubType.Sports)
					{
						Destinations[ID] = StudentManager.Clubs.List[StudentID].GetChild(0);
					}
				}
				else if (OriginalClub == ClubType.Cooking)
				{
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
				else if (OriginalClub == ClubType.Drama)
				{
					if (!StudentManager.MemorialScene.gameObject.activeInHierarchy)
					{
						Debug.Log("The Drama Club was shut down. They are still being told to perform their club action, though.");
						Destinations[ID] = StudentManager.Clubs.List[StudentID];
					}
					else
					{
						Debug.Log("The Drama Club was shut down and the gym stage has props on it. Drama students are going to go do something else.");
						Destinations[ID] = Seat;
					}
				}
				else if (OriginalClub == ClubType.Gaming)
				{
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
				else if (OriginalClub == ClubType.Art)
				{
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
				else if (OriginalClub == ClubType.MartialArts)
				{
					Destinations[ID] = StudentManager.Clubs.List[StudentID];
					DressCode = false;
				}
				else if (OriginalClub == ClubType.LightMusic)
				{
					Destinations[ID] = StudentManager.Clubs.List[StudentID];
				}
				else if (OriginalClub == ClubType.Photography)
				{
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
				else if (OriginalClub == ClubType.Science)
				{
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
				else if (OriginalClub == ClubType.Sports)
				{
					Destinations[ID] = StudentManager.Clubs.List[StudentID].GetChild(0);
				}
				else if (OriginalClub == ClubType.Gardening)
				{
					Destinations[ID] = StudentManager.Clubs.List[StudentID].GetChild(0);
				}
				else if (OriginalClub == ClubType.Newspaper)
				{
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
				else
				{
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
			}
			else if (scheduleBlock.destination == "Sulk")
			{
				Destinations[ID] = StudentManager.SulkSpots[StudentID];
			}
			else if (scheduleBlock.destination == "Sleuth")
			{
				Destinations[ID] = SleuthTarget;
			}
			else if (scheduleBlock.destination == "Stalk")
			{
				Destinations[ID] = StalkTarget;
				Stalker = true;
			}
			else if (scheduleBlock.destination == "Sunbathe")
			{
				Destinations[ID] = StudentManager.StrippingPositions[GirlID];
			}
			else if (scheduleBlock.destination == "Shock")
			{
				if (ClubGlobals.GetClubClosed(ClubType.Gaming))
				{
					Destinations[ID] = StudentManager.AltShockedSpots[StudentID - 80];
				}
				else
				{
					Destinations[ID] = StudentManager.ShockedSpots[StudentID - 80];
				}
			}
			else if (scheduleBlock.destination == "Miyuki")
			{
				ClubMemberID = StudentID - 35;
				if (ClubMemberID > 0 && ClubMemberID < 6)
				{
					Destinations[ID] = StudentManager.MiyukiSpots[ClubMemberID].transform;
				}
				else
				{
					Destinations[ID] = StudentManager.MiyukiSpots[1].transform;
				}
			}
			else if (scheduleBlock.destination == "Practice")
			{
				Destinations[ID] = StudentManager.PracticeSpots[ClubMemberID];
				if (Club == ClubType.None && !StudentManager.Eighties && StudentID == 51)
				{
					Destinations[ID] = StudentManager.Hangouts.List[StudentID];
				}
			}
			else if (scheduleBlock.destination == "Lyrics")
			{
				Destinations[ID] = StudentManager.LyricsSpot;
			}
			else if (scheduleBlock.destination == "Meeting")
			{
				Destinations[ID] = StudentManager.MeetingSpots[StudentID].transform;
			}
			else if (scheduleBlock.destination == "InfirmaryBed")
			{
				Debug.Log("Student #" + StudentID + " is now trying to assign themself to an infirmary bed.");
				Debug.Log("StudentManager.SedatedStudents is currently: " + StudentManager.SedatedStudents);
				if (StudentManager.SedatedStudents < 4)
				{
					Destinations[ID] = StudentManager.RestSpots[StudentManager.SedatedStudents];
					if (!TakingUpASedatedSpot)
					{
						StudentManager.SedatedStudents++;
						TakingUpASedatedSpot = true;
					}
				}
				else if (StudentManager.HeadacheStudents < 4)
				{
					Debug.Log("Wait. Number of Sedated Students is too high. Someone will have to go sit in the infirmary seat, instead.");
					Destinations[ID] = StudentManager.InfirmarySeats[StudentManager.HeadacheStudents];
					if (!TakingUpAHeadacheSpot)
					{
						StudentManager.HeadacheStudents++;
						TakingUpAHeadacheSpot = true;
					}
				}
				else
				{
					Debug.Log("Wait. Number of Headache Students is too high. This student will just have to sit in their classroom stead, instead.");
					Destinations[ID] = Seat;
				}
			}
			else if (scheduleBlock.destination == "InfirmarySeat")
			{
				Destinations[ID] = StudentManager.InfirmarySeats[StudentManager.HeadacheStudents];
				StudentManager.HeadacheStudents++;
			}
			else if (scheduleBlock.destination == "Paint")
			{
				Destinations[ID] = StudentManager.FridaySpots[StudentID];
			}
			else if (scheduleBlock.destination == "LockerRoom")
			{
				Destinations[ID] = StudentManager.MaleLockerRoomChangingSpot;
			}
			else if (scheduleBlock.destination == "LunchWitnessPosition")
			{
				Destinations[ID] = StudentManager.LunchWitnessPositions.List[StudentID];
			}
			else if (scheduleBlock.destination == "Wait")
			{
				Destinations[ID] = StudentManager.WaitSpots[StudentID];
			}
			else if (scheduleBlock.destination == "SleepSpot")
			{
				Debug.Log(Name + " is setting destination to ''SleepSpot''.");
				Destinations[ID] = StudentManager.SleepSpot;
			}
			else if (scheduleBlock.destination == "LightFire")
			{
				Destinations[ID] = StudentManager.PyroSpot;
			}
			else if (scheduleBlock.destination == "EightiesSpot")
			{
				Destinations[ID] = StudentManager.EightiesSpots.List[StudentID];
			}
			else if (scheduleBlock.destination == "EightiesShowerSpot")
			{
				Destinations[ID] = StudentManager.EightiesShowerSpots.List[StudentID];
			}
			else if (scheduleBlock.destination == "EightiesDramaSpot")
			{
				Destinations[ID] = StudentManager.EightiesDramaSpots.List[StudentID];
			}
			else if (scheduleBlock.destination == "EightiesStretchSpot")
			{
				Destinations[ID] = StudentManager.EightiesStretchSpots.List[StudentID];
			}
			else if (scheduleBlock.destination == "Perform")
			{
				Destinations[ID] = StudentManager.PerformSpots[StudentID];
			}
			else if (scheduleBlock.destination == "PhotoShoot")
			{
				Destinations[ID] = StudentManager.PhotoShootSpots[StudentID];
			}
			else if (scheduleBlock.destination == "Self")
			{
				Destinations[ID] = base.transform;
			}
			else if (scheduleBlock.destination == "Guard")
			{
				if (StudentID == 20 || Rival)
				{
					Destinations[ID] = StudentManager.Students[1].transform;
				}
				else if (StudentManager.RivalGuardSpots[StudentID] != null)
				{
					Destinations[ID] = StudentManager.RivalGuardSpots[StudentID].transform;
				}
				else if (StudentManager.Students[StudentManager.RivalID] != null)
				{
					Destinations[ID] = StudentManager.Students[StudentManager.RivalID].transform;
				}
				else
				{
					Destinations[ID] = Seat;
				}
			}
			else if (scheduleBlock.destination == "WitnessSpot")
			{
				_ = WitnessBonus;
				_ = 0;
				if (WitnessID + WitnessBonus < StudentManager.WitnessSpots.Length)
				{
					Destinations[ID] = StudentManager.WitnessSpots[WitnessID + WitnessBonus];
				}
				else
				{
					Destinations[ID] = StudentManager.WitnessSpots[WitnessID];
				}
			}
			else if (scheduleBlock.destination == "LunchWitnessSpot")
			{
				Destinations[ID] = StudentManager.LunchWitnessSpots[WitnessID];
			}
			else if (scheduleBlock.destination == "CleanWitnessSpot")
			{
				Destinations[ID] = StudentManager.CleaningWitnessSpots[WitnessID];
			}
			else if (scheduleBlock.destination == "AfterWitnessSpot")
			{
				Destinations[ID] = StudentManager.AfterClassWitnessSpots[WitnessID + AfterWitnessBonus];
			}
			else if (scheduleBlock.destination == "Random")
			{
				Destinations[ID] = StudentManager.RandomSpots[StudentID];
			}
			else if (scheduleBlock.destination == "CustomHangout")
			{
				Destinations[ID] = StudentManager.CustomHangouts.List[StudentID];
			}
			else if (scheduleBlock.destination == "CustomPatrol")
			{
				Destinations[ID] = StudentManager.CustomPatrols.List[StudentID].GetChild(0);
			}
			else if (scheduleBlock.destination == "RandomPatrol")
			{
				Destinations[ID] = StudentManager.CustomPatrols.List[UnityEngine.Random.Range(1, 101)].GetChild(UnityEngine.Random.Range(0, 2));
			}
			else if (scheduleBlock.destination == "BakeSale")
			{
				if (BakeSalePhase == 0)
				{
					Destinations[ID] = StudentManager.BakeSalePrepSpots[StudentID];
				}
				else
				{
					Destinations[ID] = StudentManager.BakeSaleSpots[StudentID];
				}
			}
			else if (scheduleBlock.destination == "Picnic")
			{
				Destinations[ID] = StudentManager.PicnicSpots[StudentID];
			}
			if (scheduleBlock.action == "Stand")
			{
				Actions[ID] = StudentActionType.AtLocker;
			}
			else if (scheduleBlock.action == "Socialize")
			{
				if (StudentID == 26)
				{
					Debug.Log("Somehow, this guy's shit is being set to ''Socializing''?");
				}
				Actions[ID] = StudentActionType.Socializing;
			}
			else if (scheduleBlock.action == "Game")
			{
				Actions[ID] = StudentActionType.Gaming;
			}
			else if (scheduleBlock.action == "Slave")
			{
				Actions[ID] = StudentActionType.Slave;
			}
			else if (scheduleBlock.action == "Relax")
			{
				Actions[ID] = StudentActionType.Relax;
			}
			else if (scheduleBlock.action == "Sit")
			{
				Actions[ID] = StudentActionType.SitAndTakeNotes;
			}
			else if (scheduleBlock.action == "Peek")
			{
				Actions[ID] = StudentActionType.Peek;
			}
			else if (scheduleBlock.action == "SocialSit")
			{
				Actions[ID] = StudentActionType.SitAndSocialize;
				if (Persona == PersonaType.Sleuth && Club == ClubType.None)
				{
					Actions[ID] = StudentActionType.Socializing;
				}
			}
			else if (scheduleBlock.action == "Eat")
			{
				Actions[ID] = StudentActionType.SitAndEatBento;
			}
			else if (scheduleBlock.action == "Shoes")
			{
				Actions[ID] = StudentActionType.ChangeShoes;
			}
			else if (scheduleBlock.action == "Grade")
			{
				Actions[ID] = StudentActionType.GradePapers;
			}
			else if (scheduleBlock.action == "Patrol")
			{
				Actions[ID] = StudentActionType.Patrol;
				if (OriginalClub != 0 && Club == ClubType.None && OriginalClub != ClubType.Occult)
				{
					Debug.Log("Student #" + StudentID + "'s club disbanded, so their action has been set to ''Socialize''.");
					Actions[ID] = StudentActionType.Socializing;
				}
			}
			else if (scheduleBlock.action == "Search Patrol")
			{
				Actions[ID] = StudentActionType.SearchPatrol;
			}
			else if (scheduleBlock.action == "Gossip")
			{
				Actions[ID] = StudentActionType.Gossip;
			}
			else if (scheduleBlock.action == "Graffiti")
			{
				Actions[ID] = StudentActionType.Graffiti;
			}
			else if (scheduleBlock.action == "Bully")
			{
				Actions[ID] = StudentActionType.Bully;
			}
			else if (scheduleBlock.action == "Read")
			{
				Actions[ID] = StudentActionType.Read;
			}
			else if (scheduleBlock.action == "Text")
			{
				Actions[ID] = StudentActionType.Texting;
			}
			else if (scheduleBlock.action == "Mourn")
			{
				Actions[ID] = StudentActionType.Mourn;
			}
			else if (scheduleBlock.action == "Cuddle")
			{
				Actions[ID] = StudentActionType.Cuddle;
			}
			else if (scheduleBlock.action == "Teach")
			{
				Actions[ID] = StudentActionType.Teaching;
			}
			else if (scheduleBlock.action == "Wait")
			{
				Actions[ID] = StudentActionType.Wait;
			}
			else if (scheduleBlock.action == "Clean")
			{
				Actions[ID] = StudentActionType.Clean;
			}
			else if (scheduleBlock.action == "Shamed")
			{
				Actions[ID] = StudentActionType.Shamed;
			}
			else if (scheduleBlock.action == "Follow")
			{
				Actions[ID] = StudentActionType.Follow;
			}
			else if (scheduleBlock.action == "Sulk")
			{
				Actions[ID] = StudentActionType.Sulk;
			}
			else if (scheduleBlock.action == "Sleuth")
			{
				Actions[ID] = StudentActionType.Sleuth;
			}
			else if (scheduleBlock.action == "Stalk")
			{
				Actions[ID] = StudentActionType.Stalk;
			}
			else if (scheduleBlock.action == "Sketch")
			{
				Actions[ID] = StudentActionType.Sketch;
			}
			else if (scheduleBlock.action == "Sunbathe")
			{
				Actions[ID] = StudentActionType.Sunbathe;
			}
			else if (scheduleBlock.action == "Shock")
			{
				Actions[ID] = StudentActionType.Shock;
			}
			else if (scheduleBlock.action == "Miyuki")
			{
				Actions[ID] = StudentActionType.Miyuki;
			}
			else if (scheduleBlock.action == "Meeting")
			{
				Actions[ID] = StudentActionType.Meeting;
			}
			else if (scheduleBlock.action == "Lyrics")
			{
				Actions[ID] = StudentActionType.Lyrics;
			}
			else if (scheduleBlock.action == "Practice")
			{
				Actions[ID] = StudentActionType.Practice;
			}
			else if (scheduleBlock.action == "Sew")
			{
				Actions[ID] = StudentActionType.Sew;
			}
			else if (scheduleBlock.action == "Paint")
			{
				Actions[ID] = StudentActionType.Paint;
			}
			else if (scheduleBlock.action == "UpdateAppearance")
			{
				Actions[ID] = StudentActionType.UpdateAppearance;
			}
			else if (scheduleBlock.action == "LightCig")
			{
				Actions[ID] = StudentActionType.LightCig;
			}
			else if (scheduleBlock.action == "PlaceBag")
			{
				Actions[ID] = StudentActionType.PlaceBag;
			}
			else if (scheduleBlock.action == "Sleep")
			{
				Debug.Log(Name + " is setting action to ''Sleep''.");
				Actions[ID] = StudentActionType.Sleep;
			}
			else if (scheduleBlock.action == "LightFire")
			{
				Actions[ID] = StudentActionType.LightFire;
			}
			else if (scheduleBlock.action == "Jog")
			{
				Actions[ID] = StudentActionType.Jog;
			}
			else if (scheduleBlock.action == "PrepareFood")
			{
				Actions[ID] = StudentActionType.PrepareFood;
			}
			else if (scheduleBlock.action == "Perform")
			{
				Actions[ID] = StudentActionType.Perform;
			}
			else if (scheduleBlock.action == "PhotoShoot")
			{
				Actions[ID] = StudentActionType.PhotoShoot;
			}
			else if (scheduleBlock.action == "GravurePose")
			{
				Actions[ID] = StudentActionType.GravurePose;
			}
			else if (scheduleBlock.action == "Guard")
			{
				Actions[ID] = StudentActionType.Guard;
			}
			else if (scheduleBlock.action == "Gaming")
			{
				Actions[ID] = StudentActionType.Gaming;
			}
			else if (scheduleBlock.action == "Random")
			{
				Actions[ID] = StudentActionType.Random;
			}
			else if (scheduleBlock.action == "HelpTeacher")
			{
				Actions[ID] = StudentActionType.HelpTeacher;
			}
			else if (scheduleBlock.action == "Admire")
			{
				Actions[ID] = StudentActionType.Admire;
				Infatuated = true;
				if (!Stalker)
				{
					if (Rival)
					{
						InfatuationID = 1;
					}
					else
					{
						InfatuationID = StudentManager.RivalID;
					}
				}
				if (AdmireAnim == "")
				{
					AdmireAnim = AdmireAnims[0];
				}
			}
			else if (scheduleBlock.action == "Rehearse")
			{
				Actions[ID] = StudentActionType.Rehearse;
			}
			else if (scheduleBlock.action == "Stretch")
			{
				Actions[ID] = StudentActionType.Stretch;
			}
			else if (scheduleBlock.action == "Club")
			{
				if (Club > ClubType.None)
				{
					Actions[ID] = StudentActionType.ClubAction;
				}
				else if (OriginalClub == ClubType.Cooking)
				{
					Actions[ID] = StudentActionType.Socializing;
				}
				else if (OriginalClub == ClubType.Drama)
				{
					if (!StudentManager.MemorialScene.gameObject.activeInHierarchy)
					{
						Debug.Log("The Drama Club was shut down. They are still being told to perform their club action, though.");
						Actions[ID] = StudentActionType.ClubAction;
						Debug.Log(Name + "'s Actions[" + ID + "] should be: " + Actions[ID]);
					}
					else
					{
						Debug.Log("The Drama Club was shut down and the gym stage has props on it. Drama students are going to go do something else.");
						Actions[ID] = StudentActionType.SitAndTakeNotes;
					}
				}
				else if (OriginalClub == ClubType.Occult)
				{
					Actions[ID] = StudentActionType.ClubAction;
				}
				else if (OriginalClub == ClubType.Gaming)
				{
					Actions[ID] = StudentActionType.ClubAction;
				}
				else if (OriginalClub == ClubType.Art)
				{
					Actions[ID] = StudentActionType.Sketch;
				}
				else if (OriginalClub == ClubType.MartialArts)
				{
					Actions[ID] = StudentActionType.ClubAction;
					DressCode = false;
				}
				else if (OriginalClub == ClubType.LightMusic)
				{
					Actions[ID] = StudentActionType.ClubAction;
				}
				else if (OriginalClub == ClubType.LightMusic)
				{
					Actions[ID] = StudentActionType.Socializing;
				}
				else if (OriginalClub == ClubType.Science)
				{
					Actions[ID] = StudentActionType.Socializing;
				}
				else if (OriginalClub == ClubType.Sports)
				{
					Actions[ID] = StudentActionType.ClubAction;
				}
				else if (OriginalClub == ClubType.Gardening)
				{
					Actions[ID] = StudentActionType.ClubAction;
				}
				else if (OriginalClub == ClubType.Newspaper)
				{
					Actions[ID] = StudentActionType.Socializing;
				}
				else
				{
					Debug.Log("Somehow, Student#" + StudentID + " - " + Name + " - reached this part of the code.");
					Actions[ID] = StudentActionType.Socializing;
				}
			}
			else if (scheduleBlock.action == "CustomHangout")
			{
				Actions[ID] = StudentActionType.CustomHangout;
			}
			else if (scheduleBlock.action == "CustomPatrol")
			{
				Actions[ID] = StudentActionType.CustomPatrol;
			}
			else if (scheduleBlock.action == "RandomPatrol")
			{
				Actions[ID] = StudentActionType.RandomPatrol;
			}
			else if (scheduleBlock.action == "BakeSale")
			{
				Actions[ID] = StudentActionType.BakeSale;
			}
			else if (scheduleBlock.action == "Picnic")
			{
				Actions[ID] = StudentActionType.Picnic;
			}
		}
	}

	private void SetOutlinesOrange()
	{
		for (ID = 0; ID < Outlines.Length; ID++)
		{
			if (Outlines[ID] != null)
			{
				Outlines[ID].color = new Color(1f, 0.5f, 0f, 1f);
				Outlines[ID].enabled = true;
			}
		}
		for (ID = 0; ID < RiggedAccessoryOutlines.Length; ID++)
		{
			if (RiggedAccessoryOutlines[ID] != null)
			{
				RiggedAccessoryOutlines[ID].color = new Color(1f, 0.5f, 0f, 1f);
				RiggedAccessoryOutlines[ID].enabled = Outlines[0].enabled;
			}
		}
	}

	private void SetOutlinesYellow()
	{
		for (ID = 0; ID < Outlines.Length; ID++)
		{
			if (Outlines[ID] != null)
			{
				Outlines[ID].color = new Color(1f, 1f, 0f, 1f);
				Outlines[ID].enabled = true;
			}
		}
		for (ID = 0; ID < RiggedAccessoryOutlines.Length; ID++)
		{
			if (RiggedAccessoryOutlines[ID] != null)
			{
				RiggedAccessoryOutlines[ID].color = new Color(1f, 1f, 0f, 1f);
				RiggedAccessoryOutlines[ID].enabled = Outlines[0].enabled;
			}
		}
	}

	private void SetOutlinesRed()
	{
		for (ID = 0; ID < Outlines.Length; ID++)
		{
			if (Outlines[ID] != null)
			{
				Outlines[ID].color = new Color(1f, 0f, 0f, 1f);
				Outlines[ID].enabled = true;
			}
		}
		for (ID = 0; ID < RiggedAccessoryOutlines.Length; ID++)
		{
			if (RiggedAccessoryOutlines[ID] != null)
			{
				RiggedAccessoryOutlines[ID].color = new Color(1f, 0f, 0f, 1f);
				RiggedAccessoryOutlines[ID].enabled = Outlines[0].enabled;
			}
		}
	}

	public void AddOutlineToHair()
	{
		if (Cosmetic.HairRenderer != null)
		{
			if (Cosmetic.HairRenderer.GetComponent<OutlineScript>() == null)
			{
				Cosmetic.HairRenderer.gameObject.AddComponent<OutlineScript>();
			}
			Outlines[1] = Cosmetic.HairRenderer.gameObject.GetComponent<OutlineScript>();
			if (Outlines[1].h == null)
			{
				Outlines[1].Awake();
			}
			Outlines[1].color = Outlines[0].color;
			Outlines[1].enabled = Outlines[0].enabled;
			Outlines[1].h.enabled = Outlines[1].enabled;
		}
		if (Teacher && StudentManager.Eighties && EightiesTeacherAttacher != null && EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
		{
			EightiesTeacherRenderer = EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
			if (EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.gameObject.GetComponent<OutlineScript>() == null)
			{
				EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.gameObject.AddComponent<OutlineScript>();
			}
			MyRenderer = EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
			Outlines[0] = EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.gameObject.GetComponent<OutlineScript>();
			Outlines[0].color = Outlines[1].color;
			if (Outlines[0].h == null)
			{
				Outlines[0].Awake();
			}
		}
	}

	public void PickRandomAnim()
	{
		if (Grudge)
		{
			RandomAnim = BulliedIdleAnim;
		}
		else if (Club != ClubType.Delinquent)
		{
			RandomAnim = AnimationNames[UnityEngine.Random.Range(0, AnimationNames.Length)];
		}
		else
		{
			RandomAnim = DelinquentAnims[UnityEngine.Random.Range(0, DelinquentAnims.Length)];
		}
	}

	private void PickRandomGossipAnim()
	{
		if (Grudge)
		{
			RandomAnim = BulliedIdleAnim;
			return;
		}
		RandomGossipAnim = GossipAnims[UnityEngine.Random.Range(0, GossipAnims.Length)];
		if (Actions[Phase] == StudentActionType.Gossip && DistanceToPlayer < 3f)
		{
			if (!ConversationGlobals.GetTopicDiscovered(19))
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(19, value: true);
			}
			if (!StudentManager.GetTopicLearnedByStudent(19, StudentID))
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				StudentManager.SetTopicLearnedByStudent(19, StudentID, boolean: true);
			}
		}
	}

	private void PickRandomSleuthAnim()
	{
		if (!Sleuthing)
		{
			RandomSleuthAnim = SleuthAnims[UnityEngine.Random.Range(0, 3)];
		}
		else
		{
			RandomSleuthAnim = SleuthAnims[UnityEngine.Random.Range(3, 6)];
		}
	}

	private void BecomeTeacher()
	{
		base.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
		StudentManager.Teachers[Class] = this;
		if (Class != 1)
		{
			GradingPaper = StudentManager.FacultyDesks[Class];
			if (StudentID == 94 && StudentManager.Eighties && StudentManager.Week > 1)
			{
				GradingPaper.enabled = false;
				GradingPaper = StudentManager.FacultyDesks[1];
			}
			GradingPaper.LeftHand = LeftHand.parent;
			GradingPaper.Character = Character;
			GradingPaper.Teacher = this;
			SkirtCollider.gameObject.SetActive(value: false);
			LowPoly.MyMesh = LowPoly.TeacherMesh;
			PantyCollider.enabled = false;
		}
		if (Class > 1)
		{
			VisionDistance = 12f * Paranoia;
			base.name = "Teacher_" + Class + "_" + Name;
			OriginalIdleAnim = "f02_idleShort_00";
			IdleAnim = "f02_idleShort_00";
		}
		else if (Class == 1)
		{
			VisionDistance = 12f * Paranoia;
			PatrolAnim = "f02_idle_00";
			base.name = "Nurse_" + Name;
			if (StudentManager.Eighties)
			{
				HeadacheMedicinePrompt.SetActive(value: true);
			}
		}
		else
		{
			VisionDistance = 16f * Paranoia;
			PatrolAnim = "f02_stretch_00";
			base.name = "Coach_" + Name;
			OriginalIdleAnim = "f02_tsunIdle_00";
			IdleAnim = "f02_tsunIdle_00";
		}
		StruggleAnim = "f02_teacherStruggleB_00";
		StruggleWonAnim = "f02_teacherStruggleWinB_00";
		StruggleLostAnim = "f02_teacherStruggleLoseB_00";
		OriginallyTeacher = true;
		Spawned = true;
		Teacher = true;
		if (StudentID > 89 && StudentID < 98 && StudentManager.Eighties)
		{
			SmartPhone = EightiesPhone;
			if (StudentID != 97 && StudentID != 90)
			{
				EightiesTeacherAttacher.SetActive(value: true);
				MyRenderer.enabled = false;
			}
		}
		SmartPhone.SetActive(value: false);
		base.gameObject.tag = "Untagged";
		MyController.skinWidth = 0.09f;
	}

	public void RemoveShoes()
	{
		if (!Male)
		{
			MyRenderer.materials[0].mainTexture = Cosmetic.SocksTexture;
			MyRenderer.materials[1].mainTexture = Cosmetic.SocksTexture;
		}
		else
		{
			MyRenderer.materials[Cosmetic.UniformID].mainTexture = Cosmetic.SocksTexture;
		}
	}

	public void BecomeRagdoll()
	{
		if (HeadacheMedicinePrompt != null)
		{
			HeadacheMedicinePrompt.GetComponent<GenericEightiesTaskScript>().Disable();
		}
		if (!Rival && StudentManager.ChallengeManager.RivalsOnly)
		{
			StudentManager.ChallengeManager.GameOverTimer = 1f;
		}
		if (StudentID == 19)
		{
			StudentManager.ZeroAllStalkerSpots();
		}
		if (BloodPool != null)
		{
			PromptScript component = BloodPool.GetComponent<PromptScript>();
			if (component != null)
			{
				Debug.Log("Re-enabling an object's prompt.");
				component.enabled = true;
			}
		}
		if (FollowTarget != null)
		{
			FollowTarget.Follower = null;
		}
		Meeting = false;
		if (Rival)
		{
			StudentManager.RivalEliminated = true;
			if (Follower != null && Follower.FollowTarget != null && StudentManager.LastKnownOsana.position == Vector3.zero)
			{
				StudentManager.LastKnownOsana.position = base.transform.position;
				Follower.Destinations[Follower.Phase] = StudentManager.LastKnownOsana;
				if (Follower.CurrentDestination == Follower.FollowTarget)
				{
					Follower.Pathfinding.target = StudentManager.LastKnownOsana;
					Follower.CurrentDestination = StudentManager.LastKnownOsana;
				}
			}
		}
		if (BikiniAttacher != null && BikiniAttacher.newRenderer != null)
		{
			BikiniAttacher.newRenderer.updateWhenOffscreen = true;
		}
		if (EightiesTeacherAttacher != null && EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
		{
			EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.updateWhenOffscreen = true;
		}
		if (LabcoatAttacher.newRenderer != null)
		{
			LabcoatAttacher.newRenderer.updateWhenOffscreen = true;
		}
		if (ApronAttacher.newRenderer != null)
		{
			ApronAttacher.newRenderer.updateWhenOffscreen = true;
		}
		if (Attacher.newRenderer != null)
		{
			Attacher.newRenderer.updateWhenOffscreen = true;
		}
		if (DrinkingFountain != null)
		{
			DrinkingFountain.Occupied = false;
		}
		if (!Ragdoll.enabled)
		{
			EmptyHands();
			if (Broken != null)
			{
				Broken.enabled = false;
				Broken.MyAudio.Stop();
			}
			if (Club == ClubType.Delinquent && MyWeapon != null)
			{
				MyWeapon.transform.parent = null;
				MyWeapon.MyCollider.enabled = true;
				MyWeapon.Prompt.enabled = true;
				Rigidbody component2 = MyWeapon.GetComponent<Rigidbody>();
				component2.constraints = RigidbodyConstraints.None;
				component2.isKinematic = false;
				component2.useGravity = true;
				MyWeapon = null;
			}
			if (StudentManager.ChaseCamera == ChaseCamera)
			{
				StudentManager.ChaseCamera = null;
			}
			Countdown.gameObject.SetActive(value: false);
			ChaseCamera.SetActive(value: false);
			if (Club == ClubType.Council)
			{
				Police.CouncilDeath = true;
			}
			if (WillChase)
			{
				Yandere.Chasers--;
			}
			ParticleSystem.EmissionModule emission = Hearts.emission;
			if (Following)
			{
				emission.enabled = false;
				FollowCountdown.gameObject.SetActive(value: false);
				Yandere.Follower = null;
				Yandere.Followers--;
				Following = false;
			}
			if (this == StudentManager.Reporter)
			{
				StudentManager.Reporter = null;
			}
			if (Pushed)
			{
				Police.SuicideStudent = base.gameObject;
				Police.SuicideID = StudentID;
				Police.SuicideScene = true;
				Ragdoll.Suicide = true;
				Police.Suicide = true;
			}
			if (!Tranquil && !Ragdoll.Burning && !Ragdoll.Disturbing)
			{
				if (Police == null)
				{
					Police = StudentManager.Police;
				}
				if (Police.Corpses < 0)
				{
					Police.Corpses = 0;
				}
				if (Police.Corpses < Police.CorpseList.Length)
				{
					Police.CorpseList[Police.Corpses] = Ragdoll;
				}
				Police.Corpses++;
			}
			if (!Male)
			{
				LiquidProjector.ignoreLayers = -2049;
				RightHandCollider.enabled = false;
				LeftHandCollider.enabled = false;
				PantyCollider.enabled = false;
				SkirtCollider.gameObject.SetActive(value: false);
			}
			CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			Ragdoll.AllColliders[10].isTrigger = false;
			NotFaceCollider.enabled = false;
			FaceCollider.enabled = false;
			MyController.enabled = false;
			emission.enabled = false;
			SpeechLines.Stop();
			if (MyRenderer.enabled)
			{
				MyRenderer.updateWhenOffscreen = true;
			}
			AIDestinationSetter component3 = GetComponent<AIDestinationSetter>();
			if (component3 != null)
			{
				component3.enabled = false;
			}
			Pathfinding.enabled = false;
			HipCollider.enabled = true;
			base.enabled = false;
			UnWet();
			Prompt.Hide();
			Prompt.enabled = false;
			Prompt.Hide();
			Ragdoll.CharacterAnimation = CharacterAnimation;
			Ragdoll.DetectionMarker = DetectionMarker;
			Ragdoll.RightEyeOrigin = RightEyeOrigin;
			Ragdoll.LeftEyeOrigin = LeftEyeOrigin;
			Ragdoll.Electrocuted = Electrocuted;
			Ragdoll.NeckSnapped = NeckSnapped;
			Ragdoll.BreastSize = BreastSize;
			Ragdoll.EyeShrink = EyeShrink;
			Ragdoll.StudentID = StudentID;
			Ragdoll.Tranquil = Tranquil;
			Ragdoll.Burning = Burning;
			Ragdoll.Drowned = Drowned;
			Ragdoll.Yandere = Yandere;
			Ragdoll.Police = Police;
			Ragdoll.Pushed = Pushed;
			Ragdoll.Male = Male;
			if (!Tranquil)
			{
				Police.Deaths++;
			}
			if (!NoRagdoll)
			{
				Ragdoll.enabled = true;
			}
			if (Reputation == null)
			{
				Reputation = StudentManager.Reputation;
			}
			Reputation.PendingRep -= PendingRep;
			if (WitnessedMurder && Persona != PersonaType.Evil)
			{
				Police.Witnesses--;
			}
			SetOutlinesOrange();
			if (DetectionMarker != null)
			{
				DetectionMarker.Tex.enabled = false;
			}
			GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
			MapMarker.gameObject.layer = 10;
			base.tag = "Blood";
			LowPoly.transform.parent = Hips;
			LowPoly.transform.localPosition = new Vector3(0f, -1f, 0f);
			LowPoly.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
		if (SmartPhone.transform.parent == ItemParent)
		{
			SmartPhone.SetActive(value: false);
		}
		Grudge = false;
	}

	public void GetWet()
	{
		if (InvestigatingBloodPool)
		{
			ForgetAboutBloodPool();
		}
		if ((SchemeGlobals.GetSchemeStage(1) == 3 && Rival) || SchemeGlobals.GetSchemeStage(2) == 3 || StudentID == 2)
		{
			Debug.Log("A scheme-related character was just splashed with water.");
			SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) + 1);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		TargetDistance = 1f;
		FocusOnStudent = false;
		FocusOnYandere = false;
		BeenSplashed = true;
		BatheFast = true;
		LiquidProjector.gameObject.SetActive(value: true);
		LiquidProjector.enabled = true;
		Emetic = false;
		Sedated = false;
		Headache = false;
		Vomiting = false;
		DressCode = false;
		Reacted = false;
		Alarmed = false;
		if (Gas)
		{
			LiquidProjector.material = GasMaterial;
		}
		else if (Bloody)
		{
			LiquidProjector.material = BloodMaterial;
		}
		else if (DyedBrown)
		{
			LiquidProjector.material = BrownMaterial;
		}
		else
		{
			LiquidProjector.material = WaterMaterial;
		}
		for (ID = 0; ID < LiquidEmitters.Length; ID++)
		{
			ParticleSystem obj = LiquidEmitters[ID];
			obj.gameObject.SetActive(value: true);
			ParticleSystem.MainModule main = obj.main;
			if (Gas)
			{
				main.startColor = new Color(1f, 1f, 0f, 1f);
			}
			else if (Bloody)
			{
				main.startColor = new Color(1f, 0f, 0f, 1f);
			}
			else if (DyedBrown)
			{
				main.startColor = new Color(0.5f, 0.25f, 0f, 1f);
			}
			else
			{
				main.startColor = new Color(0f, 1f, 1f, 1f);
			}
		}
		if (!Slave)
		{
			CharacterAnimation[SplashedAnim].speed = 1f;
			CharacterAnimation.CrossFade(SplashedAnim);
			Subtitle.UpdateLabel(SplashSubtitleType, 0, 1f);
			SpeechLines.Stop();
			Hearts.Stop();
			StopMeeting();
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
			SplashTimer = 0f;
			SplashPhase = 1;
			BathePhase = 1;
			ForgetRadio();
			if (Distracting)
			{
				DistractionTarget.TargetedForDistraction = false;
				DistractionTarget.Octodog.SetActive(value: false);
				DistractionTarget.Distracted = false;
				Distracting = false;
				CanTalk = true;
			}
			if (Investigating)
			{
				Investigating = false;
			}
			SchoolwearUnavailable = true;
			SentToLocker = false;
			Distracted = true;
			Splashed = true;
			Routine = false;
			GoAway = false;
			Wet = true;
			if (Following)
			{
				FollowCountdown.gameObject.SetActive(value: false);
				Yandere.Follower = null;
				Yandere.Followers--;
				Following = false;
			}
			SpawnAlarmDisc();
			if (Club == ClubType.Cooking)
			{
				IdleAnim = OriginalIdleAnim;
				WalkAnim = OriginalWalkAnim;
				LeanAnim = OriginalLeanAnim;
				ClubActivityPhase = 0;
				ClubTimer = 0f;
			}
			if (ReturningMisplacedWeapon)
			{
				DropMisplacedWeapon();
			}
			EmptyHands();
		}
		Alarm = 0f;
		UpdateDetectionMarker();
	}

	public void GetWetNoConsequences()
	{
		LiquidProjector.gameObject.SetActive(value: true);
		LiquidProjector.enabled = true;
		if (Gas)
		{
			LiquidProjector.material = GasMaterial;
		}
		else if (Bloody)
		{
			LiquidProjector.material = BloodMaterial;
		}
		else if (DyedBrown)
		{
			LiquidProjector.material = BrownMaterial;
		}
		else
		{
			LiquidProjector.material = WaterMaterial;
		}
		for (ID = 0; ID < LiquidEmitters.Length; ID++)
		{
			ParticleSystem obj = LiquidEmitters[ID];
			obj.gameObject.SetActive(value: true);
			ParticleSystem.MainModule main = obj.main;
			if (Gas)
			{
				main.startColor = new Color(1f, 1f, 0f, 1f);
			}
			else if (Bloody)
			{
				main.startColor = new Color(1f, 0f, 0f, 1f);
			}
			else if (DyedBrown)
			{
				main.startColor = new Color(0.5f, 0.25f, 0f, 1f);
			}
			else
			{
				main.startColor = new Color(0f, 1f, 1f, 1f);
			}
		}
	}

	public void UnWet()
	{
		for (ID = 0; ID < LiquidEmitters.Length; ID++)
		{
			LiquidEmitters[ID].gameObject.SetActive(value: false);
		}
	}

	public void SetSplashes(bool Bool)
	{
		for (ID = 0; ID < SplashEmitters.Length; ID++)
		{
			SplashEmitters[ID].gameObject.SetActive(Bool);
		}
	}

	public void StopMeeting()
	{
		Prompt.Label[0].text = "     Talk";
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		DistanceToDestination = 100f;
		Drownable = false;
		Pushable = false;
		Meeting = false;
		CanTalk = true;
		StudentManager.UpdateMe(StudentID);
		MeetTimer = 0f;
		RemoveOfferHelpPrompt();
		if (Rival)
		{
			StudentManager.UpdateInfatuatedTargetDistances();
		}
	}

	public void RemoveOfferHelpPrompt()
	{
		OfferHelpScript offerHelpScript = null;
		if (StudentManager.Eighties && StudentID == StudentManager.RivalID)
		{
			offerHelpScript = StudentManager.EightiesOfferHelp;
			StudentManager.LoveManager.RivalWaiting = false;
		}
		else if (StudentID == StudentManager.RivalID)
		{
			offerHelpScript = StudentManager.OsanaOfferHelp;
			StudentManager.LoveManager.RivalWaiting = false;
		}
		else if (StudentID == 30)
		{
			offerHelpScript = StudentManager.OfferHelp;
			StudentManager.LoveManager.RivalWaiting = false;
		}
		else if (StudentID == 5)
		{
			offerHelpScript = StudentManager.FragileOfferHelp;
		}
		if (offerHelpScript != null)
		{
			offerHelpScript.transform.position = Vector3.zero;
			offerHelpScript.enabled = false;
			offerHelpScript.Prompt.Hide();
			offerHelpScript.Prompt.enabled = false;
		}
	}

	public void Combust()
	{
		Police.CorpseList[Police.Corpses] = Ragdoll;
		Police.Corpses++;
		GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
		MapMarker.gameObject.layer = 10;
		base.tag = "Blood";
		Dying = true;
		CharacterAnimation.CrossFade(BurningAnim);
		CharacterAnimation[WetAnim].weight = 0f;
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		Ragdoll.BurningAnimation = true;
		Ragdoll.Disturbing = true;
		Ragdoll.Burning = true;
		WitnessedCorpse = false;
		FocusOnStudent = false;
		FocusOnYandere = false;
		Investigating = false;
		EatingSnack = false;
		DiscCheck = false;
		WalkBack = false;
		Alarmed = false;
		CanTalk = false;
		Fleeing = false;
		Routine = false;
		Reacted = false;
		Burning = true;
		Wet = false;
		SpawnAlarmDisc();
		if (!NoScream)
		{
			AudioSource component = GetComponent<AudioSource>();
			component.clip = BurningClip;
			component.Play();
		}
		LiquidProjector.enabled = false;
		UnWet();
		if (Following)
		{
			FollowCountdown.gameObject.SetActive(value: false);
			Yandere.Follower = null;
			Yandere.Followers--;
			Following = false;
		}
		for (ID = 0; ID < FireEmitters.Length; ID++)
		{
			FireEmitters[ID].gameObject.SetActive(value: true);
		}
		if (Attacked)
		{
			BurnTarget = Yandere.transform.position + Yandere.transform.forward;
			Attacked = false;
		}
	}

	public void JojoReact()
	{
		UnityEngine.Object.Instantiate(JojoHitEffect, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
		if (!Dying)
		{
			Dying = true;
			SpawnAlarmDisc();
			CharacterAnimation.CrossFade(JojoReactAnim);
			CharacterAnimation[WetAnim].weight = 0f;
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
			WitnessedCorpse = false;
			Investigating = false;
			EatingSnack = false;
			DiscCheck = false;
			WalkBack = false;
			Alarmed = false;
			CanTalk = false;
			Fleeing = false;
			Routine = false;
			Reacted = false;
			Wet = false;
			GetComponent<AudioSource>().Play();
			if (Following)
			{
				FollowCountdown.gameObject.SetActive(value: false);
				Yandere.Follower = null;
				Yandere.Followers--;
				Following = false;
			}
		}
	}

	private void Nude()
	{
		if (!Male)
		{
			PantyCollider.enabled = false;
			SkirtCollider.gameObject.SetActive(value: false);
		}
		if (!Male)
		{
			MyRenderer.sharedMesh = TowelMesh;
			if (Club == ClubType.Bully)
			{
				Cosmetic.DeactivateBullyAccessories();
			}
			MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			MyRenderer.materials[0].mainTexture = TowelTexture;
			MyRenderer.materials[1].mainTexture = TowelTexture;
			if (MyRenderer.materials.Length > 2)
			{
				MyRenderer.materials[2].mainTexture = Cosmetic.FaceTexture;
			}
			Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		}
		else
		{
			MyRenderer.sharedMesh = BaldNudeMesh;
			MyRenderer.materials[0].mainTexture = NudeTexture;
			MyRenderer.materials[1].mainTexture = null;
			MyRenderer.materials[2].mainTexture = Cosmetic.FaceTextures[SkinColor];
		}
		Cosmetic.RemoveCensor();
		if (!AoT)
		{
			if (Male)
			{
				for (ID = 0; ID < CensorSteam.Length; ID++)
				{
					CensorSteam[ID].SetActive(value: true);
				}
			}
		}
		else if (!Male)
		{
			MyRenderer.sharedMesh = BaldNudeMesh;
			MyRenderer.materials[0].mainTexture = NudeTexture;
			MyRenderer.materials[1].mainTexture = Cosmetic.FaceTexture;
			if (MyRenderer.materials.Length > 2)
			{
				MyRenderer.materials[2].mainTexture = NudeTexture;
			}
		}
		else
		{
			MyRenderer.materials[1].mainTexture = Cosmetic.FaceTextures[SkinColor];
		}
		if (Club == ClubType.Cooking)
		{
			ApronAttacher.newRenderer.gameObject.SetActive(value: false);
			Debug.Log("We were told to disable this apron attacher...");
		}
	}

	public void ChangeSchoolwear()
	{
		for (ID = 0; ID < CensorSteam.Length; ID++)
		{
			CensorSteam[ID].SetActive(value: false);
		}
		if (Attacher.gameObject.activeInHierarchy)
		{
			Attacher.RemoveAccessory();
		}
		if (LabcoatAttacher.enabled)
		{
			UnityEngine.Object.Destroy(LabcoatAttacher.newRenderer);
			LabcoatAttacher.enabled = false;
		}
		if (!Male && BikiniAttacher.enabled)
		{
			Debug.Log("Destroying Bikini's newRenderer, re-enabling MyRenderer.");
			UnityEngine.Object.Destroy(BikiniAttacher.newRenderer);
			BikiniAttacher.enabled = false;
			MyRenderer.enabled = true;
		}
		if (Schoolwear == 0)
		{
			Nude();
		}
		else if (Schoolwear == 1)
		{
			if (!Male)
			{
				Cosmetic.SetFemaleUniform();
				SkirtCollider.gameObject.SetActive(value: true);
				if (PantyCollider != null)
				{
					PantyCollider.enabled = true;
				}
				if (Club == ClubType.Bully)
				{
					Cosmetic.RightWristband.SetActive(value: true);
					Cosmetic.LeftWristband.SetActive(value: true);
					Cosmetic.Bookbag.SetActive(value: true);
					Cosmetic.Hoodie.SetActive(value: true);
				}
			}
			else
			{
				Cosmetic.SetMaleUniform();
			}
		}
		else if (Schoolwear == 2)
		{
			if (Club == ClubType.Sports && Male)
			{
				MyRenderer.sharedMesh = SwimmingTrunks;
				MyRenderer.SetBlendShapeWeight(0, 20 * (6 - ClubMemberID));
				MyRenderer.SetBlendShapeWeight(1, 20 * (6 - ClubMemberID));
				MyRenderer.materials[0].mainTexture = Cosmetic.Trunks[StudentID];
				MyRenderer.materials[1].mainTexture = Cosmetic.FaceTexture;
				MyRenderer.materials[2].mainTexture = Cosmetic.Trunks[StudentID];
			}
			else
			{
				MyRenderer.sharedMesh = SchoolSwimsuit;
				if (!Male)
				{
					Debug.Log("A female student is now changing into a swimsuit.");
					if (Club == ClubType.Bully)
					{
						MyRenderer.materials[0].mainTexture = Cosmetic.GanguroSwimsuitTextures[BullyID];
						MyRenderer.materials[1].mainTexture = Cosmetic.GanguroSwimsuitTextures[BullyID];
						Cosmetic.RightWristband.SetActive(value: false);
						Cosmetic.LeftWristband.SetActive(value: false);
						Cosmetic.Bookbag.SetActive(value: false);
						Cosmetic.Hoodie.SetActive(value: false);
					}
					else
					{
						MyRenderer.materials[0].mainTexture = SwimsuitTexture;
						MyRenderer.materials[1].mainTexture = SwimsuitTexture;
					}
					MyRenderer.materials[2].mainTexture = Cosmetic.FaceTexture;
					MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
					MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
					MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
					MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
				}
				else
				{
					MyRenderer.materials[0].mainTexture = SwimsuitTexture;
					MyRenderer.materials[1].mainTexture = Cosmetic.FaceTexture;
					MyRenderer.materials[2].mainTexture = SwimsuitTexture;
				}
			}
		}
		else if (Schoolwear == 3)
		{
			MyRenderer.sharedMesh = GymUniform;
			if (StudentManager.Eighties)
			{
				GymTexture = EightiesGymTexture;
			}
			if (!Male)
			{
				MyRenderer.materials[0].mainTexture = GymTexture;
				MyRenderer.materials[1].mainTexture = GymTexture;
				MyRenderer.materials[2].mainTexture = Cosmetic.FaceTexture;
				if (Club == ClubType.Bully)
				{
					Cosmetic.ActivateBullyAccessories();
				}
			}
			else
			{
				Debug.Log(Name + ", a male, is putting on a gym uniform.");
				MyRenderer.materials[0].mainTexture = GymTexture;
				MyRenderer.materials[2].mainTexture = Cosmetic.SkinTextures[Cosmetic.SkinColor];
				MyRenderer.materials[1].mainTexture = Cosmetic.FaceTexture;
			}
		}
		if (!Male)
		{
			Cosmetic.Stockings = ((Schoolwear == 1) ? Cosmetic.OriginalStockings : string.Empty);
			StartCoroutine(Cosmetic.PutOnStockings());
			if (GameGlobals.CensorPanties)
			{
				Cosmetic.CensorPanties();
			}
		}
		while (ID < Outlines.Length)
		{
			if (Outlines[ID] != null && Outlines[ID].h != null)
			{
				Outlines[ID].h.ReinitMaterials();
			}
			ID++;
		}
		if (Club == ClubType.Cooking)
		{
			if (Schoolwear == 1)
			{
				ApronAttacher.newRenderer.gameObject.SetActive(value: true);
			}
			else
			{
				ApronAttacher.newRenderer.gameObject.SetActive(value: false);
			}
		}
		if (Club == ClubType.LightMusic)
		{
			if (Schoolwear == 1)
			{
				InstrumentBag[ClubMemberID].gameObject.SetActive(value: true);
			}
			else
			{
				InstrumentBag[ClubMemberID].gameObject.SetActive(value: false);
			}
		}
		WalkAnim = OriginalWalkAnim;
	}

	public void AttackOnTitan()
	{
		CharacterAnimation.CrossFade(WalkAnim);
		Nape.enabled = true;
		Blind = true;
		Hurry = true;
		AoT = true;
		TargetDistance = 5f;
		SprintAnim = WalkAnim;
		RunAnim = WalkAnim;
		MyController.center = new Vector3(MyController.center.x, 0.0825f, MyController.center.z);
		MyController.radius = 0.015f;
		MyController.height = 0.15f;
		if (!Male)
		{
			Cosmetic.FaceTexture = TitanFaceTexture;
		}
		else
		{
			Cosmetic.FaceTextures[SkinColor] = TitanFaceTexture;
		}
		NudeTexture = TitanBodyTexture;
		Nude();
		for (ID = 0; ID < Outlines.Length; ID++)
		{
			if (Outlines[ID] != null)
			{
				OutlineScript outlineScript = Outlines[ID];
				if (outlineScript.h == null)
				{
					outlineScript.Awake();
				}
				outlineScript.h.ReinitMaterials();
			}
		}
		if (!Male && !Teacher)
		{
			PantyCollider.enabled = false;
			SkirtCollider.gameObject.SetActive(value: false);
		}
	}

	public void Spook()
	{
		if (!Male)
		{
			RightEye.gameObject.SetActive(value: false);
			LeftEye.gameObject.SetActive(value: false);
			MyRenderer.enabled = false;
			for (ID = 0; ID < Bones.Length; ID++)
			{
				Bones[ID].SetActive(value: true);
			}
		}
	}

	private void Unspook()
	{
		MyRenderer.enabled = true;
		for (ID = 0; ID < Bones.Length; ID++)
		{
			Bones[ID].SetActive(value: false);
		}
	}

	public void GoChange()
	{
		if (!Male)
		{
			CurrentDestination = StudentManager.StrippingPositions[GirlID];
			Pathfinding.target = StudentManager.StrippingPositions[GirlID];
		}
		else
		{
			CurrentDestination = StudentManager.MaleStripSpot;
			Pathfinding.target = StudentManager.MaleStripSpot;
		}
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		if (!SchoolwearUnavailable && !BeenSplashed)
		{
			MustChangeClothing = true;
		}
		else
		{
			Debug.Log(Name + " should not try to change clothing later on this day.");
		}
		Distracted = false;
	}

	public void SpawnAlarmDisc()
	{
		Debug.Log(base.name + " is now spawning an Alarm Disc.");
		AlarmDiscScript component = UnityEngine.Object.Instantiate(AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>();
		component.Male = Male;
		component.Originator = this;
		if (Splashed)
		{
			component.Shocking = true;
			component.NoScream = true;
		}
		if (Struggling || Shoving || MurderSuicidePhase == 100 || StudentManager.CombatMinigame.Delinquent == this)
		{
			component.NoScream = true;
		}
		if (Pushed)
		{
			component.Silent = true;
		}
		if (Club == ClubType.Delinquent)
		{
			component.Delinquent = true;
		}
		if ((Yandere.RoofPush && (bool)Yandere.TargetStudent) || Burning)
		{
			Debug.Log("Alarming death! Alarm Disc should be LOUD!");
			component.Loud = true;
		}
		if (Dying && Yandere.Equipped > 0 && Yandere.EquippedWeapon.WeaponID == 7)
		{
			component.Long = true;
		}
	}

	public void SpawnSmallAlarmDisc()
	{
		GameObject obj = UnityEngine.Object.Instantiate(AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
		obj.transform.localScale = new Vector3(100f, 1f, 100f);
		obj.GetComponent<AlarmDiscScript>().NoScream = true;
	}

	public void ChangeClubwear()
	{
		if (!ClubAttire)
		{
			Cosmetic.RemoveCensor();
			DistanceToDestination = 100f;
			ClubAttire = true;
			if (Club == ClubType.Art)
			{
				if (!Male)
				{
					RightBreast.gameObject.name = "RightBreastRENAMED";
					LeftBreast.gameObject.name = "LeftBreastRENAMED";
				}
				if (!Attacher.gameObject.activeInHierarchy)
				{
					Attacher.gameObject.SetActive(value: true);
				}
				else
				{
					Attacher.Start();
				}
			}
			else if (Club == ClubType.MartialArts)
			{
				MyRenderer.sharedMesh = JudoGiMesh;
				if (!Male)
				{
					MyRenderer.materials[0].mainTexture = Cosmetic.FaceTexture;
					MyRenderer.materials[1].mainTexture = JudoGiTexture;
					MyRenderer.materials[2].mainTexture = JudoGiTexture;
					SkirtCollider.gameObject.SetActive(value: false);
					PantyCollider.enabled = false;
					MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
				}
				else
				{
					MyRenderer.materials[0].mainTexture = JudoGiTexture;
					MyRenderer.materials[1].mainTexture = Cosmetic.FaceTexture;
					MyRenderer.materials[2].mainTexture = JudoGiTexture;
				}
			}
			else if (Club == ClubType.Science)
			{
				WearLabCoat();
			}
			else if (OriginalClub == ClubType.Sports)
			{
				if (Clock.Period < 3 || StudentManager.PoolClosed)
				{
					if (StudentManager.Eighties)
					{
						GymTexture = EightiesGymTexture;
					}
					MyRenderer.sharedMesh = GymUniform;
					if (Male)
					{
						MyRenderer.materials[0].mainTexture = GymTexture;
						MyRenderer.materials[2].mainTexture = Cosmetic.SkinTextures[Cosmetic.SkinID];
						MyRenderer.materials[1].mainTexture = Cosmetic.FaceTexture;
					}
					else
					{
						MyRenderer.materials[0].mainTexture = GymTexture;
						MyRenderer.materials[1].mainTexture = GymTexture;
						MyRenderer.materials[2].mainTexture = Cosmetic.FaceTexture;
					}
					if (Armband != null)
					{
						Armband.transform.localPosition = new Vector3(-0.1f, 0f, -0.005f);
						Physics.SyncTransforms();
					}
				}
				else
				{
					if (Armband != null)
					{
						Armband.transform.localPosition = new Vector3(-0.1f, -0.01f, 0f);
						Physics.SyncTransforms();
					}
					MyRenderer.sharedMesh = SwimmingTrunks;
					if (Male)
					{
						MyRenderer.sharedMesh = SwimmingTrunks;
						MyRenderer.SetBlendShapeWeight(0, 20 * (6 - ClubMemberID));
						MyRenderer.materials[0].mainTexture = Cosmetic.Trunks[StudentID];
						MyRenderer.materials[1].mainTexture = Cosmetic.FaceTexture;
						MyRenderer.materials[2].mainTexture = Cosmetic.Trunks[StudentID];
					}
					else
					{
						Debug.Log("A female student is now changing into a swimsuit.");
						MyRenderer.sharedMesh = SchoolSwimsuit;
						MyRenderer.materials[0].mainTexture = SwimsuitTexture;
						MyRenderer.materials[1].mainTexture = SwimsuitTexture;
						MyRenderer.materials[2].mainTexture = Cosmetic.FaceTexture;
						MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
						MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
						MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
						MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
					}
					ClubAnim = "poolDive_00";
					ClubActivityPhase = 15;
					Destinations[Phase] = StudentManager.Clubs.List[StudentID].GetChild(ClubActivityPhase);
				}
			}
			if (StudentID == 46)
			{
				Armband.transform.localPosition = new Vector3(Armband.transform.localPosition.x, Armband.transform.localPosition.y, 0.01f);
				Armband.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
			}
			return;
		}
		ClubAttire = false;
		if (Club == ClubType.Art)
		{
			Attacher.RemoveAccessory();
			return;
		}
		if (Club == ClubType.Science)
		{
			WearLabCoat();
			return;
		}
		ChangeSchoolwear();
		if (StudentID == 46)
		{
			Armband.transform.localPosition = new Vector3(-0.1f, 0f, 0f);
			Armband.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
		}
		else if (StudentID == 47 || StudentID == 49)
		{
			StudentManager.ConvoManager.BothCharactersInPosition = false;
			if (Male)
			{
				ClubAnim = "idle_20";
			}
			else
			{
				ClubAnim = "f02_idle_20";
			}
		}
	}

	private void WearLabCoat()
	{
		if (!LabcoatAttacher.enabled)
		{
			MyRenderer.sharedMesh = HeadAndHands;
			LabcoatAttacher.enabled = true;
			if (!Male)
			{
				RightBreast.gameObject.name = "RightBreastRENAMED";
				LeftBreast.gameObject.name = "LeftBreastRENAMED";
			}
			if (LabcoatAttacher.Initialized)
			{
				LabcoatAttacher.AttachAccessory();
			}
			if (!Male)
			{
				MyRenderer.materials[0].mainTexture = Cosmetic.FaceTexture;
				MyRenderer.materials[1].mainTexture = NudeTexture;
				MyRenderer.materials[2].mainTexture = null;
				HideLabCoatPanties();
			}
			else
			{
				MyRenderer.materials[0].mainTexture = Cosmetic.FaceTextures[SkinColor];
				MyRenderer.materials[1].mainTexture = NudeTexture;
				MyRenderer.materials[2].mainTexture = NudeTexture;
			}
		}
		else
		{
			if (!Male)
			{
				RightBreast.gameObject.name = "RightBreastRENAMED";
				LeftBreast.gameObject.name = "LeftBreastRENAMED";
				SkirtCollider.gameObject.SetActive(value: true);
				PantyCollider.enabled = true;
			}
			UnityEngine.Object.Destroy(LabcoatAttacher.newRenderer);
			LabcoatAttacher.enabled = false;
			ChangeSchoolwear();
		}
	}

	public void HideLabCoatPanties()
	{
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		SkirtCollider.gameObject.SetActive(value: false);
		PantyCollider.enabled = false;
	}

	public void WearBikini()
	{
		if (!BikiniAttacher.enabled)
		{
			Debug.Log("Putting bikini on now.");
			WearingBikini = true;
			BikiniAttacher.enabled = true;
			MyRenderer.enabled = false;
			RightBreast.gameObject.name = "RightBreastRENAMED";
			LeftBreast.gameObject.name = "LeftBreastRENAMED";
			if (BikiniAttacher.Initialized)
			{
				BikiniAttacher.AttachAccessory();
			}
			Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			SkirtCollider.gameObject.SetActive(value: false);
			PantyCollider.enabled = false;
		}
		else
		{
			Debug.Log("Removing bikini now.");
			WearingBikini = false;
			MyRenderer.enabled = true;
			RightBreast.gameObject.name = "RightBreastRENAMED";
			LeftBreast.gameObject.name = "LeftBreastRENAMED";
			SkirtCollider.gameObject.SetActive(value: true);
			PantyCollider.enabled = true;
			UnityEngine.Object.Destroy(BikiniAttacher.newRenderer);
			BikiniAttacher.enabled = false;
			ChangeSchoolwear();
		}
	}

	public void AttachRiggedAccessory()
	{
		RiggedAccessory.GetComponent<RiggedAccessoryAttacher>().ID = StudentID;
		if (Cosmetic.Accessory > 0)
		{
			Cosmetic.FemaleAccessories[Cosmetic.Accessory].SetActive(value: false);
		}
		if (StudentID == 26)
		{
			MyRenderer.sharedMesh = NoArmsNoTorso;
		}
		RiggedAccessory.SetActive(value: true);
	}

	public void CameraReact()
	{
		CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		Obstacle.enabled = true;
		CameraReacting = true;
		CameraReactPhase = 1;
		SpeechLines.Stop();
		Routine = false;
		StopPairing();
		if (!Sleuthing)
		{
			SmartPhone.SetActive(value: false);
		}
		OccultBook.SetActive(value: false);
		Scrubber.SetActive(value: false);
		Eraser.SetActive(value: false);
		Pen.SetActive(value: false);
		Pencil.SetActive(value: false);
		Sketchbook.SetActive(value: false);
		if (Club == ClubType.Gardening)
		{
			if (!StudentManager.Eighties || WaterLow)
			{
				WateringCan.transform.parent = Hips;
				WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
				WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
			}
		}
		else if (Club == ClubType.LightMusic)
		{
			if (StudentID == 51)
			{
				if (InstrumentBag[ClubMemberID].transform.parent == null)
				{
					Instruments[ClubMemberID].transform.parent = null;
					if (!StudentManager.Eighties)
					{
						Instruments[ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
						Instruments[ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
					}
					else
					{
						Instruments[ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
						Instruments[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
					}
					Instruments[ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
					Instruments[ClubMemberID].GetComponent<AudioSource>().Stop();
				}
				else
				{
					Instruments[ClubMemberID].SetActive(value: false);
				}
			}
			else
			{
				Instruments[ClubMemberID].SetActive(value: false);
			}
			Drumsticks[0].SetActive(value: false);
			Drumsticks[1].SetActive(value: false);
		}
		GameObject[] scienceProps = ScienceProps;
		foreach (GameObject gameObject in scienceProps)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
		scienceProps = Fingerfood;
		foreach (GameObject gameObject2 in scienceProps)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
			}
		}
		if (!Yandere.ClubAccessories[7].activeInHierarchy || Club == ClubType.Delinquent)
		{
			CharacterAnimation.CrossFade(CameraAnims[1]);
		}
		else
		{
			if (Club == ClubType.Bully)
			{
				SmartPhone.SetActive(value: true);
			}
			CharacterAnimation.CrossFade(IdleAnim);
		}
		EmptyHands();
	}

	private void LookForYandere()
	{
		if (!Yandere.Chased && CanSeeObject(Yandere.gameObject, Yandere.HeadPosition))
		{
			ReportPhase++;
		}
	}

	public void UpdatePerception()
	{
		if ((Yandere != null && Yandere.Club == ClubType.Occult) || (Yandere != null && Yandere.Class.StealthBonus > 0))
		{
			Perception = 0.5f;
		}
		else
		{
			Perception = 1f;
		}
		ChameleonCheck();
		if (Chameleon)
		{
			Perception *= 0.5f;
		}
	}

	public void StopInvestigating()
	{
		Debug.Log(Name + " was investigating something, but has stopped.");
		Giggle = null;
		if (Sleuthing && CurrentAction != StudentActionType.SitAndEatBento)
		{
			CurrentDestination = SleuthTarget;
			Pathfinding.target = SleuthTarget;
		}
		else
		{
			CurrentDestination = Destinations[Phase];
			Pathfinding.target = Destinations[Phase];
			if (Actions[Phase] == StudentActionType.Sunbathe && SunbathePhase > 1)
			{
				CurrentDestination = StudentManager.SunbatheSpots[StudentID];
				Pathfinding.target = StudentManager.SunbatheSpots[StudentID];
			}
		}
		InvestigationDistance = 0.8f;
		InvestigationTimer = 0f;
		InvestigationPhase = 0;
		if (!Hurry)
		{
			Pathfinding.speed = WalkSpeed;
		}
		else
		{
			Pathfinding.speed = 4f;
			WalkSpeed = 4f;
		}
		if (!ReturningMisplacedWeapon && Club == ClubType.Sports && CurrentAction == StudentActionType.ClubAction && ClubActivityPhase > 2 && ClubActivityPhase < 14)
		{
			Debug.Log("Student was jogging before they started investigating, and will now return to jogging.");
			Jog();
		}
		if (CurrentAction == StudentActionType.Clean)
		{
			SmartPhone.SetActive(value: false);
			Scrubber.SetActive(value: true);
			if (CleaningRole == 5)
			{
				Scrubber.GetComponent<Renderer>().material.mainTexture = Eraser.GetComponent<Renderer>().material.mainTexture;
				Eraser.SetActive(value: true);
			}
		}
		if (DistanceToDestination == 0.5f)
		{
			DistanceToDestination = 0.66666f;
		}
		YandereInnocent = false;
		Investigating = false;
		EatingSnack = false;
		HeardScream = false;
		DiscCheck = false;
		Routine = true;
		TargetDistance = 0.5f;
		if (BeforeReturnAnim != "")
		{
			WalkAnim = BeforeReturnAnim;
		}
		if (SearchingForPhone)
		{
			PatrolID = 0;
		}
	}

	public void Jog()
	{
		string text = "";
		if (!Male)
		{
			text = "f02_";
		}
		WalkAnim = text + "trackJog_00";
		Hurry = true;
		CharacterAnimation[ClubAnim].time = 0f;
		CurrentDestination = Destinations[Phase];
		Pathfinding.speed = 4f;
	}

	public void ForgetGiggle()
	{
		Debug.Log(Name + " was just told to ForgetGiggle() and stop investigating.");
		Giggle = null;
		InvestigationTimer = 0f;
		InvestigationPhase = 0;
		YandereInnocent = false;
		Investigating = false;
		DiscCheck = false;
	}

	private bool LovedOneIsTargeted(int yandereTargetID)
	{
		bool flag = StudentID == StudentManager.SuitorID && yandereTargetID == StudentManager.RivalID;
		if (StudentManager.KokonaTutorial)
		{
			return false;
		}
		if (!StudentManager.Eighties)
		{
			bool num = InCouple && PartnerID == yandereTargetID;
			bool flag2 = StudentID == 3 && yandereTargetID == 2;
			bool flag3 = StudentID == 2 && yandereTargetID == 3;
			if (StudentID == 11)
			{
				_ = yandereTargetID == 10;
			}
			else
				_ = 0;
			bool flag4 = StudentID == 38 && yandereTargetID == 37;
			bool flag5 = StudentID == 37 && yandereTargetID == 38;
			bool flag6 = StudentID == 30 && yandereTargetID == 25;
			bool flag7 = StudentID == 25 && yandereTargetID == 30;
			bool flag8 = StudentID == 28 && yandereTargetID == 30;
			bool flag9 = false;
			bool flag10 = StudentID > 55 && StudentID < 61 && yandereTargetID > 55 && yandereTargetID < 61;
			if (Injured)
			{
				flag9 = Club == ClubType.Delinquent && StudentManager.Students[yandereTargetID].Club == ClubType.Delinquent;
			}
			return num || flag2 || flag3 || flag4 || flag5 || flag6 || flag7 || flag8 || flag9 || flag10 || flag;
		}
		bool flag11 = false;
		flag11 = Male && yandereTargetID == 19;
		return flag || flag11;
	}

	private void Pose()
	{
		StudentManager.PoseMode.ChoosingAction = true;
		StudentManager.PoseMode.Panel.enabled = true;
		StudentManager.PoseMode.Student = this;
		StudentManager.PoseMode.UpdateLabels();
		StudentManager.PoseMode.Show = true;
		DialogueWheel.PromptBar.ClearButtons();
		DialogueWheel.PromptBar.Label[0].text = "Confirm";
		DialogueWheel.PromptBar.Label[1].text = "Back";
		DialogueWheel.PromptBar.Label[4].text = "Change";
		DialogueWheel.PromptBar.Label[5].text = "Increase/Decrease";
		DialogueWheel.PromptBar.UpdateButtons();
		DialogueWheel.PromptBar.Show = true;
		Yandere.Character.GetComponent<Animation>().CrossFade(Yandere.IdleAnim);
		Yandere.CanMove = false;
		Posing = true;
		SimpleLook.enabled = false;
	}

	public void DisableEffects()
	{
		LiquidProjector.enabled = false;
		if (ElectroSteam.Length != 0)
		{
			ElectroSteam[0].SetActive(value: false);
			ElectroSteam[1].SetActive(value: false);
			ElectroSteam[2].SetActive(value: false);
			ElectroSteam[3].SetActive(value: false);
		}
		if (CensorSteam.Length != 0)
		{
			CensorSteam[0].SetActive(value: false);
			CensorSteam[1].SetActive(value: false);
			CensorSteam[2].SetActive(value: false);
			CensorSteam[3].SetActive(value: false);
		}
		ParticleSystem[] liquidEmitters = LiquidEmitters;
		for (int i = 0; i < liquidEmitters.Length; i++)
		{
			liquidEmitters[i].gameObject.SetActive(value: false);
		}
		liquidEmitters = FireEmitters;
		for (int i = 0; i < liquidEmitters.Length; i++)
		{
			liquidEmitters[i].gameObject.SetActive(value: false);
		}
		for (ID = 0; ID < Bones.Length; ID++)
		{
			if (Bones[ID] != null)
			{
				Bones[ID].SetActive(value: false);
			}
		}
		if (Persona != PersonaType.PhoneAddict)
		{
			SmartPhone.SetActive(value: false);
		}
		Note.SetActive(value: false);
		SetSplashes(Bool: false);
		if (!Slave)
		{
			UnityEngine.Object.Destroy(Broken);
		}
	}

	public void DetermineSenpaiReaction()
	{
		Debug.Log("We are now determining Senpai's reaction to Yandere-chan's behavior.");
		if (StudentManager.ChallengeManager.NoAlerts)
		{
			Subtitle.CustomText = "You alarmed a student! You have failed the ''NO ALERTS'' Challenge.";
			Subtitle.UpdateLabel(SubtitleType.Custom, 1, 4.5f);
		}
		if (Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
		}
		else if (Witnessed == StudentWitnessType.WeaponAndBlood)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
		}
		else if (Witnessed == StudentWitnessType.WeaponAndInsanity)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
		}
		else if (Witnessed == StudentWitnessType.BloodAndInsanity)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
		}
		else if (Witnessed == StudentWitnessType.Weapon)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
		}
		else if (Witnessed == StudentWitnessType.Blood)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiBloodReaction, 1, 4.5f);
		}
		else if (Witnessed == StudentWitnessType.Insanity)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
		}
		else if (Witnessed == StudentWitnessType.Lewd || Witnessed == StudentWitnessType.Poisoning || Witnessed == StudentWitnessType.Pickpocketing || Witnessed == StudentWitnessType.Theft)
		{
			Debug.Log("Senpai is supposed to choose the ''Lewd'' reaction now.");
			Subtitle.UpdateLabel(SubtitleType.SenpaiLewdReaction, 1, 4.5f);
		}
		else if (GameOverCause == GameOverType.Stalking)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, Concern, 4.5f);
		}
		else if (GameOverCause == GameOverType.Murder)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiMurderReaction, MurderReaction, 4.5f);
		}
		else if (GameOverCause == GameOverType.Violence)
		{
			Subtitle.UpdateLabel(SubtitleType.SenpaiViolenceReaction, 1, 4.5f);
		}
	}

	public void ForgetRadio()
	{
		bool flag = false;
		if (CurrentAction == StudentActionType.Sunbathe && SunbathePhase > 2)
		{
			SunbathePhase = 2;
			flag = true;
		}
		if (((Persona == PersonaType.PhoneAddict && !Phoneless && !flag) || Persona == PersonaType.Sleuth || StudentID == 20) && !Phoneless)
		{
			SmartPhone.SetActive(value: true);
		}
		TurnOffRadio = false;
		RadioTimer = 0f;
		RadioPhase = 1;
		Routine = true;
		Radio = null;
	}

	public void RealizePhoneIsMissing()
	{
		Debug.Log(Name + " is updating their routine to involve ''Search Patrol''.");
		MustChangeClothing = false;
		SearchingForPhone = true;
		Phoneless = true;
		PatrolID = 0;
		ScheduleBlock obj = ScheduleBlocks[2];
		obj.destination = "Search Patrol";
		obj.action = "Search Patrol";
		ScheduleBlock obj2 = ScheduleBlocks[4];
		obj2.destination = "Search Patrol";
		obj2.action = "Search Patrol";
		ScheduleBlock obj3 = ScheduleBlocks[7];
		obj3.destination = "Search Patrol";
		obj3.action = "Search Patrol";
		GetDestinations();
		CurrentAction = StudentActionType.SearchPatrol;
	}

	public void TeleportToDestination()
	{
		GetDestinations();
		_ = Phase;
		_ = 2;
		if (Phase < ScheduleBlocks.Length && Clock.HourTime >= ScheduleBlocks[Phase].time)
		{
			Phase++;
			if (Actions[Phase] == StudentActionType.Patrol || (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Gardening))
			{
				CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
				Pathfinding.target = CurrentDestination;
			}
			else
			{
				CurrentDestination = Destinations[Phase];
				Pathfinding.target = Destinations[Phase];
			}
			if (CurrentDestination != null)
			{
				base.transform.position = CurrentDestination.position;
			}
		}
	}

	public void AltTeleportToDestination()
	{
		if (Club == ClubType.Council)
		{
			return;
		}
		Phase++;
		if (Club == ClubType.Bully)
		{
			ScheduleBlock obj = ScheduleBlocks[2];
			obj.destination = "Patrol";
			obj.action = "Patrol";
		}
		GetDestinations();
		CurrentAction = Actions[Phase];
		if (CurrentAction == StudentActionType.Patrol || (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Gardening))
		{
			CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
			Pathfinding.target = CurrentDestination;
			base.transform.position = CurrentDestination.position;
		}
		else if (Destinations[Phase] != null)
		{
			CurrentDestination = Destinations[Phase];
			Pathfinding.target = Destinations[Phase];
			if (StudentID == 8)
			{
				base.transform.position = CurrentDestination.position;
			}
			Physics.SyncTransforms();
		}
		else
		{
			Debug.Log(Name + "'s destination for this phase of the day is null. Problem?");
		}
	}

	public void GoCommitMurder()
	{
		Debug.Log("A mind-broken slave has just been instructed to go kill somebody.");
		StudentManager.MurderTakingPlace = true;
		StudentManager.MindBrokenSlave = this;
		Debug.Log("MurderTakingPlace should now be true!");
		StudentManager.UpdateTeachers();
		if (!FragileSlave && !Yandere.Succubus)
		{
			Yandere.EquippedWeapon.transform.parent = HipCollider.transform;
			Yandere.EquippedWeapon.transform.localPosition = Vector3.zero;
			Yandere.EquippedWeapon.transform.localScale = Vector3.zero;
			MyWeapon = Yandere.EquippedWeapon;
			MyWeapon.FingerprintID = StudentID;
			Yandere.EquippedWeapon = null;
			Yandere.Equipped = 0;
			StudentManager.UpdateStudents();
			Yandere.WeaponManager.UpdateLabels();
			Yandere.WeaponMenu.UpdateSprites();
			Yandere.WeaponWarning = false;
		}
		else
		{
			StudentManager.FragileWeapon.transform.parent = HipCollider.transform;
			StudentManager.FragileWeapon.transform.localPosition = Vector3.zero;
			StudentManager.FragileWeapon.transform.localScale = Vector3.zero;
			MyWeapon = StudentManager.FragileWeapon;
			MyWeapon.FingerprintID = StudentID;
			MyWeapon.MyCollider.enabled = false;
		}
		CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		if (!Male)
		{
			CharacterAnimation.CrossFade("f02_brokenStandUp_00");
			MurderSuicideAnim = "f02_murderSuicide_00";
		}
		else
		{
			MurderSuicideAnim = "murderSuicide_00";
		}
		if (HuntTarget != this)
		{
			DistanceToDestination = 100f;
			if (!Male)
			{
				Broken.Hunting = true;
			}
			TargetDistance = 1f;
			Routine = false;
			Hunting = true;
		}
		else
		{
			if (!Male)
			{
				Broken.Done = true;
			}
			Routine = false;
			Suicide = true;
		}
		Prompt.Hide();
		Prompt.enabled = false;
		if (NEStairs == null)
		{
			NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
			NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
			SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
			SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
			PoolStairs = GameObject.Find("PoolStairs").GetComponent<Collider>();
		}
	}

	public void Shove()
	{
		if (!Yandere.Shoved && !Dying && !Yandere.Egg && !Yandere.Lifting && !Yandere.SneakingShot && !ShoeRemoval.enabled && !Yandere.Talking && !SentToLocker)
		{
			if (Giggle != null)
			{
				ForgetGiggle();
			}
			ForgetRadio();
			GetComponent<AudioSource>();
			if (StudentID == 86)
			{
				Subtitle.UpdateLabel(SubtitleType.Shoving, 1, 5f);
			}
			else if (StudentID == 87)
			{
				Subtitle.UpdateLabel(SubtitleType.Shoving, 2, 5f);
			}
			else if (StudentID == 88)
			{
				Subtitle.UpdateLabel(SubtitleType.Shoving, 3, 5f);
			}
			else if (StudentID == 89)
			{
				Subtitle.UpdateLabel(SubtitleType.Shoving, 4, 5f);
			}
			if (Yandere.Aiming)
			{
				Yandere.StopAiming();
			}
			if (Yandere.Laughing)
			{
				Yandere.StopLaughing();
			}
			if (Yandere.Stance.Current != 0)
			{
				Yandere.Stance.Current = StanceType.Standing;
				Yandere.CrawlTimer = 0f;
				Yandere.Uncrouch();
			}
			base.transform.rotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
			Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(Hips.transform.position.x, Yandere.transform.position.y, Hips.transform.position.z) - Yandere.transform.position);
			CharacterAnimation[ShoveAnim].time = 0f;
			CharacterAnimation.CrossFade(ShoveAnim);
			FocusOnStudent = false;
			FocusOnYandere = false;
			Investigating = false;
			Distracted = true;
			Alarmed = false;
			Routine = false;
			Shoving = true;
			NoTalk = false;
			Patience--;
			if (StudentManager.BloodReporter == this)
			{
				StudentManager.BloodReporter = null;
				ReportingBlood = false;
			}
			if (Club == ClubType.Delinquent && (WitnessedBloodPool || FoundEnemyCorpse))
			{
				StudentManager.CombatMinigame.ExitSchoolWhenDone = true;
			}
			WitnessedBloodyWeapon = false;
			WitnessedBloodPool = false;
			WitnessedSomething = false;
			WitnessedMurder = false;
			WitnessedWeapon = false;
			WitnessedLimb = false;
			BloodPool = null;
			if (Club != ClubType.Council && Persona != PersonaType.Violent && StudentID != 20)
			{
				Debug.Log("Patience shot up to 999.");
				Patience = 999;
			}
			if (Patience < 1)
			{
				Yandere.CannotRecover = true;
			}
			if (ReturningMisplacedWeapon)
			{
				DropMisplacedWeapon();
			}
			if (StudentManager.Eighties && StudentID > 85 && StudentID < 89)
			{
				Yandere.ShoveAnim = "f02_shoveA_01";
			}
			else
			{
				Yandere.ShoveAnim = "f02_shoveA_01";
			}
			Yandere.CharacterAnimation[Yandere.ShoveAnim].time = 0f;
			Yandere.CharacterAnimation.CrossFade(Yandere.ShoveAnim);
			Yandere.YandereVision = false;
			Yandere.NearSenpai = false;
			Yandere.Degloving = false;
			Yandere.Flicking = false;
			Yandere.Punching = false;
			Yandere.CanMove = false;
			Yandere.Shoved = true;
			if (Yandere.PickUp != null && Yandere.PickUp.PreventTipping)
			{
				Debug.Log("She's holding a water cooler. Don't do a god damn thing.");
			}
			else
			{
				Yandere.EmptyHands();
			}
			Yandere.GloveTimer = 0f;
			Yandere.h = 0f;
			Yandere.v = 0f;
			Yandere.ShoveSpeed = 2f;
			if (Distraction != null)
			{
				TargetedForDistraction = false;
				Pathfinding.speed = WalkSpeed;
				SpeechLines.Stop();
				Distraction = null;
				CanTalk = true;
			}
			if (Actions[Phase] != StudentActionType.Patrol)
			{
				CurrentDestination = Destinations[Phase];
				Pathfinding.target = CurrentDestination;
			}
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
		}
	}

	public void PushYandereAway()
	{
		if (Yandere.Aiming)
		{
			Yandere.StopAiming();
		}
		if (Yandere.Laughing)
		{
			Yandere.StopLaughing();
		}
		Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(Hips.transform.position.x, Yandere.transform.position.y, Hips.transform.position.z) - Yandere.transform.position);
		Yandere.CharacterAnimation["f02_shoveA_01"].time = 0f;
		Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
		Yandere.YandereVision = false;
		Yandere.NearSenpai = false;
		Yandere.Degloving = false;
		Yandere.Flicking = false;
		Yandere.Punching = false;
		Yandere.CanMove = false;
		Yandere.Shoved = true;
		Yandere.EmptyHands();
		Yandere.GloveTimer = 0f;
		Yandere.h = 0f;
		Yandere.v = 0f;
		Yandere.ShoveSpeed = 2f;
	}

	public void Spray()
	{
		Debug.Log(Name + " is trying to Spray Yandere-chan!");
		if (Yandere.Attacking || Yandere.Struggling)
		{
			CharacterAnimation.CrossFade(ReadyToFightAnim);
			return;
		}
		bool flag = false;
		if (Yandere.DelinquentFighting && !NoBreakUp && !StudentManager.CombatMinigame.Delinquent.WitnessedMurder)
		{
			flag = true;
		}
		if (!flag)
		{
			if (!Yandere.Sprayed && !Dying && !Blind && !Yandere.Egg && !Yandere.Dumping && !Yandere.Bathing && !Yandere.Noticed && !Yandere.CannotBeSprayed)
			{
				if (SprayTimer > 0f)
				{
					SprayTimer = Mathf.MoveTowards(SprayTimer, 0f, Time.deltaTime);
				}
				else
				{
					AudioSource.PlayClipAtPoint(PepperSpraySFX, base.transform.position);
					if (StudentID == 86)
					{
						Subtitle.UpdateLabel(SubtitleType.Spraying, 1, 5f);
					}
					else if (StudentID == 87)
					{
						Subtitle.UpdateLabel(SubtitleType.Spraying, 2, 5f);
					}
					else if (StudentID == 88)
					{
						Subtitle.UpdateLabel(SubtitleType.Spraying, 3, 5f);
					}
					else if (StudentID == 89)
					{
						Subtitle.UpdateLabel(SubtitleType.Spraying, 4, 5f);
					}
					if (Yandere.Aiming)
					{
						Yandere.StopAiming();
					}
					if (Yandere.Laughing)
					{
						Yandere.StopLaughing();
					}
					base.transform.rotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
					Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(Hips.transform.position.x, Yandere.transform.position.y, Hips.transform.position.z) - Yandere.transform.position);
					Debug.Log("This is the exact moment that the character is being told to perform a spraying animation.");
					if (SprayAnim == "")
					{
						if (Male)
						{
							SprayAnim = "spray_00";
						}
						else
						{
							SprayAnim = "f02_sprayCouncilEdgy_00";
						}
					}
					CharacterAnimation.CrossFade(SprayAnim);
					PepperSpray.SetActive(value: true);
					FocusOnStudent = false;
					FocusOnYandere = false;
					Distracted = true;
					Spraying = true;
					Alarmed = false;
					Routine = false;
					Fleeing = true;
					Blind = true;
					Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
					Yandere.YandereVision = false;
					Yandere.NearSenpai = false;
					Yandere.Attacking = false;
					Yandere.FollowHips = true;
					Yandere.Punching = false;
					Yandere.CanMove = false;
					Yandere.Sprayed = true;
					Pathfinding.canSearch = false;
					Pathfinding.canMove = false;
					StudentManager.YandereDying = true;
					StudentManager.StopMoving();
					Yandere.Blur.Size = 1f;
					Yandere.Jukebox.Volume = 0f;
					if (Yandere.DelinquentFighting)
					{
						StudentManager.CombatMinigame.Stop();
					}
					DetectionMarker.gameObject.SetActive(value: false);
					if (SmartPhone != null && SmartPhone.activeInHierarchy)
					{
						SmartPhone.SetActive(value: false);
					}
				}
			}
			else if (!Yandere.Sprayed)
			{
				CharacterAnimation.CrossFade(ReadyToFightAnim);
				if (Yandere.Egg)
				{
					Yandere.CanMove = true;
					Yandere.Chased = false;
					Yandere.Chasers = 0;
					BecomeRagdoll();
				}
			}
		}
		else
		{
			Debug.Log("A student council member is breaking up the fight.");
			if (StudentManager.CombatMinigame.Delinquent.Male)
			{
				StudentManager.CombatMinigame.Delinquent.CharacterAnimation.Play("stopFighting_00");
				StudentManager.CombatMinigame.StopFightingAnim = "stopFighting_00";
			}
			else
			{
				StudentManager.CombatMinigame.Delinquent.CharacterAnimation.Play("f02_stopFighting_00");
				StudentManager.CombatMinigame.StopFightingAnim = "f02_stopFighting_00";
			}
			Yandere.CharacterAnimation.Play("f02_stopFighting_00");
			Yandere.FightHasBrokenUp = true;
			Yandere.BreakUpTimer = 10f;
			StudentManager.CombatMinigame.Path = 7;
			StudentManager.Portal.SetActive(value: true);
			if (!BreakingUpFight && Club == ClubType.Council)
			{
				Subtitle.UpdateLabel(SubtitleType.BreakingUp, ClubMemberID, 5f);
			}
			CharacterAnimation.Play(BreakUpAnim);
			BreakingUpFight = true;
			SprayTimer = 1f;
		}
		StudentManager.CombatMinigame.DisablePrompts();
		StudentManager.CombatMinigame.MyVocals.Stop();
		StudentManager.CombatMinigame.MyAudio.Stop();
		Time.timeScale = 1f;
	}

	private void DetermineCorpseLocation()
	{
		Debug.Log(Name + " has called the DetermineCorpseLocation() function.");
		if (StudentManager.Reporter == null)
		{
			StudentManager.Reporter = this;
		}
		if (Teacher)
		{
			StudentManager.CorpseLocation.position = Corpse.AllColliders[0].transform.position;
			StudentManager.CorpseLocation.LookAt(new Vector3(base.transform.position.x, StudentManager.CorpseLocation.position.y, base.transform.position.z));
			StudentManager.CorpseLocation.Translate(StudentManager.CorpseLocation.forward);
			StudentManager.LowerCorpsePosition();
		}
		if (ExamineCorpseTarget == null)
		{
			Pathfinding.target = StudentManager.CorpseLocation;
			CurrentDestination = StudentManager.CorpseLocation;
		}
		AssignCorpseGuardLocations();
	}

	private void DetermineBloodLocation()
	{
		Debug.Log(Name + " is now firing DetermineBloodLocation().");
		if (StudentManager.BloodReporter == null)
		{
			StudentManager.BloodReporter = this;
		}
		if (Teacher)
		{
			StudentManager.BloodLocation.position = BloodPool.transform.position;
			StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, StudentManager.BloodLocation.position.y, base.transform.position.z));
			StudentManager.BloodLocation.Translate(StudentManager.BloodLocation.forward, Space.World);
			StudentManager.LowerBloodPosition();
		}
	}

	private void AssignCorpseGuardLocations()
	{
		StudentManager.CorpseGuardLocation[1].position = StudentManager.CorpseLocation.position + new Vector3(0f, 0f, 1f);
		LookAway(StudentManager.CorpseGuardLocation[1], StudentManager.CorpseLocation);
		StudentManager.CorpseGuardLocation[2].position = StudentManager.CorpseLocation.position + new Vector3(1f, 0f, 0f);
		LookAway(StudentManager.CorpseGuardLocation[2], StudentManager.CorpseLocation);
		StudentManager.CorpseGuardLocation[3].position = StudentManager.CorpseLocation.position + new Vector3(0f, 0f, -1f);
		LookAway(StudentManager.CorpseGuardLocation[3], StudentManager.CorpseLocation);
		StudentManager.CorpseGuardLocation[4].position = StudentManager.CorpseLocation.position + new Vector3(-1f, 0f, 0f);
		LookAway(StudentManager.CorpseGuardLocation[4], StudentManager.CorpseLocation);
	}

	private void AssignBloodGuardLocations()
	{
		StudentManager.BloodGuardLocation[1].position = StudentManager.BloodLocation.position + new Vector3(0f, 0f, 1f);
		LookAway(StudentManager.BloodGuardLocation[1], StudentManager.BloodLocation);
		StudentManager.BloodGuardLocation[2].position = StudentManager.BloodLocation.position + new Vector3(1f, 0f, 0f);
		LookAway(StudentManager.BloodGuardLocation[2], StudentManager.BloodLocation);
		StudentManager.BloodGuardLocation[3].position = StudentManager.BloodLocation.position + new Vector3(0f, 0f, -1f);
		LookAway(StudentManager.BloodGuardLocation[3], StudentManager.BloodLocation);
		StudentManager.BloodGuardLocation[4].position = StudentManager.BloodLocation.position + new Vector3(-1f, 0f, 0f);
		LookAway(StudentManager.BloodGuardLocation[4], StudentManager.BloodLocation);
	}

	private void AssignTeacherGuardLocations()
	{
		StudentManager.TeacherGuardLocation[1].position = StudentManager.CorpseLocation.position + new Vector3(0.75f, 0f, 0.75f);
		LookAway(StudentManager.TeacherGuardLocation[1], StudentManager.CorpseLocation);
		StudentManager.TeacherGuardLocation[2].position = StudentManager.CorpseLocation.position + new Vector3(0.75f, 0f, -0.75f);
		LookAway(StudentManager.TeacherGuardLocation[2], StudentManager.CorpseLocation);
		StudentManager.TeacherGuardLocation[3].position = StudentManager.CorpseLocation.position + new Vector3(-0.75f, 0f, -0.75f);
		LookAway(StudentManager.TeacherGuardLocation[3], StudentManager.CorpseLocation);
		StudentManager.TeacherGuardLocation[4].position = StudentManager.CorpseLocation.position + new Vector3(-0.75f, 0f, 0.75f);
		LookAway(StudentManager.TeacherGuardLocation[4], StudentManager.CorpseLocation);
		StudentManager.TeacherGuardLocation[5].position = StudentManager.CorpseLocation.position + new Vector3(0f, 0f, 0.5f);
		LookAway(StudentManager.TeacherGuardLocation[5], StudentManager.CorpseLocation);
		StudentManager.TeacherGuardLocation[6].position = StudentManager.CorpseLocation.position + new Vector3(0f, 0f, -0.5f);
		LookAway(StudentManager.TeacherGuardLocation[6], StudentManager.CorpseLocation);
	}

	private void LookAway(Transform T1, Transform T2)
	{
		T1.LookAt(T2);
		float y = T1.eulerAngles.y + 180f;
		T1.eulerAngles = new Vector3(T1.eulerAngles.x, y, T1.eulerAngles.z);
	}

	public void TurnToStone()
	{
		Cosmetic.RightEyeRenderer.material.mainTexture = Yandere.Stone;
		Cosmetic.LeftEyeRenderer.material.mainTexture = Yandere.Stone;
		Cosmetic.HairRenderer.material.mainTexture = Yandere.Stone;
		if (Cosmetic.HairRenderer.materials.Length > 1)
		{
			Cosmetic.HairRenderer.materials[1].mainTexture = Yandere.Stone;
		}
		Cosmetic.RightEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		Cosmetic.LeftEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		Cosmetic.HairRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		MyRenderer.materials[0].mainTexture = Yandere.Stone;
		MyRenderer.materials[1].mainTexture = Yandere.Stone;
		MyRenderer.materials[2].mainTexture = Yandere.Stone;
		if (Teacher && Cosmetic.TeacherAccessories[8].activeInHierarchy)
		{
			MyRenderer.materials[3].mainTexture = Yandere.Stone;
		}
		if (PickPocket != null)
		{
			PickPocket.enabled = false;
			PickPocket.Prompt.Hide();
			PickPocket.Prompt.enabled = false;
		}
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		UnityEngine.Object.Destroy(DetectionMarker.gameObject);
		AudioSource.PlayClipAtPoint(Yandere.Petrify, base.transform.position + new Vector3(0f, 1f, 0f));
		UnityEngine.Object.Instantiate(Yandere.Pebbles, Hips.position, Quaternion.identity);
		Pathfinding.enabled = false;
		ShoeRemoval.enabled = false;
		CharacterAnimation.Stop();
		Prompt.enabled = false;
		SpeechLines.Stop();
		Prompt.Hide();
		base.enabled = false;
	}

	public void StopPairing()
	{
		if (Actions[Phase] != StudentActionType.Clean && Persona == PersonaType.PhoneAddict && !Phoneless && !LostTeacherTrust && !StudentManager.Eighties)
		{
			WalkAnim = PhoneAnims[1];
		}
		Spawned = true;
		Paired = false;
	}

	public void ChameleonCheck()
	{
		ChameleonBonus = 0f;
		Chameleon = false;
		if (Yandere != null && ((Yandere.Persona == YanderePersonaType.Scholarly && Persona == PersonaType.TeachersPet) || (Yandere.Persona == YanderePersonaType.Scholarly && Club == ClubType.Science) || (Yandere.Persona == YanderePersonaType.Scholarly && Club == ClubType.Art) || (Yandere.Persona == YanderePersonaType.Chill && Persona == PersonaType.SocialButterfly) || (Yandere.Persona == YanderePersonaType.Chill && Club == ClubType.Photography) || (Yandere.Persona == YanderePersonaType.Chill && Club == ClubType.Gaming) || (Yandere.Persona == YanderePersonaType.Confident && Persona == PersonaType.Heroic) || (Yandere.Persona == YanderePersonaType.Confident && Club == ClubType.MartialArts) || (Yandere.Persona == YanderePersonaType.Elegant && Club == ClubType.Drama) || (Yandere.Persona == YanderePersonaType.Girly && Persona == PersonaType.SocialButterfly) || (Yandere.Persona == YanderePersonaType.Girly && Club == ClubType.Cooking) || (Yandere.Persona == YanderePersonaType.Graceful && Club == ClubType.Gardening) || (Yandere.Persona == YanderePersonaType.Haughty && Club == ClubType.Bully) || (Yandere.Persona == YanderePersonaType.Lively && Persona == PersonaType.SocialButterfly) || (Yandere.Persona == YanderePersonaType.Lively && Club == ClubType.LightMusic) || (Yandere.Persona == YanderePersonaType.Lively && Club == ClubType.Sports) || (Yandere.Persona == YanderePersonaType.Shy && Persona == PersonaType.Loner) || (Yandere.Persona == YanderePersonaType.Shy && Club == ClubType.Occult) || (Yandere.Persona == YanderePersonaType.Tough && Persona == PersonaType.Spiteful) || (Yandere.Persona == YanderePersonaType.Tough && Club == ClubType.Delinquent)))
		{
			ChameleonBonus = VisionDistance * 0.5f;
			Chameleon = true;
		}
	}

	private void PhoneAddictGameOver()
	{
		if (!Yandere.Lost && !Yandere.ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
		{
			Yandere.CharacterAnimation.CrossFade("f02_down_22");
			Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(value: true);
			Yandere.RPGCamera.enabled = false;
			Yandere.Jukebox.GameOver();
			Yandere.enabled = false;
			Yandere.EmptyHands();
			Countdown.gameObject.SetActive(value: false);
			ChaseCamera.SetActive(value: false);
			Police.Heartbroken.Exposed = true;
			StudentManager.StopMoving();
			Fleeing = false;
		}
	}

	private void EndAlarm()
	{
		Debug.Log(Name + " just fired the EndAlarm() function.");
		if (ReturnToRoutineAfter)
		{
			CurrentDestination = Destinations[Phase];
			Pathfinding.target = Destinations[Phase];
			ReturnToRoutineAfter = false;
		}
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		if (TurnOffRadio)
		{
			RadioTimer = 3f;
		}
		if (StudentID == 1 || Teacher)
		{
			IgnoreTimer = 0.0001f;
		}
		else
		{
			IgnoreTimer = 5f;
		}
		if (Persona == PersonaType.PhoneAddict && !Phoneless)
		{
			SmartPhone.SetActive(value: true);
		}
		FocusOnStudent = false;
		FocusOnYandere = false;
		DiscCheck = false;
		Alarmed = false;
		Reacted = false;
		Hesitation = 0f;
		AlarmTimer = 0f;
		if (WitnessedCorpse)
		{
			PersonaReaction();
		}
		else if (WitnessedBloodPool || WitnessedLimb || WitnessedWeapon)
		{
			Debug.Log(Name + " will now investigate a suspicious object on the ground...");
			if (Following)
			{
				ParticleSystem.EmissionModule emission = Hearts.emission;
				emission.enabled = false;
				FollowCountdown.gameObject.SetActive(value: false);
				Yandere.Follower = null;
				Yandere.Followers--;
				Following = false;
			}
			if (BeforeReturnAnim == "")
			{
				BeforeReturnAnim = WalkAnim;
			}
			WalkAnim = OriginalWalkAnim;
			CharacterAnimation.CrossFade(WalkAnim);
			CurrentDestination = BloodPool;
			Pathfinding.target = BloodPool;
			Pathfinding.canSearch = true;
			Pathfinding.canMove = true;
			WalkSpeed = 1f;
			Pathfinding.speed = WalkSpeed;
			InvestigatingBloodPool = true;
			Routine = false;
			IgnoreTimer = 0.0001f;
		}
		else if (!Following && !Wet && !Investigating)
		{
			Routine = true;
		}
		if (ResumeDistracting)
		{
			Debug.Log(Name + " was told to resume distracting.");
			CharacterAnimation.CrossFade(WalkAnim);
			Distracting = true;
			Routine = false;
			CurrentDestination = DistractionTarget.transform;
			Pathfinding.target = DistractionTarget.transform;
			ResumeDistracting = false;
		}
		if (ResumeTakingOutTrash)
		{
			Debug.Log("This character was told to resume taking out the trash.");
			CharacterAnimation.CrossFade(WalkAnim);
			TakingOutTrash = true;
			Routine = false;
		}
		if (CurrentAction == StudentActionType.Clean)
		{
			SmartPhone.SetActive(value: false);
			Scrubber.SetActive(value: true);
			if (CleaningRole == 5)
			{
				Scrubber.GetComponent<Renderer>().material.mainTexture = Eraser.GetComponent<Renderer>().material.mainTexture;
				Eraser.SetActive(value: true);
			}
		}
		if (TurnOffRadio)
		{
			Routine = false;
		}
	}

	public void GetSleuthTarget()
	{
		if (!SleuthInitialized)
		{
			SleuthInitialized = true;
			GetInitialSleuthTarget();
		}
		WalkAnim = SleuthWalkAnim;
		TargetDistance = 2f;
		SleuthID++;
		if (SleuthID < 98)
		{
			if (StudentManager.Students[SleuthID] == null)
			{
				GetSleuthTarget();
				return;
			}
			if (!StudentManager.Students[SleuthID].gameObject.activeInHierarchy)
			{
				GetSleuthTarget();
				return;
			}
			if ((CurrentDestination != null && StudentManager.LockerRoomArea.bounds.Contains(CurrentDestination.position)) || (CurrentDestination != null && StudentManager.MaleLockerRoomArea.bounds.Contains(CurrentDestination.position)))
			{
				GetSleuthTarget();
				return;
			}
			SleuthTarget = StudentManager.Students[SleuthID].transform;
			Pathfinding.target = SleuthTarget;
			CurrentDestination = SleuthTarget;
		}
		else if (SleuthID == 98)
		{
			if (Yandere.Club == ClubType.Photography)
			{
				SleuthID = 0;
				GetSleuthTarget();
				return;
			}
			Debug.Log(Name + "'s SleuthTarget became the player...");
			SleuthTarget = Yandere.transform;
			Pathfinding.target = SleuthTarget;
			CurrentDestination = SleuthTarget;
		}
		else
		{
			SleuthID = 0;
			GetSleuthTarget();
		}
	}

	public void GetFoodTarget()
	{
		Attempts++;
		if (Attempts >= 100)
		{
			Debug.Log(Name + " is now giving up on attempting to select a person to give food to.");
			Routine = true;
			Phase++;
			return;
		}
		SleuthID++;
		if (SleuthID < 90)
		{
			if (SleuthID == StudentID)
			{
				GetFoodTarget();
			}
			else if (StudentManager.Students[SleuthID] == null)
			{
				GetFoodTarget();
			}
			else if (!StudentManager.Students[SleuthID].gameObject.activeInHierarchy)
			{
				GetFoodTarget();
			}
			else if (StudentManager.Students[SleuthID].CurrentAction == StudentActionType.SitAndEatBento || StudentManager.Students[SleuthID].CurrentAction == StudentActionType.AtLocker || StudentManager.Students[SleuthID].CurrentDestination == StudentManager.Exit || StudentManager.Students[SleuthID].Club == ClubType.Cooking || StudentManager.Students[SleuthID].Club == ClubType.Delinquent || StudentManager.Students[SleuthID].Club == ClubType.Sports || StudentManager.Students[SleuthID].TargetedForDistraction || StudentManager.Students[SleuthID].ClubActivityPhase >= 16 || StudentManager.Students[SleuthID].InEvent || !StudentManager.Students[SleuthID].Routine || StudentManager.Students[SleuthID].Posing || StudentManager.Students[SleuthID].Slave || StudentManager.Students[SleuthID].Wet || StudentManager.Students[SleuthID].Sedated || StudentManager.Students[SleuthID].DoNotFeed || StudentManager.Students[SleuthID].AlreadyFed || (StudentManager.Students[SleuthID].Club == ClubType.LightMusic && StudentManager.PracticeMusic.isPlaying))
			{
				_ = StudentManager.Students[SleuthID].CurrentAction;
				_ = 10;
				_ = StudentManager.Students[SleuthID].CurrentAction;
				_ = StudentManager.Students[SleuthID].CurrentDestination == StudentManager.Exit;
				_ = StudentManager.Students[SleuthID].Club;
				_ = 1;
				_ = StudentManager.Students[SleuthID].Club;
				_ = 14;
				_ = StudentManager.Students[SleuthID].Club;
				_ = 9;
				_ = StudentManager.Students[SleuthID].TargetedForDistraction;
				_ = StudentManager.Students[SleuthID].ClubActivityPhase;
				_ = 16;
				_ = StudentManager.Students[SleuthID].InEvent;
				_ = StudentManager.Students[SleuthID].Routine;
				_ = StudentManager.Students[SleuthID].Posing;
				_ = StudentManager.Students[SleuthID].Slave;
				_ = StudentManager.Students[SleuthID].Wet;
				_ = StudentManager.Students[SleuthID].Sedated;
				_ = StudentManager.Students[SleuthID].DoNotFeed;
				_ = StudentManager.Students[SleuthID].AlreadyFed;
				if (StudentManager.Students[SleuthID].Club == ClubType.LightMusic)
				{
					_ = StudentManager.PracticeMusic.isPlaying;
				}
				GetFoodTarget();
			}
			else if (StudentManager.LockerRoomArea.bounds.Contains(StudentManager.Students[SleuthID].transform.position) || StudentManager.MaleLockerRoomArea.bounds.Contains(StudentManager.Students[SleuthID].transform.position) || StudentManager.EastBathroomArea.bounds.Contains(StudentManager.Students[SleuthID].transform.position) || StudentManager.WestBathroomArea.bounds.Contains(StudentManager.Students[SleuthID].transform.position) || StudentManager.Students[SleuthID].transform.position.z < -100f)
			{
				GetFoodTarget();
			}
			else
			{
				CharacterAnimation.CrossFade(WalkAnim);
				DistractionTarget = StudentManager.Students[SleuthID];
				DistractionTarget.TargetedForDistraction = true;
				SleuthTarget = StudentManager.Students[SleuthID].transform;
				Pathfinding.target = SleuthTarget;
				CurrentDestination = SleuthTarget;
				TargetDistance = 0.75f;
				DistractTimer = 8f;
				Distracting = true;
				CanTalk = false;
				Routine = false;
				Attempts = 0;
			}
		}
		else
		{
			SleuthID = 0;
			GetFoodTarget();
		}
	}

	public void GetTeacherTarget()
	{
		Debug.Log(Name + " is now attempting to select a teacher to talk to.");
		Attempts++;
		if (Attempts >= 100)
		{
			Debug.Log(Name + " is now giving up on attempting to select a teacher to talk to.");
			Phase++;
			return;
		}
		TeacherID++;
		if (TeacherID < 97)
		{
			if (StudentManager.Students[TeacherID] == null)
			{
				Debug.Log(Name + " can't try to talk to Teacher #" + TeacherID + " because that teacher is not at school right now.");
				GetTeacherTarget();
				return;
			}
			if (!StudentManager.Students[TeacherID].gameObject.activeInHierarchy)
			{
				Debug.Log(Name + " can't try to talk to Teacher #" + TeacherID + " because that teacher is disabled right now.");
				GetTeacherTarget();
				return;
			}
			if (StudentManager.Students[TeacherID].TargetedForDistraction || StudentManager.Students[TeacherID].InEvent || !StudentManager.Students[TeacherID].Routine || StudentManager.Students[TeacherID].Posing)
			{
				GetTeacherTarget();
				return;
			}
			Debug.Log(Name + " is choosing Teacher #" + TeacherID + " as their target.");
			CharacterAnimation.CrossFade(WalkAnim);
			DistractionTarget = StudentManager.Students[TeacherID];
			DistractionTarget.TargetedForDistraction = true;
			DistractionTarget = StudentManager.Students[TeacherID];
			Pathfinding.target = DistractionTarget.gameObject.transform;
			CurrentDestination = DistractionTarget.gameObject.transform;
			Pathfinding.canSearch = true;
			Pathfinding.canMove = true;
			TargetDistance = 0.75f;
			DistractTimer = 10f;
			Distracting = true;
			CanTalk = false;
			Routine = false;
			Attempts = 0;
		}
		else
		{
			Debug.Log(Name + " went past Teacher #96 so they're resetting back to $90.");
			TeacherID = 90;
			GetTeacherTarget();
		}
	}

	private void PhoneAddictCameraUpdate()
	{
		if (!(SmartPhone.transform.parent != null))
		{
			return;
		}
		CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		if (!StudentManager.Eighties)
		{
			SmartPhone.transform.localPosition = new Vector3(0f, 0.005f, -0.01f);
			SmartPhone.transform.localEulerAngles = new Vector3(7.33333f, -154f, 173.66666f);
		}
		else
		{
			SmartPhone.transform.localPosition = new Vector3(0.085f, -0.0015f, 0.003f);
			SmartPhone.transform.localEulerAngles = new Vector3(-10f, 30f, 165f);
		}
		SmartPhone.SetActive(value: true);
		if (Sleuthing)
		{
			if (AlarmTimer < 2f)
			{
				AlarmTimer = 2f;
				ScaredAnim = SleuthReactAnim;
				SprintAnim = SleuthReportAnim;
				CharacterAnimation.CrossFade(ScaredAnim);
			}
			if (!CameraFlash.activeInHierarchy && CharacterAnimation[ScaredAnim].time > 2f)
			{
				CameraFlash.SetActive(value: true);
				if (Yandere.Mask != null)
				{
					Countdown.MaskedPhoto = true;
				}
			}
			return;
		}
		if (!StudentManager.Eighties)
		{
			ScaredAnim = PhoneAnims[4];
		}
		CharacterAnimation.CrossFade(ScaredAnim);
		if (!CameraFlash.activeInHierarchy && (double)CharacterAnimation[ScaredAnim].time > 3.66666)
		{
			CameraFlash.SetActive(value: true);
			if (Yandere.Mask != null)
			{
				Countdown.MaskedPhoto = true;
			}
			else if (Grudge)
			{
				Police.PhotoEvidence++;
				PhotoEvidence = true;
			}
		}
	}

	private void ReturnToRoutine()
	{
		Debug.Log(Name + " is now calling ReturnToRoutine.");
		if (Actions[Phase] == StudentActionType.Patrol || (Actions[Phase] == StudentActionType.ClubAction && Club == ClubType.Gardening))
		{
			CurrentDestination = StudentManager.Patrols.List[StudentID].GetChild(PatrolID);
			Pathfinding.target = CurrentDestination;
		}
		else
		{
			CurrentDestination = Destinations[Phase];
			Pathfinding.target = Destinations[Phase];
		}
		if (BreakingUpFight)
		{
			SetOutlinesYellow();
		}
		else
		{
			SetOutlinesOrange();
		}
		if (Yandere.Pursuer == this)
		{
			Yandere.Pursuer = null;
		}
		BreakingUpFight = false;
		WitnessedMurder = false;
		Prompt.enabled = true;
		Alarmed = false;
		Fleeing = false;
		Routine = true;
		Grudge = false;
		Pathfinding.speed = WalkSpeed;
	}

	public void EmptyHands()
	{
		bool flag = false;
		if ((SentHome && SmartPhone.activeInHierarchy) || PhotoEvidence || (Persona == PersonaType.PhoneAddict && !Dying && !Wet))
		{
			flag = true;
		}
		if (BloodPool != null && BloodPool.transform.parent == ItemParent && BloodPool.gameObject.GetComponent<WeaponScript>() != null)
		{
			BloodPool.gameObject.GetComponent<WeaponScript>().Drop();
			BloodPool.gameObject.GetComponent<WeaponScript>().enabled = true;
		}
		if (MyPlate != null && MyPlate.parent != null)
		{
			if (WitnessedMurder || WitnessedCorpse)
			{
				DropPlate();
			}
			else
			{
				MyPlate.gameObject.SetActive(value: false);
			}
		}
		if (Club == ClubType.Gardening && (!StudentManager.Eighties || WaterLow))
		{
			WateringCan.transform.parent = Hips;
			WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
			WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
		}
		if (Club == ClubType.LightMusic)
		{
			if (StudentID == 51)
			{
				if (InstrumentBag[ClubMemberID].transform.parent == null)
				{
					Instruments[ClubMemberID].transform.parent = null;
					if (!StudentManager.Eighties)
					{
						Instruments[ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
						Instruments[ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
					}
					else
					{
						Instruments[ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
						Instruments[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
					}
					Instruments[ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
					Instruments[ClubMemberID].GetComponent<AudioSource>().Stop();
				}
				else
				{
					Instruments[ClubMemberID].SetActive(value: false);
				}
			}
			else
			{
				Instruments[ClubMemberID].SetActive(value: false);
			}
			Drumsticks[0].SetActive(value: false);
			Drumsticks[1].SetActive(value: false);
			AirGuitar.Stop();
		}
		if (!Male)
		{
			Handkerchief.SetActive(value: false);
		}
		else
		{
			PinkSeifuku.SetActive(value: false);
		}
		if (!flag)
		{
			SmartPhone.SetActive(value: false);
		}
		if (BagOfChips != null)
		{
			BagOfChips.SetActive(value: false);
		}
		Chopsticks[0].SetActive(value: false);
		Chopsticks[1].SetActive(value: false);
		Sketchbook.SetActive(value: false);
		OccultBook.SetActive(value: false);
		Paintbrush.SetActive(value: false);
		Cigarette.SetActive(value: false);
		EventBook.SetActive(value: false);
		Scrubber.SetActive(value: false);
		Lighter.SetActive(value: false);
		Octodog.SetActive(value: false);
		Palette.SetActive(value: false);
		Eraser.SetActive(value: false);
		Pencil.SetActive(value: false);
		Pen.SetActive(value: false);
		if (Bento.transform.parent != null)
		{
			Bento.SetActive(value: false);
		}
		if (TrashDestination != null && TrashDestination.parent == ItemParent)
		{
			Debug.Log("Attempting to drop trash bag.");
			TrashDestination.gameObject.GetComponent<PickUpScript>().DoNotRelocate = true;
			TrashDestination.gameObject.GetComponent<PickUpScript>().Drop();
		}
		GameObject[] scienceProps = ScienceProps;
		foreach (GameObject gameObject in scienceProps)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
		scienceProps = Fingerfood;
		foreach (GameObject gameObject2 in scienceProps)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
			}
		}
	}

	public void UpdateAnimLayers()
	{
		CharacterAnimation[ConfusedSitAnim].speed += (float)StudentID * 0.01f;
		CharacterAnimation[WalkAnim].time = UnityEngine.Random.Range(0f, CharacterAnimation[WalkAnim].length);
		CharacterAnimation[WetAnim].layer = 9;
		CharacterAnimation.Play(WetAnim);
		CharacterAnimation[WetAnim].weight = 0f;
		if (!Male)
		{
			CharacterAnimation[StripAnim].speed = 1.5f;
			CharacterAnimation[GameAnim].speed = 2f;
			CharacterAnimation["f02_casualWave_04"].layer = 11;
			CharacterAnimation["f02_casualWave_04"].weight = 0f;
			CharacterAnimation["f02_friendWave_00"].layer = 10;
			CharacterAnimation["f02_friendWave_00"].weight = 0f;
			CharacterAnimation["f02_moLipSync_00"].layer = 9;
			CharacterAnimation.Play("f02_moLipSync_00");
			CharacterAnimation["f02_moLipSync_00"].weight = 0f;
			CharacterAnimation["f02_topHalfTexting_00"].layer = 8;
			CharacterAnimation.Play("f02_topHalfTexting_00");
			CharacterAnimation["f02_topHalfTexting_00"].weight = 0f;
			CharacterAnimation[CarryAnim].layer = 7;
			CharacterAnimation.Play(CarryAnim);
			CharacterAnimation[CarryAnim].weight = 0f;
			CharacterAnimation[SocialSitAnim].layer = 6;
			CharacterAnimation.Play(SocialSitAnim);
			CharacterAnimation[SocialSitAnim].weight = 0f;
			CharacterAnimation[ShyAnim].layer = 5;
			CharacterAnimation.Play(ShyAnim);
			CharacterAnimation[ShyAnim].weight = 0f;
			CharacterAnimation[FistAnim].layer = 4;
			CharacterAnimation[FistAnim].weight = 0f;
			CharacterAnimation[BentoAnim].layer = 3;
			CharacterAnimation.Play(BentoAnim);
			CharacterAnimation[BentoAnim].weight = 0f;
			CharacterAnimation[AngryFaceAnim].layer = 2;
			CharacterAnimation.Play(AngryFaceAnim);
			CharacterAnimation[AngryFaceAnim].weight = 0f;
			CharacterAnimation["f02_wetIdle_00"].speed = 1.25f;
			CharacterAnimation["f02_sleuthScan_00"].speed = 1.4f;
			BoobsResized = false;
		}
		else
		{
			CharacterAnimation[ConfusedSitAnim].speed *= -1f;
			CharacterAnimation["f02_casualWave_04"].layer = 9;
			CharacterAnimation["f02_casualWave_04"].weight = 0f;
			CharacterAnimation["friendWave_00"].layer = 8;
			CharacterAnimation["friendWave_00"].weight = 0f;
			CharacterAnimation[ToughFaceAnim].layer = 7;
			CharacterAnimation.Play(ToughFaceAnim);
			CharacterAnimation[ToughFaceAnim].weight = 0f;
			CharacterAnimation[SocialSitAnim].layer = 6;
			CharacterAnimation.Play(SocialSitAnim);
			CharacterAnimation[SocialSitAnim].weight = 0f;
			CharacterAnimation[CarryShoulderAnim].layer = 5;
			CharacterAnimation.Play(CarryShoulderAnim);
			CharacterAnimation[CarryShoulderAnim].weight = 0f;
			CharacterAnimation["scaredFace_00"].layer = 4;
			CharacterAnimation.Play("scaredFace_00");
			CharacterAnimation["scaredFace_00"].weight = 0f;
			CharacterAnimation[SadFaceAnim].layer = 3;
			CharacterAnimation.Play(SadFaceAnim);
			CharacterAnimation[SadFaceAnim].weight = 0f;
			CharacterAnimation[AngryFaceAnim].layer = 2;
			CharacterAnimation.Play(AngryFaceAnim);
			CharacterAnimation[AngryFaceAnim].weight = 0f;
			CharacterAnimation["sleuthScan_00"].speed = 1.4f;
		}
		if (Persona == PersonaType.Sleuth)
		{
			CharacterAnimation[WalkAnim].time = UnityEngine.Random.Range(0f, CharacterAnimation[WalkAnim].length);
		}
		if (Club == ClubType.Bully)
		{
			if (!StudentGlobals.GetStudentBroken(StudentID) && BullyID > 1)
			{
				CharacterAnimation["f02_bullyLaugh_00"].speed = 0.9f + (float)BullyID * 0.1f;
			}
		}
		else if (Club == ClubType.Delinquent)
		{
			CharacterAnimation[WalkAnim].time = UnityEngine.Random.Range(0f, CharacterAnimation[WalkAnim].length);
			CharacterAnimation[LeanAnim].speed = 0.5f;
		}
		else if (Club == ClubType.Council)
		{
			if (!StudentManager.Eighties)
			{
				CharacterAnimation["f02_faceCouncil" + Suffix + "_00"].layer = 10;
				CharacterAnimation.Play("f02_faceCouncil" + Suffix + "_00");
			}
		}
		else if (Club == ClubType.Gaming)
		{
			CharacterAnimation[VictoryAnim].speed -= 0.1f * (float)(StudentID - 36);
			CharacterAnimation[VictoryAnim].speed = 0.866666f;
		}
		else if (Club == ClubType.Cooking && ClubActivityPhase > 0)
		{
			WalkAnim = PlateWalkAnim;
		}
		if (!StudentManager.Eighties)
		{
			if (StudentID == 36)
			{
				CharacterAnimation[ToughFaceAnim].weight = 1f;
			}
			else if (StudentID == 66)
			{
				CharacterAnimation[ToughFaceAnim].weight = 1f;
			}
		}
		if (Tranquil)
		{
			Debug.Log("This character was tranquilized at the point in time when UpdateAnimLayers() was called.");
			CharacterAnimation.Play("f02_carryDisposeB_00");
			CharacterAnimation["f02_carryDisposeB_00"].time = CharacterAnimation["f02_carryDisposeB_00"].length;
		}
		if (Ragdoll.Concealed && Ragdoll.InsideIncinerator)
		{
			Debug.Log("This character was wrapped in a garbage bag and inside of an incinerator at the point in time when UpdateAnimLayers() was called.");
			if (Male)
			{
				CharacterAnimation.Play("carryDisposeB_00");
				CharacterAnimation["carryDisposeB_00"].time = CharacterAnimation["carryDisposeB_00"].length;
			}
			else
			{
				CharacterAnimation.Play("f02_carryDisposeB_00");
				CharacterAnimation["f02_carryDisposeB_00"].time = CharacterAnimation["f02_carryDisposeB_00"].length;
			}
			base.gameObject.SetActive(value: false);
		}
	}

	private void SpawnDetectionMarker()
	{
		DetectionMarker = UnityEngine.Object.Instantiate(Marker, Yandere.DetectionPanel.transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
		if (StudentID == 1)
		{
			DetectionMarker.GetComponent<DetectionMarkerScript>().Tex.color = new Color(1f, 0f, 0f, 0f);
		}
		DetectionMarker.transform.parent = Yandere.DetectionPanel.transform;
		DetectionMarker.Target = base.transform;
	}

	public void EquipCleaningItems()
	{
		if (CurrentAction == StudentActionType.Clean)
		{
			if (!Phoneless && (Persona == PersonaType.PhoneAddict || Persona == PersonaType.Sleuth))
			{
				WalkAnim = OriginalWalkAnim;
			}
			SmartPhone.SetActive(value: false);
			Scrubber.SetActive(value: true);
			if (CleaningRole == 5)
			{
				Scrubber.GetComponent<Renderer>().material.mainTexture = Eraser.GetComponent<Renderer>().material.mainTexture;
				Eraser.SetActive(value: true);
			}
			if (StudentID == 9 || StudentID == 60)
			{
				WalkAnim = OriginalOriginalWalkAnim;
			}
		}
	}

	public void DetermineWhatWasWitnessed()
	{
		Debug.Log("We are now determining what " + Name + " witnessed.");
		if (Witnessed == StudentWitnessType.Murder)
		{
			Debug.Log("No need to go through the entire chain. We already know that this character witnessed murder.");
			Concern = 5;
		}
		else if (YandereVisible)
		{
			Debug.Log(Name + " can see Yandere-chan right now.");
			bool flag = false;
			bool flag2 = false;
			if (Yandere.Bloodiness + (float)Yandere.GloveBlood > 0f && !Yandere.Paint)
			{
				flag = true;
			}
			if (Yandere.Club == ClubType.Art && Yandere.ClubAttire)
			{
				flag = false;
				flag2 = true;
			}
			if (Yandere.Armed)
			{
				Yandere.EquippedWeapon.SuspicionCheck();
			}
			bool flag3 = Yandere.Armed && Yandere.EquippedWeapon.Suspicious;
			bool flag4 = Yandere.PickUp != null && Yandere.PickUp.Suspicious;
			bool flag5 = Yandere.PickUp != null && Yandere.PickUp.BodyPart != null;
			bool flag6 = Yandere.PickUp != null && Yandere.PickUp.Clothing && Yandere.PickUp.Evidence;
			bool flag7 = false;
			if ((!StudentManager.Eighties && StudentID == 48 && TaskPhase == 4 && Yandere.Armed && Yandere.EquippedWeapon.WeaponID == 12) || (!StudentManager.Eighties && StudentID == 50 && TaskPhase == 4 && Yandere.Armed && Yandere.EquippedWeapon.WeaponID == 24))
			{
				flag3 = false;
				flag7 = true;
			}
			int concern = Concern;
			if (flag3)
			{
				WeaponToTakeAway = Yandere.EquippedWeapon;
			}
			if (flag3)
			{
				Debug.Log(Name + " saw the player carrying a suspicious weapon.");
			}
			if (Yandere.Rummaging || Yandere.TheftTimer > 0f)
			{
				Debug.Log("Saw Yandere-chan stealing.");
				Witnessed = StudentWitnessType.Theft;
				RepLoss = 10f;
				Concern = 5;
			}
			else if (Yandere.Pickpocketing || Yandere.Caught)
			{
				Debug.Log("Saw Yandere-chan pickpocketing.");
				Witnessed = StudentWitnessType.Pickpocketing;
				RepLoss = 10f;
				Concern = 5;
				Yandere.StudentManager.PickpocketMinigame.Failure = true;
				Yandere.StudentManager.PickpocketMinigame.End();
				Yandere.Caught = true;
				if (Teacher)
				{
					Witnessed = StudentWitnessType.Theft;
				}
			}
			else if (flag3 && Yandere.Bloodiness > 0f && Yandere.Sanity < 33.333f)
			{
				Debug.Log("Saw Yandere-chan armed, bloody, and insane.");
				TimesWeaponWitnessed++;
				TimesBloodWitnessed++;
				Witnessed = StudentWitnessType.WeaponAndBloodAndInsanity;
				RepLoss = 30f;
				Concern = 5;
			}
			else if (flag3 && Yandere.Sanity < 33.333f)
			{
				Debug.Log("Saw Yandere-chan armed and insane.");
				TimesWeaponWitnessed++;
				Witnessed = StudentWitnessType.WeaponAndInsanity;
				RepLoss = 20f;
				Concern = 5;
			}
			else if (flag && Yandere.Sanity < 33.333f)
			{
				Debug.Log("Saw Yandere-chan bloody, and insane.");
				TimesBloodWitnessed++;
				Witnessed = StudentWitnessType.BloodAndInsanity;
				RepLoss = 20f;
				Concern = 5;
			}
			else if (flag3 && Yandere.Bloodiness > 0f)
			{
				Debug.Log("Saw Yandere-chan armed and bloody.");
				TimesWeaponWitnessed++;
				TimesBloodWitnessed++;
				Witnessed = StudentWitnessType.WeaponAndBlood;
				RepLoss = 20f;
				Concern = 5;
			}
			else if (flag3)
			{
				Debug.Log("Saw Yandere-chan with a suspicious weapon.");
				TimesWeaponWitnessed++;
				WeaponWitnessed = Yandere.EquippedWeapon.WeaponID;
				PlayerHeldBloodyWeapon = Yandere.EquippedWeapon.Bloody;
				Witnessed = StudentWitnessType.Weapon;
				RepLoss = 10f;
				Concern = 5;
			}
			else if (flag4)
			{
				Debug.Log("Saw Yandere-chan with a suspicious object.");
				if (Yandere.PickUp.CleaningProduct)
				{
					if (StudentID == 1)
					{
						Witnessed = StudentWitnessType.Lewd;
					}
					else
					{
						Witnessed = StudentWitnessType.CleaningItem;
					}
				}
				else if (Teacher || Club == ClubType.Council)
				{
					Witnessed = StudentWitnessType.Insanity;
				}
				else
				{
					Witnessed = StudentWitnessType.Suspicious;
				}
				RepLoss = 10f;
				Concern = 5;
			}
			else if (Yandere.Bloodiness > 0f && !flag2)
			{
				Debug.Log("Saw Yandere-chan splattered with blood.");
				TimesBloodWitnessed++;
				Witnessed = StudentWitnessType.Blood;
				if (!Bloody)
				{
					RepLoss = 10f;
					Concern = 5;
				}
				else
				{
					RepLoss = 0f;
					Concern = 0;
				}
			}
			else if (Yandere.Sanity < 33.333f)
			{
				Debug.Log("Saw Yandere-chan acting insane.");
				Witnessed = StudentWitnessType.Insanity;
				RepLoss = 10f;
				Concern = 5;
			}
			else if (Yandere.Lewd)
			{
				Debug.Log("Saw Yandere-chan being lewd.");
				Witnessed = StudentWitnessType.Lewd;
				RepLoss = 10f;
				Concern = 5;
			}
			else if ((Yandere.Laughing && Yandere.LaughIntensity > 15f) || (StudentID > 1 && Yandere.Stance.Current == StanceType.Crouching) || Yandere.Stance.Current == StanceType.Crawling || Yandere.SuspiciousActionTimer > 0f || Yandere.WearingRaincoat || Yandere.Lockpicking || (Yandere.Carrying && Yandere.CurrentRagdoll.Concealed) || (Yandere.Dragging && Yandere.CurrentRagdoll.Concealed) || (Yandere.Schoolwear == 2 && Yandere.transform.position.z < 30f) || (AnnoyedByRadio > 1 && Yandere.AnnoyingGiggleTimer > 0f) || (Yandere.PreparingThrow && Yandere.Obvious))
			{
				if (StudentID == 1 && !Yandere.Laughing && Yandere.Sanity > 33f)
				{
					Debug.Log("Saw Yandere-chan being lewd.");
					Witnessed = StudentWitnessType.Lewd;
				}
				else
				{
					Debug.Log("Saw Yandere-chan acting insane.");
					Witnessed = StudentWitnessType.Insanity;
				}
				RepLoss = 10f;
				if (Yandere.Stance.Current == StanceType.Crouching)
				{
					AnnoyedByGiggles++;
				}
				if ((Yandere.Laughing && Yandere.LaughIntensity > 15f) || Yandere.BreakingGlass)
				{
					Concern = 5;
				}
				else if (AnnoyedByGiggles > 4)
				{
					if (StudentID == 1 && AnnoyedByRadio > 1 && Yandere.PotentiallyAnnoyingTimer > 0f)
					{
						Concern++;
					}
					else
					{
						Concern = 5;
					}
				}
				else
				{
					Concern++;
				}
			}
			else if (Yandere.Poisoning)
			{
				Debug.Log("Saw Yandere-chan poisoning a bento.");
				Witnessed = StudentWitnessType.Poisoning;
				RepLoss = 10f;
				Concern = 5;
			}
			else if (Yandere.Trespassing && StudentID > 1)
			{
				Debug.Log("Saw Yandere-chan trespassing.");
				Witnessed = (Private ? StudentWitnessType.Interruption : StudentWitnessType.Trespassing);
				Witness = true;
				if (!Teacher)
				{
					RepLoss = 10f;
				}
				Concern++;
			}
			else if (Yandere.NearSenpai || (StudentID == 1 && Yandere.Stance.Current == StanceType.Crouching))
			{
				if (StudentID == 1)
				{
					Debug.Log("Saw Yandere-chan stalking.");
					Witnessed = StudentWitnessType.Stalking;
				}
				else
				{
					Debug.Log("Saw Yandere-chan acting insane.");
					Witnessed = StudentWitnessType.Insanity;
					RepLoss = 10f;
				}
				Concern++;
			}
			else if (Yandere.Eavesdropping)
			{
				if (StudentID == 1)
				{
					Debug.Log("Saw Yandere-chan stalking.");
					Witnessed = StudentWitnessType.Stalking;
					Concern++;
				}
				else
				{
					if (InEvent)
					{
						EventInterrupted = true;
					}
					Debug.Log("Saw Yandere-chan eavesdropping.");
					Witnessed = StudentWitnessType.Eavesdropping;
					RepLoss = 10f;
					Concern = 5;
				}
			}
			else if (Yandere.Aiming)
			{
				Debug.Log("Saw Yandere-chan stalking.");
				Witnessed = StudentWitnessType.Stalking;
				Concern++;
			}
			else if (Yandere.DelinquentFighting)
			{
				Debug.Log("Saw Yandere-chan fighting a delinquent.");
				Witnessed = StudentWitnessType.Violence;
				RepLoss = 10f;
				Concern = 5;
			}
			else if (Yandere.PickUp != null && Yandere.PickUp.Clothing && Yandere.PickUp.Evidence)
			{
				Debug.Log("Saw Yandere-chan with bloody clothing.");
				Witnessed = StudentWitnessType.HoldingBloodyClothing;
				RepLoss = 10f;
				Concern = 5;
			}
			else if (flag5 || flag6)
			{
				Debug.Log("Saw Yandere-chan attempting to cover up a murder.");
				Witnessed = StudentWitnessType.CoverUp;
			}
			else if (flag7)
			{
				if (StudentID == 48)
				{
					Subtitle.CustomText = "Is that dumbbell for me? Drop it over here!";
				}
				else if (StudentID == 50)
				{
					Subtitle.CustomText = "Are you going to use that pipe wrench to fix the training dummy?";
				}
				Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
			}
			else if (Yandere.LaughTimer > 0f)
			{
				Witnessed = StudentWitnessType.Insanity;
				RepLoss = 10f;
				Concern++;
			}
			if ((StudentID == 1 || Club == ClubType.Council) && Witnessed == StudentWitnessType.Insanity && (Yandere.Stance.Current == StanceType.Crouching || Yandere.Stance.Current == StanceType.Crawling))
			{
				Debug.Log("Saw Yandere-chan stalking.");
				Witnessed = StudentWitnessType.Stalking;
				Concern = concern;
				Concern++;
			}
		}
		else
		{
			Debug.Log(Name + " is reacting to something other than Yandere-chan.");
			if (WitnessedLimb)
			{
				Witnessed = StudentWitnessType.SeveredLimb;
			}
			else if (WitnessedBloodyWeapon)
			{
				Witnessed = StudentWitnessType.BloodyWeapon;
			}
			else if (WitnessedBloodPool)
			{
				Witnessed = StudentWitnessType.BloodPool;
			}
			else if (WitnessedWeapon)
			{
				Witnessed = StudentWitnessType.DroppedWeapon;
			}
			else if (WitnessedCorpse)
			{
				Witnessed = StudentWitnessType.Corpse;
			}
			else
			{
				Debug.Log(Name + " was alarmed by something, but didn't see what it was. DiscCheck is being set to true.");
				Witnessed = StudentWitnessType.None;
				DiscCheck = true;
				Witness = false;
			}
		}
		if (Concern == 5 && Club == ClubType.Council && Yandere.Pursuer == null)
		{
			Debug.Log("A member of the student council is being transformed into a teacher.");
			Teacher = true;
		}
		if (StudentID > 1 && Witnessed != 0)
		{
			SetOutlinesYellow();
		}
	}

	public void DetermineTeacherSubtitle()
	{
		Debug.Log("We are now determining what line of dialogue the teacher should say.");
		if (Club == ClubType.Council)
		{
			Subtitle.UpdateLabel(SubtitleType.CouncilToCounselor, ClubMemberID, 5f);
			return;
		}
		if (Guarding && YandereVisible)
		{
			Debug.Log("Teacher reached this code while guarding and able to see Yandere-chan.");
			if (Yandere.Bloodiness + (float)Yandere.GloveBlood > 0f && !Yandere.Paint)
			{
				Witnessed = StudentWitnessType.Blood;
			}
			else if (Yandere.Armed)
			{
				Witnessed = StudentWitnessType.Weapon;
			}
			else if (Yandere.Sanity < 66.66666f || Yandere.WearingRaincoat || Yandere.Lockpicking)
			{
				Witnessed = StudentWitnessType.Insanity;
			}
		}
		if (Witnessed == StudentWitnessType.Murder)
		{
			if (WitnessedMindBrokenMurder)
			{
				Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 4, 6f);
			}
			else
			{
				Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 1, 6f);
			}
			GameOverCause = GameOverType.Murder;
			WitnessedMurder = true;
		}
		else if (Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			GameOverCause = GameOverType.Insanity;
			WitnessedMurder = true;
		}
		else if (Witnessed == StudentWitnessType.WeaponAndBlood)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
			GameOverCause = GameOverType.Weapon;
			WitnessedMurder = true;
		}
		else if (Witnessed == StudentWitnessType.WeaponAndInsanity)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			GameOverCause = GameOverType.Insanity;
			WitnessedMurder = true;
		}
		else if (Witnessed == StudentWitnessType.BloodAndInsanity)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			GameOverCause = GameOverType.Insanity;
			WitnessedMurder = true;
		}
		else if (Witnessed == StudentWitnessType.Weapon)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
			GameOverCause = GameOverType.Weapon;
			WitnessedMurder = true;
		}
		else if (Witnessed == StudentWitnessType.Blood)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherBloodHostile, 1, 6f);
			GameOverCause = GameOverType.Blood;
			WitnessedMurder = true;
		}
		else if (Witnessed == StudentWitnessType.Insanity || Witnessed == StudentWitnessType.Poisoning)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			GameOverCause = GameOverType.Insanity;
			WitnessedMurder = true;
		}
		else if (Witnessed == StudentWitnessType.Lewd)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
			GameOverCause = GameOverType.Lewd;
		}
		else if (Witnessed == StudentWitnessType.Trespassing)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, Concern, 5f);
		}
		else if (Witnessed == StudentWitnessType.Corpse)
		{
			Debug.Log(Name + " just discovered a corpse and called the cops.");
			DetermineCorpseLocation();
			Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
			Police.Called = true;
		}
		else if (Witnessed == StudentWitnessType.CoverUp)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherCoverUpHostile, 1, 6f);
			GameOverCause = GameOverType.Blood;
			WitnessedMurder = true;
		}
		else if (Witnessed == StudentWitnessType.CleaningItem)
		{
			Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
			GameOverCause = GameOverType.Insanity;
		}
	}

	public void ReturnMisplacedWeapon()
	{
		Debug.Log(Name + " has returned a misplaced weapon.");
		StopInvestigating();
		if (StudentManager.BloodReporter == this)
		{
			StudentManager.BloodReporter = null;
		}
		BloodPool.parent = null;
		BloodPool.position = BloodPool.GetComponent<WeaponScript>().StartingPosition;
		BloodPool.eulerAngles = BloodPool.GetComponent<WeaponScript>().StartingRotation;
		BloodPool.GetComponent<WeaponScript>().Prompt.enabled = true;
		BloodPool.GetComponent<WeaponScript>().enabled = true;
		BloodPool.GetComponent<WeaponScript>().DoNotRelocate = true;
		BloodPool.GetComponent<WeaponScript>().Drop();
		BloodPool.GetComponent<WeaponScript>().MyRigidbody.useGravity = false;
		BloodPool.GetComponent<WeaponScript>().MyRigidbody.isKinematic = true;
		BloodPool.GetComponent<WeaponScript>().Returner = null;
		BloodPool = null;
		CurrentDestination = Destinations[Phase];
		Pathfinding.target = Destinations[Phase];
		if (CurrentAction == StudentActionType.Sunbathe && SunbathePhase > 1)
		{
			Debug.Log(Name + " was sunbathing at the time.");
			CurrentDestination = StudentManager.SunbatheSpots[StudentID];
			Pathfinding.target = StudentManager.SunbatheSpots[StudentID];
		}
		if (ResumeFollowingAfter)
		{
			ResumeFollowing();
		}
		if (Club == ClubType.Council || Teacher)
		{
			Handkerchief.SetActive(value: false);
		}
		Pathfinding.speed = WalkSpeed;
		CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		ReturningMisplacedWeapon = false;
		WitnessedSomething = false;
		VerballyReacted = false;
		WitnessedWeapon = false;
		YandereInnocent = false;
		ReportingBlood = false;
		Distracted = false;
		Routine = true;
		ReturningMisplacedWeaponPhase = 0;
		WitnessCooldownTimer = 0f;
		Yandere.WeaponManager.ReturnWeaponID = -1;
		Yandere.WeaponManager.ReturnStudentID = -1;
		if (BeforeReturnAnim == "")
		{
			BeforeReturnAnim = OriginalWalkAnim;
		}
		WalkAnim = BeforeReturnAnim;
		Hurry = WasHurrying;
		Debug.Log(Name + "'s WalkAnim is now: " + WalkAnim);
		if (!Sleuthing)
		{
			return;
		}
		Debug.Log("The character who just returned a misplaced item was ''Sleuthing'' before they did, so they are using special logic...");
		if (SleuthTarget != null)
		{
			if (SleuthTarget.GetComponent<StudentScript>() == null)
			{
				Debug.Log("SleuthTarget was not a student!");
				GetSleuthTarget();
			}
			else
			{
				Debug.Log("SleuthTarget was a student!");
				CurrentDestination = SleuthTarget.transform;
				Pathfinding.target = SleuthTarget.transform;
			}
		}
		else
		{
			Debug.Log("SleuthTarget was null!");
			GetSleuthTarget();
		}
	}

	public void StopMusic()
	{
		if (StudentID == 51)
		{
			if (InstrumentBag[ClubMemberID].transform.parent == null)
			{
				Instruments[ClubMemberID].transform.parent = null;
				if (!StudentManager.Eighties)
				{
					Instruments[ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
					Instruments[ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
				}
				else
				{
					Instruments[ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
					Instruments[ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
				}
				Instruments[ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
				Instruments[ClubMemberID].GetComponent<AudioSource>().Stop();
			}
			else
			{
				Instruments[ClubMemberID].SetActive(value: false);
			}
		}
		else
		{
			Instruments[ClubMemberID].SetActive(value: false);
		}
		Drumsticks[0].SetActive(value: false);
		Drumsticks[1].SetActive(value: false);
	}

	public void DropPuzzle()
	{
		PuzzleCube.enabled = true;
		PuzzleCube.DoNotRelocate = true;
		PuzzleCube.Drop();
		SolvingPuzzle = false;
		Distracted = false;
		PuzzleTimer = 0f;
	}

	public void ReturnToNormal()
	{
		Debug.Log(Name + " has been instructed to forget everything and return to normal.");
		if (SolvingPuzzle)
		{
			Debug.Log("Student was solving a puzzle at the time. Should be forgetting about the puzzle now.");
			PuzzleTimer = 0f;
			DropPuzzle();
		}
		if (StudentManager.Reporter == this)
		{
			StudentManager.CorpseLocation.position = Vector3.zero;
			StudentManager.Reporter = null;
		}
		else if (StudentManager.BloodReporter == this)
		{
			StudentManager.BloodLocation.position = Vector3.zero;
			StudentManager.BloodReporter = null;
		}
		if (Yandere.Pursuer == this)
		{
			Yandere.Pursuer = null;
			Yandere.PreparedForStruggle = false;
		}
		StudentManager.UpdateStudents();
		CurrentDestination = Destinations[Phase];
		Pathfinding.target = Destinations[Phase];
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		Pathfinding.speed = WalkSpeed;
		TargetDistance = 1f;
		ReportPhase = 0;
		ReportTimer = 0f;
		AlarmTimer = 0f;
		AmnesiaTimer = 10f;
		if (Actions[Phase] != StudentActionType.ClubAction || Club != ClubType.Cooking || ClubActivityPhase <= 0)
		{
			RandomAnim = BulliedIdleAnim;
			IdleAnim = BulliedIdleAnim;
			WalkAnim = BulliedWalkAnim;
		}
		if (WitnessedBloodPool || WitnessedLimb || WitnessedWeapon)
		{
			Persona = OriginalPersona;
		}
		BloodPool = null;
		WitnessedBloodyWeapon = false;
		WitnessedBloodPool = false;
		WitnessedSomething = false;
		WitnessedCorpse = false;
		WitnessedMurder = false;
		WitnessedWeapon = false;
		WitnessedLimb = false;
		SmartPhone.SetActive(value: false);
		LostTeacherTrust = true;
		ReportingMurder = false;
		ReportingBlood = false;
		PinDownWitness = false;
		Distracted = false;
		Reacted = false;
		Alarmed = false;
		Fleeing = false;
		Routine = true;
		Halt = false;
		if (Club == ClubType.Council)
		{
			Persona = PersonaType.Dangerous;
		}
		for (ID = 0; ID < Outlines.Length; ID++)
		{
			if (Outlines[ID] != null)
			{
				Outlines[ID].color = new Color(1f, 1f, 0f, 1f);
			}
		}
		Countdown.gameObject.SetActive(value: false);
		Countdown.Sprite.fillAmount = 1f;
		ChaseCamera.SetActive(value: false);
	}

	public void ForgetAboutBloodPool()
	{
		Debug.Log(Name + " was told to ForgetAboutBloodPool()");
		Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
		if (Club == ClubType.Cooking && CurrentAction == StudentActionType.ClubAction && MyPlate != null && MyPlate.parent == RightHand)
		{
			GetFoodTarget();
		}
		else
		{
			CurrentDestination = Destinations[Phase];
			Pathfinding.target = Destinations[Phase];
		}
		InvestigatingBloodPool = false;
		WitnessedBloodyWeapon = false;
		WitnessedBloodPool = false;
		WitnessedSomething = false;
		WitnessedWeapon = false;
		Distracted = false;
		if (!Shoving)
		{
			Routine = true;
		}
		WitnessCooldownTimer = 5f;
		if (BloodPool != null && CanSeeObject(Yandere.gameObject, Yandere.HeadPosition) && BloodPool.parent == Yandere.RightHand)
		{
			YandereVisible = true;
			ReportTimer = 0f;
			ReportPhase = 0;
			Alarmed = false;
			Fleeing = false;
			Reacted = false;
			if (BloodPool.GetComponent<WeaponScript>() != null && BloodPool.GetComponent<WeaponScript>().Suspicious && !Yandere.Invisible)
			{
				Debug.Log(Name + " is about to call the BecomeAlarmed() function from the ForgetAboutBloodPool() function.");
				WitnessCooldownTimer = 5f;
				AlarmTimer = 0f;
				Alarm = 200f;
				BecomeAlarmed();
			}
		}
		if (BeforeReturnAnim != "")
		{
			WalkAnim = BeforeReturnAnim;
		}
		BloodPool = null;
		if (Giggle != null)
		{
			ForgetGiggle();
		}
		if (!ReturningMisplacedWeapon && Club == ClubType.Sports && CurrentAction == StudentActionType.ClubAction && ClubActivityPhase > 2 && ClubActivityPhase < 14)
		{
			Debug.Log("Student was jogging before they started investigating, and will now return to jogging.");
			Jog();
		}
	}

	public void SimpleForgetAboutBloodPool()
	{
		InvestigatingBloodPool = false;
		WitnessedBloodyWeapon = false;
		WitnessedBloodPool = false;
		WitnessedSomething = false;
		WitnessedWeapon = false;
		Distracted = false;
	}

	private void SummonWitnessCamera()
	{
		if (WitnessCamera != null)
		{
			WitnessCamera.transform.parent = WitnessPOV;
			WitnessCamera.transform.localPosition = Vector3.zero;
			WitnessCamera.transform.localEulerAngles = Vector3.zero;
			WitnessCamera.MyCamera.enabled = true;
			WitnessCamera.Show = true;
		}
	}

	public void SilentlyForgetBloodPool()
	{
		Debug.Log(Name + " was told to SilentlyForgetBloodPool()");
		InvestigatingBloodPool = false;
		WitnessedBloodyWeapon = false;
		WitnessedBloodPool = false;
		WitnessedSomething = false;
		WitnessedWeapon = false;
	}

	private void CheckForEndRaibaruEvent()
	{
		if (!(StudentManager.Students[46] == null) && StudentManager.Students[46].Phase <= Phase)
		{
			return;
		}
		Debug.Log("Raibaru has just finished mentoring the Martial Arts Club.");
		if (FollowTarget != null)
		{
			if (FollowTarget.Alive)
			{
				Destinations[Phase] = FollowTarget.transform;
				Pathfinding.target = FollowTarget.transform;
				CurrentDestination = FollowTarget.transform;
			}
			else
			{
				Destinations[Phase] = StudentManager.LastKnownOsana;
				Pathfinding.target = StudentManager.LastKnownOsana;
				CurrentDestination = StudentManager.LastKnownOsana;
			}
			FollowTarget.Follower = this;
			Actions[Phase] = StudentActionType.Follow;
			CurrentAction = StudentActionType.Follow;
		}
		else
		{
			Destinations[Phase] = StudentManager.MournSpots[StudentID];
			Pathfinding.target = StudentManager.MournSpots[StudentID];
			CurrentDestination = StudentManager.MournSpots[StudentID];
			Actions[Phase] = StudentActionType.Mourn;
			CurrentAction = StudentActionType.Mourn;
		}
		SpeechLines.Stop();
		InEvent = false;
		NoMentor = true;
		Routine = true;
	}

	private void RaibaruOsanaDeathScheduleChanges()
	{
		ScheduleBlock obj = ScheduleBlocks[1];
		obj.destination = "Mourn";
		obj.action = "Mourn";
		ScheduleBlock obj2 = ScheduleBlocks[2];
		obj2.destination = "Mourn";
		obj2.action = "Mourn";
		ScheduleBlock obj3 = ScheduleBlocks[4];
		obj3.destination = "LunchSpot";
		obj3.action = "Eat";
		Persona = PersonaType.Heroic;
		IdleAnim = BulliedIdleAnim;
		WalkAnim = BulliedWalkAnim;
		OriginalIdleAnim = IdleAnim;
	}

	private void RaibaruStopsFollowingOsana()
	{
		ScheduleBlock obj = ScheduleBlocks[3];
		obj.destination = "Seat";
		obj.action = "Sit";
		ScheduleBlock obj2 = ScheduleBlocks[5];
		obj2.destination = "Seat";
		obj2.action = "Sit";
		ScheduleBlock obj3 = ScheduleBlocks[6];
		obj3.destination = "Locker";
		obj3.action = "Shoes";
		ScheduleBlock obj4 = ScheduleBlocks[7];
		obj4.destination = "Exit";
		obj4.action = "Exit";
		ScheduleBlock obj5 = ScheduleBlocks[8];
		obj5.destination = "Exit";
		obj5.action = "Exit";
		ScheduleBlock obj6 = ScheduleBlocks[9];
		obj6.destination = "Exit";
		obj6.action = "Exit";
		FollowTarget = null;
	}

	private void StopFollowingGravureModel()
	{
		ScheduleBlock obj = ScheduleBlocks[2];
		obj.destination = "Seat";
		obj.action = "Sit";
		ScheduleBlock obj2 = ScheduleBlocks[4];
		obj2.destination = "LunchSpot";
		obj2.action = "Eat";
		ScheduleBlock obj3 = ScheduleBlocks[6];
		obj3.destination = "Locker";
		obj3.action = "Shoes";
		ScheduleBlock obj4 = ScheduleBlocks[7];
		obj4.destination = "Exit";
		obj4.action = "Stand";
		GetDestinations();
		CurrentDestination = Destinations[Phase];
		Pathfinding.target = Destinations[Phase];
		if (StudentID > 1)
		{
			IdleAnim = BulliedIdleAnim;
			WalkAnim = BulliedWalkAnim;
		}
		TargetDistance = 0.5f;
	}

	public void StopDrinking()
	{
		CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		DrinkingFountain.Occupied = false;
		EquipCleaningItems();
		EatingSnack = false;
		Private = false;
		Routine = true;
		StudentManager.UpdateMe(StudentID);
	}

	public void GoToClass()
	{
		ScheduleBlock obj = ScheduleBlocks[Phase];
		obj.destination = "Seat";
		obj.action = "SitAndTakeNotes";
		Actions[Phase] = StudentActionType.SitAndTakeNotes;
		CurrentAction = StudentActionType.SitAndTakeNotes;
		GetDestinations();
		CurrentDestination = Destinations[Phase];
		Pathfinding.target = Destinations[Phase];
	}

	public void RaibaruCannotFindOsana()
	{
		SpeechLines.Stop();
		CharacterAnimation.CrossFade(LookLeftRightAnim);
		SnackTimer += Time.deltaTime;
		if (SnackTimer > 5f)
		{
			Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 5, 10f);
			RaibaruOsanaDeathScheduleChanges();
			RaibaruStopsFollowingOsana();
			GetDestinations();
			CurrentDestination = Destinations[Phase];
			Pathfinding.target = Destinations[Phase];
			SnackTimer = 0f;
		}
		if (Actions[Phase] == StudentActionType.SitAndEatBento && Schoolwear == 2)
		{
			Debug.Log(Name + " needs to change clothing before doing whatever they're supposed to do next.");
			MustChangeClothing = true;
			ChangeClothingPhase = 0;
			CurrentDestination = StudentManager.StrippingPositions[GirlID];
			Pathfinding.target = StudentManager.StrippingPositions[GirlID];
		}
	}

	public void CannotFindInfatuationTarget()
	{
		Debug.Log("Student #" + StudentID + " cannot find the student they are supposed to be following.");
		CharacterAnimation.CrossFade(LookLeftRightAnim);
		SnackTimer += Time.deltaTime;
		if (SnackTimer > 5f)
		{
			Debug.Log("The student has decided to give up on following the gravure model.");
			StopFollowingGravureModel();
			SnackTimer = 0f;
		}
	}

	public void DisableProps()
	{
		RandomCheerAnim = CheerAnims[UnityEngine.Random.Range(0, CheerAnims.Length)];
		HealthBar.transform.parent.gameObject.SetActive(value: false);
		FollowCountdown.gameObject.SetActive(value: false);
		VomitEmitter.gameObject.SetActive(value: false);
		ChaseCamera.gameObject.SetActive(value: false);
		Countdown.gameObject.SetActive(value: false);
		MiyukiGameScreen.SetActive(value: false);
		Chopsticks[0].SetActive(value: false);
		Chopsticks[1].SetActive(value: false);
		Handkerchief.SetActive(value: false);
		PepperSpray.SetActive(value: false);
		RetroCamera.SetActive(value: false);
		WateringCan.SetActive(value: false);
		Sketchbook.SetActive(value: false);
		OccultBook.SetActive(value: false);
		Paintbrush.SetActive(value: false);
		Cigarette.SetActive(value: false);
		EventBook.SetActive(value: false);
		Handcuffs.SetActive(value: false);
		WeaponBag.SetActive(value: false);
		Scrubber.SetActive(value: false);
		Armband.SetActive(value: false);
		Lighter.SetActive(value: false);
		Octodog.SetActive(value: false);
		Palette.SetActive(value: false);
		Eraser.SetActive(value: false);
		Pencil.SetActive(value: false);
		Bento.SetActive(value: false);
		Pen.SetActive(value: false);
		SpeechLines.Stop();
		if (SmartPhone.transform.parent != null)
		{
			SmartPhone.SetActive(value: false);
		}
		GameObject[] scienceProps = ScienceProps;
		foreach (GameObject gameObject in scienceProps)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
		scienceProps = Fingerfood;
		foreach (GameObject gameObject2 in scienceProps)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
			}
		}
		scienceProps = InstrumentBag;
		foreach (GameObject gameObject3 in scienceProps)
		{
			if (gameObject3 != null)
			{
				gameObject3.SetActive(value: false);
			}
		}
		if (Male)
		{
			DisableMaleProps();
		}
		else
		{
			DisableFemaleProps();
		}
	}

	public void DisableFemaleProps()
	{
		SkirtOrigins[0] = Skirt[0].transform.localPosition;
		SkirtOrigins[1] = Skirt[1].transform.localPosition;
		SkirtOrigins[2] = Skirt[2].transform.localPosition;
		SkirtOrigins[3] = Skirt[3].transform.localPosition;
		PickRandomGossipAnim();
		DramaticCamera.gameObject.SetActive(value: false);
		MapMarker.gameObject.SetActive(value: false);
		EightiesPhone.SetActive(value: false);
		AnimatedBook.SetActive(value: false);
		Handkerchief.SetActive(value: false);
		Sketchbook.SetActive(value: false);
		GameObject[] instruments = Instruments;
		foreach (GameObject gameObject in instruments)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
		Drumsticks[0].SetActive(value: false);
		Drumsticks[1].SetActive(value: false);
		if (Club >= ClubType.Teacher)
		{
			BecomeTeacher();
		}
		if (GameGlobals.CensorPanties && !Teacher)
		{
			Cosmetic.CensorPanties();
		}
		DisableEffects();
	}

	public void DisableMaleProps()
	{
		MapMarker.gameObject.SetActive(value: false);
		DelinquentSpeechLines.Stop();
		PinkSeifuku.SetActive(value: false);
		Earpiece.SetActive(value: false);
		ParticleSystem[] liquidEmitters = LiquidEmitters;
		for (int i = 0; i < liquidEmitters.Length; i++)
		{
			liquidEmitters[i].gameObject.SetActive(value: false);
		}
		DisableEffects();
	}

	public void TriggerBeatEmUpMinigame()
	{
		GameGlobals.BeatEmUpDifficulty = 1;
		SceneManager.LoadScene("BeatEmUpScene", LoadSceneMode.Additive);
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			rootGameObjects[i].SetActive(value: false);
		}
	}

	public void PlaceBag()
	{
		Debug.Log("Current rival - " + Name + " - just put her bookbag on her desk.");
		if (!StudentManager.Eighties)
		{
			StudentManager.RivalBookBag.GetComponent<MeshFilter>().mesh = Cosmetic.ModernBookBagMesh;
			StudentManager.RivalBookBag.GetComponent<Renderer>().material.mainTexture = Cosmetic.BookbagTextures[StudentID];
		}
		if (Seat.position.x < 0f)
		{
			StudentManager.RivalBookBag.transform.position = Seat.position + new Vector3(-0.33333f, 0.342f, 0.3585f);
			StudentManager.RivalBookBag.transform.eulerAngles = new Vector3(0f, 0f, 0f);
		}
		else
		{
			StudentManager.RivalBookBag.transform.position = Seat.position + new Vector3(0.33333f, 0.342f, -0.3585f);
			StudentManager.RivalBookBag.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		}
		StudentManager.RivalBookBag.CorrectPosition = StudentManager.RivalBookBag.transform.position;
		StudentManager.RivalBookBag.CorrectRotation = StudentManager.RivalBookBag.transform.eulerAngles;
		StudentManager.RivalBookBag.gameObject.SetActive(value: true);
		StudentManager.RivalBookBag.Prompt.enabled = true;
		StudentManager.RivalBookBag.Rival = this;
		BookBag.SetActive(value: false);
		if (GiftBox)
		{
			StudentManager.WednesdayGiftBox.SetActive(value: true);
			if (base.transform.position.x < 0f)
			{
				StudentManager.WednesdayGiftBox.transform.position = Seat.position + new Vector3(-0.4f, 1.02f, 0f);
			}
			else
			{
				StudentManager.WednesdayGiftBox.transform.position = Seat.position + new Vector3(0.4f, 1.02f, 0f);
			}
			GiftBox = false;
		}
		StudentManager.BagPlaced = true;
		BagPlaced = true;
		if (VisitSenpaiDesk)
		{
			if (CurrentDestination == StudentManager.Students[1].Seat)
			{
				StudentManager.FridayTestNotes.SetActive(value: true);
				VisitSenpaiDesk = false;
			}
			Destinations[Phase] = StudentManager.Students[1].Seat;
			CurrentDestination = StudentManager.Students[1].Seat;
			Pathfinding.target = StudentManager.Students[1].Seat;
			return;
		}
		if (Bullied)
		{
			ScheduleBlock obj = ScheduleBlocks[2];
			obj.destination = "ShameSpot";
			obj.action = "Shamed";
			obj.time = 8f;
		}
		else if (StudentManager.CustomMode)
		{
			Debug.Log("Attempting to update rival's routine to whatever her Custom Mode routine is supposed to be.");
			ScheduleBlock obj2 = ScheduleBlocks[2];
			obj2.destination = OriginalDestination;
			obj2.action = OriginalAction;
		}
		else if (StudentManager.Eighties)
		{
			if (StudentID == 11 || StudentID == 12)
			{
				ScheduleBlock obj3 = ScheduleBlocks[2];
				obj3.destination = "Hangout";
				obj3.action = "Socialize";
			}
			else if (StudentID == 13)
			{
				ScheduleBlock obj4 = ScheduleBlocks[2];
				obj4.destination = "Patrol";
				obj4.action = "Patrol";
			}
			else if (StudentID == 14)
			{
				ScheduleBlock obj5 = ScheduleBlocks[2];
				obj5.destination = "Sunbathe";
				obj5.action = "Jog";
			}
			else if (StudentID == 15)
			{
				ScheduleBlock obj6 = ScheduleBlocks[2];
				obj6.destination = "Sunbathe";
				obj6.action = "Sunbathe";
			}
			else if (StudentID == 16)
			{
				ScheduleBlock obj7 = ScheduleBlocks[2];
				obj7.destination = "Perform";
				obj7.action = "Perform";
			}
			else if (StudentID == 17)
			{
				Debug.Log("Prodigy rival is building their schedule from here.");
				ScheduleBlock obj8 = ScheduleBlocks[2];
				obj8.destination = "Hangout";
				obj8.action = "HelpTeacher";
			}
			else if (StudentID == 18)
			{
				ScheduleBlock obj9 = ScheduleBlocks[2];
				obj9.destination = "Patrol";
				obj9.action = "Patrol";
			}
			else if (StudentID == 19)
			{
				ScheduleBlock scheduleBlock = ScheduleBlocks[2];
				if (SchoolGlobals.SchoolAtmosphere > 0.8f && StudentManager.Photographers > 0)
				{
					scheduleBlock.destination = "Sunbathe";
					scheduleBlock.action = "GravurePose";
				}
				else
				{
					scheduleBlock.destination = "Patrol";
					scheduleBlock.action = "Patrol";
				}
			}
			else if (StudentID == 20)
			{
				ScheduleBlock obj10 = ScheduleBlocks[2];
				obj10.destination = "Guard";
				obj10.action = "Guard";
				TargetDistance = 1f;
			}
		}
		else if (StudentID == 12)
		{
			ScheduleBlock obj11 = ScheduleBlocks[2];
			obj11.destination = "BakeSale";
			obj11.action = "BakeSale";
		}
		GetDestinations();
		CurrentDestination = Destinations[Phase];
		Pathfinding.target = Destinations[Phase];
		CurrentAction = Actions[Phase];
	}

	public void GetInitialSleuthTarget()
	{
		if (StudentID == 37)
		{
			SleuthID = 1;
		}
		else if (StudentID == 38)
		{
			SleuthID = 20;
		}
		else if (StudentID == 39)
		{
			SleuthID = 30;
		}
		else if (StudentID == 40)
		{
			SleuthID = 40;
		}
		else if (StudentID != 56)
		{
			if (StudentID == 57)
			{
				SleuthID = 50;
			}
			else if (StudentID == 58)
			{
				SleuthID = 60;
			}
			else if (StudentID == 59)
			{
				SleuthID = 70;
			}
			else if (StudentID == 60)
			{
				SleuthID = 80;
			}
		}
	}

	public void BecomeSleuth()
	{
		if (!SleuthInitialized)
		{
			SleuthInitialized = true;
			GetInitialSleuthTarget();
		}
		if (Club != ClubType.Newspaper && Club != ClubType.Photography)
		{
			_ = Club;
		}
		bool flag = false;
		if (StudentManager.Eighties)
		{
			CameraFlash = RetroCameraFlash;
			SmartPhone = RetroCamera;
			if ((double)SchoolGlobals.SchoolAtmosphere < 0.8 && StudentID == 36)
			{
				Debug.Log("Newspaper Club girl shouldn't become a sleuth, since she needs to perform club leader activities.");
				flag = true;
			}
			if (StudentID == 56 || flag)
			{
				Debug.Log("Student #" + StudentID + " is a Club leader, and shouldn't become a Sleuth...");
				flag = true;
				if (StudentManager.MissionMode)
				{
					ScheduleBlock obj = ScheduleBlocks[4];
					obj.destination = "LunchSpot";
					obj.action = "Eat";
					GetDestinations();
				}
			}
		}
		if (flag)
		{
			return;
		}
		Indoors = true;
		Spawned = true;
		if (ShoeRemoval.Locker == null)
		{
			ShoeRemoval.Start();
		}
		ShoeRemoval.PutOnShoes();
		if (StudentID != 20)
		{
			SprintAnim = SleuthSprintAnim;
			IdleAnim = SleuthIdleAnim;
			WalkAnim = SleuthWalkAnim;
		}
		CameraAnims = HeroAnims;
		SmartPhone.SetActive(value: true);
		Countdown.Speed = 0.075f;
		Sleuthing = true;
		if (Male)
		{
			SmartPhone.transform.localPosition = new Vector3(0.06f, -0.02f, -0.02f);
			SmartPhone.transform.localEulerAngles = new Vector3(22.5f, 22.5f, 150f);
		}
		else
		{
			SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.015f, -0.015f);
		}
		if (StudentManager.Eighties)
		{
			SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.066666f, -0.01f);
			SmartPhone.transform.localEulerAngles = new Vector3(15f, 15f, 105f);
			Phoneless = false;
		}
		else if (Sleuthing)
		{
			SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.015f, -0.015f);
			SmartPhone.transform.localEulerAngles = new Vector3(12.5f, 120f, 180f);
		}
		else
		{
			SmartPhone.transform.localPosition = new Vector3(0.025f, 0.02f, 0.04f);
			SmartPhone.transform.localEulerAngles = new Vector3(22.5f, -157.5f, 180f);
		}
		if (StudentID != 20 && StudentID != 36)
		{
			if (Club == ClubType.Photography)
			{
				SleuthTarget = StudentManager.Clubs.List[StudentID];
			}
			else
			{
				StudentManager.SleuthPhase = 3;
				GetSleuthTarget();
			}
			if (!Grudge)
			{
				ScheduleBlock obj2 = ScheduleBlocks[2];
				obj2.destination = "Sleuth";
				obj2.action = "Sleuth";
				if (!StudentManager.MissionMode)
				{
					ScheduleBlock obj3 = ScheduleBlocks[4];
					obj3.destination = "Sleuth";
					obj3.action = "Sleuth";
				}
				else
				{
					ScheduleBlock obj4 = ScheduleBlocks[4];
					obj4.destination = "LunchSpot";
					obj4.action = "Eat";
				}
				if (ScheduleBlocks.Length > 7)
				{
					ScheduleBlock obj5 = ScheduleBlocks[7];
					obj5.destination = "Sleuth";
					obj5.action = "Sleuth";
				}
			}
			else
			{
				StalkTarget = Yandere.transform;
				SleuthTarget = Yandere.transform;
				ScheduleBlock obj6 = ScheduleBlocks[2];
				obj6.destination = "Stalk";
				obj6.action = "Stalk";
				ScheduleBlock obj7 = ScheduleBlocks[4];
				obj7.destination = "Stalk";
				obj7.action = "Stalk";
				if (ScheduleBlocks.Length > 7)
				{
					ScheduleBlock obj8 = ScheduleBlocks[7];
					obj8.destination = "Stalk";
					obj8.action = "Stalk";
				}
			}
		}
		if (SleuthID < 1)
		{
			SleuthID = 1;
		}
	}

	public void CheckForBento()
	{
		if (Bento.activeInHierarchy && StudentID > 1 && Bento.transform.parent != null)
		{
			GenericBentoScript component = Bento.GetComponent<GenericBentoScript>();
			component.enabled = true;
			component.Prompt.enabled = true;
			Bento.SetActive(value: true);
			Bento.transform.parent = base.transform;
			if (Male)
			{
				Bento.transform.localPosition = new Vector3(0f, 0.4266666f, -0.075f);
			}
			else
			{
				Bento.transform.localPosition = new Vector3(0f, 0.461f, -0.075f);
			}
			Bento.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Bento.transform.parent = null;
		}
	}

	public void BlendIntoSittingAnim()
	{
		if (CharacterAnimation[SocialSitAnim].weight != 1f)
		{
			CharacterAnimation[SocialSitAnim].weight = Mathf.Lerp(CharacterAnimation[SocialSitAnim].weight, 1f, Time.deltaTime * 10f);
			if ((double)CharacterAnimation[SocialSitAnim].weight > 0.99)
			{
				CharacterAnimation[SocialSitAnim].weight = 1f;
			}
		}
	}

	public void BlendOutOfSittingAnim()
	{
		if (CharacterAnimation[SocialSitAnim].weight != 0f)
		{
			CharacterAnimation[SocialSitAnim].weight = Mathf.Lerp(CharacterAnimation[SocialSitAnim].weight, 0f, Time.deltaTime * 10f);
			if ((double)CharacterAnimation[SocialSitAnim].weight < 0.01)
			{
				CharacterAnimation[SocialSitAnim].weight = 0f;
			}
		}
	}

	public void Oversleep()
	{
		if (StudentID != 15 && ScheduleBlocks.Length == 10)
		{
			Debug.Log("Giving " + Name + " the ''Oversleep'' routine.");
			ScheduleBlock obj = ScheduleBlocks[6];
			obj.destination = "SleepSpot";
			obj.action = "Sleep";
			obj.time = 99999f;
			ScheduleBlock obj2 = ScheduleBlocks[7];
			obj2.destination = "SleepSpot";
			obj2.action = "Sleep";
			obj2.time = 99999f;
			ScheduleBlock obj3 = ScheduleBlocks[8];
			obj3.destination = "SleepSpot";
			obj3.action = "Sleep";
			obj3.time = 99999f;
			ScheduleBlock obj4 = ScheduleBlocks[9];
			obj4.destination = "SleepSpot";
			obj4.action = "Sleep";
			obj4.time = 99999f;
		}
	}

	public void UpdateGemaAppearance()
	{
		Debug.Log("Gema is now updating his appearance.");
		Cosmetic.FacialHairstyle = 0;
		Cosmetic.EyewearID = 9;
		Cosmetic.Hairstyle = 49;
		Cosmetic.Accessory = 0;
		Cosmetic.Start();
		OriginalIdleAnim = "properIdle_00";
		IdleAnim = "properIdle_00";
		OriginalOriginalWalkAnim = "properWalk_00";
		OriginalWalkAnim = "properWalk_00";
		WalkAnim = "properWalk_00";
		ClubAnim = "properGaming_00";
		ScheduleBlock obj = ScheduleBlocks[Phase];
		obj.destination = "Club";
		obj.action = "Club";
		GetDestinations();
		CurrentDestination = Destinations[Phase];
		Pathfinding.target = Destinations[Phase];
		StudentManager.ReactedToGameLeader = true;
		for (int i = 1; i < 6; i++)
		{
			if (StudentManager.Students[80 + i].Schoolwear != 2)
			{
				Debug.Log("Attempting to update the schedule for " + StudentManager.Students[80 + i].Name);
				ScheduleBlock obj2 = StudentManager.Students[80 + i].ScheduleBlocks[4];
				obj2.destination = "Shock";
				obj2.action = "Shock";
				StudentManager.Students[80 + i].AdmireAnim = StudentManager.Students[80 + i].AdmireAnims[UnityEngine.Random.Range(0, 3)];
				StudentManager.Students[80 + i].GetDestinations();
				StudentManager.Students[80 + i].CurrentDestination = StudentManager.Students[80 + i].Destinations[StudentManager.Students[80 + i].Phase];
				StudentManager.Students[80 + i].Pathfinding.target = StudentManager.Students[80 + i].Destinations[StudentManager.Students[80 + i].Phase];
			}
		}
	}

	public void FinishPyro()
	{
		StudentManager.PyroFlames.Stop();
		StudentManager.PyroFlameSounds[1].Stop();
		StudentManager.PyroFlameSounds[2].Stop();
		ScheduleBlock scheduleBlock = ScheduleBlocks[Phase];
		scheduleBlock.destination = "Hangout";
		scheduleBlock.action = "Socialize";
		if (StudentManager.Week > 2)
		{
			scheduleBlock.action = "Gaming";
		}
		GetDestinations();
		Pathfinding.target = Destinations[Phase];
		CurrentDestination = Destinations[Phase];
		PyroPhase = 1;
		PyroTimer = 0f;
	}

	private void CheckForWallBehind()
	{
		Debug.Log("Checking for a wall behind this student.");
		RaycastOrigin = Hips;
		Vector3 direction = RaycastOrigin.TransformDirection(base.transform.worldToLocalMatrix.MultiplyVector(base.transform.forward) * -1f);
		if (Physics.Raycast(RaycastOrigin.position, direction, out hit, 2f, OnlyDefault))
		{
			Debug.Log("Yeah, hit a wall behind.");
			TooCloseToWall = true;
		}
	}

	private void CheckForWallInFront(float Distance)
	{
		RaycastOrigin = Hips;
		Vector3 direction = RaycastOrigin.TransformDirection(base.transform.worldToLocalMatrix.MultiplyVector(base.transform.forward));
		if (Physics.Raycast(RaycastOrigin.position, direction, out hit, Distance, OnlyDefault))
		{
			TooCloseToWall = true;
		}
	}

	public void CheckForWallToLeft()
	{
		Debug.Log("Checking for a wall to the left of this character.");
		RaycastOriginVector = base.transform.position + Vector3.up * 0.5f;
		Vector3 right = base.transform.right;
		Debug.DrawRay(RaycastOriginVector, right, Color.red);
		if (Physics.Raycast(RaycastOriginVector, right, out hit, 2f, OnlyDefault))
		{
			Debug.Log("Yeah, hit a wall to the left.");
			TooCloseToWall = true;
		}
	}

	public void CheckForWallToRight()
	{
		Debug.Log("Checking for a wall to the right of this character.");
		RaycastOriginVector = base.transform.position + Vector3.up * 0.5f;
		Vector3 vector = base.transform.right * -1f;
		Debug.DrawRay(RaycastOriginVector, vector, Color.red);
		if (Physics.Raycast(RaycastOriginVector, vector, out hit, 2.5f, OnlyDefault))
		{
			Debug.Log("Yeah, hit a wall to the right.");
			TooCloseToWall = true;
		}
	}

	public void ResumeFollowing()
	{
		ScheduleBlock obj = ScheduleBlocks[4];
		obj.destination = "Follow";
		obj.action = "Follow";
		GetDestinations();
		Pathfinding.target = FollowTarget.transform;
		CurrentDestination = FollowTarget.transform;
		ResumeFollowingAfter = false;
		CanTalk = true;
		Debug.Log("Raibaru was told to resume ''Follow'' protocol.");
	}

	public void SetOriginalScheduleBlocks()
	{
		OriginalTimes = new float[ScheduleBlocks.Length];
		OriginalDests = new string[ScheduleBlocks.Length];
		OriginalActs = new string[ScheduleBlocks.Length];
		for (int i = 0; i < ScheduleBlocks.Length; i++)
		{
			OriginalTimes[i] = ScheduleBlocks[i].time;
			OriginalDests[i] = ScheduleBlocks[i].destination;
			OriginalActs[i] = ScheduleBlocks[i].action;
		}
	}

	public void SetOriginalActions()
	{
		for (int i = 0; i < Actions.Length; i++)
		{
			OriginalActions[i] = Actions[i];
		}
	}

	public void RestoreOriginalScheduleBlocks()
	{
		for (int i = 0; i < ScheduleBlocks.Length; i++)
		{
			ScheduleBlocks[i].time = OriginalTimes[i];
			ScheduleBlocks[i].destination = OriginalDests[i];
			ScheduleBlocks[i].action = OriginalActs[i];
		}
	}

	public void RestoreOriginalActions()
	{
		for (int i = 0; i < Actions.Length; i++)
		{
			Actions[i] = OriginalActions[i];
		}
	}

	public void ChangeClothing()
	{
		if (ChangeClothingPhase == 0)
		{
			Debug.Log(Name + " is changing clothing right now.");
			UnityEngine.Object.Instantiate(StudentManager.CommunalLocker.SteamCloud, base.transform.position + Vector3.up * 0.81f, Quaternion.identity).transform.parent = base.transform;
			CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			ChangeClothingPhase++;
		}
		else
		{
			if (ChangeClothingPhase != 1)
			{
				return;
			}
			CharacterAnimation.CrossFade(StripAnim);
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
			if (!(CharacterAnimation[StripAnim].time >= 1.5f))
			{
				return;
			}
			if (Schoolwear != 1)
			{
				Schoolwear = 1;
				ChangeSchoolwear();
				WalkAnim = OriginalWalkAnim;
			}
			else if (BikiniAttacher != null && BikiniAttacher.newRenderer != null)
			{
				BikiniAttacher.newRenderer.enabled = false;
				MyRenderer.enabled = true;
				WearingBikini = false;
			}
			if (CharacterAnimation[StripAnim].time >= CharacterAnimation[StripAnim].length)
			{
				Debug.Log(Name + " just finished changing clothing and is choosing destination now.");
				CurrentAction = Actions[Phase];
				if (CurrentAction == StudentActionType.AtLocker)
				{
					Pathfinding.target = StudentManager.Exit;
					CurrentDestination = StudentManager.Exit;
				}
				else if (CurrentAction == StudentActionType.ChangeShoes)
				{
					Pathfinding.target = MyLocker;
					CurrentDestination = MyLocker;
				}
				else if (CurrentAction == StudentActionType.SitAndEatBento)
				{
					Debug.Log("Should be going to eat now.");
					Pathfinding.target = StudentManager.LunchSpots.List[StudentID];
					CurrentDestination = StudentManager.LunchSpots.List[StudentID];
				}
				else
				{
					Debug.Log("Should be going to class now.");
					Pathfinding.target = Seat;
					CurrentDestination = Seat;
				}
				ChangeClothingPhase++;
				MustChangeClothing = false;
				Confessing = ConfessAfterwards;
				if (Confessing)
				{
					Debug.Log(Name + " will resume confessing now.");
					ChooseLocker();
					Routine = false;
				}
				ConfessAfterwards = false;
				DistanceToDestination = 999f;
			}
		}
	}

	public void UpdatePyroUrge()
	{
		PyroTimer += Time.deltaTime;
		if (PyroTimer > PyroLimit)
		{
			SpeechLines.Stop();
			ScheduleBlock obj = ScheduleBlocks[Phase];
			obj.destination = "LightFire";
			obj.action = "LightFire";
			GetDestinations();
			Pathfinding.target = Destinations[Phase];
			CurrentDestination = Destinations[Phase];
			PyroPhase = 1;
			PyroTimer = 0f;
		}
	}

	public void ChooseLocker()
	{
		Debug.Log(Name + " is now choosing what boy's locker to put a note in.");
		if (StudentManager.LoveManager.ConfessToSuitor)
		{
			StudentManager.SuitorLocker = StudentManager.LockerPositions[StudentManager.SuitorID];
			CurrentDestination = StudentManager.SuitorLocker;
			Pathfinding.target = StudentManager.SuitorLocker;
		}
		else
		{
			CurrentDestination = StudentManager.SenpaiLocker;
			Pathfinding.target = StudentManager.SenpaiLocker;
		}
	}

	public void DropWeaponInBox()
	{
		Debug.Log("DropWeaponInBox() was just fired.");
		StudentManager.BloodLocation.position = Vector3.zero;
		BloodPool.parent = null;
		BloodPool.position = StudentManager.WeaponBoxSpot.parent.position + new Vector3(0f, 1f, 0f);
		BloodPool.eulerAngles = new Vector3(0f, 90f, 0f);
		if (BloodPool.GetComponent<WeaponScript>() != null && BloodPool.GetComponent<WeaponScript>().Type == WeaponType.Scythe)
		{
			BloodPool.position = StudentManager.WeaponBoxSpot.parent.position + new Vector3(-0.1f, 1.5f, 0.1f);
			BloodPool.eulerAngles = new Vector3(-75f, 0f, 90f);
		}
		BloodPool.GetComponent<WeaponScript>().Prompt.enabled = true;
		BloodPool.GetComponent<WeaponScript>().Returner = null;
		BloodPool.GetComponent<WeaponScript>().enabled = true;
		BloodPool.GetComponent<WeaponScript>().DoNotRelocate = true;
		BloodPool.GetComponent<WeaponScript>().Drop();
		Handkerchief.SetActive(value: false);
		StopInvestigating();
		BloodPool = null;
	}

	public void GoPose()
	{
		Debug.Log(Name + " is being instructed to go pose for a photoshoot.");
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		Stripping = false;
		CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		Destinations[Phase] = StudentManager.Hangouts.List[19];
		Pathfinding.target = StudentManager.Hangouts.List[19];
		CurrentDestination = StudentManager.Hangouts.List[19];
		StudentManager.CommunalLocker.Student = null;
	}

	public void EnableOutlines()
	{
		for (ID = 0; ID < Outlines.Length; ID++)
		{
			if (Outlines[ID] != null)
			{
				Outlines[ID].enabled = true;
				Outlines[ID].color = new Color(0f, 1f, 0f);
			}
		}
	}

	public void ResetEyes()
	{
		LeftEye.localPosition = new Vector3(LeftEye.localPosition.x, LeftEye.localPosition.y, LeftEyeOrigin.z - EyeShrink * 0.01f);
		RightEye.localPosition = new Vector3(RightEye.localPosition.x, RightEye.localPosition.y, RightEyeOrigin.z + EyeShrink * 0.01f);
		LeftEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, LeftEye.localScale.z);
		RightEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, RightEye.localScale.z);
	}

	public void GoSitInInfirmary()
	{
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		ScheduleBlock obj = ScheduleBlocks[Phase];
		obj.destination = "InfirmarySeat";
		obj.action = "Relax";
		GetDestinations();
		CurrentDestination = Destinations[Phase];
		Pathfinding.target = Destinations[Phase];
		Pathfinding.speed = 2f;
		RelaxAnim = HeadacheSitAnim;
		SeekingMedicine = false;
		SitInInfirmary = true;
		Routine = true;
	}

	public void StopFollowing()
	{
		Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
		Prompt.Label[0].text = "     Talk";
		Prompt.Circle[0].fillAmount = 1f;
		ParticleSystem.EmissionModule emission = Hearts.emission;
		emission.enabled = false;
		FollowCountdown.gameObject.SetActive(value: false);
		Yandere.Follower = null;
		Yandere.Followers--;
		Following = false;
		Routine = true;
		CurrentDestination = Destinations[Phase];
		Pathfinding.target = Destinations[Phase];
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		Pathfinding.speed = WalkSpeed;
	}

	public void TurnOutlinesGreen()
	{
		for (ID = 0; ID < Outlines.Length; ID++)
		{
			if (Outlines[ID] != null)
			{
				Outlines[ID].enabled = true;
				Outlines[ID].color = new Color(0f, 1f, 0f);
			}
		}
	}

	public void CheckForKnifeInInventory()
	{
		if (Yandere.Weapon[1] != null && Yandere.Weapon[1].Type == WeaponType.Knife)
		{
			Yandere.WeaponMenu.Selected = 1;
			Yandere.WeaponMenu.Equip();
		}
		else if (Yandere.Weapon[2] != null && Yandere.Weapon[2].Type == WeaponType.Knife)
		{
			Yandere.WeaponMenu.Selected = 2;
			Yandere.WeaponMenu.Equip();
		}
		else if (Yandere.Container != null && Yandere.Container.TrashCan != null && Yandere.Container.TrashCan.ConcealedWeapon != null && Yandere.Container.TrashCan.ConcealedWeapon.Type == WeaponType.Knife)
		{
			WeaponScript concealedWeapon = Yandere.Container.TrashCan.ConcealedWeapon;
			Yandere.Container.TrashCan.RemoveContents();
			concealedWeapon.Equip();
			concealedWeapon.gameObject.SetActive(value: true);
		}
	}

	public void InvincibleTakedown()
	{
		Debug.Log("Something just fired InvincibleTakedown()");
		if (Yandere.Aiming)
		{
			Yandere.StopAiming();
		}
		Yandere.Mopping = false;
		Yandere.EmptyHands();
		Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
		Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 4, 0f);
		AttackReaction();
		CharacterAnimation["f02_moCounterB_00"].time = 6f;
		Yandere.CharacterAnimation["f02_moCounterA_00"].time = 6f;
		Yandere.ShoulderCamera.ObstacleCounter = true;
		Yandere.ShoulderCamera.Timer = 6f;
		Police.Show = false;
		Yandere.CameraEffects.MurderWitnessed();
		Yandere.Jukebox.GameOver();
	}

	public void GoPuke()
	{
		Debug.Log(Name + " has ingested emetic poison, and should be going to a toilet.");
		CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		if (Male)
		{
			WalkAnim = "stomachPainWalk_00";
			StudentManager.GetMaleVomitSpot(this);
			Pathfinding.target = StudentManager.MaleVomitSpot;
			CurrentDestination = StudentManager.MaleVomitSpot;
		}
		else
		{
			WalkAnim = "f02_stomachPainWalk_00";
			StudentManager.GetFemaleVomitSpot(this);
			Pathfinding.target = StudentManager.FemaleVomitSpot;
			CurrentDestination = StudentManager.FemaleVomitSpot;
		}
		if (StudentManager.Eighties && StudentID == 10)
		{
			Pathfinding.target = StudentManager.AltFemaleVomitSpot;
			CurrentDestination = StudentManager.AltFemaleVomitSpot;
			VomitDoor = StudentManager.AltFemaleVomitDoor;
		}
		CharacterAnimation.CrossFade(WalkAnim);
		DistanceToDestination = 100f;
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		Pathfinding.speed = 2f;
		MyBento.Tampered = false;
		Vomiting = true;
		Routine = false;
		Chopsticks[0].SetActive(value: false);
		Chopsticks[1].SetActive(value: false);
		Bento.SetActive(value: false);
	}
}
