using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public static class SaveFileGlobals
{
	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x06001709 RID: 5897 RVA: 0x000E08A0 File Offset: 0x000DEAA0
	// (set) Token: 0x0600170A RID: 5898 RVA: 0x000E08D0 File Offset: 0x000DEAD0
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

	// Token: 0x0600170B RID: 5899 RVA: 0x000E0900 File Offset: 0x000DEB00
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x040022A9 RID: 8873
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
