using System;

// Token: 0x020002FC RID: 764
public static class YanvaniaGlobals
{
	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x060017A3 RID: 6051 RVA: 0x000E1D18 File Offset: 0x000DFF18
	// (set) Token: 0x060017A4 RID: 6052 RVA: 0x000E1D48 File Offset: 0x000DFF48
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
	// (get) Token: 0x060017A5 RID: 6053 RVA: 0x000E1D78 File Offset: 0x000DFF78
	// (set) Token: 0x060017A6 RID: 6054 RVA: 0x000E1DA8 File Offset: 0x000DFFA8
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

	// Token: 0x060017A7 RID: 6055 RVA: 0x000E1DD8 File Offset: 0x000DFFD8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022A1 RID: 8865
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022A2 RID: 8866
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
