// Decompiled with JetBrains decompiler
// Type: ApplicationSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
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
