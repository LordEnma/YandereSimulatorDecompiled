using System;

// Token: 0x02000300 RID: 768
public static class YanvaniaGlobals
{
	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x060017C7 RID: 6087 RVA: 0x000E3B1C File Offset: 0x000E1D1C
	// (set) Token: 0x060017C8 RID: 6088 RVA: 0x000E3B4C File Offset: 0x000E1D4C
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
	// (get) Token: 0x060017C9 RID: 6089 RVA: 0x000E3B7C File Offset: 0x000E1D7C
	// (set) Token: 0x060017CA RID: 6090 RVA: 0x000E3BAC File Offset: 0x000E1DAC
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

	// Token: 0x060017CB RID: 6091 RVA: 0x000E3BDC File Offset: 0x000E1DDC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022F4 RID: 8948
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022F5 RID: 8949
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
