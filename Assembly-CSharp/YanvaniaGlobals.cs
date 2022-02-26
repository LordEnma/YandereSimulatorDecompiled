using System;

// Token: 0x020002FE RID: 766
public static class YanvaniaGlobals
{
	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x060017B6 RID: 6070 RVA: 0x000E2D30 File Offset: 0x000E0F30
	// (set) Token: 0x060017B7 RID: 6071 RVA: 0x000E2D60 File Offset: 0x000E0F60
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
	// (get) Token: 0x060017B8 RID: 6072 RVA: 0x000E2D90 File Offset: 0x000E0F90
	// (set) Token: 0x060017B9 RID: 6073 RVA: 0x000E2DC0 File Offset: 0x000E0FC0
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

	// Token: 0x060017BA RID: 6074 RVA: 0x000E2DF0 File Offset: 0x000E0FF0
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022BF RID: 8895
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022C0 RID: 8896
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
