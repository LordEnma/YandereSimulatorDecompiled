// Decompiled with JetBrains decompiler
// Type: RooftopScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RooftopScript : MonoBehaviour
{
  public GameObject[] DumpPoints;
  public GameObject Railing;
  public GameObject Fence;

  private void Start()
  {
    if (!SchoolGlobals.RoofFence)
      return;
    foreach (GameObject dumpPoint in this.DumpPoints)
      dumpPoint.SetActive(false);
    this.Railing.SetActive(false);
    this.Fence.SetActive(true);
  }
}
