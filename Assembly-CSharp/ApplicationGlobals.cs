using System;
using UnityEngine;

// Token: 0x020002EC RID: 748
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x0600153B RID: 5435 RVA: 0x000D97F4 File Offset: 0x000D79F4
	// (set) Token: 0x0600153C RID: 5436 RVA: 0x000D9824 File Offset: 0x000D7A24
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

	// Token: 0x0600153D RID: 5437 RVA: 0x000D9854 File Offset: 0x000D7A54
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x040021DA RID: 8666
	private const string Str_VersionNumber = "VersionNumber";
}
