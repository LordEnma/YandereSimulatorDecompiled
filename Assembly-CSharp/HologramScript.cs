// Decompiled with JetBrains decompiler
// Type: HologramScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
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
