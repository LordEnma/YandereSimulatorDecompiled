using System;

// Token: 0x02000300 RID: 768
public static class YanvaniaGlobals
{
	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017CF RID: 6095 RVA: 0x000E4254 File Offset: 0x000E2454
	// (set) Token: 0x060017D0 RID: 6096 RVA: 0x000E4284 File Offset: 0x000E2484
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
	// (get) Token: 0x060017D1 RID: 6097 RVA: 0x000E42B4 File Offset: 0x000E24B4
	// (set) Token: 0x060017D2 RID: 6098 RVA: 0x000E42E4 File Offset: 0x000E24E4
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

	// Token: 0x060017D3 RID: 6099 RVA: 0x000E4314 File Offset: 0x000E2514
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MidoriEasterEgg");
	}

	// Token: 0x04002300 RID: 8960
	private const string Str_DraculaDefeated = "DraculaDefeated";

	// Token: 0x04002301 RID: 8961
	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}
