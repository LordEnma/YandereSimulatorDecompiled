using System;
using UnityEngine;

// Token: 0x020003A1 RID: 929
public class PickUpScript : MonoBehaviour
{
	// Token: 0x06001A87 RID: 6791 RVA: 0x0011DE44 File Offset: 0x0011C044
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		this.Clock = GameObject.Find("Clock").GetComponent<ClockScript>();
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

	// Token: 0x06001A88 RID: 6792 RVA: 0x0011DF8C File Offset: 0x0011C18C
	private void LateUpdate()
	{
		if (this.CleaningProduct)
		{
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

	// Token: 0x06001A89 RID: 6793 RVA: 0x0011E78C File Offset: 0x0011C98C
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

	// Token: 0x06001A8A RID: 6794 RVA: 0x0011EAC4 File Offset: 0x0011CCC4
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

	// Token: 0x06001A8B RID: 6795 RVA: 0x0011EF64 File Offset: 0x0011D164
	public void DisableGarbageBag()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.MyCollider.enabled = false;
		this.MyRigidbody.useGravity = false;
		this.MyRigidbody.isKinematic = true;
		base.enabled = false;
	}

	// Token: 0x04002BCA RID: 11210
	public RigidbodyConstraints OriginalConstraints;

	// Token: 0x04002BCB RID: 11211
	public BloodCleanerScript BloodCleaner;

	// Token: 0x04002BCC RID: 11212
	public IncineratorScript Incinerator;

	// Token: 0x04002BCD RID: 11213
	public Collider PoolClosureCollider;

	// Token: 0x04002BCE RID: 11214
	public Transform ExplosiveDevice;

	// Token: 0x04002BCF RID: 11215
	public BodyPartScript BodyPart;

	// Token: 0x04002BD0 RID: 11216
	public TrashCanScript TrashCan;

	// Token: 0x04002BD1 RID: 11217
	public OutlineScript[] Outline;

	// Token: 0x04002BD2 RID: 11218
	public YandereScript Yandere;

	// Token: 0x04002BD3 RID: 11219
	public Animation MyAnimation;

	// Token: 0x04002BD4 RID: 11220
	public GameObject Explosion;

	// Token: 0x04002BD5 RID: 11221
	public BucketScript Bucket;

	// Token: 0x04002BD6 RID: 11222
	public RadioScript MyRadio;

	// Token: 0x04002BD7 RID: 11223
	public PromptScript Prompt;

	// Token: 0x04002BD8 RID: 11224
	public GloveScript Gloves;

	// Token: 0x04002BD9 RID: 11225
	public ClockScript Clock;

	// Token: 0x04002BDA RID: 11226
	public MopScript Mop;

	// Token: 0x04002BDB RID: 11227
	public Mesh EightiesMesh;

	// Token: 0x04002BDC RID: 11228
	public Mesh ClosedBook;

	// Token: 0x04002BDD RID: 11229
	public Mesh OpenBook;

	// Token: 0x04002BDE RID: 11230
	public Rigidbody MyRigidbody;

	// Token: 0x04002BDF RID: 11231
	public Collider MyCollider;

	// Token: 0x04002BE0 RID: 11232
	public MeshFilter MyRenderer;

	// Token: 0x04002BE1 RID: 11233
	public Vector3 TrashPosition;

	// Token: 0x04002BE2 RID: 11234
	public Vector3 TrashRotation;

	// Token: 0x04002BE3 RID: 11235
	public Vector3 OriginalScale;

	// Token: 0x04002BE4 RID: 11236
	public Vector3 HoldPosition;

	// Token: 0x04002BE5 RID: 11237
	public Vector3 HoldRotation;

	// Token: 0x04002BE6 RID: 11238
	public Color EvidenceColor;

	// Token: 0x04002BE7 RID: 11239
	public Color OriginalColor;

	// Token: 0x04002BE8 RID: 11240
	public bool ConcealedBodyPart;

	// Token: 0x04002BE9 RID: 11241
	public bool CleaningProduct;

	// Token: 0x04002BEA RID: 11242
	public bool DisableAtStart;

	// Token: 0x04002BEB RID: 11243
	public bool GarbageBagBox;

	// Token: 0x04002BEC RID: 11244
	public bool LockRotation;

	// Token: 0x04002BED RID: 11245
	public bool BeingLifted;

	// Token: 0x04002BEE RID: 11246
	public bool KeepGravity;

	// Token: 0x04002BEF RID: 11247
	public bool BrownPaint;

	// Token: 0x04002BF0 RID: 11248
	public bool CanCollide;

	// Token: 0x04002BF1 RID: 11249
	public bool Electronic;

	// Token: 0x04002BF2 RID: 11250
	public bool Flashlight;

	// Token: 0x04002BF3 RID: 11251
	public bool PuzzleCube;

	// Token: 0x04002BF4 RID: 11252
	public bool StinkBombs;

	// Token: 0x04002BF5 RID: 11253
	public bool SuperRobot;

	// Token: 0x04002BF6 RID: 11254
	public bool Suspicious;

	// Token: 0x04002BF7 RID: 11255
	public bool BangSnaps;

	// Token: 0x04002BF8 RID: 11256
	public bool Blowtorch;

	// Token: 0x04002BF9 RID: 11257
	public bool Clothing;

	// Token: 0x04002BFA RID: 11258
	public bool Evidence;

	// Token: 0x04002BFB RID: 11259
	public bool JerryCan;

	// Token: 0x04002BFC RID: 11260
	public bool LeftHand;

	// Token: 0x04002BFD RID: 11261
	public bool RedPaint;

	// Token: 0x04002BFE RID: 11262
	public bool Cheated;

	// Token: 0x04002BFF RID: 11263
	public bool Garbage;

	// Token: 0x04002C00 RID: 11264
	public bool Bleach;

	// Token: 0x04002C01 RID: 11265
	public bool Dumped;

	// Token: 0x04002C02 RID: 11266
	public bool Remote;

	// Token: 0x04002C03 RID: 11267
	public bool Usable;

	// Token: 0x04002C04 RID: 11268
	public bool Weight;

	// Token: 0x04002C05 RID: 11269
	public bool Radio;

	// Token: 0x04002C06 RID: 11270
	public bool Salty;

	// Token: 0x04002C07 RID: 11271
	public bool Sign;

	// Token: 0x04002C08 RID: 11272
	public bool Tarp;

	// Token: 0x04002C09 RID: 11273
	public int CarryAnimID;

	// Token: 0x04002C0A RID: 11274
	public int Strength;

	// Token: 0x04002C0B RID: 11275
	public int Period;

	// Token: 0x04002C0C RID: 11276
	public int Food;

	// Token: 0x04002C0D RID: 11277
	public float KinematicTimer;

	// Token: 0x04002C0E RID: 11278
	public float DumpTimer;

	// Token: 0x04002C0F RID: 11279
	public bool Empty = true;

	// Token: 0x04002C10 RID: 11280
	public GameObject[] FoodPieces;

	// Token: 0x04002C11 RID: 11281
	public WeaponScript StuckBoxCutter;

	// Token: 0x04002C12 RID: 11282
	public GameObject TarpObject;

	// Token: 0x04002C13 RID: 11283
	public AudioClip PickUpSound;

	// Token: 0x04002C14 RID: 11284
	public AudioSource MyAudio;

	// Token: 0x04002C15 RID: 11285
	public Texture EightiesTexture;
}
