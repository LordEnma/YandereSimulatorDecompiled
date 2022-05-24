using System;
using UnityEngine;

// Token: 0x020002ED RID: 749
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06001541 RID: 5441 RVA: 0x000DA110 File Offset: 0x000D8310
	// (set) Token: 0x06001542 RID: 5442 RVA: 0x000DA140 File Offset: 0x000D8340
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

	// Token: 0x06001543 RID: 5443 RVA: 0x000DA170 File Offset: 0x000D8370
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x040021ED RID: 8685
	private const string Str_VersionNumber = "VersionNumber";
}
