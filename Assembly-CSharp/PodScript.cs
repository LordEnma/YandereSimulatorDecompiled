// Decompiled with JetBrains decompiler
// Type: PodScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PodScript : MonoBehaviour
{
  public GameObject Projectile;
  public Transform SpawnPoint;
  public Transform PodTarget;
  public Transform AimTarget;
  public float FireRate;
  public float Timer;

  private void Start() => this.Timer = 1f;

  private void LateUpdate()
  {
    this.PodTarget.transform.parent.eulerAngles = new Vector3(0.0f, this.AimTarget.parent.eulerAngles.y, 0.0f);
    this.transform.position = Vector3.Lerp(this.transform.position, this.PodTarget.position, Time.deltaTime * 100f);
    this.transform.rotation = this.AimTarget.parent.rotation;
    this.transform.eulerAngles += new Vector3(-15f, 7.5f, 0.0f);
    if (!Input.GetButton("RB"))
      return;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= (double) this.FireRate)
      return;
    Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, this.transform.rotation);
    this.Timer = 0.0f;
  }
}
