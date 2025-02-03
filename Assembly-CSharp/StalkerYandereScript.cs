using System;
using Bayat.SaveSystem;
using HighlightingSystem;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class StalkerYandereScript : MonoBehaviour
{
	public NotificationManagerScript NotificationManager;

	public StealthInventoryScript StealthInventory;

	public RiggedAccessoryAttacher PantyAttacher;

	public StalkerPromptScript StalkerDoorPrompt;

	public GameObject StealthClothingAttacher;

	public StreetManagerScript StreetManager;

	public UniformSetterScript UniformSetter;

	public CharacterController MyController;

	public PostProcessingProfile Profile;

	public InputDeviceScript InputDevice;

	public AutoSaveManager SaveManager;

	public UILabel InstructionLabel;

	public StalkerScript Stalker;

	public UIPanel PausePanel;

	public JsonScript JSON;

	public ArcScript Arc;

	public Transform[] TeleportPoint;

	public Transform TrellisClimbSpot;

	public Transform CameraTarget;

	public Transform ObjectTarget;

	public Transform RightHand;

	public Transform EntryPOV;

	public Transform RightArm;

	public Transform Locker;

	public Transform Object;

	public Transform Hips;

	public Renderer PonytailRenderer;

	public GameObject GroundImpact;

	public GameObject PauseScreen;

	public GameObject AreYouSure;

	public GameObject PauseMenu;

	public Animation MyAnimation;

	public RPG_Camera RPGCamera;

	public AudioSource Jukebox;

	public Camera MainCamera;

	public bool Struggling;

	public bool Climbing;

	public bool Running;

	public bool NoChangeClothing;

	public bool HidingInLocker;

	public bool HidePanties;

	public bool Trespassing;

	public bool Invisible;

	public bool Eighties;

	public bool InDesert;

	public bool CanMove;

	public bool Bakery;

	public bool Chased;

	public bool Hidden;

	public bool Street;

	public bool Night;

	public Stance Stance = new Stance(StanceType.Standing);

	public string IdleAnim;

	public string WalkAnim;

	public string RunAnim;

	public string CrouchIdleAnim;

	public string CrouchWalkAnim;

	public string CrouchRunAnim;

	public float WalkSpeed;

	public float RunSpeed;

	public float CrouchWalkSpeed;

	public float CrouchRunSpeed;

	public float Intensity = 0.45f;

	public float Height;

	public int InstructionPhase = 1;

	public int LockerPhase;

	public int ClimbPhase;

	public int Pebbles;

	public int Frame;

	public SkinnedMeshRenderer MyRenderer;

	public GameObject ClothingAttacher;

	public GameObject EightiesAttacher;

	public GameObject RyobaHair;

	public Material Transparent;

	public Texture BlondePony;

	public Mesh HeadOnlyMesh;

	public Transform BreastL;

	public Transform BreastR;

	public AudioSource MyAudio;

	public GameObject Pebble;

	public bool UpdateBlendshapes;

	public bool ThanksForPlaying;

	public bool LethalPoison;

	public bool Initialized;

	public bool Sedative;

	public bool Asylum;

	public bool Cigs;

	public Material SolidBlackMaterial;

	public GameObject Beanie;

	public GameObject Shades;

	public GameObject Mask;

	public GameObject[] YandereVisionEye;

	private int UpdateFrame;

	public UILabel KeyboardControls;

	public UILabel GamepadControls;

	public GameObject ShoulderCamera;

	public NewArcScript NewArc;

	public bool UsingController;

	public float PrepareThrowTimer;

	public bool PreparingThrow;

	public bool Throwing;

	public Texture NoPan;

	public Texture Shadow;

	public CameraFilterPack_Colors_Adjust_PreFilters YandereFilter;

	public HighlightingRenderer HighlightingR;

	public HighlightingBlitter HighlightingB;

	public GameObject ThrowButton;

	public GameObject PebbleIcon;

	public GameObject AimButton;

	public UILabel PebbleLabel;

	public GameObject[] OriginalHairs;

	public GameObject[] VtuberHairs;

	public GameObject[] VtuberAccs;

	public Texture[] VtuberFaces;

	public bool UpdateTextures;

	public bool Vtuber;

	public void Start()
	{
		if (Asylum)
		{
			HomeGlobals.Night = true;
		}
		Night = HomeGlobals.Night;
		HidePanties = GameGlobals.CensorPanties;
		if (!OptionGlobals.Vsync)
		{
			QualitySettings.vSyncCount = 0;
		}
		else
		{
			QualitySettings.vSyncCount = 1;
		}
		if (BlondePony != null && GameGlobals.BlondeHair)
		{
			PonytailRenderer.material.mainTexture = BlondePony;
		}
		if (GameGlobals.Eighties)
		{
			Eighties = true;
		}
		else
		{
			PonytailRenderer.transform.parent.gameObject.SetActive(value: true);
			if (RyobaHair != null)
			{
				RyobaHair.SetActive(value: false);
			}
		}
		if (Street && GameGlobals.CustomMode)
		{
			float breastSize = JSON.Students[0].BreastSize;
			BreastL.transform.localScale = new Vector3(breastSize, breastSize, breastSize);
			BreastR.transform.localScale = new Vector3(breastSize, breastSize, breastSize);
			StealthClothingAttacher.SetActive(value: true);
			MyRenderer.enabled = false;
			Beanie.SetActive(value: true);
			Shades.SetActive(value: true);
			Mask.SetActive(value: true);
		}
		else if (GameGlobals.Eighties && EightiesAttacher != null)
		{
			if (HomeGlobals.Night || DateGlobals.Weekday == DayOfWeek.Sunday || DateGlobals.Weekday == DayOfWeek.Saturday)
			{
				EightiesAttacher.SetActive(value: true);
			}
			else
			{
				Debug.Log("Daytime or weekend. Staying in school uniform.");
				UniformSetter.enabled = true;
				BreastL.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				BreastR.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			}
			MyRenderer.sharedMesh = HeadOnlyMesh;
			PonytailRenderer.transform.parent.gameObject.SetActive(value: false);
			RyobaHair.SetActive(value: true);
			Debug.Log("Setting Ryoba blendshapes.");
			MyRenderer.SetBlendShapeWeight(0, 50f);
			MyRenderer.SetBlendShapeWeight(5, 25f);
			MyRenderer.SetBlendShapeWeight(8, 0f);
			MyRenderer.SetBlendShapeWeight(12, 100f);
			IdleAnim = "f02_ryobaIdle_00";
			WalkAnim = "f02_ryobaWalk_00";
			RunAnim = "f02_ryobaRun_00";
			MyRenderer.materials[0].mainTexture = MyRenderer.materials[2].mainTexture;
			Eighties = true;
		}
		else
		{
			if (!Asylum)
			{
				BreastL.transform.localScale = new Vector3(1f, 1f, 1f);
				BreastR.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			if (!NoChangeClothing && ClothingAttacher != null && !Initialized)
			{
				if ((!Asylum && HomeGlobals.Night) || DateGlobals.Weekday == DayOfWeek.Sunday || DateGlobals.Weekday == DayOfWeek.Saturday)
				{
					if (UniformSetter != null)
					{
						UniformSetter.Ryoba = GameGlobals.Eighties;
					}
					ClothingAttacher.SetActive(value: true);
					MyRenderer.gameObject.SetActive(value: false);
				}
				else if (!Asylum)
				{
					Debug.Log("Daytime or weekend. Staying in school uniform.");
					if (UniformSetter != null)
					{
						UniformSetter.Ryoba = false;
						UniformSetter.enabled = true;
					}
				}
				else
				{
					MyRenderer.gameObject.SetActive(value: false);
					if (GameGlobals.CustomMode)
					{
						BreastL.transform.localScale = new Vector3(1f, 1f, 1f);
						BreastR.transform.localScale = new Vector3(1f, 1f, 1f);
						RyobaHair.SetActive(value: false);
						Beanie.SetActive(value: true);
						Shades.SetActive(value: true);
						Mask.SetActive(value: true);
					}
				}
				Initialized = true;
			}
			UpdatePebbles();
		}
		VtuberCheck();
		if (Asylum)
		{
			MyAnimation["f02_prepareThrow_00"].layer = 1;
			MyAnimation.Play("f02_prepareThrow_00");
			MyAnimation["f02_prepareThrow_00"].weight = 0f;
		}
		UpdateBlendshapes = true;
	}

	private void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (UpdateTextures)
		{
			if (UpdateFrame == 1 && !Vtuber)
			{
				Debug.Log("Attempting to update textures...");
				if (ClothingAttacher != null && ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
				{
					Debug.Log("ClothingAttacher was not null.");
					MyRenderer = ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
					MyRenderer.materials[1].mainTexture = VtuberFaces[GameGlobals.VtuberID];
				}
				else
				{
					Debug.Log("ClothingAttacher was null.");
					for (int i = 0; i < 13; i++)
					{
						MyRenderer.SetBlendShapeWeight(i, 0f);
					}
					MyRenderer.SetBlendShapeWeight(0, 100f);
					MyRenderer.SetBlendShapeWeight(9, 100f);
					if (Eighties && Street)
					{
						MyRenderer.materials[0].mainTexture = VtuberFaces[GameGlobals.VtuberID];
						MyRenderer.materials[1].mainTexture = VtuberFaces[GameGlobals.VtuberID];
						MyRenderer.materials[2].mainTexture = VtuberFaces[GameGlobals.VtuberID];
					}
				}
				UpdateTextures = false;
			}
			UpdateFrame++;
		}
		if (UpdateBlendshapes)
		{
			if (Eighties)
			{
				if (!Asylum)
				{
					if (EightiesAttacher != null && EightiesAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
					{
						MyRenderer = EightiesAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
					}
				}
				else
				{
					MyRenderer = ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
				}
				if (!Street)
				{
					MyRenderer.SetBlendShapeWeight(0, 50f);
					MyRenderer.SetBlendShapeWeight(5, 25f);
					MyRenderer.SetBlendShapeWeight(8, 0f);
					MyRenderer.SetBlendShapeWeight(12, 100f);
				}
				UpdateBlendshapes = false;
			}
			else if (HomeGlobals.Night && !ThanksForPlaying && ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
			{
				MyRenderer = ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
				MyRenderer.SetBlendShapeWeight(8, 50f);
				UpdateBlendshapes = false;
			}
		}
		if (Input.GetKeyDown("m") && Jukebox != null)
		{
			if (Jukebox.isPlaying)
			{
				Jukebox.Stop();
			}
			else
			{
				Jukebox.Play();
			}
		}
		if (CanMove)
		{
			if (InstructionLabel != null)
			{
				InstructionLabel.alpha = Mathf.MoveTowards(InstructionLabel.alpha, 1f, Time.deltaTime);
			}
			if (CameraTarget != null)
			{
				CameraTarget.localPosition = new Vector3(0f, 1f + (RPGCamera.distanceMax - RPGCamera.distance) * 0.2f, 0f);
			}
			if (InDesert && base.transform.position.y < 13.7f)
			{
				UnityEngine.Object.Instantiate(GroundImpact, base.transform.position + new Vector3(0f, 0.1f, 0f), Quaternion.identity);
				InDesert = false;
			}
			UpdateMovement();
			if (Pebbles > 0)
			{
				if (InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (!GamepadControls.enabled)
					{
						KeyboardControls.enabled = false;
						GamepadControls.enabled = true;
					}
				}
				else if (!KeyboardControls.enabled)
				{
					KeyboardControls.enabled = true;
					GamepadControls.enabled = false;
				}
			}
			UpdateAim();
		}
		else
		{
			if (InstructionLabel != null)
			{
				InstructionLabel.alpha = Mathf.MoveTowards(InstructionLabel.alpha, 0f, Time.deltaTime);
			}
			if (CameraTarget != null)
			{
				if (Climbing)
				{
					if (ClimbPhase == 1)
					{
						if (MyAnimation["f02_climbTrellis_00"].time < MyAnimation["f02_climbTrellis_00"].length - 1f)
						{
							CameraTarget.position = Vector3.MoveTowards(CameraTarget.position, Hips.position + new Vector3(0f, 0.103729f, 0.003539f), Time.deltaTime);
						}
						else
						{
							CameraTarget.position = Vector3.MoveTowards(CameraTarget.position, new Vector3(-9.5f, 5f, -2.5f), Time.deltaTime);
						}
						if (MyAnimation["f02_climbTrellis_00"].time < 1f)
						{
							Time.timeScale = 1f;
							MoveTowardsTarget(TrellisClimbSpot.position);
							SpinTowardsTarget(TrellisClimbSpot.rotation);
						}
						else
						{
							base.transform.position = TrellisClimbSpot.position;
							base.transform.rotation = TrellisClimbSpot.rotation;
						}
						if (MyAnimation["f02_climbTrellis_00"].time > 7.5f)
						{
							RPGCamera.transform.position = EntryPOV.position;
							RPGCamera.transform.eulerAngles = EntryPOV.eulerAngles;
							RPGCamera.enabled = false;
							RenderSettings.ambientIntensity = 8f;
							ClimbPhase++;
						}
					}
					else
					{
						RPGCamera.transform.position = EntryPOV.position;
						RPGCamera.transform.eulerAngles = EntryPOV.eulerAngles;
						if (MyAnimation["f02_climbTrellis_00"].time > 11f)
						{
							base.transform.position = Vector3.MoveTowards(base.transform.position, TrellisClimbSpot.position + new Vector3(0.4f, 0f, 0f), Time.deltaTime * 0.5f);
						}
					}
					if (MyAnimation["f02_climbTrellis_00"].time > MyAnimation["f02_climbTrellis_00"].length)
					{
						MyAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(-9.1f, 4f, -2.5f);
						CameraTarget.position = base.transform.position + new Vector3(0f, 1f, 0f);
						RPGCamera.enabled = true;
						Climbing = false;
						CanMove = true;
						Physics.SyncTransforms();
					}
				}
				else if (Chased)
				{
					Quaternion b = Quaternion.LookRotation(Stalker.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 10f * Time.deltaTime);
				}
				else if (HidingInLocker)
				{
					if (LockerPhase == 1)
					{
						MoveTowardsTarget(Locker.position + Locker.forward * 0.5f);
						base.transform.LookAt(Locker.position);
						MyAnimation.CrossFade("f02_enterLocker_00");
						if (MyAnimation["f02_enterLocker_00"].time >= MyAnimation["f02_enterLocker_00"].length)
						{
							MyAnimation.CrossFade("f02_idleLocker_00");
							LockerPhase = 2;
						}
					}
					else if (LockerPhase == 3)
					{
						MyAnimation.CrossFade("f02_exitLocker_00");
						if (MyAnimation["f02_exitLocker_00"].time >= MyAnimation["f02_exitLocker_00"].length)
						{
							MyAnimation.CrossFade(IdleAnim);
							HidingInLocker = false;
							CanMove = true;
						}
					}
				}
			}
			UpdateThrow();
		}
		if (YandereFilter != null)
		{
			UpdateYandereVision();
		}
		if (Street && base.transform.position.x < -16f)
		{
			base.transform.position = new Vector3(-16f, 0f, base.transform.position.z);
		}
		if (Profile != null)
		{
			if (Stance.Current == StanceType.Crouching && Hidden)
			{
				if (Intensity != 1f)
				{
					Intensity = Mathf.MoveTowards(Intensity, 1f, Time.deltaTime);
					UpdateVignette();
				}
			}
			else if (Intensity != 0.45f)
			{
				Intensity = Mathf.MoveTowards(Intensity, 0.45f, Time.deltaTime);
				UpdateVignette();
			}
		}
		if (InstructionLabel != null)
		{
			if (!Bakery)
			{
				if (InstructionPhase == 1)
				{
					if (base.transform.position.z < 11f && base.transform.position.z > -11f && base.transform.position.x > -11f && base.transform.position.x < 11f)
					{
						InstructionLabel.text = "Find the stalker's room on the first floor of the house.";
						InstructionPhase++;
					}
				}
				else if (InstructionPhase == 2)
				{
					if (StalkerDoorPrompt.OpenDoor)
					{
						InstructionLabel.text = "Pick up the pet carrier.";
						InstructionPhase++;
					}
				}
				else if (InstructionPhase == 3 && Object != null)
				{
					InstructionLabel.text = "Exit the house.";
					InstructionPhase++;
				}
			}
			else if (InstructionPhase == 1 && base.transform.position.z < 10f && base.transform.position.z > -10f && base.transform.position.x > -10f && base.transform.position.x < 10f)
			{
				InstructionLabel.text = "Search the bakery for evidence of criminal activity.";
				InstructionPhase++;
			}
		}
		if (Bakery)
		{
			if (base.transform.position.x > 21f || (base.transform.position.x > -10.61f && base.transform.position.x < 3.365f && base.transform.position.z > 39.24f) || (base.transform.position.x > -10.3f && base.transform.position.x < 10.3f && base.transform.position.z > -10.3f && base.transform.position.z < 10.3f))
			{
				if (!Trespassing)
				{
					NotificationManager.CustomText = "You are now trespassing!";
					NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				Trespassing = true;
			}
			else if (base.transform.position.y < 1f)
			{
				if (Trespassing)
				{
					NotificationManager.CustomText = "You are no longer trespassing.";
					NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				Trespassing = false;
			}
		}
		if (Street)
		{
			if (!(PauseScreen != null) || !CanMove)
			{
				return;
			}
			if (!PauseScreen.activeInHierarchy)
			{
				if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown(InputNames.Xbox_Start))
				{
					PauseScreen.SetActive(value: true);
					Time.timeScale = 0.0001f;
				}
			}
			else if (PauseMenu.activeInHierarchy)
			{
				if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown(InputNames.Xbox_Start))
				{
					PauseScreen.SetActive(value: false);
					Time.timeScale = 1f;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_X))
				{
					PauseMenu.SetActive(value: false);
					AreYouSure.SetActive(value: true);
				}
				else if (Input.GetButtonDown(InputNames.Xbox_Y))
				{
					if (StreetManager.Sunlight.shadows != 0)
					{
						StreetManager.Sunlight.shadows = LightShadows.None;
					}
					else
					{
						StreetManager.Sunlight.shadows = LightShadows.Soft;
					}
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				SceneManager.LoadScene("NewTitleScene");
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PauseMenu.SetActive(value: true);
				AreYouSure.SetActive(value: false);
			}
		}
		else if (PausePanel != null && PausePanel.enabled && CanMove)
		{
			if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				SceneManager.LoadScene("HomeScene");
			}
		}
	}

	private void UpdateAim()
	{
		if ((Input.GetAxis(InputNames.Xbox_LT) > 0.5f || Input.GetMouseButton(InputNames.Mouse_RMB)) && Pebbles > 0 && !PreparingThrow && !Throwing)
		{
			base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, MainCamera.transform.eulerAngles.y, base.transform.eulerAngles.z);
			PreparingThrow = true;
			PrepareThrowTimer = 0f;
			RPGCamera.enabled = false;
			ShoulderCamera.SetActive(value: true);
			MainCamera.transform.position = Vector3.zero;
			MainCamera.transform.eulerAngles = Vector3.zero;
			if (Input.GetAxis(InputNames.Xbox_LT) > 0.5f)
			{
				UsingController = true;
			}
			NewArc.gameObject.SetActive(value: true);
		}
		if (!PreparingThrow || !(Time.timeScale > 0.0001f))
		{
			return;
		}
		if (Input.GetAxis(InputNames.Xbox_RT) > 0.5f || Input.GetMouseButtonDown(InputNames.Mouse_LMB) || Input.GetButtonDown(InputNames.Xbox_A))
		{
			MyAnimation["f02_prepareThrow_00"].weight = 0f;
			MyAnimation["f02_throw_00"].speed = 2f;
			MyAnimation["f02_throw_00"].time = 0f;
			MyAnimation.Play("f02_throw_00");
			PreparingThrow = false;
			Throwing = true;
			CanMove = false;
			NewArc.gameObject.SetActive(value: false);
			MyAudio.Play();
			Rigidbody component = UnityEngine.Object.Instantiate(Pebble, Arc.transform.position, base.transform.rotation).GetComponent<Rigidbody>();
			component.isKinematic = false;
			component.useGravity = true;
			component.AddRelativeForce(Vector3.forward * NewArc.ForwardMomentum, ForceMode.VelocityChange);
			Pebbles--;
			UpdatePebbles();
			if (Pebbles < 1)
			{
				Arc.gameObject.SetActive(value: false);
			}
		}
		else if ((UsingController && Input.GetAxis(InputNames.Xbox_LT) < 0.5f) || (!UsingController && !Input.GetMouseButton(InputNames.Mouse_RMB)))
		{
			StopAiming();
		}
	}

	public void UpdateThrow()
	{
		if (Throwing && MyAnimation["f02_throw_00"].time >= MyAnimation["f02_throw_00"].length)
		{
			Throwing = false;
			CanMove = true;
			if (Pebbles == 0)
			{
				Debug.Log("Was out of ammo.");
				StopAiming();
			}
			else
			{
				MyAnimation["f02_prepareThrow_00"].weight = 1f;
				PreparingThrow = true;
				NewArc.gameObject.SetActive(value: true);
			}
		}
	}

	public void StopAiming()
	{
		ShoulderCamera.SetActive(value: false);
		RPGCamera.enabled = true;
		UsingController = false;
		PreparingThrow = false;
		PrepareThrowTimer = 0f;
		Throwing = false;
		NewArc.gameObject.SetActive(value: false);
	}

	private void LateUpdate()
	{
		if (Asylum)
		{
			if (PreparingThrow)
			{
				if (PrepareThrowTimer < 1f)
				{
					PrepareThrowTimer += Time.deltaTime;
					MyAnimation["f02_prepareThrow_00"].weight = Mathf.MoveTowards(MyAnimation["f02_prepareThrow_00"].weight, 1f, Time.deltaTime * 10f);
				}
			}
			else if (PrepareThrowTimer < 1f)
			{
				PrepareThrowTimer += Time.deltaTime;
				MyAnimation["f02_prepareThrow_00"].weight = Mathf.MoveTowards(MyAnimation["f02_prepareThrow_00"].weight, 0f, Time.deltaTime * 10f);
			}
		}
		if (Object != null)
		{
			if (RightArm != null)
			{
				RightArm.localEulerAngles = new Vector3(RightArm.localEulerAngles.x, RightArm.localEulerAngles.y + 15f, RightArm.localEulerAngles.z);
			}
			Object.LookAt(ObjectTarget);
		}
		if (!Street || !HidePanties)
		{
			return;
		}
		PantyAttacher.newRenderer.enabled = false;
		if (!Night)
		{
			if (MyRenderer.materials[0].GetTexture("_OverlayTex") == NoPan)
			{
				MyRenderer.materials[0].SetTexture("_OverlayTex", Shadow);
			}
			if (MyRenderer.materials[1].GetTexture("_OverlayTex") == NoPan)
			{
				MyRenderer.materials[1].SetTexture("_OverlayTex", Shadow);
			}
			if (MyRenderer.materials[2].GetTexture("_OverlayTex") == NoPan)
			{
				MyRenderer.materials[2].SetTexture("_OverlayTex", Shadow);
			}
			HidePanties = false;
		}
		else
		{
			MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
		}
		HidePanties = false;
	}

	private void UpdateMovement()
	{
		if (!OptionGlobals.ToggleRun)
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
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		if (!PreparingThrow)
		{
			Vector3 vector = MainCamera.transform.TransformDirection(Vector3.forward);
			vector.y = 0f;
			vector = vector.normalized;
			Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
			Vector3 vector3 = axis2 * vector2 + axis * vector;
			Quaternion b = Quaternion.identity;
			if (vector3 != Vector3.zero)
			{
				b = Quaternion.LookRotation(vector3);
			}
			if (vector3 != Vector3.zero)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
			}
			else
			{
				b = new Quaternion(0f, 0f, 0f, 0f);
			}
			if (!Street)
			{
				if (Stance.Current == StanceType.Standing)
				{
					if (Input.GetButtonDown(InputNames.Xbox_RS))
					{
						Stance.Current = StanceType.Crouching;
						MyController.center = new Vector3(0f, 0.5f, 0f);
						MyController.height = 1f;
					}
				}
				else if (Input.GetButtonDown(InputNames.Xbox_RS))
				{
					Stance.Current = StanceType.Standing;
					MyController.center = new Vector3(0f, 0.75f, 0f);
					MyController.height = 1.5f;
				}
			}
			if (axis != 0f || axis2 != 0f)
			{
				if (Running)
				{
					if (Stance.Current == StanceType.Crouching)
					{
						MyAnimation.CrossFade(CrouchRunAnim);
						MyController.Move(base.transform.forward * CrouchRunSpeed * Time.deltaTime);
					}
					else
					{
						MyAnimation.CrossFade(RunAnim);
						MyController.Move(base.transform.forward * RunSpeed * Time.deltaTime);
					}
				}
				else if (Stance.Current == StanceType.Crouching)
				{
					MyAnimation.CrossFade(CrouchWalkAnim);
					MyController.Move(base.transform.forward * (CrouchWalkSpeed * Time.deltaTime));
				}
				else
				{
					MyAnimation.CrossFade(WalkAnim);
					MyController.Move(base.transform.forward * (WalkSpeed * Time.deltaTime));
				}
			}
			else if (Stance.Current == StanceType.Crouching)
			{
				MyAnimation.CrossFade(CrouchIdleAnim);
			}
			else
			{
				MyAnimation.CrossFade(IdleAnim);
			}
			return;
		}
		if (axis != 0f || axis2 != 0f)
		{
			if (Stance.Current == StanceType.Crouching)
			{
				MyAnimation.CrossFade(CrouchWalkAnim);
				MyController.Move(base.transform.forward * (CrouchWalkSpeed * Time.deltaTime * axis));
				MyController.Move(base.transform.right * (CrouchWalkSpeed * Time.deltaTime * axis2));
			}
			else
			{
				MyAnimation.CrossFade(WalkAnim);
				MyController.Move(base.transform.forward * (WalkSpeed * Time.deltaTime * axis));
				MyController.Move(base.transform.right * (WalkSpeed * Time.deltaTime * axis2));
			}
		}
		else if (Stance.Current == StanceType.Crouching)
		{
			MyAnimation.CrossFade(CrouchIdleAnim);
		}
		else
		{
			MyAnimation.CrossFade(IdleAnim);
		}
		string axisName = "Mouse X";
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			axisName = InputNames.Xbox_JoyX;
		}
		if (!RPGCamera.invertAxisX)
		{
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + Input.GetAxis(axisName) * RPGCamera.sensitivity * 72f * Time.deltaTime, base.transform.localEulerAngles.z);
		}
		else
		{
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y - Input.GetAxis(axisName) * RPGCamera.sensitivity * 72f * Time.deltaTime, base.transform.localEulerAngles.z);
		}
	}

	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 vector = target - base.transform.position;
		MyController.Move(vector * (Time.deltaTime * 10f));
	}

	private void SpinTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	public void UpdateVignette()
	{
		VignetteModel.Settings settings = Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = Intensity;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		Profile.vignette.settings = settings;
	}

	public void BeginStruggle()
	{
		MyAnimation.CrossFade("f02_struggleA_00");
		Struggling = true;
		Object.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		Object.gameObject.GetComponent<Rigidbody>().useGravity = true;
		Object.gameObject.GetComponent<Collider>().isTrigger = false;
		Object.parent = null;
		Object = null;
	}

	public void UpdateYandereVision()
	{
		bool flag = Input.GetButton(InputNames.Xbox_RB);
		if (Time.timeScale == 0f)
		{
			flag = false;
		}
		if (CanMove && flag)
		{
			if (YandereFilter.FadeFX < 1f)
			{
				if (!HighlightingR.enabled)
				{
					YandereVisionEye[0].SetActive(value: true);
					YandereVisionEye[1].SetActive(value: true);
					YandereFilter.enabled = true;
					HighlightingR.enabled = true;
					HighlightingB.enabled = true;
				}
				Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, Time.unscaledDeltaTime * 10f);
				YandereFilter.FadeFX = Mathf.Lerp(YandereFilter.FadeFX, 1f, Time.unscaledDeltaTime * 10f);
				if (YandereFilter.FadeFX == 1f)
				{
					Time.timeScale = 0.5f;
				}
			}
		}
		else if (YandereFilter.FadeFX > 0f)
		{
			if (HighlightingR.enabled)
			{
				YandereVisionEye[0].SetActive(value: false);
				YandereVisionEye[1].SetActive(value: false);
				HighlightingR.enabled = false;
				HighlightingB.enabled = false;
			}
			Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.unscaledDeltaTime * 10f);
			YandereFilter.FadeFX = Mathf.Lerp(YandereFilter.FadeFX, 0f, Time.unscaledDeltaTime * 10f);
			if (YandereFilter.FadeFX == 0f)
			{
				Time.timeScale = 1f;
			}
		}
	}

	public void ResetYandereEffects()
	{
		HighlightingR.enabled = false;
		HighlightingB.enabled = false;
		YandereFilter.enabled = true;
		YandereFilter.FadeFX = 0f;
		Time.timeScale = 1f;
		Intensity = 0f;
		UpdateVignette();
	}

	public void UpdatePebbles()
	{
		if (PebbleIcon != null)
		{
			if (Pebbles == 0)
			{
				PebbleIcon.SetActive(value: false);
				return;
			}
			PebbleIcon.SetActive(value: true);
			PebbleLabel.text = "PEBBLES: " + Pebbles;
		}
	}

	public void VtuberCheck()
	{
		for (int i = 1; i < VtuberHairs.Length; i++)
		{
			VtuberHairs[i].SetActive(value: false);
			VtuberAccs[i].SetActive(value: false);
		}
		if (GameGlobals.VtuberID <= 0)
		{
			return;
		}
		for (int j = 1; j < OriginalHairs.Length; j++)
		{
			OriginalHairs[j].transform.localPosition = new Vector3(0f, 100f, 0f);
		}
		VtuberHairs[GameGlobals.VtuberID].SetActive(value: true);
		VtuberAccs[GameGlobals.VtuberID].SetActive(value: true);
		if (ClothingAttacher != null && ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
		{
			MyRenderer = ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
			MyRenderer.materials[1].mainTexture = VtuberFaces[GameGlobals.VtuberID];
		}
		else
		{
			MyRenderer.materials[2].mainTexture = VtuberFaces[GameGlobals.VtuberID];
			for (int j = 0; j < 13; j++)
			{
				MyRenderer.SetBlendShapeWeight(j, 0f);
			}
			MyRenderer.SetBlendShapeWeight(0, 100f);
			if (GameGlobals.VtuberID == 1)
			{
				MyRenderer.SetBlendShapeWeight(9, 100f);
			}
		}
		if (GameGlobals.VtuberID == 2)
		{
			IdleAnim = "f02_ryobaIdle_00";
			WalkAnim = "f02_ryobaWalk_00";
			RunAnim = "f02_ryobaRun_00";
		}
		UpdateTextures = true;
		Vtuber = true;
	}
}
