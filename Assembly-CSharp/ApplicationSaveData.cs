// Decompiled with JetBrains decompiler
// Type: ApplicationSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
