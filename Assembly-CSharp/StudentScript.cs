// Decompiled with JetBrains decompiler
// Type: StudentScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Pathfinding;
using System;
using System.Collections.Generic;
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
  public Texture KokonaPhoneTexture;
  public Texture MidoriPhoneTexture;
  public Texture OsanaPhoneTexture;
  public Texture RedBookTexture;
  public Texture BloodTexture;
  public Texture BrownTexture;
  public Texture WaterTexture;
  public Texture GasTexture;
  public SkinnedMeshRenderer MyRenderer;
  public Renderer BookRenderer;
  public Transform FollowTargetDestination;
  public Transform LastSuspiciousObject2;
  public Transform LastSuspiciousObject;
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
  private int[] CorpseLayers = new int[2]{ 11, 14 };
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
  public Collider NEStairs;
  public Collider NWStairs;
  public Collider SEStairs;
  public Collider SWStairs;
  public GameObject EightiesTeacherAttacher;
  public GameObject EnterGuardStateCollider;
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
  public bool InvestigatingPossibleBlood;
  public bool InvestigatingPossibleDeath;
  public bool InvestigatingPossibleLimb;
  public bool SpecialRivalDeathReaction;
  public bool WitnessedMindBrokenMurder;
  public bool ReturningMisplacedWeapon;
  public bool SenpaiWitnessingRivalDie;
  public bool IgnoringThingsOnGround;
  public bool PlayerHeldBloodyWeapon;
  public bool TargetedForDistraction;
  public bool SchoolwearUnavailable;
  public bool WitnessedBloodyWeapon;
  public bool IgnoringPettyActions;
  public bool ReturnToRoutineAfter;
  public bool ActivateIncinerator;
  public bool MustChangeClothing;
  public bool SawCorpseThisFrame;
  public bool WillRemoveTripwire;
  public bool WitnessedBloodPool;
  public bool WitnessedSomething;
  public bool FoundFriendCorpse;
  public bool MurderedByFragile;
  public bool MurderedByStudent;
  public bool OriginallyTeacher;
  public bool ReturningFromSave;
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
  public bool StalkerFleeing;
  public bool YandereVisible;
  public bool AwareOfCorpse;
  public bool AwareOfMurder;
  public bool CrimeReported;
  public bool FleeWhenClean;
  public bool MurderSuicide;
  public bool PhotoEvidence;
  public bool RespectEarned;
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
  public bool Pushable;
  public bool PyroUrge;
  public bool Reflexes;
  public bool Replaced;
  public bool Restless;
  public bool SentHome;
  public bool Splashed;
  public bool Tranquil;
  public bool WalkBack;
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
  public float FollowTargetDistance;
  public float DistanceToPlayer;
  public float TargetDistance;
  public float ThreatDistance;
  public float LockerRoomCheckTimer;
  public float WitnessCooldownTimer;
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
  public float PuzzleTimer;
  public float GiggleTimer;
  public float GoAwayTimer;
  public float IgnoreTimer;
  public float LyricsTimer;
  public float MiyukiTimer;
  public float MusumeTimer;
  public float PatrolTimer;
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
  public float SulkTimer;
  public float TalkTimer;
  public float WaitTimer;
  public float SewTimer;
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
  public int DramaticPhase;
  public int GraffitiPhase;
  public int InfatuationID;
  public int SentHomePhase;
  public int SunbathePhase;
  public int ConfessPhase = 1;
  public int SciencePhase;
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
  public int StinkBombSpecialCase;
  public int BloodPoolsSpawned;
  public int AnnoyedByGiggles;
  public int LovestruckTarget;
  public int MurdersWitnessed;
  public int WeaponWitnessed;
  public int AnnoyedByRadio;
  public int MurderReaction;
  public int PhaseFromSave;
  public int CleaningRole;
  public int StruggleWait;
  public int TimesAnnoyed;
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
  public StudentWitnessType PreviouslyWitnessed;
  public StudentWitnessType Witnessed;
  public GameOverType GameOverCause;
  public DeathType DeathType;
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
  public string[] AdmireAnims;
  public string[] CleanAnims;
  public string[] CameraAnims;
  public string[] SocialAnims;
  public string[] CowardAnims;
  public string[] EvilAnims;
  public string[] HeroAnims;
  public string[] TaskAnims;
  public string[] PhoneAnims;
  public int ClubMemberID;
  public int StudentID;
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
  public LowPolyStudentScript LowPoly;
  public GameObject EightiesPhone;
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
  public Mesh NoArmsNoTorso;
  public GameObject RiggedAccessory;
  public int CoupleID;
  public int PartnerID;
  public float ChameleonBonus;
  public bool Chameleon;
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
  public UnityEngine.Sprite SenpaiSprite;
  public UnityEngine.Sprite RivalSprite;
  public float SavePositionX;
  public float SavePositionY;
  public float SavePositionZ;

  public bool Alive => this.DeathType == DeathType.None;

  public void Start()
  {
    string idleAnim = this.IdleAnim;
    this.CounterAnim = "f02_teacherCounterB_00";
    if (!this.Started)
    {
      this.CharacterAnimation = this.Character.GetComponent<Animation>();
      this.MyBento = this.Bento.GetComponent<GenericBentoScript>();
      this.Pathfinding.repathRate += (float) this.StudentID * 0.01f;
      this.OriginalIdleAnim = this.IdleAnim;
      this.OriginalLeanAnim = this.LeanAnim;
      this.Friend = PlayerGlobals.GetStudentFriend(this.StudentID);
      if (ClubGlobals.Club == ClubType.Occult)
        this.Perception = 0.5f;
      this.Hearts.emission.enabled = false;
      this.Prompt.OwnerType = PromptOwnerType.Person;
      this.Paranoia = 2f - SchoolGlobals.SchoolAtmosphere;
      this.VisionDistance = (PlayerGlobals.PantiesEquipped == 4 ? 5f : 10f) * this.Paranoia;
      if ((UnityEngine.Object) this.Yandere != (UnityEngine.Object) null && (UnityEngine.Object) this.Yandere.DetectionPanel != (UnityEngine.Object) null)
        this.SpawnDetectionMarker();
      StudentJson student = this.JSON.Students[this.StudentID];
      this.ScheduleBlocks = student.ScheduleBlocks;
      this.Persona = student.Persona;
      this.Class = student.Class;
      this.Crush = student.Crush;
      this.Club = student.Club;
      this.BreastSize = student.BreastSize;
      this.Strength = student.Strength;
      this.Hairstyle = student.Hairstyle;
      this.Accessory = student.Accessory;
      this.Name = student.Name;
      this.OriginalClub = this.Club;
      if (!this.StudentManager.LoveSick && SchoolAtmosphere.Type == SchoolAtmosphereType.Low && this.Club != ClubType.Council && this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Violent && this.StudentID < 90 && (this.Club <= ClubType.Gaming || this.Club == ClubType.Newspaper))
        this.IdleAnim = this.ParanoidAnim;
      if (StudentGlobals.GetStudentBroken(this.StudentID))
      {
        this.Cosmetic.RightEyeRenderer.gameObject.SetActive(false);
        this.Cosmetic.LeftEyeRenderer.gameObject.SetActive(false);
        this.Cosmetic.RightIrisLight.SetActive(false);
        this.Cosmetic.LeftIrisLight.SetActive(false);
        this.RightEmptyEye.SetActive(true);
        this.LeftEmptyEye.SetActive(true);
        this.Traumatized = true;
        this.Shy = true;
        this.Persona = PersonaType.Coward;
      }
      if (this.Name == "Random")
      {
        this.Persona = (PersonaType) UnityEngine.Random.Range(1, 8);
        if (this.Persona == PersonaType.Lovestruck)
          this.Persona = PersonaType.PhoneAddict;
        student.Persona = this.Persona;
        if (this.Persona == PersonaType.Heroic)
        {
          this.Strength = UnityEngine.Random.Range(1, 5);
          student.Strength = this.Strength;
        }
      }
      this.Seat = this.StudentManager.Seats[this.Class].List[student.Seat];
      this.gameObject.name = "Student_" + this.StudentID.ToString() + " (" + this.Name + ")";
      this.OriginalPersona = this.Persona;
      if (this.StudentID == 81 && StudentGlobals.GetStudentBroken(81))
        this.Persona = PersonaType.Coward;
      if (this.Persona == PersonaType.Loner || this.Persona == PersonaType.Coward || this.Persona == PersonaType.Fragile)
        this.CameraAnims = this.CowardAnims;
      else if (this.Persona == PersonaType.TeachersPet || this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Strict)
        this.CameraAnims = this.HeroAnims;
      else if (this.Persona == PersonaType.Evil || this.Persona == PersonaType.Spiteful || this.Persona == PersonaType.Violent)
        this.CameraAnims = this.EvilAnims;
      else if (this.Persona == PersonaType.SocialButterfly || this.Persona == PersonaType.Lovestruck || this.Persona == PersonaType.PhoneAddict || this.Persona == PersonaType.Sleuth)
        this.CameraAnims = this.SocialAnims;
      if (ClubGlobals.GetClubClosed(this.Club))
        this.Club = ClubType.None;
      this.Yandere = this.StudentManager.Yandere;
      this.DialogueWheel = this.StudentManager.DialogueWheel;
      this.ClubManager = this.StudentManager.ClubManager;
      this.Reputation = this.StudentManager.Reputation;
      this.Subtitle = this.Yandere.Subtitle;
      this.Police = this.StudentManager.Police;
      this.Clock = this.StudentManager.Clock;
      this.CameraEffects = this.Yandere.MainCamera.GetComponent<CameraEffectsScript>();
      this.RightEyeOrigin = this.RightEye.localPosition;
      this.LeftEyeOrigin = this.LeftEye.localPosition;
      this.Bento.GetComponent<GenericBentoScript>().StudentID = this.StudentID;
      this.DisableProps();
      this.OriginalOriginalSprintAnim = this.SprintAnim;
      this.OriginalOriginalWalkAnim = this.WalkAnim;
      this.OriginalSprintAnim = this.SprintAnim;
      this.OriginalWalkAnim = this.WalkAnim;
      if (this.Persona == PersonaType.Evil)
        this.ScaredAnim = this.EvilWitnessAnim;
      if (this.Persona == PersonaType.PhoneAddict)
      {
        this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
        this.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -160f, 165f);
        this.Countdown.Speed = 0.1f;
        this.SprintAnim = this.PhoneAnims[2];
        this.PatrolAnim = this.PhoneAnims[3];
      }
      if (this.Club == ClubType.Bully)
      {
        this.SkirtCollider.transform.localPosition = new Vector3(0.0f, 0.055f, 0.0f);
        if (!StudentGlobals.GetStudentBroken(this.StudentID))
        {
          this.IdleAnim = this.PhoneAnims[0];
          this.BullyID = this.StudentID - 80;
        }
      }
      this.SetSplashes(false);
      if (!this.Male)
        this.DisableFemaleProps();
      else
        this.DisableMaleProps();
      if (this.Rival)
        this.MapMarker.gameObject.SetActive(true);
      if (!this.StudentManager.Eighties)
      {
        if (this.StudentID == 1)
        {
          this.MapMarker.gameObject.SetActive(true);
          if (DateGlobals.Week == 2)
          {
            ScheduleBlock scheduleBlock1 = this.ScheduleBlocks[2];
            scheduleBlock1.destination = "Patrol";
            scheduleBlock1.action = "Patrol";
            ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[7];
            scheduleBlock2.destination = "Patrol";
            scheduleBlock2.action = "Patrol";
          }
        }
        else if (this.StudentID == 2)
        {
          if (StudentGlobals.GetStudentDead(3) || StudentGlobals.GetStudentKidnapped(3) || (UnityEngine.Object) this.StudentManager.Students[3] == (UnityEngine.Object) null || (UnityEngine.Object) this.StudentManager.Students[3] != (UnityEngine.Object) null && this.StudentManager.Students[3].Slave)
          {
            ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[2];
            scheduleBlock3.destination = "Mourn";
            scheduleBlock3.action = "Mourn";
            ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[7];
            scheduleBlock4.destination = "Mourn";
            scheduleBlock4.action = "Mourn";
            this.IdleAnim = this.BulliedIdleAnim;
            this.WalkAnim = this.BulliedWalkAnim;
          }
          this.PatrolAnim = this.SearchPatrolAnim;
        }
        else if (this.StudentID == 3)
        {
          if (StudentGlobals.GetStudentDead(2) || StudentGlobals.GetStudentKidnapped(2) || (UnityEngine.Object) this.StudentManager.Students[2] == (UnityEngine.Object) null || (UnityEngine.Object) this.StudentManager.Students[2] != (UnityEngine.Object) null && this.StudentManager.Students[2].Slave)
          {
            ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[2];
            scheduleBlock5.destination = "Mourn";
            scheduleBlock5.action = "Mourn";
            ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[7];
            scheduleBlock6.destination = "Mourn";
            scheduleBlock6.action = "Mourn";
            this.IdleAnim = this.BulliedIdleAnim;
            this.WalkAnim = this.BulliedWalkAnim;
          }
          this.PatrolAnim = this.SearchPatrolAnim;
        }
        else if (this.StudentID == 4)
        {
          this.IdleAnim = "f02_idleShort_00";
          this.WalkAnim = "f02_newWalk_00";
        }
        else if (this.StudentID == 5)
        {
          if (!this.StudentManager.TakingPortraits)
          {
            if ((UnityEngine.Object) this.StudentManager.Students[81] == (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[82] == (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[83] == (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[84] == (UnityEngine.Object) null && (UnityEngine.Object) this.StudentManager.Students[85] == (UnityEngine.Object) null)
            {
              this.CharacterAnimation["f02_smile_00"].layer = 1;
              this.CharacterAnimation.Play("f02_smile_00");
              this.CharacterAnimation["f02_smile_00"].weight = 1f;
            }
            else
              this.Shy = true;
          }
        }
        else if (this.StudentID == 6)
        {
          this.RelaxAnim = "crossarms_00";
          this.CameraAnims = this.HeroAnims;
          this.Curious = true;
          this.Crush = 11;
          if ((UnityEngine.Object) this.StudentManager.Students[11] == (UnityEngine.Object) null)
            this.Curious = false;
        }
        else if (this.StudentID == 7)
        {
          this.RunAnim = "runFeminine_00";
          this.SprintAnim = "runFeminine_00";
          this.RelaxAnim = "infirmaryRest_00";
          this.OriginalSprintAnim = this.SprintAnim;
          this.Cosmetic.Start();
          if (!GameGlobals.AlphabetMode && !this.StudentManager.MissionMode)
            this.gameObject.SetActive(false);
        }
        else if (this.StudentID == 8)
        {
          this.IdleAnim = this.BulliedIdleAnim;
          this.WalkAnim = this.BulliedWalkAnim;
        }
        else if (this.StudentID == 9)
        {
          this.IdleAnim = "idleScholarly_00";
          this.WalkAnim = "walkScholarly_00";
          this.CameraAnims = this.HeroAnims;
        }
        else if (this.StudentID == 10)
        {
          this.Reflexes = true;
          if (GameGlobals.AlphabetMode || this.StudentManager.MissionMode)
          {
            this.OriginalPersona = PersonaType.Heroic;
            this.Persona = PersonaType.Heroic;
            this.Reflexes = false;
            this.Strength = 5;
          }
          else
            this.LovestruckTarget = 11;
          if ((UnityEngine.Object) this.StudentManager.Students[11] != (UnityEngine.Object) null && DatingGlobals.SuitorProgress < 2 && (double) StudentGlobals.GetStudentReputation(10) > -33.333328247070313 && StudentGlobals.StudentSlave != 11 && !GameGlobals.AlphabetMode && !this.StudentManager.MissionMode)
          {
            this.StudentManager.Patrols.List[this.StudentID].parent = this.StudentManager.Students[11].transform;
            this.StudentManager.Patrols.List[this.StudentID].localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.StudentManager.Patrols.List[this.StudentID].localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            this.VomitPhase = -1;
            this.Indoors = true;
            this.Spawned = true;
            this.Calm = true;
            if ((UnityEngine.Object) this.ShoeRemoval.Locker == (UnityEngine.Object) null)
              this.ShoeRemoval.Start();
            this.ShoeRemoval.PutOnShoes();
            this.FollowTarget = this.StudentManager.Students[11];
            this.FollowTarget.Follower = this;
            this.IdleAnim = "f02_idleGirly_00";
            this.WalkAnim = "f02_walkGirly_00";
            this.PatrolAnim = "f02_stretch_00";
            this.OriginalIdleAnim = this.IdleAnim;
          }
          else
          {
            if ((UnityEngine.Object) this.StudentManager.Students[11] == (UnityEngine.Object) null || StudentGlobals.StudentSlave == 11 || GameGlobals.AlphabetMode || this.StudentManager.MissionMode)
              this.RaibaruOsanaDeathScheduleChanges();
            else if ((double) StudentGlobals.GetStudentReputation(10) <= -33.333328247070313)
            {
              this.ShoeRemoval.PutOnShoes();
              ScheduleBlock scheduleBlock7 = this.ScheduleBlocks[2];
              scheduleBlock7.destination = "Seat";
              scheduleBlock7.action = "Sit";
              scheduleBlock7.time = 8f;
              ScheduleBlock scheduleBlock8 = this.ScheduleBlocks[4];
              scheduleBlock8.destination = "Seat";
              scheduleBlock8.action = "Sit";
              this.IdleAnim = this.BulliedIdleAnim;
              this.WalkAnim = this.BulliedWalkAnim;
              this.OriginalIdleAnim = this.IdleAnim;
            }
            else if (DatingGlobals.SuitorProgress == 2)
            {
              ScheduleBlock scheduleBlock9 = this.ScheduleBlocks[2];
              scheduleBlock9.destination = "Peek";
              scheduleBlock9.action = "Peek";
              scheduleBlock9.time = 8f;
              ScheduleBlock scheduleBlock10 = this.ScheduleBlocks[4];
              scheduleBlock10.destination = "LunchSpot";
              scheduleBlock10.action = "Eat";
            }
            this.RaibaruStopsFollowingOsana();
            this.TargetDistance = 0.5f;
          }
          this.PhotoPatience = 0.0f;
          this.OriginalWalkAnim = this.WalkAnim;
          this.CharacterAnimation["f02_nervousLeftRight_00"].speed = 0.5f;
        }
        else if (this.StudentID == 11)
        {
          this.SmartPhone.transform.localPosition = new Vector3(-0.0075f, -1f / 400f, -0.0075f);
          this.SmartPhone.transform.localEulerAngles = new Vector3(5f, -150f, 170f);
          this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.OsanaPhoneTexture;
          this.IdleAnim = "f02_tsunIdle_00";
          this.WalkAnim = "f02_tsunWalk_00";
          this.TaskAnims[0] = "f02_Task33_Line0";
          this.TaskAnims[1] = "f02_Task33_Line1";
          this.TaskAnims[2] = "f02_Task33_Line2";
          this.TaskAnims[3] = "f02_Task33_Line3";
          this.TaskAnims[4] = "f02_Task33_Line4";
          this.TaskAnims[5] = "f02_Task33_Line5";
          this.LovestruckTarget = 1;
          this.PhotoPatience = 0.0f;
          if ((UnityEngine.Object) this.StudentManager.Students[10] == (UnityEngine.Object) null)
          {
            Debug.Log((object) "Raibaru has been killed/arrested/vanished, so Osana's schedule has changed.");
            ScheduleBlock scheduleBlock11 = this.ScheduleBlocks[2];
            scheduleBlock11.destination = "Mourn";
            scheduleBlock11.action = "Mourn";
            ScheduleBlock scheduleBlock12 = this.ScheduleBlocks[7];
            scheduleBlock12.destination = "Mourn";
            scheduleBlock12.action = "Mourn";
            this.IdleAnim = this.BulliedIdleAnim;
            this.WalkAnim = this.BulliedWalkAnim;
          }
          else if (PlayerGlobals.RaibaruLoner || GameGlobals.AlphabetMode || this.StudentManager.MissionMode)
          {
            ScheduleBlock scheduleBlock13 = this.ScheduleBlocks[2];
            scheduleBlock13.destination = "Patrol";
            scheduleBlock13.action = "Patrol";
            ScheduleBlock scheduleBlock14 = this.ScheduleBlocks[7];
            scheduleBlock14.destination = "Patrol";
            scheduleBlock14.action = "Patrol";
            this.PatrolAnim = "f02_pondering_00";
            if (this.StudentManager.MissionMode)
            {
              this.OriginalPersona = PersonaType.Loner;
              this.Persona = PersonaType.Loner;
            }
          }
          this.OriginalWalkAnim = this.WalkAnim;
        }
        else if (this.StudentID == 12)
        {
          this.IdleAnim = "f02_idleGirly_00";
          this.WalkAnim = "f02_walkGirly_00";
          this.Distracted = true;
          this.CanTalk = false;
        }
        else if (this.StudentID == 24 && this.StudentID == 25)
        {
          this.IdleAnim = "f02_idleGirly_00";
          this.WalkAnim = "f02_walkGirly_00";
        }
        else if (this.StudentID == 26)
        {
          this.IdleAnim = "idleHaughty_00";
          this.WalkAnim = "walkHaughty_00";
        }
        else if (this.StudentID == 28 || this.StudentID == 30)
        {
          if (this.StudentID == 30)
            this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.KokonaPhoneTexture;
        }
        else if (this.StudentID == 31)
        {
          this.IdleAnim = this.BulliedIdleAnim;
          this.WalkAnim = this.BulliedWalkAnim;
        }
        else if (this.StudentID == 34 || this.StudentID == 35)
        {
          this.IdleAnim = "f02_idleShort_00";
          this.WalkAnim = "f02_newWalk_00";
          if ((double) this.Paranoia > 1.666659951210022)
          {
            this.IdleAnim = this.ParanoidAnim;
            this.WalkAnim = this.ParanoidWalkAnim;
          }
        }
        else if (this.StudentID == 36)
        {
          if (TaskGlobals.GetTaskStatus(36) < 3)
          {
            this.IdleAnim = "slouchIdle_00";
            this.WalkAnim = "slouchWalk_00";
            this.ClubAnim = "slouchGaming_00";
          }
          else
          {
            this.IdleAnim = "properIdle_00";
            this.WalkAnim = "properWalk_00";
            this.ClubAnim = "properGaming_00";
          }
          if ((double) this.Paranoia > 1.666659951210022)
          {
            this.IdleAnim = this.ParanoidAnim;
            this.WalkAnim = this.ParanoidWalkAnim;
          }
          if (this.StudentManager.MissionMode)
          {
            ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
            scheduleBlock.destination = "LunchSpot";
            scheduleBlock.action = "Eat";
          }
        }
        else if (this.StudentID == 39)
        {
          this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.MidoriPhoneTexture;
          this.PatrolAnim = "f02_midoriTexting_00";
        }
        else if (this.StudentID == 51)
        {
          this.IdleAnim = "f02_idleConfident_01";
          this.WalkAnim = "f02_walkConfident_01";
          if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
          {
            this.IdleAnim = this.BulliedIdleAnim;
            this.WalkAnim = this.BulliedWalkAnim;
            this.CameraAnims = this.CowardAnims;
            this.OriginalPersona = PersonaType.Loner;
            this.Persona = PersonaType.Loner;
            if (!SchoolGlobals.RoofFence)
            {
              ScheduleBlock scheduleBlock15 = this.ScheduleBlocks[2];
              scheduleBlock15.destination = "Sulk";
              scheduleBlock15.action = "Sulk";
              ScheduleBlock scheduleBlock16 = this.ScheduleBlocks[4];
              scheduleBlock16.destination = "Sulk";
              scheduleBlock16.action = "Sulk";
              ScheduleBlock scheduleBlock17 = this.ScheduleBlocks[7];
              scheduleBlock17.destination = "Sulk";
              scheduleBlock17.action = "Sulk";
              ScheduleBlock scheduleBlock18 = this.ScheduleBlocks[8];
              scheduleBlock18.destination = "Sulk";
              scheduleBlock18.action = "Sulk";
            }
            else
            {
              ScheduleBlock scheduleBlock19 = this.ScheduleBlocks[2];
              scheduleBlock19.destination = "Seat";
              scheduleBlock19.action = "Sit";
              ScheduleBlock scheduleBlock20 = this.ScheduleBlocks[4];
              scheduleBlock20.destination = "Seat";
              scheduleBlock20.action = "Sit";
              ScheduleBlock scheduleBlock21 = this.ScheduleBlocks[7];
              scheduleBlock21.destination = "Seat";
              scheduleBlock21.action = "Sit";
              ScheduleBlock scheduleBlock22 = this.ScheduleBlocks[8];
              scheduleBlock22.destination = "Seat";
              scheduleBlock22.action = "Sit";
            }
          }
          if (this.StudentManager.MissionMode)
          {
            ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
            scheduleBlock.destination = "LunchSpot";
            scheduleBlock.action = "Eat";
          }
        }
        else if (this.StudentID == 56)
        {
          this.IdleAnim = "idleConfident_00";
          this.WalkAnim = "walkConfident_00";
          this.SleuthID = 1;
        }
        else if (this.StudentID == 57)
        {
          this.IdleAnim = "idleChill_01";
          this.WalkAnim = "walkChill_01";
          this.SleuthID = 20;
        }
        else if (this.StudentID == 58)
        {
          this.IdleAnim = "idleChill_00";
          this.WalkAnim = "walkChill_00";
          this.SleuthID = 40;
        }
        else if (this.StudentID == 59)
        {
          this.IdleAnim = "f02_idleGraceful_00";
          this.WalkAnim = "f02_walkGraceful_00";
          this.SleuthID = 60;
        }
        else if (this.StudentID == 60)
        {
          this.IdleAnim = "f02_idleScholarly_00";
          this.WalkAnim = "f02_walkScholarly_00";
          this.CameraAnims = this.HeroAnims;
          this.SleuthID = 80;
        }
        else if (this.StudentID == 61)
        {
          this.IdleAnim = "scienceIdle_00";
          this.WalkAnim = "scienceWalk_00";
          this.OriginalWalkAnim = "scienceWalk_00";
        }
        else if (this.StudentID == 62)
        {
          this.IdleAnim = "idleFrown_00";
          this.WalkAnim = "walkFrown_00";
          if ((double) this.Paranoia > 1.666659951210022)
          {
            this.IdleAnim = this.ParanoidAnim;
            this.WalkAnim = this.ParanoidWalkAnim;
          }
        }
        else if (this.StudentID == 64 || this.StudentID == 65)
        {
          this.IdleAnim = "f02_idleShort_00";
          this.WalkAnim = "f02_newWalk_00";
          if ((double) this.Paranoia > 1.666659951210022)
          {
            this.IdleAnim = this.ParanoidAnim;
            this.WalkAnim = this.ParanoidWalkAnim;
          }
        }
        else if (this.StudentID == 66)
        {
          this.IdleAnim = "pose_03";
          this.OriginalWalkAnim = "walkConfident_00";
          this.WalkAnim = "walkConfident_00";
          this.ClubThreshold = 100f;
        }
        else if (this.StudentID == 69)
        {
          this.IdleAnim = "idleFrown_00";
          this.WalkAnim = "walkFrown_00";
          if ((double) this.Paranoia > 1.666659951210022)
          {
            this.IdleAnim = this.ParanoidAnim;
            this.WalkAnim = this.ParanoidWalkAnim;
          }
        }
        else if (this.StudentID == 71)
        {
          this.IdleAnim = "f02_idleGirly_00";
          this.WalkAnim = "f02_walkGirly_00";
          if (!this.PickPocket.gameObject.transform.parent.gameObject.activeInHierarchy)
            this.PickPocket.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if ((this.StudentID == 6 || this.StudentID == 11) && DatingGlobals.SuitorProgress == 2)
        {
          this.Partner = this.StudentID == 11 ? this.StudentManager.Students[6] : this.StudentManager.Students[11];
          ScheduleBlock scheduleBlock23 = this.ScheduleBlocks[2];
          scheduleBlock23.destination = "Cuddle";
          scheduleBlock23.action = "Cuddle";
          ScheduleBlock scheduleBlock24 = this.ScheduleBlocks[4];
          scheduleBlock24.destination = "Cuddle";
          scheduleBlock24.action = "Cuddle";
          ScheduleBlock scheduleBlock25 = this.ScheduleBlocks[6];
          scheduleBlock25.destination = "Locker";
          scheduleBlock25.action = "Shoes";
          ScheduleBlock scheduleBlock26 = this.ScheduleBlocks[7];
          scheduleBlock26.destination = "Exit";
          scheduleBlock26.action = "Exit";
        }
      }
      else
      {
        this.BookRenderer.material.mainTexture = this.RedBookTexture;
        this.Phoneless = true;
        if (!this.Male)
          this.PatrolAnim = "f02_thinking_00";
        if (this.Rival)
        {
          if (this.StudentID > 10 && this.StudentID < 21)
          {
            ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
            scheduleBlock.destination = "Seat";
            scheduleBlock.action = "PlaceBag";
          }
          this.BookBag.SetActive(true);
          this.LovestruckTarget = 1;
        }
        if (this.StudentID == 11)
        {
          this.IdleAnim = "f02_idleGirly_00";
          this.WalkAnim = "f02_walkGirly_00";
          if (!this.Rival)
            this.Persona = PersonaType.LandlineUser;
        }
        else if (this.StudentID == 12)
        {
          this.CharacterAnimation["f02_startFire_00"].speed = 2f;
          this.IdleAnim = "f02_idleConfident_01";
          this.WalkAnim = "f02_walkConfident_01";
          this.PyroUrge = true;
          if (!this.Rival)
            this.Persona = PersonaType.LandlineUser;
        }
        else if (this.StudentID == 13)
        {
          this.IdleAnim = "f02_idleShy_00";
          this.WalkAnim = "f02_walkShy_00";
          if (!this.Rival)
            this.Persona = PersonaType.Coward;
        }
        else if (this.StudentID == 14)
        {
          this.IdleAnim = "f02_idleLively_00";
          this.WalkAnim = "f02_walkLively_00";
          this.ClubAnim = "f02_stretch_00";
          if (!this.Rival)
            this.Persona = PersonaType.Heroic;
        }
        else if (this.StudentID == 15)
        {
          this.IdleAnim = "f02_idleHaughty_00";
          this.WalkAnim = "f02_walkHaughty_00";
          if (!this.Rival)
            this.Persona = PersonaType.Loner;
        }
        else if (this.StudentID == 16)
        {
          this.IdleAnim = "f02_idleGirly_00";
          this.WalkAnim = "f02_walkGirly_00";
          this.ClubAnim = "f02_vocalSingA_00";
          if (DateGlobals.Week != 6)
          {
            ScheduleBlock scheduleBlock27 = this.ScheduleBlocks[2];
            scheduleBlock27.destination = "Lyrics";
            scheduleBlock27.action = "Lyrics";
            ScheduleBlock scheduleBlock28 = this.ScheduleBlocks[7];
            scheduleBlock28.destination = "Lyrics";
            scheduleBlock28.action = "Lyrics";
          }
          if (!this.Rival)
            this.Persona = PersonaType.LandlineUser;
        }
        else if (this.StudentID == 17 || this.StudentID == 18)
        {
          this.IdleAnim = "f02_idleCouncilGrace_00";
          this.WalkAnim = "f02_walkCouncilGrace_00";
          this.MyRenderer.SetBlendShapeWeight(0, 100f);
          if (!this.Rival)
            this.Persona = PersonaType.TeachersPet;
        }
        else if (this.StudentID == 19)
        {
          this.IdleAnim = "f02_idleElegant_00";
          this.WalkAnim = "f02_walkElegant_00";
          this.OriginalWalkAnim = "f02_walkElegant_00";
          this.OriginalOriginalWalkAnim = "f02_walkElegant_00";
          this.ClubAnim = this.GravureAnims[0];
          if (!this.Rival)
            this.Persona = PersonaType.LandlineUser;
        }
        else if (this.StudentID == 20)
        {
          this.IdleAnim = "f02_idleConfident_00";
          this.WalkAnim = "f02_walkConfident_00";
          this.Shovey = !this.StudentManager.RivalEliminated;
          if (!this.Rival)
            this.Persona = PersonaType.Heroic;
          this.Suffix = "Strict";
          this.IdleAnim = "f02_idleCouncil" + this.Suffix + "_00";
          this.WalkAnim = "f02_walkCouncil" + this.Suffix + "_00";
          this.ShoveAnim = "f02_pushCouncil" + this.Suffix + "_00";
          this.PatrolAnim = "f02_scanCouncil" + this.Suffix + "_00";
          this.RelaxAnim = "f02_relaxCouncil" + this.Suffix + "_00";
          this.SprayAnim = "f02_sprayCouncil" + this.Suffix + "_00";
          this.BreakUpAnim = "f02_stopCouncil" + this.Suffix + "_00";
          this.PickUpAnim = "f02_teacherPickUp_00";
        }
        else if (this.StudentID == 36)
        {
          this.BecomeSleuth();
          if ((double) this.StudentManager.Atmosphere > 0.800000011920929)
          {
            this.CharacterAnimation["f02_smile_00"].layer = 1;
            this.CharacterAnimation.Play("f02_smile_00");
            this.CharacterAnimation["f02_smile_00"].weight = 1f;
          }
        }
        else if (this.StudentID == 66)
          this.ClubThreshold = 100f;
        if (this.StudentID > 10 && this.StudentID < 21)
          this.OriginalPersona = this.Persona;
        if (this.Club == ClubType.Delinquent)
        {
          if (this.Male)
            this.CharacterAnimation[this.WalkAnim].speed += 0.01f * (float) (this.StudentID - 76);
          else
            this.Jaw.gameObject.name += "_RENAMED";
        }
        this.GuardID = this.StudentID != 20 ? 20 : 1;
      }
      this.OriginalWalkAnim = this.WalkAnim;
      if (StudentGlobals.GetStudentGrudge(this.StudentID))
      {
        if (this.Persona != PersonaType.Coward && this.Persona != PersonaType.Fragile && this.Persona != PersonaType.Evil && this.Club != ClubType.Delinquent)
        {
          this.CameraAnims = this.EvilAnims;
          this.Reputation.PendingRep -= 10f;
          this.PendingRep -= 10f;
          for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
          {
            if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
              this.Outlines[this.ID].color = new Color(1f, 1f, 0.0f, 1f);
          }
        }
        this.Grudge = true;
        this.CameraAnims = this.EvilAnims;
      }
      if (this.Rival)
      {
        for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
        {
          if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
            this.Outlines[this.ID].color = new Color(10f, 0.0f, 0.0f, 1f);
        }
      }
      if (this.Persona == PersonaType.Sleuth)
      {
        if ((double) SchoolGlobals.SchoolAtmosphere <= 0.800000011920929 || this.Grudge)
          this.BecomeSleuth();
        else if ((double) SchoolGlobals.SchoolAtmosphere <= 0.89999997615814209)
        {
          this.WalkAnim = this.ParanoidWalkAnim;
          this.CameraAnims = this.HeroAnims;
        }
      }
      if (!this.Slave)
      {
        if (this.StudentManager.Bullies > 1)
        {
          if (this.StudentID == 81 || this.StudentID == 83 || this.StudentID == 85)
          {
            if (this.Persona != PersonaType.Coward)
            {
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              this.Paired = true;
              this.CharacterAnimation["f02_walkTalk_00"].time += (float) (this.StudentID - 81);
              this.WalkAnim = "f02_walkTalk_00";
              this.SpeechLines.Play();
            }
          }
          else if (this.StudentID == 82 || this.StudentID == 84)
          {
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Paired = true;
            this.CharacterAnimation["f02_walkTalk_01"].time += (float) (this.StudentID - 81);
            this.WalkAnim = "f02_walkTalk_01";
            this.SpeechLines.Play();
          }
        }
        if (this.Club == ClubType.Delinquent)
        {
          if (this.Friend)
            this.RespectEarned = true;
          if (CounselorGlobals.WeaponsBanned == 0)
          {
            this.MyWeapon = this.Yandere.WeaponManager.DelinquentWeapons[this.StudentID - 75];
            this.MyWeapon.transform.parent = this.WeaponBagParent;
            this.MyWeapon.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.MyWeapon.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            this.MyWeapon.FingerprintID = this.StudentID;
            this.MyWeapon.MyCollider.enabled = false;
            this.WeaponBag.SetActive(true);
          }
          else
          {
            this.OriginalPersona = PersonaType.Heroic;
            this.Persona = PersonaType.Heroic;
          }
          string str = "";
          if (!this.Male)
            str = "f02_";
          this.ScaredAnim = "delinquentCombatIdle_00";
          this.LeanAnim = "delinquentConcern_00";
          this.ShoveAnim = str + "pushTough_00";
          this.WalkAnim = str + "walkTough_00";
          this.IdleAnim = str + "idleTough_00";
          this.SpeechLines = this.DelinquentSpeechLines;
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.Paired = true;
          this.TaskAnims[0] = str + "delinquentTalk_04";
          this.TaskAnims[1] = str + "delinquentTalk_01";
          this.TaskAnims[2] = str + "delinquentTalk_02";
          this.TaskAnims[3] = str + "delinquentTalk_03";
          this.TaskAnims[4] = str + "delinquentTalk_00";
          this.TaskAnims[5] = str + "delinquentTalk_03";
        }
      }
      else
        this.Club = ClubType.None;
      if (this.Rival)
      {
        this.RivalPrefix = "Rival ";
        if (DateGlobals.Weekday == DayOfWeek.Friday)
          this.ScheduleBlocks[7].time = 17f;
      }
      if (!this.Teacher && this.Name != "Random")
      {
        this.StudentManager.CleaningManager.GetRole(this.StudentID);
        this.CleaningSpot = this.StudentManager.CleaningManager.Spot;
        this.CleaningRole = this.StudentManager.CleaningManager.Role;
      }
      if (this.Club == ClubType.Cooking)
      {
        this.SleuthID = (this.StudentID - 21) * 20;
        this.ClubAnim = this.PrepareFoodAnim;
        if (this.StudentID > 12)
        {
          this.ClubMemberID = this.StudentID - 20;
          this.MyPlate = this.StudentManager.Plates[this.ClubMemberID];
          this.OriginalPlatePosition = this.MyPlate.position;
          this.OriginalPlateRotation = this.MyPlate.rotation;
        }
        if (!this.StudentManager.EmptyDemon && !this.StudentManager.TutorialActive)
          this.ApronAttacher.enabled = true;
      }
      else if (this.Club == ClubType.Drama)
      {
        if (this.StudentID == 26)
          this.ClubAnim = "teaching_00";
        else if (this.StudentID == 27 || this.StudentID == 28)
          this.ClubAnim = "sit_00";
        else if (this.StudentID == 29 || this.StudentID == 30)
          this.ClubAnim = "f02_sit_00";
        this.OriginalClubAnim = this.ClubAnim;
      }
      else if (this.Club == ClubType.Occult)
      {
        this.PatrolAnim = this.ThinkAnim;
        this.CharacterAnimation[this.PatrolAnim].speed = 0.2f;
      }
      else if (this.Club == ClubType.Gaming)
      {
        this.MiyukiGameScreen.SetActive(true);
        this.ClubMemberID = this.StudentID - 35;
        if (this.StudentID > 36)
          this.ClubAnim = this.GameAnim;
        this.ActivityAnim = this.GameAnim;
      }
      else if (this.Club == ClubType.Art)
      {
        this.ChangingBooth = this.StudentManager.ChangingBooths[4];
        this.ActivityAnim = this.PaintAnim;
        this.Attacher.ArtClub = true;
        this.ClubAnim = this.PaintAnim;
        this.DressCode = true;
        if (this.StudentManager.Week == 1 && DateGlobals.Weekday == DayOfWeek.Friday)
        {
          Debug.Log((object) "It's Friday, so the art club is changing their club activity to painting the cherry tree.");
          ScheduleBlock scheduleBlock = this.ScheduleBlocks[7];
          scheduleBlock.destination = "Paint";
          scheduleBlock.action = "Paint";
          this.VisionDistance += 5f;
        }
        this.ClubMemberID = this.StudentID - 40;
        this.Painting = this.StudentManager.FridayPaintings[this.ClubMemberID];
        this.GetDestinations();
      }
      else if (this.Club == ClubType.LightMusic)
      {
        this.ClubMemberID = this.StudentID - 50;
        this.InstrumentBag[this.ClubMemberID].SetActive(true);
        if (this.StudentID == 51)
          this.ClubAnim = "f02_practiceGuitar_01";
        else if (this.StudentID == 52 || this.StudentID == 53)
          this.ClubAnim = "f02_practiceGuitar_00";
        else if (this.StudentID == 54)
        {
          this.ClubAnim = "f02_practiceDrums_00";
          this.Instruments[4] = this.StudentManager.DrumSet;
          if (this.StudentManager.Eighties)
          {
            this.InstrumentBag[this.ClubMemberID].GetComponent<Renderer>().enabled = false;
            this.Instruments[this.ClubMemberID].GetComponent<Renderer>().enabled = false;
          }
        }
        else if (this.StudentID == 55)
          this.ClubAnim = "f02_practiceKeytar_00";
        if (this.StudentManager.Eighties && (UnityEngine.Object) this.StudentManager.Students[16] != (UnityEngine.Object) null && DateGlobals.Week == 6)
        {
          this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().enabled = false;
          this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().volume = 0.0f;
          if (this.StudentID == 52)
            this.ClubAnim = "f02_guitarPlayA_00";
          else if (this.StudentID == 53)
            this.ClubAnim = "f02_guitarPlayB_00";
          else if (this.StudentID == 54)
            this.ClubAnim = "f02_drumsPlay_00";
          else if (this.StudentID == 55)
            this.ClubAnim = "f02_keysPlay_00";
        }
      }
      else if (this.Club == ClubType.MartialArts)
      {
        this.ChangingBooth = this.StudentManager.ChangingBooths[6];
        this.DressCode = true;
        if (this.StudentID == 46)
        {
          this.IdleAnim = "pose_03";
          this.ClubAnim = "pose_03";
          this.ActivityAnim = this.IdleAnim;
        }
        else if (this.StudentID == 47)
        {
          this.GetNewAnimation = true;
          this.ClubAnim = "idle_20";
          this.ActivityAnim = "kick_24";
        }
        else if (this.StudentID == 48)
        {
          this.ClubAnim = "sit_04";
          this.ActivityAnim = "kick_24";
        }
        else if (this.StudentID == 49)
        {
          this.GetNewAnimation = true;
          this.ClubAnim = "f02_idle_20";
          this.ActivityAnim = "f02_kick_23";
        }
        else if (this.StudentID == 50)
        {
          this.ClubAnim = "f02_sit_05";
          this.ActivityAnim = "f02_kick_23";
        }
        this.ClubMemberID = this.StudentID - 45;
      }
      else if (this.Club == ClubType.Science)
      {
        if (!this.StudentManager.Eighties)
        {
          this.ChangingBooth = this.StudentManager.ChangingBooths[8];
          this.Attacher.ScienceClub = true;
          this.DressCode = true;
          if (this.StudentID == 61)
            this.ClubAnim = "scienceMad_00";
          else if (this.StudentID == 62)
            this.ClubAnim = "scienceTablet_00";
          else if (this.StudentID == 63)
            this.ClubAnim = "scienceChemistry_00";
          else if (this.StudentID == 64)
            this.ClubAnim = "f02_scienceLeg_00";
          else if (this.StudentID == 65)
            this.ClubAnim = "f02_scienceConsole_00";
        }
        else
          this.ClubAnim = !this.Male ? "f02_scienceChemistry_00" : "scienceChemistry_00";
        this.ClubMemberID = this.StudentID - 60;
      }
      else if (this.Club == ClubType.Sports)
      {
        if (this.Male)
        {
          this.ChangingBooth = this.StudentManager.ChangingBooths[9];
          this.ClubAnim = "stretch_00";
        }
        else
        {
          this.ChangingBooth = this.StudentManager.ChangingBooths[10];
          this.ClubAnim = "f02_stretch_00";
        }
        this.DressCode = true;
        this.ClubMemberID = this.StudentID - 65;
      }
      else if (this.Club == ClubType.Gardening)
      {
        if (!this.StudentManager.Eighties)
        {
          if (this.StudentID == 71)
          {
            this.PatrolAnim = "f02_thinking_00";
            this.ClubAnim = "f02_thinking_00";
            this.CharacterAnimation[this.PatrolAnim].speed = 0.9f;
          }
          else
          {
            this.ClubAnim = "f02_waterPlant_00";
            this.WateringCan.SetActive(true);
          }
        }
        else
        {
          if (this.Male)
          {
            this.PatrolAnim = "thinking_00";
            this.ClubAnim = "thinking_00";
          }
          else
          {
            this.PatrolAnim = "f02_thinking_00";
            this.ClubAnim = "f02_thinking_00";
          }
          this.CharacterAnimation[this.PatrolAnim].speed = 0.9f;
        }
      }
      else if (this.Club == ClubType.Newspaper)
      {
        if (this.StudentID == 36)
          this.ClubAnim = "f02_pondering_00";
        else if (this.Male)
        {
          this.PatrolAnim = "thinking_00";
          this.ClubAnim = "onComputer_00";
        }
        else
        {
          this.PatrolAnim = "f02_thinking_00";
          this.ClubAnim = "f02_onComputer_00";
        }
        this.OriginalClubAnim = this.ClubAnim;
      }
      if (this.OriginalClub != ClubType.Gaming)
        this.Miyuki.gameObject.SetActive(false);
      if (this.Cosmetic.Hairstyle == 20)
        this.IdleAnim = "f02_tsunIdle_00";
      this.GetDestinations();
      this.OriginalActions = new StudentActionType[this.Actions.Length];
      Array.Copy((Array) this.Actions, (Array) this.OriginalActions, this.Actions.Length);
      if (this.AoT)
        this.AttackOnTitan();
      if (this.Slave)
      {
        this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
        this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
        this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
        this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
        this.IdleAnim = this.BrokenAnim;
        this.WalkAnim = this.BrokenWalkAnim;
        this.RightEmptyEye.SetActive(true);
        this.LeftEmptyEye.SetActive(true);
        this.SmartPhone.SetActive(false);
        this.Distracted = true;
        this.Indoors = true;
        this.Safe = false;
        this.Shy = false;
        for (this.ID = 0; this.ID < this.ScheduleBlocks.Length; ++this.ID)
          this.ScheduleBlocks[this.ID].time = 0.0f;
        if (this.FragileSlave)
          this.HuntTarget = this.StudentManager.Students[StudentGlobals.FragileTarget];
      }
      if (this.Spooky)
        this.Spook();
      this.Prompt.HideButton[0] = true;
      this.Prompt.HideButton[2] = true;
      for (this.ID = 0; this.ID < this.Ragdoll.AllRigidbodies.Length; ++this.ID)
      {
        this.Ragdoll.AllRigidbodies[this.ID].isKinematic = true;
        this.Ragdoll.AllColliders[this.ID].enabled = false;
      }
      this.Ragdoll.AllColliders[10].enabled = true;
      if (this.StudentID == 1)
      {
        this.Yandere.Senpai = this.transform;
        this.Yandere.LookAt.target = this.Head;
        for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
        {
          if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
          {
            this.Outlines[this.ID].enabled = true;
            this.Outlines[this.ID].color = new Color(1f, 0.0f, 1f);
          }
        }
        this.Prompt.ButtonActive[0] = false;
        this.Prompt.ButtonActive[1] = false;
        this.Prompt.ButtonActive[2] = false;
        this.Prompt.ButtonActive[3] = false;
        if (this.StudentManager.MissionMode || GameGlobals.SenpaiMourning)
        {
          this.transform.position = Vector3.zero;
          this.gameObject.SetActive(false);
        }
      }
      else if (!this.StudentManager.StudentPhotographed[this.StudentID] && !this.Rival)
      {
        for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
        {
          if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
          {
            this.Outlines[this.ID].enabled = false;
            this.Outlines[this.ID].color = new Color(0.0f, 1f, 0.0f);
          }
        }
      }
      this.PickRandomAnim();
      this.PickRandomSleuthAnim();
      Renderer component = this.Armband.GetComponent<Renderer>();
      if (this.Club != ClubType.None && (this.StudentID == 21 || this.StudentID == 26 || this.StudentID == 31 || this.StudentID == 36 || this.StudentID == 41 || this.StudentID == 46 || this.StudentID == 51 || this.StudentID == 56 || this.StudentID == 61 || this.StudentID == 66 || this.StudentID == 71))
      {
        this.Armband.SetActive(true);
        this.ClubLeader = true;
        if (this.StudentManager.EmptyDemon)
        {
          this.IdleAnim = this.OriginalIdleAnim;
          this.WalkAnim = this.OriginalOriginalWalkAnim;
          this.OriginalPersona = PersonaType.Evil;
          this.Persona = PersonaType.Evil;
          this.ScaredAnim = this.EvilWitnessAnim;
        }
      }
      if (!this.Teacher)
      {
        this.CurrentDestination = this.Destinations[this.Phase];
        this.Pathfinding.target = this.Destinations[this.Phase];
      }
      else
        this.Indoors = true;
      if (this.StudentID == 1 || this.StudentID == 4 || this.StudentID == 5 || this.StudentID == 11)
        this.BookRenderer.material.mainTexture = this.RedBookTexture;
      this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      if (this.StudentManager.MissionMode && this.StudentID == MissionModeGlobals.MissionTarget || this.Rival)
      {
        for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
        {
          if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
          {
            this.Outlines[this.ID].enabled = true;
            this.Outlines[this.ID].color = new Color(1f, 0.0f, 0.0f);
          }
        }
      }
      UnityEngine.Object.Destroy((UnityEngine.Object) this.MyRigidbody);
      this.Started = true;
      if (this.Club == ClubType.Council)
      {
        component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, 0.0f));
        this.Armband.SetActive(true);
        this.Indoors = true;
        this.Spawned = true;
        if ((UnityEngine.Object) this.ShoeRemoval.Locker == (UnityEngine.Object) null)
          this.ShoeRemoval.Start();
        this.ShoeRemoval.PutOnShoes();
        if (this.StudentID == 86)
          this.Suffix = "Strict";
        else if (this.StudentID == 87)
          this.Suffix = "Casual";
        else if (this.StudentID == 88)
          this.Suffix = "Grace";
        else if (this.StudentID == 89)
          this.Suffix = "Edgy";
        if (!this.StudentManager.Eighties)
        {
          this.IdleAnim = "f02_idleCouncil" + this.Suffix + "_00";
          this.WalkAnim = "f02_walkCouncil" + this.Suffix + "_00";
          this.ShoveAnim = "f02_pushCouncil" + this.Suffix + "_00";
          this.PatrolAnim = "f02_scanCouncil" + this.Suffix + "_00";
          this.RelaxAnim = "f02_relaxCouncil" + this.Suffix + "_00";
          this.SprayAnim = "f02_sprayCouncil" + this.Suffix + "_00";
          this.BreakUpAnim = "f02_stopCouncil" + this.Suffix + "_00";
          this.PickUpAnim = "f02_teacherPickUp_00";
        }
        else
        {
          this.IdleAnim = idleAnim;
          this.BreakUpAnim = "delinquentTalk_03";
          this.GuardAnim = this.ReadyToFightAnim;
          this.RelaxAnim = "sit_00";
          if (this.StudentID == 89)
            this.RelaxAnim = "crossarms_00";
        }
        this.ScaredAnim = this.ReadyToFightAnim;
        this.ParanoidAnim = this.GuardAnim;
        this.CameraAnims[1] = this.IdleAnim;
        this.CameraAnims[2] = this.IdleAnim;
        this.CameraAnims[3] = this.IdleAnim;
        this.ClubMemberID = this.StudentID - 85;
        this.VisionDistance *= 2f;
      }
      if (!this.StudentManager.NoClubMeeting && this.Armband.activeInHierarchy && this.Clock.Weekday == 5)
      {
        if (this.StudentID < 86)
        {
          ScheduleBlock scheduleBlock = this.ScheduleBlocks[6];
          scheduleBlock.destination = "Meeting";
          scheduleBlock.action = "Meeting";
        }
        else
        {
          ScheduleBlock scheduleBlock = this.ScheduleBlocks[5];
          scheduleBlock.destination = "Meeting";
          scheduleBlock.action = "Meeting";
        }
        this.GetDestinations();
      }
      if (this.StudentID == 81 && StudentGlobals.GetStudentBroken(81))
      {
        this.Destinations[2] = this.StudentManager.BrokenSpot;
        this.Destinations[4] = this.StudentManager.BrokenSpot;
        this.Actions[2] = StudentActionType.Shamed;
        this.Actions[4] = StudentActionType.Shamed;
      }
    }
    this.UpdateAnimLayers();
    if (!this.Male)
    {
      if (this.StudentID == 40)
        this.LongHair[0] = this.LongHair[2];
      if (this.StudentID != 55 && this.StudentID != 40)
      {
        this.LongHair[0] = (Transform) null;
        this.LongHair[1] = (Transform) null;
        this.LongHair[2] = (Transform) null;
      }
    }
    this.SetOriginalScheduleBlocks();
    if (this.StudentManager.Randomize)
    {
      this.OriginalPersona = PersonaType.Coward;
      this.Persona = PersonaType.Coward;
    }
    if ((double) this.StudentManager.Atmosphere < 0.33333000540733337 && this.Teacher)
    {
      this.OriginalIdleAnim = "f02_idleShort_00";
      this.IdleAnim = "f02_idleShort_00";
      if (this.StudentID == 97)
      {
        this.OriginalIdleAnim = "f02_tsunIdle_00";
        this.IdleAnim = "f02_tsunIdle_00";
      }
    }
    this.CharacterAnimation.Sample();
  }

  private float GetPerceptionPercent(float distance)
  {
    float num = Mathf.Clamp01(distance / this.VisionDistance);
    return (float) (1.0 - (double) num * (double) num);
  }

  private SubtitleType LostPhoneSubtitleType
  {
    get
    {
      if (this.RivalPrefix == string.Empty)
        return SubtitleType.LostPhone;
      if (this.RivalPrefix == "Rival ")
        return SubtitleType.RivalLostPhone;
      throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
    }
  }

  private SubtitleType PickpocketSubtitleType
  {
    get
    {
      Debug.Log((object) "This is where the game determines what pickpocket subtitle to use.");
      if (this.Male)
      {
        this.Subtitle.CustomText = "Hey! Are you trying to take my keys? Knock it off!";
        return SubtitleType.Custom;
      }
      if (this.RivalPrefix == string.Empty)
        return SubtitleType.PickpocketReaction;
      if (this.RivalPrefix == "Rival ")
        return SubtitleType.RivalPickpocketReaction;
      throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
    }
  }

  private SubtitleType SplashSubtitleType
  {
    get
    {
      if (this.RivalPrefix == string.Empty)
        return !this.Male ? SubtitleType.SplashReaction : SubtitleType.SplashReactionMale;
      if (this.RivalPrefix == "Rival ")
        return SubtitleType.RivalSplashReaction;
      throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
    }
  }

  public SubtitleType TaskLineResponseType
  {
    get
    {
      if (this.StudentManager.Eighties && this.StudentID != 79)
        return SubtitleType.TaskGenericEightiesLine;
      if (this.StudentID == 4)
        return SubtitleType.Task4Line;
      if (this.StudentID == 6)
        return SubtitleType.Task6Line;
      if (this.StudentID == 8)
        return SubtitleType.Task8Line;
      if (this.StudentID == 11)
        return SubtitleType.Task11Line;
      if (this.StudentID == 13)
        return SubtitleType.Task13Line;
      if (this.StudentID == 14)
        return SubtitleType.Task14Line;
      if (this.StudentID == 15)
        return SubtitleType.Task15Line;
      if (this.StudentID == 25)
        return SubtitleType.Task25Line;
      if (this.StudentID == 28)
        return SubtitleType.Task28Line;
      if (this.StudentID == 30)
        return SubtitleType.Task30Line;
      if (this.StudentID == 36)
        return SubtitleType.Task36Line;
      if (this.StudentID == 37)
        return SubtitleType.Task37Line;
      if (this.StudentID == 38)
        return SubtitleType.Task38Line;
      if (this.StudentID == 41)
        return SubtitleType.Task41Line;
      if (this.StudentID == 46)
        return SubtitleType.Task46Line;
      if (this.StudentID == 47)
        return SubtitleType.Task47Line;
      if (this.StudentID == 48)
        return SubtitleType.Task48Line;
      if (this.StudentID == 49)
        return SubtitleType.Task49Line;
      if (this.StudentID == 50)
        return SubtitleType.Task50Line;
      if (this.StudentID == 52)
        return SubtitleType.Task52Line;
      if (this.StudentID == 76)
        return SubtitleType.Task76Line;
      if (this.StudentID == 77)
        return SubtitleType.Task77Line;
      if (this.StudentID == 78)
        return SubtitleType.Task78Line;
      if (this.StudentID == 79)
        return SubtitleType.Task79Line;
      if (this.StudentID == 80)
        return SubtitleType.Task80Line;
      return this.StudentID == 81 ? SubtitleType.Task81Line : SubtitleType.TaskGenericLine;
    }
  }

  public SubtitleType ClubInfoResponseType
  {
    get
    {
      if (this.StudentManager.EmptyDemon)
        return SubtitleType.ClubPlaceholderInfo;
      if (this.Club == ClubType.Cooking)
        return SubtitleType.ClubCookingInfo;
      if (this.Club == ClubType.Drama)
        return SubtitleType.ClubDramaInfo;
      if (this.Club == ClubType.Occult)
        return SubtitleType.ClubOccultInfo;
      if (this.Club == ClubType.Art)
        return SubtitleType.ClubArtInfo;
      if (this.Club == ClubType.LightMusic)
        return SubtitleType.ClubLightMusicInfo;
      if (this.Club == ClubType.MartialArts)
        return SubtitleType.ClubMartialArtsInfo;
      if (this.Club == ClubType.Photography)
        return this.Sleuthing ? SubtitleType.ClubPhotoInfoDark : SubtitleType.ClubPhotoInfoLight;
      if (this.Club == ClubType.Science)
        return SubtitleType.ClubScienceInfo;
      if (this.Club == ClubType.Sports)
        return SubtitleType.ClubSportsInfo;
      if (this.Club == ClubType.Gardening)
        return SubtitleType.ClubGardenInfo;
      if (this.Club == ClubType.Gaming)
        return SubtitleType.ClubGamingInfo;
      if (this.Club == ClubType.Delinquent)
        return SubtitleType.ClubDelinquentInfo;
      return this.Club == ClubType.Newspaper ? SubtitleType.ClubNewspaperInfo : SubtitleType.ClubPlaceholderInfo;
    }
  }

  private bool PointIsInFOV(Vector3 point)
  {
    Vector3 position = this.Eyes.transform.position;
    Vector3 to = point - position;
    float num = 90f;
    return (double) Vector3.Angle(this.Head.transform.forward, to) <= (double) num;
  }

  public bool SeenByYandere()
  {
    Debug.Log((object) "A ''SeenByYandere'' check is occuring.");
    Debug.DrawLine(this.Yandere.transform.position + new Vector3(0.0f, 1f, 0.0f), this.transform.position + new Vector3(0.0f, 1f, 0.0f), Color.red);
    RaycastHit hitInfo;
    if (Physics.Linecast(this.Yandere.transform.position + new Vector3(0.0f, 1f, 0.0f), this.transform.position + new Vector3(0.0f, 1f, 0.0f), out hitInfo, (int) this.YandereCheckMask))
    {
      Debug.Log((object) ("Yandere-chan's raycast hit: " + hitInfo.collider.gameObject.name));
      if ((UnityEngine.Object) hitInfo.collider.gameObject == (UnityEngine.Object) this.Head.gameObject || (UnityEngine.Object) hitInfo.collider.gameObject == (UnityEngine.Object) this.gameObject)
        return true;
    }
    return false;
  }

  public bool CanSeeObject(GameObject obj, Vector3 targetPoint, int[] layers, int mask)
  {
    Vector3 position = this.Eyes.transform.position;
    Vector3 vector3 = targetPoint - position;
    if (this.PointIsInFOV(targetPoint))
    {
      float num = this.VisionDistance * this.VisionDistance;
      if ((double) vector3.sqrMagnitude <= (double) num)
      {
        Debug.DrawLine(position, targetPoint, Color.green);
        RaycastHit hitInfo;
        if (Physics.Linecast(position, targetPoint, out hitInfo, mask) && (UnityEngine.Object) hitInfo.collider.gameObject == (UnityEngine.Object) obj)
        {
          foreach (int layer in layers)
          {
            if (hitInfo.collider.gameObject.layer == layer)
              return true;
          }
        }
      }
    }
    return false;
  }

  public bool CanSeeObject(GameObject obj, Vector3 targetPoint)
  {
    if (!this.Blind)
    {
      Debug.DrawLine(this.Eyes.position, targetPoint, Color.green);
      Vector3 position = this.Eyes.transform.position;
      Vector3 vector3 = targetPoint - position;
      float num = this.VisionDistance * this.VisionDistance;
      RaycastHit hitInfo;
      if (this.PointIsInFOV(targetPoint) & (double) vector3.sqrMagnitude <= (double) num && Physics.Linecast(position, targetPoint, out hitInfo, (int) this.Mask) && (UnityEngine.Object) hitInfo.collider.gameObject == (UnityEngine.Object) obj)
        return true;
    }
    return false;
  }

  public bool CanSeeObject(GameObject obj) => this.CanSeeObject(obj, obj.transform.position);

  private void Update()
  {
    if (!this.Stop)
    {
      this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
      this.UpdateRoutine();
      this.UpdateDetectionMarker();
      if (this.Dying)
      {
        this.UpdateDying();
        if (this.Burning)
          this.UpdateBurning();
      }
      else
      {
        if ((double) this.DistanceToPlayer <= 2.0)
          this.UpdateTalkInput();
        this.UpdateVision();
        if (this.Pushed)
          this.UpdatePushed();
        else if (this.Drowned)
          this.UpdateDrowned();
        else if (this.WitnessedMurder)
          this.UpdateWitnessedMurder();
        else if (this.Alarmed)
          this.UpdateAlarmed();
        else if (this.TurnOffRadio)
          this.UpdateTurningOffRadio();
        else if (this.Confessing)
          this.UpdateConfessing();
        else if (this.Vomiting)
          this.UpdateVomiting();
        else if (this.Splashed)
          this.UpdateSplashed();
      }
      this.UpdateMisc();
    }
    else
      this.UpdateStop();
  }

  private void UpdateStop()
  {
    if (this.StudentManager.Pose)
    {
      this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
        this.Pose();
    }
    else if (!this.ClubActivity)
    {
      if (!this.Yandere.Talking)
      {
        if (this.Yandere.Sprayed)
          this.CharacterAnimation.CrossFade(this.ScaredAnim);
        if (this.Yandere.Noticed || this.StudentManager.YandereDying)
        {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 1.0)
          {
            int num = (int) this.MyController.Move(this.transform.forward * (Time.deltaTime * -1f));
          }
        }
      }
    }
    else if ((double) this.Police.Darkness.color.a < 1.0)
    {
      if (this.Club == ClubType.Cooking)
      {
        this.CharacterAnimation[this.SocialSitAnim].layer = 99;
        this.CharacterAnimation.Play(this.SocialSitAnim);
        this.CharacterAnimation[this.SocialSitAnim].weight = 1f;
        this.SmartPhone.SetActive(false);
        this.SpeechLines.Play();
        this.CharacterAnimation.CrossFade(this.RandomAnim);
        if ((double) this.CharacterAnimation[this.RandomAnim].time >= (double) this.CharacterAnimation[this.RandomAnim].length)
          this.PickRandomAnim();
      }
      else if (this.Club == ClubType.MartialArts)
      {
        this.CharacterAnimation.Play(this.ActivityAnim);
        AudioSource component = this.GetComponent<AudioSource>();
        if (!this.Male)
        {
          if ((double) this.CharacterAnimation["f02_kick_23"].time > 1.0)
          {
            if (!this.PlayingAudio)
            {
              component.clip = this.FemaleAttacks[UnityEngine.Random.Range(0, this.FemaleAttacks.Length)];
              component.Play();
              this.PlayingAudio = true;
            }
            if ((double) this.CharacterAnimation["f02_kick_23"].time >= (double) this.CharacterAnimation["f02_kick_23"].length)
            {
              this.CharacterAnimation["f02_kick_23"].time = 0.0f;
              this.PlayingAudio = false;
            }
          }
        }
        else if ((double) this.CharacterAnimation["kick_24"].time > 1.0)
        {
          if (!this.PlayingAudio)
          {
            component.clip = this.MaleAttacks[UnityEngine.Random.Range(0, this.MaleAttacks.Length)];
            component.Play();
            this.PlayingAudio = true;
          }
          if ((double) this.CharacterAnimation["kick_24"].time >= (double) this.CharacterAnimation["kick_24"].length)
          {
            this.CharacterAnimation["kick_24"].time = 0.0f;
            this.PlayingAudio = false;
          }
        }
      }
      else if (this.Club == ClubType.Drama)
        this.Stop = false;
      else if (this.Club == ClubType.Photography)
      {
        this.CharacterAnimation.CrossFade(this.RandomSleuthAnim);
        if ((double) this.CharacterAnimation[this.RandomSleuthAnim].time >= (double) this.CharacterAnimation[this.RandomSleuthAnim].length)
          this.PickRandomSleuthAnim();
      }
      else if (this.Club == ClubType.Art)
      {
        this.CharacterAnimation.Play(this.ActivityAnim);
        this.Paintbrush.SetActive(true);
        this.Palette.SetActive(true);
      }
      else if (this.Club == ClubType.Science)
      {
        this.CharacterAnimation.Play(this.ClubAnim);
        if (!this.StudentManager.Eighties)
        {
          if (this.StudentID == 62)
            this.ScienceProps[0].SetActive(true);
          else if (this.StudentID == 63)
          {
            this.ScienceProps[1].SetActive(true);
            this.ScienceProps[2].SetActive(true);
          }
          else if (this.StudentID == 64)
            this.ScienceProps[0].SetActive(true);
        }
        else
        {
          if (!this.Male && !this.ScienceProps[1].activeInHierarchy)
          {
            Debug.Log((object) "Supposedly straightening skirt.");
            this.CharacterAnimation.Play("f02_straightenSkirt_00");
          }
          this.ScienceProps[1].SetActive(true);
          this.ScienceProps[2].SetActive(true);
        }
      }
      else if (this.Club == ClubType.Sports)
        this.Stop = false;
      else if (this.Club == ClubType.Gardening)
      {
        this.CharacterAnimation.Play(this.ClubAnim);
        this.Stop = false;
      }
      else if (this.Club == ClubType.Gaming)
        this.CharacterAnimation.CrossFade(this.ClubAnim);
    }
    this.Alarm = Mathf.MoveTowards(this.Alarm, 0.0f, Time.deltaTime);
    this.UpdateDetectionMarker();
  }

  private void UpdateRoutine()
  {
    if (this.Routine)
    {
      this.IgnoreFoodTimer -= Time.deltaTime;
      if ((UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) null)
        this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
      if (this.StalkerFleeing)
      {
        if (this.Actions[this.Phase] == StudentActionType.Stalk && (double) this.DistanceToPlayer > 10.0)
        {
          this.Pathfinding.target = this.Yandere.transform;
          this.CurrentDestination = this.Yandere.transform;
          this.StalkerFleeing = false;
          this.Pathfinding.speed = this.WalkSpeed;
        }
      }
      else if (this.Actions[this.Phase] == StudentActionType.Stalk)
      {
        this.TargetDistance = 10f;
        if ((double) this.DistanceToPlayer > 20.0)
          this.Pathfinding.speed = 4f;
        else if ((double) this.DistanceToPlayer < 10.0)
          this.Pathfinding.speed = this.WalkSpeed;
      }
      if (!this.Indoors)
      {
        if (this.Hurry && !this.Tripped && this.StudentID == 7 && (double) this.transform.position.z > -50.5 && (double) this.transform.position.x < 6.0)
        {
          this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.CharacterAnimation.CrossFade("trip_00");
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.Tripping = true;
          this.Routine = false;
          if (this.Clock.Day == 2 && !this.BountyCollider.activeInHierarchy)
          {
            this.BountyCollider.transform.localPosition = new Vector3(0.0f, 0.0f, 0.25f);
            this.BountyCollider.GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.12f, 0.0f);
            this.BountyCollider.GetComponent<BoxCollider>().size = new Vector3(0.78f, 0.24f, 1.9f);
            this.BountyCollider.SetActive(true);
          }
        }
        if (this.Paired)
        {
          if ((double) this.transform.position.z < -50.0)
          {
            if (this.transform.localEulerAngles != Vector3.zero)
              this.transform.localEulerAngles = Vector3.zero;
            int num = (int) this.MyController.Move(this.transform.forward * Time.deltaTime);
            if (this.StudentID == 81 && !this.StudentManager.Eighties)
            {
              this.MusumeTimer += Time.deltaTime;
              if ((double) this.MusumeTimer > 5.0)
              {
                this.MusumeTimer = 0.0f;
                this.MusumeRight = !this.MusumeRight;
                this.WalkAnim = this.MusumeRight ? "f02_walkTalk_00" : "f02_walkTalk_01";
              }
            }
          }
          else
          {
            if (this.Persona == PersonaType.PhoneAddict)
            {
              this.SpeechLines.Stop();
              this.SmartPhone.SetActive(true);
            }
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.StopPairing();
          }
        }
        if (this.Phase == 0)
        {
          if ((double) this.DistanceToDestination < 1.0)
          {
            this.CurrentDestination = this.MyLocker;
            this.Pathfinding.target = this.MyLocker;
            ++this.Phase;
          }
        }
        else if ((double) this.DistanceToDestination < 0.5 && !this.ShoeRemoval.enabled)
        {
          if (this.Shy)
            this.CharacterAnimation[this.ShyAnim].weight = 0.5f;
          this.SmartPhone.SetActive(false);
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.ShoeRemoval.StartChangingShoes();
          this.ShoeRemoval.enabled = true;
          this.ChangingShoes = true;
          this.CanTalk = false;
          this.Routine = false;
        }
      }
      else if (this.Phase < this.ScheduleBlocks.Length - 1 && (double) this.Clock.HourTime >= (double) this.ScheduleBlocks[this.Phase].time && !this.InEvent && !this.Meeting && this.ClubActivityPhase < 16 && !this.Ragdoll.Zs.activeInHierarchy)
      {
        if (this.Actions[this.Phase] == StudentActionType.Clean && this.Pushable && !this.Meeting)
        {
          this.Pushable = false;
          this.StudentManager.UpdateMe(this.StudentID);
          this.ChalkDust.Stop();
        }
        this.SimpleForgetAboutBloodPool();
        this.MyRenderer.updateWhenOffscreen = false;
        this.SprintAnim = this.OriginalSprintAnim;
        if (this.Headache)
        {
          this.SprintAnim = this.OriginalSprintAnim;
          this.WalkAnim = this.OriginalWalkAnim;
        }
        if (this.Vomiting)
          this.StopVomitting();
        this.Pushable = false;
        this.Headache = false;
        this.Sedated = false;
        this.Hurry = false;
        if (this.Schoolwear == 1)
          this.SunbathePhase = 0;
        ++this.Phase;
        this.BountyCollider.SetActive(false);
        if (this.Drownable)
        {
          this.Drownable = false;
          this.StudentManager.UpdateMe(this.StudentID);
        }
        if (this.Schoolwear > 1 && (UnityEngine.Object) this.Destinations[this.Phase] == (UnityEngine.Object) this.MyLocker)
        {
          ++this.Phase;
          if (this.Rival && DateGlobals.Weekday == DayOfWeek.Friday)
            --this.Phase;
        }
        if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes && this.Schoolwear == 2 || this.Actions[this.Phase] == StudentActionType.ChangeShoes && this.Schoolwear == 2 || this.Actions[this.Phase] == StudentActionType.AtLocker && this.Schoolwear == 2 || this.Actions[this.Phase] == StudentActionType.AtLocker && (UnityEngine.Object) this.BikiniAttacher != (UnityEngine.Object) null && (UnityEngine.Object) this.BikiniAttacher.newRenderer != (UnityEngine.Object) null)
        {
          Debug.Log((object) (this.Name + " needs to change clothing before doing whatever they're supposed to do next."));
          this.MustChangeClothing = true;
          this.ChangeClothingPhase = 0;
        }
        if (this.Actions[this.Phase] == StudentActionType.Graffiti && !this.StudentManager.Bully)
        {
          ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
          scheduleBlock.destination = "Patrol";
          scheduleBlock.action = "Patrol";
          this.GetDestinations();
        }
        if (!this.StudentManager.ReactedToGameLeader && this.Actions[this.Phase] == StudentActionType.Bully && !this.StudentManager.Bully)
        {
          ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
          scheduleBlock.destination = "Sunbathe";
          scheduleBlock.action = "Sunbathe";
          this.GetDestinations();
        }
        if (this.Sedated)
        {
          this.SprintAnim = this.OriginalSprintAnim;
          this.Sedated = false;
        }
        this.CurrentAction = this.Actions[this.Phase];
        this.CurrentDestination = this.Destinations[this.Phase];
        this.Pathfinding.target = this.Destinations[this.Phase];
        if (this.Rival && DateGlobals.Weekday == DayOfWeek.Friday && !this.InCouple)
        {
          if (this.Rival && DateGlobals.Weekday == DayOfWeek.Friday)
            this.CharacterAnimation.CrossFade(this.WalkAnim);
          if ((this.StudentManager.LoveManager.ConfessToSuitor || GameGlobals.RivalEliminationID != 4) && this.Actions[this.Phase] == StudentActionType.ChangeShoes)
          {
            Debug.Log((object) "The rival's current action is ''ChangingShoes''.");
            if (this.StudentManager.LoveManager.ConfessToSuitor)
            {
              this.CurrentDestination = this.StudentManager.SuitorLocker;
              this.Pathfinding.target = this.StudentManager.SuitorLocker;
            }
            else
            {
              this.CurrentDestination = this.StudentManager.SenpaiLocker;
              this.Pathfinding.target = this.StudentManager.SenpaiLocker;
            }
            this.Yandere.PauseScreen.Hint.Show = true;
            this.Yandere.PauseScreen.Hint.QuickID = 10;
            this.Confessing = true;
            this.Distracted = true;
            this.Routine = false;
            this.CanTalk = false;
          }
        }
        if ((UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) null)
          this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
        if ((UnityEngine.Object) this.Bento != (UnityEngine.Object) null && this.Bento.activeInHierarchy)
        {
          this.Bento.SetActive(false);
          this.Chopsticks[0].SetActive(false);
          this.Chopsticks[1].SetActive(false);
        }
        if (this.Male)
        {
          this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 0.0f);
          this.PinkSeifuku.SetActive(false);
        }
        else
          this.HorudaCollider.gameObject.SetActive(false);
        this.BountyCollider.SetActive(false);
        if (this.StudentID == 81)
        {
          this.Cigarette.SetActive(false);
          this.Lighter.SetActive(false);
        }
        if (!this.Paired)
        {
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
        }
        if (this.Persona != PersonaType.PhoneAddict && !this.Sleuthing)
          this.SmartPhone.SetActive(false);
        else if (!this.Slave && !this.Phoneless)
        {
          this.IdleAnim = this.PhoneAnims[0];
          this.SmartPhone.SetActive(true);
        }
        this.Paintbrush.SetActive(false);
        this.Sketchbook.SetActive(false);
        this.Palette.SetActive(false);
        this.Pencil.SetActive(false);
        this.OccultBook.SetActive(false);
        this.Scrubber.SetActive(false);
        this.Eraser.SetActive(false);
        this.Pen.SetActive(false);
        foreach (GameObject scienceProp in this.ScienceProps)
        {
          if ((UnityEngine.Object) scienceProp != (UnityEngine.Object) null)
            scienceProp.SetActive(false);
        }
        foreach (GameObject gameObject in this.Fingerfood)
        {
          if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
            gameObject.SetActive(false);
        }
        this.SpeechLines.Stop();
        this.GoAway = false;
        this.ReadPhase = 0;
        if (!this.ReturningFromSave)
          this.PatrolID = 0;
        if (this.Phase == this.PhaseFromSave)
        {
          if ((UnityEngine.Object) this.StudentManager.Patrols.List[this.StudentID] != (UnityEngine.Object) null && (UnityEngine.Object) this.Destinations[this.Phase] == (UnityEngine.Object) this.StudentManager.Patrols.List[this.StudentID].GetChild(0))
          {
            this.Destinations[this.Phase] = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
            this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
            this.Pathfinding.target = this.CurrentDestination;
          }
          this.ReturningFromSave = false;
        }
        if (this.Actions[this.Phase] == StudentActionType.Clean)
        {
          if (this.StudentID == 11)
            this.FollowTargetDestination.localPosition = new Vector3(0.0f, 0.0f, -1f);
          this.EquipCleaningItems();
        }
        else
        {
          if (this.StudentID == 11)
            this.FollowTargetDestination.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
          if (!this.Slave && !this.Phoneless)
          {
            if (this.Persona == PersonaType.PhoneAddict)
            {
              this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
              this.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -160f, 165f);
              this.WalkAnim = this.PhoneAnims[1];
            }
            else if (this.Sleuthing)
              this.WalkAnim = this.SleuthWalkAnim;
          }
        }
        if (this.Actions[this.Phase] == StudentActionType.Sleuth && this.StudentManager.SleuthPhase == 3)
          this.GetSleuthTarget();
        if (this.Actions[this.Phase] == StudentActionType.Stalk)
          this.TargetDistance = 10f;
        else if (this.Actions[this.Phase] == StudentActionType.Follow)
        {
          this.TargetDistance = 0.5f;
          if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null && !this.FollowTarget.Alive && !this.WitnessedCorpse)
          {
            this.FollowTarget.FollowTargetDestination.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            this.TargetDistance = 1f;
          }
        }
        else if (this.Actions[this.Phase] != StudentActionType.SitAndEatBento)
          this.TargetDistance = 0.5f;
        if (this.Club == ClubType.Gardening && this.StudentID != 71 && this.Actions[this.Phase] == StudentActionType.ClubAction)
        {
          if (!this.StudentManager.Eighties)
          {
            if ((UnityEngine.Object) this.WateringCan != (UnityEngine.Object) null && (UnityEngine.Object) this.WateringCan.transform.parent != (UnityEngine.Object) this.Hips)
            {
              this.WateringCan.transform.parent = this.Hips;
              this.WateringCan.transform.localPosition = new Vector3(0.0f, 0.0135f, -0.184f);
              this.WateringCan.transform.localEulerAngles = new Vector3(0.0f, 90f, 30f);
            }
            if (this.Clock.Period == 6 && (UnityEngine.Object) this.StudentManager.Patrols.List[this.StudentID] != (UnityEngine.Object) this.StudentManager.GardeningPatrols[this.StudentID - 71])
            {
              this.StudentManager.Patrols.List[this.StudentID] = this.StudentManager.GardeningPatrols[this.StudentID - 71];
              this.ClubAnim = "f02_waterPlantLow_00";
              this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
              this.Pathfinding.target = this.CurrentDestination;
            }
          }
          else if (this.Clock.Period == 6 && (UnityEngine.Object) this.StudentManager.Patrols.List[this.StudentID] != (UnityEngine.Object) this.StudentManager.GardeningPatrols[this.StudentID - 71])
          {
            this.StudentManager.Patrols.List[this.StudentID] = this.StudentManager.GardeningPatrols[this.StudentID - 71];
            this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
            this.Pathfinding.target = this.CurrentDestination;
          }
        }
        if (this.Club == ClubType.LightMusic)
        {
          if (this.StudentID == 51)
          {
            if ((UnityEngine.Object) this.InstrumentBag[this.ClubMemberID].transform.parent == (UnityEngine.Object) null)
            {
              this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
              this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
              this.Instruments[this.ClubMemberID].transform.parent = (Transform) null;
              if (!this.StudentManager.Eighties)
              {
                this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
                this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0.0f, 0.0f);
              }
              else
              {
                this.Instruments[this.ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
                this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
              }
            }
            else
              this.Instruments[this.ClubMemberID].SetActive(false);
          }
          else
            this.Instruments[this.ClubMemberID].SetActive(false);
          this.Drumsticks[0].SetActive(false);
          this.Drumsticks[1].SetActive(false);
          this.AirGuitar.Stop();
        }
        if (!this.StudentManager.Eighties && this.Phase == 8 && this.StudentID == 36)
        {
          this.StudentManager.Clubs.List[this.StudentID].position = this.StudentManager.Clubs.List[71].position;
          this.StudentManager.Clubs.List[this.StudentID].rotation = this.StudentManager.Clubs.List[71].rotation;
          this.ClubAnim = this.GameAnim;
        }
        if ((UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand)
        {
          this.CurrentDestination = this.StudentManager.Clubs.List[this.StudentID];
          this.Pathfinding.target = this.StudentManager.Clubs.List[this.StudentID];
        }
        if (this.Persona == PersonaType.Sleuth)
        {
          if (this.Male)
          {
            this.SmartPhone.transform.localPosition = new Vector3(0.06f, -0.02f, -0.02f);
            this.SmartPhone.transform.localEulerAngles = this.StudentManager.Eighties ? new Vector3(22.5f, 22.5f, 150f) : new Vector3(12.5f, 120f, 180f);
          }
          else if (!this.StudentManager.Eighties)
          {
            this.SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.015f, -0.015f);
            this.SmartPhone.transform.localEulerAngles = new Vector3(12.5f, 120f, 180f);
          }
          else
          {
            this.SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.066666f, -0.01f);
            this.SmartPhone.transform.localEulerAngles = new Vector3(15f, 15f, 105f);
          }
        }
        if ((double) this.Character.transform.localPosition.y == -0.25)
        {
          Debug.Log((object) "Swimming club special case was reached.");
          this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.ID].GetChild(this.ClubActivityPhase - 2);
          this.CurrentDestination = this.StudentManager.Clubs.List[this.ID].GetChild(this.ClubActivityPhase - 2);
          this.Pathfinding.target = this.StudentManager.Clubs.List[this.ID].GetChild(this.ClubActivityPhase - 2);
        }
        if (this.Actions[this.Phase] == StudentActionType.Sunbathe && this.SunbathePhase > 1)
        {
          this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
          this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
        }
        if (this.StudentID == 10 && (UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null && !this.FollowTarget.Alive && this.StudentManager.LastKnownOsana.position != Vector3.zero)
        {
          this.Pathfinding.target = this.StudentManager.LastKnownOsana;
          this.CurrentDestination = this.StudentManager.LastKnownOsana;
        }
        if (this.Phoneless)
          this.SmartPhone.SetActive(false);
        if (this.Rival)
        {
          if (this.CurrentAction == StudentActionType.Clean)
          {
            this.StudentManager.RivalBookBag.gameObject.SetActive(false);
            this.StudentManager.RivalBookBag.Prompt.Hide();
            this.StudentManager.RivalBookBag.Prompt.enabled = false;
            if (this.StudentManager.Eighties)
              this.BookBag.SetActive(true);
          }
          else if (this.Clock.Period == 4 && this.CurrentAction == StudentActionType.Read && !this.StudentManager.RivalBookBag.BorrowedBook)
          {
            ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
            scheduleBlock.destination = "Search Patrol";
            scheduleBlock.action = "Search Patrol";
            this.GetDestinations();
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
          }
        }
        if (!this.Teacher && this.Club != ClubType.Delinquent && this.Club != ClubType.Sports)
        {
          if (this.Clock.Period == 2 || this.Clock.Period == 4)
          {
            if (this.ClubActivityPhase < 16)
              this.Pathfinding.speed = 4f;
          }
          else
            this.Pathfinding.speed = this.WalkSpeed;
          if (!this.StudentManager.Eighties)
          {
            if (this.StudentManager.ConvoManager.Week != 0 && (this.StudentID == 25 || this.StudentID == 30 || this.StudentID == 24 || this.StudentID == 27))
            {
              this.Hurry = true;
              this.Pathfinding.speed = 4f;
            }
          }
          else if (this.StudentID > 10 && this.StudentID < 21 && (this.Schoolwear != 1 || (UnityEngine.Object) this.BikiniAttacher != (UnityEngine.Object) null && (UnityEngine.Object) this.BikiniAttacher.newRenderer != (UnityEngine.Object) null))
          {
            Debug.Log((object) (this.Name + " wasn't dressed normally when she reached this part of the code."));
            if (this.Schoolwear == 3)
            {
              Debug.Log((object) (this.Name + " was in gym clothing. Should be running."));
              this.Hurry = true;
              this.Pathfinding.speed = 4f;
            }
            if (this.CurrentAction == StudentActionType.AtLocker || this.CurrentAction == StudentActionType.ChangeShoes || this.CurrentAction == StudentActionType.SitAndTakeNotes)
            {
              Debug.Log((object) (this.Name + " is firing the GoChange() function."));
              this.ChangeClothingPhase = 0;
              this.GoChange();
            }
          }
        }
        if (this.Infatuated && this.Actions[this.Phase] == StudentActionType.Admire)
        {
          if ((double) this.transform.position.y > (double) this.CurrentDestination.position.y + 1.0 || (double) this.transform.position.y < (double) this.CurrentDestination.position.y - 1.0)
          {
            this.TargetDistance = 2f;
          }
          else
          {
            Debug.Log((object) "This is the exact moment an infatuated character is deciding their TargetDistance.");
            if ((UnityEngine.Object) this.StudentManager.Students[this.StudentManager.RivalID] != (UnityEngine.Object) null && this.StudentManager.Students[this.StudentManager.RivalID].Meeting)
            {
              Debug.Log((object) "Rival is meeting someone, so TargetDistance is far away.");
              this.TargetDistance = 10f;
            }
            else
            {
              Debug.Log((object) "Rival is NOT meeting someone, so TargetDistance is nearby.");
              this.TargetDistance = 5f;
            }
          }
        }
        if (this.Club == ClubType.Sports && this.Clock.Period == 6 && !this.StudentManager.PoolClosed && this.Schoolwear == 3)
        {
          this.ClubAnim = "poolDive_00";
          this.ClubActivityPhase = 15;
          this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
        }
        this.CharacterAnimation[this.SitAnim].weight = 0.0f;
        this.CharacterAnimation[this.SocialSitAnim].weight = 0.0f;
      }
      if ((double) this.MeetTime > 0.0)
      {
        bool flag = false;
        if ((UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand)
          flag = true;
        if (!this.InEvent && (double) this.Clock.HourTime > (double) this.MeetTime && !flag && this.Schoolwear != 0 && this.Schoolwear != 2)
        {
          Debug.Log((object) (this.Name + " acknowledges that it is time to go to a MeetSpot to have a Meeting."));
          if ((UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand && (UnityEngine.Object) this.Follower != (UnityEngine.Object) null)
          {
            ScheduleBlock scheduleBlock = this.Follower.ScheduleBlocks[this.Follower.Phase];
            scheduleBlock.destination = "Follow";
            scheduleBlock.action = "Follow";
            this.Follower.Actions[this.Follower.Phase] = StudentActionType.Follow;
            this.CurrentAction = StudentActionType.Follow;
            this.Follower.GetDestinations();
            this.Follower.CurrentDestination = this.Follower.Destinations[this.Follower.Phase];
            this.Follower.Pathfinding.target = this.Follower.Destinations[this.Follower.Phase];
          }
          this.CurrentDestination = this.MeetSpot;
          this.Pathfinding.target = this.MeetSpot;
          this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Pathfinding.speed = 4f;
          this.TargetDistance = 1f;
          this.SpeechLines.Stop();
          this.EmptyHands();
          this.Meeting = true;
          this.MeetTime = 0.0f;
          if (this.Rival)
            this.StudentManager.UpdateInfatuatedTargetDistances();
        }
      }
      if ((double) this.DistanceToDestination > (double) this.TargetDistance)
      {
        Bounds bounds;
        if (this.Actions[this.Phase] == StudentActionType.Sleuth)
        {
          if (!this.SmartPhone.activeInHierarchy)
          {
            this.SmartPhone.SetActive(true);
            this.SpeechLines.Stop();
          }
          if ((UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) null)
          {
            this.GetSleuthTarget();
          }
          else
          {
            this.LockerRoomCheckTimer += Time.deltaTime;
            if ((double) this.LockerRoomCheckTimer > 5.0)
            {
              this.LockerRoomCheckTimer = 0.0f;
              bounds = this.StudentManager.LockerRoomArea.bounds;
              if (!bounds.Contains(this.CurrentDestination.position))
              {
                bounds = this.StudentManager.MaleLockerRoomArea.bounds;
                if (!bounds.Contains(this.CurrentDestination.position))
                {
                  bounds = this.StudentManager.EastBathroomArea.bounds;
                  if (!bounds.Contains(this.CurrentDestination.position))
                  {
                    bounds = this.StudentManager.WestBathroomArea.bounds;
                    if (!bounds.Contains(this.CurrentDestination.position))
                      goto label_201;
                  }
                }
              }
              this.GetSleuthTarget();
            }
          }
        }
        else if (this.Actions[this.Phase] == StudentActionType.Stalk && this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position))
        {
          if ((double) Vector3.Distance(this.transform.position, this.StudentManager.FleeSpots[0].position) > 10.0)
          {
            this.Pathfinding.target = this.StudentManager.FleeSpots[0];
            this.CurrentDestination = this.StudentManager.FleeSpots[0];
          }
          else
          {
            this.Pathfinding.target = this.StudentManager.FleeSpots[1];
            this.CurrentDestination = this.StudentManager.FleeSpots[1];
          }
          this.Pathfinding.speed = 4f;
          this.StalkerFleeing = true;
        }
label_201:
        if (this.StudentID == 10)
        {
          if (this.Actions[this.Phase] == StudentActionType.Follow && !this.Alarmed)
          {
            this.Obstacle.enabled = false;
            if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null)
            {
              if (this.FollowTarget.Wet && (double) this.FollowTarget.DistanceToDestination < 5.0)
                this.TargetDistance = 4f;
              else if (this.FollowTarget.CurrentAction == StudentActionType.SearchPatrol)
              {
                this.TargetDistance = 1f;
              }
              else
              {
                this.TargetDistance = 0.5f;
                if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null && !this.FollowTarget.Alive && !this.WitnessedCorpse)
                  this.TargetDistance = 1f;
              }
            }
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            if ((double) this.DistanceToDestination > 2.0)
            {
              this.Pathfinding.speed = 5f;
              this.SpeechLines.Stop();
            }
            else
            {
              this.Pathfinding.speed = this.WalkSpeed;
              this.SpeechLines.Stop();
            }
          }
          else if ((double) this.transform.position.z > 121.0 && this.Actions[this.Phase] == StudentActionType.Sketch && this.Yandere.Attacking && (UnityEngine.Object) this.Yandere.TargetStudent == (UnityEngine.Object) this.FollowTarget)
          {
            this.AwareOfMurder = true;
            this.Alarm = 200f;
          }
        }
        if (this.StudentID == 12 && this.Actions[this.Phase] == StudentActionType.LightFire && (double) Vector3.Distance(this.Yandere.transform.position, this.CurrentDestination.position) < 5.0 && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
        {
          this.Subtitle.CustomText = "...oh...I didn't realize someone was here...I'll just...be going, now...";
          this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
          this.FinishPyro();
        }
        if (this.CuriosityPhase == 1 && this.Actions[this.Phase] == StudentActionType.Relax && this.StudentManager.Students[this.Crush].Private)
        {
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.CurrentDestination = this.Destinations[this.Phase];
          this.TargetDistance = 0.5f;
          this.CuriosityTimer = 0.0f;
          --this.CuriosityPhase;
        }
        if (this.Actions[this.Phase] != StudentActionType.Follow || this.Actions[this.Phase] == StudentActionType.Follow && (double) this.DistanceToDestination > (double) this.TargetDistance + 0.10000000149011612)
        {
          if (this.Actions[this.Phase] == StudentActionType.Follow && (this.Clock.Period == 1 && (double) this.Clock.HourTime > 8.4833335876464844 || this.Clock.Period == 3 && (double) this.Clock.HourTime > 13.483333587646484))
            this.Pathfinding.speed = 4f;
          if (!this.InEvent && !this.Meeting && !this.GoAway)
          {
            if (this.DressCode)
            {
              if (this.Actions[this.Phase] == StudentActionType.ClubAction)
              {
                if (!this.ClubAttire)
                {
                  if (!this.ChangingBooth.Occupied)
                  {
                    this.CurrentDestination = this.ChangingBooth.transform;
                    this.Pathfinding.target = this.ChangingBooth.transform;
                  }
                  else
                  {
                    this.CurrentDestination = this.ChangingBooth.WaitSpots[this.ClubMemberID];
                    this.Pathfinding.target = this.ChangingBooth.WaitSpots[this.ClubMemberID];
                  }
                }
                else if (this.Indoors && !this.GoAway)
                {
                  this.CurrentDestination = this.Destinations[this.Phase];
                  this.Pathfinding.target = this.Destinations[this.Phase];
                  this.DistanceToDestination = 100f;
                }
              }
              else if (this.ClubAttire)
              {
                this.TargetDistance = 1f;
                if (!this.ChangingBooth.Occupied)
                {
                  this.CurrentDestination = this.ChangingBooth.transform;
                  this.Pathfinding.target = this.ChangingBooth.transform;
                }
                else
                {
                  this.CurrentDestination = this.ChangingBooth.WaitSpots[this.ClubMemberID];
                  this.Pathfinding.target = this.ChangingBooth.WaitSpots[this.ClubMemberID];
                }
              }
              else if (this.Indoors && this.Actions[this.Phase] != StudentActionType.Clean && this.Actions[this.Phase] != StudentActionType.Sketch && this.Actions[this.Phase] != StudentActionType.Relax)
              {
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes && this.Schoolwear > 1 && !this.SchoolwearUnavailable)
            {
              this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
              this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
            }
          }
          if (!this.Pathfinding.canMove)
          {
            if (!this.Spawned)
            {
              this.transform.position = this.StudentManager.SpawnPositions[this.StudentID].position;
              this.Spawned = true;
              if (!this.StudentManager.Eighties && this.StudentID == 10 && (UnityEngine.Object) this.StudentManager.Students[11] == (UnityEngine.Object) null)
              {
                this.transform.position = new Vector3(-4f, 0.0f, -96f);
                Physics.SyncTransforms();
              }
            }
            if (!this.Paired && !this.Alarmed)
            {
              this.Pathfinding.canSearch = true;
              this.Pathfinding.canMove = true;
              this.Obstacle.enabled = false;
            }
          }
          if (!this.InEvent)
          {
            if ((double) this.Pathfinding.speed > 0.0)
            {
              if (!this.Hurry && (double) this.Pathfinding.speed == (double) this.WalkSpeed)
              {
                if (!this.CharacterAnimation.IsPlaying(this.WalkAnim))
                {
                  if (this.Persona == PersonaType.PhoneAddict && this.Actions[this.Phase] == StudentActionType.Clean)
                  {
                    this.CharacterAnimation.CrossFade(this.OriginalWalkAnim);
                  }
                  else
                  {
                    if (this.WalkAnim == "")
                      this.WalkAnim = this.OriginalWalkAnim;
                    this.CharacterAnimation.CrossFade(this.WalkAnim);
                  }
                }
              }
              else if (!this.Dying)
              {
                this.CharacterAnimation.CrossFade(this.SprintAnim);
                this.Pathfinding.speed = 4f;
              }
            }
          }
          else if (this.Mentoring && this.StudentID == 10 && this.InEvent && this.CurrentAction == StudentActionType.Socializing)
          {
            this.Pathfinding.speed = this.Hurry ? 4f : this.WalkSpeed;
            if ((double) this.Pathfinding.speed == (double) this.WalkSpeed)
              this.CharacterAnimation.CrossFade(this.WalkAnim);
            else
              this.CharacterAnimation.CrossFade(this.SprintAnim);
            this.CheckForEndRaibaruEvent();
          }
          if (this.Club == ClubType.Occult && this.Actions[this.Phase] != StudentActionType.ClubAction)
            this.OccultBook.SetActive(false);
          if (!this.Meeting && !this.GoAway && !this.InEvent)
          {
            if (this.Actions[this.Phase] == StudentActionType.Clean)
            {
              if (this.SmartPhone.activeInHierarchy)
                this.SmartPhone.SetActive(false);
              if ((UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) this.CleaningSpot.GetChild(this.CleanID))
              {
                this.CurrentDestination = this.CleaningSpot.GetChild(this.CleanID);
                this.Pathfinding.target = this.CurrentDestination;
              }
            }
            if ((this.Actions[this.Phase] == StudentActionType.Patrol || this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Gardening) && (UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID))
            {
              this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
              this.Pathfinding.target = this.CurrentDestination;
            }
          }
        }
        if (this.Meeting)
        {
          if (this.BakeSale)
          {
            this.CharacterAnimation.CrossFade(this.WalkAnim);
            this.Pathfinding.speed = this.WalkSpeed;
          }
          else
          {
            this.CharacterAnimation.CrossFade(this.SprintAnim);
            this.Pathfinding.speed = 4f;
          }
        }
        if (this.CuriosityPhase == 1 && this.CurrentAction == StudentActionType.Relax)
        {
          bounds = this.StudentManager.LockerRoomArea.bounds;
          if (!bounds.Contains(this.StudentManager.Students[this.Crush].transform.position))
          {
            bounds = this.StudentManager.EastBathroomArea.bounds;
            if (!bounds.Contains(this.StudentManager.Students[this.Crush].transform.position))
            {
              bounds = this.StudentManager.WestBathroomArea.bounds;
              if (!bounds.Contains(this.StudentManager.Students[this.Crush].transform.position))
                goto label_280;
            }
          }
          Debug.Log((object) "This code is called when a student is stalking their crush and their crush is in the locker room or shower room.");
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.CurrentDestination = this.Destinations[this.Phase];
          this.TargetDistance = 0.5f;
          this.CuriosityTimer = 0.0f;
          --this.CuriosityPhase;
        }
label_280:
        if (!this.Infatuated || this.Actions[this.Phase] != StudentActionType.Admire)
          return;
        this.TargetDistance = (double) this.transform.position.y > (double) this.CurrentDestination.position.y + 1.0 || (double) this.transform.position.y < (double) this.CurrentDestination.position.y - 1.0 ? 2f : (this.StudentManager.Students[this.StudentManager.RivalID].Meeting || this.StudentManager.Students[this.StudentManager.RivalID].InEvent ? 10f : 5f);
        bounds = this.StudentManager.LockerRoomArea.bounds;
        if (bounds.Contains(this.CurrentDestination.position) || this.StudentManager.Students[this.InfatuationID].Meeting)
        {
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
        }
        else
        {
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
        }
      }
      else
      {
        if (this.StudentID == 10 && this.InEvent && this.CurrentAction != StudentActionType.Follow && this.Mentoring)
        {
          this.SpeechLines.Play();
          this.CharacterAnimation.CrossFade(this.RandomAnim);
          if ((double) this.CharacterAnimation[this.RandomAnim].time >= (double) this.CharacterAnimation[this.RandomAnim].length)
            this.PickRandomAnim();
          if (this.Mentoring)
            this.CheckForEndRaibaruEvent();
        }
        if ((UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) null)
        {
          bool flag = false;
          if (this.Actions[this.Phase] == StudentActionType.Sleuth && this.StudentManager.SleuthPhase == 3 && !this.Meeting || this.Actions[this.Phase] == StudentActionType.Stalk || this.Actions[this.Phase] == StudentActionType.Relax && this.CuriosityPhase == 1 || this.Actions[this.Phase] == StudentActionType.Guard && !this.Meeting || this.CurrentAction == StudentActionType.Follow && (UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null && this.FollowTarget.CurrentAction == StudentActionType.SearchPatrol)
          {
            if (this.CurrentAction == StudentActionType.Follow && (UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null && this.FollowTarget.CurrentAction == StudentActionType.SearchPatrol)
              Debug.Log((object) "Raibaru knows that she should Stop Early...");
            this.TargetDistance = 2f;
            flag = true;
          }
          else if (this.Actions[this.Phase] == StudentActionType.Admire && this.Infatuated)
          {
            this.TargetDistance = (double) this.transform.position.y > (double) this.CurrentDestination.position.y + 1.0 || (double) this.transform.position.y < (double) this.CurrentDestination.position.y - 1.0 ? 2f : 5f;
            flag = true;
          }
          if (this.Actions[this.Phase] == StudentActionType.Follow)
          {
            if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null)
            {
              if (!this.ManualRotation)
              {
                this.targetRotation = Quaternion.LookRotation(this.FollowTarget.transform.position - this.transform.position);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
              }
              if (this.FollowTarget.Attacked && this.FollowTarget.Alive && !this.FollowTarget.Tranquil && !this.Blind)
              {
                Debug.Log((object) "Raibaru should be aware that Osana is being attacked.");
                this.AwareOfMurder = true;
                this.Alarm = 200f;
              }
            }
          }
          else if (!flag)
          {
            this.MoveTowardsTarget(this.CurrentDestination.position);
            if ((double) Quaternion.Angle(this.transform.rotation, this.CurrentDestination.rotation) > 1.0 && !this.StopRotating)
              this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, 10f * Time.deltaTime);
          }
          else
          {
            if (this.Infatuated)
            {
              this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Students[this.InfatuationID].transform.position.x, this.transform.position.y, this.StudentManager.Students[this.InfatuationID].transform.position.z) - this.transform.position);
              StudentScript student = this.StudentManager.Students[this.InfatuationID];
              if ((UnityEngine.Object) student != (UnityEngine.Object) null && (!student.gameObject.activeInHierarchy || !student.enabled))
                this.CannotFindInfatuationTarget();
            }
            else if (this.Actions[this.Phase] == StudentActionType.Sleuth || this.Actions[this.Phase] == StudentActionType.Stalk)
              this.targetRotation = Quaternion.LookRotation(this.SleuthTarget.position - this.transform.position);
            else if (this.Actions[this.Phase] == StudentActionType.Guard)
              this.targetRotation = Quaternion.LookRotation(this.transform.position - new Vector3(this.CurrentDestination.position.x, this.transform.position.y, this.CurrentDestination.position.z));
            else if (this.Crush > 0)
              this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Students[this.Crush].transform.position.x, this.transform.position.y, this.StudentManager.Students[this.Crush].transform.position.z) - this.transform.position);
            double num = (double) Quaternion.Angle(this.transform.rotation, this.targetRotation);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
            if (num > 1.0)
              this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          }
          this.Pathfinding.speed = this.Hurry ? 4f : this.WalkSpeed;
        }
        if (this.Pathfinding.canMove)
        {
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          if (this.Actions[this.Phase] != StudentActionType.Clean)
            this.Obstacle.enabled = true;
        }
        if (!this.InEvent && !this.Meeting && this.DressCode)
        {
          if (this.Actions[this.Phase] == StudentActionType.ClubAction)
          {
            if (!this.ClubAttire)
            {
              if (!this.ChangingBooth.Occupied)
              {
                if ((UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) this.ChangingBooth.transform)
                {
                  this.ChangingBooth.Occupied = true;
                  this.ChangingBooth.Student = this;
                  this.ChangingBooth.CheckYandereClub();
                  this.Obstacle.enabled = false;
                }
                this.CurrentDestination = this.ChangingBooth.transform;
                this.Pathfinding.target = this.ChangingBooth.transform;
              }
              else
                this.CharacterAnimation.CrossFade(this.IdleAnim);
            }
            else if (!this.GoAway)
            {
              this.CurrentDestination = this.Destinations[this.Phase];
              this.Pathfinding.target = this.Destinations[this.Phase];
            }
          }
          else if (this.ClubAttire)
          {
            if (!this.ChangingBooth.Occupied)
            {
              if ((UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) this.ChangingBooth.transform)
              {
                this.ChangingBooth.Occupied = true;
                this.ChangingBooth.Student = this;
                this.ChangingBooth.CheckYandereClub();
              }
              this.CurrentDestination = this.ChangingBooth.transform;
              this.Pathfinding.target = this.ChangingBooth.transform;
            }
            else
              this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          else if (this.Actions[this.Phase] != StudentActionType.Clean)
          {
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
          }
        }
        if (this.InEvent)
          return;
        if (!this.Meeting)
        {
          if (!this.GoAway)
          {
            if (this.Actions[this.Phase] == StudentActionType.AtLocker)
            {
              if (this.MustChangeClothing)
              {
                this.ChangeClothing();
              }
              else
              {
                this.CharacterAnimation.CrossFade(this.IdleAnim);
                this.Pathfinding.canSearch = false;
                this.Pathfinding.canMove = false;
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Socializing || this.Actions[this.Phase] == StudentActionType.Follow && (UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null && this.FollowTarget.Actions[this.Phase] != StudentActionType.Clean && (double) this.FollowTargetDistance < 1.0 && !this.FollowTarget.Alone && !this.FollowTarget.InEvent && !this.FollowTarget.Talking && !this.FollowTarget.Meeting && !this.FollowTarget.Confessing && (double) this.FollowTarget.DistanceToDestination < 1.0)
            {
              if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null)
              {
                if (this.FollowTarget.Indoors && this.FollowTarget.CurrentAction != StudentActionType.SearchPatrol)
                {
                  this.FollowTarget.FollowTargetDestination.localPosition = new Vector3(0.0f, 0.0f, 1f);
                  this.MoveTowardsTarget(this.CurrentDestination.position);
                }
                else
                  this.FollowTarget.FollowTargetDestination.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
              }
              if ((UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand)
              {
                this.MyPlate.parent = (Transform) null;
                this.MyPlate.position = this.OriginalPlatePosition;
                this.MyPlate.rotation = this.OriginalPlateRotation;
                this.IdleAnim = this.OriginalIdleAnim;
                this.WalkAnim = this.OriginalWalkAnim;
                this.LeanAnim = this.OriginalLeanAnim;
                this.ResumeDistracting = false;
                this.Distracting = false;
                this.Distracted = false;
                this.CanTalk = true;
              }
              if ((double) this.Paranoia > 1.666659951210022 && !this.StudentManager.LoveSick && this.Club != ClubType.Delinquent)
              {
                this.CharacterAnimation.CrossFade(this.IdleAnim);
              }
              else
              {
                this.StudentManager.ConvoManager.CheckMe(this.StudentID);
                if (this.Club == ClubType.Delinquent)
                {
                  if (this.Alone)
                  {
                    if (!this.Phoneless && this.TrueAlone)
                    {
                      if (!this.SmartPhone.activeInHierarchy)
                      {
                        this.CharacterAnimation.CrossFade("delinquentTexting_00");
                        this.SmartPhone.SetActive(true);
                        this.SpeechLines.Stop();
                      }
                    }
                    else
                    {
                      this.CharacterAnimation.CrossFade(this.IdleAnim);
                      this.SpeechLines.Stop();
                    }
                  }
                  else
                  {
                    if (!this.InEvent)
                    {
                      if (!this.Grudge)
                      {
                        if (!this.SpeechLines.isPlaying)
                        {
                          this.SmartPhone.SetActive(false);
                          this.SpeechLines.Play();
                        }
                      }
                      else
                        this.SmartPhone.SetActive(false);
                    }
                    this.CharacterAnimation.CrossFade(this.RandomAnim);
                    if ((double) this.CharacterAnimation[this.RandomAnim].time >= (double) this.CharacterAnimation[this.RandomAnim].length)
                      this.PickRandomAnim();
                  }
                }
                else if (this.Alone)
                {
                  if (!this.Male)
                  {
                    if (!this.Phoneless)
                    {
                      this.CharacterAnimation.CrossFade("f02_standTexting_00");
                      this.SmartPhone.SetActive(true);
                      this.SpeechLines.Stop();
                    }
                    else
                    {
                      this.CharacterAnimation.CrossFade(this.PatrolAnim);
                      this.SpeechLines.Stop();
                    }
                  }
                  else if (!this.Phoneless)
                  {
                    if (this.StudentID == 36)
                      this.CharacterAnimation.CrossFade(this.ClubAnim);
                    else if (this.StudentID == 66)
                      this.CharacterAnimation.CrossFade("delinquentTexting_00");
                    else
                      this.CharacterAnimation.CrossFade("standTexting_00");
                    if (!this.SmartPhone.activeInHierarchy && !this.Shy)
                    {
                      if (this.StudentID == 36)
                      {
                        this.SmartPhone.transform.localPosition = new Vector3(0.0566666f, -0.02f, 0.0f);
                        this.SmartPhone.transform.localEulerAngles = new Vector3(10f, 115f, 180f);
                      }
                      else
                      {
                        this.SmartPhone.transform.localPosition = new Vector3(0.015f, 0.01f, 0.025f);
                        this.SmartPhone.transform.localEulerAngles = new Vector3(10f, -160f, 165f);
                      }
                      this.SmartPhone.SetActive(true);
                      this.SpeechLines.Stop();
                    }
                  }
                  else
                  {
                    this.CharacterAnimation.CrossFade(this.PatrolAnim);
                    this.SpeechLines.Stop();
                  }
                }
                else if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null && !this.FollowTarget.gameObject.activeInHierarchy || (UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null && !this.FollowTarget.enabled)
                {
                  Debug.Log((object) "Raibaru can't find Osana.");
                  this.RaibaruCannotFindOsana();
                }
                else
                {
                  if (!this.InEvent)
                  {
                    if (!this.Grudge)
                    {
                      if (!this.SpeechLines.isPlaying)
                      {
                        this.SmartPhone.SetActive(false);
                        this.SpeechLines.Play();
                      }
                    }
                    else
                      this.SmartPhone.SetActive(false);
                  }
                  if (this.Club != ClubType.Photography)
                  {
                    this.CharacterAnimation.CrossFade(this.RandomAnim);
                    if ((double) this.CharacterAnimation[this.RandomAnim].time >= (double) this.CharacterAnimation[this.RandomAnim].length)
                      this.PickRandomAnim();
                  }
                  else
                  {
                    this.CharacterAnimation.CrossFade(this.RandomSleuthAnim);
                    if ((double) this.CharacterAnimation[this.RandomSleuthAnim].time >= (double) this.CharacterAnimation[this.RandomSleuthAnim].length)
                      this.PickRandomSleuthAnim();
                  }
                }
              }
              if (!this.PyroUrge)
                return;
              this.PyroTimer += Time.deltaTime;
              if ((double) this.PyroTimer <= 60.0)
                return;
              this.SpeechLines.Stop();
              ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
              scheduleBlock.destination = "LightFire";
              scheduleBlock.action = "LightFire";
              this.GetDestinations();
              this.Pathfinding.target = this.Destinations[this.Phase];
              this.CurrentDestination = this.Destinations[this.Phase];
              this.PyroPhase = 1;
              this.PyroTimer = 0.0f;
            }
            else if (this.Actions[this.Phase] == StudentActionType.Gossip)
            {
              if (this.StudentID == 82 && this.Clock.Day == 5)
                this.BountyCollider.SetActive(true);
              if ((double) this.Paranoia > 1.666659951210022 && !this.StudentManager.LoveSick)
              {
                this.CharacterAnimation.CrossFade(this.IdleAnim);
              }
              else
              {
                this.StudentManager.ConvoManager.CheckMe(this.StudentID);
                if (this.Alone)
                {
                  if (this.Shy)
                    return;
                  this.CharacterAnimation.CrossFade("f02_standTexting_00");
                  if (this.SmartPhone.activeInHierarchy)
                    return;
                  this.SmartPhone.SetActive(true);
                  this.SpeechLines.Stop();
                }
                else
                {
                  if (!this.SpeechLines.isPlaying)
                  {
                    this.SmartPhone.SetActive(false);
                    this.SpeechLines.Play();
                  }
                  this.CharacterAnimation.CrossFade(this.RandomGossipAnim);
                  if ((double) this.CharacterAnimation[this.RandomGossipAnim].time < (double) this.CharacterAnimation[this.RandomGossipAnim].length)
                    return;
                  this.PickRandomGossipAnim();
                }
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Gaming)
              this.CharacterAnimation.CrossFade(this.GameAnim);
            else if (this.Actions[this.Phase] == StudentActionType.Shamed)
              this.CharacterAnimation.CrossFade(this.SadSitAnim);
            else if (this.Actions[this.Phase] == StudentActionType.Slave)
            {
              this.CharacterAnimation.CrossFade(this.BrokenSitAnim);
              if (!this.FragileSlave)
                return;
              if ((UnityEngine.Object) this.HuntTarget == (UnityEngine.Object) null)
              {
                this.HuntTarget = this;
                this.GoCommitMurder();
              }
              else
              {
                if (!this.HuntTarget.Indoors)
                  return;
                this.GoCommitMurder();
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Relax)
            {
              if (this.CuriosityPhase == 0)
              {
                this.CharacterAnimation.CrossFade(this.RelaxAnim);
                if (!this.Curious)
                  return;
                this.CuriosityTimer += Time.deltaTime;
                if ((double) this.CuriosityTimer <= 30.0)
                  return;
                if (!this.StudentManager.Students[this.Crush].Private && !this.StudentManager.Students[this.Crush].Wet && !this.StudentManager.LockerRoomArea.bounds.Contains(this.StudentManager.Students[this.Crush].transform.position) && !this.StudentManager.EastBathroomArea.bounds.Contains(this.StudentManager.Students[this.Crush].transform.position) && !this.StudentManager.WestBathroomArea.bounds.Contains(this.StudentManager.Students[this.Crush].transform.position))
                {
                  this.Pathfinding.target = this.StudentManager.Students[this.Crush].transform;
                  this.CurrentDestination = this.StudentManager.Students[this.Crush].transform;
                  this.TargetDistance = 5f;
                  this.CuriosityTimer = 0.0f;
                  ++this.CuriosityPhase;
                }
                else
                  this.CuriosityTimer = 0.0f;
              }
              else
              {
                if ((UnityEngine.Object) this.Pathfinding.target != (UnityEngine.Object) this.StudentManager.Students[this.Crush].transform)
                {
                  this.Pathfinding.target = this.StudentManager.Students[this.Crush].transform;
                  this.CurrentDestination = this.StudentManager.Students[this.Crush].transform;
                }
                if (!this.StudentManager.Students[this.Crush].Alive && this.StudentManager.Students[this.Crush].Ragdoll.Concealed || !this.StudentManager.Students[this.Crush].Alive && this.StudentManager.Students[this.Crush].Ragdoll.Disposed || !this.StudentManager.Students[this.Crush].gameObject.activeInHierarchy)
                  this.CharacterAnimation.CrossFade("lookLeftRightConfused_00");
                else
                  this.CharacterAnimation.CrossFade(this.LeanAnim);
                this.CuriosityTimer += Time.deltaTime;
                if ((double) this.CuriosityTimer <= 10.0 && !this.StudentManager.Students[this.Crush].Private && !this.StudentManager.Students[this.Crush].Wet)
                  return;
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.CurrentDestination = this.Destinations[this.Phase];
                this.TargetDistance = 0.5f;
                this.CuriosityTimer = 0.0f;
                --this.CuriosityPhase;
                if ((this.StudentManager.Students[this.Crush].Alive || !this.StudentManager.Students[this.Crush].Ragdoll.Concealed) && (this.StudentManager.Students[this.Crush].Alive || !this.StudentManager.Students[this.Crush].Ragdoll.Disposed) && this.StudentManager.Students[this.Crush].gameObject.activeInHierarchy)
                  return;
                this.Curious = false;
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes)
            {
              if ((UnityEngine.Object) this.Follower != (UnityEngine.Object) null && this.Follower.Actions[this.Follower.Phase] != StudentActionType.SitAndTakeNotes && (double) this.Clock.HourTime < 15.5)
              {
                Debug.Log((object) "Raibaru has been instructed to go sit down in her seat.");
                this.Follower.GoToClass();
              }
              if ((UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand)
              {
                this.MyPlate.parent = (Transform) null;
                this.MyPlate.position = this.OriginalPlatePosition;
                this.MyPlate.rotation = this.OriginalPlateRotation;
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.IdleAnim = this.OriginalIdleAnim;
                this.WalkAnim = this.OriginalWalkAnim;
                this.LeanAnim = this.OriginalLeanAnim;
                this.ResumeDistracting = false;
                this.Distracting = false;
                this.Distracted = false;
                this.CanTalk = true;
              }
              if (this.MustChangeClothing)
                this.ChangeClothing();
              else if (this.Bullied)
              {
                if (this.SmartPhone.activeInHierarchy)
                  this.SmartPhone.SetActive(false);
                this.CharacterAnimation.CrossFade(this.SadDeskSitAnim, 1f);
              }
              else
              {
                if (this.Phoneless && this.StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !this.EndSearch && this.Yandere.CanMove)
                {
                  if (this.Rival)
                  {
                    this.LewdPhotos = this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos;
                    if (DateGlobals.Weekday == DayOfWeek.Monday)
                    {
                      SchemeGlobals.SetSchemeStage(1, 8);
                      this.Yandere.PauseScreen.Schemes.UpdateInstructions();
                    }
                  }
                  Debug.Log((object) (this.Name + " found her lost phone from this spot in the code. 1"));
                  this.CharacterAnimation.CrossFade(this.DiscoverPhoneAnim);
                  this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 2, 5f);
                  this.Phoneless = false;
                  this.EndSearch = true;
                  this.Routine = false;
                }
                if (this.EndSearch)
                  return;
                if (this.Clock.Period != 2 && this.Clock.Period != 4)
                {
                  if (this.DressCode && this.ClubAttire)
                  {
                    this.CharacterAnimation.CrossFade(this.IdleAnim);
                  }
                  else
                  {
                    if ((double) Vector3.Distance(this.transform.position, this.Seat.position) >= 0.5)
                      return;
                    if (this.StudentID == 1 && this.StudentManager.Gift.activeInHierarchy || this.StudentID == 1 && this.StudentManager.Note.activeInHierarchy)
                    {
                      this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                      this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
                      if ((double) this.CharacterAnimation[this.InspectBloodAnim].time < (double) this.CharacterAnimation[this.InspectBloodAnim].length)
                        return;
                      this.StudentManager.Gift.SetActive(false);
                      this.StudentManager.Note.SetActive(false);
                    }
                    else if (!this.Phoneless)
                    {
                      if (this.Club != ClubType.Delinquent)
                      {
                        if (!this.StudentManager.Eighties)
                        {
                          if (!this.SmartPhone.activeInHierarchy)
                          {
                            if (this.Male)
                            {
                              this.SmartPhone.transform.localPosition = new Vector3(0.025f, 1f / 400f, 0.025f);
                              this.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -160f, 180f);
                            }
                            else
                            {
                              this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.01f, 0.01f);
                              this.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -160f, 165f);
                            }
                            this.SmartPhone.SetActive(true);
                          }
                          this.CharacterAnimation.CrossFade(this.DeskTextAnim);
                        }
                        else
                        {
                          if (this.SmartPhone.activeInHierarchy)
                            this.SmartPhone.SetActive(false);
                          this.CharacterAnimation.CrossFade(this.ConfusedSitAnim);
                        }
                      }
                      else
                        this.CharacterAnimation.CrossFade("delinquentSit_00");
                    }
                    else
                      this.CharacterAnimation.CrossFade(this.ConfusedSitAnim);
                  }
                }
                else if (this.StudentManager.Teachers[this.Class].SpeechLines.isPlaying && !this.StudentManager.Teachers[this.Class].Alarmed)
                {
                  if (this.DressCode && this.ClubAttire)
                  {
                    this.CharacterAnimation.CrossFade(this.IdleAnim);
                  }
                  else
                  {
                    if (!this.Depressed && !this.Pen.activeInHierarchy)
                      this.Pen.SetActive(true);
                    if (this.SmartPhone.activeInHierarchy)
                      this.SmartPhone.SetActive(false);
                    if ((UnityEngine.Object) this.MyPaper == (UnityEngine.Object) null)
                    {
                      this.MyPaper = (double) this.transform.position.x >= 0.0 ? UnityEngine.Object.Instantiate<GameObject>(this.Paper, this.Seat.position + new Vector3(0.4f, 0.772f, 0.0f), Quaternion.identity) : UnityEngine.Object.Instantiate<GameObject>(this.Paper, this.Seat.position + new Vector3(-0.4f, 0.772f, 0.0f), Quaternion.identity);
                      this.MyPaper.transform.eulerAngles = new Vector3(0.0f, 0.0f, -90f);
                      this.MyPaper.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
                      this.MyPaper.transform.parent = this.StudentManager.Papers;
                    }
                    this.CharacterAnimation.CrossFade(this.SitAnim);
                  }
                }
                else if (this.Club != ClubType.Delinquent)
                  this.CharacterAnimation.CrossFade(this.ConfusedSitAnim);
                else
                  this.CharacterAnimation.CrossFade("delinquentSit_00");
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Peek)
            {
              this.CharacterAnimation.CrossFade(this.PeekAnim);
              if (!this.Male)
                return;
              this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
            }
            else if (this.Actions[this.Phase] == StudentActionType.ClubAction)
            {
              if (this.DressCode && !this.ClubAttire)
              {
                this.CharacterAnimation.CrossFade(this.IdleAnim);
              }
              else
              {
                if (this.StudentID == 47 || this.StudentID == 49)
                {
                  if (this.GetNewAnimation)
                    this.StudentManager.ConvoManager.MartialArtsCheck();
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  if ((double) this.CharacterAnimation[this.ClubAnim].time >= (double) this.CharacterAnimation[this.ClubAnim].length)
                    this.GetNewAnimation = true;
                }
                if (this.Club != ClubType.Occult)
                  this.CharacterAnimation.CrossFade(this.ClubAnim);
              }
              if (this.Club == ClubType.Cooking)
              {
                if (this.ClubActivityPhase == 0)
                {
                  if ((double) this.ClubTimer == 0.0)
                  {
                    this.MyPlate.parent = (Transform) null;
                    this.MyPlate.gameObject.SetActive(true);
                    this.MyPlate.position = this.OriginalPlatePosition;
                    this.MyPlate.rotation = this.OriginalPlateRotation;
                  }
                  this.ClubTimer += Time.deltaTime;
                  if ((double) this.ClubTimer <= 60.0)
                    return;
                  this.MyPlate.parent = this.RightHand;
                  this.MyPlate.localPosition = new Vector3(0.02f, -0.02f, -0.15f);
                  this.MyPlate.localEulerAngles = new Vector3(-5f, -90f, 172.5f);
                  this.IdleAnim = this.PlateIdleAnim;
                  this.WalkAnim = this.PlateWalkAnim;
                  this.LeanAnim = this.PlateIdleAnim;
                  this.GetFoodTarget();
                  this.ClubTimer = 0.0f;
                  ++this.ClubActivityPhase;
                }
                else
                  this.GetFoodTarget();
              }
              else if (this.Club == ClubType.Drama)
              {
                this.StudentManager.DramaTimer += Time.deltaTime;
                if (this.StudentManager.DramaPhase == 1)
                {
                  this.StudentManager.ConvoManager.CheckMe(this.StudentID);
                  if (this.Alone)
                  {
                    if (this.Phoneless)
                    {
                      if (!this.Male)
                      {
                        Debug.Log((object) (this.Name + " is going to try to perform the ''FemaleSit01'' animation now."));
                        this.CharacterAnimation.CrossFade("f02_sit_01");
                      }
                      else
                        this.CharacterAnimation.CrossFade("sit_01");
                    }
                    else
                    {
                      if (this.Male)
                        this.CharacterAnimation.CrossFade("standTexting_00");
                      else
                        this.CharacterAnimation.CrossFade("f02_standTexting_00");
                      if (!this.SmartPhone.activeInHierarchy)
                      {
                        this.SmartPhone.transform.localPosition = new Vector3(0.02f, 0.01f, 0.03f);
                        this.SmartPhone.transform.localEulerAngles = new Vector3(5f, -160f, 180f);
                        this.SmartPhone.SetActive(true);
                        this.SpeechLines.Stop();
                      }
                    }
                  }
                  else if (this.StudentID == 26 && !this.SpeechLines.isPlaying)
                  {
                    this.SmartPhone.SetActive(false);
                    this.SpeechLines.Play();
                  }
                  if ((double) this.StudentManager.DramaTimer <= 100.0)
                    return;
                  this.StudentManager.DramaTimer = 0.0f;
                  this.StudentManager.UpdateDrama();
                }
                else if (this.StudentManager.DramaPhase == 2)
                {
                  if ((double) this.StudentManager.DramaTimer <= 300.0)
                    return;
                  this.StudentManager.DramaTimer = 0.0f;
                  this.StudentManager.UpdateDrama();
                }
                else
                {
                  if (this.StudentManager.DramaPhase != 3)
                    return;
                  this.SpeechLines.Play();
                  this.CharacterAnimation.CrossFade(this.RandomAnim);
                  if ((double) this.CharacterAnimation[this.RandomAnim].time >= (double) this.CharacterAnimation[this.RandomAnim].length)
                    this.PickRandomAnim();
                  if ((double) this.StudentManager.DramaTimer <= 100.0)
                    return;
                  this.StudentManager.DramaTimer = 0.0f;
                  this.StudentManager.UpdateDrama();
                }
              }
              else if (this.Club == ClubType.Occult)
              {
                if (this.ReadPhase != 0)
                  return;
                this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                this.CharacterAnimation.CrossFade(this.BookSitAnim);
                if ((double) this.CharacterAnimation[this.BookSitAnim].time > (double) this.CharacterAnimation[this.BookSitAnim].length)
                {
                  this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                  this.CharacterAnimation.CrossFade(this.BookReadAnim);
                  ++this.ReadPhase;
                }
                else
                {
                  if ((double) this.CharacterAnimation[this.BookSitAnim].time <= 1.0)
                    return;
                  this.OccultBook.SetActive(true);
                }
              }
              else if (this.Club == ClubType.Art)
              {
                if (!this.ClubAttire || this.Paintbrush.activeInHierarchy || (double) Vector3.Distance(this.transform.position, this.CurrentDestination.position) >= 0.5)
                  return;
                this.Paintbrush.SetActive(true);
                this.Palette.SetActive(true);
              }
              else if (this.Club == ClubType.LightMusic)
              {
                if ((double) this.Clock.HourTime < 16.9)
                {
                  this.Instruments[this.ClubMemberID].SetActive(true);
                  this.CharacterAnimation.CrossFade(this.ClubAnim);
                  if (this.StudentID == 51)
                  {
                    if ((UnityEngine.Object) this.InstrumentBag[this.ClubMemberID].transform.parent != (UnityEngine.Object) null)
                    {
                      this.InstrumentBag[this.ClubMemberID].transform.parent = (Transform) null;
                      if (!this.StudentManager.Eighties)
                      {
                        this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(0.5f, 4.5f, 22.45666f);
                        this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0.0f, 0.0f);
                      }
                      else
                      {
                        this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(2.06f, 4.5f, 26.5f);
                        this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
                      }
                    }
                    if (!((UnityEngine.Object) this.Instruments[this.ClubMemberID].transform.parent == (UnityEngine.Object) null))
                      return;
                    this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Play();
                    this.Instruments[this.ClubMemberID].transform.parent = this.transform;
                    this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.340493f, 0.653502f, -0.286104f);
                    this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-13.6139f, 16.16775f, 72.5293f);
                  }
                  else
                  {
                    if (this.StudentID != 54 || this.Drumsticks[0].activeInHierarchy)
                      return;
                    this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Play();
                    this.Drumsticks[0].SetActive(true);
                    this.Drumsticks[1].SetActive(true);
                  }
                }
                else if (this.StudentID == 51)
                {
                  int num = (bool) (UnityEngine.Object) this.InstrumentBag[this.ClubMemberID].transform.parent ? 1 : 0;
                  if (!this.StudentManager.Eighties)
                  {
                    this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(0.5f, 4.5f, 22.45666f);
                    this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0.0f, 0.0f);
                  }
                  else
                  {
                    this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(2.06f, 4.5f, 26.5f);
                    this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
                  }
                  this.InstrumentBag[this.ClubMemberID].transform.parent = (Transform) null;
                  if (!this.StudentManager.PracticeMusic.isPlaying)
                    this.CharacterAnimation.CrossFade("f02_vocalIdle_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 114.5)
                    this.CharacterAnimation.CrossFade("f02_vocalCelebrate_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 104.0)
                    this.CharacterAnimation.CrossFade("f02_vocalWait_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 32.0)
                    this.CharacterAnimation.CrossFade("f02_vocalSingB_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 24.0)
                    this.CharacterAnimation.CrossFade("f02_vocalSingB_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 17.0)
                    this.CharacterAnimation.CrossFade("f02_vocalSingB_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 14.0)
                    this.CharacterAnimation.CrossFade("f02_vocalWait_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 8.0)
                  {
                    this.CharacterAnimation.CrossFade("f02_vocalSingA_00");
                  }
                  else
                  {
                    if ((double) this.StudentManager.PracticeMusic.time <= 0.0)
                      return;
                    this.CharacterAnimation.CrossFade("f02_vocalWait_00");
                  }
                }
                else if (this.StudentID == 52)
                {
                  if (!this.Instruments[this.ClubMemberID].activeInHierarchy)
                  {
                    this.Instruments[this.ClubMemberID].SetActive(true);
                    this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
                    this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
                    this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
                    this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
                    this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
                    this.InstrumentBag[this.ClubMemberID].transform.parent = (Transform) null;
                    this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 25f);
                    this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
                  }
                  if (!this.StudentManager.PracticeMusic.isPlaying)
                    this.CharacterAnimation.CrossFade("f02_guitarIdle_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 114.5)
                    this.CharacterAnimation.CrossFade("f02_guitarCelebrate_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 112.0)
                    this.CharacterAnimation.CrossFade("f02_guitarWait_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 64.0)
                    this.CharacterAnimation.CrossFade("f02_guitarPlayA_01");
                  else if ((double) this.StudentManager.PracticeMusic.time > 8.0)
                  {
                    this.CharacterAnimation.CrossFade("f02_guitarPlayA_00");
                  }
                  else
                  {
                    if ((double) this.StudentManager.PracticeMusic.time <= 0.0)
                      return;
                    this.CharacterAnimation.CrossFade("f02_guitarWait_00");
                  }
                }
                else if (this.StudentID == 53)
                {
                  if (!this.Instruments[this.ClubMemberID].activeInHierarchy)
                  {
                    this.Instruments[this.ClubMemberID].SetActive(true);
                    this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
                    this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
                    this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
                    this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
                    this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
                    this.InstrumentBag[this.ClubMemberID].transform.parent = (Transform) null;
                    this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 26f);
                    this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
                  }
                  if (!this.StudentManager.PracticeMusic.isPlaying)
                    this.CharacterAnimation.CrossFade("f02_guitarIdle_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 114.5)
                    this.CharacterAnimation.CrossFade("f02_guitarCelebrate_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 112.0)
                    this.CharacterAnimation.CrossFade("f02_guitarWait_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 88.0)
                    this.CharacterAnimation.CrossFade("f02_guitarPlayA_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 80.0)
                    this.CharacterAnimation.CrossFade("f02_guitarWait_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 64.0)
                  {
                    this.CharacterAnimation.CrossFade("f02_guitarPlayB_00");
                  }
                  else
                  {
                    if ((double) this.StudentManager.PracticeMusic.time <= 0.0)
                      return;
                    this.CharacterAnimation.CrossFade("f02_guitarPlaySlowA_01");
                  }
                }
                else if (this.StudentID == 54)
                {
                  if ((UnityEngine.Object) this.InstrumentBag[this.ClubMemberID].transform.parent != (UnityEngine.Object) null)
                  {
                    this.InstrumentBag[this.ClubMemberID].transform.parent = (Transform) null;
                    this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 23f);
                    this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
                  }
                  this.Drumsticks[0].SetActive(true);
                  this.Drumsticks[1].SetActive(true);
                  if (!this.StudentManager.PracticeMusic.isPlaying)
                    this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 114.5)
                    this.CharacterAnimation.CrossFade("f02_drumsCelebrate_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 108.0)
                    this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 96.0)
                    this.CharacterAnimation.CrossFade("f02_drumsPlaySlow_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 80.0)
                    this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 38.0)
                    this.CharacterAnimation.CrossFade("f02_drumsPlay_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 46.0)
                    this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 16.0)
                  {
                    this.CharacterAnimation.CrossFade("f02_drumsPlay_00");
                  }
                  else
                  {
                    if ((double) this.StudentManager.PracticeMusic.time <= 0.0)
                      return;
                    this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
                  }
                }
                else
                {
                  if (this.StudentID != 55)
                    return;
                  if ((UnityEngine.Object) this.InstrumentBag[this.ClubMemberID].transform.parent != (UnityEngine.Object) null)
                  {
                    this.InstrumentBag[this.ClubMemberID].transform.parent = (Transform) null;
                    this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 24f);
                    this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
                  }
                  if (!this.StudentManager.PracticeMusic.isPlaying)
                    this.CharacterAnimation.CrossFade("f02_keysIdle_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 114.5)
                    this.CharacterAnimation.CrossFade("f02_keysCelebrate_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 80.0)
                    this.CharacterAnimation.CrossFade("f02_keysWait_00");
                  else if ((double) this.StudentManager.PracticeMusic.time > 24.0)
                  {
                    this.CharacterAnimation.CrossFade("f02_keysPlay_00");
                  }
                  else
                  {
                    if ((double) this.StudentManager.PracticeMusic.time <= 0.0)
                      return;
                    this.CharacterAnimation.CrossFade("f02_keysWait_00");
                  }
                }
              }
              else if (this.Club == ClubType.Science)
              {
                if (this.ClubAttire && !this.GoAway || this.StudentManager.Eighties && !this.GoAway)
                {
                  if (this.SciencePhase == 0)
                    this.CharacterAnimation.CrossFade(this.ClubAnim);
                  else
                    this.CharacterAnimation.CrossFade(this.RummageAnim);
                  if ((double) Vector3.Distance(this.transform.position, this.CurrentDestination.position) >= 0.5)
                    return;
                  if (this.SciencePhase == 0)
                  {
                    if (!this.StudentManager.Eighties)
                    {
                      if (this.StudentID == 62)
                        this.ScienceProps[0].SetActive(true);
                      else if (this.StudentID == 63)
                      {
                        this.ScienceProps[1].SetActive(true);
                        this.ScienceProps[2].SetActive(true);
                      }
                      else if (this.StudentID == 64)
                        this.ScienceProps[0].SetActive(true);
                    }
                    else
                    {
                      if (!this.Male && !this.ScienceProps[1].activeInHierarchy)
                        this.CharacterAnimation.Play("f02_straightenSkirt_00");
                      this.ScienceProps[1].SetActive(true);
                      this.ScienceProps[2].SetActive(true);
                    }
                  }
                  if (this.StudentID <= 61)
                    return;
                  this.ClubTimer += Time.deltaTime;
                  if ((double) this.ClubTimer <= 60.0)
                    return;
                  this.ClubTimer = 0.0f;
                  ++this.SciencePhase;
                  if (this.SciencePhase == 1)
                  {
                    this.ClubTimer = 50f;
                    this.Destinations[this.Phase] = this.StudentManager.SupplySpots[this.StudentID - 61];
                    this.CurrentDestination = this.StudentManager.SupplySpots[this.StudentID - 61];
                    this.Pathfinding.target = this.StudentManager.SupplySpots[this.StudentID - 61];
                    foreach (GameObject scienceProp in this.ScienceProps)
                    {
                      if ((UnityEngine.Object) scienceProp != (UnityEngine.Object) null)
                        scienceProp.SetActive(false);
                    }
                  }
                  else
                  {
                    this.SciencePhase = 0;
                    this.ClubTimer = 0.0f;
                    this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID];
                    this.CurrentDestination = this.StudentManager.Clubs.List[this.StudentID];
                    this.Pathfinding.target = this.StudentManager.Clubs.List[this.StudentID];
                  }
                }
                else
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
              }
              else if (this.Club == ClubType.Sports)
              {
                this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                if (this.ClubActivityPhase == 0)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  string str = "";
                  if (!this.Male)
                    str = "f02_";
                  ++this.ClubActivityPhase;
                  this.ClubAnim = str + "stretch_01";
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
                }
                else if (this.ClubActivityPhase == 1)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  string str = "";
                  if (!this.Male)
                    str = "f02_";
                  ++this.ClubActivityPhase;
                  this.ClubAnim = str + "stretch_02";
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
                }
                else if (this.ClubActivityPhase == 2)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  int num = this.Male ? 1 : 0;
                  this.Hurry = true;
                  ++this.ClubActivityPhase;
                  this.CharacterAnimation[this.ClubAnim].time = 0.0f;
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
                }
                else if (this.ClubActivityPhase < 14)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  ++this.ClubActivityPhase;
                  this.CharacterAnimation[this.ClubAnim].time = 0.0f;
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
                }
                else if (this.ClubActivityPhase == 14)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  this.WalkAnim = this.OriginalWalkAnim;
                  string str = "";
                  if (!this.Male)
                    str = "f02_";
                  this.Hurry = false;
                  this.ClubActivityPhase = 0;
                  this.ClubAnim = str + "stretch_00";
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
                }
                else if (this.ClubActivityPhase == 15)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time >= 1.0 && (double) this.MyController.radius > 0.0)
                  {
                    this.MyRenderer.updateWhenOffscreen = true;
                    this.Obstacle.enabled = false;
                    this.MyController.radius = 0.0f;
                    this.Distracted = true;
                  }
                  if (!this.StudentManager.Eighties && (double) this.CharacterAnimation[this.ClubAnim].time >= 2.0)
                  {
                    float num = this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) + Time.deltaTime * 200f;
                    this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, num);
                  }
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < 5.0)
                    return;
                  ++this.ClubActivityPhase;
                }
                else if (this.ClubActivityPhase == 16)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < 6.1)
                    return;
                  if (!this.StudentManager.Eighties)
                  {
                    this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100f);
                    this.Cosmetic.MaleHair[this.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100f);
                  }
                  GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BigWaterSplash, this.RightHand.transform.position, Quaternion.identity);
                  gameObject.transform.eulerAngles = new Vector3(-90f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
                  this.SetSplashes(true);
                  ++this.ClubActivityPhase;
                }
                else if (this.ClubActivityPhase == 17)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  this.WalkAnim = "poolSwim_00";
                  this.ClubAnim = "poolSwim_00";
                  ++this.ClubActivityPhase;
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase - 2);
                  this.transform.position = this.Hips.transform.position;
                  this.Character.transform.localPosition = new Vector3(0.0f, -0.25f, 0.0f);
                  Physics.SyncTransforms();
                  this.CharacterAnimation.Play(this.WalkAnim);
                }
                else if (this.ClubActivityPhase == 18)
                {
                  ++this.ClubActivityPhase;
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase - 2);
                  this.DistanceToDestination = 100f;
                }
                else
                {
                  if (this.ClubActivityPhase != 19)
                    return;
                  this.ClubAnim = "poolExit_00";
                  if ((double) this.CharacterAnimation[this.ClubAnim].time >= 0.10000000149011612)
                    this.SetSplashes(false);
                  if (!this.StudentManager.Eighties && (double) this.CharacterAnimation[this.ClubAnim].time >= 4.6666598320007324)
                  {
                    float num = this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) - Time.deltaTime * 200f;
                    this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, num);
                  }
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  this.ClubActivityPhase = 15;
                  this.ClubAnim = "poolDive_00";
                  this.MyController.radius = 0.1f;
                  this.WalkAnim = this.OriginalWalkAnim;
                  this.MyRenderer.updateWhenOffscreen = false;
                  this.Character.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
                  if (!this.StudentManager.Eighties)
                    this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0.0f);
                  this.transform.position = new Vector3(this.Hips.position.x, 4f, this.Hips.position.z);
                  Physics.SyncTransforms();
                  this.CharacterAnimation.Play(this.IdleAnim);
                  this.Distracted = false;
                  if (this.Clock.Period != 2 && this.Clock.Period != 4)
                    return;
                  this.Pathfinding.speed = 4f;
                }
              }
              else if (this.Club == ClubType.Gardening)
              {
                if (!this.StudentManager.Eighties && (UnityEngine.Object) this.WateringCan.transform.parent != (UnityEngine.Object) this.RightHand)
                {
                  this.WateringCan.transform.parent = this.RightHand;
                  this.WateringCan.transform.localPosition = new Vector3(0.14f, -0.15f, -0.05f);
                  this.WateringCan.transform.localEulerAngles = new Vector3(10f, 15f, 45f);
                }
                this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
                if ((double) this.PatrolTimer < (double) this.CharacterAnimation[this.ClubAnim].length)
                  return;
                ++this.PatrolID;
                if (this.PatrolID == this.StudentManager.Patrols.List[this.StudentID].childCount)
                  this.PatrolID = 0;
                this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
                this.Pathfinding.target = this.CurrentDestination;
                this.PatrolTimer = 0.0f;
                if (this.StudentManager.Eighties)
                  return;
                this.WateringCan.transform.parent = this.Hips;
                this.WateringCan.transform.localPosition = new Vector3(0.0f, 0.0135f, -0.184f);
                this.WateringCan.transform.localEulerAngles = new Vector3(0.0f, 90f, 30f);
              }
              else if (this.Club == ClubType.Gaming)
              {
                if (this.Phase < 8)
                {
                  if (this.StudentID != 36 || this.SmartPhone.activeInHierarchy)
                    return;
                  this.SmartPhone.SetActive(true);
                  this.SmartPhone.transform.localPosition = new Vector3(0.0566666f, -0.02f, 0.0f);
                  this.SmartPhone.transform.localEulerAngles = new Vector3(10f, 115f, 180f);
                }
                else
                {
                  if (!this.ClubManager.GameScreens[this.ClubMemberID].activeInHierarchy)
                  {
                    this.ClubManager.GameScreens[this.ClubMemberID].SetActive(true);
                    this.MyController.radius = 0.2f;
                  }
                  if (!this.SmartPhone.activeInHierarchy)
                    return;
                  this.SmartPhone.SetActive(false);
                }
              }
              else
              {
                if (this.Club != ClubType.Newspaper || this.StudentID <= 36)
                  return;
                this.ClubTimer += Time.deltaTime;
                if ((double) this.ClubTimer <= 30.0)
                  return;
                if ((double) this.CurrentDestination.position.y > 0.0)
                {
                  this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(0);
                  this.Pathfinding.target = this.CurrentDestination;
                  this.ClubAnim = this.PatrolAnim;
                }
                else
                {
                  this.CurrentDestination = this.StudentManager.Clubs.List[this.StudentID];
                  this.Pathfinding.target = this.CurrentDestination;
                  this.ClubAnim = this.OriginalClubAnim;
                }
                this.ClubTimer = 0.0f;
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.SitAndSocialize)
            {
              if ((double) this.Paranoia > 1.666659951210022)
              {
                this.CharacterAnimation.CrossFade(this.IdleAnim);
              }
              else
              {
                this.StudentManager.ConvoManager.CheckMe(this.StudentID);
                if (this.Alone)
                {
                  if (!this.Male)
                    this.CharacterAnimation.CrossFade("f02_standTexting_00");
                  else
                    this.CharacterAnimation.CrossFade("standTexting_00");
                  if (!this.SmartPhone.activeInHierarchy)
                  {
                    this.SmartPhone.SetActive(true);
                    this.SpeechLines.Stop();
                  }
                }
                else
                {
                  if (!this.InEvent && !this.SpeechLines.isPlaying)
                  {
                    this.SmartPhone.SetActive(false);
                    this.SpeechLines.Play();
                  }
                  if (this.Club != ClubType.Photography)
                  {
                    this.CharacterAnimation.CrossFade(this.RandomAnim);
                    if ((double) this.CharacterAnimation[this.RandomAnim].time >= (double) this.CharacterAnimation[this.RandomAnim].length)
                      this.PickRandomAnim();
                  }
                  else
                  {
                    this.CharacterAnimation.CrossFade(this.RandomSleuthAnim);
                    if ((double) this.CharacterAnimation[this.RandomSleuthAnim].time >= (double) this.CharacterAnimation[this.RandomSleuthAnim].length)
                      this.PickRandomSleuthAnim();
                  }
                }
                if (this.StudentID != 56 || this.Clock.Day != 3)
                  return;
                this.BountyCollider.SetActive(true);
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.SitAndEatBento)
            {
              if (this.DiscCheck || (double) this.Alarm >= 100.0)
                return;
              if (!this.Ragdoll.Poisoned && (!this.Bento.activeInHierarchy || (UnityEngine.Object) this.Bento.transform.parent == (UnityEngine.Object) null))
              {
                this.SmartPhone.SetActive(false);
                if (!this.Male)
                {
                  this.Bento.transform.parent = this.LeftItemParent;
                  this.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0.0f);
                  this.Bento.transform.localEulerAngles = new Vector3(0.0f, 165f, 82.5f);
                }
                else
                {
                  this.Bento.transform.parent = this.LeftItemParent;
                  this.Bento.transform.localPosition = new Vector3(-0.05f, -0.085f, 0.0f);
                  this.Bento.transform.localEulerAngles = new Vector3(-3.2f, -24.4f, -94f);
                }
                this.Chopsticks[0].SetActive(true);
                this.Chopsticks[1].SetActive(true);
                this.Bento.SetActive(true);
                this.Lid.SetActive(false);
                this.MyBento.Prompt.Hide();
                this.MyBento.Prompt.enabled = false;
                if (this.MyBento.Tampered)
                {
                  if (this.MyBento.Emetic)
                    this.Emetic = true;
                  else if (this.MyBento.Lethal)
                    this.Lethal = true;
                  else if (this.MyBento.Tranquil)
                    this.Sedated = true;
                  else if (this.MyBento.Headache)
                  {
                    Debug.Log((object) (this.Name + "'s bento contains headache medicine."));
                    this.Headache = true;
                  }
                  this.Distracted = true;
                  this.Alarm = 0.0f;
                  this.UpdateDetectionMarker();
                }
              }
              if (!this.Emetic && !this.Lethal && !this.Sedated && !this.Headache)
              {
                this.CharacterAnimation.CrossFade(this.EatAnim);
                if (!((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null) || (this.FollowTarget.CurrentAction == StudentActionType.SitAndEatBento || this.FollowTarget.Dying) && (double) this.Clock.HourTime <= 13.375)
                  return;
                if (this.FollowTarget.Alive)
                {
                  Debug.Log((object) "Osana is no longer eating, so Raibaru is now following Osana.");
                  this.CharacterAnimation.CrossFade(this.WalkAnim);
                  this.EmptyHands();
                  this.Pathfinding.canSearch = true;
                  this.Pathfinding.canMove = true;
                  ScheduleBlock scheduleBlock1 = this.ScheduleBlocks[4];
                  scheduleBlock1.destination = "Follow";
                  scheduleBlock1.action = "Follow";
                  ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[5];
                  scheduleBlock2.destination = "Follow";
                  scheduleBlock2.action = "Follow";
                  this.GetDestinations();
                  this.Pathfinding.target = this.FollowTarget.transform;
                  this.CurrentDestination = this.FollowTarget.transform;
                }
                else
                {
                  this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 5, 10f);
                  this.RaibaruOsanaDeathScheduleChanges();
                  this.RaibaruStopsFollowingOsana();
                  this.GetDestinations();
                  this.CurrentDestination = this.Destinations[this.Phase];
                  this.Pathfinding.target = this.Destinations[this.Phase];
                }
              }
              else if (this.Emetic)
              {
                if (!this.Private)
                {
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.CharacterAnimation.CrossFade(this.EmeticAnim);
                  this.Distracted = true;
                  this.Private = true;
                  this.CanTalk = false;
                }
                if ((double) this.CharacterAnimation[this.EmeticAnim].time >= 16.0)
                {
                  if (this.StudentID == 10)
                  {
                    if (this.VomitPhase < 0)
                    {
                      this.Subtitle.UpdateLabel(SubtitleType.ObstaclePoisonReaction, 0, 9f);
                      ++this.VomitPhase;
                    }
                  }
                  else if (this.StudentID == 11 && (UnityEngine.Object) this.Follower != (UnityEngine.Object) null)
                    this.StudentManager.LastKnownOsana.position = this.transform.position;
                }
                if ((double) this.CharacterAnimation[this.EmeticAnim].time < (double) this.CharacterAnimation[this.EmeticAnim].length)
                  return;
                Debug.Log((object) (this.Name + " has ingested emetic poison, and should be going to a toilet."));
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                if (this.Male)
                {
                  this.WalkAnim = "stomachPainWalk_00";
                  this.StudentManager.GetMaleVomitSpot(this);
                  this.Pathfinding.target = this.StudentManager.MaleVomitSpot;
                  this.CurrentDestination = this.StudentManager.MaleVomitSpot;
                }
                else
                {
                  this.WalkAnim = "f02_stomachPainWalk_00";
                  this.StudentManager.GetFemaleVomitSpot(this);
                  this.Pathfinding.target = this.StudentManager.FemaleVomitSpot;
                  this.CurrentDestination = this.StudentManager.FemaleVomitSpot;
                }
                if (this.StudentID == 10)
                {
                  this.Pathfinding.target = this.StudentManager.AltFemaleVomitSpot;
                  this.CurrentDestination = this.StudentManager.AltFemaleVomitSpot;
                  this.VomitDoor = this.StudentManager.AltFemaleVomitDoor;
                }
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                this.CharacterAnimation.CrossFade(this.WalkAnim);
                this.DistanceToDestination = 100f;
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                this.Pathfinding.speed = 2f;
                this.MyBento.Tampered = false;
                this.Vomiting = true;
                this.Routine = false;
                this.Chopsticks[0].SetActive(false);
                this.Chopsticks[1].SetActive(false);
                this.Bento.SetActive(false);
              }
              else if (this.Lethal)
              {
                if (!this.Private)
                {
                  AudioSource component = this.GetComponent<AudioSource>();
                  component.clip = this.PoisonDeathClip;
                  component.Play();
                  if (this.Male)
                  {
                    this.CharacterAnimation.CrossFade("poisonDeath_00");
                    this.PoisonDeathAnim = "poisonDeath_00";
                  }
                  else
                  {
                    this.CharacterAnimation.CrossFade("f02_poisonDeath_00");
                    this.PoisonDeathAnim = "f02_poisonDeath_00";
                    this.Distracted = true;
                  }
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.MyRenderer.updateWhenOffscreen = true;
                  this.Ragdoll.Poisoned = true;
                  this.Private = true;
                  this.Prompt.Hide();
                  this.Prompt.enabled = false;
                }
                else if (this.StudentID == 11 && (UnityEngine.Object) this.StudentManager.Students[1] != (UnityEngine.Object) null && !this.StudentManager.Students[1].SenpaiWitnessingRivalDie && (double) Vector3.Distance(this.transform.position, this.StudentManager.Students[1].transform.position) < 2.0)
                {
                  Debug.Log((object) "Setting ''SenpaiWitnessingRivalDie'' to true.");
                  this.StudentManager.Students[1].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.StudentManager.Students[1].CharacterAnimation.CrossFade("witnessPoisoning_00");
                  this.StudentManager.Students[1].CurrentDestination = this.StudentManager.LunchSpots.List[1];
                  this.StudentManager.Students[1].Pathfinding.target = this.StudentManager.LunchSpots.List[1];
                  this.StudentManager.Students[1].MyRenderer.updateWhenOffscreen = true;
                  this.StudentManager.Students[1].SenpaiWitnessingRivalDie = true;
                  this.StudentManager.Students[1].Distracted = true;
                  this.StudentManager.Students[1].Routine = false;
                }
                if (!this.Distracted && (double) this.CharacterAnimation[this.PoisonDeathAnim].time >= 2.5)
                  this.Distracted = true;
                if ((double) this.CharacterAnimation[this.PoisonDeathAnim].time >= 17.5 && this.Bento.activeInHierarchy)
                {
                  this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
                  ++this.Police.Corpses;
                  GameObjectUtils.SetLayerRecursively(this.gameObject, 11);
                  this.MapMarker.gameObject.layer = 10;
                  this.tag = "Blood";
                  this.Ragdoll.ChokingAnimation = true;
                  this.Ragdoll.Disturbing = true;
                  this.Ragdoll.Choking = true;
                  this.Dying = true;
                  this.MurderSuicidePhase = 100;
                  this.SpawnAlarmDisc();
                  Debug.Log((object) (this.Name + " just spawned an 'AlarmDisc'."));
                  this.Chopsticks[0].SetActive(false);
                  this.Chopsticks[1].SetActive(false);
                  this.Bento.SetActive(false);
                }
                if ((double) this.CharacterAnimation[this.PoisonDeathAnim].time < (double) this.CharacterAnimation[this.PoisonDeathAnim].length)
                  return;
                this.BecomeRagdoll();
                this.DeathType = DeathType.Poison;
                this.Ragdoll.Choking = false;
                if (!this.StudentManager.Students[1].SenpaiWitnessingRivalDie)
                  return;
                this.Ragdoll.Prompt.Hide();
                this.Ragdoll.Prompt.enabled = false;
              }
              else if (this.Sedated)
              {
                if (!this.Private)
                {
                  Debug.Log((object) (this.Name + " is beginning to eat food that has been poisoned with a sedative."));
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.CharacterAnimation.CrossFade(this.HeadacheAnim);
                  this.Distracted = true;
                  this.CanTalk = false;
                  this.Private = true;
                }
                if ((double) this.CharacterAnimation[this.HeadacheAnim].time < (double) this.CharacterAnimation[this.HeadacheAnim].length)
                  return;
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                if (this.Male)
                {
                  this.SprintAnim = "headacheWalk_00";
                  this.RelaxAnim = "infirmaryRest_00";
                }
                else
                {
                  this.SprintAnim = "f02_headacheWalk_00";
                  this.RelaxAnim = "f02_infirmaryRest_00";
                }
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                this.CharacterAnimation.CrossFade(this.SprintAnim);
                this.DistanceToDestination = 100f;
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                this.Pathfinding.speed = 2f;
                this.MyBento.Tampered = false;
                this.Private = true;
                this.Sleepy = true;
                ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
                scheduleBlock.destination = "InfirmaryBed";
                scheduleBlock.action = "Relax";
                this.Oversleep();
                this.GetDestinations();
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.Chopsticks[0].SetActive(false);
                this.Chopsticks[1].SetActive(false);
                this.Bento.SetActive(false);
              }
              else
              {
                if (!this.Headache)
                  return;
                if (!this.Private)
                {
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.CharacterAnimation.CrossFade(this.HeadacheAnim);
                  this.CanTalk = false;
                  this.Private = true;
                }
                if ((double) this.CharacterAnimation[this.HeadacheAnim].time < (double) this.CharacterAnimation[this.HeadacheAnim].length)
                  return;
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                if (this.Male)
                {
                  this.SprintAnim = "headacheWalk_00";
                  this.IdleAnim = "headacheIdle_00";
                }
                else
                {
                  this.SprintAnim = "f02_headacheWalk_00";
                  this.IdleAnim = "f02_headacheIdle_00";
                }
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                this.CharacterAnimation.CrossFade(this.SprintAnim);
                this.DistanceToDestination = 100f;
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                this.Pathfinding.speed = 2f;
                this.MyBento.Tampered = false;
                this.SeekingMedicine = true;
                this.Routine = false;
                this.Private = true;
                this.Chopsticks[0].SetActive(false);
                this.Chopsticks[1].SetActive(false);
                this.Bento.SetActive(false);
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.ChangeShoes)
            {
              if (this.MustChangeClothing)
                this.ChangeClothing();
              else if ((double) this.MeetTime == 0.0)
              {
                if (this.StudentID == 1 && !this.StudentManager.LoveManager.ConfessToSuitor && this.StudentManager.LoveManager.LeftNote || this.StudentID == this.StudentManager.LoveManager.SuitorID && this.StudentManager.LoveManager.ConfessToSuitor && this.StudentManager.LoveManager.LeftNote)
                {
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.CharacterAnimation.CrossFade("keepNote_00");
                  this.Pathfinding.canSearch = false;
                  this.Pathfinding.canMove = false;
                  this.Confessing = true;
                  this.CanTalk = false;
                  this.Routine = false;
                }
                else
                {
                  this.SmartPhone.SetActive(false);
                  this.Pathfinding.canSearch = false;
                  this.Pathfinding.canMove = false;
                  this.ShoeRemoval.enabled = true;
                  this.CanTalk = false;
                  this.Routine = false;
                  this.ShoeRemoval.LeavingSchool();
                }
              }
              else
                this.CharacterAnimation.CrossFade(this.IdleAnim);
            }
            else if (this.Actions[this.Phase] == StudentActionType.GradePapers)
            {
              this.CharacterAnimation.CrossFade("f02_deskWrite");
              this.GradingPaper.Writing = true;
              this.Obstacle.enabled = true;
              this.Pen.SetActive(true);
            }
            else if (this.Actions[this.Phase] == StudentActionType.Patrol)
            {
              if (this.PatrolAnim == "")
                this.PatrolAnim = this.IdleAnim;
              if (this.StudentID == 1 && this.ExtraBento && (UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) this.StudentManager.Patrols.List[this.StudentID].GetChild(0))
              {
                this.StudentManager.MondayBento.SetActive(true);
                this.ExtraBento = false;
                if (this.Infatuated)
                {
                  Debug.Log((object) "Senpai is now changing his routine to go stalk the gravure idol.");
                  this.StudentManager.FollowGravureIdol(1);
                  this.CurrentDestination = this.StudentManager.Students[this.InfatuationID].transform;
                  this.Pathfinding.target = this.StudentManager.Students[this.InfatuationID].transform;
                }
              }
              this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
              if (this.StudentManager.Eighties && this.StudentID == 13)
              {
                if (this.PatrolID == 0)
                {
                  this.PatrolAnim = this.BookReadAnim;
                  this.OccultBook.SetActive(true);
                }
                else
                  this.PatrolAnim = this.ThinkAnim;
              }
              if (this.StudentID == 1)
              {
                if (this.PatrolID == 0)
                {
                  if (this.StudentManager.Gift.activeInHierarchy || this.StudentManager.Note.activeInHierarchy)
                  {
                    this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                    this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
                    if ((double) this.CharacterAnimation[this.InspectBloodAnim].time >= (double) this.CharacterAnimation[this.InspectBloodAnim].length)
                    {
                      this.StudentManager.Gift.SetActive(false);
                      this.StudentManager.Note.SetActive(false);
                    }
                  }
                  else
                    this.CharacterAnimation.CrossFade(this.PatrolAnim);
                }
                else
                  this.CharacterAnimation.CrossFade(this.PatrolAnim);
              }
              else
                this.CharacterAnimation.CrossFade(this.PatrolAnim);
              if ((double) this.PatrolTimer >= (double) this.CharacterAnimation[this.PatrolAnim].length || (UnityEngine.Object) this.Pathfinding.target == (UnityEngine.Object) null)
              {
                ++this.PatrolID;
                if (this.PatrolID == this.StudentManager.Patrols.List[this.StudentID].childCount || (UnityEngine.Object) this.Pathfinding.target == (UnityEngine.Object) null)
                  this.PatrolID = 0;
                this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
                this.Pathfinding.target = this.CurrentDestination;
                this.OccultBook.SetActive(false);
                this.PatrolTimer = 0.0f;
              }
              if (!this.Restless)
                return;
              this.SewTimer += Time.deltaTime;
              if ((double) this.SewTimer <= 20.0)
                return;
              this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
              ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
              scheduleBlock.destination = "Sketch";
              scheduleBlock.action = "Sketch";
              this.GetDestinations();
              this.CurrentDestination = this.SketchPosition;
              this.Pathfinding.target = this.SketchPosition;
              this.SewTimer = 0.0f;
            }
            else if (this.Actions[this.Phase] == StudentActionType.Read)
            {
              if (this.ReadPhase != 0)
                return;
              if (this.StudentID == 5)
                this.HorudaCollider.gameObject.SetActive(true);
              this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
              this.CharacterAnimation.CrossFade(this.BookSitAnim);
              if ((double) this.CharacterAnimation[this.BookSitAnim].time > (double) this.CharacterAnimation[this.BookSitAnim].length)
              {
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                this.CharacterAnimation.CrossFade(this.BookReadAnim);
                ++this.ReadPhase;
              }
              else
              {
                if ((double) this.CharacterAnimation[this.BookSitAnim].time <= 1.0)
                  return;
                this.OccultBook.SetActive(true);
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Texting)
            {
              this.CharacterAnimation.CrossFade("f02_midoriTexting_00");
              if ((double) this.SmartPhone.transform.localPosition.x != 0.019999999552965164)
              {
                this.SmartPhone.transform.localPosition = new Vector3(0.02f, -0.0075f, 0.0f);
                this.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -160f, -164f);
              }
              if (this.SmartPhone.activeInHierarchy || (double) this.transform.position.y <= 11.0)
                return;
              this.SmartPhone.SetActive(true);
            }
            else if (this.Actions[this.Phase] == StudentActionType.Mourn)
              this.CharacterAnimation.CrossFade("f02_brokenSit_00");
            else if (this.Actions[this.Phase] == StudentActionType.Cuddle)
            {
              if ((double) Vector3.Distance(this.transform.position, this.Partner.transform.position) < 1.0 && this.Partner.Routine)
              {
                ParticleSystem.EmissionModule emission = this.Hearts.emission;
                if (!emission.enabled)
                {
                  this.Hearts.Play();
                  emission.enabled = true;
                  if (!this.Male)
                    this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
                  else
                    this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
                }
                this.CharacterAnimation.CrossFade(this.CuddleAnim);
              }
              else
                this.CharacterAnimation.CrossFade(this.IdleAnim);
            }
            else if (this.Actions[this.Phase] == StudentActionType.Teaching)
            {
              if (this.Clock.Period != 2 && this.Clock.Period != 4)
              {
                this.CharacterAnimation.CrossFade("f02_teacherPodium_00");
              }
              else
              {
                if (!this.SpeechLines.isPlaying)
                  this.SpeechLines.Play();
                this.CharacterAnimation.CrossFade(this.TeachAnim);
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.SearchPatrol)
            {
              if (this.PatrolID == 0 && this.StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !this.EndSearch)
              {
                if (this.Rival)
                {
                  this.LewdPhotos = this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos;
                  if (DateGlobals.Weekday == DayOfWeek.Monday)
                  {
                    SchemeGlobals.SetSchemeStage(1, 8);
                    this.Yandere.PauseScreen.Schemes.UpdateInstructions();
                  }
                }
                this.CharacterAnimation.CrossFade(this.DiscoverPhoneAnim);
                this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 2, 5f);
                Debug.Log((object) (this.Name + " found her lost phone from this spot in the code. 2"));
                this.Phoneless = false;
                this.EndSearch = true;
                this.Routine = false;
              }
              if (this.EndSearch)
                return;
              this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
              this.CharacterAnimation.CrossFade(this.SearchPatrolAnim);
              if ((double) this.PatrolTimer < (double) this.CharacterAnimation[this.SearchPatrolAnim].length)
                return;
              ++this.PatrolID;
              if (this.PatrolID == this.StudentManager.SearchPatrols.List[this.Class].childCount)
                this.PatrolID = 0;
              this.CurrentDestination = this.StudentManager.SearchPatrols.List[this.Class].GetChild(this.PatrolID);
              this.Pathfinding.target = this.CurrentDestination;
              this.DistanceToDestination = 100f;
              this.PatrolTimer = 0.0f;
            }
            else if (this.Actions[this.Phase] == StudentActionType.Wait)
              this.CharacterAnimation.CrossFade(this.IdleAnim);
            else if (this.Actions[this.Phase] == StudentActionType.LightCig)
            {
              if (!this.Cigarette.active)
              {
                this.WaitAnim = "f02_smokeAttempt_00";
                this.SmartPhone.SetActive(false);
                this.Cigarette.SetActive(true);
                this.Lighter.SetActive(true);
              }
              this.CharacterAnimation.CrossFade(this.WaitAnim);
            }
            else if (this.Actions[this.Phase] == StudentActionType.Random)
              this.CurrentDestination.transform.position = this.StudentManager.PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
            else if (this.Actions[this.Phase] == StudentActionType.Clean)
            {
              this.CleanTimer += Time.deltaTime;
              if (this.CleaningRole == 5)
              {
                if (this.CleanID == 0)
                {
                  this.CharacterAnimation.CrossFade(this.CleanAnims[1]);
                }
                else
                {
                  if (!this.StudentManager.RoofFenceUp)
                  {
                    this.Pushable = true;
                    this.StudentManager.UpdateMe(this.StudentID);
                  }
                  this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
                  if ((double) this.CleanTimer >= 1.166666 && (double) this.CleanTimer <= 6.166666 && !this.ChalkDust.isPlaying)
                    this.ChalkDust.Play();
                }
              }
              else if (this.CleaningRole == 4)
              {
                this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
                if (!this.Drownable)
                {
                  this.Drownable = true;
                  this.StudentManager.UpdateMe(this.StudentID);
                }
              }
              else
                this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
              if ((double) this.CleanTimer < (double) this.CharacterAnimation[this.CleanAnims[this.CleaningRole]].length)
                return;
              ++this.CleanID;
              if (this.CleanID == this.CleaningSpot.childCount)
                this.CleanID = 0;
              this.CurrentDestination = this.CleaningSpot.GetChild(this.CleanID);
              this.Pathfinding.target = this.CurrentDestination;
              this.DistanceToDestination = 100f;
              this.CleanTimer = 0.0f;
              if (this.Pushable)
              {
                this.Prompt.Label[0].text = "     Talk";
                this.Pushable = false;
                this.StudentManager.UpdateMe(this.StudentID);
              }
              if (!this.Drownable)
                return;
              this.Drownable = false;
              this.StudentManager.UpdateMe(this.StudentID);
            }
            else if (this.Actions[this.Phase] == StudentActionType.Graffiti)
            {
              if (this.KilledMood)
              {
                this.Subtitle.UpdateLabel(SubtitleType.KilledMood, 0, 5f);
                this.GraffitiPhase = 4;
                this.KilledMood = false;
              }
              if (this.GraffitiPhase == 0)
              {
                AudioSource.PlayClipAtPoint(this.BullyGiggles[UnityEngine.Random.Range(0, this.BullyGiggles.Length)], this.Head.position);
                this.CharacterAnimation.CrossFade("f02_bullyDesk_00");
                this.SmartPhone.SetActive(false);
                ++this.GraffitiPhase;
              }
              else if (this.GraffitiPhase == 1)
              {
                if ((double) this.CharacterAnimation["f02_bullyDesk_00"].time < 8.0)
                  return;
                this.StudentManager.Graffiti[this.BullyID].SetActive(true);
                ++this.GraffitiPhase;
              }
              else if (this.GraffitiPhase == 2)
              {
                if ((double) this.CharacterAnimation["f02_bullyDesk_00"].time < 9.66666030883789)
                  return;
                AudioSource.PlayClipAtPoint(this.BullyGiggles[UnityEngine.Random.Range(0, this.BullyGiggles.Length)], this.Head.position);
                ++this.GraffitiPhase;
              }
              else if (this.GraffitiPhase == 3)
              {
                if ((double) this.CharacterAnimation["f02_bullyDesk_00"].time < (double) this.CharacterAnimation["f02_bullyDesk_00"].length)
                  return;
                ++this.GraffitiPhase;
              }
              else
              {
                if (this.GraffitiPhase != 4)
                  return;
                this.DistanceToDestination = 100f;
                ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
                scheduleBlock.destination = "Patrol";
                scheduleBlock.action = "Patrol";
                this.GetDestinations();
                if (!this.StudentManager.Eighties)
                {
                  if (this.StudentID == 82)
                    this.StudentManager.UpdateWeek1Hangout(82);
                  else if (this.StudentID == 83)
                    this.StudentManager.UpdateWeek1Hangout(83);
                }
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.SmartPhone.SetActive(true);
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Bully)
            {
              this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
              if ((UnityEngine.Object) this.StudentManager.Students[this.StudentManager.VictimID] != (UnityEngine.Object) null)
              {
                if (this.StudentManager.Students[this.StudentManager.VictimID].Distracted || this.StudentManager.Students[this.StudentManager.VictimID].Tranquil)
                {
                  this.StudentManager.NoBully[this.BullyID] = true;
                  this.KilledMood = true;
                }
                if (this.KilledMood)
                {
                  this.Subtitle.UpdateLabel(SubtitleType.KilledMood, 0, 5f);
                  this.BullyPhase = 4;
                  this.KilledMood = false;
                  this.BullyDust.Stop();
                }
                if ((UnityEngine.Object) this.StudentManager.Students[81] == (UnityEngine.Object) null)
                {
                  ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
                  scheduleBlock.destination = "Patrol";
                  scheduleBlock.action = "Patrol";
                  this.GetDestinations();
                  this.CurrentDestination = this.Destinations[this.Phase];
                  this.Pathfinding.target = this.Destinations[this.Phase];
                }
                else
                {
                  this.SmartPhone.SetActive(false);
                  if (this.BullyID == 1)
                  {
                    if (this.BullyPhase == 0)
                    {
                      this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
                      this.Scrubber.SetActive(true);
                      this.Eraser.SetActive(true);
                      this.StudentManager.Students[this.StudentManager.VictimID].CharacterAnimation.CrossFade(this.StudentManager.Students[this.StudentManager.VictimID].BullyVictimAnim);
                      this.StudentManager.Students[this.StudentManager.VictimID].Routine = false;
                      this.CharacterAnimation.CrossFade("f02_bullyEraser_00");
                      ++this.BullyPhase;
                    }
                    else if (this.BullyPhase == 1)
                    {
                      if ((double) this.CharacterAnimation["f02_bullyEraser_00"].time < 0.83333301544189453)
                        return;
                      this.BullyDust.Play();
                      ++this.BullyPhase;
                    }
                    else if (this.BullyPhase == 2)
                    {
                      if ((double) this.CharacterAnimation["f02_bullyEraser_00"].time < (double) this.CharacterAnimation["f02_bullyEraser_00"].length)
                        return;
                      AudioSource.PlayClipAtPoint(this.BullyLaughs[this.BullyID], this.Head.position);
                      this.CharacterAnimation.CrossFade("f02_bullyLaugh_00");
                      this.Scrubber.SetActive(false);
                      this.Eraser.SetActive(false);
                      ++this.BullyPhase;
                    }
                    else if (this.BullyPhase == 3)
                    {
                      if ((double) this.CharacterAnimation["f02_bullyLaugh_00"].time < (double) this.CharacterAnimation["f02_bullyLaugh_00"].length)
                        return;
                      ++this.BullyPhase;
                    }
                    else
                    {
                      if (this.BullyPhase != 4)
                        return;
                      this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                      this.StudentManager.Students[this.StudentManager.VictimID].Routine = true;
                      ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
                      scheduleBlock.destination = "Patrol";
                      scheduleBlock.action = "Patrol";
                      this.GetDestinations();
                      if (!this.StudentManager.Eighties)
                      {
                        if (this.StudentID == 82)
                          this.StudentManager.UpdateLunchtimeHangout(82);
                        else if (this.StudentID == 83)
                          this.StudentManager.UpdateLunchtimeHangout(83);
                      }
                      this.CurrentDestination = this.Destinations[this.Phase];
                      this.Pathfinding.target = this.Destinations[this.Phase];
                      this.SmartPhone.SetActive(true);
                      this.Scrubber.SetActive(false);
                      this.Eraser.SetActive(false);
                    }
                  }
                  else
                  {
                    if (this.StudentManager.Students[81].BullyPhase < 2)
                    {
                      if ((double) this.GiggleTimer == 0.0)
                      {
                        AudioSource.PlayClipAtPoint(this.BullyGiggles[UnityEngine.Random.Range(0, this.BullyGiggles.Length)], this.Head.position);
                        this.GiggleTimer = 5f;
                      }
                      this.GiggleTimer = Mathf.MoveTowards(this.GiggleTimer, 0.0f, Time.deltaTime);
                      this.CharacterAnimation.CrossFade("f02_bullyGiggle_00");
                    }
                    else if (this.StudentManager.Students[81].BullyPhase < 4)
                    {
                      if ((double) this.LaughTimer == 0.0)
                      {
                        AudioSource.PlayClipAtPoint(this.BullyLaughs[this.BullyID], this.Head.position);
                        this.LaughTimer = 5f;
                      }
                      this.LaughTimer = Mathf.MoveTowards(this.LaughTimer, 0.0f, Time.deltaTime);
                      this.CharacterAnimation.CrossFade("f02_bullyLaugh_00");
                    }
                    if ((double) this.CharacterAnimation["f02_bullyLaugh_00"].time < (double) this.CharacterAnimation["f02_bullyLaugh_00"].length && this.StudentManager.Students[81].BullyPhase != 4 && this.BullyPhase != 4)
                      return;
                    this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                    this.DistanceToDestination = 100f;
                    ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
                    scheduleBlock.destination = "Patrol";
                    scheduleBlock.action = "Patrol";
                    this.GetDestinations();
                    this.CurrentDestination = this.Destinations[this.Phase];
                    this.Pathfinding.target = this.Destinations[this.Phase];
                    this.SmartPhone.SetActive(true);
                  }
                }
              }
              else
              {
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                this.DistanceToDestination = 100f;
                ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
                scheduleBlock.destination = "Patrol";
                scheduleBlock.action = "Patrol";
                this.GetDestinations();
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.SmartPhone.SetActive(true);
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Follow)
            {
              if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null)
              {
                if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.CurrentAction == StudentActionType.Clean && (double) this.FollowTarget.DistanceToDestination < 1.0)
                {
                  this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
                  this.Scrubber.SetActive(true);
                }
                else if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && !this.FollowTarget.Meeting && this.FollowTarget.gameObject.activeInHierarchy && this.FollowTarget.CurrentAction == StudentActionType.Socializing && (double) this.FollowTarget.DistanceToDestination < 1.0)
                {
                  if (this.FollowTarget.Alone || this.FollowTarget.Meeting)
                  {
                    this.CharacterAnimation.CrossFade(this.IdleAnim);
                    this.SpeechLines.Stop();
                  }
                  else
                  {
                    this.Scrubber.SetActive(false);
                    this.SpeechLines.Play();
                    this.CharacterAnimation.CrossFade(this.RandomAnim);
                    if ((double) this.CharacterAnimation[this.RandomAnim].time < (double) this.CharacterAnimation[this.RandomAnim].length)
                      return;
                    this.PickRandomAnim();
                  }
                }
                else if (this.FollowTarget.CurrentAction == StudentActionType.SitAndTakeNotes && this.FollowTarget.Routine && !this.FollowTarget.InEvent && (double) this.FollowTarget.DistanceToDestination < 1.0 && !this.FollowTarget.Meeting && (double) this.Clock.HourTime < 15.5)
                {
                  Debug.Log((object) "Raibaru just changed her destination to class.");
                  this.GoToClass();
                }
                else if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.CurrentAction == StudentActionType.SitAndEatBento && (double) this.FollowTarget.DistanceToDestination < 1.0)
                {
                  Debug.Log((object) "Raibaru just changed her destination to lunch.");
                  ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
                  scheduleBlock.destination = "LunchSpot";
                  scheduleBlock.action = "SitAndEatBento";
                  this.Actions[this.Phase] = StudentActionType.SitAndEatBento;
                  this.CurrentAction = StudentActionType.SitAndEatBento;
                  this.GetDestinations();
                  this.CurrentDestination = this.Destinations[this.Phase];
                  this.Pathfinding.target = this.Destinations[this.Phase];
                }
                else if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.Phase == 8 && (double) this.FollowTarget.DistanceToDestination < 1.0)
                {
                  Debug.Log((object) "Raibaru just changed her destination to the lockers.");
                  ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
                  scheduleBlock.destination = "Locker";
                  scheduleBlock.action = "Shoes";
                  this.Actions[this.Phase] = StudentActionType.ChangeShoes;
                  this.CurrentAction = StudentActionType.ChangeShoes;
                  this.GetDestinations();
                  this.CurrentDestination = this.Destinations[this.Phase];
                  this.Pathfinding.target = this.Destinations[this.Phase];
                }
                else if (this.StudentManager.LoveManager.RivalWaiting && (double) this.FollowTarget.transform.position.x > 40.0 && (double) this.FollowTarget.DistanceToDestination < 1.0)
                {
                  this.CurrentDestination = this.StudentManager.LoveManager.FriendWaitSpot;
                  this.Pathfinding.target = this.StudentManager.LoveManager.FriendWaitSpot;
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
                }
                else if (this.FollowTarget.ConfessPhase == 5)
                {
                  Debug.Log((object) "Raibaru just changed her action to Sketch and her destination to Paint.");
                  ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
                  scheduleBlock.destination = "Paint";
                  scheduleBlock.action = "Sketch";
                  scheduleBlock.time = 99f;
                  this.GetDestinations();
                  this.CurrentDestination = this.Destinations[this.Phase];
                  this.Pathfinding.target = this.Destinations[this.Phase];
                  this.TargetDistance = 1f;
                  this.MyController.radius = 0.1f;
                }
                else
                {
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
                  this.SpeechLines.Stop();
                  if (this.SlideIn)
                    this.MoveTowardsTarget(this.CurrentDestination.position);
                  if (!this.FollowTarget.gameObject.activeInHierarchy || !this.FollowTarget.enabled)
                  {
                    if ((double) this.transform.position.y > -1.0)
                    {
                      Debug.Log((object) "Raibaru cannot find Osana.");
                      this.RaibaruCannotFindOsana();
                    }
                    else
                    {
                      Debug.Log((object) "Osana left school, so Raibaru is disabling herself, too.");
                      this.gameObject.SetActive(false);
                    }
                  }
                  else
                    this.CharacterAnimation.CrossFade(this.IdleAnim);
                }
              }
              else
                this.CharacterAnimation.CrossFade(this.IdleAnim);
            }
            else if (this.Actions[this.Phase] == StudentActionType.Sulk)
            {
              if (this.StudentID == 51)
              {
                this.CharacterAnimation.CrossFade("f02_railingSulk_0" + this.SulkPhase.ToString(), 1f);
                this.SulkTimer += Time.deltaTime;
                if ((double) this.SulkTimer <= 7.6666598320007324)
                  return;
                this.SulkTimer = 0.0f;
                ++this.SulkPhase;
                if (this.SulkPhase != 3)
                  return;
                this.SulkPhase = 0;
              }
              else
              {
                this.CharacterAnimation.CrossFade(this.SulkAnim);
                if (this.StudentID != 76 || this.Clock.Day != 4)
                  return;
                this.BountyCollider.SetActive(true);
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Sleuth)
            {
              if (this.StudentManager.SleuthPhase != 3)
              {
                this.StudentManager.ConvoManager.CheckMe(this.StudentID);
                if (this.Alone)
                {
                  if (this.Male)
                    this.CharacterAnimation.CrossFade("standTexting_00");
                  else
                    this.CharacterAnimation.CrossFade("f02_standTexting_00");
                  if (this.Male)
                  {
                    this.SmartPhone.transform.localPosition = new Vector3(0.025f, 1f / 400f, 0.025f);
                    this.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -160f, 180f);
                  }
                  else
                  {
                    this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.01f, 0.01f);
                    this.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -160f, 165f);
                  }
                  this.SmartPhone.SetActive(true);
                  this.SpeechLines.Stop();
                }
                else
                {
                  if (!this.SpeechLines.isPlaying)
                  {
                    this.SmartPhone.SetActive(false);
                    this.SpeechLines.Play();
                  }
                  this.CharacterAnimation.CrossFade(this.RandomSleuthAnim, 1f);
                  if ((double) this.CharacterAnimation[this.RandomSleuthAnim].time >= (double) this.CharacterAnimation[this.RandomSleuthAnim].length)
                    this.PickRandomSleuthAnim();
                  this.StudentManager.SleuthTimer += Time.deltaTime;
                  if ((double) this.StudentManager.SleuthTimer <= 100.0)
                    return;
                  this.StudentManager.SleuthTimer = 0.0f;
                  this.StudentManager.UpdateSleuths();
                }
              }
              else
              {
                this.CharacterAnimation.CrossFade(this.SleuthScanAnim);
                if ((double) this.CharacterAnimation[this.SleuthScanAnim].time < (double) this.CharacterAnimation[this.SleuthScanAnim].length)
                  return;
                this.GetSleuthTarget();
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Stalk)
            {
              this.CharacterAnimation.CrossFade(this.SleuthIdleAnim);
              if ((double) this.DistanceToPlayer >= 5.0 && !this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position))
                return;
              if ((double) Vector3.Distance(this.transform.position, this.StudentManager.FleeSpots[0].position) > 10.0)
              {
                this.Pathfinding.target = this.StudentManager.FleeSpots[0];
                this.CurrentDestination = this.StudentManager.FleeSpots[0];
              }
              else
              {
                this.Pathfinding.target = this.StudentManager.FleeSpots[1];
                this.CurrentDestination = this.StudentManager.FleeSpots[1];
              }
              this.Pathfinding.speed = 4f;
              this.StalkerFleeing = true;
            }
            else if (this.Actions[this.Phase] == StudentActionType.Sketch)
            {
              this.CharacterAnimation.CrossFade(this.SketchAnim);
              this.Sketchbook.SetActive(true);
              this.Pencil.SetActive(true);
              if (!this.Restless)
                return;
              this.SewTimer += Time.deltaTime;
              if ((double) this.SewTimer <= 20.0)
                return;
              this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
              ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
              scheduleBlock.destination = "Patrol";
              scheduleBlock.action = "Patrol";
              this.GetDestinations();
              this.EmptyHands();
              this.PatrolID = 1;
              this.PatrolTimer = 0.0f;
              this.CharacterAnimation[this.PatrolAnim].time = 0.0f;
              this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
              this.Pathfinding.target = this.CurrentDestination;
              this.SewTimer = 0.0f;
            }
            else if (this.Actions[this.Phase] == StudentActionType.Sunbathe)
            {
              if (this.SunbathePhase == 0)
              {
                this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                this.StudentManager.CommunalLocker.Open = true;
                this.StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this);
                this.MustChangeClothing = true;
                ++this.ChangeClothingPhase;
                ++this.SunbathePhase;
              }
              else if (this.SunbathePhase == 1)
              {
                this.CharacterAnimation.CrossFade(this.StripAnim);
                this.Pathfinding.canSearch = false;
                this.Pathfinding.canMove = false;
                if ((double) this.CharacterAnimation[this.StripAnim].time < 1.5)
                  return;
                if (this.Schoolwear != 2)
                {
                  this.Schoolwear = 2;
                  this.ChangeSchoolwear();
                }
                if ((double) this.CharacterAnimation[this.StripAnim].time <= (double) this.CharacterAnimation[this.StripAnim].length)
                  return;
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                this.Stripping = false;
                if (this.StudentManager.CommunalLocker.SteamCountdown)
                  return;
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                this.Destinations[this.Phase] = this.StudentManager.SunbatheSpots[this.StudentID];
                this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
                this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
                this.StudentManager.CommunalLocker.Student = (StudentScript) null;
                ++this.SunbathePhase;
              }
              else if (this.SunbathePhase == 2)
              {
                if (this.Rival && this.StudentManager.PoolClosed)
                {
                  this.Subtitle.CustomText = "I can't believe anyone would let a stupid sign stop them from sunbathing...";
                  this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                }
                this.MyRenderer.updateWhenOffscreen = true;
                this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                this.CharacterAnimation.CrossFade("f02_sunbatheStart_00");
                this.SmartPhone.SetActive(false);
                if ((double) this.CharacterAnimation["f02_sunbatheStart_00"].time < (double) this.CharacterAnimation["f02_sunbatheStart_00"].length)
                  return;
                this.MyController.radius = 0.0f;
                ++this.SunbathePhase;
              }
              else
              {
                if (this.SunbathePhase != 3)
                  return;
                if (this.Sleepy)
                {
                  if (this.Blind)
                    return;
                  Debug.Log((object) "Aaaaand...NOW! Rival is now asleep.");
                  this.CharacterAnimation.CrossFade("f02_sunbatheSleep_00");
                  this.Ragdoll.Zs.SetActive(true);
                  this.Blind = true;
                }
                else
                  this.CharacterAnimation.CrossFade("f02_sunbatheLoop_00");
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Shock)
            {
              if ((UnityEngine.Object) this.StudentManager.Students[36] == (UnityEngine.Object) null)
                ++this.Phase;
              else if (this.StudentManager.Students[36].Routine && (double) this.StudentManager.Students[36].DistanceToDestination < 1.0)
              {
                if (!this.StudentManager.GamingDoor.Open)
                  this.StudentManager.GamingDoor.OpenDoor();
                ParticleSystem.EmissionModule emission = this.Hearts.emission;
                if (this.SmartPhone.activeInHierarchy)
                {
                  this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
                  this.SmartPhone.SetActive(false);
                  this.MyController.radius = 0.0f;
                  emission.rateOverTime = (ParticleSystem.MinMaxCurve) 5f;
                  emission.enabled = true;
                  this.Hearts.Play();
                }
                this.CharacterAnimation.CrossFade("f02_peeking_0" + (this.StudentID - 80).ToString());
              }
              else
              {
                this.CharacterAnimation.CrossFade(this.PatrolAnim);
                if (this.SmartPhone.activeInHierarchy)
                  return;
                this.SmartPhone.SetActive(true);
                this.MyController.radius = 0.1f;
                if (this.BullyID == 2)
                {
                  int num1 = (int) this.MyController.Move(this.transform.right * 1f * Time.timeScale * 0.2f);
                }
                else if (this.BullyID == 3)
                {
                  int num2 = (int) this.MyController.Move(this.transform.right * -1f * Time.timeScale * 0.2f);
                }
                else if (this.BullyID == 4)
                {
                  int num3 = (int) this.MyController.Move(this.transform.right * 1f * Time.timeScale * 0.2f);
                }
                else
                {
                  if (this.BullyID != 5)
                    return;
                  int num4 = (int) this.MyController.Move(this.transform.right * -1f * Time.timeScale * 0.2f);
                }
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Miyuki)
            {
              if (this.StudentManager.MiyukiEnemy.Enemy.activeInHierarchy)
              {
                if (this.StudentID == 37 && this.Clock.Day == 1)
                  this.BountyCollider.SetActive(true);
                this.CharacterAnimation.CrossFade(this.MiyukiAnim);
                this.MiyukiTimer += Time.deltaTime;
                if ((double) this.MiyukiTimer <= 1.0)
                  return;
                this.MiyukiTimer = 0.0f;
                this.Miyuki.Shoot();
              }
              else
              {
                this.CharacterAnimation.CrossFade(this.VictoryAnim);
                this.BountyCollider.SetActive(false);
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Meeting)
            {
              if (this.StudentID != 36)
              {
                this.StudentManager.Meeting = true;
                if (this.StudentManager.Speaker == this.StudentID)
                {
                  if (this.SpeechLines.isPlaying)
                    return;
                  this.CharacterAnimation.CrossFade(this.RandomAnim);
                  this.SpeechLines.Play();
                }
                else
                {
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
                  if (!this.SpeechLines.isPlaying)
                    return;
                  this.SpeechLines.Stop();
                }
              }
              else
                this.CharacterAnimation.CrossFade(this.PeekAnim);
            }
            else if (this.Actions[this.Phase] == StudentActionType.Lyrics)
            {
              this.LyricsTimer += Time.deltaTime;
              if (this.LyricsPhase == 0)
              {
                this.CharacterAnimation.CrossFade("f02_writingLyrics_00");
                if (!this.Pencil.activeInHierarchy)
                  this.Pencil.SetActive(true);
                if ((double) this.LyricsTimer <= 18.0)
                  return;
                this.StudentManager.LyricsSpot.position = this.StudentManager.AirGuitarSpot.position;
                this.StudentManager.LyricsSpot.eulerAngles = this.StudentManager.AirGuitarSpot.eulerAngles;
                this.Pencil.SetActive(false);
                this.LyricsPhase = 1;
                this.LyricsTimer = 0.0f;
              }
              else
              {
                this.CharacterAnimation.CrossFade("f02_airGuitar_00");
                if (!this.AirGuitar.isPlaying)
                  this.AirGuitar.Play();
                if ((double) this.LyricsTimer <= 18.0)
                  return;
                this.StudentManager.LyricsSpot.position = this.StudentManager.OriginalLyricsSpot.position;
                this.StudentManager.LyricsSpot.eulerAngles = this.StudentManager.OriginalLyricsSpot.eulerAngles;
                this.AirGuitar.Stop();
                this.LyricsPhase = 0;
                this.LyricsTimer = 0.0f;
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Sew)
            {
              this.CharacterAnimation.CrossFade("sewing_00");
              this.PinkSeifuku.SetActive(true);
              if ((double) this.SewTimer >= 10.0 || this.StudentManager.TaskManager.TaskStatus[8] != 3)
                return;
              this.SewTimer += Time.deltaTime;
              if ((double) this.SewTimer <= 10.0)
                return;
              UnityEngine.Object.Instantiate<GameObject>(this.Yandere.PauseScreen.DropsMenu.GetComponent<DropsScript>().InfoChanWindow.Drops[1], new Vector3(28.289f, 0.7718928f, 5.196f), Quaternion.identity);
            }
            else if (this.Actions[this.Phase] == StudentActionType.Paint)
            {
              this.Painting.material.color += new Color(0.0f, 0.0f, 0.0f, Time.deltaTime * 0.00066666f);
              this.CharacterAnimation.CrossFade(this.PaintAnim);
              this.Paintbrush.SetActive(true);
              this.Palette.SetActive(true);
            }
            else if (this.Actions[this.Phase] == StudentActionType.UpdateAppearance)
            {
              Debug.Log((object) "We have reached the ''UpdateAppearance'' code.");
              this.UpdateGemaAppearance();
            }
            else if (this.Actions[this.Phase] == StudentActionType.PlaceBag)
              this.PlaceBag();
            else if (this.Actions[this.Phase] == StudentActionType.Sleep)
              this.CharacterAnimation.CrossFade("f02_infirmaryRest_00");
            else if (this.Actions[this.Phase] == StudentActionType.LightFire)
            {
              if (this.PyroPhase == 1)
              {
                this.CharacterAnimation.CrossFade("f02_startFire_00");
                if ((double) this.DistanceToPlayer < 5.0 && (double) this.Yandere.transform.position.x < (double) this.transform.position.x)
                {
                  this.Subtitle.CustomText = "...oh...I didn't realize someone was here...I'll just...be going, now...";
                  this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                  this.PyroPhase = 4;
                }
                else if ((double) this.CharacterAnimation["f02_startFire_00"].time > (double) this.CharacterAnimation["f02_startFire_00"].length)
                  ++this.PyroPhase;
                else if ((double) this.CharacterAnimation["f02_startFire_00"].time > 13.0)
                {
                  if (this.StudentManager.PyroFlames.isPlaying)
                    return;
                  this.StudentManager.PyroFlames.Play();
                  this.StudentManager.PyroFlameSounds[1].Play();
                  this.StudentManager.PyroFlameSounds[2].Play();
                }
                else if ((double) this.CharacterAnimation["f02_startFire_00"].time > 11.75)
                {
                  this.Note.transform.parent = (Transform) null;
                  this.Note.transform.position -= new Vector3(0.0f, Time.deltaTime, 0.0f);
                }
                else if ((double) this.CharacterAnimation["f02_startFire_00"].time > 11.5)
                  this.Lighter.SetActive(false);
                else if ((double) this.CharacterAnimation["f02_startFire_00"].time > 8.0)
                  this.PaperFire.SetActive(true);
                else if ((double) this.CharacterAnimation["f02_startFire_00"].time > 4.5)
                {
                  this.Lighter.SetActive(true);
                }
                else
                {
                  if ((double) this.CharacterAnimation["f02_startFire_00"].time <= 1.0 || this.Note.gameObject.activeInHierarchy)
                    return;
                  this.Note.transform.parent = this.RightHand;
                  this.Note.transform.localPosition = new Vector3(0.0f, -0.1f, -0.004f);
                  this.Note.transform.localEulerAngles = new Vector3(0.0f, 135f, 45f);
                  this.Note.transform.localScale = new Vector3(0.1f, 0.2f, 1f);
                  this.Note.SetActive(true);
                }
              }
              else if (this.PyroPhase == 2)
              {
                if ((double) this.PyroTimer == 0.0 && (double) this.DistanceToPlayer < 5.0)
                {
                  this.Subtitle.CustomText = "...hehe...it's always just as spellbinding as the first time...";
                  this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                }
                this.CharacterAnimation.CrossFade("f02_inspectLoop_00");
                this.PyroTimer += Time.deltaTime;
                if ((double) this.PyroTimer <= 60.0 && (double) this.Yandere.transform.position.x >= (double) this.transform.position.x)
                  return;
                if ((double) this.DistanceToPlayer < 5.0)
                {
                  if ((double) this.PyroTimer < 60.0)
                  {
                    this.Subtitle.UpdateLabel(SubtitleType.AcceptFood, 0, 0.0f);
                    this.Subtitle.CustomText = "...um...oh, my! Who started this fire? How dangerous! I'd better put it out...";
                    this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                  }
                  else
                  {
                    this.Subtitle.CustomText = "...well, that's enough for now...";
                    this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                  }
                }
                this.StudentManager.PyroWateringCan.parent = this.RightHand;
                this.StudentManager.PyroWateringCan.localPosition = new Vector3(0.14f, -0.15f, -0.05f);
                this.StudentManager.PyroWateringCan.localEulerAngles = new Vector3(10f, 15f, 45f);
                this.Note.transform.parent = this.RightHand;
                this.Note.transform.localPosition = new Vector3(0.0f, -0.1f, -0.004f);
                this.Note.transform.localEulerAngles = new Vector3(0.0f, 135f, 45f);
                this.Note.transform.localScale = new Vector3(0.1f, 0.2f, 1f);
                this.PaperFire.SetActive(false);
                this.Lighter.SetActive(false);
                this.Note.SetActive(false);
                ++this.PyroPhase;
              }
              else if (this.PyroPhase == 3)
              {
                this.CharacterAnimation.CrossFade("f02_waterPlant_00");
                if ((double) this.CharacterAnimation["f02_waterPlant_00"].time <= (double) this.CharacterAnimation["f02_waterPlant_00"].length)
                  return;
                this.WillCombust = true;
                ++this.PyroPhase;
              }
              else
              {
                if (this.PyroPhase != 4)
                  return;
                this.StudentManager.PyroWateringCan.parent = (Transform) null;
                this.StudentManager.PyroWateringCan.localPosition = new Vector3(-41f, 0.0f, 52.5f);
                this.StudentManager.PyroWateringCan.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
                if (this.StudentManager.GasInWateringCan && this.WillCombust)
                  this.Combust();
                else
                  this.FinishPyro();
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Jog)
            {
              this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
              if (this.Schoolwear == 1)
              {
                if (this.SunbathePhase == 0)
                {
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.StudentManager.CommunalLocker.Open = true;
                  this.StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this);
                  this.MustChangeClothing = true;
                  ++this.ChangeClothingPhase;
                  ++this.SunbathePhase;
                }
                else
                {
                  if (this.SunbathePhase != 1)
                    return;
                  this.CharacterAnimation.CrossFade(this.StripAnim);
                  this.Pathfinding.canSearch = false;
                  this.Pathfinding.canMove = false;
                  if ((double) this.CharacterAnimation[this.StripAnim].time < 1.5)
                    return;
                  if (this.Schoolwear != 3)
                  {
                    this.Schoolwear = 3;
                    this.ChangeSchoolwear();
                  }
                  if ((double) this.CharacterAnimation[this.StripAnim].time <= (double) this.CharacterAnimation[this.StripAnim].length)
                    return;
                  this.Pathfinding.canSearch = true;
                  this.Pathfinding.canMove = true;
                  this.Stripping = false;
                  if (this.StudentManager.CommunalLocker.SteamCountdown)
                    return;
                  this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
                  this.Pathfinding.target = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
                  this.CurrentDestination = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
                  this.StudentManager.CommunalLocker.Student = (StudentScript) null;
                  ++this.SunbathePhase;
                }
              }
              else
              {
                this.CharacterAnimation.CrossFade(this.ClubAnim);
                if (this.ClubActivityPhase == 0)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  string str = "";
                  if (!this.Male)
                    str = "f02_";
                  ++this.ClubActivityPhase;
                  this.ClubAnim = str + "stretch_01";
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
                }
                else if (this.ClubActivityPhase == 1)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  string str = "";
                  if (!this.Male)
                    str = "f02_";
                  ++this.ClubActivityPhase;
                  this.ClubAnim = str + "stretch_02";
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
                }
                else if (this.ClubActivityPhase == 2)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  string str = "";
                  if (!this.Male)
                    str = "f02_";
                  this.WalkAnim = str + "trackJog_00";
                  this.Hurry = true;
                  ++this.ClubActivityPhase;
                  this.CharacterAnimation[this.ClubAnim].time = 0.0f;
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
                  this.CurrentDestination = this.Destinations[this.Phase];
                  this.Pathfinding.target = this.CurrentDestination;
                  this.Pathfinding.speed = 4f;
                }
                else if (this.ClubActivityPhase < 14)
                {
                  if ((double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  string str = "";
                  if (!this.Male)
                    str = "f02_";
                  this.WalkAnim = str + "trackJog_00";
                  this.Hurry = true;
                  ++this.ClubActivityPhase;
                  this.CharacterAnimation[this.ClubAnim].time = 0.0f;
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
                  this.CurrentDestination = this.Destinations[this.Phase];
                  this.Pathfinding.target = this.CurrentDestination;
                  this.Pathfinding.speed = 4f;
                }
                else
                {
                  if (this.ClubActivityPhase != 14 || (double) this.CharacterAnimation[this.ClubAnim].time < (double) this.CharacterAnimation[this.ClubAnim].length)
                    return;
                  this.WalkAnim = this.OriginalWalkAnim;
                  this.Hurry = false;
                  this.ClubActivityPhase = 0;
                  this.ClubAnim = !this.Male ? "f02_stretch_00" : "stretch_00";
                  this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
                  this.CurrentDestination = this.Destinations[this.Phase];
                  this.Pathfinding.target = this.CurrentDestination;
                }
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.PrepareFood)
            {
              if (!this.MyBento.gameObject.activeInHierarchy)
              {
                this.MyBento.Lid.SetActive(false);
                this.MyBento.Prompt.enabled = true;
                this.MyBento.transform.parent = (Transform) null;
                this.MyBento.gameObject.SetActive(true);
                this.MyBento.transform.position = this.StudentManager.FoodTrays[this.StudentID].position;
                this.MyBento.transform.eulerAngles = this.StudentManager.FoodTrays[this.StudentID].eulerAngles;
              }
              this.CharacterAnimation.CrossFade(this.PrepareFoodAnim);
              this.ClubTimer += Time.deltaTime;
              if ((double) this.ClubTimer <= 60.0)
                return;
              this.MyBento.transform.parent = this.LeftItemParent;
              this.MyBento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0.0f);
              this.MyBento.transform.localEulerAngles = new Vector3(0.0f, 165f, 82.5f);
              this.MyBento.gameObject.SetActive(false);
              this.MyBento.Prompt.enabled = false;
              this.MyBento.Prompt.Hide();
              ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
              scheduleBlock.destination = "LunchSpot";
              scheduleBlock.action = "Eat";
              this.GetDestinations();
              this.Pathfinding.target = this.Destinations[this.Phase];
              this.CurrentDestination = this.Destinations[this.Phase];
            }
            else if (this.Actions[this.Phase] == StudentActionType.Perform)
            {
              this.CharacterAnimation.CrossFade(this.ClubAnim);
              if (this.StudentID == 52)
              {
                if (this.Instruments[this.ClubMemberID].activeInHierarchy)
                  return;
                this.Instruments[this.ClubMemberID].SetActive(true);
                this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
                this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
                this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
              }
              else if (this.StudentID == 53)
              {
                if (this.Instruments[this.ClubMemberID].activeInHierarchy)
                  return;
                this.Instruments[this.ClubMemberID].SetActive(true);
                this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
                this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
                this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
              }
              else
              {
                if (this.StudentID != 54)
                  return;
                this.Drumsticks[0].SetActive(true);
                this.Drumsticks[1].SetActive(true);
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.PhotoShoot)
            {
              if (this.StudentID == 19)
                Debug.Log((object) "Yeah, the gravure model recognizes that she's supposed to be at a Photo Shoot...");
              if ((UnityEngine.Object) this.StudentManager.Students[19] != (UnityEngine.Object) null)
              {
                if ((double) this.StudentManager.Students[19].ClubTimer > 0.0 && (double) this.StudentManager.Students[19].DistanceToDestination < 1.0)
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
                else
                  this.CharacterAnimation.CrossFade(this.ThinkAnim);
              }
              else
                this.CharacterAnimation.CrossFade(this.ThinkAnim);
            }
            else if (this.Actions[this.Phase] == StudentActionType.GravurePose)
            {
              if (this.Hurry)
                return;
              if (this.SunbathePhase < 2)
              {
                if (this.SunbathePhase == 0)
                {
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.StudentManager.CommunalLocker.Open = true;
                  this.StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this);
                  this.MustChangeClothing = true;
                  ++this.ChangeClothingPhase;
                  ++this.SunbathePhase;
                }
                else
                {
                  if (this.SunbathePhase != 1)
                    return;
                  this.CharacterAnimation.CrossFade(this.StripAnim);
                  this.Pathfinding.canSearch = false;
                  this.Pathfinding.canMove = false;
                  if ((double) this.CharacterAnimation[this.StripAnim].time < 1.5)
                    return;
                  this.WearBikini();
                  if ((double) this.CharacterAnimation[this.StripAnim].time <= (double) this.CharacterAnimation[this.StripAnim].length)
                    return;
                  this.Pathfinding.canSearch = true;
                  this.Pathfinding.canMove = true;
                  this.Stripping = false;
                  if (this.StudentManager.CommunalLocker.SteamCountdown)
                    return;
                  this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                  this.Destinations[this.Phase] = this.StudentManager.Hangouts.List[19];
                  this.Pathfinding.target = this.StudentManager.Hangouts.List[19];
                  this.CurrentDestination = this.StudentManager.Hangouts.List[19];
                  this.StudentManager.CommunalLocker.Student = (StudentScript) null;
                  ++this.SunbathePhase;
                }
              }
              else
              {
                this.CharacterAnimation.CrossFade(this.ClubAnim);
                this.ClubTimer += Time.deltaTime;
                if ((double) this.ClubTimer <= 5.0)
                  return;
                ++this.ClubPhase;
                if (this.ClubPhase == this.GravureAnims.Length - 1)
                  this.ClubPhase = 0;
                this.ClubAnim = this.GravureAnims[this.ClubPhase];
                this.ClubTimer = 0.0f;
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.Guard)
              this.CharacterAnimation.CrossFade(this.IdleAnim);
            else if (this.Actions[this.Phase] == StudentActionType.HelpTeacher)
            {
              this.CharacterAnimation.CrossFade(this.ThinkAnim);
              if ((double) this.CharacterAnimation[this.ThinkAnim].time <= (double) this.CharacterAnimation[this.ThinkAnim].length)
                return;
              this.GetTeacherTarget();
            }
            else
            {
              if (this.Actions[this.Phase] != StudentActionType.Admire)
                return;
              this.CharacterAnimation.CrossFade(this.AdmireAnim);
            }
          }
          else
          {
            this.CurrentDestination = this.StudentManager.GoAwaySpots.List[this.StudentID];
            this.Pathfinding.target = this.StudentManager.GoAwaySpots.List[this.StudentID];
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.GoAwayTimer += Time.deltaTime;
            if ((double) this.GoAwayTimer <= 10.0)
              return;
            Debug.Log((object) "This code is only called after a character has spent 10 seconds standing in a 'Go Away'' spot.");
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
            this.GoAwayTimer = 0.0f;
            this.GoAway = false;
          }
        }
        else
        {
          if ((double) this.MeetTimer == 0.0)
          {
            Debug.Log((object) (this.Name + " has arrived at their meeting spot."));
            if ((double) this.Yandere.Bloodiness + (double) this.Yandere.GloveBlood == 0.0 && (double) this.Yandere.Sanity >= 66.66666 && ((UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) this.StudentManager.MeetSpots.List[8] || (UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) this.StudentManager.MeetSpots.List[9] || (UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) this.StudentManager.MeetSpots.List[10]))
            {
              if (this.StudentManager.Eighties && this.StudentID == this.StudentManager.RivalID)
              {
                if ((UnityEngine.Object) this.StudentManager.EightiesOfferHelp != (UnityEngine.Object) null)
                {
                  this.StudentManager.EightiesOfferHelp.UpdateLocation();
                  this.StudentManager.EightiesOfferHelp.enabled = true;
                  this.StudentManager.EightiesOfferHelp.Prompt.enabled = true;
                }
              }
              else if (this.StudentID == 11)
              {
                this.StudentManager.OsanaOfferHelp.UpdateLocation();
                this.StudentManager.OsanaOfferHelp.enabled = true;
                this.StudentManager.OsanaOfferHelp.Prompt.enabled = true;
              }
              else if (this.StudentID == 5)
              {
                this.Yandere.BullyPhotoCheck();
                if (this.Yandere.BullyPhoto)
                {
                  this.StudentManager.FragileOfferHelp.gameObject.SetActive(true);
                  this.StudentManager.FragileOfferHelp.UpdateLocation();
                  this.StudentManager.FragileOfferHelp.enabled = true;
                  this.StudentManager.FragileOfferHelp.Prompt.enabled = true;
                }
              }
            }
            if (!SchoolGlobals.RoofFence && (double) this.transform.position.y > 11.0)
            {
              this.Pushable = true;
              this.StudentManager.UpdateMe(this.StudentID);
            }
            if ((UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) this.StudentManager.FountainSpot)
            {
              Debug.Log((object) (this.Name + " is now drownable."));
              this.Drownable = true;
              this.StudentManager.UpdateMe(this.StudentID);
            }
          }
          this.MeetTimer += Time.deltaTime;
          if ((UnityEngine.Object) this.Follower != (UnityEngine.Object) null)
            this.FollowTargetDestination.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
          if (this.BakeSale)
          {
            this.CharacterAnimation.CrossFade(this.PlateEatAnim);
            this.MeetTimer += Time.deltaTime * 6.5f;
          }
          else
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          if ((double) this.MeetTimer <= 60.0)
            return;
          if (!this.BakeSale)
          {
            if (!this.Male)
              this.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 4, 3f);
            else if (this.StudentID == 28)
              this.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 6, 3f);
            else
              this.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 4, 3f);
          }
          Debug.Log((object) (this.Name + " has been waiting for 60 seconds."));
          while ((double) this.Clock.HourTime >= (double) this.ScheduleBlocks[this.Phase].time)
            ++this.Phase;
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          if ((UnityEngine.Object) this.Follower != (UnityEngine.Object) null)
          {
            this.Follower.CurrentDestination = this.Follower.FollowTarget.transform;
            this.Follower.Pathfinding.target = this.Follower.FollowTarget.transform;
            this.FollowTargetDestination.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
          }
          this.StopMeeting();
        }
      }
    }
    else
    {
      if ((UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) null)
        this.DistanceToDestination = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
      if (this.Fleeing)
      {
        if (this.Fleeing && this.WitnessedMurder && this.Persona == PersonaType.Heroic)
        {
          Debug.Log((object) (this.Name + " has the ''Heroic'' Persona and is using the ''Fleeing'' protocol."));
          this.Pathfinding.target = this.Yandere.transform;
          this.CurrentDestination = this.Yandere.transform;
        }
        if (!this.Dying && !this.Spraying)
        {
          if (!this.PinningDown)
          {
            if (this.Persona == PersonaType.Dangerous)
            {
              this.Yandere.Pursuer = this;
              Debug.Log((object) "This student council member is running to intercept Yandere-chan.");
              if (this.Yandere.Laughing)
              {
                this.Yandere.StopLaughing();
                this.Yandere.Chased = true;
                this.Yandere.CanMove = false;
              }
              if (this.Yandere.Cauterizing || this.Yandere.Dismembering)
              {
                if (this.Yandere.Dismembering)
                  this.Yandere.StopDismembering();
                this.Yandere.Cauterizing = false;
                this.Yandere.Chased = true;
                this.Yandere.CanMove = false;
              }
              if (this.StudentManager.CombatMinigame.Path > 3 && this.StudentManager.CombatMinigame.Path < 7)
                this.ReturnToRoutine();
            }
            if ((UnityEngine.Object) this.Pathfinding.target != (UnityEngine.Object) null)
              this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
            if ((double) this.AlarmTimer > 0.0)
            {
              this.AlarmTimer = Mathf.MoveTowards(this.AlarmTimer, 0.0f, Time.deltaTime);
              if (this.StudentID == 1)
                Debug.Log((object) "Senpai entered his scared animation.");
              this.CharacterAnimation.CrossFade(this.ScaredAnim);
              if ((double) this.AlarmTimer == 0.0)
              {
                this.WalkBack = false;
                this.Alarmed = false;
              }
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              if (this.WitnessedMurder)
              {
                this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
              }
              else if (this.WitnessedCorpse)
              {
                this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, this.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - this.transform.position);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
              }
            }
            else
            {
              if (this.Persona == PersonaType.TeachersPet && this.WitnessedMurder && this.ReportPhase == 0 && (UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) null && !this.Police.Called)
              {
                Debug.Log((object) (this.Name + " is setting their teacher as their destination at the beginning of Flee protocol."));
                this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
                this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
                this.StudentManager.Reporter = this;
                this.ReportingMurder = true;
                this.DetermineCorpseLocation();
              }
              if ((double) this.transform.position.y < -10.0)
              {
                if (!this.StudentManager.Jammed)
                {
                  if (this.Persona == PersonaType.PhoneAddict && this.WitnessedMurder && !this.SawMask)
                    this.PhoneAddictGameOver();
                  else if (this.Persona != PersonaType.Evil && this.Persona != PersonaType.Coward && this.Persona != PersonaType.Fragile)
                  {
                    this.Police.Called = true;
                    this.Police.Show = true;
                  }
                }
                this.transform.position = new Vector3(this.transform.position.x, -100f, this.transform.position.z);
                this.gameObject.SetActive(false);
              }
              if ((double) this.transform.position.y < -11.0)
              {
                if (this.Persona != PersonaType.Coward && this.Persona != PersonaType.Evil && this.Persona != PersonaType.Fragile && this.OriginalPersona != PersonaType.Evil)
                {
                  --this.Police.Witnesses;
                  if (!this.StudentManager.Jammed)
                  {
                    this.Police.Show = true;
                    if (this.Countdown.gameObject.activeInHierarchy)
                      this.PhoneAddictGameOver();
                  }
                }
                this.transform.position = new Vector3(this.transform.position.x, -100f, this.transform.position.z);
                this.gameObject.SetActive(false);
              }
              if ((double) this.transform.position.z < -99.0)
              {
                this.Prompt.Hide();
                this.Prompt.enabled = false;
                this.Safe = true;
              }
              if ((double) this.DistanceToDestination > (double) this.TargetDistance)
              {
                if (!this.Phoneless)
                  this.CharacterAnimation.CrossFade(this.SprintAnim);
                else
                  this.CharacterAnimation.CrossFade(this.OriginalSprintAnim);
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                if (this.Yandere.Chased && (UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) this)
                {
                  this.Pathfinding.repathRate = 0.0f;
                  this.Pathfinding.speed = 5f;
                  this.ChaseTimer += Time.deltaTime;
                  if ((double) this.ChaseTimer > 10.0)
                  {
                    this.transform.position = this.Yandere.transform.position + this.Yandere.transform.forward * 0.999f;
                    this.transform.LookAt(this.Yandere.transform.position);
                    Physics.SyncTransforms();
                  }
                }
                else
                  this.Pathfinding.speed = 4f;
                if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless && !this.CrimeReported)
                {
                  if ((double) this.Countdown.Sprite.fillAmount == 0.0)
                  {
                    this.Countdown.Sprite.fillAmount = 1f;
                    this.CrimeReported = true;
                    if (this.WitnessedMurder && !this.Countdown.MaskedPhoto)
                    {
                      this.PhoneAddictGameOver();
                    }
                    else
                    {
                      if ((UnityEngine.Object) this.StudentManager.ChaseCamera == (UnityEngine.Object) this.ChaseCamera)
                        this.StudentManager.ChaseCamera = (GameObject) null;
                      this.SprintAnim = this.OriginalSprintAnim;
                      this.Countdown.gameObject.SetActive(false);
                      this.ChaseCamera.SetActive(false);
                      if (!this.StudentManager.Jammed)
                      {
                        this.Police.Called = true;
                        this.Police.Show = true;
                      }
                    }
                  }
                  else
                  {
                    this.SprintAnim = this.PhoneAnims[2];
                    if (!this.StudentManager.Eighties && (UnityEngine.Object) this.StudentManager.ChaseCamera == (UnityEngine.Object) null)
                    {
                      this.StudentManager.ChaseCamera = this.ChaseCamera;
                      this.ChaseCamera.SetActive(true);
                    }
                  }
                }
              }
              else
              {
                this.Pathfinding.canSearch = false;
                this.Pathfinding.canMove = false;
                if (!this.Halt)
                {
                  if (this.StudentID > 1)
                  {
                    this.MoveTowardsTarget(this.Pathfinding.target.position);
                    if (!this.Teacher && !this.FocusOnYandere)
                      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
                  }
                }
                else
                {
                  if (this.Spraying)
                    this.CharacterAnimation.CrossFade(this.SprayAnim);
                  if (this.Persona == PersonaType.TeachersPet)
                  {
                    this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Teachers[this.Class].transform.position.x, this.transform.position.y, this.StudentManager.Teachers[this.Class].transform.position.z) - this.transform.position);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                  }
                  else if (this.Persona == PersonaType.Dangerous && !this.BreakingUpFight)
                  {
                    this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                  }
                }
                if (this.Persona == PersonaType.TeachersPet)
                {
                  if (this.ReportingMurder || this.ReportingBlood)
                  {
                    if (this.StudentManager.Teachers[this.Class].Alarmed && this.ReportPhase < 100)
                    {
                      if (this.Club == ClubType.Council)
                      {
                        this.Pathfinding.target = this.StudentManager.CorpseLocation;
                        this.CurrentDestination = this.StudentManager.CorpseLocation;
                      }
                      else
                      {
                        if ((UnityEngine.Object) this.PetDestination == (UnityEngine.Object) null)
                          this.PetDestination = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, this.Seat.position + this.Seat.forward * -0.5f, Quaternion.identity).transform;
                        this.Pathfinding.target = this.PetDestination;
                        this.CurrentDestination = this.PetDestination;
                      }
                      this.ReportPhase = 3;
                    }
                    if (this.ReportPhase == 0)
                    {
                      Debug.Log((object) (this.Name + ", currently acting as a Teacher's Pet, is talking to a teacher."));
                      if ((UnityEngine.Object) this.MyTeacher == (UnityEngine.Object) null)
                        this.MyTeacher = this.StudentManager.Teachers[this.Class];
                      if (!this.MyTeacher.Alive)
                      {
                        this.Persona = PersonaType.Loner;
                        this.PersonaReaction();
                      }
                      else
                      {
                        this.Subtitle.Speaker = this;
                        this.CharacterAnimation.CrossFade(this.ScaredAnim);
                        if (this.WitnessedMurder)
                          this.Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 2, 3f);
                        else if (this.WitnessedCorpse)
                        {
                          if (this.Club == ClubType.Council)
                          {
                            this.Subtitle.CustomText = "";
                            this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 0.0f);
                            if (this.StudentID == 86)
                              this.Subtitle.UpdateLabel(SubtitleType.StrictReport, 2, 5f);
                            else if (this.StudentID == 87)
                              this.Subtitle.UpdateLabel(SubtitleType.CasualReport, 2, 5f);
                            else if (this.StudentID == 88)
                              this.Subtitle.UpdateLabel(SubtitleType.GraceReport, 2, 5f);
                            else if (this.StudentID == 89)
                              this.Subtitle.UpdateLabel(SubtitleType.EdgyReport, 2, 5f);
                          }
                          else
                            this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 2, 3f);
                        }
                        else if (this.WitnessedLimb)
                          this.Subtitle.UpdateLabel(SubtitleType.PetLimbReport, 2, 3f);
                        else if (this.WitnessedBloodyWeapon)
                          this.Subtitle.UpdateLabel(SubtitleType.PetBloodyWeaponReport, 2, 3f);
                        else if (this.WitnessedBloodPool)
                          this.Subtitle.UpdateLabel(SubtitleType.PetBloodReport, 2, 3f);
                        else if (this.WitnessedWeapon)
                          this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReport, 2, 3f);
                        this.MyTeacher = this.StudentManager.Teachers[this.Class];
                        this.MyTeacher.CurrentDestination = this.MyTeacher.transform;
                        this.MyTeacher.Pathfinding.target = this.MyTeacher.transform;
                        this.MyTeacher.Pathfinding.canSearch = false;
                        this.MyTeacher.Pathfinding.canMove = false;
                        this.MyTeacher.CharacterAnimation.CrossFade(this.MyTeacher.IdleAnim);
                        this.MyTeacher.ListeningToReport = true;
                        this.MyTeacher.Routine = false;
                        if (this.StudentManager.Teachers[this.Class].Investigating)
                          this.StudentManager.Teachers[this.Class].StopInvestigating();
                        this.Halt = true;
                        ++this.ReportPhase;
                      }
                    }
                    else if (this.ReportPhase == 1)
                    {
                      this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
                      this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
                      if (this.WitnessedBloodPool || this.WitnessedWeapon && !this.WitnessedBloodyWeapon)
                        this.CharacterAnimation.CrossFade(this.IdleAnim);
                      else if (this.WitnessedMurder || this.WitnessedCorpse || this.WitnessedLimb || this.WitnessedBloodyWeapon)
                        this.CharacterAnimation.CrossFade(this.ScaredAnim);
                      this.StudentManager.Teachers[this.Class].targetRotation = Quaternion.LookRotation(this.transform.position - this.StudentManager.Teachers[this.Class].transform.position);
                      this.StudentManager.Teachers[this.Class].transform.rotation = Quaternion.Slerp(this.StudentManager.Teachers[this.Class].transform.rotation, this.StudentManager.Teachers[this.Class].targetRotation, 10f * Time.deltaTime);
                      this.ReportTimer += Time.deltaTime;
                      if ((double) this.ReportTimer >= 3.0)
                      {
                        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
                        this.StudentManager.Teachers[this.Class].ListeningToReport = false;
                        this.StudentManager.Teachers[this.Class].MyReporter = this;
                        this.StudentManager.Teachers[this.Class].Routine = false;
                        this.StudentManager.Teachers[this.Class].Fleeing = true;
                        this.ReportTimer = 0.0f;
                        ++this.ReportPhase;
                      }
                    }
                    else if (this.ReportPhase == 2)
                    {
                      this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
                      this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
                      if (this.WitnessedBloodPool || this.WitnessedWeapon && !this.WitnessedBloodyWeapon)
                        this.CharacterAnimation.CrossFade(this.IdleAnim);
                      else if (this.WitnessedMurder || this.WitnessedCorpse || this.WitnessedLimb || this.WitnessedBloodyWeapon)
                        this.CharacterAnimation.CrossFade(this.ScaredAnim);
                    }
                    else if (this.ReportPhase == 3)
                    {
                      this.Pathfinding.target = this.transform;
                      this.CurrentDestination = this.transform;
                      if (this.WitnessedBloodPool || this.WitnessedWeapon && !this.WitnessedBloodyWeapon)
                        this.CharacterAnimation.CrossFade(this.IdleAnim);
                      else if (this.WitnessedMurder || this.WitnessedCorpse || this.WitnessedLimb || this.WitnessedBloodyWeapon)
                        this.CharacterAnimation.CrossFade(this.ParanoidAnim);
                    }
                    else if (this.ReportPhase < 100)
                    {
                      this.CharacterAnimation.CrossFade(this.ParanoidAnim);
                    }
                    else
                    {
                      if ((UnityEngine.Object) this.Pathfinding.target != (UnityEngine.Object) this.transform)
                      {
                        Debug.Log((object) "This character just set their destination to themself.");
                        if (this.Club == ClubType.Council)
                        {
                          Debug.Log((object) "The reporter was a student council member.");
                          if (this.StudentID == 86)
                            this.Subtitle.UpdateLabel(SubtitleType.StrictReport, 3, 5f);
                          else if (this.StudentID == 87)
                            this.Subtitle.UpdateLabel(SubtitleType.CasualReport, 3, 5f);
                          else if (this.StudentID == 88)
                            this.Subtitle.UpdateLabel(SubtitleType.GraceReport, 3, 5f);
                          else if (this.StudentID == 89)
                            this.Subtitle.UpdateLabel(SubtitleType.EdgyReport, 3, 5f);
                        }
                        else
                          this.Subtitle.UpdateLabel(SubtitleType.PrankReaction, 1, 5f);
                      }
                      this.Pathfinding.target = this.transform;
                      this.CurrentDestination = this.transform;
                      this.CharacterAnimation.CrossFade(this.ScaredAnim);
                      this.ReportTimer += Time.deltaTime;
                      if ((double) this.ReportTimer >= 5.0)
                        this.ReturnToNormal();
                    }
                    if ((UnityEngine.Object) this.MyTeacher != (UnityEngine.Object) null && this.MyTeacher.Guarding && this.Club == ClubType.Council)
                    {
                      this.CharacterAnimation.CrossFade(this.GuardAnim);
                      this.Persona = PersonaType.Dangerous;
                      this.Guarding = true;
                      this.Fleeing = false;
                    }
                  }
                  else if (this.Club == ClubType.Council)
                  {
                    this.CharacterAnimation.CrossFade(this.GuardAnim);
                    this.Persona = PersonaType.Dangerous;
                    this.Guarding = true;
                    this.Fleeing = false;
                  }
                  else
                  {
                    this.CharacterAnimation.CrossFade(this.ParanoidAnim);
                    this.ReportPhase = 100;
                    this.Fleeing = false;
                    this.Persona = this.OriginalPersona;
                    this.IgnoringPettyActions = true;
                    this.Guarding = true;
                  }
                }
                else if (this.Persona == PersonaType.Heroic)
                {
                  Debug.Log((object) (this.Name + " has the ''Heroic'' Persona and is using the ''Fleeing'' protocol."));
                  if (this.Yandere.Attacking || this.Yandere.Struggling && (UnityEngine.Object) this.Yandere.StruggleBar.Student != (UnityEngine.Object) this)
                  {
                    this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
                    this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                    this.Pathfinding.canSearch = false;
                    this.Pathfinding.canMove = false;
                  }
                  else if (!this.Yandere.Attacking && !this.StudentManager.PinningDown && !this.Yandere.Shoved)
                  {
                    if (this.StudentID > 1)
                    {
                      if (!this.Yandere.Struggling && !this.Yandere.StruggleBar.gameObject.activeInHierarchy && this.Yandere.RPGCamera.enabled)
                      {
                        if (this.Frame > 0)
                        {
                          Debug.Log((object) (this.Name + " is calling BeginStruggle() from this place in the code."));
                          this.BeginStruggle();
                        }
                        ++this.Frame;
                      }
                      this.CharacterAnimation[this.StruggleAnim].time = this.Teacher ? this.Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time : this.Yandere.CharacterAnimation["f02_struggleA_00"].time;
                      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Yandere.transform.rotation, 10f * Time.deltaTime);
                      if (!this.StopSliding)
                        this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.425f);
                      if (!this.Yandere.Armed || !this.Yandere.EquippedWeapon.Concealable)
                      {
                        this.BeginStruggle();
                        this.Yandere.StruggleBar.HeroWins();
                      }
                      if (this.Lost)
                      {
                        this.CharacterAnimation.CrossFade(this.StruggleWonAnim);
                        if ((double) this.CharacterAnimation[this.StruggleWonAnim].time > 1.0)
                          this.EyeShrink = 1f;
                        if ((double) this.CharacterAnimation[this.StruggleWonAnim].time < (double) this.CharacterAnimation[this.StruggleWonAnim].length)
                          ;
                      }
                      else if (this.Won)
                        this.CharacterAnimation.CrossFade(this.StruggleLostAnim);
                    }
                    else if ((UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null)
                    {
                      this.Yandere.EmptyHands();
                      this.Pathfinding.canSearch = false;
                      this.Pathfinding.canMove = false;
                      this.TargetDistance = 1f;
                      this.Yandere.CharacterAnimation.CrossFade("f02_unmasking_00");
                      this.CharacterAnimation.CrossFade("unmasking_00");
                      this.Yandere.CanMove = false;
                      this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
                      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                      this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 1f);
                      if ((double) this.CharacterAnimation["unmasking_00"].time == 0.0)
                      {
                        this.Yandere.ShoulderCamera.YandereNo();
                        this.Yandere.Jukebox.GameOver();
                      }
                      if ((double) this.CharacterAnimation["unmasking_00"].time >= 0.66666001081466675 && (UnityEngine.Object) this.Yandere.Mask.transform.parent != (UnityEngine.Object) this.LeftHand)
                      {
                        this.Yandere.CanMove = true;
                        this.Yandere.EmptyHands();
                        this.Yandere.CanMove = false;
                        this.Yandere.Mask.transform.parent = this.LeftHand;
                        this.Yandere.Mask.transform.localPosition = new Vector3(-0.1f, -0.05f, 0.0f);
                        this.Yandere.Mask.transform.localEulerAngles = new Vector3(-90f, 90f, 0.0f);
                        this.Yandere.Mask.transform.localScale = new Vector3(1f, 1f, 1f);
                      }
                      if ((double) this.CharacterAnimation["unmasking_00"].time >= (double) this.CharacterAnimation["unmasking_00"].length)
                      {
                        this.Yandere.Unmasked = true;
                        this.Yandere.ShoulderCamera.GameOver();
                        this.Yandere.Mask.Drop();
                      }
                    }
                  }
                }
                else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Fragile)
                {
                  this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
                  this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                  this.CharacterAnimation.CrossFade(this.CowardAnim);
                  this.ReactionTimer += Time.deltaTime;
                  if ((double) this.ReactionTimer > 5.0)
                  {
                    this.CurrentDestination = this.StudentManager.Exit;
                    this.Pathfinding.target = this.StudentManager.Exit;
                  }
                }
                else if (this.Persona == PersonaType.Evil)
                {
                  this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
                  this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                  this.CharacterAnimation.CrossFade(this.EvilAnim);
                  this.ReactionTimer += Time.deltaTime;
                  if ((double) this.ReactionTimer > 5.0)
                  {
                    this.CurrentDestination = this.StudentManager.Exit;
                    this.Pathfinding.target = this.StudentManager.Exit;
                  }
                }
                else if (this.Persona == PersonaType.SocialButterfly)
                {
                  if (this.ReportPhase < 4)
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
                  if (this.ReportPhase == 1)
                  {
                    if (!this.SmartPhone.activeInHierarchy)
                    {
                      if ((UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) null && !this.Police.Called)
                      {
                        this.CharacterAnimation.CrossFade(this.SocialReportAnim);
                        this.Subtitle.UpdateLabel(SubtitleType.SocialReport, 1, 5f);
                        this.StudentManager.Reporter = this;
                        this.SmartPhone.SetActive(true);
                        this.SmartPhone.transform.localPosition = new Vector3(-0.015f, -0.01f, 0.0f);
                        this.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -170f, 165f);
                      }
                      else
                        this.ReportTimer = 5f;
                    }
                    this.ReportTimer += Time.deltaTime;
                    if ((double) this.ReportTimer > 5.0)
                    {
                      if ((UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) this && !this.StudentManager.Jammed)
                      {
                        this.Police.Called = true;
                        this.Police.Show = true;
                      }
                      this.CharacterAnimation.CrossFade(this.ParanoidAnim);
                      this.SmartPhone.SetActive(false);
                      ++this.ReportPhase;
                      this.Halt = false;
                    }
                  }
                  else if (this.ReportPhase == 2)
                  {
                    if (this.WitnessedMurder && (!this.SawMask || this.SawMask && (UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null))
                      this.LookForYandere();
                  }
                  else if (this.ReportPhase == 3)
                  {
                    this.CharacterAnimation.CrossFade(this.SocialFearAnim);
                    this.Subtitle.UpdateLabel(SubtitleType.SocialFear, 1, 5f);
                    this.SpawnAlarmDisc();
                    ++this.ReportPhase;
                    this.Halt = true;
                  }
                  else if (this.ReportPhase == 4)
                  {
                    this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                    if (this.Yandere.Attacking)
                      this.LookForYandere();
                  }
                  else if (this.ReportPhase == 5)
                  {
                    this.CharacterAnimation.CrossFade(this.SocialTerrorAnim);
                    this.Subtitle.UpdateLabel(SubtitleType.SocialTerror, 1, 5f);
                    this.VisionDistance = 0.0f;
                    this.SpawnAlarmDisc();
                    ++this.ReportPhase;
                  }
                }
                else if (this.Persona == PersonaType.Lovestruck)
                {
                  if (this.ReportPhase < 3)
                  {
                    if (this.StudentManager.Students[this.LovestruckTarget].InEvent && this.StudentManager.Students[this.LovestruckTarget].Ragdoll.Zs.activeInHierarchy)
                    {
                      Debug.Log((object) "Lovestruck Target is asleep, so she needs to be woken up first.");
                      this.StudentManager.Yandere.Class.Portal.OsanaThursdayEvent.EndEvent();
                    }
                    else if (this.StudentManager.Students[this.LovestruckTarget].Fleeing)
                    {
                      Debug.Log((object) "Lovestruck Target is fleeing, so destination is being set to Exit.");
                      this.Pathfinding.target = this.StudentManager.Exit;
                      this.CurrentDestination = this.StudentManager.Exit;
                      this.ReportPhase = 3;
                    }
                  }
                  if (this.ReportPhase == 1)
                  {
                    if (!this.StudentManager.Students[this.LovestruckTarget].gameObject.activeInHierarchy || this.StudentManager.Students[this.LovestruckTarget].Ragdoll.Concealed)
                    {
                      Debug.Log((object) "A character wants to run to someone to tell them about murder, but that character is either gone or in a garbage bag.");
                      this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 5, 10f);
                      this.Pathfinding.target = this.StudentManager.Exit;
                      this.CurrentDestination = this.StudentManager.Exit;
                      this.Pathfinding.enabled = true;
                      this.ReportPhase = 3;
                    }
                    else if (!this.StudentManager.Students[this.LovestruckTarget].Alive)
                    {
                      this.CurrentDestination = this.Corpse.Student.Hips;
                      this.Pathfinding.target = this.Corpse.Student.Hips;
                      this.SpecialRivalDeathReaction = true;
                      this.WitnessRivalDiePhase = 1;
                      this.Fleeing = false;
                      this.Routine = false;
                      this.TargetDistance = 0.5f;
                    }
                    else if (this.StudentManager.Students[this.LovestruckTarget].Routine)
                    {
                      if (this.StudentManager.Students[this.LovestruckTarget].Male)
                        this.StudentManager.Students[this.LovestruckTarget].CharacterAnimation.CrossFade("surprised_00");
                      else
                        this.StudentManager.Students[this.LovestruckTarget].CharacterAnimation.CrossFade("f02_surprised_00");
                      this.StudentManager.Students[this.LovestruckTarget].EmptyHands();
                      this.CharacterAnimation.CrossFade(this.ScaredAnim);
                      this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canSearch = false;
                      this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canMove = false;
                      this.StudentManager.Students[this.LovestruckTarget].Pathfinding.enabled = false;
                      this.StudentManager.Students[this.LovestruckTarget].Investigating = false;
                      this.StudentManager.Students[this.LovestruckTarget].CheckingNote = false;
                      this.StudentManager.Students[this.LovestruckTarget].Meeting = false;
                      this.StudentManager.Students[this.LovestruckTarget].AwareOfCorpse = true;
                      this.StudentManager.Students[this.LovestruckTarget].Routine = false;
                      this.StudentManager.Students[this.LovestruckTarget].Blind = true;
                      this.Pathfinding.enabled = false;
                      if (this.WitnessedMurder && !this.SawMask)
                      {
                        this.Yandere.Jukebox.gameObject.active = false;
                        this.Yandere.MainCamera.enabled = false;
                        this.Yandere.RPGCamera.enabled = false;
                        this.Yandere.Jukebox.Volume = 0.0f;
                        this.Yandere.CanMove = false;
                        this.StudentManager.LovestruckCamera.transform.parent = this.transform;
                        this.StudentManager.LovestruckCamera.transform.localPosition = new Vector3(1f, 1f, -1f);
                        this.StudentManager.LovestruckCamera.transform.localEulerAngles = new Vector3(0.0f, -30f, 0.0f);
                        this.StudentManager.LovestruckCamera.active = true;
                      }
                      if (this.WitnessedMurder && !this.SawMask)
                        this.Subtitle.UpdateLabel(SubtitleType.LovestruckMurderReport, 0, 5f);
                      else if (this.LovestruckTarget == 1)
                        this.Subtitle.UpdateLabel(SubtitleType.LovestruckCorpseReport, 0, 5f);
                      else
                        this.Subtitle.UpdateLabel(SubtitleType.LovestruckCorpseReport, 1, 5f);
                      ++this.ReportPhase;
                    }
                    else
                      this.CharacterAnimation.CrossFade(this.ScaredAnim);
                  }
                  else if (this.ReportPhase == 2)
                  {
                    this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Students[this.LovestruckTarget].transform.position.x, this.transform.position.y, this.StudentManager.Students[this.LovestruckTarget].transform.position.z) - this.transform.position);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                    this.targetRotation = Quaternion.LookRotation(new Vector3(this.transform.position.x, this.StudentManager.Students[this.LovestruckTarget].transform.position.y, this.transform.position.z) - this.StudentManager.Students[this.LovestruckTarget].transform.position);
                    this.StudentManager.Students[this.LovestruckTarget].transform.rotation = Quaternion.Slerp(this.StudentManager.Students[this.LovestruckTarget].transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                    this.ReportTimer += Time.deltaTime;
                    if ((double) this.ReportTimer > 5.0)
                    {
                      if (this.WitnessedMurder && !this.SawMask)
                      {
                        this.Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(true);
                        this.Yandere.Police.EndOfDay.Heartbroken.Exposed = true;
                        this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
                        this.Yandere.Collapse = true;
                        this.StudentManager.StopMoving();
                        ++this.ReportPhase;
                      }
                      else
                      {
                        Debug.Log((object) "Both reporter and Lovestruck Target should be heading to the Exit.");
                        this.StudentManager.Students[this.LovestruckTarget].Pathfinding.target = this.StudentManager.Exit;
                        this.StudentManager.Students[this.LovestruckTarget].CurrentDestination = this.StudentManager.Exit;
                        this.StudentManager.Students[this.LovestruckTarget].CharacterAnimation.CrossFade(this.StudentManager.Students[this.LovestruckTarget].SprintAnim);
                        this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canSearch = true;
                        this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canMove = true;
                        this.StudentManager.Students[this.LovestruckTarget].Pathfinding.enabled = true;
                        this.StudentManager.Students[this.LovestruckTarget].Pathfinding.speed = 4f;
                        this.Pathfinding.target = this.StudentManager.Exit;
                        this.CurrentDestination = this.StudentManager.Exit;
                        this.Pathfinding.enabled = true;
                        ++this.ReportPhase;
                      }
                    }
                  }
                }
                else if (this.Persona == PersonaType.Dangerous)
                {
                  if (!this.Yandere.Attacking && !this.StudentManager.PinningDown && !this.Yandere.Struggling && !this.Yandere.Noticed && !this.Yandere.Invisible)
                  {
                    Debug.Log((object) "Calling ''Spray()'' from this part of the code. 1");
                    this.Spray();
                  }
                  else
                    this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
                }
                else if (this.Persona == PersonaType.Protective)
                {
                  if (!this.Yandere.Dumping && !this.Yandere.Attacking)
                  {
                    Debug.Log((object) "A protective student is taking down Yandere-chan.");
                    if (this.Yandere.Aiming)
                      this.Yandere.StopAiming();
                    this.Yandere.Mopping = false;
                    this.Yandere.EmptyHands();
                    this.Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
                    this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 4, 0.0f);
                    this.AttackReaction();
                    this.CharacterAnimation["f02_moCounterB_00"].time = 6f;
                    this.Yandere.CharacterAnimation["f02_moCounterA_00"].time = 6f;
                    this.Yandere.ShoulderCamera.ObstacleCounter = true;
                    this.Yandere.ShoulderCamera.Timer = 6f;
                    this.Police.Show = false;
                    this.Yandere.CameraEffects.MurderWitnessed();
                    this.Yandere.Jukebox.GameOver();
                  }
                  else
                    this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
                }
                else if (this.Persona == PersonaType.Violent)
                {
                  if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.Dumping && !this.Yandere.SneakingShot && !this.StudentManager.PinningDown && !this.RespectEarned)
                  {
                    if (!this.Yandere.DelinquentFighting)
                    {
                      Debug.Log((object) (this.Name + " is supposed to begin the combat minigame now."));
                      this.SmartPhone.SetActive(false);
                      this.Threatened = true;
                      this.Fleeing = false;
                      this.Alarmed = true;
                      this.NoTalk = false;
                      this.Patience = 0;
                    }
                  }
                  else
                    this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
                }
                else if (this.Persona == PersonaType.Strict)
                {
                  if (!this.WitnessedMurder)
                  {
                    if (this.ReportPhase == 0)
                    {
                      if (this.MyReporter.WitnessedMurder || this.MyReporter.WitnessedCorpse)
                      {
                        this.Subtitle.Speaker = this;
                        this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 0, 3f);
                        this.InvestigatingPossibleDeath = true;
                      }
                      else if (this.MyReporter.WitnessedLimb)
                      {
                        this.Subtitle.Speaker = this;
                        this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 2, 3f);
                      }
                      else if (this.MyReporter.WitnessedBloodyWeapon)
                      {
                        this.Subtitle.Speaker = this;
                        this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 3, 3f);
                      }
                      else if (this.MyReporter.WitnessedBloodPool)
                      {
                        this.Subtitle.Speaker = this;
                        this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 1, 3f);
                      }
                      else if (this.MyReporter.WitnessedWeapon)
                      {
                        this.Subtitle.Speaker = this;
                        this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 4, 3f);
                      }
                      ++this.ReportPhase;
                    }
                    else if (this.ReportPhase == 1)
                    {
                      this.CharacterAnimation.CrossFade(this.IdleAnim);
                      this.ReportTimer += Time.deltaTime;
                      if ((double) this.ReportTimer >= 3.0)
                      {
                        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
                        StudentScript studentScript = (StudentScript) null;
                        if (this.MyReporter.WitnessedMurder || this.MyReporter.WitnessedCorpse)
                          studentScript = this.StudentManager.Reporter;
                        else if (this.MyReporter.WitnessedBloodPool || this.MyReporter.WitnessedLimb || this.MyReporter.WitnessedWeapon)
                          studentScript = this.StudentManager.BloodReporter;
                        if (this.MyReporter.WitnessedLimb)
                          this.InvestigatingPossibleLimb = true;
                        if (this.MyReporter.WitnessedBloodPool)
                          this.InvestigatingPossibleBlood = true;
                        if (!studentScript.Teacher)
                        {
                          if (this.MyReporter.WitnessedMurder || this.MyReporter.WitnessedCorpse)
                          {
                            this.StudentManager.Reporter.CurrentDestination = this.StudentManager.CorpseLocation;
                            this.StudentManager.Reporter.Pathfinding.target = this.StudentManager.CorpseLocation;
                            this.CurrentDestination = this.StudentManager.CorpseLocation;
                            this.Pathfinding.target = this.StudentManager.CorpseLocation;
                            this.StudentManager.Reporter.TargetDistance = 2f;
                          }
                          else if (this.MyReporter.WitnessedBloodPool || this.MyReporter.WitnessedLimb || this.MyReporter.WitnessedWeapon)
                          {
                            Debug.Log((object) "Setting BloodReporter's destination to BloodLocation.");
                            this.StudentManager.BloodReporter.CurrentDestination = this.StudentManager.BloodLocation;
                            this.StudentManager.BloodReporter.Pathfinding.target = this.StudentManager.BloodLocation;
                            this.CurrentDestination = this.StudentManager.BloodLocation;
                            this.Pathfinding.target = this.StudentManager.BloodLocation;
                            this.StudentManager.BloodReporter.TargetDistance = 2f;
                          }
                        }
                        this.TargetDistance = 1f;
                        this.ReportTimer = 0.0f;
                        ++this.ReportPhase;
                      }
                    }
                    else if (this.ReportPhase == 2)
                    {
                      if (this.WitnessedCorpse)
                      {
                        Debug.Log((object) "A teacher has just witnessed a corpse while on their way to investigate a student's report of a corpse.");
                        this.DetermineCorpseLocation();
                        if (!this.Corpse.Poisoned)
                        {
                          this.Subtitle.Speaker = this;
                          this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 1, 5f);
                        }
                        else
                        {
                          this.Subtitle.Speaker = this;
                          this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 2, 2f);
                        }
                        ++this.ReportPhase;
                      }
                      else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
                      {
                        Debug.Log((object) ("A teacher has just witnessed an alarming object while on their way to investigate a student's report - a " + this.BloodPool.name));
                        this.DetermineBloodLocation();
                        if (!this.VerballyReacted)
                        {
                          if (this.WitnessedLimb)
                          {
                            this.Subtitle.Speaker = this;
                            this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 4, 5f);
                          }
                          else if (this.WitnessedBloodPool || this.WitnessedBloodyWeapon)
                          {
                            this.Subtitle.Speaker = this;
                            this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 3, 5f);
                          }
                          else if (this.WitnessedWeapon)
                          {
                            this.Subtitle.Speaker = this;
                            this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 5, 5f);
                          }
                        }
                        PromptScript component1 = this.BloodPool.GetComponent<PromptScript>();
                        WeaponScript component2 = this.BloodPool.GetComponent<WeaponScript>();
                        bool flag = false;
                        if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
                        {
                          if (component2.BroughtFromHome)
                          {
                            Debug.Log((object) "This weapon was brought from home!");
                            flag = true;
                          }
                          else
                            Debug.Log((object) "This weapon was not brought from home.");
                        }
                        if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && !flag)
                        {
                          Debug.Log((object) "Disabling an object's prompt.");
                          component1.Hide();
                          component1.enabled = false;
                          this.TargetDistance = 1.5f;
                        }
                        ++this.ReportPhase;
                      }
                      else
                      {
                        this.CharacterAnimation.CrossFade(this.GuardAnim);
                        if ((UnityEngine.Object) this.BloodPool == (UnityEngine.Object) null && this.StudentManager.Police.BloodParent.childCount > 0 && !this.InvestigatingPossibleLimb)
                          this.UpdateVisibleBlood();
                        this.ReportTimer += Time.deltaTime;
                        if ((double) this.ReportTimer > 5.0)
                        {
                          this.Subtitle.UpdateLabel(SubtitleType.TeacherPrankReaction, 1, 7f);
                          this.ReportPhase = 98;
                          this.ReportTimer = 0.0f;
                        }
                      }
                    }
                    else if (this.ReportPhase == 3)
                    {
                      if (this.WitnessedCorpse)
                      {
                        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, this.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - this.transform.position);
                        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                        this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                        this.CharacterAnimation.CrossFade(this.InspectAnim);
                      }
                      else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
                      {
                        if ((UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null)
                          this.targetRotation = Quaternion.LookRotation(new Vector3(this.BloodPool.transform.position.x, this.transform.position.y, this.BloodPool.transform.position.z) - this.transform.position);
                        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                        this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                        this.CharacterAnimation[this.InspectBloodAnim].speed = 0.66666f;
                        this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
                      }
                      this.ReportTimer += Time.deltaTime;
                      if ((double) this.ReportTimer >= 6.0)
                      {
                        this.ReportTimer = 0.0f;
                        if (this.WitnessedWeapon && !this.WitnessedBloodyWeapon)
                          this.ReportPhase = 7;
                        else
                          ++this.ReportPhase;
                      }
                    }
                    else if (this.ReportPhase == 4)
                    {
                      if (this.WitnessedCorpse)
                      {
                        this.Subtitle.Speaker = this;
                        this.Subtitle.UpdateLabel(SubtitleType.TeacherPoliceReport, 0, 5f);
                      }
                      else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
                      {
                        this.Subtitle.Speaker = this;
                        this.Subtitle.UpdateLabel(SubtitleType.TeacherPoliceReport, 1, 5f);
                      }
                      if (!this.StudentManager.Eighties)
                      {
                        this.SmartPhone.transform.localPosition = new Vector3(-0.01f, -0.005f, -0.02f);
                        this.SmartPhone.transform.localEulerAngles = new Vector3(-10f, -145f, 170f);
                      }
                      else
                      {
                        this.SmartPhone.transform.localPosition = new Vector3(0.0f, -0.022f, 0.0f);
                        this.SmartPhone.transform.localEulerAngles = new Vector3(90f, 45f, 0.0f);
                        this.SmartPhone.transform.localScale = new Vector3(66.66666f, 66.66666f, 66.66666f);
                      }
                      this.SmartPhone.SetActive(true);
                      ++this.ReportPhase;
                    }
                    else if (this.ReportPhase == 5)
                    {
                      this.CharacterAnimation.CrossFade(this.CallAnim);
                      this.ReportTimer += Time.deltaTime;
                      if ((double) this.ReportTimer >= 5.0)
                      {
                        this.CharacterAnimation.CrossFade(this.GuardAnim);
                        this.SmartPhone.SetActive(false);
                        this.WitnessedBloodyWeapon = false;
                        this.WitnessedBloodPool = false;
                        this.WitnessedSomething = false;
                        this.WitnessedWeapon = false;
                        this.WitnessedLimb = false;
                        this.IgnoringPettyActions = true;
                        if (!this.StudentManager.Jammed)
                        {
                          this.Police.Called = true;
                          this.Police.Show = true;
                        }
                        this.ReportTimer = 0.0f;
                        this.Guarding = true;
                        this.Alarmed = false;
                        this.Fleeing = false;
                        this.Reacted = false;
                        ++this.ReportPhase;
                        if ((UnityEngine.Object) this.MyReporter != (UnityEngine.Object) null && this.MyReporter.ReportingBlood)
                        {
                          Debug.Log((object) "The blood reporter has just been instructed to stop following the teacher.");
                          ++this.MyReporter.ReportPhase;
                        }
                      }
                    }
                    else if (this.ReportPhase != 6)
                    {
                      if (this.ReportPhase == 7)
                      {
                        if ((UnityEngine.Object) this.StudentManager.BloodReporter != (UnityEngine.Object) this)
                          this.StudentManager.BloodReporter = (StudentScript) null;
                        this.StudentManager.UpdateStudents();
                        this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = false;
                        this.BloodPool.GetComponent<WeaponScript>().Prompt.Hide();
                        this.BloodPool.GetComponent<WeaponScript>().enabled = false;
                        ++this.ReportPhase;
                      }
                      else if (this.ReportPhase == 8)
                      {
                        this.CharacterAnimation.CrossFade("f02_teacherPickUp_00");
                        if ((double) this.CharacterAnimation["f02_teacherPickUp_00"].time >= 0.33333000540733337)
                          this.Handkerchief.SetActive(true);
                        if ((double) this.CharacterAnimation["f02_teacherPickUp_00"].time >= 2.0)
                        {
                          this.BloodPool.parent = this.RightHand;
                          this.BloodPool.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                          this.BloodPool.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                          this.BloodPool.GetComponent<WeaponScript>().Returner = this;
                        }
                        if ((double) this.CharacterAnimation["f02_teacherPickUp_00"].time >= (double) this.CharacterAnimation["f02_teacherPickUp_00"].length)
                        {
                          this.CurrentDestination = this.StudentManager.WeaponBoxSpot;
                          this.Pathfinding.target = this.StudentManager.WeaponBoxSpot;
                          this.Pathfinding.speed = this.WalkSpeed;
                          this.Hurry = false;
                          ++this.ReportPhase;
                          if ((UnityEngine.Object) this.MyReporter != (UnityEngine.Object) null)
                          {
                            Debug.Log((object) "Telling reporter to go back to their normal routine.");
                            this.MyReporter.CurrentDestination = this.MyReporter.Destinations[this.MyReporter.Phase];
                            this.MyReporter.Pathfinding.target = this.MyReporter.Destinations[this.MyReporter.Phase];
                            this.MyReporter.Pathfinding.speed = 1f;
                            this.MyReporter.ReportTimer = 0.0f;
                            this.MyReporter.AlarmTimer = 0.0f;
                            this.MyReporter.TargetDistance = 1f;
                            this.MyReporter.ReportPhase = 0;
                            this.MyReporter.WitnessedSomething = false;
                            this.MyReporter.WitnessedWeapon = false;
                            this.MyReporter.Distracted = false;
                            this.MyReporter.Reacted = false;
                            this.MyReporter.Alarmed = false;
                            this.MyReporter.Fleeing = false;
                            this.MyReporter.Routine = true;
                            this.MyReporter.Halt = false;
                            this.MyReporter.Persona = this.MyReporter.OriginalPersona;
                            this.MyReporter.BloodPool = (Transform) null;
                            if (this.MyReporter.Club == ClubType.Council)
                              this.MyReporter.Persona = PersonaType.Dangerous;
                            for (this.ID = 0; this.ID < this.MyReporter.Outlines.Length; ++this.ID)
                            {
                              if ((UnityEngine.Object) this.MyReporter.Outlines[this.ID] != (UnityEngine.Object) null)
                                this.MyReporter.Outlines[this.ID].color = new Color(1f, 1f, 0.0f, 1f);
                            }
                            if (this.MyReporter.BeforeReturnAnim != "")
                              this.MyReporter.WalkAnim = this.MyReporter.BeforeReturnAnim;
                          }
                        }
                      }
                      else if (this.ReportPhase == 9)
                      {
                        this.StudentManager.BloodLocation.position = Vector3.zero;
                        this.BloodPool.parent = (Transform) null;
                        this.BloodPool.position = this.StudentManager.WeaponBoxSpot.parent.position + new Vector3(0.0f, 1f, 0.0f);
                        this.BloodPool.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
                        this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = true;
                        this.BloodPool.GetComponent<WeaponScript>().Returner = (StudentScript) null;
                        this.BloodPool.GetComponent<WeaponScript>().enabled = true;
                        this.BloodPool.GetComponent<WeaponScript>().Drop();
                        this.BloodPool = (Transform) null;
                        this.CharacterAnimation.CrossFade(this.RunAnim);
                        this.CurrentDestination = this.Destinations[this.Phase];
                        this.Pathfinding.target = this.Destinations[this.Phase];
                        this.Handkerchief.SetActive(false);
                        this.StopInvestigating();
                        this.Pathfinding.canSearch = true;
                        this.Pathfinding.canMove = true;
                        this.Pathfinding.speed = this.WalkSpeed;
                        this.WitnessedSomething = false;
                        this.VerballyReacted = false;
                        this.WitnessedWeapon = false;
                        this.YandereInnocent = false;
                        this.ReportingBlood = false;
                        this.Distracted = false;
                        this.Alarmed = false;
                        this.Fleeing = false;
                        this.Routine = true;
                        this.Halt = false;
                        this.ReportTimer = 0.0f;
                        this.ReportPhase = 0;
                      }
                      else if (this.ReportPhase == 98)
                      {
                        this.CharacterAnimation.CrossFade(this.IdleAnim);
                        this.targetRotation = Quaternion.LookRotation(this.MyReporter.transform.position - this.transform.position);
                        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                        this.ReportTimer += Time.deltaTime;
                        if ((double) this.ReportTimer > 7.0)
                          ++this.ReportPhase;
                      }
                      else if (this.ReportPhase == 99)
                      {
                        this.CharacterAnimation.CrossFade(this.RunAnim);
                        this.CurrentDestination = this.Destinations[this.Phase];
                        this.Pathfinding.target = this.Destinations[this.Phase];
                        this.Pathfinding.canSearch = true;
                        this.Pathfinding.canMove = true;
                        this.MyReporter.Persona = PersonaType.TeachersPet;
                        this.MyReporter.ReportPhase = 100;
                        this.MyReporter.Fleeing = true;
                        this.ReportTimer = 0.0f;
                        this.ReportPhase = 0;
                        this.InvestigatingPossibleBlood = false;
                        this.InvestigatingPossibleDeath = false;
                        this.InvestigatingPossibleLimb = false;
                        this.Alarmed = false;
                        this.Fleeing = false;
                        this.Routine = true;
                      }
                    }
                  }
                  else if (!this.Yandere.Dumping && !this.Yandere.Attacking)
                  {
                    if (this.Yandere.Armed && this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus > 0 && this.Yandere.EquippedWeapon.Type == WeaponType.Knife || this.Yandere.Club == ClubType.MartialArts && this.Yandere.Armed && this.Yandere.EquippedWeapon.Type == WeaponType.Knife)
                    {
                      Debug.Log((object) "Yandere-chan is in a state that allows her to enter struggles with teachers, so this teacher is changing into the ''Heroic'' Persona to have a struggle.");
                      this.Persona = PersonaType.Heroic;
                    }
                    else
                    {
                      Debug.Log((object) "A teacher is taking down Yandere-chan.");
                      if (this.Yandere.Aiming)
                        this.Yandere.StopAiming();
                      this.Yandere.Mopping = false;
                      this.Yandere.EmptyHands();
                      this.AttackReaction();
                      this.CharacterAnimation[this.CounterAnim].time = 5f;
                      this.Yandere.CharacterAnimation["f02_teacherCounterA_00"].time = 5f;
                      this.Yandere.ShoulderCamera.Timer = 5f;
                      this.Yandere.ShoulderCamera.Phase = 3;
                      this.Police.Show = false;
                      this.Yandere.CameraEffects.MurderWitnessed();
                      this.Yandere.Jukebox.GameOver();
                    }
                  }
                  else
                    this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
                }
                else if (this.Persona == PersonaType.LandlineUser)
                {
                  if (this.ReportPhase == 1)
                  {
                    if ((UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) null && !this.Police.Called)
                    {
                      this.Subtitle.UpdateLabel(SubtitleType.SocialReport, 1, 5f);
                      this.CharacterAnimation.CrossFade(this.LandLineAnim);
                      this.StudentManager.Reporter = this;
                      this.SpawnAlarmDisc();
                      ++this.ReportPhase;
                    }
                    else
                    {
                      this.CharacterAnimation.CrossFade(this.ParanoidAnim);
                      this.ReportPhase += 2;
                      this.Halt = true;
                    }
                  }
                  else if (this.ReportPhase == 2)
                  {
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
                    this.StudentManager.LandLinePhone.SetBlendShapeWeight(1, this.ReportTimer * 200f);
                    this.ReportTimer += Time.deltaTime;
                    if ((double) this.ReportTimer > 5.0)
                    {
                      if ((UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) this)
                      {
                        this.StudentManager.LandLinePhone.SetBlendShapeWeight(1, 0.0f);
                        if (!this.StudentManager.Jammed)
                        {
                          this.Police.Called = true;
                          this.Police.Show = true;
                        }
                      }
                      UnityEngine.Object.Instantiate<GameObject>(this.EnterGuardStateCollider, this.transform.position, Quaternion.identity);
                      this.CharacterAnimation.CrossFade(this.ParanoidAnim);
                      ++this.ReportPhase;
                    }
                  }
                  else if (this.ReportPhase == 3)
                  {
                    if (this.WitnessedMurder && (!this.SawMask || this.SawMask && (UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null))
                      this.LookForYandere();
                  }
                  else if (this.ReportPhase == 4)
                  {
                    this.CharacterAnimation.CrossFade(this.SocialFearAnim);
                    this.Subtitle.UpdateLabel(SubtitleType.SocialFear, 1, 5f);
                    this.SpawnAlarmDisc();
                    ++this.ReportPhase;
                    this.Halt = true;
                  }
                  else if (this.ReportPhase == 5)
                  {
                    this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                    if (this.Yandere.Attacking)
                      this.LookForYandere();
                  }
                  else if (this.ReportPhase == 6)
                  {
                    this.CharacterAnimation.CrossFade(this.SocialTerrorAnim);
                    this.Subtitle.UpdateLabel(SubtitleType.SocialTerror, 1, 5f);
                    this.VisionDistance = 0.0f;
                    this.SpawnAlarmDisc();
                    ++this.ReportPhase;
                  }
                }
              }
              if (this.Persona == PersonaType.Strict && (UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null && (UnityEngine.Object) this.BloodPool.parent == (UnityEngine.Object) this.Yandere.RightHand)
              {
                Debug.Log((object) "Yandere-chan picked up the weapon that the teacher was investigating!");
                this.WitnessedBloodyWeapon = false;
                this.WitnessedBloodPool = false;
                this.WitnessedSomething = false;
                this.WitnessedCorpse = false;
                this.WitnessedMurder = false;
                this.WitnessedWeapon = false;
                this.WitnessedLimb = false;
                this.YandereVisible = true;
                this.ReportTimer = 0.0f;
                this.BloodPool = (Transform) null;
                this.ReportPhase = 0;
                this.Alarmed = false;
                this.Fleeing = false;
                this.Routine = true;
                this.Reacted = false;
                this.AlarmTimer = 0.0f;
                this.Alarm = 200f;
                this.BecomeAlarmed();
              }
            }
          }
          else if (this.PinPhase == 0)
          {
            if ((double) this.DistanceToDestination < 1.0)
            {
              if (this.Pathfinding.canSearch)
              {
                this.Pathfinding.canSearch = false;
                this.Pathfinding.canMove = false;
              }
              this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
              this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
              this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
              this.MoveTowardsTarget(this.CurrentDestination.position);
            }
            else
            {
              this.CharacterAnimation.CrossFade(this.SprintAnim);
              if (!this.Pathfinding.canSearch)
              {
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
              }
            }
          }
          else
          {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
            this.MoveTowardsTarget(this.CurrentDestination.position);
          }
        }
      }
      if (this.Following && !this.Waiting)
      {
        this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
        if ((double) this.DistanceToDestination > 2.0)
        {
          this.CharacterAnimation.CrossFade(this.RunAnim);
          this.Pathfinding.speed = 4f;
          this.Obstacle.enabled = false;
        }
        else if ((double) this.DistanceToDestination > 1.0)
        {
          this.CharacterAnimation.CrossFade(this.OriginalWalkAnim);
          this.Pathfinding.canMove = true;
          this.Obstacle.enabled = false;
          this.Pathfinding.speed = this.WalkSpeed;
        }
        else
        {
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.Pathfinding.canMove = false;
          this.Obstacle.enabled = true;
        }
        if (this.Phase < this.ScheduleBlocks.Length && ((double) this.FollowCountdown.Sprite.fillAmount == 0.0 || (double) this.Clock.HourTime >= (double) this.ScheduleBlocks[this.Phase].time || this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.IncineratorArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.HeadmasterArea.bounds.Contains(this.Yandere.transform.position) || this.Yandere.Class.Portal.Transition || this.Yandere.TimeSkipping || this.Yandere.Trespassing))
        {
          if ((double) this.Clock.HourTime >= (double) this.ScheduleBlocks[this.Phase].time)
            ++this.Phase;
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.Hearts.emission.enabled = false;
          this.FollowCountdown.gameObject.SetActive(false);
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Yandere.Follower = (StudentScript) null;
          --this.Yandere.Followers;
          this.Following = false;
          this.Routine = true;
          this.Pathfinding.speed = this.WalkSpeed;
          if (this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.IncineratorArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.HeadmasterArea.bounds.Contains(this.Yandere.transform.position) || this.Yandere.Trespassing)
            this.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 1, 3f);
          else if (this.Yandere.TimeSkipping)
          {
            this.Subtitle.CustomText = "If you're just going to stand there spacing out, I'm leaving...";
            this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 10f);
          }
          else
            this.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
          this.Prompt.Label[0].text = "     Talk";
        }
      }
      if (this.Wet)
      {
        if ((double) this.DistanceToDestination < (double) this.TargetDistance)
        {
          if (!this.Splashed)
          {
            if (!this.InDarkness)
            {
              if (this.NotActuallyWet && this.BathePhase < 5)
                this.BathePhase = 5;
              if (this.BathePhase == 1)
              {
                this.CharacterAnimation[this.WetAnim].weight = 0.0f;
                this.StudentManager.CommunalLocker.Open = true;
                this.StudentManager.CommunalLocker.Student = this;
                this.StudentManager.CommunalLocker.SpawnSteam();
                this.Pathfinding.speed = this.WalkSpeed;
                this.Schoolwear = 0;
                ++this.BathePhase;
                this.Distracted = true;
              }
              else if (this.BathePhase == 2)
              {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
                this.MoveTowardsTarget(this.CurrentDestination.position);
                if (this.Club == ClubType.Cooking && this.ApronAttacher.newRenderer.enabled)
                  this.ApronAttacher.newRenderer.enabled = false;
              }
              else if (this.BathePhase == 3)
              {
                this.StudentManager.CommunalLocker.Open = false;
                this.CharacterAnimation.CrossFade(this.WalkAnim);
                if (!this.BatheFast)
                {
                  if (!this.Male)
                  {
                    this.CurrentDestination = this.StudentManager.FemaleBatheSpot;
                    this.Pathfinding.target = this.StudentManager.FemaleBatheSpot;
                  }
                  else
                  {
                    this.CurrentDestination = this.StudentManager.MaleBatheSpot;
                    this.Pathfinding.target = this.StudentManager.MaleBatheSpot;
                  }
                }
                else if (!this.Male)
                {
                  this.CurrentDestination = this.StudentManager.FastBatheSpot;
                  this.Pathfinding.target = this.StudentManager.FastBatheSpot;
                }
                else
                {
                  this.CurrentDestination = this.StudentManager.MaleBatheSpot;
                  this.Pathfinding.target = this.StudentManager.MaleBatheSpot;
                }
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                ++this.BathePhase;
              }
              else if (this.BathePhase == 4)
              {
                if (!this.Male)
                {
                  this.StudentManager.OpenValue = Mathf.Lerp(this.StudentManager.OpenValue, 0.0f, Time.deltaTime * 10f);
                  this.StudentManager.FemaleShowerCurtain.SetBlendShapeWeight(1, this.StudentManager.OpenValue);
                }
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
                this.MoveTowardsTarget(this.CurrentDestination.position);
                this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                this.CharacterAnimation.CrossFade(this.BathingAnim);
                if ((double) this.CharacterAnimation[this.BathingAnim].time >= (double) this.CharacterAnimation[this.BathingAnim].length)
                {
                  this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                  if (!this.Male)
                    this.StudentManager.OpenCurtain = true;
                  this.LiquidProjector.enabled = false;
                  this.Bloody = false;
                  ++this.BathePhase;
                  this.Gas = false;
                  this.GoChange();
                  this.UnWet();
                }
              }
              else if (this.BathePhase == 5)
              {
                this.StudentManager.CommunalLocker.Open = true;
                this.StudentManager.CommunalLocker.Student = this;
                this.StudentManager.CommunalLocker.SpawnSteam();
                this.Schoolwear = this.InEvent ? 1 : 3;
                if (this.NotActuallyWet)
                {
                  this.Schoolwear = 1;
                  if ((UnityEngine.Object) this.Follower != (UnityEngine.Object) null && (UnityEngine.Object) this.Follower.FollowTarget != (UnityEngine.Object) null && this.Follower.CurrentAction == StudentActionType.Sunbathe)
                  {
                    this.Follower.Schoolwear = 1;
                    this.Follower.ChangeSchoolwear();
                    this.Follower.CurrentAction = StudentActionType.Follow;
                  }
                }
                Debug.Log((object) "Time to decide if a special case applies to this character.");
                if (this.Club == ClubType.Sports && this.Clock.Period > 5 && !this.StudentManager.PoolClosed)
                {
                  Debug.Log((object) "Sports Club special case! Swimsuit!");
                  this.Schoolwear = 2;
                }
                ++this.BathePhase;
              }
              else if (this.BathePhase == 6)
              {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
                this.MoveTowardsTarget(this.CurrentDestination.position);
                if (this.Club == ClubType.Cooking && !this.ApronAttacher.newRenderer.enabled)
                {
                  this.ApronAttacher.newRenderer.enabled = true;
                  Debug.Log((object) "We are being told to re-enable this apron attacher...");
                }
              }
              else if (this.BathePhase == 7)
              {
                if (!this.Yandere.Inventory.Ring)
                  this.StudentManager.CommunalLocker.Rings.gameObject.SetActive(false);
                if (this.StudentManager.CommunalLocker.RivalPhone.Stolen && this.Yandere.Inventory.RivalPhoneID == this.StudentID)
                {
                  this.CharacterAnimation.CrossFade("f02_losingPhone_00");
                  this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 1, 5f);
                  this.RealizePhoneIsMissing();
                  this.Phoneless = true;
                  this.BatheTimer = 6f;
                  ++this.BathePhase;
                }
                else
                {
                  this.StudentManager.CommunalLocker.RivalPhone.gameObject.SetActive(false);
                  ++this.BathePhase;
                }
              }
              else if (this.BathePhase == 8)
              {
                if ((double) this.BatheTimer == 0.0)
                  ++this.BathePhase;
                else
                  this.BatheTimer = Mathf.MoveTowards(this.BatheTimer, 0.0f, Time.deltaTime);
              }
              else if (this.BathePhase == 9)
              {
                if (this.StudentManager.Eighties && this.StudentID == 30 && this.StudentManager.CommunalLocker.Rings.Stolen || !this.StudentManager.Eighties && this.StudentID == 2 && this.StudentManager.CommunalLocker.Rings.Stolen)
                {
                  this.CharacterAnimation.CrossFade("f02_losingPhone_00");
                  this.Subtitle.CustomText = !this.StudentManager.Eighties ? "Huh? My ring is missing...did someone take it?" : "Huh? One of my rings is missing...did someone steal it?!";
                  this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                  this.Depressed = true;
                  this.BatheTimer = 6f;
                  ++this.BathePhase;
                }
                else
                {
                  if (!this.StudentManager.Eighties && this.StudentID == 2)
                    this.Cosmetic.FemaleAccessories[this.Cosmetic.Accessory].SetActive(true);
                  else if (this.StudentManager.Eighties && this.StudentID == 30)
                    this.Cosmetic.EnableRings();
                  ++this.BathePhase;
                }
              }
              else if (this.BathePhase == 10)
              {
                if ((double) this.BatheTimer == 0.0)
                  ++this.BathePhase;
                else
                  this.BatheTimer = Mathf.MoveTowards(this.BatheTimer, 0.0f, Time.deltaTime);
              }
              else if (this.BathePhase == 11)
              {
                this.CharacterAnimation[this.WetAnim].weight = 0.0f;
                if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
                {
                  this.SmartPhone.SetActive(true);
                }
                else
                {
                  this.WalkAnim = this.OriginalOriginalWalkAnim;
                  this.RunAnim = this.OriginalSprintAnim;
                  this.IdleAnim = this.OriginalIdleAnim;
                }
                this.StudentManager.CommunalLocker.Student = (StudentScript) null;
                this.StudentManager.CommunalLocker.Open = false;
                if (this.Phase == 1)
                  ++this.Phase;
                if (this.Club == ClubType.Sports && this.Clock.Period > 4 && !this.StudentManager.PoolClosed)
                {
                  this.ChangeClubwear();
                  this.DressCode = true;
                }
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                this.DistanceToDestination = 100f;
                this.Routine = true;
                this.Wet = false;
                if (this.FleeWhenClean)
                {
                  this.CurrentDestination = this.StudentManager.Exit;
                  this.Pathfinding.target = this.StudentManager.Exit;
                  this.TargetDistance = 0.0f;
                  this.Routine = false;
                  this.Fleeing = true;
                }
                else
                  this.Hurry = false;
                if (!this.StudentManager.Eighties && this.Phoneless)
                {
                  this.SprintAnim = this.OriginalOriginalSprintAnim;
                  this.RunAnim = this.OriginalOriginalSprintAnim;
                  this.Pathfinding.speed = 4f;
                  this.Hurry = true;
                }
                if (this.CurrentAction == StudentActionType.PhotoShoot || this.CurrentAction == StudentActionType.GravurePose)
                  this.Hurry = false;
              }
            }
            else if (this.BathePhase == -1)
            {
              this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
              this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 2, 5f);
              this.CharacterAnimation.CrossFade("f02_electrocution_00");
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              this.Distracted = true;
              ++this.BathePhase;
            }
            else if (this.BathePhase == 0)
            {
              this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
              this.MoveTowardsTarget(this.CurrentDestination.position);
              if ((double) this.CharacterAnimation["f02_electrocution_00"].time > 2.0 && (double) this.CharacterAnimation["f02_electrocution_00"].time < 5.9500002861022949)
              {
                if (!this.LightSwitch.Panel.useGravity)
                {
                  if (!this.Bloody)
                  {
                    this.Subtitle.Speaker = this;
                    this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
                  }
                  else
                  {
                    this.Subtitle.Speaker = this;
                    this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
                  }
                  this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
                  this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
                  Debug.Log((object) "Sprinting becasue bathing.");
                  this.Pathfinding.canSearch = true;
                  this.Pathfinding.canMove = true;
                  this.Pathfinding.speed = 4f;
                  this.CharacterAnimation.CrossFade(this.WalkAnim);
                  ++this.BathePhase;
                  this.LightSwitch.Prompt.Label[0].text = "     Turn Off";
                  this.LightSwitch.BathroomLight.SetActive(true);
                  this.LightSwitch.GetComponent<AudioSource>().clip = this.LightSwitch.Flick[0];
                  this.LightSwitch.GetComponent<AudioSource>().Play();
                  this.InDarkness = false;
                }
                else
                {
                  if (!this.LightSwitch.Flicker)
                  {
                    this.CharacterAnimation["f02_electrocution_00"].speed = 0.85f;
                    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LightSwitch.Electricity, this.transform.position, Quaternion.identity);
                    gameObject.transform.parent = this.Bones[1].transform;
                    gameObject.transform.localPosition = Vector3.zero;
                    this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 3, 0.0f);
                    this.LightSwitch.GetComponent<AudioSource>().clip = this.LightSwitch.Flick[2];
                    this.LightSwitch.Flicker = true;
                    this.LightSwitch.GetComponent<AudioSource>().Play();
                    this.EyeShrink = 1f;
                    this.ElectroSteam[0].SetActive(true);
                    this.ElectroSteam[1].SetActive(true);
                    this.ElectroSteam[2].SetActive(true);
                    this.ElectroSteam[3].SetActive(true);
                  }
                  this.RightDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
                  this.LeftDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
                  this.ElectroTimer += Time.deltaTime;
                  if ((double) this.ElectroTimer > 0.10000000149011612)
                  {
                    this.ElectroTimer = 0.0f;
                    if (this.MyRenderer.enabled)
                      this.Spook();
                    else
                      this.Unspook();
                  }
                }
              }
              else if ((double) this.CharacterAnimation["f02_electrocution_00"].time > 5.9500002861022949 && (double) this.CharacterAnimation["f02_electrocution_00"].time < (double) this.CharacterAnimation["f02_electrocution_00"].length)
              {
                if (this.LightSwitch.Flicker)
                {
                  this.CharacterAnimation["f02_electrocution_00"].speed = 1f;
                  this.Prompt.Label[0].text = "     Turn Off";
                  this.LightSwitch.BathroomLight.SetActive(true);
                  this.RightDrill.localEulerAngles = new Vector3(0.0f, 0.0f, 68.30447f);
                  this.LeftDrill.localEulerAngles = new Vector3(0.0f, -180f, -159.417f);
                  this.LightSwitch.Flicker = false;
                  this.Unspook();
                  this.UnWet();
                }
              }
              else if ((double) this.CharacterAnimation["f02_electrocution_00"].time >= (double) this.CharacterAnimation["f02_electrocution_00"].length)
              {
                this.Police.ElectrocutedStudentName = this.Name;
                this.Police.ElectroScene = true;
                this.Electrocuted = true;
                this.BecomeRagdoll();
                this.DeathType = DeathType.Electrocution;
              }
            }
          }
        }
        else if (this.Pathfinding.canMove)
        {
          if (this.BathePhase == 1 || this.FleeWhenClean)
          {
            if (!this.NotActuallyWet)
            {
              if (!this.WitnessedCorpse)
              {
                this.CharacterAnimation[this.WetAnim].weight = 1f;
                this.CharacterAnimation.Play(this.WetAnim);
              }
              this.Pathfinding.speed = 4f;
              if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
                this.CharacterAnimation.CrossFade(this.OriginalSprintAnim);
              else
                this.CharacterAnimation.CrossFade(this.SprintAnim);
            }
            else
              this.CharacterAnimation.CrossFade(this.WalkAnim);
          }
          else
          {
            if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
              this.CharacterAnimation.CrossFade(this.OriginalWalkAnim);
            else
              this.CharacterAnimation.CrossFade(this.WalkAnim);
            this.Pathfinding.speed = this.WalkSpeed;
          }
        }
      }
      if (this.Distracting)
      {
        if ((UnityEngine.Object) this.DistractionTarget == (UnityEngine.Object) null)
          this.Distracting = false;
        else if (this.DistractionTarget.Dying)
        {
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.DistractionTarget.TargetedForDistraction = false;
          this.DistractionTarget.Distracted = false;
          this.DistractionTarget.EmptyHands();
          this.Pathfinding.speed = this.WalkSpeed;
          this.Distracting = false;
          this.Distracted = false;
          this.CanTalk = true;
          this.Routine = true;
        }
        else
        {
          if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0 && this.DistractionTarget.InEvent)
            this.GetFoodTarget();
          if ((double) this.DistanceToDestination < 5.0 || this.DistractionTarget.Leaving)
          {
            if (this.DistractionTarget.HelpOffered || this.DistractionTarget.InEvent || this.DistractionTarget.Talking || this.DistractionTarget.Following || this.DistractionTarget.TurnOffRadio || this.DistractionTarget.Splashed || this.DistractionTarget.Shoving || this.DistractionTarget.Spraying || this.DistractionTarget.FocusOnYandere || this.DistractionTarget.ShoeRemoval.enabled || this.DistractionTarget.Posing || this.DistractionTarget.ClubActivityPhase >= 16 || !this.DistractionTarget.enabled || this.DistractionTarget.Alarmed || this.DistractionTarget.Fleeing || this.DistractionTarget.Wet || this.DistractionTarget.EatingSnack || this.DistractionTarget.MyBento.Tampered || this.DistractionTarget.Meeting || this.DistractionTarget.Sedated || this.DistractionTarget.Sleepy || this.DistractionTarget.InvestigatingBloodPool || this.DistractionTarget.ReturningMisplacedWeapon || this.StudentManager.LockerRoomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.MaleLockerRoomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.HeadmasterArea.bounds.Contains(this.DistractionTarget.transform.position) || this.DistractionTarget.Actions[this.DistractionTarget.Phase] == StudentActionType.Bully && (double) this.DistractionTarget.DistanceToDestination < 1.0 || this.DistractionTarget.Leaving || this.DistractionTarget.CameraReacting || (UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand && this.DistractionTarget.AlreadyFed)
            {
              this.CurrentDestination = this.Destinations[this.Phase];
              this.Pathfinding.target = this.Destinations[this.Phase];
              this.DistractionTarget.TargetedForDistraction = false;
              this.Distracting = false;
              this.Distracted = false;
              this.SpeechLines.Stop();
              this.CanTalk = true;
              this.Routine = true;
              this.Pathfinding.speed = this.WalkSpeed;
              if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
                this.GetFoodTarget();
            }
            else if ((double) this.DistanceToDestination < (double) this.TargetDistance)
            {
              if (!this.DistractionTarget.Distracted)
              {
                if (this.StudentID > 1 && this.DistractionTarget.StudentID > 1 && this.Persona != PersonaType.Fragile && this.DistractionTarget.Persona != PersonaType.Fragile && (this.Club != ClubType.Bully && this.DistractionTarget.Club == ClubType.Bully || this.Club == ClubType.Bully && this.DistractionTarget.Club != ClubType.Bully))
                  this.BullyPhotoCollider.SetActive(true);
                if (this.DistractionTarget.Investigating)
                  this.DistractionTarget.StopInvestigating();
                this.StudentManager.UpdateStudents(this.DistractionTarget.StudentID);
                this.DistractionTarget.Pathfinding.canSearch = false;
                this.DistractionTarget.Pathfinding.canMove = false;
                this.DistractionTarget.OccultBook.SetActive(false);
                this.DistractionTarget.SmartPhone.SetActive(false);
                this.DistractionTarget.Distraction = this.transform;
                this.DistractionTarget.CameraReacting = false;
                this.DistractionTarget.Pathfinding.speed = 0.0f;
                this.DistractionTarget.Pen.SetActive(false);
                this.DistractionTarget.Drownable = false;
                this.DistractionTarget.Distracted = true;
                this.DistractionTarget.Pushable = false;
                this.DistractionTarget.Routine = false;
                this.DistractionTarget.CanTalk = false;
                this.DistractionTarget.ReadPhase = 0;
                this.DistractionTarget.SpeechLines.Stop();
                this.DistractionTarget.ChalkDust.Stop();
                this.DistractionTarget.CleanTimer = 0.0f;
                this.DistractionTarget.EmptyHands();
                this.DistractionTarget.Distractor = this;
                this.Pathfinding.speed = 0.0f;
                this.Distracted = true;
              }
              this.targetRotation = Quaternion.LookRotation(new Vector3(this.DistractionTarget.transform.position.x, this.transform.position.y, this.DistractionTarget.transform.position.z) - this.transform.position);
              this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
              if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
              {
                this.CharacterAnimation.CrossFade(this.IdleAnim);
              }
              else
              {
                this.DistractionTarget.SpeechLines.Play();
                this.SpeechLines.Play();
                this.CharacterAnimation.CrossFade(this.RandomAnim);
                if ((double) this.CharacterAnimation[this.RandomAnim].time >= (double) this.CharacterAnimation[this.RandomAnim].length)
                  this.PickRandomAnim();
              }
              this.DistractTimer -= Time.deltaTime;
              if ((double) this.DistractTimer <= 0.0 && this.Yandere.CanMove)
              {
                if (this.DistractionTarget.SunbathePhase == 0)
                {
                  this.DistractionTarget.CurrentDestination = this.DistractionTarget.Destinations[this.DistractionTarget.Phase];
                  this.DistractionTarget.Pathfinding.target = this.DistractionTarget.Destinations[this.DistractionTarget.Phase];
                }
                else
                {
                  this.DistractionTarget.CurrentDestination = this.StudentManager.SunbatheSpots[this.DistractionTarget.StudentID];
                  this.DistractionTarget.Pathfinding.target = this.StudentManager.SunbatheSpots[this.DistractionTarget.StudentID];
                  Debug.Log((object) (this.DistractionTarget.Name + " was sunbathing at the time of being distracted, and should be returning to their sunbathing spot now."));
                  this.DistractionTarget.SunbathePhase = 2;
                }
                this.DistractionTarget.TargetedForDistraction = false;
                this.DistractionTarget.Pathfinding.canSearch = true;
                this.DistractionTarget.Pathfinding.canMove = true;
                this.DistractionTarget.Pathfinding.speed = 1f;
                this.DistractionTarget.Octodog.SetActive(false);
                this.DistractionTarget.Distraction = (Transform) null;
                this.DistractionTarget.Distracted = false;
                this.DistractionTarget.CanTalk = true;
                this.DistractionTarget.Routine = true;
                this.DistractionTarget.EquipCleaningItems();
                this.DistractionTarget.EatingSnack = false;
                this.Private = false;
                if (this.DistractionTarget.Persona == PersonaType.PhoneAddict)
                  this.DistractionTarget.SmartPhone.SetActive(true);
                this.DistractionTarget.Distractor = (StudentScript) null;
                this.DistractionTarget.SpeechLines.Stop();
                this.SpeechLines.Stop();
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.BullyPhotoCollider.SetActive(false);
                this.Pathfinding.speed = this.WalkSpeed;
                this.Distracting = false;
                this.Distracted = false;
                this.CanTalk = true;
                this.Routine = true;
                if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
                {
                  this.DistractionTarget.AlreadyFed = true;
                  this.GetFoodTarget();
                }
                if (this.StudentID == this.StudentManager.SuitorID && this.StudentManager.DatingMinigame.SuitorAndRivalTalking)
                {
                  Debug.Log((object) "Fire ''CalculateLove()''");
                  this.StudentManager.LoveManager.Courted = true;
                  this.DialogueWheel.AdviceWindow.CalculateLove();
                  this.StudentManager.DatingMinigame.SuitorAndRivalTalking = false;
                  this.Yandere.PromptParent.gameObject.SetActive(false);
                }
              }
            }
            else if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
            {
              this.CharacterAnimation.CrossFade(this.WalkAnim);
              this.Pathfinding.canSearch = true;
              this.Pathfinding.canMove = true;
            }
            else if ((double) this.Pathfinding.speed == (double) this.WalkSpeed)
              this.CharacterAnimation.CrossFade(this.WalkAnim);
            else
              this.CharacterAnimation.CrossFade(this.SprintAnim);
          }
          else if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
          {
            this.CharacterAnimation.CrossFade(this.WalkAnim);
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            if (this.Phase < this.ScheduleBlocks.Length - 1 && (double) this.Clock.HourTime >= (double) this.ScheduleBlocks[this.Phase].time)
              this.Routine = true;
          }
          else if ((double) this.Pathfinding.speed == (double) this.WalkSpeed)
            this.CharacterAnimation.CrossFade(this.WalkAnim);
          else
            this.CharacterAnimation.CrossFade(this.SprintAnim);
        }
      }
      if (this.Hunting)
      {
        this.HuntTimer += Time.deltaTime;
        if ((double) this.HuntTimer > 1.0)
        {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity);
          gameObject.GetComponent<AlarmDiscScript>().Originator = this;
          gameObject.GetComponent<AlarmDiscScript>().Shocking = true;
          gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
          gameObject.GetComponent<AlarmDiscScript>().Silent = true;
          this.HuntTimer = 0.0f;
        }
        if ((UnityEngine.Object) this.HuntTarget != (UnityEngine.Object) null)
        {
          if (this.HuntTarget.Prompt.enabled && !this.HuntTarget.FightingSlave)
          {
            this.HuntTarget.Prompt.Hide();
            this.HuntTarget.Prompt.enabled = false;
          }
          this.Pathfinding.target = this.HuntTarget.transform;
          this.CurrentDestination = this.HuntTarget.transform;
          this.DistanceToDestination = Vector3.Distance(this.transform.position, this.HuntTarget.transform.position);
          if (this.HuntTarget.Alive && !this.HuntTarget.Tranquil && !this.HuntTarget.PinningDown)
          {
            if ((double) this.DistanceToDestination > (double) this.TargetDistance)
            {
              if (this.MurderSuicidePhase == 0)
              {
                if ((double) this.CharacterAnimation["f02_brokenStandUp_00"].time >= (double) this.CharacterAnimation["f02_brokenStandUp_00"].length)
                {
                  ++this.MurderSuicidePhase;
                  this.Pathfinding.canSearch = true;
                  this.Pathfinding.canMove = true;
                  this.CharacterAnimation.CrossFade(this.WalkAnim);
                  this.Pathfinding.speed = 1.15f;
                }
              }
              else if (this.MurderSuicidePhase == 1)
              {
                this.CharacterAnimation.CrossFade(this.WalkAnim);
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
              }
              else if (this.MurderSuicidePhase > 1)
              {
                this.CharacterAnimation.CrossFade(this.WalkAnim);
                this.HuntTarget.MoveTowardsTarget(this.transform.position + this.transform.forward * 0.01f);
              }
              if (this.HuntTarget.Dying || this.HuntTarget.Struggling || this.HuntTarget.Ragdoll.enabled || (UnityEngine.Object) this.HuntTarget.Hunter != (UnityEngine.Object) null && (UnityEngine.Object) this.HuntTarget.Hunter != (UnityEngine.Object) this)
              {
                this.Hunting = false;
                this.Suicide = true;
              }
            }
            else if (this.HuntTarget.ClubActivityPhase >= 16 || this.HuntTarget.Shoving || this.HuntTarget.ChangingShoes || this.HuntTarget.Chasing || (UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) this.HuntTarget || this.HuntTarget.SeekingMedicine || (UnityEngine.Object) this.StudentManager.CombatMinigame.Delinquent == (UnityEngine.Object) this.HuntTarget && this.StudentManager.CombatMinigame.Path == 5)
            {
              Debug.Log((object) "The mind-broken slave has to wait for something...");
              this.CharacterAnimation.CrossFade(this.IdleAnim);
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
            }
            else
            {
              if (!this.Broken.Done)
              {
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
              }
              if (!this.NEStairs.bounds.Contains(this.transform.position) && !this.NWStairs.bounds.Contains(this.transform.position) && !this.SEStairs.bounds.Contains(this.transform.position) && !this.SWStairs.bounds.Contains(this.transform.position) && !this.NEStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.NWStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.SEStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.SWStairs.bounds.Contains(this.HuntTarget.transform.position))
              {
                if (this.Pathfinding.canMove)
                {
                  Debug.Log((object) "Slave is attacking target!");
                  if (this.HuntTarget.Strength == 9 && this.StudentID != 11)
                    this.AttackWillFail = true;
                  if (!this.AttackWillFail)
                  {
                    this.CharacterAnimation.CrossFade("f02_murderSuicide_00");
                  }
                  else
                  {
                    this.CharacterAnimation.CrossFade("f02_brokenAttackFailA_00");
                    this.CharacterAnimation[this.WetAnim].weight = 0.0f;
                    this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
                    ++this.Police.Corpses;
                    GameObjectUtils.SetLayerRecursively(this.gameObject, 11);
                    this.MapMarker.gameObject.layer = 10;
                    this.tag = "Blood";
                    this.Ragdoll.MurderSuicideAnimation = true;
                    this.Ragdoll.Disturbing = true;
                    this.Dying = true;
                    this.HipCollider.enabled = true;
                    this.HipCollider.radius = 0.5f;
                    this.MurderSuicidePhase = 9;
                  }
                  this.Pathfinding.canSearch = false;
                  this.Pathfinding.canMove = false;
                  this.Broken.Subtitle.text = string.Empty;
                  this.MyController.radius = 0.0f;
                  this.Broken.Done = true;
                  if (!this.AttackWillFail)
                  {
                    AudioSource.PlayClipAtPoint(this.MurderSuicideSounds, this.transform.position + new Vector3(0.0f, 1f, 0.0f));
                    AudioSource component = this.GetComponent<AudioSource>();
                    component.clip = this.MurderSuicideKiller;
                    component.Play();
                  }
                  if (this.HuntTarget.Shoving)
                    this.Yandere.CannotRecover = false;
                  if ((UnityEngine.Object) this.StudentManager.CombatMinigame.Delinquent == (UnityEngine.Object) this.HuntTarget)
                  {
                    this.StudentManager.CombatMinigame.Stop();
                    this.StudentManager.CombatMinigame.ReleaseYandere();
                  }
                  if (!this.AttackWillFail)
                  {
                    this.HuntTarget.HipCollider.enabled = true;
                    this.HuntTarget.HipCollider.radius = 1f;
                    this.HuntTarget.DetectionMarker.Tex.enabled = false;
                  }
                  this.HuntTarget.CharacterAnimation[this.HuntTarget.WetAnim].weight = 0.0f;
                  if (!this.HuntTarget.Male)
                  {
                    this.HuntTarget.CharacterAnimation[this.HuntTarget.ShyAnim].weight = 0.0f;
                    if (this.HuntTarget.Club == ClubType.LightMusic)
                      this.HuntTarget.Instruments[this.HuntTarget.ClubMemberID].gameObject.SetActive(false);
                  }
                  if (this.HuntTarget.Rival)
                    this.HuntTarget.MapMarker.gameObject.SetActive(false);
                  this.HuntTarget.TargetedForDistraction = false;
                  this.HuntTarget.Pathfinding.canSearch = false;
                  this.HuntTarget.Pathfinding.canMove = false;
                  this.HuntTarget.WitnessCamera.Show = false;
                  this.HuntTarget.CameraReacting = false;
                  this.HuntTarget.FocusOnStudent = false;
                  this.HuntTarget.FocusOnYandere = false;
                  this.HuntTarget.Investigating = false;
                  this.HuntTarget.Distracting = false;
                  this.HuntTarget.Splashed = false;
                  this.HuntTarget.Alarmed = false;
                  this.HuntTarget.Burning = false;
                  this.HuntTarget.Fleeing = false;
                  this.HuntTarget.Routine = false;
                  this.HuntTarget.Shoving = false;
                  this.HuntTarget.Tripped = false;
                  this.HuntTarget.Wet = false;
                  this.HuntTarget.Blind = true;
                  this.HuntTarget.Hunter = this;
                  Debug.Log((object) (this.HuntTarget.Name + " should now recognize " + this.Name + " as their Hunter."));
                  this.HuntTarget.Prompt.Hide();
                  this.HuntTarget.Prompt.enabled = false;
                  if ((UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) this.HuntTarget)
                  {
                    this.Yandere.Chased = false;
                    this.Yandere.Pursuer = (StudentScript) null;
                  }
                  if (!this.AttackWillFail)
                  {
                    if (!this.HuntTarget.Male)
                      this.HuntTarget.CharacterAnimation.CrossFade("f02_murderSuicide_01");
                    else
                      this.HuntTarget.CharacterAnimation.CrossFade("murderSuicide_01");
                    this.HuntTarget.CharacterAnimation[this.HuntTarget.WetAnim].weight = 0.0f;
                    this.HuntTarget.Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
                    this.HuntTarget.GetComponent<AudioSource>().clip = this.HuntTarget.MurderSuicideVictim;
                    this.HuntTarget.GetComponent<AudioSource>().Play();
                    this.Police.CorpseList[this.Police.Corpses] = this.HuntTarget.Ragdoll;
                    ++this.Police.Corpses;
                    GameObjectUtils.SetLayerRecursively(this.HuntTarget.gameObject, 11);
                    this.MapMarker.gameObject.layer = 10;
                    this.HuntTarget.tag = "Blood";
                    this.HuntTarget.Ragdoll.MurderSuicideAnimation = true;
                    this.HuntTarget.Ragdoll.Disturbing = true;
                    this.HuntTarget.Dying = true;
                    this.HuntTarget.MurderSuicidePhase = 100;
                  }
                  else
                  {
                    this.HuntTarget.CharacterAnimation.CrossFade("f02_brokenAttackFailB_00");
                    this.HuntTarget.FightingSlave = true;
                    this.HuntTarget.Distracted = true;
                    this.HuntTarget.Blind = false;
                    this.MyWeapon.transform.parent = this.ItemParent;
                    this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
                    this.MyWeapon.transform.localPosition = Vector3.zero;
                    this.MyWeapon.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
                    this.StudentManager.UpdateMe(this.HuntTarget.StudentID);
                  }
                  this.HuntTarget.MyController.radius = 0.0f;
                  this.HuntTarget.SpeechLines.Stop();
                  this.HuntTarget.EyeShrink = 1f;
                  this.HuntTarget.SpawnAlarmDisc();
                  if (this.HuntTarget.Following)
                  {
                    this.Yandere.Follower = (StudentScript) null;
                    --this.Yandere.Followers;
                    this.Hearts.emission.enabled = false;
                    this.HuntTarget.FollowCountdown.gameObject.SetActive(false);
                    this.HuntTarget.Following = false;
                  }
                  this.OriginalYPosition = this.HuntTarget.transform.position.y;
                  if (this.MurderSuicidePhase == 0)
                    ++this.MurderSuicidePhase;
                }
                else
                {
                  this.TooCloseToWall = false;
                  this.CheckForWallInFront(1f);
                  if (this.TooCloseToWall)
                  {
                    int num = (int) this.MyController.Move(this.transform.forward * Time.deltaTime * -0.1f);
                  }
                  if (this.Dying)
                    this.Yandere.NearMindSlave = (double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 5.0;
                  if (this.MurderSuicidePhase == 0 && (double) this.CharacterAnimation["f02_brokenStandUp_00"].time >= (double) this.CharacterAnimation["f02_brokenStandUp_00"].length)
                  {
                    this.Pathfinding.canSearch = true;
                    this.Pathfinding.canMove = true;
                  }
                  if (this.MurderSuicidePhase > 0)
                  {
                    if (!this.AttackWillFail)
                    {
                      this.HuntTarget.targetRotation = Quaternion.LookRotation(this.HuntTarget.transform.position - this.transform.position);
                      this.HuntTarget.MoveTowardsTarget(this.transform.position + this.transform.forward * 0.01f);
                    }
                    else
                    {
                      this.HuntTarget.targetRotation = Quaternion.LookRotation(this.transform.position - this.HuntTarget.transform.position);
                      this.HuntTarget.MoveTowardsTarget(this.transform.position + this.transform.forward * 1f);
                    }
                    this.HuntTarget.transform.rotation = Quaternion.Slerp(this.HuntTarget.transform.rotation, this.HuntTarget.targetRotation, Time.deltaTime * 10f);
                    this.transform.position = new Vector3(this.transform.position.x, this.OriginalYPosition, this.transform.position.z);
                    this.HuntTarget.transform.position = new Vector3(this.HuntTarget.transform.position.x, this.OriginalYPosition, this.HuntTarget.transform.position.z);
                    this.targetRotation = Quaternion.LookRotation(this.HuntTarget.transform.position - this.transform.position);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
                    Physics.SyncTransforms();
                  }
                  if (this.MurderSuicidePhase == 1)
                  {
                    if ((double) this.CharacterAnimation["f02_murderSuicide_00"].time >= 2.4000000953674316)
                    {
                      this.MyWeapon.transform.parent = this.ItemParent;
                      this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
                      this.MyWeapon.transform.localPosition = Vector3.zero;
                      this.MyWeapon.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
                      ++this.MurderSuicidePhase;
                    }
                  }
                  else if (this.MurderSuicidePhase == 2)
                  {
                    if ((double) this.CharacterAnimation["f02_murderSuicide_00"].time >= 3.2999999523162842)
                    {
                      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Ragdoll.BloodPoolSpawner.BloodPool, this.transform.position + this.transform.up * 0.012f + this.transform.forward, Quaternion.identity);
                      gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0.0f, 360f), 0.0f);
                      gameObject.transform.parent = this.Police.BloodParent;
                      this.MyWeapon.Victims[this.HuntTarget.StudentID] = true;
                      this.MyWeapon.Blood.enabled = true;
                      if (!this.MyWeapon.Evidence)
                      {
                        Debug.Log((object) "A mind-broken slave is running the code for staining her equipped weapon with blood and marking it as evidence.");
                        this.MyWeapon.MurderWeapon = true;
                        this.MyWeapon.Evidence = true;
                        this.MyWeapon.Bloody = true;
                        ++this.Police.MurderWeapons;
                      }
                      UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
                      this.KnifeDown = true;
                      this.LiquidProjector.material.mainTexture = this.BloodTexture;
                      this.LiquidProjector.gameObject.SetActive(true);
                      this.LiquidProjector.enabled = true;
                      this.HuntTarget.LiquidProjector.material.mainTexture = this.HuntTarget.BloodTexture;
                      this.HuntTarget.LiquidProjector.gameObject.SetActive(true);
                      this.HuntTarget.LiquidProjector.enabled = true;
                      ++this.MurderSuicidePhase;
                    }
                  }
                  else if (this.MurderSuicidePhase == 3)
                  {
                    if (!this.KnifeDown)
                    {
                      if ((double) this.MyWeapon.transform.position.y < (double) this.transform.position.y + 0.3333333432674408)
                      {
                        UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
                        this.KnifeDown = true;
                        Debug.Log((object) "Stab!");
                      }
                    }
                    else if ((double) this.MyWeapon.transform.position.y > (double) this.transform.position.y + 0.3333333432674408)
                      this.KnifeDown = false;
                    if ((double) this.CharacterAnimation["f02_murderSuicide_00"].time >= 16.666666030883789)
                    {
                      Debug.Log((object) "Released knife!");
                      this.MyWeapon.transform.parent = (Transform) null;
                      ++this.MurderSuicidePhase;
                    }
                  }
                  else if (this.MurderSuicidePhase == 4)
                  {
                    if ((double) this.CharacterAnimation["f02_murderSuicide_00"].time >= 18.899999618530273)
                    {
                      Debug.Log((object) "Yanked out knife!");
                      UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
                      this.MyWeapon.transform.parent = this.ItemParent;
                      this.MyWeapon.transform.localPosition = Vector3.zero;
                      this.MyWeapon.transform.localEulerAngles = Vector3.zero;
                      ++this.MurderSuicidePhase;
                    }
                  }
                  else if (this.MurderSuicidePhase == 5)
                  {
                    if ((double) this.CharacterAnimation["f02_murderSuicide_00"].time >= 26.166666030883789)
                    {
                      Debug.Log((object) "Stabbed neck!");
                      UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
                      this.MyWeapon.Victims[this.StudentID] = true;
                      ++this.MurderSuicidePhase;
                    }
                  }
                  else if (this.MurderSuicidePhase == 6)
                  {
                    if ((double) this.CharacterAnimation["f02_murderSuicide_00"].time >= 30.5)
                    {
                      Debug.Log((object) "BLOOD FOUNTAIN!");
                      this.BloodFountain.Play();
                      ++this.MurderSuicidePhase;
                    }
                  }
                  else if (this.MurderSuicidePhase == 7)
                  {
                    if ((double) this.CharacterAnimation["f02_murderSuicide_00"].time >= 31.5)
                    {
                      this.BloodSprayCollider.SetActive(true);
                      ++this.MurderSuicidePhase;
                    }
                  }
                  else if (this.MurderSuicidePhase == 8)
                  {
                    if ((double) this.CharacterAnimation["f02_murderSuicide_00"].time >= (double) this.CharacterAnimation["f02_murderSuicide_00"].length)
                    {
                      this.Yandere.NearMindSlave = false;
                      this.MyWeapon.transform.parent = (Transform) null;
                      this.MyWeapon.Drop();
                      this.MyWeapon = (WeaponScript) null;
                      this.StudentManager.StopHesitating();
                      this.HuntTarget.HipCollider.radius = 0.5f;
                      this.HuntTarget.BecomeRagdoll();
                      this.HuntTarget.MurderedByStudent = true;
                      this.HuntTarget.Ragdoll.Disturbing = false;
                      this.HuntTarget.Ragdoll.MurderSuicide = true;
                      this.HuntTarget.DeathType = DeathType.Weapon;
                      if (this.FragileSlave)
                      {
                        this.HuntTarget.MurderedByFragile = true;
                        this.HuntTarget.Hunted = true;
                      }
                      if ((UnityEngine.Object) this.HuntTarget.Follower != (UnityEngine.Object) null)
                      {
                        Debug.Log((object) "This mind-broken slave just killed someone who had a follower.");
                        if (this.HuntTarget.Follower.WitnessedMindBrokenMurder)
                        {
                          Debug.Log((object) ("The follower's ''Corpse'' variable is being set to: " + this.HuntTarget.Ragdoll.Student.Name));
                          this.HuntTarget.Follower.Corpse = this.HuntTarget.Ragdoll;
                        }
                      }
                      if ((UnityEngine.Object) this.BloodSprayCollider != (UnityEngine.Object) null)
                        this.BloodSprayCollider.SetActive(false);
                      this.BecomeRagdoll();
                      this.DeathType = DeathType.Weapon;
                      this.StudentManager.MurderTakingPlace = false;
                      this.Ragdoll.MurderSuicide = true;
                      this.MurderSuicide = true;
                      this.Broken.HairPhysics[0].enabled = true;
                      this.Broken.HairPhysics[1].enabled = true;
                      this.Broken.enabled = false;
                      this.Hunting = false;
                      if (this.StudentID > 10 && this.StudentID < 21)
                      {
                        Debug.Log((object) "A former rival killed herself as a mind-broken slave. StudentManager will be informed.");
                        this.StudentManager.UpdateRivalEliminationDetails(this.StudentID);
                      }
                    }
                  }
                  else if (this.MurderSuicidePhase == 9)
                  {
                    this.CharacterAnimation.CrossFade("f02_brokenAttackFailA_00");
                    if ((double) this.CharacterAnimation["f02_brokenAttackFailA_00"].time >= (double) this.CharacterAnimation["f02_brokenAttackFailA_00"].length)
                    {
                      Debug.Log((object) "A mind-broken slave just failed to kill her target.");
                      this.Yandere.NearMindSlave = false;
                      this.MurderSuicidePhase = 1;
                      this.Hunting = false;
                      this.Suicide = true;
                      this.HuntTarget.MyController.radius = 0.1f;
                      this.HuntTarget.Distracted = false;
                      this.HuntTarget.Routine = true;
                      this.HuntTarget.FightingSlave = false;
                      this.StudentManager.UpdateMe(this.HuntTarget.StudentID);
                      if (this.StudentID > 10 && this.StudentID < 21)
                      {
                        Debug.Log((object) "A former rival killed herself as a mind-broken slave. StudentManager will be informed.");
                        this.StudentManager.UpdateRivalEliminationDetails(this.StudentID);
                      }
                    }
                    else if ((double) this.CharacterAnimation["f02_brokenAttackFailA_00"].time >= 6.5 && this.HuntTarget.FightingSlave)
                    {
                      this.HuntTarget.FightingSlave = false;
                      this.StudentManager.UpdateMe(this.HuntTarget.StudentID);
                    }
                  }
                }
              }
            }
          }
          else
          {
            this.Hunting = false;
            this.Suicide = true;
          }
        }
        else
        {
          this.Hunting = false;
          this.Suicide = true;
        }
      }
      if (this.Suicide)
      {
        if (this.MurderSuicidePhase == 0)
        {
          if ((double) this.CharacterAnimation["f02_brokenStandUp_00"].time >= (double) this.CharacterAnimation["f02_brokenStandUp_00"].length)
          {
            ++this.MurderSuicidePhase;
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Pathfinding.speed = 0.0f;
            this.CharacterAnimation.CrossFade("f02_suicide_00");
          }
        }
        else if (this.MurderSuicidePhase == 1)
        {
          if ((double) this.Pathfinding.speed > 0.0)
          {
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Pathfinding.speed = 0.0f;
            this.CharacterAnimation.CrossFade("f02_suicide_00");
          }
          if ((double) this.CharacterAnimation["f02_suicide_00"].time >= 0.73333334922790527)
          {
            this.MyWeapon.transform.parent = this.ItemParent;
            this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
            this.MyWeapon.transform.localPosition = Vector3.zero;
            this.MyWeapon.transform.localEulerAngles = Vector3.zero;
            this.Broken.Subtitle.text = string.Empty;
            this.Broken.Done = true;
            ++this.MurderSuicidePhase;
          }
        }
        else if (this.MurderSuicidePhase == 2)
        {
          if ((double) this.CharacterAnimation["f02_suicide_00"].time >= 4.1666665077209473)
          {
            Debug.Log((object) "Stabbed neck!");
            UnityEngine.Object.Instantiate<GameObject>(this.StabBloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
            this.MyWeapon.Victims[this.StudentID] = true;
            this.MyWeapon.Blood.enabled = true;
            if (!this.MyWeapon.Evidence)
            {
              this.MyWeapon.Evidence = true;
              ++this.Police.MurderWeapons;
            }
            ++this.MurderSuicidePhase;
          }
        }
        else if (this.MurderSuicidePhase == 3)
        {
          if ((double) this.CharacterAnimation["f02_suicide_00"].time >= 6.1666665077209473)
          {
            Debug.Log((object) "BLOOD FOUNTAIN!");
            this.BloodFountain.gameObject.GetComponent<AudioSource>().Play();
            this.BloodFountain.Play();
            ++this.MurderSuicidePhase;
          }
        }
        else if (this.MurderSuicidePhase == 4)
        {
          if ((double) this.CharacterAnimation["f02_suicide_00"].time >= 7.0)
          {
            this.Ragdoll.BloodPoolSpawner.SpawnPool(this.transform);
            this.BloodSprayCollider.SetActive(true);
            ++this.MurderSuicidePhase;
          }
        }
        else if (this.MurderSuicidePhase == 5 && (double) this.CharacterAnimation["f02_suicide_00"].time >= (double) this.CharacterAnimation["f02_suicide_00"].length)
        {
          this.MyWeapon.transform.parent = (Transform) null;
          this.MyWeapon.Drop();
          this.MyWeapon = (WeaponScript) null;
          this.StudentManager.StopHesitating();
          if ((UnityEngine.Object) this.BloodSprayCollider != (UnityEngine.Object) null)
            this.BloodSprayCollider.SetActive(false);
          this.BecomeRagdoll();
          this.DeathType = DeathType.Weapon;
          this.Broken.HairPhysics[0].enabled = true;
          this.Broken.HairPhysics[1].enabled = true;
          this.Broken.enabled = false;
        }
      }
      if (this.CameraReacting)
      {
        this.PhotoPatience = Mathf.MoveTowards(this.PhotoPatience, 0.0f, Time.deltaTime);
        this.Prompt.Circle[0].fillAmount = 1f;
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if (!this.Yandere.ClubAccessories[7].activeInHierarchy || this.Club == ClubType.Delinquent)
        {
          if (this.CameraReactPhase == 1)
          {
            if ((double) this.CharacterAnimation[this.CameraAnims[1]].time >= (double) this.CharacterAnimation[this.CameraAnims[1]].length)
            {
              this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
              this.CameraReactPhase = 2;
              this.CameraPoseTimer = 1f;
            }
          }
          else if (this.CameraReactPhase == 2)
          {
            this.CameraPoseTimer -= Time.deltaTime;
            if ((double) this.CameraPoseTimer <= 0.0)
            {
              this.CharacterAnimation.CrossFade(this.CameraAnims[3]);
              this.CameraReactPhase = 3;
            }
          }
          else if (this.CameraReactPhase == 3)
          {
            if ((double) this.CameraPoseTimer == 1.0)
            {
              this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
              this.CameraReactPhase = 2;
            }
            if ((double) this.CharacterAnimation[this.CameraAnims[3]].time >= (double) this.CharacterAnimation[this.CameraAnims[3]].length)
            {
              if (!this.Phoneless && (this.Persona == PersonaType.PhoneAddict || this.Sleuthing))
                this.SmartPhone.SetActive(true);
              if (!this.Male && this.Cigarette.activeInHierarchy)
                this.SmartPhone.SetActive(false);
              this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
              this.Obstacle.enabled = false;
              this.CameraReacting = false;
              this.Routine = true;
              this.ReadPhase = 0;
              if (this.Actions[this.Phase] == StudentActionType.Clean)
              {
                this.Scrubber.SetActive(true);
                if (this.CleaningRole == 5)
                  this.Eraser.SetActive(true);
              }
            }
          }
        }
        else if (this.Yandere.Shutter.TargetStudent != this.StudentID)
        {
          this.CameraPoseTimer = Mathf.MoveTowards(this.CameraPoseTimer, 0.0f, Time.deltaTime);
          if ((double) this.CameraPoseTimer == 0.0)
          {
            if (!this.Phoneless && (this.Persona == PersonaType.PhoneAddict || this.Sleuthing))
              this.SmartPhone.SetActive(true);
            this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
            this.Obstacle.enabled = false;
            this.CameraReacting = false;
            this.Routine = true;
            this.ReadPhase = 0;
            if (this.Actions[this.Phase] == StudentActionType.Clean)
            {
              this.Scrubber.SetActive(true);
              if (this.CleaningRole == 5)
                this.Eraser.SetActive(true);
            }
          }
        }
        else
          this.CameraPoseTimer = 1f;
        if (this.InEvent)
        {
          this.CameraReacting = false;
          this.ReadPhase = 0;
        }
      }
      if (this.Investigating)
      {
        if (!this.YandereInnocent && this.InvestigationPhase < 100 && this.CanSeeObject(this.Yandere.gameObject, new Vector3(this.Yandere.HeadPosition.x, this.Yandere.transform.position.y + this.Yandere.Zoom.Height, this.Yandere.HeadPosition.z)))
        {
          if ((double) Vector3.Distance(this.Yandere.transform.position, this.Giggle.transform.position) > 2.5)
          {
            this.YandereInnocent = true;
          }
          else
          {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.InvestigationPhase = 100;
            this.InvestigationTimer = 0.0f;
          }
        }
        if (this.InvestigationPhase == 0)
        {
          if ((double) this.InvestigationTimer < 5.0)
          {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            if (this.Persona == PersonaType.Heroic && this.HeardScream || this.Persona == PersonaType.Protective)
              this.InvestigationTimer += Time.deltaTime * 5f;
            else
              this.InvestigationTimer += Time.deltaTime;
            this.targetRotation = Quaternion.LookRotation(new Vector3(this.Giggle.transform.position.x, this.transform.position.y, this.Giggle.transform.position.z) - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          }
          else
          {
            Debug.Log((object) (this.Name + " reached the part of Investigating where they are being told to begin walking/running."));
            if ((UnityEngine.Object) this.Giggle != (UnityEngine.Object) null)
            {
              this.Pathfinding.target = this.Giggle.transform;
              this.CurrentDestination = this.Giggle.transform;
            }
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            if (this.Persona == PersonaType.Heroic && this.HeardScream || this.Persona == PersonaType.Protective || this.Hurry || (double) this.WalkSpeed == 4.0 || (double) this.Pathfinding.speed == 4.0)
            {
              this.CharacterAnimation.CrossFade(this.SprintAnim);
              this.Pathfinding.speed = 4f;
            }
            else
            {
              this.CharacterAnimation.CrossFade(this.WalkAnim);
              this.Pathfinding.speed = this.WalkSpeed;
            }
            ++this.InvestigationPhase;
          }
        }
        else if (this.InvestigationPhase == 1)
        {
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          if ((double) this.DistanceToDestination > 1.0)
          {
            if (this.Persona == PersonaType.Heroic && this.HeardScream || this.Persona == PersonaType.Protective || this.Hurry || (double) this.WalkSpeed == 4.0 || (double) this.Pathfinding.speed == 4.0)
              this.CharacterAnimation.CrossFade(this.SprintAnim);
            else
              this.CharacterAnimation.CrossFade(this.WalkAnim);
          }
          else
          {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            ++this.InvestigationPhase;
          }
        }
        else if (this.InvestigationPhase == 2)
        {
          if (this.Persona == PersonaType.Protective)
            this.InvestigationTimer += Time.deltaTime * 2.5f;
          else
            this.InvestigationTimer += Time.deltaTime;
          if ((double) this.InvestigationTimer > 10.0)
          {
            Debug.Log((object) "This character has investigated for 10 seconds, and is done investigating now.");
            this.StopInvestigating();
          }
        }
        else if (this.InvestigationPhase == 100)
        {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.InvestigationTimer += Time.deltaTime;
          if ((double) this.InvestigationTimer > 2.0)
          {
            Debug.Log((object) (this.Name + " reached InvestigationPhase 100."));
            this.StopInvestigating();
          }
        }
      }
      if (this.EndSearch)
      {
        Debug.Log((object) (this.Name + " just got her phone back."));
        this.MoveTowardsTarget(this.Pathfinding.target.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
        this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
        if ((double) this.PatrolTimer > 5.0)
        {
          Debug.Log((object) (this.Name + " is now attempting to return to her previous routine."));
          ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[2];
          scheduleBlock3.destination = "Hangout";
          scheduleBlock3.action = "Hangout";
          if (this.Club == ClubType.Cooking || this.Club == ClubType.MartialArts)
          {
            scheduleBlock3.destination = "Club";
            scheduleBlock3.action = "Club";
          }
          if (this.Club == ClubType.LightMusic)
          {
            scheduleBlock3.destination = "Practice";
            scheduleBlock3.action = "Practice";
          }
          ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[4];
          scheduleBlock4.destination = "LunchSpot";
          scheduleBlock4.action = "Eat";
          ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[7];
          scheduleBlock5.destination = "Hangout";
          scheduleBlock5.action = "Hangout";
          Debug.Log((object) ("ScheduleBlocks[2].destination is: " + this.ScheduleBlocks[2].destination));
          this.RestoreOriginalScheduleBlocks();
          this.RestoreOriginalActions();
          Debug.Log((object) ("And now, ScheduleBlocks[2].destination is: " + this.ScheduleBlocks[2].destination));
          this.GetDestinations();
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.CurrentAction = this.Actions[this.Phase];
          this.DistanceToDestination = 100f;
          this.EndSearch = false;
          this.Phoneless = false;
          this.Routine = true;
          this.SprintAnim = this.OriginalSprintAnim;
          this.RunAnim = this.OriginalSprintAnim;
          this.WalkAnim = this.OriginalWalkAnim;
          if (this.Persona == PersonaType.PhoneAddict)
            this.WalkAnim = this.PhoneAnims[1];
          this.Pathfinding.speed = this.WalkSpeed;
          this.Hurry = false;
          this.StudentManager.CommunalLocker.RivalPhone.ReturnToOrigin();
          if ((UnityEngine.Object) this.Follower != (UnityEngine.Object) null)
            this.Follower.TargetDistance = 0.5f;
          if (this.Persona == PersonaType.PhoneAddict)
            this.SmartPhone.SetActive(true);
        }
      }
      if (this.Shoving)
      {
        if ((double) this.SprayTimer > 0.0)
          this.SprayTimer = Mathf.MoveTowards(this.SprayTimer, 0.0f, Time.deltaTime);
        this.CharacterAnimation.CrossFade(this.ShoveAnim);
        if ((double) this.CharacterAnimation[this.ShoveAnim].time > (double) this.CharacterAnimation[this.ShoveAnim].length)
        {
          if (this.Club != ClubType.Council && this.Persona != PersonaType.Violent && this.StudentID != 20 || this.RespectEarned)
            this.Patience = 999;
          if (this.Patience > 0)
          {
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.Distracted = false;
            this.Shoving = false;
            this.Routine = true;
            this.Paired = false;
          }
          else if (this.Club == ClubType.Council || this.Shovey)
          {
            Debug.Log((object) "Calling ''Spray()'' from this part of the code. 2");
            this.Shoving = false;
            this.Spray();
          }
          else
          {
            this.SpawnAlarmDisc();
            this.SmartPhone.SetActive(false);
            this.Distracted = true;
            this.Threatened = true;
            this.Shoving = false;
            this.Alarmed = true;
          }
        }
      }
      if (this.Spraying)
      {
        this.CharacterAnimation.CrossFade(this.SprayAnim);
        this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
        this.Yandere.Attacking = false;
        if ((double) this.CharacterAnimation[this.SprayAnim].time > 0.66666)
        {
          if (this.Yandere.Armed)
            this.Yandere.EquippedWeapon.Drop();
          this.Yandere.EmptyHands();
          this.PepperSprayEffect.Play();
          this.Spraying = false;
          this.enabled = false;
        }
      }
      if (this.SentHome)
      {
        if (this.SentHomePhase == 0)
        {
          if (this.Shy)
            this.CharacterAnimation[this.ShyAnim].weight = 0.0f;
          this.CharacterAnimation.CrossFade(this.SentHomeAnim);
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          ++this.SentHomePhase;
          if (this.SmartPhone.activeInHierarchy)
          {
            this.CharacterAnimation[this.SentHomeAnim].time = 1.5f;
            ++this.SentHomePhase;
          }
        }
        else if (this.SentHomePhase == 1)
        {
          if ((double) this.CharacterAnimation[this.SentHomeAnim].time > 0.66666001081466675)
          {
            this.SmartPhone.SetActive(true);
            ++this.SentHomePhase;
          }
        }
        else if (this.SentHomePhase == 2 && (double) this.CharacterAnimation[this.SentHomeAnim].time > (double) this.CharacterAnimation[this.SentHomeAnim].length)
        {
          Debug.Log((object) "Sprinting becasue sent home.");
          this.SprintAnim = this.OriginalSprintAnim;
          this.CharacterAnimation.CrossFade(this.SprintAnim);
          this.CurrentDestination = this.StudentManager.Exit;
          this.Pathfinding.target = this.StudentManager.Exit;
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.SmartPhone.SetActive(false);
          this.Pathfinding.speed = 4f;
          ++this.SentHomePhase;
        }
      }
      if (this.DramaticReaction)
      {
        this.DramaticCamera.transform.Translate(Vector3.forward * Time.deltaTime * 0.01f);
        if (this.DramaticPhase == 0)
        {
          this.DramaticCamera.rect = new Rect(0.0f, Mathf.Lerp(this.DramaticCamera.rect.y, 0.25f, Time.deltaTime * 10f), 1f, Mathf.Lerp(this.DramaticCamera.rect.height, 0.5f, Time.deltaTime * 10f));
          this.DramaticTimer += Time.deltaTime;
          if ((double) this.DramaticTimer > 1.0)
          {
            this.DramaticTimer = 0.0f;
            ++this.DramaticPhase;
          }
        }
        else if (this.DramaticPhase == 1)
        {
          this.DramaticCamera.rect = new Rect(0.0f, Mathf.Lerp(this.DramaticCamera.rect.y, 0.5f, Time.deltaTime * 10f), 1f, Mathf.Lerp(this.DramaticCamera.rect.height, 0.0f, Time.deltaTime * 10f));
          this.DramaticTimer += Time.deltaTime;
          if ((double) this.DramaticCamera.rect.height < 0.0099999997764825821 || (double) this.DramaticTimer > 0.5)
          {
            Debug.Log((object) "Disabling Dramatic Camera.");
            this.DramaticCamera.gameObject.SetActive(false);
            this.AttackReaction();
            ++this.DramaticPhase;
          }
        }
      }
      if (this.HitReacting && (double) this.CharacterAnimation[this.SithReactAnim].time >= (double) this.CharacterAnimation[this.SithReactAnim].length)
      {
        this.Persona = PersonaType.SocialButterfly;
        this.PersonaReaction();
        this.HitReacting = false;
      }
      if (this.Eaten)
      {
        if (this.Yandere.Eating)
        {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        }
        if ((double) this.CharacterAnimation[this.EatVictimAnim].time >= (double) this.CharacterAnimation[this.EatVictimAnim].length)
          this.BecomeRagdoll();
      }
      if (this.Electrified)
      {
        Debug.Log((object) (this.Name + " is now being electrocuted."));
        this.CharacterAnimation.CrossFade(this.ElectroAnim);
        if ((double) this.CharacterAnimation[this.ElectroAnim].time >= (double) this.CharacterAnimation[this.ElectroAnim].length || this.TooCloseToWall)
        {
          this.Electrocuted = true;
          this.BecomeRagdoll();
          this.DeathType = DeathType.Electrocution;
          if ((UnityEngine.Object) this.OsanaHairL != (UnityEngine.Object) null)
          {
            this.OsanaHairL.GetComponent<DynamicBone>().enabled = true;
            this.OsanaHairR.GetComponent<DynamicBone>().enabled = true;
            this.OsanaHairL.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
            this.OsanaHairR.transform.localEulerAngles = new Vector3(0.0f, -90f, 180f);
          }
        }
        else if ((double) this.CharacterAnimation[this.ElectroAnim].time >= 9.5)
          this.CheckForWallBehind();
        else if ((double) this.CharacterAnimation[this.ElectroAnim].time < 6.0 && (UnityEngine.Object) this.OsanaHairL != (UnityEngine.Object) null)
        {
          this.OsanaHairL.transform.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
          this.OsanaHairR.transform.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
        }
      }
      if (this.BreakingUpFight)
      {
        this.targetRotation = this.Yandere.transform.rotation * Quaternion.Euler(0.0f, 90f, 0.0f);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.5f);
        if (this.StudentID == 87 && (UnityEngine.Object) this.CandyBar != (UnityEngine.Object) null)
        {
          if ((double) this.CharacterAnimation[this.BreakUpAnim].time >= 4.0)
            this.CandyBar.SetActive(false);
          else if ((double) this.CharacterAnimation[this.BreakUpAnim].time >= 1.0 / 6.0)
            this.CandyBar.SetActive(true);
        }
        if ((double) this.CharacterAnimation[this.BreakUpAnim].time != 0.0 && (double) this.CharacterAnimation[this.BreakUpAnim].time >= (double) this.CharacterAnimation[this.BreakUpAnim].length)
          this.ReturnToRoutine();
      }
      if (this.Tripping)
      {
        this.MoveTowardsTarget(new Vector3(0.0f, 0.0f, this.transform.position.z));
        this.CharacterAnimation.CrossFade("trip_00");
        this.Pathfinding.canSearch = false;
        this.Pathfinding.canMove = false;
        if ((double) this.CharacterAnimation["trip_00"].time >= 0.5 && (double) this.CharacterAnimation["trip_00"].time <= 5.5 && this.StudentManager.Gate.Crushing)
        {
          this.BecomeRagdoll();
          this.DeathType = DeathType.Weight;
          this.Ragdoll.Decapitated = true;
          UnityEngine.Object.Instantiate<GameObject>(this.SquishyBloodEffect, this.Head.position, Quaternion.identity);
        }
        if ((double) this.CharacterAnimation["trip_00"].time >= (double) this.CharacterAnimation["trip_00"].length)
        {
          this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Distracted = true;
          this.Tripping = false;
          this.Routine = true;
          this.Tripped = true;
          this.BountyCollider.SetActive(true);
        }
      }
      if (this.SeekingMedicine)
      {
        if ((UnityEngine.Object) this.StudentManager.Students[90] == (UnityEngine.Object) null)
        {
          if (this.SeekMedicinePhase < 5)
            this.SeekMedicinePhase = 5;
        }
        else if ((!this.StudentManager.Students[90].gameObject.activeInHierarchy || this.StudentManager.Students[90].Dying) && this.SeekMedicinePhase < 5)
          this.SeekMedicinePhase = 5;
        if (this.SeekMedicinePhase == 0)
        {
          this.CurrentDestination = this.StudentManager.Students[90].transform;
          this.Pathfinding.target = this.StudentManager.Students[90].transform;
          ++this.SeekMedicinePhase;
        }
        else if (this.SeekMedicinePhase == 1)
        {
          this.CharacterAnimation.CrossFade(this.SprintAnim);
          if ((double) this.DistanceToDestination < 1.0)
          {
            StudentScript student = this.StudentManager.Students[90];
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Pathfinding.speed = 0.0f;
            if (!student.Fleeing && !student.Guarding)
            {
              if (student.Investigating)
                student.StopInvestigating();
              this.StudentManager.UpdateStudents(student.StudentID);
              student.Pathfinding.canSearch = false;
              student.Pathfinding.canMove = false;
              student.RetreivingMedicine = true;
              student.Pathfinding.speed = 0.0f;
              student.CameraReacting = false;
              student.TargetStudent = this;
              student.Routine = false;
              this.Subtitle.UpdateLabel(SubtitleType.RequestMedicine, 0, 5f);
              ++this.SeekMedicinePhase;
            }
            else
              this.SeekMedicinePhase = 5;
          }
        }
        else if (this.SeekMedicinePhase == 2)
        {
          StudentScript student = this.StudentManager.Students[90];
          this.targetRotation = Quaternion.LookRotation(new Vector3(student.transform.position.x, this.transform.position.y, student.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.MedicineTimer += Time.deltaTime;
          if ((double) this.MedicineTimer > 5.0)
          {
            ++this.SeekMedicinePhase;
            this.MedicineTimer = 0.0f;
            student.Pathfinding.canSearch = true;
            student.Pathfinding.canMove = true;
            ++student.RetrieveMedicinePhase;
          }
        }
        else if (this.SeekMedicinePhase != 3)
        {
          if (this.SeekMedicinePhase == 4)
          {
            StudentScript student = this.StudentManager.Students[90];
            this.targetRotation = Quaternion.LookRotation(new Vector3(student.transform.position.x, this.transform.position.y, student.transform.position.z) - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          }
          else if (this.SeekMedicinePhase == 5)
          {
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
            scheduleBlock.destination = "InfirmarySeat";
            scheduleBlock.action = "Relax";
            this.GetDestinations();
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
            this.Pathfinding.speed = 2f;
            this.RelaxAnim = this.HeadacheSitAnim;
            this.SeekingMedicine = false;
            this.Routine = true;
          }
        }
      }
      if (this.RetreivingMedicine)
      {
        if (this.RetrieveMedicinePhase == 0)
        {
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        }
        else if (this.RetrieveMedicinePhase == 1)
        {
          this.CharacterAnimation.CrossFade(this.WalkAnim);
          this.CurrentDestination = this.StudentManager.MedicineCabinet;
          this.Pathfinding.target = this.StudentManager.MedicineCabinet;
          this.Pathfinding.speed = this.WalkSpeed;
          ++this.RetrieveMedicinePhase;
        }
        else if (this.RetrieveMedicinePhase == 2)
        {
          if ((double) this.DistanceToDestination < 1.0)
          {
            this.StudentManager.CabinetDoor.Locked = false;
            this.StudentManager.CabinetDoor.Open = true;
            this.StudentManager.CabinetDoor.Timer = 0.0f;
            this.CurrentDestination = this.TargetStudent.transform;
            this.Pathfinding.target = this.TargetStudent.transform;
            ++this.RetrieveMedicinePhase;
          }
        }
        else if (this.RetrieveMedicinePhase == 3)
        {
          if ((double) this.DistanceToDestination < 1.0)
          {
            this.CurrentDestination = this.TargetStudent.transform;
            this.Pathfinding.target = this.TargetStudent.transform;
            ++this.RetrieveMedicinePhase;
          }
        }
        else if (this.RetrieveMedicinePhase == 4)
        {
          if ((double) this.DistanceToDestination < 1.0)
          {
            this.CharacterAnimation.CrossFade("f02_giveItem_00");
            if (this.TargetStudent.Male)
              this.TargetStudent.CharacterAnimation.CrossFade("eatItem_00");
            else
              this.TargetStudent.CharacterAnimation.CrossFade("f02_eatItem_00");
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            ++this.TargetStudent.SeekMedicinePhase;
            ++this.RetrieveMedicinePhase;
          }
        }
        else if (this.RetrieveMedicinePhase == 5)
        {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.MedicineTimer += Time.deltaTime;
          if ((double) this.MedicineTimer > 3.0)
          {
            this.CharacterAnimation.CrossFade(this.WalkAnim);
            this.CurrentDestination = this.StudentManager.MedicineCabinet;
            this.Pathfinding.target = this.StudentManager.MedicineCabinet;
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            ++this.TargetStudent.SeekMedicinePhase;
            ++this.RetrieveMedicinePhase;
          }
        }
        else if (this.RetrieveMedicinePhase == 6 && (double) this.DistanceToDestination < 1.0)
        {
          this.StudentManager.CabinetDoor.Locked = true;
          this.StudentManager.CabinetDoor.Open = false;
          this.StudentManager.CabinetDoor.Timer = 0.0f;
          this.RetreivingMedicine = false;
          this.RetrieveMedicinePhase = 0;
          this.Routine = true;
        }
      }
      if (this.EatingSnack)
      {
        if (this.SnackPhase == 0)
        {
          this.CharacterAnimation.CrossFade(this.EatChipsAnim);
          this.SmartPhone.SetActive(false);
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.SnackTimer += Time.deltaTime;
          if ((double) this.SnackTimer > 10.0)
          {
            UnityEngine.Object.Destroy((UnityEngine.Object) this.BagOfChips);
            bool flag = false;
            if (!this.StudentManager.Eighties && this.StudentID == 11)
              flag = true;
            if (!flag)
            {
              this.StudentManager.GetNearestFountain(this);
              if (this.Persona == PersonaType.Protective)
                this.Pathfinding.speed = 4f;
              this.Pathfinding.target = this.DrinkingFountain.DrinkPosition;
              this.CurrentDestination = this.DrinkingFountain.DrinkPosition;
              this.Pathfinding.canSearch = true;
              this.Pathfinding.canMove = true;
              this.SnackTimer = 0.0f;
            }
            ++this.SnackPhase;
          }
        }
        else if (this.SnackPhase == 1)
        {
          if ((double) this.Pathfinding.speed < 4.0)
            this.CharacterAnimation.CrossFade(this.WalkAnim);
          else
            this.CharacterAnimation.CrossFade(this.RunAnim);
          if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
            this.SmartPhone.SetActive(true);
          if ((double) this.DistanceToDestination < 1.0)
          {
            this.SmartPhone.SetActive(false);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            ++this.SnackPhase;
          }
        }
        else if (this.SnackPhase == 2)
        {
          this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.CharacterAnimation.CrossFade(this.DrinkFountainAnim);
          this.MoveTowardsTarget(this.DrinkingFountain.DrinkPosition.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.DrinkingFountain.DrinkPosition.rotation, 10f * Time.deltaTime);
          if ((double) this.CharacterAnimation[this.DrinkFountainAnim].time >= (double) this.CharacterAnimation[this.DrinkFountainAnim].length)
          {
            this.StopDrinking();
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
          }
          else if ((double) this.CharacterAnimation[this.DrinkFountainAnim].time > 0.5 && (double) this.CharacterAnimation[this.DrinkFountainAnim].time < 1.5)
          {
            if (!this.DrinkingFountain.Sabotaged)
            {
              this.DrinkingFountain.WaterStream.Play();
            }
            else
            {
              this.StopDrinking();
              UnityEngine.Object.Instantiate<GameObject>(this.DrinkingFountain.WaterCollider, this.transform.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity);
              this.DrinkingFountain.WaterBlast.Play();
            }
          }
        }
      }
      if (this.Dodging)
      {
        if ((double) this.CharacterAnimation[this.DodgeAnim].time >= (double) this.CharacterAnimation[this.DodgeAnim].length)
        {
          Debug.Log((object) (this.Name + " has finished her dodging animation."));
          this.Dodging = false;
          if (!this.TurnOffRadio)
          {
            this.Routine = true;
          }
          else
          {
            Debug.Log((object) "Hey. You. Walk.");
            this.CharacterAnimation.CrossFade(this.WalkAnim);
          }
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          if (this.GasWarned)
          {
            this.Yandere.Subtitle.UpdateLabel(SubtitleType.GasWarning, 2, 5f);
            this.GasWarned = false;
          }
        }
        else if ((double) this.CharacterAnimation[this.DodgeAnim].time < 0.66666001081466675)
        {
          int num5 = (int) this.MyController.Move(this.transform.forward * -1f * this.DodgeSpeed * Time.deltaTime);
          int num6 = (int) this.MyController.Move(Physics.gravity * 0.1f);
          if ((double) this.DodgeSpeed > 0.0)
            this.DodgeSpeed = Mathf.MoveTowards(this.DodgeSpeed, 0.0f, Time.deltaTime * 3f);
        }
      }
      if (!this.Guarding && this.InvestigatingBloodPool)
      {
        if ((UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null)
        {
          if ((double) Vector3.Distance(this.transform.position, new Vector3(this.BloodPool.position.x, this.transform.position.y, this.BloodPool.position.z)) < 1.0)
          {
            this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
            this.CharacterAnimation[this.InspectBloodAnim].speed = 1f;
            this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Distracted = true;
            if ((double) this.CharacterAnimation[this.InspectBloodAnim].time >= (double) this.CharacterAnimation[this.InspectBloodAnim].length || this.Persona == PersonaType.Strict)
            {
              bool flag1 = false;
              if (this.Club == ClubType.Cooking && this.CurrentAction == StudentActionType.ClubAction)
                flag1 = true;
              if (this.WitnessedWeapon)
              {
                bool flag2 = false;
                if (!this.Teacher && this.BloodPool.GetComponent<WeaponScript>().Metal && this.StudentManager.MetalDetectors)
                  flag2 = true;
                if (!this.WitnessedBloodyWeapon && this.StudentID > 1 && !flag2 && this.CurrentAction != StudentActionType.SitAndTakeNotes && this.Indoors && !flag1 && this.Club != ClubType.Delinquent && !this.BloodPool.GetComponent<WeaponScript>().Dangerous && (UnityEngine.Object) this.BloodPool.GetComponent<WeaponScript>().Returner == (UnityEngine.Object) null && (UnityEngine.Object) this.BloodPool.GetComponent<WeaponScript>().Origin != (UnityEngine.Object) null)
                {
                  Debug.Log((object) (this.Name + " has picked up a weapon with intent to return it to its original location."));
                  this.CharacterAnimation[this.PickUpAnim].time = 0.0f;
                  this.BloodPool.GetComponent<WeaponScript>().Prompt.Hide();
                  this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = false;
                  this.BloodPool.GetComponent<WeaponScript>().enabled = false;
                  this.BloodPool.GetComponent<WeaponScript>().Returner = this;
                  if (this.StudentID == 41 && !this.StudentManager.Eighties)
                    this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
                  else
                    this.Subtitle.UpdateLabel(SubtitleType.ReturningWeapon, 0, 5f);
                  this.ReturningMisplacedWeapon = true;
                  this.ReportingBlood = false;
                  this.Distracted = false;
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.Yandere.WeaponManager.ReturnWeaponID = this.BloodPool.GetComponent<WeaponScript>().GlobalID;
                  this.Yandere.WeaponManager.ReturnStudentID = this.StudentID;
                }
              }
              this.InvestigatingBloodPool = false;
              this.WitnessCooldownTimer = 5f;
              if (this.WitnessedLimb)
                this.SpawnAlarmDisc();
              if (!this.ReturningMisplacedWeapon)
              {
                if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this && this.WitnessedWeapon && !this.BloodPool.GetComponent<WeaponScript>().Dangerous)
                  this.StudentManager.BloodReporter = (StudentScript) null;
                if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this && this.StudentID > 1)
                {
                  if (this.Persona != PersonaType.Strict && this.Persona != PersonaType.Violent)
                  {
                    Debug.Log((object) (this.Name + " has changed from their original Persona into a Teacher's Pet."));
                    this.Persona = PersonaType.TeachersPet;
                  }
                  this.PersonaReaction();
                }
                else
                {
                  this.Distracted = false;
                  if (this.WitnessedWeapon && !this.WitnessedBloodyWeapon)
                  {
                    Debug.Log((object) (this.Name + " is not going to bother reporting what they found."));
                    this.StopInvestigating();
                    this.CurrentDestination = this.Destinations[this.Phase];
                    this.Pathfinding.target = this.Destinations[this.Phase];
                    this.LastSuspiciousObject2 = this.LastSuspiciousObject;
                    this.LastSuspiciousObject = this.BloodPool;
                    this.Pathfinding.canSearch = true;
                    this.Pathfinding.canMove = true;
                    this.Pathfinding.speed = this.WalkSpeed;
                    if (this.StudentID == 41 && !this.StudentManager.Eighties)
                      this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
                    else if (this.Club == ClubType.Delinquent)
                      this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 2, 3f);
                    else if (this.BloodPool.GetComponent<WeaponScript>().Dangerous)
                      this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 0, 3f);
                    else
                      this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 1, 3f);
                    this.WitnessedSomething = false;
                    this.WitnessedWeapon = false;
                    this.Routine = true;
                    this.BloodPool = (Transform) null;
                    if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this)
                    {
                      if (this.Persona != PersonaType.Strict && this.Persona != PersonaType.Violent)
                      {
                        Debug.Log((object) (this.Name + " has changed from their original Persona into a Teacher's Pet."));
                        this.Persona = PersonaType.TeachersPet;
                      }
                      this.PersonaReaction();
                    }
                  }
                  else
                  {
                    Debug.Log((object) (this.Name + " just found something scary on the ground and is going to react to it now."));
                    if (this.Persona != PersonaType.Strict && this.Persona != PersonaType.Violent)
                    {
                      Debug.Log((object) (this.Name + " has changed from their original Persona into a Teacher's Pet."));
                      this.Persona = PersonaType.TeachersPet;
                    }
                    this.PersonaReaction();
                  }
                }
                this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
              }
            }
          }
          else
          {
            if (this.Persona == PersonaType.Strict)
            {
              if (this.WitnessedWeapon && (bool) (UnityEngine.Object) this.BloodPool.GetComponent<WeaponScript>().Returner)
              {
                this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.InvestigatingBloodPool = false;
                this.WitnessedBloodyWeapon = false;
                this.WitnessedBloodPool = false;
                this.WitnessedSomething = false;
                this.WitnessedWeapon = false;
                this.Distracted = false;
                this.Routine = true;
                this.BloodPool = (Transform) null;
                this.WitnessCooldownTimer = 5f;
              }
              else if ((UnityEngine.Object) this.BloodPool.parent == (UnityEngine.Object) this.Yandere.RightHand || !this.BloodPool.gameObject.activeInHierarchy)
              {
                Debug.Log((object) "Yandere-chan just picked up the weapon that was being investigated.");
                this.InvestigatingBloodPool = false;
                this.WitnessedBloodyWeapon = false;
                this.WitnessedBloodPool = false;
                this.WitnessedSomething = false;
                this.WitnessedWeapon = false;
                this.Distracted = false;
                this.Routine = true;
                if ((UnityEngine.Object) this.BloodPool.GetComponent<WeaponScript>() != (UnityEngine.Object) null && this.BloodPool.GetComponent<WeaponScript>().Suspicious)
                {
                  this.WitnessCooldownTimer = 5f;
                  this.AlarmTimer = 0.0f;
                  this.Alarm = 200f;
                }
                this.BloodPool = (Transform) null;
              }
            }
            if ((UnityEngine.Object) this.BloodPool == (UnityEngine.Object) null || this.WitnessedWeapon && (UnityEngine.Object) this.BloodPool.parent != (UnityEngine.Object) null || this.WitnessedBloodPool && (UnityEngine.Object) this.BloodPool.parent == (UnityEngine.Object) this.Yandere.RightHand || this.WitnessedWeapon && (bool) (UnityEngine.Object) this.BloodPool.GetComponent<WeaponScript>().Returner)
            {
              Debug.Log((object) "ForgetAboutBloodPool() was called from this place in the code. 1");
              this.ForgetAboutBloodPool();
            }
          }
        }
        else
        {
          Debug.Log((object) "ForgetAboutBloodPool() was called from this place in the code. 2");
          this.ForgetAboutBloodPool();
        }
      }
      if (this.ReturningMisplacedWeapon)
      {
        if (this.ReturningMisplacedWeaponPhase == 0)
        {
          this.CharacterAnimation.CrossFade(this.PickUpAnim);
          if ((this.Club == ClubType.Council || this.Teacher) && (double) this.CharacterAnimation[this.PickUpAnim].time >= 0.33333000540733337)
            this.Handkerchief.SetActive(true);
          if ((double) this.CharacterAnimation[this.PickUpAnim].time >= 2.0)
          {
            this.BloodPool.parent = this.RightHand;
            this.BloodPool.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            this.BloodPool.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            if (this.Club != ClubType.Council && !this.Teacher)
              this.BloodPool.GetComponent<WeaponScript>().FingerprintID = this.StudentID;
          }
          if ((double) this.CharacterAnimation[this.PickUpAnim].time >= (double) this.CharacterAnimation[this.PickUpAnim].length)
          {
            this.CurrentDestination = this.BloodPool.GetComponent<WeaponScript>().Origin;
            this.Pathfinding.target = this.BloodPool.GetComponent<WeaponScript>().Origin;
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.Pathfinding.speed = this.WalkSpeed;
            this.Hurry = false;
            ++this.ReturningMisplacedWeaponPhase;
          }
        }
        else
        {
          this.CharacterAnimation.CrossFade(this.WalkAnim);
          if ((double) this.DistanceToDestination < 1.1000000238418579)
            this.ReturnMisplacedWeapon();
        }
      }
      if (this.SentToLocker && !this.CheckingNote)
        this.CharacterAnimation.CrossFade(this.RunAnim);
      if (this.Stripping)
      {
        this.CharacterAnimation.CrossFade(this.StripAnim);
        this.Pathfinding.canSearch = false;
        this.Pathfinding.canMove = false;
        if ((double) this.CharacterAnimation[this.StripAnim].time >= 1.5)
        {
          if (this.Schoolwear != 1)
          {
            this.Schoolwear = 1;
            this.ChangeSchoolwear();
            this.WalkAnim = this.OriginalWalkAnim;
          }
          if ((double) this.CharacterAnimation[this.StripAnim].time > (double) this.CharacterAnimation[this.StripAnim].length)
          {
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.Stripping = false;
            this.Routine = true;
          }
        }
      }
      if (this.SenpaiWitnessingRivalDie)
      {
        this.Fleeing = false;
        if ((double) this.DistanceToDestination < 1.0)
        {
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
        }
        if (this.WitnessRivalDiePhase == 0)
        {
          this.CharacterAnimation.CrossFade("witnessPoisoning_00");
          this.MoveTowardsTarget(this.CurrentDestination.position);
          this.Chopsticks[0].SetActive(true);
          this.Chopsticks[1].SetActive(true);
          this.Bento.SetActive(true);
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, 10f * Time.deltaTime);
          if ((double) this.CharacterAnimation["witnessPoisoning_00"].time >= 18.5 && this.Bento.activeInHierarchy)
          {
            this.Chopsticks[0].SetActive(false);
            this.Chopsticks[1].SetActive(false);
            this.Bento.SetActive(false);
            ++this.WitnessRivalDiePhase;
          }
        }
        else if (this.WitnessRivalDiePhase == 1)
        {
          if ((double) this.CharacterAnimation["witnessPoisoning_00"].time >= 22.5)
          {
            this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 0, 8f);
            ++this.WitnessRivalDiePhase;
          }
        }
        else if (this.WitnessRivalDiePhase == 2)
        {
          if ((double) this.CharacterAnimation["witnessPoisoning_00"].time >= (double) this.CharacterAnimation["witnessPoisoning_00"].length)
          {
            this.transform.position = new Vector3(this.Hips.position.x, this.transform.position.y, this.Hips.position.z);
            Physics.SyncTransforms();
            this.CharacterAnimation.Play("senpaiRivalCorpseReaction_00");
            this.TargetDistance = 1.5f;
            ++this.WitnessRivalDiePhase;
            this.RivalDeathTimer = 0.0f;
          }
        }
        else if (this.WitnessRivalDiePhase == 3)
        {
          this.TargetDistance = 1.5f;
          if ((double) this.DistanceToDestination <= (double) this.TargetDistance)
          {
            this.CharacterAnimation.Play("senpaiRivalCorpseReaction_00");
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            if (this.WitnessedCorpse)
            {
              this.transform.LookAt(this.StudentManager.Students[this.StudentManager.RivalID].Head.position);
              this.transform.eulerAngles = new Vector3(0.0f, this.transform.eulerAngles.y - 90f, 0.0f);
            }
          }
          if ((double) this.RivalDeathTimer == 0.0)
            this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 2, 15f);
          this.RivalDeathTimer += Time.deltaTime;
          if ((double) this.CharacterAnimation["senpaiRivalCorpseReaction_00"].time >= (double) this.CharacterAnimation["senpaiRivalCorpseReaction_00"].length)
          {
            if (!this.Phoneless)
            {
              this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 3, 15f);
              this.CharacterAnimation.CrossFade("kneelPhone_00");
              this.SmartPhone.SetActive(true);
            }
            ++this.WitnessRivalDiePhase;
            this.RivalDeathTimer = 0.0f;
          }
        }
        else if (this.WitnessRivalDiePhase == 4)
        {
          this.CharacterAnimation.CrossFade("kneelPhone_00");
          this.RivalDeathTimer += Time.deltaTime;
          if (this.Phoneless)
            this.RivalDeathTimer += 100f;
          if ((double) this.RivalDeathTimer > (double) this.Subtitle.SenpaiRivalDeathReactionClips[3].length)
          {
            this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 4, 10f);
            this.CharacterAnimation.CrossFade("senpaiRivalCorpseCry_00");
            this.SmartPhone.SetActive(false);
            ++this.WitnessRivalDiePhase;
            if (!this.StudentManager.Jammed && !this.Phoneless)
            {
              this.Police.Called = true;
              this.Police.Show = true;
            }
          }
        }
        if ((this.Yandere.Lifting || this.Yandere.Dragging) && (UnityEngine.Object) this.Yandere.TargetStudent == (UnityEngine.Object) this.StudentManager.Students[this.StudentManager.RivalID])
          this.Alarm = 200f;
      }
      if (this.SpecialRivalDeathReaction)
      {
        if (this.WitnessRivalDiePhase == 1)
        {
          if ((double) this.DistanceToDestination <= 1.0)
          {
            this.CharacterAnimation.CrossFade("f02_friendCorpseReaction_00");
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            if (this.StudentID == this.StudentManager.ObstacleID)
              this.transform.LookAt(this.StudentManager.Students[11].Head.position);
            else
              this.transform.LookAt(this.StudentManager.Students[10].Head.position);
            this.transform.eulerAngles = new Vector3(0.0f, this.transform.eulerAngles.y - 90f, 0.0f);
          }
          else
          {
            this.CharacterAnimation.CrossFade(this.RunAnim);
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.Pathfinding.speed = 4f;
          }
          if ((double) this.RivalDeathTimer == 0.0)
          {
            this.Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
            if (this.StudentID == this.StudentManager.ObstacleID)
            {
              Debug.Log((object) "Raibaru is reacting to Osana's corpse.");
              this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 2, 15f);
            }
            else
              this.Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 2, 15f);
          }
          this.RivalDeathTimer += Time.deltaTime;
          if ((double) this.CharacterAnimation["f02_friendCorpseReaction_00"].time >= (double) this.CharacterAnimation["f02_friendCorpseReaction_00"].length)
          {
            if (!this.Phoneless)
            {
              if (this.StudentID == this.StudentManager.ObstacleID)
                this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 3, 10f);
              else
                this.Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 3, 10f);
              this.CharacterAnimation.CrossFade("f02_kneelPhone_00");
              this.SmartPhone.SetActive(true);
            }
            else
            {
              if (this.StudentID == this.StudentManager.ObstacleID)
                this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 4, 10f);
              else
                this.Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 4, 10f);
              this.CharacterAnimation.CrossFade("f02_friendCorpseCry_00");
              ++this.WitnessRivalDiePhase;
            }
            ++this.WitnessRivalDiePhase;
            this.RivalDeathTimer = 0.0f;
          }
        }
        else if (this.WitnessRivalDiePhase == 2)
        {
          this.RivalDeathTimer += Time.deltaTime;
          if ((double) this.RivalDeathTimer > (double) this.Subtitle.OsanaObstacleDeathReactionClips[3].length)
          {
            if (this.StudentID == this.StudentManager.ObstacleID)
              this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 4, 10f);
            else
              this.Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 4, 10f);
            this.CharacterAnimation.CrossFade("f02_friendCorpseCry_00");
            this.SmartPhone.SetActive(false);
            ++this.WitnessRivalDiePhase;
            if (!this.StudentManager.Jammed)
            {
              this.Police.Called = true;
              this.Police.Show = true;
            }
          }
        }
        if ((this.Yandere.Lifting || this.Yandere.Dragging) && (UnityEngine.Object) this.Yandere.TargetStudent == (UnityEngine.Object) this.StudentManager.Students[this.StudentManager.RivalID])
          this.Alarm = 200f;
      }
      if (this.SolvingPuzzle)
      {
        this.PuzzleTimer += Time.deltaTime;
        this.CharacterAnimation.CrossFade(this.PuzzleAnim);
        this.PuzzleCube.transform.Rotate(new Vector3(360f, 360f, 360f), Time.deltaTime * 100f);
        if ((double) this.PuzzleTimer > 30.0)
        {
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.PuzzleTimer = 0.0f;
          this.Routine = true;
          this.DropPuzzle();
        }
      }
      if (this.GoAway)
      {
        this.GoAwayTimer += Time.deltaTime;
        if ((double) this.GoAwayTimer > (double) this.GoAwayLimit)
        {
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.GoAwayLimit = 10f;
          this.GoAwayTimer = 0.0f;
          this.GoAway = false;
          this.Routine = true;
        }
      }
      if (this.TakingOutTrash)
      {
        if (this.TrashPhase == 0)
        {
          this.CurrentDestination = this.TrashDestination;
          this.Pathfinding.target = this.TrashDestination;
          this.EmptyHands();
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.CharacterAnimation.CrossFade(this.WalkAnim);
          ++this.TrashPhase;
        }
        else if (this.TrashPhase == 1)
        {
          if ((double) this.DistanceToDestination < 1.0)
          {
            this.TrashDestination.parent = this.ItemParent;
            this.TrashDestination.localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
            this.TrashDestination.localPosition = new Vector3(0.0f, 0.05f, -0.45f);
            this.CurrentDestination = this.Yandere.Incinerator.transform;
            this.Pathfinding.target = this.Yandere.Incinerator.transform;
            ++this.TrashPhase;
          }
        }
        else if (this.TrashPhase == 2 && (double) this.DistanceToDestination < 2.5)
        {
          this.Yandere.Incinerator.DumpGarbageBag(this.TrashDestination.GetComponent<PickUpScript>());
          this.TakingOutTrash = false;
          this.Routine = true;
        }
      }
      if (this.FocusOnYandere)
      {
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      }
      else
      {
        if (!this.FocusOnStudent)
          return;
        this.CharacterAnimation.CrossFade(this.LeanAnim);
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.WeirdStudent.position.x, this.transform.position.y, this.WeirdStudent.position.z) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      }
    }
  }

  private void UpdateVisibleCorpses()
  {
    this.VisibleCorpses.Clear();
    for (this.ID = 0; this.ID < this.Police.Corpses; ++this.ID)
    {
      RagdollScript corpse = this.Police.CorpseList[this.ID];
      if ((UnityEngine.Object) corpse != (UnityEngine.Object) null && !corpse.Hidden && !corpse.Concealed)
      {
        Collider allCollider = corpse.AllColliders[0];
        bool flag1 = false;
        if ((double) allCollider.transform.position.y < (double) this.transform.position.y + 4.0)
          flag1 = true;
        if (flag1 && this.CanSeeObject(allCollider.gameObject, allCollider.transform.position, this.CorpseLayers, (int) this.Mask))
        {
          RagdollScript component = allCollider.gameObject.transform.parent.parent.parent.GetComponent<RagdollScript>();
          bool flag2 = false;
          if (!component.Concealed)
            flag2 = true;
          if ((UnityEngine.Object) component != (UnityEngine.Object) null && !component.Concealed)
          {
            this.VisibleCorpses.Add(component.StudentID);
            this.Corpse = component;
            if (this.Club == ClubType.Delinquent && this.Corpse.Student.Club == ClubType.Bully)
            {
              this.ScaredAnim = this.EvilWitnessAnim;
              this.Persona = PersonaType.Evil;
            }
            if (this.Persona == PersonaType.TeachersPet && (UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) null && !this.Police.Called)
            {
              this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
              this.StudentManager.CorpseLocation.LookAt(this.transform.position);
              this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward * -1f);
              this.StudentManager.LowerCorpsePosition();
              this.StudentManager.Reporter = this;
              this.ReportingMurder = true;
              this.DetermineCorpseLocation();
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              this.Pathfinding.speed = 0.0f;
              this.Fleeing = false;
            }
          }
        }
      }
    }
  }

  private void UpdateVisibleBlood()
  {
    for (this.ID = 0; this.ID < this.StudentManager.Blood.Length && (UnityEngine.Object) this.BloodPool == (UnityEngine.Object) null; ++this.ID)
    {
      Collider collider = this.StudentManager.Blood[this.ID];
      if ((UnityEngine.Object) collider != (UnityEngine.Object) null && (double) Vector3.Distance(this.transform.position, collider.transform.position) < (double) this.VisionDistance && this.CanSeeObject(collider.gameObject, collider.transform.position))
      {
        this.BloodPool = collider.transform;
        this.WitnessedBloodPool = true;
        if (this.Club != ClubType.Delinquent && (UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) null && !this.Police.Called && !this.LostTeacherTrust)
        {
          this.StudentManager.BloodLocation.position = this.BloodPool.position;
          this.StudentManager.BloodLocation.LookAt(new Vector3(this.transform.position.x, this.StudentManager.BloodLocation.position.y, this.transform.position.z));
          this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward * -1f);
          this.StudentManager.LowerBloodPosition();
          this.StudentManager.BloodReporter = this;
          this.ReportingBlood = true;
          Debug.Log((object) (this.Name + " has just appointed themself as a BloodReporter."));
          this.DetermineBloodLocation();
        }
      }
    }
  }

  private void UpdateVisibleLimbs()
  {
    for (this.ID = 0; this.ID < this.StudentManager.Limbs.Length && (UnityEngine.Object) this.BloodPool == (UnityEngine.Object) null; ++this.ID)
    {
      Collider limb = this.StudentManager.Limbs[this.ID];
      if ((UnityEngine.Object) limb != (UnityEngine.Object) null && this.CanSeeObject(limb.gameObject, limb.transform.position))
      {
        this.BloodPool = limb.transform;
        this.WitnessedLimb = true;
        if (this.Club != ClubType.Delinquent && (UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) null && !this.Police.Called && !this.LostTeacherTrust)
        {
          this.StudentManager.BloodLocation.position = this.BloodPool.position;
          this.StudentManager.BloodLocation.LookAt(new Vector3(this.transform.position.x, this.StudentManager.BloodLocation.position.y, this.transform.position.z));
          this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward * -1f);
          this.StudentManager.LowerBloodPosition();
          this.StudentManager.BloodReporter = this;
          this.ReportingBlood = true;
          this.DetermineBloodLocation();
        }
      }
    }
  }

  private void UpdateVisibleWeapons()
  {
    for (this.ID = 0; this.ID < this.Yandere.WeaponManager.Weapons.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.Yandere.WeaponManager.Weapons[this.ID] != (UnityEngine.Object) null && (this.Yandere.WeaponManager.Weapons[this.ID].Blood.enabled || this.Yandere.WeaponManager.Weapons[this.ID].Misplaced && (UnityEngine.Object) this.Yandere.WeaponManager.Weapons[this.ID].transform.parent == (UnityEngine.Object) null))
      {
        if (!((UnityEngine.Object) this.BloodPool == (UnityEngine.Object) null))
          break;
        if ((UnityEngine.Object) this.Yandere.WeaponManager.Weapons[this.ID].transform != (UnityEngine.Object) this.LastSuspiciousObject && (UnityEngine.Object) this.Yandere.WeaponManager.Weapons[this.ID].transform != (UnityEngine.Object) this.LastSuspiciousObject2 && this.Yandere.WeaponManager.Weapons[this.ID].enabled)
        {
          Collider collider = this.Yandere.WeaponManager.Weapons[this.ID].MyCollider;
          if ((UnityEngine.Object) collider != (UnityEngine.Object) null && this.CanSeeObject(collider.gameObject, collider.transform.position))
          {
            if (!this.StudentManager.Eighties && this.StudentID == 48 && this.Yandere.WeaponManager.Weapons[this.ID].WeaponID == 12)
            {
              Debug.Log((object) (this.Name + " could have reacted to a dropped dumbbell, but isn't going to."));
              break;
            }
            this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
            Debug.Log((object) (this.Name + " has seen a dropped weapon on the ground."));
            this.CheckForBento();
            this.BloodPool = collider.transform;
            if (this.Yandere.WeaponManager.Weapons[this.ID].Blood.enabled)
              this.WitnessedBloodyWeapon = true;
            this.WitnessedWeapon = true;
            if (this.Club != ClubType.Delinquent && (UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) null && !this.Police.Called && !this.LostTeacherTrust)
            {
              this.StudentManager.BloodLocation.position = this.BloodPool.position;
              this.StudentManager.BloodLocation.LookAt(new Vector3(this.transform.position.x, this.StudentManager.BloodLocation.position.y, this.transform.position.z));
              this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward * -1f);
              this.StudentManager.LowerBloodPosition();
              this.StudentManager.BloodReporter = this;
              this.ReportingBlood = true;
              this.BeforeReturnAnim = this.WalkAnim;
              this.WalkAnim = this.OriginalWalkAnim;
              this.WasHurrying = this.Hurry;
              this.DetermineBloodLocation();
            }
          }
        }
      }
    }
  }

  private void UpdateVision()
  {
    bool flag1 = false;
    if (this.Distracted)
    {
      flag1 = true;
      if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this)
        flag1 = false;
      if ((double) this.AmnesiaTimer > 0.0)
      {
        this.AmnesiaTimer = Mathf.MoveTowards(this.AmnesiaTimer, 0.0f, Time.deltaTime);
        if ((double) this.AmnesiaTimer == 0.0)
          this.Distracted = false;
      }
    }
    if (!flag1)
    {
      bool flag2 = true;
      if ((UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) null && (UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) this)
        flag2 = false;
      if (((this.WitnessedMurder || this.CheckingNote || this.Shoving || this.Slave ? 0 : (!this.Struggling ? 1 : 0)) & (flag2 ? 1 : 0)) != 0 && !this.Drownable && !this.Fighting)
      {
        if (this.Police.Corpses > 0)
        {
          if (!this.Blind && !this.AwareOfCorpse)
            this.UpdateVisibleCorpses();
          if (this.VisibleCorpses.Count > 0)
          {
            if (!this.WitnessedCorpse)
            {
              Debug.Log((object) (this.Name + " discovered the corpse of " + this.Corpse.Student.Name));
              this.Fleeing = false;
              this.Police.StudentFoundCorpse = true;
              this.SawCorpseThisFrame = true;
              if (this.Club == ClubType.Delinquent && this.Corpse.Student.Club == ClubType.Bully)
              {
                Debug.Log((object) (this.Name + " witnessed the corpse of a bully, specifically."));
                this.FoundEnemyCorpse = true;
              }
              if (this.Persona == PersonaType.Sleuth)
              {
                if (this.Sleuthing)
                {
                  this.Persona = PersonaType.PhoneAddict;
                  this.SmartPhone.SetActive(true);
                }
                else
                  this.Persona = !this.StudentManager.Eighties ? PersonaType.SocialButterfly : PersonaType.LandlineUser;
              }
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              if (!this.Male)
                this.CharacterAnimation["f02_smile_00"].weight = 0.0f;
              Debug.Log((object) "Manually setting Alarm to 200.");
              this.AlarmTimer = 0.0f;
              this.Alarm = 200f;
              this.LastKnownCorpse = this.Corpse.AllColliders[0].transform.position;
              this.WitnessedBloodyWeapon = false;
              this.WitnessedBloodPool = false;
              this.WitnessedSomething = false;
              this.WitnessedWeapon = false;
              this.WitnessedCorpse = true;
              this.WitnessedLimb = false;
              this.Yandere.NotificationManager.CustomText = this.Name + " found a corpse!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
              this.SetOutlinesYellow();
              this.SummonWitnessCamera();
              if (this.ReturningMisplacedWeapon)
                this.DropMisplacedWeapon();
              if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this)
              {
                this.StudentManager.BloodReporter = (StudentScript) null;
                this.ReportingBlood = false;
                this.Fleeing = false;
              }
              if (this.Distracting || this.ResumeDistracting)
              {
                Debug.Log((object) (this.Name + " should be forgetting about ''Distracting'' right now."));
                if ((UnityEngine.Object) this.DistractionTarget != (UnityEngine.Object) null)
                  this.DistractionTarget.TargetedForDistraction = false;
                this.ResumeDistracting = false;
                this.Distracting = false;
              }
              this.InvestigatingBloodPool = false;
              this.Investigating = false;
              this.EatingSnack = false;
              this.Threatened = false;
              this.SentHome = false;
              this.Routine = false;
              this.CheckingNote = false;
              this.SentToLocker = false;
              this.Meeting = false;
              this.MeetTimer = 0.0f;
              if (this.Persona == PersonaType.Spiteful && (this.Bullied && this.Corpse.Student.Club == ClubType.Bully || this.Corpse.Student.Bullied))
              {
                this.ScaredAnim = this.EvilWitnessAnim;
                this.Persona = PersonaType.Evil;
              }
              this.ForgetRadio();
              if (this.Wet)
                this.Persona = PersonaType.Loner;
              if (this.Corpse.Disturbing)
              {
                if ((double) Vector3.Distance(this.transform.position, this.Corpse.transform.position) < 5.0)
                {
                  this.WalkBackTimer = 5f;
                  this.WalkBack = true;
                  this.Routine = false;
                }
                if (this.Corpse.BurningAnimation || this.Corpse.ElectrocutionAnimation)
                  this.Hesitation = 0.5f;
                if (this.Corpse.MurderSuicideAnimation)
                {
                  this.WitnessedMindBrokenMurder = true;
                  this.Hesitation = 1f;
                }
                if (this.Corpse.ChokingAnimation)
                  this.Hesitation = 0.6f;
              }
              if (this.Corpse.Student.Electrified)
              {
                Debug.Log((object) (this.Name + " is witnessing a person being electrocuted."));
                if (this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
                {
                  Debug.Log((object) "Yandere-chan is in the vicinity.");
                  if ((double) this.Yandere.PotentiallyMurderousTimer > 0.0)
                  {
                    Debug.Log((object) "Yandere-chan just threw a car battery, which means she just deliberately killed someone!");
                    this.WitnessMurder();
                  }
                }
              }
              if (this.Corpse.Student.Burning)
              {
                Debug.Log((object) (this.Name + " is witnessing a person burn to death."));
                if (this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
                {
                  Debug.Log((object) "Yandere-chan is in the vicinity.");
                  if ((double) this.Yandere.PotentiallyMurderousTimer > 0.0)
                  {
                    Debug.Log((object) "Yandere-chan just ran into the victim while holding a flame, which means she just deliberately killed someone!");
                    this.WitnessMurder();
                  }
                }
              }
              this.StudentManager.UpdateMe(this.StudentID);
              if (!this.Teacher)
                this.SpawnAlarmDisc();
              else
                this.AlarmTimer = 3f;
              ParticleSystem.EmissionModule emission = this.Hearts.emission;
              if (this.Talking)
              {
                this.DialogueWheel.End();
                emission.enabled = false;
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                this.Obstacle.enabled = false;
                this.Talk.enabled = false;
                this.Talking = false;
                this.Waiting = false;
                this.StudentManager.EnablePrompts();
              }
              if (this.Following)
              {
                emission.enabled = false;
                this.FollowCountdown.gameObject.SetActive(false);
                this.Yandere.Follower = (StudentScript) null;
                --this.Yandere.Followers;
                this.Following = false;
              }
            }
            if (this.Corpse.Dragged || this.Corpse.Dumped)
            {
              if (this.Teacher)
                this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, UnityEngine.Random.Range(1, 3), 3f);
              if (!this.Yandere.Egg && !this.Yandere.Invisible)
                this.WitnessMurder();
            }
          }
        }
        if (this.VisibleCorpses.Count == 0 && !this.WitnessedCorpse)
        {
          if ((double) this.WitnessCooldownTimer > 0.0)
            this.WitnessCooldownTimer = Mathf.MoveTowards(this.WitnessCooldownTimer, 0.0f, Time.deltaTime);
          else if ((this.StudentID == this.StudentManager.CurrentID || this.Persona == PersonaType.Strict && this.Fleeing) && !this.Wet && !this.Guarding && !this.IgnoreBlood && !this.InvestigatingPossibleDeath && !this.Spraying && !this.Emetic && !this.Threatened && !this.Sedated && !this.Headache && !this.SentHome && !this.Slave && !this.Talking && !this.Confessing && !this.SentToLocker && !this.Meeting && !this.IgnoringThingsOnGround && !this.RetreivingMedicine)
          {
            if ((UnityEngine.Object) this.BloodPool == (UnityEngine.Object) null && this.StudentManager.Police.LimbParent.childCount > 0)
              this.UpdateVisibleLimbs();
            if ((UnityEngine.Object) this.BloodPool == (UnityEngine.Object) null && (this.Police.BloodyWeapons > 0 || this.Yandere.WeaponManager.MisplacedWeapons > 0) && !this.InvestigatingPossibleLimb && !this.TakingOutTrash && !this.Alarmed && !this.InEvent && !this.InvestigatingPossibleBlood && !this.ChangingShoes && this.Persona != PersonaType.Violent && ((UnityEngine.Object) this.MyPlate == (UnityEngine.Object) null || (UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent != (UnityEngine.Object) this.RightHand))
              this.UpdateVisibleWeapons();
            if ((UnityEngine.Object) this.BloodPool == (UnityEngine.Object) null)
            {
              if (this.StudentManager.Police.BloodParent.childCount > 0 && !this.InvestigatingPossibleLimb)
                this.UpdateVisibleBlood();
            }
            else if (!this.WitnessedSomething)
            {
              Debug.Log((object) (this.Name + " saw something suspicious on the ground."));
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              if (!this.Male)
                this.CharacterAnimation["f02_smile_00"].weight = 0.0f;
              Debug.Log((object) "Manually setting Alarm to 200.");
              this.AlarmTimer = 0.0f;
              this.Alarm = 200f;
              this.LastKnownBlood = this.BloodPool.transform.position;
              this.NotAlarmedByYandereChan = true;
              this.WitnessedSomething = true;
              this.Investigating = false;
              this.EatingSnack = false;
              this.Threatened = false;
              this.SentHome = false;
              this.Routine = false;
              this.ForgetRadio();
              this.StudentManager.UpdateMe(this.StudentID);
              if (this.Teacher)
                this.AlarmTimer = 3f;
              ParticleSystem.EmissionModule emission = this.Hearts.emission;
              if (this.Talking)
              {
                this.DialogueWheel.End();
                emission.enabled = false;
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                this.Obstacle.enabled = false;
                this.Talk.enabled = false;
                this.Talking = false;
                this.Waiting = false;
                this.StudentManager.EnablePrompts();
              }
              if (this.Following)
              {
                emission.enabled = false;
                this.FollowCountdown.gameObject.SetActive(false);
                this.Yandere.Follower = (StudentScript) null;
                --this.Yandere.Followers;
                this.Following = false;
              }
            }
          }
        }
        this.PreviousAlarm = this.Alarm;
        if ((double) this.DistanceToPlayer < (double) this.VisionDistance - (double) this.ChameleonBonus)
        {
          if (!this.Talking && !this.Spraying && !this.SentHome && !this.Slave && !this.Attacked)
          {
            if (!this.Yandere.Noticed && !this.Yandere.Invisible)
            {
              bool flag3 = false;
              if (this.Guarding || this.Fleeing || this.InvestigatingBloodPool && this.WitnessedBloodPool)
                flag3 = true;
              if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious || this.Yandere.Armed && this.Yandere.EquippedWeapon.Bloody || !this.IgnoringPettyActions && this.StudentID > 1 && (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Yandere.PickUp.Suspicious || !this.IgnoringPettyActions && this.StudentID > 1 && (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Yandere.PickUp.CleaningProduct && this.Clock.Period != 5 || this.Guarding && this.Yandere.Mopping && (double) this.Yandere.Mop.Bloodiness > 0.0 || (double) this.Yandere.Bloodiness + (double) this.Yandere.GloveBlood > 0.0 && !this.Yandere.Paint || (double) this.Yandere.Sanity < 33.333000183105469 || this.Yandere.Pickpocketing || this.Yandere.Attacking || this.Yandere.Cauterizing || this.Yandere.Struggling || this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Dragging && this.Yandere.CurrentRagdoll.Concealed && this.Clock.Period != 5 || !this.IgnoringPettyActions && this.Yandere.Lewd || this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Carrying && this.Yandere.CurrentRagdoll.Concealed && this.Clock.Period != 5 || this.Yandere.Medusa || this.Yandere.Poisoning || this.Yandere.Pickpocketing || (double) this.Yandere.WeaponTimer > 0.0 || this.Yandere.WearingRaincoat || (double) this.Yandere.MurderousActionTimer > 0.0 || !this.IgnoringPettyActions && this.Yandere.Schoolwear == 2 && (double) this.Yandere.transform.position.z < 30.0 || !this.IgnoringPettyActions && (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && (UnityEngine.Object) this.Yandere.PickUp.BodyPart != (UnityEngine.Object) null && !this.Yandere.PickUp.Garbage || !this.IgnoringPettyActions && (double) this.Yandere.SuspiciousActionTimer > 0.0 || !this.IgnoringPettyActions && this.Yandere.Laughing && (double) this.Yandere.LaughIntensity > 15.0 || !this.IgnoringPettyActions && this.Yandere.Stance.Current == StanceType.Crouching || !this.IgnoringPettyActions && this.Yandere.Stance.Current == StanceType.Crawling || !this.IgnoringPettyActions && this.Yandere.Trespassing || this.Private && this.Yandere.Eavesdropping || this.Teacher && !this.WitnessedCorpse && this.Yandere.Trespassing || this.Teacher && !this.IgnoringPettyActions && this.Yandere.Rummaging || !this.IgnoringPettyActions && (double) this.Yandere.TheftTimer > 0.0 || this.StudentID == 1 && this.Yandere.NearSenpai && !this.Yandere.Talking || this.Yandere.Eavesdropping && this.Private || !this.IgnoringPettyActions && !this.StudentManager.CombatMinigame.Practice && this.Yandere.DelinquentFighting && this.StudentID != 10 && this.StudentManager.CombatMinigame.Path < 4 && !this.StudentManager.CombatMinigame.Practice && !this.Yandere.SeenByAuthority || flag3 && (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && (UnityEngine.Object) this.Yandere.PickUp.Mop != (UnityEngine.Object) null && (double) this.Yandere.PickUp.Mop.Bloodiness > 50.0 || !this.IgnoringPettyActions & flag3 && (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && (UnityEngine.Object) this.Yandere.PickUp.BodyPart != (UnityEngine.Object) null && !this.Yandere.PickUp.Garbage || (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence || !this.IgnoringPettyActions && this.AnnoyedByRadio > 1 && (double) this.Yandere.PotentiallyAnnoyingTimer > 0.0 || !this.IgnoringPettyActions && this.AnnoyedByGiggles > 4 && (double) this.Yandere.PotentiallyAnnoyingTimer > 0.0)
              {
                bool flag4 = false;
                if ((double) this.Yandere.transform.position.y < (double) this.transform.position.y + 4.0)
                  flag4 = true;
                Vector3 headPosition = this.Yandere.HeadPosition;
                if (flag4 && this.CanSeeObject(this.Yandere.gameObject, headPosition) || this.AwareOfMurder)
                {
                  this.YandereVisible = true;
                  if (this.Yandere.Attacking || this.Yandere.Cauterizing || this.Yandere.Struggling || this.WitnessedCorpse && this.Yandere.NearBodies > 0 && (double) this.Yandere.Bloodiness + (double) this.Yandere.GloveBlood > 0.0 && !this.Yandere.Paint || this.WitnessedCorpse && this.Yandere.NearBodies > 0 && this.Yandere.Armed || this.WitnessedCorpse && this.Yandere.NearBodies > 0 && (double) this.Yandere.Sanity < 66.666656494140625 || this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed || (double) this.Yandere.MurderousActionTimer > 0.0 || this.Guarding && (double) this.Yandere.Bloodiness + (double) this.Yandere.GloveBlood > 0.0 && !this.Yandere.Paint || this.Guarding && this.Yandere.Armed && this.Yandere.EquippedWeapon.Dangerous || this.Guarding && this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious || this.Guarding && (double) this.Yandere.Sanity < 66.666656494140625 || this.Guarding && this.Yandere.WearingRaincoat || !this.IgnoringPettyActions && !this.StudentManager.CombatMinigame.Practice && this.Club == ClubType.Council && this.Yandere.DelinquentFighting && this.StudentManager.CombatMinigame.Path < 4 && !this.Yandere.SeenByAuthority || !this.StudentManager.CombatMinigame.Practice && this.Teacher && this.Yandere.DelinquentFighting && this.StudentManager.CombatMinigame.Path < 4 && !this.Yandere.SeenByAuthority || flag3 && (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && (UnityEngine.Object) this.Yandere.PickUp.Mop != (UnityEngine.Object) null && (double) this.Yandere.PickUp.Mop.Bloodiness > 0.0 || flag3 && (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && (UnityEngine.Object) this.Yandere.PickUp.BodyPart != (UnityEngine.Object) null && !this.Yandere.PickUp.Garbage || (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Teacher && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence || (double) this.StudentManager.Atmosphere < 0.33333000540733337 && (double) this.Yandere.Bloodiness + (double) this.Yandere.GloveBlood > 0.0 && this.Yandere.Armed)
                  {
                    Debug.Log((object) (this.Name + " is aware that Yandere-chan is doing something murderous."));
                    if (this.Yandere.Hungry || !this.Yandere.Egg)
                    {
                      Debug.Log((object) (this.Name + " has just witnessed a murder!"));
                      if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null)
                      {
                        if (flag3)
                        {
                          if ((UnityEngine.Object) this.Yandere.PickUp.Mop != (UnityEngine.Object) null)
                          {
                            if ((double) this.Yandere.PickUp.Mop.Bloodiness > 0.0)
                            {
                              Debug.Log((object) "This character witnessed Yandere-chan trying to cover up a crime.");
                              this.WitnessedCoverUp = true;
                            }
                          }
                          else if ((UnityEngine.Object) this.Yandere.PickUp.BodyPart != (UnityEngine.Object) null && !this.Yandere.PickUp.Garbage)
                          {
                            Debug.Log((object) "This character witnessed Yandere-chan trying to cover up a crime.");
                            this.WitnessedCoverUp = true;
                          }
                        }
                        if (this.Teacher && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence)
                        {
                          Debug.Log((object) "This character witnessed Yandere-chan trying to cover up a crime.");
                          this.WitnessedCoverUp = true;
                        }
                      }
                      if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
                      {
                        Debug.Log((object) (this.Name + ", a Phone Addict, is deciding what to do."));
                        this.Countdown.gameObject.SetActive(false);
                        this.Countdown.Sprite.fillAmount = 1f;
                        this.WitnessedMurder = false;
                        this.Fleeing = false;
                        if (this.CrimeReported)
                        {
                          Debug.Log((object) (this.Name + "'s ''CrimeReported'' was ''true'', but we're seeing it to ''false''."));
                          this.CrimeReported = false;
                        }
                      }
                      if (!this.Yandere.DelinquentFighting)
                        this.NoBreakUp = true;
                      else if (this.Teacher || this.Club == ClubType.Council)
                        this.Yandere.SeenByAuthority = true;
                      this.WitnessMurder();
                    }
                  }
                  else if (!this.Fleeing && (!this.Alarmed || this.CanStillNotice))
                  {
                    if (this.Yandere.Rummaging || (double) this.Yandere.TheftTimer > 0.0)
                      this.Alarm = 200f;
                    if ((double) this.Yandere.WeaponTimer > 0.0)
                      this.Alarm = 200f;
                    if ((double) this.IgnoreTimer == 0.0 || this.CanStillNotice)
                    {
                      if (this.Teacher)
                        this.StudentManager.TutorialWindow.ShowTeacherMessage = true;
                      int num = 1;
                      if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious && (this.Yandere.EquippedWeapon.Type == WeaponType.Bat || this.Yandere.EquippedWeapon.Type == WeaponType.Katana || this.Yandere.EquippedWeapon.Type == WeaponType.Saw || this.Yandere.EquippedWeapon.Type == WeaponType.Weight))
                        num = 5;
                      if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
                      {
                        this.Alarm += Time.deltaTime * (100f / this.DistanceToPlayer) * this.Paranoia * this.Perception * (float) num;
                        if (this.Yandere.SneakingShot)
                          this.Alarm += (float) ((double) Time.deltaTime * (100.0 / (double) this.DistanceToPlayer) * (double) this.Paranoia * (double) this.Perception * (double) num * 2.0);
                        if ((double) this.Yandere.SuspiciousActionTimer > 0.0 || (double) this.Yandere.PotentiallyAnnoyingTimer > 0.0)
                        {
                          Debug.Log((object) (this.Name + " witnessed something suspicious or annoying."));
                          this.Alarm += (float) ((double) Time.deltaTime * (100.0 / (double) this.DistanceToPlayer) * (double) this.Paranoia * (double) this.Perception * (double) num * 9.0);
                          if (this.Yandere.CreatingBucketTrap)
                          {
                            Debug.Log((object) (this.Name + " just witnessed the player creating a bucket trap."));
                            this.WillRemoveBucket = true;
                          }
                          if (this.Yandere.CreatingTripwireTrap)
                            this.WillRemoveTripwire = true;
                        }
                      }
                      else
                        this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
                      if (this.StudentID == 1 && this.Yandere.TimeSkipping)
                        this.Clock.EndTimeSkip();
                    }
                  }
                }
                else
                  this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
              }
              else
                this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
            }
            else
              this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
          }
          else
            this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
        }
        else
          this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
        if ((double) this.PreviousAlarm > (double) this.Alarm && (double) this.Alarm < 100.0)
          this.YandereVisible = false;
        if (this.Teacher && !this.Yandere.Medusa && this.Yandere.Egg)
          this.Alarm = 0.0f;
        if ((double) this.Alarm <= 100.0)
          return;
        this.BecomeAlarmed();
      }
      else
        this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
    }
    else
    {
      if (!((UnityEngine.Object) this.Distraction != (UnityEngine.Object) null))
        return;
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Distraction.position.x, this.transform.position.y, this.Distraction.position.z) - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      if (!((UnityEngine.Object) this.Distractor != (UnityEngine.Object) null))
        return;
      if (this.Distractor.Club == ClubType.Cooking && this.Distractor.ClubActivityPhase > 0 && this.Distractor.Actions[this.Distractor.Phase] == StudentActionType.ClubAction)
      {
        this.CharacterAnimation.CrossFade(this.PlateEatAnim);
        if ((double) this.CharacterAnimation[this.PlateEatAnim].time > 6.83333)
        {
          this.Fingerfood[this.Distractor.StudentID - 20].SetActive(false);
        }
        else
        {
          if ((double) this.CharacterAnimation[this.PlateEatAnim].time <= 2.66666)
            return;
          this.Fingerfood[this.Distractor.StudentID - 20].SetActive(true);
        }
      }
      else
      {
        this.CharacterAnimation.CrossFade(this.RandomAnim);
        if ((double) this.CharacterAnimation[this.RandomAnim].time < (double) this.CharacterAnimation[this.RandomAnim].length)
          return;
        this.PickRandomAnim();
      }
    }
  }

  public void BecomeAlarmed()
  {
    Debug.Log((object) (this.Name + " just fired the BecomeAlarmed() function."));
    if (this.Yandere.Medusa && this.YandereVisible)
    {
      this.TurnToStone();
    }
    else
    {
      if (this.Investigating && !this.HeardScream)
      {
        Debug.Log((object) (this.Name + " was investigating prior to being alarmed, so they are now ending their investigation."));
        this.StopInvestigating();
      }
      if (!this.Alarmed || this.DiscCheck)
      {
        bool flag = false;
        if (this.CurrentAction == StudentActionType.Sunbathe && this.SunbathePhase > 2)
        {
          this.SunbathePhase = 2;
          flag = true;
        }
        if (this.ReturningMisplacedWeapon)
        {
          this.DropMisplacedWeapon();
          this.ReturnToRoutineAfter = true;
        }
        if ((UnityEngine.Object) this.DistractionTarget != (UnityEngine.Object) null)
          this.DistractionTarget.TargetedForDistraction = false;
        if (this.SolvingPuzzle)
          this.DropPuzzle();
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        this.Pathfinding.canSearch = false;
        this.Pathfinding.canMove = false;
        this.CameraReacting = false;
        this.CanStillNotice = false;
        this.Distracting = false;
        this.Distracted = false;
        this.DiscCheck = false;
        this.Reacted = false;
        this.Routine = false;
        this.Alarmed = true;
        this.PuzzleTimer = 0.0f;
        this.ReadPhase = 0;
        if (!this.Male)
          this.HorudaCollider.gameObject.SetActive(false);
        this.BountyCollider.SetActive(false);
        if (this.YandereVisible && (UnityEngine.Object) this.Yandere.Mask == (UnityEngine.Object) null)
          this.Witness = true;
        this.EmptyHands();
        if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless && !flag || this.Persona == PersonaType.Sleuth || this.StudentID == 20)
          this.SmartPhone.SetActive(true);
        if (this.Club == ClubType.Cooking && this.Actions[this.Phase] == StudentActionType.ClubAction && this.ClubActivityPhase == 1 && !this.WitnessedCorpse)
        {
          Debug.Log((object) ("The game believes that " + this.Name + " did not witness a corpse; ''ResumeDistracting'' is being set to ''true''."));
          this.ResumeDistracting = true;
          this.MyPlate.gameObject.SetActive(true);
        }
        if (this.TakingOutTrash && !this.WitnessedCorpse)
          this.ResumeTakingOutTrash = true;
        this.SpeechLines.Stop();
        this.StopPairing();
        if (this.Witnessed != StudentWitnessType.Weapon && this.Witnessed != StudentWitnessType.Eavesdropping)
          this.PreviouslyWitnessed = this.Witnessed;
        if ((double) this.DistanceToDestination < 5.0 && (this.Actions[this.Phase] == StudentActionType.Graffiti || this.Actions[this.Phase] == StudentActionType.Bully))
        {
          this.StudentManager.NoBully[this.BullyID] = true;
          this.KilledMood = true;
        }
        if (this.WitnessedCorpse && !this.WitnessedMurder)
        {
          this.Witnessed = StudentWitnessType.Corpse;
          this.EyeShrink = 0.9f;
        }
        else if (this.WitnessedLimb)
          this.Witnessed = StudentWitnessType.SeveredLimb;
        else if (this.WitnessedBloodyWeapon)
          this.Witnessed = StudentWitnessType.BloodyWeapon;
        else if (this.WitnessedBloodPool)
          this.Witnessed = StudentWitnessType.BloodPool;
        else if (this.WitnessedWeapon)
          this.Witnessed = StudentWitnessType.DroppedWeapon;
        else if (this.StudentManager.TutorialActive)
          this.Witnessed = StudentWitnessType.Tutorial;
        if (this.SawCorpseThisFrame)
          this.YandereVisible = false;
        if (this.TemporarilyBlind)
          this.YandereVisible = false;
        if (this.YandereVisible && !this.NotAlarmedByYandereChan)
        {
          if (!this.Injured && this.Persona == PersonaType.Violent && this.Yandere.Armed && !this.WitnessedCorpse && !this.RespectEarned || this.Persona == PersonaType.Violent && this.Yandere.DelinquentFighting)
          {
            this.Subtitle.Speaker = this;
            this.Subtitle.UpdateLabel(SubtitleType.DelinquentWeaponReaction, 0, 3f);
            this.ThreatDistance = this.DistanceToPlayer;
            this.CheerTimer = UnityEngine.Random.Range(1f, 2f);
            this.SmartPhone.SetActive(false);
            this.Threatened = true;
            this.ThreatPhase = 1;
            this.ForgetGiggle();
          }
          Debug.Log((object) (this.Name + " saw Yandere-chan doing something bad."));
          if (this.Yandere.CreatingBucketTrap)
          {
            Debug.Log((object) (this.Name + " just witnessed the player creating a bucket trap."));
            this.WillRemoveBucket = true;
          }
          if (this.Yandere.CreatingTripwireTrap)
          {
            Debug.Log((object) (this.Name + " just witnessed the player creating a tripwire trap."));
            this.WillRemoveTripwire = true;
          }
          this.FocusOnYandere = true;
          if (this.StudentID > 1)
            ++this.Yandere.Alerts;
          if (this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed || (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && (bool) (UnityEngine.Object) this.Yandere.PickUp.BodyPart && !this.Yandere.PickUp.Garbage)
          {
            if (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed)
              this.Corpse = this.Yandere.CurrentRagdoll;
            if (!this.Yandere.Egg)
              this.WitnessMurder();
          }
          else if (this.Witnessed != StudentWitnessType.Corpse)
            this.DetermineWhatWasWitnessed();
          if (this.Teacher && this.WitnessedCorpse)
            this.Concern = 1;
          if (this.StudentID == 1 && (UnityEngine.Object) this.Yandere.Mask == (UnityEngine.Object) null && !this.Yandere.Egg)
          {
            if (this.Concern == 5)
            {
              Debug.Log((object) "Senpai noticed stalking or lewdness.");
              this.SenpaiNoticed();
              if (this.Witnessed == StudentWitnessType.Stalking || this.Witnessed == StudentWitnessType.Lewd)
              {
                this.CharacterAnimation.CrossFade(this.IdleAnim);
                this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
              }
              else
              {
                Debug.Log((object) "Senpai entered his scared animation.");
                this.CharacterAnimation.CrossFade(this.ScaredAnim);
                this.CharacterAnimation["scaredFace_00"].weight = 1f;
              }
              this.CameraEffects.MurderWitnessed();
            }
            else
            {
              this.CharacterAnimation.CrossFade("suspicious_00");
              this.CameraEffects.Alarm();
            }
          }
          else if (!this.Teacher)
          {
            this.CameraEffects.Alarm();
          }
          else
          {
            Debug.Log((object) (this.Name + ", using the Teacher Persona, has just witnessed Yandere-chan doing something bad."));
            if (!this.Fleeing)
            {
              if (this.Concern < 5)
                this.CameraEffects.Alarm();
              else if (!this.Yandere.Struggling && !this.StudentManager.PinningDown)
              {
                this.SenpaiNoticed();
                this.CameraEffects.MurderWitnessed();
              }
            }
            else
            {
              this.PersonaReaction();
              this.AlarmTimer = 0.0f;
              if (this.Concern < 5)
                this.CameraEffects.Alarm();
              else
                this.CameraEffects.MurderWitnessed();
            }
          }
          if (!this.Teacher && this.Club != ClubType.Delinquent && this.Witnessed == this.PreviouslyWitnessed)
            this.RepeatReaction = true;
          if ((UnityEngine.Object) this.Yandere.Mask == (UnityEngine.Object) null)
          {
            this.RepDeduction = 0.0f;
            this.CalculateReputationPenalty();
            if ((double) this.RepDeduction >= 0.0)
              this.RepLoss -= this.RepDeduction;
            this.Reputation.PendingRep -= this.RepLoss * this.Paranoia;
            this.PendingRep -= this.RepLoss * this.Paranoia;
          }
          if ((UnityEngine.Object) this.ToiletEvent != (UnityEngine.Object) null && this.ToiletEvent.EventDay == DayOfWeek.Monday)
            this.ToiletEvent.EndEvent();
        }
        else if (!this.WitnessedCorpse)
        {
          if (this.Yandere.Caught)
          {
            if ((UnityEngine.Object) this.Yandere.Mask == (UnityEngine.Object) null)
            {
              if (this.Yandere.Pickpocketing)
              {
                this.Witnessed = StudentWitnessType.Pickpocketing;
                this.RepLoss += 10f;
              }
              else
                this.Witnessed = StudentWitnessType.Theft;
              this.RepDeduction = 0.0f;
              this.CalculateReputationPenalty();
              if ((double) this.RepDeduction >= 0.0)
                this.RepLoss -= this.RepDeduction;
              this.Reputation.PendingRep -= this.RepLoss * this.Paranoia;
              this.PendingRep -= this.RepLoss * this.Paranoia;
            }
          }
          else if (this.WitnessedLimb)
            this.Witnessed = StudentWitnessType.SeveredLimb;
          else if (this.WitnessedBloodyWeapon)
            this.Witnessed = StudentWitnessType.BloodyWeapon;
          else if (this.WitnessedBloodPool)
            this.Witnessed = StudentWitnessType.BloodPool;
          else if (this.WitnessedWeapon)
          {
            this.Witnessed = StudentWitnessType.DroppedWeapon;
          }
          else
          {
            this.Witnessed = StudentWitnessType.None;
            this.DiscCheck = true;
            this.Witness = false;
          }
        }
        else
        {
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
        }
      }
      this.NotAlarmedByYandereChan = false;
      this.SawCorpseThisFrame = false;
    }
  }

  private void UpdateDetectionMarker()
  {
    if ((double) this.Alarm < 0.0)
    {
      this.Alarm = 0.0f;
      if (this.Club == ClubType.Council && !this.Yandere.Noticed)
        this.CanStillNotice = true;
    }
    if ((UnityEngine.Object) this.DetectionMarker != (UnityEngine.Object) null)
    {
      if ((double) this.Alarm > 0.0)
      {
        if (!this.DetectionMarker.Tex.enabled)
          this.DetectionMarker.Tex.enabled = true;
        this.DetectionMarker.Tex.transform.localScale = new Vector3(this.DetectionMarker.Tex.transform.localScale.x, (double) this.Alarm <= 100.0 ? this.Alarm / 100f : 1f, this.DetectionMarker.Tex.transform.localScale.z);
        this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, this.Alarm / 100f);
      }
      else
      {
        if ((double) this.DetectionMarker.Tex.color.a == 0.0)
          return;
        this.DetectionMarker.Tex.enabled = false;
        this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0.0f);
      }
    }
    else
      this.SpawnDetectionMarker();
  }

  private void UpdateTalkInput()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      bool flag1 = false;
      if (!this.StudentManager.EmptyDemon)
      {
        if (!this.StudentManager.Eighties && this.StudentID == 10 && this.StudentManager.TaskManager.TaskStatus[46] == 1 && !this.NoMentor && !this.StudentManager.TaskManager.Mentored)
        {
          Debug.Log((object) "Nothing should be stopping her, but what time is it?");
          if (this.Clock.Period == 3 || this.Clock.Period == 5)
          {
            Debug.Log((object) "It's you-can't-mentor-the-martial-arts-club-o-clock.");
            this.Yandere.NotificationManager.CustomText = "Martial Arts Club is not training now";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            flag1 = true;
          }
        }
        else
          flag1 = true;
        if (((double) this.Alarm > 0.0 || (double) this.AlarmTimer > 0.0 || this.Yandere.Armed || this.Yandere.Shoved || this.Waiting || this.InEvent || this.SentHome || this.Threatened || this.Guarding || this.VisitSenpaiDesk || this.Distracted && !this.Drownable || this.StudentID == 1 || this.Yandere.YandereVision || this.TakingOutTrash) && (!this.Slave && !this.BadTime && !this.Yandere.Gazing && !this.FightingSlave || this.Yandere.YandereVision))
        {
          if (this.InEvent || this.VisitSenpaiDesk)
          {
            string str = "She";
            if (this.Male)
              str = "He";
            this.Yandere.NotificationManager.CustomText = str + " is busy with an event right now!";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          else if (this.Guarding)
          {
            string str = "She";
            if (this.Male)
              str = "He";
            this.Yandere.NotificationManager.CustomText = str + " is too scared to talk right now!";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          this.Prompt.Circle[0].fillAmount = 1f;
        }
      }
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        bool flag2 = false;
        if (this.StudentID < 86 && this.Armband.activeInHierarchy && (this.Actions[this.Phase] == StudentActionType.ClubAction || this.Actions[this.Phase] == StudentActionType.SitAndSocialize || this.Actions[this.Phase] == StudentActionType.Socializing || this.Actions[this.Phase] == StudentActionType.Sleuth || this.Actions[this.Phase] == StudentActionType.Lyrics || this.Actions[this.Phase] == StudentActionType.Patrol || this.Actions[this.Phase] == StudentActionType.SitAndEatBento) && ((double) this.DistanceToDestination < 1.0 || (double) this.transform.position.y > (double) this.StudentManager.ClubZones[(int) this.Club].position.y - 2.5 && (double) this.transform.position.y < (double) this.StudentManager.ClubZones[(int) this.Club].position.y + 2.5 && (double) Vector3.Distance(this.transform.position, this.StudentManager.ClubZones[(int) this.Club].position) < (double) this.ClubThreshold || (double) Vector3.Distance(this.transform.position, this.StudentManager.DramaSpots[1].position) < 12.0))
        {
          flag2 = true;
          this.Warned = false;
        }
        bool flag3 = (UnityEngine.Object) this.StudentManager.Students[76] != (UnityEngine.Object) null && this.StudentManager.Students[76].Friend;
        bool flag4 = (UnityEngine.Object) this.StudentManager.Students[77] != (UnityEngine.Object) null && this.StudentManager.Students[77].Friend;
        bool flag5 = (UnityEngine.Object) this.StudentManager.Students[78] != (UnityEngine.Object) null && this.StudentManager.Students[78].Friend;
        bool flag6 = (UnityEngine.Object) this.StudentManager.Students[79] != (UnityEngine.Object) null && this.StudentManager.Students[79].Friend;
        bool flag7 = (UnityEngine.Object) this.StudentManager.Students[80] != (UnityEngine.Object) null && this.StudentManager.Students[80].Friend;
        if (((this.StudentID != 76 || !GameGlobals.BlondeHair || (double) this.Reputation.Reputation >= -33.333328247070313 ? 0 : (this.Yandere.Persona == YanderePersonaType.Tough ? 1 : 0)) & (flag3 ? 1 : 0) & (flag4 ? 1 : 0) & (flag5 ? 1 : 0) & (flag6 ? 1 : 0) & (flag7 ? 1 : 0)) != 0)
        {
          flag2 = true;
          this.Warned = false;
        }
        bool flag8 = false;
        if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Yandere.PickUp.Salty && !this.Indoors)
          flag8 = true;
        bool flag9 = false;
        if (this.Teacher && this.StudentManager.CanSelfReport)
          flag9 = true;
        if (this.StudentManager.Pose)
        {
          this.MyController.enabled = false;
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.Stop = true;
          this.Pose();
        }
        else if (this.BadTime)
        {
          this.Yandere.EmptyHands();
          this.BecomeRagdoll();
          this.Yandere.RagdollPK.connectedBody = this.Ragdoll.AllRigidbodies[5];
          this.Yandere.RagdollPK.connectedAnchor = this.Ragdoll.LimbAnchor[4];
          this.DialogueWheel.PromptBar.ClearButtons();
          this.DialogueWheel.PromptBar.Label[1].text = "Back";
          this.DialogueWheel.PromptBar.UpdateButtons();
          this.DialogueWheel.PromptBar.Show = true;
          this.Yandere.Ragdoll = this.Ragdoll.gameObject;
          this.Yandere.SansEyes[0].SetActive(true);
          this.Yandere.SansEyes[1].SetActive(true);
          this.Yandere.GlowEffect.Play();
          this.Yandere.CanMove = false;
          this.Yandere.PK = true;
          this.DeathType = DeathType.EasterEgg;
        }
        else if (this.StudentManager.Six)
        {
          UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.transform.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity).GetComponent<AlarmDiscScript>().Originator = this;
          AudioSource.PlayClipAtPoint(this.Yandere.SixTakedown, this.transform.position);
          AudioSource.PlayClipAtPoint(this.Yandere.Snarls[UnityEngine.Random.Range(0, this.Yandere.Snarls.Length)], this.transform.position);
          this.Yandere.CharacterAnimation.CrossFade("f02_sixEat_00");
          this.Yandere.TargetStudent = this;
          this.Yandere.FollowHips = true;
          this.Yandere.Attacking = true;
          this.Yandere.CanMove = false;
          this.Yandere.Eating = true;
          this.CharacterAnimation.CrossFade(this.EatVictimAnim);
          this.CharacterAnimation[this.WetAnim].weight = 0.0f;
          this.Pathfinding.enabled = false;
          this.Routine = false;
          this.Dying = true;
          this.Eaten = true;
          this.Yandere.SixTarget = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, this.transform.position, Quaternion.identity).transform;
          this.Yandere.SixTarget.LookAt(this.Yandere.transform.position);
          this.Yandere.SixTarget.Translate(this.Yandere.SixTarget.forward);
        }
        else if (this.Yandere.SpiderGrow)
        {
          if (!this.Eaten && !this.Cosmetic.Empty)
          {
            AudioSource.PlayClipAtPoint(this.Yandere.SixTakedown, this.transform.position);
            AudioSource.PlayClipAtPoint(this.Yandere.Snarls[UnityEngine.Random.Range(0, this.Yandere.Snarls.Length)], this.transform.position);
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EmptyHusk, this.transform.position + this.transform.forward * 0.5f, Quaternion.identity);
            gameObject.GetComponent<EmptyHuskScript>().TargetStudent = this;
            gameObject.transform.LookAt(this.transform.position);
            this.CharacterAnimation.CrossFade(this.EatVictimAnim);
            this.CharacterAnimation[this.WetAnim].weight = 0.0f;
            this.Pathfinding.enabled = false;
            this.Distracted = false;
            this.Routine = false;
            this.Dying = true;
            this.Eaten = true;
            if (this.Investigating)
              this.StopInvestigating();
            if (this.Following)
            {
              this.FollowCountdown.gameObject.SetActive(false);
              this.Yandere.Follower = (StudentScript) null;
              --this.Yandere.Followers;
              this.Following = false;
            }
            UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, this.transform.position, Quaternion.identity);
          }
        }
        else if (this.StudentManager.Gaze)
        {
          this.Yandere.CharacterAnimation.CrossFade("f02_gazerPoint_00");
          this.Yandere.GazerEyes.Attacking = true;
          this.Yandere.TargetStudent = this;
          this.Yandere.GazeAttacking = true;
          this.Yandere.CanMove = false;
          this.Routine = false;
        }
        else if (this.Slave)
        {
          this.Prompt.Circle[0].fillAmount = 1f;
          this.Yandere.TargetStudent = this;
          this.Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
          this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
          this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
          this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
          this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
          this.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
          this.Yandere.PauseScreen.MainMenu.SetActive(false);
          this.Yandere.PauseScreen.Panel.enabled = true;
          this.Yandere.PauseScreen.Sideways = true;
          this.Yandere.PauseScreen.Show = true;
          Time.timeScale = 0.0001f;
          this.Yandere.PromptBar.ClearButtons();
          this.Yandere.PromptBar.Label[1].text = "Cancel";
          this.Yandere.PromptBar.UpdateButtons();
          this.Yandere.PromptBar.Show = true;
        }
        else if (this.FightingSlave)
        {
          this.Yandere.CharacterAnimation.CrossFade("f02_subtleStab_00");
          this.Yandere.SubtleStabbing = true;
          this.Yandere.TargetStudent = this;
          this.Yandere.CanMove = false;
        }
        else if (this.Following)
        {
          this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
          this.Prompt.Label[0].text = "     Talk";
          this.Prompt.Circle[0].fillAmount = 1f;
          this.Hearts.emission.enabled = false;
          this.FollowCountdown.gameObject.SetActive(false);
          this.Yandere.Follower = (StudentScript) null;
          --this.Yandere.Followers;
          this.Following = false;
          this.Routine = true;
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Pathfinding.speed = this.WalkSpeed;
        }
        else if (this.Clock.Period == 2 && !flag9 || this.Clock.Period == 4 && !flag9 || this.StudentID < 90 && (UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) this.Seat)
        {
          Debug.Log((object) "This character won't talk because Class is in session, or because their destination is ''seat''.");
          if (this.Club != ClubType.Delinquent)
            this.Subtitle.UpdateLabel(SubtitleType.ClassApology, 0, 3f);
          else
            this.Subtitle.UpdateLabel(SubtitleType.DelinquentAnnoy, UnityEngine.Random.Range(0, this.Subtitle.DelinquentAnnoyClips.Length), 3f);
          this.Prompt.Circle[0].fillAmount = 1f;
        }
        else if (((this.InEvent || !this.CanTalk || this.GoAway || this.Fleeing || this.Meeting && !this.Drownable || this.Wet || this.TurnOffRadio || this.InvestigatingBloodPool ? 1 : (!((UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null) ? 0 : ((UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand ? 1 : 0))) | (flag8 ? 1 : 0)) != 0 || this.ReturningMisplacedWeapon || this.Actions[this.Phase] == StudentActionType.Bully || this.Actions[this.Phase] == StudentActionType.Graffiti || this.CanTakeSnack && (double) this.IgnoreFoodTimer > 0.0 || !this.StudentManager.Eighties && this.StudentID == 12 || this.Rival && !this.Indoors || (UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null && this.FollowTarget.InEvent)
        {
          this.Subtitle.UpdateLabel(SubtitleType.EventApology, 1, 3f);
          this.Prompt.Circle[0].fillAmount = 1f;
          this.StudentManager.UpdateMe(this.StudentID);
        }
        else if (this.Clock.Period == 3 && this.BusyAtLunch)
        {
          this.Subtitle.UpdateLabel(SubtitleType.SadApology, 1, 3f);
          this.Prompt.Circle[0].fillAmount = 1f;
        }
        else if (this.Warned)
        {
          Debug.Log((object) "This character refuses to speak to Yandere-chan because of a grudge.");
          this.Subtitle.UpdateLabel(SubtitleType.GrudgeRefusal, 0, 3f);
          this.Prompt.Circle[0].fillAmount = 1f;
          if (!this.Male)
            this.CharacterAnimation["f02_smile_00"].weight = 0.0f;
        }
        else if (this.Ignoring)
        {
          this.Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
          this.Prompt.Circle[0].fillAmount = 1f;
        }
        else if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Yandere.PickUp.PuzzleCube)
        {
          if (this.Investigating)
            this.StopInvestigating();
          this.EmptyHands();
          this.Prompt.Circle[0].fillAmount = 1f;
          this.PuzzleCube = this.Yandere.PickUp;
          this.Yandere.EmptyHands();
          this.PuzzleCube.enabled = false;
          this.PuzzleCube.Prompt.Hide();
          this.PuzzleCube.Prompt.enabled = false;
          this.PuzzleCube.MyRigidbody.useGravity = false;
          this.PuzzleCube.MyRigidbody.isKinematic = true;
          this.PuzzleCube.gameObject.transform.parent = this.RightHand;
          this.PuzzleCube.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
          this.PuzzleCube.gameObject.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
          if (this.Male)
          {
            this.PuzzleCube.gameObject.transform.localPosition = new Vector3(0.0f, -0.0466666f, 0.0f);
            this.PuzzleCube.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
          }
          else
          {
            this.PuzzleCube.gameObject.transform.localPosition = new Vector3(0.0f, -0.0266666f, 0.0f);
            this.PuzzleCube.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
          }
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.SolvingPuzzle = true;
          this.Distracted = true;
          this.Routine = false;
        }
        else if (this.Actions[this.Phase] == StudentActionType.LightFire)
        {
          this.Yandere.NotificationManager.CustomText = "She doesn't seem to notice you...";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          this.Prompt.Circle[0].fillAmount = 1f;
        }
        else
        {
          bool flag10 = false;
          if ((double) this.Yandere.Bloodiness + (double) this.Yandere.GloveBlood > 0.0 && !this.Yandere.Paint)
            flag10 = true;
          if (!this.Witness & flag10)
          {
            this.Prompt.Circle[0].fillAmount = 1f;
            this.YandereVisible = true;
            this.Alarm = 200f;
          }
          else
          {
            this.SpeechLines.Stop();
            this.Yandere.TargetStudent = this;
            if (!this.Grudge)
            {
              if (!this.Yandere.StudentManager.TutorialActive)
                this.ClubManager.CheckGrudge(this.Club);
              if (this.StudentID > 89 && this.StudentManager.CanSelfReport)
              {
                Debug.Log((object) "The player has just reported blood/murder to the faculty.");
                this.StudentManager.Reputation.UpdateRep();
                this.Police.SelfReported = true;
                this.StudentManager.Reputation.Portal.EndDay();
              }
              else if (ClubGlobals.GetClubKicked(this.Club) & flag2)
              {
                Debug.Log((object) "Player was kicked out of this club.");
                if (this.ClubManager.ClubGrudge)
                  Debug.Log((object) "Someone in the club hates the player.");
                else
                  Debug.Log((object) "Player never showed up for club activities, got kicked.");
                this.Interaction = StudentInteractionType.ClubGrudge;
                this.TalkTimer = 5f;
                this.Warned = true;
              }
              else if (this.Yandere.Club == this.Club & flag2 && this.ClubManager.ClubGrudge)
              {
                this.Interaction = StudentInteractionType.ClubKick;
                this.ClubManager.ClubsKickedFrom[(int) this.Club] = true;
                this.TalkTimer = 5f;
                this.Warned = true;
              }
              else if (this.CanBeFed)
              {
                this.Interaction = StudentInteractionType.Feeding;
                this.TalkTimer = 10f;
              }
              else if (this.CanTakeSnack)
              {
                this.Yandere.Interaction = YandereInteractionType.GivingSnack;
                this.Yandere.TalkTimer = 3f;
                this.Interaction = StudentInteractionType.Idle;
              }
              else if (this.CanGiveHelp)
              {
                this.Yandere.Interaction = YandereInteractionType.AskingForHelp;
                this.Yandere.TalkTimer = 5f;
                this.Interaction = StudentInteractionType.Idle;
              }
              else if (!this.StudentManager.Eighties && this.StudentID == 10 && this.StudentManager.TaskManager.TaskStatus[46] == 1 && (UnityEngine.Object) this.Yandere.PickUp == (UnityEngine.Object) null && !flag1)
              {
                Debug.Log((object) ("The status of Budo's Task is: " + this.StudentManager.TaskManager.TaskStatus[46].ToString()));
                Debug.Log((object) ("The game thinks that the current period is: " + this.Clock.Period.ToString()));
                if (this.Clock.Period == 3 || this.Clock.Period == 5)
                {
                  this.Yandere.NotificationManager.CustomText = "Martial Arts Club is not training now!";
                  this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                  Debug.Log((object) "HOW THE FUCK DID THE CODE GET HERE?????");
                }
                else
                {
                  if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null)
                    this.StudentManager.LastKnownOsana.position = this.FollowTarget.transform.position;
                  this.Interaction = StudentInteractionType.Idle;
                  this.Yandere.Interaction = YandereInteractionType.TaskInquiry;
                  this.Yandere.TalkTimer = 5f;
                }
              }
              else if (this.StudentID == 79 && (double) this.DistanceToDestination < 1.0 && this.Actions[this.Phase] == StudentActionType.Wait)
              {
                this.Interaction = StudentInteractionType.WaitingForBeatEmUpResult;
              }
              else
              {
                this.DistanceToDestination = !((UnityEngine.Object) this.Destinations[this.Phase] == (UnityEngine.Object) null) ? Vector3.Distance(this.transform.position, this.Destinations[this.Phase].position) : 100f;
                if (this.Sleuthing && (UnityEngine.Object) this.SleuthTarget != (UnityEngine.Object) null)
                  this.DistanceToDestination = Vector3.Distance(this.transform.position, this.SleuthTarget.position);
                if (flag2)
                {
                  int num = this.Club != ClubType.Photography || !this.Sleuthing ? 0 : 5;
                  if (this.StudentManager.EmptyDemon)
                    num = (int) this.Club * -1;
                  this.Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int) (this.Club + num), 4f);
                  this.DialogueWheel.ClubLeader = true;
                  this.Yandere.Jukebox.ClubTheme.clip = this.Yandere.Jukebox.ClubThemes[(int) this.Club];
                  this.Yandere.Jukebox.ClubTheme.Play();
                }
                else
                  this.Subtitle.UpdateLabel(SubtitleType.Greeting, 0, 3f);
                if (this.Club != ClubType.Council && this.Club != ClubType.Delinquent && (this.Male && this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 0 || this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 4))
                {
                  ParticleSystem.EmissionModule emission = this.Hearts.emission with
                  {
                    rateOverTime = (ParticleSystem.MinMaxCurve) (float) (this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus),
                    enabled = true
                  };
                  this.Hearts.Play();
                }
                this.StudentManager.DisablePrompts();
                this.StudentManager.VolumeDown();
                this.DialogueWheel.HideShadows();
                this.DialogueWheel.Show = true;
                this.DialogueWheel.Panel.enabled = true;
                this.TalkTimer = 0.0f;
              }
            }
            else if (flag2)
            {
              this.Interaction = StudentInteractionType.ClubUnwelcome;
              this.TalkTimer = 5f;
              this.Warned = true;
            }
            else
            {
              this.Interaction = StudentInteractionType.PersonalGrudge;
              this.TalkTimer = 5f;
              this.Warned = true;
            }
            this.Yandere.ShoulderCamera.OverShoulder = true;
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Obstacle.enabled = true;
            this.Giggle = (GameObject) null;
            this.Yandere.WeaponMenu.KeyboardShow = false;
            this.Yandere.WeaponMenu.Show = false;
            this.Yandere.YandereVision = false;
            this.Yandere.CanMove = false;
            this.Yandere.Talking = true;
            this.Investigating = false;
            this.Talk.enabled = true;
            this.Reacted = false;
            this.Routine = false;
            this.Talking = true;
            this.TargetDistance = 0.5f;
            this.CuriosityPhase = 0;
            this.ReadPhase = 0;
            this.EmptyHands();
            bool flag11 = false;
            if (this.CurrentAction == StudentActionType.Sunbathe && this.SunbathePhase > 2)
            {
              this.SunbathePhase = 2;
              flag11 = true;
            }
            if (this.Phoneless)
              this.SmartPhone.SetActive(false);
            else if (this.Sleuthing)
            {
              if (!this.Scrubber.activeInHierarchy)
                this.SmartPhone.SetActive(true);
              else
                this.SmartPhone.SetActive(false);
            }
            else if (this.Persona != PersonaType.PhoneAddict)
              this.SmartPhone.SetActive(false);
            else if (!this.Scrubber.activeInHierarchy && !flag11)
              this.SmartPhone.SetActive(true);
            this.ChalkDust.Stop();
            this.StopPairing();
          }
        }
      }
    }
    if ((double) this.Prompt.Circle[2].fillAmount != 0.0 && ((double) this.Yandere.Sanity >= 33.333328247070313 || !this.Yandere.CanMove || this.Prompt.HideButton[2] || !this.Prompt.InSight || this.Club == ClubType.Council || this.Struggling || this.Chasing || (double) this.DistanceToPlayer >= 1.3999999761581421 || !this.SeenByYandere() || this.StudentID <= 1))
      return;
    if (!this.Yandere.Armed && this.Drownable)
    {
      Debug.Log((object) "Just began to drown someone.");
      if ((UnityEngine.Object) this.VomitDoor != (UnityEngine.Object) null)
      {
        this.VomitDoor.Prompt.enabled = true;
        this.VomitDoor.enabled = true;
      }
      this.Yandere.EmptyHands();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Prompt.Circle[2].fillAmount = 1f;
      this.VomitEmitter.gameObject.SetActive(false);
      this.Police.DrownedStudentName = this.Name;
      this.MyController.enabled = false;
      this.VomitEmitter.gameObject.SetActive(false);
      this.SmartPhone.SetActive(false);
      ++this.Police.DrownVictims;
      this.Distracted = true;
      this.Routine = false;
      this.Drowned = true;
      if (this.Male)
        this.Subtitle.UpdateLabel(SubtitleType.DrownReaction, 1, 3f);
      else
        this.Subtitle.UpdateLabel(SubtitleType.DrownReaction, 0, 3f);
      this.Yandere.TargetStudent = this;
      this.Yandere.Attacking = true;
      this.Yandere.CanMove = false;
      this.Yandere.Drown = true;
      this.Yandere.DrownAnim = "f02_fountainDrownA_00";
      this.DrownAnim = !this.Male ? ((double) Vector3.Distance(this.transform.position, this.StudentManager.transform.position) >= 5.0 ? "f02_toiletDrownB_00" : "f02_fountainDrownB_00") : ((double) Vector3.Distance(this.transform.position, this.StudentManager.transform.position) >= 5.0 ? "toiletDrown_00_B" : "fountainDrown_00_B");
      this.CharacterAnimation.CrossFade(this.DrownAnim);
    }
    else if (!this.Yandere.Armed && this.Pushable)
    {
      this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
      if (!this.Male)
        this.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 5, 3f);
      else
        this.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 5, 3f);
      this.Prompt.Label[0].text = "     Talk";
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Yandere.TargetStudent = this;
      this.Yandere.FollowHips = true;
      this.Yandere.Attacking = true;
      this.Yandere.RoofPush = true;
      this.Yandere.CanMove = false;
      this.Yandere.EmptyHands();
      this.EmptyHands();
      this.Distracted = true;
      this.Routine = false;
      this.Pushed = true;
      this.CharacterAnimation.CrossFade(this.PushedAnim);
      this.RemoveOfferHelpPrompt();
    }
    else
    {
      Debug.Log((object) (this.Name + " was just attacked, either because the player pressed the X button, or because Yandere-chan had low sanity."));
      this.Yandere.AttackManager.Stealth = (double) Mathf.Abs(Vector3.Angle(-this.transform.forward, this.Yandere.transform.position - this.transform.position)) <= 45.0;
      bool flag12 = false;
      if (this.Yandere.Armed && this.Yandere.AttackManager.Stealth && (this.Yandere.EquippedWeapon.Type == WeaponType.Bat || this.Yandere.EquippedWeapon.Type == WeaponType.Weight))
        flag12 = true;
      if ((double) this.Yandere.Bloodiness > 0.0)
        flag12 = true;
      if (flag12 || this.Yandere.Schoolwear == 2 || this.StudentManager.OriginalUniforms + this.StudentManager.NewUniforms > 1)
      {
        if (this.ClubActivityPhase >= 16)
          return;
        bool flag13 = false;
        if (this.Club == ClubType.Delinquent && !this.Injured && !this.Yandere.AttackManager.Stealth && !this.RespectEarned && !this.SolvingPuzzle && !this.Wet && (UnityEngine.Object) this.MyWeapon != (UnityEngine.Object) null && !this.Blind && !this.Yandere.Invisible)
        {
          Debug.Log((object) (this.Name + " knows that Yandere-chan is trying to attack them, and will now shove (and spawn alarm disc)."));
          this.Persona = PersonaType.Violent;
          flag13 = true;
          this.RespectEarned = false;
          this.Fleeing = false;
          this.Patience = 1;
          this.Shove();
          this.SpawnAlarmDisc();
        }
        if (this.Yandere.AttackManager.Stealth)
          this.SpawnSmallAlarmDisc();
        if (flag13 || this.Yandere.NearSenpai || this.Yandere.Attacking || this.Yandere.Stance.Current == StanceType.Crouching)
          return;
        if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Flaming || this.Yandere.CyborgParts[1].activeInHierarchy)
          this.Yandere.SanityBased = false;
        if (this.Strength == 9 && !this.Emetic && !this.Lethal && !this.Sedated && !this.Headache)
        {
          if (!this.Yandere.AttackManager.Stealth)
            this.CharacterAnimation.CrossFade("f02_dramaticFrontal_00");
          else
            this.CharacterAnimation.CrossFade("f02_dramaticStealth_00");
          this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
          this.Yandere.CanMove = false;
          this.DramaticCamera.enabled = true;
          this.DramaticCamera.rect = new Rect(0.0f, 0.5f, 1f, 0.0f);
          this.DramaticCamera.gameObject.SetActive(true);
          this.DramaticCamera.gameObject.GetComponent<AudioSource>().Play();
          this.DramaticReaction = true;
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.Routine = false;
        }
        else
        {
          if (!this.Yandere.Armed)
            return;
          if (this.Yandere.EquippedWeapon.WeaponID != 27 || this.Yandere.EquippedWeapon.WeaponID == 27 && this.Yandere.AttackManager.Stealth)
            this.AttackReaction();
          else
            Debug.Log((object) "Can't frontal attack with garrote.");
        }
      }
      else
      {
        if (this.Yandere.ClothingWarning)
          return;
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Clothing);
        this.StudentManager.TutorialWindow.ShowClothingMessage = true;
        this.Yandere.ClothingWarning = true;
      }
    }
  }

  private void UpdateDying()
  {
    this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
    if (!this.Attacked)
      return;
    if (!this.Teacher)
    {
      if (this.Strength == 9 && !this.Emetic && !this.Lethal && !this.Sedated && !this.Headache)
      {
        if (!this.StudentManager.Stop)
        {
          this.StudentManager.StopMoving();
          this.Yandere.RPGCamera.enabled = false;
          this.SmartPhone.SetActive(false);
          this.Police.Show = false;
        }
        this.CharacterAnimation.CrossFade("f02_moCounterB_00");
        if (!this.WitnessedMurder && (double) this.CharacterAnimation["f02_moLipSync_00"].weight == 0.0)
        {
          this.CharacterAnimation["f02_moLipSync_00"].weight = 1f;
          this.CharacterAnimation["f02_moLipSync_00"].time = 0.0f;
          this.CharacterAnimation.Play("f02_moLipSync_00");
        }
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
      }
      else
      {
        this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
        if (this.Alive && !this.Tranquil)
        {
          if (!this.Yandere.SanityBased)
          {
            this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
            if (this.Yandere.EquippedWeapon.WeaponID == 11)
            {
              this.CharacterAnimation.CrossFade(this.CyborgDeathAnim);
              this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
              if ((double) this.CharacterAnimation[this.CyborgDeathAnim].time < (double) this.CharacterAnimation[this.CyborgDeathAnim].length - 0.25 || this.Yandere.EquippedWeapon.WeaponID != 11)
                return;
              UnityEngine.Object.Instantiate<GameObject>(this.BloodyScream, this.transform.position + Vector3.up, Quaternion.identity);
              this.DeathType = DeathType.EasterEgg;
              this.BecomeRagdoll();
              this.Ragdoll.Dismember();
            }
            else if (this.Yandere.EquippedWeapon.WeaponID == 7)
            {
              this.CharacterAnimation.CrossFade(this.BuzzSawDeathAnim);
              this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
            }
            else if (!this.Yandere.EquippedWeapon.Concealable)
            {
              this.CharacterAnimation.CrossFade(this.SwingDeathAnim);
              this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
            }
            else
            {
              this.CharacterAnimation.CrossFade(this.DefendAnim);
              this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.1f);
            }
          }
          else
          {
            this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * this.Yandere.AttackManager.Distance);
            this.targetRotation = this.Yandere.AttackManager.Stealth ? Quaternion.LookRotation(this.transform.position - new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z)) : Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
          }
        }
        else
        {
          this.CharacterAnimation.CrossFade(this.DeathAnim);
          if ((double) this.CharacterAnimation[this.DeathAnim].time < 1.0)
            this.transform.Translate(Vector3.back * Time.deltaTime);
          else
            this.BecomeRagdoll();
        }
      }
    }
    else
    {
      if (!this.StudentManager.Stop)
      {
        this.StudentManager.StopMoving();
        this.Yandere.Laughing = false;
        this.Yandere.Dipping = false;
        this.Yandere.RPGCamera.enabled = false;
        this.SmartPhone.SetActive(false);
        this.Police.Show = false;
      }
      this.CharacterAnimation.CrossFade(this.CounterAnim);
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
      this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    }
  }

  private void UpdatePushed()
  {
    this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
    this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
    if ((double) this.CharacterAnimation[this.PushedAnim].time < (double) this.CharacterAnimation[this.PushedAnim].length)
      return;
    this.BecomeRagdoll();
  }

  private void UpdateDrowned()
  {
    this.SplashTimer += Time.deltaTime;
    if ((double) this.SplashTimer > 3.0 && (double) this.SplashTimer < 100.0)
    {
      this.DrowningSplashes.Play();
      this.SplashTimer += 100f;
    }
    this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
    this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
    if ((double) this.CharacterAnimation[this.DrownAnim].time < (double) this.CharacterAnimation[this.DrownAnim].length)
      return;
    this.BecomeRagdoll();
  }

  private void UpdateWitnessedMurder()
  {
    if (this.Threatened)
    {
      this.UpdateAlarmed();
    }
    else
    {
      if (this.Fleeing || this.Shoving)
        return;
      if (this.StudentID > 1 && this.Persona != PersonaType.Evil)
        this.EyeShrink += Time.deltaTime * 0.2f;
      if ((UnityEngine.Object) this.Yandere.TargetStudent != (UnityEngine.Object) null && this.LovedOneIsTargeted(this.Yandere.TargetStudent.StudentID))
      {
        this.Strength = 5;
        this.Persona = PersonaType.Heroic;
        this.SmartPhone.SetActive(false);
        this.SprintAnim = this.OriginalSprintAnim;
      }
      if ((this.Club != ClubType.Delinquent || this.Club == ClubType.Delinquent && this.Injured) && (UnityEngine.Object) this.Yandere.TargetStudent == (UnityEngine.Object) null && this.LovedOneIsTargeted(this.Yandere.NearestCorpseID))
      {
        this.Strength = 5;
        if (this.Injured)
          this.Strength = 1;
        this.Persona = PersonaType.Heroic;
      }
      if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && (UnityEngine.Object) this.Yandere.PickUp.BodyPart != (UnityEngine.Object) null && this.Yandere.PickUp.BodyPart.Type == 1 && this.LovedOneIsTargeted(this.Yandere.PickUp.BodyPart.StudentID))
      {
        this.Strength = 5;
        this.Persona = PersonaType.Heroic;
        this.SmartPhone.SetActive(false);
        this.SprintAnim = this.OriginalSprintAnim;
      }
      if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
      {
        if (!this.Attacked)
        {
          Debug.Log((object) "Calling PhoneAddictCameraUpdate() from here, specifically.");
          this.PhoneAddictCameraUpdate();
        }
      }
      else
        this.CharacterAnimation.CrossFade(this.ScaredAnim);
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.position.x, this.transform.position.y, this.Yandere.Hips.position.z) - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      if (!this.Yandere.Struggling)
      {
        if (this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Dangerous && this.Persona != PersonaType.Violent)
        {
          this.AlarmTimer += Time.deltaTime * (float) this.MurdersWitnessed;
          if (this.Urgent && this.Yandere.CanMove)
          {
            if (this.StudentID == 1)
              this.SenpaiNoticed();
            this.AlarmTimer += 5f;
          }
        }
        else
          this.AlarmTimer += Time.deltaTime * ((float) this.MurdersWitnessed * 5f);
      }
      else if (this.Yandere.Won)
        this.Urgent = true;
      if ((double) this.AlarmTimer > 5.0)
      {
        this.PersonaReaction();
        this.AlarmTimer = 0.0f;
      }
      else
      {
        if ((double) this.AlarmTimer <= 1.0 || this.Reacted)
          return;
        if (this.StudentID > 1 || (UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null)
        {
          if (this.StudentID == 1)
          {
            Debug.Log((object) "Senpai saw a mask.");
            this.Persona = PersonaType.Heroic;
            this.PersonaReaction();
          }
          if (!this.Teacher)
          {
            if (this.Persona != PersonaType.Evil)
            {
              if (this.Club == ClubType.Delinquent)
                this.SmartPhone.SetActive(false);
              else if (!this.StudentManager.Eighties && this.StudentID == 10)
              {
                Debug.Log((object) "This is the exact moment that Raibaru witnesses Yandere-chan commit murder.");
                this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 1, 3f);
                ++this.Yandere.Chasers;
                this.Urgent = true;
              }
              else
                this.Subtitle.UpdateLabel(SubtitleType.MurderReaction, 1, 3f);
            }
          }
          else if (this.WitnessedCoverUp)
          {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherCoverUpHostile, 1, 5f);
          }
          else
          {
            this.DetermineWhatWasWitnessed();
            this.DetermineTeacherSubtitle();
          }
        }
        else
        {
          Debug.Log((object) "Senpai witnessed murder, and entered a specific murder reaction animation.");
          this.MurderReaction = UnityEngine.Random.Range(1, 6);
          this.CharacterAnimation.CrossFade("senpaiMurderReaction_0" + this.MurderReaction.ToString());
          this.GameOverCause = GameOverType.Murder;
          if (!this.Yandere.Egg)
            this.SenpaiNoticed();
          this.CharacterAnimation["scaredFace_00"].weight = 0.0f;
          this.CharacterAnimation[this.AngryFaceAnim].weight = 0.0f;
          this.Yandere.ShoulderCamera.enabled = true;
          this.Yandere.ShoulderCamera.Noticed = true;
          this.Yandere.RPGCamera.enabled = false;
          this.Stop = true;
        }
        this.Reacted = true;
      }
    }
  }

  private void UpdateAlarmed()
  {
    if (!this.Threatened)
    {
      if (this.Yandere.Medusa && this.YandereVisible)
      {
        this.TurnToStone();
      }
      else
      {
        if (this.Persona != PersonaType.PhoneAddict && !this.Sleuthing)
          this.SmartPhone.SetActive(false);
        this.OccultBook.SetActive(false);
        this.Pen.SetActive(false);
        this.SpeechLines.Stop();
        this.ReadPhase = 0;
        if (this.WitnessedCorpse)
        {
          if (!this.WalkBack)
          {
            int studentId = this.StudentID;
            if (this.Persona != PersonaType.PhoneAddict)
              this.CharacterAnimation.CrossFade(this.ScaredAnim);
            else if (!this.Phoneless && !this.Attacked)
            {
              if (this.Corpse.MurderSuicideAnimation)
              {
                Debug.Log((object) "Waiting for murder suicide animation to end.");
                this.CharacterAnimation.CrossFade(this.ScaredAnim);
              }
              else
              {
                Debug.Log((object) "Calling PhoneAddictCameraUpdate() from here, actually.");
                this.PhoneAddictCameraUpdate();
              }
            }
          }
          else
          {
            Debug.Log((object) (this.Name + " is supposed to be walking backwards right now."));
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            int num = (int) this.MyController.Move(this.transform.forward * (-0.5f * Time.deltaTime));
            this.CharacterAnimation.CrossFade(this.WalkBackAnim);
            this.WalkBackTimer -= Time.deltaTime;
            if ((double) this.WalkBackTimer <= 0.0)
              this.WalkBack = false;
          }
        }
        else if (this.StudentID > 1)
        {
          if (this.Witness)
          {
            this.CharacterAnimation.CrossFade(this.LeanAnim);
          }
          else
          {
            if (!this.Investigating)
            {
              if (this.FocusOnStudent)
                this.CharacterAnimation.CrossFade(this.LeanAnim);
              else
                this.CharacterAnimation.CrossFade(this.IdleAnim);
            }
            if (this.FocusOnYandere)
            {
              if ((double) this.DistanceToPlayer < 1.0 && !this.Injured && (this.Club == ClubType.Council || this.Club == ClubType.Delinquent && !this.Injured || this.Shovey))
              {
                this.AlarmTimer = 0.0f;
                this.ThreatTimer += Time.deltaTime;
                if ((double) this.ThreatTimer > 5.0 && !this.Yandere.Struggling && !this.Yandere.DelinquentFighting && this.Prompt.InSight)
                {
                  this.ThreatTimer = 0.0f;
                  this.Shove();
                }
              }
              this.DistractionSpot = new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z);
            }
          }
        }
        else
          this.CharacterAnimation.CrossFade(this.LeanAnim);
        if (this.WitnessedMurder)
        {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        }
        else if (this.WitnessedCorpse)
        {
          if ((UnityEngine.Object) this.Corpse != (UnityEngine.Object) null && (UnityEngine.Object) this.Corpse.AllColliders[0] != (UnityEngine.Object) null)
          {
            this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, this.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          }
        }
        else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
        {
          if ((UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null)
          {
            this.targetRotation = Quaternion.LookRotation(new Vector3(this.BloodPool.transform.position.x, this.transform.position.y, this.BloodPool.transform.position.z) - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          }
        }
        else if (!this.Investigating && !this.FocusOnYandere && this.DiscCheck)
        {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.DistractionSpot.x, this.transform.position.y, this.DistractionSpot.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        }
        if (!this.Fleeing && !this.Yandere.DelinquentFighting)
          this.AlarmTimer += Time.deltaTime * (1f - this.Hesitation);
        if (!this.CanStillNotice)
          this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia) * 5.0);
        if ((double) this.AlarmTimer < 5.0 && (UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition) && (UnityEngine.Object) this.BloodPool.parent == (UnityEngine.Object) this.Yandere.RightHand)
        {
          Debug.Log((object) "ForgetAboutBloodPool() was called from this place in the code. 3");
          this.ForgetAboutBloodPool();
        }
        if ((double) this.AlarmTimer > 5.0)
          this.EndAlarm();
        else if ((double) this.AlarmTimer > 1.0 && !this.Reacted)
        {
          if (this.Teacher)
          {
            if (!this.WitnessedCorpse)
            {
              Debug.Log((object) (this.Name + " witnessed: " + this.Witnessed.ToString()));
              Debug.Log((object) "A teacher's subtitle is now being determined.");
              this.CharacterAnimation.CrossFade(this.IdleAnim);
              switch (this.Witnessed)
              {
                case StudentWitnessType.Blood:
                  this.Subtitle.UpdateLabel(SubtitleType.TeacherBloodReaction, 1, 6f);
                  this.GameOverCause = GameOverType.Blood;
                  break;
                case StudentWitnessType.BloodAndInsanity:
                case StudentWitnessType.Insanity:
                case StudentWitnessType.CleaningItem:
                case StudentWitnessType.Poisoning:
                case StudentWitnessType.WeaponAndBloodAndInsanity:
                case StudentWitnessType.WeaponAndInsanity:
                  this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
                  this.GameOverCause = GameOverType.Insanity;
                  break;
                case StudentWitnessType.Lewd:
                  Debug.Log((object) (this.Name + ", using the Teacher Persona, witnessed lewd behavior."));
                  this.Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
                  this.GameOverCause = GameOverType.Lewd;
                  break;
                case StudentWitnessType.Pickpocketing:
                case StudentWitnessType.Theft:
                  this.Subtitle.UpdateLabel(SubtitleType.TeacherTheftReaction, 1, 6f);
                  break;
                case StudentWitnessType.Trespassing:
                  this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, this.Concern, 5f);
                  break;
                case StudentWitnessType.Violence:
                  Debug.Log((object) (this.Name + ", using the Teacher Persona, witnessed violence."));
                  this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, 1, 6f);
                  this.GameOverCause = GameOverType.Violence;
                  this.Concern = 5;
                  break;
                case StudentWitnessType.Weapon:
                case StudentWitnessType.WeaponAndBlood:
                  this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponReaction, 1, 6f);
                  this.GameOverCause = GameOverType.Weapon;
                  break;
              }
              if (this.Club == ClubType.Council)
              {
                UnityEngine.Object.Destroy((UnityEngine.Object) this.Subtitle.CurrentClip);
                this.Subtitle.UpdateLabel(SubtitleType.CouncilToCounselor, this.ClubMemberID, 6f);
              }
              if (!this.Yandere.Noticed && (UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null)
              {
                Debug.Log((object) (this.Name + ", using the Teacher Persona, was alarmed because she saw something weird on the ground - a " + this.BloodPool.name));
                UnityEngine.Object.Destroy((UnityEngine.Object) this.Subtitle.CurrentClip);
                this.Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 2, 5f);
                PromptScript component1 = this.BloodPool.GetComponent<PromptScript>();
                if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
                {
                  WeaponScript component2 = this.BloodPool.GetComponent<WeaponScript>();
                  bool flag = false;
                  if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
                  {
                    if (component2.BroughtFromHome)
                    {
                      Debug.Log((object) "This weapon was brought from home!");
                      flag = true;
                    }
                    else
                      Debug.Log((object) "This weapon was not brought from home.");
                  }
                  if (!flag)
                  {
                    Debug.Log((object) ("Disabling a bloody object's prompt because " + this.Name + ", using the Teacher Persona, is heading for it."));
                    component1.Hide();
                    component1.enabled = false;
                  }
                }
                if (this.ReportPhase == 2)
                {
                  Debug.Log((object) "This teacher noticed the suspicious object while on her way to investigate something, and is now updating her pathfinding target.");
                  this.DetermineBloodLocation();
                }
              }
            }
            else
            {
              Debug.Log((object) "A teacher found a corpse.");
              this.Concern = 1;
              this.DetermineWhatWasWitnessed();
              this.DetermineTeacherSubtitle();
              if (this.WitnessedMurder)
              {
                ++this.MurdersWitnessed;
                if (!this.Yandere.Chased)
                {
                  Debug.Log((object) "A teacher has reached ChaseYandere() through UpdateAlarm().");
                  this.ChaseYandere();
                }
              }
            }
            if (!this.Chasing && (this.YandereVisible && this.Concern == 5 || this.Yandere.Noticed))
            {
              Debug.Log((object) "Yandere-chan is getting sent to the guidance counselor.");
              if (this.Witnessed == StudentWitnessType.Theft && (UnityEngine.Object) this.Yandere.StolenObject != (UnityEngine.Object) null)
              {
                this.Yandere.StolenObject.SetActive(true);
                this.Yandere.StolenObject = (GameObject) null;
                this.Yandere.Inventory.IDCard = false;
              }
              this.StudentManager.CombatMinigame.Stop();
              this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
              this.Yandere.ShoulderCamera.enabled = true;
              this.Yandere.ShoulderCamera.Noticed = true;
              this.Yandere.RPGCamera.enabled = false;
              this.Stop = true;
            }
          }
          else if (this.StudentID > 1 || (UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null)
          {
            if (this.StudentID == 41 && !this.StudentManager.Eighties)
              this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
            else if (this.RepeatReaction)
            {
              if (!this.StudentManager.Eighties && this.StudentID == 48 && this.TaskPhase == 4 && this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 12)
              {
                this.Subtitle.CustomText = "Is that dumbbell for me? Drop it over here!";
                this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
              }
              else
              {
                this.Subtitle.UpdateLabel(SubtitleType.RepeatReaction, 1, 3f);
                this.RepeatReaction = false;
              }
            }
            else if (this.Club != ClubType.Delinquent)
            {
              if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
                this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodAndInsanityReaction, 1, 3f);
              else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
                this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodReaction, 1, 3f);
              else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
                this.Subtitle.UpdateLabel(SubtitleType.WeaponAndInsanityReaction, 1, 3f);
              else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
                this.Subtitle.UpdateLabel(SubtitleType.BloodAndInsanityReaction, 1, 3f);
              else if (this.Witnessed == StudentWitnessType.Weapon)
              {
                Debug.Log((object) ("Witnessed a weapon. WeaponWitnessed is: " + this.WeaponWitnessed.ToString()));
                this.Subtitle.StudentID = this.StudentID;
                if (this.PlayerHeldBloodyWeapon)
                {
                  this.Subtitle.CustomText = "Why is that thing covered in blood?! Did you hurt someone?!";
                  this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                  this.PlayerHeldBloodyWeapon = false;
                }
                else
                  this.Subtitle.UpdateLabel(SubtitleType.WeaponReaction, this.WeaponWitnessed, 3f);
              }
              else if (this.Witnessed == StudentWitnessType.Blood)
              {
                if (!this.Bloody)
                {
                  this.Subtitle.UpdateLabel(SubtitleType.BloodReaction, 1, 3f);
                }
                else
                {
                  this.Subtitle.UpdateLabel(SubtitleType.WetBloodReaction, 1, 3f);
                  this.Witnessed = StudentWitnessType.None;
                  this.Witness = false;
                }
              }
              else if (this.Witnessed == StudentWitnessType.Insanity)
                this.Subtitle.UpdateLabel(SubtitleType.InsanityReaction, 1, 3f);
              else if (this.Witnessed == StudentWitnessType.Lewd)
                this.Subtitle.UpdateLabel(SubtitleType.LewdReaction, 1, 3f);
              else if (this.Witnessed == StudentWitnessType.CleaningItem)
                this.Subtitle.UpdateLabel(SubtitleType.SuspiciousReaction, 0, 5f);
              else if (this.Witnessed == StudentWitnessType.Suspicious)
                this.Subtitle.UpdateLabel(SubtitleType.SuspiciousReaction, 1, 5f);
              else if (this.Witnessed == StudentWitnessType.Corpse)
              {
                Debug.Log((object) (this.Name + " is currently reacting to the corpse of " + this.Corpse.Student.Name + " and is deciding what subtitle to use."));
                if (!this.StudentManager.Eighties && this.StudentID == this.StudentManager.ObstacleID && this.Corpse.Student.Rival)
                {
                  this.Subtitle.Speaker = this;
                  this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 1, 5f);
                  Debug.Log((object) "Raibaru is reacting to Osana's corpse with a unique subtitle.");
                }
                else if (!this.StudentManager.Eighties && this.StudentID == 11 && this.Corpse.StudentID == this.StudentManager.ObstacleID)
                {
                  this.Subtitle.Speaker = this;
                  this.Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 1, 5f);
                  Debug.Log((object) "Osana is reacting to Raibaru's corpse with a unique subtitle.");
                }
                else if (this.Club == ClubType.Council)
                {
                  if (this.StudentID == 86)
                    this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 1, 5f);
                  else if (this.StudentID == 87)
                    this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 2, 5f);
                  else if (this.StudentID == 88)
                    this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 3, 5f);
                  else if (this.StudentID == 89)
                    this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 4, 5f);
                }
                else if (this.Persona == PersonaType.Evil)
                  this.Subtitle.UpdateLabel(SubtitleType.EvilCorpseReaction, 1, 5f);
                else if (this.WitnessedMindBrokenMurder)
                {
                  this.Subtitle.CustomText = "This can't be happening...";
                  this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                }
                else if (!this.Corpse.Choking)
                  this.Subtitle.UpdateLabel(SubtitleType.CorpseReaction, 0, 5f);
                else
                  this.Subtitle.UpdateLabel(SubtitleType.CorpseReaction, 1, 5f);
              }
              else if (this.Witnessed == StudentWitnessType.Interruption)
              {
                if (this.StudentID == 11)
                  this.Subtitle.UpdateLabel(SubtitleType.InterruptionReaction, 1, 5f);
                else
                  this.Subtitle.UpdateLabel(SubtitleType.InterruptionReaction, 2, 5f);
              }
              else if (this.Witnessed == StudentWitnessType.Eavesdropping)
              {
                if (this.Rival)
                {
                  this.Subtitle.UpdateLabel(SubtitleType.RivalEavesdropReaction, 0, 9f);
                  this.Hesitation = 0.6f;
                }
                else if (this.StudentID == 10)
                {
                  this.Subtitle.UpdateLabel(SubtitleType.RivalEavesdropReaction, 1, 9f);
                  this.Hesitation = 0.6f;
                }
                else if (this.EventInterrupted)
                {
                  this.Subtitle.UpdateLabel(SubtitleType.EventEavesdropReaction, 1, 5f);
                  this.EventInterrupted = false;
                }
                else
                  this.Subtitle.UpdateLabel(SubtitleType.EavesdropReaction, 1, 5f);
              }
              else if (this.Witnessed == StudentWitnessType.Pickpocketing)
                this.Subtitle.UpdateLabel(this.PickpocketSubtitleType, 1, 5f);
              else if (this.Witnessed == StudentWitnessType.Violence)
                this.Subtitle.UpdateLabel(SubtitleType.ViolenceReaction, 5, 5f);
              else if (this.Witnessed == StudentWitnessType.Poisoning)
              {
                if ((UnityEngine.Object) this.Yandere.TargetBento != (UnityEngine.Object) null)
                {
                  if (this.Yandere.TargetBento.StudentID != this.StudentID)
                  {
                    this.Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 1, 5f);
                  }
                  else
                  {
                    Debug.Log((object) (this.Name + " witnessed their own bento being poisoned."));
                    this.Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 2, 5f);
                    this.NotEating = true;
                    if (this.Clock.Period == 3)
                    {
                      ++this.Phase;
                      this.Pathfinding.target = this.Destinations[this.Phase];
                      this.CurrentDestination = this.Destinations[this.Phase];
                    }
                  }
                }
                else
                {
                  Debug.Log((object) "Player was caught poisoning a bento that is a part of an event.");
                  if (this.StudentID == 11)
                  {
                    Debug.Log((object) "Osana witnessed it.");
                    if (this.StudentManager.Portal.GetComponent<PortalScript>().OsanaEvent.Bentos[1].GetComponent<BentoScript>().BeingPoisoned)
                    {
                      Debug.Log((object) "Osana witnessed Senpai's bento being poisoned.");
                      this.StudentManager.Portal.GetComponent<PortalScript>().OsanaMondayLunchEvent.enabled = false;
                      this.Subtitle.CustomText = "What are you doing to Senpai's bento?! Ugh, now I can't give it to him...";
                      this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                      this.StudentManager.Students[1].MyBento.Tampered = false;
                      this.StudentManager.Students[1].MyBento.Emetic = false;
                      this.StudentManager.Students[1].Emetic = false;
                    }
                    else if (this.StudentManager.Portal.GetComponent<PortalScript>().OsanaEvent.Bentos[2].GetComponent<BentoScript>().BeingPoisoned)
                    {
                      Debug.Log((object) "Osana witnessed her own bento being poisoned.");
                      this.StudentManager.Portal.GetComponent<PortalScript>().OsanaMondayLunchEvent.enabled = false;
                      this.Subtitle.CustomText = "What are you doing to my bento?! Well, now I'm not going to eat it...";
                      this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
                      Debug.Log((object) "Osana will spend her lunchtime looking sad.");
                      this.ScheduleBlocks[4].action = "Shamed";
                      this.GetDestinations();
                    }
                  }
                  else
                    this.Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 1, 5f);
                }
              }
              else if (this.Witnessed == StudentWitnessType.SeveredLimb)
                this.Subtitle.UpdateLabel(SubtitleType.LimbReaction, 0, 5f);
              else if (this.Witnessed == StudentWitnessType.BloodyWeapon)
                this.Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 0, 5f);
              else if (this.Witnessed == StudentWitnessType.DroppedWeapon)
                this.Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 0, 5f);
              else if (this.Witnessed == StudentWitnessType.BloodPool)
                this.Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 0, 5f);
              else if (this.Witnessed == StudentWitnessType.HoldingBloodyClothing)
                this.Subtitle.UpdateLabel(SubtitleType.HoldingBloodyClothingReaction, 0, 5f);
              else if (this.Witnessed == StudentWitnessType.Theft)
              {
                if (this.StudentID == 2 && this.RingReact)
                  this.Subtitle.UpdateLabel(SubtitleType.TheftReaction, 1, 5f);
                else
                  this.Subtitle.UpdateLabel(SubtitleType.TheftReaction, 0, 5f);
              }
              else if (this.Witnessed == StudentWitnessType.Tutorial)
                this.Subtitle.UpdateLabel(SubtitleType.TutorialReaction, 0, 10f);
              else if (this.Witnessed == StudentWitnessType.Trespassing)
                this.Subtitle.UpdateLabel(SubtitleType.TrespassReaction, 0, 10f);
              else if (this.Club == ClubType.Council)
              {
                this.Subtitle.UpdateLabel(SubtitleType.HmmReaction, this.ClubMemberID, 3f);
                this.TemporarilyBlind = false;
              }
              else
                this.Subtitle.UpdateLabel(SubtitleType.HmmReaction, 0, 3f);
            }
            else if (this.Witnessed == StudentWitnessType.None)
            {
              this.Subtitle.Speaker = this;
              this.Subtitle.UpdateLabel(SubtitleType.DelinquentHmm, 0, 5f);
            }
            else if (this.Witnessed == StudentWitnessType.Corpse)
            {
              if (this.FoundEnemyCorpse)
                this.Subtitle.UpdateLabel(SubtitleType.EvilDelinquentCorpseReaction, 1, 5f);
              else if (this.Corpse.Student.Club == ClubType.Delinquent)
              {
                this.Subtitle.Speaker = this;
                this.Subtitle.UpdateLabel(SubtitleType.DelinquentFriendCorpseReaction, 1, 5f);
                this.FoundFriendCorpse = true;
              }
              else
              {
                this.Subtitle.Speaker = this;
                this.Subtitle.UpdateLabel(SubtitleType.DelinquentCorpseReaction, 1, 5f);
              }
            }
            else if (this.Witnessed == StudentWitnessType.Weapon && !this.Injured)
            {
              this.Subtitle.Speaker = this;
              this.Subtitle.UpdateLabel(SubtitleType.DelinquentWeaponReaction, 0, 3f);
            }
            else
            {
              this.Subtitle.Speaker = this;
              if (this.WitnessedLimb || this.WitnessedWeapon || this.WitnessedBloodPool || this.WitnessedBloodyWeapon)
              {
                this.Subtitle.UpdateLabel(SubtitleType.LimbReaction, 0, 5f);
              }
              else
              {
                this.Subtitle.UpdateLabel(SubtitleType.DelinquentReaction, 0, 5f);
                Debug.Log((object) "A delinquent is reacting to Yandere-chan's behavior.");
              }
            }
          }
          else
          {
            Debug.Log((object) "We are now determining what Senpai saw...");
            if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
            {
              this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
              this.GameOverCause = GameOverType.Insanity;
            }
            else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
            {
              this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
              this.GameOverCause = GameOverType.Weapon;
            }
            else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
            {
              this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
              this.GameOverCause = GameOverType.Insanity;
            }
            else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
            {
              this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
              this.GameOverCause = GameOverType.Insanity;
            }
            else if (this.Witnessed == StudentWitnessType.Weapon)
            {
              this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
              this.GameOverCause = GameOverType.Weapon;
            }
            else if (this.Witnessed == StudentWitnessType.Blood)
            {
              this.CharacterAnimation.CrossFade("senpaiBloodReaction_00");
              this.GameOverCause = GameOverType.Blood;
            }
            else if (this.Witnessed == StudentWitnessType.Insanity)
            {
              this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
              this.GameOverCause = GameOverType.Insanity;
            }
            else if (this.Witnessed == StudentWitnessType.Lewd || this.Witnessed == StudentWitnessType.Poisoning)
            {
              this.CharacterAnimation.CrossFade("senpaiLewdReaction_00");
              this.GameOverCause = GameOverType.Lewd;
            }
            else if (this.Witnessed == StudentWitnessType.Stalking)
            {
              if (this.Concern < 5)
              {
                this.Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, this.Concern, 4.5f);
              }
              else
              {
                this.CharacterAnimation.CrossFade("senpaiCreepyReaction_00");
                this.GameOverCause = GameOverType.Stalking;
              }
              this.Witnessed = StudentWitnessType.None;
            }
            else if (this.Witnessed == StudentWitnessType.Corpse)
            {
              if (this.Corpse.Student.Rival)
              {
                this.Subtitle.Speaker = this;
                this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 1, 5f);
                Debug.Log((object) "Senpai is reacting to Osana's corpse with a unique subtitle.");
              }
              else
                this.Subtitle.UpdateLabel(SubtitleType.SenpaiCorpseReaction, 1, 5f);
            }
            else if (this.Witnessed == StudentWitnessType.Violence)
            {
              this.CharacterAnimation.CrossFade("senpaiFightReaction_00");
              this.GameOverCause = GameOverType.Violence;
              this.Concern = 5;
            }
            if (this.Concern == 5)
            {
              this.CharacterAnimation["scaredFace_00"].weight = 0.0f;
              this.CharacterAnimation[this.AngryFaceAnim].weight = 0.0f;
              this.Yandere.ShoulderCamera.enabled = true;
              this.Yandere.ShoulderCamera.Noticed = true;
              this.Yandere.RPGCamera.enabled = false;
              this.Stop = true;
            }
          }
          this.Reacted = true;
        }
        if (this.Club != ClubType.Council && !this.Shovey || (double) this.DistanceToPlayer >= 1.1000000238418579 || this.Yandere.Invisible || !this.Yandere.Armed && (!this.Yandere.Carrying || this.Yandere.CurrentRagdoll.Concealed) && (!this.Yandere.Dragging || this.Yandere.CurrentRagdoll.Concealed) || !this.Prompt.InSight)
          return;
        if (this.Yandere.Armed && !this.Yandere.EquippedWeapon.Suspicious && !this.WitnessedMurder)
        {
          Debug.Log((object) (this.Name + " is shoving the player from this place in the code. 1"));
          this.Shove();
        }
        else
        {
          Debug.Log((object) "Calling ''Spray()'' from this part of the code. 3");
          this.Spray();
        }
      }
    }
    else
    {
      this.Alarm -= (float) ((double) Time.deltaTime * 100.0 * (1.0 / (double) this.Paranoia));
      this.targetRotation = (UnityEngine.Object) this.StudentManager.CombatMinigame.Delinquent == (UnityEngine.Object) null || (UnityEngine.Object) this.StudentManager.CombatMinigame.Delinquent == (UnityEngine.Object) this ? Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position) : Quaternion.LookRotation(new Vector3(this.StudentManager.CombatMinigame.Midpoint.position.x, this.transform.position.y, this.StudentManager.CombatMinigame.Midpoint.position.z) - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      if (this.Yandere.DelinquentFighting && (UnityEngine.Object) this.StudentManager.CombatMinigame.Delinquent != (UnityEngine.Object) this)
      {
        if (this.StudentManager.CombatMinigame.Path < 4)
        {
          if ((double) this.DistanceToPlayer < 1.0)
          {
            int num1 = (int) this.MyController.Move(this.transform.forward * Time.deltaTime * -1f);
          }
          if ((double) Vector3.Distance(this.transform.position, this.StudentManager.CombatMinigame.Delinquent.transform.position) < 1.0)
          {
            int num2 = (int) this.MyController.Move(this.transform.forward * Time.deltaTime * -1f);
          }
          if (this.Yandere.enabled)
          {
            this.CheerTimer = Mathf.MoveTowards(this.CheerTimer, 0.0f, Time.deltaTime);
            if ((double) this.CheerTimer == 0.0)
            {
              this.Subtitle.Speaker = this;
              this.Subtitle.UpdateLabel(SubtitleType.DelinquentCheer, 0, 5f);
              this.CheerTimer = UnityEngine.Random.Range(2f, 3f);
            }
          }
          this.CharacterAnimation.CrossFade(this.RandomCheerAnim);
          if ((double) this.CharacterAnimation[this.RandomCheerAnim].time >= (double) this.CharacterAnimation[this.RandomCheerAnim].length)
            this.RandomCheerAnim = this.CheerAnims[UnityEngine.Random.Range(0, this.CheerAnims.Length)];
          this.ThreatPhase = 3;
          this.ThreatTimer = 0.0f;
          if (!this.WitnessedMurder)
            return;
          this.Injured = true;
        }
        else
        {
          this.CharacterAnimation.CrossFade(this.IdleAnim, 5f);
          this.NoTalk = true;
        }
      }
      else if (!this.Injured)
      {
        if ((double) this.DistanceToPlayer > 5.0 + (double) this.ThreatDistance && this.ThreatPhase < 4)
        {
          this.ThreatPhase = 3;
          this.ThreatTimer = 0.0f;
        }
        if (this.Yandere.Dumping || this.Yandere.SneakingShot)
          return;
        if ((double) this.DistanceToPlayer > 1.0 && this.Patience > 0)
        {
          if (this.ThreatPhase == 1)
          {
            this.CharacterAnimation.CrossFade("delinquentShock_00");
            if ((double) this.CharacterAnimation["delinquentShock_00"].time < (double) this.CharacterAnimation["delinquentShock_00"].length)
              return;
            this.Subtitle.Speaker = this;
            this.Subtitle.UpdateLabel(SubtitleType.DelinquentThreatened, 0, 3f);
            this.CharacterAnimation.CrossFade("delinquentCombatIdle_00");
            this.ThreatTimer = 5f;
            ++this.ThreatPhase;
          }
          else if (this.ThreatPhase == 2)
          {
            this.ThreatTimer -= Time.deltaTime;
            if ((double) this.ThreatTimer >= 0.0)
              return;
            this.Subtitle.Speaker = this;
            this.Subtitle.UpdateLabel(SubtitleType.DelinquentTaunt, 0, 5f);
            this.ThreatTimer = 5f;
            ++this.ThreatPhase;
          }
          else if (this.ThreatPhase == 3)
          {
            this.ThreatTimer -= Time.deltaTime;
            if ((double) this.ThreatTimer >= 0.0)
              return;
            if (!this.NoTalk)
            {
              this.Subtitle.Speaker = this;
              this.Subtitle.UpdateLabel(SubtitleType.DelinquentCalm, 0, 5f);
            }
            this.CharacterAnimation.CrossFade(this.IdleAnim, 5f);
            this.ThreatTimer = 5f;
            ++this.ThreatPhase;
          }
          else
          {
            if (this.ThreatPhase != 4)
              return;
            this.ThreatTimer -= Time.deltaTime;
            if ((double) this.ThreatTimer >= 0.0)
              return;
            if ((UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) this.Destinations[this.Phase])
              this.StopInvestigating();
            this.FocusOnStudent = false;
            this.FocusOnYandere = false;
            this.Distracted = false;
            this.Threatened = false;
            this.Alarmed = false;
            this.Routine = true;
            this.NoTalk = false;
            this.IgnoreTimer = 5f;
            this.AlarmTimer = 0.0f;
          }
        }
        else if (!this.NoTalk)
        {
          this.Yandere.Shoved = false;
          Debug.Log((object) "The combat minigame is now beginning.");
          string str = "";
          if (!this.Male)
            str = "Female_";
          if (this.StudentID == 46)
            this.CharacterAnimation.CrossFade("delinquentDrawWeapon_00");
          if ((UnityEngine.Object) this.StudentManager.CombatMinigame.Delinquent == (UnityEngine.Object) null)
          {
            this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatIdle");
            if ((UnityEngine.Object) this.MyWeapon.transform.parent != (UnityEngine.Object) this.ItemParent)
            {
              Debug.Log((object) ("The game is trying to tell " + ((object) this.StudentManager.CombatMinigame.Delinquent)?.ToString() + "to draw out a weapon."));
              this.CharacterAnimation.CrossFade(str + "delinquentDrawWeapon_00");
            }
            else
              this.CharacterAnimation.CrossFade("delinquentCombatIdle_00");
            if (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed)
              this.Yandere.EmptyHands();
            if (this.Yandere.Pickpocketing)
            {
              this.Yandere.Caught = true;
              this.PickPocket.PickpocketMinigame.End();
            }
            this.Yandere.StopLaughing();
            this.Yandere.StopAiming();
            this.Yandere.Unequip();
            if (this.Yandere.YandereVision)
            {
              this.Yandere.YandereVision = false;
              this.Yandere.ResetYandereEffects();
            }
            if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null)
              this.Yandere.EmptyHands();
            this.Yandere.DelinquentFighting = true;
            this.Yandere.NearSenpai = false;
            this.Yandere.Degloving = false;
            this.Yandere.CanMove = false;
            this.Yandere.GloveTimer = 0.0f;
            this.FocusOnStudent = false;
            this.FocusOnYandere = false;
            this.Distracted = true;
            this.Fighting = true;
            this.ThreatTimer = 0.0f;
            this.StudentManager.CombatMinigame.Delinquent = this;
            this.StudentManager.CombatMinigame.enabled = true;
            this.StudentManager.CombatMinigame.StartCombat();
            this.SpeechLines.Stop();
            this.SpawnAlarmDisc();
            if (this.WitnessedMurder || this.WitnessedCorpse)
            {
              this.Subtitle.Speaker = this;
              this.Subtitle.UpdateLabel(SubtitleType.DelinquentAvenge, 0, 5f);
            }
            else if (!this.StudentManager.CombatMinigame.Practice)
            {
              this.Subtitle.Speaker = this;
              this.Subtitle.UpdateLabel(SubtitleType.DelinquentFight, 0, 5f);
            }
          }
          this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
          if ((double) this.CharacterAnimation[str + "delinquentDrawWeapon_00"].time >= 0.5)
          {
            this.MyWeapon.transform.parent = this.ItemParent;
            this.MyWeapon.transform.localEulerAngles = new Vector3(0.0f, 15f, 0.0f);
            this.MyWeapon.transform.localPosition = new Vector3(0.01f, 0.0f, 0.0f);
          }
          if ((double) this.CharacterAnimation[str + "delinquentDrawWeapon_00"].time < (double) this.CharacterAnimation[str + "delinquentDrawWeapon_00"].length)
            return;
          this.Threatened = false;
          this.Alarmed = false;
          this.enabled = false;
        }
        else
        {
          this.ThreatTimer -= Time.deltaTime;
          if ((double) this.ThreatTimer >= 0.0)
            return;
          if ((UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) this.Destinations[this.Phase])
            this.StopInvestigating();
          this.Distracted = false;
          this.Threatened = false;
          this.Alarmed = false;
          this.Routine = true;
          this.NoTalk = false;
          this.IgnoreTimer = 5f;
          this.AlarmTimer = 0.0f;
        }
      }
      else
      {
        this.ThreatTimer += Time.deltaTime;
        if ((double) this.ThreatTimer <= 5.0)
          return;
        this.DistanceToDestination = 100f;
        if (!this.Yandere.CanMove)
          return;
        if (!this.WitnessedMurder && !this.WitnessedCorpse)
        {
          this.Distracted = false;
          this.Threatened = false;
          this.EndAlarm();
        }
        else
        {
          this.Threatened = false;
          this.Alarmed = false;
          this.Injured = false;
          this.PersonaReaction();
        }
      }
    }
  }

  private void UpdateBurning()
  {
    if ((double) this.DistanceToPlayer < 1.0 && !this.Yandere.Shoved && !this.Yandere.Egg)
    {
      if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Yandere.PickUp.OpenFlame && !this.Yandere.Invisible)
        this.Yandere.PotentiallyMurderousTimer = 1f;
      this.PushYandereAway();
    }
    if (this.BurnTarget != Vector3.zero)
      this.MoveTowardsTarget(this.BurnTarget);
    if ((double) this.CharacterAnimation[this.BurningAnim].time > (double) this.CharacterAnimation[this.BurningAnim].length)
    {
      this.DeathType = DeathType.Burning;
      this.BecomeRagdoll();
    }
    else
    {
      if ((double) this.CharacterAnimation[this.BurningAnim].time <= 8.0)
        return;
      this.CheckForWallInFront(2f);
      if (!this.TooCloseToWall)
        return;
      int num = (int) this.MyController.Move(this.transform.forward * Time.deltaTime * -0.5f);
    }
  }

  private void UpdateSplashed()
  {
    this.CharacterAnimation.CrossFade(this.SplashedAnim);
    if (this.Yandere.Tripping)
    {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
    }
    this.SplashTimer += Time.deltaTime;
    if ((double) this.SplashTimer > 2.0 && this.SplashPhase == 1)
    {
      if (this.Gas)
      {
        this.Subtitle.Speaker = this;
        this.Subtitle.UpdateLabel(this.SplashSubtitleType, 5, 5f);
      }
      else if (this.DyedBrown)
      {
        this.Subtitle.Speaker = this;
        this.Subtitle.UpdateLabel(this.SplashSubtitleType, 7, 5f);
      }
      else if (this.Bloody)
      {
        this.Subtitle.Speaker = this;
        this.Subtitle.UpdateLabel(this.SplashSubtitleType, 3, 5f);
      }
      else
      {
        this.Subtitle.Speaker = this;
        this.Subtitle.UpdateLabel(this.SplashSubtitleType, 1, 5f);
      }
      this.CharacterAnimation[this.SplashedAnim].speed = 0.5f;
      ++this.SplashPhase;
    }
    if ((double) this.SplashTimer <= 12.0 || this.SplashPhase != 2)
      return;
    if ((UnityEngine.Object) this.LightSwitch == (UnityEngine.Object) null)
    {
      if (this.Gas)
      {
        this.Subtitle.Speaker = this;
        this.Subtitle.UpdateLabel(this.SplashSubtitleType, 6, 5f);
      }
      else if (this.Bloody)
      {
        this.Subtitle.Speaker = this;
        this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
      }
      else
      {
        this.Subtitle.Speaker = this;
        this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
      }
      ++this.SplashPhase;
      if (!this.Male)
      {
        this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
        this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
      }
      else
      {
        this.CurrentDestination = this.StudentManager.MaleStripSpot;
        this.Pathfinding.target = this.StudentManager.MaleStripSpot;
      }
    }
    else if (!this.LightSwitch.BathroomLight.activeInHierarchy)
    {
      if (this.LightSwitch.Panel.useGravity)
      {
        this.LightSwitch.Prompt.Hide();
        this.LightSwitch.Prompt.enabled = false;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
      this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 1, 5f);
      this.CurrentDestination = this.LightSwitch.ElectrocutionSpot;
      this.Pathfinding.target = this.LightSwitch.ElectrocutionSpot;
      this.Pathfinding.speed = this.WalkSpeed;
      this.BathePhase = -1;
      this.InDarkness = true;
    }
    else
    {
      if (!this.Bloody)
      {
        this.Subtitle.Speaker = this;
        this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
      }
      else
      {
        this.Subtitle.Speaker = this;
        this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
      }
      ++this.SplashPhase;
      this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
      this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
    }
    Debug.Log((object) "Student is now running towards the locker room.");
    this.CharacterAnimation[this.WetAnim].weight = 1f;
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.Splashed = false;
  }

  private void UpdateTurningOffRadio()
  {
    if (this.Radio.On || this.RadioPhase == 3 && (UnityEngine.Object) this.Radio.transform.parent == (UnityEngine.Object) null)
    {
      if (this.RadioPhase == 1)
      {
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, this.transform.position.y, this.Radio.transform.position.z) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        this.RadioTimer += Time.deltaTime;
        if ((double) this.RadioTimer <= 3.0)
          return;
        if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
          this.SmartPhone.SetActive(true);
        if (this.Persona == PersonaType.Protective || this.Hurry)
        {
          this.CharacterAnimation.CrossFade(this.RunAnim);
          this.Pathfinding.speed = 4f;
        }
        else
          this.CharacterAnimation.CrossFade(this.WalkAnim);
        this.CurrentDestination = this.Radio.transform;
        this.Pathfinding.target = this.Radio.transform;
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.RadioTimer = 0.0f;
        ++this.RadioPhase;
      }
      else if (this.RadioPhase == 2)
      {
        if ((double) Vector3.Distance(this.transform.position, new Vector3(this.Radio.transform.position.x, this.transform.position.y, this.Radio.transform.position.z)) >= 0.5)
          return;
        this.CharacterAnimation.CrossFade(this.RadioAnim);
        this.Pathfinding.canSearch = false;
        this.Pathfinding.canMove = false;
        this.SmartPhone.SetActive(false);
        ++this.RadioPhase;
      }
      else
      {
        if (this.RadioPhase != 3)
          return;
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, this.transform.position.y, this.Radio.transform.position.z) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        this.RadioTimer += Time.deltaTime;
        if ((double) this.RadioTimer > 4.0)
        {
          if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
            this.SmartPhone.SetActive(true);
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.ForgetRadio();
        }
        else
        {
          if ((double) this.RadioTimer <= 2.0)
            return;
          this.Radio.Victim = (StudentScript) null;
          this.Radio.TurnOff();
        }
      }
    }
    else
    {
      if (this.RadioPhase < 100)
      {
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        this.Pathfinding.canSearch = false;
        this.Pathfinding.canMove = false;
        this.RadioPhase = 100;
        this.RadioTimer = 0.0f;
      }
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, this.transform.position.y, this.Radio.transform.position.z) - this.transform.position);
      this.RadioTimer += Time.deltaTime;
      if ((double) this.RadioTimer <= 1.0 && !((UnityEngine.Object) this.Radio.transform.parent != (UnityEngine.Object) null))
        return;
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.Destinations[this.Phase];
      this.Pathfinding.canSearch = true;
      this.Pathfinding.canMove = true;
      this.ForgetRadio();
    }
  }

  private void UpdateVomiting()
  {
    if (this.VomitPhase != 0 && this.VomitPhase != 4)
    {
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
      this.MoveTowardsTarget(this.CurrentDestination.position);
    }
    if (this.VomitPhase == 0)
    {
      if ((double) this.DistanceToDestination >= 0.5)
        return;
      if (!this.Yandere.Armed && (UnityEngine.Object) this.Yandere.PickUp == (UnityEngine.Object) null)
      {
        this.Drownable = true;
        this.StudentManager.UpdateMe(this.StudentID);
      }
      if ((UnityEngine.Object) this.VomitDoor != (UnityEngine.Object) null)
      {
        this.VomitDoor.Prompt.enabled = false;
        this.VomitDoor.Prompt.Hide();
        this.VomitDoor.enabled = false;
      }
      this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
      this.CharacterAnimation.CrossFade(this.VomitAnim);
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
      ++this.VomitPhase;
    }
    else if (this.VomitPhase == 1)
    {
      if ((double) this.CharacterAnimation[this.VomitAnim].time <= 1.0)
        return;
      this.VomitEmitter.gameObject.SetActive(true);
      ++this.VomitPhase;
    }
    else if (this.VomitPhase == 2)
    {
      if ((double) this.CharacterAnimation[this.VomitAnim].time <= 13.0)
        return;
      this.VomitEmitter.gameObject.SetActive(false);
      ++this.VomitPhase;
    }
    else if (this.VomitPhase == 3)
    {
      if ((double) this.CharacterAnimation[this.VomitAnim].time < (double) this.CharacterAnimation[this.VomitAnim].length)
        return;
      this.Drownable = false;
      this.StudentManager.UpdateMe(this.StudentID);
      this.WalkAnim = this.OriginalWalkAnim;
      this.CharacterAnimation.CrossFade(this.WalkAnim);
      if (this.Male)
      {
        this.StudentManager.GetMaleWashSpot(this);
        this.Pathfinding.target = this.StudentManager.MaleWashSpot;
        this.CurrentDestination = this.StudentManager.MaleWashSpot;
      }
      else
      {
        this.StudentManager.GetFemaleWashSpot(this);
        this.Pathfinding.target = this.StudentManager.FemaleWashSpot;
        this.CurrentDestination = this.StudentManager.FemaleWashSpot;
      }
      if ((UnityEngine.Object) this.VomitDoor != (UnityEngine.Object) null)
      {
        this.VomitDoor.Prompt.enabled = true;
        this.VomitDoor.enabled = true;
      }
      this.Pathfinding.canSearch = true;
      this.Pathfinding.canMove = true;
      this.Pathfinding.speed = this.WalkSpeed;
      this.DistanceToDestination = 100f;
      ++this.VomitPhase;
    }
    else if (this.VomitPhase == 4)
    {
      if ((double) this.DistanceToDestination >= 0.5)
        return;
      this.CharacterAnimation.CrossFade(this.WashFaceAnim);
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
      ++this.VomitPhase;
    }
    else
    {
      if (this.VomitPhase != 5 || (double) this.CharacterAnimation[this.WashFaceAnim].time <= (double) this.CharacterAnimation[this.WashFaceAnim].length)
        return;
      this.StopVomitting();
      ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase + 1];
      scheduleBlock.destination = "Seat";
      scheduleBlock.action = "Sit";
      this.GetDestinations();
      ++this.Phase;
      this.Pathfinding.target = this.Destinations[this.Phase];
      this.CurrentDestination = this.Destinations[this.Phase];
      this.CurrentAction = StudentActionType.SitAndTakeNotes;
      this.DistanceToDestination = 100f;
    }
  }

  private void StopVomitting()
  {
    this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.VomitEmitter.gameObject.SetActive(false);
    this.Prompt.Label[0].text = "     Talk";
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.Distracted = false;
    this.Drownable = false;
    this.Vomiting = false;
    this.Private = false;
    this.CanTalk = true;
    this.Routine = true;
    this.Emetic = false;
    this.VomitPhase = 0;
    this.StudentManager.UpdateMe(this.StudentID);
    this.WalkAnim = this.OriginalWalkAnim;
  }

  private void UpdateConfessing()
  {
    if (!this.Male)
    {
      if (this.ConfessPhase == 1)
      {
        if ((double) this.DistanceToDestination >= 0.5)
          return;
        this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
        this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.CharacterAnimation.CrossFade("f02_insertNote_00");
        this.Pathfinding.canSearch = false;
        this.Pathfinding.canMove = false;
        this.Note.SetActive(true);
        ++this.ConfessPhase;
      }
      else if (this.ConfessPhase == 2)
      {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.CurrentDestination.position);
        if ((double) this.CharacterAnimation["f02_insertNote_00"].time < 9.0)
          return;
        this.Note.SetActive(false);
        ++this.ConfessPhase;
      }
      else if (this.ConfessPhase == 3)
      {
        if ((double) this.CharacterAnimation["f02_insertNote_00"].time < (double) this.CharacterAnimation["f02_insertNote_00"].length)
          return;
        this.CurrentDestination = this.StudentManager.RivalConfessionSpot;
        this.Pathfinding.target = this.StudentManager.RivalConfessionSpot;
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.Pathfinding.speed = 4f;
        this.StudentManager.LoveManager.LeftNote = true;
        this.CharacterAnimation.CrossFade(this.SprintAnim);
        ++this.ConfessPhase;
      }
      else if (this.ConfessPhase == 4)
      {
        if ((double) this.DistanceToDestination >= 0.5)
          return;
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        this.Pathfinding.canSearch = false;
        this.Pathfinding.canMove = false;
        ++this.ConfessPhase;
      }
      else
      {
        if (this.ConfessPhase != 5)
          return;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
        this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 1f, Time.deltaTime);
        this.MoveTowardsTarget(this.CurrentDestination.position);
      }
    }
    else if (this.ConfessPhase == 1)
    {
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
      this.MoveTowardsTarget(this.CurrentDestination.position);
      if ((double) this.CharacterAnimation["keepNote_00"].time > 14.0)
        this.Note.SetActive(false);
      else if ((double) this.CharacterAnimation["keepNote_00"].time > 4.5)
        this.Note.SetActive(true);
      if ((double) this.CharacterAnimation["keepNote_00"].time < (double) this.CharacterAnimation["keepNote_00"].length)
        return;
      Debug.Log((object) "Sprinting to confession tree.");
      this.CurrentDestination = this.StudentManager.SuitorConfessionSpot;
      this.Pathfinding.target = this.StudentManager.SuitorConfessionSpot;
      this.Pathfinding.canSearch = true;
      this.Pathfinding.canMove = true;
      this.Pathfinding.speed = 4f;
      this.Note.SetActive(false);
      this.CharacterAnimation.CrossFade(this.SprintAnim);
      ++this.ConfessPhase;
    }
    else if (this.ConfessPhase == 2)
    {
      if ((double) this.DistanceToDestination >= 0.5)
        return;
      this.CharacterAnimation.CrossFade("exhausted_00");
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
      ++this.ConfessPhase;
    }
    else
    {
      if (this.ConfessPhase != 3)
        return;
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
      this.MoveTowardsTarget(this.CurrentDestination.position);
      this.CharacterAnimation.CrossFade("exhausted_00");
    }
  }

  private void UpdateMisc()
  {
    if ((double) this.IgnoreTimer > 0.0)
      this.IgnoreTimer = Mathf.MoveTowards(this.IgnoreTimer, 0.0f, Time.deltaTime);
    if (!this.Fleeing)
    {
      if ((double) this.transform.position.z < -100.0)
      {
        if ((double) this.transform.position.y >= -10.0 || this.StudentID <= 1 || this.Phase <= 1)
          return;
        this.gameObject.SetActive(false);
      }
      else
      {
        if ((double) this.transform.position.y < -0.10000000149011612)
          this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
        if (this.Dying || this.Distracted || this.WalkBack || this.Waiting || this.Guarding || this.WitnessedMurder || this.WitnessedCorpse || this.Blind || this.SentHome || this.SentToLocker || this.TurnOffRadio || this.Wet || this.InvestigatingBloodPool || this.ReturningMisplacedWeapon || this.Yandere.Egg || this.StudentManager.Pose || this.ShoeRemoval.enabled || this.Drownable)
          return;
        if (this.StudentManager.MissionMode && (double) this.DistanceToPlayer < 0.5)
        {
          Debug.Log((object) "This student cannot be interacted with right now.");
          this.Yandere.Shutter.FaceStudent = this;
          this.Yandere.Shutter.Penalize();
        }
        if ((this.Club == ClubType.Council || this.Shovey && !this.Following) && !this.WitnessedSomething)
        {
          if ((double) this.DistanceToPlayer < 5.0)
          {
            if ((double) this.DistanceToPlayer < 2.0)
              this.StudentManager.TutorialWindow.ShowCouncilMessage = true;
            if ((double) Mathf.Abs(Vector3.Angle(-this.transform.forward, this.Yandere.transform.position - this.transform.position)) <= 45.0 && this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && this.Yandere.CanMove && ((double) this.Yandere.h != 0.0 || (double) this.Yandere.v != 0.0) && (this.Yandere.Running || (double) this.DistanceToPlayer < 2.0))
            {
              if (this.Investigating)
                this.StopInvestigating();
              Debug.Log((object) (this.Name + " was alarmed because Yandere-chan was moving nearby."));
              this.DistractionSpot = this.Yandere.transform.position;
              this.Alarm = 200f;
              this.TemporarilyBlind = true;
              this.FocusOnYandere = true;
              this.Routine = false;
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
            }
          }
          if ((double) this.DistanceToPlayer < 1.1000000238418579 && !this.Yandere.Invisible && (double) Mathf.Abs(Vector3.Angle(-this.transform.forward, this.Yandere.transform.position - this.transform.position)) > 45.0 && (this.Yandere.Armed || this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed) && this.Prompt.InSight)
          {
            if (this.Yandere.Armed && !this.Yandere.EquippedWeapon.Suspicious && !this.WitnessedMurder)
            {
              Debug.Log((object) (this.Name + " is shoving the player from this place in the code. 2"));
              this.Shove();
            }
            else
            {
              Debug.Log((object) "Calling ''Spray()'' from this part of the code. 4");
              this.Spray();
            }
          }
        }
        if ((this.Club != ClubType.Council || this.Spraying) && (this.Club != ClubType.Delinquent || this.Injured || this.RespectEarned || this.Vomiting || this.Emetic || this.Headache || this.Sedated || this.Lethal) && (!this.Shovey || this.Spraying || this.Following) || (double) this.DistanceToPlayer >= 0.5 || !this.Yandere.CanMove || (double) this.Yandere.h == 0.0 && (double) this.Yandere.v == 0.0)
          return;
        if (this.Club == ClubType.Delinquent)
        {
          this.Subtitle.Speaker = this;
          this.Subtitle.UpdateLabel(SubtitleType.DelinquentShove, 0, 3f);
        }
        Debug.Log((object) (this.Name + " is shoving the player from this place in the code. 3"));
        this.Shove();
      }
    }
    else
    {
      if (this.Club != ClubType.Council && !this.Shovey || (double) this.DistanceToPlayer >= 1.1000000238418579 || this.Yandere.Invisible || (double) Mathf.Abs(Vector3.Angle(-this.transform.forward, this.Yandere.transform.position - this.transform.position)) <= 45.0 || (this.IgnoringPettyActions || !this.Yandere.Armed || !this.Yandere.EquippedWeapon.Suspicious) && (!this.Yandere.Carrying || this.Yandere.CurrentRagdoll.Concealed) && (!this.Yandere.Dragging || this.Yandere.CurrentRagdoll.Concealed) || !this.Prompt.InSight)
        return;
      Debug.Log((object) (this.Name + " will now decide whether to spray or shove the protagonist."));
      if (this.Yandere.Armed && !this.Yandere.EquippedWeapon.Suspicious && !this.WitnessedMurder)
      {
        Debug.Log((object) (this.Name + " is shoving the player from this place in the code. 4"));
        this.Shove();
      }
      else
      {
        Debug.Log((object) "Calling ''Spray()'' from this part of the code. 5");
        this.Spray();
      }
    }
  }

  private void LateUpdate()
  {
    if (this.StudentManager.DisableFarAnims && (double) this.DistanceToPlayer >= (double) this.StudentManager.FarAnimThreshold && this.CharacterAnimation.cullingType != AnimationCullingType.AlwaysAnimate && !this.WitnessCamera.Show)
      this.CharacterAnimation.enabled = false;
    else
      this.CharacterAnimation.enabled = true;
    if ((double) this.EyeShrink > 0.0)
    {
      if ((double) this.EyeShrink > 1.0)
        this.EyeShrink = 1f;
      this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
      this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
      this.LeftEye.localScale = new Vector3((float) (1.0 - (double) this.EyeShrink * 0.5), (float) (1.0 - (double) this.EyeShrink * 0.5), this.LeftEye.localScale.z);
      this.RightEye.localScale = new Vector3((float) (1.0 - (double) this.EyeShrink * 0.5), (float) (1.0 - (double) this.EyeShrink * 0.5), this.RightEye.localScale.z);
      this.PreviousEyeShrink = this.EyeShrink;
    }
    if (!this.Male)
    {
      if (this.Shy)
      {
        if (this.Routine)
          this.CharacterAnimation[this.ShyAnim].weight = this.Phase == 2 && (double) this.DistanceToDestination < 1.0 || this.Phase == 4 && (double) this.DistanceToDestination < 1.0 || this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes && (double) this.DistanceToDestination < 1.0 || this.Actions[this.Phase] == StudentActionType.Clean && (double) this.DistanceToDestination < 1.0 || this.Actions[this.Phase] == StudentActionType.Read && (double) this.DistanceToDestination < 1.0 ? Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0.0f, Time.deltaTime) : Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 1f, Time.deltaTime);
        else if (!this.Headache)
          this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0.0f, Time.deltaTime);
      }
      if ((double) this.BreastSize != 1.0 && (!this.BoobsResized || (double) this.RightBreast.localScale.x != (double) this.BreastSize))
      {
        this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
        this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
        if (!this.Cosmetic.CustomEyes)
        {
          this.RightBreast.gameObject.name = "RightBreastRENAMED";
          this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
        }
        this.BoobsResized = true;
      }
      if (this.Following)
      {
        if (this.Gush)
          this.Neck.LookAt(this.GushTarget);
        else
          this.Neck.LookAt(this.DefaultTarget);
      }
      if (this.StudentManager.Egg && this.SecurityCamera.activeInHierarchy)
        this.Head.localScale = new Vector3(0.0f, 0.0f, 0.0f);
      if (!this.Slave && this.Club == ClubType.Bully)
      {
        for (int index = 0; index < 4; ++index)
        {
          if ((UnityEngine.Object) this.Skirt[index] != (UnityEngine.Object) null)
          {
            Transform transform = this.Skirt[index].transform;
            transform.localScale = new Vector3(transform.localScale.x, 0.6666667f, transform.localScale.z);
          }
        }
      }
      if ((UnityEngine.Object) this.LongHair[0] != (UnityEngine.Object) null && this.MyBento.gameObject.activeInHierarchy && (UnityEngine.Object) this.MyBento.transform.parent != (UnityEngine.Object) null)
      {
        this.LongHair[0].eulerAngles = new Vector3(this.Spine.eulerAngles.x, this.Spine.eulerAngles.y, this.Spine.eulerAngles.z);
        this.LongHair[0].RotateAround(this.LongHair[0].position, this.transform.right, 180f);
        if ((UnityEngine.Object) this.LongHair[1] != (UnityEngine.Object) null)
        {
          this.LongHair[1].eulerAngles = new Vector3(this.Spine.eulerAngles.x, this.Spine.eulerAngles.y, this.Spine.eulerAngles.z);
          this.LongHair[1].RotateAround(this.LongHair[1].position, this.transform.right, 180f);
        }
      }
    }
    if (this.Club == ClubType.Photography || this.ClubActivity || this.Actions[this.Phase] == StudentActionType.Meeting)
    {
      if (this.Routine && !this.InEvent && !this.Meeting && !this.GoAway)
      {
        if (!this.StudentManager.Eighties)
        {
          if ((double) this.DistanceToDestination < (double) this.TargetDistance && this.Actions[this.Phase] == StudentActionType.SitAndSocialize || (double) this.DistanceToDestination < (double) this.TargetDistance && this.StudentID != 36 && this.Actions[this.Phase] == StudentActionType.Meeting || (double) this.DistanceToDestination < (double) this.TargetDistance && this.Actions[this.Phase] == StudentActionType.Sleuth && this.StudentManager.SleuthPhase != 2 && this.StudentManager.SleuthPhase != 3 || this.Club == ClubType.Photography && this.ClubActivity)
            this.BlendIntoSittingAnim();
          else
            this.BlendOutOfSittingAnim();
        }
        else if ((double) this.DistanceToDestination < (double) this.TargetDistance && this.StudentID != 36 && this.CurrentAction == StudentActionType.Meeting)
          this.BlendIntoSittingAnim();
        else
          this.BlendOutOfSittingAnim();
      }
      else
        this.BlendOutOfSittingAnim();
    }
    if (this.DK)
    {
      this.Arm[0].localScale = new Vector3(2f, 2f, 2f);
      this.Arm[1].localScale = new Vector3(2f, 2f, 2f);
      this.Head.localScale = new Vector3(2f, 2f, 2f);
    }
    if (this.Fate > 0 && (double) this.Clock.HourTime > (double) this.TimeOfDeath)
    {
      this.Yandere.TargetStudent = this;
      this.StudentManager.Shinigami.Effect = this.Fate - 1;
      this.StudentManager.Shinigami.Attack();
      this.Yandere.TargetStudent = (StudentScript) null;
      this.Fate = 0;
    }
    if (this.Yandere.BlackHole && (double) this.DistanceToPlayer < 2.5)
    {
      if ((UnityEngine.Object) this.DeathScream != (UnityEngine.Object) null)
        UnityEngine.Object.Instantiate<GameObject>(this.DeathScream, this.transform.position + Vector3.up, Quaternion.identity);
      this.BlackHoleEffect[0].enabled = true;
      this.BlackHoleEffect[1].enabled = true;
      this.BlackHoleEffect[2].enabled = true;
      this.CharacterAnimation[this.WetAnim].weight = 0.0f;
      this.DeathType = DeathType.EasterEgg;
      this.CharacterAnimation.Stop();
      this.Suck.enabled = true;
      this.BecomeRagdoll();
      this.Dying = true;
    }
    if (this.CameraReacting && (this.StudentManager.NEStairs.bounds.Contains(this.transform.position) || this.StudentManager.NWStairs.bounds.Contains(this.transform.position) || this.StudentManager.SEStairs.bounds.Contains(this.transform.position) || this.StudentManager.SWStairs.bounds.Contains(this.transform.position)) && (UnityEngine.Object) this.Spine != (UnityEngine.Object) null)
    {
      this.Spine.LookAt(this.Yandere.Spine[0]);
      this.Head.LookAt(this.Yandere.Head);
    }
    if ((double) this.DistanceToPlayer < 0.5 && !this.CameraReacting && !this.Struggling && !this.Yandere.Attacking && !this.Distracted && !this.Posing && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
    {
      this.PersonalSpaceTimer += Time.deltaTime;
      if ((double) this.PersonalSpaceTimer > 4.0)
      {
        this.Yandere.Shutter.FaceStudent = this;
        this.Yandere.Shutter.Penalize();
      }
    }
    if (!((UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) null))
      return;
    Debug.Log((object) (this.Name + "'s CurrentDestination became ''null'' for some reason."));
    this.CurrentDestination = this.Destinations[this.Phase];
    this.Pathfinding.target = this.CurrentDestination;
  }

  public void CalculateReputationPenalty()
  {
    Debug.Log((object) "Calculating reputation penalty now.");
    if (this.Male && this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 2 || this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 4)
      this.RepDeduction += this.RepLoss * 0.2f;
    if ((double) PlayerGlobals.Reputation < -33.333328247070313)
    {
      Debug.Log((object) "Rep is low. Rep loss should be harsher.");
      this.RepDeduction -= this.RepLoss * 0.2f;
    }
    if ((double) PlayerGlobals.Reputation > 33.333328247070313)
    {
      Debug.Log((object) "Rep is high. Rep loss should be lower.");
      this.RepDeduction += this.RepLoss * 0.2f;
    }
    if (this.Friend)
      this.RepDeduction += this.RepLoss * 0.2f;
    if (PlayerGlobals.PantiesEquipped == 1)
    {
      Debug.Log((object) "Wearing the less-rep-loss panties.");
      this.RepDeduction += this.RepLoss * 0.2f;
    }
    if (this.Yandere.Class.SocialBonus > 0)
      this.RepDeduction += this.RepLoss * 0.2f;
    this.ChameleonCheck();
    if (this.Chameleon)
    {
      Debug.Log((object) "Chopping reputation loss in half!");
      this.RepLoss *= 0.5f;
    }
    if (this.Yandere.Persona == YanderePersonaType.Aggressive)
      this.RepLoss *= 2f;
    if (this.Club == ClubType.Bully)
      this.RepLoss *= 2f;
    if (this.Witnessed == StudentWitnessType.CleaningItem)
      this.RepLoss *= 0.5f;
    if (this.Club != ClubType.Delinquent)
      return;
    this.RepDeduction = 0.0f;
    this.RepLoss = 0.0f;
  }

  public void MoveTowardsTarget(Vector3 target)
  {
    if ((double) Time.timeScale <= 9.9999997473787516E-05 || !this.MyController.enabled)
      return;
    Vector3 vector3 = target - this.transform.position;
    if ((double) vector3.sqrMagnitude <= 9.9999999747524271E-07)
      return;
    int num = (int) this.MyController.Move(vector3 * (Time.deltaTime * 5f / Time.timeScale));
  }

  private void LookTowardsTarget(Vector3 target)
  {
    double timeScale = (double) Time.timeScale;
  }

  public void AttackReaction()
  {
    Debug.Log((object) (this.Name + " is being attacked."));
    if (this.SolvingPuzzle)
      this.DropPuzzle();
    if ((UnityEngine.Object) this.HorudaCollider != (UnityEngine.Object) null)
      this.HorudaCollider.gameObject.SetActive(false);
    this.BountyCollider.SetActive(false);
    if (this.PhotoEvidence)
    {
      this.SmartPhone.GetComponent<SmartphoneScript>().enabled = true;
      this.SmartPhone.GetComponent<PromptScript>().enabled = true;
      this.SmartPhone.GetComponent<Rigidbody>().useGravity = true;
      this.SmartPhone.GetComponent<Collider>().enabled = true;
      this.SmartPhone.transform.parent = (Transform) null;
      this.SmartPhone.layer = 15;
    }
    else
      this.SmartPhone.SetActive(false);
    if (!this.WitnessedMurder)
      this.Yandere.AttackManager.Stealth = (double) Mathf.Abs(Vector3.Angle(-this.transform.forward, this.Yandere.transform.position - this.transform.position)) <= 45.0;
    if (this.ReturningMisplacedWeapon)
    {
      Debug.Log((object) (this.Name + " was in the process of returning a weapon when they were attacked."));
      this.DropMisplacedWeapon();
    }
    if ((UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null)
    {
      Debug.Log((object) (this.Name + "'s BloodPool was not null."));
      if ((UnityEngine.Object) this.BloodPool.GetComponent<WeaponScript>() != (UnityEngine.Object) null && (UnityEngine.Object) this.BloodPool.GetComponent<WeaponScript>().Returner == (UnityEngine.Object) this)
      {
        this.BloodPool.GetComponent<WeaponScript>().Returner = (StudentScript) null;
        this.BloodPool.GetComponent<WeaponScript>().Drop();
        this.BloodPool.GetComponent<WeaponScript>().enabled = true;
        this.BloodPool = (Transform) null;
      }
    }
    if (this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 27)
      this.StudentManager.TranqDetector.GarroteAttack();
    if (!this.Male)
    {
      if (this.Club != ClubType.Council)
        this.StudentManager.TranqDetector.TranqCheck();
      this.CharacterAnimation["f02_smile_00"].weight = 0.0f;
      this.SmartPhone.SetActive(false);
      if ((TrackedReference) this.CharacterAnimation[this.ShyAnim] != (TrackedReference) null)
        this.CharacterAnimation[this.ShyAnim].weight = 0.0f;
      this.Shy = false;
    }
    this.WitnessCamera.Show = false;
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.Yandere.CharacterAnimation["f02_idleShort_00"].time = 0.0f;
    this.Yandere.CharacterAnimation["f02_swingA_00"].time = 0.0f;
    this.CharacterAnimation[this.WetAnim].weight = 0.0f;
    this.Yandere.HipCollider.enabled = true;
    this.Yandere.TargetStudent = this;
    this.Yandere.YandereVision = false;
    this.Yandere.Attacking = true;
    this.Yandere.CanMove = false;
    if (this.Yandere.Equipped > 0 && this.Yandere.EquippedWeapon.AnimID == 2)
      this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[2]].weight = 0.0f;
    if ((UnityEngine.Object) this.DetectionMarker != (UnityEngine.Object) null)
      this.DetectionMarker.Tex.enabled = false;
    this.EmptyHands();
    this.DropPlate();
    this.MyController.radius = 0.0f;
    if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
    {
      this.Countdown.gameObject.SetActive(false);
      this.ChaseCamera.SetActive(false);
      if ((UnityEngine.Object) this.StudentManager.ChaseCamera == (UnityEngine.Object) this.ChaseCamera)
        this.StudentManager.ChaseCamera = (GameObject) null;
    }
    this.VomitEmitter.gameObject.SetActive(false);
    this.InvestigatingBloodPool = false;
    this.SeekingMedicine = false;
    this.Investigating = false;
    this.Pen.SetActive(false);
    this.EatingSnack = false;
    this.SpeechLines.Stop();
    this.Attacked = true;
    this.Alarmed = false;
    this.Fleeing = false;
    this.Routine = false;
    this.ReadPhase = 0;
    this.Dying = true;
    this.Wet = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    if (this.Following)
    {
      Debug.Log((object) "Yandere-chan's follower is being set to ''null''.");
      this.Hearts.emission.enabled = false;
      this.FollowCountdown.gameObject.SetActive(false);
      this.Yandere.Follower = (StudentScript) null;
      --this.Yandere.Followers;
      this.Following = false;
    }
    if (this.Distracting || (UnityEngine.Object) this.DistractionTarget != (UnityEngine.Object) null && this.DistractionTarget.Distracted)
    {
      Debug.Log((object) ("At the time of being attacked, " + this.Name + " was distracting " + this.DistractionTarget.Name + "."));
      this.DistractionTarget.TargetedForDistraction = false;
      this.DistractionTarget.Octodog.SetActive(false);
      this.DistractionTarget.Distracted = false;
      this.Distracting = false;
    }
    if (this.Teacher)
    {
      if (this.Yandere.Armed && this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus > 0 && this.Yandere.EquippedWeapon.Type == WeaponType.Knife || this.Yandere.Club == ClubType.MartialArts && this.Yandere.Armed && this.Yandere.EquippedWeapon.Type == WeaponType.Knife)
      {
        Debug.Log((object) (this.Name + " has called the ''BeginStruggle'' function."));
        this.Pathfinding.target = this.Yandere.transform;
        this.CurrentDestination = this.Yandere.transform;
        this.Yandere.Attacking = false;
        this.Attacked = false;
        this.Fleeing = true;
        this.Dying = false;
        this.Persona = PersonaType.Heroic;
        this.BeginStruggle();
      }
      else
      {
        Debug.Log((object) (this.Name + " just countered Yandere-chan."));
        this.Yandere.HeartRate.gameObject.SetActive(false);
        this.Yandere.ShoulderCamera.Counter = true;
        this.Yandere.ShoulderCamera.OverShoulder = false;
        this.Yandere.RPGCamera.enabled = false;
        this.Yandere.Senpai = this.transform;
        this.Yandere.Attacking = true;
        this.Yandere.CanMove = false;
        this.Yandere.Talking = false;
        this.Yandere.Noticed = true;
        this.Yandere.HUD.alpha = 0.0f;
      }
    }
    else if (this.Strength == 9 && !this.Emetic && !this.Lethal && !this.Sedated && !this.Headache)
    {
      if (!this.WitnessedMurder)
        this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 3, 11f);
      this.Yandere.CharacterAnimation.CrossFade("f02_moCounterA_00");
      this.Yandere.HeartRate.gameObject.SetActive(false);
      this.Yandere.ShoulderCamera.ObstacleCounter = true;
      this.Yandere.ShoulderCamera.OverShoulder = false;
      this.Yandere.RPGCamera.enabled = false;
      this.Yandere.Senpai = this.transform;
      this.Yandere.Attacking = true;
      this.Yandere.CanMove = false;
      this.Yandere.Talking = false;
      this.Yandere.Noticed = true;
      this.Yandere.HUD.alpha = 0.0f;
    }
    else
    {
      if (!this.Yandere.AttackManager.Stealth)
      {
        this.Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
        this.SpawnAlarmDisc();
      }
      if (this.Yandere.SanityBased)
        this.Yandere.AttackManager.Attack(this.Character, this.Yandere.EquippedWeapon);
    }
    if ((UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) this)
    {
      this.StudentManager.Reporter = (StudentScript) null;
      if (this.ReportPhase == 0)
      {
        Debug.Log((object) "A reporter died before being able to report a corpse. Corpse position reset.");
        this.StudentManager.CorpseLocation.position = Vector3.zero;
      }
    }
    if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this)
    {
      Debug.Log((object) (this.Name + " just set StudentManager.BloodReporter to ''null''."));
      this.StudentManager.BloodReporter = (StudentScript) null;
    }
    if (this.Club == ClubType.Delinquent && (UnityEngine.Object) this.MyWeapon != (UnityEngine.Object) null && (UnityEngine.Object) this.MyWeapon.transform.parent == (UnityEngine.Object) this.ItemParent)
    {
      this.MyWeapon.transform.parent = (Transform) null;
      this.MyWeapon.MyCollider.enabled = true;
      this.MyWeapon.Prompt.enabled = true;
      Rigidbody component = this.MyWeapon.GetComponent<Rigidbody>();
      component.constraints = RigidbodyConstraints.None;
      component.isKinematic = false;
      component.useGravity = true;
    }
    if (this.PhotoEvidence)
    {
      this.CameraFlash.SetActive(false);
      this.SmartPhone.SetActive(true);
    }
    if (!((UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null))
      return;
    WeaponScript component1 = this.BloodPool.GetComponent<WeaponScript>();
    if (!((UnityEngine.Object) component1 != (UnityEngine.Object) null) || !((UnityEngine.Object) component1.Returner == (UnityEngine.Object) this))
      return;
    component1.Returner = (StudentScript) null;
  }

  public void DropPlate()
  {
    if (!((UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null))
      return;
    if ((UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand)
    {
      this.MyPlate.GetComponent<Rigidbody>().isKinematic = false;
      this.MyPlate.GetComponent<Rigidbody>().useGravity = true;
      this.MyPlate.GetComponent<Collider>().enabled = true;
      this.MyPlate.parent = (Transform) null;
      this.MyPlate.gameObject.SetActive(true);
    }
    if (!this.Distracting)
      return;
    this.DistractionTarget.TargetedForDistraction = false;
    this.Distracting = false;
    this.IdleAnim = this.OriginalIdleAnim;
    this.WalkAnim = this.OriginalWalkAnim;
  }

  public void SenpaiNoticed()
  {
    Debug.Log((object) "The ''SenpaiNoticed'' function has been called.");
    if (this.Yandere.Talking)
      this.Yandere.StudentManager.DialogueWheel.End();
    if (this.Yandere.Shutter.Snapping)
    {
      Debug.Log((object) "THE SHUTTER WAS SNAPPING AT THE MOMENT THAT AYANO WAS NOTICED!");
      this.Yandere.Shutter.ResumeGameplay();
      this.Yandere.StopAiming();
      this.Yandere.Shutter.Snapping = false;
      this.Yandere.Shutter.Close = false;
      this.Yandere.Shutter.Timer = 0.0f;
    }
    this.Yandere.Stance.Current = StanceType.Standing;
    this.Yandere.CrawlTimer = 0.0f;
    this.Yandere.Uncrouch();
    this.Yandere.Noticed = true;
    if ((UnityEngine.Object) this.WeaponToTakeAway != (UnityEngine.Object) null)
    {
      Debug.Log((object) "Yandere-chan was holding a weapon at the time she was caught.");
      if (this.Teacher && !this.Yandere.Attacking)
      {
        if (this.Yandere.EquippedWeapon.WeaponID == 23)
        {
          this.WeaponToTakeAway.transform.parent = (Transform) null;
          this.WeaponToTakeAway.transform.position = this.WeaponToTakeAway.GetComponent<WeaponScript>().StartingPosition;
          this.WeaponToTakeAway.transform.eulerAngles = this.WeaponToTakeAway.GetComponent<WeaponScript>().StartingRotation;
          this.WeaponToTakeAway.GetComponent<WeaponScript>().Prompt.enabled = true;
          this.WeaponToTakeAway.GetComponent<WeaponScript>().enabled = true;
          this.WeaponToTakeAway.GetComponent<WeaponScript>().Drop();
          this.WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.useGravity = false;
          this.WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.isKinematic = true;
        }
        else
        {
          Debug.Log((object) "That weapon was splattered with blood!");
          if (this.Yandere.EquippedWeapon.Bloody)
            this.Police.WasHoldingBloodyWeapon = true;
          this.Yandere.EquippedWeapon.Drop();
          this.WeaponToTakeAway.transform.position = this.StudentManager.WeaponBoxSpot.parent.position + new Vector3(0.0f, 1f, 0.0f);
          this.WeaponToTakeAway.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
          this.WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.useGravity = true;
          this.WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.isKinematic = false;
        }
        Debug.Log((object) "The weapon has been taken away...");
      }
    }
    if (this.Yandere.StolenObjectID == 1)
    {
      Debug.Log((object) "Yandere-chan was spotted stealing cigarettes.");
      this.Yandere.Inventory.Cigs = false;
    }
    this.WeaponToTakeAway = (WeaponScript) null;
    if (!this.Yandere.Attacking)
      this.Yandere.EmptyHands();
    this.Yandere.Senpai = this.transform;
    if (this.Yandere.Aiming)
      this.Yandere.StopAiming();
    this.Yandere.PauseScreen.Hint.MyPanel.alpha = 0.0f;
    this.Yandere.DetectionPanel.alpha = 0.0f;
    this.Yandere.RPGCamera.mouseSpeed = 0.0f;
    this.Yandere.LaughIntensity = 0.0f;
    this.Yandere.HUD.alpha = 0.0f;
    this.Yandere.EyeShrink = 0.0f;
    this.Yandere.Sanity = 100f;
    this.Yandere.ProgressBar.transform.parent.gameObject.SetActive(false);
    this.Yandere.HeartRate.gameObject.SetActive(false);
    this.Yandere.Stance.Current = StanceType.Standing;
    this.Yandere.SneakShotPhone.SetActive(false);
    this.Yandere.ShoulderCamera.OverShoulder = false;
    this.Yandere.DelinquentFighting = false;
    this.Yandere.FakingReaction = false;
    this.Yandere.YandereVision = false;
    this.Yandere.CannotRecover = true;
    this.Yandere.SneakingShot = false;
    this.Yandere.Police.Show = false;
    this.Yandere.Cauterizing = false;
    this.Yandere.Poisoning = false;
    this.Yandere.Rummaging = false;
    this.Yandere.Laughing = false;
    this.Yandere.CanMove = false;
    this.Yandere.Dipping = false;
    this.Yandere.Mopping = false;
    this.Yandere.Talking = false;
    this.Yandere.Hiding = false;
    this.Yandere.Lewd = false;
    this.Yandere.Jukebox.GameOver();
    this.StudentManager.GameOverIminent = true;
    this.StudentManager.StopMoving();
    if (this.Teacher || this.StudentID == 1)
    {
      if (this.Club != ClubType.Council)
        this.IdleAnim = this.OriginalIdleAnim;
      if ((UnityEngine.Object) this.Giggle != (UnityEngine.Object) null)
        this.ForgetGiggle();
      this.AlarmTimer = 0.0f;
      this.GoAway = false;
      this.enabled = true;
      this.Stop = false;
    }
    if (this.StudentID == 1)
    {
      this.StudentManager.FountainAudio[0].Stop();
      this.StudentManager.FountainAudio[1].Stop();
    }
    if (!this.StudentManager.Eighties)
      return;
    this.Yandere.LoseGentleEyes();
  }

  private void WitnessMurder()
  {
    Debug.Log((object) (this.Name + " just realized that Yandere-chan is responsible for a murder!"));
    ++this.Yandere.Alerts;
    if ((UnityEngine.Object) this.Corpse == (UnityEngine.Object) null)
      this.Corpse = this.Yandere.CurrentRagdoll;
    this.RespectEarned = false;
    if (this.Fleeing && this.WitnessedBloodPool || this.ReportPhase == 2)
    {
      this.WitnessedBloodyWeapon = false;
      this.WitnessedBloodPool = false;
      this.WitnessedSomething = false;
      this.WitnessedWeapon = false;
      this.WitnessedLimb = false;
      this.Fleeing = false;
      this.ReportPhase = 0;
    }
    this.CharacterAnimation[this.ScaredAnim].time = 0.0f;
    this.CameraFlash.SetActive(false);
    if (!this.Male)
    {
      this.CharacterAnimation["f02_smile_00"].weight = 0.0f;
      this.WateringCan.SetActive(false);
    }
    if ((UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand)
    {
      this.MyPlate.GetComponent<Rigidbody>().isKinematic = false;
      this.MyPlate.GetComponent<Rigidbody>().useGravity = true;
      this.MyPlate.GetComponent<Collider>().enabled = true;
      this.MyPlate.parent = (Transform) null;
    }
    this.EmptyHands();
    ++this.MurdersWitnessed;
    this.SpeechLines.Stop();
    this.WitnessedBloodyWeapon = false;
    this.WitnessedBloodPool = false;
    this.WitnessedSomething = false;
    this.WitnessedWeapon = false;
    this.WitnessedLimb = false;
    if (this.ReturningMisplacedWeapon)
      this.DropMisplacedWeapon();
    this.SpecialRivalDeathReaction = false;
    this.SenpaiWitnessingRivalDie = false;
    this.ReturningMisplacedWeapon = false;
    this.InvestigatingBloodPool = false;
    this.CameraReacting = false;
    this.FocusOnStudent = false;
    this.FocusOnYandere = false;
    this.TakingOutTrash = false;
    this.WitnessedMurder = true;
    this.Investigating = false;
    this.Distracting = false;
    this.EatingSnack = false;
    this.Threatened = false;
    this.Distracted = false;
    this.Reacted = false;
    this.Routine = false;
    this.Alarmed = true;
    this.NoTalk = false;
    this.Wet = false;
    if (this.OriginalPersona != PersonaType.Violent && this.Persona != this.OriginalPersona)
    {
      Debug.Log((object) (this.Name + " is reverting back into their original Persona: " + this.OriginalPersona.ToString()));
      this.Persona = this.OriginalPersona;
      this.SwitchBack = false;
      if (this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Dangerous || this.Persona == PersonaType.Protective)
        this.PersonaReaction();
    }
    if (this.Persona == PersonaType.Spiteful && (UnityEngine.Object) this.Yandere.TargetStudent != (UnityEngine.Object) null)
    {
      Debug.Log((object) "A Spiteful student witnessed a murder.");
      if (this.Bullied && this.Yandere.TargetStudent.Club == ClubType.Bully || this.Yandere.TargetStudent.Bullied)
      {
        this.ScaredAnim = this.EvilWitnessAnim;
        this.Persona = PersonaType.Evil;
      }
    }
    if (this.Club == ClubType.Delinquent)
    {
      Debug.Log((object) "A Delinquent witnessed a murder.");
      if ((UnityEngine.Object) this.Yandere.TargetStudent != (UnityEngine.Object) null && this.Yandere.TargetStudent.Club == ClubType.Bully)
      {
        this.ScaredAnim = this.EvilWitnessAnim;
        this.Persona = PersonaType.Evil;
        this.FoundEnemyCorpse = true;
      }
      if ((this.Yandere.Lifting && !this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed) && this.Yandere.CurrentRagdoll.Student.Club == ClubType.Bully)
      {
        this.ScaredAnim = this.EvilWitnessAnim;
        this.Persona = PersonaType.Evil;
      }
    }
    if (this.Persona == PersonaType.Sleuth)
    {
      Debug.Log((object) "A Sleuth is witnessing a murder.");
      if (this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Lifting && !this.Yandere.CurrentRagdoll.Concealed || (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && (bool) (UnityEngine.Object) this.Yandere.PickUp.BodyPart)
      {
        if (!this.Sleuthing)
        {
          Debug.Log((object) "A Sleuth is changing their Persona.");
          this.Persona = this.StudentID != 56 ? (!this.StudentManager.Eighties ? PersonaType.SocialButterfly : PersonaType.LandlineUser) : PersonaType.Heroic;
        }
        else
          this.Persona = !this.StudentManager.Eighties ? PersonaType.SocialButterfly : PersonaType.LandlineUser;
      }
    }
    if (this.Persona == PersonaType.Heroic)
      this.Yandere.Pursuer = this;
    if (this.StudentID > 1 || (UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null)
    {
      this.SetOutlinesRed();
      this.SummonWitnessCamera();
      this.CameraEffects.MurderWitnessed();
      this.Witnessed = StudentWitnessType.Murder;
      if (this.Persona != PersonaType.Evil)
        ++this.Police.Witnesses;
      if (this.Teacher)
        this.StudentManager.Reporter = this;
      if (this.Talking)
      {
        this.DialogueWheel.End();
        this.Hearts.emission.enabled = false;
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.Obstacle.enabled = false;
        this.Talk.enabled = false;
        this.Talking = false;
        this.Waiting = false;
        this.StudentManager.EnablePrompts();
      }
      if ((UnityEngine.Object) this.Prompt.Label[0] != (UnityEngine.Object) null && !this.StudentManager.EmptyDemon)
      {
        this.Prompt.Label[0].text = "     Talk";
        this.Prompt.HideButton[0] = true;
      }
    }
    else
    {
      if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.Egg)
        this.SenpaiNoticed();
      this.Fleeing = false;
      this.EyeShrink = 0.0f;
      this.Yandere.Noticed = true;
      this.Yandere.Talking = false;
      this.CameraEffects.MurderWitnessed();
      this.Yandere.ShoulderCamera.OverShoulder = false;
      this.CharacterAnimation.CrossFade(this.ScaredAnim);
      this.CharacterAnimation["scaredFace_00"].weight = 1f;
      if (this.StudentID == 1)
        Debug.Log((object) "Senpai entered his scared animation.");
    }
    if (this.Persona == PersonaType.TeachersPet && (UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) null && !this.Police.Called)
    {
      this.StudentManager.CorpseLocation.position = this.Yandere.transform.position;
      this.StudentManager.LowerCorpsePosition();
      this.StudentManager.Reporter = this;
      this.ReportingMurder = true;
    }
    if (this.Following)
    {
      this.Hearts.emission.enabled = false;
      this.FollowCountdown.gameObject.SetActive(false);
      this.Yandere.Follower = (StudentScript) null;
      --this.Yandere.Followers;
      this.Following = false;
    }
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    if (!this.Phoneless && (this.Persona == PersonaType.PhoneAddict || this.Sleuthing))
      this.SmartPhone.SetActive(true);
    if (this.SmartPhone.activeInHierarchy)
    {
      if (this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Dangerous && this.Persona != PersonaType.Evil && this.Persona != PersonaType.Violent && this.Persona != PersonaType.Coward && !this.Teacher)
      {
        this.Persona = PersonaType.PhoneAddict;
        this.SprintAnim = this.Sleuthing ? this.SleuthReportAnim : this.PhoneAnims[2];
      }
      else
        this.SmartPhone.SetActive(false);
    }
    this.StopPairing();
    if (this.Persona != PersonaType.Heroic)
    {
      this.AlarmTimer = 0.0f;
      this.Alarm = 0.0f;
    }
    if (this.Teacher)
    {
      if (!this.Yandere.Chased)
      {
        Debug.Log((object) "A teacher has reached ChaseYandere through WitnessMurder.");
        this.ChaseYandere();
      }
    }
    else
      this.SpawnAlarmDisc();
    if (!this.PinDownWitness && this.Persona != PersonaType.Evil)
    {
      ++this.StudentManager.Witnesses;
      this.StudentManager.WitnessList[this.StudentManager.Witnesses] = this;
      this.StudentManager.PinDownCheck();
      this.PinDownWitness = true;
    }
    if (this.Persona == PersonaType.Violent)
    {
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
    }
    if ((UnityEngine.Object) this.Yandere.Mask == (UnityEngine.Object) null)
    {
      this.SawMask = false;
      if (this.Persona != PersonaType.Evil)
        this.Grudge = true;
    }
    else
      this.SawMask = true;
    this.StudentManager.UpdateMe(this.StudentID);
  }

  public void DropMisplacedWeapon()
  {
    this.WitnessedWeapon = false;
    this.InvestigatingBloodPool = false;
    this.ReturningMisplacedWeaponPhase = 0;
    this.ReturningMisplacedWeapon = false;
    this.BloodPool.GetComponent<WeaponScript>().Returner = (StudentScript) null;
    this.BloodPool.GetComponent<WeaponScript>().Drop();
    this.BloodPool.GetComponent<WeaponScript>().enabled = true;
    this.BloodPool = (Transform) null;
    this.WalkAnim = this.BeforeReturnAnim;
  }

  private void ChaseYandere()
  {
    Debug.Log((object) (this.Name + " has begun to chase Yandere-chan."));
    this.CurrentDestination = this.Yandere.transform;
    this.Pathfinding.target = this.Yandere.transform;
    this.Pathfinding.speed = 5f;
    if ((UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) null)
      this.Yandere.Pursuer = this;
    this.TargetDistance = 1f;
    this.AlarmTimer = 0.0f;
    this.Chasing = false;
    this.Fleeing = false;
    this.StudentManager.UpdateStudents();
  }

  private void PersonaReaction()
  {
    Debug.Log((object) (this.Name + " just called PersonaReaction(). As of now, they are a: " + this.Persona.ToString() + "."));
    if (this.Persona == PersonaType.Sleuth)
    {
      if (this.Sleuthing)
      {
        if (!this.Phoneless)
        {
          this.Persona = PersonaType.PhoneAddict;
          this.SmartPhone.SetActive(true);
        }
        else
          this.Persona = PersonaType.Loner;
      }
      else
        this.Persona = !this.StudentManager.Eighties ? (this.Phoneless ? PersonaType.Loner : PersonaType.SocialButterfly) : PersonaType.LandlineUser;
    }
    if (this.Persona == PersonaType.PhoneAddict && this.Phoneless || this.Persona == PersonaType.SocialButterfly && this.Phoneless)
      this.Persona = PersonaType.Loner;
    if (!this.Indoors && this.WitnessedMurder && !this.Rival)
    {
      Debug.Log((object) (this.Name + "'s current Persona is: " + this.Persona.ToString()));
      if (this.Persona != PersonaType.Evil && this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Coward && this.Persona != PersonaType.PhoneAddict && this.Persona != PersonaType.Protective && this.Persona != PersonaType.Violent || this.Injured)
      {
        Debug.Log((object) (this.Name + " is switching to the Loner Persona."));
        this.Persona = PersonaType.Loner;
      }
    }
    if (!this.WitnessedMurder)
    {
      if (this.Persona == PersonaType.Heroic)
      {
        this.SwitchBack = true;
        this.Persona = (UnityEngine.Object) this.Corpse != (UnityEngine.Object) null ? PersonaType.TeachersPet : PersonaType.Loner;
      }
      else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Evil || this.Persona == PersonaType.Fragile)
        this.Persona = PersonaType.Loner;
      else if (this.Persona == PersonaType.Protective)
      {
        Debug.Log((object) ("Raibaru witnessed the corpse of " + this.Corpse.Student.Name + ", and is now switching to the Lovestruck Persona."));
        this.Persona = PersonaType.Lovestruck;
      }
    }
    if (this.Persona == PersonaType.Loner || this.Persona == PersonaType.Spiteful)
    {
      Debug.Log((object) (this.Name + " is looking in the Loner/Spiteful section of PersonaReaction() to decide what to do next."));
      if (this.Club == ClubType.Delinquent)
      {
        Debug.Log((object) "A delinquent turned into a loner, and now he is fleeing.");
        if (this.Injured)
        {
          this.Subtitle.Speaker = this;
          this.Subtitle.UpdateLabel(SubtitleType.DelinquentInjuredFlee, 1, 3f);
        }
        else if (this.FoundFriendCorpse)
        {
          this.Subtitle.Speaker = this;
          this.Subtitle.UpdateLabel(SubtitleType.DelinquentFriendFlee, 1, 3f);
        }
        else if (this.FoundEnemyCorpse)
        {
          this.Subtitle.Speaker = this;
          this.Subtitle.UpdateLabel(SubtitleType.DelinquentEnemyFlee, 1, 3f);
        }
        else
        {
          this.Subtitle.Speaker = this;
          this.Subtitle.UpdateLabel(SubtitleType.DelinquentFlee, 1, 3f);
        }
      }
      else if (this.WitnessedMurder)
        this.Subtitle.UpdateLabel(SubtitleType.LonerMurderReaction, 1, 3f);
      else
        this.Subtitle.UpdateLabel(SubtitleType.LonerCorpseReaction, 1, 3f);
      if (this.Schoolwear > 0)
      {
        if (!this.Bloody)
        {
          this.Pathfinding.target = this.StudentManager.Exit;
          this.TargetDistance = 0.0f;
          this.Routine = false;
          this.Fleeing = true;
        }
        else
        {
          this.FleeWhenClean = true;
          this.TargetDistance = 1f;
          this.BatheFast = true;
        }
      }
      else
      {
        this.FleeWhenClean = true;
        if (!this.Bloody)
        {
          this.BathePhase = 5;
          this.GoChange();
        }
        else
        {
          this.CurrentDestination = this.StudentManager.FastBatheSpot;
          this.Pathfinding.target = this.StudentManager.FastBatheSpot;
          this.TargetDistance = 1f;
          this.BatheFast = true;
        }
      }
      if ((UnityEngine.Object) this.Corpse != (UnityEngine.Object) null && this.StudentID == 1 && this.Corpse.Student.Rival)
      {
        this.CurrentDestination = this.Corpse.Student.Hips;
        this.Pathfinding.target = this.Corpse.Student.Hips;
        this.SenpaiWitnessingRivalDie = true;
        this.IgnoringPettyActions = true;
        this.DistanceToDestination = 1f;
        this.WitnessRivalDiePhase = 3;
        this.Routine = false;
        this.TargetDistance = 0.5f;
      }
    }
    else if (this.Persona == PersonaType.TeachersPet)
    {
      if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
      {
        if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) null)
        {
          if (this.Club != ClubType.Delinquent && !this.Police.Called && !this.LostTeacherTrust)
          {
            this.StudentManager.BloodLocation.position = this.BloodPool.transform.position;
            this.StudentManager.LowerBloodPosition();
            Debug.Log((object) (this.Name + " has become a ''blood reporter''."));
            this.StudentManager.BloodReporter = this;
            this.ReportingBlood = true;
            this.DetermineBloodLocation();
          }
          else
            this.ReportingBlood = false;
        }
      }
      else if ((UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) null && !this.Police.Called && (UnityEngine.Object) this.StudentManager.CorpseLocation != (UnityEngine.Object) null)
      {
        this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
        this.StudentManager.LowerCorpsePosition();
        Debug.Log((object) (this.Name + " has become a ''reporter''."));
        this.StudentManager.Reporter = this;
        this.ReportingMurder = true;
        this.IgnoringPettyActions = true;
        this.DetermineCorpseLocation();
      }
      if ((UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) this)
      {
        Debug.Log((object) (this.Name + " is running to a teacher to report murder."));
        this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
        this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
        this.TargetDistance = 2f;
        if (this.Club == ClubType.Council)
        {
          if (this.StudentID == 86)
            this.Subtitle.UpdateLabel(SubtitleType.StrictReport, 1, 5f);
          else if (this.StudentID == 87)
            this.Subtitle.UpdateLabel(SubtitleType.CasualReport, 1, 5f);
          else if (this.StudentID == 88)
            this.Subtitle.UpdateLabel(SubtitleType.GraceReport, 1, 5f);
          else if (this.StudentID == 89)
            this.Subtitle.UpdateLabel(SubtitleType.EdgyReport, 1, 5f);
        }
        else if (this.WitnessedMurder)
          this.Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 1, 3f);
        else if (this.WitnessedCorpse)
          this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 1, 3f);
      }
      else if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this)
      {
        Debug.Log((object) (this.Name + " is running to a teacher to report something."));
        this.DropPlate();
        this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
        this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
        this.TargetDistance = 2f;
        if (this.WitnessedLimb)
          this.Subtitle.UpdateLabel(SubtitleType.LimbReaction, 1, 3f);
        else if (this.WitnessedBloodyWeapon)
          this.Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 1, 3f);
        else if (this.WitnessedBloodPool)
          this.Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 1, 3f);
        else if (this.WitnessedWeapon)
          this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReport, 1, 3f);
      }
      else
      {
        Debug.Log((object) (this.Name + " found something scary, and is now deciding what to do next."));
        if (this.Club == ClubType.Council)
        {
          if (this.WitnessedCorpse)
          {
            if (this.StudentManager.CorpseLocation.position == Vector3.zero)
            {
              this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
              this.AssignCorpseGuardLocations();
            }
            if (this.StudentID == 86)
              this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[1];
            else if (this.StudentID == 87)
              this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[2];
            else if (this.StudentID == 88)
              this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[3];
            else if (this.StudentID == 89)
              this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[4];
            this.CurrentDestination = this.Pathfinding.target;
          }
          else
          {
            Debug.Log((object) "A student council member is being told to travel to ''BloodGuardLocation''.");
            if (this.StudentManager.BloodLocation.position == Vector3.zero)
            {
              this.StudentManager.BloodLocation.position = this.BloodPool.transform.position;
              this.AssignBloodGuardLocations();
            }
            if (this.StudentManager.BloodGuardLocation[1].position == Vector3.zero)
              this.AssignBloodGuardLocations();
            if (this.StudentID == 86)
              this.Pathfinding.target = this.StudentManager.BloodGuardLocation[1];
            else if (this.StudentID == 87)
              this.Pathfinding.target = this.StudentManager.BloodGuardLocation[2];
            else if (this.StudentID == 88)
              this.Pathfinding.target = this.StudentManager.BloodGuardLocation[3];
            else if (this.StudentID == 89)
              this.Pathfinding.target = this.StudentManager.BloodGuardLocation[4];
            this.CurrentDestination = this.Pathfinding.target;
            this.Guarding = true;
          }
        }
        else
        {
          Debug.Log((object) (this.Name + " is considering whether or not to hide in their classroom..."));
          if ((double) Vector3.Distance(this.transform.position, this.Seat.position) < 2.0)
          {
            Debug.Log((object) "...but there is danger in their classroom, so they will flee the school instead.");
            this.Pathfinding.target = this.StudentManager.Exit;
            this.CurrentDestination = this.StudentManager.Exit;
          }
          else
          {
            this.PetDestination = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, this.Seat.position + this.Seat.forward * -0.5f, Quaternion.identity).transform;
            this.Pathfinding.target = this.PetDestination;
            this.CurrentDestination = this.PetDestination;
          }
          if (this.Distracting)
          {
            if ((UnityEngine.Object) this.DistractionTarget != (UnityEngine.Object) null)
              this.DistractionTarget.TargetedForDistraction = false;
            this.ResumeDistracting = false;
            this.Distracting = false;
          }
          this.DropPlate();
        }
        if (this.WitnessedMurder)
          this.Subtitle.UpdateLabel(SubtitleType.PetMurderReaction, 1, 3f);
        else if (this.WitnessedCorpse)
          this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReaction, 1, 3f);
        else if (this.WitnessedLimb)
          this.Subtitle.UpdateLabel(SubtitleType.PetLimbReaction, 1, 3f);
        else if (this.WitnessedBloodyWeapon)
          this.Subtitle.UpdateLabel(SubtitleType.PetBloodyWeaponReaction, 1, 3f);
        else if (this.WitnessedBloodPool)
          this.Subtitle.UpdateLabel(SubtitleType.PetBloodReaction, 1, 3f);
        else if (this.WitnessedWeapon)
          this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 1, 3f);
        this.TargetDistance = 1f;
        this.ReportingMurder = false;
        this.ReportingBlood = false;
      }
      this.Routine = false;
      this.Fleeing = true;
    }
    else if (this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Protective)
    {
      Debug.Log((object) "A Heroic student is now running PersonaReaction()...");
      this.Headache = false;
      if (!this.Yandere.Chased)
      {
        this.StudentManager.PinDownCheck();
        if (!this.StudentManager.PinningDown)
        {
          Debug.Log((object) (this.Name + "'s ''Flee'' was set to ''true'' because Hero persona reaction was called."));
          if (this.Persona == PersonaType.Protective)
          {
            this.Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
            Debug.Log((object) "You won't get away with this!");
            this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 2, 3f);
          }
          else if (this.Persona != PersonaType.Violent)
            this.Subtitle.UpdateLabel(SubtitleType.HeroMurderReaction, 3, 3f);
          else if (this.Defeats > 0)
          {
            this.Subtitle.Speaker = this;
            this.Subtitle.UpdateLabel(SubtitleType.DelinquentResume, 3, 3f);
          }
          else
          {
            this.Subtitle.Speaker = this;
            this.Subtitle.UpdateLabel(SubtitleType.DelinquentMurderReaction, 3, 3f);
          }
          this.Pathfinding.target = this.Yandere.transform;
          this.Pathfinding.speed = 5f;
          this.Yandere.Pursuer = this;
          this.Yandere.Chased = true;
          this.TargetDistance = 1f;
          this.StudentManager.UpdateStudents();
          this.Routine = false;
          this.Fleeing = true;
        }
      }
    }
    else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Fragile)
    {
      Debug.Log((object) "This character just set their destination to themself.");
      this.CurrentDestination = this.transform;
      this.Pathfinding.target = this.transform;
      this.Subtitle.UpdateLabel(SubtitleType.CowardMurderReaction, 1, 5f);
      this.Routine = false;
      this.Fleeing = true;
    }
    else if (this.Persona == PersonaType.Evil)
    {
      Debug.Log((object) "This character just set their destination to themself.");
      this.CurrentDestination = this.transform;
      this.Pathfinding.target = this.transform;
      this.Subtitle.UpdateLabel(SubtitleType.EvilMurderReaction, 1, 5f);
      this.Routine = false;
      this.Fleeing = true;
    }
    else if (this.Persona == PersonaType.SocialButterfly)
    {
      Debug.Log((object) "A social butterfly is calling PersonaReaction().");
      this.StudentManager.HidingSpots.List[this.StudentID].position = this.StudentManager.PopulationManager.GetCrowdedLocation();
      this.CurrentDestination = this.StudentManager.HidingSpots.List[this.StudentID];
      this.Pathfinding.target = this.StudentManager.HidingSpots.List[this.StudentID];
      this.Subtitle.UpdateLabel(SubtitleType.SocialDeathReaction, 1, 5f);
      this.TargetDistance = 2f;
      this.ReportPhase = 1;
      this.Routine = false;
      this.Fleeing = true;
      this.Halt = true;
    }
    else if (this.Persona == PersonaType.Lovestruck)
    {
      Debug.Log((object) (this.Name + " is now calling the the Lovestruck Persona code."));
      if ((UnityEngine.Object) this.Corpse != (UnityEngine.Object) null)
        Debug.Log((object) (this.Name + " witnessed the corpse of: " + this.Corpse.Student.Name));
      bool flag = false;
      if (!this.WitnessedMurder && (UnityEngine.Object) this.Corpse != (UnityEngine.Object) null && (this.Corpse.Student.Rival || !this.StudentManager.Eighties && this.Corpse.StudentID == this.StudentManager.ObstacleID))
        flag = true;
      if (flag)
      {
        Debug.Log((object) (this.Name + " is going to have a special reaction to the corpse of " + this.Corpse.Student.Name));
        this.CurrentDestination = this.Corpse.Student.Hips;
        this.Pathfinding.target = this.Corpse.Student.Hips;
        this.SpecialRivalDeathReaction = true;
        this.IgnoringPettyActions = true;
        this.WitnessRivalDiePhase = 1;
        this.Routine = false;
        this.TargetDistance = 0.5f;
      }
      else
      {
        if (!this.StudentManager.Students[this.LovestruckTarget].WitnessedMurder)
        {
          Debug.Log((object) (this.Name + "'s new destination should be " + this.StudentManager.Students[this.LovestruckTarget].Name));
          this.CurrentDestination = this.StudentManager.Students[this.LovestruckTarget].transform;
          this.Pathfinding.target = this.StudentManager.Students[this.LovestruckTarget].transform;
          this.StudentManager.Students[this.LovestruckTarget].TargetedForDistraction = true;
          this.TargetDistance = 1f;
          this.ReportPhase = 1;
        }
        else
        {
          Debug.Log((object) (this.Name + "'s new destination should be the exit of the school."));
          this.CurrentDestination = this.StudentManager.Exit;
          this.Pathfinding.target = this.StudentManager.Exit;
          this.TargetDistance = 0.0f;
          this.ReportPhase = 3;
        }
        if (this.LovestruckTarget == 1)
          this.Subtitle.UpdateLabel(SubtitleType.LovestruckDeathReaction, 0, 5f);
        else if (this.WitnessedMindBrokenMurder)
        {
          this.Subtitle.CustomText = "This can't be happening...";
          this.Subtitle.UpdateLabel(SubtitleType.Custom, 1, 5f);
        }
        else
          this.Subtitle.UpdateLabel(SubtitleType.LovestruckDeathReaction, 1, 5f);
        this.DistanceToDestination = 100f;
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.Routine = false;
        this.Fleeing = true;
        this.Halt = true;
      }
    }
    else if (this.Persona == PersonaType.Dangerous)
    {
      Debug.Log((object) "A student council member's PersonaReaction has been triggered.");
      if (this.WitnessedMurder)
      {
        Debug.Log((object) "A student council member's ''WitnessedMurder'' has been set to ''true''.");
        if (!this.Yandere.DelinquentFighting)
          this.Subtitle.UpdateLabel(SubtitleType.Chasing, this.ClubMemberID, 5f);
        this.Pathfinding.target = this.Yandere.transform;
        this.Pathfinding.speed = 5f;
        this.Yandere.Chased = true;
        this.TargetDistance = 1f;
        this.StudentManager.UpdateStudents();
        this.Routine = false;
        this.Fleeing = true;
        this.Halt = true;
      }
      else
      {
        Debug.Log((object) "A student council member has transformed into a Teacher's Pet.");
        this.Persona = PersonaType.TeachersPet;
        this.PersonaReaction();
      }
    }
    else if (this.Persona == PersonaType.PhoneAddict)
    {
      Debug.Log((object) (this.Name + " is executing the Phone Addict Persona code."));
      this.CurrentDestination = this.StudentManager.Exit;
      this.Pathfinding.target = this.StudentManager.Exit;
      if (!this.StudentManager.Eighties)
      {
        this.Countdown.gameObject.SetActive(true);
        if ((UnityEngine.Object) this.StudentManager.ChaseCamera == (UnityEngine.Object) null)
        {
          this.StudentManager.ChaseCamera = this.ChaseCamera;
          this.ChaseCamera.SetActive(true);
        }
      }
      this.Routine = false;
      this.Fleeing = true;
    }
    else if (this.Persona == PersonaType.Violent)
    {
      Debug.Log((object) (this.Name + ", a delinquent, is currently in the ''Violent'' part of PersonaReaction()"));
      if (this.WitnessedMurder)
      {
        if (!this.Yandere.Chased)
        {
          this.StudentManager.PinDownCheck();
          if (!this.StudentManager.PinningDown)
          {
            Debug.Log((object) (this.Name + " began fleeing because Violent persona reaction was called."));
            if (this.Defeats > 0)
            {
              this.Subtitle.Speaker = this;
              this.Subtitle.UpdateLabel(SubtitleType.DelinquentResume, 3, 3f);
            }
            else
            {
              this.Subtitle.Speaker = this;
              this.Subtitle.UpdateLabel(SubtitleType.DelinquentMurderReaction, 3, 3f);
            }
            this.Pathfinding.target = this.Yandere.transform;
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.Pathfinding.speed = 5f;
            this.Yandere.Pursuer = this;
            this.Yandere.Chased = true;
            this.TargetDistance = 1f;
            this.StudentManager.UpdateStudents();
            this.Routine = false;
            this.Fleeing = true;
          }
        }
      }
      else
      {
        Debug.Log((object) "A delinquent reached the ''Flee'' protocol through PersonaReaction().");
        if (this.FoundFriendCorpse)
        {
          this.Subtitle.Speaker = this;
          this.Subtitle.UpdateLabel(SubtitleType.DelinquentFriendFlee, 1, 3f);
        }
        else
        {
          this.Subtitle.Speaker = this;
          this.Subtitle.UpdateLabel(SubtitleType.DelinquentFlee, 1, 3f);
        }
        this.CurrentDestination = this.StudentManager.Exit;
        this.Pathfinding.target = this.StudentManager.Exit;
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.TargetDistance = 0.0f;
        this.Routine = false;
        this.Fleeing = true;
      }
    }
    else if (this.Persona == PersonaType.Strict)
    {
      if ((UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) this)
        Debug.Log((object) "This teacher is now pursuing Yandere-chan.");
      if (this.WitnessedMurder)
      {
        if ((UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) this)
        {
          Debug.Log((object) "A teacher is now reacting to the sight of murder.");
          this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 3, 3f);
          this.Pathfinding.target = this.Yandere.transform;
          this.Pathfinding.speed = 5f;
          this.Yandere.Chased = true;
          this.TargetDistance = 1f;
          this.StudentManager.UpdateStudents();
          this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
          this.Routine = false;
          this.Fleeing = true;
        }
        else if (!this.Yandere.Chased)
        {
          if (this.Yandere.FightHasBrokenUp)
          {
            Debug.Log((object) "This teacher is returning to normal after witnessing a SC member break up a fight.");
            this.WitnessedMurder = false;
            this.PinDownWitness = false;
            this.Alarmed = false;
            this.Reacted = false;
            this.Routine = true;
            this.Grudge = false;
            this.AlarmTimer = 0.0f;
            this.PreviousEyeShrink = 0.0f;
            this.EyeShrink = 0.0f;
            this.PreviousAlarm = 0.0f;
            this.MurdersWitnessed = 0;
            this.Concern = 0;
            this.Witnessed = StudentWitnessType.None;
            this.GameOverCause = GameOverType.None;
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
          }
          else
          {
            Debug.Log((object) "A teacher has reached ChaseYandere through PersonaReaction.");
            this.ChaseYandere();
          }
        }
      }
      else if (this.WitnessedCorpse)
      {
        Debug.Log((object) "A teacher is now reacting to the sight of a corpse.");
        if (this.ReportPhase == 0)
          this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
        this.Pathfinding.target = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, new Vector3(this.Corpse.AllColliders[0].transform.position.x, this.transform.position.y, this.Corpse.AllColliders[0].transform.position.z), Quaternion.identity).transform;
        this.Pathfinding.target.position = Vector3.MoveTowards(this.Pathfinding.target.position, this.transform.position, 1.5f);
        this.TargetDistance = 1f;
        this.ReportPhase = 2;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
        this.IgnoringPettyActions = true;
        this.Routine = false;
        this.Fleeing = true;
      }
      else
      {
        Debug.Log((object) "A teacher is now reacting to the sight of a severed limb, blood pool, or weapon.");
        if (this.ReportPhase == 0)
        {
          if (this.WitnessedBloodPool || this.WitnessedBloodyWeapon)
            this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 3, 3f);
          else if (this.WitnessedLimb)
            this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 4, 3f);
          else if (this.WitnessedWeapon)
            this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 5, 3f);
        }
        this.TargetDistance = 1f;
        this.ReportPhase = 2;
        this.VerballyReacted = true;
        this.Routine = false;
        this.Fleeing = true;
        this.Halt = true;
      }
    }
    else if (this.Persona == PersonaType.LandlineUser)
    {
      Debug.Log((object) "A Snitch is calling PersonaReaction().");
      this.CurrentDestination = this.StudentManager.LandLineSpot;
      this.Pathfinding.target = this.StudentManager.LandLineSpot;
      this.Subtitle.UpdateLabel(SubtitleType.SocialDeathReaction, 1, 5f);
      this.TargetDistance = 1f;
      this.ReportPhase = 1;
      this.Routine = false;
      this.Fleeing = true;
    }
    if (this.StudentID == 41 && !this.StudentManager.Eighties)
      this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
    Debug.Log((object) (this.Name + " has finished calling PersonaReaction(). As of now, they are a: " + this.Persona.ToString() + "."));
    if (this.WitnessedCorpse)
    {
      Debug.Log((object) (this.Name + " witnessed a corpse..."));
      if (this.Distracting)
      {
        Debug.Log((object) "...so ''Distracting'' is being set to false.");
        if ((UnityEngine.Object) this.DistractionTarget != (UnityEngine.Object) null)
          this.DistractionTarget.TargetedForDistraction = false;
        this.ResumeDistracting = false;
        this.Distracting = false;
      }
    }
    this.Alarm = 0.0f;
    this.UpdateDetectionMarker();
  }

  private void BeginStruggle()
  {
    Debug.Log((object) (this.Name + " has begun a struggle with Yandere-chan."));
    if (this.Yandere.Dragging)
      this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
    if (this.Yandere.Armed)
      this.Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
    this.Yandere.StruggleBar.Strength = (float) this.Strength;
    this.Yandere.StruggleBar.Struggling = true;
    this.Yandere.StruggleBar.Student = this;
    this.Yandere.StruggleBar.gameObject.SetActive(true);
    this.CharacterAnimation.CrossFade(this.StruggleAnim);
    this.Yandere.ShoulderCamera.LastPosition = this.Yandere.ShoulderCamera.transform.position;
    this.Yandere.ShoulderCamera.Struggle = true;
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.Obstacle.enabled = true;
    this.Struggling = true;
    this.DiscCheck = false;
    this.Alarmed = false;
    this.Halt = true;
    if (!this.Teacher)
    {
      this.Yandere.CharacterAnimation["f02_struggleA_00"].time = 0.0f;
    }
    else
    {
      this.Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time = 0.0f;
      this.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    if (this.Yandere.Aiming)
      this.Yandere.StopAiming();
    this.Yandere.StopLaughing();
    this.Yandere.TargetStudent = this;
    this.Yandere.YandereVision = false;
    this.Yandere.NearSenpai = false;
    this.Yandere.Struggling = true;
    this.Yandere.CanMove = false;
    if (this.Yandere.DelinquentFighting)
      this.StudentManager.CombatMinigame.Stop();
    this.Yandere.EmptyHands();
    this.Yandere.RPGCamera.enabled = false;
    this.MyController.radius = 0.0f;
    this.TargetDistance = 100f;
    this.AlarmTimer = 0.0f;
    this.SpawnAlarmDisc();
  }

  public void GetDestinations()
  {
    if (!this.Teacher)
      this.MyLocker = this.StudentManager.LockerPositions[this.StudentID];
    if (this.Slave)
    {
      foreach (ScheduleBlock scheduleBlock in this.ScheduleBlocks)
      {
        scheduleBlock.destination = "Slave";
        scheduleBlock.action = "Slave";
      }
    }
    for (this.ID = 1; this.ID < this.JSON.Students[this.StudentID].ScheduleBlocks.Length; ++this.ID)
    {
      ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.ID];
      if (scheduleBlock.destination == "Locker")
        this.Destinations[this.ID] = this.MyLocker;
      else if (scheduleBlock.destination == "Seat")
        this.Destinations[this.ID] = this.Seat;
      else if (scheduleBlock.destination == "SocialSeat")
        this.Destinations[this.ID] = this.StudentManager.SocialSeats[this.StudentID];
      else if (scheduleBlock.destination == "Podium")
        this.Destinations[this.ID] = this.StudentManager.Podiums.List[this.Class];
      else if (scheduleBlock.destination == "Exit")
        this.Destinations[this.ID] = this.StudentManager.Hangouts.List[0];
      else if (scheduleBlock.destination == "Hangout")
        this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
      else if (scheduleBlock.destination == "Week1Hangout")
        this.Destinations[this.ID] = this.StudentManager.Week1Hangouts.List[this.StudentID];
      else if (scheduleBlock.destination == "Week2Hangout")
        this.Destinations[this.ID] = this.StudentManager.Week2Hangouts.List[this.StudentID];
      else if (scheduleBlock.destination == "Stairway")
        this.Destinations[this.ID] = this.StudentManager.Stairways.List[this.StudentID];
      else if (scheduleBlock.destination == "LunchSpot")
        this.Destinations[this.ID] = this.StudentManager.LunchSpots.List[this.StudentID];
      else if (scheduleBlock.destination == "Slave")
        this.Destinations[this.ID] = this.FragileSlave ? this.StudentManager.FragileSlaveSpot : this.StudentManager.SlaveSpot;
      else if (scheduleBlock.destination == "Patrol")
      {
        this.Destinations[this.ID] = this.StudentManager.Patrols.List[this.StudentID].GetChild(0);
        if (this.Club == ClubType.None)
          this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
      }
      else if (scheduleBlock.destination == "Search Patrol")
      {
        this.StudentManager.SearchPatrols.List[this.Class].GetChild(0).position = this.Seat.position + this.Seat.forward;
        this.StudentManager.SearchPatrols.List[this.Class].GetChild(0).LookAt(this.Seat);
        this.StudentManager.StolenPhoneSpot.transform.position = this.Seat.position + this.Seat.forward * 0.4f;
        this.StudentManager.StolenPhoneSpot.transform.position += Vector3.up;
        this.StudentManager.StolenPhoneSpot.gameObject.SetActive(true);
        this.Destinations[this.ID] = this.StudentManager.SearchPatrols.List[this.Class].GetChild(0);
      }
      else if (scheduleBlock.destination == "Graffiti")
        this.Destinations[this.ID] = this.StudentManager.GraffitiSpots[this.BullyID];
      else if (scheduleBlock.destination == "Bully")
        this.Destinations[this.ID] = this.StudentManager.BullySpots[this.BullyID];
      else if (scheduleBlock.destination == "Mourn")
        this.Destinations[this.ID] = this.StudentManager.MournSpots[this.StudentID];
      else if (scheduleBlock.destination == "Clean")
      {
        if ((UnityEngine.Object) this.CleaningSpot != (UnityEngine.Object) null)
          this.Destinations[this.ID] = this.CleaningSpot.GetChild(0);
      }
      else if (scheduleBlock.destination == "ShameSpot")
        this.Destinations[this.ID] = this.StudentManager.ShameSpot;
      else if (scheduleBlock.destination == "Follow")
      {
        if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null)
          this.Destinations[this.ID] = this.FollowTarget.FollowTargetDestination;
      }
      else if (scheduleBlock.destination == "Cuddle")
        this.Destinations[this.ID] = this.Male ? this.StudentManager.MaleCoupleSpots[this.CoupleID] : this.StudentManager.FemaleCoupleSpots[this.CoupleID];
      else if (scheduleBlock.destination == "Peek")
        this.Destinations[this.ID] = this.Male ? this.StudentManager.MaleStalkSpot : this.StudentManager.FemaleStalkSpot;
      else if (scheduleBlock.destination == "Club")
        this.Destinations[this.ID] = this.Club <= ClubType.None ? this.StudentManager.Hangouts.List[this.StudentID] : (this.Club != ClubType.Sports ? this.StudentManager.Clubs.List[this.StudentID] : this.StudentManager.Clubs.List[this.StudentID].GetChild(0));
      else if (scheduleBlock.destination == "Sulk")
        this.Destinations[this.ID] = this.StudentManager.SulkSpots[this.StudentID];
      else if (scheduleBlock.destination == "Sleuth")
        this.Destinations[this.ID] = this.SleuthTarget;
      else if (scheduleBlock.destination == "Stalk")
        this.Destinations[this.ID] = this.StalkTarget;
      else if (scheduleBlock.destination == "Sunbathe")
        this.Destinations[this.ID] = this.StudentManager.StrippingPositions[this.GirlID];
      else if (scheduleBlock.destination == "Shock")
        this.Destinations[this.ID] = this.StudentManager.ShockedSpots[this.StudentID - 80];
      else if (scheduleBlock.destination == "Miyuki")
      {
        this.ClubMemberID = this.StudentID - 35;
        this.Destinations[this.ID] = this.StudentManager.MiyukiSpots[this.ClubMemberID].transform;
      }
      else if (scheduleBlock.destination == "Practice")
        this.Destinations[this.ID] = this.Club <= ClubType.None ? this.StudentManager.Hangouts.List[this.StudentID] : this.StudentManager.PracticeSpots[this.ClubMemberID];
      else if (scheduleBlock.destination == "Lyrics")
        this.Destinations[this.ID] = this.StudentManager.LyricsSpot;
      else if (scheduleBlock.destination == "Meeting")
        this.Destinations[this.ID] = this.StudentManager.MeetingSpots[this.StudentID].transform;
      else if (scheduleBlock.destination == "InfirmaryBed")
      {
        if (this.Male)
        {
          this.Destinations[this.ID] = this.StudentManager.MaleRestSpots[this.StudentManager.SedatedStudents];
          ++this.StudentManager.SedatedStudents;
        }
        else
        {
          this.Destinations[this.ID] = this.StudentManager.FemaleRestSpots[this.StudentManager.SedatedStudents];
          ++this.StudentManager.SedatedStudents;
        }
      }
      else if (scheduleBlock.destination == "InfirmarySeat")
        this.Destinations[this.ID] = this.StudentManager.InfirmarySeat;
      else if (scheduleBlock.destination == "Paint")
        this.Destinations[this.ID] = this.StudentManager.FridaySpots[this.StudentID];
      else if (scheduleBlock.destination == "LockerRoom")
        this.Destinations[this.ID] = this.StudentManager.MaleLockerRoomChangingSpot;
      else if (scheduleBlock.destination == "LunchWitnessPosition")
        this.Destinations[this.ID] = this.StudentManager.LunchWitnessPositions.List[this.StudentID];
      else if (scheduleBlock.destination == "Wait")
        this.Destinations[this.ID] = this.StudentManager.WaitSpots[this.StudentID];
      else if (scheduleBlock.destination == "SleepSpot")
      {
        Debug.Log((object) (this.Name + " is setting destination to ''SleepSpot''."));
        this.Destinations[this.ID] = this.StudentManager.SleepSpot;
      }
      else if (scheduleBlock.destination == "LightFire")
        this.Destinations[this.ID] = this.StudentManager.PyroSpot;
      else if (scheduleBlock.destination == "EightiesSpot")
        this.Destinations[this.ID] = this.StudentManager.EightiesSpots.List[this.StudentID];
      else if (scheduleBlock.destination == "Perform")
        this.Destinations[this.ID] = this.StudentManager.PerformSpots[this.StudentID];
      else if (scheduleBlock.destination == "PhotoShoot")
        this.Destinations[this.ID] = this.StudentManager.PhotoShootSpots[this.StudentID];
      else if (scheduleBlock.destination == "Guard")
        this.Destinations[this.ID] = this.StudentID != 20 ? this.StudentManager.RivalGuardSpots[this.StudentID].transform : this.StudentManager.Students[1].transform;
      else if (scheduleBlock.destination == "Random")
        this.Destinations[this.ID] = this.StudentManager.RandomSpots[this.StudentID];
      if (scheduleBlock.action == "Stand")
        this.Actions[this.ID] = StudentActionType.AtLocker;
      else if (scheduleBlock.action == "Socialize")
        this.Actions[this.ID] = StudentActionType.Socializing;
      else if (scheduleBlock.action == "Game")
        this.Actions[this.ID] = StudentActionType.Gaming;
      else if (scheduleBlock.action == "Slave")
        this.Actions[this.ID] = StudentActionType.Slave;
      else if (scheduleBlock.action == "Relax")
        this.Actions[this.ID] = StudentActionType.Relax;
      else if (scheduleBlock.action == "Sit")
        this.Actions[this.ID] = StudentActionType.SitAndTakeNotes;
      else if (scheduleBlock.action == "Peek")
        this.Actions[this.ID] = StudentActionType.Peek;
      else if (scheduleBlock.action == "SocialSit")
      {
        this.Actions[this.ID] = StudentActionType.SitAndSocialize;
        if (this.Persona == PersonaType.Sleuth && this.Club == ClubType.None)
          this.Actions[this.ID] = StudentActionType.Socializing;
      }
      else if (scheduleBlock.action == "Eat")
        this.Actions[this.ID] = StudentActionType.SitAndEatBento;
      else if (scheduleBlock.action == "Shoes")
        this.Actions[this.ID] = StudentActionType.ChangeShoes;
      else if (scheduleBlock.action == "Grade")
        this.Actions[this.ID] = StudentActionType.GradePapers;
      else if (scheduleBlock.action == "Patrol")
      {
        this.Actions[this.ID] = StudentActionType.Patrol;
        if (this.OriginalClub != ClubType.None && this.Club == ClubType.None)
        {
          Debug.Log((object) "This student's club disbanded, so their action has been set to ''Socialize''.");
          this.Actions[this.ID] = StudentActionType.Socializing;
        }
      }
      else if (scheduleBlock.action == "Search Patrol")
        this.Actions[this.ID] = StudentActionType.SearchPatrol;
      else if (scheduleBlock.action == "Gossip")
        this.Actions[this.ID] = StudentActionType.Gossip;
      else if (scheduleBlock.action == "Graffiti")
        this.Actions[this.ID] = StudentActionType.Graffiti;
      else if (scheduleBlock.action == "Bully")
        this.Actions[this.ID] = StudentActionType.Bully;
      else if (scheduleBlock.action == "Read")
        this.Actions[this.ID] = StudentActionType.Read;
      else if (scheduleBlock.action == "Text")
        this.Actions[this.ID] = StudentActionType.Texting;
      else if (scheduleBlock.action == "Mourn")
        this.Actions[this.ID] = StudentActionType.Mourn;
      else if (scheduleBlock.action == "Cuddle")
        this.Actions[this.ID] = StudentActionType.Cuddle;
      else if (scheduleBlock.action == "Teach")
        this.Actions[this.ID] = StudentActionType.Teaching;
      else if (scheduleBlock.action == "Wait")
        this.Actions[this.ID] = StudentActionType.Wait;
      else if (scheduleBlock.action == "Clean")
        this.Actions[this.ID] = StudentActionType.Clean;
      else if (scheduleBlock.action == "Shamed")
        this.Actions[this.ID] = StudentActionType.Shamed;
      else if (scheduleBlock.action == "Follow")
        this.Actions[this.ID] = StudentActionType.Follow;
      else if (scheduleBlock.action == "Sulk")
        this.Actions[this.ID] = StudentActionType.Sulk;
      else if (scheduleBlock.action == "Sleuth")
        this.Actions[this.ID] = StudentActionType.Sleuth;
      else if (scheduleBlock.action == "Stalk")
        this.Actions[this.ID] = StudentActionType.Stalk;
      else if (scheduleBlock.action == "Sketch")
        this.Actions[this.ID] = StudentActionType.Sketch;
      else if (scheduleBlock.action == "Sunbathe")
        this.Actions[this.ID] = StudentActionType.Sunbathe;
      else if (scheduleBlock.action == "Shock")
        this.Actions[this.ID] = StudentActionType.Shock;
      else if (scheduleBlock.action == "Miyuki")
        this.Actions[this.ID] = StudentActionType.Miyuki;
      else if (scheduleBlock.action == "Meeting")
        this.Actions[this.ID] = StudentActionType.Meeting;
      else if (scheduleBlock.action == "Lyrics")
        this.Actions[this.ID] = StudentActionType.Lyrics;
      else if (scheduleBlock.action == "Practice")
        this.Actions[this.ID] = StudentActionType.Practice;
      else if (scheduleBlock.action == "Sew")
        this.Actions[this.ID] = StudentActionType.Sew;
      else if (scheduleBlock.action == "Paint")
        this.Actions[this.ID] = StudentActionType.Paint;
      else if (scheduleBlock.action == "UpdateAppearance")
        this.Actions[this.ID] = StudentActionType.UpdateAppearance;
      else if (scheduleBlock.action == "LightCig")
        this.Actions[this.ID] = StudentActionType.LightCig;
      else if (scheduleBlock.action == "PlaceBag")
        this.Actions[this.ID] = StudentActionType.PlaceBag;
      else if (scheduleBlock.action == "Sleep")
      {
        Debug.Log((object) (this.Name + " is setting action to ''Sleep''."));
        this.Actions[this.ID] = StudentActionType.Sleep;
      }
      else if (scheduleBlock.action == "LightFire")
        this.Actions[this.ID] = StudentActionType.LightFire;
      else if (scheduleBlock.action == "Jog")
        this.Actions[this.ID] = StudentActionType.Jog;
      else if (scheduleBlock.action == "PrepareFood")
        this.Actions[this.ID] = StudentActionType.PrepareFood;
      else if (scheduleBlock.action == "Perform")
        this.Actions[this.ID] = StudentActionType.Perform;
      else if (scheduleBlock.action == "PhotoShoot")
        this.Actions[this.ID] = StudentActionType.PhotoShoot;
      else if (scheduleBlock.action == "GravurePose")
        this.Actions[this.ID] = StudentActionType.GravurePose;
      else if (scheduleBlock.action == "Guard")
        this.Actions[this.ID] = StudentActionType.Guard;
      else if (scheduleBlock.action == "Gaming")
        this.Actions[this.ID] = StudentActionType.Gaming;
      else if (scheduleBlock.action == "Random")
        this.Actions[this.ID] = StudentActionType.Random;
      else if (scheduleBlock.action == "HelpTeacher")
        this.Actions[this.ID] = StudentActionType.HelpTeacher;
      else if (scheduleBlock.action == "Admire")
        this.Actions[this.ID] = StudentActionType.Admire;
      else if (scheduleBlock.action == "Club")
        this.Actions[this.ID] = this.Club <= ClubType.None ? (this.OriginalClub != ClubType.Art ? StudentActionType.Socializing : StudentActionType.Sketch) : StudentActionType.ClubAction;
    }
  }

  private void SetOutlinesOrange()
  {
    for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
      {
        this.Outlines[this.ID].color = new Color(1f, 0.5f, 0.0f, 1f);
        this.Outlines[this.ID].enabled = true;
      }
    }
    for (this.ID = 0; this.ID < this.RiggedAccessoryOutlines.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.RiggedAccessoryOutlines[this.ID] != (UnityEngine.Object) null)
      {
        this.RiggedAccessoryOutlines[this.ID].color = new Color(1f, 0.5f, 0.0f, 1f);
        this.RiggedAccessoryOutlines[this.ID].enabled = this.Outlines[0].enabled;
      }
    }
  }

  private void SetOutlinesYellow()
  {
    for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
      {
        this.Outlines[this.ID].color = new Color(1f, 1f, 0.0f, 1f);
        this.Outlines[this.ID].enabled = true;
      }
    }
    for (this.ID = 0; this.ID < this.RiggedAccessoryOutlines.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.RiggedAccessoryOutlines[this.ID] != (UnityEngine.Object) null)
      {
        this.RiggedAccessoryOutlines[this.ID].color = new Color(1f, 1f, 0.0f, 1f);
        this.RiggedAccessoryOutlines[this.ID].enabled = this.Outlines[0].enabled;
      }
    }
  }

  private void SetOutlinesRed()
  {
    for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
      {
        this.Outlines[this.ID].color = new Color(1f, 0.0f, 0.0f, 1f);
        this.Outlines[this.ID].enabled = true;
      }
    }
    for (this.ID = 0; this.ID < this.RiggedAccessoryOutlines.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.RiggedAccessoryOutlines[this.ID] != (UnityEngine.Object) null)
      {
        this.RiggedAccessoryOutlines[this.ID].color = new Color(1f, 0.0f, 0.0f, 1f);
        this.RiggedAccessoryOutlines[this.ID].enabled = this.Outlines[0].enabled;
      }
    }
  }

  public void AddOutlineToHair()
  {
    if ((UnityEngine.Object) this.Cosmetic.HairRenderer != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.Cosmetic.HairRenderer.GetComponent<OutlineScript>() == (UnityEngine.Object) null)
        this.Cosmetic.HairRenderer.gameObject.AddComponent<OutlineScript>();
      this.Outlines[1] = this.Cosmetic.HairRenderer.gameObject.GetComponent<OutlineScript>();
      if ((UnityEngine.Object) this.Outlines[1].h == (UnityEngine.Object) null)
        this.Outlines[1].Awake();
      this.Outlines[1].color = this.Outlines[0].color;
      this.Outlines[1].enabled = this.Outlines[0].enabled;
      this.Outlines[1].h.enabled = this.Outlines[1].enabled;
    }
    if (!this.Teacher || !this.StudentManager.Eighties || !((UnityEngine.Object) this.EightiesTeacherAttacher != (UnityEngine.Object) null) || !((UnityEngine.Object) this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != (UnityEngine.Object) null))
      return;
    if ((UnityEngine.Object) this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.gameObject.GetComponent<OutlineScript>() == (UnityEngine.Object) null)
      this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.gameObject.AddComponent<OutlineScript>();
    this.MyRenderer = this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
    this.Outlines[0] = this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.gameObject.GetComponent<OutlineScript>();
    this.Outlines[0].color = this.Outlines[1].color;
    if (!((UnityEngine.Object) this.Outlines[0].h == (UnityEngine.Object) null))
      return;
    this.Outlines[0].Awake();
  }

  public void PickRandomAnim()
  {
    if (this.Grudge)
      this.RandomAnim = this.BulliedIdleAnim;
    else if (this.Club != ClubType.Delinquent)
      this.RandomAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
    else
      this.RandomAnim = this.DelinquentAnims[UnityEngine.Random.Range(0, this.DelinquentAnims.Length)];
  }

  private void PickRandomGossipAnim()
  {
    if (this.Grudge)
    {
      this.RandomAnim = this.BulliedIdleAnim;
    }
    else
    {
      this.RandomGossipAnim = this.GossipAnims[UnityEngine.Random.Range(0, this.GossipAnims.Length)];
      if (this.Actions[this.Phase] != StudentActionType.Gossip || (double) this.DistanceToPlayer >= 3.0)
        return;
      if (!ConversationGlobals.GetTopicDiscovered(19))
      {
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        ConversationGlobals.SetTopicDiscovered(19, true);
      }
      if (this.StudentManager.GetTopicLearnedByStudent(19, this.StudentID))
        return;
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
      this.StudentManager.SetTopicLearnedByStudent(19, this.StudentID, true);
    }
  }

  private void PickRandomSleuthAnim()
  {
    if (!this.Sleuthing)
      this.RandomSleuthAnim = this.SleuthAnims[UnityEngine.Random.Range(0, 3)];
    else
      this.RandomSleuthAnim = this.SleuthAnims[UnityEngine.Random.Range(3, 6)];
  }

  private void BecomeTeacher()
  {
    this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    this.StudentManager.Teachers[this.Class] = this;
    if (this.Class != 1)
    {
      this.GradingPaper = this.StudentManager.FacultyDesks[this.Class];
      if (this.StudentID == 94 && this.StudentManager.Eighties && this.StudentManager.Week > 1)
      {
        this.GradingPaper.enabled = false;
        this.GradingPaper = this.StudentManager.FacultyDesks[1];
      }
      this.GradingPaper.LeftHand = this.LeftHand.parent;
      this.GradingPaper.Character = this.Character;
      this.GradingPaper.Teacher = this;
      this.SkirtCollider.gameObject.SetActive(false);
      this.LowPoly.MyMesh = this.LowPoly.TeacherMesh;
      this.PantyCollider.enabled = false;
    }
    if (this.Class > 1)
    {
      this.VisionDistance = 12f * this.Paranoia;
      this.name = "Teacher_" + this.Class.ToString() + "_" + this.Name;
      this.OriginalIdleAnim = "f02_idleShort_00";
      this.IdleAnim = "f02_idleShort_00";
    }
    else if (this.Class == 1)
    {
      this.VisionDistance = 12f * this.Paranoia;
      this.PatrolAnim = "f02_idle_00";
      this.name = "Nurse_" + this.Name;
    }
    else
    {
      this.VisionDistance = 16f * this.Paranoia;
      this.PatrolAnim = "f02_stretch_00";
      this.name = "Coach_" + this.Name;
      this.OriginalIdleAnim = "f02_tsunIdle_00";
      this.IdleAnim = "f02_tsunIdle_00";
    }
    this.StruggleAnim = "f02_teacherStruggleB_00";
    this.StruggleWonAnim = "f02_teacherStruggleWinB_00";
    this.StruggleLostAnim = "f02_teacherStruggleLoseB_00";
    this.OriginallyTeacher = true;
    this.Spawned = true;
    this.Teacher = true;
    if (this.StudentID > 89 && this.StudentID < 98 && this.StudentManager.Eighties)
    {
      this.SmartPhone = this.EightiesPhone;
      if (this.StudentID != 97 && this.StudentID != 90)
      {
        this.EightiesTeacherAttacher.SetActive(true);
        this.MyRenderer.enabled = false;
      }
    }
    this.SmartPhone.SetActive(false);
    this.gameObject.tag = "Untagged";
  }

  public void RemoveShoes()
  {
    if (!this.Male)
    {
      this.MyRenderer.materials[0].mainTexture = this.Cosmetic.SocksTexture;
      this.MyRenderer.materials[1].mainTexture = this.Cosmetic.SocksTexture;
    }
    else
      this.MyRenderer.materials[this.Cosmetic.UniformID].mainTexture = this.Cosmetic.SocksTexture;
  }

  public void BecomeRagdoll()
  {
    if ((UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null)
    {
      PromptScript component = this.BloodPool.GetComponent<PromptScript>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        Debug.Log((object) "Re-enabling an object's prompt.");
        component.enabled = true;
      }
    }
    if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null)
      this.FollowTarget.Follower = (StudentScript) null;
    this.Meeting = false;
    if (this.Rival)
    {
      this.StudentManager.RivalEliminated = true;
      if ((UnityEngine.Object) this.Follower != (UnityEngine.Object) null && (UnityEngine.Object) this.Follower.FollowTarget != (UnityEngine.Object) null && this.StudentManager.LastKnownOsana.position == Vector3.zero)
      {
        this.StudentManager.LastKnownOsana.position = this.transform.position;
        this.Follower.Destinations[this.Follower.Phase] = this.StudentManager.LastKnownOsana;
        if ((UnityEngine.Object) this.Follower.CurrentDestination == (UnityEngine.Object) this.Follower.FollowTarget)
        {
          this.Follower.Pathfinding.target = this.StudentManager.LastKnownOsana;
          this.Follower.CurrentDestination = this.StudentManager.LastKnownOsana;
        }
      }
    }
    if ((UnityEngine.Object) this.BikiniAttacher != (UnityEngine.Object) null && (UnityEngine.Object) this.BikiniAttacher.newRenderer != (UnityEngine.Object) null)
      this.BikiniAttacher.newRenderer.updateWhenOffscreen = true;
    if ((UnityEngine.Object) this.EightiesTeacherAttacher != (UnityEngine.Object) null && (UnityEngine.Object) this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != (UnityEngine.Object) null)
      this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.updateWhenOffscreen = true;
    if ((UnityEngine.Object) this.LabcoatAttacher.newRenderer != (UnityEngine.Object) null)
      this.LabcoatAttacher.newRenderer.updateWhenOffscreen = true;
    if ((UnityEngine.Object) this.ApronAttacher.newRenderer != (UnityEngine.Object) null)
      this.ApronAttacher.newRenderer.updateWhenOffscreen = true;
    if ((UnityEngine.Object) this.Attacher.newRenderer != (UnityEngine.Object) null)
      this.Attacher.newRenderer.updateWhenOffscreen = true;
    if ((UnityEngine.Object) this.DrinkingFountain != (UnityEngine.Object) null)
      this.DrinkingFountain.Occupied = false;
    if (!this.Ragdoll.enabled)
    {
      this.EmptyHands();
      if ((UnityEngine.Object) this.Broken != (UnityEngine.Object) null)
      {
        this.Broken.enabled = false;
        this.Broken.MyAudio.Stop();
      }
      if (this.Club == ClubType.Delinquent && (UnityEngine.Object) this.MyWeapon != (UnityEngine.Object) null)
      {
        this.MyWeapon.transform.parent = (Transform) null;
        this.MyWeapon.MyCollider.enabled = true;
        this.MyWeapon.Prompt.enabled = true;
        Rigidbody component = this.MyWeapon.GetComponent<Rigidbody>();
        component.constraints = RigidbodyConstraints.None;
        component.isKinematic = false;
        component.useGravity = true;
        this.MyWeapon = (WeaponScript) null;
      }
      if ((UnityEngine.Object) this.StudentManager.ChaseCamera == (UnityEngine.Object) this.ChaseCamera)
        this.StudentManager.ChaseCamera = (GameObject) null;
      this.Countdown.gameObject.SetActive(false);
      this.ChaseCamera.SetActive(false);
      if (this.Club == ClubType.Council)
        this.Police.CouncilDeath = true;
      if (this.WillChase)
        --this.Yandere.Chasers;
      ParticleSystem.EmissionModule emission = this.Hearts.emission;
      if (this.Following)
      {
        emission.enabled = false;
        this.FollowCountdown.gameObject.SetActive(false);
        this.Yandere.Follower = (StudentScript) null;
        --this.Yandere.Followers;
        this.Following = false;
      }
      if ((UnityEngine.Object) this == (UnityEngine.Object) this.StudentManager.Reporter)
        this.StudentManager.Reporter = (StudentScript) null;
      if (this.Pushed)
      {
        this.Police.SuicideStudent = this.gameObject;
        this.Police.SuicideID = this.StudentID;
        this.Police.SuicideScene = true;
        this.Ragdoll.Suicide = true;
        this.Police.Suicide = true;
      }
      if (!this.Tranquil)
      {
        StudentGlobals.SetStudentDying(this.StudentID, true);
        if (!this.Ragdoll.Burning && !this.Ragdoll.Disturbing)
        {
          if ((UnityEngine.Object) this.Police == (UnityEngine.Object) null)
            this.Police = this.StudentManager.Police;
          if (this.Police.Corpses < 0)
            this.Police.Corpses = 0;
          if (this.Police.Corpses < this.Police.CorpseList.Length)
            this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
          ++this.Police.Corpses;
        }
      }
      if (!this.Male)
      {
        this.LiquidProjector.ignoreLayers = -2049;
        this.RightHandCollider.enabled = false;
        this.LeftHandCollider.enabled = false;
        this.PantyCollider.enabled = false;
        this.SkirtCollider.gameObject.SetActive(false);
      }
      this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
      this.Ragdoll.AllColliders[10].isTrigger = false;
      this.NotFaceCollider.enabled = false;
      this.FaceCollider.enabled = false;
      this.MyController.enabled = false;
      emission.enabled = false;
      this.SpeechLines.Stop();
      if (this.MyRenderer.enabled)
        this.MyRenderer.updateWhenOffscreen = true;
      AIDestinationSetter component1 = this.GetComponent<AIDestinationSetter>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        component1.enabled = false;
      this.Pathfinding.enabled = false;
      this.HipCollider.enabled = true;
      this.enabled = false;
      this.UnWet();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.Ragdoll.CharacterAnimation = this.CharacterAnimation;
      this.Ragdoll.DetectionMarker = this.DetectionMarker;
      this.Ragdoll.RightEyeOrigin = this.RightEyeOrigin;
      this.Ragdoll.LeftEyeOrigin = this.LeftEyeOrigin;
      this.Ragdoll.Electrocuted = this.Electrocuted;
      this.Ragdoll.NeckSnapped = this.NeckSnapped;
      this.Ragdoll.BreastSize = this.BreastSize;
      this.Ragdoll.EyeShrink = this.EyeShrink;
      this.Ragdoll.StudentID = this.StudentID;
      this.Ragdoll.Tranquil = this.Tranquil;
      this.Ragdoll.Burning = this.Burning;
      this.Ragdoll.Drowned = this.Drowned;
      this.Ragdoll.Yandere = this.Yandere;
      this.Ragdoll.Police = this.Police;
      this.Ragdoll.Pushed = this.Pushed;
      this.Ragdoll.Male = this.Male;
      if (!this.Tranquil)
        ++this.Police.Deaths;
      if (!this.NoRagdoll)
        this.Ragdoll.enabled = true;
      if ((UnityEngine.Object) this.Reputation == (UnityEngine.Object) null)
        this.Reputation = this.StudentManager.Reputation;
      this.Reputation.PendingRep -= this.PendingRep;
      if (this.WitnessedMurder && this.Persona != PersonaType.Evil)
        --this.Police.Witnesses;
      this.SetOutlinesOrange();
      if ((UnityEngine.Object) this.DetectionMarker != (UnityEngine.Object) null)
        this.DetectionMarker.Tex.enabled = false;
      GameObjectUtils.SetLayerRecursively(this.gameObject, 11);
      this.MapMarker.gameObject.layer = 10;
      this.tag = "Blood";
      this.LowPoly.transform.parent = this.Hips;
      this.LowPoly.transform.localPosition = new Vector3(0.0f, -1f, 0.0f);
      this.LowPoly.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }
    if ((UnityEngine.Object) this.SmartPhone.transform.parent == (UnityEngine.Object) this.ItemParent)
      this.SmartPhone.SetActive(false);
    this.Grudge = false;
  }

  public void GetWet()
  {
    if (SchemeGlobals.GetSchemeStage(1) == 3 && this.Rival || SchemeGlobals.GetSchemeStage(2) == 3 || this.StudentID == 2)
    {
      Debug.Log((object) "A scheme-related character was just splashed with water.");
      SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) + 1);
      this.Yandere.PauseScreen.Schemes.UpdateInstructions();
    }
    this.TargetDistance = 1f;
    this.FocusOnStudent = false;
    this.FocusOnYandere = false;
    this.BeenSplashed = true;
    this.BatheFast = true;
    this.LiquidProjector.gameObject.SetActive(true);
    this.LiquidProjector.enabled = true;
    this.Emetic = false;
    this.Sedated = false;
    this.Headache = false;
    this.Vomiting = false;
    this.DressCode = false;
    this.Reacted = false;
    this.Alarmed = false;
    this.LiquidProjector.material.mainTexture = !this.Gas ? (!this.Bloody ? (!this.DyedBrown ? this.WaterTexture : this.BrownTexture) : this.BloodTexture) : this.GasTexture;
    for (this.ID = 0; this.ID < this.LiquidEmitters.Length; ++this.ID)
    {
      ParticleSystem liquidEmitter = this.LiquidEmitters[this.ID];
      liquidEmitter.gameObject.SetActive(true);
      liquidEmitter.main.startColor = !this.Gas ? (!this.Bloody ? (!this.DyedBrown ? (ParticleSystem.MinMaxGradient) new Color(0.0f, 1f, 1f, 1f) : (ParticleSystem.MinMaxGradient) new Color(0.5f, 0.25f, 0.0f, 1f)) : (ParticleSystem.MinMaxGradient) new Color(1f, 0.0f, 0.0f, 1f)) : (ParticleSystem.MinMaxGradient) new Color(1f, 1f, 0.0f, 1f);
    }
    if (!this.Slave)
    {
      this.CharacterAnimation[this.SplashedAnim].speed = 1f;
      this.CharacterAnimation.CrossFade(this.SplashedAnim);
      this.Subtitle.UpdateLabel(this.SplashSubtitleType, 0, 1f);
      this.SpeechLines.Stop();
      this.Hearts.Stop();
      this.StopMeeting();
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
      this.SplashTimer = 0.0f;
      this.SplashPhase = 1;
      this.BathePhase = 1;
      this.ForgetRadio();
      if (this.Distracting)
      {
        this.DistractionTarget.TargetedForDistraction = false;
        this.DistractionTarget.Octodog.SetActive(false);
        this.DistractionTarget.Distracted = false;
        this.Distracting = false;
        this.CanTalk = true;
      }
      if (this.Investigating)
        this.Investigating = false;
      this.SchoolwearUnavailable = true;
      this.SentToLocker = false;
      this.Distracted = true;
      this.Splashed = true;
      this.Routine = false;
      this.GoAway = false;
      this.Wet = true;
      if (this.Following)
      {
        this.FollowCountdown.gameObject.SetActive(false);
        this.Yandere.Follower = (StudentScript) null;
        --this.Yandere.Followers;
        this.Following = false;
      }
      this.SpawnAlarmDisc();
      if (this.Club == ClubType.Cooking)
      {
        this.IdleAnim = this.OriginalIdleAnim;
        this.WalkAnim = this.OriginalWalkAnim;
        this.LeanAnim = this.OriginalLeanAnim;
        this.ClubActivityPhase = 0;
        this.ClubTimer = 0.0f;
      }
      if (this.ReturningMisplacedWeapon)
        this.DropMisplacedWeapon();
      this.EmptyHands();
    }
    this.Alarm = 0.0f;
    this.UpdateDetectionMarker();
  }

  public void UnWet()
  {
    for (this.ID = 0; this.ID < this.LiquidEmitters.Length; ++this.ID)
      this.LiquidEmitters[this.ID].gameObject.SetActive(false);
  }

  public void SetSplashes(bool Bool)
  {
    for (this.ID = 0; this.ID < this.SplashEmitters.Length; ++this.ID)
      this.SplashEmitters[this.ID].gameObject.SetActive(Bool);
  }

  public void StopMeeting()
  {
    Debug.Log((object) (this.Name + " has called the StopMeeting() function."));
    this.Prompt.Label[0].text = "     Talk";
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.DistanceToDestination = 100f;
    this.Drownable = false;
    this.BakeSale = false;
    this.Pushable = false;
    this.Meeting = false;
    this.CanTalk = true;
    this.StudentManager.UpdateMe(this.StudentID);
    this.MeetTimer = 0.0f;
    this.RemoveOfferHelpPrompt();
    if (!this.Rival)
      return;
    this.StudentManager.UpdateInfatuatedTargetDistances();
  }

  public void RemoveOfferHelpPrompt()
  {
    OfferHelpScript offerHelpScript = (OfferHelpScript) null;
    if (this.StudentManager.Eighties && this.StudentID == this.StudentManager.RivalID)
    {
      offerHelpScript = this.StudentManager.EightiesOfferHelp;
      this.StudentManager.LoveManager.RivalWaiting = false;
    }
    else if (this.StudentID == 11)
    {
      offerHelpScript = this.StudentManager.OsanaOfferHelp;
      this.StudentManager.LoveManager.RivalWaiting = false;
    }
    else if (this.StudentID == 30)
    {
      offerHelpScript = this.StudentManager.OfferHelp;
      this.StudentManager.LoveManager.RivalWaiting = false;
    }
    else if (this.StudentID == 5)
      offerHelpScript = this.StudentManager.FragileOfferHelp;
    if (!((UnityEngine.Object) offerHelpScript != (UnityEngine.Object) null))
      return;
    offerHelpScript.transform.position = Vector3.zero;
    offerHelpScript.enabled = false;
    offerHelpScript.Prompt.Hide();
    offerHelpScript.Prompt.enabled = false;
  }

  public void Combust()
  {
    this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
    ++this.Police.Corpses;
    GameObjectUtils.SetLayerRecursively(this.gameObject, 11);
    this.MapMarker.gameObject.layer = 10;
    this.tag = "Blood";
    this.Dying = true;
    this.SpawnAlarmDisc();
    this.Character.GetComponent<Animation>().CrossFade(this.BurningAnim);
    this.CharacterAnimation[this.WetAnim].weight = 0.0f;
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.Ragdoll.BurningAnimation = true;
    this.Ragdoll.Disturbing = true;
    this.Ragdoll.Burning = true;
    this.WitnessedCorpse = false;
    this.FocusOnStudent = false;
    this.FocusOnYandere = false;
    this.Investigating = false;
    this.EatingSnack = false;
    this.DiscCheck = false;
    this.WalkBack = false;
    this.Alarmed = false;
    this.CanTalk = false;
    this.Fleeing = false;
    this.Routine = false;
    this.Reacted = false;
    this.Burning = true;
    this.Wet = false;
    AudioSource component = this.GetComponent<AudioSource>();
    component.clip = this.BurningClip;
    component.Play();
    this.LiquidProjector.enabled = false;
    this.UnWet();
    if (this.Following)
    {
      this.FollowCountdown.gameObject.SetActive(false);
      this.Yandere.Follower = (StudentScript) null;
      --this.Yandere.Followers;
      this.Following = false;
    }
    for (this.ID = 0; this.ID < this.FireEmitters.Length; ++this.ID)
      this.FireEmitters[this.ID].gameObject.SetActive(true);
    if (!this.Attacked)
      return;
    this.BurnTarget = this.Yandere.transform.position + this.Yandere.transform.forward;
    this.Attacked = false;
  }

  public void JojoReact()
  {
    UnityEngine.Object.Instantiate<GameObject>(this.JojoHitEffect, this.transform.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity);
    if (this.Dying)
      return;
    this.Dying = true;
    this.SpawnAlarmDisc();
    this.CharacterAnimation.CrossFade(this.JojoReactAnim);
    this.CharacterAnimation[this.WetAnim].weight = 0.0f;
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.WitnessedCorpse = false;
    this.Investigating = false;
    this.EatingSnack = false;
    this.DiscCheck = false;
    this.WalkBack = false;
    this.Alarmed = false;
    this.CanTalk = false;
    this.Fleeing = false;
    this.Routine = false;
    this.Reacted = false;
    this.Wet = false;
    this.GetComponent<AudioSource>().Play();
    if (!this.Following)
      return;
    this.FollowCountdown.gameObject.SetActive(false);
    this.Yandere.Follower = (StudentScript) null;
    --this.Yandere.Followers;
    this.Following = false;
  }

  private void Nude()
  {
    if (!this.Male)
    {
      this.PantyCollider.enabled = false;
      this.SkirtCollider.gameObject.SetActive(false);
    }
    if (!this.Male)
    {
      this.MyRenderer.sharedMesh = this.TowelMesh;
      if (this.Club == ClubType.Bully)
        this.Cosmetic.DeactivateBullyAccessories();
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[0].mainTexture = this.TowelTexture;
      this.MyRenderer.materials[1].mainTexture = this.TowelTexture;
      this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
      this.Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    }
    else
    {
      this.MyRenderer.sharedMesh = this.BaldNudeMesh;
      this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
      this.MyRenderer.materials[1].mainTexture = (Texture) null;
      this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
    }
    this.Cosmetic.RemoveCensor();
    if (!this.AoT)
    {
      if (this.Male)
      {
        for (this.ID = 0; this.ID < this.CensorSteam.Length; ++this.ID)
          this.CensorSteam[this.ID].SetActive(true);
      }
    }
    else if (!this.Male)
    {
      this.MyRenderer.sharedMesh = this.BaldNudeMesh;
      this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
      this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
      this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
    }
    else
      this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
    if (this.Club != ClubType.Cooking)
      return;
    this.ApronAttacher.newRenderer.gameObject.SetActive(false);
    Debug.Log((object) "We were told to disable this apron attacher...");
  }

  public void ChangeSchoolwear()
  {
    for (this.ID = 0; this.ID < this.CensorSteam.Length; ++this.ID)
      this.CensorSteam[this.ID].SetActive(false);
    if (this.Attacher.gameObject.activeInHierarchy)
      this.Attacher.RemoveAccessory();
    if (this.LabcoatAttacher.enabled)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.LabcoatAttacher.newRenderer);
      this.LabcoatAttacher.enabled = false;
    }
    if (!this.Male && this.BikiniAttacher.enabled)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.BikiniAttacher.newRenderer);
      this.BikiniAttacher.enabled = false;
      this.MyRenderer.enabled = true;
    }
    if (this.Schoolwear == 0)
      this.Nude();
    else if (this.Schoolwear == 1)
    {
      if (!this.Male)
      {
        this.Cosmetic.SetFemaleUniform();
        this.SkirtCollider.gameObject.SetActive(true);
        if ((UnityEngine.Object) this.PantyCollider != (UnityEngine.Object) null)
          this.PantyCollider.enabled = true;
        if (this.Club == ClubType.Bully)
        {
          this.Cosmetic.RightWristband.SetActive(true);
          this.Cosmetic.LeftWristband.SetActive(true);
          this.Cosmetic.Bookbag.SetActive(true);
          this.Cosmetic.Hoodie.SetActive(true);
        }
      }
      else
        this.Cosmetic.SetMaleUniform();
    }
    else if (this.Schoolwear == 2)
    {
      if (this.Club == ClubType.Sports && this.Male)
      {
        this.MyRenderer.sharedMesh = this.SwimmingTrunks;
        this.MyRenderer.SetBlendShapeWeight(0, (float) (20 * (6 - this.ClubMemberID)));
        this.MyRenderer.SetBlendShapeWeight(1, (float) (20 * (6 - this.ClubMemberID)));
        this.MyRenderer.materials[0].mainTexture = this.Cosmetic.Trunks[this.StudentID];
        this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
        this.MyRenderer.materials[2].mainTexture = this.Cosmetic.Trunks[this.StudentID];
      }
      else
      {
        this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
        if (!this.Male)
        {
          if (this.Club == ClubType.Bully)
          {
            this.MyRenderer.materials[0].mainTexture = this.Cosmetic.GanguroSwimsuitTextures[this.BullyID];
            this.MyRenderer.materials[1].mainTexture = this.Cosmetic.GanguroSwimsuitTextures[this.BullyID];
            this.Cosmetic.RightWristband.SetActive(false);
            this.Cosmetic.LeftWristband.SetActive(false);
            this.Cosmetic.Bookbag.SetActive(false);
            this.Cosmetic.Hoodie.SetActive(false);
          }
          else
          {
            this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
            this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
          }
          this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
        }
        else
        {
          this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
          this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
          this.MyRenderer.materials[2].mainTexture = this.SwimsuitTexture;
        }
      }
    }
    else if (this.Schoolwear == 3)
    {
      this.MyRenderer.sharedMesh = this.GymUniform;
      if (this.StudentManager.Eighties)
        this.GymTexture = this.EightiesGymTexture;
      if (!this.Male)
      {
        this.MyRenderer.materials[0].mainTexture = this.GymTexture;
        this.MyRenderer.materials[1].mainTexture = this.GymTexture;
        this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
        if (this.Club == ClubType.Bully)
          this.Cosmetic.ActivateBullyAccessories();
      }
      else
      {
        this.MyRenderer.materials[0].mainTexture = this.GymTexture;
        this.MyRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinColor];
        this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
      }
    }
    if (!this.Male)
    {
      this.Cosmetic.Stockings = this.Schoolwear == 1 ? this.Cosmetic.OriginalStockings : string.Empty;
      this.StartCoroutine(this.Cosmetic.PutOnStockings());
      if (GameGlobals.CensorPanties)
        this.Cosmetic.CensorPanties();
    }
    for (; this.ID < this.Outlines.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null && (UnityEngine.Object) this.Outlines[this.ID].h != (UnityEngine.Object) null)
        this.Outlines[this.ID].h.ReinitMaterials();
    }
    if (this.Club == ClubType.Cooking)
    {
      if (this.Schoolwear == 1)
        this.ApronAttacher.newRenderer.gameObject.SetActive(true);
      else
        this.ApronAttacher.newRenderer.gameObject.SetActive(false);
    }
    if (this.Club == ClubType.LightMusic)
    {
      if (this.Schoolwear == 1)
        this.InstrumentBag[this.ClubMemberID].gameObject.SetActive(true);
      else
        this.InstrumentBag[this.ClubMemberID].gameObject.SetActive(false);
    }
    this.WalkAnim = this.OriginalWalkAnim;
  }

  public void AttackOnTitan()
  {
    this.CharacterAnimation.CrossFade(this.WalkAnim);
    this.Nape.enabled = true;
    this.Blind = true;
    this.Hurry = true;
    this.AoT = true;
    this.TargetDistance = 5f;
    this.SprintAnim = this.WalkAnim;
    this.RunAnim = this.WalkAnim;
    this.MyController.center = new Vector3(this.MyController.center.x, 0.0825f, this.MyController.center.z);
    this.MyController.radius = 0.015f;
    this.MyController.height = 0.15f;
    if (!this.Male)
      this.Cosmetic.FaceTexture = this.TitanFaceTexture;
    else
      this.Cosmetic.FaceTextures[this.SkinColor] = this.TitanFaceTexture;
    this.NudeTexture = this.TitanBodyTexture;
    this.Nude();
    for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
      {
        OutlineScript outline = this.Outlines[this.ID];
        if ((UnityEngine.Object) outline.h == (UnityEngine.Object) null)
          outline.Awake();
        outline.h.ReinitMaterials();
      }
    }
    if (this.Male || this.Teacher)
      return;
    this.PantyCollider.enabled = false;
    this.SkirtCollider.gameObject.SetActive(false);
  }

  public void Spook()
  {
    if (this.Male)
      return;
    this.RightEye.gameObject.SetActive(false);
    this.LeftEye.gameObject.SetActive(false);
    this.MyRenderer.enabled = false;
    for (this.ID = 0; this.ID < this.Bones.Length; ++this.ID)
      this.Bones[this.ID].SetActive(true);
  }

  private void Unspook()
  {
    this.MyRenderer.enabled = true;
    for (this.ID = 0; this.ID < this.Bones.Length; ++this.ID)
      this.Bones[this.ID].SetActive(false);
  }

  private void GoChange()
  {
    if (!this.Male)
    {
      this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
      this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
    }
    else
    {
      this.CurrentDestination = this.StudentManager.MaleStripSpot;
      this.Pathfinding.target = this.StudentManager.MaleStripSpot;
    }
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.Distracted = false;
  }

  public void SpawnAlarmDisc()
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity);
    gameObject.GetComponent<AlarmDiscScript>().Male = this.Male;
    gameObject.GetComponent<AlarmDiscScript>().Originator = this;
    if (this.Splashed)
    {
      gameObject.GetComponent<AlarmDiscScript>().Shocking = true;
      gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
    }
    if (this.Struggling || this.Shoving || this.MurderSuicidePhase == 100 || (UnityEngine.Object) this.StudentManager.CombatMinigame.Delinquent == (UnityEngine.Object) this)
      gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
    if (this.Pushed)
      gameObject.GetComponent<AlarmDiscScript>().Silent = true;
    if (this.Club == ClubType.Delinquent)
      gameObject.GetComponent<AlarmDiscScript>().Delinquent = true;
    if (this.Yandere.RoofPush && (bool) (UnityEngine.Object) this.Yandere.TargetStudent)
      gameObject.transform.localScale *= 2f;
    if (!this.Dying || this.Yandere.Equipped <= 0 || this.Yandere.EquippedWeapon.WeaponID != 7)
      return;
    gameObject.GetComponent<AlarmDiscScript>().Long = true;
  }

  public void SpawnSmallAlarmDisc()
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity);
    gameObject.transform.localScale = new Vector3(100f, 1f, 100f);
    gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
  }

  public void ChangeClubwear()
  {
    if (!this.ClubAttire)
    {
      this.Cosmetic.RemoveCensor();
      this.DistanceToDestination = 100f;
      this.ClubAttire = true;
      if (this.Club == ClubType.Art)
      {
        if (!this.Male)
        {
          this.RightBreast.gameObject.name = "RightBreastRENAMED";
          this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
        }
        if (!this.Attacher.gameObject.activeInHierarchy)
          this.Attacher.gameObject.SetActive(true);
        else
          this.Attacher.Start();
      }
      else if (this.Club == ClubType.MartialArts)
      {
        this.MyRenderer.sharedMesh = this.JudoGiMesh;
        if (!this.Male)
        {
          this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
          this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
          this.MyRenderer.materials[2].mainTexture = this.JudoGiTexture;
          this.SkirtCollider.gameObject.SetActive(false);
          this.PantyCollider.enabled = false;
          this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
        }
        else
        {
          this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
          this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
          this.MyRenderer.materials[2].mainTexture = this.JudoGiTexture;
        }
      }
      else if (this.Club == ClubType.Science)
        this.WearLabCoat();
      else if (this.Club == ClubType.Sports)
      {
        if (this.Clock.Period < 3 || this.StudentManager.PoolClosed)
        {
          if (this.StudentManager.Eighties)
            this.GymTexture = this.EightiesGymTexture;
          this.MyRenderer.sharedMesh = this.GymUniform;
          if (this.Male)
          {
            this.MyRenderer.materials[0].mainTexture = this.GymTexture;
            this.MyRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinID];
            this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
          }
          else
          {
            this.MyRenderer.materials[0].mainTexture = this.GymTexture;
            this.MyRenderer.materials[1].mainTexture = this.GymTexture;
            this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
          }
          if ((UnityEngine.Object) this.Armband != (UnityEngine.Object) null)
          {
            this.Armband.transform.localPosition = new Vector3(-0.1f, 0.0f, -0.005f);
            Physics.SyncTransforms();
          }
        }
        else
        {
          if ((UnityEngine.Object) this.Armband != (UnityEngine.Object) null)
          {
            this.Armband.transform.localPosition = new Vector3(-0.1f, -0.01f, 0.0f);
            Physics.SyncTransforms();
          }
          this.MyRenderer.sharedMesh = this.SwimmingTrunks;
          if (this.Male)
          {
            this.MyRenderer.sharedMesh = this.SwimmingTrunks;
            this.MyRenderer.SetBlendShapeWeight(0, (float) (20 * (6 - this.ClubMemberID)));
            this.MyRenderer.materials[0].mainTexture = this.Cosmetic.Trunks[this.StudentID];
            this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
            this.MyRenderer.materials[2].mainTexture = this.Cosmetic.Trunks[this.StudentID];
          }
          else
          {
            this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
            if (!this.Male)
            {
              this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
              this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
              this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
            }
          }
          this.ClubAnim = "poolDive_00";
          this.ClubActivityPhase = 15;
          this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
        }
      }
      if (this.StudentID != 46)
        return;
      this.Armband.transform.localPosition = new Vector3(this.Armband.transform.localPosition.x, this.Armband.transform.localPosition.y, 0.01f);
      this.Armband.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
    else
    {
      this.ClubAttire = false;
      if (this.Club == ClubType.Art)
        this.Attacher.RemoveAccessory();
      else if (this.Club == ClubType.Science)
      {
        this.WearLabCoat();
      }
      else
      {
        this.ChangeSchoolwear();
        if (this.StudentID == 46)
        {
          this.Armband.transform.localPosition = new Vector3(-0.1f, 0.0f, 0.0f);
          this.Armband.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if (this.StudentID == 47)
        {
          this.StudentManager.ConvoManager.BothCharactersInPosition = false;
          this.ClubAnim = "idle_20";
        }
        else
        {
          if (this.StudentID != 49)
            return;
          this.StudentManager.ConvoManager.BothCharactersInPosition = false;
          this.ClubAnim = "f02_idle_20";
        }
      }
    }
  }

  private void WearLabCoat()
  {
    if (!this.LabcoatAttacher.enabled)
    {
      this.MyRenderer.sharedMesh = this.HeadAndHands;
      this.LabcoatAttacher.enabled = true;
      if (!this.Male)
      {
        this.RightBreast.gameObject.name = "RightBreastRENAMED";
        this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
      }
      if (this.LabcoatAttacher.Initialized)
        this.LabcoatAttacher.AttachAccessory();
      if (!this.Male)
      {
        this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
        this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
        this.MyRenderer.materials[2].mainTexture = (Texture) null;
        this.HideLabCoatPanties();
      }
      else
      {
        this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
        this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
        this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
      }
    }
    else
    {
      if (!this.Male)
      {
        this.RightBreast.gameObject.name = "RightBreastRENAMED";
        this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
        this.SkirtCollider.gameObject.SetActive(true);
        this.PantyCollider.enabled = true;
      }
      UnityEngine.Object.Destroy((UnityEngine.Object) this.LabcoatAttacher.newRenderer);
      this.LabcoatAttacher.enabled = false;
      this.ChangeSchoolwear();
    }
  }

  public void HideLabCoatPanties()
  {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.SkirtCollider.gameObject.SetActive(false);
    this.PantyCollider.enabled = false;
  }

  public void WearBikini()
  {
    if (!this.BikiniAttacher.enabled)
    {
      this.BikiniAttacher.enabled = true;
      this.MyRenderer.enabled = false;
      this.RightBreast.gameObject.name = "RightBreastRENAMED";
      this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
      if (this.BikiniAttacher.Initialized)
        this.BikiniAttacher.AttachAccessory();
      this.Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
      this.SkirtCollider.gameObject.SetActive(false);
      this.PantyCollider.enabled = false;
    }
    else
    {
      this.MyRenderer.enabled = true;
      this.RightBreast.gameObject.name = "RightBreastRENAMED";
      this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
      this.SkirtCollider.gameObject.SetActive(true);
      this.PantyCollider.enabled = true;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.BikiniAttacher.newRenderer);
      this.BikiniAttacher.enabled = false;
      this.ChangeSchoolwear();
    }
  }

  public void AttachRiggedAccessory()
  {
    this.RiggedAccessory.GetComponent<RiggedAccessoryAttacher>().ID = this.StudentID;
    if (this.Cosmetic.Accessory > 0)
      this.Cosmetic.FemaleAccessories[this.Cosmetic.Accessory].SetActive(false);
    if (this.StudentID == 26)
      this.MyRenderer.sharedMesh = this.NoArmsNoTorso;
    this.RiggedAccessory.SetActive(true);
  }

  public void CameraReact()
  {
    this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.Obstacle.enabled = true;
    this.CameraReacting = true;
    this.CameraReactPhase = 1;
    this.SpeechLines.Stop();
    this.Routine = false;
    this.StopPairing();
    if (!this.Sleuthing)
      this.SmartPhone.SetActive(false);
    this.OccultBook.SetActive(false);
    this.Scrubber.SetActive(false);
    this.Eraser.SetActive(false);
    this.Pen.SetActive(false);
    this.Pencil.SetActive(false);
    this.Sketchbook.SetActive(false);
    if (this.Club == ClubType.Gardening)
    {
      if (!this.StudentManager.Eighties)
      {
        this.WateringCan.transform.parent = this.Hips;
        this.WateringCan.transform.localPosition = new Vector3(0.0f, 0.0135f, -0.184f);
        this.WateringCan.transform.localEulerAngles = new Vector3(0.0f, 90f, 30f);
      }
    }
    else if (this.Club == ClubType.LightMusic)
    {
      if (this.StudentID == 51)
      {
        if ((UnityEngine.Object) this.InstrumentBag[this.ClubMemberID].transform.parent == (UnityEngine.Object) null)
        {
          this.Instruments[this.ClubMemberID].transform.parent = (Transform) null;
          if (!this.StudentManager.Eighties)
          {
            this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
            this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0.0f, 0.0f);
          }
          else
          {
            this.Instruments[this.ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
            this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
          }
          this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
          this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
        }
        else
          this.Instruments[this.ClubMemberID].SetActive(false);
      }
      else
        this.Instruments[this.ClubMemberID].SetActive(false);
      this.Drumsticks[0].SetActive(false);
      this.Drumsticks[1].SetActive(false);
    }
    foreach (GameObject scienceProp in this.ScienceProps)
    {
      if ((UnityEngine.Object) scienceProp != (UnityEngine.Object) null)
        scienceProp.SetActive(false);
    }
    foreach (GameObject gameObject in this.Fingerfood)
    {
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        gameObject.SetActive(false);
    }
    if (!this.Yandere.ClubAccessories[7].activeInHierarchy || this.Club == ClubType.Delinquent)
    {
      this.CharacterAnimation.CrossFade(this.CameraAnims[1]);
    }
    else
    {
      if (this.Club == ClubType.Bully)
        this.SmartPhone.SetActive(true);
      this.CharacterAnimation.CrossFade(this.IdleAnim);
    }
    this.EmptyHands();
  }

  private void LookForYandere()
  {
    if (this.Yandere.Chased || !this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
      return;
    ++this.ReportPhase;
  }

  public void UpdatePerception()
  {
    this.Perception = (UnityEngine.Object) this.Yandere != (UnityEngine.Object) null && this.Yandere.Club == ClubType.Occult || (UnityEngine.Object) this.Yandere != (UnityEngine.Object) null && this.Yandere.Class.StealthBonus > 0 ? 0.5f : 1f;
    this.ChameleonCheck();
    if (!this.Chameleon)
      return;
    this.Perception *= 0.5f;
  }

  public void StopInvestigating()
  {
    Debug.Log((object) (this.Name + " was investigating something, but has stopped."));
    this.Giggle = (GameObject) null;
    if (this.Sleuthing && this.CurrentAction != StudentActionType.SitAndEatBento)
    {
      this.CurrentDestination = this.SleuthTarget;
      this.Pathfinding.target = this.SleuthTarget;
    }
    else
    {
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.Destinations[this.Phase];
      if (this.Actions[this.Phase] == StudentActionType.Sunbathe && this.SunbathePhase > 1)
      {
        this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
        this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
      }
    }
    this.InvestigationTimer = 0.0f;
    this.InvestigationPhase = 0;
    if (!this.Hurry)
    {
      this.Pathfinding.speed = this.WalkSpeed;
    }
    else
    {
      this.Pathfinding.speed = 4f;
      this.WalkSpeed = 4f;
    }
    if (!this.ReturningMisplacedWeapon && this.Club == ClubType.Sports && this.CurrentAction == StudentActionType.ClubAction && this.ClubActivityPhase > 2 && this.ClubActivityPhase < 14)
    {
      Debug.Log((object) "Student was jogging before they started investigating, and will now return to jogging.");
      this.Jog();
    }
    if (this.CurrentAction == StudentActionType.Clean)
    {
      this.SmartPhone.SetActive(false);
      this.Scrubber.SetActive(true);
      if (this.CleaningRole == 5)
      {
        this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
        this.Eraser.SetActive(true);
      }
    }
    if ((double) this.DistanceToDestination == 0.5)
      this.DistanceToDestination = 0.66666f;
    this.YandereInnocent = false;
    this.Investigating = false;
    this.EatingSnack = false;
    this.HeardScream = false;
    this.DiscCheck = false;
    this.Routine = true;
    if (!(this.BeforeReturnAnim != ""))
      return;
    this.WalkAnim = this.BeforeReturnAnim;
  }

  public void Jog()
  {
    string str = "";
    if (!this.Male)
      str = "f02_";
    this.WalkAnim = str + "trackJog_00";
    this.Hurry = true;
    this.CharacterAnimation[this.ClubAnim].time = 0.0f;
    this.CurrentDestination = this.Destinations[this.Phase];
    this.Pathfinding.speed = 4f;
  }

  public void ForgetGiggle()
  {
    Debug.Log((object) (this.Name + " was just told to ForgetGiggle() and stop investigating."));
    this.Giggle = (GameObject) null;
    this.InvestigationTimer = 0.0f;
    this.InvestigationPhase = 0;
    this.YandereInnocent = false;
    this.Investigating = false;
    this.DiscCheck = false;
  }

  public bool InCouple => this.CoupleID > 0;

  private bool LovedOneIsTargeted(int yandereTargetID)
  {
    bool flag1 = this.StudentID == this.StudentManager.SuitorID && yandereTargetID == this.StudentManager.RivalID;
    if (!this.StudentManager.Eighties)
    {
      int num1 = !this.InCouple ? 0 : (this.PartnerID == yandereTargetID ? 1 : 0);
      bool flag2 = this.StudentID == 3 && yandereTargetID == 2;
      bool flag3 = this.StudentID == 2 && yandereTargetID == 3;
      int num2 = this.StudentID != 11 ? 0 : (yandereTargetID == 10 ? 1 : 0);
      bool flag4 = this.StudentID == 38 && yandereTargetID == 37;
      bool flag5 = this.StudentID == 37 && yandereTargetID == 38;
      bool flag6 = this.StudentID == 30 && yandereTargetID == 25;
      bool flag7 = this.StudentID == 25 && yandereTargetID == 30;
      bool flag8 = this.StudentID == 28 && yandereTargetID == 30;
      bool flag9 = false;
      bool flag10 = this.StudentID > 55 && this.StudentID < 61 && yandereTargetID > 55 && yandereTargetID < 61;
      if (this.Injured)
        flag9 = this.Club == ClubType.Delinquent && this.StudentManager.Students[yandereTargetID].Club == ClubType.Delinquent;
      int num3 = flag2 ? 1 : 0;
      return (num1 | num3 | (flag3 ? 1 : 0) | (flag4 ? 1 : 0) | (flag5 ? 1 : 0) | (flag6 ? 1 : 0) | (flag7 ? 1 : 0) | (flag8 ? 1 : 0) | (flag9 ? 1 : 0) | (flag10 ? 1 : 0) | (flag1 ? 1 : 0)) != 0;
    }
    bool flag11 = this.Male && yandereTargetID == 19;
    return flag1 | flag11;
  }

  private void Pose()
  {
    this.StudentManager.PoseMode.ChoosingAction = true;
    this.StudentManager.PoseMode.Panel.enabled = true;
    this.StudentManager.PoseMode.Student = this;
    this.StudentManager.PoseMode.UpdateLabels();
    this.StudentManager.PoseMode.Show = true;
    this.DialogueWheel.PromptBar.ClearButtons();
    this.DialogueWheel.PromptBar.Label[0].text = "Confirm";
    this.DialogueWheel.PromptBar.Label[1].text = "Back";
    this.DialogueWheel.PromptBar.Label[4].text = "Change";
    this.DialogueWheel.PromptBar.Label[5].text = "Increase/Decrease";
    this.DialogueWheel.PromptBar.UpdateButtons();
    this.DialogueWheel.PromptBar.Show = true;
    this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
    this.Yandere.CanMove = false;
    this.Posing = true;
  }

  public void DisableEffects()
  {
    this.LiquidProjector.enabled = false;
    this.ElectroSteam[0].SetActive(false);
    this.ElectroSteam[1].SetActive(false);
    this.ElectroSteam[2].SetActive(false);
    this.ElectroSteam[3].SetActive(false);
    this.CensorSteam[0].SetActive(false);
    this.CensorSteam[1].SetActive(false);
    this.CensorSteam[2].SetActive(false);
    this.CensorSteam[3].SetActive(false);
    foreach (Component liquidEmitter in this.LiquidEmitters)
      liquidEmitter.gameObject.SetActive(false);
    foreach (Component fireEmitter in this.FireEmitters)
      fireEmitter.gameObject.SetActive(false);
    for (this.ID = 0; this.ID < this.Bones.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.Bones[this.ID] != (UnityEngine.Object) null)
        this.Bones[this.ID].SetActive(false);
    }
    if (this.Persona != PersonaType.PhoneAddict)
      this.SmartPhone.SetActive(false);
    this.Note.SetActive(false);
    if (this.Slave)
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Broken);
  }

  public void DetermineSenpaiReaction()
  {
    Debug.Log((object) "We are now determining Senpai's reaction to Yandere-chan's behavior.");
    if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
    else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
    else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
    else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
    else if (this.Witnessed == StudentWitnessType.Weapon)
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
    else if (this.Witnessed == StudentWitnessType.Blood)
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiBloodReaction, 1, 4.5f);
    else if (this.Witnessed == StudentWitnessType.Insanity)
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
    else if (this.Witnessed == StudentWitnessType.Lewd || this.Witnessed == StudentWitnessType.Poisoning || this.Witnessed == StudentWitnessType.Pickpocketing || this.Witnessed == StudentWitnessType.Theft)
    {
      Debug.Log((object) "Senpai is supposed to choose the ''Lewd'' reaction now.");
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiLewdReaction, 1, 4.5f);
    }
    else if (this.GameOverCause == GameOverType.Stalking)
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, this.Concern, 4.5f);
    else if (this.GameOverCause == GameOverType.Murder)
    {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiMurderReaction, this.MurderReaction, 4.5f);
    }
    else
    {
      if (this.GameOverCause != GameOverType.Violence)
        return;
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiViolenceReaction, 1, 4.5f);
    }
  }

  public void ForgetRadio()
  {
    bool flag = false;
    if (this.CurrentAction == StudentActionType.Sunbathe && this.SunbathePhase > 2)
    {
      this.SunbathePhase = 2;
      flag = true;
    }
    if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless && !flag || this.Persona == PersonaType.Sleuth || this.StudentID == 20)
      this.SmartPhone.SetActive(true);
    this.TurnOffRadio = false;
    this.RadioTimer = 0.0f;
    this.RadioPhase = 1;
    this.Routine = true;
    this.Radio = (RadioScript) null;
  }

  public void RealizePhoneIsMissing()
  {
    Debug.Log((object) (this.Name + " is updating their routine to involve ''Search Patrol''."));
    this.Phoneless = true;
    ScheduleBlock scheduleBlock1 = this.ScheduleBlocks[2];
    scheduleBlock1.destination = "Search Patrol";
    scheduleBlock1.action = "Search Patrol";
    ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
    scheduleBlock2.destination = "Search Patrol";
    scheduleBlock2.action = "Search Patrol";
    ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[7];
    scheduleBlock3.destination = "Search Patrol";
    scheduleBlock3.action = "Search Patrol";
    this.GetDestinations();
  }

  public void TeleportToDestination()
  {
    this.GetDestinations();
    int phase = this.Phase;
    if (this.Phase >= this.ScheduleBlocks.Length || (double) this.Clock.HourTime < (double) this.ScheduleBlocks[this.Phase].time)
      return;
    ++this.Phase;
    if (this.Actions[this.Phase] == StudentActionType.Patrol || this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Gardening)
    {
      this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
      this.Pathfinding.target = this.CurrentDestination;
    }
    else
    {
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.Destinations[this.Phase];
    }
    this.transform.position = this.CurrentDestination.position;
  }

  public void AltTeleportToDestination()
  {
    if (this.Club == ClubType.Council)
      return;
    ++this.Phase;
    if (this.Club == ClubType.Bully)
    {
      ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
      scheduleBlock.destination = "Patrol";
      scheduleBlock.action = "Patrol";
    }
    this.GetDestinations();
    this.CurrentAction = this.Actions[this.Phase];
    if (this.CurrentAction == StudentActionType.Patrol || this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Gardening)
    {
      this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
      this.Pathfinding.target = this.CurrentDestination;
      this.transform.position = this.CurrentDestination.position;
    }
    else if ((UnityEngine.Object) this.Destinations[this.Phase] != (UnityEngine.Object) null)
    {
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.Destinations[this.Phase];
      if (this.StudentID != 8)
        return;
      this.transform.position = this.CurrentDestination.position;
    }
    else
      Debug.Log((object) (this.Name + "'s destination for this phase of the day is null. Problem?"));
  }

  public void GoCommitMurder()
  {
    Debug.Log((object) "A mind-broken slave has just been instructed to go kill somebody.");
    this.StudentManager.MurderTakingPlace = true;
    this.StudentManager.MindBrokenSlave = this;
    this.StudentManager.UpdateTeachers();
    if (!this.FragileSlave)
    {
      this.Yandere.EquippedWeapon.transform.parent = this.HipCollider.transform;
      this.Yandere.EquippedWeapon.transform.localPosition = Vector3.zero;
      this.Yandere.EquippedWeapon.transform.localScale = Vector3.zero;
      this.MyWeapon = this.Yandere.EquippedWeapon;
      this.MyWeapon.FingerprintID = this.StudentID;
      this.Yandere.EquippedWeapon = (WeaponScript) null;
      this.Yandere.Equipped = 0;
      this.StudentManager.UpdateStudents();
      this.Yandere.WeaponManager.UpdateLabels();
      this.Yandere.WeaponMenu.UpdateSprites();
      this.Yandere.WeaponWarning = false;
    }
    else
    {
      this.StudentManager.FragileWeapon.transform.parent = this.HipCollider.transform;
      this.StudentManager.FragileWeapon.transform.localPosition = Vector3.zero;
      this.StudentManager.FragileWeapon.transform.localScale = Vector3.zero;
      this.MyWeapon = this.StudentManager.FragileWeapon;
      this.MyWeapon.FingerprintID = this.StudentID;
      this.MyWeapon.MyCollider.enabled = false;
    }
    this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.CharacterAnimation.CrossFade("f02_brokenStandUp_00");
    if ((UnityEngine.Object) this.HuntTarget != (UnityEngine.Object) this)
    {
      this.DistanceToDestination = 100f;
      this.Broken.Hunting = true;
      this.TargetDistance = 1f;
      this.Routine = false;
      this.Hunting = true;
    }
    else
    {
      this.Broken.Done = true;
      this.Routine = false;
      this.Suicide = true;
    }
    this.Prompt.Hide();
    this.Prompt.enabled = false;
  }

  public void Shove()
  {
    if (this.Yandere.Shoved || this.Dying || this.Yandere.Egg || this.Yandere.Lifting || this.Yandere.SneakingShot || this.ShoeRemoval.enabled || this.Yandere.Talking || this.SentToLocker)
      return;
    if ((UnityEngine.Object) this.Giggle != (UnityEngine.Object) null)
      this.ForgetGiggle();
    this.ForgetRadio();
    this.GetComponent<AudioSource>();
    if (this.StudentID == 86)
      this.Subtitle.UpdateLabel(SubtitleType.Shoving, 1, 5f);
    else if (this.StudentID == 87)
      this.Subtitle.UpdateLabel(SubtitleType.Shoving, 2, 5f);
    else if (this.StudentID == 88)
      this.Subtitle.UpdateLabel(SubtitleType.Shoving, 3, 5f);
    else if (this.StudentID == 89)
      this.Subtitle.UpdateLabel(SubtitleType.Shoving, 4, 5f);
    if (this.Yandere.Aiming)
      this.Yandere.StopAiming();
    if (this.Yandere.Laughing)
      this.Yandere.StopLaughing();
    if (this.Yandere.Stance.Current != StanceType.Standing)
    {
      this.Yandere.Stance.Current = StanceType.Standing;
      this.Yandere.CrawlTimer = 0.0f;
      this.Yandere.Uncrouch();
    }
    this.transform.rotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
    this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
    this.CharacterAnimation[this.ShoveAnim].time = 0.0f;
    this.CharacterAnimation.CrossFade(this.ShoveAnim);
    this.FocusOnStudent = false;
    this.FocusOnYandere = false;
    this.Investigating = false;
    this.Distracted = true;
    this.Alarmed = false;
    this.Routine = false;
    this.Shoving = true;
    this.NoTalk = false;
    --this.Patience;
    if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this)
    {
      this.StudentManager.BloodReporter = (StudentScript) null;
      this.ReportingBlood = false;
    }
    if (this.Club == ClubType.Delinquent && (this.WitnessedBloodPool || this.FoundEnemyCorpse))
      this.StudentManager.CombatMinigame.ExitSchoolWhenDone = true;
    this.WitnessedBloodyWeapon = false;
    this.WitnessedBloodPool = false;
    this.WitnessedSomething = false;
    this.WitnessedMurder = false;
    this.WitnessedWeapon = false;
    this.WitnessedLimb = false;
    this.BloodPool = (Transform) null;
    if (this.Club != ClubType.Council && this.Persona != PersonaType.Violent && this.StudentID != 20)
    {
      Debug.Log((object) "Patience shot up to 999.");
      this.Patience = 999;
    }
    if (this.Patience < 1)
      this.Yandere.CannotRecover = true;
    if (this.ReturningMisplacedWeapon)
      this.DropMisplacedWeapon();
    this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0.0f;
    this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
    this.Yandere.YandereVision = false;
    this.Yandere.NearSenpai = false;
    this.Yandere.Degloving = false;
    this.Yandere.Flicking = false;
    this.Yandere.Punching = false;
    this.Yandere.CanMove = false;
    this.Yandere.Shoved = true;
    this.Yandere.EmptyHands();
    this.Yandere.GloveTimer = 0.0f;
    this.Yandere.h = 0.0f;
    this.Yandere.v = 0.0f;
    this.Yandere.ShoveSpeed = 2f;
    if ((UnityEngine.Object) this.Distraction != (UnityEngine.Object) null)
    {
      this.TargetedForDistraction = false;
      this.Pathfinding.speed = this.WalkSpeed;
      this.SpeechLines.Stop();
      this.Distraction = (Transform) null;
      this.CanTalk = true;
    }
    if (this.Actions[this.Phase] != StudentActionType.Patrol)
    {
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.CurrentDestination;
    }
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
  }

  public void PushYandereAway()
  {
    if (this.Yandere.Aiming)
      this.Yandere.StopAiming();
    if (this.Yandere.Laughing)
      this.Yandere.StopLaughing();
    this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
    this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0.0f;
    this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
    this.Yandere.YandereVision = false;
    this.Yandere.NearSenpai = false;
    this.Yandere.Degloving = false;
    this.Yandere.Flicking = false;
    this.Yandere.Punching = false;
    this.Yandere.CanMove = false;
    this.Yandere.Shoved = true;
    this.Yandere.EmptyHands();
    this.Yandere.GloveTimer = 0.0f;
    this.Yandere.h = 0.0f;
    this.Yandere.v = 0.0f;
    this.Yandere.ShoveSpeed = 2f;
  }

  public void Spray()
  {
    Debug.Log((object) (this.Name + " is trying to Spray Yandere-chan!"));
    if (this.Yandere.Attacking || this.Yandere.Struggling)
    {
      this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
    }
    else
    {
      bool flag = false;
      if (this.Yandere.DelinquentFighting && !this.NoBreakUp && !this.StudentManager.CombatMinigame.Delinquent.WitnessedMurder)
        flag = true;
      if (!flag)
      {
        if (!this.Yandere.Sprayed && !this.Dying && !this.Blind && !this.Yandere.Egg && !this.Yandere.Dumping && !this.Yandere.Bathing && !this.Yandere.Noticed && !this.Yandere.CannotBeSprayed)
        {
          if ((double) this.SprayTimer > 0.0)
          {
            this.SprayTimer = Mathf.MoveTowards(this.SprayTimer, 0.0f, Time.deltaTime);
          }
          else
          {
            AudioSource.PlayClipAtPoint(this.PepperSpraySFX, this.transform.position);
            if (this.StudentID == 86)
              this.Subtitle.UpdateLabel(SubtitleType.Spraying, 1, 5f);
            else if (this.StudentID == 87)
              this.Subtitle.UpdateLabel(SubtitleType.Spraying, 2, 5f);
            else if (this.StudentID == 88)
              this.Subtitle.UpdateLabel(SubtitleType.Spraying, 3, 5f);
            else if (this.StudentID == 89)
              this.Subtitle.UpdateLabel(SubtitleType.Spraying, 4, 5f);
            if (this.Yandere.Aiming)
              this.Yandere.StopAiming();
            if (this.Yandere.Laughing)
              this.Yandere.StopLaughing();
            this.transform.rotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, this.transform.position.y, this.Yandere.Hips.transform.position.z) - this.transform.position);
            this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
            Debug.Log((object) "This is the exact moment that the character is being told to perform a spraying animation.");
            this.CharacterAnimation.CrossFade(this.SprayAnim);
            this.PepperSpray.SetActive(true);
            this.FocusOnStudent = false;
            this.FocusOnYandere = false;
            this.Distracted = true;
            this.Spraying = true;
            this.Alarmed = false;
            this.Routine = false;
            this.Fleeing = true;
            this.Blind = true;
            this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
            this.Yandere.YandereVision = false;
            this.Yandere.NearSenpai = false;
            this.Yandere.Attacking = false;
            this.Yandere.FollowHips = true;
            this.Yandere.Punching = false;
            this.Yandere.CanMove = false;
            this.Yandere.Sprayed = true;
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.StudentManager.YandereDying = true;
            this.StudentManager.StopMoving();
            this.Yandere.Blur.Size = 1f;
            this.Yandere.Jukebox.Volume = 0.0f;
            if (this.Yandere.DelinquentFighting)
              this.StudentManager.CombatMinigame.Stop();
            this.DetectionMarker.gameObject.SetActive(false);
            if ((UnityEngine.Object) this.SmartPhone != (UnityEngine.Object) null && this.SmartPhone.activeInHierarchy)
              this.SmartPhone.SetActive(false);
          }
        }
        else if (!this.Yandere.Sprayed)
        {
          this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
          if (this.Yandere.Egg)
          {
            this.Yandere.CanMove = true;
            this.Yandere.Chased = false;
            this.Yandere.Chasers = 0;
            this.BecomeRagdoll();
          }
        }
      }
      else
      {
        Debug.Log((object) "A student council member is breaking up the fight.");
        if (this.StudentManager.CombatMinigame.Delinquent.Male)
        {
          this.StudentManager.CombatMinigame.Delinquent.CharacterAnimation.Play("stopFighting_00");
          this.StudentManager.CombatMinigame.StopFightingAnim = "stopFighting_00";
        }
        else
        {
          this.StudentManager.CombatMinigame.Delinquent.CharacterAnimation.Play("f02_stopFighting_00");
          this.StudentManager.CombatMinigame.StopFightingAnim = "f02_stopFighting_00";
        }
        this.Yandere.CharacterAnimation.Play("f02_stopFighting_00");
        this.Yandere.FightHasBrokenUp = true;
        this.Yandere.BreakUpTimer = 10f;
        this.StudentManager.CombatMinigame.Path = 7;
        this.StudentManager.Portal.SetActive(true);
        if (!this.BreakingUpFight && this.Club == ClubType.Council)
          this.Subtitle.UpdateLabel(SubtitleType.BreakingUp, this.ClubMemberID, 5f);
        this.CharacterAnimation.Play(this.BreakUpAnim);
        this.BreakingUpFight = true;
        this.SprayTimer = 1f;
      }
      this.StudentManager.CombatMinigame.DisablePrompts();
      this.StudentManager.CombatMinigame.MyVocals.Stop();
      this.StudentManager.CombatMinigame.MyAudio.Stop();
      Time.timeScale = 1f;
    }
  }

  private void DetermineCorpseLocation()
  {
    Debug.Log((object) (this.Name + " has called the DetermineCorpseLocation() function."));
    if ((UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) null)
      this.StudentManager.Reporter = this;
    if (this.Teacher)
    {
      this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
      this.StudentManager.CorpseLocation.LookAt(new Vector3(this.transform.position.x, this.StudentManager.CorpseLocation.position.y, this.transform.position.z));
      this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward);
      this.StudentManager.LowerCorpsePosition();
    }
    this.Pathfinding.target = this.StudentManager.CorpseLocation;
    this.CurrentDestination = this.StudentManager.CorpseLocation;
    this.AssignCorpseGuardLocations();
  }

  private void DetermineBloodLocation()
  {
    Debug.Log((object) (this.Name + " is now firing DetermineBloodLocation()."));
    if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) null)
      this.StudentManager.BloodReporter = this;
    if (!this.Teacher)
      return;
    this.StudentManager.BloodLocation.position = this.BloodPool.transform.position;
    this.StudentManager.BloodLocation.LookAt(new Vector3(this.transform.position.x, this.StudentManager.BloodLocation.position.y, this.transform.position.z));
    this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward);
    this.StudentManager.LowerBloodPosition();
  }

  private void AssignCorpseGuardLocations()
  {
    this.StudentManager.CorpseGuardLocation[1].position = this.StudentManager.CorpseLocation.position + new Vector3(0.0f, 0.0f, 1f);
    this.LookAway(this.StudentManager.CorpseGuardLocation[1], this.StudentManager.CorpseLocation);
    this.StudentManager.CorpseGuardLocation[2].position = this.StudentManager.CorpseLocation.position + new Vector3(1f, 0.0f, 0.0f);
    this.LookAway(this.StudentManager.CorpseGuardLocation[2], this.StudentManager.CorpseLocation);
    this.StudentManager.CorpseGuardLocation[3].position = this.StudentManager.CorpseLocation.position + new Vector3(0.0f, 0.0f, -1f);
    this.LookAway(this.StudentManager.CorpseGuardLocation[3], this.StudentManager.CorpseLocation);
    this.StudentManager.CorpseGuardLocation[4].position = this.StudentManager.CorpseLocation.position + new Vector3(-1f, 0.0f, 0.0f);
    this.LookAway(this.StudentManager.CorpseGuardLocation[4], this.StudentManager.CorpseLocation);
  }

  private void AssignBloodGuardLocations()
  {
    this.StudentManager.BloodGuardLocation[1].position = this.StudentManager.BloodLocation.position + new Vector3(0.0f, 0.0f, 1f);
    this.LookAway(this.StudentManager.BloodGuardLocation[1], this.StudentManager.BloodLocation);
    this.StudentManager.BloodGuardLocation[2].position = this.StudentManager.BloodLocation.position + new Vector3(1f, 0.0f, 0.0f);
    this.LookAway(this.StudentManager.BloodGuardLocation[2], this.StudentManager.BloodLocation);
    this.StudentManager.BloodGuardLocation[3].position = this.StudentManager.BloodLocation.position + new Vector3(0.0f, 0.0f, -1f);
    this.LookAway(this.StudentManager.BloodGuardLocation[3], this.StudentManager.BloodLocation);
    this.StudentManager.BloodGuardLocation[4].position = this.StudentManager.BloodLocation.position + new Vector3(-1f, 0.0f, 0.0f);
    this.LookAway(this.StudentManager.BloodGuardLocation[4], this.StudentManager.BloodLocation);
  }

  private void AssignTeacherGuardLocations()
  {
    this.StudentManager.TeacherGuardLocation[1].position = this.StudentManager.CorpseLocation.position + new Vector3(0.75f, 0.0f, 0.75f);
    this.LookAway(this.StudentManager.TeacherGuardLocation[1], this.StudentManager.CorpseLocation);
    this.StudentManager.TeacherGuardLocation[2].position = this.StudentManager.CorpseLocation.position + new Vector3(0.75f, 0.0f, -0.75f);
    this.LookAway(this.StudentManager.TeacherGuardLocation[2], this.StudentManager.CorpseLocation);
    this.StudentManager.TeacherGuardLocation[3].position = this.StudentManager.CorpseLocation.position + new Vector3(-0.75f, 0.0f, -0.75f);
    this.LookAway(this.StudentManager.TeacherGuardLocation[3], this.StudentManager.CorpseLocation);
    this.StudentManager.TeacherGuardLocation[4].position = this.StudentManager.CorpseLocation.position + new Vector3(-0.75f, 0.0f, 0.75f);
    this.LookAway(this.StudentManager.TeacherGuardLocation[4], this.StudentManager.CorpseLocation);
    this.StudentManager.TeacherGuardLocation[5].position = this.StudentManager.CorpseLocation.position + new Vector3(0.0f, 0.0f, 0.5f);
    this.LookAway(this.StudentManager.TeacherGuardLocation[5], this.StudentManager.CorpseLocation);
    this.StudentManager.TeacherGuardLocation[6].position = this.StudentManager.CorpseLocation.position + new Vector3(0.0f, 0.0f, -0.5f);
    this.LookAway(this.StudentManager.TeacherGuardLocation[6], this.StudentManager.CorpseLocation);
  }

  private void LookAway(Transform T1, Transform T2)
  {
    T1.LookAt(T2);
    float y = T1.eulerAngles.y + 180f;
    T1.eulerAngles = new Vector3(T1.eulerAngles.x, y, T1.eulerAngles.z);
  }

  public void TurnToStone()
  {
    this.Cosmetic.RightEyeRenderer.material.mainTexture = this.Yandere.Stone;
    this.Cosmetic.LeftEyeRenderer.material.mainTexture = this.Yandere.Stone;
    this.Cosmetic.HairRenderer.material.mainTexture = this.Yandere.Stone;
    if (this.Cosmetic.HairRenderer.materials.Length > 1)
      this.Cosmetic.HairRenderer.materials[1].mainTexture = this.Yandere.Stone;
    this.Cosmetic.RightEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
    this.Cosmetic.LeftEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
    this.Cosmetic.HairRenderer.material.color = new Color(1f, 1f, 1f, 1f);
    this.MyRenderer.materials[0].mainTexture = this.Yandere.Stone;
    this.MyRenderer.materials[1].mainTexture = this.Yandere.Stone;
    this.MyRenderer.materials[2].mainTexture = this.Yandere.Stone;
    if (this.Teacher && this.Cosmetic.TeacherAccessories[8].activeInHierarchy)
      this.MyRenderer.materials[3].mainTexture = this.Yandere.Stone;
    if ((UnityEngine.Object) this.PickPocket != (UnityEngine.Object) null)
    {
      this.PickPocket.enabled = false;
      this.PickPocket.Prompt.Hide();
      this.PickPocket.Prompt.enabled = false;
    }
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.DetectionMarker.gameObject);
    AudioSource.PlayClipAtPoint(this.Yandere.Petrify, this.transform.position + new Vector3(0.0f, 1f, 0.0f));
    UnityEngine.Object.Instantiate<GameObject>(this.Yandere.Pebbles, this.Hips.position, Quaternion.identity);
    this.Pathfinding.enabled = false;
    this.ShoeRemoval.enabled = false;
    this.CharacterAnimation.Stop();
    this.Prompt.enabled = false;
    this.SpeechLines.Stop();
    this.Prompt.Hide();
    this.enabled = false;
  }

  public void StopPairing()
  {
    if (this.Actions[this.Phase] != StudentActionType.Clean && this.Persona == PersonaType.PhoneAddict && !this.Phoneless && !this.LostTeacherTrust)
      this.WalkAnim = this.PhoneAnims[1];
    this.Spawned = true;
    this.Paired = false;
  }

  public void ChameleonCheck()
  {
    this.ChameleonBonus = 0.0f;
    this.Chameleon = false;
    if (!((UnityEngine.Object) this.Yandere != (UnityEngine.Object) null) || (this.Yandere.Persona != YanderePersonaType.Scholarly || this.Persona != PersonaType.TeachersPet) && (this.Yandere.Persona != YanderePersonaType.Scholarly || this.Club != ClubType.Science) && (this.Yandere.Persona != YanderePersonaType.Scholarly || this.Club != ClubType.Art) && (this.Yandere.Persona != YanderePersonaType.Chill || this.Persona != PersonaType.SocialButterfly) && (this.Yandere.Persona != YanderePersonaType.Chill || this.Club != ClubType.Photography) && (this.Yandere.Persona != YanderePersonaType.Chill || this.Club != ClubType.Gaming) && (this.Yandere.Persona != YanderePersonaType.Confident || this.Persona != PersonaType.Heroic) && (this.Yandere.Persona != YanderePersonaType.Confident || this.Club != ClubType.MartialArts) && (this.Yandere.Persona != YanderePersonaType.Elegant || this.Club != ClubType.Drama) && (this.Yandere.Persona != YanderePersonaType.Girly || this.Persona != PersonaType.SocialButterfly) && (this.Yandere.Persona != YanderePersonaType.Girly || this.Club != ClubType.Cooking) && (this.Yandere.Persona != YanderePersonaType.Graceful || this.Club != ClubType.Gardening) && (this.Yandere.Persona != YanderePersonaType.Haughty || this.Club != ClubType.Bully) && (this.Yandere.Persona != YanderePersonaType.Lively || this.Persona != PersonaType.SocialButterfly) && (this.Yandere.Persona != YanderePersonaType.Lively || this.Club != ClubType.LightMusic) && (this.Yandere.Persona != YanderePersonaType.Lively || this.Club != ClubType.Sports) && (this.Yandere.Persona != YanderePersonaType.Shy || this.Persona != PersonaType.Loner) && (this.Yandere.Persona != YanderePersonaType.Shy || this.Club != ClubType.Occult) && (this.Yandere.Persona != YanderePersonaType.Tough || this.Persona != PersonaType.Spiteful) && (this.Yandere.Persona != YanderePersonaType.Tough || this.Club != ClubType.Delinquent))
      return;
    Debug.Log((object) "Chameleon is true!");
    this.ChameleonBonus = this.VisionDistance * 0.5f;
    this.Chameleon = true;
  }

  private void PhoneAddictGameOver()
  {
    if (this.Yandere.Lost || this.Yandere.ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
      return;
    this.Yandere.CharacterAnimation.CrossFade("f02_down_22");
    this.Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(true);
    this.Yandere.RPGCamera.enabled = false;
    this.Yandere.Jukebox.GameOver();
    this.Yandere.enabled = false;
    this.Yandere.EmptyHands();
    this.Countdown.gameObject.SetActive(false);
    this.ChaseCamera.SetActive(false);
    this.Police.Heartbroken.Exposed = true;
    this.StudentManager.StopMoving();
    this.Fleeing = false;
  }

  private void EndAlarm()
  {
    Debug.Log((object) (this.Name + " just fired the EndAlarm() function."));
    if (this.ReturnToRoutineAfter)
    {
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.Destinations[this.Phase];
      this.ReturnToRoutineAfter = false;
    }
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.IgnoreTimer = this.StudentID == 1 || this.Teacher ? 0.0001f : 5f;
    if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
      this.SmartPhone.SetActive(true);
    this.FocusOnStudent = false;
    this.FocusOnYandere = false;
    this.DiscCheck = false;
    this.Alarmed = false;
    this.Reacted = false;
    this.Hesitation = 0.0f;
    this.AlarmTimer = 0.0f;
    if (this.WitnessedCorpse)
      this.PersonaReaction();
    else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
    {
      Debug.Log((object) (this.Name + " will now investigate a suspicious object on the ground..."));
      if (this.Following)
      {
        this.Hearts.emission.enabled = false;
        this.FollowCountdown.gameObject.SetActive(false);
        this.Yandere.Follower = (StudentScript) null;
        --this.Yandere.Followers;
        this.Following = false;
      }
      this.BeforeReturnAnim = this.WalkAnim;
      this.WalkAnim = this.OriginalWalkAnim;
      this.CharacterAnimation.CrossFade(this.WalkAnim);
      this.CurrentDestination = this.BloodPool;
      this.Pathfinding.target = this.BloodPool;
      this.Pathfinding.canSearch = true;
      this.Pathfinding.canMove = true;
      this.WalkSpeed = 1f;
      this.Pathfinding.speed = this.WalkSpeed;
      this.InvestigatingBloodPool = true;
      this.Routine = false;
      this.IgnoreTimer = 0.0001f;
    }
    else if (!this.Following && !this.Wet && !this.Investigating)
      this.Routine = true;
    if (this.ResumeDistracting)
    {
      Debug.Log((object) (this.Name + " was told to resume distracting."));
      this.CharacterAnimation.CrossFade(this.WalkAnim);
      this.Distracting = true;
      this.Routine = false;
      this.CurrentDestination = this.DistractionTarget.transform;
      this.Pathfinding.target = this.DistractionTarget.transform;
      this.ResumeDistracting = false;
    }
    if (this.ResumeTakingOutTrash)
    {
      Debug.Log((object) "This character was told to resume taking out the trash.");
      this.CharacterAnimation.CrossFade(this.WalkAnim);
      this.TakingOutTrash = true;
      this.Routine = false;
    }
    if (this.CurrentAction == StudentActionType.Clean)
    {
      this.SmartPhone.SetActive(false);
      this.Scrubber.SetActive(true);
      if (this.CleaningRole == 5)
      {
        this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
        this.Eraser.SetActive(true);
      }
    }
    if (!this.TurnOffRadio)
      return;
    this.Routine = false;
  }

  public void GetSleuthTarget()
  {
    this.WalkAnim = this.SleuthWalkAnim;
    this.TargetDistance = 2f;
    ++this.SleuthID;
    if (this.SleuthID < 98)
    {
      if ((UnityEngine.Object) this.StudentManager.Students[this.SleuthID] == (UnityEngine.Object) null)
        this.GetSleuthTarget();
      else if (!this.StudentManager.Students[this.SleuthID].gameObject.activeInHierarchy)
        this.GetSleuthTarget();
      else if ((UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) null && this.StudentManager.LockerRoomArea.bounds.Contains(this.CurrentDestination.position) || (UnityEngine.Object) this.CurrentDestination != (UnityEngine.Object) null && this.StudentManager.MaleLockerRoomArea.bounds.Contains(this.CurrentDestination.position))
      {
        this.GetSleuthTarget();
      }
      else
      {
        this.SleuthTarget = this.StudentManager.Students[this.SleuthID].transform;
        this.Pathfinding.target = this.SleuthTarget;
        this.CurrentDestination = this.SleuthTarget;
      }
    }
    else if (this.SleuthID == 98)
    {
      if (this.Yandere.Club == ClubType.Photography)
      {
        this.SleuthID = 0;
        this.GetSleuthTarget();
      }
      else
      {
        this.SleuthTarget = this.Yandere.transform;
        this.Pathfinding.target = this.SleuthTarget;
        this.CurrentDestination = this.SleuthTarget;
      }
    }
    else
    {
      this.SleuthID = 0;
      this.GetSleuthTarget();
    }
  }

  public void GetFoodTarget()
  {
    ++this.Attempts;
    if (this.Attempts >= 100)
    {
      Debug.Log((object) (this.Name + " is now giving up on attempting to select a person to give food to."));
      ++this.Phase;
    }
    else
    {
      ++this.SleuthID;
      if (this.SleuthID < 90)
      {
        if (this.SleuthID == this.StudentID)
          this.GetFoodTarget();
        else if ((UnityEngine.Object) this.StudentManager.Students[this.SleuthID] == (UnityEngine.Object) null)
          this.GetFoodTarget();
        else if (!this.StudentManager.Students[this.SleuthID].gameObject.activeInHierarchy)
          this.GetFoodTarget();
        else if (this.StudentManager.Students[this.SleuthID].CurrentAction == StudentActionType.SitAndEatBento || this.StudentManager.Students[this.SleuthID].CurrentAction == StudentActionType.AtLocker || (UnityEngine.Object) this.StudentManager.Students[this.SleuthID].CurrentDestination == (UnityEngine.Object) this.StudentManager.Exit || this.StudentManager.Students[this.SleuthID].Club == ClubType.Cooking || this.StudentManager.Students[this.SleuthID].Club == ClubType.Delinquent || this.StudentManager.Students[this.SleuthID].Club == ClubType.Sports || this.StudentManager.Students[this.SleuthID].TargetedForDistraction || this.StudentManager.Students[this.SleuthID].ClubActivityPhase >= 16 || this.StudentManager.Students[this.SleuthID].InEvent || !this.StudentManager.Students[this.SleuthID].Routine || this.StudentManager.Students[this.SleuthID].Posing || this.StudentManager.Students[this.SleuthID].Slave || this.StudentManager.Students[this.SleuthID].Wet || this.StudentManager.Students[this.SleuthID].Sedated || this.StudentManager.Students[this.SleuthID].DoNotFeed || this.StudentManager.Students[this.SleuthID].AlreadyFed || this.StudentManager.Students[this.SleuthID].Club == ClubType.LightMusic && this.StudentManager.PracticeMusic.isPlaying)
        {
          int currentAction1 = (int) this.StudentManager.Students[this.SleuthID].CurrentAction;
          int currentAction2 = (int) this.StudentManager.Students[this.SleuthID].CurrentAction;
          int num1 = (UnityEngine.Object) this.StudentManager.Students[this.SleuthID].CurrentDestination == (UnityEngine.Object) this.StudentManager.Exit ? 1 : 0;
          int club1 = (int) this.StudentManager.Students[this.SleuthID].Club;
          int club2 = (int) this.StudentManager.Students[this.SleuthID].Club;
          int club3 = (int) this.StudentManager.Students[this.SleuthID].Club;
          int num2 = this.StudentManager.Students[this.SleuthID].TargetedForDistraction ? 1 : 0;
          int clubActivityPhase = this.StudentManager.Students[this.SleuthID].ClubActivityPhase;
          int num3 = this.StudentManager.Students[this.SleuthID].InEvent ? 1 : 0;
          int num4 = this.StudentManager.Students[this.SleuthID].Routine ? 1 : 0;
          int num5 = this.StudentManager.Students[this.SleuthID].Posing ? 1 : 0;
          int num6 = this.StudentManager.Students[this.SleuthID].Slave ? 1 : 0;
          int num7 = this.StudentManager.Students[this.SleuthID].Wet ? 1 : 0;
          int num8 = this.StudentManager.Students[this.SleuthID].Sedated ? 1 : 0;
          int num9 = this.StudentManager.Students[this.SleuthID].DoNotFeed ? 1 : 0;
          int num10 = this.StudentManager.Students[this.SleuthID].AlreadyFed ? 1 : 0;
          if (this.StudentManager.Students[this.SleuthID].Club == ClubType.LightMusic)
          {
            int num11 = this.StudentManager.PracticeMusic.isPlaying ? 1 : 0;
          }
          this.GetFoodTarget();
        }
        else
        {
          this.CharacterAnimation.CrossFade(this.WalkAnim);
          this.DistractionTarget = this.StudentManager.Students[this.SleuthID];
          this.DistractionTarget.TargetedForDistraction = true;
          this.SleuthTarget = this.StudentManager.Students[this.SleuthID].transform;
          this.Pathfinding.target = this.SleuthTarget;
          this.CurrentDestination = this.SleuthTarget;
          this.TargetDistance = 0.75f;
          this.DistractTimer = 8f;
          this.Distracting = true;
          this.CanTalk = false;
          this.Routine = false;
          this.Attempts = 0;
        }
      }
      else
      {
        this.SleuthID = 0;
        this.GetFoodTarget();
      }
    }
  }

  public void GetTeacherTarget()
  {
    Debug.Log((object) (this.Name + " is now attempting to select a teacher to talk to."));
    ++this.Attempts;
    if (this.Attempts >= 100)
    {
      Debug.Log((object) (this.Name + " is now giving up on attempting to select a teacher to talk to."));
      ++this.Phase;
    }
    else
    {
      ++this.TeacherID;
      if (this.TeacherID < 97)
      {
        if ((UnityEngine.Object) this.StudentManager.Students[this.TeacherID] == (UnityEngine.Object) null)
        {
          Debug.Log((object) (this.Name + " can't try to talk to Teacher #" + this.TeacherID.ToString() + " because that teacher is not at school right now."));
          this.GetTeacherTarget();
        }
        else if (!this.StudentManager.Students[this.TeacherID].gameObject.activeInHierarchy)
        {
          Debug.Log((object) (this.Name + " can't try to talk to Teacher #" + this.TeacherID.ToString() + " because that teacher is disabled right now."));
          this.GetTeacherTarget();
        }
        else if (this.StudentManager.Students[this.TeacherID].TargetedForDistraction || this.StudentManager.Students[this.TeacherID].InEvent || !this.StudentManager.Students[this.TeacherID].Routine || this.StudentManager.Students[this.TeacherID].Posing)
        {
          this.GetTeacherTarget();
        }
        else
        {
          Debug.Log((object) (this.Name + " is choosing Teacher #" + this.TeacherID.ToString() + " as their target."));
          this.CharacterAnimation.CrossFade(this.WalkAnim);
          this.DistractionTarget = this.StudentManager.Students[this.TeacherID];
          this.DistractionTarget.TargetedForDistraction = true;
          this.DistractionTarget = this.StudentManager.Students[this.TeacherID];
          this.Pathfinding.target = this.DistractionTarget.gameObject.transform;
          this.CurrentDestination = this.DistractionTarget.gameObject.transform;
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.TargetDistance = 0.75f;
          this.DistractTimer = 10f;
          this.Distracting = true;
          this.CanTalk = false;
          this.Routine = false;
          this.Attempts = 0;
        }
      }
      else
      {
        Debug.Log((object) (this.Name + " went past Teacher #96 so they're resetting back to $90."));
        this.TeacherID = 90;
        this.GetTeacherTarget();
      }
    }
  }

  private void PhoneAddictCameraUpdate()
  {
    if (!((UnityEngine.Object) this.SmartPhone.transform.parent != (UnityEngine.Object) null))
      return;
    this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    if (!this.StudentManager.Eighties)
    {
      this.SmartPhone.transform.localPosition = new Vector3(0.0f, 0.005f, -0.01f);
      this.SmartPhone.transform.localEulerAngles = new Vector3(7.33333f, -154f, 173.666656f);
    }
    else
    {
      this.SmartPhone.transform.localPosition = new Vector3(0.085f, -0.0015f, 3f / 1000f);
      this.SmartPhone.transform.localEulerAngles = new Vector3(-10f, 30f, 165f);
    }
    this.SmartPhone.SetActive(true);
    if (this.Sleuthing)
    {
      if ((double) this.AlarmTimer < 2.0)
      {
        this.AlarmTimer = 2f;
        this.ScaredAnim = this.SleuthReactAnim;
        this.SprintAnim = this.SleuthReportAnim;
        this.CharacterAnimation.CrossFade(this.ScaredAnim);
      }
      if (this.CameraFlash.activeInHierarchy || (double) this.CharacterAnimation[this.ScaredAnim].time <= 2.0)
        return;
      this.CameraFlash.SetActive(true);
      if (!((UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null))
        return;
      this.Countdown.MaskedPhoto = true;
    }
    else
    {
      this.ScaredAnim = this.PhoneAnims[4];
      this.CharacterAnimation.CrossFade(this.ScaredAnim);
      if (this.CameraFlash.activeInHierarchy || (double) this.CharacterAnimation[this.ScaredAnim].time <= 3.66666)
        return;
      this.CameraFlash.SetActive(true);
      if ((UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null)
      {
        this.Countdown.MaskedPhoto = true;
      }
      else
      {
        if (!this.Grudge)
          return;
        ++this.Police.PhotoEvidence;
        this.PhotoEvidence = true;
      }
    }
  }

  private void ReturnToRoutine()
  {
    if (this.Actions[this.Phase] == StudentActionType.Patrol || this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Gardening)
    {
      this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
      this.Pathfinding.target = this.CurrentDestination;
    }
    else
    {
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.Destinations[this.Phase];
    }
    if (this.BreakingUpFight)
      this.SetOutlinesYellow();
    else
      this.SetOutlinesOrange();
    this.BreakingUpFight = false;
    this.WitnessedMurder = false;
    this.Prompt.enabled = true;
    this.Alarmed = false;
    this.Fleeing = false;
    this.Routine = true;
    this.Grudge = false;
    this.Pathfinding.speed = this.WalkSpeed;
  }

  public void EmptyHands()
  {
    bool flag = false;
    if (this.SentHome && this.SmartPhone.activeInHierarchy || this.PhotoEvidence || this.Persona == PersonaType.PhoneAddict && !this.Dying && !this.Wet)
      flag = true;
    if ((UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent != (UnityEngine.Object) null)
    {
      if (this.WitnessedMurder || this.WitnessedCorpse)
        this.DropPlate();
      else
        this.MyPlate.gameObject.SetActive(false);
    }
    if (this.Club == ClubType.Gardening && !this.StudentManager.Eighties)
    {
      this.WateringCan.transform.parent = this.Hips;
      this.WateringCan.transform.localPosition = new Vector3(0.0f, 0.0135f, -0.184f);
      this.WateringCan.transform.localEulerAngles = new Vector3(0.0f, 90f, 30f);
    }
    if (this.Club == ClubType.LightMusic)
    {
      if (this.StudentID == 51)
      {
        if ((UnityEngine.Object) this.InstrumentBag[this.ClubMemberID].transform.parent == (UnityEngine.Object) null)
        {
          this.Instruments[this.ClubMemberID].transform.parent = (Transform) null;
          if (!this.StudentManager.Eighties)
          {
            this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
            this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0.0f, 0.0f);
          }
          else
          {
            this.Instruments[this.ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
            this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
          }
          this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
          this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
        }
        else
          this.Instruments[this.ClubMemberID].SetActive(false);
      }
      else
        this.Instruments[this.ClubMemberID].SetActive(false);
      this.Drumsticks[0].SetActive(false);
      this.Drumsticks[1].SetActive(false);
      this.AirGuitar.Stop();
    }
    if (!this.Male)
    {
      this.Handkerchief.SetActive(false);
      this.Cigarette.SetActive(false);
      this.Lighter.SetActive(false);
    }
    else
      this.PinkSeifuku.SetActive(false);
    if (!flag)
      this.SmartPhone.SetActive(false);
    if ((UnityEngine.Object) this.BagOfChips != (UnityEngine.Object) null)
      this.BagOfChips.SetActive(false);
    this.Chopsticks[0].SetActive(false);
    this.Chopsticks[1].SetActive(false);
    this.Sketchbook.SetActive(false);
    this.OccultBook.SetActive(false);
    this.Paintbrush.SetActive(false);
    this.EventBook.SetActive(false);
    this.Scrubber.SetActive(false);
    this.Octodog.SetActive(false);
    this.Palette.SetActive(false);
    this.Eraser.SetActive(false);
    this.Pencil.SetActive(false);
    this.Pen.SetActive(false);
    if ((UnityEngine.Object) this.Bento.transform.parent != (UnityEngine.Object) null)
      this.Bento.SetActive(false);
    foreach (GameObject scienceProp in this.ScienceProps)
    {
      if ((UnityEngine.Object) scienceProp != (UnityEngine.Object) null)
        scienceProp.SetActive(false);
    }
    foreach (GameObject gameObject in this.Fingerfood)
    {
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        gameObject.SetActive(false);
    }
  }

  public void UpdateAnimLayers()
  {
    this.CharacterAnimation[this.LeanAnim].speed += (float) this.StudentID * 0.01f;
    this.CharacterAnimation[this.ConfusedSitAnim].speed += (float) this.StudentID * 0.01f;
    this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0.0f, this.CharacterAnimation[this.WalkAnim].length);
    this.CharacterAnimation[this.WetAnim].layer = 9;
    this.CharacterAnimation.Play(this.WetAnim);
    this.CharacterAnimation[this.WetAnim].weight = 0.0f;
    if (!this.Male)
    {
      this.CharacterAnimation[this.StripAnim].speed = 1.5f;
      this.CharacterAnimation[this.GameAnim].speed = 2f;
      this.CharacterAnimation["f02_moLipSync_00"].layer = 9;
      this.CharacterAnimation.Play("f02_moLipSync_00");
      this.CharacterAnimation["f02_moLipSync_00"].weight = 0.0f;
      this.CharacterAnimation["f02_topHalfTexting_00"].layer = 8;
      this.CharacterAnimation.Play("f02_topHalfTexting_00");
      this.CharacterAnimation["f02_topHalfTexting_00"].weight = 0.0f;
      this.CharacterAnimation[this.CarryAnim].layer = 7;
      this.CharacterAnimation.Play(this.CarryAnim);
      this.CharacterAnimation[this.CarryAnim].weight = 0.0f;
      this.CharacterAnimation[this.SocialSitAnim].layer = 6;
      this.CharacterAnimation.Play(this.SocialSitAnim);
      this.CharacterAnimation[this.SocialSitAnim].weight = 0.0f;
      this.CharacterAnimation[this.ShyAnim].layer = 5;
      this.CharacterAnimation.Play(this.ShyAnim);
      this.CharacterAnimation[this.ShyAnim].weight = 0.0f;
      this.CharacterAnimation[this.FistAnim].layer = 4;
      this.CharacterAnimation[this.FistAnim].weight = 0.0f;
      this.CharacterAnimation[this.BentoAnim].layer = 3;
      this.CharacterAnimation.Play(this.BentoAnim);
      this.CharacterAnimation[this.BentoAnim].weight = 0.0f;
      this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
      this.CharacterAnimation.Play(this.AngryFaceAnim);
      this.CharacterAnimation[this.AngryFaceAnim].weight = 0.0f;
      this.CharacterAnimation["f02_wetIdle_00"].speed = 1.25f;
      this.CharacterAnimation["f02_sleuthScan_00"].speed = 1.4f;
      this.BoobsResized = false;
    }
    else
    {
      this.CharacterAnimation[this.ConfusedSitAnim].speed *= -1f;
      this.CharacterAnimation[this.ToughFaceAnim].layer = 7;
      this.CharacterAnimation.Play(this.ToughFaceAnim);
      this.CharacterAnimation[this.ToughFaceAnim].weight = 0.0f;
      this.CharacterAnimation[this.SocialSitAnim].layer = 6;
      this.CharacterAnimation.Play(this.SocialSitAnim);
      this.CharacterAnimation[this.SocialSitAnim].weight = 0.0f;
      this.CharacterAnimation[this.CarryShoulderAnim].layer = 5;
      this.CharacterAnimation.Play(this.CarryShoulderAnim);
      this.CharacterAnimation[this.CarryShoulderAnim].weight = 0.0f;
      this.CharacterAnimation["scaredFace_00"].layer = 4;
      this.CharacterAnimation.Play("scaredFace_00");
      this.CharacterAnimation["scaredFace_00"].weight = 0.0f;
      this.CharacterAnimation[this.SadFaceAnim].layer = 3;
      this.CharacterAnimation.Play(this.SadFaceAnim);
      this.CharacterAnimation[this.SadFaceAnim].weight = 0.0f;
      this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
      this.CharacterAnimation.Play(this.AngryFaceAnim);
      this.CharacterAnimation[this.AngryFaceAnim].weight = 0.0f;
      this.CharacterAnimation["sleuthScan_00"].speed = 1.4f;
    }
    if (this.Persona == PersonaType.Sleuth)
      this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0.0f, this.CharacterAnimation[this.WalkAnim].length);
    if (this.Club == ClubType.Bully)
    {
      if (!StudentGlobals.GetStudentBroken(this.StudentID) && this.BullyID > 1)
        this.CharacterAnimation["f02_bullyLaugh_00"].speed = (float) (0.89999997615814209 + (double) this.BullyID * 0.10000000149011612);
    }
    else if (this.Club == ClubType.Delinquent)
    {
      this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0.0f, this.CharacterAnimation[this.WalkAnim].length);
      this.CharacterAnimation[this.LeanAnim].speed = 0.5f;
    }
    else if (this.Club == ClubType.Council)
    {
      if (!this.StudentManager.Eighties)
      {
        this.CharacterAnimation["f02_faceCouncil" + this.Suffix + "_00"].layer = 10;
        this.CharacterAnimation.Play("f02_faceCouncil" + this.Suffix + "_00");
      }
    }
    else if (this.Club == ClubType.Gaming)
    {
      this.CharacterAnimation[this.VictoryAnim].speed -= 0.1f * (float) (this.StudentID - 36);
      this.CharacterAnimation[this.VictoryAnim].speed = 0.866666f;
    }
    else if (this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
      this.WalkAnim = this.PlateWalkAnim;
    if (this.StudentManager.Eighties)
      return;
    if (this.StudentID == 36)
    {
      this.CharacterAnimation[this.ToughFaceAnim].weight = 1f;
    }
    else
    {
      if (this.StudentID != 66)
        return;
      this.CharacterAnimation[this.ToughFaceAnim].weight = 1f;
    }
  }

  private void SpawnDetectionMarker()
  {
    this.DetectionMarker = UnityEngine.Object.Instantiate<GameObject>(this.Marker, this.Yandere.DetectionPanel.transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
    if (this.StudentID == 1)
      this.DetectionMarker.GetComponent<DetectionMarkerScript>().Tex.color = new Color(1f, 0.0f, 0.0f, 0.0f);
    this.DetectionMarker.transform.parent = this.Yandere.DetectionPanel.transform;
    this.DetectionMarker.Target = this.transform;
  }

  public void EquipCleaningItems()
  {
    if (this.CurrentAction != StudentActionType.Clean)
      return;
    if (!this.Phoneless && (this.Persona == PersonaType.PhoneAddict || this.Persona == PersonaType.Sleuth))
      this.WalkAnim = this.OriginalWalkAnim;
    this.SmartPhone.SetActive(false);
    this.Scrubber.SetActive(true);
    if (this.CleaningRole == 5)
    {
      this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
      this.Eraser.SetActive(true);
    }
    if (this.StudentID != 9 && this.StudentID != 60)
      return;
    this.WalkAnim = this.OriginalOriginalWalkAnim;
  }

  public void DetermineWhatWasWitnessed()
  {
    Debug.Log((object) ("We are now determining what " + this.Name + " witnessed."));
    if (this.Witnessed == StudentWitnessType.Murder)
    {
      Debug.Log((object) "No need to go through the entire chain. We already know that this character witnessed murder.");
      this.Concern = 5;
    }
    else if (this.YandereVisible)
    {
      bool flag1 = false;
      if ((double) this.Yandere.Bloodiness + (double) this.Yandere.GloveBlood > 0.0 && !this.Yandere.Paint)
        flag1 = true;
      if (this.Yandere.Armed)
        this.Yandere.EquippedWeapon.SuspicionCheck();
      bool flag2 = this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious;
      bool flag3 = (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Yandere.PickUp.Suspicious;
      bool flag4 = (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && (UnityEngine.Object) this.Yandere.PickUp.BodyPart != (UnityEngine.Object) null;
      bool flag5 = (UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence;
      bool flag6 = false;
      if (!this.StudentManager.Eighties && this.StudentID == 48 && this.TaskPhase == 4 && this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 12)
      {
        flag2 = false;
        flag6 = true;
      }
      int concern = this.Concern;
      if (flag2)
        this.WeaponToTakeAway = this.Yandere.EquippedWeapon;
      if (flag2)
        Debug.Log((object) (this.Name + " saw the player carrying a suspicious weapon."));
      if (this.Yandere.Rummaging || (double) this.Yandere.TheftTimer > 0.0)
      {
        Debug.Log((object) "Saw Yandere-chan stealing.");
        this.Witnessed = StudentWitnessType.Theft;
        this.Concern = 5;
      }
      else if (this.Yandere.Pickpocketing || this.Yandere.Caught)
      {
        Debug.Log((object) "Saw Yandere-chan pickpocketing.");
        this.Witnessed = StudentWitnessType.Pickpocketing;
        this.Concern = 5;
        this.Yandere.StudentManager.PickpocketMinigame.Failure = true;
        this.Yandere.StudentManager.PickpocketMinigame.End();
        this.Yandere.Caught = true;
        if (this.Teacher)
          this.Witnessed = StudentWitnessType.Theft;
      }
      else if (flag2 && (double) this.Yandere.Bloodiness > 0.0 && (double) this.Yandere.Sanity < 33.333000183105469)
      {
        Debug.Log((object) "Saw Yandere-chan armed, bloody, and insane.");
        ++this.Police.EndOfDay.WeaponWitnessed;
        ++this.Police.EndOfDay.BloodWitnessed;
        this.Witnessed = StudentWitnessType.WeaponAndBloodAndInsanity;
        this.RepLoss = 30f;
        this.Concern = 5;
      }
      else if (flag2 && (double) this.Yandere.Sanity < 33.333000183105469)
      {
        Debug.Log((object) "Saw Yandere-chan armed and insane.");
        ++this.Police.EndOfDay.WeaponWitnessed;
        this.Witnessed = StudentWitnessType.WeaponAndInsanity;
        this.RepLoss = 20f;
        this.Concern = 5;
      }
      else if (flag1 && (double) this.Yandere.Sanity < 33.333000183105469)
      {
        Debug.Log((object) "Saw Yandere-chan bloody, and insane.");
        ++this.Police.EndOfDay.BloodWitnessed;
        this.Witnessed = StudentWitnessType.BloodAndInsanity;
        this.RepLoss = 20f;
        this.Concern = 5;
      }
      else if (flag2 && (double) this.Yandere.Bloodiness > 0.0)
      {
        Debug.Log((object) "Saw Yandere-chan armed and bloody.");
        ++this.Police.EndOfDay.WeaponWitnessed;
        ++this.Police.EndOfDay.BloodWitnessed;
        this.Witnessed = StudentWitnessType.WeaponAndBlood;
        this.RepLoss = 20f;
        this.Concern = 5;
      }
      else if (flag2)
      {
        Debug.Log((object) "Saw Yandere-chan with a suspicious weapon.");
        ++this.Police.EndOfDay.WeaponWitnessed;
        this.WeaponWitnessed = this.Yandere.EquippedWeapon.WeaponID;
        this.PlayerHeldBloodyWeapon = this.Yandere.EquippedWeapon.Bloody;
        this.Witnessed = StudentWitnessType.Weapon;
        this.RepLoss = 10f;
        this.Concern = 5;
      }
      else if (flag3)
      {
        Debug.Log((object) "Saw Yandere-chan with a suspicious object.");
        this.Witnessed = !this.Yandere.PickUp.CleaningProduct ? (this.Teacher || this.Club == ClubType.Council ? StudentWitnessType.Insanity : StudentWitnessType.Suspicious) : (this.StudentID != 1 ? StudentWitnessType.CleaningItem : StudentWitnessType.Lewd);
        this.RepLoss = 10f;
        this.Concern = 5;
      }
      else if ((double) this.Yandere.Bloodiness > 0.0)
      {
        Debug.Log((object) "Saw Yandere-chan splattered with blood.");
        ++this.Police.EndOfDay.BloodWitnessed;
        this.Witnessed = StudentWitnessType.Blood;
        if (!this.Bloody)
        {
          this.RepLoss = 10f;
          this.Concern = 5;
        }
        else
        {
          this.RepLoss = 0.0f;
          this.Concern = 0;
        }
      }
      else if ((double) this.Yandere.Sanity < 33.333000183105469)
      {
        Debug.Log((object) "Saw Yandere-chan acting insane.");
        this.Witnessed = StudentWitnessType.Insanity;
        this.RepLoss = 10f;
        this.Concern = 5;
      }
      else if (this.Yandere.Lewd)
      {
        Debug.Log((object) "Saw Yandere-chan being lewd.");
        this.Witnessed = StudentWitnessType.Lewd;
        this.RepLoss = 10f;
        this.Concern = 5;
      }
      else if (this.Yandere.Laughing && (double) this.Yandere.LaughIntensity > 15.0 || this.StudentID > 1 && this.Yandere.Stance.Current == StanceType.Crouching || this.Yandere.Stance.Current == StanceType.Crawling || (double) this.Yandere.SuspiciousActionTimer > 0.0 || this.Yandere.WearingRaincoat || this.Yandere.Carrying && this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Dragging && this.Yandere.CurrentRagdoll.Concealed || this.Yandere.Schoolwear == 2 && (double) this.Yandere.transform.position.z < 30.0 || this.AnnoyedByRadio > 1 && (double) this.Yandere.PotentiallyAnnoyingTimer > 0.0)
      {
        if (this.StudentID == 1 && !this.Yandere.Laughing && (double) this.Yandere.Sanity > 33.0)
        {
          Debug.Log((object) "Saw Yandere-chan being lewd.");
          this.Witnessed = StudentWitnessType.Lewd;
        }
        else
        {
          Debug.Log((object) "Saw Yandere-chan acting insane.");
          this.Witnessed = StudentWitnessType.Insanity;
        }
        this.RepLoss = 10f;
        this.Concern = 5;
      }
      else if (this.Yandere.Poisoning)
      {
        Debug.Log((object) "Saw Yandere-chan poisoning a bento.");
        this.Witnessed = StudentWitnessType.Poisoning;
        this.RepLoss = 10f;
        this.Concern = 5;
      }
      else if (this.Yandere.Trespassing && this.StudentID > 1)
      {
        Debug.Log((object) "Saw Yandere-chan trespassing.");
        this.Witnessed = this.Private ? StudentWitnessType.Interruption : StudentWitnessType.Trespassing;
        this.Witness = true;
        if (!this.Teacher)
          this.RepLoss = 10f;
        ++this.Concern;
      }
      else if (this.Yandere.NearSenpai || this.StudentID == 1 && this.Yandere.Stance.Current == StanceType.Crouching)
      {
        if (this.StudentID == 1)
        {
          Debug.Log((object) "Saw Yandere-chan stalking.");
          this.Witnessed = StudentWitnessType.Stalking;
        }
        else
        {
          Debug.Log((object) "Saw Yandere-chan acting insane.");
          this.Witnessed = StudentWitnessType.Insanity;
          this.RepLoss = 10f;
        }
        ++this.Concern;
      }
      else if (this.Yandere.Eavesdropping)
      {
        if (this.StudentID == 1)
        {
          Debug.Log((object) "Saw Yandere-chan stalking.");
          this.Witnessed = StudentWitnessType.Stalking;
          ++this.Concern;
        }
        else
        {
          if (this.InEvent)
            this.EventInterrupted = true;
          Debug.Log((object) "Saw Yandere-chan eavesdropping.");
          this.Witnessed = StudentWitnessType.Eavesdropping;
          this.RepLoss = 10f;
          this.Concern = 5;
        }
      }
      else if (this.Yandere.Aiming)
      {
        Debug.Log((object) "Saw Yandere-chan stalking.");
        this.Witnessed = StudentWitnessType.Stalking;
        ++this.Concern;
      }
      else if (this.Yandere.DelinquentFighting)
      {
        Debug.Log((object) "Saw Yandere-chan fighting a delinquent.");
        this.Witnessed = StudentWitnessType.Violence;
        this.RepLoss = 10f;
        this.Concern = 5;
      }
      else if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence)
      {
        Debug.Log((object) "Saw Yandere-chan with bloody clothing.");
        this.Witnessed = StudentWitnessType.HoldingBloodyClothing;
        this.RepLoss = 10f;
        this.Concern = 5;
      }
      else if (flag4 | flag5)
      {
        Debug.Log((object) "Saw Yandere-chan attempting to cover up a murder.");
        this.Witnessed = StudentWitnessType.CoverUp;
      }
      else if (flag6)
      {
        this.Subtitle.CustomText = "Is that dumbbell for me? Drop it over here!";
        this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
      }
      if ((this.StudentID == 1 || this.Club == ClubType.Council) && this.Witnessed == StudentWitnessType.Insanity && (this.Yandere.Stance.Current == StanceType.Crouching || this.Yandere.Stance.Current == StanceType.Crawling))
      {
        Debug.Log((object) "Saw Yandere-chan stalking.");
        this.Witnessed = StudentWitnessType.Stalking;
        this.Concern = concern;
        ++this.Concern;
      }
    }
    else
    {
      Debug.Log((object) (this.Name + " is reacting to something other than Yandere-chan."));
      if (this.WitnessedLimb)
        this.Witnessed = StudentWitnessType.SeveredLimb;
      else if (this.WitnessedBloodyWeapon)
        this.Witnessed = StudentWitnessType.BloodyWeapon;
      else if (this.WitnessedBloodPool)
        this.Witnessed = StudentWitnessType.BloodPool;
      else if (this.WitnessedWeapon)
        this.Witnessed = StudentWitnessType.DroppedWeapon;
      else if (this.WitnessedCorpse)
      {
        this.Witnessed = StudentWitnessType.Corpse;
      }
      else
      {
        Debug.Log((object) (this.Name + " was alarmed by something, but didn't see what it was..."));
        this.Witnessed = StudentWitnessType.None;
        this.DiscCheck = true;
        this.Witness = false;
      }
    }
    if (this.Concern == 5 && this.Club == ClubType.Council && (UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) null)
    {
      Debug.Log((object) "A member of the student council is being transformed into a teacher.");
      this.Teacher = true;
    }
    if (this.StudentID <= 1 || this.Witnessed == StudentWitnessType.None)
      return;
    this.SetOutlinesYellow();
  }

  public void DetermineTeacherSubtitle()
  {
    Debug.Log((object) "We are now determining what line of dialogue the teacher should say.");
    if (this.Club == ClubType.Council)
    {
      this.Subtitle.UpdateLabel(SubtitleType.CouncilToCounselor, this.ClubMemberID, 5f);
    }
    else
    {
      if (this.Guarding && this.YandereVisible)
      {
        Debug.Log((object) "Teacher reached this code while guarding and able to see Yandere-chan.");
        if ((double) this.Yandere.Bloodiness + (double) this.Yandere.GloveBlood > 0.0 && !this.Yandere.Paint)
          this.Witnessed = StudentWitnessType.Blood;
        else if (this.Yandere.Armed)
          this.Witnessed = StudentWitnessType.Weapon;
        else if ((double) this.Yandere.Sanity < 66.666656494140625 || this.Yandere.WearingRaincoat)
          this.Witnessed = StudentWitnessType.Insanity;
      }
      if (this.Witnessed == StudentWitnessType.Murder)
      {
        if (this.WitnessedMindBrokenMurder)
          this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 4, 6f);
        else
          this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 1, 6f);
        this.GameOverCause = GameOverType.Murder;
        this.WitnessedMurder = true;
      }
      else if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
      {
        this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
        this.GameOverCause = GameOverType.Insanity;
        this.WitnessedMurder = true;
      }
      else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
      {
        this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
        this.GameOverCause = GameOverType.Weapon;
        this.WitnessedMurder = true;
      }
      else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
      {
        this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
        this.GameOverCause = GameOverType.Insanity;
        this.WitnessedMurder = true;
      }
      else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
      {
        this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
        this.GameOverCause = GameOverType.Insanity;
        this.WitnessedMurder = true;
      }
      else if (this.Witnessed == StudentWitnessType.Weapon)
      {
        this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
        this.GameOverCause = GameOverType.Weapon;
        this.WitnessedMurder = true;
      }
      else if (this.Witnessed == StudentWitnessType.Blood)
      {
        this.Subtitle.UpdateLabel(SubtitleType.TeacherBloodHostile, 1, 6f);
        this.GameOverCause = GameOverType.Blood;
        this.WitnessedMurder = true;
      }
      else if (this.Witnessed == StudentWitnessType.Insanity || this.Witnessed == StudentWitnessType.Poisoning)
      {
        this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
        this.GameOverCause = GameOverType.Insanity;
        this.WitnessedMurder = true;
      }
      else if (this.Witnessed == StudentWitnessType.Lewd)
      {
        this.Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
        this.GameOverCause = GameOverType.Lewd;
      }
      else if (this.Witnessed == StudentWitnessType.Trespassing)
        this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, this.Concern, 5f);
      else if (this.Witnessed == StudentWitnessType.Corpse)
      {
        Debug.Log((object) "A teacher just discovered a corpse.");
        this.DetermineCorpseLocation();
        this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
        this.Police.Called = true;
      }
      else if (this.Witnessed == StudentWitnessType.CoverUp)
      {
        this.Subtitle.UpdateLabel(SubtitleType.TeacherCoverUpHostile, 1, 6f);
        this.GameOverCause = GameOverType.Blood;
        this.WitnessedMurder = true;
      }
      else
      {
        if (this.Witnessed != StudentWitnessType.CleaningItem)
          return;
        this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
        this.GameOverCause = GameOverType.Insanity;
      }
    }
  }

  public void ReturnMisplacedWeapon()
  {
    Debug.Log((object) (this.Name + " has returned a misplaced weapon."));
    this.StopInvestigating();
    if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this)
      this.StudentManager.BloodReporter = (StudentScript) null;
    this.BloodPool.parent = (Transform) null;
    this.BloodPool.position = this.BloodPool.GetComponent<WeaponScript>().StartingPosition;
    this.BloodPool.eulerAngles = this.BloodPool.GetComponent<WeaponScript>().StartingRotation;
    this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = true;
    this.BloodPool.GetComponent<WeaponScript>().enabled = true;
    this.BloodPool.GetComponent<WeaponScript>().Drop();
    this.BloodPool.GetComponent<WeaponScript>().MyRigidbody.useGravity = false;
    this.BloodPool.GetComponent<WeaponScript>().MyRigidbody.isKinematic = true;
    this.BloodPool.GetComponent<WeaponScript>().Returner = (StudentScript) null;
    this.BloodPool = (Transform) null;
    this.CurrentDestination = this.Destinations[this.Phase];
    this.Pathfinding.target = this.Destinations[this.Phase];
    if (this.CurrentAction == StudentActionType.Sunbathe && this.SunbathePhase > 1)
    {
      Debug.Log((object) (this.Name + " was sunbathing at the time."));
      this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
      this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
    }
    if (this.ResumeFollowingAfter)
      this.ResumeFollowing();
    if (this.Club == ClubType.Council || this.Teacher)
      this.Handkerchief.SetActive(false);
    this.Pathfinding.speed = this.WalkSpeed;
    this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.ReturningMisplacedWeapon = false;
    this.WitnessedSomething = false;
    this.VerballyReacted = false;
    this.WitnessedWeapon = false;
    this.YandereInnocent = false;
    this.ReportingBlood = false;
    this.Distracted = false;
    this.Routine = true;
    this.ReturningMisplacedWeaponPhase = 0;
    this.WitnessCooldownTimer = 0.0f;
    this.Yandere.WeaponManager.ReturnWeaponID = -1;
    this.Yandere.WeaponManager.ReturnStudentID = -1;
    if (this.BeforeReturnAnim == "")
      this.BeforeReturnAnim = this.OriginalWalkAnim;
    this.WalkAnim = this.BeforeReturnAnim;
    this.Hurry = this.WasHurrying;
    Debug.Log((object) (this.Name + "'s WalkAnim is now: " + this.WalkAnim));
    if (!this.Sleuthing)
      return;
    Debug.Log((object) "The character who just returned a misplaced item was ''Sleuthing'' before they did, so they are using special logic...");
    if ((UnityEngine.Object) this.SleuthTarget != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.SleuthTarget.GetComponent<StudentScript>() == (UnityEngine.Object) null)
      {
        Debug.Log((object) "SleuthTarget was not a student!");
        this.GetSleuthTarget();
      }
      else
      {
        Debug.Log((object) "SleuthTarget was a student!");
        this.CurrentDestination = this.SleuthTarget.transform;
        this.Pathfinding.target = this.SleuthTarget.transform;
      }
    }
    else
    {
      Debug.Log((object) "SleuthTarget was null!");
      this.GetSleuthTarget();
    }
  }

  public void StopMusic()
  {
    if (this.StudentID == 51)
    {
      if ((UnityEngine.Object) this.InstrumentBag[this.ClubMemberID].transform.parent == (UnityEngine.Object) null)
      {
        this.Instruments[this.ClubMemberID].transform.parent = (Transform) null;
        if (!this.StudentManager.Eighties)
        {
          this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
          this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0.0f, 0.0f);
        }
        else
        {
          this.Instruments[this.ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
          this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0.0f);
        }
        this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
        this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
      }
      else
        this.Instruments[this.ClubMemberID].SetActive(false);
    }
    else
      this.Instruments[this.ClubMemberID].SetActive(false);
    this.Drumsticks[0].SetActive(false);
    this.Drumsticks[1].SetActive(false);
  }

  public void DropPuzzle()
  {
    this.PuzzleCube.enabled = true;
    this.PuzzleCube.Drop();
    this.SolvingPuzzle = false;
    this.Distracted = false;
    this.PuzzleTimer = 0.0f;
  }

  public void ReturnToNormal()
  {
    Debug.Log((object) (this.Name + " has been instructed to forget everything and return to normal."));
    if ((UnityEngine.Object) this.StudentManager.Reporter == (UnityEngine.Object) this)
    {
      this.StudentManager.CorpseLocation.position = Vector3.zero;
      this.StudentManager.Reporter = (StudentScript) null;
    }
    else if ((UnityEngine.Object) this.StudentManager.BloodReporter == (UnityEngine.Object) this)
    {
      this.StudentManager.BloodLocation.position = Vector3.zero;
      this.StudentManager.BloodReporter = (StudentScript) null;
    }
    if ((UnityEngine.Object) this.Yandere.Pursuer == (UnityEngine.Object) this)
    {
      this.Yandere.Pursuer = (StudentScript) null;
      this.Yandere.PreparedForStruggle = false;
    }
    this.StudentManager.UpdateStudents();
    this.CurrentDestination = this.Destinations[this.Phase];
    this.Pathfinding.target = this.Destinations[this.Phase];
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.Pathfinding.speed = this.WalkSpeed;
    this.TargetDistance = 1f;
    this.ReportPhase = 0;
    this.ReportTimer = 0.0f;
    this.AlarmTimer = 0.0f;
    this.AmnesiaTimer = 10f;
    if (this.Actions[this.Phase] != StudentActionType.ClubAction || this.Club != ClubType.Cooking || this.ClubActivityPhase <= 0)
    {
      this.RandomAnim = this.BulliedIdleAnim;
      this.IdleAnim = this.BulliedIdleAnim;
      this.WalkAnim = this.BulliedWalkAnim;
    }
    if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
      this.Persona = this.OriginalPersona;
    this.BloodPool = (Transform) null;
    this.WitnessedBloodyWeapon = false;
    this.WitnessedBloodPool = false;
    this.WitnessedSomething = false;
    this.WitnessedCorpse = false;
    this.WitnessedMurder = false;
    this.WitnessedWeapon = false;
    this.WitnessedLimb = false;
    this.SmartPhone.SetActive(false);
    this.LostTeacherTrust = true;
    this.ReportingMurder = false;
    this.ReportingBlood = false;
    this.PinDownWitness = false;
    this.Distracted = false;
    this.Reacted = false;
    this.Alarmed = false;
    this.Fleeing = false;
    this.Routine = true;
    this.Halt = false;
    if (this.Club == ClubType.Council)
      this.Persona = PersonaType.Dangerous;
    for (this.ID = 0; this.ID < this.Outlines.Length; ++this.ID)
    {
      if ((UnityEngine.Object) this.Outlines[this.ID] != (UnityEngine.Object) null)
        this.Outlines[this.ID].color = new Color(1f, 1f, 0.0f, 1f);
    }
  }

  public void ForgetAboutBloodPool()
  {
    Debug.Log((object) (this.Name + " was told to ForgetAboutBloodPool()"));
    this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
    if (this.Club == ClubType.Cooking && this.CurrentAction == StudentActionType.ClubAction && (UnityEngine.Object) this.MyPlate != (UnityEngine.Object) null && (UnityEngine.Object) this.MyPlate.parent == (UnityEngine.Object) this.RightHand)
    {
      this.GetFoodTarget();
    }
    else
    {
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.Destinations[this.Phase];
    }
    this.InvestigatingBloodPool = false;
    this.WitnessedBloodyWeapon = false;
    this.WitnessedBloodPool = false;
    this.WitnessedSomething = false;
    this.WitnessedWeapon = false;
    this.Distracted = false;
    if (!this.Shoving)
      this.Routine = true;
    this.WitnessCooldownTimer = 5f;
    if ((UnityEngine.Object) this.BloodPool != (UnityEngine.Object) null && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition) && (UnityEngine.Object) this.BloodPool.parent == (UnityEngine.Object) this.Yandere.RightHand)
    {
      this.YandereVisible = true;
      this.ReportTimer = 0.0f;
      this.ReportPhase = 0;
      this.Alarmed = false;
      this.Fleeing = false;
      this.Reacted = false;
      if ((UnityEngine.Object) this.BloodPool.GetComponent<WeaponScript>() != (UnityEngine.Object) null && this.BloodPool.GetComponent<WeaponScript>().Suspicious)
      {
        Debug.Log((object) (this.Name + " is about to call the BecomeAlarmed() function from the ForgetAboutBloodPool() function."));
        this.WitnessCooldownTimer = 5f;
        this.AlarmTimer = 0.0f;
        this.Alarm = 200f;
        this.BecomeAlarmed();
      }
    }
    if (this.BeforeReturnAnim != "")
      this.WalkAnim = this.BeforeReturnAnim;
    this.BloodPool = (Transform) null;
    if ((UnityEngine.Object) this.Giggle != (UnityEngine.Object) null)
      this.ForgetGiggle();
    if (this.ReturningMisplacedWeapon || this.Club != ClubType.Sports || this.CurrentAction != StudentActionType.ClubAction || this.ClubActivityPhase <= 2 || this.ClubActivityPhase >= 14)
      return;
    Debug.Log((object) "Student was jogging before they started investigating, and will now return to jogging.");
    this.Jog();
  }

  private void SimpleForgetAboutBloodPool()
  {
    this.InvestigatingBloodPool = false;
    this.WitnessedBloodyWeapon = false;
    this.WitnessedBloodPool = false;
    this.WitnessedSomething = false;
    this.WitnessedWeapon = false;
    this.Distracted = false;
  }

  private void SummonWitnessCamera()
  {
    this.WitnessCamera.transform.parent = this.WitnessPOV;
    this.WitnessCamera.transform.localPosition = Vector3.zero;
    this.WitnessCamera.transform.localEulerAngles = Vector3.zero;
    this.WitnessCamera.MyCamera.enabled = true;
    this.WitnessCamera.Show = true;
  }

  public void SilentlyForgetBloodPool()
  {
    Debug.Log((object) (this.Name + " was told to SilentlyForgetBloodPool()"));
    this.InvestigatingBloodPool = false;
    this.WitnessedBloodyWeapon = false;
    this.WitnessedBloodPool = false;
    this.WitnessedSomething = false;
    this.WitnessedWeapon = false;
  }

  private void CheckForEndRaibaruEvent()
  {
    if (!((UnityEngine.Object) this.StudentManager.Students[46] == (UnityEngine.Object) null) && this.StudentManager.Students[46].Phase <= this.Phase)
      return;
    Debug.Log((object) "Raibaru has just finished mentoring the Martial Arts Club.");
    if ((UnityEngine.Object) this.FollowTarget != (UnityEngine.Object) null)
    {
      if (this.FollowTarget.Alive)
      {
        this.Destinations[this.Phase] = this.FollowTarget.transform;
        this.Pathfinding.target = this.FollowTarget.transform;
        this.CurrentDestination = this.FollowTarget.transform;
      }
      else
      {
        this.Destinations[this.Phase] = this.StudentManager.LastKnownOsana;
        this.Pathfinding.target = this.StudentManager.LastKnownOsana;
        this.CurrentDestination = this.StudentManager.LastKnownOsana;
      }
      this.FollowTarget.Follower = this;
      this.Actions[this.Phase] = StudentActionType.Follow;
      this.CurrentAction = StudentActionType.Follow;
    }
    else
    {
      this.Destinations[this.Phase] = this.StudentManager.MournSpots[this.StudentID];
      this.Pathfinding.target = this.StudentManager.MournSpots[this.StudentID];
      this.CurrentDestination = this.StudentManager.MournSpots[this.StudentID];
      this.Actions[this.Phase] = StudentActionType.Mourn;
      this.CurrentAction = StudentActionType.Mourn;
    }
    this.SpeechLines.Stop();
    this.InEvent = false;
    this.NoMentor = true;
    this.Routine = true;
  }

  private void RaibaruOsanaDeathScheduleChanges()
  {
    ScheduleBlock scheduleBlock1 = this.ScheduleBlocks[1];
    scheduleBlock1.destination = "Mourn";
    scheduleBlock1.action = "Mourn";
    ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[2];
    scheduleBlock2.destination = "Mourn";
    scheduleBlock2.action = "Mourn";
    ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[4];
    scheduleBlock3.destination = "LunchSpot";
    scheduleBlock3.action = "Eat";
    this.Persona = PersonaType.Heroic;
    this.IdleAnim = this.BulliedIdleAnim;
    this.WalkAnim = this.BulliedWalkAnim;
    this.OriginalIdleAnim = this.IdleAnim;
  }

  private void RaibaruStopsFollowingOsana()
  {
    ScheduleBlock scheduleBlock1 = this.ScheduleBlocks[3];
    scheduleBlock1.destination = "Seat";
    scheduleBlock1.action = "Sit";
    ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[5];
    scheduleBlock2.destination = "Seat";
    scheduleBlock2.action = "Sit";
    ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[6];
    scheduleBlock3.destination = "Locker";
    scheduleBlock3.action = "Shoes";
    ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[7];
    scheduleBlock4.destination = "Exit";
    scheduleBlock4.action = "Exit";
    ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[8];
    scheduleBlock5.destination = "Exit";
    scheduleBlock5.action = "Exit";
    ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[9];
    scheduleBlock6.destination = "Exit";
    scheduleBlock6.action = "Exit";
    this.FollowTarget = (StudentScript) null;
  }

  private void StopFollowingGravureModel()
  {
    ScheduleBlock scheduleBlock1 = this.ScheduleBlocks[2];
    scheduleBlock1.destination = "Seat";
    scheduleBlock1.action = "Sit";
    ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
    scheduleBlock2.destination = "LunchSpot";
    scheduleBlock2.action = "Eat";
    ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[6];
    scheduleBlock3.destination = "Locker";
    scheduleBlock3.action = "Locker";
    ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[7];
    scheduleBlock4.destination = "Exit";
    scheduleBlock4.action = "Exit";
  }

  public void StopDrinking()
  {
    this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.DrinkingFountain.Occupied = false;
    this.EquipCleaningItems();
    this.EatingSnack = false;
    this.Private = false;
    this.Routine = true;
    this.StudentManager.UpdateMe(this.StudentID);
  }

  public void GoToClass()
  {
    ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
    scheduleBlock.destination = "Seat";
    scheduleBlock.action = "SitAndTakeNotes";
    this.Actions[this.Phase] = StudentActionType.SitAndTakeNotes;
    this.CurrentAction = StudentActionType.SitAndTakeNotes;
    this.GetDestinations();
    this.CurrentDestination = this.Destinations[this.Phase];
    this.Pathfinding.target = this.Destinations[this.Phase];
  }

  public void RaibaruCannotFindOsana()
  {
    this.SpeechLines.Stop();
    this.CharacterAnimation.CrossFade(this.ParanoidAnim);
    this.SnackTimer += Time.deltaTime;
    if ((double) this.SnackTimer <= 5.0)
      return;
    this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 5, 10f);
    this.RaibaruOsanaDeathScheduleChanges();
    this.RaibaruStopsFollowingOsana();
    this.GetDestinations();
    this.CurrentDestination = this.Destinations[this.Phase];
    this.Pathfinding.target = this.Destinations[this.Phase];
    this.SnackTimer = 0.0f;
  }

  public void CannotFindInfatuationTarget()
  {
    Debug.Log((object) "A student cannot find the student they are supposed to be following.");
    this.CharacterAnimation.CrossFade(this.ParanoidAnim);
    this.SnackTimer += Time.deltaTime;
    if ((double) this.SnackTimer <= 5.0)
      return;
    Debug.Log((object) "The student has decided to give up on following the gravure model.");
    this.StopFollowingGravureModel();
    this.GetDestinations();
    this.CurrentDestination = this.Destinations[this.Phase];
    this.Pathfinding.target = this.Destinations[this.Phase];
    this.SnackTimer = 0.0f;
  }

  public void DisableProps()
  {
    this.RandomCheerAnim = this.CheerAnims[UnityEngine.Random.Range(0, this.CheerAnims.Length)];
    this.HealthBar.transform.parent.gameObject.SetActive(false);
    this.FollowCountdown.gameObject.SetActive(false);
    this.VomitEmitter.gameObject.SetActive(false);
    this.ChaseCamera.gameObject.SetActive(false);
    this.Countdown.gameObject.SetActive(false);
    this.MiyukiGameScreen.SetActive(false);
    this.Chopsticks[0].SetActive(false);
    this.Chopsticks[1].SetActive(false);
    this.Handkerchief.SetActive(false);
    this.PepperSpray.SetActive(false);
    this.RetroCamera.SetActive(false);
    this.Sketchbook.SetActive(false);
    this.OccultBook.SetActive(false);
    this.Paintbrush.SetActive(false);
    this.EventBook.SetActive(false);
    this.Handcuffs.SetActive(false);
    this.WeaponBag.SetActive(false);
    this.Scrubber.SetActive(false);
    this.Armband.SetActive(false);
    this.Octodog.SetActive(false);
    this.Palette.SetActive(false);
    this.Eraser.SetActive(false);
    this.Pencil.SetActive(false);
    this.Bento.SetActive(false);
    this.Pen.SetActive(false);
    this.SpeechLines.Stop();
    if ((UnityEngine.Object) this.SmartPhone.transform.parent != (UnityEngine.Object) null)
      this.SmartPhone.SetActive(false);
    foreach (GameObject scienceProp in this.ScienceProps)
    {
      if ((UnityEngine.Object) scienceProp != (UnityEngine.Object) null)
        scienceProp.SetActive(false);
    }
    foreach (GameObject gameObject in this.Fingerfood)
    {
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        gameObject.SetActive(false);
    }
  }

  public void DisableFemaleProps()
  {
    this.SkirtOrigins[0] = this.Skirt[0].transform.localPosition;
    this.SkirtOrigins[1] = this.Skirt[1].transform.localPosition;
    this.SkirtOrigins[2] = this.Skirt[2].transform.localPosition;
    this.SkirtOrigins[3] = this.Skirt[3].transform.localPosition;
    this.InstrumentBag[1].SetActive(false);
    this.InstrumentBag[2].SetActive(false);
    this.InstrumentBag[3].SetActive(false);
    this.InstrumentBag[4].SetActive(false);
    this.InstrumentBag[5].SetActive(false);
    this.PickRandomGossipAnim();
    this.DramaticCamera.gameObject.SetActive(false);
    this.MapMarker.gameObject.SetActive(false);
    this.EightiesPhone.SetActive(false);
    this.AnimatedBook.SetActive(false);
    this.Handkerchief.SetActive(false);
    this.WateringCan.SetActive(false);
    this.Sketchbook.SetActive(false);
    this.Cigarette.SetActive(false);
    this.CandyBar.SetActive(false);
    this.Lighter.SetActive(false);
    foreach (GameObject instrument in this.Instruments)
    {
      if ((UnityEngine.Object) instrument != (UnityEngine.Object) null)
        instrument.SetActive(false);
    }
    this.Drumsticks[0].SetActive(false);
    this.Drumsticks[1].SetActive(false);
    if (this.Club >= ClubType.Teacher)
      this.BecomeTeacher();
    if (GameGlobals.CensorPanties && !this.Teacher)
      this.Cosmetic.CensorPanties();
    this.DisableEffects();
  }

  public void DisableMaleProps()
  {
    this.MapMarker.gameObject.SetActive(false);
    this.DelinquentSpeechLines.Stop();
    this.PinkSeifuku.SetActive(false);
    this.Earpiece.SetActive(false);
    foreach (Component liquidEmitter in this.LiquidEmitters)
      liquidEmitter.gameObject.SetActive(false);
  }

  public void TriggerBeatEmUpMinigame()
  {
    GameGlobals.BeatEmUpDifficulty = 1;
    SceneManager.LoadScene("BeatEmUpScene", LoadSceneMode.Additive);
    foreach (GameObject rootGameObject in SceneManager.GetActiveScene().GetRootGameObjects())
      rootGameObject.SetActive(false);
  }

  public void PlaceBag()
  {
    Debug.Log((object) (this.Name + " just put her bookbag on her desk."));
    if ((double) this.Seat.position.x < 0.0)
    {
      this.StudentManager.RivalBookBag.transform.position = this.Seat.position + new Vector3(-0.33333f, 0.342f, 0.3585f);
      this.StudentManager.RivalBookBag.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }
    else
    {
      this.StudentManager.RivalBookBag.transform.position = this.Seat.position + new Vector3(0.33333f, 0.342f, -0.3585f);
      this.StudentManager.RivalBookBag.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
    }
    this.StudentManager.RivalBookBag.CorrectPosition = this.StudentManager.RivalBookBag.transform.position;
    this.StudentManager.RivalBookBag.CorrectRotation = this.StudentManager.RivalBookBag.transform.eulerAngles;
    this.StudentManager.RivalBookBag.gameObject.SetActive(true);
    this.StudentManager.RivalBookBag.Prompt.enabled = true;
    this.StudentManager.RivalBookBag.Rival = this;
    this.BookBag.SetActive(false);
    if (this.GiftBox)
    {
      this.StudentManager.WednesdayGiftBox.SetActive(true);
      this.StudentManager.WednesdayGiftBox.transform.position = (double) this.transform.position.x >= 0.0 ? this.Seat.position + new Vector3(0.4f, 1.02f, 0.0f) : this.Seat.position + new Vector3(-0.4f, 1.02f, 0.0f);
      this.GiftBox = false;
    }
    this.BagPlaced = true;
    if (this.VisitSenpaiDesk)
    {
      if ((UnityEngine.Object) this.CurrentDestination == (UnityEngine.Object) this.StudentManager.Students[1].Seat)
      {
        this.StudentManager.FridayTestNotes.SetActive(true);
        this.VisitSenpaiDesk = false;
      }
      this.Destinations[this.Phase] = this.StudentManager.Students[1].Seat;
      this.CurrentDestination = this.StudentManager.Students[1].Seat;
      this.Pathfinding.target = this.StudentManager.Students[1].Seat;
    }
    else
    {
      if (this.Bullied)
      {
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        scheduleBlock.destination = "ShameSpot";
        scheduleBlock.action = "Shamed";
        scheduleBlock.time = 8f;
      }
      else if (this.StudentID == 11 || this.StudentID == 12)
      {
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        scheduleBlock.destination = "Hangout";
        scheduleBlock.action = "Socialize";
      }
      else if (this.StudentID == 13)
      {
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        scheduleBlock.destination = "Patrol";
        scheduleBlock.action = "Patrol";
      }
      else if (this.StudentID == 14)
      {
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        scheduleBlock.destination = "Sunbathe";
        scheduleBlock.action = "Jog";
      }
      else if (this.StudentID == 15)
      {
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        scheduleBlock.destination = "Sunbathe";
        scheduleBlock.action = "Sunbathe";
      }
      else if (this.StudentID == 16)
      {
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        scheduleBlock.destination = "Perform";
        scheduleBlock.action = "Perform";
      }
      else if (this.StudentID == 17)
      {
        Debug.Log((object) "Prodigy rival is building their schedule from here.");
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        scheduleBlock.destination = "Hangout";
        scheduleBlock.action = "HelpTeacher";
      }
      else if (this.StudentID == 18)
      {
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        scheduleBlock.destination = "Patrol";
        scheduleBlock.action = "Patrol";
      }
      else if (this.StudentID == 19)
      {
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        if ((double) SchoolGlobals.SchoolAtmosphere > 0.800000011920929 && this.StudentManager.Photographers > 0)
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
      else if (this.StudentID == 20)
      {
        ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
        scheduleBlock.destination = "Guard";
        scheduleBlock.action = "Guard";
        this.TargetDistance = 1f;
      }
      this.GetDestinations();
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.Destinations[this.Phase];
      this.CurrentAction = this.Actions[this.Phase];
    }
  }

  public void BecomeSleuth()
  {
    Debug.Log((object) "BecomeSleuth() was called.");
    if (this.Club != ClubType.Newspaper && this.Club != ClubType.Photography)
    {
      int club = (int) this.Club;
    }
    if (this.StudentManager.Eighties)
    {
      this.CameraFlash = this.RetroCameraFlash;
      this.SmartPhone = this.RetroCamera;
    }
    this.Indoors = true;
    this.Spawned = true;
    if ((UnityEngine.Object) this.ShoeRemoval.Locker == (UnityEngine.Object) null)
      this.ShoeRemoval.Start();
    this.ShoeRemoval.PutOnShoes();
    if (this.StudentID != 20)
    {
      this.SprintAnim = this.SleuthSprintAnim;
      this.IdleAnim = this.SleuthIdleAnim;
      this.WalkAnim = this.SleuthWalkAnim;
    }
    this.CameraAnims = this.HeroAnims;
    this.SmartPhone.SetActive(true);
    this.Countdown.Speed = 0.075f;
    this.Sleuthing = true;
    this.SmartPhone.transform.localPosition = !this.Male ? new Vector3(0.033333f, -0.015f, -0.015f) : new Vector3(0.06f, -0.02f, -0.02f);
    if (!this.StudentManager.Eighties)
    {
      this.SmartPhone.transform.localEulerAngles = new Vector3(12.5f, 120f, 180f);
    }
    else
    {
      if (this.Male)
      {
        this.SmartPhone.transform.localEulerAngles = new Vector3(22.5f, 22.5f, 150f);
      }
      else
      {
        this.SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.066666f, -0.01f);
        this.SmartPhone.transform.localEulerAngles = new Vector3(15f, 15f, 105f);
      }
      this.Phoneless = false;
    }
    if (this.StudentID != 20 && this.StudentID != 36)
    {
      if (this.Club == ClubType.None || this.Club == ClubType.Newspaper)
      {
        this.StudentManager.SleuthPhase = 3;
        this.SleuthID = this.StudentID;
        this.GetSleuthTarget();
      }
      else
        this.SleuthTarget = this.StudentManager.Clubs.List[this.StudentID];
      if (!this.Grudge)
      {
        ScheduleBlock scheduleBlock1 = this.ScheduleBlocks[2];
        scheduleBlock1.destination = "Sleuth";
        scheduleBlock1.action = "Sleuth";
        if (!this.StudentManager.MissionMode)
        {
          ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
          scheduleBlock2.destination = "Sleuth";
          scheduleBlock2.action = "Sleuth";
        }
        ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[7];
        scheduleBlock3.destination = "Sleuth";
        scheduleBlock3.action = "Sleuth";
      }
      else
      {
        this.StalkTarget = this.Yandere.transform;
        this.SleuthTarget = this.Yandere.transform;
        ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[2];
        scheduleBlock4.destination = "Stalk";
        scheduleBlock4.action = "Stalk";
        ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[4];
        scheduleBlock5.destination = "Stalk";
        scheduleBlock5.action = "Stalk";
        ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[7];
        scheduleBlock6.destination = "Stalk";
        scheduleBlock6.action = "Stalk";
      }
    }
    if (this.SleuthID >= 1)
      return;
    this.SleuthID = 1;
  }

  public void CheckForBento()
  {
    if (!this.Bento.activeInHierarchy || this.StudentID <= 1 || !((UnityEngine.Object) this.Bento.transform.parent != (UnityEngine.Object) null))
      return;
    GenericBentoScript component = this.Bento.GetComponent<GenericBentoScript>();
    component.enabled = true;
    component.Prompt.enabled = true;
    this.Bento.SetActive(true);
    this.Bento.transform.parent = this.transform;
    this.Bento.transform.localPosition = !this.Male ? new Vector3(0.0f, 0.461f, -0.075f) : new Vector3(0.0f, 0.4266666f, -0.075f);
    this.Bento.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.Bento.transform.parent = (Transform) null;
  }

  public void BlendIntoSittingAnim()
  {
    if ((double) this.CharacterAnimation[this.SocialSitAnim].weight == 1.0)
      return;
    this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 1f, Time.deltaTime * 10f);
    if ((double) this.CharacterAnimation[this.SocialSitAnim].weight <= 0.99)
      return;
    this.CharacterAnimation[this.SocialSitAnim].weight = 1f;
  }

  public void BlendOutOfSittingAnim()
  {
    if ((double) this.CharacterAnimation[this.SocialSitAnim].weight == 0.0)
      return;
    this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 0.0f, Time.deltaTime * 10f);
    if ((double) this.CharacterAnimation[this.SocialSitAnim].weight >= 0.01)
      return;
    this.CharacterAnimation[this.SocialSitAnim].weight = 0.0f;
  }

  public void Oversleep()
  {
    if (this.StudentID == 15 || this.ScheduleBlocks.Length != 10)
      return;
    Debug.Log((object) ("Giving " + this.Name + " the ''Oversleep'' routine."));
    ScheduleBlock scheduleBlock1 = this.ScheduleBlocks[6];
    scheduleBlock1.destination = "SleepSpot";
    scheduleBlock1.action = "Sleep";
    scheduleBlock1.time = 99999f;
    ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[7];
    scheduleBlock2.destination = "SleepSpot";
    scheduleBlock2.action = "Sleep";
    scheduleBlock2.time = 99999f;
    ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[8];
    scheduleBlock3.destination = "SleepSpot";
    scheduleBlock3.action = "Sleep";
    scheduleBlock3.time = 99999f;
    ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[9];
    scheduleBlock4.destination = "SleepSpot";
    scheduleBlock4.action = "Sleep";
    scheduleBlock4.time = 99999f;
  }

  public void UpdateGemaAppearance()
  {
    this.Cosmetic.FacialHairstyle = 0;
    this.Cosmetic.EyewearID = 9;
    this.Cosmetic.Hairstyle = 49;
    this.Cosmetic.Accessory = 0;
    this.Cosmetic.Start();
    this.OriginalIdleAnim = "properIdle_00";
    this.IdleAnim = "properIdle_00";
    this.OriginalOriginalWalkAnim = "properWalk_00";
    this.OriginalWalkAnim = "properWalk_00";
    this.WalkAnim = "properWalk_00";
    this.ClubAnim = "properGaming_00";
    ScheduleBlock scheduleBlock1 = this.ScheduleBlocks[2];
    scheduleBlock1.destination = "Club";
    scheduleBlock1.action = "Club";
    this.GetDestinations();
    this.CurrentDestination = this.Destinations[this.Phase];
    this.Pathfinding.target = this.Destinations[this.Phase];
    this.StudentManager.ReactedToGameLeader = true;
    for (int index = 1; index < 6; ++index)
    {
      ScheduleBlock scheduleBlock2 = this.StudentManager.Students[80 + index].ScheduleBlocks[4];
      scheduleBlock2.destination = "Shock";
      scheduleBlock2.action = "Shock";
      this.StudentManager.Students[80 + index].GetDestinations();
    }
  }

  public void FinishPyro()
  {
    this.StudentManager.PyroFlames.Stop();
    this.StudentManager.PyroFlameSounds[1].Stop();
    this.StudentManager.PyroFlameSounds[2].Stop();
    ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
    scheduleBlock.destination = "Hangout";
    scheduleBlock.action = "Socialize";
    this.GetDestinations();
    this.Pathfinding.target = this.Destinations[this.Phase];
    this.CurrentDestination = this.Destinations[this.Phase];
    this.PyroPhase = 1;
    this.PyroTimer = 0.0f;
  }

  public int OnlyDefault => 1;

  private void CheckForWallBehind()
  {
    Debug.Log((object) "Checking for a wall behind this student.");
    this.RaycastOrigin = this.Hips;
    if (!Physics.Raycast(this.RaycastOrigin.position, this.RaycastOrigin.TransformDirection(this.transform.worldToLocalMatrix.MultiplyVector(this.transform.forward) * -1f), out this.hit, 2f, this.OnlyDefault))
      return;
    Debug.Log((object) "Yeah, hit a wall behind.");
    this.TooCloseToWall = true;
  }

  private void CheckForWallInFront(float Distance)
  {
    this.RaycastOrigin = this.Hips;
    if (!Physics.Raycast(this.RaycastOrigin.position, this.RaycastOrigin.TransformDirection(this.transform.worldToLocalMatrix.MultiplyVector(this.transform.forward)), out this.hit, Distance, this.OnlyDefault))
      return;
    this.TooCloseToWall = true;
  }

  public void CheckForWallToLeft()
  {
    Debug.Log((object) "Checking for a wall to the left of this character.");
    this.RaycastOriginVector = this.transform.position + Vector3.up;
    Vector3 right = this.transform.right;
    Debug.DrawRay(this.RaycastOriginVector, right, Color.red);
    if (!Physics.Raycast(this.RaycastOriginVector, right, out this.hit, 2f, this.OnlyDefault))
      return;
    Debug.Log((object) "Yeah, hit a wall to the left.");
    this.TooCloseToWall = true;
  }

  public void CheckForWallToRight()
  {
    Debug.Log((object) "Checking for a wall to the right of this character.");
    this.RaycastOriginVector = this.transform.position + Vector3.up;
    Vector3 vector3 = this.transform.right * -1f;
    Debug.DrawRay(this.RaycastOriginVector, vector3, Color.red);
    if (!Physics.Raycast(this.RaycastOriginVector, vector3, out this.hit, 2.5f, this.OnlyDefault))
      return;
    Debug.Log((object) "Yeah, hit a wall to the right.");
    this.TooCloseToWall = true;
  }

  public void ResumeFollowing()
  {
    ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
    scheduleBlock.destination = "Follow";
    scheduleBlock.action = "Follow";
    this.GetDestinations();
    this.Pathfinding.target = this.FollowTarget.transform;
    this.CurrentDestination = this.FollowTarget.transform;
    this.ResumeFollowingAfter = false;
    this.CanTalk = true;
    Debug.Log((object) "Raibaru was told to resume ''Follow'' protocol.");
  }

  public void SetOriginalScheduleBlocks()
  {
    this.OriginalTimes = new float[this.ScheduleBlocks.Length];
    this.OriginalDests = new string[this.ScheduleBlocks.Length];
    this.OriginalActs = new string[this.ScheduleBlocks.Length];
    for (int index = 0; index < this.ScheduleBlocks.Length; ++index)
    {
      this.OriginalTimes[index] = this.ScheduleBlocks[index].time;
      this.OriginalDests[index] = this.ScheduleBlocks[index].destination;
      this.OriginalActs[index] = this.ScheduleBlocks[index].action;
    }
  }

  public void SetOriginalActions()
  {
    for (int index = 0; index < this.Actions.Length; ++index)
      this.OriginalActions[index] = this.Actions[index];
  }

  public void RestoreOriginalScheduleBlocks()
  {
    for (int index = 0; index < this.ScheduleBlocks.Length; ++index)
    {
      this.ScheduleBlocks[index].time = this.OriginalTimes[index];
      this.ScheduleBlocks[index].destination = this.OriginalDests[index];
      this.ScheduleBlocks[index].action = this.OriginalActs[index];
    }
  }

  public void RestoreOriginalActions()
  {
    for (int index = 0; index < this.Actions.Length; ++index)
      this.Actions[index] = this.OriginalActions[index];
  }

  public void ChangeClothing()
  {
    if (this.ChangeClothingPhase == 0)
    {
      Debug.Log((object) "A student is changing clothing right now.");
      UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.CommunalLocker.SteamCloud, this.transform.position + Vector3.up * 0.81f, Quaternion.identity);
      this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
      ++this.ChangeClothingPhase;
    }
    else
    {
      if (this.ChangeClothingPhase != 1)
        return;
      this.CharacterAnimation.CrossFade(this.StripAnim);
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
      if ((double) this.CharacterAnimation[this.StripAnim].time < 1.5)
        return;
      if (this.Schoolwear != 1)
      {
        this.Schoolwear = 1;
        this.ChangeSchoolwear();
        this.WalkAnim = this.OriginalWalkAnim;
      }
      else if ((UnityEngine.Object) this.BikiniAttacher != (UnityEngine.Object) null && (UnityEngine.Object) this.BikiniAttacher.newRenderer != (UnityEngine.Object) null)
      {
        this.BikiniAttacher.newRenderer.enabled = false;
        this.MyRenderer.enabled = true;
      }
      if ((double) this.CharacterAnimation[this.StripAnim].time < (double) this.CharacterAnimation[this.StripAnim].length)
        return;
      if (this.CurrentAction == StudentActionType.AtLocker)
      {
        this.Pathfinding.target = this.StudentManager.Exit;
        this.CurrentDestination = this.StudentManager.Exit;
      }
      else if (this.CurrentAction == StudentActionType.ChangeShoes)
      {
        this.Pathfinding.target = this.MyLocker;
        this.CurrentDestination = this.MyLocker;
      }
      else
      {
        this.Pathfinding.target = this.Seat;
        this.CurrentDestination = this.Seat;
      }
      ++this.ChangeClothingPhase;
      this.MustChangeClothing = false;
    }
  }
}
