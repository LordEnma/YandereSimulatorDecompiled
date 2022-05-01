using System;

// Token: 0x020002F5 RID: 757
public static class HomeGlobals
{
	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06001633 RID: 5683 RVA: 0x000DDB44 File Offset: 0x000DBD44
	// (set) Token: 0x06001634 RID: 5684 RVA: 0x000DDB74 File Offset: 0x000DBD74
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
	// (get) Token: 0x06001635 RID: 5685 RVA: 0x000DDBA4 File Offset: 0x000DBDA4
	// (set) Token: 0x06001636 RID: 5686 RVA: 0x000DDBD4 File Offset: 0x000DBDD4
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
	// (get) Token: 0x06001637 RID: 5687 RVA: 0x000DDC04 File Offset: 0x000DBE04
	// (set) Token: 0x06001638 RID: 5688 RVA: 0x000DDC34 File Offset: 0x000DBE34
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
	// (get) Token: 0x06001639 RID: 5689 RVA: 0x000DDC64 File Offset: 0x000DBE64
	// (set) Token: 0x0600163A RID: 5690 RVA: 0x000DDC94 File Offset: 0x000DBE94
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

	// Token: 0x0600163B RID: 5691 RVA: 0x000DDCC4 File Offset: 0x000DBEC4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x0400224D RID: 8781
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x0400224E RID: 8782
	private const string Str_Night = "Night";

	// Token: 0x0400224F RID: 8783
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x04002250 RID: 8784
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
