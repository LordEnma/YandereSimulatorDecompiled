// Decompiled with JetBrains decompiler
// Type: GasterBeamScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GasterBeamScript : MonoBehaviour
{
  public float Strength = 1000f;
  public float Target = 2f;
  public bool LoveLoveBeam;

  private void Start()
  {
    if (!this.LoveLoveBeam)
      return;
    this.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
  }

  private void Update()
  {
    if (!this.LoveLoveBeam)
      return;
    this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(100f, this.Target, this.Target), Time.deltaTime * 10f);
    if ((double) this.transform.localScale.x <= 99.989997863769531)
      return;
    this.Target = 0.0f;
    if ((double) this.transform.localScale.y >= 0.10000000149011612)
      return;
    Object.Destroy((Object) this.gameObject);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null))
      return;
    component.DeathType = DeathType.Burning;
    component.BecomeRagdoll();
    Rigidbody allRigidbody = component.Ragdoll.AllRigidbodies[0];
    allRigidbody.isKinematic = false;
    allRigidbody.AddForce((allRigidbody.transform.root.position - this.transform.root.position) * this.Strength);
    allRigidbody.AddForce(Vector3.up * 1000f);
  }
}
