// Decompiled with JetBrains decompiler
// Type: AccessoryGroupScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
