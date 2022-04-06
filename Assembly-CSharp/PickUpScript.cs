using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PickUpScript : MonoBehaviour
{
	// Token: 0x06001AC5 RID: 6853 RVA: 0x001218E0 File Offset: 0x0011FAE0
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		this.Clock = this.Yandere.StudentManager.Clock;
		if (!this.CanCollide)
		{
			Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
		}
		if (this.Outline.Length != 0)
		{
			this.OriginalColor = this.Outline[0].color;
		}
		this.OriginalScale = base.transform.localScale;
		if (this.MyRigidbody == null)
		{
			this.MyRigidbody = base.GetComponent<Rigidbody>();
		}
		this.Gloves = base.GetComponent<GloveScript>();
		if (this.DisableAtStart)
		{
			base.gameObject.SetActive(false);
		}
		if (GameGlobals.Eighties && this.EightiesMesh != null)
		{
			base.GetComponent<MeshFilter>().mesh = this.EightiesMesh;
			if (!this.Sign)
			{
				base.GetComponent<Renderer>().material.mainTexture = this.EightiesTexture;
			}
			else
			{
				base.GetComponent<Renderer>().materials[1].mainTexture = this.EightiesTexture;
			}
			if (this.Radio)
			{
				base.GetComponent<RadioScript>().OffTexture = this.EightiesTexture;
				base.GetComponent<RadioScript>().OnTexture = this.EightiesTexture;
			}
		}
	}

	// Token: 0x06001AC6 RID: 6854 RVA: 0x00121A28 File Offset: 0x0011FC28
	private void LateUpdate()
	{
		if (this.CleaningProduct)
		{
			if (this.Clock == null)
			{
				this.Clock = this.Yandere.StudentManager.Clock;
			}
			if (this.Clock.Period == 5)
			{
				this.Suspicious = false;
			}
			else
			{
				this.Suspicious = true;
			}
		}
		if (this.Weight)
		{
			this.Strength = this.Prompt.Yandere.Class.PhysicalGrade + this.Prompt.Yandere.Class.PhysicalBonus;
			if (this.Strength == 0)
			{
				this.Prompt.Label[3].text = "     Physical Stat Too Low";
				this.Prompt.Circle[3].fillAmount = 1f;
			}
			else
			{
				this.Prompt.Label[3].text = "     Carry";
			}
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			if (this.Weight)
			{
				if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
				{
					if (this.Yandere.PickUp != null)
					{
						this.Yandere.CharacterAnimation[this.Yandere.CarryAnims[this.Yandere.PickUp.CarryAnimID]].weight = 0f;
					}
					if (this.Yandere.Armed)
					{
						this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[this.Yandere.EquippedWeapon.AnimID]].weight = 0f;
					}
					this.Yandere.targetRotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, this.Yandere.transform.position.y, base.transform.position.z) - this.Yandere.transform.position);
					this.Yandere.transform.rotation = this.Yandere.targetRotation;
					this.Yandere.EmptyHands();
					base.transform.parent = this.Yandere.transform;
					base.transform.localPosition = new Vector3(0f, 0f, 0.79184f);
					base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					this.Yandere.Character.GetComponent<Animation>().Play("f02_heavyWeightLift_00");
					this.Yandere.HeavyWeight = true;
					this.Yandere.CanMove = false;
					this.Yandere.Lifting = true;
					this.MyAnimation.Play("Weight_liftUp_00");
					this.MyRigidbody.isKinematic = true;
					this.BeingLifted = true;
				}
			}
			else
			{
				this.BePickedUp();
			}
		}
		if (this.Yandere.PickUp == this)
		{
			base.transform.localPosition = this.HoldPosition;
			base.transform.localEulerAngles = this.HoldRotation;
		}
		if (this.Dumped)
		{
			this.DumpTimer += Time.deltaTime;
			if (this.DumpTimer > 1f)
			{
				if (this.Clothing)
				{
					this.Yandere.Incinerator.BloodyClothing++;
					if (this.RedPaint)
					{
						this.Yandere.Incinerator.ClothingWithRedPaint++;
					}
				}
				else if (this.BodyPart)
				{
					this.Yandere.Incinerator.BodyParts++;
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (this.Yandere.PickUp != this && !this.MyRigidbody.isKinematic)
		{
			if (!this.KeepGravity)
			{
				this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
			}
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
			if (base.transform.position.x > -46f && base.transform.position.x < -18f && base.transform.position.z > 66f && base.transform.position.z < 78f)
			{
				base.transform.position = new Vector3(-16f, 5f, 72f);
				this.KinematicTimer = 0f;
			}
		}
		if (this.Weight && this.BeingLifted)
		{
			if (this.Yandere.Lifting)
			{
				if (this.Yandere.StudentManager.Stop)
				{
					this.Drop();
				}
			}
			else
			{
				this.BePickedUp();
			}
		}
		if (this.Remote)
		{
			if (!this.Prompt.Carried)
			{
				this.Prompt.HideButton[0] = true;
				return;
			}
			this.Prompt.HideButton[0] = false;
			this.Prompt.HideButton[3] = true;
			if (this.Prompt.Circle[0].fillAmount < 1f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (!this.Suspicious)
				{
					if (!this.MyRadio.On)
					{
						this.MyRadio.TurnOn();
						return;
					}
					this.MyRadio.TurnOff();
					return;
				}
				else if (this.ExplosiveDevice != null)
				{
					if (!this.ExplosiveDevice.gameObject.activeInHierarchy)
					{
						this.Yandere.NotificationManager.CustomText = "Not while inside the bag!";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						return;
					}
					if (Vector3.Distance(this.Yandere.Senpai.position, this.ExplosiveDevice.position) < 4f)
					{
						this.Yandere.NotificationManager.CustomText = "I'd never hurt Senpai!";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						return;
					}
					if (Vector3.Distance(this.Yandere.transform.position, this.ExplosiveDevice.position) < 4f)
					{
						this.Yandere.NotificationManager.CustomText = "I'm too close!";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						return;
					}
					if (Vector3.Distance(this.Yandere.StudentManager.Headmaster.transform.position, this.ExplosiveDevice.position) < 4f || Vector3.Distance(this.Yandere.StudentManager.Journalist.transform.position, this.ExplosiveDevice.position) < 4f)
					{
						this.Yandere.NotificationManager.CustomText = "Something is jamming the signal?!";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						return;
					}
					this.Yandere.StudentManager.Police.EndOfDay.ExplosiveDeviceUsed = true;
					UnityEngine.Object.Instantiate<GameObject>(this.Explosion, this.ExplosiveDevice.position, Quaternion.identity);
					UnityEngine.Object.Destroy(this.ExplosiveDevice.gameObject);
					return;
				}
			}
		}
		else if (this.Usable && this.Bucket == null && this.Mop == null)
		{
			if (this.Prompt.Carried)
			{
				this.Prompt.HideButton[0] = false;
				this.Prompt.HideButton[3] = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					this.Drop();
					this.MyRigidbody.AddForce((this.Prompt.Yandere.transform.forward + this.Prompt.Yandere.transform.up) * 100f);
					this.Prompt.HideButton[3] = false;
					this.Prompt.Yandere.PotentiallyMurderousTimer = 1f;
					return;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
	}

	// Token: 0x06001AC7 RID: 6855 RVA: 0x00122354 File Offset: 0x00120554
	public void BePickedUp()
	{
		if (this.Radio && SchemeGlobals.GetSchemeStage(5) == 2)
		{
			SchemeGlobals.SetSchemeStage(5, 3);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (this.Salty && SchemeGlobals.GetSchemeStage(4) == 4)
		{
			SchemeGlobals.SetSchemeStage(4, 5);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (this.CarryAnimID == 10)
		{
			this.MyRenderer.mesh = this.OpenBook;
			this.Yandere.LifeNotePen.SetActive(true);
		}
		if (this.MyAnimation != null)
		{
			this.MyAnimation.Stop();
		}
		this.Prompt.Circle[3].fillAmount = 1f;
		this.BeingLifted = false;
		if (this.Yandere.PickUp != null)
		{
			this.Yandere.PickUp.Drop();
		}
		if (this.Yandere.Equipped == 3)
		{
			this.Yandere.Weapon[3].Drop();
		}
		else if (this.Yandere.Equipped > 0)
		{
			this.Yandere.Unequip();
		}
		if (this.Yandere.Dragging)
		{
			this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		if (this.Yandere.Carrying)
		{
			this.Yandere.StopCarrying();
		}
		if (!this.LeftHand)
		{
			base.transform.parent = this.Yandere.ItemParent;
		}
		else
		{
			base.transform.parent = this.Yandere.LeftItemParent;
		}
		if (base.GetComponent<RadioScript>() != null && base.GetComponent<RadioScript>().On)
		{
			base.GetComponent<RadioScript>().TurnOff();
		}
		this.MyCollider.enabled = false;
		if (this.MyRigidbody != null)
		{
			this.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
		if (this.Bucket != null)
		{
			this.Prompt.Label[0].text = "     Spill";
			this.Prompt.OffsetY[0] = 0.125f;
			if (this.Bucket.Full)
			{
				this.Prompt.Carried = true;
				this.Usable = true;
			}
			else
			{
				this.Usable = false;
			}
		}
		if (!this.Usable)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.NearestPrompt = null;
		}
		else
		{
			this.Prompt.Carried = true;
		}
		if ((this.PuzzleCube && !this.Cheated) || (this.SuperRobot && !this.Cheated))
		{
			this.Prompt.Yandere.Alphabet.Cheats++;
			this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			this.Cheated = true;
		}
		this.Yandere.PickUp = this;
		this.Yandere.CarryAnimID = this.CarryAnimID;
		OutlineScript[] outline = this.Outline;
		for (int i = 0; i < outline.Length; i++)
		{
			outline[i].color = new Color(0f, 0f, 0f, 1f);
		}
		if (this.BodyPart)
		{
			this.Yandere.NearBodies++;
		}
		this.Yandere.StudentManager.UpdateStudents(0);
		this.MyRigidbody.isKinematic = true;
		this.KinematicTimer = 0f;
		if (this.PickUpSound != null)
		{
			AudioSource.PlayClipAtPoint(this.PickUpSound, base.transform.position);
		}
	}

	// Token: 0x06001AC8 RID: 6856 RVA: 0x001226EC File Offset: 0x001208EC
	public void Drop()
	{
		if (this.Salty && SchemeGlobals.GetSchemeStage(4) == 5)
		{
			SchemeGlobals.SetSchemeStage(4, 4);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (this.TrashCan)
		{
			this.Yandere.MyController.radius = 0.2f;
		}
		if (this.CarryAnimID == 10)
		{
			this.MyRenderer.mesh = this.ClosedBook;
			this.Yandere.LifeNotePen.SetActive(false);
		}
		if (this.Weight)
		{
			this.Yandere.IdleAnim = this.Yandere.OriginalIdleAnim;
			this.Yandere.WalkAnim = this.Yandere.OriginalWalkAnim;
			this.Yandere.RunAnim = this.Yandere.OriginalRunAnim;
		}
		if (this.BloodCleaner != null)
		{
			this.BloodCleaner.enabled = true;
			this.BloodCleaner.Pathfinding.enabled = true;
		}
		if (this.Yandere.PickUp == this)
		{
			this.Yandere.PickUp = null;
		}
		if (this.BodyPart)
		{
			if (this.ConcealedBodyPart)
			{
				base.transform.parent = this.Yandere.Police.GarbageParent;
			}
			else
			{
				base.transform.parent = this.Yandere.LimbParent;
			}
		}
		else
		{
			base.transform.parent = null;
		}
		if (this.LockRotation)
		{
			base.transform.localEulerAngles = new Vector3(0f, base.transform.localEulerAngles.y, 0f);
		}
		if (this.MyRigidbody != null)
		{
			this.MyRigidbody.constraints = this.OriginalConstraints;
			if (this.PreventTipping)
			{
				this.MyRigidbody.constraints = (RigidbodyConstraints)80;
			}
			this.MyRigidbody.isKinematic = false;
			this.MyRigidbody.useGravity = true;
		}
		if (this.Dumped)
		{
			base.transform.position = this.Incinerator.DumpPoint.position;
			this.MyCollider.enabled = false;
		}
		else
		{
			this.Prompt.enabled = true;
			this.MyCollider.enabled = true;
			this.MyCollider.isTrigger = false;
			if (!this.CanCollide)
			{
				Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
			}
		}
		this.Prompt.Carried = false;
		if (this.Remote || this.Usable)
		{
			this.Prompt.HideButton[3] = false;
		}
		OutlineScript[] outline = this.Outline;
		for (int i = 0; i < outline.Length; i++)
		{
			outline[i].color = (this.Evidence ? this.EvidenceColor : this.OriginalColor);
		}
		base.transform.localScale = this.OriginalScale;
		if (this.BodyPart)
		{
			this.Yandere.NearBodies--;
		}
		this.Yandere.StudentManager.UpdateStudents(0);
		if (this.Sign)
		{
			if (this.Clock.Period < 3 && this.PoolClosureCollider.bounds.Contains(base.transform.position))
			{
				Debug.Log("Attempting to make students avoid the pool...");
				this.Yandere.NotificationManager.CustomText = "Students will now avoid the pool";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = this.PoolClosureCollider.transform.position;
				base.transform.eulerAngles = this.PoolClosureCollider.transform.eulerAngles;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.MyCollider.isTrigger = false;
				this.MyRigidbody.useGravity = false;
				this.MyRigidbody.isKinematic = true;
				base.enabled = false;
				this.Yandere.StudentManager.RemovePoolFromRoutines();
			}
			else
			{
				if (this.Clock.Period < 3)
				{
					this.Yandere.NotificationManager.CustomText = "Place sign at top of pool stairs";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					this.Yandere.NotificationManager.CustomText = "It's too late in the day for that";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				base.transform.eulerAngles = new Vector3(90f, 0f, 0f);
			}
		}
		if (this.StinkBombs || this.BangSnaps)
		{
			this.Prompt.Yandere.Arc.SetActive(false);
			this.Prompt.HideButton[3] = false;
			this.Prompt.HideButton[0] = true;
		}
		if (this.Bucket != null)
		{
			this.Prompt.HideButton[0] = true;
			this.Prompt.HideButton[3] = false;
			this.Prompt.OffsetY[0] = 0.5f;
		}
	}

	// Token: 0x06001AC9 RID: 6857 RVA: 0x00122BE4 File Offset: 0x00120DE4
	public void DisableGarbageBag()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.MyCollider.enabled = false;
		this.MyRigidbody.useGravity = false;
		this.MyRigidbody.isKinematic = true;
		base.enabled = false;
	}

	// Token: 0x04002C7A RID: 11386
	public RigidbodyConstraints OriginalConstraints;

	// Token: 0x04002C7B RID: 11387
	public BloodCleanerScript BloodCleaner;

	// Token: 0x04002C7C RID: 11388
	public IncineratorScript Incinerator;

	// Token: 0x04002C7D RID: 11389
	public Collider PoolClosureCollider;

	// Token: 0x04002C7E RID: 11390
	public WeaponScript StuckBoxCutter;

	// Token: 0x04002C7F RID: 11391
	public Transform ExplosiveDevice;

	// Token: 0x04002C80 RID: 11392
	public BodyPartScript BodyPart;

	// Token: 0x04002C81 RID: 11393
	public TrashCanScript TrashCan;

	// Token: 0x04002C82 RID: 11394
	public OutlineScript[] Outline;

	// Token: 0x04002C83 RID: 11395
	public Texture EightiesTexture;

	// Token: 0x04002C84 RID: 11396
	public YandereScript Yandere;

	// Token: 0x04002C85 RID: 11397
	public MeshFilter MyRenderer;

	// Token: 0x04002C86 RID: 11398
	public Animation MyAnimation;

	// Token: 0x04002C87 RID: 11399
	public AudioClip PickUpSound;

	// Token: 0x04002C88 RID: 11400
	public Rigidbody MyRigidbody;

	// Token: 0x04002C89 RID: 11401
	public ParticleSystem Smoke;

	// Token: 0x04002C8A RID: 11402
	public Collider MyCollider;

	// Token: 0x04002C8B RID: 11403
	public BucketScript Bucket;

	// Token: 0x04002C8C RID: 11404
	public AudioSource MyAudio;

	// Token: 0x04002C8D RID: 11405
	public RadioScript MyRadio;

	// Token: 0x04002C8E RID: 11406
	public PromptScript Prompt;

	// Token: 0x04002C8F RID: 11407
	public GloveScript Gloves;

	// Token: 0x04002C90 RID: 11408
	public ClockScript Clock;

	// Token: 0x04002C91 RID: 11409
	public MopScript Mop;

	// Token: 0x04002C92 RID: 11410
	public GameObject PuddleSparks;

	// Token: 0x04002C93 RID: 11411
	public GameObject TarpObject;

	// Token: 0x04002C94 RID: 11412
	public GameObject Explosion;

	// Token: 0x04002C95 RID: 11413
	public GameObject[] FoodPieces;

	// Token: 0x04002C96 RID: 11414
	public Mesh EightiesMesh;

	// Token: 0x04002C97 RID: 11415
	public Mesh ClosedBook;

	// Token: 0x04002C98 RID: 11416
	public Mesh OpenBook;

	// Token: 0x04002C99 RID: 11417
	public Vector3 TrashPosition;

	// Token: 0x04002C9A RID: 11418
	public Vector3 TrashRotation;

	// Token: 0x04002C9B RID: 11419
	public Vector3 OriginalScale;

	// Token: 0x04002C9C RID: 11420
	public Vector3 HoldPosition;

	// Token: 0x04002C9D RID: 11421
	public Vector3 HoldRotation;

	// Token: 0x04002C9E RID: 11422
	public Color EvidenceColor;

	// Token: 0x04002C9F RID: 11423
	public Color OriginalColor;

	// Token: 0x04002CA0 RID: 11424
	public bool ConcealedBodyPart;

	// Token: 0x04002CA1 RID: 11425
	public bool CleaningProduct;

	// Token: 0x04002CA2 RID: 11426
	public bool DisableAtStart;

	// Token: 0x04002CA3 RID: 11427
	public bool PreventTipping;

	// Token: 0x04002CA4 RID: 11428
	public bool GarbageBagBox;

	// Token: 0x04002CA5 RID: 11429
	public bool LockRotation;

	// Token: 0x04002CA6 RID: 11430
	public bool BeingLifted;

	// Token: 0x04002CA7 RID: 11431
	public bool KeepGravity;

	// Token: 0x04002CA8 RID: 11432
	public bool BrownPaint;

	// Token: 0x04002CA9 RID: 11433
	public bool CanCollide;

	// Token: 0x04002CAA RID: 11434
	public bool Electronic;

	// Token: 0x04002CAB RID: 11435
	public bool Flashlight;

	// Token: 0x04002CAC RID: 11436
	public bool PuzzleCube;

	// Token: 0x04002CAD RID: 11437
	public bool StinkBombs;

	// Token: 0x04002CAE RID: 11438
	public bool SuperRobot;

	// Token: 0x04002CAF RID: 11439
	public bool Suspicious;

	// Token: 0x04002CB0 RID: 11440
	public bool BangSnaps;

	// Token: 0x04002CB1 RID: 11441
	public bool Blowtorch;

	// Token: 0x04002CB2 RID: 11442
	public bool Clothing;

	// Token: 0x04002CB3 RID: 11443
	public bool Evidence;

	// Token: 0x04002CB4 RID: 11444
	public bool JerryCan;

	// Token: 0x04002CB5 RID: 11445
	public bool LeftHand;

	// Token: 0x04002CB6 RID: 11446
	public bool RedPaint;

	// Token: 0x04002CB7 RID: 11447
	public bool Cheated;

	// Token: 0x04002CB8 RID: 11448
	public bool Garbage;

	// Token: 0x04002CB9 RID: 11449
	public bool Bleach;

	// Token: 0x04002CBA RID: 11450
	public bool Dumped;

	// Token: 0x04002CBB RID: 11451
	public bool Remote;

	// Token: 0x04002CBC RID: 11452
	public bool Usable;

	// Token: 0x04002CBD RID: 11453
	public bool Weight;

	// Token: 0x04002CBE RID: 11454
	public bool TooBig;

	// Token: 0x04002CBF RID: 11455
	public bool Empty = true;

	// Token: 0x04002CC0 RID: 11456
	public bool Radio;

	// Token: 0x04002CC1 RID: 11457
	public bool Salty;

	// Token: 0x04002CC2 RID: 11458
	public bool Sign;

	// Token: 0x04002CC3 RID: 11459
	public bool Tarp;

	// Token: 0x04002CC4 RID: 11460
	public int CarryAnimID;

	// Token: 0x04002CC5 RID: 11461
	public int Strength;

	// Token: 0x04002CC6 RID: 11462
	public int Period;

	// Token: 0x04002CC7 RID: 11463
	public int Food;

	// Token: 0x04002CC8 RID: 11464
	public float KinematicTimer;

	// Token: 0x04002CC9 RID: 11465
	public float DumpTimer;
}
