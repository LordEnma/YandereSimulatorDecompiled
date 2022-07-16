// Decompiled with JetBrains decompiler
// Type: ApplicationSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class ApplicationSaveData
{
  public float versionNumber;

  public static ApplicationSaveData ReadFromGlobals() => new ApplicationSaveData()
  {
    versionNumber = ApplicationGlobals.VersionNumber
  };

  public static void WriteToGlobals(ApplicationSaveData data) => ApplicationGlobals.VersionNumber = data.versionNumber;
}
