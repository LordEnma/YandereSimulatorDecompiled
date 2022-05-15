using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class SchoolGlobals
{
	// Token: 0x0600172A RID: 5930 RVA: 0x000E176C File Offset: 0x000DF96C
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x0600172B RID: 5931 RVA: 0x000E17A4 File Offset: 0x000DF9A4
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x0600172C RID: 5932 RVA: 0x000E1800 File Offset: 0x000DFA00
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x0600172D RID: 5933 RVA: 0x000E1830 File Offset: 0x000DFA30
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x0600172E RID: 5934 RVA: 0x000E1868 File Offset: 0x000DFA68
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x0600172F RID: 5935 RVA: 0x000E18C4 File Offset: 0x000DFAC4
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000E18F4 File Offset: 0x000DFAF4
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000E1924 File Offset: 0x000DFB24
	public static int KidnapVictim
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim", value);
		}
	}

	// Token: 0x17000422 RID: 1058
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000E1954 File Offset: 0x000DFB54
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000E1984 File Offset: 0x000DFB84
	public static int Population
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population", value);
		}
	}

	// Token: 0x17000423 RID: 1059
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000E19B4 File Offset: 0x000DFBB4
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000E19E4 File Offset: 0x000DFBE4
	public static bool RoofFence
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence", value);
		}
	}

	// Token: 0x17000424 RID: 1060
	// (get) Token: 0x06001736 RID: 5942 RVA: 0x000E1A14 File Offset: 0x000DFC14
	// (set) Token: 0x06001737 RID: 5943 RVA: 0x000E1A44 File Offset: 0x000DFC44
	public static float PreviousSchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere", value);
		}
	}

	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x06001738 RID: 5944 RVA: 0x000E1A74 File Offset: 0x000DFC74
	// (set) Token: 0x06001739 RID: 5945 RVA: 0x000E1AA4 File Offset: 0x000DFCA4
	public static float SchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere", value);
		}
	}

	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x0600173A RID: 5946 RVA: 0x000E1AD4 File Offset: 0x000DFCD4
	// (set) Token: 0x0600173B RID: 5947 RVA: 0x000E1B04 File Offset: 0x000DFD04
	public static bool SchoolAtmosphereSet
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet", value);
		}
	}

	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x0600173C RID: 5948 RVA: 0x000E1B34 File Offset: 0x000DFD34
	// (set) Token: 0x0600173D RID: 5949 RVA: 0x000E1B64 File Offset: 0x000DFD64
	public static bool ReactedToGameLeader
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader", value);
		}
	}

	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x0600173E RID: 5950 RVA: 0x000E1B94 File Offset: 0x000DFD94
	// (set) Token: 0x0600173F RID: 5951 RVA: 0x000E1BC4 File Offset: 0x000DFDC4
	public static bool HighSecurity
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity", value);
		}
	}

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x06001740 RID: 5952 RVA: 0x000E1BF4 File Offset: 0x000DFDF4
	// (set) Token: 0x06001741 RID: 5953 RVA: 0x000E1C24 File Offset: 0x000DFE24
	public static bool SCP
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP", value);
		}
	}

	// Token: 0x06001742 RID: 5954 RVA: 0x000E1C54 File Offset: 0x000DFE54
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", SchoolGlobals.KeysOfDemonActive());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", SchoolGlobals.KeysOfGardenGraveOccupied());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Population");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
	}

	// Token: 0x040022C5 RID: 8901
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x040022C6 RID: 8902
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x040022C7 RID: 8903
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x040022C8 RID: 8904
	private const string Str_Population = "Population";

	// Token: 0x040022C9 RID: 8905
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x040022CA RID: 8906
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x040022CB RID: 8907
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x040022CC RID: 8908
	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	// Token: 0x040022CD RID: 8909
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x040022CE RID: 8910
	private const string Str_SCP = "SCP";

	// Token: 0x040022CF RID: 8911
	private const string Str_HighSecurity = "HighSecurity";
}
