using System.Collections;
using HighlightingSystem;
using Pathfinding;
using UnityEngine;
using XInputDotNetPure;

public class YandereScript : MonoBehaviour
{
	public Quaternion targetRotation;

	private Vector3 targetDirection;

	private GameObject NewTrail;

	public int AccessoryID;

	private int ID;

	public FootprintSpawnerScript RightFootprintSpawner;

	public FootprintSpawnerScript LeftFootprintSpawner;

	public CameraFilterPack_Colors_Adjust_PreFilters YandereFilter;

	public CameraFilterPack_Colors_Adjust_PreFilters SenpaiFilter;

	public SelectiveGrayscale SelectGrayscale;

	public HighlightingRenderer HighlightingR;

	public HighlightingBlitter HighlightingB;

	public CameraFilterPack_Blur_GaussianBlur Blur;

	public RiggedAccessoryAttacher EightiesBikiniAttacher;

	public NotificationManagerScript NotificationManager;

	public ObstacleDetectorScript ObstacleDetector;

	public RiggedAccessoryAttacher GloveAttacher;

	public RiggedAccessoryAttacher PantyAttacher;

	public AccessoryGroupScript AccessoryGroup;

	public DumpsterHandleScript DumpsterHandle;

	public PhonePromptBarScript PhonePromptBar;

	public ShoulderCameraScript ShoulderCamera;

	public StudentManagerScript StudentManager;

	public AttackManagerScript AttackManager;

	public CameraEffectsScript CameraEffects;

	public WeaponManagerScript WeaponManager;

	public YandereShowerScript YandereShower;

	public PromptParentScript PromptParent;

	public SplashCameraScript SplashCamera;

	public SWP_HeartRateMonitor HeartRate;

	public GenericBentoScript TargetBento;

	public LoveManagerScript LoveManager;

	public StruggleBarScript StruggleBar;

	public RummageSpotScript RummageSpot;

	public IncineratorScript Incinerator;

	public InputDeviceScript InputDevice;

	public MusicCreditScript MusicCredit;

	public PauseScreenScript PauseScreen;

	public SmartphoneScript PhoneToCrush;

	public TrailWindowScript TrailWindow;

	public WoodChipperScript WoodChipper;

	public UILabel ConcealedWeaponLabel;

	public RagdollScript CurrentRagdoll;

	public StudentScript TargetStudent;

	public WeaponMenuScript WeaponMenu;

	public UILabel ConcealedItemLabel;

	public PromptScript NearestPrompt;

	public UIPanel YandereVisionPanel;

	public ContainerScript Container;

	public InventoryScript Inventory;

	public TallLockerScript MyLocker;

	public PromptBarScript PromptBar;

	public TranqCaseScript TranqCase;

	public AudioListener MyListener;

	public UISprite SneakShotButton;

	public AlphabetScript Alphabet;

	public UILabel SenpaiShotLabel;

	public LocationScript Location;

	public SubtitleScript Subtitle;

	public UITexture SanitySmudges;

	public Material CloakMaterial;

	public DemonScript EmptyDemon;

	public StudentScript Follower;

	public UIPanel DetectionPanel;

	public UILabel SneakShotLabel;

	public BookbagScript Bookbag;

	public JukeboxScript Jukebox;

	public OutlineScript Outline;

	public StudentScript Pursuer;

	public ShutterScript Shutter;

	public Collider HipCollider;

	public UISprite ProgressBar;

	public RPG_Camera RPGCamera;

	public BucketScript Bucket;

	public LookAtTarget LookAt;

	public NewArcScript NewArc;

	public PickUpScript PickUp;

	public PoliceScript Police;

	public UILabel SanityLabel;

	public GloveScript Gloves;

	public ClassScript Class;

	public Camera UICamera;

	public UILabel PowerUp;

	public MaskScript Mask;

	public MopScript Mop;

	public UIPanel HUD;

	public CharacterController MyController;

	public Transform LeftItemParent;

	public Transform BookBagParent;

	public Transform DismemberSpot;

	public Transform CameraTarget;

	public Transform InvertSphere;

	public Transform RightArmRoll;

	public Transform LeftArmRoll;

	public Transform CameraFocus;

	public Transform RightBreast;

	public Transform HidingSpot;

	public Transform ItemParent;

	public Transform LeftBreast;

	public Transform LimbParent;

	public Transform PelvisRoot;

	public Transform PoisonSpot;

	public Transform CameraPOV;

	public Transform RightHand;

	public Transform RightKnee;

	public Transform RightFoot;

	public Transform ExitSpot;

	public Transform LeftHand;

	public Transform Backpack;

	public Transform DropSpot;

	public Transform Homeroom;

	public Transform DigSpot;

	public Transform Senpai;

	public Transform Target;

	public Transform Stool;

	public Transform Eyes;

	public Transform Head;

	public Transform Hips;

	public AudioSource HeartBeat;

	public AudioSource MyAudio;

	public GameObject[] Accessories;

	public GameObject[] Hairstyles;

	public GameObject[] Poisons;

	public GameObject[] Shoes;

	public float[] DropTimer;

	public GameObject PhysicsActivator;

	public GameObject PolaroidOfSenpai;

	public GameObject CinematicCamera;

	public GameObject FloatingShovel;

	public GameObject SneakShotPhone;

	public GameObject EasterEggMenu;

	public GameObject PantyDetector;

	public GameObject StolenObject;

	public GameObject CameraFlash;

	public GameObject MemeGlasses;

	public GameObject SelfieGuide;

	public GameObject GiggleDisc;

	public GameObject KONGlasses;

	public GameObject Microphone;

	public GameObject Paintbrush;

	public GameObject SpiderLegs;

	public GameObject AlarmDisc;

	public GameObject Character;

	public GameObject DebugMenu;

	public GameObject EyepatchL;

	public GameObject EyepatchR;

	public GameObject EmptyHusk;

	public GameObject Handcuffs;

	public GameObject ShoePair;

	public GameObject Barcode;

	public GameObject Headset;

	public GameObject Palette;

	public GameObject Ragdoll;

	public GameObject Hearts;

	public GameObject Teeth;

	public GameObject Phone;

	public GameObject Trail;

	public GameObject Match;

	public GameObject Arc;

	public SkinnedMeshRenderer MyRenderer;

	public Animation CharacterAnimation;

	public ParticleSystem GiggleLines;

	public ParticleSystem InsaneLines;

	public SpringJoint RagdollDragger;

	public SpringJoint RagdollPK;

	public Projector MyProjector;

	public Camera HeartCamera;

	public Camera MainCamera;

	public Camera Smartphone;

	public Camera HandCamera;

	public Renderer SmartphoneRenderer;

	public Renderer LongHairRenderer;

	public Renderer PonytailRenderer;

	public Renderer NoPonyRenderer;

	public Renderer LooseRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public float PotentiallyMurderousTimer;

	public float PotentiallyAnnoyingTimer;

	public float SuspiciousActionTimer;

	public float MurderousActionTimer;

	public float AnnoyingGiggleTimer;

	public float PrepareThrowTimer;

	public float CinematicTimer;

	public float SneakShotTimer;

	public float ClothingTimer;

	public float ImmunityTimer;

	public float BreakUpTimer;

	public float CanMoveTimer;

	public float RummageTimer;

	public float YandereTimer;

	public float AttackTimer;

	public float CaughtTimer;

	public float GiggleTimer;

	public float SenpaiTimer;

	public float WeaponTimer;

	public float CrawlTimer;

	public float GloveTimer;

	public float LaughTimer;

	public float SprayTimer;

	public float TheftTimer;

	public float TrailTimer;

	public float BeatTimer;

	public float BoneTimer;

	public float DumpTimer;

	public float ExitTimer;

	public float TalkTimer;

	[SerializeField]
	private float bloodiness;

	public float PreviousSanity = 100f;

	[SerializeField]
	private float sanity;

	public float TwitchTimer;

	public float NextTwitch;

	public float SenpaiThreshold;

	public float LaughIntensity;

	public float TimeSkipHeight;

	public float PourDistance;

	public float TargetHeight;

	public float PermitLaugh;

	public float ReachWeight;

	public float BreastSize;

	public float Numbness;

	public float PourTime;

	public float RunSpeed;

	public float Height;

	public float Slouch;

	public float Bend;

	public float CrouchWalkSpeed;

	public float CrouchRunSpeed;

	public float ShoveSpeed = 2f;

	public float CrawlSpeed;

	public float FlapSpeed;

	public float WalkSpeed;

	public float YandereFade;

	public float YandereTint;

	public float SenpaiFade;

	public float SenpaiTint;

	public float GreyTarget;

	public int CurrentUniformOrigin = 1;

	public int PreviousSchoolwear;

	public int NearestCorpseID;

	public int VendingMachines;

	public int StolenObjectID;

	public int StrugglePhase;

	public int PhysicalGrade;

	public int CarryAnimID;

	public int AttackPhase;

	public int Creepiness = 1;

	public int GloveBlood;

	public int NearBodies;

	public int PoisonType;

	public int Schoolwear;

	public int SpeedBonus;

	public int SprayPhase;

	public int DragState;

	public int EggBypass;

	public int EyewearID;

	public int Followers;

	public int Hairstyle;

	public int PersonaID;

	public int DigPhase;

	public int Equipped;

	public int SelfieID;

	public int Friends;

	public int Chasers;

	public int Costume;

	public int Alerts;

	public int Health = 5;

	public int Kills;

	public YandereInteractionType Interaction;

	public YanderePersonaType PreviousPersona;

	public YanderePersonaType Persona;

	public ClubType Club;

	public bool EavesdropWarning;

	public bool ClothingWarning;

	public bool BloodyWarning;

	public bool CorpseWarning;

	public bool SanityWarning;

	public bool WeaponWarning;

	public bool CreatingTripwireTrap;

	public bool CreatingBucketTrap;

	public bool DelinquentFighting;

	public bool DumpsterGrabbing;

	public bool WrappingCorpse;

	public bool FakingReaction;

	public bool BucketDropping;

	public bool CleaningWeapon;

	public bool PreparingThrow;

	public bool SubtleStabbing;

	public bool TranquilHiding;

	public bool CrushingPhone;

	public bool Eavesdropping;

	public bool Pickpocketing;

	public bool Dismembering;

	public bool SenpaiGazing;

	public bool ShootingBeam;

	public bool SneakingShot;

	public bool StoppingTime;

	public bool TimeSkipping;

	public bool Cauterizing;

	public bool HeavyWeight;

	public bool Trespassing;

	public bool WritingName;

	public bool Struggling;

	public bool Attacking;

	public bool CannotAim;

	public bool Degloving;

	public bool OutOfAmmo;

	public bool Poisoning;

	public bool Rummaging;

	public bool Stripping;

	public bool Blasting;

	public bool Carrying;

	public bool Chipping;

	public bool Dragging;

	public bool Dropping;

	public bool Flicking;

	public bool Freezing;

	public bool Laughing;

	public bool Punching;

	public bool Throwing;

	public bool Tripping;

	public bool Bathing;

	public bool Burying;

	public bool Cooking;

	public bool Digging;

	public bool Dipping;

	public bool Dumping;

	public bool Exiting;

	public bool Lifting;

	public bool Mopping;

	public bool Pouring;

	public bool Resting;

	public bool Running;

	public bool Talking;

	public bool Testing;

	public bool Aiming;

	public bool Eating;

	public bool Hiding;

	public bool Riding;

	public Stance Stance = new Stance(StanceType.Standing);

	public bool PreparedForStruggle;

	public bool SprayedByJournalist;

	public bool CrouchButtonDown;

	public bool FightHasBrokenUp;

	public bool CannotBeSprayed;

	public bool UsingController;

	public bool SeenByAuthority;

	public bool CameFromCrouch;

	public bool CannotRecover;

	public bool FilterUpdated;

	public bool NearMindSlave;

	public bool NoStainGloves;

	public bool YandereVision;

	public bool ClubActivity;

	public bool FlameDemonic;

	public bool SanityBased;

	public bool SanityPills;

	public bool SummonBones;

	public bool ClubAttire;

	public bool FollowHips;

	public bool NearSenpai;

	public bool RivalPhone;

	public bool SpiderGrow;

	public bool Invisible;

	public bool Possessed;

	public bool ToggleRun;

	public bool WitchMode;

	public bool Attacked;

	public bool CanCloak;

	public bool CanTranq;

	public bool Collapse;

	public bool Unmasked;

	public bool RedPaint;

	public bool RoofPush;

	public bool Demonic;

	public bool FlapOut;

	public bool InClass;

	public bool NoDebug;

	public bool NoLaugh;

	public bool Noticed;

	public bool Obvious;

	public bool Slender;

	public bool Sprayed;

	public bool Caught;

	public bool NoInfo;

	public bool CanMove = true;

	public bool Chased;

	public bool Frozen;

	public bool Gloved;

	public bool Selfie;

	public bool Shoved;

	public bool Drown;

	public bool Xtan;

	public bool Lewd;

	public bool Lost;

	public bool Sans;

	public bool Egg;

	public bool Won;

	public bool AR;

	public bool DK;

	public bool PK;

	public Texture[] UniformTextures;

	public Texture[] CasualTextures;

	public Texture[] FlowerTextures;

	public Texture[] BloodTextures;

	public AudioClip[] CreepyGiggles;

	public AudioClip[] Stabs;

	public WeaponScript[] Weapon;

	public GameObject[] ZipTie;

	public string[] ArmedAnims;

	public string[] CarryAnims;

	public Transform[] Spine;

	public Transform[] Foot;

	public Transform[] Hand;

	public Transform[] Arm;

	public Transform[] Leg;

	public Material[] CloakMaterials;

	public Mesh[] Uniforms;

	public Renderer RightYandereEye;

	public Renderer LeftYandereEye;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Renderer RightRedEye;

	public Renderer LeftRedEye;

	public Transform RightEye;

	public Transform LeftEye;

	public float EyeShrink;

	public Vector3 Twitch;

	private AudioClip LaughClip;

	public string PreviousIdleAnim = string.Empty;

	public string PreviousWalkAnim = string.Empty;

	public string DefaultIdleAnim = string.Empty;

	public string DefaultWalkAnim = string.Empty;

	public string PourHeight = string.Empty;

	public string DrownAnim = string.Empty;

	public string LaughAnim = string.Empty;

	public string HideAnim = string.Empty;

	public string IdleAnim = string.Empty;

	public string TalkAnim = string.Empty;

	public string WalkAnim = string.Empty;

	public string RunAnim = string.Empty;

	public string CrouchIdleAnim = string.Empty;

	public string CrouchWalkAnim = string.Empty;

	public string CrouchRunAnim = string.Empty;

	public string CrawlIdleAnim = string.Empty;

	public string CrawlWalkAnim = string.Empty;

	public string HeavyIdleAnim = string.Empty;

	public string HeavyWalkAnim = string.Empty;

	public string CarryIdleAnim = string.Empty;

	public string CarryWalkAnim = string.Empty;

	public string CarryRunAnim = string.Empty;

	public string[] CreepyIdles;

	public string[] CreepyWalks;

	public AudioClip DramaticWriting;

	public AudioClip ChargeUp;

	public AudioClip Laugh0;

	public AudioClip Laugh1;

	public AudioClip Laugh2;

	public AudioClip Laugh3;

	public AudioClip Laugh4;

	public AudioClip Thud;

	public AudioClip Dig;

	public Vector3 PreviousPosition;

	public string OriginalIdleAnim = string.Empty;

	public string OriginalWalkAnim = string.Empty;

	public string OriginalRunAnim = string.Empty;

	public Texture YanderePhoneTexture;

	public Texture BloodyGloveTexture;

	public Texture RivalPhoneTexture;

	public Texture GloveTexture;

	public Texture BlondeLoose;

	public Texture BlondePony;

	public float VibrationIntensity;

	public float VibrationTimer;

	public bool VibrationCheck;

	public AudioReverbZone SanityReverb;

	public float v;

	public float h;

	private int DebugInt;

	public GameObject CreepyArms;

	public bool SetUpRaincoatOutline;

	public bool BypassRequirement;

	public bool DropSpecifically;

	public Texture[] GloveTextures;

	public float OriginalBloodiness;

	public float CoatBloodiness;

	public bool WearingRaincoat;

	public ParticleSystem ODMEffect;

	public Texture TitanBodyTexture;

	public Texture TitanFaceTexture;

	public GameObject TitanSlash;

	public GameObject ODMGear;

	public AudioClip AirBlast;

	public GameObject[] TitanSword;

	public Texture KONTexture;

	public GameObject PunishedAccessories;

	public GameObject PunishedScarf;

	public GameObject[] PunishedArm;

	public Texture[] PunishedTextures;

	public Shader PunishedShader;

	public Mesh PunishedMesh;

	public Material HatefulSkybox;

	public Texture HatefulUniform;

	public GameObject SukebanAccessories;

	public Texture SukebanBandages;

	public Texture SukebanUniform;

	public FalconPunchScript BanchoFinisher;

	public StandPunchScript BanchoFlurry;

	public GameObject BanchoPants;

	public Mesh BanchoMesh;

	public Texture BanchoBody;

	public Texture BanchoFace;

	public GameObject[] BanchoAccessories;

	public bool BanchoActive;

	public bool Finisher;

	public AudioClip BanchoYanYan;

	public AudioClip BanchoFinalYan;

	public AmplifyMotionObject MotionObject;

	public AmplifyMotionEffect MotionBlur;

	public GameObject BanchoCamera;

	public GameObject[] SlenderHair;

	public Texture SlenderUniform;

	public Material SlenderSkybox;

	public Texture SlenderSkin;

	public Transform[] LongHair;

	public GameObject BlackEyePatch;

	public GameObject XSclera;

	public GameObject XEye;

	public Texture XBody;

	public Texture XFace;

	public GameObject[] GaloAccessories;

	public Texture GaloArms;

	public Texture GaloFace;

	public AudioClip SummonStand;

	public StandScript Stand;

	public AudioClip YanYan;

	public Texture AgentFace;

	public Texture AgentSuit;

	public GameObject CirnoIceAttack;

	public AudioClip CirnoIceClip;

	public GameObject CirnoWings;

	public GameObject CirnoHair;

	public Texture CirnoUniform;

	public Texture CirnoFace;

	public Transform[] CirnoWing;

	public float CirnoRotation;

	public float CirnoTimer;

	public AudioClip FalconPunchVoice;

	public Texture FalconBody;

	public Texture FalconFace;

	public float FalconSpeed;

	public GameObject NewFalconPunch;

	public GameObject FalconWindUp;

	public GameObject FalconPunch;

	public GameObject FalconShoulderpad;

	public GameObject FalconKneepad1;

	public GameObject FalconKneepad2;

	public GameObject FalconBuckle;

	public GameObject FalconHelmet;

	public AudioClip[] OnePunchVoices;

	public GameObject NewOnePunch;

	public GameObject OnePunch;

	public Texture SaitamaSuit;

	public GameObject Cape;

	public ParticleSystem GlowEffect;

	public GameObject[] BlasterSet;

	public GameObject[] SansEyes;

	public AudioClip BlasterClip;

	public Texture SansTexture;

	public Texture SansFace;

	public GameObject Bone;

	public AudioClip Slam;

	public Mesh Jersey;

	public int BlasterStage;

	public PKDirType PKDir;

	public Texture CyborgBody;

	public Texture CyborgFace;

	public GameObject[] CyborgParts;

	public GameObject EnergySword;

	public bool Ninja;

	public GameObject EbolaEffect;

	public GameObject EbolaWings;

	public GameObject EbolaHair;

	public Texture EbolaFace;

	public Texture EbolaUniform;

	public GameObject EbolaAttacher;

	public Mesh LongUniform;

	public Texture NewFace;

	public Mesh NewMesh;

	public GameObject[] CensorSteam;

	public Texture NudePanties;

	public Texture NudeTexture;

	public Mesh NudeMesh;

	public Texture SamusBody;

	public Texture SamusFace;

	public GlobalKnifeArrayScript GlobalKnifeArray;

	public GameObject PlayerOnlyCamera;

	public GameObject KnifeArray;

	public AudioClip ClockStart;

	public AudioClip ClockStop;

	public AudioClip ClockTick;

	public AudioClip StartShout;

	public AudioClip StopShout;

	public Texture WitchBody;

	public Texture WitchFace;

	public Collider BladeHairCollider1;

	public Collider BladeHairCollider2;

	public GameObject BladeHair;

	public DebugMenuScript TheDebugMenuScript;

	public GameObject RiggedAccessory;

	public GameObject TornadoAttack;

	public GameObject TornadoDress;

	public GameObject TornadoHair;

	public Renderer TornadoRenderer;

	public Mesh NoTorsoMesh;

	public GameObject KunHair;

	public GameObject Kun;

	public GameObject Man;

	public GameObject BlackHoleEffects;

	public Texture BlackHoleFace;

	public Texture Black;

	public bool BlackHole;

	public Transform RightLeg;

	public Transform LeftLeg;

	public GameObject Bandages;

	public GameObject LucyHelmet;

	public GameObject[] Vectors;

	public GameObject[] Kagune;

	public Texture GhoulFace;

	public Texture GhoulBody;

	public bool ReturnKagune;

	public bool SwingKagune;

	public Vector3[] KaguneRotation;

	public AudioClip KaguneSwoosh;

	public GameObject DemonSlash;

	public int KagunePhase;

	public GameObject BerserkHitbox;

	public GameObject[] Armor;

	public Texture Chainmail;

	public Texture Scarface;

	public Material Metal;

	public Material Trans;

	public GameObject BlackRobe;

	public Mesh NoUpperBodyMesh;

	public ParticleSystem[] Beam;

	public SithBeamScript[] SithBeam;

	public bool SithRecovering;

	public bool SithAttacking;

	public bool SithLord;

	public string SithPrefix;

	public int SithComboLength;

	public int SithAttacks;

	public int SithSounds;

	public int SithCombo;

	public GameObject SithHardHitbox;

	public GameObject SithHitbox;

	public GameObject SithTrail1;

	public GameObject SithTrail2;

	public Transform SithTrailEnd1;

	public Transform SithTrailEnd2;

	public ZoomScript Zoom;

	public AudioClip SithOn;

	public AudioClip SithOff;

	public AudioClip SithSwing;

	public AudioClip SithStrike;

	public AudioSource SithAudio;

	public float[] SithHardSpawnTime1;

	public float[] SithHardSpawnTime2;

	public float[] SithSpawnTime;

	public Texture SnakeFace;

	public Texture SnakeBody;

	public Texture Stone;

	public AudioClip Petrify;

	public GameObject Pebbles;

	public bool Medusa;

	public Texture GazerFace;

	public Texture GazerBody;

	public GazerEyesScript GazerEyes;

	public AudioClip FingerSnap;

	public AudioClip Zap;

	public bool GazeAttacking;

	public bool Snapping;

	public bool Gazing;

	public int SnapPhase;

	public GameObject SixRaincoat;

	public GameObject RisingSmoke;

	public GameObject DarkHelix;

	public Texture SixFaceTexture;

	public AudioClip SixTakedown;

	public Transform SixTarget;

	public Mesh SixBodyMesh;

	public Transform Mouth;

	public int EatPhase;

	public bool Hungry;

	public int Hunger;

	public float[] BloodTimes;

	public AudioClip[] Snarls;

	public Mesh HeadAndKnees;

	public int HairstyleBeforeRaincoat;

	public Texture KLKBody;

	public Texture KLKFace;

	public GameObject[] KLKParts;

	public GameObject KLKSword;

	public AudioClip LoveLoveBeamVoice;

	public GameObject MiyukiCostume;

	public GameObject LoveLoveBeam;

	public GameObject MiyukiWings;

	public Texture MiyukiSkin;

	public Texture MiyukiFace;

	public bool MagicalGirl;

	public int BeamPhase;

	public GameObject AzurGuns;

	public GameObject AzurWater;

	public GameObject AzurMist;

	public GameObject Shell;

	public Transform[] Guns;

	public int ShotsFired;

	public bool Shipgirl;

	public GameObject GarbageBag;

	public GameObject TallLadyAttacher;

	public GameObject BlackRose;

	public GameObject FloppyHat;

	public AudioClip Swoosh;

	public DynamicBone[] BoobPhysics;

	public Transform[] AllFingers;

	public float FingerLength;

	public bool LongFingers;

	public bool Swiping;

	public int SwipeID;

	public CameraFilterPack_Colors_Adjust_PreFilters HollowFilter;

	public GameObject HollowCloakAttacher;

	public GameObject HollowSword;

	public GameObject HollowMask;

	public GameObject DarkParticles;

	public Texture HollowBodyTexture;

	public Texture HollowFaceTexture;

	public Mesh NoButtMesh;

	public float ArmSize;

	public BlacklightEffect BlacklightShader;

	public GameObject BlacklightOutfit;

	public Mesh BlacklightBodyMesh;

	public RiggedAccessoryAttacher RaincoatAttacher;

	public GameObject Rain;

	public Material HorrorSkybox;

	public Texture YamikoFaceTexture;

	public Texture YamikoSkinTexture;

	public Texture YamikoAccessoryTexture;

	public GameObject LifeNotebook;

	public GameObject LifeNotePen;

	public Mesh YamikoMesh;

	public GameObject GroundImpact;

	public GameObject NierCostume;

	public GameObject HeavySword;

	public GameObject LightSword;

	public GameObject Pod;

	public Transform LightSwordParent;

	public Transform HeavySwordParent;

	public ParticleSystem LightSwordParticles;

	public ParticleSystem HeavySwordParticles;

	public string AttackPrefix;

	public float NierDamage;

	public float[] NierSpawnTime;

	public float[] NierHardSpawnTime;

	public AudioClip NierSwoosh;

	public GameObject ChinaDress;

	public GameObject MedibangAttacher;

	public NormalBufferView VaporwaveVisuals;

	public Material VaporwaveSkybox;

	public GameObject PalmTrees;

	public GameObject[] Trees;

	public Mesh SchoolSwimsuit;

	public Mesh GymUniform;

	public Mesh Towel;

	public Texture FaceTexture;

	public Texture SwimsuitTexture;

	public Texture EightiesGymTexture;

	public Texture GymTexture;

	public Texture TextureToUse;

	public Texture TowelTexture;

	public bool Casual = true;

	public Mesh JudoGiMesh;

	public Texture JudoGiTexture;

	public Mesh ApronMesh;

	public Texture ApronTexture;

	public Mesh LabCoatMesh;

	public Mesh HeadAndHands;

	public Texture LabCoatTexture;

	public RiggedAccessoryAttacher LabcoatAttacher;

	public bool Paint;

	public GameObject[] ClubAccessories;

	public GameObject Fireball;

	public bool LiftOff;

	public GameObject LiftOffParticles;

	public float LiftOffSpeed;

	public SkinnedMeshUpdater SkinUpdater;

	public Mesh RivalChanMesh;

	public Mesh TestMesh;

	public bool BullyPhoto;

	public CameraFilterScript CinematicCameraFilters;

	public CameraFilterScript CameraFilters;

	public float mass = 3f;

	public Vector3 impact = Vector3.zero;

	public RaycastHit hit;

	public Transform RaycastOrigin;

	public bool Jumping;

	public float SlowDownSpeed = 1f;

	public AudioClip[] EightiesLaughs;

	public Texture EightiesUniform;

	public Texture EightiesCasual;

	public GameObject EightiesCamera;

	public Transform ModernCamera;

	public Renderer EightiesPonytailRenderer;

	public Mesh EightiesKerchiefMesh;

	public GameObject MaidAttacher;

	public Texture MaidFace;

	public Texture MaidBody;

	public Texture MaidOutfit;

	public bool MaidCheck;

	public Texture[] VtuberFaces;

	public int VtuberID;

	public float DebugTimer;

	public RaycastHit corpseHit;

	public Transform corpseOrigin;

	public bool TooCloseToWall;

	public bool WallInFront;

	public bool WallToRight;

	public bool WallToLeft;

	public bool WallAbove;

	public float CustomThreshold;

	public int Direction;

	public bool AudioPlayed;

	public AudioClip YandereVisionOn;

	public AudioClip YandereVisionOff;

	public AudioSource YandereVisionAudio;

	public AudioSource YandereVisionDrone;

	public MiniMapComponent MiniMapIcon;

	public float Sanity
	{
		get
		{
			return sanity;
		}
		set
		{
			sanity = Mathf.Clamp(value, 0f, 100f);
			if (SanityPills)
			{
				sanity = 100f;
			}
			if (sanity > 66.66666f)
			{
				HeartRate.SetHeartRateColour(HeartRate.NormalColour);
				SanityWarning = false;
			}
			else if (sanity > 33.33333f)
			{
				HeartRate.SetHeartRateColour(HeartRate.MediumColour);
				SanityWarning = false;
				if (PreviousSanity < 33.33333f)
				{
					StudentManager.UpdateStudents();
				}
			}
			else
			{
				HeartRate.SetHeartRateColour(HeartRate.BadColour);
				if (!SanityWarning)
				{
					NotificationManager.DisplayNotification(NotificationType.Insane);
					StudentManager.TutorialWindow.ShowSanityMessage = true;
					SanityWarning = true;
				}
			}
			HeartRate.BeatsPerMinute = (int)(240f - sanity * 1.8f);
			if (!Laughing)
			{
				Teeth.SetActive(SanityWarning);
			}
			if (MyRenderer.sharedMesh != NudeMesh && !ClubAttire)
			{
				if (!Slender)
				{
					MyRenderer.materials[2].SetFloat("_BlendAmount", 1f - sanity / 100f);
				}
				else
				{
					MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
				}
			}
			else
			{
				MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			}
			PreviousSanity = sanity;
			Hairstyles[2].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, Sanity);
			SanityReverb.maxDistance = 10f - Sanity / 100f * 10f;
		}
	}

	public float Bloodiness
	{
		get
		{
			return bloodiness;
		}
		set
		{
			bloodiness = Mathf.Clamp(value, 0f, 100f);
			if (Bloodiness > 0f)
			{
				StudentManager.TutorialWindow.ShowBloodMessage = true;
			}
			bool flag = false;
			if (Club == ClubType.Art && ClubAttire)
			{
				flag = true;
			}
			if (!BloodyWarning && Bloodiness > 0f)
			{
				if (flag)
				{
					NotificationManager.CustomText = "...but not suspicious.";
					NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				NotificationManager.DisplayNotification(NotificationType.Bloody);
				BloodyWarning = true;
				if (Schoolwear > 0 && !WearingRaincoat)
				{
					Police.BloodyClothing++;
					if (!ClubAttire)
					{
						if (CurrentUniformOrigin == 1)
						{
							StudentManager.OriginalUniforms--;
							Debug.Log("One of the original uniforms has become bloody.");
						}
						else
						{
							StudentManager.NewUniforms--;
							Debug.Log("One of the new uniforms has become bloody.");
						}
						Debug.Log("As a result, # of OriginalUniforms is: " + StudentManager.OriginalUniforms + " and # of NewUniforms is: " + StudentManager.NewUniforms);
					}
				}
			}
			MyProjector.enabled = true;
			RedPaint = false;
			if (!GameGlobals.CensorBlood)
			{
				MyProjector.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.5f));
				if (Bloodiness == 100f)
				{
					MyProjector.material.mainTexture = BloodTextures[5];
				}
				else if (Bloodiness >= 80f)
				{
					MyProjector.material.mainTexture = BloodTextures[4];
				}
				else if (Bloodiness >= 60f)
				{
					MyProjector.material.mainTexture = BloodTextures[3];
				}
				else if (Bloodiness >= 40f)
				{
					MyProjector.material.mainTexture = BloodTextures[2];
				}
				else if (Bloodiness >= 20f)
				{
					MyProjector.material.mainTexture = BloodTextures[1];
				}
				else
				{
					MyProjector.enabled = false;
					BloodyWarning = false;
				}
			}
			else
			{
				MyProjector.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f));
				if (Bloodiness == 100f)
				{
					MyProjector.material.mainTexture = FlowerTextures[5];
				}
				else if (Bloodiness >= 80f)
				{
					MyProjector.material.mainTexture = FlowerTextures[4];
				}
				else if (Bloodiness >= 60f)
				{
					MyProjector.material.mainTexture = FlowerTextures[3];
				}
				else if (Bloodiness >= 40f)
				{
					MyProjector.material.mainTexture = FlowerTextures[2];
				}
				else if (Bloodiness >= 20f)
				{
					MyProjector.material.mainTexture = FlowerTextures[1];
				}
				else
				{
					MyProjector.enabled = false;
					BloodyWarning = false;
				}
			}
			StudentManager.UpdateBooths();
			MyLocker.UpdateButtons();
			Outline.h.ReinitMaterials();
		}
	}

	public WeaponScript EquippedWeapon
	{
		get
		{
			return Weapon[Equipped];
		}
		set
		{
			Weapon[Equipped] = value;
		}
	}

	public bool Armed => EquippedWeapon != null;

	public SanityType SanityType
	{
		get
		{
			if (Sanity / 100f > 2f / 3f)
			{
				return SanityType.High;
			}
			if (Sanity / 100f > 1f / 3f)
			{
				return SanityType.Medium;
			}
			return SanityType.Low;
		}
	}

	public Vector3 HeadPosition => new Vector3(base.transform.position.x, base.transform.position.y + Zoom.Height + 0.1f, base.transform.position.z);

	public int OnlyGroundLayer => 256;

	public int OnlyDefault => 1;

	private void Start()
	{
		DefaultIdleAnim = IdleAnim;
		DefaultWalkAnim = WalkAnim;
		PreviousIdleAnim = IdleAnim;
		PreviousWalkAnim = WalkAnim;
		Application.runInBackground = false;
		VtuberCheck();
		if (!GameGlobals.EightiesTutorial && !GameGlobals.KokonaTutorial)
		{
			NoLaugh = ChallengeGlobals.NoLaugh;
		}
		NoInfo = ChallengeGlobals.NoInfo;
		if (NoInfo)
		{
			SneakShotButton.alpha = 0.5f;
			SneakShotLabel.alpha = 0f;
		}
		SenpaiThreshold = 1f - (float)PlayerGlobals.ShrineItems * 0.1f;
		PhysicalGrade = ClassGlobals.PhysicalGrade;
		SpeedBonus = PlayerGlobals.SpeedBonus;
		Friends = PlayerGlobals.Friends;
		Club = ClubGlobals.Club;
		SanitySmudges.color = new Color(1f, 1f, 1f, 0f);
		SpiderLegs.SetActive(GameGlobals.EmptyDemon);
		MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
		SetAnimationLayers();
		UpdateNumbness();
		RightEyeOrigin = RightEye.localPosition;
		LeftEyeOrigin = LeftEye.localPosition;
		CharacterAnimation["f02_yanderePose_00"].weight = 0f;
		CharacterAnimation["f02_cameraPose_00"].weight = 0f;
		CharacterAnimation["f02_selfie_00"].weight = 0f;
		CharacterAnimation["f02_selfie_01"].weight = 0f;
		CharacterAnimation["f02_shipGirlSnap_00"].speed = 2f;
		CharacterAnimation["f02_gazerSnap_00"].speed = 2f;
		CharacterAnimation["f02_performing_00"].speed = 0.9f;
		CharacterAnimation["f02_sithAttack_00"].speed = 1.5f;
		CharacterAnimation["f02_sithAttack_01"].speed = 1.5f;
		CharacterAnimation["f02_sithAttack_02"].speed = 1.5f;
		CharacterAnimation["f02_sithAttackHard_00"].speed = 1.5f;
		CharacterAnimation["f02_sithAttackHard_01"].speed = 1.5f;
		CharacterAnimation["f02_sithAttackHard_02"].speed = 1.5f;
		CharacterAnimation["f02_nierRun_00"].speed = 1.5f;
		AssignFilters();
		ResetYandereEffects();
		ResetSenpaiEffects();
		Sanity = 100f;
		Bloodiness = 0f;
		YandereFade = 100f;
		EasterEggMenu.transform.localPosition = new Vector3(EasterEggMenu.transform.localPosition.x, 0f, EasterEggMenu.transform.localPosition.z);
		ProgressBar.transform.parent.gameObject.SetActive(value: false);
		Smartphone.transform.parent.gameObject.SetActive(value: false);
		ObstacleDetector.gameObject.SetActive(value: false);
		SithBeam[1].gameObject.SetActive(value: false);
		SithBeam[2].gameObject.SetActive(value: false);
		PunishedAccessories.SetActive(value: false);
		SukebanAccessories.SetActive(value: false);
		FalconShoulderpad.SetActive(value: false);
		CensorSteam[0].SetActive(value: false);
		CensorSteam[1].SetActive(value: false);
		CensorSteam[2].SetActive(value: false);
		CensorSteam[3].SetActive(value: false);
		FloatingShovel.SetActive(value: false);
		BlackEyePatch.SetActive(value: false);
		EasterEggMenu.SetActive(value: false);
		FalconKneepad1.SetActive(value: false);
		FalconKneepad2.SetActive(value: false);
		PunishedScarf.SetActive(value: false);
		FalconBuckle.SetActive(value: false);
		FalconHelmet.SetActive(value: false);
		TornadoDress.SetActive(value: false);
		Stand.Stand.SetActive(value: false);
		TornadoHair.SetActive(value: false);
		MemeGlasses.SetActive(value: false);
		MemeGlasses.SetActive(value: false);
		CirnoWings.SetActive(value: false);
		KONGlasses.SetActive(value: false);
		EbolaWings.SetActive(value: false);
		Microphone.SetActive(value: false);
		Paintbrush.SetActive(value: false);
		Poisons[1].SetActive(value: false);
		Poisons[2].SetActive(value: false);
		Poisons[3].SetActive(value: false);
		BladeHair.SetActive(value: false);
		CirnoHair.SetActive(value: false);
		EbolaHair.SetActive(value: false);
		EyepatchL.SetActive(value: false);
		EyepatchR.SetActive(value: false);
		Handcuffs.SetActive(value: false);
		ZipTie[0].SetActive(value: false);
		ZipTie[1].SetActive(value: false);
		Shoes[0].SetActive(value: false);
		Shoes[1].SetActive(value: false);
		Palette.SetActive(value: false);
		Phone.SetActive(value: false);
		Cape.SetActive(value: false);
		HeavySwordParent.gameObject.SetActive(value: false);
		LightSwordParent.gameObject.SetActive(value: false);
		Pod.SetActive(value: false);
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		GameObject[] armor = Armor;
		for (int i = 0; i < armor.Length; i++)
		{
			armor[i].SetActive(value: false);
		}
		for (ID = 1; ID < Accessories.Length; ID++)
		{
			Accessories[ID].SetActive(value: false);
		}
		armor = PunishedArm;
		for (int i = 0; i < armor.Length; i++)
		{
			armor[i].SetActive(value: false);
		}
		armor = GaloAccessories;
		for (int i = 0; i < armor.Length; i++)
		{
			armor[i].SetActive(value: false);
		}
		armor = Vectors;
		for (int i = 0; i < armor.Length; i++)
		{
			armor[i].SetActive(value: false);
		}
		for (ID = 1; ID < CyborgParts.Length; ID++)
		{
			CyborgParts[ID].SetActive(value: false);
		}
		for (ID = 0; ID < KLKParts.Length; ID++)
		{
			KLKParts[ID].SetActive(value: false);
		}
		for (ID = 0; ID < BanchoAccessories.Length; ID++)
		{
			BanchoAccessories[ID].SetActive(value: false);
		}
		if (PlayerGlobals.PantiesEquipped == 5)
		{
			RunSpeed += 1f;
		}
		if (PlayerGlobals.Headset)
		{
			Inventory.Headset = true;
		}
		UpdateHair();
		ClubAccessory();
		NoDebug = true;
		if (GameGlobals.Debug)
		{
			NoDebug = false;
		}
		if (GameGlobals.BlondeHair)
		{
			PonytailRenderer.material.mainTexture = BlondePony;
			NoPonyRenderer.material.mainTexture = BlondePony;
			LooseRenderer.material.mainTexture = BlondeLoose;
		}
		MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
		if (GameGlobals.Eighties)
		{
			BecomeRyoba();
		}
		SetUniform();
		HandCamera.gameObject.SetActive(value: false);
		CharacterAnimation.Sample();
	}

	public string GetSanityString(SanityType sanityType)
	{
		return sanityType switch
		{
			SanityType.High => "High", 
			SanityType.Medium => "Med", 
			_ => "Low", 
		};
	}

	public void SetAnimationLayers()
	{
		CharacterAnimation["f02_yanderePose_00"].layer = 1;
		CharacterAnimation.Play("f02_yanderePose_00");
		CharacterAnimation["f02_yanderePose_00"].weight = 0f;
		CharacterAnimation["f02_shy_00"].layer = 2;
		CharacterAnimation.Play("f02_shy_00");
		CharacterAnimation["f02_shy_00"].weight = 0f;
		CharacterAnimation["f02_singleSaw_00"].layer = 3;
		CharacterAnimation.Play("f02_singleSaw_00");
		CharacterAnimation["f02_singleSaw_00"].weight = 0f;
		CharacterAnimation["f02_fist_00"].layer = 4;
		CharacterAnimation.Play("f02_fist_00");
		CharacterAnimation["f02_fist_00"].weight = 0f;
		CharacterAnimation["f02_mopping_00"].layer = 5;
		CharacterAnimation["f02_mopping_00"].speed = 2f;
		CharacterAnimation.Play("f02_mopping_00");
		CharacterAnimation["f02_mopping_00"].weight = 0f;
		CharacterAnimation["f02_carry_00"].layer = 6;
		CharacterAnimation.Play("f02_carry_00");
		CharacterAnimation["f02_carry_00"].weight = 0f;
		CharacterAnimation["f02_mopCarry_00"].layer = 7;
		CharacterAnimation.Play("f02_mopCarry_00");
		CharacterAnimation["f02_mopCarry_00"].weight = 0f;
		CharacterAnimation["f02_bucketCarry_00"].layer = 8;
		CharacterAnimation.Play("f02_bucketCarry_00");
		CharacterAnimation["f02_bucketCarry_00"].weight = 0f;
		CharacterAnimation["f02_cameraPose_00"].layer = 9;
		CharacterAnimation.Play("f02_cameraPose_00");
		CharacterAnimation["f02_cameraPose_00"].weight = 0f;
		CharacterAnimation["f02_grip_00"].layer = 10;
		CharacterAnimation.Play("f02_grip_00");
		CharacterAnimation["f02_grip_00"].weight = 0f;
		CharacterAnimation["f02_holdHead_00"].layer = 11;
		CharacterAnimation.Play("f02_holdHead_00");
		CharacterAnimation["f02_holdHead_00"].weight = 0f;
		CharacterAnimation["f02_holdTorso_00"].layer = 12;
		CharacterAnimation.Play("f02_holdTorso_00");
		CharacterAnimation["f02_holdTorso_00"].weight = 0f;
		CharacterAnimation["f02_carryCan_00"].layer = 13;
		CharacterAnimation.Play("f02_carryCan_00");
		CharacterAnimation["f02_carryCan_00"].weight = 0f;
		CharacterAnimation["f02_leftGrip_00"].layer = 14;
		CharacterAnimation.Play("f02_leftGrip_00");
		CharacterAnimation["f02_leftGrip_00"].weight = 0f;
		CharacterAnimation["f02_carryShoulder_00"].layer = 15;
		CharacterAnimation.Play("f02_carryShoulder_00");
		CharacterAnimation["f02_carryShoulder_00"].weight = 0f;
		CharacterAnimation["f02_holdScythe_00"].layer = 16;
		CharacterAnimation.Play("f02_holdScythe_00");
		CharacterAnimation["f02_holdScythe_00"].weight = 0f;
		CharacterAnimation["f02_carryFlashlight_00"].layer = 17;
		CharacterAnimation.Play("f02_carryFlashlight_00");
		CharacterAnimation["f02_carryFlashlight_00"].weight = 0f;
		CharacterAnimation["f02_carryBox_00"].layer = 18;
		CharacterAnimation.Play("f02_carryBox_00");
		CharacterAnimation["f02_carryBox_00"].weight = 0f;
		CharacterAnimation["f02_holdBook_00"].layer = 19;
		CharacterAnimation.Play("f02_holdBook_00");
		CharacterAnimation["f02_holdBook_00"].weight = 0f;
		CharacterAnimation["f02_holdBook_00"].speed = 0.5f;
		CharacterAnimation["f02_holdingKitten_00"].layer = 20;
		CharacterAnimation.Play("f02_holdingKitten_00");
		CharacterAnimation["f02_holdingKitten_00"].weight = 0f;
		CharacterAnimation[CreepyIdles[1]].layer = 21;
		CharacterAnimation.Play(CreepyIdles[1]);
		CharacterAnimation[CreepyIdles[1]].weight = 0f;
		CharacterAnimation[CreepyIdles[2]].layer = 22;
		CharacterAnimation.Play(CreepyIdles[2]);
		CharacterAnimation[CreepyIdles[2]].weight = 0f;
		CharacterAnimation[CreepyIdles[3]].layer = 23;
		CharacterAnimation.Play(CreepyIdles[3]);
		CharacterAnimation[CreepyIdles[3]].weight = 0f;
		CharacterAnimation[CreepyIdles[4]].layer = 24;
		CharacterAnimation.Play(CreepyIdles[4]);
		CharacterAnimation[CreepyIdles[4]].weight = 0f;
		CharacterAnimation[CreepyIdles[5]].layer = 25;
		CharacterAnimation.Play(CreepyIdles[5]);
		CharacterAnimation[CreepyIdles[5]].weight = 0f;
		CharacterAnimation[CreepyWalks[1]].layer = 26;
		CharacterAnimation.Play(CreepyWalks[1]);
		CharacterAnimation[CreepyWalks[1]].weight = 0f;
		CharacterAnimation[CreepyWalks[2]].layer = 27;
		CharacterAnimation.Play(CreepyWalks[2]);
		CharacterAnimation[CreepyWalks[2]].weight = 0f;
		CharacterAnimation[CreepyWalks[3]].layer = 28;
		CharacterAnimation.Play(CreepyWalks[3]);
		CharacterAnimation[CreepyWalks[3]].weight = 0f;
		CharacterAnimation[CreepyWalks[4]].layer = 29;
		CharacterAnimation.Play(CreepyWalks[4]);
		CharacterAnimation[CreepyWalks[4]].weight = 0f;
		CharacterAnimation[CreepyWalks[5]].layer = 30;
		CharacterAnimation.Play(CreepyWalks[5]);
		CharacterAnimation[CreepyWalks[5]].weight = 0f;
		CharacterAnimation["f02_carryDramatic_00"].layer = 31;
		CharacterAnimation.Play("f02_carryDramatic_00");
		CharacterAnimation["f02_carryDramatic_00"].weight = 0f;
		CharacterAnimation["f02_selfie_00"].layer = 32;
		CharacterAnimation.Play("f02_selfie_00");
		CharacterAnimation["f02_selfie_00"].weight = 0f;
		CharacterAnimation["f02_selfie_01"].layer = 33;
		CharacterAnimation.Play("f02_selfie_01");
		CharacterAnimation["f02_selfie_01"].weight = 0f;
		CharacterAnimation["f02_dramaticWriting_00"].layer = 34;
		CharacterAnimation.Play("f02_dramaticWriting_00");
		CharacterAnimation["f02_dramaticWriting_00"].weight = 0f;
		CharacterAnimation["f02_reachForWeapon_00"].layer = 35;
		CharacterAnimation.Play("f02_reachForWeapon_00");
		CharacterAnimation["f02_reachForWeapon_00"].weight = 0f;
		CharacterAnimation["f02_reachForWeapon_00"].speed = 2f;
		CharacterAnimation["f02_gutsEye_00"].layer = 36;
		CharacterAnimation.Play("f02_gutsEye_00");
		CharacterAnimation["f02_gutsEye_00"].weight = 0f;
		CharacterAnimation["f02_fingerSnap_00"].layer = 37;
		CharacterAnimation.Play("f02_fingerSnap_00");
		CharacterAnimation["f02_fingerSnap_00"].weight = 0f;
		CharacterAnimation["f02_sadEyebrows_00"].layer = 38;
		CharacterAnimation.Play("f02_sadEyebrows_00");
		CharacterAnimation["f02_sadEyebrows_00"].weight = 0f;
		CharacterAnimation["f02_phonePose_00"].layer = 39;
		CharacterAnimation.Play("f02_phonePose_00");
		CharacterAnimation["f02_phonePose_00"].weight = 0f;
		CharacterAnimation["f02_prepareThrow_00"].layer = 40;
		CharacterAnimation.Play("f02_prepareThrow_00");
		CharacterAnimation["f02_prepareThrow_00"].weight = 0f;
		CharacterAnimation["f02_subtleThrowIdle_00"].layer = 41;
		CharacterAnimation.Play("f02_subtleThrowIdle_00");
		CharacterAnimation["f02_subtleThrowIdle_00"].weight = 0f;
		CharacterAnimation["f02_obviousThrowIdle_00"].layer = 42;
		CharacterAnimation.Play("f02_obviousThrowIdle_00");
		CharacterAnimation["f02_obviousThrowIdle_00"].weight = 0f;
		CharacterAnimation["f02_dipping_00"].speed = 2f;
		CharacterAnimation["f02_stripping_00"].speed = 1.5f;
		CharacterAnimation["f02_falconIdle_00"].speed = 2f;
		CharacterAnimation["f02_carryIdleA_00"].speed = 1.75f;
		CharacterAnimation["CyborgNinja_Run_Armed"].speed = 2f;
		CharacterAnimation["CyborgNinja_Run_Unarmed"].speed = 2f;
		CharacterAnimation["f02_laugh_04"].speed = 2f;
	}

	private void Update()
	{
		if (!StudentManager.Eighties && !NoDebug && Input.GetKeyDown(KeyCode.LeftAlt))
		{
			CinematicCamera.SetActive(value: false);
		}
		if (!PauseScreen.Show)
		{
			UpdateMovement();
			UpdatePoisoning();
			if (!Laughing)
			{
				MyAudio.volume -= Time.deltaTime * 2f;
			}
			else if (PickUp != null && !PickUp.Clothing && !PickUp.LeftHand)
			{
				CharacterAnimation[CarryAnims[1]].weight = Mathf.Lerp(CharacterAnimation[CarryAnims[1]].weight, 1f, Time.deltaTime * 10f);
			}
			if (!Mopping)
			{
				CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(CharacterAnimation["f02_mopping_00"].weight, 0f, Time.deltaTime * 10f);
			}
			else
			{
				CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(CharacterAnimation["f02_mopping_00"].weight, 1f, Time.deltaTime * 10f);
				if (Input.GetButtonUp(InputNames.Xbox_A) || Input.GetKeyDown(KeyCode.Escape))
				{
					Mopping = false;
				}
			}
			if (LaughIntensity == 0f)
			{
				for (ID = 0; ID < CarryAnims.Length; ID++)
				{
					string text = CarryAnims[ID];
					if (PickUp != null && CarryAnimID == ID && !Mopping && !Dipping && !Pouring && !BucketDropping && !Digging && !Burying && !WritingName)
					{
						CharacterAnimation[text].weight = Mathf.Lerp(CharacterAnimation[text].weight, 1f, Time.deltaTime * 10f);
					}
					else
					{
						CharacterAnimation[text].weight = Mathf.Lerp(CharacterAnimation[text].weight, 0f, Time.deltaTime * 10f);
					}
				}
			}
			else if (Armed)
			{
				CharacterAnimation["f02_mopCarry_00"].weight = Mathf.Lerp(CharacterAnimation["f02_mopCarry_00"].weight, 1f, Time.deltaTime * 10f);
			}
			if (Noticed && !Attacking && !Struggling && !Collapse)
			{
				if (ShoulderCamera.NoticedTimer < 1f)
				{
					CharacterAnimation.CrossFade("f02_scaredIdle_00");
				}
				targetRotation = Quaternion.LookRotation(Senpai.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
				base.transform.localEulerAngles = new Vector3(0f, base.transform.localEulerAngles.y, base.transform.localEulerAngles.z);
				if (Vector3.Distance(base.transform.position, Senpai.position) < 1.25f)
				{
					MyController.Move(base.transform.forward * (Time.deltaTime * -2f));
				}
			}
			UpdateEffects();
			UpdateTalking();
			UpdateAttacking();
			UpdateSlouch();
			if (!Noticed)
			{
				RightYandereEye.material.color = new Color(RightYandereEye.material.color.r, RightYandereEye.material.color.g, RightYandereEye.material.color.b, 1f - Sanity / 100f);
				LeftYandereEye.material.color = new Color(LeftYandereEye.material.color.r, LeftYandereEye.material.color.g, LeftYandereEye.material.color.b, 1f - Sanity / 100f);
				EyeShrink = Mathf.Lerp(EyeShrink, 0.5f * (1f - Sanity / 100f), Time.deltaTime * 10f);
			}
			UpdateTwitch();
			UpdateWarnings();
			if (!NoDebug)
			{
				UpdateDebugFunctionality();
			}
			if (!EasterEggMenu.activeInHierarchy && !DebugMenu.activeInHierarchy && !Aiming && CanMove && Time.timeScale > 0f && !StudentManager.TutorialActive && !StudentManager.KokonaTutorial && Input.GetKeyDown(KeyCode.Escape))
			{
				PauseScreen.QuitLabel.text = "Do you wish to return to the main menu?";
				PauseScreen.YesLabel.text = "Yes";
				PauseScreen.HomeButton.SetActive(value: false);
				PauseScreen.JumpToQuit();
			}
			if (base.transform.position.y < 0f)
			{
				base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			}
			if (base.transform.position.z < -99.5f)
			{
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -99.5f);
			}
			base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, 0f);
		}
		else
		{
			MyAudio.volume -= 1f / 3f;
		}
	}

	private void GoToPKDir(PKDirType pkDir, string sansAnim, Vector3 ragdollLocalPos)
	{
		CharacterAnimation.CrossFade(sansAnim);
		RagdollPK.transform.localPosition = ragdollLocalPos;
		if (PKDir != pkDir)
		{
			AudioSource.PlayClipAtPoint(Slam, base.transform.position + Vector3.up);
		}
		PKDir = pkDir;
	}

	private void UpdateMovement()
	{
		if (CanMove)
		{
			if (!ToggleRun)
			{
				Running = false;
				if (Input.GetButton(InputNames.Xbox_LB))
				{
					Running = true;
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_LB))
			{
				Running = !Running;
			}
			MyController.Move(Physics.gravity * Time.deltaTime);
			v = Input.GetAxis("Vertical");
			h = Input.GetAxis("Horizontal");
			FlapSpeed = Mathf.Abs(v) + Mathf.Abs(h);
			if (Selfie)
			{
				v = -1f * v;
				h = -1f * h;
				if (Input.GetKeyDown("z"))
				{
					SelfieID++;
					if (SelfieID > 1)
					{
						SelfieID = 0;
					}
				}
			}
			if (Frozen)
			{
				v = 0f;
				h = 0f;
			}
			if (!Aiming && !PreparingThrow)
			{
				Vector3 vector = MainCamera.transform.TransformDirection(Vector3.forward);
				vector.y = 0f;
				vector = vector.normalized;
				Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
				targetDirection = h * vector2 + v * vector;
				if (targetDirection != Vector3.zero)
				{
					targetRotation = Quaternion.LookRotation(targetDirection);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
				}
				else
				{
					targetRotation = new Quaternion(0f, 0f, 0f, 0f);
				}
				if (v != 0f || h != 0f)
				{
					if (Running && Vector3.Distance(base.transform.position, Senpai.position) > 1f)
					{
						if (Stance.Current == StanceType.Crouching)
						{
							CharacterAnimation.CrossFade(CrouchRunAnim);
							MyController.Move(base.transform.forward * (CrouchRunSpeed + (float)(PhysicalGrade + SpeedBonus) * 0.25f) * Time.deltaTime);
						}
						else if (!Dragging && !Mopping)
						{
							CharacterAnimation.CrossFade(RunAnim);
							MyController.Move(base.transform.forward * (RunSpeed + (float)(PhysicalGrade + SpeedBonus) * 0.25f) * Time.deltaTime);
						}
						else if (Mopping)
						{
							CharacterAnimation.CrossFade(WalkAnim);
							MyController.Move(base.transform.forward * (WalkSpeed * Time.deltaTime));
						}
						if (!StudentManager.TutorialActive && Stance.Current == StanceType.Crawling)
						{
							Stance.Current = StanceType.Crouching;
							Crouch();
						}
					}
					else if (!Dragging)
					{
						if (Stance.Current == StanceType.Crawling)
						{
							CharacterAnimation.CrossFade(CrawlWalkAnim);
							MyController.Move(base.transform.forward * (CrawlSpeed * Time.deltaTime));
						}
						else if (Stance.Current == StanceType.Crouching)
						{
							CharacterAnimation[CrouchWalkAnim].speed = 1f;
							CharacterAnimation.CrossFade(CrouchWalkAnim);
							MyController.Move(base.transform.forward * (CrouchWalkSpeed * Time.deltaTime));
						}
						else
						{
							CharacterAnimation.CrossFade(WalkAnim);
							if (NearSenpai)
							{
								for (int i = 1; i < 6; i++)
								{
									if (i != Creepiness)
									{
										CharacterAnimation[CreepyIdles[i]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyIdles[i]].weight, 0f, Time.deltaTime);
										CharacterAnimation[CreepyWalks[i]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyWalks[i]].weight, 0f, Time.deltaTime);
									}
								}
								CharacterAnimation[CreepyIdles[Creepiness]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyIdles[Creepiness]].weight, 0f, Time.deltaTime);
								CharacterAnimation[CreepyWalks[Creepiness]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyWalks[Creepiness]].weight, 1f, Time.deltaTime);
							}
							MyController.Move(base.transform.forward * (WalkSpeed * Time.deltaTime));
						}
					}
					else
					{
						CharacterAnimation.CrossFade("f02_dragWalk_01");
						MyController.Move(base.transform.forward * (WalkSpeed * Time.deltaTime));
					}
				}
				else if (!Dragging)
				{
					if (Stance.Current == StanceType.Crawling)
					{
						CharacterAnimation.CrossFade(CrawlIdleAnim);
					}
					else if (Stance.Current == StanceType.Crouching)
					{
						CharacterAnimation.CrossFade(CrouchIdleAnim);
					}
					else
					{
						CharacterAnimation.CrossFade(IdleAnim);
						if (NearSenpai)
						{
							for (int j = 1; j < 6; j++)
							{
								if (j != Creepiness)
								{
									CharacterAnimation[CreepyIdles[j]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyIdles[j]].weight, 0f, Time.deltaTime);
									CharacterAnimation[CreepyWalks[j]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyWalks[j]].weight, 0f, Time.deltaTime);
								}
							}
							CharacterAnimation[CreepyIdles[Creepiness]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyIdles[Creepiness]].weight, 1f, Time.deltaTime);
							CharacterAnimation[CreepyWalks[Creepiness]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyWalks[Creepiness]].weight, 0f, Time.deltaTime);
						}
					}
				}
				else
				{
					CharacterAnimation.CrossFade("f02_dragIdle_02");
				}
			}
			else
			{
				if (v != 0f || h != 0f)
				{
					if (Stance.Current == StanceType.Crawling)
					{
						CharacterAnimation.CrossFade(CrawlWalkAnim);
						MyController.Move(base.transform.forward * (CrawlSpeed * Time.deltaTime * v));
						MyController.Move(base.transform.right * (CrawlSpeed * Time.deltaTime * h));
					}
					else if (Stance.Current == StanceType.Crouching)
					{
						CharacterAnimation.CrossFade(CrouchWalkAnim);
						MyController.Move(base.transform.forward * (CrouchWalkSpeed * Time.deltaTime * v));
						MyController.Move(base.transform.right * (CrouchWalkSpeed * Time.deltaTime * h));
					}
					else
					{
						CharacterAnimation.CrossFade(WalkAnim);
						MyController.Move(base.transform.forward * (WalkSpeed * Time.deltaTime * v));
						MyController.Move(base.transform.right * (WalkSpeed * Time.deltaTime * h));
					}
				}
				else if (Stance.Current == StanceType.Crawling)
				{
					CharacterAnimation.CrossFade(CrawlIdleAnim);
				}
				else if (Stance.Current == StanceType.Crouching)
				{
					CharacterAnimation.CrossFade(CrouchIdleAnim);
				}
				else
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (!RPGCamera.invertAxisY)
				{
					Bend += Input.GetAxis("Mouse Y") * RPGCamera.sensitivity * 72f * Time.deltaTime;
				}
				else
				{
					Bend -= Input.GetAxis("Mouse Y") * RPGCamera.sensitivity * 72f * Time.deltaTime;
				}
				if (Stance.Current == StanceType.Crawling)
				{
					if (Bend < 0f)
					{
						Bend = 0f;
					}
				}
				else if (Stance.Current == StanceType.Crouching)
				{
					if (Bend < -45f)
					{
						Bend = -45f;
					}
				}
				else if (Bend < -85f)
				{
					Bend = -85f;
				}
				if (Bend > 85f)
				{
					Bend = 85f;
				}
				if (!RPGCamera.invertAxisX)
				{
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * RPGCamera.sensitivity * 72f * Time.deltaTime, base.transform.localEulerAngles.z);
				}
				else
				{
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y - Input.GetAxis("Mouse X") * RPGCamera.sensitivity * 72f * Time.deltaTime, base.transform.localEulerAngles.z);
				}
			}
			if (!NearSenpai)
			{
				if (!Input.GetButton(InputNames.Xbox_A) && !Input.GetButton(InputNames.Xbox_B) && !Input.GetButton(InputNames.Xbox_X) && !Input.GetButton(InputNames.Xbox_Y) && !StudentManager.Clock.UpdateBloom && !Frozen && !CannotAim && (Input.GetAxis(InputNames.Xbox_LT) > 0.5f || Input.GetMouseButton(InputNames.Mouse_RMB)))
				{
					if ((PickUp != null && PickUp.BangSnaps) || (PickUp != null && PickUp.StinkBombs))
					{
						if (!PreparingThrow && !Throwing)
						{
							PreviousPersona = Persona;
							PreviousIdleAnim = IdleAnim;
							PreviousWalkAnim = WalkAnim;
							IdleAnim = DefaultIdleAnim;
							WalkAnim = DefaultWalkAnim;
							Debug.Log("IdleAnim is now " + IdleAnim + ". Once we stop aiming, we have to return to " + PreviousIdleAnim + ".");
							base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, MainCamera.transform.eulerAngles.y, base.transform.eulerAngles.z);
							TargetStudent = null;
							PreparingThrow = true;
							PrepareThrowTimer = 0f;
							RPGCamera.enabled = false;
							ShoulderCamera.OverShoulder = true;
							if (Input.GetAxis(InputNames.Xbox_LT) > 0.5f)
							{
								UsingController = true;
							}
							NewArc.gameObject.SetActive(value: true);
							PromptBar.ClearButtons();
							PromptBar.Label[1].text = "Subtle/Obvious";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
					}
					else
					{
						if (Inventory.RivalPhone)
						{
							if (Input.GetButtonDown(InputNames.Xbox_LB))
							{
								CharacterAnimation["f02_cameraPose_00"].weight = 0f;
								CharacterAnimation["f02_selfie_00"].weight = 0f;
								CharacterAnimation["f02_selfie_01"].weight = 0f;
								if (!RivalPhone)
								{
									SmartphoneRenderer.material.mainTexture = RivalPhoneTexture;
									PhonePromptBar.Label.text = "SWITCH TO YOUR PHONE";
									RivalPhone = true;
								}
								else
								{
									SmartphoneRenderer.material.mainTexture = YanderePhoneTexture;
									PhonePromptBar.Label.text = "SWITCH TO STOLEN PHONE";
									RivalPhone = false;
								}
							}
						}
						else if (!Selfie && Input.GetButtonDown(InputNames.Xbox_LB) && !StudentManager.Eighties)
						{
							if (!AR)
							{
								Smartphone.cullingMask |= 1 << LayerMask.NameToLayer("Miyuki");
								AR = true;
							}
							else
							{
								Smartphone.cullingMask &= ~(1 << LayerMask.NameToLayer("Miyuki"));
								AR = false;
							}
						}
						if (Input.GetAxis(InputNames.Xbox_LT) > 0.5f)
						{
							UsingController = true;
						}
						if (!Aiming)
						{
							PauseScreen.NewSettings.Profile.depthOfField.enabled = false;
							if (CameraEffects.OneCamera)
							{
								MainCamera.clearFlags = CameraClearFlags.Color;
								MainCamera.farClipPlane = 0.02f;
								HandCamera.clearFlags = CameraClearFlags.Color;
							}
							else
							{
								MainCamera.clearFlags = CameraClearFlags.Skybox;
								MainCamera.farClipPlane = OptionGlobals.DrawDistance;
								HandCamera.clearFlags = CameraClearFlags.Depth;
							}
							base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, MainCamera.transform.eulerAngles.y, base.transform.eulerAngles.z);
							CharacterAnimation.Play(IdleAnim);
							if (!StudentManager.Eighties)
							{
								Smartphone.transform.parent.gameObject.SetActive(value: true);
								Blur.enabled = true;
								if (!CinematicCamera.activeInHierarchy)
								{
									DisableHairAndAccessories();
								}
								HandCamera.gameObject.SetActive(value: true);
								EmptyHands();
								if (!StudentManager.KokonaTutorial)
								{
									PhonePromptBar.Panel.enabled = true;
									PhonePromptBar.Show = true;
								}
							}
							else
							{
								MainCamera.nearClipPlane = 0.266666f;
								HandCamera.nearClipPlane = 0.35f;
								Smartphone.nearClipPlane = 0.266666f;
							}
							ShoulderCamera.AimingCamera = true;
							YandereVision = false;
							Mopping = false;
							Selfie = false;
							Aiming = true;
							MyController.radius = 0.45f;
							if (Inventory.RivalPhone)
							{
								if (!RivalPhone)
								{
									PhonePromptBar.Label.text = "SWITCH TO STOLEN PHONE";
								}
								else
								{
									PhonePromptBar.Label.text = "SWITCH TO YOUR PHONE";
								}
							}
							else
							{
								PhonePromptBar.Label.text = "AR GAME ON/OFF";
							}
							Time.timeScale = 1f;
							UpdateSelfieStatus();
							StudentManager.UpdatePanties(Status: true);
							CameraEffects.SmartphoneCamera.depthTextureMode = DepthTextureMode.DepthNormals;
							if (Club == ClubType.Newspaper)
							{
								ClubAccessories[(int)Club].transform.localScale = new Vector3(1f, 1f, 0.9f);
							}
						}
					}
				}
				PermitLaugh += Time.deltaTime;
				if (!Aiming && !Accessories[9].activeInHierarchy && !Accessories[16].activeInHierarchy && !Pod.activeInHierarchy && PermitLaugh > 1f && !Chased && !Input.GetButton(InputNames.Xbox_A))
				{
					if (Input.GetButton(InputNames.Xbox_RB))
					{
						if (MagicalGirl)
						{
							if (Armed && EquippedWeapon.WeaponID == 14 && Input.GetButtonDown(InputNames.Xbox_RB) && !ShootingBeam)
							{
								AudioSource.PlayClipAtPoint(LoveLoveBeamVoice, base.transform.position);
								CharacterAnimation["f02_LoveLoveBeam_00"].time = 0f;
								CharacterAnimation.CrossFade("f02_LoveLoveBeam_00");
								ShootingBeam = true;
								CanMove = false;
							}
						}
						else if (BlackRobe.activeInHierarchy)
						{
							if (Input.GetButtonDown(InputNames.Xbox_RB))
							{
								AudioSource.PlayClipAtPoint(SithOn, base.transform.position);
							}
							SithTrailEnd1.localPosition = new Vector3(-1f, 0f, 0f);
							SithTrailEnd2.localPosition = new Vector3(1f, 0f, 0f);
							Beam[0].Play();
							Beam[1].Play();
							Beam[2].Play();
							Beam[3].Play();
							if (Input.GetButtonDown(InputNames.Xbox_X))
							{
								CharacterAnimation["f02_sithAttack_00"].time = 0f;
								CharacterAnimation.Play("f02_sithAttack_00");
								SithBeam[1].Damage = 10f;
								SithBeam[2].Damage = 10f;
								SithAttacking = true;
								CanMove = false;
								SithPrefix = "";
								AttackPrefix = "sith";
							}
							if (Input.GetButtonDown(InputNames.Xbox_Y))
							{
								CharacterAnimation["f02_sithAttackHard_00"].time = 0f;
								CharacterAnimation.Play("f02_sithAttackHard_00");
								SithBeam[1].Damage = 20f;
								SithBeam[2].Damage = 20f;
								SithAttacking = true;
								CanMove = false;
								SithPrefix = "Hard";
								AttackPrefix = "sith";
							}
						}
						else if (FloppyHat.activeInHierarchy)
						{
							if (Input.GetButtonDown(InputNames.Xbox_RB))
							{
								LongFingers = !LongFingers;
								if (LongFingers)
								{
									AudioSource.PlayClipAtPoint(EmptyDemon.MouthOpen, base.transform.position);
								}
								else
								{
									AudioSource.PlayClipAtPoint(EmptyDemon.MouthClose, base.transform.position);
								}
							}
						}
						else if (Input.GetButtonDown(InputNames.Xbox_RB) && SpiderLegs.activeInHierarchy)
						{
							SpiderGrow = !SpiderGrow;
							if (SpiderGrow)
							{
								AudioSource.PlayClipAtPoint(EmptyDemon.MouthOpen, base.transform.position);
							}
							else
							{
								AudioSource.PlayClipAtPoint(EmptyDemon.MouthClose, base.transform.position);
							}
							StudentManager.UpdateStudents();
						}
						YandereTimer += Time.deltaTime;
						if (YandereTimer > 0.5f)
						{
							if (!Sans && !BlackRobe.activeInHierarchy)
							{
								YandereVision = true;
								if (!AudioPlayed)
								{
									YandereVisionAudio.clip = YandereVisionOn;
									YandereVisionAudio.Play();
									YandereVisionDrone.Play();
									AudioPlayed = true;
								}
							}
							else if (Sans)
							{
								SansEyes[0].SetActive(value: true);
								SansEyes[1].SetActive(value: true);
								GlowEffect.Play();
								SummonBones = true;
								YandereTimer = 0f;
								CanMove = false;
							}
						}
					}
					else
					{
						if (BlackRobe.activeInHierarchy)
						{
							SithTrailEnd1.localPosition = new Vector3(0f, 0f, 0f);
							SithTrailEnd2.localPosition = new Vector3(0f, 0f, 0f);
							if (Input.GetButtonUp(InputNames.Xbox_RB))
							{
								AudioSource.PlayClipAtPoint(SithOff, base.transform.position);
							}
							Beam[0].Stop();
							Beam[1].Stop();
							Beam[2].Stop();
							Beam[3].Stop();
						}
						if (YandereVision)
						{
							YandereVision = false;
						}
					}
					if (Input.GetButtonUp(InputNames.Xbox_RB))
					{
						if (CanCloak && !WearingRaincoat)
						{
							Invisible = !Invisible;
							Debug.Log("Invisibility is: " + Invisible);
							if (Invisible)
							{
								Cloak();
							}
							else
							{
								Decloak();
							}
						}
						if (Stance.Current != StanceType.Crouching && Stance.Current != StanceType.Crawling)
						{
							if (YandereTimer < 0.5f && !Dragging && !Carrying && !Pod.activeInHierarchy && !PreparingThrow && !Laughing)
							{
								if (Sans)
								{
									BlasterStage++;
									if (BlasterStage > 5)
									{
										BlasterStage = 1;
									}
									GameObject obj = Object.Instantiate(BlasterSet[BlasterStage], base.transform.position, Quaternion.identity);
									obj.transform.position = base.transform.position;
									obj.transform.rotation = base.transform.rotation;
									AudioSource.PlayClipAtPoint(BlasterClip, base.transform.position + Vector3.up);
									CharacterAnimation["f02_sansBlaster_00"].time = 0f;
									CharacterAnimation.Play("f02_sansBlaster_00");
									SansEyes[0].SetActive(value: true);
									SansEyes[1].SetActive(value: true);
									GlowEffect.Play();
									Blasting = true;
									CanMove = false;
								}
								else if (!BlackRobe.activeInHierarchy)
								{
									if (Kagune[0].activeInHierarchy)
									{
										if (!SwingKagune)
										{
											AudioSource.PlayClipAtPoint(KaguneSwoosh, base.transform.position + Vector3.up);
											SwingKagune = true;
										}
									}
									else if (Gazing || Shipgirl)
									{
										if (Gazing)
										{
											CharacterAnimation["f02_gazerSnap_00"].time = 0f;
											CharacterAnimation.CrossFade("f02_gazerSnap_00");
										}
										else
										{
											CharacterAnimation["f02_shipGirlSnap_00"].time = 0f;
											CharacterAnimation.CrossFade("f02_shipGirlSnap_00");
										}
										Snapping = true;
										CanMove = false;
									}
									else if (WitchMode)
									{
										if (!StoppingTime)
										{
											CharacterAnimation["f02_summonStand_00"].time = 0f;
											if (Freezing)
											{
												AudioSource.PlayClipAtPoint(StartShout, base.transform.position);
											}
											else
											{
												AudioSource.PlayClipAtPoint(StopShout, base.transform.position);
											}
											Freezing = !InvertSphere.gameObject.activeInHierarchy;
											StoppingTime = true;
											CanMove = false;
											MyAudio.Stop();
											Egg = true;
										}
									}
									else if (PickUp != null && PickUp.CarryAnimID == 10)
									{
										StudentManager.NoteWindow.gameObject.SetActive(value: true);
										StudentManager.NoteWindow.Show = true;
										PromptBar.Show = true;
										Blur.enabled = true;
										CanMove = false;
										Time.timeScale = 0.0001f;
										HUD.alpha = 0f;
										PromptBar.Label[0].text = "Confirm";
										PromptBar.Label[1].text = "Cancel";
										PromptBar.Label[4].text = "Select";
										PromptBar.UpdateButtons();
									}
									else if (!FalconHelmet.activeInHierarchy && !Cape.activeInHierarchy && !MagicalGirl && !FloppyHat.activeInHierarchy)
									{
										if (!Xtan)
										{
											if (!NoLaugh)
											{
												if (!CirnoHair.activeInHierarchy && !TornadoHair.activeInHierarchy && !BladeHair.activeInHierarchy)
												{
													LaughAnim = "f02_laugh_01";
													LaughClip = Laugh1;
													LaughIntensity += 1f;
													MyAudio.clip = LaughClip;
													MyAudio.time = 0f;
													MyAudio.Play();
												}
												GiggleLines.Play();
												Object.Instantiate(GiggleDisc, base.transform.position + Vector3.up, Quaternion.identity);
												AnnoyingGiggleTimer = 1f;
												MyAudio.volume = 1f;
												LaughTimer = 0.5f;
												Laughing = true;
												Mopping = false;
												CanMove = false;
												Teeth.SetActive(value: false);
											}
											else
											{
												NotificationManager.CustomText = "No giggling or laughing allowed.";
												NotificationManager.DisplayNotification(NotificationType.Custom);
											}
										}
										else if (LongHair[0].gameObject.activeInHierarchy)
										{
											LongHair[0].gameObject.SetActive(value: false);
											BlackEyePatch.SetActive(value: false);
											SlenderHair[0].transform.parent.gameObject.SetActive(value: true);
											SlenderHair[0].SetActive(value: true);
											SlenderHair[1].SetActive(value: true);
										}
										else
										{
											LongHair[0].gameObject.SetActive(value: true);
											BlackEyePatch.SetActive(value: true);
											SlenderHair[0].transform.parent.gameObject.SetActive(value: true);
											SlenderHair[0].SetActive(value: false);
											SlenderHair[1].SetActive(value: false);
										}
									}
									else if (!Punching && !FloppyHat.activeInHierarchy)
									{
										if (FalconHelmet.activeInHierarchy)
										{
											GameObject obj2 = Object.Instantiate(FalconWindUp);
											obj2.transform.parent = ItemParent;
											obj2.transform.localPosition = Vector3.zero;
											AudioClipPlayer.PlayAttached(FalconPunchVoice, MainCamera.transform, 5f, 10f);
											CharacterAnimation["f02_falconPunch_00"].time = 0f;
											CharacterAnimation.Play("f02_falconPunch_00");
											FalconSpeed = 0f;
										}
										else
										{
											GameObject obj3 = Object.Instantiate(FalconWindUp);
											obj3.transform.parent = ItemParent;
											obj3.transform.localPosition = Vector3.zero;
											AudioSource.PlayClipAtPoint(OnePunchVoices[Random.Range(0, OnePunchVoices.Length)], base.transform.position + Vector3.up);
											CharacterAnimation["f02_onePunch_00"].time = 0f;
											CharacterAnimation.CrossFade("f02_onePunch_00", 0.15f);
										}
										Punching = true;
										CanMove = false;
									}
								}
							}
						}
						else if (YandereFade == 100f && !NoLaugh)
						{
							MyAudio.clip = Laugh1;
							MyAudio.volume = 1f;
							MyAudio.time = 0f;
							MyAudio.Play();
							GiggleLines.Play();
							Object.Instantiate(GiggleDisc, base.transform.position + Vector3.up, Quaternion.identity);
							AnnoyingGiggleTimer = 1f;
						}
						else
						{
							NotificationManager.CustomText = "No giggling or laughing allowed.";
							NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						YandereTimer = 0f;
					}
				}
				bool flag = false;
				if (PreparingThrow || StudentManager.TutorialActive)
				{
					flag = true;
				}
				if (!flag)
				{
					if (Stance.Current != StanceType.Crouching && Stance.Current != StanceType.Crawling)
					{
						if (Input.GetButtonDown(InputNames.Xbox_RS))
						{
							CrouchButtonDown = true;
							YandereVision = false;
							Stance.Current = StanceType.Crouching;
							Crouch();
							if (!Armed || !EquippedWeapon.Concealable)
							{
								EmptyHands();
							}
						}
					}
					else
					{
						if (Stance.Current == StanceType.Crouching)
						{
							if (Input.GetButton(InputNames.Xbox_RS) && !CameFromCrouch)
							{
								CrawlTimer += Time.deltaTime;
							}
							if (CrawlTimer > 0.5f)
							{
								if (!Selfie)
								{
									EmptyHands();
									YandereVision = false;
									Stance.Current = StanceType.Crawling;
									CrawlTimer = 0f;
									Crawl();
								}
							}
							else if (Input.GetButtonUp(InputNames.Xbox_RS) && !CrouchButtonDown && !CameFromCrouch)
							{
								Stance.Current = StanceType.Standing;
								CrawlTimer = 0f;
								Uncrouch();
							}
						}
						else if (Input.GetButtonDown(InputNames.Xbox_RS))
						{
							CameFromCrouch = true;
							Stance.Current = StanceType.Crouching;
							Crouch();
						}
						if (Input.GetButtonUp(InputNames.Xbox_RS))
						{
							CrouchButtonDown = false;
							CameFromCrouch = false;
							CrawlTimer = 0f;
						}
					}
				}
			}
			if (Aiming)
			{
				if (!StudentManager.Eighties || (StudentManager.Eighties && Club == ClubType.Photography))
				{
					if (!RivalPhone && !StudentManager.Eighties && !StudentManager.KokonaTutorial && Input.GetButtonDown(InputNames.Xbox_A))
					{
						Selfie = !Selfie;
						UpdateSelfieStatus();
					}
					if (!Selfie)
					{
						if (!StudentManager.Eighties)
						{
							CharacterAnimation["f02_cameraPose_00"].weight = Mathf.Lerp(CharacterAnimation["f02_cameraPose_00"].weight, 1f, Time.deltaTime * 10f);
							CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(CharacterAnimation["f02_selfie_00"].weight, 0f, Time.deltaTime * 10f);
							CharacterAnimation["f02_selfie_01"].weight = Mathf.Lerp(CharacterAnimation["f02_selfie_01"].weight, 0f, Time.deltaTime * 10f);
						}
					}
					else
					{
						CharacterAnimation["f02_cameraPose_00"].weight = Mathf.Lerp(CharacterAnimation["f02_cameraPose_00"].weight, 0f, Time.deltaTime * 10f);
						if (SelfieID == 0)
						{
							CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(CharacterAnimation["f02_selfie_00"].weight, 1f, Time.deltaTime * 10f);
							CharacterAnimation["f02_selfie_01"].weight = Mathf.Lerp(CharacterAnimation["f02_selfie_01"].weight, 0f, Time.deltaTime * 10f);
						}
						else
						{
							CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(CharacterAnimation["f02_selfie_00"].weight, 0f, Time.deltaTime * 10f);
							CharacterAnimation["f02_selfie_01"].weight = Mathf.Lerp(CharacterAnimation["f02_selfie_01"].weight, 1f, Time.deltaTime * 10f);
						}
						if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							if (!SelfieGuide.activeInHierarchy)
							{
								SelfieGuide.SetActive(value: true);
							}
							else
							{
								SelfieGuide.SetActive(value: false);
							}
						}
					}
					if (ClubAccessories[7].activeInHierarchy && (Input.GetAxis("DpadY") != 0f || Input.GetAxis("Mouse ScrollWheel") != 0f || Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.LeftShift)))
					{
						if (Input.GetKey(KeyCode.Tab))
						{
							Smartphone.fieldOfView -= Time.deltaTime * 100f;
						}
						if (Input.GetKey(KeyCode.LeftShift))
						{
							Smartphone.fieldOfView += Time.deltaTime * 100f;
						}
						Smartphone.fieldOfView -= Input.GetAxis("DpadY");
						Smartphone.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 10f;
						if (Smartphone.fieldOfView > 60f)
						{
							Smartphone.fieldOfView = 60f;
						}
						if (Smartphone.fieldOfView < 30f)
						{
							Smartphone.fieldOfView = 30f;
						}
					}
					if (Input.GetAxis(InputNames.Xbox_RT) == 1f || Input.GetMouseButtonDown(InputNames.Mouse_LMB) || Input.GetButtonDown(InputNames.Xbox_RB))
					{
						RPGCamera.enabled = false;
						PauseScreen.CorrectingTime = false;
						Time.timeScale = 0.0001f;
						CanMove = false;
						Shutter.Snap();
					}
				}
				if (Time.timeScale > 0.0001f && ((UsingController && Input.GetAxis(InputNames.Xbox_LT) < 0.5f) || (!UsingController && !Input.GetMouseButton(InputNames.Mouse_RMB))))
				{
					StopAiming();
				}
				if (!StudentManager.Eighties && !NoDebug)
				{
					if (Input.GetKey(KeyCode.LeftAlt))
					{
						if (!CinematicCamera.activeInHierarchy)
						{
							if (CinematicTimer > 0f)
							{
								CinematicCamera.transform.eulerAngles = Smartphone.transform.eulerAngles;
								CinematicCamera.transform.position = Smartphone.transform.position;
								CinematicCamera.SetActive(value: true);
								CinematicTimer = 0f;
								UpdateHair();
								StopAiming();
							}
							CinematicTimer += 1f;
						}
					}
					else
					{
						CinematicTimer = 0f;
					}
				}
			}
			if (PreparingThrow && Time.timeScale > 0.0001f)
			{
				if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					PrepareThrowTimer = 0f;
					Obvious = !Obvious;
				}
				if (Input.GetAxis(InputNames.Xbox_RT) > 0.5f || Input.GetMouseButtonDown(InputNames.Mouse_LMB))
				{
					CharacterAnimation["f02_prepareThrow_00"].weight = 0f;
					CharacterAnimation["f02_subtleThrowIdle_00"].weight = 0f;
					CharacterAnimation["f02_obviousThrowIdle_00"].weight = 0f;
					CharacterAnimation["f02_throw_00"].speed = 2f;
					CharacterAnimation["f02_throw_00"].time = 0f;
					CharacterAnimation["f02_subtleThrow_00"].speed = 2f;
					CharacterAnimation["f02_obviousThrow_00"].speed = 2f;
					CharacterAnimation["f02_subtleThrow_00"].time = 0f;
					CharacterAnimation["f02_obviousThrow_00"].time = 0f;
					if (Obvious)
					{
						CharacterAnimation.Play("f02_throw_00");
					}
					else
					{
						CharacterAnimation.Play("f02_subtleThrow_00");
					}
					IdleAnim = PreviousIdleAnim;
					WalkAnim = PreviousWalkAnim;
					PreparingThrow = false;
					Throwing = true;
					CanMove = false;
					NewArc.gameObject.SetActive(value: false);
				}
				else if ((UsingController && Input.GetAxis(InputNames.Xbox_LT) < 0.5f) || (!UsingController && !Input.GetMouseButton(InputNames.Mouse_RMB)))
				{
					StopAiming();
				}
			}
			if (Gloved)
			{
				if (!Chased && Chasers == 0)
				{
					if (InputDevice.Type == InputDeviceType.Gamepad)
					{
						if (Input.GetAxis("DpadY") < -0.5f)
						{
							if (CharacterAnimation["f02_removeGloves_00"].time == 0f)
							{
								GloveTimer += Time.deltaTime;
							}
							if (GloveTimer > 0.5f)
							{
								CharacterAnimation.CrossFade("f02_removeGloves_00");
								Degloving = true;
								CanMove = false;
							}
						}
						else
						{
							GloveTimer = 0f;
						}
					}
					else if (Input.GetKey(KeyCode.Alpha1))
					{
						if (CharacterAnimation["f02_removeGloves_00"].time == 0f)
						{
							GloveTimer += Time.deltaTime;
						}
						if (GloveTimer > 0.1f)
						{
							CharacterAnimation.CrossFade("f02_removeGloves_00");
							Degloving = true;
							CanMove = false;
						}
					}
					else
					{
						GloveTimer = 0f;
					}
				}
				else
				{
					GloveTimer = 0f;
				}
			}
			if (Weapon[1] != null && DropTimer[2] == 0f)
			{
				if (InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (Input.GetAxis("DpadX") < -0.5f)
					{
						DropWeapon(1);
					}
					else
					{
						DropTimer[1] = 0f;
					}
				}
				else if (Input.GetKey(KeyCode.Alpha2))
				{
					DropWeapon(1);
				}
				else
				{
					DropTimer[1] = 0f;
				}
			}
			if (Weapon[2] != null && DropTimer[1] == 0f)
			{
				if (InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (Input.GetAxis("DpadX") > 0.5f)
					{
						DropWeapon(2);
					}
					else
					{
						DropTimer[2] = 0f;
					}
				}
				else if (Input.GetKey(KeyCode.Alpha3))
				{
					DropWeapon(2);
				}
				else
				{
					DropTimer[2] = 0f;
				}
			}
			if (Input.GetButtonDown(InputNames.Xbox_LS) || Input.GetKeyDown(KeyCode.T))
			{
				TrailTimer = 0f;
				if (NewTrail != null)
				{
					Object.Destroy(NewTrail);
				}
				NewTrail = Object.Instantiate(Trail, base.transform.position + base.transform.forward * 0.5f + Vector3.up * 0.1f, Quaternion.identity);
				if (SchemeGlobals.CurrentScheme == 0)
				{
					if (StudentManager.Tutorial != null && StudentManager.Tutorial.isActiveAndEnabled)
					{
						NewTrail.GetComponent<AIPath>().target = StudentManager.Tutorial.Destination[StudentManager.Tutorial.Phase];
					}
					else if (StudentManager.Tag.Target != null)
					{
						NewTrail.GetComponent<AIPath>().target = StudentManager.Students[StudentManager.TagStudentID].transform;
					}
					else
					{
						NewTrail.GetComponent<AIPath>().target = TrailWindow.Destinations[TrailWindow.Selected];
					}
				}
				else if (PauseScreen.Schemes.SchemeDestinations[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme)] != null)
				{
					NewTrail.GetComponent<AIPath>().target = PauseScreen.Schemes.SchemeDestinations[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme)];
				}
				else
				{
					Object.Destroy(NewTrail);
				}
			}
			if (Input.GetButton(InputNames.Xbox_LS) || Input.GetKey(KeyCode.T))
			{
				TrailTimer += Time.deltaTime;
				if (TrailTimer >= 1f)
				{
					PromptBar.ClearButtons();
					PromptBar.Label[1].text = "Exit";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					PromptParent.gameObject.SetActive(value: false);
					TrailWindow.gameObject.SetActive(value: true);
					Time.timeScale = 0.0001f;
				}
			}
			if (Armed)
			{
				for (ID = 0; ID < ArmedAnims.Length; ID++)
				{
					string text = ArmedAnims[ID];
					CharacterAnimation[text].weight = Mathf.Lerp(CharacterAnimation[text].weight, (EquippedWeapon.AnimID == ID) ? 1f : 0f, Time.deltaTime * 10f);
				}
			}
			else
			{
				StopArmedAnim();
			}
			if (ImmunityTimer > 0f)
			{
				ImmunityTimer = Mathf.MoveTowards(ImmunityTimer, 0f, Time.deltaTime);
			}
			if (TheftTimer > 0f)
			{
				TheftTimer = Mathf.MoveTowards(TheftTimer, 0f, Time.deltaTime);
				if (TheftTimer == 0f)
				{
					StolenObjectID = 0;
				}
			}
			if (WeaponTimer > 0f)
			{
				WeaponTimer = Mathf.MoveTowards(WeaponTimer, 0f, Time.deltaTime);
			}
			if (MurderousActionTimer > 0f)
			{
				MurderousActionTimer = Mathf.MoveTowards(MurderousActionTimer, 0f, Time.deltaTime);
				if (MurderousActionTimer == 0f)
				{
					TargetStudent = null;
				}
			}
			if (SuspiciousActionTimer > 0f)
			{
				SuspiciousActionTimer = Mathf.MoveTowards(SuspiciousActionTimer, 0f, Time.deltaTime);
				if (SuspiciousActionTimer == 0f)
				{
					CreatingTripwireTrap = false;
					CreatingBucketTrap = false;
				}
			}
			if (PotentiallyMurderousTimer > 0f)
			{
				Debug.Log("If a student sees a student being electrocuted right now, they should check for Yandere-chan.");
				PotentiallyMurderousTimer = Mathf.MoveTowards(PotentiallyMurderousTimer, 0f, Time.deltaTime);
			}
			if (AnnoyingGiggleTimer > 0f)
			{
				AnnoyingGiggleTimer = Mathf.MoveTowards(AnnoyingGiggleTimer, 0f, Time.deltaTime);
			}
			if (PotentiallyAnnoyingTimer > 0f)
			{
				PotentiallyAnnoyingTimer = Mathf.MoveTowards(PotentiallyAnnoyingTimer, 0f, Time.deltaTime);
			}
			if (Chased)
			{
				PreparedForStruggle = true;
				CanMove = false;
			}
			if (!Egg)
			{
				return;
			}
			if (Eating)
			{
				FollowHips = false;
				Attacking = false;
				CanMove = true;
				Eating = false;
				EatPhase = 0;
			}
			if (Pod.activeInHierarchy)
			{
				if (!SithAttacking)
				{
					if (LightSword.transform.parent != LightSwordParent)
					{
						LightSword.transform.parent = LightSwordParent;
						LightSword.transform.localPosition = new Vector3(0f, 0f, 0f);
						LightSword.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						LightSwordParticles.Play();
					}
					if (HeavySword.transform.parent != HeavySwordParent)
					{
						HeavySword.transform.parent = HeavySwordParent;
						HeavySword.transform.localPosition = new Vector3(0f, 0f, 0f);
						HeavySword.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						HeavySwordParticles.Play();
					}
				}
				if (Input.GetButtonDown(InputNames.Xbox_X))
				{
					LightSword.transform.parent = LeftItemParent;
					LightSword.transform.localPosition = new Vector3(-0.015f, 0f, 0f);
					LightSword.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
					LightSword.GetComponent<WeaponTrail>().enabled = true;
					LightSword.GetComponent<WeaponTrail>().Start();
					CharacterAnimation["f02_nierAttack_00"].time = 0f;
					CharacterAnimation.Play("f02_nierAttack_00");
					SithAttacking = true;
					CanMove = false;
					SithBeam[1].Damage = 10f;
					NierDamage = 10f;
					SithPrefix = "";
					AttackPrefix = "nier";
				}
				if (Input.GetButtonDown(InputNames.Xbox_Y))
				{
					HeavySword.transform.parent = ItemParent;
					HeavySword.transform.localPosition = new Vector3(-0.015f, 0f, 0f);
					HeavySword.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
					HeavySword.GetComponent<WeaponTrail>().enabled = true;
					HeavySword.GetComponent<WeaponTrail>().Start();
					CharacterAnimation["f02_nierAttackHard_00"].time = 0f;
					CharacterAnimation.Play("f02_nierAttackHard_00");
					SithAttacking = true;
					CanMove = false;
					SithBeam[1].Damage = 20f;
					NierDamage = 20f;
					SithPrefix = "Hard";
					AttackPrefix = "nier";
				}
			}
			if (WitchMode && Input.GetButtonDown(InputNames.Xbox_X) && InvertSphere.gameObject.activeInHierarchy)
			{
				CharacterAnimation["f02_fingerSnap_00"].time = 0f;
				CharacterAnimation.Play("f02_fingerSnap_00");
				CharacterAnimation.CrossFade(IdleAnim);
				Snapping = true;
				CanMove = false;
			}
			if (Armor[20].activeInHierarchy && Armor[20].transform.parent == ItemParent && (Input.GetButtonDown(InputNames.Xbox_X) || Input.GetButtonDown(InputNames.Xbox_Y)))
			{
				CharacterAnimation["f02_nierAttackHard_00"].time = 0f;
				CharacterAnimation.Play("f02_nierAttackHard_00");
				SithAttacking = true;
				CanMove = false;
				SithBeam[1].Damage = 20f;
				NierDamage = 20f;
				SithPrefix = "Hard";
				AttackPrefix = "nier";
			}
			if (LongFingers && Input.GetButtonDown(InputNames.Xbox_X) && !Swiping)
			{
				if (SwipeID == 1)
				{
					SwipeID = 0;
				}
				else
				{
					SwipeID++;
				}
				AudioSource.PlayClipAtPoint(Swoosh, base.transform.position + Vector3.up);
				CharacterAnimation["f02_sithAttack_0" + SwipeID].time = 0f;
				CharacterAnimation.Play("f02_sithAttack_0" + SwipeID);
				Swiping = true;
				CanMove = false;
			}
			if (TitanSword[0].activeInHierarchy)
			{
				UpdateODM();
			}
			return;
		}
		if (Egg && TitanSword[0].activeInHierarchy)
		{
			UpdateODM();
		}
		if (Chased && !Sprayed && !Attacking && !Dumping && !Dropping && !StudentManager.PinningDown && !DelinquentFighting && !Struggling && !ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
		{
			if (Pursuer != null)
			{
				targetRotation = Quaternion.LookRotation(Pursuer.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
				CharacterAnimation.CrossFade("f02_readyToFight_00");
				if (Dragging || Carrying)
				{
					EmptyHands();
				}
			}
			else
			{
				Debug.Log("If the code got here, it means that Yandere-chan is being chased, but Pursuer is null.");
				Debug.Log("This COULD mean that there was a Pursuer, who is now dead. Or, it could mean something else.");
			}
		}
		StopArmedAnim();
		if (Dumping)
		{
			targetRotation = Quaternion.LookRotation(Incinerator.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			MoveTowardsTarget(Incinerator.transform.position + Vector3.right * -2f);
			if (DumpTimer == 0f && Carrying)
			{
				CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
			}
			DumpTimer += Time.deltaTime;
			if (DumpTimer > 1f)
			{
				if (Ragdoll != null && !Ragdoll.GetComponent<RagdollScript>().Dumped)
				{
					DumpRagdoll(RagdollDumpType.Incinerator);
				}
				CharacterAnimation.CrossFade("f02_carryDisposeA_00");
				if (CharacterAnimation["f02_carryDisposeA_00"].time >= CharacterAnimation["f02_carryDisposeA_00"].length)
				{
					Incinerator.Prompt.enabled = true;
					Incinerator.Ready = true;
					Incinerator.Open = false;
					Dragging = false;
					Dumping = false;
					CanMove = true;
					Ragdoll = null;
					StopCarrying();
					DumpTimer = 0f;
				}
			}
		}
		if (Chipping)
		{
			targetRotation = Quaternion.LookRotation(WoodChipper.gameObject.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			MoveTowardsTarget(WoodChipper.DumpPoint.position);
			if (DumpTimer == 0f && Carrying)
			{
				CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
			}
			DumpTimer += Time.deltaTime;
			if (DumpTimer > 1f)
			{
				if (!Ragdoll.GetComponent<RagdollScript>().Dumped)
				{
					DumpRagdoll(RagdollDumpType.WoodChipper);
				}
				CharacterAnimation.CrossFade("f02_carryDisposeA_00");
				if ((double)CharacterAnimation["f02_carryDisposeA_00"].time >= 4.5 && WoodChipper.Acid && !WoodChipper.MyAudio.isPlaying)
				{
					WoodChipper.MyAudio.clip = WoodChipper.ShredAudio;
					WoodChipper.MyAudio.Play();
				}
				if (CharacterAnimation["f02_carryDisposeA_00"].time >= CharacterAnimation["f02_carryDisposeA_00"].length)
				{
					if (!WoodChipper.Acid)
					{
						WoodChipper.Prompt.HideButton[0] = false;
					}
					WoodChipper.Prompt.HideButton[3] = true;
					WoodChipper.Occupied = true;
					WoodChipper.Open = false;
					Dragging = false;
					Chipping = false;
					CanMove = true;
					Ragdoll = null;
					StopCarrying();
					DumpTimer = 0f;
				}
			}
		}
		if (TranquilHiding)
		{
			targetRotation = Quaternion.LookRotation(TranqCase.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			MoveTowardsTarget(TranqCase.transform.position + Vector3.right * 1.4f);
			if (DumpTimer == 0f && Carrying)
			{
				CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
			}
			DumpTimer += Time.deltaTime;
			if (DumpTimer > 1f)
			{
				if (!Ragdoll.GetComponent<RagdollScript>().Dumped)
				{
					DumpRagdoll(RagdollDumpType.TranqCase);
				}
				CharacterAnimation.CrossFade("f02_carryDisposeA_00");
				if (CharacterAnimation["f02_carryDisposeA_00"].time >= CharacterAnimation["f02_carryDisposeA_00"].length)
				{
					TranquilHiding = false;
					Dragging = false;
					Dumping = false;
					CanMove = true;
					Ragdoll = null;
					StopCarrying();
					DumpTimer = 0f;
				}
			}
		}
		if (Dipping)
		{
			if (Bucket != null)
			{
				targetRotation = Quaternion.LookRotation(new Vector3(Bucket.transform.position.x, base.transform.position.y, Bucket.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			}
			CharacterAnimation.CrossFade("f02_dipping_00");
			if (CharacterAnimation["f02_dipping_00"].time >= CharacterAnimation["f02_dipping_00"].length * 0.5f)
			{
				if (Mop == null)
				{
					Mop = PickUp.Mop;
				}
				Mop.Bleached = true;
				Mop.Sparkles.Play();
				if (Mop.StudentBloodID > 0)
				{
					Bucket.StudentBloodID = Mop.StudentBloodID;
					Mop.StudentBloodID = 0;
				}
				if (Mop.Bloodiness > 0f)
				{
					if (Bucket != null)
					{
						Bucket.Bloodiness += Mop.Bloodiness / 2f;
						Bucket.UpdateAppearance = true;
						if (Bucket.Bloodiness >= 50f)
						{
							Bucket.PickUp.Outline[0].color = new Color(1f, 0.5f, 0f, 1f);
						}
					}
					Mop.Bloodiness = 0f;
					Mop.UpdateBlood();
				}
			}
			if (CharacterAnimation["f02_dipping_00"].time >= CharacterAnimation["f02_dipping_00"].length)
			{
				CharacterAnimation["f02_dipping_00"].time = 0f;
				Mop.Prompt.enabled = true;
				TooCloseToWall = false;
				Dipping = false;
				CanMove = true;
			}
			TooCloseToWall = false;
			Direction = 1;
			CheckForWall();
			if (TooCloseToWall)
			{
				MyController.Move(base.transform.forward * -1f * Time.deltaTime);
			}
		}
		if (Pouring)
		{
			MoveTowardsTarget(Stool.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Stool.rotation, 10f * Time.deltaTime);
			string animation = "f02_bucketDump" + PourHeight + "_00";
			AnimationState animationState = CharacterAnimation[animation];
			CharacterAnimation.CrossFade(animation, 0f);
			if (animationState.time >= PourTime && !PickUp.Bucket.Poured)
			{
				if (PickUp.Bucket.Gasoline)
				{
					ParticleSystem.MainModule main = PickUp.Bucket.PourEffect.main;
					main.startColor = new Color(1f, 1f, 0f, 0.5f);
					Object.Instantiate(PickUp.Bucket.GasCollider, PickUp.Bucket.PourEffect.transform.position + PourDistance * base.transform.forward, Quaternion.identity);
				}
				else if (PickUp.Bucket.DyedBrown)
				{
					ParticleSystem.MainModule main2 = PickUp.Bucket.PourEffect.main;
					main2.startColor = new Color(0.25f, 0.125f, 0f, 0.5f);
					Object.Instantiate(PickUp.Bucket.BrownPaintCollider, PickUp.Bucket.PourEffect.transform.position + PourDistance * base.transform.forward, Quaternion.identity);
				}
				else if (PickUp.Bucket.Bloodiness < 50f)
				{
					ParticleSystem.MainModule main3 = PickUp.Bucket.PourEffect.main;
					main3.startColor = new Color(0f, 1f, 1f, 0.5f);
					Object.Instantiate(PickUp.Bucket.WaterCollider, PickUp.Bucket.PourEffect.transform.position + PourDistance * base.transform.forward, Quaternion.identity);
				}
				else
				{
					ParticleSystem.MainModule main4 = PickUp.Bucket.PourEffect.main;
					main4.startColor = new Color(0.5f, 0f, 0f, 0.5f);
					Object.Instantiate(PickUp.Bucket.BloodCollider, PickUp.Bucket.PourEffect.transform.position + PourDistance * base.transform.forward, Quaternion.identity);
				}
				PickUp.Bucket.PourEffect.Play();
				PickUp.Bucket.Poured = true;
				PickUp.Bucket.Empty();
			}
			if (animationState.time >= animationState.length)
			{
				animationState.time = 0f;
				PickUp.Bucket.Poured = false;
				Pouring = false;
				CanMove = true;
			}
		}
		if (Laughing)
		{
			if (Hairstyles[14].activeInHierarchy)
			{
				LaughAnim = "storepower_20";
				LaughClip = ChargeUp;
			}
			if (Stand.Stand.activeInHierarchy)
			{
				LaughAnim = "f02_jojoAttack_00";
				LaughClip = YanYan;
			}
			else if (FlameDemonic)
			{
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				Vector3 vector3 = MainCamera.transform.TransformDirection(Vector3.forward);
				vector3.y = 0f;
				vector3 = vector3.normalized;
				Vector3 vector4 = new Vector3(vector3.z, 0f, 0f - vector3.x);
				Vector3 vector5 = axis2 * vector4 + axis * vector3;
				if (vector5 != Vector3.zero)
				{
					targetRotation = Quaternion.LookRotation(vector5);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
				}
				LaughAnim = "f02_demonAttack_00";
				CirnoTimer -= Time.deltaTime;
				if (CirnoTimer < 0f)
				{
					Object.Instantiate(Fireball, RightHand.position, base.transform.rotation).transform.localEulerAngles += new Vector3(Random.Range(0f, 22.5f), Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f));
					Object.Instantiate(Fireball, LeftHand.position, base.transform.rotation).transform.localEulerAngles += new Vector3(Random.Range(0f, 22.5f), Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f));
					CirnoTimer = 0.1f;
				}
			}
			else if (CirnoHair.activeInHierarchy)
			{
				float axis3 = Input.GetAxis("Vertical");
				float axis4 = Input.GetAxis("Horizontal");
				Vector3 vector6 = MainCamera.transform.TransformDirection(Vector3.forward);
				vector6.y = 0f;
				vector6 = vector6.normalized;
				Vector3 vector7 = new Vector3(vector6.z, 0f, 0f - vector6.x);
				Vector3 vector8 = axis4 * vector7 + axis3 * vector6;
				if (vector8 != Vector3.zero)
				{
					targetRotation = Quaternion.LookRotation(vector8);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
				}
				LaughAnim = "f02_cirnoAttack_00";
				CirnoTimer -= Time.deltaTime;
				if (CirnoTimer < 0f)
				{
					Object.Instantiate(CirnoIceAttack, base.transform.position + base.transform.up * 1.4f, base.transform.rotation).transform.localEulerAngles += new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
					MyAudio.PlayOneShot(CirnoIceClip);
					CirnoTimer = 0.1f;
				}
			}
			else if (TornadoHair.activeInHierarchy)
			{
				LaughAnim = "f02_tornadoAttack_00";
				CirnoTimer -= Time.deltaTime;
				if (CirnoTimer < 0f)
				{
					GameObject gameObject = Object.Instantiate(TornadoAttack, base.transform.forward * 5f + new Vector3(base.transform.position.x + Random.Range(-5f, 5f), base.transform.position.y, base.transform.position.z + Random.Range(-5f, 5f)), base.transform.rotation);
					while (Vector3.Distance(base.transform.position, gameObject.transform.position) < 1f)
					{
						gameObject.transform.position = base.transform.forward * 5f + new Vector3(base.transform.position.x + Random.Range(-5f, 5f), base.transform.position.y, base.transform.position.z + Random.Range(-5f, 5f));
					}
					CirnoTimer = 0.1f;
				}
			}
			else if (BladeHair.activeInHierarchy)
			{
				LaughAnim = "f02_spin_00";
				base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + Time.deltaTime * 360f * 2f, base.transform.localEulerAngles.z);
				BladeHairCollider1.enabled = true;
				BladeHairCollider2.enabled = true;
			}
			else if (BanchoActive)
			{
				BanchoFlurry.MyCollider.enabled = true;
				LaughAnim = "f02_banchoFlurry_00";
			}
			else if (MyAudio.clip != LaughClip)
			{
				MyAudio.clip = LaughClip;
				MyAudio.time = 0f;
				MyAudio.Play();
			}
			CharacterAnimation.CrossFade(LaughAnim);
			if (Input.GetButtonDown(InputNames.Xbox_RB))
			{
				LaughIntensity += 1f;
				if (LaughIntensity <= 5f)
				{
					LaughAnim = "f02_laugh_01";
					LaughClip = Laugh1;
					LaughTimer = 0.5f;
				}
				else if (LaughIntensity <= 10f)
				{
					LaughAnim = "f02_laugh_02";
					LaughClip = Laugh2;
					LaughTimer = 1f;
				}
				else if (LaughIntensity <= 15f)
				{
					LaughAnim = "f02_laugh_03";
					LaughClip = Laugh3;
					LaughTimer = 1.5f;
				}
				else if (LaughIntensity <= 20f)
				{
					Object.Instantiate(AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
					if (StudentManager.Eighties)
					{
						LaughAnim = "f02_evilLaugh_00";
					}
					else
					{
						LaughAnim = "f02_laugh_04";
					}
					LaughClip = Laugh4;
					LaughTimer = 2f;
					LoseGentleEyes();
				}
				else
				{
					Object.Instantiate(AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
					if (StudentManager.Eighties)
					{
						LaughAnim = "f02_evilLaugh_00";
					}
					else
					{
						LaughAnim = "f02_laugh_04";
					}
					LaughIntensity = 20f;
					LaughTimer = 2f;
				}
			}
			if (LaughIntensity > 15f)
			{
				if (StudentManager.KokonaTutorial)
				{
					Sanity += Time.deltaTime * 20f;
				}
				else
				{
					Sanity += Time.deltaTime * 10f;
				}
			}
			LaughTimer -= Time.deltaTime;
			if (LaughTimer <= 0f)
			{
				StopLaughing();
			}
		}
		if (TimeSkipping)
		{
			CharacterAnimation.CrossFade("f02_timeSkip_00");
			Sanity += Time.deltaTime * 0.166666f;
		}
		if (DumpsterGrabbing)
		{
			if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetKey("right"))
			{
				CharacterAnimation.CrossFade((DumpsterHandle.Direction == -1f) ? "f02_dumpsterPull_00" : "f02_dumpsterPush_00");
			}
			else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey("left"))
			{
				CharacterAnimation.CrossFade((DumpsterHandle.Direction == -1f) ? "f02_dumpsterPush_00" : "f02_dumpsterPull_00");
			}
			else
			{
				CharacterAnimation.CrossFade("f02_dumpsterGrab_00");
			}
		}
		if (Stripping)
		{
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, StudentManager.YandereStripSpot.rotation, 10f * Time.deltaTime);
			if (CharacterAnimation["f02_stripping_00"].time >= CharacterAnimation["f02_stripping_00"].length)
			{
				Stripping = false;
				CanMove = true;
				MyLocker.UpdateSchoolwear();
			}
		}
		if (Bathing)
		{
			MoveTowardsTarget(YandereShower.BatheSpot.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, YandereShower.BatheSpot.rotation, 10f * Time.deltaTime);
			CharacterAnimation.CrossFade(IdleAnim);
			if (YandereShower.Timer < 1f)
			{
				if (Schoolwear == 2)
				{
					Police.BloodyClothing--;
					StudentManager.OriginalUniforms++;
					Debug.Log("And now, # of OriginalUniforms is: " + StudentManager.OriginalUniforms + " and # of NewUniforms is: " + StudentManager.NewUniforms);
				}
				Bloodiness = 0f;
				Bathing = false;
				CanMove = true;
			}
		}
		if (Degloving)
		{
			CharacterAnimation.CrossFade("f02_removeGloves_00");
			if (CharacterAnimation["f02_removeGloves_00"].time >= CharacterAnimation["f02_removeGloves_00"].length)
			{
				RemoveGloves();
			}
			else if (Chased || Chasers > 0 || Noticed)
			{
				Degloving = false;
				GloveTimer = 0f;
				if (!Noticed)
				{
					CanMove = true;
				}
			}
			else if (InputDevice.Type == InputDeviceType.Gamepad)
			{
				if (Input.GetAxis("DpadY") > -0.5f)
				{
					Degloving = false;
					CanMove = true;
					GloveTimer = 0f;
				}
			}
			else if (Input.GetKeyUp(KeyCode.Alpha1))
			{
				Degloving = false;
				CanMove = true;
				GloveTimer = 0f;
			}
		}
		if (Struggling)
		{
			if (!Won && !Lost)
			{
				CharacterAnimation.CrossFade(TargetStudent.Teacher ? "f02_teacherStruggleA_00" : "f02_struggleA_00");
				targetRotation = Quaternion.LookRotation(TargetStudent.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			}
			else if (Won)
			{
				if (!TargetStudent.Teacher)
				{
					CharacterAnimation.CrossFade("f02_struggleWinA_00");
					if (CharacterAnimation["f02_struggleWinA_00"].time > CharacterAnimation["f02_struggleWinA_00"].length - 1f)
					{
						EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime * 3.33333f);
					}
				}
				else
				{
					Debug.Log(TargetStudent.Name + " is being instructed to perform their ''losing struggle'' animation.");
					CharacterAnimation.CrossFade("f02_teacherStruggleWinA_00");
					TargetStudent.CharacterAnimation.CrossFade(TargetStudent.StruggleWonAnim);
					EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime);
				}
				if (StrugglePhase == 0)
				{
					if ((!TargetStudent.Teacher && CharacterAnimation["f02_struggleWinA_00"].time > 1.3f) || (TargetStudent.Teacher && CharacterAnimation["f02_teacherStruggleWinA_00"].time > 0.8f))
					{
						Debug.Log("Yandere-chan just killed " + TargetStudent.Name + " as a result of winning a struggling against them.");
						TargetStudent.DeathCause = EquippedWeapon.WeaponID;
						Object.Instantiate(TargetStudent.StabBloodEffect, TargetStudent.Teacher ? EquippedWeapon.transform.position : TargetStudent.Head.position, Quaternion.identity);
						Bloodiness += 20f;
						Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Numbness;
						StainWeapon();
						StrugglePhase++;
					}
				}
				else if (StrugglePhase == 1)
				{
					if (TargetStudent.Teacher && CharacterAnimation["f02_teacherStruggleWinA_00"].time > 1.3f)
					{
						Object.Instantiate(TargetStudent.StabBloodEffect, EquippedWeapon.transform.position, Quaternion.identity);
						StrugglePhase++;
					}
				}
				else if (StrugglePhase == 2 && TargetStudent.Teacher && CharacterAnimation["f02_teacherStruggleWinA_00"].time > 2.1f)
				{
					Object.Instantiate(TargetStudent.StabBloodEffect, EquippedWeapon.transform.position, Quaternion.identity);
					StrugglePhase++;
				}
				if (TargetStudent.Teacher && CharacterAnimation["f02_teacherStruggleWinA_00"].time > 2.75f)
				{
					Debug.Log("A teacher lost a struggle and is falling now. Checking for nearby walls.");
					TargetStudent.TooCloseToWall = false;
					TargetStudent.CheckForWallToLeft();
					if (TargetStudent.TooCloseToWall)
					{
						TargetStudent.StopSliding = true;
						Debug.Log("Too close to a wall! Trying to slide the character to the side.");
						TargetStudent.MyController.Move(TargetStudent.transform.right * Time.deltaTime * -2f);
					}
				}
				if (!TargetStudent.Teacher && CharacterAnimation["f02_struggleWinA_00"].time > 2.25f)
				{
					Debug.Log("A student lost a struggle and is falling now. Checking for nearby walls.");
					TargetStudent.TooCloseToWall = false;
					TargetStudent.CheckForWallToRight();
					if (TargetStudent.TooCloseToWall)
					{
						TargetStudent.StopSliding = true;
						Debug.Log("Too close to a wall! Trying to slide the character to the side.");
						TargetStudent.MyController.Move(TargetStudent.transform.right * Time.deltaTime * 2f);
					}
				}
				if ((!TargetStudent.Teacher && CharacterAnimation["f02_struggleWinA_00"].time > CharacterAnimation["f02_struggleWinA_00"].length) || (TargetStudent.Teacher && CharacterAnimation["f02_teacherStruggleWinA_00"].time > CharacterAnimation["f02_teacherStruggleWinA_00"].length))
				{
					MyController.radius = 0.2f;
					CharacterAnimation.CrossFade(IdleAnim);
					ShoulderCamera.Struggle = false;
					Struggling = false;
					StrugglePhase = 0;
					if (TargetStudent == Pursuer)
					{
						Pursuer = null;
						Chased = false;
					}
					TargetStudent.BecomeRagdoll();
					TargetStudent.DeathType = DeathType.Weapon;
					SeenByAuthority = false;
				}
			}
			else if (Lost)
			{
				CharacterAnimation.CrossFade(TargetStudent.Teacher ? "f02_teacherStruggleLoseA_00" : "f02_struggleLoseA_00");
			}
		}
		if (ClubActivity)
		{
			if (Club == ClubType.Drama)
			{
				CharacterAnimation.Play("f02_performing_00");
			}
			else if (Club == ClubType.Art)
			{
				CharacterAnimation.Play("f02_painting_00");
			}
			else if (Club == ClubType.MartialArts)
			{
				CharacterAnimation.Play("f02_kick_23");
				if (CharacterAnimation["f02_kick_23"].time >= CharacterAnimation["f02_kick_23"].length)
				{
					CharacterAnimation["f02_kick_23"].time = 0f;
				}
			}
			else if (Club == ClubType.Photography)
			{
				if (!StudentManager.Eighties)
				{
					CharacterAnimation.Play("f02_sit_00");
				}
			}
			else if (Club == ClubType.Gaming)
			{
				CharacterAnimation.Play("f02_playingGames_00");
			}
		}
		if (Possessed)
		{
			CharacterAnimation.CrossFade("f02_possessionPose_00");
		}
		if (Lifting)
		{
			if (!HeavyWeight)
			{
				if (CharacterAnimation["f02_carryLiftA_00"].time >= CharacterAnimation["f02_carryLiftA_00"].length)
				{
					IdleAnim = CarryIdleAnim;
					WalkAnim = CarryWalkAnim;
					RunAnim = CarryRunAnim;
					CanMove = true;
					Carrying = true;
					Lifting = false;
				}
			}
			else if (CharacterAnimation["f02_heavyWeightLift_00"].time >= CharacterAnimation["f02_heavyWeightLift_00"].length)
			{
				CharacterAnimation[CarryAnims[0]].weight = 1f;
				IdleAnim = HeavyIdleAnim;
				WalkAnim = HeavyWalkAnim;
				RunAnim = CarryRunAnim;
				CanMove = true;
				Lifting = false;
			}
		}
		if (Dropping)
		{
			targetRotation = Quaternion.LookRotation(DropSpot.position + DropSpot.forward - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			MoveTowardsTarget(DropSpot.position);
			if (Ragdoll != null && CurrentRagdoll == null)
			{
				CurrentRagdoll = Ragdoll.GetComponent<RagdollScript>();
			}
			if (DumpTimer == 0f && Carrying)
			{
				CurrentRagdoll.CharacterAnimation[CurrentRagdoll.DumpedAnim].time = 2.5f;
				CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
			}
			DumpTimer += Time.deltaTime;
			if (DumpTimer > 1f)
			{
				FollowHips = true;
				if (Ragdoll != null)
				{
					CurrentRagdoll.PelvisRoot.localEulerAngles = new Vector3(CurrentRagdoll.PelvisRoot.localEulerAngles.x, 0f, CurrentRagdoll.PelvisRoot.localEulerAngles.z);
					CurrentRagdoll.PelvisRoot.localPosition = new Vector3(CurrentRagdoll.PelvisRoot.localPosition.x, CurrentRagdoll.PelvisRoot.localPosition.y, 0f);
				}
				CameraTarget.position = Vector3.MoveTowards(CameraTarget.position, new Vector3(Hips.position.x, base.transform.position.y + 1f, Hips.position.z), Time.deltaTime * 10f);
				if (CharacterAnimation["f02_carryDisposeA_00"].time >= 4.5f)
				{
					StopCarrying();
				}
				else
				{
					if (CurrentRagdoll.StopAnimation)
					{
						CurrentRagdoll.StopAnimation = false;
						for (ID = 0; ID < CurrentRagdoll.AllRigidbodies.Length; ID++)
						{
							CurrentRagdoll.AllRigidbodies[ID].isKinematic = true;
						}
					}
					CharacterAnimation.CrossFade("f02_carryDisposeA_00");
					CurrentRagdoll.CharacterAnimation.CrossFade(CurrentRagdoll.DumpedAnim);
					Ragdoll.transform.position = base.transform.position;
					Ragdoll.transform.eulerAngles = base.transform.eulerAngles;
				}
				if (CharacterAnimation["f02_carryDisposeA_00"].time >= CharacterAnimation["f02_carryDisposeA_00"].length)
				{
					CameraTarget.localPosition = new Vector3(0f, 1f, 0f);
					FollowHips = false;
					Dropping = false;
					CanMove = true;
					DumpTimer = 0f;
				}
			}
		}
		if (Dismembering && CharacterAnimation["f02_dismember_00"].time >= CharacterAnimation["f02_dismember_00"].length)
		{
			StopDismembering();
		}
		if (WrappingCorpse && CharacterAnimation["f02_dismember_00"].time >= CharacterAnimation["f02_dismember_00"].length)
		{
			StopWrappingCorpse();
		}
		if (Shoved)
		{
			if (CharacterAnimation["f02_shoveA_01"].time >= CharacterAnimation["f02_shoveA_01"].length)
			{
				CharacterAnimation.CrossFade(IdleAnim);
				Shoved = false;
				if (!CannotRecover)
				{
					CanMove = true;
				}
			}
			else if (CharacterAnimation["f02_shoveA_01"].time < 0.66666f)
			{
				MyController.Move(base.transform.forward * -1f * ShoveSpeed * Time.deltaTime);
				MyController.Move(Physics.gravity * 0.1f);
				if (ShoveSpeed > 0f)
				{
					ShoveSpeed = Mathf.MoveTowards(ShoveSpeed, 0f, Time.deltaTime * 3f);
				}
			}
		}
		if (Attacked && CharacterAnimation["f02_swingB_00"].time >= CharacterAnimation["f02_swingB_00"].length)
		{
			if (!StudentManager.KokonaTutorial)
			{
				ShoulderCamera.HeartbrokenCamera.SetActive(value: true);
			}
			base.enabled = false;
		}
		if (Hiding)
		{
			if (!Exiting)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, HidingSpot.rotation, Time.deltaTime * 10f);
				MoveTowardsTarget(HidingSpot.position);
				CharacterAnimation.CrossFade(HideAnim);
				if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					PromptBar.ClearButtons();
					PromptBar.Show = false;
					Exiting = true;
				}
			}
			else
			{
				MoveTowardsTarget(ExitSpot.position);
				CharacterAnimation.CrossFade(IdleAnim);
				ExitTimer += Time.deltaTime;
				if (ExitTimer > 1f || Vector3.Distance(base.transform.position, ExitSpot.position) < 0.1f)
				{
					MyController.center = new Vector3(MyController.center.x, 0.875f, MyController.center.z);
					MyController.radius = 0.2f;
					MyController.height = 1.55f;
					ExitTimer = 0f;
					Exiting = false;
					CanMove = true;
					Hiding = false;
				}
			}
		}
		if (BucketDropping)
		{
			targetRotation = Quaternion.LookRotation(DropSpot.position + DropSpot.forward - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			MoveTowardsTarget(DropSpot.position);
			if (CharacterAnimation["f02_bucketDrop_00"].time >= CharacterAnimation["f02_bucketDrop_00"].length)
			{
				MyController.radius = 0.2f;
				BucketDropping = false;
				CanMove = true;
			}
			else if (CharacterAnimation["f02_bucketDrop_00"].time >= 1f && PickUp != null)
			{
				Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Numbness;
				GameObjectUtils.SetLayerRecursively(PickUp.Bucket.gameObject, 0);
				PickUp.Bucket.UpdateAppearance = true;
				PickUp.Bucket.Dropped = true;
				EmptyHands();
			}
		}
		if (Flicking)
		{
			if (CharacterAnimation["f02_flickingMatch_00"].time >= CharacterAnimation["f02_flickingMatch_00"].length)
			{
				PickUp.GetComponent<MatchboxScript>().Prompt.enabled = true;
				Flicking = false;
				CanMove = true;
			}
			else if (CharacterAnimation["f02_flickingMatch_00"].time > 1f && Match != null)
			{
				Rigidbody component = Match.GetComponent<Rigidbody>();
				component.isKinematic = false;
				component.useGravity = true;
				component.AddRelativeForce(Vector3.right * 250f);
				Match.transform.parent = null;
				Match = null;
			}
		}
		if (Rummaging)
		{
			MoveTowardsTarget(RummageSpot.Target.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, RummageSpot.Target.rotation, Time.deltaTime * 10f);
			RummageTimer += Time.deltaTime * 2f;
			ProgressBar.transform.localScale = new Vector3(RummageTimer / 10f, ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
			if (RummageTimer > 10f)
			{
				RummageSpot.GetReward();
				ProgressBar.transform.parent.gameObject.SetActive(value: false);
				RummageSpot = null;
				Rummaging = false;
				RummageTimer = 0f;
				CanMove = true;
			}
		}
		if (Digging)
		{
			if (DigPhase == 1)
			{
				if (CharacterAnimation["f02_shovelDig_00"].time >= 1.6666666f)
				{
					MyAudio.volume = 1f;
					MyAudio.clip = Dig;
					MyAudio.Play();
					DigPhase++;
				}
			}
			else if (DigPhase == 2)
			{
				if (CharacterAnimation["f02_shovelDig_00"].time >= 3.5f)
				{
					MyAudio.volume = 1f;
					MyAudio.Play();
					DigPhase++;
				}
			}
			else if (DigPhase == 3)
			{
				if (CharacterAnimation["f02_shovelDig_00"].time >= 5.6666665f)
				{
					MyAudio.volume = 1f;
					MyAudio.Play();
					DigPhase++;
				}
			}
			else if (DigPhase == 4 && CharacterAnimation["f02_shovelDig_00"].time >= CharacterAnimation["f02_shovelDig_00"].length)
			{
				StopDigging();
			}
		}
		if (Burying)
		{
			if (DigPhase == 1)
			{
				if (CharacterAnimation["f02_shovelBury_00"].time >= 2.1666667f)
				{
					MyAudio.volume = 1f;
					MyAudio.clip = Dig;
					MyAudio.Play();
					DigPhase++;
				}
			}
			else if (DigPhase == 2)
			{
				if (CharacterAnimation["f02_shovelBury_00"].time >= 4.6666665f)
				{
					MyAudio.volume = 1f;
					MyAudio.Play();
					DigPhase++;
				}
			}
			else if (CharacterAnimation["f02_shovelBury_00"].time >= CharacterAnimation["f02_shovelBury_00"].length)
			{
				StopBurying();
			}
		}
		if (Pickpocketing && !Noticed && Caught)
		{
			CaughtTimer += Time.deltaTime;
			if (CaughtTimer > 1f)
			{
				if (!CannotRecover)
				{
					CanMove = true;
				}
				Pickpocketing = false;
				CaughtTimer = 0f;
				Caught = false;
			}
		}
		if (Sprayed)
		{
			if (SprayPhase == 0)
			{
				if ((double)CharacterAnimation["f02_sprayed_00"].time > 0.66666)
				{
					Blur.enabled = true;
					Blur.Size += Time.deltaTime;
				}
				if (CharacterAnimation["f02_sprayed_00"].time > 5f)
				{
					Police.Darkness.enabled = true;
					Police.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Police.Darkness.color.a, 1f, Time.deltaTime));
					if (Police.Darkness.color.a == 1f)
					{
						SprayTimer += Time.deltaTime;
						if (SprayTimer > 1f)
						{
							CharacterAnimation.Play("f02_tied_00");
							RPGCamera.enabled = false;
							ZipTie[0].SetActive(value: true);
							ZipTie[1].SetActive(value: true);
							Blur.enabled = false;
							SprayTimer = 0f;
							SprayPhase++;
						}
					}
				}
			}
			else if (SprayPhase == 1)
			{
				Police.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Police.Darkness.color.a, 0f, Time.deltaTime));
				if (Police.Darkness.color.a == 0f)
				{
					SprayTimer += Time.deltaTime;
					if (SprayTimer > 1f)
					{
						ShoulderCamera.HeartbrokenCamera.SetActive(value: true);
						HeartCamera.gameObject.SetActive(value: false);
						HUD.alpha = 0f;
						SprayPhase++;
					}
				}
			}
		}
		if (CleaningWeapon)
		{
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Target.rotation, Time.deltaTime * 10f);
			MoveTowardsTarget(Target.position);
			if (CharacterAnimation["f02_cleaningWeapon_00"].time >= CharacterAnimation["f02_cleaningWeapon_00"].length)
			{
				EquippedWeapon.Blood.enabled = false;
				EquippedWeapon.Evidence = false;
				EquippedWeapon.Bloody = false;
				EquippedWeapon.RemoveBlood();
				EquippedWeapon.SuspicionCheck();
				if (Gloved)
				{
					EquippedWeapon.FingerprintID = 0;
				}
				CleaningWeapon = false;
				CanMove = true;
			}
		}
		if (CrushingPhone)
		{
			CharacterAnimation.CrossFade("f02_phoneCrush_00");
			targetRotation = Quaternion.LookRotation(new Vector3(PhoneToCrush.transform.position.x, base.transform.position.y, PhoneToCrush.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			MoveTowardsTarget(PhoneToCrush.PhoneCrushingSpot.position);
			if (CharacterAnimation["f02_phoneCrush_00"].time >= 0.5f && PhoneToCrush.enabled)
			{
				PhoneToCrush.transform.localEulerAngles = new Vector3(PhoneToCrush.transform.localEulerAngles.x, PhoneToCrush.transform.localEulerAngles.y, 0f);
				Object.Instantiate(PhoneToCrush.PhoneSmash, PhoneToCrush.transform.position, Quaternion.identity);
				Police.PhotoEvidence--;
				PhoneToCrush.MyRenderer.material.mainTexture = PhoneToCrush.SmashedTexture;
				PhoneToCrush.MyMesh.mesh = PhoneToCrush.SmashedMesh;
				PhoneToCrush.Prompt.Hide();
				PhoneToCrush.Prompt.enabled = false;
				PhoneToCrush.enabled = false;
			}
			if (CharacterAnimation["f02_phoneCrush_00"].time >= CharacterAnimation["f02_phoneCrush_00"].length)
			{
				CrushingPhone = false;
				CanMove = true;
			}
		}
		if (SubtleStabbing)
		{
			if (CharacterAnimation["f02_subtleStab_00"].time < 0.5f)
			{
				CharacterAnimation.CrossFade("f02_subtleStab_00");
				targetRotation = Quaternion.LookRotation(new Vector3(TargetStudent.transform.position.x, base.transform.position.y, TargetStudent.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
				MoveTowardsTarget(TargetStudent.transform.position + TargetStudent.transform.forward * -1f);
			}
			else if (TargetStudent.Strength > 0)
			{
				TargetStudent.Strength = 0;
				TargetStudent.Hunter.MurderSuicidePhase = 0;
				TargetStudent.Hunter.AttackWillFail = false;
				TargetStudent.Hunter.Pathfinding.canMove = true;
				TargetStudent.CharacterAnimation["f02_murderSuicide_01"].time = 1.5f;
				TargetStudent.Hunter.CharacterAnimation["f02_murderSuicide_00"].time = 1.5f;
				Debug.Log("Making the hunter's attack a success!");
			}
			if (CharacterAnimation["f02_subtleStab_00"].time >= CharacterAnimation["f02_subtleStab_00"].length)
			{
				StainWeapon();
				SubtleStabbing = false;
				CanMove = true;
			}
		}
		if (SneakingShot)
		{
			if (SneakShotTimer == 0f)
			{
				CharacterAnimation["f02_sneakShot_01"].speed = 4f;
				CharacterAnimation.CrossFade("f02_sneakShot_01");
				if (CharacterAnimation["f02_sneakShot_01"].time >= 1f)
				{
					SneakShotPhone.SetActive(value: true);
				}
				if (CharacterAnimation["f02_sneakShot_01"].time >= CharacterAnimation["f02_sneakShot_01"].length)
				{
					SneakShotTimer += Time.deltaTime;
					CameraFlash.SetActive(value: true);
					StudentManager.UpdatePanties(Status: true);
					Object.Instantiate(PantyDetector, SneakShotPhone.transform.position, base.transform.rotation).GetComponent<PantyDetectorScript>().Yandere = this;
				}
			}
			else
			{
				SneakShotTimer += Time.deltaTime;
				if (SneakShotTimer > 0.33333f)
				{
					CharacterAnimation["f02_sneakShot_02"].speed = 4f;
					CharacterAnimation.CrossFade("f02_sneakShot_02");
					if (CharacterAnimation["f02_sneakShot_02"].time >= 1.5f)
					{
						SneakShotPhone.SetActive(value: false);
						CameraFlash.SetActive(value: false);
						Shutter.Blocked = false;
						SneakingShot = false;
						if (!Chased)
						{
							CanMove = true;
						}
						Lewd = false;
						WallToLeft = false;
						WallToRight = false;
						WallInFront = false;
						SneakShotTimer = 0f;
					}
				}
			}
		}
		if (Throwing && ((Obvious && CharacterAnimation["f02_throw_00"].time >= CharacterAnimation["f02_throw_00"].length) || (!Obvious && CharacterAnimation["f02_subtleThrow_00"].time >= CharacterAnimation["f02_subtleThrow_00"].length)))
		{
			Throwing = false;
			CanMove = true;
			if (OutOfAmmo)
			{
				Debug.Log("Was out of ammo.");
				StopAiming();
			}
			else
			{
				if (Obvious)
				{
					CharacterAnimation["f02_prepareThrow_00"].weight = 1f;
				}
				else
				{
					CharacterAnimation["f02_subtleThrowIdle_00"].weight = 1f;
				}
				IdleAnim = DefaultIdleAnim;
				WalkAnim = DefaultWalkAnim;
				PreparingThrow = true;
				NewArc.gameObject.SetActive(value: true);
			}
		}
		if (CanMoveTimer > 0f)
		{
			CanMoveTimer = Mathf.MoveTowards(CanMoveTimer, 0f, Time.deltaTime);
			if (CanMoveTimer == 0f)
			{
				CanMove = true;
			}
		}
		if (!Egg)
		{
			return;
		}
		if (Punching)
		{
			if (FalconHelmet.activeInHierarchy)
			{
				if (CharacterAnimation["f02_falconPunch_00"].time >= 1f && CharacterAnimation["f02_falconPunch_00"].time <= 1.25f)
				{
					FalconSpeed = Mathf.MoveTowards(FalconSpeed, 2.5f, Time.deltaTime * 2.5f);
				}
				else if (CharacterAnimation["f02_falconPunch_00"].time >= 1.25f && CharacterAnimation["f02_falconPunch_00"].time <= 1.5f)
				{
					FalconSpeed = Mathf.MoveTowards(FalconSpeed, 0f, Time.deltaTime * 2.5f);
				}
				if (CharacterAnimation["f02_falconPunch_00"].time >= 1f && CharacterAnimation["f02_falconPunch_00"].time <= 1.5f)
				{
					if (NewFalconPunch == null)
					{
						NewFalconPunch = Object.Instantiate(FalconPunch);
						NewFalconPunch.transform.parent = ItemParent;
						NewFalconPunch.transform.localPosition = Vector3.zero;
					}
					MyController.Move(base.transform.forward * FalconSpeed);
				}
				if (CharacterAnimation["f02_falconPunch_00"].time >= CharacterAnimation["f02_falconPunch_00"].length)
				{
					NewFalconPunch = null;
					Punching = false;
					CanMove = true;
				}
			}
			else
			{
				if (CharacterAnimation["f02_onePunch_00"].time >= 0.833333f && CharacterAnimation["f02_onePunch_00"].time <= 1f && NewOnePunch == null)
				{
					NewOnePunch = Object.Instantiate(OnePunch);
					NewOnePunch.transform.parent = ItemParent;
					NewOnePunch.transform.localPosition = Vector3.zero;
				}
				if (CharacterAnimation["f02_onePunch_00"].time >= 2f)
				{
					NewOnePunch = null;
					Punching = false;
					CanMove = true;
				}
			}
		}
		if (PK)
		{
			if (Input.GetAxis("Vertical") > 0.5f)
			{
				GoToPKDir(PKDirType.Up, "f02_sansUp_00", new Vector3(0f, 3f, 2f));
			}
			else if (Input.GetAxis("Vertical") < -0.5f)
			{
				GoToPKDir(PKDirType.Down, "f02_sansDown_00", new Vector3(0f, 0f, 2f));
			}
			else if (Input.GetAxis("Horizontal") > 0.5f)
			{
				GoToPKDir(PKDirType.Right, "f02_sansRight_00", new Vector3(1.5f, 1.5f, 2f));
			}
			else if (Input.GetAxis("Horizontal") < -0.5f)
			{
				GoToPKDir(PKDirType.Left, "f02_sansLeft_00", new Vector3(-1.5f, 1.5f, 2f));
			}
			else
			{
				CharacterAnimation.CrossFade("f02_sansHold_00");
				RagdollPK.transform.localPosition = new Vector3(0f, 1.5f, 2f);
				PKDir = PKDirType.None;
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PromptBar.ClearButtons();
				PromptBar.UpdateButtons();
				PromptBar.Show = false;
				Ragdoll.GetComponent<RagdollScript>().StopDragging();
				SansEyes[0].SetActive(value: false);
				SansEyes[1].SetActive(value: false);
				GlowEffect.Stop();
				CanMove = true;
				PK = false;
			}
		}
		if (SummonBones)
		{
			CharacterAnimation.CrossFade("f02_sansBones_00");
			if (BoneTimer == 0f)
			{
				Object.Instantiate(Bone, base.transform.position + base.transform.right * Random.Range(-2.5f, 2.5f) + base.transform.up * -2f + base.transform.forward * Random.Range(1f, 6f), Quaternion.identity);
			}
			BoneTimer += Time.deltaTime;
			if (BoneTimer > 0.1f)
			{
				BoneTimer = 0f;
			}
			if (Input.GetButtonUp(InputNames.Xbox_RB))
			{
				SansEyes[0].SetActive(value: false);
				SansEyes[1].SetActive(value: false);
				GlowEffect.Stop();
				SummonBones = false;
				CanMove = true;
			}
			if (PK)
			{
				PromptBar.ClearButtons();
				PromptBar.UpdateButtons();
				PromptBar.Show = false;
				Ragdoll.GetComponent<RagdollScript>().StopDragging();
				SansEyes[0].SetActive(value: false);
				SansEyes[1].SetActive(value: false);
				GlowEffect.Stop();
				CanMove = true;
				PK = false;
			}
		}
		if (Blasting)
		{
			if (CharacterAnimation["f02_sansBlaster_00"].time >= CharacterAnimation["f02_sansBlaster_00"].length - 0.25f)
			{
				SansEyes[0].SetActive(value: false);
				SansEyes[1].SetActive(value: false);
				GlowEffect.Stop();
				Blasting = false;
				CanMove = true;
			}
			if (PK)
			{
				PromptBar.ClearButtons();
				PromptBar.UpdateButtons();
				PromptBar.Show = false;
				Ragdoll.GetComponent<RagdollScript>().StopDragging();
				SansEyes[0].SetActive(value: false);
				SansEyes[1].SetActive(value: false);
				GlowEffect.Stop();
				CanMove = true;
				PK = false;
			}
		}
		if (SithAttacking)
		{
			if (!SithRecovering)
			{
				if (SithBeam[1].Damage == 10f || NierDamage == 10f)
				{
					if (SithAttacks == 0 && CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= SithSpawnTime[SithCombo])
					{
						Object.Instantiate(SithHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
						SithAttacks++;
					}
				}
				else if (Pod.activeInHierarchy || Armor[20].activeInHierarchy)
				{
					if (CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= SithHardSpawnTime1[SithCombo] && SithAttacks == 0)
					{
						Object.Instantiate(BerserkHitbox, base.transform.position + base.transform.forward * 1.5f + base.transform.up, base.transform.rotation).GetComponent<SithBeamScript>().Damage = 20f;
						SithAttacks++;
						if (SithCombo < 2)
						{
							Object.Instantiate(GroundImpact, base.transform.position + base.transform.forward * 1.5f, base.transform.rotation).transform.localScale = new Vector3(2f, 2f, 2f);
						}
					}
				}
				else if (SithAttacks == 0)
				{
					if (CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= SithHardSpawnTime1[SithCombo])
					{
						Object.Instantiate(SithHardHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
						SithAttacks++;
					}
				}
				else if (SithAttacks == 1)
				{
					if (CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= SithHardSpawnTime2[SithCombo])
					{
						Object.Instantiate(SithHardHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
						SithAttacks++;
					}
				}
				else if (SithAttacks == 2 && SithCombo == 1 && CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= 14f / 15f)
				{
					Object.Instantiate(SithHardHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
					SithAttacks++;
				}
				SithSoundCheck();
				if (CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].length)
				{
					if (SithCombo < SithComboLength)
					{
						SithCombo++;
						SithSounds = 0;
						SithAttacks = 0;
						CharacterAnimation.Play("f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo);
					}
					else
					{
						CharacterAnimation.Play("f02_" + AttackPrefix + "Recover" + SithPrefix + "_0" + SithCombo);
						if (!Pod.activeInHierarchy)
						{
							CharacterAnimation["f02_" + AttackPrefix + "Recover" + SithPrefix + "_0" + SithCombo].speed = 2f;
						}
						else
						{
							CharacterAnimation["f02_" + AttackPrefix + "Recover" + SithPrefix + "_0" + SithCombo].speed = 0.5f;
						}
						SithRecovering = true;
					}
				}
				else
				{
					if (Input.GetButtonDown(InputNames.Xbox_X) && SithComboLength < SithCombo + 1 && SithComboLength < 2)
					{
						SithComboLength++;
					}
					if (Input.GetButtonDown(InputNames.Xbox_Y) && SithComboLength < SithCombo + 1 && SithComboLength < 2)
					{
						SithComboLength++;
					}
				}
			}
			else if (CharacterAnimation["f02_" + AttackPrefix + "Recover" + SithPrefix + "_0" + SithCombo].time >= CharacterAnimation["f02_" + AttackPrefix + "Recover" + SithPrefix + "_0" + SithCombo].length || h + v != 0f)
			{
				if (SithPrefix == "")
				{
					LightSwordParticles.Play();
				}
				else
				{
					HeavySwordParticles.Play();
				}
				HeavySword.GetComponent<WeaponTrail>().enabled = false;
				LightSword.GetComponent<WeaponTrail>().enabled = false;
				SithRecovering = false;
				SithAttacking = false;
				SithComboLength = 0;
				SithAttacks = 0;
				SithSounds = 0;
				SithCombo = 0;
				CanMove = true;
			}
		}
		if (Eating)
		{
			if (Vector3.Distance(base.transform.position, TargetStudent.transform.position) > 0.5f)
			{
				base.transform.Translate(Vector3.forward * Time.deltaTime);
			}
			targetRotation = Quaternion.LookRotation(new Vector3(TargetStudent.transform.position.x, base.transform.position.y, TargetStudent.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			if (CharacterAnimation["f02_sixEat_00"].time > BloodTimes[EatPhase])
			{
				Object.Instantiate(TargetStudent.StabBloodEffect, Mouth.position, Quaternion.identity).GetComponent<RandomStabScript>().Biting = true;
				Bloodiness += 20f;
				EatPhase++;
			}
			if (CharacterAnimation["f02_sixEat_00"].time >= CharacterAnimation["f02_sixEat_00"].length)
			{
				if (!Kagune[0].activeInHierarchy && Hunger < 5)
				{
					CharacterAnimation["f02_sixRun_00"].speed += 0.1f;
					RunSpeed += 1f;
					Hunger++;
					if (Hunger == 5)
					{
						RisingSmoke.SetActive(value: true);
						RunAnim = "f02_sixFastRun_00";
					}
				}
				Debug.Log("Finished eating.");
				FollowHips = false;
				Attacking = false;
				CanMove = true;
				Eating = false;
				EatPhase = 0;
			}
		}
		if (Snapping)
		{
			if (SnapPhase == 0)
			{
				if (Gazing)
				{
					if (CharacterAnimation["f02_gazerSnap_00"].time >= 0.8f)
					{
						AudioSource.PlayClipAtPoint(FingerSnap, base.transform.position + Vector3.up);
						GazerEyes.ChangeEffect();
						SnapPhase++;
					}
				}
				else if (WitchMode)
				{
					if (CharacterAnimation["f02_fingerSnap_00"].time >= 1f)
					{
						AudioSource.PlayClipAtPoint(FingerSnap, base.transform.position + Vector3.up);
						Object.Instantiate(KnifeArray, base.transform.position, base.transform.rotation).GetComponent<KnifeArrayScript>().GlobalKnifeArray = GlobalKnifeArray;
						SnapPhase++;
					}
				}
				else if (ShotsFired < 1)
				{
					if (CharacterAnimation["f02_shipGirlSnap_00"].time >= 1f)
					{
						Object.Instantiate(Shell, Guns[1].position, base.transform.rotation);
						ShotsFired++;
					}
				}
				else if (ShotsFired < 2)
				{
					if (CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.2f)
					{
						Object.Instantiate(Shell, Guns[2].position, base.transform.rotation);
						ShotsFired++;
					}
				}
				else if (ShotsFired < 3)
				{
					if (CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.4f)
					{
						Object.Instantiate(Shell, Guns[3].position, base.transform.rotation);
						ShotsFired++;
					}
				}
				else if (ShotsFired < 4 && CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.6f)
				{
					Object.Instantiate(Shell, Guns[4].position, base.transform.rotation);
					ShotsFired++;
					SnapPhase++;
				}
			}
			else if (Gazing)
			{
				if (CharacterAnimation["f02_gazerSnap_00"].time >= CharacterAnimation["f02_gazerSnap_00"].length)
				{
					Snapping = false;
					CanMove = true;
					SnapPhase = 0;
				}
			}
			else if (WitchMode)
			{
				if (CharacterAnimation["f02_fingerSnap_00"].time >= CharacterAnimation["f02_fingerSnap_00"].length)
				{
					CharacterAnimation.Stop("f02_fingerSnap_00");
					Snapping = false;
					CanMove = true;
					SnapPhase = 0;
				}
			}
			else if (CharacterAnimation["f02_shipGirlSnap_00"].time >= CharacterAnimation["f02_shipGirlSnap_00"].length)
			{
				Snapping = false;
				CanMove = true;
				ShotsFired = 0;
				SnapPhase = 0;
			}
		}
		if (GazeAttacking)
		{
			if (TargetStudent != null)
			{
				targetRotation = Quaternion.LookRotation(new Vector3(TargetStudent.transform.position.x, base.transform.position.y, TargetStudent.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			}
			if (SnapPhase == 0)
			{
				if (CharacterAnimation["f02_gazerPoint_00"].time >= 1f)
				{
					AudioSource.PlayClipAtPoint(Zap, base.transform.position + Vector3.up);
					GazerEyes.Attack();
					SnapPhase++;
				}
			}
			else if (CharacterAnimation["f02_gazerPoint_00"].time >= CharacterAnimation["f02_gazerPoint_00"].length)
			{
				GazerEyes.Attacking = false;
				GazeAttacking = false;
				CanMove = true;
				SnapPhase = 0;
			}
		}
		if (Finisher)
		{
			if (CharacterAnimation["f02_banchoFinisher_00"].time >= CharacterAnimation["f02_banchoFinisher_00"].length)
			{
				CharacterAnimation.CrossFade(IdleAnim);
				Finisher = false;
				CanMove = true;
			}
			else if (CharacterAnimation["f02_banchoFinisher_00"].time >= 1.6666666f)
			{
				BanchoFinisher.MyCollider.enabled = false;
			}
			else if (CharacterAnimation["f02_banchoFinisher_00"].time >= 5f / 6f)
			{
				BanchoFinisher.MyCollider.enabled = true;
			}
		}
		if (ShootingBeam)
		{
			CharacterAnimation.CrossFade("f02_LoveLoveBeam_00");
			if (CharacterAnimation["f02_LoveLoveBeam_00"].time >= 1.5f && BeamPhase == 0)
			{
				Object.Instantiate(LoveLoveBeam, base.transform.position, base.transform.rotation);
				BeamPhase++;
			}
			if (CharacterAnimation["f02_LoveLoveBeam_00"].time >= CharacterAnimation["f02_LoveLoveBeam_00"].length - 1f)
			{
				ShootingBeam = false;
				YandereTimer = 0f;
				CanMove = true;
				BeamPhase = 0;
			}
		}
		if (WritingName)
		{
			CharacterAnimation.CrossFade("f02_dramaticWriting_00");
			if (CharacterAnimation["f02_dramaticWriting_00"].time == 0f)
			{
				AudioSource.PlayClipAtPoint(DramaticWriting, base.transform.position);
			}
			if (CharacterAnimation["f02_dramaticWriting_00"].time >= 5f && StudentManager.NoteWindow.TargetStudent > 0)
			{
				StudentManager.Students[StudentManager.NoteWindow.TargetStudent].Fate = StudentManager.NoteWindow.MeetID;
				StudentManager.Students[StudentManager.NoteWindow.TargetStudent].TimeOfDeath = StudentManager.NoteWindow.TimeID;
				StudentManager.NoteWindow.TargetStudent = 0;
			}
			if (CharacterAnimation["f02_dramaticWriting_00"].time >= CharacterAnimation["f02_dramaticWriting_00"].length)
			{
				CharacterAnimation[CarryAnims[10]].weight = 1f;
				CharacterAnimation["f02_dramaticWriting_00"].time = 0f;
				CharacterAnimation.Stop("f02_dramaticWriting_00");
				WritingName = false;
				CanMove = true;
			}
		}
		if (StoppingTime)
		{
			CharacterAnimation.CrossFade("f02_summonStand_00");
			if (CharacterAnimation["f02_summonStand_00"].time >= 1f)
			{
				if (Freezing)
				{
					if (!InvertSphere.gameObject.activeInHierarchy)
					{
						if (MyAudio.clip != ClockStop)
						{
							MyAudio.clip = ClockStop;
							MyAudio.volume = 1f;
							MyAudio.Play();
						}
						InvertSphere.gameObject.SetActive(value: true);
						PlayerOnlyCamera.SetActive(value: true);
						StudentManager.TimeFreeze();
					}
					InvertSphere.transform.localScale = Vector3.MoveTowards(InvertSphere.transform.localScale, new Vector3(0.2375f, 0.2375f, 0f), Time.deltaTime);
					MyAudio.volume = 1f;
					Jukebox.Ebola.pitch = Mathf.MoveTowards(Jukebox.Ebola.pitch, 0.2f, Time.deltaTime);
				}
				else
				{
					if (MyAudio.clip != ClockStart)
					{
						MyAudio.clip = ClockStart;
						MyAudio.volume = 1f;
						MyAudio.Play();
						StudentManager.TimeUnfreeze();
					}
					InvertSphere.transform.localScale = Vector3.MoveTowards(InvertSphere.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime);
					MyAudio.volume = 1f;
					Jukebox.Ebola.pitch = Mathf.MoveTowards(Jukebox.Ebola.pitch, 1f, Time.deltaTime);
					GlobalKnifeArray.ActivateKnives();
				}
			}
			if (CharacterAnimation["f02_summonStand_00"].time >= CharacterAnimation["f02_summonStand_00"].length)
			{
				StoppingTime = false;
				CanMove = true;
				InvertSphere.gameObject.SetActive(Freezing);
				PlayerOnlyCamera.SetActive(Freezing);
			}
		}
		if (Swiping)
		{
			if (CharacterAnimation["f02_sithAttack_0" + SwipeID].time >= CharacterAnimation["f02_sithAttack_0" + SwipeID].length * 0.9f)
			{
				Swiping = false;
				CanMove = true;
				Finisher = false;
			}
			else if (CharacterAnimation["f02_sithAttack_0" + SwipeID].time >= CharacterAnimation["f02_sithAttack_0" + SwipeID].length * 0.25f && !Finisher)
			{
				Object.Instantiate(DemonSlash, base.transform.position + base.transform.up + base.transform.forward * 2f, Quaternion.identity);
				Finisher = true;
			}
		}
	}

	private void UpdatePoisoning()
	{
		if (!Poisoning)
		{
			return;
		}
		if (PoisonSpot != null)
		{
			if (Vector3.Distance(base.transform.position, PoisonSpot.position) > 0.1f)
			{
				MoveTowardsTarget(PoisonSpot.position);
			}
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, PoisonSpot.rotation, Time.deltaTime * 10f);
		}
		else
		{
			targetRotation = Quaternion.LookRotation(new Vector3(TargetBento.transform.position.x, base.transform.position.y, TargetBento.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			MoveTowardsTarget(TargetBento.PoisonSpot.position);
		}
		if (CharacterAnimation["f02_poisoning_00"].time >= CharacterAnimation["f02_poisoning_00"].length)
		{
			StudentManager.Portal.GetComponent<PortalScript>().OsanaEvent.Bentos[1].GetComponent<BentoScript>().BeingPoisoned = false;
			StudentManager.Portal.GetComponent<PortalScript>().OsanaEvent.Bentos[1].GetComponent<BentoScript>().BeingPoisoned = false;
			CharacterAnimation["f02_poisoning_00"].speed = 1f;
			Poisons[PoisonType].SetActive(value: false);
			PoisonSpot = null;
			Poisoning = false;
			CanMove = true;
		}
		else if (CharacterAnimation["f02_poisoning_00"].time >= 5.25f)
		{
			Poisons[PoisonType].SetActive(value: false);
		}
		else if ((double)CharacterAnimation["f02_poisoning_00"].time >= 0.75)
		{
			Poisons[PoisonType].SetActive(value: true);
		}
	}

	private void UpdateEffects()
	{
		if (!Attacking && !DelinquentFighting && !Lost && CanMove)
		{
			if (Vector3.Distance(base.transform.position, Senpai.position) < SenpaiThreshold)
			{
				if (!Talking)
				{
					if (!NearSenpai && StudentManager.Students[1].Pathfinding.speed < 7.5f)
					{
						StudentManager.TutorialWindow.ShowSenpaiMessage = true;
						NearSenpai = true;
					}
					if (Laughing)
					{
						Debug.Log("Yandere-chan was laughing, and is being told to stop laughing because UpdateEffects() was called.");
						StopLaughing();
						if (Pursuer != null)
						{
							CanMove = false;
						}
					}
					Stance.Current = StanceType.Standing;
					YandereVision = false;
					Mopping = false;
					Uncrouch();
					YandereTimer = 0f;
					EmptyHands();
					if (Aiming)
					{
						StopAiming();
					}
				}
			}
			else
			{
				NearSenpai = false;
			}
		}
		if (NearSenpai && !Noticed)
		{
			if (!FilterUpdated)
			{
				AssignFilters();
				FilterUpdated = true;
			}
			SenpaiFilter.enabled = true;
			SenpaiFilter.FadeFX = Mathf.Lerp(SenpaiFilter.FadeFX, 1f, Time.deltaTime * 10f);
			SenpaiFade = Mathf.Lerp(SenpaiFade, 0f, Time.deltaTime * 10f);
			SenpaiTint = 1f - SenpaiFade / 100f;
			_ = Attacking;
			SelectGrayscale.desaturation = Mathf.Lerp(SelectGrayscale.desaturation, 0f, Time.deltaTime * 10f);
			HeartBeat.volume = SenpaiTint;
			Sanity += Time.deltaTime * 10f;
			SenpaiTimer += Time.deltaTime;
			BeatTimer += Time.deltaTime;
			if (BeatTimer > 60f / (float)HeartRate.BeatsPerMinute)
			{
				GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
				VibrationCheck = true;
				VibrationTimer = 0.1f;
				BeatTimer = 0f;
			}
			if (SenpaiTimer > 10f && Creepiness < 5)
			{
				SenpaiTimer = 0f;
				Creepiness++;
			}
		}
		else if (SenpaiFade < 99f)
		{
			SenpaiFilter.FadeFX = Mathf.Lerp(SenpaiFilter.FadeFX, 0f, Time.deltaTime * 10f);
			SenpaiFade = Mathf.Lerp(SenpaiFade, 100f, Time.deltaTime * 10f);
			SenpaiTint = SenpaiFade / 100f;
			SelectGrayscale.desaturation = Mathf.Lerp(SelectGrayscale.desaturation, GreyTarget, Time.deltaTime * 10f);
			CharacterAnimation["f02_shy_00"].weight = 1f - SenpaiTint;
			for (int i = 1; i < 6; i++)
			{
				CharacterAnimation[CreepyIdles[i]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyIdles[i]].weight, 0f, Time.deltaTime * 10f);
				CharacterAnimation[CreepyWalks[i]].weight = Mathf.MoveTowards(CharacterAnimation[CreepyWalks[i]].weight, 0f, Time.deltaTime * 10f);
			}
			HeartBeat.volume = 1f - SenpaiTint;
		}
		else if (SenpaiFade < 100f)
		{
			ResetSenpaiEffects();
		}
		if (YandereVision)
		{
			if (!HighlightingR.enabled)
			{
				YandereFilter.enabled = true;
				HighlightingR.enabled = true;
				HighlightingB.enabled = true;
			}
			if (Stance.Current == StanceType.Standing)
			{
				if (YandereVisionPanel.alpha == 0f)
				{
					if (!StudentManager.Eighties)
					{
						Phone.transform.localPosition = new Vector3(-0.02f, -0.005f, 0.03f);
						Phone.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
					}
					else
					{
						Phone.transform.localPosition = new Vector3(-0.015f, -0.006f, 0.015f);
						Phone.transform.localEulerAngles = new Vector3(-90f, -165f, 0f);
					}
					RightRedEye.material.color = new Color(1f, 1f, 1f, 1f);
					LeftRedEye.material.color = new Color(1f, 1f, 1f, 1f);
					RightYandereEye.material.color = new Color(1f, 1f, 1f, 0f);
					LeftYandereEye.material.color = new Color(1f, 1f, 1f, 0f);
					if (Inventory.SenpaiShots > 0 || StudentManager.MissionMode || StudentManager.Eighties)
					{
						SenpaiShotLabel.text = "Speed Up Time";
					}
					else
					{
						SenpaiShotLabel.text = "Speed Up Time (Requires Photo of Senpai)";
					}
					UpdateConcealedWeaponStatus();
					UpdateConcealedItemStatus();
				}
				YandereVisionPanel.alpha = Mathf.MoveTowards(YandereVisionPanel.alpha, 1f, Time.unscaledDeltaTime * 10f);
			}
			else
			{
				YandereVisionPanel.alpha = Mathf.MoveTowards(YandereVisionPanel.alpha, 0f, Time.unscaledDeltaTime * 10f);
				SenpaiGazing = false;
			}
			bool flag = Inventory.SenpaiShots > 0 || StudentManager.MissionMode || StudentManager.Eighties;
			if (YandereVisionPanel.alpha == 1f && flag && PickUp == null && !Armed && !Carrying && !Dragging)
			{
				SenpaiShotLabel.text = "Speed Up Time";
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					SenpaiGazing = !SenpaiGazing;
				}
			}
			else
			{
				if (PickUp != null || Armed || Carrying || Dragging)
				{
					SenpaiShotLabel.text = "Speed Up Time (Empty Hands First)";
				}
				SenpaiGazing = false;
			}
			if (SenpaiGazing)
			{
				Phone.SetActive(value: true);
				CharacterAnimation["f02_phonePose_00"].weight = Mathf.Lerp(CharacterAnimation["f02_phonePose_00"].weight, 1f, Time.unscaledDeltaTime * 10f);
				Time.timeScale = Mathf.Lerp(Time.timeScale, 2f, Time.unscaledDeltaTime * 10f);
			}
			else
			{
				Phone.SetActive(value: false);
				CharacterAnimation["f02_phonePose_00"].weight = Mathf.Lerp(CharacterAnimation["f02_phonePose_00"].weight, 0f, Time.unscaledDeltaTime * 10f);
				Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, Time.unscaledDeltaTime * 10f);
			}
			YandereFilter.FadeFX = Mathf.Lerp(YandereFilter.FadeFX, 1f, Time.unscaledDeltaTime * 10f);
			YandereFade = Mathf.Lerp(YandereFade, 0f, Time.unscaledDeltaTime * 10f);
			YandereTint = 1f - YandereFade / 100f;
			CameraEffects.UpdateVignette(YandereFilter.FadeFX);
			if (StudentManager.Tag.Target != null)
			{
				StudentManager.Tag.Sprite.color = new Color(1f, 0f, 0f, Mathf.Lerp(StudentManager.Tag.Sprite.color.a, 1f, Time.unscaledDeltaTime * 10f));
			}
			if (StudentManager.Students[StudentManager.RivalID] != null)
			{
				StudentManager.RedString.gameObject.SetActive(value: true);
			}
			if (CanMove && !Carrying && !Dragging && YandereVisionPanel.alpha == 1f)
			{
				if (!StudentManager.KokonaTutorial && SneakShotLabel.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_B))
				{
					Direction = 1;
					CheckForWall();
					if (WallInFront)
					{
						Debug.Log("The player took a photo really close to a wall!");
						NotificationManager.CustomText = "Camera's view is blocked!";
						NotificationManager.DisplayNotification(NotificationType.Custom);
						Shutter.Blocked = true;
					}
					EmptyHands();
					YandereVision = false;
					SneakingShot = true;
					CanMove = false;
					Lewd = true;
				}
				else if (ConcealedWeaponLabel.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_Y))
				{
					if (Container.TrashCan.Item != null)
					{
						CharacterAnimation["f02_reachForWeapon_00"].time = 0f;
						ReachWeight = 1f;
						Container.TrashCan.RemoveContents();
					}
					else if (Armed)
					{
						if (EquippedWeapon.Type == WeaponType.Scythe)
						{
							NotificationManager.CustomText = "That's too big to fit inside!";
							NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						else
						{
							Container.TrashCan.StashItem();
							UpdateConcealedWeaponStatus();
						}
					}
				}
				else if (ConcealedItemLabel.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_X))
				{
					StudentManager.CheckForAttackPrompt();
					if (!StudentManager.AttackPromptActive)
					{
						Debug.Log("Stashing/removing item.");
						if (Bookbag.ConcealedPickup != null)
						{
							Bookbag.RemoveContents();
						}
						else if (PickUp != null)
						{
							Bookbag.TryToStashItem();
							UpdateConcealedItemStatus();
						}
					}
					else
					{
						Debug.Log("A student was attackable! Can't interact with the bookbag right now.");
					}
				}
			}
			if (Chased)
			{
				ResetYandereEffects();
			}
			return;
		}
		if (HighlightingR.enabled)
		{
			HighlightingR.enabled = false;
			HighlightingB.enabled = false;
		}
		if (YandereFade < 99f)
		{
			if (!Aiming)
			{
				Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.unscaledDeltaTime * 10f);
			}
			Phone.SetActive(value: false);
			CharacterAnimation["f02_phonePose_00"].weight = Mathf.Lerp(CharacterAnimation["f02_phonePose_00"].weight, 0f, Time.unscaledDeltaTime * 10f);
			YandereVisionPanel.alpha = Mathf.Lerp(YandereVisionPanel.alpha, 0f, Time.unscaledDeltaTime * 10f);
			YandereFilter.FadeFX = Mathf.Lerp(YandereFilter.FadeFX, 0f, Time.unscaledDeltaTime * 10f);
			YandereFade = Mathf.Lerp(YandereFade, 100f, Time.unscaledDeltaTime * 10f);
			YandereTint = YandereFade / 100f;
			CameraEffects.UpdateVignette(1f - Sanity * 0.01f);
			StudentManager.Tag.Sprite.color = new Color(1f, 0f, 0f, Mathf.Lerp(StudentManager.Tag.Sprite.color.a, 0f, Time.unscaledDeltaTime * 10f));
			if (StudentManager.RedString != null)
			{
				StudentManager.RedString.gameObject.SetActive(value: false);
			}
			RightRedEye.material.color = new Color(RightRedEye.material.color.r, RightRedEye.material.color.g, RightRedEye.material.color.b, 1f - YandereFade / 100f);
			LeftRedEye.material.color = new Color(LeftRedEye.material.color.r, LeftRedEye.material.color.g, LeftRedEye.material.color.b, 1f - YandereFade / 100f);
			RightYandereEye.material.color = new Color(RightYandereEye.material.color.r, YandereFade / 100f, YandereFade / 100f, RightYandereEye.material.color.a);
			LeftYandereEye.material.color = new Color(LeftYandereEye.material.color.r, YandereFade / 100f, YandereFade / 100f, LeftYandereEye.material.color.a);
			if (AudioPlayed)
			{
				YandereVisionAudio.clip = YandereVisionOff;
				YandereVisionAudio.Play();
				YandereVisionDrone.Stop();
				AudioPlayed = false;
			}
		}
		else if (YandereFade < 100f)
		{
			ResetYandereEffects();
		}
	}

	private void UpdateTalking()
	{
		if (!Talking)
		{
			return;
		}
		if (TargetStudent != null)
		{
			targetRotation = Quaternion.LookRotation(new Vector3(TargetStudent.transform.position.x, base.transform.position.y, TargetStudent.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
			if (Vector3.Distance(base.transform.position, TargetStudent.transform.position) < 0.75f)
			{
				MyController.Move(base.transform.forward * Time.deltaTime * -1f);
				CameraEffects.UpdateDOF(Vector3.Distance(base.transform.position, TargetStudent.transform.position) + 0.1f);
			}
			if (TargetStudent.Follower != null)
			{
				TargetStudent.FollowTargetDestination.position = TargetStudent.Follower.transform.position;
			}
		}
		if (Interaction == YandereInteractionType.Idle)
		{
			if (TargetStudent != null && !TargetStudent.Counselor)
			{
				CharacterAnimation.CrossFade(IdleAnim);
			}
		}
		else if (Interaction == YandereInteractionType.Apologizing)
		{
			if (TalkTimer == 10f)
			{
				CharacterAnimation.CrossFade("f02_greet_00");
				if (TargetStudent.Witnessed == StudentWitnessType.Insanity || TargetStudent.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity || TargetStudent.Witnessed == StudentWitnessType.WeaponAndInsanity || TargetStudent.Witnessed == StudentWitnessType.BloodAndInsanity)
				{
					Subtitle.UpdateLabel(SubtitleType.InsanityApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.WeaponAndBlood)
				{
					Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Weapon)
				{
					Subtitle.UpdateLabel(SubtitleType.WeaponApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Blood)
				{
					Subtitle.UpdateLabel(SubtitleType.BloodApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Lewd)
				{
					Subtitle.UpdateLabel(SubtitleType.LewdApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Accident)
				{
					Subtitle.UpdateLabel(SubtitleType.AccidentApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Suspicious)
				{
					Subtitle.UpdateLabel(SubtitleType.SuspiciousApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Eavesdropping)
				{
					Subtitle.UpdateLabel(SubtitleType.EavesdropApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Theft)
				{
					Subtitle.UpdateLabel(SubtitleType.TheftApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Violence)
				{
					Subtitle.UpdateLabel(SubtitleType.ViolenceApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Pickpocketing)
				{
					Subtitle.UpdateLabel(SubtitleType.PickpocketApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.CleaningItem)
				{
					Subtitle.UpdateLabel(SubtitleType.CleaningApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Poisoning)
				{
					Subtitle.UpdateLabel(SubtitleType.PoisonApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.HoldingBloodyClothing)
				{
					Subtitle.UpdateLabel(SubtitleType.HoldingBloodyClothingApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Trespassing)
				{
					Subtitle.UpdateLabel(SubtitleType.TrespassApology, 0, 10f);
				}
				else if (TargetStudent.Witnessed == StudentWitnessType.Tutorial)
				{
					Subtitle.UpdateLabel(SubtitleType.TutorialApology, 0, 10f);
				}
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_greet_00"].time >= CharacterAnimation["f02_greet_00"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.Forgiving;
					TargetStudent.TalkTimer = 3f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.Compliment)
		{
			if (TalkTimer == 5f)
			{
				CharacterAnimation.CrossFade("f02_greet_01");
				Subtitle.CustomText = TargetStudent.DialogueWheel.TopicInterface.Statement;
				Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_greet_01"].time >= CharacterAnimation["f02_greet_01"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.ReceivingCompliment;
					TargetStudent.TalkTimer = 3f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.Gossip)
		{
			if (TalkTimer == 5f)
			{
				CharacterAnimation.CrossFade("f02_lookdown_00");
				Subtitle.CustomText = TargetStudent.DialogueWheel.TopicInterface.Statement;
				Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_lookdown_00"].time >= CharacterAnimation["f02_lookdown_00"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.Gossiping;
					TargetStudent.TalkTimer = 3f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.Bye)
		{
			if (TalkTimer == 2f)
			{
				CharacterAnimation.CrossFade("f02_greet_00");
				Subtitle.UpdateLabel(SubtitleType.PlayerFarewell, 0, 2f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_greet_00"].time >= CharacterAnimation["f02_greet_00"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.Bye;
					TargetStudent.TalkTimer = 2f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.FollowMe)
		{
			int num = 0;
			if (Club == ClubType.Delinquent)
			{
				num++;
			}
			if (TalkTimer == 3f)
			{
				if (Club == ClubType.Delinquent)
				{
					TalkAnim = "f02_delinquentGesture_01";
				}
				else
				{
					TalkAnim = "f02_greet_01";
				}
				CharacterAnimation.CrossFade(TalkAnim);
				Subtitle.UpdateLabel(SubtitleType.PlayerFollow, num, 3f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation[TalkAnim].time >= CharacterAnimation[TalkAnim].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.FollowingPlayer;
					TargetStudent.TalkTimer = 2f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.GoAway)
		{
			int num2 = 0;
			if (Club == ClubType.Delinquent)
			{
				num2++;
			}
			if (TalkTimer == 3f)
			{
				if (Club == ClubType.Delinquent)
				{
					TalkAnim = "f02_delinquentGesture_01";
				}
				else
				{
					TalkAnim = "f02_lookdown_00";
				}
				CharacterAnimation.CrossFade(TalkAnim);
				Subtitle.UpdateLabel(SubtitleType.PlayerLeave, num2, 3f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation[TalkAnim].time >= CharacterAnimation[TalkAnim].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.GoingAway;
					TargetStudent.TalkTimer = 3f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.DistractThem)
		{
			int num3 = 0;
			if (Club == ClubType.Delinquent || StudentManager.Eighties)
			{
				num3++;
			}
			if (TalkTimer == 3f)
			{
				if (Club == ClubType.Delinquent)
				{
					TalkAnim = "f02_delinquentGesture_01";
				}
				else
				{
					TalkAnim = "f02_lookdown_00";
				}
				CharacterAnimation.CrossFade(TalkAnim);
				Subtitle.UpdateLabel(SubtitleType.PlayerDistract, num3, 3f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation[TalkAnim].time >= CharacterAnimation[TalkAnim].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.DistractingTarget;
					TargetStudent.TalkTimer = 3f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.NamingCrush)
		{
			if (TalkTimer == 3f)
			{
				CharacterAnimation.CrossFade("f02_greet_01");
				Subtitle.UpdateLabel(SubtitleType.PlayerLove, 0, 3f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_greet_01"].time >= CharacterAnimation["f02_greet_01"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.NamingCrush;
					TargetStudent.TalkTimer = 3f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.ChangingAppearance)
		{
			if (TalkTimer == 3f)
			{
				CharacterAnimation.CrossFade("f02_greet_01");
				Subtitle.UpdateLabel(SubtitleType.PlayerLove, 2, 3f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_greet_01"].time >= CharacterAnimation["f02_greet_01"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					Debug.Log("The game believes that the protagonist's TalkTimer just reached 0.");
					TargetStudent.Interaction = StudentInteractionType.ChangingAppearance;
					TargetStudent.TalkTimer = 3f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.Court)
		{
			if (TalkTimer == 5f)
			{
				CharacterAnimation.CrossFade("f02_greet_01");
				if (!TargetStudent.Male)
				{
					Subtitle.UpdateLabel(SubtitleType.PlayerLove, 3, 5f);
				}
				else
				{
					Subtitle.UpdateLabel(SubtitleType.PlayerLove, 4, 5f);
				}
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_greet_01"].time >= CharacterAnimation["f02_greet_01"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.Court;
					TargetStudent.TalkTimer = 3f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.Advice)
		{
			if (TalkTimer == 5f)
			{
				CharacterAnimation.CrossFade("f02_greet_01");
				Subtitle.UpdateLabel(SubtitleType.PlayerLove, 5, 5f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_greet_01"].time >= CharacterAnimation["f02_greet_01"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.Advice;
					TargetStudent.TalkTimer = 5f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.TaskInquiry)
		{
			if (TalkTimer == 3f || TalkTimer == 5f)
			{
				CharacterAnimation.CrossFade("f02_greet_01");
				if (TargetStudent.Club == ClubType.Bully)
				{
					Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 0, 5f);
				}
				else if (TargetStudent.StudentID == 10)
				{
					Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 6, 5f);
				}
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_greet_01"].time >= CharacterAnimation["f02_greet_01"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					Debug.Log("Telling student to respond to task inquiry.");
					TargetStudent.Interaction = StudentInteractionType.TaskInquiry;
					TargetStudent.TalkTimer = 10f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.GivingSnack)
		{
			if (TalkTimer == 3f)
			{
				CharacterAnimation.CrossFade("f02_greet_01");
				Subtitle.UpdateLabel(SubtitleType.OfferSnack, 0, 3f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (CharacterAnimation["f02_greet_01"].time >= CharacterAnimation["f02_greet_01"].length)
				{
					CharacterAnimation.CrossFade(IdleAnim);
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.TakingSnack;
					TargetStudent.TalkTimer = 5f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else if (Interaction == YandereInteractionType.AskingForHelp)
		{
			if (TalkTimer == 5f)
			{
				CharacterAnimation.CrossFade(IdleAnim);
				Subtitle.UpdateLabel(SubtitleType.AskForHelp, 0, 5f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.GivingHelp;
					TargetStudent.TalkTimer = 4f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
		else
		{
			if (Interaction != YandereInteractionType.SendingToLocker)
			{
				return;
			}
			if (TalkTimer == 5f)
			{
				CharacterAnimation.CrossFade("f02_greet_01");
				Subtitle.UpdateLabel(SubtitleType.SendToLocker, 0, 5f);
			}
			else
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TalkTimer = 0f;
				}
				if (TalkTimer <= 0f)
				{
					TargetStudent.Interaction = StudentInteractionType.SentToLocker;
					TargetStudent.TalkTimer = 5f;
					Interaction = YandereInteractionType.Idle;
				}
			}
			TalkTimer -= Time.deltaTime;
		}
	}

	private void UpdateAttacking()
	{
		if (!Attacking)
		{
			return;
		}
		if (TargetStudent != null)
		{
			targetRotation = Quaternion.LookRotation(new Vector3(TargetStudent.transform.position.x, base.transform.position.y, TargetStudent.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 10f);
		}
		if (Drown)
		{
			MoveTowardsTarget(TargetStudent.transform.position + TargetStudent.transform.forward * -0.0001f);
			CharacterAnimation.CrossFade(DrownAnim);
			if (CharacterAnimation[DrownAnim].time > CharacterAnimation[DrownAnim].length)
			{
				TargetStudent.DeathType = DeathType.Drowning;
				Attacking = false;
				if (!Noticed)
				{
					CanMove = true;
				}
				Drown = false;
				Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Numbness;
			}
		}
		else if (RoofPush)
		{
			CameraTarget.position = Vector3.MoveTowards(CameraTarget.position, new Vector3(Hips.position.x, base.transform.position.y + 1f, Hips.position.z), Time.deltaTime * 10f);
			MoveTowardsTarget(TargetStudent.transform.position - TargetStudent.transform.forward);
			CharacterAnimation.CrossFade("f02_roofPushA_00");
			if (CharacterAnimation["f02_roofPushA_00"].time > 4.3333335f)
			{
				if (Shoes[0].activeInHierarchy)
				{
					Object.Instantiate(ShoePair, base.transform.position + new Vector3(0f, 0.045f, 0f) + base.transform.forward * 1.6f, Quaternion.identity).transform.eulerAngles = base.transform.eulerAngles;
					Shoes[0].SetActive(value: false);
					Shoes[1].SetActive(value: false);
				}
			}
			else if (CharacterAnimation["f02_roofPushA_00"].time > 2.1666667f)
			{
				if (TargetStudent.SnackTimer == 0f)
				{
					TargetStudent.SpawnAlarmDisc();
					TargetStudent.SnackTimer = 1f;
				}
				if (TargetStudent.Schoolwear == 1 && !TargetStudent.ClubAttire && !Shoes[0].activeInHierarchy)
				{
					TargetStudent.RemoveShoes();
					Shoes[0].SetActive(value: true);
					Shoes[1].SetActive(value: true);
				}
			}
			float num = 0f;
			num = ((TargetStudent.Schoolwear != 1 || TargetStudent.ClubAttire) ? 3.5f : CharacterAnimation["f02_roofPushA_00"].length);
			if (CharacterAnimation["f02_roofPushA_00"].time > num)
			{
				CameraTarget.localPosition = new Vector3(0f, 1f, 0f);
				TargetStudent.DeathType = DeathType.Falling;
				SplashCamera.transform.parent = null;
				FollowHips = false;
				Attacking = false;
				RoofPush = false;
				CanMove = true;
				Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Numbness;
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				SplashCamera.transform.parent = base.transform;
				SplashCamera.transform.localPosition = new Vector3(2f, -10.65f, 4.775f);
				SplashCamera.transform.localEulerAngles = new Vector3(0f, -135f, 0f);
				SplashCamera.Show = true;
				SplashCamera.MyCamera.enabled = true;
			}
		}
		else if (TargetStudent.Teacher)
		{
			CharacterAnimation.CrossFade("f02_teacherCounterA_00");
			if (EquippedWeapon != null)
			{
				EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			}
			Character.transform.position = new Vector3(Character.transform.position.x, TargetStudent.transform.position.y, Character.transform.position.z);
		}
		else
		{
			if (SanityBased)
			{
				return;
			}
			if (EquippedWeapon.WeaponID == 27)
			{
				Debug.Log("Well, uh, we're killing with a garrote...");
				return;
			}
			if (EquippedWeapon.WeaponID == 11)
			{
				CharacterAnimation.CrossFade("CyborgNinja_Slash");
				if (CharacterAnimation["CyborgNinja_Slash"].time == 0f)
				{
					TargetStudent.CharacterAnimation[TargetStudent.PhoneAnim].weight = 0f;
					EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
				}
				if (CharacterAnimation["CyborgNinja_Slash"].time >= CharacterAnimation["CyborgNinja_Slash"].length)
				{
					Bloodiness += 20f;
					StainWeapon();
					CharacterAnimation["CyborgNinja_Slash"].time = 0f;
					CharacterAnimation.Stop("CyborgNinja_Slash");
					CharacterAnimation.CrossFade(IdleAnim);
					Attacking = false;
					if (!Noticed)
					{
						CanMove = true;
					}
					else
					{
						EquippedWeapon.Drop();
					}
				}
				return;
			}
			if (EquippedWeapon.WeaponID == 7)
			{
				CharacterAnimation.CrossFade("f02_buzzSawKill_A_00");
				if (CharacterAnimation["f02_buzzSawKill_A_00"].time == 0f)
				{
					TargetStudent.CharacterAnimation[TargetStudent.PhoneAnim].weight = 0f;
					EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
				}
				if (AttackPhase == 1)
				{
					if (CharacterAnimation["f02_buzzSawKill_A_00"].time > 1f / 3f)
					{
						TargetStudent.LiquidProjector.enabled = true;
						EquippedWeapon.Effect();
						StainWeapon();
						TargetStudent.LiquidProjector.material = TargetStudent.BloodMaterial;
						Bloodiness += 20f;
						AttackPhase++;
					}
				}
				else if (AttackPhase < 6 && CharacterAnimation["f02_buzzSawKill_A_00"].time > 1f / 3f * (float)AttackPhase)
				{
					TargetStudent.LiquidProjector.material = TargetStudent.BloodMaterial;
					Bloodiness += 20f;
					AttackPhase++;
				}
				if (CharacterAnimation["f02_buzzSawKill_A_00"].time > CharacterAnimation["f02_buzzSawKill_A_00"].length)
				{
					if (TargetStudent == StudentManager.Reporter)
					{
						StudentManager.Reporter = null;
					}
					CharacterAnimation["f02_buzzSawKill_A_00"].time = 0f;
					CharacterAnimation.Stop("f02_buzzSawKill_A_00");
					CharacterAnimation.CrossFade(IdleAnim);
					MyController.radius = 0.2f;
					Attacking = false;
					AttackPhase = 1;
					Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Numbness;
					TargetStudent.DeathType = DeathType.Weapon;
					TargetStudent.BecomeRagdoll();
					if (!Noticed)
					{
						CanMove = true;
					}
					else
					{
						EquippedWeapon.Drop();
					}
				}
				return;
			}
			if (!EquippedWeapon.Concealable)
			{
				if (AttackPhase == 1)
				{
					CharacterAnimation.CrossFade("f02_swingA_00");
					if (CharacterAnimation["f02_swingA_00"].time > CharacterAnimation["f02_swingA_00"].length * 0.3f)
					{
						if (TargetStudent == StudentManager.Reporter)
						{
							StudentManager.Reporter = null;
						}
						Object.Destroy(TargetStudent.DeathScream);
						EquippedWeapon.Effect();
						AttackPhase = 2;
						Bloodiness += 20f;
						StainWeapon();
						Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Numbness;
					}
				}
				else if (CharacterAnimation["f02_swingA_00"].time >= CharacterAnimation["f02_swingA_00"].length * 0.9f)
				{
					CharacterAnimation.CrossFade(IdleAnim);
					TargetStudent.DeathType = DeathType.Weapon;
					TargetStudent.BecomeRagdoll();
					MyController.radius = 0.2f;
					Attacking = false;
					AttackPhase = 1;
					AttackTimer = 0f;
					if (!Noticed)
					{
						CanMove = true;
					}
					else
					{
						EquippedWeapon.Drop();
					}
				}
				return;
			}
			if (AttackPhase == 1)
			{
				CharacterAnimation.CrossFade("f02_stab_00");
				if (!(CharacterAnimation["f02_stab_00"].time > CharacterAnimation["f02_stab_00"].length * 0.35f))
				{
					return;
				}
				CharacterAnimation.CrossFade(IdleAnim);
				if (EquippedWeapon.Flaming)
				{
					Egg = true;
					TargetStudent.Combust();
				}
				else if (CanTranq && !TargetStudent.Male && TargetStudent.Club != ClubType.Council)
				{
					TargetStudent.Tranquil = true;
					CanTranq = false;
					Follower = null;
					Followers--;
				}
				else
				{
					TargetStudent.BloodSpray.SetActive(value: true);
					TargetStudent.DeathType = DeathType.Weapon;
					Bloodiness += 20f;
				}
				if (TargetStudent == StudentManager.Reporter)
				{
					StudentManager.Reporter = null;
				}
				AudioSource.PlayClipAtPoint(Stabs[Random.Range(0, Stabs.Length)], base.transform.position + Vector3.up);
				AttackPhase = 2;
				Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Numbness;
				if (EquippedWeapon.WeaponID == 8)
				{
					TargetStudent.Ragdoll.Sacrifice = true;
					if (GameGlobals.Paranormal)
					{
						EquippedWeapon.Effect();
					}
				}
				return;
			}
			AttackTimer += Time.deltaTime;
			if (AttackTimer > 0.3f)
			{
				if (!CanTranq)
				{
					StainWeapon();
				}
				MyController.radius = 0.2f;
				SanityBased = true;
				Attacking = false;
				AttackPhase = 1;
				AttackTimer = 0f;
				if (!Noticed)
				{
					CanMove = true;
				}
				else
				{
					EquippedWeapon.Drop();
				}
			}
		}
	}

	public void UpdateSlouch()
	{
		if (FloppyHat.activeInHierarchy)
		{
			return;
		}
		if (CanMove && !Attacking && !Dragging && PickUp == null && !Aiming && Stance.Current != StanceType.Crawling && !Possessed && !Carrying && !CirnoWings.activeInHierarchy && LaughIntensity < 16f)
		{
			CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(CharacterAnimation["f02_yanderePose_00"].weight, 1f - Sanity / 100f, Time.deltaTime * 10f);
			if (Hairstyle == 2 && Stance.Current == StanceType.Crouching)
			{
				Slouch = Mathf.Lerp(Slouch, 0f, Time.deltaTime * 20f);
			}
			else
			{
				Slouch = Mathf.Lerp(Slouch, 5f * (1f - Sanity / 100f), Time.deltaTime * 10f);
			}
		}
		else
		{
			CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(CharacterAnimation["f02_yanderePose_00"].weight, 0f, Time.deltaTime * 10f);
			Slouch = Mathf.Lerp(Slouch, 0f, Time.deltaTime * 10f);
		}
	}

	private void UpdateTwitch()
	{
		if (Sanity < 100f)
		{
			TwitchTimer += Time.deltaTime;
			if (TwitchTimer > NextTwitch)
			{
				Twitch = new Vector3((1f - Sanity / 100f) * Random.Range(-10f, 10f), (1f - Sanity / 100f) * Random.Range(-10f, 10f), (1f - Sanity / 100f) * Random.Range(-10f, 10f));
				NextTwitch = Random.Range(0f, 1f);
				TwitchTimer = 0f;
			}
			Twitch = Vector3.Lerp(Twitch, Vector3.zero, Time.deltaTime * 10f);
		}
	}

	private void UpdateWarnings()
	{
		if (NearBodies > 0)
		{
			if (!CorpseWarning)
			{
				if (PickUp != null && PickUp.GarbageBagBox && PickUp.BodyBags == 0)
				{
					NotificationManager.CustomText = "using masking tape and garbage bags!";
					NotificationManager.DisplayNotification(NotificationType.Custom);
					NotificationManager.CustomText = "Craft bodybags at the workbench";
					NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				NotificationManager.DisplayNotification(NotificationType.Body);
				StudentManager.UpdateStudents();
				CorpseWarning = true;
			}
		}
		else if (CorpseWarning)
		{
			StudentManager.UpdateStudents();
			CorpseWarning = false;
		}
		if (Eavesdropping)
		{
			if (!EavesdropWarning)
			{
				NotificationManager.DisplayNotification(NotificationType.Eavesdropping);
				EavesdropWarning = true;
			}
		}
		else if (EavesdropWarning)
		{
			EavesdropWarning = false;
		}
		if (ClothingWarning)
		{
			ClothingTimer += Time.deltaTime;
			if (ClothingTimer > 1f)
			{
				ClothingWarning = false;
				ClothingTimer = 0f;
			}
		}
	}

	private void UpdateDebugFunctionality()
	{
		if (!EasterEggMenu.activeInHierarchy && !DebugMenu.activeInHierarchy)
		{
			if (Input.GetKeyDown(KeyCode.P))
			{
				CyborgParts[1].SetActive(value: false);
				MemeGlasses.SetActive(value: false);
				KONGlasses.SetActive(value: false);
				EyepatchR.SetActive(value: false);
				EyepatchL.SetActive(value: false);
				EyewearID++;
				if (EyewearID == 1)
				{
					EyepatchR.SetActive(value: true);
				}
				else if (EyewearID == 2)
				{
					EyepatchL.SetActive(value: true);
				}
				else if (EyewearID == 3)
				{
					EyepatchR.SetActive(value: true);
					EyepatchL.SetActive(value: true);
				}
				else if (EyewearID == 4)
				{
					KONGlasses.SetActive(value: true);
				}
				else if (EyewearID == 5)
				{
					MemeGlasses.SetActive(value: true);
				}
				else if (EyewearID == 6)
				{
					if (CyborgParts[2].activeInHierarchy)
					{
						CyborgParts[1].SetActive(value: true);
					}
					else
					{
						EyewearID = 0;
					}
				}
				else
				{
					EyewearID = 0;
				}
			}
			if (Input.GetKeyDown(KeyCode.H))
			{
				if (Input.GetButton(InputNames.Xbox_LB))
				{
					Hairstyle += 10;
				}
				else
				{
					Hairstyle++;
				}
				UpdateHair();
			}
			if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				Hairstyle--;
				UpdateHair();
			}
			if (Input.GetKeyDown(KeyCode.O) && !EasterEggMenu.activeInHierarchy)
			{
				if (AccessoryID > 0)
				{
					Accessories[AccessoryID].SetActive(value: false);
				}
				if (Input.GetButton(InputNames.Xbox_LB))
				{
					AccessoryID += 10;
				}
				else
				{
					AccessoryID++;
				}
				UpdateAccessory();
			}
			if (Input.GetKey(KeyCode.O) && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (AccessoryID > 0)
				{
					Accessories[AccessoryID].SetActive(value: false);
				}
				AccessoryID--;
				UpdateAccessory();
			}
			if (Input.GetKeyDown("-"))
			{
				if (Time.timeScale < 6f)
				{
					Time.timeScale = 1f;
				}
				else
				{
					Time.timeScale -= 5f;
				}
			}
			if (Input.GetKeyDown("="))
			{
				if (Time.timeScale < 5f)
				{
					Time.timeScale = 5f;
				}
				else
				{
					Time.timeScale += 5f;
					if (Time.timeScale > 25f)
					{
						Time.timeScale = 25f;
					}
				}
			}
			if (Input.GetKey(KeyCode.Period))
			{
				BreastSize += Time.deltaTime;
				if (BreastSize > 2f)
				{
					BreastSize = 2f;
				}
				RightBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
				LeftBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
			}
			if (Input.GetKey(KeyCode.Comma))
			{
				BreastSize -= Time.deltaTime;
				if (BreastSize < 0.5f)
				{
					BreastSize = 0.5f;
				}
				RightBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
				LeftBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
			}
		}
		if (CanMove)
		{
			if (!Egg && base.transform.position.y < 1000f)
			{
				if (Input.GetKeyDown(KeyCode.Slash))
				{
					DebugMenu.SetActive(value: false);
					EasterEggMenu.SetActive(!EasterEggMenu.activeInHierarchy);
				}
				if (EasterEggMenu.activeInHierarchy)
				{
					if (Input.GetKeyDown(KeyCode.P))
					{
						Punish();
					}
					else if (Input.GetKeyDown(KeyCode.Z))
					{
						Slend();
					}
					else if (Input.GetKeyDown(KeyCode.B))
					{
						Bancho();
					}
					else if (Input.GetKeyDown(KeyCode.C))
					{
						Cirno();
					}
					else if (Input.GetKeyDown(KeyCode.H))
					{
						EmptyHands();
						Hate();
					}
					else if (Input.GetKeyDown(KeyCode.T))
					{
						StudentManager.AttackOnTitan();
						AttackOnTitan();
					}
					else if (Input.GetKeyDown(KeyCode.G))
					{
						GaloSengen();
					}
					else if (!Input.GetKeyDown(KeyCode.J))
					{
						if (Input.GetKeyDown(KeyCode.K))
						{
							EasterEggMenu.SetActive(value: false);
							StudentManager.Kong();
							DK = true;
						}
						else if (Input.GetKeyDown(KeyCode.L))
						{
							Agent();
						}
						else if (!Input.GetKeyDown(KeyCode.N))
						{
							if (Input.GetKeyDown(KeyCode.S))
							{
								EasterEggMenu.SetActive(value: false);
								Egg = true;
								StudentManager.Spook();
							}
							else if (Input.GetKeyDown(KeyCode.F))
							{
								EasterEggMenu.SetActive(value: false);
								Falcon();
							}
							else if (Input.GetKeyDown(KeyCode.X))
							{
								EasterEggMenu.SetActive(value: false);
								X();
							}
							else if (Input.GetKeyDown(KeyCode.O))
							{
								EasterEggMenu.SetActive(value: false);
								Punch();
							}
							else if (Input.GetKeyDown(KeyCode.U))
							{
								EasterEggMenu.SetActive(value: false);
								BadTime();
							}
							else if (Input.GetKeyDown(KeyCode.Y))
							{
								EasterEggMenu.SetActive(value: false);
								CyborgNinja();
							}
							else if (Input.GetKeyDown(KeyCode.E))
							{
								EasterEggMenu.SetActive(value: false);
								Ebola();
							}
							else if (Input.GetKeyDown(KeyCode.Q))
							{
								EasterEggMenu.SetActive(value: false);
								Samus();
							}
							else if (Input.GetKeyDown(KeyCode.W))
							{
								EasterEggMenu.SetActive(value: false);
								Witch();
							}
							else if (Input.GetKeyDown(KeyCode.R))
							{
								EasterEggMenu.SetActive(value: false);
								Pose();
							}
							else if (Input.GetKeyDown(KeyCode.V))
							{
								EasterEggMenu.SetActive(value: false);
								Vaporwave();
							}
							else if (Input.GetKeyDown(KeyCode.Alpha2))
							{
								EasterEggMenu.SetActive(value: false);
								HairBlades();
							}
							else if (Input.GetKeyDown(KeyCode.Alpha7))
							{
								EasterEggMenu.SetActive(value: false);
								Tornado();
							}
							else if (Input.GetKeyDown(KeyCode.Alpha8))
							{
								EasterEggMenu.SetActive(value: false);
								GenderSwap();
							}
							else if (Input.GetKeyDown(KeyCode.A))
							{
								EasterEggMenu.SetActive(value: false);
								HollowMode();
							}
							else if (Input.GetKeyDown(KeyCode.I))
							{
								StudentManager.NoGravity = true;
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.D))
							{
								EasterEggMenu.SetActive(value: false);
								Sith();
							}
							else if (Input.GetKeyDown(KeyCode.M))
							{
								EasterEggMenu.SetActive(value: false);
								Snake();
							}
							else if (Input.GetKeyDown(KeyCode.Alpha1))
							{
								EasterEggMenu.SetActive(value: false);
								Gazer();
							}
							else if (Input.GetKeyDown(KeyCode.Alpha3))
							{
								StudentManager.SecurityCameras();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.Alpha4))
							{
								KLK();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.Alpha6))
							{
								EasterEggMenu.SetActive(value: false);
								Six();
							}
							else if (Input.GetKeyDown(KeyCode.F1))
							{
								Weather();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F2))
							{
								Horror();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F3))
							{
								LifeNote();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F4))
							{
								Mandere();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F5))
							{
								BlackHoleChan();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F6))
							{
								ElfenLied();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F7))
							{
								Berserk();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F8))
							{
								Nier();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F9))
							{
								Ghoul();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F10))
							{
								CinematicCameraFilters.enabled = true;
								CameraFilters.enabled = true;
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F11))
							{
								GarbageMode();
								EasterEggMenu.SetActive(value: false);
							}
							else if (Input.GetKeyDown(KeyCode.F12))
							{
								TallMode();
								EasterEggMenu.SetActive(value: false);
							}
							else if (!Input.GetKeyDown(KeyCode.ScrollLock) && Input.GetKeyDown(KeyCode.Space))
							{
								EasterEggMenu.SetActive(value: false);
							}
						}
					}
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Z))
		{
			DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
		}
		DebugTimer = Mathf.MoveTowards(DebugTimer, 0f, Time.deltaTime);
	}

	private void LateUpdate()
	{
		if (VibrationCheck)
		{
			VibrationTimer = Mathf.MoveTowards(VibrationTimer, 0f, Time.deltaTime);
			if (VibrationTimer == 0f)
			{
				GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
				VibrationCheck = false;
			}
		}
		LeftEye.localPosition = new Vector3(LeftEye.localPosition.x, LeftEye.localPosition.y, LeftEyeOrigin.z - EyeShrink * 0.02f);
		RightEye.localPosition = new Vector3(RightEye.localPosition.x, RightEye.localPosition.y, RightEyeOrigin.z + EyeShrink * 0.02f);
		LeftEye.localScale = new Vector3(1f - EyeShrink, 1f - EyeShrink, LeftEye.localScale.z);
		RightEye.localScale = new Vector3(1f - EyeShrink, 1f - EyeShrink, RightEye.localScale.z);
		for (ID = 0; ID < Spine.Length; ID++)
		{
			Transform transform = Spine[ID].transform;
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + Slouch, transform.localEulerAngles.y, transform.localEulerAngles.z);
		}
		if (Aiming)
		{
			float num = 1f;
			if (Selfie)
			{
				num = -1f;
			}
			Transform transform2 = Spine[3].transform;
			transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x - Bend * num, transform2.localEulerAngles.y, transform2.localEulerAngles.z);
		}
		float num2 = 1f;
		if (Stance.Current == StanceType.Crouching)
		{
			num2 = 3.66666f;
		}
		if (!Armed || (Armed && EquippedWeapon.Type != WeaponType.Scythe))
		{
			Transform transform3 = Arm[0].transform;
			transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, transform3.localEulerAngles.y, transform3.localEulerAngles.z - Slouch * (3f + num2));
			Transform transform4 = Arm[1].transform;
			transform4.localEulerAngles = new Vector3(transform4.localEulerAngles.x, transform4.localEulerAngles.y, transform4.localEulerAngles.z + Slouch * (3f + num2));
		}
		if (!Aiming)
		{
			Head.localEulerAngles += Twitch;
		}
		if (Aiming)
		{
			if (Stance.Current == StanceType.Crawling)
			{
				if (!StudentManager.Eighties)
				{
					TargetHeight = -1.4f;
				}
				else
				{
					TargetHeight = -2f;
				}
			}
			else if (Stance.Current == StanceType.Crouching)
			{
				if (!StudentManager.Eighties)
				{
					TargetHeight = -0.6f;
				}
				else
				{
					TargetHeight = -2f;
				}
			}
			else
			{
				TargetHeight = 0f;
			}
			Height = Mathf.Lerp(Height, TargetHeight, Time.deltaTime * 10f);
			PelvisRoot.transform.localPosition = new Vector3(PelvisRoot.transform.localPosition.x, Height, PelvisRoot.transform.localPosition.z);
		}
		if (PreparingThrow)
		{
			if (PrepareThrowTimer < 1f)
			{
				PrepareThrowTimer += Time.deltaTime;
				if (Obvious)
				{
					CharacterAnimation["f02_prepareThrow_00"].weight = Mathf.MoveTowards(CharacterAnimation["f02_prepareThrow_00"].weight, 1f, Time.deltaTime * 10f);
					CharacterAnimation["f02_subtleThrowIdle_00"].weight = Mathf.MoveTowards(CharacterAnimation["f02_subtleThrowIdle_00"].weight, 0f, Time.deltaTime * 10f);
				}
				else
				{
					CharacterAnimation["f02_prepareThrow_00"].weight = Mathf.MoveTowards(CharacterAnimation["f02_prepareThrow_00"].weight, 0f, Time.deltaTime * 10f);
					CharacterAnimation["f02_subtleThrowIdle_00"].weight = Mathf.MoveTowards(CharacterAnimation["f02_subtleThrowIdle_00"].weight, 1f, Time.deltaTime * 10f);
				}
			}
		}
		else if (PrepareThrowTimer < 1f)
		{
			PrepareThrowTimer += Time.deltaTime;
			CharacterAnimation["f02_prepareThrow_00"].weight = Mathf.MoveTowards(CharacterAnimation["f02_prepareThrow_00"].weight, 0f, Time.deltaTime * 10f);
			CharacterAnimation["f02_subtleThrowIdle_00"].weight = Mathf.MoveTowards(CharacterAnimation["f02_subtleThrowIdle_00"].weight, 0f, Time.deltaTime * 10f);
			CharacterAnimation["f02_obviousThrowIdle_00"].weight = Mathf.MoveTowards(CharacterAnimation["f02_obviousThrowIdle_00"].weight, 0f, Time.deltaTime * 10f);
		}
		if (Egg)
		{
			if (Slender)
			{
				Transform transform5 = Leg[0];
				transform5.localScale = new Vector3(transform5.localScale.x, 2f, transform5.localScale.z);
				Transform transform6 = Foot[0];
				transform6.localScale = new Vector3(transform6.localScale.x, 0.5f, transform6.localScale.z);
				Transform transform7 = Leg[1];
				transform7.localScale = new Vector3(transform7.localScale.x, 2f, transform7.localScale.z);
				Transform transform8 = Foot[1];
				transform8.localScale = new Vector3(transform8.localScale.x, 0.5f, transform8.localScale.z);
				Transform transform9 = Arm[0];
				transform9.localScale = new Vector3(2f, transform9.localScale.y, transform9.localScale.z);
				Transform transform10 = Arm[1];
				transform10.localScale = new Vector3(2f, transform10.localScale.y, transform10.localScale.z);
			}
			if (DK)
			{
				Arm[0].localScale = new Vector3(2f, 2f, 2f);
				Arm[1].localScale = new Vector3(2f, 2f, 2f);
				Head.localScale = new Vector3(2f, 2f, 2f);
			}
			if (CirnoWings.activeInHierarchy)
			{
				if (Running)
				{
					FlapSpeed = 5f;
				}
				else if (FlapSpeed == 0f)
				{
					FlapSpeed = 1f;
				}
				else
				{
					FlapSpeed = 3f;
				}
				Transform transform11 = CirnoWing[0];
				Transform transform12 = CirnoWing[1];
				if (!FlapOut)
				{
					CirnoRotation += Time.deltaTime * 100f * FlapSpeed;
					transform11.localEulerAngles = new Vector3(transform11.localEulerAngles.x, CirnoRotation, transform11.localEulerAngles.z);
					transform12.localEulerAngles = new Vector3(transform12.localEulerAngles.x, 0f - CirnoRotation, transform12.localEulerAngles.z);
					if (CirnoRotation > 15f)
					{
						FlapOut = true;
					}
				}
				else
				{
					CirnoRotation -= Time.deltaTime * 100f * FlapSpeed;
					transform11.localEulerAngles = new Vector3(transform11.localEulerAngles.x, CirnoRotation, transform11.localEulerAngles.z);
					transform12.localEulerAngles = new Vector3(transform12.localEulerAngles.x, 0f - CirnoRotation, transform12.localEulerAngles.z);
					if (CirnoRotation < -15f)
					{
						FlapOut = false;
					}
				}
			}
			if (BlackHole)
			{
				RightLeg.transform.Rotate(-60f, 0f, 0f, Space.Self);
				LeftLeg.transform.Rotate(-60f, 0f, 0f, Space.Self);
			}
			if (SwingKagune)
			{
				if (!ReturnKagune)
				{
					for (int i = 0; i < Kagune.Length; i++)
					{
						if (i < 2)
						{
							KaguneRotation[i] = new Vector3(Mathf.MoveTowards(KaguneRotation[i].x, 15f, Time.deltaTime * 1000f), Mathf.MoveTowards(KaguneRotation[i].y, 180f, Time.deltaTime * 1000f), Mathf.MoveTowards(KaguneRotation[i].z, 500f, Time.deltaTime * 1000f));
							Kagune[i].transform.localEulerAngles = KaguneRotation[i];
						}
						else
						{
							KaguneRotation[i] = new Vector3(Mathf.MoveTowards(KaguneRotation[i].x, 15f, Time.deltaTime * 1000f), Mathf.MoveTowards(KaguneRotation[i].y, -180f, Time.deltaTime * 1000f), Mathf.MoveTowards(KaguneRotation[i].z, -500f, Time.deltaTime * 1000f));
							Kagune[i].transform.localEulerAngles = KaguneRotation[i];
						}
					}
					if (KagunePhase == 0 && KaguneRotation[0].y == 180f)
					{
						Object.Instantiate(DemonSlash, base.transform.position + base.transform.up + base.transform.forward, Quaternion.identity);
						KagunePhase = 1;
					}
					if (KaguneRotation[0] == new Vector3(15f, 180f, 500f))
					{
						ReturnKagune = true;
					}
				}
				else
				{
					for (int j = 0; j < Kagune.Length; j++)
					{
						switch (j)
						{
						case 0:
							KaguneRotation[j] = new Vector3(Mathf.Lerp(KaguneRotation[j].x, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(KaguneRotation[j].y, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
							break;
						case 1:
							KaguneRotation[j] = new Vector3(Mathf.Lerp(KaguneRotation[j].x, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(KaguneRotation[j].y, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
							break;
						case 2:
							KaguneRotation[j] = new Vector3(Mathf.Lerp(KaguneRotation[j].x, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(KaguneRotation[j].y, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
							break;
						case 3:
							KaguneRotation[j] = new Vector3(Mathf.Lerp(KaguneRotation[j].x, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(KaguneRotation[j].y, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
							break;
						}
						Kagune[j].transform.localEulerAngles = KaguneRotation[j];
					}
					if (Vector3.Distance(KaguneRotation[0], new Vector3(22.5f, 22.5f, 0f)) < 10f)
					{
						SwingKagune = false;
						ReturnKagune = false;
						KagunePhase = 0;
					}
				}
			}
			if (FloppyHat.activeInHierarchy)
			{
				int k = 0;
				if (LongFingers)
				{
					CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(CharacterAnimation["f02_yanderePose_00"].weight, 1f, Time.deltaTime * 10f);
					FingerLength = Mathf.Lerp(FingerLength, 4f, Time.deltaTime * 10f);
					for (Slouch = Mathf.Lerp(Slouch, 1f, Time.deltaTime * 10f); k < AllFingers.Length; k++)
					{
						AllFingers[k].localScale = new Vector3(FingerLength, 1f, 1f);
					}
				}
				else
				{
					CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(CharacterAnimation["f02_yanderePose_00"].weight, 0f, Time.deltaTime * 10f);
					FingerLength = Mathf.Lerp(FingerLength, 1f, Time.deltaTime * 10f);
					for (Slouch = Mathf.Lerp(Slouch, 0f, Time.deltaTime * 10f); k < AllFingers.Length; k++)
					{
						AllFingers[k].localScale = new Vector3(FingerLength, 1f, 1f);
					}
				}
			}
			if (HollowMask.activeInHierarchy)
			{
				if (Armed)
				{
					if (!Attacking)
					{
						RightArmRoll.GetChild(0).localEulerAngles = new Vector3(0f, 0f, 0f);
						if (Running)
						{
							RightArmRoll.parent.localEulerAngles = new Vector3(0f, 0f, -75f);
							RightArmRoll.localEulerAngles = new Vector3(0f, 0f, 0f);
							RightArmRoll.GetChild(0).GetChild(1).localEulerAngles = new Vector3(0f, 0f, 0f);
							RightArmRoll.GetChild(0).GetChild(1).GetChild(0)
								.localEulerAngles = new Vector3(0f, 90f, 0f);
						}
						else
						{
							RightArmRoll.parent.localEulerAngles += new Vector3(0f, 0f, 5f);
							RightArmRoll.GetChild(0).GetChild(1).GetChild(0)
								.localEulerAngles = new Vector3(0f, 45f, 0f);
						}
					}
					ArmSize = Mathf.Lerp(ArmSize, 1f, Time.deltaTime * 10f);
				}
				else
				{
					ArmSize = Mathf.Lerp(ArmSize, 0f, Time.deltaTime * 10f);
				}
				RightArmRoll.parent.localScale = new Vector3(ArmSize, ArmSize, ArmSize);
				RightFootprintSpawner.transform.parent.localScale = new Vector3(0f, 0f, 0f);
				LeftFootprintSpawner.transform.parent.localScale = new Vector3(0f, 0f, 0f);
				LeftArmRoll.parent.localScale = new Vector3(0f, 0f, 0f);
			}
		}
		if (SpiderLegs.activeInHierarchy)
		{
			if (SpiderGrow)
			{
				if (SpiderLegs.transform.localScale.x < 0.49f)
				{
					SpiderLegs.transform.localScale = Vector3.Lerp(SpiderLegs.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), Time.deltaTime * 5f);
					SchoolGlobals.SchoolAtmosphere = 1f - SpiderLegs.transform.localScale.x;
					StudentManager.SetAtmosphere();
				}
			}
			else if (SpiderLegs.transform.localScale.x > 0.001f)
			{
				SpiderLegs.transform.localScale = Vector3.Lerp(SpiderLegs.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 5f);
				SchoolGlobals.SchoolAtmosphere = 1f - SpiderLegs.transform.localScale.x;
				StudentManager.SetAtmosphere();
			}
		}
		if (PickUp != null && PickUp.Flashlight)
		{
			RightHand.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
		}
		if (ReachWeight > 0f)
		{
			CharacterAnimation["f02_reachForWeapon_00"].weight = ReachWeight;
			ReachWeight = Mathf.MoveTowards(ReachWeight, 0f, Time.deltaTime * 2f);
			if (ReachWeight < 0.01f)
			{
				ReachWeight = 0f;
				CharacterAnimation["f02_reachForWeapon_00"].weight = 0f;
			}
		}
		if (SanitySmudges.color.a > 1f - sanity / 100f + 0.0001f || SanitySmudges.color.a < 1f - sanity / 100f - 0.0001f)
		{
			float a = SanitySmudges.color.a;
			a = Mathf.MoveTowards(a, 1f - sanity / 100f, Time.deltaTime);
			SanitySmudges.color = new Color(1f, 1f, 1f, a);
			StudentManager.SelectiveGreyscale.desaturation = 1f - StudentManager.Atmosphere + a;
			if (a > 0.66666f)
			{
				float faces = 1f - (1f - a) / 0.33333f;
				if (!StudentManager.Randomize)
				{
					StudentManager.SetFaces(faces);
				}
			}
			else
			{
				StudentManager.SetFaces(0f);
			}
			SanityLabel.text = (100f - a * 100f).ToString("0") + "%";
		}
		if (CanMove && sanity < 33.333f && !NearSenpai && NearestPrompt == null)
		{
			GiggleTimer += Time.deltaTime * (1f - sanity / 33.333f);
			if (GiggleTimer > 10f)
			{
				Object.Instantiate(GiggleDisc, base.transform.position + Vector3.up, Quaternion.identity);
				AudioSource.PlayClipAtPoint(CreepyGiggles[Random.Range(0, CreepyGiggles.Length)], base.transform.position);
				InsaneLines.Play();
				GiggleTimer = 0f;
			}
		}
		if (FightHasBrokenUp)
		{
			BreakUpTimer = Mathf.MoveTowards(BreakUpTimer, 0f, Time.deltaTime);
			if (BreakUpTimer == 0f)
			{
				FightHasBrokenUp = false;
				SeenByAuthority = false;
			}
		}
		if (WearingRaincoat && !SetUpRaincoatOutline)
		{
			if (RaincoatAttacher.newRenderer.GetComponent<OutlineScript>() == null)
			{
				RaincoatAttacher.newRenderer.gameObject.AddComponent<OutlineScript>();
			}
			OutlineScript component = RaincoatAttacher.newRenderer.gameObject.GetComponent<OutlineScript>();
			if (component.h == null)
			{
				component.Awake();
				SetUpRaincoatOutline = true;
			}
			component.color = Outline.color;
			component.enabled = Outline.enabled;
		}
		if (MaidCheck)
		{
			GameObject obj = PelvisRoot.Find("Base").gameObject;
			GameObject gameObject = PelvisRoot.Find("Legs").gameObject;
			GameObject gameObject2 = PelvisRoot.Find("Outfit").gameObject;
			obj.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = MaidFace;
			obj.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = MaidBody;
			gameObject.GetComponent<SkinnedMeshRenderer>().material.mainTexture = MaidBody;
			gameObject2.GetComponent<SkinnedMeshRenderer>().material.mainTexture = MaidOutfit;
		}
	}

	public void StainWeapon()
	{
		Debug.Log("Yandere-chan is running the code for staining her equipped weapon with blood and marking it as evidence.");
		if (!(EquippedWeapon != null))
		{
			return;
		}
		Debug.Log("Yandere-chan's eqipped weapon is: " + EquippedWeapon);
		if (TargetStudent != null && TargetStudent.StudentID < EquippedWeapon.Victims.Length)
		{
			EquippedWeapon.Victims[TargetStudent.StudentID] = true;
		}
		if (!EquippedWeapon.Blood.enabled)
		{
			EquippedWeapon.Evidence = true;
			EquippedWeapon.Bloody = true;
			if (!Dismembering)
			{
				Police.MurderWeapons++;
			}
		}
		EquippedWeapon.Blood.enabled = true;
		EquippedWeapon.StainWithBlood();
		if (!Dismembering)
		{
			EquippedWeapon.MurderWeapon = true;
		}
		if (EquippedWeapon.Type == WeaponType.Bat)
		{
			NoStainGloves = true;
		}
		if (!NoStainGloves)
		{
			if ((Gloved || WearingRaincoat) && !Gloves.Blood.enabled)
			{
				GloveAttacher.newRenderer.material.mainTexture = BloodyGloveTexture;
				Gloves.PickUp.Evidence = true;
				Gloves.Blood.enabled = true;
				GloveBlood = 1;
				Police.BloodyClothing++;
			}
			if (Mask != null && !Mask.Blood.enabled)
			{
				Mask.PickUp.Evidence = true;
				Mask.Blood.enabled = true;
				Police.BloodyClothing++;
			}
		}
	}

	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 vector = target - base.transform.position;
		MyController.Move(vector * (Time.deltaTime * 10f));
	}

	public void StopAiming()
	{
		UpdateAccessory();
		UpdateHair();
		CharacterAnimation["f02_cameraPose_00"].weight = 0f;
		CharacterAnimation["f02_selfie_00"].weight = 0f;
		CharacterAnimation["f02_selfie_01"].weight = 0f;
		PelvisRoot.transform.localPosition = new Vector3(PelvisRoot.transform.localPosition.x, 0f, PelvisRoot.transform.localPosition.z);
		ShoulderCamera.AimingCamera = false;
		if (!Input.GetButtonDown(InputNames.Xbox_Start) && !Input.GetKeyDown(KeyCode.Escape))
		{
			FixCamera();
		}
		if (ShoulderCamera.Timer == 0f)
		{
			RPGCamera.enabled = true;
		}
		if (!OptionGlobals.Fog)
		{
			MainCamera.clearFlags = CameraClearFlags.Skybox;
		}
		else
		{
			MainCamera.clearFlags = CameraClearFlags.Color;
		}
		Smartphone.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		Smartphone.targetTexture = Shutter.SmartphoneScreen;
		Smartphone.transform.parent.gameObject.SetActive(value: false);
		Smartphone.fieldOfView = 60f;
		MainCamera.farClipPlane = OptionGlobals.DrawDistance;
		MainCamera.nearClipPlane = 0.1f;
		Shutter.TargetStudent = 0;
		Height = 0f;
		Bend = 0f;
		HandCamera.gameObject.SetActive(value: false);
		SelfieGuide.SetActive(value: false);
		PhonePromptBar.Show = false;
		MainCamera.enabled = true;
		Aiming = false;
		Selfie = false;
		Lewd = false;
		StudentManager.UpdatePanties(Status: false);
		if (OptionGlobals.DepthOfField)
		{
			PauseScreen.NewSettings.Profile.depthOfField.enabled = true;
		}
		if (Club == ClubType.Newspaper)
		{
			ClubAccessories[(int)Club].transform.localScale = new Vector3(1f, 1f, 1f);
		}
		MyController.radius = 0.2f;
		if (PreparingThrow)
		{
			IdleAnim = PreviousIdleAnim;
			WalkAnim = PreviousWalkAnim;
		}
		ShoulderCamera.OverShoulder = false;
		UsingController = false;
		PreparingThrow = false;
		PrepareThrowTimer = 0f;
		Throwing = false;
		NewArc.gameObject.SetActive(value: false);
		OutOfAmmo = false;
		PromptBar.ClearButtons();
		PromptBar.Show = false;
	}

	public void FixCamera()
	{
		if (!SneakingShot)
		{
			RPGCamera.enabled = true;
			RPGCamera.UpdateRotation();
			RPGCamera.mouseSmoothingFactor = 0f;
			RPGCamera.GetInput();
			RPGCamera.GetDesiredPosition();
			RPGCamera.PositionUpdate();
			RPGCamera.mouseSmoothingFactor = 0.08f;
		}
		Blur.enabled = false;
	}

	public void ResetSenpaiEffects()
	{
		SenpaiFilter.enabled = false;
		Phone.SetActive(value: false);
		for (int i = 1; i < 6; i++)
		{
			CharacterAnimation[CreepyIdles[i]].weight = 0f;
			CharacterAnimation[CreepyWalks[i]].weight = 0f;
		}
		CharacterAnimation["f02_shy_00"].weight = 0f;
		HeartBeat.volume = 0f;
		SelectGrayscale.desaturation = GreyTarget;
		SenpaiFade = 100f;
		SenpaiTint = 0f;
	}

	public void ResetYandereEffects()
	{
		YandereTimer = 0f;
		Phone.SetActive(value: false);
		CharacterAnimation["f02_phonePose_00"].weight = 0f;
		YandereVisionPanel.alpha = 0f;
		SenpaiGazing = false;
		CameraEffects.UpdateVignette(1f - Sanity * 0.01f);
		YandereFilter.FadeFX = 0f;
		YandereFilter.enabled = false;
		Time.timeScale = 1f;
		YandereFade = 100f;
		StudentManager.Tag.Sprite.color = new Color(1f, 0f, 0f, 0f);
		StudentManager.RedString.gameObject.SetActive(value: false);
		RightRedEye.material.color = new Color(1f, 1f, 1f, 0f);
		LeftRedEye.material.color = new Color(1f, 1f, 1f, 0f);
		RightYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
		LeftYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
		HighlightingR.enabled = false;
		HighlightingB.enabled = false;
		YandereVisionDrone.Stop();
	}

	private void DumpRagdoll(RagdollDumpType Type)
	{
		Ragdoll.transform.position = base.transform.position;
		switch (Type)
		{
		case RagdollDumpType.Incinerator:
			Ragdoll.transform.LookAt(Incinerator.transform.position);
			Ragdoll.transform.eulerAngles = new Vector3(Ragdoll.transform.eulerAngles.x, Ragdoll.transform.eulerAngles.y + 180f, Ragdoll.transform.eulerAngles.z);
			break;
		case RagdollDumpType.TranqCase:
			Ragdoll.transform.LookAt(TranqCase.transform.position);
			break;
		case RagdollDumpType.WoodChipper:
			Ragdoll.transform.LookAt(WoodChipper.transform.position);
			break;
		}
		RagdollScript component = Ragdoll.GetComponent<RagdollScript>();
		component.DumpType = Type;
		component.Dump();
	}

	public void Unequip()
	{
		Debug.Log("Yandere-chan has been told to de-equip whatever she currently has equipped - *if* she has anything equipped right now.");
		if (CanMove || Noticed || BypassRequirement)
		{
			Debug.Log("Yandere-chan has now de-equipped her weapon.");
			if (Equipped < 3)
			{
				CharacterAnimation["f02_reachForWeapon_00"].time = 0f;
				ReachWeight = 1f;
				if (EquippedWeapon != null)
				{
					EquippedWeapon.gameObject.SetActive(value: false);
				}
			}
			else if (Weapon[3] != null)
			{
				Weapon[3].Drop();
			}
			Equipped = 0;
			Mopping = false;
			StudentManager.UpdateStudents();
			WeaponManager.UpdateLabels();
			WeaponMenu.UpdateSprites();
			WeaponWarning = false;
			BypassRequirement = false;
		}
		UpdateConcealedWeaponStatus();
	}

	public void DropWeapon(int ID)
	{
		if (!Weapon[ID].Undroppable)
		{
			DropTimer[ID] += Time.deltaTime;
			if (DropTimer[ID] > 0.5f)
			{
				Weapon[ID].Drop();
				Weapon[ID] = null;
				Unequip();
				DropTimer[ID] = 0f;
			}
		}
	}

	public void EmptyHands()
	{
		if (Carrying || HeavyWeight)
		{
			StopCarrying();
		}
		if (Armed)
		{
			if (DropSpecifically)
			{
				EquippedWeapon.Drop();
			}
			else
			{
				Unequip();
			}
		}
		if (PickUp != null)
		{
			PickUp.Drop();
		}
		if (Dragging)
		{
			Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		for (ID = 1; ID < Poisons.Length; ID++)
		{
			Poisons[ID].SetActive(value: false);
		}
		Mopping = false;
		UpdateConcealedItemStatus();
	}

	public void UpdateNumbness()
	{
		Numbness = 1f - 0.1f * (float)(Class.Numbness + Class.NumbnessBonus + Class.PsychologyGrade + Class.PsychologyBonus);
		if (Club == ClubType.Occult)
		{
			Numbness -= 0.5f;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (StudentManager != null && !StudentManager.TutorialActive && other.gameObject.name == "BloodPool(Clone)" && other.transform.localScale.x > 0.3f)
		{
			RightFootprintSpawner.StudentBloodID = other.GetComponent<BloodPoolScript>().StudentBloodID;
			LeftFootprintSpawner.StudentBloodID = RightFootprintSpawner.StudentBloodID;
			if (PlayerGlobals.PantiesEquipped == 8)
			{
				RightFootprintSpawner.Bloodiness = 5;
				LeftFootprintSpawner.Bloodiness = 5;
			}
			else
			{
				RightFootprintSpawner.Bloodiness = 10;
				LeftFootprintSpawner.Bloodiness = 10;
			}
		}
	}

	public void UpdateHair()
	{
		if (Hairstyle > Hairstyles.Length - 1)
		{
			Hairstyle = 0;
		}
		if (Hairstyle < 0)
		{
			Hairstyle = Hairstyles.Length - 1;
		}
		for (ID = 1; ID < Hairstyles.Length; ID++)
		{
			Hairstyles[ID].SetActive(value: false);
		}
		if (Hairstyle > 0)
		{
			Hairstyles[Hairstyle].SetActive(value: true);
		}
		for (ID = 1; ID < Hairstyles.Length; ID++)
		{
			Hairstyles[ID].layer = 13;
		}
	}

	public void StopLaughing()
	{
		BladeHairCollider1.enabled = false;
		BladeHairCollider2.enabled = false;
		if (Sanity < 33.33333f)
		{
			Teeth.SetActive(value: true);
		}
		LaughIntensity = 0f;
		Laughing = false;
		LaughClip = null;
		Twitch = Vector3.zero;
		if (!Stand.Stand.activeInHierarchy)
		{
			CanMove = true;
		}
		if (BanchoActive)
		{
			AudioSource.PlayClipAtPoint(BanchoFinalYan, base.transform.position);
			CharacterAnimation.CrossFade("f02_banchoFinisher_00");
			BanchoFlurry.MyCollider.enabled = false;
			Finisher = true;
			CanMove = false;
		}
		if (StudentManager.Eighties)
		{
			RestoreGentleEyes();
		}
		if (sanity > 99f)
		{
			sanity = 100f;
		}
	}

	private void SetUniform()
	{
		if (StudentGlobals.FemaleUniform == 0)
		{
			StudentGlobals.FemaleUniform = 1;
		}
		MyRenderer.sharedMesh = Uniforms[StudentGlobals.FemaleUniform];
		if (Casual)
		{
			TextureToUse = UniformTextures[StudentGlobals.FemaleUniform];
		}
		else
		{
			TextureToUse = CasualTextures[StudentGlobals.FemaleUniform];
		}
		MyRenderer.materials[0].mainTexture = TextureToUse;
		MyRenderer.materials[1].mainTexture = TextureToUse;
		MyRenderer.materials[2].mainTexture = FaceTexture;
		StartCoroutine(ApplyCustomCostume());
	}

	private IEnumerator ApplyCustomCostume()
	{
		if (StudentGlobals.FemaleUniform == 1)
		{
			WWW CustomUniform4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
			yield return CustomUniform4;
			if (CustomUniform4.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform4.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform4.texture;
			}
		}
		else if (StudentGlobals.FemaleUniform == 2)
		{
			WWW CustomUniform4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
			yield return CustomUniform4;
			if (CustomUniform4.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform4.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform4.texture;
			}
		}
		else if (StudentGlobals.FemaleUniform == 3)
		{
			WWW CustomUniform4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
			yield return CustomUniform4;
			if (CustomUniform4.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform4.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform4.texture;
			}
		}
		else if (StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5)
		{
			WWW CustomUniform4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
			yield return CustomUniform4;
			if (CustomUniform4.error == null)
			{
				MyRenderer.materials[0].mainTexture = CustomUniform4.texture;
				MyRenderer.materials[1].mainTexture = CustomUniform4.texture;
			}
		}
		WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
		yield return CustomFace;
		if (CustomFace.error == null)
		{
			MyRenderer.materials[2].mainTexture = CustomFace.texture;
			FaceTexture = CustomFace.texture;
		}
		WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
		yield return CustomHair;
		if (CustomHair.error == null)
		{
			PonytailRenderer.material.mainTexture = CustomHair.texture;
			PigtailR.material.mainTexture = CustomHair.texture;
			PigtailL.material.mainTexture = CustomHair.texture;
		}
		WWW CustomLoose = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLoose.png");
		yield return CustomLoose;
		if (CustomLoose.error == null)
		{
			LooseRenderer.material.mainTexture = CustomLoose.texture;
		}
		WWW CustomDrills = new WWW("file:///" + Application.streamingAssetsPath + "/CustomDrills.png");
		yield return CustomDrills;
		if (CustomDrills.error == null)
		{
			Drills.materials[0].mainTexture = CustomDrills.texture;
			Drills.material.mainTexture = CustomDrills.texture;
		}
		WWW CustomSwimsuit = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSwimsuit.png");
		yield return CustomSwimsuit;
		if (CustomSwimsuit.error == null)
		{
			SwimsuitTexture = CustomSwimsuit.texture;
		}
		WWW CustomGym = new WWW("file:///" + Application.streamingAssetsPath + "/CustomGym.png");
		yield return CustomGym;
		if (CustomGym.error == null)
		{
			GymTexture = CustomGym.texture;
		}
		WWW CustomNude = new WWW("file:///" + Application.streamingAssetsPath + "/CustomNude.png");
		yield return CustomNude;
		if (CustomNude.error == null)
		{
			NudeTexture = CustomNude.texture;
		}
		WWW CustomLongHairA = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairA.png");
		yield return CustomDrills;
		WWW CustomLongHairB = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairB.png");
		yield return CustomDrills;
		WWW CustomLongHairC = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairC.png");
		yield return CustomDrills;
		if (CustomLongHairA.error == null && CustomLongHairB.error == null && CustomLongHairC.error == null)
		{
			LongHairRenderer.materials[0].mainTexture = CustomLongHairA.texture;
			LongHairRenderer.materials[1].mainTexture = CustomLongHairB.texture;
			LongHairRenderer.materials[2].mainTexture = CustomLongHairC.texture;
		}
	}

	public void WearGloves()
	{
		if (Bloodiness > 0f && !Gloves.Blood.enabled)
		{
			Gloves.PickUp.Evidence = true;
			Gloves.Blood.enabled = true;
		}
		if (Gloves.Blood.enabled)
		{
			GloveBlood = 1;
		}
		Gloved = true;
		if (WearingRaincoat)
		{
			if (Bloodiness > CoatBloodiness)
			{
				CoatBloodiness = Bloodiness;
			}
			WearRaincoat();
			if (RaincoatAttacher.newRenderer != null)
			{
				RaincoatAttacher.newRenderer.enabled = true;
			}
			OriginalBloodiness = Bloodiness;
			Bloodiness = CoatBloodiness;
		}
		else
		{
			GloveAttacher.newRenderer.enabled = true;
		}
		if (StudentGlobals.FemaleUniform == 2 || StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5 || StudentGlobals.FemaleUniform == 6)
		{
			GloveAttacher.newRenderer.SetBlendShapeWeight(0, 100f);
		}
	}

	private void AttackOnTitan()
	{
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = TitanBodyTexture;
		MyRenderer.materials[1].mainTexture = TitanFaceTexture;
		MyRenderer.materials[2].mainTexture = TitanBodyTexture;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		ODMGear.SetActive(value: true);
		TitanSword[0].SetActive(value: true);
		TitanSword[1].SetActive(value: true);
		IdleAnim = "f02_heroicIdle_00";
		WalkAnim = "f02_walkConfident_00";
		RunAnim = "f02_sithRun_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		RunSpeed *= 2f;
		MusicCredit.SongLabel.text = "Now Playing: This Is My Choice";
		MusicCredit.BandLabel.text = "By: The Kira Justice";
		MusicCredit.Sprite.enabled = true;
		MusicCredit.Slide = true;
		EasterEggMenu.SetActive(value: false);
		Egg = true;
		Outline.h.ReinitMaterials();
	}

	private void KON()
	{
		MyRenderer.sharedMesh = Uniforms[4];
		MyRenderer.materials[0].mainTexture = KONTexture;
		MyRenderer.materials[1].mainTexture = KONTexture;
		MyRenderer.materials[2].mainTexture = FaceTexture;
		Outline.h.ReinitMaterials();
	}

	private void Punish()
	{
		PunishedShader = Shader.Find("Toon/Cutoff");
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		EasterEggMenu.SetActive(value: false);
		Egg = true;
		PunishedAccessories.SetActive(value: true);
		PunishedScarf.SetActive(value: true);
		EyepatchL.SetActive(value: false);
		EyepatchR.SetActive(value: false);
		for (ID = 0; ID < PunishedArm.Length; ID++)
		{
			PunishedArm[ID].SetActive(value: true);
		}
		MyRenderer.sharedMesh = PunishedMesh;
		MyRenderer.materials[0].mainTexture = PunishedTextures[1];
		MyRenderer.materials[1].mainTexture = PunishedTextures[1];
		MyRenderer.materials[2].mainTexture = PunishedTextures[0];
		MyRenderer.materials[1].shader = PunishedShader;
		MyRenderer.materials[1].SetFloat("_Shininess", 1f);
		MyRenderer.materials[1].SetFloat("_ShadowThreshold", 0f);
		MyRenderer.materials[1].SetFloat("_Cutoff", 0.9f);
		MyRenderer.materials[1].color = new Color(1f, 1f, 1f, 1f);
		Outline.h.ReinitMaterials();
	}

	private void Hate()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = Uniforms[1];
		MyRenderer.materials[0].mainTexture = HatefulUniform;
		MyRenderer.materials[1].mainTexture = HatefulUniform;
		MyRenderer.materials[2].mainTexture = FaceTexture;
		RenderSettings.skybox = HatefulSkybox;
		SelectGrayscale.desaturation = 1f;
		HeartRate.gameObject.SetActive(value: false);
		Sanity = 0f;
		Hairstyle = 15;
		UpdateHair();
		EasterEggMenu.SetActive(value: false);
		Egg = true;
	}

	private void Sukeban()
	{
		IdleAnim = "f02_idle_00";
		SukebanAccessories.SetActive(value: true);
		MyRenderer.sharedMesh = Uniforms[1];
		MyRenderer.materials[1].mainTexture = SukebanBandages;
		MyRenderer.materials[0].mainTexture = SukebanUniform;
		MyRenderer.materials[2].mainTexture = FaceTexture;
		EasterEggMenu.SetActive(value: false);
		Egg = true;
	}

	private void Bancho()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		BanchoCamera.SetActive(value: true);
		MotionObject.enabled = true;
		MotionBlur.enabled = true;
		BanchoAccessories[0].SetActive(value: true);
		BanchoAccessories[1].SetActive(value: true);
		BanchoAccessories[2].SetActive(value: true);
		BanchoAccessories[3].SetActive(value: true);
		BanchoAccessories[4].SetActive(value: true);
		BanchoAccessories[5].SetActive(value: true);
		BanchoAccessories[6].SetActive(value: true);
		BanchoAccessories[7].SetActive(value: true);
		BanchoAccessories[8].SetActive(value: true);
		Laugh1 = BanchoYanYan;
		Laugh2 = BanchoYanYan;
		Laugh3 = BanchoYanYan;
		Laugh4 = BanchoYanYan;
		IdleAnim = "f02_banchoIdle_00";
		WalkAnim = "f02_banchoWalk_00";
		RunAnim = "f02_banchoSprint_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		RunSpeed *= 2f;
		BanchoPants.SetActive(value: true);
		MyRenderer.sharedMesh = BanchoMesh;
		MyRenderer.materials[0].mainTexture = BanchoFace;
		MyRenderer.materials[1].mainTexture = BanchoBody;
		MyRenderer.materials[2].mainTexture = BanchoBody;
		BanchoActive = true;
		TheDebugMenuScript.UpdateCensor();
		Character.transform.localPosition = new Vector3(0f, 0.04f, 0f);
		Hairstyle = 0;
		UpdateHair();
		EasterEggMenu.SetActive(value: false);
		Egg = true;
	}

	private void Slend()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		RenderSettings.skybox = SlenderSkybox;
		SelectGrayscale.desaturation = 0.5f;
		SelectGrayscale.enabled = true;
		EasterEggMenu.SetActive(value: false);
		Slender = true;
		Egg = true;
		Hairstyle = 0;
		UpdateHair();
		SlenderHair[0].transform.parent.gameObject.SetActive(value: true);
		SlenderHair[0].SetActive(value: true);
		SlenderHair[1].SetActive(value: true);
		RightYandereEye.gameObject.SetActive(value: false);
		LeftYandereEye.gameObject.SetActive(value: false);
		Character.transform.localPosition = new Vector3(Character.transform.localPosition.x, 0.822f, Character.transform.localPosition.z);
		MyRenderer.sharedMesh = Uniforms[1];
		MyRenderer.materials[0].mainTexture = SlenderUniform;
		MyRenderer.materials[1].mainTexture = SlenderUniform;
		MyRenderer.materials[2].mainTexture = SlenderSkin;
		Sanity = 0f;
	}

	private void X()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		Xtan = true;
		Egg = true;
		Hairstyle = 9;
		UpdateHair();
		BlackEyePatch.SetActive(value: true);
		XSclera.SetActive(value: true);
		XEye.SetActive(value: true);
		Schoolwear = 2;
		ChangeSchoolwear();
		CanMove = true;
		MyRenderer.materials[0].mainTexture = XBody;
		MyRenderer.materials[1].mainTexture = XBody;
		MyRenderer.materials[2].mainTexture = XFace;
	}

	private void GaloSengen()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		IdleAnim = "f02_gruntIdle_00";
		EasterEggMenu.SetActive(value: false);
		Egg = true;
		for (ID = 0; ID < GaloAccessories.Length; ID++)
		{
			GaloAccessories[ID].SetActive(value: true);
		}
		MyRenderer.sharedMesh = Uniforms[1];
		MyRenderer.materials[0].mainTexture = UniformTextures[1];
		MyRenderer.materials[1].mainTexture = GaloArms;
		MyRenderer.materials[2].mainTexture = GaloFace;
		Hairstyle = 14;
		UpdateHair();
	}

	public void Jojo()
	{
		ShoulderCamera.LastPosition = ShoulderCamera.transform.position;
		ShoulderCamera.Summoning = true;
		RPGCamera.enabled = false;
		AudioSource.PlayClipAtPoint(SummonStand, base.transform.position);
		IdleAnim = "f02_jojoPose_00";
		WalkAnim = "f02_jojoWalk_00";
		EasterEggMenu.SetActive(value: false);
		CanMove = false;
		Egg = true;
		CharacterAnimation.CrossFade("f02_summonStand_00");
		Laugh1 = YanYan;
		Laugh2 = YanYan;
		Laugh3 = YanYan;
		Laugh4 = YanYan;
	}

	private void Agent()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = Uniforms[4];
		MyRenderer.materials[0].mainTexture = AgentSuit;
		MyRenderer.materials[1].mainTexture = AgentSuit;
		MyRenderer.materials[2].mainTexture = AgentFace;
		EasterEggMenu.SetActive(value: false);
		Egg = true;
		Barcode.SetActive(value: true);
		Hairstyle = 0;
		UpdateHair();
	}

	private void Cirno()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = Uniforms[3];
		MyRenderer.materials[0].mainTexture = CirnoUniform;
		MyRenderer.materials[1].mainTexture = CirnoUniform;
		MyRenderer.materials[2].mainTexture = CirnoFace;
		CirnoWings.SetActive(value: true);
		CirnoHair.SetActive(value: true);
		IdleAnim = "f02_cirnoIdle_00";
		WalkAnim = "f02_cirnoWalk_00";
		RunAnim = "f02_cirnoRun_00";
		EasterEggMenu.SetActive(value: false);
		Stance.Current = StanceType.Standing;
		Uncrouch();
		Egg = true;
		Hairstyle = 0;
		UpdateHair();
	}

	private void Falcon()
	{
		MyRenderer.sharedMesh = NudeMesh;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].mainTexture = FalconBody;
		MyRenderer.materials[1].mainTexture = FalconFace;
		MyRenderer.materials[2].mainTexture = FalconBody;
		FalconShoulderpad.SetActive(value: true);
		FalconKneepad1.SetActive(value: true);
		FalconKneepad2.SetActive(value: true);
		FalconBuckle.SetActive(value: true);
		FalconHelmet.SetActive(value: true);
		CharacterAnimation[RunAnim].speed = 5f;
		IdleAnim = "f02_falconIdle_00";
		RunSpeed *= 5f;
		Egg = true;
		Hairstyle = 3;
		UpdateHair();
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Punch()
	{
		MusicCredit.SongLabel.text = "Now Playing: Unknown Hero";
		MusicCredit.BandLabel.text = "By: The Kira Justice";
		MusicCredit.Sprite.enabled = true;
		MusicCredit.Slide = true;
		MyRenderer.sharedMesh = SchoolSwimsuit;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].mainTexture = SaitamaSuit;
		MyRenderer.materials[1].mainTexture = SaitamaSuit;
		MyRenderer.materials[2].mainTexture = FaceTexture;
		EasterEggMenu.SetActive(value: false);
		Barcode.SetActive(value: false);
		Cape.SetActive(value: true);
		Egg = true;
		Hairstyle = 0;
		UpdateHair();
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void BadTime()
	{
		MyRenderer.sharedMesh = Jersey;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].mainTexture = SansFace;
		MyRenderer.materials[1].mainTexture = SansTexture;
		MyRenderer.materials[2].mainTexture = SansTexture;
		EasterEggMenu.SetActive(value: false);
		IdleAnim = "f02_sansIdle_00";
		WalkAnim = "f02_sansWalk_00";
		RunAnim = "f02_sansRun_00";
		StudentManager.BadTime();
		Barcode.SetActive(value: false);
		Sans = true;
		Egg = true;
		Hairstyle = 0;
		UpdateHair();
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().EasterEggCheck();
	}

	private void CyborgNinja()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		EnergySword.SetActive(value: true);
		IdleAnim = "CyborgNinja_Idle_Unarmed";
		RunAnim = "CyborgNinja_Run_Unarmed";
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = CyborgBody;
		MyRenderer.materials[1].mainTexture = CyborgFace;
		MyRenderer.materials[2].mainTexture = CyborgBody;
		Schoolwear = 0;
		for (ID = 1; ID < CyborgParts.Length; ID++)
		{
			CyborgParts[ID].SetActive(value: true);
		}
		for (ID = 1; ID < StudentManager.Students.Length; ID++)
		{
			StudentScript studentScript = StudentManager.Students[ID];
			if (studentScript != null)
			{
				studentScript.Teacher = false;
				studentScript.Strength = 0;
			}
		}
		RunSpeed *= 2f;
		EyewearID = 6;
		Hairstyle = 45;
		UpdateHair();
		Ninja = true;
		Egg = true;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Ebola()
	{
		StudentManager.Ebola = true;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		IdleAnim = "f02_ebolaIdle_00";
		Nude();
		MyRenderer.enabled = false;
		Hairstyle = 0;
		UpdateHair();
		EbolaAttacher.SetActive(value: true);
		EbolaWings.SetActive(value: true);
		EbolaHair.SetActive(value: true);
		Egg = true;
	}

	private void Long()
	{
		MyRenderer.sharedMesh = LongUniform;
	}

	private void SwapMesh()
	{
		MyRenderer.sharedMesh = NewMesh;
		MyRenderer.materials[0].mainTexture = TextureToUse;
		MyRenderer.materials[1].mainTexture = NewFace;
		MyRenderer.materials[2].mainTexture = TextureToUse;
		RightYandereEye.gameObject.SetActive(value: false);
		LeftYandereEye.gameObject.SetActive(value: false);
	}

	private void Nude()
	{
		Debug.Log("Making Yandere-chan nude.");
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = NudeTexture;
		MyRenderer.materials[1].mainTexture = FaceTexture;
		for (ID = 0; ID < CensorSteam.Length; ID++)
		{
		}
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
		EasterEggMenu.SetActive(value: false);
		ClubAttire = false;
		Schoolwear = 0;
		bool flag = false;
		if (EightiesBikiniAttacher.gameObject.activeInHierarchy || (EightiesBikiniAttacher.newRenderer != null && EightiesBikiniAttacher.newRenderer.enabled))
		{
			flag = true;
		}
		if (StudentManager.Eighties && !flag)
		{
			for (int i = 0; i < 13; i++)
			{
				MyRenderer.SetBlendShapeWeight(i, 0f);
			}
		}
		ClubAccessory();
	}

	private void Samus()
	{
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = SamusBody;
		MyRenderer.materials[1].mainTexture = SamusFace;
		PantyAttacher.newRenderer.enabled = false;
		Schoolwear = 0;
		PonytailRenderer.material.mainTexture = BlondePony;
		Egg = true;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Witch()
	{
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = WitchBody;
		MyRenderer.materials[1].mainTexture = WitchFace;
		PantyAttacher.newRenderer.enabled = false;
		Schoolwear = 0;
		IdleAnim = "f02_idleElegant_00";
		WalkAnim = "f02_jojoWalk_00";
		WitchMode = true;
		Egg = true;
		Hairstyle = 100;
		UpdateHair();
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Pose()
	{
		if (!StudentManager.Pose)
		{
			StudentManager.Pose = true;
		}
		else
		{
			StudentManager.Pose = false;
		}
		StudentManager.UpdateStudents();
		SenpaiThreshold = 0f;
		StudentScript studentScript = StudentManager.Students[1];
		studentScript.Prompt.enabled = true;
		studentScript.Prompt.ButtonActive[0] = true;
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

	private void HairBlades()
	{
		Hairstyle = 0;
		UpdateHair();
		BladeHair.SetActive(value: true);
		Egg = true;
	}

	private void Tornado()
	{
		Hairstyle = 0;
		UpdateHair();
		IdleAnim = "f02_tornadoIdle_00";
		WalkAnim = "f02_tornadoWalk_00";
		RunAnim = "f02_tornadoRun_00";
		TornadoHair.SetActive(value: true);
		TornadoDress.SetActive(value: true);
		RiggedAccessory.SetActive(value: true);
		MyRenderer.sharedMesh = NoTorsoMesh;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		Sanity = 100f;
		MyRenderer.materials[0].mainTexture = FaceTexture;
		MyRenderer.materials[1].mainTexture = NudePanties;
		MyRenderer.materials[2].mainTexture = NudePanties;
		TheDebugMenuScript.UpdateCensor();
		Stance.Current = StanceType.Standing;
		Egg = true;
	}

	private void GenderSwap()
	{
		Kun.SetActive(value: true);
		KunHair.SetActive(value: true);
		MyRenderer.enabled = false;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		IdleAnim = "idleShort_00";
		WalkAnim = "walk_00";
		RunAnim = "newSprint_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		Hairstyle = 0;
		UpdateHair();
	}

	private void Mandere()
	{
		Man.SetActive(value: true);
		Barcode.SetActive(value: false);
		MyRenderer.enabled = false;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		RightYandereEye.gameObject.SetActive(value: false);
		LeftYandereEye.gameObject.SetActive(value: false);
		IdleAnim = "idleShort_00";
		WalkAnim = "walk_00";
		RunAnim = "newSprint_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		Hairstyle = 0;
		UpdateHair();
	}

	private void BlackHoleChan()
	{
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = Black;
		MyRenderer.materials[1].mainTexture = BlackHoleFace;
		MyRenderer.materials[2].mainTexture = Black;
		PantyAttacher.newRenderer.enabled = false;
		Schoolwear = 0;
		IdleAnim = "f02_gazerIdle_00";
		WalkAnim = "f02_gazerWalk_00";
		RunAnim = "f02_gazerRun_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		Hairstyle = 182;
		UpdateHair();
		BlackHoleEffects.SetActive(value: true);
		BlackHole = true;
		Egg = true;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void ElfenLied()
	{
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = NudeTexture;
		MyRenderer.materials[1].mainTexture = FaceTexture;
		MyRenderer.materials[2].mainTexture = NudeTexture;
		GameObject[] vectors = Vectors;
		for (int i = 0; i < vectors.Length; i++)
		{
			vectors[i].SetActive(value: true);
		}
		IdleAnim = "f02_sixIdle_00";
		WalkAnim = "f02_sixWalk_00";
		RunAnim = "f02_sixRun_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		LucyHelmet.SetActive(value: true);
		Bandages.SetActive(value: true);
		Egg = true;
		WalkSpeed = 0.75f;
		RunSpeed = 2f;
		Hairstyle = 0;
		UpdateHair();
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Ghoul()
	{
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = GhoulBody;
		MyRenderer.materials[1].mainTexture = GhoulFace;
		MyRenderer.materials[2].mainTexture = GhoulBody;
		GameObject[] kagune = Kagune;
		for (int i = 0; i < kagune.Length; i++)
		{
			kagune[i].SetActive(value: true);
		}
		IdleAnim = "f02_sixIdle_00";
		WalkAnim = "f02_sixWalk_00";
		RunAnim = "f02_psychoRun_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		StudentManager.Six = true;
		StudentManager.UpdateStudents();
		Egg = true;
		WalkSpeed = 0.75f;
		RunSpeed = 10f;
		Hairstyle = 15;
		UpdateHair();
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Berserk()
	{
		SchoolGlobals.SchoolAtmosphere = 0.5f;
		StudentManager.SetAtmosphere();
		GameObject[] armor = Armor;
		for (int i = 0; i < armor.Length; i++)
		{
			armor[i].SetActive(value: true);
		}
		Renderer[] trees = StudentManager.Trees;
		for (int i = 0; i < trees.Length; i++)
		{
			trees[i].materials[1] = Trans;
		}
		SithSpawnTime = NierSpawnTime;
		SithHardSpawnTime1 = NierHardSpawnTime;
		SithHardSpawnTime2 = NierHardSpawnTime;
		SithAudio.clip = NierSwoosh;
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = Chainmail;
		MyRenderer.materials[1].mainTexture = Scarface;
		MyRenderer.materials[2].mainTexture = Chainmail;
		PantyAttacher.newRenderer.enabled = false;
		Schoolwear = 0;
		TheDebugMenuScript.UpdateCensor();
		IdleAnim = "f02_heroicIdle_00";
		WalkAnim = "f02_walkConfident_00";
		RunAnim = "f02_nierRun_00";
		CharacterAnimation["f02_nierRun_00"].speed = 1f;
		CharacterAnimation["f02_gutsEye_00"].weight = 1f;
		RunSpeed = 7.5f;
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		Hairstyle = 188;
		UpdateHair();
		Egg = true;
	}

	private void Sith()
	{
		Hairstyle = 67;
		UpdateHair();
		SithTrail1.SetActive(value: true);
		SithTrail2.SetActive(value: true);
		IdleAnim = "f02_sithIdle_00";
		WalkAnim = "f02_sithWalk_00";
		RunAnim = "f02_sithRun_00";
		BlackRobe.SetActive(value: true);
		MyRenderer.sharedMesh = NoUpperBodyMesh;
		MyRenderer.materials[0].mainTexture = NudePanties;
		MyRenderer.materials[1].mainTexture = FaceTexture;
		MyRenderer.materials[2].mainTexture = NudePanties;
		Stance.Current = StanceType.Standing;
		FollowHips = true;
		SithLord = true;
		Egg = true;
		Police.Clock.CameraEffects.Profile.depthOfField.enabled = false;
		TheDebugMenuScript.UpdateCensor();
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		RunSpeed *= 2f;
		Zoom.TargetZoom = 0.4f;
	}

	private void Snake()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = Uniforms[1];
		MyRenderer.materials[0].mainTexture = SnakeBody;
		MyRenderer.materials[1].mainTexture = SnakeBody;
		MyRenderer.materials[2].mainTexture = SnakeFace;
		Hairstyle = 161;
		UpdateHair();
		Medusa = true;
		Egg = true;
	}

	private void Gazer()
	{
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		GazerEyes.gameObject.SetActive(value: true);
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = GazerBody;
		MyRenderer.materials[1].mainTexture = GazerFace;
		MyRenderer.materials[2].mainTexture = GazerBody;
		PantyAttacher.newRenderer.enabled = false;
		Schoolwear = 0;
		IdleAnim = "f02_gazerIdle_00";
		WalkAnim = "f02_gazerWalk_00";
		RunAnim = "f02_gazerRun_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		Hairstyle = 158;
		UpdateHair();
		StudentManager.Gaze = true;
		StudentManager.UpdateStudents();
		Gazing = true;
		Egg = true;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Six()
	{
		RenderSettings.skybox = HatefulSkybox;
		Hairstyle = 0;
		UpdateHair();
		IdleAnim = "f02_sixIdle_00";
		WalkAnim = "f02_sixWalk_00";
		RunAnim = "f02_sixRun_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		SixRaincoat.SetActive(value: true);
		MyRenderer.sharedMesh = SixBodyMesh;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].mainTexture = NudeTexture;
		MyRenderer.materials[1].mainTexture = SixFaceTexture;
		MyRenderer.materials[2].mainTexture = NudeTexture;
		TheDebugMenuScript.UpdateCensor();
		SchoolGlobals.SchoolAtmosphere = 0f;
		StudentManager.SetAtmosphere();
		StudentManager.Six = true;
		StudentManager.UpdateStudents();
		StudentManager.DepowerStudentCouncil();
		WalkSpeed = 0.75f;
		RunSpeed = 2f;
		Hungry = true;
		Egg = true;
		StudentManager.Students[1].Blind = true;
	}

	public void WearRaincoat()
	{
		Debug.Log("Yandere-chan is now firing the WearRaincoat() function.");
		HairstyleBeforeRaincoat = Hairstyle;
		if (VtuberID == 0)
		{
			if (!StudentManager.Eighties)
			{
				Hairstyle = 200;
			}
			else
			{
				Hairstyle = 204;
			}
			UpdateHair();
		}
		RaincoatAttacher.gameObject.SetActive(value: true);
		MyRenderer.sharedMesh = HeadAndKnees;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].mainTexture = FaceTexture;
		MyRenderer.materials[1].mainTexture = NudeTexture;
		MyRenderer.materials[2].mainTexture = NudeTexture;
		TheDebugMenuScript.UpdateCensor();
		ClubAccessory();
	}

	private void KLK()
	{
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		KLKSword.SetActive(value: true);
		IdleAnim = "f02_heroicIdle_00";
		WalkAnim = "f02_walkConfident_00";
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = KLKBody;
		MyRenderer.materials[1].mainTexture = KLKFace;
		MyRenderer.materials[2].mainTexture = KLKBody;
		PantyAttacher.newRenderer.enabled = false;
		Schoolwear = 0;
		for (ID = 0; ID < KLKParts.Length; ID++)
		{
			KLKParts[ID].SetActive(value: true);
		}
		for (ID = 1; ID < StudentManager.Students.Length; ID++)
		{
			StudentScript studentScript = StudentManager.Students[ID];
			if (studentScript != null)
			{
				studentScript.Teacher = false;
			}
		}
		Egg = true;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	public void Miyuki()
	{
		MiyukiCostume.SetActive(value: true);
		MiyukiWings.SetActive(value: true);
		IdleAnim = "f02_idleGirly_00";
		WalkAnim = "f02_walkGirly_00";
		MyRenderer.sharedMesh = NudeMesh;
		MyRenderer.materials[0].mainTexture = MiyukiSkin;
		MyRenderer.materials[1].mainTexture = MiyukiFace;
		MyRenderer.materials[2].mainTexture = MiyukiSkin;
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		TheDebugMenuScript.UpdateCensor();
		Jukebox.MiyukiMusic();
		Hairstyle = 171;
		UpdateHair();
		MagicalGirl = true;
		Egg = true;
	}

	public void AzurLane()
	{
		Schoolwear = 2;
		ChangeSchoolwear();
		PantyAttacher.newRenderer.enabled = false;
		IdleAnim = "f02_gazerIdle_00";
		WalkAnim = "f02_gazerWalk_00";
		RunAnim = "f02_gazerRun_00";
		OriginalIdleAnim = IdleAnim;
		OriginalWalkAnim = WalkAnim;
		OriginalRunAnim = RunAnim;
		AzurGuns.SetActive(value: true);
		AzurWater.SetActive(value: true);
		AzurMist.SetActive(value: true);
		Shipgirl = true;
		CanMove = true;
		Egg = true;
		Jukebox.Shipgirl();
	}

	private void GarbageMode()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.sharedMesh = null;
		Hairstyle = 0;
		UpdateHair();
		GarbageBag.SetActive(value: true);
		for (ID = 1; ID < 101; ID++)
		{
			if (StudentManager.Students[ID] != null && StudentManager.Students[ID].gameObject.activeInHierarchy)
			{
				StudentManager.Students[ID].Cosmetic.HairRenderer.gameObject.SetActive(value: false);
				StudentManager.Students[ID].MyRenderer.enabled = false;
				StudentManager.Students[ID].GarbageBag.SetActive(value: true);
			}
		}
	}

	private void TallMode()
	{
		SchoolGlobals.SchoolAtmosphere = 0.5f;
		StudentManager.SetAtmosphere();
		TallLadyAttacher.SetActive(value: true);
		BlackRose.SetActive(value: true);
		FloppyHat.SetActive(value: true);
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.sharedMesh = null;
		Hairstyle = 201;
		UpdateHair();
		IdleAnim = "f02_idleGraceful_00";
		WalkAnim = "f02_walkGraceful_00";
		OriginalIdleAnim = "f02_idleGraceful_00";
		OriginalWalkAnim = "f02_walkGraceful_00";
		CharacterAnimation["f02_sithAttack_00"].speed = 1f;
		CharacterAnimation["f02_sithAttack_01"].speed = 1f;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
		base.transform.localScale = new Vector3(1.27f, 1.27f, 1.27f);
		RightBreast.localScale = new Vector3(1.5f, 1.5f, 1.5f);
		LeftBreast.localScale = new Vector3(1.5f, 1.5f, 1.5f);
		BoobPhysics[0].enabled = true;
		BoobPhysics[1].enabled = true;
		Egg = true;
	}

	private void HollowMode()
	{
		RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
		RenderSettings.skybox = HorrorSkybox;
		SchoolGlobals.SchoolAtmosphere = 0f;
		StudentManager.SetAtmosphere();
		HollowCloakAttacher.SetActive(value: true);
		HollowSword.SetActive(value: true);
		HollowMask.SetActive(value: true);
		DarkParticles.SetActive(value: true);
		MyRenderer.sharedMesh = NoButtMesh;
		MyRenderer.materials[0].mainTexture = HollowFaceTexture;
		MyRenderer.materials[1].mainTexture = HollowBodyTexture;
		Hairstyle = 0;
		UpdateHair();
		RunAnim = "f02_nierRun_00";
		CharacterAnimation["f02_nierRun_00"].speed = 1f;
		RunSpeed = 7.5f;
		CharacterAnimation["f02_sithAttack_00"].speed = 1f;
		CharacterAnimation["f02_sithAttack_01"].speed = 1f;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
		PantyAttacher.newRenderer.enabled = false;
		HollowFilter.enabled = true;
		Invisible = true;
		for (ID = 1; ID < StudentManager.Students.Length; ID++)
		{
			StudentScript studentScript = StudentManager.Students[ID];
			if (studentScript != null)
			{
				studentScript.Teacher = false;
			}
		}
		Egg = true;
	}

	private void Blacklight()
	{
		BlacklightShader.enabled = true;
		Hairstyle = 196;
		UpdateHair();
		IdleAnim = "f02_idleElegant_00";
		WalkAnim = "f02_jojoWalk_00";
		OriginalIdleAnim = "f02_idleElegant_00";
		OriginalWalkAnim = "f02_jojoWalk_00";
		BlacklightOutfit.SetActive(value: true);
		MyRenderer.sharedMesh = BlacklightBodyMesh;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].mainTexture = FaceTexture;
		MyRenderer.materials[1].mainTexture = NudeTexture;
		MyRenderer.materials[2].mainTexture = NudeTexture;
		Egg = true;
	}

	public void Weather()
	{
		if (!Rain.activeInHierarchy)
		{
			SchoolGlobals.SchoolAtmosphere = 0f;
			StudentManager.SetAtmosphere();
			Rain.SetActive(value: true);
			Jukebox.Start();
			return;
		}
		Hairstyle = 67;
		UpdateHair();
		RaincoatAttacher.gameObject.SetActive(value: true);
		MyRenderer.sharedMesh = SixBodyMesh;
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].mainTexture = FaceTexture;
		MyRenderer.materials[1].mainTexture = NudeTexture;
		MyRenderer.materials[2].mainTexture = NudeTexture;
		TheDebugMenuScript.UpdateCensor();
	}

	private void Horror()
	{
		Class.Portal.EndEvents();
		Rain.SetActive(value: false);
		RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
		RenderSettings.skybox = HorrorSkybox;
		SchoolGlobals.SchoolAtmosphere = 0f;
		StudentManager.SetAtmosphere();
		RPGCamera.desiredDistance = 0.33333f;
		Zoom.OverShoulder = true;
		Zoom.TargetZoom = 0.2f;
		PauseScreen.MissionMode.FPS.transform.localPosition = new Vector3(1020f, -465f, 0f);
		PauseScreen.MissionMode.Watermark.gameObject.SetActive(value: false);
		PauseScreen.MissionMode.Nemesis.SetActive(value: true);
		StudentManager.Clock.MainLight.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		StudentManager.Clock.gameObject.SetActive(value: false);
		StudentManager.Clock.SunFlare.SetActive(value: false);
		StudentManager.Clock.Horror = true;
		StudentManager.Students[1].transform.position = new Vector3(0f, 0f, 0f);
		StudentManager.Headmaster.gameObject.SetActive(value: false);
		StudentManager.Reputation.gameObject.SetActive(value: false);
		StudentManager.Flashlight.gameObject.SetActive(value: true);
		StudentManager.Flashlight.BePickedUp();
		StudentManager.DelinquentRadio.SetActive(value: false);
		StudentManager.CounselorDoor[0].enabled = false;
		StudentManager.CounselorDoor[1].enabled = false;
		StudentManager.CounselorDoor[0].Prompt.enabled = false;
		StudentManager.CounselorDoor[1].Prompt.enabled = false;
		StudentManager.Portal.SetActive(value: false);
		RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
		for (ID = 1; ID < 101; ID++)
		{
			if (StudentManager.Students[ID] != null && StudentManager.Students[ID].gameObject.activeInHierarchy)
			{
				StudentManager.DisableStudent(ID);
			}
		}
		Egg = true;
	}

	private void LifeNote()
	{
		for (ID = 1; ID < 101; ID++)
		{
			StudentManager.StudentPhotographed[ID] = true;
		}
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		LifeNotebook.transform.position = base.transform.position + base.transform.forward + new Vector3(0f, 2.5f, 0f);
		LifeNotebook.GetComponent<Rigidbody>().useGravity = true;
		LifeNotebook.GetComponent<Rigidbody>().isKinematic = false;
		LifeNotebook.gameObject.SetActive(value: true);
		MyRenderer.sharedMesh = YamikoMesh;
		MyRenderer.materials[0].mainTexture = YamikoSkinTexture;
		MyRenderer.materials[1].mainTexture = YamikoAccessoryTexture;
		MyRenderer.materials[2].mainTexture = YamikoFaceTexture;
		PantyAttacher.newRenderer.enabled = false;
		Schoolwear = 0;
		Hairstyle = 180;
		UpdateHair();
		StudentManager.NoteWindow.BecomeLifeNote();
		Egg = true;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	private void Nier()
	{
		NierCostume.SetActive(value: true);
		HeavySwordParent.gameObject.SetActive(value: true);
		LightSwordParent.gameObject.SetActive(value: true);
		HeavySword.GetComponent<WeaponTrail>().Start();
		LightSword.GetComponent<WeaponTrail>().Start();
		HeavySword.GetComponent<WeaponTrail>().enabled = false;
		LightSword.GetComponent<WeaponTrail>().enabled = false;
		Pod.SetActive(value: true);
		SithSpawnTime = NierSpawnTime;
		SithHardSpawnTime1 = NierHardSpawnTime;
		SithHardSpawnTime2 = NierHardSpawnTime;
		SithAudio.clip = NierSwoosh;
		Pod.transform.parent = null;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.sharedMesh = null;
		PantyAttacher.newRenderer.enabled = false;
		Schoolwear = 0;
		Hairstyle = 181;
		UpdateHair();
		Egg = true;
		IdleAnim = "f02_heroicIdle_00";
		WalkAnim = "f02_walkGraceful_00";
		RunAnim = "f02_nierRun_00";
		RunSpeed = 10f;
		DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	public void WearChinaDress()
	{
		EbolaHair.SetActive(value: false);
		Hairstyle = 1;
		UpdateHair();
		ChinaDress.SetActive(value: true);
		Nude();
		PantyAttacher.newRenderer.enabled = true;
	}

	public void Medibang()
	{
		MedibangAttacher.SetActive(value: true);
		Hairstyle = 208;
		UpdateHair();
		MyRenderer.enabled = false;
	}

	private void Vaporwave()
	{
		VaporwaveVisuals.ApplyNormalView();
		RenderSettings.skybox = VaporwaveSkybox;
		PalmTrees.SetActive(value: true);
		for (int i = 1; i < Trees.Length; i++)
		{
			Trees[i].SetActive(value: false);
		}
	}

	public void ChangeSchoolwear()
	{
		if (StudentManager.Eighties)
		{
			RestoreGentleEyes();
			GymTexture = EightiesGymTexture;
		}
		PantyAttacher.newRenderer.enabled = false;
		RightFootprintSpawner.Bloodiness = 0;
		LeftFootprintSpawner.Bloodiness = 0;
		if (ClubAttire && Bloodiness == 0f)
		{
			Schoolwear = PreviousSchoolwear;
		}
		EightiesBikiniAttacher.RemoveAccessory();
		LabcoatAttacher.RemoveAccessory();
		Paint = false;
		for (ID = 0; ID < CensorSteam.Length; ID++)
		{
			CensorSteam[ID].SetActive(value: false);
		}
		if (Casual)
		{
			TextureToUse = UniformTextures[StudentGlobals.FemaleUniform];
		}
		else
		{
			TextureToUse = CasualTextures[StudentGlobals.FemaleUniform];
		}
		if (!Egg && !StudentManager.Eighties && Hairstyle == 210)
		{
			Hairstyle = 1;
			UpdateHair();
		}
		if ((ClubAttire && Bloodiness > 0f) || Schoolwear == 0)
		{
			MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			MyRenderer.sharedMesh = Towel;
			MyRenderer.materials[0].mainTexture = TowelTexture;
			MyRenderer.materials[1].mainTexture = TowelTexture;
			MyRenderer.materials[2].mainTexture = FaceTexture;
			ClubAttire = false;
			Schoolwear = 0;
			if (!Egg && !StudentManager.Eighties && Hairstyle == 1)
			{
				Hairstyle = 210;
				UpdateHair();
			}
		}
		else if (Schoolwear == 1)
		{
			PantyAttacher.newRenderer.enabled = true;
			MyRenderer.sharedMesh = Uniforms[StudentGlobals.FemaleUniform];
			MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			if (GameGlobals.CensorPanties)
			{
				Debug.Log("Activating shadows on Yandere-chan.");
				MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
				MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
				PantyAttacher.newRenderer.enabled = false;
			}
			MyRenderer.materials[0].mainTexture = TextureToUse;
			MyRenderer.materials[1].mainTexture = TextureToUse;
			MyRenderer.materials[2].mainTexture = FaceTexture;
			StartCoroutine(ApplyCustomCostume());
		}
		else if (Schoolwear == 2)
		{
			if (Inventory.Bikini)
			{
				EightiesBikiniAttacher.gameObject.SetActive(value: true);
				if (EightiesBikiniAttacher.newRenderer != null)
				{
					EightiesBikiniAttacher.newRenderer.enabled = true;
				}
				Nude();
				Schoolwear = 2;
			}
			else
			{
				MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
				MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
				MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
				MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
				MyRenderer.sharedMesh = SchoolSwimsuit;
				MyRenderer.materials[0].mainTexture = SwimsuitTexture;
				MyRenderer.materials[1].mainTexture = SwimsuitTexture;
				MyRenderer.materials[2].mainTexture = FaceTexture;
			}
		}
		else if (Schoolwear == 3)
		{
			MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			MyRenderer.sharedMesh = GymUniform;
			MyRenderer.materials[0].mainTexture = GymTexture;
			MyRenderer.materials[1].mainTexture = GymTexture;
			MyRenderer.materials[2].mainTexture = FaceTexture;
		}
		CanMove = false;
		Outline.h.ReinitMaterials();
		ClubAccessory();
	}

	public void ChangeClubwear()
	{
		PantyAttacher.newRenderer.enabled = false;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
		Paint = false;
		if (!ClubAttire)
		{
			ClubAttire = true;
			if (Club == ClubType.Art)
			{
				MyRenderer.sharedMesh = ApronMesh;
				MyRenderer.materials[0].mainTexture = ApronTexture;
				MyRenderer.materials[1].mainTexture = ApronTexture;
				MyRenderer.materials[2].mainTexture = FaceTexture;
				Schoolwear = 4;
				Paint = true;
			}
			else if (Club == ClubType.MartialArts)
			{
				MyRenderer.sharedMesh = JudoGiMesh;
				MyRenderer.materials[0].mainTexture = FaceTexture;
				MyRenderer.materials[1].mainTexture = JudoGiTexture;
				MyRenderer.materials[2].mainTexture = JudoGiTexture;
				Schoolwear = 5;
			}
			else if (Club == ClubType.Science)
			{
				LabcoatAttacher.enabled = true;
				MyRenderer.sharedMesh = HeadAndHands;
				if (LabcoatAttacher.Initialized)
				{
					LabcoatAttacher.AttachAccessory();
				}
				MyRenderer.materials[0].mainTexture = FaceTexture;
				MyRenderer.materials[1].mainTexture = NudeTexture;
				MyRenderer.materials[2].mainTexture = NudeTexture;
				Schoolwear = 6;
			}
			MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
		}
		else
		{
			ChangeSchoolwear();
			ClubAttire = false;
			MyRenderer.materials[2].SetFloat("_BlendAmount", 1f - sanity / 100f);
		}
		if (ClubAttire && Hairstyle == 210)
		{
			Hairstyle = 1;
			UpdateHair();
		}
		MyLocker.UpdateButtons();
		ClubAccessory();
	}

	public void ClubAccessory()
	{
		for (ID = 0; ID < ClubAccessories.Length; ID++)
		{
			GameObject gameObject = ClubAccessories[ID];
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
		if (MyRenderer.sharedMesh != Towel && !WearingRaincoat && Club > ClubType.None && ClubAccessories[(int)Club] != null)
		{
			ClubAccessories[(int)Club].SetActive(value: true);
		}
	}

	public void StopCarrying()
	{
		CurrentRagdoll = null;
		if (Ragdoll != null)
		{
			TooCloseToWall = false;
			WallToRight = false;
			WallToLeft = false;
			Direction = 0;
			while (Direction < 3)
			{
				Direction++;
				CheckForWall();
			}
			if (TooCloseToWall)
			{
				Ragdoll.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z);
				if (WallToRight && WallToLeft)
				{
					Ragdoll.transform.Translate(base.transform.worldToLocalMatrix.MultiplyVector(base.transform.forward * -0.5f));
				}
				else if (WallToRight)
				{
					Ragdoll.transform.Translate(base.transform.worldToLocalMatrix.MultiplyVector(base.transform.right * -0.5f));
				}
				else if (WallToLeft)
				{
					Ragdoll.transform.Translate(base.transform.worldToLocalMatrix.MultiplyVector(base.transform.right * 0.5f));
				}
				Physics.SyncTransforms();
			}
			Ragdoll.GetComponent<RagdollScript>().Fall();
		}
		HeavyWeight = false;
		Carrying = false;
		IdleAnim = OriginalIdleAnim;
		WalkAnim = OriginalWalkAnim;
		RunAnim = OriginalRunAnim;
	}

	private void Crouch()
	{
		MyController.center = new Vector3(MyController.center.x, 0.55f, MyController.center.z);
		MyController.height = 0.9f;
	}

	private void Crawl()
	{
		MyController.center = new Vector3(MyController.center.x, 0.25f, MyController.center.z);
		MyController.height = 0.1f;
	}

	public void Uncrouch()
	{
		MyController.center = new Vector3(MyController.center.x, 0.875f, MyController.center.z);
		MyController.height = 1.55f;
	}

	private void StopArmedAnim()
	{
		for (ID = 0; ID < ArmedAnims.Length; ID++)
		{
			string text = ArmedAnims[ID];
			CharacterAnimation[text].weight = Mathf.Lerp(CharacterAnimation[text].weight, 0f, Time.deltaTime * 10f);
		}
	}

	public void UpdateAccessory()
	{
		if (AccessoryGroup != null)
		{
			AccessoryGroup.SetPartsActive(active: false);
		}
		if (AccessoryID > Accessories.Length - 1)
		{
			AccessoryID = 0;
		}
		if (AccessoryID < 0)
		{
			AccessoryID = Accessories.Length - 1;
		}
		if (AccessoryID > 0)
		{
			Accessories[AccessoryID].SetActive(value: true);
			AccessoryGroup = Accessories[AccessoryID].GetComponent<AccessoryGroupScript>();
			if (AccessoryGroup != null)
			{
				AccessoryGroup.SetPartsActive(active: true);
			}
		}
		for (ID = 1; ID < Accessories.Length; ID++)
		{
			Accessories[ID].layer = 13;
		}
	}

	private void DisableHairAndAccessories()
	{
		for (ID = 1; ID < Accessories.Length; ID++)
		{
			Accessories[ID].layer = 4;
		}
		for (ID = 1; ID < Hairstyles.Length; ID++)
		{
			Hairstyles[ID].layer = 4;
		}
	}

	public void BullyPhotoCheck()
	{
		Debug.Log("We are now going to perform a bully photo check.");
		for (int i = 1; i < 26; i++)
		{
			if (PauseScreen.PhotoGallery.PhotographTaken[i] && PauseScreen.PhotoGallery.BullyPhoto[i] > 0)
			{
				Debug.Log("Yandere-chan has a bully photo in her photo gallery!");
				BullyPhoto = true;
			}
		}
	}

	public void UpdatePersona(int NewPersona)
	{
		switch (NewPersona)
		{
		case 0:
			Persona = YanderePersonaType.Default;
			break;
		case 1:
			Persona = YanderePersonaType.Chill;
			break;
		case 2:
			Persona = YanderePersonaType.Confident;
			break;
		case 3:
			Persona = YanderePersonaType.Elegant;
			break;
		case 4:
			Persona = YanderePersonaType.Girly;
			break;
		case 5:
			Persona = YanderePersonaType.Graceful;
			break;
		case 6:
			Persona = YanderePersonaType.Haughty;
			break;
		case 7:
			Persona = YanderePersonaType.Lively;
			break;
		case 8:
			Persona = YanderePersonaType.Scholarly;
			break;
		case 9:
			Persona = YanderePersonaType.Shy;
			break;
		case 10:
			Persona = YanderePersonaType.Tough;
			break;
		case 11:
			Persona = YanderePersonaType.Aggressive;
			break;
		case 12:
			Persona = YanderePersonaType.Grunt;
			break;
		}
	}

	private void SithSoundCheck()
	{
		if (SithBeam[1].Damage == 10f || NierDamage == 10f)
		{
			if (SithSounds == 0 && CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= SithSpawnTime[SithCombo] - 0.1f)
			{
				SithAudio.pitch = Random.Range(0.9f, 1.1f);
				SithAudio.Play();
				SithSounds++;
			}
		}
		else if (SithSounds == 0)
		{
			if (CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= SithHardSpawnTime1[SithCombo] - 0.1f)
			{
				SithAudio.pitch = Random.Range(0.9f, 1.1f);
				SithAudio.Play();
				SithSounds++;
			}
		}
		else if (SithSounds == 1)
		{
			if (CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= SithHardSpawnTime2[SithCombo] - 0.1f)
			{
				SithAudio.pitch = Random.Range(0.9f, 1.1f);
				SithAudio.Play();
				SithSounds++;
			}
		}
		else if (SithSounds == 2 && SithCombo == 1 && CharacterAnimation["f02_" + AttackPrefix + "Attack" + SithPrefix + "_0" + SithCombo].time >= 5f / 6f)
		{
			SithAudio.pitch = Random.Range(0.9f, 1.1f);
			SithAudio.Play();
			SithSounds++;
		}
	}

	public void UpdateSelfieStatus()
	{
		if (!Selfie)
		{
			Smartphone.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Smartphone.targetTexture = Shutter.SmartphoneScreen;
			HandCamera.gameObject.SetActive(value: true);
			SelfieGuide.SetActive(value: false);
			MainCamera.enabled = true;
			if (!StudentManager.Eighties)
			{
				Blur.enabled = true;
			}
			else
			{
				Blur.enabled = false;
			}
			return;
		}
		if (Stance.Current == StanceType.Crawling)
		{
			Stance.Current = StanceType.Crouching;
		}
		Smartphone.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
		UpdateAccessory();
		UpdateHair();
		HandCamera.gameObject.SetActive(value: false);
		Smartphone.targetTexture = null;
		MainCamera.enabled = false;
		Smartphone.cullingMask &= ~(1 << LayerMask.NameToLayer("Miyuki"));
		AR = false;
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		Cursor.lockState = CursorLockMode.None;
	}

	private void AddImpact(Vector3 dir, float force)
	{
		dir.Normalize();
		if (dir.y < 0f)
		{
			dir.y = 0f - dir.y;
		}
		impact += dir.normalized * force / mass;
	}

	private void CheckForGround()
	{
		RaycastOrigin = Zoom.transform;
		Vector3 vector = RaycastOrigin.TransformDirection(Vector3.up * -1f);
		Debug.DrawRay(RaycastOrigin.position, vector, Color.green);
		if (Physics.Raycast(RaycastOrigin.position, vector, out hit, 1.1f, OnlyGroundLayer))
		{
			Debug.Log("Yandere-chan landed on the ground.");
			impact = Vector3.zero;
			Jumping = false;
			CanMove = true;
		}
	}

	private void UpdateODM()
	{
		if (Jumping && (CharacterAnimation["ODM_Jump"].time > 0.25f || CharacterAnimation["ODM_Slash"].time > 0f))
		{
			if (Input.GetButtonDown(InputNames.Xbox_X) && (CharacterAnimation["ODM_Slash"].time == 0f || CharacterAnimation["ODM_Slash"].time >= CharacterAnimation["ODM_Slash"].length))
			{
				AudioSource.PlayClipAtPoint(Swoosh, base.transform.position + Vector3.up);
				GameObject obj = Object.Instantiate(TitanSlash, base.transform.position, Quaternion.identity);
				obj.name = "0";
				obj.transform.parent = Hips;
				obj.transform.localPosition = Vector3.zero;
				CharacterAnimation["ODM_Slash"].speed = 20f;
				CharacterAnimation["ODM_Slash"].time = 0f;
				CharacterAnimation.CrossFade("ODM_Slash", 0.1f);
				base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, 1f, 1f);
			}
			if (CharacterAnimation["ODM_Slash"].time >= CharacterAnimation["ODM_Slash"].length)
			{
				CharacterAnimation["ODM_Jump"].time = CharacterAnimation["ODM_Jump"].length;
				CharacterAnimation.CrossFade("ODM_Jump");
			}
			CheckForGround();
		}
		if (CharacterAnimation["ODM_Jump"].time > 0.25f && MyController.velocity.y == 0f && base.transform.position.y == 0f)
		{
			Jumping = false;
			CanMove = true;
		}
		if ((double)impact.magnitude > 0.2)
		{
			MyController.Move(impact * Time.deltaTime);
		}
		MyController.Move(Physics.gravity * Time.deltaTime * 2f);
		impact = Vector3.Lerp(impact, Vector3.zero, Time.deltaTime * SlowDownSpeed);
		if (Input.GetButtonDown(InputNames.Xbox_A) && base.transform.position.y < 50f)
		{
			AudioSource.PlayClipAtPoint(AirBlast, base.transform.position);
			v = Input.GetAxis("Vertical");
			h = Input.GetAxis("Horizontal");
			Vector3 vector = MainCamera.transform.TransformDirection(Vector3.forward);
			vector.y = 0f;
			vector = vector.normalized;
			Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
			targetDirection = h * vector2 + v * vector;
			if (h + v != 0f)
			{
				targetRotation = Quaternion.LookRotation(targetDirection);
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, targetRotation, 360f);
			}
			AddImpact(new Vector3(targetDirection.x, 1f, targetDirection.z), 100f);
			CharacterAnimation["ODM_Jump"].speed = 5f;
			CharacterAnimation["ODM_Jump"].time = 0f;
			CharacterAnimation.CrossFade("ODM_Jump", 0.1f);
			ODMEffect.Play();
			CanMove = false;
			Jumping = true;
		}
	}

	private void BecomeRyoba()
	{
		if (VtuberID == 0)
		{
			MyRenderer.SetBlendShapeWeight(0, 50f);
			MyRenderer.SetBlendShapeWeight(5, 25f);
			MyRenderer.SetBlendShapeWeight(8, 0f);
			MyRenderer.SetBlendShapeWeight(12, 100f);
			Hairstyle = 203;
			UpdateHair();
		}
		OriginalIdleAnim = "f02_ryobaIdle_00";
		IdleAnim = "f02_ryobaIdle_00";
		OriginalWalkAnim = "f02_ryobaWalk_00";
		WalkAnim = "f02_ryobaWalk_00";
		OriginalRunAnim = "f02_ryobaRun_00";
		RunAnim = "f02_ryobaRun_00";
		BreastSize = 1.5f;
		RightBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
		LeftBreast.localScale = new Vector3(BreastSize, BreastSize, BreastSize);
		SneakShotButton.alpha = 0.5f;
		SneakShotLabel.alpha = 0f;
		Phone = PolaroidOfSenpai;
		Laugh1 = EightiesLaughs[1];
		Laugh2 = EightiesLaughs[2];
		Laugh3 = EightiesLaughs[3];
		Laugh4 = EightiesLaughs[4];
		UniformTextures[6] = EightiesUniform;
		CasualTextures[6] = EightiesCasual;
		ModernCamera.localScale = new Vector3(0f, 0f, 0f);
		EightiesCamera.SetActive(value: true);
		ClubAccessories[1].GetComponent<MeshFilter>().mesh = EightiesKerchiefMesh;
	}

	public void Maid()
	{
		WeaponManager.Weapons[53].gameObject.SetActive(value: true);
		MaidAttacher.SetActive(value: true);
		Hairstyle = 209;
		UpdateHair();
		EyewearID = 0;
		UpdateDebugFunctionality();
		for (ID = 1; ID < Accessories.Length; ID++)
		{
			Accessories[ID].SetActive(value: false);
		}
		MyRenderer.enabled = false;
	}

	public void LoseGentleEyes()
	{
		bool flag = false;
		if (EightiesBikiniAttacher.newRenderer != null && EightiesBikiniAttacher.newRenderer.enabled)
		{
			flag = true;
		}
		if (!Egg && !flag && VtuberID == 0)
		{
			MyRenderer.SetBlendShapeWeight(0, 0f);
			MyRenderer.SetBlendShapeWeight(5, 0f);
			MyRenderer.SetBlendShapeWeight(12, 0f);
		}
	}

	public void RestoreGentleEyes()
	{
		bool flag = false;
		if (EightiesBikiniAttacher.newRenderer != null && EightiesBikiniAttacher.newRenderer.enabled)
		{
			flag = true;
		}
		if (!Egg && !flag && VtuberID == 0)
		{
			MyRenderer.SetBlendShapeWeight(0, 50f);
			MyRenderer.SetBlendShapeWeight(5, 25f);
			MyRenderer.SetBlendShapeWeight(12, 100f);
		}
	}

	public void UpdateConcealedWeaponStatus()
	{
		ConcealedWeaponLabel.alpha = 0.5f;
		if (Container != null && Container.TrashCan != null)
		{
			if (Container.TrashCan.Item != null)
			{
				ConcealedWeaponLabel.text = "Equip Weapon From Bag";
				ConcealedWeaponLabel.alpha = 1f;
			}
			else if (Armed)
			{
				ConcealedWeaponLabel.text = "Conceal Weapon In Bag";
				ConcealedWeaponLabel.alpha = 1f;
			}
		}
	}

	public void UpdateConcealedItemStatus()
	{
		ConcealedItemLabel.alpha = 0.5f;
		if (Bookbag != null)
		{
			if (Bookbag.ConcealedPickup != null)
			{
				ConcealedItemLabel.text = "Equip Item From Bookbag";
				ConcealedItemLabel.alpha = 1f;
			}
			else if (PickUp != null)
			{
				ConcealedItemLabel.text = "Conceal Item In Bookbag";
				ConcealedItemLabel.alpha = 1f;
			}
		}
	}

	public void VtuberFace()
	{
		if (!Egg)
		{
			LoseGentleEyes();
			MyRenderer.SetBlendShapeWeight(0, 100f);
			MyRenderer.SetBlendShapeWeight(5, 0f);
			MyRenderer.SetBlendShapeWeight(8, 0f);
			MyRenderer.SetBlendShapeWeight(9, 100f);
			MyRenderer.SetBlendShapeWeight(12, 0f);
		}
	}

	public void VtuberCheck()
	{
		VtuberID = GameGlobals.VtuberID;
		if (VtuberID == 1)
		{
			FaceTexture = VtuberFaces[VtuberID];
			Hairstyle = 207;
			UpdateHair();
			VtuberFace();
		}
	}

	public void Cloak()
	{
		EightiesPonytailRenderer.material = CloakMaterial;
		PonytailRenderer.material = CloakMaterial;
		MyRenderer.materials = CloakMaterials;
		Outline.h.ReinitMaterials();
		if (!StudentManager.Eighties)
		{
			Hairstyle = 1;
		}
		else
		{
			Hairstyle = 203;
		}
		UpdateHair();
		PantyAttacher.newRenderer.enabled = !Invisible;
	}

	public void Decloak()
	{
		PauseScreen.NewSettings.QualityManager.UpdateYandereChan();
		SetUniform();
		MyRenderer.materials[0].color = Color.white;
		MyRenderer.materials[1].color = Color.white;
		MyRenderer.materials[2].color = Color.white;
		MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[0].SetFloat("_Outline", 0.002f);
		MyRenderer.materials[1].SetFloat("_Outline", 0.002f);
		MyRenderer.materials[2].SetFloat("_Outline", 0.002f);
		PonytailRenderer.material.color = new Color(0.25f, 0.25f, 0.25f, 1f);
		PonytailRenderer.material.SetFloat("_Outline", 0.002f);
		EightiesPonytailRenderer.material.color = new Color(0.25f, 0.25f, 0.25f, 1f);
		EightiesPonytailRenderer.material.SetFloat("_Outline", 0.002f);
		if (!StudentManager.Eighties)
		{
			Hairstyle = 1;
		}
		else
		{
			Hairstyle = 203;
		}
		UpdateHair();
		PantyAttacher.newRenderer.enabled = !Invisible;
	}

	public void CheckForWall()
	{
		Debug.Log("Checking for a wall.");
		Vector3 vector = Vector3.zero;
		corpseOrigin = Hips;
		float maxDistance = 1f;
		if (CustomThreshold > 0f)
		{
			maxDistance = CustomThreshold;
		}
		if (Direction == 1)
		{
			Debug.Log("Checkin' front.");
			vector = base.transform.forward;
			maxDistance = 0.66666f;
			if (Dipping)
			{
				maxDistance = 1f;
			}
		}
		else if (Direction == 2)
		{
			Debug.Log("Checkin' right.");
			vector = base.transform.right;
		}
		else if (Direction == 3)
		{
			Debug.Log("Checkin' left.");
			vector = base.transform.right * -1f;
		}
		else if (Direction == 4)
		{
			Debug.Log("Checkin' up.");
			vector = base.transform.up;
		}
		Debug.DrawRay(corpseOrigin.position, vector, Color.yellow);
		if (Physics.Raycast(corpseOrigin.position, vector, out corpseHit, maxDistance, OnlyDefault))
		{
			if (Direction == 1)
			{
				Debug.Log("Wall in front!");
				WallInFront = true;
			}
			else if (Direction == 2)
			{
				Debug.Log("Wall to the right!");
				WallToRight = true;
			}
			else if (Direction == 3)
			{
				Debug.Log("Wall to the left!");
				WallToLeft = true;
			}
			else if (Direction == 4)
			{
				Debug.Log("Wall up above!");
				WallAbove = true;
			}
			TooCloseToWall = true;
		}
		else
		{
			Debug.Log("Nope, didn't hit a wall...");
		}
	}

	public void StopDismembering()
	{
		CameraEffects.UpdateDOF(2f);
		Ragdoll.GetComponent<RagdollScript>().Dismember();
		RPGCamera.enabled = true;
		TargetStudent = null;
		Dismembering = false;
		CanMove = true;
		Ragdoll = null;
	}

	public void StopWrappingCorpse()
	{
		CameraEffects.UpdateDOF(2f);
		Ragdoll.GetComponent<RagdollScript>().ConcealInTrashBag();
		RPGCamera.enabled = true;
		TargetStudent = null;
		WrappingCorpse = false;
		CanMove = true;
		Ragdoll = null;
		PickUpScript pickUp = PickUp;
		if (pickUp != null)
		{
			pickUp.Drop();
			pickUp.BePickedUp();
		}
	}

	public void RemoveGloves()
	{
		Gloves.GetComponent<Rigidbody>().isKinematic = false;
		Gloves.transform.parent = null;
		if (WearingRaincoat)
		{
			RaincoatAttacher.newRenderer.enabled = false;
			CoatBloodiness = Bloodiness;
			Bloodiness = OriginalBloodiness;
			LeftFootprintSpawner.Bloodiness = 0;
			RightFootprintSpawner.Bloodiness = 0;
			WearingRaincoat = false;
			if (Schoolwear == 1)
			{
				PantyAttacher.newRenderer.enabled = true;
				TheDebugMenuScript.UpdateCensor();
			}
			Hairstyle = HairstyleBeforeRaincoat;
			UpdateHair();
		}
		else
		{
			GloveAttacher.newRenderer.enabled = false;
		}
		Gloves.gameObject.SetActive(value: true);
		if (Gloves.Blood.enabled)
		{
			OutlineScript component = Gloves.GetComponent<OutlineScript>();
			if (component != null)
			{
				component.color = new Color(1f, 0.5f, 0f, 1f);
			}
		}
		Gloves.PickUp.MyRigidbody.isKinematic = false;
		Gloves.PickUp.MyRigidbody.useGravity = true;
		StudentManager.GloveID = 0;
		Degloving = false;
		CanMove = true;
		Gloved = false;
		Gloves = null;
		SetUniform();
		GloveBlood = 0;
		ClubAccessory();
	}

	public void AssignFilters()
	{
		CameraFilterPack_Colors_Adjust_PreFilters[] components = MainCamera.GetComponents<CameraFilterPack_Colors_Adjust_PreFilters>();
		for (int i = 0; i < 3; i++)
		{
			if (components[i].filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlueLagoon)
			{
				YandereFilter = components[i];
			}
			else if (components[i].filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.PopRocket)
			{
				SenpaiFilter = components[i];
			}
		}
		HollowFilter = components[3];
	}

	public void StopDigging()
	{
		EquippedWeapon.gameObject.SetActive(value: true);
		FloatingShovel.SetActive(value: false);
		RPGCamera.enabled = true;
		Digging = false;
		CanMove = true;
	}

	public void StopBurying()
	{
		EquippedWeapon.gameObject.SetActive(value: true);
		FloatingShovel.SetActive(value: false);
		RPGCamera.enabled = true;
		Burying = false;
		CanMove = true;
	}
}
