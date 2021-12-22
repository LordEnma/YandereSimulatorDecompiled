using System;

// Token: 0x020002F0 RID: 752
public static class HomeGlobals
{
	// Token: 0x170003BF RID: 959
	// (get) Token: 0x06001605 RID: 5637 RVA: 0x000DB024 File Offset: 0x000D9224
	// (set) Token: 0x06001606 RID: 5638 RVA: 0x000DB054 File Offset: 0x000D9254
	public static bool LateForSchool
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool", value);
		}
	}

	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x06001607 RID: 5639 RVA: 0x000DB084 File Offset: 0x000D9284
	// (set) Token: 0x06001608 RID: 5640 RVA: 0x000DB0B4 File Offset: 0x000D92B4
	public static bool Night
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Night", value);
		}
	}

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x06001609 RID: 5641 RVA: 0x000DB0E4 File Offset: 0x000D92E4
	// (set) Token: 0x0600160A RID: 5642 RVA: 0x000DB114 File Offset: 0x000D9314
	public static bool StartInBasement
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement", value);
		}
	}

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x0600160B RID: 5643 RVA: 0x000DB144 File Offset: 0x000D9344
	// (set) Token: 0x0600160C RID: 5644 RVA: 0x000DB174 File Offset: 0x000D9374
	public static bool MiyukiDefeated
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated", value);
		}
	}

	// Token: 0x0600160D RID: 5645 RVA: 0x000DB1A4 File Offset: 0x000D93A4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x040021E5 RID: 8677
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x040021E6 RID: 8678
	private const string Str_Night = "Night";

	// Token: 0x040021E7 RID: 8679
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x040021E8 RID: 8680
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
