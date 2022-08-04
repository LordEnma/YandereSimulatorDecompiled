// Decompiled with JetBrains decompiler
// Type: JiggleBone
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class JiggleBone : MonoBehaviour
{
  public bool debugMode = true;
  private Vector3 dynamicPos;
  public Vector3 boneAxis = new Vector3(0.0f, 0.0f, 1f);
  public float targetDistance = 2f;
  public float bStiffness = 0.1f;
  public float bMass = 0.9f;
  public float bDamping = 0.75f;
  public float bGravity = 0.75f;
  private Vector3 force;
  private Vector3 acc;
  private Vector3 vel;
  public bool SquashAndStretch = true;
  public float sideStretch = 0.15f;
  public float frontStretch = 0.2f;

  private void Awake() => this.dynamicPos = this.transform.position + this.transform.TransformDirection(this.boneAxis * this.targetDistance);

  private void LateUpdate()
  {
    this.transform.rotation = new Quaternion();
    Vector3 dir = this.transform.TransformDirection(this.boneAxis * this.targetDistance);
    Vector3 vector3 = this.transform.TransformDirection(new Vector3(0.0f, 1f, 0.0f));
    Vector3 start = this.transform.position + this.transform.TransformDirection(this.boneAxis * this.targetDistance);
    this.force.x = (start.x - this.dynamicPos.x) * this.bStiffness;
    this.acc.x = this.force.x / this.bMass;
    this.vel.x += this.acc.x * (1f - this.bDamping);
    this.force.y = (start.y - this.dynamicPos.y) * this.bStiffness;
    this.force.y -= this.bGravity / 10f;
    this.acc.y = this.force.y / this.bMass;
    this.vel.y += this.acc.y * (1f - this.bDamping);
    this.force.z = (start.z - this.dynamicPos.z) * this.bStiffness;
    this.acc.z = this.force.z / this.bMass;
    this.vel.z += this.acc.z * (1f - this.bDamping);
    this.dynamicPos += this.vel + this.force;
    this.transform.LookAt(this.dynamicPos, vector3);
    if (this.SquashAndStretch)
    {
      float magnitude = (this.dynamicPos - start).magnitude;
      if ((double) this.boneAxis.x != 0.0)
      {
        double frontStretch1 = (double) this.frontStretch;
      }
      else
      {
        double sideStretch1 = (double) this.sideStretch;
      }
      if ((double) this.boneAxis.y != 0.0)
      {
        double frontStretch2 = (double) this.frontStretch;
      }
      else
      {
        double sideStretch2 = (double) this.sideStretch;
      }
      if ((double) this.boneAxis.z != 0.0)
      {
        double frontStretch3 = (double) this.frontStretch;
      }
      else
      {
        double sideStretch3 = (double) this.sideStretch;
      }
    }
    if (!this.debugMode)
      return;
    Debug.DrawRay(this.transform.position, dir, Color.blue);
    Debug.DrawRay(this.transform.position, vector3, Color.green);
    Debug.DrawRay(start, Vector3.up * 0.2f, Color.yellow);
    Debug.DrawRay(this.dynamicPos, Vector3.up * 0.2f, Color.red);
  }
}
