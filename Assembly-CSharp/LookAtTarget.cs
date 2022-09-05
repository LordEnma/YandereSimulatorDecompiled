// Decompiled with JetBrains decompiler
// Type: LookAtTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Look At Target")]
public class LookAtTarget : MonoBehaviour
{
  public int level;
  public Transform target;
  public float speed = 8f;
  private Transform mTrans;

  private void Start() => this.mTrans = this.transform;

  private void LateUpdate()
  {
    if (!((Object) this.target != (Object) null))
      return;
    Vector3 forward = this.target.position - this.mTrans.position;
    if ((double) forward.magnitude <= 1.0 / 1000.0)
      return;
    this.mTrans.rotation = Quaternion.Slerp(this.mTrans.rotation, Quaternion.LookRotation(forward), Mathf.Clamp01(this.speed * Time.deltaTime));
  }
}
