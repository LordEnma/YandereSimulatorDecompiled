// Decompiled with JetBrains decompiler
// Type: YanvaniaCandlestickScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
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
