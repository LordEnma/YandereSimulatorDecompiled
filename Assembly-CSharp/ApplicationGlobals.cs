using System;
using UnityEngine;

// Token: 0x020002E9 RID: 745
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06001521 RID: 5409 RVA: 0x000D7F78 File Offset: 0x000D6178
	// (set) Token: 0x06001522 RID: 5410 RVA: 0x000D7FA8 File Offset: 0x000D61A8
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

	// Token: 0x06001523 RID: 5411 RVA: 0x000D7FD8 File Offset: 0x000D61D8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x04002195 RID: 8597
	private const string Str_VersionNumber = "VersionNumber";
}
