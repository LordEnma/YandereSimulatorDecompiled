using System;

// Token: 0x020002F5 RID: 757
public static class HomeGlobals
{
	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06001633 RID: 5683 RVA: 0x000DDB10 File Offset: 0x000DBD10
	// (set) Token: 0x06001634 RID: 5684 RVA: 0x000DDB40 File Offset: 0x000DBD40
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
	// (get) Token: 0x06001635 RID: 5685 RVA: 0x000DDB70 File Offset: 0x000DBD70
	// (set) Token: 0x06001636 RID: 5686 RVA: 0x000DDBA0 File Offset: 0x000DBDA0
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
	// (get) Token: 0x06001637 RID: 5687 RVA: 0x000DDBD0 File Offset: 0x000DBDD0
	// (set) Token: 0x06001638 RID: 5688 RVA: 0x000DDC00 File Offset: 0x000DBE00
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
	// (get) Token: 0x06001639 RID: 5689 RVA: 0x000DDC30 File Offset: 0x000DBE30
	// (set) Token: 0x0600163A RID: 5690 RVA: 0x000DDC60 File Offset: 0x000DBE60
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

	// Token: 0x0600163B RID: 5691 RVA: 0x000DDC90 File Offset: 0x000DBE90
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
