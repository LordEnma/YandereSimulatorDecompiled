using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
public static class SaveFileGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016D8 RID: 5848 RVA: 0x000DDA90 File Offset: 0x000DBC90
	// (set) Token: 0x060016D9 RID: 5849 RVA: 0x000DDAC0 File Offset: 0x000DBCC0
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

	// Token: 0x060016DA RID: 5850 RVA: 0x000DDAF0 File Offset: 0x000DBCF0
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x0400222A RID: 8746
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
