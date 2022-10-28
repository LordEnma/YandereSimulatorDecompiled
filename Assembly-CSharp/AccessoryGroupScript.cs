// Decompiled with JetBrains decompiler
// Type: AccessoryGroupScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AccessoryGroupScript : MonoBehaviour
{
  public GameObject[] Parts;

  public void SetPartsActive(bool active)
  {
    foreach (GameObject part in this.Parts)
      part.SetActive(active);
  }
}
