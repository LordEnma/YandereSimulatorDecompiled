using System;
using UnityEngine;

// Token: 0x020002EA RID: 746
public static class CollectibleGlobals
{
	// Token: 0x06001547 RID: 5447 RVA: 0x000D7F50 File Offset: 0x000D6150
	public static bool GetHeadmasterTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + tapeID.ToString());
	}

	// Token: 0x06001548 RID: 5448 RVA: 0x000D7F88 File Offset: 0x000D6188
	public static void SetHeadmasterTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + text, value);
	}

	// Token: 0x06001549 RID: 5449 RVA: 0x000D7FE4 File Offset: 0x000D61E4
	public static bool GetHeadmasterTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + tapeID.ToString());
	}

	// Token: 0x0600154A RID: 5450 RVA: 0x000D801C File Offset: 0x000D621C
	public static void SetHeadmasterTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + text, value);
	}

	// Token: 0x0600154B RID: 5451 RVA: 0x000D8078 File Offset: 0x000D6278
	public static int[] KeysOfHeadmasterTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_");
	}

	// Token: 0x0600154C RID: 5452 RVA: 0x000D80A8 File Offset: 0x000D62A8
	public static int[] KeysOfHeadmasterTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_");
	}

	// Token: 0x0600154D RID: 5453 RVA: 0x000D80D8 File Offset: 0x000D62D8
	public static bool GetBasementTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + tapeID.ToString());
	}

	// Token: 0x0600154E RID: 5454 RVA: 0x000D8110 File Offset: 0x000D6310
	public static void SetBasementTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + text, value);
	}

	// Token: 0x0600154F RID: 5455 RVA: 0x000D816C File Offset: 0x000D636C
	public static int[] KeysOfBasementTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_");
	}

	// Token: 0x06001550 RID: 5456 RVA: 0x000D819C File Offset: 0x000D639C
	public static bool GetBasementTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + tapeID.ToString());
	}

	// Token: 0x06001551 RID: 5457 RVA: 0x000D81D4 File Offset: 0x000D63D4
	public static void SetBasementTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + text, value);
	}

	// Token: 0x06001552 RID: 5458 RVA: 0x000D8230 File Offset: 0x000D6430
	public static int[] KeysOfBasementTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_");
	}

	// Token: 0x06001553 RID: 5459 RVA: 0x000D8260 File Offset: 0x000D6460
	public static bool GetMangaCollected(int mangaID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + mangaID.ToString());
	}

	// Token: 0x06001554 RID: 5460 RVA: 0x000D8298 File Offset: 0x000D6498
	public static void SetMangaCollected(int mangaID, bool value)
	{
		string text = mangaID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + text, value);
	}

	// Token: 0x06001555 RID: 5461 RVA: 0x000D82F4 File Offset: 0x000D64F4
	public static bool GetGiftPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + giftID.ToString());
	}

	// Token: 0x06001556 RID: 5462 RVA: 0x000D832C File Offset: 0x000D652C
	public static void SetGiftPurchased(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + text, value);
	}

	// Token: 0x06001557 RID: 5463 RVA: 0x000D8388 File Offset: 0x000D6588
	public static bool GetGiftGiven(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + giftID.ToString());
	}

	// Token: 0x06001558 RID: 5464 RVA: 0x000D83C0 File Offset: 0x000D65C0
	public static void SetGiftGiven(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + text, value);
	}

	// Token: 0x17000381 RID: 897
	// (get) Token: 0x06001559 RID: 5465 RVA: 0x000D841C File Offset: 0x000D661C
	// (set) Token: 0x0600155A RID: 5466 RVA: 0x000D844C File Offset: 0x000D664C
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
	// (get) Token: 0x0600155B RID: 5467 RVA: 0x000D847C File Offset: 0x000D667C
	// (set) Token: 0x0600155C RID: 5468 RVA: 0x000D84AC File Offset: 0x000D66AC
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

	// Token: 0x0600155D RID: 5469 RVA: 0x000D84DC File Offset: 0x000D66DC
	public static bool GetPantyPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + giftID.ToString());
	}

	// Token: 0x0600155E RID: 5470 RVA: 0x000D8514 File Offset: 0x000D6714
	public static void SetPantyPurchased(int pantyID, bool value)
	{
		string text = pantyID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + text, value);
	}

	// Token: 0x0600155F RID: 5471 RVA: 0x000D8570 File Offset: 0x000D6770
	public static bool GetAdvicePurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + giftID.ToString());
	}

	// Token: 0x06001560 RID: 5472 RVA: 0x000D85A8 File Offset: 0x000D67A8
	public static void SetAdvicePurchased(int adviceID, bool value)
	{
		string text = adviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + text, value);
	}

	// Token: 0x06001561 RID: 5473 RVA: 0x000D8604 File Offset: 0x000D6804
	public static int[] KeysOfMangaCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_");
	}

	// Token: 0x06001562 RID: 5474 RVA: 0x000D8634 File Offset: 0x000D6834
	public static int[] KeysOfGiftPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_");
	}

	// Token: 0x06001563 RID: 5475 RVA: 0x000D8664 File Offset: 0x000D6864
	public static int[] KeysOfGiftGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_");
	}

	// Token: 0x06001564 RID: 5476 RVA: 0x000D8694 File Offset: 0x000D6894
	public static int[] KeysOfPantyPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_");
	}

	// Token: 0x06001565 RID: 5477 RVA: 0x000D86C4 File Offset: 0x000D68C4
	public static int[] KeysOfAdvicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_");
	}

	// Token: 0x06001566 RID: 5478 RVA: 0x000D86F4 File Offset: 0x000D68F4
	public static bool GetTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + tapeID.ToString());
	}

	// Token: 0x06001567 RID: 5479 RVA: 0x000D872C File Offset: 0x000D692C
	public static void SetTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + text, value);
	}

	// Token: 0x06001568 RID: 5480 RVA: 0x000D8788 File Offset: 0x000D6988
	public static int[] KeysOfTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_");
	}

	// Token: 0x06001569 RID: 5481 RVA: 0x000D87B8 File Offset: 0x000D69B8
	public static bool GetTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + tapeID.ToString());
	}

	// Token: 0x0600156A RID: 5482 RVA: 0x000D87F0 File Offset: 0x000D69F0
	public static void SetTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + text, value);
	}

	// Token: 0x0600156B RID: 5483 RVA: 0x000D884C File Offset: 0x000D6A4C
	public static int[] KeysOfTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_");
	}

	// Token: 0x0600156C RID: 5484 RVA: 0x000D887C File Offset: 0x000D6A7C
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

	// Token: 0x04002193 RID: 8595
	private const string Str_HeadmasterTapeCollected = "HeadmasterTapeCollected_";

	// Token: 0x04002194 RID: 8596
	private const string Str_HeadmasterTapeListened = "HeadmasterTapeListened_";

	// Token: 0x04002195 RID: 8597
	private const string Str_BasementTapeCollected = "BasementTapeCollected_";

	// Token: 0x04002196 RID: 8598
	private const string Str_BasementTapeListened = "BasementTapeListened_";

	// Token: 0x04002197 RID: 8599
	private const string Str_MangaCollected = "MangaCollected_";

	// Token: 0x04002198 RID: 8600
	private const string Str_GiftPurchased = "GiftPurchased_";

	// Token: 0x04002199 RID: 8601
	private const string Str_GiftGiven = "GiftGiven_";

	// Token: 0x0400219A RID: 8602
	private const string Str_MatchmakingGifts = "MatchmakingGifts";

	// Token: 0x0400219B RID: 8603
	private const string Str_SenpaiGifts = "SenpaiGifts";

	// Token: 0x0400219C RID: 8604
	private const string Str_PantyPurchased = "PantyPurchased_";

	// Token: 0x0400219D RID: 8605
	private const string Str_AdvicePurchased = "AdvicePurchased_";

	// Token: 0x0400219E RID: 8606
	private const string Str_TapeCollected = "TapeCollected_";

	// Token: 0x0400219F RID: 8607
	private const string Str_TapeListened = "TapeListened_";
}
