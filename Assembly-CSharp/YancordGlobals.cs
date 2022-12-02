using UnityEngine;

public static class YancordGlobals
{
	private const string Str_JoinedYancord = "JoinedYancord";

	private const string Str_CurrentConversation = "CurrentConversation";

	public static bool JoinedYancord
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_JoinedYancord");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_JoinedYancord", value);
		}
	}

	public static int CurrentConversation
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_CurrentConversation");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CurrentConversation", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CurrentConversation");
	}
}
