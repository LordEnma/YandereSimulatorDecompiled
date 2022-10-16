// Decompiled with JetBrains decompiler
// Type: SaveFileGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class SaveFileGlobals
{
  private const string Str_CurrentSaveFile = "CurrentSaveFile";

  public static int CurrentSaveFile
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile", value);
  }

  public static void DeleteAll() => Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
}
