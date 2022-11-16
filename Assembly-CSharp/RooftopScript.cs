// Decompiled with JetBrains decompiler
// Type: RooftopScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
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
