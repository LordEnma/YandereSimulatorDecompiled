using UnityEngine;

public class WeaponScript : MonoBehaviour
{
	public ParticleSystem[] ShortBloodSpray;

	public ParticleSystem[] BloodSpray;

	public OutlineScript[] Outline;

	public Transform[] ScytheParts;

	public float[] SoundTime;

	public IncineratorScript Incinerator;

	public StudentScript Returner;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform Origin;

	public Transform Parent;

	public AudioClip[] Clips;

	public AudioClip[] Clips2;

	public AudioClip[] Clips3;

	public AudioClip DismemberClip;

	public AudioClip EquipClip;

	public SkinnedMeshRenderer ChainsawTeeth;

	public StudentScript InteractingStudent;

	public SkinnedMeshRenderer SkinnedMesh;

	public ParticleSystem FireEffect;

	public GameObject WeaponTrail;

	public GameObject ExtraBlade;

	public AudioSource FireAudio;

	public Rigidbody MyRigidbody;

	public AudioSource MyAudio;

	public Renderer MyRenderer;

	public GameObject Nails;

	public Transform Blade;

	public Projector Blood;

	public Collider SecondaryCollider;

	public Collider MyCollider;

	public Vector3 StartingPosition;

	public Vector3 StartingRotation;

	public bool UnequipImmediately;

	public bool InsideIncinerator;

	public bool AlreadyExamined;

	public bool BroughtFromHome;

	public bool DelinquentOwned;

	public bool DisableCollider;

	public bool DoNotDisable;

	public bool Dismembering;

	public bool MurderWeapon;

	public bool WeaponEffect;

	public bool Concealable;

	public bool Undroppable;

	public bool Suspicious;

	public bool Dangerous;

	public bool Misplaced;

	public bool Chainsaw;

	public bool Disposed;

	public bool Evidence;

	public bool Innocent;

	public bool LeftHand;

	public bool StartLow;

	public bool Animate;

	public bool Flaming;

	public bool Unravel;

	public bool Bloody;

	public bool Broken;

	public bool Dumped;

	public bool Heated;

	public bool Rotate;

	public bool Blunt;

	public bool InBag;

	public bool Metal;

	public bool Flip;

	public bool Spin;

	public Color EvidenceColor;

	public Color OriginalColor;

	public float TargetWeaponDistance = 1.2f;

	public float OriginalOffset;

	public float KinematicTimer;

	public float AnimTimer;

	public float DumpTimer;

	public float Rotation;

	public float Speed;

	public Vector3 UnravelPosition = new Vector3(0.05f, -0.033333f, 0.04f);

	public Vector3 UnravelRotation = new Vector3(17.5f, 35f, -15f);

	public string SpriteName;

	public string Name;

	public int DismemberPhase;

	public int FingerprintID;

	public int GlobalID;

	public int WeaponID;

	public int AnimID;

	public int BagID;

	public WeaponType Type = WeaponType.Knife;

	private AudioClip OriginalClip;

	private int ID;

	public MeshFilter MyMeshFilter;

	public Mesh EightiesCircularSaw;

	public Texture EightiesCircularSawTexture;

	public bool[] Victims;

	public bool ClubProperty;

	public bool OneOfAKind;

	public ClubType Club;

	public Vector3 CustomRotation;

	public GameObject EightiesObject;

	public GameObject ModernObject;

	public Vector3[] TargetRotation;

	public Vector3[] Rotations;

	public Texture BloodTexture;

	public Texture CensorTexture;

	public bool DoNotRelocate;

	public GameObject HeartBurst;

	public BoxCollider CookingClub;

	public CarryableCardboardBoxScript Box;

	public bool InBox;

	public Material CensorMaterial;

	public void Start()
	{
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		StartingPosition = base.transform.position;
		StartingRotation = base.transform.eulerAngles;
		Physics.IgnoreCollision(Yandere.GetComponent<Collider>(), MyCollider);
		if (SecondaryCollider != null)
		{
			Physics.IgnoreCollision(Yandere.GetComponent<Collider>(), SecondaryCollider);
		}
		OriginalColor = Outline[0].color;
		if (StartLow)
		{
			OriginalOffset = Prompt.OffsetY[3];
			Prompt.OffsetY[3] = 0.2f;
		}
		if (DisableCollider)
		{
			MyCollider.enabled = false;
			if (SecondaryCollider != null)
			{
				SecondaryCollider.enabled = false;
			}
		}
		MyAudio = GetComponent<AudioSource>();
		if (MyAudio != null)
		{
			OriginalClip = MyAudio.clip;
		}
		MyRigidbody = GetComponent<Rigidbody>();
		MyRigidbody.isKinematic = true;
		if (!BroughtFromHome)
		{
			Transform parent = GameObject.Find("WeaponOriginParent").transform;
			Origin = Object.Instantiate(Prompt.Yandere.StudentManager.EmptyObject, base.transform.position, Quaternion.identity).transform;
			Origin.parent = parent;
		}
		if (GameGlobals.Eighties)
		{
			if (WeaponID == 7)
			{
				MyMeshFilter.mesh = EightiesCircularSaw;
				MyRenderer.material.mainTexture = EightiesCircularSawTexture;
				MyRenderer.transform.localPosition = new Vector3(0.005f, 0.045f, -0.0075f);
			}
			else if (WeaponID == 14)
			{
				EightiesObject.SetActive(value: true);
				ModernObject.SetActive(value: false);
				MyRenderer = EightiesObject.GetComponent<Renderer>();
			}
			else if (EightiesCircularSawTexture != null)
			{
				MyRenderer.material.mainTexture = EightiesCircularSawTexture;
			}
		}
		Innocent = !Suspicious;
		if (WeaponID == 7 || WeaponID == 10 || WeaponID == 13)
		{
			TargetWeaponDistance = 5f;
		}
		if (Rotations.Length != 0)
		{
			Rotations = TargetRotation;
		}
		if (BloodSpray.Length != 0 && BloodSpray[0] != null)
		{
			UpdateBloodSpray();
		}
	}

	public string GetTypePrefix()
	{
		switch (Type)
		{
		case WeaponType.Knife:
			return "knife";
		case WeaponType.Katana:
			return "katana";
		case WeaponType.Bat:
			return "bat";
		case WeaponType.Saw:
			return "saw";
		case WeaponType.Syringe:
			return "syringe";
		case WeaponType.Weight:
			return "weight";
		case WeaponType.Scythe:
			return "scythe";
		case WeaponType.Garrote:
			return "strangle";
		case WeaponType.Chainsaw:
			return "chainsaw";
		default:
			Debug.LogError("Weapon type \"" + Type.ToString() + "\" not implemented.");
			return string.Empty;
		}
	}

	public AudioClip GetClip(float sanity, bool stealth)
	{
		AudioClip[] array = ((Clips2.Length != 0) ? ((Random.Range(2, 4) == 2) ? Clips2 : Clips3) : Clips);
		if (stealth)
		{
			return array[0];
		}
		if (sanity > 2f / 3f)
		{
			return array[1];
		}
		if (sanity > 1f / 3f)
		{
			return array[2];
		}
		return array[3];
	}

	private void Update()
	{
		if (WeaponID == 16 && Yandere.EquippedWeapon == this && Input.GetButtonDown(InputNames.Xbox_RB) && ExtraBlade != null)
		{
			ExtraBlade.SetActive(!ExtraBlade.activeInHierarchy);
		}
		if (Dismembering)
		{
			_ = Chainsaw;
			if (DismemberPhase < 4)
			{
				if (MyAudio.time > 0.75f)
				{
					if (Speed < 36f)
					{
						Speed += Time.deltaTime + 10f;
					}
					if (!Chainsaw)
					{
						Rotation += Speed;
						Blade.localEulerAngles = new Vector3(Rotation, Blade.localEulerAngles.y, Blade.localEulerAngles.z);
					}
					else
					{
						ChainsawTeeth.SetBlendShapeWeight(0, Random.Range(0, 101));
					}
				}
				if (MyAudio.time > SoundTime[DismemberPhase])
				{
					Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 2.5f : 5f) * Yandere.Numbness;
					Yandere.Bloodiness += 25f;
					ShortBloodSpray[0].Play();
					ShortBloodSpray[1].Play();
					if (!Blood.enabled)
					{
						Yandere.StainWeapon();
					}
					DismemberPhase++;
					if (Yandere.Gloved && !Yandere.Gloves.Blood.enabled)
					{
						Yandere.Gloves.Blood.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 1f));
						Yandere.Gloves.Blood.material.mainTexture = Yandere.BloodTextures[5];
						Yandere.Gloves.PickUp.Evidence = true;
						Yandere.Gloves.Blood.enabled = true;
						Yandere.GloveBlood = 1;
						Yandere.Police.BloodyClothing++;
					}
				}
			}
			else
			{
				if (!Chainsaw)
				{
					Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 2f);
					Blade.localEulerAngles = new Vector3(Rotation, Blade.localEulerAngles.y, Blade.localEulerAngles.z);
				}
				if (!MyAudio.isPlaying)
				{
					MyAudio.clip = OriginalClip;
					Dismembering = false;
					DismemberPhase = 0;
					Rotation = 0f;
					Speed = 0f;
				}
			}
		}
		else if (Yandere.EquippedWeapon == this)
		{
			if (Yandere.AttackManager.IsAttacking())
			{
				if (Type == WeaponType.Knife)
				{
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, Mathf.Lerp(base.transform.localEulerAngles.y, Flip ? 180f : 0f, Time.deltaTime * 10f), base.transform.localEulerAngles.z);
				}
				else if (Type == WeaponType.Saw)
				{
					if (Spin)
					{
						Blade.transform.localEulerAngles = new Vector3(Blade.transform.localEulerAngles.x + Time.deltaTime * 360f, Blade.transform.localEulerAngles.y, Blade.transform.localEulerAngles.z);
					}
				}
				else if (Type == WeaponType.Scythe)
				{
					MyRenderer.transform.localEulerAngles = new Vector3(12.5f, 7.5f, 90f);
				}
				else if (Type == WeaponType.Chainsaw && Spin)
				{
					ChainsawTeeth.SetBlendShapeWeight(0, Random.Range(0, 101));
				}
			}
		}
		else if (!MyRigidbody.isKinematic && Yandere.Police.EndOfDay.Phase == 1)
		{
			if (base.transform.position.y < 0f)
			{
				Debug.Log("Allegedly, a weapon named " + Name + " just fell beneath y 0?");
				base.transform.position = new Vector3(base.transform.position.x, 0.025f, base.transform.position.z);
			}
			KinematicTimer = Mathf.MoveTowards(KinematicTimer, 5f, Time.deltaTime);
			if (KinematicTimer == 5f)
			{
				MyRigidbody.isKinematic = true;
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -71f && base.transform.position.x < -61f && base.transform.position.z > -37.5f && base.transform.position.z < -27.5f)
			{
				Yandere.NotificationManager.CustomText = "The weapon has been placed nearby.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = new Vector3(-63f, 1f, -26.5f);
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -21f && base.transform.position.x < 21f && base.transform.position.z > 100f && base.transform.position.z < 133f)
			{
				Yandere.NotificationManager.CustomText = "A weapon rolled to the bottom of the hill.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = new Vector3(0f, 0.5f, 99.5f);
				KinematicTimer = 0f;
			}
			if (base.transform.position.z >= 133f && base.transform.position.y < Yandere.transform.position.y)
			{
				Debug.Log("Popping an object up above the ground.");
				base.transform.position += Vector3.up;
			}
			if (base.transform.position.x > -46f && base.transform.position.x < -18f && base.transform.position.z > 66f && base.transform.position.z < 78f)
			{
				base.transform.position = new Vector3(-16f, 5f, 72f);
				KinematicTimer = 0f;
			}
		}
		if (Rotate)
		{
			base.transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
		}
		if (Unravel)
		{
			if (Yandere.Attacking)
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, UnravelPosition, Time.deltaTime * 2f);
				base.transform.localEulerAngles = UnravelRotation;
				if (SkinnedMesh.GetBlendShapeWeight(0) < 100f)
				{
					SkinnedMesh.SetBlendShapeWeight(0, SkinnedMesh.GetBlendShapeWeight(0) + Time.deltaTime * 200f);
				}
			}
			else
			{
				SkinnedMesh.SetBlendShapeWeight(0, SkinnedMesh.GetBlendShapeWeight(0) - Time.deltaTime * 200f);
				if (SkinnedMesh.GetBlendShapeWeight(0) <= 0f)
				{
					base.transform.localPosition = Vector3.zero;
					base.transform.localEulerAngles = Vector3.zero;
					if (CustomRotation != Vector3.zero)
					{
						base.transform.localPosition = CustomRotation;
					}
					Unravel = false;
				}
			}
		}
		if (WeaponID == 24 && Flip)
		{
			base.transform.localEulerAngles = new Vector3(2f, -172f, -102.5f);
		}
		if (Animate)
		{
			Rotations[0] = Vector3.Lerp(Rotations[0], TargetRotation[0], Time.deltaTime * 10f);
			Rotations[1] = Vector3.Lerp(Rotations[1], TargetRotation[1], Time.deltaTime * 10f);
			Rotations[2] = Vector3.Lerp(Rotations[2], TargetRotation[2], Time.deltaTime * 10f);
			ScytheParts[0].transform.localEulerAngles = Rotations[0];
			ScytheParts[1].transform.localEulerAngles = Rotations[1];
			ScytheParts[2].transform.localEulerAngles = Rotations[2];
			AnimTimer = Mathf.MoveTowards(AnimTimer, 0f, Time.deltaTime);
			if (AnimTimer == 0f)
			{
				Animate = false;
			}
		}
	}

	private void LateUpdate()
	{
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			if (Returner != null && (!Returner.Alive || !Returner.WitnessedMurder))
			{
				Returner = null;
			}
			if (Returner != null)
			{
				Prompt.Circle[3].fillAmount = 1f;
				Yandere.NotificationManager.CustomText = "Someone is currently interacting with that weapon...";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else
			{
				Equip();
			}
		}
		if (Yandere.EquippedWeapon == this)
		{
			if (Yandere.Armed)
			{
				base.transform.localScale = new Vector3(1f, 1f, 1f);
				if (!Yandere.Struggling)
				{
					if (Yandere.CanMove)
					{
						base.transform.localPosition = Vector3.zero;
						if (Type == WeaponType.Bat)
						{
							base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
						}
						else
						{
							base.transform.localEulerAngles = CustomRotation;
						}
					}
				}
				else
				{
					base.transform.localPosition = new Vector3(-0.01f, 0.005f, -0.01f);
				}
			}
			if (Club == ClubType.Cooking && Yandere.Club == ClubType.Cooking)
			{
				SuspicionCheck();
			}
		}
		if (Dumped)
		{
			DumpTimer += Time.deltaTime;
			if (DumpTimer > 1f)
			{
				if (MurderWeapon)
				{
					Yandere.Incinerator.MurderWeapons++;
				}
				if (Bloody)
				{
					Yandere.Incinerator.BloodyWeapons++;
				}
				base.gameObject.SetActive(value: false);
			}
		}
		if ((base.transform.parent == Yandere.ItemParent || base.transform.parent == Yandere.LeftItemParent) && Concealable && Yandere.Weapon[1] != this && Yandere.Weapon[2] != this)
		{
			Drop();
		}
	}

	public void Equip()
	{
		Debug.Log("Yandere-chan just equipped a " + Name + ".");
		if (ScytheParts.Length != 0)
		{
			AnimTimer = 5f;
			Animate = true;
			TargetRotation[0] = new Vector3(90f, -3.254547f, 0f);
			TargetRotation[1] = new Vector3(0f, 0f, -7.877716f);
			TargetRotation[2] = new Vector3(0f, 0f, 100.2056f);
		}
		InBag = false;
		if (WeaponID == 6 && SchemeGlobals.GetSchemeStage(4) == 1)
		{
			SchemeGlobals.SetSchemeStage(4, 2);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		Prompt.Circle[3].fillAmount = 1f;
		if (Yandere.ImmunityTimer == 0f && Yandere.Chasers == 0)
		{
			if (Prompt.Suspicious)
			{
				Yandere.TheftTimer = 0.1f;
			}
			SuspicionCheck();
			if (Suspicious)
			{
				Yandere.WeaponTimer = 0.1f;
			}
		}
		if (!Yandere.Gloved)
		{
			if (FingerprintID == 0)
			{
				Yandere.WeaponManager.WeaponsTouched++;
				if (Yandere.WeaponManager.WeaponsTouched > 19)
				{
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("WeaponMaster", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
			}
			FingerprintID = 100;
		}
		for (ID = 0; ID < Outline.Length; ID++)
		{
			if (Outline[ID] != null)
			{
				Outline[ID].color = new Color(0f, 0f, 0f, 1f);
			}
		}
		if (LeftHand)
		{
			base.transform.parent = Yandere.LeftItemParent;
		}
		else
		{
			base.transform.parent = Yandere.ItemParent;
		}
		base.transform.localPosition = Vector3.zero;
		if (Type == WeaponType.Bat)
		{
			base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
		}
		else
		{
			base.transform.localEulerAngles = Vector3.zero;
		}
		MyCollider.enabled = false;
		if (SecondaryCollider != null)
		{
			SecondaryCollider.enabled = false;
		}
		MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
		if (Yandere.Equipped == 3 && Yandere.Weapon[3] != null)
		{
			Yandere.Weapon[3].Drop();
		}
		if (Yandere.PickUp != null)
		{
			Yandere.PickUp.Drop();
		}
		if (Yandere.Dragging)
		{
			Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		if (Yandere.Carrying)
		{
			Yandere.StopCarrying();
		}
		if (Concealable)
		{
			if (Yandere.Weapon[1] == null)
			{
				if (Yandere.Weapon[2] != null)
				{
					Yandere.Weapon[2].gameObject.SetActive(value: false);
				}
				Yandere.Equipped = 1;
				Yandere.EquippedWeapon = this;
				Yandere.WeaponManager.SetEquippedWeapon1(this);
			}
			else if (Yandere.Weapon[2] == null)
			{
				if (Yandere.Weapon[1] != null)
				{
					if (!DoNotDisable)
					{
						Yandere.Weapon[1].gameObject.SetActive(value: false);
					}
					DoNotDisable = false;
				}
				Yandere.Equipped = 2;
				Yandere.EquippedWeapon = this;
				Yandere.WeaponManager.SetEquippedWeapon2(this);
			}
			else if (Yandere.Weapon[2].gameObject.activeInHierarchy)
			{
				Yandere.Weapon[2].Drop();
				Yandere.Equipped = 2;
				Yandere.EquippedWeapon = this;
				Yandere.WeaponManager.SetEquippedWeapon2(this);
			}
			else
			{
				Yandere.Weapon[1].Drop();
				Yandere.Equipped = 1;
				Yandere.EquippedWeapon = this;
				Yandere.WeaponManager.SetEquippedWeapon1(this);
			}
		}
		else
		{
			if (Yandere.Weapon[1] != null)
			{
				Yandere.Weapon[1].gameObject.SetActive(value: false);
			}
			if (Yandere.Weapon[2] != null)
			{
				Yandere.Weapon[2].gameObject.SetActive(value: false);
			}
			Yandere.Equipped = 3;
			Yandere.EquippedWeapon = this;
			Yandere.WeaponManager.SetEquippedWeapon3(this);
		}
		Object.Instantiate(Yandere.PhysicsActivator, base.transform.position, Quaternion.identity);
		Yandere.StudentManager.UpdateStudents();
		Prompt.Hide();
		Prompt.enabled = false;
		Yandere.NearestPrompt = null;
		if (WeaponID == 9 || WeaponID == 10 || WeaponID == 12 || WeaponID == 14 || WeaponID == 16 || WeaponID == 22 || WeaponID == 25)
		{
			SuspicionCheck();
		}
		if (Yandere.EquippedWeapon.Suspicious)
		{
			if (!Yandere.WeaponWarning)
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Armed);
				Yandere.WeaponWarning = true;
			}
		}
		else
		{
			Yandere.WeaponWarning = false;
		}
		Yandere.WeaponMenu.UpdateSprites();
		Yandere.WeaponManager.UpdateLabels();
		if (Blood.enabled)
		{
			Yandere.Police.BloodyWeapons--;
		}
		if (WeaponID == 11)
		{
			Yandere.IdleAnim = "CyborgNinja_Idle_Armed";
			Yandere.WalkAnim = "CyborgNinja_Walk_Armed";
			Yandere.RunAnim = "CyborgNinja_Run_Armed";
		}
		if (WeaponID == 26)
		{
			WeaponTrail.SetActive(value: true);
		}
		KinematicTimer = 0f;
		AudioSource.PlayClipAtPoint(EquipClip, Yandere.MainCamera.transform.position);
		if (UnequipImmediately)
		{
			Debug.Log("This weapon knows that it should unequip itself.");
			UnequipImmediately = false;
			Yandere.BypassRequirement = true;
			Yandere.Unequip();
		}
		Yandere.UpdateConcealedWeaponStatus();
	}

	public void Drop()
	{
		if (Undroppable)
		{
			return;
		}
		if (ScytheParts.Length != 0)
		{
			AnimTimer = 5f;
			Animate = true;
			TargetRotation[0] = new Vector3(90f, 15f, 0f);
			TargetRotation[1] = new Vector3(0f, 0f, -172.6f);
			TargetRotation[2] = new Vector3(0f, 0f, 179.2f);
		}
		if (Unravel)
		{
			SkinnedMesh.SetBlendShapeWeight(0, 0f);
			Unravel = false;
		}
		if (!DoNotRelocate && (Yandere.PersonaID == 4 || Yandere.h != 0f || Yandere.v != 0f))
		{
			base.transform.position = Yandere.transform.position + new Vector3(0f, 1f, 0f);
		}
		DoNotRelocate = false;
		if (WeaponID == 6 && SchemeGlobals.GetSchemeStage(4) == 2)
		{
			SchemeGlobals.SetSchemeStage(4, 1);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (WeaponID == 11)
		{
			Yandere.IdleAnim = "CyborgNinja_Idle_Unarmed";
			Yandere.WalkAnim = Yandere.OriginalWalkAnim;
			Yandere.RunAnim = "CyborgNinja_Run_Unarmed";
		}
		if (StartLow)
		{
			Prompt.OffsetY[3] = OriginalOffset;
		}
		if (Yandere.Weapon[1] == this)
		{
			Yandere.WeaponManager.YandereWeapon1 = -1;
		}
		else if (Yandere.Weapon[2] == this)
		{
			Yandere.WeaponManager.YandereWeapon2 = -1;
		}
		else if (Yandere.Weapon[3] == this)
		{
			Yandere.WeaponManager.YandereWeapon3 = -1;
		}
		if (Yandere.EquippedWeapon == this)
		{
			Yandere.EquippedWeapon = null;
			Yandere.Equipped = 0;
			Yandere.StudentManager.UpdateStudents();
		}
		base.gameObject.SetActive(value: true);
		base.transform.parent = null;
		if (MyRigidbody != null)
		{
			MyRigidbody.constraints = RigidbodyConstraints.None;
			MyRigidbody.isKinematic = false;
			MyRigidbody.useGravity = true;
		}
		MyCollider.isTrigger = false;
		if (SecondaryCollider != null)
		{
			SecondaryCollider.isTrigger = false;
		}
		if (Dumped)
		{
			base.transform.position = Incinerator.DumpPoint.position;
		}
		else
		{
			Prompt.enabled = true;
			MyCollider.enabled = true;
			if (SecondaryCollider != null)
			{
				SecondaryCollider.enabled = true;
			}
			if (Yandere.GetComponent<Collider>().enabled)
			{
				Physics.IgnoreCollision(Yandere.GetComponent<Collider>(), MyCollider);
				if (SecondaryCollider != null)
				{
					Physics.IgnoreCollision(Yandere.GetComponent<Collider>(), SecondaryCollider);
				}
			}
		}
		if (Blood.enabled)
		{
			Debug.Log("This weapon, " + base.gameObject.name + " is now incrementing Police.BloodyWeapons.");
			Yandere.Police.BloodyWeapons++;
		}
		if (Vector3.Distance(StartingPosition, base.transform.position) > 2f && Vector3.Distance(base.transform.position, Yandere.StudentManager.WeaponBoxSpot.parent.position) > 2f)
		{
			if (!Misplaced)
			{
				Prompt.Yandere.WeaponManager.MisplacedWeapons++;
				Misplaced = true;
			}
		}
		else if (Misplaced)
		{
			Prompt.Yandere.WeaponManager.MisplacedWeapons--;
			Misplaced = false;
		}
		for (ID = 0; ID < Outline.Length; ID++)
		{
			Outline[ID].color = (Evidence ? EvidenceColor : OriginalColor);
		}
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
		if (WeaponID == 26)
		{
			base.transform.parent = Parent;
			base.transform.localEulerAngles = Vector3.zero;
			base.transform.localPosition = Vector3.zero;
			MyRigidbody.isKinematic = true;
			WeaponTrail.SetActive(value: false);
		}
		if (Vector3.Distance(base.transform.position, StartingPosition) < 1f || Vector3.Distance(Yandere.transform.position, StartingPosition) < 1f)
		{
			base.transform.position = StartingPosition;
			base.transform.eulerAngles = StartingRotation;
			MyRigidbody.isKinematic = true;
			MyRigidbody.useGravity = false;
			MyCollider.isTrigger = true;
			if (SecondaryCollider != null)
			{
				SecondaryCollider.isTrigger = true;
			}
		}
	}

	public void UpdateLabel()
	{
		if (!(this != null) || !base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (Yandere.Weapon[1] != null && Yandere.Weapon[2] != null && Concealable)
		{
			if (Prompt.Label[3] != null)
			{
				if (!Yandere.Armed || Yandere.Equipped == 3)
				{
					Prompt.Label[3].text = "     Swap " + Yandere.Weapon[1].Name + " for " + Name;
				}
				else
				{
					Prompt.Label[3].text = "     Swap " + Yandere.EquippedWeapon.Name + " for " + Name;
				}
			}
		}
		else if (Prompt.Label[3] != null)
		{
			Prompt.Label[3].text = "     " + Name;
		}
	}

	public void Effect()
	{
		if (WeaponID == 7)
		{
			BloodSpray[0].Play();
			BloodSpray[1].Play();
		}
		else if (WeaponID == 8)
		{
			base.gameObject.GetComponent<ParticleSystem>().Play();
			MyAudio.clip = OriginalClip;
			MyAudio.Play();
		}
		else if (WeaponID == 2 || WeaponID == 9 || WeaponID == 10 || WeaponID == 12 || WeaponID == 13)
		{
			MyAudio.Play();
		}
		else if (WeaponID == 14)
		{
			Object.Instantiate(HeartBurst, Yandere.TargetStudent.Head.position, Quaternion.identity);
			MyAudio.Play();
		}
	}

	public void Dismember()
	{
		Yandere.CameraEffects.UpdateDOF(2f / 3f);
		MyAudio.clip = DismemberClip;
		MyAudio.Play();
		Dismembering = true;
	}

	public void SuspicionCheck()
	{
		if (Innocent)
		{
			Suspicious = false;
		}
		else if (Club == ClubType.Cooking && Yandere.Club == ClubType.Cooking)
		{
			if (CookingClub.bounds.Contains(Yandere.transform.position))
			{
				Debug.Log("Ayano is inside of the Cooking Club.");
				Suspicious = false;
			}
			else
			{
				Debug.Log("Ayano is not inside of the Cooking Club.");
				Suspicious = true;
			}
		}
		else
		{
			if (Yandere == null)
			{
				Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
			}
			if ((WeaponID == 9 && Yandere.Club == ClubType.Sports) || (WeaponID == 10 && Yandere.Club == ClubType.Gardening) || (WeaponID == 12 && Yandere.Club == ClubType.Sports) || (WeaponID == 14 && Yandere.Club == ClubType.Drama) || (WeaponID == 16 && Yandere.Club == ClubType.Drama) || (WeaponID == 22 && Yandere.Club == ClubType.Drama) || (WeaponID == 25 && Yandere.Club == ClubType.LightMusic))
			{
				Suspicious = false;
			}
			else
			{
				Suspicious = true;
			}
		}
		if (Bloody)
		{
			Suspicious = true;
		}
		else
		{
			for (ID = 0; ID < Outline.Length; ID++)
			{
				if (Outline[ID] != null)
				{
					Outline[ID].color = new Color(0f, 1f, 1f, 1f);
				}
			}
		}
		if (Nails != null && Nails.activeInHierarchy)
		{
			Suspicious = true;
		}
	}

	public void StainWithBlood()
	{
		if (MyRenderer.materials.Length > 1)
		{
			MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
		}
		else
		{
			MyRenderer.material.SetFloat("_BlendAmount", 1f);
		}
	}

	public void RemoveBlood()
	{
		if (MyRenderer.materials.Length > 1)
		{
			MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		}
		else
		{
			MyRenderer.material.SetFloat("_BlendAmount", 0f);
		}
	}

	public void GetStuckInBox()
	{
		Physics.IgnoreCollision(Box.GetComponent<Collider>(), MyCollider);
		if (Prompt.Yandere.EquippedWeapon == this)
		{
			Prompt.Yandere.DropTimer[Prompt.Yandere.Equipped] = 0.5f;
			Prompt.Yandere.DropWeapon(Prompt.Yandere.Equipped);
		}
		MyRigidbody.useGravity = false;
		MyRigidbody.isKinematic = true;
		MyCollider.isTrigger = true;
		base.transform.parent = Box.transform;
		base.transform.localPosition = new Vector3(0f, 0.24f, 0f);
		base.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		Prompt.Hide();
		Prompt.enabled = false;
		base.enabled = false;
		base.gameObject.SetActive(value: true);
		Box.PickUp.StuckBoxCutter = this;
		InBox = true;
	}

	public void UpdateBloodSpray()
	{
		if (GameGlobals.CensorBlood)
		{
			ReplaceBloodWithFlowers(BloodSpray[0]);
			ReplaceBloodWithFlowers(BloodSpray[1]);
			ReplaceBloodWithFlowers(ShortBloodSpray[0]);
			ReplaceBloodWithFlowers(ShortBloodSpray[1]);
		}
		else
		{
			BloodSpray[0].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = BloodTexture;
			BloodSpray[1].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = BloodTexture;
			ShortBloodSpray[0].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = BloodTexture;
			ShortBloodSpray[1].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = BloodTexture;
		}
	}

	public void ReplaceBloodWithFlowers(ParticleSystem ps)
	{
		ParticleSystemRenderer component = ps.GetComponent<ParticleSystemRenderer>();
		component.material = CensorMaterial;
		component.material.color = Color.white;
		ParticleSystem.ColorOverLifetimeModule colorOverLifetime = ps.colorOverLifetime;
		colorOverLifetime.enabled = false;
		ps.startColor = Color.white;
	}
}
