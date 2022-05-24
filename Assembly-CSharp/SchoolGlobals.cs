using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class SchoolGlobals
{
	// Token: 0x0600172A RID: 5930 RVA: 0x000E18E8 File Offset: 0x000DFAE8
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x0600172B RID: 5931 RVA: 0x000E1920 File Offset: 0x000DFB20
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x0600172C RID: 5932 RVA: 0x000E197C File Offset: 0x000DFB7C
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x0600172D RID: 5933 RVA: 0x000E19AC File Offset: 0x000DFBAC
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x0600172E RID: 5934 RVA: 0x000E19E4 File Offset: 0x000DFBE4
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x0600172F RID: 5935 RVA: 0x000E1A40 File Offset: 0x000DFC40
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000E1A70 File Offset: 0x000DFC70
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000E1AA0 File Offset: 0x000DFCA0
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
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000E1AD0 File Offset: 0x000DFCD0
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000E1B00 File Offset: 0x000DFD00
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
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000E1B30 File Offset: 0x000DFD30
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000E1B60 File Offset: 0x000DFD60
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
	// (get) Token: 0x06001736 RID: 5942 RVA: 0x000E1B90 File Offset: 0x000DFD90
	// (set) Token: 0x06001737 RID: 5943 RVA: 0x000E1BC0 File Offset: 0x000DFDC0
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
	// (get) Token: 0x06001738 RID: 5944 RVA: 0x000E1BF0 File Offset: 0x000DFDF0
	// (set) Token: 0x06001739 RID: 5945 RVA: 0x000E1C20 File Offset: 0x000DFE20
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
	// (get) Token: 0x0600173A RID: 5946 RVA: 0x000E1C50 File Offset: 0x000DFE50
	// (set) Token: 0x0600173B RID: 5947 RVA: 0x000E1C80 File Offset: 0x000DFE80
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
	// (get) Token: 0x0600173C RID: 5948 RVA: 0x000E1CB0 File Offset: 0x000DFEB0
	// (set) Token: 0x0600173D RID: 5949 RVA: 0x000E1CE0 File Offset: 0x000DFEE0
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
	// (get) Token: 0x0600173E RID: 5950 RVA: 0x000E1D10 File Offset: 0x000DFF10
	// (set) Token: 0x0600173F RID: 5951 RVA: 0x000E1D40 File Offset: 0x000DFF40
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
	// (get) Token: 0x06001740 RID: 5952 RVA: 0x000E1D70 File Offset: 0x000DFF70
	// (set) Token: 0x06001741 RID: 5953 RVA: 0x000E1DA0 File Offset: 0x000DFFA0
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

	// Token: 0x06001742 RID: 5954 RVA: 0x000E1DD0 File Offset: 0x000DFFD0
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

	// Token: 0x040022C6 RID: 8902
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x040022C7 RID: 8903
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x040022C8 RID: 8904
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x040022C9 RID: 8905
	private const string Str_Population = "Population";

	// Token: 0x040022CA RID: 8906
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x040022CB RID: 8907
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x040022CC RID: 8908
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x040022CD RID: 8909
	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	// Token: 0x040022CE RID: 8910
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x040022CF RID: 8911
	private const string Str_SCP = "SCP";

	// Token: 0x040022D0 RID: 8912
	private const string Str_HighSecurity = "HighSecurity";
}
