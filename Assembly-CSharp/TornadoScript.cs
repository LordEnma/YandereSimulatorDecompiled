// Decompiled with JetBrains decompiler
// Type: TornadoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TornadoScript : MonoBehaviour
{
  public GameObject FemaleBloodyScream;
  public GameObject MaleBloodyScream;
  public GameObject Scream;
  public Collider MyCollider;
  public float Strength = 10000f;
  public float Timer;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 0.5)
      return;
    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
    this.MyCollider.enabled = true;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null) || component.StudentID <= 1)
      return;
    this.Scream = Object.Instantiate<GameObject>(component.Male ? this.MaleBloodyScream : this.FemaleBloodyScream, component.transform.position + Vector3.up, Quaternion.identity);
    this.Scream.transform.parent = component.HipCollider.transform;
    this.Scream.transform.localPosition = Vector3.zero;
    component.DeathType = DeathType.EasterEgg;
    component.BecomeRagdoll();
    Rigidbody allRigidbody = component.Ragdoll.AllRigidbodies[0];
    allRigidbody.isKinematic = false;
    allRigidbody.AddForce(Vector3.up * this.Strength);
  }
}
