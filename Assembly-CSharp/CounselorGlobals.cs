using UnityEngine;

public static class CounselorGlobals
{
	private const string Str_DelinquentPunishments = "DelinquentPunishments";

	private const string Str_CounselorPunishments = "CounselorPunishments";

	private const string Str_CounselorVisits = "CounselorVisits";

	private const string Str_CounselorTape = "CounselorTape";

	private const string Str_ApologiesUsed = "ApologiesUsed";

	private const string Str_WeaponsBanned = "WeaponsBanned";

	private const string Str_BloodVisits = "BloodVisits";

	private const string Str_InsanityVisits = "InsanityVisits";

	private const string Str_LewdVisits = "LewdVisits";

	private const string Str_TheftVisits = "TheftVisits";

	private const string Str_TrespassVisits = "TrespassVisits";

	private const string Str_WeaponVisits = "WeaponVisits";

	private const string Str_BloodExcuseUsed = "BloodExcuseUsed";

	private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";

	private const string Str_LewdExcuseUsed = "LewdExcuseUsed";

	private const string Str_TheftExcuseUsed = "TheftExcuseUsed";

	private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";

	private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";

	private const string Str_BloodBlameUsed = "BloodBlameUsed";

	private const string Str_InsanityBlameUsed = "InsanityBlameUsed";

	private const string Str_LewdBlameUsed = "LewdBlameUsed";

	private const string Str_TheftBlameUsed = "TheftBlameUsed";

	private const string Str_TrespassBlameUsed = "TrespassBlameUsed";

	private const string Str_WeaponBlameUsed = "WeaponBlameUsed";

	private const string Str_ReportedAlcohol = "ReportedAlcohol";

	private const string Str_ReportedCigarettes = "ReportedCigarettes";

	private const string Str_ReportedCondoms = "ReportedCondoms";

	private const string Str_ReportedTheft = "ReportedTheft";

	private const string Str_ReportedCheating = "ReportedCheating";

	public static int DelinquentPunishments
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_DelinquentPunishments");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_DelinquentPunishments", value);
		}
	}

	public static int CounselorPunishments
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_CounselorPunishments");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CounselorPunishments", value);
		}
	}

	public static int CounselorVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_CounselorVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CounselorVisits", value);
		}
	}

	public static int CounselorTape
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_CounselorTape");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CounselorTape", value);
		}
	}

	public static int ApologiesUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_ApologiesUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_ApologiesUsed", value);
		}
	}

	public static int WeaponsBanned
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_WeaponsBanned");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_WeaponsBanned", value);
		}
	}

	public static int BloodVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BloodVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BloodVisits", value);
		}
	}

	public static int InsanityVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_InsanityVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_InsanityVisits", value);
		}
	}

	public static int LewdVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_LewdVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_LewdVisits", value);
		}
	}

	public static int TheftVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_TheftVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_TheftVisits", value);
		}
	}

	public static int TrespassVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_TrespassVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_TrespassVisits", value);
		}
	}

	public static int WeaponVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_WeaponVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_WeaponVisits", value);
		}
	}

	public static int BloodExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BloodExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BloodExcuseUsed", value);
		}
	}

	public static int InsanityExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_InsanityExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_InsanityExcuseUsed", value);
		}
	}

	public static int LewdExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_LewdExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_LewdExcuseUsed", value);
		}
	}

	public static int TheftExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_TheftExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_TheftExcuseUsed", value);
		}
	}

	public static int TrespassExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_TrespassExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_TrespassExcuseUsed", value);
		}
	}

	public static int WeaponExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_WeaponExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_WeaponExcuseUsed", value);
		}
	}

	public static int BloodBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BloodBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BloodBlameUsed", value);
		}
	}

	public static int InsanityBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_InsanityBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_InsanityBlameUsed", value);
		}
	}

	public static int LewdBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_LewdBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_LewdBlameUsed", value);
		}
	}

	public static int TheftBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_TheftBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_TheftBlameUsed", value);
		}
	}

	public static int TrespassBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_TrespassBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_TrespassBlameUsed", value);
		}
	}

	public static int WeaponBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_WeaponBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_WeaponBlameUsed", value);
		}
	}

	public static bool ReportedAlcohol
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_ReportedAlcohol");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ReportedAlcohol", value);
		}
	}

	public static bool ReportedCigarettes
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_ReportedCigarettes");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ReportedCigarettes", value);
		}
	}

	public static bool ReportedCondoms
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_ReportedCondoms");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ReportedCondoms", value);
		}
	}

	public static bool ReportedTheft
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_ReportedTheft");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ReportedTheft", value);
		}
	}

	public static bool ReportedCheating
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_ReportedCheating");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ReportedCheating", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DelinquentPunishments");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CounselorPunishments");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CounselorVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CounselorTape");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ApologiesUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_WeaponsBanned");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BloodVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_InsanityVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_LewdVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_TheftVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_TrespassVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_WeaponVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BloodExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_InsanityExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_LewdExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_TheftExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_TrespassExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_WeaponExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BloodBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_InsanityBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_LewdBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_TheftBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_TrespassBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_WeaponBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ReportedAlcohol");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ReportedCigarettes");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ReportedCondoms");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ReportedTheft");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ReportedCheating");
	}
}
