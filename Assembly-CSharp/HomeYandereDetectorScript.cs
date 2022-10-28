// Decompiled with JetBrains decompiler
// Type: HomeYandereDetectorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeYandereDetectorScript : MonoBehaviour
{
  public bool YandereDetected;

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.tag == "Player"))
      return;
    this.YandereDetected = true;
  }

  private void OnTriggerExit(Collider other)
  {
    if (!(other.tag == "Player"))
      return;
    this.YandereDetected = false;
  }
}
