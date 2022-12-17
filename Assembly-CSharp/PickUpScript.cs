using UnityEngine;

public class PickUpScript : MonoBehaviour
{
	public RigidbodyConstraints OriginalConstraints;

	public BloodCleanerScript BloodCleaner;

	public IncineratorScript Incinerator;

	public Collider PoolClosureCollider;

	public WeaponScript StuckBoxCutter;

	public Transform ExplosiveDevice;

	public BodyPartScript BodyPart;

	public TrashCanScript TrashCan;

	public OutlineScript[] Outline;

	public Texture EightiesTexture;

	public YandereScript Yandere;

	public MeshFilter MyRenderer;

	public Animation MyAnimation;

	public AudioClip PickUpSound;

	public Rigidbody MyRigidbody;

	public ParticleSystem Smoke;

	public Collider MyCollider;

	public BucketScript Bucket;

	public AudioSource MyAudio;

	public RadioScript MyRadio;

	public PromptScript Prompt;

	public GloveScript Gloves;

	public ClockScript Clock;

	public MopScript Mop;

	public GameObject PuddleSparks;

	public GameObject SmokeCloud;

	public GameObject TarpObject;

	public GameObject Explosion;

	public GameObject Flame;

	public GameObject[] FoodPieces;

	public Mesh EightiesMesh;

	public Mesh ClosedBook;

	public Mesh OpenBook;

	public Vector3 TrashPosition;

	public Vector3 TrashRotation;

	public Vector3 OriginalScale;

	public Vector3 HoldPosition;

	public Vector3 HoldRotation;

	public Color EvidenceColor;

	public Color OriginalColor;

	public bool InstantiatedObject;

	public bool ConcealedBodyPart;

	public bool CleaningProduct;

	public bool DisableAtStart;

	public bool PreventTipping;

	public bool DoNotTeleport;

	public bool GarbageBagBox;

	public bool InsideBookbag;

	public bool CannotPickUp;

	public bool LockRotation;

	public bool BeingLifted;

	public bool KeepGravity;

	public bool BrownPaint;

	public bool CanCollide;

	public bool CarBattery;

	public bool Electronic;

	public bool Flashlight;

	public bool PuzzleCube;

	public bool StinkBombs;

	public bool SuperRobot;

	public bool Suspicious;

	public bool BangSnaps;

	public bool Blowtorch;

	public bool OpenFlame;

	public bool SmokeBomb;

	public bool Clothing;

	public bool Evidence;

	public bool JerryCan;

	public bool LeftHand;

	public bool RedPaint;

	public bool Cheated;

	public bool Garbage;

	public bool Tinfoil;

	public bool Bleach;

	public bool Dumped;

	public bool Remote;

	public bool Usable;

	public bool Weight;

	public bool TooBig;

	public bool Empty = true;

	public bool Radio;

	public bool Salty;

	public bool Sign;

	public bool Tarp;

	public int CarryAnimID;

	public int Strength;

	public int Period;

	public int Food;

	public float KinematicTimer;

	public float DumpTimer;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	public SpawnedObjectType ObjectType;

	private void Start()
	{
		Yandere = Prompt.Yandere;
		if (Yandere == null)
		{
			Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		}
		Clock = Yandere.StudentManager.Clock;
		if (!CanCollide)
		{
			Physics.IgnoreCollision(Yandere.GetComponent<Collider>(), MyCollider);
		}
		if (Outline.Length != 0)
		{
			OriginalColor = Outline[0].color;
		}
		OriginalScale = base.transform.localScale;
		if (MyRigidbody == null)
		{
			MyRigidbody = GetComponent<Rigidbody>();
		}
		Gloves = GetComponent<GloveScript>();
		if (DisableAtStart)
		{
			base.gameObject.SetActive(false);
		}
		if (GameGlobals.Eighties && EightiesMesh != null)
		{
			GetComponent<MeshFilter>().mesh = EightiesMesh;
			if (!Sign)
			{
				GetComponent<Renderer>().material.mainTexture = EightiesTexture;
			}
			else
			{
				GetComponent<Renderer>().materials[1].mainTexture = EightiesTexture;
			}
			if (Radio)
			{
				GetComponent<RadioScript>().OffTexture = EightiesTexture;
				GetComponent<RadioScript>().OnTexture = EightiesTexture;
			}
		}
		Yandere.StudentManager.AllPickUps[Yandere.StudentManager.PickUpID] = this;
		Yandere.StudentManager.PickUpID++;
		if (!Clothing && BodyPart == null)
		{
			OriginalPosition = base.transform.position;
			OriginalRotation = base.transform.eulerAngles;
		}
		if (InstantiatedObject)
		{
			Yandere.StudentManager.SpawnedObjectManager.SpawnedObjectList[Yandere.StudentManager.SpawnedObjectManager.ObjectsSpawned] = ObjectType;
			Yandere.StudentManager.SpawnedObjectManager.SpawnedTransforms[Yandere.StudentManager.SpawnedObjectManager.ObjectsSpawned] = base.transform;
			Yandere.StudentManager.SpawnedObjectManager.ObjectsSpawned++;
		}
	}

	private void LateUpdate()
	{
		if (CleaningProduct)
		{
			if (Clock == null)
			{
				Clock = Yandere.StudentManager.Clock;
			}
			if (Clock.Period == 5)
			{
				Suspicious = false;
			}
			else
			{
				Suspicious = true;
			}
		}
		if (Weight)
		{
			Strength = Prompt.Yandere.Class.PhysicalGrade + Prompt.Yandere.Class.PhysicalBonus;
			if (Strength == 0)
			{
				Prompt.Label[3].text = "     Physical Stat Too Low";
				Prompt.Circle[3].fillAmount = 1f;
			}
			else
			{
				Prompt.Label[3].text = "     Carry";
			}
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Circle[3].fillAmount = 1f;
			if (Weight)
			{
				if (!Yandere.Chased && Yandere.Chasers == 0)
				{
					if (Yandere.PickUp != null)
					{
						Yandere.CharacterAnimation[Yandere.CarryAnims[Yandere.PickUp.CarryAnimID]].weight = 0f;
					}
					if (Yandere.Armed)
					{
						Yandere.CharacterAnimation[Yandere.ArmedAnims[Yandere.EquippedWeapon.AnimID]].weight = 0f;
					}
					Yandere.targetRotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, Yandere.transform.position.y, base.transform.position.z) - Yandere.transform.position);
					Yandere.transform.rotation = Yandere.targetRotation;
					Yandere.EmptyHands();
					base.transform.parent = Yandere.transform;
					base.transform.localPosition = new Vector3(0f, 0f, 0.79184f);
					base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					Yandere.Character.GetComponent<Animation>().Play("f02_heavyWeightLift_00");
					Yandere.HeavyWeight = true;
					Yandere.CanMove = false;
					Yandere.Lifting = true;
					MyAnimation.Play("Weight_liftUp_00");
					MyRigidbody.isKinematic = true;
					BeingLifted = true;
				}
			}
			else if (!CannotPickUp)
			{
				BePickedUp();
			}
		}
		if (Yandere.PickUp == this)
		{
			base.transform.localPosition = HoldPosition;
			base.transform.localEulerAngles = HoldRotation;
		}
		if (Dumped)
		{
			DumpTimer += Time.deltaTime;
			if (DumpTimer > 1f)
			{
				if (Clothing)
				{
					Yandere.Incinerator.BloodyClothing++;
					if (RedPaint)
					{
						Yandere.Incinerator.ClothingWithRedPaint++;
					}
				}
				else if ((bool)BodyPart)
				{
					Yandere.Incinerator.BodyParts++;
				}
				base.gameObject.SetActive(false);
			}
		}
		if (Yandere.PickUp != this && !MyRigidbody.isKinematic)
		{
			if (!KeepGravity)
			{
				KinematicTimer = Mathf.MoveTowards(KinematicTimer, 5f, Time.deltaTime);
			}
			if (KinematicTimer == 5f)
			{
				MyRigidbody.isKinematic = true;
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -71f && base.transform.position.x < -61f && base.transform.position.z > -37.5f && base.transform.position.z < -27.5f)
			{
				Yandere.NotificationManager.CustomText = "You can't drop that there!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = new Vector3(-63f, 1f, -26.5f);
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -46f && base.transform.position.x < -18f && base.transform.position.z > 66f && base.transform.position.z < 78f)
			{
				base.transform.position = new Vector3(-16f, 5f, 72f);
				KinematicTimer = 0f;
			}
		}
		if (Weight && BeingLifted)
		{
			if (Yandere.Lifting)
			{
				if (Yandere.StudentManager.Stop)
				{
					Drop();
				}
			}
			else if (!CannotPickUp)
			{
				BePickedUp();
			}
		}
		if (Remote)
		{
			if (Prompt.Carried)
			{
				Prompt.HideButton[0] = false;
				Prompt.HideButton[3] = true;
				if (ExplosiveDevice != null)
				{
					if (Prompt.Circle[0].fillAmount == 0f)
					{
						Prompt.Circle[0].fillAmount = 1f;
						if (!ExplosiveDevice.gameObject.activeInHierarchy)
						{
							Yandere.NotificationManager.CustomText = "Not while inside the bag!";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						else if (Vector3.Distance(Yandere.Senpai.position, ExplosiveDevice.position) < 4f)
						{
							Yandere.NotificationManager.CustomText = "I'd never hurt Senpai!";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						else if (Vector3.Distance(Yandere.transform.position, ExplosiveDevice.position) < 4f)
						{
							Yandere.NotificationManager.CustomText = "I'm too close!";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						else if (Vector3.Distance(Yandere.StudentManager.Headmaster.transform.position, ExplosiveDevice.position) < 4f || Vector3.Distance(Yandere.StudentManager.Journalist.transform.position, ExplosiveDevice.position) < 4f)
						{
							Yandere.NotificationManager.CustomText = "Something is jamming the signal?!";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						else
						{
							Yandere.StudentManager.Police.EndOfDay.ExplosiveDeviceUsed = true;
							Object.Instantiate(Explosion, ExplosiveDevice.position, Quaternion.identity);
							Object.Destroy(ExplosiveDevice.gameObject);
							Drop();
							Prompt.Hide();
							Object.Destroy(base.gameObject);
						}
					}
				}
				else if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					if (!MyRadio.On)
					{
						MyRadio.TurnOn();
					}
					else
					{
						MyRadio.TurnOff();
					}
				}
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
		}
		else if (Usable && Bucket == null && Mop == null && !StinkBombs && !BangSnaps && !SmokeBomb)
		{
			if (Prompt.Carried)
			{
				Prompt.HideButton[0] = false;
				Prompt.HideButton[3] = true;
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					DoNotTeleport = true;
					Drop();
					DoNotTeleport = false;
					MyRigidbody.AddForce((Prompt.Yandere.transform.forward + Prompt.Yandere.transform.up) * 100f);
					Prompt.HideButton[3] = false;
					if (!Prompt.Yandere.Invisible)
					{
						Prompt.Yandere.PotentiallyMurderousTimer = 1f;
					}
				}
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
		}
		else if (Flame != null)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Flame.SetActive(!Flame.activeInHierarchy);
			}
		}
		else if (SmokeBomb)
		{
			if (Prompt.Carried)
			{
				Prompt.HideButton[0] = false;
				Prompt.HideButton[3] = true;
			}
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Object.Instantiate(SmokeCloud, Yandere.transform.position, Quaternion.identity);
				Drop();
				Object.Destroy(base.gameObject);
			}
		}
		if (Flame != null && Flame.activeInHierarchy && Time.timeScale > 0.1f)
		{
			Flame.transform.localScale = new Vector3(Random.Range(17.5f, 22.5f), Random.Range(17.5f, 22.5f), Random.Range(17.5f, 22.5f));
		}
	}

	public void BePickedUp()
	{
		if (Radio && SchemeGlobals.GetSchemeStage(5) == 2)
		{
			SchemeGlobals.SetSchemeStage(5, 3);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (Salty && SchemeGlobals.GetSchemeStage(4) == 4)
		{
			SchemeGlobals.SetSchemeStage(4, 5);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (CarryAnimID == 10)
		{
			MyRenderer.mesh = OpenBook;
			Yandere.LifeNotePen.SetActive(true);
		}
		if (MyAnimation != null)
		{
			MyAnimation.Stop();
		}
		Prompt.Circle[3].fillAmount = 1f;
		BeingLifted = false;
		if (Yandere.PickUp != null)
		{
			Yandere.PickUp.Drop();
		}
		if (Yandere.Equipped == 3)
		{
			Yandere.Weapon[3].Drop();
		}
		else if (Yandere.Equipped > 0)
		{
			Yandere.Unequip();
		}
		if (Yandere.Dragging)
		{
			Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		if (Yandere.Carrying)
		{
			Yandere.StopCarrying();
		}
		if (!LeftHand)
		{
			base.transform.parent = Yandere.ItemParent;
		}
		else
		{
			base.transform.parent = Yandere.LeftItemParent;
		}
		if (GetComponent<RadioScript>() != null && GetComponent<RadioScript>().On)
		{
			GetComponent<RadioScript>().TurnOff();
		}
		MyCollider.enabled = false;
		if (MyRigidbody != null)
		{
			MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
		if (Bucket != null)
		{
			Prompt.Label[0].text = "     Spill";
			Prompt.OffsetY[0] = 0.125f;
			if (Bucket.Full)
			{
				Prompt.Carried = true;
				Usable = true;
			}
			else
			{
				Usable = false;
			}
		}
		if (!Usable)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			Yandere.NearestPrompt = null;
		}
		else
		{
			Prompt.Carried = true;
		}
		if ((PuzzleCube && !Cheated) || (SuperRobot && !Cheated))
		{
			Prompt.Yandere.Alphabet.Cheats++;
			Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			Cheated = true;
		}
		Yandere.PickUp = this;
		Yandere.CarryAnimID = CarryAnimID;
		Object.Instantiate(Yandere.PhysicsActivator, base.transform.position, Quaternion.identity);
		if ((bool)BodyPart)
		{
			Yandere.NearBodies++;
		}
		Yandere.StudentManager.UpdateStudents();
		MyRigidbody.isKinematic = true;
		KinematicTimer = 0f;
		if (PickUpSound != null)
		{
			AudioSource.PlayClipAtPoint(PickUpSound, base.transform.position);
		}
		if (StinkBombs || BangSnaps)
		{
			Prompt.Yandere.Arc.SetActive(true);
		}
		Yandere.UpdateConcealedItemStatus();
	}

	public void Drop()
	{
		if ((bool)Mop)
		{
			Mop.MyAudio.Stop();
		}
		if (!Yandere.BucketDropping)
		{
			Yandere.Direction = 1;
			Yandere.CheckForWall();
		}
		if (Yandere.WallInFront)
		{
			base.transform.position = new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z);
		}
		Yandere.WallInFront = false;
		if (Salty && SchemeGlobals.GetSchemeStage(4) == 5)
		{
			SchemeGlobals.SetSchemeStage(4, 4);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if ((bool)TrashCan)
		{
			Yandere.MyController.radius = 0.2f;
		}
		if (CarryAnimID == 10)
		{
			MyRenderer.mesh = ClosedBook;
			Yandere.LifeNotePen.SetActive(false);
		}
		if (Weight)
		{
			Yandere.IdleAnim = Yandere.OriginalIdleAnim;
			Yandere.WalkAnim = Yandere.OriginalWalkAnim;
			Yandere.RunAnim = Yandere.OriginalRunAnim;
		}
		if (BloodCleaner != null)
		{
			BloodCleaner.enabled = true;
			BloodCleaner.Pathfinding.enabled = true;
		}
		if (Yandere.PickUp == this)
		{
			Yandere.PickUp = null;
		}
		if ((bool)BodyPart)
		{
			if (ConcealedBodyPart)
			{
				base.transform.parent = Yandere.Police.GarbageParent;
			}
			else
			{
				base.transform.parent = Yandere.LimbParent;
			}
		}
		else
		{
			base.transform.parent = null;
		}
		if (LockRotation)
		{
			base.transform.localEulerAngles = new Vector3(0f, base.transform.localEulerAngles.y, 0f);
		}
		if (MyRigidbody != null)
		{
			MyRigidbody.constraints = OriginalConstraints;
			if (PreventTipping)
			{
				MyRigidbody.constraints = (RigidbodyConstraints)122;
			}
			MyRigidbody.isKinematic = false;
			MyRigidbody.useGravity = true;
		}
		if (Dumped)
		{
			base.transform.position = Incinerator.DumpPoint.position;
			MyCollider.enabled = false;
		}
		else
		{
			Prompt.enabled = true;
			MyCollider.enabled = true;
			MyCollider.isTrigger = false;
			if (!CanCollide)
			{
				Physics.IgnoreCollision(Yandere.GetComponent<Collider>(), MyCollider);
			}
		}
		Prompt.Carried = false;
		if (Remote || Usable)
		{
			Prompt.HideButton[3] = false;
		}
		base.transform.localScale = OriginalScale;
		if ((bool)BodyPart)
		{
			Yandere.NearBodies--;
		}
		Yandere.StudentManager.UpdateStudents();
		if (Sign)
		{
			if (Clock.Period < 3 && PoolClosureCollider.bounds.Contains(base.transform.position))
			{
				Debug.Log("Attempting to make students avoid the pool...");
				Yandere.NotificationManager.CustomText = "Students will now avoid the pool";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = PoolClosureCollider.transform.position;
				base.transform.eulerAngles = PoolClosureCollider.transform.eulerAngles;
				Prompt.Hide();
				Prompt.enabled = false;
				MyCollider.isTrigger = false;
				MyRigidbody.useGravity = false;
				MyRigidbody.isKinematic = true;
				base.enabled = false;
				Yandere.StudentManager.RemovePoolFromRoutines();
			}
			else
			{
				if (Clock.Period < 3)
				{
					Yandere.NotificationManager.CustomText = "Place sign at top of pool stairs";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					Yandere.NotificationManager.CustomText = "It's too late in the day for that";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				base.transform.eulerAngles = new Vector3(90f, 0f, 0f);
			}
		}
		if (StinkBombs || BangSnaps || SmokeBomb)
		{
			Prompt.Yandere.Arc.SetActive(false);
			Prompt.HideButton[3] = false;
			Prompt.HideButton[0] = true;
		}
		if (Bucket != null)
		{
			Prompt.HideButton[0] = true;
			Prompt.HideButton[3] = false;
			Prompt.OffsetY[0] = 0.5f;
		}
		if (!DoNotTeleport && (Vector3.Distance(base.transform.position, OriginalPosition) < 1f || Vector3.Distance(Yandere.transform.position, OriginalPosition) < 1f))
		{
			base.transform.position = OriginalPosition;
			base.transform.eulerAngles = OriginalRotation;
			MyRigidbody.isKinematic = true;
			MyRigidbody.useGravity = false;
			MyCollider.isTrigger = true;
		}
		DoNotTeleport = false;
	}

	public void DisableGarbageBag()
	{
		Prompt.Hide();
		Prompt.enabled = false;
		MyCollider.enabled = false;
		MyRigidbody.useGravity = false;
		MyRigidbody.isKinematic = true;
		base.enabled = false;
	}

	public void UpdateFood()
	{
		int num = 0;
		while (num < Food)
		{
			num++;
			FoodPieces[num].SetActive(true);
		}
	}
}
