using System;

// Token: 0x020002FC RID: 764
public static class YanvaniaGlobals
{
	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x060017A3 RID: 6051 RVA: 0x000E1C2C File Offset: 0x000DFE2C
	// (set) Token: 0x060017A4 RID: 6052 RVA: 0x000E1C5C File Offset: 0x000DFE5C
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
	// (get) Token: 0x060017A5 RID: 6053 RVA: 0x000E1C8C File Offset: 0x000DFE8C
	// (set) Token: 0x060017A6 RID: 6054 RVA: 0x000E1CBC File Offset: 0x000DFEBC
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

	// Token: 0x060017A7 RID: 6055 RVA: 0x000E1CEC File Offset: 0x000DFEEC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x0400229E RID: 8862
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x0400229F RID: 8863
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
