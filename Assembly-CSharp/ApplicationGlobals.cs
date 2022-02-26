using System;
using UnityEngine;

// Token: 0x020002EA RID: 746
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x0600152A RID: 5418 RVA: 0x000D885C File Offset: 0x000D6A5C
	// (set) Token: 0x0600152B RID: 5419 RVA: 0x000D888C File Offset: 0x000D6A8C
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

	// Token: 0x0600152C RID: 5420 RVA: 0x000D88BC File Offset: 0x000D6ABC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x040021A4 RID: 8612
	private const string Str_VersionNumber = "VersionNumber";
}
