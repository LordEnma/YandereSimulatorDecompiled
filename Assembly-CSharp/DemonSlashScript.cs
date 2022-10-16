// Decompiled with JetBrains decompiler
// Type: DemonSlashScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DemonSlashScript : MonoBehaviour
{
  public GameObject FemaleBloodyScream;
  public GameObject MaleBloodyScream;
  public AudioSource MyAudio;
  public Collider MyCollider;
  public float Timer;

  private void Start() => this.MyAudio = this.GetComponent<AudioSource>();

  private void Update()
  {
    if (!this.MyCollider.enabled)
      return;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 0.3333333432674408)
      return;
    this.MyCollider.enabled = false;
    this.Timer = 0.0f;
  }

  private void OnTriggerEnter(Collider other)
  {
    Transform root = other.gameObject.transform.root;
    StudentScript component = root.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null) || component.StudentID == 1 || !component.Alive)
      return;
    component.DeathType = DeathType.EasterEgg;
    if (!component.Male)
      Object.Instantiate<GameObject>(this.FemaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
    else
      Object.Instantiate<GameObject>(this.MaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
    component.BecomeRagdoll();
    component.Ragdoll.Dismember();
    this.MyAudio.Play();
  }
}
