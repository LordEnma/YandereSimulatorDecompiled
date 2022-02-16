using System;
using UnityEngine;

// Token: 0x020003A5 RID: 933
public class PickUpScript : MonoBehaviour
{
	// Token: 0x06001AA2 RID: 6818 RVA: 0x0011F78C File Offset: 0x0011D98C
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

	// Token: 0x06001AA3 RID: 6819 RVA: 0x0011F8D4 File Offset: 0x0011DAD4
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
			if (this.Prompt.Carried)
			{
				this.Prompt.HideButton[0] = false;
				this.Prompt.HideButton[3] = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
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
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
	}

	// Token: 0x06001AA4 RID: 6820 RVA: 0x001200F8 File Offset: 0x0011E2F8
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

	// Token: 0x06001AA5 RID: 6821 RVA: 0x00120430 File Offset: 0x0011E630
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
		if (this.Remote)
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
	}

	// Token: 0x06001AA6 RID: 6822 RVA: 0x001208D0 File Offset: 0x0011EAD0
	public void DisableGarbageBag()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.MyCollider.enabled = false;
		this.MyRigidbody.useGravity = false;
		this.MyRigidbody.isKinematic = true;
		base.enabled = false;
	}

	// Token: 0x04002C11 RID: 11281
	public RigidbodyConstraints OriginalConstraints;

	// Token: 0x04002C12 RID: 11282
	public BloodCleanerScript BloodCleaner;

	// Token: 0x04002C13 RID: 11283
	public IncineratorScript Incinerator;

	// Token: 0x04002C14 RID: 11284
	public Collider PoolClosureCollider;

	// Token: 0x04002C15 RID: 11285
	public Transform ExplosiveDevice;

	// Token: 0x04002C16 RID: 11286
	public BodyPartScript BodyPart;

	// Token: 0x04002C17 RID: 11287
	public TrashCanScript TrashCan;

	// Token: 0x04002C18 RID: 11288
	public OutlineScript[] Outline;

	// Token: 0x04002C19 RID: 11289
	public YandereScript Yandere;

	// Token: 0x04002C1A RID: 11290
	public Animation MyAnimation;

	// Token: 0x04002C1B RID: 11291
	public GameObject Explosion;

	// Token: 0x04002C1C RID: 11292
	public BucketScript Bucket;

	// Token: 0x04002C1D RID: 11293
	public RadioScript MyRadio;

	// Token: 0x04002C1E RID: 11294
	public PromptScript Prompt;

	// Token: 0x04002C1F RID: 11295
	public GloveScript Gloves;

	// Token: 0x04002C20 RID: 11296
	public ClockScript Clock;

	// Token: 0x04002C21 RID: 11297
	public MopScript Mop;

	// Token: 0x04002C22 RID: 11298
	public Mesh EightiesMesh;

	// Token: 0x04002C23 RID: 11299
	public Mesh ClosedBook;

	// Token: 0x04002C24 RID: 11300
	public Mesh OpenBook;

	// Token: 0x04002C25 RID: 11301
	public Rigidbody MyRigidbody;

	// Token: 0x04002C26 RID: 11302
	public Collider MyCollider;

	// Token: 0x04002C27 RID: 11303
	public MeshFilter MyRenderer;

	// Token: 0x04002C28 RID: 11304
	public Vector3 TrashPosition;

	// Token: 0x04002C29 RID: 11305
	public Vector3 TrashRotation;

	// Token: 0x04002C2A RID: 11306
	public Vector3 OriginalScale;

	// Token: 0x04002C2B RID: 11307
	public Vector3 HoldPosition;

	// Token: 0x04002C2C RID: 11308
	public Vector3 HoldRotation;

	// Token: 0x04002C2D RID: 11309
	public Color EvidenceColor;

	// Token: 0x04002C2E RID: 11310
	public Color OriginalColor;

	// Token: 0x04002C2F RID: 11311
	public bool ConcealedBodyPart;

	// Token: 0x04002C30 RID: 11312
	public bool CleaningProduct;

	// Token: 0x04002C31 RID: 11313
	public bool DisableAtStart;

	// Token: 0x04002C32 RID: 11314
	public bool GarbageBagBox;

	// Token: 0x04002C33 RID: 11315
	public bool LockRotation;

	// Token: 0x04002C34 RID: 11316
	public bool BeingLifted;

	// Token: 0x04002C35 RID: 11317
	public bool KeepGravity;

	// Token: 0x04002C36 RID: 11318
	public bool BrownPaint;

	// Token: 0x04002C37 RID: 11319
	public bool CanCollide;

	// Token: 0x04002C38 RID: 11320
	public bool Electronic;

	// Token: 0x04002C39 RID: 11321
	public bool Flashlight;

	// Token: 0x04002C3A RID: 11322
	public bool PuzzleCube;

	// Token: 0x04002C3B RID: 11323
	public bool StinkBombs;

	// Token: 0x04002C3C RID: 11324
	public bool SuperRobot;

	// Token: 0x04002C3D RID: 11325
	public bool Suspicious;

	// Token: 0x04002C3E RID: 11326
	public bool BangSnaps;

	// Token: 0x04002C3F RID: 11327
	public bool Blowtorch;

	// Token: 0x04002C40 RID: 11328
	public bool Clothing;

	// Token: 0x04002C41 RID: 11329
	public bool Evidence;

	// Token: 0x04002C42 RID: 11330
	public bool JerryCan;

	// Token: 0x04002C43 RID: 11331
	public bool LeftHand;

	// Token: 0x04002C44 RID: 11332
	public bool RedPaint;

	// Token: 0x04002C45 RID: 11333
	public bool Cheated;

	// Token: 0x04002C46 RID: 11334
	public bool Garbage;

	// Token: 0x04002C47 RID: 11335
	public bool Bleach;

	// Token: 0x04002C48 RID: 11336
	public bool Dumped;

	// Token: 0x04002C49 RID: 11337
	public bool Remote;

	// Token: 0x04002C4A RID: 11338
	public bool Usable;

	// Token: 0x04002C4B RID: 11339
	public bool Weight;

	// Token: 0x04002C4C RID: 11340
	public bool Radio;

	// Token: 0x04002C4D RID: 11341
	public bool Salty;

	// Token: 0x04002C4E RID: 11342
	public bool Sign;

	// Token: 0x04002C4F RID: 11343
	public bool Tarp;

	// Token: 0x04002C50 RID: 11344
	public int CarryAnimID;

	// Token: 0x04002C51 RID: 11345
	public int Strength;

	// Token: 0x04002C52 RID: 11346
	public int Period;

	// Token: 0x04002C53 RID: 11347
	public int Food;

	// Token: 0x04002C54 RID: 11348
	public float KinematicTimer;

	// Token: 0x04002C55 RID: 11349
	public float DumpTimer;

	// Token: 0x04002C56 RID: 11350
	public bool Empty = true;

	// Token: 0x04002C57 RID: 11351
	public GameObject[] FoodPieces;

	// Token: 0x04002C58 RID: 11352
	public WeaponScript StuckBoxCutter;

	// Token: 0x04002C59 RID: 11353
	public GameObject TarpObject;

	// Token: 0x04002C5A RID: 11354
	public AudioClip PickUpSound;

	// Token: 0x04002C5B RID: 11355
	public AudioSource MyAudio;

	// Token: 0x04002C5C RID: 11356
	public Texture EightiesTexture;
}
