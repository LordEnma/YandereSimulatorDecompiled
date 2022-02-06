using System;
using Bayat.SaveSystem;
using HighlightingSystem;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x0200043F RID: 1087
public class StalkerYandereScript : MonoBehaviour
{
	// Token: 0x06001CF0 RID: 7408 RVA: 0x00158FA0 File Offset: 0x001571A0
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

	// Token: 0x06001CF1 RID: 7409 RVA: 0x0015915C File Offset: 0x0015735C
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

	// Token: 0x06001CF2 RID: 7410 RVA: 0x001597A4 File Offset: 0x001579A4
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

	// Token: 0x06001CF3 RID: 7411 RVA: 0x00159AF0 File Offset: 0x00157CF0
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

	// Token: 0x06001CF4 RID: 7412 RVA: 0x00159B70 File Offset: 0x00157D70
	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	// Token: 0x06001CF5 RID: 7413 RVA: 0x00159BAC File Offset: 0x00157DAC
	private void SpinTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	// Token: 0x06001CF6 RID: 7414 RVA: 0x00159BD8 File Offset: 0x00157DD8
	public void UpdateVignette()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = this.Intensity;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001CF7 RID: 7415 RVA: 0x00159C4C File Offset: 0x00157E4C
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

	// Token: 0x06001CF8 RID: 7416 RVA: 0x00159CC8 File Offset: 0x00157EC8
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

	// Token: 0x06001CF9 RID: 7417 RVA: 0x00159E34 File Offset: 0x00158034
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

	// Token: 0x06001CFA RID: 7418 RVA: 0x00159E90 File Offset: 0x00158090
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

	// Token: 0x04003471 RID: 13425
	public CharacterController MyController;

	// Token: 0x04003472 RID: 13426
	public PostProcessingProfile Profile;

	// Token: 0x04003473 RID: 13427
	public AutoSaveManager SaveManager;

	// Token: 0x04003474 RID: 13428
	public StalkerScript Stalker;

	// Token: 0x04003475 RID: 13429
	public ArcScript Arc;

	// Token: 0x04003476 RID: 13430
	public Transform TrellisClimbSpot;

	// Token: 0x04003477 RID: 13431
	public Transform CameraTarget;

	// Token: 0x04003478 RID: 13432
	public Transform ObjectTarget;

	// Token: 0x04003479 RID: 13433
	public Transform RightHand;

	// Token: 0x0400347A RID: 13434
	public Transform EntryPOV;

	// Token: 0x0400347B RID: 13435
	public Transform RightArm;

	// Token: 0x0400347C RID: 13436
	public Transform Object;

	// Token: 0x0400347D RID: 13437
	public Transform Hips;

	// Token: 0x0400347E RID: 13438
	public Renderer PonytailRenderer;

	// Token: 0x0400347F RID: 13439
	public GameObject GroundImpact;

	// Token: 0x04003480 RID: 13440
	public Animation MyAnimation;

	// Token: 0x04003481 RID: 13441
	public RPG_Camera RPGCamera;

	// Token: 0x04003482 RID: 13442
	public AudioSource Jukebox;

	// Token: 0x04003483 RID: 13443
	public Camera MainCamera;

	// Token: 0x04003484 RID: 13444
	public bool Struggling;

	// Token: 0x04003485 RID: 13445
	public bool Climbing;

	// Token: 0x04003486 RID: 13446
	public bool Running;

	// Token: 0x04003487 RID: 13447
	public bool Invisible;

	// Token: 0x04003488 RID: 13448
	public bool Eighties;

	// Token: 0x04003489 RID: 13449
	public bool InDesert;

	// Token: 0x0400348A RID: 13450
	public bool CanMove;

	// Token: 0x0400348B RID: 13451
	public bool Chased;

	// Token: 0x0400348C RID: 13452
	public bool Hidden;

	// Token: 0x0400348D RID: 13453
	public bool Street;

	// Token: 0x0400348E RID: 13454
	public Stance Stance = new Stance(StanceType.Standing);

	// Token: 0x0400348F RID: 13455
	public string IdleAnim;

	// Token: 0x04003490 RID: 13456
	public string WalkAnim;

	// Token: 0x04003491 RID: 13457
	public string RunAnim;

	// Token: 0x04003492 RID: 13458
	public string CrouchIdleAnim;

	// Token: 0x04003493 RID: 13459
	public string CrouchWalkAnim;

	// Token: 0x04003494 RID: 13460
	public string CrouchRunAnim;

	// Token: 0x04003495 RID: 13461
	public float WalkSpeed;

	// Token: 0x04003496 RID: 13462
	public float RunSpeed;

	// Token: 0x04003497 RID: 13463
	public float CrouchWalkSpeed;

	// Token: 0x04003498 RID: 13464
	public float CrouchRunSpeed;

	// Token: 0x04003499 RID: 13465
	public float Intensity = 0.45f;

	// Token: 0x0400349A RID: 13466
	public int ClimbPhase;

	// Token: 0x0400349B RID: 13467
	public int Pebbles;

	// Token: 0x0400349C RID: 13468
	public int Frame;

	// Token: 0x0400349D RID: 13469
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400349E RID: 13470
	public GameObject ClothingAttacher;

	// Token: 0x0400349F RID: 13471
	public GameObject EightiesAttacher;

	// Token: 0x040034A0 RID: 13472
	public GameObject RyobaHair;

	// Token: 0x040034A1 RID: 13473
	public Material Transparent;

	// Token: 0x040034A2 RID: 13474
	public Texture BlondePony;

	// Token: 0x040034A3 RID: 13475
	public Mesh HeadOnlyMesh;

	// Token: 0x040034A4 RID: 13476
	public Transform BreastL;

	// Token: 0x040034A5 RID: 13477
	public Transform BreastR;

	// Token: 0x040034A6 RID: 13478
	public AudioSource MyAudio;

	// Token: 0x040034A7 RID: 13479
	public GameObject Pebble;

	// Token: 0x040034A8 RID: 13480
	public bool LethalPoison;

	// Token: 0x040034A9 RID: 13481
	public bool Sedative;

	// Token: 0x040034AA RID: 13482
	public bool Asylum;

	// Token: 0x040034AB RID: 13483
	public bool Cigs;

	// Token: 0x040034AC RID: 13484
	public CameraFilterPack_Colors_Adjust_PreFilters YandereFilter;

	// Token: 0x040034AD RID: 13485
	public HighlightingRenderer HighlightingR;

	// Token: 0x040034AE RID: 13486
	public HighlightingBlitter HighlightingB;

	// Token: 0x040034AF RID: 13487
	public GameObject ThrowButton;

	// Token: 0x040034B0 RID: 13488
	public GameObject PebbleIcon;

	// Token: 0x040034B1 RID: 13489
	public GameObject AimButton;

	// Token: 0x040034B2 RID: 13490
	public UILabel PebbleLabel;
}
