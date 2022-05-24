using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class SaveFileGlobals
{
	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x06001711 RID: 5905 RVA: 0x000E1234 File Offset: 0x000DF434
	// (set) Token: 0x06001712 RID: 5906 RVA: 0x000E1264 File Offset: 0x000DF464
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

	// Token: 0x06001713 RID: 5907 RVA: 0x000E1294 File Offset: 0x000DF494
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x040022BD RID: 8893
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
