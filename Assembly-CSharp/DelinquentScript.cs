using UnityEngine;

public class DelinquentScript : MonoBehaviour
{
	private Quaternion targetRotation;

	public DelinquentManagerScript DelinquentManager;

	public YandereScript Yandere;

	public Quaternion OriginalRotation;

	public Vector3 LookAtTarget;

	public GameObject Character;

	public SkinnedMeshRenderer MyRenderer;

	public GameObject MyWeapon;

	public GameObject Jukebox;

	public Mesh LongSkirt;

	public Camera Eyes;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Default;

	public Transform Weapon;

	public Transform Neck;

	public Transform Head;

	public Plane[] Planes;

	public string CooldownAnim = "f02_idleShort_00";

	public string ThreatenAnim = "f02_threaten_00";

	public string SurpriseAnim = "f02_surprise_00";

	public string ShoveAnim = "f02_shoveB_00";

	public string SwingAnim = "f02_swingA_00";

	public string RunAnim = "f02_spring_00";

	public string IdleAnim = string.Empty;

	public string Prefix = "f02_";

	public bool ExpressedSurprise;

	public bool LookAtPlayer;

	public bool Threatening;

	public bool Attacking;

	public bool HeadStill;

	public bool Cooldown;

	public bool Shoving;

	public bool Rapping;

	public bool Run;

	public float DistanceToPlayer;

	public float RunSpeed;

	public float BustSize;

	public float Rotation;

	public float Timer;

	public int AudioPhase = 1;

	public int Spaces;

	public AudioClip[] ProximityClips;

	public AudioClip[] SurrenderClips;

	public AudioClip[] SurpriseClips;

	public AudioClip[] ThreatenClips;

	public AudioClip[] AggroClips;

	public AudioClip[] ShoveClips;

	public AudioClip[] CaseClips;

	public AudioClip SurpriseClip;

	public AudioClip AttackClip;

	public AudioClip Crumple;

	public AudioClip Strike;

	public GameObject DefaultHair;

	public GameObject Mask;

	public GameObject EasterHair;

	public GameObject Bandanas;

	public Renderer HairRenderer;

	public Color HairColor;

	public Texture BlondThugHair;

	public Transform TimePortal;

	public bool Suck;

	private void Start()
	{
		EasterHair.SetActive(value: false);
		Bandanas.SetActive(value: false);
		OriginalRotation = base.transform.rotation;
		LookAtTarget = Default.position;
		if (Weapon != null)
		{
			Weapon.localPosition = new Vector3(Weapon.localPosition.x, -0.145f, Weapon.localPosition.z);
			Rotation = 90f;
			Weapon.localEulerAngles = new Vector3(Rotation, Weapon.localEulerAngles.y, Weapon.localEulerAngles.z);
		}
	}

	private void Update()
	{
		DistanceToPlayer = Vector3.Distance(base.transform.position, Yandere.transform.position);
		AudioSource component = GetComponent<AudioSource>();
		if (DistanceToPlayer < 7f)
		{
			Planes = GeometryUtility.CalculateFrustumPlanes(Eyes);
			if (GeometryUtility.TestPlanesAABB(Planes, Yandere.GetComponent<Collider>().bounds))
			{
				if (Physics.Linecast(Eyes.transform.position, Yandere.transform.position + Vector3.up, out var hitInfo))
				{
					if (hitInfo.collider.gameObject == Yandere.gameObject)
					{
						LookAtPlayer = true;
						if (Yandere.Armed)
						{
							if (!Threatening)
							{
								component.clip = SurpriseClips[Random.Range(0, SurpriseClips.Length)];
								component.pitch = Random.Range(0.9f, 1.1f);
								component.Play();
							}
							Threatening = true;
							if (Cooldown)
							{
								Cooldown = false;
								Timer = 0f;
							}
						}
						else
						{
							if (Yandere.CorpseWarning)
							{
								if (!Threatening)
								{
									component.clip = SurpriseClips[Random.Range(0, SurpriseClips.Length)];
									component.pitch = Random.Range(0.9f, 1.1f);
									component.Play();
								}
								Threatening = true;
								if (!Yandere.Chased && Yandere.Chasers == 0)
								{
									DelinquentManager.Attacker = this;
									Run = true;
								}
								Yandere.Chased = true;
							}
							else if (!Threatening && DelinquentManager.SpeechTimer == 0f)
							{
								component.clip = ((Yandere.Container == null) ? ProximityClips[Random.Range(0, ProximityClips.Length)] : CaseClips[Random.Range(0, CaseClips.Length)]);
								component.Play();
								DelinquentManager.SpeechTimer = 10f;
							}
							LookAtPlayer = true;
						}
					}
					else
					{
						LookAtPlayer = false;
					}
				}
			}
			else
			{
				LookAtPlayer = false;
			}
		}
		if (!Threatening)
		{
			if (Shoving)
			{
				targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				targetRotation = Quaternion.LookRotation(base.transform.position - Yandere.transform.position);
				Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, targetRotation, 10f * Time.deltaTime);
				if (Character.GetComponent<Animation>()[ShoveAnim].time >= Character.GetComponent<Animation>()[ShoveAnim].length)
				{
					LookAtTarget = Neck.position + Neck.forward;
					Character.GetComponent<Animation>().CrossFade(IdleAnim, 1f);
					Shoving = false;
				}
				if (Weapon != null)
				{
					Weapon.localPosition = new Vector3(Weapon.localPosition.x, Mathf.Lerp(Weapon.localPosition.y, 0f, Time.deltaTime * 10f), Weapon.localPosition.z);
					Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 10f);
					Weapon.localEulerAngles = new Vector3(Rotation, Weapon.localEulerAngles.y, Weapon.localEulerAngles.z);
				}
			}
			else
			{
				Shove();
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, OriginalRotation, Time.deltaTime);
				if (Weapon != null)
				{
					Weapon.localPosition = new Vector3(Weapon.localPosition.x, Mathf.Lerp(Weapon.localPosition.y, -0.145f, Time.deltaTime * 10f), Weapon.localPosition.z);
					Rotation = Mathf.Lerp(Rotation, 90f, Time.deltaTime * 10f);
					Weapon.localEulerAngles = new Vector3(Rotation, Weapon.localEulerAngles.y, Weapon.localEulerAngles.z);
				}
			}
		}
		else
		{
			targetRotation = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
			if (Weapon != null)
			{
				Weapon.localPosition = new Vector3(Weapon.localPosition.x, Mathf.Lerp(Weapon.localPosition.y, 0f, Time.deltaTime * 10f), Weapon.localPosition.z);
				Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 10f);
				Weapon.localEulerAngles = new Vector3(Rotation, Weapon.localEulerAngles.y, Weapon.localEulerAngles.z);
			}
			if (DistanceToPlayer < 1f)
			{
				if (Yandere.Armed || Run)
				{
					if (!Yandere.Attacked)
					{
						if (Yandere.CanMove && ((!Yandere.Chased && Yandere.Chasers == 0) || (Yandere.Chased && DelinquentManager.Attacker == this)))
						{
							AudioSource component2 = DelinquentManager.GetComponent<AudioSource>();
							if (!component2.isPlaying)
							{
								component2.clip = AttackClip;
								component2.Play();
								DelinquentManager.enabled = false;
							}
							if (Yandere.Laughing)
							{
								Yandere.StopLaughing();
							}
							if (Yandere.Aiming)
							{
								Yandere.StopAiming();
							}
							Character.GetComponent<Animation>().CrossFade(SwingAnim);
							MyWeapon.SetActive(value: true);
							Attacking = true;
							Yandere.Character.GetComponent<Animation>().CrossFade("f02_swingB_00");
							Yandere.RPGCamera.enabled = false;
							Yandere.CanMove = false;
							Yandere.Attacked = true;
							Yandere.EmptyHands();
						}
					}
					else if (Attacking)
					{
						if (AudioPhase == 1)
						{
							if (Character.GetComponent<Animation>()[SwingAnim].time >= Character.GetComponent<Animation>()[SwingAnim].length * 0.3f)
							{
								Jukebox.SetActive(value: false);
								AudioPhase++;
								component.pitch = 1f;
								component.clip = Strike;
								component.Play();
							}
						}
						else if (AudioPhase == 2 && Character.GetComponent<Animation>()[SwingAnim].time >= Character.GetComponent<Animation>()[SwingAnim].length * 0.85f)
						{
							AudioPhase++;
							component.pitch = 1f;
							component.clip = Crumple;
							component.Play();
						}
						targetRotation = Quaternion.LookRotation(base.transform.position - Yandere.transform.position);
						Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, targetRotation, 10f * Time.deltaTime);
					}
				}
				else
				{
					Shove();
				}
			}
			else if (!ExpressedSurprise)
			{
				Character.GetComponent<Animation>().CrossFade(SurpriseAnim);
				if (Character.GetComponent<Animation>()[SurpriseAnim].time >= Character.GetComponent<Animation>()[SurpriseAnim].length)
				{
					ExpressedSurprise = true;
				}
			}
			else if (Run)
			{
				if (DistanceToPlayer > 1f)
				{
					base.transform.position = Vector3.MoveTowards(base.transform.position, Yandere.transform.position, Time.deltaTime * RunSpeed);
					Character.GetComponent<Animation>().CrossFade(RunAnim);
					RunSpeed += Time.deltaTime;
				}
			}
			else if (!Cooldown)
			{
				Character.GetComponent<Animation>().CrossFade(ThreatenAnim);
				if (!Yandere.Armed)
				{
					Timer += Time.deltaTime;
					if (Timer > 2.5f)
					{
						Cooldown = true;
						if (!DelinquentManager.GetComponent<AudioSource>().isPlaying)
						{
							DelinquentManager.SpeechTimer = Time.deltaTime;
						}
					}
				}
				else
				{
					Timer = 0f;
					if (DelinquentManager.SpeechTimer == 0f)
					{
						DelinquentManager.GetComponent<AudioSource>().clip = ThreatenClips[Random.Range(0, ThreatenClips.Length)];
						DelinquentManager.GetComponent<AudioSource>().Play();
						DelinquentManager.SpeechTimer = 10f;
					}
				}
			}
			else
			{
				if (DelinquentManager.SpeechTimer == 0f)
				{
					AudioSource component3 = DelinquentManager.GetComponent<AudioSource>();
					if (!component3.isPlaying)
					{
						component3.clip = SurrenderClips[Random.Range(0, SurrenderClips.Length)];
						component3.Play();
						DelinquentManager.SpeechTimer = 5f;
					}
				}
				Character.GetComponent<Animation>().CrossFade(CooldownAnim, 2.5f);
				Timer += Time.deltaTime;
				if (Timer > 5f)
				{
					Character.GetComponent<Animation>().CrossFade(IdleAnim, 1f);
					ExpressedSurprise = false;
					Threatening = false;
					Cooldown = false;
					Timer = 0f;
				}
				Shove();
			}
		}
		if (Input.GetKeyDown(KeyCode.V) && LongSkirt != null)
		{
			MyRenderer.sharedMesh = LongSkirt;
		}
		if (Input.GetKeyDown(KeyCode.Space) && Vector3.Distance(Yandere.transform.position, DelinquentManager.transform.position) < 10f)
		{
			Spaces++;
			if (Spaces == 9)
			{
				if (HairRenderer == null)
				{
					DefaultHair.SetActive(value: false);
					EasterHair.SetActive(value: true);
					EasterHair.GetComponent<Renderer>().material.mainTexture = BlondThugHair;
				}
			}
			else if (Spaces == 10)
			{
				Rapping = true;
				MyWeapon.SetActive(value: false);
				IdleAnim = Prefix + "gruntIdle_00";
				Animation component4 = Character.GetComponent<Animation>();
				component4.CrossFade(IdleAnim);
				component4[IdleAnim].time = Random.Range(0f, component4[IdleAnim].length);
				DefaultHair.SetActive(value: false);
				Mask.SetActive(value: false);
				EasterHair.SetActive(value: true);
				Bandanas.SetActive(value: true);
				if (HairRenderer != null)
				{
					HairRenderer.material.color = HairColor;
				}
				DelinquentManager.EasterEgg();
			}
		}
		if (Suck)
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, TimePortal.position, Time.deltaTime * 10f);
			if (base.transform.position == TimePortal.position)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}

	private void Shove()
	{
		if (!Yandere.Shoved && !Yandere.Tripping && DistanceToPlayer < 0.5f)
		{
			AudioSource component = DelinquentManager.GetComponent<AudioSource>();
			component.clip = ShoveClips[Random.Range(0, ShoveClips.Length)];
			component.Play();
			DelinquentManager.SpeechTimer = 5f;
			if (Yandere.transform.position.x > base.transform.position.x)
			{
				Yandere.transform.position = new Vector3(base.transform.position.x - 0.001f, Yandere.transform.position.y, Yandere.transform.position.z);
			}
			if (Yandere.Aiming)
			{
				Yandere.StopAiming();
			}
			Animation component2 = Character.GetComponent<Animation>();
			component2[ShoveAnim].time = 0f;
			component2.CrossFade(ShoveAnim);
			Shoving = true;
			Yandere.Character.GetComponent<Animation>().CrossFade("f02_shoveA_01");
			Yandere.Punching = false;
			Yandere.CanMove = false;
			Yandere.Shoved = true;
			Yandere.ShoveSpeed = 2f;
			ExpressedSurprise = false;
			Threatening = false;
			Cooldown = false;
			Timer = 0f;
		}
	}

	private void LateUpdate()
	{
		if (!Threatening)
		{
			if (!Shoving && !Rapping)
			{
				LookAtTarget = Vector3.Lerp(LookAtTarget, LookAtPlayer ? Yandere.Head.position : Default.position, Time.deltaTime * 2f);
				Neck.LookAt(LookAtTarget);
			}
			if (HeadStill)
			{
				Head.transform.localEulerAngles = Vector3.zero;
			}
		}
		if (BustSize > 0f)
		{
			RightBreast.localScale = new Vector3(BustSize, BustSize, BustSize);
			LeftBreast.localScale = new Vector3(BustSize, BustSize, BustSize);
		}
	}

	private void OnEnable()
	{
		Character.GetComponent<Animation>().CrossFade(IdleAnim, 1f);
	}
}
