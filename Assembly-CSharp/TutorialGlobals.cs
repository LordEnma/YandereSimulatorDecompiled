public static class TutorialGlobals
{
	private const string Str_IgnoreDistraction = "IgnoreDistraction";

	private const string Str_IgnoreClothing = "IgnoreClothing";

	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	private const string Str_IgnorePersona = "IgnorePersona";

	private const string Str_IgnoreLocker = "IgnoreLocker";

	private const string Str_IgnorePolice = "IgnorePolice";

	private const string Str_IgnoreSanity = "IgnoreSanity";

	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	private const string Str_IgnoreVision = "IgnoreVision";

	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	private const string Str_IgnoreBlood = "IgnoreBlood";

	private const string Str_IgnoreClass = "IgnoreClass";

	private const string Str_IgnoreMoney = "IgnoreMoney";

	private const string Str_IgnorePhoto = "IgnorePhoto";

	private const string Str_IgnoreClub = "IgnoreClub";

	private const string Str_IgnoreInfo = "IgnoreInfo";

	private const string Str_IgnorePool = "IgnorePool";

	private const string Str_IgnoreRep = "IgnoreClass";

	public static bool IgnoreDistraction
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreDistraction");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreDistraction", value);
		}
	}

	public static bool IgnoreClothing
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreClothing");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreClothing", value);
		}
	}

	public static bool IgnoreCouncil
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreCouncil");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreCouncil", value);
		}
	}

	public static bool IgnoreTeacher
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreTeacher");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreTeacher", value);
		}
	}

	public static bool IgnorePersona
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnorePersona");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnorePersona", value);
		}
	}

	public static bool IgnoreLocker
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreLocker");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreLocker", value);
		}
	}

	public static bool IgnorePolice
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnorePolice");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnorePolice", value);
		}
	}

	public static bool IgnoreSanity
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreSanity");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreSanity", value);
		}
	}

	public static bool IgnoreSenpai
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreSenpai");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreSenpai", value);
		}
	}

	public static bool IgnoreVision
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreVision");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreVision", value);
		}
	}

	public static bool IgnoreWeapon
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreWeapon");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreWeapon", value);
		}
	}

	public static bool IgnoreBlood
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreBlood");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreBlood", value);
		}
	}

	public static bool IgnoreClass
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreClass");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreClass", value);
		}
	}

	public static bool IgnoreMoney
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreMoney");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreMoney", value);
		}
	}

	public static bool IgnorePhoto
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnorePhoto");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnorePhoto", value);
		}
	}

	public static bool IgnoreClub
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreClub");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreClub", value);
		}
	}

	public static bool IgnoreInfo
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreInfo");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreInfo", value);
		}
	}

	public static bool IgnorePool
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnorePool");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnorePool", value);
		}
	}

	public static bool IgnoreRep
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_IgnoreClass");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_IgnoreClass", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreDistraction");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreClothing");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreCouncil");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreTeacher");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnorePersona");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreLocker");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnorePolice");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreSanity");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreSenpai");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreVision");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreWeapon");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreBlood");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreClass");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreMoney");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnorePhoto");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreClub");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreInfo");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnorePool");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_IgnoreClass");
	}
}
