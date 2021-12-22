using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class SaveFileGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016DF RID: 5855 RVA: 0x000DE250 File Offset: 0x000DC450
	// (set) Token: 0x060016E0 RID: 5856 RVA: 0x000DE280 File Offset: 0x000DC480
	public static int CurrentSaveFile
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile", value);
		}
	}

	// Token: 0x060016E1 RID: 5857 RVA: 0x000DE2B0 File Offset: 0x000DC4B0
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x0400224A RID: 8778
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
