using UnityEngine;

public static class SchoolGlobals
{
	private const string Str_DemonActive = "DemonActive_";

	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	private const string Str_KidnapVictim = "KidnapVictim";

	private const string Str_Population = "Population";

	private const string Str_RoofFence = "RoofFence";

	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	private const string Str_SCP = "SCP";

	private const string Str_HighSecurity = "HighSecurity";

	private const string Str_Seeds = "Seeds";

	private const string Str_SeedProgress = "SeedProgress";

	private const string Str_BiologySeeds = "BiologySeeds";

	private const string Str_BiologySeedProgress = "BiologySeedProgress";

	private const string Str_PlantProgress = "PlantProgress";

	public static int KidnapVictim
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_KidnapVictim");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_KidnapVictim", value);
		}
	}

	public static int Population
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Population");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Population", value);
		}
	}

	public static bool RoofFence
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_RoofFence");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_RoofFence", value);
		}
	}

	public static float PreviousSchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_PreviousSchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_PreviousSchoolAtmosphere", value);
		}
	}

	public static float SchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_SchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_SchoolAtmosphere", value);
		}
	}

	public static bool SchoolAtmosphereSet
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_SchoolAtmosphereSet");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_SchoolAtmosphereSet", value);
		}
	}

	public static bool ReactedToGameLeader
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_ReactedToGameLeader");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_ReactedToGameLeader", value);
		}
	}

	public static bool HighSecurity
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_HighSecurity");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_HighSecurity", value);
		}
	}

	public static bool SCP
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_SCP");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_SCP", value);
		}
	}

	public static int Seeds
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_Seeds");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_Seeds", value);
		}
	}

	public static int SeedProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SeedProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SeedProgress", value);
		}
	}

	public static int BiologySeeds
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BiologySeeds");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BiologySeeds", value);
		}
	}

	public static int BiologySeedProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_BiologySeedProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_BiologySeedProgress", value);
		}
	}

	public static int PlantProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_PlantProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_PlantProgress", value);
		}
	}

	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_DemonActive_" + demonID);
	}

	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_DemonActive_" + text, value);
	}

	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_DemonActive_");
	}

	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_GardenGraveOccupied_" + graveID);
	}

	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_GardenGraveOccupied_" + text, value);
	}

	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_GardenGraveOccupied_");
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_DemonActive_", KeysOfDemonActive());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_GardenGraveOccupied_", KeysOfGardenGraveOccupied());
		Globals.Delete("Profile_" + GameGlobals.Profile + "_KidnapVictim");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Population");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_RoofFence");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SchoolAtmosphere");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SchoolAtmosphereSet");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PreviousSchoolAtmosphere");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ReactedToGameLeader");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_HighSecurity");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SCP");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Seeds");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SeedProgress");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BiologySeeds");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_BiologySeedProgress");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_PlantProgress");
	}
}
