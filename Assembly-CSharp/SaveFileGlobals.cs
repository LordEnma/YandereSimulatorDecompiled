using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class SaveFileGlobals
{
	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x060016E6 RID: 5862 RVA: 0x000DEE74 File Offset: 0x000DD074
	// (set) Token: 0x060016E7 RID: 5863 RVA: 0x000DEEA4 File Offset: 0x000DD0A4
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

	// Token: 0x060016E8 RID: 5864 RVA: 0x000DEED4 File Offset: 0x000DD0D4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x0400225D RID: 8797
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
