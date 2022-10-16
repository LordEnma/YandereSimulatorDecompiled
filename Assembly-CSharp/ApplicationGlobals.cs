// Decompiled with JetBrains decompiler
// Type: ApplicationGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
