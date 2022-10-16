// Decompiled with JetBrains decompiler
// Type: HologramScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
