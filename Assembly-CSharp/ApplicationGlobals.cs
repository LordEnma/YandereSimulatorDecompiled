using System;
using UnityEngine;

// Token: 0x020002EC RID: 748
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x0600153F RID: 5439 RVA: 0x000D9C90 File Offset: 0x000D7E90
	// (set) Token: 0x06001540 RID: 5440 RVA: 0x000D9CC0 File Offset: 0x000D7EC0
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

	// Token: 0x06001541 RID: 5441 RVA: 0x000D9CF0 File Offset: 0x000D7EF0
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x040021E3 RID: 8675
	private const string Str_VersionNumber = "VersionNumber";
}
