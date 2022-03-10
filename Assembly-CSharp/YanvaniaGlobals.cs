using System;

// Token: 0x020002FE RID: 766
public static class YanvaniaGlobals
{
	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x060017B6 RID: 6070 RVA: 0x000E3060 File Offset: 0x000E1260
	// (set) Token: 0x060017B7 RID: 6071 RVA: 0x000E3090 File Offset: 0x000E1290
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
	// (get) Token: 0x060017B8 RID: 6072 RVA: 0x000E30C0 File Offset: 0x000E12C0
	// (set) Token: 0x060017B9 RID: 6073 RVA: 0x000E30F0 File Offset: 0x000E12F0
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

	// Token: 0x060017BA RID: 6074 RVA: 0x000E3120 File Offset: 0x000E1320
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022D3 RID: 8915
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022D4 RID: 8916
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
