using System;
using Bayat.SaveSystem;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x0200043B RID: 1083
public class StalkerYandereScript : MonoBehaviour
{
	// Token: 0x06001CDA RID: 7386 RVA: 0x00155F0C File Offset: 0x0015410C
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

	// Token: 0x06001CDB RID: 7387 RVA: 0x00156070 File Offset: 0x00154270
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

	// Token: 0x06001CDC RID: 7388 RVA: 0x00156564 File Offset: 0x00154764
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

	// Token: 0x06001CDD RID: 7389 RVA: 0x001568B0 File Offset: 0x00154AB0
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

	// Token: 0x06001CDE RID: 7390 RVA: 0x00156930 File Offset: 0x00154B30
	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	// Token: 0x06001CDF RID: 7391 RVA: 0x0015696C File Offset: 0x00154B6C
	private void SpinTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	// Token: 0x06001CE0 RID: 7392 RVA: 0x00156998 File Offset: 0x00154B98
	public void UpdateVignette()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = this.Intensity;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001CE1 RID: 7393 RVA: 0x00156A0C File Offset: 0x00154C0C
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

	// Token: 0x04003429 RID: 13353
	public CharacterController MyController;

	// Token: 0x0400342A RID: 13354
	public PostProcessingProfile Profile;

	// Token: 0x0400342B RID: 13355
	public AutoSaveManager SaveManager;

	// Token: 0x0400342C RID: 13356
	public StalkerScript Stalker;

	// Token: 0x0400342D RID: 13357
	public Transform TrellisClimbSpot;

	// Token: 0x0400342E RID: 13358
	public Transform CameraTarget;

	// Token: 0x0400342F RID: 13359
	public Transform ObjectTarget;

	// Token: 0x04003430 RID: 13360
	public Transform RightHand;

	// Token: 0x04003431 RID: 13361
	public Transform EntryPOV;

	// Token: 0x04003432 RID: 13362
	public Transform RightArm;

	// Token: 0x04003433 RID: 13363
	public Transform Object;

	// Token: 0x04003434 RID: 13364
	public Transform Hips;

	// Token: 0x04003435 RID: 13365
	public Renderer PonytailRenderer;

	// Token: 0x04003436 RID: 13366
	public GameObject GroundImpact;

	// Token: 0x04003437 RID: 13367
	public Animation MyAnimation;

	// Token: 0x04003438 RID: 13368
	public RPG_Camera RPGCamera;

	// Token: 0x04003439 RID: 13369
	public AudioSource Jukebox;

	// Token: 0x0400343A RID: 13370
	public Camera MainCamera;

	// Token: 0x0400343B RID: 13371
	public bool Struggling;

	// Token: 0x0400343C RID: 13372
	public bool Climbing;

	// Token: 0x0400343D RID: 13373
	public bool Running;

	// Token: 0x0400343E RID: 13374
	public bool Invisible;

	// Token: 0x0400343F RID: 13375
	public bool Eighties;

	// Token: 0x04003440 RID: 13376
	public bool InDesert;

	// Token: 0x04003441 RID: 13377
	public bool CanMove;

	// Token: 0x04003442 RID: 13378
	public bool Chased;

	// Token: 0x04003443 RID: 13379
	public bool Hidden;

	// Token: 0x04003444 RID: 13380
	public bool Street;

	// Token: 0x04003445 RID: 13381
	public Stance Stance = new Stance(StanceType.Standing);

	// Token: 0x04003446 RID: 13382
	public string IdleAnim;

	// Token: 0x04003447 RID: 13383
	public string WalkAnim;

	// Token: 0x04003448 RID: 13384
	public string RunAnim;

	// Token: 0x04003449 RID: 13385
	public string CrouchIdleAnim;

	// Token: 0x0400344A RID: 13386
	public string CrouchWalkAnim;

	// Token: 0x0400344B RID: 13387
	public string CrouchRunAnim;

	// Token: 0x0400344C RID: 13388
	public float WalkSpeed;

	// Token: 0x0400344D RID: 13389
	public float RunSpeed;

	// Token: 0x0400344E RID: 13390
	public float CrouchWalkSpeed;

	// Token: 0x0400344F RID: 13391
	public float CrouchRunSpeed;

	// Token: 0x04003450 RID: 13392
	public float Intensity = 0.45f;

	// Token: 0x04003451 RID: 13393
	public int ClimbPhase;

	// Token: 0x04003452 RID: 13394
	public int Frame;

	// Token: 0x04003453 RID: 13395
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04003454 RID: 13396
	public GameObject ClothingAttacher;

	// Token: 0x04003455 RID: 13397
	public GameObject EightiesAttacher;

	// Token: 0x04003456 RID: 13398
	public GameObject RyobaHair;

	// Token: 0x04003457 RID: 13399
	public Material Transparent;

	// Token: 0x04003458 RID: 13400
	public Texture BlondePony;

	// Token: 0x04003459 RID: 13401
	public Mesh HeadOnlyMesh;

	// Token: 0x0400345A RID: 13402
	public Transform BreastL;

	// Token: 0x0400345B RID: 13403
	public Transform BreastR;

	// Token: 0x0400345C RID: 13404
	public bool Asylum;
}
