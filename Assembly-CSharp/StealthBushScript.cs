// Decompiled with JetBrains decompiler
// Type: StealthBushScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
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
