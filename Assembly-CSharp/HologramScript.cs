// Decompiled with JetBrains decompiler
// Type: HologramScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HologramScript : MonoBehaviour
{
  public GameObject[] Holograms;

  public void UpdateHolograms()
  {
    foreach (GameObject hologram in this.Holograms)
      hologram.SetActive(this.TrueFalse());
  }

  private bool TrueFalse() => (double) Random.value >= 0.5;
}
