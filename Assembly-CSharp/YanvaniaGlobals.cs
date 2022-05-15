using System;

// Token: 0x02000301 RID: 769
public static class YanvaniaGlobals
{
	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017D3 RID: 6099 RVA: 0x000E459C File Offset: 0x000E279C
	// (set) Token: 0x060017D4 RID: 6100 RVA: 0x000E45CC File Offset: 0x000E27CC
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
	// (get) Token: 0x060017D5 RID: 6101 RVA: 0x000E45FC File Offset: 0x000E27FC
	// (set) Token: 0x060017D6 RID: 6102 RVA: 0x000E462C File Offset: 0x000E282C
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

	// Token: 0x060017D7 RID: 6103 RVA: 0x000E465C File Offset: 0x000E285C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x0400230A RID: 8970
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x0400230B RID: 8971
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
