// Decompiled with JetBrains decompiler
// Type: MGPMEnemyScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MGPMEnemyScript : MonoBehaviour
{
  public MGPMManagerScript GameplayManager;
  public MGPMMiyukiScript Miyuki;
  public AudioSource MyAudio;
  public GameObject FinalBossExplosion;
  public GameObject Projectile;
  public GameObject Explosion;
  public GameObject PickUp;
  public GameObject Impact;
  public Renderer ExtraRenderer;
  public Renderer MyRenderer;
  public Collider MyCollider;
  public Transform HealthBar;
  public Texture[] Sprite;
  public int Pattern;
  public int Health;
  public int Frame;
  public int Phase;
  public int Side;
  public float AttackFrequency;
  public float ExplosionTimer;
  public float AttackTimer;
  public float DeathTimer;
  public float PhaseTimer;
  public float FlashWhite;
  public float Rotation;
  public float Speed;
  public float Timer;
  public float Spin;
  public float FPS;
  public float PositionX;
  public float PositionY;
  public bool ShootEverywhere;
  public bool QuintupleAttack;
  public bool SextupleAttack;
  public bool DoubleAttack;
  public bool TripleAttack;
  public bool Homing;

  private void Start()
  {
    if (this.Pattern != 10 && GameGlobals.HardMode)
      this.Health += 6;
    this.Side = (double) this.transform.localPosition.x >= 0.0 ? -1 : 1;
    if (this.Pattern == 11)
      this.MyCollider.enabled = false;
    if (this.GameplayManager.GameOver)
    {
      this.MyAudio.volume = 0.0f;
      this.AttackFrequency = 0.0f;
    }
    if (!this.GameplayManager.Eighties)
      return;
    this.MyRenderer.material.color = new Color(1f, 0.0f, 0.0f, 1f);
    if (!((Object) this.ExtraRenderer != (Object) null))
      return;
    this.ExtraRenderer.material.color = new Color(1f, 0.0f, 0.0f, 1f);
  }

  private void Update()
  {
    if (this.Health > 0)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > (double) this.FPS)
      {
        this.Timer = 0.0f;
        ++this.Frame;
        if (this.Frame == this.Sprite.Length)
          this.Frame = 0;
        this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
        if ((Object) this.ExtraRenderer != (Object) null)
          this.ExtraRenderer.material.mainTexture = this.Sprite[this.Frame];
      }
      switch (this.Pattern)
      {
        case 0:
          this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - this.Speed * Time.deltaTime, 0.0f);
          this.Speed = Mathf.Lerp(this.Speed, 0.0f, Time.deltaTime);
          break;
        case 1:
          if (this.Phase == 1)
          {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, this.Miyuki.transform.localPosition, this.Speed * Time.deltaTime);
            this.Speed = Mathf.Lerp(this.Speed, 0.0f, Time.deltaTime);
            this.PhaseTimer += Time.deltaTime;
            if ((double) this.PhaseTimer > 2.0)
            {
              this.AttackTimer = -100f;
              ++this.Phase;
              break;
            }
            break;
          }
          this.Rotation = Mathf.Lerp(this.Rotation, (float) (90 * this.Side), this.Speed * Time.deltaTime);
          this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.Rotation);
          this.transform.Translate(this.transform.up * -1f * this.Speed * Time.deltaTime);
          this.Speed += Time.deltaTime;
          if ((double) this.transform.localPosition.y > 288.0)
          {
            Object.Destroy((Object) this.gameObject);
            break;
          }
          break;
        case 2:
          this.transform.localPosition = new Vector3(this.transform.localPosition.x + this.Speed * Time.deltaTime, this.transform.localPosition.y - 100f * Time.deltaTime, this.transform.localPosition.z);
          if (this.Phase == 1)
          {
            this.Speed -= Time.deltaTime * 200f;
            if ((double) this.Speed < -200.0)
              ++this.Phase;
          }
          else
          {
            this.Speed += Time.deltaTime * 200f;
            if ((double) this.Speed > 200.0)
              --this.Phase;
          }
          if ((double) this.transform.localPosition.y < -288.0)
          {
            Object.Destroy((Object) this.gameObject);
            break;
          }
          break;
        case 3:
          this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - this.Speed * Time.deltaTime, 0.0f);
          if ((double) this.transform.localPosition.y < -288.0)
          {
            Object.Destroy((Object) this.gameObject);
            break;
          }
          break;
        case 4:
          this.transform.LookAt(this.Miyuki.transform.position);
          this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - this.Speed * Time.deltaTime, 0.0f);
          if ((double) this.transform.localPosition.y < -288.0)
          {
            Object.Destroy((Object) this.gameObject);
            break;
          }
          break;
        case 5:
          if (this.Phase == 1)
          {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(this.transform.localPosition.x, 0.0f, this.transform.localPosition.z), this.Speed * Time.deltaTime);
            this.PhaseTimer += Time.deltaTime;
            if ((double) this.PhaseTimer > 1.0)
            {
              this.Speed = 1f;
              ++this.Phase;
            }
          }
          else
          {
            this.Speed += (float) ((double) this.Speed * (double) Time.deltaTime * 2.5);
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.Speed * -1f, this.transform.localPosition.z);
          }
          if ((double) this.transform.localPosition.y < -288.0)
          {
            Object.Destroy((Object) this.gameObject);
            break;
          }
          break;
        case 6:
          this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(this.transform.localPosition.x, 135f, this.transform.localPosition.z), this.Speed * Time.deltaTime);
          break;
        case 7:
          this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90f);
          this.transform.localPosition = new Vector3(this.transform.localPosition.x - this.Speed * Time.deltaTime, this.transform.localPosition.y - this.Speed * 0.25f * Time.deltaTime, this.transform.localPosition.z);
          if ((double) this.transform.localPosition.x < -160.0)
          {
            Object.Destroy((Object) this.gameObject);
            break;
          }
          break;
        case 8:
          this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
          this.transform.localPosition = new Vector3(this.transform.localPosition.x + this.Speed * Time.deltaTime, this.transform.localPosition.y - this.Speed * 0.25f * Time.deltaTime, this.transform.localPosition.z);
          if ((double) this.transform.localPosition.x > 160.0)
          {
            Object.Destroy((Object) this.gameObject);
            break;
          }
          break;
        case 9:
          this.transform.localPosition = new Vector3(this.transform.localPosition.x + this.Speed * Time.deltaTime, this.transform.localPosition.y - 20f * Time.deltaTime, this.transform.localPosition.z);
          if ((double) this.transform.localPosition.x > 60.0)
            this.transform.localPosition = new Vector3(60f, this.transform.localPosition.y, this.transform.localPosition.z);
          else if ((double) this.transform.localPosition.x < -60.0)
            this.transform.localPosition = new Vector3(-60f, this.transform.localPosition.y, this.transform.localPosition.z);
          if (this.Phase == 1)
          {
            this.Speed -= Time.deltaTime * 120f;
            if ((double) this.Speed < -120.0)
              ++this.Phase;
          }
          else
          {
            this.Speed += Time.deltaTime * 120f;
            if ((double) this.Speed > 120.0)
              --this.Phase;
          }
          if ((double) this.transform.localPosition.y < -288.0)
          {
            Object.Destroy((Object) this.gameObject);
            break;
          }
          break;
        case 10:
          if (this.Phase == 1)
          {
            this.transform.LookAt(this.Miyuki.transform);
            ++this.Phase;
          }
          else
            this.transform.Translate(Vector3.forward * this.Speed * Time.deltaTime, Space.Self);
          if ((double) this.transform.localPosition.y < -288.0)
          {
            Object.Destroy((Object) this.gameObject);
            break;
          }
          break;
        case 11:
          if (this.Phase == 1)
          {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(this.transform.localPosition.x, 150f, this.transform.localPosition.z), this.Speed * Time.deltaTime);
            this.PhaseTimer += Time.deltaTime;
            if ((double) this.PhaseTimer > 5.0)
            {
              this.MyCollider.enabled = true;
              this.AttackFrequency = 0.5f;
              this.PhaseTimer = 0.0f;
              this.Speed = 0.0f;
              ++this.Phase;
              break;
            }
            break;
          }
          if (this.Phase == 2)
          {
            this.PhaseTimer += Time.deltaTime;
            if ((double) this.PhaseTimer > 10.0)
            {
              this.QuintupleAttack = false;
              this.SextupleAttack = false;
              this.ShootEverywhere = true;
              this.AttackFrequency = 0.1f;
              this.PhaseTimer = 0.0f;
              this.Speed = 0.1f;
              this.Spin = 45f;
              ++this.Phase;
              break;
            }
            break;
          }
          if (this.Phase == 3)
          {
            this.PhaseTimer += Time.deltaTime;
            this.Speed += this.Speed * Time.deltaTime;
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(this.transform.localPosition.x, -214f, this.transform.localPosition.z), this.Speed * Time.deltaTime);
            if ((double) this.PhaseTimer > 5.0)
            {
              this.PhaseTimer = 0.0f;
              this.Speed = 0.1f;
              ++this.Phase;
              break;
            }
            break;
          }
          if (this.Phase == 4)
          {
            this.PhaseTimer += Time.deltaTime;
            this.Speed += this.Speed * Time.deltaTime;
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(this.transform.localPosition.x, 150f, this.transform.localPosition.z), this.Speed * Time.deltaTime);
            if ((double) this.PhaseTimer > 5.0)
            {
              this.QuintupleAttack = true;
              this.SextupleAttack = true;
              this.ShootEverywhere = false;
              this.AttackFrequency = 0.5f;
              this.PhaseTimer = 0.0f;
              this.Phase = 2;
              break;
            }
            break;
          }
          break;
      }
      if ((double) this.AttackFrequency > 0.0)
      {
        this.AttackTimer += Time.deltaTime;
        if ((double) this.AttackTimer > (double) this.AttackFrequency)
        {
          if (this.ShootEverywhere)
          {
            this.Attack(5f, this.Spin);
            this.Spin += 5f;
          }
          else if (this.SextupleAttack)
          {
            this.Attack(5f, 115f);
            this.Attack(5f, 105f);
            this.Attack(5f, 95f);
            this.Attack(5f, 85f);
            this.Attack(5f, 75f);
            this.Attack(5f, 65f);
            this.QuintupleAttack = true;
            this.SextupleAttack = false;
          }
          else if (this.QuintupleAttack)
          {
            this.Attack(5f, 105f);
            this.Attack(5f, 97.5f);
            this.Attack(5f, 90f);
            this.Attack(5f, 82.5f);
            this.Attack(5f, 75f);
            this.QuintupleAttack = false;
            this.SextupleAttack = true;
          }
          else if (this.TripleAttack)
          {
            this.Attack(5f, 90f);
            this.Attack(5f, 75f);
            this.Attack(5f, 105f);
          }
          else if (this.DoubleAttack)
          {
            this.Attack(2.5f, 90f);
            this.Attack(5f, 90f);
          }
          else
            this.Attack(5f, 90f);
          this.AttackTimer = 0.0f;
        }
      }
    }
    else if (this.Pattern < 11)
    {
      GameObject gameObject1 = Object.Instantiate<GameObject>(this.Explosion, this.transform.position, Quaternion.identity);
      gameObject1.transform.parent = this.transform.parent;
      gameObject1.transform.localScale = this.Pattern == 6 || this.Pattern == 9 || this.Pattern == 12 ? new Vector3(128f, 128f, 1f) : new Vector3(64f, 64f, 1f);
      if (GameGlobals.EasyMode)
      {
        GameObject gameObject2 = Object.Instantiate<GameObject>(this.PickUp, this.transform.position, Quaternion.identity);
        gameObject2.transform.parent = this.transform.parent;
        gameObject2.transform.localScale = new Vector3(16f, 16f, 1f);
        if (this.Miyuki.GameplayManager.Eighties)
          gameObject2.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      }
      this.GameplayManager.Score += 100;
      Object.Destroy((Object) this.gameObject);
    }
    else
    {
      this.GameplayManager.Jukebox.volume -= Time.deltaTime * 0.1f;
      this.AttackFrequency = 0.0f;
      this.Pattern = 100;
      this.DeathTimer += Time.deltaTime;
      if ((double) this.DeathTimer < 5.0)
      {
        if ((double) this.ExplosionTimer == 0.0)
        {
          GameObject gameObject = Object.Instantiate<GameObject>(this.Explosion, this.transform.position, Quaternion.identity);
          gameObject.transform.parent = this.transform.parent;
          gameObject.transform.localPosition += new Vector3(Random.Range(-100f, 100f), Random.Range(-50f, 50f), 0.0f);
          gameObject.transform.localScale = new Vector3(128f, 128f, 1f);
          this.GameplayManager.Score += 100;
          this.ExplosionTimer = 0.1f;
        }
        else
          this.ExplosionTimer = Mathf.MoveTowards(this.ExplosionTimer, 0.0f, Time.deltaTime);
      }
      else
      {
        GameObject gameObject = Object.Instantiate<GameObject>(this.FinalBossExplosion, this.transform.position, Quaternion.identity);
        gameObject.transform.parent = this.transform.parent;
        gameObject.transform.localScale = new Vector3(256f, 256f, 1f);
        this.GameplayManager.StageClear = true;
        this.GameplayManager.Score += 1000;
        Object.Destroy((Object) this.gameObject);
      }
    }
    if ((double) this.FlashWhite <= 0.0)
      return;
    this.FlashWhite = Mathf.MoveTowards(this.FlashWhite, 0.0f, Time.deltaTime);
    if ((double) this.FlashWhite != 0.0)
      return;
    this.MyRenderer.material.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f, 0.0f));
    if (!((Object) this.ExtraRenderer != (Object) null))
      return;
    this.ExtraRenderer.material.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f, 0.0f));
  }

  private void Attack(float AttackSpeed, float AttackRotation)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(this.Projectile, this.transform.position, Quaternion.identity);
    gameObject.transform.parent = this.transform.parent;
    gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
    if (this.Homing)
      gameObject.transform.LookAt(this.Miyuki.transform);
    else
      gameObject.transform.localEulerAngles = new Vector3(AttackRotation, 90f, 0.0f);
    gameObject.GetComponent<MGPMProjectileScript>().Speed = AttackSpeed;
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.layer != 8)
      return;
    GameObject gameObject = Object.Instantiate<GameObject>(this.Impact, this.transform.position, Quaternion.identity);
    gameObject.transform.parent = this.transform.parent;
    gameObject.transform.localScale = new Vector3(32f, 32f, 32f);
    gameObject.transform.localPosition = new Vector3(collision.gameObject.transform.localPosition.x, collision.gameObject.transform.localPosition.y, 1f);
    this.MyRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
    if ((Object) this.ExtraRenderer != (Object) null)
      this.ExtraRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
    Object.Destroy((Object) collision.gameObject);
    this.FlashWhite = 0.05f;
    --this.Health;
    if (this.Health == 0 && (Object) this.MyCollider != (Object) null)
      this.MyCollider.enabled = false;
    if (!((Object) this.HealthBar != (Object) null))
      return;
    this.HealthBar.localScale = new Vector3((float) this.Health / 500f, 1f, 1f);
  }
}
