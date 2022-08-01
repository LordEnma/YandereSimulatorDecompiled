// Decompiled with JetBrains decompiler
// Type: YanvaniaCandlestickScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaCandlestickScript : MonoBehaviour
{
  public GameObject DestroyedCandlestick;
  public bool Destroyed;
  public AudioClip Break;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 19 || this.Destroyed)
      return;
    Object.Instantiate<GameObject>(this.DestroyedCandlestick, this.transform.position, Quaternion.identity).transform.localScale = this.transform.localScale;
    this.Destroyed = true;
    AudioClipPlayer.Play2D(this.Break, this.transform.position);
    Object.Destroy((Object) this.gameObject);
  }
}
