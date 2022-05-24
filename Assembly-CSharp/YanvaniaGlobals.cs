using System;

// Token: 0x02000301 RID: 769
public static class YanvaniaGlobals
{
	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017D3 RID: 6099 RVA: 0x000E4718 File Offset: 0x000E2918
	// (set) Token: 0x060017D4 RID: 6100 RVA: 0x000E4748 File Offset: 0x000E2948
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

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x060017D5 RID: 6101 RVA: 0x000E4778 File Offset: 0x000E2978
	// (set) Token: 0x060017D6 RID: 6102 RVA: 0x000E47A8 File Offset: 0x000E29A8
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

	// Token: 0x060017D7 RID: 6103 RVA: 0x000E47D8 File Offset: 0x000E29D8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x0400230B RID: 8971
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x0400230C RID: 8972
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
