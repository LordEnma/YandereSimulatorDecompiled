// Decompiled with JetBrains decompiler
// Type: YanvaniaDraculaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YanvaniaDraculaScript : MonoBehaviour
{
  public YanvaniaCameraScript YanvaniaCamera;
  public YanvaniaYanmontScript Yanmont;
  public UITexture HealthBarParent;
  public UITexture Photograph;
  public AudioClip DeathScream;
  public AudioClip FinalLine;
  public GameObject NewTeleportEffect;
  public GameObject NewAttack;
  public GameObject DoubleFireball;
  public GameObject TripleFireball;
  public GameObject MainCamera;
  public GameObject EndCamera;
  public GameObject TeleportEffect;
  public GameObject Explosion;
  public GameObject Character;
  public Transform HealthBar;
  public Transform RightHand;
  public Transform Head;
  public Renderer MyRenderer;
  public UILabel Label;
  public AudioClip[] Injuries;
  public float ExplosionTimer;
  public float TeleportTimer = 10f;
  public float AttackTimer;
  public float FinalTimer;
  public float DeathTimer;
  public float FlashTimer;
  public float Distance;
  public float MaxHealth = 100f;
  public float Health = 100f;
  public bool FinalLineSpoken;
  public bool PhotoTaken;
  public bool Screamed;
  public bool Injured;
  public bool Shrink;
  public bool Grow;
  public bool Red;
  public int AttackID;
  public int Frames;
  public int Frame;

  private void Awake()
  {
    Animation component = this.Character.GetComponent<Animation>();
    component["succubus_a_damage_l"].speed = 0.1f;
    component["succubus_a_charm_02"].speed = 2.4f;
    component["succubus_a_charm_03"].speed = 4.66666f;
  }

  private void Update()
  {
    Animation component1 = this.Character.GetComponent<Animation>();
    this.Label.enabled = false;
    if ((double) this.Yanmont.Health > 0.0)
    {
      if ((double) this.Health > 0.0)
      {
        if ((double) this.transform.position.z == 0.0)
          this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, (double) this.Yanmont.transform.position.x > (double) this.transform.position.x ? -90f : 90f, this.transform.localEulerAngles.z);
        if ((Object) this.NewTeleportEffect == (Object) null)
        {
          if ((double) this.transform.position.y > 0.0)
          {
            this.Distance = Mathf.Abs(this.Yanmont.transform.position.x) - Mathf.Abs(this.transform.position.x);
            if ((double) Mathf.Abs(this.Distance) < 0.61000001430511475 && (double) this.Yanmont.FlashTimer == 0.0)
              this.Yanmont.TakeDamage(5);
            if (this.AttackID == 0)
            {
              this.AttackID = Random.Range(1, 3);
              this.TeleportTimer = 5f;
              this.AttackTimer = 0.0f;
              this.NewAttack = (GameObject) null;
              if (this.AttackID == 1)
              {
                component1["succubus_a_charm_02"].time = 0.0f;
                component1.CrossFade("succubus_a_charm_02");
              }
              else
              {
                component1["succubus_a_charm_03"].time = 0.0f;
                component1.CrossFade("succubus_a_charm_03");
              }
            }
            else
            {
              this.AttackTimer += Time.deltaTime;
              if (this.AttackID == 1)
              {
                if ((double) component1["succubus_a_charm_02"].time > 3.5 && (Object) this.NewAttack == (Object) null)
                {
                  this.NewAttack = Object.Instantiate<GameObject>(this.TripleFireball, this.RightHand.position, Quaternion.identity);
                  this.NewAttack.GetComponent<YanvaniaTripleFireballScript>().Dracula = this.transform;
                }
                if ((double) component1["succubus_a_charm_02"].time >= (double) component1["succubus_a_charm_02"].length)
                  component1.CrossFade("succubus_a_idle_01");
              }
              else
              {
                if ((double) component1["succubus_a_charm_03"].time > 4.0 && (Object) this.NewAttack == (Object) null)
                {
                  this.NewAttack = Object.Instantiate<GameObject>(this.DoubleFireball, this.RightHand.position, Quaternion.identity);
                  this.NewAttack.GetComponent<YanvaniaDoubleFireballScript>().Dracula = this.transform;
                }
                if ((double) component1["succubus_a_charm_03"].time >= (double) component1["succubus_a_charm_03"].length)
                  component1.CrossFade("succubus_a_idle_01");
              }
              this.TeleportTimer -= Time.deltaTime;
            }
          }
          else
            this.TeleportTimer -= Time.deltaTime;
          if ((double) this.TeleportTimer < 0.0)
          {
            if ((double) this.transform.position.y < 0.0)
              this.transform.position = new Vector3(Random.Range(-38.5f, -31f), this.transform.position.y, this.transform.position.z);
            this.SpawnTeleportEffect();
          }
        }
        else
        {
          if (this.Shrink)
          {
            this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, new Vector3(0.0f, 2f, 0.0f), (float) ((double) Time.deltaTime * 0.5 * 2.0));
            if ((double) this.transform.localScale.x == 0.0)
            {
              this.NewTeleportEffect = (GameObject) null;
              this.Shrink = false;
              this.Teleport();
            }
          }
          if (this.Grow)
          {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1.5f, 1.5f, 1.5f), (float) ((double) Time.deltaTime * 1.5 * 2.0));
            if ((double) this.transform.localScale.x > 1.4900000095367432)
            {
              this.NewTeleportEffect = (GameObject) null;
              this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
              this.Grow = false;
            }
          }
        }
        if ((double) this.FlashTimer > 0.0)
        {
          this.FlashTimer -= Time.deltaTime;
          if (!this.Red)
          {
            foreach (Material material in this.MyRenderer.materials)
              material.color = new Color(1f, 0.0f, 0.0f, 1f);
            ++this.Frames;
            if (this.Frames == 5)
            {
              this.Frames = 0;
              this.Red = true;
            }
          }
          else
          {
            foreach (Material material in this.MyRenderer.materials)
              material.color = new Color(1f, 1f, 1f, 1f);
            ++this.Frames;
            if (this.Frames == 5)
            {
              this.Frames = 0;
              this.Red = false;
            }
          }
        }
        else
        {
          foreach (Material material in this.MyRenderer.materials)
            material.color = new Color(1f, 1f, 1f, 1f);
        }
      }
      else
      {
        this.HealthBarParent.transform.localPosition = new Vector3(this.HealthBarParent.transform.localPosition.x, this.HealthBarParent.transform.localPosition.y - Time.deltaTime * 0.2f, this.HealthBarParent.transform.localPosition.z);
        this.HealthBarParent.transform.localScale = new Vector3(this.HealthBarParent.transform.localScale.x, this.HealthBarParent.transform.localScale.y + Time.deltaTime * 0.2f, this.HealthBarParent.transform.localScale.z);
        this.HealthBarParent.color = new Color(this.HealthBarParent.color.r, this.HealthBarParent.color.g, this.HealthBarParent.color.b, this.HealthBarParent.color.a - Time.deltaTime * 0.2f);
        component1.Play("succubus_a_damage_l");
        this.ExplosionTimer += Time.deltaTime;
        this.DeathTimer += Time.deltaTime;
        AudioSource component2 = this.GetComponent<AudioSource>();
        if ((double) this.DeathTimer < 5.0)
        {
          if ((double) this.DeathTimer > 1.0 && !this.FinalLineSpoken)
          {
            this.FinalLineSpoken = true;
            component2.clip = this.FinalLine;
            component2.Play();
          }
          if ((double) this.ExplosionTimer > 0.10000000149011612)
          {
            Object.Instantiate<GameObject>(this.Explosion, this.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0.0f, 2.5f), Random.Range(-1f, 1f)), Quaternion.identity);
            this.ExplosionTimer = 0.0f;
          }
        }
        else
        {
          if (!this.Screamed)
          {
            this.Screamed = true;
            component2.clip = this.DeathScream;
            component2.Play();
          }
          if ((double) this.DeathTimer > 5.0)
          {
            if (!this.PhotoTaken)
            {
              Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0.0f, 0.0166666675f);
              if ((double) Time.timeScale == 0.0)
              {
                ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Dracula.png");
                if (this.Frame > 0)
                  this.StartCoroutine(this.ApplyScreenshot());
                ++this.Frame;
              }
            }
            else if ((Object) this.Photograph.mainTexture != (Object) null)
            {
              this.Photograph.transform.localEulerAngles = new Vector3(this.Photograph.transform.localEulerAngles.x + Time.deltaTime * 3.6f, this.Photograph.transform.localEulerAngles.y, this.Photograph.transform.localEulerAngles.z - Time.deltaTime * 3.6f);
              this.Photograph.transform.localScale = Vector3.MoveTowards(this.Photograph.transform.localScale, Vector3.zero, Time.deltaTime * 0.2f);
              this.Photograph.color = new Color(this.Photograph.color.r, this.Photograph.color.g - Time.deltaTime * 0.2f, this.Photograph.color.b - Time.deltaTime * 0.2f, this.Photograph.color.a);
              if (this.Photograph.transform.localScale == Vector3.zero)
              {
                this.FinalTimer += Time.deltaTime;
                if ((double) this.FinalTimer > 1.0)
                {
                  YanvaniaGlobals.DraculaDefeated = true;
                  SceneManager.LoadScene("YanvaniaTitleScene");
                }
              }
            }
          }
        }
      }
    }
    else
      component1.CrossFade("succubus_a_talk_01");
    this.HealthBar.parent.transform.localPosition = new Vector3(Mathf.Lerp(this.HealthBar.parent.transform.localPosition.x, 1025f, Time.deltaTime * 10f), this.HealthBar.parent.transform.localPosition.y, this.HealthBar.parent.transform.localPosition.z);
    this.HealthBar.localScale = new Vector3(this.HealthBar.localScale.x, Mathf.Lerp(this.HealthBar.localScale.y, this.Health / this.MaxHealth, Time.deltaTime * 10f), this.HealthBar.localScale.z);
    if (!Input.GetKeyDown(KeyCode.Alpha4))
      return;
    this.transform.position = new Vector3(this.transform.position.x, 6.5f, 0.0f);
    this.Health = 1f;
    this.TakeDamage();
  }

  public void SpawnTeleportEffect()
  {
    Animation component = this.Character.GetComponent<Animation>();
    if ((double) this.transform.position.y > 0.0)
    {
      this.NewTeleportEffect = Object.Instantiate<GameObject>(this.TeleportEffect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
      component["DraculaTeleport"].time = component["DraculaTeleport"].length;
      component["DraculaTeleport"].speed = -2f;
      component.Play("DraculaTeleport");
      this.Shrink = true;
    }
    else
    {
      this.Teleport();
      this.NewTeleportEffect = Object.Instantiate<GameObject>(this.TeleportEffect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
      component["DraculaTeleport"].speed = 1.7f;
      component["DraculaTeleport"].time = 0.0f;
      component.Play("DraculaTeleport");
      this.Grow = true;
    }
    this.NewTeleportEffect.GetComponent<YanvaniaTeleportEffectScript>().Dracula = this;
    this.TeleportTimer = 1f;
    this.AttackID = 0;
  }

  private void Teleport() => this.transform.position = new Vector3(this.transform.position.x, (double) this.transform.position.y > 0.0 ? -10f : 6.5f, 0.0f);

  public void TakeDamage()
  {
    this.Health -= (float) (5.0 + ((double) this.Yanmont.Level * 5.0 - 5.0));
    if ((double) this.Health <= 0.0)
    {
      this.YanvaniaCamera.StopMusic = true;
      this.Health = 0.0f;
    }
    else
    {
      this.FlashTimer = 1f;
      this.Injured = true;
      AudioSource component = this.GetComponent<AudioSource>();
      component.clip = this.Injuries[Random.Range(0, this.Injuries.Length)];
      component.Play();
    }
  }

  private IEnumerator ApplyScreenshot()
  {
    this.PhotoTaken = true;
    WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Dracula.png");
    yield return (object) www;
    this.Photograph.mainTexture = (Texture) www.texture;
    this.MainCamera.SetActive(false);
    this.EndCamera.GetComponent<AudioListener>().enabled = true;
    Time.timeScale = 1f;
  }
}
