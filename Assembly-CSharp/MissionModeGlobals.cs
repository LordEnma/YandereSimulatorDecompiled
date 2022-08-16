// Decompiled with JetBrains decompiler
// Type: MissionModeGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class MissionModeGlobals
{
  private const string Str_MissionCondition = "MissionCondition_";
  private const string Str_MissionDifficulty = "MissionDifficulty";
  private const string Str_MissionMode = "MissionMode";
  private const string Str_MissionRequiredClothing = "MissionRequiredClothing";
  private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";
  private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";
  private const string Str_MissionTarget = "MissionTarget";
  private const string Str_MissionTargetName = "MissionTargetName";
  private const string Str_NemesisDifficulty = "NemesisDifficulty";
  private const string Str_NemesisAggression = "NemesisAggression";
  private const string Str_MultiMission = "MultiMission";

  public static int GetMissionCondition(int id) => PlayerPrefs.GetInt("MissionCondition_" + id.ToString());

  public static void SetMissionCondition(int id, int value)
  {
    string id1 = id.ToString();
    KeysHelper.AddIfMissing("MissionCondition_", id1);
    PlayerPrefs.SetInt("MissionCondition_" + id1, value);
  }

  public static int[] KeysOfMissionCondition() => KeysHelper.GetIntegerKeys("MissionCondition_");

  public static int MissionDifficulty
  {
    get => PlayerPrefs.GetInt(nameof (MissionDifficulty));
    set => PlayerPrefs.SetInt(nameof (MissionDifficulty), value);
  }

  public static bool MissionMode
  {
    get => GlobalsHelper.GetBool(nameof (MissionMode));
    set => GlobalsHelper.SetBool(nameof (MissionMode), value);
  }

  public static bool MultiMission
  {
    get => GlobalsHelper.GetBool(nameof (MultiMission));
    set => GlobalsHelper.SetBool(nameof (MultiMission), value);
  }

  public static int MissionRequiredClothing
  {
    get => PlayerPrefs.GetInt(nameof (MissionRequiredClothing));
    set => PlayerPrefs.SetInt(nameof (MissionRequiredClothing), value);
  }

  public static int MissionRequiredDisposal
  {
    get => PlayerPrefs.GetInt(nameof (MissionRequiredDisposal));
    set => PlayerPrefs.SetInt(nameof (MissionRequiredDisposal), value);
  }

  public static int MissionRequiredWeapon
  {
    get => PlayerPrefs.GetInt(nameof (MissionRequiredWeapon));
    set => PlayerPrefs.SetInt(nameof (MissionRequiredWeapon), value);
  }

  public static int MissionTarget
  {
    get => PlayerPrefs.GetInt(nameof (MissionTarget));
    set => PlayerPrefs.SetInt(nameof (MissionTarget), value);
  }

  public static string MissionTargetName
  {
    get => PlayerPrefs.GetString(nameof (MissionTargetName));
    set => PlayerPrefs.SetString(nameof (MissionTargetName), value);
  }

  public static int NemesisDifficulty
  {
    get => PlayerPrefs.GetInt(nameof (NemesisDifficulty));
    set => PlayerPrefs.SetInt(nameof (NemesisDifficulty), value);
  }

  public static bool NemesisAggression
  {
    get => GlobalsHelper.GetBool(nameof (NemesisAggression));
    set => GlobalsHelper.SetBool(nameof (NemesisAggression), value);
  }

  public static void DeleteAll()
  {
    Globals.DeleteCollection("MissionCondition_", MissionModeGlobals.KeysOfMissionCondition());
    Globals.Delete("MissionDifficulty");
    Globals.Delete("MissionMode");
    Globals.Delete("MissionRequiredClothing");
    Globals.Delete("MissionRequiredDisposal");
    Globals.Delete("MissionRequiredWeapon");
    Globals.Delete("MissionTarget");
    Globals.Delete("MissionTargetName");
    Globals.Delete("NemesisDifficulty");
    Globals.Delete("NemesisAggression");
    Globals.Delete("MultiMission");
  }
}
