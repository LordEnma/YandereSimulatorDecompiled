using System;

// Token: 0x020002EF RID: 751
public static class HomeGlobals
{
	// Token: 0x170003BF RID: 959
	// (get) Token: 0x060015FE RID: 5630 RVA: 0x000DA864 File Offset: 0x000D8A64
	// (set) Token: 0x060015FF RID: 5631 RVA: 0x000DA894 File Offset: 0x000D8A94
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
	// (get) Token: 0x06001600 RID: 5632 RVA: 0x000DA8C4 File Offset: 0x000D8AC4
	// (set) Token: 0x06001601 RID: 5633 RVA: 0x000DA8F4 File Offset: 0x000D8AF4
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
	// (get) Token: 0x06001602 RID: 5634 RVA: 0x000DA924 File Offset: 0x000D8B24
	// (set) Token: 0x06001603 RID: 5635 RVA: 0x000DA954 File Offset: 0x000D8B54
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
	// (get) Token: 0x06001604 RID: 5636 RVA: 0x000DA984 File Offset: 0x000D8B84
	// (set) Token: 0x06001605 RID: 5637 RVA: 0x000DA9B4 File Offset: 0x000D8BB4
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

	// Token: 0x06001606 RID: 5638 RVA: 0x000DA9E4 File Offset: 0x000D8BE4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x040021C5 RID: 8645
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x040021C6 RID: 8646
	private const string Str_Night = "Night";

	// Token: 0x040021C7 RID: 8647
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x040021C8 RID: 8648
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
