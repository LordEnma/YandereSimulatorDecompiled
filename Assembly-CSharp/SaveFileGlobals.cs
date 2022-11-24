// Decompiled with JetBrains decompiler
// Type: SaveFileGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
