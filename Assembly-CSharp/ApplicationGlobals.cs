using System;
using UnityEngine;

// Token: 0x020002EA RID: 746
public static class ApplicationGlobals
{
	// Token: 0x1700036F RID: 879
	// (get) Token: 0x0600152D RID: 5421 RVA: 0x000D8FFC File Offset: 0x000D71FC
	// (set) Token: 0x0600152E RID: 5422 RVA: 0x000D902C File Offset: 0x000D722C
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

	// Token: 0x0600152F RID: 5423 RVA: 0x000D905C File Offset: 0x000D725C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VersionNumber");
	}

	// Token: 0x040021C8 RID: 8648
	private const string Str_VersionNumber = "VersionNumber";
}
