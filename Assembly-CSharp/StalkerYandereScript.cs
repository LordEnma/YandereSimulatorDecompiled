using System;
using Bayat.SaveSystem;
using HighlightingSystem;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000447 RID: 1095
public class StalkerYandereScript : MonoBehaviour
{
	// Token: 0x06001D2B RID: 7467 RVA: 0x0015CC84 File Offset: 0x0015AE84
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
		else if (this.RyobaHair != null)
		{
			this.RyobaHair.SetActive(false);
		}
		if (GameGlobals.Eighties && this.EightiesAttacher != null)
		{
			this.EightiesAttacher.SetActive(true);
			this.MyRenderer.sharedMesh = this.HeadOnlyMesh;
			this.PonytailRenderer.gameObject.SetActive(false);
			this.RyobaHair.SetActive(true);
			Debug.Log("Setting Ryoba blendshapes.");
			this.MyRenderer.SetBlendShapeWeight(0, 50f);
			this.MyRenderer.SetBlendShapeWeight(5, 25f);
			this.MyRenderer.SetBlendShapeWeight(9, 0f);
			this.MyRenderer.SetBlendShapeWeight(12, 100f);
			this.IdleAnim = "f02_ryobaIdle_00";
			this.WalkAnim = "f02_ryobaWalk_00";
			this.RunAnim = "f02_ryobaRun_00";
			this.MyRenderer.materials[0].mainTexture = this.MyRenderer.materials[2].mainTexture;
			this.Eighties = true;
			if (this.Street)
			{
				this.BreastL.transform.localScale = new Vector3(1f, 1f, 1f);
				this.BreastR.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
		else
		{
			if (!this.Asylum)
			{
				this.BreastL.transform.localScale = new Vector3(1f, 1f, 1f);
				this.BreastR.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			if (this.ClothingAttacher != null && !this.Initialized)
			{
				Debug.Log("Regular Renderer disabled, ClothingAttacher activated.");
				this.ClothingAttacher.SetActive(true);
				this.MyRenderer.gameObject.SetActive(false);
				this.Initialized = true;
			}
			this.UpdatePebbles();
		}
		this.VtuberCheck();
	}

	// Token: 0x06001D2C RID: 7468 RVA: 0x0015CEDC File Offset: 0x0015B0DC
	private void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (this.UpdateTextures)
		{
			if (this.UpdateFrame == 1)
			{
				Debug.Log("Attempting to update textures...");
				if (this.ClothingAttacher != null && this.ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
				{
					Debug.Log("ClothingAttacher was not null.");
					this.MyRenderer = this.ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
					this.MyRenderer.materials[1].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
				}
				else
				{
					Debug.Log("ClothingAttacher was null.");
					for (int i = 0; i < 13; i++)
					{
						this.MyRenderer.SetBlendShapeWeight(i, 0f);
					}
					this.MyRenderer.SetBlendShapeWeight(0, 100f);
					this.MyRenderer.SetBlendShapeWeight(9, 100f);
					if (this.Eighties && this.Street)
					{
						this.MyRenderer.materials[0].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
						this.MyRenderer.materials[1].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
						this.MyRenderer.materials[2].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
					}
				}
				this.UpdateTextures = false;
			}
			this.UpdateFrame++;
		}
		if (this.UpdateBlendshapes)
		{
			Debug.Log("Setting Ryoba Blendshapes 2");
			this.MyRenderer = this.EightiesAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
			this.MyRenderer.SetBlendShapeWeight(0, 50f);
			this.MyRenderer.SetBlendShapeWeight(5, 25f);
			this.MyRenderer.SetBlendShapeWeight(9, 0f);
			this.MyRenderer.SetBlendShapeWeight(12, 100f);
			this.UpdateBlendshapes = false;
		}
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

	// Token: 0x06001D2D RID: 7469 RVA: 0x0015D6EC File Offset: 0x0015B8EC
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

	// Token: 0x06001D2E RID: 7470 RVA: 0x0015DA38 File Offset: 0x0015BC38
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

	// Token: 0x06001D2F RID: 7471 RVA: 0x0015DAB8 File Offset: 0x0015BCB8
	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	// Token: 0x06001D30 RID: 7472 RVA: 0x0015DAF4 File Offset: 0x0015BCF4
	private void SpinTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	// Token: 0x06001D31 RID: 7473 RVA: 0x0015DB20 File Offset: 0x0015BD20
	public void UpdateVignette()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = this.Intensity;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001D32 RID: 7474 RVA: 0x0015DB94 File Offset: 0x0015BD94
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

	// Token: 0x06001D33 RID: 7475 RVA: 0x0015DC10 File Offset: 0x0015BE10
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

	// Token: 0x06001D34 RID: 7476 RVA: 0x0015DD7C File Offset: 0x0015BF7C
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

	// Token: 0x06001D35 RID: 7477 RVA: 0x0015DDD8 File Offset: 0x0015BFD8
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

	// Token: 0x06001D36 RID: 7478 RVA: 0x0015DE34 File Offset: 0x0015C034
	public void VtuberCheck()
	{
		if (GameGlobals.VtuberID > 0)
		{
			for (int i = 1; i < this.OriginalHairs.Length; i++)
			{
				this.OriginalHairs[i].transform.localPosition = new Vector3(0f, 100f, 0f);
			}
			this.VtuberHairs[GameGlobals.VtuberID].SetActive(true);
			if (this.ClothingAttacher != null && this.ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
			{
				this.MyRenderer = this.ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
				this.MyRenderer.materials[1].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
			}
			else
			{
				this.MyRenderer.materials[2].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
				for (int i = 0; i < 13; i++)
				{
					this.MyRenderer.SetBlendShapeWeight(i, 0f);
				}
				this.MyRenderer.SetBlendShapeWeight(0, 100f);
				this.MyRenderer.SetBlendShapeWeight(9, 100f);
			}
			this.UpdateTextures = true;
			this.Vtuber = true;
			return;
		}
		this.VtuberHairs[1].SetActive(false);
	}

	// Token: 0x0400350B RID: 13579
	public CharacterController MyController;

	// Token: 0x0400350C RID: 13580
	public PostProcessingProfile Profile;

	// Token: 0x0400350D RID: 13581
	public AutoSaveManager SaveManager;

	// Token: 0x0400350E RID: 13582
	public StalkerScript Stalker;

	// Token: 0x0400350F RID: 13583
	public ArcScript Arc;

	// Token: 0x04003510 RID: 13584
	public Transform TrellisClimbSpot;

	// Token: 0x04003511 RID: 13585
	public Transform CameraTarget;

	// Token: 0x04003512 RID: 13586
	public Transform ObjectTarget;

	// Token: 0x04003513 RID: 13587
	public Transform RightHand;

	// Token: 0x04003514 RID: 13588
	public Transform EntryPOV;

	// Token: 0x04003515 RID: 13589
	public Transform RightArm;

	// Token: 0x04003516 RID: 13590
	public Transform Object;

	// Token: 0x04003517 RID: 13591
	public Transform Hips;

	// Token: 0x04003518 RID: 13592
	public Renderer PonytailRenderer;

	// Token: 0x04003519 RID: 13593
	public GameObject GroundImpact;

	// Token: 0x0400351A RID: 13594
	public Animation MyAnimation;

	// Token: 0x0400351B RID: 13595
	public RPG_Camera RPGCamera;

	// Token: 0x0400351C RID: 13596
	public AudioSource Jukebox;

	// Token: 0x0400351D RID: 13597
	public Camera MainCamera;

	// Token: 0x0400351E RID: 13598
	public bool Struggling;

	// Token: 0x0400351F RID: 13599
	public bool Climbing;

	// Token: 0x04003520 RID: 13600
	public bool Running;

	// Token: 0x04003521 RID: 13601
	public bool Invisible;

	// Token: 0x04003522 RID: 13602
	public bool Eighties;

	// Token: 0x04003523 RID: 13603
	public bool InDesert;

	// Token: 0x04003524 RID: 13604
	public bool CanMove;

	// Token: 0x04003525 RID: 13605
	public bool Chased;

	// Token: 0x04003526 RID: 13606
	public bool Hidden;

	// Token: 0x04003527 RID: 13607
	public bool Street;

	// Token: 0x04003528 RID: 13608
	public Stance Stance = new Stance(StanceType.Standing);

	// Token: 0x04003529 RID: 13609
	public string IdleAnim;

	// Token: 0x0400352A RID: 13610
	public string WalkAnim;

	// Token: 0x0400352B RID: 13611
	public string RunAnim;

	// Token: 0x0400352C RID: 13612
	public string CrouchIdleAnim;

	// Token: 0x0400352D RID: 13613
	public string CrouchWalkAnim;

	// Token: 0x0400352E RID: 13614
	public string CrouchRunAnim;

	// Token: 0x0400352F RID: 13615
	public float WalkSpeed;

	// Token: 0x04003530 RID: 13616
	public float RunSpeed;

	// Token: 0x04003531 RID: 13617
	public float CrouchWalkSpeed;

	// Token: 0x04003532 RID: 13618
	public float CrouchRunSpeed;

	// Token: 0x04003533 RID: 13619
	public float Intensity = 0.45f;

	// Token: 0x04003534 RID: 13620
	public int ClimbPhase;

	// Token: 0x04003535 RID: 13621
	public int Pebbles;

	// Token: 0x04003536 RID: 13622
	public int Frame;

	// Token: 0x04003537 RID: 13623
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04003538 RID: 13624
	public GameObject ClothingAttacher;

	// Token: 0x04003539 RID: 13625
	public GameObject EightiesAttacher;

	// Token: 0x0400353A RID: 13626
	public GameObject RyobaHair;

	// Token: 0x0400353B RID: 13627
	public Material Transparent;

	// Token: 0x0400353C RID: 13628
	public Texture BlondePony;

	// Token: 0x0400353D RID: 13629
	public Mesh HeadOnlyMesh;

	// Token: 0x0400353E RID: 13630
	public Transform BreastL;

	// Token: 0x0400353F RID: 13631
	public Transform BreastR;

	// Token: 0x04003540 RID: 13632
	public AudioSource MyAudio;

	// Token: 0x04003541 RID: 13633
	public GameObject Pebble;

	// Token: 0x04003542 RID: 13634
	public bool UpdateBlendshapes;

	// Token: 0x04003543 RID: 13635
	public bool LethalPoison;

	// Token: 0x04003544 RID: 13636
	public bool Initialized;

	// Token: 0x04003545 RID: 13637
	public bool Sedative;

	// Token: 0x04003546 RID: 13638
	public bool Asylum;

	// Token: 0x04003547 RID: 13639
	public bool Cigs;

	// Token: 0x04003548 RID: 13640
	private int UpdateFrame;

	// Token: 0x04003549 RID: 13641
	public CameraFilterPack_Colors_Adjust_PreFilters YandereFilter;

	// Token: 0x0400354A RID: 13642
	public HighlightingRenderer HighlightingR;

	// Token: 0x0400354B RID: 13643
	public HighlightingBlitter HighlightingB;

	// Token: 0x0400354C RID: 13644
	public GameObject ThrowButton;

	// Token: 0x0400354D RID: 13645
	public GameObject PebbleIcon;

	// Token: 0x0400354E RID: 13646
	public GameObject AimButton;

	// Token: 0x0400354F RID: 13647
	public UILabel PebbleLabel;

	// Token: 0x04003550 RID: 13648
	public GameObject[] OriginalHairs;

	// Token: 0x04003551 RID: 13649
	public GameObject[] VtuberHairs;

	// Token: 0x04003552 RID: 13650
	public Texture[] VtuberFaces;

	// Token: 0x04003553 RID: 13651
	public bool UpdateTextures;

	// Token: 0x04003554 RID: 13652
	public bool Vtuber;
}
