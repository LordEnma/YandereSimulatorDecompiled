using System;
using UnityEngine;

// Token: 0x020003A6 RID: 934
public class PickUpScript : MonoBehaviour
{
	// Token: 0x06001AAC RID: 6828 RVA: 0x00120578 File Offset: 0x0011E778
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

	// Token: 0x06001AAD RID: 6829 RVA: 0x001206C0 File Offset: 0x0011E8C0
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

	// Token: 0x06001AAE RID: 6830 RVA: 0x00120EE4 File Offset: 0x0011F0E4
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

	// Token: 0x06001AAF RID: 6831 RVA: 0x0012121C File Offset: 0x0011F41C
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

	// Token: 0x06001AB0 RID: 6832 RVA: 0x001216BC File Offset: 0x0011F8BC
	public void DisableGarbageBag()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.MyCollider.enabled = false;
		this.MyRigidbody.useGravity = false;
		this.MyRigidbody.isKinematic = true;
		base.enabled = false;
	}

	// Token: 0x04002C37 RID: 11319
	public RigidbodyConstraints OriginalConstraints;

	// Token: 0x04002C38 RID: 11320
	public BloodCleanerScript BloodCleaner;

	// Token: 0x04002C39 RID: 11321
	public IncineratorScript Incinerator;

	// Token: 0x04002C3A RID: 11322
	public Collider PoolClosureCollider;

	// Token: 0x04002C3B RID: 11323
	public Transform ExplosiveDevice;

	// Token: 0x04002C3C RID: 11324
	public BodyPartScript BodyPart;

	// Token: 0x04002C3D RID: 11325
	public TrashCanScript TrashCan;

	// Token: 0x04002C3E RID: 11326
	public OutlineScript[] Outline;

	// Token: 0x04002C3F RID: 11327
	public YandereScript Yandere;

	// Token: 0x04002C40 RID: 11328
	public Animation MyAnimation;

	// Token: 0x04002C41 RID: 11329
	public GameObject Explosion;

	// Token: 0x04002C42 RID: 11330
	public BucketScript Bucket;

	// Token: 0x04002C43 RID: 11331
	public RadioScript MyRadio;

	// Token: 0x04002C44 RID: 11332
	public PromptScript Prompt;

	// Token: 0x04002C45 RID: 11333
	public GloveScript Gloves;

	// Token: 0x04002C46 RID: 11334
	public ClockScript Clock;

	// Token: 0x04002C47 RID: 11335
	public MopScript Mop;

	// Token: 0x04002C48 RID: 11336
	public Mesh EightiesMesh;

	// Token: 0x04002C49 RID: 11337
	public Mesh ClosedBook;

	// Token: 0x04002C4A RID: 11338
	public Mesh OpenBook;

	// Token: 0x04002C4B RID: 11339
	public Rigidbody MyRigidbody;

	// Token: 0x04002C4C RID: 11340
	public Collider MyCollider;

	// Token: 0x04002C4D RID: 11341
	public MeshFilter MyRenderer;

	// Token: 0x04002C4E RID: 11342
	public Vector3 TrashPosition;

	// Token: 0x04002C4F RID: 11343
	public Vector3 TrashRotation;

	// Token: 0x04002C50 RID: 11344
	public Vector3 OriginalScale;

	// Token: 0x04002C51 RID: 11345
	public Vector3 HoldPosition;

	// Token: 0x04002C52 RID: 11346
	public Vector3 HoldRotation;

	// Token: 0x04002C53 RID: 11347
	public Color EvidenceColor;

	// Token: 0x04002C54 RID: 11348
	public Color OriginalColor;

	// Token: 0x04002C55 RID: 11349
	public bool ConcealedBodyPart;

	// Token: 0x04002C56 RID: 11350
	public bool CleaningProduct;

	// Token: 0x04002C57 RID: 11351
	public bool DisableAtStart;

	// Token: 0x04002C58 RID: 11352
	public bool GarbageBagBox;

	// Token: 0x04002C59 RID: 11353
	public bool LockRotation;

	// Token: 0x04002C5A RID: 11354
	public bool BeingLifted;

	// Token: 0x04002C5B RID: 11355
	public bool KeepGravity;

	// Token: 0x04002C5C RID: 11356
	public bool BrownPaint;

	// Token: 0x04002C5D RID: 11357
	public bool CanCollide;

	// Token: 0x04002C5E RID: 11358
	public bool Electronic;

	// Token: 0x04002C5F RID: 11359
	public bool Flashlight;

	// Token: 0x04002C60 RID: 11360
	public bool PuzzleCube;

	// Token: 0x04002C61 RID: 11361
	public bool StinkBombs;

	// Token: 0x04002C62 RID: 11362
	public bool SuperRobot;

	// Token: 0x04002C63 RID: 11363
	public bool Suspicious;

	// Token: 0x04002C64 RID: 11364
	public bool BangSnaps;

	// Token: 0x04002C65 RID: 11365
	public bool Blowtorch;

	// Token: 0x04002C66 RID: 11366
	public bool Clothing;

	// Token: 0x04002C67 RID: 11367
	public bool Evidence;

	// Token: 0x04002C68 RID: 11368
	public bool JerryCan;

	// Token: 0x04002C69 RID: 11369
	public bool LeftHand;

	// Token: 0x04002C6A RID: 11370
	public bool RedPaint;

	// Token: 0x04002C6B RID: 11371
	public bool Cheated;

	// Token: 0x04002C6C RID: 11372
	public bool Garbage;

	// Token: 0x04002C6D RID: 11373
	public bool Bleach;

	// Token: 0x04002C6E RID: 11374
	public bool Dumped;

	// Token: 0x04002C6F RID: 11375
	public bool Remote;

	// Token: 0x04002C70 RID: 11376
	public bool Usable;

	// Token: 0x04002C71 RID: 11377
	public bool Weight;

	// Token: 0x04002C72 RID: 11378
	public bool Radio;

	// Token: 0x04002C73 RID: 11379
	public bool Salty;

	// Token: 0x04002C74 RID: 11380
	public bool Sign;

	// Token: 0x04002C75 RID: 11381
	public bool Tarp;

	// Token: 0x04002C76 RID: 11382
	public int CarryAnimID;

	// Token: 0x04002C77 RID: 11383
	public int Strength;

	// Token: 0x04002C78 RID: 11384
	public int Period;

	// Token: 0x04002C79 RID: 11385
	public int Food;

	// Token: 0x04002C7A RID: 11386
	public float KinematicTimer;

	// Token: 0x04002C7B RID: 11387
	public float DumpTimer;

	// Token: 0x04002C7C RID: 11388
	public bool Empty = true;

	// Token: 0x04002C7D RID: 11389
	public GameObject[] FoodPieces;

	// Token: 0x04002C7E RID: 11390
	public WeaponScript StuckBoxCutter;

	// Token: 0x04002C7F RID: 11391
	public GameObject TarpObject;

	// Token: 0x04002C80 RID: 11392
	public AudioClip PickUpSound;

	// Token: 0x04002C81 RID: 11393
	public AudioSource MyAudio;

	// Token: 0x04002C82 RID: 11394
	public Texture EightiesTexture;
}
