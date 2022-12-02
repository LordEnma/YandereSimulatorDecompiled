using UnityEngine;

public static class SaveFileGlobals
{
	private const string Str_CurrentSaveFile = "CurrentSaveFile";

	public static int CurrentSaveFile
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_CurrentSaveFile");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CurrentSaveFile", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CurrentSaveFile");
	}
}
