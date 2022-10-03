// Decompiled with JetBrains decompiler
// Type: YanvaniaJarScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaJarScript : MonoBehaviour
{
  public GameObject Explosion;
  public bool Destroyed;
  public AudioClip Break;
  public GameObject Shard;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 19 || this.Destroyed)
      return;
    Object.Instantiate<GameObject>(this.Explosion, this.transform.position + Vector3.up * 0.5f, Quaternion.identity);
    this.Destroyed = true;
    AudioClipPlayer.Play2D(this.Break, this.transform.position);
    for (int index = 1; index < 11; ++index)
      Object.Instantiate<GameObject>(this.Shard, this.transform.position + Vector3.up * Random.Range(0.0f, 1f) + Vector3.right * Random.Range(-0.5f, 0.5f), Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
