using System;
using UnityEngine;

// Token: 0x020002F8 RID: 760
public static class SaveFileGlobals
{
	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x060016F6 RID: 5878 RVA: 0x000DF8CC File Offset: 0x000DDACC
	// (set) Token: 0x060016F7 RID: 5879 RVA: 0x000DF8FC File Offset: 0x000DDAFC
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

	// Token: 0x060016F8 RID: 5880 RVA: 0x000DF92C File Offset: 0x000DDB2C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x04002272 RID: 8818
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
