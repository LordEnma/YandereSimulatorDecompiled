// Decompiled with JetBrains decompiler
// Type: RagdollScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RagdollScript : MonoBehaviour
{
  public BloodPoolSpawnerScript BloodPoolSpawner;
  public DetectionMarkerScript DetectionMarker;
  public IncineratorScript Incinerator;
  public WoodChipperScript WoodChipper;
  public TranqCaseScript TranqCase;
  public StudentScript Student;
  public YandereScript Yandere;
  public PoliceScript Police;
  public PromptScript Prompt;
  public SkinnedMeshRenderer MyRenderer;
  public Collider BloodSpawnerCollider;
  public Animation CharacterAnimation;
  public Collider HideCollider;
  public Rigidbody[] AllRigidbodies;
  public Collider[] AllColliders;
  public Rigidbody[] Rigidbodies;
  public Transform[] SpawnPoints;
  public GameObject[] BodyParts;
  public Transform NearestLimb;
  public Transform RightBreast;
  public Transform LeftBreast;
  public Transform PelvisRoot;
  public Transform Ponytail;
  public Transform RightEye;
  public Transform LeftEye;
  public Transform HairR;
  public Transform HairL;
  public Transform[] Limb;
  public Transform Head;
  public Vector3 RightEyeOrigin;
  public Vector3 LeftEyeOrigin;
  public Vector3[] LimbAnchor;
  public GameObject Character;
  public GameObject TarpBag;
  public GameObject MyTarp;
  public GameObject Zs;
  public bool ElectrocutionAnimation;
  public bool MurderSuicideAnimation;
  public bool BurningAnimation;
  public bool ChokingAnimation;
  public bool RigidbodiesManuallyDisabled;
  public bool TeleportNextFrame;
  public bool ColoredOutline;
  public bool AddingToCount;
  public bool MurderSuicide;
  public bool AddedOutline;
  public bool Cauterizable;
  public bool Electrocuted;
  public bool StruckGround;
  public bool StopAnimation = true;
  public bool Decapitated;
  public bool Dismembered;
  public bool NeckSnapped;
  public bool Cauterized;
  public bool Disturbing;
  public bool Concealed;
  public bool Sacrifice;
  public bool Wrappable;
  public bool Disposed;
  public bool Poisoned;
  public bool Tranquil;
  public bool Tutorial;
  public bool Burning;
  public bool Carried;
  public bool Choking;
  public bool Dragged;
  public bool Drowned;
  public bool Falling;
  public bool Nemesis;
  public bool Settled;
  public bool Suicide;
  public bool Burned;
  public bool Dumped;
  public bool Hidden;
  public bool Pushed;
  public bool Male;
  public float AnimStartTime;
  public float SettleTimer;
  public float BreastSize;
  public float DumpTimer;
  public float EyeShrink;
  public float FallTimer;
  public int StudentID;
  public RagdollDumpType DumpType;
  public int LimbID;
  public int Frame;
  public string DumpedAnim = string.Empty;
  public string LiftAnim = string.Empty;
  public string IdleAnim = string.Empty;
  public string WalkAnim = string.Empty;
  public string RunAnim = string.Empty;
  public bool UpdateNextFrame;
  public Vector3 NextPosition;
  public Quaternion NextRotation;
  public int Frames;

  private void Start()
  {
    this.ElectrocutionAnimation = false;
    this.MurderSuicideAnimation = false;
    this.BurningAnimation = false;
    this.ChokingAnimation = false;
    this.Disturbing = false;
    this.Yandere = this.Student.StudentManager.Yandere;
    Physics.IgnoreLayerCollision(11, 13, true);
    this.Zs.SetActive(this.Tranquil);
    if (!this.Tranquil && !this.Poisoned && !this.Drowned && !this.Electrocuted && !this.Burning && !this.NeckSnapped)
    {
      this.Student.StudentManager.TutorialWindow.ShowPoolMessage = true;
      this.BloodPoolSpawner.gameObject.SetActive(true);
      this.BloodPoolSpawner.StudentManager = this.Student.StudentManager;
      if (this.Pushed)
        this.BloodPoolSpawner.Timer = 5f;
    }
    if (!this.RigidbodiesManuallyDisabled)
    {
      for (int index = 0; index < this.AllRigidbodies.Length; ++index)
      {
        this.AllRigidbodies[index].isKinematic = false;
        this.AllColliders[index].enabled = true;
        if ((Object) this.Yandere != (Object) null && this.Yandere.StudentManager.NoGravity)
          this.AllRigidbodies[index].useGravity = false;
      }
    }
    else
      this.AllColliders[0].enabled = true;
    this.Student.Prompt.enabled = false;
    this.Student.Prompt.Hide();
    this.Prompt.enabled = true;
    if (!this.Tranquil)
      this.Prompt.HideButton[3] = false;
    if (this.Tutorial)
    {
      this.Prompt.HideButton[1] = true;
      this.Prompt.HideButton[3] = true;
    }
    if ((Object) this.Yandere != (Object) null && this.Yandere.BlackHole)
      this.DestroyRigidbodies();
    if (!this.Concealed)
      return;
    this.ConcealInTrashBag();
  }

  private void Update()
  {
    if (this.UpdateNextFrame)
    {
      this.Student.Hips.localPosition = this.NextPosition;
      this.Student.Hips.localRotation = this.NextRotation;
      Physics.SyncTransforms();
      this.UpdateNextFrame = false;
    }
    if (!this.Dragged && !this.Carried && !this.Settled && !this.Yandere.PK && !this.Yandere.StudentManager.NoGravity)
    {
      this.SettleTimer += Time.deltaTime;
      if ((double) this.SettleTimer > 5.0)
      {
        this.Settled = true;
        for (int index = 0; index < this.AllRigidbodies.Length; ++index)
        {
          this.AllRigidbodies[index].isKinematic = true;
          this.AllColliders[index].enabled = false;
        }
      }
    }
    if ((Object) this.DetectionMarker != (Object) null)
    {
      if ((double) this.DetectionMarker.Tex.color.a > 0.10000000149011612)
      {
        this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, Mathf.MoveTowards(this.DetectionMarker.Tex.color.a, 0.0f, Time.deltaTime * 10f));
      }
      else
      {
        this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0.0f);
        this.DetectionMarker = (DetectionMarkerScript) null;
      }
    }
    if ((Object) this.Yandere != (Object) null)
    {
      if (!this.Dumped)
      {
        if (this.StopAnimation)
        {
          if (this.Student.CharacterAnimation.isPlaying)
          {
            this.Student.CharacterAnimation.Stop();
          }
          else
          {
            if (this.TeleportNextFrame)
            {
              this.Student.transform.position = new Vector3(-28.78f, 4f, 10.386f);
              this.TeleportNextFrame = false;
            }
            if (this.Student.DeathType == DeathType.Weight && this.RigidbodiesManuallyDisabled)
            {
              Debug.Log((object) "Forcing the ''crushed'' animation to play.");
              if (!this.Student.Male)
                this.Student.CharacterAnimation.Play("f02_crushed_00");
              else
                this.Student.CharacterAnimation.Play("crushed_00");
              this.TeleportNextFrame = true;
            }
          }
        }
        if ((Object) this.Yandere.PickUp != (Object) null)
        {
          if (this.Yandere.PickUp.GarbageBagBox)
          {
            if (!this.Concealed)
            {
              this.Prompt.Label[0].text = "     Conceal";
              this.Cauterizable = false;
              this.Wrappable = true;
            }
          }
          else if (this.Yandere.PickUp.Tarp)
            this.Prompt.Label[0].text = "     Place Tarp";
          else if (this.Yandere.PickUp.Blowtorch)
          {
            if (this.Concealed)
              this.Prompt.HideButton[0] = true;
            else if (this.BloodPoolSpawner.enabled)
            {
              this.Prompt.Label[0].text = "     Cauterize";
              this.Cauterizable = true;
              this.Wrappable = false;
            }
          }
          else
          {
            this.Prompt.Label[0].text = "     Dismember";
            this.Cauterizable = false;
            this.Wrappable = false;
          }
        }
        else if (this.Cauterizable)
        {
          this.Prompt.Label[0].text = "     Dismember";
          this.Cauterizable = false;
          this.Wrappable = false;
        }
        if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
        {
          this.Prompt.Circle[0].fillAmount = 1f;
          if ((Object) this.Yandere.PickUp != (Object) null && this.Yandere.PickUp.Tarp)
          {
            GameObject gameObject = this.Yandere.PickUp.gameObject;
            this.MyTarp = Object.Instantiate<GameObject>(this.Yandere.PickUp.TarpObject, new Vector3(this.Student.Hips.position.x, this.Yandere.transform.position.y, this.Student.Hips.position.z), this.Yandere.transform.rotation);
            this.Yandere.EmptyHands();
            Object.Destroy((Object) gameObject);
          }
          else if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
          {
            if (this.Wrappable)
              this.ConcealInTrashBag();
            else if (this.Cauterizable)
            {
              this.Prompt.Label[0].text = "     Dismember";
              this.BloodPoolSpawner.enabled = false;
              this.Cauterizable = false;
              this.Cauterized = true;
              this.Yandere.CharacterAnimation.CrossFade("f02_cauterize_00");
              this.Yandere.Cauterizing = true;
              this.Yandere.CanMove = false;
              this.Yandere.PickUp.GetComponent<BlowtorchScript>().enabled = true;
              this.Yandere.PickUp.GetComponent<AudioSource>().Play();
            }
            else if (this.Yandere.StudentManager.OriginalUniforms + this.Yandere.StudentManager.NewUniforms > 0)
            {
              this.Yandere.CharacterAnimation.CrossFade("f02_dismember_00");
              this.Yandere.transform.LookAt(this.transform);
              this.Yandere.RPGCamera.transform.position = this.Yandere.DismemberSpot.position;
              this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DismemberSpot.eulerAngles;
              this.Yandere.EquippedWeapon.Dismember();
              this.Yandere.RPGCamera.enabled = false;
              this.Yandere.TargetStudent = this.Student;
              this.Yandere.Ragdoll = this.gameObject;
              this.Yandere.Dismembering = true;
              this.Yandere.CanMove = false;
            }
            else if (!this.Yandere.ClothingWarning)
            {
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Clothing);
              this.Yandere.StudentManager.TutorialWindow.ShowClothingMessage = true;
              this.Yandere.ClothingWarning = true;
            }
          }
        }
        if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
        {
          this.Prompt.Circle[1].fillAmount = 1f;
          if (!this.Student.FireEmitters[1].isPlaying)
          {
            if (!this.Dragged)
            {
              this.Yandere.EmptyHands();
              this.Prompt.AcceptingInput[1] = false;
              this.Prompt.Label[1].text = "     Drop";
              this.PickNearestLimb();
              this.Yandere.RagdollDragger.connectedBody = this.Rigidbodies[this.LimbID];
              this.Yandere.RagdollDragger.connectedAnchor = this.LimbAnchor[this.LimbID];
              this.Yandere.Dragging = true;
              this.Yandere.Running = false;
              this.Yandere.DragState = 0;
              this.Yandere.Ragdoll = this.gameObject;
              this.Yandere.CurrentRagdoll = this;
              this.Dragged = true;
              this.Yandere.StudentManager.UpdateStudents();
              if (this.MurderSuicide)
              {
                this.Police.MurderSuicideScene = false;
                this.MurderSuicide = false;
              }
              if (this.Suicide)
              {
                this.Police.Suicide = false;
                this.Suicide = false;
              }
              for (int index = 0; index < this.Student.Ragdoll.AllRigidbodies.Length; ++index)
                this.Student.Ragdoll.AllRigidbodies[index].drag = 2f;
              for (int index = 0; index < this.AllRigidbodies.Length; ++index)
              {
                this.AllRigidbodies[index].isKinematic = false;
                this.AllColliders[index].enabled = true;
                if (this.Yandere.StudentManager.NoGravity)
                  this.AllRigidbodies[index].useGravity = false;
              }
              this.RigidbodiesManuallyDisabled = false;
            }
            else
              this.StopDragging();
          }
        }
        if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
        {
          this.Prompt.Circle[3].fillAmount = 1f;
          if (!this.Student.FireEmitters[1].isPlaying)
          {
            this.Yandere.EmptyHands();
            this.Prompt.Label[1].text = "     Drop";
            this.Prompt.HideButton[1] = true;
            this.Prompt.HideButton[3] = true;
            this.Prompt.enabled = false;
            this.Prompt.Hide();
            for (int index = 0; index < this.AllRigidbodies.Length; ++index)
            {
              this.AllRigidbodies[index].isKinematic = true;
              this.AllColliders[index].enabled = false;
            }
            if (this.Male)
            {
              Rigidbody allRigidbody = this.AllRigidbodies[0];
              allRigidbody.transform.parent.transform.localPosition = new Vector3(allRigidbody.transform.parent.transform.localPosition.x, 0.2f, allRigidbody.transform.parent.transform.localPosition.z);
            }
            this.Yandere.CharacterAnimation["f02_carryLiftA_00"].speed = (float) (1.0 + (double) (this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus) * 0.20000000298023224);
            this.Student.CharacterAnimation[this.LiftAnim].speed = (float) (1.0 + (double) (this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus) * 0.20000000298023224);
            this.Yandere.CharacterAnimation.Play("f02_carryLiftA_00");
            this.Student.CharacterAnimation.enabled = true;
            this.Student.CharacterAnimation.Play(this.LiftAnim);
            this.BloodSpawnerCollider.enabled = false;
            this.PelvisRoot.localEulerAngles = new Vector3(this.PelvisRoot.localEulerAngles.x, 0.0f, this.PelvisRoot.localEulerAngles.z);
            this.Prompt.MyCollider.enabled = false;
            this.PelvisRoot.localPosition = new Vector3(this.PelvisRoot.localPosition.x, this.PelvisRoot.localPosition.y, 0.0f);
            this.Yandere.Ragdoll = this.gameObject;
            this.Yandere.CurrentRagdoll = this;
            this.Yandere.CanMove = false;
            this.Yandere.Lifting = true;
            this.StopAnimation = false;
            this.Carried = true;
            this.Falling = false;
            this.FallTimer = 0.0f;
            this.RigidbodiesManuallyDisabled = false;
            this.TeleportNextFrame = false;
          }
        }
        if (this.Yandere.Running && this.Yandere.CanMove && this.Dragged)
          this.StopDragging();
        if ((double) Vector3.Distance(this.Yandere.transform.position, this.Prompt.transform.position) < 2.0)
        {
          if (!this.Suicide && !this.Concealed && !this.AddingToCount)
          {
            this.Yandere.NearestCorpseID = this.StudentID;
            ++this.Yandere.NearBodies;
            this.AddingToCount = true;
          }
        }
        else if (this.AddingToCount)
        {
          --this.Yandere.NearBodies;
          this.AddingToCount = false;
        }
        if (!this.Prompt.AcceptingInput[1] && Input.GetButtonUp("B"))
          this.Prompt.AcceptingInput[1] = true;
        bool flag = false;
        if (this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 7 && !this.Student.Nemesis)
        {
          this.Prompt.Label[0].text = "     Dismember";
          this.Cauterizable = false;
          this.Wrappable = false;
          flag = true;
        }
        if ((Object) this.Yandere.PickUp != (Object) null && this.Yandere.PickUp.Blowtorch && !this.Cauterized || (Object) this.Yandere.PickUp != (Object) null && this.Yandere.PickUp.Tarp || (Object) this.Yandere.PickUp != (Object) null && this.Yandere.PickUp.GarbageBagBox && !this.Concealed)
          flag = true;
        this.Prompt.HideButton[0] = this.Dragged || this.Carried || this.Tranquil || this.Concealed || !flag;
      }
      else if (this.DumpType == RagdollDumpType.Incinerator)
      {
        if ((double) this.DumpTimer == 0.0 && this.Yandere.Carrying)
          this.Student.CharacterAnimation[this.DumpedAnim].time = 2.5f;
        this.Student.CharacterAnimation.CrossFade(this.DumpedAnim);
        this.DumpTimer += Time.deltaTime;
        if ((double) this.Student.CharacterAnimation[this.DumpedAnim].time >= (double) this.Student.CharacterAnimation[this.DumpedAnim].length)
        {
          if (this.Concealed)
            ++this.Incinerator.HiddenCorpses;
          ++this.Incinerator.Corpses;
          this.Incinerator.CorpseList[this.Incinerator.Corpses] = this.StudentID;
          this.Remove();
          this.enabled = false;
        }
      }
      else if (this.DumpType == RagdollDumpType.TranqCase)
      {
        if ((double) this.DumpTimer == 0.0 && this.Yandere.Carrying)
          this.Student.CharacterAnimation[this.DumpedAnim].time = 2.5f;
        this.Student.CharacterAnimation.CrossFade(this.DumpedAnim);
        this.DumpTimer += Time.deltaTime;
        if ((double) this.Student.CharacterAnimation[this.DumpedAnim].time >= (double) this.Student.CharacterAnimation[this.DumpedAnim].length)
        {
          this.Student.Cosmetic.FemaleHair[this.Student.Cosmetic.Hairstyle].SetActive(false);
          this.TranqCase.Open = false;
          if (this.AddingToCount)
            --this.Yandere.NearBodies;
          this.enabled = false;
        }
      }
      else if (this.DumpType == RagdollDumpType.WoodChipper)
      {
        if ((double) this.DumpTimer == 0.0 && this.Yandere.Carrying)
          this.Student.CharacterAnimation[this.DumpedAnim].time = 2.5f;
        this.Student.CharacterAnimation.CrossFade(this.DumpedAnim);
        this.DumpTimer += Time.deltaTime;
        if ((double) this.Student.CharacterAnimation[this.DumpedAnim].time >= (double) this.Student.CharacterAnimation[this.DumpedAnim].length)
        {
          this.WoodChipper = this.Yandere.WoodChipper;
          Debug.Log((object) ("Student #" + this.StudentID.ToString() + " is now updating " + this.WoodChipper.gameObject.name + " with an ID number."));
          if (this.Concealed)
            ++this.WoodChipper.HiddenCorpses;
          this.WoodChipper.VictimID = this.StudentID;
          this.Remove();
          this.enabled = false;
        }
      }
    }
    if (this.Hidden && (Object) this.HideCollider == (Object) null)
    {
      if (!this.Concealed)
        --this.Police.HiddenCorpses;
      this.Hidden = false;
    }
    if (this.Falling)
    {
      this.FallTimer += Time.deltaTime;
      if ((double) this.FallTimer > 2.0)
      {
        this.BloodSpawnerCollider.enabled = true;
        this.FallTimer = 0.0f;
        this.Falling = false;
      }
    }
    if (this.Pushed && !this.StruckGround && !this.Hidden && (double) this.SettleTimer > 1.5)
    {
      Debug.Log((object) "A student who was shoved from the school rooftop just hit the ground.");
      Object.Instantiate<GameObject>(this.Student.AlarmDisc, new Vector3(this.Student.Hips.position.x, 1f, this.Student.Hips.position.z), Quaternion.identity).transform.localScale = new Vector3(1000f, 1f, 1000f);
      this.StruckGround = true;
    }
    if (this.Burning)
    {
      for (int index = 0; index < 3; ++index)
      {
        Material material = this.MyRenderer.materials[index];
        material.color = (Color) Vector4.MoveTowards((Vector4) material.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
      }
      this.Student.Cosmetic.HairRenderer.material.color = (Color) Vector4.MoveTowards((Vector4) this.Student.Cosmetic.HairRenderer.material.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
      if (this.MyRenderer.materials[0].color == new Color(0.1f, 0.1f, 0.1f, 1f))
      {
        this.Burning = false;
        this.Burned = true;
      }
    }
    if (this.Burned)
      this.Sacrifice = (double) Vector3.Distance(this.Prompt.transform.position, this.Yandere.StudentManager.SacrificeSpot.position) < 1.5;
    if (!this.Concealed || this.AddedOutline || this.ColoredOutline)
      return;
    Debug.Log((object) "We have not yet confirmed that an outline has been added to a garbage bag.");
    if (!this.Student.GarbageBag.activeInHierarchy)
      return;
    Debug.Log((object) "The garbage bag is definitely active...");
    RiggedAccessoryAttacher component = this.Student.GarbageBag.GetComponent<RiggedAccessoryAttacher>();
    if (!((Object) component != (Object) null) || !((Object) component.newRenderer != (Object) null) || !((Object) component.newRenderer.gameObject.GetComponent<OutlineScript>() != (Object) null))
      return;
    Debug.Log((object) "Confirming that the outline is orange and enabled.");
    component.newRenderer.gameObject.GetComponent<OutlineScript>().color = new Color(1f, 0.5f, 0.0f);
    component.newRenderer.gameObject.GetComponent<OutlineScript>().enabled = true;
    this.AddedOutline = true;
    this.ColoredOutline = true;
  }

  private void LateUpdate()
  {
    if (!this.Male)
    {
      if ((Object) this.LeftEye != (Object) null)
      {
        this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
        this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
        this.LeftEye.localScale = new Vector3((float) (1.0 - (double) this.EyeShrink * 0.5), (float) (1.0 - (double) this.EyeShrink * 0.5), this.LeftEye.localScale.z);
        this.RightEye.localScale = new Vector3((float) (1.0 - (double) this.EyeShrink * 0.5), (float) (1.0 - (double) this.EyeShrink * 0.5), this.RightEye.localScale.z);
      }
      if (this.StudentID == 81)
      {
        for (int index = 0; index < 4; ++index)
        {
          Transform transform = this.Student.Skirt[index];
          transform.transform.localScale = new Vector3(transform.transform.localScale.x, 0.6666667f, transform.transform.localScale.z);
        }
      }
    }
    if (this.Decapitated)
      this.Head.localScale = Vector3.zero;
    if (!((Object) this.Yandere != (Object) null) || !((Object) this.Yandere.Ragdoll == (Object) this.gameObject))
      return;
    if ((double) this.Yandere.DumpTimer < 1.0)
    {
      if (this.Yandere.Lifting)
      {
        this.transform.position = this.Yandere.transform.position;
        this.transform.eulerAngles = this.Yandere.transform.eulerAngles;
      }
      else if (this.Carried)
      {
        this.transform.position = this.Yandere.transform.position;
        this.transform.eulerAngles = this.Yandere.transform.eulerAngles;
        double axis1 = (double) Input.GetAxis("Vertical");
        float axis2 = Input.GetAxis("Horizontal");
        if (axis1 != 0.0 || (double) axis2 != 0.0)
          this.Student.CharacterAnimation.CrossFade(this.Yandere.Running ? this.RunAnim : this.WalkAnim);
        else
          this.Student.CharacterAnimation.CrossFade(this.IdleAnim);
        this.Student.CharacterAnimation[this.IdleAnim].time = this.Yandere.CharacterAnimation["f02_carryIdleA_00"].time;
        this.Student.CharacterAnimation[this.WalkAnim].time = this.Yandere.CharacterAnimation["f02_carryWalkA_00"].time;
        this.Student.CharacterAnimation[this.RunAnim].time = this.Yandere.CharacterAnimation["f02_carryRunA_00"].time;
      }
    }
    if (!this.Carried)
      return;
    if (this.Male)
    {
      Rigidbody allRigidbody = this.AllRigidbodies[0];
      allRigidbody.transform.parent.transform.localPosition = new Vector3(allRigidbody.transform.parent.transform.localPosition.x, 0.2f, allRigidbody.transform.parent.transform.localPosition.z);
    }
    if (!this.Yandere.Struggling && !this.Yandere.DelinquentFighting && !this.Yandere.Sprayed && !this.Yandere.Noticed)
      return;
    this.Fall();
  }

  public void StopDragging()
  {
    this.Student.Prompt.enabled = false;
    this.Student.Prompt.Hide();
    foreach (Rigidbody allRigidbody in this.Student.Ragdoll.AllRigidbodies)
      allRigidbody.drag = 0.0f;
    if (!this.Tranquil)
      this.Prompt.HideButton[3] = false;
    this.Prompt.AcceptingInput[1] = true;
    this.Prompt.Circle[1].fillAmount = 1f;
    this.Prompt.Label[1].text = "     Drag";
    this.Yandere.RagdollDragger.connectedBody = (Rigidbody) null;
    this.Yandere.RagdollPK.connectedBody = (Rigidbody) null;
    this.Yandere.Dragging = false;
    this.Yandere.Ragdoll = (GameObject) null;
    this.Yandere.StudentManager.UpdateStudents();
    this.SettleTimer = 0.0f;
    this.Settled = false;
    this.Dragged = false;
  }

  private void PickNearestLimb()
  {
    if (this.Concealed)
    {
      this.LimbID = 3;
    }
    else
    {
      this.NearestLimb = this.Limb[0];
      this.LimbID = 0;
      for (int index = 1; index < 4; ++index)
      {
        Transform transform = this.Limb[index];
        if ((double) Vector3.Distance(transform.position, this.Yandere.transform.position) < (double) Vector3.Distance(this.NearestLimb.position, this.Yandere.transform.position))
        {
          this.NearestLimb = transform;
          this.LimbID = index;
        }
      }
    }
  }

  public void Dump()
  {
    if (this.DumpType == RagdollDumpType.Incinerator)
    {
      this.transform.eulerAngles = this.Yandere.transform.eulerAngles;
      this.transform.position = this.Yandere.transform.position;
      this.Incinerator = this.Yandere.Incinerator;
      this.BloodPoolSpawner.enabled = false;
    }
    else if (this.DumpType == RagdollDumpType.TranqCase)
      this.TranqCase = this.Yandere.TranqCase;
    else if (this.DumpType == RagdollDumpType.WoodChipper)
      this.WoodChipper = this.Yandere.WoodChipper;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Dumped = true;
    foreach (Rigidbody allRigidbody in this.AllRigidbodies)
      allRigidbody.isKinematic = true;
  }

  public void Fall()
  {
    this.Student.Prompt.enabled = false;
    this.Student.Prompt.Hide();
    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.0001f, this.transform.position.z);
    this.Prompt.Label[1].text = "     Drag";
    this.Prompt.HideButton[1] = false;
    this.Prompt.enabled = true;
    if (!this.Tranquil)
      this.Prompt.HideButton[3] = false;
    if (this.Dragged)
    {
      this.Yandere.RagdollDragger.connectedBody = (Rigidbody) null;
      this.Yandere.RagdollPK.connectedBody = (Rigidbody) null;
      this.Yandere.Dragging = false;
      this.Dragged = false;
    }
    this.Yandere.Ragdoll = (GameObject) null;
    this.Prompt.MyCollider.enabled = true;
    this.BloodPoolSpawner.NearbyBlood = 0;
    this.StopAnimation = true;
    this.SettleTimer = 0.0f;
    this.Carried = false;
    this.Settled = false;
    this.Falling = true;
    for (int index = 0; index < this.AllRigidbodies.Length; ++index)
    {
      this.AllRigidbodies[index].isKinematic = false;
      this.AllColliders[index].enabled = true;
    }
    if (!((Object) this.Student.Cosmetic.BurlapSack != (Object) null) || !((Object) this.Student.Cosmetic.BurlapSack.newRenderer != (Object) null))
      return;
    this.Student.Cosmetic.BurlapSack.newRenderer.updateWhenOffscreen = true;
  }

  public void QuickDismember()
  {
    Debug.Log((object) "QuickDismember() was called.");
    for (int index = 0; index < this.BodyParts.Length; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.BodyParts[index], this.SpawnPoints[index].position, Quaternion.identity);
      gameObject.transform.eulerAngles = this.SpawnPoints[index].eulerAngles;
      gameObject.GetComponent<PromptScript>().enabled = false;
      gameObject.GetComponent<PickUpScript>().enabled = false;
      gameObject.GetComponent<OutlineScript>().enabled = false;
    }
    if ((Object) this.BloodPoolSpawner.BloodParent == (Object) null)
      this.BloodPoolSpawner.Start();
    Bounds bounds = this.Student.StudentManager.NEStairs.bounds;
    if (!bounds.Contains(this.BloodPoolSpawner.transform.position))
    {
      bounds = this.Student.StudentManager.NWStairs.bounds;
      if (!bounds.Contains(this.BloodPoolSpawner.transform.position))
      {
        bounds = this.Student.StudentManager.SEStairs.bounds;
        if (!bounds.Contains(this.BloodPoolSpawner.transform.position))
        {
          bounds = this.Student.StudentManager.SWStairs.bounds;
          if (!bounds.Contains(this.BloodPoolSpawner.transform.position))
            this.BloodPoolSpawner.SpawnBigPool();
        }
      }
    }
    this.gameObject.SetActive(false);
  }

  public void Dismember()
  {
    Debug.Log((object) "Dismembering a character.");
    if (this.Dismembered)
      return;
    if (!GameGlobals.Debug && !GameGlobals.Debug)
    {
      PlayerPrefs.SetInt("HeadsHunted", PlayerPrefs.GetInt("HeadsHunted") + 1);
      if (PlayerPrefs.GetInt("HeadsHunted") > 9)
      {
        PlayerPrefs.SetInt("HeadHunter", 1);
        PlayerPrefs.SetInt("a", 1);
      }
    }
    this.Student.LiquidProjector.material.mainTexture = this.Student.BloodTexture;
    if ((Object) this.MyTarp == (Object) null)
    {
      for (int index = 0; index < this.BodyParts.Length; ++index)
      {
        if (this.Decapitated)
        {
          ++index;
          this.Decapitated = false;
        }
        GameObject gameObject = Object.Instantiate<GameObject>(this.BodyParts[index], this.SpawnPoints[index].position, Quaternion.identity);
        gameObject.transform.parent = this.Yandere.LimbParent;
        gameObject.transform.eulerAngles = this.SpawnPoints[index].eulerAngles;
        BodyPartScript component = gameObject.GetComponent<BodyPartScript>();
        component.StudentID = this.StudentID;
        component.Sacrifice = this.Sacrifice;
        if (this.Yandere.StudentManager.NoGravity)
          gameObject.GetComponent<Rigidbody>().useGravity = false;
        switch (index)
        {
          case 0:
            if (!this.Student.OriginallyTeacher)
            {
              if (!this.Male)
              {
                this.Student.Cosmetic.FemaleHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
                if ((Object) this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory] != (Object) null && this.Student.Cosmetic.Accessory != 3 && this.Student.Cosmetic.Accessory != 6 && this.Student.Cosmetic.Accessory != 9)
                  this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
              }
              else
              {
                Transform transform = this.Student.Cosmetic.MaleHair[this.Student.Cosmetic.Hairstyle].transform;
                transform.parent = gameObject.transform;
                transform.localScale *= 1.06382978f;
                if ((double) transform.transform.localPosition.y < -1.0)
                  transform.transform.localPosition = new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y - 0.095f, transform.transform.localPosition.z);
                if ((Object) this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory] != (Object) null)
                  this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
              }
            }
            else
            {
              this.Student.Cosmetic.TeacherHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
              if ((Object) this.Student.Cosmetic.TeacherAccessories[this.Student.Cosmetic.Accessory] != (Object) null && this.Student.Cosmetic.Accessory != 7)
                this.Student.Cosmetic.TeacherAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
            }
            if (this.Student.Club != ClubType.Photography && this.Student.Club < ClubType.Gaming && (Object) this.Student.Cosmetic.ClubAccessories[(int) this.Student.Club] != (Object) null)
            {
              this.Student.Cosmetic.ClubAccessories[(int) this.Student.Club].transform.parent = gameObject.transform;
              if (this.Student.Club == ClubType.Occult)
              {
                if (!this.Male)
                {
                  this.Student.Cosmetic.ClubAccessories[(int) this.Student.Club].transform.localPosition = new Vector3(0.0f, -1.5f, 0.01f);
                  this.Student.Cosmetic.ClubAccessories[(int) this.Student.Club].transform.localEulerAngles = Vector3.zero;
                }
                else
                {
                  this.Student.Cosmetic.ClubAccessories[(int) this.Student.Club].transform.localPosition = new Vector3(0.0f, -1.42f, 0.005f);
                  this.Student.Cosmetic.ClubAccessories[(int) this.Student.Club].transform.localEulerAngles = Vector3.zero;
                }
              }
            }
            gameObject.GetComponent<Renderer>().materials[0].mainTexture = this.Student.Cosmetic.FaceTexture;
            gameObject.transform.position += new Vector3(0.0f, 1f, 0.0f);
            Bounds bounds = this.Student.StudentManager.NEStairs.bounds;
            if (!bounds.Contains(this.BloodPoolSpawner.transform.position))
            {
              bounds = this.Student.StudentManager.NWStairs.bounds;
              if (!bounds.Contains(this.BloodPoolSpawner.transform.position))
              {
                bounds = this.Student.StudentManager.SEStairs.bounds;
                if (!bounds.Contains(this.BloodPoolSpawner.transform.position))
                {
                  bounds = this.Student.StudentManager.SWStairs.bounds;
                  if (!bounds.Contains(this.BloodPoolSpawner.transform.position))
                  {
                    this.BloodPoolSpawner.SpawnBigPool();
                    if ((Object) this.BloodPoolSpawner.BloodParent == (Object) null)
                    {
                      this.BloodPoolSpawner.Start();
                      break;
                    }
                    break;
                  }
                  break;
                }
                break;
              }
              break;
            }
            break;
          case 1:
            if (this.Student.Club == ClubType.Photography && (Object) this.Student.Cosmetic.ClubAccessories[(int) this.Student.Club] != (Object) null)
            {
              this.Student.Cosmetic.ClubAccessories[(int) this.Student.Club].transform.parent = gameObject.transform;
              break;
            }
            break;
          case 2:
            if (!this.Student.Male && this.Student.Cosmetic.Accessory == 6)
            {
              this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
              break;
            }
            break;
        }
      }
    }
    else
    {
      for (int index = 0; index < 6; ++index)
      {
        GameObject gameObject = Object.Instantiate<GameObject>(this.TarpBag, this.Student.Hips.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity);
        if (index == 0)
          gameObject.transform.position = this.Student.Hips.position + new Vector3(0.0f, 0.5f, 0.0f);
        else if (index == 1)
          gameObject.transform.position = this.Student.Hips.position + new Vector3(0.5f, 0.5f, 0.0f);
        else if (index == 2)
          gameObject.transform.position = this.Student.Hips.position + new Vector3(-0.5f, 0.5f, 0.0f);
        else if (index == 3)
          gameObject.transform.position = this.Student.Hips.position + new Vector3(0.0f, 0.5f, 0.5f);
        else if (index == 4)
          gameObject.transform.position = this.Student.Hips.position + new Vector3(0.0f, 0.5f, -0.5f);
        else if (index == 5)
          gameObject.transform.position = this.Student.Hips.position + new Vector3(0.5f, 0.5f, 0.5f);
        gameObject.GetComponent<BodyPartScript>().StudentID = this.StudentID;
        gameObject.transform.parent = this.Prompt.Yandere.Police.GarbageParent;
        this.Student.StudentManager.GarbageBagList[this.Student.StudentManager.GarbageBags] = gameObject;
        ++this.Student.StudentManager.GarbageBags;
      }
    }
    if ((Object) this.Police == (Object) null)
      this.Police = this.Yandere.Police;
    this.Police.PartsIcon.gameObject.SetActive(true);
    this.Police.BodyParts += 6;
    --this.Yandere.NearBodies;
    --this.Police.Corpses;
    this.transform.parent = this.Student.StudentManager.DisabledObjectParent;
    this.gameObject.SetActive(false);
    this.Dismembered = true;
    if (!((Object) this.MyTarp != (Object) null))
      return;
    Object.Destroy((Object) this.MyTarp);
  }

  public void Remove()
  {
    Debug.Log((object) ("The Remove() function has been called on " + this.Student.Name + "'s RagdollScript."));
    this.Student.Removed = true;
    this.BloodPoolSpawner.enabled = false;
    if (this.AddingToCount)
      --this.Yandere.NearBodies;
    if (this.Poisoned)
      this.Police.PoisonScene = false;
    this.gameObject.SetActive(false);
  }

  public void DestroyRigidbodies()
  {
    this.BloodPoolSpawner.gameObject.SetActive(false);
    for (int index = 0; index < this.AllRigidbodies.Length; ++index)
    {
      if ((Object) this.AllRigidbodies[index].gameObject.GetComponent<CharacterJoint>() != (Object) null)
        Object.Destroy((Object) this.AllRigidbodies[index].gameObject.GetComponent<CharacterJoint>());
      Object.Destroy((Object) this.AllRigidbodies[index]);
      this.AllColliders[index].enabled = false;
    }
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.enabled = false;
  }

  public void DisableRigidbodies()
  {
    for (int index = 0; index < this.AllRigidbodies.Length; ++index)
    {
      this.AllRigidbodies[index].isKinematic = true;
      this.AllColliders[index].enabled = false;
    }
    this.RigidbodiesManuallyDisabled = true;
    this.StopAnimation = true;
  }

  public void EnableRigidbodies()
  {
    for (int index = 0; index < this.AllRigidbodies.Length; ++index)
    {
      this.AllRigidbodies[index].isKinematic = false;
      this.AllColliders[index].enabled = true;
      this.AllRigidbodies[index].useGravity = !this.Yandere.StudentManager.NoGravity;
    }
    this.RigidbodiesManuallyDisabled = false;
    this.StopAnimation = false;
  }

  public void HideAccessories()
  {
    this.Student.Cosmetic.RightStockings[0].SetActive(false);
    this.Student.Cosmetic.LeftStockings[0].SetActive(false);
    this.Student.Cosmetic.RightWristband.SetActive(false);
    this.Student.Cosmetic.LeftWristband.SetActive(false);
    this.Student.Cosmetic.Bookbag.SetActive(false);
    this.Student.Cosmetic.Hoodie.SetActive(false);
  }

  public void ConcealInTrashBag()
  {
    this.Prompt.Label[0].text = "     Dismember";
    ++this.Student.StudentManager.Police.HiddenCorpses;
    this.Concealed = true;
    this.Wrappable = false;
    if (this.AddingToCount)
    {
      --this.Yandere.NearBodies;
      this.AddingToCount = false;
    }
    this.Student.MyRenderer.enabled = false;
    if ((Object) this.Student.Cosmetic.HairRenderer != (Object) null)
      this.Student.Cosmetic.HairRenderer.gameObject.SetActive(false);
    else if (this.Student.Nemesis)
      this.Student.gameObject.GetComponent<NemesisScript>().NemesisHair.SetActive(false);
    this.Student.GarbageBag.SetActive(true);
    if (!this.Student.Male)
    {
      this.Student.InstrumentBag[1].SetActive(false);
      this.Student.InstrumentBag[2].SetActive(false);
      this.Student.InstrumentBag[3].SetActive(false);
      this.Student.InstrumentBag[4].SetActive(false);
      this.Student.InstrumentBag[5].SetActive(false);
      this.HideAccessories();
    }
    if (this.Student.ApronAttacher.enabled)
      this.Student.ApronAttacher.newRenderer.enabled = false;
    if (this.Student.Attacher.enabled && (Object) this.Student.Attacher.newRenderer != (Object) null)
      this.Student.Attacher.newRenderer.enabled = false;
    if (this.Student.LabcoatAttacher.enabled)
      this.Student.LabcoatAttacher.newRenderer.enabled = false;
    this.Student.Armband.SetActive(false);
    this.BloodPoolSpawner.enabled = false;
    if ((Object) this.Yandere.PickUp != (Object) null)
    {
      this.Yandere.PickUp.GetComponent<AudioSource>().Play();
      this.Yandere.MurderousActionTimer = 1f;
    }
    if ((Object) this.Student.BikiniAttacher != (Object) null && (Object) this.Student.BikiniAttacher.newRenderer != (Object) null)
      this.Student.BikiniAttacher.newRenderer.enabled = false;
    if ((bool) (Object) this.Student.Cosmetic)
      this.Student.Cosmetic.DisableAccessories();
    if ((Object) this.Student.EightiesTeacherAttacher != (Object) null && this.Student.EightiesTeacherAttacher.activeInHierarchy)
      this.Student.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.enabled = false;
    if ((Object) this.Student.Cosmetic.BurlapSack != (Object) null && (Object) this.Student.Cosmetic.BurlapSack.newRenderer != (Object) null)
      this.Student.Cosmetic.BurlapSack.newRenderer.enabled = false;
    this.Student.SpeechLines.Stop();
    this.Student.DisableProps();
    if (this.Student.Male)
      this.Student.DisableMaleProps();
    else
      this.Student.DisableFemaleProps();
    if (this.Student.Male)
      return;
    this.Student.Cosmetic.DisableFingernails();
  }
}
