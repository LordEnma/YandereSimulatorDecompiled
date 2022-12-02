using System;
using UnityEngine;

public static class DateGlobals
{
	private const string Str_Week = "Week";

	private const string Str_Weekday = "Weekday";

	private const string Str_PassDays = "PassDays";

	private const string Str_DayPassed = "DayPassed";

	private const string Str_GameplayDay = "GameplayDay";

	private const string Str_ForceSkip = "ForceSkip";

	public static int Week
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Week");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Week", value);
		}
	}

	public static DayOfWeek Weekday
	{
		get
		{
			return GlobalsHelper.GetEnum<DayOfWeek>("Profile_" + GameGlobals.Profile + "_Weekday");
		}
		set
		{
			GlobalsHelper.SetEnum("Profile_" + GameGlobals.Profile + "_Weekday", value);
		}
	}

	public static int PassDays
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PassDays");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PassDays", value);
		}
	}

	public static bool DayPassed
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_DayPassed");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_DayPassed", value);
		}
	}

	public static int GameplayDay
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_GameplayDay");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_GameplayDay", value);
		}
	}

	public static bool ForceSkip
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_ForceSkip");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ForceSkip", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ForceSkip");
	}
}
