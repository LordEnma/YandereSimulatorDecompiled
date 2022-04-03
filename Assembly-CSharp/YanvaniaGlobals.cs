using System;

// Token: 0x020002FF RID: 767
public static class YanvaniaGlobals
{
	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x060017C1 RID: 6081 RVA: 0x000E3A0C File Offset: 0x000E1C0C
	// (set) Token: 0x060017C2 RID: 6082 RVA: 0x000E3A3C File Offset: 0x000E1C3C
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
	// (get) Token: 0x060017C3 RID: 6083 RVA: 0x000E3A6C File Offset: 0x000E1C6C
	// (set) Token: 0x060017C4 RID: 6084 RVA: 0x000E3A9C File Offset: 0x000E1C9C
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

	// Token: 0x060017C5 RID: 6085 RVA: 0x000E3ACC File Offset: 0x000E1CCC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022F2 RID: 8946
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022F3 RID: 8947
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
