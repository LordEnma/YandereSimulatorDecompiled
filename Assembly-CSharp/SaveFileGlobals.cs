using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public static class SaveFileGlobals
{
	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x0600170D RID: 5901 RVA: 0x000E0D3C File Offset: 0x000DEF3C
	// (set) Token: 0x0600170E RID: 5902 RVA: 0x000E0D6C File Offset: 0x000DEF6C
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

	// Token: 0x0600170F RID: 5903 RVA: 0x000E0D9C File Offset: 0x000DEF9C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x040022B2 RID: 8882
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
