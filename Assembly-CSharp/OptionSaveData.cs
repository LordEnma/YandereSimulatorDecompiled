// Decompiled with JetBrains decompiler
// Type: OptionSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class OptionSaveData
{
  public bool disableBloom;
  public int disableFarAnimations = 5;
  public bool disableOutlines;
  public bool disablePostAliasing;
  public bool enableShadows;
  public int drawDistance;
  public int drawDistanceLimit;
  public bool fog;
  public int fpsIndex;
  public bool highPopulation;
  public int lowDetailStudents;
  public int particleCount;

  public static OptionSaveData ReadFromGlobals() => new OptionSaveData()
  {
    disableBloom = OptionGlobals.DisableBloom,
    disableFarAnimations = OptionGlobals.DisableFarAnimations,
    disableOutlines = OptionGlobals.DisableOutlines,
    disablePostAliasing = OptionGlobals.DisablePostAliasing,
    enableShadows = OptionGlobals.EnableShadows,
    drawDistance = OptionGlobals.DrawDistance,
    drawDistanceLimit = OptionGlobals.DrawDistanceLimit,
    fog = OptionGlobals.Fog,
    fpsIndex = OptionGlobals.FPSIndex,
    highPopulation = OptionGlobals.HighPopulation,
    lowDetailStudents = OptionGlobals.LowDetailStudents,
    particleCount = OptionGlobals.ParticleCount
  };

  public static void WriteToGlobals(OptionSaveData data)
  {
    OptionGlobals.DisableBloom = data.disableBloom;
    OptionGlobals.DisableFarAnimations = data.disableFarAnimations;
    OptionGlobals.DisableOutlines = data.disableOutlines;
    OptionGlobals.DisablePostAliasing = data.disablePostAliasing;
    OptionGlobals.EnableShadows = data.enableShadows;
    OptionGlobals.DrawDistance = data.drawDistance;
    OptionGlobals.DrawDistanceLimit = data.drawDistanceLimit;
    OptionGlobals.Fog = data.fog;
    OptionGlobals.FPSIndex = data.fpsIndex;
    OptionGlobals.HighPopulation = data.highPopulation;
    OptionGlobals.LowDetailStudents = data.lowDetailStudents;
    OptionGlobals.ParticleCount = data.particleCount;
  }
}
