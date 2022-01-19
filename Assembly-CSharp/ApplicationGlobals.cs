using System;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x0600151B RID: 5403 RVA: 0x000D78FC File Offset: 0x000D5AFC
	// (set) Token: 0x0600151C RID: 5404 RVA: 0x000D792C File Offset: 0x000D5B2C
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

	// Token: 0x0600151D RID: 5405 RVA: 0x000D795C File Offset: 0x000D5B5C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x04002188 RID: 8584
	private const string Str_VersionNumber = "VersionNumber";
}
