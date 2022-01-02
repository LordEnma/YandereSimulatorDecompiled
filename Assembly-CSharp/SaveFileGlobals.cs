using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class SaveFileGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016DF RID: 5855 RVA: 0x000DE4A0 File Offset: 0x000DC6A0
	// (set) Token: 0x060016E0 RID: 5856 RVA: 0x000DE4D0 File Offset: 0x000DC6D0
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

	// Token: 0x060016E1 RID: 5857 RVA: 0x000DE500 File Offset: 0x000DC700
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x0400224D RID: 8781
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
