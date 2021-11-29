using System;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06001510 RID: 5392 RVA: 0x000D6AD8 File Offset: 0x000D4CD8
	// (set) Token: 0x06001511 RID: 5393 RVA: 0x000D6B08 File Offset: 0x000D4D08
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

	// Token: 0x06001512 RID: 5394 RVA: 0x000D6B38 File Offset: 0x000D4D38
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x0400215E RID: 8542
	private const string Str_VersionNumber = "VersionNumber";
}
