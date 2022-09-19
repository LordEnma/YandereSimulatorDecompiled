// Decompiled with JetBrains decompiler
// Type: DelinquentScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    this.EasterHair.SetActive(false);
    this.Bandanas.SetActive(false);
    this.OriginalRotation = this.transform.rotation;
    this.LookAtTarget = this.Default.position;
    if (!((Object) this.Weapon != (Object) null))
      return;
    this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, -0.145f, this.Weapon.localPosition.z);
    this.Rotation = 90f;
    this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
  }

  private void Update()
  {
    this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
    AudioSource component1 = this.GetComponent<AudioSource>();
    if ((double) this.DistanceToPlayer < 7.0)
    {
      this.Planes = GeometryUtility.CalculateFrustumPlanes(this.Eyes);
      if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.GetComponent<Collider>().bounds))
      {
        RaycastHit hitInfo;
        if (Physics.Linecast(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up, out hitInfo))
        {
          if ((Object) hitInfo.collider.gameObject == (Object) this.Yandere.gameObject)
          {
            this.LookAtPlayer = true;
            if (this.Yandere.Armed)
            {
              if (!this.Threatening)
              {
                component1.clip = this.SurpriseClips[Random.Range(0, this.SurpriseClips.Length)];
                component1.pitch = Random.Range(0.9f, 1.1f);
                component1.Play();
              }
              this.Threatening = true;
              if (this.Cooldown)
              {
                this.Cooldown = false;
                this.Timer = 0.0f;
              }
            }
            else
            {
              if (this.Yandere.CorpseWarning)
              {
                if (!this.Threatening)
                {
                  component1.clip = this.SurpriseClips[Random.Range(0, this.SurpriseClips.Length)];
                  component1.pitch = Random.Range(0.9f, 1.1f);
                  component1.Play();
                }
                this.Threatening = true;
                if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
                {
                  this.DelinquentManager.Attacker = this;
                  this.Run = true;
                }
                this.Yandere.Chased = true;
              }
              else if (!this.Threatening && (double) this.DelinquentManager.SpeechTimer == 0.0)
              {
                component1.clip = (Object) this.Yandere.Container == (Object) null ? this.ProximityClips[Random.Range(0, this.ProximityClips.Length)] : this.CaseClips[Random.Range(0, this.CaseClips.Length)];
                component1.Play();
                this.DelinquentManager.SpeechTimer = 10f;
              }
              this.LookAtPlayer = true;
            }
          }
          else
            this.LookAtPlayer = false;
        }
      }
      else
        this.LookAtPlayer = false;
    }
    if (!this.Threatening)
    {
      if (this.Shoving)
      {
        this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        this.targetRotation = Quaternion.LookRotation(this.transform.position - this.Yandere.transform.position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if ((double) this.Character.GetComponent<Animation>()[this.ShoveAnim].time >= (double) this.Character.GetComponent<Animation>()[this.ShoveAnim].length)
        {
          this.LookAtTarget = this.Neck.position + this.Neck.forward;
          this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim, 1f);
          this.Shoving = false;
        }
        if ((Object) this.Weapon != (Object) null)
        {
          this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, Mathf.Lerp(this.Weapon.localPosition.y, 0.0f, Time.deltaTime * 10f), this.Weapon.localPosition.z);
          this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 10f);
          this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
        }
      }
      else
      {
        this.Shove();
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.OriginalRotation, Time.deltaTime);
        if ((Object) this.Weapon != (Object) null)
        {
          this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, Mathf.Lerp(this.Weapon.localPosition.y, -0.145f, Time.deltaTime * 10f), this.Weapon.localPosition.z);
          this.Rotation = Mathf.Lerp(this.Rotation, 90f, Time.deltaTime * 10f);
          this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
        }
      }
    }
    else
    {
      this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      if ((Object) this.Weapon != (Object) null)
      {
        this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, Mathf.Lerp(this.Weapon.localPosition.y, 0.0f, Time.deltaTime * 10f), this.Weapon.localPosition.z);
        this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 10f);
        this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
      }
      if ((double) this.DistanceToPlayer < 1.0)
      {
        if (this.Yandere.Armed || this.Run)
        {
          if (!this.Yandere.Attacked)
          {
            if (this.Yandere.CanMove && (!this.Yandere.Chased && this.Yandere.Chasers == 0 || this.Yandere.Chased && (Object) this.DelinquentManager.Attacker == (Object) this))
            {
              AudioSource component2 = this.DelinquentManager.GetComponent<AudioSource>();
              if (!component2.isPlaying)
              {
                component2.clip = this.AttackClip;
                component2.Play();
                this.DelinquentManager.enabled = false;
              }
              if (this.Yandere.Laughing)
                this.Yandere.StopLaughing();
              if (this.Yandere.Aiming)
                this.Yandere.StopAiming();
              this.Character.GetComponent<Animation>().CrossFade(this.SwingAnim);
              this.MyWeapon.SetActive(true);
              this.Attacking = true;
              this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_swingB_00");
              this.Yandere.RPGCamera.enabled = false;
              this.Yandere.CanMove = false;
              this.Yandere.Attacked = true;
              this.Yandere.EmptyHands();
            }
          }
          else if (this.Attacking)
          {
            if (this.AudioPhase == 1)
            {
              if ((double) this.Character.GetComponent<Animation>()[this.SwingAnim].time >= (double) this.Character.GetComponent<Animation>()[this.SwingAnim].length * 0.30000001192092896)
              {
                this.Jukebox.SetActive(false);
                ++this.AudioPhase;
                component1.pitch = 1f;
                component1.clip = this.Strike;
                component1.Play();
              }
            }
            else if (this.AudioPhase == 2 && (double) this.Character.GetComponent<Animation>()[this.SwingAnim].time >= (double) this.Character.GetComponent<Animation>()[this.SwingAnim].length * 0.85000002384185791)
            {
              ++this.AudioPhase;
              component1.pitch = 1f;
              component1.clip = this.Crumple;
              component1.Play();
            }
            this.targetRotation = Quaternion.LookRotation(this.transform.position - this.Yandere.transform.position);
            this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          }
        }
        else
          this.Shove();
      }
      else if (!this.ExpressedSurprise)
      {
        this.Character.GetComponent<Animation>().CrossFade(this.SurpriseAnim);
        if ((double) this.Character.GetComponent<Animation>()[this.SurpriseAnim].time >= (double) this.Character.GetComponent<Animation>()[this.SurpriseAnim].length)
          this.ExpressedSurprise = true;
      }
      else if (this.Run)
      {
        if ((double) this.DistanceToPlayer > 1.0)
        {
          this.transform.position = Vector3.MoveTowards(this.transform.position, this.Yandere.transform.position, Time.deltaTime * this.RunSpeed);
          this.Character.GetComponent<Animation>().CrossFade(this.RunAnim);
          this.RunSpeed += Time.deltaTime;
        }
      }
      else if (!this.Cooldown)
      {
        this.Character.GetComponent<Animation>().CrossFade(this.ThreatenAnim);
        if (!this.Yandere.Armed)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 2.5)
          {
            this.Cooldown = true;
            if (!this.DelinquentManager.GetComponent<AudioSource>().isPlaying)
              this.DelinquentManager.SpeechTimer = Time.deltaTime;
          }
        }
        else
        {
          this.Timer = 0.0f;
          if ((double) this.DelinquentManager.SpeechTimer == 0.0)
          {
            this.DelinquentManager.GetComponent<AudioSource>().clip = this.ThreatenClips[Random.Range(0, this.ThreatenClips.Length)];
            this.DelinquentManager.GetComponent<AudioSource>().Play();
            this.DelinquentManager.SpeechTimer = 10f;
          }
        }
      }
      else
      {
        if ((double) this.DelinquentManager.SpeechTimer == 0.0)
        {
          AudioSource component3 = this.DelinquentManager.GetComponent<AudioSource>();
          if (!component3.isPlaying)
          {
            component3.clip = this.SurrenderClips[Random.Range(0, this.SurrenderClips.Length)];
            component3.Play();
            this.DelinquentManager.SpeechTimer = 5f;
          }
        }
        this.Character.GetComponent<Animation>().CrossFade(this.CooldownAnim, 2.5f);
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.0)
        {
          this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim, 1f);
          this.ExpressedSurprise = false;
          this.Threatening = false;
          this.Cooldown = false;
          this.Timer = 0.0f;
        }
        this.Shove();
      }
    }
    if (Input.GetKeyDown(KeyCode.V) && (Object) this.LongSkirt != (Object) null)
      this.MyRenderer.sharedMesh = this.LongSkirt;
    if (Input.GetKeyDown(KeyCode.Space) && (double) Vector3.Distance(this.Yandere.transform.position, this.DelinquentManager.transform.position) < 10.0)
    {
      ++this.Spaces;
      if (this.Spaces == 9)
      {
        if ((Object) this.HairRenderer == (Object) null)
        {
          this.DefaultHair.SetActive(false);
          this.EasterHair.SetActive(true);
          this.EasterHair.GetComponent<Renderer>().material.mainTexture = this.BlondThugHair;
        }
      }
      else if (this.Spaces == 10)
      {
        this.Rapping = true;
        this.MyWeapon.SetActive(false);
        this.IdleAnim = this.Prefix + "gruntIdle_00";
        Animation component4 = this.Character.GetComponent<Animation>();
        component4.CrossFade(this.IdleAnim);
        component4[this.IdleAnim].time = Random.Range(0.0f, component4[this.IdleAnim].length);
        this.DefaultHair.SetActive(false);
        this.Mask.SetActive(false);
        this.EasterHair.SetActive(true);
        this.Bandanas.SetActive(true);
        if ((Object) this.HairRenderer != (Object) null)
          this.HairRenderer.material.color = this.HairColor;
        this.DelinquentManager.EasterEgg();
      }
    }
    if (!this.Suck)
      return;
    this.transform.position = Vector3.MoveTowards(this.transform.position, this.TimePortal.position, Time.deltaTime * 10f);
    if (!(this.transform.position == this.TimePortal.position))
      return;
    Object.Destroy((Object) this.gameObject);
  }

  private void Shove()
  {
    if (this.Yandere.Shoved || this.Yandere.Tripping || (double) this.DistanceToPlayer >= 0.5)
      return;
    AudioSource component1 = this.DelinquentManager.GetComponent<AudioSource>();
    component1.clip = this.ShoveClips[Random.Range(0, this.ShoveClips.Length)];
    component1.Play();
    this.DelinquentManager.SpeechTimer = 5f;
    if ((double) this.Yandere.transform.position.x > (double) this.transform.position.x)
      this.Yandere.transform.position = new Vector3(this.transform.position.x - 1f / 1000f, this.Yandere.transform.position.y, this.Yandere.transform.position.z);
    if (this.Yandere.Aiming)
      this.Yandere.StopAiming();
    Animation component2 = this.Character.GetComponent<Animation>();
    component2[this.ShoveAnim].time = 0.0f;
    component2.CrossFade(this.ShoveAnim);
    this.Shoving = true;
    this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_shoveA_01");
    this.Yandere.Punching = false;
    this.Yandere.CanMove = false;
    this.Yandere.Shoved = true;
    this.Yandere.ShoveSpeed = 2f;
    this.ExpressedSurprise = false;
    this.Threatening = false;
    this.Cooldown = false;
    this.Timer = 0.0f;
  }

  private void LateUpdate()
  {
    if (!this.Threatening)
    {
      if (!this.Shoving && !this.Rapping)
      {
        this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.LookAtPlayer ? this.Yandere.Head.position : this.Default.position, Time.deltaTime * 2f);
        this.Neck.LookAt(this.LookAtTarget);
      }
      if (this.HeadStill)
        this.Head.transform.localEulerAngles = Vector3.zero;
    }
    if ((double) this.BustSize <= 0.0)
      return;
    this.RightBreast.localScale = new Vector3(this.BustSize, this.BustSize, this.BustSize);
    this.LeftBreast.localScale = new Vector3(this.BustSize, this.BustSize, this.BustSize);
  }

  private void OnEnable() => this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim, 1f);
}
