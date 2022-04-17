using System;

// Token: 0x020002F5 RID: 757
public static class HomeGlobals
{
	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x0600162F RID: 5679 RVA: 0x000DD674 File Offset: 0x000DB874
	// (set) Token: 0x06001630 RID: 5680 RVA: 0x000DD6A4 File Offset: 0x000DB8A4
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
	// (get) Token: 0x06001631 RID: 5681 RVA: 0x000DD6D4 File Offset: 0x000DB8D4
	// (set) Token: 0x06001632 RID: 5682 RVA: 0x000DD704 File Offset: 0x000DB904
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
	// (get) Token: 0x06001633 RID: 5683 RVA: 0x000DD734 File Offset: 0x000DB934
	// (set) Token: 0x06001634 RID: 5684 RVA: 0x000DD764 File Offset: 0x000DB964
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
	// (get) Token: 0x06001635 RID: 5685 RVA: 0x000DD794 File Offset: 0x000DB994
	// (set) Token: 0x06001636 RID: 5686 RVA: 0x000DD7C4 File Offset: 0x000DB9C4
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

	// Token: 0x06001637 RID: 5687 RVA: 0x000DD7F4 File Offset: 0x000DB9F4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x04002244 RID: 8772
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x04002245 RID: 8773
	private const string Str_Night = "Night";

	// Token: 0x04002246 RID: 8774
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x04002247 RID: 8775
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
