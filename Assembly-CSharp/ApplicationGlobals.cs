using System;
using UnityEngine;

// Token: 0x020002EB RID: 747
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06001533 RID: 5427 RVA: 0x000D94FC File Offset: 0x000D76FC
	// (set) Token: 0x06001534 RID: 5428 RVA: 0x000D952C File Offset: 0x000D772C
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

	// Token: 0x06001535 RID: 5429 RVA: 0x000D955C File Offset: 0x000D775C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x040021D6 RID: 8662
	private const string Str_VersionNumber = "VersionNumber";
}
