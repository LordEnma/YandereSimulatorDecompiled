using UnityEngine;

public static class ClubGlobals
{
	private const string Str_Club = "Club";

	private const string Str_ClubClosed = "ClubClosed_";

	private const string Str_ClubKicked = "ClubKicked_";

	private const string Str_QuitClub = "QuitClub_";

	private const string Str_ActivitiesAttended = "ActivitiesAttended_";

	public static ClubType Club
	{
		get
		{
			return GlobalsHelper.GetEnum<ClubType>("Profile_" + GameGlobals.Profile + "_Club");
		}
		set
		{
			GlobalsHelper.SetEnum("Profile_" + GameGlobals.Profile + "_Club", value);
		}
	}

	public static int ActivitiesAttended
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_ActivitiesAttended_");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_ActivitiesAttended_", value);
		}
	}

	public static bool GetClubClosed(ClubType clubID)
	{
		string text = GameGlobals.Profile.ToString();
		int num = (int)clubID;
		return GlobalsHelper.GetBool("Profile_" + text + "_ClubClosed_" + num);
	}

	public static void SetClubClosed(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_ClubClosed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ClubClosed_" + text, value);
	}

	public static ClubType[] KeysOfClubClosed()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile + "_ClubClosed_");
	}

	public static bool GetClubKicked(ClubType clubID)
	{
		string text = GameGlobals.Profile.ToString();
		int num = (int)clubID;
		return GlobalsHelper.GetBool("Profile_" + text + "_ClubKicked_" + num);
	}

	public static void SetClubKicked(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_ClubKicked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ClubKicked_" + text, value);
	}

	public static ClubType[] KeysOfClubKicked()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile + "_ClubKicked_");
	}

	public static bool GetQuitClub(ClubType clubID)
	{
		string text = GameGlobals.Profile.ToString();
		int num = (int)clubID;
		return GlobalsHelper.GetBool("Profile_" + text + "_QuitClub_" + num);
	}

	public static void SetQuitClub(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_QuitClub_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_QuitClub_" + text, value);
	}

	public static ClubType[] KeysOfQuitClub()
	{
		return KeysHelper.GetEnumKeys<ClubType>("Profile_" + GameGlobals.Profile + "_QuitClub_");
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Club");
		ClubType[] array = KeysOfClubClosed();
		foreach (ClubType clubType in array)
		{
			string text = GameGlobals.Profile.ToString();
			int num = (int)clubType;
			Globals.Delete("Profile_" + text + "_ClubClosed_" + num);
		}
		array = KeysOfClubKicked();
		foreach (ClubType clubType2 in array)
		{
			string text2 = GameGlobals.Profile.ToString();
			int num = (int)clubType2;
			Globals.Delete("Profile_" + text2 + "_ClubKicked_" + num);
		}
		array = KeysOfQuitClub();
		foreach (ClubType clubType3 in array)
		{
			string text3 = GameGlobals.Profile.ToString();
			int num = (int)clubType3;
			Globals.Delete("Profile_" + text3 + "_QuitClub_" + num);
		}
		KeysHelper.Delete("Profile_" + GameGlobals.Profile + "_ClubClosed_");
		KeysHelper.Delete("Profile_" + GameGlobals.Profile + "_ClubKicked_");
		KeysHelper.Delete("Profile_" + GameGlobals.Profile + "_QuitClub_");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ActivitiesAttended_");
	}
}
