// Decompiled with JetBrains decompiler
// Type: PickUpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    this.Yandere = this.Prompt.Yandere;
    if ((Object) this.Yandere == (Object) null)
      this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    this.Clock = this.Yandere.StudentManager.Clock;
    if (!this.CanCollide)
      Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
    if (this.Outline.Length != 0)
      this.OriginalColor = this.Outline[0].color;
    this.OriginalScale = this.transform.localScale;
    if ((Object) this.MyRigidbody == (Object) null)
      this.MyRigidbody = this.GetComponent<Rigidbody>();
    this.Gloves = this.GetComponent<GloveScript>();
    if (this.DisableAtStart)
      this.gameObject.SetActive(false);
    if (GameGlobals.Eighties && (Object) this.EightiesMesh != (Object) null)
    {
      this.GetComponent<MeshFilter>().mesh = this.EightiesMesh;
      if (!this.Sign)
        this.GetComponent<Renderer>().material.mainTexture = this.EightiesTexture;
      else
        this.GetComponent<Renderer>().materials[1].mainTexture = this.EightiesTexture;
      if (this.Radio)
      {
        this.GetComponent<RadioScript>().OffTexture = this.EightiesTexture;
        this.GetComponent<RadioScript>().OnTexture = this.EightiesTexture;
      }
    }
    this.Yandere.StudentManager.AllPickUps[this.Yandere.StudentManager.PickUpID] = this;
    ++this.Yandere.StudentManager.PickUpID;
    if (!this.Clothing && (Object) this.BodyPart == (Object) null)
    {
      this.OriginalPosition = this.transform.position;
      this.OriginalRotation = this.transform.eulerAngles;
    }
    if (!this.InstantiatedObject)
      return;
    this.Yandere.StudentManager.SpawnedObjectManager.SpawnedObjectList[this.Yandere.StudentManager.SpawnedObjectManager.ObjectsSpawned] = this.ObjectType;
    this.Yandere.StudentManager.SpawnedObjectManager.SpawnedTransforms[this.Yandere.StudentManager.SpawnedObjectManager.ObjectsSpawned] = this.transform;
    ++this.Yandere.StudentManager.SpawnedObjectManager.ObjectsSpawned;
  }

  private void LateUpdate()
  {
    if (this.CleaningProduct)
    {
      if ((Object) this.Clock == (Object) null)
        this.Clock = this.Yandere.StudentManager.Clock;
      this.Suspicious = this.Clock.Period != 5;
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
        this.Prompt.Label[3].text = "     Carry";
    }
    if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
    {
      this.Prompt.Circle[3].fillAmount = 1f;
      if (this.Weight)
      {
        if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
        {
          if ((Object) this.Yandere.PickUp != (Object) null)
            this.Yandere.CharacterAnimation[this.Yandere.CarryAnims[this.Yandere.PickUp.CarryAnimID]].weight = 0.0f;
          if (this.Yandere.Armed)
            this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[this.Yandere.EquippedWeapon.AnimID]].weight = 0.0f;
          this.Yandere.targetRotation = Quaternion.LookRotation(new Vector3(this.transform.position.x, this.Yandere.transform.position.y, this.transform.position.z) - this.Yandere.transform.position);
          this.Yandere.transform.rotation = this.Yandere.targetRotation;
          this.Yandere.EmptyHands();
          this.transform.parent = this.Yandere.transform;
          this.transform.localPosition = new Vector3(0.0f, 0.0f, 0.79184f);
          this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
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
        this.BePickedUp();
    }
    if ((Object) this.Yandere.PickUp == (Object) this)
    {
      this.transform.localPosition = this.HoldPosition;
      this.transform.localEulerAngles = this.HoldRotation;
    }
    if (this.Dumped)
    {
      this.DumpTimer += Time.deltaTime;
      if ((double) this.DumpTimer > 1.0)
      {
        if (this.Clothing)
        {
          ++this.Yandere.Incinerator.BloodyClothing;
          if (this.RedPaint)
            ++this.Yandere.Incinerator.ClothingWithRedPaint;
        }
        else if ((bool) (Object) this.BodyPart)
          ++this.Yandere.Incinerator.BodyParts;
        Object.Destroy((Object) this.gameObject);
      }
    }
    if ((Object) this.Yandere.PickUp != (Object) this && !this.MyRigidbody.isKinematic)
    {
      if (!this.KeepGravity)
        this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
      if ((double) this.KinematicTimer == 5.0)
      {
        this.MyRigidbody.isKinematic = true;
        this.KinematicTimer = 0.0f;
      }
      if ((double) this.transform.position.x > -71.0 && (double) this.transform.position.x < -61.0 && (double) this.transform.position.z > -37.5 && (double) this.transform.position.z < -27.5)
      {
        this.Yandere.NotificationManager.CustomText = "You can't drop that there!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.transform.position = new Vector3(-63f, 1f, -26.5f);
        this.KinematicTimer = 0.0f;
      }
      if ((double) this.transform.position.x > -46.0 && (double) this.transform.position.x < -18.0 && (double) this.transform.position.z > 66.0 && (double) this.transform.position.z < 78.0)
      {
        this.transform.position = new Vector3(-16f, 5f, 72f);
        this.KinematicTimer = 0.0f;
      }
    }
    if (this.Weight && this.BeingLifted)
    {
      if (this.Yandere.Lifting)
      {
        if (this.Yandere.StudentManager.Stop)
          this.Drop();
      }
      else
        this.BePickedUp();
    }
    if (this.Remote)
    {
      if (this.Prompt.Carried)
      {
        this.Prompt.HideButton[0] = false;
        this.Prompt.HideButton[3] = true;
        if ((Object) this.ExplosiveDevice != (Object) null)
        {
          if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
          {
            this.Prompt.Circle[0].fillAmount = 1f;
            if (!this.ExplosiveDevice.gameObject.activeInHierarchy)
            {
              this.Yandere.NotificationManager.CustomText = "Not while inside the bag!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            else if ((double) Vector3.Distance(this.Yandere.Senpai.position, this.ExplosiveDevice.position) < 4.0)
            {
              this.Yandere.NotificationManager.CustomText = "I'd never hurt Senpai!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            else if ((double) Vector3.Distance(this.Yandere.transform.position, this.ExplosiveDevice.position) < 4.0)
            {
              this.Yandere.NotificationManager.CustomText = "I'm too close!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            else if ((double) Vector3.Distance(this.Yandere.StudentManager.Headmaster.transform.position, this.ExplosiveDevice.position) < 4.0 || (double) Vector3.Distance(this.Yandere.StudentManager.Journalist.transform.position, this.ExplosiveDevice.position) < 4.0)
            {
              this.Yandere.NotificationManager.CustomText = "Something is jamming the signal?!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            else
            {
              this.Yandere.StudentManager.Police.EndOfDay.ExplosiveDeviceUsed = true;
              Object.Instantiate<GameObject>(this.Explosion, this.ExplosiveDevice.position, Quaternion.identity);
              Object.Destroy((Object) this.ExplosiveDevice.gameObject);
              this.Drop();
              this.Prompt.Hide();
              Object.Destroy((Object) this.gameObject);
            }
          }
        }
        else if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
        {
          this.Prompt.Circle[0].fillAmount = 1f;
          if (!this.MyRadio.On)
            this.MyRadio.TurnOn();
          else
            this.MyRadio.TurnOff();
        }
      }
      else
        this.Prompt.HideButton[0] = true;
    }
    else if (this.Usable && (Object) this.Bucket == (Object) null && (Object) this.Mop == (Object) null && !this.StinkBombs && !this.BangSnaps && !this.SmokeBomb)
    {
      if (this.Prompt.Carried)
      {
        this.Prompt.HideButton[0] = false;
        this.Prompt.HideButton[3] = true;
        if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
        {
          this.Prompt.Circle[0].fillAmount = 1f;
          this.DoNotTeleport = true;
          this.Drop();
          this.DoNotTeleport = false;
          this.MyRigidbody.AddForce((this.Prompt.Yandere.transform.forward + this.Prompt.Yandere.transform.up) * 100f);
          this.Prompt.HideButton[3] = false;
          if (!this.Prompt.Yandere.Invisible)
            this.Prompt.Yandere.PotentiallyMurderousTimer = 1f;
        }
      }
      else
        this.Prompt.HideButton[0] = true;
    }
    else if ((Object) this.Flame != (Object) null)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Flame.SetActive(!this.Flame.activeInHierarchy);
      }
    }
    else if (this.SmokeBomb)
    {
      if (this.Prompt.Carried)
      {
        this.Prompt.HideButton[0] = false;
        this.Prompt.HideButton[3] = true;
      }
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        Object.Instantiate<GameObject>(this.SmokeCloud, this.Yandere.transform.position, Quaternion.identity);
        this.Drop();
        Object.Destroy((Object) this.gameObject);
      }
    }
    if (!((Object) this.Flame != (Object) null) || !this.Flame.activeInHierarchy || (double) Time.timeScale <= 0.10000000149011612)
      return;
    this.Flame.transform.localScale = new Vector3(Random.Range(17.5f, 22.5f), Random.Range(17.5f, 22.5f), Random.Range(17.5f, 22.5f));
  }

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
    if ((Object) this.MyAnimation != (Object) null)
      this.MyAnimation.Stop();
    this.Prompt.Circle[3].fillAmount = 1f;
    this.BeingLifted = false;
    if ((Object) this.Yandere.PickUp != (Object) null)
      this.Yandere.PickUp.Drop();
    if (this.Yandere.Equipped == 3)
      this.Yandere.Weapon[3].Drop();
    else if (this.Yandere.Equipped > 0)
      this.Yandere.Unequip();
    if (this.Yandere.Dragging)
      this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
    if (this.Yandere.Carrying)
      this.Yandere.StopCarrying();
    if (!this.LeftHand)
      this.transform.parent = this.Yandere.ItemParent;
    else
      this.transform.parent = this.Yandere.LeftItemParent;
    if ((Object) this.GetComponent<RadioScript>() != (Object) null && this.GetComponent<RadioScript>().On)
      this.GetComponent<RadioScript>().TurnOff();
    this.MyCollider.enabled = false;
    if ((Object) this.MyRigidbody != (Object) null)
      this.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    if ((Object) this.Bucket != (Object) null)
    {
      this.Prompt.Label[0].text = "     Spill";
      this.Prompt.OffsetY[0] = 0.125f;
      if (this.Bucket.Full)
      {
        this.Prompt.Carried = true;
        this.Usable = true;
      }
      else
        this.Usable = false;
    }
    if (!this.Usable)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Yandere.NearestPrompt = (PromptScript) null;
    }
    else
      this.Prompt.Carried = true;
    if (this.PuzzleCube && !this.Cheated || this.SuperRobot && !this.Cheated)
    {
      ++this.Prompt.Yandere.Alphabet.Cheats;
      this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
      this.Cheated = true;
    }
    this.Yandere.PickUp = this;
    this.Yandere.CarryAnimID = this.CarryAnimID;
    if ((bool) (Object) this.BodyPart)
      ++this.Yandere.NearBodies;
    this.Yandere.StudentManager.UpdateStudents();
    this.MyRigidbody.isKinematic = true;
    this.KinematicTimer = 0.0f;
    if ((Object) this.PickUpSound != (Object) null)
      AudioSource.PlayClipAtPoint(this.PickUpSound, this.transform.position);
    if (this.StinkBombs || this.BangSnaps)
      this.Prompt.Yandere.Arc.SetActive(true);
    this.Yandere.UpdateConcealedItemStatus();
  }

  public void Drop()
  {
    if ((bool) (Object) this.Mop)
      this.Mop.MyAudio.Stop();
    if (!this.Yandere.BucketDropping)
    {
      this.Yandere.Direction = 1;
      this.Yandere.CheckForWall();
    }
    if (this.Yandere.WallInFront)
      this.transform.position = new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z);
    this.Yandere.WallInFront = false;
    if (this.Salty && SchemeGlobals.GetSchemeStage(4) == 5)
    {
      SchemeGlobals.SetSchemeStage(4, 4);
      this.Yandere.PauseScreen.Schemes.UpdateInstructions();
    }
    if ((bool) (Object) this.TrashCan)
      this.Yandere.MyController.radius = 0.2f;
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
    if ((Object) this.BloodCleaner != (Object) null)
    {
      this.BloodCleaner.enabled = true;
      this.BloodCleaner.Pathfinding.enabled = true;
    }
    if ((Object) this.Yandere.PickUp == (Object) this)
      this.Yandere.PickUp = (PickUpScript) null;
    if ((bool) (Object) this.BodyPart)
    {
      if (this.ConcealedBodyPart)
        this.transform.parent = this.Yandere.Police.GarbageParent;
      else
        this.transform.parent = this.Yandere.LimbParent;
    }
    else
      this.transform.parent = (Transform) null;
    if (this.LockRotation)
      this.transform.localEulerAngles = new Vector3(0.0f, this.transform.localEulerAngles.y, 0.0f);
    if ((Object) this.MyRigidbody != (Object) null)
    {
      this.MyRigidbody.constraints = this.OriginalConstraints;
      if (this.PreventTipping)
        this.MyRigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
      this.MyRigidbody.isKinematic = false;
      this.MyRigidbody.useGravity = true;
    }
    if (this.Dumped)
    {
      this.transform.position = this.Incinerator.DumpPoint.position;
      this.MyCollider.enabled = false;
    }
    else
    {
      this.Prompt.enabled = true;
      this.MyCollider.enabled = true;
      this.MyCollider.isTrigger = false;
      if (!this.CanCollide)
        Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
    }
    this.Prompt.Carried = false;
    if (this.Remote || this.Usable)
      this.Prompt.HideButton[3] = false;
    this.transform.localScale = this.OriginalScale;
    if ((bool) (Object) this.BodyPart)
      --this.Yandere.NearBodies;
    this.Yandere.StudentManager.UpdateStudents();
    if (this.Sign)
    {
      if (this.Clock.Period < 3 && this.PoolClosureCollider.bounds.Contains(this.transform.position))
      {
        Debug.Log((object) "Attempting to make students avoid the pool...");
        this.Yandere.NotificationManager.CustomText = "Students will now avoid the pool";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.transform.position = this.PoolClosureCollider.transform.position;
        this.transform.eulerAngles = this.PoolClosureCollider.transform.eulerAngles;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.MyCollider.isTrigger = false;
        this.MyRigidbody.useGravity = false;
        this.MyRigidbody.isKinematic = true;
        this.enabled = false;
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
        this.transform.eulerAngles = new Vector3(90f, 0.0f, 0.0f);
      }
    }
    if (this.StinkBombs || this.BangSnaps || this.SmokeBomb)
    {
      this.Prompt.Yandere.Arc.SetActive(false);
      this.Prompt.HideButton[3] = false;
      this.Prompt.HideButton[0] = true;
    }
    if ((Object) this.Bucket != (Object) null)
    {
      this.Prompt.HideButton[0] = true;
      this.Prompt.HideButton[3] = false;
      this.Prompt.OffsetY[0] = 0.5f;
    }
    if (!this.DoNotTeleport && ((double) Vector3.Distance(this.transform.position, this.OriginalPosition) < 1.0 || (double) Vector3.Distance(this.Yandere.transform.position, this.OriginalPosition) < 1.0))
    {
      this.transform.position = this.OriginalPosition;
      this.transform.eulerAngles = this.OriginalRotation;
      this.MyRigidbody.isKinematic = true;
      this.MyRigidbody.useGravity = false;
      this.MyCollider.isTrigger = true;
    }
    this.DoNotTeleport = false;
  }

  public void DisableGarbageBag()
  {
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.MyCollider.enabled = false;
    this.MyRigidbody.useGravity = false;
    this.MyRigidbody.isKinematic = true;
    this.enabled = false;
  }

  public void UpdateFood()
  {
    int index = 0;
    while (index < this.Food)
    {
      ++index;
      this.FoodPieces[index].SetActive(true);
    }
  }
}
