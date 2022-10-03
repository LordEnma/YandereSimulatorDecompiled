// Decompiled with JetBrains decompiler
// Type: StealthBushScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StealthBushScript : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
    if (!((Object) component != (Object) null))
      return;
    component.Hidden = true;
  }

  private void OnTriggerExit(Collider other)
  {
    StalkerYandereScript component = other.gameObject.GetComponent<StalkerYandereScript>();
    if (!((Object) component != (Object) null))
      return;
    component.Hidden = false;
  }
}
