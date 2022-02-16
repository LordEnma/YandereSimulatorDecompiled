using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class SaveFileGlobals
{
	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x060016ED RID: 5869 RVA: 0x000DEFE8 File Offset: 0x000DD1E8
	// (set) Token: 0x060016EE RID: 5870 RVA: 0x000DF018 File Offset: 0x000DD218
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

	// Token: 0x060016EF RID: 5871 RVA: 0x000DF048 File Offset: 0x000DD248
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentSaveFile");
	}

	// Token: 0x04002263 RID: 8803
	private const string Str_CurrentSaveFile = "CurrentSaveFile";
}
