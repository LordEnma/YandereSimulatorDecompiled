// Decompiled with JetBrains decompiler
// Type: YanvaniaSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
