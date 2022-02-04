using System;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x0600151C RID: 5404 RVA: 0x000D7DD0 File Offset: 0x000D5FD0
	// (set) Token: 0x0600151D RID: 5405 RVA: 0x000D7E00 File Offset: 0x000D6000
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

	// Token: 0x0600151E RID: 5406 RVA: 0x000D7E30 File Offset: 0x000D6030
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x0400218E RID: 8590
	private const string Str_VersionNumber = "VersionNumber";
}
