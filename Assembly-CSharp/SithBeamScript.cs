// Decompiled with JetBrains decompiler
// Type: SithBeamScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SithBeamScript : MonoBehaviour
{
  public GameObject BloodEffect;
  public Collider MyCollider;
  public float Damage = 10f;
  public float Lifespan;
  public int RandomNumber;
  public AudioClip Hit;
  public AudioClip[] FemalePain;
  public AudioClip[] MalePain;
  public bool Projectile;

  private void Update()
  {
    if (this.Projectile)
      this.transform.Translate(this.transform.forward * Time.deltaTime * 15f, Space.World);
    this.Lifespan = Mathf.MoveTowards(this.Lifespan, 0.0f, Time.deltaTime);
    if ((double) this.Lifespan != 0.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null) || component.StudentID <= 1)
      return;
    AudioSource.PlayClipAtPoint(this.Hit, this.transform.position);
    this.RandomNumber = Random.Range(0, 3);
    if (this.MalePain.Length != 0)
    {
      if (component.Male)
        AudioSource.PlayClipAtPoint(this.MalePain[this.RandomNumber], this.transform.position);
      else
        AudioSource.PlayClipAtPoint(this.FemalePain[this.RandomNumber], this.transform.position);
    }
    Object.Instantiate<GameObject>(this.BloodEffect, component.transform.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity);
    component.Health -= this.Damage;
    component.HealthBar.transform.parent.gameObject.SetActive(true);
    component.HealthBar.transform.localScale = new Vector3(component.Health / 100f, 1f, 1f);
    component.Character.transform.localScale = new Vector3(component.Character.transform.localScale.x * -1f, component.Character.transform.localScale.y, component.Character.transform.localScale.z);
    if ((double) component.Health <= 0.0)
    {
      component.DeathType = DeathType.EasterEgg;
      component.HealthBar.transform.parent.gameObject.SetActive(false);
      component.BecomeRagdoll();
      component.Ragdoll.AllRigidbodies[0].isKinematic = false;
    }
    else
    {
      component.CharacterAnimation[component.SithReactAnim].time = 0.0f;
      component.CharacterAnimation.Play(component.SithReactAnim);
      component.Pathfinding.canSearch = false;
      component.Pathfinding.canMove = false;
      component.HitReacting = true;
      component.Routine = false;
      component.Fleeing = false;
    }
    if (!this.Projectile)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
