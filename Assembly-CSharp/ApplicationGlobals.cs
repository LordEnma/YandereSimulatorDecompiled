using System;
using UnityEngine;

// Token: 0x020002EC RID: 748
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06001539 RID: 5433 RVA: 0x000D960C File Offset: 0x000D780C
	// (set) Token: 0x0600153A RID: 5434 RVA: 0x000D963C File Offset: 0x000D783C
	public static float VersionNumber
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber", value);
		}
	}

	// Token: 0x0600153B RID: 5435 RVA: 0x000D966C File Offset: 0x000D786C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x040021D8 RID: 8664
	private const string Str_VersionNumber = "VersionNumber";
}
