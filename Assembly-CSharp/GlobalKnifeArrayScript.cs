// Decompiled with JetBrains decompiler
// Type: GlobalKnifeArrayScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GlobalKnifeArrayScript : MonoBehaviour
{
  public TimeStopKnifeScript[] Knives;
  public int ID;

  public void ActivateKnives()
  {
    foreach (TimeStopKnifeScript knife in this.Knives)
    {
      if ((Object) knife != (Object) null)
        knife.Unfreeze = true;
    }
    this.ID = 0;
  }
}
