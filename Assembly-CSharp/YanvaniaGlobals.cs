using System;

// Token: 0x020002FE RID: 766
public static class YanvaniaGlobals
{
	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x060017BB RID: 6075 RVA: 0x000E350C File Offset: 0x000E170C
	// (set) Token: 0x060017BC RID: 6076 RVA: 0x000E353C File Offset: 0x000E173C
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

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017BD RID: 6077 RVA: 0x000E356C File Offset: 0x000E176C
	// (set) Token: 0x060017BE RID: 6078 RVA: 0x000E359C File Offset: 0x000E179C
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

	// Token: 0x060017BF RID: 6079 RVA: 0x000E35CC File Offset: 0x000E17CC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022E4 RID: 8932
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022E5 RID: 8933
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
