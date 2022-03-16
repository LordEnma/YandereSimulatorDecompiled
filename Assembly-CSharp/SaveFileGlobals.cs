using System;
using UnityEngine;

// Token: 0x020002F8 RID: 760
public static class SaveFileGlobals
{
	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x060016FB RID: 5883 RVA: 0x000E00A8 File Offset: 0x000DE2A8
	// (set) Token: 0x060016FC RID: 5884 RVA: 0x000E00D8 File Offset: 0x000DE2D8
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

	// Token: 0x060016FD RID: 5885 RVA: 0x000E0108 File Offset: 0x000DE308
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x04002297 RID: 8855
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
