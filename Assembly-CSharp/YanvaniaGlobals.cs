using System;

// Token: 0x020002FC RID: 764
public static class YanvaniaGlobals
{
	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x060017A4 RID: 6052 RVA: 0x000E2134 File Offset: 0x000E0334
	// (set) Token: 0x060017A5 RID: 6053 RVA: 0x000E2164 File Offset: 0x000E0364
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

	// Token: 0x17000446 RID: 1094
	// (get) Token: 0x060017A6 RID: 6054 RVA: 0x000E2194 File Offset: 0x000E0394
	// (set) Token: 0x060017A7 RID: 6055 RVA: 0x000E21C4 File Offset: 0x000E03C4
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

	// Token: 0x060017A8 RID: 6056 RVA: 0x000E21F4 File Offset: 0x000E03F4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022A6 RID: 8870
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022A7 RID: 8871
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
