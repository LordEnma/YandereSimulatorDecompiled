// Decompiled with JetBrains decompiler
// Type: YandereScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using HighlightingSystem;
using Pathfinding;
using System.Collections;
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
  public WoodChipperScript WoodChipper;
  public UILabel ConcealedWeaponLabel;
  public RagdollScript CurrentRagdoll;
  public StudentScript TargetStudent;
  public WeaponMenuScript WeaponMenu;
  public PromptScript NearestPrompt;
  public UIPanel YandereVisionPanel;
  public ContainerScript Container;
  public InventoryScript Inventory;
  public TallLockerScript MyLocker;
  public PromptBarScript PromptBar;
  public TranqCaseScript TranqCase;
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
  public GameObject PolaroidOfSenpai;
  public GameObject CinematicCamera;
  public GameObject FloatingShovel;
  public GameObject SneakShotPhone;
  public GameObject EasterEggMenu;
  public GameObject PantyDetector;
  public GameObject StolenObject;
  public GameObject CameraFlash;
  public GameObject SelfieGuide;
  public GameObject MemeGlasses;
  public GameObject GiggleDisc;
  public GameObject KONGlasses;
  public GameObject Microphone;
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
  public Renderer PigtailR;
  public Renderer PigtailL;
  public Renderer Drills;
  public float PotentiallyMurderousTimer;
  public float SuspiciousActionTimer;
  public float MurderousActionTimer;
  public float CinematicTimer;
  public float SneakShotTimer;
  public float ClothingTimer;
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
  public int Chasers;
  public int Costume;
  public int Alerts;
  public int Health = 5;
  public YandereInteractionType Interaction;
  public YanderePersonaType Persona;
  public ClubType Club;
  public bool EavesdropWarning;
  public bool ClothingWarning;
  public bool BloodyWarning;
  public bool CorpseWarning;
  public bool SanityWarning;
  public bool WeaponWarning;
  public bool DelinquentFighting;
  public bool DumpsterGrabbing;
  public bool FakingReaction;
  public bool BucketDropping;
  public bool CleaningWeapon;
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
  public bool Degloving;
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
  public bool NoDebug;
  public bool Noticed;
  public bool InClass;
  public bool Slender;
  public bool Sprayed;
  public bool Caught;
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
  public Texture BlondePony;
  public float VibrationIntensity;
  public float VibrationTimer;
  public bool VibrationCheck;
  public float v;
  public float h;
  private int DebugInt;
  public GameObject CreepyArms;
  public bool SetUpRaincoatOutline;
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
  public Texture[] VtuberFaces;
  public int VtuberID;
  public float DebugTimer;

  private void Start()
  {
    Application.runInBackground = false;
    this.VtuberCheck();
    this.SenpaiThreshold = (float) (1.0 - (double) PlayerGlobals.ShrineItems * 0.100000001490116);
    this.PhysicalGrade = ClassGlobals.PhysicalGrade;
    this.SpeedBonus = PlayerGlobals.SpeedBonus;
    this.Club = ClubGlobals.Club;
    this.SanitySmudges.color = new Color(1f, 1f, 1f, 0.0f);
    this.SpiderLegs.SetActive(GameGlobals.EmptyDemon);
    this.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0.0f);
    this.SetAnimationLayers();
    this.UpdateNumbness();
    this.RightEyeOrigin = this.RightEye.localPosition;
    this.LeftEyeOrigin = this.LeftEye.localPosition;
    this.CharacterAnimation["f02_yanderePose_00"].weight = 0.0f;
    this.CharacterAnimation["f02_cameraPose_00"].weight = 0.0f;
    this.CharacterAnimation["f02_selfie_00"].weight = 0.0f;
    this.CharacterAnimation["f02_selfie_01"].weight = 0.0f;
    this.CharacterAnimation["f02_shipGirlSnap_00"].speed = 2f;
    this.CharacterAnimation["f02_gazerSnap_00"].speed = 2f;
    this.CharacterAnimation["f02_performing_00"].speed = 0.9f;
    this.CharacterAnimation["f02_sithAttack_00"].speed = 1.5f;
    this.CharacterAnimation["f02_sithAttack_01"].speed = 1.5f;
    this.CharacterAnimation["f02_sithAttack_02"].speed = 1.5f;
    this.CharacterAnimation["f02_sithAttackHard_00"].speed = 1.5f;
    this.CharacterAnimation["f02_sithAttackHard_01"].speed = 1.5f;
    this.CharacterAnimation["f02_sithAttackHard_02"].speed = 1.5f;
    this.CharacterAnimation["f02_nierRun_00"].speed = 1.5f;
    CameraFilterPack_Colors_Adjust_PreFilters[] components = this.MainCamera.GetComponents<CameraFilterPack_Colors_Adjust_PreFilters>();
    this.YandereFilter = components[0];
    this.SenpaiFilter = components[1];
    this.HollowFilter = components[3];
    this.ResetYandereEffects();
    this.ResetSenpaiEffects();
    this.Sanity = 100f;
    this.Bloodiness = 0.0f;
    this.EasterEggMenu.transform.localPosition = new Vector3(this.EasterEggMenu.transform.localPosition.x, 0.0f, this.EasterEggMenu.transform.localPosition.z);
    this.ProgressBar.transform.parent.gameObject.SetActive(false);
    this.Smartphone.transform.parent.gameObject.SetActive(false);
    this.ObstacleDetector.gameObject.SetActive(false);
    this.SithBeam[1].gameObject.SetActive(false);
    this.SithBeam[2].gameObject.SetActive(false);
    this.PunishedAccessories.SetActive(false);
    this.SukebanAccessories.SetActive(false);
    this.FalconShoulderpad.SetActive(false);
    this.CensorSteam[0].SetActive(false);
    this.CensorSteam[1].SetActive(false);
    this.CensorSteam[2].SetActive(false);
    this.CensorSteam[3].SetActive(false);
    this.FloatingShovel.SetActive(false);
    this.BlackEyePatch.SetActive(false);
    this.EasterEggMenu.SetActive(false);
    this.FalconKneepad1.SetActive(false);
    this.FalconKneepad2.SetActive(false);
    this.PunishedScarf.SetActive(false);
    this.FalconBuckle.SetActive(false);
    this.FalconHelmet.SetActive(false);
    this.TornadoDress.SetActive(false);
    this.Stand.Stand.SetActive(false);
    this.TornadoHair.SetActive(false);
    this.MemeGlasses.SetActive(false);
    this.CirnoWings.SetActive(false);
    this.KONGlasses.SetActive(false);
    this.EbolaWings.SetActive(false);
    this.Microphone.SetActive(false);
    this.Poisons[1].SetActive(false);
    this.Poisons[2].SetActive(false);
    this.Poisons[3].SetActive(false);
    this.BladeHair.SetActive(false);
    this.CirnoHair.SetActive(false);
    this.EbolaHair.SetActive(false);
    this.EyepatchL.SetActive(false);
    this.EyepatchR.SetActive(false);
    this.Handcuffs.SetActive(false);
    this.ZipTie[0].SetActive(false);
    this.ZipTie[1].SetActive(false);
    this.Shoes[0].SetActive(false);
    this.Shoes[1].SetActive(false);
    this.Phone.SetActive(false);
    this.Cape.SetActive(false);
    this.HeavySwordParent.gameObject.SetActive(false);
    this.LightSwordParent.gameObject.SetActive(false);
    this.Pod.SetActive(false);
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    foreach (GameObject gameObject in this.Armor)
      gameObject.SetActive(false);
    for (this.ID = 1; this.ID < this.Accessories.Length; ++this.ID)
      this.Accessories[this.ID].SetActive(false);
    foreach (GameObject gameObject in this.PunishedArm)
      gameObject.SetActive(false);
    foreach (GameObject galoAccessory in this.GaloAccessories)
      galoAccessory.SetActive(false);
    foreach (GameObject vector in this.Vectors)
      vector.SetActive(false);
    for (this.ID = 1; this.ID < this.CyborgParts.Length; ++this.ID)
      this.CyborgParts[this.ID].SetActive(false);
    for (this.ID = 0; this.ID < this.KLKParts.Length; ++this.ID)
      this.KLKParts[this.ID].SetActive(false);
    for (this.ID = 0; this.ID < this.BanchoAccessories.Length; ++this.ID)
      this.BanchoAccessories[this.ID].SetActive(false);
    if (PlayerGlobals.PantiesEquipped == 5)
      ++this.RunSpeed;
    if (PlayerGlobals.Headset)
      this.Inventory.Headset = true;
    this.UpdateHair();
    this.ClubAccessory();
    this.NoDebug = true;
    if (GameGlobals.Debug)
      this.NoDebug = false;
    if (GameGlobals.BlondeHair)
    {
      this.PonytailRenderer.material.mainTexture = this.BlondePony;
      this.NoPonyRenderer.material.mainTexture = this.BlondePony;
    }
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
    if (GameGlobals.Eighties)
      this.BecomeRyoba();
    this.SetUniform();
    this.HandCamera.gameObject.SetActive(false);
    this.CharacterAnimation.Sample();
  }

  public float Sanity
  {
    get => this.sanity;
    set
    {
      this.sanity = Mathf.Clamp(value, 0.0f, 100f);
      if (this.SanityPills)
        this.sanity = 100f;
      if ((double) this.sanity > 66.6666564941406)
      {
        this.HeartRate.SetHeartRateColour(this.HeartRate.NormalColour);
        this.SanityWarning = false;
      }
      else if ((double) this.sanity > 33.3333282470703)
      {
        this.HeartRate.SetHeartRateColour(this.HeartRate.MediumColour);
        this.SanityWarning = false;
        if ((double) this.PreviousSanity < 33.3333282470703)
          this.StudentManager.UpdateStudents();
      }
      else
      {
        this.HeartRate.SetHeartRateColour(this.HeartRate.BadColour);
        if (!this.SanityWarning)
        {
          this.NotificationManager.DisplayNotification(NotificationType.Insane);
          this.StudentManager.TutorialWindow.ShowSanityMessage = true;
          this.SanityWarning = true;
        }
      }
      this.HeartRate.BeatsPerMinute = (int) (240.0 - (double) this.sanity * 1.79999995231628);
      if (!this.Laughing)
        this.Teeth.SetActive(this.SanityWarning);
      if ((Object) this.MyRenderer.sharedMesh != (Object) this.NudeMesh)
      {
        if (!this.Slender)
          this.MyRenderer.materials[2].SetFloat("_BlendAmount", (float) (1.0 - (double) this.sanity / 100.0));
        else
          this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
      }
      else
        this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
      this.PreviousSanity = this.sanity;
      this.Hairstyles[2].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, this.Sanity);
    }
  }

  public float Bloodiness
  {
    get => this.bloodiness;
    set
    {
      this.bloodiness = Mathf.Clamp(value, 0.0f, 100f);
      if ((double) this.Bloodiness > 0.0)
        this.StudentManager.TutorialWindow.ShowBloodMessage = true;
      if (!this.BloodyWarning && (double) this.Bloodiness > 0.0)
      {
        this.NotificationManager.DisplayNotification(NotificationType.Bloody);
        this.BloodyWarning = true;
        if (this.Schoolwear > 0 && !this.WearingRaincoat)
        {
          Debug.Log((object) "From YandereScript, incrementing Police.BloodyClothing.");
          ++this.Police.BloodyClothing;
          if (!this.ClubAttire)
          {
            if (this.CurrentUniformOrigin == 1)
            {
              --this.StudentManager.OriginalUniforms;
              Debug.Log((object) "One of the original uniforms has become bloody.");
            }
            else
            {
              --this.StudentManager.NewUniforms;
              Debug.Log((object) "One of the new uniforms has become bloody.");
            }
            Debug.Log((object) ("As a result, # of OriginalUniforms is: " + this.StudentManager.OriginalUniforms.ToString() + " and # of NewUniforms is: " + this.StudentManager.NewUniforms.ToString()));
          }
        }
      }
      this.MyProjector.enabled = true;
      this.RedPaint = false;
      if (!GameGlobals.CensorBlood)
      {
        this.MyProjector.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.5f));
        if ((double) this.Bloodiness == 100.0)
          this.MyProjector.material.mainTexture = this.BloodTextures[5];
        else if ((double) this.Bloodiness >= 80.0)
          this.MyProjector.material.mainTexture = this.BloodTextures[4];
        else if ((double) this.Bloodiness >= 60.0)
          this.MyProjector.material.mainTexture = this.BloodTextures[3];
        else if ((double) this.Bloodiness >= 40.0)
          this.MyProjector.material.mainTexture = this.BloodTextures[2];
        else if ((double) this.Bloodiness >= 20.0)
        {
          this.MyProjector.material.mainTexture = this.BloodTextures[1];
        }
        else
        {
          this.MyProjector.enabled = false;
          this.BloodyWarning = false;
        }
      }
      else
      {
        this.MyProjector.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f));
        if ((double) this.Bloodiness == 100.0)
          this.MyProjector.material.mainTexture = this.FlowerTextures[5];
        else if ((double) this.Bloodiness >= 80.0)
          this.MyProjector.material.mainTexture = this.FlowerTextures[4];
        else if ((double) this.Bloodiness >= 60.0)
          this.MyProjector.material.mainTexture = this.FlowerTextures[3];
        else if ((double) this.Bloodiness >= 40.0)
          this.MyProjector.material.mainTexture = this.FlowerTextures[2];
        else if ((double) this.Bloodiness >= 20.0)
        {
          this.MyProjector.material.mainTexture = this.FlowerTextures[1];
        }
        else
        {
          this.MyProjector.enabled = false;
          this.BloodyWarning = false;
        }
      }
      this.StudentManager.UpdateBooths();
      this.MyLocker.UpdateButtons();
      this.Outline.h.ReinitMaterials();
    }
  }

  public WeaponScript EquippedWeapon
  {
    get => this.Weapon[this.Equipped];
    set => this.Weapon[this.Equipped] = value;
  }

  public bool Armed => (Object) this.EquippedWeapon != (Object) null;

  public SanityType SanityType
  {
    get
    {
      if ((double) this.Sanity / 100.0 > 0.666666686534882)
        return SanityType.High;
      return (double) this.Sanity / 100.0 > 0.333333343267441 ? SanityType.Medium : SanityType.Low;
    }
  }

  public string GetSanityString(SanityType sanityType)
  {
    if (sanityType == SanityType.High)
      return "High";
    return sanityType == SanityType.Medium ? "Med" : "Low";
  }

  public Vector3 HeadPosition => new Vector3(this.transform.position.x, this.transform.position.y + this.Zoom.Height, this.transform.position.z);

  public void SetAnimationLayers()
  {
    this.CharacterAnimation["f02_yanderePose_00"].layer = 1;
    this.CharacterAnimation.Play("f02_yanderePose_00");
    this.CharacterAnimation["f02_yanderePose_00"].weight = 0.0f;
    this.CharacterAnimation["f02_shy_00"].layer = 2;
    this.CharacterAnimation.Play("f02_shy_00");
    this.CharacterAnimation["f02_shy_00"].weight = 0.0f;
    this.CharacterAnimation["f02_singleSaw_00"].layer = 3;
    this.CharacterAnimation.Play("f02_singleSaw_00");
    this.CharacterAnimation["f02_singleSaw_00"].weight = 0.0f;
    this.CharacterAnimation["f02_fist_00"].layer = 4;
    this.CharacterAnimation.Play("f02_fist_00");
    this.CharacterAnimation["f02_fist_00"].weight = 0.0f;
    this.CharacterAnimation["f02_mopping_00"].layer = 5;
    this.CharacterAnimation["f02_mopping_00"].speed = 2f;
    this.CharacterAnimation.Play("f02_mopping_00");
    this.CharacterAnimation["f02_mopping_00"].weight = 0.0f;
    this.CharacterAnimation["f02_carry_00"].layer = 6;
    this.CharacterAnimation.Play("f02_carry_00");
    this.CharacterAnimation["f02_carry_00"].weight = 0.0f;
    this.CharacterAnimation["f02_mopCarry_00"].layer = 7;
    this.CharacterAnimation.Play("f02_mopCarry_00");
    this.CharacterAnimation["f02_mopCarry_00"].weight = 0.0f;
    this.CharacterAnimation["f02_bucketCarry_00"].layer = 8;
    this.CharacterAnimation.Play("f02_bucketCarry_00");
    this.CharacterAnimation["f02_bucketCarry_00"].weight = 0.0f;
    this.CharacterAnimation["f02_cameraPose_00"].layer = 9;
    this.CharacterAnimation.Play("f02_cameraPose_00");
    this.CharacterAnimation["f02_cameraPose_00"].weight = 0.0f;
    this.CharacterAnimation["f02_grip_00"].layer = 10;
    this.CharacterAnimation.Play("f02_grip_00");
    this.CharacterAnimation["f02_grip_00"].weight = 0.0f;
    this.CharacterAnimation["f02_holdHead_00"].layer = 11;
    this.CharacterAnimation.Play("f02_holdHead_00");
    this.CharacterAnimation["f02_holdHead_00"].weight = 0.0f;
    this.CharacterAnimation["f02_holdTorso_00"].layer = 12;
    this.CharacterAnimation.Play("f02_holdTorso_00");
    this.CharacterAnimation["f02_holdTorso_00"].weight = 0.0f;
    this.CharacterAnimation["f02_carryCan_00"].layer = 13;
    this.CharacterAnimation.Play("f02_carryCan_00");
    this.CharacterAnimation["f02_carryCan_00"].weight = 0.0f;
    this.CharacterAnimation["f02_leftGrip_00"].layer = 14;
    this.CharacterAnimation.Play("f02_leftGrip_00");
    this.CharacterAnimation["f02_leftGrip_00"].weight = 0.0f;
    this.CharacterAnimation["f02_carryShoulder_00"].layer = 15;
    this.CharacterAnimation.Play("f02_carryShoulder_00");
    this.CharacterAnimation["f02_carryShoulder_00"].weight = 0.0f;
    this.CharacterAnimation["f02_carryFlashlight_00"].layer = 16;
    this.CharacterAnimation.Play("f02_carryFlashlight_00");
    this.CharacterAnimation["f02_carryFlashlight_00"].weight = 0.0f;
    this.CharacterAnimation["f02_carryBox_00"].layer = 17;
    this.CharacterAnimation.Play("f02_carryBox_00");
    this.CharacterAnimation["f02_carryBox_00"].weight = 0.0f;
    this.CharacterAnimation["f02_holdBook_00"].layer = 18;
    this.CharacterAnimation.Play("f02_holdBook_00");
    this.CharacterAnimation["f02_holdBook_00"].weight = 0.0f;
    this.CharacterAnimation["f02_holdBook_00"].speed = 0.5f;
    this.CharacterAnimation[this.CreepyIdles[1]].layer = 19;
    this.CharacterAnimation.Play(this.CreepyIdles[1]);
    this.CharacterAnimation[this.CreepyIdles[1]].weight = 0.0f;
    this.CharacterAnimation[this.CreepyIdles[2]].layer = 20;
    this.CharacterAnimation.Play(this.CreepyIdles[2]);
    this.CharacterAnimation[this.CreepyIdles[2]].weight = 0.0f;
    this.CharacterAnimation[this.CreepyIdles[3]].layer = 21;
    this.CharacterAnimation.Play(this.CreepyIdles[3]);
    this.CharacterAnimation[this.CreepyIdles[3]].weight = 0.0f;
    this.CharacterAnimation[this.CreepyIdles[4]].layer = 22;
    this.CharacterAnimation.Play(this.CreepyIdles[4]);
    this.CharacterAnimation[this.CreepyIdles[4]].weight = 0.0f;
    this.CharacterAnimation[this.CreepyIdles[5]].layer = 23;
    this.CharacterAnimation.Play(this.CreepyIdles[5]);
    this.CharacterAnimation[this.CreepyIdles[5]].weight = 0.0f;
    this.CharacterAnimation[this.CreepyWalks[1]].layer = 24;
    this.CharacterAnimation.Play(this.CreepyWalks[1]);
    this.CharacterAnimation[this.CreepyWalks[1]].weight = 0.0f;
    this.CharacterAnimation[this.CreepyWalks[2]].layer = 25;
    this.CharacterAnimation.Play(this.CreepyWalks[2]);
    this.CharacterAnimation[this.CreepyWalks[2]].weight = 0.0f;
    this.CharacterAnimation[this.CreepyWalks[3]].layer = 26;
    this.CharacterAnimation.Play(this.CreepyWalks[3]);
    this.CharacterAnimation[this.CreepyWalks[3]].weight = 0.0f;
    this.CharacterAnimation[this.CreepyWalks[4]].layer = 27;
    this.CharacterAnimation.Play(this.CreepyWalks[4]);
    this.CharacterAnimation[this.CreepyWalks[4]].weight = 0.0f;
    this.CharacterAnimation[this.CreepyWalks[5]].layer = 28;
    this.CharacterAnimation.Play(this.CreepyWalks[5]);
    this.CharacterAnimation[this.CreepyWalks[5]].weight = 0.0f;
    this.CharacterAnimation["f02_carryDramatic_00"].layer = 29;
    this.CharacterAnimation.Play("f02_carryDramatic_00");
    this.CharacterAnimation["f02_carryDramatic_00"].weight = 0.0f;
    this.CharacterAnimation["f02_selfie_00"].layer = 30;
    this.CharacterAnimation.Play("f02_selfie_00");
    this.CharacterAnimation["f02_selfie_00"].weight = 0.0f;
    this.CharacterAnimation["f02_selfie_01"].layer = 31;
    this.CharacterAnimation.Play("f02_selfie_01");
    this.CharacterAnimation["f02_selfie_01"].weight = 0.0f;
    this.CharacterAnimation["f02_dramaticWriting_00"].layer = 32;
    this.CharacterAnimation.Play("f02_dramaticWriting_00");
    this.CharacterAnimation["f02_dramaticWriting_00"].weight = 0.0f;
    this.CharacterAnimation["f02_reachForWeapon_00"].layer = 33;
    this.CharacterAnimation.Play("f02_reachForWeapon_00");
    this.CharacterAnimation["f02_reachForWeapon_00"].weight = 0.0f;
    this.CharacterAnimation["f02_reachForWeapon_00"].speed = 2f;
    this.CharacterAnimation["f02_gutsEye_00"].layer = 34;
    this.CharacterAnimation.Play("f02_gutsEye_00");
    this.CharacterAnimation["f02_gutsEye_00"].weight = 0.0f;
    this.CharacterAnimation["f02_fingerSnap_00"].layer = 35;
    this.CharacterAnimation.Play("f02_fingerSnap_00");
    this.CharacterAnimation["f02_fingerSnap_00"].weight = 0.0f;
    this.CharacterAnimation["f02_sadEyebrows_00"].layer = 36;
    this.CharacterAnimation.Play("f02_sadEyebrows_00");
    this.CharacterAnimation["f02_sadEyebrows_00"].weight = 0.0f;
    this.CharacterAnimation["f02_phonePose_00"].layer = 37;
    this.CharacterAnimation.Play("f02_phonePose_00");
    this.CharacterAnimation["f02_phonePose_00"].weight = 0.0f;
    this.CharacterAnimation["f02_dipping_00"].speed = 2f;
    this.CharacterAnimation["f02_stripping_00"].speed = 1.5f;
    this.CharacterAnimation["f02_falconIdle_00"].speed = 2f;
    this.CharacterAnimation["f02_carryIdleA_00"].speed = 1.75f;
    this.CharacterAnimation["CyborgNinja_Run_Armed"].speed = 2f;
    this.CharacterAnimation["CyborgNinja_Run_Unarmed"].speed = 2f;
  }

  private void Update()
  {
    if (!this.StudentManager.Eighties && Input.GetKeyDown(KeyCode.LeftAlt))
      this.CinematicCamera.SetActive(false);
    if (!this.PauseScreen.Show)
    {
      this.UpdateMovement();
      this.UpdatePoisoning();
      if (!this.Laughing)
        this.MyAudio.volume -= Time.deltaTime * 2f;
      else if ((Object) this.PickUp != (Object) null && !this.PickUp.Clothing)
        this.CharacterAnimation[this.CarryAnims[1]].weight = Mathf.Lerp(this.CharacterAnimation[this.CarryAnims[1]].weight, 1f, Time.deltaTime * 10f);
      if (!this.Mopping)
      {
        this.CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopping_00"].weight, 0.0f, Time.deltaTime * 10f);
      }
      else
      {
        this.CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopping_00"].weight, 1f, Time.deltaTime * 10f);
        if (Input.GetButtonUp("A") || Input.GetKeyDown(KeyCode.Escape))
          this.Mopping = false;
      }
      if ((double) this.LaughIntensity == 0.0)
      {
        for (this.ID = 0; this.ID < this.CarryAnims.Length; ++this.ID)
        {
          string carryAnim = this.CarryAnims[this.ID];
          this.CharacterAnimation[carryAnim].weight = !((Object) this.PickUp != (Object) null) || this.CarryAnimID != this.ID || this.Mopping || this.Dipping || this.Pouring || this.BucketDropping || this.Digging || this.Burying || this.WritingName ? Mathf.Lerp(this.CharacterAnimation[carryAnim].weight, 0.0f, Time.deltaTime * 10f) : Mathf.Lerp(this.CharacterAnimation[carryAnim].weight, 1f, Time.deltaTime * 10f);
        }
      }
      else if (this.Armed)
        this.CharacterAnimation["f02_mopCarry_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopCarry_00"].weight, 1f, Time.deltaTime * 10f);
      if (this.Noticed && !this.Attacking && !this.Struggling && !this.Collapse)
      {
        if ((double) this.ShoulderCamera.NoticedTimer < 1.0)
          this.CharacterAnimation.CrossFade("f02_scaredIdle_00");
        this.targetRotation = Quaternion.LookRotation(this.Senpai.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.transform.localEulerAngles = new Vector3(0.0f, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        if ((double) Vector3.Distance(this.transform.position, this.Senpai.position) < 1.25)
        {
          int num = (int) this.MyController.Move(this.transform.forward * (Time.deltaTime * -2f));
        }
      }
      this.UpdateEffects();
      this.UpdateTalking();
      this.UpdateAttacking();
      this.UpdateSlouch();
      if (!this.Noticed)
      {
        this.RightYandereEye.material.color = new Color(this.RightYandereEye.material.color.r, this.RightYandereEye.material.color.g, this.RightYandereEye.material.color.b, (float) (1.0 - (double) this.Sanity / 100.0));
        this.LeftYandereEye.material.color = new Color(this.LeftYandereEye.material.color.r, this.LeftYandereEye.material.color.g, this.LeftYandereEye.material.color.b, (float) (1.0 - (double) this.Sanity / 100.0));
        this.EyeShrink = Mathf.Lerp(this.EyeShrink, (float) (0.5 * (1.0 - (double) this.Sanity / 100.0)), Time.deltaTime * 10f);
      }
      this.UpdateTwitch();
      this.UpdateWarnings();
      if (!this.NoDebug)
        this.UpdateDebugFunctionality();
      if (!this.EasterEggMenu.activeInHierarchy && !this.DebugMenu.activeInHierarchy && !this.Aiming && this.CanMove && (double) Time.timeScale > 0.0 && !this.StudentManager.TutorialActive && Input.GetKeyDown(KeyCode.Escape))
        this.PauseScreen.JumpToQuit();
      if ((double) this.transform.position.y < 0.0)
        this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
      if ((double) this.transform.position.z < -99.5)
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -99.5f);
      this.transform.eulerAngles = new Vector3(0.0f, this.transform.eulerAngles.y, 0.0f);
    }
    else
      this.MyAudio.volume -= 0.3333333f;
  }

  private void GoToPKDir(PKDirType pkDir, string sansAnim, Vector3 ragdollLocalPos)
  {
    this.CharacterAnimation.CrossFade(sansAnim);
    this.RagdollPK.transform.localPosition = ragdollLocalPos;
    if (this.PKDir != pkDir)
      AudioSource.PlayClipAtPoint(this.Slam, this.transform.position + Vector3.up);
    this.PKDir = pkDir;
  }

  private void UpdateMovement()
  {
    if (this.CanMove)
    {
      if (!this.ToggleRun)
      {
        this.Running = false;
        if (Input.GetButton("LB"))
          this.Running = true;
      }
      else if (Input.GetButtonDown("LB"))
        this.Running = !this.Running;
      int num1 = (int) this.MyController.Move(Physics.gravity * Time.deltaTime);
      this.v = Input.GetAxis("Vertical");
      this.h = Input.GetAxis("Horizontal");
      this.FlapSpeed = Mathf.Abs(this.v) + Mathf.Abs(this.h);
      if (this.Selfie)
      {
        this.v = -1f * this.v;
        this.h = -1f * this.h;
        if (Input.GetKeyDown("z"))
        {
          ++this.SelfieID;
          if (this.SelfieID > 1)
            this.SelfieID = 0;
        }
      }
      if (this.Frozen)
      {
        this.v = 0.0f;
        this.h = 0.0f;
      }
      if (!this.Aiming)
      {
        Vector3 vector3 = this.MainCamera.transform.TransformDirection(Vector3.forward) with
        {
          y = 0.0f
        };
        vector3 = vector3.normalized;
        this.targetDirection = this.h * new Vector3(vector3.z, 0.0f, -vector3.x) + this.v * vector3;
        if (this.targetDirection != Vector3.zero)
        {
          this.targetRotation = Quaternion.LookRotation(this.targetDirection);
          this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        }
        else
          this.targetRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        if ((double) this.v != 0.0 || (double) this.h != 0.0)
        {
          if (this.Running && (double) Vector3.Distance(this.transform.position, this.Senpai.position) > 1.0)
          {
            if (this.Stance.Current == StanceType.Crouching)
            {
              this.CharacterAnimation.CrossFade(this.CrouchRunAnim);
              int num2 = (int) this.MyController.Move(this.transform.forward * (this.CrouchRunSpeed + (float) (this.PhysicalGrade + this.SpeedBonus) * 0.25f) * Time.deltaTime);
            }
            else if (!this.Dragging && !this.Mopping)
            {
              this.CharacterAnimation.CrossFade(this.RunAnim);
              int num3 = (int) this.MyController.Move(this.transform.forward * (this.RunSpeed + (float) (this.PhysicalGrade + this.SpeedBonus) * 0.25f) * Time.deltaTime);
            }
            else if (this.Mopping)
            {
              this.CharacterAnimation.CrossFade(this.WalkAnim);
              int num4 = (int) this.MyController.Move(this.transform.forward * (this.WalkSpeed * Time.deltaTime));
            }
            int current = (int) this.Stance.Current;
            if (this.Stance.Current == StanceType.Crawling)
            {
              this.Stance.Current = StanceType.Crouching;
              this.Crouch();
            }
          }
          else if (!this.Dragging)
          {
            if (this.Stance.Current == StanceType.Crawling)
            {
              this.CharacterAnimation.CrossFade(this.CrawlWalkAnim);
              int num5 = (int) this.MyController.Move(this.transform.forward * (this.CrawlSpeed * Time.deltaTime));
            }
            else if (this.Stance.Current == StanceType.Crouching)
            {
              this.CharacterAnimation[this.CrouchWalkAnim].speed = 1f;
              this.CharacterAnimation.CrossFade(this.CrouchWalkAnim);
              int num6 = (int) this.MyController.Move(this.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime));
            }
            else
            {
              this.CharacterAnimation.CrossFade(this.WalkAnim);
              if (this.NearSenpai)
              {
                for (int index = 1; index < 6; ++index)
                {
                  if (index != this.Creepiness)
                  {
                    this.CharacterAnimation[this.CreepyIdles[index]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[index]].weight, 0.0f, Time.deltaTime);
                    this.CharacterAnimation[this.CreepyWalks[index]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[index]].weight, 0.0f, Time.deltaTime);
                  }
                }
                this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight, 0.0f, Time.deltaTime);
                this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight, 1f, Time.deltaTime);
              }
              int num7 = (int) this.MyController.Move(this.transform.forward * (this.WalkSpeed * Time.deltaTime));
            }
          }
          else
          {
            this.CharacterAnimation.CrossFade("f02_dragWalk_01");
            int num8 = (int) this.MyController.Move(this.transform.forward * (this.WalkSpeed * Time.deltaTime));
          }
        }
        else if (!this.Dragging)
        {
          if (this.Stance.Current == StanceType.Crawling)
            this.CharacterAnimation.CrossFade(this.CrawlIdleAnim);
          else if (this.Stance.Current == StanceType.Crouching)
          {
            this.CharacterAnimation.CrossFade(this.CrouchIdleAnim);
          }
          else
          {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            if (this.NearSenpai)
            {
              for (int index = 1; index < 6; ++index)
              {
                if (index != this.Creepiness)
                {
                  this.CharacterAnimation[this.CreepyIdles[index]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[index]].weight, 0.0f, Time.deltaTime);
                  this.CharacterAnimation[this.CreepyWalks[index]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[index]].weight, 0.0f, Time.deltaTime);
                }
              }
              this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight, 1f, Time.deltaTime);
              this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight, 0.0f, Time.deltaTime);
            }
          }
        }
        else
          this.CharacterAnimation.CrossFade("f02_dragIdle_02");
      }
      else
      {
        if ((double) this.v != 0.0 || (double) this.h != 0.0)
        {
          if (this.Stance.Current == StanceType.Crawling)
          {
            this.CharacterAnimation.CrossFade(this.CrawlWalkAnim);
            int num9 = (int) this.MyController.Move(this.transform.forward * (this.CrawlSpeed * Time.deltaTime * this.v));
            int num10 = (int) this.MyController.Move(this.transform.right * (this.CrawlSpeed * Time.deltaTime * this.h));
          }
          else if (this.Stance.Current == StanceType.Crouching)
          {
            this.CharacterAnimation.CrossFade(this.CrouchWalkAnim);
            int num11 = (int) this.MyController.Move(this.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime * this.v));
            int num12 = (int) this.MyController.Move(this.transform.right * (this.CrouchWalkSpeed * Time.deltaTime * this.h));
          }
          else
          {
            this.CharacterAnimation.CrossFade(this.WalkAnim);
            int num13 = (int) this.MyController.Move(this.transform.forward * (this.WalkSpeed * Time.deltaTime * this.v));
            int num14 = (int) this.MyController.Move(this.transform.right * (this.WalkSpeed * Time.deltaTime * this.h));
          }
        }
        else if (this.Stance.Current == StanceType.Crawling)
          this.CharacterAnimation.CrossFade(this.CrawlIdleAnim);
        else if (this.Stance.Current == StanceType.Crouching)
          this.CharacterAnimation.CrossFade(this.CrouchIdleAnim);
        else
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if (!this.RPGCamera.invertAxisY)
          this.Bend += (float) ((double) Input.GetAxis("Mouse Y") * (double) this.RPGCamera.sensitivity * 72.0) * Time.deltaTime;
        else
          this.Bend -= (float) ((double) Input.GetAxis("Mouse Y") * (double) this.RPGCamera.sensitivity * 72.0) * Time.deltaTime;
        if (this.Stance.Current == StanceType.Crawling)
        {
          if ((double) this.Bend < 0.0)
            this.Bend = 0.0f;
        }
        else if (this.Stance.Current == StanceType.Crouching)
        {
          if ((double) this.Bend < -45.0)
            this.Bend = -45f;
        }
        else if ((double) this.Bend < -85.0)
          this.Bend = -85f;
        if ((double) this.Bend > 85.0)
          this.Bend = 85f;
        if (!this.RPGCamera.invertAxisX)
          this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y + (float) ((double) Input.GetAxis("Mouse X") * (double) this.RPGCamera.sensitivity * 72.0) * Time.deltaTime, this.transform.localEulerAngles.z);
        else
          this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y - (float) ((double) Input.GetAxis("Mouse X") * (double) this.RPGCamera.sensitivity * 72.0) * Time.deltaTime, this.transform.localEulerAngles.z);
      }
      if (!this.NearSenpai)
      {
        if (!Input.GetButton("A") && !Input.GetButton("B") && !Input.GetButton("X") && !Input.GetButton("Y") && !this.StudentManager.Clock.UpdateBloom && !this.Frozen && ((double) Input.GetAxis("LT") > 0.5 || Input.GetMouseButton(1)))
        {
          if (this.Inventory.RivalPhone)
          {
            if (Input.GetButtonDown("LB"))
            {
              this.CharacterAnimation["f02_cameraPose_00"].weight = 0.0f;
              this.CharacterAnimation["f02_selfie_00"].weight = 0.0f;
              this.CharacterAnimation["f02_selfie_01"].weight = 0.0f;
              if (!this.RivalPhone)
              {
                this.SmartphoneRenderer.material.mainTexture = this.RivalPhoneTexture;
                this.PhonePromptBar.Label.text = "SWITCH TO YOUR PHONE";
                this.RivalPhone = true;
              }
              else
              {
                this.SmartphoneRenderer.material.mainTexture = this.YanderePhoneTexture;
                this.PhonePromptBar.Label.text = "SWITCH TO STOLEN PHONE";
                this.RivalPhone = false;
              }
            }
          }
          else if (!this.Selfie && Input.GetButtonDown("LB") && !this.StudentManager.Eighties)
          {
            if (!this.AR)
            {
              this.Smartphone.cullingMask |= 1 << LayerMask.NameToLayer("Miyuki");
              this.AR = true;
            }
            else
            {
              this.Smartphone.cullingMask &= ~(1 << LayerMask.NameToLayer("Miyuki"));
              this.AR = false;
            }
          }
          if ((double) Input.GetAxis("LT") > 0.5)
            this.UsingController = true;
          if (!this.Aiming)
          {
            this.PauseScreen.NewSettings.Profile.depthOfField.enabled = false;
            if (this.CameraEffects.OneCamera)
            {
              this.MainCamera.clearFlags = CameraClearFlags.Color;
              this.MainCamera.farClipPlane = 0.02f;
              this.HandCamera.clearFlags = CameraClearFlags.Color;
            }
            else
            {
              this.MainCamera.clearFlags = CameraClearFlags.Skybox;
              this.MainCamera.farClipPlane = (float) OptionGlobals.DrawDistance;
              this.HandCamera.clearFlags = CameraClearFlags.Depth;
            }
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.MainCamera.transform.eulerAngles.y, this.transform.eulerAngles.z);
            this.CharacterAnimation.Play(this.IdleAnim);
            if (!this.StudentManager.Eighties)
            {
              this.Smartphone.transform.parent.gameObject.SetActive(true);
              this.Blur.enabled = true;
              if (!this.CinematicCamera.activeInHierarchy)
                this.DisableHairAndAccessories();
              this.HandCamera.gameObject.SetActive(true);
              this.EmptyHands();
              this.PhonePromptBar.Panel.enabled = true;
              this.PhonePromptBar.Show = true;
            }
            else
            {
              this.MainCamera.nearClipPlane = 0.12f;
              this.HandCamera.nearClipPlane = 0.35f;
              this.Smartphone.nearClipPlane = 0.12f;
            }
            this.ShoulderCamera.AimingCamera = true;
            this.YandereVision = false;
            this.Mopping = false;
            this.Selfie = false;
            this.Aiming = true;
            this.PhonePromptBar.Label.text = !this.Inventory.RivalPhone ? "AR GAME ON/OFF" : (this.RivalPhone ? "SWITCH TO YOUR PHONE" : "SWITCH TO STOLEN PHONE");
            Time.timeScale = 1f;
            this.UpdateSelfieStatus();
            this.StudentManager.UpdatePanties(true);
            this.CameraEffects.SmartphoneCamera.depthTextureMode = DepthTextureMode.DepthNormals;
          }
        }
        this.PermitLaugh += Time.deltaTime;
        if (!this.Aiming && !this.Accessories[9].activeInHierarchy && !this.Accessories[16].activeInHierarchy && !this.Pod.activeInHierarchy && (double) this.PermitLaugh > 1.0 && !this.Chased && !Input.GetButton("A"))
        {
          if (Input.GetButton("RB"))
          {
            if (this.MagicalGirl)
            {
              if (this.Armed && this.EquippedWeapon.WeaponID == 14 && Input.GetButtonDown("RB") && !this.ShootingBeam)
              {
                AudioSource.PlayClipAtPoint(this.LoveLoveBeamVoice, this.transform.position);
                this.CharacterAnimation["f02_LoveLoveBeam_00"].time = 0.0f;
                this.CharacterAnimation.CrossFade("f02_LoveLoveBeam_00");
                this.ShootingBeam = true;
                this.CanMove = false;
              }
            }
            else if (this.BlackRobe.activeInHierarchy)
            {
              if (Input.GetButtonDown("RB"))
                AudioSource.PlayClipAtPoint(this.SithOn, this.transform.position);
              this.SithTrailEnd1.localPosition = new Vector3(-1f, 0.0f, 0.0f);
              this.SithTrailEnd2.localPosition = new Vector3(1f, 0.0f, 0.0f);
              this.Beam[0].Play();
              this.Beam[1].Play();
              this.Beam[2].Play();
              this.Beam[3].Play();
              if (Input.GetButtonDown("X"))
              {
                this.CharacterAnimation["f02_sithAttack_00"].time = 0.0f;
                this.CharacterAnimation.Play("f02_sithAttack_00");
                this.SithBeam[1].Damage = 10f;
                this.SithBeam[2].Damage = 10f;
                this.SithAttacking = true;
                this.CanMove = false;
                this.SithPrefix = "";
                this.AttackPrefix = "sith";
              }
              if (Input.GetButtonDown("Y"))
              {
                this.CharacterAnimation["f02_sithAttackHard_00"].time = 0.0f;
                this.CharacterAnimation.Play("f02_sithAttackHard_00");
                this.SithBeam[1].Damage = 20f;
                this.SithBeam[2].Damage = 20f;
                this.SithAttacking = true;
                this.CanMove = false;
                this.SithPrefix = "Hard";
                this.AttackPrefix = "sith";
              }
            }
            else if (this.FloppyHat.activeInHierarchy)
            {
              if (Input.GetButtonDown("RB"))
              {
                this.LongFingers = !this.LongFingers;
                if (this.LongFingers)
                  AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthOpen, this.transform.position);
                else
                  AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthClose, this.transform.position);
              }
            }
            else if (Input.GetButtonDown("RB") && this.SpiderLegs.activeInHierarchy)
            {
              this.SpiderGrow = !this.SpiderGrow;
              if (this.SpiderGrow)
                AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthOpen, this.transform.position);
              else
                AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthClose, this.transform.position);
              this.StudentManager.UpdateStudents();
            }
            this.YandereTimer += Time.deltaTime;
            if ((double) this.YandereTimer > 0.5)
            {
              if (!this.Sans && !this.BlackRobe.activeInHierarchy)
                this.YandereVision = true;
              else if (this.Sans)
              {
                this.SansEyes[0].SetActive(true);
                this.SansEyes[1].SetActive(true);
                this.GlowEffect.Play();
                this.SummonBones = true;
                this.YandereTimer = 0.0f;
                this.CanMove = false;
              }
            }
          }
          else
          {
            if (this.BlackRobe.activeInHierarchy)
            {
              this.SithTrailEnd1.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
              this.SithTrailEnd2.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
              if (Input.GetButtonUp("RB"))
                AudioSource.PlayClipAtPoint(this.SithOff, this.transform.position);
              this.Beam[0].Stop();
              this.Beam[1].Stop();
              this.Beam[2].Stop();
              this.Beam[3].Stop();
            }
            if (this.YandereVision)
              this.YandereVision = false;
          }
          if (Input.GetButtonUp("RB"))
          {
            if (this.CanCloak && !this.WearingRaincoat)
            {
              this.Invisible = !this.Invisible;
              Debug.Log((object) ("Invisibility is: " + this.Invisible.ToString()));
              if (this.Invisible)
                this.Decloak();
              else
                this.Cloak();
            }
            if (this.Stance.Current != StanceType.Crouching && this.Stance.Current != StanceType.Crawling)
            {
              if ((double) this.YandereTimer < 0.5 && !this.Dragging && !this.Carrying && !this.Pod.activeInHierarchy && !this.Laughing)
              {
                if (this.Sans)
                {
                  ++this.BlasterStage;
                  if (this.BlasterStage > 5)
                    this.BlasterStage = 1;
                  GameObject gameObject = Object.Instantiate<GameObject>(this.BlasterSet[this.BlasterStage], this.transform.position, Quaternion.identity);
                  gameObject.transform.position = this.transform.position;
                  gameObject.transform.rotation = this.transform.rotation;
                  AudioSource.PlayClipAtPoint(this.BlasterClip, this.transform.position + Vector3.up);
                  this.CharacterAnimation["f02_sansBlaster_00"].time = 0.0f;
                  this.CharacterAnimation.Play("f02_sansBlaster_00");
                  this.SansEyes[0].SetActive(true);
                  this.SansEyes[1].SetActive(true);
                  this.GlowEffect.Play();
                  this.Blasting = true;
                  this.CanMove = false;
                }
                else if (!this.BlackRobe.activeInHierarchy)
                {
                  if (this.Kagune[0].activeInHierarchy)
                  {
                    if (!this.SwingKagune)
                    {
                      AudioSource.PlayClipAtPoint(this.KaguneSwoosh, this.transform.position + Vector3.up);
                      this.SwingKagune = true;
                    }
                  }
                  else if (this.Gazing || this.Shipgirl)
                  {
                    if (this.Gazing)
                    {
                      this.CharacterAnimation["f02_gazerSnap_00"].time = 0.0f;
                      this.CharacterAnimation.CrossFade("f02_gazerSnap_00");
                    }
                    else
                    {
                      this.CharacterAnimation["f02_shipGirlSnap_00"].time = 0.0f;
                      this.CharacterAnimation.CrossFade("f02_shipGirlSnap_00");
                    }
                    this.Snapping = true;
                    this.CanMove = false;
                  }
                  else if (this.WitchMode)
                  {
                    if (!this.StoppingTime)
                    {
                      this.CharacterAnimation["f02_summonStand_00"].time = 0.0f;
                      if (this.Freezing)
                        AudioSource.PlayClipAtPoint(this.StartShout, this.transform.position);
                      else
                        AudioSource.PlayClipAtPoint(this.StopShout, this.transform.position);
                      this.Freezing = !this.InvertSphere.gameObject.activeInHierarchy;
                      this.StoppingTime = true;
                      this.CanMove = false;
                      this.MyAudio.Stop();
                      this.Egg = true;
                    }
                  }
                  else if ((Object) this.PickUp != (Object) null && this.PickUp.CarryAnimID == 10)
                  {
                    this.StudentManager.NoteWindow.gameObject.SetActive(true);
                    this.StudentManager.NoteWindow.Show = true;
                    this.PromptBar.Show = true;
                    this.Blur.enabled = true;
                    this.CanMove = false;
                    Time.timeScale = 0.0001f;
                    this.HUD.alpha = 0.0f;
                    this.PromptBar.Label[0].text = "Confirm";
                    this.PromptBar.Label[1].text = "Cancel";
                    this.PromptBar.Label[4].text = "Select";
                    this.PromptBar.UpdateButtons();
                  }
                  else if (!this.FalconHelmet.activeInHierarchy && !this.Cape.activeInHierarchy && !this.MagicalGirl && !this.FloppyHat.activeInHierarchy)
                  {
                    if (!this.Xtan)
                    {
                      if (!this.CirnoHair.activeInHierarchy && !this.TornadoHair.activeInHierarchy && !this.BladeHair.activeInHierarchy)
                      {
                        this.LaughAnim = "f02_laugh_01";
                        this.LaughClip = this.Laugh1;
                        ++this.LaughIntensity;
                        this.MyAudio.clip = this.LaughClip;
                        this.MyAudio.time = 0.0f;
                        this.MyAudio.Play();
                      }
                      this.GiggleLines.Play();
                      Object.Instantiate<GameObject>(this.GiggleDisc, this.transform.position + Vector3.up, Quaternion.identity);
                      this.MyAudio.volume = 1f;
                      this.LaughTimer = 0.5f;
                      this.Laughing = true;
                      this.Mopping = false;
                      this.CanMove = false;
                      this.Teeth.SetActive(false);
                    }
                    else if (this.LongHair[0].gameObject.activeInHierarchy)
                    {
                      this.LongHair[0].gameObject.SetActive(false);
                      this.BlackEyePatch.SetActive(false);
                      this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
                      this.SlenderHair[0].SetActive(true);
                      this.SlenderHair[1].SetActive(true);
                    }
                    else
                    {
                      this.LongHair[0].gameObject.SetActive(true);
                      this.BlackEyePatch.SetActive(true);
                      this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
                      this.SlenderHair[0].SetActive(false);
                      this.SlenderHair[1].SetActive(false);
                    }
                  }
                  else if (!this.Punching && !this.FloppyHat.activeInHierarchy)
                  {
                    if (this.FalconHelmet.activeInHierarchy)
                    {
                      GameObject gameObject = Object.Instantiate<GameObject>(this.FalconWindUp);
                      gameObject.transform.parent = this.ItemParent;
                      gameObject.transform.localPosition = Vector3.zero;
                      AudioClipPlayer.PlayAttached(this.FalconPunchVoice, this.MainCamera.transform, 5f, 10f);
                      this.CharacterAnimation["f02_falconPunch_00"].time = 0.0f;
                      this.CharacterAnimation.Play("f02_falconPunch_00");
                      this.FalconSpeed = 0.0f;
                    }
                    else
                    {
                      GameObject gameObject = Object.Instantiate<GameObject>(this.FalconWindUp);
                      gameObject.transform.parent = this.ItemParent;
                      gameObject.transform.localPosition = Vector3.zero;
                      AudioSource.PlayClipAtPoint(this.OnePunchVoices[Random.Range(0, this.OnePunchVoices.Length)], this.transform.position + Vector3.up);
                      this.CharacterAnimation["f02_onePunch_00"].time = 0.0f;
                      this.CharacterAnimation.CrossFade("f02_onePunch_00", 0.15f);
                    }
                    this.Punching = true;
                    this.CanMove = false;
                  }
                }
              }
            }
            else
            {
              this.MyAudio.clip = this.Laugh1;
              this.MyAudio.volume = 1f;
              this.MyAudio.time = 0.0f;
              this.MyAudio.Play();
              this.GiggleLines.Play();
              Object.Instantiate<GameObject>(this.GiggleDisc, this.transform.position + Vector3.up, Quaternion.identity);
            }
            this.YandereTimer = 0.0f;
          }
        }
        if (true)
        {
          if (this.Stance.Current != StanceType.Crouching && this.Stance.Current != StanceType.Crawling)
          {
            if (Input.GetButtonDown("RS"))
            {
              this.CrouchButtonDown = true;
              this.YandereVision = false;
              this.Stance.Current = StanceType.Crouching;
              this.Crouch();
              if (!this.Armed || !this.EquippedWeapon.Concealable)
                this.EmptyHands();
            }
          }
          else
          {
            if (this.Stance.Current == StanceType.Crouching)
            {
              if (Input.GetButton("RS") && !this.CameFromCrouch)
                this.CrawlTimer += Time.deltaTime;
              if ((double) this.CrawlTimer > 0.5)
              {
                if (!this.Selfie)
                {
                  this.EmptyHands();
                  this.YandereVision = false;
                  this.Stance.Current = StanceType.Crawling;
                  this.CrawlTimer = 0.0f;
                  this.Crawl();
                }
              }
              else if (Input.GetButtonUp("RS") && !this.CrouchButtonDown && !this.CameFromCrouch)
              {
                this.Stance.Current = StanceType.Standing;
                this.CrawlTimer = 0.0f;
                this.Uncrouch();
              }
            }
            else if (Input.GetButtonDown("RS"))
            {
              this.CameFromCrouch = true;
              this.Stance.Current = StanceType.Crouching;
              this.Crouch();
            }
            if (Input.GetButtonUp("RS"))
            {
              this.CrouchButtonDown = false;
              this.CameFromCrouch = false;
              this.CrawlTimer = 0.0f;
            }
          }
        }
      }
      if (this.Aiming)
      {
        if (!this.StudentManager.Eighties || this.StudentManager.Eighties && this.Club == ClubType.Photography)
        {
          if (!this.RivalPhone && !this.StudentManager.Eighties && Input.GetButtonDown("A"))
          {
            this.Selfie = !this.Selfie;
            this.UpdateSelfieStatus();
          }
          if (!this.Selfie)
          {
            if (!this.StudentManager.Eighties)
            {
              this.CharacterAnimation["f02_cameraPose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_cameraPose_00"].weight, 1f, Time.deltaTime * 10f);
              this.CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_00"].weight, 0.0f, Time.deltaTime * 10f);
              this.CharacterAnimation["f02_selfie_01"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_01"].weight, 0.0f, Time.deltaTime * 10f);
            }
          }
          else
          {
            this.CharacterAnimation["f02_cameraPose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_cameraPose_00"].weight, 0.0f, Time.deltaTime * 10f);
            if (this.SelfieID == 0)
            {
              this.CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_00"].weight, 1f, Time.deltaTime * 10f);
              this.CharacterAnimation["f02_selfie_01"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_01"].weight, 0.0f, Time.deltaTime * 10f);
            }
            else
            {
              this.CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_00"].weight, 0.0f, Time.deltaTime * 10f);
              this.CharacterAnimation["f02_selfie_01"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_01"].weight, 1f, Time.deltaTime * 10f);
            }
            if (Input.GetButtonDown("B"))
            {
              if (!this.SelfieGuide.activeInHierarchy)
                this.SelfieGuide.SetActive(true);
              else
                this.SelfieGuide.SetActive(false);
            }
          }
          if (this.ClubAccessories[7].activeInHierarchy && ((double) Input.GetAxis("DpadY") != 0.0 || (double) Input.GetAxis("Mouse ScrollWheel") != 0.0 || Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.LeftShift)))
          {
            if (Input.GetKey(KeyCode.Tab))
              this.Smartphone.fieldOfView -= Time.deltaTime * 100f;
            if (Input.GetKey(KeyCode.LeftShift))
              this.Smartphone.fieldOfView += Time.deltaTime * 100f;
            this.Smartphone.fieldOfView -= Input.GetAxis("DpadY");
            this.Smartphone.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 10f;
            if ((double) this.Smartphone.fieldOfView > 60.0)
              this.Smartphone.fieldOfView = 60f;
            if ((double) this.Smartphone.fieldOfView < 30.0)
              this.Smartphone.fieldOfView = 30f;
          }
          if ((double) Input.GetAxis("RT") == 1.0 || Input.GetMouseButtonDown(0) || Input.GetButtonDown("RB"))
          {
            this.RPGCamera.enabled = false;
            this.PauseScreen.CorrectingTime = false;
            Time.timeScale = 0.0001f;
            this.CanMove = false;
            this.Shutter.Snap();
          }
        }
        if ((double) Time.timeScale > 9.99999974737875E-05 && (this.UsingController && (double) Input.GetAxis("LT") < 0.5 || !this.UsingController && !Input.GetMouseButton(1)))
          this.StopAiming();
        if (!this.StudentManager.Eighties)
        {
          if (Input.GetKey(KeyCode.LeftAlt))
          {
            if (!this.CinematicCamera.activeInHierarchy)
            {
              if ((double) this.CinematicTimer > 0.0)
              {
                this.CinematicCamera.transform.eulerAngles = this.Smartphone.transform.eulerAngles;
                this.CinematicCamera.transform.position = this.Smartphone.transform.position;
                this.CinematicCamera.SetActive(true);
                this.CinematicTimer = 0.0f;
                this.UpdateHair();
                this.StopAiming();
              }
              ++this.CinematicTimer;
            }
          }
          else
            this.CinematicTimer = 0.0f;
        }
      }
      if (this.Gloved)
      {
        if (!this.Chased && this.Chasers == 0)
        {
          if (this.InputDevice.Type == InputDeviceType.Gamepad)
          {
            if ((double) Input.GetAxis("DpadY") < -0.5)
            {
              if ((double) this.CharacterAnimation["f02_removeGloves_00"].time == 0.0)
                this.GloveTimer += Time.deltaTime;
              if ((double) this.GloveTimer > 0.5)
              {
                this.CharacterAnimation.CrossFade("f02_removeGloves_00");
                this.Degloving = true;
                this.CanMove = false;
              }
            }
            else
              this.GloveTimer = 0.0f;
          }
          else if (Input.GetKey(KeyCode.Alpha1))
          {
            if ((double) this.CharacterAnimation["f02_removeGloves_00"].time == 0.0)
              this.GloveTimer += Time.deltaTime;
            if ((double) this.GloveTimer > 0.100000001490116)
            {
              this.CharacterAnimation.CrossFade("f02_removeGloves_00");
              this.Degloving = true;
              this.CanMove = false;
            }
          }
          else
            this.GloveTimer = 0.0f;
        }
        else
          this.GloveTimer = 0.0f;
      }
      if ((Object) this.Weapon[1] != (Object) null && (double) this.DropTimer[2] == 0.0)
      {
        if (this.InputDevice.Type == InputDeviceType.Gamepad)
        {
          if ((double) Input.GetAxis("DpadX") < -0.5)
            this.DropWeapon(1);
          else
            this.DropTimer[1] = 0.0f;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
          this.DropWeapon(1);
        else
          this.DropTimer[1] = 0.0f;
      }
      if ((Object) this.Weapon[2] != (Object) null && (double) this.DropTimer[1] == 0.0)
      {
        if (this.InputDevice.Type == InputDeviceType.Gamepad)
        {
          if ((double) Input.GetAxis("DpadX") > 0.5)
            this.DropWeapon(2);
          else
            this.DropTimer[2] = 0.0f;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
          this.DropWeapon(2);
        else
          this.DropTimer[2] = 0.0f;
      }
      if (Input.GetButtonDown("LS") || Input.GetKeyDown(KeyCode.T))
      {
        if ((Object) this.NewTrail != (Object) null)
          Object.Destroy((Object) this.NewTrail);
        this.NewTrail = Object.Instantiate<GameObject>(this.Trail, this.transform.position + this.transform.forward * 0.5f + Vector3.up * 0.1f, Quaternion.identity);
        if (SchemeGlobals.CurrentScheme == 0)
        {
          if ((Object) this.StudentManager.Tutorial != (Object) null && this.StudentManager.Tutorial.isActiveAndEnabled)
            this.NewTrail.GetComponent<AIPath>().target = this.StudentManager.Tutorial.Destination[this.StudentManager.Tutorial.Phase];
          else if ((Object) this.StudentManager.Tag.Target == (Object) null)
            this.NewTrail.GetComponent<AIPath>().target = this.Homeroom;
          else
            this.NewTrail.GetComponent<AIPath>().target = this.StudentManager.Students[this.StudentManager.TagStudentID].transform;
        }
        else if ((Object) this.PauseScreen.Schemes.SchemeDestinations[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme)] != (Object) null)
          this.NewTrail.GetComponent<AIPath>().target = this.PauseScreen.Schemes.SchemeDestinations[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme)];
        else
          Object.Destroy((Object) this.NewTrail);
      }
      if (this.Armed)
      {
        for (this.ID = 0; this.ID < this.ArmedAnims.Length; ++this.ID)
        {
          string armedAnim = this.ArmedAnims[this.ID];
          this.CharacterAnimation[armedAnim].weight = Mathf.Lerp(this.CharacterAnimation[armedAnim].weight, this.EquippedWeapon.AnimID == this.ID ? 1f : 0.0f, Time.deltaTime * 10f);
        }
      }
      else
        this.StopArmedAnim();
      if ((double) this.TheftTimer > 0.0)
      {
        this.TheftTimer = Mathf.MoveTowards(this.TheftTimer, 0.0f, Time.deltaTime);
        if ((double) this.TheftTimer == 0.0)
          this.StolenObjectID = 0;
      }
      if ((double) this.WeaponTimer > 0.0)
        this.WeaponTimer = Mathf.MoveTowards(this.WeaponTimer, 0.0f, Time.deltaTime);
      if ((double) this.MurderousActionTimer > 0.0)
      {
        this.MurderousActionTimer = Mathf.MoveTowards(this.MurderousActionTimer, 0.0f, Time.deltaTime);
        if ((double) this.MurderousActionTimer == 0.0)
          this.TargetStudent = (StudentScript) null;
      }
      if ((double) this.SuspiciousActionTimer > 0.0)
        this.SuspiciousActionTimer = Mathf.MoveTowards(this.SuspiciousActionTimer, 0.0f, Time.deltaTime);
      if ((double) this.PotentiallyMurderousTimer > 0.0)
      {
        Debug.Log((object) "If a student sees a student being electrocuted right now, they should check for Yandere-chan.");
        this.PotentiallyMurderousTimer = Mathf.MoveTowards(this.PotentiallyMurderousTimer, 0.0f, Time.deltaTime);
      }
      if (this.Chased)
      {
        this.PreparedForStruggle = true;
        this.CanMove = false;
      }
      if (!this.Egg)
        return;
      if (this.Eating)
      {
        this.FollowHips = false;
        this.Attacking = false;
        this.CanMove = true;
        this.Eating = false;
        this.EatPhase = 0;
      }
      if (this.Pod.activeInHierarchy)
      {
        if (!this.SithAttacking)
        {
          if ((Object) this.LightSword.transform.parent != (Object) this.LightSwordParent)
          {
            this.LightSword.transform.parent = this.LightSwordParent;
            this.LightSword.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            this.LightSword.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.LightSwordParticles.Play();
          }
          if ((Object) this.HeavySword.transform.parent != (Object) this.HeavySwordParent)
          {
            this.HeavySword.transform.parent = this.HeavySwordParent;
            this.HeavySword.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            this.HeavySword.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.HeavySwordParticles.Play();
          }
        }
        if (Input.GetButtonDown("X"))
        {
          this.LightSword.transform.parent = this.LeftItemParent;
          this.LightSword.transform.localPosition = new Vector3(-0.015f, 0.0f, 0.0f);
          this.LightSword.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
          this.LightSword.GetComponent<WeaponTrail>().enabled = true;
          this.LightSword.GetComponent<WeaponTrail>().Start();
          this.CharacterAnimation["f02_nierAttack_00"].time = 0.0f;
          this.CharacterAnimation.Play("f02_nierAttack_00");
          this.SithAttacking = true;
          this.CanMove = false;
          this.SithBeam[1].Damage = 10f;
          this.NierDamage = 10f;
          this.SithPrefix = "";
          this.AttackPrefix = "nier";
        }
        if (Input.GetButtonDown("Y"))
        {
          this.HeavySword.transform.parent = this.ItemParent;
          this.HeavySword.transform.localPosition = new Vector3(-0.015f, 0.0f, 0.0f);
          this.HeavySword.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
          this.HeavySword.GetComponent<WeaponTrail>().enabled = true;
          this.HeavySword.GetComponent<WeaponTrail>().Start();
          this.CharacterAnimation["f02_nierAttackHard_00"].time = 0.0f;
          this.CharacterAnimation.Play("f02_nierAttackHard_00");
          this.SithAttacking = true;
          this.CanMove = false;
          this.SithBeam[1].Damage = 20f;
          this.NierDamage = 20f;
          this.SithPrefix = "Hard";
          this.AttackPrefix = "nier";
        }
      }
      if (this.WitchMode && Input.GetButtonDown("X") && this.InvertSphere.gameObject.activeInHierarchy)
      {
        this.CharacterAnimation["f02_fingerSnap_00"].time = 0.0f;
        this.CharacterAnimation.Play("f02_fingerSnap_00");
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        this.Snapping = true;
        this.CanMove = false;
      }
      if (this.Armor[20].activeInHierarchy && (Object) this.Armor[20].transform.parent == (Object) this.ItemParent && (Input.GetButtonDown("X") || Input.GetButtonDown("Y")))
      {
        this.CharacterAnimation["f02_nierAttackHard_00"].time = 0.0f;
        this.CharacterAnimation.Play("f02_nierAttackHard_00");
        this.SithAttacking = true;
        this.CanMove = false;
        this.SithBeam[1].Damage = 20f;
        this.NierDamage = 20f;
        this.SithPrefix = "Hard";
        this.AttackPrefix = "nier";
      }
      if (this.LongFingers && Input.GetButtonDown("X") && !this.Swiping)
      {
        if (this.SwipeID == 1)
          this.SwipeID = 0;
        else
          ++this.SwipeID;
        AudioSource.PlayClipAtPoint(this.Swoosh, this.transform.position + Vector3.up);
        this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].time = 0.0f;
        this.CharacterAnimation.Play("f02_sithAttack_0" + this.SwipeID.ToString());
        this.Swiping = true;
        this.CanMove = false;
      }
      if (!this.TitanSword[0].activeInHierarchy)
        return;
      this.UpdateODM();
    }
    else
    {
      if (this.Egg && this.TitanSword[0].activeInHierarchy)
        this.UpdateODM();
      if (this.Chased && !this.Sprayed && !this.Attacking && !this.Dumping && !this.StudentManager.PinningDown && !this.DelinquentFighting && !this.ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
      {
        if ((Object) this.Pursuer != (Object) null)
        {
          this.targetRotation = Quaternion.LookRotation(this.Pursuer.transform.position - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
          this.CharacterAnimation.CrossFade("f02_readyToFight_00");
          if (this.Dragging || this.Carrying)
            this.EmptyHands();
        }
        else
        {
          this.PreparedForStruggle = false;
          this.CanMove = true;
          this.Chased = false;
        }
      }
      this.StopArmedAnim();
      if (this.Dumping)
      {
        this.targetRotation = Quaternion.LookRotation(this.Incinerator.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.Incinerator.transform.position + Vector3.right * -2f);
        if ((double) this.DumpTimer == 0.0 && this.Carrying)
          this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
        this.DumpTimer += Time.deltaTime;
        if ((double) this.DumpTimer > 1.0)
        {
          if ((Object) this.Ragdoll != (Object) null && !this.Ragdoll.GetComponent<RagdollScript>().Dumped)
            this.DumpRagdoll(RagdollDumpType.Incinerator);
          this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
          if ((double) this.CharacterAnimation["f02_carryDisposeA_00"].time >= (double) this.CharacterAnimation["f02_carryDisposeA_00"].length)
          {
            this.Incinerator.Prompt.enabled = true;
            this.Incinerator.Ready = true;
            this.Incinerator.Open = false;
            this.Dragging = false;
            this.Dumping = false;
            this.CanMove = true;
            this.Ragdoll = (GameObject) null;
            this.StopCarrying();
            this.DumpTimer = 0.0f;
          }
        }
      }
      if (this.Chipping)
      {
        this.targetRotation = Quaternion.LookRotation(this.WoodChipper.gameObject.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.WoodChipper.DumpPoint.position);
        if ((double) this.DumpTimer == 0.0 && this.Carrying)
          this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
        this.DumpTimer += Time.deltaTime;
        if ((double) this.DumpTimer > 1.0)
        {
          if (!this.Ragdoll.GetComponent<RagdollScript>().Dumped)
            this.DumpRagdoll(RagdollDumpType.WoodChipper);
          this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
          if ((double) this.CharacterAnimation["f02_carryDisposeA_00"].time >= 4.5 && this.WoodChipper.Acid && !this.WoodChipper.MyAudio.isPlaying)
          {
            this.WoodChipper.MyAudio.clip = this.WoodChipper.ShredAudio;
            this.WoodChipper.MyAudio.Play();
          }
          if ((double) this.CharacterAnimation["f02_carryDisposeA_00"].time >= (double) this.CharacterAnimation["f02_carryDisposeA_00"].length)
          {
            if (!this.WoodChipper.Acid)
              this.WoodChipper.Prompt.HideButton[0] = false;
            this.WoodChipper.Prompt.HideButton[3] = true;
            this.WoodChipper.Occupied = true;
            this.WoodChipper.Open = false;
            this.Dragging = false;
            this.Chipping = false;
            this.CanMove = true;
            this.Ragdoll = (GameObject) null;
            this.StopCarrying();
            this.DumpTimer = 0.0f;
          }
        }
      }
      if (this.TranquilHiding)
      {
        this.targetRotation = Quaternion.LookRotation(this.TranqCase.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.TranqCase.transform.position + Vector3.right * 1.4f);
        if ((double) this.DumpTimer == 0.0 && this.Carrying)
          this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
        this.DumpTimer += Time.deltaTime;
        if ((double) this.DumpTimer > 1.0)
        {
          if (!this.Ragdoll.GetComponent<RagdollScript>().Dumped)
            this.DumpRagdoll(RagdollDumpType.TranqCase);
          this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
          if ((double) this.CharacterAnimation["f02_carryDisposeA_00"].time >= (double) this.CharacterAnimation["f02_carryDisposeA_00"].length)
          {
            this.TranquilHiding = false;
            this.Dragging = false;
            this.Dumping = false;
            this.CanMove = true;
            this.Ragdoll = (GameObject) null;
            this.StopCarrying();
            this.DumpTimer = 0.0f;
          }
        }
      }
      if (this.Dipping)
      {
        if ((Object) this.Bucket != (Object) null)
        {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Bucket.transform.position.x, this.transform.position.y, this.Bucket.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        }
        this.CharacterAnimation.CrossFade("f02_dipping_00");
        if ((double) this.CharacterAnimation["f02_dipping_00"].time >= (double) this.CharacterAnimation["f02_dipping_00"].length * 0.5)
        {
          if ((Object) this.Mop == (Object) null)
            this.Mop = this.PickUp.Mop;
          this.Mop.Bleached = true;
          this.Mop.Sparkles.Play();
          if (this.Mop.StudentBloodID > 0)
          {
            this.Bucket.StudentBloodID = this.Mop.StudentBloodID;
            this.Mop.StudentBloodID = 0;
          }
          if ((double) this.Mop.Bloodiness > 0.0)
          {
            if ((Object) this.Bucket != (Object) null)
            {
              this.Bucket.Bloodiness += this.Mop.Bloodiness / 2f;
              this.Bucket.UpdateAppearance = true;
              if ((double) this.Bucket.Bloodiness >= 50.0)
                this.Bucket.PickUp.Outline[0].color = new Color(1f, 0.5f, 0.0f, 1f);
            }
            this.Mop.Bloodiness = 0.0f;
            this.Mop.UpdateBlood();
          }
        }
        if ((double) this.CharacterAnimation["f02_dipping_00"].time >= (double) this.CharacterAnimation["f02_dipping_00"].length)
        {
          this.CharacterAnimation["f02_dipping_00"].time = 0.0f;
          this.Mop.Prompt.enabled = true;
          this.Dipping = false;
          this.CanMove = true;
        }
      }
      if (this.Pouring)
      {
        this.MoveTowardsTarget(this.Stool.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Stool.rotation, 10f * Time.deltaTime);
        string str = "f02_bucketDump" + this.PourHeight + "_00";
        AnimationState animationState = this.CharacterAnimation[str];
        this.CharacterAnimation.CrossFade(str, 0.0f);
        if ((double) animationState.time >= (double) this.PourTime && !this.PickUp.Bucket.Poured)
        {
          if (this.PickUp.Bucket.Gasoline)
          {
            this.PickUp.Bucket.PourEffect.main.startColor = (ParticleSystem.MinMaxGradient) new Color(1f, 1f, 0.0f, 0.5f);
            Object.Instantiate<GameObject>(this.PickUp.Bucket.GasCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * this.transform.forward, Quaternion.identity);
          }
          else if (this.PickUp.Bucket.DyedBrown)
          {
            this.PickUp.Bucket.PourEffect.main.startColor = (ParticleSystem.MinMaxGradient) new Color(0.25f, 0.125f, 0.0f, 0.5f);
            Object.Instantiate<GameObject>(this.PickUp.Bucket.BrownPaintCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * this.transform.forward, Quaternion.identity);
          }
          else if ((double) this.PickUp.Bucket.Bloodiness < 50.0)
          {
            this.PickUp.Bucket.PourEffect.main.startColor = (ParticleSystem.MinMaxGradient) new Color(0.0f, 1f, 1f, 0.5f);
            Object.Instantiate<GameObject>(this.PickUp.Bucket.WaterCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * this.transform.forward, Quaternion.identity);
          }
          else
          {
            this.PickUp.Bucket.PourEffect.main.startColor = (ParticleSystem.MinMaxGradient) new Color(0.5f, 0.0f, 0.0f, 0.5f);
            Object.Instantiate<GameObject>(this.PickUp.Bucket.BloodCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * this.transform.forward, Quaternion.identity);
          }
          this.PickUp.Bucket.PourEffect.Play();
          this.PickUp.Bucket.Poured = true;
          this.PickUp.Bucket.Empty();
        }
        if ((double) animationState.time >= (double) animationState.length)
        {
          animationState.time = 0.0f;
          this.PickUp.Bucket.Poured = false;
          this.Pouring = false;
          this.CanMove = true;
        }
      }
      if (this.Laughing)
      {
        if (this.Hairstyles[14].activeInHierarchy)
        {
          this.LaughAnim = "storepower_20";
          this.LaughClip = this.ChargeUp;
        }
        if (this.Stand.Stand.activeInHierarchy)
        {
          this.LaughAnim = "f02_jojoAttack_00";
          this.LaughClip = this.YanYan;
        }
        else if (this.FlameDemonic)
        {
          float axis1 = Input.GetAxis("Vertical");
          double axis2 = (double) Input.GetAxis("Horizontal");
          Vector3 vector3_1 = this.MainCamera.transform.TransformDirection(Vector3.forward) with
          {
            y = 0.0f
          };
          vector3_1 = vector3_1.normalized;
          Vector3 vector3_2 = new Vector3(vector3_1.z, 0.0f, -vector3_1.x);
          Vector3 forward = (float) axis2 * vector3_2 + axis1 * vector3_1;
          if (forward != Vector3.zero)
          {
            this.targetRotation = Quaternion.LookRotation(forward);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
          }
          this.LaughAnim = "f02_demonAttack_00";
          this.CirnoTimer -= Time.deltaTime;
          if ((double) this.CirnoTimer < 0.0)
          {
            Object.Instantiate<GameObject>(this.Fireball, this.RightHand.position, this.transform.rotation).transform.localEulerAngles += new Vector3(Random.Range(0.0f, 22.5f), Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f));
            Object.Instantiate<GameObject>(this.Fireball, this.LeftHand.position, this.transform.rotation).transform.localEulerAngles += new Vector3(Random.Range(0.0f, 22.5f), Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f));
            this.CirnoTimer = 0.1f;
          }
        }
        else if (this.CirnoHair.activeInHierarchy)
        {
          float axis3 = Input.GetAxis("Vertical");
          double axis4 = (double) Input.GetAxis("Horizontal");
          Vector3 vector3_3 = this.MainCamera.transform.TransformDirection(Vector3.forward) with
          {
            y = 0.0f
          };
          vector3_3 = vector3_3.normalized;
          Vector3 vector3_4 = new Vector3(vector3_3.z, 0.0f, -vector3_3.x);
          Vector3 forward = (float) axis4 * vector3_4 + axis3 * vector3_3;
          if (forward != Vector3.zero)
          {
            this.targetRotation = Quaternion.LookRotation(forward);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
          }
          this.LaughAnim = "f02_cirnoAttack_00";
          this.CirnoTimer -= Time.deltaTime;
          if ((double) this.CirnoTimer < 0.0)
          {
            Object.Instantiate<GameObject>(this.CirnoIceAttack, this.transform.position + this.transform.up * 1.4f, this.transform.rotation).transform.localEulerAngles += new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            this.MyAudio.PlayOneShot(this.CirnoIceClip);
            this.CirnoTimer = 0.1f;
          }
        }
        else if (this.TornadoHair.activeInHierarchy)
        {
          this.LaughAnim = "f02_tornadoAttack_00";
          this.CirnoTimer -= Time.deltaTime;
          if ((double) this.CirnoTimer < 0.0)
          {
            GameObject gameObject = Object.Instantiate<GameObject>(this.TornadoAttack, this.transform.forward * 5f + new Vector3(this.transform.position.x + Random.Range(-5f, 5f), this.transform.position.y, this.transform.position.z + Random.Range(-5f, 5f)), this.transform.rotation);
            while ((double) Vector3.Distance(this.transform.position, gameObject.transform.position) < 1.0)
              gameObject.transform.position = this.transform.forward * 5f + new Vector3(this.transform.position.x + Random.Range(-5f, 5f), this.transform.position.y, this.transform.position.z + Random.Range(-5f, 5f));
            this.CirnoTimer = 0.1f;
          }
        }
        else if (this.BladeHair.activeInHierarchy)
        {
          this.LaughAnim = "f02_spin_00";
          this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y + (float) ((double) Time.deltaTime * 360.0 * 2.0), this.transform.localEulerAngles.z);
          this.BladeHairCollider1.enabled = true;
          this.BladeHairCollider2.enabled = true;
        }
        else if (this.BanchoActive)
        {
          this.BanchoFlurry.MyCollider.enabled = true;
          this.LaughAnim = "f02_banchoFlurry_00";
        }
        else if ((Object) this.MyAudio.clip != (Object) this.LaughClip)
        {
          this.MyAudio.clip = this.LaughClip;
          this.MyAudio.time = 0.0f;
          this.MyAudio.Play();
        }
        this.CharacterAnimation.CrossFade(this.LaughAnim);
        if (Input.GetButtonDown("RB"))
        {
          ++this.LaughIntensity;
          if ((double) this.LaughIntensity <= 5.0)
          {
            this.LaughAnim = "f02_laugh_01";
            this.LaughClip = this.Laugh1;
            this.LaughTimer = 0.5f;
          }
          else if ((double) this.LaughIntensity <= 10.0)
          {
            this.LaughAnim = "f02_laugh_02";
            this.LaughClip = this.Laugh2;
            this.LaughTimer = 1f;
          }
          else if ((double) this.LaughIntensity <= 15.0)
          {
            this.LaughAnim = "f02_laugh_03";
            this.LaughClip = this.Laugh3;
            this.LaughTimer = 1.5f;
          }
          else if ((double) this.LaughIntensity <= 20.0)
          {
            Object.Instantiate<GameObject>(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
            this.LaughAnim = !this.StudentManager.Eighties ? "f02_laugh_04" : "f02_evilLaugh_00";
            this.LaughClip = this.Laugh4;
            this.LaughTimer = 2f;
            this.LoseGentleEyes();
          }
          else
          {
            Object.Instantiate<GameObject>(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
            this.LaughAnim = !this.StudentManager.Eighties ? "f02_laugh_04" : "f02_evilLaugh_00";
            this.LaughIntensity = 20f;
            this.LaughTimer = 2f;
          }
        }
        if ((double) this.LaughIntensity > 15.0)
          this.Sanity += Time.deltaTime * 10f;
        this.LaughTimer -= Time.deltaTime;
        if ((double) this.LaughTimer <= 0.0)
          this.StopLaughing();
      }
      if (this.TimeSkipping)
      {
        this.CharacterAnimation.CrossFade("f02_timeSkip_00");
        this.Sanity += Time.deltaTime * 0.166666f;
      }
      if (this.DumpsterGrabbing)
      {
        if ((double) Input.GetAxis("Horizontal") > 0.5 || (double) Input.GetAxis("DpadX") > 0.5 || Input.GetKey("right"))
          this.CharacterAnimation.CrossFade((double) this.DumpsterHandle.Direction == -1.0 ? "f02_dumpsterPull_00" : "f02_dumpsterPush_00");
        else if ((double) Input.GetAxis("Horizontal") < -0.5 || (double) Input.GetAxis("DpadX") < -0.5 || Input.GetKey("left"))
          this.CharacterAnimation.CrossFade((double) this.DumpsterHandle.Direction == -1.0 ? "f02_dumpsterPush_00" : "f02_dumpsterPull_00");
        else
          this.CharacterAnimation.CrossFade("f02_dumpsterGrab_00");
      }
      if (this.Stripping)
      {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.StudentManager.YandereStripSpot.rotation, 10f * Time.deltaTime);
        if ((double) this.CharacterAnimation["f02_stripping_00"].time >= (double) this.CharacterAnimation["f02_stripping_00"].length)
        {
          this.Stripping = false;
          this.CanMove = true;
          this.MyLocker.UpdateSchoolwear();
        }
      }
      if (this.Bathing)
      {
        this.MoveTowardsTarget(this.YandereShower.BatheSpot.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.YandereShower.BatheSpot.rotation, 10f * Time.deltaTime);
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.YandereShower.Timer < 1.0)
        {
          if (this.Schoolwear == 2)
          {
            --this.Police.BloodyClothing;
            ++this.StudentManager.OriginalUniforms;
            Debug.Log((object) ("And now, # of OriginalUniforms is: " + this.StudentManager.OriginalUniforms.ToString() + " and # of NewUniforms is: " + this.StudentManager.NewUniforms.ToString()));
          }
          this.Bloodiness = 0.0f;
          this.Bathing = false;
          this.CanMove = true;
        }
      }
      if (this.Degloving)
      {
        this.CharacterAnimation.CrossFade("f02_removeGloves_00");
        if ((double) this.CharacterAnimation["f02_removeGloves_00"].time >= (double) this.CharacterAnimation["f02_removeGloves_00"].length)
        {
          this.Gloves.GetComponent<Rigidbody>().isKinematic = false;
          this.Gloves.transform.parent = (Transform) null;
          if (this.WearingRaincoat)
          {
            this.RaincoatAttacher.newRenderer.enabled = false;
            this.CoatBloodiness = this.Bloodiness;
            this.Bloodiness = this.OriginalBloodiness;
            this.WearingRaincoat = false;
            if (this.Schoolwear == 1)
            {
              this.PantyAttacher.newRenderer.enabled = true;
              this.TheDebugMenuScript.UpdateCensor();
            }
            this.Hairstyle = this.HairstyleBeforeRaincoat;
            this.UpdateHair();
          }
          else
            this.GloveAttacher.newRenderer.enabled = false;
          this.Gloves.gameObject.SetActive(true);
          if (this.Gloves.Blood.enabled)
          {
            OutlineScript component = this.Gloves.GetComponent<OutlineScript>();
            if ((Object) component != (Object) null)
              component.color = new Color(1f, 0.5f, 0.0f, 1f);
          }
          this.StudentManager.GloveID = 0;
          this.Degloving = false;
          this.CanMove = true;
          this.Gloved = false;
          this.Gloves = (GloveScript) null;
          this.SetUniform();
          this.GloveBlood = 0;
          Debug.Log((object) "Gloves removed.");
        }
        else if (this.Chased || this.Chasers > 0 || this.Noticed)
        {
          this.Degloving = false;
          this.GloveTimer = 0.0f;
          if (!this.Noticed)
            this.CanMove = true;
        }
        else if (this.InputDevice.Type == InputDeviceType.Gamepad)
        {
          if ((double) Input.GetAxis("DpadY") > -0.5)
          {
            this.Degloving = false;
            this.CanMove = true;
            this.GloveTimer = 0.0f;
          }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
          this.Degloving = false;
          this.CanMove = true;
          this.GloveTimer = 0.0f;
        }
      }
      if (this.Struggling)
      {
        if (!this.Won && !this.Lost)
        {
          this.CharacterAnimation.CrossFade(this.TargetStudent.Teacher ? "f02_teacherStruggleA_00" : "f02_struggleA_00");
          this.targetRotation = Quaternion.LookRotation(this.TargetStudent.transform.position - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        }
        else if (this.Won)
        {
          if (!this.TargetStudent.Teacher)
          {
            this.CharacterAnimation.CrossFade("f02_struggleWinA_00");
            if ((double) this.CharacterAnimation["f02_struggleWinA_00"].time > (double) this.CharacterAnimation["f02_struggleWinA_00"].length - 1.0)
              this.EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(this.EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime * 3.33333f);
          }
          else
          {
            Debug.Log((object) (this.TargetStudent.Name + " is being instructed to perform their ''losing struggle'' animation."));
            this.CharacterAnimation.CrossFade("f02_teacherStruggleWinA_00");
            this.TargetStudent.CharacterAnimation.CrossFade(this.TargetStudent.StruggleWonAnim);
            this.EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(this.EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime);
          }
          if (this.StrugglePhase == 0)
          {
            if (!this.TargetStudent.Teacher && (double) this.CharacterAnimation["f02_struggleWinA_00"].time > 1.29999995231628 || this.TargetStudent.Teacher && (double) this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 0.800000011920929)
            {
              Debug.Log((object) ("Yandere-chan just killed " + this.TargetStudent.Name + " as a result of winning a struggling against them."));
              this.TargetStudent.DeathCause = this.EquippedWeapon.WeaponID;
              Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.TargetStudent.Teacher ? this.EquippedWeapon.transform.position : this.TargetStudent.Head.position, Quaternion.identity);
              this.Bloodiness += 20f;
              this.Sanity -= 20f * this.Numbness;
              this.StainWeapon();
              ++this.StrugglePhase;
            }
          }
          else if (this.StrugglePhase == 1)
          {
            if (this.TargetStudent.Teacher && (double) this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 1.29999995231628)
            {
              Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.EquippedWeapon.transform.position, Quaternion.identity);
              ++this.StrugglePhase;
            }
          }
          else if (this.StrugglePhase == 2 && this.TargetStudent.Teacher && (double) this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 2.09999990463257)
          {
            Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.EquippedWeapon.transform.position, Quaternion.identity);
            ++this.StrugglePhase;
          }
          if (!this.TargetStudent.Teacher && (double) this.CharacterAnimation["f02_struggleWinA_00"].time > (double) this.CharacterAnimation["f02_struggleWinA_00"].length || this.TargetStudent.Teacher && (double) this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > (double) this.CharacterAnimation["f02_teacherStruggleWinA_00"].length)
          {
            this.MyController.radius = 0.2f;
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.ShoulderCamera.Struggle = false;
            this.Struggling = false;
            this.StrugglePhase = 0;
            if ((Object) this.TargetStudent == (Object) this.Pursuer)
            {
              this.Pursuer = (StudentScript) null;
              this.Chased = false;
            }
            this.TargetStudent.BecomeRagdoll();
            this.TargetStudent.DeathType = DeathType.Weapon;
            this.SeenByAuthority = false;
          }
        }
        else if (this.Lost)
          this.CharacterAnimation.CrossFade(this.TargetStudent.Teacher ? "f02_teacherStruggleLoseA_00" : "f02_struggleLoseA_00");
      }
      if (this.ClubActivity)
      {
        if (this.Club == ClubType.Drama)
          this.CharacterAnimation.Play("f02_performing_00");
        else if (this.Club == ClubType.Art)
          this.CharacterAnimation.Play("f02_painting_00");
        else if (this.Club == ClubType.MartialArts)
        {
          this.CharacterAnimation.Play("f02_kick_23");
          if ((double) this.CharacterAnimation["f02_kick_23"].time >= (double) this.CharacterAnimation["f02_kick_23"].length)
            this.CharacterAnimation["f02_kick_23"].time = 0.0f;
        }
        else if (this.Club == ClubType.Photography)
          this.CharacterAnimation.Play("f02_sit_00");
        else if (this.Club == ClubType.Gaming)
          this.CharacterAnimation.Play("f02_playingGames_00");
      }
      if (this.Possessed)
        this.CharacterAnimation.CrossFade("f02_possessionPose_00");
      if (this.Lifting)
      {
        if (!this.HeavyWeight)
        {
          if ((double) this.CharacterAnimation["f02_carryLiftA_00"].time >= (double) this.CharacterAnimation["f02_carryLiftA_00"].length)
          {
            this.IdleAnim = this.CarryIdleAnim;
            this.WalkAnim = this.CarryWalkAnim;
            this.RunAnim = this.CarryRunAnim;
            this.CanMove = true;
            this.Carrying = true;
            this.Lifting = false;
          }
        }
        else if ((double) this.CharacterAnimation["f02_heavyWeightLift_00"].time >= (double) this.CharacterAnimation["f02_heavyWeightLift_00"].length)
        {
          this.CharacterAnimation[this.CarryAnims[0]].weight = 1f;
          this.IdleAnim = this.HeavyIdleAnim;
          this.WalkAnim = this.HeavyWalkAnim;
          this.RunAnim = this.CarryRunAnim;
          this.CanMove = true;
          this.Lifting = false;
        }
      }
      if (this.Dropping)
      {
        this.targetRotation = Quaternion.LookRotation(this.DropSpot.position + this.DropSpot.forward - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.DropSpot.position);
        if ((Object) this.Ragdoll != (Object) null && (Object) this.CurrentRagdoll == (Object) null)
          this.CurrentRagdoll = this.Ragdoll.GetComponent<RagdollScript>();
        if ((double) this.DumpTimer == 0.0 && this.Carrying)
        {
          this.CurrentRagdoll.CharacterAnimation[this.CurrentRagdoll.DumpedAnim].time = 2.5f;
          this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
        }
        this.DumpTimer += Time.deltaTime;
        if ((double) this.DumpTimer > 1.0)
        {
          this.FollowHips = true;
          if ((Object) this.Ragdoll != (Object) null)
          {
            this.CurrentRagdoll.PelvisRoot.localEulerAngles = new Vector3(this.CurrentRagdoll.PelvisRoot.localEulerAngles.x, 0.0f, this.CurrentRagdoll.PelvisRoot.localEulerAngles.z);
            this.CurrentRagdoll.PelvisRoot.localPosition = new Vector3(this.CurrentRagdoll.PelvisRoot.localPosition.x, this.CurrentRagdoll.PelvisRoot.localPosition.y, 0.0f);
          }
          this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, this.transform.position.y + 1f, this.Hips.position.z), Time.deltaTime * 10f);
          if ((double) this.CharacterAnimation["f02_carryDisposeA_00"].time >= 4.5)
          {
            this.StopCarrying();
          }
          else
          {
            if (this.CurrentRagdoll.StopAnimation)
            {
              this.CurrentRagdoll.StopAnimation = false;
              for (this.ID = 0; this.ID < this.CurrentRagdoll.AllRigidbodies.Length; ++this.ID)
                this.CurrentRagdoll.AllRigidbodies[this.ID].isKinematic = true;
            }
            this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
            this.CurrentRagdoll.CharacterAnimation.CrossFade(this.CurrentRagdoll.DumpedAnim);
            this.Ragdoll.transform.position = this.transform.position;
            this.Ragdoll.transform.eulerAngles = this.transform.eulerAngles;
          }
          if ((double) this.CharacterAnimation["f02_carryDisposeA_00"].time >= (double) this.CharacterAnimation["f02_carryDisposeA_00"].length)
          {
            this.CameraTarget.localPosition = new Vector3(0.0f, 1f, 0.0f);
            this.FollowHips = false;
            this.Dropping = false;
            this.CanMove = true;
            this.DumpTimer = 0.0f;
          }
        }
      }
      if (this.Dismembering && (double) this.CharacterAnimation["f02_dismember_00"].time >= (double) this.CharacterAnimation["f02_dismember_00"].length)
      {
        this.CameraEffects.UpdateDOF(2f);
        this.Ragdoll.GetComponent<RagdollScript>().Dismember();
        this.RPGCamera.enabled = true;
        this.TargetStudent = (StudentScript) null;
        this.Dismembering = false;
        this.CanMove = true;
        this.Ragdoll = (GameObject) null;
      }
      if (this.Shoved)
      {
        if ((double) this.CharacterAnimation["f02_shoveA_01"].time >= (double) this.CharacterAnimation["f02_shoveA_01"].length)
        {
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.Shoved = false;
          if (!this.CannotRecover)
            this.CanMove = true;
        }
        else if ((double) this.CharacterAnimation["f02_shoveA_01"].time < 0.666660010814667)
        {
          int num15 = (int) this.MyController.Move(this.transform.forward * -1f * this.ShoveSpeed * Time.deltaTime);
          int num16 = (int) this.MyController.Move(Physics.gravity * 0.1f);
          if ((double) this.ShoveSpeed > 0.0)
            this.ShoveSpeed = Mathf.MoveTowards(this.ShoveSpeed, 0.0f, Time.deltaTime * 3f);
        }
      }
      if (this.Attacked && (double) this.CharacterAnimation["f02_swingB_00"].time >= (double) this.CharacterAnimation["f02_swingB_00"].length)
      {
        this.ShoulderCamera.HeartbrokenCamera.SetActive(true);
        this.enabled = false;
      }
      if (this.Hiding)
      {
        if (!this.Exiting)
        {
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.HidingSpot.rotation, Time.deltaTime * 10f);
          this.MoveTowardsTarget(this.HidingSpot.position);
          this.CharacterAnimation.CrossFade(this.HideAnim);
          if (Input.GetButtonDown("B"))
          {
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
            this.Exiting = true;
          }
        }
        else
        {
          this.MoveTowardsTarget(this.ExitSpot.position);
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.ExitTimer += Time.deltaTime;
          if ((double) this.ExitTimer > 1.0 || (double) Vector3.Distance(this.transform.position, this.ExitSpot.position) < 0.100000001490116)
          {
            this.MyController.center = new Vector3(this.MyController.center.x, 0.875f, this.MyController.center.z);
            this.MyController.radius = 0.2f;
            this.MyController.height = 1.55f;
            this.ExitTimer = 0.0f;
            this.Exiting = false;
            this.CanMove = true;
            this.Hiding = false;
          }
        }
      }
      if (this.BucketDropping)
      {
        this.targetRotation = Quaternion.LookRotation(this.DropSpot.position + this.DropSpot.forward - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.DropSpot.position);
        if ((double) this.CharacterAnimation["f02_bucketDrop_00"].time >= (double) this.CharacterAnimation["f02_bucketDrop_00"].length)
        {
          this.MyController.radius = 0.2f;
          this.BucketDropping = false;
          this.CanMove = true;
        }
        else if ((double) this.CharacterAnimation["f02_bucketDrop_00"].time >= 1.0 && (Object) this.PickUp != (Object) null)
        {
          GameObjectUtils.SetLayerRecursively(this.PickUp.Bucket.gameObject, 0);
          this.PickUp.Bucket.UpdateAppearance = true;
          this.PickUp.Bucket.Dropped = true;
          this.EmptyHands();
        }
      }
      if (this.Flicking)
      {
        if ((double) this.CharacterAnimation["f02_flickingMatch_00"].time >= (double) this.CharacterAnimation["f02_flickingMatch_00"].length)
        {
          this.PickUp.GetComponent<MatchboxScript>().Prompt.enabled = true;
          this.Arc.SetActive(true);
          this.Flicking = false;
          this.CanMove = true;
        }
        else if ((double) this.CharacterAnimation["f02_flickingMatch_00"].time > 1.0 && (Object) this.Match != (Object) null)
        {
          Rigidbody component = this.Match.GetComponent<Rigidbody>();
          component.isKinematic = false;
          component.useGravity = true;
          component.AddRelativeForce(Vector3.right * 250f);
          this.Match.transform.parent = (Transform) null;
          this.Match = (GameObject) null;
        }
      }
      if (this.Rummaging)
      {
        this.MoveTowardsTarget(this.RummageSpot.Target.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.RummageSpot.Target.rotation, Time.deltaTime * 10f);
        this.RummageTimer += Time.deltaTime;
        this.ProgressBar.transform.localScale = new Vector3(this.RummageTimer / 10f, this.ProgressBar.transform.localScale.y, this.ProgressBar.transform.localScale.z);
        if ((double) this.RummageTimer > 10.0)
        {
          this.RummageSpot.GetReward();
          this.ProgressBar.transform.parent.gameObject.SetActive(false);
          this.RummageSpot = (RummageSpotScript) null;
          this.Rummaging = false;
          this.RummageTimer = 0.0f;
          this.CanMove = true;
        }
      }
      if (this.Digging)
      {
        if (this.DigPhase == 1)
        {
          if ((double) this.CharacterAnimation["f02_shovelDig_00"].time >= 1.66666662693024)
          {
            this.MyAudio.volume = 1f;
            this.MyAudio.clip = this.Dig;
            this.MyAudio.Play();
            ++this.DigPhase;
          }
        }
        else if (this.DigPhase == 2)
        {
          if ((double) this.CharacterAnimation["f02_shovelDig_00"].time >= 3.5)
          {
            this.MyAudio.volume = 1f;
            this.MyAudio.Play();
            ++this.DigPhase;
          }
        }
        else if (this.DigPhase == 3)
        {
          if ((double) this.CharacterAnimation["f02_shovelDig_00"].time >= 5.66666650772095)
          {
            this.MyAudio.volume = 1f;
            this.MyAudio.Play();
            ++this.DigPhase;
          }
        }
        else if (this.DigPhase == 4 && (double) this.CharacterAnimation["f02_shovelDig_00"].time >= (double) this.CharacterAnimation["f02_shovelDig_00"].length)
        {
          this.EquippedWeapon.gameObject.SetActive(true);
          this.FloatingShovel.SetActive(false);
          this.RPGCamera.enabled = true;
          this.Digging = false;
          this.CanMove = true;
        }
      }
      if (this.Burying)
      {
        if (this.DigPhase == 1)
        {
          if ((double) this.CharacterAnimation["f02_shovelBury_00"].time >= 2.16666674613953)
          {
            this.MyAudio.volume = 1f;
            this.MyAudio.clip = this.Dig;
            this.MyAudio.Play();
            ++this.DigPhase;
          }
        }
        else if (this.DigPhase == 2)
        {
          if ((double) this.CharacterAnimation["f02_shovelBury_00"].time >= 4.66666650772095)
          {
            this.MyAudio.volume = 1f;
            this.MyAudio.Play();
            ++this.DigPhase;
          }
        }
        else if ((double) this.CharacterAnimation["f02_shovelBury_00"].time >= (double) this.CharacterAnimation["f02_shovelBury_00"].length)
        {
          this.EquippedWeapon.gameObject.SetActive(true);
          this.FloatingShovel.SetActive(false);
          this.RPGCamera.enabled = true;
          this.Burying = false;
          this.CanMove = true;
        }
      }
      if (this.Pickpocketing && !this.Noticed && this.Caught)
      {
        this.CaughtTimer += Time.deltaTime;
        if ((double) this.CaughtTimer > 1.0)
        {
          if (!this.CannotRecover)
            this.CanMove = true;
          this.Pickpocketing = false;
          this.CaughtTimer = 0.0f;
          this.Caught = false;
        }
      }
      if (this.Sprayed)
      {
        if (this.SprayPhase == 0)
        {
          if ((double) this.CharacterAnimation["f02_sprayed_00"].time > 0.66666)
          {
            this.Blur.enabled = true;
            this.Blur.Size += Time.deltaTime;
          }
          if ((double) this.CharacterAnimation["f02_sprayed_00"].time > 5.0)
          {
            this.Police.Darkness.enabled = true;
            this.Police.Darkness.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Police.Darkness.color.a, 1f, Time.deltaTime));
            if ((double) this.Police.Darkness.color.a == 1.0)
            {
              this.SprayTimer += Time.deltaTime;
              if ((double) this.SprayTimer > 1.0)
              {
                this.CharacterAnimation.Play("f02_tied_00");
                this.RPGCamera.enabled = false;
                this.ZipTie[0].SetActive(true);
                this.ZipTie[1].SetActive(true);
                this.Blur.enabled = false;
                this.SprayTimer = 0.0f;
                ++this.SprayPhase;
              }
            }
          }
        }
        else if (this.SprayPhase == 1)
        {
          this.Police.Darkness.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Police.Darkness.color.a, 0.0f, Time.deltaTime));
          if ((double) this.Police.Darkness.color.a == 0.0)
          {
            this.SprayTimer += Time.deltaTime;
            if ((double) this.SprayTimer > 1.0)
            {
              this.ShoulderCamera.HeartbrokenCamera.SetActive(true);
              this.HeartCamera.gameObject.SetActive(false);
              this.HUD.alpha = 0.0f;
              ++this.SprayPhase;
            }
          }
        }
      }
      if (this.CleaningWeapon)
      {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Target.rotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.Target.position);
        if ((double) this.CharacterAnimation["f02_cleaningWeapon_00"].time >= (double) this.CharacterAnimation["f02_cleaningWeapon_00"].length)
        {
          this.EquippedWeapon.Blood.enabled = false;
          this.EquippedWeapon.Evidence = false;
          this.EquippedWeapon.Bloody = false;
          this.EquippedWeapon.SuspicionCheck();
          if (this.Gloved)
            this.EquippedWeapon.FingerprintID = 0;
          this.CleaningWeapon = false;
          this.CanMove = true;
        }
      }
      if (this.CrushingPhone)
      {
        this.CharacterAnimation.CrossFade("f02_phoneCrush_00");
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.PhoneToCrush.transform.position.x, this.transform.position.y, this.PhoneToCrush.transform.position.z) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.PhoneToCrush.PhoneCrushingSpot.position);
        if ((double) this.CharacterAnimation["f02_phoneCrush_00"].time >= 0.5 && this.PhoneToCrush.enabled)
        {
          this.PhoneToCrush.transform.localEulerAngles = new Vector3(this.PhoneToCrush.transform.localEulerAngles.x, this.PhoneToCrush.transform.localEulerAngles.y, 0.0f);
          Object.Instantiate<GameObject>(this.PhoneToCrush.PhoneSmash, this.PhoneToCrush.transform.position, Quaternion.identity);
          --this.Police.PhotoEvidence;
          this.PhoneToCrush.MyRenderer.material.mainTexture = this.PhoneToCrush.SmashedTexture;
          this.PhoneToCrush.MyMesh.mesh = this.PhoneToCrush.SmashedMesh;
          this.PhoneToCrush.Prompt.Hide();
          this.PhoneToCrush.Prompt.enabled = false;
          this.PhoneToCrush.enabled = false;
        }
        if ((double) this.CharacterAnimation["f02_phoneCrush_00"].time >= (double) this.CharacterAnimation["f02_phoneCrush_00"].length)
        {
          this.CrushingPhone = false;
          this.CanMove = true;
        }
      }
      if (this.SubtleStabbing)
      {
        if ((double) this.CharacterAnimation["f02_subtleStab_00"].time < 0.5)
        {
          this.CharacterAnimation.CrossFade("f02_subtleStab_00");
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
          this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * -1f);
        }
        else if (this.TargetStudent.Strength > 0)
        {
          this.TargetStudent.Strength = 0;
          this.TargetStudent.Hunter.MurderSuicidePhase = 0;
          this.TargetStudent.Hunter.AttackWillFail = false;
          this.TargetStudent.Hunter.Pathfinding.canMove = true;
          this.TargetStudent.CharacterAnimation["f02_murderSuicide_01"].time = 1.5f;
          this.TargetStudent.Hunter.CharacterAnimation["f02_murderSuicide_00"].time = 1.5f;
          Debug.Log((object) "Making the hunter's attack a success!");
        }
        if ((double) this.CharacterAnimation["f02_subtleStab_00"].time >= (double) this.CharacterAnimation["f02_subtleStab_00"].length)
        {
          this.SubtleStabbing = false;
          this.CanMove = true;
        }
      }
      if (this.SneakingShot)
      {
        if ((double) this.SneakShotTimer == 0.0)
        {
          this.CharacterAnimation["f02_sneakShot_01"].speed = 4f;
          this.CharacterAnimation.CrossFade("f02_sneakShot_01");
          if ((double) this.CharacterAnimation["f02_sneakShot_01"].time >= 1.0)
            this.SneakShotPhone.SetActive(true);
          if ((double) this.CharacterAnimation["f02_sneakShot_01"].time >= (double) this.CharacterAnimation["f02_sneakShot_01"].length)
          {
            this.SneakShotTimer += Time.deltaTime;
            this.CameraFlash.SetActive(true);
            this.StudentManager.UpdatePanties(true);
            Object.Instantiate<GameObject>(this.PantyDetector, this.SneakShotPhone.transform.position, this.transform.rotation).GetComponent<PantyDetectorScript>().Yandere = this;
          }
        }
        else
        {
          this.SneakShotTimer += Time.deltaTime;
          if ((double) this.SneakShotTimer > 0.333330005407333)
          {
            this.CharacterAnimation["f02_sneakShot_02"].speed = 4f;
            this.CharacterAnimation.CrossFade("f02_sneakShot_02");
            if ((double) this.CharacterAnimation["f02_sneakShot_02"].time >= 1.5)
            {
              this.SneakShotPhone.SetActive(false);
              this.CameraFlash.SetActive(false);
              this.SneakingShot = false;
              this.CanMove = true;
              this.Lewd = false;
              this.SneakShotTimer = 0.0f;
            }
          }
        }
      }
      if ((double) this.CanMoveTimer > 0.0)
      {
        this.CanMoveTimer = Mathf.MoveTowards(this.CanMoveTimer, 0.0f, Time.deltaTime);
        if ((double) this.CanMoveTimer == 0.0)
          this.CanMove = true;
      }
      if (!this.Egg)
        return;
      if (this.Punching)
      {
        if (this.FalconHelmet.activeInHierarchy)
        {
          if ((double) this.CharacterAnimation["f02_falconPunch_00"].time >= 1.0 && (double) this.CharacterAnimation["f02_falconPunch_00"].time <= 1.25)
            this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, 2.5f, Time.deltaTime * 2.5f);
          else if ((double) this.CharacterAnimation["f02_falconPunch_00"].time >= 1.25 && (double) this.CharacterAnimation["f02_falconPunch_00"].time <= 1.5)
            this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, 0.0f, Time.deltaTime * 2.5f);
          if ((double) this.CharacterAnimation["f02_falconPunch_00"].time >= 1.0 && (double) this.CharacterAnimation["f02_falconPunch_00"].time <= 1.5)
          {
            if ((Object) this.NewFalconPunch == (Object) null)
            {
              this.NewFalconPunch = Object.Instantiate<GameObject>(this.FalconPunch);
              this.NewFalconPunch.transform.parent = this.ItemParent;
              this.NewFalconPunch.transform.localPosition = Vector3.zero;
            }
            int num = (int) this.MyController.Move(this.transform.forward * this.FalconSpeed);
          }
          if ((double) this.CharacterAnimation["f02_falconPunch_00"].time >= (double) this.CharacterAnimation["f02_falconPunch_00"].length)
          {
            this.NewFalconPunch = (GameObject) null;
            this.Punching = false;
            this.CanMove = true;
          }
        }
        else
        {
          if ((double) this.CharacterAnimation["f02_onePunch_00"].time >= 0.833333015441895 && (double) this.CharacterAnimation["f02_onePunch_00"].time <= 1.0 && (Object) this.NewOnePunch == (Object) null)
          {
            this.NewOnePunch = Object.Instantiate<GameObject>(this.OnePunch);
            this.NewOnePunch.transform.parent = this.ItemParent;
            this.NewOnePunch.transform.localPosition = Vector3.zero;
          }
          if ((double) this.CharacterAnimation["f02_onePunch_00"].time >= 2.0)
          {
            this.NewOnePunch = (GameObject) null;
            this.Punching = false;
            this.CanMove = true;
          }
        }
      }
      if (this.PK)
      {
        if ((double) Input.GetAxis("Vertical") > 0.5)
          this.GoToPKDir(PKDirType.Up, "f02_sansUp_00", new Vector3(0.0f, 3f, 2f));
        else if ((double) Input.GetAxis("Vertical") < -0.5)
          this.GoToPKDir(PKDirType.Down, "f02_sansDown_00", new Vector3(0.0f, 0.0f, 2f));
        else if ((double) Input.GetAxis("Horizontal") > 0.5)
          this.GoToPKDir(PKDirType.Right, "f02_sansRight_00", new Vector3(1.5f, 1.5f, 2f));
        else if ((double) Input.GetAxis("Horizontal") < -0.5)
        {
          this.GoToPKDir(PKDirType.Left, "f02_sansLeft_00", new Vector3(-1.5f, 1.5f, 2f));
        }
        else
        {
          this.CharacterAnimation.CrossFade("f02_sansHold_00");
          this.RagdollPK.transform.localPosition = new Vector3(0.0f, 1.5f, 2f);
          this.PKDir = PKDirType.None;
        }
        if (Input.GetButtonDown("B"))
        {
          this.PromptBar.ClearButtons();
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = false;
          this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.CanMove = true;
          this.PK = false;
        }
      }
      if (this.SummonBones)
      {
        this.CharacterAnimation.CrossFade("f02_sansBones_00");
        if ((double) this.BoneTimer == 0.0)
          Object.Instantiate<GameObject>(this.Bone, this.transform.position + this.transform.right * Random.Range(-2.5f, 2.5f) + this.transform.up * -2f + this.transform.forward * Random.Range(1f, 6f), Quaternion.identity);
        this.BoneTimer += Time.deltaTime;
        if ((double) this.BoneTimer > 0.100000001490116)
          this.BoneTimer = 0.0f;
        if (Input.GetButtonUp("RB"))
        {
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.SummonBones = false;
          this.CanMove = true;
        }
        if (this.PK)
        {
          this.PromptBar.ClearButtons();
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = false;
          this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.CanMove = true;
          this.PK = false;
        }
      }
      if (this.Blasting)
      {
        if ((double) this.CharacterAnimation["f02_sansBlaster_00"].time >= (double) this.CharacterAnimation["f02_sansBlaster_00"].length - 0.25)
        {
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.Blasting = false;
          this.CanMove = true;
        }
        if (this.PK)
        {
          this.PromptBar.ClearButtons();
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = false;
          this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.CanMove = true;
          this.PK = false;
        }
      }
      if (this.SithAttacking)
      {
        if (!this.SithRecovering)
        {
          if ((double) this.SithBeam[1].Damage == 10.0 || (double) this.NierDamage == 10.0)
          {
            if (this.SithAttacks == 0)
            {
              if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time >= (double) this.SithSpawnTime[this.SithCombo])
              {
                Object.Instantiate<GameObject>(this.SithHitbox, this.transform.position + this.transform.forward * 1f + this.transform.up, this.transform.rotation);
                ++this.SithAttacks;
              }
            }
          }
          else if (this.Pod.activeInHierarchy || this.Armor[20].activeInHierarchy)
          {
            if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time >= (double) this.SithHardSpawnTime1[this.SithCombo] && this.SithAttacks == 0)
            {
              Object.Instantiate<GameObject>(this.SithHitbox, this.transform.position + this.transform.forward * 1.5f + this.transform.up, this.transform.rotation).GetComponent<SithBeamScript>().Damage = 20f;
              ++this.SithAttacks;
              if (this.SithCombo < 2)
                Object.Instantiate<GameObject>(this.GroundImpact, this.transform.position + this.transform.forward * 1.5f, this.transform.rotation).transform.localScale = new Vector3(2f, 2f, 2f);
            }
          }
          else if (this.SithAttacks == 0)
          {
            if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time >= (double) this.SithHardSpawnTime1[this.SithCombo])
            {
              Object.Instantiate<GameObject>(this.SithHardHitbox, this.transform.position + this.transform.forward * 1f + this.transform.up, this.transform.rotation);
              ++this.SithAttacks;
            }
          }
          else if (this.SithAttacks == 1)
          {
            if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time >= (double) this.SithHardSpawnTime2[this.SithCombo])
            {
              Object.Instantiate<GameObject>(this.SithHardHitbox, this.transform.position + this.transform.forward * 1f + this.transform.up, this.transform.rotation);
              ++this.SithAttacks;
            }
          }
          else if (this.SithAttacks == 2 && this.SithCombo == 1)
          {
            if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time >= 0.933333337306976)
            {
              Object.Instantiate<GameObject>(this.SithHardHitbox, this.transform.position + this.transform.forward * 1f + this.transform.up, this.transform.rotation);
              ++this.SithAttacks;
            }
          }
          this.SithSoundCheck();
          if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time >= (double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].length)
          {
            if (this.SithCombo < this.SithComboLength)
            {
              ++this.SithCombo;
              this.SithSounds = 0;
              this.SithAttacks = 0;
              this.CharacterAnimation.Play("f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString());
            }
            else
            {
              this.CharacterAnimation.Play("f02_" + this.AttackPrefix + "Recover" + this.SithPrefix + "_0" + this.SithCombo.ToString());
              if (!this.Pod.activeInHierarchy)
                this.CharacterAnimation["f02_" + this.AttackPrefix + "Recover" + this.SithPrefix + "_0" + this.SithCombo.ToString()].speed = 2f;
              else
                this.CharacterAnimation["f02_" + this.AttackPrefix + "Recover" + this.SithPrefix + "_0" + this.SithCombo.ToString()].speed = 0.5f;
              this.SithRecovering = true;
            }
          }
          else
          {
            if (Input.GetButtonDown("X") && this.SithComboLength < this.SithCombo + 1 && this.SithComboLength < 2)
              ++this.SithComboLength;
            if (Input.GetButtonDown("Y") && this.SithComboLength < this.SithCombo + 1 && this.SithComboLength < 2)
              ++this.SithComboLength;
          }
        }
        else if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Recover" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time >= (double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Recover" + this.SithPrefix + "_0" + this.SithCombo.ToString()].length || (double) this.h + (double) this.v != 0.0)
        {
          if (this.SithPrefix == "")
            this.LightSwordParticles.Play();
          else
            this.HeavySwordParticles.Play();
          this.HeavySword.GetComponent<WeaponTrail>().enabled = false;
          this.LightSword.GetComponent<WeaponTrail>().enabled = false;
          this.SithRecovering = false;
          this.SithAttacking = false;
          this.SithComboLength = 0;
          this.SithAttacks = 0;
          this.SithSounds = 0;
          this.SithCombo = 0;
          this.CanMove = true;
        }
      }
      if (this.Eating)
      {
        if ((double) Vector3.Distance(this.transform.position, this.TargetStudent.transform.position) > 0.5)
          this.transform.Translate(Vector3.forward * Time.deltaTime);
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if ((double) this.CharacterAnimation["f02_sixEat_00"].time > (double) this.BloodTimes[this.EatPhase])
        {
          Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.Mouth.position, Quaternion.identity).GetComponent<RandomStabScript>().Biting = true;
          this.Bloodiness += 20f;
          ++this.EatPhase;
        }
        if ((double) this.CharacterAnimation["f02_sixEat_00"].time >= (double) this.CharacterAnimation["f02_sixEat_00"].length)
        {
          if (!this.Kagune[0].activeInHierarchy && this.Hunger < 5)
          {
            this.CharacterAnimation["f02_sixRun_00"].speed += 0.1f;
            ++this.RunSpeed;
            ++this.Hunger;
            if (this.Hunger == 5)
            {
              this.RisingSmoke.SetActive(true);
              this.RunAnim = "f02_sixFastRun_00";
            }
          }
          Debug.Log((object) "Finished eating.");
          this.FollowHips = false;
          this.Attacking = false;
          this.CanMove = true;
          this.Eating = false;
          this.EatPhase = 0;
        }
      }
      if (this.Snapping)
      {
        if (this.SnapPhase == 0)
        {
          if (this.Gazing)
          {
            if ((double) this.CharacterAnimation["f02_gazerSnap_00"].time >= 0.800000011920929)
            {
              AudioSource.PlayClipAtPoint(this.FingerSnap, this.transform.position + Vector3.up);
              this.GazerEyes.ChangeEffect();
              ++this.SnapPhase;
            }
          }
          else if (this.WitchMode)
          {
            if ((double) this.CharacterAnimation["f02_fingerSnap_00"].time >= 1.0)
            {
              AudioSource.PlayClipAtPoint(this.FingerSnap, this.transform.position + Vector3.up);
              Object.Instantiate<GameObject>(this.KnifeArray, this.transform.position, this.transform.rotation).GetComponent<KnifeArrayScript>().GlobalKnifeArray = this.GlobalKnifeArray;
              ++this.SnapPhase;
            }
          }
          else if (this.ShotsFired < 1)
          {
            if ((double) this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.0)
            {
              Object.Instantiate<GameObject>(this.Shell, this.Guns[1].position, this.transform.rotation);
              ++this.ShotsFired;
            }
          }
          else if (this.ShotsFired < 2)
          {
            if ((double) this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.20000004768372)
            {
              Object.Instantiate<GameObject>(this.Shell, this.Guns[2].position, this.transform.rotation);
              ++this.ShotsFired;
            }
          }
          else if (this.ShotsFired < 3)
          {
            if ((double) this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.39999997615814)
            {
              Object.Instantiate<GameObject>(this.Shell, this.Guns[3].position, this.transform.rotation);
              ++this.ShotsFired;
            }
          }
          else if (this.ShotsFired < 4 && (double) this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.60000002384186)
          {
            Object.Instantiate<GameObject>(this.Shell, this.Guns[4].position, this.transform.rotation);
            ++this.ShotsFired;
            ++this.SnapPhase;
          }
        }
        else if (this.Gazing)
        {
          if ((double) this.CharacterAnimation["f02_gazerSnap_00"].time >= (double) this.CharacterAnimation["f02_gazerSnap_00"].length)
          {
            this.Snapping = false;
            this.CanMove = true;
            this.SnapPhase = 0;
          }
        }
        else if (this.WitchMode)
        {
          if ((double) this.CharacterAnimation["f02_fingerSnap_00"].time >= (double) this.CharacterAnimation["f02_fingerSnap_00"].length)
          {
            this.CharacterAnimation.Stop("f02_fingerSnap_00");
            this.Snapping = false;
            this.CanMove = true;
            this.SnapPhase = 0;
          }
        }
        else if ((double) this.CharacterAnimation["f02_shipGirlSnap_00"].time >= (double) this.CharacterAnimation["f02_shipGirlSnap_00"].length)
        {
          this.Snapping = false;
          this.CanMove = true;
          this.ShotsFired = 0;
          this.SnapPhase = 0;
        }
      }
      if (this.GazeAttacking)
      {
        if ((Object) this.TargetStudent != (Object) null)
        {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        }
        if (this.SnapPhase == 0)
        {
          if ((double) this.CharacterAnimation["f02_gazerPoint_00"].time >= 1.0)
          {
            AudioSource.PlayClipAtPoint(this.Zap, this.transform.position + Vector3.up);
            this.GazerEyes.Attack();
            ++this.SnapPhase;
          }
        }
        else if ((double) this.CharacterAnimation["f02_gazerPoint_00"].time >= (double) this.CharacterAnimation["f02_gazerPoint_00"].length)
        {
          this.GazerEyes.Attacking = false;
          this.GazeAttacking = false;
          this.CanMove = true;
          this.SnapPhase = 0;
        }
      }
      if (this.Finisher)
      {
        if ((double) this.CharacterAnimation["f02_banchoFinisher_00"].time >= (double) this.CharacterAnimation["f02_banchoFinisher_00"].length)
        {
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.Finisher = false;
          this.CanMove = true;
        }
        else if ((double) this.CharacterAnimation["f02_banchoFinisher_00"].time >= 1.66666662693024)
          this.BanchoFinisher.MyCollider.enabled = false;
        else if ((double) this.CharacterAnimation["f02_banchoFinisher_00"].time >= 0.833333313465118)
          this.BanchoFinisher.MyCollider.enabled = true;
      }
      if (this.ShootingBeam)
      {
        this.CharacterAnimation.CrossFade("f02_LoveLoveBeam_00");
        if ((double) this.CharacterAnimation["f02_LoveLoveBeam_00"].time >= 1.5 && this.BeamPhase == 0)
        {
          Object.Instantiate<GameObject>(this.LoveLoveBeam, this.transform.position, this.transform.rotation);
          ++this.BeamPhase;
        }
        if ((double) this.CharacterAnimation["f02_LoveLoveBeam_00"].time >= (double) this.CharacterAnimation["f02_LoveLoveBeam_00"].length - 1.0)
        {
          this.ShootingBeam = false;
          this.YandereTimer = 0.0f;
          this.CanMove = true;
          this.BeamPhase = 0;
        }
      }
      if (this.WritingName)
      {
        this.CharacterAnimation.CrossFade("f02_dramaticWriting_00");
        if ((double) this.CharacterAnimation["f02_dramaticWriting_00"].time == 0.0)
          AudioSource.PlayClipAtPoint(this.DramaticWriting, this.transform.position);
        if ((double) this.CharacterAnimation["f02_dramaticWriting_00"].time >= 5.0 && this.StudentManager.NoteWindow.TargetStudent > 0)
        {
          this.StudentManager.Students[this.StudentManager.NoteWindow.TargetStudent].Fate = this.StudentManager.NoteWindow.MeetID;
          this.StudentManager.Students[this.StudentManager.NoteWindow.TargetStudent].TimeOfDeath = this.StudentManager.NoteWindow.TimeID;
          this.StudentManager.NoteWindow.TargetStudent = 0;
        }
        if ((double) this.CharacterAnimation["f02_dramaticWriting_00"].time >= (double) this.CharacterAnimation["f02_dramaticWriting_00"].length)
        {
          this.CharacterAnimation[this.CarryAnims[10]].weight = 1f;
          this.CharacterAnimation["f02_dramaticWriting_00"].time = 0.0f;
          this.CharacterAnimation.Stop("f02_dramaticWriting_00");
          this.WritingName = false;
          this.CanMove = true;
        }
      }
      if (this.StoppingTime)
      {
        this.CharacterAnimation.CrossFade("f02_summonStand_00");
        if ((double) this.CharacterAnimation["f02_summonStand_00"].time >= 1.0)
        {
          if (this.Freezing)
          {
            if (!this.InvertSphere.gameObject.activeInHierarchy)
            {
              if ((Object) this.MyAudio.clip != (Object) this.ClockStop)
              {
                this.MyAudio.clip = this.ClockStop;
                this.MyAudio.volume = 1f;
                this.MyAudio.Play();
              }
              this.InvertSphere.gameObject.SetActive(true);
              this.PlayerOnlyCamera.SetActive(true);
              this.StudentManager.TimeFreeze();
            }
            this.InvertSphere.transform.localScale = Vector3.MoveTowards(this.InvertSphere.transform.localScale, new Vector3(0.2375f, 0.2375f, 0.0f), Time.deltaTime);
            this.MyAudio.volume = 1f;
            this.Jukebox.Ebola.pitch = Mathf.MoveTowards(this.Jukebox.Ebola.pitch, 0.2f, Time.deltaTime);
          }
          else
          {
            if ((Object) this.MyAudio.clip != (Object) this.ClockStart)
            {
              this.MyAudio.clip = this.ClockStart;
              this.MyAudio.volume = 1f;
              this.MyAudio.Play();
              this.StudentManager.TimeUnfreeze();
            }
            this.InvertSphere.transform.localScale = Vector3.MoveTowards(this.InvertSphere.transform.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime);
            this.MyAudio.volume = 1f;
            this.Jukebox.Ebola.pitch = Mathf.MoveTowards(this.Jukebox.Ebola.pitch, 1f, Time.deltaTime);
            this.GlobalKnifeArray.ActivateKnives();
          }
        }
        if ((double) this.CharacterAnimation["f02_summonStand_00"].time >= (double) this.CharacterAnimation["f02_summonStand_00"].length)
        {
          this.StoppingTime = false;
          this.CanMove = true;
          this.InvertSphere.gameObject.SetActive(this.Freezing);
          this.PlayerOnlyCamera.SetActive(this.Freezing);
        }
      }
      if (!this.Swiping)
        return;
      if ((double) this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].time >= (double) this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].length * 0.899999976158142)
      {
        this.Swiping = false;
        this.CanMove = true;
        this.Finisher = false;
      }
      else
      {
        if ((double) this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].time < (double) this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].length * 0.25 || this.Finisher)
          return;
        Object.Instantiate<GameObject>(this.DemonSlash, this.transform.position + this.transform.up + this.transform.forward * 2f, Quaternion.identity);
        this.Finisher = true;
      }
    }
  }

  private void UpdatePoisoning()
  {
    if (!this.Poisoning)
      return;
    if ((Object) this.PoisonSpot != (Object) null)
    {
      this.MoveTowardsTarget(this.PoisonSpot.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.PoisonSpot.rotation, Time.deltaTime * 10f);
    }
    else
    {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetBento.transform.position.x, this.transform.position.y, this.TargetBento.transform.position.z) - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
      this.MoveTowardsTarget(this.TargetBento.PoisonSpot.position);
    }
    if ((double) this.CharacterAnimation["f02_poisoning_00"].time >= (double) this.CharacterAnimation["f02_poisoning_00"].length)
    {
      this.CharacterAnimation["f02_poisoning_00"].speed = 1f;
      this.Poisons[this.PoisonType].SetActive(false);
      this.PoisonSpot = (Transform) null;
      this.Poisoning = false;
      this.CanMove = true;
    }
    else if ((double) this.CharacterAnimation["f02_poisoning_00"].time >= 5.25)
    {
      this.Poisons[this.PoisonType].SetActive(false);
    }
    else
    {
      if ((double) this.CharacterAnimation["f02_poisoning_00"].time < 0.75)
        return;
      this.Poisons[this.PoisonType].SetActive(true);
    }
  }

  private void UpdateEffects()
  {
    if (!this.Attacking && !this.DelinquentFighting && !this.Lost && this.CanMove)
    {
      if ((double) Vector3.Distance(this.transform.position, this.Senpai.position) < (double) this.SenpaiThreshold)
      {
        if (!this.Talking)
        {
          if (!this.NearSenpai && (double) this.StudentManager.Students[1].Pathfinding.speed < 7.5)
          {
            this.StudentManager.TutorialWindow.ShowSenpaiMessage = true;
            this.NearSenpai = true;
          }
          if (this.Laughing)
          {
            Debug.Log((object) "Yandere-chan was laughing, and is being told to stop laughing because UpdateEffects() was called.");
            this.StopLaughing();
            if ((Object) this.Pursuer != (Object) null)
              this.CanMove = false;
          }
          this.Stance.Current = StanceType.Standing;
          this.YandereVision = false;
          this.Mopping = false;
          this.Uncrouch();
          this.YandereTimer = 0.0f;
          this.EmptyHands();
          if (this.Aiming)
            this.StopAiming();
        }
      }
      else
        this.NearSenpai = false;
    }
    if (this.NearSenpai && !this.Noticed)
    {
      this.SenpaiFilter.enabled = true;
      this.SenpaiFilter.FadeFX = Mathf.Lerp(this.SenpaiFilter.FadeFX, 1f, Time.deltaTime * 10f);
      this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, 0.0f, Time.deltaTime * 10f);
      this.SenpaiTint = (float) (1.0 - (double) this.SenpaiFade / 100.0);
      int num = this.Attacking ? 1 : 0;
      this.SelectGrayscale.desaturation = Mathf.Lerp(this.SelectGrayscale.desaturation, 0.0f, Time.deltaTime * 10f);
      this.HeartBeat.volume = this.SenpaiTint;
      this.Sanity += Time.deltaTime * 10f;
      this.SenpaiTimer += Time.deltaTime;
      this.BeatTimer += Time.deltaTime;
      if ((double) this.BeatTimer > 60.0 / (double) this.HeartRate.BeatsPerMinute)
      {
        GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
        this.VibrationCheck = true;
        this.VibrationTimer = 0.1f;
        this.BeatTimer = 0.0f;
      }
      if ((double) this.SenpaiTimer > 10.0 && this.Creepiness < 5)
      {
        this.SenpaiTimer = 0.0f;
        ++this.Creepiness;
      }
    }
    else if ((double) this.SenpaiFade < 99.0)
    {
      this.SenpaiFilter.FadeFX = Mathf.Lerp(this.SenpaiFilter.FadeFX, 0.0f, Time.deltaTime * 10f);
      this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, 100f, Time.deltaTime * 10f);
      this.SenpaiTint = this.SenpaiFade / 100f;
      this.SelectGrayscale.desaturation = Mathf.Lerp(this.SelectGrayscale.desaturation, this.GreyTarget, Time.deltaTime * 10f);
      this.CharacterAnimation["f02_shy_00"].weight = 1f - this.SenpaiTint;
      for (int index = 1; index < 6; ++index)
      {
        this.CharacterAnimation[this.CreepyIdles[index]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[index]].weight, 0.0f, Time.deltaTime * 10f);
        this.CharacterAnimation[this.CreepyWalks[index]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[index]].weight, 0.0f, Time.deltaTime * 10f);
      }
      this.HeartBeat.volume = 1f - this.SenpaiTint;
    }
    else if ((double) this.SenpaiFade < 100.0)
      this.ResetSenpaiEffects();
    if (this.YandereVision)
    {
      if (!this.HighlightingR.enabled)
      {
        this.YandereFilter.enabled = true;
        this.HighlightingR.enabled = true;
        this.HighlightingB.enabled = true;
      }
      if (this.Stance.Current == StanceType.Standing)
      {
        if ((double) this.YandereVisionPanel.alpha == 0.0)
        {
          if (!this.StudentManager.Eighties)
          {
            this.Phone.transform.localPosition = new Vector3(-0.02f, -0.005f, 0.03f);
            this.Phone.transform.localEulerAngles = new Vector3(0.0f, 180f, 180f);
          }
          else
          {
            this.Phone.transform.localPosition = new Vector3(-0.015f, -3f / 500f, 0.015f);
            this.Phone.transform.localEulerAngles = new Vector3(-90f, -165f, 0.0f);
          }
          this.RightRedEye.material.color = new Color(1f, 1f, 1f, 1f);
          this.LeftRedEye.material.color = new Color(1f, 1f, 1f, 1f);
          this.RightYandereEye.material.color = new Color(1f, 1f, 1f, 0.0f);
          this.LeftYandereEye.material.color = new Color(1f, 1f, 1f, 0.0f);
          this.SenpaiShotLabel.text = this.Inventory.SenpaiShots > 0 || this.StudentManager.MissionMode || this.StudentManager.Eighties ? "Speed Up Time" : "Speed Up Time (Requires Photo of Senpai)";
          this.UpdateConcealedWeaponStatus();
        }
        this.YandereVisionPanel.alpha = Mathf.MoveTowards(this.YandereVisionPanel.alpha, 1f, Time.unscaledDeltaTime * 10f);
      }
      else
      {
        this.YandereVisionPanel.alpha = Mathf.MoveTowards(this.YandereVisionPanel.alpha, 0.0f, Time.unscaledDeltaTime * 10f);
        this.SenpaiGazing = false;
      }
      if ((double) this.YandereVisionPanel.alpha == 1.0 & (this.Inventory.SenpaiShots > 0 || this.StudentManager.MissionMode || this.StudentManager.Eighties) && (Object) this.PickUp == (Object) null && !this.Armed && !this.Carrying && !this.Dragging)
      {
        this.SenpaiShotLabel.text = "Speed Up Time";
        if (Input.GetButtonDown("A"))
          this.SenpaiGazing = !this.SenpaiGazing;
      }
      else
      {
        if ((Object) this.PickUp != (Object) null || this.Armed || this.Carrying || this.Dragging)
          this.SenpaiShotLabel.text = "Speed Up Time (Empty Hands First)";
        this.SenpaiGazing = false;
      }
      if (this.SenpaiGazing)
      {
        this.Phone.SetActive(true);
        this.CharacterAnimation["f02_phonePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_phonePose_00"].weight, 1f, Time.unscaledDeltaTime * 10f);
        Time.timeScale = Mathf.Lerp(Time.timeScale, 2f, Time.unscaledDeltaTime * 10f);
      }
      else
      {
        this.Phone.SetActive(false);
        this.CharacterAnimation["f02_phonePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_phonePose_00"].weight, 0.0f, Time.unscaledDeltaTime * 10f);
        Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, Time.unscaledDeltaTime * 10f);
      }
      this.YandereFilter.FadeFX = Mathf.Lerp(this.YandereFilter.FadeFX, 1f, Time.unscaledDeltaTime * 10f);
      this.YandereFade = Mathf.Lerp(this.YandereFade, 0.0f, Time.unscaledDeltaTime * 10f);
      this.YandereTint = (float) (1.0 - (double) this.YandereFade / 100.0);
      this.CameraEffects.UpdateVignette(this.YandereFilter.FadeFX);
      if ((Object) this.StudentManager.Tag.Target != (Object) null)
        this.StudentManager.Tag.Sprite.color = new Color(1f, 0.0f, 0.0f, Mathf.Lerp(this.StudentManager.Tag.Sprite.color.a, 1f, Time.unscaledDeltaTime * 10f));
      if ((Object) this.StudentManager.Students[this.StudentManager.RivalID] != (Object) null)
        this.StudentManager.RedString.gameObject.SetActive(true);
      if (this.CanMove && !this.Carrying && !this.Dragging && (double) this.YandereVisionPanel.alpha == 1.0)
      {
        if ((double) this.SneakShotLabel.alpha == 1.0 && Input.GetButtonDown("B"))
        {
          this.EmptyHands();
          this.YandereVision = false;
          this.SneakingShot = true;
          this.CanMove = false;
          this.Lewd = true;
        }
        else if ((double) this.ConcealedWeaponLabel.alpha == 1.0 && Input.GetButtonDown("Y"))
        {
          if ((Object) this.Container.TrashCan.Item != (Object) null)
          {
            if ((Object) this.Container.TrashCan.ConcealedWeapon != (Object) null)
            {
              WeaponScript concealedWeapon = this.Container.TrashCan.ConcealedWeapon;
            }
            this.CharacterAnimation["f02_reachForWeapon_00"].time = 0.0f;
            this.ReachWeight = 1f;
            this.Container.TrashCan.RemoveContents();
          }
          else if (this.Armed)
          {
            this.Container.TrashCan.StashItem();
            this.UpdateConcealedWeaponStatus();
          }
        }
      }
      if (!this.Chased)
        return;
      this.ResetYandereEffects();
    }
    else
    {
      if (this.HighlightingR.enabled)
      {
        this.HighlightingR.enabled = false;
        this.HighlightingB.enabled = false;
      }
      if ((double) this.YandereFade < 99.0)
      {
        if (!this.Aiming)
          Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.unscaledDeltaTime * 10f);
        this.Phone.SetActive(false);
        this.CharacterAnimation["f02_phonePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_phonePose_00"].weight, 0.0f, Time.unscaledDeltaTime * 10f);
        this.YandereVisionPanel.alpha = Mathf.Lerp(this.YandereVisionPanel.alpha, 0.0f, Time.unscaledDeltaTime * 10f);
        this.YandereFilter.FadeFX = Mathf.Lerp(this.YandereFilter.FadeFX, 0.0f, Time.unscaledDeltaTime * 10f);
        this.YandereFade = Mathf.Lerp(this.YandereFade, 100f, Time.unscaledDeltaTime * 10f);
        this.YandereTint = this.YandereFade / 100f;
        this.CameraEffects.UpdateVignette((float) (1.0 - (double) this.Sanity * 0.00999999977648258));
        this.StudentManager.Tag.Sprite.color = new Color(1f, 0.0f, 0.0f, Mathf.Lerp(this.StudentManager.Tag.Sprite.color.a, 0.0f, Time.unscaledDeltaTime * 10f));
        this.StudentManager.RedString.gameObject.SetActive(false);
        this.RightRedEye.material.color = new Color(this.RightRedEye.material.color.r, this.RightRedEye.material.color.g, this.RightRedEye.material.color.b, (float) (1.0 - (double) this.YandereFade / 100.0));
        this.LeftRedEye.material.color = new Color(this.LeftRedEye.material.color.r, this.LeftRedEye.material.color.g, this.LeftRedEye.material.color.b, (float) (1.0 - (double) this.YandereFade / 100.0));
        this.RightYandereEye.material.color = new Color(this.RightYandereEye.material.color.r, this.YandereFade / 100f, this.YandereFade / 100f, this.RightYandereEye.material.color.a);
        this.LeftYandereEye.material.color = new Color(this.LeftYandereEye.material.color.r, this.YandereFade / 100f, this.YandereFade / 100f, this.LeftYandereEye.material.color.a);
      }
      else
      {
        if ((double) this.YandereFade >= 100.0)
          return;
        this.ResetYandereEffects();
      }
    }
  }

  private void UpdateTalking()
  {
    if (!this.Talking)
      return;
    if ((Object) this.TargetStudent != (Object) null)
    {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
      if ((double) Vector3.Distance(this.transform.position, this.TargetStudent.transform.position) < 0.75)
      {
        int num = (int) this.MyController.Move(this.transform.forward * Time.deltaTime * -1f);
        this.CameraEffects.UpdateDOF(Vector3.Distance(this.transform.position, this.TargetStudent.transform.position) + 0.1f);
      }
    }
    if (this.Interaction == YandereInteractionType.Idle)
    {
      if (!((Object) this.TargetStudent != (Object) null) || this.TargetStudent.Counselor)
        return;
      this.CharacterAnimation.CrossFade(this.IdleAnim);
    }
    else if (this.Interaction == YandereInteractionType.Apologizing)
    {
      if ((double) this.TalkTimer == 10.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_00");
        if (this.TargetStudent.Witnessed == StudentWitnessType.Insanity || this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity || this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndInsanity || this.TargetStudent.Witnessed == StudentWitnessType.BloodAndInsanity)
          this.Subtitle.UpdateLabel(SubtitleType.InsanityApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndBlood)
          this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Weapon)
          this.Subtitle.UpdateLabel(SubtitleType.WeaponApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Blood)
          this.Subtitle.UpdateLabel(SubtitleType.BloodApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Lewd)
          this.Subtitle.UpdateLabel(SubtitleType.LewdApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Accident)
          this.Subtitle.UpdateLabel(SubtitleType.AccidentApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Suspicious)
          this.Subtitle.UpdateLabel(SubtitleType.SuspiciousApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Eavesdropping)
          this.Subtitle.UpdateLabel(SubtitleType.EavesdropApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Theft)
          this.Subtitle.UpdateLabel(SubtitleType.TheftApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Violence)
          this.Subtitle.UpdateLabel(SubtitleType.ViolenceApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Pickpocketing)
          this.Subtitle.UpdateLabel(SubtitleType.PickpocketApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.CleaningItem)
          this.Subtitle.UpdateLabel(SubtitleType.CleaningApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Poisoning)
          this.Subtitle.UpdateLabel(SubtitleType.PoisonApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.HoldingBloodyClothing)
          this.Subtitle.UpdateLabel(SubtitleType.HoldingBloodyClothingApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Trespassing)
          this.Subtitle.UpdateLabel(SubtitleType.TrespassApology, 0, 10f);
        else if (this.TargetStudent.Witnessed == StudentWitnessType.Tutorial)
          this.Subtitle.UpdateLabel(SubtitleType.TutorialApology, 0, 10f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_greet_00"].time >= (double) this.CharacterAnimation["f02_greet_00"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.Forgiving;
          this.TargetStudent.TalkTimer = 3f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.Compliment)
    {
      if ((double) this.TalkTimer == 5.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_01");
        this.Subtitle.CustomText = this.TargetStudent.DialogueWheel.TopicInterface.Statement;
        this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_greet_01"].time >= (double) this.CharacterAnimation["f02_greet_01"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.ReceivingCompliment;
          this.TargetStudent.TalkTimer = 3f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.Gossip)
    {
      if ((double) this.TalkTimer == 5.0)
      {
        this.CharacterAnimation.CrossFade("f02_lookdown_00");
        this.Subtitle.CustomText = this.TargetStudent.DialogueWheel.TopicInterface.Statement;
        this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_lookdown_00"].time >= (double) this.CharacterAnimation["f02_lookdown_00"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.Gossiping;
          this.TargetStudent.TalkTimer = 3f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.Bye)
    {
      if ((double) this.TalkTimer == 2.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_00");
        this.Subtitle.UpdateLabel(SubtitleType.PlayerFarewell, 0, 2f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_greet_00"].time >= (double) this.CharacterAnimation["f02_greet_00"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.Bye;
          this.TargetStudent.TalkTimer = 2f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.FollowMe)
    {
      int ID = 0;
      if (this.Club == ClubType.Delinquent)
        ++ID;
      if ((double) this.TalkTimer == 3.0)
      {
        this.TalkAnim = this.Club != ClubType.Delinquent ? "f02_greet_01" : "f02_delinquentGesture_01";
        this.CharacterAnimation.CrossFade(this.TalkAnim);
        this.Subtitle.UpdateLabel(SubtitleType.PlayerFollow, ID, 3f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation[this.TalkAnim].time >= (double) this.CharacterAnimation[this.TalkAnim].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.FollowingPlayer;
          this.TargetStudent.TalkTimer = 2f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.GoAway)
    {
      int ID = 0;
      if (this.Club == ClubType.Delinquent)
        ++ID;
      if ((double) this.TalkTimer == 3.0)
      {
        this.TalkAnim = this.Club != ClubType.Delinquent ? "f02_lookdown_00" : "f02_delinquentGesture_01";
        this.CharacterAnimation.CrossFade(this.TalkAnim);
        this.Subtitle.UpdateLabel(SubtitleType.PlayerLeave, ID, 3f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation[this.TalkAnim].time >= (double) this.CharacterAnimation[this.TalkAnim].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.GoingAway;
          this.TargetStudent.TalkTimer = 3f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.DistractThem)
    {
      int ID = 0;
      if (this.Club == ClubType.Delinquent || this.StudentManager.Eighties)
        ++ID;
      if ((double) this.TalkTimer == 3.0)
      {
        this.TalkAnim = this.Club != ClubType.Delinquent ? "f02_lookdown_00" : "f02_delinquentGesture_01";
        this.CharacterAnimation.CrossFade(this.TalkAnim);
        this.Subtitle.UpdateLabel(SubtitleType.PlayerDistract, ID, 3f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation[this.TalkAnim].time >= (double) this.CharacterAnimation[this.TalkAnim].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.DistractingTarget;
          this.TargetStudent.TalkTimer = 3f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.NamingCrush)
    {
      if ((double) this.TalkTimer == 3.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_01");
        this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 0, 3f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_greet_01"].time >= (double) this.CharacterAnimation["f02_greet_01"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.NamingCrush;
          this.TargetStudent.TalkTimer = 3f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.ChangingAppearance)
    {
      if ((double) this.TalkTimer == 3.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_01");
        this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 2, 3f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_greet_01"].time >= (double) this.CharacterAnimation["f02_greet_01"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.ChangingAppearance;
          this.TargetStudent.TalkTimer = 3f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.Court)
    {
      if ((double) this.TalkTimer == 5.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_01");
        if (!this.TargetStudent.Male)
          this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 3, 5f);
        else
          this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 4, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_greet_01"].time >= (double) this.CharacterAnimation["f02_greet_01"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.Court;
          this.TargetStudent.TalkTimer = 3f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.Advice)
    {
      if ((double) this.TalkTimer == 5.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_01");
        this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 5, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_greet_01"].time >= (double) this.CharacterAnimation["f02_greet_01"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.Advice;
          this.TargetStudent.TalkTimer = 5f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.TaskInquiry)
    {
      if ((double) this.TalkTimer == 3.0 || (double) this.TalkTimer == 5.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_01");
        if (this.TargetStudent.Club == ClubType.Bully)
          this.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 0, 5f);
        else if (this.TargetStudent.StudentID == 10)
          this.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 6, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_greet_01"].time >= (double) this.CharacterAnimation["f02_greet_01"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          Debug.Log((object) "Telling student to respond to task inquiry.");
          this.TargetStudent.Interaction = StudentInteractionType.TaskInquiry;
          this.TargetStudent.TalkTimer = 10f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.GivingSnack)
    {
      if ((double) this.TalkTimer == 3.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_01");
        this.Subtitle.UpdateLabel(SubtitleType.OfferSnack, 0, 3f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.CharacterAnimation["f02_greet_01"].time >= (double) this.CharacterAnimation["f02_greet_01"].length)
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.TakingSnack;
          this.TargetStudent.TalkTimer = 5f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else if (this.Interaction == YandereInteractionType.AskingForHelp)
    {
      if ((double) this.TalkTimer == 5.0)
      {
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        this.Subtitle.UpdateLabel(SubtitleType.AskForHelp, 0, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.GivingHelp;
          this.TargetStudent.TalkTimer = 4f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
    else
    {
      if (this.Interaction != YandereInteractionType.SendingToLocker)
        return;
      if ((double) this.TalkTimer == 5.0)
      {
        this.CharacterAnimation.CrossFade("f02_greet_01");
        this.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 0, 5f);
      }
      else
      {
        if (Input.GetButtonDown("A"))
          this.TalkTimer = 0.0f;
        if ((double) this.TalkTimer <= 0.0)
        {
          this.TargetStudent.Interaction = StudentInteractionType.SentToLocker;
          this.TargetStudent.TalkTimer = 5f;
          this.Interaction = YandereInteractionType.Idle;
        }
      }
      this.TalkTimer -= Time.deltaTime;
    }
  }

  private void UpdateAttacking()
  {
    if (!this.Attacking)
      return;
    if ((Object) this.TargetStudent != (Object) null)
    {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, this.transform.position.y, this.TargetStudent.transform.position.z) - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
    }
    if (this.Drown)
    {
      this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * -0.0001f);
      this.CharacterAnimation.CrossFade(this.DrownAnim);
      if ((double) this.CharacterAnimation[this.DrownAnim].time <= (double) this.CharacterAnimation[this.DrownAnim].length)
        return;
      this.TargetStudent.DeathType = DeathType.Drowning;
      this.Attacking = false;
      if (!this.Noticed)
        this.CanMove = true;
      this.Drown = false;
      this.Sanity -= (PlayerGlobals.PantiesEquipped == 10 ? 10f : 20f) * this.Numbness;
    }
    else if (this.RoofPush)
    {
      this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, this.transform.position.y + 1f, this.Hips.position.z), Time.deltaTime * 10f);
      this.MoveTowardsTarget(this.TargetStudent.transform.position - this.TargetStudent.transform.forward);
      this.CharacterAnimation.CrossFade("f02_roofPushA_00");
      if ((double) this.CharacterAnimation["f02_roofPushA_00"].time > 4.33333349227905)
      {
        if (this.Shoes[0].activeInHierarchy)
        {
          Object.Instantiate<GameObject>(this.ShoePair, this.transform.position + new Vector3(0.0f, 0.045f, 0.0f) + this.transform.forward * 1.6f, Quaternion.identity).transform.eulerAngles = this.transform.eulerAngles;
          this.Shoes[0].SetActive(false);
          this.Shoes[1].SetActive(false);
        }
      }
      else if ((double) this.CharacterAnimation["f02_roofPushA_00"].time > 2.16666674613953 && this.TargetStudent.Schoolwear == 1 && !this.TargetStudent.ClubAttire && !this.Shoes[0].activeInHierarchy)
      {
        this.TargetStudent.RemoveShoes();
        this.Shoes[0].SetActive(true);
        this.Shoes[1].SetActive(true);
      }
      if ((double) this.CharacterAnimation["f02_roofPushA_00"].time > (this.TargetStudent.Schoolwear != 1 || this.TargetStudent.ClubAttire ? 3.5 : (double) this.CharacterAnimation["f02_roofPushA_00"].length))
      {
        this.CameraTarget.localPosition = new Vector3(0.0f, 1f, 0.0f);
        this.TargetStudent.DeathType = DeathType.Falling;
        this.SplashCamera.transform.parent = (Transform) null;
        this.Attacking = false;
        this.RoofPush = false;
        this.CanMove = true;
        this.Sanity -= 20f * this.Numbness;
      }
      if (!Input.GetButtonDown("B"))
        return;
      this.SplashCamera.transform.parent = this.transform;
      this.SplashCamera.transform.localPosition = new Vector3(2f, -10.65f, 4.775f);
      this.SplashCamera.transform.localEulerAngles = new Vector3(0.0f, -135f, 0.0f);
      this.SplashCamera.Show = true;
      this.SplashCamera.MyCamera.enabled = true;
    }
    else if (this.TargetStudent.Teacher)
    {
      this.CharacterAnimation.CrossFade("f02_teacherCounterA_00");
      if ((Object) this.EquippedWeapon != (Object) null)
        this.EquippedWeapon.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
      this.Character.transform.position = new Vector3(this.Character.transform.position.x, this.TargetStudent.transform.position.y, this.Character.transform.position.z);
    }
    else
    {
      if (this.SanityBased)
        return;
      if (this.EquippedWeapon.WeaponID == 27)
        Debug.Log((object) "Well, uh, we're killing with a garrote...");
      else if (this.EquippedWeapon.WeaponID == 11)
      {
        this.CharacterAnimation.CrossFade("CyborgNinja_Slash");
        if ((double) this.CharacterAnimation["CyborgNinja_Slash"].time == 0.0)
        {
          this.TargetStudent.CharacterAnimation[this.TargetStudent.PhoneAnim].weight = 0.0f;
          this.EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
        }
        if ((double) this.CharacterAnimation["CyborgNinja_Slash"].time < (double) this.CharacterAnimation["CyborgNinja_Slash"].length)
          return;
        this.Bloodiness += 20f;
        this.StainWeapon();
        this.CharacterAnimation["CyborgNinja_Slash"].time = 0.0f;
        this.CharacterAnimation.Stop("CyborgNinja_Slash");
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        this.Attacking = false;
        if (!this.Noticed)
          this.CanMove = true;
        else
          this.EquippedWeapon.Drop();
      }
      else if (this.EquippedWeapon.WeaponID == 7)
      {
        this.CharacterAnimation.CrossFade("f02_buzzSawKill_A_00");
        if ((double) this.CharacterAnimation["f02_buzzSawKill_A_00"].time == 0.0)
        {
          this.TargetStudent.CharacterAnimation[this.TargetStudent.PhoneAnim].weight = 0.0f;
          this.EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
        }
        if (this.AttackPhase == 1)
        {
          if ((double) this.CharacterAnimation["f02_buzzSawKill_A_00"].time > 0.333333343267441)
          {
            this.TargetStudent.LiquidProjector.enabled = true;
            this.EquippedWeapon.Effect();
            this.StainWeapon();
            this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[1];
            this.Bloodiness += 20f;
            ++this.AttackPhase;
          }
        }
        else if (this.AttackPhase < 6 && (double) this.CharacterAnimation["f02_buzzSawKill_A_00"].time > 0.333333343267441 * (double) this.AttackPhase)
        {
          this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[this.AttackPhase];
          this.Bloodiness += 20f;
          ++this.AttackPhase;
        }
        if ((double) this.CharacterAnimation["f02_buzzSawKill_A_00"].time <= (double) this.CharacterAnimation["f02_buzzSawKill_A_00"].length)
          return;
        if ((Object) this.TargetStudent == (Object) this.StudentManager.Reporter)
          this.StudentManager.Reporter = (StudentScript) null;
        this.CharacterAnimation["f02_buzzSawKill_A_00"].time = 0.0f;
        this.CharacterAnimation.Stop("f02_buzzSawKill_A_00");
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        this.MyController.radius = 0.2f;
        this.Attacking = false;
        this.AttackPhase = 1;
        this.Sanity -= 20f * this.Numbness;
        this.TargetStudent.DeathType = DeathType.Weapon;
        this.TargetStudent.BecomeRagdoll();
        if (!this.Noticed)
          this.CanMove = true;
        else
          this.EquippedWeapon.Drop();
      }
      else if (!this.EquippedWeapon.Concealable)
      {
        if (this.AttackPhase == 1)
        {
          this.CharacterAnimation.CrossFade("f02_swingA_00");
          if ((double) this.CharacterAnimation["f02_swingA_00"].time <= (double) this.CharacterAnimation["f02_swingA_00"].length * 0.300000011920929)
            return;
          if ((Object) this.TargetStudent == (Object) this.StudentManager.Reporter)
            this.StudentManager.Reporter = (StudentScript) null;
          Object.Destroy((Object) this.TargetStudent.DeathScream);
          this.EquippedWeapon.Effect();
          this.AttackPhase = 2;
          this.Bloodiness += 20f;
          this.StainWeapon();
          this.Sanity -= 20f * this.Numbness;
        }
        else
        {
          if ((double) this.CharacterAnimation["f02_swingA_00"].time < (double) this.CharacterAnimation["f02_swingA_00"].length * 0.899999976158142)
            return;
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.TargetStudent.DeathType = DeathType.Weapon;
          this.TargetStudent.BecomeRagdoll();
          this.MyController.radius = 0.2f;
          this.Attacking = false;
          this.AttackPhase = 1;
          this.AttackTimer = 0.0f;
          if (!this.Noticed)
            this.CanMove = true;
          else
            this.EquippedWeapon.Drop();
        }
      }
      else if (this.AttackPhase == 1)
      {
        this.CharacterAnimation.CrossFade("f02_stab_00");
        if ((double) this.CharacterAnimation["f02_stab_00"].time <= (double) this.CharacterAnimation["f02_stab_00"].length * 0.349999994039536)
          return;
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        if (this.EquippedWeapon.Flaming)
        {
          this.Egg = true;
          this.TargetStudent.Combust();
        }
        else if (this.CanTranq && !this.TargetStudent.Male && this.TargetStudent.Club != ClubType.Council)
        {
          this.TargetStudent.Tranquil = true;
          this.CanTranq = false;
          this.Follower = (StudentScript) null;
          --this.Followers;
        }
        else
        {
          this.TargetStudent.BloodSpray.SetActive(true);
          this.TargetStudent.DeathType = DeathType.Weapon;
          this.Bloodiness += 20f;
        }
        if ((Object) this.TargetStudent == (Object) this.StudentManager.Reporter)
          this.StudentManager.Reporter = (StudentScript) null;
        AudioSource.PlayClipAtPoint(this.Stabs[Random.Range(0, this.Stabs.Length)], this.transform.position + Vector3.up);
        this.AttackPhase = 2;
        this.Sanity -= 20f * this.Numbness;
        if (this.EquippedWeapon.WeaponID != 8)
          return;
        this.TargetStudent.Ragdoll.Sacrifice = true;
        if (!GameGlobals.Paranormal)
          return;
        this.EquippedWeapon.Effect();
      }
      else
      {
        this.AttackTimer += Time.deltaTime;
        if ((double) this.AttackTimer <= 0.300000011920929)
          return;
        if (!this.CanTranq)
          this.StainWeapon();
        this.MyController.radius = 0.2f;
        this.SanityBased = true;
        this.Attacking = false;
        this.AttackPhase = 1;
        this.AttackTimer = 0.0f;
        if (!this.Noticed)
          this.CanMove = true;
        else
          this.EquippedWeapon.Drop();
      }
    }
  }

  public void UpdateSlouch()
  {
    if (this.FloppyHat.activeInHierarchy)
      return;
    if (this.CanMove && !this.Attacking && !this.Dragging && (Object) this.PickUp == (Object) null && !this.Aiming && this.Stance.Current != StanceType.Crawling && !this.Possessed && !this.Carrying && !this.CirnoWings.activeInHierarchy && (double) this.LaughIntensity < 16.0)
    {
      this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, (float) (1.0 - (double) this.Sanity / 100.0), Time.deltaTime * 10f);
      if (this.Hairstyle == 2 && this.Stance.Current == StanceType.Crouching)
        this.Slouch = Mathf.Lerp(this.Slouch, 0.0f, Time.deltaTime * 20f);
      else
        this.Slouch = Mathf.Lerp(this.Slouch, (float) (5.0 * (1.0 - (double) this.Sanity / 100.0)), Time.deltaTime * 10f);
    }
    else
    {
      this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 0.0f, Time.deltaTime * 10f);
      this.Slouch = Mathf.Lerp(this.Slouch, 0.0f, Time.deltaTime * 10f);
    }
  }

  private void UpdateTwitch()
  {
    if ((double) this.Sanity >= 100.0)
      return;
    this.TwitchTimer += Time.deltaTime;
    if ((double) this.TwitchTimer > (double) this.NextTwitch)
    {
      this.Twitch = new Vector3((float) (1.0 - (double) this.Sanity / 100.0) * Random.Range(-10f, 10f), (float) (1.0 - (double) this.Sanity / 100.0) * Random.Range(-10f, 10f), (float) (1.0 - (double) this.Sanity / 100.0) * Random.Range(-10f, 10f));
      this.NextTwitch = Random.Range(0.0f, 1f);
      this.TwitchTimer = 0.0f;
    }
    this.Twitch = Vector3.Lerp(this.Twitch, Vector3.zero, Time.deltaTime * 10f);
  }

  private void UpdateWarnings()
  {
    if (this.NearBodies > 0)
    {
      if (!this.CorpseWarning)
      {
        this.NotificationManager.DisplayNotification(NotificationType.Body);
        this.StudentManager.UpdateStudents();
        this.CorpseWarning = true;
      }
    }
    else if (this.CorpseWarning)
    {
      this.StudentManager.UpdateStudents();
      this.CorpseWarning = false;
    }
    if (this.Eavesdropping)
    {
      if (!this.EavesdropWarning)
      {
        this.NotificationManager.DisplayNotification(NotificationType.Eavesdropping);
        this.EavesdropWarning = true;
      }
    }
    else if (this.EavesdropWarning)
      this.EavesdropWarning = false;
    if (!this.ClothingWarning)
      return;
    this.ClothingTimer += Time.deltaTime;
    if ((double) this.ClothingTimer <= 1.0)
      return;
    this.ClothingWarning = false;
    this.ClothingTimer = 0.0f;
  }

  private void UpdateDebugFunctionality()
  {
    if (!this.EasterEggMenu.activeInHierarchy && !this.DebugMenu.activeInHierarchy)
    {
      if (Input.GetKeyDown(KeyCode.P))
      {
        this.CyborgParts[1].SetActive(false);
        this.MemeGlasses.SetActive(false);
        this.KONGlasses.SetActive(false);
        this.EyepatchR.SetActive(false);
        this.EyepatchL.SetActive(false);
        ++this.EyewearID;
        if (this.EyewearID == 1)
          this.EyepatchR.SetActive(true);
        else if (this.EyewearID == 2)
          this.EyepatchL.SetActive(true);
        else if (this.EyewearID == 3)
        {
          this.EyepatchR.SetActive(true);
          this.EyepatchL.SetActive(true);
        }
        else if (this.EyewearID == 4)
          this.KONGlasses.SetActive(true);
        else if (this.EyewearID == 5)
          this.MemeGlasses.SetActive(true);
        else if (this.EyewearID == 6)
        {
          if (this.CyborgParts[2].activeInHierarchy)
            this.CyborgParts[1].SetActive(true);
          else
            this.EyewearID = 0;
        }
        else
          this.EyewearID = 0;
      }
      if (Input.GetKeyDown(KeyCode.H))
      {
        if (Input.GetButton("LB"))
          this.Hairstyle += 10;
        else
          ++this.Hairstyle;
        this.UpdateHair();
      }
      if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.LeftArrow))
      {
        --this.Hairstyle;
        this.UpdateHair();
      }
      if (Input.GetKeyDown(KeyCode.O) && !this.EasterEggMenu.activeInHierarchy)
      {
        if (this.AccessoryID > 0)
          this.Accessories[this.AccessoryID].SetActive(false);
        if (Input.GetButton("LB"))
          this.AccessoryID += 10;
        else
          ++this.AccessoryID;
        this.UpdateAccessory();
      }
      if (Input.GetKey(KeyCode.O) && Input.GetKeyDown(KeyCode.LeftArrow))
      {
        if (this.AccessoryID > 0)
          this.Accessories[this.AccessoryID].SetActive(false);
        --this.AccessoryID;
        this.UpdateAccessory();
      }
      if (Input.GetKeyDown("-"))
      {
        if ((double) Time.timeScale < 6.0)
          Time.timeScale = 1f;
        else
          Time.timeScale -= 5f;
      }
      if (Input.GetKeyDown("="))
      {
        if ((double) Time.timeScale < 5.0)
        {
          Time.timeScale = 5f;
        }
        else
        {
          Time.timeScale += 5f;
          if ((double) Time.timeScale > 25.0)
            Time.timeScale = 25f;
        }
      }
      if (Input.GetKey(KeyCode.Period))
      {
        this.BreastSize += Time.deltaTime;
        if ((double) this.BreastSize > 2.0)
          this.BreastSize = 2f;
        this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
        this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      }
      if (Input.GetKey(KeyCode.Comma))
      {
        this.BreastSize -= Time.deltaTime;
        if ((double) this.BreastSize < 0.5)
          this.BreastSize = 0.5f;
        this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
        this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      }
    }
    if (this.CanMove)
    {
      if (!this.Egg || this.EggBypass > 8)
      {
        if ((double) this.transform.position.y < 1000.0)
        {
          if (Input.GetKeyDown(KeyCode.Slash))
          {
            this.DebugMenu.SetActive(false);
            this.EasterEggMenu.SetActive(!this.EasterEggMenu.activeInHierarchy);
          }
          if (this.EasterEggMenu.activeInHierarchy)
          {
            if (Input.GetKeyDown(KeyCode.P))
              this.Punish();
            else if (Input.GetKeyDown(KeyCode.Z))
              this.Slend();
            else if (Input.GetKeyDown(KeyCode.B))
              this.Bancho();
            else if (Input.GetKeyDown(KeyCode.C))
              this.Cirno();
            else if (Input.GetKeyDown(KeyCode.H))
            {
              this.EmptyHands();
              this.Hate();
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
              this.StudentManager.AttackOnTitan();
              this.AttackOnTitan();
            }
            else if (Input.GetKeyDown(KeyCode.G))
              this.GaloSengen();
            else if (!Input.GetKeyDown(KeyCode.J))
            {
              if (Input.GetKeyDown(KeyCode.K))
              {
                this.EasterEggMenu.SetActive(false);
                this.StudentManager.Kong();
                this.DK = true;
              }
              else if (Input.GetKeyDown(KeyCode.L))
                this.Agent();
              else if (!Input.GetKeyDown(KeyCode.N))
              {
                if (Input.GetKeyDown(KeyCode.S))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Egg = true;
                  this.StudentManager.Spook();
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Falcon();
                }
                else if (Input.GetKeyDown(KeyCode.X))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.X();
                }
                else if (Input.GetKeyDown(KeyCode.O))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Punch();
                }
                else if (Input.GetKeyDown(KeyCode.U))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.BadTime();
                }
                else if (Input.GetKeyDown(KeyCode.Y))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.CyborgNinja();
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Ebola();
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Samus();
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Witch();
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Pose();
                }
                else if (Input.GetKeyDown(KeyCode.V))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Vaporwave();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.HairBlades();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Tornado();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.GenderSwap();
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.HollowMode();
                }
                else if (Input.GetKeyDown(KeyCode.I))
                {
                  this.StudentManager.NoGravity = true;
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Sith();
                }
                else if (Input.GetKeyDown(KeyCode.M))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Snake();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Gazer();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                  this.StudentManager.SecurityCameras();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                  this.KLK();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                  this.EasterEggMenu.SetActive(false);
                  this.Six();
                }
                else if (Input.GetKeyDown(KeyCode.F1))
                {
                  this.Weather();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F2))
                {
                  this.Horror();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F3))
                {
                  this.LifeNote();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F4))
                {
                  this.Mandere();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F5))
                {
                  this.BlackHoleChan();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F6))
                {
                  this.ElfenLied();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F7))
                {
                  this.Berserk();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F8))
                {
                  this.Nier();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F9))
                {
                  this.Ghoul();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F10))
                {
                  this.CinematicCameraFilters.enabled = true;
                  this.CameraFilters.enabled = true;
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F11))
                {
                  this.GarbageMode();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.F12))
                {
                  this.TallMode();
                  this.EasterEggMenu.SetActive(false);
                }
                else if (!Input.GetKeyDown(KeyCode.ScrollLock) && Input.GetKeyDown(KeyCode.Space))
                  this.EasterEggMenu.SetActive(false);
              }
            }
          }
        }
      }
      else if (Input.GetKeyDown(KeyCode.Slash))
        ++this.EggBypass;
    }
    else if (Input.GetKeyDown(KeyCode.Z))
      this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
    this.DebugTimer = Mathf.MoveTowards(this.DebugTimer, 0.0f, Time.deltaTime);
  }

  private void LateUpdate()
  {
    if (this.VibrationCheck)
    {
      this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0.0f, Time.deltaTime);
      if ((double) this.VibrationTimer == 0.0)
      {
        GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
        this.VibrationCheck = false;
      }
    }
    this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.02f);
    this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.02f);
    this.LeftEye.localScale = new Vector3(1f - this.EyeShrink, 1f - this.EyeShrink, this.LeftEye.localScale.z);
    this.RightEye.localScale = new Vector3(1f - this.EyeShrink, 1f - this.EyeShrink, this.RightEye.localScale.z);
    for (this.ID = 0; this.ID < this.Spine.Length; ++this.ID)
    {
      Transform transform = this.Spine[this.ID].transform;
      transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + this.Slouch, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
    if (this.Aiming)
    {
      float num = 1f;
      if (this.Selfie)
        num = -1f;
      Transform transform = this.Spine[3].transform;
      transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - this.Bend * num, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
    float num1 = 1f;
    if (this.Stance.Current == StanceType.Crouching)
      num1 = 3.66666f;
    Transform transform1 = this.Arm[0].transform;
    transform1.localEulerAngles = new Vector3(transform1.localEulerAngles.x, transform1.localEulerAngles.y, transform1.localEulerAngles.z - this.Slouch * (3f + num1));
    Transform transform2 = this.Arm[1].transform;
    transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, transform2.localEulerAngles.y, transform2.localEulerAngles.z + this.Slouch * (3f + num1));
    if (!this.Aiming)
      this.Head.localEulerAngles += this.Twitch;
    if (this.Aiming)
    {
      this.TargetHeight = this.Stance.Current != StanceType.Crawling ? (this.Stance.Current != StanceType.Crouching ? 0.0f : (this.StudentManager.Eighties ? -2f : -0.6f)) : (this.StudentManager.Eighties ? -2f : -1.4f);
      this.Height = Mathf.Lerp(this.Height, this.TargetHeight, Time.deltaTime * 10f);
      this.PelvisRoot.transform.localPosition = new Vector3(this.PelvisRoot.transform.localPosition.x, this.Height, this.PelvisRoot.transform.localPosition.z);
    }
    if (this.Egg)
    {
      if (this.Slender)
      {
        Transform transform3 = this.Leg[0];
        transform3.localScale = new Vector3(transform3.localScale.x, 2f, transform3.localScale.z);
        Transform transform4 = this.Foot[0];
        transform4.localScale = new Vector3(transform4.localScale.x, 0.5f, transform4.localScale.z);
        Transform transform5 = this.Leg[1];
        transform5.localScale = new Vector3(transform5.localScale.x, 2f, transform5.localScale.z);
        Transform transform6 = this.Foot[1];
        transform6.localScale = new Vector3(transform6.localScale.x, 0.5f, transform6.localScale.z);
        Transform transform7 = this.Arm[0];
        transform7.localScale = new Vector3(2f, transform7.localScale.y, transform7.localScale.z);
        Transform transform8 = this.Arm[1];
        transform8.localScale = new Vector3(2f, transform8.localScale.y, transform8.localScale.z);
      }
      if (this.DK)
      {
        this.Arm[0].localScale = new Vector3(2f, 2f, 2f);
        this.Arm[1].localScale = new Vector3(2f, 2f, 2f);
        this.Head.localScale = new Vector3(2f, 2f, 2f);
      }
      if (this.CirnoWings.activeInHierarchy)
      {
        this.FlapSpeed = !this.Running ? ((double) this.FlapSpeed != 0.0 ? 3f : 1f) : 5f;
        Transform transform9 = this.CirnoWing[0];
        Transform transform10 = this.CirnoWing[1];
        if (!this.FlapOut)
        {
          this.CirnoRotation += Time.deltaTime * 100f * this.FlapSpeed;
          transform9.localEulerAngles = new Vector3(transform9.localEulerAngles.x, this.CirnoRotation, transform9.localEulerAngles.z);
          transform10.localEulerAngles = new Vector3(transform10.localEulerAngles.x, -this.CirnoRotation, transform10.localEulerAngles.z);
          if ((double) this.CirnoRotation > 15.0)
            this.FlapOut = true;
        }
        else
        {
          this.CirnoRotation -= Time.deltaTime * 100f * this.FlapSpeed;
          transform9.localEulerAngles = new Vector3(transform9.localEulerAngles.x, this.CirnoRotation, transform9.localEulerAngles.z);
          transform10.localEulerAngles = new Vector3(transform10.localEulerAngles.x, -this.CirnoRotation, transform10.localEulerAngles.z);
          if ((double) this.CirnoRotation < -15.0)
            this.FlapOut = false;
        }
      }
      if (this.BlackHole)
      {
        this.RightLeg.transform.Rotate(-60f, 0.0f, 0.0f, Space.Self);
        this.LeftLeg.transform.Rotate(-60f, 0.0f, 0.0f, Space.Self);
      }
      if (this.SwingKagune)
      {
        if (!this.ReturnKagune)
        {
          for (int index = 0; index < this.Kagune.Length; ++index)
          {
            if (index < 2)
            {
              this.KaguneRotation[index] = new Vector3(Mathf.MoveTowards(this.KaguneRotation[index].x, 15f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[index].y, 180f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[index].z, 500f, Time.deltaTime * 1000f));
              this.Kagune[index].transform.localEulerAngles = this.KaguneRotation[index];
            }
            else
            {
              this.KaguneRotation[index] = new Vector3(Mathf.MoveTowards(this.KaguneRotation[index].x, 15f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[index].y, -180f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[index].z, -500f, Time.deltaTime * 1000f));
              this.Kagune[index].transform.localEulerAngles = this.KaguneRotation[index];
            }
          }
          if (this.KagunePhase == 0 && (double) this.KaguneRotation[0].y == 180.0)
          {
            Object.Instantiate<GameObject>(this.DemonSlash, this.transform.position + this.transform.up + this.transform.forward, Quaternion.identity);
            this.KagunePhase = 1;
          }
          if (this.KaguneRotation[0] == new Vector3(15f, 180f, 500f))
            this.ReturnKagune = true;
        }
        else
        {
          for (int index = 0; index < this.Kagune.Length; ++index)
          {
            switch (index)
            {
              case 0:
                this.KaguneRotation[index] = new Vector3(Mathf.Lerp(this.KaguneRotation[index].x, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[index].y, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[index].z, 0.0f, Time.deltaTime * 10f));
                break;
              case 1:
                this.KaguneRotation[index] = new Vector3(Mathf.Lerp(this.KaguneRotation[index].x, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[index].y, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[index].z, 0.0f, Time.deltaTime * 10f));
                break;
              case 2:
                this.KaguneRotation[index] = new Vector3(Mathf.Lerp(this.KaguneRotation[index].x, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[index].y, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[index].z, 0.0f, Time.deltaTime * 10f));
                break;
              case 3:
                this.KaguneRotation[index] = new Vector3(Mathf.Lerp(this.KaguneRotation[index].x, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[index].y, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[index].z, 0.0f, Time.deltaTime * 10f));
                break;
            }
            this.Kagune[index].transform.localEulerAngles = this.KaguneRotation[index];
          }
          if ((double) Vector3.Distance(this.KaguneRotation[0], new Vector3(22.5f, 22.5f, 0.0f)) < 10.0)
          {
            this.SwingKagune = false;
            this.ReturnKagune = false;
            this.KagunePhase = 0;
          }
        }
      }
      if (this.FloppyHat.activeInHierarchy)
      {
        int index = 0;
        if (this.LongFingers)
        {
          this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 1f, Time.deltaTime * 10f);
          this.FingerLength = Mathf.Lerp(this.FingerLength, 4f, Time.deltaTime * 10f);
          this.Slouch = Mathf.Lerp(this.Slouch, 1f, Time.deltaTime * 10f);
          for (; index < this.AllFingers.Length; ++index)
            this.AllFingers[index].localScale = new Vector3(this.FingerLength, 1f, 1f);
        }
        else
        {
          this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 0.0f, Time.deltaTime * 10f);
          this.FingerLength = Mathf.Lerp(this.FingerLength, 1f, Time.deltaTime * 10f);
          this.Slouch = Mathf.Lerp(this.Slouch, 0.0f, Time.deltaTime * 10f);
          for (; index < this.AllFingers.Length; ++index)
            this.AllFingers[index].localScale = new Vector3(this.FingerLength, 1f, 1f);
        }
      }
      if (this.HollowMask.activeInHierarchy)
      {
        if (this.Armed)
        {
          if (!this.Attacking)
          {
            this.RightArmRoll.GetChild(0).localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            if (this.Running)
            {
              this.RightArmRoll.parent.localEulerAngles = new Vector3(0.0f, 0.0f, -75f);
              this.RightArmRoll.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
              this.RightArmRoll.GetChild(0).GetChild(1).localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
              this.RightArmRoll.GetChild(0).GetChild(1).GetChild(0).localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
            }
            else
            {
              this.RightArmRoll.parent.localEulerAngles += new Vector3(0.0f, 0.0f, 5f);
              this.RightArmRoll.GetChild(0).GetChild(1).GetChild(0).localEulerAngles = new Vector3(0.0f, 45f, 0.0f);
            }
          }
          this.ArmSize = Mathf.Lerp(this.ArmSize, 1f, Time.deltaTime * 10f);
        }
        else
          this.ArmSize = Mathf.Lerp(this.ArmSize, 0.0f, Time.deltaTime * 10f);
        this.RightArmRoll.parent.localScale = new Vector3(this.ArmSize, this.ArmSize, this.ArmSize);
        this.RightFootprintSpawner.transform.parent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        this.LeftFootprintSpawner.transform.parent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        this.LeftArmRoll.parent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
      }
    }
    if (this.SpiderLegs.activeInHierarchy)
    {
      if (this.SpiderGrow)
      {
        if ((double) this.SpiderLegs.transform.localScale.x < 0.490000009536743)
        {
          this.SpiderLegs.transform.localScale = Vector3.Lerp(this.SpiderLegs.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), Time.deltaTime * 5f);
          SchoolGlobals.SchoolAtmosphere = 1f - this.SpiderLegs.transform.localScale.x;
          this.StudentManager.SetAtmosphere();
        }
      }
      else if ((double) this.SpiderLegs.transform.localScale.x > 1.0 / 1000.0)
      {
        this.SpiderLegs.transform.localScale = Vector3.Lerp(this.SpiderLegs.transform.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 5f);
        SchoolGlobals.SchoolAtmosphere = 1f - this.SpiderLegs.transform.localScale.x;
        this.StudentManager.SetAtmosphere();
      }
    }
    if ((Object) this.PickUp != (Object) null && this.PickUp.Flashlight)
      this.RightHand.transform.eulerAngles = new Vector3(0.0f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    if ((double) this.ReachWeight > 0.0)
    {
      this.CharacterAnimation["f02_reachForWeapon_00"].weight = this.ReachWeight;
      this.ReachWeight = Mathf.MoveTowards(this.ReachWeight, 0.0f, Time.deltaTime * 2f);
      if ((double) this.ReachWeight < 0.00999999977648258)
      {
        this.ReachWeight = 0.0f;
        this.CharacterAnimation["f02_reachForWeapon_00"].weight = 0.0f;
      }
    }
    if ((double) this.SanitySmudges.color.a > 1.0 - (double) this.sanity / 100.0 + 9.99999974737875E-05 || (double) this.SanitySmudges.color.a < 1.0 - (double) this.sanity / 100.0 - 9.99999974737875E-05)
    {
      float a = Mathf.MoveTowards(this.SanitySmudges.color.a, (float) (1.0 - (double) this.sanity / 100.0), Time.deltaTime);
      this.SanitySmudges.color = new Color(1f, 1f, 1f, a);
      this.StudentManager.SelectiveGreyscale.desaturation = 1f - this.StudentManager.Atmosphere + a;
      if ((double) a > 0.666660010814667)
        this.StudentManager.SetFaces((float) (1.0 - (1.0 - (double) a) / 0.333330005407333));
      else
        this.StudentManager.SetFaces(0.0f);
      this.SanityLabel.text = ((float) (100.0 - (double) a * 100.0)).ToString("0") + "%";
    }
    if (this.CanMove && (double) this.sanity < 33.3330001831055 && !this.NearSenpai)
    {
      this.GiggleTimer += Time.deltaTime * (float) (1.0 - (double) this.sanity / 33.3330001831055);
      if ((double) this.GiggleTimer > 10.0)
      {
        Object.Instantiate<GameObject>(this.GiggleDisc, this.transform.position + Vector3.up, Quaternion.identity);
        AudioSource.PlayClipAtPoint(this.CreepyGiggles[Random.Range(0, this.CreepyGiggles.Length)], this.transform.position);
        this.InsaneLines.Play();
        this.GiggleTimer = 0.0f;
      }
    }
    if (this.FightHasBrokenUp)
    {
      this.BreakUpTimer = Mathf.MoveTowards(this.BreakUpTimer, 0.0f, Time.deltaTime);
      if ((double) this.BreakUpTimer == 0.0)
      {
        this.FightHasBrokenUp = false;
        this.SeenByAuthority = false;
      }
    }
    if (!this.WearingRaincoat || this.SetUpRaincoatOutline)
      return;
    if ((Object) this.RaincoatAttacher.newRenderer.GetComponent<OutlineScript>() == (Object) null)
      this.RaincoatAttacher.newRenderer.gameObject.AddComponent<OutlineScript>();
    OutlineScript component = this.RaincoatAttacher.newRenderer.gameObject.GetComponent<OutlineScript>();
    if ((Object) component.h == (Object) null)
    {
      component.Awake();
      this.SetUpRaincoatOutline = true;
    }
    component.color = this.Outline.color;
    component.enabled = this.Outline.enabled;
  }

  public void StainWeapon()
  {
    Debug.Log((object) "Time to run the code for staining a weapon with blood and marking it as evidence.");
    Debug.Log((object) ("Dismembering is: " + this.Dismembering.ToString()));
    if (!((Object) this.EquippedWeapon != (Object) null))
      return;
    if ((Object) this.TargetStudent != (Object) null && this.TargetStudent.StudentID < this.EquippedWeapon.Victims.Length)
      this.EquippedWeapon.Victims[this.TargetStudent.StudentID] = true;
    if (!this.EquippedWeapon.Blood.enabled)
    {
      this.EquippedWeapon.Evidence = true;
      this.EquippedWeapon.Bloody = true;
      if (!this.Dismembering)
        ++this.Police.MurderWeapons;
    }
    this.EquippedWeapon.Blood.enabled = true;
    if (!this.Dismembering)
    {
      this.EquippedWeapon.MurderWeapon = true;
    }
    else
    {
      int num = this.EquippedWeapon.Blood.enabled ? 1 : 0;
    }
    if (this.EquippedWeapon.Type == WeaponType.Bat)
      this.NoStainGloves = true;
    if (this.NoStainGloves)
      return;
    if (this.Gloved && !this.Gloves.Blood.enabled)
    {
      this.GloveAttacher.newRenderer.material.mainTexture = this.BloodyGloveTexture;
      this.Gloves.PickUp.Evidence = true;
      this.Gloves.Blood.enabled = true;
      this.GloveBlood = 1;
      ++this.Police.BloodyClothing;
    }
    if (!((Object) this.Mask != (Object) null) || this.Mask.Blood.enabled)
      return;
    this.Mask.PickUp.Evidence = true;
    this.Mask.Blood.enabled = true;
    ++this.Police.BloodyClothing;
  }

  public void MoveTowardsTarget(Vector3 target)
  {
    int num = (int) this.MyController.Move((target - this.transform.position) * (Time.deltaTime * 10f));
  }

  public void StopAiming()
  {
    this.UpdateAccessory();
    this.UpdateHair();
    this.CharacterAnimation["f02_cameraPose_00"].weight = 0.0f;
    this.CharacterAnimation["f02_selfie_00"].weight = 0.0f;
    this.CharacterAnimation["f02_selfie_01"].weight = 0.0f;
    this.PelvisRoot.transform.localPosition = new Vector3(this.PelvisRoot.transform.localPosition.x, 0.0f, this.PelvisRoot.transform.localPosition.z);
    this.ShoulderCamera.AimingCamera = false;
    if (!Input.GetButtonDown("Start") && !Input.GetKeyDown(KeyCode.Escape))
      this.FixCamera();
    if ((double) this.ShoulderCamera.Timer == 0.0)
      this.RPGCamera.enabled = true;
    this.MainCamera.clearFlags = OptionGlobals.Fog ? CameraClearFlags.Color : CameraClearFlags.Skybox;
    this.Smartphone.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.Smartphone.targetTexture = this.Shutter.SmartphoneScreen;
    this.Smartphone.transform.parent.gameObject.SetActive(false);
    this.Smartphone.fieldOfView = 60f;
    this.MainCamera.farClipPlane = (float) OptionGlobals.DrawDistance;
    this.MainCamera.nearClipPlane = 0.1f;
    this.Shutter.TargetStudent = 0;
    this.Height = 0.0f;
    this.Bend = 0.0f;
    this.HandCamera.gameObject.SetActive(false);
    this.SelfieGuide.SetActive(false);
    this.PhonePromptBar.Show = false;
    this.MainCamera.enabled = true;
    this.UsingController = false;
    this.Aiming = false;
    this.Selfie = false;
    this.Lewd = false;
    this.StudentManager.UpdatePanties(false);
    if (!OptionGlobals.DepthOfField)
      return;
    this.PauseScreen.NewSettings.Profile.depthOfField.enabled = true;
  }

  public void FixCamera()
  {
    if (!this.SneakingShot)
    {
      this.RPGCamera.enabled = true;
      this.RPGCamera.UpdateRotation();
      this.RPGCamera.mouseSmoothingFactor = 0.0f;
      this.RPGCamera.GetInput();
      this.RPGCamera.GetDesiredPosition();
      this.RPGCamera.PositionUpdate();
      this.RPGCamera.mouseSmoothingFactor = 0.08f;
    }
    this.Blur.enabled = false;
  }

  public void ResetSenpaiEffects()
  {
    this.SenpaiFilter.enabled = false;
    this.Phone.SetActive(false);
    for (int index = 1; index < 6; ++index)
    {
      this.CharacterAnimation[this.CreepyIdles[index]].weight = 0.0f;
      this.CharacterAnimation[this.CreepyWalks[index]].weight = 0.0f;
    }
    this.CharacterAnimation["f02_shy_00"].weight = 0.0f;
    this.HeartBeat.volume = 0.0f;
    this.SelectGrayscale.desaturation = this.GreyTarget;
    this.SenpaiFade = 100f;
    this.SenpaiTint = 0.0f;
  }

  public void ResetYandereEffects()
  {
    this.YandereTimer = 0.0f;
    this.Phone.SetActive(false);
    this.CharacterAnimation["f02_phonePose_00"].weight = 0.0f;
    this.YandereVisionPanel.alpha = 0.0f;
    this.SenpaiGazing = false;
    this.CameraEffects.UpdateVignette((float) (1.0 - (double) this.Sanity * 0.00999999977648258));
    this.YandereFilter.FadeFX = 0.0f;
    this.YandereFilter.enabled = false;
    Time.timeScale = 1f;
    this.YandereFade = 100f;
    this.StudentManager.Tag.Sprite.color = new Color(1f, 0.0f, 0.0f, 0.0f);
    this.StudentManager.RedString.gameObject.SetActive(false);
    this.RightRedEye.material.color = new Color(1f, 1f, 1f, 0.0f);
    this.LeftRedEye.material.color = new Color(1f, 1f, 1f, 0.0f);
    this.RightYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
    this.LeftYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
    this.HighlightingR.enabled = false;
    this.HighlightingB.enabled = false;
  }

  private void DumpRagdoll(RagdollDumpType Type)
  {
    this.Ragdoll.transform.position = this.transform.position;
    switch (Type)
    {
      case RagdollDumpType.Incinerator:
        this.Ragdoll.transform.LookAt(this.Incinerator.transform.position);
        this.Ragdoll.transform.eulerAngles = new Vector3(this.Ragdoll.transform.eulerAngles.x, this.Ragdoll.transform.eulerAngles.y + 180f, this.Ragdoll.transform.eulerAngles.z);
        break;
      case RagdollDumpType.TranqCase:
        this.Ragdoll.transform.LookAt(this.TranqCase.transform.position);
        break;
      case RagdollDumpType.WoodChipper:
        this.Ragdoll.transform.LookAt(this.WoodChipper.transform.position);
        break;
    }
    RagdollScript component = this.Ragdoll.GetComponent<RagdollScript>();
    component.DumpType = Type;
    component.Dump();
  }

  public void Unequip()
  {
    if (this.CanMove || this.Noticed)
    {
      if (this.Equipped < 3)
      {
        this.CharacterAnimation["f02_reachForWeapon_00"].time = 0.0f;
        this.ReachWeight = 1f;
        if ((Object) this.EquippedWeapon != (Object) null)
          this.EquippedWeapon.gameObject.SetActive(false);
      }
      else if ((Object) this.Weapon[3] != (Object) null)
        this.Weapon[3].Drop();
      this.Equipped = 0;
      this.Mopping = false;
      this.StudentManager.UpdateStudents();
      this.WeaponManager.UpdateLabels();
      this.WeaponMenu.UpdateSprites();
      this.WeaponWarning = false;
    }
    this.UpdateConcealedWeaponStatus();
  }

  public void DropWeapon(int ID)
  {
    if (this.Weapon[ID].Undroppable)
      return;
    this.DropTimer[ID] += Time.deltaTime;
    if ((double) this.DropTimer[ID] <= 0.5)
      return;
    this.Weapon[ID].Drop();
    this.Weapon[ID] = (WeaponScript) null;
    this.Unequip();
    this.DropTimer[ID] = 0.0f;
  }

  public void EmptyHands()
  {
    if (this.Carrying || this.HeavyWeight)
      this.StopCarrying();
    if (this.Armed)
      this.Unequip();
    if ((Object) this.PickUp != (Object) null)
      this.PickUp.Drop();
    if (this.Dragging)
      this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
    for (this.ID = 1; this.ID < this.Poisons.Length; ++this.ID)
      this.Poisons[this.ID].SetActive(false);
    this.Mopping = false;
  }

  public void UpdateNumbness() => this.Numbness = (float) (1.0 - 0.100000001490116 * (double) (this.Class.Numbness + this.Class.NumbnessBonus + this.Class.PsychologyGrade + this.Class.PsychologyBonus));

  private void OnTriggerEnter(Collider other)
  {
    if (!((Object) this.StudentManager != (Object) null) || this.StudentManager.TutorialActive || !(other.gameObject.name == "BloodPool(Clone)") || (double) other.transform.localScale.x <= 0.300000011920929)
      return;
    this.RightFootprintSpawner.StudentBloodID = other.GetComponent<BloodPoolScript>().StudentBloodID;
    this.LeftFootprintSpawner.StudentBloodID = this.RightFootprintSpawner.StudentBloodID;
    if (PlayerGlobals.PantiesEquipped == 8)
    {
      this.RightFootprintSpawner.Bloodiness = 5;
      this.LeftFootprintSpawner.Bloodiness = 5;
    }
    else
    {
      this.RightFootprintSpawner.Bloodiness = 10;
      this.LeftFootprintSpawner.Bloodiness = 10;
    }
  }

  public void UpdateHair()
  {
    if (this.Hairstyle > this.Hairstyles.Length - 1)
      this.Hairstyle = 0;
    if (this.Hairstyle < 0)
      this.Hairstyle = this.Hairstyles.Length - 1;
    for (this.ID = 1; this.ID < this.Hairstyles.Length; ++this.ID)
      this.Hairstyles[this.ID].SetActive(false);
    if (this.Hairstyle <= 0)
      return;
    this.Hairstyles[this.Hairstyle].SetActive(true);
  }

  public void StopLaughing()
  {
    this.BladeHairCollider1.enabled = false;
    this.BladeHairCollider2.enabled = false;
    if ((double) this.Sanity < 33.3333282470703)
      this.Teeth.SetActive(true);
    this.LaughIntensity = 0.0f;
    this.Laughing = false;
    this.LaughClip = (AudioClip) null;
    this.Twitch = Vector3.zero;
    if (!this.Stand.Stand.activeInHierarchy)
      this.CanMove = true;
    if (this.BanchoActive)
    {
      AudioSource.PlayClipAtPoint(this.BanchoFinalYan, this.transform.position);
      this.CharacterAnimation.CrossFade("f02_banchoFinisher_00");
      this.BanchoFlurry.MyCollider.enabled = false;
      this.Finisher = true;
      this.CanMove = false;
    }
    if (!this.StudentManager.Eighties)
      return;
    this.RestoreGentleEyes();
  }

  private void SetUniform()
  {
    if (StudentGlobals.FemaleUniform == 0)
      StudentGlobals.FemaleUniform = 1;
    this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
    this.TextureToUse = !this.Casual ? this.CasualTextures[StudentGlobals.FemaleUniform] : this.UniformTextures[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
    this.MyRenderer.materials[1].mainTexture = this.TextureToUse;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.StartCoroutine(this.ApplyCustomCostume());
  }

  private IEnumerator ApplyCustomCostume()
  {
    WWW CustomUniform;
    switch (StudentGlobals.FemaleUniform)
    {
      case 1:
        CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
        yield return (object) CustomUniform;
        if (CustomUniform.error == null)
        {
          this.MyRenderer.materials[0].mainTexture = (Texture) CustomUniform.texture;
          this.MyRenderer.materials[1].mainTexture = (Texture) CustomUniform.texture;
        }
        CustomUniform = (WWW) null;
        break;
      case 2:
        CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
        yield return (object) CustomUniform;
        if (CustomUniform.error == null)
        {
          this.MyRenderer.materials[0].mainTexture = (Texture) CustomUniform.texture;
          this.MyRenderer.materials[1].mainTexture = (Texture) CustomUniform.texture;
        }
        CustomUniform = (WWW) null;
        break;
      case 3:
        CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
        yield return (object) CustomUniform;
        if (CustomUniform.error == null)
        {
          this.MyRenderer.materials[0].mainTexture = (Texture) CustomUniform.texture;
          this.MyRenderer.materials[1].mainTexture = (Texture) CustomUniform.texture;
        }
        CustomUniform = (WWW) null;
        break;
      case 4:
      case 5:
        CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
        yield return (object) CustomUniform;
        if (CustomUniform.error == null)
        {
          this.MyRenderer.materials[0].mainTexture = (Texture) CustomUniform.texture;
          this.MyRenderer.materials[1].mainTexture = (Texture) CustomUniform.texture;
        }
        CustomUniform = (WWW) null;
        break;
    }
    WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
    yield return (object) CustomFace;
    if (CustomFace.error == null)
    {
      this.MyRenderer.materials[2].mainTexture = (Texture) CustomFace.texture;
      this.FaceTexture = (Texture) CustomFace.texture;
    }
    WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
    yield return (object) CustomHair;
    if (CustomHair.error == null)
    {
      this.PonytailRenderer.material.mainTexture = (Texture) CustomHair.texture;
      this.PigtailR.material.mainTexture = (Texture) CustomHair.texture;
      this.PigtailL.material.mainTexture = (Texture) CustomHair.texture;
    }
    WWW CustomDrills = new WWW("file:///" + Application.streamingAssetsPath + "/CustomDrills.png");
    yield return (object) CustomDrills;
    if (CustomDrills.error == null)
    {
      this.Drills.materials[0].mainTexture = (Texture) CustomDrills.texture;
      this.Drills.material.mainTexture = (Texture) CustomDrills.texture;
    }
    WWW CustomSwimsuit = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSwimsuit.png");
    yield return (object) CustomSwimsuit;
    if (CustomSwimsuit.error == null)
      this.SwimsuitTexture = (Texture) CustomSwimsuit.texture;
    WWW CustomGym = new WWW("file:///" + Application.streamingAssetsPath + "/CustomGym.png");
    yield return (object) CustomGym;
    if (CustomGym.error == null)
      this.GymTexture = (Texture) CustomGym.texture;
    WWW CustomNude = new WWW("file:///" + Application.streamingAssetsPath + "/CustomNude.png");
    yield return (object) CustomNude;
    if (CustomNude.error == null)
      this.NudeTexture = (Texture) CustomNude.texture;
    WWW CustomLongHairA = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairA.png");
    yield return (object) CustomDrills;
    WWW CustomLongHairB = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairB.png");
    yield return (object) CustomDrills;
    WWW CustomLongHairC = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairC.png");
    yield return (object) CustomDrills;
    if (CustomLongHairA.error == null && CustomLongHairB.error == null && CustomLongHairC.error == null)
    {
      this.LongHairRenderer.materials[0].mainTexture = (Texture) CustomLongHairA.texture;
      this.LongHairRenderer.materials[1].mainTexture = (Texture) CustomLongHairB.texture;
      this.LongHairRenderer.materials[2].mainTexture = (Texture) CustomLongHairC.texture;
    }
  }

  public void WearGloves()
  {
    if ((double) this.Bloodiness > 0.0 && !this.Gloves.Blood.enabled)
    {
      this.Gloves.PickUp.Evidence = true;
      this.Gloves.Blood.enabled = true;
    }
    if (this.Gloves.Blood.enabled)
      this.GloveBlood = 1;
    this.Gloved = true;
    if (this.WearingRaincoat)
    {
      this.WearRaincoat();
      if ((Object) this.RaincoatAttacher.newRenderer != (Object) null)
        this.RaincoatAttacher.newRenderer.enabled = true;
      this.OriginalBloodiness = this.Bloodiness;
      this.Bloodiness = this.CoatBloodiness;
    }
    else
      this.GloveAttacher.newRenderer.enabled = true;
  }

  private void AttackOnTitan()
  {
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.TitanFaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.TitanBodyTexture;
    this.MyRenderer.materials[2].mainTexture = this.TitanBodyTexture;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.ODMGear.SetActive(true);
    this.TitanSword[0].SetActive(true);
    this.TitanSword[1].SetActive(true);
    this.IdleAnim = "f02_heroicIdle_00";
    this.WalkAnim = "f02_walkConfident_00";
    this.RunAnim = "f02_sithRun_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.RunSpeed *= 2f;
    this.MusicCredit.SongLabel.text = "Now Playing: This Is My Choice";
    this.MusicCredit.BandLabel.text = "By: The Kira Justice";
    this.MusicCredit.Panel.enabled = true;
    this.MusicCredit.Slide = true;
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
    this.Outline.h.ReinitMaterials();
  }

  private void KON()
  {
    this.MyRenderer.sharedMesh = this.Uniforms[4];
    this.MyRenderer.materials[0].mainTexture = this.KONTexture;
    this.MyRenderer.materials[1].mainTexture = this.KONTexture;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.Outline.h.ReinitMaterials();
  }

  private void Punish()
  {
    this.PunishedShader = Shader.Find("Toon/Cutoff");
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
    this.PunishedAccessories.SetActive(true);
    this.PunishedScarf.SetActive(true);
    this.EyepatchL.SetActive(false);
    this.EyepatchR.SetActive(false);
    for (this.ID = 0; this.ID < this.PunishedArm.Length; ++this.ID)
      this.PunishedArm[this.ID].SetActive(true);
    this.MyRenderer.sharedMesh = this.PunishedMesh;
    this.MyRenderer.materials[0].mainTexture = this.PunishedTextures[1];
    this.MyRenderer.materials[1].mainTexture = this.PunishedTextures[1];
    this.MyRenderer.materials[2].mainTexture = this.PunishedTextures[0];
    this.MyRenderer.materials[1].shader = this.PunishedShader;
    this.MyRenderer.materials[1].SetFloat("_Shininess", 1f);
    this.MyRenderer.materials[1].SetFloat("_ShadowThreshold", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_Cutoff", 0.9f);
    this.MyRenderer.materials[1].color = new Color(1f, 1f, 1f, 1f);
    this.Outline.h.ReinitMaterials();
  }

  private void Hate()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.HatefulUniform;
    this.MyRenderer.materials[1].mainTexture = this.HatefulUniform;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    RenderSettings.skybox = this.HatefulSkybox;
    this.SelectGrayscale.desaturation = 1f;
    this.HeartRate.gameObject.SetActive(false);
    this.Sanity = 0.0f;
    this.Hairstyle = 15;
    this.UpdateHair();
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
  }

  private void Sukeban()
  {
    this.IdleAnim = "f02_idle_00";
    this.SukebanAccessories.SetActive(true);
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[1].mainTexture = this.SukebanBandages;
    this.MyRenderer.materials[0].mainTexture = this.SukebanUniform;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
  }

  private void Bancho()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.BanchoCamera.SetActive(true);
    this.MotionObject.enabled = true;
    this.MotionBlur.enabled = true;
    this.BanchoAccessories[0].SetActive(true);
    this.BanchoAccessories[1].SetActive(true);
    this.BanchoAccessories[2].SetActive(true);
    this.BanchoAccessories[3].SetActive(true);
    this.BanchoAccessories[4].SetActive(true);
    this.BanchoAccessories[5].SetActive(true);
    this.BanchoAccessories[6].SetActive(true);
    this.BanchoAccessories[7].SetActive(true);
    this.BanchoAccessories[8].SetActive(true);
    this.Laugh1 = this.BanchoYanYan;
    this.Laugh2 = this.BanchoYanYan;
    this.Laugh3 = this.BanchoYanYan;
    this.Laugh4 = this.BanchoYanYan;
    this.IdleAnim = "f02_banchoIdle_00";
    this.WalkAnim = "f02_banchoWalk_00";
    this.RunAnim = "f02_banchoSprint_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.RunSpeed *= 2f;
    this.BanchoPants.SetActive(true);
    this.MyRenderer.sharedMesh = this.BanchoMesh;
    this.MyRenderer.materials[0].mainTexture = this.BanchoFace;
    this.MyRenderer.materials[1].mainTexture = this.BanchoBody;
    this.MyRenderer.materials[2].mainTexture = this.BanchoBody;
    this.BanchoActive = true;
    this.TheDebugMenuScript.UpdateCensor();
    this.Character.transform.localPosition = new Vector3(0.0f, 0.04f, 0.0f);
    this.Hairstyle = 0;
    this.UpdateHair();
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
  }

  private void Slend()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    RenderSettings.skybox = this.SlenderSkybox;
    this.SelectGrayscale.desaturation = 0.5f;
    this.SelectGrayscale.enabled = true;
    this.EasterEggMenu.SetActive(false);
    this.Slender = true;
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
    this.SlenderHair[0].SetActive(true);
    this.SlenderHair[1].SetActive(true);
    this.RightYandereEye.gameObject.SetActive(false);
    this.LeftYandereEye.gameObject.SetActive(false);
    this.Character.transform.localPosition = new Vector3(this.Character.transform.localPosition.x, 0.822f, this.Character.transform.localPosition.z);
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.SlenderUniform;
    this.MyRenderer.materials[1].mainTexture = this.SlenderUniform;
    this.MyRenderer.materials[2].mainTexture = this.SlenderSkin;
    this.Sanity = 0.0f;
  }

  private void X()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.Xtan = true;
    this.Egg = true;
    this.Hairstyle = 9;
    this.UpdateHair();
    this.BlackEyePatch.SetActive(true);
    this.XSclera.SetActive(true);
    this.XEye.SetActive(true);
    this.Schoolwear = 2;
    this.ChangeSchoolwear();
    this.CanMove = true;
    this.MyRenderer.materials[0].mainTexture = this.XBody;
    this.MyRenderer.materials[1].mainTexture = this.XBody;
    this.MyRenderer.materials[2].mainTexture = this.XFace;
  }

  private void GaloSengen()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.IdleAnim = "f02_gruntIdle_00";
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
    for (this.ID = 0; this.ID < this.GaloAccessories.Length; ++this.ID)
      this.GaloAccessories[this.ID].SetActive(true);
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.UniformTextures[1];
    this.MyRenderer.materials[1].mainTexture = this.GaloArms;
    this.MyRenderer.materials[2].mainTexture = this.GaloFace;
    this.Hairstyle = 14;
    this.UpdateHair();
  }

  public void Jojo()
  {
    this.ShoulderCamera.LastPosition = this.ShoulderCamera.transform.position;
    this.ShoulderCamera.Summoning = true;
    this.RPGCamera.enabled = false;
    AudioSource.PlayClipAtPoint(this.SummonStand, this.transform.position);
    this.IdleAnim = "f02_jojoPose_00";
    this.WalkAnim = "f02_jojoWalk_00";
    this.EasterEggMenu.SetActive(false);
    this.CanMove = false;
    this.Egg = true;
    this.CharacterAnimation.CrossFade("f02_summonStand_00");
    this.Laugh1 = this.YanYan;
    this.Laugh2 = this.YanYan;
    this.Laugh3 = this.YanYan;
    this.Laugh4 = this.YanYan;
  }

  private void Agent()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = this.Uniforms[4];
    this.MyRenderer.materials[0].mainTexture = this.AgentSuit;
    this.MyRenderer.materials[1].mainTexture = this.AgentSuit;
    this.MyRenderer.materials[2].mainTexture = this.AgentFace;
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
    this.Barcode.SetActive(true);
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  private void Cirno()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = this.Uniforms[3];
    this.MyRenderer.materials[0].mainTexture = this.CirnoUniform;
    this.MyRenderer.materials[1].mainTexture = this.CirnoUniform;
    this.MyRenderer.materials[2].mainTexture = this.CirnoFace;
    this.CirnoWings.SetActive(true);
    this.CirnoHair.SetActive(true);
    this.IdleAnim = "f02_cirnoIdle_00";
    this.WalkAnim = "f02_cirnoWalk_00";
    this.RunAnim = "f02_cirnoRun_00";
    this.EasterEggMenu.SetActive(false);
    this.Stance.Current = StanceType.Standing;
    this.Uncrouch();
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  private void Falcon()
  {
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[0].mainTexture = this.FalconFace;
    this.MyRenderer.materials[1].mainTexture = this.FalconBody;
    this.MyRenderer.materials[2].mainTexture = this.FalconBody;
    this.FalconShoulderpad.SetActive(true);
    this.FalconKneepad1.SetActive(true);
    this.FalconKneepad2.SetActive(true);
    this.FalconBuckle.SetActive(true);
    this.FalconHelmet.SetActive(true);
    this.CharacterAnimation[this.RunAnim].speed = 5f;
    this.IdleAnim = "f02_falconIdle_00";
    this.RunSpeed *= 5f;
    this.Egg = true;
    this.Hairstyle = 3;
    this.UpdateHair();
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void Punch()
  {
    this.MusicCredit.SongLabel.text = "Now Playing: Unknown Hero";
    this.MusicCredit.BandLabel.text = "By: The Kira Justice";
    this.MusicCredit.Panel.enabled = true;
    this.MusicCredit.Slide = true;
    this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[0].mainTexture = this.SaitamaSuit;
    this.MyRenderer.materials[1].mainTexture = this.SaitamaSuit;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.EasterEggMenu.SetActive(false);
    this.Barcode.SetActive(false);
    this.Cape.SetActive(true);
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void BadTime()
  {
    this.MyRenderer.sharedMesh = this.Jersey;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[0].mainTexture = this.SansFace;
    this.MyRenderer.materials[1].mainTexture = this.SansTexture;
    this.MyRenderer.materials[2].mainTexture = this.SansTexture;
    this.EasterEggMenu.SetActive(false);
    this.IdleAnim = "f02_sansIdle_00";
    this.WalkAnim = "f02_sansWalk_00";
    this.RunAnim = "f02_sansRun_00";
    this.StudentManager.BadTime();
    this.Barcode.SetActive(false);
    this.Sans = true;
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().EasterEggCheck();
  }

  private void CyborgNinja()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.EnergySword.SetActive(true);
    this.IdleAnim = "CyborgNinja_Idle_Unarmed";
    this.RunAnim = "CyborgNinja_Run_Unarmed";
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.CyborgFace;
    this.MyRenderer.materials[1].mainTexture = this.CyborgBody;
    this.MyRenderer.materials[2].mainTexture = this.CyborgBody;
    this.Schoolwear = 0;
    for (this.ID = 1; this.ID < this.CyborgParts.Length; ++this.ID)
      this.CyborgParts[this.ID].SetActive(true);
    for (this.ID = 1; this.ID < this.StudentManager.Students.Length; ++this.ID)
    {
      StudentScript student = this.StudentManager.Students[this.ID];
      if ((Object) student != (Object) null)
      {
        student.Teacher = false;
        student.Strength = 0;
      }
    }
    this.RunSpeed *= 2f;
    this.EyewearID = 6;
    this.Hairstyle = 45;
    this.UpdateHair();
    this.Ninja = true;
    this.Egg = true;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void Ebola()
  {
    this.StudentManager.Ebola = true;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.IdleAnim = "f02_ebolaIdle_00";
    this.Nude();
    this.MyRenderer.enabled = false;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.EbolaAttacher.SetActive(true);
    this.EbolaWings.SetActive(true);
    this.EbolaHair.SetActive(true);
    this.Egg = true;
  }

  private void Long() => this.MyRenderer.sharedMesh = this.LongUniform;

  private void SwapMesh()
  {
    this.MyRenderer.sharedMesh = this.NewMesh;
    this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
    this.MyRenderer.materials[1].mainTexture = this.NewFace;
    this.MyRenderer.materials[2].mainTexture = this.TextureToUse;
    this.RightYandereEye.gameObject.SetActive(false);
    this.LeftYandereEye.gameObject.SetActive(false);
  }

  private void Nude()
  {
    Debug.Log((object) "Making Yandere-chan nude.");
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
    this.ID = 0;
    while (this.ID < this.CensorSteam.Length)
      ++this.ID;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
    this.EasterEggMenu.SetActive(false);
    this.ClubAttire = false;
    this.Schoolwear = 0;
    if (this.StudentManager.Eighties)
    {
      for (int index = 0; index < 13; ++index)
        this.MyRenderer.SetBlendShapeWeight(index, 0.0f);
    }
    this.ClubAccessory();
  }

  private void Samus()
  {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.SamusFace;
    this.MyRenderer.materials[1].mainTexture = this.SamusBody;
    this.PantyAttacher.newRenderer.enabled = false;
    this.Schoolwear = 0;
    this.PonytailRenderer.material.mainTexture = this.SamusFace;
    this.Egg = true;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void Witch()
  {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.WitchFace;
    this.MyRenderer.materials[1].mainTexture = this.WitchBody;
    this.PantyAttacher.newRenderer.enabled = false;
    this.Schoolwear = 0;
    this.IdleAnim = "f02_idleElegant_00";
    this.WalkAnim = "f02_jojoWalk_00";
    this.WitchMode = true;
    this.Egg = true;
    this.Hairstyle = 100;
    this.UpdateHair();
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void Pose()
  {
    this.StudentManager.Pose = !this.StudentManager.Pose;
    this.StudentManager.UpdateStudents();
  }

  private void HairBlades()
  {
    this.Hairstyle = 0;
    this.UpdateHair();
    this.BladeHair.SetActive(true);
    this.Egg = true;
  }

  private void Tornado()
  {
    this.Hairstyle = 0;
    this.UpdateHair();
    this.IdleAnim = "f02_tornadoIdle_00";
    this.WalkAnim = "f02_tornadoWalk_00";
    this.RunAnim = "f02_tornadoRun_00";
    this.TornadoHair.SetActive(true);
    this.TornadoDress.SetActive(true);
    this.RiggedAccessory.SetActive(true);
    this.MyRenderer.sharedMesh = this.NoTorsoMesh;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.Sanity = 100f;
    this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudePanties;
    this.MyRenderer.materials[2].mainTexture = this.NudePanties;
    this.TheDebugMenuScript.UpdateCensor();
    this.Stance.Current = StanceType.Standing;
    this.Egg = true;
  }

  private void GenderSwap()
  {
    this.Kun.SetActive(true);
    this.KunHair.SetActive(true);
    this.MyRenderer.enabled = false;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.IdleAnim = "idleShort_00";
    this.WalkAnim = "walk_00";
    this.RunAnim = "newSprint_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  private void Mandere()
  {
    this.Man.SetActive(true);
    this.Barcode.SetActive(false);
    this.MyRenderer.enabled = false;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.RightYandereEye.gameObject.SetActive(false);
    this.LeftYandereEye.gameObject.SetActive(false);
    this.IdleAnim = "idleShort_00";
    this.WalkAnim = "walk_00";
    this.RunAnim = "newSprint_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  private void BlackHoleChan()
  {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.BlackHoleFace;
    this.MyRenderer.materials[1].mainTexture = this.Black;
    this.MyRenderer.materials[2].mainTexture = this.Black;
    this.PantyAttacher.newRenderer.enabled = false;
    this.Schoolwear = 0;
    this.IdleAnim = "f02_gazerIdle_00";
    this.WalkAnim = "f02_gazerWalk_00";
    this.RunAnim = "f02_gazerRun_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.Hairstyle = 182;
    this.UpdateHair();
    this.BlackHoleEffects.SetActive(true);
    this.BlackHole = true;
    this.Egg = true;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void ElfenLied()
  {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
    this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
    foreach (GameObject vector in this.Vectors)
      vector.SetActive(true);
    this.IdleAnim = "f02_sixIdle_00";
    this.WalkAnim = "f02_sixWalk_00";
    this.RunAnim = "f02_sixRun_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.LucyHelmet.SetActive(true);
    this.Bandages.SetActive(true);
    this.Egg = true;
    this.WalkSpeed = 0.75f;
    this.RunSpeed = 2f;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void Ghoul()
  {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.GhoulFace;
    this.MyRenderer.materials[1].mainTexture = this.GhoulBody;
    this.MyRenderer.materials[2].mainTexture = this.GhoulBody;
    foreach (GameObject gameObject in this.Kagune)
      gameObject.SetActive(true);
    this.IdleAnim = "f02_sixIdle_00";
    this.WalkAnim = "f02_sixWalk_00";
    this.RunAnim = "f02_psychoRun_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.StudentManager.Six = true;
    this.StudentManager.UpdateStudents();
    this.Egg = true;
    this.WalkSpeed = 0.75f;
    this.RunSpeed = 10f;
    this.Hairstyle = 15;
    this.UpdateHair();
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void Berserk()
  {
    SchoolGlobals.SchoolAtmosphere = 0.5f;
    this.StudentManager.SetAtmosphere();
    foreach (GameObject gameObject in this.Armor)
      gameObject.SetActive(true);
    foreach (Renderer tree in this.StudentManager.Trees)
      tree.materials[1] = this.Trans;
    this.SithSpawnTime = this.NierSpawnTime;
    this.SithHardSpawnTime1 = this.NierHardSpawnTime;
    this.SithHardSpawnTime2 = this.NierHardSpawnTime;
    this.SithAudio.clip = this.NierSwoosh;
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.Scarface;
    this.MyRenderer.materials[1].mainTexture = this.Chainmail;
    this.MyRenderer.materials[2].mainTexture = this.Chainmail;
    this.PantyAttacher.newRenderer.enabled = false;
    this.Schoolwear = 0;
    this.TheDebugMenuScript.UpdateCensor();
    this.IdleAnim = "f02_heroicIdle_00";
    this.WalkAnim = "f02_walkConfident_00";
    this.RunAnim = "f02_nierRun_00";
    this.CharacterAnimation["f02_nierRun_00"].speed = 1f;
    this.CharacterAnimation["f02_gutsEye_00"].weight = 1f;
    this.RunSpeed = 7.5f;
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.Hairstyle = 188;
    this.UpdateHair();
    this.Egg = true;
  }

  private void Sith()
  {
    this.Hairstyle = 67;
    this.UpdateHair();
    this.SithTrail1.SetActive(true);
    this.SithTrail2.SetActive(true);
    this.IdleAnim = "f02_sithIdle_00";
    this.WalkAnim = "f02_sithWalk_00";
    this.RunAnim = "f02_sithRun_00";
    this.BlackRobe.SetActive(true);
    this.MyRenderer.sharedMesh = this.NoUpperBodyMesh;
    this.MyRenderer.materials[0].mainTexture = this.NudePanties;
    this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[2].mainTexture = this.NudePanties;
    this.Stance.Current = StanceType.Standing;
    this.FollowHips = true;
    this.SithLord = true;
    this.Egg = true;
    this.Police.Clock.CameraEffects.Profile.depthOfField.enabled = false;
    this.TheDebugMenuScript.UpdateCensor();
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.RunSpeed *= 2f;
    this.Zoom.TargetZoom = 0.4f;
  }

  private void Snake()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.SnakeBody;
    this.MyRenderer.materials[1].mainTexture = this.SnakeBody;
    this.MyRenderer.materials[2].mainTexture = this.SnakeFace;
    this.Hairstyle = 161;
    this.UpdateHair();
    this.Medusa = true;
    this.Egg = true;
  }

  private void Gazer()
  {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.GazerEyes.gameObject.SetActive(true);
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.GazerFace;
    this.MyRenderer.materials[1].mainTexture = this.GazerBody;
    this.MyRenderer.materials[2].mainTexture = this.GazerBody;
    this.PantyAttacher.newRenderer.enabled = false;
    this.Schoolwear = 0;
    this.IdleAnim = "f02_gazerIdle_00";
    this.WalkAnim = "f02_gazerWalk_00";
    this.RunAnim = "f02_gazerRun_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.Hairstyle = 158;
    this.UpdateHair();
    this.StudentManager.Gaze = true;
    this.StudentManager.UpdateStudents();
    this.Gazing = true;
    this.Egg = true;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void Six()
  {
    RenderSettings.skybox = this.HatefulSkybox;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.IdleAnim = "f02_sixIdle_00";
    this.WalkAnim = "f02_sixWalk_00";
    this.RunAnim = "f02_sixRun_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.SixRaincoat.SetActive(true);
    this.MyRenderer.sharedMesh = this.SixBodyMesh;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[0].mainTexture = this.SixFaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
    this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
    this.TheDebugMenuScript.UpdateCensor();
    SchoolGlobals.SchoolAtmosphere = 0.0f;
    this.StudentManager.SetAtmosphere();
    this.StudentManager.Six = true;
    this.StudentManager.UpdateStudents();
    this.StudentManager.DepowerStudentCouncil();
    this.WalkSpeed = 0.75f;
    this.RunSpeed = 2f;
    this.Hungry = true;
    this.Egg = true;
    this.StudentManager.Students[1].Blind = true;
  }

  public void WearRaincoat()
  {
    Debug.Log((object) "Yandere-chan is now firing the WearRaincoat() function.");
    this.HairstyleBeforeRaincoat = this.Hairstyle;
    if (this.VtuberID == 0)
    {
      this.Hairstyle = this.StudentManager.Eighties ? 204 : 200;
      this.UpdateHair();
    }
    this.RaincoatAttacher.gameObject.SetActive(true);
    this.MyRenderer.sharedMesh = this.HeadAndKnees;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
    this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
    this.TheDebugMenuScript.UpdateCensor();
  }

  private void KLK()
  {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.KLKSword.SetActive(true);
    this.IdleAnim = "f02_heroicIdle_00";
    this.WalkAnim = "f02_walkConfident_00";
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.KLKFace;
    this.MyRenderer.materials[1].mainTexture = this.KLKBody;
    this.MyRenderer.materials[2].mainTexture = this.KLKBody;
    this.PantyAttacher.newRenderer.enabled = false;
    this.Schoolwear = 0;
    for (this.ID = 0; this.ID < this.KLKParts.Length; ++this.ID)
      this.KLKParts[this.ID].SetActive(true);
    for (this.ID = 1; this.ID < this.StudentManager.Students.Length; ++this.ID)
    {
      StudentScript student = this.StudentManager.Students[this.ID];
      if ((Object) student != (Object) null)
        student.Teacher = false;
    }
    this.Egg = true;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  public void Miyuki()
  {
    this.MiyukiCostume.SetActive(true);
    this.MiyukiWings.SetActive(true);
    this.IdleAnim = "f02_idleGirly_00";
    this.WalkAnim = "f02_walkGirly_00";
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.MiyukiFace;
    this.MyRenderer.materials[1].mainTexture = this.MiyukiSkin;
    this.MyRenderer.materials[2].mainTexture = this.MiyukiSkin;
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.TheDebugMenuScript.UpdateCensor();
    this.Jukebox.MiyukiMusic();
    this.Hairstyle = 171;
    this.UpdateHair();
    this.MagicalGirl = true;
    this.Egg = true;
  }

  public void AzurLane()
  {
    this.Schoolwear = 2;
    this.ChangeSchoolwear();
    this.PantyAttacher.newRenderer.enabled = false;
    this.IdleAnim = "f02_gazerIdle_00";
    this.WalkAnim = "f02_gazerWalk_00";
    this.RunAnim = "f02_gazerRun_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.AzurGuns.SetActive(true);
    this.AzurWater.SetActive(true);
    this.AzurMist.SetActive(true);
    this.Shipgirl = true;
    this.CanMove = true;
    this.Egg = true;
    this.Jukebox.Shipgirl();
  }

  private void GarbageMode()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.sharedMesh = (Mesh) null;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.GarbageBag.SetActive(true);
    for (this.ID = 1; this.ID < 101; ++this.ID)
    {
      if ((Object) this.StudentManager.Students[this.ID] != (Object) null && this.StudentManager.Students[this.ID].gameObject.activeInHierarchy)
      {
        this.StudentManager.Students[this.ID].Cosmetic.HairRenderer.gameObject.SetActive(false);
        this.StudentManager.Students[this.ID].MyRenderer.enabled = false;
        this.StudentManager.Students[this.ID].GarbageBag.SetActive(true);
      }
    }
  }

  private void TallMode()
  {
    SchoolGlobals.SchoolAtmosphere = 0.5f;
    this.StudentManager.SetAtmosphere();
    this.TallLadyAttacher.SetActive(true);
    this.BlackRose.SetActive(true);
    this.FloppyHat.SetActive(true);
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.sharedMesh = (Mesh) null;
    this.Hairstyle = 201;
    this.UpdateHair();
    this.IdleAnim = "f02_idleGraceful_00";
    this.WalkAnim = "f02_walkGraceful_00";
    this.OriginalIdleAnim = "f02_idleGraceful_00";
    this.OriginalWalkAnim = "f02_walkGraceful_00";
    this.CharacterAnimation["f02_sithAttack_00"].speed = 1f;
    this.CharacterAnimation["f02_sithAttack_01"].speed = 1f;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
    this.transform.localScale = new Vector3(1.27f, 1.27f, 1.27f);
    this.RightBreast.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    this.LeftBreast.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    this.BoobPhysics[0].enabled = true;
    this.BoobPhysics[1].enabled = true;
    this.Egg = true;
  }

  private void HollowMode()
  {
    RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
    RenderSettings.skybox = this.HorrorSkybox;
    SchoolGlobals.SchoolAtmosphere = 0.0f;
    this.StudentManager.SetAtmosphere();
    this.HollowCloakAttacher.SetActive(true);
    this.HollowSword.SetActive(true);
    this.HollowMask.SetActive(true);
    this.DarkParticles.SetActive(true);
    this.MyRenderer.sharedMesh = this.NoButtMesh;
    this.MyRenderer.materials[0].mainTexture = this.HollowFaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.HollowBodyTexture;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.RunAnim = "f02_nierRun_00";
    this.CharacterAnimation["f02_nierRun_00"].speed = 1f;
    this.RunSpeed = 7.5f;
    this.CharacterAnimation["f02_sithAttack_00"].speed = 1f;
    this.CharacterAnimation["f02_sithAttack_01"].speed = 1f;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
    this.PantyAttacher.newRenderer.enabled = false;
    this.HollowFilter.enabled = true;
    this.Invisible = true;
    for (this.ID = 1; this.ID < this.StudentManager.Students.Length; ++this.ID)
    {
      StudentScript student = this.StudentManager.Students[this.ID];
      if ((Object) student != (Object) null)
        student.Teacher = false;
    }
    this.Egg = true;
  }

  private void Blacklight()
  {
    this.BlacklightShader.enabled = true;
    this.Hairstyle = 196;
    this.UpdateHair();
    this.IdleAnim = "f02_idleElegant_00";
    this.WalkAnim = "f02_jojoWalk_00";
    this.OriginalIdleAnim = "f02_idleElegant_00";
    this.OriginalWalkAnim = "f02_jojoWalk_00";
    this.BlacklightOutfit.SetActive(true);
    this.MyRenderer.sharedMesh = this.BlacklightBodyMesh;
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
    this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
    this.Egg = true;
  }

  public void Weather()
  {
    if (!this.Rain.activeInHierarchy)
    {
      SchoolGlobals.SchoolAtmosphere = 0.0f;
      this.StudentManager.SetAtmosphere();
      this.Rain.SetActive(true);
      this.Jukebox.Start();
    }
    else
    {
      this.Hairstyle = 67;
      this.UpdateHair();
      this.RaincoatAttacher.gameObject.SetActive(true);
      this.MyRenderer.sharedMesh = this.SixBodyMesh;
      this.PantyAttacher.newRenderer.enabled = false;
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
      this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
      this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
      this.TheDebugMenuScript.UpdateCensor();
    }
  }

  private void Horror()
  {
    this.Rain.SetActive(false);
    RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
    RenderSettings.skybox = this.HorrorSkybox;
    SchoolGlobals.SchoolAtmosphere = 0.0f;
    this.StudentManager.SetAtmosphere();
    this.RPGCamera.desiredDistance = 0.33333f;
    this.Zoom.OverShoulder = true;
    this.Zoom.TargetZoom = 0.2f;
    this.PauseScreen.MissionMode.FPS.transform.localPosition = new Vector3(1020f, -465f, 0.0f);
    this.PauseScreen.MissionMode.Watermark.gameObject.SetActive(false);
    this.PauseScreen.MissionMode.Nemesis.SetActive(true);
    this.StudentManager.Clock.MainLight.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    this.StudentManager.Clock.gameObject.SetActive(false);
    this.StudentManager.Clock.SunFlare.SetActive(false);
    this.StudentManager.Clock.Horror = true;
    this.StudentManager.Students[1].transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    this.StudentManager.Headmaster.gameObject.SetActive(false);
    this.StudentManager.Reputation.gameObject.SetActive(false);
    this.StudentManager.Flashlight.gameObject.SetActive(true);
    this.StudentManager.Flashlight.BePickedUp();
    this.StudentManager.DelinquentRadio.SetActive(false);
    this.StudentManager.CounselorDoor[0].enabled = false;
    this.StudentManager.CounselorDoor[1].enabled = false;
    this.StudentManager.CounselorDoor[0].Prompt.enabled = false;
    this.StudentManager.CounselorDoor[1].Prompt.enabled = false;
    this.StudentManager.Portal.SetActive(false);
    RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
    for (this.ID = 1; this.ID < 101; ++this.ID)
    {
      if ((Object) this.StudentManager.Students[this.ID] != (Object) null && this.StudentManager.Students[this.ID].gameObject.activeInHierarchy)
        this.StudentManager.DisableStudent(this.ID);
    }
    this.Egg = true;
  }

  private void LifeNote()
  {
    for (this.ID = 1; this.ID < 101; ++this.ID)
      StudentGlobals.SetStudentPhotographed(this.ID, true);
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.LifeNotebook.transform.position = this.transform.position + this.transform.forward + new Vector3(0.0f, 2.5f, 0.0f);
    this.LifeNotebook.GetComponent<Rigidbody>().useGravity = true;
    this.LifeNotebook.GetComponent<Rigidbody>().isKinematic = false;
    this.LifeNotebook.gameObject.SetActive(true);
    this.MyRenderer.sharedMesh = this.YamikoMesh;
    this.MyRenderer.materials[0].mainTexture = this.YamikoSkinTexture;
    this.MyRenderer.materials[1].mainTexture = this.YamikoAccessoryTexture;
    this.MyRenderer.materials[2].mainTexture = this.YamikoFaceTexture;
    this.PantyAttacher.newRenderer.enabled = false;
    this.Schoolwear = 0;
    this.Hairstyle = 180;
    this.UpdateHair();
    this.StudentManager.NoteWindow.BecomeLifeNote();
    this.Egg = true;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  private void Nier()
  {
    this.NierCostume.SetActive(true);
    this.HeavySwordParent.gameObject.SetActive(true);
    this.LightSwordParent.gameObject.SetActive(true);
    this.HeavySword.GetComponent<WeaponTrail>().Start();
    this.LightSword.GetComponent<WeaponTrail>().Start();
    this.HeavySword.GetComponent<WeaponTrail>().enabled = false;
    this.LightSword.GetComponent<WeaponTrail>().enabled = false;
    this.Pod.SetActive(true);
    this.SithSpawnTime = this.NierSpawnTime;
    this.SithHardSpawnTime1 = this.NierHardSpawnTime;
    this.SithHardSpawnTime2 = this.NierHardSpawnTime;
    this.SithAudio.clip = this.NierSwoosh;
    this.Pod.transform.parent = (Transform) null;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.sharedMesh = (Mesh) null;
    this.PantyAttacher.newRenderer.enabled = false;
    this.Schoolwear = 0;
    this.Hairstyle = 181;
    this.UpdateHair();
    this.Egg = true;
    this.IdleAnim = "f02_heroicIdle_00";
    this.WalkAnim = "f02_walkGraceful_00";
    this.RunAnim = "f02_nierRun_00";
    this.RunSpeed = 10f;
    this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
  }

  public void WearChinaDress()
  {
    this.EbolaHair.SetActive(false);
    this.EbolaWings.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 0.0f);
    this.EbolaWings.GetComponent<Renderer>().material.SetColor("_OutlineColor", new Color(0.0f, 0.0f, 0.0f));
    this.Hairstyle = 1;
    this.UpdateHair();
    this.ChinaDress.SetActive(true);
    this.Nude();
    this.PantyAttacher.newRenderer.enabled = true;
  }

  public void Medibang()
  {
    this.MedibangAttacher.SetActive(true);
    this.Hairstyle = 208;
    this.UpdateHair();
    this.MyRenderer.enabled = false;
  }

  private void Vaporwave()
  {
    this.VaporwaveVisuals.ApplyNormalView();
    RenderSettings.skybox = this.VaporwaveSkybox;
    this.PalmTrees.SetActive(true);
    for (int index = 1; index < this.Trees.Length; ++index)
      this.Trees[index].SetActive(false);
  }

  public void ChangeSchoolwear()
  {
    if (this.StudentManager.Eighties)
    {
      this.RestoreGentleEyes();
      this.GymTexture = this.EightiesGymTexture;
    }
    this.PantyAttacher.newRenderer.enabled = false;
    this.RightFootprintSpawner.Bloodiness = 0;
    this.LeftFootprintSpawner.Bloodiness = 0;
    if (this.ClubAttire && (double) this.Bloodiness == 0.0)
      this.Schoolwear = this.PreviousSchoolwear;
    this.LabcoatAttacher.RemoveAccessory();
    this.Paint = false;
    for (this.ID = 0; this.ID < this.CensorSteam.Length; ++this.ID)
      this.CensorSteam[this.ID].SetActive(false);
    this.TextureToUse = !this.Casual ? this.CasualTextures[StudentGlobals.FemaleUniform] : this.UniformTextures[StudentGlobals.FemaleUniform];
    if (this.ClubAttire && (double) this.Bloodiness > 0.0 || this.Schoolwear == 0)
    {
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
      this.MyRenderer.sharedMesh = this.Towel;
      this.MyRenderer.materials[0].mainTexture = this.TowelTexture;
      this.MyRenderer.materials[1].mainTexture = this.TowelTexture;
      this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
      this.ClubAttire = false;
      this.Schoolwear = 0;
    }
    else if (this.Schoolwear == 1)
    {
      this.PantyAttacher.newRenderer.enabled = true;
      this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
      if (GameGlobals.CensorPanties)
      {
        Debug.Log((object) "Activating shadows on Yandere-chan.");
        this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
        this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
        this.PantyAttacher.newRenderer.enabled = false;
      }
      this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
      this.MyRenderer.materials[1].mainTexture = this.TextureToUse;
      this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
      this.StartCoroutine(this.ApplyCustomCostume());
    }
    else if (this.Schoolwear == 2)
    {
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
      this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
      this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
      this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
      this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    }
    else if (this.Schoolwear == 3)
    {
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
      this.MyRenderer.sharedMesh = this.GymUniform;
      this.MyRenderer.materials[0].mainTexture = this.GymTexture;
      this.MyRenderer.materials[1].mainTexture = this.GymTexture;
      this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    }
    this.CanMove = false;
    this.Outline.h.ReinitMaterials();
    this.ClubAccessory();
  }

  public void ChangeClubwear()
  {
    this.PantyAttacher.newRenderer.enabled = false;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
    this.Paint = false;
    if (!this.ClubAttire)
    {
      this.ClubAttire = true;
      if (this.Club == ClubType.Art)
      {
        this.MyRenderer.sharedMesh = this.ApronMesh;
        this.MyRenderer.materials[0].mainTexture = this.ApronTexture;
        this.MyRenderer.materials[1].mainTexture = this.ApronTexture;
        this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
        this.Schoolwear = 4;
        this.Paint = true;
      }
      else if (this.Club == ClubType.MartialArts)
      {
        this.MyRenderer.sharedMesh = this.JudoGiMesh;
        this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
        this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
        this.MyRenderer.materials[2].mainTexture = this.JudoGiTexture;
        this.Schoolwear = 5;
      }
      else if (this.Club == ClubType.Science)
      {
        this.LabcoatAttacher.enabled = true;
        this.MyRenderer.sharedMesh = this.HeadAndHands;
        if (this.LabcoatAttacher.Initialized)
          this.LabcoatAttacher.AttachAccessory();
        this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
        this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
        this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
        this.Schoolwear = 6;
      }
    }
    else
    {
      this.ChangeSchoolwear();
      this.ClubAttire = false;
    }
    this.MyLocker.UpdateButtons();
  }

  public void ClubAccessory()
  {
    for (this.ID = 0; this.ID < this.ClubAccessories.Length; ++this.ID)
    {
      GameObject clubAccessory = this.ClubAccessories[this.ID];
      if ((Object) clubAccessory != (Object) null)
        clubAccessory.SetActive(false);
    }
    if (!((Object) this.MyRenderer.sharedMesh != (Object) this.Towel) || this.Club <= ClubType.None || !((Object) this.ClubAccessories[(int) this.Club] != (Object) null))
      return;
    this.ClubAccessories[(int) this.Club].SetActive(true);
  }

  public void StopCarrying()
  {
    this.CurrentRagdoll = (RagdollScript) null;
    if ((Object) this.Ragdoll != (Object) null)
      this.Ragdoll.GetComponent<RagdollScript>().Fall();
    this.HeavyWeight = false;
    this.Carrying = false;
    this.IdleAnim = this.OriginalIdleAnim;
    this.WalkAnim = this.OriginalWalkAnim;
    this.RunAnim = this.OriginalRunAnim;
  }

  private void Crouch()
  {
    this.MyController.center = new Vector3(this.MyController.center.x, 0.55f, this.MyController.center.z);
    this.MyController.height = 0.9f;
  }

  private void Crawl()
  {
    this.MyController.center = new Vector3(this.MyController.center.x, 0.25f, this.MyController.center.z);
    this.MyController.height = 0.1f;
  }

  public void Uncrouch()
  {
    this.MyController.center = new Vector3(this.MyController.center.x, 0.875f, this.MyController.center.z);
    this.MyController.height = 1.55f;
  }

  private void StopArmedAnim()
  {
    for (this.ID = 0; this.ID < this.ArmedAnims.Length; ++this.ID)
    {
      string armedAnim = this.ArmedAnims[this.ID];
      this.CharacterAnimation[armedAnim].weight = Mathf.Lerp(this.CharacterAnimation[armedAnim].weight, 0.0f, Time.deltaTime * 10f);
    }
  }

  public void UpdateAccessory()
  {
    if ((Object) this.AccessoryGroup != (Object) null)
      this.AccessoryGroup.SetPartsActive(false);
    if (this.AccessoryID > this.Accessories.Length - 1)
      this.AccessoryID = 0;
    if (this.AccessoryID < 0)
      this.AccessoryID = this.Accessories.Length - 1;
    if (this.AccessoryID <= 0)
      return;
    this.Accessories[this.AccessoryID].SetActive(true);
    this.AccessoryGroup = this.Accessories[this.AccessoryID].GetComponent<AccessoryGroupScript>();
    if (!((Object) this.AccessoryGroup != (Object) null))
      return;
    this.AccessoryGroup.SetPartsActive(true);
  }

  private void DisableHairAndAccessories()
  {
    for (this.ID = 1; this.ID < this.Accessories.Length; ++this.ID)
      this.Accessories[this.ID].SetActive(false);
    for (this.ID = 1; this.ID < this.Hairstyles.Length; ++this.ID)
      this.Hairstyles[this.ID].SetActive(false);
  }

  public void BullyPhotoCheck()
  {
    Debug.Log((object) "We are now going to perform a bully photo check.");
    for (int photoID = 1; photoID < 26; ++photoID)
    {
      if (PlayerGlobals.GetPhoto(photoID) && PlayerGlobals.GetBullyPhoto(photoID) > 0)
      {
        Debug.Log((object) "Yandere-chan has a bully photo in her photo gallery!");
        this.BullyPhoto = true;
      }
    }
  }

  public void UpdatePersona(int NewPersona)
  {
    switch (NewPersona)
    {
      case 0:
        this.Persona = YanderePersonaType.Default;
        break;
      case 1:
        this.Persona = YanderePersonaType.Chill;
        break;
      case 2:
        this.Persona = YanderePersonaType.Confident;
        break;
      case 3:
        this.Persona = YanderePersonaType.Elegant;
        break;
      case 4:
        this.Persona = YanderePersonaType.Girly;
        break;
      case 5:
        this.Persona = YanderePersonaType.Graceful;
        break;
      case 6:
        this.Persona = YanderePersonaType.Haughty;
        break;
      case 7:
        this.Persona = YanderePersonaType.Lively;
        break;
      case 8:
        this.Persona = YanderePersonaType.Scholarly;
        break;
      case 9:
        this.Persona = YanderePersonaType.Shy;
        break;
      case 10:
        this.Persona = YanderePersonaType.Tough;
        break;
      case 11:
        this.Persona = YanderePersonaType.Aggressive;
        break;
      case 12:
        this.Persona = YanderePersonaType.Grunt;
        break;
    }
  }

  private void SithSoundCheck()
  {
    if ((double) this.SithBeam[1].Damage == 10.0 || (double) this.NierDamage == 10.0)
    {
      if (this.SithSounds != 0)
        return;
      if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time < (double) this.SithSpawnTime[this.SithCombo] - 0.100000001490116)
        return;
      this.SithAudio.pitch = Random.Range(0.9f, 1.1f);
      this.SithAudio.Play();
      ++this.SithSounds;
    }
    else if (this.SithSounds == 0)
    {
      if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time < (double) this.SithHardSpawnTime1[this.SithCombo] - 0.100000001490116)
        return;
      this.SithAudio.pitch = Random.Range(0.9f, 1.1f);
      this.SithAudio.Play();
      ++this.SithSounds;
    }
    else if (this.SithSounds == 1)
    {
      if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time < (double) this.SithHardSpawnTime2[this.SithCombo] - 0.100000001490116)
        return;
      this.SithAudio.pitch = Random.Range(0.9f, 1.1f);
      this.SithAudio.Play();
      ++this.SithSounds;
    }
    else
    {
      if (this.SithSounds != 2 || this.SithCombo != 1)
        return;
      if ((double) this.CharacterAnimation["f02_" + this.AttackPrefix + "Attack" + this.SithPrefix + "_0" + this.SithCombo.ToString()].time < 0.833333313465118)
        return;
      this.SithAudio.pitch = Random.Range(0.9f, 1.1f);
      this.SithAudio.Play();
      ++this.SithSounds;
    }
  }

  public void UpdateSelfieStatus()
  {
    if (!this.Selfie)
    {
      this.Smartphone.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.Smartphone.targetTexture = this.Shutter.SmartphoneScreen;
      this.HandCamera.gameObject.SetActive(true);
      this.SelfieGuide.SetActive(false);
      this.MainCamera.enabled = true;
      if (!this.StudentManager.Eighties)
        this.Blur.enabled = true;
      else
        this.Blur.enabled = false;
    }
    else
    {
      if (this.Stance.Current == StanceType.Crawling)
        this.Stance.Current = StanceType.Crouching;
      this.Smartphone.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
      this.UpdateAccessory();
      this.UpdateHair();
      this.HandCamera.gameObject.SetActive(false);
      this.Smartphone.targetTexture = (RenderTexture) null;
      this.MainCamera.enabled = false;
      this.Smartphone.cullingMask &= ~(1 << LayerMask.NameToLayer("Miyuki"));
      this.AR = false;
    }
  }

  private void OnApplicationFocus(bool hasFocus) => Cursor.lockState = CursorLockMode.Locked;

  private void OnApplicationPause(bool pauseStatus) => Cursor.lockState = CursorLockMode.None;

  private void AddImpact(Vector3 dir, float force)
  {
    dir.Normalize();
    if ((double) dir.y < 0.0)
      dir.y = -dir.y;
    this.impact += dir.normalized * force / this.mass;
  }

  public int OnlyGroundLayer => 256;

  private void CheckForGround()
  {
    this.RaycastOrigin = this.Zoom.transform;
    Vector3 vector3 = this.RaycastOrigin.TransformDirection(Vector3.up * -1f);
    Debug.DrawRay(this.RaycastOrigin.position, vector3, Color.green);
    if (!Physics.Raycast(this.RaycastOrigin.position, vector3, out this.hit, 1.1f, this.OnlyGroundLayer))
      return;
    Debug.Log((object) "Yandere-chan landed on the ground.");
    this.impact = Vector3.zero;
    this.Jumping = false;
    this.CanMove = true;
  }

  private void UpdateODM()
  {
    if (this.Jumping && ((double) this.CharacterAnimation["ODM_Jump"].time > 0.25 || (double) this.CharacterAnimation["ODM_Slash"].time > 0.0))
    {
      if (Input.GetButtonDown("X") && ((double) this.CharacterAnimation["ODM_Slash"].time == 0.0 || (double) this.CharacterAnimation["ODM_Slash"].time >= (double) this.CharacterAnimation["ODM_Slash"].length))
      {
        AudioSource.PlayClipAtPoint(this.Swoosh, this.transform.position + Vector3.up);
        GameObject gameObject = Object.Instantiate<GameObject>(this.TitanSlash, this.transform.position, Quaternion.identity);
        gameObject.name = "0";
        gameObject.transform.parent = this.Hips;
        gameObject.transform.localPosition = Vector3.zero;
        this.CharacterAnimation["ODM_Slash"].speed = 20f;
        this.CharacterAnimation["ODM_Slash"].time = 0.0f;
        this.CharacterAnimation.CrossFade("ODM_Slash", 0.1f);
        this.transform.localScale = new Vector3(this.transform.localScale.x * -1f, 1f, 1f);
      }
      if ((double) this.CharacterAnimation["ODM_Slash"].time >= (double) this.CharacterAnimation["ODM_Slash"].length)
      {
        this.CharacterAnimation["ODM_Jump"].time = this.CharacterAnimation["ODM_Jump"].length;
        this.CharacterAnimation.CrossFade("ODM_Jump");
      }
      this.CheckForGround();
    }
    if ((double) this.CharacterAnimation["ODM_Jump"].time > 0.25 && (double) this.MyController.velocity.y == 0.0 && (double) this.transform.position.y == 0.0)
    {
      this.Jumping = false;
      this.CanMove = true;
    }
    if ((double) this.impact.magnitude > 0.2)
    {
      int num1 = (int) this.MyController.Move(this.impact * Time.deltaTime);
    }
    int num2 = (int) this.MyController.Move(Physics.gravity * Time.deltaTime * 2f);
    this.impact = Vector3.Lerp(this.impact, Vector3.zero, Time.deltaTime * this.SlowDownSpeed);
    if (!Input.GetButtonDown("A") || (double) this.transform.position.y >= 50.0)
      return;
    AudioSource.PlayClipAtPoint(this.AirBlast, this.transform.position);
    this.v = Input.GetAxis("Vertical");
    this.h = Input.GetAxis("Horizontal");
    Vector3 vector3 = this.MainCamera.transform.TransformDirection(Vector3.forward) with
    {
      y = 0.0f
    };
    vector3 = vector3.normalized;
    this.targetDirection = this.h * new Vector3(vector3.z, 0.0f, -vector3.x) + this.v * vector3;
    if ((double) this.h + (double) this.v != 0.0)
    {
      this.targetRotation = Quaternion.LookRotation(this.targetDirection);
      this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, 360f);
    }
    this.AddImpact(new Vector3(this.targetDirection.x, 1f, this.targetDirection.z), 100f);
    this.CharacterAnimation["ODM_Jump"].speed = 5f;
    this.CharacterAnimation["ODM_Jump"].time = 0.0f;
    this.CharacterAnimation.CrossFade("ODM_Jump", 0.1f);
    this.ODMEffect.Play();
    this.CanMove = false;
    this.Jumping = true;
  }

  private void BecomeRyoba()
  {
    if (this.VtuberID == 0)
    {
      this.MyRenderer.SetBlendShapeWeight(0, 50f);
      this.MyRenderer.SetBlendShapeWeight(5, 25f);
      this.MyRenderer.SetBlendShapeWeight(8, 0.0f);
      this.MyRenderer.SetBlendShapeWeight(12, 100f);
      this.Hairstyle = 203;
      this.UpdateHair();
    }
    this.OriginalIdleAnim = "f02_ryobaIdle_00";
    this.IdleAnim = "f02_ryobaIdle_00";
    this.OriginalWalkAnim = "f02_ryobaWalk_00";
    this.WalkAnim = "f02_ryobaWalk_00";
    this.OriginalRunAnim = "f02_ryobaRun_00";
    this.RunAnim = "f02_ryobaRun_00";
    this.BreastSize = 1.5f;
    this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
    this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
    this.SneakShotButton.alpha = 0.5f;
    this.SneakShotLabel.alpha = 0.0f;
    this.Phone = this.PolaroidOfSenpai;
    this.Laugh1 = this.EightiesLaughs[1];
    this.Laugh2 = this.EightiesLaughs[2];
    this.Laugh3 = this.EightiesLaughs[3];
    this.Laugh4 = this.EightiesLaughs[4];
    this.UniformTextures[6] = this.EightiesUniform;
    this.CasualTextures[6] = this.EightiesCasual;
    this.ModernCamera.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.EightiesCamera.SetActive(true);
  }

  public void LoseGentleEyes()
  {
    if (this.Egg)
      return;
    this.MyRenderer.SetBlendShapeWeight(0, 0.0f);
    this.MyRenderer.SetBlendShapeWeight(5, 0.0f);
    this.MyRenderer.SetBlendShapeWeight(12, 0.0f);
  }

  public void RestoreGentleEyes()
  {
    if (this.Egg || this.VtuberID != 0)
      return;
    this.MyRenderer.SetBlendShapeWeight(0, 50f);
    this.MyRenderer.SetBlendShapeWeight(5, 25f);
    this.MyRenderer.SetBlendShapeWeight(12, 100f);
  }

  public void VtuberFace()
  {
    if (this.Egg)
      return;
    this.LoseGentleEyes();
    this.MyRenderer.SetBlendShapeWeight(0, 100f);
    this.MyRenderer.SetBlendShapeWeight(5, 0.0f);
    this.MyRenderer.SetBlendShapeWeight(8, 0.0f);
    this.MyRenderer.SetBlendShapeWeight(9, 100f);
    this.MyRenderer.SetBlendShapeWeight(12, 0.0f);
  }

  public void UpdateConcealedWeaponStatus()
  {
    this.ConcealedWeaponLabel.alpha = 0.5f;
    if (!((Object) this.Container != (Object) null) || !((Object) this.Container.TrashCan != (Object) null))
      return;
    if ((Object) this.Container.TrashCan.Item != (Object) null)
    {
      this.ConcealedWeaponLabel.text = "Equip Weapon From Bag";
      this.ConcealedWeaponLabel.alpha = 1f;
    }
    else
    {
      if (!this.Armed)
        return;
      this.ConcealedWeaponLabel.text = "Conceal Weapon In Bag";
      this.ConcealedWeaponLabel.alpha = 1f;
    }
  }

  public void VtuberCheck()
  {
    this.VtuberID = GameGlobals.VtuberID;
    if (this.VtuberID != 1)
      return;
    this.FaceTexture = this.VtuberFaces[this.VtuberID];
    this.Hairstyle = 207;
    this.UpdateHair();
    this.VtuberFace();
  }

  public void Cloak()
  {
    this.EightiesPonytailRenderer.material = this.CloakMaterial;
    this.PonytailRenderer.material = this.CloakMaterial;
    this.MyRenderer.materials = this.CloakMaterials;
    this.Outline.h.ReinitMaterials();
    this.Hairstyle = this.StudentManager.Eighties ? 203 : 1;
    this.UpdateHair();
    this.PantyAttacher.newRenderer.enabled = !this.Invisible;
  }

  public void Decloak()
  {
    this.PauseScreen.NewSettings.QualityManager.UpdateOutlinesAndRimlight();
    this.SetUniform();
    this.MyRenderer.materials[0].color = Color.white;
    this.MyRenderer.materials[1].color = Color.white;
    this.MyRenderer.materials[2].color = Color.white;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
    this.MyRenderer.materials[0].SetFloat("_Outline", 1f / 500f);
    this.MyRenderer.materials[1].SetFloat("_Outline", 1f / 500f);
    this.MyRenderer.materials[2].SetFloat("_Outline", 1f / 500f);
    this.PonytailRenderer.material.color = new Color(0.25f, 0.25f, 0.25f, 1f);
    this.PonytailRenderer.material.SetFloat("_Outline", 1f / 500f);
    this.EightiesPonytailRenderer.material.color = new Color(0.25f, 0.25f, 0.25f, 1f);
    this.EightiesPonytailRenderer.material.SetFloat("_Outline", 1f / 500f);
    this.Hairstyle = this.StudentManager.Eighties ? 203 : 1;
    this.UpdateHair();
    this.PantyAttacher.newRenderer.enabled = !this.Invisible;
  }
}
