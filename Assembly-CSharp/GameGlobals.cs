using UnityEngine;

public static class GameGlobals
{
	private const string Str_Profile = "Profile";

	private const string Str_MostRecentSlot = "MostRecentSlot";

	private const string Str_LoveSick = "LoveSick";

	private const string Str_MasksBanned = "MasksBanned";

	private const string Str_Paranormal = "Paranormal";

	private const string Str_EasyMode = "EasyMode";

	private const string Str_HardMode = "HardMode";

	private const string Str_EmptyDemon = "EmptyDemon";

	private const string Str_CensorBlood = "CensorBlood";

	private const string Str_CensorPanties = "CensorPanties";

	private const string Str_CensorKillingAnims = "CensorKillingAnims";

	private const string Str_SpareUniform = "SpareUniform";

	private const string Str_BlondeHair = "BlondeHair";

	private const string Str_SenpaiMourning = "SenpaiMourning";

	private const string Str_RivalEliminationID = "RivalEliminationID";

	private const string Str_SpecificEliminationID = "SpecificEliminationID";

	private const string Str_NonlethalElimination = "NonlethalElimination";

	private const string Str_ReputationsInitialized = "ReputationsInitialized";

	private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";

	private const string Str_AlphabetMode = "AlphabetMode";

	private const string Str_PoliceYesterday = "PoliceYesterday";

	private const string Str_DarkEnding = "DarkEnding";

	private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";

	private const string Str_TransitionToPostCredits = "TransitionToPostCredits";

	private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";

	private const string Str_InformedAboutSkipping = "InformedAboutSkipping";

	private const string Str_RingStolen = "RingStolen";

	private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";

	private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";

	private const string Str_EightiesCutsceneID = "EightiesCutsceneID";

	private const string Str_EightiesTutorial = "EightiesTutorial";

	private const string Str_Eighties = "Eighties";

	private const string Str_YakuzaPhase = "YakuzaPhase";

	private const string Str_MetBarber = "MetBarber";

	private const string Str_Debug = "Debug";

	private const string Str_RivalEliminations = "RivalEliminations";

	private const string Str_SpecificEliminations = "SpecificEliminations";

	private const string Str_IntroducedAbduction = "IntroducedAbduction";

	private const string Str_IntroducedRansom = "IntroducedRansom";

	private const string Str_TrueEnding = "TrueEnding";

	private const string Str_JustKidnapped = "JustKidnapped";

	private const string Str_ShowAbduction = "ShowAbduction";

	private const string Str_AbductionTarget = "AbductionTarget";

	private const string Str_CameFromTitleScreen = "CameFromTitleScreen";

	private const string Str_VtuberID = "VtuberID";

	private const string Str_GrudgeConversationHappened = "GrudgeConversationHappened";

	private const string Str_ItemRemoved = "ItemRemoved";

	public static int Profile
	{
		get
		{
			return PlayerPrefs.GetInt("Profile");
		}
		set
		{
			PlayerPrefs.SetInt("Profile", value);
		}
	}

	public static int MostRecentSlot
	{
		get
		{
			return PlayerPrefs.GetInt("MostRecentSlot");
		}
		set
		{
			PlayerPrefs.SetInt("MostRecentSlot", value);
		}
	}

	public static bool LoveSick
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_LoveSick");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_LoveSick", value);
		}
	}

	public static bool MasksBanned
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_MasksBanned");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_MasksBanned", value);
		}
	}

	public static bool Paranormal
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_Paranormal");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_Paranormal", value);
		}
	}

	public static bool EasyMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_EasyMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_EasyMode", value);
		}
	}

	public static bool HardMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_HardMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_HardMode", value);
		}
	}

	public static bool EmptyDemon
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_EmptyDemon");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_EmptyDemon", value);
		}
	}

	public static bool CensorBlood
	{
		get
		{
			return GlobalsHelper.GetBool("Profile__CensorBlood");
		}
		set
		{
			GlobalsHelper.SetBool("Profile__CensorBlood", value);
		}
	}

	public static bool CensorPanties
	{
		get
		{
			return GlobalsHelper.GetBool("Profile__CensorPanties");
		}
		set
		{
			GlobalsHelper.SetBool("Profile__CensorPanties", value);
		}
	}

	public static bool CensorKillingAnims
	{
		get
		{
			return GlobalsHelper.GetBool("Profile__CensorKillingAnims");
		}
		set
		{
			GlobalsHelper.SetBool("Profile__CensorKillingAnims", value);
		}
	}

	public static bool SpareUniform
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_SpareUniform");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_SpareUniform", value);
		}
	}

	public static bool BlondeHair
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_BlondeHair");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_BlondeHair", value);
		}
	}

	public static bool SenpaiMourning
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_SenpaiMourning");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_SenpaiMourning", value);
		}
	}

	public static int RivalEliminationID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + Profile + "_RivalEliminationID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + Profile + "_RivalEliminationID", value);
		}
	}

	public static int SpecificEliminationID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + Profile + "_SpecificEliminationID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + Profile + "_SpecificEliminationID", value);
		}
	}

	public static bool NonlethalElimination
	{
		get
		{
			return GlobalsHelper.GetBool("NonlethalElimination");
		}
		set
		{
			GlobalsHelper.SetBool("NonlethalElimination", value);
		}
	}

	public static bool ReputationsInitialized
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_ReputationsInitialized");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_ReputationsInitialized", value);
		}
	}

	public static bool AnswerSheetUnavailable
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_AnswerSheetUnavailable");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_AnswerSheetUnavailable", value);
		}
	}

	public static bool AlphabetMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_AlphabetMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_AlphabetMode", value);
		}
	}

	public static bool PoliceYesterday
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_PoliceYesterday");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_PoliceYesterday", value);
		}
	}

	public static bool DarkEnding
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_DarkEnding");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_DarkEnding", value);
		}
	}

	public static bool SenpaiSawOsanaCorpse
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_SenpaiSawOsanaCorpse");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_SenpaiSawOsanaCorpse", value);
		}
	}

	public static bool TransitionToPostCredits
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_TransitionToPostCredits");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_TransitionToPostCredits", value);
		}
	}

	public static bool PlayerHasBeatenDemo
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_PlayerHasBeatenDemo");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_PlayerHasBeatenDemo", value);
		}
	}

	public static bool InformedAboutSkipping
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_InformedAboutSkipping");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_InformedAboutSkipping", value);
		}
	}

	public static bool RingStolen
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_RingStolen");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_RingStolen", value);
		}
	}

	public static int BeatEmUpDifficulty
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + Profile + "_BeatEmUpDifficulty");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + Profile + "_BeatEmUpDifficulty", value);
		}
	}

	public static bool BeatEmUpSuccess
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_BeatEmUpSuccess");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_BeatEmUpSuccess", value);
		}
	}

	public static int EightiesCutsceneID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + Profile + "_EightiesCutsceneID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + Profile + "_EightiesCutsceneID", value);
		}
	}

	public static bool EightiesTutorial
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_EightiesTutorial");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_EightiesTutorial", value);
		}
	}

	public static bool Eighties
	{
		get
		{
			return GlobalsHelper.GetBool("Eighties");
		}
		set
		{
			GlobalsHelper.SetBool("Eighties", value);
		}
	}

	public static int YakuzaPhase
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + Profile + "_YakuzaPhase");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + Profile + "_YakuzaPhase", value);
		}
	}

	public static bool MetBarber
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_MetBarber");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_MetBarber", value);
		}
	}

	public static bool IntroducedAbduction
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_IntroducedAbduction");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_IntroducedAbduction", value);
		}
	}

	public static bool IntroducedRansom
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_IntroducedRansom");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_IntroducedRansom", value);
		}
	}

	public static bool Debug
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_Debug");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_Debug", value);
		}
	}

	public static bool TrueEnding
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_TrueEnding");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_TrueEnding", value);
		}
	}

	public static bool JustKidnapped
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_JustKidnapped");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_JustKidnapped", value);
		}
	}

	public static bool ShowAbduction
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + Profile + "_ShowAbduction");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + Profile + "_ShowAbduction", value);
		}
	}

	public static int AbductionTarget
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + Profile + "_AbductionTarget");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + Profile + "_AbductionTarget", value);
		}
	}

	public static bool CameFromTitleScreen
	{
		get
		{
			return GlobalsHelper.GetBool("CameFromTitleScreen");
		}
		set
		{
			GlobalsHelper.SetBool("CameFromTitleScreen", value);
		}
	}

	public static bool GrudgeConversationHappened
	{
		get
		{
			return GlobalsHelper.GetBool("GrudgeConversationHappened");
		}
		set
		{
			GlobalsHelper.SetBool("GrudgeConversationHappened", value);
		}
	}

	public static int VtuberID
	{
		get
		{
			return PlayerPrefs.GetInt("VtuberID");
		}
		set
		{
			PlayerPrefs.SetInt("VtuberID", value);
		}
	}

	public static int GetRivalEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + Profile + "_RivalEliminations" + elimID);
	}

	public static void SetRivalEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + Profile + "_RivalEliminations", text);
		PlayerPrefs.SetInt("Profile_" + Profile + "_RivalEliminations" + text, value);
	}

	public static int[] KeysOfRivalEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + Profile + "_RivalEliminations");
	}

	public static int GetSpecificEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + Profile + "_SpecificEliminations" + elimID);
	}

	public static void SetSpecificEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + Profile + "_SpecificEliminations", text);
		PlayerPrefs.SetInt("Profile_" + Profile + "_SpecificEliminations" + text, value);
	}

	public static int[] KeysOfSpecificEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + Profile + "_SpecificEliminations");
	}

	public static int GetItemRemoved(int itemID)
	{
		return PlayerPrefs.GetInt("Profile_" + Profile + "_ItemRemoved" + itemID);
	}

	public static void SetItemRemoved(int itemID, int value)
	{
		string text = itemID.ToString();
		KeysHelper.AddIfMissing("Profile_" + Profile + "_ItemRemoved", text);
		PlayerPrefs.SetInt("Profile_" + Profile + "_ItemRemoved" + text, value);
	}

	public static int[] KeysOfItemRemoved()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + Profile + "_ItemRemoved");
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + Profile + "_LoveSick");
		Globals.Delete("Profile_" + Profile + "_MasksBanned");
		Globals.Delete("Profile_" + Profile + "_Paranormal");
		Globals.Delete("Profile_" + Profile + "_EasyMode");
		Globals.Delete("Profile_" + Profile + "_HardMode");
		Globals.Delete("Profile_" + Profile + "_EmptyDemon");
		Globals.Delete("Profile_" + Profile + "_CensorBlood");
		Globals.Delete("Profile_" + Profile + "_CensorPanties");
		Globals.Delete("Profile_" + Profile + "_CensorKillingAnims");
		Globals.Delete("Profile_" + Profile + "_SpareUniform");
		Globals.Delete("Profile_" + Profile + "_BlondeHair");
		Globals.Delete("Profile_" + Profile + "_SenpaiMourning");
		Globals.Delete("Profile_" + Profile + "_RivalEliminationID");
		Globals.Delete("Profile_" + Profile + "_SpecificEliminationID");
		Globals.Delete("Profile_" + Profile + "_NonlethalElimination");
		Globals.Delete("Profile_" + Profile + "_ReputationsInitialized");
		Globals.Delete("Profile_" + Profile + "_AnswerSheetUnavailable");
		Globals.Delete("Profile_" + Profile + "_AlphabetMode");
		Globals.Delete("Profile_" + Profile + "_PoliceYesterday");
		Globals.Delete("Profile_" + Profile + "_DarkEnding");
		Globals.Delete("Profile_" + Profile + "_MostRecentSlot");
		Globals.Delete("Profile_" + Profile + "_SenpaiSawOsanaCorpse");
		Globals.Delete("Profile_" + Profile + "_TransitionToPostCredits");
		Globals.Delete("Profile_" + Profile + "_PlayerHasBeatenDemo");
		Globals.Delete("Profile_" + Profile + "_InformedAboutSkipping");
		Globals.Delete("Profile_" + Profile + "_RingStolen");
		Globals.Delete("Profile_" + Profile + "_BeatEmUpDifficulty");
		Globals.Delete("Profile_" + Profile + "_BeatEmUpSuccess");
		Globals.Delete("Profile_" + Profile + "_YakuzaPhase");
		Globals.Delete("Profile_" + Profile + "_MetBarber");
		Globals.Delete("Profile_" + Profile + "_Debug");
		Globals.Delete("Profile_" + Profile + "_IntroducedAbduction");
		Globals.Delete("Profile_" + Profile + "_IntroducedRansom");
		Globals.Delete("Profile_" + Profile + "_EightiesCutsceneID");
		Globals.Delete("Profile_" + Profile + "_EightiesTutorial");
		Globals.Delete("Profile_" + Profile + "_Eighties");
		Globals.Delete("Profile_" + Profile + "_TrueEnding");
		Globals.Delete("Profile_" + Profile + "_JustKidnapped");
		Globals.Delete("Profile_" + Profile + "_ShowAbduction");
		Globals.Delete("Profile_" + Profile + "_AbductionTarget");
		Globals.Delete("Profile_" + Profile + "_CameFromTitleScreen");
		Globals.Delete("Profile_" + Profile + "_VtuberID");
		Globals.Delete("Profile_" + Profile + "_GrudgeConversationHappened");
		for (int i = 1; i < 11; i++)
		{
			SetSpecificEliminations(i, 0);
		}
		Globals.DeleteCollection("Profile_" + Profile + "_RivalEliminations", KeysOfRivalEliminations());
		Globals.DeleteCollection("Profile_" + Profile + "_SpecificEliminations", KeysOfSpecificEliminations());
		Globals.DeleteCollection("Profile_" + Profile + "_ItemRemoved", KeysOfItemRemoved());
	}
}
