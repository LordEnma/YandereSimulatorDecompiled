public static class ChallengeGlobals
{
	private const string Str_KnifeOnly = "KnifeOnly";

	private const string Str_NoAlerts = "NoAlerts";

	private const string Str_NoBag = "NoBag";

	private const string Str_NoFriends = "NoFriends";

	private const string Str_NoGaming = "NoGaming";

	private const string Str_NoInfo = "NoInfo";

	private const string Str_NoLaugh = "NoLaugh";

	private const string Str_RivalsOnly = "RivalsOnly";

	public static bool KnifeOnly
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_KnifeOnly");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_KnifeOnly", value);
		}
	}

	public static bool NoAlerts
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_NoAlerts");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_NoAlerts", value);
		}
	}

	public static bool NoBag
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_NoBag");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_NoBag", value);
		}
	}

	public static bool NoFriends
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_NoFriends");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_NoFriends", value);
		}
	}

	public static bool NoGaming
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_NoGaming");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_NoGaming", value);
		}
	}

	public static bool NoInfo
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_NoInfo");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_NoInfo", value);
		}
	}

	public static bool NoLaugh
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_NoLaugh");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_NoLaugh", value);
		}
	}

	public static bool RivalsOnly
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_RivalsOnly");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_RivalsOnly", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_KnifeOnly");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NoAlerts");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NoBag");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NoFriends");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NoGaming");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NoInfo");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NoLaugh");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_RivalsOnly");
	}
}
