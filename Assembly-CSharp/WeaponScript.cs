// Decompiled with JetBrains decompiler
// Type: WeaponScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WeaponScript : MonoBehaviour
{
  public ParticleSystem[] ShortBloodSpray;
  public ParticleSystem[] BloodSpray;
  public OutlineScript[] Outline;
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
  public ParticleSystem FireEffect;
  public GameObject WeaponTrail;
  public GameObject ExtraBlade;
  public AudioSource FireAudio;
  public Rigidbody MyRigidbody;
  public AudioSource MyAudio;
  public Collider MyCollider;
  public Renderer MyRenderer;
  public GameObject Nails;
  public Transform Blade;
  public Projector Blood;
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
  public bool Disposed;
  public bool Evidence;
  public bool Innocent;
  public bool StartLow;
  public bool Flaming;
  public bool Bloody;
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
  public float OriginalOffset;
  public float KinematicTimer;
  public float DumpTimer;
  public float Rotation;
  public float Speed;
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
  public GameObject HeartBurst;

  public void Start()
  {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    this.StartingPosition = this.transform.position;
    this.StartingRotation = this.transform.eulerAngles;
    Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
    this.OriginalColor = this.Outline[0].color;
    if (this.StartLow)
    {
      this.OriginalOffset = this.Prompt.OffsetY[3];
      this.Prompt.OffsetY[3] = 0.2f;
    }
    if (this.DisableCollider)
      this.MyCollider.enabled = false;
    this.MyAudio = this.GetComponent<AudioSource>();
    if ((Object) this.MyAudio != (Object) null)
      this.OriginalClip = this.MyAudio.clip;
    this.MyRigidbody = this.GetComponent<Rigidbody>();
    this.MyRigidbody.isKinematic = true;
    if (!this.BroughtFromHome)
    {
      Transform transform = GameObject.Find("WeaponOriginParent").transform;
      this.Origin = Object.Instantiate<GameObject>(this.Prompt.Yandere.StudentManager.EmptyObject, this.transform.position, Quaternion.identity).transform;
      this.Origin.parent = transform;
    }
    if (this.WeaponID == 7 && GameGlobals.Eighties)
    {
      this.MyMeshFilter.mesh = this.EightiesCircularSaw;
      this.MyRenderer.material.mainTexture = this.EightiesCircularSawTexture;
      this.MyRenderer.transform.localPosition = new Vector3(0.005f, 0.045f, -0.0075f);
    }
    this.Innocent = !this.Suspicious;
  }

  public string GetTypePrefix()
  {
    if (this.Type == WeaponType.Knife)
      return "knife";
    if (this.Type == WeaponType.Katana)
      return "katana";
    if (this.Type == WeaponType.Bat)
      return "bat";
    if (this.Type == WeaponType.Saw)
      return "saw";
    if (this.Type == WeaponType.Syringe)
      return "syringe";
    if (this.Type == WeaponType.Weight)
      return "weight";
    if (this.Type == WeaponType.Garrote)
      return "syringe";
    Debug.LogError((object) ("Weapon type \"" + this.Type.ToString() + "\" not implemented."));
    return string.Empty;
  }

  public AudioClip GetClip(float sanity, bool stealth)
  {
    AudioClip[] audioClipArray = this.Clips2.Length != 0 ? (Random.Range(2, 4) == 2 ? this.Clips2 : this.Clips3) : this.Clips;
    if (stealth)
      return audioClipArray[0];
    if ((double) sanity > 0.66666668653488159)
      return audioClipArray[1];
    return (double) sanity > 0.3333333432674408 ? audioClipArray[2] : audioClipArray[3];
  }

  private void Update()
  {
    if (this.WeaponID == 16 && (Object) this.Yandere.EquippedWeapon == (Object) this && Input.GetButtonDown("RB") && (Object) this.ExtraBlade != (Object) null)
      this.ExtraBlade.SetActive(!this.ExtraBlade.activeInHierarchy);
    if (this.Dismembering)
    {
      if (this.DismemberPhase < 4)
      {
        if ((double) this.MyAudio.time > 0.75)
        {
          if ((double) this.Speed < 36.0)
            this.Speed += Time.deltaTime + 10f;
          this.Rotation += this.Speed;
          this.Blade.localEulerAngles = new Vector3(this.Rotation, this.Blade.localEulerAngles.y, this.Blade.localEulerAngles.z);
        }
        if ((double) this.MyAudio.time > (double) this.SoundTime[this.DismemberPhase])
        {
          this.Yandere.Sanity -= (PlayerGlobals.PantiesEquipped == 10 ? 2.5f : 5f) * this.Yandere.Numbness;
          this.Yandere.Bloodiness += 25f;
          this.ShortBloodSpray[0].Play();
          this.ShortBloodSpray[1].Play();
          if (!this.Blood.enabled)
            this.Yandere.StainWeapon();
          ++this.DismemberPhase;
          if (this.Yandere.Gloved && !this.Yandere.Gloves.Blood.enabled)
          {
            this.Yandere.Gloves.PickUp.Evidence = true;
            this.Yandere.Gloves.Blood.enabled = true;
            this.Yandere.GloveBlood = 1;
            ++this.Yandere.Police.BloodyClothing;
          }
        }
      }
      else
      {
        this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 2f);
        this.Blade.localEulerAngles = new Vector3(this.Rotation, this.Blade.localEulerAngles.y, this.Blade.localEulerAngles.z);
        if (!this.MyAudio.isPlaying)
        {
          this.MyAudio.clip = this.OriginalClip;
          this.Dismembering = false;
          this.DismemberPhase = 0;
          this.Rotation = 0.0f;
          this.Speed = 0.0f;
        }
      }
    }
    else if ((Object) this.Yandere.EquippedWeapon == (Object) this)
    {
      if (this.Yandere.AttackManager.IsAttacking())
      {
        if (this.Type == WeaponType.Knife)
          this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, Mathf.Lerp(this.transform.localEulerAngles.y, this.Flip ? 180f : 0.0f, Time.deltaTime * 10f), this.transform.localEulerAngles.z);
        else if (this.Type == WeaponType.Saw && this.Spin)
          this.Blade.transform.localEulerAngles = new Vector3(this.Blade.transform.localEulerAngles.x + Time.deltaTime * 360f, this.Blade.transform.localEulerAngles.y, this.Blade.transform.localEulerAngles.z);
      }
    }
    else if (!this.MyRigidbody.isKinematic)
    {
      this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
      if ((double) this.KinematicTimer == 5.0)
      {
        this.MyRigidbody.isKinematic = true;
        this.KinematicTimer = 0.0f;
      }
      if ((double) this.transform.position.x > -71.0 && (double) this.transform.position.x < -61.0 && (double) this.transform.position.z > -37.5 && (double) this.transform.position.z < -27.5)
      {
        this.Yandere.NotificationManager.CustomText = "The weapon has been placed nearby.";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.transform.position = new Vector3(-63f, 1f, -26.5f);
        this.KinematicTimer = 0.0f;
      }
      if ((double) this.transform.position.x > -21.0 && (double) this.transform.position.x < 21.0 && (double) this.transform.position.z > 100.0 && (double) this.transform.position.z < 135.0)
      {
        this.Yandere.NotificationManager.CustomText = "It rolled to the bottom of the hill.";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.transform.position = new Vector3(0.0f, 0.5f, 99.5f);
        this.KinematicTimer = 0.0f;
      }
      if ((double) this.transform.position.x > -46.0 && (double) this.transform.position.x < -18.0 && (double) this.transform.position.z > 66.0 && (double) this.transform.position.z < 78.0)
      {
        this.transform.position = new Vector3(-16f, 5f, 72f);
        this.KinematicTimer = 0.0f;
      }
    }
    if (!this.Rotate)
      return;
    this.transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
  }

  private void LateUpdate()
  {
    if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
    {
      this.InBag = false;
      if (this.WeaponID == 6 && SchemeGlobals.GetSchemeStage(4) == 1)
      {
        SchemeGlobals.SetSchemeStage(4, 2);
        this.Yandere.PauseScreen.Schemes.UpdateInstructions();
      }
      this.Prompt.Circle[3].fillAmount = 1f;
      if (this.Yandere.Chasers == 0)
      {
        if (this.Prompt.Suspicious)
          this.Yandere.TheftTimer = 0.1f;
        this.SuspicionCheck();
        if (this.Suspicious)
          this.Yandere.WeaponTimer = 0.1f;
      }
      if (!this.Yandere.Gloved)
      {
        if (this.FingerprintID == 0)
        {
          ++this.Yandere.WeaponManager.WeaponsTouched;
          if (this.Yandere.WeaponManager.WeaponsTouched > 19 && !GameGlobals.Debug)
            PlayerPrefs.SetInt("WeaponMaster", 1);
        }
        this.FingerprintID = 100;
      }
      for (this.ID = 0; this.ID < this.Outline.Length; ++this.ID)
      {
        if ((Object) this.Outline[this.ID] != (Object) null)
          this.Outline[this.ID].color = new Color(0.0f, 0.0f, 0.0f, 1f);
      }
      this.transform.parent = this.Yandere.ItemParent;
      this.transform.localPosition = Vector3.zero;
      if (this.Type == WeaponType.Bat)
        this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
      else
        this.transform.localEulerAngles = Vector3.zero;
      this.MyCollider.enabled = false;
      this.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
      if (this.Yandere.Equipped == 3 && (Object) this.Yandere.Weapon[3] != (Object) null)
        this.Yandere.Weapon[3].Drop();
      if ((Object) this.Yandere.PickUp != (Object) null)
        this.Yandere.PickUp.Drop();
      if (this.Yandere.Dragging)
        this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
      if (this.Yandere.Carrying)
        this.Yandere.StopCarrying();
      if (this.Concealable)
      {
        if ((Object) this.Yandere.Weapon[1] == (Object) null)
        {
          if ((Object) this.Yandere.Weapon[2] != (Object) null)
            this.Yandere.Weapon[2].gameObject.SetActive(false);
          this.Yandere.Equipped = 1;
          this.Yandere.EquippedWeapon = this;
          this.Yandere.WeaponManager.SetEquippedWeapon1(this);
        }
        else if ((Object) this.Yandere.Weapon[2] == (Object) null)
        {
          if ((Object) this.Yandere.Weapon[1] != (Object) null)
          {
            if (!this.DoNotDisable)
              this.Yandere.Weapon[1].gameObject.SetActive(false);
            this.DoNotDisable = false;
          }
          this.Yandere.Equipped = 2;
          this.Yandere.EquippedWeapon = this;
          this.Yandere.WeaponManager.SetEquippedWeapon2(this);
        }
        else if (this.Yandere.Weapon[2].gameObject.activeInHierarchy)
        {
          this.Yandere.Weapon[2].Drop();
          this.Yandere.Equipped = 2;
          this.Yandere.EquippedWeapon = this;
          this.Yandere.WeaponManager.SetEquippedWeapon2(this);
        }
        else
        {
          this.Yandere.Weapon[1].Drop();
          this.Yandere.Equipped = 1;
          this.Yandere.EquippedWeapon = this;
          this.Yandere.WeaponManager.SetEquippedWeapon1(this);
        }
      }
      else
      {
        if ((Object) this.Yandere.Weapon[1] != (Object) null)
          this.Yandere.Weapon[1].gameObject.SetActive(false);
        if ((Object) this.Yandere.Weapon[2] != (Object) null)
          this.Yandere.Weapon[2].gameObject.SetActive(false);
        this.Yandere.Equipped = 3;
        this.Yandere.EquippedWeapon = this;
        this.Yandere.WeaponManager.SetEquippedWeapon3(this);
      }
      this.Yandere.StudentManager.UpdateStudents();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Yandere.NearestPrompt = (PromptScript) null;
      if (this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12 || this.WeaponID == 14 || this.WeaponID == 16 || this.WeaponID == 22 || this.WeaponID == 25)
        this.SuspicionCheck();
      if (this.Yandere.EquippedWeapon.Suspicious)
      {
        if (!this.Yandere.WeaponWarning)
        {
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Armed);
          this.Yandere.WeaponWarning = true;
        }
      }
      else
        this.Yandere.WeaponWarning = false;
      this.Yandere.WeaponMenu.UpdateSprites();
      this.Yandere.WeaponManager.UpdateLabels();
      if (this.Blood.enabled)
        --this.Yandere.Police.BloodyWeapons;
      if (this.WeaponID == 11)
      {
        this.Yandere.IdleAnim = "CyborgNinja_Idle_Armed";
        this.Yandere.WalkAnim = "CyborgNinja_Walk_Armed";
        this.Yandere.RunAnim = "CyborgNinja_Run_Armed";
      }
      if (this.WeaponID == 26)
        this.WeaponTrail.SetActive(true);
      this.KinematicTimer = 0.0f;
      AudioSource.PlayClipAtPoint(this.EquipClip, this.Yandere.MainCamera.transform.position);
      if (this.UnequipImmediately)
      {
        this.UnequipImmediately = false;
        this.Yandere.Unequip();
      }
      this.Yandere.UpdateConcealedWeaponStatus();
    }
    if ((Object) this.Yandere.EquippedWeapon == (Object) this && this.Yandere.Armed)
    {
      this.transform.localScale = new Vector3(1f, 1f, 1f);
      if (!this.Yandere.Struggling)
      {
        if (this.Yandere.CanMove)
        {
          this.transform.localPosition = Vector3.zero;
          if (this.Type == WeaponType.Bat)
            this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
          else
            this.transform.localEulerAngles = Vector3.zero;
        }
      }
      else
        this.transform.localPosition = new Vector3(-0.01f, 0.005f, -0.01f);
    }
    if (this.Dumped)
    {
      this.DumpTimer += Time.deltaTime;
      if ((double) this.DumpTimer > 1.0)
      {
        if (this.MurderWeapon)
          ++this.Yandere.Incinerator.MurderWeapons;
        if (this.Bloody)
          ++this.Yandere.Incinerator.BloodyWeapons;
        this.gameObject.SetActive(false);
      }
    }
    if (!((Object) this.transform.parent == (Object) this.Yandere.ItemParent) || !this.Concealable || !((Object) this.Yandere.Weapon[1] != (Object) this) || !((Object) this.Yandere.Weapon[2] != (Object) this))
      return;
    this.Drop();
  }

  public void Drop()
  {
    if (this.Undroppable)
      return;
    if (this.WeaponID == 6 && SchemeGlobals.GetSchemeStage(4) == 2)
    {
      SchemeGlobals.SetSchemeStage(4, 1);
      this.Yandere.PauseScreen.Schemes.UpdateInstructions();
    }
    Debug.Log((object) ("A " + this.gameObject.name + " has just been dropped."));
    if (this.WeaponID == 11)
    {
      this.Yandere.IdleAnim = "CyborgNinja_Idle_Unarmed";
      this.Yandere.WalkAnim = this.Yandere.OriginalWalkAnim;
      this.Yandere.RunAnim = "CyborgNinja_Run_Unarmed";
    }
    if (this.StartLow)
      this.Prompt.OffsetY[3] = this.OriginalOffset;
    if ((Object) this.Yandere.Weapon[1] == (Object) this)
      this.Yandere.WeaponManager.YandereWeapon1 = -1;
    else if ((Object) this.Yandere.Weapon[2] == (Object) this)
      this.Yandere.WeaponManager.YandereWeapon2 = -1;
    else if ((Object) this.Yandere.Weapon[3] == (Object) this)
      this.Yandere.WeaponManager.YandereWeapon3 = -1;
    if ((Object) this.Yandere.EquippedWeapon == (Object) this)
    {
      this.Yandere.EquippedWeapon = (WeaponScript) null;
      this.Yandere.Equipped = 0;
      this.Yandere.StudentManager.UpdateStudents();
    }
    this.gameObject.SetActive(true);
    this.transform.parent = (Transform) null;
    this.MyRigidbody.constraints = RigidbodyConstraints.None;
    this.MyRigidbody.isKinematic = false;
    this.MyRigidbody.useGravity = true;
    this.MyCollider.isTrigger = false;
    if (this.Dumped)
    {
      this.transform.position = this.Incinerator.DumpPoint.position;
    }
    else
    {
      this.Prompt.enabled = true;
      this.MyCollider.enabled = true;
      if (this.Yandere.GetComponent<Collider>().enabled)
        Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
    }
    if (this.Blood.enabled)
      ++this.Yandere.Police.BloodyWeapons;
    if ((double) Vector3.Distance(this.StartingPosition, this.transform.position) > 5.0 && (double) Vector3.Distance(this.transform.position, this.Yandere.StudentManager.WeaponBoxSpot.parent.position) > 1.0)
    {
      if (!this.Misplaced)
      {
        ++this.Prompt.Yandere.WeaponManager.MisplacedWeapons;
        this.Misplaced = true;
      }
    }
    else if (this.Misplaced)
    {
      --this.Prompt.Yandere.WeaponManager.MisplacedWeapons;
      this.Misplaced = false;
    }
    for (this.ID = 0; this.ID < this.Outline.Length; ++this.ID)
      this.Outline[this.ID].color = this.Evidence ? this.EvidenceColor : this.OriginalColor;
    if ((double) this.transform.position.y > 1000.0)
      this.transform.position = new Vector3(12f, 0.0f, 28f);
    if (this.WeaponID == 26)
    {
      this.transform.parent = this.Parent;
      this.transform.localEulerAngles = Vector3.zero;
      this.transform.localPosition = Vector3.zero;
      this.MyRigidbody.isKinematic = true;
      this.WeaponTrail.SetActive(false);
    }
    if ((double) Vector3.Distance(this.transform.position, this.StartingPosition) >= 1.0 && (double) Vector3.Distance(this.Yandere.transform.position, this.StartingPosition) >= 1.0)
      return;
    this.transform.position = this.StartingPosition;
    this.transform.eulerAngles = this.StartingRotation;
    this.MyRigidbody.isKinematic = true;
    this.MyRigidbody.useGravity = false;
    this.MyCollider.isTrigger = true;
  }

  public void UpdateLabel()
  {
    if (!((Object) this != (Object) null) || !this.gameObject.activeInHierarchy)
      return;
    if ((Object) this.Yandere.Weapon[1] != (Object) null && (Object) this.Yandere.Weapon[2] != (Object) null && this.Concealable)
    {
      if (!((Object) this.Prompt.Label[3] != (Object) null))
        return;
      if (!this.Yandere.Armed || this.Yandere.Equipped == 3)
        this.Prompt.Label[3].text = "     Swap " + this.Yandere.Weapon[1].Name + " for " + this.Name;
      else
        this.Prompt.Label[3].text = "     Swap " + this.Yandere.EquippedWeapon.Name + " for " + this.Name;
    }
    else
    {
      if (!((Object) this.Prompt.Label[3] != (Object) null))
        return;
      this.Prompt.Label[3].text = "     " + this.Name;
    }
  }

  public void Effect()
  {
    if (this.WeaponID == 7)
    {
      this.BloodSpray[0].Play();
      this.BloodSpray[1].Play();
    }
    else if (this.WeaponID == 8)
    {
      this.gameObject.GetComponent<ParticleSystem>().Play();
      this.MyAudio.clip = this.OriginalClip;
      this.MyAudio.Play();
    }
    else if (this.WeaponID == 2 || this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12 || this.WeaponID == 13)
    {
      this.MyAudio.Play();
    }
    else
    {
      if (this.WeaponID != 14)
        return;
      Object.Instantiate<GameObject>(this.HeartBurst, this.Yandere.TargetStudent.Head.position, Quaternion.identity);
      this.MyAudio.Play();
    }
  }

  public void Dismember()
  {
    this.Yandere.CameraEffects.UpdateDOF(0.6666667f);
    this.MyAudio.clip = this.DismemberClip;
    this.MyAudio.Play();
    this.Dismembering = true;
  }

  public void SuspicionCheck()
  {
    this.Suspicious = !this.Innocent && (this.WeaponID != 9 || this.Yandere.Club != ClubType.Sports) && (this.WeaponID != 10 || this.Yandere.Club != ClubType.Gardening) && (this.WeaponID != 12 || this.Yandere.Club != ClubType.Sports) && (this.WeaponID != 14 || this.Yandere.Club != ClubType.Drama) && (this.WeaponID != 16 || this.Yandere.Club != ClubType.Drama) && (this.WeaponID != 22 || this.Yandere.Club != ClubType.Drama) && (this.WeaponID != 25 || this.Yandere.Club != ClubType.LightMusic);
    if (this.Bloody)
    {
      this.Suspicious = true;
    }
    else
    {
      for (this.ID = 0; this.ID < this.Outline.Length; ++this.ID)
      {
        if ((Object) this.Outline[this.ID] != (Object) null)
          this.Outline[this.ID].color = new Color(0.0f, 1f, 1f, 1f);
      }
    }
  }
}
