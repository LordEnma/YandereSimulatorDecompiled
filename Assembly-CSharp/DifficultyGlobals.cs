public static class DifficultyGlobals
{
	private const string Str_InvincibleRaibaru = "InvincibleRaibaru";

	private const string Str_NoCase = "NoCase";

	private const string Str_TransparentFence = "TransparentFence";

	private const string Str_MustStrangle = "MustStrangle";

	private const string Str_MudRequired = "MudRequired";

	private const string Str_CraftBodybags = "CraftBodybags";

	private const string Str_WeaponsBreak = "WeaponsBreak";

	public static bool InvincibleRaibaru
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_InvincibleRaibaru");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_InvincibleRaibaru", value);
		}
	}

	public static bool NoCase
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_NoCase");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_NoCase", value);
		}
	}

	public static bool TransparentFence
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_TransparentFence");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_TransparentFence", value);
		}
	}

	public static bool MustStrangle
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_MustStrangle");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_MustStrangle", value);
		}
	}

	public static bool MudRequired
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_MudRequired");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_MudRequired", value);
		}
	}

	public static bool CraftBodybags
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_CraftBodybags");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_CraftBodybags", value);
		}
	}

	public static bool WeaponsBreak
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_WeaponsBreak");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_WeaponsBreak", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_InvincibleRaibaru");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_NoCase");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_TransparentFence");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MustStrangle");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MudRequired");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CraftBodybags");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_WeaponsBreak");
	}
}
