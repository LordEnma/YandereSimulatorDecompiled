using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class SaveFileGlobals
{
	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x06001701 RID: 5889 RVA: 0x000E05A8 File Offset: 0x000DE7A8
	// (set) Token: 0x06001702 RID: 5890 RVA: 0x000E05D8 File Offset: 0x000DE7D8
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

	// Token: 0x06001703 RID: 5891 RVA: 0x000E0608 File Offset: 0x000DE808
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x040022A5 RID: 8869
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
