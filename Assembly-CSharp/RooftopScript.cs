// Decompiled with JetBrains decompiler
// Type: RooftopScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
