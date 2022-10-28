// Decompiled with JetBrains decompiler
// Type: StealthBushScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
