using System;
using UnityEngine;

// Token: 0x0200027A RID: 634
public class DelinquentScript : MonoBehaviour
{
	// Token: 0x0600136C RID: 4972 RVA: 0x000B18C4 File Offset: 0x000AFAC4
	private void Start()
	{
		this.EasterHair.SetActive(false);
		this.Bandanas.SetActive(false);
		this.OriginalRotation = base.transform.rotation;
		this.LookAtTarget = this.Default.position;
		if (this.Weapon != null)
		{
			this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, -0.145f, this.Weapon.localPosition.z);
			this.Rotation = 90f;
			this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
		}
	}

	// Token: 0x0600136D RID: 4973 RVA: 0x000B1990 File Offset: 0x000AFB90
	private void Update()
	{
		this.DistanceToPlayer = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.DistanceToPlayer < 7f)
		{
			this.Planes = GeometryUtility.CalculateFrustumPlanes(this.Eyes);
			if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.GetComponent<Collider>().bounds))
			{
				RaycastHit raycastHit;
				if (Physics.Linecast(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up, out raycastHit))
				{
					if (raycastHit.collider.gameObject == this.Yandere.gameObject)
					{
						this.LookAtPlayer = true;
						if (this.Yandere.Armed)
						{
							if (!this.Threatening)
							{
								component.clip = this.SurpriseClips[UnityEngine.Random.Range(0, this.SurpriseClips.Length)];
								component.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
								component.Play();
							}
							this.Threatening = true;
							if (this.Cooldown)
							{
								this.Cooldown = false;
								this.Timer = 0f;
							}
						}
						else
						{
							if (this.Yandere.CorpseWarning)
							{
								if (!this.Threatening)
								{
									component.clip = this.SurpriseClips[UnityEngine.Random.Range(0, this.SurpriseClips.Length)];
									component.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
									component.Play();
								}
								this.Threatening = true;
								if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
								{
									this.DelinquentManager.Attacker = this;
									this.Run = true;
								}
								this.Yandere.Chased = true;
							}
							else if (!this.Threatening && this.DelinquentManager.SpeechTimer == 0f)
							{
								component.clip = ((this.Yandere.Container == null) ? this.ProximityClips[UnityEngine.Random.Range(0, this.ProximityClips.Length)] : this.CaseClips[UnityEngine.Random.Range(0, this.CaseClips.Length)]);
								component.Play();
								this.DelinquentManager.SpeechTimer = 10f;
							}
							this.LookAtPlayer = true;
						}
					}
					else
					{
						this.LookAtPlayer = false;
					}
				}
			}
			else
			{
				this.LookAtPlayer = false;
			}
		}
		if (!this.Threatening)
		{
			if (this.Shoving)
			{
				this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				this.targetRotation = Quaternion.LookRotation(base.transform.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				if (this.Character.GetComponent<Animation>()[this.ShoveAnim].time >= this.Character.GetComponent<Animation>()[this.ShoveAnim].length)
				{
					this.LookAtTarget = this.Neck.position + this.Neck.forward;
					this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim, 1f);
					this.Shoving = false;
				}
				if (this.Weapon != null)
				{
					this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, Mathf.Lerp(this.Weapon.localPosition.y, 0f, Time.deltaTime * 10f), this.Weapon.localPosition.z);
					this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
					this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
				}
			}
			else
			{
				this.Shove();
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.OriginalRotation, Time.deltaTime);
				if (this.Weapon != null)
				{
					this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, Mathf.Lerp(this.Weapon.localPosition.y, -0.145f, Time.deltaTime * 10f), this.Weapon.localPosition.z);
					this.Rotation = Mathf.Lerp(this.Rotation, 90f, Time.deltaTime * 10f);
					this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
				}
			}
		}
		else
		{
			this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			if (this.Weapon != null)
			{
				this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, Mathf.Lerp(this.Weapon.localPosition.y, 0f, Time.deltaTime * 10f), this.Weapon.localPosition.z);
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
				this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
			}
			if (this.DistanceToPlayer < 1f)
			{
				if (this.Yandere.Armed || this.Run)
				{
					if (!this.Yandere.Attacked)
					{
						if (this.Yandere.CanMove && ((!this.Yandere.Chased && this.Yandere.Chasers == 0) || (this.Yandere.Chased && this.DelinquentManager.Attacker == this)))
						{
							AudioSource component2 = this.DelinquentManager.GetComponent<AudioSource>();
							if (!component2.isPlaying)
							{
								component2.clip = this.AttackClip;
								component2.Play();
								this.DelinquentManager.enabled = false;
							}
							if (this.Yandere.Laughing)
							{
								this.Yandere.StopLaughing();
							}
							if (this.Yandere.Aiming)
							{
								this.Yandere.StopAiming();
							}
							this.Character.GetComponent<Animation>().CrossFade(this.SwingAnim);
							this.MyWeapon.SetActive(true);
							this.Attacking = true;
							this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_swingB_00");
							this.Yandere.RPGCamera.enabled = false;
							this.Yandere.CanMove = false;
							this.Yandere.Attacked = true;
							this.Yandere.EmptyHands();
						}
					}
					else if (this.Attacking)
					{
						if (this.AudioPhase == 1)
						{
							if (this.Character.GetComponent<Animation>()[this.SwingAnim].time >= this.Character.GetComponent<Animation>()[this.SwingAnim].length * 0.3f)
							{
								this.Jukebox.SetActive(false);
								this.AudioPhase++;
								component.pitch = 1f;
								component.clip = this.Strike;
								component.Play();
							}
						}
						else if (this.AudioPhase == 2 && this.Character.GetComponent<Animation>()[this.SwingAnim].time >= this.Character.GetComponent<Animation>()[this.SwingAnim].length * 0.85f)
						{
							this.AudioPhase++;
							component.pitch = 1f;
							component.clip = this.Crumple;
							component.Play();
						}
						this.targetRotation = Quaternion.LookRotation(base.transform.position - this.Yandere.transform.position);
						this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					}
				}
				else
				{
					this.Shove();
				}
			}
			else if (!this.ExpressedSurprise)
			{
				this.Character.GetComponent<Animation>().CrossFade(this.SurpriseAnim);
				if (this.Character.GetComponent<Animation>()[this.SurpriseAnim].time >= this.Character.GetComponent<Animation>()[this.SurpriseAnim].length)
				{
					this.ExpressedSurprise = true;
				}
			}
			else if (this.Run)
			{
				if (this.DistanceToPlayer > 1f)
				{
					base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yandere.transform.position, Time.deltaTime * this.RunSpeed);
					this.Character.GetComponent<Animation>().CrossFade(this.RunAnim);
					this.RunSpeed += Time.deltaTime;
				}
			}
			else if (!this.Cooldown)
			{
				this.Character.GetComponent<Animation>().CrossFade(this.ThreatenAnim);
				if (!this.Yandere.Armed)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 2.5f)
					{
						this.Cooldown = true;
						if (!this.DelinquentManager.GetComponent<AudioSource>().isPlaying)
						{
							this.DelinquentManager.SpeechTimer = Time.deltaTime;
						}
					}
				}
				else
				{
					this.Timer = 0f;
					if (this.DelinquentManager.SpeechTimer == 0f)
					{
						this.DelinquentManager.GetComponent<AudioSource>().clip = this.ThreatenClips[UnityEngine.Random.Range(0, this.ThreatenClips.Length)];
						this.DelinquentManager.GetComponent<AudioSource>().Play();
						this.DelinquentManager.SpeechTimer = 10f;
					}
				}
			}
			else
			{
				if (this.DelinquentManager.SpeechTimer == 0f)
				{
					AudioSource component3 = this.DelinquentManager.GetComponent<AudioSource>();
					if (!component3.isPlaying)
					{
						component3.clip = this.SurrenderClips[UnityEngine.Random.Range(0, this.SurrenderClips.Length)];
						component3.Play();
						this.DelinquentManager.SpeechTimer = 5f;
					}
				}
				this.Character.GetComponent<Animation>().CrossFade(this.CooldownAnim, 2.5f);
				this.Timer += Time.deltaTime;
				if (this.Timer > 5f)
				{
					this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim, 1f);
					this.ExpressedSurprise = false;
					this.Threatening = false;
					this.Cooldown = false;
					this.Timer = 0f;
				}
				this.Shove();
			}
		}
		if (Input.GetKeyDown(KeyCode.V) && this.LongSkirt != null)
		{
			this.MyRenderer.sharedMesh = this.LongSkirt;
		}
		if (Input.GetKeyDown(KeyCode.Space) && Vector3.Distance(this.Yandere.transform.position, this.DelinquentManager.transform.position) < 10f)
		{
			this.Spaces++;
			if (this.Spaces == 9)
			{
				if (this.HairRenderer == null)
				{
					this.DefaultHair.SetActive(false);
					this.EasterHair.SetActive(true);
					this.EasterHair.GetComponent<Renderer>().material.mainTexture = this.BlondThugHair;
				}
			}
			else if (this.Spaces == 10)
			{
				this.Rapping = true;
				this.MyWeapon.SetActive(false);
				this.IdleAnim = this.Prefix + "gruntIdle_00";
				Animation component4 = this.Character.GetComponent<Animation>();
				component4.CrossFade(this.IdleAnim);
				component4[this.IdleAnim].time = UnityEngine.Random.Range(0f, component4[this.IdleAnim].length);
				this.DefaultHair.SetActive(false);
				this.Mask.SetActive(false);
				this.EasterHair.SetActive(true);
				this.Bandanas.SetActive(true);
				if (this.HairRenderer != null)
				{
					this.HairRenderer.material.color = this.HairColor;
				}
				this.DelinquentManager.EasterEgg();
			}
		}
		if (this.Suck)
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, this.TimePortal.position, Time.deltaTime * 10f);
			if (base.transform.position == this.TimePortal.position)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x0600136E RID: 4974 RVA: 0x000B2780 File Offset: 0x000B0980
	private void Shove()
	{
		if (!this.Yandere.Shoved && !this.Yandere.Tripping && this.DistanceToPlayer < 0.5f)
		{
			AudioSource component = this.DelinquentManager.GetComponent<AudioSource>();
			component.clip = this.ShoveClips[UnityEngine.Random.Range(0, this.ShoveClips.Length)];
			component.Play();
			this.DelinquentManager.SpeechTimer = 5f;
			if (this.Yandere.transform.position.x > base.transform.position.x)
			{
				this.Yandere.transform.position = new Vector3(base.transform.position.x - 0.001f, this.Yandere.transform.position.y, this.Yandere.transform.position.z);
			}
			if (this.Yandere.Aiming)
			{
				this.Yandere.StopAiming();
			}
			Animation component2 = this.Character.GetComponent<Animation>();
			component2[this.ShoveAnim].time = 0f;
			component2.CrossFade(this.ShoveAnim);
			this.Shoving = true;
			this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_shoveA_01");
			this.Yandere.Punching = false;
			this.Yandere.CanMove = false;
			this.Yandere.Shoved = true;
			this.Yandere.ShoveSpeed = 2f;
			this.ExpressedSurprise = false;
			this.Threatening = false;
			this.Cooldown = false;
			this.Timer = 0f;
		}
	}

	// Token: 0x0600136F RID: 4975 RVA: 0x000B2930 File Offset: 0x000B0B30
	private void LateUpdate()
	{
		if (!this.Threatening)
		{
			if (!this.Shoving && !this.Rapping)
			{
				this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.LookAtPlayer ? this.Yandere.Head.position : this.Default.position, Time.deltaTime * 2f);
				this.Neck.LookAt(this.LookAtTarget);
			}
			if (this.HeadStill)
			{
				this.Head.transform.localEulerAngles = Vector3.zero;
			}
		}
		if (this.BustSize > 0f)
		{
			this.RightBreast.localScale = new Vector3(this.BustSize, this.BustSize, this.BustSize);
			this.LeftBreast.localScale = new Vector3(this.BustSize, this.BustSize, this.BustSize);
		}
	}

	// Token: 0x06001370 RID: 4976 RVA: 0x000B2A15 File Offset: 0x000B0C15
	private void OnEnable()
	{
		this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim, 1f);
	}

	// Token: 0x04001C5D RID: 7261
	private Quaternion targetRotation;

	// Token: 0x04001C5E RID: 7262
	public DelinquentManagerScript DelinquentManager;

	// Token: 0x04001C5F RID: 7263
	public YandereScript Yandere;

	// Token: 0x04001C60 RID: 7264
	public Quaternion OriginalRotation;

	// Token: 0x04001C61 RID: 7265
	public Vector3 LookAtTarget;

	// Token: 0x04001C62 RID: 7266
	public GameObject Character;

	// Token: 0x04001C63 RID: 7267
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001C64 RID: 7268
	public GameObject MyWeapon;

	// Token: 0x04001C65 RID: 7269
	public GameObject Jukebox;

	// Token: 0x04001C66 RID: 7270
	public Mesh LongSkirt;

	// Token: 0x04001C67 RID: 7271
	public Camera Eyes;

	// Token: 0x04001C68 RID: 7272
	public Transform RightBreast;

	// Token: 0x04001C69 RID: 7273
	public Transform LeftBreast;

	// Token: 0x04001C6A RID: 7274
	public Transform Default;

	// Token: 0x04001C6B RID: 7275
	public Transform Weapon;

	// Token: 0x04001C6C RID: 7276
	public Transform Neck;

	// Token: 0x04001C6D RID: 7277
	public Transform Head;

	// Token: 0x04001C6E RID: 7278
	public Plane[] Planes;

	// Token: 0x04001C6F RID: 7279
	public string CooldownAnim = "f02_idleShort_00";

	// Token: 0x04001C70 RID: 7280
	public string ThreatenAnim = "f02_threaten_00";

	// Token: 0x04001C71 RID: 7281
	public string SurpriseAnim = "f02_surprise_00";

	// Token: 0x04001C72 RID: 7282
	public string ShoveAnim = "f02_shoveB_00";

	// Token: 0x04001C73 RID: 7283
	public string SwingAnim = "f02_swingA_00";

	// Token: 0x04001C74 RID: 7284
	public string RunAnim = "f02_spring_00";

	// Token: 0x04001C75 RID: 7285
	public string IdleAnim = string.Empty;

	// Token: 0x04001C76 RID: 7286
	public string Prefix = "f02_";

	// Token: 0x04001C77 RID: 7287
	public bool ExpressedSurprise;

	// Token: 0x04001C78 RID: 7288
	public bool LookAtPlayer;

	// Token: 0x04001C79 RID: 7289
	public bool Threatening;

	// Token: 0x04001C7A RID: 7290
	public bool Attacking;

	// Token: 0x04001C7B RID: 7291
	public bool HeadStill;

	// Token: 0x04001C7C RID: 7292
	public bool Cooldown;

	// Token: 0x04001C7D RID: 7293
	public bool Shoving;

	// Token: 0x04001C7E RID: 7294
	public bool Rapping;

	// Token: 0x04001C7F RID: 7295
	public bool Run;

	// Token: 0x04001C80 RID: 7296
	public float DistanceToPlayer;

	// Token: 0x04001C81 RID: 7297
	public float RunSpeed;

	// Token: 0x04001C82 RID: 7298
	public float BustSize;

	// Token: 0x04001C83 RID: 7299
	public float Rotation;

	// Token: 0x04001C84 RID: 7300
	public float Timer;

	// Token: 0x04001C85 RID: 7301
	public int AudioPhase = 1;

	// Token: 0x04001C86 RID: 7302
	public int Spaces;

	// Token: 0x04001C87 RID: 7303
	public AudioClip[] ProximityClips;

	// Token: 0x04001C88 RID: 7304
	public AudioClip[] SurrenderClips;

	// Token: 0x04001C89 RID: 7305
	public AudioClip[] SurpriseClips;

	// Token: 0x04001C8A RID: 7306
	public AudioClip[] ThreatenClips;

	// Token: 0x04001C8B RID: 7307
	public AudioClip[] AggroClips;

	// Token: 0x04001C8C RID: 7308
	public AudioClip[] ShoveClips;

	// Token: 0x04001C8D RID: 7309
	public AudioClip[] CaseClips;

	// Token: 0x04001C8E RID: 7310
	public AudioClip SurpriseClip;

	// Token: 0x04001C8F RID: 7311
	public AudioClip AttackClip;

	// Token: 0x04001C90 RID: 7312
	public AudioClip Crumple;

	// Token: 0x04001C91 RID: 7313
	public AudioClip Strike;

	// Token: 0x04001C92 RID: 7314
	public GameObject DefaultHair;

	// Token: 0x04001C93 RID: 7315
	public GameObject Mask;

	// Token: 0x04001C94 RID: 7316
	public GameObject EasterHair;

	// Token: 0x04001C95 RID: 7317
	public GameObject Bandanas;

	// Token: 0x04001C96 RID: 7318
	public Renderer HairRenderer;

	// Token: 0x04001C97 RID: 7319
	public Color HairColor;

	// Token: 0x04001C98 RID: 7320
	public Texture BlondThugHair;

	// Token: 0x04001C99 RID: 7321
	public Transform TimePortal;

	// Token: 0x04001C9A RID: 7322
	public bool Suck;
}
