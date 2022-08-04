// Decompiled with JetBrains decompiler
// Type: DatingGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class DatingGlobals
{
  private const string Str_Affection = "Affection";
  private const string Str_AffectionLevel = "AffectionLevel";
  private const string Str_ComplimentGiven = "ComplimentGiven_";
  private const string Str_SuitorCheck = "SuitorCheck_";
  private const string Str_SuitorProgress = "SuitorProgress";
  private const string Str_SuitorTrait = "SuitorTrait_";
  private const string Str_TopicDiscussed = "TopicDiscussed_";
  private const string Str_TraitDemonstrated = "TraitDemonstrated_";
  private const string Str_RivalSabotaged = "RivalSabotaged";

  public static float Affection
  {
    get => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Affection");
    set => PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Affection", value);
  }

  public static float AffectionLevel
  {
    get => PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_AffectionLevel");
    set => PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_AffectionLevel", value);
  }

  public static bool GetComplimentGiven(int complimentID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());

  public static void SetComplimentGiven(int complimentID, bool value)
  {
    string id = complimentID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + id, value);
  }

  public static int[] KeysOfComplimentGiven() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");

  public static bool GetSuitorCheck(int checkID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());

  public static void SetSuitorCheck(int checkID, bool value)
  {
    string id = checkID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + id, value);
  }

  public static int[] KeysOfSuitorCheck() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");

  public static int SuitorProgress
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorProgress");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorProgress", value);
  }

  public static int GetSuitorTrait(int traitID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());

  public static void SetSuitorTrait(int traitID, int value)
  {
    string id = traitID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + id, value);
  }

  public static int[] KeysOfSuitorTrait() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");

  public static bool GetTopicDiscussed(int topicID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());

  public static void SetTopicDiscussed(int topicID, bool value)
  {
    string id = topicID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + id, value);
  }

  public static int[] KeysOfTopicDiscussed() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");

  public static int GetTraitDemonstrated(int traitID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());

  public static void SetTraitDemonstrated(int traitID, int value)
  {
    string id = traitID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + id, value);
  }

  public static int[] KeysOfTraitDemonstrated() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");

  public static int RivalSabotaged
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalSabotaged");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalSabotaged", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Affection");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AffectionLevel");
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", DatingGlobals.KeysOfComplimentGiven());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", DatingGlobals.KeysOfSuitorCheck());
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SuitorProgress");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RivalSabotaged");
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", DatingGlobals.KeysOfSuitorTrait());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", DatingGlobals.KeysOfTopicDiscussed());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", DatingGlobals.KeysOfTraitDemonstrated());
  }
}
