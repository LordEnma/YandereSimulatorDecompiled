using System;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x0600151C RID: 5404 RVA: 0x000D7E84 File Offset: 0x000D6084
	// (set) Token: 0x0600151D RID: 5405 RVA: 0x000D7EB4 File Offset: 0x000D60B4
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

	// Token: 0x0600151E RID: 5406 RVA: 0x000D7EE4 File Offset: 0x000D60E4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x04002190 RID: 8592
	private const string Str_VersionNumber = "VersionNumber";
}
