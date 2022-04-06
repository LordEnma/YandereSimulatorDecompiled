using System;

// Token: 0x020002F5 RID: 757
public static class HomeGlobals
{
	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x0600162D RID: 5677 RVA: 0x000DD48C File Offset: 0x000DB68C
	// (set) Token: 0x0600162E RID: 5678 RVA: 0x000DD4BC File Offset: 0x000DB6BC
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
	// (get) Token: 0x0600162F RID: 5679 RVA: 0x000DD4EC File Offset: 0x000DB6EC
	// (set) Token: 0x06001630 RID: 5680 RVA: 0x000DD51C File Offset: 0x000DB71C
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
	// (get) Token: 0x06001631 RID: 5681 RVA: 0x000DD54C File Offset: 0x000DB74C
	// (set) Token: 0x06001632 RID: 5682 RVA: 0x000DD57C File Offset: 0x000DB77C
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
	// (get) Token: 0x06001633 RID: 5683 RVA: 0x000DD5AC File Offset: 0x000DB7AC
	// (set) Token: 0x06001634 RID: 5684 RVA: 0x000DD5DC File Offset: 0x000DB7DC
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

	// Token: 0x06001635 RID: 5685 RVA: 0x000DD60C File Offset: 0x000DB80C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x04002242 RID: 8770
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x04002243 RID: 8771
	private const string Str_Night = "Night";

	// Token: 0x04002244 RID: 8772
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x04002245 RID: 8773
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
