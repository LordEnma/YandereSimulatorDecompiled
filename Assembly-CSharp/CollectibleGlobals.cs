using System;
using UnityEngine;

// Token: 0x020002ED RID: 749
public static class CollectibleGlobals
{
	// Token: 0x0600155A RID: 5466 RVA: 0x000D9844 File Offset: 0x000D7A44
	public static bool GetHeadmasterTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + tapeID.ToString());
	}

	// Token: 0x0600155B RID: 5467 RVA: 0x000D987C File Offset: 0x000D7A7C
	public static void SetHeadmasterTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_" + text, value);
	}

	// Token: 0x0600155C RID: 5468 RVA: 0x000D98D8 File Offset: 0x000D7AD8
	public static bool GetHeadmasterTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + tapeID.ToString());
	}

	// Token: 0x0600155D RID: 5469 RVA: 0x000D9910 File Offset: 0x000D7B10
	public static void SetHeadmasterTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_" + text, value);
	}

	// Token: 0x0600155E RID: 5470 RVA: 0x000D996C File Offset: 0x000D7B6C
	public static int[] KeysOfHeadmasterTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeCollected_");
	}

	// Token: 0x0600155F RID: 5471 RVA: 0x000D999C File Offset: 0x000D7B9C
	public static int[] KeysOfHeadmasterTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HeadmasterTapeListened_");
	}

	// Token: 0x06001560 RID: 5472 RVA: 0x000D99CC File Offset: 0x000D7BCC
	public static bool GetBasementTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + tapeID.ToString());
	}

	// Token: 0x06001561 RID: 5473 RVA: 0x000D9A04 File Offset: 0x000D7C04
	public static void SetBasementTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_" + text, value);
	}

	// Token: 0x06001562 RID: 5474 RVA: 0x000D9A60 File Offset: 0x000D7C60
	public static int[] KeysOfBasementTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeCollected_");
	}

	// Token: 0x06001563 RID: 5475 RVA: 0x000D9A90 File Offset: 0x000D7C90
	public static bool GetBasementTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + tapeID.ToString());
	}

	// Token: 0x06001564 RID: 5476 RVA: 0x000D9AC8 File Offset: 0x000D7CC8
	public static void SetBasementTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_" + text, value);
	}

	// Token: 0x06001565 RID: 5477 RVA: 0x000D9B24 File Offset: 0x000D7D24
	public static int[] KeysOfBasementTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BasementTapeListened_");
	}

	// Token: 0x06001566 RID: 5478 RVA: 0x000D9B54 File Offset: 0x000D7D54
	public static bool GetMangaCollected(int mangaID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + mangaID.ToString());
	}

	// Token: 0x06001567 RID: 5479 RVA: 0x000D9B8C File Offset: 0x000D7D8C
	public static void SetMangaCollected(int mangaID, bool value)
	{
		string text = mangaID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_" + text, value);
	}

	// Token: 0x06001568 RID: 5480 RVA: 0x000D9BE8 File Offset: 0x000D7DE8
	public static bool GetGiftPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + giftID.ToString());
	}

	// Token: 0x06001569 RID: 5481 RVA: 0x000D9C20 File Offset: 0x000D7E20
	public static void SetGiftPurchased(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_" + text, value);
	}

	// Token: 0x0600156A RID: 5482 RVA: 0x000D9C7C File Offset: 0x000D7E7C
	public static bool GetGiftGiven(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + giftID.ToString());
	}

	// Token: 0x0600156B RID: 5483 RVA: 0x000D9CB4 File Offset: 0x000D7EB4
	public static void SetGiftGiven(int giftID, bool value)
	{
		string text = giftID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_" + text, value);
	}

	// Token: 0x17000381 RID: 897
	// (get) Token: 0x0600156C RID: 5484 RVA: 0x000D9D10 File Offset: 0x000D7F10
	// (set) Token: 0x0600156D RID: 5485 RVA: 0x000D9D40 File Offset: 0x000D7F40
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
	// (get) Token: 0x0600156E RID: 5486 RVA: 0x000D9D70 File Offset: 0x000D7F70
	// (set) Token: 0x0600156F RID: 5487 RVA: 0x000D9DA0 File Offset: 0x000D7FA0
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

	// Token: 0x06001570 RID: 5488 RVA: 0x000D9DD0 File Offset: 0x000D7FD0
	public static bool GetPantyPurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + giftID.ToString());
	}

	// Token: 0x06001571 RID: 5489 RVA: 0x000D9E08 File Offset: 0x000D8008
	public static void SetPantyPurchased(int pantyID, bool value)
	{
		string text = pantyID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_" + text, value);
	}

	// Token: 0x06001572 RID: 5490 RVA: 0x000D9E64 File Offset: 0x000D8064
	public static bool GetAdvicePurchased(int giftID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + giftID.ToString());
	}

	// Token: 0x06001573 RID: 5491 RVA: 0x000D9E9C File Offset: 0x000D809C
	public static void SetAdvicePurchased(int adviceID, bool value)
	{
		string text = adviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_" + text, value);
	}

	// Token: 0x06001574 RID: 5492 RVA: 0x000D9EF8 File Offset: 0x000D80F8
	public static int[] KeysOfMangaCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_MangaCollected_");
	}

	// Token: 0x06001575 RID: 5493 RVA: 0x000D9F28 File Offset: 0x000D8128
	public static int[] KeysOfGiftPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftPurchased_");
	}

	// Token: 0x06001576 RID: 5494 RVA: 0x000D9F58 File Offset: 0x000D8158
	public static int[] KeysOfGiftGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GiftGiven_");
	}

	// Token: 0x06001577 RID: 5495 RVA: 0x000D9F88 File Offset: 0x000D8188
	public static int[] KeysOfPantyPurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PantyPurchased_");
	}

	// Token: 0x06001578 RID: 5496 RVA: 0x000D9FB8 File Offset: 0x000D81B8
	public static int[] KeysOfAdvicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_AdvicePurchased_");
	}

	// Token: 0x06001579 RID: 5497 RVA: 0x000D9FE8 File Offset: 0x000D81E8
	public static bool GetTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + tapeID.ToString());
	}

	// Token: 0x0600157A RID: 5498 RVA: 0x000DA020 File Offset: 0x000D8220
	public static void SetTapeCollected(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_" + text, value);
	}

	// Token: 0x0600157B RID: 5499 RVA: 0x000DA07C File Offset: 0x000D827C
	public static int[] KeysOfTapeCollected()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeCollected_");
	}

	// Token: 0x0600157C RID: 5500 RVA: 0x000DA0AC File Offset: 0x000D82AC
	public static bool GetTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + tapeID.ToString());
	}

	// Token: 0x0600157D RID: 5501 RVA: 0x000DA0E4 File Offset: 0x000D82E4
	public static void SetTapeListened(int tapeID, bool value)
	{
		string text = tapeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_" + text, value);
	}

	// Token: 0x0600157E RID: 5502 RVA: 0x000DA140 File Offset: 0x000D8340
	public static int[] KeysOfTapeListened()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TapeListened_");
	}

	// Token: 0x0600157F RID: 5503 RVA: 0x000DA170 File Offset: 0x000D8370
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

	// Token: 0x040021CD RID: 8653
	private const string Str_HeadmasterTapeCollected = "HeadmasterTapeCollected_";

	// Token: 0x040021CE RID: 8654
	private const string Str_HeadmasterTapeListened = "HeadmasterTapeListened_";

	// Token: 0x040021CF RID: 8655
	private const string Str_BasementTapeCollected = "BasementTapeCollected_";

	// Token: 0x040021D0 RID: 8656
	private const string Str_BasementTapeListened = "BasementTapeListened_";

	// Token: 0x040021D1 RID: 8657
	private const string Str_MangaCollected = "MangaCollected_";

	// Token: 0x040021D2 RID: 8658
	private const string Str_GiftPurchased = "GiftPurchased_";

	// Token: 0x040021D3 RID: 8659
	private const string Str_GiftGiven = "GiftGiven_";

	// Token: 0x040021D4 RID: 8660
	private const string Str_MatchmakingGifts = "MatchmakingGifts";

	// Token: 0x040021D5 RID: 8661
	private const string Str_SenpaiGifts = "SenpaiGifts";

	// Token: 0x040021D6 RID: 8662
	private const string Str_PantyPurchased = "PantyPurchased_";

	// Token: 0x040021D7 RID: 8663
	private const string Str_AdvicePurchased = "AdvicePurchased_";

	// Token: 0x040021D8 RID: 8664
	private const string Str_TapeCollected = "TapeCollected_";

	// Token: 0x040021D9 RID: 8665
	private const string Str_TapeListened = "TapeListened_";
}
