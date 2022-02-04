using System;

// Token: 0x020002FC RID: 764
public static class YanvaniaGlobals
{
	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x060017A4 RID: 6052 RVA: 0x000E21EC File Offset: 0x000E03EC
	// (set) Token: 0x060017A5 RID: 6053 RVA: 0x000E221C File Offset: 0x000E041C
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
	// (get) Token: 0x060017A6 RID: 6054 RVA: 0x000E224C File Offset: 0x000E044C
	// (set) Token: 0x060017A7 RID: 6055 RVA: 0x000E227C File Offset: 0x000E047C
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

	// Token: 0x060017A8 RID: 6056 RVA: 0x000E22AC File Offset: 0x000E04AC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022A7 RID: 8871
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022A8 RID: 8872
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
