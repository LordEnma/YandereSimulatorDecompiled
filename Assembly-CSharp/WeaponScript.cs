using System;
using UnityEngine;

// Token: 0x020004C7 RID: 1223
public class WeaponScript : MonoBehaviour
{
	// Token: 0x06002008 RID: 8200 RVA: 0x001C73CC File Offset: 0x001C55CC
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

	// Token: 0x06002009 RID: 8201 RVA: 0x001C7580 File Offset: 0x001C5780
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

	// Token: 0x0600200A RID: 8202 RVA: 0x001C7620 File Offset: 0x001C5820
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

	// Token: 0x0600200B RID: 8203 RVA: 0x001C767C File Offset: 0x001C587C
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

	// Token: 0x0600200C RID: 8204 RVA: 0x001C7C80 File Offset: 0x001C5E80
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
				if (this.MurderWeapon)
				{
					this.Yandere.Incinerator.MurderWeapons++;
				}
				if (this.Bloody)
				{
					this.Yandere.Incinerator.BloodyWeapons++;
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (base.transform.parent == this.Yandere.ItemParent && this.Concealable && this.Yandere.Weapon[1] != this && this.Yandere.Weapon[2] != this)
		{
			this.Drop();
		}
	}

	// Token: 0x0600200D RID: 8205 RVA: 0x001C845C File Offset: 0x001C665C
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

	// Token: 0x0600200E RID: 8206 RVA: 0x001C8804 File Offset: 0x001C6A04
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

	// Token: 0x0600200F RID: 8207 RVA: 0x001C8944 File Offset: 0x001C6B44
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

	// Token: 0x06002010 RID: 8208 RVA: 0x001C8A23 File Offset: 0x001C6C23
	public void Dismember()
	{
		this.Yandere.CameraEffects.UpdateDOF(0.6666667f);
		this.MyAudio.clip = this.DismemberClip;
		this.MyAudio.Play();
		this.Dismembering = true;
	}

	// Token: 0x06002011 RID: 8209 RVA: 0x001C8A60 File Offset: 0x001C6C60
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

	// Token: 0x04004342 RID: 17218
	public ParticleSystem[] ShortBloodSpray;

	// Token: 0x04004343 RID: 17219
	public ParticleSystem[] BloodSpray;

	// Token: 0x04004344 RID: 17220
	public OutlineScript[] Outline;

	// Token: 0x04004345 RID: 17221
	public float[] SoundTime;

	// Token: 0x04004346 RID: 17222
	public IncineratorScript Incinerator;

	// Token: 0x04004347 RID: 17223
	public StudentScript Returner;

	// Token: 0x04004348 RID: 17224
	public YandereScript Yandere;

	// Token: 0x04004349 RID: 17225
	public PromptScript Prompt;

	// Token: 0x0400434A RID: 17226
	public Transform Origin;

	// Token: 0x0400434B RID: 17227
	public Transform Parent;

	// Token: 0x0400434C RID: 17228
	public AudioClip[] Clips;

	// Token: 0x0400434D RID: 17229
	public AudioClip[] Clips2;

	// Token: 0x0400434E RID: 17230
	public AudioClip[] Clips3;

	// Token: 0x0400434F RID: 17231
	public AudioClip DismemberClip;

	// Token: 0x04004350 RID: 17232
	public AudioClip EquipClip;

	// Token: 0x04004351 RID: 17233
	public ParticleSystem FireEffect;

	// Token: 0x04004352 RID: 17234
	public GameObject WeaponTrail;

	// Token: 0x04004353 RID: 17235
	public GameObject ExtraBlade;

	// Token: 0x04004354 RID: 17236
	public AudioSource FireAudio;

	// Token: 0x04004355 RID: 17237
	public Rigidbody MyRigidbody;

	// Token: 0x04004356 RID: 17238
	public AudioSource MyAudio;

	// Token: 0x04004357 RID: 17239
	public Collider MyCollider;

	// Token: 0x04004358 RID: 17240
	public Renderer MyRenderer;

	// Token: 0x04004359 RID: 17241
	public GameObject Nails;

	// Token: 0x0400435A RID: 17242
	public Transform Blade;

	// Token: 0x0400435B RID: 17243
	public Projector Blood;

	// Token: 0x0400435C RID: 17244
	public Vector3 StartingPosition;

	// Token: 0x0400435D RID: 17245
	public Vector3 StartingRotation;

	// Token: 0x0400435E RID: 17246
	public bool UnequipImmediately;

	// Token: 0x0400435F RID: 17247
	public bool AlreadyExamined;

	// Token: 0x04004360 RID: 17248
	public bool BroughtFromHome;

	// Token: 0x04004361 RID: 17249
	public bool DelinquentOwned;

	// Token: 0x04004362 RID: 17250
	public bool DisableCollider;

	// Token: 0x04004363 RID: 17251
	public bool DoNotDisable;

	// Token: 0x04004364 RID: 17252
	public bool Dismembering;

	// Token: 0x04004365 RID: 17253
	public bool MurderWeapon;

	// Token: 0x04004366 RID: 17254
	public bool WeaponEffect;

	// Token: 0x04004367 RID: 17255
	public bool Concealable;

	// Token: 0x04004368 RID: 17256
	public bool Undroppable;

	// Token: 0x04004369 RID: 17257
	public bool Suspicious;

	// Token: 0x0400436A RID: 17258
	public bool Dangerous;

	// Token: 0x0400436B RID: 17259
	public bool Misplaced;

	// Token: 0x0400436C RID: 17260
	public bool Evidence;

	// Token: 0x0400436D RID: 17261
	public bool Innocent;

	// Token: 0x0400436E RID: 17262
	public bool StartLow;

	// Token: 0x0400436F RID: 17263
	public bool Flaming;

	// Token: 0x04004370 RID: 17264
	public bool Bloody;

	// Token: 0x04004371 RID: 17265
	public bool Dumped;

	// Token: 0x04004372 RID: 17266
	public bool Heated;

	// Token: 0x04004373 RID: 17267
	public bool Rotate;

	// Token: 0x04004374 RID: 17268
	public bool Blunt;

	// Token: 0x04004375 RID: 17269
	public bool Metal;

	// Token: 0x04004376 RID: 17270
	public bool Flip;

	// Token: 0x04004377 RID: 17271
	public bool Spin;

	// Token: 0x04004378 RID: 17272
	public Color EvidenceColor;

	// Token: 0x04004379 RID: 17273
	public Color OriginalColor;

	// Token: 0x0400437A RID: 17274
	public float OriginalOffset;

	// Token: 0x0400437B RID: 17275
	public float KinematicTimer;

	// Token: 0x0400437C RID: 17276
	public float DumpTimer;

	// Token: 0x0400437D RID: 17277
	public float Rotation;

	// Token: 0x0400437E RID: 17278
	public float Speed;

	// Token: 0x0400437F RID: 17279
	public string SpriteName;

	// Token: 0x04004380 RID: 17280
	public string Name;

	// Token: 0x04004381 RID: 17281
	public int DismemberPhase;

	// Token: 0x04004382 RID: 17282
	public int FingerprintID;

	// Token: 0x04004383 RID: 17283
	public int GlobalID;

	// Token: 0x04004384 RID: 17284
	public int WeaponID;

	// Token: 0x04004385 RID: 17285
	public int AnimID;

	// Token: 0x04004386 RID: 17286
	public WeaponType Type = WeaponType.Knife;

	// Token: 0x04004387 RID: 17287
	public bool[] Victims;

	// Token: 0x04004388 RID: 17288
	private AudioClip OriginalClip;

	// Token: 0x04004389 RID: 17289
	private int ID;

	// Token: 0x0400438A RID: 17290
	public MeshFilter MyMeshFilter;

	// Token: 0x0400438B RID: 17291
	public Mesh EightiesCircularSaw;

	// Token: 0x0400438C RID: 17292
	public Texture EightiesCircularSawTexture;

	// Token: 0x0400438D RID: 17293
	public GameObject HeartBurst;
}
