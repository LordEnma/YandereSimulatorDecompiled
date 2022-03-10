using System;

// Token: 0x020002EC RID: 748
public static class ClubGlobals
{
	// Token: 0x17000380 RID: 896
	// (get) Token: 0x0600154E RID: 5454 RVA: 0x000D943C File Offset: 0x000D763C
	// (set) Token: 0x0600154F RID: 5455 RVA: 0x000D946C File Offset: 0x000D766C
	public static ClubType Club
	{
		get
		{
			return GlobalsHelper.GetEnum<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_Club");
		}
		set
		{
			GlobalsHelper.SetEnum<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_Club", value);
		}
	}

	// Token: 0x06001550 RID: 5456 RVA: 0x000D949C File Offset: 0x000D769C
	public static bool GetClubClosed(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_ClubClosed_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x06001551 RID: 5457 RVA: 0x000D94D4 File Offset: 0x000D76D4
	public static void SetClubClosed(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_" + text, value);
	}

	// Token: 0x06001552 RID: 5458 RVA: 0x000D9530 File Offset: 0x000D7730
	public static ClubType[] KeysOfClubClosed()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_");
	}

	// Token: 0x06001553 RID: 5459 RVA: 0x000D9560 File Offset: 0x000D7760
	public static bool GetClubKicked(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_ClubKicked_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x06001554 RID: 5460 RVA: 0x000D9598 File Offset: 0x000D7798
	public static void SetClubKicked(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_" + text, value);
	}

	// Token: 0x06001555 RID: 5461 RVA: 0x000D95F4 File Offset: 0x000D77F4
	public static ClubType[] KeysOfClubKicked()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_");
	}

	// Token: 0x06001556 RID: 5462 RVA: 0x000D9624 File Offset: 0x000D7824
	public static bool GetQuitClub(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_QuitClub_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x06001557 RID: 5463 RVA: 0x000D965C File Offset: 0x000D785C
	public static void SetQuitClub(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_" + text, value);
	}

	// Token: 0x06001558 RID: 5464 RVA: 0x000D96B8 File Offset: 0x000D78B8
	public static ClubType[] KeysOfQuitClub()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_");
	}

	// Token: 0x06001559 RID: 5465 RVA: 0x000D96E8 File Offset: 0x000D78E8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Club");
		foreach (ClubType clubType in ClubGlobals.KeysOfClubClosed())
		{
			string str = "Profile_";
			string str2 = GameGlobals.Profile.ToString();
			string str3 = "_ClubClosed_";
			int num = (int)clubType;
			Globals.Delete(str + str2 + str3 + num.ToString());
		}
		foreach (ClubType clubType2 in ClubGlobals.KeysOfClubKicked())
		{
			string str4 = "Profile_";
			string str5 = GameGlobals.Profile.ToString();
			string str6 = "_ClubKicked_";
			int num = (int)clubType2;
			Globals.Delete(str4 + str5 + str6 + num.ToString());
		}
		foreach (ClubType clubType3 in ClubGlobals.KeysOfQuitClub())
		{
			string str7 = "Profile_";
			string str8 = GameGlobals.Profile.ToString();
			string str9 = "_QuitClub_";
			int num = (int)clubType3;
			Globals.Delete(str7 + str8 + str9 + num.ToString());
		}
		KeysHelper.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_");
		KeysHelper.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_");
		KeysHelper.Delete("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_");
	}

	// Token: 0x040021C9 RID: 8649
	private const string Str_Club = "Club";

	// Token: 0x040021CA RID: 8650
	private const string Str_ClubClosed = "ClubClosed_";

	// Token: 0x040021CB RID: 8651
	private const string Str_ClubKicked = "ClubKicked_";

	// Token: 0x040021CC RID: 8652
	private const string Str_QuitClub = "QuitClub_";
}
