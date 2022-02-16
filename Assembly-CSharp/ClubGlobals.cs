using System;

// Token: 0x020002EB RID: 747
public static class ClubGlobals
{
	// Token: 0x17000380 RID: 896
	// (get) Token: 0x06001545 RID: 5445 RVA: 0x000D8828 File Offset: 0x000D6A28
	// (set) Token: 0x06001546 RID: 5446 RVA: 0x000D8858 File Offset: 0x000D6A58
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

	// Token: 0x06001547 RID: 5447 RVA: 0x000D8888 File Offset: 0x000D6A88
	public static bool GetClubClosed(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_ClubClosed_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x06001548 RID: 5448 RVA: 0x000D88C0 File Offset: 0x000D6AC0
	public static void SetClubClosed(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_" + text, value);
	}

	// Token: 0x06001549 RID: 5449 RVA: 0x000D891C File Offset: 0x000D6B1C
	public static ClubType[] KeysOfClubClosed()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_");
	}

	// Token: 0x0600154A RID: 5450 RVA: 0x000D894C File Offset: 0x000D6B4C
	public static bool GetClubKicked(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_ClubKicked_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x0600154B RID: 5451 RVA: 0x000D8984 File Offset: 0x000D6B84
	public static void SetClubKicked(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_" + text, value);
	}

	// Token: 0x0600154C RID: 5452 RVA: 0x000D89E0 File Offset: 0x000D6BE0
	public static ClubType[] KeysOfClubKicked()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_");
	}

	// Token: 0x0600154D RID: 5453 RVA: 0x000D8A10 File Offset: 0x000D6C10
	public static bool GetQuitClub(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_QuitClub_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x0600154E RID: 5454 RVA: 0x000D8A48 File Offset: 0x000D6C48
	public static void SetQuitClub(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_" + text, value);
	}

	// Token: 0x0600154F RID: 5455 RVA: 0x000D8AA4 File Offset: 0x000D6CA4
	public static ClubType[] KeysOfQuitClub()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_");
	}

	// Token: 0x06001550 RID: 5456 RVA: 0x000D8AD4 File Offset: 0x000D6CD4
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

	// Token: 0x040021A6 RID: 8614
	private const string Str_Club = "Club";

	// Token: 0x040021A7 RID: 8615
	private const string Str_ClubClosed = "ClubClosed_";

	// Token: 0x040021A8 RID: 8616
	private const string Str_ClubKicked = "ClubKicked_";

	// Token: 0x040021A9 RID: 8617
	private const string Str_QuitClub = "QuitClub_";
}
