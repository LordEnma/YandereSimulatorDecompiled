using System;
using UnityEngine;

// Token: 0x020002EB RID: 747
public static class CollectibleGlobals
{
	// Token: 0x0600154B RID: 5451 RVA: 0x000D85B4 File Offset: 0x000D67B4
	public static bool GetHeadmasterTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + tapeID.ToString());
	}

	// Token: 0x0600154C RID: 5452 RVA: 0x000D85EC File Offset: 0x000D67EC
	public static void SetHeadmasterTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + text, value);
	}

	// Token: 0x0600154D RID: 5453 RVA: 0x000D8648 File Offset: 0x000D6848
	public static bool GetHeadmasterTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + tapeID.ToString());
	}

	// Token: 0x0600154E RID: 5454 RVA: 0x000D8680 File Offset: 0x000D6880
	public static void SetHeadmasterTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + text, value);
	}

	// Token: 0x0600154F RID: 5455 RVA: 0x000D86DC File Offset: 0x000D68DC
	public static int[] KeysOfHeadmasterTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_");
	}

	// Token: 0x06001550 RID: 5456 RVA: 0x000D870C File Offset: 0x000D690C
	public static int[] KeysOfHeadmasterTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_");
	}

	// Token: 0x06001551 RID: 5457 RVA: 0x000D873C File Offset: 0x000D693C
	public static bool GetBasementTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + tapeID.ToString());
	}

	// Token: 0x06001552 RID: 5458 RVA: 0x000D8774 File Offset: 0x000D6974
	public static void SetBasementTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + text, value);
	}

	// Token: 0x06001553 RID: 5459 RVA: 0x000D87D0 File Offset: 0x000D69D0
	public static int[] KeysOfBasementTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_");
	}

	// Token: 0x06001554 RID: 5460 RVA: 0x000D8800 File Offset: 0x000D6A00
	public static bool GetBasementTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + tapeID.ToString());
	}

	// Token: 0x06001555 RID: 5461 RVA: 0x000D8838 File Offset: 0x000D6A38
	public static void SetBasementTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + text, value);
	}

	// Token: 0x06001556 RID: 5462 RVA: 0x000D8894 File Offset: 0x000D6A94
	public static int[] KeysOfBasementTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_");
	}

	// Token: 0x06001557 RID: 5463 RVA: 0x000D88C4 File Offset: 0x000D6AC4
	public static bool GetMangaCollected(int mangaID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + mangaID.ToString());
	}

	// Token: 0x06001558 RID: 5464 RVA: 0x000D88FC File Offset: 0x000D6AFC
	public static void SetMangaCollected(int mangaID, bool value)
	{
		string text = mangaID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + text, value);
	}

	// Token: 0x06001559 RID: 5465 RVA: 0x000D8958 File Offset: 0x000D6B58
	public static bool GetGiftPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + giftID.ToString());
	}

	// Token: 0x0600155A RID: 5466 RVA: 0x000D8990 File Offset: 0x000D6B90
	public static void SetGiftPurchased(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + text, value);
	}

	// Token: 0x0600155B RID: 5467 RVA: 0x000D89EC File Offset: 0x000D6BEC
	public static bool GetGiftGiven(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + giftID.ToString());
	}

	// Token: 0x0600155C RID: 5468 RVA: 0x000D8A24 File Offset: 0x000D6C24
	public static void SetGiftGiven(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + text, value);
	}

	// Token: 0x17000381 RID: 897
	// (get) Token: 0x0600155D RID: 5469 RVA: 0x000D8A80 File Offset: 0x000D6C80
	// (set) Token: 0x0600155E RID: 5470 RVA: 0x000D8AB0 File Offset: 0x000D6CB0
	public static int MatchmakingGifts
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MatchmakingGifts");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MatchmakingGifts", value);
		}
	}

	// Token: 0x17000382 RID: 898
	// (get) Token: 0x0600155F RID: 5471 RVA: 0x000D8AE0 File Offset: 0x000D6CE0
	// (set) Token: 0x06001560 RID: 5472 RVA: 0x000D8B10 File Offset: 0x000D6D10
	public static int SenpaiGifts
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiGifts");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiGifts", value);
		}
	}

	// Token: 0x06001561 RID: 5473 RVA: 0x000D8B40 File Offset: 0x000D6D40
	public static bool GetPantyPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + giftID.ToString());
	}

	// Token: 0x06001562 RID: 5474 RVA: 0x000D8B78 File Offset: 0x000D6D78
	public static void SetPantyPurchased(int pantyID, bool value)
	{
		string text = pantyID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + text, value);
	}

	// Token: 0x06001563 RID: 5475 RVA: 0x000D8BD4 File Offset: 0x000D6DD4
	public static bool GetAdvicePurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + giftID.ToString());
	}

	// Token: 0x06001564 RID: 5476 RVA: 0x000D8C0C File Offset: 0x000D6E0C
	public static void SetAdvicePurchased(int adviceID, bool value)
	{
		string text = adviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + text, value);
	}

	// Token: 0x06001565 RID: 5477 RVA: 0x000D8C68 File Offset: 0x000D6E68
	public static int[] KeysOfMangaCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_");
	}

	// Token: 0x06001566 RID: 5478 RVA: 0x000D8C98 File Offset: 0x000D6E98
	public static int[] KeysOfGiftPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_");
	}

	// Token: 0x06001567 RID: 5479 RVA: 0x000D8CC8 File Offset: 0x000D6EC8
	public static int[] KeysOfGiftGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_");
	}

	// Token: 0x06001568 RID: 5480 RVA: 0x000D8CF8 File Offset: 0x000D6EF8
	public static int[] KeysOfPantyPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_");
	}

	// Token: 0x06001569 RID: 5481 RVA: 0x000D8D28 File Offset: 0x000D6F28
	public static int[] KeysOfAdvicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_");
	}

	// Token: 0x0600156A RID: 5482 RVA: 0x000D8D58 File Offset: 0x000D6F58
	public static bool GetTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + tapeID.ToString());
	}

	// Token: 0x0600156B RID: 5483 RVA: 0x000D8D90 File Offset: 0x000D6F90
	public static void SetTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + text, value);
	}

	// Token: 0x0600156C RID: 5484 RVA: 0x000D8DEC File Offset: 0x000D6FEC
	public static int[] KeysOfTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_");
	}

	// Token: 0x0600156D RID: 5485 RVA: 0x000D8E1C File Offset: 0x000D701C
	public static bool GetTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + tapeID.ToString());
	}

	// Token: 0x0600156E RID: 5486 RVA: 0x000D8E54 File Offset: 0x000D7054
	public static void SetTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + text, value);
	}

	// Token: 0x0600156F RID: 5487 RVA: 0x000D8EB0 File Offset: 0x000D70B0
	public static int[] KeysOfTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_");
	}

	// Token: 0x06001570 RID: 5488 RVA: 0x000D8EE0 File Offset: 0x000D70E0
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
	}

	// Token: 0x0400219D RID: 8605
	private const string Str_HeadmasterTapeCollected = "HeadmasterTapeCollected_";

	// Token: 0x0400219E RID: 8606
	private const string Str_HeadmasterTapeListened = "HeadmasterTapeListened_";

	// Token: 0x0400219F RID: 8607
	private const string Str_BasementTapeCollected = "BasementTapeCollected_";

	// Token: 0x040021A0 RID: 8608
	private const string Str_BasementTapeListened = "BasementTapeListened_";

	// Token: 0x040021A1 RID: 8609
	private const string Str_MangaCollected = "MangaCollected_";

	// Token: 0x040021A2 RID: 8610
	private const string Str_GiftPurchased = "GiftPurchased_";

	// Token: 0x040021A3 RID: 8611
	private const string Str_GiftGiven = "GiftGiven_";

	// Token: 0x040021A4 RID: 8612
	private const string Str_MatchmakingGifts = "MatchmakingGifts";

	// Token: 0x040021A5 RID: 8613
	private const string Str_SenpaiGifts = "SenpaiGifts";

	// Token: 0x040021A6 RID: 8614
	private const string Str_PantyPurchased = "PantyPurchased_";

	// Token: 0x040021A7 RID: 8615
	private const string Str_AdvicePurchased = "AdvicePurchased_";

	// Token: 0x040021A8 RID: 8616
	private const string Str_TapeCollected = "TapeCollected_";

	// Token: 0x040021A9 RID: 8617
	private const string Str_TapeListened = "TapeListened_";
}
