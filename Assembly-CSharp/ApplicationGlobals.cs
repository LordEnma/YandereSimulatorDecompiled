// Decompiled with JetBrains decompiler
// Type: ApplicationGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class ApplicationGlobals
{
  private const string Str_VersionNumber = "VersionNumber";

  public static float VersionNumber
  {
    get => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
    set => PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber", value);
  }

  public static void DeleteAll() => Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
}
