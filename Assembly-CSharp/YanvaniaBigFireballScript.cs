// Decompiled with JetBrains decompiler
// Type: YanvaniaBigFireballScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaBigFireballScript : MonoBehaviour
{
  public GameObject Explosion;

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.gameObject.name == "YanmontChan"))
      return;
    other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
    Object.Instantiate<GameObject>(this.Explosion, this.transform.position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
