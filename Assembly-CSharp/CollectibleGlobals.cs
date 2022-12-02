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

	public static int MatchmakingGifts
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_MatchmakingGifts");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_MatchmakingGifts", value);
		}
	}

	public static int SenpaiGifts
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SenpaiGifts");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SenpaiGifts", value);
		}
	}

	public static int HorrorMangaProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_HorrorMangaProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_HorrorMangaProgress", value);
		}
	}

	public static int RomanceMangaProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_RomanceMangaProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_RomanceMangaProgress", value);
		}
	}

	public static int EnlightenedMangaProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_EnlightenedMangaProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_EnlightenedMangaProgress", value);
		}
	}

	public static bool GetHeadmasterTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_HeadmasterTapeCollected_" + tapeID);
	}

	public static void SetHeadmasterTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_HeadmasterTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_HeadmasterTapeCollected_" + text, value);
	}

	public static bool GetHeadmasterTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_HeadmasterTapeListened_" + tapeID);
	}

	public static void SetHeadmasterTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_HeadmasterTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_HeadmasterTapeListened_" + text, value);
	}

	public static int[] KeysOfHeadmasterTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_HeadmasterTapeCollected_");
	}

	public static int[] KeysOfHeadmasterTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_HeadmasterTapeListened_");
	}

	public static bool GetBasementTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_BasementTapeCollected_" + tapeID);
	}

	public static void SetBasementTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_BasementTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_BasementTapeCollected_" + text, value);
	}

	public static int[] KeysOfBasementTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_BasementTapeCollected_");
	}

	public static bool GetBasementTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_BasementTapeListened_" + tapeID);
	}

	public static void SetBasementTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_BasementTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_BasementTapeListened_" + text, value);
	}

	public static int[] KeysOfBasementTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_BasementTapeListened_");
	}

	public static bool GetMangaCollected(int mangaID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_MangaCollected_" + mangaID);
	}

	public static void SetMangaCollected(int mangaID, bool value)
	{
		string text = mangaID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_MangaCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_MangaCollected_" + text, value);
	}

	public static bool GetGiftPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_GiftPurchased_" + giftID);
	}

	public static void SetGiftPurchased(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_GiftPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_GiftPurchased_" + text, value);
	}

	public static bool GetGiftGiven(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_GiftGiven_" + giftID);
	}

	public static void SetGiftGiven(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_GiftGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_GiftGiven_" + text, value);
	}

	public static bool GetPantyPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_PantyPurchased_" + giftID);
	}

	public static void SetPantyPurchased(int pantyID, bool value)
	{
		string text = pantyID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_PantyPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_PantyPurchased_" + text, value);
	}

	public static bool GetAdvicePurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_AdvicePurchased_" + giftID);
	}

	public static void SetAdvicePurchased(int adviceID, bool value)
	{
		string text = adviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_AdvicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_AdvicePurchased_" + text, value);
	}

	public static int[] KeysOfMangaCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_MangaCollected_");
	}

	public static int[] KeysOfGiftPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_GiftPurchased_");
	}

	public static int[] KeysOfGiftGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_GiftGiven_");
	}

	public static int[] KeysOfPantyPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_PantyPurchased_");
	}

	public static int[] KeysOfAdvicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_AdvicePurchased_");
	}

	public static bool GetTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_TapeCollected_" + tapeID);
	}

	public static void SetTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_TapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_TapeCollected_" + text, value);
	}

	public static int[] KeysOfTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_TapeCollected_");
	}

	public static bool GetTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_TapeListened_" + tapeID);
	}

	public static void SetTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_TapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_TapeListened_" + text, value);
	}

	public static int[] KeysOfTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_TapeListened_");
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_HeadmasterTapeCollected_", KeysOfHeadmasterTapeCollected());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_HeadmasterTapeListened_", KeysOfHeadmasterTapeListened());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_BasementTapeCollected_", KeysOfBasementTapeCollected());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_BasementTapeListened_", KeysOfBasementTapeListened());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_MangaCollected_", KeysOfMangaCollected());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_AdvicePurchased_", KeysOfAdvicePurchased());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_PantyPurchased_", KeysOfPantyPurchased());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_GiftPurchased_", KeysOfGiftPurchased());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_GiftGiven_", KeysOfGiftGiven());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_TapeCollected_", KeysOfTapeCollected());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_TapeListened_", KeysOfTapeListened());
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MatchmakingGifts");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiGifts");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_HorrorMangaProgress");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_RomanceMangaProgress");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_EnlightenedMangaProgress");
	}
}
