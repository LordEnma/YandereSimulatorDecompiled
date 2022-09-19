// Decompiled with JetBrains decompiler
// Type: RooftopScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
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
