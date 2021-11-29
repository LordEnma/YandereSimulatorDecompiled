using System;

// Token: 0x020002FA RID: 762
public static class YanvaniaGlobals
{
	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x06001796 RID: 6038 RVA: 0x000E0E74 File Offset: 0x000DF074
	// (set) Token: 0x06001797 RID: 6039 RVA: 0x000E0EA4 File Offset: 0x000DF0A4
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
	// (get) Token: 0x06001798 RID: 6040 RVA: 0x000E0ED4 File Offset: 0x000DF0D4
	// (set) Token: 0x06001799 RID: 6041 RVA: 0x000E0F04 File Offset: 0x000DF104
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

	// Token: 0x0600179A RID: 6042 RVA: 0x000E0F34 File Offset: 0x000DF134
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x04002276 RID: 8822
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x04002277 RID: 8823
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
