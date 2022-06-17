// Decompiled with JetBrains decompiler
// Type: GlobalKnifeArrayScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
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
