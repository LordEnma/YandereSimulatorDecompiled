using UnityEngine;

public static class SchemeGlobals
{
	private const string Str_CurrentScheme = "CurrentScheme";

	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	private const string Str_HelpingKokona = "HelpingKokona";

	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	private const string Str_SchemeStage = "SchemeStage_";

	private const string Str_SchemeStatus = "SchemeStatus_";

	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	private const string Str_ServicePurchased = "ServicePurchased_";

	private const string Str_UnlockExpulsionDaily = "UnlockExpulsionDaily";

	private const string Str_UnlockRejectionDaily = "UnlockRejectionDaily";

	public static int CurrentScheme
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_CurrentScheme");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CurrentScheme", value);
		}
	}

	public static bool EmbarassingSecret
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_EmbarassingSecret");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_EmbarassingSecret", value);
		}
	}

	public static bool HelpingKokona
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_HelpingKokona");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_HelpingKokona", value);
		}
	}

	public static bool UnlockExpulsionDaily
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_UnlockExpulsionDaily");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_UnlockExpulsionDaily", value);
		}
	}

	public static bool UnlockRejectionDaily
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_UnlockRejectionDaily");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_UnlockRejectionDaily", value);
		}
	}

	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SchemePreviousStage_" + schemeID);
	}

	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SchemePreviousStage_" + text, value);
	}

	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_SchemePreviousStage_");
	}

	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SchemeStage_" + schemeID);
	}

	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SchemeStage_" + text, value);
	}

	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_SchemeStage_");
	}

	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_SchemeStatus_" + schemeID);
	}

	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_SchemeStatus_" + text, value);
	}

	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_SchemeStatus_");
	}

	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_SchemeUnlocked_" + schemeID);
	}

	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_SchemeUnlocked_" + text, value);
	}

	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_SchemeUnlocked_");
	}

	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_ServicePurchased_" + serviceID);
	}

	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ServicePurchased_" + text, value);
	}

	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_ServicePurchased_");
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CurrentScheme");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_EmbarassingSecret");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_HelpingKokona");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_SchemePreviousStage_", KeysOfSchemePreviousStage());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_SchemeStage_", KeysOfSchemeStage());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_SchemeStatus_", KeysOfSchemeStatus());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_SchemeUnlocked_", KeysOfSchemeUnlocked());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_ServicePurchased_", KeysOfServicePurchased());
		Globals.Delete("Profile_" + GameGlobals.Profile + "_UnlockExpulsionDaily");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_UnlockRejectionDaily");
	}
}
