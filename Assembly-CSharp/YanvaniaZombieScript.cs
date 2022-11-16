// Decompiled with JetBrains decompiler
// Type: YanvaniaZombieScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaZombieScript : MonoBehaviour
{
  public GameObject ZombieEffect;
  public GameObject BloodEffect;
  public GameObject DeathEffect;
  public GameObject HitEffect;
  public GameObject Character;
  public YanvaniaYanmontScript Yanmont;
  public int HP;
  public float WalkSpeed1;
  public float WalkSpeed2;
  public float Damage;
  public float HitReactTimer;
  public float DeathTimer;
  public float WalkTimer;
  public float Timer;
  public int HitReactState;
  public int WalkType;
  public float LeftBoundary;
  public float RightBoundary;
  public bool EffectSpawned;
  public bool Dying;
  public bool Sink;
  public bool Walk;
  public Texture[] Textures;
  public Renderer MyRenderer;
  public Collider MyCollider;
  public AudioClip DeathSound;
  public AudioClip HitSound;
  public AudioClip RisingSound;
  public AudioClip SinkingSound;

  private void Start()
  {
    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, (double) this.Yanmont.transform.position.x > (double) this.transform.position.x ? 90f : -90f, this.transform.eulerAngles.z);
    Object.Instantiate<GameObject>(this.ZombieEffect, this.transform.position, Quaternion.identity);
    this.transform.position = new Vector3(this.transform.position.x, -0.63f, this.transform.position.z);
    Animation component = this.Character.GetComponent<Animation>();
    component["getup1"].speed = 2f;
    component.Play("getup1");
    this.GetComponent<AudioSource>().PlayOneShot(this.RisingSound);
    this.MyRenderer.material.mainTexture = this.Textures[Random.Range(0, 22)];
    this.MyCollider.enabled = false;
  }

  private void Update()
  {
    AudioSource component1 = this.GetComponent<AudioSource>();
    if (this.Dying)
    {
      this.DeathTimer += Time.deltaTime;
      if ((double) this.DeathTimer > 1.0)
      {
        if (!this.EffectSpawned)
        {
          Object.Instantiate<GameObject>(this.ZombieEffect, this.transform.position, Quaternion.identity);
          component1.PlayOneShot(this.SinkingSound);
          this.EffectSpawned = true;
        }
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - Time.deltaTime, this.transform.position.z);
        if ((double) this.transform.position.y < -0.40000000596046448)
          Object.Destroy((Object) this.gameObject);
      }
    }
    else
    {
      Animation component2 = this.Character.GetComponent<Animation>();
      if (this.Sink)
      {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - Time.deltaTime * 0.74f, this.transform.position.z);
        if ((double) this.transform.position.y < -0.62999999523162842)
          Object.Destroy((Object) this.gameObject);
      }
      else if (this.Walk)
      {
        this.WalkTimer += Time.deltaTime;
        if (this.WalkType == 1)
        {
          this.transform.Translate(Vector3.forward * Time.deltaTime * this.WalkSpeed1);
          component2.CrossFade("walk1");
        }
        else
        {
          this.transform.Translate(Vector3.forward * Time.deltaTime * this.WalkSpeed2);
          component2.CrossFade("walk2");
        }
        if ((double) this.WalkTimer > 10.0)
          this.SinkNow();
      }
      else
      {
        this.Timer += Time.deltaTime;
        if ((double) this.transform.position.y < 0.0)
        {
          this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime * 0.74f, this.transform.position.z);
          if ((double) this.transform.position.y > 0.0)
            this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
        }
        if ((double) this.Timer > 0.85000002384185791)
        {
          this.Walk = true;
          this.MyCollider.enabled = true;
          this.WalkType = Random.Range(1, 3);
        }
      }
      if ((double) this.transform.position.x < (double) this.LeftBoundary)
      {
        this.transform.position = new Vector3(this.LeftBoundary, this.transform.position.y, this.transform.position.z);
        this.SinkNow();
      }
      if ((double) this.transform.position.x > (double) this.RightBoundary)
      {
        this.transform.position = new Vector3(this.RightBoundary, this.transform.position.y, this.transform.position.z);
        this.SinkNow();
      }
      if (this.HP <= 0)
      {
        Object.Instantiate<GameObject>(this.DeathEffect, new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), Quaternion.identity);
        component2.Play("die");
        component1.PlayOneShot(this.DeathSound);
        this.MyCollider.enabled = false;
        this.Yanmont.EXP += 10f;
        this.Dying = true;
      }
    }
    if ((double) this.HitReactTimer >= 1.0)
      return;
    this.MyRenderer.material.color = new Color(1f, this.HitReactTimer, this.HitReactTimer, 1f);
    this.HitReactTimer += Time.deltaTime * 10f;
    if ((double) this.HitReactTimer < 1.0)
      return;
    this.MyRenderer.material.color = new Color(1f, 1f, 1f, 1f);
  }

  private void SinkNow()
  {
    Animation component = this.Character.GetComponent<Animation>();
    component["getup1"].time = component["getup1"].length;
    component["getup1"].speed = -2f;
    component.Play("getup1");
    this.GetComponent<AudioSource>().PlayOneShot(this.SinkingSound);
    Object.Instantiate<GameObject>(this.ZombieEffect, this.transform.position, Quaternion.identity);
    this.MyCollider.enabled = false;
    this.Sink = true;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (this.Dying)
      return;
    if (other.gameObject.tag == "Player")
      this.Yanmont.TakeDamage(5);
    if (!(other.gameObject.name == "Heart") || (double) this.HitReactTimer < 1.0)
      return;
    Object.Instantiate<GameObject>(this.HitEffect, other.transform.position, Quaternion.identity);
    this.GetComponent<AudioSource>().PlayOneShot(this.HitSound);
    this.HitReactTimer = 0.0f;
    this.HP -= 20 + (this.Yanmont.Level * 5 - 5);
  }
}
