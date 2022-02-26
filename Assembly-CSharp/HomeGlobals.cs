using System;

// Token: 0x020002F3 RID: 755
public static class HomeGlobals
{
	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x0600161C RID: 5660 RVA: 0x000DC6A0 File Offset: 0x000DA8A0
	// (set) Token: 0x0600161D RID: 5661 RVA: 0x000DC6D0 File Offset: 0x000DA8D0
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
	// (get) Token: 0x0600161E RID: 5662 RVA: 0x000DC700 File Offset: 0x000DA900
	// (set) Token: 0x0600161F RID: 5663 RVA: 0x000DC730 File Offset: 0x000DA930
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
	// (get) Token: 0x06001620 RID: 5664 RVA: 0x000DC760 File Offset: 0x000DA960
	// (set) Token: 0x06001621 RID: 5665 RVA: 0x000DC790 File Offset: 0x000DA990
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
	// (get) Token: 0x06001622 RID: 5666 RVA: 0x000DC7C0 File Offset: 0x000DA9C0
	// (set) Token: 0x06001623 RID: 5667 RVA: 0x000DC7F0 File Offset: 0x000DA9F0
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

	// Token: 0x06001624 RID: 5668 RVA: 0x000DC820 File Offset: 0x000DAA20
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x0400220D RID: 8717
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x0400220E RID: 8718
	private const string Str_Night = "Night";

	// Token: 0x0400220F RID: 8719
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x04002210 RID: 8720
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
