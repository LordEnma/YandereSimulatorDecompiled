// Decompiled with JetBrains decompiler
// Type: YanvaniaWitchScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaWitchScript : MonoBehaviour
{
  public YanvaniaYanmontScript Yanmont;
  public GameObject GroundImpact;
  public GameObject BlackHole;
  public GameObject Character;
  public GameObject HitEffect;
  public GameObject Wall;
  public AudioClip DeathScream;
  public AudioClip HitSound;
  public float HitReactTimer;
  public float AttackTimer = 10f;
  public float HP = 100f;
  public bool CastSpell;
  public bool Casting;

  private void Update()
  {
    Animation component = this.Character.GetComponent<Animation>();
    if ((double) this.AttackTimer < 10.0)
    {
      this.AttackTimer += Time.deltaTime;
      if ((double) this.AttackTimer > 0.800000011920929 && !this.CastSpell)
      {
        this.CastSpell = true;
        Object.Instantiate<GameObject>(this.BlackHole, this.transform.position + Vector3.up * 3f + Vector3.right * 6f, Quaternion.identity);
        Object.Instantiate<GameObject>(this.GroundImpact, this.transform.position + Vector3.right * 1.15f, Quaternion.identity);
      }
      if ((double) component["Staff Spell Ground"].time >= (double) component["Staff Spell Ground"].length)
      {
        component.CrossFade("Staff Stance");
        this.Casting = false;
      }
    }
    else if ((double) Vector3.Distance(this.transform.position, this.Yanmont.transform.position) < 5.0)
    {
      this.AttackTimer = 0.0f;
      this.Casting = true;
      this.CastSpell = false;
      component["Staff Spell Ground"].time = 0.0f;
      component.CrossFade("Staff Spell Ground");
    }
    if (!this.Casting && (double) component["Receive Damage"].time >= (double) component["Receive Damage"].length)
      component.CrossFade("Staff Stance");
    this.HitReactTimer += Time.deltaTime * 10f;
  }

  private void OnTriggerEnter(Collider other)
  {
    if ((double) this.HP <= 0.0)
      return;
    if (other.gameObject.tag == "Player")
      this.Yanmont.TakeDamage(5);
    if (!(other.gameObject.name == "Heart"))
      return;
    Animation component1 = this.Character.GetComponent<Animation>();
    if (!this.Casting)
    {
      component1["Receive Damage"].time = 0.0f;
      component1.Play("Receive Damage");
    }
    if ((double) this.HitReactTimer < 1.0)
      return;
    Object.Instantiate<GameObject>(this.HitEffect, other.transform.position, Quaternion.identity);
    this.HitReactTimer = 0.0f;
    this.HP -= (float) (5.0 + ((double) this.Yanmont.Level * 5.0 - 5.0));
    AudioSource component2 = this.GetComponent<AudioSource>();
    if ((double) this.HP <= 0.0)
    {
      component2.PlayOneShot(this.DeathScream);
      component1.Play("Die 2");
      this.Yanmont.EXP += 100f;
      this.enabled = false;
      Object.Destroy((Object) this.Wall);
    }
    else
      component2.PlayOneShot(this.HitSound);
  }
}
