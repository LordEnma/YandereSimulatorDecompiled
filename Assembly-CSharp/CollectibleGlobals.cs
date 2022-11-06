// Decompiled with JetBrains decompiler
// Type: CollectibleGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class CollectibleGlobals
{
  private const string Str_HeadmasterTapeCollected = "HeadmasterTapeCollected_";
  private const string Str_HeadmasterTapeListened = "HeadmasterTapeListened_";
  private const string Str_BasementTapeCollected = "BasementTapeCollected_";
  private const string Str_BasementTapeListened = "BasementTapeListened_";
  private const string Str_MangaCollected = "MangaCollected_";
  private const string Str_HorrorMangaProgress = "HorrorMangaProgress";
  private const string Str_RomanceMangaProgress = "RomanceMangaProgress";
  private const string Str_EnlightenedMangaProgress = "EnlightenedMangaProgress";
  private const string Str_GiftPurchased = "GiftPurchased_";
  private const string Str_GiftGiven = "GiftGiven_";
  private const string Str_MatchmakingGifts = "MatchmakingGifts";
  private const string Str_SenpaiGifts = "SenpaiGifts";
  private const string Str_PantyPurchased = "PantyPurchased_";
  private const string Str_AdvicePurchased = "AdvicePurchased_";
  private const string Str_TapeCollected = "TapeCollected_";
  private const string Str_TapeListened = "TapeListened_";

  public static bool GetHeadmasterTapeCollected(int tapeID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + tapeID.ToString());

  public static void SetHeadmasterTapeCollected(int tapeID, bool value)
  {
    string id = tapeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + id, value);
  }

  public static bool GetHeadmasterTapeListened(int tapeID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + tapeID.ToString());

  public static void SetHeadmasterTapeListened(int tapeID, bool value)
  {
    string id = tapeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + id, value);
  }

  public static int[] KeysOfHeadmasterTapeCollected() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_");

  public static int[] KeysOfHeadmasterTapeListened() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_");

  public static bool GetBasementTapeCollected(int tapeID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + tapeID.ToString());

  public static void SetBasementTapeCollected(int tapeID, bool value)
  {
    string id = tapeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + id, value);
  }

  public static int[] KeysOfBasementTapeCollected() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_");

  public static bool GetBasementTapeListened(int tapeID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + tapeID.ToString());

  public static void SetBasementTapeListened(int tapeID, bool value)
  {
    string id = tapeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + id, value);
  }

  public static int[] KeysOfBasementTapeListened() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_");

  public static bool GetMangaCollected(int mangaID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + mangaID.ToString());

  public static void SetMangaCollected(int mangaID, bool value)
  {
    string id = mangaID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + id, value);
  }

  public static bool GetGiftPurchased(int giftID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + giftID.ToString());

  public static void SetGiftPurchased(int giftID, bool value)
  {
    string id = giftID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + id, value);
  }

  public static bool GetGiftGiven(int giftID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + giftID.ToString());

  public static void SetGiftGiven(int giftID, bool value)
  {
    string id = giftID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + id, value);
  }

  public static int MatchmakingGifts
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MatchmakingGifts");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MatchmakingGifts", value);
  }

  public static int SenpaiGifts
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiGifts");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiGifts", value);
  }

  public static bool GetPantyPurchased(int giftID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + giftID.ToString());

  public static void SetPantyPurchased(int pantyID, bool value)
  {
    string id = pantyID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + id, value);
  }

  public static bool GetAdvicePurchased(int giftID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + giftID.ToString());

  public static void SetAdvicePurchased(int adviceID, bool value)
  {
    string id = adviceID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + id, value);
  }

  public static int[] KeysOfMangaCollected() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_");

  public static int[] KeysOfGiftPurchased() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_");

  public static int[] KeysOfGiftGiven() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_");

  public static int[] KeysOfPantyPurchased() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_");

  public static int[] KeysOfAdvicePurchased() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_");

  public static bool GetTapeCollected(int tapeID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + tapeID.ToString());

  public static void SetTapeCollected(int tapeID, bool value)
  {
    string id = tapeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + id, value);
  }

  public static int[] KeysOfTapeCollected() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_");

  public static bool GetTapeListened(int tapeID) => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + tapeID.ToString());

  public static void SetTapeListened(int tapeID, bool value)
  {
    string id = tapeID.ToString();
    KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_", id);
    GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + id, value);
  }

  public static int[] KeysOfTapeListened() => KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_");

  public static int HorrorMangaProgress
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_HorrorMangaProgress");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_HorrorMangaProgress", value);
  }

  public static int RomanceMangaProgress
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RomanceMangaProgress");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RomanceMangaProgress", value);
  }

  public static int EnlightenedMangaProgress
  {
    get => PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenedMangaProgress");
    set => PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenedMangaProgress", value);
  }

  public static void DeleteAll()
  {
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_", CollectibleGlobals.KeysOfHeadmasterTapeCollected());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_", CollectibleGlobals.KeysOfHeadmasterTapeListened());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_", CollectibleGlobals.KeysOfBasementTapeCollected());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_", CollectibleGlobals.KeysOfBasementTapeListened());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_", CollectibleGlobals.KeysOfMangaCollected());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_", CollectibleGlobals.KeysOfAdvicePurchased());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_", CollectibleGlobals.KeysOfPantyPurchased());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_", CollectibleGlobals.KeysOfGiftPurchased());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_", CollectibleGlobals.KeysOfGiftGiven());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_", CollectibleGlobals.KeysOfTapeCollected());
    Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_", CollectibleGlobals.KeysOfTapeListened());
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MatchmakingGifts");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiGifts");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HorrorMangaProgress");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RomanceMangaProgress");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenedMangaProgress");
  }
}
