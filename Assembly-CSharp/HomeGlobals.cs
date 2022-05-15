using System;

// Token: 0x020002F6 RID: 758
public static class HomeGlobals
{
	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06001635 RID: 5685 RVA: 0x000DDE14 File Offset: 0x000DC014
	// (set) Token: 0x06001636 RID: 5686 RVA: 0x000DDE44 File Offset: 0x000DC044
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

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06001637 RID: 5687 RVA: 0x000DDE74 File Offset: 0x000DC074
	// (set) Token: 0x06001638 RID: 5688 RVA: 0x000DDEA4 File Offset: 0x000DC0A4
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

	// Token: 0x170003C4 RID: 964
	// (get) Token: 0x06001639 RID: 5689 RVA: 0x000DDED4 File Offset: 0x000DC0D4
	// (set) Token: 0x0600163A RID: 5690 RVA: 0x000DDF04 File Offset: 0x000DC104
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

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x0600163B RID: 5691 RVA: 0x000DDF34 File Offset: 0x000DC134
	// (set) Token: 0x0600163C RID: 5692 RVA: 0x000DDF64 File Offset: 0x000DC164
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

	// Token: 0x0600163D RID: 5693 RVA: 0x000DDF94 File Offset: 0x000DC194
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x04002256 RID: 8790
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x04002257 RID: 8791
	private const string Str_Night = "Night";

	// Token: 0x04002258 RID: 8792
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x04002259 RID: 8793
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
