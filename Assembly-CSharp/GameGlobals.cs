// Decompiled with JetBrains decompiler
// Type: GameGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class GameGlobals
{
  private const string Str_Profile = "Profile";
  private const string Str_MostRecentSlot = "MostRecentSlot";
  private const string Str_LoveSick = "LoveSick";
  private const string Str_MasksBanned = "MasksBanned";
  private const string Str_Paranormal = "Paranormal";
  private const string Str_EasyMode = "EasyMode";
  private const string Str_HardMode = "HardMode";
  private const string Str_EmptyDemon = "EmptyDemon";
  private const string Str_CensorBlood = "CensorBlood";
  private const string Str_CensorPanties = "CensorPanties";
  private const string Str_CensorKillingAnims = "CensorKillingAnims";
  private const string Str_SpareUniform = "SpareUniform";
  private const string Str_BlondeHair = "BlondeHair";
  private const string Str_SenpaiMourning = "SenpaiMourning";
  private const string Str_RivalEliminationID = "RivalEliminationID";
  private const string Str_SpecificEliminationID = "SpecificEliminationID";
  private const string Str_NonlethalElimination = "NonlethalElimination";
  private const string Str_ReputationsInitialized = "ReputationsInitialized";
  private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";
  private const string Str_AlphabetMode = "AlphabetMode";
  private const string Str_PoliceYesterday = "PoliceYesterday";
  private const string Str_DarkEnding = "DarkEnding";
  private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";
  private const string Str_TransitionToPostCredits = "TransitionToPostCredits";
  private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";
  private const string Str_InformedAboutSkipping = "InformedAboutSkipping";
  private const string Str_RingStolen = "RingStolen";
  private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";
  private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";
  private const string Str_EightiesCutsceneID = "EightiesCutsceneID";
  private const string Str_EightiesTutorial = "EightiesTutorial";
  private const string Str_Eighties = "Eighties";
  private const string Str_YakuzaPhase = "YakuzaPhase";
  private const string Str_MetBarber = "MetBarber";
  private const string Str_Debug = "Debug";
  private const string Str_RivalEliminations = "RivalEliminations";
  private const string Str_SpecificEliminations = "SpecificEliminations";
  private const string Str_IntroducedAbduction = "IntroducedAbduction";
  private const string Str_IntroducedRansom = "IntroducedRansom";
  private const string Str_TrueEnding = "TrueEnding";
  private const string Str_JustKidnapped = "JustKidnapped";
  private const string Str_ShowAbduction = "ShowAbduction";
  private const string Str_AbductionTarget = "AbductionTarget";
  private const string Str_CameFromTitleScreen = "CameFromTitleScreen";
  private const string Str_VtuberID = "VtuberID";
  private const string Str_ItemRemoved = "ItemRemoved";

  public static int Profile
  {
    get => PlayerPrefs.GetInt(nameof (Profile));
    set => PlayerPrefs.SetInt(nameof (Profile), value);
  }

  public static int MostRecentSlot
  {
    get => PlayerPrefs.GetInt(nameof (MostRecentSlot));
    set => PlayerPrefs.SetInt(nameof (MostRecentSlot), value);
  }

  public static bool LoveSick
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LoveSick");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LoveSick", value);
  }

  public static bool MasksBanned
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MasksBanned");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MasksBanned", value);
  }

  public static bool Paranormal
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Paranormal");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Paranormal", value);
  }

  public static bool EasyMode
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EasyMode");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EasyMode", value);
  }

  public static bool HardMode
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HardMode");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HardMode", value);
  }

  public static bool EmptyDemon
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmptyDemon");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmptyDemon", value);
  }

  public static bool CensorBlood
  {
    get => GlobalsHelper.GetBool("Profile__CensorBlood");
    set => GlobalsHelper.SetBool("Profile__CensorBlood", value);
  }

  public static bool CensorPanties
  {
    get => GlobalsHelper.GetBool("Profile__CensorPanties");
    set => GlobalsHelper.SetBool("Profile__CensorPanties", value);
  }

  public static bool CensorKillingAnims
  {
    get => GlobalsHelper.GetBool("Profile__CensorKillingAnims");
    set => GlobalsHelper.SetBool("Profile__CensorKillingAnims", value);
  }

  public static bool SpareUniform
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SpareUniform");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SpareUniform", value);
  }

  public static bool BlondeHair
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BlondeHair");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BlondeHair", value);
  }

  public static bool SenpaiMourning
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiMourning");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiMourning", value);
  }

  public static int RivalEliminationID
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminationID");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminationID", value);
  }

  public static int SpecificEliminationID
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminationID");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminationID", value);
  }

  public static bool NonlethalElimination
  {
    get => GlobalsHelper.GetBool(nameof (NonlethalElimination));
    set => GlobalsHelper.SetBool(nameof (NonlethalElimination), value);
  }

  public static bool ReputationsInitialized
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReputationsInitialized");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReputationsInitialized", value);
  }

  public static bool AnswerSheetUnavailable
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AnswerSheetUnavailable");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AnswerSheetUnavailable", value);
  }

  public static bool AlphabetMode
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AlphabetMode");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AlphabetMode", value);
  }

  public static bool PoliceYesterday
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PoliceYesterday");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PoliceYesterday", value);
  }

  public static bool DarkEnding
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DarkEnding");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DarkEnding", value);
  }

  public static bool SenpaiSawOsanaCorpse
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSawOsanaCorpse");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSawOsanaCorpse", value);
  }

  public static bool TransitionToPostCredits
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TransitionToPostCredits");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TransitionToPostCredits", value);
  }

  public static bool PlayerHasBeatenDemo
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PlayerHasBeatenDemo");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PlayerHasBeatenDemo", value);
  }

  public static bool InformedAboutSkipping
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_InformedAboutSkipping");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_InformedAboutSkipping", value);
  }

  public static bool RingStolen
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RingStolen");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RingStolen", value);
  }

  public static int BeatEmUpDifficulty
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpDifficulty");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpDifficulty", value);
  }

  public static bool BeatEmUpSuccess
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpSuccess");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpSuccess", value);
  }

  public static int EightiesCutsceneID
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_EightiesCutsceneID");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_EightiesCutsceneID", value);
  }

  public static bool EightiesTutorial
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EightiesTutorial");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EightiesTutorial", value);
  }

  public static bool Eighties
  {
    get => GlobalsHelper.GetBool(nameof (Eighties));
    set => GlobalsHelper.SetBool(nameof (Eighties), value);
  }

  public static int YakuzaPhase
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_YakuzaPhase");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_YakuzaPhase", value);
  }

  public static bool MetBarber
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MetBarber");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MetBarber", value);
  }

  public static bool IntroducedAbduction
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedAbduction");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedAbduction", value);
  }

  public static bool IntroducedRansom
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedRansom");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedRansom", value);
  }

  public static bool Debug
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Debug");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Debug", value);
  }

  public static int GetRivalEliminations(int elimID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + elimID.ToString());

  public static void SetRivalEliminations(int elimID, int value)
  {
    string id = elimID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + id, value);
  }

  public static int[] KeysOfRivalEliminations() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations");

  public static int GetSpecificEliminations(int elimID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + elimID.ToString());

  public static void SetSpecificEliminations(int elimID, int value)
  {
    string id = elimID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + id, value);
  }

  public static int[] KeysOfSpecificEliminations() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations");

  public static bool TrueEnding
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TrueEnding");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TrueEnding", value);
  }

  public static bool JustKidnapped
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_JustKidnapped");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_JustKidnapped", value);
  }

  public static bool ShowAbduction
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShowAbduction");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShowAbduction", value);
  }

  public static int AbductionTarget
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_AbductionTarget");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_AbductionTarget", value);
  }

  public static bool CameFromTitleScreen
  {
    get => GlobalsHelper.GetBool(nameof (CameFromTitleScreen));
    set => GlobalsHelper.SetBool(nameof (CameFromTitleScreen), value);
  }

  public static int VtuberID
  {
    get => PlayerPrefs.GetInt(nameof (VtuberID));
    set => PlayerPrefs.SetInt(nameof (VtuberID), value);
  }

  public static int GetItemRemoved(int itemID) => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ItemRemoved" + itemID.ToString());

  public static void SetItemRemoved(int itemID, int value)
  {
    string id = itemID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ItemRemoved", id);
    PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ItemRemoved" + id, value);
  }

  public static int[] KeysOfItemRemoved() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ItemRemoved");

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LoveSick");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MasksBanned");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Paranormal");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EasyMode");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HardMode");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EmptyDemon");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CensorBlood");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CensorPanties");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CensorKillingAnims");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SpareUniform");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BlondeHair");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiMourning");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminationID");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminationID");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_NonlethalElimination");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReputationsInitialized");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AnswerSheetUnavailable");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AlphabetMode");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PoliceYesterday");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DarkEnding");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MostRecentSlot");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSawOsanaCorpse");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TransitionToPostCredits");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PlayerHasBeatenDemo");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InformedAboutSkipping");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RingStolen");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpDifficulty");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpSuccess");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_YakuzaPhase");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MetBarber");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Debug");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedAbduction");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedRansom");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EightiesCutsceneID");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EightiesTutorial");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Eighties");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TrueEnding");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JustKidnapped");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ShowAbduction");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AbductionTarget");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CameFromTitleScreen");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VtuberID");
    for (int elimID = 1; elimID < 11; ++elimID)
      GameGlobals.SetSpecificEliminations(elimID, 0);
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", GameGlobals.KeysOfRivalEliminations());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", GameGlobals.KeysOfSpecificEliminations());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_ItemRemoved", GameGlobals.KeysOfItemRemoved());
  }
}
