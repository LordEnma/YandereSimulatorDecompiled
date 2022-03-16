using System;
using UnityEngine;

// Token: 0x020004C1 RID: 1217
public class WeaponScript : MonoBehaviour
{
	// Token: 0x06001FDB RID: 8155 RVA: 0x001C21DC File Offset: 0x001C03DC
	public void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		this.StartingPosition = base.transform.position;
		this.StartingRotation = base.transform.eulerAngles;
		Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
		this.OriginalColor = this.Outline[0].color;
		if (this.StartLow)
		{
			this.OriginalOffset = this.Prompt.OffsetY[3];
			this.Prompt.OffsetY[3] = 0.2f;
		}
		if (this.DisableCollider)
		{
			this.MyCollider.enabled = false;
		}
		this.MyAudio = base.GetComponent<AudioSource>();
		if (this.MyAudio != null)
		{
			this.OriginalClip = this.MyAudio.clip;
		}
		this.MyRigidbody = base.GetComponent<Rigidbody>();
		this.MyRigidbody.isKinematic = true;
		if (!this.BroughtFromHome)
		{
			Transform transform = GameObject.Find("WeaponOriginParent").transform;
			this.Origin = UnityEngine.Object.Instantiate<GameObject>(this.Prompt.Yandere.StudentManager.EmptyObject, base.transform.position, Quaternion.identity).transform;
			this.Origin.parent = transform;
		}
		if (this.WeaponID == 7 && GameGlobals.Eighties)
		{
			this.MyMeshFilter.mesh = this.EightiesCircularSaw;
			this.MyRenderer.material.mainTexture = this.EightiesCircularSawTexture;
			this.MyRenderer.transform.localPosition = new Vector3(0.005f, 0.045f, -0.0075f);
		}
		this.Innocent = !this.Suspicious;
	}

	// Token: 0x06001FDC RID: 8156 RVA: 0x001C2390 File Offset: 0x001C0590
	public string GetTypePrefix()
	{
		if (this.Type == WeaponType.Knife)
		{
			return "knife";
		}
		if (this.Type == WeaponType.Katana)
		{
			return "katana";
		}
		if (this.Type == WeaponType.Bat)
		{
			return "bat";
		}
		if (this.Type == WeaponType.Saw)
		{
			return "saw";
		}
		if (this.Type == WeaponType.Syringe)
		{
			return "syringe";
		}
		if (this.Type == WeaponType.Weight)
		{
			return "weight";
		}
		if (this.Type == WeaponType.Garrote)
		{
			return "syringe";
		}
		Debug.LogError("Weapon type \"" + this.Type.ToString() + "\" not implemented.");
		return string.Empty;
	}

	// Token: 0x06001FDD RID: 8157 RVA: 0x001C2430 File Offset: 0x001C0630
	public AudioClip GetClip(float sanity, bool stealth)
	{
		AudioClip[] array;
		if (this.Clips2.Length == 0)
		{
			array = this.Clips;
		}
		else
		{
			array = ((UnityEngine.Random.Range(2, 4) == 2) ? this.Clips2 : this.Clips3);
		}
		if (stealth)
		{
			return array[0];
		}
		if (sanity > 0.6666667f)
		{
			return array[1];
		}
		if (sanity > 0.33333334f)
		{
			return array[2];
		}
		return array[3];
	}

	// Token: 0x06001FDE RID: 8158 RVA: 0x001C248C File Offset: 0x001C068C
	private void Update()
	{
		if (this.WeaponID == 16 && this.Yandere.EquippedWeapon == this && Input.GetButtonDown("RB") && this.ExtraBlade != null)
		{
			this.ExtraBlade.SetActive(!this.ExtraBlade.activeInHierarchy);
		}
		if (this.Dismembering)
		{
			if (this.DismemberPhase < 4)
			{
				if (this.MyAudio.time > 0.75f)
				{
					if (this.Speed < 36f)
					{
						this.Speed += Time.deltaTime + 10f;
					}
					this.Rotation += this.Speed;
					this.Blade.localEulerAngles = new Vector3(this.Rotation, this.Blade.localEulerAngles.y, this.Blade.localEulerAngles.z);
				}
				if (this.MyAudio.time > this.SoundTime[this.DismemberPhase])
				{
					this.Yandere.Sanity -= 5f * this.Yandere.Numbness;
					this.Yandere.Bloodiness += 25f;
					this.ShortBloodSpray[0].Play();
					this.ShortBloodSpray[1].Play();
					this.Blood.enabled = true;
					this.MurderWeapon = true;
					this.DismemberPhase++;
					if (this.Yandere.Gloved && !this.Yandere.Gloves.Blood.enabled)
					{
						this.Yandere.Gloves.PickUp.Evidence = true;
						this.Yandere.Gloves.Blood.enabled = true;
						this.Yandere.GloveBlood = 1;
						this.Yandere.Police.BloodyClothing++;
					}
				}
			}
			else
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 2f);
				this.Blade.localEulerAngles = new Vector3(this.Rotation, this.Blade.localEulerAngles.y, this.Blade.localEulerAngles.z);
				if (!this.MyAudio.isPlaying)
				{
					this.MyAudio.clip = this.OriginalClip;
					this.Yandere.StainWeapon();
					this.Dismembering = false;
					this.DismemberPhase = 0;
					this.Rotation = 0f;
					this.Speed = 0f;
				}
			}
		}
		else if (this.Yandere.EquippedWeapon == this)
		{
			if (this.Yandere.AttackManager.IsAttacking())
			{
				if (this.Type == WeaponType.Knife)
				{
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, Mathf.Lerp(base.transform.localEulerAngles.y, this.Flip ? 180f : 0f, Time.deltaTime * 10f), base.transform.localEulerAngles.z);
				}
				else if (this.Type == WeaponType.Saw && this.Spin)
				{
					this.Blade.transform.localEulerAngles = new Vector3(this.Blade.transform.localEulerAngles.x + Time.deltaTime * 360f, this.Blade.transform.localEulerAngles.y, this.Blade.transform.localEulerAngles.z);
				}
			}
		}
		else if (!this.MyRigidbody.isKinematic)
		{
			this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
			if (this.KinematicTimer == 5f)
			{
				this.MyRigidbody.isKinematic = true;
				this.KinematicTimer = 0f;
			}
			if (base.transform.position.x > -71f && base.transform.position.x < -61f && base.transform.position.z > -37.5f && base.transform.position.z < -27.5f)
			{
				this.Yandere.NotificationManager.CustomText = "You can't drop that there!";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = new Vector3(-63f, 1f, -26.5f);
				this.KinematicTimer = 0f;
			}
			if (base.transform.position.x > -21f && base.transform.position.x < 21f && base.transform.position.z > 100f && base.transform.position.z < 135f)
			{
				base.transform.position = new Vector3(0f, 1f, 100f);
				this.KinematicTimer = 0f;
			}
			if (base.transform.position.x > -46f && base.transform.position.x < -18f && base.transform.position.z > 66f && base.transform.position.z < 78f)
			{
				base.transform.position = new Vector3(-16f, 5f, 72f);
				this.KinematicTimer = 0f;
			}
		}
		if (this.Rotate)
		{
			base.transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
		}
	}

	// Token: 0x06001FDF RID: 8159 RVA: 0x001C2A90 File Offset: 0x001C0C90
	private void LateUpdate()
	{
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			if (this.WeaponID == 6 && SchemeGlobals.GetSchemeStage(4) == 1)
			{
				SchemeGlobals.SetSchemeStage(4, 2);
				this.Yandere.PauseScreen.Schemes.UpdateInstructions();
			}
			this.Prompt.Circle[3].fillAmount = 1f;
			if (this.Yandere.Chasers == 0)
			{
				if (this.Prompt.Suspicious)
				{
					this.Yandere.TheftTimer = 0.1f;
				}
				if (this.Dangerous || this.Suspicious)
				{
					this.Yandere.WeaponTimer = 0.1f;
				}
			}
			if (!this.Yandere.Gloved)
			{
				if (this.FingerprintID == 0)
				{
					this.Yandere.WeaponManager.WeaponsTouched++;
					if (this.Yandere.WeaponManager.WeaponsTouched > 19 && !GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("WeaponMaster", 1);
					}
				}
				this.FingerprintID = 100;
			}
			this.ID = 0;
			while (this.ID < this.Outline.Length)
			{
				if (this.Outline[this.ID] != null)
				{
					this.Outline[this.ID].color = new Color(0f, 0f, 0f, 1f);
				}
				this.ID++;
			}
			base.transform.parent = this.Yandere.ItemParent;
			base.transform.localPosition = Vector3.zero;
			if (this.Type == WeaponType.Bat)
			{
				base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
			}
			else
			{
				base.transform.localEulerAngles = Vector3.zero;
			}
			this.MyCollider.enabled = false;
			this.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
			if (this.Yandere.Equipped == 3 && this.Yandere.Weapon[3] != null)
			{
				this.Yandere.Weapon[3].Drop();
			}
			if (this.Yandere.PickUp != null)
			{
				this.Yandere.PickUp.Drop();
			}
			if (this.Yandere.Dragging)
			{
				this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
			}
			if (this.Yandere.Carrying)
			{
				this.Yandere.StopCarrying();
			}
			if (this.Concealable)
			{
				if (this.Yandere.Weapon[1] == null)
				{
					if (this.Yandere.Weapon[2] != null)
					{
						this.Yandere.Weapon[2].gameObject.SetActive(false);
					}
					this.Yandere.Equipped = 1;
					this.Yandere.EquippedWeapon = this;
					this.Yandere.WeaponManager.SetEquippedWeapon1(this);
				}
				else if (this.Yandere.Weapon[2] == null)
				{
					if (this.Yandere.Weapon[1] != null)
					{
						if (!this.DoNotDisable)
						{
							this.Yandere.Weapon[1].gameObject.SetActive(false);
						}
						this.DoNotDisable = false;
					}
					this.Yandere.Equipped = 2;
					this.Yandere.EquippedWeapon = this;
					this.Yandere.WeaponManager.SetEquippedWeapon2(this);
				}
				else if (this.Yandere.Weapon[2].gameObject.activeInHierarchy)
				{
					this.Yandere.Weapon[2].Drop();
					this.Yandere.Equipped = 2;
					this.Yandere.EquippedWeapon = this;
					this.Yandere.WeaponManager.SetEquippedWeapon2(this);
				}
				else
				{
					this.Yandere.Weapon[1].Drop();
					this.Yandere.Equipped = 1;
					this.Yandere.EquippedWeapon = this;
					this.Yandere.WeaponManager.SetEquippedWeapon1(this);
				}
			}
			else
			{
				if (this.Yandere.Weapon[1] != null)
				{
					this.Yandere.Weapon[1].gameObject.SetActive(false);
				}
				if (this.Yandere.Weapon[2] != null)
				{
					this.Yandere.Weapon[2].gameObject.SetActive(false);
				}
				this.Yandere.Equipped = 3;
				this.Yandere.EquippedWeapon = this;
				this.Yandere.WeaponManager.SetEquippedWeapon3(this);
			}
			this.Yandere.StudentManager.UpdateStudents(0);
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.NearestPrompt = null;
			if (this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12 || this.WeaponID == 14 || this.WeaponID == 16 || this.WeaponID == 22 || this.WeaponID == 25)
			{
				this.SuspicionCheck();
			}
			if (this.Yandere.EquippedWeapon.Suspicious)
			{
				if (!this.Yandere.WeaponWarning)
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Armed);
					this.Yandere.WeaponWarning = true;
				}
			}
			else
			{
				this.Yandere.WeaponWarning = false;
			}
			this.Yandere.WeaponMenu.UpdateSprites();
			this.Yandere.WeaponManager.UpdateLabels();
			if (this.Blood.enabled)
			{
				this.Yandere.Police.BloodyWeapons--;
			}
			if (this.WeaponID == 11)
			{
				this.Yandere.IdleAnim = "CyborgNinja_Idle_Armed";
				this.Yandere.WalkAnim = "CyborgNinja_Walk_Armed";
				this.Yandere.RunAnim = "CyborgNinja_Run_Armed";
			}
			if (this.WeaponID == 26)
			{
				this.WeaponTrail.SetActive(true);
			}
			this.KinematicTimer = 0f;
			AudioSource.PlayClipAtPoint(this.EquipClip, this.Yandere.MainCamera.transform.position);
			if (this.UnequipImmediately)
			{
				this.UnequipImmediately = false;
				this.Yandere.Unequip();
			}
			this.Yandere.UpdateConcealedWeaponStatus();
		}
		if (this.Yandere.EquippedWeapon == this && this.Yandere.Armed)
		{
			base.transform.localScale = new Vector3(1f, 1f, 1f);
			if (!this.Yandere.Struggling)
			{
				if (this.Yandere.CanMove)
				{
					base.transform.localPosition = Vector3.zero;
					if (this.Type == WeaponType.Bat)
					{
						base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
					}
					else
					{
						base.transform.localEulerAngles = Vector3.zero;
					}
				}
			}
			else
			{
				base.transform.localPosition = new Vector3(-0.01f, 0.005f, -0.01f);
			}
		}
		if (this.Dumped)
		{
			this.DumpTimer += Time.deltaTime;
			if (this.DumpTimer > 1f)
			{
				if (this.Bloody || this.MurderWeapon)
				{
					this.Yandere.Incinerator.MurderWeapons++;
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (base.transform.parent == this.Yandere.ItemParent && this.Concealable && this.Yandere.Weapon[1] != this && this.Yandere.Weapon[2] != this)
		{
			this.Drop();
		}
	}

	// Token: 0x06001FE0 RID: 8160 RVA: 0x001C3254 File Offset: 0x001C1454
	public void Drop()
	{
		if (!this.Undroppable)
		{
			if (this.WeaponID == 6 && SchemeGlobals.GetSchemeStage(4) == 2)
			{
				SchemeGlobals.SetSchemeStage(4, 1);
				this.Yandere.PauseScreen.Schemes.UpdateInstructions();
			}
			if (this.WeaponID == 11)
			{
				this.Yandere.IdleAnim = "CyborgNinja_Idle_Unarmed";
				this.Yandere.WalkAnim = this.Yandere.OriginalWalkAnim;
				this.Yandere.RunAnim = "CyborgNinja_Run_Unarmed";
			}
			if (this.StartLow)
			{
				this.Prompt.OffsetY[3] = this.OriginalOffset;
			}
			if (this.Yandere.Weapon[1] == this)
			{
				this.Yandere.WeaponManager.YandereWeapon1 = -1;
			}
			else if (this.Yandere.Weapon[2] == this)
			{
				this.Yandere.WeaponManager.YandereWeapon2 = -1;
			}
			else if (this.Yandere.Weapon[3] == this)
			{
				this.Yandere.WeaponManager.YandereWeapon3 = -1;
			}
			if (this.Yandere.EquippedWeapon == this)
			{
				this.Yandere.EquippedWeapon = null;
				this.Yandere.Equipped = 0;
				this.Yandere.StudentManager.UpdateStudents(0);
			}
			base.gameObject.SetActive(true);
			base.transform.parent = null;
			this.MyRigidbody.constraints = RigidbodyConstraints.None;
			this.MyRigidbody.isKinematic = false;
			this.MyRigidbody.useGravity = true;
			this.MyCollider.isTrigger = false;
			if (this.Dumped)
			{
				base.transform.position = this.Incinerator.DumpPoint.position;
			}
			else
			{
				this.Prompt.enabled = true;
				this.MyCollider.enabled = true;
				if (this.Yandere.GetComponent<Collider>().enabled)
				{
					Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
				}
			}
			if (this.Blood.enabled)
			{
				this.Yandere.Police.BloodyWeapons++;
			}
			if (Vector3.Distance(this.StartingPosition, base.transform.position) > 5f && Vector3.Distance(base.transform.position, this.Yandere.StudentManager.WeaponBoxSpot.parent.position) > 1f)
			{
				if (!this.Misplaced)
				{
					this.Prompt.Yandere.WeaponManager.MisplacedWeapons++;
					this.Misplaced = true;
				}
			}
			else if (this.Misplaced)
			{
				this.Prompt.Yandere.WeaponManager.MisplacedWeapons--;
				this.Misplaced = false;
			}
			this.ID = 0;
			while (this.ID < this.Outline.Length)
			{
				this.Outline[this.ID].color = (this.Evidence ? this.EvidenceColor : this.OriginalColor);
				this.ID++;
			}
			if (base.transform.position.y > 1000f)
			{
				base.transform.position = new Vector3(12f, 0f, 28f);
			}
			if (this.WeaponID == 26)
			{
				base.transform.parent = this.Parent;
				base.transform.localEulerAngles = Vector3.zero;
				base.transform.localPosition = Vector3.zero;
				this.MyRigidbody.isKinematic = true;
				this.WeaponTrail.SetActive(false);
			}
		}
	}

	// Token: 0x06001FE1 RID: 8161 RVA: 0x001C35FC File Offset: 0x001C17FC
	public void UpdateLabel()
	{
		if (this != null && base.gameObject.activeInHierarchy)
		{
			if (this.Yandere.Weapon[1] != null && this.Yandere.Weapon[2] != null && this.Concealable)
			{
				if (this.Prompt.Label[3] != null)
				{
					if (!this.Yandere.Armed || this.Yandere.Equipped == 3)
					{
						this.Prompt.Label[3].text = "     Swap " + this.Yandere.Weapon[1].Name + " for " + this.Name;
						return;
					}
					this.Prompt.Label[3].text = "     Swap " + this.Yandere.EquippedWeapon.Name + " for " + this.Name;
					return;
				}
			}
			else if (this.Prompt.Label[3] != null)
			{
				this.Prompt.Label[3].text = "     " + this.Name;
			}
		}
	}

	// Token: 0x06001FE2 RID: 8162 RVA: 0x001C373C File Offset: 0x001C193C
	public void Effect()
	{
		if (this.WeaponID == 7)
		{
			this.BloodSpray[0].Play();
			this.BloodSpray[1].Play();
			return;
		}
		if (this.WeaponID == 8)
		{
			base.gameObject.GetComponent<ParticleSystem>().Play();
			this.MyAudio.clip = this.OriginalClip;
			this.MyAudio.Play();
			return;
		}
		if (this.WeaponID == 2 || this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12 || this.WeaponID == 13)
		{
			this.MyAudio.Play();
			return;
		}
		if (this.WeaponID == 14)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HeartBurst, this.Yandere.TargetStudent.Head.position, Quaternion.identity);
			this.MyAudio.Play();
		}
	}

	// Token: 0x06001FE3 RID: 8163 RVA: 0x001C381B File Offset: 0x001C1A1B
	public void Dismember()
	{
		this.Yandere.CameraEffects.UpdateDOF(0.6666667f);
		this.MyAudio.clip = this.DismemberClip;
		this.MyAudio.Play();
		this.Dismembering = true;
	}

	// Token: 0x06001FE4 RID: 8164 RVA: 0x001C3858 File Offset: 0x001C1A58
	public void SuspicionCheck()
	{
		if (this.Innocent)
		{
			this.Suspicious = false;
		}
		else if ((this.WeaponID == 9 && this.Yandere.Club == ClubType.Sports) || (this.WeaponID == 10 && this.Yandere.Club == ClubType.Gardening) || (this.WeaponID == 12 && this.Yandere.Club == ClubType.Sports) || (this.WeaponID == 14 && this.Yandere.Club == ClubType.Drama) || (this.WeaponID == 16 && this.Yandere.Club == ClubType.Drama) || (this.WeaponID == 22 && this.Yandere.Club == ClubType.Drama) || (this.WeaponID == 25 && this.Yandere.Club == ClubType.LightMusic))
		{
			this.Suspicious = false;
		}
		else
		{
			this.Suspicious = true;
		}
		if (this.Bloody)
		{
			this.Suspicious = true;
			return;
		}
		this.ID = 0;
		while (this.ID < this.Outline.Length)
		{
			if (this.Outline[this.ID] != null)
			{
				this.Outline[this.ID].color = new Color(0f, 1f, 1f, 1f);
			}
			this.ID++;
		}
	}

	// Token: 0x040042C0 RID: 17088
	public ParticleSystem[] ShortBloodSpray;

	// Token: 0x040042C1 RID: 17089
	public ParticleSystem[] BloodSpray;

	// Token: 0x040042C2 RID: 17090
	public OutlineScript[] Outline;

	// Token: 0x040042C3 RID: 17091
	public float[] SoundTime;

	// Token: 0x040042C4 RID: 17092
	public IncineratorScript Incinerator;

	// Token: 0x040042C5 RID: 17093
	public StudentScript Returner;

	// Token: 0x040042C6 RID: 17094
	public YandereScript Yandere;

	// Token: 0x040042C7 RID: 17095
	public PromptScript Prompt;

	// Token: 0x040042C8 RID: 17096
	public Transform Origin;

	// Token: 0x040042C9 RID: 17097
	public Transform Parent;

	// Token: 0x040042CA RID: 17098
	public AudioClip[] Clips;

	// Token: 0x040042CB RID: 17099
	public AudioClip[] Clips2;

	// Token: 0x040042CC RID: 17100
	public AudioClip[] Clips3;

	// Token: 0x040042CD RID: 17101
	public AudioClip DismemberClip;

	// Token: 0x040042CE RID: 17102
	public AudioClip EquipClip;

	// Token: 0x040042CF RID: 17103
	public ParticleSystem FireEffect;

	// Token: 0x040042D0 RID: 17104
	public GameObject WeaponTrail;

	// Token: 0x040042D1 RID: 17105
	public GameObject ExtraBlade;

	// Token: 0x040042D2 RID: 17106
	public AudioSource FireAudio;

	// Token: 0x040042D3 RID: 17107
	public Rigidbody MyRigidbody;

	// Token: 0x040042D4 RID: 17108
	public AudioSource MyAudio;

	// Token: 0x040042D5 RID: 17109
	public Collider MyCollider;

	// Token: 0x040042D6 RID: 17110
	public Renderer MyRenderer;

	// Token: 0x040042D7 RID: 17111
	public GameObject Nails;

	// Token: 0x040042D8 RID: 17112
	public Transform Blade;

	// Token: 0x040042D9 RID: 17113
	public Projector Blood;

	// Token: 0x040042DA RID: 17114
	public Vector3 StartingPosition;

	// Token: 0x040042DB RID: 17115
	public Vector3 StartingRotation;

	// Token: 0x040042DC RID: 17116
	public bool UnequipImmediately;

	// Token: 0x040042DD RID: 17117
	public bool AlreadyExamined;

	// Token: 0x040042DE RID: 17118
	public bool BroughtFromHome;

	// Token: 0x040042DF RID: 17119
	public bool DelinquentOwned;

	// Token: 0x040042E0 RID: 17120
	public bool DisableCollider;

	// Token: 0x040042E1 RID: 17121
	public bool DoNotDisable;

	// Token: 0x040042E2 RID: 17122
	public bool Dismembering;

	// Token: 0x040042E3 RID: 17123
	public bool MurderWeapon;

	// Token: 0x040042E4 RID: 17124
	public bool WeaponEffect;

	// Token: 0x040042E5 RID: 17125
	public bool Concealable;

	// Token: 0x040042E6 RID: 17126
	public bool Undroppable;

	// Token: 0x040042E7 RID: 17127
	public bool Suspicious;

	// Token: 0x040042E8 RID: 17128
	public bool Dangerous;

	// Token: 0x040042E9 RID: 17129
	public bool Misplaced;

	// Token: 0x040042EA RID: 17130
	public bool Evidence;

	// Token: 0x040042EB RID: 17131
	public bool Innocent;

	// Token: 0x040042EC RID: 17132
	public bool StartLow;

	// Token: 0x040042ED RID: 17133
	public bool Flaming;

	// Token: 0x040042EE RID: 17134
	public bool Bloody;

	// Token: 0x040042EF RID: 17135
	public bool Dumped;

	// Token: 0x040042F0 RID: 17136
	public bool Heated;

	// Token: 0x040042F1 RID: 17137
	public bool Rotate;

	// Token: 0x040042F2 RID: 17138
	public bool Blunt;

	// Token: 0x040042F3 RID: 17139
	public bool Metal;

	// Token: 0x040042F4 RID: 17140
	public bool Flip;

	// Token: 0x040042F5 RID: 17141
	public bool Spin;

	// Token: 0x040042F6 RID: 17142
	public Color EvidenceColor;

	// Token: 0x040042F7 RID: 17143
	public Color OriginalColor;

	// Token: 0x040042F8 RID: 17144
	public float OriginalOffset;

	// Token: 0x040042F9 RID: 17145
	public float KinematicTimer;

	// Token: 0x040042FA RID: 17146
	public float DumpTimer;

	// Token: 0x040042FB RID: 17147
	public float Rotation;

	// Token: 0x040042FC RID: 17148
	public float Speed;

	// Token: 0x040042FD RID: 17149
	public string SpriteName;

	// Token: 0x040042FE RID: 17150
	public string Name;

	// Token: 0x040042FF RID: 17151
	public int DismemberPhase;

	// Token: 0x04004300 RID: 17152
	public int FingerprintID;

	// Token: 0x04004301 RID: 17153
	public int GlobalID;

	// Token: 0x04004302 RID: 17154
	public int WeaponID;

	// Token: 0x04004303 RID: 17155
	public int AnimID;

	// Token: 0x04004304 RID: 17156
	public WeaponType Type = WeaponType.Knife;

	// Token: 0x04004305 RID: 17157
	public bool[] Victims;

	// Token: 0x04004306 RID: 17158
	private AudioClip OriginalClip;

	// Token: 0x04004307 RID: 17159
	private int ID;

	// Token: 0x04004308 RID: 17160
	public MeshFilter MyMeshFilter;

	// Token: 0x04004309 RID: 17161
	public Mesh EightiesCircularSaw;

	// Token: 0x0400430A RID: 17162
	public Texture EightiesCircularSawTexture;

	// Token: 0x0400430B RID: 17163
	public GameObject HeartBurst;
}
