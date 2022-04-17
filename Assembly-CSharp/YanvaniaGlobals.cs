using System;

// Token: 0x02000300 RID: 768
public static class YanvaniaGlobals
{
	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017CB RID: 6091 RVA: 0x000E3D84 File Offset: 0x000E1F84
	// (set) Token: 0x060017CC RID: 6092 RVA: 0x000E3DB4 File Offset: 0x000E1FB4
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

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017CD RID: 6093 RVA: 0x000E3DE4 File Offset: 0x000E1FE4
	// (set) Token: 0x060017CE RID: 6094 RVA: 0x000E3E14 File Offset: 0x000E2014
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

	// Token: 0x060017CF RID: 6095 RVA: 0x000E3E44 File Offset: 0x000E2044
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022F7 RID: 8951
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022F8 RID: 8952
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
