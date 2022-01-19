using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class SaveFileGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016E3 RID: 5859 RVA: 0x000DE8B4 File Offset: 0x000DCAB4
	// (set) Token: 0x060016E4 RID: 5860 RVA: 0x000DE8E4 File Offset: 0x000DCAE4
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

	// Token: 0x060016E5 RID: 5861 RVA: 0x000DE914 File Offset: 0x000DCB14
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x04002254 RID: 8788
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
