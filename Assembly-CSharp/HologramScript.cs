// Decompiled with JetBrains decompiler
// Type: HologramScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
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
