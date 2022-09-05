// Decompiled with JetBrains decompiler
// Type: VtuberHairReplacerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class VtuberHairReplacerScript : MonoBehaviour
{
  public GameObject YandereHair;
  public GameObject[] VtuberHair;

  private void Start()
  {
    if (GameGlobals.VtuberID > 0)
    {
      this.YandereHair.SetActive(false);
      this.VtuberHair[GameGlobals.VtuberID].SetActive(true);
    }
    else
      this.VtuberHair[1].SetActive(false);
  }
}
