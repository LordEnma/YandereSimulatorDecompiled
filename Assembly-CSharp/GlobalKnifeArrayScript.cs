// Decompiled with JetBrains decompiler
// Type: GlobalKnifeArrayScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
