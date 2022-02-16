using System;

// Token: 0x020002FD RID: 765
public static class YanvaniaGlobals
{
	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x060017AD RID: 6061 RVA: 0x000E244C File Offset: 0x000E064C
	// (set) Token: 0x060017AE RID: 6062 RVA: 0x000E247C File Offset: 0x000E067C
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

	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x060017AF RID: 6063 RVA: 0x000E24AC File Offset: 0x000E06AC
	// (set) Token: 0x060017B0 RID: 6064 RVA: 0x000E24DC File Offset: 0x000E06DC
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

	// Token: 0x060017B1 RID: 6065 RVA: 0x000E250C File Offset: 0x000E070C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022B0 RID: 8880
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022B1 RID: 8881
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
