public static class EventGlobals
{
	private const string Str_BefriendConversation = "BefriendConversation";

	private const string Str_StalkerConversation = "StalkerConversation";

	private const string Str_KidnapConversation = "KidnapConversation";

	private const string Str_OsanaConversation = "OsanaConversation";

	private const string Str_Event1 = "Event1";

	private const string Str_Event2 = "Event2";

	private const string Str_OsanaEvent1 = "OsanaEvent1";

	private const string Str_OsanaEvent2 = "OsanaEvent2";

	private const string Str_LivingRoom = "LivingRoom";

	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";

	public static bool BefriendConversation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_BefriendConversation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_BefriendConversation", value);
		}
	}

	public static bool StalkerConversation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_StalkerConversation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_StalkerConversation", value);
		}
	}

	public static bool KidnapConversation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_KidnapConversation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_KidnapConversation", value);
		}
	}

	public static bool OsanaConversation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_OsanaConversation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_OsanaConversation", value);
		}
	}

	public static bool OsanaEvent1
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_OsanaEvent1");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_OsanaEvent1", value);
		}
	}

	public static bool OsanaEvent2
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_OsanaEvent2");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_OsanaEvent2", value);
		}
	}

	public static bool Event1
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_Event1");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_Event1", value);
		}
	}

	public static bool Event2
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_Event2");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_Event2", value);
		}
	}

	public static bool LivingRoom
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_LivingRoom");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_LivingRoom", value);
		}
	}

	public static bool LearnedAboutPhotographer
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_LearnedAboutPhotographer");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_LearnedAboutPhotographer", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BefriendConversation");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_StalkerConversation");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_KidnapConversation");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_OsanaConversation");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_OsanaEvent1");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_OsanaEvent2");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Event1");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Event2");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_LivingRoom");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_LearnedAboutPhotographer");
	}
}
