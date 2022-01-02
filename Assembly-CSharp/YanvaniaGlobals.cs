using System;

// Token: 0x020002FB RID: 763
public static class YanvaniaGlobals
{
	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x0600179F RID: 6047 RVA: 0x000E1904 File Offset: 0x000DFB04
	// (set) Token: 0x060017A0 RID: 6048 RVA: 0x000E1934 File Offset: 0x000DFB34
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
	// (get) Token: 0x060017A1 RID: 6049 RVA: 0x000E1964 File Offset: 0x000DFB64
	// (set) Token: 0x060017A2 RID: 6050 RVA: 0x000E1994 File Offset: 0x000DFB94
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

	// Token: 0x060017A3 RID: 6051 RVA: 0x000E19C4 File Offset: 0x000DFBC4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x0400229A RID: 8858
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x0400229B RID: 8859
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
