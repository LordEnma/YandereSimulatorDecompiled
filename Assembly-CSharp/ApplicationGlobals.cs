using System;
using UnityEngine;

// Token: 0x020002E7 RID: 743
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06001517 RID: 5399 RVA: 0x000D74E8 File Offset: 0x000D56E8
	// (set) Token: 0x06001518 RID: 5400 RVA: 0x000D7518 File Offset: 0x000D5718
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

	// Token: 0x06001519 RID: 5401 RVA: 0x000D7548 File Offset: 0x000D5748
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x04002181 RID: 8577
	private const string Str_VersionNumber = "VersionNumber";
}
