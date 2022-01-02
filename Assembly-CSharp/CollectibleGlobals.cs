using System;
using UnityEngine;

// Token: 0x020002EA RID: 746
public static class CollectibleGlobals
{
	// Token: 0x06001547 RID: 5447 RVA: 0x000D81A0 File Offset: 0x000D63A0
	public static bool GetHeadmasterTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + tapeID.ToString());
	}

	// Token: 0x06001548 RID: 5448 RVA: 0x000D81D8 File Offset: 0x000D63D8
	public static void SetHeadmasterTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + text, value);
	}

	// Token: 0x06001549 RID: 5449 RVA: 0x000D8234 File Offset: 0x000D6434
	public static bool GetHeadmasterTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + tapeID.ToString());
	}

	// Token: 0x0600154A RID: 5450 RVA: 0x000D826C File Offset: 0x000D646C
	public static void SetHeadmasterTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + text, value);
	}

	// Token: 0x0600154B RID: 5451 RVA: 0x000D82C8 File Offset: 0x000D64C8
	public static int[] KeysOfHeadmasterTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_");
	}

	// Token: 0x0600154C RID: 5452 RVA: 0x000D82F8 File Offset: 0x000D64F8
	public static int[] KeysOfHeadmasterTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_");
	}

	// Token: 0x0600154D RID: 5453 RVA: 0x000D8328 File Offset: 0x000D6528
	public static bool GetBasementTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + tapeID.ToString());
	}

	// Token: 0x0600154E RID: 5454 RVA: 0x000D8360 File Offset: 0x000D6560
	public static void SetBasementTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + text, value);
	}

	// Token: 0x0600154F RID: 5455 RVA: 0x000D83BC File Offset: 0x000D65BC
	public static int[] KeysOfBasementTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_");
	}

	// Token: 0x06001550 RID: 5456 RVA: 0x000D83EC File Offset: 0x000D65EC
	public static bool GetBasementTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + tapeID.ToString());
	}

	// Token: 0x06001551 RID: 5457 RVA: 0x000D8424 File Offset: 0x000D6624
	public static void SetBasementTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + text, value);
	}

	// Token: 0x06001552 RID: 5458 RVA: 0x000D8480 File Offset: 0x000D6680
	public static int[] KeysOfBasementTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_");
	}

	// Token: 0x06001553 RID: 5459 RVA: 0x000D84B0 File Offset: 0x000D66B0
	public static bool GetMangaCollected(int mangaID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + mangaID.ToString());
	}

	// Token: 0x06001554 RID: 5460 RVA: 0x000D84E8 File Offset: 0x000D66E8
	public static void SetMangaCollected(int mangaID, bool value)
	{
		string text = mangaID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + text, value);
	}

	// Token: 0x06001555 RID: 5461 RVA: 0x000D8544 File Offset: 0x000D6744
	public static bool GetGiftPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + giftID.ToString());
	}

	// Token: 0x06001556 RID: 5462 RVA: 0x000D857C File Offset: 0x000D677C
	public static void SetGiftPurchased(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + text, value);
	}

	// Token: 0x06001557 RID: 5463 RVA: 0x000D85D8 File Offset: 0x000D67D8
	public static bool GetGiftGiven(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + giftID.ToString());
	}

	// Token: 0x06001558 RID: 5464 RVA: 0x000D8610 File Offset: 0x000D6810
	public static void SetGiftGiven(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + text, value);
	}

	// Token: 0x17000381 RID: 897
	// (get) Token: 0x06001559 RID: 5465 RVA: 0x000D866C File Offset: 0x000D686C
	// (set) Token: 0x0600155A RID: 5466 RVA: 0x000D869C File Offset: 0x000D689C
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
	// (get) Token: 0x0600155B RID: 5467 RVA: 0x000D86CC File Offset: 0x000D68CC
	// (set) Token: 0x0600155C RID: 5468 RVA: 0x000D86FC File Offset: 0x000D68FC
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

	// Token: 0x0600155D RID: 5469 RVA: 0x000D872C File Offset: 0x000D692C
	public static bool GetPantyPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + giftID.ToString());
	}

	// Token: 0x0600155E RID: 5470 RVA: 0x000D8764 File Offset: 0x000D6964
	public static void SetPantyPurchased(int pantyID, bool value)
	{
		string text = pantyID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + text, value);
	}

	// Token: 0x0600155F RID: 5471 RVA: 0x000D87C0 File Offset: 0x000D69C0
	public static bool GetAdvicePurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + giftID.ToString());
	}

	// Token: 0x06001560 RID: 5472 RVA: 0x000D87F8 File Offset: 0x000D69F8
	public static void SetAdvicePurchased(int adviceID, bool value)
	{
		string text = adviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + text, value);
	}

	// Token: 0x06001561 RID: 5473 RVA: 0x000D8854 File Offset: 0x000D6A54
	public static int[] KeysOfMangaCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_");
	}

	// Token: 0x06001562 RID: 5474 RVA: 0x000D8884 File Offset: 0x000D6A84
	public static int[] KeysOfGiftPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_");
	}

	// Token: 0x06001563 RID: 5475 RVA: 0x000D88B4 File Offset: 0x000D6AB4
	public static int[] KeysOfGiftGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_");
	}

	// Token: 0x06001564 RID: 5476 RVA: 0x000D88E4 File Offset: 0x000D6AE4
	public static int[] KeysOfPantyPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_");
	}

	// Token: 0x06001565 RID: 5477 RVA: 0x000D8914 File Offset: 0x000D6B14
	public static int[] KeysOfAdvicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_");
	}

	// Token: 0x06001566 RID: 5478 RVA: 0x000D8944 File Offset: 0x000D6B44
	public static bool GetTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + tapeID.ToString());
	}

	// Token: 0x06001567 RID: 5479 RVA: 0x000D897C File Offset: 0x000D6B7C
	public static void SetTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + text, value);
	}

	// Token: 0x06001568 RID: 5480 RVA: 0x000D89D8 File Offset: 0x000D6BD8
	public static int[] KeysOfTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_");
	}

	// Token: 0x06001569 RID: 5481 RVA: 0x000D8A08 File Offset: 0x000D6C08
	public static bool GetTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + tapeID.ToString());
	}

	// Token: 0x0600156A RID: 5482 RVA: 0x000D8A40 File Offset: 0x000D6C40
	public static void SetTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + text, value);
	}

	// Token: 0x0600156B RID: 5483 RVA: 0x000D8A9C File Offset: 0x000D6C9C
	public static int[] KeysOfTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_");
	}

	// Token: 0x0600156C RID: 5484 RVA: 0x000D8ACC File Offset: 0x000D6CCC
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

	// Token: 0x04002196 RID: 8598
	private const string Str_HeadmasterTapeCollected = "HeadmasterTapeCollected_";

	// Token: 0x04002197 RID: 8599
	private const string Str_HeadmasterTapeListened = "HeadmasterTapeListened_";

	// Token: 0x04002198 RID: 8600
	private const string Str_BasementTapeCollected = "BasementTapeCollected_";

	// Token: 0x04002199 RID: 8601
	private const string Str_BasementTapeListened = "BasementTapeListened_";

	// Token: 0x0400219A RID: 8602
	private const string Str_MangaCollected = "MangaCollected_";

	// Token: 0x0400219B RID: 8603
	private const string Str_GiftPurchased = "GiftPurchased_";

	// Token: 0x0400219C RID: 8604
	private const string Str_GiftGiven = "GiftGiven_";

	// Token: 0x0400219D RID: 8605
	private const string Str_MatchmakingGifts = "MatchmakingGifts";

	// Token: 0x0400219E RID: 8606
	private const string Str_SenpaiGifts = "SenpaiGifts";

	// Token: 0x0400219F RID: 8607
	private const string Str_PantyPurchased = "PantyPurchased_";

	// Token: 0x040021A0 RID: 8608
	private const string Str_AdvicePurchased = "AdvicePurchased_";

	// Token: 0x040021A1 RID: 8609
	private const string Str_TapeCollected = "TapeCollected_";

	// Token: 0x040021A2 RID: 8610
	private const string Str_TapeListened = "TapeListened_";
}
