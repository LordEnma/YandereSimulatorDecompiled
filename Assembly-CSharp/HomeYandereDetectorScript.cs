// Decompiled with JetBrains decompiler
// Type: HomeYandereDetectorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
