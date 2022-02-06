using System;

// Token: 0x020002FC RID: 764
public static class YanvaniaGlobals
{
	// Token: 0x17000446 RID: 1094
	// (get) Token: 0x060017A6 RID: 6054 RVA: 0x000E22D8 File Offset: 0x000E04D8
	// (set) Token: 0x060017A7 RID: 6055 RVA: 0x000E2308 File Offset: 0x000E0508
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

	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x060017A8 RID: 6056 RVA: 0x000E2338 File Offset: 0x000E0538
	// (set) Token: 0x060017A9 RID: 6057 RVA: 0x000E2368 File Offset: 0x000E0568
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

	// Token: 0x060017AA RID: 6058 RVA: 0x000E2398 File Offset: 0x000E0598
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x040022AA RID: 8874
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x040022AB RID: 8875
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
