using System;

// Token: 0x020002F3 RID: 755
public static class HomeGlobals
{
	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x0600161C RID: 5660 RVA: 0x000DC9D0 File Offset: 0x000DABD0
	// (set) Token: 0x0600161D RID: 5661 RVA: 0x000DCA00 File Offset: 0x000DAC00
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

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x0600161E RID: 5662 RVA: 0x000DCA30 File Offset: 0x000DAC30
	// (set) Token: 0x0600161F RID: 5663 RVA: 0x000DCA60 File Offset: 0x000DAC60
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

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06001620 RID: 5664 RVA: 0x000DCA90 File Offset: 0x000DAC90
	// (set) Token: 0x06001621 RID: 5665 RVA: 0x000DCAC0 File Offset: 0x000DACC0
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

	// Token: 0x170003C4 RID: 964
	// (get) Token: 0x06001622 RID: 5666 RVA: 0x000DCAF0 File Offset: 0x000DACF0
	// (set) Token: 0x06001623 RID: 5667 RVA: 0x000DCB20 File Offset: 0x000DAD20
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

	// Token: 0x06001624 RID: 5668 RVA: 0x000DCB50 File Offset: 0x000DAD50
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x04002221 RID: 8737
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x04002222 RID: 8738
	private const string Str_Night = "Night";

	// Token: 0x04002223 RID: 8739
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x04002224 RID: 8740
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
