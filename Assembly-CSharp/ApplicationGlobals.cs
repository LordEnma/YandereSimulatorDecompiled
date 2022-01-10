using System;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x0600151B RID: 5403 RVA: 0x000D7810 File Offset: 0x000D5A10
	// (set) Token: 0x0600151C RID: 5404 RVA: 0x000D7840 File Offset: 0x000D5A40
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

	// Token: 0x0600151D RID: 5405 RVA: 0x000D7870 File Offset: 0x000D5A70
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x04002185 RID: 8581
	private const string Str_VersionNumber = "VersionNumber";
}
