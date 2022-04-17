using System;

// Token: 0x020002EE RID: 750
public static class ClubGlobals
{
	// Token: 0x17000380 RID: 896
	// (get) Token: 0x0600155F RID: 5471 RVA: 0x000DA0A4 File Offset: 0x000D82A4
	// (set) Token: 0x06001560 RID: 5472 RVA: 0x000DA0D4 File Offset: 0x000D82D4
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

	// Token: 0x06001561 RID: 5473 RVA: 0x000DA104 File Offset: 0x000D8304
	public static bool GetClubClosed(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_ClubClosed_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x06001562 RID: 5474 RVA: 0x000DA13C File Offset: 0x000D833C
	public static void SetClubClosed(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_" + text, value);
	}

	// Token: 0x06001563 RID: 5475 RVA: 0x000DA198 File Offset: 0x000D8398
	public static ClubType[] KeysOfClubClosed()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubClosed_");
	}

	// Token: 0x06001564 RID: 5476 RVA: 0x000DA1C8 File Offset: 0x000D83C8
	public static bool GetClubKicked(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_ClubKicked_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x06001565 RID: 5477 RVA: 0x000DA200 File Offset: 0x000D8400
	public static void SetClubKicked(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_" + text, value);
	}

	// Token: 0x06001566 RID: 5478 RVA: 0x000DA25C File Offset: 0x000D845C
	public static ClubType[] KeysOfClubKicked()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_ClubKicked_");
	}

	// Token: 0x06001567 RID: 5479 RVA: 0x000DA28C File Offset: 0x000D848C
	public static bool GetQuitClub(ClubType clubID)
	{
		string str = "Profile_";
		string str2 = GameGlobals.Profile.ToString();
		string str3 = "_QuitClub_";
		int num = (int)clubID;
		return GlobalsHelper.GetBool(str + str2 + str3 + num.ToString());
	}

	// Token: 0x06001568 RID: 5480 RVA: 0x000DA2C4 File Offset: 0x000D84C4
	public static void SetQuitClub(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_" + text, value);
	}

	// Token: 0x06001569 RID: 5481 RVA: 0x000DA320 File Offset: 0x000D8520
	public static ClubType[] KeysOfQuitClub()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile.ToString() + "_QuitClub_");
	}

	// Token: 0x0600156A RID: 5482 RVA: 0x000DA350 File Offset: 0x000D8550
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

	// Token: 0x040021EB RID: 8683
	private const string Str_Club = "Club";

	// Token: 0x040021EC RID: 8684
	private const string Str_ClubClosed = "ClubClosed_";

	// Token: 0x040021ED RID: 8685
	private const string Str_ClubKicked = "ClubKicked_";

	// Token: 0x040021EE RID: 8686
	private const string Str_QuitClub = "QuitClub_";
}
