// Decompiled with JetBrains decompiler
// Type: YanvaniaSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class YanvaniaSaveData
{
  public bool draculaDefeated;
  public bool midoriEasterEgg;

  public static YanvaniaSaveData ReadFromGlobals() => new YanvaniaSaveData()
  {
    draculaDefeated = YanvaniaGlobals.DraculaDefeated,
    midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
  };

  public static void WriteToGlobals(YanvaniaSaveData data)
  {
    YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
    YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
  }
}
