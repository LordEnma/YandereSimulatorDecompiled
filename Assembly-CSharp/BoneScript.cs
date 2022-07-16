// Decompiled with JetBrains decompiler
// Type: BoneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BoneScript : MonoBehaviour
{
  public AudioSource MyAudio;
  public float Height;
  public float Origin;
  public bool Drop;

  private void Start()
  {
    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, Random.Range(0.0f, 360f), this.transform.eulerAngles.z);
    this.Origin = this.transform.position.y;
    this.MyAudio.pitch = Random.Range(0.9f, 1.1f);
  }

  private void Update()
  {
    if (!this.Drop)
    {
      if ((double) this.transform.position.y < (double) this.Origin + 2.0 - 9.99999974737875E-05)
        this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(this.transform.position.y, this.Origin + 2f, Time.deltaTime * 10f), this.transform.position.z);
      else
        this.Drop = true;
    }
    else
    {
      this.Height -= Time.deltaTime;
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + this.Height, this.transform.position.z);
      if ((double) this.transform.position.y >= (double) this.Origin - 2.15499997138977)
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null))
      return;
    component.DeathType = DeathType.EasterEgg;
    component.BecomeRagdoll();
    Rigidbody allRigidbody = component.Ragdoll.AllRigidbodies[0];
    allRigidbody.isKinematic = false;
    allRigidbody.AddForce(this.transform.up);
  }
}
