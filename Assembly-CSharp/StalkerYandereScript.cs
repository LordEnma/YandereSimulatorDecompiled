using System;
using Bayat.SaveSystem;
using HighlightingSystem;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000441 RID: 1089
public class StalkerYandereScript : MonoBehaviour
{
	// Token: 0x06001D02 RID: 7426 RVA: 0x0015A2D8 File Offset: 0x001584D8
	public void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (this.BlondePony != null && GameGlobals.BlondeHair)
		{
			this.PonytailRenderer.material.mainTexture = this.BlondePony;
		}
		if (GameGlobals.Eighties)
		{
			this.Eighties = true;
		}
		if (GameGlobals.Eighties && this.EightiesAttacher != null)
		{
			this.EightiesAttacher.SetActive(true);
			this.MyRenderer.sharedMesh = this.HeadOnlyMesh;
			this.PonytailRenderer.gameObject.SetActive(false);
			this.RyobaHair.SetActive(true);
			this.MyRenderer.SetBlendShapeWeight(0, 50f);
			this.MyRenderer.SetBlendShapeWeight(5, 25f);
			this.MyRenderer.SetBlendShapeWeight(9, 0f);
			this.MyRenderer.SetBlendShapeWeight(12, 100f);
			this.IdleAnim = "f02_ryobaIdle_00";
			this.WalkAnim = "f02_ryobaWalk_00";
			this.RunAnim = "f02_ryobaRun_00";
			this.MyRenderer.materials[0].mainTexture = this.MyRenderer.materials[2].mainTexture;
			this.Eighties = true;
			return;
		}
		if (!this.Asylum)
		{
			this.BreastL.transform.localScale = new Vector3(1f, 1f, 1f);
			this.BreastR.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		if (this.ClothingAttacher != null)
		{
			this.ClothingAttacher.SetActive(true);
			this.MyRenderer.gameObject.SetActive(false);
		}
		this.UpdatePebbles();
	}

	// Token: 0x06001D03 RID: 7427 RVA: 0x0015A494 File Offset: 0x00158694
	private void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (Input.GetKeyDown("m") && this.Jukebox != null)
		{
			if (this.Jukebox.isPlaying)
			{
				this.Jukebox.Stop();
			}
			else
			{
				this.Jukebox.Play();
			}
		}
		if (this.CanMove)
		{
			if (this.CameraTarget != null)
			{
				this.CameraTarget.localPosition = new Vector3(0f, 1f + (this.RPGCamera.distanceMax - this.RPGCamera.distance) * 0.2f, 0f);
			}
			if (this.InDesert && base.transform.position.y < 13.7f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.GroundImpact, base.transform.position + new Vector3(0f, 0.1f, 0f), Quaternion.identity);
				this.InDesert = false;
			}
			this.UpdateMovement();
			if (this.YandereFilter != null)
			{
				this.UpdateYandereVision();
			}
			if (this.Pebbles > 0)
			{
				if (!this.Arc.gameObject.activeInHierarchy)
				{
					this.Arc.Timer = 1f;
				}
				this.Arc.gameObject.SetActive(Input.GetButton("X"));
				if (this.Arc.gameObject.activeInHierarchy)
				{
					this.ThrowButton.SetActive(true);
					this.AimButton.SetActive(false);
					if (Input.GetButtonDown("A"))
					{
						this.MyAudio.Play();
						Rigidbody component = UnityEngine.Object.Instantiate<GameObject>(this.Pebble, this.Arc.transform.position, base.transform.rotation).GetComponent<Rigidbody>();
						component.isKinematic = false;
						component.useGravity = true;
						component.AddRelativeForce(Vector3.up * 250f);
						component.AddRelativeForce(Vector3.forward * 250f);
						this.Pebbles--;
						this.UpdatePebbles();
						if (this.Pebbles < 1)
						{
							this.Arc.gameObject.SetActive(false);
						}
					}
				}
				else
				{
					this.ThrowButton.SetActive(false);
					this.AimButton.SetActive(true);
				}
			}
		}
		else if (this.CameraTarget != null)
		{
			if (this.Climbing)
			{
				if (this.ClimbPhase == 1)
				{
					if (this.MyAnimation["f02_climbTrellis_00"].time < this.MyAnimation["f02_climbTrellis_00"].length - 1f)
					{
						this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, this.Hips.position + new Vector3(0f, 0.103729f, 0.003539f), Time.deltaTime);
					}
					else
					{
						this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(-9.5f, 5f, -2.5f), Time.deltaTime);
					}
					this.MoveTowardsTarget(this.TrellisClimbSpot.position);
					this.SpinTowardsTarget(this.TrellisClimbSpot.rotation);
					if (this.MyAnimation["f02_climbTrellis_00"].time > 7.5f)
					{
						this.RPGCamera.transform.position = this.EntryPOV.position;
						this.RPGCamera.transform.eulerAngles = this.EntryPOV.eulerAngles;
						this.RPGCamera.enabled = false;
						RenderSettings.ambientIntensity = 8f;
						this.ClimbPhase++;
					}
				}
				else
				{
					this.RPGCamera.transform.position = this.EntryPOV.position;
					this.RPGCamera.transform.eulerAngles = this.EntryPOV.eulerAngles;
					if (this.MyAnimation["f02_climbTrellis_00"].time > 11f)
					{
						base.transform.position = Vector3.MoveTowards(base.transform.position, this.TrellisClimbSpot.position + new Vector3(0.4f, 0f, 0f), Time.deltaTime * 0.5f);
					}
				}
				if (this.MyAnimation["f02_climbTrellis_00"].time > this.MyAnimation["f02_climbTrellis_00"].length)
				{
					this.MyAnimation.Play("f02_idleShort_00");
					base.transform.position = new Vector3(-9.1f, 4f, -2.5f);
					this.CameraTarget.position = base.transform.position + new Vector3(0f, 1f, 0f);
					this.RPGCamera.enabled = true;
					this.Climbing = false;
					this.CanMove = true;
					Physics.SyncTransforms();
				}
			}
			else if (this.Chased)
			{
				Quaternion b = Quaternion.LookRotation(this.Stalker.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 10f * Time.deltaTime);
			}
		}
		if (this.Street && base.transform.position.x < -16f)
		{
			base.transform.position = new Vector3(-16f, 0f, base.transform.position.z);
		}
		if (this.Profile != null)
		{
			if (this.Stance.Current == StanceType.Crouching && this.Hidden)
			{
				if (this.Intensity != 1f)
				{
					this.Intensity = Mathf.MoveTowards(this.Intensity, 1f, Time.deltaTime);
					this.UpdateVignette();
					return;
				}
			}
			else if (this.Intensity != 0.45f)
			{
				this.Intensity = Mathf.MoveTowards(this.Intensity, 0.45f, Time.deltaTime);
				this.UpdateVignette();
			}
		}
	}

	// Token: 0x06001D04 RID: 7428 RVA: 0x0015AADC File Offset: 0x00158CDC
	private void UpdateMovement()
	{
		if (!OptionGlobals.ToggleRun)
		{
			this.Running = false;
			if (Input.GetButton("LB"))
			{
				this.Running = true;
			}
		}
		else if (Input.GetButtonDown("LB"))
		{
			this.Running = !this.Running;
		}
		this.MyController.Move(Physics.gravity * Time.deltaTime);
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		Vector3 vector = this.MainCamera.transform.TransformDirection(Vector3.forward);
		vector.y = 0f;
		vector = vector.normalized;
		Vector3 a = new Vector3(vector.z, 0f, -vector.x);
		Vector3 vector2 = axis2 * a + axis * vector;
		Quaternion b = Quaternion.identity;
		if (vector2 != Vector3.zero)
		{
			b = Quaternion.LookRotation(vector2);
		}
		if (vector2 != Vector3.zero)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
		}
		else
		{
			b = new Quaternion(0f, 0f, 0f, 0f);
		}
		if (!this.Street)
		{
			if (this.Stance.Current == StanceType.Standing)
			{
				if (Input.GetButtonDown("RS"))
				{
					this.Stance.Current = StanceType.Crouching;
					this.MyController.center = new Vector3(0f, 0.5f, 0f);
					this.MyController.height = 1f;
				}
			}
			else if (Input.GetButtonDown("RS"))
			{
				this.Stance.Current = StanceType.Standing;
				this.MyController.center = new Vector3(0f, 0.75f, 0f);
				this.MyController.height = 1.5f;
			}
		}
		if (axis != 0f || axis2 != 0f)
		{
			if (this.Running)
			{
				if (this.Stance.Current == StanceType.Crouching)
				{
					this.MyAnimation.CrossFade(this.CrouchRunAnim);
					this.MyController.Move(base.transform.forward * this.CrouchRunSpeed * Time.deltaTime);
					return;
				}
				this.MyAnimation.CrossFade(this.RunAnim);
				this.MyController.Move(base.transform.forward * this.RunSpeed * Time.deltaTime);
				return;
			}
			else
			{
				if (this.Stance.Current == StanceType.Crouching)
				{
					this.MyAnimation.CrossFade(this.CrouchWalkAnim);
					this.MyController.Move(base.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime));
					return;
				}
				this.MyAnimation.CrossFade(this.WalkAnim);
				this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
				return;
			}
		}
		else
		{
			if (this.Stance.Current == StanceType.Crouching)
			{
				this.MyAnimation.CrossFade(this.CrouchIdleAnim);
				return;
			}
			this.MyAnimation.CrossFade(this.IdleAnim);
			return;
		}
	}

	// Token: 0x06001D05 RID: 7429 RVA: 0x0015AE28 File Offset: 0x00159028
	private void LateUpdate()
	{
		if (this.Object != null)
		{
			if (this.RightArm != null)
			{
				this.RightArm.localEulerAngles = new Vector3(this.RightArm.localEulerAngles.x, this.RightArm.localEulerAngles.y + 15f, this.RightArm.localEulerAngles.z);
			}
			this.Object.LookAt(this.ObjectTarget);
		}
	}

	// Token: 0x06001D06 RID: 7430 RVA: 0x0015AEA8 File Offset: 0x001590A8
	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	// Token: 0x06001D07 RID: 7431 RVA: 0x0015AEE4 File Offset: 0x001590E4
	private void SpinTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	// Token: 0x06001D08 RID: 7432 RVA: 0x0015AF10 File Offset: 0x00159110
	public void UpdateVignette()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = this.Intensity;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001D09 RID: 7433 RVA: 0x0015AF84 File Offset: 0x00159184
	public void BeginStruggle()
	{
		this.MyAnimation.CrossFade("f02_struggleA_00");
		this.Struggling = true;
		this.Object.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		this.Object.gameObject.GetComponent<Rigidbody>().useGravity = true;
		this.Object.gameObject.GetComponent<Collider>().isTrigger = false;
		this.Object.parent = null;
		this.Object = null;
	}

	// Token: 0x06001D0A RID: 7434 RVA: 0x0015B000 File Offset: 0x00159200
	public void UpdateYandereVision()
	{
		if (Input.GetButton("RB"))
		{
			if (this.YandereFilter.FadeFX < 1f)
			{
				if (!this.HighlightingR.enabled)
				{
					this.YandereFilter.enabled = true;
					this.HighlightingR.enabled = true;
					this.HighlightingB.enabled = true;
				}
				Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, Time.unscaledDeltaTime * 10f);
				this.YandereFilter.FadeFX = Mathf.Lerp(this.YandereFilter.FadeFX, 1f, Time.unscaledDeltaTime * 10f);
				if (this.YandereFilter.FadeFX == 1f)
				{
					Time.timeScale = 0.5f;
					return;
				}
			}
		}
		else if (this.YandereFilter.FadeFX > 0f)
		{
			if (this.HighlightingR.enabled)
			{
				this.HighlightingR.enabled = false;
				this.HighlightingB.enabled = false;
			}
			Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.unscaledDeltaTime * 10f);
			this.YandereFilter.FadeFX = Mathf.Lerp(this.YandereFilter.FadeFX, 0f, Time.unscaledDeltaTime * 10f);
			if (this.YandereFilter.FadeFX == 0f)
			{
				Time.timeScale = 1f;
			}
		}
	}

	// Token: 0x06001D0B RID: 7435 RVA: 0x0015B16C File Offset: 0x0015936C
	private void ResetYandereEffects()
	{
		this.HighlightingR.enabled = false;
		this.HighlightingB.enabled = false;
		this.YandereFilter.enabled = true;
		this.YandereFilter.FadeFX = 0f;
		Time.timeScale = 1f;
		this.Intensity = 0f;
		this.UpdateVignette();
	}

	// Token: 0x06001D0C RID: 7436 RVA: 0x0015B1C8 File Offset: 0x001593C8
	public void UpdatePebbles()
	{
		if (this.PebbleIcon != null)
		{
			if (this.Pebbles == 0)
			{
				this.PebbleIcon.SetActive(false);
				return;
			}
			this.PebbleIcon.SetActive(true);
			this.PebbleLabel.text = "PEBBLES: " + this.Pebbles.ToString();
		}
	}

	// Token: 0x0400349D RID: 13469
	public CharacterController MyController;

	// Token: 0x0400349E RID: 13470
	public PostProcessingProfile Profile;

	// Token: 0x0400349F RID: 13471
	public AutoSaveManager SaveManager;

	// Token: 0x040034A0 RID: 13472
	public StalkerScript Stalker;

	// Token: 0x040034A1 RID: 13473
	public ArcScript Arc;

	// Token: 0x040034A2 RID: 13474
	public Transform TrellisClimbSpot;

	// Token: 0x040034A3 RID: 13475
	public Transform CameraTarget;

	// Token: 0x040034A4 RID: 13476
	public Transform ObjectTarget;

	// Token: 0x040034A5 RID: 13477
	public Transform RightHand;

	// Token: 0x040034A6 RID: 13478
	public Transform EntryPOV;

	// Token: 0x040034A7 RID: 13479
	public Transform RightArm;

	// Token: 0x040034A8 RID: 13480
	public Transform Object;

	// Token: 0x040034A9 RID: 13481
	public Transform Hips;

	// Token: 0x040034AA RID: 13482
	public Renderer PonytailRenderer;

	// Token: 0x040034AB RID: 13483
	public GameObject GroundImpact;

	// Token: 0x040034AC RID: 13484
	public Animation MyAnimation;

	// Token: 0x040034AD RID: 13485
	public RPG_Camera RPGCamera;

	// Token: 0x040034AE RID: 13486
	public AudioSource Jukebox;

	// Token: 0x040034AF RID: 13487
	public Camera MainCamera;

	// Token: 0x040034B0 RID: 13488
	public bool Struggling;

	// Token: 0x040034B1 RID: 13489
	public bool Climbing;

	// Token: 0x040034B2 RID: 13490
	public bool Running;

	// Token: 0x040034B3 RID: 13491
	public bool Invisible;

	// Token: 0x040034B4 RID: 13492
	public bool Eighties;

	// Token: 0x040034B5 RID: 13493
	public bool InDesert;

	// Token: 0x040034B6 RID: 13494
	public bool CanMove;

	// Token: 0x040034B7 RID: 13495
	public bool Chased;

	// Token: 0x040034B8 RID: 13496
	public bool Hidden;

	// Token: 0x040034B9 RID: 13497
	public bool Street;

	// Token: 0x040034BA RID: 13498
	public Stance Stance = new Stance(StanceType.Standing);

	// Token: 0x040034BB RID: 13499
	public string IdleAnim;

	// Token: 0x040034BC RID: 13500
	public string WalkAnim;

	// Token: 0x040034BD RID: 13501
	public string RunAnim;

	// Token: 0x040034BE RID: 13502
	public string CrouchIdleAnim;

	// Token: 0x040034BF RID: 13503
	public string CrouchWalkAnim;

	// Token: 0x040034C0 RID: 13504
	public string CrouchRunAnim;

	// Token: 0x040034C1 RID: 13505
	public float WalkSpeed;

	// Token: 0x040034C2 RID: 13506
	public float RunSpeed;

	// Token: 0x040034C3 RID: 13507
	public float CrouchWalkSpeed;

	// Token: 0x040034C4 RID: 13508
	public float CrouchRunSpeed;

	// Token: 0x040034C5 RID: 13509
	public float Intensity = 0.45f;

	// Token: 0x040034C6 RID: 13510
	public int ClimbPhase;

	// Token: 0x040034C7 RID: 13511
	public int Pebbles;

	// Token: 0x040034C8 RID: 13512
	public int Frame;

	// Token: 0x040034C9 RID: 13513
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040034CA RID: 13514
	public GameObject ClothingAttacher;

	// Token: 0x040034CB RID: 13515
	public GameObject EightiesAttacher;

	// Token: 0x040034CC RID: 13516
	public GameObject RyobaHair;

	// Token: 0x040034CD RID: 13517
	public Material Transparent;

	// Token: 0x040034CE RID: 13518
	public Texture BlondePony;

	// Token: 0x040034CF RID: 13519
	public Mesh HeadOnlyMesh;

	// Token: 0x040034D0 RID: 13520
	public Transform BreastL;

	// Token: 0x040034D1 RID: 13521
	public Transform BreastR;

	// Token: 0x040034D2 RID: 13522
	public AudioSource MyAudio;

	// Token: 0x040034D3 RID: 13523
	public GameObject Pebble;

	// Token: 0x040034D4 RID: 13524
	public bool LethalPoison;

	// Token: 0x040034D5 RID: 13525
	public bool Sedative;

	// Token: 0x040034D6 RID: 13526
	public bool Asylum;

	// Token: 0x040034D7 RID: 13527
	public bool Cigs;

	// Token: 0x040034D8 RID: 13528
	public CameraFilterPack_Colors_Adjust_PreFilters YandereFilter;

	// Token: 0x040034D9 RID: 13529
	public HighlightingRenderer HighlightingR;

	// Token: 0x040034DA RID: 13530
	public HighlightingBlitter HighlightingB;

	// Token: 0x040034DB RID: 13531
	public GameObject ThrowButton;

	// Token: 0x040034DC RID: 13532
	public GameObject PebbleIcon;

	// Token: 0x040034DD RID: 13533
	public GameObject AimButton;

	// Token: 0x040034DE RID: 13534
	public UILabel PebbleLabel;
}
