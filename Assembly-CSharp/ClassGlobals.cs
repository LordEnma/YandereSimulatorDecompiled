using UnityEngine;

public static class ClassGlobals
{
	private const string Str_Biology = "Biology";

	private const string Str_BiologyBonus = "BiologyBonus";

	private const string Str_BiologyGrade = "BiologyGrade";

	private const string Str_Chemistry = "Chemistry";

	private const string Str_ChemistryBonus = "ChemistryBonus";

	private const string Str_ChemistryGrade = "ChemistryGrade";

	private const string Str_Language = "Language";

	private const string Str_LanguageBonus = "LanguageBonus";

	private const string Str_LanguageGrade = "LanguageGrade";

	private const string Str_Physical = "Physical";

	private const string Str_PhysicalBonus = "PhysicalBonus";

	private const string Str_PhysicalGrade = "PhysicalGrade";

	private const string Str_Psychology = "Psychology";

	private const string Str_PsychologyBonus = "PsychologyBonus";

	private const string Str_PsychologyGrade = "PsychologyGrade";

	private const string Str_BonusStudyPoints = "BonusStudyPoints";

	public static int Biology
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Biology");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Biology", value);
		}
	}

	public static int BiologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BiologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BiologyBonus", value);
		}
	}

	public static int BiologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BiologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BiologyGrade", value);
		}
	}

	public static int Chemistry
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Chemistry");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Chemistry", value);
		}
	}

	public static int ChemistryBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_ChemistryBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_ChemistryBonus", value);
		}
	}

	public static int ChemistryGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_ChemistryGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_ChemistryGrade", value);
		}
	}

	public static int Language
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Language");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Language", value);
		}
	}

	public static int LanguageBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_LanguageBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_LanguageBonus", value);
		}
	}

	public static int LanguageGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_LanguageGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_LanguageGrade", value);
		}
	}

	public static int Physical
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Physical");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Physical", value);
		}
	}

	public static int PhysicalBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PhysicalBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PhysicalBonus", value);
		}
	}

	public static int PhysicalGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PhysicalGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PhysicalGrade", value);
		}
	}

	public static int Psychology
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Psychology");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Psychology", value);
		}
	}

	public static int PsychologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PsychologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PsychologyBonus", value);
		}
	}

	public static int PsychologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PsychologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PsychologyGrade", value);
		}
	}

	public static int BonusStudyPoints
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BonusStudyPoints");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BonusStudyPoints", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Biology");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BiologyBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BiologyGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Chemistry");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ChemistryBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ChemistryGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Language");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_LanguageBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_LanguageGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Physical");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PhysicalBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PhysicalGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Psychology");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PsychologyBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PsychologyGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BonusStudyPoints");
	}
}
