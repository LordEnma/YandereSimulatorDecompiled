using System;
using Bayat.SaveSystem;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x0200043C RID: 1084
public class StalkerYandereScript : MonoBehaviour
{
	// Token: 0x06001CE4 RID: 7396 RVA: 0x00156C74 File Offset: 0x00154E74
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
			this.IdleAnim = "f02_ryobaIdle_00";
			this.WalkAnim = "f02_walkCouncilGrace_00";
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
	}

	// Token: 0x06001CE5 RID: 7397 RVA: 0x00156DD8 File Offset: 0x00154FD8
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

	// Token: 0x06001CE6 RID: 7398 RVA: 0x001572CC File Offset: 0x001554CC
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

	// Token: 0x06001CE7 RID: 7399 RVA: 0x00157618 File Offset: 0x00155818
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

	// Token: 0x06001CE8 RID: 7400 RVA: 0x00157698 File Offset: 0x00155898
	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	// Token: 0x06001CE9 RID: 7401 RVA: 0x001576D4 File Offset: 0x001558D4
	private void SpinTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	// Token: 0x06001CEA RID: 7402 RVA: 0x00157700 File Offset: 0x00155900
	public void UpdateVignette()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = this.Intensity;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001CEB RID: 7403 RVA: 0x00157774 File Offset: 0x00155974
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

	// Token: 0x0400345B RID: 13403
	public CharacterController MyController;

	// Token: 0x0400345C RID: 13404
	public PostProcessingProfile Profile;

	// Token: 0x0400345D RID: 13405
	public AutoSaveManager SaveManager;

	// Token: 0x0400345E RID: 13406
	public StalkerScript Stalker;

	// Token: 0x0400345F RID: 13407
	public Transform TrellisClimbSpot;

	// Token: 0x04003460 RID: 13408
	public Transform CameraTarget;

	// Token: 0x04003461 RID: 13409
	public Transform ObjectTarget;

	// Token: 0x04003462 RID: 13410
	public Transform RightHand;

	// Token: 0x04003463 RID: 13411
	public Transform EntryPOV;

	// Token: 0x04003464 RID: 13412
	public Transform RightArm;

	// Token: 0x04003465 RID: 13413
	public Transform Object;

	// Token: 0x04003466 RID: 13414
	public Transform Hips;

	// Token: 0x04003467 RID: 13415
	public Renderer PonytailRenderer;

	// Token: 0x04003468 RID: 13416
	public GameObject GroundImpact;

	// Token: 0x04003469 RID: 13417
	public Animation MyAnimation;

	// Token: 0x0400346A RID: 13418
	public RPG_Camera RPGCamera;

	// Token: 0x0400346B RID: 13419
	public AudioSource Jukebox;

	// Token: 0x0400346C RID: 13420
	public Camera MainCamera;

	// Token: 0x0400346D RID: 13421
	public bool Struggling;

	// Token: 0x0400346E RID: 13422
	public bool Climbing;

	// Token: 0x0400346F RID: 13423
	public bool Running;

	// Token: 0x04003470 RID: 13424
	public bool Invisible;

	// Token: 0x04003471 RID: 13425
	public bool Eighties;

	// Token: 0x04003472 RID: 13426
	public bool InDesert;

	// Token: 0x04003473 RID: 13427
	public bool CanMove;

	// Token: 0x04003474 RID: 13428
	public bool Chased;

	// Token: 0x04003475 RID: 13429
	public bool Hidden;

	// Token: 0x04003476 RID: 13430
	public bool Street;

	// Token: 0x04003477 RID: 13431
	public Stance Stance = new Stance(StanceType.Standing);

	// Token: 0x04003478 RID: 13432
	public string IdleAnim;

	// Token: 0x04003479 RID: 13433
	public string WalkAnim;

	// Token: 0x0400347A RID: 13434
	public string RunAnim;

	// Token: 0x0400347B RID: 13435
	public string CrouchIdleAnim;

	// Token: 0x0400347C RID: 13436
	public string CrouchWalkAnim;

	// Token: 0x0400347D RID: 13437
	public string CrouchRunAnim;

	// Token: 0x0400347E RID: 13438
	public float WalkSpeed;

	// Token: 0x0400347F RID: 13439
	public float RunSpeed;

	// Token: 0x04003480 RID: 13440
	public float CrouchWalkSpeed;

	// Token: 0x04003481 RID: 13441
	public float CrouchRunSpeed;

	// Token: 0x04003482 RID: 13442
	public float Intensity = 0.45f;

	// Token: 0x04003483 RID: 13443
	public int ClimbPhase;

	// Token: 0x04003484 RID: 13444
	public int Frame;

	// Token: 0x04003485 RID: 13445
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04003486 RID: 13446
	public GameObject ClothingAttacher;

	// Token: 0x04003487 RID: 13447
	public GameObject EightiesAttacher;

	// Token: 0x04003488 RID: 13448
	public GameObject RyobaHair;

	// Token: 0x04003489 RID: 13449
	public Material Transparent;

	// Token: 0x0400348A RID: 13450
	public Texture BlondePony;

	// Token: 0x0400348B RID: 13451
	public Mesh HeadOnlyMesh;

	// Token: 0x0400348C RID: 13452
	public Transform BreastL;

	// Token: 0x0400348D RID: 13453
	public Transform BreastR;

	// Token: 0x0400348E RID: 13454
	public bool Asylum;
}
