// Decompiled with JetBrains decompiler
// Type: RooftopScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
