using System;

// Token: 0x020002E9 RID: 745
public static class ClubGlobals
{
	// Token: 0x17000380 RID: 896
	// (get) Token: 0x0600153B RID: 5435 RVA: 0x000D7B48 File Offset: 0x000D5D48
	// (set) Token: 0x0600153C RID: 5436 RVA: 0x000D7B78 File Offset: 0x000D5D78
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

	// Token: 0x0600153D RID: 5437 RVA: 0x000D7BA8 File Offset: 0x000D5DA8
	public static bool GetClubClosed(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_ClubClosed_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x0600153E RID: 5438 RVA: 0x000D7BE0 File Offset: 0x000D5DE0
	public static void SetClubClosed(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_" + text, value);
	}

	// Token: 0x0600153F RID: 5439 RVA: 0x000D7C3C File Offset: 0x000D5E3C
	public static ClubType[] KeysOfClubClosed()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_");
	}

	// Token: 0x06001540 RID: 5440 RVA: 0x000D7C6C File Offset: 0x000D5E6C
	public static bool GetClubKicked(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_ClubKicked_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x06001541 RID: 5441 RVA: 0x000D7CA4 File Offset: 0x000D5EA4
	public static void SetClubKicked(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_" + text, value);
	}

	// Token: 0x06001542 RID: 5442 RVA: 0x000D7D00 File Offset: 0x000D5F00
	public static ClubType[] KeysOfClubKicked()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_");
	}

	// Token: 0x06001543 RID: 5443 RVA: 0x000D7D30 File Offset: 0x000D5F30
	public static bool GetQuitClub(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_QuitClub_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x06001544 RID: 5444 RVA: 0x000D7D68 File Offset: 0x000D5F68
	public static void SetQuitClub(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_" + text, value);
	}

	// Token: 0x06001545 RID: 5445 RVA: 0x000D7DC4 File Offset: 0x000D5FC4
	public static ClubType[] KeysOfQuitClub()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_");
	}

	// Token: 0x06001546 RID: 5446 RVA: 0x000D7DF4 File Offset: 0x000D5FF4
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

	// Token: 0x0400218F RID: 8591
	private const string Str_Club = "Club";

	// Token: 0x04002190 RID: 8592
	private const string Str_ClubClosed = "ClubClosed_";

	// Token: 0x04002191 RID: 8593
	private const string Str_ClubKicked = "ClubKicked_";

	// Token: 0x04002192 RID: 8594
	private const string Str_QuitClub = "QuitClub_";
}
