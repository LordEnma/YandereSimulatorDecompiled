public static class YanvaniaGlobals
{
	private const string Str_DraculaDefeated = "DraculaDefeated";

	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";

	public static bool DraculaDefeated
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_DraculaDefeated");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_DraculaDefeated", value);
		}
	}

	public static bool MidoriEasterEgg
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_MidoriEasterEgg");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_MidoriEasterEgg", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DraculaDefeated");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MidoriEasterEgg");
	}
}
