using System;

// Token: 0x020002FB RID: 763
public static class YanvaniaGlobals
{
	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x0600179D RID: 6045 RVA: 0x000E1634 File Offset: 0x000DF834
	// (set) Token: 0x0600179E RID: 6046 RVA: 0x000E1664 File Offset: 0x000DF864
	public static bool DraculaDefeated
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated", value);
		}
	}

	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x0600179F RID: 6047 RVA: 0x000E1694 File Offset: 0x000DF894
	// (set) Token: 0x060017A0 RID: 6048 RVA: 0x000E16C4 File Offset: 0x000DF8C4
	public static bool MidoriEasterEgg
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg", value);
		}
	}

	// Token: 0x060017A1 RID: 6049 RVA: 0x000E16F4 File Offset: 0x000DF8F4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x04002296 RID: 8854
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x04002297 RID: 8855
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
