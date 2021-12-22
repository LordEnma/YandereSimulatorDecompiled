using System;
using UnityEngine;

// Token: 0x020002E7 RID: 743
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06001517 RID: 5399 RVA: 0x000D7298 File Offset: 0x000D5498
	// (set) Token: 0x06001518 RID: 5400 RVA: 0x000D72C8 File Offset: 0x000D54C8
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

	// Token: 0x06001519 RID: 5401 RVA: 0x000D72F8 File Offset: 0x000D54F8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x0400217E RID: 8574
	private const string Str_VersionNumber = "VersionNumber";
}
