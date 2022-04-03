using System;

// Token: 0x020002F4 RID: 756
public static class HomeGlobals
{
	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06001627 RID: 5671 RVA: 0x000DD37C File Offset: 0x000DB57C
	// (set) Token: 0x06001628 RID: 5672 RVA: 0x000DD3AC File Offset: 0x000DB5AC
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
	// (get) Token: 0x06001629 RID: 5673 RVA: 0x000DD3DC File Offset: 0x000DB5DC
	// (set) Token: 0x0600162A RID: 5674 RVA: 0x000DD40C File Offset: 0x000DB60C
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
	// (get) Token: 0x0600162B RID: 5675 RVA: 0x000DD43C File Offset: 0x000DB63C
	// (set) Token: 0x0600162C RID: 5676 RVA: 0x000DD46C File Offset: 0x000DB66C
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
	// (get) Token: 0x0600162D RID: 5677 RVA: 0x000DD49C File Offset: 0x000DB69C
	// (set) Token: 0x0600162E RID: 5678 RVA: 0x000DD4CC File Offset: 0x000DB6CC
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

	// Token: 0x0600162F RID: 5679 RVA: 0x000DD4FC File Offset: 0x000DB6FC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x04002240 RID: 8768
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x04002241 RID: 8769
	private const string Str_Night = "Night";

	// Token: 0x04002242 RID: 8770
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x04002243 RID: 8771
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
