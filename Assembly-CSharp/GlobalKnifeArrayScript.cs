// Decompiled with JetBrains decompiler
// Type: GlobalKnifeArrayScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
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
