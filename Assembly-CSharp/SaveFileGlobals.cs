using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public static class SaveFileGlobals
{
	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x06001707 RID: 5895 RVA: 0x000E06B8 File Offset: 0x000DE8B8
	// (set) Token: 0x06001708 RID: 5896 RVA: 0x000E06E8 File Offset: 0x000DE8E8
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

	// Token: 0x06001709 RID: 5897 RVA: 0x000E0718 File Offset: 0x000DE918
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x040022A7 RID: 8871
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
