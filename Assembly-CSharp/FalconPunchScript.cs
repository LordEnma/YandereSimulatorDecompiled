// Decompiled with JetBrains decompiler
// Type: FalconPunchScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FalconPunchScript : MonoBehaviour
{
  public GameObject FalconExplosion;
  public Rigidbody MyRigidbody;
  public Collider MyCollider;
  public float Strength = 100f;
  public float Speed = 100f;
  public bool Destructive;
  public bool IgnoreTime;
  public bool Shipgirl;
  public bool Bancho;
  public bool Falcon;
  public bool Mecha;
  public float TimeLimit = 0.5f;
  public float Timer;

  private void Start()
  {
    if (!this.Mecha)
      return;
    this.MyRigidbody.AddForce(this.transform.forward * this.Speed * 10f);
  }

  private void Update()
  {
    if (!this.IgnoreTime)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > (double) this.TimeLimit)
        this.MyCollider.enabled = false;
    }
    if (!this.Shipgirl)
      return;
    this.MyRigidbody.AddForce(this.transform.forward * this.Speed);
  }

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log((object) "A punch collided with something.");
    if (other.gameObject.layer == 9)
    {
      Debug.Log((object) "A punch collided with something on the Characters layer.");
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if ((Object) component != (Object) null)
      {
        Debug.Log((object) "A punch collided with a student.");
        if (component.StudentID > 1)
        {
          Debug.Log((object) "A punch collided with a student and killed them.");
          Object.Instantiate<GameObject>(this.FalconExplosion, component.transform.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity);
          component.DeathType = DeathType.EasterEgg;
          component.BecomeRagdoll();
          Rigidbody allRigidbody = component.Ragdoll.AllRigidbodies[0];
          allRigidbody.isKinematic = false;
          Vector3 vector3 = allRigidbody.transform.position - component.Yandere.transform.position;
          if (this.Falcon)
            allRigidbody.AddForce(vector3 * this.Strength);
          else if (this.Bancho)
            allRigidbody.AddForce(vector3.x * this.Strength, 5000f, vector3.z * this.Strength);
          else
            allRigidbody.AddForce(vector3.x * this.Strength, 10000f, vector3.z * this.Strength);
        }
      }
    }
    if (!this.Destructive || other.gameObject.layer == 2 || other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 13 || other.gameObject.layer == 17)
      return;
    GameObject gameObject = (GameObject) null;
    StudentScript component1 = other.gameObject.transform.root.GetComponent<StudentScript>();
    if ((Object) component1 != (Object) null)
    {
      if (component1.StudentID <= 1)
        gameObject = component1.gameObject;
    }
    else
      gameObject = other.gameObject;
    if (!((Object) gameObject != (Object) null))
      return;
    Object.Instantiate<GameObject>(this.FalconExplosion, this.transform.position + new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    Object.Destroy((Object) gameObject);
    Object.Destroy((Object) this.gameObject);
  }
}
