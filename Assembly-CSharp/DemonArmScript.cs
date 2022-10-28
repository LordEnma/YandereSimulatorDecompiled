// Decompiled with JetBrains decompiler
// Type: DemonArmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DemonArmScript : MonoBehaviour
{
  public GameObject DismembermentCollider;
  public Animation MyAnimation;
  public Collider ClawCollider;
  public bool Attacking;
  public bool Attacked;
  public bool Rising = true;
  public string IdleAnim = "DemonArmIdle";
  public string AttackAnim = "DemonArmAttack";
  public AudioClip Whoosh;
  public float AnimSpeed = 1f;
  public float AnimTime;

  private void Start()
  {
    this.MyAnimation = this.GetComponent<Animation>();
    if (!this.Rising)
      this.MyAnimation[this.IdleAnim].speed = this.AnimSpeed * 0.5f;
    this.MyAnimation[this.AttackAnim].speed = 1f;
  }

  private void Update()
  {
    if (!this.Rising)
    {
      if (!this.Attacking)
        this.MyAnimation.CrossFade(this.IdleAnim);
      else if (!this.Attacked)
      {
        if ((double) this.MyAnimation[this.AttackAnim].time < (double) this.MyAnimation[this.AttackAnim].length * 0.15000000596046448)
          return;
        this.ClawCollider.enabled = true;
        this.Attacked = true;
      }
      else
      {
        if ((double) this.MyAnimation[this.AttackAnim].time >= (double) this.MyAnimation[this.AttackAnim].length * 0.40000000596046448)
          this.ClawCollider.enabled = false;
        if ((double) this.MyAnimation[this.AttackAnim].time < (double) this.MyAnimation[this.AttackAnim].length)
          return;
        this.MyAnimation.CrossFade(this.IdleAnim);
        this.ClawCollider.enabled = false;
        this.Attacking = false;
        this.Attacked = false;
        this.AnimTime = 0.0f;
      }
    }
    else
    {
      if ((double) this.MyAnimation["DemonArmRise"].time < (double) this.MyAnimation["DemonArmRise"].length)
        return;
      this.Rising = false;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    StudentScript component1 = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component1 != (Object) null) || component1.StudentID <= 1)
      return;
    AudioSource component2 = this.GetComponent<AudioSource>();
    component2.clip = this.Whoosh;
    component2.pitch = Random.Range(-0.9f, 1.1f);
    component2.Play();
    this.GetComponent<Animation>().CrossFade(this.AttackAnim);
    this.Attacking = true;
  }
}
