using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class SaveFileGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016E4 RID: 5860 RVA: 0x000DED88 File Offset: 0x000DCF88
	// (set) Token: 0x060016E5 RID: 5861 RVA: 0x000DEDB8 File Offset: 0x000DCFB8
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

	// Token: 0x060016E6 RID: 5862 RVA: 0x000DEDE8 File Offset: 0x000DCFE8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x0400225A RID: 8794
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
