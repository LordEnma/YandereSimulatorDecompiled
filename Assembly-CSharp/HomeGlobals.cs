using System;

// Token: 0x020002F3 RID: 755
public static class HomeGlobals
{
	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06001621 RID: 5665 RVA: 0x000DCE7C File Offset: 0x000DB07C
	// (set) Token: 0x06001622 RID: 5666 RVA: 0x000DCEAC File Offset: 0x000DB0AC
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
	// (get) Token: 0x06001623 RID: 5667 RVA: 0x000DCEDC File Offset: 0x000DB0DC
	// (set) Token: 0x06001624 RID: 5668 RVA: 0x000DCF0C File Offset: 0x000DB10C
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
	// (get) Token: 0x06001625 RID: 5669 RVA: 0x000DCF3C File Offset: 0x000DB13C
	// (set) Token: 0x06001626 RID: 5670 RVA: 0x000DCF6C File Offset: 0x000DB16C
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
	// (get) Token: 0x06001627 RID: 5671 RVA: 0x000DCF9C File Offset: 0x000DB19C
	// (set) Token: 0x06001628 RID: 5672 RVA: 0x000DCFCC File Offset: 0x000DB1CC
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

	// Token: 0x06001629 RID: 5673 RVA: 0x000DCFFC File Offset: 0x000DB1FC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x04002232 RID: 8754
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x04002233 RID: 8755
	private const string Str_Night = "Night";

	// Token: 0x04002234 RID: 8756
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x04002235 RID: 8757
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
