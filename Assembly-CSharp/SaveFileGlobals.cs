using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class SaveFileGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016E4 RID: 5860 RVA: 0x000DECD0 File Offset: 0x000DCED0
	// (set) Token: 0x060016E5 RID: 5861 RVA: 0x000DED00 File Offset: 0x000DCF00
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

	// Token: 0x060016E6 RID: 5862 RVA: 0x000DED30 File Offset: 0x000DCF30
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x04002259 RID: 8793
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
