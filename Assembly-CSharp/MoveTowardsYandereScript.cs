// Decompiled with JetBrains decompiler
// Type: MoveTowardsYandereScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MoveTowardsYandereScript : MonoBehaviour
{
  public ParticleSystem Smoke;
  public Transform Yandere;
  public float Distance;
  public float Speed;
  public bool Fall;

  private void Start()
  {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
    this.Distance = Vector3.Distance(this.transform.position, this.Yandere.position);
  }

  private void Update()
  {
    if ((double) Vector3.Distance(this.transform.position, this.Yandere.position) > (double) this.Distance * 0.5 && (double) this.transform.position.y < (double) this.Yandere.position.y + 0.5)
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
    this.Speed += Time.deltaTime;
    this.transform.position = Vector3.MoveTowards(this.transform.position, this.Yandere.position, this.Speed * Time.deltaTime);
    if ((double) Vector3.Distance(this.transform.position, this.Yandere.position) != 0.0)
      return;
    this.Smoke.emission.enabled = false;
  }
}
